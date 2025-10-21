using System.Data;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.User;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using System.Globalization;
using System.Text.RegularExpressions;
using DigitalProductionProgram.Log;
using System.Diagnostics;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Templates;
using Microsoft.Data.SqlClient;



namespace DigitalProductionProgram.Measure
{
    internal class Measure_ControlManagement
    {
        public Wall wall;

        private Bitmap Img_1_Layer
        {
            get
            {
                var runout = $"{wall.Img_Nr_Wall1}-{wall.Img_Nr_Wall2}-{wall.Img_Nr_Wall3}-{wall.Img_Nr_Wall4}";

                var picture = "1";
                if (wall.IsBad)
                    picture = "3";
                if (wall.IsWarning)
                    picture = "2";
                if (wall.IsOk)
                    picture = "1";
                if (wall.IsNeutral)
                    picture = "Neutral";


                var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Cross_Section_Tube", "1_Layer");
                string imagePath;
                if (runout.Contains('0') || runout == "1-1-1-1")
                    imagePath = Path.Combine(basePath, $"{picture}.png");
                else
                {
                    basePath = Path.Combine(basePath, "RunOut");
                    imagePath = Path.Combine(basePath, $"{runout}.png");
                }

                try
                {
                    // Open a FileStream and load the Bitmap from it, ensuring it's closed properly
                    using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    return new Bitmap(stream);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error loading image: {ex.Message}");
                    return null; // Prevent crash
                }

            }
        }
        private Bitmap Img_2_Layer
        {
            get
            {
                var picture = string.Empty;
                if (wall.Layer1Is_Ok && wall.Layer2Is_Bad)
                    picture = "1-3";
                if (wall.Layer1Is_Ok && wall.Layer2Is_Warning)
                    picture = "1-2";
                if (wall.Layer1Is_Ok && wall.Layer2Is_Ok)
                    picture = "1-1";
                if (wall.Layer1Is_Warning && wall.Layer2Is_Bad)
                    picture = "2-3";
                if (wall.Layer1Is_Warning && wall.Layer2Is_Warning)
                    picture = "2-2";
                if (wall.Layer1Is_Warning && wall.Layer2Is_Ok)
                    picture = "2-1";
                if (wall.Layer1Is_Bad && wall.Layer2Is_Bad)
                    picture = "3-3";
                if (wall.Layer1Is_Bad && wall.Layer2Is_Warning)
                    picture = "3-2";
                if (wall.Layer1Is_Bad && wall.Layer2Is_Ok)
                    picture = "3-1";


                if (wall.IsBad)
                    picture = "3-3";
                if (wall.IsWarning)
                    picture = "2-2";

                if (wall.IsNeutral_2Layer)
                    picture = "Neutral";
                var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Cross_Section_Tube", "2_Layer");
                //basePath = Path.Combine(basePath, "RunOut");
                var image = Path.Combine(basePath, $"{picture}.png");
                return File.Exists(image) ? new Bitmap(image) : null;
            }
        }
        private Bitmap Img_3_Layer
        {
            get
            {
                var picture = string.Empty;
                if (wall.Layer1Is_Ok && wall.Layer2Is_Ok && wall.Layer3Is_Bad)
                    picture = "1-1-3";
                if (wall.Layer1Is_Ok && wall.Layer2Is_Ok && wall.Layer3Is_Warning)
                    picture = "1-1-2";
                if (wall.Layer1Is_Ok && wall.Layer2Is_Ok && wall.Layer3Is_Ok)
                    picture = "1-1-1";
                if (wall.Layer1Is_Ok && wall.Layer2Is_Warning && wall.Layer3Is_Bad)
                    picture = "1-2-3";
                if (wall.Layer1Is_Ok && wall.Layer2Is_Warning && wall.Layer3Is_Warning)
                    picture = "1-2-2";
                if (wall.Layer1Is_Ok && wall.Layer2Is_Warning && wall.Layer3Is_Ok)
                    picture = "1-2-1";
                if (wall.Layer1Is_Ok && wall.Layer2Is_Bad && wall.Layer3Is_Bad)
                    picture = "1-3-3";
                if (wall.Layer1Is_Ok && wall.Layer2Is_Bad && wall.Layer3Is_Warning)
                    picture = "1-3-2";
                if (wall.Layer1Is_Ok && wall.Layer2Is_Bad && wall.Layer3Is_Ok)
                    picture = "1-3-1";

                if (wall.Layer1Is_Warning && wall.Layer2Is_Ok && wall.Layer3Is_Bad)
                    picture = "2-1-3";
                if (wall.Layer1Is_Warning && wall.Layer2Is_Ok && wall.Layer3Is_Warning)
                    picture = "2-1-2";
                if (wall.Layer1Is_Warning && wall.Layer2Is_Ok && wall.Layer3Is_Ok)
                    picture = "2-1-1";
                if (wall.Layer1Is_Warning && wall.Layer2Is_Warning && wall.Layer3Is_Bad)
                    picture = "2-2-3";
                if (wall.Layer1Is_Warning && wall.Layer2Is_Warning && wall.Layer3Is_Warning)
                    picture = "2-2-2";
                if (wall.Layer1Is_Warning && wall.Layer2Is_Warning && wall.Layer3Is_Ok)
                    picture = "2-2-1";
                if (wall.Layer1Is_Warning && wall.Layer2Is_Bad && wall.Layer3Is_Bad)
                    picture = "2-3-3";
                if (wall.Layer1Is_Warning && wall.Layer2Is_Bad && wall.Layer3Is_Warning)
                    picture = "2-3-2";
                if (wall.Layer1Is_Warning && wall.Layer2Is_Bad && wall.Layer3Is_Ok)
                    picture = "2-3-1";

                if (wall.Layer1Is_Bad && wall.Layer2Is_Ok && wall.Layer3Is_Bad)
                    picture = "3-1-3";
                if (wall.Layer1Is_Bad && wall.Layer2Is_Ok && wall.Layer3Is_Warning)
                    picture = "3-1-2";
                if (wall.Layer1Is_Bad && wall.Layer2Is_Ok && wall.Layer3Is_Ok)
                    picture = "3-1-1";
                if (wall.Layer1Is_Bad && wall.Layer2Is_Warning && wall.Layer3Is_Bad)
                    picture = "3-2-3";
                if (wall.Layer1Is_Bad && wall.Layer2Is_Warning && wall.Layer3Is_Warning)
                    picture = "3-2-2";
                if (wall.Layer1Is_Bad && wall.Layer2Is_Warning && wall.Layer3Is_Ok)
                    picture = "3-2-1";
                if (wall.Layer1Is_Bad && wall.Layer2Is_Bad && wall.Layer3Is_Bad)
                    picture = "3-3-3";
                if (wall.Layer1Is_Bad && wall.Layer2Is_Bad && wall.Layer3Is_Warning)
                    picture = "3-3-2";
                if (wall.Layer1Is_Bad && wall.Layer2Is_Bad && wall.Layer3Is_Ok)
                    picture = "3-3-1";

                if (wall.IsBad)
                    picture = "3-3-3";
                if (wall.IsWarning)
                    picture = "2-2-2";

                if (wall.IsNeutral_3Layer)
                    picture = "Neutral";
                var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Cross_Section_Tube", "3_Layer");
                basePath = Path.Combine(basePath, "RunOut");
                var image = Path.Combine(basePath, $"{picture}.png");
                return File.Exists(image) ? new Bitmap(image) : null;
            }
        }
        public static double? GetValue(Measurement_Protocol mp, string CodeName)
        {
            var ctrl = InputControl(mp.flp_InputControls, new[] { CodeName });
            if (ctrl is null)
                return null;
            if (double.TryParse(ctrl.Text, out var value))
                return value;
            return null;
        }


        public interface IMandatoryControl
        {
            bool IsMandatory { get; set; }
        }
        public class HeaderLabel : Label
        {
            private readonly ToolTip toolTip;
            private bool isMandatory;

            public bool IsMandatory
            {
                get => isMandatory;
                set
                {
                    isMandatory = value;
                    UpdateToolTip();
                }
            }
            public int ColumnIndex { get; set; }

            public HeaderLabel()
            {
                toolTip = new ToolTip();
            }
            private void UpdateToolTip()
            {
                toolTip.SetToolTip(this, IsMandatory ? "Detta fält måste fyllas i." : "Detta fält behöver inte fyllas i.");
            }
        }
        public class InputCheckBox : CheckBox, IMandatoryControl
        {
            public int ColumnIndex { get; set; }
            public int DataType { get; set; }
            public int DescriptionID { get; set; }
            public bool IsMandatory { get; set; }
        }
        public class InputNumericUpDown : NumericUpDown, IMandatoryControl
        {
            public int ColumnIndex { get; set; }
            public int DescriptionID { get; set; }
            public int DataType { get; set; }
            public string? Monitor_Name { get; set; }
            public new int Increment { get; set; }
            public bool IsMandatory { get; set; }
            public bool IsOkEdit { get; set; }
        }
        public class InputTextBox : TextBox, IMandatoryControl
        {
            public int ColumnIndex { get; set; }
            public int DescriptionID { get; set; }
            public string? Formula { get; set; }
            public int DataType { get; set; }
            public string? Monitor_Name { get; set; }
            public bool IsMandatory { get; set; }
            public bool IsOkEdit { get; set; }

            public double? USL { get; set; }
            public double? UCL { get; set; }
            public double? NOM { get; set; }
            public double? LSL { get; set; }
            public double? LCL { get; set; }
        }

        //private static NumericUpDown NumBag(Measurement_Protocol mp)
        //{
        //    return (from Control ctrl in mp.flp_InputControls.Controls where ctrl is NumericUpDown && ctrl.Name == "Bag" select (NumericUpDown)ctrl).FirstOrDefault();
        //}
       
        //private static int LastOkNumbag(Measurement_Protocol mp, ref int row)
        //{
        //    bool IsDiscarded;
        //    do
        //    {
        //        if (row < 0)
        //            return 0;
        //        bool.TryParse(mp.dgv_Measurements.Rows[row].Cells["Discarded"].Value.ToString(), out IsDiscarded);
        //        if (IsDiscarded)
        //            row--;
        //    } while (IsDiscarded);

        //    int.TryParse(mp.dgv_Measurements.Rows[row].Cells["Bag"].Value.ToString(), out var bag);
        //    return bag;
        //}

        public static Control? InputControl(FlowLayoutPanel flp, string[] CodeName)
        {
            foreach (var code in CodeName)
            {
                foreach (Control ctrl in flp.Controls)
                {
                    if (ctrl is InputTextBox tb && tb.Monitor_Name == code)
                        return tb;

                    if (ctrl is InputNumericUpDown nu && nu.Monitor_Name == code)
                        return nu;
                }
            }

            return null;
        }
        public void Clear_InputControls(Measurement_Protocol mp)
        {
            Formula.Is_ClearingData = true;
            foreach (Control ctrl in mp.flp_InputControls.Controls)
            {
                switch (ctrl)
                {
                    case CheckBox chb:
                        chb.Checked = false;
                        break;
                    case TextBox tb:
                        tb.Text = string.Empty;
                        break;
                }
            }
            Formula.Is_ClearingData = false;
        }
        public void ClearYellowBoxes(Measurement_Protocol mp)
        {
            DataGridView[] dgvs = { mp.dgv_HelpInput_1, mp.dgv_HelpInput_2, mp.dgv_Walls, mp.dgv_RecWalls };

            foreach (var dgv in dgvs)
            foreach (DataGridViewRow row in dgv.Rows)
                row.Cells[1].Value = string.Empty;

            Task.Factory.StartNew(() => Draw_CrossSectionTube(mp));
        }
        public void Change_GUI_Template(Measurement_Protocol mp)
        {
            bool isUsingSecondHelpInput = false;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT
                        Name,
                        IsAmountEditable,
                        IsBagEditable,
                        IsExtraInputBoxesEnabled, 
                        IsExtraInputBoxes_2Layer,
                        IsExtraInputBoxes_SecondMeasurement,
                        IsExtraFieldForCutterEnabled
                    FROM MeasureProtocol.MainTemplate
                    WHERE MeasureProtocolMainTemplateID = @maintemplateid";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();


                cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mp.Text += $" - {reader["Name"]}";
                    if (bool.TryParse(reader["IsAmountEditable"].ToString(), out var isVisible))
                        mp.btn_EditAmount.Visible = isVisible;
                    if (bool.TryParse(reader["IsBagEditable"].ToString(), out isVisible))
                        mp.btn_EditBag.Visible = isVisible;

                    if (bool.TryParse(reader["IsExtraInputBoxesEnabled"].ToString(), out isVisible))
                    {
                        mp.pb_CrossSectionTube.Visible = isVisible;
                        mp.tlp_Help_InputData_1.Visible = isVisible;
                    }
                    if (bool.TryParse(reader["IsExtraInputBoxes_SecondMeasurement"].ToString(), out isUsingSecondHelpInput))
                    {
                        mp.tlp_Help_InputData_2.Visible = isUsingSecondHelpInput;
                    }
                    if (bool.TryParse(reader["IsExtraFieldForCutterEnabled"].ToString(), out isVisible))
                    {
                        mp.tlp_Mätdon.RowStyles[0].Height = isVisible ? 22 : 0;
                        mp.label_HackNr.Visible = isVisible;
                        mp.tb_Hack.Visible = isVisible;
                    }
                }
            }
            Add_GUI_HelpInput_Controls(mp, isUsingSecondHelpInput);

            return;

            switch (Templates_MeasureProtocol.MainTemplate.ID)
            {
                case 1:     //Hackning PUR IV
                case 9:     //Hackning TEF
                    mp.pb_CrossSectionTube.Visible = false;
                    mp.tlp_Help_InputData_1.Visible = false;
                    break;

                case 4:     //Extrudering TEF 2 Layer
                    mp.tlp_Help_InputData_1.ColumnStyles[2].Width = 0;
                    mp.tlp_Help_InputData_1.Width = 180;
                    mp.panel_Bottom.Height = 250;
                    break;

                case 10:    //Extrudering PTFE
                case 11:    //Extrudering Grov PTFE
                case 18:
                    mp.tlp_Help_InputData_1.ColumnStyles[2].Width = 0;
                    mp.tlp_Help_InputData_1.Width = 170;
                    mp.btn_EditAmount.Visible = false;
                    if (Order.Enhet != "st")
                        // headerText = " PTFE Sintring";
                        // else
                        //  headerText = " Hackning, Boston";
                        break;
                case 12:    //Synergy PTFE
                    mp.pb_CrossSectionTube.Visible = false;
                    mp.tlp_Help_InputData_1.Visible = false;
                    mp.btn_EditAmount.Visible = false;
                    mp.btn_EditBag.Visible = true;
                    //headerText = " Synergy PTFE";
                    break;
                case 13:    //Kragning PTFE
                case 15:    //Kragning K22 PTFE
                    mp.tlp_Mätdon.RowStyles[0].Height = 0;
                    mp.pb_CrossSectionTube.Visible = false;
                    mp.tlp_Help_InputData_1.Visible = false;
                    mp.btn_EditBag.Visible = true;
                    break;
                case 14:    //Spolning PTFE
                    mp.tlp_Mätdon.RowStyles[0].Height = 0;
                    break;
                case 16:    //Hackning PTFE
                    mp.tlp_Mätdon.RowStyles[0].Height = 0;
                    break;
                case 17:    //Bump PTFE
                    mp.btn_EditAmount.Visible = false;
                    mp.pb_CrossSectionTube.Visible = false;
                    mp.tlp_Help_InputData_1.Visible = false;
                    mp.tlp_Mätdon.RowStyles[0].Height = 0;
                    break;
                case 19:    //Slitting PTFE
                    mp.btn_EditAmount.Visible = false;
                    mp.pb_CrossSectionTube.Visible = false;
                    mp.tlp_Help_InputData_1.Visible = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


        }
        private static void Add_Row_DatagridView(DataGridView dgv, string text)
        {
            dgv.Rows.Add();
            //dgv.Rows[dgv.Rows.Count - 1].HeaderCell.Value = text;
            dgv.Rows[dgv.Rows.Count - 1].Cells[0].Value = text;

        }
        private void Add_GUI_HelpInput_Controls(Measurement_Protocol mp, bool isUsingSecondHelpInput)
        {
            if (Order.NumberOfLayers < 2)
            {
                for (var x = 1; x < 4; x++)
                    Add_Row_DatagridView(mp.dgv_HelpInput_1, $"x{x}");
                for (var y = 1; y < 4; y++)
                    Add_Row_DatagridView(mp.dgv_HelpInput_1, $"y{y}");
                for (var w = 1; w < 5; w++)
                    Add_Row_DatagridView(mp.dgv_Walls, $"Wall{w}");
            }
            else
            {
                mp.panel_Bottom.Height = 250;
                for (var x = 1; x < 6; x++)
                    Add_Row_DatagridView(mp.dgv_HelpInput_1, $"x{x}");
                for (var y = 1; y < 6; y++)
                    Add_Row_DatagridView(mp.dgv_HelpInput_1, $"y{y}");
                for (var L1w = 1; L1w < 5; L1w++)
                    Add_Row_DatagridView(mp.dgv_Walls, $"L1-w{L1w}:");
                for (var L2w = 1; L2w < 5; L2w++)
                    Add_Row_DatagridView(mp.dgv_Walls, $"L2-w{L2w}:");
            }

            if (isUsingSecondHelpInput)
            {
                for (var x = 1; x < 4; x++)
                    Add_Row_DatagridView(mp.dgv_HelpInput_2, $"x{x}");
                for (var y = 1; y < 4; y++)
                    Add_Row_DatagridView(mp.dgv_HelpInput_2, $"y{y}");
                for (var w = 1; w < 5; w++)
                    Add_Row_DatagridView(mp.dgv_RecWalls, $"RecWall{w}");

            }
          
            Task.Factory.StartNew(() => Draw_CrossSectionTube(mp));
        }
        public static void SafeInvoke(Control control, Action action)
        {
            if (control.IsHandleCreated)
            {
                if (control.InvokeRequired)
                    control.Invoke(action);
                else
                    action();
            }
        }


        public void Draw_CrossSectionTube(Measurement_Protocol mp)
        {
            Bitmap bmp = null;
            wall.MainWall = GetValue(mp, "Wall");
            wall.MainRunOut = GetValue(mp, "Runout");
            wall.Wall_Layer1 = GetValue(mp, "Wall Layer 1");
            wall.Wall_Layer2 = GetValue(mp, "Wall Layer 2");
            wall.Wall_Layer3 = GetValue(mp, "Wall Layer 3");
            wall.RunOut_Layer1 = GetValue(mp, "Runout Layer 1");
            wall.RunOut_Layer2 = GetValue(mp, "Runout Layer 2");
            wall.RunOut_Layer3 = GetValue(mp, "Runout Layer 3");

            switch (Order.NumberOfLayers)
            {
                case 0:
                case 1:
                    bmp = Img_1_Layer;
                    break;
                case 2:
                    bmp = Img_2_Layer;
                    break;
                case 3:
                    bmp = Img_3_Layer;
                    break;
            }

            try
            {
                SafeInvoke(mp.pb_CrossSectionTube, () => mp.pb_CrossSectionTube.BackgroundImage = bmp);
            }
            catch (Exception ex)
            {
                Log.Activity.LoadMemory();
                _ = Log.Activity.Stop($"Fail: CurrentMemory = {Log.Activity.CurrentMemory / 1000000} - PeakMemory = {Log.Activity.PeakMemory / 1000000} - DrawCross_Section: - {ex}");
            }
        }
        private static void ShowSpecialItems(object sender, EventArgs e)
        {
            if (MeasureInformation.IsOpening)
                return;
            var tb = (InputTextBox)sender;
            var codename = tb.Monitor_Name;
            var items = new List<string?> { "N/A" };

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT
                        Item
                    FROM MeasureProtocol.ItemsList
                    WHERE MeasureProtocolMainTemplateID = @maintemplateid
                    AND DescriptionID = @descriptionid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                cmd.Parameters.AddWithValue("@descriptionid", tb.DescriptionID);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    items.Add(reader["Item"].ToString());
            }

            switch (codename)
            {
                case "PreFab":
                    if (PreFab.DataTable_PreFab(Order.OrderID).Rows.Count <= 0)
                        return;
                    items = Monitor.Monitor.PreFab_BatchNr(PreFab.DataTable_PreFab(Order.OrderID).Rows[0][LanguageManager.GetString("label_PartNumber")].ToString());
                    break;
                case "BatchNr_Skärmad":
                    var partNr = string.Empty;
                    foreach (DataRow row in PreFab.DataTable_PreFab(Order.OrderID).Rows)
                    {
                        if (row["Slang:"].ToString()== "Skärmad")
                        {
                            partNr = row[$"{LanguageManager.GetString("label_PartNumber")}"].ToString();
                            break;
                        }
                    }
                    items = Monitor.Monitor.PreFab_BatchNr(partNr);
                    break;

            }


            if (items is null || items.Count <= 0)
                return;
            using var chooseItem = new Choose_Item(items, new Control[] { tb }, false, true);
            chooseItem.ShowDialog();
        }
        private static void Validate_Value_TextChanged(object? sender, EventArgs e)
        {
            var ctrl = (Control)sender;

            if (double.TryParse(ctrl.Text, out var value) == false)
            {
                ctrl.BackColor = Color.White;
                ctrl.ForeColor = Color.Black;
                return;
            }
            MeasurementValidator.DataVerification_Value(value, ctrl);
        }

       
        public static void Set_NumericUpDown_Values(Measurement_Protocol mp)
        {
            foreach (var numeric in mp.flp_InputControls.Controls.OfType<InputNumericUpDown>())
            {
                var colIndex = numeric.ColumnIndex;
                var increment = numeric.Increment;

                var maxValue = mp.dgv_Measurements.Rows.Cast<DataGridViewRow>()
                    .Where(row => row.Cells[colIndex].Value != null)
                    .Select(row => Convert.ToInt32(row.Cells[colIndex].Value))
                    .DefaultIfEmpty(0)  // Prevents "Sequence contains no elements"
                    .Max();

                if (Part.IsPartNrSpecial)
                {
                    if (Is4LastMeasuresSameSpool)
                        numeric.Value = maxValue + 1;
                    else
                    {
                        if (maxValue > 0)
                            numeric.Value = maxValue;
                    }
                }
                else
                {
                    if (increment > 0)
                        numeric.Value = maxValue + increment;
                    else if (maxValue > 0)
                        numeric.Value = maxValue;
                }
            }
        }
        
        private static bool Is4LastMeasuresSameSpool
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT COUNT(*) AS Count
                    FROM MeasureProtocol.Data 
                    WHERE OrderID = @orderid
                        AND DescriptionID = (SELECT ID FROM MeasureProtocol.Description WHERE CodeName = 'Bag')
                        AND Value = (SELECT MAX(Value) FROM MeasureProtocol.Data WHERE DescriptionID = (SELECT ID FROM MeasureProtocol.Description WHERE CodeName = 'Bag')
                        AND OrderID = @orderid)";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    con.Open();
                    var count = (int)cmd.ExecuteScalar();
                    if (count == 4)
                        return true;
                }

                return false;
            }
        }

        internal class AddControls
        {
            public static void Load_InputControls(Measurement_Protocol mp)
            {
                var TotalWidth = 0;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                SELECT 
                    DescriptionID,
                    Parameter_UserText, 
                    Parameter_Monitor,
                    IsList,
                    IsMandatory,
                    IsOkEdit,
                    Formula,
                    DataType, 
                    ControlType,
                    ColumnIndex,
                    Increment,
                    ColumnWidth, 
                    Decimals,
                    MaxChars
                FROM MeasureProtocol.Template as template
                    JOIN MeasureProtocol.Description as description
                        ON template.DescriptionID = description.Id 
                    JOIN MeasureProtocol.MainTemplate as maintemplate
                        ON template.MeasureProtocolMainTemplateID = maintemplate.MeasureProtocolMainTemplateID
                WHERE template.MeasureProtocolMainTemplateID = @maintemplateid 
                ORDER BY ColumnIndex";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows == false)
                    {
                        InfoText.Show(LanguageManager.GetString("measureprotocol_Info_1"), CustomColors.InfoText_Color.Bad, "Warning!", mp);
                        mp.Close();
                        return;
                    }

                    var columnIndex = 0;
                    while (reader.Read())
                    {
                        var formula = reader["Formula"].ToString();

                        bool.TryParse(reader["IsList"].ToString(), out var isList);
                        bool.TryParse(reader["IsMandatory"].ToString(), out var isMandatory);
                        bool.TryParse(reader["IsOkEdit"].ToString(), out var isOkEdit);
                        int.TryParse(reader["DescriptionID"].ToString(), out var descriptionID);
                        int.TryParse(reader["ColumnIndex"].ToString(), out columnIndex);
                        int.TryParse(reader["Increment"].ToString(), out var increment);
                        int.TryParse(reader["ColumnWidth"].ToString(), out var width);
                        int.TryParse(reader["Decimals"].ToString(), out var decimals);
                        int.TryParse(reader["MaxChars"].ToString(), out var maxChars);
                        var userText = reader["Parameter_UserText"].ToString();
                        var name = reader["Parameter_Monitor"].ToString();
                        var controlType = reader["ControlType"].ToString();
                        int.TryParse(reader["DataType"].ToString(), out var dataType);
                        var columnName = string.IsNullOrEmpty(name) ? userText : name;
                        var dataTypeName = Database.datatype.FirstOrDefault(d => d.ID == dataType)?.Name ?? "Unknown";

                        Add_Column_DatagridView(mp.dgv_Measurements, columnName, userText, columnIndex, width);

                        Add_Header(mp.flp_Headers, reader["Parameter_UserText"].ToString(), isMandatory, columnIndex, width);

                        switch (controlType)
                        {
                            case "NumericUpDown":
                                Add_Input_NumUpDown(mp.flp_InputControls, dataType, columnIndex, increment, width, descriptionID, name, isMandatory,  isOkEdit);
                                break;
                            case "TextBox":
                                switch (dataTypeName)
                                {
                                    case "Numeric":
                                        Add_Input_Numeric(mp, mp.flp_InputControls, dataType, columnIndex, width, descriptionID, maxChars, decimals, formula, name,  isMandatory, isOkEdit);
                                        break;
                                    case "Text":
                                        Add_Input_Text(mp.flp_InputControls, dataType, columnIndex, width, descriptionID, name, isList, isMandatory, isOkEdit);
                                        break;
                                }
                                break;
                            case "CheckBox":
                                Add_Input_CheckBox(mp.flp_InputControls, dataType, columnIndex, width, descriptionID, name, isMandatory);
                                break;
                        }
                        TotalWidth += width + 1;
                    }

                    Add_Header(mp.flp_Headers, LanguageManager.GetString("empNr"), true, columnIndex + 3, 50);
                    Add_Label(mp.flp_InputControls, Person.EmployeeNr, columnIndex + 3, 50);

                    Add_Header(mp.flp_Headers, "Sign", true, columnIndex + 4, 40);
                    Add_Label(mp.flp_InputControls, Person.Sign, columnIndex + 4, 40);

                    Add_Column_DatagridView(mp.dgv_Measurements, "Date", LanguageManager.GetString("dateTime"), columnIndex + 1, 160);
                    TotalWidth += 161;
                    Add_Column_DatagridView(mp.dgv_Measurements, "ErrorCode", LanguageManager.GetString("errorCode"), columnIndex + 2, 55);
                    TotalWidth += 55;
                    Add_Column_DatagridView(mp.dgv_Measurements, "AnstNr", LanguageManager.GetString("empNr"), columnIndex + 3, 70);
                    TotalWidth += 70;
                    Add_Column_DatagridView(mp.dgv_Measurements, "Sign", "Sign", columnIndex + 4, 50);
                    TotalWidth += 51;
                    Add_Column_DatagridView(mp.dgv_Measurements, "Discarded", "Discarded", columnIndex + 5, 0);
                    Add_Column_DatagridView(mp.dgv_Measurements, "TempID", "TempID", columnIndex + 6, 0);
                }
                //22pixlar är extra space som behövs till Scrollbar
                mp.Width = TotalWidth + 22;
                mp.pb_CrossSectionTube.Left = mp.tlp_Help_InputData_1.Right;
            }

            private static void Add_Column_DatagridView(DataGridView dgv, string name, string? headerText, int columnIndex, int width)
            {
                dgv.Columns.Add(name, headerText);
                dgv.Columns[name].Tag = columnIndex;
                dgv.Columns[name].Width = width;
                dgv.Columns[name].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (width == 0)
                    dgv.Columns[name].Visible = false;
            }

            public static void Add_Header(Control flp_Headers, string? text, bool isMandatory, int columnIndex, int width)
            {
                var lbl_Header = new HeaderLabel
                {
                    Text = text,
                    ColumnIndex = columnIndex,
                    IsMandatory = isMandatory,
                    BackColor = Color.Gainsboro,
                    Margin = new Padding(1, 1, 0, 0),
                    Font = new Font("Century", 7),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Width = width,
                    Height = flp_Headers.Height
                };

                lbl_Header.BackColor = isMandatory ? Color.Gainsboro : Color.DarkSeaGreen;

                flp_Headers.Controls.Add(lbl_Header);
            }
            public static void Add_Label(Control flp_InputControls, string text, int columnIndex, int width)
            {
                var lbl_Header = new Label
                {
                    Text = text,
                    Tag = columnIndex,
                    BackColor = Color.WhiteSmoke,
                    Margin = new Padding(1, 1, 0, 0),
                    Font = new Font("Courier New", 10),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Width = width,
                    Height = 22
                };
                flp_InputControls.Controls.Add(lbl_Header);
            }

            public static void Add_Input_NumUpDown(FlowLayoutPanel flp_InputControls, int dataType, int columnIndex, int increment, int width, int descriptionID, string monitorName, bool isMandatory,  bool isOkEdit)
            {
                var num = new InputNumericUpDown
                {
                    ColumnIndex = columnIndex,
                    DataType = dataType,
                    DescriptionID = descriptionID,
                    Font = new Font("Courier New", 11),
                    Increment = increment,
                    IsMandatory = isMandatory,
                    IsOkEdit = isOkEdit,
                    InterceptArrowKeys = true,
                    Margin = new Padding(1, 0, 0, 0),
                    Monitor_Name = monitorName,
                    Maximum = 100000,
                    Minimum = 1,
                    Name = monitorName,
                    Value = 1,
                    Width = width,

                };
                num.ValueChanged += Validate_Value_TextChanged;
                flp_InputControls.Controls.Add(num);
            }
            public static void Add_Input_CheckBox(FlowLayoutPanel flp_InputControls, int dataType, int columnIndex, int width, int descriptionID, string name, bool isMandatory)
            {
                var checkBox = new Measure_ControlManagement.InputCheckBox()
                {
                    BackColor = Color.White,
                    CheckAlign = ContentAlignment.MiddleLeft,
                    ColumnIndex = columnIndex,
                    DataType = dataType,
                    DescriptionID = descriptionID,
                    Font = new Font("Courier New", 10),
                    IsMandatory = isMandatory,
                    Margin = new Padding(1, 1, 0, 0),
                    Padding = new Padding(18, 0, 0, 0),
                    Width = width,
                    AutoSize = false,
                    Height = 22,
                    Name = name
                };
                flp_InputControls.Controls.Add(checkBox);
            }
            public static void Add_Input_Numeric(Measurement_Protocol mp, FlowLayoutPanel flp_InputControls, int dataType, int columnIndex, int width, int descriptionID, int maxChars, int Decimals, string formula, string? monitorName, bool isMandatory, bool isOkEdit)
            {
                var tb = new InputTextBox
                {
                    BorderStyle = BorderStyle.None,
                    ColumnIndex = columnIndex,
                    DataType = dataType,
                    DescriptionID = descriptionID,
                    Font = new Font("Courier New", 10),
                    Formula = formula,
                    Height = 22,
                    IsMandatory = isMandatory,
                    IsOkEdit = isOkEdit,
                    Margin = new Padding(1, 1, 0, 0),
                    MaxLength = maxChars,
                    Multiline = true,
                    Monitor_Name = monitorName,
                    Name = monitorName,
                    ShortcutsEnabled = false,
                    Width = width,
                    USL = MeasurePoints.Tolerances.ActiveTolerance(monitorName, "USL"),
                    UCL = MeasurePoints.Tolerances.ActiveTolerance(monitorName, "UCL"),
                    NOM = MeasurePoints.Tolerances.ActiveTolerance(monitorName, "NOM"),
                    LSL = MeasurePoints.Tolerances.ActiveTolerance(monitorName, "LSL"),
                    LCL = MeasurePoints.Tolerances.ActiveTolerance(monitorName, "LCL")
                };
                tb.KeyPress += Public_Events.Only_Decimal_KeyPress;
                tb.MouseDoubleClick += Public_Events.Control_MouseDoubleClick;
                switch (monitorName)
                {
                    case "Exp ID":
                        tb.MouseDown += mp.Exp_ID_MouseUp;
                        break;
                    case "Exp OD":
                        tb.MouseDown += mp.Exp_OD_MouseUp;
                        break;
                    case "Exp Wall":
                        tb.MouseDown += mp.Exp_Wall_MouseUp;
                        break;
                    case "Rec ID":
                        tb.MouseDown += mp.Rec_ID_MouseUp;
                        break;
                    case "Rec OD":
                        tb.MouseDown += mp.Rec_OD_MouseUp;
                        break;
                    case "Rec Wall":
                        tb.MouseDown += mp.Rec_Wall_MouseUp;
                        break;
                }
                tb.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
                //if (IsFormula)
                tb.TextChanged += (_, e) => Formula.CalculateFormula(flp_InputControls, Decimals, new[] { mp.dgv_Walls, mp.dgv_RecWalls });
                tb.TextChanged += Validate_Value_TextChanged;
                flp_InputControls.Controls.Add(tb);
            }
            public static void Add_Input_Text(Control flp_InputControls, int dataType, int columnIndex, int width, int descriptionID, string monitorName, bool isList, bool isMandatory, bool isOkEdit)
            {
                var tb = new InputTextBox
                {
                    BorderStyle = BorderStyle.None,
                    ColumnIndex = columnIndex,
                    DataType = dataType,
                    DescriptionID = descriptionID,
                    Font = new Font("Courier New", 10),
                    Height = 22,
                    IsMandatory = isMandatory,
                    IsOkEdit = isOkEdit,
                    Margin = new Padding(1, 1, 0, 0),
                    Monitor_Name = monitorName,
                    Multiline = true,
                    Name = monitorName,
                    Width = width,
                    ShortcutsEnabled = false,

                };
                tb.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
                tb.MouseDoubleClick += Public_Events.Control_MouseDoubleClick;
                if (isList)
                {
                    tb.Enter += ShowSpecialItems;
                    tb.Click += ShowSpecialItems;
                }

                flp_InputControls.Controls.Add(tb);
            }
        }
        internal static class Formula
        {
            public static bool Is_ClearingData;
            private static Dictionary<string, object> Parameters(string formula, FlowLayoutPanel flp, DataGridView[] dgvs)
            {
                var parameters = new Dictionary<string, object>();
                var matches = Regex.Matches(formula, @"\b[A-Za-z_][A-Za-z0-9_]*\b");

                // Fetch values from textboxes
                foreach (Match match in matches)
                {
                    var paramName = match.Value;
                    var textBox = flp.Controls.OfType<Measure_ControlManagement.InputTextBox>().FirstOrDefault(tb => tb.Monitor_Name == paramName);

                    if (textBox != null && double.TryParse(textBox.Text, out var value))
                    {

                        if (value > 0)
                            parameters[paramName] = value;
                    }
                }

                // Fetch values from DataGridView
                foreach (Match match in matches)
                {
                    var paramName = match.Value;
                    foreach (var dgv in dgvs)
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (paramName == row.Cells[0].Value?.ToString() && row.Cells[1].Value != null && !string.IsNullOrEmpty(row.Cells[1].Value?.ToString()))
                            {
                                if (double.TryParse(row.Cells[1].Value?.ToString(), out var value))
                                {
                                    parameters[paramName] = value;
                                }
                            }

                        }
                    }
                }
                return parameters;
            }
            public static void CalculateFormula(FlowLayoutPanel flp, int decimals, DataGridView[] dgv_Walls)
            {
                if (Is_ClearingData)
                    return;
                foreach (var input_tb in flp.Controls.OfType<InputTextBox>())
                {
                    var formula = input_tb.Formula?.Trim();

                    if (string.IsNullOrWhiteSpace(formula))
                        continue;

                    // Remove leading '=' if present
                    formula = Regex.Replace(formula, @"^=+", "");

                    // Extract variable names from formula
                    var parameters = Parameters(formula, flp, dgv_Walls);
                    if (parameters.Count == 0)
                        return;
                    // Evaluate formula using NCalc
                    try
                    {
                        var expression = new NCalc.Expression(formula);
                        foreach (var param in parameters)
                        {
                            expression.Parameters[param.Key] = param.Value;
                        }

                        var result = expression.Evaluate();

                        input_tb.Text = double.TryParse(result.ToString(), out var numericResult)
                            ? Math.Round(numericResult, decimals).ToString(CultureInfo.CurrentCulture)
                            : "N/A";
                    }
                    catch (Exception)
                    {
                        //input_tb.Text = "NaN";
                    }
                }
            }
        }
    }
}
