using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.EasterEggs;

namespace DigitalProductionProgram.MainWindow
{
    public partial class ServerStatus : UserControl
    {
        public static string? DPP_ServerStatus;
        private Main_Form? mainForm;

        public ServerStatus()
        {
            InitializeComponent();
        }
        public void SetMainForm(Main_Form form)
        {
            mainForm = form;
        }
        public static void DrawPanelMonitorStatus(Panel panel, Color color)
        {
            //panel.Paint += (sender, e) =>
            //{
            //    if (panel.Width <= 0 || panel.Height <= 0)
            //        return; // Undvik crash

            //    using var g = e.Graphics;
            //    Point[] trianglePoints =
            //    {
            //        new Point(0, 0),
            //        new Point(panel.Width / 2, panel.Height),
            //        new Point(panel.Width, 0)
            //    };

            //    using Brush brush = new SolidBrush(color);
            //    try
            //    {
            //        g.FillPolygon(brush, trianglePoints);
            //    }
            //    catch (Exception ex)
            //    {
            //        Debug.WriteLine($"Fel i DrawPanelMonitorStatus: {ex.Message}");
            //    }
            //};

        }
        public void DrawPanelDPP_ServerStatus(long time)
        {
            Color color = Color.Aqua;
            if (time > 100)
                color = Color.BlueViolet;

            panel_DPP_ServerStatus.Paint += (sender, e) =>
            {
                using var g = e.Graphics;
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
            tooltip.SetToolTip(lbl_DPP_Status, DPP_ServerStatus);
        }

        private void lbl_MonitorStatus_Click(object sender, EventArgs e)
        {
            if (mainForm != null && EasterEgg_HighScore.IsOkStartGame("Flying Easter Egg", mainForm))
            {
                FlyingEasterEgg flying = new FlyingEasterEgg(mainForm);
                flying.StartGame();
            }
        }
    }
}
