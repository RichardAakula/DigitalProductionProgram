using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DigitalProductionProgram.Övrigt
{
    internal abstract class Validate_Data
    {
        [DebuggerStepThrough]
        static string? NormalizeString(string? s)
        {
            // Normalizer: trim, collapse internal whitespace, normalize unicode
            if (string.IsNullOrWhiteSpace(s))
                return null;
            var trimmed = s.Trim();
            var collapsed = Regex.Replace(trimmed, @"\s+", " ");
            return collapsed.Normalize(NormalizationForm.FormC);
        }

        private static string CodeText(string name, int uppstart, int maskin)
        {
            //Hämtar ut ett namn som används för att meddela Processtekniker vilken parameter som behöver uppdateras.
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
        private static string Description_Codetext(int row, int formtemplateid)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT CodeText
                    FROM Protocol.Description
                           
                    WHERE id = (SELECT TOP(1) ProtocolDescriptionID FROM Protocol.Template 
                                    WHERE FormTemplateID = @formtemplateid
                                    AND RowIndex = @row)";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
            cmd.Parameters.AddWithValue("@row", row);
            var value = cmd.ExecuteScalar();
            return value?.ToString();
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
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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
                if (string.IsNullOrEmpty(type) || ControlValidator.IsStringNA(type))
                    IsOk = true;
            }
            ChangeColor_dgvCell(codetext, protocolDescriptionID, cell, IsErrorAndValidated, IsErrorAndHistoricalData, IsOnlyWarning, IsOk, startUp);

        }
        public static void IsMachine_Ok(string text, string codetext, int protocolDescriptionID, DataGridViewCell cell, int uppstart, string? nomValue, bool IsValueCritical, bool isMachineInRange)
        {
            if (Person.Role == "Utveckling" || (cell != null && cell.ReadOnly))
                return;

            var IsErrorAndValidated = false;       //Validerat Processkort
            var IsErrorAndHistoricalData = false;  //Baserat På Historiska Data
            bool IsReferenceOnly = false;             //Om fältet INTE är kritiskt
            bool IsOk = true;                       //Om fältet är ok

            var normNomValue = NormalizeString(nomValue);
            var normText = NormalizeString(text);

            if (!string.IsNullOrEmpty(normNomValue))
            {
                bool match = false;

                if (isMachineInRange)
                {
                    if (normNomValue.Contains('-'))
                    {
                        // Ex: K6-K9
                        var numbers = Regex.Matches(normNomValue, @"\d+")
                                           .Cast<Match>()
                                           .Select(m => int.Parse(m.Value))
                                           .ToList();
                        if (numbers.Count >= 2 && int.TryParse(Regex.Replace(normText ?? "", @"[^\d]", ""), out int value))
                        {
                            match = value >= numbers[0] && value <= numbers[1];
                        }
                    }
                    else if (normNomValue.Contains(','))
                    {
                        // Ex: E1, E2
                        var options = normNomValue.Split(',')
                            .Select(s => s.Trim())
                            .ToList();
                        match = options.Any(opt => string.Equals(opt, normText, StringComparison.OrdinalIgnoreCase));
                    }
                    else
                    {
                        // Exakt match
                        match = string.Equals(normNomValue, normText, StringComparison.OrdinalIgnoreCase);
                    }
                }
                else
                {
                    // Exakt match
                    match = string.Equals(normNomValue, normText, StringComparison.OrdinalIgnoreCase);
                }

                if (!match)//Nom och Value matchar INTE
                {
                    IsOk = false;
                    if (ProcesscardBasedOn.IsHistoricalData)
                        IsErrorAndHistoricalData = true;
                    if (ProcesscardBasedOn.IsValidated)
                        IsErrorAndValidated = true;
                }

                if (!IsValueCritical)//Om fältet INTE är kritiskt
                {
                    IsErrorAndHistoricalData = false;
                    IsErrorAndValidated = false;
                    IsReferenceOnly = true;
                   // IsOk = true;
                }
            }

            ChangeColor_dgvCell(codetext, protocolDescriptionID, cell, IsErrorAndValidated, IsErrorAndHistoricalData, IsReferenceOnly, IsOk, uppstart);
        }

        public static void IsHSPipe_Ok(string? text, string codetext, int protocolDescriptionID, string? nom, DataGridViewCell cell, int uppstart, bool isNomValueCritical)
        {
            if (Person.Role == "Utveckling")
                return;
            if (cell != null)
                if (cell.ReadOnly)
                    return;
            var Value = Tools.RegisterList.NomID_HS_Pipe(text);

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
                if (!string.IsNullOrWhiteSpace(Value) &&
                    double.TryParse(Value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                    IsText = false;
                else
                    IsText = true;
            }
            else
            {
                IsText = !double.TryParse(control.Text, out _);
            }

            if (IsText)
                Value_DataGridView_Text(IsValueCritical, codetext,   Nom,  Value, protocolDescriptionID, cell, control, uppstart, maskin);
            else
                Value_DataGridView_Number(IsValueCritical, codetext, Min, Nom, Max, Value, protocolDescriptionID, cell, control, uppstart, maskin);
        }
        private static void Value_DataGridView_Text(bool IsValueCritical, string name, string? Nom, string? Value, int protocolDescriptionID, DataGridViewCell cell = null, Control control = null, int uppstart = 0, int maskin = 0)
        {
            var IsErrorAndHistoricalData = false;
            var IsErrorAndValidated = false;
            var IsOnlyWarning = false;
            var IsOk = true;

            // Hämta aktuell text (från kontroll eller cell)
            var actualValue = control is null ? Value : control.Text;

            if (string.IsNullOrWhiteSpace(actualValue) && cell != null)
            {
                cell.Style.BackColor = Color.White;
                cell.Style.ForeColor = Color.Black;
                return;
            }

            var normNom = NormalizeString(Nom);
            var normValue = NormalizeString(actualValue);

            bool match = string.IsNullOrEmpty(normNom) || string.Equals(normValue, normNom, StringComparison.OrdinalIgnoreCase);

            if (!match)
            {
                IsOk = false;
                if (IsValueCritical)
                {
                    if (ProcesscardBasedOn.IsHistoricalData)
                        IsErrorAndHistoricalData = true;
                    if (ProcesscardBasedOn.IsValidated)
                        IsErrorAndValidated = true;
                    IsOk = false;
                }
                else
                {
                    IsOnlyWarning = true;
                }
            }

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

            var input = cell is null
                    ? control?.Text : Value;
            if (!double.TryParse(input?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                // Ingen giltig siffra → behandla som OK eller return
                return;
            }

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


        private static bool IsFieldReportedTo_Processtekniker(string text)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $"SELECT * FROM Processcard.ProposedChanges {Queries.WHERE_OrderID} AND Rubrik LIKE '%{text}%'";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@id", Order.OrderID);
            con.Open();
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return true;
            return false;
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
                SendMessage_Error(codetext, protocolDescriptionID, maskin, uppstart);
                if (Processcard_Changes.IsMessageSaved == false && Module.IsOkToSave || CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ExceedToleranceProcesscard, false) == false)
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
                if (IsOk)//Om det är tomt i Processkortet så är det ok att avbryta här
                    return;
                IsOk = false;
            }
            //if (IsOk)
            //{
            //    //Om ok blir det Grönt
            //    cell.Style.BackColor = CustomColors.Ok_Back;
            //    cell.Style.ForeColor = CustomColors.Ok_Front;
            //    return;
            //}

            if (IsOnlyWarning && IsOk == false)
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
                SendMessage_Error(codetext, protocolDescriptionID, maskin, uppstart);
                if (Processcard_Changes.IsMessageSaved == false && Module.IsOkToSave || CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ExceedToleranceProcesscard, false) == false)
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
            if (Module.IsOkToSave == false || IsFieldReportedTo_Processtekniker(CodeText(codetext, 0, maskin)) || Monitor.Monitor.factory == Monitor.Monitor.Factory.Holding)
            {
                Processcard_Changes.IsMessageSaved = true;
                return;
            }

            var Codename = CodeText(codetext, uppstart, maskin);
            string rubrik;
            string? text;
            if (is_OnlyNomValue)
            {
                text = $"{LanguageManager.GetString("validateData_Info_2_1")} {Codename} {LanguageManager.GetString("validateData_Info_2_2")}";

                rubrik = $"{LanguageManager.GetString("validateData_Info_3_1")} <br />" +
                         $"{CodeText(codetext, uppstart, maskin)} {LanguageManager.GetString("validateData_Info_3_2")} <br />" +
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
        private static void SendMessage_Error(string codetext, int protocolDescriptionID, int maskin, int uppstart)
        {
            //Om körprotokollet öppnas skippas detta.
            //Om Fältet är meddelat sen tidigare så skippas detta.
            //Om ordern körs på Holding skippas detta steg
            if (Module.IsOkToSave == false || IsFieldReportedTo_Processtekniker(CodeText(codetext, 0, maskin)) || Monitor.Monitor.factory == Monitor.Monitor.Factory.Holding)
            {
                if (Module.IsOkToSave)
                    InfoText.Show(LanguageManager.GetString("validateData_Info_6"), CustomColors.InfoText_Color.Bad, "Warning!");
                return;
            }

            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ExceedToleranceProcesscard, false))
            {
                var text = string.Format($"{LanguageManager.GetString("validateData_Info_8")}", Person.Role);
                var rubrik = $"{LanguageManager.GetString("validateData_Info_7_3")} <br />" +
                                 $"{CodeText(codetext, uppstart, maskin)} {LanguageManager.GetString("validateData_Info_7_4")} <br />" +
                                 $"{LanguageManager.GetString("validateData_Info_3_3")}";
                
                InfoText.Question(text, CustomColors.InfoText_Color.Bad, "Warning");
                if (InfoText.answer == InfoText.Answer.Yes)
                {
                    Points.Add_Points(8, "Meddelar Processtekniker att man kört utanför Processkortets gränser.");

                    var save_Meddelande = new Processcard_Changes(rubrik, protocolDescriptionID);
                    save_Meddelande.ShowDialog();
                }
                else
                    Processcard_Changes.IsMessageSaved = false;
            }
            else
            {
                var text = $"{LanguageManager.GetString("validateData_Info_9_1")}";
                var rubrik = $"{LanguageManager.GetString("validateData_Info_9_2")} <br />" +
                                 $"{CodeText(codetext, uppstart, maskin)} {LanguageManager.GetString("validateData_Info_9_3")} <br />" +
                                 $"{LanguageManager.GetString("validateData_Info_3_3")}";
               

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
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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
