using System.ComponentModel;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DigitalProductionProgram.Zumbach
{
    partial class MeasureWithZumbach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MeasureWithZumbach));
            ChartArea chartArea1 = new ChartArea();
            StripLine stripLine1 = new StripLine();
            StripLine stripLine2 = new StripLine();
            Legend legend1 = new Legend();
            Series series1 = new Series();
            Series series2 = new Series();
            Series series3 = new Series();
            Title title1 = new Title();
            bgw_Zumbach = new BackgroundWorker();
            chb_VisaPos1 = new CheckBox();
            chb_VisaPos2 = new CheckBox();
            chb_VisaPos3 = new CheckBox();
            panel_InfoZumbachChart = new Panel();
            tlp_Top = new TableLayoutPanel();
            chb_Sortera_Bort_Kasserade = new CheckBox();
            lbl_OrderNr = new Label();
            btn_Up = new Button();
            label_Measurement = new Label();
            btn_Up_Full = new Button();
            btn_Down = new Button();
            btn_Down_Full = new Button();
            panel_Position3 = new Panel();
            lbl_Pipe_3 = new Label();
            label_Position3 = new Label();
            rb_Position3 = new RadioButton();
            panel_Position2 = new Panel();
            lbl_Pipe_2 = new Label();
            label_Position2 = new Label();
            rb_Position2 = new RadioButton();
            panel_Position1 = new Panel();
            label_Position1 = new Label();
            lbl_Pipe_1 = new Label();
            rb_Position1 = new RadioButton();
            lbl_Measurement = new Label();
            chb_LogData = new CheckBox();
            lbl_OD = new Label();
            chb_AutoMätByte = new CheckBox();
            pb_Info_UCL_LCL_Styrgränser = new PictureBox();
            tlp_MåttInfo = new TableLayoutPanel();
            label_DateTimeMeasurement_Pos1 = new Label();
            lbl_3HiLo = new Label();
            label_MAX = new Label();
            lbl_1Max = new Label();
            lbl_2Max = new Label();
            lbl_2HiLo = new Label();
            label_AVG = new Label();
            lbl_1HiLo = new Label();
            lbl_2Min = new Label();
            lbl_1Avg = new Label();
            label_HiLo = new Label();
            lbl_1Min = new Label();
            lbl_2Avg = new Label();
            label_MIN = new Label();
            lbl_3Min = new Label();
            lbl_3Avg = new Label();
            lbl_3Max = new Label();
            label_DateTimeMeasurement_Pos2 = new Label();
            label_DateTimeMeasurement_Pos3 = new Label();
            label_Cpk = new Label();
            lbl_1Cpk = new Label();
            lbl_2Cpk = new Label();
            lbl_3Cpk = new Label();
            chb_AutoPosByte = new CheckBox();
            lbl_Maskin = new Label();
            btn_Jämna_Kurvor = new Button();
            btn_GetDataOrder = new Button();
            btn_DeleteSelectedData = new Button();
            chartZumbach = new Chart();
            tlp_Panel_Left = new TableLayoutPanel();
            flp_Buttons = new FlowLayoutPanel();
            btn_DiscardMeasurement = new Button();
            btn_GetDataPartNr = new Button();
            btn_ZoomOut = new Button();
            btn_PrintZumbach = new Button();
            bgw_Random = new BackgroundWorker();
            panel_InfoZumbachChart.SuspendLayout();
            tlp_Top.SuspendLayout();
            panel_Position3.SuspendLayout();
            panel_Position2.SuspendLayout();
            panel_Position1.SuspendLayout();
            ((ISupportInitialize)pb_Info_UCL_LCL_Styrgränser).BeginInit();
            tlp_MåttInfo.SuspendLayout();
            ((ISupportInitialize)chartZumbach).BeginInit();
            tlp_Panel_Left.SuspendLayout();
            flp_Buttons.SuspendLayout();
            SuspendLayout();
            // 
            // bgw_Zumbach
            // 
            bgw_Zumbach.WorkerSupportsCancellation = true;
            bgw_Zumbach.DoWork += bgw_Zumbach_DoWork;
            // 
            // chb_VisaPos1
            // 
            chb_VisaPos1.AutoSize = true;
            chb_VisaPos1.BackColor = Color.Transparent;
            chb_VisaPos1.Checked = true;
            chb_VisaPos1.CheckState = CheckState.Checked;
            tlp_MåttInfo.SetColumnSpan(chb_VisaPos1, 2);
            chb_VisaPos1.Cursor = Cursors.Hand;
            chb_VisaPos1.Dock = DockStyle.Fill;
            chb_VisaPos1.Font = new Font("Segoe UI", 9.75F);
            chb_VisaPos1.ForeColor = Color.Yellow;
            chb_VisaPos1.Location = new Point(1, 2);
            chb_VisaPos1.Margin = new Padding(1, 2, 0, 0);
            chb_VisaPos1.Name = "chb_VisaPos1";
            chb_VisaPos1.Size = new Size(111, 21);
            chb_VisaPos1.TabIndex = 851;
            chb_VisaPos1.Text = "Visa";
            chb_VisaPos1.UseVisualStyleBackColor = false;
            chb_VisaPos1.CheckedChanged += ShowPosition_CheckedChanged;
            // 
            // chb_VisaPos2
            // 
            chb_VisaPos2.AutoSize = true;
            chb_VisaPos2.BackColor = Color.Transparent;
            chb_VisaPos2.Checked = true;
            chb_VisaPos2.CheckState = CheckState.Checked;
            tlp_MåttInfo.SetColumnSpan(chb_VisaPos2, 2);
            chb_VisaPos2.Cursor = Cursors.Hand;
            chb_VisaPos2.Dock = DockStyle.Fill;
            chb_VisaPos2.Font = new Font("Segoe UI", 9.75F);
            chb_VisaPos2.ForeColor = Color.White;
            chb_VisaPos2.Location = new Point(113, 2);
            chb_VisaPos2.Margin = new Padding(1, 2, 0, 0);
            chb_VisaPos2.Name = "chb_VisaPos2";
            chb_VisaPos2.Size = new Size(111, 21);
            chb_VisaPos2.TabIndex = 851;
            chb_VisaPos2.Text = "Visa";
            chb_VisaPos2.UseVisualStyleBackColor = false;
            chb_VisaPos2.CheckedChanged += ShowPosition_CheckedChanged;
            // 
            // chb_VisaPos3
            // 
            chb_VisaPos3.AutoSize = true;
            chb_VisaPos3.BackColor = Color.Transparent;
            chb_VisaPos3.Checked = true;
            chb_VisaPos3.CheckState = CheckState.Checked;
            tlp_MåttInfo.SetColumnSpan(chb_VisaPos3, 2);
            chb_VisaPos3.Cursor = Cursors.Hand;
            chb_VisaPos3.Dock = DockStyle.Fill;
            chb_VisaPos3.Font = new Font("Segoe UI", 9.75F);
            chb_VisaPos3.ForeColor = Color.Lime;
            chb_VisaPos3.Location = new Point(225, 2);
            chb_VisaPos3.Margin = new Padding(1, 2, 0, 0);
            chb_VisaPos3.Name = "chb_VisaPos3";
            chb_VisaPos3.Size = new Size(111, 21);
            chb_VisaPos3.TabIndex = 851;
            chb_VisaPos3.Text = "Visa";
            chb_VisaPos3.UseVisualStyleBackColor = false;
            chb_VisaPos3.CheckedChanged += ShowPosition_CheckedChanged;
            // 
            // panel_InfoZumbachChart
            // 
            panel_InfoZumbachChart.BackColor = Color.DarkRed;
            panel_InfoZumbachChart.BorderStyle = BorderStyle.FixedSingle;
            panel_InfoZumbachChart.Controls.Add(tlp_Top);
            panel_InfoZumbachChart.Cursor = Cursors.SizeAll;
            panel_InfoZumbachChart.Dock = DockStyle.Top;
            panel_InfoZumbachChart.Location = new Point(0, 0);
            panel_InfoZumbachChart.Margin = new Padding(4, 3, 4, 3);
            panel_InfoZumbachChart.Name = "panel_InfoZumbachChart";
            panel_InfoZumbachChart.Size = new Size(1850, 255);
            panel_InfoZumbachChart.TabIndex = 853;
            // 
            // tlp_Top
            // 
            tlp_Top.ColumnCount = 13;
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 292F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 68F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 59F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 54F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 960F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlp_Top.Controls.Add(chb_Sortera_Bort_Kasserade, 8, 9);
            tlp_Top.Controls.Add(lbl_OrderNr, 12, 0);
            tlp_Top.Controls.Add(btn_Up, 0, 0);
            tlp_Top.Controls.Add(label_Measurement, 0, 2);
            tlp_Top.Controls.Add(btn_Up_Full, 1, 0);
            tlp_Top.Controls.Add(btn_Down, 0, 4);
            tlp_Top.Controls.Add(btn_Down_Full, 1, 4);
            tlp_Top.Controls.Add(panel_Position3, 6, 0);
            tlp_Top.Controls.Add(panel_Position2, 4, 0);
            tlp_Top.Controls.Add(panel_Position1, 2, 0);
            tlp_Top.Controls.Add(lbl_Measurement, 1, 2);
            tlp_Top.Controls.Add(chb_LogData, 8, 0);
            tlp_Top.Controls.Add(lbl_OD, 9, 0);
            tlp_Top.Controls.Add(chb_AutoMätByte, 8, 8);
            tlp_Top.Controls.Add(pb_Info_UCL_LCL_Styrgränser, 8, 4);
            tlp_Top.Controls.Add(tlp_MåttInfo, 2, 3);
            tlp_Top.Controls.Add(chb_AutoPosByte, 8, 7);
            tlp_Top.Controls.Add(lbl_Maskin, 12, 5);
            tlp_Top.Dock = DockStyle.Fill;
            tlp_Top.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tlp_Top.Location = new Point(0, 0);
            tlp_Top.Margin = new Padding(4, 3, 4, 3);
            tlp_Top.Name = "tlp_Top";
            tlp_Top.RowCount = 11;
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 14F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 14F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Top.Size = new Size(1848, 253);
            tlp_Top.TabIndex = 869;
            // 
            // chb_Sortera_Bort_Kasserade
            // 
            chb_Sortera_Bort_Kasserade.AutoSize = true;
            chb_Sortera_Bort_Kasserade.BackColor = Color.Transparent;
            chb_Sortera_Bort_Kasserade.Checked = true;
            chb_Sortera_Bort_Kasserade.CheckState = CheckState.Checked;
            chb_Sortera_Bort_Kasserade.Cursor = Cursors.Hand;
            chb_Sortera_Bort_Kasserade.Dock = DockStyle.Fill;
            chb_Sortera_Bort_Kasserade.Font = new Font("Microsoft Sans Serif", 10F);
            chb_Sortera_Bort_Kasserade.ForeColor = Color.Silver;
            chb_Sortera_Bort_Kasserade.Location = new Point(547, 226);
            chb_Sortera_Bort_Kasserade.Margin = new Padding(1);
            chb_Sortera_Bort_Kasserade.Name = "chb_Sortera_Bort_Kasserade";
            chb_Sortera_Bort_Kasserade.Size = new Size(290, 27);
            chb_Sortera_Bort_Kasserade.TabIndex = 871;
            chb_Sortera_Bort_Kasserade.Text = "Sortera bort kasserade mätningar";
            chb_Sortera_Bort_Kasserade.UseVisualStyleBackColor = false;
            chb_Sortera_Bort_Kasserade.Visible = false;
            chb_Sortera_Bort_Kasserade.CheckedChanged += SortOutDiscardedMeasurements_CheckedChanged;
            // 
            // lbl_OrderNr
            // 
            lbl_OrderNr.AutoSize = true;
            lbl_OrderNr.BackColor = Color.Transparent;
            lbl_OrderNr.Dock = DockStyle.Left;
            lbl_OrderNr.Font = new Font("Palatino Linotype", 56.75F);
            lbl_OrderNr.ForeColor = Color.Black;
            lbl_OrderNr.Location = new Point(1023, 0);
            lbl_OrderNr.Margin = new Padding(4, 0, 4, 0);
            lbl_OrderNr.Name = "lbl_OrderNr";
            tlp_Top.SetRowSpan(lbl_OrderNr, 5);
            lbl_OrderNr.Size = new Size(338, 118);
            lbl_OrderNr.TabIndex = 855;
            lbl_OrderNr.Text = "OrderNr";
            lbl_OrderNr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn_Up
            // 
            btn_Up.BackColor = Color.White;
            btn_Up.BackgroundImage = (Image)resources.GetObject("btn_Up.BackgroundImage");
            btn_Up.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Up.Cursor = Cursors.Hand;
            btn_Up.Dock = DockStyle.Fill;
            btn_Up.Font = new Font("Showcard Gothic", 20F, FontStyle.Bold);
            btn_Up.ForeColor = Color.White;
            btn_Up.Location = new Point(0, 0);
            btn_Up.Margin = new Padding(0);
            btn_Up.Name = "btn_Up";
            tlp_Top.SetRowSpan(btn_Up, 2);
            btn_Up.Size = new Size(105, 58);
            btn_Up.TabIndex = 860;
            btn_Up.UseVisualStyleBackColor = false;
            btn_Up.MouseDown += Up_Down_MouseDown;
            // 
            // label_Measurement
            // 
            label_Measurement.AutoSize = true;
            label_Measurement.BackColor = Color.Black;
            label_Measurement.Dock = DockStyle.Fill;
            label_Measurement.Font = new Font("Segoe UI", 9.75F);
            label_Measurement.ForeColor = Color.White;
            label_Measurement.Location = new Point(0, 58);
            label_Measurement.Margin = new Padding(0);
            label_Measurement.Name = "label_Measurement";
            tlp_Top.SetRowSpan(label_Measurement, 2);
            label_Measurement.Size = new Size(105, 46);
            label_Measurement.TabIndex = 847;
            label_Measurement.Text = "Mätning";
            label_Measurement.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_Up_Full
            // 
            btn_Up_Full.BackColor = Color.White;
            btn_Up_Full.BackgroundImage = (Image)resources.GetObject("btn_Up_Full.BackgroundImage");
            btn_Up_Full.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Up_Full.Cursor = Cursors.Hand;
            btn_Up_Full.Dock = DockStyle.Fill;
            btn_Up_Full.Font = new Font("Showcard Gothic", 20F, FontStyle.Bold);
            btn_Up_Full.Location = new Point(105, 0);
            btn_Up_Full.Margin = new Padding(0, 0, 2, 0);
            btn_Up_Full.Name = "btn_Up_Full";
            tlp_Top.SetRowSpan(btn_Up_Full, 2);
            btn_Up_Full.Size = new Size(103, 58);
            btn_Up_Full.TabIndex = 862;
            btn_Up_Full.UseVisualStyleBackColor = false;
            btn_Up_Full.Click += UP_Full_Click;
            // 
            // btn_Down
            // 
            btn_Down.BackColor = Color.White;
            btn_Down.BackgroundImage = (Image)resources.GetObject("btn_Down.BackgroundImage");
            btn_Down.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Down.Cursor = Cursors.Hand;
            btn_Down.Dock = DockStyle.Fill;
            btn_Down.Font = new Font("Showcard Gothic", 20F, FontStyle.Bold);
            btn_Down.Location = new Point(0, 104);
            btn_Down.Margin = new Padding(0);
            btn_Down.Name = "btn_Down";
            tlp_Top.SetRowSpan(btn_Down, 2);
            btn_Down.Size = new Size(105, 58);
            btn_Down.TabIndex = 860;
            btn_Down.UseVisualStyleBackColor = false;
            btn_Down.MouseDown += Up_Down_MouseDown;
            // 
            // btn_Down_Full
            // 
            btn_Down_Full.BackColor = Color.White;
            btn_Down_Full.BackgroundImage = (Image)resources.GetObject("btn_Down_Full.BackgroundImage");
            btn_Down_Full.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Down_Full.Cursor = Cursors.Hand;
            btn_Down_Full.Dock = DockStyle.Fill;
            btn_Down_Full.Font = new Font("Showcard Gothic", 20F, FontStyle.Bold);
            btn_Down_Full.Location = new Point(105, 104);
            btn_Down_Full.Margin = new Padding(0, 0, 2, 0);
            btn_Down_Full.Name = "btn_Down_Full";
            tlp_Top.SetRowSpan(btn_Down_Full, 2);
            btn_Down_Full.Size = new Size(103, 58);
            btn_Down_Full.TabIndex = 863;
            btn_Down_Full.UseVisualStyleBackColor = false;
            btn_Down_Full.Click += Down_Full_Click;
            // 
            // panel_Position3
            // 
            panel_Position3.BackColor = Color.Transparent;
            panel_Position3.BorderStyle = BorderStyle.Fixed3D;
            tlp_Top.SetColumnSpan(panel_Position3, 2);
            panel_Position3.Controls.Add(lbl_Pipe_3);
            panel_Position3.Controls.Add(label_Position3);
            panel_Position3.Controls.Add(rb_Position3);
            panel_Position3.Cursor = Cursors.Hand;
            panel_Position3.Dock = DockStyle.Fill;
            panel_Position3.Location = new Point(436, 1);
            panel_Position3.Margin = new Padding(2, 1, 1, 1);
            panel_Position3.Name = "panel_Position3";
            tlp_Top.SetRowSpan(panel_Position3, 3);
            panel_Position3.Size = new Size(109, 79);
            panel_Position3.TabIndex = 859;
            panel_Position3.Click += Position3_Click;
            // 
            // lbl_Pipe_3
            // 
            lbl_Pipe_3.Dock = DockStyle.Bottom;
            lbl_Pipe_3.ForeColor = Color.Lime;
            lbl_Pipe_3.Location = new Point(0, 60);
            lbl_Pipe_3.Margin = new Padding(4, 0, 4, 0);
            lbl_Pipe_3.Name = "lbl_Pipe_3";
            lbl_Pipe_3.Size = new Size(105, 15);
            lbl_Pipe_3.TabIndex = 850;
            lbl_Pipe_3.Text = "HS Pipe 3";
            lbl_Pipe_3.Click += Position3_Click;
            // 
            // label_Position3
            // 
            label_Position3.BackColor = Color.Transparent;
            label_Position3.Cursor = Cursors.Hand;
            label_Position3.Dock = DockStyle.Top;
            label_Position3.Font = new Font("Segoe UI", 9.75F);
            label_Position3.ForeColor = Color.Lime;
            label_Position3.Location = new Point(0, 0);
            label_Position3.Margin = new Padding(4, 0, 4, 0);
            label_Position3.Name = "label_Position3";
            label_Position3.Size = new Size(105, 20);
            label_Position3.TabIndex = 847;
            label_Position3.Text = "Position";
            label_Position3.TextAlign = ContentAlignment.TopCenter;
            label_Position3.Click += Position3_Click;
            // 
            // rb_Position3
            // 
            rb_Position3.AutoSize = true;
            rb_Position3.BackColor = Color.Transparent;
            rb_Position3.CheckAlign = ContentAlignment.MiddleCenter;
            rb_Position3.Cursor = Cursors.Hand;
            rb_Position3.Dock = DockStyle.Fill;
            rb_Position3.Font = new Font("Microsoft Sans Serif", 16.25F);
            rb_Position3.ForeColor = Color.Lime;
            rb_Position3.Location = new Point(0, 0);
            rb_Position3.Margin = new Padding(4, 3, 4, 3);
            rb_Position3.Name = "rb_Position3";
            rb_Position3.Size = new Size(105, 75);
            rb_Position3.TabIndex = 845;
            rb_Position3.Text = "3";
            rb_Position3.TextAlign = ContentAlignment.MiddleRight;
            rb_Position3.UseVisualStyleBackColor = false;
            rb_Position3.Click += Position_Click;
            // 
            // panel_Position2
            // 
            panel_Position2.BackColor = Color.Transparent;
            panel_Position2.BorderStyle = BorderStyle.Fixed3D;
            tlp_Top.SetColumnSpan(panel_Position2, 2);
            panel_Position2.Controls.Add(lbl_Pipe_2);
            panel_Position2.Controls.Add(label_Position2);
            panel_Position2.Controls.Add(rb_Position2);
            panel_Position2.Cursor = Cursors.Hand;
            panel_Position2.Dock = DockStyle.Fill;
            panel_Position2.Location = new Point(324, 1);
            panel_Position2.Margin = new Padding(2, 1, 2, 1);
            panel_Position2.Name = "panel_Position2";
            tlp_Top.SetRowSpan(panel_Position2, 3);
            panel_Position2.Size = new Size(108, 79);
            panel_Position2.TabIndex = 859;
            panel_Position2.Click += Position2_Click;
            // 
            // lbl_Pipe_2
            // 
            lbl_Pipe_2.Dock = DockStyle.Bottom;
            lbl_Pipe_2.ForeColor = Color.White;
            lbl_Pipe_2.Location = new Point(0, 60);
            lbl_Pipe_2.Margin = new Padding(4, 0, 4, 0);
            lbl_Pipe_2.Name = "lbl_Pipe_2";
            lbl_Pipe_2.Size = new Size(104, 15);
            lbl_Pipe_2.TabIndex = 849;
            lbl_Pipe_2.Text = "HS Pipe 2";
            lbl_Pipe_2.Click += Position2_Click;
            // 
            // label_Position2
            // 
            label_Position2.BackColor = Color.Transparent;
            label_Position2.Cursor = Cursors.Hand;
            label_Position2.Dock = DockStyle.Top;
            label_Position2.Font = new Font("Segoe UI", 9.75F);
            label_Position2.ForeColor = Color.White;
            label_Position2.Location = new Point(0, 0);
            label_Position2.Margin = new Padding(1);
            label_Position2.Name = "label_Position2";
            label_Position2.Size = new Size(104, 20);
            label_Position2.TabIndex = 847;
            label_Position2.Text = "Position";
            label_Position2.TextAlign = ContentAlignment.TopCenter;
            label_Position2.Click += Position2_Click;
            // 
            // rb_Position2
            // 
            rb_Position2.AutoSize = true;
            rb_Position2.BackColor = Color.Transparent;
            rb_Position2.CheckAlign = ContentAlignment.MiddleCenter;
            rb_Position2.Cursor = Cursors.Hand;
            rb_Position2.Dock = DockStyle.Fill;
            rb_Position2.Font = new Font("Microsoft Sans Serif", 16.25F);
            rb_Position2.ForeColor = Color.White;
            rb_Position2.Location = new Point(0, 0);
            rb_Position2.Margin = new Padding(4, 3, 4, 3);
            rb_Position2.Name = "rb_Position2";
            rb_Position2.Size = new Size(104, 75);
            rb_Position2.TabIndex = 845;
            rb_Position2.Text = "2";
            rb_Position2.TextAlign = ContentAlignment.MiddleRight;
            rb_Position2.UseVisualStyleBackColor = false;
            rb_Position2.Click += Position_Click;
            // 
            // panel_Position1
            // 
            panel_Position1.BackColor = Color.Transparent;
            panel_Position1.BorderStyle = BorderStyle.Fixed3D;
            tlp_Top.SetColumnSpan(panel_Position1, 2);
            panel_Position1.Controls.Add(label_Position1);
            panel_Position1.Controls.Add(lbl_Pipe_1);
            panel_Position1.Controls.Add(rb_Position1);
            panel_Position1.Cursor = Cursors.Hand;
            panel_Position1.Dock = DockStyle.Fill;
            panel_Position1.Location = new Point(211, 1);
            panel_Position1.Margin = new Padding(1);
            panel_Position1.Name = "panel_Position1";
            tlp_Top.SetRowSpan(panel_Position1, 3);
            panel_Position1.Size = new Size(110, 79);
            panel_Position1.TabIndex = 858;
            panel_Position1.Click += Position1_Click;
            // 
            // label_Position1
            // 
            label_Position1.BackColor = Color.Transparent;
            label_Position1.Cursor = Cursors.Hand;
            label_Position1.Dock = DockStyle.Top;
            label_Position1.Font = new Font("Segoe UI", 9.75F);
            label_Position1.ForeColor = Color.Yellow;
            label_Position1.Location = new Point(0, 0);
            label_Position1.Margin = new Padding(4, 0, 4, 0);
            label_Position1.Name = "label_Position1";
            label_Position1.Size = new Size(106, 20);
            label_Position1.TabIndex = 847;
            label_Position1.Text = "Position";
            label_Position1.TextAlign = ContentAlignment.TopCenter;
            label_Position1.Click += Position1_Click;
            // 
            // lbl_Pipe_1
            // 
            lbl_Pipe_1.BackColor = Color.Transparent;
            lbl_Pipe_1.Dock = DockStyle.Bottom;
            lbl_Pipe_1.ForeColor = Color.Yellow;
            lbl_Pipe_1.Location = new Point(0, 60);
            lbl_Pipe_1.Margin = new Padding(1, 1, 2, 1);
            lbl_Pipe_1.Name = "lbl_Pipe_1";
            lbl_Pipe_1.Size = new Size(106, 15);
            lbl_Pipe_1.TabIndex = 848;
            lbl_Pipe_1.Text = "HS Pipe 1";
            lbl_Pipe_1.Click += Position1_Click;
            // 
            // rb_Position1
            // 
            rb_Position1.BackColor = Color.Transparent;
            rb_Position1.CheckAlign = ContentAlignment.MiddleCenter;
            rb_Position1.Checked = true;
            rb_Position1.Cursor = Cursors.Hand;
            rb_Position1.Dock = DockStyle.Fill;
            rb_Position1.Font = new Font("Microsoft Sans Serif", 16.25F);
            rb_Position1.ForeColor = Color.Yellow;
            rb_Position1.Location = new Point(0, 0);
            rb_Position1.Margin = new Padding(4, 3, 4, 3);
            rb_Position1.Name = "rb_Position1";
            rb_Position1.Size = new Size(106, 75);
            rb_Position1.TabIndex = 845;
            rb_Position1.TabStop = true;
            rb_Position1.Text = "1";
            rb_Position1.TextAlign = ContentAlignment.MiddleRight;
            rb_Position1.UseVisualStyleBackColor = false;
            rb_Position1.Click += Position_Click;
            // 
            // lbl_Measurement
            // 
            lbl_Measurement.AutoSize = true;
            lbl_Measurement.BackColor = Color.Black;
            lbl_Measurement.Dock = DockStyle.Fill;
            lbl_Measurement.Font = new Font("Segoe UI", 18.25F);
            lbl_Measurement.ForeColor = Color.White;
            lbl_Measurement.Location = new Point(105, 58);
            lbl_Measurement.Margin = new Padding(0, 0, 2, 0);
            lbl_Measurement.Name = "lbl_Measurement";
            tlp_Top.SetRowSpan(lbl_Measurement, 2);
            lbl_Measurement.Size = new Size(103, 46);
            lbl_Measurement.TabIndex = 866;
            lbl_Measurement.Text = "1";
            lbl_Measurement.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Measurement.TextChanged += Measurement_TextChanged;
            // 
            // chb_LogData
            // 
            chb_LogData.AutoSize = true;
            chb_LogData.BackColor = Color.Transparent;
            chb_LogData.Cursor = Cursors.Hand;
            chb_LogData.Dock = DockStyle.Fill;
            chb_LogData.Font = new Font("Microsoft Sans Serif", 19.25F);
            chb_LogData.ForeColor = Color.Silver;
            chb_LogData.Location = new Point(550, 3);
            chb_LogData.Margin = new Padding(4, 3, 4, 3);
            chb_LogData.MinimumSize = new Size(198, 0);
            chb_LogData.Name = "chb_LogData";
            tlp_Top.SetRowSpan(chb_LogData, 2);
            chb_LogData.Size = new Size(284, 52);
            chb_LogData.TabIndex = 848;
            chb_LogData.Text = "Starta Loggning";
            chb_LogData.UseVisualStyleBackColor = false;
            chb_LogData.CheckedChanged += CheckBox_LogData_CheckedChanged;
            // 
            // lbl_OD
            // 
            lbl_OD.AutoSize = true;
            lbl_OD.BackColor = Color.Transparent;
            tlp_Top.SetColumnSpan(lbl_OD, 3);
            lbl_OD.Dock = DockStyle.Fill;
            lbl_OD.Font = new Font("Segoe UI", 22.75F, FontStyle.Bold);
            lbl_OD.ForeColor = Color.Teal;
            lbl_OD.Location = new Point(842, 0);
            lbl_OD.Margin = new Padding(4, 0, 4, 0);
            lbl_OD.Name = "lbl_OD";
            tlp_Top.SetRowSpan(lbl_OD, 2);
            lbl_OD.Size = new Size(173, 58);
            lbl_OD.TabIndex = 25;
            lbl_OD.Text = "0,000";
            // 
            // chb_AutoMätByte
            // 
            chb_AutoMätByte.AutoSize = true;
            chb_AutoMätByte.BackColor = Color.Transparent;
            chb_AutoMätByte.Cursor = Cursors.Hand;
            chb_AutoMätByte.Dock = DockStyle.Fill;
            chb_AutoMätByte.Font = new Font("Microsoft Sans Serif", 10F);
            chb_AutoMätByte.ForeColor = Color.Silver;
            chb_AutoMätByte.Location = new Point(547, 202);
            chb_AutoMätByte.Margin = new Padding(1);
            chb_AutoMätByte.Name = "chb_AutoMätByte";
            chb_AutoMätByte.Size = new Size(290, 22);
            chb_AutoMätByte.TabIndex = 865;
            chb_AutoMätByte.Text = "Automatiskt Mätningsbyte";
            chb_AutoMätByte.UseVisualStyleBackColor = false;
            chb_AutoMätByte.Visible = false;
            // 
            // pb_Info_UCL_LCL_Styrgränser
            // 
            pb_Info_UCL_LCL_Styrgränser.BackColor = Color.Transparent;
            pb_Info_UCL_LCL_Styrgränser.BackgroundImage = (Image)resources.GetObject("pb_Info_UCL_LCL_Styrgränser.BackgroundImage");
            pb_Info_UCL_LCL_Styrgränser.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info_UCL_LCL_Styrgränser.Cursor = Cursors.Hand;
            pb_Info_UCL_LCL_Styrgränser.Location = new Point(550, 107);
            pb_Info_UCL_LCL_Styrgränser.Margin = new Padding(4, 3, 4, 3);
            pb_Info_UCL_LCL_Styrgränser.Name = "pb_Info_UCL_LCL_Styrgränser";
            tlp_Top.SetRowSpan(pb_Info_UCL_LCL_Styrgränser, 2);
            pb_Info_UCL_LCL_Styrgränser.Size = new Size(41, 39);
            pb_Info_UCL_LCL_Styrgränser.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Info_UCL_LCL_Styrgränser.TabIndex = 869;
            pb_Info_UCL_LCL_Styrgränser.TabStop = false;
            pb_Info_UCL_LCL_Styrgränser.Visible = false;
            pb_Info_UCL_LCL_Styrgränser.Click += pb_Info_UCL_LCL_Styrgränser_Click;
            // 
            // tlp_MåttInfo
            // 
            tlp_MåttInfo.BackColor = Color.Black;
            tlp_MåttInfo.ColumnCount = 6;
            tlp_Top.SetColumnSpan(tlp_MåttInfo, 6);
            tlp_MåttInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_MåttInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_MåttInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_MåttInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_MåttInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_MåttInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_MåttInfo.Controls.Add(label_DateTimeMeasurement_Pos1, 0, 1);
            tlp_MåttInfo.Controls.Add(lbl_3HiLo, 5, 5);
            tlp_MåttInfo.Controls.Add(label_MAX, 0, 2);
            tlp_MåttInfo.Controls.Add(lbl_1Max, 1, 2);
            tlp_MåttInfo.Controls.Add(lbl_2Max, 3, 2);
            tlp_MåttInfo.Controls.Add(lbl_2HiLo, 3, 5);
            tlp_MåttInfo.Controls.Add(label_AVG, 0, 3);
            tlp_MåttInfo.Controls.Add(lbl_1HiLo, 1, 5);
            tlp_MåttInfo.Controls.Add(lbl_2Min, 3, 4);
            tlp_MåttInfo.Controls.Add(lbl_1Avg, 1, 3);
            tlp_MåttInfo.Controls.Add(chb_VisaPos1, 0, 0);
            tlp_MåttInfo.Controls.Add(chb_VisaPos3, 4, 0);
            tlp_MåttInfo.Controls.Add(label_HiLo, 0, 5);
            tlp_MåttInfo.Controls.Add(chb_VisaPos2, 2, 0);
            tlp_MåttInfo.Controls.Add(lbl_1Min, 1, 4);
            tlp_MåttInfo.Controls.Add(lbl_2Avg, 3, 3);
            tlp_MåttInfo.Controls.Add(label_MIN, 0, 4);
            tlp_MåttInfo.Controls.Add(lbl_3Min, 5, 4);
            tlp_MåttInfo.Controls.Add(lbl_3Avg, 5, 3);
            tlp_MåttInfo.Controls.Add(lbl_3Max, 5, 2);
            tlp_MåttInfo.Controls.Add(label_DateTimeMeasurement_Pos2, 2, 1);
            tlp_MåttInfo.Controls.Add(label_DateTimeMeasurement_Pos3, 4, 1);
            tlp_MåttInfo.Controls.Add(label_Cpk, 0, 6);
            tlp_MåttInfo.Controls.Add(lbl_1Cpk, 1, 6);
            tlp_MåttInfo.Controls.Add(lbl_2Cpk, 3, 6);
            tlp_MåttInfo.Controls.Add(lbl_3Cpk, 5, 6);
            tlp_MåttInfo.Dock = DockStyle.Fill;
            tlp_MåttInfo.Location = new Point(210, 81);
            tlp_MåttInfo.Margin = new Padding(0);
            tlp_MåttInfo.Name = "tlp_MåttInfo";
            tlp_MåttInfo.RowCount = 7;
            tlp_Top.SetRowSpan(tlp_MåttInfo, 7);
            tlp_MåttInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_MåttInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_MåttInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tlp_MåttInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tlp_MåttInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tlp_MåttInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tlp_MåttInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tlp_MåttInfo.Size = new Size(336, 173);
            tlp_MåttInfo.TabIndex = 898;
            // 
            // label_DateTimeMeasurement_Pos1
            // 
            label_DateTimeMeasurement_Pos1.AutoSize = true;
            tlp_MåttInfo.SetColumnSpan(label_DateTimeMeasurement_Pos1, 2);
            label_DateTimeMeasurement_Pos1.Dock = DockStyle.Fill;
            label_DateTimeMeasurement_Pos1.Font = new Font("Lucida Sans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DateTimeMeasurement_Pos1.ForeColor = Color.White;
            label_DateTimeMeasurement_Pos1.Location = new Point(4, 23);
            label_DateTimeMeasurement_Pos1.Margin = new Padding(4, 0, 4, 0);
            label_DateTimeMeasurement_Pos1.Name = "label_DateTimeMeasurement_Pos1";
            label_DateTimeMeasurement_Pos1.Size = new Size(104, 35);
            label_DateTimeMeasurement_Pos1.TabIndex = 903;
            label_DateTimeMeasurement_Pos1.Text = "date";
            label_DateTimeMeasurement_Pos1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_3HiLo
            // 
            lbl_3HiLo.AutoSize = true;
            lbl_3HiLo.BackColor = Color.Transparent;
            lbl_3HiLo.Font = new Font("Segoe UI", 8.75F);
            lbl_3HiLo.ForeColor = Color.Lime;
            lbl_3HiLo.Location = new Point(284, 121);
            lbl_3HiLo.Margin = new Padding(4, 0, 0, 0);
            lbl_3HiLo.Name = "lbl_3HiLo";
            lbl_3HiLo.Size = new Size(34, 15);
            lbl_3HiLo.TabIndex = 847;
            lbl_3HiLo.Text = "0,000";
            // 
            // label_MAX
            // 
            label_MAX.AutoSize = true;
            label_MAX.BackColor = Color.Transparent;
            label_MAX.Font = new Font("Segoe UI", 9.75F);
            label_MAX.ForeColor = Color.Silver;
            label_MAX.Location = new Point(4, 58);
            label_MAX.Margin = new Padding(4, 0, 4, 0);
            label_MAX.Name = "label_MAX";
            label_MAX.Size = new Size(36, 17);
            label_MAX.TabIndex = 847;
            label_MAX.Text = "MAX";
            // 
            // lbl_1Max
            // 
            lbl_1Max.AutoSize = true;
            lbl_1Max.BackColor = Color.Transparent;
            lbl_1Max.Font = new Font("Segoe UI", 8.75F);
            lbl_1Max.ForeColor = Color.Yellow;
            lbl_1Max.Location = new Point(60, 58);
            lbl_1Max.Margin = new Padding(4, 0, 0, 0);
            lbl_1Max.Name = "lbl_1Max";
            lbl_1Max.Size = new Size(34, 15);
            lbl_1Max.TabIndex = 847;
            lbl_1Max.Text = "0,000";
            // 
            // lbl_2Max
            // 
            lbl_2Max.AutoSize = true;
            lbl_2Max.BackColor = Color.Transparent;
            lbl_2Max.Font = new Font("Segoe UI", 8.75F);
            lbl_2Max.ForeColor = Color.White;
            lbl_2Max.Location = new Point(172, 58);
            lbl_2Max.Margin = new Padding(4, 0, 0, 0);
            lbl_2Max.Name = "lbl_2Max";
            lbl_2Max.Size = new Size(34, 15);
            lbl_2Max.TabIndex = 847;
            lbl_2Max.Text = "0,000";
            // 
            // lbl_2HiLo
            // 
            lbl_2HiLo.AutoSize = true;
            lbl_2HiLo.BackColor = Color.Transparent;
            lbl_2HiLo.Font = new Font("Segoe UI", 8.75F);
            lbl_2HiLo.ForeColor = Color.White;
            lbl_2HiLo.Location = new Point(172, 121);
            lbl_2HiLo.Margin = new Padding(4, 0, 0, 0);
            lbl_2HiLo.Name = "lbl_2HiLo";
            lbl_2HiLo.Size = new Size(34, 15);
            lbl_2HiLo.TabIndex = 847;
            lbl_2HiLo.Text = "0,000";
            // 
            // label_AVG
            // 
            label_AVG.AutoSize = true;
            label_AVG.BackColor = Color.Transparent;
            label_AVG.Font = new Font("Segoe UI", 9.75F);
            label_AVG.ForeColor = Color.Silver;
            label_AVG.Location = new Point(4, 79);
            label_AVG.Margin = new Padding(4, 0, 4, 0);
            label_AVG.Name = "label_AVG";
            label_AVG.Size = new Size(32, 17);
            label_AVG.TabIndex = 847;
            label_AVG.Text = "AVG";
            // 
            // lbl_1HiLo
            // 
            lbl_1HiLo.AutoSize = true;
            lbl_1HiLo.BackColor = Color.Transparent;
            lbl_1HiLo.Font = new Font("Segoe UI", 8.75F);
            lbl_1HiLo.ForeColor = Color.Yellow;
            lbl_1HiLo.Location = new Point(60, 121);
            lbl_1HiLo.Margin = new Padding(4, 0, 0, 0);
            lbl_1HiLo.Name = "lbl_1HiLo";
            lbl_1HiLo.Size = new Size(34, 15);
            lbl_1HiLo.TabIndex = 847;
            lbl_1HiLo.Text = "0,000";
            // 
            // lbl_2Min
            // 
            lbl_2Min.AutoSize = true;
            lbl_2Min.BackColor = Color.Transparent;
            lbl_2Min.Font = new Font("Segoe UI", 8.75F);
            lbl_2Min.ForeColor = Color.White;
            lbl_2Min.Location = new Point(172, 100);
            lbl_2Min.Margin = new Padding(4, 0, 0, 0);
            lbl_2Min.Name = "lbl_2Min";
            lbl_2Min.Size = new Size(34, 15);
            lbl_2Min.TabIndex = 847;
            lbl_2Min.Text = "0,000";
            // 
            // lbl_1Avg
            // 
            lbl_1Avg.AutoSize = true;
            lbl_1Avg.BackColor = Color.Transparent;
            lbl_1Avg.Font = new Font("Segoe UI", 8.75F);
            lbl_1Avg.ForeColor = Color.Yellow;
            lbl_1Avg.Location = new Point(60, 79);
            lbl_1Avg.Margin = new Padding(4, 0, 0, 0);
            lbl_1Avg.Name = "lbl_1Avg";
            lbl_1Avg.Size = new Size(34, 15);
            lbl_1Avg.TabIndex = 847;
            lbl_1Avg.Text = "0,000";
            // 
            // label_HiLo
            // 
            label_HiLo.AutoSize = true;
            label_HiLo.BackColor = Color.Transparent;
            label_HiLo.Font = new Font("Segoe UI", 9.75F);
            label_HiLo.ForeColor = Color.Silver;
            label_HiLo.Location = new Point(4, 121);
            label_HiLo.Margin = new Padding(4, 0, 4, 0);
            label_HiLo.Name = "label_HiLo";
            label_HiLo.Size = new Size(39, 17);
            label_HiLo.TabIndex = 847;
            label_HiLo.Text = "Hi-Lo";
            // 
            // lbl_1Min
            // 
            lbl_1Min.AutoSize = true;
            lbl_1Min.BackColor = Color.Transparent;
            lbl_1Min.Font = new Font("Segoe UI", 8.75F);
            lbl_1Min.ForeColor = Color.Yellow;
            lbl_1Min.Location = new Point(60, 100);
            lbl_1Min.Margin = new Padding(4, 0, 0, 0);
            lbl_1Min.Name = "lbl_1Min";
            lbl_1Min.Size = new Size(34, 15);
            lbl_1Min.TabIndex = 847;
            lbl_1Min.Text = "0,000";
            // 
            // lbl_2Avg
            // 
            lbl_2Avg.AutoSize = true;
            lbl_2Avg.BackColor = Color.Transparent;
            lbl_2Avg.Font = new Font("Segoe UI", 8.75F);
            lbl_2Avg.ForeColor = Color.White;
            lbl_2Avg.Location = new Point(172, 79);
            lbl_2Avg.Margin = new Padding(4, 0, 0, 0);
            lbl_2Avg.Name = "lbl_2Avg";
            lbl_2Avg.Size = new Size(34, 15);
            lbl_2Avg.TabIndex = 847;
            lbl_2Avg.Text = "0,000";
            // 
            // label_MIN
            // 
            label_MIN.AutoSize = true;
            label_MIN.BackColor = Color.Transparent;
            label_MIN.Font = new Font("Segoe UI", 9.75F);
            label_MIN.ForeColor = Color.Silver;
            label_MIN.Location = new Point(4, 100);
            label_MIN.Margin = new Padding(4, 0, 4, 0);
            label_MIN.Name = "label_MIN";
            label_MIN.Size = new Size(33, 17);
            label_MIN.TabIndex = 847;
            label_MIN.Text = "MIN";
            // 
            // lbl_3Min
            // 
            lbl_3Min.AutoSize = true;
            lbl_3Min.BackColor = Color.Transparent;
            lbl_3Min.Font = new Font("Segoe UI", 8.75F);
            lbl_3Min.ForeColor = Color.Lime;
            lbl_3Min.Location = new Point(284, 100);
            lbl_3Min.Margin = new Padding(4, 0, 0, 0);
            lbl_3Min.Name = "lbl_3Min";
            lbl_3Min.Size = new Size(34, 15);
            lbl_3Min.TabIndex = 847;
            lbl_3Min.Text = "0,000";
            // 
            // lbl_3Avg
            // 
            lbl_3Avg.AutoSize = true;
            lbl_3Avg.BackColor = Color.Transparent;
            lbl_3Avg.Font = new Font("Segoe UI", 8.75F);
            lbl_3Avg.ForeColor = Color.Lime;
            lbl_3Avg.Location = new Point(284, 79);
            lbl_3Avg.Margin = new Padding(4, 0, 0, 0);
            lbl_3Avg.Name = "lbl_3Avg";
            lbl_3Avg.Size = new Size(34, 15);
            lbl_3Avg.TabIndex = 847;
            lbl_3Avg.Text = "0,000";
            // 
            // lbl_3Max
            // 
            lbl_3Max.AutoSize = true;
            lbl_3Max.BackColor = Color.Transparent;
            lbl_3Max.Font = new Font("Segoe UI", 8.75F);
            lbl_3Max.ForeColor = Color.Lime;
            lbl_3Max.Location = new Point(284, 58);
            lbl_3Max.Margin = new Padding(4, 0, 0, 0);
            lbl_3Max.Name = "lbl_3Max";
            lbl_3Max.Size = new Size(34, 15);
            lbl_3Max.TabIndex = 847;
            lbl_3Max.Text = "0,000";
            // 
            // label_DateTimeMeasurement_Pos2
            // 
            label_DateTimeMeasurement_Pos2.AutoSize = true;
            tlp_MåttInfo.SetColumnSpan(label_DateTimeMeasurement_Pos2, 2);
            label_DateTimeMeasurement_Pos2.Dock = DockStyle.Fill;
            label_DateTimeMeasurement_Pos2.Font = new Font("Lucida Sans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DateTimeMeasurement_Pos2.ForeColor = Color.White;
            label_DateTimeMeasurement_Pos2.Location = new Point(116, 23);
            label_DateTimeMeasurement_Pos2.Margin = new Padding(4, 0, 4, 0);
            label_DateTimeMeasurement_Pos2.Name = "label_DateTimeMeasurement_Pos2";
            label_DateTimeMeasurement_Pos2.Size = new Size(104, 35);
            label_DateTimeMeasurement_Pos2.TabIndex = 903;
            label_DateTimeMeasurement_Pos2.Text = "date";
            label_DateTimeMeasurement_Pos2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_DateTimeMeasurement_Pos3
            // 
            label_DateTimeMeasurement_Pos3.AutoSize = true;
            tlp_MåttInfo.SetColumnSpan(label_DateTimeMeasurement_Pos3, 2);
            label_DateTimeMeasurement_Pos3.Dock = DockStyle.Fill;
            label_DateTimeMeasurement_Pos3.Font = new Font("Lucida Sans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DateTimeMeasurement_Pos3.ForeColor = Color.White;
            label_DateTimeMeasurement_Pos3.Location = new Point(228, 23);
            label_DateTimeMeasurement_Pos3.Margin = new Padding(4, 0, 4, 0);
            label_DateTimeMeasurement_Pos3.Name = "label_DateTimeMeasurement_Pos3";
            label_DateTimeMeasurement_Pos3.Size = new Size(104, 35);
            label_DateTimeMeasurement_Pos3.TabIndex = 903;
            label_DateTimeMeasurement_Pos3.Text = "date";
            label_DateTimeMeasurement_Pos3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Cpk
            // 
            label_Cpk.AutoSize = true;
            label_Cpk.BackColor = Color.Transparent;
            label_Cpk.Font = new Font("Segoe UI", 9.75F);
            label_Cpk.ForeColor = Color.Silver;
            label_Cpk.Location = new Point(4, 142);
            label_Cpk.Margin = new Padding(4, 0, 4, 0);
            label_Cpk.Name = "label_Cpk";
            label_Cpk.Size = new Size(30, 17);
            label_Cpk.TabIndex = 847;
            label_Cpk.Text = "Cpk";
            // 
            // lbl_1Cpk
            // 
            lbl_1Cpk.AutoSize = true;
            lbl_1Cpk.BackColor = Color.Transparent;
            lbl_1Cpk.Font = new Font("Segoe UI", 8.75F);
            lbl_1Cpk.ForeColor = Color.Yellow;
            lbl_1Cpk.Location = new Point(60, 142);
            lbl_1Cpk.Margin = new Padding(4, 0, 0, 0);
            lbl_1Cpk.Name = "lbl_1Cpk";
            lbl_1Cpk.Size = new Size(34, 15);
            lbl_1Cpk.TabIndex = 847;
            lbl_1Cpk.Text = "0,000";
            // 
            // lbl_2Cpk
            // 
            lbl_2Cpk.AutoSize = true;
            lbl_2Cpk.BackColor = Color.Transparent;
            lbl_2Cpk.Font = new Font("Segoe UI", 8.75F);
            lbl_2Cpk.ForeColor = Color.White;
            lbl_2Cpk.Location = new Point(172, 142);
            lbl_2Cpk.Margin = new Padding(4, 0, 0, 0);
            lbl_2Cpk.Name = "lbl_2Cpk";
            lbl_2Cpk.Size = new Size(34, 15);
            lbl_2Cpk.TabIndex = 847;
            lbl_2Cpk.Text = "0,000";
            // 
            // lbl_3Cpk
            // 
            lbl_3Cpk.AutoSize = true;
            lbl_3Cpk.BackColor = Color.Transparent;
            lbl_3Cpk.Font = new Font("Segoe UI", 8.75F);
            lbl_3Cpk.ForeColor = Color.Lime;
            lbl_3Cpk.Location = new Point(284, 142);
            lbl_3Cpk.Margin = new Padding(4, 0, 0, 0);
            lbl_3Cpk.Name = "lbl_3Cpk";
            lbl_3Cpk.Size = new Size(34, 15);
            lbl_3Cpk.TabIndex = 847;
            lbl_3Cpk.Text = "0,000";
            // 
            // chb_AutoPosByte
            // 
            chb_AutoPosByte.AutoSize = true;
            chb_AutoPosByte.BackColor = Color.Transparent;
            chb_AutoPosByte.Checked = true;
            chb_AutoPosByte.CheckState = CheckState.Checked;
            chb_AutoPosByte.Cursor = Cursors.Hand;
            chb_AutoPosByte.Dock = DockStyle.Fill;
            chb_AutoPosByte.Font = new Font("Microsoft Sans Serif", 10F);
            chb_AutoPosByte.ForeColor = Color.Silver;
            chb_AutoPosByte.Location = new Point(547, 177);
            chb_AutoPosByte.Margin = new Padding(1);
            chb_AutoPosByte.Name = "chb_AutoPosByte";
            chb_AutoPosByte.Size = new Size(290, 23);
            chb_AutoPosByte.TabIndex = 848;
            chb_AutoPosByte.Text = "Automatiskt Positionsbyte";
            chb_AutoPosByte.UseVisualStyleBackColor = false;
            // 
            // lbl_Maskin
            // 
            lbl_Maskin.AutoSize = true;
            lbl_Maskin.BackColor = Color.Transparent;
            lbl_Maskin.Dock = DockStyle.Left;
            lbl_Maskin.Font = new Font("Palatino Linotype", 42.75F);
            lbl_Maskin.Location = new Point(1023, 118);
            lbl_Maskin.Margin = new Padding(4, 0, 4, 0);
            lbl_Maskin.Name = "lbl_Maskin";
            tlp_Top.SetRowSpan(lbl_Maskin, 4);
            lbl_Maskin.Size = new Size(222, 107);
            lbl_Maskin.TabIndex = 901;
            lbl_Maskin.Text = "Maskin";
            lbl_Maskin.TextAlign = ContentAlignment.TopRight;
            // 
            // btn_Jämna_Kurvor
            // 
            btn_Jämna_Kurvor.BackColor = Color.Transparent;
            btn_Jämna_Kurvor.Cursor = Cursors.Hand;
            btn_Jämna_Kurvor.FlatStyle = FlatStyle.Flat;
            btn_Jämna_Kurvor.Font = new Font("Microsoft Sans Serif", 11.25F);
            btn_Jämna_Kurvor.ForeColor = Color.Silver;
            btn_Jämna_Kurvor.Location = new Point(0, 82);
            btn_Jämna_Kurvor.Margin = new Padding(0, 0, 0, 6);
            btn_Jämna_Kurvor.Name = "btn_Jämna_Kurvor";
            btn_Jämna_Kurvor.Size = new Size(304, 35);
            btn_Jämna_Kurvor.TabIndex = 899;
            btn_Jämna_Kurvor.Text = "Jämna till kurvorna";
            btn_Jämna_Kurvor.UseVisualStyleBackColor = false;
            btn_Jämna_Kurvor.Visible = false;
            btn_Jämna_Kurvor.Click += TuneInMeasurement_Click;
            // 
            // btn_GetDataOrder
            // 
            btn_GetDataOrder.BackColor = Color.Transparent;
            btn_GetDataOrder.Cursor = Cursors.Hand;
            btn_GetDataOrder.FlatStyle = FlatStyle.Flat;
            btn_GetDataOrder.Font = new Font("Microsoft Sans Serif", 11.25F);
            btn_GetDataOrder.ForeColor = Color.Silver;
            btn_GetDataOrder.Location = new Point(0, 123);
            btn_GetDataOrder.Margin = new Padding(0, 0, 0, 6);
            btn_GetDataOrder.Name = "btn_GetDataOrder";
            btn_GetDataOrder.Size = new Size(304, 35);
            btn_GetDataOrder.TabIndex = 849;
            btn_GetDataOrder.Text = "Hämta data från hela ordern";
            btn_GetDataOrder.UseVisualStyleBackColor = false;
            btn_GetDataOrder.Click += LoadData_Order_Click;
            // 
            // btn_DeleteSelectedData
            // 
            btn_DeleteSelectedData.BackColor = Color.Transparent;
            btn_DeleteSelectedData.Cursor = Cursors.Hand;
            btn_DeleteSelectedData.Dock = DockStyle.Fill;
            btn_DeleteSelectedData.FlatStyle = FlatStyle.Flat;
            btn_DeleteSelectedData.Font = new Font("Microsoft Sans Serif", 11.25F);
            btn_DeleteSelectedData.ForeColor = Color.Silver;
            btn_DeleteSelectedData.Location = new Point(0, 0);
            btn_DeleteSelectedData.Margin = new Padding(0, 0, 0, 6);
            btn_DeleteSelectedData.Name = "btn_DeleteSelectedData";
            btn_DeleteSelectedData.Size = new Size(304, 35);
            btn_DeleteSelectedData.TabIndex = 849;
            btn_DeleteSelectedData.Text = "Radera markerad data";
            btn_DeleteSelectedData.UseVisualStyleBackColor = false;
            btn_DeleteSelectedData.Visible = false;
            btn_DeleteSelectedData.Click += DiscardSelectedData_Click;
            // 
            // chartZumbach
            // 
            chartZumbach.BackColor = Color.Transparent;
            chartZumbach.BorderlineColor = Color.Transparent;
            chartZumbach.BorderlineDashStyle = ChartDashStyle.Solid;
            chartZumbach.BorderSkin.BackColor = Color.Transparent;
            chartZumbach.BorderSkin.BorderDashStyle = ChartDashStyle.Solid;
            chartArea1.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea1.AxisX.LabelStyle.Format = "\" \"";
            chartArea1.AxisX.LabelStyle.IsEndLabelVisible = false;
            chartArea1.AxisX.LineColor = Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = Color.Gray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea1.AxisX.ScaleBreakStyle.LineColor = Color.Aqua;
            stripLine1.BorderColor = Color.Red;
            stripLine1.BorderWidth = 2;
            stripLine1.Text = "slMax";
            stripLine2.BorderColor = Color.Red;
            stripLine2.BorderWidth = 2;
            stripLine2.Text = "slMin";
            chartArea1.AxisX.StripLines.Add(stripLine1);
            chartArea1.AxisX.StripLines.Add(stripLine2);
            chartArea1.AxisX.Title = "Mätning";
            chartArea1.AxisX.TitleFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chartArea1.AxisX.TitleForeColor = Color.Goldenrod;
            chartArea1.AxisX2.LabelStyle.ForeColor = Color.White;
            chartArea1.AxisX2.LineColor = Color.White;
            chartArea1.AxisX2.TitleForeColor = Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea1.AxisY.LineColor = Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = Color.Gray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartArea1.AxisY.TextOrientation = TextOrientation.Horizontal;
            chartArea1.AxisY.Title = "OD";
            chartArea1.AxisY.TitleFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chartArea1.AxisY.TitleForeColor = Color.Goldenrod;
            chartArea1.AxisY2.LineColor = Color.White;
            chartArea1.BackColor = Color.Transparent;
            chartArea1.BorderColor = Color.Transparent;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            chartZumbach.ChartAreas.Add(chartArea1);
            tlp_Panel_Left.SetColumnSpan(chartZumbach, 2);
            chartZumbach.Dock = DockStyle.Fill;
            legend1.BackColor = Color.Transparent;
            legend1.Enabled = false;
            legend1.ForeColor = Color.White;
            legend1.HeaderSeparatorColor = Color.Silver;
            legend1.Name = "Legend1";
            legend1.TableStyle = LegendTableStyle.Wide;
            legend1.TitleForeColor = Color.White;
            chartZumbach.Legends.Add(legend1);
            chartZumbach.Location = new Point(336, 3);
            chartZumbach.Margin = new Padding(4, 3, 4, 3);
            chartZumbach.Name = "chartZumbach";
            chartZumbach.Palette = ChartColorPalette.Light;
            tlp_Panel_Left.SetRowSpan(chartZumbach, 2);
            series1.BorderColor = Color.Red;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Line;
            series1.Color = Color.Yellow;
            series1.LabelBackColor = Color.Black;
            series1.LabelBorderColor = Color.Transparent;
            series1.LabelForeColor = Color.White;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = Color.Maroon;
            series1.Name = "Pos1";
            series1.YValuesPerPoint = 6;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = SeriesChartType.Line;
            series2.Color = Color.White;
            series2.Legend = "Legend1";
            series2.Name = "Pos2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = SeriesChartType.Line;
            series3.Color = Color.Lime;
            series3.Legend = "Legend1";
            series3.Name = "Pos3";
            chartZumbach.Series.Add(series1);
            chartZumbach.Series.Add(series2);
            chartZumbach.Series.Add(series3);
            chartZumbach.Size = new Size(1510, 708);
            chartZumbach.TabIndex = 854;
            chartZumbach.Text = "chart1";
            title1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            title1.ForeColor = Color.Crimson;
            title1.Name = "Title1";
            title1.Visible = false;
            chartZumbach.Titles.Add(title1);
            chartZumbach.AxisViewChanged += Chart_Zumbach_AxisViewChanged;
            chartZumbach.MouseMove += Chart_Zumbach_MouseMove;
            // 
            // tlp_Panel_Left
            // 
            tlp_Panel_Left.ColumnCount = 6;
            tlp_Panel_Left.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tlp_Panel_Left.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
            tlp_Panel_Left.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
            tlp_Panel_Left.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tlp_Panel_Left.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Panel_Left.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tlp_Panel_Left.Controls.Add(chartZumbach, 4, 0);
            tlp_Panel_Left.Controls.Add(flp_Buttons, 0, 1);
            tlp_Panel_Left.Dock = DockStyle.Fill;
            tlp_Panel_Left.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlp_Panel_Left.Location = new Point(0, 255);
            tlp_Panel_Left.Margin = new Padding(4, 3, 4, 3);
            tlp_Panel_Left.Name = "tlp_Panel_Left";
            tlp_Panel_Left.RowCount = 2;
            tlp_Panel_Left.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlp_Panel_Left.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_Panel_Left.Size = new Size(1850, 714);
            tlp_Panel_Left.TabIndex = 868;
            // 
            // flp_Buttons
            // 
            tlp_Panel_Left.SetColumnSpan(flp_Buttons, 4);
            flp_Buttons.Controls.Add(btn_DeleteSelectedData);
            flp_Buttons.Controls.Add(btn_DiscardMeasurement);
            flp_Buttons.Controls.Add(btn_Jämna_Kurvor);
            flp_Buttons.Controls.Add(btn_GetDataOrder);
            flp_Buttons.Controls.Add(btn_GetDataPartNr);
            flp_Buttons.Controls.Add(btn_ZoomOut);
            flp_Buttons.Controls.Add(btn_PrintZumbach);
            flp_Buttons.Dock = DockStyle.Fill;
            flp_Buttons.FlowDirection = FlowDirection.TopDown;
            flp_Buttons.Location = new Point(4, 49);
            flp_Buttons.Margin = new Padding(4, 3, 4, 3);
            flp_Buttons.Name = "flp_Buttons";
            flp_Buttons.Padding = new Padding(0, 0, 0, 6);
            flp_Buttons.Size = new Size(324, 662);
            flp_Buttons.TabIndex = 901;
            // 
            // btn_DiscardMeasurement
            // 
            btn_DiscardMeasurement.BackColor = Color.Transparent;
            btn_DiscardMeasurement.Cursor = Cursors.Hand;
            btn_DiscardMeasurement.FlatStyle = FlatStyle.Flat;
            btn_DiscardMeasurement.Font = new Font("Microsoft Sans Serif", 11.25F);
            btn_DiscardMeasurement.ForeColor = Color.Silver;
            btn_DiscardMeasurement.Location = new Point(0, 41);
            btn_DiscardMeasurement.Margin = new Padding(0, 0, 0, 6);
            btn_DiscardMeasurement.Name = "btn_DiscardMeasurement";
            btn_DiscardMeasurement.Size = new Size(304, 35);
            btn_DiscardMeasurement.TabIndex = 881;
            btn_DiscardMeasurement.Text = "Kassera Mätning";
            btn_DiscardMeasurement.UseVisualStyleBackColor = false;
            btn_DiscardMeasurement.Click += DiscardMeasurement_Click;
            // 
            // btn_GetDataPartNr
            // 
            btn_GetDataPartNr.BackColor = Color.Transparent;
            btn_GetDataPartNr.Cursor = Cursors.Hand;
            btn_GetDataPartNr.FlatStyle = FlatStyle.Flat;
            btn_GetDataPartNr.Font = new Font("Microsoft Sans Serif", 11.25F);
            btn_GetDataPartNr.ForeColor = Color.Silver;
            btn_GetDataPartNr.Location = new Point(0, 164);
            btn_GetDataPartNr.Margin = new Padding(0, 0, 0, 6);
            btn_GetDataPartNr.MinimumSize = new Size(181, 0);
            btn_GetDataPartNr.Name = "btn_GetDataPartNr";
            btn_GetDataPartNr.Size = new Size(304, 35);
            btn_GetDataPartNr.TabIndex = 901;
            btn_GetDataPartNr.Text = "Hämta data från hela artikeln";
            btn_GetDataPartNr.UseVisualStyleBackColor = false;
            btn_GetDataPartNr.Click += LoadData_PartNr_Click;
            // 
            // btn_ZoomOut
            // 
            btn_ZoomOut.BackColor = Color.Transparent;
            btn_ZoomOut.Cursor = Cursors.Hand;
            btn_ZoomOut.FlatStyle = FlatStyle.Flat;
            btn_ZoomOut.Font = new Font("Microsoft Sans Serif", 11.25F);
            btn_ZoomOut.ForeColor = Color.Silver;
            btn_ZoomOut.Location = new Point(0, 205);
            btn_ZoomOut.Margin = new Padding(0, 0, 0, 6);
            btn_ZoomOut.Name = "btn_ZoomOut";
            btn_ZoomOut.Size = new Size(304, 29);
            btn_ZoomOut.TabIndex = 882;
            btn_ZoomOut.Text = "Zoom Out";
            btn_ZoomOut.UseVisualStyleBackColor = false;
            btn_ZoomOut.Click += ZoomOut_Click;
            // 
            // btn_PrintZumbach
            // 
            btn_PrintZumbach.BackColor = Color.Transparent;
            btn_PrintZumbach.Cursor = Cursors.Hand;
            btn_PrintZumbach.FlatStyle = FlatStyle.Flat;
            btn_PrintZumbach.Font = new Font("Microsoft Sans Serif", 11.25F);
            btn_PrintZumbach.ForeColor = Color.Silver;
            btn_PrintZumbach.Location = new Point(0, 240);
            btn_PrintZumbach.Margin = new Padding(0);
            btn_PrintZumbach.Name = "btn_PrintZumbach";
            btn_PrintZumbach.Size = new Size(304, 29);
            btn_PrintZumbach.TabIndex = 849;
            btn_PrintZumbach.Text = "Skriv ut Zumbachmätningar";
            btn_PrintZumbach.UseVisualStyleBackColor = false;
            btn_PrintZumbach.Click += Print_Click;
            // 
            // bgw_Random
            // 
            bgw_Random.WorkerSupportsCancellation = true;
            bgw_Random.DoWork += bgw_GetRandomValues;
            // 
            // MeasureWithZumbach
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1850, 969);
            Controls.Add(tlp_Panel_Left);
            Controls.Add(panel_InfoZumbachChart);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "MeasureWithZumbach";
            RightToLeftLayout = true;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.Manual;
            WindowState = FormWindowState.Maximized;
            Deactivate += Zumbach_Krympslang_Deactivate;
            FormClosed += Zumbach_Krympslang_FormClosed;
            Load += MeasureWithZumbachLoad;
            panel_InfoZumbachChart.ResumeLayout(false);
            tlp_Top.ResumeLayout(false);
            tlp_Top.PerformLayout();
            panel_Position3.ResumeLayout(false);
            panel_Position3.PerformLayout();
            panel_Position2.ResumeLayout(false);
            panel_Position2.PerformLayout();
            panel_Position1.ResumeLayout(false);
            ((ISupportInitialize)pb_Info_UCL_LCL_Styrgränser).EndInit();
            tlp_MåttInfo.ResumeLayout(false);
            tlp_MåttInfo.PerformLayout();
            ((ISupportInitialize)chartZumbach).EndInit();
            tlp_Panel_Left.ResumeLayout(false);
            flp_Buttons.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private BackgroundWorker bgw_Zumbach;
        private CheckBox chb_VisaPos1;
        private CheckBox chb_VisaPos2;
        private CheckBox chb_VisaPos3;
        private Panel panel_InfoZumbachChart;
        private Button btn_GetDataOrder;
        private CheckBox chb_LogData;
        private Label label_Position3;
        private Label label_Position1;
        private Label label_Measurement;
        private RadioButton rb_Position3;
        private RadioButton rb_Position2;
        private RadioButton rb_Position1;
        private Label lbl_OD;
        private CheckBox chb_AutoPosByte;
        private Label label_AVG;
        private Label label_MIN;
        private Label label_MAX;
        private Label lbl_3Avg;
        private Label lbl_2Avg;
        private Label lbl_1Avg;
        private Label lbl_3HiLo;
        private Label lbl_2HiLo;
        private Label lbl_1HiLo;
        private Label label_HiLo;
        private Label lbl_3Min;
        private Label lbl_2Min;
        private Label lbl_1Min;
        private Label lbl_3Max;
        private Label lbl_2Max;
        private Label lbl_1Max;
        private Panel panel_Position1;
        private Label label_Position2;
        private Panel panel_Position3;
        private Panel panel_Position2;
        private Button btn_Up;
        private Button btn_Down;
        private Button btn_Up_Full;
        private Button btn_Down_Full;
        private Button btn_DeleteSelectedData;
        private CheckBox chb_AutoMätByte;
        private Label lbl_OrderNr;
        private Label lbl_Pipe_1;
        private Label lbl_Pipe_3;
        private Label lbl_Pipe_2;
        private TableLayoutPanel tlp_Top;
        private PictureBox pb_Info_UCL_LCL_Styrgränser;
        private TableLayoutPanel tlp_Panel_Left;
        private CheckBox chb_Sortera_Bort_Kasserade;
        private Button btn_DiscardMeasurement;
        private Button btn_ZoomOut;
        private Button btn_PrintZumbach;
        private TableLayoutPanel tlp_MåttInfo;
        private Button btn_Jämna_Kurvor;
        private Label lbl_Maskin;
        private BackgroundWorker bgw_Random;
        private FlowLayoutPanel flp_Buttons;
        private Button btn_GetDataPartNr;
        public Label lbl_Measurement;
        public Chart chartZumbach;
        private Label label_DateTimeMeasurement_Pos1;
        private Label label_DateTimeMeasurement_Pos2;
        private Label label_DateTimeMeasurement_Pos3;
        private Label label_Cpk;
        private Label lbl_1Cpk;
        private Label lbl_2Cpk;
        private Label lbl_3Cpk;
    }
}