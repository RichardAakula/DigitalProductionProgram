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
            components = new Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Manage_Processcards));
            dgv_Revision = new DataGridView();
            col_RevNr = new DataGridViewTextBoxColumn();
            col_RevInfo = new DataGridViewTextBoxColumn();
            col_RevCreated = new DataGridViewTextBoxColumn();
            col_EstablishedBy = new DataGridViewTextBoxColumn();
            col_PartID = new DataGridViewTextBoxColumn();
            col_TotalOrders = new DataGridViewTextBoxColumn();
            label_List_PartNr = new Label();
            label_Inactive = new Label();
            panel_RevisionInfo = new Panel();
            panel_RevInfo_Kommentarer = new Panel();
            tlp_Bottom = new TableLayoutPanel();
            label_Processkort_Godkänt_RevInfo = new Label();
            label_ProcessCard_ExtraInfo = new Label();
            tb_RevInfo = new TextBox();
            tb_ExtraInfo = new TextBox();
            ProcesscardBasedOn = new ProcesscardBasedOn();
            tlp_Main_Processkort = new TableLayoutPanel();
            tab_Main = new TablessControl();
            tp_Kragning = new TabPage();
            Processkort_Kragning = new PC_Kragning();
            tp_Skärmning = new TabPage();
            Processcard_Skärmning = new PC_Skärmning();
            tp_Slipning = new TabPage();
            Processkort_Slipning = new PC_Slipning_TEF();
            tp_Svetsning = new TabPage();
            Processkort_Svetsning = new PC_Svetsning_TEF();
            tp_Protocol = new TabPage();
            flp_Machines = new FlowLayoutPanel();
            tlp_Processkort_Top = new TableLayoutPanel();
            label_ProductType = new Label();
            tb_NewPartNr = new TextBox();
            label_PartNumber = new Label();
            tb_ProdType = new TextBox();
            flp_Left = new FlowLayoutPanel();
            panel_PartNr = new Panel();
            cb_MeasureProtocolTemplateName = new ComboBox();
            cb_ProtocolTemplateName = new ComboBox();
            cb_TemplateRevision = new ComboBox();
            btn_ReloadPartNr = new Button();
            tb_PartNr = new TextBox();
            label_ProtocolTemplateRevision = new Label();
            label_MeasureProtocolTemplateName = new Label();
            label_ProtocolTemplateName = new Label();
            chb_HideInactive_PartNr = new CheckBox();
            pb_Info = new PictureBox();
            panel_ProductionLine = new Panel();
            label_Info_Prodline = new Label();
            tb_ProdLine = new TextBox();
            label_ProdLine = new Label();
            panel_Tips = new Panel();
            lbl_Tips_2 = new Label();
            lbl_Tips_1 = new Label();
            label_Tips = new Label();
            flp_ExtraInfo = new FlowLayoutPanel();
            panel_InfoLayers = new Panel();
            label_Info_TotalLayer = new Label();
            num_NumberOfLayers = new NumericUpDown();
            panel_Buttons = new Panel();
            btn_Info = new Button();
            btn_NewTemplate = new Button();
            btn_CopyPartNr = new Button();
            btn_ClearProcessCard = new Button();
            btn_DeActivate_PartNr = new Button();
            btn_UpdateTemplate = new Button();
            btn_LoadOldData = new Button();
            btn_Save_Processcard = new Button();
            btn_DeleteProcesscard = new Button();
            toolTip = new ToolTip(components);
            tlp_Main = new TableLayoutPanel();
            ((ISupportInitialize)dgv_Revision).BeginInit();
            panel_RevisionInfo.SuspendLayout();
            panel_RevInfo_Kommentarer.SuspendLayout();
            tlp_Bottom.SuspendLayout();
            tlp_Main_Processkort.SuspendLayout();
            tab_Main.SuspendLayout();
            tp_Kragning.SuspendLayout();
            tp_Skärmning.SuspendLayout();
            tp_Slipning.SuspendLayout();
            tp_Svetsning.SuspendLayout();
            tp_Protocol.SuspendLayout();
            tlp_Processkort_Top.SuspendLayout();
            flp_Left.SuspendLayout();
            panel_PartNr.SuspendLayout();
            ((ISupportInitialize)pb_Info).BeginInit();
            panel_ProductionLine.SuspendLayout();
            panel_Tips.SuspendLayout();
            flp_ExtraInfo.SuspendLayout();
            panel_InfoLayers.SuspendLayout();
            ((ISupportInitialize)num_NumberOfLayers).BeginInit();
            panel_Buttons.SuspendLayout();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_Revision
            // 
            dgv_Revision.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_Revision.BackgroundColor = Color.FromArgb(141, 180, 226);
            dgv_Revision.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Revision.Columns.AddRange(new DataGridViewColumn[] { col_RevNr, col_RevInfo, col_RevCreated, col_EstablishedBy, col_PartID, col_TotalOrders });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_Revision.DefaultCellStyle = dataGridViewCellStyle1;
            dgv_Revision.Dock = DockStyle.Fill;
            dgv_Revision.Location = new Point(0, 0);
            dgv_Revision.MultiSelect = false;
            dgv_Revision.Name = "dgv_Revision";
            dgv_Revision.ReadOnly = true;
            dgv_Revision.RowHeadersVisible = false;
            dgv_Revision.ScrollBars = ScrollBars.Vertical;
            dgv_Revision.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Revision.Size = new Size(700, 534);
            dgv_Revision.TabIndex = 872;
            dgv_Revision.CellClick += Revision_CellEnter;
            dgv_Revision.CellEnter += Revision_CellEnter;
            // 
            // col_RevNr
            // 
            col_RevNr.HeaderText = "RevNr:";
            col_RevNr.Name = "col_RevNr";
            col_RevNr.ReadOnly = true;
            col_RevNr.Width = 45;
            // 
            // col_RevInfo
            // 
            col_RevInfo.HeaderText = "RevisionInfo:";
            col_RevInfo.Name = "col_RevInfo";
            col_RevInfo.ReadOnly = true;
            col_RevInfo.Width = 382;
            // 
            // col_RevCreated
            // 
            col_RevCreated.HeaderText = "Revision Created:";
            col_RevCreated.Name = "col_RevCreated";
            col_RevCreated.ReadOnly = true;
            col_RevCreated.Width = 80;
            // 
            // col_EstablishedBy
            // 
            col_EstablishedBy.HeaderText = "Established By:";
            col_EstablishedBy.Name = "col_EstablishedBy";
            col_EstablishedBy.ReadOnly = true;
            col_EstablishedBy.Width = 65;
            // 
            // col_PartID
            // 
            col_PartID.HeaderText = "Part ID";
            col_PartID.Name = "col_PartID";
            col_PartID.ReadOnly = true;
            col_PartID.Visible = false;
            // 
            // col_TotalOrders
            // 
            col_TotalOrders.HeaderText = "Total Orders:";
            col_TotalOrders.Name = "col_TotalOrders";
            col_TotalOrders.ReadOnly = true;
            // 
            // label_List_PartNr
            // 
            label_List_PartNr.AutoSize = true;
            label_List_PartNr.BackColor = Color.Transparent;
            label_List_PartNr.Font = new Font("Palatino Linotype", 9.25F);
            label_List_PartNr.ForeColor = Color.Khaki;
            label_List_PartNr.Location = new Point(3, 69);
            label_List_PartNr.Margin = new Padding(3, 6, 3, 0);
            label_List_PartNr.Name = "label_List_PartNr";
            label_List_PartNr.Size = new Size(129, 18);
            label_List_PartNr.TabIndex = 840;
            label_List_PartNr.Text = "Lista med ArtikelNr";
            // 
            // label_Inactive
            // 
            label_Inactive.AutoSize = true;
            label_Inactive.BackColor = Color.Transparent;
            label_Inactive.Font = new Font("Modern No. 20", 15F);
            label_Inactive.ForeColor = Color.Red;
            label_Inactive.Location = new Point(9, 382);
            label_Inactive.Margin = new Padding(3, 0, 3, 5);
            label_Inactive.Name = "label_Inactive";
            label_Inactive.Size = new Size(70, 22);
            label_Inactive.TabIndex = 1001;
            label_Inactive.Text = "Inaktiv";
            label_Inactive.Visible = false;
            // 
            // panel_RevisionInfo
            // 
            panel_RevisionInfo.BackColor = Color.Transparent;
            panel_RevisionInfo.Controls.Add(dgv_Revision);
            panel_RevisionInfo.Controls.Add(panel_RevInfo_Kommentarer);
            panel_RevisionInfo.Location = new Point(753, 3);
            panel_RevisionInfo.MinimumSize = new Size(675, 0);
            panel_RevisionInfo.Name = "panel_RevisionInfo";
            panel_RevisionInfo.Size = new Size(700, 815);
            panel_RevisionInfo.TabIndex = 881;
            // 
            // panel_RevInfo_Kommentarer
            // 
            panel_RevInfo_Kommentarer.BorderStyle = BorderStyle.FixedSingle;
            panel_RevInfo_Kommentarer.Controls.Add(tlp_Bottom);
            panel_RevInfo_Kommentarer.Dock = DockStyle.Bottom;
            panel_RevInfo_Kommentarer.Location = new Point(0, 534);
            panel_RevInfo_Kommentarer.Name = "panel_RevInfo_Kommentarer";
            panel_RevInfo_Kommentarer.Size = new Size(700, 281);
            panel_RevInfo_Kommentarer.TabIndex = 878;
            // 
            // tlp_Bottom
            // 
            tlp_Bottom.ColumnCount = 2;
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.0679F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.9321F));
            tlp_Bottom.Controls.Add(label_Processkort_Godkänt_RevInfo, 0, 1);
            tlp_Bottom.Controls.Add(label_ProcessCard_ExtraInfo, 1, 1);
            tlp_Bottom.Controls.Add(tb_RevInfo, 0, 2);
            tlp_Bottom.Controls.Add(tb_ExtraInfo, 1, 2);
            tlp_Bottom.Controls.Add(ProcesscardBasedOn, 0, 0);
            tlp_Bottom.Dock = DockStyle.Fill;
            tlp_Bottom.Location = new Point(0, 0);
            tlp_Bottom.Name = "tlp_Bottom";
            tlp_Bottom.RowCount = 3;
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Bottom.Size = new Size(698, 279);
            tlp_Bottom.TabIndex = 0;
            // 
            // label_Processkort_Godkänt_RevInfo
            // 
            label_Processkort_Godkänt_RevInfo.BackColor = Color.White;
            label_Processkort_Godkänt_RevInfo.Dock = DockStyle.Fill;
            label_Processkort_Godkänt_RevInfo.Font = new Font("Arial", 9F);
            label_Processkort_Godkänt_RevInfo.Location = new Point(0, 90);
            label_Processkort_Godkänt_RevInfo.Margin = new Padding(0, 0, 0, 1);
            label_Processkort_Godkänt_RevInfo.Name = "label_Processkort_Godkänt_RevInfo";
            label_Processkort_Godkänt_RevInfo.Size = new Size(328, 19);
            label_Processkort_Godkänt_RevInfo.TabIndex = 843;
            label_Processkort_Godkänt_RevInfo.Text = "RevisionsInfo:";
            label_Processkort_Godkänt_RevInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_ProcessCard_ExtraInfo
            // 
            label_ProcessCard_ExtraInfo.BackColor = Color.White;
            label_ProcessCard_ExtraInfo.Dock = DockStyle.Fill;
            label_ProcessCard_ExtraInfo.Font = new Font("Arial", 9F);
            label_ProcessCard_ExtraInfo.Location = new Point(329, 90);
            label_ProcessCard_ExtraInfo.Margin = new Padding(1, 0, 0, 1);
            label_ProcessCard_ExtraInfo.Name = "label_ProcessCard_ExtraInfo";
            label_ProcessCard_ExtraInfo.Size = new Size(369, 19);
            label_ProcessCard_ExtraInfo.TabIndex = 261;
            label_ProcessCard_ExtraInfo.Text = "Extra Info åt operatörerna som endast syns i programmet:";
            label_ProcessCard_ExtraInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_RevInfo
            // 
            tb_RevInfo.BackColor = Color.White;
            tb_RevInfo.BorderStyle = BorderStyle.None;
            tb_RevInfo.Dock = DockStyle.Fill;
            tb_RevInfo.Font = new Font("Consolas", 9F);
            tb_RevInfo.Location = new Point(0, 110);
            tb_RevInfo.Margin = new Padding(0);
            tb_RevInfo.Multiline = true;
            tb_RevInfo.Name = "tb_RevInfo";
            tb_RevInfo.Size = new Size(328, 169);
            tb_RevInfo.TabIndex = 200;
            // 
            // tb_ExtraInfo
            // 
            tb_ExtraInfo.BackColor = Color.White;
            tb_ExtraInfo.BorderStyle = BorderStyle.None;
            tb_ExtraInfo.Dock = DockStyle.Fill;
            tb_ExtraInfo.Font = new Font("Consolas", 9F);
            tb_ExtraInfo.Location = new Point(329, 110);
            tb_ExtraInfo.Margin = new Padding(1, 0, 0, 0);
            tb_ExtraInfo.Multiline = true;
            tb_ExtraInfo.Name = "tb_ExtraInfo";
            tb_ExtraInfo.Size = new Size(369, 169);
            tb_ExtraInfo.TabIndex = 201;
            // 
            // ProcesscardBasedOn
            // 
            ProcesscardBasedOn.BackColor = Color.Black;
            tlp_Bottom.SetColumnSpan(ProcesscardBasedOn, 2);
            ProcesscardBasedOn.Dock = DockStyle.Fill;
            ProcesscardBasedOn.Location = new Point(0, 0);
            ProcesscardBasedOn.Margin = new Padding(0);
            ProcesscardBasedOn.Name = "ProcesscardBasedOn";
            ProcesscardBasedOn.Size = new Size(698, 90);
            ProcesscardBasedOn.TabIndex = 844;
            // 
            // tlp_Main_Processkort
            // 
            tlp_Main_Processkort.AutoScroll = true;
            tlp_Main_Processkort.ColumnCount = 1;
            tlp_Main_Processkort.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main_Processkort.Controls.Add(tab_Main, 0, 1);
            tlp_Main_Processkort.Controls.Add(tlp_Processkort_Top, 0, 0);
            tlp_Main_Processkort.Dock = DockStyle.Fill;
            tlp_Main_Processkort.Location = new Point(3, 3);
            tlp_Main_Processkort.Name = "tlp_Main_Processkort";
            tlp_Main_Processkort.RowCount = 2;
            tlp_Main_Processkort.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Main_Processkort.RowStyles.Add(new RowStyle(SizeType.Absolute, 173F));
            tlp_Main_Processkort.Size = new Size(744, 1055);
            tlp_Main_Processkort.TabIndex = 947;
            // 
            // tab_Main
            // 
            tab_Main.Controls.Add(tp_Kragning);
            tab_Main.Controls.Add(tp_Skärmning);
            tab_Main.Controls.Add(tp_Slipning);
            tab_Main.Controls.Add(tp_Svetsning);
            tab_Main.Controls.Add(tp_Protocol);
            tab_Main.Dock = DockStyle.Fill;
            tab_Main.Location = new Point(0, 25);
            tab_Main.Margin = new Padding(0);
            tab_Main.Name = "tab_Main";
            tab_Main.SelectedIndex = 0;
            tab_Main.Size = new Size(744, 1030);
            tab_Main.TabIndex = 874;
            // 
            // tp_Kragning
            // 
            tp_Kragning.BackColor = Color.FromArgb(226, 239, 218);
            tp_Kragning.Controls.Add(Processkort_Kragning);
            tp_Kragning.Location = new Point(4, 24);
            tp_Kragning.Name = "tp_Kragning";
            tp_Kragning.Padding = new Padding(3);
            tp_Kragning.Size = new Size(736, 1002);
            tp_Kragning.TabIndex = 2;
            tp_Kragning.Text = "Krag";
            // 
            // Processkort_Kragning
            // 
            Processkort_Kragning.Dock = DockStyle.Top;
            Processkort_Kragning.Location = new Point(3, 3);
            Processkort_Kragning.Margin = new Padding(4, 3, 4, 3);
            Processkort_Kragning.Name = "Processkort_Kragning";
            Processkort_Kragning.Size = new Size(730, 180);
            Processkort_Kragning.TabIndex = 0;
            // 
            // tp_Skärmning
            // 
            tp_Skärmning.BackColor = Color.SlateBlue;
            tp_Skärmning.Controls.Add(Processcard_Skärmning);
            tp_Skärmning.Location = new Point(4, 24);
            tp_Skärmning.Name = "tp_Skärmning";
            tp_Skärmning.Padding = new Padding(3);
            tp_Skärmning.Size = new Size(192, 72);
            tp_Skärmning.TabIndex = 4;
            tp_Skärmning.Text = "Skärmn";
            // 
            // Processcard_Skärmning
            // 
            Processcard_Skärmning.Location = new Point(2, 2);
            Processcard_Skärmning.Margin = new Padding(4, 3, 4, 3);
            Processcard_Skärmning.Name = "Processcard_Skärmning";
            Processcard_Skärmning.Size = new Size(304, 207);
            Processcard_Skärmning.TabIndex = 0;
            // 
            // tp_Slipning
            // 
            tp_Slipning.BackColor = Color.Maroon;
            tp_Slipning.Controls.Add(Processkort_Slipning);
            tp_Slipning.Location = new Point(4, 24);
            tp_Slipning.Name = "tp_Slipning";
            tp_Slipning.Padding = new Padding(3);
            tp_Slipning.Size = new Size(192, 72);
            tp_Slipning.TabIndex = 5;
            tp_Slipning.Text = "Slip";
            // 
            // Processkort_Slipning
            // 
            Processkort_Slipning.Location = new Point(4, 3);
            Processkort_Slipning.Margin = new Padding(4, 3, 4, 3);
            Processkort_Slipning.Name = "Processkort_Slipning";
            Processkort_Slipning.Size = new Size(423, 152);
            Processkort_Slipning.TabIndex = 0;
            // 
            // tp_Svetsning
            // 
            tp_Svetsning.BackColor = Color.Khaki;
            tp_Svetsning.Controls.Add(Processkort_Svetsning);
            tp_Svetsning.Location = new Point(4, 24);
            tp_Svetsning.Name = "tp_Svetsning";
            tp_Svetsning.Padding = new Padding(3);
            tp_Svetsning.Size = new Size(192, 72);
            tp_Svetsning.TabIndex = 6;
            tp_Svetsning.Text = "Svets";
            // 
            // Processkort_Svetsning
            // 
            Processkort_Svetsning.Dock = DockStyle.Fill;
            Processkort_Svetsning.Location = new Point(3, 3);
            Processkort_Svetsning.Margin = new Padding(0);
            Processkort_Svetsning.Name = "Processkort_Svetsning";
            Processkort_Svetsning.Size = new Size(186, 66);
            Processkort_Svetsning.TabIndex = 0;
            // 
            // tp_Protocol
            // 
            tp_Protocol.Controls.Add(flp_Machines);
            tp_Protocol.Location = new Point(4, 24);
            tp_Protocol.Name = "tp_Protocol";
            tp_Protocol.Padding = new Padding(3);
            tp_Protocol.Size = new Size(736, 1002);
            tp_Protocol.TabIndex = 20;
            tp_Protocol.Text = "Protocol";
            tp_Protocol.UseVisualStyleBackColor = true;
            // 
            // flp_Machines
            // 
            flp_Machines.AutoScroll = true;
            flp_Machines.BackColor = Color.FromArgb(25, 25, 25);
            flp_Machines.Dock = DockStyle.Fill;
            flp_Machines.Location = new Point(3, 3);
            flp_Machines.Name = "flp_Machines";
            flp_Machines.Size = new Size(730, 996);
            flp_Machines.TabIndex = 908;
            flp_Machines.WrapContents = false;
            // 
            // tlp_Processkort_Top
            // 
            tlp_Processkort_Top.ColumnCount = 4;
            tlp_Processkort_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 53F));
            tlp_Processkort_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            tlp_Processkort_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlp_Processkort_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlp_Processkort_Top.Controls.Add(label_ProductType, 2, 0);
            tlp_Processkort_Top.Controls.Add(tb_NewPartNr, 1, 0);
            tlp_Processkort_Top.Controls.Add(label_PartNumber, 0, 0);
            tlp_Processkort_Top.Controls.Add(tb_ProdType, 3, 0);
            tlp_Processkort_Top.Dock = DockStyle.Fill;
            tlp_Processkort_Top.Location = new Point(0, 0);
            tlp_Processkort_Top.Margin = new Padding(0, 0, 0, 1);
            tlp_Processkort_Top.Name = "tlp_Processkort_Top";
            tlp_Processkort_Top.RowCount = 1;
            tlp_Processkort_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Processkort_Top.Size = new Size(744, 24);
            tlp_Processkort_Top.TabIndex = 947;
            // 
            // label_ProductType
            // 
            label_ProductType.BackColor = Color.FromArgb(250, 250, 250);
            label_ProductType.Dock = DockStyle.Fill;
            label_ProductType.Font = new Font("Arial", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_ProductType.ForeColor = Color.Black;
            label_ProductType.Location = new Point(150, 0);
            label_ProductType.Margin = new Padding(1, 0, 0, 0);
            label_ProductType.Name = "label_ProductType";
            label_ProductType.Size = new Size(76, 24);
            label_ProductType.TabIndex = 876;
            label_ProductType.Text = "Produkttyp:";
            label_ProductType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_NewPartNr
            // 
            tb_NewPartNr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_NewPartNr.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_NewPartNr.BorderStyle = BorderStyle.None;
            tb_NewPartNr.CharacterCasing = CharacterCasing.Upper;
            tb_NewPartNr.Dock = DockStyle.Fill;
            tb_NewPartNr.Font = new Font("Consolas", 10F);
            tb_NewPartNr.ForeColor = Color.DodgerBlue;
            tb_NewPartNr.Location = new Point(54, 0);
            tb_NewPartNr.Margin = new Padding(1, 0, 0, 0);
            tb_NewPartNr.MaxLength = 12;
            tb_NewPartNr.Multiline = true;
            tb_NewPartNr.Name = "tb_NewPartNr";
            tb_NewPartNr.Size = new Size(95, 24);
            tb_NewPartNr.TabIndex = 875;
            tb_NewPartNr.TextChanged += ArtikelNr_TextChanged;
            tb_NewPartNr.Enter += NewPartNr_Enter;
            // 
            // label_PartNumber
            // 
            label_PartNumber.BackColor = Color.FromArgb(250, 250, 250);
            label_PartNumber.Dock = DockStyle.Fill;
            label_PartNumber.Font = new Font("Arial", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_PartNumber.ForeColor = Color.Black;
            label_PartNumber.Location = new Point(0, 0);
            label_PartNumber.Margin = new Padding(0);
            label_PartNumber.Name = "label_PartNumber";
            label_PartNumber.Size = new Size(53, 24);
            label_PartNumber.TabIndex = 100;
            label_PartNumber.Text = "ArtikelNr:";
            label_PartNumber.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_ProdType
            // 
            tb_ProdType.BorderStyle = BorderStyle.None;
            tb_ProdType.Dock = DockStyle.Fill;
            tb_ProdType.Font = new Font("Consolas", 9F);
            tb_ProdType.ForeColor = Color.DodgerBlue;
            tb_ProdType.Location = new Point(227, 0);
            tb_ProdType.Margin = new Padding(1, 0, 0, 0);
            tb_ProdType.Multiline = true;
            tb_ProdType.Name = "tb_ProdType";
            tb_ProdType.Size = new Size(517, 24);
            tb_ProdType.TabIndex = 877;
            tb_ProdType.Click += ProdType_Click;
            tb_ProdType.TextChanged += ProdType_TextChanged;
            // 
            // flp_Left
            // 
            flp_Left.BackColor = Color.White;
            flp_Left.Controls.Add(panel_PartNr);
            flp_Left.Controls.Add(panel_ProductionLine);
            flp_Left.Controls.Add(panel_Tips);
            flp_Left.Controls.Add(flp_ExtraInfo);
            flp_Left.Controls.Add(panel_Buttons);
            flp_Left.Dock = DockStyle.Left;
            flp_Left.Location = new Point(0, 0);
            flp_Left.Name = "flp_Left";
            flp_Left.Size = new Size(250, 1061);
            flp_Left.TabIndex = 945;
            // 
            // panel_PartNr
            // 
            panel_PartNr.BackColor = Color.FromArgb(25, 25, 25);
            panel_PartNr.Controls.Add(cb_MeasureProtocolTemplateName);
            panel_PartNr.Controls.Add(cb_ProtocolTemplateName);
            panel_PartNr.Controls.Add(cb_TemplateRevision);
            panel_PartNr.Controls.Add(btn_ReloadPartNr);
            panel_PartNr.Controls.Add(tb_PartNr);
            panel_PartNr.Controls.Add(label_Inactive);
            panel_PartNr.Controls.Add(label_ProtocolTemplateRevision);
            panel_PartNr.Controls.Add(label_MeasureProtocolTemplateName);
            panel_PartNr.Controls.Add(label_ProtocolTemplateName);
            panel_PartNr.Controls.Add(label_List_PartNr);
            panel_PartNr.Controls.Add(chb_HideInactive_PartNr);
            panel_PartNr.Controls.Add(pb_Info);
            panel_PartNr.Dock = DockStyle.Top;
            panel_PartNr.Location = new Point(3, 0);
            panel_PartNr.Margin = new Padding(3, 0, 0, 0);
            panel_PartNr.Name = "panel_PartNr";
            panel_PartNr.Size = new Size(245, 409);
            panel_PartNr.TabIndex = 946;
            // 
            // cb_MeasureProtocolTemplateName
            // 
            cb_MeasureProtocolTemplateName.BackColor = Color.FromArgb(25, 25, 25);
            cb_MeasureProtocolTemplateName.Font = new Font("Palatino Linotype", 9.25F);
            cb_MeasureProtocolTemplateName.ForeColor = Color.WhiteSmoke;
            cb_MeasureProtocolTemplateName.FormattingEnabled = true;
            cb_MeasureProtocolTemplateName.Location = new Point(13, 301);
            cb_MeasureProtocolTemplateName.Name = "cb_MeasureProtocolTemplateName";
            cb_MeasureProtocolTemplateName.Size = new Size(221, 25);
            cb_MeasureProtocolTemplateName.TabIndex = 1013;
            // 
            // cb_ProtocolTemplateName
            // 
            cb_ProtocolTemplateName.BackColor = Color.FromArgb(25, 25, 25);
            cb_ProtocolTemplateName.Font = new Font("Palatino Linotype", 9.25F);
            cb_ProtocolTemplateName.ForeColor = Color.WhiteSmoke;
            cb_ProtocolTemplateName.FormattingEnabled = true;
            cb_ProtocolTemplateName.Location = new Point(13, 181);
            cb_ProtocolTemplateName.Name = "cb_ProtocolTemplateName";
            cb_ProtocolTemplateName.Size = new Size(221, 25);
            cb_ProtocolTemplateName.TabIndex = 1013;
            cb_ProtocolTemplateName.SelectedIndexChanged += TemplateName_SelectedIndexChanged;
            cb_ProtocolTemplateName.SelectionChangeCommitted += TemplateName_SelectionChangeCommitted;
            // 
            // cb_TemplateRevision
            // 
            cb_TemplateRevision.BackColor = Color.FromArgb(25, 25, 25);
            cb_TemplateRevision.Font = new Font("Palatino Linotype", 9.25F);
            cb_TemplateRevision.ForeColor = Color.WhiteSmoke;
            cb_TemplateRevision.FormattingEnabled = true;
            cb_TemplateRevision.Location = new Point(13, 236);
            cb_TemplateRevision.Name = "cb_TemplateRevision";
            cb_TemplateRevision.Size = new Size(121, 25);
            cb_TemplateRevision.TabIndex = 1013;
            cb_TemplateRevision.SelectedIndexChanged += ProtocolTemplateRevision_SelectedIndexChanged;
            // 
            // btn_ReloadPartNr
            // 
            btn_ReloadPartNr.Cursor = Cursors.Hand;
            btn_ReloadPartNr.FlatAppearance.BorderColor = Color.FromArgb(0, 97, 0);
            btn_ReloadPartNr.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 97, 0);
            btn_ReloadPartNr.FlatStyle = FlatStyle.Flat;
            btn_ReloadPartNr.Font = new Font("Palatino Linotype", 10.25F);
            btn_ReloadPartNr.ForeColor = Color.FromArgb(198, 239, 206);
            btn_ReloadPartNr.Location = new Point(10, 122);
            btn_ReloadPartNr.Name = "btn_ReloadPartNr";
            btn_ReloadPartNr.Size = new Size(159, 28);
            btn_ReloadPartNr.TabIndex = 1012;
            btn_ReloadPartNr.Text = "Ladda om ArtikelNr";
            btn_ReloadPartNr.UseVisualStyleBackColor = true;
            btn_ReloadPartNr.Click += ReloadPartNr_Click;
            // 
            // tb_PartNr
            // 
            tb_PartNr.BackColor = Color.FromArgb(25, 25, 25);
            tb_PartNr.BorderStyle = BorderStyle.FixedSingle;
            tb_PartNr.Font = new Font("Palatino Linotype", 9.25F);
            tb_PartNr.ForeColor = Color.WhiteSmoke;
            tb_PartNr.Location = new Point(10, 92);
            tb_PartNr.Name = "tb_PartNr";
            tb_PartNr.Size = new Size(159, 24);
            tb_PartNr.TabIndex = 1010;
            tb_PartNr.Click += PartNr_Enter;
            tb_PartNr.TextChanged += PartNr_TextChanged;
            tb_PartNr.Enter += PartNr_Enter;
            // 
            // label_ProtocolTemplateRevision
            // 
            label_ProtocolTemplateRevision.AutoSize = true;
            label_ProtocolTemplateRevision.BackColor = Color.Transparent;
            label_ProtocolTemplateRevision.Font = new Font("Palatino Linotype", 9.25F);
            label_ProtocolTemplateRevision.ForeColor = Color.Khaki;
            label_ProtocolTemplateRevision.Location = new Point(6, 215);
            label_ProtocolTemplateRevision.Margin = new Padding(3, 6, 3, 0);
            label_ProtocolTemplateRevision.Name = "label_ProtocolTemplateRevision";
            label_ProtocolTemplateRevision.Size = new Size(209, 18);
            label_ProtocolTemplateRevision.TabIndex = 840;
            label_ProtocolTemplateRevision.Text = "Väl Revision för Protokollets Mall";
            // 
            // label_MeasureProtocolTemplateName
            // 
            label_MeasureProtocolTemplateName.AutoSize = true;
            label_MeasureProtocolTemplateName.BackColor = Color.Transparent;
            label_MeasureProtocolTemplateName.Font = new Font("Palatino Linotype", 9.25F);
            label_MeasureProtocolTemplateName.ForeColor = Color.Khaki;
            label_MeasureProtocolTemplateName.Location = new Point(4, 276);
            label_MeasureProtocolTemplateName.Name = "label_MeasureProtocolTemplateName";
            label_MeasureProtocolTemplateName.Size = new Size(176, 18);
            label_MeasureProtocolTemplateName.TabIndex = 840;
            label_MeasureProtocolTemplateName.Text = "Välj Mall för MätProtokollet";
            // 
            // label_ProtocolTemplateName
            // 
            label_ProtocolTemplateName.AutoSize = true;
            label_ProtocolTemplateName.BackColor = Color.Transparent;
            label_ProtocolTemplateName.Font = new Font("Palatino Linotype", 9.25F);
            label_ProtocolTemplateName.ForeColor = Color.Khaki;
            label_ProtocolTemplateName.Location = new Point(4, 159);
            label_ProtocolTemplateName.Margin = new Padding(3, 6, 3, 0);
            label_ProtocolTemplateName.Name = "label_ProtocolTemplateName";
            label_ProtocolTemplateName.Size = new Size(152, 18);
            label_ProtocolTemplateName.TabIndex = 840;
            label_ProtocolTemplateName.Text = "Välj Mall för Protokollet";
            // 
            // chb_HideInactive_PartNr
            // 
            chb_HideInactive_PartNr.AutoSize = true;
            chb_HideInactive_PartNr.Checked = true;
            chb_HideInactive_PartNr.CheckState = CheckState.Checked;
            chb_HideInactive_PartNr.Font = new Font("Palatino Linotype", 10.25F);
            chb_HideInactive_PartNr.ForeColor = Color.White;
            chb_HideInactive_PartNr.Location = new Point(3, 43);
            chb_HideInactive_PartNr.Name = "chb_HideInactive_PartNr";
            chb_HideInactive_PartNr.Size = new Size(166, 23);
            chb_HideInactive_PartNr.TabIndex = 842;
            chb_HideInactive_PartNr.Text = "Dölj Inaktiva Artiklar";
            chb_HideInactive_PartNr.UseVisualStyleBackColor = true;
            // 
            // pb_Info
            // 
            pb_Info.BackColor = Color.Transparent;
            pb_Info.BackgroundImage = (Image)resources.GetObject("pb_Info.BackgroundImage");
            pb_Info.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info.Cursor = Cursors.Hand;
            pb_Info.Location = new Point(3, 3);
            pb_Info.Margin = new Padding(3, 3, 100, 3);
            pb_Info.Name = "pb_Info";
            pb_Info.Size = new Size(34, 34);
            pb_Info.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Info.TabIndex = 870;
            pb_Info.TabStop = false;
            pb_Info.Click += Info_Click;
            // 
            // panel_ProductionLine
            // 
            panel_ProductionLine.BackColor = Color.FromArgb(25, 25, 25);
            panel_ProductionLine.Controls.Add(label_Info_Prodline);
            panel_ProductionLine.Controls.Add(tb_ProdLine);
            panel_ProductionLine.Controls.Add(label_ProdLine);
            panel_ProductionLine.Dock = DockStyle.Top;
            panel_ProductionLine.Location = new Point(3, 411);
            panel_ProductionLine.Margin = new Padding(3, 2, 0, 0);
            panel_ProductionLine.Name = "panel_ProductionLine";
            panel_ProductionLine.Size = new Size(245, 166);
            panel_ProductionLine.TabIndex = 1013;
            // 
            // label_Info_Prodline
            // 
            label_Info_Prodline.Dock = DockStyle.Bottom;
            label_Info_Prodline.Font = new Font("Lucida Sans", 8.25F);
            label_Info_Prodline.ForeColor = SystemColors.Info;
            label_Info_Prodline.Location = new Point(0, 58);
            label_Info_Prodline.Name = "label_Info_Prodline";
            label_Info_Prodline.Padding = new Padding(10, 0, 0, 0);
            label_Info_Prodline.Size = new Size(245, 108);
            label_Info_Prodline.TabIndex = 1008;
            label_Info_Prodline.Text = "Det är väldigt viktigt att du väljer rätt Produktionslinje här, speciellt när multipla Processkort används. \r\nProduktionslinjerna hämtas från Monitor.\r\n\r\nOm rätt linje saknas, kontakta Admin.\r\n";
            // 
            // tb_ProdLine
            // 
            tb_ProdLine.BackColor = Color.FromArgb(25, 25, 25);
            tb_ProdLine.Font = new Font("Palatino Linotype", 9.25F);
            tb_ProdLine.ForeColor = Color.WhiteSmoke;
            tb_ProdLine.Location = new Point(4, 26);
            tb_ProdLine.Margin = new Padding(8, 3, 3, 6);
            tb_ProdLine.Name = "tb_ProdLine";
            tb_ProdLine.Size = new Size(196, 24);
            tb_ProdLine.TabIndex = 1009;
            tb_ProdLine.MouseClick += ProdLine_Click;
            tb_ProdLine.TextChanged += ProdLinje_TextChanged;
            // 
            // label_ProdLine
            // 
            label_ProdLine.AutoSize = true;
            label_ProdLine.BackColor = Color.Transparent;
            label_ProdLine.Font = new Font("Palatino Linotype", 9.25F);
            label_ProdLine.ForeColor = Color.Khaki;
            label_ProdLine.Location = new Point(9, 4);
            label_ProdLine.Margin = new Padding(3, 5, 90, 5);
            label_ProdLine.Name = "label_ProdLine";
            label_ProdLine.Size = new Size(108, 18);
            label_ProdLine.TabIndex = 1003;
            label_ProdLine.Text = "Produktionslinje";
            // 
            // panel_Tips
            // 
            panel_Tips.BackColor = Color.FromArgb(25, 25, 25);
            panel_Tips.Controls.Add(lbl_Tips_2);
            panel_Tips.Controls.Add(lbl_Tips_1);
            panel_Tips.Controls.Add(label_Tips);
            panel_Tips.Dock = DockStyle.Top;
            panel_Tips.Location = new Point(3, 579);
            panel_Tips.Margin = new Padding(3, 2, 0, 0);
            panel_Tips.Name = "panel_Tips";
            panel_Tips.Size = new Size(245, 189);
            panel_Tips.TabIndex = 1011;
            panel_Tips.Visible = false;
            // 
            // lbl_Tips_2
            // 
            lbl_Tips_2.Dock = DockStyle.Bottom;
            lbl_Tips_2.Font = new Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Tips_2.ForeColor = SystemColors.Info;
            lbl_Tips_2.Location = new Point(0, 120);
            lbl_Tips_2.Margin = new Padding(3, 10, 3, 0);
            lbl_Tips_2.Name = "lbl_Tips_2";
            lbl_Tips_2.Size = new Size(245, 69);
            lbl_Tips_2.TabIndex = 2;
            lbl_Tips_2.Text = "Tips #2";
            // 
            // lbl_Tips_1
            // 
            lbl_Tips_1.Dock = DockStyle.Top;
            lbl_Tips_1.Font = new Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Tips_1.ForeColor = SystemColors.Info;
            lbl_Tips_1.Location = new Point(0, 23);
            lbl_Tips_1.Name = "lbl_Tips_1";
            lbl_Tips_1.Size = new Size(245, 92);
            lbl_Tips_1.TabIndex = 1;
            lbl_Tips_1.Text = "Tips #1";
            // 
            // label_Tips
            // 
            label_Tips.Dock = DockStyle.Top;
            label_Tips.Font = new Font("Palatino Linotype", 10.75F);
            label_Tips.ForeColor = Color.Goldenrod;
            label_Tips.Location = new Point(0, 0);
            label_Tips.Margin = new Padding(3, 0, 3, 15);
            label_Tips.Name = "label_Tips";
            label_Tips.Size = new Size(245, 23);
            label_Tips.TabIndex = 0;
            label_Tips.Text = "Tips";
            label_Tips.TextAlign = ContentAlignment.TopCenter;
            // 
            // flp_ExtraInfo
            // 
            flp_ExtraInfo.BackColor = Color.FromArgb(25, 25, 25);
            flp_ExtraInfo.Controls.Add(panel_InfoLayers);
            flp_ExtraInfo.Dock = DockStyle.Top;
            flp_ExtraInfo.Location = new Point(3, 770);
            flp_ExtraInfo.Margin = new Padding(3, 2, 3, 3);
            flp_ExtraInfo.Name = "flp_ExtraInfo";
            flp_ExtraInfo.Size = new Size(245, 116);
            flp_ExtraInfo.TabIndex = 3;
            // 
            // panel_InfoLayers
            // 
            panel_InfoLayers.Controls.Add(label_Info_TotalLayer);
            panel_InfoLayers.Controls.Add(num_NumberOfLayers);
            panel_InfoLayers.Dock = DockStyle.Top;
            panel_InfoLayers.Location = new Point(3, 3);
            panel_InfoLayers.Name = "panel_InfoLayers";
            panel_InfoLayers.Size = new Size(238, 61);
            panel_InfoLayers.TabIndex = 1013;
            // 
            // label_Info_TotalLayer
            // 
            label_Info_TotalLayer.Font = new Font("Lucida Sans", 8.25F);
            label_Info_TotalLayer.ForeColor = SystemColors.Info;
            label_Info_TotalLayer.Location = new Point(49, 3);
            label_Info_TotalLayer.Name = "label_Info_TotalLayer";
            label_Info_TotalLayer.Padding = new Padding(10, 0, 0, 0);
            label_Info_TotalLayer.Size = new Size(189, 51);
            label_Info_TotalLayer.TabIndex = 1014;
            label_Info_TotalLayer.Text = "Antal lager på slangen. Processkortet uppdateras automatiskt när du ändrar antal.";
            // 
            // num_NumberOfLayers
            // 
            num_NumberOfLayers.Font = new Font("Courier New", 14.25F);
            num_NumberOfLayers.ForeColor = Color.DarkSlateGray;
            num_NumberOfLayers.Location = new Point(4, 16);
            num_NumberOfLayers.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            num_NumberOfLayers.Name = "num_NumberOfLayers";
            num_NumberOfLayers.Size = new Size(41, 29);
            num_NumberOfLayers.TabIndex = 1013;
            num_NumberOfLayers.ValueChanged += Update_Processkort_NumberOfLayers;
            // 
            // panel_Buttons
            // 
            panel_Buttons.BackColor = Color.FromArgb(25, 25, 25);
            panel_Buttons.Controls.Add(btn_Info);
            panel_Buttons.Controls.Add(btn_NewTemplate);
            panel_Buttons.Controls.Add(btn_CopyPartNr);
            panel_Buttons.Controls.Add(btn_ClearProcessCard);
            panel_Buttons.Controls.Add(btn_DeActivate_PartNr);
            panel_Buttons.Controls.Add(btn_UpdateTemplate);
            panel_Buttons.Controls.Add(btn_LoadOldData);
            panel_Buttons.Controls.Add(btn_Save_Processcard);
            panel_Buttons.Controls.Add(btn_DeleteProcesscard);
            panel_Buttons.Dock = DockStyle.Top;
            panel_Buttons.Location = new Point(3, 891);
            panel_Buttons.Margin = new Padding(3, 2, 0, 0);
            panel_Buttons.Name = "panel_Buttons";
            panel_Buttons.Size = new Size(245, 305);
            panel_Buttons.TabIndex = 1015;
            // 
            // btn_Info
            // 
            btn_Info.Cursor = Cursors.Hand;
            btn_Info.FlatAppearance.BorderColor = Color.FromArgb(0, 97, 0);
            btn_Info.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 97, 0);
            btn_Info.FlatStyle = FlatStyle.Flat;
            btn_Info.Font = new Font("Palatino Linotype", 10.25F);
            btn_Info.ForeColor = Color.FromArgb(198, 239, 206);
            btn_Info.Location = new Point(0, 264);
            btn_Info.Name = "btn_Info";
            btn_Info.Size = new Size(241, 28);
            btn_Info.TabIndex = 1011;
            btn_Info.Text = "Info";
            btn_Info.UseVisualStyleBackColor = true;
            btn_Info.Visible = false;
            btn_Info.Click += Info_Click;
            // 
            // btn_NewTemplate
            // 
            btn_NewTemplate.Cursor = Cursors.Hand;
            btn_NewTemplate.FlatAppearance.BorderColor = Color.FromArgb(0, 97, 0);
            btn_NewTemplate.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 97, 0);
            btn_NewTemplate.FlatStyle = FlatStyle.Flat;
            btn_NewTemplate.Font = new Font("Palatino Linotype", 10.25F);
            btn_NewTemplate.ForeColor = Color.FromArgb(198, 239, 206);
            btn_NewTemplate.Location = new Point(0, 230);
            btn_NewTemplate.Name = "btn_NewTemplate";
            btn_NewTemplate.Size = new Size(241, 28);
            btn_NewTemplate.TabIndex = 1011;
            btn_NewTemplate.Text = "New Template";
            btn_NewTemplate.UseVisualStyleBackColor = true;
            btn_NewTemplate.Visible = false;
            btn_NewTemplate.Click += NewTemplate_Click;
            // 
            // btn_CopyPartNr
            // 
            btn_CopyPartNr.Cursor = Cursors.Hand;
            btn_CopyPartNr.FlatAppearance.BorderColor = Color.FromArgb(0, 97, 0);
            btn_CopyPartNr.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 97, 0);
            btn_CopyPartNr.FlatStyle = FlatStyle.Flat;
            btn_CopyPartNr.Font = new Font("Palatino Linotype", 10.25F);
            btn_CopyPartNr.ForeColor = Color.FromArgb(198, 239, 206);
            btn_CopyPartNr.Location = new Point(1, 196);
            btn_CopyPartNr.Name = "btn_CopyPartNr";
            btn_CopyPartNr.Size = new Size(241, 28);
            btn_CopyPartNr.TabIndex = 1010;
            btn_CopyPartNr.Text = "Copy PartNr";
            btn_CopyPartNr.UseVisualStyleBackColor = true;
            btn_CopyPartNr.Visible = false;
            btn_CopyPartNr.Click += CopyPartNr_Click;
            // 
            // btn_ClearProcessCard
            // 
            btn_ClearProcessCard.Cursor = Cursors.Hand;
            btn_ClearProcessCard.FlatAppearance.BorderColor = Color.FromArgb(156, 101, 0);
            btn_ClearProcessCard.FlatAppearance.MouseOverBackColor = Color.FromArgb(156, 101, 0);
            btn_ClearProcessCard.FlatStyle = FlatStyle.Flat;
            btn_ClearProcessCard.Font = new Font("Palatino Linotype", 10.25F);
            btn_ClearProcessCard.ForeColor = Color.FromArgb(255, 235, 156);
            btn_ClearProcessCard.Location = new Point(2, 64);
            btn_ClearProcessCard.Name = "btn_ClearProcessCard";
            btn_ClearProcessCard.Size = new Size(241, 28);
            btn_ClearProcessCard.TabIndex = 1009;
            btn_ClearProcessCard.Text = "Töm Processkortet";
            btn_ClearProcessCard.UseVisualStyleBackColor = true;
            btn_ClearProcessCard.Click += Töm_Processkort_Click;
            // 
            // btn_DeActivate_PartNr
            // 
            btn_DeActivate_PartNr.Cursor = Cursors.Hand;
            btn_DeActivate_PartNr.FlatAppearance.BorderColor = Color.FromArgb(255, 235, 156);
            btn_DeActivate_PartNr.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 235, 156);
            btn_DeActivate_PartNr.FlatStyle = FlatStyle.Flat;
            btn_DeActivate_PartNr.Font = new Font("Palatino Linotype", 10.25F);
            btn_DeActivate_PartNr.ForeColor = Color.FromArgb(156, 101, 0);
            btn_DeActivate_PartNr.Location = new Point(2, 33);
            btn_DeActivate_PartNr.Name = "btn_DeActivate_PartNr";
            btn_DeActivate_PartNr.Size = new Size(241, 28);
            btn_DeActivate_PartNr.TabIndex = 1009;
            btn_DeActivate_PartNr.Text = "Inaktivera Processkortet";
            btn_DeActivate_PartNr.UseVisualStyleBackColor = true;
            btn_DeActivate_PartNr.Click += Aktivera_Inaktivera_ArtikelNr_Click;
            // 
            // btn_UpdateTemplate
            // 
            btn_UpdateTemplate.Cursor = Cursors.Hand;
            btn_UpdateTemplate.FlatAppearance.BorderColor = Color.FromArgb(0, 97, 0);
            btn_UpdateTemplate.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 97, 0);
            btn_UpdateTemplate.FlatStyle = FlatStyle.Flat;
            btn_UpdateTemplate.Font = new Font("Palatino Linotype", 10.25F);
            btn_UpdateTemplate.ForeColor = Color.FromArgb(198, 239, 206);
            btn_UpdateTemplate.Location = new Point(2, 162);
            btn_UpdateTemplate.Name = "btn_UpdateTemplate";
            btn_UpdateTemplate.Size = new Size(241, 28);
            btn_UpdateTemplate.TabIndex = 1009;
            btn_UpdateTemplate.Text = "Update Template";
            btn_UpdateTemplate.UseVisualStyleBackColor = true;
            btn_UpdateTemplate.Visible = false;
            btn_UpdateTemplate.Click += UpdateTemplate_Click;
            // 
            // btn_LoadOldData
            // 
            btn_LoadOldData.Cursor = Cursors.Hand;
            btn_LoadOldData.FlatAppearance.BorderColor = Color.FromArgb(0, 97, 0);
            btn_LoadOldData.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 97, 0);
            btn_LoadOldData.FlatStyle = FlatStyle.Flat;
            btn_LoadOldData.Font = new Font("Palatino Linotype", 10.25F);
            btn_LoadOldData.ForeColor = Color.FromArgb(198, 239, 206);
            btn_LoadOldData.Location = new Point(2, 128);
            btn_LoadOldData.Name = "btn_LoadOldData";
            btn_LoadOldData.Size = new Size(241, 28);
            btn_LoadOldData.TabIndex = 1009;
            btn_LoadOldData.Text = "Load Old Data";
            btn_LoadOldData.UseVisualStyleBackColor = true;
            btn_LoadOldData.Visible = false;
            // 
            // btn_Save_Processcard
            // 
            btn_Save_Processcard.Cursor = Cursors.Hand;
            btn_Save_Processcard.FlatAppearance.BorderColor = Color.FromArgb(0, 97, 0);
            btn_Save_Processcard.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 97, 0);
            btn_Save_Processcard.FlatStyle = FlatStyle.Flat;
            btn_Save_Processcard.Font = new Font("Palatino Linotype", 10.25F);
            btn_Save_Processcard.ForeColor = Color.FromArgb(198, 239, 206);
            btn_Save_Processcard.Location = new Point(2, 2);
            btn_Save_Processcard.Name = "btn_Save_Processcard";
            btn_Save_Processcard.Size = new Size(241, 28);
            btn_Save_Processcard.TabIndex = 1009;
            btn_Save_Processcard.Text = "Spara Processkortet";
            btn_Save_Processcard.UseVisualStyleBackColor = true;
            btn_Save_Processcard.Click += Save_Click;
            // 
            // btn_DeleteProcesscard
            // 
            btn_DeleteProcesscard.Cursor = Cursors.Hand;
            btn_DeleteProcesscard.FlatAppearance.BorderColor = Color.FromArgb(255, 199, 206);
            btn_DeleteProcesscard.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 199, 206);
            btn_DeleteProcesscard.FlatStyle = FlatStyle.Flat;
            btn_DeleteProcesscard.Font = new Font("Palatino Linotype", 10.25F);
            btn_DeleteProcesscard.ForeColor = Color.FromArgb(156, 0, 6);
            btn_DeleteProcesscard.Location = new Point(2, 95);
            btn_DeleteProcesscard.Name = "btn_DeleteProcesscard";
            btn_DeleteProcesscard.Size = new Size(241, 28);
            btn_DeleteProcesscard.TabIndex = 1009;
            btn_DeleteProcesscard.Text = "Radera Processkortet";
            btn_DeleteProcesscard.UseVisualStyleBackColor = true;
            btn_DeleteProcesscard.Click += Delete_Processcard_Click;
            // 
            // toolTip
            // 
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            // 
            // tlp_Main
            // 
            tlp_Main.AutoScroll = true;
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 750F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle());
            tlp_Main.Controls.Add(panel_RevisionInfo, 1, 0);
            tlp_Main.Controls.Add(tlp_Main_Processkort, 0, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(250, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 1;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(1521, 1061);
            tlp_Main.TabIndex = 946;
            // 
            // Manage_Processcards
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(1771, 1061);
            Controls.Add(tlp_Main);
            Controls.Add(flp_Left);
            Name = "Manage_Processcards";
            StartPosition = FormStartPosition.Manual;
            Text = " ";
            WindowState = FormWindowState.Maximized;
            Activated += Skapa_Uppdatera_Processkort_Activated;
            FormClosed += Lägg_till_nytt_Processkort_FormClosed;
            Load += Manage_Processcards_Load;
            ((ISupportInitialize)dgv_Revision).EndInit();
            panel_RevisionInfo.ResumeLayout(false);
            panel_RevInfo_Kommentarer.ResumeLayout(false);
            tlp_Bottom.ResumeLayout(false);
            tlp_Bottom.PerformLayout();
            tlp_Main_Processkort.ResumeLayout(false);
            tab_Main.ResumeLayout(false);
            tp_Kragning.ResumeLayout(false);
            tp_Skärmning.ResumeLayout(false);
            tp_Slipning.ResumeLayout(false);
            tp_Svetsning.ResumeLayout(false);
            tp_Protocol.ResumeLayout(false);
            tlp_Processkort_Top.ResumeLayout(false);
            tlp_Processkort_Top.PerformLayout();
            flp_Left.ResumeLayout(false);
            panel_PartNr.ResumeLayout(false);
            panel_PartNr.PerformLayout();
            ((ISupportInitialize)pb_Info).EndInit();
            panel_ProductionLine.ResumeLayout(false);
            panel_ProductionLine.PerformLayout();
            panel_Tips.ResumeLayout(false);
            flp_ExtraInfo.ResumeLayout(false);
            panel_InfoLayers.ResumeLayout(false);
            ((ISupportInitialize)num_NumberOfLayers).EndInit();
            panel_Buttons.ResumeLayout(false);
            tlp_Main.ResumeLayout(false);
            ResumeLayout(false);

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
        private ComboBox cb_MeasureProtocolTemplateName;
        private Label label_MeasureProtocolTemplateName;
        private DataGridViewTextBoxColumn col_RevNr;
        private DataGridViewTextBoxColumn col_RevInfo;
        private DataGridViewTextBoxColumn col_RevCreated;
        private DataGridViewTextBoxColumn col_EstablishedBy;
        private DataGridViewTextBoxColumn col_PartID;
        private DataGridViewTextBoxColumn col_TotalOrders;
        private FlowLayoutPanel flp_Machines;
    }
}