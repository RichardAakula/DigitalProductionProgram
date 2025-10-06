using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DigitalProductionProgram.Measure
{
    partial class BrowseMeasureProtocols
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            cb_Workoperations = new ComboBox();
            label_ChooseWorkOperation = new Label();
            label_MeasureTemplateName = new Label();
            cb_MeasureprotocolTemplateName = new ComboBox();
            label_PartNumber = new Label();
            dgv_MeasureProtocol = new DataGridView();
            label_Info = new Label();
            measurePoints = new MeasurePoints();
            panel_TopRight = new Panel();
            panelInfo = new Panel();
            dgv_TopList = new DataGridView();
            date_From = new DateTimePicker();
            label4 = new Label();
            lbl_antal_mätningar = new Label();
            label_Info_Datum = new Label();
            label1 = new Label();
            tlp_Main = new TableLayoutPanel();
            panel_Top = new Panel();
            flp_Controls = new FlowLayoutPanel();
            lbl_TotalOrders = new Label();
            label_TemplateRevision = new Label();
            cb_MeasureTemplateRevision = new ComboBox();
            tb_PartNr = new TextBox();
            chb_SelectAllOrders = new CheckBox();
            groupBox1 = new GroupBox();
            btn_LoadOrder = new Button();
            num_SelectTotalOrders = new NumericUpDown();
            tlp_Bottom = new TableLayoutPanel();
            btn_ExportDataToExcel = new Button();
            ((ISupportInitialize)dgv_MeasureProtocol).BeginInit();
            panel_TopRight.SuspendLayout();
            panelInfo.SuspendLayout();
            ((ISupportInitialize)dgv_TopList).BeginInit();
            tlp_Main.SuspendLayout();
            panel_Top.SuspendLayout();
            flp_Controls.SuspendLayout();
            groupBox1.SuspendLayout();
            ((ISupportInitialize)num_SelectTotalOrders).BeginInit();
            tlp_Bottom.SuspendLayout();
            SuspendLayout();
            // 
            // cb_Workoperations
            // 
            cb_Workoperations.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Workoperations.FormattingEnabled = true;
            cb_Workoperations.Location = new Point(4, 73);
            cb_Workoperations.Margin = new Padding(4, 3, 4, 3);
            cb_Workoperations.Name = "cb_Workoperations";
            cb_Workoperations.Size = new Size(205, 23);
            cb_Workoperations.TabIndex = 5;
            cb_Workoperations.SelectionChangeCommitted += Workoperation_SelectionChangeCommitted;
            // 
            // label_ChooseWorkOperation
            // 
            label_ChooseWorkOperation.AutoSize = true;
            label_ChooseWorkOperation.Cursor = Cursors.Hand;
            label_ChooseWorkOperation.Font = new Font("Segoe UI", 11F);
            label_ChooseWorkOperation.ForeColor = Color.FromArgb(239, 228, 177);
            label_ChooseWorkOperation.Location = new Point(4, 42);
            label_ChooseWorkOperation.Margin = new Padding(4, 0, 4, 0);
            label_ChooseWorkOperation.Name = "label_ChooseWorkOperation";
            label_ChooseWorkOperation.Padding = new Padding(0, 4, 0, 4);
            label_ChooseWorkOperation.Size = new Size(145, 28);
            label_ChooseWorkOperation.TabIndex = 1;
            label_ChooseWorkOperation.Text = "Välj Arbetsoperation";
            label_ChooseWorkOperation.Click += Clear_label_Click;
            // 
            // label_MeasureTemplateName
            // 
            label_MeasureTemplateName.AutoSize = true;
            label_MeasureTemplateName.Cursor = Cursors.Hand;
            label_MeasureTemplateName.Font = new Font("Segoe UI", 11F);
            label_MeasureTemplateName.ForeColor = Color.FromArgb(239, 228, 177);
            label_MeasureTemplateName.Location = new Point(4, 99);
            label_MeasureTemplateName.Margin = new Padding(4, 0, 4, 0);
            label_MeasureTemplateName.Name = "label_MeasureTemplateName";
            label_MeasureTemplateName.Padding = new Padding(0, 4, 0, 4);
            label_MeasureTemplateName.Size = new Size(180, 28);
            label_MeasureTemplateName.TabIndex = 1;
            label_MeasureTemplateName.Text = "Välj Mall för Mätprotokoll";
            label_MeasureTemplateName.Click += Clear_label_Click;
            // 
            // cb_MeasureprotocolTemplateName
            // 
            cb_MeasureprotocolTemplateName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_MeasureprotocolTemplateName.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_MeasureprotocolTemplateName.FormattingEnabled = true;
            cb_MeasureprotocolTemplateName.Location = new Point(4, 130);
            cb_MeasureprotocolTemplateName.Margin = new Padding(4, 3, 4, 3);
            cb_MeasureprotocolTemplateName.MaxDropDownItems = 25;
            cb_MeasureprotocolTemplateName.Name = "cb_MeasureprotocolTemplateName";
            cb_MeasureprotocolTemplateName.Size = new Size(205, 23);
            cb_MeasureprotocolTemplateName.Sorted = true;
            cb_MeasureprotocolTemplateName.TabIndex = 0;
            cb_MeasureprotocolTemplateName.SelectedIndexChanged += MeasureTemplateName_SelectedIndexChanged;
            // 
            // label_PartNumber
            // 
            label_PartNumber.AutoSize = true;
            label_PartNumber.Cursor = Cursors.Hand;
            label_PartNumber.Font = new Font("Segoe UI", 11F);
            label_PartNumber.ForeColor = Color.FromArgb(239, 228, 177);
            label_PartNumber.Location = new Point(4, 213);
            label_PartNumber.Margin = new Padding(4, 0, 4, 0);
            label_PartNumber.Name = "label_PartNumber";
            label_PartNumber.Padding = new Padding(0, 0, 0, 6);
            label_PartNumber.Size = new Size(135, 26);
            label_PartNumber.TabIndex = 1;
            label_PartNumber.Text = "Välj Artikelnummer";
            label_PartNumber.Click += Clear_label_Click;
            // 
            // dgv_MeasureProtocol
            // 
            dgv_MeasureProtocol.AllowUserToAddRows = false;
            dgv_MeasureProtocol.AllowUserToDeleteRows = false;
            dgv_MeasureProtocol.AllowUserToResizeRows = false;
            dgv_MeasureProtocol.BackgroundColor = Color.FromArgb(6, 81, 87);
            dgv_MeasureProtocol.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_MeasureProtocol.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_MeasureProtocol.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_MeasureProtocol.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_MeasureProtocol.Dock = DockStyle.Fill;
            dgv_MeasureProtocol.Location = new Point(229, 0);
            dgv_MeasureProtocol.Margin = new Padding(6, 3, 4, 3);
            dgv_MeasureProtocol.Name = "dgv_MeasureProtocol";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_MeasureProtocol.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_MeasureProtocol.RowHeadersVisible = false;
            dgv_MeasureProtocol.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_MeasureProtocol.Size = new Size(1134, 440);
            dgv_MeasureProtocol.TabIndex = 43;
            dgv_MeasureProtocol.CellClick += MätProtokoll_CellClick;
            // 
            // label_Info
            // 
            label_Info.BackColor = Color.FromArgb(6, 81, 87);
            label_Info.Dock = DockStyle.Fill;
            label_Info.Font = new Font("Lucida Sans", 12.25F);
            label_Info.ForeColor = SystemColors.Info;
            label_Info.Location = new Point(0, 0);
            label_Info.Margin = new Padding(4, 23, 4, 0);
            label_Info.Name = "label_Info";
            label_Info.Size = new Size(456, 440);
            label_Info.TabIndex = 44;
            // 
            // measurePoints
            // 
            measurePoints.BackColor = Color.Black;
            measurePoints.Dock = DockStyle.Fill;
            measurePoints.Location = new Point(5, 3);
            measurePoints.Margin = new Padding(5, 3, 5, 3);
            measurePoints.Name = "measurePoints";
            measurePoints.Size = new Size(466, 1070);
            measurePoints.TabIndex = 2;
            // 
            // panel_TopRight
            // 
            panel_TopRight.BackColor = Color.FromArgb(45, 15, 45);
            panel_TopRight.Controls.Add(label_Info);
            panel_TopRight.Controls.Add(panelInfo);
            panel_TopRight.Dock = DockStyle.Right;
            panel_TopRight.Location = new Point(1363, 0);
            panel_TopRight.Margin = new Padding(4, 3, 4, 3);
            panel_TopRight.Name = "panel_TopRight";
            panel_TopRight.Size = new Size(874, 440);
            panel_TopRight.TabIndex = 46;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.FromArgb(40, 40, 40);
            panelInfo.BorderStyle = BorderStyle.Fixed3D;
            panelInfo.Controls.Add(dgv_TopList);
            panelInfo.Controls.Add(date_From);
            panelInfo.Controls.Add(label4);
            panelInfo.Controls.Add(lbl_antal_mätningar);
            panelInfo.Controls.Add(label_Info_Datum);
            panelInfo.Controls.Add(label1);
            panelInfo.Dock = DockStyle.Right;
            panelInfo.Location = new Point(456, 0);
            panelInfo.Margin = new Padding(4, 3, 4, 3);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(418, 440);
            panelInfo.TabIndex = 41;
            // 
            // dgv_TopList
            // 
            dgv_TopList.AllowUserToAddRows = false;
            dgv_TopList.AllowUserToDeleteRows = false;
            dgv_TopList.AllowUserToResizeColumns = false;
            dgv_TopList.AllowUserToResizeRows = false;
            dgv_TopList.BackgroundColor = Color.FromArgb(6, 81, 87);
            dgv_TopList.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv_TopList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_TopList.ColumnHeadersVisible = false;
            dgv_TopList.Dock = DockStyle.Fill;
            dgv_TopList.Location = new Point(0, 0);
            dgv_TopList.Margin = new Padding(4, 3, 4, 3);
            dgv_TopList.Name = "dgv_TopList";
            dgv_TopList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_TopList.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(45, 45, 45);
            dataGridViewCellStyle4.ForeColor = Color.Gold;
            dgv_TopList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgv_TopList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_TopList.Size = new Size(414, 436);
            dgv_TopList.TabIndex = 4;
            // 
            // date_From
            // 
            date_From.Location = new Point(126, 14);
            date_From.Margin = new Padding(4, 3, 4, 3);
            date_From.MinDate = new DateTime(2004, 1, 1, 0, 0, 0, 0);
            date_From.Name = "date_From";
            date_From.Size = new Size(186, 23);
            date_From.TabIndex = 3;
            date_From.Value = new DateTime(2004, 8, 7, 12, 55, 0, 0);
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.OrangeRed;
            label4.Location = new Point(98, 99);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(71, 19);
            label4.TabIndex = 1;
            label4.Text = "Topplista";
            // 
            // lbl_antal_mätningar
            // 
            lbl_antal_mätningar.AutoSize = true;
            lbl_antal_mätningar.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_antal_mätningar.ForeColor = Color.DarkGoldenrod;
            lbl_antal_mätningar.Location = new Point(122, 72);
            lbl_antal_mätningar.Margin = new Padding(4, 0, 4, 0);
            lbl_antal_mätningar.Name = "lbl_antal_mätningar";
            lbl_antal_mätningar.Size = new Size(13, 15);
            lbl_antal_mätningar.TabIndex = 1;
            lbl_antal_mätningar.Text = "0";
            // 
            // label_Info_Datum
            // 
            label_Info_Datum.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Info_Datum.ForeColor = Color.DarkGoldenrod;
            label_Info_Datum.Location = new Point(4, 1);
            label_Info_Datum.Margin = new Padding(4, 0, 4, 0);
            label_Info_Datum.Name = "label_Info_Datum";
            label_Info_Datum.Size = new Size(112, 40);
            label_Info_Datum.TabIndex = 1;
            label_Info_Datum.Text = "Hämta mätningar från:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkGoldenrod;
            label1.Location = new Point(4, 72);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 1;
            label1.Text = "Antal mätningar:";
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.FromArgb(112, 198, 176);
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tlp_Main.Controls.Add(panel_Top, 0, 0);
            tlp_Main.Controls.Add(tlp_Bottom, 0, 1);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 29.1884823F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 70.8115158F));
            tlp_Main.Size = new Size(2245, 1528);
            tlp_Main.TabIndex = 47;
            // 
            // panel_Top
            // 
            panel_Top.Controls.Add(dgv_MeasureProtocol);
            panel_Top.Controls.Add(flp_Controls);
            panel_Top.Controls.Add(panel_TopRight);
            panel_Top.Dock = DockStyle.Fill;
            panel_Top.Location = new Point(4, 3);
            panel_Top.Margin = new Padding(4, 3, 4, 3);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(2237, 440);
            panel_Top.TabIndex = 46;
            // 
            // flp_Controls
            // 
            flp_Controls.BackColor = Color.FromArgb(6, 81, 87);
            flp_Controls.Controls.Add(lbl_TotalOrders);
            flp_Controls.Controls.Add(label_ChooseWorkOperation);
            flp_Controls.Controls.Add(cb_Workoperations);
            flp_Controls.Controls.Add(label_MeasureTemplateName);
            flp_Controls.Controls.Add(cb_MeasureprotocolTemplateName);
            flp_Controls.Controls.Add(label_TemplateRevision);
            flp_Controls.Controls.Add(cb_MeasureTemplateRevision);
            flp_Controls.Controls.Add(label_PartNumber);
            flp_Controls.Controls.Add(tb_PartNr);
            flp_Controls.Controls.Add(chb_SelectAllOrders);
            flp_Controls.Controls.Add(groupBox1);
            flp_Controls.Controls.Add(btn_ExportDataToExcel);
            flp_Controls.Dock = DockStyle.Left;
            flp_Controls.FlowDirection = FlowDirection.TopDown;
            flp_Controls.Location = new Point(0, 0);
            flp_Controls.Margin = new Padding(4, 3, 4, 3);
            flp_Controls.Name = "flp_Controls";
            flp_Controls.Size = new Size(229, 440);
            flp_Controls.TabIndex = 47;
            // 
            // lbl_TotalOrders
            // 
            lbl_TotalOrders.AutoSize = true;
            lbl_TotalOrders.Font = new Font("Lucida Sans", 11F);
            lbl_TotalOrders.ForeColor = Color.FromArgb(181, 210, 207);
            lbl_TotalOrders.Location = new Point(3, 0);
            lbl_TotalOrders.Name = "lbl_TotalOrders";
            lbl_TotalOrders.Padding = new Padding(0, 5, 0, 20);
            lbl_TotalOrders.Size = new Size(104, 42);
            lbl_TotalOrders.TabIndex = 13;
            lbl_TotalOrders.Text = "Antal Ordrar: ";
            // 
            // label_TemplateRevision
            // 
            label_TemplateRevision.AutoSize = true;
            label_TemplateRevision.Cursor = Cursors.Hand;
            label_TemplateRevision.Font = new Font("Segoe UI", 11F);
            label_TemplateRevision.ForeColor = Color.FromArgb(239, 228, 177);
            label_TemplateRevision.Location = new Point(4, 156);
            label_TemplateRevision.Margin = new Padding(4, 0, 4, 0);
            label_TemplateRevision.Name = "label_TemplateRevision";
            label_TemplateRevision.Padding = new Padding(0, 4, 0, 4);
            label_TemplateRevision.Size = new Size(164, 28);
            label_TemplateRevision.TabIndex = 7;
            label_TemplateRevision.Text = "Välj Revision för Mallen";
            // 
            // cb_MeasureTemplateRevision
            // 
            cb_MeasureTemplateRevision.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_MeasureTemplateRevision.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_MeasureTemplateRevision.FormattingEnabled = true;
            cb_MeasureTemplateRevision.Location = new Point(4, 187);
            cb_MeasureTemplateRevision.Margin = new Padding(4, 3, 4, 3);
            cb_MeasureTemplateRevision.MaxDropDownItems = 25;
            cb_MeasureTemplateRevision.Name = "cb_MeasureTemplateRevision";
            cb_MeasureTemplateRevision.Size = new Size(205, 23);
            cb_MeasureTemplateRevision.Sorted = true;
            cb_MeasureTemplateRevision.TabIndex = 8;
            cb_MeasureTemplateRevision.SelectedIndexChanged += MeasureTemplateRevision_SelectedIndexChanged;
            // 
            // tb_PartNr
            // 
            tb_PartNr.Location = new Point(4, 242);
            tb_PartNr.Margin = new Padding(4, 3, 4, 3);
            tb_PartNr.Name = "tb_PartNr";
            tb_PartNr.Size = new Size(144, 23);
            tb_PartNr.TabIndex = 6;
            tb_PartNr.MouseClick += PartNr_MouseClick;
            tb_PartNr.TextChanged += PartNr_TextChanged;
            // 
            // chb_SelectAllOrders
            // 
            chb_SelectAllOrders.AutoSize = true;
            chb_SelectAllOrders.Font = new Font("Segoe UI", 11F);
            chb_SelectAllOrders.ForeColor = Color.FromArgb(239, 228, 177);
            chb_SelectAllOrders.Location = new Point(3, 271);
            chb_SelectAllOrders.Name = "chb_SelectAllOrders";
            chb_SelectAllOrders.Size = new Size(125, 24);
            chb_SelectAllOrders.TabIndex = 10;
            chb_SelectAllOrders.Text = "Välj alla ordrar";
            chb_SelectAllOrders.UseVisualStyleBackColor = true;
            chb_SelectAllOrders.CheckedChanged += chb_SelectAllOrders_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_LoadOrder);
            groupBox1.Controls.Add(num_SelectTotalOrders);
            groupBox1.Font = new Font("Segoe UI", 11F);
            groupBox1.ForeColor = Color.FromArgb(239, 228, 177);
            groupBox1.Location = new Point(3, 301);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 64);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Välj max antal ordrar";
            // 
            // btn_LoadOrder
            // 
            btn_LoadOrder.BackColor = Color.FromArgb(198, 239, 206);
            btn_LoadOrder.FlatStyle = FlatStyle.Flat;
            btn_LoadOrder.Font = new Font("Segoe UI", 10F);
            btn_LoadOrder.ForeColor = Color.FromArgb(0, 97, 0);
            btn_LoadOrder.Location = new Point(61, 28);
            btn_LoadOrder.Margin = new Padding(0);
            btn_LoadOrder.Name = "btn_LoadOrder";
            btn_LoadOrder.Size = new Size(104, 26);
            btn_LoadOrder.TabIndex = 12;
            btn_LoadOrder.Text = "Ladda Data";
            btn_LoadOrder.UseVisualStyleBackColor = false;
            btn_LoadOrder.Click += LoadOrder_Click;
            // 
            // num_SelectTotalOrders
            // 
            num_SelectTotalOrders.Font = new Font("Modern No. 20", 12.75F);
            num_SelectTotalOrders.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            num_SelectTotalOrders.Location = new Point(6, 28);
            num_SelectTotalOrders.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_SelectTotalOrders.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_SelectTotalOrders.Name = "num_SelectTotalOrders";
            num_SelectTotalOrders.Size = new Size(49, 26);
            num_SelectTotalOrders.TabIndex = 11;
            num_SelectTotalOrders.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // tlp_Bottom
            // 
            tlp_Bottom.ColumnCount = 2;
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 476F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Bottom.Controls.Add(measurePoints, 0, 0);
            tlp_Bottom.Dock = DockStyle.Fill;
            tlp_Bottom.Location = new Point(3, 449);
            tlp_Bottom.Name = "tlp_Bottom";
            tlp_Bottom.RowCount = 1;
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Bottom.Size = new Size(2239, 1076);
            tlp_Bottom.TabIndex = 47;
            // 
            // btn_ExportDataToExcel
            // 
            btn_ExportDataToExcel.BackColor = Color.FromArgb(198, 239, 206);
            btn_ExportDataToExcel.FlatStyle = FlatStyle.Flat;
            btn_ExportDataToExcel.Font = new Font("Segoe UI", 10F);
            btn_ExportDataToExcel.ForeColor = Color.FromArgb(0, 97, 0);
            btn_ExportDataToExcel.Location = new Point(0, 368);
            btn_ExportDataToExcel.Margin = new Padding(0);
            btn_ExportDataToExcel.Name = "btn_ExportDataToExcel";
            btn_ExportDataToExcel.Size = new Size(203, 26);
            btn_ExportDataToExcel.TabIndex = 13;
            btn_ExportDataToExcel.Text = "Exportera mätningar till Excel";
            btn_ExportDataToExcel.UseVisualStyleBackColor = false;
            btn_ExportDataToExcel.Click += ExportDataToExcel_Click;
            // 
            // BrowseMeasureProtocols
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.FromArgb(45, 45, 45);
            ClientSize = new Size(2245, 1528);
            Controls.Add(tlp_Main);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "BrowseMeasureProtocols";
            Text = "Titta på gamla Mätprotokoll";
            WindowState = FormWindowState.Maximized;
            FormClosed += SökMätprotokoll_FormClosed;
            Load += BrowseMeasureProtocols_Load;
            ((ISupportInitialize)dgv_MeasureProtocol).EndInit();
            panel_TopRight.ResumeLayout(false);
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ((ISupportInitialize)dgv_TopList).EndInit();
            tlp_Main.ResumeLayout(false);
            panel_Top.ResumeLayout(false);
            flp_Controls.ResumeLayout(false);
            flp_Controls.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((ISupportInitialize)num_SelectTotalOrders).EndInit();
            tlp_Bottom.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private Label label_PartNumber;
        private System.Threading.Timer timer_AddPoints;
        private DataGridView dgv_MeasureProtocol;
        private Label label_Info;
        private Label label_MeasureTemplateName;
        private ComboBox cb_MeasureprotocolTemplateName;
        private MeasurePoints measurePoints;
        private Panel panel_TopRight;
        private Panel panelInfo;
        private ComboBox cb_Workoperations;
        private DataGridView dgv_TopList;
        private DateTimePicker date_From;
        private Label label4;
        private Label lbl_antal_mätningar;
        private Label label_Info_Datum;
        private Label label1;
        private TableLayoutPanel tlp_Main;
        private Panel panel_Top;
        private Label label_ChooseWorkOperation;
        private FlowLayoutPanel flp_Controls;
        private TextBox tb_PartNr;
        private Label label_TemplateRevision;
        private ComboBox cb_MeasureTemplateRevision;
        private TableLayoutPanel tlp_Bottom;
        private CheckBox chb_SelectAllOrders;
        private GroupBox groupBox1;
        private NumericUpDown num_SelectTotalOrders;
        private Button btn_LoadOrder;
        private Label lbl_TotalOrders;
        private Button btn_ExportDataToExcel;
    }
}