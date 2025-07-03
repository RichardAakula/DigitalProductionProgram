using System.ComponentModel;

namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    partial class Comments
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
            tlp_Main = new TableLayoutPanel();
            tb_Comments = new TextBox();
            label_Comments = new Label();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Black;
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.Controls.Add(tb_Comments, 0, 1);
            tlp_Main.Controls.Add(label_Comments, 0, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(727, 215);
            tlp_Main.TabIndex = 0;
            // 
            // tb_Comments
            // 
            tb_Comments.BorderStyle = BorderStyle.None;
            tb_Comments.Dock = DockStyle.Fill;
            tb_Comments.Font = new Font("Courier New", 9F);
            tb_Comments.ForeColor = Color.DarkSlateGray;
            tb_Comments.Location = new Point(0, 25);
            tb_Comments.Margin = new Padding(0, 0, 1, 0);
            tb_Comments.Multiline = true;
            tb_Comments.Name = "tb_Comments";
            tb_Comments.ScrollBars = ScrollBars.Vertical;
            tb_Comments.Size = new Size(726, 190);
            tb_Comments.TabIndex = 948;
            // 
            // label_Comments
            // 
            label_Comments.BackColor = Color.LightGray;
            label_Comments.Cursor = Cursors.SizeAll;
            label_Comments.Dock = DockStyle.Fill;
            label_Comments.Font = new Font("Palatino Linotype", 10.25F);
            label_Comments.ForeColor = Color.SaddleBrown;
            label_Comments.Location = new Point(0, 0);
            label_Comments.Margin = new Padding(0, 0, 1, 1);
            label_Comments.Name = "label_Comments";
            label_Comments.Size = new Size(726, 24);
            label_Comments.TabIndex = 862;
            label_Comments.Text = "Kommentarer allmänt om körningen:";
            // 
            // Comments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Comments";
            Size = new Size(727, 215);
            Load += Comments_Load;
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        public TextBox tb_Comments;
        public Label label_Comments;
    }
}
