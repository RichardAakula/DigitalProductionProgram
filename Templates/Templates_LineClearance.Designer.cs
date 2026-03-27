using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Templates
{
    partial class Templates_LineClearance
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Templates_LineClearance));
            flp_Main = new FlowLayoutPanel();
            dgv_Tasks = new DataGridView();
            tb_Category = new TextBox();
            cb_TemplateName = new ComboBox();
            btn_SaveNewTemplate = new Button();
            btn_UpdateTemplate = new Button();
            label_LineClearanceRevision = new Label();
            btn_NewModule = new Button();
            btn_PreviewTemplate = new Button();
            cb_TemplateRevision = new ComboBox();
            btn_DeleteTemplate = new Button();
            pb_RenameCategory = new PictureBox();
            btn_MoveTaskUp = new PictureBox();
            btn_MoveTaskDown = new PictureBox();
            btn_MoveCategoryUp = new PictureBox();
            btn_MoveCategoryDown = new PictureBox();
            btn_DeleteTask = new PictureBox();
            btn_DeleteCategory = new PictureBox();
            label_Buttons_Task = new Label();
            label_Buttons_Category = new Label();
            label_ActiveCategory = new Label();
            btn_NewRevision = new Button();
            toolTip = new ToolTip(components);
            tb_AddNewTask = new TextBox();
            btn_AddTask = new Button();
            gbx_CategoryLineClearance = new GroupBox();
            gbx_Tasks = new GroupBox();
            gbox_LineClearanceTemplate = new GroupBox();
            tb_Centuri = new TextBox();
            chb_IsApprovalRequired = new CheckBox();
            label_ProtocolTemplateName = new Label();
            tlp_Top = new TableLayoutPanel();
            tlp_ExtraInfo = new TableLayoutPanel();
            label_TotalConnectedOrders = new Label();
            lbl_CreatedDate = new Label();
            lbl_CreatedBy = new Label();
            label_CreatedDate = new Label();
            label_CreatedBy = new Label();
            label_TotalConnectedProcesscards = new Label();
            btn_ConnectPartNr_NewTemplate = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            web_PDF_Viewer = new WebBrowser();
            flp_ObjectManagement = new FlowLayoutPanel();
            ((ISupportInitialize)dgv_Tasks).BeginInit();
            ((ISupportInitialize)pb_RenameCategory).BeginInit();
            ((ISupportInitialize)btn_MoveTaskUp).BeginInit();
            ((ISupportInitialize)btn_MoveTaskDown).BeginInit();
            ((ISupportInitialize)btn_MoveCategoryUp).BeginInit();
            ((ISupportInitialize)btn_MoveCategoryDown).BeginInit();
            ((ISupportInitialize)btn_DeleteTask).BeginInit();
            ((ISupportInitialize)btn_DeleteCategory).BeginInit();
            gbx_CategoryLineClearance.SuspendLayout();
            gbx_Tasks.SuspendLayout();
            gbox_LineClearanceTemplate.SuspendLayout();
            tlp_Top.SuspendLayout();
            tlp_ExtraInfo.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flp_ObjectManagement.SuspendLayout();
            SuspendLayout();
            // 
            // flp_Main
            // 
            flp_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flp_Main.AutoScroll = true;
            flp_Main.BackColor = Color.FromArgb(81, 85, 92);
            flp_Main.FlowDirection = FlowDirection.TopDown;
            flp_Main.Location = new Point(727, 229);
            flp_Main.Margin = new Padding(4, 3, 4, 3);
            flp_Main.MaximumSize = new Size(1540, 2308);
            flp_Main.Name = "flp_Main";
            flp_Main.Size = new Size(809, 866);
            flp_Main.TabIndex = 0;
            flp_Main.WrapContents = false;
            // 
            // dgv_Tasks
            // 
            dgv_Tasks.AllowUserToAddRows = false;
            dgv_Tasks.AllowUserToDeleteRows = false;
            dgv_Tasks.AllowUserToResizeColumns = false;
            dgv_Tasks.AllowUserToResizeRows = false;
            dgv_Tasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgv_Tasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Tasks.BackgroundColor = Color.FromArgb(81, 85, 92);
            dgv_Tasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Tasks.Location = new Point(4, 229);
            dgv_Tasks.Margin = new Padding(4, 3, 4, 3);
            dgv_Tasks.MultiSelect = false;
            dgv_Tasks.Name = "dgv_Tasks";
            dgv_Tasks.ReadOnly = true;
            dgv_Tasks.RowHeadersVisible = false;
            dgv_Tasks.Size = new Size(575, 866);
            dgv_Tasks.TabIndex = 2;
            dgv_Tasks.Visible = false;
            dgv_Tasks.CellMouseDown += Tasks_CellMouseDown;
            dgv_Tasks.ColumnHeaderMouseClick += Tasks_ColumnHeaderMouseClick;
            dgv_Tasks.KeyPress += CodeText_KeyPress;
            // 
            // tb_Category
            // 
            tb_Category.Font = new Font("Lucida Sans", 8.25F);
            tb_Category.Location = new Point(7, 66);
            tb_Category.Margin = new Padding(4, 3, 4, 3);
            tb_Category.Name = "tb_Category";
            tb_Category.Size = new Size(642, 20);
            tb_Category.TabIndex = 3;
            // 
            // cb_TemplateName
            // 
            cb_TemplateName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cb_TemplateName.Font = new Font("Lucida Sans", 11.25F);
            cb_TemplateName.FormattingEnabled = true;
            cb_TemplateName.Location = new Point(7, 181);
            cb_TemplateName.Margin = new Padding(4, 3, 4, 3);
            cb_TemplateName.Name = "cb_TemplateName";
            cb_TemplateName.Size = new Size(461, 25);
            cb_TemplateName.TabIndex = 4;
            cb_TemplateName.SelectedIndexChanged += Template_Name_SelectedIndexChanged;
            // 
            // btn_SaveNewTemplate
            // 
            btn_SaveNewTemplate.BackColor = Color.FromArgb(185, 188, 189);
            btn_SaveNewTemplate.Cursor = Cursors.Hand;
            btn_SaveNewTemplate.Dock = DockStyle.Fill;
            btn_SaveNewTemplate.FlatStyle = FlatStyle.Flat;
            btn_SaveNewTemplate.Font = new Font("Lucida Sans", 10.25F);
            btn_SaveNewTemplate.ForeColor = Color.FromArgb(63, 116, 140);
            btn_SaveNewTemplate.Location = new Point(6, 6);
            btn_SaveNewTemplate.Margin = new Padding(6, 0, 0, 0);
            btn_SaveNewTemplate.Name = "btn_SaveNewTemplate";
            btn_SaveNewTemplate.Size = new Size(286, 40);
            btn_SaveNewTemplate.TabIndex = 1;
            btn_SaveNewTemplate.Text = "Spara Mall";
            btn_SaveNewTemplate.UseVisualStyleBackColor = false;
            btn_SaveNewTemplate.Click += Save_Template_Click;
            // 
            // btn_UpdateTemplate
            // 
            btn_UpdateTemplate.BackColor = Color.FromArgb(185, 188, 189);
            btn_UpdateTemplate.Cursor = Cursors.Hand;
            btn_UpdateTemplate.Dock = DockStyle.Fill;
            btn_UpdateTemplate.FlatStyle = FlatStyle.Flat;
            btn_UpdateTemplate.Font = new Font("Lucida Sans", 10.25F);
            btn_UpdateTemplate.ForeColor = Color.FromArgb(63, 116, 140);
            btn_UpdateTemplate.Location = new Point(6, 46);
            btn_UpdateTemplate.Margin = new Padding(6, 0, 0, 0);
            btn_UpdateTemplate.Name = "btn_UpdateTemplate";
            btn_UpdateTemplate.Size = new Size(286, 40);
            btn_UpdateTemplate.TabIndex = 1;
            btn_UpdateTemplate.Text = "Uppdatera Mall";
            btn_UpdateTemplate.UseVisualStyleBackColor = false;
            btn_UpdateTemplate.Click += Update_Template_Click;
            // 
            // label_LineClearanceRevision
            // 
            label_LineClearanceRevision.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label_LineClearanceRevision.BackColor = Color.FromArgb(239, 228, 177);
            label_LineClearanceRevision.Font = new Font("Lucida Sans", 10.25F);
            label_LineClearanceRevision.ForeColor = Color.FromArgb(57, 108, 121);
            label_LineClearanceRevision.Location = new Point(597, 152);
            label_LineClearanceRevision.Margin = new Padding(4, 0, 4, 0);
            label_LineClearanceRevision.Name = "label_LineClearanceRevision";
            label_LineClearanceRevision.Size = new Size(204, 25);
            label_LineClearanceRevision.TabIndex = 9;
            label_LineClearanceRevision.Text = "Line-Clearance Revision";
            // 
            // btn_NewModule
            // 
            btn_NewModule.BackColor = Color.FromArgb(198, 239, 206);
            btn_NewModule.Cursor = Cursors.Hand;
            btn_NewModule.FlatStyle = FlatStyle.Flat;
            btn_NewModule.Font = new Font("Lucida Sans", 10.25F);
            btn_NewModule.ForeColor = Color.FromArgb(0, 97, 0);
            btn_NewModule.Location = new Point(7, 27);
            btn_NewModule.Margin = new Padding(4, 3, 4, 3);
            btn_NewModule.Name = "btn_NewModule";
            btn_NewModule.Size = new Size(127, 32);
            btn_NewModule.TabIndex = 11;
            btn_NewModule.Text = "Lägg till";
            btn_NewModule.UseVisualStyleBackColor = false;
            btn_NewModule.Click += NewModule_Click;
            // 
            // btn_PreviewTemplate
            // 
            btn_PreviewTemplate.BackColor = Color.FromArgb(185, 188, 189);
            btn_PreviewTemplate.Cursor = Cursors.Hand;
            btn_PreviewTemplate.Dock = DockStyle.Fill;
            btn_PreviewTemplate.FlatStyle = FlatStyle.Flat;
            btn_PreviewTemplate.Font = new Font("Lucida Sans", 10.25F);
            btn_PreviewTemplate.ForeColor = Color.FromArgb(63, 116, 140);
            btn_PreviewTemplate.Location = new Point(292, 46);
            btn_PreviewTemplate.Margin = new Padding(0);
            btn_PreviewTemplate.Name = "btn_PreviewTemplate";
            btn_PreviewTemplate.Size = new Size(292, 40);
            btn_PreviewTemplate.TabIndex = 1;
            btn_PreviewTemplate.Text = "Förhandsgranska Mall";
            btn_PreviewTemplate.UseVisualStyleBackColor = false;
            btn_PreviewTemplate.Click += PreviewTemplate_Click;
            // 
            // cb_TemplateRevision
            // 
            cb_TemplateRevision.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cb_TemplateRevision.Font = new Font("Lucida Sans", 11.25F);
            cb_TemplateRevision.FormattingEnabled = true;
            cb_TemplateRevision.Location = new Point(597, 181);
            cb_TemplateRevision.Margin = new Padding(4, 3, 4, 3);
            cb_TemplateRevision.Name = "cb_TemplateRevision";
            cb_TemplateRevision.Size = new Size(84, 25);
            cb_TemplateRevision.TabIndex = 14;
            cb_TemplateRevision.Text = "A";
            cb_TemplateRevision.SelectedIndexChanged += Template_RevisionNr_SelectedIndexChanged;
            cb_TemplateRevision.KeyPress += Revision_KeyPress;
            // 
            // btn_DeleteTemplate
            // 
            btn_DeleteTemplate.BackColor = Color.FromArgb(255, 199, 206);
            btn_DeleteTemplate.Cursor = Cursors.Hand;
            btn_DeleteTemplate.Dock = DockStyle.Fill;
            btn_DeleteTemplate.FlatStyle = FlatStyle.Flat;
            btn_DeleteTemplate.Font = new Font("Lucida Sans", 10.25F);
            btn_DeleteTemplate.ForeColor = Color.FromArgb(156, 0, 6);
            btn_DeleteTemplate.Location = new Point(6, 86);
            btn_DeleteTemplate.Margin = new Padding(6, 0, 0, 0);
            btn_DeleteTemplate.Name = "btn_DeleteTemplate";
            btn_DeleteTemplate.Size = new Size(286, 40);
            btn_DeleteTemplate.TabIndex = 1;
            btn_DeleteTemplate.Text = "Radera Mall";
            btn_DeleteTemplate.UseVisualStyleBackColor = false;
            btn_DeleteTemplate.Click += Delete_Template_Click;
            // 
            // pb_RenameCategory
            // 
            pb_RenameCategory.Anchor = AnchorStyles.None;
            pb_RenameCategory.BackgroundImage = (Image)resources.GetObject("pb_RenameCategory.BackgroundImage");
            pb_RenameCategory.BackgroundImageLayout = ImageLayout.Stretch;
            pb_RenameCategory.Cursor = Cursors.Hand;
            pb_RenameCategory.Location = new Point(45, 113);
            pb_RenameCategory.Margin = new Padding(4, 3, 4, 6);
            pb_RenameCategory.Name = "pb_RenameCategory";
            pb_RenameCategory.Size = new Size(48, 47);
            pb_RenameCategory.TabIndex = 5;
            pb_RenameCategory.TabStop = false;
            toolTip.SetToolTip(pb_RenameCategory, "Fyll i det nya namnet till vänster ");
            pb_RenameCategory.Click += RenameModule_Click;
            // 
            // btn_MoveTaskUp
            // 
            btn_MoveTaskUp.Anchor = AnchorStyles.None;
            btn_MoveTaskUp.BackgroundImage = (Image)resources.GetObject("btn_MoveTaskUp.BackgroundImage");
            btn_MoveTaskUp.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MoveTaskUp.Cursor = Cursors.Hand;
            btn_MoveTaskUp.Location = new Point(54, 355);
            btn_MoveTaskUp.Margin = new Padding(4, 3, 4, 6);
            btn_MoveTaskUp.Name = "btn_MoveTaskUp";
            btn_MoveTaskUp.Size = new Size(30, 33);
            btn_MoveTaskUp.TabIndex = 3;
            btn_MoveTaskUp.TabStop = false;
            btn_MoveTaskUp.Click += MoveTaskUp_Click;
            // 
            // btn_MoveTaskDown
            // 
            btn_MoveTaskDown.Anchor = AnchorStyles.None;
            btn_MoveTaskDown.BackgroundImage = (Image)resources.GetObject("btn_MoveTaskDown.BackgroundImage");
            btn_MoveTaskDown.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MoveTaskDown.Cursor = Cursors.Hand;
            btn_MoveTaskDown.Location = new Point(54, 397);
            btn_MoveTaskDown.Margin = new Padding(4, 3, 4, 6);
            btn_MoveTaskDown.Name = "btn_MoveTaskDown";
            btn_MoveTaskDown.Size = new Size(30, 33);
            btn_MoveTaskDown.TabIndex = 4;
            btn_MoveTaskDown.TabStop = false;
            btn_MoveTaskDown.Click += MoveTaskDown_Click;
            // 
            // btn_MoveCategoryUp
            // 
            btn_MoveCategoryUp.Anchor = AnchorStyles.None;
            btn_MoveCategoryUp.BackgroundImage = (Image)resources.GetObject("btn_MoveCategoryUp.BackgroundImage");
            btn_MoveCategoryUp.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MoveCategoryUp.Cursor = Cursors.Hand;
            btn_MoveCategoryUp.Location = new Point(54, 169);
            btn_MoveCategoryUp.Margin = new Padding(4, 3, 4, 6);
            btn_MoveCategoryUp.Name = "btn_MoveCategoryUp";
            btn_MoveCategoryUp.Size = new Size(30, 33);
            btn_MoveCategoryUp.TabIndex = 2;
            btn_MoveCategoryUp.TabStop = false;
            btn_MoveCategoryUp.Click += MoveCategoryUp_Click;
            // 
            // btn_MoveCategoryDown
            // 
            btn_MoveCategoryDown.Anchor = AnchorStyles.None;
            btn_MoveCategoryDown.BackgroundImage = (Image)resources.GetObject("btn_MoveCategoryDown.BackgroundImage");
            btn_MoveCategoryDown.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MoveCategoryDown.Cursor = Cursors.Hand;
            btn_MoveCategoryDown.Location = new Point(54, 211);
            btn_MoveCategoryDown.Margin = new Padding(4, 3, 4, 6);
            btn_MoveCategoryDown.Name = "btn_MoveCategoryDown";
            btn_MoveCategoryDown.Size = new Size(30, 33);
            btn_MoveCategoryDown.TabIndex = 2;
            btn_MoveCategoryDown.TabStop = false;
            btn_MoveCategoryDown.Click += MoveCategoryDown_Click;
            // 
            // btn_DeleteTask
            // 
            btn_DeleteTask.Anchor = AnchorStyles.None;
            btn_DeleteTask.BackgroundImage = (Image)resources.GetObject("btn_DeleteTask.BackgroundImage");
            btn_DeleteTask.BackgroundImageLayout = ImageLayout.Stretch;
            btn_DeleteTask.Cursor = Cursors.Hand;
            btn_DeleteTask.Location = new Point(45, 439);
            btn_DeleteTask.Margin = new Padding(4, 3, 4, 6);
            btn_DeleteTask.Name = "btn_DeleteTask";
            btn_DeleteTask.Size = new Size(48, 47);
            btn_DeleteTask.TabIndex = 1;
            btn_DeleteTask.TabStop = false;
            toolTip.SetToolTip(btn_DeleteTask, "Radera markerad rad");
            btn_DeleteTask.Click += DeleteTask_Click;
            // 
            // btn_DeleteCategory
            // 
            btn_DeleteCategory.Anchor = AnchorStyles.None;
            btn_DeleteCategory.BackgroundImage = (Image)resources.GetObject("btn_DeleteCategory.BackgroundImage");
            btn_DeleteCategory.BackgroundImageLayout = ImageLayout.Stretch;
            btn_DeleteCategory.Cursor = Cursors.Hand;
            btn_DeleteCategory.Location = new Point(45, 253);
            btn_DeleteCategory.Margin = new Padding(4, 3, 4, 29);
            btn_DeleteCategory.Name = "btn_DeleteCategory";
            btn_DeleteCategory.Size = new Size(48, 47);
            btn_DeleteCategory.TabIndex = 1;
            btn_DeleteCategory.TabStop = false;
            toolTip.SetToolTip(btn_DeleteCategory, "Radera markerad modul");
            btn_DeleteCategory.Click += DeleteCategory_Click;
            // 
            // label_Buttons_Task
            // 
            label_Buttons_Task.Anchor = AnchorStyles.None;
            label_Buttons_Task.AutoSize = true;
            label_Buttons_Task.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold);
            label_Buttons_Task.ForeColor = Color.FromArgb(255, 235, 156);
            label_Buttons_Task.Location = new Point(38, 329);
            label_Buttons_Task.Margin = new Padding(4, 0, 4, 6);
            label_Buttons_Task.Name = "label_Buttons_Task";
            label_Buttons_Task.Size = new Size(62, 17);
            label_Buttons_Task.TabIndex = 0;
            label_Buttons_Task.Text = "Åtgärd";
            // 
            // label_Buttons_Category
            // 
            label_Buttons_Category.Anchor = AnchorStyles.None;
            label_Buttons_Category.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold);
            label_Buttons_Category.ForeColor = Color.FromArgb(255, 235, 156);
            label_Buttons_Category.Location = new Point(4, 70);
            label_Buttons_Category.Margin = new Padding(4, 23, 4, 12);
            label_Buttons_Category.Name = "label_Buttons_Category";
            label_Buttons_Category.Size = new Size(130, 28);
            label_Buttons_Category.TabIndex = 0;
            label_Buttons_Category.Text = "Kategori";
            label_Buttons_Category.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_ActiveCategory
            // 
            label_ActiveCategory.Anchor = AnchorStyles.None;
            label_ActiveCategory.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold);
            label_ActiveCategory.ForeColor = Color.Silver;
            label_ActiveCategory.Location = new Point(4, 0);
            label_ActiveCategory.Margin = new Padding(4, 0, 4, 0);
            label_ActiveCategory.Name = "label_ActiveCategory";
            label_ActiveCategory.Size = new Size(130, 47);
            label_ActiveCategory.TabIndex = 0;
            label_ActiveCategory.Text = "Aktiv Kategori";
            label_ActiveCategory.TextAlign = ContentAlignment.TopCenter;
            // 
            // btn_NewRevision
            // 
            btn_NewRevision.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_NewRevision.BackColor = Color.FromArgb(198, 239, 206);
            btn_NewRevision.Cursor = Cursors.Hand;
            btn_NewRevision.FlatStyle = FlatStyle.Flat;
            btn_NewRevision.Font = new Font("Lucida Sans", 10.25F);
            btn_NewRevision.ForeColor = Color.FromArgb(0, 97, 0);
            btn_NewRevision.Location = new Point(690, 181);
            btn_NewRevision.Margin = new Padding(4, 3, 4, 3);
            btn_NewRevision.Name = "btn_NewRevision";
            btn_NewRevision.Size = new Size(112, 29);
            btn_NewRevision.TabIndex = 1;
            btn_NewRevision.Text = "Ny Revision";
            toolTip.SetToolTip(btn_NewRevision, "Vänsterklicka för att stega upp en revision, högerklicka för att stega ner en revision.");
            btn_NewRevision.UseVisualStyleBackColor = false;
            btn_NewRevision.MouseDown += NewRevision_MouseDown;
            // 
            // tb_AddNewTask
            // 
            tb_AddNewTask.Font = new Font("Lucida Sans", 8.25F);
            tb_AddNewTask.Location = new Point(7, 66);
            tb_AddNewTask.Margin = new Padding(4, 3, 4, 3);
            tb_AddNewTask.Name = "tb_AddNewTask";
            tb_AddNewTask.Size = new Size(642, 20);
            tb_AddNewTask.TabIndex = 3;
            tb_AddNewTask.TextChanged += FilterTask_TextChanged;
            // 
            // btn_AddTask
            // 
            btn_AddTask.BackColor = Color.FromArgb(198, 239, 206);
            btn_AddTask.Cursor = Cursors.Hand;
            btn_AddTask.FlatStyle = FlatStyle.Flat;
            btn_AddTask.Font = new Font("Lucida Sans", 10.25F);
            btn_AddTask.ForeColor = Color.FromArgb(0, 97, 0);
            btn_AddTask.Location = new Point(7, 27);
            btn_AddTask.Margin = new Padding(4, 3, 4, 3);
            btn_AddTask.Name = "btn_AddTask";
            btn_AddTask.Size = new Size(141, 32);
            btn_AddTask.TabIndex = 11;
            btn_AddTask.Text = "Lägg till Åtgärd";
            btn_AddTask.UseVisualStyleBackColor = false;
            btn_AddTask.Click += AddTaskText_Click;
            // 
            // gbx_CategoryLineClearance
            // 
            gbx_CategoryLineClearance.Controls.Add(btn_NewModule);
            gbx_CategoryLineClearance.Controls.Add(tb_Category);
            gbx_CategoryLineClearance.Font = new Font("Lucida Sans", 10.25F);
            gbx_CategoryLineClearance.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_CategoryLineClearance.Location = new Point(4, 3);
            gbx_CategoryLineClearance.Margin = new Padding(4, 3, 4, 3);
            gbx_CategoryLineClearance.Name = "gbx_CategoryLineClearance";
            gbx_CategoryLineClearance.Padding = new Padding(4, 3, 4, 3);
            gbx_CategoryLineClearance.Size = new Size(575, 104);
            gbx_CategoryLineClearance.TabIndex = 20;
            gbx_CategoryLineClearance.TabStop = false;
            gbx_CategoryLineClearance.Text = "Kategori";
            // 
            // gbx_Tasks
            // 
            gbx_Tasks.Controls.Add(btn_AddTask);
            gbx_Tasks.Controls.Add(tb_AddNewTask);
            gbx_Tasks.Font = new Font("Lucida Sans", 10.25F);
            gbx_Tasks.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_Tasks.Location = new Point(4, 114);
            gbx_Tasks.Margin = new Padding(4, 3, 4, 3);
            gbx_Tasks.Name = "gbx_Tasks";
            gbx_Tasks.Padding = new Padding(4, 3, 4, 3);
            gbx_Tasks.Size = new Size(575, 104);
            gbx_Tasks.TabIndex = 21;
            gbx_Tasks.TabStop = false;
            gbx_Tasks.Text = "Åtgärder";
            // 
            // gbox_LineClearanceTemplate
            // 
            gbox_LineClearanceTemplate.Controls.Add(tb_Centuri);
            gbox_LineClearanceTemplate.Controls.Add(chb_IsApprovalRequired);
            gbox_LineClearanceTemplate.Controls.Add(cb_TemplateName);
            gbox_LineClearanceTemplate.Controls.Add(btn_NewRevision);
            gbox_LineClearanceTemplate.Controls.Add(label_ProtocolTemplateName);
            gbox_LineClearanceTemplate.Controls.Add(label_LineClearanceRevision);
            gbox_LineClearanceTemplate.Controls.Add(cb_TemplateRevision);
            gbox_LineClearanceTemplate.Dock = DockStyle.Fill;
            gbox_LineClearanceTemplate.Font = new Font("Lucida Sans", 10.25F);
            gbox_LineClearanceTemplate.ForeColor = Color.FromArgb(239, 228, 177);
            gbox_LineClearanceTemplate.Location = new Point(727, 3);
            gbox_LineClearanceTemplate.Margin = new Padding(4, 3, 4, 3);
            gbox_LineClearanceTemplate.Name = "gbox_LineClearanceTemplate";
            gbox_LineClearanceTemplate.Padding = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.SetRowSpan(gbox_LineClearanceTemplate, 2);
            gbox_LineClearanceTemplate.Size = new Size(809, 220);
            gbox_LineClearanceTemplate.TabIndex = 21;
            gbox_LineClearanceTemplate.TabStop = false;
            gbox_LineClearanceTemplate.Text = "Line-Clearance Mall";
            // 
            // tb_Centuri
            // 
            tb_Centuri.Font = new Font("Lucida Sans", 10.25F, FontStyle.Underline);
            tb_Centuri.ForeColor = SystemColors.Highlight;
            tb_Centuri.Location = new Point(10, 76);
            tb_Centuri.Margin = new Padding(4, 3, 4, 3);
            tb_Centuri.Name = "tb_Centuri";
            tb_Centuri.PlaceholderText = "Länk till Centuri...";
            tb_Centuri.Size = new Size(795, 24);
            tb_Centuri.TabIndex = 3;
            tb_Centuri.Click += Centuri_Click;
            // 
            // chb_IsApprovalRequired
            // 
            chb_IsApprovalRequired.AutoSize = true;
            chb_IsApprovalRequired.Font = new Font("Lucida Sans", 11.25F);
            chb_IsApprovalRequired.ForeColor = Color.FromArgb(187, 215, 228);
            chb_IsApprovalRequired.Location = new Point(10, 32);
            chb_IsApprovalRequired.Margin = new Padding(4, 3, 4, 3);
            chb_IsApprovalRequired.Name = "chb_IsApprovalRequired";
            chb_IsApprovalRequired.Size = new Size(414, 21);
            chb_IsApprovalRequired.TabIndex = 15;
            chb_IsApprovalRequired.Text = "Skall Line-Clearance godkännas av behörig Personal?";
            chb_IsApprovalRequired.UseVisualStyleBackColor = true;
            // 
            // label_ProtocolTemplateName
            // 
            label_ProtocolTemplateName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_ProtocolTemplateName.BackColor = Color.FromArgb(239, 228, 177);
            label_ProtocolTemplateName.Font = new Font("Lucida Sans", 10.25F);
            label_ProtocolTemplateName.ForeColor = Color.FromArgb(57, 108, 121);
            label_ProtocolTemplateName.Location = new Point(7, 152);
            label_ProtocolTemplateName.Margin = new Padding(4, 0, 4, 0);
            label_ProtocolTemplateName.Name = "label_ProtocolTemplateName";
            label_ProtocolTemplateName.Size = new Size(204, 25);
            label_ProtocolTemplateName.TabIndex = 9;
            label_ProtocolTemplateName.Text = "Protokollets Mall-Namn";
            // 
            // tlp_Top
            // 
            tlp_Top.ColumnCount = 3;
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 292F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 292F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1814F));
            tlp_Top.Controls.Add(tlp_ExtraInfo, 2, 0);
            tlp_Top.Controls.Add(btn_SaveNewTemplate, 0, 0);
            tlp_Top.Controls.Add(btn_PreviewTemplate, 1, 1);
            tlp_Top.Controls.Add(btn_DeleteTemplate, 0, 2);
            tlp_Top.Controls.Add(btn_UpdateTemplate, 0, 1);
            tlp_Top.Controls.Add(btn_ConnectPartNr_NewTemplate, 1, 0);
            tlp_Top.Dock = DockStyle.Top;
            tlp_Top.Location = new Point(0, 0);
            tlp_Top.Margin = new Padding(0);
            tlp_Top.Name = "tlp_Top";
            tlp_Top.Padding = new Padding(0, 6, 0, 0);
            tlp_Top.RowCount = 3;
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tlp_Top.Size = new Size(2398, 126);
            tlp_Top.TabIndex = 878;
            // 
            // tlp_ExtraInfo
            // 
            tlp_ExtraInfo.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp_ExtraInfo.ColumnCount = 2;
            tlp_ExtraInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tlp_ExtraInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_ExtraInfo.Controls.Add(label_TotalConnectedOrders, 0, 2);
            tlp_ExtraInfo.Controls.Add(lbl_CreatedDate, 1, 1);
            tlp_ExtraInfo.Controls.Add(lbl_CreatedBy, 1, 0);
            tlp_ExtraInfo.Controls.Add(label_CreatedDate, 0, 1);
            tlp_ExtraInfo.Controls.Add(label_CreatedBy, 0, 0);
            tlp_ExtraInfo.Controls.Add(label_TotalConnectedProcesscards, 0, 3);
            tlp_ExtraInfo.Dock = DockStyle.Right;
            tlp_ExtraInfo.Location = new Point(1862, 6);
            tlp_ExtraInfo.Margin = new Padding(0);
            tlp_ExtraInfo.Name = "tlp_ExtraInfo";
            tlp_ExtraInfo.Padding = new Padding(0, 0, 6, 0);
            tlp_ExtraInfo.RowCount = 4;
            tlp_Top.SetRowSpan(tlp_ExtraInfo, 2);
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_ExtraInfo.Size = new Size(536, 80);
            tlp_ExtraInfo.TabIndex = 19;
            // 
            // label_TotalConnectedOrders
            // 
            label_TotalConnectedOrders.AutoSize = true;
            tlp_ExtraInfo.SetColumnSpan(label_TotalConnectedOrders, 2);
            label_TotalConnectedOrders.Dock = DockStyle.Right;
            label_TotalConnectedOrders.Font = new Font("Lucida Sans", 11.25F);
            label_TotalConnectedOrders.ForeColor = Color.FromArgb(187, 215, 228);
            label_TotalConnectedOrders.Location = new Point(274, 39);
            label_TotalConnectedOrders.Margin = new Padding(4, 0, 4, 0);
            label_TotalConnectedOrders.Name = "label_TotalConnectedOrders";
            label_TotalConnectedOrders.Size = new Size(251, 18);
            label_TotalConnectedOrders.TabIndex = 16;
            label_TotalConnectedOrders.Text = "Antal Ordrar kopplade till mallen:";
            label_TotalConnectedOrders.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_CreatedDate
            // 
            lbl_CreatedDate.AutoSize = true;
            lbl_CreatedDate.BackColor = Color.Transparent;
            lbl_CreatedDate.Dock = DockStyle.Fill;
            lbl_CreatedDate.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold);
            lbl_CreatedDate.ForeColor = Color.FromArgb(255, 235, 156);
            lbl_CreatedDate.Location = new Point(177, 20);
            lbl_CreatedDate.Margin = new Padding(0);
            lbl_CreatedDate.Name = "lbl_CreatedDate";
            lbl_CreatedDate.Size = new Size(352, 18);
            lbl_CreatedDate.TabIndex = 18;
            lbl_CreatedDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_CreatedBy
            // 
            lbl_CreatedBy.AutoSize = true;
            lbl_CreatedBy.BackColor = Color.Transparent;
            lbl_CreatedBy.Dock = DockStyle.Fill;
            lbl_CreatedBy.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold);
            lbl_CreatedBy.ForeColor = Color.FromArgb(255, 235, 156);
            lbl_CreatedBy.Location = new Point(177, 1);
            lbl_CreatedBy.Margin = new Padding(0);
            lbl_CreatedBy.Name = "lbl_CreatedBy";
            lbl_CreatedBy.Size = new Size(352, 18);
            lbl_CreatedBy.TabIndex = 17;
            lbl_CreatedBy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_CreatedDate
            // 
            label_CreatedDate.AutoSize = true;
            label_CreatedDate.Dock = DockStyle.Right;
            label_CreatedDate.Font = new Font("Lucida Sans", 11.25F);
            label_CreatedDate.ForeColor = Color.FromArgb(187, 215, 228);
            label_CreatedDate.Location = new Point(56, 20);
            label_CreatedDate.Margin = new Padding(4, 0, 4, 0);
            label_CreatedDate.Name = "label_CreatedDate";
            label_CreatedDate.Size = new Size(116, 18);
            label_CreatedDate.TabIndex = 16;
            label_CreatedDate.Text = "Mallen skapad:";
            // 
            // label_CreatedBy
            // 
            label_CreatedBy.AutoSize = true;
            label_CreatedBy.Dock = DockStyle.Right;
            label_CreatedBy.Font = new Font("Lucida Sans", 11.25F);
            label_CreatedBy.ForeColor = Color.FromArgb(187, 215, 228);
            label_CreatedBy.Location = new Point(34, 1);
            label_CreatedBy.Margin = new Padding(4, 0, 4, 0);
            label_CreatedBy.Name = "label_CreatedBy";
            label_CreatedBy.Size = new Size(138, 18);
            label_CreatedBy.TabIndex = 16;
            label_CreatedBy.Text = "Mallen skapad av:";
            // 
            // label_TotalConnectedProcesscards
            // 
            label_TotalConnectedProcesscards.AutoSize = true;
            tlp_ExtraInfo.SetColumnSpan(label_TotalConnectedProcesscards, 2);
            label_TotalConnectedProcesscards.Dock = DockStyle.Right;
            label_TotalConnectedProcesscards.Font = new Font("Lucida Sans", 11.25F);
            label_TotalConnectedProcesscards.ForeColor = Color.FromArgb(187, 215, 228);
            label_TotalConnectedProcesscards.Location = new Point(234, 58);
            label_TotalConnectedProcesscards.Margin = new Padding(4, 0, 4, 0);
            label_TotalConnectedProcesscards.Name = "label_TotalConnectedProcesscards";
            label_TotalConnectedProcesscards.Size = new Size(291, 21);
            label_TotalConnectedProcesscards.TabIndex = 16;
            label_TotalConnectedProcesscards.Text = "Antal Processkort kopplade till mallen:";
            label_TotalConnectedProcesscards.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn_ConnectPartNr_NewTemplate
            // 
            btn_ConnectPartNr_NewTemplate.BackColor = Color.FromArgb(185, 188, 189);
            btn_ConnectPartNr_NewTemplate.Cursor = Cursors.Hand;
            btn_ConnectPartNr_NewTemplate.Dock = DockStyle.Fill;
            btn_ConnectPartNr_NewTemplate.FlatStyle = FlatStyle.Flat;
            btn_ConnectPartNr_NewTemplate.Font = new Font("Lucida Sans", 10.25F);
            btn_ConnectPartNr_NewTemplate.ForeColor = Color.FromArgb(63, 116, 140);
            btn_ConnectPartNr_NewTemplate.Location = new Point(292, 6);
            btn_ConnectPartNr_NewTemplate.Margin = new Padding(0);
            btn_ConnectPartNr_NewTemplate.Name = "btn_ConnectPartNr_NewTemplate";
            btn_ConnectPartNr_NewTemplate.Size = new Size(292, 40);
            btn_ConnectPartNr_NewTemplate.TabIndex = 20;
            btn_ConnectPartNr_NewTemplate.Text = "Koppla Aktiv Mall till Processkort";
            btn_ConnectPartNr_NewTemplate.UseVisualStyleBackColor = false;
            btn_ConnectPartNr_NewTemplate.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 583F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 817F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tableLayoutPanel1.Controls.Add(gbx_CategoryLineClearance, 0, 0);
            tableLayoutPanel1.Controls.Add(gbx_Tasks, 0, 1);
            tableLayoutPanel1.Controls.Add(flp_Main, 2, 2);
            tableLayoutPanel1.Controls.Add(gbox_LineClearanceTemplate, 2, 0);
            tableLayoutPanel1.Controls.Add(dgv_Tasks, 0, 2);
            tableLayoutPanel1.Controls.Add(web_PDF_Viewer, 3, 2);
            tableLayoutPanel1.Controls.Add(flp_ObjectManagement, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 126);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 111F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 115F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            tableLayoutPanel1.Size = new Size(2398, 1098);
            tableLayoutPanel1.TabIndex = 879;
            // 
            // web_PDF_Viewer
            // 
            web_PDF_Viewer.Dock = DockStyle.Fill;
            web_PDF_Viewer.Location = new Point(1544, 229);
            web_PDF_Viewer.Margin = new Padding(4, 3, 4, 3);
            web_PDF_Viewer.MinimumSize = new Size(23, 23);
            web_PDF_Viewer.Name = "web_PDF_Viewer";
            web_PDF_Viewer.Size = new Size(850, 866);
            web_PDF_Viewer.TabIndex = 22;
            // 
            // flp_ObjectManagement
            // 
            flp_ObjectManagement.Controls.Add(label_ActiveCategory);
            flp_ObjectManagement.Controls.Add(label_Buttons_Category);
            flp_ObjectManagement.Controls.Add(pb_RenameCategory);
            flp_ObjectManagement.Controls.Add(btn_MoveCategoryUp);
            flp_ObjectManagement.Controls.Add(btn_MoveCategoryDown);
            flp_ObjectManagement.Controls.Add(btn_DeleteCategory);
            flp_ObjectManagement.Controls.Add(label_Buttons_Task);
            flp_ObjectManagement.Controls.Add(btn_MoveTaskUp);
            flp_ObjectManagement.Controls.Add(btn_MoveTaskDown);
            flp_ObjectManagement.Controls.Add(btn_DeleteTask);
            flp_ObjectManagement.Dock = DockStyle.Fill;
            flp_ObjectManagement.FlowDirection = FlowDirection.TopDown;
            flp_ObjectManagement.Location = new Point(587, 229);
            flp_ObjectManagement.Margin = new Padding(4, 3, 4, 3);
            flp_ObjectManagement.Name = "flp_ObjectManagement";
            flp_ObjectManagement.Size = new Size(132, 866);
            flp_ObjectManagement.TabIndex = 23;
            // 
            // Templates_LineClearance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(2398, 1224);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tlp_Top);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Templates_LineClearance";
            Text = "Hantera Line-Clearance Mallar";
            WindowState = FormWindowState.Maximized;
            FormClosed += Manage_Templates_FormClosed;
            ((ISupportInitialize)dgv_Tasks).EndInit();
            ((ISupportInitialize)pb_RenameCategory).EndInit();
            ((ISupportInitialize)btn_MoveTaskUp).EndInit();
            ((ISupportInitialize)btn_MoveTaskDown).EndInit();
            ((ISupportInitialize)btn_MoveCategoryUp).EndInit();
            ((ISupportInitialize)btn_MoveCategoryDown).EndInit();
            ((ISupportInitialize)btn_DeleteTask).EndInit();
            ((ISupportInitialize)btn_DeleteCategory).EndInit();
            gbx_CategoryLineClearance.ResumeLayout(false);
            gbx_CategoryLineClearance.PerformLayout();
            gbx_Tasks.ResumeLayout(false);
            gbx_Tasks.PerformLayout();
            gbox_LineClearanceTemplate.ResumeLayout(false);
            gbox_LineClearanceTemplate.PerformLayout();
            tlp_Top.ResumeLayout(false);
            tlp_ExtraInfo.ResumeLayout(false);
            tlp_ExtraInfo.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            flp_ObjectManagement.ResumeLayout(false);
            flp_ObjectManagement.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flp_Main;
        private DataGridView dgv_Tasks;
        private TextBox tb_Category;
        private ComboBox cb_TemplateName;
        private Button btn_SaveNewTemplate;
        private Button btn_UpdateTemplate;
        private Label label_LineClearanceRevision;
        private Button btn_NewModule;
        private Button btn_PreviewTemplate;
        private ComboBox cb_TemplateRevision;
        private Button btn_DeleteTemplate;
        private Label label_Buttons_Category;
        private PictureBox btn_DeleteCategory;
        private PictureBox btn_DeleteTask;
        private Label label_Buttons_Task;
        private PictureBox btn_MoveTaskUp;
        private PictureBox btn_MoveTaskDown;
        private PictureBox btn_MoveCategoryUp;
        private PictureBox btn_MoveCategoryDown;
        private Button btn_NewRevision;
        private PictureBox pb_RenameCategory;
        private ToolTip toolTip;
        private TextBox tb_AddNewTask;
        private Button btn_AddTask;
        private GroupBox gbx_CategoryLineClearance;
        private GroupBox gbx_Tasks;
        private Label label_ActiveCategory;
        private GroupBox gbox_LineClearanceTemplate;
        private Label label_ProtocolTemplateName;
        private CheckBox chb_IsApprovalRequired;
        private TextBox tb_Centuri;
        private TableLayoutPanel tlp_Top;
        private TableLayoutPanel tlp_ExtraInfo;
        private Label label_TotalConnectedOrders;
        private Label lbl_CreatedDate;
        private Label lbl_CreatedBy;
        private Label label_CreatedDate;
        private Label label_CreatedBy;
        private Label label_TotalConnectedProcesscards;
        private TableLayoutPanel tableLayoutPanel1;
        private WebBrowser web_PDF_Viewer;
        private FlowLayoutPanel flp_ObjectManagement;
        private Button btn_ConnectPartNr_NewTemplate;
    }
}