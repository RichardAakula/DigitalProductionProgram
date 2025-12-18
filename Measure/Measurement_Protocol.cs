using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;
using DigitalProductionProgram.Protocols.LineClearance;
using static DigitalProductionProgram.Measure.Measure_ControlManagement;

namespace DigitalProductionProgram.Measure
{
    public partial class Measurement_Protocol : Form
    {


        private readonly Measure_ControlManagement controls;
        public static int Max_Bag_Value()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT MAX(data.Value)
                    FROM MeasureProtocol.Data AS data
                        JOIN MeasureProtocol.Description AS description
                            ON data.DescriptionId = description.Id
                        LEFT JOIN MeasureProtocol.MainData AS maindata
                            ON data.OrderID = maindata.OrderID
                    WHERE data.OrderID = @orderid
                        AND description.CodeName IN ('Bag')
                        AND (maindata.Discarded IS NULL OR maindata.Discarded = 'False')
                        AND data.RowIndex NOT IN (
                            SELECT RowIndex 
                            FROM MeasureProtocol.MainData 
                            WHERE Discarded = 'True' AND OrderID = @orderid)";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            var value = cmd.ExecuteScalar();
            var maxValue = 0;
            if (value != null)
                int.TryParse(value.ToString(), out maxValue);
            return maxValue;
        }


        public bool IsSomeValueBad
        {
            get
            {
                foreach (Control control in flp_InputControls.Controls)
                    if (control.BackColor == CustomColors.Neutral_Back)
                        return true;
                return false;
            }
        }


        private string SortingOrder;

        private bool IsOkSaveData
        {
            get
            {
                if (IsSomeValueBad)
                {
                    InfoText.Question(LanguageManager.GetString("measureprotocol_Warning_1"), CustomColors.InfoText_Color.Bad, "Warning", this);
                    return InfoText.answer != InfoText.Answer.No;
                }
                if (IsTransferInEditMode)
                    return true;
                var IsOk = true;
                Control? control = null;
                foreach (Control? ctrl in flp_InputControls.Controls)
                {
                    if (Part.IsPartNrSpecial && (ctrl == InputControl(flp_InputControls, new[] { "ID" }) || ctrl == InputControl(flp_InputControls, new[] { "OD" }) || ctrl == InputControl(flp_InputControls, new[] { "Wall" })))
                        continue;

                    if (ctrl is IMandatoryControl isMandatoryControl)
                        if (isMandatoryControl.IsMandatory == false)
                            continue;
                    if (ctrl is InputCheckBox checkBox)
                        if (checkBox.Checked)
                            continue;
                    if (!string.IsNullOrEmpty(ctrl.Text))
                        continue;

                    control = ctrl;

                    IsOk = false;
                    break;
                }

                if (IsOk)
                    return true;
                InfoText.Show(LanguageManager.GetString("measureprotocol_Info_6").Replace("\\n", Environment.NewLine), CustomColors.InfoText_Color.Bad, "Error!");
                ControlValidator.SoftBlink(control, CustomColors.Bad_Front, Color.White, 200, 200);
                return false;
            }
        }
        private bool IsOkSaveLengthMeasure
        {
            get
            {
                if (InputControl(flp_InputControls, new[] { "Position" }).Text == "0")
                {
                    InfoText.Show(LanguageManager.GetString("measureprotocol_Info_7"), CustomColors.InfoText_Color.Bad, "Warning", this);
                    ControlValidator.SoftBlink(InputControl(flp_InputControls, new[] { "Position" }), CustomColors.Warning_Back, CustomColors.Warning_Front, 200);
                    return false;
                }
                if (string.IsNullOrEmpty(InputControl(flp_InputControls, new[] { "Length" }).Text) || InputControl(flp_InputControls, new[] { "Length" }).Text == "N/A")
                {
                    InfoText.Show(LanguageManager.GetString("measureprotocol_Info_8"), CustomColors.InfoText_Color.Bad, "Warning", this);
                    ControlValidator.SoftBlink(InputControl(flp_InputControls, new[] { "Length" }), CustomColors.Warning_Back, CustomColors.Warning_Front, 200);
                    return false;
                }

                foreach (Control control in flp_InputControls.Controls)
                {
                    if (!string.IsNullOrEmpty(control.Text))
                    {
                        InfoText.Show(LanguageManager.GetString("measureprotocol_Info_9"), CustomColors.InfoText_Color.Bad, "Warning", this);
                        return false;
                    }
                }
                if (!Person.IsPasswordOk(LanguageManager.GetString("measureprotocol_Info_10")))
                    return false;
                return true;
            }
        }
        private bool IsTransferInEditMode;

        public Measurement_Protocol()
        {
            Activity.Start();
            Calculate.Reset_Values();
            Part.SetPartNrSpecial("Spolning Special Mätprotokoll");

            SortingOrder = "ASC";
            if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.SortMeasurementsDESC))
                SortingOrder = "DESC";

            MeasureInformation.IsOpening = true;
            controls = new Measure_ControlManagement
            {
                wall = new Wall
                {
                    LCL = MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "LCL"),
                    UCL = MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "UCL"),
                    LSL = MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "LSL"),
                    USL = MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "USL"),
                    RunOut_USL = MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Runout, "USL"),
                    RunOut_UCL = MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Runout, "UCL")
                }
            };
            InitializeComponent();

            tb_Hack.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
            controls.Change_GUI_Template(this);
            AddControls.Load_InputControls(this);

            Load_FROM_Korprotokoll_Main();
            Load_MeasureData();
            Set_NumericUpDown_Values(this);
            measureInstrument.Load_Data();
            measureInstrument.dgv_Mätdon.CellValueChanged += measureInstrument.Mätdon_CellValueChanged;

            dgv_HelpInput_1.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
            dgv_HelpInput_2.KeyDown += Public_Events.Enter_To_TAB_KeyDown;

            Translate_Form();

            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                    break;
                case Manage_WorkOperation.WorkOperations.Kragning_PTFE:
                case Manage_WorkOperation.WorkOperations.Kragning_K22_PTFE:
                case Manage_WorkOperation.WorkOperations.Synergy_PTFE_K18:
                    if (LineClearance.IsLineClearanceApproved == false)
                    {
                        InfoText.Show(LanguageManager.GetString("Warning_OpenMeasureProtocol_3"), CustomColors.InfoText_Color.Bad, null);
                        Lock_Protocol();
                    }
                    break;
                default:
                    if (Order.IsOrderDone == false && LineClearance.IsLineClearanceDone == false)
                    {
                        InfoText.Show(LanguageManager.GetString("Warning_OpenMeasureProtocol_4"), CustomColors.InfoText_Color.Bad, null);
                        Lock_Protocol();
                    }
                    break;
            }

            if (Order.IsOrderDone)
                Lock_Protocol();

            _ = Activity.Stop("Öppnar Mätprotokoll");
        }


        private void Translate_Form()
        {
            Text = LanguageManager.GetString("Measurement_Protocol");

            LanguageManager.TranslationHelper.TranslateControls(new Control[]
            {
                label_Customer, label_Description, label_OrderNr, label_PartNumber, label_Ok, label_Fail, label_Warning, label_Felskrivning, label_Discarded, btn_Clear_HelpInput_1,
                btn_Clear_HelpInput_2, btn_TransferLengthMeasure, btn_TransferMeasurement, btn_EditBag, btn_EditAmount, btn_Discard, btn_TransferToExcel, label_TotalMeasureMents, label_DiscardedMeasurements
            });
            measureInstrument.Translate_Form();
        }
        private void Load_FROM_Korprotokoll_Main()
        {
            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                    tlp_OrderInfo_TEF.Dispose();
                    lbl_OrderNr_FEP.Text = Order.OrderNumber;
                    lbl_Kund_FEP.Text = Order.Customer;
                    Load_FROM_Korprotokoll_FEP();
                    break;
                default:
                    tlp_OrderInfo_FEP.Dispose();
                    lbl_Benämning_Övrigt.Text = Order.Description;
                    lbl_OrderNr_Övrigt.Text = Order.OrderNumber;
                    lbl_ArtikelNr_Övrigt.Text = Order.PartNumber;
                    lbl_Kund_Övrigt.Text = Order.Customer;
                    break;
            }
        }
        private void Load_FROM_Korprotokoll_FEP()
        {
            lbl_Nom_ID.Text = $"{MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ID, "NOM")}";
            lbl_Nom_OD.Text = $"{MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM")}";
            lbl_Nom_Wall.Text = $"{MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "NOM")}";
            lbl_Nom_Length.Text = $"{MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Length, "NOM")}";

            Korprotokoll.Load_Data(Order.OrderID, 247, 2, Single_Extrudering);
            Korprotokoll.Load_Data(Order.OrderID, 251, 2, Co_Extrudering);
            Korprotokoll.Load_Data(Order.OrderID, 248, 2, Clear);
            Korprotokoll.Load_Data(Order.OrderID, 252, 2, Röntgen);
            Korprotokoll.Load_Data(Order.OrderID, 250, 0, Antal_Stripes);
            Korprotokoll.Load_Data(Order.OrderID, 246, 1, tb_Hack);
        }
        private void Load_MeasureData()
        {
            // Säkerställ att stilar finns
            if (styleDiscarded == null)
                Initialize_Styles();

            dgv_Measurements.SuspendLayout();
            dgv_Measurements.Visible = false;
            dgv_Measurements.Rows.Clear();

            if (Templates_MeasureProtocol.MainTemplate.ID == 0)
                return;

            var rowsBuffer = new List<object[]>(); // mellanlagra alla rader i RAM

            using (var con = new SqlConnection(Database.cs_Protocol))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = @"
            SELECT 
                Parameter_UserText, 
                Parameter_Monitor,
                Data.Value, 
                TextValue,  
                BoolValue, 
                DateValue, 
                Date, 
                Discarded, 
                ErrorCode, 
                AnstNr, 
                Sign, 
                main.TempID, 
                ColumnIndex, 
                Decimals, 
                data.RowIndex, 
                template.DataType, 
                template.ControlType, 
                bag.value as Bag
            FROM MeasureProtocol.Data as data
            JOIN MeasureProtocol.Template as template
                ON data.DescriptionId = template.DescriptionID
            JOIN MeasureProtocol.MainData as main
                ON data.RowIndex = main.RowIndex AND data.OrderID = main.OrderID
            JOIN (
                SELECT 
                    OrderID, 
                    Rowindex, 
                    MAX(Value) as Value 
                FROM MeasureProtocol.Data 
                JOIN MeasureProtocol.Description as description 
                    ON data.DescriptionId = description.ID 
                WHERE CodeName = 'Bag' 
                GROUP BY orderid, rowindex
            ) bag ON bag.orderid = main.orderid AND main.rowindex = bag.rowindex
            WHERE data.OrderID = @orderid 
              AND MeasureProtocolMainTemplateID = @maintemplateid ";

                if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.SortMeasurementsDESC))
                    cmd.CommandText += $"ORDER BY Bag {SortingOrder}, RowIndex, ColumnIndex";
                else
                    cmd.CommandText += $"ORDER BY Date {SortingOrder}, Bag, RowIndex, ColumnIndex";

                cmd.Parameters.Add("@orderid", SqlDbType.Int).Value = Order.OrderID;
                cmd.Parameters.Add("@maintemplateid", SqlDbType.Int).Value = Templates_MeasureProtocol.MainTemplate.ID;

                ServerStatus.Add_Sql_Counter();
                con.Open();

                using (var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    while (reader.Read())
                    {
                        rowsBuffer.Add([
                            reader["Parameter_UserText"],
                            reader["Parameter_Monitor"],
                            reader["Value"],
                            reader["TextValue"],
                            reader["BoolValue"],
                            reader["Date"],
                            reader["Discarded"],
                            reader["ErrorCode"],
                            reader["AnstNr"],
                            reader["Sign"],
                            reader["TempID"],
                            reader["ColumnIndex"],
                            reader["Decimals"],
                            reader["DataType"],
                            reader["ControlType"]
                        ]);
                    }
                }
            }

            // Bearbeta data i minnet
            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            DataGridViewRow currentRow = null;
            int currentRowIndex = -1;

            foreach (var rowObj in rowsBuffer)
            {
                var parameterName = rowObj[1]?.ToString();
                var controlType = rowObj[14]?.ToString();
                var colIndex = Convert.ToInt32(rowObj[11]);
                int.TryParse(rowObj[12]?.ToString(), out var decimals);
                int.TryParse(rowObj[13]?.ToString(), out var dataType);
                bool.TryParse(rowObj[6]?.ToString(), out var isDiscarded);
                var tempId = Convert.ToInt32(rowObj[10]);
                string text = "";

                switch (controlType)
                {
                    case "TextBox":
                        if (dataType == 0 && double.TryParse(rowObj[2]?.ToString(), out var num))
                            text = SetDecimals_Value(num, decimals);
                        else if (dataType == 1)
                            text = rowObj[3]?.ToString();
                        else
                            text = "N/A";
                        break;

                    case "NumericUpDown":
                        if (double.TryParse(rowObj[2]?.ToString(), out var numValue))
                            text = SetDecimals_Value(numValue, decimals);
                        else
                            text = "N/A";
                        break;

                    case "CheckBox":
                        if (bool.TryParse(rowObj[4]?.ToString(), out var boolValue))
                            text = boolValue ? "\u2714" : "";
                        else
                            text = "N/A";
                        break;
                }

                // Starta ny rad om colIndex == 0
                if (colIndex == 0)
                {
                    currentRowIndex = dgv_Measurements.Rows.Add();
                    currentRow = dgv_Measurements.Rows[currentRowIndex];

                    var date = DateTime.TryParse(rowObj[5]?.ToString(), out var dt) ? dt : DateTime.MinValue;
                    var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                    formattedDate = formattedDate.Replace(":ss", "");

                    Add_Text_DatagridCell(currentRowIndex, currentRow.Cells["Date"], formattedDate, isDiscarded);
                    Add_Text_DatagridCell(currentRowIndex, currentRow.Cells["ErrorCode"], rowObj[7]?.ToString(), isDiscarded);
                    Add_Text_DatagridCell(currentRowIndex, currentRow.Cells["AnstNr"], rowObj[8]?.ToString(), isDiscarded);
                    Add_Text_DatagridCell(currentRowIndex, currentRow.Cells["Sign"], rowObj[9]?.ToString(), isDiscarded);
                    Add_Text_DatagridCell(currentRowIndex, currentRow.Cells["Discarded"], rowObj[6]?.ToString(), isDiscarded);
                    Add_Text_DatagridCell(currentRowIndex, currentRow.Cells["TempID"], tempId.ToString(), isDiscarded);
                }

                if (currentRow != null)
                    Add_Text_DatagridCell(currentRowIndex, currentRow.Cells[colIndex], text, isDiscarded, parameterName);
            }

            if (dgv_Measurements.Rows.Count > 0)
                dgv_Measurements.FirstDisplayedScrollingRowIndex = dgv_Measurements.Rows.Count - 1;

            Count_Measurements();
            dgv_Measurements.Visible = true;
            dgv_Measurements.ResumeLayout();
        }

        private void Count_Measurements()
        {
            var total = 0;
            var discarded = 0;

            foreach (DataGridViewRow row in dgv_Measurements.Rows)
            {
                if (row.IsNewRow)
                    continue;

                total++;

                var cell = row.Cells["Discarded"];
                if (cell?.Value != null && cell.Value.ToString().Equals("True", StringComparison.OrdinalIgnoreCase))
                    discarded++;
            }

            lbl_TotalMeasurements.Text = total.ToString();
            lbl_DiscardedMeasurements.Text = discarded.ToString();
        }

        private void Lock_Protocol()
        {
            btn_Discard.Enabled = btn_EditAmount.Enabled = btn_EditBag.Enabled = btn_TransferLengthMeasure.Enabled = btn_TransferMeasurement.Enabled = false;
            measureInstrument.Enabled = false;
            Co_Extrudering.Enabled = Antal_Stripes.Enabled = Single_Extrudering.Enabled = Clear.Enabled = Röntgen.Enabled = false;
            flp_Headers.Controls.Clear();
            flp_InputControls.Controls.Clear();
        }

        private DataGridViewCellStyle styleDiscarded;
        private DataGridViewCellStyle styleNA;
        private DataGridViewCellStyle styleOk;

        private void Initialize_Styles()
        {
            styleDiscarded = new DataGridViewCellStyle
            {
                BackColor = CustomColors.Discarded_Back,
                ForeColor = CustomColors.Discarded_Front,
                Font = StrikeoutFont
            };

            styleNA = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Red,
                Font = ItalicFont
            };

            styleOk = new DataGridViewCellStyle
            {
                BackColor = CustomColors.Ok_Back,
                ForeColor = CustomColors.Ok_Front
            };
        }

       

        private static readonly Font StrikeoutFont = new Font("Segoe UI", 9, FontStyle.Strikeout);
        private static readonly Font ItalicFont = new Font("Courier New", 8, FontStyle.Italic);

        private void Add_Text_DatagridCell(int row, DataGridViewCell cell, string text, bool isDiscarded, string codeText = null)
        {
            if (isDiscarded)
            {
                cell.Style = styleDiscarded;
            }
            else if (string.IsNullOrEmpty(text) || ControlValidator.IsStringNA(text))
            {
                cell.Style = styleNA;
                text = "N/A";
            }
            else
            {
                cell.Style = styleOk;
                if (!string.IsNullOrEmpty(codeText))
                    MeasurementValidator.DataVerification_Value_dgv(dgv_Measurements, text, codeText, row, cell.ColumnIndex);
            }

            cell.Value = text;
        }
      
        public static string SetDecimals_Value(double value, int decimals)
        {
            switch (decimals)
            {
                case 0:
                    return $"{value:0}";
                case 1:
                    return $"{value:0.0}";
                case 2:
                    return $"{value:0.00}";
                case 3:
                    return $"{value:0.000}";

                default:
                    return value.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void Co_Extrudering_CheckedChanged(object sender, EventArgs e)
        {
            Module.IsOkToSave = true;
            Korprotokoll.Save_Data(Co_Extrudering.Checked.ToString(), 251, 2);

            if (Co_Extrudering.Checked)
            {
                Co_Extrudering.CheckedChanged -= Co_Extrudering_CheckedChanged;
                Single_Extrudering.Checked = false;
            }
            Co_Extrudering.CheckedChanged += Co_Extrudering_CheckedChanged;
            Module.IsOkToSave = false;
        }
        private void Singel_Extrudering_CheckedChanged(object sender, EventArgs e)
        {
            Module.IsOkToSave = true;
            Korprotokoll.Save_Data(Single_Extrudering.Checked.ToString(), 247, 2);

            if (Single_Extrudering.Checked)
            {
                Single_Extrudering.CheckedChanged -= Singel_Extrudering_CheckedChanged;
                Co_Extrudering.Checked = false;
            }
            Single_Extrudering.CheckedChanged += Singel_Extrudering_CheckedChanged;
            Module.IsOkToSave = false;
        }
        private void Clear_CheckedChanged(object sender, EventArgs e)
        {
            Module.IsOkToSave = true;
            Korprotokoll.Save_Data(Clear.Checked.ToString(), 248, 2);

            if (Clear.Checked)
            {
                Clear.CheckedChanged -= Clear_CheckedChanged;
                Röntgen.Checked = false;
            }
            Clear.CheckedChanged += Clear_CheckedChanged;
            Module.IsOkToSave = false;
        }
        private void Röntgen_CheckedChanged(object sender, EventArgs e)
        {
            Module.IsOkToSave = true;
            Korprotokoll.Save_Data(Röntgen.Checked.ToString(), 252, 2);

            if (Röntgen.Checked)
            {
                Röntgen.CheckedChanged -= Röntgen_CheckedChanged;
                Clear.Checked = false;
            }
            Röntgen.CheckedChanged += Röntgen_CheckedChanged;
            Module.IsOkToSave = false;
        }
        private void Antal_Stripes_Leave(object sender, EventArgs e)
        {
            Module.IsOkToSave = true;
            Korprotokoll.Save_Data(Antal_Stripes.Text, 250, 0);
            Module.IsOkToSave = false;
        }
        private void TransferMeasurement_Click(object sender, EventArgs e)
        {
            Activity.Start();
            string loginfo;
            var bag = "0";
            if (InputControl(flp_InputControls, new[] { "Bag" }) != null)
                bag = InputControl(flp_InputControls, new[] { "Bag" }).Text;

            if (IsOkSaveData == false)
                return;
            if (!Person.IsPasswordOk(LanguageManager.GetString("measureprotocol_Info_2")))
                return;

            
            if (IsTransferInEditMode)
            {
                UPDATE_MeasureProtocol_Values();
                loginfo = "UPDATE";
            }
            else
            {
                var IsTransferOk = true;
                INSERT_MeasureProtocol_Values(ref IsTransferOk);
                if (IsTransferOk)
                    INSERT_MeasureProtocol_Main();
                else
                    _ = Activity.Stop($"Measurement Failed - {bag}");
                loginfo = "INSERT";
            }

            IsTransferInEditMode = false;
            btn_Discard.Enabled = true;
            btn_EditBag.Enabled = true;
            btn_EditAmount.Enabled = true;
            btn_TransferLengthMeasure.Enabled = false;



            Points.Add_Points(5, "Överför Mätning - Mätprotokoll");
            Load_MeasureData();
            Refresh();
            Thread.Sleep(1000);



            Set_NumericUpDown_Values(this);

            controls.Clear_InputControls(this);
            controls.ClearYellowBoxes(this);
            foreach (Control ctrl in flp_InputControls.Controls)
                ctrl.Enabled = true;
            Order.Check_BioBurden_Samples(int.Parse(bag), MeasureInformation.Most_Frequent_TotalAmount, this); //Denna är SAFE, drar inget minne.
            if (dgv_Measurements.Rows.Count == 1)
                Settings.Settings.Notifications.Subscription.NotifyFirstRun();

            _ = Activity.Stop($"Överför Mätning ({loginfo}) - {Order.WorkOperation} - Spole: {bag} - RowIndex: {dgv_Measurements.Rows.Count} - Användare.AnstNr = {Person.EmployeeNr}");
            dgv_HelpInput_1.Focus();
            Calculate.Reset_Values();
        }
        private void DiscardMeasurement_Click(object sender, EventArgs e)
        {
            if (dgv_Measurements.SelectedRows.Count < 1)
            {
                InfoText.Show(LanguageManager.GetString("measureprotocol_Info_3"), CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            if (dgv_Measurements.CurrentRow != null)
            {
                var row = dgv_Measurements.CurrentRow.Index;
                using var chooseErrorCode = new ChooseErrorCode();
                using var black = new BlackBackground("", 80);
                black.Show();
                chooseErrorCode.ShowDialog();
                if (string.IsNullOrEmpty(chooseErrorCode.ErrorCode) || string.IsNullOrEmpty(chooseErrorCode.Comment))
                {
                    InfoText.Show(LanguageManager.GetString("measureprotocol_Info_12"), CustomColors.InfoText_Color.Info, LanguageManager.GetString("Warning"));
                    black.Close();
                    return;
                }

                black.Close();

                var errorCode = chooseErrorCode.ErrorCode.Substring(0, 3);
                var tempid = dgv_Measurements.Rows[row].Cells["TempID"].Value.ToString();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "UPDATE Measureprotocol.MainData SET Discarded = 'True', ErrorCode = @errorcode WHERE OrderID = @orderid AND TempID = @tempid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@errorcode", errorCode);
                    cmd.Parameters.AddWithValue("@tempid", tempid);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                var comment = $"{LanguageManager.GetString("discardedMeasurement_Info_1")} {errorCode} - {chooseErrorCode.Comment}";
                var bag = dgv_Measurements.Rows[row].Cells["Bag"].Value.ToString();
                Extra_Comments.Add(bag, comment, Person.EmployeeNr, true, Extra_Comments.Next_Row_ExtraComments);
            }

            Load_MeasureData();
        }
        private void TransferLengthMeasure_Click(object sender, EventArgs e)
        {
            //Osäker om denna används längre, tror den hört till Krympslang.
            //Den är dold tills vidare tills Produktion frågar nåt.
            if (IsOkSaveLengthMeasure == false)
                return;
            var IsTransferOk = true;
            INSERT_MeasureProtocol_Values(ref IsTransferOk);
            if (IsTransferOk)
                INSERT_MeasureProtocol_Main();
        }
        private void EditTotal_Click(object sender, EventArgs e)
        {
            MeasureInformation.IsOpening = true;

            IsTransferInEditMode = true;
            btn_Discard.Enabled = false;
            btn_EditAmount.Enabled = false;
            btn_TransferLengthMeasure.Enabled = false;

            CopyRowToInputControls(dgv_Measurements.CurrentCell.RowIndex);
            foreach (Control ctrl in flp_InputControls.Controls)
            {
                ctrl.Enabled = false;

                switch (ctrl)
                {
                    case InputNumericUpDown num when num.IsOkEdit:
                    case InputTextBox tb when tb.IsOkEdit:
                        ctrl.Enabled = true;
                        break;
                }
            }

            MeasureInformation.IsOpening = false;
        }
        private void EditBag_Click(object sender, EventArgs e)
        {
            MeasureInformation.IsOpening = true;

            IsTransferInEditMode = true;
            btn_Discard.Enabled = false;
            btn_EditBag.Enabled = false;
            btn_TransferLengthMeasure.Enabled = false;

            CopyRowToInputControls(dgv_Measurements.CurrentCell.RowIndex);
            foreach (Control ctrl in flp_InputControls.Controls)
            {
                ctrl.Enabled = false;

                switch (ctrl)
                {
                    case InputNumericUpDown num when num.IsOkEdit:
                    case InputTextBox tb when tb.IsOkEdit:
                        ctrl.Enabled = true;
                        break;
                }
            }

            MeasureInformation.IsOpening = false;
        }
        private void Hack_Leave(object sender, EventArgs e)
        {
            Module.IsOkToSave = true;
            Korprotokoll.Save_Data(tb_Hack.Text, 246, 1);
            Module.IsOkToSave = false;
        }
        private void CopyRow_Measurements_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CopyRowToInputControls(e.RowIndex);
        }
        private void CopyRowToInputControls(int row)
        {
            for (var i = 0; i < dgv_Measurements.Columns.Count - 5; i++)
            {
                var name = dgv_Measurements.Columns[i].Name;
                var ctrl = InputControl(flp_InputControls, new[] { name });
                if (ctrl is TextBox || ctrl is NumericUpDown)
                    ctrl.Text = dgv_Measurements.Rows[row].Cells[i].Value.ToString();
            }
        }
        private void SortMeasurementSpool(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (SortingOrder == "ASC")
                SortingOrder = "DESC";
            else
                SortingOrder = "ASC";
            Load_MeasureData();
        }


        private void INSERT_MeasureProtocol_Main()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    INSERT INTO MeasureProtocol.MainData
                    VALUES (@orderID, NULL, @date, NULL, @employeenumber, @sign, COALESCE((SELECT MAX(rowindex) + 1 FROM MeasureProtocol.MainData WHERE OrderID = @orderid), 1))";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderID", Order.OrderID);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                cmd.Parameters.AddWithValue("@sign", Person.Sign);
                cmd.ExecuteNonQuery();
            }
        }
        private void INSERT_MeasureProtocol_Values(ref bool IsTransferOk)
        {
            foreach (Control ctrl in flp_InputControls.Controls)
            {
                var descriptionID = 10000;
                var dataType = 0;
                switch (ctrl)
                {
                    case Label _:
                        continue;
                    case InputCheckBox checkBox:
                        descriptionID = checkBox.DescriptionID;
                        dataType = checkBox.DataType;
                        break;
                    case InputNumericUpDown numericUpDown:
                        descriptionID = numericUpDown.DescriptionID;
                        dataType = numericUpDown.DataType;
                        break;
                    case InputTextBox textBox:
                        descriptionID = textBox.DescriptionID;
                        dataType = textBox.DataType;
                        break;
                }

                if (descriptionID == 10000)
                {
                    IsTransferOk = false;
                    return;
                }

                // 🚀 Använd ExecuteSafe istället för att öppna connection direkt
                Database.ExecuteSafe(_ =>
                 {
                     const string query = @"
                INSERT INTO MeasureProtocol.Data
                VALUES (@orderid, @descriptionid, @value, @textvalue, @boolvalue, @datevalue, 
                COALESCE((SELECT MAX(rowindex) + 1 
                          FROM MeasureProtocol.MainData 
                          WHERE OrderID = @orderid), 1))";

                     using var cmd = new SqlCommand(query, _);
                     ServerStatus.Add_Sql_Counter();

                     cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                     cmd.Parameters.AddWithValue("@descriptionid", descriptionID);

                     switch (dataType)
                     {
                         case 0:
                             SQL_Parameter.Double(cmd.Parameters, "@value", ctrl.Text);
                             cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                             cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                             break;
                         case 1:
                             SQL_Parameter.String(cmd.Parameters, "@textvalue", ctrl.Text);
                             cmd.Parameters.AddWithValue("@value", DBNull.Value);
                             cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                             break;
                         case 2:
                             cmd.Parameters.AddWithValue("@value", DBNull.Value);
                             cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                             var chb = (CheckBox)ctrl;
                             SQL_Parameter.Boolean(cmd.Parameters, "@boolvalue", chb.Checked);
                             break;
                     }

                     cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                     cmd.ExecuteNonQuery();
                     return true; // returnvärde krävs för ExecuteSafe<T>
                 });
            }
        }

        private void UPDATE_MeasureProtocol_Values()
        {
            foreach (Control ctrl in flp_InputControls.Controls)
            {
                if (ctrl is Label || ctrl.Enabled == false)
                    continue;

                var descriptionID = 10000;
                var dataType = 0;
                switch (ctrl)
                {
                    case InputCheckBox checkBox:
                        descriptionID = checkBox.DescriptionID;
                        dataType = checkBox.DataType;
                        break;
                    case InputNumericUpDown numericUpDown:
                        descriptionID = numericUpDown.DescriptionID;
                        dataType = numericUpDown.DataType;
                        break;
                    case InputTextBox textBox:
                        descriptionID = textBox.DescriptionID;
                        dataType = textBox.DataType;
                        break;
                }
                
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        UPDATE MeasureProtocol.Data
                        SET Value = IsNull(@value, Value), TextValue = IsNull(@textvalue, TextValue)
                        WHERE OrderID = @orderid 
                            AND DescriptionId = @descriptionid 
                            AND RowIndex = @rowindex";

                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@descriptionid", descriptionID);
                SQL_Parameter.Int(cmd.Parameters, "@rowIndex", dgv_Measurements.CurrentCell.RowIndex + 1);
                switch (dataType)
                {
                    case 0:
                        SQL_Parameter.Double(cmd.Parameters, "@value", ctrl.Text);
                        cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                        break;
                    case 1:
                        SQL_Parameter.String(cmd.Parameters, "@textvalue", ctrl.Text);
                        cmd.Parameters.AddWithValue("@value", DBNull.Value);
                        break;
                }

                cmd.ExecuteNonQuery();
            }
        }

        private bool KeyUpHandled;
        private void HelpInput_1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyUp += HelpInput_1_CellValueKeyUp;
            tb.KeyDown += HelpInput_1_CellValueKeyDown;

        }
        private void HelpInput_2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyUp += HelpInput_2_CellValueKeyUp;
            tb.KeyDown += HelpInput_1_CellValueKeyDown;
        }



        private bool IsOkDrawTube
        {
            get
            {
                foreach (DataGridViewRow dgvRow in dgv_HelpInput_1.Rows)
                    if (dgvRow.Cells[1].EditedFormattedValue is null || string.IsNullOrEmpty(dgvRow.Cells[1].EditedFormattedValue.ToString()))
                        return false;
                return true;
            }
        }
        private void HelpInput_1_CellValueKeyDown(object sender, KeyEventArgs e)
        {
            KeyUpHandled = false;
        }
        private void HelpInput_1_CellValueKeyUp(object sender, KeyEventArgs e)
        {
            if (MeasureInformation.IsOpening || KeyUpHandled)
                return;

            KeyUpHandled = true;
            var dgv = dgv_HelpInput_1;
            var row = dgv.CurrentCell.RowIndex;
            var col = dgv.CurrentCell.ColumnIndex;
            Calculate_xyValues_Measurement_1(dgv, row);
            Calculate_Walls(dgv_Walls, typeof(Calculate.Measurement_1));
            //CodeName "ID", "OD", m.m. måste matcha namnet som finns i Databastabellen MeasureProtocol.Description
            if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.ManufacturesHeatShrink))
            {
                InputControl(flp_InputControls, new[] { "Exp ID" }).Text = $"{Calculate.Measurement_1.ID_1Layer:0.000}";
                InputControl(flp_InputControls, new[] { "Exp OD" }).Text = $"{Calculate.Measurement_1.OD_1Layer:0.000}";
                InputControl(flp_InputControls, new[] { "Exp Wall" }).Text = $"{Calculate.Measurement_1.Wall_1Layer:0.000}";
                // InputControl(flp_InputControls, "Exp Concentricity").Text = $"{Calculate.Conc:0}";
            }
            else
            {
                switch (Order.NumberOfLayers)
                {
                    case 0:
                    case 1:

                        InputControl(flp_InputControls, new[] { "ID", "Main Body ID" }).Text = $"{Calculate.Measurement_1.ID_1Layer:0.000}";
                        InputControl(flp_InputControls, new[] { "OD", "Main Body OD" }).Text = $"{Calculate.Measurement_1.OD_1Layer:0.000}";
                        InputControl(flp_InputControls, new[] { "Wall" }).Text = $"{Calculate.Measurement_1.Wall_1Layer:0.000}";
                        InputControl(flp_InputControls, new[] { "Ovality" }).Text = $"{Calculate.Measurement_1.Oval_1Layer:0.000}";
                        InputControl(flp_InputControls, new[] { "Runout" }).Text = $"{Calculate.Measurement_1.RunOut_1Layer:0.000}";
                        break;
                    case 2:
                        InputControl(flp_InputControls, new[] { "ID", "Main Body ID" }).Text = $"{Calculate.Measurement_1.ID_2Layer:0.000}";
                        InputControl(flp_InputControls, new[] { "OD", "Main Body OD" }).Text = $"{Calculate.Measurement_1.OD_2Layer:0.000}";
                        InputControl(flp_InputControls, new[] { "Layer1OD" }).Text = $"{Calculate.Measurement_1.OD_2Layer_Layer1:0.000}";
                        InputControl(flp_InputControls, new[] { "Wall" }).Text = $"{Calculate.Measurement_1.Wall_2Layer_Layer1 + Calculate.Measurement_1.Wall_2Layer_Layer2:0.000}";
                        InputControl(flp_InputControls, new[] { "WallLayer1" }).Text = $"{Calculate.Measurement_1.Wall_2Layer_Layer1:0.000}";
                        InputControl(flp_InputControls, new[] { "WallLayer2" }).Text = $"{Calculate.Measurement_1.Wall_2Layer_Layer2:0.000}";
                        InputControl(flp_InputControls, new[] { "Ovality" }).Text = $"{Calculate.Measurement_1.Oval_2Layer:0.000}";
                        InputControl(flp_InputControls, new[] { "Runout" }).Text = $"{Calculate.Measurement_1.RunOut_2Layer:0.000}";
                        InputControl(flp_InputControls, new[] { "RunoutLayer1" }).Text = $"{Calculate.Measurement_1.RunOut_2Layer_Layer1:0.000}";
                        InputControl(flp_InputControls, new[] { "RunoutLayer2" }).Text = $"{Calculate.Measurement_1.RunOut_2Layer_Layer2:0.000}";
                        break;
                }
            }

            if (IsOkDrawTube)
                Task.Factory.StartNew(() => controls.Draw_CrossSectionTube(this));
        }
        private void HelpInput_2_CellValueKeyUp(object sender, KeyEventArgs e)
        {
            if (MeasureInformation.IsOpening)
                return;

            var dgv = dgv_HelpInput_2;
            var row = dgv.CurrentCell.RowIndex;
            var col = dgv.CurrentCell.ColumnIndex;
            Calculate_xyValues_Measurement_2(dgv, row);
            Calculate_Walls(dgv_RecWalls, typeof(Calculate.Measurement_2));

            InputControl(flp_InputControls, new[] { "Rec ID" }).Text = $"{Calculate.Measurement_2.ID:0.000}";
            InputControl(flp_InputControls, new[] { "Rec OD" }).Text = $"{Calculate.Measurement_2.OD:0.000}";
            InputControl(flp_InputControls, new[] { "Rec Wall" }).Text = $"{Calculate.Measurement_2.Wall:0.000}";

            if (IsOkDrawTube)
                Task.Factory.StartNew(() => controls.Draw_CrossSectionTube(this));
        }
        private void Walls_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridView dgv = sender as DataGridView;
                if (dgv.CurrentCell.ColumnIndex == 1) // Second column
                {
                    e.IsInputKey = true; // Mark Enter as a handled key
                    SendKeys.Send("{TAB}"); // Move to next row or cell
                }
            }
        }
        public void Exp_ID_MouseUp(object? sender, MouseEventArgs e)
        {
            var ctrl = InputControl(flp_InputControls, new[] { "Exp ID" });
            if (e.Button == MouseButtons.Right)
            {
                menu_Beräkna.Show(ctrl, e.X, e.Y);
                menu_ID_Blåst.Visible = true;
                menu_OD_Blåst.Visible = false;
                menu_W_Blåst.Visible = false;
                menu_ID_Krympt.Visible = false;
                menu_OD_Krympt.Visible = false;
                menu_W_Krympt.Visible = false;
            }
        }
        public void Exp_OD_MouseUp(object? sender, MouseEventArgs e)
        {
            var ctrl = (Control)sender;
            if (e.Button == MouseButtons.Right)
            {
                menu_Beräkna.Show(ctrl, e.X, e.Y);
                menu_ID_Blåst.Visible = false;
                menu_OD_Blåst.Visible = true;
                menu_W_Blåst.Visible = false;
                menu_ID_Krympt.Visible = false;
                menu_OD_Krympt.Visible = false;
                menu_W_Krympt.Visible = false;
            }
        }
        public void Exp_Wall_MouseUp(object? sender, MouseEventArgs e)
        {
            var ctrl = (Control)sender;
            if (e.Button == MouseButtons.Right)
            {
                menu_Beräkna.Show(ctrl, e.X, e.Y);
                menu_ID_Blåst.Visible = false;
                menu_OD_Blåst.Visible = false;
                menu_W_Blåst.Visible = true;
                menu_ID_Krympt.Visible = false;
                menu_OD_Krympt.Visible = false;
                menu_W_Krympt.Visible = false;
            }
        }
        public void Rec_ID_MouseUp(object? sender, MouseEventArgs e)
        {
            var ctrl = (Control)sender;
            if (e.Button == MouseButtons.Right)
            {
                menu_Beräkna.Show(ctrl, e.X, e.Y);
                menu_ID_Blåst.Visible = false;
                menu_OD_Blåst.Visible = false;
                menu_W_Blåst.Visible = false;
                menu_ID_Krympt.Visible = true;
                menu_OD_Krympt.Visible = false;
                menu_W_Krympt.Visible = false;
            }
        }
        public void Rec_OD_MouseUp(object? sender, MouseEventArgs e)
        {
            var ctrl = (Control)sender;
            if (e.Button == MouseButtons.Right)
            {
                menu_Beräkna.Show(ctrl, e.X, e.Y);
                menu_ID_Blåst.Visible = false;
                menu_OD_Blåst.Visible = false;
                menu_W_Blåst.Visible = false;
                menu_ID_Krympt.Visible = false;
                menu_OD_Krympt.Visible = true;
                menu_W_Krympt.Visible = false;
            }
        }
        public void Rec_Wall_MouseUp(object? sender, MouseEventArgs e)
        {
            var ctrl = (Control)sender;
            if (e.Button == MouseButtons.Right)
            {
                menu_Beräkna.Show(ctrl, e.X, e.Y);
                menu_ID_Blåst.Visible = false;
                menu_OD_Blåst.Visible = false;
                menu_W_Blåst.Visible = false;
                menu_ID_Krympt.Visible = false;
                menu_OD_Krympt.Visible = false;
                menu_W_Krympt.Visible = true;
            }
        }
        private void Menu_Beräkna_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = e.ClickedItem;
            _ = Activity.Stop(item.Text);
            double.TryParse(InputControl(flp_InputControls, new[] { "Exp ID" }).Text, out var ExpID);
            double.TryParse(InputControl(flp_InputControls, new[] { "Exp OD" }).Text, out var ExpOD);
            double.TryParse(InputControl(flp_InputControls, new[] { "Exp Wall" }).Text, out var ExpWall);
            double.TryParse(InputControl(flp_InputControls, new[] { "Rec ID" }).Text, out var RecID);
            double.TryParse(InputControl(flp_InputControls, new[] { "Rec OD" }).Text, out var RecOD);
            double.TryParse(InputControl(flp_InputControls, new[] { "Rec Wall" }).Text, out var RecWall);


            switch (item.Text)
            {
                case "Calculate Exp. ID with Wall and OD":
                    if (ExpOD > 0 && ExpWall > 0)
                        InputControl(flp_InputControls, new[] { "Exp ID" }).Text = $"{ExpOD - (ExpWall + ExpWall)}";
                    return;
                case "Calculate Exp. OD with Wall and ID":
                    if (ExpID > 0 && ExpWall > 0)
                        InputControl(flp_InputControls, new[] { "Exp OD" }).Text = $"{ExpID + ExpWall + ExpWall}";
                    return;
                case "Calculate Exp. Wall with ID and OD":
                    if (ExpOD > 0 && ExpID > 0)
                        InputControl(flp_InputControls, new[] { "Exp Wall" }).Text = $"{(ExpOD - ExpID) / 2}";
                    return;
                case "Calculate Rec. ID with Wall and OD":
                    if (RecOD > 0 && RecWall > 0)
                        InputControl(flp_InputControls, new[] { "Rec ID" }).Text = $"{RecOD - (RecWall + RecWall)}";
                    return;
                case "Calculate Rec. OD with Wall and ID":
                    if (RecID > 0 && RecWall > 0)
                        InputControl(flp_InputControls, new[] { "Rec OD" }).Text = $"{RecID + RecWall + RecWall}";
                    return;
                case "Calculate Rec. Wall with ID and OD":
                    if (RecOD > 0 && RecID > 0)
                        InputControl(flp_InputControls, new[] { "Rec Wall" }).Text = $"{(RecOD - RecID) / 2}";
                    return;
            }

            InfoText.Show(LanguageManager.GetString("measureprotocol_Info_5"), CustomColors.InfoText_Color.Warning, "Warning", this);
        }
        private void Calculate_Walls(DataGridView dgv, Type measurementType)
        {
            if (dgv.Rows.Count > 4)
            {
                dgv.Rows[0].Cells[1].Value = GetPropertyValue(measurementType, "x1") / 1000;
                dgv.Rows[1].Cells[1].Value = (GetPropertyValue(measurementType, "x5") - GetPropertyValue(measurementType, "x4")) / 1000;
                dgv.Rows[2].Cells[1].Value = GetPropertyValue(measurementType, "y1") / 1000;
                dgv.Rows[3].Cells[1].Value = (GetPropertyValue(measurementType, "y5") - GetPropertyValue(measurementType, "y4")) / 1000;

                dgv.Rows[4].Cells[1].Value = (GetPropertyValue(measurementType, "x2") - GetPropertyValue(measurementType, "x1")) / 1000;
                dgv.Rows[5].Cells[1].Value = (GetPropertyValue(measurementType, "x4") - GetPropertyValue(measurementType, "x3")) / 1000;
                dgv.Rows[6].Cells[1].Value = (GetPropertyValue(measurementType, "y2") - GetPropertyValue(measurementType, "y1")) / 1000;
                dgv.Rows[7].Cells[1].Value = (GetPropertyValue(measurementType, "y4") - GetPropertyValue(measurementType, "y3")) / 1000;

                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[0].Cells[1], "Wall Layer 1");
                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[1].Cells[1], "Wall Layer 1");
                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[2].Cells[1], "Wall Layer 1");
                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[3].Cells[1], "Wall Layer 1");

                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[4].Cells[1], "Wall Layer 2");
                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[5].Cells[1], "Wall Layer 2");
                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[6].Cells[1], "Wall Layer 2");
                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[7].Cells[1], "Wall Layer 2");
            }
            else
            {
                dgv.Rows[0].Cells[1].Value = GetPropertyValue(measurementType, "x1") / 1000;
                dgv.Rows[1].Cells[1].Value = (GetPropertyValue(measurementType, "x3") - GetPropertyValue(measurementType, "x2")) / 1000;
                dgv.Rows[2].Cells[1].Value = GetPropertyValue(measurementType, "y1") / 1000;
                dgv.Rows[3].Cells[1].Value = (GetPropertyValue(measurementType, "y3") - GetPropertyValue(measurementType, "y2")) / 1000;

                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[0].Cells[1], "Wall");
                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[1].Cells[1], "Wall");
                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[2].Cells[1], "Wall");
                MeasurementValidator.DataVerification_Walls_dgv(dgv.Rows[3].Cells[1], "Wall");
            }
        }

        private double GetPropertyValue(Type type, string fieldName)
        {
            var field = type.GetField(fieldName);
            if (field != null)
            {
                var value = field.GetValue(null); // Get static field value
                return value != null ? Convert.ToDouble(value) : 0;
            }

            return 0; // Default value if field is missing
        }

        private static void Calculate_xyValues_Measurement_1(DataGridView dgv, int row)
        {
            var text = dgv.CurrentCell.EditedFormattedValue?.ToString();
            if (string.IsNullOrWhiteSpace(text))
                return;

            if (!double.TryParse(text, out double value))
                return; // Exit if parsing fails

            var variableName = dgv.Rows[row].Cells[0].Value?.ToString();
            if (string.IsNullOrWhiteSpace(variableName))
                return;

            // Dictionary to map variable names to properties dynamically
            var variableMap = new Dictionary<string, Action<double>>
            {
                ["x1"] = v => Calculate.Measurement_1.x1 = v,
                ["x2"] = v => Calculate.Measurement_1.x2 = v,
                ["x3"] = v => Calculate.Measurement_1.x3 = v,
                ["x4"] = v => Calculate.Measurement_1.x4 = v,
                ["x5"] = v => Calculate.Measurement_1.x5 = v,
                ["x6"] = v => Calculate.Measurement_1.x6 = v,
                ["y1"] = v => Calculate.Measurement_1.y1 = v,
                ["y2"] = v => Calculate.Measurement_1.y2 = v,
                ["y3"] = v => Calculate.Measurement_1.y3 = v,
                ["y4"] = v => Calculate.Measurement_1.y4 = v,
                ["y5"] = v => Calculate.Measurement_1.y5 = v,
                ["y6"] = v => Calculate.Measurement_1.y6 = v
            };

            // Assign value if the variable name exists in the dictionary
            if (variableMap.TryGetValue(variableName, out var assignValue))
            {
                assignValue(value);
            }
        }
        private static void Calculate_xyValues_Measurement_2(DataGridView dgv, int row)
        {
            var text = dgv.CurrentCell.EditedFormattedValue?.ToString();
            if (string.IsNullOrWhiteSpace(text))
                return;

            if (!double.TryParse(text, out double value))
                return; // Exit if parsing fails

            var variableName = dgv.Rows[row].Cells[0].Value?.ToString();
            if (string.IsNullOrWhiteSpace(variableName))
                return;

            // Dictionary to map variable names to properties dynamically
            var variableMap = new Dictionary<string, Action<double>>
            {
                ["x1"] = v => Calculate.Measurement_2.x1 = v,
                ["x2"] = v => Calculate.Measurement_2.x2 = v,
                ["x3"] = v => Calculate.Measurement_2.x3 = v,
                ["y1"] = v => Calculate.Measurement_2.y1 = v,
                ["y2"] = v => Calculate.Measurement_2.y2 = v,
                ["y3"] = v => Calculate.Measurement_2.y3 = v,
            };

            // Assign value if the variable name exists in the dictionary
            if (variableMap.TryGetValue(variableName, out var assignValue))
            {
                assignValue(value);
            }
        }
        private void Clear_HelpInput_1_Click(object sender, EventArgs e)
        {
            controls.ClearYellowBoxes(this);
            Calculate.Reset_Values();
        }

        private void Measurement_Protocol_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ = Activity.Stop("Stänger Mätprotokoll");
        }
    }



}
