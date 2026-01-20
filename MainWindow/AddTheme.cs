using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.OrderManagement;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;


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
            using var dlg = new OpenFileDialog
            {
                Filter = "All Files(*.*)|*.*",
                Title = $"Välj en bild som du vill använda till temat {cb_Theme.Text}",
                Multiselect = true
            };

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var pictures = dlg.FileNames;

            foreach (var picture in pictures)
            {
                // Läs filen som byte-array
                var profilePicture = File.ReadAllBytes(picture);

                // Visa bilden i UI
                using var ms = new MemoryStream(profilePicture);
                BackgroundImage?.Dispose(); // frigör eventuell tidigare bild
                BackgroundImage = Image.FromStream(ms);
                Refresh();

                // Spara i databasen med ExecuteSafe
                Database.ExecuteSafe(con =>
                {
                    const string query = @"
                        INSERT INTO [Settings].Themes (Theme, Image)
                        VALUES (@theme, @image)";

                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@theme", SqlDbType.NVarChar, 50).Value = cb_Theme.Text;
                    cmd.Parameters.Add("@image", SqlDbType.VarBinary, profilePicture.Length).Value = profilePicture;

                    cmd.ExecuteNonQuery();
                });
            }

            MessageBox.Show("Alla bilder är uppladdade.");
        }

    }
}
