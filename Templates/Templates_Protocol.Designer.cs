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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Templates_Protocol));
            this.flp_Main = new System.Windows.Forms.FlowLayoutPanel();
            this.dgv_CodeText = new System.Windows.Forms.DataGridView();
            this.tb_ModuleName = new System.Windows.Forms.TextBox();
            this.cb_TemplateName = new System.Windows.Forms.ComboBox();
            this.btn_SaveNewTemplate = new System.Windows.Forms.Button();
            this.btn_UpdateTemplate = new System.Windows.Forms.Button();
            this.label_ModuleName = new System.Windows.Forms.Label();
            this.label_TemplateName = new System.Windows.Forms.Label();
            this.label_Revision = new System.Windows.Forms.Label();
            this.chb_IsUsingPreFab = new System.Windows.Forms.CheckBox();
            this.btn_NewModule = new System.Windows.Forms.Button();
            this.tb_FilterCodeText = new System.Windows.Forms.TextBox();
            this.label_FilterCodeText = new System.Windows.Forms.Label();
            this.btn_ConnectPartNr_NewTemplate = new System.Windows.Forms.Button();
            this.btn_PreviewTemplate = new System.Windows.Forms.Button();
            this.cb_LineClearance_Revision = new System.Windows.Forms.ComboBox();
            this.label_LineClearanceTemplate = new System.Windows.Forms.Label();
            this.cb_TemplateRevision = new System.Windows.Forms.ComboBox();
            this.btn_DeleteTemplate = new System.Windows.Forms.Button();
            this.cb_MainInfo_Template = new System.Windows.Forms.ComboBox();
            this.label_MainInfoTemplate = new System.Windows.Forms.Label();
            this.btn_ConnectPartNr_NewRevision = new System.Windows.Forms.Button();
            this.pb_RenameModule = new System.Windows.Forms.PictureBox();
            this.btn_CodeTextUp = new System.Windows.Forms.PictureBox();
            this.btn_CodeTextDown = new System.Windows.Forms.PictureBox();
            this.btn_ModuleUp = new System.Windows.Forms.PictureBox();
            this.btn_ModuleDown = new System.Windows.Forms.PictureBox();
            this.btn_DeleteCodeText = new System.Windows.Forms.PictureBox();
            this.btn_DeleteModule = new System.Windows.Forms.PictureBox();
            this.label_Buttons_CodeText = new System.Windows.Forms.Label();
            this.label_Buttons_Module = new System.Windows.Forms.Label();
            this.label_TotalConnectedProcesscards = new System.Windows.Forms.Label();
            this.btn_NewRevision = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label_WorkoperationName = new System.Windows.Forms.Label();
            this.label_CreatedBy = new System.Windows.Forms.Label();
            this.label_CreatedDate = new System.Windows.Forms.Label();
            this.tlp_ExtraInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label_TotalConnectedOrders = new System.Windows.Forms.Label();
            this.lbl_CreatedDate = new System.Windows.Forms.Label();
            this.lbl_CreatedBy = new System.Windows.Forms.Label();
            this.chb_IsProductionLineNeeded = new System.Windows.Forms.CheckBox();
            this.tlp_Bottom = new System.Windows.Forms.TableLayoutPanel();
            this.web_PDF_Viewer = new System.Windows.Forms.WebBrowser();
            this.flp_ObjectManagement = new System.Windows.Forms.FlowLayoutPanel();
            this.gbx_Module = new System.Windows.Forms.GroupBox();
            this.gbx_Protocol_Template = new System.Windows.Forms.GroupBox();
            this.tb_Workoperation = new System.Windows.Forms.TextBox();
            this.gbx_CodeText = new System.Windows.Forms.GroupBox();
            this.tlp_Top = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CodeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_RenameModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CodeTextUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CodeTextDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ModuleUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ModuleDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DeleteCodeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DeleteModule)).BeginInit();
            this.tlp_ExtraInfo.SuspendLayout();
            this.tlp_Bottom.SuspendLayout();
            this.flp_ObjectManagement.SuspendLayout();
            this.gbx_Module.SuspendLayout();
            this.gbx_Protocol_Template.SuspendLayout();
            this.gbx_CodeText.SuspendLayout();
            this.tlp_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_Main
            // 
            this.flp_Main.AutoScroll = true;
            this.flp_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            this.tlp_Bottom.SetColumnSpan(this.flp_Main, 5);
            this.flp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Main.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Main.Location = new System.Drawing.Point(329, 244);
            this.flp_Main.MaximumSize = new System.Drawing.Size(1320, 2000);
            this.flp_Main.Name = "flp_Main";
            this.flp_Main.Size = new System.Drawing.Size(1015, 714);
            this.flp_Main.TabIndex = 0;
            this.flp_Main.WrapContents = false;
            // 
            // dgv_CodeText
            // 
            this.dgv_CodeText.AllowUserToAddRows = false;
            this.dgv_CodeText.AllowUserToDeleteRows = false;
            this.dgv_CodeText.AllowUserToResizeColumns = false;
            this.dgv_CodeText.AllowUserToResizeRows = false;
            this.dgv_CodeText.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_CodeText.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            this.dgv_CodeText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CodeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_CodeText.Location = new System.Drawing.Point(5, 241);
            this.dgv_CodeText.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_CodeText.MultiSelect = false;
            this.dgv_CodeText.Name = "dgv_CodeText";
            this.dgv_CodeText.ReadOnly = true;
            this.dgv_CodeText.RowHeadersVisible = false;
            this.dgv_CodeText.Size = new System.Drawing.Size(255, 720);
            this.dgv_CodeText.TabIndex = 2;
            this.dgv_CodeText.Visible = false;
            this.dgv_CodeText.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CodeText_CellMouseDown);
            this.dgv_CodeText.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CodeText_ColumnHeaderMouseClick);
            this.dgv_CodeText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodeText_KeyPress);
            // 
            // tb_ModuleName
            // 
            this.tb_ModuleName.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.tb_ModuleName.Location = new System.Drawing.Point(4, 90);
            this.tb_ModuleName.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.tb_ModuleName.Multiline = true;
            this.tb_ModuleName.Name = "tb_ModuleName";
            this.tb_ModuleName.Size = new System.Drawing.Size(248, 25);
            this.tb_ModuleName.TabIndex = 3;
            this.tb_ModuleName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ModuleName_KeyPress);
            // 
            // cb_TemplateName
            // 
            this.cb_TemplateName.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.cb_TemplateName.FormattingEnabled = true;
            this.cb_TemplateName.Location = new System.Drawing.Point(3, 192);
            this.cb_TemplateName.Margin = new System.Windows.Forms.Padding(0);
            this.cb_TemplateName.Name = "cb_TemplateName";
            this.cb_TemplateName.Size = new System.Drawing.Size(345, 25);
            this.cb_TemplateName.TabIndex = 4;
            this.cb_TemplateName.SelectedIndexChanged += new System.EventHandler(this.Template_Name_SelectedIndexChanged);
            this.cb_TemplateName.TextChanged += new System.EventHandler(this.TemplateName_TextChanged);
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
            this.btn_SaveNewTemplate.Size = new System.Drawing.Size(245, 31);
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
            this.btn_UpdateTemplate.Location = new System.Drawing.Point(5, 36);
            this.btn_UpdateTemplate.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_UpdateTemplate.Name = "btn_UpdateTemplate";
            this.btn_UpdateTemplate.Size = new System.Drawing.Size(245, 31);
            this.btn_UpdateTemplate.TabIndex = 1;
            this.btn_UpdateTemplate.Text = "Uppdatera Mall";
            this.btn_UpdateTemplate.UseVisualStyleBackColor = false;
            this.btn_UpdateTemplate.Click += new System.EventHandler(this.Update_Template_Click);
            // 
            // label_ModuleName
            // 
            this.label_ModuleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.label_ModuleName.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_ModuleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(108)))), ((int)(((byte)(121)))));
            this.label_ModuleName.Location = new System.Drawing.Point(4, 55);
            this.label_ModuleName.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_ModuleName.Name = "label_ModuleName";
            this.label_ModuleName.Size = new System.Drawing.Size(248, 34);
            this.label_ModuleName.TabIndex = 8;
            this.label_ModuleName.Text = "Modul-namn, den vertikala texten till vänster om modulen.\r\n";
            // 
            // label_TemplateName
            // 
            this.label_TemplateName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.label_TemplateName.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_TemplateName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(108)))), ((int)(((byte)(121)))));
            this.label_TemplateName.Location = new System.Drawing.Point(4, 166);
            this.label_TemplateName.Margin = new System.Windows.Forms.Padding(0);
            this.label_TemplateName.Name = "label_TemplateName";
            this.label_TemplateName.Size = new System.Drawing.Size(343, 24);
            this.label_TemplateName.TabIndex = 8;
            this.label_TemplateName.Text = "Mallens namn:";
            // 
            // label_Revision
            // 
            this.label_Revision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.label_Revision.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_Revision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(108)))), ((int)(((byte)(121)))));
            this.label_Revision.Location = new System.Drawing.Point(348, 166);
            this.label_Revision.Margin = new System.Windows.Forms.Padding(0);
            this.label_Revision.Name = "label_Revision";
            this.label_Revision.Size = new System.Drawing.Size(69, 24);
            this.label_Revision.TabIndex = 9;
            this.label_Revision.Text = "Revision";
            // 
            // chb_IsUsingPreFab
            // 
            this.chb_IsUsingPreFab.AutoSize = true;
            this.chb_IsUsingPreFab.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.chb_IsUsingPreFab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.chb_IsUsingPreFab.Location = new System.Drawing.Point(6, 23);
            this.chb_IsUsingPreFab.Name = "chb_IsUsingPreFab";
            this.chb_IsUsingPreFab.Size = new System.Drawing.Size(188, 21);
            this.chb_IsUsingPreFab.TabIndex = 10;
            this.chb_IsUsingPreFab.Text = "Används Halvfabrikat?";
            this.chb_IsUsingPreFab.UseVisualStyleBackColor = true;
            // 
            // btn_NewModule
            // 
            this.btn_NewModule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_NewModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NewModule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewModule.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_NewModule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_NewModule.Location = new System.Drawing.Point(3, 25);
            this.btn_NewModule.Margin = new System.Windows.Forms.Padding(0);
            this.btn_NewModule.Name = "btn_NewModule";
            this.btn_NewModule.Size = new System.Drawing.Size(249, 30);
            this.btn_NewModule.TabIndex = 11;
            this.btn_NewModule.Text = "Lägg till Modul";
            this.btn_NewModule.UseVisualStyleBackColor = false;
            this.btn_NewModule.Click += new System.EventHandler(this.NewModule_Click);
            // 
            // tb_FilterCodeText
            // 
            this.tb_FilterCodeText.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.tb_FilterCodeText.Location = new System.Drawing.Point(4, 49);
            this.tb_FilterCodeText.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.tb_FilterCodeText.Multiline = true;
            this.tb_FilterCodeText.Name = "tb_FilterCodeText";
            this.tb_FilterCodeText.Size = new System.Drawing.Size(248, 25);
            this.tb_FilterCodeText.TabIndex = 3;
            this.tb_FilterCodeText.TextChanged += new System.EventHandler(this.FilterCodeText_TextChanged);
            this.tb_FilterCodeText.Enter += new System.EventHandler(this.FilterCodeText_Enter);
            // 
            // label_FilterCodeText
            // 
            this.label_FilterCodeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.label_FilterCodeText.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_FilterCodeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(108)))), ((int)(((byte)(121)))));
            this.label_FilterCodeText.Location = new System.Drawing.Point(4, 24);
            this.label_FilterCodeText.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_FilterCodeText.Name = "label_FilterCodeText";
            this.label_FilterCodeText.Size = new System.Drawing.Size(248, 24);
            this.label_FilterCodeText.TabIndex = 8;
            this.label_FilterCodeText.Text = "Filtrera texten";
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
            this.btn_ConnectPartNr_NewTemplate.Size = new System.Drawing.Size(250, 31);
            this.btn_ConnectPartNr_NewTemplate.TabIndex = 1;
            this.btn_ConnectPartNr_NewTemplate.Text = "Koppla Aktiv Mall till Processkort";
            this.btn_ConnectPartNr_NewTemplate.UseVisualStyleBackColor = false;
            this.btn_ConnectPartNr_NewTemplate.Click += new System.EventHandler(this.ConnectTemplate_Click);
            // 
            // btn_PreviewTemplate
            // 
            this.btn_PreviewTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_PreviewTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PreviewTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PreviewTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PreviewTemplate.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_PreviewTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_PreviewTemplate.Location = new System.Drawing.Point(250, 67);
            this.btn_PreviewTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.btn_PreviewTemplate.Name = "btn_PreviewTemplate";
            this.btn_PreviewTemplate.Size = new System.Drawing.Size(250, 33);
            this.btn_PreviewTemplate.TabIndex = 1;
            this.btn_PreviewTemplate.Text = "Förhandsgranska Mall";
            this.btn_PreviewTemplate.UseVisualStyleBackColor = false;
            this.btn_PreviewTemplate.Click += new System.EventHandler(this.PreviewTemplate_Click);
            // 
            // cb_LineClearance_Revision
            // 
            this.cb_LineClearance_Revision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_LineClearance_Revision.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.cb_LineClearance_Revision.FormattingEnabled = true;
            this.cb_LineClearance_Revision.Location = new System.Drawing.Point(22, 71);
            this.cb_LineClearance_Revision.Margin = new System.Windows.Forms.Padding(0);
            this.cb_LineClearance_Revision.Name = "cb_LineClearance_Revision";
            this.cb_LineClearance_Revision.Size = new System.Drawing.Size(49, 25);
            this.cb_LineClearance_Revision.TabIndex = 12;
            this.cb_LineClearance_Revision.SelectedIndexChanged += new System.EventHandler(this.LineClearance_Revision_SelectedIndexChanged);
            // 
            // label_LineClearanceTemplate
            // 
            this.label_LineClearanceTemplate.AutoSize = true;
            this.label_LineClearanceTemplate.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_LineClearanceTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.label_LineClearanceTemplate.Location = new System.Drawing.Point(81, 75);
            this.label_LineClearanceTemplate.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label_LineClearanceTemplate.Name = "label_LineClearanceTemplate";
            this.label_LineClearanceTemplate.Size = new System.Drawing.Size(715, 17);
            this.label_LineClearanceTemplate.TabIndex = 13;
            this.label_LineClearanceTemplate.Text = "Revision för LineClearance. Gå till Hantering av Mallar för LineClearance för att" +
    " se hur den ser ut.\r\n";
            // 
            // cb_TemplateRevision
            // 
            this.cb_TemplateRevision.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.cb_TemplateRevision.FormattingEnabled = true;
            this.cb_TemplateRevision.Location = new System.Drawing.Point(347, 192);
            this.cb_TemplateRevision.Margin = new System.Windows.Forms.Padding(0);
            this.cb_TemplateRevision.Name = "cb_TemplateRevision";
            this.cb_TemplateRevision.Size = new System.Drawing.Size(71, 25);
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
            this.btn_DeleteTemplate.Location = new System.Drawing.Point(5, 67);
            this.btn_DeleteTemplate.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_DeleteTemplate.Name = "btn_DeleteTemplate";
            this.btn_DeleteTemplate.Size = new System.Drawing.Size(245, 33);
            this.btn_DeleteTemplate.TabIndex = 1;
            this.btn_DeleteTemplate.Text = "Radera Mall";
            this.btn_DeleteTemplate.UseVisualStyleBackColor = false;
            this.btn_DeleteTemplate.Click += new System.EventHandler(this.Delete_Template_Click);
            // 
            // cb_MainInfo_Template
            // 
            this.cb_MainInfo_Template.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.cb_MainInfo_Template.FormattingEnabled = true;
            this.cb_MainInfo_Template.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cb_MainInfo_Template.Location = new System.Drawing.Point(22, 102);
            this.cb_MainInfo_Template.Margin = new System.Windows.Forms.Padding(0);
            this.cb_MainInfo_Template.Name = "cb_MainInfo_Template";
            this.cb_MainInfo_Template.Size = new System.Drawing.Size(49, 25);
            this.cb_MainInfo_Template.TabIndex = 12;
            // 
            // label_MainInfoTemplate
            // 
            this.label_MainInfoTemplate.AutoSize = true;
            this.label_MainInfoTemplate.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_MainInfoTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.label_MainInfoTemplate.Location = new System.Drawing.Point(81, 106);
            this.label_MainInfoTemplate.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label_MainInfoTemplate.Name = "label_MainInfoTemplate";
            this.label_MainInfoTemplate.Size = new System.Drawing.Size(603, 17);
            this.label_MainInfoTemplate.TabIndex = 13;
            this.label_MainInfoTemplate.Text = "Mall för Main Info (Välj mall och Förhandsgranska mallen för att se hur den ser u" +
    "t)\r\n";
            // 
            // btn_ConnectPartNr_NewRevision
            // 
            this.btn_ConnectPartNr_NewRevision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_ConnectPartNr_NewRevision.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ConnectPartNr_NewRevision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ConnectPartNr_NewRevision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ConnectPartNr_NewRevision.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_ConnectPartNr_NewRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_ConnectPartNr_NewRevision.Location = new System.Drawing.Point(250, 36);
            this.btn_ConnectPartNr_NewRevision.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ConnectPartNr_NewRevision.Name = "btn_ConnectPartNr_NewRevision";
            this.btn_ConnectPartNr_NewRevision.Size = new System.Drawing.Size(250, 31);
            this.btn_ConnectPartNr_NewRevision.TabIndex = 1;
            this.btn_ConnectPartNr_NewRevision.Text = "Koppla Artikelnr till ny Revision";
            this.btn_ConnectPartNr_NewRevision.UseVisualStyleBackColor = false;
            this.btn_ConnectPartNr_NewRevision.Visible = false;
            this.btn_ConnectPartNr_NewRevision.Click += new System.EventHandler(this.ConnectPartNr_NewRevision_Click);
            // 
            // pb_RenameModule
            // 
            this.pb_RenameModule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb_RenameModule.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_RenameModule.BackgroundImage")));
            this.pb_RenameModule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_RenameModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_RenameModule.Location = new System.Drawing.Point(9, 27);
            this.pb_RenameModule.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pb_RenameModule.Name = "pb_RenameModule";
            this.pb_RenameModule.Size = new System.Drawing.Size(42, 41);
            this.pb_RenameModule.TabIndex = 5;
            this.pb_RenameModule.TabStop = false;
            this.toolTip.SetToolTip(this.pb_RenameModule, "Fyll i det nya namnet till vänster ");
            this.pb_RenameModule.Click += new System.EventHandler(this.RenameModule_Click);
            // 
            // btn_CodeTextUp
            // 
            this.btn_CodeTextUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_CodeTextUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CodeTextUp.BackgroundImage")));
            this.btn_CodeTextUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CodeTextUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CodeTextUp.Location = new System.Drawing.Point(17, 238);
            this.btn_CodeTextUp.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btn_CodeTextUp.Name = "btn_CodeTextUp";
            this.btn_CodeTextUp.Size = new System.Drawing.Size(26, 29);
            this.btn_CodeTextUp.TabIndex = 3;
            this.btn_CodeTextUp.TabStop = false;
            this.btn_CodeTextUp.Click += new System.EventHandler(this.CodeTextUp_Click);
            // 
            // btn_CodeTextDown
            // 
            this.btn_CodeTextDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_CodeTextDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CodeTextDown.BackgroundImage")));
            this.btn_CodeTextDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CodeTextDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CodeTextDown.Location = new System.Drawing.Point(17, 275);
            this.btn_CodeTextDown.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btn_CodeTextDown.Name = "btn_CodeTextDown";
            this.btn_CodeTextDown.Size = new System.Drawing.Size(26, 29);
            this.btn_CodeTextDown.TabIndex = 4;
            this.btn_CodeTextDown.TabStop = false;
            this.btn_CodeTextDown.Click += new System.EventHandler(this.CodeTextDown_Click);
            // 
            // btn_ModuleUp
            // 
            this.btn_ModuleUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ModuleUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ModuleUp.BackgroundImage")));
            this.btn_ModuleUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ModuleUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ModuleUp.Location = new System.Drawing.Point(17, 73);
            this.btn_ModuleUp.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btn_ModuleUp.Name = "btn_ModuleUp";
            this.btn_ModuleUp.Size = new System.Drawing.Size(26, 29);
            this.btn_ModuleUp.TabIndex = 2;
            this.btn_ModuleUp.TabStop = false;
            this.btn_ModuleUp.Click += new System.EventHandler(this.ModuleUp_Click);
            // 
            // btn_ModuleDown
            // 
            this.btn_ModuleDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ModuleDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ModuleDown.BackgroundImage")));
            this.btn_ModuleDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ModuleDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ModuleDown.Location = new System.Drawing.Point(17, 110);
            this.btn_ModuleDown.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btn_ModuleDown.Name = "btn_ModuleDown";
            this.btn_ModuleDown.Size = new System.Drawing.Size(26, 29);
            this.btn_ModuleDown.TabIndex = 2;
            this.btn_ModuleDown.TabStop = false;
            this.btn_ModuleDown.Click += new System.EventHandler(this.ModuleDown_Click);
            // 
            // btn_DeleteCodeText
            // 
            this.btn_DeleteCodeText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_DeleteCodeText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_DeleteCodeText.BackgroundImage")));
            this.btn_DeleteCodeText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DeleteCodeText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteCodeText.Location = new System.Drawing.Point(9, 312);
            this.btn_DeleteCodeText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btn_DeleteCodeText.Name = "btn_DeleteCodeText";
            this.btn_DeleteCodeText.Size = new System.Drawing.Size(41, 41);
            this.btn_DeleteCodeText.TabIndex = 1;
            this.btn_DeleteCodeText.TabStop = false;
            this.toolTip.SetToolTip(this.btn_DeleteCodeText, "Radera markerad rad");
            this.btn_DeleteCodeText.Click += new System.EventHandler(this.DeleteCodeText_Click);
            // 
            // btn_DeleteModule
            // 
            this.btn_DeleteModule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_DeleteModule.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_DeleteModule.BackgroundImage")));
            this.btn_DeleteModule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DeleteModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteModule.Location = new System.Drawing.Point(9, 147);
            this.btn_DeleteModule.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.btn_DeleteModule.Name = "btn_DeleteModule";
            this.btn_DeleteModule.Size = new System.Drawing.Size(41, 41);
            this.btn_DeleteModule.TabIndex = 1;
            this.btn_DeleteModule.TabStop = false;
            this.toolTip.SetToolTip(this.btn_DeleteModule, "Radera markerad modul");
            this.btn_DeleteModule.Click += new System.EventHandler(this.DeleteModule_Click);
            // 
            // label_Buttons_CodeText
            // 
            this.label_Buttons_CodeText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Buttons_CodeText.AutoSize = true;
            this.label_Buttons_CodeText.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold);
            this.label_Buttons_CodeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.label_Buttons_CodeText.Location = new System.Drawing.Point(8, 213);
            this.label_Buttons_CodeText.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.label_Buttons_CodeText.Name = "label_Buttons_CodeText";
            this.label_Buttons_CodeText.Size = new System.Drawing.Size(43, 17);
            this.label_Buttons_CodeText.TabIndex = 0;
            this.label_Buttons_CodeText.Text = "Text";
            // 
            // label_Buttons_Module
            // 
            this.label_Buttons_Module.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Buttons_Module.AutoSize = true;
            this.label_Buttons_Module.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold);
            this.label_Buttons_Module.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.label_Buttons_Module.Location = new System.Drawing.Point(3, 0);
            this.label_Buttons_Module.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label_Buttons_Module.Name = "label_Buttons_Module";
            this.label_Buttons_Module.Size = new System.Drawing.Size(54, 17);
            this.label_Buttons_Module.TabIndex = 0;
            this.label_Buttons_Module.Text = "Modul";
            // 
            // label_TotalConnectedProcesscards
            // 
            this.label_TotalConnectedProcesscards.AutoSize = true;
            this.tlp_ExtraInfo.SetColumnSpan(this.label_TotalConnectedProcesscards, 2);
            this.label_TotalConnectedProcesscards.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_TotalConnectedProcesscards.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_TotalConnectedProcesscards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.label_TotalConnectedProcesscards.Location = new System.Drawing.Point(159, 70);
            this.label_TotalConnectedProcesscards.Name = "label_TotalConnectedProcesscards";
            this.label_TotalConnectedProcesscards.Size = new System.Drawing.Size(291, 24);
            this.label_TotalConnectedProcesscards.TabIndex = 16;
            this.label_TotalConnectedProcesscards.Text = "Antal Processkort kopplade till mallen:";
            this.label_TotalConnectedProcesscards.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_NewRevision
            // 
            this.btn_NewRevision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_NewRevision.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NewRevision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewRevision.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_NewRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_NewRevision.Location = new System.Drawing.Point(419, 192);
            this.btn_NewRevision.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btn_NewRevision.Name = "btn_NewRevision";
            this.btn_NewRevision.Size = new System.Drawing.Size(104, 24);
            this.btn_NewRevision.TabIndex = 1;
            this.btn_NewRevision.Text = "Ny Revision";
            this.toolTip.SetToolTip(this.btn_NewRevision, "Vänsterklicka för att stega upp en revision, högerklicka för att stega ner en rev" +
        "ision.");
            this.btn_NewRevision.UseVisualStyleBackColor = false;
            this.btn_NewRevision.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewRevision_MouseDown);
            // 
            // label_WorkoperationName
            // 
            this.label_WorkoperationName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.label_WorkoperationName.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_WorkoperationName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(108)))), ((int)(((byte)(121)))));
            this.label_WorkoperationName.Location = new System.Drawing.Point(525, 166);
            this.label_WorkoperationName.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_WorkoperationName.Name = "label_WorkoperationName";
            this.label_WorkoperationName.Size = new System.Drawing.Size(492, 24);
            this.label_WorkoperationName.TabIndex = 8;
            this.label_WorkoperationName.Text = "Arbetsoperation:";
            // 
            // label_CreatedBy
            // 
            this.label_CreatedBy.AutoSize = true;
            this.label_CreatedBy.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_CreatedBy.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_CreatedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.label_CreatedBy.Location = new System.Drawing.Point(10, 1);
            this.label_CreatedBy.Name = "label_CreatedBy";
            this.label_CreatedBy.Size = new System.Drawing.Size(138, 22);
            this.label_CreatedBy.TabIndex = 16;
            this.label_CreatedBy.Text = "Mallen skapad av:";
            // 
            // label_CreatedDate
            // 
            this.label_CreatedDate.AutoSize = true;
            this.label_CreatedDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_CreatedDate.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_CreatedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.label_CreatedDate.Location = new System.Drawing.Point(32, 24);
            this.label_CreatedDate.Name = "label_CreatedDate";
            this.label_CreatedDate.Size = new System.Drawing.Size(116, 22);
            this.label_CreatedDate.TabIndex = 16;
            this.label_CreatedDate.Text = "Mallen skapad:";
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
            this.tlp_ExtraInfo.Location = new System.Drawing.Point(1721, 5);
            this.tlp_ExtraInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_ExtraInfo.Name = "tlp_ExtraInfo";
            this.tlp_ExtraInfo.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tlp_ExtraInfo.RowCount = 4;
            this.tlp_Top.SetRowSpan(this.tlp_ExtraInfo, 3);
            this.tlp_ExtraInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_ExtraInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_ExtraInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_ExtraInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_ExtraInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_ExtraInfo.Size = new System.Drawing.Size(459, 95);
            this.tlp_ExtraInfo.TabIndex = 18;
            // 
            // label_TotalConnectedOrders
            // 
            this.label_TotalConnectedOrders.AutoSize = true;
            this.tlp_ExtraInfo.SetColumnSpan(this.label_TotalConnectedOrders, 2);
            this.label_TotalConnectedOrders.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_TotalConnectedOrders.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_TotalConnectedOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.label_TotalConnectedOrders.Location = new System.Drawing.Point(199, 47);
            this.label_TotalConnectedOrders.Name = "label_TotalConnectedOrders";
            this.label_TotalConnectedOrders.Size = new System.Drawing.Size(251, 22);
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
            this.lbl_CreatedDate.Location = new System.Drawing.Point(152, 24);
            this.lbl_CreatedDate.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_CreatedDate.Name = "lbl_CreatedDate";
            this.lbl_CreatedDate.Size = new System.Drawing.Size(301, 22);
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
            this.lbl_CreatedBy.Size = new System.Drawing.Size(301, 22);
            this.lbl_CreatedBy.TabIndex = 17;
            this.lbl_CreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chb_IsProductionLineNeeded
            // 
            this.chb_IsProductionLineNeeded.AutoSize = true;
            this.chb_IsProductionLineNeeded.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.chb_IsProductionLineNeeded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(228)))));
            this.chb_IsProductionLineNeeded.Location = new System.Drawing.Point(6, 47);
            this.chb_IsProductionLineNeeded.Name = "chb_IsProductionLineNeeded";
            this.chb_IsProductionLineNeeded.Size = new System.Drawing.Size(181, 21);
            this.chb_IsProductionLineNeeded.TabIndex = 10;
            this.chb_IsProductionLineNeeded.Text = "Multipla Processkort?";
            this.chb_IsProductionLineNeeded.UseVisualStyleBackColor = true;
            // 
            // tlp_Bottom
            // 
            this.tlp_Bottom.ColumnCount = 8;
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 295F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 502F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 828F));
            this.tlp_Bottom.Controls.Add(this.flp_Main, 2, 2);
            this.tlp_Bottom.Controls.Add(this.dgv_CodeText, 0, 2);
            this.tlp_Bottom.Controls.Add(this.web_PDF_Viewer, 7, 2);
            this.tlp_Bottom.Controls.Add(this.flp_ObjectManagement, 1, 2);
            this.tlp_Bottom.Controls.Add(this.gbx_Module, 0, 0);
            this.tlp_Bottom.Controls.Add(this.gbx_Protocol_Template, 2, 0);
            this.tlp_Bottom.Controls.Add(this.gbx_CodeText, 0, 1);
            this.tlp_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Bottom.Location = new System.Drawing.Point(0, 100);
            this.tlp_Bottom.Name = "tlp_Bottom";
            this.tlp_Bottom.Padding = new System.Windows.Forms.Padding(5, 20, 5, 0);
            this.tlp_Bottom.RowCount = 3;
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Bottom.Size = new System.Drawing.Size(2180, 961);
            this.tlp_Bottom.TabIndex = 875;
            // 
            // web_PDF_Viewer
            // 
            this.web_PDF_Viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web_PDF_Viewer.Location = new System.Drawing.Point(1350, 244);
            this.web_PDF_Viewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_PDF_Viewer.Name = "web_PDF_Viewer";
            this.web_PDF_Viewer.Size = new System.Drawing.Size(822, 714);
            this.web_PDF_Viewer.TabIndex = 16;
            // 
            // flp_ObjectManagement
            // 
            this.flp_ObjectManagement.Controls.Add(this.label_Buttons_Module);
            this.flp_ObjectManagement.Controls.Add(this.pb_RenameModule);
            this.flp_ObjectManagement.Controls.Add(this.btn_ModuleUp);
            this.flp_ObjectManagement.Controls.Add(this.btn_ModuleDown);
            this.flp_ObjectManagement.Controls.Add(this.btn_DeleteModule);
            this.flp_ObjectManagement.Controls.Add(this.label_Buttons_CodeText);
            this.flp_ObjectManagement.Controls.Add(this.btn_CodeTextUp);
            this.flp_ObjectManagement.Controls.Add(this.btn_CodeTextDown);
            this.flp_ObjectManagement.Controls.Add(this.btn_DeleteCodeText);
            this.flp_ObjectManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_ObjectManagement.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_ObjectManagement.Location = new System.Drawing.Point(260, 241);
            this.flp_ObjectManagement.Margin = new System.Windows.Forms.Padding(0);
            this.flp_ObjectManagement.Name = "flp_ObjectManagement";
            this.flp_ObjectManagement.Size = new System.Drawing.Size(66, 720);
            this.flp_ObjectManagement.TabIndex = 17;
            // 
            // gbx_Module
            // 
            this.gbx_Module.Controls.Add(this.btn_NewModule);
            this.gbx_Module.Controls.Add(this.label_ModuleName);
            this.gbx_Module.Controls.Add(this.tb_ModuleName);
            this.gbx_Module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_Module.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_Module.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.gbx_Module.Location = new System.Drawing.Point(5, 20);
            this.gbx_Module.Margin = new System.Windows.Forms.Padding(0);
            this.gbx_Module.Name = "gbx_Module";
            this.gbx_Module.Size = new System.Drawing.Size(255, 123);
            this.gbx_Module.TabIndex = 18;
            this.gbx_Module.TabStop = false;
            this.gbx_Module.Text = "Modul";
            // 
            // gbx_Protocol_Template
            // 
            this.tlp_Bottom.SetColumnSpan(this.gbx_Protocol_Template, 5);
            this.gbx_Protocol_Template.Controls.Add(this.tb_Workoperation);
            this.gbx_Protocol_Template.Controls.Add(this.label_Revision);
            this.gbx_Protocol_Template.Controls.Add(this.chb_IsUsingPreFab);
            this.gbx_Protocol_Template.Controls.Add(this.cb_TemplateRevision);
            this.gbx_Protocol_Template.Controls.Add(this.chb_IsProductionLineNeeded);
            this.gbx_Protocol_Template.Controls.Add(this.cb_LineClearance_Revision);
            this.gbx_Protocol_Template.Controls.Add(this.cb_TemplateName);
            this.gbx_Protocol_Template.Controls.Add(this.label_LineClearanceTemplate);
            this.gbx_Protocol_Template.Controls.Add(this.cb_MainInfo_Template);
            this.gbx_Protocol_Template.Controls.Add(this.btn_NewRevision);
            this.gbx_Protocol_Template.Controls.Add(this.label_MainInfoTemplate);
            this.gbx_Protocol_Template.Controls.Add(this.label_TemplateName);
            this.gbx_Protocol_Template.Controls.Add(this.label_WorkoperationName);
            this.gbx_Protocol_Template.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_Protocol_Template.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_Protocol_Template.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.gbx_Protocol_Template.Location = new System.Drawing.Point(326, 20);
            this.gbx_Protocol_Template.Margin = new System.Windows.Forms.Padding(0);
            this.gbx_Protocol_Template.Name = "gbx_Protocol_Template";
            this.tlp_Bottom.SetRowSpan(this.gbx_Protocol_Template, 2);
            this.gbx_Protocol_Template.Size = new System.Drawing.Size(1021, 221);
            this.gbx_Protocol_Template.TabIndex = 19;
            this.gbx_Protocol_Template.TabStop = false;
            this.gbx_Protocol_Template.Text = "Protokoll Mall";
            // 
            // tb_Workoperation
            // 
            this.tb_Workoperation.Location = new System.Drawing.Point(526, 193);
            this.tb_Workoperation.Name = "tb_Workoperation";
            this.tb_Workoperation.Size = new System.Drawing.Size(492, 23);
            this.tb_Workoperation.TabIndex = 15;
            this.tb_Workoperation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Workoperation_MouseDown);
            // 
            // gbx_CodeText
            // 
            this.gbx_CodeText.Controls.Add(this.label_FilterCodeText);
            this.gbx_CodeText.Controls.Add(this.tb_FilterCodeText);
            this.gbx_CodeText.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_CodeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.gbx_CodeText.Location = new System.Drawing.Point(5, 143);
            this.gbx_CodeText.Margin = new System.Windows.Forms.Padding(0);
            this.gbx_CodeText.Name = "gbx_CodeText";
            this.gbx_CodeText.Size = new System.Drawing.Size(255, 88);
            this.gbx_CodeText.TabIndex = 19;
            this.gbx_CodeText.TabStop = false;
            this.gbx_CodeText.Text = "Processparametrar/Enhet";
            // 
            // tlp_Top
            // 
            this.tlp_Top.ColumnCount = 3;
            this.tlp_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlp_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlp_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Top.Controls.Add(this.tlp_ExtraInfo, 2, 0);
            this.tlp_Top.Controls.Add(this.btn_PreviewTemplate, 1, 2);
            this.tlp_Top.Controls.Add(this.btn_ConnectPartNr_NewRevision, 1, 1);
            this.tlp_Top.Controls.Add(this.btn_DeleteTemplate, 0, 2);
            this.tlp_Top.Controls.Add(this.btn_SaveNewTemplate, 0, 0);
            this.tlp_Top.Controls.Add(this.btn_UpdateTemplate, 0, 1);
            this.tlp_Top.Controls.Add(this.btn_ConnectPartNr_NewTemplate, 1, 0);
            this.tlp_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_Top.Location = new System.Drawing.Point(0, 0);
            this.tlp_Top.Name = "tlp_Top";
            this.tlp_Top.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tlp_Top.RowCount = 3;
            this.tlp_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Top.Size = new System.Drawing.Size(2180, 100);
            this.tlp_Top.TabIndex = 877;
            // 
            // Templates_Protocol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(2180, 1061);
            this.Controls.Add(this.tlp_Bottom);
            this.Controls.Add(this.tlp_Top);
            this.Name = "Templates_Protocol";
            this.Text = "Manage Templates";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Manage_Templates_FormClosed);
            this.Load += new System.EventHandler(this.Manage_Templates_Load);
            this.Resize += new System.EventHandler(this.Manage_Templates_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CodeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_RenameModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CodeTextUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CodeTextDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ModuleUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ModuleDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DeleteCodeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DeleteModule)).EndInit();
            this.tlp_ExtraInfo.ResumeLayout(false);
            this.tlp_ExtraInfo.PerformLayout();
            this.tlp_Bottom.ResumeLayout(false);
            this.flp_ObjectManagement.ResumeLayout(false);
            this.flp_ObjectManagement.PerformLayout();
            this.gbx_Module.ResumeLayout(false);
            this.gbx_Module.PerformLayout();
            this.gbx_Protocol_Template.ResumeLayout(false);
            this.gbx_Protocol_Template.PerformLayout();
            this.gbx_CodeText.ResumeLayout(false);
            this.gbx_CodeText.PerformLayout();
            this.tlp_Top.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private WebBrowser web_PDF_Viewer;
        private FlowLayoutPanel flp_ObjectManagement;
        private GroupBox gbx_Module;
        private GroupBox gbx_Protocol_Template;
        private GroupBox gbx_CodeText;
        private TextBox tb_Workoperation;
    }
}