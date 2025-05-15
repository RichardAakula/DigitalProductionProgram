using System;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Övrigt
{
    public partial class EasterEgg_2 : Form
    {
        private static string Comment(int distance)
        {
            if (distance > 0 && distance < 50)
                return "Wow!! Utopiskt!!";
            if (distance > 49 && distance < 70)
                return "Gudomligt bra!!";
            if (distance > 69 && distance < 100)
                return "Fantastiskt bra!!";
            if (distance > 99 && distance < 200)
                return "Ganska bra!!";
            if (distance > 199 && distance < 300)
                return "Hyfsat bra!";
            if (distance > 299 && distance < 400)
                return "Ok";
            if (distance > 399 && distance < 500)
                return "Mnjaa..Det där var nog inte så nära";
            if (distance > 499 && distance < 600)
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
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT COUNT(*) FROM Easter_Egg_Points WHERE Namn = @namn AND CAST (Datum AS date) = @date AND Game = 'Easter Egg 2'";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@namn", Person.Name);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    if (value is null)
                        return 0;
                    return (int)value;
                }
            }
        }
        public static int Antal_Spelare_Som_Spelat
        {
            get
            {
                var ctr = 0;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT DISTINCT Namn FROM Easter_Egg_Points WHERE Namn <> @namn AND Game = 'Easter Egg 2'";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@namn", Person.Name);
                    con.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        ctr++;
                }
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

            InfoText.Show($"Du missade totalt med {totalDistance} pixlar\n\n" +
                          $"Du fick {Points(totalDistance)} poäng\n" +
                          $"{Comment(totalDistance)}", CustomColors.InfoText_Color.Warning, null, this);

            Save_Points(Points(totalDistance));
            Show_Highscore();
            Close();
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
            ControlValidator.SoftBlink(panel, Color.Red, Color.Black, 300, 3000);
            Thread.Sleep(3000);
            panel.Dispose();
        }
        private void Show_Highscore()
        {
            var message = "Top 20:\n\n";
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT Namn, Datum, Points FROM Easter_Egg_Points WHERE Game = 'Easter Egg 2' ORDER BY Points DESC";
                var cmd = new SqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var date = DateTime.Parse(reader["Datum"].ToString());
                    message += $"{reader["Namn"]} - {date:yyyy-MM-dd HH:mm}:      {reader["Points"]}\n";
                }

                InfoText.Show(message, CustomColors.InfoText_Color.Info, "Info", this);
            }
        }
        private static void Save_Points(int points)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "INSERT INTO Easter_Egg_Points VALUES( @game, @namn, @datum, NULL, @points)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@game", "Easter Egg 2");
                cmd.Parameters.AddWithValue("@namn", Person.Name);
                cmd.Parameters.AddWithValue("@datum", DateTime.Now);
                cmd.Parameters.AddWithValue("@points", points);
                

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
