
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Equipment
{
    partial class Choose_Item
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
            this.tb_Filter = new System.Windows.Forms.TextBox();
            this.dgv_Items = new System.Windows.Forms.DataGridView();
            this.label_ChooseItemInfo_1 = new System.Windows.Forms.Label();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_AddedItems = new System.Windows.Forms.DataGridView();
            this.Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flp_Left = new System.Windows.Forms.FlowLayoutPanel();
            this.label_ChooseItemInfo_2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Items)).BeginInit();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AddedItems)).BeginInit();
            this.flp_Left.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_Filter
            // 
            this.tb_Filter.Location = new System.Drawing.Point(1, 63);
            this.tb_Filter.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Filter.Name = "tb_Filter";
            this.tb_Filter.Size = new System.Drawing.Size(162, 20);
            this.tb_Filter.TabIndex = 0;
            this.tb_Filter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            this.tb_Filter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Filter_KeyDown);
            // 
            // dgv_Items
            // 
            this.dgv_Items.AllowUserToAddRows = false;
            this.dgv_Items.AllowUserToDeleteRows = false;
            this.dgv_Items.AllowUserToResizeColumns = false;
            this.dgv_Items.AllowUserToResizeRows = false;
            this.dgv_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Items.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Items.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Items.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Items.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Items.Location = new System.Drawing.Point(164, 2);
            this.dgv_Items.Margin = new System.Windows.Forms.Padding(1, 2, 0, 0);
            this.dgv_Items.MultiSelect = false;
            this.dgv_Items.Name = "dgv_Items";
            this.dgv_Items.RowHeadersVisible = false;
            this.tlp_Main.SetRowSpan(this.dgv_Items, 3);
            this.dgv_Items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Items.Size = new System.Drawing.Size(248, 174);
            this.dgv_Items.TabIndex = 1;
            this.dgv_Items.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Items_KeyDown);
            // 
            // label_ChooseItemInfo_1
            // 
            this.label_ChooseItemInfo_1.AutoSize = true;
            this.label_ChooseItemInfo_1.BackColor = System.Drawing.SystemColors.Info;
            this.label_ChooseItemInfo_1.Font = new System.Drawing.Font("Lucida Sans", 9.25F);
            this.label_ChooseItemInfo_1.ForeColor = System.Drawing.Color.DimGray;
            this.label_ChooseItemInfo_1.Location = new System.Drawing.Point(2, 2);
            this.label_ChooseItemInfo_1.Margin = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.label_ChooseItemInfo_1.Name = "label_ChooseItemInfo_1";
            this.label_ChooseItemInfo_1.Size = new System.Drawing.Size(160, 45);
            this.label_ChooseItemInfo_1.TabIndex = 2;
            this.label_ChooseItemInfo_1.Text = "Filtrera listan genom att skriva i textrutan nedanför.";
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tlp_Main.ColumnCount = 4;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tlp_Main.Controls.Add(this.dgv_AddedItems, 3, 0);
            this.tlp_Main.Controls.Add(this.dgv_Items, 2, 0);
            this.tlp_Main.Controls.Add(this.flp_Left, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(499, 176);
            this.tlp_Main.TabIndex = 3;
            // 
            // dgv_AddedItems
            // 
            this.dgv_AddedItems.AllowUserToAddRows = false;
            this.dgv_AddedItems.AllowUserToDeleteRows = false;
            this.dgv_AddedItems.AllowUserToResizeColumns = false;
            this.dgv_AddedItems.AllowUserToResizeRows = false;
            this.dgv_AddedItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_AddedItems.BackgroundColor = System.Drawing.Color.White;
            this.dgv_AddedItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_AddedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AddedItems.ColumnHeadersVisible = false;
            this.dgv_AddedItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Items});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_AddedItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_AddedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_AddedItems.Location = new System.Drawing.Point(413, 2);
            this.dgv_AddedItems.Margin = new System.Windows.Forms.Padding(1, 2, 0, 0);
            this.dgv_AddedItems.MultiSelect = false;
            this.dgv_AddedItems.Name = "dgv_AddedItems";
            this.dgv_AddedItems.RowHeadersVisible = false;
            this.tlp_Main.SetRowSpan(this.dgv_AddedItems, 3);
            this.dgv_AddedItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_AddedItems.Size = new System.Drawing.Size(86, 174);
            this.dgv_AddedItems.TabIndex = 3;
            this.dgv_AddedItems.Visible = false;
            // 
            // Items
            // 
            this.Items.HeaderText = "Items";
            this.Items.Name = "Items";
            this.Items.Width = 5;
            // 
            // flp_Left
            // 
            this.tlp_Main.SetColumnSpan(this.flp_Left, 2);
            this.flp_Left.Controls.Add(this.label_ChooseItemInfo_1);
            this.flp_Left.Controls.Add(this.label_ChooseItemInfo_2);
            this.flp_Left.Controls.Add(this.tb_Filter);
            this.flp_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Left.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Left.Location = new System.Drawing.Point(0, 0);
            this.flp_Left.Margin = new System.Windows.Forms.Padding(0);
            this.flp_Left.Name = "flp_Left";
            this.tlp_Main.SetRowSpan(this.flp_Left, 3);
            this.flp_Left.Size = new System.Drawing.Size(163, 176);
            this.flp_Left.TabIndex = 5;
            // 
            // label_ChooseItemInfo_2
            // 
            this.label_ChooseItemInfo_2.AutoSize = true;
            this.label_ChooseItemInfo_2.BackColor = System.Drawing.SystemColors.Info;
            this.label_ChooseItemInfo_2.Font = new System.Drawing.Font("Lucida Sans", 9.25F);
            this.label_ChooseItemInfo_2.ForeColor = System.Drawing.Color.DimGray;
            this.label_ChooseItemInfo_2.Location = new System.Drawing.Point(2, 47);
            this.label_ChooseItemInfo_2.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.label_ChooseItemInfo_2.Name = "label_ChooseItemInfo_2";
            this.label_ChooseItemInfo_2.Size = new System.Drawing.Size(0, 15);
            this.label_ChooseItemInfo_2.TabIndex = 4;
            // 
            // Choose_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(499, 176);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(300, 215);
            this.Name = "Choose_Item";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Choose_Item_FormClosing);
            this.Load += new System.EventHandler(this.Choose_Item_Load);
            this.Shown += new System.EventHandler(this.Choose_Item_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Items)).EndInit();
            this.tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AddedItems)).EndInit();
            this.flp_Left.ResumeLayout(false);
            this.flp_Left.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox tb_Filter;
        private DataGridView dgv_Items;
        private Label label_ChooseItemInfo_1;
        private TableLayoutPanel tlp_Main;
        private DataGridView dgv_AddedItems;
        private DataGridViewTextBoxColumn Items;
        private Label label_ChooseItemInfo_2;
        private FlowLayoutPanel flp_Left;
    }
}