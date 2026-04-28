namespace DigitalProductionProgram.Statistics
{
    partial class Statistics_DPP
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            selectorPanel = new Panel();
            cbStatistics = new DigitalProductionProgram.ControlsManagement.DropdownSelector();
            chartHost = new Panel();
            chart_Stats = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            selectorPanel.SuspendLayout();
            chartHost.SuspendLayout();
            SuspendLayout();
            // 
            // selectorPanel
            // 
            selectorPanel.BackColor = Color.FromArgb(35, 35, 35);
            selectorPanel.Controls.Add(cbStatistics);
            selectorPanel.Dock = DockStyle.Top;
            selectorPanel.Location = new Point(0, 0);
            selectorPanel.Name = "selectorPanel";
            selectorPanel.Padding = new Padding(4);
            selectorPanel.Size = new Size(356, 33);
            selectorPanel.TabIndex = 0;
            selectorPanel.Visible = false;
            // 
            // cbStatistics
            // 
            cbStatistics.BackColor = Color.FromArgb(48, 48, 48);
            cbStatistics.Dock = DockStyle.Fill;
            cbStatistics.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            cbStatistics.ForeColor = Color.White;
            cbStatistics.Location = new Point(4, 4);
            cbStatistics.Name = "cbStatistics";
            cbStatistics.Size = new Size(348, 25);
            cbStatistics.TabIndex = 0;
            cbStatistics.SelectedIndexChanged += cbStatistics_SelectedIndexChanged;
            // 
            // chartHost
            // 
            chartHost.Controls.Add(chart_Stats);
            chartHost.Dock = DockStyle.Fill;
            chartHost.Location = new Point(0, 33);
            chartHost.Name = "chartHost";
            chartHost.Size = new Size(356, 222);
            chartHost.TabIndex = 1;
            // 
            // chart_Stats
            // 
            chart_Stats.BackColor = Color.FromArgb(35, 35, 35);
            chart_Stats.Dock = DockStyle.Fill;
            chart_Stats.Location = new Point(0, 0);
            chart_Stats.Name = "chart_Stats";
            chart_Stats.Size = new Size(356, 222);
            chart_Stats.TabIndex = 0;
            chart_Stats.MouseDown += chart_Statistics_MouseDown;
            // 
            // Statistics_DPP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(chartHost);
            Controls.Add(selectorPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Statistics_DPP";
            Size = new Size(356, 255);
            Load += Statistics_DPP_Load;
            selectorPanel.ResumeLayout(false);
            chartHost.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel selectorPanel;
        private DigitalProductionProgram.ControlsManagement.DropdownSelector cbStatistics;
        private Panel chartHost;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chart_Stats;
    }
}
