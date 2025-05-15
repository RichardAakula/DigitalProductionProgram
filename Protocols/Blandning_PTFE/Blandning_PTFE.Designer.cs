using System.ComponentModel;

namespace DigitalProductionProgram.Protocols.Blandning_PTFE
{
    partial class Blandning_PTFE
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
            this.MainProtocol = new MainProtocol_Blandning_PTFE();
            this.SuspendLayout();
            // 
            // MainProtocol
            // 
            this.MainProtocol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainProtocol.Location = new System.Drawing.Point(0, 0);
            this.MainProtocol.Margin = new System.Windows.Forms.Padding(0);
            this.MainProtocol.Name = "MainProtocol";
            this.MainProtocol.Size = new System.Drawing.Size(1004, 790);
            this.MainProtocol.TabIndex = 0;
            // 
            // Blandning_PTFE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1004, 790);
            this.Controls.Add(this.MainProtocol);
            this.Name = "Blandning_PTFE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Blandning PTFE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Blandning_PTFE_FormClosing);
            this.Load += new System.EventHandler(this.Protocol_Blandning_PTFE_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MainProtocol_Blandning_PTFE MainProtocol;
    }
}