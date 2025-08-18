using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DigitalProductionProgram.Templates.Templates_Protocol;
using ProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;

namespace DigitalProductionProgram.Templates
{
    public partial class Templates_Protocol : Form
    {
        private static int totalConnectedProcesscardsToTemplate;

        public static int TotalConnectedProcesscardsToTemplate
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT COUNT(*) FROM Processcard.MainData WHERE ProtocolMainTemplateID = @maintemplateid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@maintemplateid", MainTemplate.ID);
                    var value = cmd.ExecuteScalar();
                    var result = value == null ? 0 : int.Parse(value.ToString());
                    totalConnectedProcesscardsToTemplate = result;
                    return result;
                }

            }
        }
        private static int totalConnectedOrdersToTemplate;
        public static int TotalConnectedOrdersToTemplate
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT COUNT(*) FROM [Order].MainData WHERE ProtocolMainTemplateID = @maintemplateid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@maintemplateid", MainTemplate.ID);
                    var value = cmd.ExecuteScalar();
                    var result = value == null ? 0 : int.Parse(value.ToString());
                    totalConnectedOrdersToTemplate = result;
                    return result;
                }

            }
        }


        public static DataGridView dgv_ProtocolsActive_Main;
        public static DataGridView dgv_Active_ModuleInfo;
        public static Panel panel_Active;
        public static Label label_Active_ModuleName;
        public PreviewTemplate preview;


        public static List<string> List_TemplateNames = new List<string>();
        public static List<string> List_RevisionNr = new List<string>();

        public static class TemplateButtons
        {
            public static bool isOkUpdateTemplate;
            private static bool isOkSaveTemplate;

            public static bool IsOkUpdateTemplate
            {
                get => isOkUpdateTemplate;
                set
                {
                    if (isOkUpdateTemplate != value)
                    {
                        if (totalConnectedProcesscardsToTemplate == 0 && totalConnectedOrdersToTemplate == 0)
                            isOkUpdateTemplate = true;
                        else
                            isOkUpdateTemplate = value;
                        OnIsOkUpdateTemplateChanged(EventArgs.Empty);
                    }
                }
            }
            public static bool IsOkSaveTemplate
            {
                get => isOkSaveTemplate;
                set
                {
                    if (isOkSaveTemplate != value)
                    {
                        isOkSaveTemplate = value;
                        OnIsOkSaveTemplateChanged(EventArgs.Empty);
                    }
                }
            }
            public static event EventHandler IsOkUpdateTemplateChanged;
            public static event EventHandler IsOkSaveTemplateChanged;
            private static void OnIsOkUpdateTemplateChanged(EventArgs e)
            {
                IsOkUpdateTemplateChanged?.Invoke(null, e);
            }
            private static void OnIsOkSaveTemplateChanged(EventArgs e)
            {
                IsOkSaveTemplateChanged?.Invoke(null, e);
            }
        }




        private bool IsOkSaveTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(cb_TemplateRevision.Text))
                {
                    InfoText.Show("Fyll i mallens revisionsnr före du sparar mallen.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return false;
                }
                if (string.IsNullOrEmpty(cb_TemplateName.Text))
                {
                    InfoText.Show("Fyll i mallens namn före du sparar mallen.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return false;
                }
                if (flp_Main.Controls.Cast<Panel>().SelectMany(panel => panel.Controls.OfType<DataGridView>()).Any(dgv => dgv.Rows.Count == 0))
                {
                    InfoText.Show("Någon av modulerna saknar rader, du kan inte spara mallen utan rader i alla moduler.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return false;
                }

                return true;
            }
        }


        public Templates_Protocol()
        {
            Order.Save_TempOrderInfo();
            InitializeComponent();
            CodeText.LoadData(dgv_CodeText);
            Fill_MainTemplate_Names();
            Fill_LineClearance_Templates();
            InitializeButtons();
        }
        private void Manage_Templates_Load(object sender, EventArgs e)
        {
            Load_PDF();
            TemplateButtons.IsOkSaveTemplate = false;
            TemplateButtons.IsOkUpdateTemplate = false;
        }

        private void InitializeButtons()
        {
            TemplateButtons.IsOkUpdateTemplateChanged += (sender, e) =>
            {
                Update_UpdateButton();
            };

            TemplateButtons.IsOkSaveTemplateChanged += (sender, e) =>
            {
                Update_SaveButton();
            };
        }



        private void Update_SaveButton()
        {
            if (TemplateButtons.IsOkSaveTemplate)
            {
                btn_SaveNewTemplate.BackColor = CustomColors.Ok_Back;
                btn_SaveNewTemplate.ForeColor = CustomColors.Ok_Front;
            }
            else
            {
                btn_SaveNewTemplate.BackColor = CustomColors.Bad_Back;
                btn_SaveNewTemplate.ForeColor = CustomColors.Bad_Front;
            }
        }
        private void Update_UpdateButton()
        {
            if (TemplateButtons.IsOkUpdateTemplate)
            {
                btn_UpdateTemplate.BackColor = CustomColors.Ok_Back;
                btn_UpdateTemplate.ForeColor = CustomColors.Ok_Front;
            }
            else
            {
                btn_UpdateTemplate.BackColor = CustomColors.Bad_Back;
                btn_UpdateTemplate.ForeColor = CustomColors.Bad_Front;
            }
        }



        private void Fill_MainTemplate_Names()
        {
            cb_TemplateName.SelectedIndexChanged -= Template_Name_SelectedIndexChanged;
            cb_TemplateName.Items.Clear();
            List_TemplateNames.Clear();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                SELECT DISTINCT Name
                FROM Protocol.MainTemplate
                ORDER BY Name";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cb_TemplateName.Items.Add(reader.GetString(0));
                    List_TemplateNames.Add(reader.GetString(0));
                }
            }

            cb_TemplateName.SelectedIndexChanged += Template_Name_SelectedIndexChanged;
        }
        private void Fill_Template_RevisionNr()
        {
            cb_TemplateName.SelectedIndexChanged -= Template_Name_SelectedIndexChanged;
            cb_TemplateRevision.Items.Clear();
            List_RevisionNr.Clear();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                SELECT DISTINCT Revision
                FROM Protocol.MainTemplate
                WHERE Name = @name";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@name", cb_TemplateName.Text);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cb_TemplateRevision.Items.Add(reader.GetString(0));
                    List_RevisionNr.Add(reader.GetString(0));
                }
            }

            cb_TemplateName.SelectedIndexChanged += Template_Name_SelectedIndexChanged;
            cb_TemplateRevision.SelectedIndex = cb_TemplateRevision.Items.Count - 1;
        }
        private void Fill_LineClearance_Templates()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Revision", typeof(string)); // Define the column

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT LineClearance_Revision as Revision FROM LineClearance.MainTemplate WHERE ProtocolTemplateName = @templatename";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@templatename", cb_TemplateName.Text);
                con.Open();
                var adapter = new SqlDataAdapter(cmd); // Use the SqlCommand object
                adapter.Fill(dataTable);
            }

            //if (dataTable.Rows.Count == 0)
            //    dataTable.Rows.Add("A");

            cb_LineClearance_Revision.DisplayMember = "Revision";
            cb_LineClearance_Revision.ValueMember = "Revision";
            cb_LineClearance_Revision.DataSource = dataTable;
        }

        private void Load_PDF()
        {
            var filePath = Path.Combine(Path.GetTempPath(), "Guide - Templates.pdf");
            File.WriteAllBytes(filePath, Properties.Resources.GuideTemplates);
            web_PDF_Viewer.Navigate(filePath); // Load the PDF into the WebBrowser control
        }


        private void NewModule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_ModuleName.Text))
            {
                InfoText.Show("Fyll i modulens namn före du försöker lägga till en modul.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }
            AddModule(1);
            tb_ModuleName.Text = string.Empty;
        }
        private void NewRevision_MouseDown(object sender, MouseEventArgs e)
        {
            TemplateButtons.IsOkUpdateTemplate = false;
            if (e.Button == MouseButtons.Left)
                cb_TemplateRevision.Text = ControlValidator.Next_Letter(cb_TemplateRevision.Text, true);
            else
            {
                if (cb_TemplateRevision.Text != MainTemplate.Revision)
                    cb_TemplateRevision.Text = ControlValidator.Next_Letter(cb_TemplateRevision.Text, false);
            }
        }
        private void Revision_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Save_Template_Click(object sender, EventArgs e)
        {
            if (IsOkSaveTemplate == false)
                return;
            if (MainTemplate.IsTemplateExist(cb_TemplateName.Text, cb_TemplateRevision.Text))
            {
                InfoText.Show("Denna Revision finns redan, om du vill spara en ny mall måste du ändra Revision först.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }

            MainTemplate.Save_NewTemplate(cb_TemplateName.Text, cb_TemplateRevision.Text, chb_IsUsingPreFab.Checked, chb_IsProductionLineNeeded.Checked, cb_LineClearance_Revision.Text, cb_MainInfo_Template.Text, tb_Workoperation.Text, flp_Main);

            InfoText.Question("" +
                          $"Den nya mallen {cb_TemplateName.Text} är nu sparad och är nu klar att börja skapa nya processkort för.\n" +
                          "Vill du koppla gamla artikelnummer till den nya mallen?\n" +
                          "Om du svarar 'Ja' så öppnas ett nytt formulär där du får välja vilka artiklar som skall kopplas om",
                CustomColors.InfoText_Color.Info, null, this);
            if (InfoText.answer == InfoText.Answer.No)
                return;
            MainTemplate.Load_MainTemplateID(cb_TemplateName.Text, cb_TemplateRevision.Text);
            var partsManager = new Connect_Templates(cb_TemplateName.Text, cb_TemplateRevision.Text, false, Connect_Templates.SourceType.Type_Protocols);
            partsManager.ShowDialog();

            Fill_MainTemplate_Names();
        }
        private async void Update_Template_Click(object sender, EventArgs e)
        {
            if (!IsOkSaveTemplate)
                return;
            PerformUpdate();
            //await Task.Run(PerformUpdate); // Run in background
            InfoText.Show("Mallen har nu blivit uppdaterad.", CustomColors.InfoText_Color.Ok, null, this);
        }
        private void PerformUpdate()
        {
            if (TemplateButtons.IsOkUpdateTemplate)
            {
                MainTemplate.Update_Data(chb_IsUsingPreFab.Checked, cb_LineClearance_Revision.Text);

                int templateOrder = 0;

                foreach (Panel panel in flp_Main.Controls)
                {
                    var lbl_ModuleName = panel.Controls.OfType<Label>().FirstOrDefault();
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

                    int.TryParse(dgv_FormTemplate.Rows[0].Cells["col_MachineIndex"].Value.ToString(), out var machineIndex);

                    FormTemplate.Save_Data(cb_TemplateName.Text, cb_TemplateRevision.Text, dgv_FormTemplate, lbl_ModuleName.Text, templateOrder);
                    Template.Update_Data(cb_TemplateName.Text, dgv_Template, cb_TemplateRevision.Text, templateOrder, machineIndex, formtemplateID);
                    templateOrder++;

                }
            }
            else
            {
                var total = 0;
                if (MainTemplate.IsTemplateConnectedToProcesscard(ref total))
                {
                    ShowWarning($"Denna mall har {total} processkort kopplat till sig och kan inte längre uppdateras.");
                    return;
                }

                if (MainTemplate.IsTemplateConnectedToOrderNr(ref total))
                {
                    ShowWarning($"Denna mall har {total} ordrar kopplade till sig och kan inte längre uppdateras.");
                    return;
                }

                MainTemplate.Delete_Template(cb_TemplateName.Text, cb_TemplateRevision.Text, false);
                MainTemplate.Save_NewTemplate(cb_TemplateName.Text, cb_TemplateRevision.Text, chb_IsUsingPreFab.Checked, chb_IsProductionLineNeeded.Checked, cb_LineClearance_Revision.Text, cb_MainInfo_Template.Text, tb_Workoperation.Text, flp_Main);
            }
        }

        // Shows warning messages safely
        private void ShowWarning(string? message)
        {
            Invoke((Action)(() =>
            {
                InfoText.Show(message, CustomColors.InfoText_Color.Bad, "Warning!", this);
            }));
        }
        private void Delete_Template_Click(object sender, EventArgs e)
        {
            var total = 0;
            if (MainTemplate.IsTemplateConnectedToProcesscard(ref total))
            {
                InfoText.Show($"Denna mall har {total} processkort kopplat till sig och kan inte raderas, kontakta admin vid problem", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }
            if (MainTemplate.IsTemplateConnectedToOrderNr(ref total))
            {
                InfoText.Show($"Denna mall har {total} ordrar kopplade till sig och kan inte längre uppdateras. Du måste nu skapa en ny revision.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }
            MainTemplate.Delete_Template(cb_TemplateName.Text, cb_TemplateRevision.Text, true);
            Fill_MainTemplate_Names();
            cb_TemplateName.SelectedIndex = -1;

        }

        private void ConnectTemplate_Click(object sender, EventArgs e)
        {
            var partsManager = new Connect_Templates(cb_TemplateName.Text, cb_TemplateRevision.Text, false, Connect_Templates.SourceType.Type_Protocols);
            partsManager.ShowDialog();
        }
        private void ConnectPartNr_NewRevision_Click(object sender, EventArgs e)
        {
            var partsManager = new Connect_Templates(cb_TemplateName.Text, cb_TemplateRevision.Text, true, Connect_Templates.SourceType.Type_Protocols);
            partsManager.ShowDialog();
        }
        private void PreviewTemplate_Click(object sender, EventArgs e)
        {
            preview = new PreviewTemplate(cb_LineClearance_Revision.Text, cb_MainInfo_Template.Text);
            preview.Show();
            preview.Update_Template(flp_Main);
        }
        private void LineClearance_Revision_SelectedIndexChanged(object sender, EventArgs e)
        {
            TemplateButtons.IsOkUpdateTemplate = false;
        }

        private static void AddVerticalTextModuleHeader(Label label, string text)
        {
            var header = text.Aggregate<char, string>(null, (current, c) => current + $"{c}\n");
            label.Text = header;
        }

        private void AddModule(int machineIndex, int? formTemplateID = null)
        {
            var panel = new Panel
            {
                AutoSize = false,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Width = flp_Main.Width - 20,
                Margin = new Padding(1, 1, 0, 0),
                Name = formTemplateID.ToString(),
            };

            var label_Module_Name = new Label
            {
                Name = tb_ModuleName.Text,
                Dock = DockStyle.Left,
                AutoSize = false,
                Width = 17,
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            AddVerticalTextModuleHeader(label_Module_Name, tb_ModuleName.Text);

            var dgv_FormTemplate = TemplateControls.Add_DataGridView("dgv_FormTemplate", 62, DockStyle.Top, true, false);
            dgv_Active_ModuleInfo = dgv_FormTemplate;
            FormTemplate.AddColumns_dgv_FormTemplate(dgv_FormTemplate);


            var dgv_Template = TemplateControls.Add_DataGridView($"dgv_Module_{tb_ModuleName.Text}", 150, DockStyle.Fill, false, true);
            Template.AddColumns_dgv_Template(dgv_Template);

            dgv_ProtocolsActive_Main = dgv_Template;

            panel_Active = panel;
            label_Active_ModuleName = label_Module_Name;

            panel.Controls.Add(dgv_FormTemplate);
            panel.Controls.Add(label_Module_Name);
            panel.Controls.Add(dgv_Template);
            dgv_Template.BringToFront();
            flp_Main.Controls.Add(panel);
            dgv_CodeText.Visible = true;
            if (formTemplateID != null)
            {
                Template.Load_Data(cb_TemplateRevision.Text, formTemplateID);
                FormTemplate.Load_Data(formTemplateID, cb_TemplateName.Text, cb_TemplateRevision.Text, machineIndex);
            }
            TemplateButtons.IsOkUpdateTemplate = false;
            tb_ModuleName.Text = string.Empty;
        }
        private void AddNewCodeText_Unit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_NewCodeText.Text) || string.IsNullOrEmpty(tb_NewUnit.Text))
            {
                InfoText.Show("Fyll i både parameter och enhet före du sparar data.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }
            CodeText.InsertNewCodeText(tb_NewCodeText.Text, tb_NewUnit.Text);
            CodeText.LoadData(dgv_CodeText);
            tb_NewCodeText.Text = string.Empty;
            tb_NewUnit.Text = string.Empty;
        }

        private void Workoperation_MouseDown(object sender, MouseEventArgs e)
        {
            List<string?> list = new List<string?>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                SELECT DISTINCT Name
                FROM Workoperation.Names
                ORDER BY Name";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader.GetString(0));
            }
            Control[] controls = { tb_Workoperation };
            var chooseWorkoperation = new Choose_Item(list, controls, false);
            chooseWorkoperation.ShowDialog();
        }
        private void CodeText_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var codetext = dgv_CodeText.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (TemplateControls.IsCodeTextExistInModule(dgv_ProtocolsActive_Main, codetext))
                return;
            dgv_ProtocolsActive_Main.Rows.Add();
            dgv_ProtocolsActive_Main.Rows[dgv_ProtocolsActive_Main.Rows.Count - 1].Cells["col_CodeText"].Value = codetext;
            dgv_ProtocolsActive_Main.Rows[dgv_ProtocolsActive_Main.Rows.Count - 1].Cells["col_ProtocolDescriptionID"].Value = int.Parse(dgv_CodeText.Rows[e.RowIndex].Cells[0].Value.ToString());
            dgv_ProtocolsActive_Main.Rows[dgv_ProtocolsActive_Main.Rows.Count - 1].Cells["col_Unit"].Value = dgv_CodeText.Rows[e.RowIndex].Cells[2].Value.ToString();

            TemplateButtons.IsOkUpdateTemplate = false;
            TemplateButtons.IsOkSaveTemplate = true;
        }
        private void CodeText_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CodeText.LoadData(dgv_CodeText);
        }
        private void ModuleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);

        }
        private void CodeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            var key = e.KeyChar;
            foreach (DataGridViewRow row in dgv_CodeText.Rows)
            {
                if (row.Cells[1].Value.ToString().StartsWith(key.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    row.Selected = true;
                    dgv_CodeText.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }
        private void RenameModule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_ModuleName.Text))
            {
                InfoText.Show("Fyll i namnet på modulen före du försöker ändra det.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                ControlValidator.SoftBlink(tb_ModuleName, Color.White, Color.Maroon);
                return;
            }
            label_Active_ModuleName.Text = tb_ModuleName.Text;
            TemplateButtons.IsOkUpdateTemplate = false;
        }
        private void DeleteModule_Click(object sender, EventArgs e)
        {
            panel_Active.Dispose();
            TemplateButtons.IsOkUpdateTemplate = false;
        }
        private void ModuleUp_Click(object sender, EventArgs e)
        {
            var index = flp_Main.Controls.GetChildIndex(panel_Active);
            if (index > 0)
            {
                flp_Main.Controls.SetChildIndex(panel_Active, index - 1);
                TemplateButtons.IsOkUpdateTemplate = false;
            }

        }
        private void ModuleDown_Click(object sender, EventArgs e)
        {
            var index = flp_Main.Controls.GetChildIndex(panel_Active);
            if (index < flp_Main.Controls.Count)
            {
                flp_Main.Controls.SetChildIndex(panel_Active, index + 1);
                TemplateButtons.IsOkUpdateTemplate = false;
            }

        }
        private void DeleteCodeText_Click(object sender, EventArgs e)
        {
            dgv_ProtocolsActive_Main.Rows.RemoveAt(dgv_ProtocolsActive_Main.CurrentCell.RowIndex);

            preview?.Update_Template(flp_Main);
            TemplateButtons.IsOkUpdateTemplate = false;
        }
        private void CodeTextUp_Click(object sender, EventArgs e)
        {
            var row = dgv_ProtocolsActive_Main.CurrentCell.RowIndex;
            var rowToMove = dgv_ProtocolsActive_Main.Rows[row];
            if (row > 0)
            {
                dgv_ProtocolsActive_Main.Rows.RemoveAt(row);
                dgv_ProtocolsActive_Main.Rows.Insert(row - 1, rowToMove);
                dgv_ProtocolsActive_Main.CurrentCell = dgv_ProtocolsActive_Main.Rows[row - 1].Cells[1];
                TemplateButtons.IsOkUpdateTemplate = false;
            }
        }
        private void CodeTextDown_Click(object sender, EventArgs e)
        {
            var row = dgv_ProtocolsActive_Main.CurrentCell.RowIndex;
            var rowToMove = dgv_ProtocolsActive_Main.Rows[row];
            if (row < dgv_ProtocolsActive_Main.Rows.Count - 1)
            {
                dgv_ProtocolsActive_Main.Rows.RemoveAt(row);
                dgv_ProtocolsActive_Main.Rows.Insert(row + 1, rowToMove);
                dgv_ProtocolsActive_Main.CurrentCell = dgv_ProtocolsActive_Main.Rows[row + 1].Cells[1];
                TemplateButtons.IsOkUpdateTemplate = false;
            }
        }
        private void NewCodeText_Enter(object sender, EventArgs e)
        {
            return;
            List<string> listCodeText = CodeText.dt_CodeText.AsEnumerable()
                .Select(row => row.Field<string>("CodeText"))
                .Where(codeText => !string.IsNullOrEmpty(codeText)) // Filter out empty code texts
                .Distinct() // Ensure uniqueness
                .ToList();

            var choose_Item = new Choose_Item(listCodeText, new[] { tb_NewCodeText }, false, true);
            choose_Item.ShowDialog();
        }
        private void NewUnit_Enter(object sender, EventArgs e)
        {
            List<string> listUnit = CodeText.dt_CodeText.AsEnumerable()
                .Select(row => row.Field<string>("Unit"))
                .Where(unit => !string.IsNullOrEmpty(unit)) // Filter out empty units
                .Distinct() // Ensure uniqueness
                .ToList();

            var choose_Item = new Choose_Item(listUnit, new[] { tb_NewUnit }, false, true);
            choose_Item.ShowDialog();
        }

        private void IsUsingExtraLineClearance_Click(object sender, EventArgs e)
        {
            ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;
        }

        private void Template_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_TemplateRevision.SelectedIndexChanged -= Template_RevisionNr_SelectedIndexChanged;

            preview?.Dispose();
            Fill_Template_RevisionNr();

            LoadData(true);

            cb_TemplateRevision.SelectedIndexChanged += Template_RevisionNr_SelectedIndexChanged;
        }
        private void Template_RevisionNr_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_ConnectPartNr_NewRevision.Visible = cb_TemplateRevision.Text != "A";

            if (TemplateButtons.IsOkUpdateTemplate == false)
            {
                InfoText.Question("Är du säker på att du vill ladda om mallen? Dina aktiva ändringar kommer att försvinna.", CustomColors.InfoText_Color.Warning, "Warning!", this);
                if (InfoText.answer == InfoText.Answer.No)
                    return;
            }

            LoadData(false);

        }
        private void TemplateName_TextChanged(object sender, EventArgs e)
        {
            TemplateButtons.isOkUpdateTemplate = false;
        }
        private void FilterCodeText_TextChanged(object sender, EventArgs e)
        {
            var filterCondition =
                $"[CodeTExt] LIKE '%{tb_FilterCodeText.Text}%' ";
            CodeText.dt_CodeText.DefaultView.RowFilter = filterCondition;
        }
        private async void FilterCodeText_Enter(object sender, EventArgs e)
        {
            await Task.Delay(10); // Small delay to ensure focus is properly set
            tb_FilterCodeText.SelectAll();
        }
        private void LoadData(bool isOkLoadRevision)
        {
            ClearTemplates();
            var lineClearance_Revision = string.Empty;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT FormTemplateID, ModuleName, formtemplate.MainTemplateID, maintemplate.Name as TemplateName, LineClearance_Template, MachineIndex, workoperation.Name as Workoperation, maintemplate.CreatedBy, maintemplate.CreatedDate
                    FROM Protocol.FormTemplate as formtemplate
                        JOIN Protocol.MainTemplate as maintemplate
                            ON formtemplate.MainTemplateID = maintemplate.ID
                        JOIN Workoperation.Names as workoperation
                            ON maintemplate.WorkoperationID = workoperation.ID
                        LEFT JOIN LineClearance.MainTemplate as lc
                            ON lc.ProtocolMainTemplateID = maintemplate.ID
                                AND lc.LineClearance_Revision = maintemplate.LineClearance_Template
                    WHERE formtemplate.MainTemplateID = (SELECT ID From Protocol.MainTemplate WHERE Name = @templatename AND Revision = @revision) 
                        AND TemplateOrder IS NOT NULL 
                    ORDER BY TemplateOrder, MachineIndex";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@templateName", cb_TemplateName.Text);
                cmd.Parameters.AddWithValue("@revision", cb_TemplateRevision.Text);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tb_Workoperation.Text = reader["Workoperation"].ToString();
                    lbl_CreatedBy.Text = $"{reader["CreatedBy"]}";
                    DateTime.TryParse(reader["CreatedDate"].ToString(), out DateTime dateTime);
                    lbl_CreatedDate.Text = dateTime.ToString("yyyy-MM-dd HH:mm");
                    lineClearance_Revision = reader["LineClearance_Template"].ToString();
                    var codetext = reader["ModuleName"].ToString();
                    int.TryParse(reader["FormTemplateID"].ToString(), out var formTemplateID);
                    MainTemplate.ID = int.Parse(reader["MainTemplateID"].ToString());
                    MainTemplate.Name = reader["TemplateName"].ToString();
                    int.TryParse(reader["MachineIndex"].ToString(), out var machindeIndex);

                    int? formtemplateID = formTemplateID;

                    tb_ModuleName.Text = codetext.Replace(" ", "").Replace("\n", "").Replace("\r", "");
                    if (isOkLoadRevision)
                        LoadRevisions();
                    AddModule(machindeIndex, formtemplateID);
                }
            }
            MainTemplate.Load_Data(cb_TemplateName.Text, cb_TemplateRevision.Text, chb_IsUsingPreFab, chb_IsProductionLineNeeded, cb_LineClearance_Revision, cb_MainInfo_Template);

            label_TotalConnectedProcesscards.Text = $"Antal Processkort kopplade till mallen: {TotalConnectedProcesscardsToTemplate}";
            label_TotalConnectedOrders.Text = $"Antal Ordrar kopplade till mallen: {TotalConnectedOrdersToTemplate}";
            MainTemplate.Revision = cb_TemplateRevision.Text;
            Fill_LineClearance_Templates();
            cb_LineClearance_Revision.SelectedValue = lineClearance_Revision;
            TemplateButtons.IsOkUpdateTemplate = true;
        }
        private void ClearTemplates()
        {
            flp_Main.Controls.Clear();
        }
        private void LoadRevisions()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query =
                    @"SELECT DISTINCT Revision FROM Protocol.Template WHERE FormTemplateID IN (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplate) ORDER BY Revision DESC";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@maintemplate", MainTemplate.ID);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    cb_TemplateRevision.Text = value.ToString();
            }
        }
        private void Manage_Templates_FormClosed(object sender, FormClosedEventArgs e)
        {
            Order.Restore_TempOrderInfo();
        }
        private void Manage_Templates_Resize(object sender, EventArgs e)
        {
            tlp_ExtraInfo.Left = ClientSize.Width - tlp_ExtraInfo.Width;
        }





        public class CodeText
        {
            public static void LoadData(DataGridView dgv)
            {
                dt_CodeText = new DataTable();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT 
                        description.ID, 
                        description.CodeText, 
                        unit.UnitName AS Unit
                    FROM Protocol.Description AS description
                    LEFT JOIN Protocol.Unit AS unit
                        ON description.UnitID = unit.ID
                    WHERE description.UnitID IS NOT NULL
                    ORDER BY description.CodeText";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    con.Open();
                    var dataAdapter = new SqlDataAdapter(query, con);
                    dataAdapter.Fill(dt_CodeText);
                    dgv.DataSource = dt_CodeText;
                }

                dgv.Columns[0].Visible = false;
                dgv.Columns[2].Visible = true;
            }
            public static DataTable? dt_CodeText;

            public static void InsertNewCodeText(string codeText, string unit)
            {
                int unitID;
                using var con = new SqlConnection(Database.cs_Protocol);
                ServerStatus.Add_Sql_Counter();
                con.Open();

                // 1. Kontrollera om Unit finns
                var cmdCheckUnit = new SqlCommand("SELECT ID FROM Protocol.Unit WHERE UnitName = @unit", con);
                cmdCheckUnit.Parameters.AddWithValue("@unit", unit);
                var result = cmdCheckUnit.ExecuteScalar();

                if (result != null)
                    unitID = Convert.ToInt32(result);
                else
                {
                    // Insert ny unit
                    var cmdInsertUnit = new SqlCommand("INSERT INTO Protocol.Unit (UnitName) VALUES (@unit); SELECT SCOPE_IDENTITY();", con);
                    cmdInsertUnit.Parameters.AddWithValue("@unit", unit);
                    unitID = Convert.ToInt32(cmdInsertUnit.ExecuteScalar());
                }

                // 2. Kontrollera om CodeText+UnitID finns
                var cmdCheckDescription = new SqlCommand("SELECT ID FROM Protocol.Description WHERE CodeText = @codetext AND UnitID = @unitid", con);
                cmdCheckDescription.Parameters.AddWithValue("@codetext", codeText);
                cmdCheckDescription.Parameters.AddWithValue("@unitid", unitID);
                var descrResult = cmdCheckDescription.ExecuteScalar();

                if (descrResult == null)
                {
                    var cmdInsertDescription = new SqlCommand("INSERT INTO Protocol.Description (CodeText, UnitID) VALUES (@codetext, @unitid)", con);
                    cmdInsertDescription.Parameters.AddWithValue("@codetext", codeText);
                    cmdInsertDescription.Parameters.AddWithValue("@unitid", unitID);
                    cmdInsertDescription.ExecuteNonQuery();
                }
            }
        }

        public class TemplateControls
        {
            private static FlowLayoutPanel? flp;
            private static PreviewTemplate? previewTemplate;
            public static bool IsCodeTextExistInModule(DataGridView dgv, string codeText)
            {
                if (dgv is null)
                    return true;
                for (var i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells["col_CodeText"].Value.ToString() == codeText)
                        return true;
                }
                return false;
            }

            public TemplateControls(FlowLayoutPanel? flp_Main, PreviewTemplate preview)
            {
                flp = flp_Main;
                previewTemplate = preview;
            }
            public static DataGridView Add_DataGridView(string name, int height, DockStyle dockStyle, bool isOKChangeBackColor, bool isUsingEvents)
            {
                var dgv = new DataGridView
                {
                    AllowDrop = true,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToResizeColumns = false,
                    AllowUserToResizeRows = false,
                    AllowUserToOrderColumns = false,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.Black,
                    ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                    Dock = dockStyle,
                    EnableHeadersVisualStyles = false,
                    EditMode = DataGridViewEditMode.EditOnEnter,
                    Height = height,
                    Margin = new Padding(0, 0, 0, 0),
                    MultiSelect = false,
                    Name = name,
                    RowHeadersVisible = false,
                    ScrollBars = ScrollBars.None,



                };


                if (isOKChangeBackColor)
                {
                    dgv.DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.FromArgb(6, 81, 87),
                        ForeColor = Color.FromArgb(255, 235, 156),
                        Alignment = DataGridViewContentAlignment.MiddleCenter,
                        Font = new Font("Lucida Sans", 8, FontStyle.Bold)
                    };
                    dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                    { BackColor = Color.FromArgb(45, 113, 122) };
                }

                if (isUsingEvents)
                {
                    dgv.Enter += Enter_dgv;
                    dgv.RowsAdded += RowsAdded_dgv;
                    dgv.RowsRemoved += RowsRemoved_dgv;
                    dgv.CurrentCellDirtyStateChanged += CurrentCellDirtyStateChanged;
                    dgv.CellValueChanged += Dgv_CellValueChanged;
                    dgv.ColumnHeaderMouseClick += CopyFirstRow;
                    dgv.AllowDrop = true;
                    dgv.RowEnter += RowEnter_dgv;
                    dgv.RowLeave += RowLeave_dgv;
                    dgv.CellClick += CellClick_dgv;
                }

                dgv.CellValueChanged += Update_PreviewTemplate;
                return dgv;
            }
            public static void AddColumn(DataGridView dgv, DataGridViewColumn col, string headerText, string name, int width = 0, bool IsVisible = true, bool IsDataSource = false)
            {
                col.HeaderText = headerText;
                col.HeaderCell.Style.WrapMode = DataGridViewTriState.True;
                col.Name = name;
                if (width != 0)
                    col.Width = width;
                else
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (IsDataSource && col is DataGridViewComboBoxColumn comboBoxColumn)
                {
                    comboBoxColumn.DataSource = Database.datatype;
                    comboBoxColumn.DisplayMember = "Name";
                    comboBoxColumn.ValueMember = "ID";
                }
                dgv.Columns.Add(col);
                col.Visible = IsVisible;
            }
            private static void CellClick_dgv(object? sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex > dgv_ProtocolsActive_Main.Columns.Count - 4)
                    TemplateButtons.IsOkUpdateTemplate = false;
            }

            private static void RowsAdded_dgv(object? sender, DataGridViewRowsAddedEventArgs e)
            {
                var dgv = (DataGridView)sender;
                ChangePanelHeight(dgv);
                if (flp is null || previewTemplate.IsDisposed)
                    return;
                previewTemplate.Update_Template(flp);
            }
            private static void RowsRemoved_dgv(object? sender, DataGridViewRowsRemovedEventArgs e)
            {
                var dgv = (DataGridView)sender;
                var parentControl = dgv.Parent;
                if (parentControl is Panel panel)
                    panel_Active = panel;
                ChangePanelHeight(dgv);
            }
            private static void Enter_dgv(object? sender, EventArgs e)
            {
                var dgv = (DataGridView)sender;
                dgv_ProtocolsActive_Main = dgv;
                var parentControl = dgv.Parent;
                if (parentControl is Panel panel)
                    panel_Active = panel;
                label_Active_ModuleName = panel_Active.Controls.OfType<Label>().FirstOrDefault();

            }
            private static void RowEnter_dgv(object? sender, DataGridViewCellEventArgs e)
            {
                dgv_ProtocolsActive_Main.Rows[e.RowIndex].Cells["col_Codetext"].Style.BackColor = Color.Khaki;
            }
            private static void RowLeave_dgv(object? sender, DataGridViewCellEventArgs e)
            {
                dgv_ProtocolsActive_Main.Rows[e.RowIndex].Cells["col_Codetext"].Style.BackColor = Color.White;
            }
            private static void CopyFirstRow(object? sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.ColumnIndex < 2)
                    return;
                var dgv = (DataGridView)sender;
                var value = dgv.Rows[0].Cells[e.ColumnIndex].Value;
                foreach (DataGridViewRow row in dgv.Rows)
                    row.Cells[e.ColumnIndex].Value = value;

            }
            public static void Update_PreviewTemplate(object? sender, DataGridViewCellEventArgs e)
            {
                if (flp is null || previewTemplate.IsDisposed)
                    return;
                previewTemplate.Update_Template(flp);
            }
            private static void CurrentCellDirtyStateChanged(object? sender, EventArgs e)
            {
                var dgv = (DataGridView)sender;
                if (dgv.IsCurrentCellDirty)
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (dgv.CurrentCell is DataGridViewCheckBoxCell)
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            private static void Dgv_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
            {
                var dgv = (DataGridView)sender;
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                switch (dgv.Columns[e.ColumnIndex].Name)
                {
                    case "col_DataType":
                        HandleDataTypeColumn(dgv, e.RowIndex);
                        break;

                    case "col_MIN":
                    case "col_NOM":
                    case "col_MAX":
                        HandleCheckboxColumn();
                        break;

                    default:
                        // Handle other cases if needed
                        break;
                }
            }
            private static void HandleDataTypeColumn(DataGridView dgv, int rowIndex)
            {
                var dataTypeID = (int)dgv.Rows[rowIndex].Cells["col_DataType"].Value;
                var decimalsCell = dgv.Rows[rowIndex].Cells["col_Decimals"];

                if (dataTypeID == 0)
                {
                    decimalsCell.ReadOnly = false;
                    decimalsCell.Style.BackColor = Color.White;
                }
                else
                {
                    decimalsCell.ReadOnly = true;
                    decimalsCell.Style.BackColor = Color.LightGray;
                }
            }

            // Handles checkbox column changes
            private static void HandleCheckboxColumn()
            {
                TemplateButtons.isOkUpdateTemplate = false; // Assuming you have this variable defined
            }
            private static void ChangePanelHeight(DataGridView dgv)
            {
                var combinedHeight = dgv.ColumnHeadersHeight + dgv.Rows.Cast<DataGridViewRow>().Sum(r => r.Height);
                panel_Active.Height = combinedHeight + 62;
            }

        }




        public class MainTemplate
        {
            public static string? Name { get; set; }
            public static int ID { get; set; }
            public static string? Revision { get; set; }
            public static bool IsUsingOven { get; set; }

            public static bool IsProcesscardUsingProdline
            {
                get
                {
                    using var con = new SqlConnection(Database.cs_Protocol);
                    const string query =
                        @"SELECT IsProdLineUsedInProcesscard FROM Protocol.MainTemplate WHERE ID = @maintemplateid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@maintemplateid", ID);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        return Convert.ToBoolean(result);

                    return false;
                }
            }
            public static bool IsTemplateConnectedToProcesscard(ref int total)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                    SELECT COUNT(*) FROM Processcard.MainData WHERE ProtocolMainTemplateID = @maintemplateid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@maintemplateid", ID);
                var value = cmd.ExecuteScalar();
                if (value != null)
                    int.TryParse(value.ToString(), out total);
                if (total > 0)
                    return true;

                return false;
            }
            public static bool IsTemplateConnectedToOrderNr(ref int total)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT COUNT(*) FROM [Order].MainData WHERE ProtocolMainTemplateID = @maintemplateid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        int.TryParse(value.ToString(), out total);
                    if (total > 0)
                        return true;
                }

                return false;
            }
            public static bool IsTemplateExist(string name, string revision)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        SELECT * FROM Protocol.MainTemplate WHERE Name = @name AND Revision = @revision";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@revision", revision);
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                }

                return false;
            }
            public static int Old_MainTemplateID(int partID)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        SELECT ProtocolMainTemplateID FROM Processcard.MainData WHERE PartID = @partid";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partID", partID);
                    object value = cmd.ExecuteScalar();
                    if (value != null)
                        return int.Parse(value.ToString());
                }

                return 0;
            }

            public static void Load_MainTemplateID(string templateName, string revision)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query =
                    @"SELECT ID FROM Protocol.MainTemplate WHERE Name = @name AND Revision = @revision";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@name", templateName);
                cmd.Parameters.AddWithValue("@revision", revision);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    ID = int.Parse(value.ToString());
            }
            public static void Set_MainTemplateID(ref bool IsOkStartOrder)
            {
                if (Order.PartID != null)
                {
                    using var con = new SqlConnection(Database.cs_Protocol);
                    const string query =
                        @"SELECT ProtocolMainTemplateID FROM Processcard.MainData WHERE PartID = @partid";
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

                var chooseTemplate = new ProcesscardTemplateSelector(ProcesscardTemplateSelector.TemplateType.TemplateProtocol);
                chooseTemplate.ShowDialog();
                if (chooseTemplate.IsAborted)
                    IsOkStartOrder = false;

            }
            public static void Set_MainTemplateID(string name, string revision)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                    SELECT ID FROM Protocol.MainTemplate WHERE Name = @name AND Revision = @revision";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@revision", revision);
                ID = (int)cmd.ExecuteScalar();
            }
            public static void Load_Data(string name, string revision, CheckBox chb_UsingPreFab, CheckBox chb_IsUsingProdLine, ComboBox cb_LineClearanceTemplate, ComboBox cb_MainInfoTemplate)
            {
                try
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        const string query = @"
                            SELECT ID, IsUsingPreFab, IsProdLineUsedInProcesscard, LineClearance_Template, MainInfo_Template
                            FROM Protocol.MainTemplate as protocol
                            WHERE Name = @name AND Revision = @revision";
                        using (var cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@revision", revision);
                            con.Open();
                            using (var reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    if (bool.TryParse(reader["IsUsingPreFab"].ToString(), out var isUsingPreFab))
                                        chb_UsingPreFab.Checked = isUsingPreFab;
                                    if (bool.TryParse(reader["IsProdLineUsedInProcesscard"].ToString(), out var isUsingProdLine))
                                        chb_IsUsingProdLine.Checked = isUsingProdLine;

                                    cb_LineClearanceTemplate.Text = reader["LineClearance_Template"]?.ToString() ?? "Standard";
                                    cb_MainInfoTemplate.Text = reader["MainInfo_Template"]?.ToString() ?? string.Empty;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    InfoText.Show($"Error:\n {e.Message}", CustomColors.InfoText_Color.Bad, "Warning");
                }
            }
            public static void Save_NewTemplate(string templateName, string revision, bool isUsingPrefab, bool isUsingProdLine, string? lineClearanceTemplate, string mainInfoTemplate, string workoperation, FlowLayoutPanel flp)
            {
                Save_Data(templateName, revision, isUsingPrefab, isUsingProdLine, lineClearanceTemplate, mainInfoTemplate, workoperation);

                var templateOrder = 0;
                foreach (Panel panel in flp.Controls)
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

                    int.TryParse(dgv_FormTemplate.Rows[0].Cells["col_MachineIndex"].Value.ToString(), out var machineIndex);
                    if (machineIndex > 1)
                        templateOrder--;
                    FormTemplate.Save_Data(templateName, revision, dgv_FormTemplate, label_Name.Text, templateOrder);
                    Template.Save_Data(templateName, dgv_Template, revision, templateOrder, machineIndex, 0);
                    templateOrder++;
                }
            }
            public static void Save_Data(string name, string revision, bool isUsingPreFab, bool isUsingProdLine, string? lineClearanceTemplate, string mainInfoTemplate, string workoperation)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query =
                        @"
                        IF NOT EXISTS 
                            (
                                SELECT * FROM Protocol.MainTemplate 
                                WHERE Name = @name AND Revision = @revision
                            )
                        INSERT INTO Protocol.MainTemplate 
                            (
                                Name, 
                                Revision, 
                                IsUsingPreFab, 
                                IsProdLineUsedInProcesscard, 
                                LineClearance_Template, 
                                MainInfo_Template, 
                                WorkoperationID, 
                                CreatedBy, 
                                CreatedDate
                            )
                        VALUES 
                            (
                                @name, 
                                @revision, 
                                @isusingprefab, 
                                @isusingprodline, 
                                @lineclearancetemplate, 
                                @maininfotemplate, 
                                (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation), 
                                @createdby, 
                                @createddate
                            )";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@revision", revision);
                    cmd.Parameters.AddWithValue("@isusingprefab", isUsingPreFab);
                    cmd.Parameters.AddWithValue("@isusingprodline", isUsingProdLine);
                    SQL_Parameter.String(cmd.Parameters, "@lineclearancetemplate", lineClearanceTemplate);
                    cmd.Parameters.AddWithValue("@maininfotemplate", mainInfoTemplate);
                    cmd.Parameters.AddWithValue("@workoperation", workoperation);
                    cmd.Parameters.AddWithValue("@createdby", Person.Name);
                    cmd.Parameters.AddWithValue("@createddate", DateTime.Now);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            public static void Update_Data(bool isUsingPreFab, string lineClearanceTemplate)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query =
                        @"
                            UPDATE Protocol.MainTemplate 
                            SET 
                                IsUsingPreFab = @isusingprefab, 
                                LineClearance_Template = @lineclearancetemplate
                            WHERE ID = @protocolmaintemplateid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@protocolmaintemplateid", ID);
                    cmd.Parameters.AddWithValue("@isusingprefab", isUsingPreFab);
                    cmd.Parameters.AddWithValue("@lineclearancetemplate", lineClearanceTemplate);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            public static void Delete_Template(string templateName, string revision, bool isOkAskQuestion)
            {
                if (isOkAskQuestion)
                {
                    InfoText.Question($"Är du säker på att du vill radera mallen '{templateName}-{revision}'? \n" +
                                      "Det går INTE att ångra detta!\n" +
                                      "Vill du fortsätta?", CustomColors.InfoText_Color.Warning, "Warning");
                    if (InfoText.answer == InfoText.Answer.No)
                        return;
                }

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    DELETE FROM Protocol.Template WHERE FormTemplateID IN (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @oldmaintemplateid)
                    DELETE FROM Protocol.FormTemplate WHERE MainTemplateID = @oldmaintemplateid
                    DELETE FROM Protocol.MainTemplate WHERE ID = @oldmaintemplateid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@oldmaintemplateid", ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public class FormTemplate
        {
            public static void AddColumns_dgv_FormTemplate(DataGridView dgv)
            {
                dgv.ColumnHeadersHeight = 33;
                dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "Rubrik synlig?", "col_IsHeaderVisible", 115);
                TemplateControls.AddColumn(dgv, new DataGridViewTextBoxColumn(), "Maskin Index", "col_MachineIndex", 60);
                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "Behöver autentiseras", "col_IsAuthenticationNeeded", 120);
                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "Multipla kolumner i Uppstart", "col_IsMultipleColumnsStartUp", 120);
                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "Används datum för Uppstart?", "col_IsStartUpDates", 100);
                TemplateControls.AddColumn(dgv, new DataGridViewTextBoxColumn(), "Kolumnbredd Processkort", "col_ProcesscardWidth", 100);
                TemplateControls.AddColumn(dgv, new DataGridViewTextBoxColumn(), "Kolumnbredd Körprotokoll", "col_RunProtocolWidth", 100);

                dgv.Rows.Add(false, 1, false, false, false, 50, 50);
            }
            public static void Load_Data(int? formTemplateID, string templateName, string templateRevision, int machineIndex)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT IsHeaderVisible, MachineIndex, IsAuthenticationNeeded, IsMultipleColumnsStartUp, IsStartUpDates, Processcard_ColWidth, RunProtocol_ColWidth
                    FROM Protocol.FormTemplate
                    WHERE FormTemplateID = @formtemplateid
                        AND MainTemplateID = (SELECT ID From Protocol.MainTemplate WHERE Name = @name AND Revision = @revision)
                        AND MachineIndex = @machineIndex";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@formtemplateid", formTemplateID);
                    cmd.Parameters.AddWithValue("@name", templateName);
                    cmd.Parameters.AddWithValue("@revision", templateRevision);
                    cmd.Parameters.AddWithValue("@machineIndex", machineIndex);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        bool.TryParse(reader["IsHeaderVisible"].ToString(), out var isHeaderVisible);
                        dgv_Active_ModuleInfo.Rows[0].Cells["col_IsHeaderVisible"].Value =
                            isHeaderVisible;

                        dgv_Active_ModuleInfo.Rows[0].Cells["col_MachineIndex"].Value =
                            machineIndex;

                        bool.TryParse(reader["IsAuthenticationNeeded"].ToString(), out var isAuthenticationNeeded);
                        dgv_Active_ModuleInfo.Rows[0].Cells["col_IsAuthenticationNeeded"].Value =
                            isAuthenticationNeeded;

                        bool.TryParse(reader["IsMultipleColumnsStartUp"].ToString(),
                            out var isMultipleColumnsStartUp);
                        dgv_Active_ModuleInfo.Rows[0].Cells["col_IsMultipleColumnsStartUp"].Value =
                            isMultipleColumnsStartUp;

                        bool.TryParse(reader["IsStartUpDates"].ToString(), out var isStartUpDates);
                        dgv_Active_ModuleInfo.Rows[0].Cells["col_IsStartUpDates"].Value =
                            isStartUpDates;

                        int.TryParse(reader["Processcard_ColWidth"].ToString(), out var pcColWidth);
                        dgv_Active_ModuleInfo.Rows[0].Cells["col_ProcesscardWidth"].Value =
                            pcColWidth;

                        int.TryParse(reader["RunProtocol_ColWidth"].ToString(), out var rpColWidth);
                        dgv_Active_ModuleInfo.Rows[0].Cells["col_RunProtocolWidth"].Value =
                            rpColWidth;

                    }
                }
            }
            public static void Save_Data(string templateName, string revision, DataGridView dgv, string moduleName, int templateOrder)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        MERGE INTO Protocol.FormTemplate AS target
                        USING (SELECT (SELECT ID FROM Protocol.MainTemplate WHERE Name = @templatename AND Revision = @revision) AS MainTemplateID) AS source
                            ON target.ModuleName = @modulename
                            AND target.MachineIndex = @machineindex
                            AND target.MainTemplateID = source.MainTemplateID
                        WHEN MATCHED THEN
                        UPDATE SET 
                            target.ModuleName = @modulename, 
                            target.IsHeaderVisible = @isheadervisible, 
                            target.MachineIndex = @machineIndex, 
                            target.IsAuthenticationNeeded = @isauthenticationneeded, 
                            target.IsMultipleColumnsStartup = @ismultiplecolumnsstartup, 
                            target.IsStartUpDates = @isstartupdates, 
                            target.Processcard_ColWidth = @processcardColwidth, 
                            target.RunProtocol_ColWidth = @runprotocolColwidth
                        WHEN NOT MATCHED THEN
                        INSERT 
                        (
                            TemplateOrder, 
                            ModuleName, 
                            IsHeaderVisible, 
                            MachineIndex, 
                            IsAuthenticationNeeded, 
                            IsMultipleColumnsStartup, 
                            IsStartUpDates, 
                            Processcard_ColWidth, 
                            RunProtocol_ColWidth, 
                            MainTemplateID
                        )
                        VALUES 
                        (
                            @templateorder, 
                            @modulename, 
                            @isheadervisible, 
                            @machineIndex, 
                            @isauthenticationneeded, 
                            @ismultiplecolumnsstartup, 
                            @isstartupdates, 
                            @processcardColwidth, 
                            @runprotocolColwidth, 
                            source.MainTemplateID
                        );";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@templatename", templateName);
                    cmd.Parameters.AddWithValue("@revision", revision);

                    cmd.Parameters.AddWithValue("@templateorder", templateOrder);
                    cmd.Parameters.AddWithValue("@modulename", moduleName.Replace("\n", ""));
                    SQL_Parameter.Boolean(cmd.Parameters, "@isheadervisible", dgv.Rows[0].Cells["col_IsHeaderVisible"].Value, true);
                    SQL_Parameter.Int(cmd.Parameters, "@machineIndex", dgv.Rows[0].Cells["col_MachineIndex"].Value);
                    SQL_Parameter.Boolean(cmd.Parameters, "@isauthenticationneeded", dgv.Rows[0].Cells["col_IsAuthenticationNeeded"].Value, true);
                    SQL_Parameter.Boolean(cmd.Parameters, "@ismultiplecolumnsstartup", dgv.Rows[0].Cells["col_IsMultipleColumnsStartup"].Value, true);
                    SQL_Parameter.Boolean(cmd.Parameters, "@isstartupdates", dgv.Rows[0].Cells["col_IsStartUpDates"].Value, true);
                    SQL_Parameter.Int(cmd.Parameters, "@processcardColwidth", dgv.Rows[0].Cells["col_ProcesscardWidth"].Value);
                    SQL_Parameter.Int(cmd.Parameters, "@runprotocolColwidth", dgv.Rows[0].Cells["col_RunProtocolWidth"].Value);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            //public static void Update_Data(string templateName, string moduleName, string revision, DataGridView dgv, int formtemplateid)
            //{
            //    using (var con = new SqlConnection(Database.cs_Protocol))
            //    {
            //        const string query = @"
            //            UPDATE Protocol.FormTemplate 
            //            SET ModuleName = @modulename, IsHeaderVisible = @isheadervisible, MachineIndex = @machineIndex, IsAuthenticationNeeded = @isauthenticationneeded, IsMultipleColumnsStartup = @ismultiplecolumnsstartup, IsStartUpDates = @isstartupdates, Processcard_ColWidth = @processcardColwidth, RunProtocol_ColWidth = @runprotocolColwidth
            //            WHERE FormTemplateID = @formtemplateid
            //                AND MainTemplateID = (SELECT ID FROM Protocol.MainTemplate WHERE Name = @templatename AND Revision = @revision)
            //                AND MachineIndex = @machineindex";
            //        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            //        cmd.Parameters.AddWithValue("@templatename", templateName);
            //        cmd.Parameters.AddWithValue("@revision", revision);
            //        cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
            //        cmd.Parameters.AddWithValue("@modulename", moduleName.Replace(" ", "").Replace("\n", "").Replace("\r", ""));
            //        SQL_Parameter.Boolean(cmd.Parameters, "@isheadervisible", dgv.Rows[0].Cells["col_IsHeaderVisible"].Value, true);
            //        SQL_Parameter.Int(cmd.Parameters, "@machineIndex", dgv.Rows[0].Cells["col_MachineIndex"].Value);
            //        SQL_Parameter.Boolean(cmd.Parameters, "@isauthenticationneeded",
            //            dgv.Rows[0].Cells["col_IsAuthenticationNeeded"].Value, true);
            //        SQL_Parameter.Boolean(cmd.Parameters, "@ismultiplecolumnsstartup",
            //            dgv.Rows[0].Cells["col_IsMultipleColumnsStartup"].Value, true);
            //        SQL_Parameter.Boolean(cmd.Parameters, "@isstartupdates",
            //            dgv.Rows[0].Cells["col_IsStartUpDates"].Value, true);
            //        SQL_Parameter.Int(cmd.Parameters, "@processcardColwidth",
            //            dgv.Rows[0].Cells["col_ProcesscardWidth"].Value);
            //        SQL_Parameter.Int(cmd.Parameters, "@runprotocolColwidth",
            //            dgv.Rows[0].Cells["col_RunProtocolWidth"].Value);
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }
        public class Template
        {
            public static int? ID(int row, int col, string revision, int formTemplateid)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT ID FROM Protocol.Template 
                    WHERE FormTemplateID = @formtemplateid
                        AND ColumnIndex = @colindex
                        AND RowIndex = @rowIndex 
                        AND revision = @revision";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@formtemplateid", formTemplateid);
                    cmd.Parameters.AddWithValue("@rowIndex", row);
                    cmd.Parameters.AddWithValue("@colindex", col);
                    cmd.Parameters.AddWithValue("@revision", revision);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    return (int?)value;
                }
            }

            public static void AddColumns_dgv_Template(DataGridView dgv)
            {
                TemplateControls.AddColumn(dgv, new DataGridViewTextBoxColumn(), "ProtocolDescriptionID", "col_ProtocolDescriptionID", 1, false);
                TemplateControls.AddColumn(dgv, new DataGridViewTextBoxColumn(), "CodeText", "col_Codetext", 180);
                TemplateControls.AddColumn(dgv, new DataGridViewTextBoxColumn(), "Enhet", "col_Unit", 46);
                TemplateControls.AddColumn(dgv, new DataGridViewComboBoxColumn(), "Data Type", "col_DataType", 74, true, true);
                TemplateControls.AddColumn(dgv, new DataGridViewTextBoxColumn(), "Decimaler", "col_Decimals", 65);
                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "Används i Processkort?", "col_UsedInProcesscard", 90);
                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "Värde kritiskt?", "col_ValueCritical", 65);
                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "Lista Processkort?", "col_ProcesscardList", 90);
                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "Lista Körprotokoll?", "col_ProtocolList", 90);
                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "Ok, skriva text?", "col_IsOkWriteOwnText", 70);
                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "Obligatoriskt fält?", "col_Required", 85);

                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "MIN", "col_MIN", 35);
                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "NOM", "col_NOM", 35);
                TemplateControls.AddColumn(dgv, new DataGridViewCheckBoxColumn(), "MAX", "col_MAX", 35);


                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8.0F, FontStyle.Bold);
                foreach (DataGridViewColumn column in dgv.Columns)
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            public static void Load_Data(string revision, int? formTemplateID)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                SELECT 
                    template.ProtocolDescriptionID, 
                    description.CodeText, 
                    unit.UnitName AS Unit, 
                    template.ColumnIndex, 
                    template.RowIndex, 
                    template.Type, 
                    template.Decimals, 
                    template.IsUsedInProcesscard, 
                    template.IsValueCritical, 
                    template.IsList_Processcard, 
                    template.IsList_Protocol, 
                    template.IsOkWriteText, 
                    template.IsRequired
                FROM Protocol.Template AS template
                INNER JOIN Protocol.Description AS description
                    ON template.ProtocolDescriptionID = description.ID
                LEFT JOIN Protocol.Unit AS unit
                    ON description.UnitID = unit.ID
                WHERE template.FormTemplateID = @formtemplateid
                    AND template.Revision = @revision
                    AND template.RowIndex IS NOT NULL
                ORDER BY template.RowIndex, template.ColumnIndex";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@formtemplateid", formTemplateID);
                cmd.Parameters.AddWithValue("@revision", revision);
                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int.TryParse(reader["ProtocolDescriptionID"].ToString(), out var protocoldescriptionID);
                    var codetext = reader["CodeText"].ToString();

                    int.TryParse(reader["Type"].ToString(), out var type);
                    bool.TryParse(reader["IsRequired"].ToString(), out var isRequired);
                    bool.TryParse(reader["IsOkWriteText"].ToString(), out var isOkWriteText);

                    if (bool.TryParse(reader["IsUsedInProcesscard"].ToString(), out var isUsedInProcesscard) ==
                        false)
                        isUsedInProcesscard = true;
                    if (bool.TryParse(reader["IsValueCritical"].ToString(), out var isNomValueCritical) ==
                        false)
                        isNomValueCritical = true;
                    if (bool.TryParse(reader["IsList_Processcard"].ToString(), out var isListProcesscard) ==
                        false)
                        isListProcesscard = true;
                    if (bool.TryParse(reader["IsList_Protocol"].ToString(), out var isListProtocol) == false)
                        isListProtocol = true;


                    if (TemplateControls.IsCodeTextExistInModule(dgv_ProtocolsActive_Main, codetext) == false)
                    {
                        dgv_ProtocolsActive_Main.Rows.Add();
                        dgv_ProtocolsActive_Main.Rows[^1].Cells["col_ProtocolDescriptionID"]
                            .Value = protocoldescriptionID;
                        dgv_ProtocolsActive_Main.Rows[^1].Cells["col_Unit"].Value = reader["Unit"].ToString();
                        dgv_ProtocolsActive_Main.Rows[^1].Cells["col_CodeText"].Value = reader["CodeText"].ToString();
                        dgv_ProtocolsActive_Main.Rows[^1].Cells["col_IsOkWriteOwnText"].Value = isOkWriteText;

                    }

                    if (int.TryParse(reader["Decimals"].ToString(), out var decimals))
                        dgv_ProtocolsActive_Main.Rows[^1].Cells["col_Decimals"].Value = decimals;
                    else
                        dgv_ProtocolsActive_Main.Rows[^1].Cells["col_Decimals"].Value = string.Empty;

                    if (int.TryParse(reader["ColumnIndex"].ToString(), out var column))
                    {
                        switch (column)
                        {
                            case 0:
                                dgv_ProtocolsActive_Main.Rows[^1].Cells["col_MIN"].Value = true;
                                break;
                            case 1:
                                dgv_ProtocolsActive_Main.Rows[^1].Cells["col_NOM"].Value = true;
                                break;
                            case 2:
                                dgv_ProtocolsActive_Main.Rows[^1].Cells["col_MAX"].Value =
                                    true;
                                break;
                        }
                    }
                    else
                    {
                        dgv_ProtocolsActive_Main.Rows[^1].Cells["col_MIN"].Value = false;
                        dgv_ProtocolsActive_Main.Rows[^1].Cells["col_NOM"].Value = false;
                        dgv_ProtocolsActive_Main.Rows[^1].Cells["col_MAX"].Value = false;
                    }

                    dgv_ProtocolsActive_Main.Rows[^1].Cells["col_DataType"].Value = type;
                    dgv_ProtocolsActive_Main.Rows[^1].Cells["col_UsedInProcesscard"].Value = isUsedInProcesscard;
                    dgv_ProtocolsActive_Main.Rows[^1].Cells["col_ValueCritical"].Value = isNomValueCritical;
                    dgv_ProtocolsActive_Main.Rows[^1].Cells["col_ProcesscardList"].Value = isListProcesscard;
                    dgv_ProtocolsActive_Main.Rows[^1].Cells["col_ProtocolList"].Value = isListProtocol;
                    dgv_ProtocolsActive_Main.Rows[^1].Cells["col_IsOKWriteOwnText"].Value = isOkWriteText;
                    dgv_ProtocolsActive_Main.Rows[^1].Cells["col_Required"].Value = isRequired;
                }
            }
            public static void Save_Data(string templateName, DataGridView dgv, string revision, int templateOrder, int machineIndex, int formTemplateID)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open(); // Open connection ONCE

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    var columnIndex = 0;

                    bool isUsedInProcesscard = row.Cells["col_UsedInProcesscard"].Value != null &&
                                               bool.TryParse(row.Cells["col_UsedInProcesscard"].Value.ToString(), out bool temp) && temp;

                    // Get FormTemplateID once and reuse it
                    if (formTemplateID == 0)
                    {
                        using var cmd = new SqlCommand(@"
                                SELECT FormTemplateID FROM Protocol.FormTemplate 
                                WHERE MainTemplateID = (SELECT ID FROM Protocol.MainTemplate WHERE Name = @templatename AND Revision = @revision) 
                                    AND TemplateOrder = @templateorder 
                                    AND MachineIndex = @machineindex", con);
                        cmd.Parameters.AddWithValue("@templatename", templateName);
                        cmd.Parameters.AddWithValue("@revision", revision);
                        cmd.Parameters.AddWithValue("@templateorder", templateOrder);
                        cmd.Parameters.AddWithValue("@machineindex", machineIndex);
                        var value = cmd.ExecuteScalar();
                        int.TryParse(value.ToString(), out formTemplateID);
                    }

                    for (var col = dgv.Columns.Count - 3; col < dgv.Columns.Count; col++)
                    {
                        // Existing insert/update logic
                        bool IsColumnUsed = row.Cells[col].Value != null &&
                                            bool.TryParse(row.Cells[col].Value.ToString(), out temp) && temp;
                        if (IsColumnUsed || columnIndex == 1)
                        {
                            using var cmd = new SqlCommand(@"
                               INSERT INTO Protocol.Template 
                                   (
                                       Revision, 
                                       FormTemplateID, 
                                       ColumnIndex, 
                                       RowIndex, 
                                       Type, 
                                       Decimals, 
                                       IsUsedInProcesscard, 
                                       IsValueCritical, 
                                       IsList_Processcard, 
                                       IsList_Protocol, 
                                       IsOkWriteText, 
                                       IsRequired, 
                                       ProtocolDescriptionID
                                   )
                               VALUES 
                                   (
                                       @revision, 
                                       @formtemplateid, 
                                       @columnindex, 
                                       @rowindex, 
                                       @type, 
                                       @decimals, 
                                       @isusedinprocesscard, 
                                       @isvaluecritical, 
                                       @islistprocesscard, 
                                       @islistprotocol, 
                                       @isokwriteowntext, 
                                       @isrequired, 
                                       @protocoldescriptionid
                                   )", con);
                            cmd.Parameters.AddWithValue("@revision", (object)revision ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@formtemplateid", formTemplateID);
                            if (isUsedInProcesscard)
                                cmd.Parameters.AddWithValue("@columnindex", columnIndex);
                            else
                                cmd.Parameters.AddWithValue("@columnindex", DBNull.Value);
                            cmd.Parameters.AddWithValue("@rowindex", row.Index);
                            SQL_Parameter.Int(cmd.Parameters, "@type", row.Cells["col_DataType"].Value);
                            SQL_Parameter.Int(cmd.Parameters, "@decimals", row.Cells["col_Decimals"].Value);
                            SQL_Parameter.Int(cmd.Parameters, "@protocoldescriptionid", row.Cells["col_ProtocolDescriptionID"].Value);
                            SQL_Parameter.Boolean(cmd.Parameters, "@isusedinprocesscard", row.Cells["col_UsedInProcesscard"].Value, true);
                            SQL_Parameter.Boolean(cmd.Parameters, "@isvaluecritical", row.Cells["col_ValueCritical"].Value, true);
                            SQL_Parameter.Boolean(cmd.Parameters, "@islistprocesscard", row.Cells["col_ProcesscardList"].Value, true);
                            SQL_Parameter.Boolean(cmd.Parameters, "@islistprotocol", row.Cells["col_ProtocolList"].Value, true);
                            SQL_Parameter.Boolean(cmd.Parameters, "@isokwriteowntext", row.Cells["col_IsOkWriteOwnText"].Value, true);
                            SQL_Parameter.Boolean(cmd.Parameters, "@isrequired", row.Cells["col_Required"].Value, true);

                            cmd.ExecuteNonQuery();
                        }

                        columnIndex++;
                    }

                }
            }

            public static void Update_Data(string templateName, DataGridView dgv, string revision, int templateOrder, int machineIndex, int formTemplateID)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open(); // Open connection ONCE

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        var columnIndex = 0;

                        bool isUsedInProcesscard = row.Cells["col_UsedInProcesscard"].Value != null &&
                                                   bool.TryParse(row.Cells["col_UsedInProcesscard"].Value.ToString(), out bool temp) && temp;

                        // Get FormTemplateID once and reuse it
                        if (formTemplateID == 0)
                        {
                            //formtemplateid bör aldrig vara 0 vid update så detta bör kunna tas bort
                            using (var cmd = new SqlCommand(@"
                                SELECT FormTemplateID FROM Protocol.FormTemplate 
                                WHERE MainTemplateID = (SELECT ID FROM Protocol.MainTemplate WHERE Name = @templatename AND Revision = @revision) 
                                    AND TemplateOrder = @templateorder 
                                    AND MachineIndex = @machineindex", con))
                            {
                                cmd.Parameters.AddWithValue("@templatename", templateName);
                                cmd.Parameters.AddWithValue("@revision", revision);
                                cmd.Parameters.AddWithValue("@templateorder", templateOrder);
                                cmd.Parameters.AddWithValue("@machineindex", machineIndex);
                                var value = cmd.ExecuteScalar();
                                int.TryParse(value.ToString(), out formTemplateID);
                            }
                        }

                        for (var col = dgv.Columns.Count - 3; col < dgv.Columns.Count; col++)
                        {
                            using (var cmd = new SqlCommand(@"
                              
                               UPDATE Protocol.Template
                                   SET 
                                       Type = @type, 
                                       Decimals = @decimals, 
                                       IsUsedInProcesscard = @isusedinprocesscard, 
                                       IsValueCritical = @isvaluecritical, 
                                       IsList_Processcard = @islistprocesscard, 
                                       IsList_Protocol = @islistprotocol, 
                                       IsOkWriteText = @isokwriteowntext, 
                                       IsRequired = @isrequired
                                   WHERE FormTemplateID = @formtemplateid 
                                       AND ProtocolDescriptionID = @protocoldescriptionid
                                       AND (ColumnIndex = @columnindex OR ISNULL(ColumnIndex, '') = '')
                                       AND RowIndex = @rowindex", con))
                            {
                                SQL_Parameter.Int(cmd.Parameters, "@type", row.Cells["col_DataType"].Value);
                                SQL_Parameter.Int(cmd.Parameters, "@decimals", row.Cells["col_Decimals"].Value);
                                SQL_Parameter.Boolean(cmd.Parameters, "@isusedinprocesscard", row.Cells["col_UsedInProcesscard"].Value, true);
                                SQL_Parameter.Boolean(cmd.Parameters, "@isvaluecritical", row.Cells["col_ValueCritical"].Value, true);
                                SQL_Parameter.Boolean(cmd.Parameters, "@islistprocesscard", row.Cells["col_ProcesscardList"].Value, true);
                                SQL_Parameter.Boolean(cmd.Parameters, "@islistprotocol", row.Cells["col_ProtocolList"].Value, true);
                                SQL_Parameter.Boolean(cmd.Parameters, "@isokwriteowntext", row.Cells["col_IsOkWriteOwnText"].Value, true);
                                SQL_Parameter.Boolean(cmd.Parameters, "@isrequired", row.Cells["col_Required"].Value, true);

                                cmd.Parameters.AddWithValue("@formtemplateid", formTemplateID);
                                SQL_Parameter.Int(cmd.Parameters, "@protocoldescriptionid", row.Cells["col_ProtocolDescriptionID"].Value);
                                if (isUsedInProcesscard)
                                    cmd.Parameters.AddWithValue("@columnindex", columnIndex);
                                else
                                    cmd.Parameters.AddWithValue("@columnindex", DBNull.Value);
                                cmd.Parameters.AddWithValue("@rowindex", row.Index);

                                cmd.ExecuteNonQuery();
                            }

                            columnIndex++;
                        }

                    }
                } // Connection disposed here

            }
        }

        
    }
}



