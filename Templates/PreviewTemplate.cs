
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.MainInfo;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Templates;

namespace DigitalProductionProgram.Protocols.Template_Management
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
                    var lineClearance_A = new LineClearance.LineClearance
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
        public void Update_Template(FlowLayoutPanel? flp_Main)
        {
            DrawingControl.SuspendDrawing(this);
            Clear_All();

            foreach (Panel panel in flp_Main.Controls)
            {
                var label_Name = new Label();
                foreach (var lbl in panel.Controls.OfType<Label>())
                    label_Name = lbl;

                int.TryParse(panel.Name, out var formtemplateID);
                DataGridView dgv_FormTemplate = null;
                DataGridView dgv_Template = null;
                foreach (var dgv in panel.Controls.OfType<DataGridView>())
                {
                    if (dgv.Name == "dgv_FormTemplate")
                        dgv_FormTemplate = dgv;
                    else
                        dgv_Template = dgv;
                }

                var module = new Module
                {
                    LeftHeader = label_Name.Text,
                    Margin = new Padding(0, 0, 0, 1),
                    FormTemplateID = formtemplateID,
                    Dock = DockStyle.Fill,
                };
                tlp_Machines.Controls.Add(module);
                tlp_Machines.SetCellPosition(module, new TableLayoutPanelCellPosition(0, tlp_Machines.RowCount - 1));
                var pcWidth = 0;
                var rpWidth = 0;
                if (dgv_FormTemplate.Rows[0].Cells["col_ProcesscardWidth"].Value != null)
                    int.TryParse(dgv_FormTemplate.Rows[0].Cells["col_ProcesscardWidth"].Value.ToString(), out pcWidth);
                if (dgv_FormTemplate.Rows[0].Cells["col_RunProtocolWidth"].Value != null)
                    int.TryParse(dgv_FormTemplate.Rows[0].Cells["col_RunProtocolWidth"].Value.ToString(), out rpWidth);

                module.dgv_Module.Columns["col_MIN"].Width = module.dgv_Module.Columns["col_NOM"].Width =
                    module.dgv_Module.Columns["col_MAX"].Width = pcWidth;
                module.dgv_Module.Columns[module.dgv_Module.Columns.Count - 1].Width = rpWidth;
                module.dgv_Module.ColumnHeadersVisible =
                    (bool)dgv_FormTemplate.Rows[0].Cells["col_IsHeaderVisible"].Value;

                foreach (DataGridViewRow row in dgv_Template.Rows)
                {
                    module.dgv_Module.Rows.Add();
                    module.dgv_Module.Rows[row.Index].Cells["col_CodeText"].Value = row.Cells["col_CodeText"].Value;
                    module.dgv_Module.Rows[row.Index].Cells["col_Unit"].Value = row.Cells["col_Unit"].Value;

                    var IsUsingProcesscard = false;
                    if (dgv_Template.Rows[row.Index].Cells["col_UsedInProcesscard"].Value != null)
                        bool.TryParse(dgv_Template.Rows[row.Index].Cells["col_UsedInProcesscard"].Value.ToString(),
                            out IsUsingProcesscard);
                    if (IsUsingProcesscard)
                    {
                        if (row.Cells["col_MIN"].Value != null)
                            if (bool.TryParse(row.Cells["col_MIN"].Value.ToString(), out var IsOk))
                                module.dgv_Module.Rows[row.Index].Cells["col_MIN"].Style.BackColor =
                                    IsOk ? Color.Gainsboro : Color.FromArgb(60, 60, 60);
                        if (row.Cells["col_NOM"].Value != null)
                            if (bool.TryParse(row.Cells["col_NOM"].Value.ToString(), out var IsOk))
                                module.dgv_Module.Rows[row.Index].Cells["col_NOM"].Style.BackColor =
                                    IsOk ? Color.Silver : Color.FromArgb(60, 60, 60);
                        if (row.Cells["col_MAX"].Value != null)
                            if (bool.TryParse(row.Cells["col_MAX"].Value.ToString(), out var IsOk))
                                module.dgv_Module.Rows[row.Index].Cells["col_MAX"].Style.BackColor =
                                    IsOk ? Color.Gainsboro : Color.FromArgb(60, 60, 60);
                    }
                }

                if (IsOkHideColumn("col_MIN", module))
                    module.dgv_Module.Columns["col_MIN"].Visible = false;
                if (IsOkHideColumn("col_MAX", module))
                    module.dgv_Module.Columns["col_MAX"].Visible = false;


                tlp_Machines.RowStyles[tlp_Machines.RowCount - 1].Height = module.dgv_Module.Rows.Count * module.dgv_Module.RowTemplate.Height;
                if (module.dgv_Module.ColumnHeadersVisible)
                    tlp_Machines.RowStyles[tlp_Machines.RowCount - 1].Height += module.dgv_Module.ColumnHeadersHeight;

                tlp_Machines.RowCount++;
                tlp_Machines.RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
                module.dgv_Module.ReadOnly = true;
                module.Remove_AllStartups();
            }
            DrawingControl.ResumeDrawing(this);
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
            var width = 0;
            var machine = new Machine(machineIndex, ref isAutheticationNeeded, ref width, false)
            {
                Dock = DockStyle.Fill,
                Name = machineIndex.ToString(),
            };
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
