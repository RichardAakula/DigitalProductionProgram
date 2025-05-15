using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    public partial class ServerStatus : UserControl
    {
        public static string DPP_ServerStatus;

        public ServerStatus()
        {
            InitializeComponent();
        }
        public static void DrawPanelMonitorStatus(Panel panel, Color color)
        {
            panel.Paint += (sender, e) =>
            {
                using (var g = e.Graphics)
                {
                    // Define the points of the triangle
                    Point[] trianglePoints =
                    {
                        new Point(0, 0),
                        new Point(panel.Width / 2, panel.Height),
                        new Point(panel.Width, 0)
                    };

                    // Draw the filled triangle
                    using (Brush brush = new SolidBrush(color))
                    {
                        try
                        {
                            g.FillPolygon(brush, trianglePoints);
                            // g.DrawPolygon(Pens.DarkGreen, trianglePoints);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception);
                        }
                    }

                }
            };
        }
        public void DrawPanelDPP_ServerStatus(long time)
        {
            Color color = Color.Aqua;
            if (time > 100)
                color = Color.BlueViolet;

            panel_DPP_ServerStatus.Paint += (sender, e) =>
            {
                using (var g = e.Graphics)
                {
                    // Define the points of the triangle
                    Point[] trianglePoints =
                    {
                        new Point(0, 0),
                        new Point(panel_DPP_ServerStatus.Width / 2, panel_DPP_ServerStatus.Height),
                        new Point(panel_DPP_ServerStatus.Width, 0)
                    };

                    // Draw the filled triangle
                    using (Brush brush = new SolidBrush(color))
                    {
                        try
                        {
                            g.FillPolygon(brush, trianglePoints);
                            // g.DrawPolygon(Pens.DarkGreen, trianglePoints);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception);
                        }
                    }

                }
            };
        }

        private void MonitorStatus_MouseHover(object sender, EventArgs e)
        {
            var tooltip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };
            tooltip.SetToolTip(lbl_MonitorStatus, Monitor.Monitor.MonitorStatus);
        }

        private void DPP_Status_MouseHover(object sender, EventArgs e)
        {
            var tooltip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };
            tooltip.SetToolTip(lbl_DPP_Status,DPP_ServerStatus);
        }
    }
}
