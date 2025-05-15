using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Help
{
    partial class Warning
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
            this.lbl_Warning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Warning
            // 
            this.lbl_Warning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_Warning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Warning.Font = new System.Drawing.Font("Lucida Sans", 38.25F);
            this.lbl_Warning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(101)))), ((int)(((byte)(0)))));
            this.lbl_Warning.Location = new System.Drawing.Point(0, 0);
            this.lbl_Warning.Name = "lbl_Warning";
            this.lbl_Warning.Size = new System.Drawing.Size(1136, 165);
            this.lbl_Warning.TabIndex = 0;
            this.lbl_Warning.Text = "Warning";
            this.lbl_Warning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Warning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1136, 165);
            this.Controls.Add(this.lbl_Warning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Warning";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Warning";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        public Label lbl_Warning;
    }
}