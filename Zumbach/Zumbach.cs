using DigitalProductionProgram.DatabaseManagement;

using System.Data;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.MainWindow;
using Microsoft.Data.SqlClient;
using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Zumbach
{
    internal class Zumbach
    {
       public static void Load_DataTable_Measurements(ControlsManagement.ProgressBar pbar)
        {
            int ctr = 0;
            DataTable_Measurements = new DataTable();

            DataTable_Measurements.Columns.Add("Bag", typeof(int));
            DataTable_Measurements.Columns.Add("Antal_DataPunkter", typeof(int));

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT DISTINCT Bag FROM Zumbach.Measurements WHERE OrderID = @orderid ORDER BY Bag";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                con.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataTable_Measurements.Rows.Add(int.Parse(reader["Bag"].ToString()));
                }
            }

            var totalRows = DataTable_Measurements.Rows.Count;


            for (var i = 0; i < totalRows; i++)
            {
                int.TryParse(DataTable_Measurements.Rows[i][0].ToString(), out var bagId);

                var count = MeasureWithZumbach.ZumbachData.AsEnumerable()
                    .Count(x => (int)x["OrderID"] == Order.OrderID && int.Parse(x["Bag"].ToString()) == bagId);

                DataTable_Measurements.Rows[i][1] = count;

                // Steg 2: Uppdatera progress
                var progress = 10 + (int)((double)(i + 1) / totalRows * 90);  // 10–100%
                pbar.Set_ValueProgressBar(progress, LanguageManager.GetString("zumbach_Info_3"));
            }

            // Sista steg: Säkerställ att progressen är klar
            pbar.Set_ValueProgressBar(100, LanguageManager.GetString("done"));
        }

        public static DataTable DataTable_Measurements { get; set; } = null!;

        public static string TotalMeasurements { get; set; } = null!;
        public static string TotalMeasurePoints { get; set; } = null!;

        public static void Load_MeasureStats()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    SELECT 
                        (SELECT COUNT(*) FROM Zumbach.Measurements) AS TotalMeasurements,
                        (SELECT COUNT(*) FROM Zumbach.Data) AS TotalMeasurePoints";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TotalMeasurements = ConvertToReadableValue(reader.GetInt32(reader.GetOrdinal("TotalMeasurements")));
                TotalMeasurePoints = ConvertToReadableValue(reader.GetInt32(reader.GetOrdinal("TotalMeasurePoints")));
            }
        }

        private static string ConvertToReadableValue(int value)
        {
            if (value < 1000000)
                return value.ToString();

            switch (value.ToString().Length)
            {
                case 7:
                case 8:
                case 9:
                    return $"{value / 1000000.0:F2} {LanguageManager.GetString("zumbachCounter_1")}";
                case 10:
                case 11:
                    return $"{value / 1000000000.0:F3}  {LanguageManager.GetString("zumbachCounter_2")}";

            }

            return "N/A";
        }
    }
}
