using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Measure
{
    partial class Measurement_Protocol
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Measurement_Protocol));
            tlp_OrderInfo_TEF = new TableLayoutPanel();
            lbl_Benämning_Övrigt = new Label();
            label_Description = new Label();
            lbl_OrderNr_Övrigt = new Label();
            label_OrderNr = new Label();
            label_Customer = new Label();
            label_PartNumber = new Label();
            lbl_ArtikelNr_Övrigt = new Label();
            lbl_Kund_Övrigt = new Label();
            flp_Buttons = new FlowLayoutPanel();
            btn_TransferLengthMeasure = new Button();
            btn_TransferMeasurement = new Button();
            btn_EditBag = new Button();
            btn_EditAmount = new Button();
            btn_Discard = new Button();
            btn_TransferToExcel = new Button();
            tlp_Help_InputData_1 = new TableLayoutPanel();
            btn_Clear_HelpInput_1 = new Button();
            dgv_HelpInput_1 = new DataGridView();
            RowHeaders = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            dgv_Walls = new DataGridView();
            col_Info = new DataGridViewTextBoxColumn();
            col_Wall = new DataGridViewTextBoxColumn();
            btn_Clear_HelpInput_2 = new Button();
            dgv_RecWalls = new DataGridView();
            col_RecInfo = new DataGridViewTextBoxColumn();
            col_RecWall = new DataGridViewTextBoxColumn();
            dgv_HelpInput_2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            pb_CrossSectionTube = new PictureBox();
            tlp_Mätdon = new TableLayoutPanel();
            tb_Hack = new TextBox();
            label_HackNr = new Label();
            measureInstrument = new MeasureInstrument();
            tlp_Main = new TableLayoutPanel();
            dgv_Measurements = new DataGridView();
            tlp_Info_Colors = new TableLayoutPanel();
            label_Discarded = new Label();
            label_Ok = new Label();
            label_Fail = new Label();
            label_Felskrivning = new Label();
            label_Warning = new Label();
            panel1 = new Panel();
            label_TotalMeasureMents = new Label();
            lbl_DiscardedMeasurements = new Label();
            lbl_TotalMeasurements = new Label();
            label_DiscardedMeasurements = new Label();
            flp_Headers = new FlowLayoutPanel();
            pb_Info = new PictureBox();
            flp_InputControls = new FlowLayoutPanel();
            panel_Bottom = new Panel();
            tlp_Help_InputData_2 = new TableLayoutPanel();
            tlp_OrderInfo_FEP = new TableLayoutPanel();
            label_OD = new Label();
            lbl_Nom_OD = new Label();
            label_Wall = new Label();
            lbl_Nom_Wall = new Label();
            label_Length = new Label();
            lbl_Nom_Length = new Label();
            lbl_Nom_ID = new Label();
            label_ID = new Label();
            lbl_OrderNr_FEP = new Label();
            label_OrderNr_2 = new Label();
            label_Customer_2 = new Label();
            lbl_Kund_FEP = new Label();
            Co_Extrudering = new CheckBox();
            Röntgen = new CheckBox();
            Clear = new CheckBox();
            label_AntalStripes = new Label();
            Antal_Stripes = new TextBox();
            label_st = new Label();
            Single_Extrudering = new CheckBox();
            menu_Beräkna = new ContextMenuStrip(components);
            menu_ID_Blåst = new ToolStripMenuItem();
            menu_OD_Blåst = new ToolStripMenuItem();
            menu_W_Blåst = new ToolStripMenuItem();
            menu_ID_Krympt = new ToolStripMenuItem();
            menu_OD_Krympt = new ToolStripMenuItem();
            menu_W_Krympt = new ToolStripMenuItem();
            tlp_OrderInfo_TEF.SuspendLayout();
            flp_Buttons.SuspendLayout();
            tlp_Help_InputData_1.SuspendLayout();
            ((ISupportInitialize)dgv_HelpInput_1).BeginInit();
            ((ISupportInitialize)dgv_Walls).BeginInit();
            ((ISupportInitialize)dgv_RecWalls).BeginInit();
            ((ISupportInitialize)dgv_HelpInput_2).BeginInit();
            ((ISupportInitialize)pb_CrossSectionTube).BeginInit();
            tlp_Mätdon.SuspendLayout();
            tlp_Main.SuspendLayout();
            ((ISupportInitialize)dgv_Measurements).BeginInit();
            tlp_Info_Colors.SuspendLayout();
            panel1.SuspendLayout();
            ((ISupportInitialize)pb_Info).BeginInit();
            panel_Bottom.SuspendLayout();
            tlp_Help_InputData_2.SuspendLayout();
            tlp_OrderInfo_FEP.SuspendLayout();
            menu_Beräkna.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_OrderInfo_TEF
            // 
            tlp_OrderInfo_TEF.BackColor = Color.FromArgb(25, 25, 25);
            tlp_OrderInfo_TEF.ColumnCount = 4;
            tlp_OrderInfo_TEF.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 122F));
            tlp_OrderInfo_TEF.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_OrderInfo_TEF.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tlp_OrderInfo_TEF.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tlp_OrderInfo_TEF.Controls.Add(lbl_Benämning_Övrigt, 1, 1);
            tlp_OrderInfo_TEF.Controls.Add(label_Description, 0, 1);
            tlp_OrderInfo_TEF.Controls.Add(lbl_OrderNr_Övrigt, 3, 0);
            tlp_OrderInfo_TEF.Controls.Add(label_OrderNr, 2, 0);
            tlp_OrderInfo_TEF.Controls.Add(label_Customer, 0, 0);
            tlp_OrderInfo_TEF.Controls.Add(label_PartNumber, 2, 1);
            tlp_OrderInfo_TEF.Controls.Add(lbl_ArtikelNr_Övrigt, 3, 1);
            tlp_OrderInfo_TEF.Controls.Add(lbl_Kund_Övrigt, 1, 0);
            tlp_OrderInfo_TEF.Dock = DockStyle.Top;
            tlp_OrderInfo_TEF.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlp_OrderInfo_TEF.Location = new Point(0, 0);
            tlp_OrderInfo_TEF.Margin = new Padding(0);
            tlp_OrderInfo_TEF.Name = "tlp_OrderInfo_TEF";
            tlp_OrderInfo_TEF.RowCount = 2;
            tlp_OrderInfo_TEF.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_OrderInfo_TEF.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_OrderInfo_TEF.Size = new Size(1155, 51);
            tlp_OrderInfo_TEF.TabIndex = 85;
            // 
            // lbl_Benämning_Övrigt
            // 
            lbl_Benämning_Övrigt.AutoSize = true;
            lbl_Benämning_Övrigt.BackColor = Color.White;
            lbl_Benämning_Övrigt.Dock = DockStyle.Fill;
            lbl_Benämning_Övrigt.Font = new Font("Consolas", 10F);
            lbl_Benämning_Övrigt.ForeColor = Color.DarkSlateGray;
            lbl_Benämning_Övrigt.Location = new Point(123, 26);
            lbl_Benämning_Övrigt.Margin = new Padding(1, 1, 0, 1);
            lbl_Benämning_Övrigt.Name = "lbl_Benämning_Övrigt";
            lbl_Benämning_Övrigt.Size = new Size(717, 24);
            lbl_Benämning_Övrigt.TabIndex = 924;
            lbl_Benämning_Övrigt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Description
            // 
            label_Description.BackColor = Color.White;
            label_Description.Dock = DockStyle.Fill;
            label_Description.Font = new Font("Arial", 12F);
            label_Description.ForeColor = Color.Black;
            label_Description.Location = new Point(1, 26);
            label_Description.Margin = new Padding(1, 1, 0, 1);
            label_Description.Name = "label_Description";
            label_Description.Size = new Size(121, 24);
            label_Description.TabIndex = 921;
            label_Description.Text = "Benämning:";
            label_Description.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderNr_Övrigt
            // 
            lbl_OrderNr_Övrigt.BackColor = Color.White;
            lbl_OrderNr_Övrigt.Dock = DockStyle.Fill;
            lbl_OrderNr_Övrigt.Font = new Font("Consolas", 10F);
            lbl_OrderNr_Övrigt.ForeColor = Color.DarkSlateGray;
            lbl_OrderNr_Övrigt.Location = new Point(981, 1);
            lbl_OrderNr_Övrigt.Margin = new Padding(1, 1, 1, 0);
            lbl_OrderNr_Övrigt.Name = "lbl_OrderNr_Övrigt";
            lbl_OrderNr_Övrigt.Size = new Size(173, 24);
            lbl_OrderNr_Övrigt.TabIndex = 915;
            lbl_OrderNr_Övrigt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr
            // 
            label_OrderNr.BackColor = Color.White;
            label_OrderNr.Dock = DockStyle.Fill;
            label_OrderNr.Font = new Font("Arial", 12F);
            label_OrderNr.ForeColor = Color.Black;
            label_OrderNr.Location = new Point(841, 1);
            label_OrderNr.Margin = new Padding(1, 1, 0, 0);
            label_OrderNr.Name = "label_OrderNr";
            label_OrderNr.Size = new Size(139, 24);
            label_OrderNr.TabIndex = 914;
            label_OrderNr.Text = "OrderNr: ";
            label_OrderNr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Customer
            // 
            label_Customer.BackColor = Color.White;
            label_Customer.Dock = DockStyle.Fill;
            label_Customer.Font = new Font("Arial", 12F);
            label_Customer.ForeColor = Color.Black;
            label_Customer.Location = new Point(1, 1);
            label_Customer.Margin = new Padding(1, 1, 0, 0);
            label_Customer.Name = "label_Customer";
            label_Customer.Size = new Size(121, 24);
            label_Customer.TabIndex = 898;
            label_Customer.Text = "Kund: ";
            label_Customer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_PartNumber
            // 
            label_PartNumber.BackColor = Color.White;
            label_PartNumber.Dock = DockStyle.Fill;
            label_PartNumber.Font = new Font("Arial", 12F);
            label_PartNumber.ForeColor = Color.Black;
            label_PartNumber.Location = new Point(841, 26);
            label_PartNumber.Margin = new Padding(1, 1, 0, 1);
            label_PartNumber.Name = "label_PartNumber";
            label_PartNumber.Size = new Size(139, 24);
            label_PartNumber.TabIndex = 922;
            label_PartNumber.Text = "ArtikelNr:";
            label_PartNumber.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_ArtikelNr_Övrigt
            // 
            lbl_ArtikelNr_Övrigt.BackColor = Color.White;
            lbl_ArtikelNr_Övrigt.Dock = DockStyle.Fill;
            lbl_ArtikelNr_Övrigt.Font = new Font("Consolas", 10F);
            lbl_ArtikelNr_Övrigt.ForeColor = Color.DarkSlateGray;
            lbl_ArtikelNr_Övrigt.Location = new Point(981, 26);
            lbl_ArtikelNr_Övrigt.Margin = new Padding(1);
            lbl_ArtikelNr_Övrigt.Name = "lbl_ArtikelNr_Övrigt";
            lbl_ArtikelNr_Övrigt.Size = new Size(173, 24);
            lbl_ArtikelNr_Övrigt.TabIndex = 923;
            lbl_ArtikelNr_Övrigt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Kund_Övrigt
            // 
            lbl_Kund_Övrigt.AutoSize = true;
            lbl_Kund_Övrigt.BackColor = Color.White;
            lbl_Kund_Övrigt.Dock = DockStyle.Fill;
            lbl_Kund_Övrigt.Font = new Font("Consolas", 10F);
            lbl_Kund_Övrigt.ForeColor = Color.DarkSlateGray;
            lbl_Kund_Övrigt.Location = new Point(123, 1);
            lbl_Kund_Övrigt.Margin = new Padding(1, 1, 0, 0);
            lbl_Kund_Övrigt.Name = "lbl_Kund_Övrigt";
            lbl_Kund_Övrigt.Size = new Size(717, 24);
            lbl_Kund_Övrigt.TabIndex = 902;
            lbl_Kund_Övrigt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flp_Buttons
            // 
            flp_Buttons.BackColor = Color.FromArgb(55, 55, 55);
            flp_Buttons.Controls.Add(btn_TransferLengthMeasure);
            flp_Buttons.Controls.Add(btn_TransferMeasurement);
            flp_Buttons.Controls.Add(btn_EditBag);
            flp_Buttons.Controls.Add(btn_EditAmount);
            flp_Buttons.Controls.Add(btn_Discard);
            flp_Buttons.Controls.Add(btn_TransferToExcel);
            flp_Buttons.Dock = DockStyle.Bottom;
            flp_Buttons.Location = new Point(0, 788);
            flp_Buttons.Margin = new Padding(4, 3, 4, 3);
            flp_Buttons.Name = "flp_Buttons";
            flp_Buttons.Size = new Size(1155, 69);
            flp_Buttons.TabIndex = 986;
            // 
            // btn_TransferLengthMeasure
            // 
            btn_TransferLengthMeasure.BackColor = Color.FromArgb(50, 50, 50);
            btn_TransferLengthMeasure.Cursor = Cursors.Hand;
            btn_TransferLengthMeasure.FlatAppearance.BorderColor = Color.FromArgb(198, 239, 206);
            btn_TransferLengthMeasure.FlatAppearance.BorderSize = 3;
            btn_TransferLengthMeasure.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 255);
            btn_TransferLengthMeasure.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 97, 0);
            btn_TransferLengthMeasure.FlatStyle = FlatStyle.Flat;
            btn_TransferLengthMeasure.Font = new Font("Palatino Linotype", 9F);
            btn_TransferLengthMeasure.ForeColor = Color.White;
            btn_TransferLengthMeasure.Location = new Point(6, 6);
            btn_TransferLengthMeasure.Margin = new Padding(6, 6, 6, 1);
            btn_TransferLengthMeasure.Name = "btn_TransferLengthMeasure";
            btn_TransferLengthMeasure.Size = new Size(124, 58);
            btn_TransferLengthMeasure.TabIndex = 10;
            btn_TransferLengthMeasure.Text = "Överför Längdmätning";
            btn_TransferLengthMeasure.UseVisualStyleBackColor = false;
            btn_TransferLengthMeasure.Visible = false;
            btn_TransferLengthMeasure.Click += TransferLengthMeasure_Click;
            // 
            // btn_TransferMeasurement
            // 
            btn_TransferMeasurement.BackColor = Color.FromArgb(50, 50, 50);
            btn_TransferMeasurement.Cursor = Cursors.Hand;
            btn_TransferMeasurement.FlatAppearance.BorderColor = Color.FromArgb(198, 239, 206);
            btn_TransferMeasurement.FlatAppearance.BorderSize = 3;
            btn_TransferMeasurement.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 97, 0);
            btn_TransferMeasurement.FlatStyle = FlatStyle.Flat;
            btn_TransferMeasurement.Font = new Font("Palatino Linotype", 9F);
            btn_TransferMeasurement.ForeColor = Color.White;
            btn_TransferMeasurement.Location = new Point(142, 6);
            btn_TransferMeasurement.Margin = new Padding(6, 6, 6, 1);
            btn_TransferMeasurement.Name = "btn_TransferMeasurement";
            btn_TransferMeasurement.Size = new Size(124, 58);
            btn_TransferMeasurement.TabIndex = 48;
            btn_TransferMeasurement.Text = "Överför Mätning";
            btn_TransferMeasurement.UseVisualStyleBackColor = false;
            btn_TransferMeasurement.Click += TransferMeasurement_Click;
            // 
            // btn_EditBag
            // 
            btn_EditBag.BackColor = Color.FromArgb(50, 50, 50);
            btn_EditBag.Cursor = Cursors.Hand;
            btn_EditBag.FlatAppearance.BorderColor = Color.FromArgb(156, 101, 0);
            btn_EditBag.FlatAppearance.BorderSize = 3;
            btn_EditBag.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 235, 156);
            btn_EditBag.FlatStyle = FlatStyle.Flat;
            btn_EditBag.Font = new Font("Palatino Linotype", 9F);
            btn_EditBag.ForeColor = Color.White;
            btn_EditBag.Location = new Point(301, 6);
            btn_EditBag.Margin = new Padding(29, 6, 6, 1);
            btn_EditBag.Name = "btn_EditBag";
            btn_EditBag.Size = new Size(133, 58);
            btn_EditBag.TabIndex = 855;
            btn_EditBag.Text = "Redigera PåseNr/SpoleNr";
            btn_EditBag.UseVisualStyleBackColor = false;
            btn_EditBag.Visible = false;
            btn_EditBag.Click += EditBag_Click;
            // 
            // btn_EditAmount
            // 
            btn_EditAmount.BackColor = Color.FromArgb(50, 50, 50);
            btn_EditAmount.Cursor = Cursors.Hand;
            btn_EditAmount.FlatAppearance.BorderColor = Color.FromArgb(156, 101, 0);
            btn_EditAmount.FlatAppearance.BorderSize = 3;
            btn_EditAmount.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 235, 156);
            btn_EditAmount.FlatStyle = FlatStyle.Flat;
            btn_EditAmount.Font = new Font("Palatino Linotype", 9F);
            btn_EditAmount.ForeColor = Color.White;
            btn_EditAmount.Location = new Point(469, 6);
            btn_EditAmount.Margin = new Padding(29, 6, 6, 1);
            btn_EditAmount.Name = "btn_EditAmount";
            btn_EditAmount.Size = new Size(102, 58);
            btn_EditAmount.TabIndex = 48;
            btn_EditAmount.Text = "Redigera Mängd";
            btn_EditAmount.UseVisualStyleBackColor = false;
            btn_EditAmount.Visible = false;
            btn_EditAmount.Click += EditTotal_Click;
            // 
            // btn_Discard
            // 
            btn_Discard.BackColor = Color.FromArgb(50, 50, 50);
            btn_Discard.Cursor = Cursors.Hand;
            btn_Discard.FlatAppearance.BorderColor = Color.FromArgb(156, 0, 6);
            btn_Discard.FlatAppearance.BorderSize = 3;
            btn_Discard.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 199, 206);
            btn_Discard.FlatStyle = FlatStyle.Flat;
            btn_Discard.Font = new Font("Palatino Linotype", 9F);
            btn_Discard.ForeColor = Color.White;
            btn_Discard.Location = new Point(612, 6);
            btn_Discard.Margin = new Padding(35, 6, 1, 6);
            btn_Discard.Name = "btn_Discard";
            btn_Discard.Size = new Size(156, 58);
            btn_Discard.TabIndex = 853;
            btn_Discard.Text = "Kassera Mätning";
            btn_Discard.UseVisualStyleBackColor = false;
            btn_Discard.Click += DiscardMeasurement_Click;
            // 
            // btn_TransferToExcel
            // 
            btn_TransferToExcel.BackColor = Color.FromArgb(50, 50, 50);
            btn_TransferToExcel.Cursor = Cursors.Hand;
            btn_TransferToExcel.FlatAppearance.BorderColor = Color.FromArgb(198, 239, 206);
            btn_TransferToExcel.FlatAppearance.BorderSize = 3;
            btn_TransferToExcel.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 97, 0);
            btn_TransferToExcel.FlatStyle = FlatStyle.Flat;
            btn_TransferToExcel.Font = new Font("Palatino Linotype", 9F);
            btn_TransferToExcel.ForeColor = Color.White;
            btn_TransferToExcel.Location = new Point(827, 6);
            btn_TransferToExcel.Margin = new Padding(58, 6, 6, 1);
            btn_TransferToExcel.Name = "btn_TransferToExcel";
            btn_TransferToExcel.Size = new Size(161, 58);
            btn_TransferToExcel.TabIndex = 854;
            btn_TransferToExcel.Text = "Överför Mätningar till Excel";
            btn_TransferToExcel.UseVisualStyleBackColor = false;
            btn_TransferToExcel.Visible = false;
            // 
            // tlp_Help_InputData_1
            // 
            tlp_Help_InputData_1.BackColor = Color.Transparent;
            tlp_Help_InputData_1.ColumnCount = 2;
            tlp_Help_InputData_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlp_Help_InputData_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            tlp_Help_InputData_1.Controls.Add(btn_Clear_HelpInput_1, 0, 0);
            tlp_Help_InputData_1.Controls.Add(dgv_HelpInput_1, 0, 1);
            tlp_Help_InputData_1.Controls.Add(dgv_Walls, 1, 1);
            tlp_Help_InputData_1.Dock = DockStyle.Left;
            tlp_Help_InputData_1.Location = new Point(0, 0);
            tlp_Help_InputData_1.Margin = new Padding(0);
            tlp_Help_InputData_1.Name = "tlp_Help_InputData_1";
            tlp_Help_InputData_1.RowCount = 2;
            tlp_Help_InputData_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlp_Help_InputData_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Help_InputData_1.Size = new Size(204, 239);
            tlp_Help_InputData_1.TabIndex = 984;
            tlp_Help_InputData_1.Visible = false;
            // 
            // btn_Clear_HelpInput_1
            // 
            btn_Clear_HelpInput_1.BackColor = Color.FromArgb(50, 50, 50);
            btn_Clear_HelpInput_1.Dock = DockStyle.Fill;
            btn_Clear_HelpInput_1.FlatAppearance.BorderColor = Color.FromArgb(156, 0, 6);
            btn_Clear_HelpInput_1.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 199, 206);
            btn_Clear_HelpInput_1.FlatStyle = FlatStyle.Flat;
            btn_Clear_HelpInput_1.Font = new Font("Palatino Linotype", 9F);
            btn_Clear_HelpInput_1.ForeColor = Color.White;
            btn_Clear_HelpInput_1.Location = new Point(0, 0);
            btn_Clear_HelpInput_1.Margin = new Padding(0);
            btn_Clear_HelpInput_1.Name = "btn_Clear_HelpInput_1";
            btn_Clear_HelpInput_1.Size = new Size(88, 28);
            btn_Clear_HelpInput_1.TabIndex = 854;
            btn_Clear_HelpInput_1.Text = "Töm";
            btn_Clear_HelpInput_1.UseVisualStyleBackColor = false;
            btn_Clear_HelpInput_1.Click += Clear_HelpInput_1_Click;
            // 
            // dgv_HelpInput_1
            // 
            dgv_HelpInput_1.AllowUserToAddRows = false;
            dgv_HelpInput_1.AllowUserToDeleteRows = false;
            dgv_HelpInput_1.AllowUserToResizeColumns = false;
            dgv_HelpInput_1.AllowUserToResizeRows = false;
            dgv_HelpInput_1.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_HelpInput_1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_HelpInput_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_HelpInput_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_HelpInput_1.ColumnHeadersVisible = false;
            dgv_HelpInput_1.Columns.AddRange(new DataGridViewColumn[] { RowHeaders, Value });
            dgv_HelpInput_1.Cursor = Cursors.IBeam;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Khaki;
            dataGridViewCellStyle4.Font = new Font("Courier New", 8.25F);
            dataGridViewCellStyle4.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgv_HelpInput_1.DefaultCellStyle = dataGridViewCellStyle4;
            dgv_HelpInput_1.Dock = DockStyle.Fill;
            dgv_HelpInput_1.Location = new Point(0, 28);
            dgv_HelpInput_1.Margin = new Padding(0);
            dgv_HelpInput_1.Name = "dgv_HelpInput_1";
            dgv_HelpInput_1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgv_HelpInput_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgv_HelpInput_1.RowHeadersVisible = false;
            dgv_HelpInput_1.RowHeadersWidth = 30;
            dgv_HelpInput_1.RowTemplate.Height = 20;
            dgv_HelpInput_1.ShowEditingIcon = false;
            dgv_HelpInput_1.ShowRowErrors = false;
            dgv_HelpInput_1.Size = new Size(88, 211);
            dgv_HelpInput_1.TabIndex = 0;
            dgv_HelpInput_1.EditingControlShowing += HelpInput_1_EditingControlShowing;
            // 
            // RowHeaders
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            RowHeaders.DefaultCellStyle = dataGridViewCellStyle2;
            RowHeaders.Frozen = true;
            RowHeaders.HeaderText = "Row Headers";
            RowHeaders.Name = "RowHeaders";
            RowHeaders.ReadOnly = true;
            RowHeaders.SortMode = DataGridViewColumnSortMode.NotSortable;
            RowHeaders.Width = 25;
            // 
            // Value
            // 
            Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.BackColor = Color.Khaki;
            dataGridViewCellStyle3.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            Value.DefaultCellStyle = dataGridViewCellStyle3;
            Value.Frozen = true;
            Value.HeaderText = "Values";
            Value.MaxInputLength = 5;
            Value.Name = "Value";
            Value.SortMode = DataGridViewColumnSortMode.NotSortable;
            Value.Width = 74;
            // 
            // dgv_Walls
            // 
            dgv_Walls.AllowUserToAddRows = false;
            dgv_Walls.AllowUserToDeleteRows = false;
            dgv_Walls.AllowUserToResizeColumns = false;
            dgv_Walls.AllowUserToResizeRows = false;
            dgv_Walls.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_Walls.BorderStyle = BorderStyle.None;
            dgv_Walls.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv_Walls.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Walls.ColumnHeadersVisible = false;
            dgv_Walls.Columns.AddRange(new DataGridViewColumn[] { col_Info, col_Wall });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgv_Walls.DefaultCellStyle = dataGridViewCellStyle7;
            dgv_Walls.Dock = DockStyle.Fill;
            dgv_Walls.GridColor = Color.FromArgb(25, 25, 25);
            dgv_Walls.Location = new Point(88, 28);
            dgv_Walls.Margin = new Padding(0);
            dgv_Walls.Name = "dgv_Walls";
            dgv_Walls.ReadOnly = true;
            dgv_Walls.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle8.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgv_Walls.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgv_Walls.RowHeadersVisible = false;
            dgv_Walls.RowHeadersWidth = 20;
            dgv_Walls.RowTemplate.ReadOnly = true;
            dgv_Walls.ScrollBars = ScrollBars.None;
            dgv_Walls.Size = new Size(117, 211);
            dgv_Walls.TabIndex = 856;
            dgv_Walls.PreviewKeyDown += Walls_PreviewKeyDown;
            // 
            // col_Info
            // 
            col_Info.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col_Info.HeaderText = "Info";
            col_Info.Name = "col_Info";
            col_Info.ReadOnly = true;
            col_Info.Width = 5;
            // 
            // col_Wall
            // 
            col_Wall.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle6.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            col_Wall.DefaultCellStyle = dataGridViewCellStyle6;
            col_Wall.HeaderText = "Wall";
            col_Wall.Name = "col_Wall";
            col_Wall.ReadOnly = true;
            // 
            // btn_Clear_HelpInput_2
            // 
            btn_Clear_HelpInput_2.BackColor = Color.FromArgb(50, 50, 50);
            btn_Clear_HelpInput_2.FlatAppearance.BorderColor = Color.FromArgb(156, 0, 6);
            btn_Clear_HelpInput_2.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 199, 206);
            btn_Clear_HelpInput_2.FlatStyle = FlatStyle.Flat;
            btn_Clear_HelpInput_2.Font = new Font("Palatino Linotype", 9F);
            btn_Clear_HelpInput_2.ForeColor = Color.White;
            btn_Clear_HelpInput_2.Location = new Point(0, 0);
            btn_Clear_HelpInput_2.Margin = new Padding(0);
            btn_Clear_HelpInput_2.Name = "btn_Clear_HelpInput_2";
            btn_Clear_HelpInput_2.Size = new Size(88, 28);
            btn_Clear_HelpInput_2.TabIndex = 855;
            btn_Clear_HelpInput_2.Text = "Töm";
            btn_Clear_HelpInput_2.UseVisualStyleBackColor = false;
            // 
            // dgv_RecWalls
            // 
            dgv_RecWalls.AllowUserToAddRows = false;
            dgv_RecWalls.AllowUserToDeleteRows = false;
            dgv_RecWalls.AllowUserToResizeColumns = false;
            dgv_RecWalls.AllowUserToResizeRows = false;
            dgv_RecWalls.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_RecWalls.BorderStyle = BorderStyle.None;
            dgv_RecWalls.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv_RecWalls.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_RecWalls.ColumnHeadersVisible = false;
            dgv_RecWalls.Columns.AddRange(new DataGridViewColumn[] { col_RecInfo, col_RecWall });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgv_RecWalls.DefaultCellStyle = dataGridViewCellStyle10;
            dgv_RecWalls.Dock = DockStyle.Fill;
            dgv_RecWalls.GridColor = Color.FromArgb(25, 25, 25);
            dgv_RecWalls.Location = new Point(88, 28);
            dgv_RecWalls.Margin = new Padding(0);
            dgv_RecWalls.Name = "dgv_RecWalls";
            dgv_RecWalls.ReadOnly = true;
            dgv_RecWalls.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle11.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.White;
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle11.SelectionForeColor = Color.White;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgv_RecWalls.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgv_RecWalls.RowHeadersVisible = false;
            dgv_RecWalls.RowHeadersWidth = 20;
            dgv_RecWalls.RowTemplate.ReadOnly = true;
            dgv_RecWalls.ScrollBars = ScrollBars.None;
            dgv_RecWalls.Size = new Size(117, 211);
            dgv_RecWalls.TabIndex = 857;
            // 
            // col_RecInfo
            // 
            col_RecInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col_RecInfo.HeaderText = "Info";
            col_RecInfo.Name = "col_RecInfo";
            col_RecInfo.ReadOnly = true;
            col_RecInfo.Width = 5;
            // 
            // col_RecWall
            // 
            col_RecWall.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle9.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.White;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            col_RecWall.DefaultCellStyle = dataGridViewCellStyle9;
            col_RecWall.HeaderText = "Wall";
            col_RecWall.Name = "col_RecWall";
            col_RecWall.ReadOnly = true;
            // 
            // dgv_HelpInput_2
            // 
            dgv_HelpInput_2.AllowUserToAddRows = false;
            dgv_HelpInput_2.AllowUserToDeleteRows = false;
            dgv_HelpInput_2.AllowUserToResizeColumns = false;
            dgv_HelpInput_2.AllowUserToResizeRows = false;
            dgv_HelpInput_2.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_HelpInput_2.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Control;
            dataGridViewCellStyle12.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dgv_HelpInput_2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dgv_HelpInput_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_HelpInput_2.ColumnHeadersVisible = false;
            dgv_HelpInput_2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dgv_HelpInput_2.Cursor = Cursors.IBeam;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = Color.Khaki;
            dataGridViewCellStyle15.Font = new Font("Courier New", 8.25F);
            dataGridViewCellStyle15.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.False;
            dgv_HelpInput_2.DefaultCellStyle = dataGridViewCellStyle15;
            dgv_HelpInput_2.Location = new Point(0, 28);
            dgv_HelpInput_2.Margin = new Padding(0);
            dgv_HelpInput_2.Name = "dgv_HelpInput_2";
            dgv_HelpInput_2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle16.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle16.ForeColor = Color.White;
            dataGridViewCellStyle16.SelectionBackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle16.SelectionForeColor = Color.White;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
            dgv_HelpInput_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            dgv_HelpInput_2.RowHeadersVisible = false;
            dgv_HelpInput_2.RowHeadersWidth = 30;
            dgv_HelpInput_2.RowTemplate.Height = 20;
            dgv_HelpInput_2.ShowEditingIcon = false;
            dgv_HelpInput_2.ShowRowErrors = false;
            dgv_HelpInput_2.Size = new Size(88, 211);
            dgv_HelpInput_2.TabIndex = 2;
            dgv_HelpInput_2.EditingControlShowing += HelpInput_2_EditingControlShowing;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle13.ForeColor = Color.White;
            dataGridViewCellStyle13.SelectionBackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle13.SelectionForeColor = Color.White;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewTextBoxColumn1.Frozen = true;
            dataGridViewTextBoxColumn1.HeaderText = "Row Headers";
            dataGridViewTextBoxColumn1.MaxInputLength = 2;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle14.BackColor = Color.Khaki;
            dataGridViewCellStyle14.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = Color.White;
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewTextBoxColumn2.Frozen = true;
            dataGridViewTextBoxColumn2.HeaderText = "Values";
            dataGridViewTextBoxColumn2.MaxInputLength = 5;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn2.Width = 74;
            // 
            // pb_CrossSectionTube
            // 
            pb_CrossSectionTube.BackColor = Color.Transparent;
            pb_CrossSectionTube.BackgroundImageLayout = ImageLayout.Stretch;
            pb_CrossSectionTube.Dock = DockStyle.Left;
            pb_CrossSectionTube.Location = new Point(408, 0);
            pb_CrossSectionTube.Margin = new Padding(0);
            pb_CrossSectionTube.Name = "pb_CrossSectionTube";
            pb_CrossSectionTube.Size = new Size(233, 239);
            pb_CrossSectionTube.TabIndex = 985;
            pb_CrossSectionTube.TabStop = false;
            // 
            // tlp_Mätdon
            // 
            tlp_Mätdon.BackColor = Color.FromArgb(15, 15, 15);
            tlp_Mätdon.ColumnCount = 2;
            tlp_Mätdon.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.10506F));
            tlp_Mätdon.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.89493F));
            tlp_Mätdon.Controls.Add(tb_Hack, 1, 0);
            tlp_Mätdon.Controls.Add(label_HackNr, 0, 0);
            tlp_Mätdon.Controls.Add(measureInstrument, 0, 1);
            tlp_Mätdon.Dock = DockStyle.Right;
            tlp_Mätdon.Location = new Point(699, 0);
            tlp_Mätdon.Margin = new Padding(0, 5, 0, 0);
            tlp_Mätdon.Name = "tlp_Mätdon";
            tlp_Mätdon.RowCount = 2;
            tlp_Mätdon.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Mätdon.RowStyles.Add(new RowStyle(SizeType.Percent, 99.99999F));
            tlp_Mätdon.Size = new Size(456, 239);
            tlp_Mätdon.TabIndex = 987;
            // 
            // tb_Hack
            // 
            tb_Hack.BorderStyle = BorderStyle.None;
            tb_Hack.Dock = DockStyle.Fill;
            tb_Hack.Font = new Font("Consolas", 10F);
            tb_Hack.ForeColor = Color.DarkSlateGray;
            tb_Hack.Location = new Point(160, 0);
            tb_Hack.Margin = new Padding(0, 0, 0, 1);
            tb_Hack.MaxLength = 20;
            tb_Hack.Multiline = true;
            tb_Hack.Name = "tb_Hack";
            tb_Hack.Size = new Size(296, 24);
            tb_Hack.TabIndex = 960;
            tb_Hack.Leave += Hack_Leave;
            // 
            // label_HackNr
            // 
            label_HackNr.BackColor = Color.Transparent;
            label_HackNr.Dock = DockStyle.Right;
            label_HackNr.Font = new Font("Arial", 10F);
            label_HackNr.ForeColor = Color.White;
            label_HackNr.Location = new Point(1, 1);
            label_HackNr.Margin = new Padding(1, 1, 0, 1);
            label_HackNr.Name = "label_HackNr";
            label_HackNr.Size = new Size(159, 23);
            label_HackNr.TabIndex = 959;
            label_HackNr.Text = "Hack/Upptagare nr:";
            label_HackNr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // measureInstrument
            // 
            measureInstrument.AutoSize = true;
            measureInstrument.BackColor = Color.FromArgb(35, 103, 112);
            tlp_Mätdon.SetColumnSpan(measureInstrument, 2);
            measureInstrument.Dock = DockStyle.Fill;
            measureInstrument.Location = new Point(5, 28);
            measureInstrument.Margin = new Padding(5, 3, 5, 3);
            measureInstrument.Name = "measureInstrument";
            measureInstrument.Size = new Size(446, 208);
            measureInstrument.TabIndex = 961;
            measureInstrument.TabStop = false;
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.FromArgb(25, 25, 25);
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 270F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 510F));
            tlp_Main.Controls.Add(dgv_Measurements, 0, 0);
            tlp_Main.Controls.Add(tlp_Info_Colors, 0, 1);
            tlp_Main.Controls.Add(flp_Headers, 0, 2);
            tlp_Main.Controls.Add(flp_InputControls, 0, 3);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 119);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 4;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_Main.Size = new Size(1155, 430);
            tlp_Main.TabIndex = 988;
            // 
            // dgv_Measurements
            // 
            dgv_Measurements.AllowUserToAddRows = false;
            dgv_Measurements.AllowUserToDeleteRows = false;
            dgv_Measurements.AllowUserToResizeColumns = false;
            dgv_Measurements.AllowUserToResizeRows = false;
            dgv_Measurements.BackgroundColor = Color.White;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle17.BackColor = SystemColors.Info;
            dataGridViewCellStyle17.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle17.ForeColor = SystemColors.ControlDark;
            dataGridViewCellStyle17.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dgv_Measurements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dgv_Measurements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlp_Main.SetColumnSpan(dgv_Measurements, 2);
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = SystemColors.Window;
            dataGridViewCellStyle18.Font = new Font("Courier New", 9.25F);
            dataGridViewCellStyle18.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            dgv_Measurements.DefaultCellStyle = dataGridViewCellStyle18;
            dgv_Measurements.Dock = DockStyle.Fill;
            dgv_Measurements.EnableHeadersVisualStyles = false;
            dgv_Measurements.Location = new Point(0, 0);
            dgv_Measurements.Margin = new Padding(0);
            dgv_Measurements.MultiSelect = false;
            dgv_Measurements.Name = "dgv_Measurements";
            dgv_Measurements.ReadOnly = true;
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = SystemColors.Control;
            dataGridViewCellStyle19.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle19.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dgv_Measurements.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dgv_Measurements.RowHeadersVisible = false;
            dgv_Measurements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Measurements.Size = new Size(1155, 278);
            dgv_Measurements.TabIndex = 86;
            dgv_Measurements.TabStop = false;
            dgv_Measurements.CellMouseDoubleClick += CopyRow_Measurements_CellMouseDoubleClick;
            dgv_Measurements.ColumnHeaderMouseClick += SortMeasurementSpool;
            // 
            // tlp_Info_Colors
            // 
            tlp_Info_Colors.BackColor = Color.FromArgb(45, 113, 122);
            tlp_Info_Colors.ColumnCount = 3;
            tlp_Main.SetColumnSpan(tlp_Info_Colors, 2);
            tlp_Info_Colors.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 251F));
            tlp_Info_Colors.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 229F));
            tlp_Info_Colors.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlp_Info_Colors.Controls.Add(label_Discarded, 1, 1);
            tlp_Info_Colors.Controls.Add(label_Ok, 0, 0);
            tlp_Info_Colors.Controls.Add(label_Fail, 0, 1);
            tlp_Info_Colors.Controls.Add(label_Felskrivning, 1, 0);
            tlp_Info_Colors.Controls.Add(label_Warning, 0, 2);
            tlp_Info_Colors.Controls.Add(panel1, 2, 0);
            tlp_Info_Colors.Dock = DockStyle.Fill;
            tlp_Info_Colors.Location = new Point(1, 278);
            tlp_Info_Colors.Margin = new Padding(1, 0, 1, 1);
            tlp_Info_Colors.Name = "tlp_Info_Colors";
            tlp_Info_Colors.RowCount = 3;
            tlp_Info_Colors.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Info_Colors.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Info_Colors.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Info_Colors.Size = new Size(1153, 73);
            tlp_Info_Colors.TabIndex = 977;
            // 
            // label_Discarded
            // 
            label_Discarded.BackColor = Color.DimGray;
            label_Discarded.Dock = DockStyle.Fill;
            label_Discarded.Font = new Font("Segoe UI", 9F, FontStyle.Strikeout, GraphicsUnit.Point, 0);
            label_Discarded.ForeColor = Color.FromArgb(60, 60, 60);
            label_Discarded.Location = new Point(251, 23);
            label_Discarded.Margin = new Padding(0);
            label_Discarded.Name = "label_Discarded";
            label_Discarded.Size = new Size(229, 23);
            label_Discarded.TabIndex = 973;
            label_Discarded.Text = "Kasserad";
            label_Discarded.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Ok
            // 
            label_Ok.BackColor = Color.FromArgb(198, 239, 206);
            label_Ok.Dock = DockStyle.Fill;
            label_Ok.Font = new Font("Segoe UI", 8.75F);
            label_Ok.ForeColor = Color.FromArgb(0, 97, 0);
            label_Ok.Location = new Point(0, 0);
            label_Ok.Margin = new Padding(0);
            label_Ok.Name = "label_Ok";
            label_Ok.Size = new Size(251, 23);
            label_Ok.TabIndex = 954;
            label_Ok.Text = "Värde ok";
            label_Ok.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Fail
            // 
            label_Fail.BackColor = Color.FromArgb(255, 199, 206);
            label_Fail.Dock = DockStyle.Fill;
            label_Fail.Font = new Font("Segoe UI", 8.75F);
            label_Fail.ForeColor = Color.FromArgb(156, 0, 6);
            label_Fail.Location = new Point(0, 23);
            label_Fail.Margin = new Padding(0);
            label_Fail.Name = "label_Fail";
            label_Fail.Size = new Size(251, 23);
            label_Fail.TabIndex = 954;
            label_Fail.Text = "Värde utanför Spec.";
            label_Fail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Felskrivning
            // 
            label_Felskrivning.BackColor = Color.FromArgb(180, 198, 231);
            label_Felskrivning.Dock = DockStyle.Fill;
            label_Felskrivning.Font = new Font("Segoe UI", 8.75F);
            label_Felskrivning.ForeColor = Color.DarkSlateGray;
            label_Felskrivning.Location = new Point(251, 0);
            label_Felskrivning.Margin = new Padding(0);
            label_Felskrivning.Name = "label_Felskrivning";
            label_Felskrivning.Size = new Size(229, 23);
            label_Felskrivning.TabIndex = 954;
            label_Felskrivning.Text = "Felskrivning?";
            label_Felskrivning.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Warning
            // 
            label_Warning.BackColor = Color.FromArgb(255, 235, 156);
            label_Warning.Dock = DockStyle.Fill;
            label_Warning.Font = new Font("Segoe UI", 8.75F);
            label_Warning.ForeColor = Color.FromArgb(156, 101, 0);
            label_Warning.Location = new Point(0, 46);
            label_Warning.Margin = new Padding(0);
            label_Warning.Name = "label_Warning";
            label_Warning.Size = new Size(251, 27);
            label_Warning.TabIndex = 954;
            label_Warning.Text = "Varning, värde utanför styrgräns";
            label_Warning.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 113, 122);
            panel1.Controls.Add(pb_Info);
            panel1.Controls.Add(label_TotalMeasureMents);
            panel1.Controls.Add(lbl_DiscardedMeasurements);
            panel1.Controls.Add(lbl_TotalMeasurements);
            panel1.Controls.Add(label_DiscardedMeasurements);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(480, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            tlp_Info_Colors.SetRowSpan(panel1, 3);
            panel1.Size = new Size(673, 73);
            panel1.TabIndex = 977;
            // 
            // label_TotalMeasureMents
            // 
            label_TotalMeasureMents.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_TotalMeasureMents.AutoSize = true;
            label_TotalMeasureMents.ForeColor = Color.FromArgb(187, 215, 228);
            label_TotalMeasureMents.Location = new Point(494, 7);
            label_TotalMeasureMents.Name = "label_TotalMeasureMents";
            label_TotalMeasureMents.Size = new Size(128, 15);
            label_TotalMeasureMents.TabIndex = 976;
            label_TotalMeasureMents.Text = "Totalt Antal Mätningar:";
            label_TotalMeasureMents.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_DiscardedMeasurements
            // 
            lbl_DiscardedMeasurements.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_DiscardedMeasurements.AutoSize = true;
            lbl_DiscardedMeasurements.Font = new Font("Segoe UI", 10F);
            lbl_DiscardedMeasurements.ForeColor = Color.FromArgb(187, 215, 228);
            lbl_DiscardedMeasurements.Location = new Point(628, 28);
            lbl_DiscardedMeasurements.Name = "lbl_DiscardedMeasurements";
            lbl_DiscardedMeasurements.Size = new Size(17, 19);
            lbl_DiscardedMeasurements.TabIndex = 976;
            lbl_DiscardedMeasurements.Text = "0";
            // 
            // lbl_TotalMeasurements
            // 
            lbl_TotalMeasurements.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_TotalMeasurements.AutoSize = true;
            lbl_TotalMeasurements.Font = new Font("Segoe UI", 10F);
            lbl_TotalMeasurements.ForeColor = Color.FromArgb(187, 215, 228);
            lbl_TotalMeasurements.Location = new Point(628, 5);
            lbl_TotalMeasurements.Name = "lbl_TotalMeasurements";
            lbl_TotalMeasurements.Size = new Size(17, 19);
            lbl_TotalMeasurements.TabIndex = 976;
            lbl_TotalMeasurements.Text = "0";
            // 
            // label_DiscardedMeasurements
            // 
            label_DiscardedMeasurements.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_DiscardedMeasurements.AutoSize = true;
            label_DiscardedMeasurements.ForeColor = Color.FromArgb(187, 215, 228);
            label_DiscardedMeasurements.Location = new Point(470, 28);
            label_DiscardedMeasurements.Name = "label_DiscardedMeasurements";
            label_DiscardedMeasurements.Size = new Size(152, 15);
            label_DiscardedMeasurements.TabIndex = 976;
            label_DiscardedMeasurements.Text = "Totalt Kasserade Mätningar:";
            label_DiscardedMeasurements.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flp_Headers
            // 
            flp_Headers.BackColor = Color.FromArgb(10, 10, 10);
            tlp_Main.SetColumnSpan(flp_Headers, 2);
            flp_Headers.Dock = DockStyle.Fill;
            flp_Headers.Location = new Point(0, 352);
            flp_Headers.Margin = new Padding(0);
            flp_Headers.Name = "flp_Headers";
            flp_Headers.Size = new Size(1155, 51);
            flp_Headers.TabIndex = 978;
            // 
            // pb_Info
            // 
            pb_Info.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pb_Info.BackColor = Color.Transparent;
            pb_Info.BackgroundImage = (Image)resources.GetObject("pb_Info.BackgroundImage");
            pb_Info.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info.Cursor = Cursors.Hand;
            pb_Info.Location = new Point(2, 3);
            pb_Info.Margin = new Padding(4, 3, 4, 3);
            pb_Info.Name = "pb_Info";
            pb_Info.Size = new Size(47, 45);
            pb_Info.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Info.TabIndex = 974;
            pb_Info.TabStop = false;
            // 
            // flp_InputControls
            // 
            flp_InputControls.BackColor = Color.FromArgb(10, 10, 10);
            tlp_Main.SetColumnSpan(flp_InputControls, 2);
            flp_InputControls.Dock = DockStyle.Fill;
            flp_InputControls.Location = new Point(0, 403);
            flp_InputControls.Margin = new Padding(0, 0, 0, 2);
            flp_InputControls.Name = "flp_InputControls";
            flp_InputControls.Size = new Size(1155, 25);
            flp_InputControls.TabIndex = 979;
            // 
            // panel_Bottom
            // 
            panel_Bottom.BackColor = Color.FromArgb(25, 25, 25);
            panel_Bottom.Controls.Add(pb_CrossSectionTube);
            panel_Bottom.Controls.Add(tlp_Help_InputData_2);
            panel_Bottom.Controls.Add(tlp_Help_InputData_1);
            panel_Bottom.Controls.Add(tlp_Mätdon);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 549);
            panel_Bottom.Margin = new Padding(4, 3, 4, 3);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(1155, 239);
            panel_Bottom.TabIndex = 989;
            // 
            // tlp_Help_InputData_2
            // 
            tlp_Help_InputData_2.BackColor = Color.Transparent;
            tlp_Help_InputData_2.ColumnCount = 2;
            tlp_Help_InputData_2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlp_Help_InputData_2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            tlp_Help_InputData_2.Controls.Add(btn_Clear_HelpInput_2, 0, 0);
            tlp_Help_InputData_2.Controls.Add(dgv_HelpInput_2, 0, 1);
            tlp_Help_InputData_2.Controls.Add(dgv_RecWalls, 1, 1);
            tlp_Help_InputData_2.Dock = DockStyle.Left;
            tlp_Help_InputData_2.Location = new Point(204, 0);
            tlp_Help_InputData_2.Margin = new Padding(0);
            tlp_Help_InputData_2.Name = "tlp_Help_InputData_2";
            tlp_Help_InputData_2.RowCount = 2;
            tlp_Help_InputData_2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlp_Help_InputData_2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Help_InputData_2.Size = new Size(204, 239);
            tlp_Help_InputData_2.TabIndex = 985;
            tlp_Help_InputData_2.Visible = false;
            // 
            // tlp_OrderInfo_FEP
            // 
            tlp_OrderInfo_FEP.BackColor = Color.FromArgb(25, 25, 25);
            tlp_OrderInfo_FEP.ColumnCount = 14;
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 99F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 47F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 47F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 47F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 47F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
            tlp_OrderInfo_FEP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 490F));
            tlp_OrderInfo_FEP.Controls.Add(label_OD, 6, 0);
            tlp_OrderInfo_FEP.Controls.Add(lbl_Nom_OD, 7, 0);
            tlp_OrderInfo_FEP.Controls.Add(label_Wall, 8, 0);
            tlp_OrderInfo_FEP.Controls.Add(lbl_Nom_Wall, 9, 0);
            tlp_OrderInfo_FEP.Controls.Add(label_Length, 10, 0);
            tlp_OrderInfo_FEP.Controls.Add(lbl_Nom_Length, 11, 0);
            tlp_OrderInfo_FEP.Controls.Add(lbl_Nom_ID, 5, 0);
            tlp_OrderInfo_FEP.Controls.Add(label_ID, 4, 0);
            tlp_OrderInfo_FEP.Controls.Add(lbl_OrderNr_FEP, 13, 0);
            tlp_OrderInfo_FEP.Controls.Add(label_OrderNr_2, 12, 0);
            tlp_OrderInfo_FEP.Controls.Add(label_Customer_2, 0, 0);
            tlp_OrderInfo_FEP.Controls.Add(lbl_Kund_FEP, 1, 0);
            tlp_OrderInfo_FEP.Controls.Add(Co_Extrudering, 0, 1);
            tlp_OrderInfo_FEP.Controls.Add(Röntgen, 12, 1);
            tlp_OrderInfo_FEP.Controls.Add(Clear, 10, 1);
            tlp_OrderInfo_FEP.Controls.Add(label_AntalStripes, 2, 1);
            tlp_OrderInfo_FEP.Controls.Add(Antal_Stripes, 3, 1);
            tlp_OrderInfo_FEP.Controls.Add(label_st, 4, 1);
            tlp_OrderInfo_FEP.Controls.Add(Single_Extrudering, 5, 1);
            tlp_OrderInfo_FEP.Dock = DockStyle.Top;
            tlp_OrderInfo_FEP.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlp_OrderInfo_FEP.Location = new Point(0, 51);
            tlp_OrderInfo_FEP.Margin = new Padding(0);
            tlp_OrderInfo_FEP.Name = "tlp_OrderInfo_FEP";
            tlp_OrderInfo_FEP.RowCount = 2;
            tlp_OrderInfo_FEP.RowStyles.Add(new RowStyle(SizeType.Percent, 66.10169F));
            tlp_OrderInfo_FEP.RowStyles.Add(new RowStyle(SizeType.Percent, 33.8983F));
            tlp_OrderInfo_FEP.Size = new Size(1155, 68);
            tlp_OrderInfo_FEP.TabIndex = 990;
            // 
            // label_OD
            // 
            label_OD.BackColor = Color.White;
            label_OD.Dock = DockStyle.Fill;
            label_OD.Font = new Font("Arial", 10F);
            label_OD.ForeColor = Color.Black;
            label_OD.Location = new Point(410, 1);
            label_OD.Margin = new Padding(1, 1, 0, 0);
            label_OD.Name = "label_OD";
            label_OD.Size = new Size(39, 43);
            label_OD.TabIndex = 939;
            label_OD.Text = "OD: ";
            label_OD.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Nom_OD
            // 
            lbl_Nom_OD.AutoSize = true;
            lbl_Nom_OD.BackColor = Color.White;
            lbl_Nom_OD.Dock = DockStyle.Fill;
            lbl_Nom_OD.Font = new Font("Consolas", 8F);
            lbl_Nom_OD.ForeColor = Color.DarkSlateGray;
            lbl_Nom_OD.Location = new Point(449, 1);
            lbl_Nom_OD.Margin = new Padding(0, 1, 0, 0);
            lbl_Nom_OD.Name = "lbl_Nom_OD";
            lbl_Nom_OD.Size = new Size(47, 43);
            lbl_Nom_OD.TabIndex = 938;
            lbl_Nom_OD.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Wall
            // 
            label_Wall.BackColor = Color.White;
            label_Wall.Dock = DockStyle.Fill;
            label_Wall.Font = new Font("Arial", 10F);
            label_Wall.ForeColor = Color.Black;
            label_Wall.Location = new Point(497, 1);
            label_Wall.Margin = new Padding(1, 1, 0, 0);
            label_Wall.Name = "label_Wall";
            label_Wall.Size = new Size(46, 43);
            label_Wall.TabIndex = 937;
            label_Wall.Text = "Wall:";
            label_Wall.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Nom_Wall
            // 
            lbl_Nom_Wall.AutoSize = true;
            lbl_Nom_Wall.BackColor = Color.White;
            lbl_Nom_Wall.Dock = DockStyle.Fill;
            lbl_Nom_Wall.Font = new Font("Consolas", 8F);
            lbl_Nom_Wall.ForeColor = Color.DarkSlateGray;
            lbl_Nom_Wall.Location = new Point(543, 1);
            lbl_Nom_Wall.Margin = new Padding(0, 1, 0, 0);
            lbl_Nom_Wall.Name = "lbl_Nom_Wall";
            lbl_Nom_Wall.Size = new Size(47, 43);
            lbl_Nom_Wall.TabIndex = 936;
            lbl_Nom_Wall.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Length
            // 
            label_Length.BackColor = Color.White;
            label_Length.Dock = DockStyle.Fill;
            label_Length.Font = new Font("Arial", 10F);
            label_Length.ForeColor = Color.Black;
            label_Length.Location = new Point(591, 1);
            label_Length.Margin = new Padding(1, 1, 0, 0);
            label_Length.Name = "label_Length";
            label_Length.Size = new Size(69, 43);
            label_Length.TabIndex = 935;
            label_Length.Text = "Length:";
            label_Length.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Nom_Length
            // 
            lbl_Nom_Length.AutoSize = true;
            lbl_Nom_Length.BackColor = Color.White;
            lbl_Nom_Length.Dock = DockStyle.Fill;
            lbl_Nom_Length.Font = new Font("Consolas", 8F);
            lbl_Nom_Length.ForeColor = Color.DarkSlateGray;
            lbl_Nom_Length.Location = new Point(660, 1);
            lbl_Nom_Length.Margin = new Padding(0, 1, 0, 0);
            lbl_Nom_Length.Name = "lbl_Nom_Length";
            lbl_Nom_Length.Size = new Size(91, 43);
            lbl_Nom_Length.TabIndex = 934;
            lbl_Nom_Length.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Nom_ID
            // 
            lbl_Nom_ID.AutoSize = true;
            lbl_Nom_ID.BackColor = Color.White;
            lbl_Nom_ID.Dock = DockStyle.Fill;
            lbl_Nom_ID.Font = new Font("Consolas", 8F);
            lbl_Nom_ID.ForeColor = Color.DarkSlateGray;
            lbl_Nom_ID.Location = new Point(362, 1);
            lbl_Nom_ID.Margin = new Padding(0, 1, 0, 0);
            lbl_Nom_ID.Name = "lbl_Nom_ID";
            lbl_Nom_ID.Size = new Size(47, 43);
            lbl_Nom_ID.TabIndex = 926;
            lbl_Nom_ID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_ID
            // 
            label_ID.BackColor = Color.White;
            label_ID.Dock = DockStyle.Fill;
            label_ID.Font = new Font("Arial", 10F);
            label_ID.ForeColor = Color.Black;
            label_ID.Location = new Point(328, 1);
            label_ID.Margin = new Padding(1, 1, 0, 0);
            label_ID.Name = "label_ID";
            label_ID.Size = new Size(34, 43);
            label_ID.TabIndex = 925;
            label_ID.Text = "ID: ";
            label_ID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderNr_FEP
            // 
            lbl_OrderNr_FEP.BackColor = Color.White;
            lbl_OrderNr_FEP.Dock = DockStyle.Fill;
            lbl_OrderNr_FEP.Font = new Font("Consolas", 10F);
            lbl_OrderNr_FEP.ForeColor = Color.DarkSlateGray;
            lbl_OrderNr_FEP.Location = new Point(838, 1);
            lbl_OrderNr_FEP.Margin = new Padding(1, 1, 1, 0);
            lbl_OrderNr_FEP.Name = "lbl_OrderNr_FEP";
            lbl_OrderNr_FEP.Size = new Size(488, 43);
            lbl_OrderNr_FEP.TabIndex = 915;
            lbl_OrderNr_FEP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr_2
            // 
            label_OrderNr_2.BackColor = Color.White;
            label_OrderNr_2.Dock = DockStyle.Fill;
            label_OrderNr_2.Font = new Font("Arial", 12F);
            label_OrderNr_2.ForeColor = Color.Black;
            label_OrderNr_2.Location = new Point(752, 1);
            label_OrderNr_2.Margin = new Padding(1, 1, 0, 0);
            label_OrderNr_2.Name = "label_OrderNr_2";
            label_OrderNr_2.Size = new Size(85, 43);
            label_OrderNr_2.TabIndex = 914;
            label_OrderNr_2.Text = "OrderNr: ";
            label_OrderNr_2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Customer_2
            // 
            label_Customer_2.BackColor = Color.White;
            label_Customer_2.Dock = DockStyle.Fill;
            label_Customer_2.Font = new Font("Arial", 12F);
            label_Customer_2.ForeColor = Color.Black;
            label_Customer_2.Location = new Point(1, 1);
            label_Customer_2.Margin = new Padding(1, 1, 0, 0);
            label_Customer_2.Name = "label_Customer_2";
            label_Customer_2.Size = new Size(79, 43);
            label_Customer_2.TabIndex = 898;
            label_Customer_2.Text = "Kund: ";
            label_Customer_2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Kund_FEP
            // 
            lbl_Kund_FEP.AutoSize = true;
            lbl_Kund_FEP.BackColor = Color.White;
            tlp_OrderInfo_FEP.SetColumnSpan(lbl_Kund_FEP, 3);
            lbl_Kund_FEP.Dock = DockStyle.Fill;
            lbl_Kund_FEP.Font = new Font("Consolas", 10F);
            lbl_Kund_FEP.ForeColor = Color.DarkSlateGray;
            lbl_Kund_FEP.Location = new Point(81, 1);
            lbl_Kund_FEP.Margin = new Padding(1, 1, 0, 0);
            lbl_Kund_FEP.Name = "lbl_Kund_FEP";
            lbl_Kund_FEP.Size = new Size(246, 43);
            lbl_Kund_FEP.TabIndex = 902;
            lbl_Kund_FEP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Co_Extrudering
            // 
            Co_Extrudering.AutoSize = true;
            Co_Extrudering.BackColor = Color.White;
            tlp_OrderInfo_FEP.SetColumnSpan(Co_Extrudering, 2);
            Co_Extrudering.Dock = DockStyle.Fill;
            Co_Extrudering.Font = new Font("Arial", 9F);
            Co_Extrudering.Location = new Point(1, 45);
            Co_Extrudering.Margin = new Padding(1, 1, 0, 1);
            Co_Extrudering.Name = "Co_Extrudering";
            Co_Extrudering.Padding = new Padding(6, 0, 0, 0);
            Co_Extrudering.Size = new Size(178, 22);
            Co_Extrudering.TabIndex = 927;
            Co_Extrudering.Text = "Co-Extrudering";
            Co_Extrudering.UseVisualStyleBackColor = false;
            Co_Extrudering.CheckedChanged += Co_Extrudering_CheckedChanged;
            // 
            // Röntgen
            // 
            Röntgen.AutoSize = true;
            Röntgen.BackColor = Color.White;
            tlp_OrderInfo_FEP.SetColumnSpan(Röntgen, 2);
            Röntgen.Dock = DockStyle.Fill;
            Röntgen.Font = new Font("Arial", 9F);
            Röntgen.Location = new Point(752, 45);
            Röntgen.Margin = new Padding(1);
            Röntgen.Name = "Röntgen";
            Röntgen.Padding = new Padding(6, 0, 0, 0);
            Röntgen.Size = new Size(574, 22);
            Röntgen.TabIndex = 933;
            Röntgen.Text = "R/O";
            Röntgen.UseVisualStyleBackColor = false;
            Röntgen.CheckedChanged += Röntgen_CheckedChanged;
            // 
            // Clear
            // 
            Clear.AutoSize = true;
            Clear.BackColor = Color.White;
            tlp_OrderInfo_FEP.SetColumnSpan(Clear, 2);
            Clear.Dock = DockStyle.Fill;
            Clear.Font = new Font("Arial", 9F);
            Clear.Location = new Point(591, 45);
            Clear.Margin = new Padding(1, 1, 0, 1);
            Clear.Name = "Clear";
            Clear.Padding = new Padding(6, 0, 0, 0);
            Clear.Size = new Size(160, 22);
            Clear.TabIndex = 932;
            Clear.Text = "Clear";
            Clear.UseVisualStyleBackColor = false;
            Clear.CheckedChanged += Clear_CheckedChanged;
            // 
            // label_AntalStripes
            // 
            label_AntalStripes.BackColor = Color.White;
            label_AntalStripes.Dock = DockStyle.Fill;
            label_AntalStripes.Font = new Font("Arial", 9F);
            label_AntalStripes.ForeColor = Color.Black;
            label_AntalStripes.Location = new Point(180, 45);
            label_AntalStripes.Margin = new Padding(1, 1, 0, 1);
            label_AntalStripes.Name = "label_AntalStripes";
            label_AntalStripes.Size = new Size(95, 22);
            label_AntalStripes.TabIndex = 928;
            label_AntalStripes.Text = "Antal Stripes:";
            label_AntalStripes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Antal_Stripes
            // 
            Antal_Stripes.BorderStyle = BorderStyle.None;
            Antal_Stripes.Dock = DockStyle.Fill;
            Antal_Stripes.Font = new Font("Consolas", 10F);
            Antal_Stripes.ForeColor = Color.DarkSlateGray;
            Antal_Stripes.Location = new Point(275, 45);
            Antal_Stripes.Margin = new Padding(0, 1, 0, 1);
            Antal_Stripes.MaxLength = 1;
            Antal_Stripes.Multiline = true;
            Antal_Stripes.Name = "Antal_Stripes";
            Antal_Stripes.Size = new Size(52, 22);
            Antal_Stripes.TabIndex = 929;
            Antal_Stripes.TextAlign = HorizontalAlignment.Center;
            Antal_Stripes.Leave += Antal_Stripes_Leave;
            // 
            // label_st
            // 
            label_st.BackColor = Color.White;
            label_st.Dock = DockStyle.Fill;
            label_st.Font = new Font("Arial", 9F);
            label_st.ForeColor = Color.Black;
            label_st.Location = new Point(327, 45);
            label_st.Margin = new Padding(0, 1, 0, 1);
            label_st.Name = "label_st";
            label_st.Size = new Size(35, 22);
            label_st.TabIndex = 930;
            label_st.Text = "st";
            label_st.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Single_Extrudering
            // 
            Single_Extrudering.AutoSize = true;
            Single_Extrudering.BackColor = Color.White;
            tlp_OrderInfo_FEP.SetColumnSpan(Single_Extrudering, 5);
            Single_Extrudering.Dock = DockStyle.Fill;
            Single_Extrudering.Font = new Font("Arial", 9F);
            Single_Extrudering.Location = new Point(363, 45);
            Single_Extrudering.Margin = new Padding(1, 1, 0, 1);
            Single_Extrudering.Name = "Single_Extrudering";
            Single_Extrudering.Padding = new Padding(6, 0, 0, 0);
            Single_Extrudering.Size = new Size(227, 22);
            Single_Extrudering.TabIndex = 931;
            Single_Extrudering.Text = "Singel extrudering";
            Single_Extrudering.UseVisualStyleBackColor = false;
            Single_Extrudering.CheckedChanged += Singel_Extrudering_CheckedChanged;
            // 
            // menu_Beräkna
            // 
            menu_Beräkna.ImageScalingSize = new Size(20, 20);
            menu_Beräkna.Items.AddRange(new ToolStripItem[] { menu_ID_Blåst, menu_OD_Blåst, menu_W_Blåst, menu_ID_Krympt, menu_OD_Krympt, menu_W_Krympt });
            menu_Beräkna.Name = "menu_ID";
            menu_Beräkna.Size = new Size(258, 136);
            menu_Beräkna.ItemClicked += Menu_Beräkna_ItemClicked;
            // 
            // menu_ID_Blåst
            // 
            menu_ID_Blåst.Name = "menu_ID_Blåst";
            menu_ID_Blåst.Size = new Size(257, 22);
            menu_ID_Blåst.Text = "Calculate Exp. ID with Wall and OD";
            // 
            // menu_OD_Blåst
            // 
            menu_OD_Blåst.Name = "menu_OD_Blåst";
            menu_OD_Blåst.Size = new Size(257, 22);
            menu_OD_Blåst.Text = "Calculate Exp. OD with Wall and ID";
            // 
            // menu_W_Blåst
            // 
            menu_W_Blåst.Name = "menu_W_Blåst";
            menu_W_Blåst.Size = new Size(257, 22);
            menu_W_Blåst.Text = "Calculate Exp. Wall with ID and OD";
            // 
            // menu_ID_Krympt
            // 
            menu_ID_Krympt.Name = "menu_ID_Krympt";
            menu_ID_Krympt.Size = new Size(257, 22);
            menu_ID_Krympt.Text = "Calculate Rec. ID with Wall and OD";
            // 
            // menu_OD_Krympt
            // 
            menu_OD_Krympt.Name = "menu_OD_Krympt";
            menu_OD_Krympt.Size = new Size(257, 22);
            menu_OD_Krympt.Text = "Calculate Rec. OD with Wall and ID";
            // 
            // menu_W_Krympt
            // 
            menu_W_Krympt.Name = "menu_W_Krympt";
            menu_W_Krympt.Size = new Size(257, 22);
            menu_W_Krympt.Text = "Calculate Rec. Wall with ID and OD";
            // 
            // Measurement_Protocol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(1155, 857);
            Controls.Add(tlp_Main);
            Controls.Add(tlp_OrderInfo_FEP);
            Controls.Add(tlp_OrderInfo_TEF);
            Controls.Add(panel_Bottom);
            Controls.Add(flp_Buttons);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(983, 39);
            Name = "Measurement_Protocol";
            Text = "Mätprotokoll";
            FormClosing += Measurement_Protocol_FormClosing;
            tlp_OrderInfo_TEF.ResumeLayout(false);
            tlp_OrderInfo_TEF.PerformLayout();
            flp_Buttons.ResumeLayout(false);
            tlp_Help_InputData_1.ResumeLayout(false);
            ((ISupportInitialize)dgv_HelpInput_1).EndInit();
            ((ISupportInitialize)dgv_Walls).EndInit();
            ((ISupportInitialize)dgv_RecWalls).EndInit();
            ((ISupportInitialize)dgv_HelpInput_2).EndInit();
            ((ISupportInitialize)pb_CrossSectionTube).EndInit();
            tlp_Mätdon.ResumeLayout(false);
            tlp_Mätdon.PerformLayout();
            tlp_Main.ResumeLayout(false);
            ((ISupportInitialize)dgv_Measurements).EndInit();
            tlp_Info_Colors.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((ISupportInitialize)pb_Info).EndInit();
            panel_Bottom.ResumeLayout(false);
            tlp_Help_InputData_2.ResumeLayout(false);
            tlp_OrderInfo_FEP.ResumeLayout(false);
            tlp_OrderInfo_FEP.PerformLayout();
            menu_Beräkna.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlp_OrderInfo_TEF;
        private Label lbl_Benämning_Övrigt;
        private Label label_Description;
        private Label lbl_OrderNr_Övrigt;
        private Label label_OrderNr;
        private Label lbl_Kund_Övrigt;
        private Label label_Customer;
        private Label label_PartNumber;
        private Label lbl_ArtikelNr_Övrigt;
        private FlowLayoutPanel flp_Buttons;
        public Button btn_TransferMeasurement;
        public Button btn_TransferLengthMeasure;
        public Button btn_EditAmount;
        public Button btn_Discard;
        public Button btn_TransferToExcel;
        public Label label_HackNr;
        public TextBox tb_Hack;
        public PictureBox pb_CrossSectionTube;
        public TableLayoutPanel tlp_Mätdon;
        public TableLayoutPanel tlp_Help_InputData_1;
        public DataGridView dgv_HelpInput_1;
        public DataGridView dgv_HelpInput_2;
        public Button btn_Clear_HelpInput_2;
        public Button btn_Clear_HelpInput_1;
        public TableLayoutPanel tlp_Main;
        private TableLayoutPanel tlp_Info_Colors;
        private PictureBox pb_Info;
        private Label label_Discarded;
        private Label label_Ok;
        private Label label_Fail;
        private Label label_Felskrivning;
        private Label label_Warning;
        public FlowLayoutPanel flp_Headers;
        public FlowLayoutPanel flp_InputControls;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private MeasureInstrument measureInstrument;
        public DataGridView dgv_Walls;
        private DataGridViewTextBoxColumn RowHeaders;
        private DataGridViewTextBoxColumn Value;
        public DataGridView dgv_Measurements;
        public Panel panel_Bottom;
        private TableLayoutPanel tlp_OrderInfo_FEP;
        private Label label_OD;
        private Label lbl_Nom_OD;
        private Label label_Wall;
        private Label lbl_Nom_Wall;
        private Label label_Length;
        private Label lbl_Nom_Length;
        private Label lbl_Nom_ID;
        private Label label_ID;
        private Label lbl_OrderNr_FEP;
        private Label label_OrderNr_2;
        private Label label_Customer_2;
        private Label lbl_Kund_FEP;
        private CheckBox Co_Extrudering;
        private CheckBox Röntgen;
        private CheckBox Clear;
        private Label label_AntalStripes;
        private TextBox Antal_Stripes;
        private Label label_st;
        private CheckBox Single_Extrudering;
        public Button btn_EditBag;
        private ContextMenuStrip menu_Beräkna;
        private ToolStripMenuItem menu_ID_Blåst;
        private ToolStripMenuItem menu_OD_Blåst;
        private ToolStripMenuItem menu_W_Blåst;
        private ToolStripMenuItem menu_ID_Krympt;
        private ToolStripMenuItem menu_OD_Krympt;
        private ToolStripMenuItem menu_W_Krympt;
        public DataGridView dgv_RecWalls;
        public TableLayoutPanel tlp_Help_InputData_2;
        private DataGridViewTextBoxColumn col_Info;
        private DataGridViewTextBoxColumn col_Wall;
        private DataGridViewTextBoxColumn col_RecInfo;
        private DataGridViewTextBoxColumn col_RecWall;
        private Label label_DiscardedMeasurements;
        private Label label_TotalMeasureMents;
        private Label lbl_TotalMeasurements;
        private Label lbl_DiscardedMeasurements;
        private Panel panel1;
    }
}