using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Templates
{
    partial class Templates_Protocol
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Templates_Protocol));
            flp_Main = new FlowLayoutPanel();
            dgv_CodeText = new DataGridView();
            tb_ModuleName = new TextBox();
            cb_TemplateName = new ComboBox();
            btn_SaveNewTemplate = new Button();
            btn_UpdateTemplate = new Button();
            label_ModuleName = new Label();
            label_TemplateName = new Label();
            label_Revision = new Label();
            chb_IsUsingPreFab = new CheckBox();
            btn_NewModule = new Button();
            tb_FilterCodeText = new TextBox();
            label_FilterCodeText = new Label();
            btn_ConnectPartNr_NewTemplate = new Button();
            btn_PreviewTemplate = new Button();
            cb_LineClearance_Revision = new ComboBox();
            label_LineClearanceTemplate = new Label();
            cb_TemplateRevision = new ComboBox();
            btn_DeleteTemplate = new Button();
            cb_MainInfo_Template = new ComboBox();
            label_MainInfoTemplate = new Label();
            btn_ConnectPartNr_NewRevision = new Button();
            pb_RenameModule = new PictureBox();
            btn_CodeTextUp = new PictureBox();
            btn_CodeTextDown = new PictureBox();
            btn_ModuleUp = new PictureBox();
            btn_ModuleDown = new PictureBox();
            btn_DeleteCodeText = new PictureBox();
            btn_DeleteModule = new PictureBox();
            label_Buttons_CodeText = new Label();
            label_Buttons_Module = new Label();
            label_TotalConnectedProcesscards = new Label();
            btn_NewRevision = new Button();
            toolTip = new ToolTip(components);
            label_WorkoperationName = new Label();
            label_CreatedBy = new Label();
            label_CreatedDate = new Label();
            tlp_ExtraInfo = new TableLayoutPanel();
            label_TotalConnectedOrders = new Label();
            lbl_CreatedDate = new Label();
            lbl_CreatedBy = new Label();
            chb_IsProductionLineNeeded = new CheckBox();
            tlp_Bottom = new TableLayoutPanel();
            flp_ObjectManagement = new FlowLayoutPanel();
            gbx_Module = new GroupBox();
            gbx_Protocol_Template = new GroupBox();
            pb_Manual = new PictureBox();
            tb_Workoperation = new TextBox();
            gbx_CodeText = new GroupBox();
            tb_NewUnit = new TextBox();
            tb_NewCodeText = new TextBox();
            btn_AddCodeText = new Button();
            tlp_Top = new TableLayoutPanel();
            ((ISupportInitialize)dgv_CodeText).BeginInit();
            ((ISupportInitialize)pb_RenameModule).BeginInit();
            ((ISupportInitialize)btn_CodeTextUp).BeginInit();
            ((ISupportInitialize)btn_CodeTextDown).BeginInit();
            ((ISupportInitialize)btn_ModuleUp).BeginInit();
            ((ISupportInitialize)btn_ModuleDown).BeginInit();
            ((ISupportInitialize)btn_DeleteCodeText).BeginInit();
            ((ISupportInitialize)btn_DeleteModule).BeginInit();
            tlp_ExtraInfo.SuspendLayout();
            tlp_Bottom.SuspendLayout();
            flp_ObjectManagement.SuspendLayout();
            gbx_Module.SuspendLayout();
            gbx_Protocol_Template.SuspendLayout();
            ((ISupportInitialize)pb_Manual).BeginInit();
            gbx_CodeText.SuspendLayout();
            tlp_Top.SuspendLayout();
            SuspendLayout();
            // 
            // flp_Main
            // 
            flp_Main.AutoScroll = true;
            flp_Main.BackColor = Color.FromArgb(81, 85, 92);
            tlp_Bottom.SetColumnSpan(flp_Main, 5);
            flp_Main.Dock = DockStyle.Fill;
            flp_Main.FlowDirection = FlowDirection.TopDown;
            flp_Main.Location = new Point(385, 287);
            flp_Main.Margin = new Padding(4, 3, 4, 3);
            flp_Main.MaximumSize = new Size(1540, 2308);
            flp_Main.Name = "flp_Main";
            tlp_Bottom.SetRowSpan(flp_Main, 2);
            flp_Main.Size = new Size(1155, 802);
            flp_Main.TabIndex = 0;
            flp_Main.WrapContents = false;
            // 
            // dgv_CodeText
            // 
            dgv_CodeText.AllowUserToAddRows = false;
            dgv_CodeText.AllowUserToDeleteRows = false;
            dgv_CodeText.AllowUserToResizeColumns = false;
            dgv_CodeText.AllowUserToResizeRows = false;
            dgv_CodeText.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_CodeText.BackgroundColor = Color.FromArgb(81, 85, 92);
            dgv_CodeText.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_CodeText.Dock = DockStyle.Fill;
            dgv_CodeText.Location = new Point(6, 354);
            dgv_CodeText.Margin = new Padding(0);
            dgv_CodeText.MultiSelect = false;
            dgv_CodeText.Name = "dgv_CodeText";
            dgv_CodeText.ReadOnly = true;
            dgv_CodeText.RowHeadersVisible = false;
            dgv_CodeText.Size = new Size(298, 738);
            dgv_CodeText.TabIndex = 2;
            dgv_CodeText.Visible = false;
            dgv_CodeText.CellMouseDown += CodeText_CellMouseDown;
            dgv_CodeText.ColumnHeaderMouseClick += CodeText_ColumnHeaderMouseClick;
            dgv_CodeText.KeyPress += CodeText_KeyPress;
            // 
            // tb_ModuleName
            // 
            tb_ModuleName.Font = new Font("Lucida Sans", 8.25F);
            tb_ModuleName.Location = new Point(5, 104);
            tb_ModuleName.Margin = new Padding(1, 0, 0, 0);
            tb_ModuleName.Multiline = true;
            tb_ModuleName.Name = "tb_ModuleName";
            tb_ModuleName.Size = new Size(289, 28);
            tb_ModuleName.TabIndex = 3;
            tb_ModuleName.KeyPress += ModuleName_KeyPress;
            // 
            // cb_TemplateName
            // 
            cb_TemplateName.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_TemplateName.FlatStyle = FlatStyle.System;
            cb_TemplateName.Font = new Font("Lucida Sans", 11.25F);
            cb_TemplateName.FormattingEnabled = true;
            cb_TemplateName.Location = new Point(4, 222);
            cb_TemplateName.Margin = new Padding(0);
            cb_TemplateName.Name = "cb_TemplateName";
            cb_TemplateName.Size = new Size(402, 25);
            cb_TemplateName.TabIndex = 4;
            cb_TemplateName.SelectedIndexChanged += Template_Name_SelectedIndexChanged;
            cb_TemplateName.TextChanged += TemplateName_TextChanged;
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
            btn_SaveNewTemplate.Size = new Size(286, 36);
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
            btn_UpdateTemplate.Location = new Point(6, 42);
            btn_UpdateTemplate.Margin = new Padding(6, 0, 0, 0);
            btn_UpdateTemplate.Name = "btn_UpdateTemplate";
            btn_UpdateTemplate.Size = new Size(286, 36);
            btn_UpdateTemplate.TabIndex = 1;
            btn_UpdateTemplate.Text = "Uppdatera Mall";
            btn_UpdateTemplate.UseVisualStyleBackColor = false;
            btn_UpdateTemplate.Click += Update_Template_Click;
            // 
            // label_ModuleName
            // 
            label_ModuleName.BackColor = Color.FromArgb(239, 228, 177);
            label_ModuleName.Font = new Font("Lucida Sans", 10.25F);
            label_ModuleName.ForeColor = Color.FromArgb(57, 108, 121);
            label_ModuleName.Location = new Point(5, 63);
            label_ModuleName.Margin = new Padding(1, 0, 0, 1);
            label_ModuleName.Name = "label_ModuleName";
            label_ModuleName.Size = new Size(289, 39);
            label_ModuleName.TabIndex = 8;
            label_ModuleName.Text = "Modul-namn, den vertikala texten till vänster om modulen.\r\n";
            // 
            // label_TemplateName
            // 
            label_TemplateName.BackColor = Color.FromArgb(239, 228, 177);
            label_TemplateName.Font = new Font("Lucida Sans", 10.25F);
            label_TemplateName.ForeColor = Color.FromArgb(57, 108, 121);
            label_TemplateName.Location = new Point(5, 192);
            label_TemplateName.Margin = new Padding(0);
            label_TemplateName.Name = "label_TemplateName";
            label_TemplateName.Size = new Size(400, 28);
            label_TemplateName.TabIndex = 8;
            label_TemplateName.Text = "Mallens namn:";
            // 
            // label_Revision
            // 
            label_Revision.BackColor = Color.FromArgb(239, 228, 177);
            label_Revision.Font = new Font("Lucida Sans", 10.25F);
            label_Revision.ForeColor = Color.FromArgb(57, 108, 121);
            label_Revision.Location = new Point(406, 192);
            label_Revision.Margin = new Padding(0);
            label_Revision.Name = "label_Revision";
            label_Revision.Size = new Size(80, 28);
            label_Revision.TabIndex = 9;
            label_Revision.Text = "Revision";
            // 
            // chb_IsUsingPreFab
            // 
            chb_IsUsingPreFab.AutoSize = true;
            chb_IsUsingPreFab.Font = new Font("Lucida Sans", 11.25F);
            chb_IsUsingPreFab.ForeColor = Color.FromArgb(187, 215, 228);
            chb_IsUsingPreFab.Location = new Point(7, 27);
            chb_IsUsingPreFab.Margin = new Padding(4, 3, 4, 3);
            chb_IsUsingPreFab.Name = "chb_IsUsingPreFab";
            chb_IsUsingPreFab.Size = new Size(188, 21);
            chb_IsUsingPreFab.TabIndex = 10;
            chb_IsUsingPreFab.Text = "Används Halvfabrikat?";
            chb_IsUsingPreFab.UseVisualStyleBackColor = true;
            // 
            // btn_NewModule
            // 
            btn_NewModule.BackColor = Color.FromArgb(185, 188, 189);
            btn_NewModule.Cursor = Cursors.Hand;
            btn_NewModule.FlatStyle = FlatStyle.Flat;
            btn_NewModule.Font = new Font("Lucida Sans", 10.25F);
            btn_NewModule.ForeColor = Color.FromArgb(63, 116, 140);
            btn_NewModule.Location = new Point(4, 29);
            btn_NewModule.Margin = new Padding(0);
            btn_NewModule.Name = "btn_NewModule";
            btn_NewModule.Size = new Size(290, 35);
            btn_NewModule.TabIndex = 11;
            btn_NewModule.Text = "Lägg till Modul";
            btn_NewModule.UseVisualStyleBackColor = false;
            btn_NewModule.Click += NewModule_Click;
            // 
            // tb_FilterCodeText
            // 
            tb_FilterCodeText.Font = new Font("Lucida Sans", 8.25F);
            tb_FilterCodeText.Location = new Point(5, 57);
            tb_FilterCodeText.Margin = new Padding(1, 0, 0, 0);
            tb_FilterCodeText.Multiline = true;
            tb_FilterCodeText.Name = "tb_FilterCodeText";
            tb_FilterCodeText.Size = new Size(289, 28);
            tb_FilterCodeText.TabIndex = 3;
            tb_FilterCodeText.TextChanged += FilterCodeText_TextChanged;
            tb_FilterCodeText.Enter += FilterCodeText_Enter;
            // 
            // label_FilterCodeText
            // 
            label_FilterCodeText.BackColor = Color.FromArgb(239, 228, 177);
            label_FilterCodeText.Font = new Font("Lucida Sans", 10.25F);
            label_FilterCodeText.ForeColor = Color.FromArgb(57, 108, 121);
            label_FilterCodeText.Location = new Point(5, 28);
            label_FilterCodeText.Margin = new Padding(0, 0, 0, 1);
            label_FilterCodeText.Name = "label_FilterCodeText";
            label_FilterCodeText.Size = new Size(289, 28);
            label_FilterCodeText.TabIndex = 8;
            label_FilterCodeText.Text = "Filtrera texten";
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
            btn_ConnectPartNr_NewTemplate.Size = new Size(292, 36);
            btn_ConnectPartNr_NewTemplate.TabIndex = 1;
            btn_ConnectPartNr_NewTemplate.Text = "Koppla Aktiv Mall till Processkort";
            btn_ConnectPartNr_NewTemplate.UseVisualStyleBackColor = false;
            btn_ConnectPartNr_NewTemplate.Click += ConnectTemplate_Click;
            // 
            // btn_PreviewTemplate
            // 
            btn_PreviewTemplate.BackColor = Color.FromArgb(185, 188, 189);
            btn_PreviewTemplate.Cursor = Cursors.Hand;
            btn_PreviewTemplate.Dock = DockStyle.Fill;
            btn_PreviewTemplate.FlatStyle = FlatStyle.Flat;
            btn_PreviewTemplate.Font = new Font("Lucida Sans", 10.25F);
            btn_PreviewTemplate.ForeColor = Color.FromArgb(63, 116, 140);
            btn_PreviewTemplate.Location = new Point(292, 78);
            btn_PreviewTemplate.Margin = new Padding(0);
            btn_PreviewTemplate.Name = "btn_PreviewTemplate";
            btn_PreviewTemplate.Size = new Size(292, 37);
            btn_PreviewTemplate.TabIndex = 1;
            btn_PreviewTemplate.Text = "Förhandsgranska Mall";
            btn_PreviewTemplate.UseVisualStyleBackColor = false;
            btn_PreviewTemplate.Click += PreviewTemplate_Click;
            // 
            // cb_LineClearance_Revision
            // 
            cb_LineClearance_Revision.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_LineClearance_Revision.Font = new Font("Lucida Sans", 11.25F);
            cb_LineClearance_Revision.FormattingEnabled = true;
            cb_LineClearance_Revision.Location = new Point(26, 82);
            cb_LineClearance_Revision.Margin = new Padding(0);
            cb_LineClearance_Revision.Name = "cb_LineClearance_Revision";
            cb_LineClearance_Revision.Size = new Size(56, 25);
            cb_LineClearance_Revision.TabIndex = 12;
            cb_LineClearance_Revision.SelectedIndexChanged += LineClearance_Revision_SelectedIndexChanged;
            // 
            // label_LineClearanceTemplate
            // 
            label_LineClearanceTemplate.AutoSize = true;
            label_LineClearanceTemplate.Font = new Font("Lucida Sans", 11.25F);
            label_LineClearanceTemplate.ForeColor = Color.FromArgb(187, 215, 228);
            label_LineClearanceTemplate.Location = new Point(94, 87);
            label_LineClearanceTemplate.Margin = new Padding(23, 0, 4, 0);
            label_LineClearanceTemplate.Name = "label_LineClearanceTemplate";
            label_LineClearanceTemplate.Size = new Size(715, 17);
            label_LineClearanceTemplate.TabIndex = 13;
            label_LineClearanceTemplate.Text = "Revision för LineClearance. Gå till Hantering av Mallar för LineClearance för att se hur den ser ut.\r\n";
            // 
            // cb_TemplateRevision
            // 
            cb_TemplateRevision.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_TemplateRevision.FlatStyle = FlatStyle.System;
            cb_TemplateRevision.Font = new Font("Lucida Sans", 11.25F);
            cb_TemplateRevision.FormattingEnabled = true;
            cb_TemplateRevision.Location = new Point(405, 222);
            cb_TemplateRevision.Margin = new Padding(0);
            cb_TemplateRevision.Name = "cb_TemplateRevision";
            cb_TemplateRevision.Size = new Size(82, 25);
            cb_TemplateRevision.TabIndex = 14;
            cb_TemplateRevision.SelectedIndexChanged += Template_RevisionNr_SelectedIndexChanged;
            cb_TemplateRevision.KeyPress += Revision_KeyPress;
            // 
            // btn_DeleteTemplate
            // 
            btn_DeleteTemplate.BackColor = Color.FromArgb(185, 188, 189);
            btn_DeleteTemplate.Cursor = Cursors.Hand;
            btn_DeleteTemplate.Dock = DockStyle.Fill;
            btn_DeleteTemplate.FlatStyle = FlatStyle.Flat;
            btn_DeleteTemplate.Font = new Font("Lucida Sans", 10.25F);
            btn_DeleteTemplate.ForeColor = Color.FromArgb(63, 116, 140);
            btn_DeleteTemplate.Location = new Point(6, 78);
            btn_DeleteTemplate.Margin = new Padding(6, 0, 0, 0);
            btn_DeleteTemplate.Name = "btn_DeleteTemplate";
            btn_DeleteTemplate.Size = new Size(286, 37);
            btn_DeleteTemplate.TabIndex = 1;
            btn_DeleteTemplate.Text = "Radera Mall";
            btn_DeleteTemplate.UseVisualStyleBackColor = false;
            btn_DeleteTemplate.Click += Delete_Template_Click;
            // 
            // cb_MainInfo_Template
            // 
            cb_MainInfo_Template.Font = new Font("Lucida Sans", 11.25F);
            cb_MainInfo_Template.FormattingEnabled = true;
            cb_MainInfo_Template.Items.AddRange(new object[] { "A", "B", "C" });
            cb_MainInfo_Template.Location = new Point(26, 118);
            cb_MainInfo_Template.Margin = new Padding(0);
            cb_MainInfo_Template.Name = "cb_MainInfo_Template";
            cb_MainInfo_Template.Size = new Size(56, 25);
            cb_MainInfo_Template.TabIndex = 12;
            // 
            // label_MainInfoTemplate
            // 
            label_MainInfoTemplate.AutoSize = true;
            label_MainInfoTemplate.Font = new Font("Lucida Sans", 11.25F);
            label_MainInfoTemplate.ForeColor = Color.FromArgb(187, 215, 228);
            label_MainInfoTemplate.Location = new Point(94, 122);
            label_MainInfoTemplate.Margin = new Padding(23, 0, 4, 0);
            label_MainInfoTemplate.Name = "label_MainInfoTemplate";
            label_MainInfoTemplate.Size = new Size(603, 17);
            label_MainInfoTemplate.TabIndex = 13;
            label_MainInfoTemplate.Text = "Mall för Main Info (Välj mall och Förhandsgranska mallen för att se hur den ser ut)\r\n";
            // 
            // btn_ConnectPartNr_NewRevision
            // 
            btn_ConnectPartNr_NewRevision.BackColor = Color.FromArgb(185, 188, 189);
            btn_ConnectPartNr_NewRevision.Cursor = Cursors.Hand;
            btn_ConnectPartNr_NewRevision.Dock = DockStyle.Fill;
            btn_ConnectPartNr_NewRevision.FlatStyle = FlatStyle.Flat;
            btn_ConnectPartNr_NewRevision.Font = new Font("Lucida Sans", 10.25F);
            btn_ConnectPartNr_NewRevision.ForeColor = Color.FromArgb(63, 116, 140);
            btn_ConnectPartNr_NewRevision.Location = new Point(292, 42);
            btn_ConnectPartNr_NewRevision.Margin = new Padding(0);
            btn_ConnectPartNr_NewRevision.Name = "btn_ConnectPartNr_NewRevision";
            btn_ConnectPartNr_NewRevision.Size = new Size(292, 36);
            btn_ConnectPartNr_NewRevision.TabIndex = 1;
            btn_ConnectPartNr_NewRevision.Text = "Koppla Artikelnr till ny Revision";
            btn_ConnectPartNr_NewRevision.UseVisualStyleBackColor = false;
            btn_ConnectPartNr_NewRevision.Visible = false;
            btn_ConnectPartNr_NewRevision.Click += ConnectPartNr_NewRevision_Click;
            // 
            // pb_RenameModule
            // 
            pb_RenameModule.Anchor = AnchorStyles.None;
            pb_RenameModule.BackgroundImage = (Image)resources.GetObject("pb_RenameModule.BackgroundImage");
            pb_RenameModule.BackgroundImageLayout = ImageLayout.Stretch;
            pb_RenameModule.Cursor = Cursors.Hand;
            pb_RenameModule.Location = new Point(6, 29);
            pb_RenameModule.Margin = new Padding(0, 0, 0, 6);
            pb_RenameModule.Name = "pb_RenameModule";
            pb_RenameModule.Size = new Size(49, 47);
            pb_RenameModule.TabIndex = 5;
            pb_RenameModule.TabStop = false;
            toolTip.SetToolTip(pb_RenameModule, "Fyll i det nya namnet till vänster ");
            pb_RenameModule.Click += RenameModule_Click;
            // 
            // btn_CodeTextUp
            // 
            btn_CodeTextUp.Anchor = AnchorStyles.None;
            btn_CodeTextUp.BackgroundImage = (Image)resources.GetObject("btn_CodeTextUp.BackgroundImage");
            btn_CodeTextUp.BackgroundImageLayout = ImageLayout.Stretch;
            btn_CodeTextUp.Cursor = Cursors.Hand;
            btn_CodeTextUp.Location = new Point(16, 268);
            btn_CodeTextUp.Margin = new Padding(4, 3, 4, 6);
            btn_CodeTextUp.Name = "btn_CodeTextUp";
            btn_CodeTextUp.Size = new Size(30, 33);
            btn_CodeTextUp.TabIndex = 3;
            btn_CodeTextUp.TabStop = false;
            btn_CodeTextUp.Click += CodeTextUp_Click;
            // 
            // btn_CodeTextDown
            // 
            btn_CodeTextDown.Anchor = AnchorStyles.None;
            btn_CodeTextDown.BackgroundImage = (Image)resources.GetObject("btn_CodeTextDown.BackgroundImage");
            btn_CodeTextDown.BackgroundImageLayout = ImageLayout.Stretch;
            btn_CodeTextDown.Cursor = Cursors.Hand;
            btn_CodeTextDown.Location = new Point(16, 310);
            btn_CodeTextDown.Margin = new Padding(4, 3, 4, 6);
            btn_CodeTextDown.Name = "btn_CodeTextDown";
            btn_CodeTextDown.Size = new Size(30, 33);
            btn_CodeTextDown.TabIndex = 4;
            btn_CodeTextDown.TabStop = false;
            btn_CodeTextDown.Click += CodeTextDown_Click;
            // 
            // btn_ModuleUp
            // 
            btn_ModuleUp.Anchor = AnchorStyles.None;
            btn_ModuleUp.BackgroundImage = (Image)resources.GetObject("btn_ModuleUp.BackgroundImage");
            btn_ModuleUp.BackgroundImageLayout = ImageLayout.Stretch;
            btn_ModuleUp.Cursor = Cursors.Hand;
            btn_ModuleUp.Location = new Point(16, 82);
            btn_ModuleUp.Margin = new Padding(0, 0, 0, 6);
            btn_ModuleUp.Name = "btn_ModuleUp";
            btn_ModuleUp.Size = new Size(30, 33);
            btn_ModuleUp.TabIndex = 2;
            btn_ModuleUp.TabStop = false;
            btn_ModuleUp.Click += ModuleUp_Click;
            // 
            // btn_ModuleDown
            // 
            btn_ModuleDown.Anchor = AnchorStyles.None;
            btn_ModuleDown.BackgroundImage = (Image)resources.GetObject("btn_ModuleDown.BackgroundImage");
            btn_ModuleDown.BackgroundImageLayout = ImageLayout.Stretch;
            btn_ModuleDown.Cursor = Cursors.Hand;
            btn_ModuleDown.Location = new Point(16, 124);
            btn_ModuleDown.Margin = new Padding(4, 3, 4, 6);
            btn_ModuleDown.Name = "btn_ModuleDown";
            btn_ModuleDown.Size = new Size(30, 33);
            btn_ModuleDown.TabIndex = 2;
            btn_ModuleDown.TabStop = false;
            btn_ModuleDown.Click += ModuleDown_Click;
            // 
            // btn_DeleteCodeText
            // 
            btn_DeleteCodeText.Anchor = AnchorStyles.None;
            btn_DeleteCodeText.BackgroundImage = (Image)resources.GetObject("btn_DeleteCodeText.BackgroundImage");
            btn_DeleteCodeText.BackgroundImageLayout = ImageLayout.Stretch;
            btn_DeleteCodeText.Cursor = Cursors.Hand;
            btn_DeleteCodeText.Location = new Point(7, 352);
            btn_DeleteCodeText.Margin = new Padding(4, 3, 4, 6);
            btn_DeleteCodeText.Name = "btn_DeleteCodeText";
            btn_DeleteCodeText.Size = new Size(48, 47);
            btn_DeleteCodeText.TabIndex = 1;
            btn_DeleteCodeText.TabStop = false;
            toolTip.SetToolTip(btn_DeleteCodeText, "Radera markerad rad");
            btn_DeleteCodeText.Click += DeleteCodeText_Click;
            // 
            // btn_DeleteModule
            // 
            btn_DeleteModule.Anchor = AnchorStyles.None;
            btn_DeleteModule.BackgroundImage = (Image)resources.GetObject("btn_DeleteModule.BackgroundImage");
            btn_DeleteModule.BackgroundImageLayout = ImageLayout.Stretch;
            btn_DeleteModule.Cursor = Cursors.Hand;
            btn_DeleteModule.Location = new Point(7, 166);
            btn_DeleteModule.Margin = new Padding(4, 3, 4, 29);
            btn_DeleteModule.Name = "btn_DeleteModule";
            btn_DeleteModule.Size = new Size(48, 47);
            btn_DeleteModule.TabIndex = 1;
            btn_DeleteModule.TabStop = false;
            toolTip.SetToolTip(btn_DeleteModule, "Radera markerad modul");
            btn_DeleteModule.Click += DeleteModule_Click;
            // 
            // label_Buttons_CodeText
            // 
            label_Buttons_CodeText.Anchor = AnchorStyles.None;
            label_Buttons_CodeText.AutoSize = true;
            label_Buttons_CodeText.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold);
            label_Buttons_CodeText.ForeColor = Color.FromArgb(255, 235, 156);
            label_Buttons_CodeText.Location = new Point(9, 242);
            label_Buttons_CodeText.Margin = new Padding(4, 0, 4, 6);
            label_Buttons_CodeText.Name = "label_Buttons_CodeText";
            label_Buttons_CodeText.Size = new Size(43, 17);
            label_Buttons_CodeText.TabIndex = 0;
            label_Buttons_CodeText.Text = "Text";
            // 
            // label_Buttons_Module
            // 
            label_Buttons_Module.Anchor = AnchorStyles.None;
            label_Buttons_Module.AutoSize = true;
            label_Buttons_Module.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold);
            label_Buttons_Module.ForeColor = Color.FromArgb(255, 235, 156);
            label_Buttons_Module.Location = new Point(4, 0);
            label_Buttons_Module.Margin = new Padding(4, 0, 4, 12);
            label_Buttons_Module.Name = "label_Buttons_Module";
            label_Buttons_Module.Size = new Size(54, 17);
            label_Buttons_Module.TabIndex = 0;
            label_Buttons_Module.Text = "Modul";
            // 
            // label_TotalConnectedProcesscards
            // 
            label_TotalConnectedProcesscards.AutoSize = true;
            tlp_ExtraInfo.SetColumnSpan(label_TotalConnectedProcesscards, 2);
            label_TotalConnectedProcesscards.Dock = DockStyle.Right;
            label_TotalConnectedProcesscards.Font = new Font("Lucida Sans", 11.25F);
            label_TotalConnectedProcesscards.ForeColor = Color.FromArgb(187, 215, 228);
            label_TotalConnectedProcesscards.Location = new Point(234, 82);
            label_TotalConnectedProcesscards.Margin = new Padding(4, 0, 4, 0);
            label_TotalConnectedProcesscards.Name = "label_TotalConnectedProcesscards";
            label_TotalConnectedProcesscards.Size = new Size(291, 26);
            label_TotalConnectedProcesscards.TabIndex = 16;
            label_TotalConnectedProcesscards.Text = "Antal Processkort kopplade till mallen:";
            label_TotalConnectedProcesscards.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn_NewRevision
            // 
            btn_NewRevision.BackColor = Color.FromArgb(185, 188, 189);
            btn_NewRevision.Cursor = Cursors.Hand;
            btn_NewRevision.FlatStyle = FlatStyle.Flat;
            btn_NewRevision.Font = new Font("Lucida Sans", 10.25F);
            btn_NewRevision.ForeColor = Color.FromArgb(63, 116, 140);
            btn_NewRevision.Location = new Point(489, 222);
            btn_NewRevision.Margin = new Padding(1, 0, 0, 0);
            btn_NewRevision.Name = "btn_NewRevision";
            btn_NewRevision.Size = new Size(121, 28);
            btn_NewRevision.TabIndex = 1;
            btn_NewRevision.Text = "Ny Revision";
            toolTip.SetToolTip(btn_NewRevision, "Vänsterklicka för att stega upp en revision, högerklicka för att stega ner en revision.");
            btn_NewRevision.UseVisualStyleBackColor = false;
            btn_NewRevision.MouseDown += NewRevision_MouseDown;
            // 
            // label_WorkoperationName
            // 
            label_WorkoperationName.BackColor = Color.FromArgb(239, 228, 177);
            label_WorkoperationName.Font = new Font("Lucida Sans", 10.25F);
            label_WorkoperationName.ForeColor = Color.FromArgb(57, 108, 121);
            label_WorkoperationName.Location = new Point(612, 192);
            label_WorkoperationName.Margin = new Padding(1, 0, 0, 1);
            label_WorkoperationName.Name = "label_WorkoperationName";
            label_WorkoperationName.Size = new Size(574, 28);
            label_WorkoperationName.TabIndex = 8;
            label_WorkoperationName.Text = "Arbetsoperation:";
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
            label_CreatedBy.Size = new Size(138, 26);
            label_CreatedBy.TabIndex = 16;
            label_CreatedBy.Text = "Mallen skapad av:";
            // 
            // label_CreatedDate
            // 
            label_CreatedDate.AutoSize = true;
            label_CreatedDate.Dock = DockStyle.Right;
            label_CreatedDate.Font = new Font("Lucida Sans", 11.25F);
            label_CreatedDate.ForeColor = Color.FromArgb(187, 215, 228);
            label_CreatedDate.Location = new Point(56, 28);
            label_CreatedDate.Margin = new Padding(4, 0, 4, 0);
            label_CreatedDate.Name = "label_CreatedDate";
            label_CreatedDate.Size = new Size(116, 26);
            label_CreatedDate.TabIndex = 16;
            label_CreatedDate.Text = "Mallen skapad:";
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
            tlp_ExtraInfo.Location = new Point(1562, 6);
            tlp_ExtraInfo.Margin = new Padding(0);
            tlp_ExtraInfo.Name = "tlp_ExtraInfo";
            tlp_ExtraInfo.Padding = new Padding(0, 0, 6, 0);
            tlp_ExtraInfo.RowCount = 4;
            tlp_Top.SetRowSpan(tlp_ExtraInfo, 3);
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_ExtraInfo.Size = new Size(536, 109);
            tlp_ExtraInfo.TabIndex = 18;
            // 
            // label_TotalConnectedOrders
            // 
            label_TotalConnectedOrders.AutoSize = true;
            tlp_ExtraInfo.SetColumnSpan(label_TotalConnectedOrders, 2);
            label_TotalConnectedOrders.Dock = DockStyle.Right;
            label_TotalConnectedOrders.Font = new Font("Lucida Sans", 11.25F);
            label_TotalConnectedOrders.ForeColor = Color.FromArgb(187, 215, 228);
            label_TotalConnectedOrders.Location = new Point(274, 55);
            label_TotalConnectedOrders.Margin = new Padding(4, 0, 4, 0);
            label_TotalConnectedOrders.Name = "label_TotalConnectedOrders";
            label_TotalConnectedOrders.Size = new Size(251, 26);
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
            lbl_CreatedDate.Location = new Point(177, 28);
            lbl_CreatedDate.Margin = new Padding(0);
            lbl_CreatedDate.Name = "lbl_CreatedDate";
            lbl_CreatedDate.Size = new Size(352, 26);
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
            lbl_CreatedBy.Size = new Size(352, 26);
            lbl_CreatedBy.TabIndex = 17;
            lbl_CreatedBy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chb_IsProductionLineNeeded
            // 
            chb_IsProductionLineNeeded.AutoSize = true;
            chb_IsProductionLineNeeded.Font = new Font("Lucida Sans", 11.25F);
            chb_IsProductionLineNeeded.ForeColor = Color.FromArgb(187, 215, 228);
            chb_IsProductionLineNeeded.Location = new Point(7, 54);
            chb_IsProductionLineNeeded.Margin = new Padding(4, 3, 4, 3);
            chb_IsProductionLineNeeded.Name = "chb_IsProductionLineNeeded";
            chb_IsProductionLineNeeded.Size = new Size(181, 21);
            chb_IsProductionLineNeeded.TabIndex = 10;
            chb_IsProductionLineNeeded.Text = "Multipla Processkort?";
            chb_IsProductionLineNeeded.UseVisualStyleBackColor = true;
            // 
            // tlp_Bottom
            // 
            tlp_Bottom.AutoScroll = true;
            tlp_Bottom.ColumnCount = 8;
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 298F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 57F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 344F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 122F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 558F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 994F));
            tlp_Bottom.Controls.Add(flp_Main, 2, 2);
            tlp_Bottom.Controls.Add(dgv_CodeText, 0, 3);
            tlp_Bottom.Controls.Add(flp_ObjectManagement, 1, 2);
            tlp_Bottom.Controls.Add(gbx_Module, 0, 0);
            tlp_Bottom.Controls.Add(gbx_Protocol_Template, 2, 0);
            tlp_Bottom.Controls.Add(gbx_CodeText, 0, 1);
            tlp_Bottom.Dock = DockStyle.Fill;
            tlp_Bottom.Location = new Point(0, 115);
            tlp_Bottom.Margin = new Padding(4, 3, 4, 3);
            tlp_Bottom.Name = "tlp_Bottom";
            tlp_Bottom.Padding = new Padding(6, 23, 6, 0);
            tlp_Bottom.RowCount = 4;
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 142F));
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 119F));
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Bottom.Size = new Size(2098, 1109);
            tlp_Bottom.TabIndex = 875;
            // 
            // flp_ObjectManagement
            // 
            flp_ObjectManagement.Controls.Add(label_Buttons_Module);
            flp_ObjectManagement.Controls.Add(pb_RenameModule);
            flp_ObjectManagement.Controls.Add(btn_ModuleUp);
            flp_ObjectManagement.Controls.Add(btn_ModuleDown);
            flp_ObjectManagement.Controls.Add(btn_DeleteModule);
            flp_ObjectManagement.Controls.Add(label_Buttons_CodeText);
            flp_ObjectManagement.Controls.Add(btn_CodeTextUp);
            flp_ObjectManagement.Controls.Add(btn_CodeTextDown);
            flp_ObjectManagement.Controls.Add(btn_DeleteCodeText);
            flp_ObjectManagement.Dock = DockStyle.Fill;
            flp_ObjectManagement.FlowDirection = FlowDirection.TopDown;
            flp_ObjectManagement.Location = new Point(304, 284);
            flp_ObjectManagement.Margin = new Padding(0);
            flp_ObjectManagement.Name = "flp_ObjectManagement";
            tlp_Bottom.SetRowSpan(flp_ObjectManagement, 2);
            flp_ObjectManagement.Size = new Size(77, 808);
            flp_ObjectManagement.TabIndex = 17;
            // 
            // gbx_Module
            // 
            gbx_Module.Controls.Add(btn_NewModule);
            gbx_Module.Controls.Add(label_ModuleName);
            gbx_Module.Controls.Add(tb_ModuleName);
            gbx_Module.Dock = DockStyle.Fill;
            gbx_Module.Font = new Font("Lucida Sans", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbx_Module.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_Module.Location = new Point(6, 23);
            gbx_Module.Margin = new Padding(0);
            gbx_Module.Name = "gbx_Module";
            gbx_Module.Padding = new Padding(4, 3, 4, 3);
            gbx_Module.Size = new Size(298, 142);
            gbx_Module.TabIndex = 18;
            gbx_Module.TabStop = false;
            gbx_Module.Text = "Modul";
            // 
            // gbx_Protocol_Template
            // 
            tlp_Bottom.SetColumnSpan(gbx_Protocol_Template, 5);
            gbx_Protocol_Template.Controls.Add(pb_Manual);
            gbx_Protocol_Template.Controls.Add(tb_Workoperation);
            gbx_Protocol_Template.Controls.Add(label_Revision);
            gbx_Protocol_Template.Controls.Add(chb_IsUsingPreFab);
            gbx_Protocol_Template.Controls.Add(cb_TemplateRevision);
            gbx_Protocol_Template.Controls.Add(chb_IsProductionLineNeeded);
            gbx_Protocol_Template.Controls.Add(cb_LineClearance_Revision);
            gbx_Protocol_Template.Controls.Add(cb_TemplateName);
            gbx_Protocol_Template.Controls.Add(label_LineClearanceTemplate);
            gbx_Protocol_Template.Controls.Add(cb_MainInfo_Template);
            gbx_Protocol_Template.Controls.Add(btn_NewRevision);
            gbx_Protocol_Template.Controls.Add(label_MainInfoTemplate);
            gbx_Protocol_Template.Controls.Add(label_TemplateName);
            gbx_Protocol_Template.Controls.Add(label_WorkoperationName);
            gbx_Protocol_Template.Dock = DockStyle.Fill;
            gbx_Protocol_Template.Font = new Font("Lucida Sans", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbx_Protocol_Template.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_Protocol_Template.Location = new Point(381, 23);
            gbx_Protocol_Template.Margin = new Padding(0);
            gbx_Protocol_Template.Name = "gbx_Protocol_Template";
            gbx_Protocol_Template.Padding = new Padding(4, 3, 4, 3);
            tlp_Bottom.SetRowSpan(gbx_Protocol_Template, 2);
            gbx_Protocol_Template.Size = new Size(1163, 261);
            gbx_Protocol_Template.TabIndex = 19;
            gbx_Protocol_Template.TabStop = false;
            gbx_Protocol_Template.Text = "Protokoll Mall";
            // 
            // pb_Manual
            // 
            pb_Manual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pb_Manual.BackColor = Color.Transparent;
            pb_Manual.BackgroundImage = (Image)resources.GetObject("pb_Manual.BackgroundImage");
            pb_Manual.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Manual.Cursor = Cursors.Hand;
            pb_Manual.Location = new Point(1121, 9);
            pb_Manual.Margin = new Padding(4, 12, 4, 3);
            pb_Manual.Name = "pb_Manual";
            pb_Manual.Size = new Size(41, 39);
            pb_Manual.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Manual.TabIndex = 871;
            pb_Manual.TabStop = false;
            pb_Manual.Click += pb_Manual_Click;
            // 
            // tb_Workoperation
            // 
            tb_Workoperation.Location = new Point(614, 223);
            tb_Workoperation.Margin = new Padding(4, 3, 4, 3);
            tb_Workoperation.Name = "tb_Workoperation";
            tb_Workoperation.Size = new Size(573, 23);
            tb_Workoperation.TabIndex = 15;
            tb_Workoperation.MouseDown += Workoperation_MouseDown;
            // 
            // gbx_CodeText
            // 
            gbx_CodeText.Controls.Add(tb_NewUnit);
            gbx_CodeText.Controls.Add(tb_NewCodeText);
            gbx_CodeText.Controls.Add(btn_AddCodeText);
            gbx_CodeText.Controls.Add(label_FilterCodeText);
            gbx_CodeText.Controls.Add(tb_FilterCodeText);
            gbx_CodeText.Dock = DockStyle.Fill;
            gbx_CodeText.Font = new Font("Lucida Sans", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbx_CodeText.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_CodeText.Location = new Point(6, 165);
            gbx_CodeText.Margin = new Padding(0);
            gbx_CodeText.Name = "gbx_CodeText";
            gbx_CodeText.Padding = new Padding(4, 3, 4, 3);
            tlp_Bottom.SetRowSpan(gbx_CodeText, 2);
            gbx_CodeText.Size = new Size(298, 189);
            gbx_CodeText.TabIndex = 19;
            gbx_CodeText.TabStop = false;
            gbx_CodeText.Text = "Processparametrar/Enhet";
            // 
            // tb_NewUnit
            // 
            tb_NewUnit.Font = new Font("Lucida Sans", 8.25F);
            tb_NewUnit.Location = new Point(209, 155);
            tb_NewUnit.Margin = new Padding(1, 0, 0, 0);
            tb_NewUnit.Multiline = true;
            tb_NewUnit.Name = "tb_NewUnit";
            tb_NewUnit.Size = new Size(85, 28);
            tb_NewUnit.TabIndex = 14;
            tb_NewUnit.Enter += NewUnit_Enter;
            // 
            // tb_NewCodeText
            // 
            tb_NewCodeText.CharacterCasing = CharacterCasing.Upper;
            tb_NewCodeText.Font = new Font("Lucida Sans", 8.25F);
            tb_NewCodeText.Location = new Point(5, 155);
            tb_NewCodeText.Margin = new Padding(1, 0, 0, 0);
            tb_NewCodeText.Multiline = true;
            tb_NewCodeText.Name = "tb_NewCodeText";
            tb_NewCodeText.Size = new Size(203, 28);
            tb_NewCodeText.TabIndex = 13;
            tb_NewCodeText.Enter += NewCodeText_Enter;
            // 
            // btn_AddCodeText
            // 
            btn_AddCodeText.BackColor = Color.FromArgb(185, 188, 189);
            btn_AddCodeText.Cursor = Cursors.Hand;
            btn_AddCodeText.FlatStyle = FlatStyle.Flat;
            btn_AddCodeText.Font = new Font("Lucida Sans", 10.25F);
            btn_AddCodeText.ForeColor = Color.FromArgb(63, 116, 140);
            btn_AddCodeText.Location = new Point(4, 115);
            btn_AddCodeText.Margin = new Padding(0);
            btn_AddCodeText.Name = "btn_AddCodeText";
            btn_AddCodeText.Size = new Size(290, 35);
            btn_AddCodeText.TabIndex = 12;
            btn_AddCodeText.Text = "Lägg till Parameter/enhet";
            btn_AddCodeText.UseVisualStyleBackColor = false;
            btn_AddCodeText.Click += AddNewCodeText_Unit_Click;
            // 
            // tlp_Top
            // 
            tlp_Top.ColumnCount = 3;
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 292F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 292F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tlp_Top.Controls.Add(tlp_ExtraInfo, 2, 0);
            tlp_Top.Controls.Add(btn_PreviewTemplate, 1, 2);
            tlp_Top.Controls.Add(btn_ConnectPartNr_NewRevision, 1, 1);
            tlp_Top.Controls.Add(btn_DeleteTemplate, 0, 2);
            tlp_Top.Controls.Add(btn_SaveNewTemplate, 0, 0);
            tlp_Top.Controls.Add(btn_UpdateTemplate, 0, 1);
            tlp_Top.Controls.Add(btn_ConnectPartNr_NewTemplate, 1, 0);
            tlp_Top.Dock = DockStyle.Top;
            tlp_Top.Location = new Point(0, 0);
            tlp_Top.Margin = new Padding(4, 3, 4, 3);
            tlp_Top.Name = "tlp_Top";
            tlp_Top.Padding = new Padding(0, 6, 0, 0);
            tlp_Top.RowCount = 3;
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tlp_Top.Size = new Size(2098, 115);
            tlp_Top.TabIndex = 877;
            // 
            // Templates_Protocol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(2098, 1224);
            Controls.Add(tlp_Bottom);
            Controls.Add(tlp_Top);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Templates_Protocol";
            Text = "Manage Templates";
            WindowState = FormWindowState.Maximized;
            FormClosed += Manage_Templates_FormClosed;
            Load += Manage_Templates_Load;
            Resize += Manage_Templates_Resize;
            ((ISupportInitialize)dgv_CodeText).EndInit();
            ((ISupportInitialize)pb_RenameModule).EndInit();
            ((ISupportInitialize)btn_CodeTextUp).EndInit();
            ((ISupportInitialize)btn_CodeTextDown).EndInit();
            ((ISupportInitialize)btn_ModuleUp).EndInit();
            ((ISupportInitialize)btn_ModuleDown).EndInit();
            ((ISupportInitialize)btn_DeleteCodeText).EndInit();
            ((ISupportInitialize)btn_DeleteModule).EndInit();
            tlp_ExtraInfo.ResumeLayout(false);
            tlp_ExtraInfo.PerformLayout();
            tlp_Bottom.ResumeLayout(false);
            flp_ObjectManagement.ResumeLayout(false);
            flp_ObjectManagement.PerformLayout();
            gbx_Module.ResumeLayout(false);
            gbx_Module.PerformLayout();
            gbx_Protocol_Template.ResumeLayout(false);
            gbx_Protocol_Template.PerformLayout();
            ((ISupportInitialize)pb_Manual).EndInit();
            gbx_CodeText.ResumeLayout(false);
            gbx_CodeText.PerformLayout();
            tlp_Top.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flp_Main;
        private DataGridView dgv_CodeText;
        private TextBox tb_ModuleName;
        private ComboBox cb_TemplateName;
        private Button btn_SaveNewTemplate;
        private Button btn_UpdateTemplate;
        private Label label_ModuleName;
        private Label label_TemplateName;
        private Label label_Revision;
        private CheckBox chb_IsUsingPreFab;
        private Button btn_NewModule;
        private TextBox tb_FilterCodeText;
        private Label label_FilterCodeText;
        private Button btn_ConnectPartNr_NewTemplate;
        private Button btn_PreviewTemplate;
        private ComboBox cb_LineClearance_Revision;
        private Label label_LineClearanceTemplate;
        private ComboBox cb_TemplateRevision;
        private Button btn_DeleteTemplate;
        private ComboBox cb_MainInfo_Template;
        private Label label_MainInfoTemplate;
        private Button btn_ConnectPartNr_NewRevision;
        private Label label_Buttons_Module;
        private PictureBox btn_DeleteModule;
        private PictureBox btn_DeleteCodeText;
        private Label label_Buttons_CodeText;
        private PictureBox btn_CodeTextUp;
        private PictureBox btn_CodeTextDown;
        private PictureBox btn_ModuleUp;
        private PictureBox btn_ModuleDown;
        private Label label_TotalConnectedProcesscards;
        private Button btn_NewRevision;
        private PictureBox pb_RenameModule;
        private ToolTip toolTip;
        private Label label_WorkoperationName;
        private Label label_CreatedBy;
        private Label label_CreatedDate;
        private TableLayoutPanel tlp_ExtraInfo;
        private Label lbl_CreatedBy;
        private Label lbl_CreatedDate;
        private Label label_TotalConnectedOrders;
        private CheckBox chb_IsProductionLineNeeded;
        private TableLayoutPanel tlp_Bottom;
        private TableLayoutPanel tlp_Top;
        private FlowLayoutPanel flp_ObjectManagement;
        private GroupBox gbx_Module;
        private GroupBox gbx_Protocol_Template;
        private GroupBox gbx_CodeText;
        private TextBox tb_Workoperation;
        private TextBox tb_NewUnit;
        private TextBox tb_NewCodeText;
        private Button btn_AddCodeText;
        private PictureBox pb_Manual;
    }
}