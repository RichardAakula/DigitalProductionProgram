using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Protocols.Kragning_TEF;
using DigitalProductionProgram.Protocols.Skärmning_TEF;
using DigitalProductionProgram.Protocols.Slipning_TEF;
using DigitalProductionProgram.Protocols.Svetsning_TEF;

namespace DigitalProductionProgram.Processcards
{
    partial class Manage_Processcards
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manage_Processcards));
            this.dgv_Revision = new System.Windows.Forms.DataGridView();
            this.col_RevNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RevInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RevCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_EstablishedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TotalOrders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_List_PartNr = new System.Windows.Forms.Label();
            this.label_Inactive = new System.Windows.Forms.Label();
            this.panel_RevisionInfo = new System.Windows.Forms.Panel();
            this.panel_RevInfo_Kommentarer = new System.Windows.Forms.Panel();
            this.tlp_Bottom = new System.Windows.Forms.TableLayoutPanel();
            this.label_Processkort_Godkänt_RevInfo = new System.Windows.Forms.Label();
            this.label_ProcessCard_ExtraInfo = new System.Windows.Forms.Label();
            this.tb_RevInfo = new System.Windows.Forms.TextBox();
            this.tb_ExtraInfo = new System.Windows.Forms.TextBox();
            this.ProcesscardBasedOn = new DigitalProductionProgram.Processcards.ProcesscardBasedOn();
            this.tlp_Main_Processkort = new System.Windows.Forms.TableLayoutPanel();
            this.tab_Main = new DigitalProductionProgram.ControlsManagement.TablessControl();
            this.tp_Kragning = new System.Windows.Forms.TabPage();
            this.Processkort_Kragning = new DigitalProductionProgram.Protocols.Kragning_TEF.PC_Kragning();
            this.tp_Skärmning = new System.Windows.Forms.TabPage();
            this.Processcard_Skärmning = new DigitalProductionProgram.Protocols.Skärmning_TEF.PC_Skärmning();
            this.tp_Slipning = new System.Windows.Forms.TabPage();
            this.Processkort_Slipning = new DigitalProductionProgram.Protocols.Slipning_TEF.PC_Slipning_TEF();
            this.tp_Svetsning = new System.Windows.Forms.TabPage();
            this.Processkort_Svetsning = new DigitalProductionProgram.Protocols.Svetsning_TEF.PC_Svetsning_TEF();
            this.tp_Protocol = new System.Windows.Forms.TabPage();
            this.tlp_Machines = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Processkort_Top = new System.Windows.Forms.TableLayoutPanel();
            this.label_ProductType = new System.Windows.Forms.Label();
            this.tb_NewPartNr = new System.Windows.Forms.TextBox();
            this.label_PartNumber = new System.Windows.Forms.Label();
            this.tb_ProdType = new System.Windows.Forms.TextBox();
            this.flp_Left = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_PartNr = new System.Windows.Forms.Panel();
            this.cb_MeasureProtocolTemplateName = new System.Windows.Forms.ComboBox();
            this.cb_ProtocolTemplateName = new System.Windows.Forms.ComboBox();
            this.cb_TemplateRevision = new System.Windows.Forms.ComboBox();
            this.btn_ReloadPartNr = new System.Windows.Forms.Button();
            this.tb_PartNr = new System.Windows.Forms.TextBox();
            this.label_ProtocolTemplateRevision = new System.Windows.Forms.Label();
            this.label_MeasureProtocolTemplateName = new System.Windows.Forms.Label();
            this.label_ProtocolTemplateName = new System.Windows.Forms.Label();
            this.chb_HideInactive_PartNr = new System.Windows.Forms.CheckBox();
            this.pb_Info = new System.Windows.Forms.PictureBox();
            this.panel_ProductionLine = new System.Windows.Forms.Panel();
            this.label_Info_Prodline = new System.Windows.Forms.Label();
            this.tb_ProdLine = new System.Windows.Forms.TextBox();
            this.label_ProdLine = new System.Windows.Forms.Label();
            this.panel_Tips = new System.Windows.Forms.Panel();
            this.lbl_Tips_2 = new System.Windows.Forms.Label();
            this.lbl_Tips_1 = new System.Windows.Forms.Label();
            this.label_Tips = new System.Windows.Forms.Label();
            this.flp_ExtraInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_InfoLayers = new System.Windows.Forms.Panel();
            this.label_Info_TotalLayer = new System.Windows.Forms.Label();
            this.num_NumberOfLayers = new System.Windows.Forms.NumericUpDown();
            this.panel_Buttons = new System.Windows.Forms.Panel();
            this.btn_Info = new System.Windows.Forms.Button();
            this.btn_NewTemplate = new System.Windows.Forms.Button();
            this.btn_CopyPartNr = new System.Windows.Forms.Button();
            this.btn_ClearProcessCard = new System.Windows.Forms.Button();
            this.btn_DeActivate_PartNr = new System.Windows.Forms.Button();
            this.btn_UpdateTemplate = new System.Windows.Forms.Button();
            this.btn_LoadOldData = new System.Windows.Forms.Button();
            this.btn_Save_Processcard = new System.Windows.Forms.Button();
            this.btn_DeleteProcesscard = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Revision)).BeginInit();
            this.panel_RevisionInfo.SuspendLayout();
            this.panel_RevInfo_Kommentarer.SuspendLayout();
            this.tlp_Bottom.SuspendLayout();
            this.tlp_Main_Processkort.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.tp_Kragning.SuspendLayout();
            this.tp_Skärmning.SuspendLayout();
            this.tp_Slipning.SuspendLayout();
            this.tp_Svetsning.SuspendLayout();
            this.tp_Protocol.SuspendLayout();
            this.tlp_Processkort_Top.SuspendLayout();
            this.flp_Left.SuspendLayout();
            this.panel_PartNr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).BeginInit();
            this.panel_ProductionLine.SuspendLayout();
            this.panel_Tips.SuspendLayout();
            this.flp_ExtraInfo.SuspendLayout();
            this.panel_InfoLayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_NumberOfLayers)).BeginInit();
            this.panel_Buttons.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Revision
            // 
            this.dgv_Revision.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Revision.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(180)))), ((int)(((byte)(226)))));
            this.dgv_Revision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Revision.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_RevNr,
            this.col_RevInfo,
            this.col_RevCreated,
            this.col_EstablishedBy,
            this.col_PartID,
            this.col_TotalOrders});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Revision.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Revision.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_Revision.Location = new System.Drawing.Point(0, 0);
            this.dgv_Revision.MultiSelect = false;
            this.dgv_Revision.Name = "dgv_Revision";
            this.dgv_Revision.ReadOnly = true;
            this.dgv_Revision.RowHeadersVisible = false;
            this.dgv_Revision.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Revision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Revision.Size = new System.Drawing.Size(638, 353);
            this.dgv_Revision.TabIndex = 872;
            this.dgv_Revision.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Revision_CellEnter);
            this.dgv_Revision.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Revision_CellEnter);
            // 
            // col_RevNr
            // 
            this.col_RevNr.HeaderText = "RevNr:";
            this.col_RevNr.Name = "col_RevNr";
            this.col_RevNr.ReadOnly = true;
            this.col_RevNr.Width = 45;
            // 
            // col_RevInfo
            // 
            this.col_RevInfo.HeaderText = "RevisionInfo:";
            this.col_RevInfo.Name = "col_RevInfo";
            this.col_RevInfo.ReadOnly = true;
            this.col_RevInfo.Width = 382;
            // 
            // col_RevCreated
            // 
            this.col_RevCreated.HeaderText = "Revision Created:";
            this.col_RevCreated.Name = "col_RevCreated";
            this.col_RevCreated.ReadOnly = true;
            this.col_RevCreated.Width = 80;
            // 
            // col_EstablishedBy
            // 
            this.col_EstablishedBy.HeaderText = "Established By:";
            this.col_EstablishedBy.Name = "col_EstablishedBy";
            this.col_EstablishedBy.ReadOnly = true;
            this.col_EstablishedBy.Width = 65;
            // 
            // col_PartID
            // 
            this.col_PartID.HeaderText = "Part ID";
            this.col_PartID.Name = "col_PartID";
            this.col_PartID.ReadOnly = true;
            this.col_PartID.Visible = false;
            // 
            // col_TotalOrders
            // 
            this.col_TotalOrders.HeaderText = "Total Orders:";
            this.col_TotalOrders.Name = "col_TotalOrders";
            this.col_TotalOrders.ReadOnly = true;
            // 
            // label_List_PartNr
            // 
            this.label_List_PartNr.AutoSize = true;
            this.label_List_PartNr.BackColor = System.Drawing.Color.Transparent;
            this.label_List_PartNr.Font = new System.Drawing.Font("Palatino Linotype", 9.25F);
            this.label_List_PartNr.ForeColor = System.Drawing.Color.Khaki;
            this.label_List_PartNr.Location = new System.Drawing.Point(3, 69);
            this.label_List_PartNr.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label_List_PartNr.Name = "label_List_PartNr";
            this.label_List_PartNr.Size = new System.Drawing.Size(129, 18);
            this.label_List_PartNr.TabIndex = 840;
            this.label_List_PartNr.Text = "Lista med ArtikelNr";
            // 
            // label_Inactive
            // 
            this.label_Inactive.AutoSize = true;
            this.label_Inactive.BackColor = System.Drawing.Color.Transparent;
            this.label_Inactive.Font = new System.Drawing.Font("Modern No. 20", 15F);
            this.label_Inactive.ForeColor = System.Drawing.Color.Red;
            this.label_Inactive.Location = new System.Drawing.Point(9, 382);
            this.label_Inactive.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.label_Inactive.Name = "label_Inactive";
            this.label_Inactive.Size = new System.Drawing.Size(70, 22);
            this.label_Inactive.TabIndex = 1001;
            this.label_Inactive.Text = "Inaktiv";
            this.label_Inactive.Visible = false;
            // 
            // panel_RevisionInfo
            // 
            this.panel_RevisionInfo.BackColor = System.Drawing.Color.Transparent;
            this.panel_RevisionInfo.Controls.Add(this.dgv_Revision);
            this.panel_RevisionInfo.Controls.Add(this.panel_RevInfo_Kommentarer);
            this.panel_RevisionInfo.Location = new System.Drawing.Point(782, 3);
            this.panel_RevisionInfo.Name = "panel_RevisionInfo";
            this.panel_RevisionInfo.Size = new System.Drawing.Size(638, 634);
            this.panel_RevisionInfo.TabIndex = 881;
            // 
            // panel_RevInfo_Kommentarer
            // 
            this.panel_RevInfo_Kommentarer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_RevInfo_Kommentarer.Controls.Add(this.tlp_Bottom);
            this.panel_RevInfo_Kommentarer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_RevInfo_Kommentarer.Location = new System.Drawing.Point(0, 353);
            this.panel_RevInfo_Kommentarer.Name = "panel_RevInfo_Kommentarer";
            this.panel_RevInfo_Kommentarer.Size = new System.Drawing.Size(638, 281);
            this.panel_RevInfo_Kommentarer.TabIndex = 878;
            // 
            // tlp_Bottom
            // 
            this.tlp_Bottom.ColumnCount = 2;
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.0679F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.9321F));
            this.tlp_Bottom.Controls.Add(this.label_Processkort_Godkänt_RevInfo, 0, 1);
            this.tlp_Bottom.Controls.Add(this.label_ProcessCard_ExtraInfo, 1, 1);
            this.tlp_Bottom.Controls.Add(this.tb_RevInfo, 0, 2);
            this.tlp_Bottom.Controls.Add(this.tb_ExtraInfo, 1, 2);
            this.tlp_Bottom.Controls.Add(this.ProcesscardBasedOn, 0, 0);
            this.tlp_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Bottom.Location = new System.Drawing.Point(0, 0);
            this.tlp_Bottom.Name = "tlp_Bottom";
            this.tlp_Bottom.RowCount = 4;
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Bottom.Size = new System.Drawing.Size(636, 279);
            this.tlp_Bottom.TabIndex = 0;
            // 
            // label_Processkort_Godkänt_RevInfo
            // 
            this.label_Processkort_Godkänt_RevInfo.BackColor = System.Drawing.Color.White;
            this.label_Processkort_Godkänt_RevInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Processkort_Godkänt_RevInfo.Font = new System.Drawing.Font("Arial", 9F);
            this.label_Processkort_Godkänt_RevInfo.Location = new System.Drawing.Point(0, 90);
            this.label_Processkort_Godkänt_RevInfo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Processkort_Godkänt_RevInfo.Name = "label_Processkort_Godkänt_RevInfo";
            this.label_Processkort_Godkänt_RevInfo.Size = new System.Drawing.Size(299, 19);
            this.label_Processkort_Godkänt_RevInfo.TabIndex = 843;
            this.label_Processkort_Godkänt_RevInfo.Text = "RevisionsInfo:";
            this.label_Processkort_Godkänt_RevInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ProcessCard_ExtraInfo
            // 
            this.label_ProcessCard_ExtraInfo.BackColor = System.Drawing.Color.White;
            this.label_ProcessCard_ExtraInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ProcessCard_ExtraInfo.Font = new System.Drawing.Font("Arial", 9F);
            this.label_ProcessCard_ExtraInfo.Location = new System.Drawing.Point(300, 90);
            this.label_ProcessCard_ExtraInfo.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_ProcessCard_ExtraInfo.Name = "label_ProcessCard_ExtraInfo";
            this.label_ProcessCard_ExtraInfo.Size = new System.Drawing.Size(336, 19);
            this.label_ProcessCard_ExtraInfo.TabIndex = 261;
            this.label_ProcessCard_ExtraInfo.Text = "Extra Info åt operatörerna som endast syns i programmet:";
            this.label_ProcessCard_ExtraInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_RevInfo
            // 
            this.tb_RevInfo.BackColor = System.Drawing.Color.White;
            this.tb_RevInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_RevInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_RevInfo.Font = new System.Drawing.Font("Consolas", 9F);
            this.tb_RevInfo.Location = new System.Drawing.Point(0, 110);
            this.tb_RevInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tb_RevInfo.Multiline = true;
            this.tb_RevInfo.Name = "tb_RevInfo";
            this.tb_RevInfo.Size = new System.Drawing.Size(299, 149);
            this.tb_RevInfo.TabIndex = 200;
            // 
            // tb_ExtraInfo
            // 
            this.tb_ExtraInfo.BackColor = System.Drawing.Color.White;
            this.tb_ExtraInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ExtraInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ExtraInfo.Font = new System.Drawing.Font("Consolas", 9F);
            this.tb_ExtraInfo.Location = new System.Drawing.Point(300, 110);
            this.tb_ExtraInfo.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.tb_ExtraInfo.Multiline = true;
            this.tb_ExtraInfo.Name = "tb_ExtraInfo";
            this.tb_ExtraInfo.Size = new System.Drawing.Size(336, 149);
            this.tb_ExtraInfo.TabIndex = 201;
            // 
            // ProcesscardBasedOn
            // 
            this.ProcesscardBasedOn.BackColor = System.Drawing.Color.Black;
            this.tlp_Bottom.SetColumnSpan(this.ProcesscardBasedOn, 2);
            this.ProcesscardBasedOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcesscardBasedOn.Location = new System.Drawing.Point(0, 0);
            this.ProcesscardBasedOn.Margin = new System.Windows.Forms.Padding(0);
            this.ProcesscardBasedOn.Name = "ProcesscardBasedOn";
            this.ProcesscardBasedOn.Size = new System.Drawing.Size(636, 90);
            this.ProcesscardBasedOn.TabIndex = 844;
            // 
            // tlp_Main_Processkort
            // 
            this.tlp_Main_Processkort.AutoScroll = true;
            this.tlp_Main_Processkort.ColumnCount = 1;
            this.tlp_Main_Processkort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main_Processkort.Controls.Add(this.tab_Main, 0, 1);
            this.tlp_Main_Processkort.Controls.Add(this.tlp_Processkort_Top, 0, 0);
            this.tlp_Main_Processkort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main_Processkort.Location = new System.Drawing.Point(3, 3);
            this.tlp_Main_Processkort.Name = "tlp_Main_Processkort";
            this.tlp_Main_Processkort.RowCount = 2;
            this.tlp_Main_Processkort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Main_Processkort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tlp_Main_Processkort.Size = new System.Drawing.Size(773, 1055);
            this.tlp_Main_Processkort.TabIndex = 947;
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.tp_Kragning);
            this.tab_Main.Controls.Add(this.tp_Skärmning);
            this.tab_Main.Controls.Add(this.tp_Slipning);
            this.tab_Main.Controls.Add(this.tp_Svetsning);
            this.tab_Main.Controls.Add(this.tp_Protocol);
            this.tab_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Main.Location = new System.Drawing.Point(0, 25);
            this.tab_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.SelectedIndex = 0;
            this.tab_Main.Size = new System.Drawing.Size(773, 1030);
            this.tab_Main.TabIndex = 874;
            // 
            // tp_Kragning
            // 
            this.tp_Kragning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(218)))));
            this.tp_Kragning.Controls.Add(this.Processkort_Kragning);
            this.tp_Kragning.Location = new System.Drawing.Point(4, 22);
            this.tp_Kragning.Name = "tp_Kragning";
            this.tp_Kragning.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Kragning.Size = new System.Drawing.Size(765, 1004);
            this.tp_Kragning.TabIndex = 2;
            this.tp_Kragning.Text = "Krag";
            // 
            // Processkort_Kragning
            // 
            this.Processkort_Kragning.Dock = System.Windows.Forms.DockStyle.Top;
            this.Processkort_Kragning.Location = new System.Drawing.Point(3, 3);
            this.Processkort_Kragning.Name = "Processkort_Kragning";
            this.Processkort_Kragning.Size = new System.Drawing.Size(759, 180);
            this.Processkort_Kragning.TabIndex = 0;
            // 
            // tp_Skärmning
            // 
            this.tp_Skärmning.BackColor = System.Drawing.Color.SlateBlue;
            this.tp_Skärmning.Controls.Add(this.Processcard_Skärmning);
            this.tp_Skärmning.Location = new System.Drawing.Point(4, 22);
            this.tp_Skärmning.Name = "tp_Skärmning";
            this.tp_Skärmning.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Skärmning.Size = new System.Drawing.Size(192, 74);
            this.tp_Skärmning.TabIndex = 4;
            this.tp_Skärmning.Text = "Skärmn";
            // 
            // Processcard_Skärmning
            // 
            this.Processcard_Skärmning.Location = new System.Drawing.Point(2, 2);
            this.Processcard_Skärmning.Name = "Processcard_Skärmning";
            this.Processcard_Skärmning.Size = new System.Drawing.Size(304, 207);
            this.Processcard_Skärmning.TabIndex = 0;
            // 
            // tp_Slipning
            // 
            this.tp_Slipning.BackColor = System.Drawing.Color.Maroon;
            this.tp_Slipning.Controls.Add(this.Processkort_Slipning);
            this.tp_Slipning.Location = new System.Drawing.Point(4, 22);
            this.tp_Slipning.Name = "tp_Slipning";
            this.tp_Slipning.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Slipning.Size = new System.Drawing.Size(192, 74);
            this.tp_Slipning.TabIndex = 5;
            this.tp_Slipning.Text = "Slip";
            // 
            // Processkort_Slipning
            // 
            this.Processkort_Slipning.Location = new System.Drawing.Point(4, 3);
            this.Processkort_Slipning.Name = "Processkort_Slipning";
            this.Processkort_Slipning.Size = new System.Drawing.Size(423, 152);
            this.Processkort_Slipning.TabIndex = 0;
            // 
            // tp_Svetsning
            // 
            this.tp_Svetsning.BackColor = System.Drawing.Color.Khaki;
            this.tp_Svetsning.Controls.Add(this.Processkort_Svetsning);
            this.tp_Svetsning.Location = new System.Drawing.Point(4, 22);
            this.tp_Svetsning.Name = "tp_Svetsning";
            this.tp_Svetsning.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Svetsning.Size = new System.Drawing.Size(192, 74);
            this.tp_Svetsning.TabIndex = 6;
            this.tp_Svetsning.Text = "Svets";
            // 
            // Processkort_Svetsning
            // 
            this.Processkort_Svetsning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Processkort_Svetsning.Location = new System.Drawing.Point(3, 3);
            this.Processkort_Svetsning.Margin = new System.Windows.Forms.Padding(0);
            this.Processkort_Svetsning.Name = "Processkort_Svetsning";
            this.Processkort_Svetsning.Size = new System.Drawing.Size(186, 68);
            this.Processkort_Svetsning.TabIndex = 0;
            // 
            // tp_Protocol
            // 
            this.tp_Protocol.Controls.Add(this.tlp_Machines);
            this.tp_Protocol.Location = new System.Drawing.Point(4, 22);
            this.tp_Protocol.Name = "tp_Protocol";
            this.tp_Protocol.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Protocol.Size = new System.Drawing.Size(192, 74);
            this.tp_Protocol.TabIndex = 20;
            this.tp_Protocol.Text = "Protocol";
            this.tp_Protocol.UseVisualStyleBackColor = true;
            // 
            // tlp_Machines
            // 
            this.tlp_Machines.AutoScroll = true;
            this.tlp_Machines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlp_Machines.ColumnCount = 1;
            this.tlp_Machines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Machines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Machines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Machines.Location = new System.Drawing.Point(3, 3);
            this.tlp_Machines.Name = "tlp_Machines";
            this.tlp_Machines.RowCount = 1;
            this.tlp_Machines.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Machines.Size = new System.Drawing.Size(186, 68);
            this.tlp_Machines.TabIndex = 903;
            // 
            // tlp_Processkort_Top
            // 
            this.tlp_Processkort_Top.ColumnCount = 4;
            this.tlp_Processkort_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlp_Processkort_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlp_Processkort_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tlp_Processkort_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Processkort_Top.Controls.Add(this.label_ProductType, 2, 0);
            this.tlp_Processkort_Top.Controls.Add(this.tb_NewPartNr, 1, 0);
            this.tlp_Processkort_Top.Controls.Add(this.label_PartNumber, 0, 0);
            this.tlp_Processkort_Top.Controls.Add(this.tb_ProdType, 3, 0);
            this.tlp_Processkort_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Processkort_Top.Location = new System.Drawing.Point(0, 0);
            this.tlp_Processkort_Top.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tlp_Processkort_Top.Name = "tlp_Processkort_Top";
            this.tlp_Processkort_Top.RowCount = 1;
            this.tlp_Processkort_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Processkort_Top.Size = new System.Drawing.Size(773, 24);
            this.tlp_Processkort_Top.TabIndex = 947;
            // 
            // label_ProductType
            // 
            this.label_ProductType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label_ProductType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ProductType.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProductType.ForeColor = System.Drawing.Color.Black;
            this.label_ProductType.Location = new System.Drawing.Point(150, 0);
            this.label_ProductType.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_ProductType.Name = "label_ProductType";
            this.label_ProductType.Size = new System.Drawing.Size(76, 24);
            this.label_ProductType.TabIndex = 876;
            this.label_ProductType.Text = "Produkttyp:";
            this.label_ProductType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_NewPartNr
            // 
            this.tb_NewPartNr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tb_NewPartNr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tb_NewPartNr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_NewPartNr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_NewPartNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_NewPartNr.Font = new System.Drawing.Font("Consolas", 10F);
            this.tb_NewPartNr.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_NewPartNr.Location = new System.Drawing.Point(54, 0);
            this.tb_NewPartNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.tb_NewPartNr.MaxLength = 12;
            this.tb_NewPartNr.Multiline = true;
            this.tb_NewPartNr.Name = "tb_NewPartNr";
            this.tb_NewPartNr.Size = new System.Drawing.Size(95, 24);
            this.tb_NewPartNr.TabIndex = 875;
            this.tb_NewPartNr.TextChanged += new System.EventHandler(this.ArtikelNr_TextChanged);
            this.tb_NewPartNr.Enter += new System.EventHandler(this.NewPartNr_Enter);
            // 
            // label_PartNumber
            // 
            this.label_PartNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label_PartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PartNumber.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PartNumber.ForeColor = System.Drawing.Color.Black;
            this.label_PartNumber.Location = new System.Drawing.Point(0, 0);
            this.label_PartNumber.Margin = new System.Windows.Forms.Padding(0);
            this.label_PartNumber.Name = "label_PartNumber";
            this.label_PartNumber.Size = new System.Drawing.Size(53, 24);
            this.label_PartNumber.TabIndex = 100;
            this.label_PartNumber.Text = "ArtikelNr:";
            this.label_PartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_ProdType
            // 
            this.tb_ProdType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ProdType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ProdType.Font = new System.Drawing.Font("Consolas", 9F);
            this.tb_ProdType.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tb_ProdType.Location = new System.Drawing.Point(227, 0);
            this.tb_ProdType.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.tb_ProdType.Multiline = true;
            this.tb_ProdType.Name = "tb_ProdType";
            this.tb_ProdType.Size = new System.Drawing.Size(546, 24);
            this.tb_ProdType.TabIndex = 877;
            this.tb_ProdType.Click += new System.EventHandler(this.ProdType_Click);
            this.tb_ProdType.TextChanged += new System.EventHandler(this.ProdType_TextChanged);
            // 
            // flp_Left
            // 
            this.flp_Left.BackColor = System.Drawing.Color.White;
            this.flp_Left.Controls.Add(this.panel_PartNr);
            this.flp_Left.Controls.Add(this.panel_ProductionLine);
            this.flp_Left.Controls.Add(this.panel_Tips);
            this.flp_Left.Controls.Add(this.flp_ExtraInfo);
            this.flp_Left.Controls.Add(this.panel_Buttons);
            this.flp_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.flp_Left.Location = new System.Drawing.Point(0, 0);
            this.flp_Left.Name = "flp_Left";
            this.flp_Left.Size = new System.Drawing.Size(250, 1061);
            this.flp_Left.TabIndex = 945;
            // 
            // panel_PartNr
            // 
            this.panel_PartNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel_PartNr.Controls.Add(this.cb_MeasureProtocolTemplateName);
            this.panel_PartNr.Controls.Add(this.cb_ProtocolTemplateName);
            this.panel_PartNr.Controls.Add(this.cb_TemplateRevision);
            this.panel_PartNr.Controls.Add(this.btn_ReloadPartNr);
            this.panel_PartNr.Controls.Add(this.tb_PartNr);
            this.panel_PartNr.Controls.Add(this.label_Inactive);
            this.panel_PartNr.Controls.Add(this.label_ProtocolTemplateRevision);
            this.panel_PartNr.Controls.Add(this.label_MeasureProtocolTemplateName);
            this.panel_PartNr.Controls.Add(this.label_ProtocolTemplateName);
            this.panel_PartNr.Controls.Add(this.label_List_PartNr);
            this.panel_PartNr.Controls.Add(this.chb_HideInactive_PartNr);
            this.panel_PartNr.Controls.Add(this.pb_Info);
            this.panel_PartNr.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_PartNr.Location = new System.Drawing.Point(3, 0);
            this.panel_PartNr.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.panel_PartNr.Name = "panel_PartNr";
            this.panel_PartNr.Size = new System.Drawing.Size(245, 409);
            this.panel_PartNr.TabIndex = 946;
            // 
            // cb_MeasureProtocolTemplateName
            // 
            this.cb_MeasureProtocolTemplateName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cb_MeasureProtocolTemplateName.Font = new System.Drawing.Font("Palatino Linotype", 9.25F);
            this.cb_MeasureProtocolTemplateName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cb_MeasureProtocolTemplateName.FormattingEnabled = true;
            this.cb_MeasureProtocolTemplateName.Location = new System.Drawing.Point(13, 301);
            this.cb_MeasureProtocolTemplateName.Name = "cb_MeasureProtocolTemplateName";
            this.cb_MeasureProtocolTemplateName.Size = new System.Drawing.Size(221, 25);
            this.cb_MeasureProtocolTemplateName.TabIndex = 1013;
            // 
            // cb_ProtocolTemplateName
            // 
            this.cb_ProtocolTemplateName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cb_ProtocolTemplateName.Font = new System.Drawing.Font("Palatino Linotype", 9.25F);
            this.cb_ProtocolTemplateName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cb_ProtocolTemplateName.FormattingEnabled = true;
            this.cb_ProtocolTemplateName.Location = new System.Drawing.Point(13, 181);
            this.cb_ProtocolTemplateName.Name = "cb_ProtocolTemplateName";
            this.cb_ProtocolTemplateName.Size = new System.Drawing.Size(221, 25);
            this.cb_ProtocolTemplateName.TabIndex = 1013;
            this.cb_ProtocolTemplateName.SelectedIndexChanged += new System.EventHandler(this.TemplateName_SelectedIndexChanged);
            this.cb_ProtocolTemplateName.SelectionChangeCommitted += new System.EventHandler(this.TemplateName_SelectionChangeCommitted);
            // 
            // cb_TemplateRevision
            // 
            this.cb_TemplateRevision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cb_TemplateRevision.Font = new System.Drawing.Font("Palatino Linotype", 9.25F);
            this.cb_TemplateRevision.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cb_TemplateRevision.FormattingEnabled = true;
            this.cb_TemplateRevision.Location = new System.Drawing.Point(13, 236);
            this.cb_TemplateRevision.Name = "cb_TemplateRevision";
            this.cb_TemplateRevision.Size = new System.Drawing.Size(121, 25);
            this.cb_TemplateRevision.TabIndex = 1013;
            this.cb_TemplateRevision.SelectedIndexChanged += new System.EventHandler(this.ProtocolTemplateRevision_SelectedIndexChanged);
            // 
            // btn_ReloadPartNr
            // 
            this.btn_ReloadPartNr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ReloadPartNr.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_ReloadPartNr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_ReloadPartNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReloadPartNr.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.btn_ReloadPartNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_ReloadPartNr.Location = new System.Drawing.Point(10, 122);
            this.btn_ReloadPartNr.Name = "btn_ReloadPartNr";
            this.btn_ReloadPartNr.Size = new System.Drawing.Size(159, 28);
            this.btn_ReloadPartNr.TabIndex = 1012;
            this.btn_ReloadPartNr.Text = "Ladda om ArtikelNr";
            this.btn_ReloadPartNr.UseVisualStyleBackColor = true;
            this.btn_ReloadPartNr.Click += new System.EventHandler(this.ReloadPartNr_Click);
            // 
            // tb_PartNr
            // 
            this.tb_PartNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_PartNr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_PartNr.Font = new System.Drawing.Font("Palatino Linotype", 9.25F);
            this.tb_PartNr.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tb_PartNr.Location = new System.Drawing.Point(10, 92);
            this.tb_PartNr.Name = "tb_PartNr";
            this.tb_PartNr.Size = new System.Drawing.Size(159, 24);
            this.tb_PartNr.TabIndex = 1010;
            this.tb_PartNr.Click += new System.EventHandler(this.PartNr_Enter);
            this.tb_PartNr.TextChanged += new System.EventHandler(this.PartNr_TextChanged);
            this.tb_PartNr.Enter += new System.EventHandler(this.PartNr_Enter);
            // 
            // label_ProtocolTemplateRevision
            // 
            this.label_ProtocolTemplateRevision.AutoSize = true;
            this.label_ProtocolTemplateRevision.BackColor = System.Drawing.Color.Transparent;
            this.label_ProtocolTemplateRevision.Font = new System.Drawing.Font("Palatino Linotype", 9.25F);
            this.label_ProtocolTemplateRevision.ForeColor = System.Drawing.Color.Khaki;
            this.label_ProtocolTemplateRevision.Location = new System.Drawing.Point(6, 215);
            this.label_ProtocolTemplateRevision.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label_ProtocolTemplateRevision.Name = "label_ProtocolTemplateRevision";
            this.label_ProtocolTemplateRevision.Size = new System.Drawing.Size(209, 18);
            this.label_ProtocolTemplateRevision.TabIndex = 840;
            this.label_ProtocolTemplateRevision.Text = "Väl Revision för Protokollets Mall";
            // 
            // label_MeasureProtocolTemplateName
            // 
            this.label_MeasureProtocolTemplateName.AutoSize = true;
            this.label_MeasureProtocolTemplateName.BackColor = System.Drawing.Color.Transparent;
            this.label_MeasureProtocolTemplateName.Font = new System.Drawing.Font("Palatino Linotype", 9.25F);
            this.label_MeasureProtocolTemplateName.ForeColor = System.Drawing.Color.Khaki;
            this.label_MeasureProtocolTemplateName.Location = new System.Drawing.Point(4, 276);
            this.label_MeasureProtocolTemplateName.Name = "label_MeasureProtocolTemplateName";
            this.label_MeasureProtocolTemplateName.Size = new System.Drawing.Size(176, 18);
            this.label_MeasureProtocolTemplateName.TabIndex = 840;
            this.label_MeasureProtocolTemplateName.Text = "Välj Mall för MätProtokollet";
            // 
            // label_ProtocolTemplateName
            // 
            this.label_ProtocolTemplateName.AutoSize = true;
            this.label_ProtocolTemplateName.BackColor = System.Drawing.Color.Transparent;
            this.label_ProtocolTemplateName.Font = new System.Drawing.Font("Palatino Linotype", 9.25F);
            this.label_ProtocolTemplateName.ForeColor = System.Drawing.Color.Khaki;
            this.label_ProtocolTemplateName.Location = new System.Drawing.Point(4, 159);
            this.label_ProtocolTemplateName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label_ProtocolTemplateName.Name = "label_ProtocolTemplateName";
            this.label_ProtocolTemplateName.Size = new System.Drawing.Size(152, 18);
            this.label_ProtocolTemplateName.TabIndex = 840;
            this.label_ProtocolTemplateName.Text = "Välj Mall för Protokollet";
            // 
            // chb_HideInactive_PartNr
            // 
            this.chb_HideInactive_PartNr.AutoSize = true;
            this.chb_HideInactive_PartNr.Checked = true;
            this.chb_HideInactive_PartNr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_HideInactive_PartNr.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.chb_HideInactive_PartNr.ForeColor = System.Drawing.Color.White;
            this.chb_HideInactive_PartNr.Location = new System.Drawing.Point(3, 43);
            this.chb_HideInactive_PartNr.Name = "chb_HideInactive_PartNr";
            this.chb_HideInactive_PartNr.Size = new System.Drawing.Size(166, 23);
            this.chb_HideInactive_PartNr.TabIndex = 842;
            this.chb_HideInactive_PartNr.Text = "Dölj Inaktiva Artiklar";
            this.chb_HideInactive_PartNr.UseVisualStyleBackColor = true;
            // 
            // pb_Info
            // 
            this.pb_Info.BackColor = System.Drawing.Color.Transparent;
            this.pb_Info.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Info.BackgroundImage")));
            this.pb_Info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info.Location = new System.Drawing.Point(3, 3);
            this.pb_Info.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.pb_Info.Name = "pb_Info";
            this.pb_Info.Size = new System.Drawing.Size(34, 34);
            this.pb_Info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Info.TabIndex = 870;
            this.pb_Info.TabStop = false;
            this.pb_Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // panel_ProductionLine
            // 
            this.panel_ProductionLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel_ProductionLine.Controls.Add(this.label_Info_Prodline);
            this.panel_ProductionLine.Controls.Add(this.tb_ProdLine);
            this.panel_ProductionLine.Controls.Add(this.label_ProdLine);
            this.panel_ProductionLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ProductionLine.Location = new System.Drawing.Point(3, 411);
            this.panel_ProductionLine.Margin = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.panel_ProductionLine.Name = "panel_ProductionLine";
            this.panel_ProductionLine.Size = new System.Drawing.Size(245, 166);
            this.panel_ProductionLine.TabIndex = 1013;
            // 
            // label_Info_Prodline
            // 
            this.label_Info_Prodline.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_Info_Prodline.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_Info_Prodline.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Info_Prodline.Location = new System.Drawing.Point(0, 58);
            this.label_Info_Prodline.Name = "label_Info_Prodline";
            this.label_Info_Prodline.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label_Info_Prodline.Size = new System.Drawing.Size(245, 108);
            this.label_Info_Prodline.TabIndex = 1008;
            this.label_Info_Prodline.Text = "Det är väldigt viktigt att du väljer rätt Produktionslinje här, speciellt när mul" +
    "tipla Processkort används. \r\nProduktionslinjerna hämtas från Monitor.\r\n\r\nOm rätt" +
    " linje saknas, kontakta Admin.\r\n";
            // 
            // tb_ProdLine
            // 
            this.tb_ProdLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tb_ProdLine.Font = new System.Drawing.Font("Palatino Linotype", 9.25F);
            this.tb_ProdLine.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tb_ProdLine.Location = new System.Drawing.Point(4, 26);
            this.tb_ProdLine.Margin = new System.Windows.Forms.Padding(8, 3, 3, 6);
            this.tb_ProdLine.Name = "tb_ProdLine";
            this.tb_ProdLine.Size = new System.Drawing.Size(196, 24);
            this.tb_ProdLine.TabIndex = 1009;
            this.tb_ProdLine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProdLine_Click);
            this.tb_ProdLine.TextChanged += new System.EventHandler(this.ProdLinje_TextChanged);
            // 
            // label_ProdLine
            // 
            this.label_ProdLine.AutoSize = true;
            this.label_ProdLine.BackColor = System.Drawing.Color.Transparent;
            this.label_ProdLine.Font = new System.Drawing.Font("Palatino Linotype", 9.25F);
            this.label_ProdLine.ForeColor = System.Drawing.Color.Khaki;
            this.label_ProdLine.Location = new System.Drawing.Point(9, 4);
            this.label_ProdLine.Margin = new System.Windows.Forms.Padding(3, 5, 90, 5);
            this.label_ProdLine.Name = "label_ProdLine";
            this.label_ProdLine.Size = new System.Drawing.Size(108, 18);
            this.label_ProdLine.TabIndex = 1003;
            this.label_ProdLine.Text = "Produktionslinje";
            // 
            // panel_Tips
            // 
            this.panel_Tips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel_Tips.Controls.Add(this.lbl_Tips_2);
            this.panel_Tips.Controls.Add(this.lbl_Tips_1);
            this.panel_Tips.Controls.Add(this.label_Tips);
            this.panel_Tips.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Tips.Location = new System.Drawing.Point(3, 579);
            this.panel_Tips.Margin = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.panel_Tips.Name = "panel_Tips";
            this.panel_Tips.Size = new System.Drawing.Size(245, 189);
            this.panel_Tips.TabIndex = 1011;
            this.panel_Tips.Visible = false;
            // 
            // lbl_Tips_2
            // 
            this.lbl_Tips_2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_Tips_2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tips_2.ForeColor = System.Drawing.SystemColors.Info;
            this.lbl_Tips_2.Location = new System.Drawing.Point(0, 120);
            this.lbl_Tips_2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lbl_Tips_2.Name = "lbl_Tips_2";
            this.lbl_Tips_2.Size = new System.Drawing.Size(245, 69);
            this.lbl_Tips_2.TabIndex = 2;
            this.lbl_Tips_2.Text = "Tips #2";
            // 
            // lbl_Tips_1
            // 
            this.lbl_Tips_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Tips_1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tips_1.ForeColor = System.Drawing.SystemColors.Info;
            this.lbl_Tips_1.Location = new System.Drawing.Point(0, 23);
            this.lbl_Tips_1.Name = "lbl_Tips_1";
            this.lbl_Tips_1.Size = new System.Drawing.Size(245, 92);
            this.lbl_Tips_1.TabIndex = 1;
            this.lbl_Tips_1.Text = "Tips #1";
            // 
            // label_Tips
            // 
            this.label_Tips.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Tips.Font = new System.Drawing.Font("Palatino Linotype", 10.75F);
            this.label_Tips.ForeColor = System.Drawing.Color.Goldenrod;
            this.label_Tips.Location = new System.Drawing.Point(0, 0);
            this.label_Tips.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.label_Tips.Name = "label_Tips";
            this.label_Tips.Size = new System.Drawing.Size(245, 23);
            this.label_Tips.TabIndex = 0;
            this.label_Tips.Text = "Tips";
            this.label_Tips.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flp_ExtraInfo
            // 
            this.flp_ExtraInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.flp_ExtraInfo.Controls.Add(this.panel_InfoLayers);
            this.flp_ExtraInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.flp_ExtraInfo.Location = new System.Drawing.Point(3, 770);
            this.flp_ExtraInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.flp_ExtraInfo.Name = "flp_ExtraInfo";
            this.flp_ExtraInfo.Size = new System.Drawing.Size(245, 116);
            this.flp_ExtraInfo.TabIndex = 3;
            // 
            // panel_InfoLayers
            // 
            this.panel_InfoLayers.Controls.Add(this.label_Info_TotalLayer);
            this.panel_InfoLayers.Controls.Add(this.num_NumberOfLayers);
            this.panel_InfoLayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_InfoLayers.Location = new System.Drawing.Point(3, 3);
            this.panel_InfoLayers.Name = "panel_InfoLayers";
            this.panel_InfoLayers.Size = new System.Drawing.Size(238, 61);
            this.panel_InfoLayers.TabIndex = 1013;
            // 
            // label_Info_TotalLayer
            // 
            this.label_Info_TotalLayer.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_Info_TotalLayer.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Info_TotalLayer.Location = new System.Drawing.Point(49, 3);
            this.label_Info_TotalLayer.Name = "label_Info_TotalLayer";
            this.label_Info_TotalLayer.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label_Info_TotalLayer.Size = new System.Drawing.Size(189, 51);
            this.label_Info_TotalLayer.TabIndex = 1014;
            this.label_Info_TotalLayer.Text = "Antal lager på slangen. Processkortet uppdateras automatiskt när du ändrar antal." +
    "";
            // 
            // num_NumberOfLayers
            // 
            this.num_NumberOfLayers.Font = new System.Drawing.Font("Courier New", 14.25F);
            this.num_NumberOfLayers.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.num_NumberOfLayers.Location = new System.Drawing.Point(4, 16);
            this.num_NumberOfLayers.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_NumberOfLayers.Name = "num_NumberOfLayers";
            this.num_NumberOfLayers.Size = new System.Drawing.Size(41, 29);
            this.num_NumberOfLayers.TabIndex = 1013;
            this.num_NumberOfLayers.ValueChanged += new System.EventHandler(this.Update_Processkort_NumberOfLayers);
            // 
            // panel_Buttons
            // 
            this.panel_Buttons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel_Buttons.Controls.Add(this.btn_Info);
            this.panel_Buttons.Controls.Add(this.btn_NewTemplate);
            this.panel_Buttons.Controls.Add(this.btn_CopyPartNr);
            this.panel_Buttons.Controls.Add(this.btn_ClearProcessCard);
            this.panel_Buttons.Controls.Add(this.btn_DeActivate_PartNr);
            this.panel_Buttons.Controls.Add(this.btn_UpdateTemplate);
            this.panel_Buttons.Controls.Add(this.btn_LoadOldData);
            this.panel_Buttons.Controls.Add(this.btn_Save_Processcard);
            this.panel_Buttons.Controls.Add(this.btn_DeleteProcesscard);
            this.panel_Buttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Buttons.Location = new System.Drawing.Point(3, 891);
            this.panel_Buttons.Margin = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.panel_Buttons.Name = "panel_Buttons";
            this.panel_Buttons.Size = new System.Drawing.Size(245, 305);
            this.panel_Buttons.TabIndex = 1015;
            // 
            // btn_Info
            // 
            this.btn_Info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Info.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_Info.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_Info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Info.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.btn_Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_Info.Location = new System.Drawing.Point(0, 264);
            this.btn_Info.Name = "btn_Info";
            this.btn_Info.Size = new System.Drawing.Size(241, 28);
            this.btn_Info.TabIndex = 1011;
            this.btn_Info.Text = "Info";
            this.btn_Info.UseVisualStyleBackColor = true;
            this.btn_Info.Visible = false;
            this.btn_Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // btn_NewTemplate
            // 
            this.btn_NewTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NewTemplate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_NewTemplate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_NewTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewTemplate.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.btn_NewTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_NewTemplate.Location = new System.Drawing.Point(0, 230);
            this.btn_NewTemplate.Name = "btn_NewTemplate";
            this.btn_NewTemplate.Size = new System.Drawing.Size(241, 28);
            this.btn_NewTemplate.TabIndex = 1011;
            this.btn_NewTemplate.Text = "New Template";
            this.btn_NewTemplate.UseVisualStyleBackColor = true;
            this.btn_NewTemplate.Visible = false;
            this.btn_NewTemplate.Click += new System.EventHandler(this.NewTemplate_Click);
            // 
            // btn_CopyPartNr
            // 
            this.btn_CopyPartNr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CopyPartNr.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_CopyPartNr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_CopyPartNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CopyPartNr.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.btn_CopyPartNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_CopyPartNr.Location = new System.Drawing.Point(1, 196);
            this.btn_CopyPartNr.Name = "btn_CopyPartNr";
            this.btn_CopyPartNr.Size = new System.Drawing.Size(241, 28);
            this.btn_CopyPartNr.TabIndex = 1010;
            this.btn_CopyPartNr.Text = "Copy PartNr";
            this.btn_CopyPartNr.UseVisualStyleBackColor = true;
            this.btn_CopyPartNr.Visible = false;
            this.btn_CopyPartNr.Click += new System.EventHandler(this.CopyPartNr_Click);
            // 
            // btn_ClearProcessCard
            // 
            this.btn_ClearProcessCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ClearProcessCard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(101)))), ((int)(((byte)(0)))));
            this.btn_ClearProcessCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(101)))), ((int)(((byte)(0)))));
            this.btn_ClearProcessCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClearProcessCard.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.btn_ClearProcessCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.btn_ClearProcessCard.Location = new System.Drawing.Point(2, 64);
            this.btn_ClearProcessCard.Name = "btn_ClearProcessCard";
            this.btn_ClearProcessCard.Size = new System.Drawing.Size(241, 28);
            this.btn_ClearProcessCard.TabIndex = 1009;
            this.btn_ClearProcessCard.Text = "Töm Processkortet";
            this.btn_ClearProcessCard.UseVisualStyleBackColor = true;
            this.btn_ClearProcessCard.Click += new System.EventHandler(this.Töm_Processkort_Click);
            // 
            // btn_DeActivate_PartNr
            // 
            this.btn_DeActivate_PartNr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeActivate_PartNr.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.btn_DeActivate_PartNr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.btn_DeActivate_PartNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeActivate_PartNr.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.btn_DeActivate_PartNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(101)))), ((int)(((byte)(0)))));
            this.btn_DeActivate_PartNr.Location = new System.Drawing.Point(2, 33);
            this.btn_DeActivate_PartNr.Name = "btn_DeActivate_PartNr";
            this.btn_DeActivate_PartNr.Size = new System.Drawing.Size(241, 28);
            this.btn_DeActivate_PartNr.TabIndex = 1009;
            this.btn_DeActivate_PartNr.Text = "Inaktivera Processkortet";
            this.btn_DeActivate_PartNr.UseVisualStyleBackColor = true;
            this.btn_DeActivate_PartNr.Click += new System.EventHandler(this.Aktivera_Inaktivera_ArtikelNr_Click);
            // 
            // btn_UpdateTemplate
            // 
            this.btn_UpdateTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_UpdateTemplate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_UpdateTemplate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_UpdateTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UpdateTemplate.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.btn_UpdateTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_UpdateTemplate.Location = new System.Drawing.Point(2, 162);
            this.btn_UpdateTemplate.Name = "btn_UpdateTemplate";
            this.btn_UpdateTemplate.Size = new System.Drawing.Size(241, 28);
            this.btn_UpdateTemplate.TabIndex = 1009;
            this.btn_UpdateTemplate.Text = "Update Template";
            this.btn_UpdateTemplate.UseVisualStyleBackColor = true;
            this.btn_UpdateTemplate.Visible = false;
            this.btn_UpdateTemplate.Click += new System.EventHandler(this.UpdateTemplate_Click);
            // 
            // btn_LoadOldData
            // 
            this.btn_LoadOldData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_LoadOldData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_LoadOldData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_LoadOldData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LoadOldData.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.btn_LoadOldData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_LoadOldData.Location = new System.Drawing.Point(2, 128);
            this.btn_LoadOldData.Name = "btn_LoadOldData";
            this.btn_LoadOldData.Size = new System.Drawing.Size(241, 28);
            this.btn_LoadOldData.TabIndex = 1009;
            this.btn_LoadOldData.Text = "Load Old Data";
            this.btn_LoadOldData.UseVisualStyleBackColor = true;
            this.btn_LoadOldData.Visible = false;
            // 
            // btn_Save_Processcard
            // 
            this.btn_Save_Processcard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save_Processcard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_Save_Processcard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_Save_Processcard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save_Processcard.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.btn_Save_Processcard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_Save_Processcard.Location = new System.Drawing.Point(2, 2);
            this.btn_Save_Processcard.Name = "btn_Save_Processcard";
            this.btn_Save_Processcard.Size = new System.Drawing.Size(241, 28);
            this.btn_Save_Processcard.TabIndex = 1009;
            this.btn_Save_Processcard.Text = "Spara Processkortet";
            this.btn_Save_Processcard.UseVisualStyleBackColor = true;
            this.btn_Save_Processcard.Click += new System.EventHandler(this.Save_Click);
            // 
            // btn_DeleteProcesscard
            // 
            this.btn_DeleteProcesscard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteProcesscard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_DeleteProcesscard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_DeleteProcesscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteProcesscard.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.btn_DeleteProcesscard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_DeleteProcesscard.Location = new System.Drawing.Point(2, 95);
            this.btn_DeleteProcesscard.Name = "btn_DeleteProcesscard";
            this.btn_DeleteProcesscard.Size = new System.Drawing.Size(241, 28);
            this.btn_DeleteProcesscard.TabIndex = 1009;
            this.btn_DeleteProcesscard.Text = "Radera Processkortet";
            this.btn_DeleteProcesscard.UseVisualStyleBackColor = true;
            this.btn_DeleteProcesscard.Click += new System.EventHandler(this.Delete_Processcard_Click);
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 779F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.panel_RevisionInfo, 1, 0);
            this.tlp_Main.Controls.Add(this.tlp_Main_Processkort, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(250, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 1;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(1446, 1061);
            this.tlp_Main.TabIndex = 946;
            // 
            // Manage_Processcards
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1696, 1061);
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.flp_Left);
            this.Name = "Manage_Processcards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Skapa_Uppdatera_Processkort_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Lägg_till_nytt_Processkort_FormClosed);
            this.Load += new System.EventHandler(this.Manage_Processcards_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Revision)).EndInit();
            this.panel_RevisionInfo.ResumeLayout(false);
            this.panel_RevInfo_Kommentarer.ResumeLayout(false);
            this.tlp_Bottom.ResumeLayout(false);
            this.tlp_Bottom.PerformLayout();
            this.tlp_Main_Processkort.ResumeLayout(false);
            this.tab_Main.ResumeLayout(false);
            this.tp_Kragning.ResumeLayout(false);
            this.tp_Skärmning.ResumeLayout(false);
            this.tp_Slipning.ResumeLayout(false);
            this.tp_Svetsning.ResumeLayout(false);
            this.tp_Protocol.ResumeLayout(false);
            this.tlp_Processkort_Top.ResumeLayout(false);
            this.tlp_Processkort_Top.PerformLayout();
            this.flp_Left.ResumeLayout(false);
            this.panel_PartNr.ResumeLayout(false);
            this.panel_PartNr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).EndInit();
            this.panel_ProductionLine.ResumeLayout(false);
            this.panel_ProductionLine.PerformLayout();
            this.panel_Tips.ResumeLayout(false);
            this.flp_ExtraInfo.ResumeLayout(false);
            this.panel_InfoLayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_NumberOfLayers)).EndInit();
            this.panel_Buttons.ResumeLayout(false);
            this.tlp_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label label_List_PartNr;
        private Panel panel_RevisionInfo;
        private Panel panel_RevInfo_Kommentarer;
        private TableLayoutPanel tlp_Bottom;
        private Label label_Processkort_Godkänt_RevInfo;
        private Label label_ProcessCard_ExtraInfo;
        private Label label_Inactive;
        private FlowLayoutPanel flp_Left;
        private ToolTip toolTip;
        public CheckBox chb_HideInactive_PartNr;
        public TextBox tb_RevInfo;
        public TextBox tb_ExtraInfo;
        private PictureBox pb_Info;
        private Label label_ProdLine;
        public TextBox tb_ProdLine;
        private Label label_Info_Prodline;
        public ProcesscardBasedOn ProcesscardBasedOn;
        private Label label_Tips;
        private Label lbl_Tips_1;
        private Label lbl_Tips_2;
        public DataGridView dgv_Revision;
        private Panel panel_PartNr;
        private Panel panel_ProductionLine;
        private Panel panel_Tips;
        private Panel panel_Buttons;
        private Label label_Info_TotalLayer;
        private NumericUpDown num_NumberOfLayers;
        public Button btn_DeleteProcesscard;
        public Button btn_DeActivate_PartNr;
        public Button btn_Save_Processcard;
        public Button btn_ClearProcessCard;
        private FlowLayoutPanel flp_ExtraInfo;
        private Panel panel_InfoLayers;
        public TextBox tb_PartNr;
        public Button btn_LoadOldData;
        public Button btn_UpdateTemplate;
        public Button btn_CopyPartNr;
        private TableLayoutPanel tlp_Main_Processkort;
        private TableLayoutPanel tlp_Processkort_Top;
        private Label label_ProductType;
        public TextBox tb_NewPartNr;
        private Label label_PartNumber;
        public TextBox tb_ProdType;
        private TableLayoutPanel tlp_Main;
        private TablessControl tab_Main;
        private TabPage tp_Kragning;
        private PC_Kragning Processkort_Kragning;
        private TabPage tp_Skärmning;
        private PC_Skärmning Processcard_Skärmning;
        private TabPage tp_Slipning;
        private PC_Slipning_TEF Processkort_Slipning;
        private TabPage tp_Svetsning;
        private PC_Svetsning_TEF Processkort_Svetsning;
        private TabPage tp_Protocol;
        public Button btn_ReloadPartNr;
        private Label label_ProtocolTemplateName;
        private ComboBox cb_TemplateRevision;
        public Button btn_NewTemplate;
        public Button btn_Info;
        private ComboBox cb_ProtocolTemplateName;
        private Label label_ProtocolTemplateRevision;
        private TableLayoutPanel tlp_Machines;
        private ComboBox cb_MeasureProtocolTemplateName;
        private Label label_MeasureProtocolTemplateName;
        private DataGridViewTextBoxColumn col_RevNr;
        private DataGridViewTextBoxColumn col_RevInfo;
        private DataGridViewTextBoxColumn col_RevCreated;
        private DataGridViewTextBoxColumn col_EstablishedBy;
        private DataGridViewTextBoxColumn col_PartID;
        private DataGridViewTextBoxColumn col_TotalOrders;
    }
}