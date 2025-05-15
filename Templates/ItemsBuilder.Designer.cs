namespace DigitalProductionProgram.Protocols.Template_Management
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.btn_SaveItems = new System.Windows.Forms.Button();
            this.dgv_Items = new System.Windows.Forms.DataGridView();
            this.col_Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_ListItems = new System.Windows.Forms.DataGridView();
            this.gbx_Items = new System.Windows.Forms.GroupBox();
            this.btn_AddItem = new System.Windows.Forms.Button();
            this.tb_AddNewItem = new System.Windows.Forms.TextBox();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListItems)).BeginInit();
            this.gbx_Items.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 3;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 979F));
            this.tlp_Main.Controls.Add(this.btn_SaveItems, 0, 0);
            this.tlp_Main.Controls.Add(this.dgv_Items, 1, 2);
            this.tlp_Main.Controls.Add(this.dgv_ListItems, 0, 2);
            this.tlp_Main.Controls.Add(this.gbx_Items, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(1382, 816);
            this.tlp_Main.TabIndex = 0;
            // 
            // btn_SaveItems
            // 
            this.btn_SaveItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_SaveItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_SaveItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveItems.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_SaveItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_SaveItems.Location = new System.Drawing.Point(3, 3);
            this.btn_SaveItems.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btn_SaveItems.Name = "btn_SaveItems";
            this.btn_SaveItems.Size = new System.Drawing.Size(194, 30);
            this.btn_SaveItems.TabIndex = 26;
            this.btn_SaveItems.Text = "Spara och Avsluta";
            this.btn_SaveItems.UseVisualStyleBackColor = false;
            this.btn_SaveItems.Click += new System.EventHandler(this.SaveItems_Click);
            // 
            // dgv_Items
            // 
            this.dgv_Items.AllowUserToAddRows = false;
            this.dgv_Items.AllowUserToResizeColumns = false;
            this.dgv_Items.AllowUserToResizeRows = false;
            this.dgv_Items.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Items});
            this.dgv_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Items.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_Items.EnableHeadersVisualStyles = false;
            this.dgv_Items.Location = new System.Drawing.Point(203, 139);
            this.dgv_Items.Name = "dgv_Items";
            this.dgv_Items.RowHeadersVisible = false;
            this.dgv_Items.Size = new System.Drawing.Size(197, 674);
            this.dgv_Items.TabIndex = 25;
            // 
            // col_Items
            // 
            this.col_Items.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Items.HeaderText = "Items";
            this.col_Items.Name = "col_Items";
            // 
            // dgv_ListItems
            // 
            this.dgv_ListItems.AllowUserToAddRows = false;
            this.dgv_ListItems.AllowUserToDeleteRows = false;
            this.dgv_ListItems.AllowUserToResizeColumns = false;
            this.dgv_ListItems.AllowUserToResizeRows = false;
            this.dgv_ListItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_ListItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_ListItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            this.dgv_ListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListItems.ColumnHeadersVisible = false;
            this.dgv_ListItems.Location = new System.Drawing.Point(3, 139);
            this.dgv_ListItems.MultiSelect = false;
            this.dgv_ListItems.Name = "dgv_ListItems";
            this.dgv_ListItems.ReadOnly = true;
            this.dgv_ListItems.RowHeadersVisible = false;
            this.dgv_ListItems.Size = new System.Drawing.Size(194, 674);
            this.dgv_ListItems.TabIndex = 3;
            this.dgv_ListItems.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ListItems_CellMouseDown);
            // 
            // gbx_Items
            // 
            this.gbx_Items.Controls.Add(this.btn_AddItem);
            this.gbx_Items.Controls.Add(this.tb_AddNewItem);
            this.gbx_Items.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.gbx_Items.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.gbx_Items.Location = new System.Drawing.Point(3, 51);
            this.gbx_Items.Name = "gbx_Items";
            this.gbx_Items.Size = new System.Drawing.Size(194, 82);
            this.gbx_Items.TabIndex = 22;
            this.gbx_Items.TabStop = false;
            this.gbx_Items.Text = "Svarsalternativ";
            // 
            // btn_AddItem
            // 
            this.btn_AddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(188)))), ((int)(((byte)(189)))));
            this.btn_AddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddItem.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_AddItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(116)))), ((int)(((byte)(140)))));
            this.btn_AddItem.Location = new System.Drawing.Point(6, 23);
            this.btn_AddItem.Name = "btn_AddItem";
            this.btn_AddItem.Size = new System.Drawing.Size(150, 28);
            this.btn_AddItem.TabIndex = 11;
            this.btn_AddItem.Text = "Lägg till text";
            this.btn_AddItem.UseVisualStyleBackColor = false;
            // 
            // tb_AddNewItem
            // 
            this.tb_AddNewItem.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.tb_AddNewItem.Location = new System.Drawing.Point(6, 57);
            this.tb_AddNewItem.Name = "tb_AddNewItem";
            this.tb_AddNewItem.Size = new System.Drawing.Size(150, 20);
            this.tb_AddNewItem.TabIndex = 3;
            // 
            // ItemsBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1382, 816);
            this.Controls.Add(this.tlp_Main);
            this.Name = "ItemsBuilder";
            this.Text = "ItemsBuilder";
            this.tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListItems)).EndInit();
            this.gbx_Items.ResumeLayout(false);
            this.gbx_Items.PerformLayout();
            this.ResumeLayout(false);

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
    }
}