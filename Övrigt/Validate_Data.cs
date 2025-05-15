using System;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Övrigt
{
    internal class Validate_Data
    {
        private static string Description_Codetext(int row, int formtemplateid)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT CodeText
                    FROM Protocol.Description
                           
                    WHERE id = (SELECT TOP(1) ProtocolDescriptionID FROM Protocol.Template 
                                    WHERE FormTemplateID = @formtemplateid
                                    AND RowIndex = @row)";
                var cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                cmd.Parameters.AddWithValue("@row", row);
                var value = cmd.ExecuteScalar();
                return value?.ToString();
            }
        }

        public static void ValidateData(DataGridViewCell cell, int row, bool IsValueCritical, int formtemplateid, int protocolDescriptionID, string? Min, string? Nom, string? Max, string? Value = null)
        {
            if(Person.Role == "Utveckling")
                return;
            if (Order.PartID is null)
                return;
            string ColumnName = null;
            if (Module.IsOkToSave)
                ColumnName = Description_Codetext(row, formtemplateid);
            const int Uppstart = 1;
            if (Value == null)
                if (cell?.Value != null)
                    Value = cell.Value.ToString();

            Value_CellOrControl(IsValueCritical, ColumnName, protocolDescriptionID, Min, Max, Value, Nom, cell, null, Uppstart);
        }


        public static void IsEquipmentOk(bool IsValueCritical, string? type, string codetext, int protocolDescriptionID, int startUp, DataGridViewCell cell, string db_Table)
        {
            if (Person.Role == "Utveckling")
                return;
            if (cell != null)
                if (cell.ReadOnly)
                    return;
            var IsErrorAndValidated = false;
            var IsErrorAndHistoricalData = false;
            var IsOnlyWarning = false;

            var IsOk = true;

            using (var con = new SqlConnection(Database.cs_ToolRegister))
            {
                var query = $"SELECT * FROM {db_Table} WHERE Typ = @typ AND ID_NUmmer = @idnumber";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idnumber", cell.Value.ToString());
                SQL_Parameter.String(cmd.Parameters, "@typ", type);
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows == false)
                {
                    if (ProcesscardBasedOn.IsHistoricalData)
                        IsErrorAndHistoricalData = true;
                    if (ProcesscardBasedOn.IsValidated)
                        IsErrorAndValidated = true;
                    if (IsValueCritical == false)
                        IsOnlyWarning = true;
                    IsOk = false;
                }
            }
            ChangeColor_dgvCell(codetext, protocolDescriptionID, cell, IsErrorAndValidated, IsErrorAndHistoricalData, IsOnlyWarning, IsOk, startUp);

        }
        public static void IsMachine_Ok(string text, string codetext, int protocolDescriptionID, DataGridViewCell cell, int uppstart, string? nomValue,  bool IsValueCritical, bool isMachineInRange)
        {
            if (Person.Role == "Utveckling")
                return;

            if (cell != null)
                if (cell.ReadOnly)
                    return;

            var IsErrorAndValidated = false;
            var IsErrorAndHistoricalData = false;
            var IsOnlyWarning = false;
            var IsOk = true;

           // var nom = Processcard.Nom_TextValue(codetext, formtemplateid, machine);
            if (nomValue != null)
            {
                if (isMachineInRange)
                {
                    if (nomValue.Contains('-'))
                    {
                        //Om Maskinen kan vara mellan 2 olika tal. t.ex. K6-K9
                        var NomValue = Regex.Replace(nomValue, "[^0-9.-]", "").Replace(" ", "");
                        var TextValue = Regex.Replace(text, "[^0-9.-]", "");

                        int.TryParse(NomValue.Substring(0, NomValue.IndexOf('-')), out var NomValue_Min);
                        var length = NomValue.Length - NomValue.Substring(0, NomValue.IndexOf('-') + 1).Length;
                        var startIndex = NomValue.IndexOf('-') + 1;

                        int.TryParse(NomValue.Substring(startIndex, length), out var NomValue_Max);

                        int.TryParse(TextValue, out var Value);

                        // Om värdet inte är mellan NomValue_Min och NomValue_Max
                        if (Enumerable.Range(NomValue_Min, NomValue_Max - NomValue_Min + 1).Contains(Value) == false)
                        {
                            if (ProcesscardBasedOn.IsHistoricalData)
                                IsErrorAndHistoricalData = true;
                            if (ProcesscardBasedOn.IsValidated)
                                IsErrorAndValidated = true;
                            
                            IsOk = false;
                        }
                    }
                    else if (nomValue.Contains(','))
                    {
                        //Om  Maskinen kan vara antingen ELLER. t.ex. E1, E2
                        if (nomValue.Contains(text) == false)
                        {
                            IsOk = false;
                            if (ProcesscardBasedOn.IsHistoricalData)
                                IsErrorAndHistoricalData = true;
                            if (ProcesscardBasedOn.IsValidated)
                                IsErrorAndValidated = true;
                        }
                    }
                }
                else
                {
                    //Om Kragmaskin är exakt. t.ex. K6
                    if (nomValue != text)
                    {
                        IsOk = false;
                        if (ProcesscardBasedOn.IsHistoricalData)
                            IsErrorAndHistoricalData = true;
                        if (ProcesscardBasedOn.IsValidated)
                            IsErrorAndValidated = true;
                    }
                }

                if (IsValueCritical == false)
                {
                    IsErrorAndHistoricalData = false;
                    IsErrorAndValidated = false;
                    IsOnlyWarning = true;
                    IsOk = true;
                }
            }

            ChangeColor_dgvCell(codetext, protocolDescriptionID, cell, IsErrorAndValidated, IsErrorAndHistoricalData, IsOnlyWarning, IsOk, uppstart);
        }
        public static void IsHSPipe_Ok(string? text, string codetext, int protocolDescriptionID, string? nom, DataGridViewCell cell, int uppstart, bool isNomValueCritical)
        {
            if (Person.Role == "Utveckling")
                return;
            if (cell != null)
                if (cell.ReadOnly)
                    return;
            var Value = Tools.NomID_HS_Pipe(text);

            Value_CellOrControl(isNomValueCritical, codetext, protocolDescriptionID, null, null, Value, nom, cell, null, uppstart);
        }
        public static void IsTool_Ok(string? text, string codetext, int protocolDescriptionID, string? nom, DataGridViewCell cell, int startup, int machine, string? min, string? max, bool IsValueCritical)
        {
            if (Person.Role == "Utveckling")
                return;
            if (cell != null)
                if (cell.ReadOnly)
                    return;
            var IsErrorAndValidated = false;
            var IsErrorAndHistoricalData = false;
            var IsOnlyWarning = false;

            var IsOk = true;

            if ( nom != null && nom.Contains('-'))
            {
                double.TryParse(nom.Substring(0, nom.IndexOf('-')), out var NomValue_Min);
                double.TryParse(nom.Substring(nom.IndexOf('-') + 1, nom.Length - (nom.IndexOf('-') + 1)), out var NomValue_Max);

                double.TryParse(Regex.Replace(text, "[A-Öa-ö]", ""), out var Value);

                // Om värdet inte är mellan NomValue_Min och NomValue_Max
                if (Value > NomValue_Max || Value < NomValue_Min)
                {
                    if (ProcesscardBasedOn.IsHistoricalData)
                        IsErrorAndHistoricalData = true;
                    if (ProcesscardBasedOn.IsValidated)
                        IsErrorAndValidated = true;

                    IsOk = false;
                }
            }
            else
            {
                text = Regex.Replace(text, "[a-öA-Ö\\s]", "");
                Value_CellOrControl(IsValueCritical, codetext, protocolDescriptionID,  min, max, text, nom, cell, null, startup, machine);
                return;
            }
            if (IsValueCritical == false)
            {
                IsErrorAndHistoricalData = false;
                IsErrorAndValidated = false;
                IsOnlyWarning = true;
                IsOk = true;
            }
            ChangeColor_dgvCell(codetext, protocolDescriptionID, cell, IsErrorAndValidated, IsErrorAndHistoricalData, IsOnlyWarning, IsOk, startup);
        }

        public static void Value_CellOrControl(bool IsValueCritical, string codetext, int protocolDescriptionID,  string? Min, string? Max, string? Value, string? Nom = null, DataGridViewCell cell = null, Control control = null,  int uppstart = 0, int maskin = 0)
        {
            bool IsText;
            if (control is null)
            {
                if (cell is null)
                    return;
                if (double.TryParse(Value, out _))
                    IsText = false;
                else
                    IsText = true;
            }
            else
            {
                if (double.TryParse(control.Text, out _))
                    IsText = false;
                else
                    IsText= true;
            }

            if (IsText)
                Value_DataGridView_Text(IsValueCritical, codetext,   Nom,  Value, protocolDescriptionID, cell, control, uppstart, maskin);
            else
                Value_DataGridView_Number(IsValueCritical, codetext, Min, Nom, Max, Value, protocolDescriptionID, cell, control, uppstart, maskin);
        }

        private static void Value_DataGridView_Text(bool IsValueCritical, string name, string? Nom,  string? Value, int protocolDescriptionID, DataGridViewCell cell = null, Control control = null, int uppstart = 0, int maskin = 0)
        {
            var IsErrorAndHistoricalData = false;
            var IsErrorAndValidated = false;
            var IsOnlyWarning = false;

            if (string.IsNullOrEmpty(Value) && cell != null)
            {
                cell.Style.BackColor = Color.White;
                cell.Style.ForeColor = Color.Black;
                return;
            }
            if (IsValueCritical)
            {
                if (Value != Nom && !string.IsNullOrEmpty(Nom))
                {
                    IsErrorAndHistoricalData = ProcesscardBasedOn.IsHistoricalData;
                    IsErrorAndValidated = ProcesscardBasedOn.IsValidated;
                }
            }
            else
            {
                if (Nom != Value && string.IsNullOrEmpty(Nom) == false)
                    IsOnlyWarning = true;
            }
            var IsOk = !IsErrorAndHistoricalData && !IsErrorAndValidated;


            if (control is null)
                ChangeColor_dgvCell(name, protocolDescriptionID, cell, IsErrorAndValidated, IsErrorAndHistoricalData, IsOnlyWarning, IsOk, uppstart, maskin);
            else
                ChangeColor_TextBox(name, protocolDescriptionID, control, IsErrorAndValidated, IsErrorAndHistoricalData, IsOnlyWarning, IsOk, uppstart, maskin);
        }
        private static void Value_DataGridView_Number(bool IsValueCritical, string name, string? Min, string? Nom, string? Max, string? Value, int protocolDescriptionID, DataGridViewCell cell = null, Control control = null, int uppstart = 0, int maskin = 0)
        {
            var IsErrorAndHistoricalData = false;
            var IsErrorAndValidated = false;
            var IsOnlyWarning = false;

            var IsOk = true;
            double value;
            double? min = null;
            double? nom = null;
            double? max = null;
            
            if (!string.IsNullOrEmpty(Min))
                if (double.TryParse(Min, out var value_min))
                    min = value_min;
            if (!string.IsNullOrEmpty(Nom))
                if (double.TryParse(Nom, out var value_nom))
                    nom = value_nom;
            if (!string.IsNullOrEmpty(Max))
                if (double.TryParse(Max, out var value_max))
                    max = value_max;

            if (cell is null)
                double.TryParse(control.Text, out value);
            else
                double.TryParse(Value, out value);

            if (ProcesscardBasedOn.IsHistoricalData || ProcesscardBasedOn.IsValidated)
            {
                var isHistorical = ProcesscardBasedOn.IsHistoricalData;
                var isValidated = ProcesscardBasedOn.IsValidated;
                var isCritical = IsValueCritical;
                var isNomCheck = min is null && max is null;
                var isOutOfRange = isNomCheck ? (value > nom || value < nom) : (value > max || value < min);

                if (isOutOfRange)
                {
                    if (isCritical)
                    {
                        if (isHistorical) 
                            IsErrorAndHistoricalData = true;
                        if (isValidated) 
                            IsErrorAndValidated = true;
                    }
                    else
                    {
                        IsOnlyWarning = true;
                    }
                }

                if (IsErrorAndHistoricalData || IsErrorAndValidated)
                {
                    IsOk = false;
                }
            }
          
            if (control is null)
                ChangeColor_dgvCell(name, protocolDescriptionID, cell, IsErrorAndValidated, IsErrorAndHistoricalData, IsOnlyWarning, IsOk, uppstart, maskin);
            else
                ChangeColor_TextBox(name, protocolDescriptionID, control, IsErrorAndValidated, IsErrorAndHistoricalData, IsOnlyWarning, IsOk, uppstart, maskin);
        }

        private static string CodeName(string name, int uppstart, int maskin)
        {
            string text;
            var namn = name;
            if (namn.Contains("tb_"))
            {
                namn = name.Remove(0, 3);
                if (namn.Contains('_'))
                    namn = namn.Remove(namn.Length - 2, 2);
            }

            if (maskin == 0)
                text = $"{namn} - {LanguageManager.GetString("protocol_Info_2")}: {uppstart}";
            else
                text = $"{namn} - {LanguageManager.GetString("machine")}: {maskin} - {LanguageManager.GetString("protocol_Info_2")}: {uppstart}";
            
            //Används för att kontrollera att namn + maskin ej redan finns Meddela Processtekniker Mailet
            if (uppstart == 0 && maskin != 0)
                text = $"{namn} - {LanguageManager.GetString("machine")}: {maskin}";

            if (uppstart == 0 && maskin == 0)
                text = $"{namn}";

            return text;
        }

        public static bool IsFieldReportedTo_Processtekniker(string text)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $"SELECT * FROM Processcard.ProposedChanges {Queries.WHERE_OrderID} AND Rubrik LIKE '%{text}%'";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
                return false;
            }
        }
       
        private static void ChangeColor_TextBox(string codetext, int protocolDescriptionID, Control ctrl, bool IsErrorAndValidated, bool IsErrorAndHistoricalData, bool IsOnlyWarning, bool IsOk, int uppstart, int maskin = 0)
        {
            if (ctrl is null)
            {
                //TextBox blir standard
                ctrl.BackColor = Color.White;
                ctrl.ForeColor = Color.DarkSlateGray;
                return;
            }
            if (ControlValidator.IsStringNA(ctrl.Text))
            {
                ctrl.ForeColor = Color.Red;
                ctrl.BackColor = Color.White;
                return;
            }

            if (IsOnlyWarning)
            {
                ctrl.BackColor = CustomColors.Warning_Back;
                ctrl.ForeColor = CustomColors.Warning_Front;
                return;
            }

            if (IsErrorAndHistoricalData)
            {
                ctrl.BackColor = CustomColors.Bad_Back;
                ctrl.ForeColor = CustomColors.Bad_Front;
                SendMessage_Warning(codetext, protocolDescriptionID, maskin, uppstart, false);
                if (Processcard_Changes.IsMessageSaved == false && Module.IsOkToSave)
                    ctrl.Text = string.Empty;
            }

            if (IsErrorAndValidated)
            {
                ctrl.BackColor = CustomColors.Bad_Back;
                ctrl.ForeColor = CustomColors.Bad_Front;
                SendMessage_Error(codetext, protocolDescriptionID, maskin, uppstart, false);
                if (Processcard_Changes.IsMessageSaved == false && Module.IsOkToSave)
                    ctrl.Text = string.Empty;
            }

            if (ProcesscardBasedOn.IsUnderDevelopment)
            {
                ctrl.BackColor = CustomColors.Ok_Back;
                ctrl.ForeColor = CustomColors.Ok_Front;
            }

            if (IsOk)
            {
                //Om ok blir det Grönt
                ctrl.BackColor = CustomColors.Ok_Back;
                ctrl.ForeColor = CustomColors.Ok_Front;
            }

            if (string.IsNullOrEmpty(ctrl.Text))
            {
                //TextBox blir standard
                ctrl.BackColor = Color.White;
                ctrl.ForeColor = Color.DarkSlateGray;
            }
        }
        private static void ChangeColor_dgvCell(string codetext, int protocolDescriptionID, DataGridViewCell cell, bool IsErrorAndValidated, bool IsErrorAndHistoricalData, bool IsOnlyWarning, bool IsOk, int uppstart, int maskin = 0)
        {
            if (cell == null)
                return;
            if (cell.Value is null)
            {
                //TextBox blir standard
                cell.Style.BackColor = Color.White;
                cell.Style.ForeColor = Color.DarkSlateGray;
                return;
            }
            if (ControlValidator.IsStringNA(cell.Value.ToString()))
            {
                cell.Style.ForeColor = Color.Red;
                cell.Style.BackColor = Color.White;
                IsOk = false;
            }
            if (IsOnlyWarning)
            {
                cell.Style.BackColor = CustomColors.Warning_Back;
                cell.Style.ForeColor = CustomColors.Warning_Front;
                return;
            }

            if (IsErrorAndHistoricalData)
            {
                cell.Style.BackColor = CustomColors.Bad_Back;
                cell.Style.ForeColor = CustomColors.Bad_Front;
                SendMessage_Warning(codetext, protocolDescriptionID, maskin, uppstart, false);
                if (Processcard_Changes.IsMessageSaved == false && Module.IsOkToSave)
                    cell.Value = string.Empty;
            }

            if (IsErrorAndValidated)
            {
                cell.Style.BackColor = CustomColors.Bad_Back;
                cell.Style.ForeColor = CustomColors.Bad_Front;
                SendMessage_Error(codetext, protocolDescriptionID, maskin, uppstart, false);
                if (Module.IsOkToSave) // && Processcard_Changes.IsMessageSaved == false
                    cell.Value = string.Empty;
            }

            if (ProcesscardBasedOn.IsUnderDevelopment)
            {
                cell.Style.BackColor = CustomColors.Ok_Back;
                cell.Style.ForeColor = CustomColors.Ok_Front;
            }

            if (IsOk)
            {
                //Om ok blir det Grönt
                cell.Style.BackColor = CustomColors.Ok_Back;
                cell.Style.ForeColor = CustomColors.Ok_Front;
            }

            if (string.IsNullOrEmpty(cell.Value.ToString()))
            {
                //TextBox blir standard
                cell.Style.BackColor = Color.White;
                cell.Style.ForeColor = Color.DarkSlateGray;
            }


        }
        private static void SendMessage_Warning(string codetext, int protocolDescriptionID, int maskin, int uppstart, bool is_OnlyNomValue)
        {
            //Om körprotokollet håller på öppnas skippas detta.
            //Om Fältet är meddelat sen tidigare så skippas detta.
            //Om ordern körs på Holding skippas detta steg
            if (Module.IsOkToSave == false || IsFieldReportedTo_Processtekniker(CodeName(codetext, 0, maskin)) || Monitor.Monitor.factory == Monitor.Monitor.Factory.Holding)
            {
                Processcard_Changes.IsMessageSaved = true;
                return;
            }

            var Codename = CodeName(codetext, uppstart, maskin);
            string rubrik;
            string? text;
            if (is_OnlyNomValue)
            {
                text = $"{LanguageManager.GetString("validateData_Info_2_1")} {Codename} {LanguageManager.GetString("validateData_Info_2_2")}";

                rubrik = $"{LanguageManager.GetString("validateData_Info_3_1")} <br />" +
                         $"{CodeName(codetext, uppstart, maskin)} {LanguageManager.GetString("validateData_Info_3_2")} <br />" +
                         $"{LanguageManager.GetString("validateData_Info_3_3")}";
            }
            else
            {
                text = $"{LanguageManager.GetString("validateData_Info_4_1")} {Codename} {LanguageManager.GetString("validateData_Info_4_2")}";
                rubrik = $"{LanguageManager.GetString("validateData_Info_5_1")} <br />" +
                         $"{Codename} {LanguageManager.GetString("validateData_Info_5_2")} <br />" +
                         $"{LanguageManager.GetString("validateData_Info_3_3")}";
            }

            InfoText.Show(text, CustomColors.InfoText_Color.Warning,"Warning!", null);

            Points.Add_Points(8, $"Meddelar Processtekniker att man kört utanför Processkortets gränser. Fieldname:({Codename})");
            var save_Meddelande = new Processcard_Changes(rubrik, protocolDescriptionID);
            save_Meddelande.ShowDialog();

        }
        private static void SendMessage_Error(string codetext, int protocolDescriptionID, int maskin, int uppstart, bool is_OnlyNomValue)
        {
            //Om körprotokollet öppnas skippas detta.
            //Om Fältet är meddelat sen tidigare så skippas detta.
            //Om ordern körs på Holding skippas detta steg
            if (Module.IsOkToSave == false || IsFieldReportedTo_Processtekniker(CodeName(codetext, 0, maskin)) || Monitor.Monitor.factory == Monitor.Monitor.Factory.Holding)
            {
                if (Module.IsOkToSave)
                    InfoText.Show(LanguageManager.GetString("validateData_Info_6"), CustomColors.InfoText_Color.Bad, "Warning!");
                return;
            }

            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ExceedToleranceProcesscard, false))
            {
                string? text;
                string rubrik;
                if (is_OnlyNomValue)
                {
                    text = $"{LanguageManager.GetString("validateData_Info_7_1")} {Person.Role} {LanguageManager.GetString("validateData_Info_7_2")}";
                    rubrik = $"{LanguageManager.GetString("validateData_Info_7_3")} <br />" +
                             $"{CodeName(codetext, uppstart, maskin)} {LanguageManager.GetString("validateData_Info_7_4")} <br />" +
                             $"{LanguageManager.GetString("validateData_Info_3_3")}";
                }
                else
                {
                    text = $"{LanguageManager.GetString("validateData_Info_8")} {Person.Role} {LanguageManager.GetString("validateData_Info_7_2")}";
                    rubrik = $"{LanguageManager.GetString("validateData_Info_7_3")} <br />" +
                             $"{CodeName(codetext, uppstart, maskin)} {LanguageManager.GetString("validateData_Info_7_4")} <br />" +
                             $"{LanguageManager.GetString("validateData_Info_3_3")}";
                }
                InfoText.Question(text, CustomColors.InfoText_Color.Bad, "Warning", null);
                if (InfoText.answer == InfoText.Answer.Yes)
                {
                    Points.Add_Points(8, "Meddelar Processtekniker att man kört utanför Processkortets gränser.");

                    var save_Meddelande = new Processcard_Changes(rubrik, protocolDescriptionID);
                    save_Meddelande.ShowDialog();
                }
            }
            else
            {
                string? text;
                string rubrik;

                if (is_OnlyNomValue)
                {
                    text = $"{LanguageManager.GetString("validateData_Info_9_1")}";
                    rubrik = $"{LanguageManager.GetString("validateData_Info_9_2")} <br />" +
                             $"{CodeName(codetext, uppstart, maskin)} {LanguageManager.GetString("validateData_Info_9_3")} <br />" +
                             $"{LanguageManager.GetString("validateData_Info_3_3")}";
                }
                else
                {
                    text = $"{LanguageManager.GetString("validateData_Info_9_4")}";
                    rubrik = $"{LanguageManager.GetString("validateData_Info_7_3")} <br />" +
                             $"{CodeName(codetext, uppstart, maskin)} {LanguageManager.GetString("validateData_Info_9_5")} <br />" +
                             $"{LanguageManager.GetString("validateData_Info_3_3")}";
                }

                InfoText.Show(text, CustomColors.InfoText_Color.Bad, "Warning!");

                var save_Meddelande = new Processcard_Changes(rubrik, protocolDescriptionID);
                save_Meddelande.ShowDialog();
            }

        }

       
        public static void IsCharOk_KeyPress(KeyPressEventArgs e, int row, int formtemplateid,  DataGridView dgv = null)
        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            byte? datatype = null;
            int? decimals = null;
            var IsUsingOnlyList_Protocol = false;
            var IsOkWriteText = false;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                SELECT Type, Decimals, MaxChars, IsList_Processcard, IsList_Protocol, IsOkWriteText
                FROM Protocol.Template
                WHERE FormTemplateID = @formtemplateid
                    
                    AND RowIndex = @row";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@row", row);
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    datatype = byte.Parse(reader["Type"].ToString());
                    if (int.TryParse(reader["Decimals"].ToString(), out var value))
                        decimals = value;
                    int.TryParse(reader["MaxChars"].ToString(), out _);
                    bool.TryParse(reader["IsList_Protocol"].ToString(), out IsUsingOnlyList_Protocol);
                    bool.TryParse(reader["IsOkWriteText"].ToString(), out IsOkWriteText);
                }
            }

            var decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            switch (datatype)
            {
                case 0:
                    if (decimals > 0)
                    {//decimaltal
                        if (!char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator && e.KeyChar != '-')
                        {
                            e.Handled = true;
                            return;
                        }
                        e.Handled = false;
                        return;
                    }

                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                    {//heltal
                        e.Handled = true;
                        return;
                    }
                    e.Handled = false;
                    return;

                case 1://text
                    if (Manage_Processcards.IsProcesscardUnderManagement)
                    {
                        e.Handled = false;
                        return;
                    }

                    if (IsUsingOnlyList_Protocol && IsOkWriteText)
                    {
                        e.Handled = false;
                        return;
                    }
                    if (IsUsingOnlyList_Protocol == false)
                    {
                        e.Handled = false;
                        return;
                    }

                    break;
            }

            Control control = null;
            if (dgv.Parent != null)
                control = dgv.Parent;
            
            InfoText.Show(LanguageManager.GetString("validateData_Info_1"), CustomColors.InfoText_Color.Warning, "Warning!", control);
            if (dgv != null)
                dgv.CurrentCell = dgv.Rows[row].Cells[dgv.CurrentCell.ColumnIndex];
            e.Handled = true;
        }
       
    }
}
