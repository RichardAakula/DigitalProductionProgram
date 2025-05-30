using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.ExtraProtocols;

namespace DigitalProductionProgram.Protocols.Slipning_TEF
{
    partial class Slipning_TEF
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
            this.Baserat_På = new ProcesscardBasedOn();
            this.Kommentarer = new Comments();
            this.MainProtocol = new MainProtocol_Slipning_TEF();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.Baserat_På, 0, 2);
            this.tlp_Main.Controls.Add(this.Kommentarer, 0, 1);
            this.tlp_Main.Controls.Add(this.MainProtocol, 0, 0);
            this.tlp_Main.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 628F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlp_Main.Size = new System.Drawing.Size(1022, 871);
            this.tlp_Main.TabIndex = 0;
            // 
            // Baserat_På
            // 
            this.Baserat_På.BackColor = System.Drawing.Color.Black;
            this.Baserat_På.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Baserat_På.Location = new System.Drawing.Point(0, 744);
            this.Baserat_På.Margin = new System.Windows.Forms.Padding(0);
            this.Baserat_På.Name = "Baserat_På";
            this.Baserat_På.Size = new System.Drawing.Size(1022, 127);
            this.Baserat_På.TabIndex = 1024;
            // 
            // Kommentarer
            // 
            this.Kommentarer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Kommentarer.Location = new System.Drawing.Point(1, 629);
            this.Kommentarer.Margin = new System.Windows.Forms.Padding(1);
            this.Kommentarer.Name = "Kommentarer";
            this.Kommentarer.Size = new System.Drawing.Size(1020, 114);
            this.Kommentarer.TabIndex = 1025;
            // 
            // MainProtocol
            // 
            this.MainProtocol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainProtocol.Location = new System.Drawing.Point(1, 1);
            this.MainProtocol.Margin = new System.Windows.Forms.Padding(1);
            this.MainProtocol.Name = "MainProtocol";
            this.MainProtocol.Size = new System.Drawing.Size(1020, 626);
            this.MainProtocol.TabIndex = 1026;
            // 
            // Slipning_TEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1022, 871);
            this.Controls.Add(this.tlp_Main);
            this.Name = "Slipning_TEF";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Slipning TEF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Processkort_Slipning_FormClosing);
            this.tlp_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private ProcesscardBasedOn Baserat_På;
        private Comments Kommentarer;
        public MainProtocol_Slipning_TEF MainProtocol;
    }
}