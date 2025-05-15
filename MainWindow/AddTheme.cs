using System;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.OrderManagement;


namespace DigitalProductionProgram.MainWindow
{
    public partial class AddTheme : Form
    {
        public AddTheme()
        {
            InitializeComponent();
            Fill_cb_Themes();
        }

        private void Fill_cb_Themes()
        {
            cb_Theme.DataSource = Enum.GetValues(typeof(Teman.Themes));
        }

       

        private void btn_AddProfilePicture_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                // Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|All Files(*.*)|*.*|PNG Files(*.png|*.png)",
                Filter = "All Files(*.*)|*.*",
                Title = $"Välj en bild som du vill använda till temat {cb_Theme.Text}"
            };
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var pictures = dlg.FileNames;

                foreach (var picture in pictures)
                {
                    var fs = new FileStream(picture, FileMode.Open, FileAccess.Read);
                    var br = new BinaryReader(fs);
                    var ProfilePicture = br.ReadBytes((int)fs.Length);

                    var ms = new MemoryStream(ProfilePicture);
                    BackgroundImage = Image.FromStream(ms);
                    Thread.Sleep(1000);
                    Refresh();
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        var query = @"
                   
                        INSERT INTO [Settings].Themes (Theme, Image)
                        VALUES (@theme, @image)";
                        con.Open();
                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@image", ProfilePicture);
                        cmd.Parameters.AddWithValue("@theme", cb_Theme.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Alla bilder är uppladdade.");
            }
        }
    }
}
