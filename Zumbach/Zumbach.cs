using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalProductionProgram.Zumbach
{
    internal class Zumbach
    {
       public static void Load_DataTable_Measurements(CustomProgressBar pbar, DataTable zumbachData)
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

                var count = zumbachData.AsEnumerable()
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
            Database.ExecuteSafe(con =>
            {
                const string query = @"
                    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; -- eller WITH (NOLOCK)
                    SELECT 
                        (SELECT COUNT_BIG(*) FROM Zumbach.Measurements WITH (NOLOCK)) AS TotalMeasurements,
                        (SELECT COUNT_BIG(*) FROM Zumbach.[Data]      WITH (NOLOCK)) AS TotalMeasurePoints";

                using var cmd = new SqlCommand(query, con); 
                using var reader = cmd.ExecuteReader();    
                if (reader.Read())
                {

                    var ordTotalMeasurements = reader.GetOrdinal("TotalMeasurements");
                    var ordTotalMeasurePoints = reader.GetOrdinal("TotalMeasurePoints");

                    long totalMeasurements = reader.GetInt64(ordTotalMeasurements);
                    long totalMeasurePoints = reader.GetInt64(ordTotalMeasurePoints);

                    TotalMeasurements = ConvertToReadableValue(totalMeasurements);
                    TotalMeasurePoints = ConvertToReadableValue(totalMeasurePoints);


                }
            });
        }


        private static string ConvertToReadableValue(long value)
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
