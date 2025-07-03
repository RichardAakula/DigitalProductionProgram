using System.Data;

using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;


namespace DigitalProductionProgram.Equipment
{
    public class Tools
    {
        public class PreviousOrders
        {
            public static string? HS_Pipe(int descriptionID)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                    SELECT TextValue FROM [Order].Data 
                    WHERE OrderID = @orderid 
                    AND ProtocolDescriptionID = @descriptionid
                        
                    ORDER BY Uppstart";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@descriptionid", descriptionID);
                con.Open();
                var value = cmd.ExecuteScalar();
                return value?.ToString();
            }
        }

        public class RegisterList
        {
            public static string? NomID_HS_Pipe(string? id_Number)
            {
                using var con = new SqlConnection(Database.cs_ToolRegister);
                var query = @"SELECT Nom_ID FROM Register_Krympslangsrör WHERE ID_Nummer = @id";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.String(cmd.Parameters, "@id", id_Number);
                con.Open();
                var value = cmd.ExecuteScalar();
                return value?.ToString();
            }
            public static List<string> List_HS_PipeID(bool IsNomID)
            {
                var list = new List<string>();
                using var con = new SqlConnection(Database.cs_ToolRegister);
                var query = IsNomID ? "SELECT Nom_ID FROM Register_Krympslangsrör WHERE Inaktiv != 'True' OR Inaktiv IS NULL GROUP BY Nom_ID ORDER BY min(ID)" : @"SELECT ID_Nummer FROM Register_Krympslangsrör WHERE Inaktiv != 'True' OR Inaktiv IS NULL GROUP BY ID_Nummer ORDER BY min(ID)";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader[0].ToString());
                return list;
            }
            public static List<string> List_HS_Hackhylsa
            {
                get
                {
                    var list = new List<string>();
                    using var con = new SqlConnection(Database.cs_ToolRegister);
                    var query = @"SELECT DISTINCT ID_Nummer FROM Register_Hackhylsor ORDER BY ID_Nummer DESC";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0].ToString());
                    return list;
                }
            }

            public static DataTable DataTable_Tools(string typ, double? min = null, double? max = null)
            {
                var dt = new DataTable();
                dt.Columns.Add("Item1", typeof(string));
                dt.Columns.Add("Item2", typeof(string));
                using var con = new SqlConnection(Database.cs_ToolRegister);
                var query = "SELECT DISTINCT ID_Nummer, Landlängd_nom, Dimension_nom FROM Register_Verktyg WHERE Typ = '" + typ + "' AND (Kasserad IS NULL OR Kasserad = '') ";
                if (min != null)
                    query += "AND Dimension_nom >= @min AND Dimension_nom <= @max ";
                query += "ORDER BY Dimension_nom";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.Double(cmd.Parameters, "@min", min);
                SQL_Parameter.Double(cmd.Parameters, "@max", max);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dt.Rows.Add($"{reader[0]}", $"{reader[1]}");
                return dt;
            }
        }
        
        public static void Load_HSPipes()
        {
            if (!CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.ManufacturesHeatShrink)) 
                return;
            Order.HS_Pipe_1 = PreviousOrders.HS_Pipe(75);
            Order.HS_Pipe_2 = PreviousOrders.HS_Pipe(160);
            Order.HS_Pipe_3 = PreviousOrders.HS_Pipe(161);
        }

        public static string RegularUsedToolType(string type)
        {
            using var con = new SqlConnection(Database.cs_ToolRegister);
            var query = @"
                    SELECT TOP(1) Typ as Type, COUNT(*) Ctr
                    FROM RegularUsed_VerktygsTyp_Användare
                    WHERE Användare = @user
                        AND Typ LIKE '%' + @type + '%'
                    GROUP BY Typ
                    ORDER BY Ctr DESC";

            using var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@user", Person.Name); // Adjust as needed
            cmd.Parameters.AddWithValue("@type", type);
            con.Open();
            var result = cmd.ExecuteScalar(); // Get the first value from the first row

            return result?.ToString() ?? string.Empty; // Return Type or empty string if null
        }
        public static void AddRegularUsedToolTypeForUser(string typ)
        {
            using var con = new SqlConnection(Database.cs_ToolRegister);
            const string query = @"INSERT INTO RegularUsed_VerktygsTyp_Användare (Användare, Typ, Datum) 
                                    VALUES (@user, @typ, @date)";

            using var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            cmd.Parameters.AddWithValue("@user", Person.Name);
            cmd.Parameters.AddWithValue("@typ", typ);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.ExecuteNonQuery();
        }
    }
}
