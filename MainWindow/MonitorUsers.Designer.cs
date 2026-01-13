
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
            cb_Monitor = new ComboBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flp_List
            // 
            flp_List.AutoScroll = true;
            flp_List.BackColor = Color.FromArgb(25, 25, 25);
            flp_List.Dock = DockStyle.Top;
            flp_List.FlowDirection = FlowDirection.TopDown;
            flp_List.Location = new Point(0, 36);
            flp_List.Margin = new Padding(0);
            flp_List.Name = "flp_List";
            flp_List.Size = new Size(1893, 422);
            flp_List.TabIndex = 0;
            flp_List.WrapContents = false;
            flp_List.SizeChanged += flp_List_SizeChanged;
            // 
            // chart
            // 
            chart.BackColor = Color.FromArgb(6, 81, 87);
            chart.Dock = DockStyle.Fill;
            chart.Location = new Point(0, 458);
            chart.Name = "chart";
            chart.Size = new Size(1893, 551);
            chart.TabIndex = 1;
            // 
            // cb_Monitor
            // 
            cb_Monitor.FormattingEnabled = true;
            cb_Monitor.Items.AddRange(new object[] { "001.1", "003.1", "010.1", "012.1" });
            cb_Monitor.Location = new Point(3, 3);
            cb_Monitor.Name = "cb_Monitor";
            cb_Monitor.Size = new Size(152, 23);
            cb_Monitor.TabIndex = 0;
            cb_Monitor.SelectedIndexChanged += cb_Monitor_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(cb_Monitor);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1893, 36);
            panel1.TabIndex = 2;
            // 
            // MonitorUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            Controls.Add(chart);
            Controls.Add(flp_List);
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "MonitorUsers";
            Size = new Size(1893, 1009);
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        //private FlowLayoutPanel flp_List;
        public System.Windows.Forms.Timer timer_Update;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chart;
        private ComboBox cb_Monitor;
        private Panel panel1;
    }
}
