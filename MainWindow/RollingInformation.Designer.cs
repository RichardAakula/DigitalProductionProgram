
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class RollingInformation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            panel_Information = new Panel();
            lbl_Tips = new Label();
            timer_MoveLabel = new System.Windows.Forms.Timer(components);
            panel_Information.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Information
            // 
            panel_Information.BackColor = Color.Transparent;
            panel_Information.Controls.Add(lbl_Tips);
            panel_Information.Dock = DockStyle.Fill;
            panel_Information.ForeColor = Color.White;
            panel_Information.Location = new Point(0, 0);
            panel_Information.Margin = new Padding(0);
            panel_Information.Name = "panel_Information";
            panel_Information.Size = new Size(1156, 46);
            panel_Information.TabIndex = 892;
            // 
            // lbl_Tips
            // 
            lbl_Tips.AutoSize = true;
            lbl_Tips.BackColor = Color.Transparent;
            lbl_Tips.Font = new Font("Palatino Linotype", 13.25F);
            lbl_Tips.ForeColor = Color.Gold;
            lbl_Tips.Location = new Point(8, 4);
            lbl_Tips.Margin = new Padding(4, 0, 4, 0);
            lbl_Tips.MaximumSize = new Size(5833, 35);
            lbl_Tips.Name = "lbl_Tips";
            lbl_Tips.RightToLeft = RightToLeft.No;
            lbl_Tips.Size = new Size(46, 30);
            lbl_Tips.TabIndex = 571;
            lbl_Tips.Text = "Tips:";
            lbl_Tips.TextAlign = ContentAlignment.TopCenter;
            lbl_Tips.UseCompatibleTextRendering = true;
            // 
            // timer_MoveLabel
            // 
            timer_MoveLabel.Enabled = true;
            timer_MoveLabel.Interval = 15000;
            timer_MoveLabel.Tick += timer_MoveLabel_Tick;
            // 
            // Main_RollingInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panel_Information);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main_RollingInformation";
            Size = new Size(1156, 46);
            Load += Main_RollingInformation_Load;
            panel_Information.ResumeLayout(false);
            panel_Information.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private Panel panel_Information;
        public Label lbl_Tips;
        private System.Windows.Forms.Timer timer_MoveLabel;
    }
}
