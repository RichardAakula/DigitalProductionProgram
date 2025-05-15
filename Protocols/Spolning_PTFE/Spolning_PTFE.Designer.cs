
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Spolning_PTFE
{
    partial class Spolning_PTFE
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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.Kommentarer = new Comments();
            this.MainProtocol = new MainProtocol_Spolning_PTFE();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.Kommentarer, 0, 1);
            this.tlp_Main.Controls.Add(this.MainProtocol, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(1141, 701);
            this.tlp_Main.TabIndex = 0;
            // 
            // Kommentarer
            // 
            this.Kommentarer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Kommentarer.Location = new System.Drawing.Point(1, 602);
            this.Kommentarer.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.Kommentarer.Name = "Kommentarer";
            this.Kommentarer.Size = new System.Drawing.Size(1140, 98);
            this.Kommentarer.TabIndex = 3;
            // 
            // MainProtocol
            // 
            this.MainProtocol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainProtocol.Location = new System.Drawing.Point(0, 0);
            this.MainProtocol.Margin = new System.Windows.Forms.Padding(0);
            this.MainProtocol.Name = "MainProtocol";
            this.MainProtocol.Size = new System.Drawing.Size(1141, 601);
            this.MainProtocol.TabIndex = 4;
            // 
            // Spolning_PTFE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1141, 701);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Spolning_PTFE";
            this.Text = "Spolning PTFE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Spolning_PTFE_FormClosing);
            this.Load += new System.EventHandler(this.Protocol_Spolning_Load);
            this.tlp_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Comments Kommentarer;
        private MainProtocol_Spolning_PTFE MainProtocol;
    }
}