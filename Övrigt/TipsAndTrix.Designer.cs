namespace DigitalProductionProgram.Övrigt
{
    partial class TipsAndTrix
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipsAndTrix));
            tlp_Tips_Trix = new TableLayoutPanel();
            label_Tips_Trix = new Label();
            pb_Info_Tips_Trix = new PictureBox();
            rb_Text_Tips_Trix = new RichTextBox();
            colorDialog1 = new ColorDialog();
            fontDialog1 = new FontDialog();
            tlp_Tips_Trix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Info_Tips_Trix).BeginInit();
            SuspendLayout();
            // 
            // tlp_Tips_Trix
            // 
            tlp_Tips_Trix.BackColor = Color.Transparent;
            tlp_Tips_Trix.ColumnCount = 2;
            tlp_Tips_Trix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Tips_Trix.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 41F));
            tlp_Tips_Trix.Controls.Add(label_Tips_Trix, 0, 0);
            tlp_Tips_Trix.Controls.Add(pb_Info_Tips_Trix, 1, 0);
            tlp_Tips_Trix.Controls.Add(rb_Text_Tips_Trix, 0, 1);
            tlp_Tips_Trix.Dock = DockStyle.Fill;
            tlp_Tips_Trix.Location = new Point(0, 0);
            tlp_Tips_Trix.Margin = new Padding(0, 3, 0, 0);
            tlp_Tips_Trix.Name = "tlp_Tips_Trix";
            tlp_Tips_Trix.RowCount = 2;
            tlp_Tips_Trix.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tlp_Tips_Trix.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Tips_Trix.Size = new Size(286, 395);
            tlp_Tips_Trix.TabIndex = 913;
            // 
            // label_Tips_Trix
            // 
            label_Tips_Trix.AutoSize = true;
            label_Tips_Trix.BackColor = Color.Transparent;
            label_Tips_Trix.Dock = DockStyle.Fill;
            label_Tips_Trix.Font = new Font("Palatino Linotype", 14.25F);
            label_Tips_Trix.ForeColor = Color.Moccasin;
            label_Tips_Trix.Location = new Point(0, 0);
            label_Tips_Trix.Margin = new Padding(0);
            label_Tips_Trix.Name = "label_Tips_Trix";
            label_Tips_Trix.Size = new Size(245, 37);
            label_Tips_Trix.TabIndex = 872;
            label_Tips_Trix.Text = "Tips and Trix";
            label_Tips_Trix.TextAlign = ContentAlignment.MiddleCenter;
            label_Tips_Trix.UseMnemonic = false;
            // 
            // pb_Info_Tips_Trix
            // 
            pb_Info_Tips_Trix.BackColor = Color.Transparent;
            pb_Info_Tips_Trix.BackgroundImage = (Image)resources.GetObject("pb_Info_Tips_Trix.BackgroundImage");
            pb_Info_Tips_Trix.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info_Tips_Trix.Cursor = Cursors.Hand;
            pb_Info_Tips_Trix.Dock = DockStyle.Fill;
            pb_Info_Tips_Trix.Location = new Point(245, 0);
            pb_Info_Tips_Trix.Margin = new Padding(0);
            pb_Info_Tips_Trix.Name = "pb_Info_Tips_Trix";
            pb_Info_Tips_Trix.Size = new Size(41, 37);
            pb_Info_Tips_Trix.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Info_Tips_Trix.TabIndex = 871;
            pb_Info_Tips_Trix.TabStop = false;
            pb_Info_Tips_Trix.Click += Info_Tips_Trix_Click;
            // 
            // rb_Text_Tips_Trix
            // 
            rb_Text_Tips_Trix.BackColor = Color.FromArgb(25, 25, 25);
            rb_Text_Tips_Trix.BorderStyle = BorderStyle.None;
            tlp_Tips_Trix.SetColumnSpan(rb_Text_Tips_Trix, 2);
            rb_Text_Tips_Trix.Dock = DockStyle.Fill;
            rb_Text_Tips_Trix.Font = new Font("Microsoft Sans Serif", 8F);
            rb_Text_Tips_Trix.ForeColor = SystemColors.Info;
            rb_Text_Tips_Trix.Location = new Point(0, 37);
            rb_Text_Tips_Trix.Margin = new Padding(0);
            rb_Text_Tips_Trix.Name = "rb_Text_Tips_Trix";
            rb_Text_Tips_Trix.Size = new Size(286, 358);
            rb_Text_Tips_Trix.TabIndex = 873;
            rb_Text_Tips_Trix.Text = "";
            rb_Text_Tips_Trix.KeyPress += Text_Tips_Trix_KeyPress;
            rb_Text_Tips_Trix.KeyUp += Text_Tips_Trix_KeyUp;
            rb_Text_Tips_Trix.MouseDown += Text_Tips_Trix_MouseDown;
            // 
            // TipsAndTrix
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(tlp_Tips_Trix);
            Margin = new Padding(4, 3, 4, 3);
            Name = "TipsAndTrix";
            Size = new Size(286, 395);
            tlp_Tips_Trix.ResumeLayout(false);
            tlp_Tips_Trix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Info_Tips_Trix).EndInit();
            ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tlp_Tips_Trix;
        private System.Windows.Forms.RichTextBox rb_Text_Tips_Trix;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        public System.Windows.Forms.Label label_Tips_Trix;
        public System.Windows.Forms.PictureBox pb_Info_Tips_Trix;
    }
}
