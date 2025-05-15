using System;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Help
{
    public partial class InfoText_Image : Form
    {
        

        public InfoText_Image(Image img, string url)
        {
            InitializeComponent();

            if (img != null)
            {
                tlp_Main.BackgroundImage = img;
                Width = img.Width;
                Height = img.Height;
                //mp_Video.Visible = false;
                _ = Activity.Stop($"Tittat på Bild - {img}");
            }
            if (url != null)
            {
               // mp_Video.Dock = DockStyle.Fill;
                WindowState = FormWindowState.Maximized;
                //  mp_Video.Visible = true;
                // mp_Video.URL = url;
                _ = Activity.Stop($"Tittat på Video {url}");
            }
            Points.Add_Points(1, "Klickar på bild vid Infotext om bild finns.");

        }

       

        private void InfoText_Image_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InfoText_Image_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private void lbl_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
