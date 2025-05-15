using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using DigitalProductionProgram.DatabaseManagement;

using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Customer
{
    internal class Customer
    {

        public static List<string> List_Customers
        {
            get
            {
                var list = new List<string>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT DISTINCT Customer FROM [Order].MainData WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) ORDER BY Customer";

                    var cmd = new SqlCommand(query, con);
                    SQL_Parameter.String(cmd.Parameters, "@workoperation", Order.WorkOperation.ToString());
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0].ToString());
                }
                return list;
            }
        }
    }
}
