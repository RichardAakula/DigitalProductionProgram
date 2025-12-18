using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.MainInfo;
using DigitalProductionProgram.Protocols.Protocol;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace DigitalProductionProgram.Templates
{
    public partial class PreviewTemplate : Form
    {
        private readonly bool IsOkToCompare;
        public PreviewTemplate(string lineClearanceTemplate, string mainInfoTemplate)
        {
            InitializeComponent();

            cb_TemplateName.DataSource = Templates_Protocol.List_TemplateNames;
            cb_RevisionNr.DataSource = Templates_Protocol.List_RevisionNr;
            cb_TemplateName.SelectedIndex = -1;
            Add_MainInfo(mainInfoTemplate);
            Add_LineClearance(lineClearanceTemplate);
            IsOkToCompare = true;
        }

        private void Clear_All()
        {
            tlp_Machines.Controls.Clear();
            tlp_Machines.RowCount = 1;
        }

        private void Add_LineClearance(string lineClearanceTemplate)
        {
            switch (lineClearanceTemplate)
            {
                case "A":
                    var lineClearance_A = new Protocols.LineClearance.LineClearance
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0, 3, 0, 1)
                    };
                    lineClearance_A.Translate_Form();
                    panel_LineClearance.Controls.Add(lineClearance_A);
                    lineClearance_A.Enabled = false;
                    break;

            }
        }
        private void Add_MainInfo(string mainInfoTemplate)
        {
            switch (mainInfoTemplate)
            {
                case "A":
                    var mainInfo_A = new MainInfo_A
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0, 0, 0, 1)
                    };
                    mainInfo_A.Translate_Form();
                    panel_MainInfo.Controls.Add(mainInfo_A);
                    break;
                case "B":
                    var mainInfo_B = new MainInfo_B
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0, 0, 0, 1)
                    };
                    mainInfo_B.Translate_Form();
                    panel_MainInfo.Controls.Add(mainInfo_B);
                    break;
            }
        }

        public async Task Update_TemplateAsync(FlowLayoutPanel? flp_Main)
        {
            // Show progressbar on UI
            var pbar = new CustomProgressBar();
            try
            {
                pbar.Show();
                pbar.pBar_Main.Style = ProgressBarStyle.Marquee;
                pbar.pBar_Main.MarqueeAnimationSpeed = 30;
                pbar.Set_ValueProgressBar(0, "Laddar längsta möjliga text till protokollet...");

                // Give the UI a short chance to render the progressbar
                await Task.Delay(200);

                if (flp_Main == null)
                    return;

                // 1) Snapshot minimal data from UI quickly (on UI thread)
                var snapshots = new List<PanelSnapshot>();
                this.Invoke(() =>
                {
                    foreach (Panel panel in flp_Main.Controls.OfType<Panel>())
                    {
                        var snapshot = new PanelSnapshot
                        {
                            PanelName = panel.Name,
                            LabelText = panel.Controls.OfType<Label>().FirstOrDefault()?.Text ?? string.Empty,
                            FormTemplate = CopyGridToTable(panel.Controls.OfType<DataGridView>().FirstOrDefault(d => d.Name == "dgv_FormTemplate")),
                            Template = CopyGridToTable(panel.Controls.OfType<DataGridView>().FirstOrDefault(d => d.Name != "dgv_FormTemplate"))
                        };
                        snapshots.Add(snapshot);
                    }
                });

                // 2) For each snapshot: do DB / CPU work on background thread, then create the UI on UI thread
                await Task.Run(() =>
                {
                    foreach (var snap in snapshots)
                    {
                        var dto = BuildModuleDtoFromSnapshot(snap);
                        // Minimal UI update: create and populate Module control
                        this.Invoke(() => CreateModuleFromDto(dto));
                    }
                });
            }
            finally
            {
                // Ensure progressbar is closed on UI thread
                try { this.Invoke((Action)(() => pbar.Close())); }
                catch { /* ignore if form disposed */ }
            }
        }

        #region Helper DTOs and methods

        private class PanelSnapshot
        {
            public string PanelName = string.Empty;
            public string LabelText = string.Empty;
            public DataTable? FormTemplate;
            public DataTable? Template;
        }
        private class ModuleRowDto
        {
            public string? CodeText;
            public string? Unit;
            public string? MinValue;
            public string? NomValue;
            public string? MaxValue;
            public string? RpValue;
            public bool IsUsingProcesscard;
            public bool? CellMinOk;
            public bool? CellNomOk;
            public bool? CellMaxOk;
        }
        private class ModuleDto
        {
            public string Header = string.Empty;
            public int FormTemplateID;
            public int PcMinWidth;
            public int PcNomWidth;
            public int PcMaxWidth;
            public int RpWidth;
            public bool ColumnHeadersVisible;
            public List<ModuleRowDto> Rows = new List<ModuleRowDto>();
        }

        private static DataTable? CopyGridToTable(DataGridView? dgv)
        {
            if (dgv == null)
                return null;

            var tbl = new DataTable();
            // create columns
            foreach (DataGridViewColumn col in dgv.Columns)
                tbl.Columns.Add(col.Name, typeof(string));

            // copy rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                var dr = tbl.NewRow();
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    var val = row.Cells[col.Index].Value;
                    dr[col.Name] = val?.ToString() ?? string.Empty;
                }
                tbl.Rows.Add(dr);
            }
            return tbl;
        }

        private ModuleDto BuildModuleDtoFromSnapshot(PanelSnapshot snap)
        {
            var dto = new ModuleDto
            {
                Header = snap.LabelText ?? string.Empty
            };

            // parse formtemplate widths & header visibility from snapshot.FormTemplate (row 0)
            if (snap.FormTemplate != null && snap.FormTemplate.Rows.Count > 0)
            {
                var row = snap.FormTemplate.Rows[0];
                int.TryParse(row.Table.Columns.Contains("col_MinProcesscardWidth") ? row["col_MinProcesscardWidth"]?.ToString() : null, out var pcMin);
                int.TryParse(row.Table.Columns.Contains("col_NomProcesscardWidth") ? row["col_NomProcesscardWidth"]?.ToString() : null, out var pcNom);
                int.TryParse(row.Table.Columns.Contains("col_MaxProcesscardWidth") ? row["col_MaxProcesscardWidth"]?.ToString() : null, out var pcMax);
                int.TryParse(row.Table.Columns.Contains("col_NomRunProtocolWidth") ? row["col_NomRunProtocolWidth"]?.ToString() : null, out var rpWidth);
                bool.TryParse(row.Table.Columns.Contains("col_IsHeaderVisible") ? row["col_IsHeaderVisible"]?.ToString() : null, out var isHeaderVisible);
               
                dto.PcMinWidth = pcMin;
                dto.PcNomWidth = pcNom;
                dto.PcMaxWidth = pcMax;
                dto.RpWidth = rpWidth;
                dto.ColumnHeadersVisible = isHeaderVisible;
            }

            // parse FormTemplateID from panel name
            int.TryParse(snap.PanelName, out var formtemplateID);
            dto.FormTemplateID = formtemplateID;

            // Build rows: for each row in template snapshot call Load_TestData (DB) on background thread
            if (snap.Template != null)
            {
                for (int i = 0; i < snap.Template.Rows.Count; i++)
                {
                    var row = snap.Template.Rows[i];
                    var rowDto = new ModuleRowDto
                    {
                        CodeText = row.Table.Columns.Contains("col_CodeText") ? row["col_CodeText"]?.ToString() : string.Empty,
                        Unit = row.Table.Columns.Contains("col_Unit") ? row["col_Unit"]?.ToString() : string.Empty
                    };

                    int.TryParse(row.Table.Columns.Contains("col_ProtocolDescriptionID") ? row["col_ProtocolDescriptionID"]?.ToString() : null, out var protocolDescriptionID);
                    int.TryParse(row.Table.Columns.Contains("col_DataType") ? row["col_DataType"]?.ToString() : null, out var dataType);

                    // call Load_TestData (safe in background) for MIN, NOM, MAX
                    try
                    {
                        rowDto.MinValue = Load_TestProcessData(protocolDescriptionID, dataType, 0);
                        rowDto.NomValue = Load_TestProcessData(protocolDescriptionID, dataType, 1);
                        rowDto.MaxValue = Load_TestProcessData(protocolDescriptionID, dataType, 2);
                        rowDto.RpValue = Load_TestData(protocolDescriptionID, dataType);

                    }
                    catch
                    {
                        rowDto.MinValue = rowDto.MinValue ?? string.Empty;
                        rowDto.NomValue = rowDto.NomValue ?? string.Empty;
                        rowDto.MaxValue = rowDto.MaxValue ?? string.Empty;
                    }

                    // flags from snapshot cells (these came as strings)
                    bool.TryParse(row.Table.Columns.Contains("col_UsedInProcesscard") ? row["col_UsedInProcesscard"]?.ToString() : null, out var isUsingProcesscard);
                    rowDto.IsUsingProcesscard = isUsingProcesscard;

                    if (row.Table.Columns.Contains("col_MIN"))
                       
                    // Replace the problematic lines inside BuildModuleDtoFromSnapshot as follows:

                    if (row.Table.Columns.Contains("col_MIN"))
                    {
                        rowDto.CellMinOk = bool.TryParse(row["col_MIN"]?.ToString(), out var cellMinOkValue) ? cellMinOkValue : (bool?)null;
                    }
                    if (row.Table.Columns.Contains("col_NOM"))
                    {
                        rowDto.CellNomOk = bool.TryParse(row["col_NOM"]?.ToString(), out var cellNomOkValue) ? cellNomOkValue : (bool?)null;
                    }
                    if (row.Table.Columns.Contains("col_MAX"))
                    {
                        rowDto.CellMaxOk = bool.TryParse(row["col_MAX"]?.ToString(), out var cellMaxOkValue) ? cellMaxOkValue : (bool?)null;
                    }
                    

                    dto.Rows.Add(rowDto);
                }
            }

            return dto;
        }

        private void CreateModuleFromDto(ModuleDto dto)
        {
            // Create the Module control and populate it from DTO (runs on UI thread)
            var module = new Module
            {
                LeftHeader = dto.Header,
                Margin = new Padding(0, 0, 0, 1),
                FormTemplateID = dto.FormTemplateID,
                Dock = DockStyle.Fill,
            };
           
            tlp_Machines.Controls.Add(module);
            tlp_Machines.SetCellPosition(module, new TableLayoutPanelCellPosition(0, tlp_Machines.RowCount - 1));
          //  module.dgv_Module.Columns.Add("Test", "1");
            // set widths & header visibility
            if (module.dgv_Module.Columns.Contains("col_MIN")) module.dgv_Module.Columns["col_MIN"].Width = dto.PcMinWidth;
            if (module.dgv_Module.Columns.Contains("col_NOM")) module.dgv_Module.Columns["col_NOM"].Width = dto.PcNomWidth;
            if (module.dgv_Module.Columns.Contains("col_MAX")) module.dgv_Module.Columns["col_MAX"].Width = dto.PcMaxWidth;
            if (module.dgv_Module.Columns.Contains("col_StartUp_1")) module.dgv_Module.Columns["col_StartUp_1"].Width = dto.RpWidth;
            if (module.dgv_Module.ColumnCount > 0) module.dgv_Module.Columns[^1].Width = dto.RpWidth;
            module.dgv_Module.ColumnHeadersVisible = dto.ColumnHeadersVisible;
            // add rows and values
            for (int i = 0; i < dto.Rows.Count; i++)
            {
                var r = dto.Rows[i];
                module.dgv_Module.Rows.Add();
                var rowIndex = module.dgv_Module.Rows.Count - 1;

                if (module.dgv_Module.Columns.Contains("col_CodeText"))
                    module.dgv_Module.Rows[rowIndex].Cells["col_CodeText"].Value = r.CodeText;
                if (module.dgv_Module.Columns.Contains("col_Unit"))
                    module.dgv_Module.Rows[rowIndex].Cells["col_Unit"].Value = r.Unit;
                if (module.dgv_Module.Columns.Contains("col_MIN"))
                    module.dgv_Module.Rows[rowIndex].Cells["col_MIN"].Value = r.MinValue;
                if (module.dgv_Module.Columns.Contains("col_NOM"))
                    module.dgv_Module.Rows[rowIndex].Cells["col_NOM"].Value = r.NomValue;
                if (module.dgv_Module.Columns.Contains("col_MAX"))
                    module.dgv_Module.Rows[rowIndex].Cells["col_MAX"].Value = r.MaxValue;
                if (module.dgv_Module.Columns.Contains("col_StartUp_1"))
                    module.dgv_Module.Rows[rowIndex].Cells["col_StartUp_1"].Value = r.RpValue;

                if (r.IsUsingProcesscard)
                {
                    if (module.dgv_Module.Columns.Contains("col_MIN") && r.CellMinOk.HasValue)
                        module.dgv_Module.Rows[rowIndex].Cells["col_MIN"].Style.BackColor = r.CellMinOk.Value ? Color.Gainsboro : Color.FromArgb(60, 60, 60);
                    if (module.dgv_Module.Columns.Contains("col_NOM") && r.CellNomOk.HasValue)
                        module.dgv_Module.Rows[rowIndex].Cells["col_NOM"].Style.BackColor = r.CellNomOk.Value ? Color.Silver : Color.FromArgb(60, 60, 60);
                    if (module.dgv_Module.Columns.Contains("col_MAX") && r.CellMaxOk.HasValue)
                        module.dgv_Module.Rows[rowIndex].Cells["col_MAX"].Style.BackColor = r.CellMaxOk.Value ? Color.Gainsboro : Color.FromArgb(60, 60, 60);
                }
            }

            // hide columns if needed (same logic as before)
            if (IsOkHideColumn("col_MIN", module))
                if (module.dgv_Module.Columns.Contains("col_MIN")) module.dgv_Module.Columns["col_MIN"].Visible = false;
            if (IsOkHideColumn("col_MAX", module))
                if (module.dgv_Module.Columns.Contains("col_MAX")) module.dgv_Module.Columns["col_MAX"].Visible = false;

            // adjust layout heights and finalize
            tlp_Machines.RowStyles[tlp_Machines.RowCount - 1].Height = module.dgv_Module.Rows.Count * module.dgv_Module.RowTemplate.Height;
            if (module.dgv_Module.ColumnHeadersVisible)
                tlp_Machines.RowStyles[tlp_Machines.RowCount - 1].Height += module.dgv_Module.ColumnHeadersHeight;

            tlp_Machines.RowCount++;
            tlp_Machines.RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            module.dgv_Module.ReadOnly = true;
        }

        #endregion




        private string Load_TestProcessData(int protocolDescriptionID, int dataType, int columnIndex)
        {
            // Välj rätt kolumn
            var column = dataType switch
            {
                0 => "Value",
                1 => "TextValue",
                _ => null
            };
            if (column == null)
                return "N/A";

            var result = string.Empty;

            var query = $@"
        SELECT TOP(1) {column}
        FROM Processcard.[Data]
        WHERE TemplateID IN
        (
            SELECT ID 
            FROM Protocol.Template
            WHERE ProtocolDescriptionID = @protocolDescriptionID
              AND ColumnIndex = @columnIndex
              AND {column} IS NOT NULL
        )
        AND PartID IN (SELECT PartID FROM Processcard.MainData WHERE ProtocolMainTemplateID IN (SELECT ID FROM Protocol.MainTemplate WHERE Name = @name))

        ORDER BY LEN({column}) DESC;";

            using var con = new SqlConnection(Database.cs_Protocol);
            using var cmd = new SqlCommand(query, con);
            ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@protocolDescriptionID", protocolDescriptionID);
            cmd.Parameters.AddWithValue("@columnIndex", columnIndex);
            cmd.Parameters.AddWithValue("@name", Templates_Protocol.MainTemplate.Name);

            con.Open();
            var value = cmd.ExecuteScalar();

            if (value != null && value != DBNull.Value)
                result = value.ToString()?.Trim();

            return result;
        }
        private string Load_TestData(int protocolDescriptionID, int dataType)
        {
            // Välj rätt kolumn
            var column = dataType switch
            {
                0 => "Value",
                1 => "TextValue",
                _ => null
            };
            if (column == null)
                return "N/A";

            var result = string.Empty;

            var query = $@"
        SELECT TOP(1) {column}
        FROM [Order].[Data]
        WHERE ProtocolDescriptionID = @protocolDescriptionID
              AND {column} IS NOT NULL
              AND OrderID IN (SELECT OrderID FROM [Order].MainData WHERE ProtocolMainTemplateID IN (SELECT ID FROM Protocol.MainTemplate WHERE Name = @name))
        ORDER BY LEN({column}) DESC;";

            using var con = new SqlConnection(Database.cs_Protocol);
            using var cmd = new SqlCommand(query, con);
            ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@protocolDescriptionID", protocolDescriptionID);
            cmd.Parameters.AddWithValue("@name", Templates_Protocol.MainTemplate.Name);

            con.Open();
            var value = cmd.ExecuteScalar();

            if (value != null && value != DBNull.Value)
                result = value.ToString()?.Trim();

            return result;
        }




        private bool IsOkHideColumn(string columnName, Module module)
        {
            return module.dgv_Module.Rows.Cast<DataGridViewRow>().All(row => row.Cells[columnName].Style.BackColor != Color.Gainsboro);
        }
        private readonly List<DataGridView> list_New_Template = new List<DataGridView>();
        private readonly List<DataGridView> list_Old_Template = new List<DataGridView>();

        private void Compare_Templates()
        {
            list_New_Template.Clear();
            list_Old_Template.Clear();

            ProcessAllControls(tlp_Machines, list_New_Template);
            ProcessAllControls(tlp_Machines_Compare, list_Old_Template);

            var list_New_CodeText = (from dgv in list_New_Template
                                     from DataGridViewRow row in dgv.Rows
                                     where row.Cells["col_CodeText"].Value != null
                                     select row.Cells["col_CodeText"].Value.ToString()).ToList();
            var list_Old_CodeText = (from dgv in list_Old_Template
                                     from DataGridViewRow row in dgv.Rows
                                     where row.Cells["col_CodeText"].Value != null
                                     select row.Cells["col_CodeText"].Value.ToString()).ToList();

            foreach (var row in from dgv in list_New_Template from DataGridViewRow row in dgv.Rows where row.Cells["col_CodeText"].Value != null select row)
                row.DefaultCellStyle.BackColor = list_Old_CodeText.Contains(row.Cells["col_CodeText"].Value.ToString()) ? Color.White : CustomColors.Bad_Back;

            foreach (var row in from dgv in list_Old_Template from DataGridViewRow row in dgv.Rows where row.Cells["col_CodeText"].Value != null select row)
                row.DefaultCellStyle.BackColor = list_New_CodeText.Contains(row.Cells["col_CodeText"].Value.ToString()) == false ? CustomColors.Bad_Back : Color.White;

        }


        public void ProcessAllControls(Control parent, List<DataGridView> list)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is DataGridView view)
                    list.Add(view);

                if (control.Controls.Count > 0)
                    ProcessAllControls(control, list);
            }
        }
        private void AddMachine(int columnIndex, byte machineIndex)
        {
            var isAutheticationNeeded = false;
            // var IsUsingPrefab = false;
            var height = 0; //Denna används inte här
            var machine = new Machine(machineIndex, ref isAutheticationNeeded, ref height, false)
            {
                Dock = DockStyle.Fill,
                Name = machineIndex.ToString(),
            };
            var width = machine.TotalWidth;
            machine.Remove_AllStartups();
            tlp_Machines_Compare.Controls.Add(machine);
            tlp_Machines_Compare.SetCellPosition(machine, new TableLayoutPanelCellPosition(columnIndex, 0));


        }
        private void TemplateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsOkToCompare == false)
                return;
            var org_revision = Templates_Protocol.MainTemplate.Revision;
            var org_TemplateID = Templates_Protocol.MainTemplate.Revision;

            Templates_Protocol.MainTemplate.Revision = cb_RevisionNr.Text;
            Templates_Protocol.MainTemplate.Load_MainTemplateID(cb_TemplateName.Text, cb_RevisionNr.Text);
            if (string.IsNullOrEmpty(Templates_Protocol.MainTemplate.Revision) || string.IsNullOrEmpty(cb_TemplateName.Text) == false)
            {
                tlp_Machines_Compare.Controls.Clear();
                AddMachine(0, 1);
                Compare_Templates();
            }

            Templates_Protocol.MainTemplate.Revision = org_revision;
            Templates_Protocol.MainTemplate.Revision = org_TemplateID;
        }

        
    }
}
