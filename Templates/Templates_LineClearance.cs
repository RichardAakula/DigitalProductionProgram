using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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

namespace DigitalProductionProgram.Templates
{
    public partial class Templates_LineClearance : Form
    {
        public static DataGridView dgv_LineClearance_Active_Main;
        public static Panel panel_Active;
        //public static Label label_Active_Category;
        public PreviewTemplate? preview;

        public static List<string> List_TemplateNames = new List<string>();
        public static List<string> List_RevisionNr = new List<string>();
        public static List<int> List_ProtocolMainTemplateID = new List<int>();

        public static bool IsOkUpdateTemplate = true;
        private bool IsOkSaveTemplate()
        {
            if (string.IsNullOrEmpty(cb_TemplateRevision.Text))
            {
                InfoText.Show("Fyll i mallens RevisionsNr före du sparar mallen för Line-Clearance.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return false;
            }
            if (string.IsNullOrEmpty(cb_TemplateName.Text))
            {
                InfoText.Show("Du måste välja en Protokoll-Mall före du försöker spara mallen för Line-Clearance.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return false;
            }
            if (flp_Main.Controls.Cast<Panel>().SelectMany(panel => panel.Controls.OfType<DataGridView>()).Any(dgv => dgv.Rows.Count == 0))
            {
                InfoText.Show("Någon av Kategorierna saknar åtgärder, du kan inte spara mallen utan åtgärder i alla Kategorier.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return false;
            }

            return true;
        }

        public static Templates_LineClearance? manage_LineClearanceTemplates;

        public Templates_LineClearance()
        {
            Order.Save_TempOrderInfo();
            manage_LineClearanceTemplates = this;
            InitializeComponent();
            Tasks.LoadData(dgv_Tasks);
            Fill_MainTemplate_Names();
            Load_AutoCompleteCategoryText();
            Load_AutoCompleteCenturiLink();
            Load_PDF();
        }


        private void Fill_MainTemplate_Names()
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
                        ID,
                        ROW_NUMBER() OVER (PARTITION BY Name ORDER BY Revision DESC) AS rn
                    FROM 
                    Protocol.MainTemplate
                )
                SELECT 
                    Name,
                    ID
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
                    List_ProtocolMainTemplateID.Add(int.Parse(reader["Id"].ToString()));
                }
            }

            cb_TemplateName.SelectedIndexChanged += Template_Name_SelectedIndexChanged;
        }

        private void Load_AutoCompleteCategoryText()
        {
            var autoCompleteCollection = new AutoCompleteStringCollection();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT DISTINCT Category FROM LineClearance.FormTemplate";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    autoCompleteCollection.Add(reader["Category"].ToString());
            }
            tb_Category.AutoCompleteMode = AutoCompleteMode.Suggest;
            tb_Category.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_Category.AutoCompleteCustomSource = autoCompleteCollection;

        }
        private void Load_AutoCompleteCenturiLink()
        {
            var autoCompleteCollection = new AutoCompleteStringCollection();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT DISTINCT CenturiLink FROM LineClearance.MainTemplate";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    autoCompleteCollection.Add(reader["CenturiLink"].ToString());
            }
            tb_Centuri.AutoCompleteMode = AutoCompleteMode.Suggest;
            tb_Centuri.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_Centuri.AutoCompleteCustomSource = autoCompleteCollection;

        }
        private void Load_PDF()
        {
            var filePath = Path.Combine(Path.GetTempPath(), "Guide - Templates.pdf");
            File.WriteAllBytes(filePath, Properties.Resources.GuideLineClearanceTemplates);
            web_PDF_Viewer.Navigate(filePath); // Load the PDF into the WebBrowser control
        }


        private void NewModule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Category.Text))
            {
                InfoText.Show("Fyll i namnet på kategorin före du försöker lägga till en kategori.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                ControlValidator.SoftBlink(tb_Category, CustomColors.Bad_Front, CustomColors.Bad_Back);
                return;
            }

            if (string.IsNullOrEmpty(cb_TemplateName.Text))
            {
                InfoText.Show("Välj först en protokoll-mall som du vill koppla LineClearance mot.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                ControlValidator.SoftBlink(cb_TemplateName, CustomColors.Bad_Front, CustomColors.Bad_Back);
                return;
            }
            AddCategory();
            tb_Category.Text = string.Empty;
        }
        private void NewRevision_MouseDown(object sender, MouseEventArgs e)
        {
            IsOkUpdateTemplate = false;
            if (e.Button == MouseButtons.Left)
                cb_TemplateRevision.Text = ControlValidator.Next_Letter(cb_TemplateRevision.Text, true);
            else
            {
                if (cb_TemplateRevision.Text != Templates_Protocol.MainTemplate.Revision)
                    cb_TemplateRevision.Text = ControlValidator.Next_Letter(cb_TemplateRevision.Text, false);
            }
        }
        private void Revision_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void Centuri_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Centuri.Text))
                return;
            Process.Start(tb_Centuri.Text);
        }
        private void Save_Template_Click(object sender, EventArgs e)
        {
            if (IsOkSaveTemplate() == false)
                return;
            if (MainTemplate.IsTemplateExist(cb_TemplateRevision.Text))
            {
                InfoText.Show("Denna mall finns redan sparad. Om du vill uppdatera den klickar du på 'Uppdatera Mall'", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }
            Template.Save_NewTemplate(cb_TemplateName.Text, cb_TemplateRevision.Text, tb_Centuri.Text, chb_IsApprovalRequired.Checked, flp_Main);
            InfoText.Show("" +
                          "Den nya mallen är nu sparad.\n" +
                          "Om du vill koppla denna mall till en Protokoll-Mall så går du till Hantering av mallar för Protokoll och väljer vilken LineClerance-Revision den mallen skall ha.",
                CustomColors.InfoText_Color.Info, null, this);

            Fill_MainTemplate_Names();
            Load_AutoCompleteCategoryText();
            Load_AutoCompleteCenturiLink();
        }
        private void Update_Template_Click(object sender, EventArgs e)
        {
            //Nedanstående är avaktiverad tills detta börjar användas skarpt med mallarna kopplade på riktigt

            //var totalConnectedProcesscardsToTemplate = Template_Management.TemplateControls.LineClearance.TotalConnectedProcesscardsToTemplate(cb_Revision.Text);
            //var totalConnectedOrdersToTemplate = Template_Management.TemplateControls.LineClearance.TotalConnectedOrdersToTemplate(cb_Revision.Text);
            //if (totalConnectedProcesscardsToTemplate > 1)
            //{
            //    InfoText.Show($"Denna mall har {totalConnectedProcesscardsToTemplate} processkort kopplat till sig och kan inte längre uppdateras. Du måste nu skapa en ny revision.", CustomColors.InfoText_Color.Bad, "Warning!", this);
            //    return;
            //}

            //if (totalConnectedOrdersToTemplate > 1)
            //{
            //    InfoText.Show($"Denna mall har {totalConnectedOrdersToTemplate} ordrar kopplade till sig och kan inte längre uppdateras. Du måste nu skapa en ny revision.", CustomColors.InfoText_Color.Bad, "Warning!", this);
            //    return;
            //}

            MainTemplate.Delete_Template();
            Template.Save_NewTemplate(cb_TemplateName.Text, cb_TemplateRevision.Text, tb_Centuri.Text, chb_IsApprovalRequired.Checked, flp_Main);


            InfoText.Show("" +
                          "Mallen är nu uppdaterad\n" +
                          "Om du vill koppla denna mall till en Protokoll-Mall så går du till Hantering av mallar för Protokoll och väljer vilken LineClerance-Revision den mallen skall ha.",
                CustomColors.InfoText_Color.Info, null, this);

            Fill_MainTemplate_Names();
            Load_AutoCompleteCategoryText();
            Load_AutoCompleteCenturiLink();
            LoadData();
        }
        private void Delete_Template_Click(object sender, EventArgs e)
        {
           // var total = 0;
           // if (Template_Management.TemplateControls.Protocol.IsTemplateConnectedToProcesscard(ref total))
           // {
           //     InfoText.Show($"Denna mall har {total} processkort kopplat till sig och kan inte raderas, kontakta admin vid problem", CustomColors.InfoText_Color.Bad, "Warning!", this);
           //     return;
           // }
           // if (Template_Management.TemplateControls.Protocol.IsTemplateConnectedToOrderNr(ref total))
           // {
           //     InfoText.Show($"Denna mall har {total} ordrar kopplade till sig och kan inte längre uppdateras. Du måste nu skapa en ny revision.", CustomColors.InfoText_Color.Bad, "Warning!", this);
           //     return;
           // }
           //// Template_Management.TemplateControls.Delete_Template(cb_TemplateName.Text, cb_Revision.Text, true);
           // Fill_MainTemplate_Names();
           // cb_TemplateName.SelectedIndex = -1;

        }
        private void PreviewTemplate_Click(object sender, EventArgs e)
        {
            preview.Show();
            _ = preview.Update_TemplateAsync(flp_Main);
        }
        private void ConnectTemplate_Click(object sender, EventArgs e)
        {
            var partsManager = new Connect_Templates(cb_TemplateName.Text, cb_TemplateRevision.Text, false, Connect_Templates.SourceType.Type_LineClearance);
            partsManager.ShowDialog();
        }


        private void AddCategory(int? formTemplateID = null)
        {
            var panel = new Panel
            {
                AutoSize = false,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Width = flp_Main.Width - 20,
                Margin = new Padding(1, 1, 0, 0),
                Name = formTemplateID.ToString(),

            };
            panel_Active = panel;

            var label_Header = new Label
            {
                Name = tb_Category.Text,
                Text = tb_Category.Text,
                Dock = DockStyle.Top,
                Font = new Font("Arial", 12f, FontStyle.Bold),
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
            };
            label_Header.Click += TemplateControls.Category_Click;
            label_ActiveCategory.Text = tb_Category.Text;

            var dgv_Template = TemplateControls.DataGridView_Template($"dgv_Header_{tb_Category.Text}", 0, DockStyle.Fill);
            Template.AddColumns_dgv_Template(dgv_Template);

            TemplateControls.ChangePanelHeight(dgv_Template);
            dgv_LineClearance_Active_Main = dgv_Template;


            // label_Active_ModuleName = label_Module_Name;

            panel.Controls.Add(label_Header);
            panel.Controls.Add(dgv_Template);
            dgv_Template.BringToFront();
            flp_Main.Controls.Add(panel);

            if (formTemplateID != null)
            {
                Template.Load_Data(formTemplateID);
                //Template_Management.TemplateControls.Protocol.FormTemplate.Load_Data(formTemplateID, cb_TemplateName.Text, cb_Revision.Text);
            }
            IsOkUpdateTemplate = false;
            tb_Category.Text = string.Empty;
        }



        private void Tasks_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var task = dgv_Tasks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            Tasks.Add(task, int.Parse(dgv_Tasks.Rows[e.RowIndex].Cells[0].Value.ToString()));
            tb_AddNewTask.Text = string.Empty;
        }
        private void Tasks_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Tasks.LoadData(dgv_Tasks);
        }

        private void CodeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            var key = e.KeyChar;
            foreach (DataGridViewRow row in dgv_Tasks.Rows)
            {
                if (row.Cells[1].Value.ToString().StartsWith(key.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    row.Selected = true;
                    dgv_Tasks.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }
        private void RenameModule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Category.Text))
            {
                InfoText.Show("Fyll i namnet på modulen före du försöker ändra det.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                ControlValidator.SoftBlink(tb_Category, Color.White, Color.Maroon);
                return;
            }
            label_ActiveCategory.Text = tb_Category.Text;
            tb_Category.Text = string.Empty;
            IsOkUpdateTemplate = false;
        }
        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            panel_Active.Dispose();
            IsOkUpdateTemplate = false;
        }
        private void MoveCategoryUp_Click(object sender, EventArgs e)
        {
            var index = flp_Main.Controls.GetChildIndex(panel_Active);
            if (index > 0)
            {
                flp_Main.Controls.SetChildIndex(panel_Active, index - 1);
                IsOkUpdateTemplate = false;
            }

        }
        private void MoveCategoryDown_Click(object sender, EventArgs e)
        {
            var index = flp_Main.Controls.GetChildIndex(panel_Active);
            if (index < flp_Main.Controls.Count)
            {
                flp_Main.Controls.SetChildIndex(panel_Active, index + 1);
                IsOkUpdateTemplate = false;
            }

        }
        private void DeleteTask_Click(object sender, EventArgs e)
        {
            dgv_LineClearance_Active_Main.Rows.RemoveAt(dgv_LineClearance_Active_Main.CurrentCell.RowIndex);

            _ = preview?.Update_TemplateAsync(flp_Main);
            IsOkUpdateTemplate = false;
        }
        private void MoveTaskUp_Click(object sender, EventArgs e)
        {
            var row = dgv_LineClearance_Active_Main.CurrentCell.RowIndex;
            var rowToMove = dgv_LineClearance_Active_Main.Rows[row];
            if (row > 0)
            {
                dgv_LineClearance_Active_Main.Rows.RemoveAt(row);
                dgv_LineClearance_Active_Main.Rows.Insert(row - 1, rowToMove);
                dgv_LineClearance_Active_Main.CurrentCell = dgv_LineClearance_Active_Main.Rows[row - 1].Cells[1];
                IsOkUpdateTemplate = false;
            }
        }
        private void MoveTaskDown_Click(object sender, EventArgs e)
        {
            var row = dgv_LineClearance_Active_Main.CurrentCell.RowIndex;
            var rowToMove = dgv_LineClearance_Active_Main.Rows[row];
            if (row < dgv_LineClearance_Active_Main.Rows.Count - 1)
            {
                dgv_LineClearance_Active_Main.Rows.RemoveAt(row);
                dgv_LineClearance_Active_Main.Rows.Insert(row + 1, rowToMove);
                dgv_LineClearance_Active_Main.CurrentCell = dgv_LineClearance_Active_Main.Rows[row + 1].Cells[1];
                IsOkUpdateTemplate = false;
            }
        }


        private void Template_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_TemplateRevision.SelectedIndexChanged -= Template_RevisionNr_SelectedIndexChanged;

            preview?.Dispose();
            Fill_Template_RevisionNr();
            Templates_Protocol.MainTemplate.ID = List_ProtocolMainTemplateID[cb_TemplateName.SelectedIndex];
            dgv_Tasks.Visible = true;
            // LoadRevisions();

            LoadData();
            cb_TemplateRevision.SelectedIndexChanged += Template_RevisionNr_SelectedIndexChanged;
        }
        private void Template_RevisionNr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsOkUpdateTemplate == false)
            {
                InfoText.Question("Är du säker på att du vill ladda om mallen? Dina aktiva ändringar kommer att försvinna.", CustomColors.InfoText_Color.Warning, "Warning!", this);
                if (InfoText.answer == InfoText.Answer.No)
                    return;
            }

            LoadData();
        }

        private void FilterTask_TextChanged(object sender, EventArgs e)
        {
            var filterCondition = $"[Tasks] LIKE '%{tb_AddNewTask.Text}%' ";
            Tasks.dt_Tasks.DefaultView.RowFilter = filterCondition;
        }

        private void AddTaskText_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_AddNewTask.Text))
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    IF NOT EXISTS (SELECT * FROM LineClearance.Description WHERE Tasks = @task)
                    BEGIN
                        INSERT INTO LineClearance.Description (Tasks)
                        OUTPUT INSERTED.DescriptionID
                            VALUES (@task)
                    END";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@task", SqlDbType.NVarChar).Value = tb_AddNewTask.Text;
                    con.Open();
                    var descriptionID = cmd.ExecuteScalar();
                    if (descriptionID != null)
                        Tasks.Add(tb_AddNewTask.Text, (int)descriptionID);
                }
            }
            Tasks.LoadData(dgv_Tasks);

            tb_AddNewTask.Text = string.Empty;
        }
        private void LoadData()
        {
            ClearCategorys();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT maintemplate.MainTemplateID, formtemplate.FormTemplateID, LineClearance_Revision, IsApprovalRequired, CenturiLink, Category, CreatedBy, CreatedDate
                    FROM LineClearance.MainTemplate as maintemplate
                        JOIN LineClearance.FormTemplate as formtemplate
                            ON formtemplate.MainTemplateID = maintemplate.MainTemplateID
                    WHERE maintemplate.ProtocolTemplateName = @templatename 
                        AND LineClearance_Revision = @lineclearancerevision
                        AND TemplateOrder IS NOT NULL 
                      
                    ORDER BY TemplateOrder";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@templatename", cb_TemplateName.Text);
                cmd.Parameters.AddWithValue("@lineclearancerevision", cb_TemplateRevision.Text);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lbl_CreatedBy.Text = $"{reader["CreatedBy"]}";
                        DateTime.TryParse(reader["CreatedDate"].ToString(), out var dateTime);
                        lbl_CreatedDate.Text = dateTime.ToString("yyyy-MM-dd HH:mm");

                        chb_IsApprovalRequired.Checked = reader.GetBoolean(3);
                        tb_Centuri.Text = reader["CenturiLink"].ToString();
                        tb_Category.Text = reader["Category"].ToString();
                        if (int.TryParse(reader["FormTemplateID"].ToString(), out var formTemplateID))
                        {
                            MainTemplate.LineClearance_MainTemplateID = int.Parse(reader["MainTemplateID"].ToString());
                            AddCategory(formTemplateID);
                        }
                    }

                    if (reader.HasRows == false)
                        MainTemplate.LineClearance_MainTemplateID = null;
                }
            }
            MainTemplate.LineClearance_Revision = cb_TemplateRevision.Text;
            label_TotalConnectedProcesscards.Text = $"Antal Processkort kopplade till mallen: {MainTemplate.TotalConnectedProcesscardsToTemplate(cb_TemplateRevision.Text)}";
            label_TotalConnectedOrders.Text = $"Antal Ordrar kopplade till mallen: {MainTemplate.TotalConnectedOrdersToTemplate(cb_TemplateRevision.Text)}";

            IsOkUpdateTemplate = true;
        }
        private void ClearCategorys()
        {
            flp_Main.Controls.Clear();
        }
        private void Fill_Template_RevisionNr()
        {
            cb_TemplateName.SelectedIndexChanged -= Template_Name_SelectedIndexChanged;
            cb_TemplateRevision.Items.Clear();
            List_RevisionNr.Clear();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                SELECT DISTINCT LineClearance_Revision
                FROM LineClearance.MainTemplate
                WHERE ProtocolMainTemplateID = (SELECT TOP(1) ID FROM Protocol.MainTemplate WHERE Name = @name ORDER BY LineClearance_Revision DESC)";
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
        private void LoadRevisions()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query =
                    @"
                    SELECT DISTINCT LineClearance_Revision 
                    FROM LineClearance.MainTemplate 
                    WHERE ProtocolMainTemplateID = (SELECT TOP (1) ID From Protocol.MainTemplate WHERE Name = @templatename ORDER BY Revision DESC) ORDER BY LineClearance_Revision DESC";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@templatename", cb_TemplateName.Text); //Template_Management.TemplateControls.LineClearance.LineClearanceMainTemplateID);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    cb_TemplateRevision.Text = value.ToString();
            }
        }




        public class Tasks
        {
            public static bool IsTaskExistInCategory(DataGridView dgv, string codeText)
            {
                if (dgv is null)
                    return true;
                for (var i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells["col_Tasks"].Value.ToString() == codeText)
                        return true;
                }
                return false;
            }

            public static void LoadData(DataGridView dgv)
            {
                dt_Tasks = new DataTable();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT DescriptionID, Tasks FROM LineClearance.Description ORDER BY Tasks";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    var dataAdapter = new SqlDataAdapter(query, con);
                    dataAdapter.Fill(dt_Tasks);
                    dgv.DataSource = dt_Tasks;
                }

                dgv.Columns[0].Visible = false;
            }
            public static DataTable dt_Tasks;
            public static void Add(string task, int protocoldescriptionID)
            {
                if (IsTaskExistInCategory(dgv_LineClearance_Active_Main, task))
                    return;
                dgv_LineClearance_Active_Main.Rows.Add();
                dgv_LineClearance_Active_Main.Rows[dgv_LineClearance_Active_Main.Rows.Count - 1].Cells["col_Tasks"].Value = $"• {task}";
                dgv_LineClearance_Active_Main.Rows[dgv_LineClearance_Active_Main.Rows.Count - 1].Cells["col_ProtocolDescriptionID"].Value = protocoldescriptionID;

                IsOkUpdateTemplate = false;
            }
        }

        public class TemplateControls
        {
            private static FlowLayoutPanel? flp;
            private static PreviewTemplate previewTemplate;

            public TemplateControls(FlowLayoutPanel? flp_Main, PreviewTemplate preview)
            {
                flp = flp_Main;
                previewTemplate = preview;
            }
            public static DataGridView DataGridView_Template(string name, int height, DockStyle dockStyle)
            {
                var dgv = new DataGridView
                {
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToResizeColumns = false,
                    AllowUserToResizeRows = false,
                    AllowUserToOrderColumns = false,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.Black,
                    Dock = dockStyle,
                    EnableHeadersVisualStyles = false,
                    Height = height,
                    Margin = new Padding(0, 0, 0, 0),
                    MultiSelect = false,
                    Name = name,
                    RowHeadersVisible = false,
                    ScrollBars = ScrollBars.None,
                    AllowDrop = true,

                };

                dgv.Enter += Enter_dgv;
                dgv.RowsAdded += RowsAdded_dgv;
                dgv.RowsRemoved += RowsRemoved_dgv;
                dgv.CurrentCellDirtyStateChanged += CurrentCellDirtyStateChanged;
                dgv.ColumnHeaderMouseClick += CopyFirstRow;
                dgv.AllowDrop = true;
                dgv.CellClick += CellClick_dgv;
                dgv.Leave += Dgv_Leave;

                dgv.CellValueChanged += Update_PreviewTemplate;
                return dgv;
            }

            private static void CellClick_dgv(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex > dgv_LineClearance_Active_Main.Columns.Count - 4)
                    IsOkUpdateTemplate = false;
            }

            private static void RowsAdded_dgv(object sender, DataGridViewRowsAddedEventArgs e)
            {
                var dgv = (DataGridView)sender;
                ChangePanelHeight(dgv);
                if (flp is null || previewTemplate.IsDisposed)
                    return;
                _ = previewTemplate.Update_TemplateAsync(flp);
            }
            private static void RowsRemoved_dgv(object sender, DataGridViewRowsRemovedEventArgs e)
            {
                var dgv = (DataGridView)sender;
                var parentControl = dgv.Parent;
                if (parentControl is Panel panel)
                    panel_Active = panel;
                ChangePanelHeight(dgv);
            }
            private static void Enter_dgv(object sender, EventArgs e)
            {
                var dgv = (DataGridView)sender;

                dgv_LineClearance_Active_Main = dgv;
                var parentControl = dgv.Parent;
                if (parentControl is Panel panel)
                    panel_Active = panel;
                foreach (var lbl in panel_Active.Controls.OfType<Label>())
                    manage_LineClearanceTemplates.label_ActiveCategory.Text = lbl.Text;

            }
            private static void Dgv_Leave(object sender, EventArgs e)
            {
                var dgv = (DataGridView)sender;
                dgv.ClearSelection();
            }
            public static void Category_Click(object sender, EventArgs e)
            {
                var label = (Label)sender;
                var parentControl = label.Parent;
                if (parentControl is Panel panel)
                    panel_Active = panel;
                foreach (var dgv in panel_Active.Controls.OfType<DataGridView>())
                    dgv_LineClearance_Active_Main = dgv;

                manage_LineClearanceTemplates.label_ActiveCategory.Text = label.Text;
            }

            private static void CopyFirstRow(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.ColumnIndex < 2)
                    return;
                var dgv = (DataGridView)sender;
                var value = dgv.Rows[0].Cells[e.ColumnIndex].Value;
                foreach (DataGridViewRow row in dgv.Rows)
                    row.Cells[e.ColumnIndex].Value = value;

            }
            public static void Update_PreviewTemplate(object sender, DataGridViewCellEventArgs e)
            {
                if (flp is null || previewTemplate.IsDisposed)
                    return;
                _ = previewTemplate.Update_TemplateAsync(flp);
            }
            private static void CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
                var dgv = (DataGridView)sender;
                if (dgv.IsCurrentCellDirty)
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            public static void ChangePanelHeight(DataGridView dgv)
            {
                var combinedHeight = dgv.ColumnHeadersHeight + dgv.Rows.Cast<DataGridViewRow>().Sum(r => r.Height);
                panel_Active.Height = combinedHeight;
            }
        }

        private void Manage_Templates_FormClosed(object sender, FormClosedEventArgs e)
        {
            Order.Restore_TempOrderInfo();
        }

        public class MainTemplate
        {
            public static int? LineClearance_MainTemplateID { get; set; }
            public static string LineClearance_Revision { get; set; }
            public static string LineClearance_CenturiLink { get; set; }
            public static int TotalConnectedProcesscardsToTemplate(string lineClearanceRevision)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                            SELECT COUNT(*) 
                            FROM Processcard.MainData as maindata
                                JOIN LineClearance.MainTemplate as lineclearancetemplate
	                                ON maindata.ProtocolMainTemplateID = lineclearancetemplate.ProtocolMainTemplateID  
                                JOIN Protocol.MainTemplate as protocolTemplate
	                                ON protocolTemplate.ID = lineclearancetemplate.ProtocolMainTemplateID
                            WHERE maindata.ProtocolMainTemplateID = (SELECT ProtocolMainTemplateID FROM LineClearance.MainTemplate WHERE MainTemplateID = @lineclearancemaintemplateid)
                                AND protocolTemplate.LineClearance_Template = @lineclearancerevision";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@lineclearancemaintemplateid", LineClearance_MainTemplateID);
                    cmd.Parameters.AddWithValue("@lineclearancerevision", lineClearanceRevision);
                    var value = cmd.ExecuteScalar();
                    return value == null ? 0 : int.Parse(value.ToString());
                }
            }
            public static int TotalConnectedOrdersToTemplate(string lineClearanceRevision)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT COUNT(*) 
                    FROM [Order].MainData as maindata
                    JOIN LineClearance.MainTemplate as lineclearancetemplate
                     	ON maindata.ProtocolMainTemplateID = lineclearancetemplate.ProtocolMainTemplateID  
                    JOIN Protocol.MainTemplate as protocolTemplate
	                    ON protocolTemplate.ID = lineclearancetemplate.ProtocolMainTemplateID
                    WHERE maindata.ProtocolMainTemplateID = (SELECT ProtocolMainTemplateID FROM LineClearance.MainTemplate WHERE MainTemplateID = @lineclearancemaintemplateid)
                        AND protocolTemplate.LineClearance_Template = @lineclearancerevision";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@lineclearancemaintemplateid", LineClearance_MainTemplateID);
                    cmd.Parameters.AddWithValue("@lineclearancerevision", lineClearanceRevision);
                    var value = cmd.ExecuteScalar();
                    return value == null ? 0 : int.Parse(value.ToString());
                }
            }
            public static bool IsTemplateExist(string revision)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        SELECT * FROM LineClearance.MainTemplate WHERE MainTemplateID = @maintemplateid AND LineClearance_Revision = @lcrevision ";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.Add("@maintemplateid", SqlDbType.Int).Value = LineClearance_MainTemplateID;
                        cmd.Parameters.Add("@lcrevision", SqlDbType.NVarChar).Value = revision;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                                return true;
                        }
                    }
                }
                return false;
            }

            public static void Set_MainTemplateID()
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                        SELECT TOP (1) MainTemplateID 
                        FROM LineClearance.MainTemplate 
                        WHERE ProtocolMainTemplateID = @prototocolmaintemplateid
                        ORDER BY LineClearance_Revision DESC";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@prototocolmaintemplateid", Templates_Protocol.MainTemplate.ID);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != DBNull.Value && value != null)
                {
                    LineClearance_MainTemplateID = int.Parse(value.ToString());
                    return;
                }

                return;
                //Koden nedan behövs troligen inte, LineClearance bör alltid bli rätt laddad
                var chooseTemplate = new ProcesscardTemplateSelector(ProcesscardTemplateSelector.TemplateType.TemplateMeasureProtocol);
                chooseTemplate.ShowDialog();
            }
            public static void Save_Data(string name, string lineClearanceRevision, string centuriLink, bool isApprovalRequired)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query =
                        @"IF NOT EXISTS (SELECT * FROM LineClearance.MainTemplate WHERE ProtocolMainTemplateID = @protocolmaintemplateid AND LineClearance_Revision = @revision)
                        INSERT INTO LineClearance.MainTemplate (ProtocolMainTemplateID, LineClearance_Revision, IsApprovalRequired, CenturiLink, CreatedBy, CreatedDate)
                        VALUES (@protocolmaintemplateid, @revision, @isapprovalrequired, @centurilink, @createdby, @createddate)";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.Add("@maintemplateid", SqlDbType.Int).Value = LineClearance_MainTemplateID;

                    cmd.Parameters.AddWithValue("@protocolmaintemplateid", Templates_Protocol.MainTemplate.ID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@revision", lineClearanceRevision);
                    cmd.Parameters.AddWithValue("@isapprovalrequired", isApprovalRequired);
                    cmd.Parameters.AddWithValue("@centurilink", centuriLink);
                    cmd.Parameters.AddWithValue("@createdby", Person.Name);
                    cmd.Parameters.AddWithValue("@createddate", DateTime.Now);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            public static void Delete_Template()
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query =
                        @"
                        BEGIN TRANSACTION
                            BEGIN TRY
                                DELETE FROM LineClearance.MainTemplate WHERE MainTemplateID = @maintemplateid;
                                DELETE FROM LineClearance.Template WHERE FormTemplateID IN (SELECT FormTemplateID FROM LineClearance.FormTemplate WHERE MainTemplateID = @maintemplateid);
                                DELETE FROM LineClearance.FormTemplate WHERE MainTemplateID = @maintemplateid;          
                                COMMIT TRANSACTION;
                            END TRY
                        BEGIN CATCH
                        ROLLBACK TRANSACTION;
                        
                        END CATCH";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.Add("@maintemplateid", SqlDbType.Int).Value = LineClearance_MainTemplateID;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public class Template
        {

            public static void AddColumns_dgv_Template(DataGridView dgv)
            {
                Templates_Protocol.TemplateControls.AddColumn(dgv, new DataGridViewTextBoxColumn(), "ProtocolDescriptionID", "col_ProtocolDescriptionID", 0, false);
                Templates_Protocol.TemplateControls.AddColumn(dgv, new DataGridViewTextBoxColumn(), "Tasks", "col_Tasks");

                dgv.ColumnHeadersVisible = false;
                foreach (DataGridViewColumn column in dgv.Columns)
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            public static void Save_NewTemplate(string protocolTemplateName, string lineClearanceRevision, string centuriLink, bool isApprovalRequired, FlowLayoutPanel flp)
            {
                MainTemplate.Save_Data(protocolTemplateName, lineClearanceRevision, centuriLink, isApprovalRequired);

                var templateOrder = 0;
                foreach (Panel panel in flp.Controls)
                {
                    var label_Name = new Label();
                    foreach (var lbl in panel.Controls.OfType<Label>())
                        label_Name = lbl;

                    DataGridView dgv_Template = null;
                    foreach (var dgv in panel.Controls.OfType<DataGridView>())
                    {
                        dgv_Template = dgv;
                    }

                    FormTemplate.Save_Data(label_Name.Text, templateOrder, lineClearanceRevision);
                    Save_Data(dgv_Template, templateOrder, lineClearanceRevision);
                    templateOrder++;
                }
            }
            public static void Save_Data(DataGridView dgv, int templateOrder, string lineClearanceRevision)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    using var con = new SqlConnection(Database.cs_Protocol);
                    const string query = @"
                                INSERT INTO LineClearance.Template (FormTemplateID, DescriptionID, RowIndex)
                                VALUES ( 
                                            (SELECT FormTemplateID 
                                                FROM LineClearance.FormTemplate 
                                                WHERE MainTemplateID = (SELECT MainTemplateID FROM LineClearance.MainTemplate WHERE ProtocolMainTemplateID = @protocolmaintemplateid AND LineClearance_Revision = @lcrevision) 
                                                    AND TemplateOrder = @templateorder), 
                                            @protocoldescriptionid,
                                            @rowindex
                                        )";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@templateorder", templateOrder);
                    //cmd.Parameters.AddWithValue("@maintemplateid", LineClearanceMainTemplateID);
                    cmd.Parameters.AddWithValue("@protocolmaintemplateid", Templates_Protocol.MainTemplate.ID);
                    cmd.Parameters.AddWithValue("@lcrevision", lineClearanceRevision);
                    SQL_Parameter.Int(cmd.Parameters, "@protocoldescriptionid", row.Cells["col_ProtocolDescriptionID"].Value);
                    cmd.Parameters.AddWithValue("@rowindex", row.Index);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            public static void Load_Data(int? formTemplateID)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT template.DescriptionID, Tasks
                    FROM LineClearance.Template as template
                    INNER JOIN LineClearance.Description as description
                        ON template.DescriptionID = description.DescriptionID
                    WHERE template.FormTemplateID = @formtemplateid
                        AND RowIndex IS NOT NULL
                    ORDER BY RowIndex";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@formtemplateid", formTemplateID);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int.TryParse(reader["DescriptionID"].ToString(), out var protocoldescriptionID);
                        var task = reader["Tasks"].ToString();

                        dgv_LineClearance_Active_Main.Rows.Add();
                        dgv_LineClearance_Active_Main.Rows[dgv_LineClearance_Active_Main.Rows.Count - 1].Cells["col_ProtocolDescriptionID"].Value = protocoldescriptionID;
                        dgv_LineClearance_Active_Main.Rows[dgv_LineClearance_Active_Main.Rows.Count - 1].Cells["col_Tasks"].Value = $"• {task}";
                    }
                }
            }
        }
        public class FormTemplate
        {
            public static void Save_Data(string category, int templateOrder, string revision)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        IF NOT EXISTS (SELECT * FROM LineClearance.FormTemplate WHERE Category = @category AND MainTemplateID = (SELECT MainTemplateID FROM LineClearance.MainTemplate WHERE ProtocolMainTemplateID = @protocolmaintemplateid AND LineClearance_Revision = @lcrevision))
                            INSERT INTO LineClearance.FormTemplate (MainTemplateID, TemplateOrder, Category)
                            VALUES (
                                       (SELECT MainTemplateID FROM LineClearance.MainTemplate WHERE ProtocolMainTemplateID = @protocolmaintemplateid AND LineClearance_Revision = @lcrevision), @templateorder, @category
                                   )";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.Add("@maintemplateid", SqlDbType.Int).Value = MainTemplate.LineClearance_MainTemplateID;
                    cmd.Parameters.Add("@protocolmaintemplateid", SqlDbType.Int).Value = Templates_Protocol.MainTemplate.ID;
                    cmd.Parameters.Add("@templateorder", SqlDbType.Int).Value = templateOrder;
                    cmd.Parameters.Add("@category", SqlDbType.NVarChar).Value = category;
                    cmd.Parameters.Add("@lcrevision", SqlDbType.NVarChar).Value = revision;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}



