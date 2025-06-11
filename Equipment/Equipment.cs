﻿using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Equipment
{
    internal class Equipment
    {
        public static string? HS_Machine { get; set; }

        public static bool Is_Filterhus_Used_No_Processcard
        {
            //Om inget processkort används så kan operatören välja i Menyn om man vill köra med Filterhus eller Silpaket.
            //Den datan sparas då i [Order].Data med ProtocolDescriptionID = 201
            get
            {
                if (string.IsNullOrEmpty(Order.PartID.ToString()))
                    return false;
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        SELECT BoolValue                          
                        FROM [Order].Data
                        WHERE OrderID = @orderid
                        AND ProtocolDescriptionID = 313";
                var IsFilterhus = false;
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var value = cmd.ExecuteScalar();
                if (value != null)
                    bool.TryParse(value.ToString(), out IsFilterhus);
                return IsFilterhus;
            }
        }
        public static bool Is_Filterhus_Used_In_Processcard
        {
            get
            {
                if (string.IsNullOrEmpty(Order.PartID.ToString()))
                    return false;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT TextValue                          
                        FROM Processcard.Data
                        WHERE PartID = @partID
                        AND TemplateID = (SELECT ID FROM Protocol.Template WHERE ProtocolDescriptionID = 313 AND FormTemplateID = 31)";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@partID", Order.PartID);
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        if (value.ToString() == "Ja")
                            return true;
                }

                return false;
            }
        }
        public static List<string> Blacklist_Utrustning
        {//Filtrerar bort felaktigheter som operatörerna skrivit in
            get
            {
                var list = new List<string>
                {
                    "Helios T25",
                    "Helios T14",
                    "Helios T11",
                    "Helios T9",
                    "Helios",
                    "t 15",
                    "T 14",
                    "En",
                    "En Skruv",
                    "En skruv",
                    "H14",
                    "Ja",
                    "N1l1632 N1k0649-2",
                    "N1l1650+ N1k0649-2",
                    "T 14",
                    "T-10",
                    "T12 + T21",
                    "T14+T09",
                    "T9+T10",
                    "T9+T14",
                    "80-150-80",
                    "80 +150+325",
                    "80 +150",
                    "80+ 150",
                    "150/80",
                    "80/150",
                    "80/150/325/80",
                    "80/150/80",
                    "80+150 / 80+150",
                    "80+150 / 80",
                    "80+150 x 2",
                    "80+150x2",
                    "80150",
                    "80-150",
                    "N1k",
                    "N1K",
                    "N1l",
                    "N1L",
                    "N1K+N1L",
                    "N1K+N3",
                    "Betol omärkt",
                    "B25 omärkt",
                    "NI-B25",
                    "I3",
                    "Fri-Extrudering",

                };
                return list;
            }
        }

        public static List<string?> List_ProdLines
        {
            get
            {
                var list = new List<string?>();
                foreach (var prodlinje in Monitor.Monitor.WorkCenters.Where(prodlinje => list.Contains(prodlinje.Value) == false))
                    list.Add(prodlinje.Value);

                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"SELECT DISTINCT ProdLine FROM Processcard.MainData ORDER BY ProdLine";
                var cmd = new SqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!Blacklist_Utrustning.Contains(reader[0].ToString()) && !list.Contains(reader[0].ToString()))
                        list.Add(reader[0].ToString());
                }

                return list;
            }
        }
        
        public static List<string?> List_Intag
        {
            get
            {
                var list = new List<string?>
                {
                    LanguageManager.GetString("slätt"),
                    LanguageManager.GetString("rillat"),
                    "N/A"
                };
                return list;
            }
        }
        public static List<string?> List_Tool_Type(string CodeName)
        {
            var list = new List<string?>();
            using var con = new SqlConnection(Database.cs_ToolRegister);
            var query = "SELECT DISTINCT Typ FROM Register_Verktyg WHERE Sort = @codeName AND (Kasserad IS NULL OR Kasserad = '') ORDER BY Typ";

            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@codeName", CodeName);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(reader[0].ToString());
            return list;
        }
        public static List<string?> List_Tool(string? typ, string? min = null, string? max = null)
        {
            var list = new List<string?>();
            double.TryParse(min, out var MIN);
            double.TryParse(max, out var MAX);
            using var con = new SqlConnection(Database.cs_ToolRegister);
            var query = $@"
                    SELECT DISTINCT ID_Nummer, Landlängd_nom, Dimension_nom 
                    FROM Register_Verktyg 
                    WHERE (Typ = @typ OR @typ IS NULL)
                        AND (Kasserad IS NULL OR Kasserad = '') ";
            if (!string.IsNullOrEmpty(min) && !string.IsNullOrEmpty(max))
                query += "AND Dimension_nom >= @min AND Dimension_nom <= @max ";
            query += "ORDER BY Dimension_nom";
            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@min", MIN);
            cmd.Parameters.AddWithValue("@max", MAX);
            SQL_Parameter.String(cmd.Parameters, "@typ", typ);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add($"{reader[0]}:{reader[1]}");
            return list;
        }
        public static List<string?> List_From_Register(string kolumn, string register, bool is_Show_Typ = false, string nom_Typ = null, string? sort = null)
        {
            var list = new List<string?>();

            using (var con = new SqlConnection(Database.cs_ToolRegister))
            {
                string query;
                if (is_Show_Typ == false || !string.IsNullOrEmpty(sort))
                    query = $"SELECT DISTINCT {kolumn} ";
                else
                    query = $"SELECT DISTINCT {kolumn}, Typ ";

                query += $"FROM {register} ";

                if (string.IsNullOrEmpty(nom_Typ) == false && nom_Typ != "N/A" && string.IsNullOrEmpty(sort))
                    query += $"WHERE Typ = '{nom_Typ}' ";
                if (!string.IsNullOrEmpty(sort))
                    query += "WHERE Sort = @sort AND (Kasserad IS NULL OR Kasserad = '')";


                con.Open();
                var cmd = new SqlCommand(query, con);
                SQL_Parameter.String(cmd.Parameters, "@sort", sort);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!Blacklist_Utrustning.Contains(reader[0].ToString()))
                    {
                        if (is_Show_Typ == false || !string.IsNullOrEmpty(sort))
                            list.Add(reader[0].ToString());
                        else
                            list.Add($"{reader[0]} : ({reader[1]})");

                    }

                }
                list.Add("N/A");
            }
            return list;

        }
        public static List<string?> List_Equipment_Protocol(string codetext)
        {
            var list = new List<string>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT DISTINCT TextValue 
                        FROM [Order].Data WHERE ProtocolDescriptionID = (SELECT ID FROM Protocol.Description WHERE CodeText COLLATE Latin1_General_BIN = @codetext COLLATE Latin1_General_BIN) 
                        ORDER BY TextValue";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@codetext", codetext);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    if (!Blacklist_Utrustning.Contains(reader[0].ToString()))
                        list.Add(reader[0].ToString());
            }
            return list;
        }
        public static List<string> List_Equipment_Extruder
        {
            get
            {
                var list = new List<string>();
                using (var con = new SqlConnection(Database.cs_ToolRegister))
                {
                    const string query = "SELECT DISTINCT Extruder FROM Extruder_Skruvar ORDER BY Extruder";

                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0].ToString());
                }

                return list;
            }
        }
        public static List<string?> List_Register(bool isType, string? type, string db_Table)
        {
            var list = new List<string>();
            using (var con = new SqlConnection(Database.cs_ToolRegister))
            {
                string query;
                if (isType)
                    query = $"SELECT DISTINCT Typ FROM {db_Table}";
                else
                if (string.IsNullOrEmpty(type) || ControlValidator.IsStringNA(type))
                    query = $"SELECT DISTINCT ID_Nummer, Typ FROM {db_Table}";
                else
                    query = $"SELECT DISTINCT ID_Nummer, Typ FROM {db_Table} WHERE Typ = @type";

                var cmd = new SqlCommand(query, con);
                con.Open();
                SQL_Parameter.String(cmd.Parameters, "@type", type);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(isType ? reader[0].ToString() : $"{reader[0]}:({reader[1]})");
            }
            return list;
        }
        public static List<string?> List_CleanedCylinder(int startup)
        {
            var list = new List<string?>
            {
                LanguageManager.GetString("yes")
            };
            if (startup > 1)
                list.Add(LanguageManager.GetString("no"));
            if (startup != 1) 
                return list;
            list.Add(LanguageManager.GetString("protocol_EquimentInfo_1")); //No, same material and equipment as last order
            list.Add(LanguageManager.GetString("protocol_EquimentInfo_2")); //No, same material as last startup
            if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.CleanedCyliner)) 
                return list;
            list.Add(LanguageManager.GetString("protocol_EquimentInfo_3")); //No, soft to hard material
            list.Add(LanguageManager.GetString("protocol_EquimentInfo_4")); //No, light to dark color

            return list;
        }


        public static DataTable DataTable_Skruvar(string[] extrudrar)
        {
            var list_Skruvar = new List<string>();
            var dt = new DataTable();
            dt.Columns.Add("Item1", typeof(string));
            dt.Columns.Add("Item2", typeof(string));

            foreach (var extruder in extrudrar)
            {
                using (var con = new SqlConnection(Database.cs_ToolRegister))
                {
                    var query = "SELECT Skruv FROM Extruder_Skruvar WHERE Extruder = @extruder";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@extruder", extruder);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        if (!list_Skruvar.Contains(reader[0].ToString()))
                            list_Skruvar.Add(reader[0].ToString());
                }
            }

            foreach (var id_Nummer in list_Skruvar)
            {
                using (var con = new SqlConnection(Database.cs_ToolRegister))
                {
                    var query = "SELECT Typ, ID_Nummer FROM Register_Skruvar " +
                                "WHERE ID_Nummer = @idNummer AND Typ > '' AND Typ IS NOT NULL AND Reserv = 'False' AND Inaktiv = 'False' AND (Kasserad IS NULL OR Kasserad = '')";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idNummer", id_Nummer);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        dt.Rows.Add($"{reader[0]}", $"{reader[1]}");
                }
            }
            return dt;
        }
        public static void Set_Filterhus_Used_In_Protocol(bool value)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        IF NOT EXISTS (SELECT * FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = 201)
                            INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, Uppstart, Ugn, Value, TextValue, BoolValue)
                            VALUES (@orderid, 201, NULL, NULL, NULL, NULL, @boolvalue)
                        ELSE
                            UPDATE [Order].Data 
                                SET boolvalue = @boolvalue
                            WHERE OrderID = @orderid AND ProtocolDescriptionID = 201";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@boolvalue", value);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
