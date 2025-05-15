using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.Processcards;

namespace DigitalProductionProgram.Protocols.Kragning_TEF
{
    partial class Kragning_TEF
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
            this.Kommentarer = new Comments();
            this.BaseratPå = new ProcesscardBasedOn();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.MainProtocol = new MainProtocol_Kragning_TEF();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Kommentarer
            // 
            this.Kommentarer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Kommentarer.Location = new System.Drawing.Point(1, 673);
            this.Kommentarer.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.Kommentarer.Name = "Kommentarer";
            this.Kommentarer.Size = new System.Drawing.Size(709, 145);
            this.Kommentarer.TabIndex = 909;
            // 
            // BaseratPå
            // 
            this.BaseratPå.BackColor = System.Drawing.Color.Black;
            this.BaseratPå.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseratPå.Location = new System.Drawing.Point(0, 820);
            this.BaseratPå.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.BaseratPå.Name = "BaseratPå";
            this.BaseratPå.Size = new System.Drawing.Size(710, 104);
            this.BaseratPå.TabIndex = 908;
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.White;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlp_Main.Controls.Add(this.BaseratPå, 0, 2);
            this.tlp_Main.Controls.Add(this.Kommentarer, 0, 1);
            this.tlp_Main.Controls.Add(this.MainProtocol, 0, 0);
            this.tlp_Main.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 672F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tlp_Main.Size = new System.Drawing.Size(710, 924);
            this.tlp_Main.TabIndex = 0;
            // 
            // MainProtocol
            // 
            this.MainProtocol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainProtocol.Location = new System.Drawing.Point(1, 1);
            this.MainProtocol.Margin = new System.Windows.Forms.Padding(1);
            this.MainProtocol.Name = "MainProtocol";
            this.MainProtocol.Size = new System.Drawing.Size(708, 670);
            this.MainProtocol.TabIndex = 910;
            // 
            // Kragning_TEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(710, 924);
            this.Controls.Add(this.tlp_Main);
            this.Name = "Kragning_TEF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Körprotokoll / Processkort - Kragning, TEF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Körprotokoll_Kragning_FormClosing);
            this.tlp_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Comments Kommentarer;
        private ProcesscardBasedOn BaseratPå;
        private TableLayoutPanel tlp_Main;
        public MainProtocol_Kragning_TEF MainProtocol;
    }
}