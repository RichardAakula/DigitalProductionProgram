using System;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Globalization;
using System.IO.Ports;
using System.Security.Cryptography;
using System.Windows.Forms.DataVisualization.Charting;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.PrintingServices.Workoperation_Printouts;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.User;
using ProgressBar = DigitalProductionProgram.ControlsManagement.ProgressBar;

namespace DigitalProductionProgram.Zumbach
{
    public partial class MeasureWithZumbach : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                Change_Measurement(1, "btn_Up", null);
                return true; // indicate that you handled this keystroke
            }
            if (keyData == Keys.Down)
            {
                Change_Measurement(1, "btn_Down", null);
                return true;
            }
            if (keyData == Keys.PageUp)
            {
                btn_Up_Full.PerformClick();
                return true;
            }
            if (keyData == Keys.PageDown)
            {
                btn_Down_Full.PerformClick();
                return true;
            }
            if (keyData == Keys.D1)
            {
                Position_Click(rb_Position1, null);
                return true;
            }
            if (keyData == Keys.D2)
            {
                Position_Click(rb_Position2, null);
                return true;
            }
            if (keyData == Keys.D3)
            {
                Position_Click(rb_Position3, null);
                return true;
            }
            if (keyData == Keys.L)
            {
                //if (chb_LoggaData.Checked)
                //    chb_LoggaData.Checked = false;
                //else
                //    chb_LoggaData.Checked = true;
                //chb_LoggaData_CheckedChanged(chb_LoggaData, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private ProgressBar pbar;
        private readonly PrintPreviewDialog preview_Chart = new();
        private readonly PrintDocument print_Chart = new();
        private readonly ToolTip tooltip = new();
        private Point? prevPosition;
        private int? DeleteMeasurements;
        private readonly SerialPort serialPort;

        private Panel? panel_Blink(int pos)
        {
            switch (pos)
            {
                case 0:
                    return panel_Position1;
                case 1:
                    return panel_Position2;
                case 2:
                    return panel_Position3;
            }
            return null;
        }
        private readonly StripLine StripLine_USL = new();
        private readonly StripLine StripLine_LSL = new();
        private readonly StripLine StripLine_UCL = new();
        private readonly StripLine StripLine_LCL = new();



        public static void Load_ZumbachData()
        {
            ZumbachData = new DataTable();
            var query = @"
                    SELECT data.OrderID, OD, data.Position, data.Bag, m.Discarded, data.ID, m.DateTime
                    FROM Zumbach.Data AS data
                    JOIN Zumbach.Measurements AS m
	                    ON data.OrderID = m.OrderID AND data.Position = m.Position AND data.Bag = m.Bag
                    WHERE data.OrderID = @orderid
                    ORDER BY Bag, Position, DateTime, ID";
            using var con = new SqlConnection(Database.cs_Protocol);
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            cmd.CommandTimeout = 1800;
            con.Open();

            var dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(ZumbachData);
        }
        public static DataTable? ZumbachData { get; set; }
        



        //private Dictionary<string, string>? utskrift_Körprotokoll;


        private string? zumbachMessage;

        public static int Measurement;
        private int position;
        private int ctr_AutoLogOFF;
        private int startRow;   //anger vilken rad i ZumbachData som den senaste mätningen startar vid
        private int stack;

        
        public static double? ExpOD_LSL, ExpOD_USL, ExpOD_UCL, ExpOD_LCL;

        private bool IsLogging;
        private bool IsSeriesEmpty
        {
            get
            {
                if (chartZumbach.Series.Count < 3)
                    return false;
                if (chartZumbach.Series[0].Points.Count < 1 && chartZumbach.Series[1].Points.Count < 1 && chartZumbach.Series[2].Points.Count < 1)
                    return true;
                return false;
            }
        }
        private bool IsSeriesContainsValues
        {
            get
            {
                if (chartZumbach.Series.Count < 3)
                    return false;
                if (chartZumbach.Series[0].Points.Count > 0 && chartZumbach.Series[1].Points.Count > 0 && chartZumbach.Series[2].Points.Count > 0)
                    return true;
                return false;
            }

        }
        private bool IsOD_Ok(double od)
        {
            bool flag;
            if (od == 0)
                return false;

            if (od > StripLine_LSL.IntervalOffset - 1.0 && StripLine_LSL.IntervalOffset > 0)
                flag = true;
            else
                return false;
            if (StripLine_LSL.IntervalOffset == 0)
                flag = true;

            if (od < StripLine_USL.IntervalOffset + 1.0 && StripLine_USL.IntervalOffset > 0)
                flag = true;
            else
                return false;

            if (StripLine_USL.IntervalOffset == 0)
                return true;

            if (ExpOD_LSL != null && od < ExpOD_LSL * 1.30)
                flag = true;
            else
                flag = false;
            if (od > chartZumbach.ChartAreas[0].AxisY.Minimum)
                flag = true;
            else
                flag = false;

            return flag;
        }
        private bool IsOkLogData
        {
            get
            {
                var rows = ZumbachData.Select("Position = " + position + " AND Bag = " + Measurement);

                if (rows.Length > 0)
                    return false;
                return true;
            }
        }
        private bool IsSaved;
        private readonly bool[] IsPositionDiscarded = new bool[3];
       
       


        public MeasureWithZumbach(Screen pos)
        {
            InitializeComponent();
            serialPort = new SerialPort();
            pbar = new ProgressBar { Location = pos.Bounds.Location };

            Translate_Form();

            pbar.Show();

            print_Chart.PrintPage += Print_Chart_PrintPage;
            preview_Chart.Document = print_Chart;
            print_Chart.DefaultPageSettings.Landscape = true;

            SetChartLimits();
            
            Load_COM_Settings();

            position = 1;
            pbar.Set_ValueProgressBar(30, LanguageManager.GetString("zumbach_Info_3"));
            Initialize_Chart();

            InitializeGUI_Befattning();


            Load_Data();
            Measurement = Zumbach.DataTable_Measurements.Rows.Count > 0 ? Zumbach.DataTable_Measurements.Rows.Count : 1;
            pbar.Close();
        }
        private void MeasureWithZumbachLoad(object sender, EventArgs e)
        {
            Initialize_GUI_Switch_Position(true);

            LoadData_Bag(false);
            Initialize_GUI();
            InitializeChart_Påse();

            Refresh();

            WindowState = FormWindowState.Normal;
        }

        private void Translate_Form()
        {
            Control[] controls = { chb_LogData, label_Measurement, btn_DeleteSelectedData, btn_DiscardMeasurement, btn_GetDataOrder, btn_GetDataPartNr, btn_PrintZumbach, chb_AutoPosByte };
            LanguageManager.TranslationHelper.TranslateControls(controls);

            chb_VisaPos1.Text = chb_VisaPos2.Text = chb_VisaPos3.Text = LanguageManager.GetString("zumbach_ShowPosition");
        }
        private void Load_COM_Settings()
        {
            var settings = ZumbachSettings.LoadComSettings();
            serialPort.PortName = settings.Portname;
            serialPort.BaudRate = settings.Baudrate;
            serialPort.DataBits = settings.DataBits;
            serialPort.StopBits = settings.Stopbits;
            serialPort.Parity = Parity.Even;
            serialPort.Handshake = settings.Handshake;
            DeleteMeasurements = settings.DeleteMeasurements;
            zumbachMessage = settings.Message;
        }
        public void Load_Data()
        {
            Load_ZumbachData();
           
            Zumbach.Load_DataTable_Measurements(pbar);
        }





        //--------- LOAD DATA ----------------------------------------------
        public void LoadData_Bag(bool IsOkBlinkControlsAreDiscarded)
        {
            DrawingControl.SuspendDrawing(this);    //Denna rad behöver vara kvar, annars laddas hela mätningen om punkt för punkt efter varje mätning
            ClearAllDataChart();

            IsPositionDiscarded[0] = false;
            IsPositionDiscarded[1] = false;
            IsPositionDiscarded[2] = false;
            if (chartZumbach.Series.Count < 3)
                return;

            Measurement = int.Parse(lbl_Measurement.Text);
            var row = ZumbachData?.Select($"Bag = '{Measurement}'");

            int ctr = 0;
            int? previousSerie = null;
            foreach (var t in row)
            {
                var serie = int.Parse(t["Position"].ToString()) - 1;
                // Nollställ ctr om serien bytt
                if (previousSerie != null && previousSerie != serie)
                    ctr = 0;

                double.TryParse(t["OD"].ToString(), out var od);
                bool.TryParse(t["Discarded"].ToString(), out var is_Kasserad);
                
                Print_OD_Chart(od, serie, ctr, Measurement);
                ctr++;
                previousSerie = serie; // spara senaste serie

                var datetime = t["DateTime"].ToString();
                switch (serie)
                {
                    case 0:
                        label_DateTimeMeasurement_Pos1.Text = datetime;
                        break;
                    case 1:
                        label_DateTimeMeasurement_Pos2.Text = datetime;
                        break;
                    case 2:
                        label_DateTimeMeasurement_Pos3.Text = datetime;
                        break;
                }
                if (chb_Sortera_Bort_Kasserade.Checked && is_Kasserad)
                {
                    for (var ii = 0; ii < 3; ii++)
                        if (serie == ii)
                            IsPositionDiscarded[ii] = true;
                }

            }


            if (IsOkBlinkControlsAreDiscarded == false)
            {
                //Kollar om mätningen är Kasserad
                for (var i = 0; i < 3; i++)
                {
                    if (IsPositionDiscarded[i])
                    {
                        ControlValidator.SoftBlink(panel_Blink(i), Color.DarkOrange, Color.Transparent, 350, 50);    //Blinkar om position är Kasserad
                        if (chb_Sortera_Bort_Kasserade.Checked)
                            Clear_Serie(chartZumbach.Series[i]);
                    }
                }
            }
            if (ZumbachData.Rows.Count > 2)
                Calculate_Data();
            DrawingControl.ResumeDrawing(this);
        }
        private void LoadData_Order()
        {
            ClearAllDataChart();
            var bar = new ProgressBar();
            bar.Show();

            var query = chb_Sortera_Bort_Kasserade.Checked ? @"
        SELECT OD, data.Position, data.Bag 
        FROM Zumbach.Measurements as meas 
        JOIN Zumbach.Data as data
            ON data.OrderID = meas.OrderID AND data.Position = meas.Position AND data.Bag = meas.Bag
        WHERE meas.OrderID = @orderid AND meas.Discarded = 'False' 
        ORDER BY meas.DateTime, data.ID" : @"
        SELECT OD, data.Position, data.Bag 
        FROM Zumbach.Measurements as meas
        JOIN Zumbach.Data as data
            ON data.OrderID = meas.OrderID AND data.Position = meas.Position AND data.Bag = meas.Bag
        WHERE meas.OrderID = @orderid
        ORDER BY meas.DateTime, data.ID";

            int ctr = 0;
            int ctr_step = 10;
            int stepper = ZumbachData.Select("Discarded <> true").Length;
            int value = stepper / 90;

            bar.Set_ValueProgressBar(10, $"{LanguageManager.GetString("zumbachLoadData")}");

            List<(int x, int bag)> bagChangeX = new List<(int x, int bag)>();

            int? currentBag = null;
            int? currentPosition = null;
            int lastXforPosition = 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                var x = 0;
                while (reader.Read())
                {
                    var od = double.Parse(reader[0].ToString()!);
                    var pos = int.Parse(reader[1].ToString()!) - 1;
                    var bag = int.Parse(reader[2].ToString()!);
                    // Kontrollerar om ny bag börjar här
                    if (currentBag != bag)
                    {
                        bagChangeX.Add((x, bag)); // bara en gång per mätning
                        currentBag = bag;
                        lastXforPosition = x;
                        ctr++;

                    }
                    //Kontrollerar om en ny Position börjar här
                    if (pos != currentPosition)
                    {
                        x = lastXforPosition;
                        currentPosition = pos;
                    }
                    Print_OD_Chart(od, pos, x, bag); // x = mätpunktsindex
                    x++;
                   // if (pos == 2) // sista positionen, då ökar vi ctr
                   // {
                        //if (ctr % value == 0)
                        //{
                        //    ctr_step++;
                        //    bar.Set_ValueProgressBar(ctr_step, $"{LanguageManager.GetString("zumbachLoadData")}");
                        //}
                       // ctr++;
                  //  }
                }
                Add_AnnotationBagNr(bagChangeX);
            }

            bar.Close();
        }






        private void Add_AnnotationBagNr(List<(int x, int bag)> bagChangeX)
        {
            chartZumbach.ChartAreas[0].AxisX.CustomLabels.Clear();
            var ctr = bagChangeX.Count;
            var divider = 1;
            if (ctr > 30)
                divider = 5;
            foreach (var (x, bag) in bagChangeX.Skip(1).GroupBy(e => e.x).Select(g => g.First()))
            {
                if (bag % divider == 0)
                {
                    var annotation = new TextAnnotation
                    {
                        Text = $"{bag}",
                        Font = new Font("Arial", 9),
                        ForeColor = Color.Yellow,
                        AnchorX = x,
                        AnchorY = chartZumbach.ChartAreas[0].AxisY.Minimum,
                        AnchorAlignment = ContentAlignment.BottomCenter,
                        AxisX = chartZumbach.ChartAreas[0].AxisX,
                        AxisY = chartZumbach.ChartAreas[0].AxisY
                    };
                    chartZumbach.Annotations.Add(annotation);
                }
                
            }
        }
        private void LoadData_PartNr()
        {
            ClearAllDataChart();
            var point = new Point(0, 0);
            var progressBar = new ProgressBar();
            progressBar.Show();
            progressBar.Set_ValueProgressBar(0, "Laddar ner data från hela artikeln");

            var query = chb_Sortera_Bort_Kasserade.Checked ? @"
                    SELECT OD, data.Position, data.Bag, meas.OrderId
                    FROM Zumbach.Measurements as meas 
                    JOIN Zumbach.Data as data
                        ON data.OrderID = meas.OrderID AND data.Position = meas.Position AND data.Bag = meas.Bag
                    WHERE meas.OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartID = @partID) AND meas.Discarded = 'False' 
                    ORDER BY meas.DateTime, data.ID" : @"

                    SELECT OD, data.Position, data.Bag, meas.OrderId
                    FROM Zumbach.Measurements as meas 
                    JOIN Zumbach.Data as data
                        ON data.OrderID = meas.OrderID AND data.Position = meas.Position AND data.Bag = meas.Bag
                    WHERE meas.OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartID = @partID)  
                    ORDER BY meas.DateTime, data.ID";
            progressBar.Set_ValueProgressBar(10, "Laddar ner data från hela artikeln");
            var stepper = ZumbachData.Select("Discarded" + " <> true").Length;
            var value = stepper / 90;
            var ctr = 0;
            var ctr_step = 10;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var pos = int.Parse(reader[1].ToString()) - 1;
                    var OrderID = reader[2].ToString();
                    var od = double.Parse(reader[0].ToString());
                    chartZumbach.Series[pos].Points.AddXY(OrderID, od);
                    if (ctr % value == 0)
                    {
                        ctr_step++;
                        progressBar.Set_ValueProgressBar(ctr_step, "Laddar ner data från hela artikeln");
                    }
                    ctr++;
                }
            }
            progressBar.Close();
        }





        //--------------- PRINT --------------------------------------------------------------------------------------
        //private void PrintOut_Chart(object sender, PrintPageEventArgs e)
        //{
        //    // Spara originalstorlek
        //    var originalSize = chartZumbach.Size;

        //    try
        //    {
        //        // Sätt temporär storlek som matchar utskriftsytan
        //        chartZumbach.Size = new Size(1050, 650);

        //        // Rita chart till utskrift
        //        var rectangle_chart = new Rectangle(0, 194, 1050, 650);
        //        chartZumbach.Printing.PrintPaint(e.Graphics, rectangle_chart);

        //        // Rita ram runt
        //        e.Graphics.DrawRectangle(CustomFonts.thinBlack, 25, 194, 1040, 600);
        //    }
        //    finally
        //    {
        //        // Återställ originalstorlek efter utskrift
        //        chartZumbach.Size = originalSize;
        //    }
        //}

        private void PrintOut_Chart(object sender, PrintPageEventArgs e)
        {
            float scaleX = 1050f / chartZumbach.Width;
            float scaleY = 630f / chartZumbach.Height;

            var state = e.Graphics.Save();
            e.Graphics.TranslateTransform(0, 194);
            e.Graphics.ScaleTransform(scaleX, scaleY);

            chartZumbach.Printing.PrintPaint(e.Graphics, new Rectangle(0, 0, chartZumbach.Width, chartZumbach.Height));

            e.Graphics.Restore(state);

            e.Graphics.DrawRectangle(CustomFonts.thinBlack, 25, 194, 1040, 600);
        }
        private void Print_Chart_PrintPage(object sender, PrintPageEventArgs e)
        {
            _ = Log.Activity.Stop("Skriver ut Zumbachmätningar.");
            Print.utskrift_Korprotokoll = Print.List_PrintOut_Korprotokoll;
            Print_Protocol.totalPrintOuts = new PrintVariables.TotalPrintOuts();
            Print_Protocol.Set_DefaultPaperSize(print_Chart, true);
            PrintVariables.Active_PrintOut = 1;
            ((Form)preview_Chart).WindowState = FormWindowState.Maximized;


            Print_Protocol.PrintOut.PageHeader(e, LanguageManager.GetString("print_Header_ZumbachProtocol"), 1);
            Print_Protocol.PrintOut.Order_INFO(e);
            PrintOut_Chart(sender, e);
        }



        //---------------- CHANGE GUI ---------------------------------
        private void ChangeTheme()
        {
            SuspendLayout();
            MachineColor.Set_HeatShrink_Color();
            Change_BackColor(MachineColor.Theme_BackColor, panel_InfoZumbachChart);

            lbl_OrderNr.ForeColor = lbl_Maskin.ForeColor = btn_Jämna_Kurvor.ForeColor = chb_LogData.ForeColor = chb_AutoPosByte.ForeColor = chb_AutoMätByte.ForeColor = chb_Sortera_Bort_Kasserade.ForeColor = MachineColor.Theme_ForeColor;

            ResumeLayout();

            if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.ManufacturesHeatShrink) == false)
                Initailize_GUI_Extrudering();
        }
    
        private void Initialize_GUI()
        {
            // this.SuspendLayout();
            lbl_OrderNr.Text = Order.OrderNumber;
            lbl_Maskin.Text = Equipment.Equipment.HS_Machine;

            panel_Position1.BackColor = Color.FromArgb(120, Color.Black);
            label_Position1.BackColor = Color.FromArgb(120, Color.Black);
            rb_Position1.BackColor = Color.FromArgb(120, Color.Black);
            lbl_Pipe_1.BackColor = Color.FromArgb(120, Color.Black);

            lbl_Pipe_1.Text = Order.HS_Pipe_1;
            lbl_Pipe_2.Text = Order.HS_Pipe_2;
            lbl_Pipe_3.Text = Order.HS_Pipe_3;
            chartZumbach.BackColor = Color.FromArgb(220, Color.Black);
            ChangeTheme();
            //  this.ResumeLayout();
        }
        private void Initailize_GUI_Extrudering()
        {
            Change_BackColor(Color.White, panel_InfoZumbachChart);
            // chartZumbach.BackColor = Color.White;
            lbl_OrderNr.ForeColor = Color.Black;
            lbl_Maskin.ForeColor = Color.Black;
            btn_Jämna_Kurvor.ForeColor = Color.Black;
        }

        private void SetChartLimits()
        {
            ExpOD_USL = MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpOD, "USL");
            ExpOD_LSL = MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpOD, "LSL");

            ExpOD_UCL = MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpOD, "UCL");
            ExpOD_LCL = MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpOD, "LCL");

            if (Monitor.Monitor.status == Monitor.Monitor.Status.Bad || ExpOD_LSL == 0 || ExpOD_LSL is null)
            {
                InfoText.Show(LanguageManager.GetString("missingMeasurePoints"), CustomColors.InfoText_Color.Warning, "Warning!", this);

                var addMeasurePoints = new AddMeasurePointsManually();
                addMeasurePoints.ShowDialog();
            }
        }

        private void Initialize_GUI_Switch_Position(bool is_Ok_Change_GUI)
        {
            if (!is_Ok_Change_GUI)
                return;

            var positions = new[]
            {
                new { Panel = panel_Position1, Label = label_Position1, RadioButton = rb_Position1, PipeLabel = lbl_Pipe_1, Max = lbl_1Max, Avg = lbl_1Avg, Min = lbl_1Min, HiLo = lbl_1HiLo },
                new { Panel = panel_Position2, Label = label_Position2, RadioButton = rb_Position2, PipeLabel = lbl_Pipe_2, Max = lbl_2Max, Avg = lbl_2Avg, Min = lbl_2Min, HiLo = lbl_2HiLo },
                new { Panel = panel_Position3, Label = label_Position3, RadioButton = rb_Position3, PipeLabel = lbl_Pipe_3, Max = lbl_3Max, Avg = lbl_3Avg, Min = lbl_3Min, HiLo = lbl_3HiLo }
            };

            for (int i = 0; i < positions.Length; i++)
            {
                bool isSelected = i == position - 1;

                var backColor = isSelected ? Color.FromArgb(120, Color.Black) : Color.Transparent;
                var borderStyle = isSelected ? BorderStyle.Fixed3D : BorderStyle.None;

                var pos = positions[i];

                // BackColor on first 4 controls
                var controlsToColor = new Control[] { pos.Panel, pos.Label, pos.RadioButton, pos.PipeLabel };
                foreach (var ctrl in controlsToColor)
                {
                    ctrl.BackColor = backColor;
                }

                // BorderStyle on panel
                pos.Panel.BorderStyle = borderStyle;

                // RadioButton check state
                pos.RadioButton.Checked = isSelected;
            }
        }

        private void InitializeGUI_Befattning()
        {
            if (Person.Role == "SuperAdmin")
            {
                chb_Sortera_Bort_Kasserade.Visible = true;
                btn_Jämna_Kurvor.Visible = true;
            }
            btn_DeleteSelectedData.Visible =
                CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.DeleteSelectedDataZumbach, false);

            if (string.IsNullOrEmpty(Person.Role))
            {
                chb_LogData.Enabled = false;
                btn_DeleteSelectedData.Enabled = false;
                btn_DiscardMeasurement.Enabled = false;
                btn_Jämna_Kurvor.Enabled = false;
                rb_Position1.Enabled = false;
                rb_Position2.Enabled = false;
                rb_Position3.Enabled = false;
            }
        }

        private void Switch_Position()
        {
            if (rb_Position1.Checked)
            {
                Position_Click(rb_Position2, null);
                rb_Position2.Checked = true;
                position = 2;
                stack = 0;
                Initialize_GUI_Switch_Position(true);
            }
            else if (rb_Position2.Checked)
            {
                Position_Click(rb_Position3, null);
                rb_Position3.Checked = true;
                position = 3;
                stack = 0;
                Initialize_GUI_Switch_Position(true);
            }
            else if (rb_Position3.Checked)
            {
                Position_Click(rb_Position1, null);
                rb_Position1.Checked = true;
                position = 1;
                stack = 0;
                Initialize_GUI_Switch_Position(true);
                if (chb_AutoMätByte.Checked)
                    btn_Up.PerformClick();
            }
        }

        private static void Change_BackColor(Color clr, Control ctrl)
        {
            ctrl.Invoke(new Action<Color, Control>(DoInvoke_change_Color), clr, ctrl);
        }
        private static void DoInvoke_change_Color(Color clr, Control ctrl)
        {
            ctrl.BackColor = clr;
        }


        //------------- INITIALIZE CHART-----------------------------------
        private void InitializeChart_Logging()
        {
            chartZumbach.ChartAreas[0].AxisX.Title = "Time";
        }
        private void InitializeChart_Order()
        {
            chartZumbach.ChartAreas[0].AxisX.Title = "Measurement";
            chartZumbach.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chartZumbach.ChartAreas[0].AxisX.ScaleView.Zoom(1, 500);
        }
        private void InitializeChart_ArtikelNr()
        {
            chartZumbach.ChartAreas[0].AxisX.Title = "PartNumber";
            chartZumbach.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chartZumbach.ChartAreas[0].AxisX.ScaleView.Zoom(1, 500);
        }
        private void InitializeChart_Påse()
        {
            chartZumbach.ChartAreas[0].AxisX.Title = "Length";
            chartZumbach.ChartAreas[0].AxisY.LabelStyle.Format = "0.00";
        }
        private void InitializeChart_Utskrift()
        {
            var chA2 = new ChartArea { Name = "ChartArea2" };
            var chA3 = new ChartArea { Name = "ChartArea3" };
            chartZumbach.ChartAreas.Add(chA2);
            chartZumbach.ChartAreas.Add(chA3);

            var slMax1 = new StripLine { BorderColor = Color.Red, BorderWidth = 2, Text = "USL", ForeColor = Color.Red };
            var slMax2 = new StripLine { BorderColor = Color.Red, BorderWidth = 2, Text = "USL", ForeColor = Color.Red };
            var slMin1 = new StripLine { BorderColor = Color.Red, BorderWidth = 2, Text = "LSL", ForeColor = Color.Red };
            var slMin2 = new StripLine { BorderColor = Color.Red, BorderWidth = 2, Text = "LSL", ForeColor = Color.Red };

            slMax1.IntervalOffset = slMax2.IntervalOffset = StripLine_USL.IntervalOffset;
            slMin1.IntervalOffset = slMin2.IntervalOffset = StripLine_LSL.IntervalOffset;

            chartZumbach.BackColor = Color.White;

            chartZumbach.Series[1].ChartArea = "ChartArea2";
            chartZumbach.Series[2].ChartArea = "ChartArea3";

            chartZumbach.Series[1].Color = Color.White;
            chartZumbach.Series[2].Color = Color.Lime;

            for (var i = 0; i < 3; i++)
            {
                var area = chartZumbach.ChartAreas[i];
                chartZumbach.Series[i].Color = Color.Black;
                area.BackColor = Color.Transparent;
                //area.AxisX.Title = "Measurement";
                //area.AxisX.TitleForeColor = Color.Black;
                //area.AxisX.TitleFont = new Font("Segoe UI", 14);
                area.AxisY.Title = "OD - Position " + (i + 1);
                area.AxisY.TitleForeColor = Color.Black;
                area.AxisY.TitleFont = new Font("Segoe UI", 10);
                area.AxisY.TextOrientation = TextOrientation.Horizontal;
                area.AxisX.LineColor = Color.Black;
                area.AxisY.LineColor = Color.Black;
                area.AxisX.ScrollBar.Enabled = false;
                area.AxisY.LabelStyle.Format = "0.00";
                area.AxisY.Interval = 0.02;
                area.AxisY.Maximum = chartZumbach.ChartAreas[0].AxisY.Maximum;
                area.AxisY.Minimum = chartZumbach.ChartAreas[0].AxisY.Minimum;
                area.AxisX.MajorGrid.LineColor = Color.Gray;
                //area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
                area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
               // area.AxisX.LabelStyle.ForeColor = Color.Black;
                area.AxisY.LabelStyle.ForeColor = Color.Black;
                area.AxisX.LabelStyle.Format = " ";
            }

            if (ExpOD_USL == 0)
            {
                chartZumbach.ChartAreas[0].AxisY.StripLines.Add(StripLine_LSL);
                chartZumbach.ChartAreas[1].AxisY.StripLines.Add(slMin1);
                chartZumbach.ChartAreas[2].AxisY.StripLines.Add(slMin2);
            }
            else
            {
                chartZumbach.ChartAreas[0].AxisY.StripLines.Add(StripLine_LSL);
                chartZumbach.ChartAreas[0].AxisY.StripLines.Add(StripLine_USL);
                chartZumbach.ChartAreas[1].AxisY.StripLines.Add(slMin1);
                chartZumbach.ChartAreas[1].AxisY.StripLines.Add(slMax1);
                chartZumbach.ChartAreas[2].AxisY.StripLines.Add(slMin2);
                chartZumbach.ChartAreas[2].AxisY.StripLines.Add(slMax2);
            }

            // Sätt färg och font på befintliga text-annotations
            foreach (var annotation in chartZumbach.Annotations.OfType<TextAnnotation>())
            {
                annotation.ForeColor = Color.Black;
                annotation.Font = new Font("Arial", 5);
            }
        }



        private void Initialize_Chart()
        {
            panel_Position2.BorderStyle = BorderStyle.None;
            panel_Position3.BorderStyle = BorderStyle.None;
            chartZumbach.Series[0].Points.Clear();
            chartZumbach.Series[1].Points.Clear();
            chartZumbach.Series[2].Points.Clear();

            StripLine_USL.BorderColor = Color.Red;
            StripLine_LSL.BorderColor = Color.Red;
            StripLine_UCL.BorderColor = Color.DarkOrange;
            StripLine_LCL.BorderColor = Color.DarkOrange;

            StripLine_USL.BorderWidth = 2;
            StripLine_LSL.BorderWidth = 2;
            StripLine_UCL.BorderWidth = 2;
            StripLine_LCL.BorderWidth = 2;

            if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.ManufacturesHeatShrink))
                Initialize_Chart_HeatShrink();
            else
                Initialize_Chart_Extrusion();

            StripLine_USL.ForeColor = Color.Red;
            StripLine_LSL.ForeColor = Color.Red;
            StripLine_UCL.ForeColor = Color.DarkOrange;
            StripLine_LCL.ForeColor = Color.DarkOrange;

            chartZumbach.ChartAreas[0].AxisY.Interval = 0.02;
        }
        private void Initialize_Chart_Extrusion()
        {
            if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "USL") == 0)
            {
                if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM") != null)
                    chartZumbach.ChartAreas[0].AxisY.Maximum = (double)MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM") + 0.08;
            }
            else if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "USL") != null) chartZumbach.ChartAreas[0].AxisY.Maximum = (double)MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "USL") + 0.05;

            if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "LSL") == 0)
            {
                if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM") != null) chartZumbach.ChartAreas[0].AxisY.Minimum = (double)MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM") - 0.08;
            }
            else if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "LSL") != null) chartZumbach.ChartAreas[0].AxisY.Minimum = (double)MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "LSL") - 0.05;

            if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "USL") > 0)
                StripLine_USL.IntervalOffset = (double)MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "USL");
            else if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM") != null)
                StripLine_USL.IntervalOffset = (double)MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM") + 0.03;

            if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "LSL") > 0)
                StripLine_LSL.IntervalOffset = (double)MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "LSL");
            else if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM") != null)
                StripLine_LSL.IntervalOffset = (double)MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM") - 0.03;

            StripLine_USL.Text = "USL-" + MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "USL");
            StripLine_LSL.Text = "LSL-" + MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "LSL");



            chartZumbach.ChartAreas[0].AxisY.StripLines.Add(StripLine_LSL);
            chartZumbach.ChartAreas[0].AxisY.StripLines.Add(StripLine_USL);
        }
        private void Initialize_Chart_HeatShrink()
        {

            if (ExpOD_USL== 0)
                chartZumbach.ChartAreas[0].AxisY.Maximum = double.NaN;
            else
            {
                if (ExpOD_USL != null)
                    chartZumbach.ChartAreas[0].AxisY.Maximum = (double)ExpOD_USL + 0.05;
            }

            if (ExpOD_LSL != null)
            {
                chartZumbach.ChartAreas[0].AxisY.Minimum = (double)ExpOD_LSL - 0.05;

                if (ExpOD_USL > 0)
                    StripLine_USL.IntervalOffset = (double)ExpOD_USL; // max;
                else
                    StripLine_USL.IntervalOffset = double.MaxValue;
                    

                StripLine_LSL.IntervalOffset = (double)ExpOD_LSL; // min;
                StripLine_USL.Text = "USL-" + ExpOD_USL;
                StripLine_LSL.Text = "LSL-" + ExpOD_LSL;
            }

            if (ExpOD_LCL > 0)
            {
                StripLine_LCL.IntervalOffset = (double)ExpOD_LCL;
                chartZumbach.ChartAreas[0].AxisY.StripLines.Add(StripLine_LCL);
                StripLine_LCL.Text = "LCL-" + ExpOD_LCL;
            }

            if (ExpOD_UCL > 0)
            {
                StripLine_UCL.IntervalOffset = (double)ExpOD_UCL;
                chartZumbach.ChartAreas[0].AxisY.StripLines.Add(StripLine_UCL);
                StripLine_UCL.Text = "UCL-" + ExpOD_UCL;
            }

            if (ExpOD_USL == 0)
                chartZumbach.ChartAreas[0].AxisY.StripLines.Add(StripLine_LSL);
            else
            {
                chartZumbach.ChartAreas[0].AxisY.StripLines.Add(StripLine_LSL);
                chartZumbach.ChartAreas[0].AxisY.StripLines.Add(StripLine_USL);
            }
        }

        private void Calculate_Data()
        {
            Label[] lbl_Max = { lbl_1Max, lbl_2Max, lbl_3Max };
            Label[] lbl_Avg = { lbl_1Avg, lbl_2Avg, lbl_3Avg };
            Label[] lbl_Min = { lbl_1Min, lbl_2Min, lbl_3Min };
            Label[] lbl_HiLo = { lbl_1HiLo, lbl_2HiLo, lbl_3HiLo };
            Label[] lbl_Cpk = { lbl_1Cpk, lbl_2Cpk, lbl_3Cpk };
            Label[] lbl_Date = { label_DateTimeMeasurement_Pos1, label_DateTimeMeasurement_Pos2, label_DateTimeMeasurement_Pos3 };

            var orgPos = position;
            rb_Position1.Click -= Position_Click!;
            rb_Position2.Click -= Position_Click!;
            rb_Position3.Click -= Position_Click!;
            for (var i = 0; i < 3; i++)
            {
                position = i + 1;
                Initialize_GUI_Switch_Position(false);

                Print_Date(lbl_Date[i]);
                Print_MAX_OD(lbl_Max[i]);
                Print_AVG_OD(lbl_Avg[i]);
                Print_MIN_OD(lbl_Min[i]);
                Print_Hi_Lo(lbl_HiLo[i], lbl_Max[i], lbl_Min[i]);
                Print_Cpk(lbl_Cpk[i], i);
            }
            position = orgPos;
            Initialize_GUI_Switch_Position(false);

            rb_Position1.Click += Position_Click!;
            rb_Position2.Click += Position_Click!;
            rb_Position3.Click += Position_Click!;
        }


        private void Chart_Zumbach_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chartZumbach.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

            foreach (var result in results)
            {
                if (result.ChartElementType != ChartElementType.DataPoint)
                    continue;
                if (!(result.Object is DataPoint prop))
                    continue;
                if (ExpOD_LSL != null)
                    tooltip.Show("OD = " + prop.YValues[0] + Environment.NewLine + "OD-LSL = " + $"{prop.YValues[0] - (double)ExpOD_LSL:0.000}", chartZumbach, pos.X + 15, pos.Y - 15);
            }
        }
        private void Chart_Zumbach_AxisViewChanged(object sender, ViewEventArgs e)
        {
            //Detta aktiverar den minsta serien(lägst medelvärde)

            var min_Chart = (int)chartZumbach.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            var max_Chart = (int)chartZumbach.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            var min_Pos1 = Calculate.Diagram.min_Value(chartZumbach, 0, min_Chart, max_Chart);
            var min_Pos2 = Calculate.Diagram.min_Value(chartZumbach, 1, min_Chart, max_Chart);
            var min_Pos3 = Calculate.Diagram.min_Value(chartZumbach, 2, min_Chart, max_Chart);

            switch (Calculate.Diagram.min_Serie(min_Pos1, min_Pos2, min_Pos3))
            {
                case 1:
                    rb_Position1.PerformClick();
                    break;
                case 2:
                    rb_Position2.PerformClick();
                    break;
                case 3:
                    rb_Position3.PerformClick();
                    break;

            }
        }





        //------- PRINT DATA - CHANGE TEXTBOXES ETC -------------------------
        private void Print_Date(Label lbl_Date)
        {
            var row = ZumbachData.Select($"Bag = '{Measurement}'");
            //Lägger till data i chart
            foreach (var t in row)
            {
                var serie = int.Parse(t["Position"].ToString()) - 1;
                var datetime = t["DateTime"].ToString();
                switch (serie)
                {
                    case 0:
                        Invoke_Date(label_DateTimeMeasurement_Pos1, datetime);
                        //label_DateTimeMeasurement_Pos1.Text = datetime;
                        break;
                    case 1:
                        Invoke_Date(label_DateTimeMeasurement_Pos2, datetime);
                        //label_DateTimeMeasurement_Pos2.Text = datetime;
                        break;
                    case 2:
                        Invoke_Date(label_DateTimeMeasurement_Pos3, datetime);
                        //label_DateTimeMeasurement_Pos3.Text = datetime;
                        break;
                }
            }
        }
        private void Print_OD_Chart(double od, int pos, int x, int bag)
        {
            chartZumbach.Invoke(new Action<double, int, int, int >(Invoke_print_OD_chart), od, pos, x, bag);
        }
        private void Print_OD(double _strPrint)
        {
            lbl_OD.Invoke(new Action(() => lbl_OD.Text = $"{_strPrint:0.000}"));
        }
        private void Print_MAX_OD(Label lbl)
        {
            lbl.Invoke(new Action<Label>(Invoke_MAX_OD), lbl);
        }
        private void Print_AVG_OD(Label lbl)
        {
            lbl.Invoke(new Action<Label>(Invoke_AVG_OD), lbl);
        }
        private void Print_MIN_OD(Label lbl)
        {
            lbl.Invoke(new Action<Label>(Invoke_MIN_OD), lbl);
        }
        private void Print_Hi_Lo(Label lbl, Label lbl_Max, Label lbl_Min)
        {
            try
            {
                lbl.Invoke(new Action<Label, Label, Label>(Invoke_Hi_Lo), lbl, lbl_Max, lbl_Min);
            }
            catch { Debug.WriteLine("print_Hi_Lo"); }
        }
        private void Print_Cpk(Label lbl, int position)
        {
            lbl.Invoke(new Action<Label, int>(Invoke_Cpk), lbl, position);
        }

        private void Clear_Serie(Series serie)
        {
            try
            {
                chartZumbach.Invoke(new Action(() => serie.Points.Clear()));
            }
            catch { Debug.WriteLine("Clear Serie"); }
        }

        private void Invoke_MAX_OD(Label lbl)
        {
            var max = double.MinValue;

            if (chartZumbach.Series[position - 1].Points.Count > 0)
            {
                double.TryParse(chartZumbach.Series[position - 1].Points.FindMaxByValue().YValues[0].ToString(), out var od);
                max = Math.Max(max, od);
                lbl.Text = $"{max:0.000}";
            }
            else
                lbl.Text = "N/A";
        }
        private void Invoke_AVG_OD(Label lbl)
        {
            var serie = string.Empty;
            if (position == 1)
                serie = "Pos1";
            if (position == 2)
                serie = "Pos2";
            if (position == 3)
                serie = "Pos3";
            if (chartZumbach.Series[position - 1].Points.Count > 0)
            {
                var avg = chartZumbach.DataManipulator.Statistics.Mean(serie);
                lbl.Text = $"{avg:0.000}";
            }
            else
                lbl.Text = "N/A";
        }
        private void Invoke_MIN_OD(Label lbl)
        {
            var min = double.MaxValue;
            if (chartZumbach.Series[position - 1].Points.Count > 0)
            {
                double.TryParse(chartZumbach.Series[position - 1].Points.FindMinByValue().YValues[0].ToString(), out var od);
                min = Math.Min(min, od);
                lbl.Text = $"{min:0.000}";
            }
            else
                lbl.Text = "N/A";
        }
        private void Invoke_Hi_Lo(Label lbl, Label lbl_Max, Label lbl_Min)
        {
            if (double.TryParse(lbl_Max.Text, out var max) && double.TryParse(lbl_Min.Text, out var min))
                lbl.Text = $"{max - min:0.000}";
            else
                lbl.Text = "N/A";

        }

        private void Invoke_Date(Label label, string text)
        {
            if (label.InvokeRequired)
                label.Invoke(new Action(() => label.Text = text));
            else
                label.Text = text;
        }
        private void Invoke_Cpk(Label lbl, int position)
        {
            var list = chartZumbach.Series[position].Points.Select(dataPoint => dataPoint.YValues[0]).Select(dummy => (double?)dummy).ToList();
            lbl.Text = Calculate.Cpk(list, ExpOD_USL, ExpOD_LSL).ToString();
        }

        private void Invoke_print_OD_chart(double od, int pos, int x, int bag)
        {
            SuspendLayout();
            var pointIndex = chartZumbach.Series[pos].Points.AddXY(x, od);
            chartZumbach.Series[pos].Points[pointIndex].ToolTip = $"Bag {bag}, OD: {od:0.000}";
            ResumeLayout();
        }



        private void ClearAllDataChart()
        {
            foreach (var serie in chartZumbach.Series)
                Clear_Serie(serie);
            lbl_1Max.Text = string.Empty;
            lbl_1Avg.Text = string.Empty;
            lbl_1Min.Text = string.Empty;
            lbl_1HiLo.Text = string.Empty;
            lbl_2Max.Text = string.Empty;
            lbl_2Avg.Text = string.Empty;
            lbl_2Min.Text = string.Empty;
            lbl_2HiLo.Text = string.Empty;
            lbl_3Max.Text = string.Empty;
            lbl_3Avg.Text = string.Empty;
            lbl_3Min.Text = string.Empty;
            lbl_3HiLo.Text = string.Empty;
            lbl_1Cpk.Text = string.Empty;
            lbl_2Cpk.Text = string.Empty;
            lbl_3Cpk.Text = string.Empty;
            label_DateTimeMeasurement_Pos1.Text = string.Empty;
            label_DateTimeMeasurement_Pos2.Text = string.Empty;
            label_DateTimeMeasurement_Pos3.Text = string.Empty;
        }





        //------------------- ZUMBACH -------------------------------
        private double OD
        {
            get
            {
                var culture = CultureInfo.InvariantCulture;
                serialPort.WriteLine(zumbachMessage + "\r");
                var receiveData = serialPort.ReadLine();
                receiveData = receiveData.Remove(0, zumbachMessage.Length + 1);
                receiveData = receiveData.Substring(0, 6);
                double.TryParse(receiveData, NumberStyles.Any, culture, out var od);
                return od;


                //if (double.TryParse(receiveData, out var od))
                //    return od;
                //receiveData = receiveData.Replace(".", ",");
                //double.TryParse(receiveData, out od);
                //return od;
            }
        }
        private static int ctr_RndOD;
        static double GenerateRandomOD(int minValue, int maxValue)
        {
            var randomBytes = new byte[4];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(randomBytes);

            var randomValue = BitConverter.ToInt32(randomBytes, 0);

            return Math.Abs(randomValue % (maxValue - minValue + 1)) + minValue;
        }
        private static double Rnd_OD
        {
            get
            {
                var min = (int)(ExpOD_LSL * 1000) + 5;
                var max = min + 15;

                var od = GenerateRandomOD(min, max);


                ctr_RndOD++;
                if (ctr_RndOD > 300)
                    return 0;
                return od / 1000;

            }
        }

        private void CheckBox_LogData_CheckedChanged(object sender, EventArgs e)
        {
            Order.Set_IsOrderDone();
            if (Order.IsOrderDone)
            {
                InfoText.Show(LanguageManager.GetString("zumbach_Info_12"), CustomColors.InfoText_Color.Bad, "Warning!", this);
                chb_LogData.Enabled = false;
                return;
            }
            InitializeChart_Logging();

            if (chb_LogData.Checked)
            {
                if (Person.IsUserSignedIn(false))
                    StartLogData();
                else
                {
                    InfoText.Show(LanguageManager.GetString("zumbach_Info_13"), CustomColors.InfoText_Color.Warning, "Warning!", this);
                    Close();
                }
            }
            else
            {
                IsLogging = false;
                StopLogData();
            }
        }
        private void OpenSerialPort(ref bool IsPortOpen)
        {
            if (!serialPort.IsOpen)
            {
                try
                {
                    if (!SerialPort.GetPortNames().Contains(serialPort.PortName))
                    {
                        IsPortOpen = false;
                        InfoText.Show($"This COM-port {serialPort.PortName} does not exist on this computer, please contact Admin.", CustomColors.InfoText_Color.Bad, "Error:");
                        return;
                    }

                    serialPort.Open();
                    IsPortOpen = true;
                }
                catch (Exception exc)
                {
                    IsPortOpen = false;
                    InfoText.Show($"{exc.Message}", CustomColors.InfoText_Color.Bad, "Fel:");
                }
            }

        }
        private void StartLogData()
        {
            if (IsOkLogData == false)
            {
                IsSaved = true;
                chb_LogData.Checked = false;
                InfoText.Show(LanguageManager.GetString("zumbach_Info_5"), CustomColors.InfoText_Color.Warning, "Warning!");
                return;
            }
            Points.Add_Points(1, "Loggar ZumbachData");
            startRow = ZumbachData.Rows.Count;

            panel_InfoZumbachChart.BackColor = Color.FromArgb(255, 1, 50, 1);


            Refresh();
            chb_LogData.CheckedChanged -= CheckBox_LogData_CheckedChanged;
            chb_LogData.Checked = true;
            chb_LogData.CheckedChanged += CheckBox_LogData_CheckedChanged;

            IsLogging = true;
            var IsPortOpen = true;
            OpenSerialPort(ref IsPortOpen);


            if (IsPortOpen)
            {
                IsSaved = false;
                bgw_Zumbach.RunWorkerAsync();
            }
            else if (Person.Role == "SuperAdmin")
            {
                IsSaved = false;
                bgw_Random.RunWorkerAsync();
            }
            else
                chb_LogData.Checked = false;
        }
        private void StopLogData()
        {
            //this.SuspendLayout();
            chb_LogData.CheckedChanged -= CheckBox_LogData_CheckedChanged;
            chb_LogData.Invoke(new Action(() => chb_LogData.Checked = false));
            chb_LogData.CheckedChanged += CheckBox_LogData_CheckedChanged;

            serialPort.Close();
            bgw_Zumbach.CancelAsync();
            bgw_Zumbach.Dispose();
            bgw_Random.CancelAsync();
            bgw_Random.Dispose();
            ctr_RndOD = 0;

            if (ZumbachData.Rows.Count - startRow > 10 && IsSaved == false)
            {
                IsSaved = true;
                SortOut_BadData_Zumbach();

                if (ZumbachData.Rows.Count - startRow < 50)
                {
                    InfoText.Question($"{LanguageManager.GetString("zumbach_Info_6_1")} {ZumbachData.Rows.Count - startRow} {LanguageManager.GetString("zumbach_Info_6_2")}\n{LanguageManager.GetString("zumbach_Info_6_3")}", CustomColors.InfoText_Color.Warning, "Warning!", this);
                    if (InfoText.answer == InfoText.Answer.Yes)
                    {
                        Save_ZumbachData.INSERT_Measurement((byte)Measurement, (byte)position);
                        for (var i = startRow; i < ZumbachData.Rows.Count - DeleteMeasurements; i++)
                            Save_ZumbachData.INSERT_Data(double.Parse(ZumbachData.Rows[i]["OD"].ToString()), position, Measurement);
                    }
                }
                else
                {

                    Save_ZumbachData.INSERT_Measurement((byte)Measurement, (byte)position);
                    for (var i = startRow; i < ZumbachData.Rows.Count - DeleteMeasurements; i++)
                        Save_ZumbachData.INSERT_Data(double.Parse(ZumbachData.Rows[i]["OD"].ToString()), position, Measurement);
                }

                if (chb_AutoPosByte.Checked)
                    Switch_Position();

                Load_Data();
                ctr_AutoLogOFF = 0;
            }

            Task.Factory.StartNew(ChangeTheme);

            Calculate_Data();
            _ = Log.Activity.Stop("Loggar data Zumbach:");
        }
        private void SortOut_BadData_Zumbach()
        {
            //Sorterar bort 5 första samt 15 sista värden pga ofta felaktiga
            for (var i = startRow + 5; i > startRow; i--)
            {
                var dr = ZumbachData.Rows[i];
                dr.Delete();
            }
            for (var i = 0; i < 10; i++)
            {
                var dr = ZumbachData.Rows[ZumbachData.Rows.Count - 1];
                dr.Delete();
            }
        }

        private void bgw_Zumbach_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                var od = OD;

                Print_OD(od);

                if (IsOD_Ok(od))
                {
                    ZumbachData.Rows.Add(Order.OrderID, od, position, Measurement, false, stack);
                    ctr_AutoLogOFF = 0;
                    Print_OD_Chart(od, position - 1, stack, Measurement);

                    stack++;
                    Thread.Sleep(50);
                }
                if (od == 0.0)
                    ctr_AutoLogOFF++;
                if (ctr_AutoLogOFF > 60)
                {
                    IsLogging = false;
                    StopLogData();
                }
            }
            while (IsLogging); //flagBackgroundWorker
        }
        private void bgw_GetRandomValues(object sender, DoWorkEventArgs e)
        {
            var ctr = 0;
            do
            {
                double od;
                ctr++;
                if (ctr == 300)
                    od = 0;
                else
                    od = Rnd_OD;

                Print_OD(od);

                if (IsOD_Ok(od))
                {
                    ZumbachData.Rows.Add(Order.OrderID, od, position, Measurement, false, stack);
                    ctr_AutoLogOFF = 0;
                    Print_OD_Chart(od, position - 1, stack, Measurement);

                    stack++;
                    Thread.Sleep(50);
                }
                if (od == 0.0)
                    ctr_AutoLogOFF++;
                if (ctr_AutoLogOFF > 60)
                {
                    IsLogging = false;
                    StopLogData();
                }
            }
            while (IsLogging); //flagBackgroundWorker
        }





        //------------------btn-Clicks-------------------------------------------
        private void UP_Full_Click(object sender, EventArgs e)
        {
            if (Zumbach.DataTable_Measurements.Rows.Count > 0)
                lbl_Measurement.Text = Zumbach.DataTable_Measurements.Rows[Zumbach.DataTable_Measurements.Rows.Count - 1]["Bag"].ToString();
            Measurement = int.Parse(lbl_Measurement.Text);
        }
        private void Down_Full_Click(object sender, EventArgs e)
        {
            if (Zumbach.DataTable_Measurements.Rows.Count > 0)
                lbl_Measurement.Text = "1";
            Measurement = int.Parse(lbl_Measurement.Text);
        }
        private void Up_Down_MouseDown(object sender, MouseEventArgs? e)
        {
            var step = e.Button == MouseButtons.Right ? 10 : 1;
            var name = ((Button)sender).Name;
            Measurement = int.Parse(lbl_Measurement.Text);
            Change_Measurement(step, name, e);

        }
        public void Change_Measurement(int step, string name, MouseEventArgs? e)
        {
            switch (name)
            {
                case "btn_Up":
                    Measurement += step;
                    break;
                case "btn_Down" when step > 1:
                {
                    if (Measurement < 11)
                        Measurement -= 1;
                    else
                        Measurement -= step;
                    break;
                }
                case "btn_Down" when Measurement > 10:
                    Measurement -= step;
                    break;
                case "btn_Down":
                {
                    if (Measurement > 1)
                        Measurement -= 1;
                    break;
                }
            }

            if (TuningZumbachMeasurements.IsTuningCharts == false)
            {
               
                if (IsSeriesEmpty == false && IsSeriesContainsValues == false && int.Parse(lbl_Measurement.Text) > Zumbach.DataTable_Measurements.Rows.Count)
                {
                    InfoText.Question(LanguageManager.GetString("zumbach_Info_7"), CustomColors.InfoText_Color.Info, "Warning!", this);
                    if (InfoText.answer == InfoText.Answer.No)
                        return;
                }
            }
            stack = 0;
            ctr_AutoLogOFF = 0;

            Position_Click(rb_Position1, e);
            rb_Position1.Checked = true;
            lbl_Measurement.Text = Measurement.ToString();
        }


        private void LoadData_PartNr_Click(object sender, EventArgs e)
        {
            LoadData_PartNr();
            InitializeChart_ArtikelNr();
            Calculate_Data();

            chartZumbach.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
            chartZumbach.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
        }
        private void LoadData_Order_Click(object sender, EventArgs e)
        {
            LoadData_Order();
            InitializeChart_Order();
            Calculate_Data();
            chartZumbach.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
            chartZumbach.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
        }
       
        private void DiscardSelectedData_Click(object sender, EventArgs e)
        {
            var min_Chart = chartZumbach.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            var max_Chart = chartZumbach.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
           

            var totalMeasurements = (int)max_Chart - (int)min_Chart - 1;
            var conditions = $"Bag = {Measurement} AND Position = {position}";
            var foundRows = ZumbachData.Select(conditions);
            if (foundRows.Length == 0)
                return;

            var min_TempID = int.Parse(foundRows[(int)min_Chart]["ID"].ToString());
            if (totalMeasurements > foundRows.Length)
                totalMeasurements = foundRows.Length;

            var max_TempID = int.Parse(foundRows[(int)min_Chart + totalMeasurements - 1]["ID"].ToString());


            InfoText.Question($"{LanguageManager.GetString("delete")} {totalMeasurements} {LanguageManager.GetString("zumbach_Info_9_2")} {position} / {LanguageManager.GetString("zumbach_Info_9_3")} {Measurement}?", CustomColors.InfoText_Color.Info, "Warning!", this);
            if (InfoText.answer == InfoText.Answer.Yes)
            {
                SaveData.DELETE_Value_Zumbach_Multiple(min_TempID, max_TempID, Measurement, position);
                Load_Data();
            }
            LoadData_Bag(false);
            chartZumbach.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chartZumbach.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);

        }
        private void DiscardMeasurement_Click(object sender, EventArgs e)
        {
            InfoText.Question("Är du säker på att du vill skrota hela denna mätning?", CustomColors.InfoText_Color.Warning, "Warning!", this);
            if (InfoText.answer == InfoText.Answer.Yes)
                DiscardMeasureMent(int.Parse(lbl_Measurement.Text));
            Load_Data();
            LoadData_Bag(false);
        }

        public static void DiscardMeasureMent(int measurement)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"UPDATE Zumbach.Measurements SET Discarded = 'True'
                        WHERE OrderID = @orderid AND Bag = @bag";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@bag", measurement);
                con.Open();
                cmd.ExecuteScalar();
            }
        }
        private void ZoomOut_Click(object sender, EventArgs e)
        {
            chartZumbach.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
            chartZumbach.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
        }
        private void Print_Click(object sender, EventArgs e)
        {
            InfoText.Show(LanguageManager.GetString("zumbach_Info_10"), CustomColors.InfoText_Color.Info, "Info", this);
            btn_Down_Full.PerformClick();
            TuningZumbachMeasurements.TuneOrder(this);

            ClearAllDataChart();
            Refresh();
            LoadData_Order();
            Refresh();
            InitializeChart_Utskrift();
            Refresh();
            preview_Chart.ShowDialog();
            Close();
        }

        private void Position_Click(object sender, EventArgs? e)
        {
            var rb = (RadioButton)sender;
            position = int.Parse(rb.Name[11].ToString());
            stack = 0;
            ctr_AutoLogOFF = 0;

            Initialize_GUI_Switch_Position(true);
        }
        private void ShowPosition_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            var serie = int.Parse(cb.Name[11].ToString()) - 1;
            if (cb.Checked)
                chartZumbach.Series[serie].Enabled = true;
            else
                chartZumbach.Series[serie].Enabled = false;
        }

        private void SortOutDiscardedMeasurements_CheckedChanged(object sender, EventArgs e)
        {
            LoadData_Bag(false);
        }
        private static bool IsMeasurementExist(int number)
        {
            foreach (DataRow row in Zumbach.DataTable_Measurements.Rows)
                if (int.TryParse(row["Bag"].ToString(), out var result) && result == number)
                    return true;
            return false;
        }
        private void Measurement_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(lbl_Measurement.Text, out Measurement);
            if (IsMeasurementExist(Measurement))
            {
                LoadData_Bag(false);
                InitializeChart_Påse();
            }
            else
                ClearAllDataChart();
        }

        private void pb_Info_UCL_LCL_Styrgränser_Click(object sender, EventArgs e)
        {
            InfoText.Show(@"UCL/LCL ger dig extra styrgränser som visar ungefär var du borde ligga i dina mätning, datan är baserad på tidigare körningar med just detta rör.
Siffran efter UCL/LCL på checkboxarna anger hur många mätpunkter styrgränserna baserar sig på.

OBS!! Denna data kan vara lite missvisande om tidigare körningar är dåligt körda, men efter hand med mera data kommer gränserna att stämma bättre.
                           
Justera temperaturen vid behov att flytta upp/ner kurvan.
OBS!! Kontrollera ALLTID krympta värden efter en temperaturjustering.

Du kan styra vissa funktioner i zumbachfönstret med tangetbortet:
Pil Upp - Bläddra en påse upp.
Pil Ner - Bläddra en påse ner.
1       - Byter till position 1.
2       - Byter till position 2.
3       - Byter till position 3.
L       - Startar/Avslutar Loggning.
", CustomColors.InfoText_Color.Info, "Info", this);
        }
        private void Position1_Click(object sender, EventArgs? e)
        {
            Position_Click(rb_Position1, e);
            rb_Position1.Checked = true;
        }
        private void Position2_Click(object sender, EventArgs? e)
        {
            Position_Click(rb_Position2, e);
            rb_Position2.Checked = true;
        }
        private void Position3_Click(object sender, EventArgs? e)
        {
            Position_Click(rb_Position3, e);
            rb_Position3.Checked = true;
        }


        //----------Jämnar till Zumbach serierna--------------------------------------
        
        private void TuneInMeasurement_Click(object sender, EventArgs e)
        {
            btn_Down_Full.PerformClick();
            TuningZumbachMeasurements.TuneOrder(this);
            LoadData_Bag(false);
        }
        
        //----------------E N D --------------------------------------------------
        private void Zumbach_Krympslang_Deactivate(object sender, EventArgs e)
        {
            if (chb_LogData.Checked)
            {
                //logOFF();
            }
        }
        private void Zumbach_Krympslang_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort.Close();
            Main_Form.IsZumbachÖppet = false;
            Dispose();
        }


        private static class Save_ZumbachData
        {
            public static void INSERT_Measurement(byte bag, byte position)
            {

                const string query = @"
                    INSERT INTO Zumbach.Measurements (OrderID, UserID, Discarded, Bag, Position, DateTime) 
                    VALUES (@orderid, @userid, @discarded, @bag, @position, @datetime)";

                var con = new SqlConnection(Database.cs_Protocol);
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@userid", Person.Get_EmployeeID(Person.EmployeeNr));
                cmd.Parameters.AddWithValue("@discarded", false);
                cmd.Parameters.AddWithValue("@bag", bag);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@datetime", DateTime.Now);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            public static void INSERT_Data(double od, int position, int påse)
            {//Datumformatet i datorn måste ändras till yyyy-MM-dd 
                var query = @"INSERT INTO Zumbach.Data (OrderID, Bag, Position, OD) 
                                    VALUES (@orderid, @bag, @position, @od)";

                var con = new SqlConnection(Database.cs_Protocol);
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@bag", påse);
                cmd.Parameters.AddWithValue("@od", od);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


    }
}
