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
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.MainWindow;

namespace DigitalProductionProgram.EasterEggs
{
    internal class EasterEgg_HighScore
    {
        public static int TotalGames(string game)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT COUNT(*) FROM Easter_Egg_Points WHERE Namn = @namn AND Game = @game";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@namn", Person.Name);
            cmd.Parameters.AddWithValue("@game", game);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value is null)
                return 0;
            return (int)value;
        }

        private static int TotalPlayers(string game)
        {
            var ctr = 0;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT DISTINCT Namn FROM Easter_Egg_Points WHERE Namn <> @namn AND Game = @game";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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

            InfoText.Question($"You are the {ControlManager.FormatOrdinal(TotalPlayers(game) + 1)} to uncover this hidden Easter egg.\n" +
                              $"Do you dare to open it... or leave its secrets buried?",
                CustomColors.InfoText_Color.Info, "EASostoteroregoggog", form, true);
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
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@namn", Person.Name);
            cmd.Parameters.AddWithValue("@datum", DateTime.Now);
            cmd.Parameters.AddWithValue("@level", level);
            cmd.Parameters.AddWithValue("@points", points);
            cmd.Parameters.AddWithValue("@game", game);

            con.Open();
            cmd.ExecuteNonQuery();
        }
        public static int CountEntries(string game, int level)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT COUNT(*) FROM Easter_Egg_Points WHERE Namn = @namn AND Game = @game AND Level = @level";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@namn", Person.Name);
            cmd.Parameters.AddWithValue("@game", game);
            cmd.Parameters.AddWithValue("@level", level);
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value is null)
                return 0;
            return Convert.ToInt32(value);
        }
        public static void Save_MarkerIfMissing(int level, string game)
        {
            if (string.IsNullOrWhiteSpace(Person.Name) || CountEntries(game, level) > 0)
                return;
            Save_Score(level, 0, game);
        }
        public static void Save_LevelFound(int level, string game)
        {
            Save_MarkerIfMissing(level, game);
        }
        public static bool HasFoundLevel(string game, int level)
        {
            if (string.IsNullOrWhiteSpace(Person.Name))
                return false;
            return CountEntries(game, level) > 0;
        }
        public static bool HasFoundAllLevels(string game, int lastLevel)
        {
            if (string.IsNullOrWhiteSpace(Person.Name) || lastLevel < 1)
                return false;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT COUNT(DISTINCT Level) FROM Easter_Egg_Points WHERE Namn = @namn AND Game = @game AND Level BETWEEN 1 AND @lastLevel";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@namn", Person.Name);
            cmd.Parameters.AddWithValue("@game", game);
            cmd.Parameters.AddWithValue("@lastLevel", lastLevel);
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value is null)
                return false;
            return Convert.ToInt32(value) >= lastLevel;
        }
        public static void ReplacePlayerScore(string game, int level, int points)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();
            using var transaction = con.BeginTransaction();
            const string deleteQuery = "DELETE FROM Easter_Egg_Points WHERE Namn = @namn AND Game = @game AND (Level <= 0 OR Level = @level)";
            using (var deleteCmd = new SqlCommand(deleteQuery, con, transaction))
            {
                deleteCmd.Parameters.AddWithValue("@namn", Person.Name);
                deleteCmd.Parameters.AddWithValue("@game", game);
                deleteCmd.Parameters.AddWithValue("@level", level);
                deleteCmd.ExecuteNonQuery();
            }
            const string insertQuery = "INSERT INTO Easter_Egg_Points VALUES(@game, @namn, @datum, @level, @points)";
            using (var insertCmd = new SqlCommand(insertQuery, con, transaction))
            {
                insertCmd.Parameters.AddWithValue("@namn", Person.Name);
                insertCmd.Parameters.AddWithValue("@datum", DateTime.Now);
                insertCmd.Parameters.AddWithValue("@level", level);
                insertCmd.Parameters.AddWithValue("@points", points);
                insertCmd.Parameters.AddWithValue("@game", game);
                insertCmd.ExecuteNonQuery();
            }
            transaction.Commit();
        }
        public static DataTable LoadHighscores(string game, int topCount = 0, bool excludeZeroPoints = false)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var topClause = topCount > 0 ? $"TOP ({topCount}) " : string.Empty;
            var zeroClause = excludeZeroPoints ? " AND Points > 0" : string.Empty;
            var query = $@"SELECT {topClause}Namn, Datum, Level, Points
                FROM Easter_Egg_Points
            WHERE Game = @game{zeroClause}
            ORDER BY Points DESC, Datum ASC";
            using var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@game", game);
            var dt = new DataTable();
            using var adapter = new SqlDataAdapter(cmd);
            con.Open();
            adapter.Fill(dt);

            return dt;
        }
    }
}
