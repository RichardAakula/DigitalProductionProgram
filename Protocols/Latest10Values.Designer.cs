using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols
{
    partial class Latest10Values
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
            this.panel_MainForm = new System.Windows.Forms.Panel();
            this.label_Latest10Values_Info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Header
            // 
            this.label_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Header.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_Header.Location = new System.Drawing.Point(0, 0);
            this.label_Header.Name = "label_Header";
            this.label_Header.Size = new System.Drawing.Size(350, 18);
            this.label_Header.TabIndex = 0;
            this.label_Header.Text = "Extrudrar";
            this.label_Header.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel_MainForm
            // 
            this.panel_MainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_MainForm.Location = new System.Drawing.Point(0, 0);
            this.panel_MainForm.MinimumSize = new System.Drawing.Size(200, 0);
            this.panel_MainForm.Name = "panel_MainForm";
            this.panel_MainForm.Size = new System.Drawing.Size(350, 137);
            this.panel_MainForm.TabIndex = 1;
            this.panel_MainForm.Click += new System.EventHandler(this.panel_MainForm_Click);
            // 
            // label_Latest10Values_Info
            // 
            this.label_Latest10Values_Info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_Latest10Values_Info.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Latest10Values_Info.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_Latest10Values_Info.Location = new System.Drawing.Point(0, 119);
            this.label_Latest10Values_Info.Name = "label_Latest10Values_Info";
            this.label_Latest10Values_Info.Size = new System.Drawing.Size(350, 18);
            this.label_Latest10Values_Info.TabIndex = 2;
            this.label_Latest10Values_Info.Text = "Klicka i fönstret för att stänga ner det.";
            // 
            // Latest10Values
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(350, 137);
            this.Controls.Add(this.label_Latest10Values_Info);
            this.Controls.Add(this.label_Header);
            this.Controls.Add(this.panel_MainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(350, 0);
            this.Name = "Latest10Values";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SenasteKörningar";
            this.ResumeLayout(false);

        }

        #endregion
        private Label label_Header;
        private Panel panel_MainForm;
        private Label label_Latest10Values_Info;
    }
}