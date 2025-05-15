using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Processcards
{
    partial class ProcesscardTemplateSelector
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
            this.label_Header = new System.Windows.Forms.Label();
            this.flp_Buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.label_Green = new System.Windows.Forms.Label();
            this.label_Orange = new System.Windows.Forms.Label();
            this.label_Brown = new System.Windows.Forms.Label();
            this.label_Red = new System.Windows.Forms.Label();
            this.tlp_InfoLabels = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_InfoLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Header
            // 
            this.label_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(113)))), ((int)(((byte)(122)))));
            this.label_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Header.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            this.label_Header.Location = new System.Drawing.Point(0, 0);
            this.label_Header.Name = "label_Header";
            this.label_Header.Size = new System.Drawing.Size(672, 52);
            this.label_Header.TabIndex = 2;
            this.label_Header.Text = "Header:";
            // 
            // flp_Buttons
            // 
            this.flp_Buttons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(113)))), ((int)(((byte)(122)))));
            this.flp_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Buttons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Buttons.Location = new System.Drawing.Point(0, 140);
            this.flp_Buttons.Name = "flp_Buttons";
            this.flp_Buttons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flp_Buttons.Size = new System.Drawing.Size(672, 121);
            this.flp_Buttons.TabIndex = 16;
            // 
            // label_Green
            // 
            this.label_Green.AutoSize = true;
            this.label_Green.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.label_Green.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Green.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label_Green.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.label_Green.Location = new System.Drawing.Point(3, 0);
            this.label_Green.Name = "label_Green";
            this.label_Green.Size = new System.Drawing.Size(666, 22);
            this.label_Green.TabIndex = 2;
            this.label_Green.Text = "Order Ok att starta";
            // 
            // label_Orange
            // 
            this.label_Orange.AutoSize = true;
            this.label_Orange.BackColor = System.Drawing.Color.DarkOrange;
            this.label_Orange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Orange.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label_Orange.ForeColor = System.Drawing.Color.Brown;
            this.label_Orange.Location = new System.Drawing.Point(3, 22);
            this.label_Orange.Name = "label_Orange";
            this.label_Orange.Size = new System.Drawing.Size(666, 22);
            this.label_Orange.TabIndex = 14;
            this.label_Orange.Text = "ArtikelNr utan processkort körd fler än 3 ggr - Processkort behövs - Kontakta arb" +
    "etsledare";
            // 
            // label_Brown
            // 
            this.label_Brown.AutoSize = true;
            this.label_Brown.BackColor = System.Drawing.Color.Brown;
            this.label_Brown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Brown.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label_Brown.ForeColor = System.Drawing.Color.DarkOrange;
            this.label_Brown.Location = new System.Drawing.Point(3, 44);
            this.label_Brown.Name = "label_Brown";
            this.label_Brown.Size = new System.Drawing.Size(666, 22);
            this.label_Brown.TabIndex = 13;
            this.label_Brown.Text = "Processkort under framarbetning och körd fler än 3 gånger - Kontakta arbetsledare" +
    "";
            // 
            // label_Red
            // 
            this.label_Red.AutoSize = true;
            this.label_Red.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.label_Red.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Red.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label_Red.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.label_Red.Location = new System.Drawing.Point(3, 66);
            this.label_Red.Name = "label_Red";
            this.label_Red.Size = new System.Drawing.Size(666, 22);
            this.label_Red.TabIndex = 2;
            this.label_Red.Text = "Ej godkänd av QA";
            // 
            // tlp_InfoLabels
            // 
            this.tlp_InfoLabels.ColumnCount = 1;
            this.tlp_InfoLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_InfoLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_InfoLabels.Controls.Add(this.label_Red, 0, 3);
            this.tlp_InfoLabels.Controls.Add(this.label_Brown, 0, 2);
            this.tlp_InfoLabels.Controls.Add(this.label_Orange, 0, 1);
            this.tlp_InfoLabels.Controls.Add(this.label_Green, 0, 0);
            this.tlp_InfoLabels.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_InfoLabels.Location = new System.Drawing.Point(0, 52);
            this.tlp_InfoLabels.Name = "tlp_InfoLabels";
            this.tlp_InfoLabels.RowCount = 4;
            this.tlp_InfoLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_InfoLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_InfoLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_InfoLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_InfoLabels.Size = new System.Drawing.Size(672, 88);
            this.tlp_InfoLabels.TabIndex = 0;
            // 
            // ProcesscardTemplateSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(113)))), ((int)(((byte)(122)))));
            this.ClientSize = new System.Drawing.Size(672, 261);
            this.Controls.Add(this.flp_Buttons);
            this.Controls.Add(this.tlp_InfoLabels);
            this.Controls.Add(this.label_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ProcesscardTemplateSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseProcesscard_FormClosing);
            this.Load += new System.EventHandler(this.ProcesscardTemplateSelector_Load);
            this.tlp_InfoLabels.ResumeLayout(false);
            this.tlp_InfoLabels.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label_Header;
        private FlowLayoutPanel flp_Buttons;
        private Label label_Green;
        private Label label_Orange;
        private Label label_Brown;
        private Label label_Red;
        private TableLayoutPanel tlp_InfoLabels;
    }
}