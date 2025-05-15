using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Templates
{
    partial class Connect_Templates
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_PartList = new System.Windows.Forms.DataGridView();
            this.tb_Workoperation = new System.Windows.Forms.TextBox();
            this.tb_PartNumber = new System.Windows.Forms.TextBox();
            this.label_Workoperation = new System.Windows.Forms.Label();
            this.label_PartNumber = new System.Windows.Forms.Label();
            this.label_TemplateName = new System.Windows.Forms.Label();
            this.tb_TemplateName = new System.Windows.Forms.TextBox();
            this.btn_CreateNewRevisionProcesscard = new System.Windows.Forms.Button();
            this.label_ProdType = new System.Windows.Forms.Label();
            this.tb_ProdType = new System.Windows.Forms.TextBox();
            this.chb_ShowRevNr = new System.Windows.Forms.CheckBox();
            this.btn_UpdateExistingRevisionProcesscard = new System.Windows.Forms.Button();
            this.tb_ProdLine = new System.Windows.Forms.TextBox();
            this.label_ProdLine = new System.Windows.Forms.Label();
            this.chb_Invert_PartNr = new System.Windows.Forms.CheckBox();
            this.chb_Invert_Workoperation = new System.Windows.Forms.CheckBox();
            this.chb_Invert_TemplateName = new System.Windows.Forms.CheckBox();
            this.chb_Invert_ProdType = new System.Windows.Forms.CheckBox();
            this.chb_Invert_ProdLine = new System.Windows.Forms.CheckBox();
            this.label_Invert = new System.Windows.Forms.Label();
            this.num_Machines = new System.Windows.Forms.NumericUpDown();
            this.label_Machines = new System.Windows.Forms.Label();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.tlp_Bottom = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_ActiveRow = new System.Windows.Forms.Label();
            this.label_av = new System.Windows.Forms.Label();
            this.lbl_TotalRows = new System.Windows.Forms.Label();
            this.label_Processkort_Godkänt_RevInfo = new System.Windows.Forms.Label();
            this.tb_RevInfo = new System.Windows.Forms.TextBox();
            this.label_Revision = new System.Windows.Forms.Label();
            this.tb_Revision = new System.Windows.Forms.TextBox();
            this.chb_Invert_Revision = new System.Windows.Forms.CheckBox();
            this.btn_ConnectMeasureTemplate = new System.Windows.Forms.Button();
            this.flp_Buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_CompareDataInTemplates = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PartList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Machines)).BeginInit();
            this.panel_Left.SuspendLayout();
            this.tlp_Bottom.SuspendLayout();
            this.flp_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_PartList
            // 
            this.dgv_PartList.AllowUserToAddRows = false;
            this.dgv_PartList.AllowUserToDeleteRows = false;
            this.dgv_PartList.AllowUserToResizeColumns = false;
            this.dgv_PartList.AllowUserToResizeRows = false;
            this.dgv_PartList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_PartList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            this.dgv_PartList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(146)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PartList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_PartList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_PartList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_PartList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_PartList.EnableHeadersVisualStyles = false;
            this.dgv_PartList.Location = new System.Drawing.Point(0, 0);
            this.dgv_PartList.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.dgv_PartList.Name = "dgv_PartList";
            this.dgv_PartList.ReadOnly = true;
            this.dgv_PartList.RowHeadersVisible = false;
            this.dgv_PartList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PartList.Size = new System.Drawing.Size(1280, 995);
            this.dgv_PartList.TabIndex = 15;
            this.dgv_PartList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.PartList_CellEnter);
            this.dgv_PartList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.PartList_RowsAdded);
            this.dgv_PartList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.PartList_RowsRemoved);
            // 
            // tb_Workoperation
            // 
            this.tb_Workoperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Workoperation.Location = new System.Drawing.Point(1564, 180);
            this.tb_Workoperation.Name = "tb_Workoperation";
            this.tb_Workoperation.Size = new System.Drawing.Size(136, 20);
            this.tb_Workoperation.TabIndex = 18;
            this.tb_Workoperation.TextChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // tb_PartNumber
            // 
            this.tb_PartNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_PartNumber.Location = new System.Drawing.Point(1564, 120);
            this.tb_PartNumber.Name = "tb_PartNumber";
            this.tb_PartNumber.Size = new System.Drawing.Size(136, 20);
            this.tb_PartNumber.TabIndex = 19;
            this.tb_PartNumber.TextChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // label_Workoperation
            // 
            this.label_Workoperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Workoperation.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_Workoperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_Workoperation.Location = new System.Drawing.Point(1564, 160);
            this.label_Workoperation.Name = "label_Workoperation";
            this.label_Workoperation.Size = new System.Drawing.Size(136, 16);
            this.label_Workoperation.TabIndex = 16;
            this.label_Workoperation.Text = "Arbetsoperation";
            this.label_Workoperation.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_Workoperation.Click += new System.EventHandler(this.Filter_ClearText_Click);
            // 
            // label_PartNumber
            // 
            this.label_PartNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PartNumber.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_PartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_PartNumber.Location = new System.Drawing.Point(1564, 100);
            this.label_PartNumber.Name = "label_PartNumber";
            this.label_PartNumber.Size = new System.Drawing.Size(136, 16);
            this.label_PartNumber.TabIndex = 17;
            this.label_PartNumber.Text = "ArtikelNr:";
            this.label_PartNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_PartNumber.Click += new System.EventHandler(this.Filter_ClearText_Click);
            // 
            // label_TemplateName
            // 
            this.label_TemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_TemplateName.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_TemplateName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_TemplateName.Location = new System.Drawing.Point(1564, 220);
            this.label_TemplateName.Name = "label_TemplateName";
            this.label_TemplateName.Size = new System.Drawing.Size(136, 16);
            this.label_TemplateName.TabIndex = 16;
            this.label_TemplateName.Text = "Mall namn";
            this.label_TemplateName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_TemplateName.Click += new System.EventHandler(this.Filter_ClearText_Click);
            // 
            // tb_TemplateName
            // 
            this.tb_TemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_TemplateName.Location = new System.Drawing.Point(1564, 240);
            this.tb_TemplateName.Name = "tb_TemplateName";
            this.tb_TemplateName.Size = new System.Drawing.Size(136, 20);
            this.tb_TemplateName.TabIndex = 18;
            this.tb_TemplateName.TextChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // btn_CreateNewRevisionProcesscard
            // 
            this.btn_CreateNewRevisionProcesscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CreateNewRevisionProcesscard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_CreateNewRevisionProcesscard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CreateNewRevisionProcesscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateNewRevisionProcesscard.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_CreateNewRevisionProcesscard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_CreateNewRevisionProcesscard.Location = new System.Drawing.Point(0, 169);
            this.btn_CreateNewRevisionProcesscard.Margin = new System.Windows.Forms.Padding(0);
            this.btn_CreateNewRevisionProcesscard.Name = "btn_CreateNewRevisionProcesscard";
            this.btn_CreateNewRevisionProcesscard.Size = new System.Drawing.Size(190, 42);
            this.btn_CreateNewRevisionProcesscard.TabIndex = 20;
            this.btn_CreateNewRevisionProcesscard.Text = "Skapa en ny Revision av Processkortet";
            this.btn_CreateNewRevisionProcesscard.UseVisualStyleBackColor = false;
            this.btn_CreateNewRevisionProcesscard.Click += new System.EventHandler(this.CreateNewRevisionProcesscard);
            // 
            // label_ProdType
            // 
            this.label_ProdType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ProdType.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_ProdType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_ProdType.Location = new System.Drawing.Point(1564, 280);
            this.label_ProdType.Name = "label_ProdType";
            this.label_ProdType.Size = new System.Drawing.Size(136, 16);
            this.label_ProdType.TabIndex = 16;
            this.label_ProdType.Text = "ProdType";
            this.label_ProdType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_ProdType.Click += new System.EventHandler(this.Filter_ClearText_Click);
            // 
            // tb_ProdType
            // 
            this.tb_ProdType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ProdType.Location = new System.Drawing.Point(1564, 300);
            this.tb_ProdType.Name = "tb_ProdType";
            this.tb_ProdType.Size = new System.Drawing.Size(136, 20);
            this.tb_ProdType.TabIndex = 18;
            this.tb_ProdType.TextChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // chb_ShowRevNr
            // 
            this.chb_ShowRevNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_ShowRevNr.AutoSize = true;
            this.chb_ShowRevNr.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.chb_ShowRevNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.chb_ShowRevNr.Location = new System.Drawing.Point(1530, 38);
            this.chb_ShowRevNr.Name = "chb_ShowRevNr";
            this.chb_ShowRevNr.Size = new System.Drawing.Size(170, 20);
            this.chb_ShowRevNr.TabIndex = 21;
            this.chb_ShowRevNr.Text = "Visa Gamla Revisioner";
            this.chb_ShowRevNr.UseVisualStyleBackColor = true;
            this.chb_ShowRevNr.Visible = false;
            this.chb_ShowRevNr.CheckedChanged += new System.EventHandler(this.ShowRevNr_CheckedChanged);
            // 
            // btn_UpdateExistingRevisionProcesscard
            // 
            this.btn_UpdateExistingRevisionProcesscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_UpdateExistingRevisionProcesscard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_UpdateExistingRevisionProcesscard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_UpdateExistingRevisionProcesscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UpdateExistingRevisionProcesscard.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_UpdateExistingRevisionProcesscard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_UpdateExistingRevisionProcesscard.Location = new System.Drawing.Point(0, 211);
            this.btn_UpdateExistingRevisionProcesscard.Margin = new System.Windows.Forms.Padding(0);
            this.btn_UpdateExistingRevisionProcesscard.Name = "btn_UpdateExistingRevisionProcesscard";
            this.btn_UpdateExistingRevisionProcesscard.Size = new System.Drawing.Size(190, 94);
            this.btn_UpdateExistingRevisionProcesscard.TabIndex = 20;
            this.btn_UpdateExistingRevisionProcesscard.Text = "Uppdaterar Processkort \r\nAnvänds endast för SuperAdmin när mallar ska kopplas om " +
    "till nya systemet\r\n\r\n";
            this.btn_UpdateExistingRevisionProcesscard.UseVisualStyleBackColor = false;
            this.btn_UpdateExistingRevisionProcesscard.Visible = false;
            this.btn_UpdateExistingRevisionProcesscard.Click += new System.EventHandler(this.UpdateExistingRevisionProcesscard);
            // 
            // tb_ProdLine
            // 
            this.tb_ProdLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ProdLine.Location = new System.Drawing.Point(1564, 360);
            this.tb_ProdLine.Name = "tb_ProdLine";
            this.tb_ProdLine.Size = new System.Drawing.Size(136, 20);
            this.tb_ProdLine.TabIndex = 23;
            this.tb_ProdLine.TextChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // label_ProdLine
            // 
            this.label_ProdLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ProdLine.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_ProdLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_ProdLine.Location = new System.Drawing.Point(1564, 340);
            this.label_ProdLine.Name = "label_ProdLine";
            this.label_ProdLine.Size = new System.Drawing.Size(136, 16);
            this.label_ProdLine.TabIndex = 22;
            this.label_ProdLine.Text = "ProdLine";
            this.label_ProdLine.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_ProdLine.Click += new System.EventHandler(this.Filter_ClearText_Click);
            // 
            // chb_Invert_PartNr
            // 
            this.chb_Invert_PartNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_Invert_PartNr.AutoSize = true;
            this.chb_Invert_PartNr.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.chb_Invert_PartNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.chb_Invert_PartNr.Location = new System.Drawing.Point(1529, 124);
            this.chb_Invert_PartNr.Name = "chb_Invert_PartNr";
            this.chb_Invert_PartNr.Size = new System.Drawing.Size(15, 14);
            this.chb_Invert_PartNr.TabIndex = 24;
            this.chb_Invert_PartNr.UseVisualStyleBackColor = true;
            this.chb_Invert_PartNr.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // chb_Invert_Workoperation
            // 
            this.chb_Invert_Workoperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_Invert_Workoperation.AutoSize = true;
            this.chb_Invert_Workoperation.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.chb_Invert_Workoperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.chb_Invert_Workoperation.Location = new System.Drawing.Point(1529, 184);
            this.chb_Invert_Workoperation.Name = "chb_Invert_Workoperation";
            this.chb_Invert_Workoperation.Size = new System.Drawing.Size(15, 14);
            this.chb_Invert_Workoperation.TabIndex = 24;
            this.chb_Invert_Workoperation.UseVisualStyleBackColor = true;
            this.chb_Invert_Workoperation.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // chb_Invert_TemplateName
            // 
            this.chb_Invert_TemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_Invert_TemplateName.AutoSize = true;
            this.chb_Invert_TemplateName.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.chb_Invert_TemplateName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.chb_Invert_TemplateName.Location = new System.Drawing.Point(1529, 244);
            this.chb_Invert_TemplateName.Name = "chb_Invert_TemplateName";
            this.chb_Invert_TemplateName.Size = new System.Drawing.Size(15, 14);
            this.chb_Invert_TemplateName.TabIndex = 24;
            this.chb_Invert_TemplateName.UseVisualStyleBackColor = true;
            this.chb_Invert_TemplateName.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // chb_Invert_ProdType
            // 
            this.chb_Invert_ProdType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_Invert_ProdType.AutoSize = true;
            this.chb_Invert_ProdType.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.chb_Invert_ProdType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.chb_Invert_ProdType.Location = new System.Drawing.Point(1530, 304);
            this.chb_Invert_ProdType.Name = "chb_Invert_ProdType";
            this.chb_Invert_ProdType.Size = new System.Drawing.Size(15, 14);
            this.chb_Invert_ProdType.TabIndex = 24;
            this.chb_Invert_ProdType.UseVisualStyleBackColor = true;
            this.chb_Invert_ProdType.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // chb_Invert_ProdLine
            // 
            this.chb_Invert_ProdLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_Invert_ProdLine.AutoSize = true;
            this.chb_Invert_ProdLine.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.chb_Invert_ProdLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.chb_Invert_ProdLine.Location = new System.Drawing.Point(1530, 364);
            this.chb_Invert_ProdLine.Name = "chb_Invert_ProdLine";
            this.chb_Invert_ProdLine.Size = new System.Drawing.Size(15, 14);
            this.chb_Invert_ProdLine.TabIndex = 24;
            this.chb_Invert_ProdLine.UseVisualStyleBackColor = true;
            this.chb_Invert_ProdLine.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // label_Invert
            // 
            this.label_Invert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Invert.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_Invert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_Invert.Location = new System.Drawing.Point(1479, 100);
            this.label_Invert.Name = "label_Invert";
            this.label_Invert.Size = new System.Drawing.Size(79, 16);
            this.label_Invert.TabIndex = 25;
            this.label_Invert.Text = "Invertera";
            this.label_Invert.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // num_Machines
            // 
            this.num_Machines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_Machines.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.num_Machines.Location = new System.Drawing.Point(1636, 477);
            this.num_Machines.Name = "num_Machines";
            this.num_Machines.Size = new System.Drawing.Size(62, 27);
            this.num_Machines.TabIndex = 26;
            this.num_Machines.ValueChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // label_Machines
            // 
            this.label_Machines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Machines.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_Machines.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_Machines.Location = new System.Drawing.Point(1564, 458);
            this.label_Machines.Name = "label_Machines";
            this.label_Machines.Size = new System.Drawing.Size(136, 16);
            this.label_Machines.TabIndex = 22;
            this.label_Machines.Text = "Antal Maskiner:";
            this.label_Machines.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_Machines.Click += new System.EventHandler(this.Filter_ClearText_Click);
            // 
            // panel_Left
            // 
            this.panel_Left.Controls.Add(this.dgv_PartList);
            this.panel_Left.Controls.Add(this.tlp_Bottom);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 0);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(1280, 1019);
            this.panel_Left.TabIndex = 27;
            // 
            // tlp_Bottom
            // 
            this.tlp_Bottom.ColumnCount = 4;
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Bottom.Controls.Add(this.lbl_ActiveRow, 0, 0);
            this.tlp_Bottom.Controls.Add(this.label_av, 1, 0);
            this.tlp_Bottom.Controls.Add(this.lbl_TotalRows, 2, 0);
            this.tlp_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlp_Bottom.Location = new System.Drawing.Point(0, 995);
            this.tlp_Bottom.Name = "tlp_Bottom";
            this.tlp_Bottom.RowCount = 1;
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Bottom.Size = new System.Drawing.Size(1280, 24);
            this.tlp_Bottom.TabIndex = 16;
            // 
            // lbl_ActiveRow
            // 
            this.lbl_ActiveRow.AutoSize = true;
            this.lbl_ActiveRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ActiveRow.ForeColor = System.Drawing.Color.White;
            this.lbl_ActiveRow.Location = new System.Drawing.Point(3, 0);
            this.lbl_ActiveRow.Name = "lbl_ActiveRow";
            this.lbl_ActiveRow.Size = new System.Drawing.Size(29, 24);
            this.lbl_ActiveRow.TabIndex = 0;
            this.lbl_ActiveRow.Text = "150";
            this.lbl_ActiveRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_av
            // 
            this.label_av.AutoSize = true;
            this.label_av.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_av.ForeColor = System.Drawing.Color.White;
            this.label_av.Location = new System.Drawing.Point(38, 0);
            this.label_av.Name = "label_av";
            this.label_av.Size = new System.Drawing.Size(19, 24);
            this.label_av.TabIndex = 0;
            this.label_av.Text = "av";
            this.label_av.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalRows
            // 
            this.lbl_TotalRows.AutoSize = true;
            this.lbl_TotalRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalRows.ForeColor = System.Drawing.Color.White;
            this.lbl_TotalRows.Location = new System.Drawing.Point(63, 0);
            this.lbl_TotalRows.Name = "lbl_TotalRows";
            this.lbl_TotalRows.Size = new System.Drawing.Size(29, 24);
            this.lbl_TotalRows.TabIndex = 0;
            this.lbl_TotalRows.Text = "500";
            this.lbl_TotalRows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Processkort_Godkänt_RevInfo
            // 
            this.label_Processkort_Godkänt_RevInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Processkort_Godkänt_RevInfo.BackColor = System.Drawing.Color.White;
            this.label_Processkort_Godkänt_RevInfo.Font = new System.Drawing.Font("Arial", 9F);
            this.label_Processkort_Godkänt_RevInfo.Location = new System.Drawing.Point(0, 0);
            this.label_Processkort_Godkänt_RevInfo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Processkort_Godkänt_RevInfo.Name = "label_Processkort_Godkänt_RevInfo";
            this.label_Processkort_Godkänt_RevInfo.Size = new System.Drawing.Size(190, 19);
            this.label_Processkort_Godkänt_RevInfo.TabIndex = 845;
            this.label_Processkort_Godkänt_RevInfo.Text = "RevisionsInfo:";
            this.label_Processkort_Godkänt_RevInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_RevInfo
            // 
            this.tb_RevInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_RevInfo.BackColor = System.Drawing.Color.White;
            this.tb_RevInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_RevInfo.Font = new System.Drawing.Font("Consolas", 9F);
            this.tb_RevInfo.Location = new System.Drawing.Point(0, 20);
            this.tb_RevInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tb_RevInfo.Multiline = true;
            this.tb_RevInfo.Name = "tb_RevInfo";
            this.tb_RevInfo.Size = new System.Drawing.Size(190, 149);
            this.tb_RevInfo.TabIndex = 844;
            // 
            // label_Revision
            // 
            this.label_Revision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Revision.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_Revision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_Revision.Location = new System.Drawing.Point(1564, 400);
            this.label_Revision.Name = "label_Revision";
            this.label_Revision.Size = new System.Drawing.Size(136, 16);
            this.label_Revision.TabIndex = 846;
            this.label_Revision.Text = "Revision";
            this.label_Revision.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tb_Revision
            // 
            this.tb_Revision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Revision.Location = new System.Drawing.Point(1567, 420);
            this.tb_Revision.Name = "tb_Revision";
            this.tb_Revision.Size = new System.Drawing.Size(136, 20);
            this.tb_Revision.TabIndex = 23;
            this.tb_Revision.TextChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // chb_Invert_Revision
            // 
            this.chb_Invert_Revision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_Invert_Revision.AutoSize = true;
            this.chb_Invert_Revision.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.chb_Invert_Revision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.chb_Invert_Revision.Location = new System.Drawing.Point(1529, 423);
            this.chb_Invert_Revision.Name = "chb_Invert_Revision";
            this.chb_Invert_Revision.Size = new System.Drawing.Size(15, 14);
            this.chb_Invert_Revision.TabIndex = 24;
            this.chb_Invert_Revision.UseVisualStyleBackColor = true;
            this.chb_Invert_Revision.CheckedChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // btn_ConnectMeasureTemplate
            // 
            this.btn_ConnectMeasureTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ConnectMeasureTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_ConnectMeasureTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ConnectMeasureTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ConnectMeasureTemplate.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_ConnectMeasureTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_ConnectMeasureTemplate.Location = new System.Drawing.Point(0, 305);
            this.btn_ConnectMeasureTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ConnectMeasureTemplate.Name = "btn_ConnectMeasureTemplate";
            this.btn_ConnectMeasureTemplate.Size = new System.Drawing.Size(190, 59);
            this.btn_ConnectMeasureTemplate.TabIndex = 847;
            this.btn_ConnectMeasureTemplate.Text = "Koppla Mall för Mätprotokoll till senaste Revison av Processkort";
            this.btn_ConnectMeasureTemplate.UseVisualStyleBackColor = false;
            this.btn_ConnectMeasureTemplate.Click += new System.EventHandler(this.ConnectMeasureTemplate_Click);
            // 
            // flp_Buttons
            // 
            this.flp_Buttons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flp_Buttons.Controls.Add(this.label_Processkort_Godkänt_RevInfo);
            this.flp_Buttons.Controls.Add(this.tb_RevInfo);
            this.flp_Buttons.Controls.Add(this.btn_CreateNewRevisionProcesscard);
            this.flp_Buttons.Controls.Add(this.btn_UpdateExistingRevisionProcesscard);
            this.flp_Buttons.Controls.Add(this.btn_ConnectMeasureTemplate);
            this.flp_Buttons.Controls.Add(this.btn_CompareDataInTemplates);
            this.flp_Buttons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Buttons.Location = new System.Drawing.Point(1498, 551);
            this.flp_Buttons.Name = "flp_Buttons";
            this.flp_Buttons.Size = new System.Drawing.Size(196, 456);
            this.flp_Buttons.TabIndex = 848;
            // 
            // btn_CompareDataInTemplates
            // 
            this.btn_CompareDataInTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CompareDataInTemplates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_CompareDataInTemplates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CompareDataInTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CompareDataInTemplates.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_CompareDataInTemplates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_CompareDataInTemplates.Location = new System.Drawing.Point(0, 364);
            this.btn_CompareDataInTemplates.Margin = new System.Windows.Forms.Padding(0);
            this.btn_CompareDataInTemplates.Name = "btn_CompareDataInTemplates";
            this.btn_CompareDataInTemplates.Size = new System.Drawing.Size(190, 42);
            this.btn_CompareDataInTemplates.TabIndex = 848;
            this.btn_CompareDataInTemplates.Text = "Jämför data mellan mallar";
            this.btn_CompareDataInTemplates.UseVisualStyleBackColor = false;
            this.btn_CompareDataInTemplates.Click += new System.EventHandler(this.CompareDataInTemplates_Click);
            // 
            // Connect_Templates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1711, 1019);
            this.Controls.Add(this.flp_Buttons);
            this.Controls.Add(this.label_Revision);
            this.Controls.Add(this.panel_Left);
            this.Controls.Add(this.num_Machines);
            this.Controls.Add(this.label_Invert);
            this.Controls.Add(this.chb_Invert_Revision);
            this.Controls.Add(this.chb_Invert_ProdLine);
            this.Controls.Add(this.chb_Invert_ProdType);
            this.Controls.Add(this.chb_Invert_TemplateName);
            this.Controls.Add(this.chb_Invert_Workoperation);
            this.Controls.Add(this.chb_Invert_PartNr);
            this.Controls.Add(this.tb_Revision);
            this.Controls.Add(this.tb_ProdLine);
            this.Controls.Add(this.label_Machines);
            this.Controls.Add(this.label_ProdLine);
            this.Controls.Add(this.chb_ShowRevNr);
            this.Controls.Add(this.tb_ProdType);
            this.Controls.Add(this.tb_TemplateName);
            this.Controls.Add(this.tb_Workoperation);
            this.Controls.Add(this.tb_PartNumber);
            this.Controls.Add(this.label_ProdType);
            this.Controls.Add(this.label_TemplateName);
            this.Controls.Add(this.label_Workoperation);
            this.Controls.Add(this.label_PartNumber);
            this.Name = "Connect_Templates";
            this.Text = "PartTemplateManager";
            this.Load += new System.EventHandler(this.PartTemplateManager_Load);
            this.Shown += new System.EventHandler(this.PartTemplateManager_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PartList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Machines)).EndInit();
            this.panel_Left.ResumeLayout(false);
            this.tlp_Bottom.ResumeLayout(false);
            this.tlp_Bottom.PerformLayout();
            this.flp_Buttons.ResumeLayout(false);
            this.flp_Buttons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgv_PartList;
        private TextBox tb_Workoperation;
        private TextBox tb_PartNumber;
        private Label label_Workoperation;
        private Label label_PartNumber;
        private Label label_TemplateName;
        private TextBox tb_TemplateName;
        private Button btn_CreateNewRevisionProcesscard;
        private Label label_ProdType;
        private TextBox tb_ProdType;
        private CheckBox chb_ShowRevNr;
        private Button btn_UpdateExistingRevisionProcesscard;
        private TextBox tb_ProdLine;
        private Label label_ProdLine;
        private CheckBox chb_Invert_PartNr;
        private CheckBox chb_Invert_Workoperation;
        private CheckBox chb_Invert_TemplateName;
        private CheckBox chb_Invert_ProdType;
        private CheckBox chb_Invert_ProdLine;
        private Label label_Invert;
        private NumericUpDown num_Machines;
        private Label label_Machines;
        private Panel panel_Left;
        private TableLayoutPanel tlp_Bottom;
        private Label lbl_ActiveRow;
        private Label label_av;
        private Label lbl_TotalRows;
        private Label label_Processkort_Godkänt_RevInfo;
        public TextBox tb_RevInfo;
        private Label label_Revision;
        private TextBox tb_Revision;
        private CheckBox chb_Invert_Revision;
        private Button btn_ConnectMeasureTemplate;
        private FlowLayoutPanel flp_Buttons;
        private Button btn_CompareDataInTemplates;
    }
}