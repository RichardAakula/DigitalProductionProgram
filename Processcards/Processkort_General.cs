using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Processcards
{
    internal abstract class Processkort_General
    {
        public static string? LoadRevNr(int? partID = null)
        {
            if (partID == null)
                partID = Order.PartID;
            if (Order.PartID is null || Order.PartID == 0)
                return null;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT RevNr FROM Processcard.MainData WHERE PartID = @partid";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            SQL_Parameter.NullableINT(cmd.Parameters, "@partid", partID);
            if (string.IsNullOrEmpty((string)cmd.ExecuteScalar()))
                return string.Empty;
            return (string)cmd.ExecuteScalar();
        }
        public static string? LoadProdType
        {
            get
            {
                if (Order.PartID is null || Order.PartID == 0)
                    return null;

                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT ProdType FROM Processcard.MainData WHERE PartID = @partid";
                var cmd = new SqlCommand(query, con);
                ServerStatus.Add_Sql_Counter();
                con.Open();

                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
                var result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return null; // eller return string.Empty om du hellre vill

                var prodType = result.ToString();
                return string.IsNullOrEmpty(prodType) ? string.Empty : prodType;
            }
        }
    }
}
