using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    partial class PreFab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreFab));
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.btn_PreFab = new System.Windows.Forms.Button();
            this.btn_RemovePreFab = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pb_Info = new System.Windows.Forms.PictureBox();
            this.btn_AddPreFab = new System.Windows.Forms.Button();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 3;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlp_Main.Controls.Add(this.btn_PreFab, 0, 0);
            this.tlp_Main.Controls.Add(this.btn_RemovePreFab, 1, 1);
            this.tlp_Main.Controls.Add(this.dgv, 0, 2);
            this.tlp_Main.Controls.Add(this.pb_Info, 2, 1);
            this.tlp_Main.Controls.Add(this.btn_AddPreFab, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(731, 189);
            this.tlp_Main.TabIndex = 0;
            // 
            // btn_PreFab
            // 
            this.btn_PreFab.BackColor = System.Drawing.Color.LightGray;
            this.tlp_Main.SetColumnSpan(this.btn_PreFab, 5);
            this.btn_PreFab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PreFab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PreFab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btn_PreFab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PreFab.Font = new System.Drawing.Font("Palatino Linotype", 10F);
            this.btn_PreFab.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btn_PreFab.Location = new System.Drawing.Point(0, 0);
            this.btn_PreFab.Margin = new System.Windows.Forms.Padding(0);
            this.btn_PreFab.Name = "btn_PreFab";
            this.btn_PreFab.Size = new System.Drawing.Size(731, 28);
            this.btn_PreFab.TabIndex = 974;
            this.btn_PreFab.Text = "Halvfabrikat";
            this.btn_PreFab.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_PreFab.UseVisualStyleBackColor = false;
            this.btn_PreFab.Click += new System.EventHandler(this.PreFab_Click);
            // 
            // btn_RemovePreFab
            // 
            this.btn_RemovePreFab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btn_RemovePreFab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RemovePreFab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btn_RemovePreFab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemovePreFab.Font = new System.Drawing.Font("Consolas", 9F);
            this.btn_RemovePreFab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_RemovePreFab.Location = new System.Drawing.Point(186, 29);
            this.btn_RemovePreFab.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btn_RemovePreFab.Name = "btn_RemovePreFab";
            this.btn_RemovePreFab.Size = new System.Drawing.Size(159, 23);
            this.btn_RemovePreFab.TabIndex = 973;
            this.btn_RemovePreFab.Text = "Radera Halvfabrikat";
            this.btn_RemovePreFab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_RemovePreFab.UseVisualStyleBackColor = false;
            this.btn_RemovePreFab.Click += new System.EventHandler(this.Delete_PreFab_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv.ColumnHeadersHeight = 20;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tlp_Main.SetColumnSpan(this.dgv, 3);
            this.dgv.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.dgv.Location = new System.Drawing.Point(0, 52);
            this.dgv.Margin = new System.Windows.Forms.Padding(0);
            this.dgv.Name = "dgv";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(731, 137);
            this.dgv.TabIndex = 908;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PreFab_CellClick);
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.CellFormatting);
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Save_CellValueChanged);
            this.dgv.Leave += new System.EventHandler(this.dgv_Leave);
            // 
            // pb_Info
            // 
            this.pb_Info.BackColor = System.Drawing.Color.Transparent;
            this.pb_Info.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Info.BackgroundImage")));
            this.pb_Info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_Info.Location = new System.Drawing.Point(345, 28);
            this.pb_Info.Margin = new System.Windows.Forms.Padding(0);
            this.pb_Info.Name = "pb_Info";
            this.pb_Info.Size = new System.Drawing.Size(42, 24);
            this.pb_Info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Info.TabIndex = 971;
            this.pb_Info.TabStop = false;
            this.pb_Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // btn_AddPreFab
            // 
            this.btn_AddPreFab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btn_AddPreFab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddPreFab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_AddPreFab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btn_AddPreFab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddPreFab.Font = new System.Drawing.Font("Consolas", 9F);
            this.btn_AddPreFab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_AddPreFab.Location = new System.Drawing.Point(2, 29);
            this.btn_AddPreFab.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btn_AddPreFab.Name = "btn_AddPreFab";
            this.btn_AddPreFab.Size = new System.Drawing.Size(182, 23);
            this.btn_AddPreFab.TabIndex = 972;
            this.btn_AddPreFab.Text = "Lägg till Halvfabrikat";
            this.btn_AddPreFab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddPreFab.UseVisualStyleBackColor = false;
            this.btn_AddPreFab.Click += new System.EventHandler(this.Add_PreFab_Click);
            // 
            // PreFab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "PreFab";
            this.Size = new System.Drawing.Size(731, 189);
            this.tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public TableLayoutPanel tlp_Main;
        public DataGridView dgv;
        private PictureBox pb_Info;
        private Button btn_PreFab;
        public Button btn_AddPreFab;
        public Button btn_RemovePreFab;
    }
}
