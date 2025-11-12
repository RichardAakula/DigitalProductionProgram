using System.ComponentModel;
using System.Windows.Forms;

using DigitalProductionProgram.Measure;
using DigitalProductionProgram.Statistics;

namespace DigitalProductionProgram.MainWindow
{
    sealed partial class Main_Form
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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Main_Form));
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            toolTip1 = new ToolTip(components);
            lbl_Rating = new Label();
            pb_Info_UserPoints = new PictureBox();
            tlp_ExtraInfo = new TableLayoutPanel();
            lbl_ExtraInfo = new Label();
            label_ExtraInfo = new Label();
            measurePoints = new MeasurePoints();
            measureStats = new MainMeasureStatistics();
            OrderInformation = new Main_OrderInformation();
            AQL = new Main_AQL();
            panel_Right = new Panel();
            FeedBackQC = new DigitalProductionProgram.QC.FeedBackQC();
            TipsAndTrix = new DigitalProductionProgram.Övrigt.TipsAndTrix();
            tlp_Top = new TableLayoutPanel();
            MainMenu = new Main_Menu();
            Serverstatus = new ServerStatus();
            RollingInformation = new RollingInformation();
            tlp_Left = new TableLayoutPanel();
            panel_Profile = new Panel();
            tlp_UserInfo = new TableLayoutPanel();
            label_EmpNr = new Label();
            label_Sign = new Label();
            label_Role = new Label();
            lbl_Namn = new Label();
            lbl_EmpNr = new Label();
            lbl_Sign = new Label();
            lbl_Role = new Label();
            pbOperatör = new PictureBox();
            pb_Grade = new PictureBox();
            lbl_Percent = new Label();
            panel_Grade_Percent = new Panel();
            tlp_QuickOpen = new TableLayoutPanel();
            label_Filter = new Label();
            pb_Info_Snabböppna = new PictureBox();
            dgv_QuickOpen = new DataGridView();
            label_QuickOpenOrder = new Label();
            lbl_Company = new Label();
            panel_Background_OptinovaLogo = new Panel();
            pBox_OptinovaLogo = new PictureBox();
            ActiveOrdersUser = new ActiveOrdersUser();
            timer_Check_MeasurePoints = new System.Windows.Forms.Timer(components);
            timer_Check_If_Maintenance_Has_Started = new System.Windows.Forms.Timer(components);
            timer_ReLogin_Monitor = new System.Windows.Forms.Timer(components);
            Buttons = new Main_Buttons();
            PriorityPlanning = new Main_Priorityplanning();
            panel_Bottom = new Panel();
            spitContainer_Bottom = new SplitContainer();
            splitContainer_Right = new SplitContainer();
            tlp_MainWindow = new TableLayoutPanel();
            Statistics_DPP = new Statistics_DPP();
            measurementChart = new MeasurementChart();
            ((ISupportInitialize)pb_Info_UserPoints).BeginInit();
            tlp_ExtraInfo.SuspendLayout();
            panel_Right.SuspendLayout();
            tlp_Top.SuspendLayout();
            tlp_Left.SuspendLayout();
            panel_Profile.SuspendLayout();
            tlp_UserInfo.SuspendLayout();
            ((ISupportInitialize)pbOperatör).BeginInit();
            ((ISupportInitialize)pb_Grade).BeginInit();
            tlp_QuickOpen.SuspendLayout();
            ((ISupportInitialize)pb_Info_Snabböppna).BeginInit();
            ((ISupportInitialize)dgv_QuickOpen).BeginInit();
            panel_Background_OptinovaLogo.SuspendLayout();
            ((ISupportInitialize)pBox_OptinovaLogo).BeginInit();
            panel_Bottom.SuspendLayout();
            ((ISupportInitialize)spitContainer_Bottom).BeginInit();
            spitContainer_Bottom.Panel1.SuspendLayout();
            spitContainer_Bottom.Panel2.SuspendLayout();
            spitContainer_Bottom.SuspendLayout();
            ((ISupportInitialize)splitContainer_Right).BeginInit();
            splitContainer_Right.Panel1.SuspendLayout();
            splitContainer_Right.Panel2.SuspendLayout();
            splitContainer_Right.SuspendLayout();
            tlp_MainWindow.SuspendLayout();
            SuspendLayout();
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 0;
            toolTip1.IsBalloon = true;
            toolTip1.ShowAlways = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            // 
            // lbl_Rating
            // 
            lbl_Rating.AutoSize = true;
            lbl_Rating.BackColor = Color.Transparent;
            lbl_Rating.Font = new Font("Consolas", 40.75F);
            lbl_Rating.ForeColor = SystemColors.ButtonHighlight;
            lbl_Rating.Location = new Point(934, 123);
            lbl_Rating.Margin = new Padding(0);
            lbl_Rating.Name = "lbl_Rating";
            lbl_Rating.Size = new Size(58, 65);
            lbl_Rating.TabIndex = 900;
            lbl_Rating.Text = "1";
            lbl_Rating.TextAlign = ContentAlignment.MiddleCenter;
            toolTip1.SetToolTip(lbl_Rating, "Poäng på denna order baserat på materialet.");
            lbl_Rating.Visible = false;
            // 
            // pb_Info_UserPoints
            // 
            pb_Info_UserPoints.BackColor = Color.Transparent;
            pb_Info_UserPoints.BackgroundImage = (Image)resources.GetObject("pb_Info_UserPoints.BackgroundImage");
            pb_Info_UserPoints.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info_UserPoints.Cursor = Cursors.Hand;
            pb_Info_UserPoints.Location = new Point(938, 81);
            pb_Info_UserPoints.Margin = new Padding(4, 12, 4, 3);
            pb_Info_UserPoints.Name = "pb_Info_UserPoints";
            pb_Info_UserPoints.Size = new Size(41, 39);
            pb_Info_UserPoints.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Info_UserPoints.TabIndex = 870;
            pb_Info_UserPoints.TabStop = false;
            pb_Info_UserPoints.Visible = false;
            pb_Info_UserPoints.Click += Info_Poäng_Click;
            // 
            // tlp_ExtraInfo
            // 
            tlp_ExtraInfo.BackColor = Color.FromArgb(60, 60, 60);
            tlp_ExtraInfo.ColumnCount = 1;
            tlp_ExtraInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_ExtraInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tlp_ExtraInfo.Controls.Add(lbl_ExtraInfo, 0, 1);
            tlp_ExtraInfo.Controls.Add(label_ExtraInfo, 0, 0);
            tlp_ExtraInfo.Dock = DockStyle.Fill;
            tlp_ExtraInfo.Location = new Point(1108, 198);
            tlp_ExtraInfo.Margin = new Padding(4, 3, 4, 3);
            tlp_ExtraInfo.Name = "tlp_ExtraInfo";
            tlp_ExtraInfo.RowCount = 2;
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle());
            tlp_ExtraInfo.Size = new Size(207, 158);
            tlp_ExtraInfo.TabIndex = 906;
            tlp_ExtraInfo.Visible = false;
            // 
            // lbl_ExtraInfo
            // 
            lbl_ExtraInfo.AutoSize = true;
            lbl_ExtraInfo.BackColor = Color.Transparent;
            lbl_ExtraInfo.Dock = DockStyle.Fill;
            lbl_ExtraInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_ExtraInfo.ForeColor = Color.Black;
            lbl_ExtraInfo.Location = new Point(0, 29);
            lbl_ExtraInfo.Margin = new Padding(0);
            lbl_ExtraInfo.Name = "lbl_ExtraInfo";
            lbl_ExtraInfo.Size = new Size(207, 129);
            lbl_ExtraInfo.TabIndex = 0;
            lbl_ExtraInfo.Text = "Extra Info";
            // 
            // label_ExtraInfo
            // 
            label_ExtraInfo.BackColor = Color.Transparent;
            label_ExtraInfo.Dock = DockStyle.Fill;
            label_ExtraInfo.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold);
            label_ExtraInfo.ForeColor = Color.Moccasin;
            label_ExtraInfo.Location = new Point(0, 0);
            label_ExtraInfo.Margin = new Padding(0);
            label_ExtraInfo.Name = "label_ExtraInfo";
            label_ExtraInfo.Size = new Size(207, 29);
            label_ExtraInfo.TabIndex = 892;
            label_ExtraInfo.Text = "Extrainformation:";
            label_ExtraInfo.TextAlign = ContentAlignment.MiddleCenter;
            label_ExtraInfo.Visible = false;
            // 
            // measurePoints
            // 
            measurePoints.BackColor = Color.Transparent;
            measurePoints.Dock = DockStyle.Fill;
            measurePoints.Location = new Point(6, 195);
            measurePoints.Margin = new Padding(6, 0, 0, 0);
            measurePoints.Name = "measurePoints";
            measurePoints.Size = new Size(531, 164);
            measurePoints.TabIndex = 915;
            measurePoints.Visible = false;
            // 
            // measureStats
            // 
            measureStats.BackColor = Color.Transparent;
            measureStats.Dock = DockStyle.Fill;
            measureStats.Location = new Point(549, 195);
            measureStats.Margin = new Padding(12, 0, 0, 0);
            measureStats.Name = "measureStats";
            measureStats.Size = new Size(385, 164);
            measureStats.TabIndex = 916;
            measureStats.Visible = false;
            // 
            // OrderInformation
            // 
            OrderInformation.BackColor = Color.FromArgb(60, 60, 60);
            tlp_MainWindow.SetColumnSpan(OrderInformation, 2);
            OrderInformation.Location = new Point(6, 6);
            OrderInformation.Margin = new Padding(6, 6, 0, 3);
            OrderInformation.Name = "OrderInformation";
            tlp_MainWindow.SetRowSpan(OrderInformation, 3);
            OrderInformation.Size = new Size(928, 186);
            OrderInformation.TabIndex = 918;
            // 
            // AQL
            // 
            AQL.BackColor = Color.FromArgb(60, 60, 60);
            AQL.Dock = DockStyle.Left;
            AQL.Location = new Point(1104, 3);
            AQL.Margin = new Padding(0, 3, 4, 23);
            AQL.Name = "AQL";
            tlp_MainWindow.SetRowSpan(AQL, 3);
            AQL.Size = new Size(211, 169);
            AQL.TabIndex = 919;
            AQL.Visible = false;
            // 
            // panel_Right
            // 
            panel_Right.Controls.Add(FeedBackQC);
            panel_Right.Controls.Add(TipsAndTrix);
            panel_Right.Dock = DockStyle.Fill;
            panel_Right.Location = new Point(0, 0);
            panel_Right.Margin = new Padding(2, 3, 4, 3);
            panel_Right.Name = "panel_Right";
            panel_Right.Size = new Size(280, 706);
            panel_Right.TabIndex = 921;
            // 
            // FeedBackQC
            // 
            FeedBackQC.BackColor = Color.FromArgb(120, 20, 20);
            FeedBackQC.Dock = DockStyle.Fill;
            FeedBackQC.Location = new Point(0, 324);
            FeedBackQC.Margin = new Padding(0);
            FeedBackQC.MinimumSize = new Size(350, 0);
            FeedBackQC.Name = "FeedBackQC";
            FeedBackQC.Size = new Size(350, 382);
            FeedBackQC.TabIndex = 913;
            FeedBackQC.Visible = false;
            // 
            // TipsAndTrix
            // 
            TipsAndTrix.BackColor = Color.Transparent;
            TipsAndTrix.Dock = DockStyle.Top;
            TipsAndTrix.Location = new Point(0, 0);
            TipsAndTrix.Margin = new Padding(5, 3, 5, 3);
            TipsAndTrix.Name = "TipsAndTrix";
            TipsAndTrix.Size = new Size(280, 324);
            TipsAndTrix.TabIndex = 914;
            TipsAndTrix.Visible = false;
            // 
            // tlp_Top
            // 
            tlp_Top.BackColor = Color.FromArgb(25, 25, 25);
            tlp_Top.ColumnCount = 3;
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 665F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 169F));
            tlp_Top.Controls.Add(MainMenu, 0, 0);
            tlp_Top.Controls.Add(Serverstatus, 2, 0);
            tlp_Top.Controls.Add(RollingInformation, 1, 0);
            tlp_Top.Dock = DockStyle.Top;
            tlp_Top.Location = new Point(0, 0);
            tlp_Top.Margin = new Padding(0);
            tlp_Top.Name = "tlp_Top";
            tlp_Top.RowCount = 1;
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Top.Size = new Size(1924, 43);
            tlp_Top.TabIndex = 912;
            // 
            // MainMenu
            // 
            MainMenu.AutoSize = true;
            MainMenu.BackColor = Color.Transparent;
            MainMenu.Dock = DockStyle.Fill;
            MainMenu.Location = new Point(0, 0);
            MainMenu.Margin = new Padding(0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(665, 43);
            MainMenu.TabIndex = 894;
            // 
            // Serverstatus
            // 
            Serverstatus.Dock = DockStyle.Fill;
            Serverstatus.Location = new Point(1760, 3);
            Serverstatus.Margin = new Padding(5, 3, 5, 3);
            Serverstatus.Name = "Serverstatus";
            Serverstatus.Size = new Size(159, 37);
            Serverstatus.TabIndex = 895;
            // 
            // RollingInformation
            // 
            RollingInformation.BackColor = Color.Transparent;
            RollingInformation.Dock = DockStyle.Fill;
            RollingInformation.Location = new Point(669, 3);
            RollingInformation.Margin = new Padding(4, 3, 4, 3);
            RollingInformation.Name = "RollingInformation";
            RollingInformation.Size = new Size(1082, 37);
            RollingInformation.TabIndex = 896;
            // 
            // tlp_Left
            // 
            tlp_Left.BackColor = Color.FromArgb(25, 25, 25);
            tlp_Left.ColumnCount = 1;
            tlp_Left.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Left.Controls.Add(panel_Profile, 0, 2);
            tlp_Left.Controls.Add(tlp_QuickOpen, 0, 4);
            tlp_Left.Controls.Add(lbl_Company, 0, 1);
            tlp_Left.Controls.Add(panel_Background_OptinovaLogo, 0, 0);
            tlp_Left.Controls.Add(ActiveOrdersUser, 0, 3);
            tlp_Left.Dock = DockStyle.Left;
            tlp_Left.Location = new Point(0, 43);
            tlp_Left.Margin = new Padding(0);
            tlp_Left.Name = "tlp_Left";
            tlp_Left.RowCount = 5;
            tlp_Left.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            tlp_Left.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tlp_Left.RowStyles.Add(new RowStyle(SizeType.Absolute, 338F));
            tlp_Left.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Left.RowStyles.Add(new RowStyle(SizeType.Absolute, 332F));
            tlp_Left.Size = new Size(318, 1018);
            tlp_Left.TabIndex = 920;
            // 
            // panel_Profile
            // 
            panel_Profile.BackColor = Color.Transparent;
            panel_Profile.Controls.Add(tlp_UserInfo);
            panel_Profile.Controls.Add(pbOperatör);
            panel_Profile.Controls.Add(pb_Grade);
            panel_Profile.Controls.Add(lbl_Percent);
            panel_Profile.Controls.Add(panel_Grade_Percent);
            panel_Profile.Dock = DockStyle.Fill;
            panel_Profile.Location = new Point(0, 133);
            panel_Profile.Margin = new Padding(0);
            panel_Profile.Name = "panel_Profile";
            panel_Profile.Size = new Size(318, 338);
            panel_Profile.TabIndex = 863;
            panel_Profile.Visible = false;
            // 
            // tlp_UserInfo
            // 
            tlp_UserInfo.ColumnCount = 2;
            tlp_UserInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.25203F));
            tlp_UserInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.74797F));
            tlp_UserInfo.Controls.Add(label_EmpNr, 0, 1);
            tlp_UserInfo.Controls.Add(label_Sign, 0, 2);
            tlp_UserInfo.Controls.Add(label_Role, 0, 3);
            tlp_UserInfo.Controls.Add(lbl_Namn, 0, 0);
            tlp_UserInfo.Controls.Add(lbl_EmpNr, 1, 1);
            tlp_UserInfo.Controls.Add(lbl_Sign, 1, 2);
            tlp_UserInfo.Controls.Add(lbl_Role, 1, 3);
            tlp_UserInfo.Location = new Point(8, 218);
            tlp_UserInfo.Margin = new Padding(4, 3, 4, 3);
            tlp_UserInfo.Name = "tlp_UserInfo";
            tlp_UserInfo.RowCount = 4;
            tlp_UserInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_UserInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_UserInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_UserInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_UserInfo.Size = new Size(287, 117);
            tlp_UserInfo.TabIndex = 859;
            // 
            // label_EmpNr
            // 
            label_EmpNr.AutoSize = true;
            label_EmpNr.BackColor = Color.Transparent;
            label_EmpNr.Cursor = Cursors.Hand;
            label_EmpNr.Dock = DockStyle.Fill;
            label_EmpNr.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_EmpNr.ForeColor = SystemColors.Info;
            label_EmpNr.Location = new Point(4, 29);
            label_EmpNr.Margin = new Padding(4, 0, 4, 0);
            label_EmpNr.Name = "label_EmpNr";
            label_EmpNr.Size = new Size(144, 29);
            label_EmpNr.TabIndex = 356;
            label_EmpNr.Text = "Anst.Nr:";
            label_EmpNr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Sign
            // 
            label_Sign.AutoSize = true;
            label_Sign.BackColor = Color.Transparent;
            label_Sign.Cursor = Cursors.Hand;
            label_Sign.Dock = DockStyle.Fill;
            label_Sign.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Sign.ForeColor = SystemColors.Info;
            label_Sign.Location = new Point(4, 58);
            label_Sign.Margin = new Padding(4, 0, 4, 0);
            label_Sign.Name = "label_Sign";
            label_Sign.Size = new Size(144, 29);
            label_Sign.TabIndex = 358;
            label_Sign.Text = "Sign:";
            label_Sign.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Role
            // 
            label_Role.AutoSize = true;
            label_Role.BackColor = Color.Transparent;
            label_Role.Cursor = Cursors.Hand;
            label_Role.Dock = DockStyle.Fill;
            label_Role.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Role.ForeColor = SystemColors.Info;
            label_Role.Location = new Point(4, 87);
            label_Role.Margin = new Padding(4, 0, 4, 0);
            label_Role.Name = "label_Role";
            label_Role.Size = new Size(144, 30);
            label_Role.TabIndex = 360;
            label_Role.Text = "Befattning:";
            label_Role.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Namn
            // 
            lbl_Namn.BackColor = Color.Transparent;
            tlp_UserInfo.SetColumnSpan(lbl_Namn, 2);
            lbl_Namn.Dock = DockStyle.Fill;
            lbl_Namn.Font = new Font("Microsoft Sans Serif", 11.75F, FontStyle.Bold);
            lbl_Namn.ForeColor = Color.White;
            lbl_Namn.Location = new Point(4, 0);
            lbl_Namn.Margin = new Padding(4, 0, 4, 0);
            lbl_Namn.Name = "lbl_Namn";
            lbl_Namn.Size = new Size(279, 29);
            lbl_Namn.TabIndex = 363;
            lbl_Namn.Click += SignIn_Click;
            // 
            // lbl_EmpNr
            // 
            lbl_EmpNr.BackColor = Color.Transparent;
            lbl_EmpNr.Cursor = Cursors.Hand;
            lbl_EmpNr.Dock = DockStyle.Fill;
            lbl_EmpNr.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_EmpNr.ForeColor = Color.White;
            lbl_EmpNr.Location = new Point(156, 29);
            lbl_EmpNr.Margin = new Padding(4, 0, 4, 0);
            lbl_EmpNr.Name = "lbl_EmpNr";
            lbl_EmpNr.Size = new Size(127, 29);
            lbl_EmpNr.TabIndex = 357;
            lbl_EmpNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Sign
            // 
            lbl_Sign.BackColor = Color.Transparent;
            lbl_Sign.Cursor = Cursors.Hand;
            lbl_Sign.Dock = DockStyle.Fill;
            lbl_Sign.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Sign.ForeColor = Color.White;
            lbl_Sign.Location = new Point(156, 58);
            lbl_Sign.Margin = new Padding(4, 0, 4, 0);
            lbl_Sign.Name = "lbl_Sign";
            lbl_Sign.Size = new Size(127, 29);
            lbl_Sign.TabIndex = 359;
            lbl_Sign.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Role
            // 
            lbl_Role.BackColor = Color.Transparent;
            lbl_Role.Cursor = Cursors.Hand;
            lbl_Role.Dock = DockStyle.Fill;
            lbl_Role.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Role.ForeColor = Color.White;
            lbl_Role.Location = new Point(156, 87);
            lbl_Role.Margin = new Padding(4, 0, 4, 0);
            lbl_Role.Name = "lbl_Role";
            lbl_Role.Size = new Size(127, 30);
            lbl_Role.TabIndex = 362;
            lbl_Role.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pbOperatör
            // 
            pbOperatör.BackColor = Color.Transparent;
            pbOperatör.BackgroundImageLayout = ImageLayout.Stretch;
            pbOperatör.Cursor = Cursors.Hand;
            pbOperatör.Location = new Point(23, 10);
            pbOperatör.Margin = new Padding(4, 3, 4, 3);
            pbOperatör.Name = "pbOperatör";
            pbOperatör.Size = new Size(146, 201);
            pbOperatör.SizeMode = PictureBoxSizeMode.StretchImage;
            pbOperatör.TabIndex = 353;
            pbOperatör.TabStop = false;
            pbOperatör.Click += SignIn_Click;
            // 
            // pb_Grade
            // 
            pb_Grade.BackColor = Color.Transparent;
            pb_Grade.BackgroundImageLayout = ImageLayout.Zoom;
            pb_Grade.BorderStyle = BorderStyle.Fixed3D;
            pb_Grade.Cursor = Cursors.IBeam;
            pb_Grade.Location = new Point(176, 6);
            pb_Grade.Margin = new Padding(4, 3, 4, 3);
            pb_Grade.Name = "pb_Grade";
            pb_Grade.Size = new Size(58, 80);
            pb_Grade.TabIndex = 857;
            pb_Grade.TabStop = false;
            pb_Grade.Visible = false;
            pb_Grade.Click += EasterEgg_1_Click;
            // 
            // lbl_Percent
            // 
            lbl_Percent.BackColor = Color.Transparent;
            lbl_Percent.Font = new Font("Microsoft Sans Serif", 6.25F);
            lbl_Percent.ForeColor = Color.White;
            lbl_Percent.Location = new Point(229, 89);
            lbl_Percent.Margin = new Padding(4, 0, 4, 0);
            lbl_Percent.Name = "lbl_Percent";
            lbl_Percent.Size = new Size(43, 16);
            lbl_Percent.TabIndex = 0;
            lbl_Percent.Text = "100 %";
            lbl_Percent.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Percent.Visible = false;
            // 
            // panel_Grade_Percent
            // 
            panel_Grade_Percent.BackColor = Color.Black;
            panel_Grade_Percent.Location = new Point(178, 6);
            panel_Grade_Percent.Margin = new Padding(4, 3, 4, 3);
            panel_Grade_Percent.Name = "panel_Grade_Percent";
            panel_Grade_Percent.Size = new Size(93, 81);
            panel_Grade_Percent.TabIndex = 858;
            panel_Grade_Percent.Visible = false;
            // 
            // tlp_QuickOpen
            // 
            tlp_QuickOpen.BackColor = Color.Pink;
            tlp_QuickOpen.ColumnCount = 2;
            tlp_QuickOpen.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            tlp_QuickOpen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_QuickOpen.Controls.Add(label_Filter, 1, 0);
            tlp_QuickOpen.Controls.Add(pb_Info_Snabböppna, 0, 0);
            tlp_QuickOpen.Controls.Add(dgv_QuickOpen, 0, 3);
            tlp_QuickOpen.Controls.Add(label_QuickOpenOrder, 0, 2);
            tlp_QuickOpen.Dock = DockStyle.Left;
            tlp_QuickOpen.Location = new Point(2, 689);
            tlp_QuickOpen.Margin = new Padding(2, 3, 0, 0);
            tlp_QuickOpen.Name = "tlp_QuickOpen";
            tlp_QuickOpen.RowCount = 4;
            tlp_QuickOpen.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_QuickOpen.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlp_QuickOpen.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_QuickOpen.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tlp_QuickOpen.Size = new Size(316, 329);
            tlp_QuickOpen.TabIndex = 13;
            // 
            // label_Filter
            // 
            label_Filter.BackColor = Color.LightYellow;
            label_Filter.Cursor = Cursors.Hand;
            label_Filter.Font = new Font("Lucida Sans", 9F, FontStyle.Bold);
            label_Filter.ForeColor = Color.DimGray;
            label_Filter.Location = new Point(55, 0);
            label_Filter.Margin = new Padding(0);
            label_Filter.Name = "label_Filter";
            label_Filter.Size = new Size(261, 23);
            label_Filter.TabIndex = 873;
            label_Filter.Text = "Filtrera arbetsoperationer";
            label_Filter.TextAlign = ContentAlignment.MiddleLeft;
            label_Filter.Click += FilterWorkoperations_Click;
            // 
            // pb_Info_Snabböppna
            // 
            pb_Info_Snabböppna.BackColor = Color.Transparent;
            pb_Info_Snabböppna.BackgroundImage = (Image)resources.GetObject("pb_Info_Snabböppna.BackgroundImage");
            pb_Info_Snabböppna.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info_Snabböppna.Cursor = Cursors.Hand;
            pb_Info_Snabböppna.Location = new Point(4, 3);
            pb_Info_Snabböppna.Margin = new Padding(4, 3, 4, 3);
            pb_Info_Snabböppna.Name = "pb_Info_Snabböppna";
            tlp_QuickOpen.SetRowSpan(pb_Info_Snabböppna, 2);
            pb_Info_Snabböppna.Size = new Size(40, 38);
            pb_Info_Snabböppna.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Info_Snabböppna.TabIndex = 870;
            pb_Info_Snabböppna.TabStop = false;
            pb_Info_Snabböppna.Click += Info_Snabböppna_Click;
            // 
            // dgv_QuickOpen
            // 
            dgv_QuickOpen.AllowUserToAddRows = false;
            dgv_QuickOpen.AllowUserToDeleteRows = false;
            dgv_QuickOpen.AllowUserToResizeColumns = false;
            dgv_QuickOpen.AllowUserToResizeRows = false;
            dgv_QuickOpen.BackgroundColor = Color.FromArgb(60, 60, 60);
            dgv_QuickOpen.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_QuickOpen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_QuickOpen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_QuickOpen.ColumnHeadersVisible = false;
            tlp_QuickOpen.SetColumnSpan(dgv_QuickOpen, 2);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgv_QuickOpen.DefaultCellStyle = dataGridViewCellStyle5;
            dgv_QuickOpen.Dock = DockStyle.Fill;
            dgv_QuickOpen.Location = new Point(0, 75);
            dgv_QuickOpen.Margin = new Padding(0, 3, 0, 0);
            dgv_QuickOpen.Name = "dgv_QuickOpen";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgv_QuickOpen.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgv_QuickOpen.RowHeadersVisible = false;
            dgv_QuickOpen.RowHeadersWidth = 51;
            dgv_QuickOpen.ScrollBars = ScrollBars.None;
            dgv_QuickOpen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_QuickOpen.Size = new Size(316, 254);
            dgv_QuickOpen.TabIndex = 8;
            dgv_QuickOpen.CellClick += QuickOpen_CellClick;
            // 
            // label_QuickOpenOrder
            // 
            label_QuickOpenOrder.BackColor = Color.Transparent;
            tlp_QuickOpen.SetColumnSpan(label_QuickOpenOrder, 2);
            label_QuickOpenOrder.Dock = DockStyle.Fill;
            label_QuickOpenOrder.Font = new Font("Palatino Linotype", 11F, FontStyle.Bold);
            label_QuickOpenOrder.ForeColor = Color.Snow;
            label_QuickOpenOrder.Location = new Point(4, 48);
            label_QuickOpenOrder.Margin = new Padding(4, 1, 0, 0);
            label_QuickOpenOrder.Name = "label_QuickOpenOrder";
            label_QuickOpenOrder.Size = new Size(312, 24);
            label_QuickOpenOrder.TabIndex = 7;
            label_QuickOpenOrder.Text = "Öppna senaste startade order";
            label_QuickOpenOrder.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Company
            // 
            lbl_Company.BackColor = Color.Transparent;
            lbl_Company.Cursor = Cursors.Hand;
            lbl_Company.Dock = DockStyle.Top;
            lbl_Company.Font = new Font("Times New Roman", 28F, FontStyle.Bold);
            lbl_Company.ForeColor = Color.FromArgb(171, 150, 85);
            lbl_Company.Location = new Point(4, 82);
            lbl_Company.Margin = new Padding(4, 0, 4, 0);
            lbl_Company.Name = "lbl_Company";
            lbl_Company.Size = new Size(310, 51);
            lbl_Company.TabIndex = 862;
            lbl_Company.Text = "Company";
            lbl_Company.TextAlign = ContentAlignment.TopCenter;
            lbl_Company.Click += SignIn_Click;
            // 
            // panel_Background_OptinovaLogo
            // 
            panel_Background_OptinovaLogo.BackColor = Color.FromArgb(230, 230, 230);
            panel_Background_OptinovaLogo.Controls.Add(pBox_OptinovaLogo);
            panel_Background_OptinovaLogo.Dock = DockStyle.Fill;
            panel_Background_OptinovaLogo.Location = new Point(0, 0);
            panel_Background_OptinovaLogo.Margin = new Padding(0);
            panel_Background_OptinovaLogo.Name = "panel_Background_OptinovaLogo";
            panel_Background_OptinovaLogo.Size = new Size(318, 82);
            panel_Background_OptinovaLogo.TabIndex = 865;
            // 
            // pBox_OptinovaLogo
            // 
            pBox_OptinovaLogo.BackColor = Color.Transparent;
            pBox_OptinovaLogo.BackgroundImageLayout = ImageLayout.Stretch;
            pBox_OptinovaLogo.Cursor = Cursors.Hand;
            pBox_OptinovaLogo.Dock = DockStyle.Fill;
            pBox_OptinovaLogo.Image = Properties.Resources.NewLogo;
            pBox_OptinovaLogo.Location = new Point(0, 0);
            pBox_OptinovaLogo.Margin = new Padding(0);
            pBox_OptinovaLogo.Name = "pBox_OptinovaLogo";
            pBox_OptinovaLogo.Size = new Size(318, 82);
            pBox_OptinovaLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pBox_OptinovaLogo.TabIndex = 5;
            pBox_OptinovaLogo.TabStop = false;
            pBox_OptinovaLogo.Click += EasterEgg_2_Click;
            // 
            // ActiveOrdersUser
            // 
            ActiveOrdersUser.BackColor = Color.FromArgb(60, 60, 60);
            ActiveOrdersUser.Dock = DockStyle.Fill;
            ActiveOrdersUser.Location = new Point(4, 474);
            ActiveOrdersUser.Margin = new Padding(4, 3, 4, 3);
            ActiveOrdersUser.Name = "ActiveOrdersUser";
            ActiveOrdersUser.Size = new Size(310, 209);
            ActiveOrdersUser.TabIndex = 866;
            // 
            // Buttons
            // 
            Buttons.BackColor = Color.FromArgb(60, 60, 60);
            Buttons.Dock = DockStyle.Top;
            Buttons.Location = new Point(318, 43);
            Buttons.Margin = new Padding(0);
            Buttons.Name = "Buttons";
            Buttons.Size = new Size(1606, 45);
            Buttons.TabIndex = 917;
            // 
            // PriorityPlanning
            // 
            PriorityPlanning.BackColor = Color.FromArgb(60, 60, 60);
            PriorityPlanning.Dock = DockStyle.Fill;
            PriorityPlanning.Location = new Point(0, 0);
            PriorityPlanning.Margin = new Padding(0);
            PriorityPlanning.Name = "PriorityPlanning";
            PriorityPlanning.Padding = new Padding(0, 0, 10, 0);
            PriorityPlanning.Size = new Size(1606, 260);
            PriorityPlanning.TabIndex = 14;
            // 
            // panel_Bottom
            // 
            panel_Bottom.Controls.Add(PriorityPlanning);
            panel_Bottom.Dock = DockStyle.Fill;
            panel_Bottom.Location = new Point(0, 0);
            panel_Bottom.Margin = new Padding(4, 3, 4, 3);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(1606, 260);
            panel_Bottom.TabIndex = 0;
            // 
            // spitContainer_Bottom
            // 
            spitContainer_Bottom.BackColor = Color.Transparent;
            spitContainer_Bottom.Dock = DockStyle.Fill;
            spitContainer_Bottom.Location = new Point(318, 88);
            spitContainer_Bottom.Name = "spitContainer_Bottom";
            spitContainer_Bottom.Orientation = Orientation.Horizontal;
            // 
            // spitContainer_Bottom.Panel1
            // 
            spitContainer_Bottom.Panel1.Controls.Add(splitContainer_Right);
            // 
            // spitContainer_Bottom.Panel2
            // 
            spitContainer_Bottom.Panel2.Controls.Add(panel_Bottom);
            spitContainer_Bottom.Size = new Size(1606, 973);
            spitContainer_Bottom.SplitterDistance = 706;
            spitContainer_Bottom.SplitterWidth = 7;
            spitContainer_Bottom.TabIndex = 922;
            // 
            // splitContainer_Right
            // 
            splitContainer_Right.BackColor = Color.Transparent;
            splitContainer_Right.Dock = DockStyle.Fill;
            splitContainer_Right.Location = new Point(0, 0);
            splitContainer_Right.Name = "splitContainer_Right";
            // 
            // splitContainer_Right.Panel1
            // 
            splitContainer_Right.Panel1.Controls.Add(tlp_MainWindow);
            // 
            // splitContainer_Right.Panel2
            // 
            splitContainer_Right.Panel2.Controls.Add(panel_Right);
            splitContainer_Right.Size = new Size(1606, 706);
            splitContainer_Right.SplitterDistance = 1319;
            splitContainer_Right.SplitterWidth = 7;
            splitContainer_Right.TabIndex = 0;
            // 
            // tlp_MainWindow
            // 
            tlp_MainWindow.BackColor = Color.Transparent;
            tlp_MainWindow.ColumnCount = 5;
            tlp_MainWindow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 537F));
            tlp_MainWindow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 397F));
            tlp_MainWindow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            tlp_MainWindow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
            tlp_MainWindow.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            tlp_MainWindow.Controls.Add(pb_Info_UserPoints, 2, 1);
            tlp_MainWindow.Controls.Add(tlp_ExtraInfo, 4, 3);
            tlp_MainWindow.Controls.Add(lbl_Rating, 2, 2);
            tlp_MainWindow.Controls.Add(AQL, 4, 0);
            tlp_MainWindow.Controls.Add(OrderInformation, 0, 0);
            tlp_MainWindow.Controls.Add(measurePoints, 0, 3);
            tlp_MainWindow.Controls.Add(measureStats, 1, 3);
            tlp_MainWindow.Controls.Add(Statistics_DPP, 3, 4);
            tlp_MainWindow.Controls.Add(measurementChart, 0, 4);
            tlp_MainWindow.Dock = DockStyle.Fill;
            tlp_MainWindow.Location = new Point(0, 0);
            tlp_MainWindow.Margin = new Padding(4, 3, 3, 3);
            tlp_MainWindow.Name = "tlp_MainWindow";
            tlp_MainWindow.RowCount = 5;
            tlp_MainWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tlp_MainWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tlp_MainWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tlp_MainWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 164F));
            tlp_MainWindow.RowStyles.Add(new RowStyle(SizeType.Absolute, 87F));
            tlp_MainWindow.Size = new Size(1319, 706);
            tlp_MainWindow.TabIndex = 0;
            // 
            // Statistics_DPP
            // 
            Statistics_DPP.BackColor = Color.Transparent;
            tlp_MainWindow.SetColumnSpan(Statistics_DPP, 2);
            Statistics_DPP.Dock = DockStyle.Fill;
            Statistics_DPP.Location = new Point(1000, 362);
            Statistics_DPP.Margin = new Padding(4, 3, 4, 3);
            Statistics_DPP.Name = "Statistics_DPP";
            Statistics_DPP.Size = new Size(315, 341);
            Statistics_DPP.TabIndex = 920;
            // 
            // measurementChart
            // 
            measurementChart.BackColor = Color.Transparent;
            tlp_MainWindow.SetColumnSpan(measurementChart, 3);
            measurementChart.Dock = DockStyle.Fill;
            measurementChart.Location = new Point(6, 361);
            measurementChart.Margin = new Padding(6, 2, 0, 0);
            measurementChart.Name = "measurementChart";
            measurementChart.Size = new Size(990, 345);
            measurementChart.TabIndex = 921;
            measurementChart.Visible = false;
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1924, 1061);
            Controls.Add(spitContainer_Bottom);
            Controls.Add(Buttons);
            Controls.Add(tlp_Left);
            Controls.Add(tlp_Top);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main_Form";
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = true;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.Manual;
            Text = "Digitala Process Program";
            TransparencyKey = Color.Fuchsia;
            WindowState = FormWindowState.Maximized;
            FormClosing += MainForm_FormClosing;
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            ((ISupportInitialize)pb_Info_UserPoints).EndInit();
            tlp_ExtraInfo.ResumeLayout(false);
            tlp_ExtraInfo.PerformLayout();
            panel_Right.ResumeLayout(false);
            tlp_Top.ResumeLayout(false);
            tlp_Top.PerformLayout();
            tlp_Left.ResumeLayout(false);
            panel_Profile.ResumeLayout(false);
            tlp_UserInfo.ResumeLayout(false);
            tlp_UserInfo.PerformLayout();
            ((ISupportInitialize)pbOperatör).EndInit();
            ((ISupportInitialize)pb_Grade).EndInit();
            tlp_QuickOpen.ResumeLayout(false);
            ((ISupportInitialize)pb_Info_Snabböppna).EndInit();
            ((ISupportInitialize)dgv_QuickOpen).EndInit();
            panel_Background_OptinovaLogo.ResumeLayout(false);
            ((ISupportInitialize)pBox_OptinovaLogo).EndInit();
            panel_Bottom.ResumeLayout(false);
            spitContainer_Bottom.Panel1.ResumeLayout(false);
            spitContainer_Bottom.Panel2.ResumeLayout(false);
            ((ISupportInitialize)spitContainer_Bottom).EndInit();
            spitContainer_Bottom.ResumeLayout(false);
            splitContainer_Right.Panel1.ResumeLayout(false);
            splitContainer_Right.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer_Right).EndInit();
            splitContainer_Right.ResumeLayout(false);
            tlp_MainWindow.ResumeLayout(false);
            tlp_MainWindow.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        //private ElementHost elementHost1;
        private ToolTip toolTip1;
        private TableLayoutPanel tlp_MainWindow;
        private Label lbl_ExtraInfo;
        private Label label_ExtraInfo;
        private Label lbl_Rating;
        private PictureBox pb_Info_UserPoints;
        public TableLayoutPanel tlp_Top;
        public TableLayoutPanel tlp_ExtraInfo;
        private System.Windows.Forms.Timer timer_Check_MeasurePoints;
        private System.Windows.Forms.Timer timer_Check_If_Maintenance_Has_Started;
       
        public MainMeasureStatistics measureStats;
        public MeasurePoints measurePoints;
        public Main_OrderInformation OrderInformation;
        public Main_AQL AQL;
        public Main_Buttons Buttons;
        private TableLayoutPanel tlp_Left;
        public Panel panel_Profile;
        private PictureBox pbOperatör;
        private PictureBox pb_Grade;
        private Label lbl_Namn;
        public Label lbl_Percent;
        private Panel panel_Grade_Percent;
        private Label label_Role;
        private Label lbl_Role;
        private Label label_Sign;
        private Label label_EmpNr;
        private Label lbl_EmpNr;
        private Label lbl_Sign;
        private Label lbl_Company;
        private Panel panel_Background_OptinovaLogo;
        private PictureBox pBox_OptinovaLogo;
        public Main_Menu MainMenu;
        private TableLayoutPanel tlp_UserInfo;
        private System.Windows.Forms.Timer timer_ReLogin_Monitor;
        public ServerStatus Serverstatus;
        private QC.FeedBackQC FeedBackQC;
        private Panel panel_Right;
        public TableLayoutPanel tlp_QuickOpen;
        private Label label_Filter;
        private PictureBox pb_Info_Snabböppna;
        public DataGridView dgv_QuickOpen;
        private Label label_QuickOpenOrder;
        private Panel panel_Bottom;
        public Main_Priorityplanning PriorityPlanning;
        private SplitContainer spitContainer_Bottom;
        private SplitContainer splitContainer_Right;
        private ActiveOrdersUser ActiveOrdersUser;
        private Statistics_DPP Statistics_DPP;
        public Övrigt.TipsAndTrix TipsAndTrix;
        private MeasurementChart measurementChart;
        private RollingInformation RollingInformation;
    }
}