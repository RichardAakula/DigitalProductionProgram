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
            panel_Filter = new Panel();
            gBox_OrderList = new GroupBox();
            btn_LoadOrder = new Button();
            chkList_ListOrders = new CheckedListBox();
            tb_PartNr = new TextBox();
            btn_ExportDataToExcel = new Button();
            cb_MeasureTemplateRevision = new ComboBox();
            label_TemplateRevision = new Label();
            lbl_TotalOrders = new Label();
            tlp_Bottom = new TableLayoutPanel();
            ((ISupportInitialize)dgv_MeasureProtocol).BeginInit();
            panel_TopRight.SuspendLayout();
            panelInfo.SuspendLayout();
            ((ISupportInitialize)dgv_TopList).BeginInit();
            tlp_Main.SuspendLayout();
            panel_Top.SuspendLayout();
            panel_Filter.SuspendLayout();
            gBox_OrderList.SuspendLayout();
            tlp_Bottom.SuspendLayout();
            SuspendLayout();
            // 
            // cb_Workoperations
            // 
            cb_Workoperations.Dock = DockStyle.Top;
            cb_Workoperations.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Workoperations.FormattingEnabled = true;
            cb_Workoperations.Location = new Point(0, 70);
            cb_Workoperations.Margin = new Padding(4, 3, 4, 3);
            cb_Workoperations.Name = "cb_Workoperations";
            cb_Workoperations.Size = new Size(235, 23);
            cb_Workoperations.TabIndex = 5;
            cb_Workoperations.SelectionChangeCommitted += Workoperation_SelectionChangeCommitted;
            // 
            // label_ChooseWorkOperation
            // 
            label_ChooseWorkOperation.AutoSize = true;
            label_ChooseWorkOperation.Cursor = Cursors.Hand;
            label_ChooseWorkOperation.Dock = DockStyle.Top;
            label_ChooseWorkOperation.Font = new Font("Segoe UI", 11F);
            label_ChooseWorkOperation.ForeColor = Color.FromArgb(239, 228, 177);
            label_ChooseWorkOperation.Location = new Point(0, 42);
            label_ChooseWorkOperation.Margin = new Padding(4, 0, 4, 0);
            label_ChooseWorkOperation.Name = "label_ChooseWorkOperation";
            label_ChooseWorkOperation.Padding = new Padding(0, 4, 0, 4);
            label_ChooseWorkOperation.Size = new Size(145, 28);
            label_ChooseWorkOperation.TabIndex = 1;
            label_ChooseWorkOperation.Text = "Välj Arbetsoperation";
            // 
            // label_MeasureTemplateName
            // 
            label_MeasureTemplateName.AutoSize = true;
            label_MeasureTemplateName.Cursor = Cursors.Hand;
            label_MeasureTemplateName.Dock = DockStyle.Top;
            label_MeasureTemplateName.Font = new Font("Segoe UI", 11F);
            label_MeasureTemplateName.ForeColor = Color.FromArgb(239, 228, 177);
            label_MeasureTemplateName.Location = new Point(0, 93);
            label_MeasureTemplateName.Margin = new Padding(4, 0, 4, 0);
            label_MeasureTemplateName.Name = "label_MeasureTemplateName";
            label_MeasureTemplateName.Padding = new Padding(0, 10, 0, 4);
            label_MeasureTemplateName.Size = new Size(180, 34);
            label_MeasureTemplateName.TabIndex = 1;
            label_MeasureTemplateName.Text = "Välj Mall för Mätprotokoll";
            // 
            // cb_MeasureprotocolTemplateName
            // 
            cb_MeasureprotocolTemplateName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_MeasureprotocolTemplateName.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_MeasureprotocolTemplateName.Dock = DockStyle.Top;
            cb_MeasureprotocolTemplateName.FormattingEnabled = true;
            cb_MeasureprotocolTemplateName.Location = new Point(0, 127);
            cb_MeasureprotocolTemplateName.Margin = new Padding(4, 3, 4, 3);
            cb_MeasureprotocolTemplateName.MaxDropDownItems = 25;
            cb_MeasureprotocolTemplateName.Name = "cb_MeasureprotocolTemplateName";
            cb_MeasureprotocolTemplateName.Size = new Size(235, 23);
            cb_MeasureprotocolTemplateName.Sorted = true;
            cb_MeasureprotocolTemplateName.TabIndex = 0;
            cb_MeasureprotocolTemplateName.SelectedIndexChanged += MeasureTemplateName_SelectedIndexChanged;
            // 
            // label_PartNumber
            // 
            label_PartNumber.AutoSize = true;
            label_PartNumber.Cursor = Cursors.Hand;
            label_PartNumber.Dock = DockStyle.Top;
            label_PartNumber.Font = new Font("Segoe UI", 11F);
            label_PartNumber.ForeColor = Color.FromArgb(239, 228, 177);
            label_PartNumber.Location = new Point(0, 207);
            label_PartNumber.Margin = new Padding(4, 0, 4, 0);
            label_PartNumber.Name = "label_PartNumber";
            label_PartNumber.Padding = new Padding(0, 15, 0, 6);
            label_PartNumber.Size = new Size(135, 41);
            label_PartNumber.TabIndex = 1;
            label_PartNumber.Text = "Välj Artikelnummer";
            // 
            // dgv_MeasureProtocol
            // 
            dgv_MeasureProtocol.AllowUserToAddRows = false;
            dgv_MeasureProtocol.AllowUserToDeleteRows = false;
            dgv_MeasureProtocol.AllowUserToResizeRows = false;
            dgv_MeasureProtocol.BackgroundColor = Color.FromArgb(119, 142, 162);
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
            dgv_MeasureProtocol.Location = new Point(235, 0);
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
            dgv_MeasureProtocol.Size = new Size(1128, 743);
            dgv_MeasureProtocol.TabIndex = 43;
            dgv_MeasureProtocol.CellClick += MätProtokoll_CellClick;
            // 
            // label_Info
            // 
            label_Info.BackColor = Color.Transparent;
            label_Info.Dock = DockStyle.Fill;
            label_Info.Font = new Font("Lucida Sans", 12.25F);
            label_Info.ForeColor = Color.Transparent;
            label_Info.Location = new Point(0, 0);
            label_Info.Margin = new Padding(4, 23, 4, 0);
            label_Info.Name = "label_Info";
            label_Info.Size = new Size(456, 743);
            label_Info.TabIndex = 44;
            // 
            // measurePoints
            // 
            measurePoints.BackColor = Color.Black;
            measurePoints.Dock = DockStyle.Fill;
            measurePoints.Location = new Point(5, 3);
            measurePoints.Margin = new Padding(5, 3, 5, 3);
            measurePoints.Name = "measurePoints";
            measurePoints.Size = new Size(466, 767);
            measurePoints.TabIndex = 2;
            // 
            // panel_TopRight
            // 
            panel_TopRight.BackColor = Color.Transparent;
            panel_TopRight.Controls.Add(label_Info);
            panel_TopRight.Controls.Add(panelInfo);
            panel_TopRight.Dock = DockStyle.Right;
            panel_TopRight.Location = new Point(1363, 0);
            panel_TopRight.Margin = new Padding(4, 3, 4, 3);
            panel_TopRight.Name = "panel_TopRight";
            panel_TopRight.Size = new Size(874, 743);
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
            panelInfo.Size = new Size(418, 743);
            panelInfo.TabIndex = 41;
            // 
            // dgv_TopList
            // 
            dgv_TopList.AllowUserToAddRows = false;
            dgv_TopList.AllowUserToDeleteRows = false;
            dgv_TopList.AllowUserToResizeColumns = false;
            dgv_TopList.AllowUserToResizeRows = false;
            dgv_TopList.BackgroundColor = Color.FromArgb(81, 85, 92);
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
            dgv_TopList.Size = new Size(414, 739);
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
            tlp_Main.BackColor = Color.FromArgb(119, 142, 162);
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
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 49.0183258F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 50.9816742F));
            tlp_Main.Size = new Size(2245, 1528);
            tlp_Main.TabIndex = 47;
            // 
            // panel_Top
            // 
            panel_Top.BackColor = Color.Transparent;
            panel_Top.Controls.Add(dgv_MeasureProtocol);
            panel_Top.Controls.Add(panel_Filter);
            panel_Top.Controls.Add(panel_TopRight);
            panel_Top.Dock = DockStyle.Fill;
            panel_Top.Location = new Point(4, 3);
            panel_Top.Margin = new Padding(4, 3, 4, 3);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(2237, 743);
            panel_Top.TabIndex = 46;
            // 
            // panel_Filter
            // 
            panel_Filter.BackColor = Color.FromArgb(6, 81, 87);
            panel_Filter.Controls.Add(gBox_OrderList);
            panel_Filter.Controls.Add(tb_PartNr);
            panel_Filter.Controls.Add(label_PartNumber);
            panel_Filter.Controls.Add(btn_ExportDataToExcel);
            panel_Filter.Controls.Add(cb_MeasureTemplateRevision);
            panel_Filter.Controls.Add(label_TemplateRevision);
            panel_Filter.Controls.Add(cb_MeasureprotocolTemplateName);
            panel_Filter.Controls.Add(label_MeasureTemplateName);
            panel_Filter.Controls.Add(cb_Workoperations);
            panel_Filter.Controls.Add(label_ChooseWorkOperation);
            panel_Filter.Controls.Add(lbl_TotalOrders);
            panel_Filter.Dock = DockStyle.Left;
            panel_Filter.Location = new Point(0, 0);
            panel_Filter.Name = "panel_Filter";
            panel_Filter.Size = new Size(235, 743);
            panel_Filter.TabIndex = 14;
            // 
            // gBox_OrderList
            // 
            gBox_OrderList.Controls.Add(btn_LoadOrder);
            gBox_OrderList.Controls.Add(chkList_ListOrders);
            gBox_OrderList.Dock = DockStyle.Bottom;
            gBox_OrderList.Font = new Font("Segoe UI", 11F);
            gBox_OrderList.ForeColor = Color.FromArgb(239, 228, 177);
            gBox_OrderList.Location = new Point(0, 384);
            gBox_OrderList.Name = "gBox_OrderList";
            gBox_OrderList.Size = new Size(235, 326);
            gBox_OrderList.TabIndex = 12;
            gBox_OrderList.TabStop = false;
            gBox_OrderList.Text = "Välj ordrar";
            // 
            // btn_LoadOrder
            // 
            btn_LoadOrder.BackColor = Color.FromArgb(198, 239, 206);
            btn_LoadOrder.Dock = DockStyle.Bottom;
            btn_LoadOrder.FlatStyle = FlatStyle.Flat;
            btn_LoadOrder.Font = new Font("Segoe UI", 10F);
            btn_LoadOrder.ForeColor = Color.FromArgb(0, 97, 0);
            btn_LoadOrder.Location = new Point(3, 297);
            btn_LoadOrder.Margin = new Padding(0);
            btn_LoadOrder.Name = "btn_LoadOrder";
            btn_LoadOrder.Size = new Size(229, 26);
            btn_LoadOrder.TabIndex = 12;
            btn_LoadOrder.Text = "Ladda Data";
            btn_LoadOrder.UseVisualStyleBackColor = false;
            btn_LoadOrder.Click += LoadOrder_Click;
            // 
            // chkList_ListOrders
            // 
            chkList_ListOrders.Dock = DockStyle.Fill;
            chkList_ListOrders.FormattingEnabled = true;
            chkList_ListOrders.Location = new Point(3, 23);
            chkList_ListOrders.MultiColumn = true;
            chkList_ListOrders.Name = "chkList_ListOrders";
            chkList_ListOrders.SelectionMode = SelectionMode.None;
            chkList_ListOrders.Size = new Size(229, 300);
            chkList_ListOrders.TabIndex = 14;
            chkList_ListOrders.ItemCheck += chkList_ListOrders_ItemCheck;
            chkList_ListOrders.MouseDown += chkList_ListOrders_MouseDown;
            // 
            // tb_PartNr
            // 
            tb_PartNr.Dock = DockStyle.Top;
            tb_PartNr.Location = new Point(0, 248);
            tb_PartNr.Margin = new Padding(4, 3, 4, 3);
            tb_PartNr.Name = "tb_PartNr";
            tb_PartNr.Size = new Size(235, 23);
            tb_PartNr.TabIndex = 6;
            tb_PartNr.MouseClick += PartNr_MouseClick;
            tb_PartNr.TextChanged += PartNr_TextChanged;
            // 
            // btn_ExportDataToExcel
            // 
            btn_ExportDataToExcel.BackColor = Color.FromArgb(198, 239, 206);
            btn_ExportDataToExcel.Dock = DockStyle.Bottom;
            btn_ExportDataToExcel.FlatStyle = FlatStyle.Flat;
            btn_ExportDataToExcel.Font = new Font("Segoe UI", 11F);
            btn_ExportDataToExcel.ForeColor = Color.FromArgb(0, 97, 0);
            btn_ExportDataToExcel.Location = new Point(0, 710);
            btn_ExportDataToExcel.Margin = new Padding(0, 0, 2, 0);
            btn_ExportDataToExcel.Name = "btn_ExportDataToExcel";
            btn_ExportDataToExcel.Size = new Size(235, 33);
            btn_ExportDataToExcel.TabIndex = 13;
            btn_ExportDataToExcel.Text = "Exportera mätningar till Excel";
            btn_ExportDataToExcel.UseVisualStyleBackColor = false;
            btn_ExportDataToExcel.Click += ExportDataToExcel_Click;
            // 
            // cb_MeasureTemplateRevision
            // 
            cb_MeasureTemplateRevision.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_MeasureTemplateRevision.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_MeasureTemplateRevision.Dock = DockStyle.Top;
            cb_MeasureTemplateRevision.FormattingEnabled = true;
            cb_MeasureTemplateRevision.Location = new Point(0, 184);
            cb_MeasureTemplateRevision.Margin = new Padding(4, 3, 4, 3);
            cb_MeasureTemplateRevision.MaxDropDownItems = 25;
            cb_MeasureTemplateRevision.Name = "cb_MeasureTemplateRevision";
            cb_MeasureTemplateRevision.Size = new Size(235, 23);
            cb_MeasureTemplateRevision.Sorted = true;
            cb_MeasureTemplateRevision.TabIndex = 8;
            // 
            // label_TemplateRevision
            // 
            label_TemplateRevision.AutoSize = true;
            label_TemplateRevision.Cursor = Cursors.Hand;
            label_TemplateRevision.Dock = DockStyle.Top;
            label_TemplateRevision.Font = new Font("Segoe UI", 11F);
            label_TemplateRevision.ForeColor = Color.FromArgb(239, 228, 177);
            label_TemplateRevision.Location = new Point(0, 150);
            label_TemplateRevision.Margin = new Padding(4, 0, 4, 0);
            label_TemplateRevision.Name = "label_TemplateRevision";
            label_TemplateRevision.Padding = new Padding(0, 10, 0, 4);
            label_TemplateRevision.Size = new Size(164, 34);
            label_TemplateRevision.TabIndex = 7;
            label_TemplateRevision.Text = "Välj Revision för Mallen";
            // 
            // lbl_TotalOrders
            // 
            lbl_TotalOrders.AutoSize = true;
            lbl_TotalOrders.Dock = DockStyle.Top;
            lbl_TotalOrders.Font = new Font("Lucida Sans", 11F);
            lbl_TotalOrders.ForeColor = Color.FromArgb(181, 210, 207);
            lbl_TotalOrders.Location = new Point(0, 0);
            lbl_TotalOrders.Name = "lbl_TotalOrders";
            lbl_TotalOrders.Padding = new Padding(0, 5, 0, 20);
            lbl_TotalOrders.Size = new Size(104, 42);
            lbl_TotalOrders.TabIndex = 13;
            lbl_TotalOrders.Text = "Antal Ordrar: ";
            // 
            // tlp_Bottom
            // 
            tlp_Bottom.BackColor = Color.FromArgb(112, 198, 176);
            tlp_Bottom.ColumnCount = 2;
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 476F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Bottom.Controls.Add(measurePoints, 0, 0);
            tlp_Bottom.Dock = DockStyle.Fill;
            tlp_Bottom.Location = new Point(3, 752);
            tlp_Bottom.Name = "tlp_Bottom";
            tlp_Bottom.RowCount = 1;
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Bottom.Size = new Size(2239, 773);
            tlp_Bottom.TabIndex = 47;
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
            panel_Filter.ResumeLayout(false);
            panel_Filter.PerformLayout();
            gBox_OrderList.ResumeLayout(false);
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
        private TextBox tb_PartNr;
        private Label label_TemplateRevision;
        private ComboBox cb_MeasureTemplateRevision;
        private TableLayoutPanel tlp_Bottom;
        private GroupBox gBox_OrderList;
        private Button btn_LoadOrder;
        private Label lbl_TotalOrders;
        private Button btn_ExportDataToExcel;
        private CheckedListBox chkList_ListOrders;
        private Panel panel_Filter;
    }
}