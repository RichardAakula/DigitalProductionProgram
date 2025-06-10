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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart_Statistics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chart_Statistics).BeginInit();
            SuspendLayout();
            // 
            // chart_Statistics
            // 
            chart_Statistics.BackColor = Color.Transparent;
            chartArea1.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea1.AxisX.LineColor = Color.Transparent;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineWidth = 0;
            chartArea1.AxisX.MajorTickMark.LineWidth = 0;
            chartArea1.AxisX.TitleForeColor = Color.White;
            chartArea1.AxisX2.TitleForeColor = Color.White;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LineColor = Color.Transparent;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineWidth = 0;
            chartArea1.AxisY.MajorTickMark.LineWidth = 0;
            chartArea1.AxisY.TitleForeColor = Color.White;
            chartArea1.BackColor = Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chart_Statistics.ChartAreas.Add(chartArea1);
            chart_Statistics.Cursor = Cursors.Hand;
            chart_Statistics.Dock = DockStyle.Fill;
            legend1.BackColor = Color.Transparent;
            legend1.BorderColor = Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new Font("Microsoft Sans Serif", 9F);
            legend1.ForeColor = Color.White;
            legend1.IsDockedInsideChartArea = false;
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 11.81818F;
            legend1.Position.Width = 46.71053F;
            legend1.Position.X = 3F;
            chart_Statistics.Legends.Add(legend1);
            chart_Statistics.Location = new Point(0, 0);
            chart_Statistics.Margin = new Padding(4, 3, 4, 3);
            chart_Statistics.Name = "chart_Statistics";
            chart_Statistics.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Color = Color.FromArgb(45, 113, 122);
            series1.CustomProperties = "LabelStyle=Bottom";
            series1.Font = new Font("Arial", 8F);
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.LabelForeColor = Color.FromArgb(239, 228, 177);
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chart_Statistics.Series.Add(series1);
            chart_Statistics.Size = new Size(356, 255);
            chart_Statistics.TabIndex = 0;
            chart_Statistics.Text = "chart1";
            chart_Statistics.MouseClick += panelStatistics_Click;
            chart_Statistics.MouseDown += chart_Statistics_MouseDown;
            // 
            // Statistics_DPP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(chart_Statistics);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Statistics_DPP";
            Size = new Size(356, 255);
            Load += Statistics_DPP_Load;
            ((System.ComponentModel.ISupportInitialize)chart_Statistics).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Statistics;
    }
}
