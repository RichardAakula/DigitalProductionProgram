using System.Configuration;
using Microsoft.Data.SqlClient;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;

namespace DigitalProductionProgram.Measure
{
   
    internal class MeasureInformation
    {
        public static int TotalMeasurmentsByOperators
        {
            get
            {
                var query = "SELECT COUNT(*) FROM Measureprotocol.MainData WHERE OrderID = @orderid";

                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                return (int)cmd.ExecuteScalar();
            }
        }
        public static int Most_Frequent_TotalAmount
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        SELECT TOP(1) TextValue, COUNT(TextValue) AS Frequency
                        FROM MeasureProtocol.Data
                        WHERE OrderID = @orderid
                        AND TextValue != 'N/A'
                        AND DescriptionId = 48
                        GROUP BY TextValue";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var value = cmd.ExecuteScalar();
                if (value != null)
                    if (int.TryParse(value.ToString(), out var antal))
                        return antal;
                return 0;
            }
        }
        public static Dictionary<string, int> AllMeasurementCounts()
        {
            var result = new Dictionary<string, int>();

            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
        SELECT wo.Name, COUNT(*) AS Count
        FROM MeasureProtocol.Data md
        INNER JOIN [Order].MainData omd ON md.OrderID = omd.OrderID
        INNER JOIN Workoperation.Names wo ON omd.WorkOperationID = wo.ID
        WHERE md.DescriptionId = 37
        GROUP BY wo.Name

        UNION ALL

        SELECT 'TOTAL', COUNT(*) 
        FROM MeasureProtocol.Data 
        WHERE DescriptionId = 37";

            using var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var name = reader.GetString(0);
                var count = reader.GetInt32(1);
                result[name] = count;
            }

            return result;
        }
        public static bool IsOpening = false;
        
    }
}
