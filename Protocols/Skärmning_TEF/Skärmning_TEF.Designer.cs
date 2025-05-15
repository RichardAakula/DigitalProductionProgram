using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.Processcards;

namespace DigitalProductionProgram.Protocols.Skärmning_TEF
{
    partial class Skärmning_TEF
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
            this.ProcesskortBaserat_På = new ProcesscardBasedOn();
            this.MainProtocol = new MainProtocol_Skärmning_TEF();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1109F));
            this.tlp_Main.Controls.Add(this.ProcesskortBaserat_På, 0, 1);
            this.tlp_Main.Controls.Add(this.MainProtocol, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(1);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 644F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(1109, 776);
            this.tlp_Main.TabIndex = 0;
            // 
            // ProcesskortBaserat_På
            // 
            this.ProcesskortBaserat_På.BackColor = System.Drawing.Color.Black;
            this.ProcesskortBaserat_På.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcesskortBaserat_På.Location = new System.Drawing.Point(0, 645);
            this.ProcesskortBaserat_På.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.ProcesskortBaserat_På.Name = "ProcesskortBaserat_På";
            this.ProcesskortBaserat_På.Size = new System.Drawing.Size(1109, 131);
            this.ProcesskortBaserat_På.TabIndex = 1033;
            // 
            // MainProtocol
            // 
            this.MainProtocol.Location = new System.Drawing.Point(0, 0);
            this.MainProtocol.Margin = new System.Windows.Forms.Padding(0);
            this.MainProtocol.Name = "MainProtocol";
            this.MainProtocol.Size = new System.Drawing.Size(1109, 644);
            this.MainProtocol.TabIndex = 1034;
            // 
            // Skärmning_TEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(1109, 776);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Skärmning_TEF";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Processkort/Körprotokoll Skärmning TEF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Skärmning_FormClosing);
            this.tlp_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private ProcesscardBasedOn ProcesskortBaserat_På;
        public MainProtocol_Skärmning_TEF MainProtocol;
    }
}