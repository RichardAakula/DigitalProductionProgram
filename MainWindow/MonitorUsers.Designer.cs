
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
            tlp_Main = new TableLayoutPanel();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // flp_List
            // 
            flp_List.AutoScroll = true;
            flp_List.BackColor = Color.FromArgb(25, 25, 25);
            flp_List.Dock = DockStyle.Fill;
            flp_List.FlowDirection = FlowDirection.TopDown;
            flp_List.Location = new Point(0, 30);
            flp_List.Margin = new Padding(0);
            flp_List.Name = "flp_List";
            flp_List.Size = new Size(622, 979);
            flp_List.TabIndex = 0;
            flp_List.WrapContents = false;
            flp_List.SizeChanged += flp_List_SizeChanged;
            // 
            // chart
            // 
            chart.BackColor = Color.FromArgb(6, 81, 87);
            chart.Dock = DockStyle.Fill;
            chart.Location = new Point(625, 3);
            chart.Name = "chart";
            tlp_Main.SetRowSpan(chart, 2);
            chart.Size = new Size(1265, 1003);
            chart.TabIndex = 1;
            // 
            // cb_Monitor
            // 
            cb_Monitor.Dock = DockStyle.Left;
            cb_Monitor.FormattingEnabled = true;
            cb_Monitor.Items.AddRange(new object[] { "001.1", "003.1", "010.1", "012.1" });
            cb_Monitor.Location = new Point(3, 3);
            cb_Monitor.Name = "cb_Monitor";
            cb_Monitor.Size = new Size(161, 23);
            cb_Monitor.TabIndex = 0;
            cb_Monitor.SelectedIndexChanged += cb_Monitor_SelectedIndexChanged;
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 622F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.Controls.Add(cb_Monitor, 0, 0);
            tlp_Main.Controls.Add(chart, 1, 0);
            tlp_Main.Controls.Add(flp_List, 0, 1);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 2.97324085F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 97.02676F));
            tlp_Main.Size = new Size(1893, 1009);
            tlp_Main.TabIndex = 3;
            tlp_Main.Paint += tlp_Main_Paint;
            // 
            // MonitorUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            Controls.Add(tlp_Main);
            Margin = new Padding(0);
            Name = "MonitorUsers";
            Size = new Size(1893, 1009);
            tlp_Main.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        //private FlowLayoutPanel flp_List;
        public System.Windows.Forms.Timer timer_Update;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chart;
        private ComboBox cb_Monitor;
        private TableLayoutPanel tlp_Main;
    }
}
