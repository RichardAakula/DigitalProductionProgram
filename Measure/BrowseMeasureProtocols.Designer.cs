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
            components = new Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            cb_Workoperations = new ComboBox();
            label_ChooseWorkOperation = new Label();
            label_MeasureProtocolTemplateName = new Label();
            cb_MeasureprotocolTemplateName = new ComboBox();
            label_ChoosePartNumber = new Label();
            dgv_MeasureProtocol = new DataGridView();
            label_Info = new Label();
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
            label_FilterInfo = new Label();
            chk_FilterDiscarded = new CheckBox();
            panel_FilterOutliers = new Panel();
            num_OutlierLimit = new NumericUpDown();
            chk_FilterBadValues = new CheckBox();
            label_Threshold = new Label();
            gBox_FilterOrders = new GroupBox();
            btn_ReloadData = new Button();
            chkList_ListOrders = new CheckedListBox();
            tb_PartNr = new TextBox();
            btn_ExportDataToExcel = new Button();
            cb_MeasureTemplateRevision = new ComboBox();
            label_ChooseRevisionMeasureTemplate = new Label();
            label_TotalOrders = new Label();
            tlp_Bottom = new TableLayoutPanel();
            panel_SPC = new Panel();
            tlp_SPC_Data = new TableLayoutPanel();
            lbl_Bar_StandardDeviation = new Label();
            lbl_Bar_Ppk = new Label();
            lbl_Bar_Pp = new Label();
            lbl_Bar_Kurtosis = new Label();
            lbl_Kurtosis = new Label();
            lbl_Skewness = new Label();
            lbl_StandardDeviation = new Label();
            lbl_Range = new Label();
            label_Kurtosis = new Label();
            label_Skewness = new Label();
            label_StandardDev = new Label();
            label_Range = new Label();
            lbl_Min = new Label();
            label_Min = new Label();
            lbl_Max = new Label();
            label_Max = new Label();
            lbl_Median = new Label();
            label_Median = new Label();
            lbl_Mean = new Label();
            label_Mean = new Label();
            lbl_Ppk = new Label();
            label_Ppk = new Label();
            lbl_Pp = new Label();
            label_Pp = new Label();
            label_TotalMeasurements = new Label();
            lbl_TotalMeasurements = new Label();
            lbl_Bar_Skewness = new Label();
            label_PerformanceRatio = new Label();
            lbl_PerformanceRatio = new Label();
            lbl_Bar_PerformanceRatio = new Label();
            label_SPC_Title = new Label();
            cf_MeasurePoints = new MeasurePoints();
            toolTip1 = new ToolTip(components);
            ((ISupportInitialize)dgv_MeasureProtocol).BeginInit();
            panel_TopRight.SuspendLayout();
            panelInfo.SuspendLayout();
            ((ISupportInitialize)dgv_TopList).BeginInit();
            tlp_Main.SuspendLayout();
            panel_Top.SuspendLayout();
            panel_Filter.SuspendLayout();
            panel_FilterOutliers.SuspendLayout();
            ((ISupportInitialize)num_OutlierLimit).BeginInit();
            gBox_FilterOrders.SuspendLayout();
            tlp_Bottom.SuspendLayout();
            panel_SPC.SuspendLayout();
            tlp_SPC_Data.SuspendLayout();
            SuspendLayout();
            // 
            // cb_Workoperations
            // 
            cb_Workoperations.Dock = DockStyle.Top;
            cb_Workoperations.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Workoperations.FormattingEnabled = true;
            cb_Workoperations.Location = new Point(0, 56);
            cb_Workoperations.Margin = new Padding(4, 3, 4, 0);
            cb_Workoperations.Name = "cb_Workoperations";
            cb_Workoperations.Size = new Size(320, 23);
            cb_Workoperations.TabIndex = 5;
            cb_Workoperations.SelectionChangeCommitted += Workoperation_SelectionChangeCommitted;
            // 
            // label_ChooseWorkOperation
            // 
            label_ChooseWorkOperation.AutoSize = true;
            label_ChooseWorkOperation.Cursor = Cursors.Hand;
            label_ChooseWorkOperation.Dock = DockStyle.Top;
            label_ChooseWorkOperation.Font = new Font("Segoe UI", 9F);
            label_ChooseWorkOperation.ForeColor = Color.FromArgb(239, 228, 177);
            label_ChooseWorkOperation.Location = new Point(0, 32);
            label_ChooseWorkOperation.Margin = new Padding(4, 0, 4, 0);
            label_ChooseWorkOperation.Name = "label_ChooseWorkOperation";
            label_ChooseWorkOperation.Padding = new Padding(0, 5, 0, 4);
            label_ChooseWorkOperation.Size = new Size(113, 24);
            label_ChooseWorkOperation.TabIndex = 1;
            label_ChooseWorkOperation.Text = "Välj Arbetsoperation";
            // 
            // label_MeasureProtocolTemplateName
            // 
            label_MeasureProtocolTemplateName.AutoSize = true;
            label_MeasureProtocolTemplateName.Cursor = Cursors.Hand;
            label_MeasureProtocolTemplateName.Dock = DockStyle.Top;
            label_MeasureProtocolTemplateName.Font = new Font("Segoe UI", 9F);
            label_MeasureProtocolTemplateName.ForeColor = Color.FromArgb(239, 228, 177);
            label_MeasureProtocolTemplateName.Location = new Point(0, 79);
            label_MeasureProtocolTemplateName.Margin = new Padding(4, 0, 4, 0);
            label_MeasureProtocolTemplateName.Name = "label_MeasureProtocolTemplateName";
            label_MeasureProtocolTemplateName.Padding = new Padding(0, 5, 0, 4);
            label_MeasureProtocolTemplateName.Size = new Size(141, 24);
            label_MeasureProtocolTemplateName.TabIndex = 1;
            label_MeasureProtocolTemplateName.Text = "Välj Mall för Mätprotokoll";
            // 
            // cb_MeasureprotocolTemplateName
            // 
            cb_MeasureprotocolTemplateName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_MeasureprotocolTemplateName.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_MeasureprotocolTemplateName.Dock = DockStyle.Top;
            cb_MeasureprotocolTemplateName.FormattingEnabled = true;
            cb_MeasureprotocolTemplateName.Location = new Point(0, 103);
            cb_MeasureprotocolTemplateName.Margin = new Padding(4, 3, 4, 0);
            cb_MeasureprotocolTemplateName.MaxDropDownItems = 25;
            cb_MeasureprotocolTemplateName.Name = "cb_MeasureprotocolTemplateName";
            cb_MeasureprotocolTemplateName.Size = new Size(320, 23);
            cb_MeasureprotocolTemplateName.Sorted = true;
            cb_MeasureprotocolTemplateName.TabIndex = 0;
            cb_MeasureprotocolTemplateName.SelectedIndexChanged += MeasureTemplateName_SelectedIndexChanged;
            // 
            // label_ChoosePartNumber
            // 
            label_ChoosePartNumber.AutoSize = true;
            label_ChoosePartNumber.Cursor = Cursors.Hand;
            label_ChoosePartNumber.Dock = DockStyle.Top;
            label_ChoosePartNumber.Font = new Font("Segoe UI", 9F);
            label_ChoosePartNumber.ForeColor = Color.FromArgb(239, 228, 177);
            label_ChoosePartNumber.Location = new Point(0, 173);
            label_ChoosePartNumber.Margin = new Padding(4, 0, 4, 0);
            label_ChoosePartNumber.Name = "label_ChoosePartNumber";
            label_ChoosePartNumber.Padding = new Padding(0, 5, 0, 6);
            label_ChoosePartNumber.Size = new Size(108, 26);
            label_ChoosePartNumber.TabIndex = 1;
            label_ChoosePartNumber.Text = "Välj Artikelnummer";
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
            dgv_MeasureProtocol.Location = new Point(320, 0);
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
            dgv_MeasureProtocol.Size = new Size(540, 647);
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
            label_Info.Size = new Size(456, 647);
            label_Info.TabIndex = 44;
            // 
            // panel_TopRight
            // 
            panel_TopRight.BackColor = Color.Transparent;
            panel_TopRight.Controls.Add(label_Info);
            panel_TopRight.Controls.Add(panelInfo);
            panel_TopRight.Dock = DockStyle.Right;
            panel_TopRight.Location = new Point(1079, 0);
            panel_TopRight.Margin = new Padding(4, 3, 4, 3);
            panel_TopRight.Name = "panel_TopRight";
            panel_TopRight.Size = new Size(874, 647);
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
            panelInfo.Size = new Size(418, 647);
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
            dgv_TopList.Size = new Size(414, 643);
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
            tlp_Main.Controls.Add(panel_Top, 0, 0);
            tlp_Main.Controls.Add(tlp_Bottom, 0, 1);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 653F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(1961, 1059);
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
            panel_Top.Size = new Size(1953, 647);
            panel_Top.TabIndex = 46;
            // 
            // panel_Filter
            // 
            panel_Filter.BackColor = Color.FromArgb(6, 81, 87);
            panel_Filter.Controls.Add(label_FilterInfo);
            panel_Filter.Controls.Add(chk_FilterDiscarded);
            panel_Filter.Controls.Add(panel_FilterOutliers);
            panel_Filter.Controls.Add(gBox_FilterOrders);
            panel_Filter.Controls.Add(tb_PartNr);
            panel_Filter.Controls.Add(label_ChoosePartNumber);
            panel_Filter.Controls.Add(btn_ExportDataToExcel);
            panel_Filter.Controls.Add(cb_MeasureTemplateRevision);
            panel_Filter.Controls.Add(label_ChooseRevisionMeasureTemplate);
            panel_Filter.Controls.Add(cb_MeasureprotocolTemplateName);
            panel_Filter.Controls.Add(label_MeasureProtocolTemplateName);
            panel_Filter.Controls.Add(cb_Workoperations);
            panel_Filter.Controls.Add(label_ChooseWorkOperation);
            panel_Filter.Controls.Add(label_TotalOrders);
            panel_Filter.Dock = DockStyle.Left;
            panel_Filter.Location = new Point(0, 0);
            panel_Filter.MinimumSize = new Size(0, 650);
            panel_Filter.Name = "panel_Filter";
            panel_Filter.Size = new Size(320, 650);
            panel_Filter.TabIndex = 14;
            // 
            // label_FilterInfo
            // 
            label_FilterInfo.AutoSize = true;
            label_FilterInfo.Dock = DockStyle.Top;
            label_FilterInfo.ForeColor = Color.FromArgb(181, 210, 207);
            label_FilterInfo.Location = new Point(0, 270);
            label_FilterInfo.Name = "label_FilterInfo";
            label_FilterInfo.Size = new Size(54, 15);
            label_FilterInfo.TabIndex = 15;
            label_FilterInfo.Text = "FilterInfo";
            // 
            // chk_FilterDiscarded
            // 
            chk_FilterDiscarded.AutoSize = true;
            chk_FilterDiscarded.Dock = DockStyle.Top;
            chk_FilterDiscarded.Font = new Font("Segoe UI", 9F);
            chk_FilterDiscarded.ForeColor = Color.FromArgb(239, 228, 177);
            chk_FilterDiscarded.Location = new Point(0, 251);
            chk_FilterDiscarded.Name = "chk_FilterDiscarded";
            chk_FilterDiscarded.Padding = new Padding(1, 0, 0, 0);
            chk_FilterDiscarded.Size = new Size(320, 19);
            chk_FilterDiscarded.TabIndex = 14;
            chk_FilterDiscarded.Text = "Exkludera kasserade mätningar";
            chk_FilterDiscarded.UseVisualStyleBackColor = true;
            chk_FilterDiscarded.CheckedChanged += chk_FilterBad_CheckedChanged;
            // 
            // panel_FilterOutliers
            // 
            panel_FilterOutliers.Controls.Add(num_OutlierLimit);
            panel_FilterOutliers.Controls.Add(chk_FilterBadValues);
            panel_FilterOutliers.Controls.Add(label_Threshold);
            panel_FilterOutliers.Dock = DockStyle.Top;
            panel_FilterOutliers.Location = new Point(0, 222);
            panel_FilterOutliers.Margin = new Padding(0);
            panel_FilterOutliers.Name = "panel_FilterOutliers";
            panel_FilterOutliers.Padding = new Padding(1, 5, 0, 0);
            panel_FilterOutliers.Size = new Size(320, 29);
            panel_FilterOutliers.TabIndex = 17;
            // 
            // num_OutlierLimit
            // 
            num_OutlierLimit.BackColor = Color.FromArgb(6, 81, 87);
            num_OutlierLimit.Dock = DockStyle.Right;
            num_OutlierLimit.ForeColor = Color.FromArgb(239, 228, 177);
            num_OutlierLimit.Location = new Point(236, 5);
            num_OutlierLimit.Name = "num_OutlierLimit";
            num_OutlierLimit.Size = new Size(38, 23);
            num_OutlierLimit.TabIndex = 16;
            num_OutlierLimit.Value = new decimal(new int[] { 10, 0, 0, 0 });
            num_OutlierLimit.ValueChanged += chk_FilterBad_CheckedChanged;
            // 
            // chk_FilterBadValues
            // 
            chk_FilterBadValues.AutoSize = true;
            chk_FilterBadValues.Dock = DockStyle.Left;
            chk_FilterBadValues.Font = new Font("Segoe UI", 9F);
            chk_FilterBadValues.ForeColor = Color.FromArgb(239, 228, 177);
            chk_FilterBadValues.Location = new Point(1, 5);
            chk_FilterBadValues.Name = "chk_FilterBadValues";
            chk_FilterBadValues.Size = new Size(157, 24);
            chk_FilterBadValues.TabIndex = 14;
            chk_FilterBadValues.Text = "Ta bort avvikande värden";
            chk_FilterBadValues.UseVisualStyleBackColor = true;
            chk_FilterBadValues.CheckedChanged += chk_FilterBad_CheckedChanged;
            // 
            // label_Threshold
            // 
            label_Threshold.AutoSize = true;
            label_Threshold.Dock = DockStyle.Right;
            label_Threshold.Font = new Font("Segoe UI", 9F);
            label_Threshold.ForeColor = Color.FromArgb(239, 228, 177);
            label_Threshold.Location = new Point(274, 5);
            label_Threshold.Name = "label_Threshold";
            label_Threshold.Padding = new Padding(0, 3, 0, 0);
            label_Threshold.Size = new Size(46, 18);
            label_Threshold.TabIndex = 17;
            label_Threshold.Text = "Z Score";
            // 
            // gBox_FilterOrders
            // 
            gBox_FilterOrders.Controls.Add(btn_ReloadData);
            gBox_FilterOrders.Controls.Add(chkList_ListOrders);
            gBox_FilterOrders.Dock = DockStyle.Bottom;
            gBox_FilterOrders.Font = new Font("Segoe UI", 11F);
            gBox_FilterOrders.ForeColor = Color.FromArgb(239, 228, 177);
            gBox_FilterOrders.Location = new Point(0, 335);
            gBox_FilterOrders.Name = "gBox_FilterOrders";
            gBox_FilterOrders.Size = new Size(320, 282);
            gBox_FilterOrders.TabIndex = 12;
            gBox_FilterOrders.TabStop = false;
            gBox_FilterOrders.Text = "Välj ordrar";
            // 
            // btn_ReloadData
            // 
            btn_ReloadData.BackColor = Color.FromArgb(198, 239, 206);
            btn_ReloadData.Dock = DockStyle.Bottom;
            btn_ReloadData.FlatStyle = FlatStyle.Flat;
            btn_ReloadData.Font = new Font("Segoe UI", 10F);
            btn_ReloadData.ForeColor = Color.FromArgb(0, 97, 0);
            btn_ReloadData.Location = new Point(3, 253);
            btn_ReloadData.Margin = new Padding(0);
            btn_ReloadData.Name = "btn_ReloadData";
            btn_ReloadData.Size = new Size(314, 26);
            btn_ReloadData.TabIndex = 12;
            btn_ReloadData.Text = "Ladda Data";
            btn_ReloadData.UseVisualStyleBackColor = false;
            btn_ReloadData.Click += LoadOrder_Click;
            // 
            // chkList_ListOrders
            // 
            chkList_ListOrders.Dock = DockStyle.Fill;
            chkList_ListOrders.FormattingEnabled = true;
            chkList_ListOrders.Location = new Point(3, 23);
            chkList_ListOrders.MultiColumn = true;
            chkList_ListOrders.Name = "chkList_ListOrders";
            chkList_ListOrders.SelectionMode = SelectionMode.None;
            chkList_ListOrders.Size = new Size(314, 256);
            chkList_ListOrders.TabIndex = 14;
            chkList_ListOrders.ItemCheck += chkList_ListOrders_ItemCheck;
            chkList_ListOrders.MouseDown += chkList_ListOrders_MouseDown;
            // 
            // tb_PartNr
            // 
            tb_PartNr.Dock = DockStyle.Top;
            tb_PartNr.Location = new Point(0, 199);
            tb_PartNr.Margin = new Padding(4, 3, 4, 0);
            tb_PartNr.Name = "tb_PartNr";
            tb_PartNr.Size = new Size(320, 23);
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
            btn_ExportDataToExcel.Location = new Point(0, 617);
            btn_ExportDataToExcel.Margin = new Padding(0, 0, 2, 0);
            btn_ExportDataToExcel.Name = "btn_ExportDataToExcel";
            btn_ExportDataToExcel.Size = new Size(320, 33);
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
            cb_MeasureTemplateRevision.Location = new Point(0, 150);
            cb_MeasureTemplateRevision.Margin = new Padding(4, 3, 4, 0);
            cb_MeasureTemplateRevision.MaxDropDownItems = 25;
            cb_MeasureTemplateRevision.Name = "cb_MeasureTemplateRevision";
            cb_MeasureTemplateRevision.Size = new Size(320, 23);
            cb_MeasureTemplateRevision.Sorted = true;
            cb_MeasureTemplateRevision.TabIndex = 8;
            cb_MeasureTemplateRevision.SelectedValueChanged += cb_MeasureTemplateRevision_SelectionChangeCommitted;
            // 
            // label_ChooseRevisionMeasureTemplate
            // 
            label_ChooseRevisionMeasureTemplate.AutoSize = true;
            label_ChooseRevisionMeasureTemplate.Cursor = Cursors.Hand;
            label_ChooseRevisionMeasureTemplate.Dock = DockStyle.Top;
            label_ChooseRevisionMeasureTemplate.Font = new Font("Segoe UI", 9F);
            label_ChooseRevisionMeasureTemplate.ForeColor = Color.FromArgb(239, 228, 177);
            label_ChooseRevisionMeasureTemplate.Location = new Point(0, 126);
            label_ChooseRevisionMeasureTemplate.Margin = new Padding(4, 0, 4, 0);
            label_ChooseRevisionMeasureTemplate.Name = "label_ChooseRevisionMeasureTemplate";
            label_ChooseRevisionMeasureTemplate.Padding = new Padding(0, 5, 0, 4);
            label_ChooseRevisionMeasureTemplate.Size = new Size(298, 24);
            label_ChooseRevisionMeasureTemplate.TabIndex = 7;
            label_ChooseRevisionMeasureTemplate.Text = "Select Revision for the Measurement Protocol Template";
            // 
            // label_TotalOrders
            // 
            label_TotalOrders.AutoSize = true;
            label_TotalOrders.Dock = DockStyle.Top;
            label_TotalOrders.Font = new Font("Lucida Sans", 11F);
            label_TotalOrders.ForeColor = Color.FromArgb(181, 210, 207);
            label_TotalOrders.Location = new Point(0, 0);
            label_TotalOrders.Name = "label_TotalOrders";
            label_TotalOrders.Padding = new Padding(0, 5, 0, 10);
            label_TotalOrders.Size = new Size(104, 32);
            label_TotalOrders.TabIndex = 13;
            label_TotalOrders.Text = "Antal Ordrar: ";
            // 
            // tlp_Bottom
            // 
            tlp_Bottom.BackColor = Color.FromArgb(112, 198, 176);
            tlp_Bottom.ColumnCount = 3;
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 468F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 296F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Bottom.Controls.Add(panel_SPC, 1, 0);
            tlp_Bottom.Controls.Add(cf_MeasurePoints, 0, 0);
            tlp_Bottom.Dock = DockStyle.Fill;
            tlp_Bottom.Location = new Point(3, 656);
            tlp_Bottom.Name = "tlp_Bottom";
            tlp_Bottom.RowCount = 1;
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Bottom.Size = new Size(1955, 400);
            tlp_Bottom.TabIndex = 47;
            // 
            // panel_SPC
            // 
            panel_SPC.BackColor = Color.FromArgb(6, 81, 87);
            panel_SPC.Controls.Add(tlp_SPC_Data);
            panel_SPC.Controls.Add(label_SPC_Title);
            panel_SPC.Dock = DockStyle.Fill;
            panel_SPC.Location = new Point(471, 3);
            panel_SPC.Name = "panel_SPC";
            panel_SPC.Size = new Size(290, 394);
            panel_SPC.TabIndex = 3;
            // 
            // tlp_SPC_Data
            // 
            tlp_SPC_Data.BackColor = Color.FromArgb(6, 81, 87);
            tlp_SPC_Data.ColumnCount = 3;
            tlp_SPC_Data.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            tlp_SPC_Data.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 49F));
            tlp_SPC_Data.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_SPC_Data.Controls.Add(lbl_Bar_StandardDeviation, 2, 6);
            tlp_SPC_Data.Controls.Add(lbl_Bar_Ppk, 2, 10);
            tlp_SPC_Data.Controls.Add(lbl_Bar_Pp, 2, 9);
            tlp_SPC_Data.Controls.Add(lbl_Bar_Kurtosis, 2, 8);
            tlp_SPC_Data.Controls.Add(lbl_Kurtosis, 1, 8);
            tlp_SPC_Data.Controls.Add(lbl_Skewness, 1, 7);
            tlp_SPC_Data.Controls.Add(lbl_StandardDeviation, 1, 6);
            tlp_SPC_Data.Controls.Add(lbl_Range, 1, 5);
            tlp_SPC_Data.Controls.Add(label_Kurtosis, 0, 8);
            tlp_SPC_Data.Controls.Add(label_Skewness, 0, 7);
            tlp_SPC_Data.Controls.Add(label_StandardDev, 0, 6);
            tlp_SPC_Data.Controls.Add(label_Range, 0, 5);
            tlp_SPC_Data.Controls.Add(lbl_Min, 1, 3);
            tlp_SPC_Data.Controls.Add(label_Min, 0, 3);
            tlp_SPC_Data.Controls.Add(lbl_Max, 1, 4);
            tlp_SPC_Data.Controls.Add(label_Max, 0, 4);
            tlp_SPC_Data.Controls.Add(lbl_Median, 1, 2);
            tlp_SPC_Data.Controls.Add(label_Median, 0, 2);
            tlp_SPC_Data.Controls.Add(lbl_Mean, 1, 1);
            tlp_SPC_Data.Controls.Add(label_Mean, 0, 1);
            tlp_SPC_Data.Controls.Add(lbl_Ppk, 1, 10);
            tlp_SPC_Data.Controls.Add(label_Ppk, 0, 10);
            tlp_SPC_Data.Controls.Add(lbl_Pp, 1, 9);
            tlp_SPC_Data.Controls.Add(label_Pp, 0, 9);
            tlp_SPC_Data.Controls.Add(label_TotalMeasurements, 0, 0);
            tlp_SPC_Data.Controls.Add(lbl_TotalMeasurements, 1, 0);
            tlp_SPC_Data.Controls.Add(lbl_Bar_Skewness, 2, 7);
            tlp_SPC_Data.Controls.Add(label_PerformanceRatio, 0, 11);
            tlp_SPC_Data.Controls.Add(lbl_PerformanceRatio, 1, 11);
            tlp_SPC_Data.Controls.Add(lbl_Bar_PerformanceRatio, 2, 11);
            tlp_SPC_Data.Dock = DockStyle.Fill;
            tlp_SPC_Data.Location = new Point(0, 31);
            tlp_SPC_Data.Name = "tlp_SPC_Data";
            tlp_SPC_Data.RowCount = 13;
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.Size = new Size(290, 363);
            tlp_SPC_Data.TabIndex = 871;
            // 
            // lbl_Bar_StandardDeviation
            // 
            lbl_Bar_StandardDeviation.AutoSize = true;
            lbl_Bar_StandardDeviation.Dock = DockStyle.Fill;
            lbl_Bar_StandardDeviation.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_Bar_StandardDeviation.ForeColor = Color.FromArgb(147, 146, 153);
            lbl_Bar_StandardDeviation.Location = new Point(177, 120);
            lbl_Bar_StandardDeviation.Name = "lbl_Bar_StandardDeviation";
            lbl_Bar_StandardDeviation.Size = new Size(110, 20);
            lbl_Bar_StandardDeviation.TabIndex = 25;
            lbl_Bar_StandardDeviation.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl_Bar_Ppk
            // 
            lbl_Bar_Ppk.AutoSize = true;
            lbl_Bar_Ppk.Dock = DockStyle.Fill;
            lbl_Bar_Ppk.Location = new Point(177, 200);
            lbl_Bar_Ppk.Name = "lbl_Bar_Ppk";
            lbl_Bar_Ppk.Size = new Size(110, 20);
            lbl_Bar_Ppk.TabIndex = 24;
            lbl_Bar_Ppk.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Bar_Pp
            // 
            lbl_Bar_Pp.AutoSize = true;
            lbl_Bar_Pp.Dock = DockStyle.Fill;
            lbl_Bar_Pp.Location = new Point(177, 180);
            lbl_Bar_Pp.Name = "lbl_Bar_Pp";
            lbl_Bar_Pp.Size = new Size(110, 20);
            lbl_Bar_Pp.TabIndex = 23;
            lbl_Bar_Pp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Bar_Kurtosis
            // 
            lbl_Bar_Kurtosis.AutoSize = true;
            lbl_Bar_Kurtosis.Dock = DockStyle.Fill;
            lbl_Bar_Kurtosis.Location = new Point(177, 160);
            lbl_Bar_Kurtosis.Name = "lbl_Bar_Kurtosis";
            lbl_Bar_Kurtosis.Size = new Size(110, 20);
            lbl_Bar_Kurtosis.TabIndex = 22;
            lbl_Bar_Kurtosis.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Kurtosis
            // 
            lbl_Kurtosis.AutoSize = true;
            lbl_Kurtosis.Dock = DockStyle.Fill;
            lbl_Kurtosis.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Kurtosis.Location = new Point(128, 160);
            lbl_Kurtosis.Name = "lbl_Kurtosis";
            lbl_Kurtosis.Size = new Size(43, 20);
            lbl_Kurtosis.TabIndex = 20;
            lbl_Kurtosis.Text = "-";
            // 
            // lbl_Skewness
            // 
            lbl_Skewness.AutoSize = true;
            lbl_Skewness.Dock = DockStyle.Fill;
            lbl_Skewness.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Skewness.Location = new Point(128, 140);
            lbl_Skewness.Name = "lbl_Skewness";
            lbl_Skewness.Size = new Size(43, 20);
            lbl_Skewness.TabIndex = 19;
            lbl_Skewness.Text = "-";
            // 
            // lbl_StandardDeviation
            // 
            lbl_StandardDeviation.AutoSize = true;
            lbl_StandardDeviation.Dock = DockStyle.Fill;
            lbl_StandardDeviation.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_StandardDeviation.Location = new Point(128, 120);
            lbl_StandardDeviation.Name = "lbl_StandardDeviation";
            lbl_StandardDeviation.Size = new Size(43, 20);
            lbl_StandardDeviation.TabIndex = 18;
            lbl_StandardDeviation.Text = "-";
            // 
            // lbl_Range
            // 
            lbl_Range.AutoSize = true;
            lbl_Range.Dock = DockStyle.Fill;
            lbl_Range.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Range.Location = new Point(128, 100);
            lbl_Range.Name = "lbl_Range";
            lbl_Range.Size = new Size(43, 20);
            lbl_Range.TabIndex = 17;
            lbl_Range.Text = "-";
            // 
            // label_Kurtosis
            // 
            label_Kurtosis.AutoSize = true;
            label_Kurtosis.Dock = DockStyle.Fill;
            label_Kurtosis.ForeColor = Color.FromArgb(181, 210, 207);
            label_Kurtosis.Location = new Point(3, 160);
            label_Kurtosis.Name = "label_Kurtosis";
            label_Kurtosis.Size = new Size(119, 20);
            label_Kurtosis.TabIndex = 16;
            label_Kurtosis.Text = "Kurtosis:";
            label_Kurtosis.TextAlign = ContentAlignment.TopRight;
            label_Kurtosis.MouseHover += SPC_MouseHover;
            // 
            // label_Skewness
            // 
            label_Skewness.AutoSize = true;
            label_Skewness.Dock = DockStyle.Fill;
            label_Skewness.ForeColor = Color.FromArgb(181, 210, 207);
            label_Skewness.Location = new Point(3, 140);
            label_Skewness.Name = "label_Skewness";
            label_Skewness.Size = new Size(119, 20);
            label_Skewness.TabIndex = 15;
            label_Skewness.Text = "Skewness:";
            label_Skewness.TextAlign = ContentAlignment.TopRight;
            label_Skewness.MouseHover += SPC_MouseHover;
            // 
            // label_StandardDev
            // 
            label_StandardDev.AutoSize = true;
            label_StandardDev.Dock = DockStyle.Fill;
            label_StandardDev.ForeColor = Color.FromArgb(181, 210, 207);
            label_StandardDev.Location = new Point(3, 120);
            label_StandardDev.Name = "label_StandardDev";
            label_StandardDev.Size = new Size(119, 20);
            label_StandardDev.TabIndex = 14;
            label_StandardDev.Text = "Standard Deviation:";
            label_StandardDev.TextAlign = ContentAlignment.TopRight;
            label_StandardDev.MouseHover += SPC_MouseHover;
            // 
            // label_Range
            // 
            label_Range.AutoSize = true;
            label_Range.Dock = DockStyle.Fill;
            label_Range.ForeColor = Color.FromArgb(181, 210, 207);
            label_Range.Location = new Point(3, 100);
            label_Range.Name = "label_Range";
            label_Range.Size = new Size(119, 20);
            label_Range.TabIndex = 13;
            label_Range.Text = "Range:";
            label_Range.TextAlign = ContentAlignment.TopRight;
            label_Range.MouseHover += SPC_MouseHover;
            // 
            // lbl_Min
            // 
            lbl_Min.AutoSize = true;
            lbl_Min.Dock = DockStyle.Fill;
            lbl_Min.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Min.Location = new Point(128, 60);
            lbl_Min.Name = "lbl_Min";
            lbl_Min.Size = new Size(43, 20);
            lbl_Min.TabIndex = 12;
            lbl_Min.Text = "-";
            // 
            // label_Min
            // 
            label_Min.AutoSize = true;
            label_Min.Dock = DockStyle.Fill;
            label_Min.ForeColor = Color.FromArgb(181, 210, 207);
            label_Min.Location = new Point(3, 60);
            label_Min.Name = "label_Min";
            label_Min.Size = new Size(119, 20);
            label_Min.TabIndex = 11;
            label_Min.Text = "Min:";
            label_Min.TextAlign = ContentAlignment.TopRight;
            label_Min.MouseHover += SPC_MouseHover;
            // 
            // lbl_Max
            // 
            lbl_Max.AutoSize = true;
            lbl_Max.Dock = DockStyle.Fill;
            lbl_Max.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Max.Location = new Point(128, 80);
            lbl_Max.Name = "lbl_Max";
            lbl_Max.Size = new Size(43, 20);
            lbl_Max.TabIndex = 10;
            lbl_Max.Text = "-";
            // 
            // label_Max
            // 
            label_Max.AutoSize = true;
            label_Max.Dock = DockStyle.Fill;
            label_Max.ForeColor = Color.FromArgb(181, 210, 207);
            label_Max.Location = new Point(3, 80);
            label_Max.Name = "label_Max";
            label_Max.Size = new Size(119, 20);
            label_Max.TabIndex = 9;
            label_Max.Text = "Max:";
            label_Max.TextAlign = ContentAlignment.TopRight;
            label_Max.MouseHover += SPC_MouseHover;
            // 
            // lbl_Median
            // 
            lbl_Median.AutoSize = true;
            lbl_Median.Dock = DockStyle.Fill;
            lbl_Median.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Median.Location = new Point(128, 40);
            lbl_Median.Name = "lbl_Median";
            lbl_Median.Size = new Size(43, 20);
            lbl_Median.TabIndex = 8;
            lbl_Median.Text = "-";
            // 
            // label_Median
            // 
            label_Median.AutoSize = true;
            label_Median.Dock = DockStyle.Fill;
            label_Median.ForeColor = Color.FromArgb(181, 210, 207);
            label_Median.Location = new Point(3, 40);
            label_Median.Name = "label_Median";
            label_Median.Size = new Size(119, 20);
            label_Median.TabIndex = 7;
            label_Median.Text = "Median:";
            label_Median.TextAlign = ContentAlignment.TopRight;
            label_Median.MouseHover += SPC_MouseHover;
            // 
            // lbl_Mean
            // 
            lbl_Mean.AutoSize = true;
            lbl_Mean.Dock = DockStyle.Fill;
            lbl_Mean.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Mean.Location = new Point(128, 20);
            lbl_Mean.Name = "lbl_Mean";
            lbl_Mean.Size = new Size(43, 20);
            lbl_Mean.TabIndex = 6;
            lbl_Mean.Text = "-";
            // 
            // label_Mean
            // 
            label_Mean.AutoSize = true;
            label_Mean.Dock = DockStyle.Fill;
            label_Mean.ForeColor = Color.FromArgb(181, 210, 207);
            label_Mean.Location = new Point(3, 20);
            label_Mean.Name = "label_Mean";
            label_Mean.Size = new Size(119, 20);
            label_Mean.TabIndex = 5;
            label_Mean.Text = "Mean:";
            label_Mean.TextAlign = ContentAlignment.TopRight;
            label_Mean.MouseHover += SPC_MouseHover;
            // 
            // lbl_Ppk
            // 
            lbl_Ppk.AutoSize = true;
            lbl_Ppk.Dock = DockStyle.Fill;
            lbl_Ppk.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Ppk.Location = new Point(128, 200);
            lbl_Ppk.Name = "lbl_Ppk";
            lbl_Ppk.Size = new Size(43, 20);
            lbl_Ppk.TabIndex = 4;
            lbl_Ppk.Text = "-";
            // 
            // label_Ppk
            // 
            label_Ppk.AutoSize = true;
            label_Ppk.Dock = DockStyle.Fill;
            label_Ppk.ForeColor = Color.FromArgb(181, 210, 207);
            label_Ppk.Location = new Point(3, 200);
            label_Ppk.Name = "label_Ppk";
            label_Ppk.Size = new Size(119, 20);
            label_Ppk.TabIndex = 3;
            label_Ppk.Text = "Ppk:";
            label_Ppk.TextAlign = ContentAlignment.TopRight;
            label_Ppk.MouseHover += SPC_MouseHover;
            // 
            // lbl_Pp
            // 
            lbl_Pp.AutoSize = true;
            lbl_Pp.Dock = DockStyle.Fill;
            lbl_Pp.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Pp.Location = new Point(128, 180);
            lbl_Pp.Name = "lbl_Pp";
            lbl_Pp.Size = new Size(43, 20);
            lbl_Pp.TabIndex = 2;
            lbl_Pp.Text = "-";
            // 
            // label_Pp
            // 
            label_Pp.AutoSize = true;
            label_Pp.Dock = DockStyle.Fill;
            label_Pp.ForeColor = Color.FromArgb(181, 210, 207);
            label_Pp.Location = new Point(3, 180);
            label_Pp.Name = "label_Pp";
            label_Pp.Size = new Size(119, 20);
            label_Pp.TabIndex = 1;
            label_Pp.Text = "Pp:";
            label_Pp.TextAlign = ContentAlignment.TopRight;
            label_Pp.MouseHover += SPC_MouseHover;
            // 
            // label_TotalMeasurements
            // 
            label_TotalMeasurements.AutoSize = true;
            label_TotalMeasurements.Dock = DockStyle.Fill;
            label_TotalMeasurements.ForeColor = Color.FromArgb(181, 210, 207);
            label_TotalMeasurements.Location = new Point(3, 0);
            label_TotalMeasurements.Name = "label_TotalMeasurements";
            label_TotalMeasurements.Size = new Size(119, 20);
            label_TotalMeasurements.TabIndex = 0;
            label_TotalMeasurements.Text = "Total Measurements:";
            label_TotalMeasurements.TextAlign = ContentAlignment.TopRight;
            label_TotalMeasurements.MouseHover += SPC_MouseHover;
            // 
            // lbl_TotalMeasurements
            // 
            lbl_TotalMeasurements.AutoSize = true;
            lbl_TotalMeasurements.Dock = DockStyle.Fill;
            lbl_TotalMeasurements.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_TotalMeasurements.Location = new Point(128, 0);
            lbl_TotalMeasurements.Name = "lbl_TotalMeasurements";
            lbl_TotalMeasurements.Size = new Size(43, 20);
            lbl_TotalMeasurements.TabIndex = 0;
            lbl_TotalMeasurements.Text = "0";
            // 
            // lbl_Bar_Skewness
            // 
            lbl_Bar_Skewness.AutoSize = true;
            lbl_Bar_Skewness.Dock = DockStyle.Fill;
            lbl_Bar_Skewness.Location = new Point(177, 140);
            lbl_Bar_Skewness.Name = "lbl_Bar_Skewness";
            lbl_Bar_Skewness.Size = new Size(110, 20);
            lbl_Bar_Skewness.TabIndex = 21;
            lbl_Bar_Skewness.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_PerformanceRatio
            // 
            label_PerformanceRatio.AutoSize = true;
            label_PerformanceRatio.Dock = DockStyle.Fill;
            label_PerformanceRatio.ForeColor = Color.FromArgb(181, 210, 207);
            label_PerformanceRatio.Location = new Point(3, 220);
            label_PerformanceRatio.Name = "label_PerformanceRatio";
            label_PerformanceRatio.Size = new Size(119, 20);
            label_PerformanceRatio.TabIndex = 26;
            label_PerformanceRatio.Text = "Performance Ratio:";
            label_PerformanceRatio.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_PerformanceRatio
            // 
            lbl_PerformanceRatio.AutoSize = true;
            lbl_PerformanceRatio.Dock = DockStyle.Fill;
            lbl_PerformanceRatio.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_PerformanceRatio.Location = new Point(128, 220);
            lbl_PerformanceRatio.Name = "lbl_PerformanceRatio";
            lbl_PerformanceRatio.Size = new Size(43, 20);
            lbl_PerformanceRatio.TabIndex = 27;
            lbl_PerformanceRatio.Text = "-";
            // 
            // lbl_Bar_PerformanceRatio
            // 
            lbl_Bar_PerformanceRatio.AutoSize = true;
            lbl_Bar_PerformanceRatio.Dock = DockStyle.Fill;
            lbl_Bar_PerformanceRatio.Location = new Point(177, 220);
            lbl_Bar_PerformanceRatio.Name = "lbl_Bar_PerformanceRatio";
            lbl_Bar_PerformanceRatio.Size = new Size(110, 20);
            lbl_Bar_PerformanceRatio.TabIndex = 28;
            lbl_Bar_PerformanceRatio.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_SPC_Title
            // 
            label_SPC_Title.BackColor = Color.Transparent;
            label_SPC_Title.Dock = DockStyle.Top;
            label_SPC_Title.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold);
            label_SPC_Title.ForeColor = Color.Moccasin;
            label_SPC_Title.Location = new Point(0, 0);
            label_SPC_Title.Margin = new Padding(4, 0, 4, 0);
            label_SPC_Title.Name = "label_SPC_Title";
            label_SPC_Title.Size = new Size(290, 31);
            label_SPC_Title.TabIndex = 870;
            label_SPC_Title.Text = "SPC-analys av mätdata:";
            label_SPC_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cf_MeasurePoints
            // 
            cf_MeasurePoints.BackColor = Color.Black;
            cf_MeasurePoints.Dock = DockStyle.Fill;
            cf_MeasurePoints.Location = new Point(4, 3);
            cf_MeasurePoints.Margin = new Padding(4, 3, 4, 3);
            cf_MeasurePoints.Name = "cf_MeasurePoints";
            cf_MeasurePoints.Size = new Size(460, 394);
            cf_MeasurePoints.TabIndex = 4;
            // 
            // BrowseMeasureProtocols
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.FromArgb(45, 45, 45);
            ClientSize = new Size(1961, 1059);
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
            panel_FilterOutliers.ResumeLayout(false);
            panel_FilterOutliers.PerformLayout();
            ((ISupportInitialize)num_OutlierLimit).EndInit();
            gBox_FilterOrders.ResumeLayout(false);
            tlp_Bottom.ResumeLayout(false);
            panel_SPC.ResumeLayout(false);
            tlp_SPC_Data.ResumeLayout(false);
            tlp_SPC_Data.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private Label label_ChoosePartNumber;
        private System.Threading.Timer timer_AddPoints;
        private DataGridView dgv_MeasureProtocol;
        private Label label_Info;
        private Label label_MeasureProtocolTemplateName;
        private ComboBox cb_MeasureprotocolTemplateName;
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
        private Label label_ChooseRevisionMeasureTemplate;
        private ComboBox cb_MeasureTemplateRevision;
        private TableLayoutPanel tlp_Bottom;
        private GroupBox gBox_FilterOrders;
        private Button btn_ReloadData;
        private Label label_TotalOrders;
        private Button btn_ExportDataToExcel;
        private CheckedListBox chkList_ListOrders;
        private Panel panel_Filter;
        private CheckBox chk_FilterBadValues;
        private CheckBox chk_FilterDiscarded;
        private Label label_FilterInfo;
        private Panel panel1;
        private Panel panel_FilterOutliers;
        private NumericUpDown num_OutlierLimit;
        private Label label_Threshold;
        private Panel panel_SPC;
        private Label label_TotalMeasurements;
        private Label lbl_TotalMeasurements;
        public Label label_SPC_Title;
        private TableLayoutPanel tlp_SPC_Data;
        private Label lbl_Pp;
        private Label label_Pp;
        private Label lbl_Ppk;
        private Label label_Ppk;
        private Label label_Mean;
        private Label lbl_Mean;
        private Label label_Median;
        private Label lbl_Median;
        private Label lbl_Min;
        private Label label_Min;
        private Label lbl_Max;
        private Label label_Max;
        private Label label_StandardDev;
        private Label label_Range;
        private Label lbl_Kurtosis;
        private Label lbl_Skewness;
        private Label lbl_StandardDeviation;
        private Label lbl_Range;
        private Label label_Kurtosis;
        private Label label_Skewness;
        private Label lbl_Bar_Skewness;
        private Label lbl_Bar_Ppk;
        private Label lbl_Bar_Pp;
        private Label lbl_Bar_Kurtosis;
        private Label lbl_Bar_StandardDeviation;
        private ToolTip toolTip1;
        private MeasurePoints cf_MeasurePoints;
        private Label label_PerformanceRatio;
        private Label lbl_PerformanceRatio;
        private Label lbl_Bar_PerformanceRatio;
    }
}