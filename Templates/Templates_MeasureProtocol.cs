using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.User;
using static DigitalProductionProgram.Templates.Templates_Protocol;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DigitalProductionProgram.Templates
{
    public partial class Templates_MeasureProtocol : Form
    {
        public static int TotalConnectedProcesscardsToTemplate
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT COUNT(*) FROM Processcard.MainData WHERE MeasureProtocolMainTemplateID = @maintemplateid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@maintemplateid", MainTemplate.ID);
                    var value = cmd.ExecuteScalar();
                    return value == null ? 0 : int.Parse(value.ToString() ?? string.Empty);
                }

            }
        }
        public static int TotalConnectedOrdersToTemplate
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT COUNT(*) FROM [Order].MainData WHERE MeasureProtocolMainTemplateID = @maintemplateid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@maintemplateid", MainTemplate.ID);
                    var value = cmd.ExecuteScalar();
                    return value == null ? 0 : int.Parse(value.ToString() ?? string.Empty);
                }

            }
        }

        private bool IsLoading = true;

        public static List<string> List_TemplateNames = new List<string>();
        public static List<string> List_RevisionNr = new List<string>();
        public static List<int> List_MeasureProtocolMainTemplateID = new List<int>();

        public static class TemplateState
        {
            private static bool _isOkUpdateTemplate;
            public static bool IsOkUpdateTemplate
            {
                get => _isOkUpdateTemplate;
                set
                {
                    _isOkUpdateTemplate = value;
                    OnUpdateTemplateModeChanged?.Invoke(value);
                }
            }

            public static event Action<bool>? OnUpdateTemplateModeChanged;

        }


        private bool IsNewRevisionSet = true;
        private bool IsOkSaveTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(cb_Revision.Text))
                {
                    InfoText.Show("Fyll i mallens RevisionsNr före du sparar mallen för Mätprotokoll.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return false;
                }

                if (string.IsNullOrEmpty(cb_TemplateName.Text))
                {
                    InfoText.Show("Du måste välja en Protokoll-Mall före du försöker spara mallen för Mätprotokoll.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return false;
                }

                if (string.IsNullOrEmpty(cb_Workoperation.Text))
                {
                    InfoText.Question("Du har inte valt någon arbetsoperation.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return false;
                }

                foreach (DataGridViewRow row in dgv_Template.Rows)
                {
                    if (row.Cells["col_DataType"].Value == null || string.IsNullOrEmpty(row.Cells["col_DataType"].Value.ToString()))
                    {
                        InfoText.Show("Du måste fylla i Datatyp för alla Parametrar före du sparar/uppdaterar mallen.", CustomColors.InfoText_Color.Bad, "Warning");
                        return false;
                    }

                    if (row.Cells["col_ControlType"].Value == null || string.IsNullOrEmpty(row.Cells["col_ControlType"].Value.ToString()))
                    {
                        InfoText.Show("Du måste fylla i typ av inmatningskontroll för alla Parametrar före du sparar/uppdaterar mallen.", CustomColors.InfoText_Color.Bad, "Warning");
                        return false;
                    }

                }

                if (IsNewRevisionSet)
                    return true;

                if (TemplateState.IsOkUpdateTemplate == false)
                {
                    InfoText.Show("Du har gjort ändringar i mallen som kräver en ny Revision av Mallen.", CustomColors.InfoText_Color.Bad, "Warning", this);
                    return false;
                }

                return true;
            }
        }


        public Templates_MeasureProtocol()
        {
            Order.Save_TempOrderInfo();
            InitializeComponent();
            MainTemplate.SetNew_MainTemplateID();

            cb_TemplateName.SelectedIndexChanged -= Template_Name_SelectedIndexChanged;

            Fill_MeasureProtocolTemplate_Names();
            cb_Workoperation.DataSource = Manage_WorkOperation.WorkOperation.Description;
            cb_Workoperation.SelectedIndex = -1;
            Load_PDF();

            cb_TemplateName.SelectedIndexChanged += Template_Name_SelectedIndexChanged;
        }
        private void Templates_MeasureProtocol_Load(object sender, EventArgs e)
        {
            TemplateState.OnUpdateTemplateModeChanged += UpdateSaveButtonText;
            UpdateSaveButtonText(TemplateState.IsOkUpdateTemplate); // Initial state

            Parameters.Load(dgv_Parameters);

            var comboBoxColumn = (DataGridViewComboBoxColumn)dgv_Template.Columns["col_DataType"];
            comboBoxColumn.DataSource = Database.datatype;
            comboBoxColumn.DisplayMember = "Name";
            comboBoxColumn.ValueMember = "ID";

            comboBoxColumn = (DataGridViewComboBoxColumn)dgv_Template.Columns["col_ControlType"];
            comboBoxColumn.DataSource = ControlManager.ControlTypes;
            comboBoxColumn.DisplayMember = "Name";
            comboBoxColumn.ValueMember = "Name";

            cb_Monitor_MeasuringTemplate.DataSource = Monitor.Monitor.DataTable_MeasuringTemplates;
            cb_Monitor_MeasuringTemplate.DisplayMember = "Description";
            cb_Monitor_MeasuringTemplate.ValueMember = "FormTemplateId";
            cb_Monitor_MeasuringTemplate.SelectedIndex = -1;
        }

        private void Fill_MeasureProtocolTemplate_Names()
        {
            cb_TemplateName.SelectedIndexChanged -= Template_Name_SelectedIndexChanged;
            cb_TemplateName.Items.Clear();
            List_TemplateNames.Clear();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                WITH LatestRevisions AS 
                (
                    SELECT 
                        Name,
                        Revision,
                        MeasureProtocolMainTemplateID,
                        ROW_NUMBER() OVER (PARTITION BY Name ORDER BY Revision DESC) AS rn
                    FROM 
                    MeasureProtocol.MainTemplate
                )
                SELECT 
                    Name,
                    MeasureProtocolMainTemplateID
                FROM 
                LatestRevisions
                WHERE rn = 1
                ORDER BY Name";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cb_TemplateName.Items.Add(reader.GetString(0));
                    List_TemplateNames.Add(reader.GetString(0));
                    List_MeasureProtocolMainTemplateID.Add(int.Parse(reader["MeasureProtocolMainTemplateID"].ToString()));
                }
            }

            cb_TemplateName.SelectedIndexChanged += Template_Name_SelectedIndexChanged;
        }


        private void Load_PDF()
        {
            var filePath = Path.Combine(Path.GetTempPath(), "Guide - MeasureprotocolTemplates.pdf");
            File.WriteAllBytes(filePath, Properties.Resources.GuideMeasureprotocolTemplates);
            web_PDF_Viewer.Navigate(filePath); // Load the PDF into the WebBrowser control
        }
        private void LoadData()
        {
            IsLoading = true;
            dgv_Template.Rows.Clear();
            var parameterValues = new Dictionary<int, string>();

            using (var con = new SqlConnection(Database.cs_Protocol))
            using (var cmd = new SqlCommand(@"
       SELECT 
            DescriptionID,
            Parameter_UserText, 
            Parameter_Monitor, 
            ColumnWidth,   
            IsList,
            IsMandatory,
            Formula,
            DataType, 
            ControlType,
            ColumnIndex,
            Increment,
            Decimals, 
            MaxChars,
            maintemplate.MeasureProtocolMainTemplateID,
            maintemplate.MeasureProtocolTemplate_Monitor,
            maintemplate.IsAmountEditable,
            maintemplate.IsExtraInputBoxesEnabled,
            maintemplate.IsExtraInputBoxes_2Layer,
            maintemplate.IsExtraInputBoxes_SecondMeasurement,
            maintemplate.IsExtraFieldForCutterEnabled,
            workoperation.Description,
            CreatedBy,
            CreatedDate
        FROM  MeasureProtocol.MainTemplate AS maintemplate
        LEFT JOIN MeasureProtocol.Template AS template
            ON template.MeasureProtocolMainTemplateID = maintemplate.MeasureProtocolMainTemplateID
        LEFT JOIN Workoperation.Names as workoperation
            ON workoperation.ID = maintemplate.WorkoperationID
        WHERE maintemplate.Name = @name
            AND maintemplate.Revision = @revision
        ORDER BY template.ColumnIndex", con))
            {
                cmd.Parameters.AddWithValue("@name", cb_TemplateName.Text);
                cmd.Parameters.AddWithValue("@revision", cb_Revision.Text);
                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var isFirstRow = true; // Track the first row

                    while (reader.Read())
                    {
                        if (isFirstRow)
                        {
                            MainTemplate.ID = reader["MeasureProtocolMainTemplateID"] is DBNull
                                ? null
                                : (int?)Convert.ToInt32(reader["MeasureProtocolMainTemplateID"]);
                            lbl_CreatedBy.Text = reader["CreatedBy"].ToString();
                            lbl_CreatedDate.Text = GetFormattedDate(reader["CreatedDate"]);
                            cb_Monitor_MeasuringTemplate.Text = reader["MeasureProtocolTemplate_Monitor"].ToString();
                            chb_EditAmount.Checked = bool.TryParse(reader["IsAmountEditable"].ToString(), out var isAmountEditable) && isAmountEditable;
                            chb_ExtraInputBoxes.Checked = bool.TryParse(reader["IsExtraInputBoxesEnabled"].ToString(), out var isExtraInputBoxes) && isExtraInputBoxes;
                            chb_ExtraInputBoxes_2Layer.Checked = bool.TryParse(reader["IsExtraInputBoxes_2Layer"].ToString(), out var isExtraInputBoxes_2Layer) && isExtraInputBoxes_2Layer;
                            chb_ExtraInputBoxes_Second_Measurement.Checked = bool.TryParse(reader["IsExtraInputBoxes_SecondMeasurement"].ToString(), out var isExtraInputBoxes_SecondMeasurement) && isExtraInputBoxes_SecondMeasurement;
                            chb_IsUsingCutterTakeUpUnit.Checked = bool.TryParse(reader["IsExtraFieldForCutterEnabled"].ToString(), out var isExtraFieldCutter) && isExtraFieldCutter;

                            cb_Workoperation.SelectedItem = reader["Description"].ToString();
                            isFirstRow = false;
                        }

                        if (int.TryParse(reader["ColumnIndex"].ToString(), out var columnIndex) == false)
                            continue;
                        var rowIndex = dgv_Template.Rows.Add();
                        var row = dgv_Template.Rows[rowIndex];

                        var parameterUserText = reader["Parameter_UserText"].ToString();

                        parameterValues[columnIndex] = parameterUserText;
                        row.Cells["col_DescriptionID"].Value = reader["DescriptionID"];
                        row.Cells["col_Parameter"].Value = reader["Parameter_UserText"];
                        row.Cells["col_Formula"].Value = reader["Formula"];
                        row.Cells["col_ParameterMonitor"].Value = GetValue(reader, "Parameter_Monitor");
                        row.Cells["col_Items"].Value = GetBooleanValue(reader, "IsList");
                        row.Cells["col_IsMandatory"].Value = GetBooleanValue(reader, "IsMandatory");
                        row.Cells["col_DataType"].Value = GetIntValue(reader, "DataType");
                        row.Cells["col_ControlType"].Value = reader["ControlType"];
                        row.Cells["col_Increment"].Value = reader["Increment"];
                        row.Cells["col_Width"].Value = GetIntValue(reader, "ColumnWidth");
                        row.Cells["col_Decimals"].Value = GetIntValue(reader, "Decimals");
                        row.Cells["col_MaxChars"].Value = GetIntValue(reader, "MaxChars");
                    }
                }
            }
            foreach (DataGridViewRow row in dgv_Template.Rows)
            {
                if (row.Cells["col_Formula"].Value != null)
                {
                    var formula = row.Cells["col_Formula"].Value.ToString();
                    var evaluatedFormula = EvaluateFormula(formula, parameterValues);
                    row.Cells["col_Formula"].Value = evaluatedFormula;
                }
            }
            IsLoading = false;
            TemplateState.IsOkUpdateTemplate = true;
            IsNewRevisionSet = false;

            label_TotalConnectedProcesscards.Text = $"Antal Processkort kopplade till mallen: {TotalConnectedProcesscardsToTemplate}";
            label_TotalConnectedOrders.Text = $"Antal Ordrar kopplade till mallen: {TotalConnectedOrdersToTemplate}";
        }

        private static string EvaluateFormula(string formula, Dictionary<int, string> parameterValues)
        {
            foreach (var kvp in parameterValues)
                if (string.IsNullOrEmpty(formula) == false)
                    formula = formula.Replace($"[{kvp.Key}]", $"[{kvp.Value}]");

            return formula;
        }
        private static string GetFormattedDate(object dateValue)
        {
            return DateTime.TryParse(dateValue?.ToString(), out var dateTime)
                ? dateTime.ToString(CultureInfo.CurrentCulture)
                : string.Empty;
        }
        private static object GetValue(SqlDataReader reader, string columnName)
        {
            return reader[columnName] != DBNull.Value ? reader[columnName] : null;
        }
        private static object GetIntValue(SqlDataReader reader, string columnName)
        {
            return int.TryParse(reader[columnName]?.ToString(), out var result) ? result : (object)null;
        }
        private static object GetBooleanValue(SqlDataReader reader, string columnName)
        {
            return bool.TryParse(reader[columnName]?.ToString(), out var result) ? result : (object)null;
        }
        private void UpdateSaveButtonText(bool isUpdateMode)
        {
            btn_SaveTemplate.Text = isUpdateMode ? "Uppdatera Mall" : "Spara Mall";
        }

        private void Revision_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Save_Template_Click(object sender, EventArgs e)
        {
            if (IsOkSaveTemplate == false)
                return;

            if (TemplateState.IsOkUpdateTemplate == false)
            {
                var totalConnectedProcesscardsToTemplate = TotalConnectedProcesscardsToTemplate;
                var totalConnectedOrdersToTemplate = TotalConnectedOrdersToTemplate;
                if (totalConnectedProcesscardsToTemplate > 1)
                {
                    InfoText.Show($"Denna mall har {totalConnectedProcesscardsToTemplate} processkort kopplat till sig och kan inte längre uppdateras. Du måste nu skapa en ny revision.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return;
                }

                if (totalConnectedOrdersToTemplate > 1)
                {
                    InfoText.Show($"Denna mall har {totalConnectedOrdersToTemplate} ordrar kopplade till sig och kan inte längre uppdateras. Du måste nu skapa en ny revision.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return;
                }
            }

            MainTemplate.Name = cb_TemplateName.Text;
            MainTemplate.Revision = cb_Revision.Text;
            MainTemplate.TemplateMonitor = cb_Monitor_MeasuringTemplate.Text;
            MainTemplate.IsAmountEditable = chb_EditAmount.Checked;
            MainTemplate.IsExtraInputBoxesEnabled = chb_ExtraInputBoxes.Checked;
            MainTemplate.IsExtraInputBoxes_2Layer = chb_ExtraInputBoxes_2Layer.Checked;
            MainTemplate.IsExtraInputBoxes_SecondMeasurement = chb_ExtraInputBoxes_Second_Measurement.Checked;
            MainTemplate.IsExtraFieldForCutterEnabled = chb_IsUsingCutterTakeUpUnit.Checked;
            MainTemplate.Workoperation = cb_Workoperation.Text;
            MainTemplate.Save_Data();
            Template.Update_Data(dgv_Template);


            InfoText.Question("" +
                              $"Den nya mallen {cb_TemplateName.Text} är nu sparad och är nu klar att börja skapa nya processkort för.\n" +
                              "Vill du koppla gamla artikelnummer till den nya mallen?\n" +
                              "Om du svarar 'Ja' så öppnas ett nytt formulär där du får välja vilka artiklar som skall kopplas om",
                CustomColors.InfoText_Color.Info, null, this);

            Fill_MeasureProtocolTemplate_Names();

            //LoadData();
        }
        private void Delete_Template_Click(object sender, EventArgs e)
        {
            //var total = 0;
            //if (Template_Management.TemplateControls.Protocol.IsTemplateConnectedToProcesscard(ref total))
            //{
            //    InfoText.Show($"Denna mall har {total} processkort kopplat till sig och kan inte raderas, kontakta admin vid problem", CustomColors.InfoText_Color.Bad, "Warning!", this);
            //    return;
            //}
            //if (Template_Management.TemplateControls.Protocol.IsTemplateConnectedToOrderNr(ref total))
            //{
            //    InfoText.Show($"Denna mall har {total} ordrar kopplade till sig och kan inte längre uppdateras. Du måste nu skapa en ny revision.", CustomColors.InfoText_Color.Bad, "Warning!", this);
            //    return;
            //}
            ////Template_Management.TemplateControls.Delete_Template(cb_TemplateName.Text, cb_Revision.Text, true);
            //Fill_MainTemplate_Names();
            //cb_TemplateName.SelectedIndex = -1;

        }

        private void ConnectPartNr_NewTemplate_Click(object sender, EventArgs e)
        {
            var partsManager = new Connect_Templates(cb_TemplateName.Text, cb_Revision.Text, false, Connect_Templates.SourceType.Type_MeasureProtocols);
            partsManager.ShowDialog();
        }







        private void Parameters_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var parameter = dgv_Parameters.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            var descriptionid = dgv_Parameters.Rows[e.RowIndex].Cells[0].Value.ToString();
            //if (TemplateControls.IsCodeTextExistInModule(dgv_ProtocolsActive_Main, codetext))
            //    return;
            dgv_Template.Rows.Add();
            dgv_Template.Rows[dgv_Template.Rows.Count - 1].Cells["col_DescriptionID"].Value = descriptionid;
            dgv_Template.Rows[dgv_Template.Rows.Count - 1].Cells["col_Parameter"].Value = parameter;
            tb_AddNewParameter.Text = string.Empty;

            TemplateState.IsOkUpdateTemplate = false;
        }

        private void Template_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.IsCurrentCellDirty)
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void Template_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Template.Columns["col_DataType"] is null || dgv_Template.Columns["col_ControlType"] is null || e.RowIndex < 0)
                return;
            int.TryParse(dgv_Template.Rows[e.RowIndex].Cells["col_DescriptionID"].Value.ToString(), out var descriptionID);
            var cellParameter = dgv_Template.Rows[e.RowIndex].Cells["col_Parameter"];
            var cellParameterMonitor = dgv_Template.Rows[e.RowIndex].Cells["col_ParameterMonitor"];
            var ColumnName = dgv_Template.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            var cellDataType = dgv_Template.Rows[e.RowIndex].Cells["col_DataType"];
            var cellControlType = dgv_Template.Rows[e.RowIndex].Cells["col_ControlType"];
            var cellIncrement = dgv_Template.Rows[e.RowIndex].Cells["col_Increment"];
            var cellDecimals = dgv_Template.Rows[e.RowIndex].Cells["col_Decimals"];
            var cellItems = dgv_Template.Rows[e.RowIndex].Cells["col_Items"];
            var cellFormula = dgv_Template.Rows[e.RowIndex].Cells["col_Formula"];
            dgv_Template.CellValueChanged -= Template_CellValueChanged;
            switch (ColumnName)
            {
                case "col_ParameterMonitor":
                    switch (cellParameterMonitor.EditedFormattedValue.ToString())
                    {
                        case "Bag":
                            cellControlType.Value = "NumericUpDown";
                            cellDataType.Value = "Numeric";
                            cellDecimals.Value = null;
                            cellControlType.ReadOnly = cellDecimals.ReadOnly = true;
                            cellDecimals.Style.BackColor = Color.LightGray;
                            break;
                        default:
                            cellControlType.ReadOnly = cellDataType.ReadOnly = cellDecimals.ReadOnly = false;
                            cellControlType.Style.BackColor = cellDataType.Style.BackColor = cellDecimals.Style.BackColor = Color.White;
                            break;
                    }
                    break;
                case ("col_DataType"):
                    TemplateState.IsOkUpdateTemplate = false;
                    switch (cellDataType.EditedFormattedValue.ToString())
                    {
                        case "Bool":
                            cellControlType.Value = "CheckBox";
                            cellIncrement.ReadOnly = cellControlType.ReadOnly = cellDecimals.ReadOnly = true;
                            cellIncrement.Value = null;
                            cellIncrement.Style.BackColor = cellDecimals.Style.BackColor = cellControlType.Style.BackColor = cellFormula.Style.BackColor = Color.LightGray;
                            break;
                        case "Numeric":
                            cellControlType.ReadOnly = false;
                            cellDecimals.ReadOnly = false;
                            cellDecimals.Style.BackColor = cellControlType.Style.BackColor = cellFormula.Style.BackColor = Color.White;
                            break;
                        case "Text":
                            cellDecimals.ReadOnly = true;
                            cellDecimals.Style.BackColor = cellFormula.Style.BackColor = Color.LightGray;
                            break;
                        // goto EndSwitch;
                        default:
                            cellControlType.ReadOnly = false;
                            cellDecimals.ReadOnly = false;
                            cellFormula.Style.BackColor = Color.LightGray;
                            cellDecimals.Style.BackColor = cellControlType.Style.BackColor = Color.White;
                            break;
                    }
                    break;

                case "col_ControlType":
                    TemplateState.IsOkUpdateTemplate = false;
                    switch (cellControlType.EditedFormattedValue.ToString())
                    {
                        case "NumericUpDown":
                            cellDecimals.ReadOnly = cellFormula.ReadOnly = true;
                            cellDecimals.Style.BackColor = Color.LightGray;
                            cellDecimals.Value = null;
                            cellIncrement.ReadOnly = false;
                            cellIncrement.Style.BackColor = Color.White;
                            break;
                        case "CheckBox":
                            cellDataType.Value = "Bool";
                            cellDecimals.ReadOnly = cellIncrement.ReadOnly = true;
                            cellDecimals.Style.BackColor = cellIncrement.Style.BackColor = Color.LightGray;
                            cellDecimals.Value = null;
                            break;
                        case "TextBox":
                            if (cellDataType.EditedFormattedValue.ToString() == "Text")
                            {
                                cellDecimals.ReadOnly = true;
                                cellDecimals.Style.BackColor = Color.LightGray;
                                break;
                            }
                            cellFormula.ReadOnly = cellDecimals.ReadOnly = false;
                            cellIncrement.ReadOnly = true;
                            cellIncrement.Style.BackColor = Color.LightGray;
                            cellIncrement.Value = null;
                            cellDecimals.Style.BackColor = cellFormula.Style.BackColor = Color.White;
                            break;
                        default:
                            cellDecimals.ReadOnly = cellIncrement.ReadOnly = false;
                            cellDecimals.Style.BackColor = cellIncrement.Style.BackColor = Color.White;
                            break;
                    }
                    break;

                case "col_Items":
                    if (cellItems.Value != null && bool.TryParse(cellItems.Value.ToString(), out var isChecked) && IsLoading == false)
                    {
                        if (isChecked)
                        {
                            cellControlType.Value = "TextBox";
                            cellDataType.Value = "Text";
                            cellControlType.ReadOnly = cellDataType.ReadOnly = true;
                            cellControlType.Style.BackColor = cellDataType.Style.BackColor = Color.LightGray;

                            var itemsBuilder = new ItemsBuilder(cellParameter?.Value.ToString() ?? string.Empty, descriptionID);
                            itemsBuilder.ShowDialog();
                        }
                        else
                        {
                            cellControlType.ReadOnly = cellDataType.ReadOnly = false;
                            cellControlType.Style.BackColor = cellDataType.Style.BackColor = Color.White;
                        }
                    }
                    break;
            }
            dgv_Template.CellValueChanged += Template_CellValueChanged;
        }
        
        private void Template_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var cellParameter = dgv_Template.Rows[e.RowIndex].Cells["col_Parameter"];
            var activeParameter = cellParameter.Value.ToString();
            var ColumnName = dgv_Template.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            var cellFormula = dgv_Template.Rows[e.RowIndex].Cells["col_Formula"];
            if (ColumnName != "col_Formula")
                return;
            //if (cellFormula.Style.BackColor != Color.White)
            //    return;
            var dataTable = new DataTable();
            dataTable.Columns.Add("Parameter", typeof(string));
            dataTable.Columns.Add("ParameterMonitor", typeof(string));
            foreach (DataGridViewRow row in dgv_Template.Rows)
            {
                if (row.Cells["col_DataType"].EditedFormattedValue.ToString() == "Numeric")
                {
                    var parameter = row.Cells["col_Parameter"].EditedFormattedValue.ToString();
                    var parameterMonitor = row.Cells["col_ParameterMonitor"].EditedFormattedValue.ToString();
                    dataTable.Rows.Add(parameter, parameterMonitor);
                }

            }

            var formulaValue = new FormulaBuilder(activeParameter, dataTable);
            formulaValue.ShowDialog();
            cellFormula.Value = formulaValue.Formula;
        }

        private void CodeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            var key = e.KeyChar;
            foreach (DataGridViewRow row in dgv_Parameters.Rows)
            {
                if (row.Cells[1].Value.ToString().StartsWith(key.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    row.Selected = true;
                    dgv_Parameters.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }
        private void ExtraInputBoxes_CheckedChanged(object sender, EventArgs e)
        {
            chb_ExtraInputBoxes_2Layer.Visible = chb_ExtraInputBoxes_Second_Measurement.Visible = chb_ExtraInputBoxes.Checked;
        }
        private void DeleteTask_Click(object sender, EventArgs e)
        {
            dgv_Template.Rows.RemoveAt(dgv_Template.CurrentCell.RowIndex);
            TemplateState.IsOkUpdateTemplate = false;
        }
        private void MoveTaskUp_Click(object sender, EventArgs e)
        {
            var row = dgv_Template.CurrentCell.RowIndex;
            var rowToMove = dgv_Template.Rows[row];
            if (row > 0)
            {
                dgv_Template.Rows.RemoveAt(row);
                dgv_Template.Rows.Insert(row - 1, rowToMove);
                dgv_Template.CurrentCell = dgv_Template.Rows[row - 1].Cells[1];
                TemplateState.IsOkUpdateTemplate = false;
            }
        }
        private void MoveTaskDown_Click(object sender, EventArgs e)
        {
            var row = dgv_Template.CurrentCell.RowIndex;
            var rowToMove = dgv_Template.Rows[row];
            if (row < dgv_Template.Rows.Count - 1)
            {
                dgv_Template.Rows.RemoveAt(row);
                dgv_Template.Rows.Insert(row + 1, rowToMove);
                dgv_Template.CurrentCell = dgv_Template.Rows[row + 1].Cells[1];
                TemplateState.IsOkUpdateTemplate = false;
            }
        }


        private void Template_Name_SelectedIndexChanged(object? sender, EventArgs e)
        {
            cb_Revision.SelectedIndexChanged -= Template_RevisionNr_SelectedIndexChanged;

            Fill_Template_RevisionNr();
            dgv_Parameters.Visible = true;

            LoadData();
            cb_Revision.SelectedIndexChanged += Template_RevisionNr_SelectedIndexChanged;
        }
        private void TemplateName_TextChanged(object sender, EventArgs e)
        {

        }
        private void Monitor_MeasuringTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Monitor_MeasuringTemplate.SelectedIndex <= 0) return;
            var combobBoxColumn = (DataGridViewComboBoxColumn)dgv_Template.Columns["col_ParameterMonitor"];
            int.TryParse(cb_Monitor_MeasuringTemplate.SelectedValue.ToString(), out var value);
            var list = Monitor.Monitor.List_MonitorParameters(value);
            combobBoxColumn.DataSource = list;
        }
        private void NewRevision_MouseDown(object sender, MouseEventArgs e)
        {
            //TemplateState.IsOkUpdateTemplate = false;
            if (e.Button == MouseButtons.Left)
                cb_Revision.Text = ControlValidator.Next_Letter(cb_Revision.Text, true);
            else
            {
                if (cb_Revision.Text != MainTemplate.Revision)
                    cb_Revision.Text = ControlValidator.Next_Letter(cb_Revision.Text, false);
            }
            MainTemplate.SetNew_MainTemplateID();
            IsNewRevisionSet = true;

            TemplateState.IsOkUpdateTemplate = cb_Revision.Text == MainTemplate.Revision;
        }
        private void Template_RevisionNr_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainTemplate.Revision = cb_Revision.Text;
            if (TemplateState.IsOkUpdateTemplate == false)
            {
                InfoText.Question("Är du säker på att du vill ladda om mallen? Dina aktiva ändringar kommer att försvinna.", CustomColors.InfoText_Color.Warning, "Warning!", this);
                if (InfoText.answer == InfoText.Answer.No)
                    return;
            }

            LoadData();
        }
        private void Template_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false; // Prevent the default error dialog
        }
        private void AddNewParameter_TextChanged(object sender, EventArgs e)
        {
            var filterCondition = $"[CodeName] LIKE '%{tb_AddNewParameter.Text}%' ";
            Parameters.dt_Parameters.DefaultView.RowFilter = filterCondition;
        }


        private void Fill_Template_RevisionNr()
        {
            cb_TemplateName.SelectedIndexChanged -= Template_Name_SelectedIndexChanged;
            cb_Revision.Items.Clear();
            List_RevisionNr.Clear();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                SELECT DISTINCT Revision
                FROM Measureprotocol.MainTemplate
                WHERE Name = @name";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@name", cb_TemplateName.Text);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cb_Revision.Items.Add(reader.GetString(0));
                    List_RevisionNr.Add(reader.GetString(0));
                }
            }

            cb_TemplateName.SelectedIndexChanged += Template_Name_SelectedIndexChanged;
            cb_Revision.SelectedIndex = cb_Revision.Items.Count - 1;
            MainTemplate.Revision = cb_Revision.Text;
        }
        private void Manage_Templates_FormClosed(object sender, FormClosedEventArgs e)
        {
            Order.Restore_TempOrderInfo();
        }


        public class Parameters
        {
            public static DataTable dt_Parameters;
            public static void Load(DataGridView dgv)
            {
                dt_Parameters = new DataTable();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT ID, CodeName FROM MeasureProtocol.Description ORDER BY CodeName";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    var dataAdapter = new SqlDataAdapter(query, con);
                    dataAdapter.Fill(dt_Parameters);
                    dgv.DataSource = dt_Parameters;
                }

                dgv.Columns[1].FillWeight = 100;
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns[0].Visible = false;
            }
        }


        public class MainTemplate
        {
            internal static string? Name { get; set; }
            public static int? ID { get; set; }
            internal static string? Revision { get; set; }
            internal static string TemplateMonitor { get; set; }
            internal static bool IsAmountEditable { get; set; }
            internal static bool IsExtraInputBoxesEnabled { get; set; }
            internal static bool IsExtraInputBoxes_2Layer { get; set; }
            internal static bool IsExtraInputBoxes_SecondMeasurement { get; set; }
            internal static bool IsExtraFieldForCutterEnabled { get; set; }
            internal static string Workoperation { get; set; }

            public static void Set_MainTemplateID(ref bool IsOkStartOrder)
            {
                if (Order.PartID != null)
                {
                    using var con = new SqlConnection(Database.cs_Protocol);
                    const string query =
                        @"SELECT MeasureProtocolMainTemplateID FROM Processcard.MainData WHERE PartID = @partid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", Order.PartID);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    if (value != DBNull.Value && value != null)
                    {
                        ID = int.Parse(value.ToString());
                        return;
                    }

                    return;
                }

                var chooseTemplate = new ProcesscardTemplateSelector(ProcesscardTemplateSelector.TemplateType.TemplateMeasureProtocol);
                chooseTemplate.ShowDialog();
                if (chooseTemplate.IsAborted)
                    IsOkStartOrder = false;
            }
            public static void Save_Data()
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                        IF NOT EXISTS 
                            (
                                SELECT * FROM MeasureProtocol.MainTemplate 
                                WHERE Name = @name
                                    AND Revision = @revision
                            )
                        BEGIN
                            INSERT INTO MeasureProtocol.MainTemplate 
                                (
                                    MeasureProtocolTemplate_Monitor, 
                                    Revision, 
                                    Name,   
                                    IsAmountEditable,
                                    IsExtraInputBoxesEnabled,
                                    IsExtraInputBoxes_2Layer,
                                    IsExtraInputBoxes_SecondMeasurement,
                                    IsExtraFieldForCutterEnabled,
                                    WorkoperationID,    
                                    CreatedBy, 
                                    CreatedDate 
                                )
                            VALUES 
                                ( 
                                    @templatemonitor,
                                    @revision,
                                    @name,
                                    @isamounteditable,
                                    @isextrainputboxesenabled,
                                    @isextrainputboxes2layer,
                                    @isextrainputboxessecondmeasurement,
                                    @isextrafieldforcutterenabled,
                                    (SELECT ID FROM Workoperation.Names WHERE Description = @workoperation),
                                    @createdby,
                                    @createddate
                                )
                        END
                        ELSE
                        BEGIN
                            UPDATE MeasureProtocol.MainTemplate 
                            SET 
                                MeasureProtocolTemplate_Monitor = @templatemonitor,
                                Name = @name,
                                IsAmountEditable = @isamounteditable,
                                IsExtraInputBoxesEnabled = @isextrainputboxesenabled,
                                IsExtraInputBoxes_2Layer = @isextrainputboxes2layer,
                                IsExtraInputBoxes_SecondMeasurement = @isextrainputboxessecondmeasurement,
                                IsExtraFieldForCutterEnabled = @isextrafieldforcutterenabled
                           WHERE Name = @name
                                AND Revision = @revision
                        END";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@templatemonitor", TemplateMonitor);
                cmd.Parameters.AddWithValue("@revision", Revision);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@isamounteditable", IsAmountEditable);
                cmd.Parameters.AddWithValue("@isextrainputboxesenabled", IsExtraInputBoxesEnabled);
                cmd.Parameters.AddWithValue("@isextrainputboxes2layer", IsExtraInputBoxes_2Layer);
                cmd.Parameters.AddWithValue("@isextrainputboxessecondmeasurement", IsExtraInputBoxes_SecondMeasurement);
                cmd.Parameters.AddWithValue("@isextrafieldforcutterenabled", IsExtraFieldForCutterEnabled);
                cmd.Parameters.AddWithValue("@workoperation", Workoperation);
                cmd.Parameters.AddWithValue("@createdby", Person.Name);
                cmd.Parameters.AddWithValue("@createddate", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            internal static void SetNew_MainTemplateID()
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"SELECT ISNULL(MAX(MeasureProtocolMainTemplateID) + 1, 1) FROM MeasureProtocol.MainTemplate";

                using var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                ID = Convert.ToInt32(cmd.ExecuteScalar()); // Handles null safely
            }
        }

        public class Template
        {
            public static void Update_Data(DataGridView dgv)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open(); // Open connection once

                const string query = @"
                IF NOT EXISTS
                    (
                        SELECT 1 FROM MeasureProtocol.Template 
                        WHERE MeasureProtocolMainTemplateID = (SELECT MeasureProtocolMainTemplateID FROM MeasureProtocol.MainTemplate WHERE Name = @name AND Revision = @revision)
                        AND ColumnIndex = @columnindex
                    )
                BEGIN
                    INSERT INTO MeasureProtocol.Template
                    (
                        MeasureProtocolMainTemplateID,
                        DescriptionID,
                        Parameter_UserText, 
                        Parameter_Monitor,          
                        IsMandatory,    
                        IsList, 
                        Formula, 
                        DataType, 
                        ControlType, 
                        ColumnIndex, 
                        Increment,
                        ColumnWidth, 
                        Decimals, 
                        MaxChars
                    )
                    VALUES 
                    ( 
                        (SELECT MeasureProtocolMainTemplateID FROM MeasureProtocol.MainTemplate WHERE Name = @name AND Revision = @revision),
                        @descriptionid,
                        @parameter,
                        @parametermonitor,
                        @ismandatory,
                        @islist,
                        @formula,
                        @datatype,
                        @controltype,
                        @columnindex,
                        @increment,
                        @columnwidth,
                        @decimals,
                        @maxchars
                    )
                END
                ELSE
                BEGIN
                    UPDATE MeasureProtocol.Template
                    SET
                        DescriptionID = @descriptionid,
                        Parameter_UserText = @parameter,
                        Parameter_Monitor = @parametermonitor,
                        IsMandatory = @ismandatory,                        
                        IsList = @islist,
                        Formula = @formula,
                        DataType = @datatype,
                        ControlType = @controltype,
                        ColumnIndex = @columnindex,
                        Increment = @increment,
                        ColumnWidth = @columnwidth, 
                        Decimals = @decimals,
                        MaxChars = @maxchars
                    WHERE MeasureProtocolMainTemplateID = (SELECT MeasureProtocolMainTemplateID FROM MeasureProtocol.MainTemplate WHERE Name = @name AND Revision = @revision)
                    AND ColumnIndex = @columnindex
                END";

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    using var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@name", MainTemplate.Name);
                    cmd.Parameters.AddWithValue("@revision", MainTemplate.Revision);
                    cmd.Parameters.AddWithValue("@descriptionid", GetIntValue(row, "col_DescriptionID"));
                    cmd.Parameters.AddWithValue("@parameter", GetValue(row, "col_Parameter"));
                    cmd.Parameters.AddWithValue("@parametermonitor", GetValue(row, "col_ParameterMonitor"));
                    cmd.Parameters.AddWithValue("@ismandatory", GetBooleanValue(row, "col_IsMandatory"));
                    cmd.Parameters.AddWithValue("@islist", GetBooleanValue(row, "col_Items"));
                    cmd.Parameters.AddWithValue("@formula", ReplaceVariablesWithRowNumbers(row.Cells["col_Formula"], dgv));
                    cmd.Parameters.AddWithValue("@datatype", GetIntValue(row, "col_DataType"));
                    cmd.Parameters.AddWithValue("@controltype", GetValue(row, "col_ControlType"));
                    cmd.Parameters.AddWithValue("@columnindex", row.Index);
                    cmd.Parameters.AddWithValue("@increment", GetIntValue(row, "col_Increment"));
                    cmd.Parameters.AddWithValue("@columnwidth", GetIntValue(row, "col_Width"));
                    cmd.Parameters.AddWithValue("@decimals", GetIntValue(row, "col_Decimals"));
                    cmd.Parameters.AddWithValue("@maxchars", GetIntValue(row, "col_MaxChars"));

                    cmd.ExecuteNonQuery();
                }
            }

            private static object ReplaceVariablesWithRowNumbers(DataGridViewCell dgv_cell, DataGridView dgv)
            {
                if (dgv_cell.Value is null || string.IsNullOrWhiteSpace(dgv_cell.Value.ToString()))
                    return DBNull.Value; // Return as-is if formula is empty or dgv is null

                var formula = dgv_cell.Value.ToString();
                var matches = Regex.Matches(formula, @"\[(.*?)\]");

                foreach (Match match in matches)
                {
                    var variableName = match.Groups[1].Value; // Extract variable name

                    // Find the row index where this variable exists
                    var rowIndex = -1;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow) // Ignore the "new row" placeholder
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Value != null && cell.Value.ToString() == variableName)
                                {
                                    rowIndex = row.Index;
                                    break; // Stop checking once found
                                }
                            }
                        }
                        if (rowIndex != -1) break; // Stop outer loop once found
                    }

                    // Replace the variable with its row number if found
                    if (rowIndex != -1)
                        formula = formula.Replace($"[{variableName}]", $"[{rowIndex}]");
                }

                return formula;
            }
        }
        private static object GetValue(DataGridViewRow row, string columnName)
        {
            var cellValue = row.Cells[columnName]?.Value;
            return cellValue == null || cellValue == DBNull.Value ? DBNull.Value : cellValue;
        }
        private static object GetIntValue(DataGridViewRow row, string columnName)
        {
            return int.TryParse(row.Cells[columnName]?.Value?.ToString(), out var result) ? result : (object)DBNull.Value;
        }
        private static object GetBooleanValue(DataGridViewRow row, string columnName)
        {
            return bool.TryParse(row.Cells[columnName]?.Value?.ToString(), out var result) ? result : (object)DBNull.Value;
        }

        
    }
}



