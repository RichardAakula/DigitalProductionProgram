using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace DigitalProductionProgram.ControlsManagement
{
    public partial class CustomProgressBar : Form
    {
        private double Value;
        private double Maximum = 100;
        [DebuggerStepThrough]
        public CustomProgressBar(int Total_Bars = 1)
        {
            InitializeComponent();
          
            panel1.Left = (int)Screen.PrimaryScreen.Bounds.Width / 2 - panel1.Width / 2;
            panel1.Top = (int)Screen.PrimaryScreen.Bounds.Height / 2 - panel1.Height / 2;

            switch (Total_Bars)
            {
                case 0:
                    pBar_Extra.Visible = false;
                    pBar_Main.Visible = false;
                    lbl_Percent_Extra.Visible = false;
                    lbl_Percent_Main.Visible = false;
                    Height = 80;
                    break;
                case 1:
                    pBar_Extra.Visible = false;
                    lbl_Percent_Extra.Visible = false;
                    Height = 60;
                    break;
            }
            
        }
        [DebuggerStepThrough]
        public void Set_ValueProgressBar(double value, string? info, double extraValue = 0)
        {
            value = Math.Max(0, Math.Min(100, value));

            // Start, mid, end
            var red = Color.FromArgb(156, 0, 6);
            var yellow = Color.FromArgb(255, 235, 156);
            var green = Color.FromArgb(0, 97, 0);

            if (value < 50)
            {
                // Röd -> Gul
                double ratio = value / 50.0;
                return LerpColor(red, yellow, ratio);
            }
            else
            {
                // Gul -> Grön
                double ratio = (value - 50) / 50.0;
                return LerpColor(yellow, green, ratio);
            }
        }

        private Color LerpColor(Color from, Color to, double t)
        {
            t = Math.Max(0, Math.Min(1, t));
            int r = (int)(from.R + (to.R - from.R) * t);
            int g = (int)(from.G + (to.G - from.G) * t);
            int b = (int)(from.B + (to.B - from.B) * t);
            return Color.FromArgb(r, g, b);
        }

        public void Set_ValueProgressBar(double value, string? info, double extraValue = 0, bool isOkRefresh = false)
        {
            value = Math.Max(0, Math.Min(100, value));
            extraValue = Math.Max(0, Math.Min(100, extraValue));
            // Sätt main progress
            pBar_Main.Value = (int)value;
            lbl_Percent_Main.Text = $"{value:0.00}%";

            if (extraValue > 0 && extraValue < 101)
            {
               // pBar_Extra.Value = (int)extraValue;
                pBar_Extra.Value = (int)(extraValue * (pBar_Extra.Maximum - pBar_Extra.Minimum) / 100.0);
                lbl_Percent_Extra.Text = $"{extraValue:0.00}%";
            }

            Refresh();
        }

        public static void close()
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "ProgressBar")
                        form.Close();
                }
            }
            catch
            {
                try
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.Name == "ProgressBar")
                            form.Close();
                    }
                }
                catch
                {
                    Debug.WriteLine("Försöker stänga ProgressBar");
                }
            }

        }
    }
}
