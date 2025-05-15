using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.Processcards;

namespace DigitalProductionProgram.Protocols.Svetsning_TEF
{
    partial class Svetsning_TEF
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
            this.Processkort_BaseratPå = new ProcesscardBasedOn();
            this.Kommentarer = new Comments();
            this.MainProtocol = new MainProtocol_Svetsning_TEF();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 826F));
            this.tlp_Main.Controls.Add(this.Processkort_BaseratPå, 0, 2);
            this.tlp_Main.Controls.Add(this.Kommentarer, 0, 1);
            this.tlp_Main.Controls.Add(this.MainProtocol, 0, 0);
            this.tlp_Main.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 797F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlp_Main.Size = new System.Drawing.Size(826, 976);
            this.tlp_Main.TabIndex = 0;
            // 
            // Processkort_BaseratPå
            // 
            this.Processkort_BaseratPå.BackColor = System.Drawing.Color.Black;
            this.Processkort_BaseratPå.Cursor = System.Windows.Forms.Cursors.Default;
            this.Processkort_BaseratPå.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Processkort_BaseratPå.Location = new System.Drawing.Point(0, 901);
            this.Processkort_BaseratPå.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Processkort_BaseratPå.Name = "Processkort_BaseratPå";
            this.Processkort_BaseratPå.Size = new System.Drawing.Size(826, 75);
            this.Processkort_BaseratPå.TabIndex = 1025;
            // 
            // Kommentarer
            // 
            this.Kommentarer.Cursor = System.Windows.Forms.Cursors.Default;
            this.Kommentarer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Kommentarer.Location = new System.Drawing.Point(1, 798);
            this.Kommentarer.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.Kommentarer.Name = "Kommentarer";
            this.Kommentarer.Size = new System.Drawing.Size(825, 102);
            this.Kommentarer.TabIndex = 1026;
            // 
            // MainProtocol
            // 
            this.MainProtocol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainProtocol.Location = new System.Drawing.Point(0, 0);
            this.MainProtocol.Margin = new System.Windows.Forms.Padding(0);
            this.MainProtocol.Name = "MainProtocol";
            this.MainProtocol.Size = new System.Drawing.Size(826, 797);
            this.MainProtocol.TabIndex = 1027;
            // 
            // Svetsning_TEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(826, 976);
            this.Controls.Add(this.tlp_Main);
            this.Name = "Svetsning_TEF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Körprotokoll / Processkort - Svetsning, TEF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Processkort_Svetsning_FormClosing);
            this.tlp_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlp_Main;
        private ProcesscardBasedOn Processkort_BaseratPå;
        private Comments Kommentarer;
        private MainProtocol_Svetsning_TEF MainProtocol;
    }
}