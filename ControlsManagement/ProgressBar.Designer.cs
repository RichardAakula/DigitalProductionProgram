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
            pBar_Main = new ProgressBar();
            lbl_Info = new Label();
            lbl_Percent_Main = new Label();
            panel_Main = new Panel();
            lbl_Percent_Extra = new Label();
            pBar_Extra = new ProgressBar();
            panel_Main.SuspendLayout();
            SuspendLayout();
            // 
            // pBar_Main
            // 
            pBar_Main.Location = new Point(61, 74);
            pBar_Main.Margin = new Padding(4, 3, 4, 3);
            pBar_Main.Name = "pBar_Main";
            pBar_Main.Size = new Size(700, 35);
            pBar_Main.Step = 1;
            pBar_Main.Style = ProgressBarStyle.Continuous;
            pBar_Main.TabIndex = 0;
            // 
            // lbl_Info
            // 
            lbl_Info.AutoSize = true;
            lbl_Info.BackColor = Color.Transparent;
            lbl_Info.Font = new Font("Modern No. 20", 16F);
            lbl_Info.ForeColor = Color.FromArgb(255, 235, 156);
            lbl_Info.Location = new Point(66, 13);
            lbl_Info.Margin = new Padding(4, 0, 4, 0);
            lbl_Info.Name = "lbl_Info";
            lbl_Info.Size = new Size(100, 24);
            lbl_Info.TabIndex = 1;
            lbl_Info.Text = "Loading...";
            // 
            // lbl_Percent_Main
            // 
            lbl_Percent_Main.AutoSize = true;
            lbl_Percent_Main.BackColor = Color.Transparent;
            lbl_Percent_Main.Font = new Font("Microsoft Sans Serif", 16F);
            lbl_Percent_Main.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_Percent_Main.Location = new Point(66, 118);
            lbl_Percent_Main.Margin = new Padding(4, 0, 4, 0);
            lbl_Percent_Main.Name = "lbl_Percent_Main";
            lbl_Percent_Main.Size = new Size(44, 26);
            lbl_Percent_Main.TabIndex = 1;
            lbl_Percent_Main.Text = "0%";
            // 
            // panel_Main
            // 
            panel_Main.BackColor = Color.FromArgb(6, 81, 87);
            panel_Main.Controls.Add(lbl_Info);
            panel_Main.Controls.Add(lbl_Percent_Extra);
            panel_Main.Controls.Add(lbl_Percent_Main);
            panel_Main.Controls.Add(pBar_Extra);
            panel_Main.Controls.Add(pBar_Main);
            panel_Main.Location = new Point(533, 393);
            panel_Main.Margin = new Padding(4, 3, 4, 3);
            panel_Main.Name = "panel_Main";
            panel_Main.Size = new Size(817, 224);
            panel_Main.TabIndex = 2;
            // 
            // lbl_Percent_Extra
            // 
            lbl_Percent_Extra.AutoSize = true;
            lbl_Percent_Extra.BackColor = Color.Transparent;
            lbl_Percent_Extra.Font = new Font("Microsoft Sans Serif", 16F);
            lbl_Percent_Extra.ForeColor = Color.FromArgb(255, 235, 156);
            lbl_Percent_Extra.Location = new Point(66, 190);
            lbl_Percent_Extra.Margin = new Padding(4, 0, 4, 0);
            lbl_Percent_Extra.Name = "lbl_Percent_Extra";
            lbl_Percent_Extra.Size = new Size(44, 26);
            lbl_Percent_Extra.TabIndex = 1;
            lbl_Percent_Extra.Text = "0%";
            // 
            // pBar_Extra
            // 
            pBar_Extra.ForeColor = Color.Red;
            pBar_Extra.Location = new Point(61, 160);
            pBar_Extra.Margin = new Padding(4, 3, 4, 3);
            pBar_Extra.Name = "pBar_Extra";
            pBar_Extra.Size = new Size(700, 25);
            pBar_Extra.Step = 1;
            pBar_Extra.Style = ProgressBarStyle.Continuous;
            pBar_Extra.TabIndex = 0;
            // 
            // CustomProgressBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1940, 1053);
            Controls.Add(panel_Main);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "CustomProgressBar";
            Opacity = 0.9D;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ProgressBar";
            WindowState = FormWindowState.Maximized;
            panel_Main.ResumeLayout(false);
            panel_Main.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private Label lbl_Info;
        private Label lbl_Percent_Main;
        private Panel panel_Main;
        private Label lbl_Percent_Extra;
        private System.Windows.Forms.ProgressBar pBar_Extra;
        public ProgressBar pBar_Main;
    }
}