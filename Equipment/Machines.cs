using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using DigitalProductionProgram.DatabaseManagement;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;

namespace DigitalProductionProgram.Equipment
{
    internal class Machines
    {
        public static List<string> Kragmaskiner(int FormTemplateID)
        {
                var list = new List<string>();
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"SELECT DISTINCT textvalue
                    FROM [Order].Data WHERE ProtocolDescriptionID = 10";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", "KRAGMASKIN");
                cmd.Parameters.AddWithValue("@formtemplateid", FormTemplateID);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                    list.Add(reader[0].ToString());
                return list;
        }
       
      
        public static List<string?> Extruders(string codetext, int? orderid = 0)
        {
            var list = new List<string?>();
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT DISTINCT TextValue
                    FROM [Order].Data 
                    WHERE ProtocolDescriptionID = (SELECT ID FROM Protocol.Description WHERE CodeText = @codetext)
                        AND OrderID IN (SELECT OrderID FROM [Order].MainData WHERE ProtocolMainTemplateID = @maintemplateid)";
            if (orderid > 0)
                query += "AND OrderID = @orderid";
            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@codetext", codetext);
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
                list.Add(reader[0].ToString());
            return list;
        }
        public static List<string> Cylinders
        {
            get
            {
                var cylinders = new List<string>();
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                        SELECT DISTINCT TextValue 
                        FROM Processcard.Data WHERE TemplateID IN 
                            (SELECT Id FROM Protocol.Template WHERE ProtocolDescriptionID = 
								(SELECT id FROM Protocol.Description WHERE CodeText = 'CYLINDER') 
                                    AND (FormTemplateID IN (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid)))";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                    cylinders.Add(reader[0].ToString());
                return cylinders;
            }
        }
        public static List<string> HS_Upptagare
        {
            get
            {
                var list = new List<string>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT DISTINCT TextValue
                        FROM [Order].Data WHERE ProtocolDescriptionID = 73";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0].ToString());
                }
                return list;
            }
        }
        public static List<string> HS_Machines
        {
            get
            {
                var list = new List<string>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    //ProtocolDescriptionID 159 = HS MASKIN
                    var query = @"
                        SELECT DISTINCT TextValue 
                        FROM [Order].Data WHERE ProtocolDescriptionID = 159";

                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0].ToString());
                }
                return list;

            }
        }
        public static List<string> List_ProdLine
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT DISTINCT ProdLine FROM [Order].MainData 
                                ORDER BY ProdLine";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    var list = new List<string>();
                    while (reader.Read())
                        list.Add(reader[0].ToString());
                    return list;

                }
            }
        }

        public static string? Active_HS_Machine
        {
            get
            {
                if (Order.OrderID is null)
                    return string.Empty;
                using (var con = new SqlConnection(Database.cs_Protocol))
                { 
                    const string query = @"
                        SELECT TextValue 
                        FROM [Order].Data 
                        WHERE OrderID = @orderid 
                            AND ProtocolDescriptionID = 159
                            AND Uppstart = 1";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    return value is null ? string.Empty : value.ToString();
                }
            }
        }

    }
}
