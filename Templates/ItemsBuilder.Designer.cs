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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tlp_Main = new TableLayoutPanel();
            btn_SaveItems = new Button();
            dgv_Items = new DataGridView();
            col_Items = new DataGridViewTextBoxColumn();
            dgv_ListItems = new DataGridView();
            col_ListItems = new DataGridViewTextBoxColumn();
            gbx_Items = new GroupBox();
            btn_AddItem = new Button();
            tb_AddNewItem = new TextBox();
            tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Items).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_ListItems).BeginInit();
            gbx_Items.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 3;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 233F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 237F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1142F));
            tlp_Main.Controls.Add(btn_SaveItems, 0, 0);
            tlp_Main.Controls.Add(dgv_Items, 1, 2);
            tlp_Main.Controls.Add(dgv_ListItems, 0, 2);
            tlp_Main.Controls.Add(gbx_Items, 0, 1);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 3;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 102F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(1612, 942);
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
            btn_SaveItems.Size = new Size(225, 35);
            btn_SaveItems.TabIndex = 26;
            btn_SaveItems.Text = "Spara och Avsluta";
            btn_SaveItems.UseVisualStyleBackColor = false;
            btn_SaveItems.Click += SaveItems_Click;
            // 
            // dgv_Items
            // 
            dgv_Items.AllowUserToAddRows = false;
            dgv_Items.AllowUserToResizeColumns = false;
            dgv_Items.AllowUserToResizeRows = false;
            dgv_Items.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(6, 81, 87);
            dataGridViewCellStyle1.Font = new Font("Lucida Sans", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 235, 156);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_Items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Items.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Items.Columns.AddRange(new DataGridViewColumn[] { col_Items });
            dgv_Items.Dock = DockStyle.Fill;
            dgv_Items.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv_Items.EnableHeadersVisualStyles = false;
            dgv_Items.Location = new Point(237, 160);
            dgv_Items.Margin = new Padding(4, 3, 4, 3);
            dgv_Items.Name = "dgv_Items";
            dgv_Items.RowHeadersVisible = false;
            dgv_Items.Size = new Size(229, 779);
            dgv_Items.TabIndex = 25;
            // 
            // col_Items
            // 
            col_Items.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_Items.HeaderText = "Items";
            col_Items.Name = "col_Items";
            // 
            // dgv_ListItems
            // 
            dgv_ListItems.AllowUserToAddRows = false;
            dgv_ListItems.AllowUserToDeleteRows = false;
            dgv_ListItems.AllowUserToResizeColumns = false;
            dgv_ListItems.AllowUserToResizeRows = false;
            dgv_ListItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgv_ListItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_ListItems.BackgroundColor = Color.FromArgb(81, 85, 92);
            dgv_ListItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ListItems.ColumnHeadersVisible = false;
            dgv_ListItems.Columns.AddRange(new DataGridViewColumn[] { col_ListItems });
            dgv_ListItems.Location = new Point(4, 160);
            dgv_ListItems.Margin = new Padding(4, 3, 4, 3);
            dgv_ListItems.MultiSelect = false;
            dgv_ListItems.Name = "dgv_ListItems";
            dgv_ListItems.ReadOnly = true;
            dgv_ListItems.RowHeadersVisible = false;
            dgv_ListItems.Size = new Size(225, 779);
            dgv_ListItems.TabIndex = 3;
            dgv_ListItems.CellMouseDown += ItemList_CellMouseDown;
            // 
            // col_ListItems
            // 
            col_ListItems.HeaderText = "Items";
            col_ListItems.Name = "col_ListItems";
            col_ListItems.ReadOnly = true;
            col_ListItems.Width = 5;
            // 
            // gbx_Items
            // 
            gbx_Items.Controls.Add(btn_AddItem);
            gbx_Items.Controls.Add(tb_AddNewItem);
            gbx_Items.Font = new Font("Lucida Sans", 10.25F);
            gbx_Items.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_Items.Location = new Point(4, 58);
            gbx_Items.Margin = new Padding(4, 3, 4, 3);
            gbx_Items.Name = "gbx_Items";
            gbx_Items.Padding = new Padding(4, 3, 4, 3);
            gbx_Items.Size = new Size(225, 95);
            gbx_Items.TabIndex = 22;
            gbx_Items.TabStop = false;
            gbx_Items.Text = "Svarsalternativ";
            // 
            // btn_AddItem
            // 
            btn_AddItem.BackColor = Color.FromArgb(185, 188, 189);
            btn_AddItem.Cursor = Cursors.Hand;
            btn_AddItem.FlatStyle = FlatStyle.Flat;
            btn_AddItem.Font = new Font("Lucida Sans", 10.25F);
            btn_AddItem.ForeColor = Color.FromArgb(63, 116, 140);
            btn_AddItem.Location = new Point(7, 27);
            btn_AddItem.Margin = new Padding(4, 3, 4, 3);
            btn_AddItem.Name = "btn_AddItem";
            btn_AddItem.Size = new Size(175, 32);
            btn_AddItem.TabIndex = 11;
            btn_AddItem.Text = "Lägg till text";
            btn_AddItem.UseVisualStyleBackColor = false;
            btn_AddItem.Click += NewItem_Click;
            // 
            // tb_AddNewItem
            // 
            tb_AddNewItem.Font = new Font("Lucida Sans", 8.25F);
            tb_AddNewItem.Location = new Point(7, 66);
            tb_AddNewItem.Margin = new Padding(4, 3, 4, 3);
            tb_AddNewItem.Name = "tb_AddNewItem";
            tb_AddNewItem.Size = new Size(174, 20);
            tb_AddNewItem.TabIndex = 3;
            // 
            // ItemsBuilder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1612, 942);
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ItemsBuilder";
            Text = "ItemsBuilder";
            FormClosed += ItemsBuilder_FormClosed;
            tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Items).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_ListItems).EndInit();
            gbx_Items.ResumeLayout(false);
            gbx_Items.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.DataGridView dgv_ListItems;
        private System.Windows.Forms.GroupBox gbx_Items;
        private System.Windows.Forms.Button btn_AddItem;
        private System.Windows.Forms.TextBox tb_AddNewItem;
        private System.Windows.Forms.DataGridView dgv_Items;
        private System.Windows.Forms.Button btn_SaveItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Items;
        private DataGridViewTextBoxColumn col_ListItems;
    }
}