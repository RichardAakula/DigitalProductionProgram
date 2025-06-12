using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System.Data;
using DigitalProductionProgram.MainWindow;

namespace DigitalProductionProgram.EasterEggs
{
    public partial class EasterEgg_2 : Form
    {
        private static string Comment(int distance)
        {
            if (distance is > 0 and < 50)
                return "Wow!! Utopiskt!!";
            if (distance is > 49 and < 70)
                return "Gudomligt bra!!";
            if (distance is > 69 and < 100)
                return "Fantastiskt bra!!";
            if (distance is > 99 and < 200)
                return "Ganska bra!!";
            if (distance is > 199 and < 300)
                return "Hyfsat bra!";
            if (distance is > 299 and < 400)
                return "Ok";
            if (distance is > 399 and < 500)
                return "Mnjaa..Det där var nog inte så nära";
            if (distance is > 499 and < 600)
                return "Hoppsan, sikta du ens?";

            return "eeeehh...??? Okej?";
        }
        private static int Points(int distance)
        {
            var points = 1000 - distance;
            return points > 0 ? points : 0;
        }
        public static int Antal_Spel
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT COUNT(*) FROM Easter_Egg_Points WHERE Namn = @namn AND CAST (Datum AS date) = @date AND Game = 'Easter Egg 2'";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@namn", Person.Name);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value is null)
                    return 0;
                return (int)value;
            }
        }
        public static int Antal_Spelare_Som_Spelat
        {
            get
            {
                var ctr = 0;
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT DISTINCT Namn FROM Easter_Egg_Points WHERE Namn <> @namn AND Game = 'Easter Egg 2'";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@namn", Person.Name);
                con.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    ctr++;
                return ctr;
            }
        }
        private readonly int max_X;
        private readonly int max_Y;
        private int X, Y;

        public EasterEgg_2()
        {
            InitializeComponent();
            max_X = Width;
            max_Y = Height;
           
        }
        private void EasterEgg_2_Shown(object sender, EventArgs e)
        {
            Set_XY();
        }



        private void Set_XY()
        {
            var rnd = new Random();
            X = rnd.Next(0, max_X);
            Y = rnd.Next(0, max_Y);

            InfoText.Show($"Försök klicka så nära dessa koordinater som möjligt. \nX: {X}\nY: {Y}", CustomColors.InfoText_Color.Ok, null,this);
        }

        

        
        

        private void EasterEgg_2_Click(object sender, EventArgs e)
        {
            var y = Cursor.Position.Y;
            var x = Cursor.Position.X;
            var distanceX = Math.Max(X, x) - Math.Min(X, x);
            var distanceY = Math.Max(Y, y) - Math.Min(Y, y);
            var totalDistance = distanceX + distanceY;

            Blink_Pixel();

            InfoText.Show($"Du missade punkten med {totalDistance} pixlar\n\n" +
                          $"Du fick {Points(totalDistance)} poäng\n" +
                          $"{Comment(totalDistance)}", CustomColors.InfoText_Color.Warning, null, this);

            EasterEgg_HighScore.Save_Score(Antal_Spelare_Som_Spelat, Points(totalDistance), "Easter Egg 2");
            
            Show_Highscore();
            //Close();
        }

        private void Blink_Pixel()
        {
            var panel = new Panel
            {
                Width = 3,
                Height = 3,
                BackColor = Color.Black,
                Left = X,
                Top = Y,
            };
            Controls.Add(panel);
            ControlValidator.SoftBlink(panel, Color.Red, Color.Yellow, 200, 3000);
            Thread.Sleep(3000);
            panel.Dispose();
        }
        private void Show_Highscore()
        {
            dgv_HighScore.Visible = true;
            const string query = @"
            SELECT Namn, Datum, Points
            FROM Easter_Egg_Points
            WHERE Game = 'Easter Egg 2'
            ORDER BY Points DESC";

            using var con = new SqlConnection(Database.cs_Protocol);
            using var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            using var adapter = new SqlDataAdapter(cmd);
            var table = new DataTable();

            try
            {
                con.Open();
                adapter.Fill(table);

                // Formatera datumkolumnen
                foreach (DataRow row in table.Rows)
                {
                    if (DateTime.TryParse(row["Datum"]?.ToString(), out var dt))
                    {
                        row["Datum"] = dt.ToString("yyyy-MM-dd HH:mm");
                    }
                }

                dgv_HighScore.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid hämtning av highscore: {ex.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
