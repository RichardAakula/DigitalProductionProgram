using System.Collections;
using System.Data;
using System.Text;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Övrigt;
using Microsoft.Data.SqlClient;

namespace DigitalProductionProgram.Statistics
{
    public sealed partial class ParameterDataSearch : Form
    {
        private List<string> allPartNumbers = [];
        private List<ParameterDefinition> allMeasureParameters = [];
        private List<ParameterDefinition> allProtocolParameters = [];
        private List<TemplateFilterDefinition> allMeasureTemplates = [];
        private List<TemplateFilterDefinition> allProtocolTemplates = [];
        private List<WorkOperationDefinition> allWorkOperations = [];
        private List<string> allPrefabPartNumbers = [];
        private List<string> allPrefabDescriptions = [];

        private readonly List<string> selectedPartNumbers = [];
        private readonly List<ParameterDefinition> selectedMeasureParameters = [];
        private readonly List<ParameterDefinition> selectedOrderParameters = [];
        private readonly List<string> selectedPrefabArticleNumbers = [];
        private readonly List<string> selectedPrefabNames = [];

        public ParameterDataSearch()
        {
            Log.Activity.Start();
            InitializeComponent();
            ConfigureGrid();
            WireEvents();
            _ =Log.Activity.Stop("User open Analysis of Parameter Data");
        }

        private void WireEvents()
        {
            Load += ParameterDataSearch_Load;

            lb_PartNr.Click += (_, _) => AddSelectedTextValue(lb_PartNr, selectedPartNumbers, lb_SelectedPartNr);
            lb_MeasureProtocolParameters.Click += (_, _) => AddSelectedParameter(lb_MeasureProtocolParameters, selectedMeasureParameters, lb_SelectedMeasureParameters);
            lb_ProtocolParameters.Click += (_, _) => AddSelectedParameter(lb_ProtocolParameters, selectedOrderParameters, lb_SelectedProtocolParameters);
            lb_PrefabPartNr.Click += (_, _) => AddSelectedTextValue(lb_PrefabPartNr, selectedPrefabArticleNumbers, lb_SelectedPrefabPartNr);
            lb_PrefabDescription.Click += (_, _) => AddSelectedTextValue(lb_PrefabDescription, selectedPrefabNames, lb_SelectedPrefabDescription);

            btn_AddPartNr.Click += (_, _) => AddSelectedTextValue(lb_PartNr, selectedPartNumbers, lb_SelectedPartNr);
            btn_AddMeasureParameter.Click += (_, _) => AddSelectedParameter(lb_MeasureProtocolParameters, selectedMeasureParameters, lb_SelectedMeasureParameters);
            btn_AddOrder.Click += (_, _) => AddSelectedParameter(lb_ProtocolParameters, selectedOrderParameters, lb_SelectedProtocolParameters);
            btn_AddPrefabPartNr.Click += (_, _) => AddSelectedTextValue(lb_PrefabPartNr, selectedPrefabArticleNumbers, lb_SelectedPrefabPartNr);
            btn_AddPrefabDescription.Click += (_, _) => AddSelectedTextValue(lb_PrefabDescription, selectedPrefabNames, lb_SelectedPrefabDescription);

            btn_RemovePartNr.Click += (_, _) => RemoveSelectedTextValue(selectedPartNumbers, lb_SelectedPartNr);
            btn_RemoveMeasure.Click += (_, _) => RemoveSelectedParameter(selectedMeasureParameters, lb_SelectedMeasureParameters);
            btn_RemoveOrder.Click += (_, _) => RemoveSelectedParameter(selectedOrderParameters, lb_SelectedProtocolParameters);
            btn_RemovePrefabPartNr.Click += (_, _) => RemoveSelectedTextValue(selectedPrefabArticleNumbers, lb_SelectedPrefabPartNr);
            btn_RemovePrefabDescription.Click += (_, _) => RemoveSelectedTextValue(selectedPrefabNames, lb_SelectedPrefabDescription);
            btnFetchData.Click += BtnFetchData_Click;
            btn_ExportToCsv.Click += Btn_ExportToCsv_Click;

            cb_WorkOperation.SelectedIndexChanged += (_, _) => ApplyPartNumberFilter();
            tb_FilterPartNr.TextChanged += (_, _) => ApplyPartNumberFilter();
            cb_MeasureTemplate.SelectedIndexChanged += (_, _) => ApplyMeasureParameterFilter();
            tb_FilterMeasurementParameters.TextChanged += (_, _) => ApplyMeasureParameterFilter();
            cb_ProtocolTemplate.SelectedIndexChanged += (_, _) => ApplyProtocolParameterFilter();
            tb_FilterProtocolParameters.TextChanged += (_, _) => ApplyProtocolParameterFilter();
            tb_FilterPrefabPartNr.TextChanged += (_, _) => ApplyTextFilter(lb_PrefabPartNr, allPrefabPartNumbers, tb_FilterPrefabPartNr.Text);
            tb_FilterPrefabDescription.TextChanged += (_, _) => ApplyTextFilter(lb_PrefabDescription, allPrefabDescriptions, tb_FilterPrefabDescription.Text);

            ConfigureSelectedListReordering(lb_SelectedPartNr, selectedPartNumbers);
            ConfigureSelectedListReordering(lb_SelectedMeasureParameters, selectedMeasureParameters);
            ConfigureSelectedListReordering(lb_SelectedProtocolParameters, selectedOrderParameters);
            ConfigureSelectedListReordering(lb_SelectedPrefabPartNr, selectedPrefabArticleNumbers);
            ConfigureSelectedListReordering(lb_SelectedPrefabDescription, selectedPrefabNames);
        }

        private void ConfigureGrid()
        {
            dgv_Result.EnableHeadersVisualStyles = false;
            dgv_Result.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgv_Result.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            dgv_Result.DefaultCellStyle.BackColor = Color.FromArgb(25, 25, 25);
            dgv_Result.DefaultCellStyle.ForeColor = Color.Gainsboro;
            dgv_Result.DefaultCellStyle.SelectionBackColor = Color.DarkSlateBlue;
            dgv_Result.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv_Result.GridColor = Color.FromArgb(55, 55, 55);
        }

        private void ParameterDataSearch_Load(object? sender, EventArgs e)
        {
            LoadWorkOperations();
            LoadPartNumbers();
            LoadMeasureTemplates();
            LoadMeasureParameters();
            LoadProtocolTemplates();
            LoadProtocolParameters();
            LoadPrefabPartNumbers();
            LoadPrefabDescription();
            AddDefaultSelections();
        }

        private void LoadPartNumbers()
        {
            allPartNumbers = Database.ExecuteSafe(con =>
            {
                const string query = """
                                     SELECT DISTINCT main.PartNr
                                     FROM [Order].MainData AS main
                                     WHERE PartNr IS NOT NULL
                                         AND PartNr <> ''
                                     ORDER BY main.PartNr
                                     """;

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                var result = new List<string>();
                while (reader.Read())
                    result.Add(reader.GetString(0));

                return result;
            }) ?? [];

            ApplyPartNumberFilter();
        }

        private void LoadWorkOperations()
        {
            allWorkOperations = Database.ExecuteSafe(con =>
            {
                const string query = """
                                     SELECT
                                         ID,
                                         Name
                                     FROM Workoperation.Names
                                     WHERE Name IS NOT NULL
                                         AND Name <> ''
                                     ORDER BY Name
                                     """;

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                var result = new List<WorkOperationDefinition>
                {
                    new(0, "Alla arbetsoperationer")
                };

                while (reader.Read())
                {
                    var id = Convert.ToInt32(reader.GetValue(0));
                    var name = reader.GetString(1);
                    result.Add(new WorkOperationDefinition(id, name));
                }

                return result;
            }) ?? [new WorkOperationDefinition(0, "Alla arbetsoperationer")];

            cb_WorkOperation.DataSource = null;
            cb_WorkOperation.DisplayMember = nameof(WorkOperationDefinition.Name);
            cb_WorkOperation.DataSource = allWorkOperations;
            cb_WorkOperation.SelectedIndex = 0;
        }

        private void LoadMeasureTemplates()
        {
            allMeasureTemplates = Database.ExecuteSafe(con =>
            {
                const string query = """
                                     SELECT
                                         maintemplate.MeasureProtocolMainTemplateID,
                                         maintemplate.Name,
                                         maintemplate.Revision,
                                         template.DescriptionID
                                     FROM MeasureProtocol.MainTemplate AS maintemplate
                                     LEFT JOIN MeasureProtocol.Template AS template
                                         ON template.MeasureProtocolMainTemplateID = maintemplate.MeasureProtocolMainTemplateID
                                     WHERE maintemplate.Name IS NOT NULL
                                         AND maintemplate.Name <> ''
                                     ORDER BY maintemplate.Name, maintemplate.Revision DESC, template.DescriptionID
                                     """;

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                var templates = new Dictionary<int, TemplateFilterDefinition>();
                while (reader.Read())
                {
                    var templateId = Convert.ToInt32(reader.GetValue(0));
                    if (!templates.TryGetValue(templateId, out var template))
                    {
                        var name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        var revision = reader.IsDBNull(2) ? string.Empty : reader.GetValue(2).ToString() ?? string.Empty;
                        template = new TemplateFilterDefinition(templateId, BuildMeasureTemplateDisplayName(name, revision));
                        templates.Add(templateId, template);
                    }

                    if (!reader.IsDBNull(3))
                        template.DescriptionIds.Add(Convert.ToInt32(reader.GetValue(3)));
                }

                var result = templates.Values.ToList();
                result.Insert(0, new TemplateFilterDefinition(0, "Alla mallar"));
                return result;
            }) ?? [new TemplateFilterDefinition(0, "Alla mallar")];

            cb_MeasureTemplate.DataSource = null;
            cb_MeasureTemplate.DisplayMember = nameof(TemplateFilterDefinition.DisplayName);
            cb_MeasureTemplate.DataSource = allMeasureTemplates;
            cb_MeasureTemplate.SelectedIndex = 0;
        }

        private void LoadProtocolTemplates()
        {
            allProtocolTemplates = Database.ExecuteSafe(con =>
            {
                const string query = """
                                     SELECT
                                         maintemplate.ID,
                                         maintemplate.Name,
                                         maintemplate.Revision,
                                         template.ProtocolDescriptionID
                                     FROM Protocol.MainTemplate AS maintemplate
                                     LEFT JOIN Protocol.FormTemplate AS formtemplate
                                         ON formtemplate.MainTemplateID = maintemplate.ID
                                     LEFT JOIN Protocol.Template AS template
                                         ON template.FormTemplateID = formtemplate.FormTemplateID
                                     WHERE maintemplate.Name IS NOT NULL
                                         AND maintemplate.Name <> ''
                                     ORDER BY maintemplate.Name, maintemplate.Revision DESC, template.ProtocolDescriptionID
                                     """;

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                var templates = new Dictionary<int, TemplateFilterDefinition>();
                while (reader.Read())
                {
                    var templateId = Convert.ToInt32(reader.GetValue(0));
                    if (!templates.TryGetValue(templateId, out var template))
                    {
                        var name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        var revision = reader.IsDBNull(2) ? string.Empty : reader.GetValue(2).ToString() ?? string.Empty;
                        template = new TemplateFilterDefinition(templateId, BuildMeasureTemplateDisplayName(name, revision));
                        templates.Add(templateId, template);
                    }

                    if (!reader.IsDBNull(3))
                        template.DescriptionIds.Add(Convert.ToInt32(reader.GetValue(3)));
                }

                var result = templates.Values.ToList();
                result.Insert(0, new TemplateFilterDefinition(0, "Alla mallar"));
                return result;
            }) ?? [new TemplateFilterDefinition(0, "Alla mallar")];

            cb_ProtocolTemplate.DataSource = null;
            cb_ProtocolTemplate.DisplayMember = nameof(TemplateFilterDefinition.DisplayName);
            cb_ProtocolTemplate.DataSource = allProtocolTemplates;
            cb_ProtocolTemplate.SelectedIndex = 0;
        }

        private void LoadMeasureParameters()
        {
            allMeasureParameters = Database.ExecuteSafe(con =>
            {
                const string query = """
                                     SELECT DISTINCT
                                         description.ID,
                                         description.CodeName
                                     FROM MeasureProtocol.Description AS description
                                     INNER JOIN MeasureProtocol.Data AS data
                                         ON data.DescriptionId = description.ID
                                     ORDER BY description.CodeName
                                     """;

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                var result = new List<ParameterDefinition>();
                while (reader.Read())
                {
                    var id = Convert.ToInt32(reader.GetValue(0));
                    var codeName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    result.Add(new ParameterDefinition(id, GetMeasureDisplayName(id, codeName), ParameterType.Measure));
                }

                return result;
            }) ?? [];

            ApplyMeasureParameterFilter();
        }

        private void LoadProtocolParameters()
        {
            allProtocolParameters = Database.ExecuteSafe(con =>
            {
                const string query = """
                                     SELECT DISTINCT
                                         description.ID,
                                         description.CodeText
                                     FROM Protocol.Description AS description
                                     INNER JOIN [Order].Data AS data
                                         ON data.ProtocolDescriptionID = description.ID
                                     ORDER BY description.CodeText
                                     """;

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                var result = new List<ParameterDefinition>();
                while (reader.Read())
                {
                    var id = Convert.ToInt32(reader.GetValue(0));
                    var codeText = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    result.Add(new ParameterDefinition(id, GetOrderDisplayName(id, codeText), ParameterType.Order));
                }

                return result;
            }) ?? [];

            ApplyProtocolParameterFilter();
        }

        private void LoadPrefabPartNumbers()
        {
            allPrefabPartNumbers = Database.ExecuteSafe(con =>
            {
                const string query = """
                                     SELECT DISTINCT Halvfabrikat_ArtikelNr
                                     FROM [Order].Prefab
                                     WHERE Halvfabrikat_ArtikelNr IS NOT NULL
                                         AND Halvfabrikat_ArtikelNr <> ''
                                     ORDER BY Halvfabrikat_ArtikelNr
                                     """;

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                var result = new List<string>();
                while (reader.Read())
                    result.Add(reader.GetString(0));

                return result;
            }) ?? [];

            ApplyTextFilter(lb_PrefabPartNr, allPrefabPartNumbers, tb_FilterPrefabPartNr.Text);
        }

        private void LoadPrefabDescription()
        {
            allPrefabDescriptions = Database.ExecuteSafe(con =>
            {
                const string query = """
                                     SELECT DISTINCT Halvfabrikat_Benämning
                                     FROM [Order].Prefab
                                     WHERE Halvfabrikat_Benämning IS NOT NULL
                                         AND Halvfabrikat_Benämning <> ''
                                     ORDER BY Halvfabrikat_Benämning
                                     """;

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                var result = new List<string>();
                while (reader.Read())
                    result.Add(reader.GetString(0));

                return result;
            }) ?? [];

            ApplyTextFilter(lb_PrefabDescription, allPrefabDescriptions, tb_FilterPrefabDescription.Text);
        }

        private void AddDefaultSelections()
        {
            selectedPartNumbers.Clear();
            selectedMeasureParameters.Clear();
            selectedOrderParameters.Clear();
            selectedPrefabArticleNumbers.Clear();
            selectedPrefabNames.Clear();

            lb_SelectedPartNr.Items.Clear();
            lb_SelectedMeasureParameters.Items.Clear();
            lb_SelectedProtocolParameters.Items.Clear();
            lb_SelectedPrefabPartNr.Items.Clear();
            lb_SelectedPrefabDescription.Items.Clear();
        }

        private static void AddSelectedParameter(ListBox sourceListBox, List<ParameterDefinition> selectedParameters, ListBox listBox)
        {
            if (sourceListBox.SelectedItems.Count == 0)
                return;

            var itemsToAdd = sourceListBox.SelectedItems.Cast<object>().ToList();

            foreach (var selectedItem in itemsToAdd)
            {
                if (selectedItem is not ParameterDefinition parameter)
                    continue;

                if (selectedParameters.Any(x => x.Id == parameter.Id))
                    continue;

                selectedParameters.Add(parameter);
                listBox.Items.Add(parameter.Name);
            }
        }

        private static void AddSelectedTextValue(ListBox sourceListBox, List<string> selectedValues, ListBox listBox)
        {
            if (sourceListBox.SelectedItems.Count == 0)
                return;

            var itemsToAdd = sourceListBox.SelectedItems.Cast<object>().ToList();

            foreach (var selectedItem in itemsToAdd)
            {
                if (selectedItem is not string value || string.IsNullOrWhiteSpace(value))
                    continue;

                if (selectedValues.Contains(value, StringComparer.OrdinalIgnoreCase))
                    continue;

                selectedValues.Add(value);
                listBox.Items.Add(value);
            }
        }

        private static void RemoveSelectedParameter(List<ParameterDefinition> selectedParameters, ListBox listBox)
        {
            if (listBox.SelectedIndex < 0 || listBox.SelectedIndex >= selectedParameters.Count)
                return;

            selectedParameters.RemoveAt(listBox.SelectedIndex);
            listBox.Items.RemoveAt(listBox.SelectedIndex);
        }

        private static void RemoveSelectedTextValue(List<string> selectedValues, ListBox listBox)
        {
            if (listBox.SelectedIndex < 0 || listBox.SelectedIndex >= selectedValues.Count)
                return;

            selectedValues.RemoveAt(listBox.SelectedIndex);
            listBox.Items.RemoveAt(listBox.SelectedIndex);
        }

        private static void ConfigureSelectedListReordering(ListBox listBox, IList backingList)
        {
            listBox.AllowDrop = true;
            listBox.MouseDown += (_, e) => BeginSelectedListDrag(listBox, backingList, e);
            listBox.DragOver += (_, e) => HandleSelectedListDragOver(e);
            listBox.DragDrop += (_, e) => HandleSelectedListDragDrop(listBox, backingList, e);
        }

        private static void BeginSelectedListDrag(ListBox listBox, IList backingList, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var dragIndex = listBox.IndexFromPoint(e.Location);
            if (dragIndex < 0 || dragIndex >= listBox.Items.Count)
                return;

            listBox.SelectedIndex = dragIndex;
            var dragItem = new ListBoxDragItem(listBox, backingList, dragIndex);
            listBox.DoDragDrop(dragItem, DragDropEffects.Move);
        }

        private static void HandleSelectedListDragOver(DragEventArgs e)
        {
            e.Effect = e.Data?.GetData(typeof(ListBoxDragItem)) is ListBoxDragItem
                ? DragDropEffects.Move
                : DragDropEffects.None;
        }

        private static void HandleSelectedListDragDrop(ListBox targetListBox, IList targetBackingList, DragEventArgs e)
        {
            if (e.Data?.GetData(typeof(ListBoxDragItem)) is not ListBoxDragItem dragItem)
                return;

            if (!ReferenceEquals(dragItem.ListBox, targetListBox) || !ReferenceEquals(dragItem.BackingList, targetBackingList))
                return;

            if (dragItem.Index < 0 || dragItem.Index >= targetListBox.Items.Count)
                return;

            var targetPoint = targetListBox.PointToClient(new Point(e.X, e.Y));
            var targetIndex = GetDropIndex(targetListBox, targetPoint);

            if (targetIndex == dragItem.Index)
                return;

            var movedItem = targetBackingList[dragItem.Index];
            targetBackingList.RemoveAt(dragItem.Index);

            if (targetIndex > dragItem.Index)
                targetIndex--;

            if (targetIndex < 0 || targetIndex > targetBackingList.Count)
                targetIndex = targetBackingList.Count;

            targetBackingList.Insert(targetIndex, movedItem);
            RebindSelectedListBox(targetListBox, targetBackingList);
            targetListBox.SelectedIndex = targetIndex;
        }

        private static int GetDropIndex(ListBox listBox, Point targetPoint)
        {
            var hoverIndex = listBox.IndexFromPoint(targetPoint);
            if (hoverIndex < 0)
                return listBox.Items.Count;

            var itemRectangle = listBox.GetItemRectangle(hoverIndex);
            var insertAfter = targetPoint.Y > itemRectangle.Top + (itemRectangle.Height / 2);
            return insertAfter ? hoverIndex + 1 : hoverIndex;
        }

        private static void RebindSelectedListBox(ListBox listBox, IList source)
        {
            listBox.BeginUpdate();
            try
            {
                listBox.Items.Clear();
                foreach (var item in source)
                {
                    listBox.Items.Add(item is ParameterDefinition parameter ? parameter.Name : item);
                }
            }
            finally
            {
                listBox.EndUpdate();
            }
        }

        private static void ApplyTextFilter(ListBox listBox, IEnumerable<string> source, string filterText)
        {
            var filtered = source
                .Where(x => IsMatch(x, filterText))
                .ToList();

            listBox.DataSource = null;
            listBox.DataSource = filtered;
        }

        private void ApplyPartNumberFilter()
        {
            var selectedWorkOperation = cb_WorkOperation.SelectedItem as WorkOperationDefinition;

            IEnumerable<string> source = allPartNumbers;
            if (selectedWorkOperation != null && selectedWorkOperation.Id > 0)
            {
                source = Database.ExecuteSafe(con =>
                {
                    const string query = """
                                         SELECT DISTINCT main.PartNr
                                         FROM [Order].MainData AS main
                                         WHERE main.PartNr IS NOT NULL
                                             AND main.PartNr <> ''
                                             AND main.WorkoperationID = @workoperationid
                                         ORDER BY main.PartNr
                                         """;

                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@workoperationid", selectedWorkOperation.Id);
                    using var reader = cmd.ExecuteReader();

                    var result = new List<string>();
                    while (reader.Read())
                        result.Add(reader.GetString(0));

                    return result;
                }) ?? [];
            }

            ApplyTextFilter(lb_PartNr, source, tb_FilterPartNr.Text);
        }

        private static void ApplyParameterFilter(ListBox listBox, IEnumerable<ParameterDefinition> source, string filterText)
        {
            var filtered = source
                .Where(x => IsMatch(x.Name, filterText))
                .ToList();

            listBox.DataSource = null;
            listBox.DisplayMember = string.Empty;
            listBox.DataSource = filtered;
            listBox.DisplayMember = nameof(ParameterDefinition.Name);
        }

        private void ApplyMeasureParameterFilter()
        {
            var selectedTemplate = cb_MeasureTemplate.SelectedItem as TemplateFilterDefinition;
            var filtered = allMeasureParameters
                .Where(x => selectedTemplate == null
                    || selectedTemplate.DescriptionIds.Count == 0
                    || selectedTemplate.DescriptionIds.Contains(x.Id))
                .Where(x => IsMatch(x.Name, tb_FilterMeasurementParameters.Text))
                .ToList();

            lb_MeasureProtocolParameters.DataSource = null;
            lb_MeasureProtocolParameters.DisplayMember = string.Empty;
            lb_MeasureProtocolParameters.DataSource = filtered;
            lb_MeasureProtocolParameters.DisplayMember = nameof(ParameterDefinition.Name);
        }

        private void ApplyProtocolParameterFilter()
        {
            var selectedTemplate = cb_ProtocolTemplate.SelectedItem as TemplateFilterDefinition;
            var filtered = allProtocolParameters
                .Where(x => selectedTemplate == null
                    || selectedTemplate.DescriptionIds.Count == 0
                    || selectedTemplate.DescriptionIds.Contains(x.Id))
                .Where(x => IsMatch(x.Name, tb_FilterProtocolParameters.Text))
                .ToList();

            lb_ProtocolParameters.DataSource = null;
            lb_ProtocolParameters.DisplayMember = string.Empty;
            lb_ProtocolParameters.DataSource = filtered;
            lb_ProtocolParameters.DisplayMember = nameof(ParameterDefinition.Name);
        }

        private static bool IsMatch(string value, string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText))
                return true;

            if (filterText.StartsWith('*'))
            {
                var containsText = filterText[1..].Trim();
                return string.IsNullOrEmpty(containsText)
                    || value.Contains(containsText, StringComparison.OrdinalIgnoreCase);
            }

            return value.StartsWith(filterText, StringComparison.OrdinalIgnoreCase);
        }

        private void BtnFetchData_Click(object? sender, EventArgs e)
        {
            Log.Activity.Start();
            if (selectedMeasureParameters.Count == 0 && selectedOrderParameters.Count == 0)
            {
                MessageBox.Show("Valj minst en parameter innan du hamtar data.", "Parameterdata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnFetchData.Enabled = false;
            lbl_Status.Text = "Hämtar data...";

            try
            {
                var sql = BuildQuery();
                var dt = Database.ExecuteSafe(con =>
                {
                    using var cmd = new SqlCommand(sql, con);
                    using var adapter = new SqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                });

                dgv_Result.DataSource = dt;
                lbl_Status.Text = dt == null ? "Ingen data hamtades." : $"{dt.Rows.Count} rader hamtade.";
            }
            finally
            {
                btnFetchData.Enabled = true;
                _= Log.Activity.Stop($"User fetched parameter data. MeasureProtocolTemplate = {cb_MeasureTemplate.Text}, ProtocolTemplate = {cb_ProtocolTemplate.Text}, Workoperation = {cb_WorkOperation.Text}. Total Rows = {dgv_Result.Rows.Count}");
            }
        }
        private void Btn_ExportToCsv_Click(object? sender, EventArgs e)
        {
            ExportCsv();
        }

        private void ExportCsv()
        {
            if (dgv_Result.DataSource is not DataTable dt || dt.Rows.Count == 0)
            {
                MessageBox.Show("Det finns ingen data att exportera.", "Parameterdata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sb = new StringBuilder();
            Get_Protocol_Data.ConvertDataTableTo_csv(dt, sb);

            var fileName = string.Format(
                "Parameterdata_{0:yyyyMMdd_HHmmss}.csv",
                DateTime.Now);

            Get_Protocol_Data.Save_csvFile(sb, fileName);
        }

        private string BuildQuery()
        {
            var ctes = new List<string>();
            var selectColumns = new List<string>
            {
                "main.PartNr",
                "main.OrderNr"
            };
            var joins = new List<string>();

            if (selectedMeasureParameters.Count > 0)
            {
                ctes.Add(BuildMeasurementParametersCte());
                joins.Add("""
                          LEFT JOIN mp
                              ON mp.OrderID = main.OrderID
                          """);

                selectColumns.AddRange(selectedMeasureParameters.Select(p => $"mp.{BuildSqlIdentifier(p)} AS [{EscapeSqlAlias(p.Name)}]"));
                selectColumns.Add("mp.RowIndex");
            }

            if (selectedOrderParameters.Count > 0)
            {
                ctes.Add(BuildProtocolParametersCte());
                joins.Add("""
                          LEFT JOIN ord_single AS ord
                              ON ord.OrderID = main.OrderID
                          """);

                selectColumns.AddRange(selectedOrderParameters.Select(p => $"ord.{BuildSqlIdentifier(p)} AS [{EscapeSqlAlias(p.Name)}]"));
            }

            ctes.Add("""
                     prefab AS (
                         SELECT
                             OrderID,
                             MAX(Halvfabrikat_ArtikelNr) AS Halvfabrikat_ArtikelNr,
                             MAX(Halvfabrikat_Benämning) AS Halvfabrikat_Benämning,
                             MAX(Halvfabrikat_ID) AS Halvfabrikat_ID,
                             MAX(Halvfabrikat_OD) AS Halvfabrikat_OD,
                             MAX(Halvfabrikat_W) AS Halvfabrikat_W,
                             MAX(Halvfabrikat_OrderNr) AS Halvfabrikat_OrderNr
                         FROM [Order].Prefab
                         GROUP BY OrderID
                     )
                     """);

            selectColumns.AddRange(
            [
                "prefab.Halvfabrikat_ArtikelNr",
                "prefab.Halvfabrikat_Benämning",
                "prefab.Halvfabrikat_ID",
                "prefab.Halvfabrikat_OD",
                "prefab.Halvfabrikat_W",
                "next_prefab.Halvfabrikat_ArtikelNr AS Next_Halvfabrikat_ArtikelNr"
            ]);

            joins.Add("""
                      LEFT JOIN prefab
                          ON prefab.OrderID = main.OrderID
                      LEFT JOIN [Order].MainData AS next_main
                          ON next_main.OrderNr = prefab.Halvfabrikat_OrderNr
                      LEFT JOIN [Order].Prefab AS next_prefab
                          ON next_prefab.OrderID = next_main.OrderID
                      """);

            var orderBy = selectedMeasureParameters.Count > 0
                ? "ORDER BY main.PartNr, main.OrderNr, mp.RowIndex;"
                : "ORDER BY main.PartNr, main.OrderNr;";

            var builder = new StringBuilder();
            builder.AppendLine("WITH");
            builder.AppendLine(string.Join("," + Environment.NewLine, ctes));
            builder.AppendLine();
            builder.AppendLine("SELECT");
            builder.AppendLine("    " + string.Join("," + Environment.NewLine + "    ", selectColumns));
            builder.AppendLine("FROM [Order].MainData AS main");
            builder.AppendLine(string.Join(Environment.NewLine, joins));
            builder.AppendLine(BuildWhereClause());
            builder.AppendLine(orderBy);

            return builder.ToString();
        }

        private string BuildWhereClause()
        {
            var filters = new List<string>();

            if (selectedPartNumbers.Count > 0)
            {
                filters.Add(
                    $"({string.Join(" OR ", selectedPartNumbers.Select(p => $"main.PartNr = {ToSqlStringLiteral(p)}"))})");
            }

            var prefabFilters = new List<string>();

            if (selectedPrefabArticleNumbers.Count > 0)
            {
                prefabFilters.Add(
                    $"next_prefab.Halvfabrikat_ArtikelNr IN ({string.Join(", ", selectedPrefabArticleNumbers.Select(ToSqlStringLiteral))})");
            }

            if (selectedPrefabNames.Count > 0)
            {
                prefabFilters.Add(
                    $"next_prefab.Halvfabrikat_Benämning IN ({string.Join(", ", selectedPrefabNames.Select(ToSqlStringLiteral))})");
            }

            if (prefabFilters.Count > 0)
                filters.Add($"({string.Join(" OR ", prefabFilters)})");

            if (filters.Count == 0)
                return string.Empty;

            return "WHERE" + Environment.NewLine + "    " + string.Join(Environment.NewLine + "    AND ", filters);
        }

        private string BuildMeasurementParametersCte()
        {
            var columns = selectedMeasureParameters.Select(p =>
                $"MAX(CASE WHEN DescriptionId = {p.Id} THEN {SqlValueExpression()} END) AS {BuildSqlIdentifier(p)}");

            return $"""
                    mp AS (
                        SELECT
                            OrderID,
                            RowIndex,
                            {string.Join("," + Environment.NewLine + "            ", columns)}
                        FROM MeasureProtocol.Data
                        GROUP BY OrderID, RowIndex
                    )
                    """;
        }

        private string BuildProtocolParametersCte()
        {
            var columns = selectedOrderParameters.Select(p =>
                $"MAX(CASE WHEN ProtocolDescriptionID = {p.Id} THEN {SqlValueExpression()} END) AS {BuildSqlIdentifier(p)}");

            return $"""
                    ord_single AS (
                        SELECT
                            OrderID,
                            {string.Join("," + Environment.NewLine + "            ", columns)}
                        FROM [Order].Data
                        GROUP BY OrderID
                    )
                    """;
        }

        private static string SqlValueExpression()
        {
            return """
                   COALESCE(
                       CONVERT(nvarchar(255), Value),
                       TextValue,
                       CASE
                           WHEN BoolValue IS NULL THEN NULL
                           WHEN BoolValue = 1 THEN 'True'
                           ELSE 'False'
                       END,
                       CONVERT(nvarchar(30), DateValue, 120)
                   )
                   """;
        }

        private static string BuildSqlIdentifier(ParameterDefinition parameter)
        {
            return $"[{parameter.Type}_{parameter.Id}]";
        }

        private static string EscapeSqlAlias(string value)
        {
            return value.Replace("]", "]]");
        }

        private static string ToSqlStringLiteral(string value)
        {
            return $"N'{value.Replace("'", "''")}'";
        }

        private static string BuildMeasureTemplateDisplayName(string name, string revision)
        {
            if (string.IsNullOrWhiteSpace(revision))
                return name;

            return $"{name} Rev {revision}";
        }

        private static string GetMeasureDisplayName(int id, string fallbackName)
        {
            return id switch
            {
                14 => "Exp.ID",
                16 => "Exp.OD",
                22 => "Exp.Wall",
                15 => "Rec.ID",
                17 => "Rec.OD",
                23 => "Rec.Wall",
                _ => fallbackName
            };
        }

        private static string GetOrderDisplayName(int id, string fallbackName)
        {
            return id switch
            {
                75 => "Pipe 1",
                160 => "Pipe 2",
                161 => "Pipe 3",
                60 => "Speed",
                348 => "Pressure",
                62 => "Temp Pos 1",
                64 => "Temp Pos 2",
                65 => "Temp Pos 3",
                68 => "Bromsad?",
                70 => "Bromsad Vikt",
                _ => fallbackName
            };
        }

        private sealed record ParameterDefinition(int Id, string Name, ParameterType Type)
        {
            public override string ToString() => Name;
        }

        private sealed class TemplateFilterDefinition(int id, string displayName)
        {
            public int Id { get; } = id;
            public string DisplayName { get; } = displayName;
            public HashSet<int> DescriptionIds { get; } = [];

            public override string ToString() => DisplayName;
        }

        private sealed class WorkOperationDefinition(int id, string name)
        {
            public int Id { get; } = id;
            public string Name { get; } = name;

            public override string ToString() => Name;
        }

        private sealed class ListBoxDragItem(ListBox listBox, IList backingList, int index)
        {
            public ListBox ListBox { get; } = listBox;
            public IList BackingList { get; } = backingList;
            public int Index { get; } = index;
        }

        private enum ParameterType
        {
            Measure,
            Order
        }
    }
}
