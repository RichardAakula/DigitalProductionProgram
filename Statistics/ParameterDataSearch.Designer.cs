using System.ComponentModel;

namespace DigitalProductionProgram.Statistics
{
    partial class ParameterDataSearch
    {
        private IContainer components = null;
        private TableLayoutPanel tlpMain;
        private TableLayoutPanel tlpFilter;
        private TableLayoutPanel tlpPartNr;
        private FlowLayoutPanel flpActions;
        private GroupBox gb_Parameters;
        private GroupBox gb_Filter;
        private Label lbl_Description;
        private Label lbl_Status;
        private Label label_MeasurementParameters;
        private Label label_ProtocolParameters;
        private Label label_FilterInfo_PartNumber;
        private Label label_FilterInfo_PreFab_PartNumber;
        private Label label_FilterInfo_PreFab_Description;
        private ComboBox cb_WorkOperation;
        private ComboBox cb_MeasureTemplate;
        private ComboBox cb_ProtocolTemplate;
        private TextBox tb_FilterMeasurementParameters;
        private TextBox tb_FilterProtocolParameters;
        private TextBox tb_FilterPartNr;
        private TextBox tb_FilterPrefabPartNr;
        private TextBox tb_FilterPrefabDescription;
        private ListBox lb_MeasureProtocolParameters;
        private ListBox lb_SelectedMeasureParameters;
        private ListBox lb_ProtocolParameters;
        private ListBox lb_SelectedProtocolParameters;
        private ListBox lb_PartNr;
        private ListBox lb_SelectedPartNr;
        private ListBox lb_PrefabPartNr;
        private ListBox lb_SelectedPrefabPartNr;
        private ListBox lb_PrefabDescription;
        private ListBox lb_SelectedPrefabDescription;
        private FlowLayoutPanel flpParameterAddActions;
        private FlowLayoutPanel flpFilterAddActions;
        private Button btn_AddMeasureParameter;
        private Button btn_AddOrder;
        private Button btn_AddPartNr;
        private Button btn_AddPrefabPartNr;
        private Button btn_AddPrefabDescription;
        private Button btn_RemoveMeasure;
        private Button btn_RemoveOrder;
        private Button btn_RemovePartNr;
        private Button btn_RemovePrefabPartNr;
        private Button btn_RemovePrefabDescription;
        private Button btnFetchData;
        private Button btn_StopSearch;
        private DataGridView dgv_Result;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tlpMain = new TableLayoutPanel();
            lbl_Description = new Label();
            gb_Parameters = new GroupBox();
            tlpFilter = new TableLayoutPanel();
            label_MeasurementParameters = new Label();
            label_ProtocolParameters = new Label();
            cb_MeasureTemplate = new ComboBox();
            cb_ProtocolTemplate = new ComboBox();
            tb_FilterMeasurementParameters = new TextBox();
            tb_FilterProtocolParameters = new TextBox();
            lb_MeasureProtocolParameters = new ListBox();
            lb_SelectedMeasureParameters = new ListBox();
            flpParameterAddActions = new FlowLayoutPanel();
            lb_ProtocolParameters = new ListBox();
            lb_SelectedProtocolParameters = new ListBox();
            btn_AddMeasureParameter = new Button();
            btn_RemoveMeasure = new Button();
            btn_AddOrder = new Button();
            btn_RemoveOrder = new Button();
            gb_Filter = new GroupBox();
            tlpPartNr = new TableLayoutPanel();
            label_FilterInfo_PartNumber = new Label();
            label_FilterInfo_PreFab_PartNumber = new Label();
            label_FilterInfo_PreFab_Description = new Label();
            cb_WorkOperation = new ComboBox();
            tb_FilterPartNr = new TextBox();
            tb_FilterPrefabPartNr = new TextBox();
            tb_FilterPrefabDescription = new TextBox();
            lb_PartNr = new ListBox();
            lb_SelectedPartNr = new ListBox();
            flpFilterAddActions = new FlowLayoutPanel();
            lb_PrefabPartNr = new ListBox();
            lb_SelectedPrefabPartNr = new ListBox();
            lb_PrefabDescription = new ListBox();
            lb_SelectedPrefabDescription = new ListBox();
            btn_AddPartNr = new Button();
            btn_RemovePartNr = new Button();
            btn_AddPrefabPartNr = new Button();
            btn_RemovePrefabPartNr = new Button();
            btn_AddPrefabDescription = new Button();
            btn_RemovePrefabDescription = new Button();
            flpActions = new FlowLayoutPanel();
            btnFetchData = new Button();
            lbl_Status = new Label();
            btn_ExportToCsv = new Button();
            btn_StopSearch = new Button();
            dgv_Result = new DataGridView();
            tlpMain.SuspendLayout();
            gb_Parameters.SuspendLayout();
            tlpFilter.SuspendLayout();
            gb_Filter.SuspendLayout();
            tlpPartNr.SuspendLayout();
            flpActions.SuspendLayout();
            ((ISupportInitialize)dgv_Result).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.BackColor = Color.Transparent;
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(lbl_Description, 0, 0);
            tlpMain.Controls.Add(gb_Parameters, 0, 1);
            tlpMain.Controls.Add(gb_Filter, 0, 2);
            tlpMain.Controls.Add(flpActions, 0, 3);
            tlpMain.Controls.Add(dgv_Result, 0, 4);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(12, 12);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 5;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 316F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 308F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1756, 961);
            tlpMain.TabIndex = 0;
            // 
            // lbl_Description
            // 
            lbl_Description.AutoSize = true;
            lbl_Description.Dock = DockStyle.Fill;
            lbl_Description.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Description.ForeColor = Color.FromArgb(239, 228, 177);
            lbl_Description.Location = new Point(3, 0);
            lbl_Description.Name = "lbl_Description";
            lbl_Description.Size = new Size(1750, 45);
            lbl_Description.TabIndex = 0;
            lbl_Description.Text = "Välj parametrar och filter. \r\nTips: filtrera text genom att skriva i textrutan, eller *text for att visa poster som innehaller texten.";
            // 
            // gb_Parameters
            // 
            gb_Parameters.Controls.Add(tlpFilter);
            gb_Parameters.Dock = DockStyle.Fill;
            gb_Parameters.ForeColor = Color.FromArgb(239, 228, 177);
            gb_Parameters.Location = new Point(3, 48);
            gb_Parameters.Name = "gb_Parameters";
            gb_Parameters.Padding = new Padding(5);
            gb_Parameters.Size = new Size(1750, 310);
            gb_Parameters.TabIndex = 1;
            gb_Parameters.TabStop = false;
            gb_Parameters.Text = "Parametrar";
            // 
            // tlpFilter
            // 
            tlpFilter.ColumnCount = 7;
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpFilter.Controls.Add(label_MeasurementParameters, 0, 0);
            tlpFilter.Controls.Add(label_ProtocolParameters, 3, 0);
            tlpFilter.Controls.Add(cb_MeasureTemplate, 0, 1);
            tlpFilter.Controls.Add(cb_ProtocolTemplate, 3, 1);
            tlpFilter.Controls.Add(tb_FilterMeasurementParameters, 0, 2);
            tlpFilter.Controls.Add(tb_FilterProtocolParameters, 3, 2);
            tlpFilter.Controls.Add(lb_MeasureProtocolParameters, 0, 3);
            tlpFilter.Controls.Add(lb_SelectedMeasureParameters, 1, 3);
            tlpFilter.Controls.Add(flpParameterAddActions, 6, 3);
            tlpFilter.Controls.Add(lb_ProtocolParameters, 3, 3);
            tlpFilter.Controls.Add(lb_SelectedProtocolParameters, 4, 3);
            tlpFilter.Controls.Add(btn_AddMeasureParameter, 0, 4);
            tlpFilter.Controls.Add(btn_RemoveMeasure, 1, 4);
            tlpFilter.Controls.Add(btn_AddOrder, 3, 4);
            tlpFilter.Controls.Add(btn_RemoveOrder, 4, 4);
            tlpFilter.Dock = DockStyle.Fill;
            tlpFilter.Location = new Point(5, 21);
            tlpFilter.Name = "tlpFilter";
            tlpFilter.RowCount = 5;
            tlpFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlpFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlpFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 179F));
            tlpFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tlpFilter.Size = new Size(1740, 284);
            tlpFilter.TabIndex = 0;
            // 
            // label_MeasurementParameters
            // 
            label_MeasurementParameters.AutoSize = true;
            tlpFilter.SetColumnSpan(label_MeasurementParameters, 2);
            label_MeasurementParameters.Dock = DockStyle.Fill;
            label_MeasurementParameters.Font = new Font("Lucida Sans", 12F);
            label_MeasurementParameters.ForeColor = Color.FromArgb(187, 215, 228);
            label_MeasurementParameters.Location = new Point(3, 0);
            label_MeasurementParameters.Name = "label_MeasurementParameters";
            label_MeasurementParameters.Size = new Size(294, 20);
            label_MeasurementParameters.TabIndex = 0;
            label_MeasurementParameters.Text = "Mätparametrar";
            label_MeasurementParameters.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_ProtocolParameters
            // 
            label_ProtocolParameters.AutoSize = true;
            tlpFilter.SetColumnSpan(label_ProtocolParameters, 2);
            label_ProtocolParameters.Dock = DockStyle.Fill;
            label_ProtocolParameters.Font = new Font("Lucida Sans", 12F);
            label_ProtocolParameters.ForeColor = Color.FromArgb(187, 215, 228);
            label_ProtocolParameters.Location = new Point(418, 0);
            label_ProtocolParameters.Name = "label_ProtocolParameters";
            label_ProtocolParameters.Size = new Size(394, 20);
            label_ProtocolParameters.TabIndex = 1;
            label_ProtocolParameters.Text = "Protokoll parametrar";
            label_ProtocolParameters.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cb_MeasureTemplate
            // 
            tlpFilter.SetColumnSpan(cb_MeasureTemplate, 2);
            cb_MeasureTemplate.Dock = DockStyle.Fill;
            cb_MeasureTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_MeasureTemplate.FormattingEnabled = true;
            cb_MeasureTemplate.Location = new Point(3, 23);
            cb_MeasureTemplate.Name = "cb_MeasureTemplate";
            cb_MeasureTemplate.Size = new Size(294, 23);
            cb_MeasureTemplate.TabIndex = 2;
            // 
            // cb_ProtocolTemplate
            // 
            tlpFilter.SetColumnSpan(cb_ProtocolTemplate, 2);
            cb_ProtocolTemplate.Dock = DockStyle.Fill;
            cb_ProtocolTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_ProtocolTemplate.FormattingEnabled = true;
            cb_ProtocolTemplate.Location = new Point(418, 23);
            cb_ProtocolTemplate.Name = "cb_ProtocolTemplate";
            cb_ProtocolTemplate.Size = new Size(394, 23);
            cb_ProtocolTemplate.TabIndex = 3;
            // 
            // tb_FilterMeasurementParameters
            // 
            tlpFilter.SetColumnSpan(tb_FilterMeasurementParameters, 2);
            tb_FilterMeasurementParameters.Dock = DockStyle.Fill;
            tb_FilterMeasurementParameters.Location = new Point(3, 51);
            tb_FilterMeasurementParameters.Name = "tb_FilterMeasurementParameters";
            tb_FilterMeasurementParameters.PlaceholderText = "Lägg till mätparametrar...";
            tb_FilterMeasurementParameters.Size = new Size(294, 23);
            tb_FilterMeasurementParameters.TabIndex = 4;
            // 
            // tb_FilterProtocolParameters
            // 
            tlpFilter.SetColumnSpan(tb_FilterProtocolParameters, 2);
            tb_FilterProtocolParameters.Dock = DockStyle.Fill;
            tb_FilterProtocolParameters.Location = new Point(418, 51);
            tb_FilterProtocolParameters.Name = "tb_FilterProtocolParameters";
            tb_FilterProtocolParameters.PlaceholderText = "Lägg till protokoll parametrar...";
            tb_FilterProtocolParameters.Size = new Size(394, 23);
            tb_FilterProtocolParameters.TabIndex = 5;
            // 
            // lb_MeasureProtocolParameters
            // 
            lb_MeasureProtocolParameters.BackColor = Color.FromArgb(25, 25, 25);
            lb_MeasureProtocolParameters.Dock = DockStyle.Fill;
            lb_MeasureProtocolParameters.ForeColor = Color.FromArgb(255, 235, 156);
            lb_MeasureProtocolParameters.ItemHeight = 15;
            lb_MeasureProtocolParameters.Location = new Point(3, 79);
            lb_MeasureProtocolParameters.Name = "lb_MeasureProtocolParameters";
            lb_MeasureProtocolParameters.SelectionMode = SelectionMode.MultiExtended;
            lb_MeasureProtocolParameters.Size = new Size(144, 173);
            lb_MeasureProtocolParameters.TabIndex = 5;
            // 
            // lb_SelectedMeasureParameters
            // 
            lb_SelectedMeasureParameters.BackColor = Color.FromArgb(25, 25, 25);
            lb_SelectedMeasureParameters.Dock = DockStyle.Fill;
            lb_SelectedMeasureParameters.ForeColor = Color.FromArgb(198, 239, 206);
            lb_SelectedMeasureParameters.ItemHeight = 15;
            lb_SelectedMeasureParameters.Location = new Point(153, 79);
            lb_SelectedMeasureParameters.Name = "lb_SelectedMeasureParameters";
            lb_SelectedMeasureParameters.SelectionMode = SelectionMode.MultiExtended;
            lb_SelectedMeasureParameters.Size = new Size(144, 173);
            lb_SelectedMeasureParameters.TabIndex = 6;
            // 
            // flpParameterAddActions
            // 
            flpParameterAddActions.AutoSize = true;
            flpParameterAddActions.Dock = DockStyle.Top;
            flpParameterAddActions.FlowDirection = FlowDirection.TopDown;
            flpParameterAddActions.Location = new Point(933, 79);
            flpParameterAddActions.Name = "flpParameterAddActions";
            flpParameterAddActions.Size = new Size(804, 0);
            flpParameterAddActions.TabIndex = 11;
            flpParameterAddActions.WrapContents = false;
            // 
            // lb_ProtocolParameters
            // 
            lb_ProtocolParameters.BackColor = Color.FromArgb(25, 25, 25);
            lb_ProtocolParameters.Dock = DockStyle.Fill;
            lb_ProtocolParameters.ForeColor = Color.FromArgb(255, 235, 156);
            lb_ProtocolParameters.ItemHeight = 15;
            lb_ProtocolParameters.Location = new Point(418, 79);
            lb_ProtocolParameters.Name = "lb_ProtocolParameters";
            lb_ProtocolParameters.SelectionMode = SelectionMode.MultiExtended;
            lb_ProtocolParameters.Size = new Size(194, 173);
            lb_ProtocolParameters.TabIndex = 8;
            // 
            // lb_SelectedProtocolParameters
            // 
            lb_SelectedProtocolParameters.BackColor = Color.FromArgb(25, 25, 25);
            lb_SelectedProtocolParameters.Dock = DockStyle.Fill;
            lb_SelectedProtocolParameters.ForeColor = Color.FromArgb(198, 239, 206);
            lb_SelectedProtocolParameters.ItemHeight = 15;
            lb_SelectedProtocolParameters.Location = new Point(618, 79);
            lb_SelectedProtocolParameters.Name = "lb_SelectedProtocolParameters";
            lb_SelectedProtocolParameters.SelectionMode = SelectionMode.MultiExtended;
            lb_SelectedProtocolParameters.Size = new Size(194, 173);
            lb_SelectedProtocolParameters.TabIndex = 9;
            // 
            // btn_AddMeasureParameter
            // 
            btn_AddMeasureParameter.AutoSize = true;
            btn_AddMeasureParameter.BackColor = Color.FromArgb(198, 239, 206);
            btn_AddMeasureParameter.Dock = DockStyle.Left;
            btn_AddMeasureParameter.FlatStyle = FlatStyle.Flat;
            btn_AddMeasureParameter.Font = new Font("Segoe UI", 12F);
            btn_AddMeasureParameter.ForeColor = Color.FromArgb(0, 97, 0);
            btn_AddMeasureParameter.Location = new Point(3, 258);
            btn_AddMeasureParameter.Name = "btn_AddMeasureParameter";
            btn_AddMeasureParameter.Size = new Size(30, 23);
            btn_AddMeasureParameter.TabIndex = 0;
            btn_AddMeasureParameter.Text = "+";
            btn_AddMeasureParameter.UseCompatibleTextRendering = true;
            btn_AddMeasureParameter.UseVisualStyleBackColor = false;
            // 
            // btn_RemoveMeasure
            // 
            btn_RemoveMeasure.BackColor = Color.FromArgb(255, 199, 206);
            btn_RemoveMeasure.Dock = DockStyle.Left;
            btn_RemoveMeasure.FlatStyle = FlatStyle.Flat;
            btn_RemoveMeasure.Font = new Font("Segoe UI", 12F);
            btn_RemoveMeasure.ForeColor = Color.FromArgb(156, 0, 6);
            btn_RemoveMeasure.Location = new Point(153, 258);
            btn_RemoveMeasure.Name = "btn_RemoveMeasure";
            btn_RemoveMeasure.Size = new Size(30, 23);
            btn_RemoveMeasure.TabIndex = 6;
            btn_RemoveMeasure.Text = "-";
            btn_RemoveMeasure.UseCompatibleTextRendering = true;
            btn_RemoveMeasure.UseVisualStyleBackColor = false;
            // 
            // btn_AddOrder
            // 
            btn_AddOrder.AutoSize = true;
            btn_AddOrder.BackColor = Color.FromArgb(198, 239, 206);
            btn_AddOrder.Dock = DockStyle.Left;
            btn_AddOrder.FlatStyle = FlatStyle.Flat;
            btn_AddOrder.Font = new Font("Segoe UI", 12F);
            btn_AddOrder.ForeColor = Color.FromArgb(0, 97, 0);
            btn_AddOrder.Location = new Point(418, 258);
            btn_AddOrder.Name = "btn_AddOrder";
            btn_AddOrder.Size = new Size(30, 23);
            btn_AddOrder.TabIndex = 1;
            btn_AddOrder.Text = "+";
            btn_AddOrder.UseCompatibleTextRendering = true;
            btn_AddOrder.UseVisualStyleBackColor = false;
            // 
            // btn_RemoveOrder
            // 
            btn_RemoveOrder.BackColor = Color.FromArgb(255, 199, 206);
            btn_RemoveOrder.Dock = DockStyle.Left;
            btn_RemoveOrder.FlatStyle = FlatStyle.Flat;
            btn_RemoveOrder.Font = new Font("Segoe UI", 12F);
            btn_RemoveOrder.ForeColor = Color.FromArgb(156, 0, 6);
            btn_RemoveOrder.Location = new Point(618, 258);
            btn_RemoveOrder.Name = "btn_RemoveOrder";
            btn_RemoveOrder.Size = new Size(30, 23);
            btn_RemoveOrder.TabIndex = 9;
            btn_RemoveOrder.Text = "-";
            btn_RemoveOrder.UseCompatibleTextRendering = true;
            btn_RemoveOrder.UseVisualStyleBackColor = false;
            // 
            // gb_Filter
            // 
            gb_Filter.Controls.Add(tlpPartNr);
            gb_Filter.Dock = DockStyle.Fill;
            gb_Filter.ForeColor = Color.FromArgb(239, 228, 177);
            gb_Filter.Location = new Point(3, 364);
            gb_Filter.Name = "gb_Filter";
            gb_Filter.Padding = new Padding(5);
            gb_Filter.Size = new Size(1750, 302);
            gb_Filter.TabIndex = 2;
            gb_Filter.TabStop = false;
            gb_Filter.Text = "Filter (valfritt)";
            // 
            // tlpPartNr
            // 
            tlpPartNr.ColumnCount = 10;
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPartNr.Controls.Add(label_FilterInfo_PartNumber, 0, 0);
            tlpPartNr.Controls.Add(label_FilterInfo_PreFab_PartNumber, 3, 0);
            tlpPartNr.Controls.Add(label_FilterInfo_PreFab_Description, 6, 0);
            tlpPartNr.Controls.Add(cb_WorkOperation, 0, 1);
            tlpPartNr.Controls.Add(tb_FilterPartNr, 0, 2);
            tlpPartNr.Controls.Add(tb_FilterPrefabPartNr, 3, 2);
            tlpPartNr.Controls.Add(tb_FilterPrefabDescription, 6, 2);
            tlpPartNr.Controls.Add(lb_PartNr, 0, 3);
            tlpPartNr.Controls.Add(lb_SelectedPartNr, 1, 3);
            tlpPartNr.Controls.Add(flpFilterAddActions, 9, 3);
            tlpPartNr.Controls.Add(lb_PrefabPartNr, 3, 3);
            tlpPartNr.Controls.Add(lb_SelectedPrefabPartNr, 4, 3);
            tlpPartNr.Controls.Add(lb_PrefabDescription, 6, 3);
            tlpPartNr.Controls.Add(lb_SelectedPrefabDescription, 7, 3);
            tlpPartNr.Controls.Add(btn_AddPartNr, 0, 4);
            tlpPartNr.Controls.Add(btn_RemovePartNr, 1, 4);
            tlpPartNr.Controls.Add(btn_AddPrefabPartNr, 3, 4);
            tlpPartNr.Controls.Add(btn_RemovePrefabPartNr, 4, 4);
            tlpPartNr.Controls.Add(btn_AddPrefabDescription, 6, 4);
            tlpPartNr.Controls.Add(btn_RemovePrefabDescription, 7, 4);
            tlpPartNr.Dock = DockStyle.Fill;
            tlpPartNr.Location = new Point(5, 21);
            tlpPartNr.Name = "tlpPartNr";
            tlpPartNr.RowCount = 5;
            tlpPartNr.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpPartNr.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlpPartNr.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlpPartNr.RowStyles.Add(new RowStyle(SizeType.Absolute, 173F));
            tlpPartNr.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tlpPartNr.Size = new Size(1740, 276);
            tlpPartNr.TabIndex = 0;
            // 
            // label_FilterInfo_PartNumber
            // 
            tlpPartNr.SetColumnSpan(label_FilterInfo_PartNumber, 2);
            label_FilterInfo_PartNumber.Dock = DockStyle.Fill;
            label_FilterInfo_PartNumber.Font = new Font("Lucida Sans", 12F);
            label_FilterInfo_PartNumber.ForeColor = Color.FromArgb(187, 215, 228);
            label_FilterInfo_PartNumber.Location = new Point(3, 0);
            label_FilterInfo_PartNumber.Name = "label_FilterInfo_PartNumber";
            label_FilterInfo_PartNumber.Size = new Size(294, 20);
            label_FilterInfo_PartNumber.TabIndex = 0;
            label_FilterInfo_PartNumber.Text = "Filtrera ArtikelNummer";
            // 
            // label_FilterInfo_PreFab_PartNumber
            // 
            tlpPartNr.SetColumnSpan(label_FilterInfo_PreFab_PartNumber, 2);
            label_FilterInfo_PreFab_PartNumber.Dock = DockStyle.Fill;
            label_FilterInfo_PreFab_PartNumber.Font = new Font("Lucida Sans", 12F);
            label_FilterInfo_PreFab_PartNumber.ForeColor = Color.FromArgb(187, 215, 228);
            label_FilterInfo_PreFab_PartNumber.Location = new Point(418, 0);
            label_FilterInfo_PreFab_PartNumber.Name = "label_FilterInfo_PreFab_PartNumber";
            label_FilterInfo_PreFab_PartNumber.Size = new Size(294, 20);
            label_FilterInfo_PreFab_PartNumber.TabIndex = 1;
            label_FilterInfo_PreFab_PartNumber.Text = "Filtrera Halvfabrikat ArtikelNummer";
            // 
            // label_FilterInfo_PreFab_Description
            // 
            tlpPartNr.SetColumnSpan(label_FilterInfo_PreFab_Description, 2);
            label_FilterInfo_PreFab_Description.Dock = DockStyle.Fill;
            label_FilterInfo_PreFab_Description.Font = new Font("Lucida Sans", 12F);
            label_FilterInfo_PreFab_Description.ForeColor = Color.FromArgb(187, 215, 228);
            label_FilterInfo_PreFab_Description.Location = new Point(833, 0);
            label_FilterInfo_PreFab_Description.Name = "label_FilterInfo_PreFab_Description";
            label_FilterInfo_PreFab_Description.Size = new Size(394, 20);
            label_FilterInfo_PreFab_Description.TabIndex = 2;
            label_FilterInfo_PreFab_Description.Text = "Filtrera Halvfabrikat Benämning";
            // 
            // cb_WorkOperation
            // 
            tlpPartNr.SetColumnSpan(cb_WorkOperation, 2);
            cb_WorkOperation.Dock = DockStyle.Fill;
            cb_WorkOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_WorkOperation.FormattingEnabled = true;
            cb_WorkOperation.Location = new Point(3, 23);
            cb_WorkOperation.Name = "cb_WorkOperation";
            cb_WorkOperation.Size = new Size(294, 23);
            cb_WorkOperation.TabIndex = 3;
            // 
            // tb_FilterPartNr
            // 
            tlpPartNr.SetColumnSpan(tb_FilterPartNr, 2);
            tb_FilterPartNr.Dock = DockStyle.Fill;
            tb_FilterPartNr.Location = new Point(3, 51);
            tb_FilterPartNr.Name = "tb_FilterPartNr";
            tb_FilterPartNr.PlaceholderText = "Filtrera artikelnummer...";
            tb_FilterPartNr.Size = new Size(294, 23);
            tb_FilterPartNr.TabIndex = 4;
            // 
            // tb_FilterPrefabPartNr
            // 
            tlpPartNr.SetColumnSpan(tb_FilterPrefabPartNr, 2);
            tb_FilterPrefabPartNr.Dock = DockStyle.Fill;
            tb_FilterPrefabPartNr.Location = new Point(418, 51);
            tb_FilterPrefabPartNr.Name = "tb_FilterPrefabPartNr";
            tb_FilterPrefabPartNr.PlaceholderText = "Filtrerar Halvfabrikatets artikelnummer...";
            tb_FilterPrefabPartNr.Size = new Size(294, 23);
            tb_FilterPrefabPartNr.TabIndex = 5;
            // 
            // tb_FilterPrefabDescription
            // 
            tlpPartNr.SetColumnSpan(tb_FilterPrefabDescription, 2);
            tb_FilterPrefabDescription.Dock = DockStyle.Fill;
            tb_FilterPrefabDescription.Location = new Point(833, 51);
            tb_FilterPrefabDescription.Name = "tb_FilterPrefabDescription";
            tb_FilterPrefabDescription.PlaceholderText = "Filtrerar Halvfabrikatets benämning...";
            tb_FilterPrefabDescription.Size = new Size(394, 23);
            tb_FilterPrefabDescription.TabIndex = 6;
            // 
            // lb_PartNr
            // 
            lb_PartNr.BackColor = Color.FromArgb(25, 25, 25);
            lb_PartNr.Dock = DockStyle.Fill;
            lb_PartNr.ForeColor = Color.FromArgb(255, 235, 156);
            lb_PartNr.ItemHeight = 15;
            lb_PartNr.Location = new Point(3, 79);
            lb_PartNr.Name = "lb_PartNr";
            lb_PartNr.SelectionMode = SelectionMode.MultiExtended;
            lb_PartNr.Size = new Size(144, 167);
            lb_PartNr.TabIndex = 7;
            // 
            // lb_SelectedPartNr
            // 
            lb_SelectedPartNr.BackColor = Color.FromArgb(25, 25, 25);
            lb_SelectedPartNr.Dock = DockStyle.Fill;
            lb_SelectedPartNr.ForeColor = Color.FromArgb(198, 239, 206);
            lb_SelectedPartNr.ItemHeight = 15;
            lb_SelectedPartNr.Location = new Point(153, 79);
            lb_SelectedPartNr.Name = "lb_SelectedPartNr";
            lb_SelectedPartNr.SelectionMode = SelectionMode.MultiExtended;
            lb_SelectedPartNr.Size = new Size(144, 167);
            lb_SelectedPartNr.TabIndex = 8;
            // 
            // flpFilterAddActions
            // 
            flpFilterAddActions.AutoSize = true;
            flpFilterAddActions.Dock = DockStyle.Top;
            flpFilterAddActions.FlowDirection = FlowDirection.TopDown;
            flpFilterAddActions.Location = new Point(1348, 79);
            flpFilterAddActions.Name = "flpFilterAddActions";
            flpFilterAddActions.Size = new Size(389, 0);
            flpFilterAddActions.TabIndex = 15;
            flpFilterAddActions.WrapContents = false;
            // 
            // lb_PrefabPartNr
            // 
            lb_PrefabPartNr.BackColor = Color.FromArgb(25, 25, 25);
            lb_PrefabPartNr.Dock = DockStyle.Fill;
            lb_PrefabPartNr.ForeColor = Color.FromArgb(255, 235, 156);
            lb_PrefabPartNr.ItemHeight = 15;
            lb_PrefabPartNr.Location = new Point(418, 79);
            lb_PrefabPartNr.Name = "lb_PrefabPartNr";
            lb_PrefabPartNr.SelectionMode = SelectionMode.MultiExtended;
            lb_PrefabPartNr.Size = new Size(144, 167);
            lb_PrefabPartNr.TabIndex = 10;
            // 
            // lb_SelectedPrefabPartNr
            // 
            lb_SelectedPrefabPartNr.BackColor = Color.FromArgb(25, 25, 25);
            lb_SelectedPrefabPartNr.Dock = DockStyle.Fill;
            lb_SelectedPrefabPartNr.ForeColor = Color.FromArgb(198, 239, 206);
            lb_SelectedPrefabPartNr.ItemHeight = 15;
            lb_SelectedPrefabPartNr.Location = new Point(568, 79);
            lb_SelectedPrefabPartNr.Name = "lb_SelectedPrefabPartNr";
            lb_SelectedPrefabPartNr.SelectionMode = SelectionMode.MultiExtended;
            lb_SelectedPrefabPartNr.Size = new Size(144, 167);
            lb_SelectedPrefabPartNr.TabIndex = 11;
            // 
            // lb_PrefabDescription
            // 
            lb_PrefabDescription.BackColor = Color.FromArgb(25, 25, 25);
            lb_PrefabDescription.Dock = DockStyle.Fill;
            lb_PrefabDescription.ForeColor = Color.FromArgb(255, 235, 156);
            lb_PrefabDescription.ItemHeight = 15;
            lb_PrefabDescription.Location = new Point(833, 79);
            lb_PrefabDescription.Name = "lb_PrefabDescription";
            lb_PrefabDescription.SelectionMode = SelectionMode.MultiExtended;
            lb_PrefabDescription.Size = new Size(194, 167);
            lb_PrefabDescription.TabIndex = 12;
            // 
            // lb_SelectedPrefabDescription
            // 
            lb_SelectedPrefabDescription.BackColor = Color.FromArgb(25, 25, 25);
            lb_SelectedPrefabDescription.Dock = DockStyle.Fill;
            lb_SelectedPrefabDescription.ForeColor = Color.FromArgb(198, 239, 206);
            lb_SelectedPrefabDescription.ItemHeight = 15;
            lb_SelectedPrefabDescription.Location = new Point(1033, 79);
            lb_SelectedPrefabDescription.Name = "lb_SelectedPrefabDescription";
            lb_SelectedPrefabDescription.SelectionMode = SelectionMode.MultiExtended;
            lb_SelectedPrefabDescription.Size = new Size(194, 167);
            lb_SelectedPrefabDescription.TabIndex = 13;
            // 
            // btn_AddPartNr
            // 
            btn_AddPartNr.AutoSize = true;
            btn_AddPartNr.BackColor = Color.FromArgb(198, 239, 206);
            btn_AddPartNr.Dock = DockStyle.Left;
            btn_AddPartNr.FlatStyle = FlatStyle.Flat;
            btn_AddPartNr.Font = new Font("Segoe UI", 12F);
            btn_AddPartNr.ForeColor = Color.FromArgb(0, 97, 0);
            btn_AddPartNr.Location = new Point(3, 252);
            btn_AddPartNr.Name = "btn_AddPartNr";
            btn_AddPartNr.Size = new Size(30, 21);
            btn_AddPartNr.TabIndex = 0;
            btn_AddPartNr.Text = "+";
            btn_AddPartNr.UseCompatibleTextRendering = true;
            btn_AddPartNr.UseVisualStyleBackColor = false;
            // 
            // btn_RemovePartNr
            // 
            btn_RemovePartNr.BackColor = Color.FromArgb(255, 199, 206);
            btn_RemovePartNr.Dock = DockStyle.Left;
            btn_RemovePartNr.FlatStyle = FlatStyle.Flat;
            btn_RemovePartNr.Font = new Font("Segoe UI", 12F);
            btn_RemovePartNr.ForeColor = Color.FromArgb(156, 0, 6);
            btn_RemovePartNr.Location = new Point(153, 252);
            btn_RemovePartNr.Name = "btn_RemovePartNr";
            btn_RemovePartNr.Size = new Size(30, 21);
            btn_RemovePartNr.TabIndex = 8;
            btn_RemovePartNr.Text = "-";
            btn_RemovePartNr.UseCompatibleTextRendering = true;
            btn_RemovePartNr.UseVisualStyleBackColor = false;
            // 
            // btn_AddPrefabPartNr
            // 
            btn_AddPrefabPartNr.AutoSize = true;
            btn_AddPrefabPartNr.BackColor = Color.FromArgb(198, 239, 206);
            btn_AddPrefabPartNr.Dock = DockStyle.Left;
            btn_AddPrefabPartNr.FlatStyle = FlatStyle.Flat;
            btn_AddPrefabPartNr.Font = new Font("Segoe UI", 12F);
            btn_AddPrefabPartNr.ForeColor = Color.FromArgb(0, 97, 0);
            btn_AddPrefabPartNr.Location = new Point(418, 252);
            btn_AddPrefabPartNr.Name = "btn_AddPrefabPartNr";
            btn_AddPrefabPartNr.Size = new Size(30, 21);
            btn_AddPrefabPartNr.TabIndex = 1;
            btn_AddPrefabPartNr.Text = "+";
            btn_AddPrefabPartNr.UseCompatibleTextRendering = true;
            btn_AddPrefabPartNr.UseVisualStyleBackColor = false;
            // 
            // btn_RemovePrefabPartNr
            // 
            btn_RemovePrefabPartNr.BackColor = Color.FromArgb(255, 199, 206);
            btn_RemovePrefabPartNr.Dock = DockStyle.Left;
            btn_RemovePrefabPartNr.FlatStyle = FlatStyle.Flat;
            btn_RemovePrefabPartNr.Font = new Font("Segoe UI", 12F);
            btn_RemovePrefabPartNr.ForeColor = Color.FromArgb(156, 0, 6);
            btn_RemovePrefabPartNr.Location = new Point(568, 252);
            btn_RemovePrefabPartNr.Name = "btn_RemovePrefabPartNr";
            btn_RemovePrefabPartNr.Size = new Size(30, 21);
            btn_RemovePrefabPartNr.TabIndex = 11;
            btn_RemovePrefabPartNr.Text = "-";
            btn_RemovePrefabPartNr.UseCompatibleTextRendering = true;
            btn_RemovePrefabPartNr.UseVisualStyleBackColor = false;
            // 
            // btn_AddPrefabDescription
            // 
            btn_AddPrefabDescription.AutoSize = true;
            btn_AddPrefabDescription.BackColor = Color.FromArgb(198, 239, 206);
            btn_AddPrefabDescription.Dock = DockStyle.Left;
            btn_AddPrefabDescription.FlatStyle = FlatStyle.Flat;
            btn_AddPrefabDescription.Font = new Font("Segoe UI", 12F);
            btn_AddPrefabDescription.ForeColor = Color.FromArgb(0, 97, 0);
            btn_AddPrefabDescription.Location = new Point(833, 252);
            btn_AddPrefabDescription.Name = "btn_AddPrefabDescription";
            btn_AddPrefabDescription.Size = new Size(30, 21);
            btn_AddPrefabDescription.TabIndex = 2;
            btn_AddPrefabDescription.Text = "+";
            btn_AddPrefabDescription.UseCompatibleTextRendering = true;
            btn_AddPrefabDescription.UseVisualStyleBackColor = false;
            // 
            // btn_RemovePrefabDescription
            // 
            btn_RemovePrefabDescription.BackColor = Color.FromArgb(255, 199, 206);
            btn_RemovePrefabDescription.Dock = DockStyle.Left;
            btn_RemovePrefabDescription.FlatStyle = FlatStyle.Flat;
            btn_RemovePrefabDescription.Font = new Font("Segoe UI", 12F);
            btn_RemovePrefabDescription.ForeColor = Color.FromArgb(156, 0, 6);
            btn_RemovePrefabDescription.Location = new Point(1033, 252);
            btn_RemovePrefabDescription.Name = "btn_RemovePrefabDescription";
            btn_RemovePrefabDescription.Size = new Size(30, 21);
            btn_RemovePrefabDescription.TabIndex = 14;
            btn_RemovePrefabDescription.Text = "-";
            btn_RemovePrefabDescription.UseCompatibleTextRendering = true;
            btn_RemovePrefabDescription.UseVisualStyleBackColor = false;
            // 
            // flpActions
            // 
            flpActions.AutoSize = true;
            flpActions.Controls.Add(btnFetchData);
            flpActions.Controls.Add(lbl_Status);
            flpActions.Controls.Add(btn_ExportToCsv);
            flpActions.Controls.Add(btn_StopSearch);
            flpActions.Dock = DockStyle.Top;
            flpActions.Location = new Point(3, 672);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(1750, 45);
            flpActions.TabIndex = 3;
            // 
            // btnFetchData
            // 
            btnFetchData.AutoSize = true;
            btnFetchData.BackColor = Color.FromArgb(198, 239, 206);
            btnFetchData.FlatStyle = FlatStyle.Flat;
            btnFetchData.ForeColor = Color.FromArgb(0, 97, 0);
            btnFetchData.Location = new Point(3, 3);
            btnFetchData.Name = "btnFetchData";
            btnFetchData.Padding = new Padding(12, 6, 12, 6);
            btnFetchData.Size = new Size(105, 39);
            btnFetchData.TabIndex = 0;
            btnFetchData.Text = "Hämta data";
            btnFetchData.UseVisualStyleBackColor = false;
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.ForeColor = Color.DarkGray;
            lbl_Status.Location = new Point(114, 11);
            lbl_Status.Margin = new Padding(3, 11, 3, 0);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(0, 15);
            lbl_Status.TabIndex = 1;
            // 
            // btn_ExportToCsv
            // 
            btn_ExportToCsv.AutoSize = true;
            btn_ExportToCsv.BackColor = Color.FromArgb(184, 220, 231);
            btn_ExportToCsv.FlatStyle = FlatStyle.Flat;
            btn_ExportToCsv.ForeColor = Color.FromArgb(6, 81, 87);
            btn_ExportToCsv.Location = new Point(120, 3);
            btn_ExportToCsv.Name = "btn_ExportToCsv";
            btn_ExportToCsv.Padding = new Padding(12, 6, 12, 6);
            btn_ExportToCsv.Size = new Size(133, 39);
            btn_ExportToCsv.TabIndex = 2;
            btn_ExportToCsv.Text = "Exportera till CSV";
            btn_ExportToCsv.UseVisualStyleBackColor = false;
            // 
            // btn_StopSearch
            // 
            btn_StopSearch.AutoSize = true;
            btn_StopSearch.BackColor = Color.FromArgb(255, 199, 206);
            btn_StopSearch.FlatStyle = FlatStyle.Flat;
            btn_StopSearch.ForeColor = Color.FromArgb(156, 0, 6);
            btn_StopSearch.Location = new Point(259, 3);
            btn_StopSearch.Name = "btn_StopSearch";
            btn_StopSearch.Padding = new Padding(12, 6, 12, 6);
            btn_StopSearch.Size = new Size(90, 39);
            btn_StopSearch.TabIndex = 3;
            btn_StopSearch.Text = "Stoppa";
            btn_StopSearch.UseVisualStyleBackColor = false;
            // 
            // dgv_Result
            // 
            dgv_Result.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Result.Dock = DockStyle.Fill;
            dgv_Result.Location = new Point(3, 726);
            dgv_Result.Name = "dgv_Result";
            dgv_Result.Size = new Size(1750, 232);
            dgv_Result.TabIndex = 4;
            // 
            // ParameterDataSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1780, 985);
            Controls.Add(tlpMain);
            ForeColor = Color.Gainsboro;
            MinimumSize = new Size(1200, 700);
            Name = "ParameterDataSearch";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Analys av parameterdata";
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            gb_Parameters.ResumeLayout(false);
            tlpFilter.ResumeLayout(false);
            tlpFilter.PerformLayout();
            gb_Filter.ResumeLayout(false);
            tlpPartNr.ResumeLayout(false);
            tlpPartNr.PerformLayout();
            flpActions.ResumeLayout(false);
            flpActions.PerformLayout();
            ((ISupportInitialize)dgv_Result).EndInit();
            ResumeLayout(false);
        }

        private static void ConfigureHeaderLabel(Label label, string text)
        {
            label.AutoSize = true;
            label.Dock = DockStyle.Fill;
            label.Font = new Font("Lucida Sans", 12F);
            label.ForeColor = Color.FromArgb(187, 215, 228);
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleCenter;
        }

        private static void ConfigureSourceTextBox(TextBox textBox)
        {
            textBox.Dock = DockStyle.Fill;
            textBox.PlaceholderText = "text eller *text";
        }

        private static void ConfigureSourceListBox(ListBox listBox)
        {
            listBox.BackColor = Color.FromArgb(25, 25, 25);
            listBox.BorderStyle = BorderStyle.FixedSingle;
            listBox.Dock = DockStyle.Fill;
            listBox.ForeColor = Color.FromArgb(255, 235, 156);
            listBox.SelectionMode = SelectionMode.MultiExtended;
        }

        private static void ConfigureSelectedListBox(ListBox listBox)
        {
            listBox.BackColor = Color.FromArgb(25, 25, 25);
            listBox.BorderStyle = BorderStyle.FixedSingle;
            listBox.Dock = DockStyle.Fill;
            listBox.ForeColor = Color.FromArgb(198, 239, 206);
            listBox.SelectionMode = SelectionMode.MultiSimple;
        }

        private static void ConfigureRemoveButton(Button button, string text)
        {
            button.AutoSize = true;
            button.BackColor = Color.FromArgb(255, 199, 206);
            button.Dock = DockStyle.Fill;
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = Color.FromArgb(156, 0, 6);
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }
        private Button btn_ExportToCsv;
    }
}


