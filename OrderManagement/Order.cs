using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using DigitalProductionProgram.Protocols.MainInfo;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.QC;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;
using static DigitalProductionProgram.OrderManagement.Manage_WorkOperation;
using CustomProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;

namespace DigitalProductionProgram.OrderManagement
{
    public abstract class Order
    {
        private static int TotalOrders
        {
            get
            {
                if (string.IsNullOrEmpty(RevNr))
                    return Part.TotalOrders_WithoutProcesscard;
                return Part.TotalOrders_WithProcesscardBasedOn_DevelopmentOfProcesscard;
            }
        }

        public static WorkOperations WorkOperation;

        public static int WorkoperationID
        {
            get
            {
                if (WorkOperation == WorkOperations.Nothing)
                    return 0;

                return Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@workoperation", WorkOperation.ToString());
                    var value = cmd.ExecuteScalar();
                    return value != null ? Convert.ToInt32(value) : 0;
                });
            }
        }
        public static string? OrderNumber { get; set; }
        public static string? Operation { get; set; }
        public static int? OrderID { get; set; }
        public static int LastOrderID
        {
            get
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = @"
                SELECT TOP(2) OrderID
                FROM [Order].MainData
                WHERE PartID = @partid
                  AND OrderID != @orderid
                ORDER BY Date_Start DESC";

                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@partid", PartID);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);

                    var value = cmd.ExecuteScalar();
                    if (value != null && int.TryParse(value.ToString(), out var lastorderid))
                        return lastorderid;

                    return 0;
                });
            }
        }
        public static int Total_Orders
        {
            get
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = @"SELECT COUNT(*) FROM [Order].MainData";
                    using var cmd = new SqlCommand(query, con);
                    var total = cmd.ExecuteScalar();
                    if (total != null && total != DBNull.Value)
                        return Convert.ToInt32(total);
                    return 0;
                });
            }
        }
        public static List<string?> List_Orders
        {
            get
            {
                return Database.ExecuteSafe(con =>
                {
                    var list = new List<string?>();
                    const string query = @"
                        SELECT DISTINCT OrderNr
                        FROM [Order].MainData
                        WHERE WorkOperationID = 
                        (
                            SELECT ID
                            FROM Workoperation.Names
                            WHERE Name = @workoperation
                                AND ID IS NOT NULL
                        )
                        ORDER BY OrderNr";
                    using var cmd = new SqlCommand(query, con);
                    SQL_Parameter.String(cmd.Parameters, "@workoperation", WorkOperation.ToString());

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0]?.ToString());

                    return list;
                });
            }
        }
        public static List<string?> List_ProdType
        {
            get
            {
                return Database.ExecuteSafe(con =>
                {
                    var list = new List<string?>();
                    const string query = @"
                SELECT DISTINCT ProdType
                FROM [Order].MainData
                WHERE WorkOperationID = (
                    SELECT ID FROM Workoperation.Names
                    WHERE Name = @workoperation AND ID IS NOT NULL
                )
                ORDER BY ProdType";

                    using var cmd = new SqlCommand(query, con);
                    SQL_Parameter.String(cmd.Parameters, "@workoperation", WorkOperation.ToString());

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0]?.ToString());

                    return list;
                }) ?? []; // fallback om ExecuteSafe returnerar null
            }
        }


        public static void Load_OrderID(string? ordernr, string? operation)
        {
            if (string.IsNullOrEmpty(ordernr))
            {
                OrderID = null;
                return;
            }
            Database.ExecuteSafe(con =>
            {
                const string query = "SELECT OrderID FROM [Order].MainData WHERE OrderNr = @orderNr AND Operation = @operation";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderNr", ordernr);
                cmd.Parameters.AddWithValue("@operation", operation);
                var value = cmd.ExecuteScalar();
                OrderID = (int?)value;
            });
        }



        public static void Load_OrderInformation()
        {
            Load_OrderID(OrderNumber, Operation);
            Load_ProdLine();
           
            WorkOperation = Load_WorkOperation(true, OrderID, PartID);
        }
        public static void Load_OrderInformation_TestOrder()
        {
            Database.ExecuteSafe(con =>
            {
                const string query = @"
            SELECT Operation, ProdLine AS Description
            FROM [Order].MainData
            WHERE OrderNr = @orderNr";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderNr", Order.OrderNumber);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order.Operation = reader["Operation"]?.ToString();
                    Order.Description = reader["Description"]?.ToString();
                }
            });
        }


        public static void Load_Operation(int? orderID)
        {
            if (orderID == null)
                return;

            var operation = Database.ExecuteSafe(con =>
            {
                const string query = "SELECT Operation FROM [Order].MainData WHERE OrderID = @id";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", orderID);

                var value = cmd.ExecuteScalar();
                return value?.ToString();
            });

            if (!string.IsNullOrEmpty(operation))
                Operation = operation;
        }


        public static void Load_ProdLine()
        {
            if (OrderID is null)
                return;

            Database.ExecuteSafe(con =>
            {
                const string query = "SELECT ProdLine FROM [Order].MainData WHERE OrderID = @id";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", OrderID);
                var value = cmd.ExecuteScalar();
                ProdLine = value != null ? value.ToString() : string.Empty;
            });
        }

        public static void Load_ProdType()
        {
            if (OrderID is null)
                return;

            Database.ExecuteSafe(con =>
            {
                const string query = "SELECT ProdType FROM [Order].MainData WHERE OrderID = @orderid";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                var value = cmd.ExecuteScalar();
                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                    ProdType = value.ToString();
            });

            // Om vi fortfarande inte har ProdType, hämta från Processcard
            if (string.IsNullOrEmpty(ProdType) && PartID != null)
            {
                Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT ProdType FROM Processcard.MainData WHERE PartID = @partid";
                    using var cmd = new SqlCommand(query, con);
                    SQL_Parameter.NullableINT(cmd.Parameters, "@partid", PartID);
                    var value = cmd.ExecuteScalar();
                    if (value != null && !string.IsNullOrEmpty(value.ToString()))
                        ProdType = value.ToString();
                });
            }
        }


        public static int Amount { get; set; }
        public static int NumberOfLayers { get; set; } = 1;
        public static int? Create_NewOrderID
        {
            get
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT TOP(1) OrderID FROM [Order].MainData ORDER BY OrderID DESC";
                    using var cmd = new SqlCommand(query, con);
                    var value = cmd.ExecuteScalar();
                    if (value is null)
                        return 1;
                    return (int)value + 1;
                });
            }
        }

        public static int? PartID { get; set; }
        public static int? PartGroupID { get; set; }
        public static string? PartNumber { get; set; }
        public static string? RevNr { get; set; }
        public static string Department { get; set; }
        public static string? Description { get; set; }
        public static string Draghastighet { get; set; }
        public static string Enhet { get; set; }
        public static string? Customer { get; set; }
        
        public static string ProdGroup { get; set; }
        public static string ProdGrupp_pgrKod { get; set; }
        public static string? ProdType { get; set; }
        public static string? ProdLine { get; set; }
        
        public static string? HS_Pipe_1 { get; set; }
        public static string? HS_Pipe_2 { get; set; }
        public static string? HS_Pipe_3 { get; set; }
        public static string StartTime { get; set; }
        public static string StopTime { get; set; }
        public static string VersionNr_ActiveOrder
        {
            get
            {
                if (string.IsNullOrEmpty(OrderNumber))
                    return string.Empty;

                return Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT Version FROM [Order].MainData WHERE OrderID = @orderid";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    var value = cmd.ExecuteScalar();
                    return value?.ToString() ?? string.Empty;
                });
            }
        }

        public static string Rating
        {
            get
            {
                if (string.IsNullOrEmpty(OrderNumber) || OrderID is null)
                    return string.Empty;
                return Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT Points FROM [Order].MainData WHERE OrderID = @orderid";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    var value = cmd.ExecuteScalar();
                    return value?.ToString() ?? string.Empty;
                });
            }
        }


        public static bool Is_PrintOutCopy { get; set; }

        public static bool IsOrderDone { get; set; }
        public static void Set_IsOrderDone()
        {
            if (OrderID is null || OrderNumber == "Q12345")
            {
                IsOrderDone = false;
                return;
            }
            IsOrderDone = Database.ExecuteSafe(con =>
            {
                const string query = "SELECT IsOrderDone FROM [Order].MainData WHERE OrderID = @orderid";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", OrderID);

                var value = cmd.ExecuteScalar();
                if (value == null)
                    return false;
                return bool.TryParse(value.ToString(), out var result) && result;
            });
        }


        public static void DeActivateOrder(int orderid, string comment)
        {
            Database.ExecuteSafe(con =>
            {
                const string query = @"
                    IF NOT EXISTS (SELECT OrderID FROM [Order].InactiveOrders WHERE OrderID = @orderid)
                    BEGIN
                        INSERT INTO [Order].InactiveOrders 
                            (OrderID, Comment, InactivatedBy_Name, InactivatedBy_EmployeeNr, Inactivated_Date)
                        VALUES 
                            (@orderid, @comment, @name, @employeenr, @date)
                    END";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@comment", comment);
                cmd.Parameters.AddWithValue("@name", Person.Name);
                cmd.Parameters.AddWithValue("@employeenr", Person.EmployeeNr);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                cmd.ExecuteNonQuery();
            });
        }
        public static void ActivateOrder(int orderid)
        {
            Database.ExecuteSafe(con =>
            {
                const string query = @"
                    DELETE FROM [Order].InactiveOrders
                    WHERE OrderID = @orderid";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.ExecuteNonQuery();
            });
        }
        public static bool IsOrderDone_Before
        {
            get
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT Date_Stop FROM [Order].MainData WHERE OrderID = @orderid";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    var result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value;
                });
            }
        }
        public static bool IsOrderExist(string? orderNumber, string? operation)
        {
            if (string.IsNullOrEmpty(orderNumber))
                return false;

            return Database.ExecuteSafe(con =>
            {
                const string query = "SELECT 1 FROM [Order].MainData WHERE OrderNr = @ordernumber AND Operation = @operation";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ordernumber", orderNumber);
                cmd.Parameters.AddWithValue("@operation", operation);
                using var reader = cmd.ExecuteReader();
                return reader.HasRows;
            });
        }

        private static bool IsOnlyTestRun =>
            new[] { "D", "TR", "SP" }.Any(prefix => OrderNumber.StartsWith(prefix));
        public static bool IsPointsSetForOrder
        {
            get
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT 1 FROM [Order].MainData WHERE OrderID = @orderid AND Points IS NOT NULL";

                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    using var reader = cmd.ExecuteReader();
                    return reader.HasRows;
                });
            }
        }

        public static bool IsUsingBioBurdenSamples { get; set; }



        public static TimeSpan Total_RunTime_Order
        {
            get
            {
                if (OrderID is null)
                    return TimeSpan.Zero;

                var start = Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT Date_Start FROM [Order].Data WHERE OrderID = @orderid";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);

                    var result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                        return DateTime.Now; // fallback om starttid saknas
                    return DateTime.Parse(result.ToString());
                });

                var stop = DateTime.Now;
                return stop - start;
            }
        }

        public static void Set_NumberOfLayers()
        {
            NumberOfLayers = 1;

            if (WorkOperation != WorkOperations.Extrudering_Termo)
                return;

            var isExtraLayer = Database.ExecuteSafe(con =>
            {
                const string query = @"
                    SELECT IsExtraInputBoxes_2Layer 
                    FROM MeasureProtocol.MainTemplate
                    WHERE MeasureProtocolMainTemplateID = @measureprotocoltemplateid";

                using var cmd = new SqlCommand(query, con);
                SQL_Parameter.Int(cmd.Parameters, "@measureprotocoltemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                var value = cmd.ExecuteScalar();
                if (value == null || value == DBNull.Value)
                    return false;

                return bool.TryParse(value.ToString(), out var result) && result;
            });

            NumberOfLayers = isExtraLayer ? 2 : 1;
        }

        public static void Check_BioBurden_Samples(int mätning, int totalAmount, Control form)
        {
            if (Order.IsUsingBioBurdenSamples == false)
                return;
            if (totalAmount == 0)
                return;
            
            var percent_Order = mätning / (Amount / (double)totalAmount);

            if (percent_Order is > 0.45 and < 0.50)
                InfoText.Show("Du har snart kört halva ordern så var beredd på att ta Bioburden prover.", CustomColors.InfoText_Color.Info, "Info", form);

            if (!(percent_Order >= 0.50) || Korprotokoll.IsBioburdenSamplesTaken) 
                return;
            InfoText.Question("Halva ordern är nu körd och du skall ta Bioburden prover för denna order.\n" +
                          "Bekräfta här genom att trycka på Ja att du tagit prover.\n" +
                          "Trycker du Nej kommer denna varning även vid nästa mätning.", CustomColors.InfoText_Color.Warning, "BioBurden samples!", null);
            if (InfoText.answer == InfoText.Answer.Yes)
                SaveData.INSERT_BioBurdenSamples();
        }
        public static void CheckIfOldOrderNotDoneExists(ref string? ordernr, ref string? operation)
        {
            //Kontrollerar om Användare har startat en order för länge sedan som fortfarande ligger öppen och ej avslutad

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"SELECT TOP(1) OrderNr, Operation, Date_Start FROM [Order].MainData WHERE IsOrderDone = 'False' AND Date_Start < @datum AND Name_Start = @namn";
            con.Open();
            var cmd = new SqlCommand(query, con); 
            cmd.Parameters.AddWithValue("@datum", DateTime.Now.AddMonths(-3));
            cmd.Parameters.AddWithValue("@namn", Person.Name);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    TimeSpan months;
                    if (DateTime.TryParse(reader["Date_Start"].ToString(), out var date_Order))
                        months = DateTime.Now.Subtract(date_Order);
                    else
                        months = DateTime.Now.Subtract(DateTime.Now.AddMonths(-3));
                    var dateSpan = Math.Round(months.Days / (365.25 / 12), 0);
                    InfoText.Question($"{Properties.Resources.orderNotDone_1} {reader["OrderNr"]} - Operation {reader["Operation"]} {Properties.Resources.orderNotDone_2} {dateSpan} {Properties.Resources.orderNotDone_3}\n" +
                                      $"{Properties.Resources.orderNotDone_4}\n\n" +
                                      $"{Properties.Resources.orderNotDone_5}", CustomColors.InfoText_Color.Info, "Info");
                    Activity.Start();
                    if (InfoText.answer == InfoText.Answer.Yes)
                    {
                        ordernr = reader[0].ToString();
                        operation = reader[1].ToString();
                        Points.Add_Points(100, $"Öppnade Order {ordernr}-{operation} för att avsluta den.");
                            
                        return;
                    }

                    Points.Add_Points(-10, $"Öppnade INTE Order {ordernr}-{operation} för att avsluta den.");
                }
            }
        }
        public static void Clear_Order()
        {
            WorkOperation = WorkOperations.Nothing;
          
            OrderNumber = null;
            OrderID = null;
            Operation = null;
            Description = null;
            PartNumber = null;
            PartGroupID = null;
            ProdLine = null;
            PartID = null;
            RevNr = null;


            Amount = 0;
            Department = null;
            Description = null;
            ProdType = null;

            Draghastighet = null;
            Enhet = null;
            NumberOfLayers = 0;
            Customer = null;
            Equipment.Equipment.HS_Machine = null;
            Templates_Protocol.MainTemplate.Revision = null;
            Templates_Protocol.MainTemplate.Name = null;
            Templates_Protocol.MainTemplate.ID = 0;
            Templates_MeasureProtocol.MainTemplate.ID = null;
            Templates_MeasureProtocol.MainTemplate.Name = null;
            Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID = null;
            HS_Pipe_1 = null;
            HS_Pipe_2 = null;
            HS_Pipe_3 = null;
            StartTime = null;
            StopTime = null;

            Monitor.Monitor.Order = null;
        }

        public static void DELETE_Order()
        {
            if (OrderID is null)
                return;

            Database.ExecuteSafe(con =>
            {
                const string query = @"
            BEGIN TRANSACTION
                DELETE FROM [Order].Compound WHERE OrderID = @id;
                DELETE FROM [Order].Compound_Main WHERE OrderID = @id;
                DELETE FROM [Order].Data WHERE OrderID = @id; 
                DELETE FROM [Order].ExtraComments WHERE OrderID = @id;                       
                DELETE FROM [Order].MainData WHERE OrderID = @id;    
                DELETE FROM Korprotokoll_Slipning_Maskinparametrar WHERE OrderID = @id;                         
                DELETE FROM Korprotokoll_Slipning_Produktion WHERE OrderID = @id;
                DELETE FROM [Order].PreFab WHERE OrderID = @id;
                DELETE FROM Measureprotocol.Data WHERE OrderID = @id; 
                DELETE FROM Measureprotocol.MainData WHERE OrderID = @id; 
                DELETE FROM MeasureInstruments.Mätdon WHERE OrderID = @id;
                DELETE FROM Processcard.ProposedChanges WHERE OrderID = @id;
                DELETE FROM [Order].Läcksökning WHERE OrderID = @id;  
                DELETE FROM Zumbach.Data WHERE OrderID = @id;
                DELETE FROM Zumbach.Measurements WHERE OrderID = @id;
            COMMIT TRANSACTION";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", OrderID);
                cmd.ExecuteNonQuery();
                return true;
            });
        }







        public static class Start
        {
            private static bool IsOrderOkToStart
            {
                get
                {
                    if (string.IsNullOrEmpty(OrderNumber) == false)
                        if (OrderNumber[0] == 'D' || (OrderNumber[0] == 'S' && OrderNumber[1] == 'P'))
                            return true;

                    if (Processcard.IsUnderConstruction == false && Processcard.IsApproved_By_QA(PartID) == false)
                        return CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.StartOrderWithoutQA_sign);

                    if (Monitor.Monitor.factory == Monitor.Monitor.Factory.Holding || Processcard.IsNotUsingProcesscard(WorkOperation) || Processcard.IsUnderConstruction == false)
                        return true;

                    var totalOrders = TotalOrders;

                    switch (totalOrders)
                    {
                        case 0:
                        case 1:
                        case 2:
                            return true;
                        case 3: //Startar 4e Ordern
                            InfoText.Show(string.Format(Properties.Resources.mail_Subject_NotifyOrderStartCount, PartNumber, totalOrders + 1), CustomColors.InfoText_Color.Warning, "Warning!");
                            Mail.NotifyOrderStartCount_4to5(totalOrders + 1);
                            return true;
                        case 4: //Startar 5e Ordern
                        {
                            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.StartOrderNr_5_WithoutProcesscard))
                            {
                                Mail.NotifyOrderStartCount_4to5(totalOrders + 1);
                                return true;
                            }

                            return false;
                        }
                        case 5: //Startar 6e Ordern
                        {
                            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.StartOrderNr_6_WithoutProcesscard))
                            {
                                Mail.NotifyOrderStartCount_6(totalOrders + 1);
                                Mail.NotifyCustomerServiceOrderCount_6();
                                InfoText.Show(string.Format(Properties.Resources.notifyUserOrderStartCount_6, PartNumber, totalOrders + 1), CustomColors.InfoText_Color.Warning, "Warning!");
                                return true;
                            }

                            return false;
                        }
                        default: //Startar 7e ordern eller senare
                        {
                            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.StartOrderNr_7_WithoutProcesscard))
                            {
                                Mail.NotifyOrderStartCount_4to5(totalOrders + 1);
                                InfoText.Show(string.Format(Properties.Resources.notifyDirectorOrderStartCount_7, PartNumber), CustomColors.InfoText_Color.Warning, "Warning!");

                                return true;
                            }

                            return false;
                        }
                    }
                }
            }

            private static bool IsUserNotLoggedIn(Control form)
            {
                if (string.IsNullOrEmpty(Person.Name))
                {
                    InfoText.Show(Properties.Resources.startOrder_NeedLogin, CustomColors.InfoText_Color.Warning, "Warning", form);

                    CustomProgressBar.close();
                    return true;
                }
                return false;
            }
            private static bool IsWorkOperationOk(Control form)
            {
                if (WorkOperation == WorkOperations.Nothing)
                {
                    using var A_OP = new Manage_WorkOperation();
                    A_OP.ShowDialog();
                }
                if (WorkOperation == WorkOperations.Nothing)
                {
                    InfoText.Show(Properties.Resources.startOrder_NoWorkoperation, CustomColors.InfoText_Color.Bad, "Warning", form);

                    CustomProgressBar.close();
                    return false;
                }

                return true;
            }

            private static void ResetOrder(Main_Form main)
            {
                main.Clear_Mainform();
                main.cf_OrderInformation.tb_OrderNr.Focus();
                CustomProgressBar.close();
                //IsOkStartOrder = false;
            }
            public static void New_Order(Main_Form main, ref bool IsOkStartOrder)
            {
                Activity.Start();
                RevNr = string.Empty;

                if (IsUserNotLoggedIn(main))
                {
                    ResetOrder(main);
                    return;
                }

                InfoText.Question($"{Properties.Resources.StartOrder} {OrderNumber} - {ProdLine}?", CustomColors.InfoText_Color.Info, $"{WorkOperation}", null);
                if (InfoText.answer == InfoText.Answer.No)
                {
                    ResetOrder(main);
                    return;
                }

                IsOkStartOrder = true;
                OrderID = Create_NewOrderID;
                if (IsWorkOperationOk(main) == false)
                {
                    ResetOrder(main);
                    return;
                }
                main.cf_OrderInformation.LoadMainForm_NewOrder();
                main.cf_OrderInformation.lbl_Version.Text = ChangeLog.CurrentVersion.ToString();


                if (IsChosen_ProcesscardOk == false || IsOrderOkToStart == false)
                {
                    ResetOrder(main);
                    return;
                }

                if (IsOkStartOrder || Part.IsPartID_Exist() == false)
                {
                    main.Load_MeasurePoints();
                    Templates_Protocol.MainTemplate.Set_MainTemplateID(ref IsOkStartOrder);
                    Templates_MeasureProtocol.MainTemplate.Set_MainTemplateID(ref IsOkStartOrder);
                    Templates_LineClearance.MainTemplate.Set_MainTemplateID();
                    if (!IsOkStartOrder)
                    {
                        InfoText.Show(Properties.Resources.selectTemplateError, CustomColors.InfoText_Color.Bad, "Warning", main);
                        ResetOrder(main);
                        return;
                    }
                   
                    Save_MainInfo(); //Hämtar data från Processkorten och lägger till det till ordern
                }
                else
                {
                    ResetOrder(main);
                    return;
                }
                if (QC_Feedback.IsOperationHaveQCFeedback)
                {
                    using var qc = new QC_Feedback(false, true, true);
                    qc.ShowDialog();
                }
                
                IsOrderDone = false;
                Load_ProdType();
                Templates_Protocol.MainTemplate.Revision = Korprotokoll.ProtocolTemplateRevision.OrderNr(OrderID);
                _ = Activity.Stop($"""
                                   Starting Order: {Order.OrderNumber} - {Order.Operation} by {Person.Name} 
                                   | ProtocolMainTemplateID = {Templates_Protocol.MainTemplate.ID} 
                                   | MeasurementProtocolTemplateID = {Templates_MeasureProtocol.MainTemplate.ID}
                                   | LineClearanceMainTemplateID = {Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID}
                                   """);
                _ = Main_FilterQuickOpen.Load_ListAsync(main.dgv_QuickOpen);
            }


            public static void OpenRandomOrder(Main_OrderInformation cf_OrderInformation)
            {
                // Hämta en slumpmässig OrderID via ExecuteSafe som returnerar värde
                var orderid = Database.ExecuteSafe(con =>
                {
                    const string query = @"
                        SELECT TOP(1) OrderID
                        FROM [Order].MainData
                        ORDER BY NEWID()";

                    using var cmd = new SqlCommand(query, con);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                });

                if (orderid == 0)
                {
                    InfoText.Show("Kunde inte hämta en slumpmässig order.", CustomColors.InfoText_Color.Bad, "Fel", null);
                    return;
                }
                // Logga in via API och starta order
                Login_Monitor.Login_API();
                cf_OrderInformation.tb_OrderNr.Text = orderid.ToString();
                cf_OrderInformation.StartOrder();
            }


            private static bool IsChosen_ProcesscardOk
            {
                get
                {
                    if (Order.PartID > 0)
                        return true;
                    if (!string.IsNullOrEmpty(RevNr))
                        return true;

                    if (Processcard.IsMultipleProcesscard(WorkOperation))
                    {
                        using var chooseProcesscard_StartOrder = new ProcesscardTemplateSelector(true, false, false, false); 
                        using var black = new BlackBackground("", 70);
                        black.Show();
                        chooseProcesscard_StartOrder.ShowDialog();
                        black.Close();
                    }

                    if (OrderNumber is null)
                        return false;
                    if (PartID is null)
                        return true;
                    RevNr = Processkort_General.LoadRevNr();
                    return true;
                }
            }

            private static void Save_MainInfo()
            {
                SaveData.INSERT_Korprotokoll_MainData();
                Module.IsOkToSave = true;
                switch (WorkOperation)
                {
                    
                    case WorkOperations.Extrudering_FEP:
                        Korprotokoll.Save_Date_StartUp1();
                        Korprotokoll.Save_Data("", 213, 0, 1, 1);//Zon 1
                        PreFab.SaveData.SavePrefabFromMonitor();
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                        break;

                    case WorkOperations.Extrudering_Termo:
                    case WorkOperations.Extrudering_Tryck:
                        Korprotokoll.Save_Date_StartUp1();
                        PreFab.SaveData.SavePrefabFromMonitor();
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                        break;

                    case WorkOperations.Extrusion_HS:
                        Korprotokoll.Save_Date_StartUp1();
                        PreFab.SaveData.SavePrefabFromMonitor();
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                        break;

                    case WorkOperations.Hackning_TEF:
                    case WorkOperations.Hackning_PTFE:
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                        break;


                    case WorkOperations.Krympslangsblåsning:
                    case WorkOperations.HeatShrink:
                        PreFab.SaveData.SavePrefabFromMonitor();
                        break;

                    case WorkOperations.Extrudering_PTFE:
                    case WorkOperations.Extrudering_Grov_PTFE:
                        PreFab.SaveData.SavePrefabFromMonitor();
                        break;

                    case WorkOperations.Kragning_PTFE:
                    case WorkOperations.Kragning_K22_PTFE:
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                        break;

                    case WorkOperations.Skärmning:
                    case WorkOperations.Svetsning:
                        PreFab.SaveData.SavePrefabFromMonitor();
                        break;

                    case WorkOperations.Synergy_PTFE_K18:
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                        PreFab.SaveData.SavePrefabFromMonitor();
                        break;
                }
                Module.IsOkToSave = false;
            }
        }

        public static class Finish
        {
            private static IEnumerable<int> formTemplateIDs
            {
                get
                {
                    // Filtrerar bort Equipment så att operatörerna lär sig att fylla i all utrustning.
                    // N/A sparas som NULL och då kan man inte avsluta ordern.
                    var blacklist = new HashSet<int>
                    {
                        38, 39, 70, 75, 88, 116
                    };

                    return Database.ExecuteSafe(con =>
                    {
                        var list = new List<int>();

                        const string query = "SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid";
                        using var cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                        using var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader[0] != DBNull.Value)
                            {
                                var id = Convert.ToInt32(reader[0]);
                                if (!blacklist.Contains(id))
                                    list.Add(id);
                            }
                        }

                        return list;
                    });
                }
            }


            private static bool Is_OkFinishOrder(Main_Form main)
            {
                if (IsOrderDone_Before)
                    return true;
                  
                switch (WorkOperation)
                {
                    case WorkOperations.Blandning_PTFE:
                            return Is_Blandning_PTFE_Done(main);
                        
                        case WorkOperations.Extrudering_FEP:
                        case WorkOperations.Svetsning:
                            return Is_Protocol_Done(formTemplateIDs, main) && Is_Halvfabrikat_Done(main) && IsCommentsDone(main);
                        
                        case WorkOperations.Extrudering_PTFE:
                        case WorkOperations.Extrudering_Grov_PTFE:
                            return Is_MeasureEquipmentFilledIn(main) && Is_Halvfabrikat_Done(main) && Is_Protocol_Done(formTemplateIDs, main) && IsCommentsDone(main);
                        
                        case WorkOperations.Extrudering_Termo:
                        case WorkOperations.Extrudering_Tryck:
                        case WorkOperations.Extrusion_HS:
                            return Is_Protocol_Done(formTemplateIDs, main) && Is_MeasureEquipmentFilledIn(main) && Is_CompoundForm_Done(main) && Is_RoomClimate_Done(main) && Is_Halvfabrikat_Done(main) && IsCommentsDone(main);
                        
                        case WorkOperations.Kragning_TEF:
                            return Is_Halvfabrikat_Done(main) && Is_Protocol_Done(formTemplateIDs, main);

                        case WorkOperations.Krympslangsblåsning:
                        case WorkOperations.HeatShrink:
                            return IsHeatShrinkMeasurementsDone(main) && Is_MeasureEquipmentFilledIn(main) && Is_Halvfabrikat_Done(main) && Is_Protocol_Done(formTemplateIDs, main) && IsCommentsDone(main);

                        case WorkOperations.Skärmning:
                            return true;
                        case WorkOperations.Slipning:
                            return Is_Slipning_Done(main) && IsCommentsDone(main);


                    default:
                        return Is_Protocol_Done(formTemplateIDs, main) && Is_MeasureEquipmentFilledIn(main) && IsCommentsDone(main);
                }
                    return false;
            }
            private static bool Is_Protocol_Done(IEnumerable<int> array_formtemplateid, Main_Form main)
            {
                var totalStartUps = Module.TotalStartUps;

                foreach (var formtemplateid in array_formtemplateid)
                {
                    var isDone = Database.ExecuteSafe(con =>
                    {
                        const string query_Processkort = """
                                                            SELECT DISTINCT 
                                                                COALESCE(pc_data.type, template.type) AS type, 
                                                                MachineIndex, 
                                                                descr.CodeText, 
                                                                descr.ID,
                                                                COALESCE(pc_data.TemplateID, template.ID) AS TemplateID, 
                                                                pc_data.Value, 
                                                                pc_data.TextValue, 
                                                                template.RowIndex,
                                                                IsRequired
                                                            FROM Protocol.Template AS template
                                                            FULL OUTER JOIN Processcard.Data AS pc_data
                                                                ON template.ID = pc_data.TemplateID
                                                                AND PartID = @partid
                                                                AND NOT 
                                                                (
                                                                    pc_data.Value IS NULL 
                                                                    AND (pc_data.TextValue IS NULL OR pc_data.TextValue = '')
                                                                )
                                                            LEFT JOIN Protocol.Description AS descr
                                                                ON descr.ID = template.ProtocolDescriptionID
                                                            WHERE template.FormTemplateID = @formtemplateid
                                                                AND ColumnIndex = 1
                                                                AND IsRequired = 1
                                                                AND pc_data.TemplateID IS NOT NULL
                                                            ORDER BY RowIndex, MachineIndex
                                                         """;

                        using var cmd = new SqlCommand(query_Processkort, con);
                        cmd.Parameters.AddWithValue("@partid", PartID);
                        cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);

                        using var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int.TryParse(reader["Type"]?.ToString(), out var type);
                            int.TryParse(reader["ID"]?.ToString(), out var protocolDescriptionId);

                            var codeText = reader["CodeText"]?.ToString();
                            var machine = reader["MachineIndex"]?.ToString();

                            if (codeText == "FILTERHUS")
                            {
                                if (Equipment.Equipment.Is_Filterhus_Used_In_Processcard == false ||
                                    Equipment.Equipment.Is_Filterhus_Used_No_Processcard == false)
                                    break;
                            }

                            switch (type)
                            {
                                case 0:
                                    if (!Is_Value_Exist_In_Korprotokoll(codeText, protocolDescriptionId, "Value", machine, totalStartUps))
                                        return ShowMessage(
                                            string.IsNullOrEmpty(machine)
                                                ? $"{Properties.Resources.orderDone_1} ({codeText})"
                                                : $"{Properties.Resources.orderDone_1} ({codeText}) {Properties.Resources.orderDone_2} {machine}", main);
                                    break;

                                case 1:
                                    if (!Is_Value_Exist_In_Korprotokoll(codeText, protocolDescriptionId, "TextValue", machine, totalStartUps))
                                        return ShowMessage(
                                                string.IsNullOrEmpty(machine)
                                                    ? $"{Properties.Resources.orderDone_1} ({codeText})"
                                            : $"{Properties.Resources.orderDone_1} ({codeText}) {Properties.Resources.orderDone_2} {machine}",main);
                                    break;
                            }
                        }
                        return true;
                            });

                        if (!isDone)
                            return false;
                }
                return true;
            }
            private static bool Is_Blandning_PTFE_Done(Main_Form main)
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT 1 FROM [Order].Data WHERE OrderID = @orderid";

                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);

                    using var reader = cmd.ExecuteReader();
                    return reader.HasRows || ShowMessage("Fyll i Journalen före du avslutar ordern.", main);
                });
            }
            private static bool Is_CompoundForm_Done(Main_Form main)
            {
                if (Settings.Settings.SpecialPartNumbers
                        .DataTable_SpecialPartNr("Kompoundering")
                        .AsEnumerable()
                        .Any(row => PartNumber == row.Field<string>("PartNr")) == false)
                    return true;

                return Database.ExecuteSafe(con =>
                {
                    const string query = @"
            SELECT Size AS Pelletsstorlek, 
                   BulkWeight AS Bulkvikt, 
                   Weight75D AS [Vikt 75D], 
                   Weight55D AS [Vikt 55D]
            FROM [Order].Compound AS kompound
            JOIN [Order].Compound_Main AS main
                ON kompound.OrderID = main.OrderID
            WHERE main.OrderID = @orderid";

                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);

                    using var reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                        return ShowMessage("Du har inte fyllt i Kompounderings-blanketten.", main);
                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            if (string.IsNullOrEmpty(reader[i]?.ToString()))
                            {
                                var message = reader.GetName(i);
                                return ShowMessage($"Fyll i {message} i Kompounderings-blanketten ", main);
                            }
                        }
                    }
                    return true;
                });
            }


            private static bool Is_MeasureEquipmentFilledIn(Main_Form main)
            {
                Part.SetPartNrSpecial("Kompoundering");
                if (Part.IsPartNrSpecial)
                    return true;

                return Database.ExecuteSafe(con =>
                {
                    var query = $"SELECT * FROM MeasureInstruments.Mätdon {Queries.WHERE_OrderID}";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", OrderID);

                    using var reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                        return ShowMessage(Properties.Resources.finishOrder_MeasureEq_2, main);

                    while (reader.Read())
                        if (string.IsNullOrEmpty(reader["Nr"]?.ToString()))
                            return ShowMessage(Properties.Resources.finishOrder_MeasureEq_1, main);
                    return true;
                });
            }
            private static bool Is_Halvfabrikat_Done(Main_Form main)
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT * FROM [Order].PreFab WHERE OrderID = @orderid";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);

                    using var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (string.IsNullOrEmpty(reader["Halvfabrikat_OrderNr"]?.ToString()))
                            return ShowMessage(Properties.Resources.finishOrder_Halvfabrikat_1, main);

                        if (WorkOperation is WorkOperations.Extrudering_Termo or WorkOperations.Extrudering_Tryck or WorkOperations.Extrusion_HS && string.IsNullOrEmpty(reader["Extruder"]?.ToString()))
                            return ShowMessage($"{Properties.Resources.finishOrder_Halvfabrikat_2_1} {reader["Halvfabrikat_ArtikelNr"]} {Properties.Resources.finishOrder_Halvfabrikat_2_2}", main);
                    }

                    return true;
                });
            }
            private static bool Is_RoomClimate_Done(Main_Form main)
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT Rum_Temp, Rum_Fukt FROM [Order].MainData WHERE OrderID = @orderid";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (string.IsNullOrEmpty(reader["Rum_Temp"]?.ToString()))
                            return ShowMessage(Properties.Resources.finishOrder_RoomTemp, main);

                        if (string.IsNullOrEmpty(reader["Rum_Fukt"]?.ToString()))
                            return ShowMessage(Properties.Resources.finishOrder_RoomMoist, main);
                    }

                    return true;
                });
            }
            private static bool IsHeatShrinkMeasurementsDone(Main_Form main)
            {
                if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Length, "LSL") < 500)
                    return true;

                return Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT COUNT(*) FROM Measureprotocol.MainData WHERE OrderID = @orderid";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);

                    var ctr = Convert.ToInt32(cmd.ExecuteScalar());

                    if (ctr < 13 && !IsOnlyTestRun)
                        return ShowMessage(
                            $"{Properties.Resources.finishOrder_2_1} {ctr} {Properties.Resources.finishOrder_2_2}",
                            main);

                    return true;
                });
            }
            private static bool Is_Slipning_Done(Main_Form main)
            {
                return Database.ExecuteSafe(con =>
                {
                    var queryMaskin = $"SELECT * FROM Korprotokoll_Slipning_Maskinparametrar {Queries.WHERE_OrderID}";
                    using (var cmd = new SqlCommand(queryMaskin, con))
                    {
                        cmd.Parameters.AddWithValue("@id", OrderID);
                        using var reader = cmd.ExecuteReader();

                        if (!reader.HasRows)
                            return ShowMessage("Fyll i Maskinparametrarna i Körprotokollet", main);
                    }

                    var queryProd = $"SELECT * FROM Korprotokoll_Slipning_Produktion {Queries.WHERE_OrderID}";
                    using (var cmd = new SqlCommand(queryProd, con))
                    {
                        cmd.Parameters.AddWithValue("@id", OrderID);
                        using var reader = cmd.ExecuteReader();

                        if (!reader.HasRows)
                            return ShowMessage("Fyll i Produktionsparametrarna i Körprotokollet", main);
                    }

                    return true;
                });
            }
            private static bool IsCommentsDone(Main_Form main)
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = "SELECT Comments FROM [Order].MainData WHERE OrderID = @orderid";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (string.IsNullOrEmpty(reader["Comments"]?.ToString()))
                            return ShowMessage(Properties.Resources.finishOrder_Comments, main);
                    }

                    return true;
                });
            }

            private static bool Is_Value_Exist_In_Korprotokoll(string codetext, int protocolDescriptionID, string valueType, string machine, int totalStartups)
            {
                return Database.ExecuteSafe(con =>
                {
                    for (var startUp = 1; startUp <= totalStartups; startUp++)
                    {
                        var query = $@"
                            SELECT {valueType}, Uppstart, MachineIndex
                            FROM [Order].Data
                            WHERE OrderID = @orderid
                                AND ProtocolDescriptionID = @protocoldescriptionid
                                AND Uppstart = @startup";

                        if (!string.IsNullOrEmpty(machine))
                            query += " AND (MachineIndex = @machineindex OR (MachineIndex IS NULL AND @machineindex IS NULL))";

                        using var cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@orderid", OrderID);
                        cmd.Parameters.AddWithValue("@protocoldescriptionid", protocolDescriptionID);
                        cmd.Parameters.AddWithValue("@codetext", codetext);
                        cmd.Parameters.AddWithValue("@startup", startUp);
                        cmd.Parameters.AddWithValue("@machineindex", machine ?? (object)DBNull.Value);

                        using var reader = cmd.ExecuteReader();
                        if (!reader.HasRows)
                            continue;

                        while (reader.Read())
                        {
                            int.TryParse(reader["Uppstart"]?.ToString(), out var uppstart);
                            var value = reader[0]?.ToString();

                            if (Is_Korprotokoll_Value_Discarded(uppstart))
                                continue;

                            if (Is_ValueReportedAndOkToLeaveEmpty(protocolDescriptionID))
                                return true;

                            if (!string.IsNullOrEmpty(value))
                                return true;
                        }
                    }

                    return false;
                });
            }

            private static bool Is_ValueReportedAndOkToLeaveEmpty(int protocolDescriptionID)
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = @"
                        SELECT 1 
                        FROM [Processcard].ProposedChanges 
                        WHERE OrderID = @orderid 
                            AND ProtocolDescriptionID = @protocoldescriptionid";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", protocolDescriptionID);
                    var value = cmd.ExecuteScalar();
                    return value != null;
                });
            }

            private static bool Is_Korprotokoll_Value_Discarded(int uppstart)
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = @"
                    SELECT BoolValue 
                    FROM [Order].Data 
                    WHERE OrderID = @orderid 
                        AND Uppstart = @row 
                        AND ProtocolDescriptionID = @protocoldescriptionid";

                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    cmd.Parameters.AddWithValue("@row", uppstart);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", 174); // 174 = Kasserad

                    var value = cmd.ExecuteScalar();
                    return value != null && bool.TryParse(value.ToString(), out var isDiscarded) && isDiscarded;
                });
            }


            private static bool ShowMessage(string? Text, Main_Form main)
            {
                if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.FinishIncompleteOrder, false))
                {
                    InfoText.Question($"{Text} {Properties.Resources.finishOrder_3_1}\n\n" +
                                  $"{Properties.Resources.finishOrder_3_2} {Person.Role} {Properties.Resources.finishOrder_3_3}\n\n" +
                                  $"{Properties.Resources.finishOrder_3_4}", CustomColors.InfoText_Color.Warning, "Warning!", main);
                    if (InfoText.answer == InfoText.Answer.Yes)
                        return true;
                    return false;
                }

                InfoText.Show($"{Text} {Properties.Resources.finishOrder_3_1}", CustomColors.InfoText_Color.Bad, "Warning", main);
                _ = Activity.Stop($"Error FinishOrder: {Text}");
                return false;
            }

            public static void Order(Main_Form main)
            {
                if (IsOrderDone)
                {
                    InfoText.Show(Properties.Resources.finishOrder_1, CustomColors.InfoText_Color.Bad, "Warning!", main);
                    return;
                }

                if (string.IsNullOrEmpty(Person.Name))
                {
                    InfoText.Show(Properties.Resources.finishOrder_4, CustomColors.InfoText_Color.Bad, "Warning!", main);
                    return;
                }
                Activity.Start();
               // ControlManager.Close_All_Körprotokoll();
                if (Is_OkFinishOrder(main) == false)
                    return;
                

                //Frågar om det är ok att fortsätta med utskrift m.m.
                using var ok = new FinishOrder();
                using var bb = new BlackBackground(string.Empty, 70);
                bb.Show();
                ok.ShowDialog();
                bb.Close();
                if (IsOrderDone == false)
                    return;

                // Check/force a physical printer before starting any preview/print flow.
                if (ok.utskrift && !Manage_PrintOuts.IsPrinterSelected)
                {
                    InfoText.Question("Vill du avsluta ordern och spara ordern som pdf istälelt för att skriva ut den?", CustomColors.InfoText_Color.Warning, "Ingen skrivare vald.");
                    if (InfoText.answer == InfoText.Answer.No) 
                        return;
                }

                // Finishing Order i and set EndDate and Print papers
                if (!IsOrderDone_Before)
                {
                    var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                    var formattedDate = DateTime.Now.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                    main.cf_OrderInformation.lbl_Stopp.Text = formattedDate;

                    SaveData.UPDATE_Order_EndTime(DateTime.Now);
                    _ = Activity.Stop("FinishOrder: Update EndTime [Order].MainData");
                    if (MainProtocol.IsUsingStartUpDates)
                    {
                        SaveData.INSERT_LastStartUp_EndDate();
                        _ = Activity.Stop("FinishOrder: Update EndTime [Order].Data");
                    }
                        
                }

                Is_PrintOutCopy = false;
                _ = Activity.Stop("Prints the order when finished.");
                if (ok.utskrift)
                    main.PrintOut();

                SaveData.UPDATE_OrderKlar();
                IsOrderDone = true;
                _ = Activity.Stop("Order Finished");
                main.cf_MainMenu.Menu_Order_OrderDone.Enabled = false;
                main.cf_MainMenu.Menu_User.Enabled = false;
                main.Change_GUI_OrderKlar();

                //Meddelar processtekniker om eventuella uppdateringar av Processkort
                //Om Artikel är under Framarbetning OCH Antal ordrar körda är 3 så skickas ett mail eller om inget Processkort finns OCH antal körda ordrar = 3
                //D-ordrar skall heller inte 
                // if SuperAdmin close old orders ther is no need to send this mail
                if (Person.Role != "SuperAdmin")
                {
                    _ = Activity.Stop("Finish Order: Sends email notifications about process card updates.");
                    Mail.ProcesscardNeedChanges_FinishOrder();
                    if (TotalOrders == 3 && !Processcard.IsNotUsingProcesscard(WorkOperation))
                        Mail.NotifyOrderFinishedCount_3();
                }

                _ = Main_FilterQuickOpen.Load_ListAsync(main.dgv_QuickOpen);
               
            }
        }
        private static OrderInfoSnapshot? _snapshot;

        private class OrderInfoSnapshot
        {
            public WorkOperations? Workoperation { get; set; }
            public int? OrderID { get; set; }
            public int? PartID { get; set; }
            public int? PartGroupID { get; set; }
            public int MainTemplateID { get; set; }
            public string? Benamning { get; set; }
            public string? OrderNr { get; set; }
            public string? Operation { get; set; }
            public string? PartNr { get; set; }
            public string? RevNr { get; set; }
            public string? ProdLine { get; set; }
            public string? Customer { get; set; }
            public string? ProdType { get; set; }
            public string? ProdGroup { get; set; }
            public string? TemplateRevision { get; set; }
            public string? MainTemplateName { get; set; }
            public int? LineClearanceMainTemplateID { get; set; }
            public int? MeasureProtocolMainTemplateID { get; set; }
        }
        public static void Save_TempOrderInfo()
        {
            _snapshot = new OrderInfoSnapshot
            {
                Benamning = Description,
                MainTemplateName = Templates_Protocol.MainTemplate.Name,
                MainTemplateID = Templates_Protocol.MainTemplate.ID,
                LineClearanceMainTemplateID = Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID,
                MeasureProtocolMainTemplateID = Templates_MeasureProtocol.MainTemplate.ID,
                OrderNr = OrderNumber,
                OrderID = OrderID,
                Operation = Operation,
                PartNr = PartNumber,
                PartID = PartID,
                PartGroupID = PartGroupID,
                RevNr = RevNr,
                Workoperation = WorkOperation,
                ProdLine = ProdLine,
                ProdType = ProdType,
                ProdGroup = ProdGroup,
                Customer = Customer,
                TemplateRevision = Templates_Protocol.MainTemplate.Revision
            };
        }
        public static void Restore_TempOrderInfo()
        {
            if (_snapshot is null)
                return;

            Description = _snapshot.Benamning;
            Templates_Protocol.MainTemplate.Name = _snapshot.MainTemplateName;
            Templates_Protocol.MainTemplate.ID = _snapshot.MainTemplateID;
            Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID = _snapshot.LineClearanceMainTemplateID;
            Templates_MeasureProtocol.MainTemplate.ID = _snapshot.MeasureProtocolMainTemplateID;
            OrderNumber = _snapshot.OrderNr;
            OrderID = _snapshot.OrderID;
            Operation = _snapshot.Operation;
            PartNumber = _snapshot.PartNr;
            PartID = _snapshot.PartID;
            PartGroupID = _snapshot.PartGroupID;
            RevNr = _snapshot.RevNr;
            WorkOperation = (WorkOperations)_snapshot.Workoperation;
            ProdLine = _snapshot.ProdLine;
            ProdType = _snapshot.ProdType;
            ProdGroup = _snapshot.ProdGroup;
            Customer = _snapshot.Customer;
            Templates_Protocol.MainTemplate.Revision = _snapshot.TemplateRevision;
        }

    }
}
