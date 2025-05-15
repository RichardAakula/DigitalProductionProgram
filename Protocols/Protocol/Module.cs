using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.Protocol
{
    public partial class Module : UserControl
    {
        public string? LeftHeader { get; set; }
        public int FormTemplateID { get; set; }
        public int RunprotocolWidth { get; set; }
        public int MachineIndex { get; set; }
        public bool IsAuthenticationNeeded { get; set; }
        public bool IsModuleUsedWithMultipleColumnsStartup { get; set; }
        public bool IsModuleUsingStartUpDates { get; set; }
        private int StartUp_Width { get; set; }

        public static bool IsOkToSave;
        public static int TotalStartUps
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT MAX(Uppstart) FROM [Order].Data WHERE OrderID = @orderid";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var total = cmd.ExecuteScalar();
                if (total != null)
                    if (short.TryParse(total.ToString(), out var result))
                        return result;
                return 1;
            }
        }
      

        private string HeaderText_StartUp(int startup, int oven)
        {
            return oven == 0 ? $"{startup}" : $"{startup}-Ugn# {oven}";
        }
        public static int StartUp(string headertext)
        {
            if (headertext.Contains('-'))
            {
                const string pattern = @"^\d+";
                var match = Regex.Match(headertext, pattern);
                headertext = match.Value;
            }

            if (int.TryParse(headertext, out var startup) == false)
            {
                _ = Activity.Stop($"Error Save Data: Wrong Startup: {headertext}");
            }
            return startup;

        }

        private int ColIndex_StartUp1
        {
            get
            {
                if (dgv_Module.Columns.Contains("col_StartUp_1"))
                    return dgv_Module.Columns["col_StartUp_1"].Index;
                return -1;
            }
        }

        public static bool IsOkAddStartUp(int startUp)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $@"
                    SELECT * FROM [Order].Data WHERE OrderID = @orderid AND Uppstart = @startup";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            cmd.Parameters.AddWithValue("@startup", startUp);
            con.Open();
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return true;

            return false;
        }

        private static string? DieType;
        private static string? TipType;
        

        private static string? MIN_Value(DataGridViewRow dgv_Row)
        {
            return dgv_Row.Cells["col_MIN"].Value?.ToString();
        }
        private static string? NOM_Value(DataGridViewRow dgv_Row)
        {
            return dgv_Row.Cells["col_NOM"].Value?.ToString();
        }
        private static string? MAX_Value(DataGridViewRow dgv_Row)
        {
            return dgv_Row.Cells["col_MAX"].Value?.ToString();
        }
        public int TotalModuleHeight
        {
            get
            {
                if (dgv_Module.Rows.Count < 1)
                    return 0;
                var totalHeight= (from DataGridViewRow row in dgv_Module.Rows where row.Visible select row.Height).Sum();
               
                if (dgv_Module.ColumnHeadersVisible)
                    totalHeight += dgv_Module.ColumnHeadersHeight;
                return totalHeight + 1;
            }

        }

        public static bool IsOk_CellValueChanged;
        public static bool IsOkShowList;
        public Equipment equipment;
        public Processcard.Save save_processcard;
        public Processcard.Load load_processcard;
        public Processcard processcard;
        


        public Module()
        {
            InitializeComponent();
            MainProtocol.Module_dataGridViews?.Add(dgv_Module);

            dgv_Module.ScrollBars = ScrollBars.None;
         

            equipment = new Equipment(this);
            save_processcard = new Processcard.Save(this);
            load_processcard = new Processcard.Load(this);
            processcard = new Processcard(this);
            IsOk_CellValueChanged = true;
        }


        private void Label_LEFT_Paint(object sender, PaintEventArgs e)
        {
            LeftHeader = LeftHeader?.Replace("\n", "");
            var width = Processcard.TextLength(LeftHeader, new Font("Arial", 8), CreateGraphics());
            Print_LeftLabel(e, LeftHeader, TotalModuleHeight / 2 - width / 2);

            dgv_Module.ClearSelection();
        }
        public static void Print_LeftLabel(PaintEventArgs e, string? text, int y, Font? font = null)
        {
            font ??= new Font("Arial", 8);
            var g = e.Graphics;
            
            g.DrawString(text, font, Brushes.Black, 0, y, new StringFormat(StringFormatFlags.DirectionVertical));
        }

        private static bool IsCodeTextExistInModule(DataGridView dgv, string codeText)
        {
            for (var i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["col_CodeText"].Value is null)
                    return false;
                if (dgv.Rows[i].Cells["col_CodeText"].Value.ToString() == codeText)
                    return true;
            }
            return false;
        }

        public void LoadTemplate(bool IsHeaderVisible, int processcardColWidth, int runProtocolColWidth, bool isOkChangeProcessData)
        {
            StartUp_Width = runProtocolColWidth;

            var CheckIfOnlyNomValue_ColIndex = new List<int>();
            dgv_Module.ColumnHeadersVisible = IsHeaderVisible;
            dgv_Module.Columns["col_MIN"].Width = dgv_Module.Columns["col_NOM"].Width = dgv_Module.Columns["col_MAX"].Width = processcardColWidth;
            dgv_Module.Columns["col_StartUp_1"].Width = runProtocolColWidth;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    SELECT ProtocolDescriptionID, CodeText, Unit, ColumnIndex, RowIndex, Type, Decimals, IsUsedInProcesscard, IsValueCritical, IsList_Processcard, IsList_Protocol, IsOkWriteText, IsRequired, IsAuthenticationNeeded, IsMultipleColumnsStartup, IsStartUpDates
                    FROM Protocol.Template as template
                    INNER JOIN Protocol.Description as description
                        ON template.ProtocolDescriptionID = description.ID
                    INNER JOIN Protocol.FormTemplate as formtemplate
                        ON template.FormTemplateID = formtemplate.FormTemplateID
                    WHERE template.FormTemplateID = @formtemplateid
                        AND MainTemplateID = @maintemplateid
                        AND RowIndex IS NOT NULL
                    ORDER BY RowIndex, ColumnIndex";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@formtemplateid", FormTemplateID);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                con.Open();
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    bool.TryParse(reader["IsAuthenticationNeeded"].ToString(), out var isAuthenticationNeeded);
                    IsAuthenticationNeeded = isAuthenticationNeeded;
                    bool.TryParse(reader["IsMultipleColumnsStartup"].ToString(), out var isMultipleColumnsStartup);
                    IsModuleUsedWithMultipleColumnsStartup = isMultipleColumnsStartup;
                    bool.TryParse(reader["IsStartUpDates"].ToString(), out var isStartUpDates);
                    IsModuleUsingStartUpDates = isStartUpDates;

                    int.TryParse(reader["ProtocolDescriptionID"].ToString(), out var protocoldescriptionID);
                    int.TryParse(reader["Type"].ToString(), out var type);

                    var codetext = reader["CodeText"].ToString();
                    var unit = reader["Unit"].ToString();
                    if (bool.TryParse(reader["IsValueCritical"].ToString(), out var isValueCritical) == false)
                        isValueCritical = true;
                    if (bool.TryParse(reader["IsList_Protocol"].ToString(), out var isListProtocol) == false)
                        isListProtocol = true;
                    if (bool.TryParse(reader["IsList_Processcard"].ToString(), out var isListProcesscard) == false)
                        isListProcesscard = true;
                    if (bool.TryParse(reader["IsOkWriteText"].ToString(), out var isOkWriteText) == false)
                        isOkWriteText = true;
                    if (bool.TryParse(reader["IsUsedInProcesscard"].ToString(), out var isUsedInProcesscard) == false)
                        isUsedInProcesscard = true;

                    int.TryParse(reader["RowIndex"].ToString(), out var row);
                    int? col = null;
                    if (int.TryParse(reader["ColumnIndex"].ToString(), out var colIndex))
                    {
                        col = colIndex;
                        CheckIfOnlyNomValue_ColIndex.Add(colIndex);
                    }
                    
                    if (IsCodeTextExistInModule(dgv_Module, codetext) == false)
                    {
                        dgv_Module.Rows.Add();
                        dgv_Module.Rows[row].Cells["col_CodeText"].Value = codetext;
                        dgv_Module.Rows[row].Cells["col_Unit"].Value = unit;
                        dgv_Module.Rows[row].Cells["col_IsValueCritical"].Value = isValueCritical;
                        dgv_Module.Rows[row].Cells["col_IsList_Protocol"].Value = isListProtocol;
                        dgv_Module.Rows[row].Cells["col_IsList_Processcard"].Value = isListProcesscard;
                        dgv_Module.Rows[row].Cells["col_IsOkWriteText"].Value = isOkWriteText;
                        dgv_Module.Rows[row].Cells["col_ProtocolDescriptionID"].Value = protocoldescriptionID;
                        dgv_Module.Rows[row].Cells["col_DataType"].Value = type;
                    }
                    if (col != null && isUsedInProcesscard)
                        UnLockCell(row, col);

                    SetColorCodeText(isValueCritical, dgv_Module.Rows[row].Cells["col_CodeText"]);
                }
                
            }

            if (CheckIfOnlyNomValue_ColIndex.Contains(0) == false && CheckIfOnlyNomValue_ColIndex.Contains(2) == false)
                dgv_Module.Columns["col_MIN"].Visible = dgv_Module.Columns["col_MAX"].Visible = false;
            if (isOkChangeProcessData)
            {
                dgv_Module.Columns["col_MIN"].ReadOnly = false;
                dgv_Module.Columns["col_NOM"].ReadOnly = false;
                dgv_Module.Columns["col_MAX"].ReadOnly = false;
            }
        }

        private void SetColorCodeText(bool isCritical, DataGridViewCell cell)
        {
            cell.Style.ForeColor = isCritical ? Color.Black : CustomColors.Ok_Front;
            cell.Style.BackColor = Color.FromArgb(252, 250, 235);
            if (isCritical)
                cell.Style.Font = new Font(dgv_Module.Columns["col_CodeText"].DefaultCellStyle.Font, FontStyle.Bold);
        }
        private void UnLockCell(int row, int? col)
        {
            switch (col)
            {
                case 0:
                dgv_Module.Rows[row].Cells["col_MIN"].Style.BackColor = Color.Gainsboro;
                    break;
                case 1:
                    dgv_Module.Rows[row].Cells["col_NOM"].Style.BackColor = Color.Silver;
                    break;
                case 2:
                    dgv_Module.Rows[row].Cells["col_MAX"].Style.BackColor = Color.Gainsboro;
                    break;
            }
        }


        public void Clear_ProcessData()
        {
            for (var i = 0; i < dgv_Module.Rows.Count; i++)
            {
                dgv_Module.Rows[i].Cells[dgv_Module.ColumnCount - 3].Value = string.Empty;
                dgv_Module.Rows[i].Cells[dgv_Module.ColumnCount - 2].Value = string.Empty;
                dgv_Module.Rows[i].Cells[dgv_Module.ColumnCount - 1].Value = string.Empty;
            }
        }
        
        public void Load_Data(int formTemplateID)
        {
            Load_StartUps();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                        SELECT DISTINCT Value, TextValue, DateValue, MachineIndex, Uppstart, Ugn, template.RowIndex, template.Decimals, template.Type
                        FROM [Order].Data AS protocol
	                        JOIN Protocol.Template as template
		                        ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
	                        JOIN Protocol.Description as descr
		                        ON descr.id = template.ProtocolDescriptionID
                        WHERE OrderID = @orderid
                            AND FormTemplateID = @formtemplateid
                            AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0))
                            AND template.RowIndex IS NOT NULL
                            AND Uppstart > 0
                       ORDER BY Uppstart, Ugn, template.RowIndex";
                con.Open();
                var cmd = new SqlCommand(query, con);
                SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@formtemplateid", formTemplateID);
                cmd.Parameters.AddWithValue("@machineindex", MachineIndex);
                var reader = cmd.ExecuteReader();


                int? previousStartup = null;
                int? previousOven = null;
                
                var activeColumn = ColIndex_StartUp1;
                while (reader.Read())
                {
                    int.TryParse(reader["Uppstart"].ToString(), out var startup);
                    int.TryParse(reader["Ugn"].ToString(), out var oven);

                    
                    int.TryParse(reader["Type"].ToString(), out var type);
                    int.TryParse(reader["RowIndex"].ToString(), out var row);
                    
                    var value = string.Empty;
                    switch (type)
                    {
                        case 0: //NumberValue
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);
                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                                value = Processcard.Format_Value(NumberValue, decimals);
                            break;
                        case 1://TextValue
                            value = reader["TextValue"].ToString();
                            break;
                        case 2://BoolValue
                            break;
                        case 3://DateValue
                            if (DateTime.TryParse(reader["DateValue"].ToString(), out var date))
                            {
                                var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                                var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                                value = formattedDate;
                            }
                                
                            break;
                    }

                    if (string.IsNullOrEmpty(value))
                        value = "N/A";
                   
                    if (previousStartup.HasValue && previousOven.HasValue)
                    {
                        if (startup != previousStartup.Value || oven != previousOven.Value)
                            activeColumn++;
                    }

                    previousStartup = startup;
                    previousOven = oven;

                    var cell = dgv_Module.Rows[row].Cells[activeColumn];
                    if (Browse_Protocols.Browse_Protocols.Is_BrowsingProtocols == false)
                        cell.Selected = true;
                    cell.Value = value;
                   
                }
            }
           
            if (IsAuthenticationNeeded)
                for (int col = ColIndex_StartUp1; col < dgv_Module.Columns.Count; col++)
                {
                    if (dgv_Module.Rows[dgv_Module.Rows.Count - 1].Cells[col].Value != null)
                        equipment.Lock_Equipment(col);
                }
            dgv_Module.ClearSelection();
            
        }
        private void Load_StartUps()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"SELECT MAX(Uppstart) FROM [Order].Data WHERE OrderID = @orderid";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value == null) 
                return;
            int.TryParse(value.ToString(), out int startups);
            //Detta lägger till kolumner för Ugn 2 för första Uppstarten
            if (IsModuleUsedWithMultipleColumnsStartup)
            {
                dgv_Module.Columns["col_StartUp_1"].HeaderText = "1-Ugn# 1";
                var totalColumns = SinteringOven.TotalOvens(1);
                for (int oven = 2; oven < totalColumns + 1; oven++)
                    AddStartup(1, oven);
            }
            //Lägger till kolumner för Ugn för resterande uppstarter
            for (var startup = 2; startup < startups+1; startup++)
            {
                if (IsModuleUsedWithMultipleColumnsStartup)
                    for (int oven = 1; oven < SinteringOven.TotalOvens(startup) + 1; oven++)
                        AddStartup(startup, oven);
                else
                    AddStartup(startup);
            }
        }
        
        public void AddStartup(int startUp, int oven = 0)
        {
            var clonedColumn = dgv_Module.Columns[^1].Clone() as DataGridViewColumn;
            dgv_Module.Columns.Add(clonedColumn ?? new DataGridViewTextBoxColumn());

            dgv_Module.Columns[^1].HeaderText = HeaderText_StartUp(startUp,oven);
            dgv_Module.Columns[^1].ReadOnly = false;
            dgv_Module.Columns[^1].Width = StartUp_Width;

        }
        public void RemoveStartup()
        {
            var startUp = StartUp(dgv_Module.Columns[^1].HeaderText);
            dgv_Module.Columns.RemoveAt(dgv_Module.Columns.Count - 1);
            dgv_Module.ClearSelection();
           
            if (IsModuleUsedWithMultipleColumnsStartup)
                for (int col = dgv_Module.Columns.Count - 1; col > ColIndex_StartUp1; col--)
                {
                    if (StartUp(dgv_Module.Columns[col].HeaderText) == startUp)
                        dgv_Module.Columns.RemoveAt(col);
                }

        }
        public void Divide_StartUp(bool IsOkAddExtraColumn)
        {
            for (var col = ColIndex_StartUp1; col < dgv_Module.Columns.Count; col++)
            {
                var startup = StartUp(dgv_Module.Columns[col].HeaderText);
                var totalColumns = SinteringOven.TotalOvens(startup);

                if (IsOkAddExtraColumn && col == dgv_Module.Columns.Count - 1)
                    totalColumns++;
                if (startup > 0)
                    if (IsModuleUsedWithMultipleColumnsStartup == false)
                        dgv_Module.Columns[col].Width = RunprotocolWidth * totalColumns;
            }
        }

        public void Remove_AllStartups()
        {
            var colIndex_StartUp1 = ColIndex_StartUp1;
            do
            {
                dgv_Module.Columns.RemoveAt(dgv_Module.Columns.Count - 1);
            } while (dgv_Module.Columns.Count > colIndex_StartUp1);
            
        }

        private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress -= AllowedChars_CellKeyPress;
            tb.KeyPress += AllowedChars_CellKeyPress;
            tb.ShortcutsEnabled = false;
        }
        private void AllowedChars_CellKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (IsOkToSave == false && Manage_Processcards.IsProcesscardUnderManagement == false)
            {
                e.Handled = true;
                return;
            }

            var row = dgv_Module.CurrentCell.RowIndex;
            if (IsAuthenticationNeeded && row > dgv_Module.Rows.Count - 3)
            {
                e.Handled = true;
                return;
            }
                
            Validate_Data.IsCharOk_KeyPress(e, row, FormTemplateID,  dgv_Module);
        }
        private void Module_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Module == null || IsOkToSave == false)
                return;
            var row = e.RowIndex;
            dgv_Module.Rows[row].Cells["col_CodeText"].Style.BackColor = Color.Khaki;
        }
        private void Module_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dgv_Module[e.ColumnIndex, e.RowIndex];
                string toolTipText;
                if (cell.Style.BackColor == CustomColors.Bad_Back)
                {
                    toolTipText = $"{LanguageManager.GetString("cell_Protocol_ToolTip_1")}\n" +
                                  $"{cell.Value}";
                }
                else if (cell.Style.BackColor == CustomColors.Warning_Back)
                {
                    toolTipText = $"{LanguageManager.GetString("cell_Protocol_ToolTip_2")}\n" +
                                  $"{cell.Value}";
                }
                else if (cell.Style.BackColor == CustomColors.Ok_Back)
                    toolTipText = $"{cell.Value}";
                else
                    toolTipText = $"{cell.Value}";

                cell.ToolTipText = toolTipText;
            }
        }
        private void Module_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Module == null || IsOkToSave == false)
                return;
            var row = e.RowIndex;
            dgv_Module.Rows[row].Cells["col_CodeText"].Style.BackColor = Color.White;
        }
        private void Protocol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dgv_Module.CurrentCell;
            if (IsOkToSave == false || cell.ReadOnly)
                return;
            cell.Value = "N/A";
            cell.Style.ForeColor = Color.Red;
            cell.Style.BackColor = Color.White;
        }
        private void Module_Leave(object sender, EventArgs e)
        {
            dgv_Module.ClearSelection();
        }
        public void Module_ValidateData_SaveData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Browse_Protocols.Browse_Protocols.Is_BrowsingProtocols || Manage_Processcards.IsProcesscardUnderManagement)
                return;
            if (dgv_Module.CurrentCell is null)
                return;
            var row = dgv_Module.CurrentCell.RowIndex;
            var oven = 0;
            var col = dgv_Module.CurrentCell.ColumnIndex;
            if (dgv_Module.Columns[col].ReadOnly)
                return;
            var dgv_Row = dgv_Module.Rows[row];
            var cell = dgv_Module.Rows[row].Cells[col];

            if (cell.Value is null || string.IsNullOrEmpty(cell.Value.ToString()))
                return;

            var startUp = col + 1;
            
            if (row < 0)
                return;
            if (IsModuleUsedWithMultipleColumnsStartup)
                oven = SinteringOven.Oven(dgv_Module.Columns[e.ColumnIndex].HeaderText);
            int.TryParse(dgv_Module.Rows[row].Cells["col_ProtocolDescriptionID"].Value.ToString(), out var protocolDescriptionID);

            bool.TryParse(dgv_Row.Cells["col_IsValueCritical"].Value.ToString(), out var IsValueCritical);
           
            var IsValidated = false;
            if (IsOk_CellValueChanged)
            {
                string? text;
                switch (protocolDescriptionID)
                {
                    case 1:     //HACK
                        Validate_Data.IsMachine_Ok(cell.Value.ToString(), "HACK", protocolDescriptionID, dgv_Module.CurrentCell, startUp, NOM_Value(dgv_Row), IsValueCritical, false);
                        IsValidated = true;
                        break;
                    case 10:    //KRAGMASKIN
                        Validate_Data.IsMachine_Ok(cell.Value.ToString(), "KRAGMASKIN", protocolDescriptionID, dgv_Module.CurrentCell, startUp, NOM_Value(dgv_Row), IsValueCritical, true);
                        IsValidated = true;
                        break;
                    case 75:   //RÖR ID# POS 1
                    case 160:  //RÖR ID# POS 2
                    case 161:  //RÖR ID# POS 3
                        text = dgv_Module.Rows[row].Cells[col].Value.ToString();
                        Validate_Data.IsHSPipe_Ok(text, dgv_Row.Cells[0].Value.ToString(), protocolDescriptionID, NOM_Value(dgv_Row), dgv_Row.Cells[col], startUp, IsValueCritical);
                        IsValidated = true;
                        break;
                    case 80:    //EXTRUDER
                        Validate_Data.IsMachine_Ok(cell.Value.ToString(), "EXTRUDER", protocolDescriptionID, dgv_Module.CurrentCell, startUp, NOM_Value(dgv_Row), IsValueCritical, false);
                        IsValidated = true;
                        break;
                    case 83:    //MUNSTYCKE
                    case 209:   //KÄRNA
                        text = dgv_Module.Rows[row].Cells[col].Value.ToString();
                        Validate_Data.IsTool_Ok(text, dgv_Row.Cells["col_CodeText"].Value.ToString(), protocolDescriptionID, NOM_Value(dgv_Row), cell, startUp, MachineIndex, MIN_Value(dgv_Row), MAX_Value(dgv_Row), IsValueCritical);
                        IsValidated = true;
                        break;
                    case 159:   //HS MASKIN
                        HeatShrink.Change_Color_MachineName(dgv_Module);
                        Refresh();
                        IsValidated = true;
                        break;
                    case 95:    //SINTRINGSUGN
                        Validate_Data.IsMachine_Ok(cell.Value.ToString(), "SINTRINGSUGN", protocolDescriptionID, dgv_Module.CurrentCell, startUp, NOM_Value(dgv_Row), IsValueCritical, true);
                        IsValidated = true;
                        break;
                    case 277:   //Tork - TID
                        Extrusion.Change_DryTimeUnderProduction(cell, dgv_Module, MachineIndex);
                        IsValidated = true;
                        break;
                    case 305:   //SCREW
                        Validate_Data.IsEquipmentOk(IsValueCritical, NOM_Value(dgv_Row), dgv_Module.Rows[row].Cells["col_CodeText"].Value.ToString(), protocolDescriptionID, startUp, cell, "Register_Skruvar");
                        IsValidated = true;
                        break;
                    case 306:   //DRYER
                        Validate_Data.IsEquipmentOk(IsValueCritical, NOM_Value(dgv_Row), dgv_Module.Rows[row].Cells["col_CodeText"].Value.ToString(), protocolDescriptionID, startUp, cell, "Register_Torkar");
                        IsValidated = true;
                        break;
                    case 307:   //HEAD
                        Validate_Data.IsEquipmentOk(IsValueCritical, NOM_Value(dgv_Row), dgv_Module.Rows[row].Cells["col_CodeText"].Value.ToString(), protocolDescriptionID, startUp, cell, "Register_Huvud");
                        IsValidated = true;
                        break;
                    case 308:   //TORPEDO
                        Validate_Data.IsEquipmentOk(IsValueCritical, NOM_Value(dgv_Row), dgv_Module.Rows[row].Cells["col_CodeText"].Value.ToString(), protocolDescriptionID, startUp, cell, "Register_Torpeder");
                        IsValidated = true;
                        break;
                    case 309:   //TORPEDONUTS
                        Validate_Data.IsEquipmentOk(IsValueCritical, NOM_Value(dgv_Row), dgv_Module.Rows[row].Cells["col_CodeText"].Value.ToString(), protocolDescriptionID, startUp, cell, "Register_Torpedmuttrar");
                        IsValidated = true;
                        break;
                    case 314:
                        IsValidated = true;
                        break;
                    //case 316: //CALIBRATION
                    //    Validate_Data.IsEquipmentOk(NOM_Value(dgv_Row), dgv_Module.Rows[row].Cells["col_CodeText"].Value.ToString(), startUp, cell, "Register_Kalibreringar");
                    //    IsValidated = true;
                    //    break;
                    case 325:   //RENGJORT CYLINDER
                        if (IsOkToSave)
                        {
                            Extrusion.Cleaned_Cylinder(dgv_Module, FormTemplateID, MachineIndex);
                            cell.Selected = true;
                        }
                        break;
                    case 326:   //RENGJORT UTRUSTNING
                        if (IsOkToSave)
                        {
                            Extrusion.Cleaned_Equipment(dgv_Module, FormTemplateID);
                            cell.Selected = true;
                        }
                        break;
                }
            }

            if (IsValidated == false)
                Validate_Data.ValidateData(cell, row, IsValueCritical, FormTemplateID, 0,MIN_Value(dgv_Row), NOM_Value(dgv_Row), MAX_Value(dgv_Row));

            DatabaseManagement.Save_Data(dgv_Module, row, FormTemplateID, oven, MachineIndex);
        }
        public void Module_ShowSpecialItems_CellRightMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (IsOkShowList == false || dgv_Module.Columns[e.ColumnIndex].ReadOnly)
                return;
            if (IsAuthenticationNeeded && e.RowIndex > dgv_Module.Rows.Count - 3)
                return;
            var isProcesscardUnderManagement = Manage_Processcards.IsProcesscardUnderManagement;
            dgv_Module.Focus();
            var row = e.RowIndex;
            var col = e.ColumnIndex;
            if (row < 0)
                return;
            
           
            bool.TryParse(dgv_Module.Rows[row].Cells["col_IsList_Processcard"].Value.ToString(), out var isListProcesscard);
            if (Manage_Processcards.IsProcesscardUnderManagement && isListProcesscard == false)
                return;

            DataGridViewCell[] cells = { dgv_Module.Rows[row].Cells[e.ColumnIndex] };
            var dgv_Row = dgv_Module.Rows[row];
            var items = new List<string>();
            dgv_Module.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            var IsItemsMultipleColumns = false;
            int.TryParse(dgv_Module.Rows[row].Cells["col_ProtocolDescriptionID"].Value.ToString(), out var protocolDescriptionID);

            if (e.Button == MouseButtons.Right)
            {
                
                bool.TryParse(dgv_Module.Rows[row].Cells["col_IsOkWriteText"].Value.ToString(), out var isOkWriteText);
                bool.TryParse(dgv_Module.Rows[e.RowIndex].Cells["col_IsList_Protocol"].Value.ToString(), out var IsListProtocol);
                int.TryParse(dgv_Module.Columns[e.ColumnIndex].HeaderText, out var startup);
                if (IsListProtocol)
                {
                    switch (protocolDescriptionID)
                    {
                        case 10:    //KRAGMASKIN
                            items = Machines.Kragmaskiner(FormTemplateID);
                            break;
                        case 19:    //ENKEL/DUBBEL KRAGE
                            items.Add("Enkel");
                            items.Add("Dubbel");
                            break;
                        case 22:    //DUBBELTAPERING
                        case 29:    //BYTE/RENGÖRING GRIPPERS
                        case 31:    //BYTE HACKBETT
                        case 68:    //BROMSAD PRODUKT
                        case 69:    //VINKELREGLERING
                        case 86:    //MELLANPRESSNING
                        case 125:   //HASTIGHETSREGLERARE
                        case 227:   //LÄCKSÖKNING
                        case 228:   //ANTISTAT
                        case 231:   //ANVÄNDS UGN
                        case 291:   //TRYCKREGLERING
                        case 292:   //OD REGLERING
                        case 326:   //RENGJORT UTRUSTNING
                        case 313:
                            items.Add(LanguageManager.GetString("yes"));
                            items.Add(LanguageManager.GetString("no"));
                            break;
                        case 80:    //EXTRUDER
                            items = CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.ExtruderRegister) ? DigitalProductionProgram.Equipment.Equipment.List_From_Register("Extruder", "Extruder_Skruvar") : Machines.Extruders("EXTRUDER");
                            break;
                        case 81:    //CYLINDER
                            items = Machines.Cylinders;
                            break;
                        case 85:    //KANYL TYP
                            items.Add("S");
                            items.Add("D");
                            items.Add("S/D");
                            break;
                        case 108:   //AUTO/MAN
                            items.Add("Auto");
                            items.Add("Manuell");
                            break;
                        case 239:
                        case 240:
                            var InComingDate = dgv_Module.Rows[row].Cells[col].Value is null ? string.Empty : dgv_Module.Rows[row].Cells[col].Value.ToString();
                            var datePicker = new DatePicker(InComingDate);
                            datePicker.ShowDialog();
                            dgv_Module.Rows[row].Cells[col].Value = datePicker.OutGoingDate;
                            return;
                        case 277: //TORK-TID
                            items.Add(LanguageManager.GetString("dryingMaterial_1"));
                            break;
                        case 301: //HACK/DRAGARE
                            items = DigitalProductionProgram.Equipment.Equipment.List_Equipment_Protocol("HACK/DRAGARE");
                            break;
                        case 303: //TRANSPORTBAND/UPPTAGARE
                            items = DigitalProductionProgram.Equipment.Equipment.List_Equipment_Protocol("TRANSPORTBAND/UPPTAGARE");
                            break;
                        case 325: //RENGJORT CYLINDER
                            items = DigitalProductionProgram.Equipment.Equipment.List_CleanedCylinder(startup);
                            break;
                        case 304: //INTAG
                            items = DigitalProductionProgram.Equipment.Equipment.List_Intag.ToList();
                            break;
                        case 305: //SKRUVTYP
                            //Korprotokoll hämtar ID_Nummer
                            items = DigitalProductionProgram.Equipment.Equipment.List_Register(isProcesscardUnderManagement,NOM_Value(dgv_Row), "Register_Skruvar");
                            IsItemsMultipleColumns = true;
                            break;
                        case 306: //TORK
                            items = DigitalProductionProgram.Equipment.Equipment.List_Register(isProcesscardUnderManagement, NOM_Value(dgv_Row), "Register_Torkar");
                            IsItemsMultipleColumns = true;
                            break;
                        case 307: //HUVUD
                            items = DigitalProductionProgram.Equipment.Equipment.List_Register(isProcesscardUnderManagement, NOM_Value(dgv_Row), "Register_Huvud");
                            IsItemsMultipleColumns = true;
                            break;
                        case 308: //TORPED
                            items = DigitalProductionProgram.Equipment.Equipment.List_Register(isProcesscardUnderManagement, NOM_Value(dgv_Row), "Register_Torpeder");
                            IsItemsMultipleColumns = true;
                            break;
                        case 309: //TORPEDMUTTER
                            items = DigitalProductionProgram.Equipment.Equipment.List_Register(isProcesscardUnderManagement, NOM_Value(dgv_Row), "Register_Torpedmuttrar");
                            IsItemsMultipleColumns = true;
                            break;
                        case 310: //MUNSTYCKE TYP
                            items = DigitalProductionProgram.Equipment.Equipment.List_Tool_Type("Munstycke");
                            
                            break;
                        case 83: //MUNSTYCKE
                            cells = new[] { dgv_Module.Rows[e.RowIndex].Cells[col], dgv_Module.Rows[e.RowIndex + 1].Cells[col] };
                            if (Order.WorkOperation == Manage_WorkOperation.WorkOperations.Extrudering_FEP)
                                DieType = "Munstycken FEP";
                            items = DigitalProductionProgram.Equipment.Equipment.List_Tool(DieType, MIN_Value(dgv_Row), MAX_Value(dgv_Row));
                            IsItemsMultipleColumns = true;
                            break;
                        case 311: //KÄRNA TYP
                            items = DigitalProductionProgram.Equipment.Equipment.List_Tool_Type("Kanyl");
                            break;
                        case 209: //KÄRNA
                            cells = new[] {dgv_Module.Rows[e.RowIndex].Cells[col], dgv_Module.Rows[e.RowIndex + 1].Cells[col] };
                            if (Order.WorkOperation == Manage_WorkOperation.WorkOperations.Extrudering_FEP)
                                TipType = "Kanyler FEP";
                            items = DigitalProductionProgram.Equipment.Equipment.List_Tool(TipType, MIN_Value(dgv_Row), MAX_Value(dgv_Row));
                            IsItemsMultipleColumns = true;
                            break;
                        case 229:   //UPPTAGNING
                            items.Add("Leveransspole");
                            items.Add("Mellanspolning");
                            items.Add("Direkt Hackning");
                            break;
                        case 312: //SILPAKET
                            var choose_Silduk = new Choose_Silduk(dgv_Module.Rows[row].Cells[e.ColumnIndex]);
                            choose_Silduk.ShowDialog();
                            return;

                        case 314: //FILTERHUSTYP
                            items = Monitor.Monitor.List_Serialnumber_Extrusion_Filter(NOM_Value(dgv_Row));
                            break;
                        case 315: //FILTER ARTIKELNR
                            items = Monitor.Monitor.List_CandleFilter_PartNr("Candle");
                            break;
                        case 316: //KALIBRERINGSTYP

                            items = DigitalProductionProgram.Equipment.Equipment.List_Register(true, NOM_Value(dgv_Row), "Register_Kalibreringar"); 
                          //  IsItemsMultipleColumns = false;
                            break;
                        case 159:   //HS MASKIN
                            items = Machines.HS_Machines;
                            break;
                        case 75:    //RÖR ID# POS 1
                        case 160:   //RÖR ID# POS 2
                        case 161:   //RÖR ID# POS 3
                            items = Tools.List_HS_PipeID(isProcesscardUnderManagement);
                            break;
                        case 71:    //HACKHYLSA
                            items = Tools.List_HS_Hackhylsa;
                            break;
                        case 73:    //UPPTAGARE/HACK
                            items = Machines.HS_Upptagare;
                            break;
                        case 131:   //RAKBLADSTYP
                            items = Monitor.Monitor.List_RazorTypes;
                            break;
                        case 132:   //HACKRÖRSTYP
                            items.Add("Vanlig");
                            items.Add("PTFE");
                            items.Add("Vinkel");
                            break;
                        case 138:   //HJUL
                            items.Add("Stort");
                            items.Add("Litet");
                            break;
                        case 139:   //PÅSTYP
                            items.Add("Transparent PE");
                            items.Add("Svart PE");
                            items.Add("Spolpåse");
                            items.Add("Inserterrörspåse");
                            break;
                        case 333:   //SVÄNGT / BYTT RAKBLAD
                            items.Add("Svängt Rakblad");
                            items.Add("Nytt Rakblad");
                            break;
                        case 357:   //BRYTPLATTA
                            items.Add("Platt");
                            items.Add("Försänkt");
                            items.Add("Strypring");
                            break;
                    }
                }

                
                if (items is null)
                    return;
                if (items.Contains("N/A") == false)
                    items.Add("N/A");
                items.Add(LanguageManager.GetString("checkLastOperations"));
                if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ChooseFreelyFromListsProtocol, false))
                    isOkWriteText = true;
                var choose_Item = new Choose_Item(items, cells, dgv_Module.Rows[row].Cells[0].Value.ToString(), MachineIndex, startup, isOkWriteText, false, IsItemsMultipleColumns);
                choose_Item.ShowDialog();
            }
            if (IsOkToSave)
                SpecialItems(row, col, protocolDescriptionID, isProcesscardUnderManagement);
        }
        private void Module_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Module.ReadOnly && IsOkToSave)
            {
                if (LineClearance.LineClearance.IsLineClearanceDone == false)
                    InfoText.Show(LanguageManager.GetString("lineClearance_Info_2"), CustomColors.InfoText_Color.Bad, "Warning", this);
                else if (Person.IsUserSignedIn(true))
                    return;
                else
                    InfoText.Show(LanguageManager.GetString("otherUserIsLoggedIn"), CustomColors.InfoText_Color.Warning, "Warning", this);
            }
        }
        private void SpecialItems(int row, int col, int protocolDescriptionID, bool isProcesscardUnderManagement)
        {
            var cell = dgv_Module.Rows[row].Cells[col];
            if (cell.Value == null)
                return;
            switch (protocolDescriptionID)
            {
                case 75:
                    Order.HS_Pipe_1 = Tools.HS_Pipe(protocolDescriptionID);
                    break;
                case 160:
                    Order.HS_Pipe_2 = Tools.HS_Pipe(protocolDescriptionID);
                    break;
                case 161:
                    Order.HS_Pipe_3 = Tools.HS_Pipe(protocolDescriptionID);
                    break;
                case 83:
                case 209:
                    if (isProcesscardUnderManagement)
                        cell.Value = Regex.Replace(cell.Value.ToString(), "[^0-9,]", "");
                    break;
                case 310:
                    DieType = dgv_Module.Rows[row].Cells[col].Value.ToString();
                    break;
                case 311:
                    TipType = dgv_Module.Rows[row].Cells[col].Value.ToString();
                    break;
                case 325:   //RENGJORT CYLINDER
                    break;
                case 326:   //RENGJORT UTRUSTNING
                    break;
            }
        }



        //private void Korprotokoll_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (MainProtocol.Module_dataGridViews is null)
        //    {
        //        var dgv = (DataGridView)sender;
        //        MainProtocol.Module_dataGridViews = new List<DataGridView> { dgv };
        //    }
        //    var lastcolumn = dgv_Module.Columns["col_MAX"].Index;
        //    var activeColumn = dgv_Module.HitTest(e.X, e.Y);

        //    if (activeColumn.ColumnIndex > lastcolumn)
        //    {
        //        DrawingControl.SuspendDrawing(this);
        //        ((HandledMouseEventArgs)e).Handled = true;

        //        var columnsToScroll = e.Delta > 0 ? -30 : 30; // Adjust this value as needed
        //                                                      // DataGridView dgv = (DataGridView)sender;
        //        int columnWidth = 100;
        //        foreach (var dgv in MainProtocol.Module_dataGridViews)
        //        {
        //            if (dgv.Columns.Count > 0)
        //            {
        //                var currentOffset = dgv.HorizontalScrollingOffset;
        //                var newOffset = Math.Max(0, currentOffset + columnsToScroll * dgv.Columns[0].Width);
        //                dgv.HorizontalScrollingOffset = newOffset;
        //            }
        //        }
        //        DrawingControl.ResumeDrawing(this);
        //    }

        //}
        //private void Korprotokoll_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (MainProtocol.Module_dataGridViews is null)
        //    {
        //        var dgv = (DataGridView)sender;
        //        MainProtocol.Module_dataGridViews = new List<DataGridView> { dgv };
        //    }
        //    var lastcolumn = dgv_Module.Columns["col_MAX"].Index;
        //    var activeColumn = dgv_Module.HitTest(e.X, e.Y);

        //    if (activeColumn.ColumnIndex > lastcolumn)
        //    {
        //        // DrawingControl.SuspendDrawing(this);
        //        ((HandledMouseEventArgs)e).Handled = true;
        //        foreach (var dgv in MainProtocol.Module_dataGridViews)
        //        {
        //            try
        //            {
        //                int totalVisibleWidth = 0;
        //                int lastVisibleColumnIndex = dgv.FirstDisplayedScrollingColumnIndex;

        //                // Calculate the total width of the visible columns
        //                for (int i = dgv.FirstDisplayedScrollingColumnIndex; i < dgv.Columns.Count; i++)
        //                {
        //                    totalVisibleWidth += dgv.Columns[i].Width;
        //                    if (totalVisibleWidth > dgv.ClientSize.Width)
        //                    {
        //                        lastVisibleColumnIndex = i;
        //                        break;
        //                    }
        //                }

        //                // Adjust the scrolling
        //                if (e.Delta > 0)
        //                {
        //                    if (dgv.FirstDisplayedScrollingColumnIndex > 0)
        //                        dgv.FirstDisplayedScrollingColumnIndex--;
        //                }
        //                else
        //                {
        //                    if (lastVisibleColumnIndex < dgv.Columns.Count - 1)
        //                        dgv.FirstDisplayedScrollingColumnIndex++;
        //                }
        //            }
        //            catch (Exception exception)
        //            {
        //                // Handle the exception (optional)
        //            }
        //        }

        //        //  DrawingControl.ResumeDrawing(this);
        //    }

        //}

        public class DatabaseManagement
        {
            public static void Delete_StartUp(int startup)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    IF EXISTS (SELECT * FROM [Order].Data WHERE OrderID = @orderid AND Uppstart = @uppstart)
                        DELETE FROM [Order].Data 
                        WHERE OrderID = @orderid 
                            AND Uppstart = @uppstart";

                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@uppstart", startup);
                    cmd.ExecuteNonQuery();
                }
            }
            public static void Delete_Oven(int startup, int oven)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    IF EXISTS (SELECT * FROM [Order].Data WHERE OrderID = @orderid AND Uppstart = @uppstart AND Ugn = @oven)
                        DELETE FROM [Order].Data 
                        WHERE OrderID = @orderid 
                            AND Uppstart = @uppstart
                            AND Ugn = @oven";

                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@uppstart", startup);
                    cmd.Parameters.AddWithValue("@oven", oven);
                    cmd.ExecuteNonQuery();
                }
            }
            public static void Save_Data(DataGridView dgv, int row, int formtemplateid, int OvenIndex = 0, int machineindex = 0)
            {
                if (Module.IsOkToSave == false)
                    return;
                var cell = dgv.CurrentCell;

                var protocol_Description_ID = Protocol_Description.Protocol_Description_ID_Row(row, formtemplateid);
                _ = int.Parse(dgv.Rows[row].Cells["col_DataType"].Value.ToString());
                int type = ValueType(protocol_Description_ID, formtemplateid);

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = OvenIndex > 0 ? @"
                    IF NOT EXISTS (SELECT * FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid AND uppstart = @uppstart AND ugn = @ugn)
                        INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, MachineIndex, Uppstart, Ugn, Value, TextValue, BoolValue)
                        VALUES (@orderid, @protocoldescriptionid, @machineindex, @uppstart, @ugn, @value, @textvalue, @boolvalue)
                    ELSE
                        UPDATE [Order].Data 
                            SET value = @value, textvalue = @textvalue, BoolValue = @boolvalue
                        WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid AND uppstart = @uppstart AND ugn = @ugn" : @"
                    IF NOT EXISTS (SELECT * FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid AND (COALESCE(Uppstart, 0) = COALESCE(@uppstart, 0)) AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)))
                        INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, MachineIndex, Uppstart, Ugn, Value, TextValue, BoolValue, datevalue)
                        VALUES (@orderid, @protocoldescriptionid, @machineindex, @uppstart, @ugn, @value, @textvalue, @boolvalue, @datevalue)
                    ELSE
                        UPDATE [Order].Data 
                            SET value = @value, textvalue = @textvalue, BoolValue = @boolvalue, datevalue = @datevalue
                        WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid AND (COALESCE(Uppstart, 0) = COALESCE(@uppstart, 0)) AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0))";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", protocol_Description_ID);
                    SQL_Parameter.Int(cmd.Parameters, "@machineindex", machineindex);
                    cmd.Parameters.AddWithValue("@uppstart", Module.StartUp(dgv.Columns[cell.ColumnIndex].HeaderText)); //dgv.Columns[cell.ColumnIndex].HeaderText);
                    if (OvenIndex > 0)
                        cmd.Parameters.AddWithValue("@ugn", OvenIndex);
                    else
                        cmd.Parameters.AddWithValue("@ugn", DBNull.Value);

                    switch (type)
                    {
                        case 0://NumberValue
                            SQL_Parameter.Double(cmd.Parameters, "@value", cell.Value);
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                            break;
                        case 1://TextValue
                            if (cell.Value != null)
                                SQL_Parameter.String(cmd.Parameters, "@textvalue", cell.Value.ToString());
                            else
                                cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@value", DBNull.Value);
                            cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                            break;
                        case 2://BoolValue
                            SQL_Parameter.Boolean(cmd.Parameters, "@boolean", cell.Value);
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@value", DBNull.Value);
                            cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                            break;
                        case 3://DateValue
                            if (DateTime.TryParse(cell.Value.ToString(), out var dateValue))
                                cmd.Parameters.AddWithValue("@datevalue", dateValue);
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@value", DBNull.Value);
                            cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                            break;
                    }

                    cmd.ExecuteNonQuery();
                }
            }

            public static int ValueType(int? id, int FormTemplateID)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    SELECT Type FROM Protocol.Template
                    WHERE ProtocolDescriptionID = @descrid
                        AND FormTemplateID = @formtemplateid";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@descrid", id);
                    cmd.Parameters.AddWithValue("@formtemplateid", FormTemplateID);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    return int.Parse(value.ToString());
                }
            }
        }

        public static class SinteringOven
        {
            public static int Oven(string headertext)
            {
                const string pattern = @"\-Ugn# (\d+)";
                var match = Regex.Match(headertext, pattern);
                headertext = match.Groups[1].Value;
                int.TryParse(headertext, out var result);
                return result;
            }
            public static int TotalOvens(int startUp)
            {
                if (Order.OrderID is null)
                    return 0;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"
                    SELECT MAX(Ugn) FROM [Order].Data WHERE OrderID = @orderid AND Uppstart = @startup";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@startup", startUp);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                    {
                        if (int.TryParse(value.ToString(), out var result))
                            return result;
                    }

                }
                return 1;
            }
            public static bool IsOkAddOven(int startUp, int oven)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"
                    SELECT * FROM [Order].Data WHERE OrderID = @orderid AND Uppstart = @startup AND Ugn = @oven";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@startup", startUp);
                    cmd.Parameters.AddWithValue("@oven", oven);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                }

                return false;
            }

            public static void RemoveOven(Module module)
            {
                var startUp = StartUp(module.dgv_Module.Columns[module.dgv_Module.Columns.Count - 1].HeaderText);
                var oven = Oven(module.dgv_Module.Columns[module.dgv_Module.Columns.Count - 1].HeaderText);

                if (module.IsModuleUsedWithMultipleColumnsStartup)
                    for (int col = module.dgv_Module.Columns.Count - 1; col > module.ColIndex_StartUp1; col--)
                    {
                        if (Oven(module.dgv_Module.Columns[col].HeaderText) == oven && StartUp(module.dgv_Module.Columns[col].HeaderText) == startUp)
                            module.dgv_Module.Columns.RemoveAt(col);
                    }
            }
        }

        public class Equipment
        {
            public static bool IsEquipmentEmpty(DataGridView dgv)
            {
                return (from DataGridViewRow row in dgv.Rows select row.Cells[dgv.Columns.Count - 1].Value into cellValue where cellValue != null select cellValue).All(cellValue => string.IsNullOrEmpty(cellValue.ToString()));
            }
            private readonly Module module;

            public Equipment(Module parentModule)
            {
                module = parentModule;
            }

            public void Lock_Equipment(int col)
            {
                module.dgv_Module.Columns[col].ReadOnly = true;
            }
            public void ConfirmEquipment(DataGridView dgv)
            {
                var col = dgv.Columns.Count - 1;
                dgv.Rows[dgv.Rows.Count - 2].Cells[col].Selected = true;
                dgv.Rows[dgv.Rows.Count - 2].Cells[col].Value = DateTime.Now;

                dgv.Rows[dgv.Rows.Count - 1].Cells[col].Selected = true;
                dgv.Rows[dgv.Rows.Count - 1].Cells[col].Value = Person.Name;
                Lock_Equipment(col);
                _ = Activity.Stop("Operatör har bekräftat Utrustningen.");
                dgv.ClearSelection();
            }
            public void CheckIfEquipmentIsConfirmed(ref bool isQuestionAnswered, ref bool isOkCloseForm, bool isOkWarnUser)
            {
                var cell = module.dgv_Module.Rows[module.dgv_Module.Rows.Count - 1].Cells[module.dgv_Module.Columns.Count - 1];
                int.TryParse(cell.OwningColumn.HeaderText, out var StartUp);
                
                if (module.IsAuthenticationNeeded && (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString())) && IsEquipmentEmpty(module.dgv_Module) == false)
                {
                    if (isOkWarnUser == false)
                    {//Om av någon orsak utrustning har blivit sparad utan att operatör har bekräftat utrustningen så raderas den automatiskt nästa gång protokollet öppnas.
                        _ = Activity.Stop($"Senaste Uppstart för utrustning raderas pga att operatör {Person.Name} inte har bekräftat utrustningen. Användare har INTE fått meddelande om detta.");
                        Delete_LastStartup(StartUp, module.FormTemplateID, module.dgv_Module);
                        foreach (DataGridViewRow row in module.dgv_Module.Rows)
                            row.Cells[module.dgv_Module.Columns.Count - 1].Value = string.Empty;
                        return;
                    }
                    if (isQuestionAnswered == false)
                        InfoText.Question(LanguageManager.GetString("equipment_Info_1"), CustomColors.InfoText_Color.Warning, "Warning!", null);
                    if (InfoText.answer == InfoText.Answer.Yes)
                    {
                            _ = Activity.Stop($"Senaste Uppstart för utrustning raderas pga att operatör {Person.Name} inte har bekräftat utrustningen. Användare har fått meddelande om detta.");
                        Delete_LastStartup(StartUp, module.FormTemplateID, module.dgv_Module);
                        isQuestionAnswered = true;
                        isOkCloseForm = true;
                    }
                    else
                    {
                        isOkCloseForm = false;
                        isQuestionAnswered = false;
                    }
                }

                
            }
            public static void Delete_LastStartup(int startup, int formtemplateid, DataGridView dgv)
            {
                //Om Användare stänger ner Körprotokollet utan att ha fyllt i hela utrustningen så raderas utrustningen från senaste uppstart
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                            DELETE FROM [Order].Data
                            WHERE OrderID = @orderid
                                AND Uppstart = @startup
                                AND ProtocolDescriptionID IN (SELECT ProtocolDescriptionID FROM Protocol.Template WHERE FormTemplateID = @formtemplateid)";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@startup", startup);
                    // cmd.Parameters.AddWithValue("@machineindex", machine);
                    cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);

                    cmd.ExecuteNonQuery();
                }
            }
            public bool IsEquipmentOkToConfirm(DataGridView dgv, int machineIndex)
            {
                var col = dgv.Columns.Count - 1;
                for (var row = 0; row < dgv.Rows.Count - 2; row++)
                {
                    if (dgv.Rows[row].Visible == false)
                        continue;
                    var cell = dgv.Rows[row].Cells[col];
                    if (cell?.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        InfoText.Show($"{LanguageManager.GetString("equipment_Info_8")} #{machineIndex} {LanguageManager.GetString("equipment_Info_2")}", CustomColors.InfoText_Color.Warning, "Warning", dgv.Parent);
                        if (cell != null)
                            cell.Selected = true;
                        return false;
                    }
                }
                return true;
            }
        }

        public class Production
        {
            public static void AddDates(DataGridView dgv, int FormTemplateID)
            {
                IsOkToSave = true;

                var rowIndex_Start = 0;
                var rowIndex_Stop = 0;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        SELECT RowIndex FROM Protocol.Template WHERE FormTemplateID = @formtemplateID AND Type = 3 ORDER BY RowIndex";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@formtemplateid", FormTemplateID);
                    var reader = cmd.ExecuteReader();
                    var ctr = 0;
                    while (reader.Read())
                    {
                        int.TryParse(reader["RowIndex"].ToString(), out var rowIndex);
                        if (ctr == 0)
                            rowIndex_Start = rowIndex;
                        else
                            rowIndex_Stop = rowIndex;

                        ctr++;
                    }
                }

                var date = DateTime.Now;
                var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);

                var cellDate1 = dgv.Rows[rowIndex_Stop].Cells[dgv.Columns.Count - 2];

                cellDate1.Selected = true;
                if (cellDate1.Value is null || string.IsNullOrEmpty(cellDate1.Value.ToString()))
                    cellDate1.Value = formattedDate;

                dgv.Rows[rowIndex_Start].Cells[dgv.Columns.Count - 1].Selected = true;
                dgv.Rows[rowIndex_Start].Cells[dgv.Columns.Count - 1].Value = formattedDate;

                IsOkToSave = false;
            }
        }

        public class Extrusion
        {
            public static void Cleaned_Cylinder(DataGridView dgv_Protocol, int formtemplateid, int machineindex)
            {
                // IsOk_CellValueChanged = false;
                var value = dgv_Protocol.CurrentCell.Value.ToString();
                var startup = dgv_Protocol.Columns.Count;
                switch (value)
                {
                    case "Ja":
                    case "Yes":
                        Delete_Equipment(dgv_Protocol);
                        break;
                    case "Nej, samma material och utrustning som föreg. Order":
                    case "No, same material and equipment as last":
                    case "Nej, samma material som föreg. uppstart":
                    case "No, same material as last startup":
                    case "Nej, mjukt till hårt material":
                    case "No, soft to hard material":
                    case "Nej, ljus till mörk färg":
                    case "No, light to dark color":
                        if (startup == 1)
                            Copy_FromLastOrder(dgv_Protocol, formtemplateid, machineindex);
                        else
                            Copy_FromLastStartUp(dgv_Protocol);
                        break;
                    case "Nej":
                    case "No":
                        Copy_FromLastStartUp(dgv_Protocol);
                        break;
                }
                IsOk_CellValueChanged = true;
            }
            public static void Cleaned_Equipment(DataGridView dgv_Protocol, int formtemplateid)
            {
                var text = dgv_Protocol.CurrentCell.Value.ToString();
                var RowsToDelete = new List<int>();
                switch (text)
                {
                    case "Ja":
                    case "Yes":
                        using (var con = new SqlConnection(Database.cs_Protocol))
                        {
                            var query = @"
                                SELECT RowIndex
                                FROM Protocol.Template
                                WHERE FormTemplateID = @formtemplateid
                                AND ProtocolDescriptionID IN 
                                (
                                    SELECT ID
                                    FROM Protocol.Description
                                    WHERE CodeText IN ('Munstycke', 'KÄRNA', 'MUNSTYCKE - LANDLÄNGD', 'KÄRNA - LANDLÄNGD')
                                )";
                            con.Open();
                            var cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                            var reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (int.TryParse(reader["RowIndex"].ToString(), out var row))
                                    RowsToDelete.Add(row);
                            }
                        }

                        foreach (var row in RowsToDelete)
                            dgv_Protocol.Rows[row].Cells[dgv_Protocol.Columns.Count - 1].Value = string.Empty;
                        break;
                }
            }
            public static void Copy_FromLastStartUp(DataGridView dgv_Protocol)
            {
                for (var i = 2; i < dgv_Protocol.Rows.Count - 2; i++)
                {
                    if (!dgv_Protocol.Rows[i].Visible)
                        continue;
                    dgv_Protocol.Rows[i].Cells[dgv_Protocol.Columns.Count - 1].Selected = true;
                    dgv_Protocol.Rows[i].Cells[dgv_Protocol.Columns.Count - 1].Value = dgv_Protocol.Rows[i].Cells[dgv_Protocol.Columns.Count - 2].Value;

                }
            }
            public static void Copy_FromLastOrder(DataGridView dgv_Protocol, int formtemplateid, int machineindex)
            {
                var lastOrderID = Order.LastOrderID;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                                SELECT DISTINCT Value, TextValue, DateValue, MachineIndex, Uppstart, Ugn, RowIndex, template.Decimals, template.Type
                                FROM [Order].Data AS protocol
	                                JOIN Protocol.Template as template
		                                ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
	                                JOIN Protocol.Description as descr
		                                ON descr.id = template.ProtocolDescriptionID
                                WHERE OrderID = @orderid
                                    AND FormTemplateID = @formtemplateid
                                    AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0))
                                    AND RowIndex IS NOT NULL
                                    AND RowIndex > 1
                                    AND Uppstart = 1
                                ORDER BY RowIndex";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", lastOrderID);
                    cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                    cmd.Parameters.AddWithValue("@machineindex", machineindex);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int.TryParse(reader["type"].ToString(), out var type);
                        int.TryParse(reader["RowIndex"].ToString(), out var row);
                        if (row == dgv_Protocol.Rows.Count - 2)
                            return;
                        var value = string.Empty;
                        switch (type)
                        {
                            case 0: //NumberValue
                                int.TryParse(reader["Decimals"].ToString(), out var decimals);
                                if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                    value = string.Empty;
                                else
                                    value = Processcard.Format_Value(NumberValue, decimals);
                                break;
                            case 1: //TextValue
                                value = reader["TextValue"].ToString();
                                break;
                            case 2: //BoolValue
                                break;
                            case 3: //DateValue
                                if (DateTime.TryParse(reader["datevalue"].ToString(), out var date))
                                    value = date.ToString("yyyy-MM-dd HH:mm");
                                break;
                        }

                        if (string.IsNullOrEmpty(value))
                            value = "N/A";

                        var cell = dgv_Protocol.Rows[row].Cells[dgv_Protocol.Columns.Count - 1];
                        if (Browse_Protocols.Browse_Protocols.Is_BrowsingProtocols == false && cell.Visible)
                        {
                            cell.Selected = true;
                            cell.Value = value;
                        }
                    }
                }
            }
            public static void Delete_Equipment(DataGridView dgv_Protocol)
            {
                for (var i = 2; i < dgv_Protocol.Rows.Count - 1; i++)
                    dgv_Protocol.Rows[i].Cells[dgv_Protocol.Columns.Count - 1].Value = string.Empty;
            }
            public static void Load_DryingUnderExtrusion(DataGridView dgv_Protocol, int ExtruderIndex)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT DISTINCT BoolValue, Uppstart
                        FROM [Order].Data
                        WHERE OrderID = @orderid
                            AND ProtocolDescriptionID = 317
                            AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0))
                       ORDER BY uppstart";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@machineindex", ExtruderIndex);
                    var reader = cmd.ExecuteReader();
                    var col = 0;
                    while (reader.Read())
                    {
                        if (bool.TryParse(reader["BoolValue"].ToString(), out var IsTorkUK))
                        {
                            if (IsTorkUK)
                            {
                                dgv_Protocol.Rows[1].Cells[col].Value = LanguageManager.GetString("dryingMaterial_2");
                                dgv_Protocol.Rows[1].Cells[col].Style.BackColor = Color.DimGray;
                                dgv_Protocol.Rows[1].Cells[col].Style.ForeColor = Color.White;
                            }
                        }

                        col++;
                    }
                }
            }
            public static void Change_DryTimeUnderProduction(DataGridViewCell cell, DataGridView dgv_Protocol, int MachineIndex)
            {
                switch (cell.Value.ToString())
                {
                    case "Ange Tid":
                    case "Set Time":
                        cell.ReadOnly = false;
                        cell.Style.BackColor = Color.White;
                        cell.Style.ForeColor = Color.DarkSlateGray;
                        cell.Value = string.Empty;
                        //Korprotokoll.Save_Data("False", 317,  int.Parse(dgv_Protocol.Columns[cell.ColumnIndex].HeaderText), MachineIndex);
                        break;
                    case "Torkar material under körningen (UK)":
                    case "Drying material During Extrusion (DE)":
                        cell.Value = LanguageManager.GetString("dryingMaterial_2");
                        cell.Style.BackColor = Color.DimGray;
                        cell.Style.ForeColor = Color.White;
                        cell.ReadOnly = true;
                        //Korprotokoll.Save_Data("True", 317,  int.Parse(dgv_Protocol.Columns[cell.ColumnIndex].HeaderText), MachineIndex);
                        break;
                }
            }
        }

        public class HeatShrink
        {
            public static void Change_Color_MachineName(DataGridView dgv_Protocol)
            {
                var cell = dgv_Protocol.CurrentCell;
                if (cell.Value is null)
                    return;
                DigitalProductionProgram.Equipment.Equipment.HS_Machine = cell.Value.ToString();
                MachineColor.Set_HeatShrink_Color();

                cell.Style.BackColor = MachineColor.Theme_BackColor;
                cell.Style.ForeColor = MachineColor.Theme_ForeColor;
            }
        }

        
    }
}
