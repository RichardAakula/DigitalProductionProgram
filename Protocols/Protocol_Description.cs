using System.Configuration;
using Microsoft.Data.SqlClient;
using DigitalProductionProgram.DatabaseManagement;

using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Protocols
{
    internal class Protocol_Description
    {
        public static int? Protocol_Description_ID_Row(int row, int formtemplateid)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT ProtocolDescriptionID FROM Protocol.Template
                    WHERE FormTemplateID = @formtemplateid
                        AND RowIndex = @rowIndex";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                cmd.Parameters.AddWithValue("@rowIndex", row);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                con.Open();
                var value = cmd.ExecuteScalar();
                return (int?)value;
            }
        }
        public static int? Protocol_Description_ID_Col(int col, int formtemplateid)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT ProtocolDescriptionID FROM Protocol.Template
                    WHERE FormTemplateID = @formtemplateid
                    AND ColumnIndex = @colIndex";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                cmd.Parameters.AddWithValue("@colIndex", col);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                con.Open();
                var value = cmd.ExecuteScalar();
                return (int?)value;
            }
        }

        public static string Codetext(int id)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT CodeText FROM Protocol.Description
                    WHERE id = @id";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return value.ToString();
            }
            return null;
        }
       
    }
}
