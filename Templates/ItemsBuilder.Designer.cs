namespace DigitalProductionProgram.Templates
{
    partial class ItemsBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            tlp_Main = new TableLayoutPanel();
            btn_SaveItems = new Button();
            tab_Main = new TabControl();
            page_OwnLists = new TabPage();
            tlp_OwnLists = new TableLayoutPanel();
            label_Info_OwnItems = new Label();
            gbx_AvailableOptions = new GroupBox();
            dgv_ListItems = new DataGridView();
            col_ListItems = new DataGridViewTextBoxColumn();
            tb_AddNewItem = new TextBox();
            btn_AddItem = new Button();
            gbx_ChosenItems = new GroupBox();
            dgv_Items = new DataGridView();
            col_ID = new DataGridViewTextBoxColumn();
            col_Items = new DataGridViewTextBoxColumn();
            btn_DeleteItem = new Button();
            page_MonitorLists = new TabPage();
            tlp_MonitorLists = new TableLayoutPanel();
            gbx_MonitorPartCode = new GroupBox();
            cb_PartCode = new ComboBox();
            gbx_Filter = new GroupBox();
            tb_FilterText = new TextBox();
            label_FilterText = new Label();
            cb_FilterCodeText = new ComboBox();
            label_FilterColumn = new Label();
            cb_FilterFunctions = new ComboBox();
            label_Filter = new Label();
            gbx_MonitorAPI = new GroupBox();
            cb_Identifier = new ComboBox();
            label_Column = new Label();
            cb_Properties = new ComboBox();
            label_Property = new Label();
            cb_Module = new ComboBox();
            label_Module = new Label();
            label_ListMonitor = new Label();
            page_DPP_Lists = new TabPage();
            label_CodeText = new Label();
            tlp_Main.SuspendLayout();
            tab_Main.SuspendLayout();
            page_OwnLists.SuspendLayout();
            tlp_OwnLists.SuspendLayout();
            gbx_AvailableOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ListItems).BeginInit();
            gbx_ChosenItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Items).BeginInit();
            page_MonitorLists.SuspendLayout();
            tlp_MonitorLists.SuspendLayout();
            gbx_MonitorPartCode.SuspendLayout();
            gbx_Filter.SuspendLayout();
            gbx_MonitorAPI.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 223F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 169F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlp_Main.Controls.Add(btn_SaveItems, 0, 0);
            tlp_Main.Controls.Add(tab_Main, 0, 1);
            tlp_Main.Controls.Add(label_CodeText, 1, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Main.Size = new Size(1299, 942);
            tlp_Main.TabIndex = 0;
            // 
            // btn_SaveItems
            // 
            btn_SaveItems.BackColor = Color.FromArgb(185, 188, 189);
            btn_SaveItems.Cursor = Cursors.Hand;
            btn_SaveItems.Dock = DockStyle.Top;
            btn_SaveItems.FlatStyle = FlatStyle.Flat;
            btn_SaveItems.Font = new Font("Lucida Sans", 10.25F);
            btn_SaveItems.ForeColor = Color.FromArgb(63, 116, 140);
            btn_SaveItems.Location = new Point(4, 3);
            btn_SaveItems.Margin = new Padding(4, 3, 4, 0);
            btn_SaveItems.Name = "btn_SaveItems";
            btn_SaveItems.Size = new Size(215, 35);
            btn_SaveItems.TabIndex = 26;
            btn_SaveItems.Text = "Spara och Avsluta";
            btn_SaveItems.UseVisualStyleBackColor = false;
            btn_SaveItems.Click += Close_Click;
            // 
            // tab_Main
            // 
            tlp_Main.SetColumnSpan(tab_Main, 2);
            tab_Main.Controls.Add(page_OwnLists);
            tab_Main.Controls.Add(page_MonitorLists);
            tab_Main.Controls.Add(page_DPP_Lists);
            tab_Main.Dock = DockStyle.Fill;
            tab_Main.Location = new Point(3, 58);
            tab_Main.Name = "tab_Main";
            tab_Main.SelectedIndex = 0;
            tab_Main.Size = new Size(1293, 881);
            tab_Main.SizeMode = TabSizeMode.FillToRight;
            tab_Main.TabIndex = 33;
            // 
            // page_OwnLists
            // 
            page_OwnLists.Controls.Add(tlp_OwnLists);
            page_OwnLists.Font = new Font("Segoe UI", 15F);
            page_OwnLists.ForeColor = Color.FromArgb(184, 220, 231);
            page_OwnLists.Location = new Point(4, 24);
            page_OwnLists.Name = "page_OwnLists";
            page_OwnLists.Padding = new Padding(3);
            page_OwnLists.Size = new Size(1285, 853);
            page_OwnLists.TabIndex = 0;
            page_OwnLists.Text = "Egna Listor";
            page_OwnLists.UseVisualStyleBackColor = true;
            // 
            // tlp_OwnLists
            // 
            tlp_OwnLists.BackColor = Color.FromArgb(6, 81, 87);
            tlp_OwnLists.ColumnCount = 3;
            tlp_OwnLists.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 262F));
            tlp_OwnLists.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 227F));
            tlp_OwnLists.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            tlp_OwnLists.Controls.Add(label_Info_OwnItems, 0, 0);
            tlp_OwnLists.Controls.Add(gbx_AvailableOptions, 0, 1);
            tlp_OwnLists.Controls.Add(gbx_ChosenItems, 1, 1);
            tlp_OwnLists.Dock = DockStyle.Fill;
            tlp_OwnLists.Location = new Point(3, 3);
            tlp_OwnLists.Name = "tlp_OwnLists";
            tlp_OwnLists.RowCount = 2;
            tlp_OwnLists.RowStyles.Add(new RowStyle(SizeType.Percent, 4.202719F));
            tlp_OwnLists.RowStyles.Add(new RowStyle(SizeType.Percent, 95.79728F));
            tlp_OwnLists.Size = new Size(1279, 847);
            tlp_OwnLists.TabIndex = 0;
            // 
            // label_Info_OwnItems
            // 
            label_Info_OwnItems.AutoSize = true;
            tlp_OwnLists.SetColumnSpan(label_Info_OwnItems, 2);
            label_Info_OwnItems.Dock = DockStyle.Fill;
            label_Info_OwnItems.Font = new Font("Segoe UI", 15F);
            label_Info_OwnItems.ForeColor = Color.FromArgb(184, 220, 231);
            label_Info_OwnItems.Location = new Point(3, 0);
            label_Info_OwnItems.Name = "label_Info_OwnItems";
            label_Info_OwnItems.Size = new Size(483, 35);
            label_Info_OwnItems.TabIndex = 29;
            label_Info_OwnItems.Text = "Egna Listor";
            label_Info_OwnItems.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbx_AvailableOptions
            // 
            gbx_AvailableOptions.Controls.Add(dgv_ListItems);
            gbx_AvailableOptions.Controls.Add(tb_AddNewItem);
            gbx_AvailableOptions.Controls.Add(btn_AddItem);
            gbx_AvailableOptions.Dock = DockStyle.Fill;
            gbx_AvailableOptions.Font = new Font("Lucida Sans", 10.25F);
            gbx_AvailableOptions.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_AvailableOptions.Location = new Point(2, 40);
            gbx_AvailableOptions.Margin = new Padding(2, 5, 0, 0);
            gbx_AvailableOptions.Name = "gbx_AvailableOptions";
            gbx_AvailableOptions.Padding = new Padding(4, 3, 4, 3);
            gbx_AvailableOptions.Size = new Size(260, 807);
            gbx_AvailableOptions.TabIndex = 22;
            gbx_AvailableOptions.TabStop = false;
            gbx_AvailableOptions.Text = "Tillgängliga Alternativ";
            // 
            // dgv_ListItems
            // 
            dgv_ListItems.AllowUserToAddRows = false;
            dgv_ListItems.AllowUserToDeleteRows = false;
            dgv_ListItems.AllowUserToResizeColumns = false;
            dgv_ListItems.AllowUserToResizeRows = false;
            dgv_ListItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_ListItems.BackgroundColor = Color.FromArgb(81, 85, 92);
            dgv_ListItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ListItems.ColumnHeadersVisible = false;
            dgv_ListItems.Columns.AddRange(new DataGridViewColumn[] { col_ListItems });
            dgv_ListItems.Dock = DockStyle.Fill;
            dgv_ListItems.Location = new Point(4, 72);
            dgv_ListItems.Margin = new Padding(0);
            dgv_ListItems.MultiSelect = false;
            dgv_ListItems.Name = "dgv_ListItems";
            dgv_ListItems.ReadOnly = true;
            dgv_ListItems.RowHeadersVisible = false;
            dgv_ListItems.Size = new Size(252, 732);
            dgv_ListItems.TabIndex = 3;
            dgv_ListItems.CellMouseDown += ItemList_CellMouseDown;
            // 
            // col_ListItems
            // 
            dataGridViewCellStyle4.ForeColor = Color.Black;
            col_ListItems.DefaultCellStyle = dataGridViewCellStyle4;
            col_ListItems.HeaderText = "Items";
            col_ListItems.Name = "col_ListItems";
            col_ListItems.ReadOnly = true;
            col_ListItems.Width = 5;
            // 
            // tb_AddNewItem
            // 
            tb_AddNewItem.Dock = DockStyle.Top;
            tb_AddNewItem.Font = new Font("Lucida Sans", 8.25F);
            tb_AddNewItem.Location = new Point(4, 52);
            tb_AddNewItem.Margin = new Padding(4, 3, 4, 3);
            tb_AddNewItem.Name = "tb_AddNewItem";
            tb_AddNewItem.Size = new Size(252, 20);
            tb_AddNewItem.TabIndex = 3;
            // 
            // btn_AddItem
            // 
            btn_AddItem.BackColor = Color.FromArgb(185, 188, 189);
            btn_AddItem.Cursor = Cursors.Hand;
            btn_AddItem.Dock = DockStyle.Top;
            btn_AddItem.FlatStyle = FlatStyle.Flat;
            btn_AddItem.Font = new Font("Lucida Sans", 10.25F);
            btn_AddItem.ForeColor = Color.FromArgb(63, 116, 140);
            btn_AddItem.Location = new Point(4, 20);
            btn_AddItem.Margin = new Padding(0);
            btn_AddItem.Name = "btn_AddItem";
            btn_AddItem.Size = new Size(252, 32);
            btn_AddItem.TabIndex = 11;
            btn_AddItem.Text = "Lägg till text";
            btn_AddItem.UseVisualStyleBackColor = false;
            btn_AddItem.Click += NewItem_Click;
            // 
            // gbx_ChosenItems
            // 
            gbx_ChosenItems.Controls.Add(dgv_Items);
            gbx_ChosenItems.Controls.Add(btn_DeleteItem);
            gbx_ChosenItems.Dock = DockStyle.Fill;
            gbx_ChosenItems.Font = new Font("Lucida Sans", 10.25F);
            gbx_ChosenItems.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_ChosenItems.Location = new Point(264, 40);
            gbx_ChosenItems.Margin = new Padding(2, 5, 0, 0);
            gbx_ChosenItems.Name = "gbx_ChosenItems";
            gbx_ChosenItems.Size = new Size(225, 807);
            gbx_ChosenItems.TabIndex = 27;
            gbx_ChosenItems.TabStop = false;
            gbx_ChosenItems.Text = "Valda Alternativ";
            // 
            // dgv_Items
            // 
            dgv_Items.AllowUserToAddRows = false;
            dgv_Items.AllowUserToResizeColumns = false;
            dgv_Items.AllowUserToResizeRows = false;
            dgv_Items.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(6, 81, 87);
            dataGridViewCellStyle5.Font = new Font("Lucida Sans", 10.25F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(255, 235, 156);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgv_Items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgv_Items.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Items.ColumnHeadersVisible = false;
            dgv_Items.Columns.AddRange(new DataGridViewColumn[] { col_ID, col_Items });
            dgv_Items.Dock = DockStyle.Fill;
            dgv_Items.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv_Items.EnableHeadersVisualStyles = false;
            dgv_Items.Location = new Point(3, 52);
            dgv_Items.Margin = new Padding(0);
            dgv_Items.Name = "dgv_Items";
            dgv_Items.RowHeadersVisible = false;
            dgv_Items.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Items.Size = new Size(219, 752);
            dgv_Items.TabIndex = 25;
            // 
            // col_ID
            // 
            col_ID.HeaderText = "ID";
            col_ID.Name = "col_ID";
            col_ID.Visible = false;
            // 
            // col_Items
            // 
            col_Items.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.ForeColor = Color.Black;
            col_Items.DefaultCellStyle = dataGridViewCellStyle6;
            col_Items.HeaderText = "Items";
            col_Items.Name = "col_Items";
            col_Items.ReadOnly = true;
            // 
            // btn_DeleteItem
            // 
            btn_DeleteItem.BackColor = Color.FromArgb(185, 188, 189);
            btn_DeleteItem.Cursor = Cursors.Hand;
            btn_DeleteItem.Dock = DockStyle.Top;
            btn_DeleteItem.FlatStyle = FlatStyle.Flat;
            btn_DeleteItem.Font = new Font("Lucida Sans", 10.25F);
            btn_DeleteItem.ForeColor = Color.FromArgb(63, 116, 140);
            btn_DeleteItem.Location = new Point(3, 20);
            btn_DeleteItem.Margin = new Padding(0);
            btn_DeleteItem.Name = "btn_DeleteItem";
            btn_DeleteItem.Size = new Size(219, 32);
            btn_DeleteItem.TabIndex = 26;
            btn_DeleteItem.Text = "Radera markerat Alternativ";
            btn_DeleteItem.UseVisualStyleBackColor = false;
            btn_DeleteItem.Click += DeleteItem_Click;
            // 
            // page_MonitorLists
            // 
            page_MonitorLists.Controls.Add(tlp_MonitorLists);
            page_MonitorLists.Location = new Point(4, 24);
            page_MonitorLists.Name = "page_MonitorLists";
            page_MonitorLists.Padding = new Padding(3);
            page_MonitorLists.Size = new Size(1285, 853);
            page_MonitorLists.TabIndex = 1;
            page_MonitorLists.Text = "Monitor Listor";
            page_MonitorLists.UseVisualStyleBackColor = true;
            // 
            // tlp_MonitorLists
            // 
            tlp_MonitorLists.BackColor = Color.FromArgb(6, 81, 87);
            tlp_MonitorLists.ColumnCount = 4;
            tlp_MonitorLists.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 202F));
            tlp_MonitorLists.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 213F));
            tlp_MonitorLists.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 201F));
            tlp_MonitorLists.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            tlp_MonitorLists.Controls.Add(gbx_MonitorPartCode, 0, 1);
            tlp_MonitorLists.Controls.Add(gbx_Filter, 2, 1);
            tlp_MonitorLists.Controls.Add(gbx_MonitorAPI, 1, 1);
            tlp_MonitorLists.Controls.Add(label_ListMonitor, 0, 0);
            tlp_MonitorLists.Dock = DockStyle.Fill;
            tlp_MonitorLists.Location = new Point(3, 3);
            tlp_MonitorLists.Name = "tlp_MonitorLists";
            tlp_MonitorLists.RowCount = 2;
            tlp_MonitorLists.RowStyles.Add(new RowStyle(SizeType.Percent, 4.82076645F));
            tlp_MonitorLists.RowStyles.Add(new RowStyle(SizeType.Percent, 95.17924F));
            tlp_MonitorLists.Size = new Size(1279, 847);
            tlp_MonitorLists.TabIndex = 0;
            // 
            // gbx_MonitorPartCode
            // 
            gbx_MonitorPartCode.Controls.Add(cb_PartCode);
            gbx_MonitorPartCode.Dock = DockStyle.Fill;
            gbx_MonitorPartCode.Font = new Font("Lucida Sans", 10.25F);
            gbx_MonitorPartCode.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_MonitorPartCode.Location = new Point(2, 45);
            gbx_MonitorPartCode.Margin = new Padding(2, 5, 0, 0);
            gbx_MonitorPartCode.Name = "gbx_MonitorPartCode";
            gbx_MonitorPartCode.Size = new Size(200, 802);
            gbx_MonitorPartCode.TabIndex = 31;
            gbx_MonitorPartCode.TabStop = false;
            gbx_MonitorPartCode.Text = "Välj Typ";
            // 
            // cb_PartCode
            // 
            cb_PartCode.Dock = DockStyle.Top;
            cb_PartCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_PartCode.FormattingEnabled = true;
            cb_PartCode.Location = new Point(3, 20);
            cb_PartCode.Name = "cb_PartCode";
            cb_PartCode.Size = new Size(194, 24);
            cb_PartCode.TabIndex = 28;
            // 
            // gbx_Filter
            // 
            gbx_Filter.Controls.Add(tb_FilterText);
            gbx_Filter.Controls.Add(label_FilterText);
            gbx_Filter.Controls.Add(cb_FilterCodeText);
            gbx_Filter.Controls.Add(label_FilterColumn);
            gbx_Filter.Controls.Add(cb_FilterFunctions);
            gbx_Filter.Controls.Add(label_Filter);
            gbx_Filter.Dock = DockStyle.Fill;
            gbx_Filter.Font = new Font("Lucida Sans", 10.25F);
            gbx_Filter.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_Filter.Location = new Point(417, 45);
            gbx_Filter.Margin = new Padding(2, 5, 0, 0);
            gbx_Filter.Name = "gbx_Filter";
            gbx_Filter.Size = new Size(199, 802);
            gbx_Filter.TabIndex = 32;
            gbx_Filter.TabStop = false;
            gbx_Filter.Text = "Välj Filter";
            // 
            // tb_FilterText
            // 
            tb_FilterText.Dock = DockStyle.Top;
            tb_FilterText.Location = new Point(3, 146);
            tb_FilterText.Name = "tb_FilterText";
            tb_FilterText.Size = new Size(193, 24);
            tb_FilterText.TabIndex = 35;
            // 
            // label_FilterText
            // 
            label_FilterText.AutoSize = true;
            label_FilterText.Dock = DockStyle.Top;
            label_FilterText.Location = new Point(3, 120);
            label_FilterText.Name = "label_FilterText";
            label_FilterText.Padding = new Padding(0, 5, 0, 5);
            label_FilterText.Size = new Size(73, 26);
            label_FilterText.TabIndex = 34;
            label_FilterText.Text = "Filter Text";
            // 
            // cb_FilterCodeText
            // 
            cb_FilterCodeText.Dock = DockStyle.Top;
            cb_FilterCodeText.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_FilterCodeText.FormattingEnabled = true;
            cb_FilterCodeText.Location = new Point(3, 96);
            cb_FilterCodeText.Name = "cb_FilterCodeText";
            cb_FilterCodeText.Size = new Size(193, 24);
            cb_FilterCodeText.TabIndex = 33;
            // 
            // label_FilterColumn
            // 
            label_FilterColumn.AutoSize = true;
            label_FilterColumn.Dock = DockStyle.Top;
            label_FilterColumn.Location = new Point(3, 70);
            label_FilterColumn.Name = "label_FilterColumn";
            label_FilterColumn.Padding = new Padding(0, 5, 0, 5);
            label_FilterColumn.Size = new Size(148, 26);
            label_FilterColumn.TabIndex = 32;
            label_FilterColumn.Text = "Filtrera på CodeText?";
            // 
            // cb_FilterFunctions
            // 
            cb_FilterFunctions.Dock = DockStyle.Top;
            cb_FilterFunctions.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_FilterFunctions.FormattingEnabled = true;
            cb_FilterFunctions.Items.AddRange(new object[] { "eq", "startswith", "endwith" });
            cb_FilterFunctions.Location = new Point(3, 46);
            cb_FilterFunctions.Name = "cb_FilterFunctions";
            cb_FilterFunctions.Size = new Size(193, 24);
            cb_FilterFunctions.TabIndex = 28;
            cb_FilterFunctions.Visible = false;
            // 
            // label_Filter
            // 
            label_Filter.AutoSize = true;
            label_Filter.Dock = DockStyle.Top;
            label_Filter.Location = new Point(3, 20);
            label_Filter.Name = "label_Filter";
            label_Filter.Padding = new Padding(0, 5, 0, 5);
            label_Filter.Size = new Size(110, 26);
            label_Filter.TabIndex = 29;
            label_Filter.Text = "Filter funktioner";
            label_Filter.Visible = false;
            // 
            // gbx_MonitorAPI
            // 
            gbx_MonitorAPI.Controls.Add(cb_Identifier);
            gbx_MonitorAPI.Controls.Add(label_Column);
            gbx_MonitorAPI.Controls.Add(cb_Properties);
            gbx_MonitorAPI.Controls.Add(label_Property);
            gbx_MonitorAPI.Controls.Add(cb_Module);
            gbx_MonitorAPI.Controls.Add(label_Module);
            gbx_MonitorAPI.Dock = DockStyle.Fill;
            gbx_MonitorAPI.Font = new Font("Lucida Sans", 10.25F);
            gbx_MonitorAPI.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_MonitorAPI.Location = new Point(204, 45);
            gbx_MonitorAPI.Margin = new Padding(2, 5, 0, 0);
            gbx_MonitorAPI.Name = "gbx_MonitorAPI";
            gbx_MonitorAPI.Size = new Size(211, 802);
            gbx_MonitorAPI.TabIndex = 30;
            gbx_MonitorAPI.TabStop = false;
            gbx_MonitorAPI.Text = "Extra Fält";
            // 
            // cb_Identifier
            // 
            cb_Identifier.Dock = DockStyle.Top;
            cb_Identifier.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Identifier.FormattingEnabled = true;
            cb_Identifier.Items.AddRange(new object[] { "PartNumber", "Description" });
            cb_Identifier.Location = new Point(3, 146);
            cb_Identifier.Name = "cb_Identifier";
            cb_Identifier.Size = new Size(205, 24);
            cb_Identifier.TabIndex = 31;
            // 
            // label_Column
            // 
            label_Column.AutoSize = true;
            label_Column.Dock = DockStyle.Top;
            label_Column.Location = new Point(3, 120);
            label_Column.Name = "label_Column";
            label_Column.Padding = new Padding(0, 5, 0, 5);
            label_Column.Size = new Size(68, 26);
            label_Column.TabIndex = 30;
            label_Column.Text = "Extra Fält";
            // 
            // cb_Properties
            // 
            cb_Properties.Dock = DockStyle.Top;
            cb_Properties.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Properties.FormattingEnabled = true;
            cb_Properties.Items.AddRange(new object[] { "PartNumber", "ExtraDescription", "Description" });
            cb_Properties.Location = new Point(3, 96);
            cb_Properties.Name = "cb_Properties";
            cb_Properties.Size = new Size(205, 24);
            cb_Properties.TabIndex = 27;
            // 
            // label_Property
            // 
            label_Property.AutoSize = true;
            label_Property.Dock = DockStyle.Top;
            label_Property.Location = new Point(3, 70);
            label_Property.Name = "label_Property";
            label_Property.Padding = new Padding(0, 5, 0, 5);
            label_Property.Size = new Size(64, 26);
            label_Property.TabIndex = 29;
            label_Property.Text = "Property";
            // 
            // cb_Module
            // 
            cb_Module.Dock = DockStyle.Top;
            cb_Module.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Module.FormattingEnabled = true;
            cb_Module.Items.AddRange(new object[] { "Common", "Inventory", "Manufacturing", "" });
            cb_Module.Location = new Point(3, 46);
            cb_Module.Name = "cb_Module";
            cb_Module.Size = new Size(205, 24);
            cb_Module.TabIndex = 27;
            cb_Module.Visible = false;
            cb_Module.SelectedIndexChanged += cb_Module_SelectedIndexChanged;
            // 
            // label_Module
            // 
            label_Module.AutoSize = true;
            label_Module.Dock = DockStyle.Top;
            label_Module.Location = new Point(3, 20);
            label_Module.Name = "label_Module";
            label_Module.Padding = new Padding(0, 5, 0, 5);
            label_Module.Size = new Size(47, 26);
            label_Module.TabIndex = 28;
            label_Module.Text = "Modul";
            label_Module.Visible = false;
            // 
            // label_ListMonitor
            // 
            label_ListMonitor.AutoSize = true;
            tlp_MonitorLists.SetColumnSpan(label_ListMonitor, 2);
            label_ListMonitor.Dock = DockStyle.Fill;
            label_ListMonitor.Font = new Font("Segoe UI", 15F);
            label_ListMonitor.ForeColor = Color.FromArgb(184, 220, 231);
            label_ListMonitor.Location = new Point(3, 0);
            label_ListMonitor.Name = "label_ListMonitor";
            label_ListMonitor.Size = new Size(409, 40);
            label_ListMonitor.TabIndex = 29;
            label_ListMonitor.Text = "Monitor Listor";
            label_ListMonitor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // page_DPP_Lists
            // 
            page_DPP_Lists.BackColor = Color.Red;
            page_DPP_Lists.Location = new Point(4, 24);
            page_DPP_Lists.Name = "page_DPP_Lists";
            page_DPP_Lists.Padding = new Padding(3);
            page_DPP_Lists.Size = new Size(1285, 853);
            page_DPP_Lists.TabIndex = 2;
            page_DPP_Lists.Text = "DPP Listor";
            // 
            // label_CodeText
            // 
            label_CodeText.AutoSize = true;
            label_CodeText.Dock = DockStyle.Fill;
            label_CodeText.Font = new Font("Segoe UI", 30F);
            label_CodeText.ForeColor = Color.FromArgb(184, 220, 231);
            label_CodeText.Location = new Point(226, 0);
            label_CodeText.Name = "label_CodeText";
            label_CodeText.Size = new Size(1070, 55);
            label_CodeText.TabIndex = 34;
            label_CodeText.Text = "CodeText";
            label_CodeText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ItemsBuilder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1299, 942);
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ItemsBuilder";
            Text = "ItemsBuilder";
            FormClosed += ItemsBuilder_FormClosed;
            Load += ItemsBuilder_Load;
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            tab_Main.ResumeLayout(false);
            page_OwnLists.ResumeLayout(false);
            tlp_OwnLists.ResumeLayout(false);
            tlp_OwnLists.PerformLayout();
            gbx_AvailableOptions.ResumeLayout(false);
            gbx_AvailableOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ListItems).EndInit();
            gbx_ChosenItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Items).EndInit();
            page_MonitorLists.ResumeLayout(false);
            tlp_MonitorLists.ResumeLayout(false);
            tlp_MonitorLists.PerformLayout();
            gbx_MonitorPartCode.ResumeLayout(false);
            gbx_Filter.ResumeLayout(false);
            gbx_Filter.PerformLayout();
            gbx_MonitorAPI.ResumeLayout(false);
            gbx_MonitorAPI.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.Button btn_SaveItems;
        private Label label_CodeText;
        private TabControl tab_Main;
        private TabPage page_OwnLists;
        private TableLayoutPanel tlp_OwnLists;
        private Label label_Info_OwnItems;
        private GroupBox gbx_AvailableOptions;
        private DataGridView dgv_ListItems;
        private DataGridViewTextBoxColumn col_ListItems;
        private TextBox tb_AddNewItem;
        private Button btn_AddItem;
        private GroupBox gbx_ChosenItems;
        private DataGridView dgv_Items;
        private DataGridViewTextBoxColumn col_ID;
        private DataGridViewTextBoxColumn col_Items;
        private Button btn_DeleteItem;
        private TabPage page_MonitorLists;
        private TableLayoutPanel tlp_MonitorLists;
        private GroupBox gbx_MonitorPartCode;
        private ComboBox cb_PartCode;
        private GroupBox gbx_Filter;
        private TextBox tb_FilterText;
        private Label label_FilterText;
        private ComboBox cb_FilterCodeText;
        private Label label_FilterColumn;
        private ComboBox cb_FilterFunctions;
        private Label label_Filter;
        private GroupBox gbx_MonitorAPI;
        private ComboBox cb_Identifier;
        private Label label_Column;
        private ComboBox cb_Properties;
        private Label label_Property;
        private ComboBox cb_Module;
        private Label label_Module;
        private Label label_ListMonitor;
        private TabPage page_DPP_Lists;
    }
}