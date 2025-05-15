using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols
{
    internal class Korprotokoll
    {
        public static bool IsProtocol_Open_By_AnotherUser(Form form)
        {
            if (!Order.IsOrderDone)
            {
                if (Person.IsUserSignedIn(true) == false)
                    Module.IsOkToSave = false;
                else
                {
                    if (Processkort_General.IsProcesscardOpen == false)
                    {
                        SaveData.Set_Processcard_Open();
                        return false;
                    }

                    if (Environment.MachineName != Open_ByComputer ||
                        Person.Name != Open_ByUser &
                        !string.IsNullOrEmpty(Open_ByUser))
                    {
                        InfoText.Show(
                            $"{LanguageManager.GetString("protocol_OpenAnotherUser_1")} {Open_ByUser} {LanguageManager.GetString("protocol_OpenAnotherUser_2")} {Open_ByComputer}.\n" +
                            $"{LanguageManager.GetString("protocol_OpenAnotherUser_3")} {Open_ByUser}",
                            CustomColors.InfoText_Color.Warning, "Information", form);

                        return true;
                    }

                    SaveData.Set_Processcard_Open();
                    return false;
                }
            }

            return false;
        }
        public static string Open_ByUser
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var cmd = new SqlCommand(Queries.SELECT_Processcard_Open_By, con);
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    con.Open();
                    try
                    {
                        return (string)cmd.ExecuteScalar();
                    }
                    catch
                    {
                        return "NULL";
                    }
                }
            }
        }
        public static string Open_ByComputer
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var cmd = new SqlCommand(Queries.SELECT_Processcard_Open_By_Computer, con);
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    con.Open();
                    try
                    {
                        return (string)cmd.ExecuteScalar();
                    }
                    catch
                    {
                        return "NULL";
                    }
                }
            }
        }

        public class ProtocolTemplateRevision
        {
            public static void SetActiveRevision(int FormTemplateID)
            {
                //Hämtar först TemplateRevision från Ordern,
                //Om det inte finns där så hämtas det från Processkortet,
                //Om det inte finns så hämtas senaste från Template
                //Order.TemplateRevision = OrderNr(Order.OrderID)
                //                                 ?? (Order.PartID != null ? PartNumber : null)
                //                                 ?? Latest(FormTemplateID);
                if (OrderNr(Order.OrderID) != null)
                {
                    Templates_Protocol.MainTemplate.Revision = OrderNr(Order.OrderID);
                }
                else if (Order.PartID != null)
                {
                    Templates_Protocol.MainTemplate.Revision = PartNumber;
                }
                else
                {
                    Templates_Protocol.MainTemplate.Revision = Latest(FormTemplateID);
                }
            }

            public static string NewOrder
            {
                get
                {
                    if (Order.PartID != null)
                        return PartNumber;

                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        var query = @"
                        SELECT TOP(1) Revision 
                        FROM Protocol.MainTemplate 	                    
                        WHERE ID = @maintemplateid
                        ORDER BY revision DESC";
                        con.Open();
                        var cmd = new SqlCommand(query, con);
                        
                        cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                        var value = cmd.ExecuteScalar();
                        return value?.ToString();
                    }
                }
            }

            public static string OrderNr(int? orderID)
            {
                if (orderID == null)
                    return null;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                            SELECT ProtocolTemplateRevision 
                            FROM [Order].MainData
                            WHERE OrderID = @orderid";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", orderID);

                    return cmd.ExecuteScalar().ToString();
                }
            }
            public static int MainTemplateID(int? orderID)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                            SELECT ProtocolMainTemplateID 
                            FROM [Order].MainData
                            WHERE OrderID = @orderid";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", orderID);
                    int.TryParse(cmd.ExecuteScalar().ToString(), out int maintemplateid);
                    return maintemplateid;

                }
            }
            public static string PartNumber
            {
                get
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        var query = @"
                            SELECT ProtocolTemplateRevision 
                            FROM Processcard.MainData
                            WHERE PartID = @partid";
                        con.Open();
                        var cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@partid", Order.PartID);

                        return cmd.ExecuteScalar().ToString();
                    }
                }
            }

            public static string Latest(int FormTemplateID)
            {
                if (FormTemplateID == 0)
                    return null;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    SELECT TOP(1) Revision 
                    FROM Protocol.Template 
                    WHERE FormTemplateID = @formtemplateid
                    ORDER BY Revision DESC";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@formtemplateid", FormTemplateID);

                    return cmd.ExecuteScalar().ToString();
                }
            }

        }


        public static int ValueType(int? id)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT TOP(1) Type FROM Protocol.Template
                    WHERE ProtocolDescriptionID = @descrid";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@descrid", id);
                con.Open();
                var value = cmd.ExecuteScalar();
                return int.Parse(value.ToString());
            }
        }



        public static int Total_Machines
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query =
                        @"SELECT MAX(MachineIndex) FROM [Order].Data WHERE OrderID = @orderid";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    var antal = cmd.ExecuteScalar();
                    if (antal == null)
                        return 0;
                    return int.TryParse(antal.ToString(), out var result) ? result : 0;
                }
            }
        }
        public static int TotalProductionRows(string table)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $"SELECT COUNT(*) FROM {table} WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        public static bool IsBioburdenSamplesTaken
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT * FROM BioBurden_Samples WHERE OrderID = @orderid";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    return false;
                }
            }
        }

       

        public static void Load_Data(int? orderID, int protocoldescriptionid, int valueType, Control control)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT DISTINCT Value, TextValue, BoolValue, DateValue
                    FROM [Order].Data
                    WHERE OrderID = @orderid
	                    AND ProtocolDescriptionID = @protocoldescriptionid";
                con.Open();
                var cmd = new SqlCommand(query, con);
                
                SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", orderID);
                cmd.Parameters.AddWithValue("@protocoldescriptionid", protocoldescriptionid);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var value = string.Empty;
                    switch (valueType)
                    {
                        case 0: //NumberValue
                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue))
                                value = NumberValue.ToString();
                            break;
                        case 1: //TextValue
                            value = reader["TextValue"].ToString();
                            break;
                        case 2: //BoolValue
                            bool.TryParse(reader["boolvalue"].ToString(), out var boolvalue);
                            value = boolvalue.ToString();
                            break;
                        case 3: //DateValue
                            if (DateTime.TryParse(reader["datevalue"].ToString(), out var date))
                                value = date.ToString("yyyy-MM-dd HH:mm");
                            break;
                    }

                    if (string.IsNullOrEmpty(value))
                        value = "N/A";

                    if (control is CheckBox box)
                    {
                        bool.TryParse(value, out var IsChecked);
                        box.Checked = IsChecked;
                    }
                    else
                        control.Text = value;

                }
            }
        }
        public static string? Load_Data(int? orderID, int formtemplateid, int protocoldescriptionid)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query =
                    "EXEC Korprotokoll.sp_Load_Data_Control @orderid, @formtemplateid, @revision, @protocoldescriptionid";
                con.Open();
                var cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };
                SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", orderID);
                cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                cmd.Parameters.AddWithValue("@revision", ProtocolTemplateRevision.OrderNr(orderID));
                cmd.Parameters.AddWithValue("@protocoldescriptionid", protocoldescriptionid);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader["type"].ToString(), out var type);
                    var value = string.Empty;
                    switch (type)
                    {
                        case 0: //NumberValue
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);
                            value = double.TryParse(reader["Value"].ToString(), out var NumberValue) == false ? string.Empty : Processcard.Format_Value(NumberValue, decimals);
                            break;
                        case 1: //TextValue
                            value = reader["TextValue"].ToString();
                            break;
                        case 2: //BoolValue
                            bool.TryParse(reader["boolvalue"].ToString(), out var boolvalue);
                            value = boolvalue.ToString();
                            break;
                        case 3: //DateValue
                            if (DateTime.TryParse(reader["datevalue"].ToString(), out var date))
                                value = date.ToString("yyyy-MM-dd HH:mm");
                            break;
                    }

                    if (string.IsNullOrEmpty(value))
                        value = "N/A";

                    return value;
                }
            }

            return null;
        }
        
        public static void Save_Data(string? value, int protocoldescriptionid, int valueType, int? uppstart = null, int? machineindex = null)
        {
            if (Module.IsOkToSave == false)
                return;


            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    IF NOT EXISTS (SELECT * FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid AND (COALESCE(Uppstart, 0) = COALESCE(@uppstart, 0)) AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)))
                        INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, MachineIndex, uppstart, Value, TextValue, BoolValue, datevalue)
                        VALUES (@orderid, @protocoldescriptionid, @machineindex, @uppstart, @value, @textvalue, @boolvalue, @datevalue)
                    ELSE
                        UPDATE [Order].Data 
                            SET value = @value, textvalue = @textvalue, BoolValue = @boolvalue, datevalue = @datevalue
                        WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid AND (COALESCE(Uppstart, 0) = COALESCE(@uppstart, 0)) AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0))";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@protocoldescriptionid", protocoldescriptionid);
                SQL_Parameter.NullableINT(cmd.Parameters, "@uppstart", uppstart);
                SQL_Parameter.NullableINT(cmd.Parameters, "@machineindex", machineindex);

                switch (valueType)
                {
                    case 0: //NumberValue
                        SQL_Parameter.Double(cmd.Parameters, "@value", value);
                        cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                        cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                        cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                        break;
                    case 1: //TextValue
                        if (value != null)
                            SQL_Parameter.String(cmd.Parameters, "@textvalue", value);
                        else
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                        cmd.Parameters.AddWithValue("@value", DBNull.Value);
                        cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                        cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                        break;
                    case 2: //BoolValue
                        SQL_Parameter.Boolean(cmd.Parameters, "@boolvalue", value);
                        cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                        cmd.Parameters.AddWithValue("@value", DBNull.Value);
                        cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                        break;
                    case 3: //DateValue
                        if (DateTime.TryParse(value, out var dateTime) == false)
                            cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@datevalue", dateTime);
                        SQL_Parameter.Date_Time(cmd.Parameters, "@datevalue", value);
                        cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                        cmd.Parameters.AddWithValue("@value", DBNull.Value);
                        cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                        break;
                }

                cmd.ExecuteNonQuery();
            }
        }
        public static void Save_Date_StartUp1()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, MachineIndex, Uppstart, Datevalue)
                    VALUES (@orderid, @protocoldescriptionid, @machineindex, @uppstart, @datevalue)";

                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@protocoldescriptionid", 239);
                SQL_Parameter.NullableINT(cmd.Parameters, "@uppstart", 1);
                SQL_Parameter.NullableINT(cmd.Parameters, "@machineindex", 1);
                cmd.Parameters.AddWithValue("@datevalue", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
