
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class MonitorUsers
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
            flp_List = new DoubleBufferedFlowLayoutPanel();
            chart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            SuspendLayout();
            // 
            // flp_List
            // 
            flp_List.AutoScroll = true;
            flp_List.BackColor = Color.FromArgb(25, 25, 25);
            flp_List.Dock = DockStyle.Top;
            flp_List.FlowDirection = FlowDirection.TopDown;
            flp_List.Location = new Point(0, 0);
            flp_List.Margin = new Padding(0);
            flp_List.Name = "flp_List";
            flp_List.Size = new Size(1893, 535);
            flp_List.TabIndex = 0;
            flp_List.WrapContents = false;
            // 
            // chart
            // 
            chart.BackColor = Color.FromArgb(6, 81, 87);
            chart.Dock = DockStyle.Fill;
            chart.Location = new Point(0, 535);
            chart.Name = "chart";
            chart.Size = new Size(1893, 474);
            chart.TabIndex = 1;
            // 
            // MonitorUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            Controls.Add(chart);
            Controls.Add(flp_List);
            Margin = new Padding(0);
            Name = "MonitorUsers";
            Size = new Size(1893, 1009);
            ResumeLayout(false);

        }

        #endregion
        //private FlowLayoutPanel flp_List;
        public System.Windows.Forms.Timer timer_Update;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chart;
    }
}
