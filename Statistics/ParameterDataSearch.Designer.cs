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
        private ComboBox cb_WorkOperation;
        private ComboBox cb_MeasureTemplate;
        private ComboBox cb_ProtocolTemplate;
        private TextBox tb_FilterMeasurementParameters;
        private TextBox tb_FilterProtocolParameters;
        private TextBox tb_FilterPartNr;
        private TextBox tb_FilterPrefabPartNr;
        private ListBox lb_MeasureProtocolParameters;
        private ListBox lb_SelectedMeasureParameters;
        private ListBox lb_ProtocolParameters;
        private ListBox lb_SelectedProtocolParameters;
        private ListBox lb_PartNr;
        private ListBox lb_SelectedPartNr;
        private ListBox lb_PrefabPartNr;
        private ListBox lb_SelectedPrefabPartNr;
        private FlowLayoutPanel flpParameterAddActions;
        private FlowLayoutPanel flpFilterAddActions;
        private Button btn_AddMeasureParameter;
        private Button btn_AddOrder;
        private Button btn_AddPartNr;
        private Button btn_AddPrefabPartNr;
        private Button btn_RemoveMeasure;
        private Button btn_RemoveOrder;
        private Button btn_RemovePartNr;
        private Button btn_RemovePrefabPartNr;
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
            cb_WorkOperation = new ComboBox();
            tb_FilterPartNr = new TextBox();
            tb_FilterPrefabPartNr = new TextBox();
            lb_PartNr = new ListBox();
            lb_SelectedPartNr = new ListBox();
            flpFilterAddActions = new FlowLayoutPanel();
            lb_PrefabPartNr = new ListBox();
            lb_SelectedPrefabPartNr = new ListBox();
            btn_AddPartNr = new Button();
            btn_RemovePartNr = new Button();
            btn_AddPrefabPartNr = new Button();
            btn_RemovePrefabPartNr = new Button();
            tb_FilterRawMaterialPartNr = new TextBox();
            lb_RawMaterialPartNr = new ListBox();
            lb_SelectedRawMaterialPartNr = new ListBox();
            btn_AddRawMaterialPartNr = new Button();
            tb_FilterRawMaterialDescription = new TextBox();
            btn_RemoveRawMaterialDescription = new Button();
            lb_RawMaterialDescription = new ListBox();
            lb_SelectedRawMaterialDescription = new ListBox();
            btn_AddRawMaterialDescription = new Button();
            btn_RemoveRawMaterialPartNr = new Button();
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
            tlpMain.Size = new Size(1900, 961);
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
            lbl_Description.Size = new Size(1894, 45);
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
            gb_Parameters.Size = new Size(1894, 310);
            gb_Parameters.TabIndex = 1;
            gb_Parameters.TabStop = false;
            gb_Parameters.Text = "Parametrar";
            // 
            // tlpFilter
            // 
            tlpFilter.ColumnCount = 7;
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
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
            tlpFilter.Size = new Size(1884, 284);
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
            label_ProtocolParameters.Location = new Point(353, 0);
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
            cb_ProtocolTemplate.Location = new Point(353, 23);
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
            tb_FilterProtocolParameters.Location = new Point(353, 51);
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
            flpParameterAddActions.Location = new Point(868, 79);
            flpParameterAddActions.Name = "flpParameterAddActions";
            flpParameterAddActions.Size = new Size(1013, 0);
            flpParameterAddActions.TabIndex = 11;
            flpParameterAddActions.WrapContents = false;
            // 
            // lb_ProtocolParameters
            // 
            lb_ProtocolParameters.BackColor = Color.FromArgb(25, 25, 25);
            lb_ProtocolParameters.Dock = DockStyle.Fill;
            lb_ProtocolParameters.ForeColor = Color.FromArgb(255, 235, 156);
            lb_ProtocolParameters.ItemHeight = 15;
            lb_ProtocolParameters.Location = new Point(353, 79);
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
            lb_SelectedProtocolParameters.Location = new Point(553, 79);
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
            btn_AddOrder.Location = new Point(353, 258);
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
            btn_RemoveOrder.Location = new Point(553, 258);
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
            gb_Filter.Size = new Size(1894, 302);
            gb_Filter.TabIndex = 2;
            gb_Filter.TabStop = false;
            gb_Filter.Text = "Filter (valfritt)";
            // 
            // tlpPartNr
            // 
            tlpPartNr.ColumnCount = 16;
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlpPartNr.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPartNr.Controls.Add(cb_WorkOperation, 0, 1);
            tlpPartNr.Controls.Add(tb_FilterPartNr, 0, 2);
            tlpPartNr.Controls.Add(tb_FilterPrefabPartNr, 9, 2);
            tlpPartNr.Controls.Add(lb_PartNr, 0, 3);
            tlpPartNr.Controls.Add(lb_SelectedPartNr, 1, 3);
            tlpPartNr.Controls.Add(flpFilterAddActions, 15, 3);
            tlpPartNr.Controls.Add(lb_PrefabPartNr, 9, 3);
            tlpPartNr.Controls.Add(lb_SelectedPrefabPartNr, 10, 3);
            tlpPartNr.Controls.Add(btn_AddPartNr, 0, 4);
            tlpPartNr.Controls.Add(btn_RemovePartNr, 1, 4);
            tlpPartNr.Controls.Add(btn_AddPrefabPartNr, 9, 4);
            tlpPartNr.Controls.Add(btn_RemovePrefabPartNr, 10, 4);
            tlpPartNr.Controls.Add(tb_FilterRawMaterialPartNr, 3, 2);
            tlpPartNr.Controls.Add(lb_RawMaterialPartNr, 3, 3);
            tlpPartNr.Controls.Add(lb_SelectedRawMaterialPartNr, 4, 3);
            tlpPartNr.Controls.Add(btn_AddRawMaterialPartNr, 3, 4);
            tlpPartNr.Controls.Add(tb_FilterRawMaterialDescription, 6, 2);
            tlpPartNr.Controls.Add(btn_RemoveRawMaterialDescription, 7, 4);
            tlpPartNr.Controls.Add(lb_RawMaterialDescription, 6, 3);
            tlpPartNr.Controls.Add(lb_SelectedRawMaterialDescription, 7, 3);
            tlpPartNr.Controls.Add(btn_AddRawMaterialDescription, 6, 4);
            tlpPartNr.Controls.Add(btn_RemoveRawMaterialPartNr, 4, 4);
            tlpPartNr.Dock = DockStyle.Fill;
            tlpPartNr.Location = new Point(5, 21);
            tlpPartNr.Name = "tlpPartNr";
            tlpPartNr.RowCount = 5;
            tlpPartNr.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpPartNr.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlpPartNr.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlpPartNr.RowStyles.Add(new RowStyle(SizeType.Absolute, 173F));
            tlpPartNr.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tlpPartNr.Size = new Size(1884, 276);
            tlpPartNr.TabIndex = 0;
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
            tb_FilterPrefabPartNr.Location = new Point(1173, 51);
            tb_FilterPrefabPartNr.Name = "tb_FilterPrefabPartNr";
            tb_FilterPrefabPartNr.PlaceholderText = "Filtrerar på Halvfabrikatets Artikelnummer...";
            tb_FilterPrefabPartNr.Size = new Size(344, 23);
            tb_FilterPrefabPartNr.TabIndex = 5;
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
            flpFilterAddActions.Location = new Point(2043, 79);
            flpFilterAddActions.Name = "flpFilterAddActions";
            flpFilterAddActions.Size = new Size(1, 0);
            flpFilterAddActions.TabIndex = 15;
            flpFilterAddActions.WrapContents = false;
            // 
            // lb_PrefabPartNr
            // 
            lb_PrefabPartNr.BackColor = Color.FromArgb(25, 25, 25);
            lb_PrefabPartNr.Dock = DockStyle.Fill;
            lb_PrefabPartNr.ForeColor = Color.FromArgb(255, 235, 156);
            lb_PrefabPartNr.ItemHeight = 15;
            lb_PrefabPartNr.Location = new Point(1173, 79);
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
            lb_SelectedPrefabPartNr.Location = new Point(1323, 79);
            lb_SelectedPrefabPartNr.Name = "lb_SelectedPrefabPartNr";
            lb_SelectedPrefabPartNr.SelectionMode = SelectionMode.MultiExtended;
            lb_SelectedPrefabPartNr.Size = new Size(194, 167);
            lb_SelectedPrefabPartNr.TabIndex = 11;
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
            btn_AddPrefabPartNr.Location = new Point(1173, 252);
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
            btn_RemovePrefabPartNr.Location = new Point(1323, 252);
            btn_RemovePrefabPartNr.Name = "btn_RemovePrefabPartNr";
            btn_RemovePrefabPartNr.Size = new Size(30, 21);
            btn_RemovePrefabPartNr.TabIndex = 11;
            btn_RemovePrefabPartNr.Text = "-";
            btn_RemovePrefabPartNr.UseCompatibleTextRendering = true;
            btn_RemovePrefabPartNr.UseVisualStyleBackColor = false;
            // 
            // tb_FilterRawMaterialPartNr
            // 
            tlpPartNr.SetColumnSpan(tb_FilterRawMaterialPartNr, 2);
            tb_FilterRawMaterialPartNr.Dock = DockStyle.Fill;
            tb_FilterRawMaterialPartNr.Location = new Point(353, 51);
            tb_FilterRawMaterialPartNr.Name = "tb_FilterRawMaterialPartNr";
            tb_FilterRawMaterialPartNr.PlaceholderText = "Filtrerar Råmaterialets Artikelnummer...";
            tb_FilterRawMaterialPartNr.Size = new Size(294, 23);
            tb_FilterRawMaterialPartNr.TabIndex = 17;
            // 
            // lb_RawMaterialPartNr
            // 
            lb_RawMaterialPartNr.BackColor = Color.FromArgb(25, 25, 25);
            lb_RawMaterialPartNr.Dock = DockStyle.Fill;
            lb_RawMaterialPartNr.ForeColor = Color.FromArgb(255, 235, 156);
            lb_RawMaterialPartNr.ItemHeight = 15;
            lb_RawMaterialPartNr.Location = new Point(353, 79);
            lb_RawMaterialPartNr.Name = "lb_RawMaterialPartNr";
            lb_RawMaterialPartNr.SelectionMode = SelectionMode.MultiExtended;
            lb_RawMaterialPartNr.Size = new Size(144, 167);
            lb_RawMaterialPartNr.TabIndex = 18;
            // 
            // lb_SelectedRawMaterialPartNr
            // 
            lb_SelectedRawMaterialPartNr.BackColor = Color.FromArgb(25, 25, 25);
            lb_SelectedRawMaterialPartNr.Dock = DockStyle.Fill;
            lb_SelectedRawMaterialPartNr.ForeColor = Color.FromArgb(198, 239, 206);
            lb_SelectedRawMaterialPartNr.ItemHeight = 15;
            lb_SelectedRawMaterialPartNr.Location = new Point(503, 79);
            lb_SelectedRawMaterialPartNr.Name = "lb_SelectedRawMaterialPartNr";
            lb_SelectedRawMaterialPartNr.SelectionMode = SelectionMode.MultiExtended;
            lb_SelectedRawMaterialPartNr.Size = new Size(144, 167);
            lb_SelectedRawMaterialPartNr.TabIndex = 19;
            // 
            // btn_AddRawMaterialPartNr
            // 
            btn_AddRawMaterialPartNr.AutoSize = true;
            btn_AddRawMaterialPartNr.BackColor = Color.FromArgb(198, 239, 206);
            btn_AddRawMaterialPartNr.Dock = DockStyle.Left;
            btn_AddRawMaterialPartNr.FlatStyle = FlatStyle.Flat;
            btn_AddRawMaterialPartNr.Font = new Font("Segoe UI", 12F);
            btn_AddRawMaterialPartNr.ForeColor = Color.FromArgb(0, 97, 0);
            btn_AddRawMaterialPartNr.Location = new Point(353, 252);
            btn_AddRawMaterialPartNr.Name = "btn_AddRawMaterialPartNr";
            btn_AddRawMaterialPartNr.Size = new Size(30, 21);
            btn_AddRawMaterialPartNr.TabIndex = 20;
            btn_AddRawMaterialPartNr.Text = "+";
            btn_AddRawMaterialPartNr.UseCompatibleTextRendering = true;
            btn_AddRawMaterialPartNr.UseVisualStyleBackColor = false;
            // 
            // tb_FilterRawMaterialDescription
            // 
            tlpPartNr.SetColumnSpan(tb_FilterRawMaterialDescription, 2);
            tb_FilterRawMaterialDescription.Dock = DockStyle.Fill;
            tb_FilterRawMaterialDescription.Location = new Point(703, 51);
            tb_FilterRawMaterialDescription.Name = "tb_FilterRawMaterialDescription";
            tb_FilterRawMaterialDescription.PlaceholderText = "Filtrerar på Råmaterialets Benämning...";
            tb_FilterRawMaterialDescription.Size = new Size(414, 23);
            tb_FilterRawMaterialDescription.TabIndex = 5;
            // 
            // btn_RemoveRawMaterialDescription
            // 
            btn_RemoveRawMaterialDescription.BackColor = Color.FromArgb(255, 199, 206);
            btn_RemoveRawMaterialDescription.Dock = DockStyle.Left;
            btn_RemoveRawMaterialDescription.FlatStyle = FlatStyle.Flat;
            btn_RemoveRawMaterialDescription.Font = new Font("Segoe UI", 12F);
            btn_RemoveRawMaterialDescription.ForeColor = Color.FromArgb(156, 0, 6);
            btn_RemoveRawMaterialDescription.Location = new Point(923, 252);
            btn_RemoveRawMaterialDescription.Name = "btn_RemoveRawMaterialDescription";
            btn_RemoveRawMaterialDescription.Size = new Size(30, 21);
            btn_RemoveRawMaterialDescription.TabIndex = 11;
            btn_RemoveRawMaterialDescription.Text = "-";
            btn_RemoveRawMaterialDescription.UseCompatibleTextRendering = true;
            btn_RemoveRawMaterialDescription.UseVisualStyleBackColor = false;
            // 
            // lb_RawMaterialDescription
            // 
            lb_RawMaterialDescription.BackColor = Color.FromArgb(25, 25, 25);
            lb_RawMaterialDescription.Dock = DockStyle.Fill;
            lb_RawMaterialDescription.ForeColor = Color.FromArgb(255, 235, 156);
            lb_RawMaterialDescription.ItemHeight = 15;
            lb_RawMaterialDescription.Location = new Point(703, 79);
            lb_RawMaterialDescription.Name = "lb_RawMaterialDescription";
            lb_RawMaterialDescription.SelectionMode = SelectionMode.MultiExtended;
            lb_RawMaterialDescription.Size = new Size(214, 167);
            lb_RawMaterialDescription.TabIndex = 12;
            // 
            // lb_SelectedRawMaterialDescription
            // 
            lb_SelectedRawMaterialDescription.BackColor = Color.FromArgb(25, 25, 25);
            lb_SelectedRawMaterialDescription.Dock = DockStyle.Fill;
            lb_SelectedRawMaterialDescription.ForeColor = Color.FromArgb(198, 239, 206);
            lb_SelectedRawMaterialDescription.ItemHeight = 15;
            lb_SelectedRawMaterialDescription.Location = new Point(923, 79);
            lb_SelectedRawMaterialDescription.Name = "lb_SelectedRawMaterialDescription";
            lb_SelectedRawMaterialDescription.SelectionMode = SelectionMode.MultiExtended;
            lb_SelectedRawMaterialDescription.Size = new Size(194, 167);
            lb_SelectedRawMaterialDescription.TabIndex = 13;
            // 
            // btn_AddRawMaterialDescription
            // 
            btn_AddRawMaterialDescription.AutoSize = true;
            btn_AddRawMaterialDescription.BackColor = Color.FromArgb(198, 239, 206);
            btn_AddRawMaterialDescription.Dock = DockStyle.Left;
            btn_AddRawMaterialDescription.FlatStyle = FlatStyle.Flat;
            btn_AddRawMaterialDescription.Font = new Font("Segoe UI", 12F);
            btn_AddRawMaterialDescription.ForeColor = Color.FromArgb(0, 97, 0);
            btn_AddRawMaterialDescription.Location = new Point(703, 252);
            btn_AddRawMaterialDescription.Name = "btn_AddRawMaterialDescription";
            btn_AddRawMaterialDescription.Size = new Size(30, 21);
            btn_AddRawMaterialDescription.TabIndex = 23;
            btn_AddRawMaterialDescription.Text = "+";
            btn_AddRawMaterialDescription.UseCompatibleTextRendering = true;
            btn_AddRawMaterialDescription.UseVisualStyleBackColor = false;
            // 
            // btn_RemoveRawMaterialPartNr
            // 
            btn_RemoveRawMaterialPartNr.BackColor = Color.FromArgb(255, 199, 206);
            btn_RemoveRawMaterialPartNr.Dock = DockStyle.Left;
            btn_RemoveRawMaterialPartNr.FlatStyle = FlatStyle.Flat;
            btn_RemoveRawMaterialPartNr.Font = new Font("Segoe UI", 12F);
            btn_RemoveRawMaterialPartNr.ForeColor = Color.FromArgb(156, 0, 6);
            btn_RemoveRawMaterialPartNr.Location = new Point(503, 252);
            btn_RemoveRawMaterialPartNr.Name = "btn_RemoveRawMaterialPartNr";
            btn_RemoveRawMaterialPartNr.Size = new Size(30, 21);
            btn_RemoveRawMaterialPartNr.TabIndex = 11;
            btn_RemoveRawMaterialPartNr.Text = "-";
            btn_RemoveRawMaterialPartNr.UseCompatibleTextRendering = true;
            btn_RemoveRawMaterialPartNr.UseVisualStyleBackColor = false;
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
            flpActions.Size = new Size(1894, 45);
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
            dgv_Result.Size = new Size(1894, 232);
            dgv_Result.TabIndex = 4;
            dgv_Result.VirtualMode = true;
            // 
            // ParameterDataSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1924, 985);
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
        private TextBox tb_FilterRawMaterialPartNr;
        private ListBox lb_RawMaterialPartNr;
        private ListBox lb_SelectedRawMaterialPartNr;
        private TextBox tb_FilterRawMaterialDescription;
       
        private Button btn_RemoveRawMaterialDescription;
        private ListBox lb_RawMaterialDescription;
        private ListBox lb_SelectedRawMaterialDescription;
        private Button btn_AddRawMaterialPartNr;
        private Button btn_AddRawMaterialDescription;
        private Button btn_RemoveRawMaterialPartNr;
    }
}


