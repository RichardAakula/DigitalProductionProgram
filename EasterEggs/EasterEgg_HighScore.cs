using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalProductionProgram.MainWindow;

namespace DigitalProductionProgram.EasterEggs
{
    internal class EasterEgg_HighScore
    {
        public static int TotalGames(string game)
        {

            return 0 ;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT COUNT(*) FROM Easter_Egg_Points WHERE Namn = @namn AND Game = @game";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@namn", Person.Name);
            cmd.Parameters.AddWithValue("@game", game);
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value is null)
                return 0;
            return (int)value;
        }
        public static int TotalGamesToday(string game)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT COUNT(*) FROM Easter_Egg_Points WHERE Namn = @namn AND CAST (Datum AS date) = @date AND Game = @game";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@namn", Person.Name);
            cmd.Parameters.AddWithValue("@game", game);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value is null)
                return 0;
            return (int)value;
        }
        public static int TotalPlayers(string game)
        {
            var ctr = 0;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT DISTINCT Namn FROM Easter_Egg_Points WHERE Namn <> @namn AND Game = @game";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@namn", Person.Name);
            cmd.Parameters.AddWithValue("@game", game);
            con.Open();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
                ctr++; 
            return ctr;
        }

        public static bool IsOkStartGame(string game, Main_Form form)
        {
            if (string.IsNullOrEmpty(Person.Name))
                return false;
            if (TotalGamesToday(game) > 1)
            {
                InfoText.Show("Öpp öpp, inga någgi mera idag. Nu jobbar vi lite.\n" +
                              "Nya tag imorrn.", CustomColors.InfoText_Color.Bad, "Hold your horses!", form);
                return false;
            }

            InfoText.Question($"Du är Nr:{TotalPlayers(game) + 1} att hitta detta påskägg. Vill du fortsätta och öppna det?",
                CustomColors.InfoText_Color.Info, "popåsskokägoggog", form);
            if (InfoText.answer == InfoText.Answer.No)
                return false;
            return true;
        }
        public static void Save_Score(int level, int points, string game)
        {
            //if (Person.Name == "Richard Aakula")
            //    return;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "INSERT INTO Easter_Egg_Points VALUES(@game, @namn, @datum, @level, @points)";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@namn", Person.Name);
            cmd.Parameters.AddWithValue("@datum", DateTime.Now);
            cmd.Parameters.AddWithValue("@level", level);
            cmd.Parameters.AddWithValue("@points", points);
            cmd.Parameters.AddWithValue("@game", game);

            con.Open();
            cmd.ExecuteNonQuery();
        }
        public static DataTable LoadHighscores(string game)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"SELECT Namn, Datum, Level, Points
                FROM Easter_Egg_Points
            WHERE Game = @game
            ORDER BY Points DESC";
            using var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@game", game);
            var dt = new DataTable();
            using var adapter = new SqlDataAdapter(cmd);
            con.Open();
            adapter.Fill(dt);

            return dt;
        }
    }
}
