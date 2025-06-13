using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Processcards
{
    internal class Processkort_General
    {
        public static bool IsProcesscardOpen
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var cmd = new SqlCommand(Queries.SELECT_is_Processcard_Open, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                con.Open();
                try
                {
                    var result = cmd.ExecuteScalar();
                    if (result == DBNull.Value || result == null)
                        return false;
                    return (bool)result;


                }
                catch
                {
                    SaveData.Reset_Processcard_Open(true);
                    return false;
                }
            }
        }

        public static string? Last_RevNr(int? partID = null)
        {
            if (partID == null)
                partID = Order.PartID;
            if (Order.PartID is null || Order.PartID == 0)
                return null;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT RevNr FROM Processcard.MainData WHERE PartID = @partid";
            var cmd = new SqlCommand(query, con);
            con.Open();
            SQL_Parameter.NullableINT(cmd.Parameters, "@partid", partID);
            if (string.IsNullOrEmpty((string)cmd.ExecuteScalar()))
                return string.Empty;
            return (string)cmd.ExecuteScalar();
        }
        
       
       
    }
}
