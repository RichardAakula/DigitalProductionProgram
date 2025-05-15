
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols
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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tb_Comments = new System.Windows.Forms.TextBox();
            this.label_Comments = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.tb_Comments, 0, 1);
            this.tlp_Main.Controls.Add(this.label_Comments, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(623, 186);
            this.tlp_Main.TabIndex = 0;
            // 
            // tb_Comments
            // 
            this.tb_Comments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Comments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Comments.Font = new System.Drawing.Font("Courier New", 9F);
            this.tb_Comments.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Comments.Location = new System.Drawing.Point(0, 22);
            this.tb_Comments.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.tb_Comments.Multiline = true;
            this.tb_Comments.Name = "tb_Comments";
            this.tb_Comments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Comments.Size = new System.Drawing.Size(622, 164);
            this.tb_Comments.TabIndex = 948;
            // 
            // label_Comments
            // 
            this.label_Comments.BackColor = System.Drawing.Color.LightGray;
            this.label_Comments.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Comments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Comments.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label_Comments.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_Comments.Location = new System.Drawing.Point(0, 0);
            this.label_Comments.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.label_Comments.Name = "label_Comments";
            this.label_Comments.Size = new System.Drawing.Size(622, 21);
            this.label_Comments.TabIndex = 862;
            this.label_Comments.Text = "Kommentarer allmänt om körningen:";
            // 
            // Comments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "Comments";
            this.Size = new System.Drawing.Size(623, 186);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        public TextBox tb_Comments;
        public Label label_Comments;
    }
}
