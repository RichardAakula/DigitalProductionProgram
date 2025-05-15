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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Templates_LineClearance));
            this.flp_Main = new System.Windows.Forms.FlowLayoutPanel();
            this.dgv_Tasks = new System.Windows.Forms.DataGridView();
            this.tb_Category = new System.Windows.Forms.TextBox();
            this.cb_TemplateName = new System.Windows.Forms.ComboBox();
            this.btn_SaveNewTemplate = new System.Windows.Forms.Button();
            this.btn_UpdateTemplate = new System.Windows.Forms.Button();
            this.label_LineClearanceRevision = new System.Windows.Forms.Label();
            this.btn_NewModule = new System.Windows.Forms.Button();
            this.btn_PreviewTemplate = new System.Windows.Forms.Button();
            this.cb_TemplateRevision = new System.Windows.Forms.ComboBox();
            this.btn_DeleteTemplate = new System.Windows.Forms.Button();
            this.pb_RenameCategory = new System.Windows.Forms.PictureBox();
            this.btn_MoveTaskUp = new System.Windows.Forms.PictureBox();
            this.btn_MoveTaskDown = new System.Windows.Forms.PictureBox();
            this.btn_MoveCategoryUp = new System.Windows.Forms.PictureBox();
            this.btn_MoveCategoryDown = new System.Windows.Forms.PictureBox();
            this.btn_DeleteTask = new System.Windows.Forms.PictureBox();
            this.btn_DeleteCategory = new System.Windows.Forms.PictureBox();
            this.label_Buttons_Task = new System.Windows.Forms.Label();
            this.label_Buttons_Category = new System.Windows.Forms.Label();
            this.label_ActiveCategory = new System.Windows.Forms.Label();
            this.btn_NewRevision = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tb_AddNewTask = new System.Windows.Forms.TextBox();
            this.btn_AddTask = new System.Windows.Forms.Button();
            this.gbx_CategoryLineClearance = new System.Windows.Forms.GroupBox();
            this.gbx_Tasks = new System.Windows.Forms.GroupBox();
            this.gbox_LineClearanceTemplate = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Centuri = new System.Windows.Forms.TextBox();
            this.chb_IsApprovalRequired = new System.Windows.Forms.CheckBox();
            this.label_ProtocolTemplateName = new System.Windows.Forms.Label();
            this.tlp_Top = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_ExtraInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label_TotalConnectedOrders = new System.Windows.Forms.Label();
            this.lbl_CreatedDate = new System.Windows.Forms.Label();
            this.lbl_CreatedBy = new System.Windows.Forms.Label();
            this.label_CreatedDate = new System.Windows.Forms.Label();
            this.label_CreatedBy = new System.Windows.Forms.Label();
            this.label_TotalConnectedProcesscards = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.web_PDF_Viewer = new System.Windows.Forms.WebBrowser();
            this.flp_ObjectManagement = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_ConnectPartNr_NewTemplate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_RenameCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_MoveTaskUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_MoveTaskDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_MoveCategoryUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_MoveCategoryDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DeleteTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DeleteCategory)).BeginInit();
            this.gbx_CategoryLineClearance.SuspendLayout();
            this.gbx_Tasks.SuspendLayout();
            this.gbox_LineClearanceTemplate.SuspendLayout();
            this.tlp_Top.SuspendLayout();
            this.tlp_ExtraInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flp_ObjectManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_Main
            // 
            this.flp_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flp_Main.AutoScroll = true;
            this.flp_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            this.flp_Main.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Main.Location = new System.Drawing.Point(623, 199);
            this.flp_Main.MaximumSize = new System.Drawing.Size(1320, 2000);
            this.flp_Main.Name = "flp_Main";
            this.flp_Main.Size = new System.Drawing.Size(694, 750);
            this.flp_Main.TabIndex = 0;
            this.flp_Main.WrapContents = false;
            // 
            // dgv_Tasks
            // 
            this.dgv_Tasks.AllowUserToAddRows = false;
            this.dgv_Tasks.AllowUserToDeleteRows = false;
            this.dgv_Tasks.AllowUserToResizeColumns = false;
            this.dgv_Tasks.AllowUserToResizeRows = false;
            this.dgv_Tasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_Tasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Tasks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            this.dgv_Tasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tasks.Location = new System.Drawing.Point(3, 199);
            this.dgv_Tasks.MultiSelect = false;
            this.dgv_Tasks.Name = "dgv_Tasks";
            this.dgv_Tasks.ReadOnly = true;
            this.dgv_Tasks.RowHeadersVisible = false;
            this.dgv_Tasks.Size = new System.Drawing.Size(494, 750);
            this.dgv_Tasks.TabIndex = 2;
            this.dgv_Tasks.Visible = false;
            this.dgv_Tasks.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Tasks_CellMouseDown);
            this.dgv_Tasks.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Tasks_ColumnHeaderMouseClick);
            this.dgv_Tasks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodeText_KeyPress);
            // 
            // tb_Category
            // 
            this.tb_Category.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.tb_Category.Location = new System.Drawing.Point(6, 57);
            this.tb_Category.Name = "tb_Category";
            this.tb_Category.Size = new System.Drawing.Size(551, 20);
            this.tb_Category.TabIndex = 3;
            // 
            // cb_TemplateName
            // 
            this.cb_TemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_TemplateName.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.cb_TemplateName.FormattingEnabled = true;
            this.cb_TemplateName.Location = new System.Drawing.Point(6, 156);
            this.cb_TemplateName.Name = "cb_TemplateName";
            this.cb_TemplateName.Size = new System.Drawing.Size(396, 25);
            this.cb_TemplateName.TabIndex = 4;
            this.cb_TemplateName.SelectedIndexChanged += new System.EventHandler(this.Template_Name_SelectedIndexChanged);
            // 
            // btn_SaveNewTemplate
            // 
            this.btn_SaveNewTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_SaveNewTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveNewTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SaveNewTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveNewTemplate.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_SaveNewTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_SaveNewTemplate.Location = new System.Drawing.Point(5, 5);
            this.btn_SaveNewTemplate.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_SaveNewTemplate.Name = "btn_SaveNewTemplate";
            this.btn_SaveNewTemplate.Size = new System.Drawing.Size(245, 34);
            this.btn_SaveNewTemplate.TabIndex = 1;
            this.btn_SaveNewTemplate.Text = "Spara Mall";
            this.btn_SaveNewTemplate.UseVisualStyleBackColor = false;
            this.btn_SaveNewTemplate.Click += new System.EventHandler(this.Save_Template_Click);
            // 
            // btn_UpdateTemplate
            // 
            this.btn_UpdateTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_UpdateTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_UpdateTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_UpdateTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UpdateTemplate.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_UpdateTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_UpdateTemplate.Location = new System.Drawing.Point(5, 39);
            this.btn_UpdateTemplate.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_UpdateTemplate.Name = "btn_UpdateTemplate";
            this.btn_UpdateTemplate.Size = new System.Drawing.Size(245, 34);
            this.btn_UpdateTemplate.TabIndex = 1;
            this.btn_UpdateTemplate.Text = "Uppdatera Mall";
            this.btn_UpdateTemplate.UseVisualStyleBackColor = false;
            this.btn_UpdateTemplate.Click += new System.EventHandler(this.Update_Template_Click);
            // 
            // label_LineClearanceRevision
            // 
            this.label_LineClearanceRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_LineClearanceRevision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.label_LineClearanceRevision.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_LineClearanceRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(108)))), ((int)(((byte)(121)))));
            this.label_LineClearanceRevision.Location = new System.Drawing.Point(513, 131);
            this.label_LineClearanceRevision.Name = "label_LineClearanceRevision";
            this.label_LineClearanceRevision.Size = new System.Drawing.Size(175, 22);
            this.label_LineClearanceRevision.TabIndex = 9;
            this.label_LineClearanceRevision.Text = "Line-Clearance Revision";
            // 
            // btn_NewModule
            // 
            this.btn_NewModule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_NewModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NewModule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewModule.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_NewModule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_NewModule.Location = new System.Drawing.Point(6, 23);
            this.btn_NewModule.Name = "btn_NewModule";
            this.btn_NewModule.Size = new System.Drawing.Size(109, 28);
            this.btn_NewModule.TabIndex = 11;
            this.btn_NewModule.Text = "Lägg till";
            this.btn_NewModule.UseVisualStyleBackColor = false;
            this.btn_NewModule.Click += new System.EventHandler(this.NewModule_Click);
            // 
            // btn_PreviewTemplate
            // 
            this.btn_PreviewTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_PreviewTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PreviewTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PreviewTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PreviewTemplate.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_PreviewTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_PreviewTemplate.Location = new System.Drawing.Point(250, 39);
            this.btn_PreviewTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.btn_PreviewTemplate.Name = "btn_PreviewTemplate";
            this.btn_PreviewTemplate.Size = new System.Drawing.Size(250, 34);
            this.btn_PreviewTemplate.TabIndex = 1;
            this.btn_PreviewTemplate.Text = "Förhandsgranska Mall";
            this.btn_PreviewTemplate.UseVisualStyleBackColor = false;
            this.btn_PreviewTemplate.Click += new System.EventHandler(this.PreviewTemplate_Click);
            // 
            // cb_TemplateRevision
            // 
            this.cb_TemplateRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_TemplateRevision.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.cb_TemplateRevision.FormattingEnabled = true;
            this.cb_TemplateRevision.Location = new System.Drawing.Point(513, 156);
            this.cb_TemplateRevision.Name = "cb_TemplateRevision";
            this.cb_TemplateRevision.Size = new System.Drawing.Size(73, 25);
            this.cb_TemplateRevision.TabIndex = 14;
            this.cb_TemplateRevision.Text = "A";
            this.cb_TemplateRevision.SelectedIndexChanged += new System.EventHandler(this.Template_RevisionNr_SelectedIndexChanged);
            this.cb_TemplateRevision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Revision_KeyPress);
            // 
            // btn_DeleteTemplate
            // 
            this.btn_DeleteTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_DeleteTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_DeleteTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteTemplate.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_DeleteTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_DeleteTemplate.Location = new System.Drawing.Point(5, 73);
            this.btn_DeleteTemplate.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_DeleteTemplate.Name = "btn_DeleteTemplate";
            this.btn_DeleteTemplate.Size = new System.Drawing.Size(245, 36);
            this.btn_DeleteTemplate.TabIndex = 1;
            this.btn_DeleteTemplate.Text = "Radera Mall";
            this.btn_DeleteTemplate.UseVisualStyleBackColor = false;
            this.btn_DeleteTemplate.Click += new System.EventHandler(this.Delete_Template_Click);
            // 
            // pb_RenameCategory
            // 
            this.pb_RenameCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb_RenameCategory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_RenameCategory.BackgroundImage")));
            this.pb_RenameCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_RenameCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_RenameCategory.Location = new System.Drawing.Point(38, 98);
            this.pb_RenameCategory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.pb_RenameCategory.Name = "pb_RenameCategory";
            this.pb_RenameCategory.Size = new System.Drawing.Size(41, 41);
            this.pb_RenameCategory.TabIndex = 5;
            this.pb_RenameCategory.TabStop = false;
            this.toolTip.SetToolTip(this.pb_RenameCategory, "Fyll i det nya namnet till vänster ");
            this.pb_RenameCategory.Click += new System.EventHandler(this.RenameModule_Click);
            // 
            // btn_MoveTaskUp
            // 
            this.btn_MoveTaskUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_MoveTaskUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_MoveTaskUp.BackgroundImage")));
            this.btn_MoveTaskUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_MoveTaskUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MoveTaskUp.Location = new System.Drawing.Point(45, 312);
            this.btn_MoveTaskUp.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btn_MoveTaskUp.Name = "btn_MoveTaskUp";
            this.btn_MoveTaskUp.Size = new System.Drawing.Size(26, 29);
            this.btn_MoveTaskUp.TabIndex = 3;
            this.btn_MoveTaskUp.TabStop = false;
            this.btn_MoveTaskUp.Click += new System.EventHandler(this.MoveTaskUp_Click);
            // 
            // btn_MoveTaskDown
            // 
            this.btn_MoveTaskDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_MoveTaskDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_MoveTaskDown.BackgroundImage")));
            this.btn_MoveTaskDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_MoveTaskDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MoveTaskDown.Location = new System.Drawing.Point(45, 349);
            this.btn_MoveTaskDown.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btn_MoveTaskDown.Name = "btn_MoveTaskDown";
            this.btn_MoveTaskDown.Size = new System.Drawing.Size(26, 29);
            this.btn_MoveTaskDown.TabIndex = 4;
            this.btn_MoveTaskDown.TabStop = false;
            this.btn_MoveTaskDown.Click += new System.EventHandler(this.MoveTaskDown_Click);
            // 
            // btn_MoveCategoryUp
            // 
            this.btn_MoveCategoryUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_MoveCategoryUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_MoveCategoryUp.BackgroundImage")));
            this.btn_MoveCategoryUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_MoveCategoryUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MoveCategoryUp.Location = new System.Drawing.Point(45, 147);
            this.btn_MoveCategoryUp.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btn_MoveCategoryUp.Name = "btn_MoveCategoryUp";
            this.btn_MoveCategoryUp.Size = new System.Drawing.Size(26, 29);
            this.btn_MoveCategoryUp.TabIndex = 2;
            this.btn_MoveCategoryUp.TabStop = false;
            this.btn_MoveCategoryUp.Click += new System.EventHandler(this.MoveCategoryUp_Click);
            // 
            // btn_MoveCategoryDown
            // 
            this.btn_MoveCategoryDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_MoveCategoryDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_MoveCategoryDown.BackgroundImage")));
            this.btn_MoveCategoryDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_MoveCategoryDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MoveCategoryDown.Location = new System.Drawing.Point(45, 184);
            this.btn_MoveCategoryDown.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btn_MoveCategoryDown.Name = "btn_MoveCategoryDown";
            this.btn_MoveCategoryDown.Size = new System.Drawing.Size(26, 29);
            this.btn_MoveCategoryDown.TabIndex = 2;
            this.btn_MoveCategoryDown.TabStop = false;
            this.btn_MoveCategoryDown.Click += new System.EventHandler(this.MoveCategoryDown_Click);
            // 
            // btn_DeleteTask
            // 
            this.btn_DeleteTask.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_DeleteTask.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_DeleteTask.BackgroundImage")));
            this.btn_DeleteTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DeleteTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteTask.Location = new System.Drawing.Point(38, 386);
            this.btn_DeleteTask.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btn_DeleteTask.Name = "btn_DeleteTask";
            this.btn_DeleteTask.Size = new System.Drawing.Size(41, 41);
            this.btn_DeleteTask.TabIndex = 1;
            this.btn_DeleteTask.TabStop = false;
            this.toolTip.SetToolTip(this.btn_DeleteTask, "Radera markerad rad");
            this.btn_DeleteTask.Click += new System.EventHandler(this.DeleteTask_Click);
            // 
            // btn_DeleteCategory
            // 
            this.btn_DeleteCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_DeleteCategory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_DeleteCategory.BackgroundImage")));
            this.btn_DeleteCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DeleteCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteCategory.Location = new System.Drawing.Point(38, 221);
            this.btn_DeleteCategory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.btn_DeleteCategory.Name = "btn_DeleteCategory";
            this.btn_DeleteCategory.Size = new System.Drawing.Size(41, 41);
            this.btn_DeleteCategory.TabIndex = 1;
            this.btn_DeleteCategory.TabStop = false;
            this.toolTip.SetToolTip(this.btn_DeleteCategory, "Radera markerad modul");
            this.btn_DeleteCategory.Click += new System.EventHandler(this.DeleteCategory_Click);
            // 
            // label_Buttons_Task
            // 
            this.label_Buttons_Task.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Buttons_Task.AutoSize = true;
            this.label_Buttons_Task.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold);
            this.label_Buttons_Task.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.label_Buttons_Task.Location = new System.Drawing.Point(27, 287);
            this.label_Buttons_Task.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.label_Buttons_Task.Name = "label_Buttons_Task";
            this.label_Buttons_Task.Size = new System.Drawing.Size(62, 17);
            this.label_Buttons_Task.TabIndex = 0;
            this.label_Buttons_Task.Text = "Åtgärd";
            // 
            // label_Buttons_Category
            // 
            this.label_Buttons_Category.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Buttons_Category.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold);
            this.label_Buttons_Category.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.label_Buttons_Category.Location = new System.Drawing.Point(3, 61);
            this.label_Buttons_Category.Margin = new System.Windows.Forms.Padding(3, 20, 3, 10);
            this.label_Buttons_Category.Name = "label_Buttons_Category";
            this.label_Buttons_Category.Size = new System.Drawing.Size(111, 24);
            this.label_Buttons_Category.TabIndex = 0;
            this.label_Buttons_Category.Text = "Kategori";
            this.label_Buttons_Category.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ActiveCategory
            // 
            this.label_ActiveCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_ActiveCategory.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold);
            this.label_ActiveCategory.ForeColor = System.Drawing.Color.Silver;
            this.label_ActiveCategory.Location = new System.Drawing.Point(3, 0);
            this.label_ActiveCategory.Name = "label_ActiveCategory";
            this.label_ActiveCategory.Size = new System.Drawing.Size(111, 41);
            this.label_ActiveCategory.TabIndex = 0;
            this.label_ActiveCategory.Text = "Aktiv Kategori";
            this.label_ActiveCategory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_NewRevision
            // 
            this.btn_NewRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NewRevision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_NewRevision.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NewRevision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewRevision.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_NewRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_NewRevision.Location = new System.Drawing.Point(592, 156);
            this.btn_NewRevision.Name = "btn_NewRevision";
            this.btn_NewRevision.Size = new System.Drawing.Size(96, 25);
            this.btn_NewRevision.TabIndex = 1;
            this.btn_NewRevision.Text = "Ny Revision";
            this.toolTip.SetToolTip(this.btn_NewRevision, "Vänsterklicka för att stega upp en revision, högerklicka för att stega ner en rev" +
        "ision.");
            this.btn_NewRevision.UseVisualStyleBackColor = false;
            this.btn_NewRevision.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewRevision_MouseDown);
            // 
            // tb_AddNewTask
            // 
            this.tb_AddNewTask.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.tb_AddNewTask.Location = new System.Drawing.Point(6, 57);
            this.tb_AddNewTask.Name = "tb_AddNewTask";
            this.tb_AddNewTask.Size = new System.Drawing.Size(551, 20);
            this.tb_AddNewTask.TabIndex = 3;
            this.tb_AddNewTask.TextChanged += new System.EventHandler(this.FilterTask_TextChanged);
            // 
            // btn_AddTask
            // 
            this.btn_AddTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_AddTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddTask.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_AddTask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_AddTask.Location = new System.Drawing.Point(6, 23);
            this.btn_AddTask.Name = "btn_AddTask";
            this.btn_AddTask.Size = new System.Drawing.Size(121, 28);
            this.btn_AddTask.TabIndex = 11;
            this.btn_AddTask.Text = "Lägg till Åtgärd";
            this.btn_AddTask.UseVisualStyleBackColor = false;
            this.btn_AddTask.Click += new System.EventHandler(this.AddTaskText_Click);
            // 
            // gbx_CategoryLineClearance
            // 
            this.gbx_CategoryLineClearance.Controls.Add(this.btn_NewModule);
            this.gbx_CategoryLineClearance.Controls.Add(this.tb_Category);
            this.gbx_CategoryLineClearance.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.gbx_CategoryLineClearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.gbx_CategoryLineClearance.Location = new System.Drawing.Point(3, 3);
            this.gbx_CategoryLineClearance.Name = "gbx_CategoryLineClearance";
            this.gbx_CategoryLineClearance.Size = new System.Drawing.Size(494, 90);
            this.gbx_CategoryLineClearance.TabIndex = 20;
            this.gbx_CategoryLineClearance.TabStop = false;
            this.gbx_CategoryLineClearance.Text = "Kategori";
            // 
            // gbx_Tasks
            // 
            this.gbx_Tasks.Controls.Add(this.btn_AddTask);
            this.gbx_Tasks.Controls.Add(this.tb_AddNewTask);
            this.gbx_Tasks.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.gbx_Tasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.gbx_Tasks.Location = new System.Drawing.Point(3, 99);
            this.gbx_Tasks.Name = "gbx_Tasks";
            this.gbx_Tasks.Size = new System.Drawing.Size(494, 90);
            this.gbx_Tasks.TabIndex = 21;
            this.gbx_Tasks.TabStop = false;
            this.gbx_Tasks.Text = "Åtgärder";
            // 
            // gbox_LineClearanceTemplate
            // 
            this.gbox_LineClearanceTemplate.Controls.Add(this.label1);
            this.gbox_LineClearanceTemplate.Controls.Add(this.tb_Centuri);
            this.gbox_LineClearanceTemplate.Controls.Add(this.chb_IsApprovalRequired);
            this.gbox_LineClearanceTemplate.Controls.Add(this.cb_TemplateName);
            this.gbox_LineClearanceTemplate.Controls.Add(this.btn_NewRevision);
            this.gbox_LineClearanceTemplate.Controls.Add(this.label_ProtocolTemplateName);
            this.gbox_LineClearanceTemplate.Controls.Add(this.label_LineClearanceRevision);
            this.gbox_LineClearanceTemplate.Controls.Add(this.cb_TemplateRevision);
            this.gbox_LineClearanceTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbox_LineClearanceTemplate.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.gbox_LineClearanceTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.gbox_LineClearanceTemplate.Location = new System.Drawing.Point(623, 3);
            this.gbox_LineClearanceTemplate.Name = "gbox_LineClearanceTemplate";
            this.tableLayoutPanel1.SetRowSpan(this.gbox_LineClearanceTemplate, 2);
            this.gbox_LineClearanceTemplate.Size = new System.Drawing.Size(694, 190);
            this.gbox_LineClearanceTemplate.TabIndex = 21;
            this.gbox_LineClearanceTemplate.TabStop = false;
            this.gbox_LineClearanceTemplate.Text = "Line-Clearance Mall";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Länk till Centuri:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Centuri
            // 
            this.tb_Centuri.Font = new System.Drawing.Font("Lucida Sans", 10.25F, System.Drawing.FontStyle.Underline);
            this.tb_Centuri.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tb_Centuri.Location = new System.Drawing.Point(140, 66);
            this.tb_Centuri.Name = "tb_Centuri";
            this.tb_Centuri.Size = new System.Drawing.Size(551, 24);
            this.tb_Centuri.TabIndex = 3;
            this.tb_Centuri.Click += new System.EventHandler(this.Centuri_Click);
            // 
            // chb_IsApprovalRequired
            // 
            this.chb_IsApprovalRequired.AutoSize = true;
            this.chb_IsApprovalRequired.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.chb_IsApprovalRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.chb_IsApprovalRequired.Location = new System.Drawing.Point(9, 28);
            this.chb_IsApprovalRequired.Name = "chb_IsApprovalRequired";
            this.chb_IsApprovalRequired.Size = new System.Drawing.Size(414, 21);
            this.chb_IsApprovalRequired.TabIndex = 15;
            this.chb_IsApprovalRequired.Text = "Skall Line-Clearance godkännas av behörig Personal?";
            this.chb_IsApprovalRequired.UseVisualStyleBackColor = true;
            // 
            // label_ProtocolTemplateName
            // 
            this.label_ProtocolTemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ProtocolTemplateName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.label_ProtocolTemplateName.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_ProtocolTemplateName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(108)))), ((int)(((byte)(121)))));
            this.label_ProtocolTemplateName.Location = new System.Drawing.Point(6, 131);
            this.label_ProtocolTemplateName.Name = "label_ProtocolTemplateName";
            this.label_ProtocolTemplateName.Size = new System.Drawing.Size(175, 22);
            this.label_ProtocolTemplateName.TabIndex = 9;
            this.label_ProtocolTemplateName.Text = "Protokollets Mall-Namn";
            // 
            // tlp_Top
            // 
            this.tlp_Top.ColumnCount = 3;
            this.tlp_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlp_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlp_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1555F));
            this.tlp_Top.Controls.Add(this.tlp_ExtraInfo, 2, 0);
            this.tlp_Top.Controls.Add(this.btn_SaveNewTemplate, 0, 0);
            this.tlp_Top.Controls.Add(this.btn_PreviewTemplate, 1, 1);
            this.tlp_Top.Controls.Add(this.btn_DeleteTemplate, 0, 2);
            this.tlp_Top.Controls.Add(this.btn_UpdateTemplate, 0, 1);
            this.tlp_Top.Controls.Add(this.btn_ConnectPartNr_NewTemplate, 1, 0);
            this.tlp_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_Top.Location = new System.Drawing.Point(0, 0);
            this.tlp_Top.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Top.Name = "tlp_Top";
            this.tlp_Top.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tlp_Top.RowCount = 3;
            this.tlp_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Top.Size = new System.Drawing.Size(2055, 109);
            this.tlp_Top.TabIndex = 878;
            // 
            // tlp_ExtraInfo
            // 
            this.tlp_ExtraInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp_ExtraInfo.ColumnCount = 2;
            this.tlp_ExtraInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlp_ExtraInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_ExtraInfo.Controls.Add(this.label_TotalConnectedOrders, 0, 2);
            this.tlp_ExtraInfo.Controls.Add(this.lbl_CreatedDate, 1, 1);
            this.tlp_ExtraInfo.Controls.Add(this.lbl_CreatedBy, 1, 0);
            this.tlp_ExtraInfo.Controls.Add(this.label_CreatedDate, 0, 1);
            this.tlp_ExtraInfo.Controls.Add(this.label_CreatedBy, 0, 0);
            this.tlp_ExtraInfo.Controls.Add(this.label_TotalConnectedProcesscards, 0, 3);
            this.tlp_ExtraInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlp_ExtraInfo.Location = new System.Drawing.Point(1596, 5);
            this.tlp_ExtraInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_ExtraInfo.Name = "tlp_ExtraInfo";
            this.tlp_ExtraInfo.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tlp_ExtraInfo.RowCount = 4;
            this.tlp_Top.SetRowSpan(this.tlp_ExtraInfo, 2);
            this.tlp_ExtraInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_ExtraInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_ExtraInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_ExtraInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_ExtraInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_ExtraInfo.Size = new System.Drawing.Size(459, 68);
            this.tlp_ExtraInfo.TabIndex = 19;
            // 
            // label_TotalConnectedOrders
            // 
            this.label_TotalConnectedOrders.AutoSize = true;
            this.tlp_ExtraInfo.SetColumnSpan(this.label_TotalConnectedOrders, 2);
            this.label_TotalConnectedOrders.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_TotalConnectedOrders.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_TotalConnectedOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.label_TotalConnectedOrders.Location = new System.Drawing.Point(199, 33);
            this.label_TotalConnectedOrders.Name = "label_TotalConnectedOrders";
            this.label_TotalConnectedOrders.Size = new System.Drawing.Size(251, 15);
            this.label_TotalConnectedOrders.TabIndex = 16;
            this.label_TotalConnectedOrders.Text = "Antal Ordrar kopplade till mallen:";
            this.label_TotalConnectedOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CreatedDate
            // 
            this.lbl_CreatedDate.AutoSize = true;
            this.lbl_CreatedDate.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CreatedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_CreatedDate.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_CreatedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_CreatedDate.Location = new System.Drawing.Point(152, 17);
            this.lbl_CreatedDate.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_CreatedDate.Name = "lbl_CreatedDate";
            this.lbl_CreatedDate.Size = new System.Drawing.Size(301, 15);
            this.lbl_CreatedDate.TabIndex = 18;
            this.lbl_CreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_CreatedBy
            // 
            this.lbl_CreatedBy.AutoSize = true;
            this.lbl_CreatedBy.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CreatedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_CreatedBy.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_CreatedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_CreatedBy.Location = new System.Drawing.Point(152, 1);
            this.lbl_CreatedBy.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_CreatedBy.Name = "lbl_CreatedBy";
            this.lbl_CreatedBy.Size = new System.Drawing.Size(301, 15);
            this.lbl_CreatedBy.TabIndex = 17;
            this.lbl_CreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_CreatedDate
            // 
            this.label_CreatedDate.AutoSize = true;
            this.label_CreatedDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_CreatedDate.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_CreatedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.label_CreatedDate.Location = new System.Drawing.Point(32, 17);
            this.label_CreatedDate.Name = "label_CreatedDate";
            this.label_CreatedDate.Size = new System.Drawing.Size(116, 15);
            this.label_CreatedDate.TabIndex = 16;
            this.label_CreatedDate.Text = "Mallen skapad:";
            // 
            // label_CreatedBy
            // 
            this.label_CreatedBy.AutoSize = true;
            this.label_CreatedBy.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_CreatedBy.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_CreatedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.label_CreatedBy.Location = new System.Drawing.Point(10, 1);
            this.label_CreatedBy.Name = "label_CreatedBy";
            this.label_CreatedBy.Size = new System.Drawing.Size(138, 15);
            this.label_CreatedBy.TabIndex = 16;
            this.label_CreatedBy.Text = "Mallen skapad av:";
            // 
            // label_TotalConnectedProcesscards
            // 
            this.label_TotalConnectedProcesscards.AutoSize = true;
            this.tlp_ExtraInfo.SetColumnSpan(this.label_TotalConnectedProcesscards, 2);
            this.label_TotalConnectedProcesscards.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_TotalConnectedProcesscards.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_TotalConnectedProcesscards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.label_TotalConnectedProcesscards.Location = new System.Drawing.Point(159, 49);
            this.label_TotalConnectedProcesscards.Name = "label_TotalConnectedProcesscards";
            this.label_TotalConnectedProcesscards.Size = new System.Drawing.Size(291, 18);
            this.label_TotalConnectedProcesscards.TabIndex = 16;
            this.label_TotalConnectedProcesscards.Text = "Antal Processkort kopplade till mallen:";
            this.label_TotalConnectedProcesscards.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 700F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.gbx_CategoryLineClearance, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbx_Tasks, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flp_Main, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.gbox_LineClearanceTemplate, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv_Tasks, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.web_PDF_Viewer, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.flp_ObjectManagement, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 109);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2055, 952);
            this.tableLayoutPanel1.TabIndex = 879;
            // 
            // web_PDF_Viewer
            // 
            this.web_PDF_Viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web_PDF_Viewer.Location = new System.Drawing.Point(1323, 199);
            this.web_PDF_Viewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_PDF_Viewer.Name = "web_PDF_Viewer";
            this.web_PDF_Viewer.Size = new System.Drawing.Size(729, 750);
            this.web_PDF_Viewer.TabIndex = 22;
            // 
            // flp_ObjectManagement
            // 
            this.flp_ObjectManagement.Controls.Add(this.label_ActiveCategory);
            this.flp_ObjectManagement.Controls.Add(this.label_Buttons_Category);
            this.flp_ObjectManagement.Controls.Add(this.pb_RenameCategory);
            this.flp_ObjectManagement.Controls.Add(this.btn_MoveCategoryUp);
            this.flp_ObjectManagement.Controls.Add(this.btn_MoveCategoryDown);
            this.flp_ObjectManagement.Controls.Add(this.btn_DeleteCategory);
            this.flp_ObjectManagement.Controls.Add(this.label_Buttons_Task);
            this.flp_ObjectManagement.Controls.Add(this.btn_MoveTaskUp);
            this.flp_ObjectManagement.Controls.Add(this.btn_MoveTaskDown);
            this.flp_ObjectManagement.Controls.Add(this.btn_DeleteTask);
            this.flp_ObjectManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_ObjectManagement.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_ObjectManagement.Location = new System.Drawing.Point(503, 199);
            this.flp_ObjectManagement.Name = "flp_ObjectManagement";
            this.flp_ObjectManagement.Size = new System.Drawing.Size(114, 750);
            this.flp_ObjectManagement.TabIndex = 23;
            // 
            // btn_ConnectPartNr_NewTemplate
            // 
            this.btn_ConnectPartNr_NewTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_ConnectPartNr_NewTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ConnectPartNr_NewTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ConnectPartNr_NewTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ConnectPartNr_NewTemplate.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_ConnectPartNr_NewTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_ConnectPartNr_NewTemplate.Location = new System.Drawing.Point(250, 5);
            this.btn_ConnectPartNr_NewTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ConnectPartNr_NewTemplate.Name = "btn_ConnectPartNr_NewTemplate";
            this.btn_ConnectPartNr_NewTemplate.Size = new System.Drawing.Size(250, 34);
            this.btn_ConnectPartNr_NewTemplate.TabIndex = 20;
            this.btn_ConnectPartNr_NewTemplate.Text = "Koppla Aktiv Mall till Processkort";
            this.btn_ConnectPartNr_NewTemplate.UseVisualStyleBackColor = false;
            this.btn_ConnectPartNr_NewTemplate.Visible = false;
            // 
            // Templates_LineClearance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(2055, 1061);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tlp_Top);
            this.Name = "Templates_LineClearance";
            this.Text = "Hantera Line-Clearance Mallar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Manage_Templates_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_RenameCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_MoveTaskUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_MoveTaskDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_MoveCategoryUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_MoveCategoryDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DeleteTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DeleteCategory)).EndInit();
            this.gbx_CategoryLineClearance.ResumeLayout(false);
            this.gbx_CategoryLineClearance.PerformLayout();
            this.gbx_Tasks.ResumeLayout(false);
            this.gbx_Tasks.PerformLayout();
            this.gbox_LineClearanceTemplate.ResumeLayout(false);
            this.gbox_LineClearanceTemplate.PerformLayout();
            this.tlp_Top.ResumeLayout(false);
            this.tlp_ExtraInfo.ResumeLayout(false);
            this.tlp_ExtraInfo.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flp_ObjectManagement.ResumeLayout(false);
            this.flp_ObjectManagement.PerformLayout();
            this.ResumeLayout(false);

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
        private Label label1;
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