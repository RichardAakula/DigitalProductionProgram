using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DigitalProductionProgram.User
{
    partial class WhoIsLoggedIn
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
            flp_Users = new FlowLayoutPanel();
            panel_Chart = new Panel();
            SuspendLayout();
            // 
            // flp_Users
            // 
            flp_Users.Dock = DockStyle.Top;
            flp_Users.Location = new Point(0, 0);
            flp_Users.Margin = new Padding(4, 3, 4, 3);
            flp_Users.Name = "flp_Users";
            flp_Users.Size = new Size(1917, 625);
            flp_Users.TabIndex = 858;
            // 
            // panel_Chart
            // 
            panel_Chart.Dock = DockStyle.Fill;
            panel_Chart.Location = new Point(0, 625);
            panel_Chart.Name = "panel_Chart";
            panel_Chart.Size = new Size(1917, 191);
            panel_Chart.TabIndex = 859;
            // 
            // WhoIsLoggedIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Black;
            ClientSize = new Size(1917, 816);
            Controls.Add(panel_Chart);
            Controls.Add(flp_Users);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "WhoIsLoggedIn";
            Opacity = 0.96D;
            Text = "Inloggad";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);

        }

        #endregion
        private FlowLayoutPanel flp_Users;
        private Panel panel_Chart;
    }
}