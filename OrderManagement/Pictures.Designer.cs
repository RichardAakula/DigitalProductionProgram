using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.OrderHantering
{
    partial class Pictures
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
            this.lblClose = new System.Windows.Forms.Label();
            this.flp_Main = new System.Windows.Forms.FlowLayoutPanel();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.Red;
            this.lblClose.Location = new System.Drawing.Point(3, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(34, 37);
            this.lblClose.TabIndex = 4;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lbl_Close_Click);
            // 
            // flp_Main
            // 
            this.flp_Main.AutoScroll = true;
            this.tlp_Main.SetColumnSpan(this.flp_Main, 2);
            this.flp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Main.Location = new System.Drawing.Point(3, 43);
            this.flp_Main.Name = "flp_Main";
            this.flp_Main.Size = new System.Drawing.Size(1094, 485);
            this.flp_Main.TabIndex = 5;
            // 
            // tlp_Main
            // 
            this.tlp_Main.AutoScroll = true;
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.lblClose, 0, 0);
            this.tlp_Main.Controls.Add(this.flp_Main, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(1100, 531);
            this.tlp_Main.TabIndex = 6;
            // 
            // Pictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1100, 531);
            this.Controls.Add(this.tlp_Main);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pictures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pictures";
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label lblClose;
        private FlowLayoutPanel flp_Main;
        private TableLayoutPanel tlp_Main;
    }
}