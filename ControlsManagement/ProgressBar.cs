using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace DigitalProductionProgram.ControlsManagement
{
    public partial class ProgressBar : Form
    {
       
        public ProgressBar(int Total_Bars = 1)
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
                    Height = 130;
                    break;
            }
            
        }
        public void Set_ValueProgressBar(double value, string? info, double extraValue = 0)
        {
            if (value < 101)
                pBar_Main.Value = (int)value;
            lbl_Info.Text = info;
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
