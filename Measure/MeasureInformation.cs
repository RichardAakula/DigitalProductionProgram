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
        public static string Latest_Measureprotocol_Revision
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT TOP(1) revision 
                        FROM Measureprotocol.MainTemplate	                    
                        WHERE MeasureProtocolMainTemplateID = @formtemplateid
                        ORDER BY revision DESC";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@formtemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                    var value = cmd.ExecuteScalar();
                    return value?.ToString();
                }
            }
        }

        public static int TotalMeasurmentsByOperators
        {
            get
            {
                var query = "SELECT COUNT(*) FROM Measureprotocol.MainData WHERE OrderID = @orderid";

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public static int Most_Frequent_TotalAmount
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
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
                }
                return 0;
            }
        }
        public static int TotalMeasurements(string? workoperation = null)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                string query;
                if (workoperation != null)
                    query = @"
                        SELECT COUNT(*) FROM MeasureProtocol.Data
                        WHERE EXISTS (SELECT * FROM [Order].MainData 
                            WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL)
                            AND MeasureProtocol.Data.OrderID = [Order].MainData.OrderID)
                        AND DescriptionId = 37";//37 = Påse_Spole
                else
                    query = @"SELECT COUNT(*) FROM MeasureProtocol.Data WHERE DescriptionId = 37";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.String(cmd.Parameters, "@workoperation", workoperation);
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        public static bool IsOpening = false;
        
    }
}
