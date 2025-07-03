using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.ControlsManagement
{
    partial class CustomProgressBar
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
            this.pBar_Main = new System.Windows.Forms.ProgressBar();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.lbl_Percent_Main = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Percent_Extra = new System.Windows.Forms.Label();
            this.pBar_Extra = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBar_Main
            // 
            this.pBar_Main.Location = new System.Drawing.Point(52, 64);
            this.pBar_Main.Name = "pBar_Main";
            this.pBar_Main.Size = new System.Drawing.Size(600, 30);
            this.pBar_Main.Step = 1;
            this.pBar_Main.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar_Main.TabIndex = 0;
            // 
            // lbl_Info
            // 
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Info.Font = new System.Drawing.Font("Modern No. 20", 16F);
            this.lbl_Info.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Info.Location = new System.Drawing.Point(57, 11);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(100, 24);
            this.lbl_Info.TabIndex = 1;
            this.lbl_Info.Text = "Loading...";
            // 
            // lbl_Percent_Main
            // 
            this.lbl_Percent_Main.AutoSize = true;
            this.lbl_Percent_Main.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Percent_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_Percent_Main.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Percent_Main.Location = new System.Drawing.Point(57, 102);
            this.lbl_Percent_Main.Name = "lbl_Percent_Main";
            this.lbl_Percent_Main.Size = new System.Drawing.Size(32, 20);
            this.lbl_Percent_Main.TabIndex = 1;
            this.lbl_Percent_Main.Text = "0%";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lbl_Info);
            this.panel1.Controls.Add(this.lbl_Percent_Extra);
            this.panel1.Controls.Add(this.lbl_Percent_Main);
            this.panel1.Controls.Add(this.pBar_Extra);
            this.panel1.Controls.Add(this.pBar_Main);
            this.panel1.Location = new System.Drawing.Point(457, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 194);
            this.panel1.TabIndex = 2;
            // 
            // lbl_Percent_Extra
            // 
            this.lbl_Percent_Extra.AutoSize = true;
            this.lbl_Percent_Extra.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Percent_Extra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_Percent_Extra.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Percent_Extra.Location = new System.Drawing.Point(57, 165);
            this.lbl_Percent_Extra.Name = "lbl_Percent_Extra";
            this.lbl_Percent_Extra.Size = new System.Drawing.Size(32, 20);
            this.lbl_Percent_Extra.TabIndex = 1;
            this.lbl_Percent_Extra.Text = "0%";
            // 
            // pBar_Extra
            // 
            this.pBar_Extra.ForeColor = System.Drawing.Color.Red;
            this.pBar_Extra.Location = new System.Drawing.Point(52, 139);
            this.pBar_Extra.Name = "pBar_Extra";
            this.pBar_Extra.Size = new System.Drawing.Size(600, 22);
            this.pBar_Extra.Step = 1;
            this.pBar_Extra.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar_Extra.TabIndex = 0;
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1663, 913);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressBar";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProgressBar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBar_Main;
        private Label lbl_Info;
        private Label lbl_Percent_Main;
        private Panel panel1;
        private Label lbl_Percent_Extra;
        private System.Windows.Forms.ProgressBar pBar_Extra;
    }
}