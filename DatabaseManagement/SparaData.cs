using System;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.DatabaseManagement
{
    internal class SaveData
    {
        public static void INSERT_BioBurdenSamples()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "INSERT INTO BioBurden_Samples VALUES (@orderid, @namn, @employeenumber, @datum)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@namn", Person.Name);
                cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                cmd.Parameters.AddWithValue("@datum", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
        }

        public static void INSERT_Kommentar_Byte_BatchNr(string kommentar)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "INSERT INTO [Order].ExtraComments (OrderID, Spole, Kommentar, Datum, AnstNr, is_Locked, Row)" +
                                     "VALUES (@id, @spole, @kommentar, @datum, @employeenumber, 'True', @row)";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                cmd.Parameters.AddWithValue("@spole", "N/A");
                cmd.Parameters.AddWithValue("@kommentar", kommentar);
                cmd.Parameters.AddWithValue("@datum", DateTime.Now);
                cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                cmd.Parameters.AddWithValue("@row", Extra_Comments.Next_Row_ExtraComments);
                con.Open();
                cmd.ExecuteScalar();
            }
        }
        public static void INSERT_Korprotokoll_MainData()
        {
            //Här är ProdType null om inte operatören fått välja Processkort
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                const string query = @"
                        
                INSERT INTO [Order].MainData 
                (
                    WorkOperationID, 
                    ProtocolMainTemplateID, 
                    LineClearanceMainTemplateID, 
                    MeasureProtocolMainTemplateID,
                    OrderID, 
                    OrderNr, 
                    Operation, 
                    PartID, 
                    PartNr, 
                    RevNr, 
                    ProdGroup, 
                    ProdLine, 
                    ProdType, 
                    Customer, 
                    Description, 
                    Amount, 
                    Unit,
                    Name_Start, 
                    Date_Start, 
                    Version, 
                    IsOrderDone, 
                    IsDeleted 
                )
                VALUES 
                (
                    @workoperationid, 
                    @protocolmaintemplateid, 
                    @lineclearancetemplateid,
                    @measureprotocolmaintemplateid, 
                    @orderid, 
                    @ordernr, 
                    @operation, 
                    @partid, 
                    @partnr, 
                    @revNr, 
                    @prodgroup, 
                    @prodline, 
                    @prodtype, 
                    @customer, 
                    @description, 
                    @amount, 
                    @unit,
                    @name_start, 
                    @date_start, 
                    @version, 
                    'False', 
                    'False'
                )";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@workoperationid", Order.WorkoperationID);
                SQL_Parameter.Int(cmd.Parameters, "@protocolmaintemplateid", Templates_Protocol.MainTemplate.ID);
                SQL_Parameter.NullableINT(cmd.Parameters, "@lineclearancetemplateid", Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID);
                cmd.Parameters.AddWithValue("@measureprotocolmaintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@ordernr", Order.OrderNumber);
                cmd.Parameters.AddWithValue("@operation", Order.Operation);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
                cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
                SQL_Parameter.String(cmd.Parameters, "@prodtype", Order.ProdType);
                cmd.Parameters.AddWithValue("@amount", Order.Amount);
                cmd.Parameters.AddWithValue("@unit", Order.Enhet);
               // cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@name_start", Person.Name);
                cmd.Parameters.AddWithValue("@date_start", Order.StartTime);
                cmd.Parameters.AddWithValue("@description", Order.Description);
                SQL_Parameter.String(cmd.Parameters, "@customer", Order.Customer);
                cmd.Parameters.AddWithValue("@prodgroup", Order.ProdGroup);
                SQL_Parameter.String(cmd.Parameters, "@revNr", Order.RevNr);
                cmd.Parameters.AddWithValue("@version", ChangeLog.CurrentVersion.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        
        public static void INSERT_Operatör_Tid_Läsa_MyAnalysis(double seconds)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"IF NOT EXISTS (SELECT * FROM [User].TimeReadChangeLog WHERE UserID = @userid AND Month = @month AND Year = @year)
                                    INSERT INTO [User].TimeReadChangeLog (UserID, Month, Year, Time) VALUES (@userid, @month, @year, @time)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@userid", Person.UserID);
                cmd.Parameters.AddWithValue("@month", DateTime.Now.Month.ToString());
                cmd.Parameters.AddWithValue("@year", DateTime.Now.Year.ToString());
                cmd.Parameters.AddWithValue("@time", seconds);
                cmd.ExecuteNonQuery();
            }
        }
        public static void INSERT_Order_Rating(string point)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"UPDATE [Order].MainData SET Points = @point {Queries.WHERE_OrderID}";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                cmd.Parameters.AddWithValue("@point", point);
                con.Open();
                cmd.ExecuteScalar();
            }
        }




        public static void UPDATE_Användare_Seen_Gallup_Result()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "UPDATE [User].Person SET Seen_Gallup_result = 'True' WHERE EmployeeNumber = @employeenumber";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UPDATE_Processkort_Hantering_Arbetsoperation(string arbetsOperation)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "UPDATE [User].Person SET Processkort_ArbetsOperation = @workoperation WHERE Name = @name";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@workoperation", arbetsOperation);
                cmd.Parameters.AddWithValue("@name", Person.Name);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public static void UPDATE_Korprotokoll_Main_From_Processkort_Main()
        {
            //Improvement: RevNr kanske inte behöver uppdateras här? Det har sitt rätta värde före det kommer hit, men måste kollas ordentligt
            if (Part.IsPartID_Exist() == false)
                return;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                UPDATE [Order].MainData
                SET [Order].MainData.RevNr = pc_main.RevNr,
                    [Order].MainData.ProdType = pc_main.ProdType

                FROM [Order].MainData, Processcard.MainData AS pc_main
                WHERE [Order].MainData.PartID = @partid
                    AND pc_main.PartID = @partid
                    AND pc_main.RevNr = @revNr
                    AND pc_main.WorkOperationID = @workoperationid
                    AND [Order].MainData.OrderID = @orderid";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.Int(cmd.Parameters, "@partid", Order.PartID);
                SQL_Parameter.Int(cmd.Parameters, "@workoperationid", Order.WorkoperationID);
                SQL_Parameter.Int(cmd.Parameters, "@orderid", Order.OrderID);
                if (string.IsNullOrEmpty(Order.RevNr))
                    cmd.Parameters.AddWithValue("@revNr", Processkort_General.Last_RevNr());
                else//Om Testorder skapats så skall revNr vara Order.RevNr annars skall det automatiskt hämtas från Senaste_RevNr_Processkort
                    cmd.Parameters.AddWithValue("@revNr", Order.RevNr);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public static void UPDATE_Korprotokoll_Parametrar_Kassera(string db_Tabell, string datum, string tid, string anstNr)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $"UPDATE {db_Tabell} SET Kasserad = 'True' {Queries.WHERE_OrderID} AND Datum = @datum AND Tid = @tid AND AnstNr = @employeenumber";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                cmd.Parameters.AddWithValue("@datum", datum);
                cmd.Parameters.AddWithValue("@tid", tid);
                cmd.Parameters.AddWithValue("@employeenumber", anstNr);
                con.Open();
                cmd.ExecuteScalar();
            }
        }

        public static void UPDATE_User_Online(bool flag, string anstNr)
        {
            try
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "UPDATE [User].Person SET Online = @flag WHERE EmployeeNumber = @employeenumber";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@flag", flag);
                    cmd.Parameters.AddWithValue("@employeenumber", anstNr);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception e)
            {
                ErrorHandler.Allmänt_Fel(e, "UPDATE_Operatör_Online");
            }

        }
        
        public static void UPDATE_Order_EndTime(DateTime endTime)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "UPDATE [Order].MainData SET Date_Stop = @stop WHERE OrderID = @orderid AND Date_Stop IS NULL";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@stop", endTime);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void INSERT_LastStartUp_EndDate()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                        IF NOT EXISTS (
                            SELECT * 
                            FROM [Order].Data 
                            WHERE OrderID = @orderid 
                                AND ProtocolDescriptionID = 240 
                                AND COALESCE(Uppstart, 0) = COALESCE(@startup, 0)
                            )
                        BEGIN
                            INSERT INTO [Order].Data (
                                OrderID, ProtocolDescriptionID, MachineIndex, Uppstart, Value, TextValue, BoolValue, DateValue) 
                            VALUES (
                                @orderid, 240, 1, @startup, @value, @textvalue, @boolvalue, @datevalue)
                        END";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@startup", Module.TotalStartUps);
                cmd.Parameters.AddWithValue("@value", DBNull.Value);
                cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                cmd.Parameters.AddWithValue("@datevalue", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void UPDATE_OrderKlar()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "UPDATE [Order].MainData SET IsOrderDone = 'True' WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void UPDATE_Unlock_OrderDone()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $"UPDATE [Order].MainData SET IsOrderDone = 'False' {Queries.WHERE_OrderID}";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
            }
        }


        public static void DELETE_Value_Zumbach_Multiple(int min, int max, int påse, int position)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"DELETE FROM Zumbach.Data WHERE OrderID = @orderid AND Bag = @bag AND Position = @pos
                    AND ID BETWEEN @id_min AND @id_max";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@bag", påse);
                cmd.Parameters.AddWithValue("@pos", position);

                cmd.Parameters.AddWithValue("@id_min", min);
                cmd.Parameters.AddWithValue("@id_max", max);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public static async void Reset_Processcard_Open(bool is_Ok_To_Reset)
        {
            if (Order.OrderID is null)
                return;

            if (!string.IsNullOrEmpty(Person.Name) && (Environment.MachineName == Korprotokoll.Open_ByComputer) && (Person.Name == Korprotokoll.Open_ByUser) || is_Ok_To_Reset)
            {
                await Activity.Stop($"Användare: {Person.Name} på Dator: {Environment.MachineName} Loggar ut Användare {Korprotokoll.Open_ByUser} från Dator {Korprotokoll.Open_ByComputer}");

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = Queries.UPDATE_Reset_Processcard_Open;
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    con.Open();
                    cmd.ExecuteScalar();
                }
            }
        }
        public static void Set_Processcard_Open()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var cmd = new SqlCommand(Queries.UPDATE_Set_Processcard_Open, con);
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                cmd.Parameters.AddWithValue("@användare", Person.Name);
                cmd.Parameters.AddWithValue("@computer", Environment.MachineName);
                con.Open();
                cmd.ExecuteScalar();
            }
        }

    }
    public class Meddelande
    {
        public static void UPDATE_Meddelande_Kvittera_Läst(string meddelande)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "UPDATE Meddelanden SET Läst = 'True' WHERE Mottagare = @mottagare AND Meddelande = @meddelande";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@mottagare", Person.Name);
                cmd.Parameters.AddWithValue("@meddelande", meddelande);
                con.Open();
                cmd.ExecuteScalar();
            }
        }

    }

}
