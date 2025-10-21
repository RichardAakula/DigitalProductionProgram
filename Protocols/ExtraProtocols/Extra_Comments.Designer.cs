namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    partial class Extra_Comments
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label_Header = new System.Windows.Forms.Label();
            this.dgv_ExtraComments = new System.Windows.Forms.DataGridView();
            this.timer_Update_ExtraKommentarer = new System.Windows.Forms.Timer(this.components);
            this.Spool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_Locked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExtraComments)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 5;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 444F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlp_Main.Controls.Add(this.label_Header, 0, 0);
            this.tlp_Main.Controls.Add(this.dgv_ExtraComments, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(878, 716);
            this.tlp_Main.TabIndex = 2;
            // 
            // label_Header
            // 
            this.label_Header.BackColor = System.Drawing.Color.LightGray;
            this.tlp_Main.SetColumnSpan(this.label_Header, 5);
            this.label_Header.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Header.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Header.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_Header.Location = new System.Drawing.Point(1, 1);
            this.label_Header.Margin = new System.Windows.Forms.Padding(1);
            this.label_Header.Name = "label_Header";
            this.label_Header.Size = new System.Drawing.Size(876, 24);
            this.label_Header.TabIndex = 850;
            this.label_Header.Text = "Extra Kommentarer:";
            // 
            // dgv_ExtraComments
            // 
            this.dgv_ExtraComments.AllowUserToAddRows = false;
            this.dgv_ExtraComments.AllowUserToDeleteRows = false;
            this.dgv_ExtraComments.AllowUserToResizeColumns = false;
            this.dgv_ExtraComments.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 7F);
            this.dgv_ExtraComments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ExtraComments.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ExtraComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ExtraComments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ExtraComments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ExtraComments.ColumnHeadersHeight = 30;
            this.dgv_ExtraComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ExtraComments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Spool,
            this.Comments,
            this.Date,
            this.Sign,
            this.EmpNr,
            this.is_Locked});
            this.tlp_Main.SetColumnSpan(this.dgv_ExtraComments, 5);
            this.dgv_ExtraComments.Cursor = System.Windows.Forms.Cursors.IBeam;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ExtraComments.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_ExtraComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ExtraComments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_ExtraComments.Location = new System.Drawing.Point(1, 27);
            this.dgv_ExtraComments.Margin = new System.Windows.Forms.Padding(1);
            this.dgv_ExtraComments.MultiSelect = false;
            this.dgv_ExtraComments.Name = "dgv_ExtraComments";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ExtraComments.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_ExtraComments.RowHeadersVisible = false;
            this.dgv_ExtraComments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_ExtraComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_ExtraComments.ShowCellToolTips = false;
            this.dgv_ExtraComments.Size = new System.Drawing.Size(876, 688);
            this.dgv_ExtraComments.TabIndex = 949;
            this.dgv_ExtraComments.TabStop = false;
            this.dgv_ExtraComments.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExtraComments_RowEnter);
            this.dgv_ExtraComments.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExtraComments_RowValidated);
            // 
            // timer_Update_ExtraKommentarer
            // 
            this.timer_Update_ExtraKommentarer.Interval = 5000;
            this.timer_Update_ExtraKommentarer.Tick += new System.EventHandler(this.timer_Update_ExtraKommentarer_Tick);
            // 
            // Spool
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 7F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Spool.DefaultCellStyle = dataGridViewCellStyle3;
            this.Spool.HeaderText = "Spole/Påse:";
            this.Spool.MaxInputLength = 4;
            this.Spool.Name = "Spool";
            this.Spool.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Spool.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Spool.Width = 37;
            // 
            // Comments
            // 
            this.Comments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 7F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Comments.DefaultCellStyle = dataGridViewCellStyle4;
            this.Comments.HeaderText = "Kommentarer:";
            this.Comments.MaxInputLength = 60;
            this.Comments.Name = "Comments";
            this.Comments.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Comments.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Date
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Courier New", 7F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Date.DefaultCellStyle = dataGridViewCellStyle5;
            this.Date.HeaderText = "Datum:";
            this.Date.MaxInputLength = 5;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Date.Width = 109;
            // 
            // Sign
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Courier New", 7F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Sign.DefaultCellStyle = dataGridViewCellStyle6;
            this.Sign.HeaderText = "Sign:";
            this.Sign.Name = "Sign";
            this.Sign.ReadOnly = true;
            this.Sign.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Sign.Width = 36;
            // 
            // EmpNr
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Courier New", 7F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.EmpNr.DefaultCellStyle = dataGridViewCellStyle7;
            this.EmpNr.HeaderText = "AnstNr:";
            this.EmpNr.Name = "EmpNr";
            this.EmpNr.ReadOnly = true;
            this.EmpNr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EmpNr.Width = 45;
            // 
            // is_Locked
            // 
            this.is_Locked.HeaderText = "is_Locked";
            this.is_Locked.Name = "is_Locked";
            this.is_Locked.Visible = false;
            // 
            // Extra_Comments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 716);
            this.Controls.Add(this.tlp_Main);
            this.Name = "Extra_Comments";
            this.tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExtraComments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.Label label_Header;
        public System.Windows.Forms.DataGridView dgv_ExtraComments;
        private System.Windows.Forms.Timer timer_Update_ExtraKommentarer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spool;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sign;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpNr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_Locked;
    }
}