namespace DigitalProductionProgram.ToolManagement
{
    partial class ToolCalculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel_Left = new Panel();
            panel_Tools = new Panel();
            tlp_Tools = new TableLayoutPanel();
            lbl_TotalCalculations = new Label();
            label_TotalCalculations = new Label();
            label_Die_max = new Label();
            label_Die_min = new Label();
            label_Pin = new Label();
            label_Die = new Label();
            label_InfoTools = new Label();
            num_Die_min = new NumericUpDown();
            num_Die_max = new NumericUpDown();
            num_Die_step = new NumericUpDown();
            num_Pin_min = new NumericUpDown();
            num_Pin_max = new NumericUpDown();
            num_Pin_step = new NumericUpDown();
            label_Die_step = new Label();
            label_Pin_min = new Label();
            label_Pin_max = new Label();
            label_Pin_step = new Label();
            label_Tools = new Label();
            panel_Extrusion = new Panel();
            tlp_Extrusion = new TableLayoutPanel();
            tb_PullerSpeed = new TextBox();
            label_PullerSpeed = new Label();
            label_Density = new Label();
            label_DDR_min = new Label();
            label_DDR_max = new Label();
            label_Balance_max = new Label();
            label_Balance_min = new Label();
            tb_Density = new TextBox();
            num_DDR_min = new NumericUpDown();
            num_DDR_max = new NumericUpDown();
            num_Balance_min = new NumericUpDown();
            num_Balance_max = new NumericUpDown();
            label_Extrusion = new Label();
            panel_OrderInformation = new Panel();
            tlp_MainOrderInformation = new TableLayoutPanel();
            label_ID = new Label();
            tb_ID = new TextBox();
            label_Customer = new Label();
            tb_Customer = new TextBox();
            label_PartNumber = new Label();
            tb_PartNumber = new TextBox();
            label_Operation = new Label();
            label_OrderNr = new Label();
            tb_OrderNr = new TextBox();
            label_OD = new Label();
            label_Wall = new Label();
            tb_OD = new TextBox();
            tb_Wall = new TextBox();
            label_Length = new Label();
            tb_Length = new TextBox();
            tb_Operation = new TextBox();
            label_OrderInformation = new Label();
            tlp_Main = new TableLayoutPanel();
            cb_Pin = new ComboBox();
            cb_Die = new ComboBox();
            dgv_Combinations = new DataGridView();
            col_Die = new DataGridViewTextBoxColumn();
            col_DieLL = new DataGridViewTextBoxColumn();
            col_Pin = new DataGridViewTextBoxColumn();
            col_PinLL = new DataGridViewTextBoxColumn();
            col_ToolGap = new DataGridViewTextBoxColumn();
            col_DDR = new DataGridViewTextBoxColumn();
            col_Balance = new DataGridViewTextBoxColumn();
            col_ShearRate = new DataGridViewTextBoxColumn();
            chb_DöljKasseradeVerktyg = new CheckBox();
            lbl_TotalCombinations = new Label();
            lbl_AntalMunstycken = new Label();
            lbl_AntalKanyl = new Label();
            label_Info_Ok = new Label();
            label_Info_Bad = new Label();
            label_Info_Warning = new Label();
            tb_DieType = new TextBox();
            tb_PinType = new TextBox();
            rb_Register = new RadioButton();
            rb_TheoreticalTools = new RadioButton();
            btn_StartCalculation = new Button();
            pbar_Calculate = new ProgressBar();
            label_Warning = new Label();
            btn_Abort = new Button();
            btn_PrintOut = new Button();
            timer_OkSaveCalculation = new System.Windows.Forms.Timer(components);
            panel_Left.SuspendLayout();
            panel_Tools.SuspendLayout();
            tlp_Tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_Die_min).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Die_max).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Die_step).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Pin_min).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Pin_max).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Pin_step).BeginInit();
            panel_Extrusion.SuspendLayout();
            tlp_Extrusion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_DDR_min).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_DDR_max).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Balance_min).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Balance_max).BeginInit();
            panel_OrderInformation.SuspendLayout();
            tlp_MainOrderInformation.SuspendLayout();
            tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Combinations).BeginInit();
            SuspendLayout();
            // 
            // panel_Left
            // 
            panel_Left.BackColor = Color.FromArgb(45, 113, 122);
            panel_Left.Controls.Add(panel_Tools);
            panel_Left.Controls.Add(panel_Extrusion);
            panel_Left.Controls.Add(panel_OrderInformation);
            panel_Left.Dock = DockStyle.Left;
            panel_Left.Location = new Point(0, 0);
            panel_Left.Margin = new Padding(4, 3, 4, 3);
            panel_Left.Name = "panel_Left";
            panel_Left.Size = new Size(342, 1280);
            panel_Left.TabIndex = 0;
            // 
            // panel_Tools
            // 
            panel_Tools.BackColor = Color.Transparent;
            panel_Tools.BorderStyle = BorderStyle.Fixed3D;
            panel_Tools.Controls.Add(tlp_Tools);
            panel_Tools.Controls.Add(label_Tools);
            panel_Tools.Dock = DockStyle.Top;
            panel_Tools.Location = new Point(0, 530);
            panel_Tools.Margin = new Padding(4, 3, 4, 3);
            panel_Tools.Name = "panel_Tools";
            panel_Tools.Size = new Size(342, 316);
            panel_Tools.TabIndex = 193;
            // 
            // tlp_Tools
            // 
            tlp_Tools.ColumnCount = 5;
            tlp_Tools.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tlp_Tools.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33332F));
            tlp_Tools.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            tlp_Tools.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            tlp_Tools.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tlp_Tools.Controls.Add(lbl_TotalCalculations, 3, 8);
            tlp_Tools.Controls.Add(label_TotalCalculations, 0, 8);
            tlp_Tools.Controls.Add(label_Die_max, 2, 2);
            tlp_Tools.Controls.Add(label_Die_min, 1, 2);
            tlp_Tools.Controls.Add(label_Pin, 1, 4);
            tlp_Tools.Controls.Add(label_Die, 1, 1);
            tlp_Tools.Controls.Add(label_InfoTools, 0, 0);
            tlp_Tools.Controls.Add(num_Die_min, 1, 3);
            tlp_Tools.Controls.Add(num_Die_max, 2, 3);
            tlp_Tools.Controls.Add(num_Die_step, 3, 3);
            tlp_Tools.Controls.Add(num_Pin_min, 1, 6);
            tlp_Tools.Controls.Add(num_Pin_max, 2, 6);
            tlp_Tools.Controls.Add(num_Pin_step, 3, 6);
            tlp_Tools.Controls.Add(label_Die_step, 3, 2);
            tlp_Tools.Controls.Add(label_Pin_min, 1, 5);
            tlp_Tools.Controls.Add(label_Pin_max, 2, 5);
            tlp_Tools.Controls.Add(label_Pin_step, 3, 5);
            tlp_Tools.Dock = DockStyle.Fill;
            tlp_Tools.Location = new Point(21, 0);
            tlp_Tools.Margin = new Padding(4, 3, 4, 3);
            tlp_Tools.Name = "tlp_Tools";
            tlp_Tools.Padding = new Padding(0, 6, 0, 0);
            tlp_Tools.RowCount = 9;
            tlp_Tools.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            tlp_Tools.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Tools.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Tools.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Tools.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Tools.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Tools.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Tools.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tlp_Tools.RowStyles.Add(new RowStyle(SizeType.Absolute, 9F));
            tlp_Tools.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Tools.Size = new Size(317, 312);
            tlp_Tools.TabIndex = 192;
            // 
            // lbl_TotalCalculations
            // 
            lbl_TotalCalculations.BackColor = Color.Transparent;
            tlp_Tools.SetColumnSpan(lbl_TotalCalculations, 2);
            lbl_TotalCalculations.Dock = DockStyle.Fill;
            lbl_TotalCalculations.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_TotalCalculations.ForeColor = Color.FromArgb(239, 228, 177);
            lbl_TotalCalculations.ImageAlign = ContentAlignment.BottomCenter;
            lbl_TotalCalculations.Location = new Point(184, 277);
            lbl_TotalCalculations.Margin = new Padding(1, 0, 0, 1);
            lbl_TotalCalculations.Name = "lbl_TotalCalculations";
            lbl_TotalCalculations.Size = new Size(133, 34);
            lbl_TotalCalculations.TabIndex = 203;
            lbl_TotalCalculations.Text = "50";
            lbl_TotalCalculations.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_TotalCalculations
            // 
            label_TotalCalculations.BackColor = Color.Transparent;
            tlp_Tools.SetColumnSpan(label_TotalCalculations, 3);
            label_TotalCalculations.Dock = DockStyle.Fill;
            label_TotalCalculations.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_TotalCalculations.ForeColor = Color.FromArgb(239, 228, 177);
            label_TotalCalculations.ImageAlign = ContentAlignment.BottomCenter;
            label_TotalCalculations.Location = new Point(1, 277);
            label_TotalCalculations.Margin = new Padding(1, 0, 0, 1);
            label_TotalCalculations.Name = "label_TotalCalculations";
            label_TotalCalculations.Size = new Size(182, 34);
            label_TotalCalculations.TabIndex = 202;
            label_TotalCalculations.Text = "Antal beräkningar:";
            label_TotalCalculations.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Die_max
            // 
            label_Die_max.BackColor = Color.Transparent;
            label_Die_max.Dock = DockStyle.Fill;
            label_Die_max.Font = new Font("Arial", 10F);
            label_Die_max.ForeColor = Color.FromArgb(239, 228, 177);
            label_Die_max.ImageAlign = ContentAlignment.BottomCenter;
            label_Die_max.Location = new Point(110, 93);
            label_Die_max.Margin = new Padding(1, 0, 0, 1);
            label_Die_max.Name = "label_Die_max";
            label_Die_max.Size = new Size(73, 28);
            label_Die_max.TabIndex = 199;
            label_Die_max.Text = "Max";
            label_Die_max.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Die_min
            // 
            label_Die_min.BackColor = Color.Transparent;
            label_Die_min.Dock = DockStyle.Fill;
            label_Die_min.Font = new Font("Arial", 10F);
            label_Die_min.ForeColor = Color.FromArgb(239, 228, 177);
            label_Die_min.ImageAlign = ContentAlignment.BottomCenter;
            label_Die_min.Location = new Point(36, 93);
            label_Die_min.Margin = new Padding(1, 0, 0, 1);
            label_Die_min.Name = "label_Die_min";
            label_Die_min.Size = new Size(73, 28);
            label_Die_min.TabIndex = 197;
            label_Die_min.Text = "Min";
            label_Die_min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Pin
            // 
            label_Pin.BackColor = Color.Transparent;
            tlp_Tools.SetColumnSpan(label_Pin, 3);
            label_Pin.Dock = DockStyle.Fill;
            label_Pin.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold);
            label_Pin.ForeColor = Color.FromArgb(40, 40, 40);
            label_Pin.ImageAlign = ContentAlignment.BottomCenter;
            label_Pin.Location = new Point(36, 151);
            label_Pin.Margin = new Padding(1, 0, 0, 1);
            label_Pin.Name = "label_Pin";
            label_Pin.Size = new Size(221, 28);
            label_Pin.TabIndex = 193;
            label_Pin.Text = "Kärna";
            label_Pin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Die
            // 
            label_Die.BackColor = Color.Transparent;
            tlp_Tools.SetColumnSpan(label_Die, 3);
            label_Die.Dock = DockStyle.Fill;
            label_Die.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold);
            label_Die.ForeColor = Color.FromArgb(40, 40, 40);
            label_Die.ImageAlign = ContentAlignment.BottomCenter;
            label_Die.Location = new Point(36, 64);
            label_Die.Margin = new Padding(1, 0, 0, 1);
            label_Die.Name = "label_Die";
            label_Die.Size = new Size(221, 28);
            label_Die.TabIndex = 192;
            label_Die.Text = "Munstycke";
            label_Die.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_InfoTools
            // 
            label_InfoTools.AutoSize = true;
            tlp_Tools.SetColumnSpan(label_InfoTools, 5);
            label_InfoTools.Dock = DockStyle.Fill;
            label_InfoTools.Font = new Font("Lucida Sans", 10.25F);
            label_InfoTools.ForeColor = Color.FromArgb(171, 150, 85);
            label_InfoTools.Location = new Point(4, 6);
            label_InfoTools.Margin = new Padding(4, 0, 4, 0);
            label_InfoTools.Name = "label_InfoTools";
            label_InfoTools.Size = new Size(309, 58);
            label_InfoTools.TabIndex = 0;
            label_InfoTools.Text = "Detta används endast för beräkning av teoretiska verktyg.";
            // 
            // num_Die_min
            // 
            num_Die_min.BackColor = Color.White;
            num_Die_min.DecimalPlaces = 2;
            num_Die_min.Dock = DockStyle.Fill;
            num_Die_min.Font = new Font("Century", 9.75F);
            num_Die_min.ForeColor = Color.Black;
            num_Die_min.Location = new Point(39, 125);
            num_Die_min.Margin = new Padding(4, 3, 4, 3);
            num_Die_min.Maximum = new decimal(new int[] { 49, 0, 0, 0 });
            num_Die_min.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            num_Die_min.Name = "num_Die_min";
            num_Die_min.Size = new Size(66, 23);
            num_Die_min.TabIndex = 198;
            num_Die_min.TextAlign = HorizontalAlignment.Center;
            num_Die_min.ThousandsSeparator = true;
            num_Die_min.Value = new decimal(new int[] { 1, 0, 0, 0 });
            num_Die_min.ValueChanged += Calculate_ControlChanged;
            // 
            // num_Die_max
            // 
            num_Die_max.BackColor = Color.White;
            num_Die_max.DecimalPlaces = 2;
            num_Die_max.Font = new Font("Century", 9.75F);
            num_Die_max.ForeColor = Color.Black;
            num_Die_max.Location = new Point(113, 125);
            num_Die_max.Margin = new Padding(4, 3, 4, 3);
            num_Die_max.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            num_Die_max.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            num_Die_max.Name = "num_Die_max";
            num_Die_max.Size = new Size(66, 23);
            num_Die_max.TabIndex = 200;
            num_Die_max.TextAlign = HorizontalAlignment.Center;
            num_Die_max.ThousandsSeparator = true;
            num_Die_max.Value = new decimal(new int[] { 25, 0, 0, 0 });
            num_Die_max.ValueChanged += Calculate_ControlChanged;
            // 
            // num_Die_step
            // 
            num_Die_step.BackColor = Color.White;
            num_Die_step.DecimalPlaces = 2;
            num_Die_step.Font = new Font("Century", 9.75F);
            num_Die_step.ForeColor = Color.Black;
            num_Die_step.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            num_Die_step.Location = new Point(187, 125);
            num_Die_step.Margin = new Padding(4, 3, 4, 3);
            num_Die_step.Maximum = new decimal(new int[] { 49, 0, 0, 0 });
            num_Die_step.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            num_Die_step.Name = "num_Die_step";
            num_Die_step.Size = new Size(66, 23);
            num_Die_step.TabIndex = 200;
            num_Die_step.TextAlign = HorizontalAlignment.Center;
            num_Die_step.ThousandsSeparator = true;
            num_Die_step.Value = new decimal(new int[] { 3, 0, 0, 131072 });
            num_Die_step.ValueChanged += Calculate_ControlChanged;
            // 
            // num_Pin_min
            // 
            num_Pin_min.BackColor = Color.White;
            num_Pin_min.DecimalPlaces = 2;
            num_Pin_min.Font = new Font("Century", 9.75F);
            num_Pin_min.ForeColor = Color.Black;
            num_Pin_min.Location = new Point(39, 212);
            num_Pin_min.Margin = new Padding(4, 3, 4, 3);
            num_Pin_min.Maximum = new decimal(new int[] { 49, 0, 0, 0 });
            num_Pin_min.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            num_Pin_min.Name = "num_Pin_min";
            num_Pin_min.Size = new Size(66, 23);
            num_Pin_min.TabIndex = 200;
            num_Pin_min.TextAlign = HorizontalAlignment.Center;
            num_Pin_min.ThousandsSeparator = true;
            num_Pin_min.Value = new decimal(new int[] { 1, 0, 0, 0 });
            num_Pin_min.ValueChanged += Calculate_ControlChanged;
            // 
            // num_Pin_max
            // 
            num_Pin_max.BackColor = Color.White;
            num_Pin_max.DecimalPlaces = 2;
            num_Pin_max.Font = new Font("Century", 9.75F);
            num_Pin_max.ForeColor = Color.Black;
            num_Pin_max.Location = new Point(113, 212);
            num_Pin_max.Margin = new Padding(4, 3, 4, 3);
            num_Pin_max.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            num_Pin_max.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            num_Pin_max.Name = "num_Pin_max";
            num_Pin_max.Size = new Size(66, 23);
            num_Pin_max.TabIndex = 200;
            num_Pin_max.TextAlign = HorizontalAlignment.Center;
            num_Pin_max.ThousandsSeparator = true;
            num_Pin_max.Value = new decimal(new int[] { 20, 0, 0, 0 });
            num_Pin_max.ValueChanged += Calculate_ControlChanged;
            // 
            // num_Pin_step
            // 
            num_Pin_step.BackColor = Color.White;
            num_Pin_step.DecimalPlaces = 2;
            num_Pin_step.Font = new Font("Century", 9.75F);
            num_Pin_step.ForeColor = Color.Black;
            num_Pin_step.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            num_Pin_step.Location = new Point(187, 212);
            num_Pin_step.Margin = new Padding(4, 3, 4, 3);
            num_Pin_step.Maximum = new decimal(new int[] { 49, 0, 0, 0 });
            num_Pin_step.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            num_Pin_step.Name = "num_Pin_step";
            num_Pin_step.Size = new Size(66, 23);
            num_Pin_step.TabIndex = 200;
            num_Pin_step.TextAlign = HorizontalAlignment.Center;
            num_Pin_step.ThousandsSeparator = true;
            num_Pin_step.Value = new decimal(new int[] { 3, 0, 0, 131072 });
            num_Pin_step.ValueChanged += Calculate_ControlChanged;
            // 
            // label_Die_step
            // 
            label_Die_step.BackColor = Color.Transparent;
            label_Die_step.Dock = DockStyle.Fill;
            label_Die_step.Font = new Font("Arial", 10F);
            label_Die_step.ForeColor = Color.FromArgb(239, 228, 177);
            label_Die_step.ImageAlign = ContentAlignment.BottomCenter;
            label_Die_step.Location = new Point(184, 93);
            label_Die_step.Margin = new Padding(1, 0, 0, 1);
            label_Die_step.Name = "label_Die_step";
            label_Die_step.Size = new Size(73, 28);
            label_Die_step.TabIndex = 201;
            label_Die_step.Text = "Steg";
            label_Die_step.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Pin_min
            // 
            label_Pin_min.BackColor = Color.Transparent;
            label_Pin_min.Dock = DockStyle.Fill;
            label_Pin_min.Font = new Font("Arial", 10F);
            label_Pin_min.ForeColor = Color.FromArgb(239, 228, 177);
            label_Pin_min.ImageAlign = ContentAlignment.BottomCenter;
            label_Pin_min.Location = new Point(36, 180);
            label_Pin_min.Margin = new Padding(1, 0, 0, 1);
            label_Pin_min.Name = "label_Pin_min";
            label_Pin_min.Size = new Size(73, 28);
            label_Pin_min.TabIndex = 197;
            label_Pin_min.Text = "Min";
            label_Pin_min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Pin_max
            // 
            label_Pin_max.BackColor = Color.Transparent;
            label_Pin_max.Dock = DockStyle.Fill;
            label_Pin_max.Font = new Font("Arial", 10F);
            label_Pin_max.ForeColor = Color.FromArgb(239, 228, 177);
            label_Pin_max.ImageAlign = ContentAlignment.BottomCenter;
            label_Pin_max.Location = new Point(110, 180);
            label_Pin_max.Margin = new Padding(1, 0, 0, 1);
            label_Pin_max.Name = "label_Pin_max";
            label_Pin_max.Size = new Size(73, 28);
            label_Pin_max.TabIndex = 197;
            label_Pin_max.Text = "Max";
            label_Pin_max.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Pin_step
            // 
            label_Pin_step.BackColor = Color.Transparent;
            label_Pin_step.Dock = DockStyle.Fill;
            label_Pin_step.Font = new Font("Arial", 10F);
            label_Pin_step.ForeColor = Color.FromArgb(239, 228, 177);
            label_Pin_step.ImageAlign = ContentAlignment.BottomCenter;
            label_Pin_step.Location = new Point(184, 180);
            label_Pin_step.Margin = new Padding(1, 0, 0, 1);
            label_Pin_step.Name = "label_Pin_step";
            label_Pin_step.Size = new Size(73, 28);
            label_Pin_step.TabIndex = 197;
            label_Pin_step.Text = "Steg";
            label_Pin_step.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Tools
            // 
            label_Tools.BackColor = Color.Transparent;
            label_Tools.BorderStyle = BorderStyle.Fixed3D;
            label_Tools.Dock = DockStyle.Left;
            label_Tools.Font = new Font("Century", 9.25F);
            label_Tools.ForeColor = Color.FromArgb(187, 215, 228);
            label_Tools.Location = new Point(0, 0);
            label_Tools.Margin = new Padding(4, 0, 4, 0);
            label_Tools.Name = "label_Tools";
            label_Tools.Size = new Size(21, 312);
            label_Tools.TabIndex = 188;
            label_Tools.Text = "VERKTYG";
            label_Tools.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Extrusion
            // 
            panel_Extrusion.BackColor = Color.Transparent;
            panel_Extrusion.BorderStyle = BorderStyle.Fixed3D;
            panel_Extrusion.Controls.Add(tlp_Extrusion);
            panel_Extrusion.Controls.Add(label_Extrusion);
            panel_Extrusion.Dock = DockStyle.Top;
            panel_Extrusion.Location = new Point(0, 307);
            panel_Extrusion.Margin = new Padding(4, 3, 4, 3);
            panel_Extrusion.Name = "panel_Extrusion";
            panel_Extrusion.Size = new Size(342, 223);
            panel_Extrusion.TabIndex = 192;
            // 
            // tlp_Extrusion
            // 
            tlp_Extrusion.ColumnCount = 3;
            tlp_Extrusion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 124F));
            tlp_Extrusion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 71F));
            tlp_Extrusion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 121F));
            tlp_Extrusion.Controls.Add(tb_PullerSpeed, 1, 0);
            tlp_Extrusion.Controls.Add(label_PullerSpeed, 0, 0);
            tlp_Extrusion.Controls.Add(label_Density, 0, 1);
            tlp_Extrusion.Controls.Add(label_DDR_min, 0, 2);
            tlp_Extrusion.Controls.Add(label_DDR_max, 0, 3);
            tlp_Extrusion.Controls.Add(label_Balance_max, 0, 5);
            tlp_Extrusion.Controls.Add(label_Balance_min, 0, 4);
            tlp_Extrusion.Controls.Add(tb_Density, 1, 1);
            tlp_Extrusion.Controls.Add(num_DDR_min, 1, 2);
            tlp_Extrusion.Controls.Add(num_DDR_max, 1, 3);
            tlp_Extrusion.Controls.Add(num_Balance_min, 1, 4);
            tlp_Extrusion.Controls.Add(num_Balance_max, 1, 5);
            tlp_Extrusion.Dock = DockStyle.Fill;
            tlp_Extrusion.Location = new Point(21, 0);
            tlp_Extrusion.Margin = new Padding(4, 3, 4, 3);
            tlp_Extrusion.Name = "tlp_Extrusion";
            tlp_Extrusion.Padding = new Padding(0, 23, 0, 0);
            tlp_Extrusion.RowCount = 7;
            tlp_Extrusion.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Extrusion.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Extrusion.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Extrusion.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Extrusion.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Extrusion.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Extrusion.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Extrusion.Size = new Size(317, 219);
            tlp_Extrusion.TabIndex = 192;
            // 
            // tb_PullerSpeed
            // 
            tb_PullerSpeed.AcceptsTab = true;
            tb_PullerSpeed.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_PullerSpeed.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_PullerSpeed.BackColor = Color.White;
            tb_PullerSpeed.BorderStyle = BorderStyle.None;
            tb_PullerSpeed.CharacterCasing = CharacterCasing.Upper;
            tb_PullerSpeed.Dock = DockStyle.Fill;
            tb_PullerSpeed.Font = new Font("Arial", 12F);
            tb_PullerSpeed.ForeColor = Color.DarkGray;
            tb_PullerSpeed.Location = new Point(124, 26);
            tb_PullerSpeed.Margin = new Padding(0, 3, 0, 0);
            tb_PullerSpeed.Name = "tb_PullerSpeed";
            tb_PullerSpeed.Size = new Size(71, 19);
            tb_PullerSpeed.TabIndex = 200;
            tb_PullerSpeed.Text = "10";
            // 
            // label_PullerSpeed
            // 
            label_PullerSpeed.BackColor = Color.Transparent;
            label_PullerSpeed.Dock = DockStyle.Fill;
            label_PullerSpeed.Font = new Font("Arial", 10F);
            label_PullerSpeed.ForeColor = Color.FromArgb(239, 228, 177);
            label_PullerSpeed.ImageAlign = ContentAlignment.BottomCenter;
            label_PullerSpeed.Location = new Point(1, 23);
            label_PullerSpeed.Margin = new Padding(1, 0, 0, 1);
            label_PullerSpeed.Name = "label_PullerSpeed";
            label_PullerSpeed.Size = new Size(123, 28);
            label_PullerSpeed.TabIndex = 191;
            label_PullerSpeed.Text = "Draghastighet:";
            label_PullerSpeed.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Density
            // 
            label_Density.BackColor = Color.Transparent;
            label_Density.Dock = DockStyle.Fill;
            label_Density.Font = new Font("Arial", 10F);
            label_Density.ForeColor = Color.FromArgb(239, 228, 177);
            label_Density.ImageAlign = ContentAlignment.BottomCenter;
            label_Density.Location = new Point(1, 52);
            label_Density.Margin = new Padding(1, 0, 0, 1);
            label_Density.Name = "label_Density";
            label_Density.Size = new Size(123, 28);
            label_Density.TabIndex = 192;
            label_Density.Text = "Densitet:";
            label_Density.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_DDR_min
            // 
            label_DDR_min.BackColor = Color.Transparent;
            label_DDR_min.Dock = DockStyle.Fill;
            label_DDR_min.Font = new Font("Arial", 10F);
            label_DDR_min.ForeColor = Color.FromArgb(239, 228, 177);
            label_DDR_min.ImageAlign = ContentAlignment.BottomCenter;
            label_DDR_min.Location = new Point(1, 81);
            label_DDR_min.Margin = new Padding(1, 0, 0, 1);
            label_DDR_min.Name = "label_DDR_min";
            label_DDR_min.Size = new Size(123, 28);
            label_DDR_min.TabIndex = 196;
            label_DDR_min.Text = "DDR Min:";
            label_DDR_min.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_DDR_max
            // 
            label_DDR_max.BackColor = Color.Transparent;
            label_DDR_max.Dock = DockStyle.Fill;
            label_DDR_max.Font = new Font("Arial", 10F);
            label_DDR_max.ForeColor = Color.FromArgb(239, 228, 177);
            label_DDR_max.ImageAlign = ContentAlignment.BottomCenter;
            label_DDR_max.Location = new Point(1, 110);
            label_DDR_max.Margin = new Padding(1, 0, 0, 1);
            label_DDR_max.Name = "label_DDR_max";
            label_DDR_max.Size = new Size(123, 28);
            label_DDR_max.TabIndex = 194;
            label_DDR_max.Text = "DDR Max:";
            label_DDR_max.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Balance_max
            // 
            label_Balance_max.BackColor = Color.Transparent;
            label_Balance_max.Dock = DockStyle.Fill;
            label_Balance_max.Font = new Font("Arial", 10F);
            label_Balance_max.ForeColor = Color.FromArgb(239, 228, 177);
            label_Balance_max.ImageAlign = ContentAlignment.BottomCenter;
            label_Balance_max.Location = new Point(1, 168);
            label_Balance_max.Margin = new Padding(1, 0, 0, 1);
            label_Balance_max.Name = "label_Balance_max";
            label_Balance_max.Size = new Size(123, 28);
            label_Balance_max.TabIndex = 195;
            label_Balance_max.Text = "Balans Max:";
            label_Balance_max.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Balance_min
            // 
            label_Balance_min.BackColor = Color.Transparent;
            label_Balance_min.Dock = DockStyle.Fill;
            label_Balance_min.Font = new Font("Arial", 10F);
            label_Balance_min.ForeColor = Color.FromArgb(239, 228, 177);
            label_Balance_min.ImageAlign = ContentAlignment.BottomCenter;
            label_Balance_min.Location = new Point(1, 139);
            label_Balance_min.Margin = new Padding(1, 0, 0, 1);
            label_Balance_min.Name = "label_Balance_min";
            label_Balance_min.Size = new Size(123, 28);
            label_Balance_min.TabIndex = 193;
            label_Balance_min.Text = "Balans Min:";
            label_Balance_min.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_Density
            // 
            tb_Density.AcceptsTab = true;
            tb_Density.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_Density.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_Density.BackColor = Color.White;
            tb_Density.BorderStyle = BorderStyle.None;
            tb_Density.CharacterCasing = CharacterCasing.Upper;
            tb_Density.Dock = DockStyle.Fill;
            tb_Density.Font = new Font("Arial", 12F);
            tb_Density.ForeColor = Color.DarkGray;
            tb_Density.Location = new Point(124, 55);
            tb_Density.Margin = new Padding(0, 3, 0, 0);
            tb_Density.Name = "tb_Density";
            tb_Density.Size = new Size(71, 19);
            tb_Density.TabIndex = 200;
            tb_Density.Text = "2,14";
            // 
            // num_DDR_min
            // 
            num_DDR_min.BackColor = Color.White;
            num_DDR_min.DecimalPlaces = 1;
            num_DDR_min.Dock = DockStyle.Fill;
            num_DDR_min.Font = new Font("Century", 9.75F);
            num_DDR_min.ForeColor = Color.DarkGray;
            num_DDR_min.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            num_DDR_min.Location = new Point(128, 84);
            num_DDR_min.Margin = new Padding(4, 3, 4, 3);
            num_DDR_min.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            num_DDR_min.Name = "num_DDR_min";
            num_DDR_min.Size = new Size(63, 23);
            num_DDR_min.TabIndex = 202;
            num_DDR_min.ThousandsSeparator = true;
            num_DDR_min.Value = new decimal(new int[] { 1, 0, 0, 0 });
            num_DDR_min.ValueChanged += Calculate_ControlChanged;
            // 
            // num_DDR_max
            // 
            num_DDR_max.BackColor = Color.White;
            num_DDR_max.DecimalPlaces = 1;
            num_DDR_max.Dock = DockStyle.Fill;
            num_DDR_max.Font = new Font("Century", 9.75F);
            num_DDR_max.ForeColor = Color.DarkGray;
            num_DDR_max.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            num_DDR_max.Location = new Point(128, 113);
            num_DDR_max.Margin = new Padding(4, 3, 4, 3);
            num_DDR_max.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_DDR_max.Name = "num_DDR_max";
            num_DDR_max.Size = new Size(63, 23);
            num_DDR_max.TabIndex = 201;
            num_DDR_max.ThousandsSeparator = true;
            num_DDR_max.Value = new decimal(new int[] { 100, 0, 0, 65536 });
            num_DDR_max.ValueChanged += Calculate_ControlChanged;
            // 
            // num_Balance_min
            // 
            num_Balance_min.BackColor = Color.White;
            num_Balance_min.DecimalPlaces = 3;
            num_Balance_min.Dock = DockStyle.Fill;
            num_Balance_min.Font = new Font("Century", 9.75F);
            num_Balance_min.ForeColor = Color.DarkGray;
            num_Balance_min.Increment = new decimal(new int[] { 5, 0, 0, 196608 });
            num_Balance_min.Location = new Point(128, 142);
            num_Balance_min.Margin = new Padding(4, 3, 4, 3);
            num_Balance_min.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            num_Balance_min.Minimum = new decimal(new int[] { 8, 0, 0, 65536 });
            num_Balance_min.Name = "num_Balance_min";
            num_Balance_min.Size = new Size(63, 23);
            num_Balance_min.TabIndex = 204;
            num_Balance_min.TextAlign = HorizontalAlignment.Center;
            num_Balance_min.ThousandsSeparator = true;
            num_Balance_min.Value = new decimal(new int[] { 95, 0, 0, 131072 });
            num_Balance_min.ValueChanged += Calculate_ControlChanged;
            // 
            // num_Balance_max
            // 
            num_Balance_max.BackColor = Color.White;
            num_Balance_max.DecimalPlaces = 3;
            num_Balance_max.Dock = DockStyle.Fill;
            num_Balance_max.Font = new Font("Century", 9.75F);
            num_Balance_max.ForeColor = Color.DarkGray;
            num_Balance_max.Increment = new decimal(new int[] { 5, 0, 0, 196608 });
            num_Balance_max.Location = new Point(128, 171);
            num_Balance_max.Margin = new Padding(4, 3, 4, 3);
            num_Balance_max.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            num_Balance_max.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_Balance_max.Name = "num_Balance_max";
            num_Balance_max.Size = new Size(63, 23);
            num_Balance_max.TabIndex = 203;
            num_Balance_max.TextAlign = HorizontalAlignment.Center;
            num_Balance_max.ThousandsSeparator = true;
            num_Balance_max.Value = new decimal(new int[] { 105, 0, 0, 131072 });
            num_Balance_max.ValueChanged += Calculate_ControlChanged;
            // 
            // label_Extrusion
            // 
            label_Extrusion.BackColor = Color.Transparent;
            label_Extrusion.BorderStyle = BorderStyle.Fixed3D;
            label_Extrusion.Dock = DockStyle.Left;
            label_Extrusion.Font = new Font("Century", 9.25F);
            label_Extrusion.ForeColor = Color.FromArgb(187, 215, 228);
            label_Extrusion.Location = new Point(0, 0);
            label_Extrusion.Margin = new Padding(4, 0, 4, 0);
            label_Extrusion.Name = "label_Extrusion";
            label_Extrusion.Size = new Size(21, 219);
            label_Extrusion.TabIndex = 188;
            label_Extrusion.Text = "EXTRUDERING";
            label_Extrusion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_OrderInformation
            // 
            panel_OrderInformation.BackColor = Color.Transparent;
            panel_OrderInformation.BorderStyle = BorderStyle.Fixed3D;
            panel_OrderInformation.Controls.Add(tlp_MainOrderInformation);
            panel_OrderInformation.Controls.Add(label_OrderInformation);
            panel_OrderInformation.Dock = DockStyle.Top;
            panel_OrderInformation.Location = new Point(0, 0);
            panel_OrderInformation.Margin = new Padding(4, 3, 4, 3);
            panel_OrderInformation.Name = "panel_OrderInformation";
            panel_OrderInformation.Size = new Size(342, 307);
            panel_OrderInformation.TabIndex = 0;
            // 
            // tlp_MainOrderInformation
            // 
            tlp_MainOrderInformation.ColumnCount = 4;
            tlp_MainOrderInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            tlp_MainOrderInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 57F));
            tlp_MainOrderInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlp_MainOrderInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            tlp_MainOrderInformation.Controls.Add(label_ID, 0, 5);
            tlp_MainOrderInformation.Controls.Add(tb_ID, 1, 5);
            tlp_MainOrderInformation.Controls.Add(label_Customer, 0, 3);
            tlp_MainOrderInformation.Controls.Add(tb_Customer, 1, 3);
            tlp_MainOrderInformation.Controls.Add(label_PartNumber, 0, 2);
            tlp_MainOrderInformation.Controls.Add(tb_PartNumber, 1, 2);
            tlp_MainOrderInformation.Controls.Add(label_Operation, 0, 1);
            tlp_MainOrderInformation.Controls.Add(label_OrderNr, 0, 0);
            tlp_MainOrderInformation.Controls.Add(tb_OrderNr, 1, 0);
            tlp_MainOrderInformation.Controls.Add(label_OD, 0, 6);
            tlp_MainOrderInformation.Controls.Add(label_Wall, 0, 7);
            tlp_MainOrderInformation.Controls.Add(tb_OD, 1, 6);
            tlp_MainOrderInformation.Controls.Add(tb_Wall, 1, 7);
            tlp_MainOrderInformation.Controls.Add(label_Length, 0, 8);
            tlp_MainOrderInformation.Controls.Add(tb_Length, 1, 8);
            tlp_MainOrderInformation.Controls.Add(tb_Operation, 1, 1);
            tlp_MainOrderInformation.Dock = DockStyle.Fill;
            tlp_MainOrderInformation.Location = new Point(21, 0);
            tlp_MainOrderInformation.Margin = new Padding(4, 3, 4, 3);
            tlp_MainOrderInformation.Name = "tlp_MainOrderInformation";
            tlp_MainOrderInformation.Padding = new Padding(0, 12, 0, 0);
            tlp_MainOrderInformation.RowCount = 10;
            tlp_MainOrderInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_MainOrderInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_MainOrderInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_MainOrderInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_MainOrderInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tlp_MainOrderInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_MainOrderInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_MainOrderInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_MainOrderInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_MainOrderInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_MainOrderInformation.Size = new Size(317, 303);
            tlp_MainOrderInformation.TabIndex = 191;
            // 
            // label_ID
            // 
            label_ID.BackColor = Color.Transparent;
            label_ID.Dock = DockStyle.Fill;
            label_ID.Font = new Font("Arial", 10F);
            label_ID.ForeColor = Color.FromArgb(239, 228, 177);
            label_ID.ImageAlign = ContentAlignment.BottomCenter;
            label_ID.Location = new Point(1, 196);
            label_ID.Margin = new Padding(1, 0, 0, 1);
            label_ID.Name = "label_ID";
            label_ID.Size = new Size(90, 22);
            label_ID.TabIndex = 198;
            label_ID.Text = "ID";
            label_ID.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_ID
            // 
            tb_ID.AcceptsTab = true;
            tb_ID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_ID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_ID.BackColor = Color.White;
            tb_ID.BorderStyle = BorderStyle.None;
            tb_ID.CharacterCasing = CharacterCasing.Upper;
            tb_ID.Dock = DockStyle.Fill;
            tb_ID.Font = new Font("Arial", 12F);
            tb_ID.ForeColor = Color.DarkGray;
            tb_ID.Location = new Point(91, 199);
            tb_ID.Margin = new Padding(0, 3, 0, 0);
            tb_ID.Name = "tb_ID";
            tb_ID.Size = new Size(57, 19);
            tb_ID.TabIndex = 197;
            tb_ID.TextChanged += ID_OD_TextChanged;
            // 
            // label_Customer
            // 
            label_Customer.BackColor = Color.Transparent;
            label_Customer.Dock = DockStyle.Fill;
            label_Customer.Font = new Font("Arial", 10F);
            label_Customer.ForeColor = Color.FromArgb(239, 228, 177);
            label_Customer.ImageAlign = ContentAlignment.BottomCenter;
            label_Customer.Location = new Point(1, 81);
            label_Customer.Margin = new Padding(1, 0, 0, 1);
            label_Customer.Name = "label_Customer";
            label_Customer.Size = new Size(90, 22);
            label_Customer.TabIndex = 196;
            label_Customer.Text = "Kund:";
            label_Customer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_Customer
            // 
            tb_Customer.AcceptsTab = true;
            tb_Customer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_Customer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_Customer.BackColor = Color.White;
            tb_Customer.BorderStyle = BorderStyle.None;
            tb_Customer.CharacterCasing = CharacterCasing.Upper;
            tlp_MainOrderInformation.SetColumnSpan(tb_Customer, 3);
            tb_Customer.Dock = DockStyle.Fill;
            tb_Customer.Font = new Font("Arial", 9F);
            tb_Customer.ForeColor = Color.DarkGray;
            tb_Customer.Location = new Point(91, 81);
            tb_Customer.Margin = new Padding(0, 0, 6, 0);
            tb_Customer.Name = "tb_Customer";
            tb_Customer.Size = new Size(220, 14);
            tb_Customer.TabIndex = 195;
            // 
            // label_PartNumber
            // 
            label_PartNumber.BackColor = Color.Transparent;
            label_PartNumber.Dock = DockStyle.Fill;
            label_PartNumber.Font = new Font("Arial", 10F);
            label_PartNumber.ForeColor = Color.FromArgb(239, 228, 177);
            label_PartNumber.ImageAlign = ContentAlignment.BottomCenter;
            label_PartNumber.Location = new Point(1, 58);
            label_PartNumber.Margin = new Padding(1, 0, 0, 1);
            label_PartNumber.Name = "label_PartNumber";
            label_PartNumber.Size = new Size(90, 22);
            label_PartNumber.TabIndex = 194;
            label_PartNumber.Text = "ArtikelNr:";
            label_PartNumber.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_PartNumber
            // 
            tb_PartNumber.AcceptsTab = true;
            tb_PartNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_PartNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_PartNumber.BackColor = Color.White;
            tb_PartNumber.BorderStyle = BorderStyle.None;
            tb_PartNumber.CharacterCasing = CharacterCasing.Upper;
            tlp_MainOrderInformation.SetColumnSpan(tb_PartNumber, 2);
            tb_PartNumber.Dock = DockStyle.Fill;
            tb_PartNumber.Font = new Font("Arial", 9F);
            tb_PartNumber.ForeColor = Color.DarkGray;
            tb_PartNumber.Location = new Point(91, 58);
            tb_PartNumber.Margin = new Padding(0);
            tb_PartNumber.Name = "tb_PartNumber";
            tb_PartNumber.Size = new Size(134, 14);
            tb_PartNumber.TabIndex = 193;
            // 
            // label_Operation
            // 
            label_Operation.BackColor = Color.Transparent;
            label_Operation.Dock = DockStyle.Fill;
            label_Operation.Font = new Font("Arial", 10F);
            label_Operation.ForeColor = Color.FromArgb(239, 228, 177);
            label_Operation.ImageAlign = ContentAlignment.BottomCenter;
            label_Operation.Location = new Point(1, 35);
            label_Operation.Margin = new Padding(1, 0, 0, 1);
            label_Operation.Name = "label_Operation";
            label_Operation.Size = new Size(90, 22);
            label_Operation.TabIndex = 192;
            label_Operation.Text = "Operation:";
            label_Operation.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_OrderNr
            // 
            label_OrderNr.BackColor = Color.Transparent;
            label_OrderNr.Dock = DockStyle.Fill;
            label_OrderNr.Font = new Font("Arial", 10F);
            label_OrderNr.ForeColor = Color.FromArgb(239, 228, 177);
            label_OrderNr.ImageAlign = ContentAlignment.BottomCenter;
            label_OrderNr.Location = new Point(1, 12);
            label_OrderNr.Margin = new Padding(1, 0, 0, 1);
            label_OrderNr.Name = "label_OrderNr";
            label_OrderNr.Size = new Size(90, 22);
            label_OrderNr.TabIndex = 190;
            label_OrderNr.Text = "OrderNr:";
            label_OrderNr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_OrderNr
            // 
            tb_OrderNr.AcceptsTab = true;
            tb_OrderNr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_OrderNr.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_OrderNr.BackColor = Color.White;
            tb_OrderNr.BorderStyle = BorderStyle.None;
            tb_OrderNr.CharacterCasing = CharacterCasing.Upper;
            tlp_MainOrderInformation.SetColumnSpan(tb_OrderNr, 2);
            tb_OrderNr.Dock = DockStyle.Fill;
            tb_OrderNr.Font = new Font("Arial", 9F);
            tb_OrderNr.ForeColor = Color.DarkGray;
            tb_OrderNr.Location = new Point(91, 12);
            tb_OrderNr.Margin = new Padding(0);
            tb_OrderNr.Name = "tb_OrderNr";
            tb_OrderNr.Size = new Size(134, 14);
            tb_OrderNr.TabIndex = 189;
            tb_OrderNr.Leave += OrderNr_Leave;
            // 
            // label_OD
            // 
            label_OD.BackColor = Color.Transparent;
            label_OD.Dock = DockStyle.Fill;
            label_OD.Font = new Font("Arial", 10F);
            label_OD.ForeColor = Color.FromArgb(239, 228, 177);
            label_OD.ImageAlign = ContentAlignment.BottomCenter;
            label_OD.Location = new Point(1, 219);
            label_OD.Margin = new Padding(1, 0, 0, 1);
            label_OD.Name = "label_OD";
            label_OD.Size = new Size(90, 22);
            label_OD.TabIndex = 198;
            label_OD.Text = "OD";
            label_OD.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Wall
            // 
            label_Wall.BackColor = Color.Transparent;
            label_Wall.Dock = DockStyle.Fill;
            label_Wall.Font = new Font("Arial", 10F);
            label_Wall.ForeColor = Color.FromArgb(239, 228, 177);
            label_Wall.ImageAlign = ContentAlignment.BottomCenter;
            label_Wall.Location = new Point(1, 242);
            label_Wall.Margin = new Padding(1, 0, 0, 1);
            label_Wall.Name = "label_Wall";
            label_Wall.Size = new Size(90, 22);
            label_Wall.TabIndex = 198;
            label_Wall.Text = "Wall";
            label_Wall.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_OD
            // 
            tb_OD.AcceptsTab = true;
            tb_OD.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_OD.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_OD.BackColor = Color.White;
            tb_OD.BorderStyle = BorderStyle.None;
            tb_OD.CharacterCasing = CharacterCasing.Upper;
            tb_OD.Dock = DockStyle.Fill;
            tb_OD.Font = new Font("Arial", 12F);
            tb_OD.ForeColor = Color.DarkGray;
            tb_OD.Location = new Point(91, 222);
            tb_OD.Margin = new Padding(0, 3, 0, 0);
            tb_OD.Name = "tb_OD";
            tb_OD.Size = new Size(57, 19);
            tb_OD.TabIndex = 197;
            tb_OD.TextChanged += ID_OD_TextChanged;
            // 
            // tb_Wall
            // 
            tb_Wall.AcceptsTab = true;
            tb_Wall.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_Wall.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_Wall.BackColor = Color.White;
            tb_Wall.BorderStyle = BorderStyle.None;
            tb_Wall.CharacterCasing = CharacterCasing.Upper;
            tb_Wall.Dock = DockStyle.Fill;
            tb_Wall.Font = new Font("Arial", 12F);
            tb_Wall.ForeColor = Color.DarkGray;
            tb_Wall.Location = new Point(91, 245);
            tb_Wall.Margin = new Padding(0, 3, 0, 0);
            tb_Wall.Name = "tb_Wall";
            tb_Wall.Size = new Size(57, 19);
            tb_Wall.TabIndex = 197;
            // 
            // label_Length
            // 
            label_Length.BackColor = Color.Transparent;
            label_Length.Dock = DockStyle.Fill;
            label_Length.Font = new Font("Arial", 10F);
            label_Length.ForeColor = Color.FromArgb(239, 228, 177);
            label_Length.ImageAlign = ContentAlignment.BottomCenter;
            label_Length.Location = new Point(1, 265);
            label_Length.Margin = new Padding(1, 0, 0, 1);
            label_Length.Name = "label_Length";
            label_Length.Size = new Size(90, 22);
            label_Length.TabIndex = 198;
            label_Length.Text = "Length";
            label_Length.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_Length
            // 
            tb_Length.AcceptsTab = true;
            tb_Length.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_Length.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_Length.BackColor = Color.White;
            tb_Length.BorderStyle = BorderStyle.None;
            tb_Length.CharacterCasing = CharacterCasing.Upper;
            tb_Length.Dock = DockStyle.Fill;
            tb_Length.Font = new Font("Arial", 12F);
            tb_Length.ForeColor = Color.DarkGray;
            tb_Length.Location = new Point(91, 268);
            tb_Length.Margin = new Padding(0, 3, 0, 0);
            tb_Length.Name = "tb_Length";
            tb_Length.Size = new Size(57, 19);
            tb_Length.TabIndex = 197;
            // 
            // tb_Operation
            // 
            tb_Operation.AcceptsTab = true;
            tb_Operation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_Operation.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_Operation.BackColor = Color.White;
            tb_Operation.BorderStyle = BorderStyle.None;
            tb_Operation.CharacterCasing = CharacterCasing.Upper;
            tlp_MainOrderInformation.SetColumnSpan(tb_Operation, 3);
            tb_Operation.Dock = DockStyle.Fill;
            tb_Operation.Font = new Font("Arial", 9F);
            tb_Operation.ForeColor = Color.DarkGray;
            tb_Operation.Location = new Point(91, 35);
            tb_Operation.Margin = new Padding(0, 0, 6, 0);
            tb_Operation.Name = "tb_Operation";
            tb_Operation.Size = new Size(220, 14);
            tb_Operation.TabIndex = 199;
            tb_Operation.MouseClick += Operation_MouseClick;
            // 
            // label_OrderInformation
            // 
            label_OrderInformation.BackColor = Color.Transparent;
            label_OrderInformation.BorderStyle = BorderStyle.Fixed3D;
            label_OrderInformation.Dock = DockStyle.Left;
            label_OrderInformation.Font = new Font("Century", 9.25F);
            label_OrderInformation.ForeColor = Color.FromArgb(187, 215, 228);
            label_OrderInformation.Location = new Point(0, 0);
            label_OrderInformation.Margin = new Padding(4, 0, 4, 0);
            label_OrderInformation.Name = "label_OrderInformation";
            label_OrderInformation.Size = new Size(21, 303);
            label_OrderInformation.TabIndex = 188;
            label_OrderInformation.Text = "ORDER INFORMATION ";
            label_OrderInformation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.FromArgb(81, 85, 92);
            tlp_Main.ColumnCount = 5;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 251F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 121F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 113F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 355F));
            tlp_Main.Controls.Add(cb_Pin, 1, 2);
            tlp_Main.Controls.Add(cb_Die, 1, 1);
            tlp_Main.Controls.Add(dgv_Combinations, 0, 6);
            tlp_Main.Controls.Add(chb_DöljKasseradeVerktyg, 0, 0);
            tlp_Main.Controls.Add(lbl_TotalCombinations, 0, 5);
            tlp_Main.Controls.Add(lbl_AntalMunstycken, 2, 1);
            tlp_Main.Controls.Add(lbl_AntalKanyl, 2, 2);
            tlp_Main.Controls.Add(label_Info_Ok, 3, 0);
            tlp_Main.Controls.Add(label_Info_Bad, 3, 2);
            tlp_Main.Controls.Add(label_Info_Warning, 3, 1);
            tlp_Main.Controls.Add(tb_DieType, 0, 1);
            tlp_Main.Controls.Add(tb_PinType, 0, 2);
            tlp_Main.Controls.Add(rb_Register, 0, 3);
            tlp_Main.Controls.Add(rb_TheoreticalTools, 0, 4);
            tlp_Main.Location = new Point(562, 140);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 7;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlp_Main.RowStyles.Add(new RowStyle());
            tlp_Main.Size = new Size(854, 1146);
            tlp_Main.TabIndex = 357;
            // 
            // cb_Pin
            // 
            cb_Pin.BackColor = Color.White;
            cb_Pin.DropDownHeight = 200;
            cb_Pin.Font = new Font("Cambria", 9F);
            cb_Pin.ForeColor = Color.Black;
            cb_Pin.FormattingEnabled = true;
            cb_Pin.IntegralHeight = false;
            cb_Pin.ItemHeight = 14;
            cb_Pin.Location = new Point(255, 57);
            cb_Pin.Margin = new Padding(4, 1, 0, 0);
            cb_Pin.Name = "cb_Pin";
            cb_Pin.Size = new Size(81, 22);
            cb_Pin.TabIndex = 170;
            cb_Pin.SelectedIndexChanged += Calculate_ControlChanged;
            // 
            // cb_Die
            // 
            cb_Die.BackColor = Color.White;
            cb_Die.DropDownHeight = 200;
            cb_Die.FlatStyle = FlatStyle.System;
            cb_Die.Font = new Font("Cambria", 9F);
            cb_Die.ForeColor = Color.Black;
            cb_Die.FormattingEnabled = true;
            cb_Die.IntegralHeight = false;
            cb_Die.ItemHeight = 14;
            cb_Die.Location = new Point(255, 29);
            cb_Die.Margin = new Padding(4, 1, 0, 0);
            cb_Die.Name = "cb_Die";
            cb_Die.Size = new Size(81, 22);
            cb_Die.TabIndex = 169;
            cb_Die.SelectedIndexChanged += Calculate_ControlChanged;
            // 
            // dgv_Combinations
            // 
            dgv_Combinations.AllowUserToAddRows = false;
            dgv_Combinations.AllowUserToDeleteRows = false;
            dgv_Combinations.BackgroundColor = Color.FromArgb(81, 85, 92);
            dgv_Combinations.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(6, 81, 87);
            dataGridViewCellStyle1.Font = new Font("Lucida Sans", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 235, 156);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_Combinations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Combinations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Combinations.Columns.AddRange(new DataGridViewColumn[] { col_Die, col_DieLL, col_Pin, col_PinLL, col_ToolGap, col_DDR, col_Balance, col_ShearRate });
            tlp_Main.SetColumnSpan(dgv_Combinations, 4);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(147, 156, 153);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_Combinations.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_Combinations.Dock = DockStyle.Fill;
            dgv_Combinations.EnableHeadersVisualStyles = false;
            dgv_Combinations.GridColor = Color.FromArgb(81, 85, 92);
            dgv_Combinations.Location = new Point(4, 197);
            dgv_Combinations.Margin = new Padding(4, 3, 4, 3);
            dgv_Combinations.MultiSelect = false;
            dgv_Combinations.Name = "dgv_Combinations";
            dgv_Combinations.RowHeadersVisible = false;
            dgv_Combinations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Combinations.Size = new Size(567, 946);
            dgv_Combinations.TabIndex = 194;
            // 
            // col_Die
            // 
            col_Die.HeaderText = "Munstycke";
            col_Die.Name = "col_Die";
            col_Die.Width = 80;
            // 
            // col_DieLL
            // 
            col_DieLL.HeaderText = "LL";
            col_DieLL.Name = "col_DieLL";
            col_DieLL.SortMode = DataGridViewColumnSortMode.Programmatic;
            col_DieLL.Width = 40;
            // 
            // col_Pin
            // 
            col_Pin.HeaderText = "Kärna";
            col_Pin.Name = "col_Pin";
            col_Pin.Width = 80;
            // 
            // col_PinLL
            // 
            col_PinLL.HeaderText = "LL";
            col_PinLL.Name = "col_PinLL";
            col_PinLL.SortMode = DataGridViewColumnSortMode.Programmatic;
            col_PinLL.Width = 40;
            // 
            // col_ToolGap
            // 
            col_ToolGap.HeaderText = "Spel";
            col_ToolGap.Name = "col_ToolGap";
            col_ToolGap.Width = 50;
            // 
            // col_DDR
            // 
            col_DDR.HeaderText = "DDR";
            col_DDR.Name = "col_DDR";
            col_DDR.Width = 50;
            // 
            // col_Balance
            // 
            col_Balance.HeaderText = "Balans";
            col_Balance.Name = "col_Balance";
            col_Balance.Width = 50;
            // 
            // col_ShearRate
            // 
            col_ShearRate.HeaderText = "ShearRate";
            col_ShearRate.Name = "col_ShearRate";
            col_ShearRate.Width = 75;
            // 
            // chb_DöljKasseradeVerktyg
            // 
            chb_DöljKasseradeVerktyg.AutoSize = true;
            chb_DöljKasseradeVerktyg.Checked = true;
            chb_DöljKasseradeVerktyg.CheckState = CheckState.Checked;
            chb_DöljKasseradeVerktyg.Font = new Font("Microsoft Sans Serif", 9.25F);
            chb_DöljKasseradeVerktyg.ForeColor = Color.FromArgb(119, 142, 162);
            chb_DöljKasseradeVerktyg.Location = new Point(4, 3);
            chb_DöljKasseradeVerktyg.Margin = new Padding(4, 3, 4, 3);
            chb_DöljKasseradeVerktyg.Name = "chb_DöljKasseradeVerktyg";
            chb_DöljKasseradeVerktyg.Size = new Size(165, 20);
            chb_DöljKasseradeVerktyg.TabIndex = 187;
            chb_DöljKasseradeVerktyg.Text = "Dölj kasserade verktyg";
            chb_DöljKasseradeVerktyg.UseVisualStyleBackColor = true;
            // 
            // lbl_TotalCombinations
            // 
            lbl_TotalCombinations.AutoSize = true;
            lbl_TotalCombinations.BackColor = Color.Transparent;
            tlp_Main.SetColumnSpan(lbl_TotalCombinations, 2);
            lbl_TotalCombinations.Dock = DockStyle.Fill;
            lbl_TotalCombinations.Font = new Font("Century", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_TotalCombinations.ForeColor = Color.FromArgb(119, 142, 162);
            lbl_TotalCombinations.Location = new Point(4, 154);
            lbl_TotalCombinations.Margin = new Padding(4, 0, 4, 0);
            lbl_TotalCombinations.Name = "lbl_TotalCombinations";
            lbl_TotalCombinations.Size = new Size(333, 40);
            lbl_TotalCombinations.TabIndex = 189;
            lbl_TotalCombinations.Text = "Antal kombinationer:";
            lbl_TotalCombinations.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_AntalMunstycken
            // 
            lbl_AntalMunstycken.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbl_AntalMunstycken.AutoSize = true;
            lbl_AntalMunstycken.BackColor = Color.Transparent;
            lbl_AntalMunstycken.Cursor = Cursors.Hand;
            lbl_AntalMunstycken.Font = new Font("Century", 9.75F);
            lbl_AntalMunstycken.ForeColor = Color.DimGray;
            lbl_AntalMunstycken.Location = new Point(345, 28);
            lbl_AntalMunstycken.Margin = new Padding(4, 0, 4, 0);
            lbl_AntalMunstycken.Name = "lbl_AntalMunstycken";
            lbl_AntalMunstycken.Size = new Size(113, 16);
            lbl_AntalMunstycken.TabIndex = 186;
            lbl_AntalMunstycken.Text = "0";
            // 
            // lbl_AntalKanyl
            // 
            lbl_AntalKanyl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbl_AntalKanyl.AutoSize = true;
            lbl_AntalKanyl.BackColor = Color.Transparent;
            lbl_AntalKanyl.Cursor = Cursors.Hand;
            lbl_AntalKanyl.Font = new Font("Century", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_AntalKanyl.ForeColor = Color.DimGray;
            lbl_AntalKanyl.Location = new Point(345, 56);
            lbl_AntalKanyl.Margin = new Padding(4, 0, 4, 0);
            lbl_AntalKanyl.Name = "lbl_AntalKanyl";
            lbl_AntalKanyl.Size = new Size(113, 16);
            lbl_AntalKanyl.TabIndex = 186;
            lbl_AntalKanyl.Text = "0";
            // 
            // label_Info_Ok
            // 
            label_Info_Ok.AutoSize = true;
            label_Info_Ok.BackColor = Color.FromArgb(198, 239, 206);
            tlp_Main.SetColumnSpan(label_Info_Ok, 2);
            label_Info_Ok.Dock = DockStyle.Fill;
            label_Info_Ok.Font = new Font("Microsoft Sans Serif", 9.25F);
            label_Info_Ok.ForeColor = Color.FromArgb(0, 97, 0);
            label_Info_Ok.Location = new Point(466, 0);
            label_Info_Ok.Margin = new Padding(4, 0, 4, 2);
            label_Info_Ok.Name = "label_Info_Ok";
            label_Info_Ok.Size = new Size(460, 26);
            label_Info_Ok.TabIndex = 196;
            label_Info_Ok.Text = "Verktygskombination Ok";
            // 
            // label_Info_Bad
            // 
            label_Info_Bad.AutoSize = true;
            label_Info_Bad.BackColor = Color.FromArgb(255, 199, 206);
            tlp_Main.SetColumnSpan(label_Info_Bad, 2);
            label_Info_Bad.Dock = DockStyle.Fill;
            label_Info_Bad.Font = new Font("Microsoft Sans Serif", 9.25F);
            label_Info_Bad.ForeColor = Color.FromArgb(156, 0, 6);
            label_Info_Bad.Location = new Point(466, 56);
            label_Info_Bad.Margin = new Padding(4, 0, 4, 2);
            label_Info_Bad.Name = "label_Info_Bad";
            label_Info_Bad.Size = new Size(460, 26);
            label_Info_Bad.TabIndex = 196;
            label_Info_Bad.Text = "Landlängden saknas på Munstycke eller Kanyl";
            // 
            // label_Info_Warning
            // 
            label_Info_Warning.AutoSize = true;
            label_Info_Warning.BackColor = Color.FromArgb(255, 235, 156);
            tlp_Main.SetColumnSpan(label_Info_Warning, 2);
            label_Info_Warning.Dock = DockStyle.Fill;
            label_Info_Warning.Font = new Font("Microsoft Sans Serif", 9.25F);
            label_Info_Warning.ForeColor = Color.FromArgb(156, 101, 0);
            label_Info_Warning.Location = new Point(466, 28);
            label_Info_Warning.Margin = new Padding(4, 0, 4, 2);
            label_Info_Warning.Name = "label_Info_Warning";
            label_Info_Warning.Size = new Size(460, 26);
            label_Info_Warning.TabIndex = 196;
            label_Info_Warning.Text = "Landlängden är större på Munstycket än Kanylen";
            // 
            // tb_DieType
            // 
            tb_DieType.Dock = DockStyle.Fill;
            tb_DieType.Location = new Point(6, 30);
            tb_DieType.Margin = new Padding(6, 2, 0, 0);
            tb_DieType.Name = "tb_DieType";
            tb_DieType.Size = new Size(245, 23);
            tb_DieType.TabIndex = 197;
            tb_DieType.MouseClick += DieType_MouseClick;
            tb_DieType.TextChanged += DieType_TextChanged;
            // 
            // tb_PinType
            // 
            tb_PinType.Dock = DockStyle.Fill;
            tb_PinType.Location = new Point(6, 58);
            tb_PinType.Margin = new Padding(6, 2, 0, 0);
            tb_PinType.Name = "tb_PinType";
            tb_PinType.Size = new Size(245, 23);
            tb_PinType.TabIndex = 197;
            tb_PinType.MouseClick += PinType_MouseClick;
            tb_PinType.TextChanged += PinType_TextChanged;
            // 
            // rb_Register
            // 
            rb_Register.AutoSize = true;
            rb_Register.Checked = true;
            tlp_Main.SetColumnSpan(rb_Register, 3);
            rb_Register.Dock = DockStyle.Fill;
            rb_Register.Font = new Font("Lucida Sans", 10.25F);
            rb_Register.ForeColor = Color.FromArgb(171, 150, 85);
            rb_Register.Location = new Point(4, 87);
            rb_Register.Margin = new Padding(4, 3, 4, 3);
            rb_Register.Name = "rb_Register";
            rb_Register.Size = new Size(454, 29);
            rb_Register.TabIndex = 198;
            rb_Register.TabStop = true;
            rb_Register.Text = "Beräkna med verktyg Register";
            rb_Register.UseVisualStyleBackColor = true;
            rb_Register.CheckedChanged += Calculate_ControlChanged;
            // 
            // rb_TheoreticalTools
            // 
            rb_TheoreticalTools.AutoSize = true;
            tlp_Main.SetColumnSpan(rb_TheoreticalTools, 3);
            rb_TheoreticalTools.Dock = DockStyle.Fill;
            rb_TheoreticalTools.Font = new Font("Lucida Sans", 10.25F);
            rb_TheoreticalTools.ForeColor = Color.FromArgb(171, 150, 85);
            rb_TheoreticalTools.Location = new Point(4, 122);
            rb_TheoreticalTools.Margin = new Padding(4, 3, 4, 3);
            rb_TheoreticalTools.Name = "rb_TheoreticalTools";
            rb_TheoreticalTools.Size = new Size(454, 29);
            rb_TheoreticalTools.TabIndex = 198;
            rb_TheoreticalTools.Text = "Beräkna fram nya verktyg";
            rb_TheoreticalTools.UseVisualStyleBackColor = true;
            rb_TheoreticalTools.CheckedChanged += Calculate_ControlChanged;
            // 
            // btn_StartCalculation
            // 
            btn_StartCalculation.BackColor = Color.FromArgb(198, 239, 206);
            btn_StartCalculation.FlatAppearance.MouseOverBackColor = Color.FromArgb(168, 209, 176);
            btn_StartCalculation.FlatStyle = FlatStyle.Flat;
            btn_StartCalculation.Font = new Font("Arial", 9.25F);
            btn_StartCalculation.ForeColor = Color.FromArgb(0, 97, 0);
            btn_StartCalculation.Location = new Point(350, 143);
            btn_StartCalculation.Margin = new Padding(4, 3, 4, 3);
            btn_StartCalculation.Name = "btn_StartCalculation";
            btn_StartCalculation.Size = new Size(122, 35);
            btn_StartCalculation.TabIndex = 358;
            btn_StartCalculation.Text = "Beräkna";
            btn_StartCalculation.UseVisualStyleBackColor = false;
            btn_StartCalculation.Click += Calculate_Click;
            // 
            // pbar_Calculate
            // 
            pbar_Calculate.Dock = DockStyle.Top;
            pbar_Calculate.Location = new Point(342, 0);
            pbar_Calculate.Margin = new Padding(4, 3, 4, 3);
            pbar_Calculate.Name = "pbar_Calculate";
            pbar_Calculate.Size = new Size(1407, 36);
            pbar_Calculate.TabIndex = 359;
            // 
            // label_Warning
            // 
            label_Warning.BackColor = Color.FromArgb(255, 235, 156);
            label_Warning.Dock = DockStyle.Top;
            label_Warning.Font = new Font("Microsoft Sans Serif", 13.25F);
            label_Warning.ForeColor = Color.FromArgb(156, 101, 0);
            label_Warning.Location = new Point(342, 36);
            label_Warning.Margin = new Padding(4, 0, 4, 6);
            label_Warning.Name = "label_Warning";
            label_Warning.Padding = new Padding(0, 0, 0, 6);
            label_Warning.Size = new Size(1407, 80);
            label_Warning.TabIndex = 360;
            label_Warning.Text = "Varning\r\n\r\n\r\n";
            label_Warning.Visible = false;
            // 
            // btn_Abort
            // 
            btn_Abort.BackColor = Color.FromArgb(255, 199, 206);
            btn_Abort.FlatAppearance.MouseOverBackColor = Color.FromArgb(225, 169, 176);
            btn_Abort.FlatStyle = FlatStyle.Flat;
            btn_Abort.Font = new Font("Arial", 9.25F);
            btn_Abort.ForeColor = Color.FromArgb(156, 0, 6);
            btn_Abort.Location = new Point(350, 187);
            btn_Abort.Margin = new Padding(4, 3, 4, 3);
            btn_Abort.Name = "btn_Abort";
            btn_Abort.Size = new Size(122, 35);
            btn_Abort.TabIndex = 361;
            btn_Abort.Text = "Avbryt";
            btn_Abort.UseVisualStyleBackColor = false;
            btn_Abort.Click += Abort_Click;
            // 
            // btn_PrintOut
            // 
            btn_PrintOut.BackColor = Color.FromArgb(81, 85, 86);
            btn_PrintOut.FlatAppearance.MouseOverBackColor = Color.FromArgb(117, 116, 123);
            btn_PrintOut.FlatStyle = FlatStyle.Flat;
            btn_PrintOut.Font = new Font("Arial", 9.25F);
            btn_PrintOut.ForeColor = Color.FromArgb(147, 146, 153);
            btn_PrintOut.Location = new Point(350, 253);
            btn_PrintOut.Margin = new Padding(4, 3, 4, 3);
            btn_PrintOut.Name = "btn_PrintOut";
            btn_PrintOut.Size = new Size(122, 35);
            btn_PrintOut.TabIndex = 358;
            btn_PrintOut.Text = "Skriv Ut";
            btn_PrintOut.UseVisualStyleBackColor = false;
            btn_PrintOut.Visible = false;
            btn_PrintOut.Click += Calculate_Click;
            // 
            // timer_OkSaveCalculation
            // 
            timer_OkSaveCalculation.Interval = 5000;
            timer_OkSaveCalculation.Tick += timer_OkSaveCalculation_Tick;
            // 
            // ToolCalculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 115, 140);
            ClientSize = new Size(1749, 1280);
            Controls.Add(btn_Abort);
            Controls.Add(label_Warning);
            Controls.Add(pbar_Calculate);
            Controls.Add(btn_PrintOut);
            Controls.Add(btn_StartCalculation);
            Controls.Add(tlp_Main);
            Controls.Add(panel_Left);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ToolCalculator";
            Text = "ToolCalculator";
            FormClosed += ToolCalculator_FormClosed;
            Load += ToolCalculator_Load;
            panel_Left.ResumeLayout(false);
            panel_Tools.ResumeLayout(false);
            tlp_Tools.ResumeLayout(false);
            tlp_Tools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_Die_min).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Die_max).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Die_step).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Pin_min).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Pin_max).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Pin_step).EndInit();
            panel_Extrusion.ResumeLayout(false);
            tlp_Extrusion.ResumeLayout(false);
            tlp_Extrusion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_DDR_min).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_DDR_max).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Balance_min).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Balance_max).EndInit();
            panel_OrderInformation.ResumeLayout(false);
            tlp_MainOrderInformation.ResumeLayout(false);
            tlp_MainOrderInformation.PerformLayout();
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Combinations).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Panel panel_OrderInformation;
        private System.Windows.Forms.Label label_OrderInformation;
        public System.Windows.Forms.TextBox tb_OrderNr;
        private System.Windows.Forms.TableLayoutPanel tlp_MainOrderInformation;
        private System.Windows.Forms.Label label_Customer;
        public System.Windows.Forms.TextBox tb_Customer;
        private System.Windows.Forms.Label label_PartNumber;
        public System.Windows.Forms.TextBox tb_PartNumber;
        private System.Windows.Forms.Label label_Operation;
        private System.Windows.Forms.Label label_OrderNr;
        private System.Windows.Forms.Label label_ID;
        public System.Windows.Forms.TextBox tb_ID;
        private System.Windows.Forms.Label label_OD;
        private System.Windows.Forms.Label label_Wall;
        public System.Windows.Forms.TextBox tb_OD;
        public System.Windows.Forms.TextBox tb_Wall;
        private System.Windows.Forms.Label label_Length;
        public System.Windows.Forms.TextBox tb_Length;
        public System.Windows.Forms.TextBox tb_Operation;
        private System.Windows.Forms.Panel panel_Extrusion;
        private System.Windows.Forms.TableLayoutPanel tlp_Extrusion;
        private System.Windows.Forms.Label label_PullerSpeed;
        private System.Windows.Forms.Label label_Density;
        private System.Windows.Forms.Label label_DDR_min;
        private System.Windows.Forms.Label label_DDR_max;
        private System.Windows.Forms.Label label_Balance_max;
        private System.Windows.Forms.Label label_Balance_min;
        private System.Windows.Forms.Label label_Extrusion;
        public System.Windows.Forms.TextBox tb_PullerSpeed;
        public System.Windows.Forms.TextBox tb_Density;
        private System.Windows.Forms.NumericUpDown num_DDR_min;
        private System.Windows.Forms.NumericUpDown num_DDR_max;
        private System.Windows.Forms.NumericUpDown num_Balance_min;
        private System.Windows.Forms.NumericUpDown num_Balance_max;
        private System.Windows.Forms.Panel panel_Tools;
        private System.Windows.Forms.TableLayoutPanel tlp_Tools;
        private System.Windows.Forms.Label label_Tools;
        private System.Windows.Forms.Label label_InfoTools;
        private System.Windows.Forms.Label label_Die;
        private System.Windows.Forms.Label label_Die_max;
        private System.Windows.Forms.Label label_Die_min;
        private System.Windows.Forms.Label label_Pin;
        private System.Windows.Forms.NumericUpDown num_Die_min;
        private System.Windows.Forms.NumericUpDown num_Die_max;
        private System.Windows.Forms.NumericUpDown num_Die_step;
        private System.Windows.Forms.NumericUpDown num_Pin_min;
        private System.Windows.Forms.NumericUpDown num_Pin_max;
        private System.Windows.Forms.NumericUpDown num_Pin_step;
        private System.Windows.Forms.Label label_Die_step;
        private System.Windows.Forms.Label label_Pin_min;
        private System.Windows.Forms.Label label_Pin_max;
        private System.Windows.Forms.Label label_Pin_step;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.ComboBox cb_Pin;
        private System.Windows.Forms.ComboBox cb_Die;
        private System.Windows.Forms.DataGridView dgv_Combinations;
        private System.Windows.Forms.CheckBox chb_DöljKasseradeVerktyg;
        private System.Windows.Forms.Label lbl_TotalCombinations;
        private System.Windows.Forms.Label lbl_AntalMunstycken;
        private System.Windows.Forms.Label lbl_AntalKanyl;
        private System.Windows.Forms.Label label_Info_Ok;
        private System.Windows.Forms.Label label_Info_Warning;
        private System.Windows.Forms.TextBox tb_DieType;
        private System.Windows.Forms.TextBox tb_PinType;
        private System.Windows.Forms.Button btn_StartCalculation;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Die;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DieLL;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Pin;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PinLL;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ToolGap;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ShearRate;
        private System.Windows.Forms.RadioButton rb_Register;
        private System.Windows.Forms.RadioButton rb_TheoreticalTools;
        private System.Windows.Forms.Label label_Info_Bad;
        private System.Windows.Forms.ProgressBar pbar_Calculate;
        private System.Windows.Forms.Label label_Warning;
        private System.Windows.Forms.Button btn_Abort;
        private System.Windows.Forms.Button btn_PrintOut;
        private System.Windows.Forms.Label lbl_TotalCalculations;
        private System.Windows.Forms.Label label_TotalCalculations;
        private System.Windows.Forms.Timer timer_OkSaveCalculation;
    }
}