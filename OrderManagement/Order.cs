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
    public class Order
    {
        public static int TotalOrders
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
                    ServerStatus.Add_Sql_Counter();
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
                Database.ExecuteSafe(con =>
                {
                    var query = @"
                    SELECT TOP(2) OrderID
                    FROM [Order].MainData
                    WHERE PartID = @partid
                    AND OrderID != @orderid
                    ORDER BY Date_Start DESC";

                    using var cmd = new SqlCommand(query, con);
                    ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", PartID);
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    var value = cmd.ExecuteScalar();
                    return value != null && int.TryParse(value.ToString(), out var lastorderid)
                        ? lastorderid : 0;
                });
                return 0;
            }
        }
        public static int Total_Orders
        {
            get
            {
                Database.ExecuteSafe(con =>
                {
                    const string query = @"SELECT COUNT(*) FROM [Order].MainData";
                    var cmd = new SqlCommand(query, con);
                    ServerStatus.Add_Sql_Counter();
                    var total = cmd.ExecuteScalar();
                    if (total != null)
                        return int.Parse(total.ToString());
                    return 0;
                });
                return 0;
            }
        }
        public static List<string?> List_Orders
        {
            get
            {
                var list = new List<string?>();
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"SELECT DISTINCT OrderNr FROM [Order].MainData WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) ORDER BY OrderNr";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.String(cmd.Parameters, "@workoperation", WorkOperation.ToString());
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader[0].ToString());
                return list;
            }
        }
        public static List<string> List_OrderNrPrefix
        {
            get
            {
                var list = new List<string>();

                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"SELECT DISTINCT LEFT ([Order].MainData.OrderNr, 1) FROM [Order].MainData";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader[0].ToString());
                return list;
            }
        }
        public static List<string?> List_ProdType
        {
            get
            {
                var list = new List<string?>();
                Database.ExecuteSafe(con =>
                {
                    const string query = @"SELECT DISTINCT ProdType FROM [Order].MainData WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) ORDER BY ProdType";
                    var cmd = new SqlCommand(query, con);
                    ServerStatus.Add_Sql_Counter();
                    SQL_Parameter.String(cmd.Parameters, "@workoperation", WorkOperation.ToString());
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0].ToString());
                    return list;
                });
                return list;
            }
        }
        
        public static void Load_OrderID(string? ordernr, string? operation)
        {
            if (string.IsNullOrEmpty(ordernr))
            {
                OrderID = null;
                return;
            }
                
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT OrderID FROM [Order].MainData WHERE OrderNr = @orderNr AND Operation = @operation";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderNr", ordernr);
                cmd.Parameters.AddWithValue("@operation", operation);
                var value = cmd.ExecuteScalar();
                OrderID = (int?)value;
            }
        }

        public static int? GetOrderID(string? ordernr, string operation)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT OrderID FROM [Order].MainData WHERE OrderNr = @orderNr AND Operation = @operation";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderNr", ordernr);
            cmd.Parameters.AddWithValue("@operation", operation);
            var value = cmd.ExecuteScalar();
            return (int?)value;
        }
        public static string GetOrderNr(int orderid)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT OrderNr FROM [Order].MainData WHERE OrderID = @orderid";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                var value = cmd.ExecuteScalar();
                return value.ToString();
            }
        }

        private static WorkOperations Temp_Workoperation;
        private static int? Temp_OrderID;
        private static int? Temp_PartID;
        private static int? Temp_PartGroupID;
        private static int Temp_MainTemplateID;
        private static string? Temp_Benämning;
        private static string? Temp_OrderNr;
        private static string? Temp_Operation;
        private static string? Temp_PartNr;
        private static string? Temp_RevNr;
        private static string? Temp_ProdLine;
        private static string? Temp_Customer;
        private static string? Temp_ProdType;
        private static string Temp_ProdGroup;
        private static string? Temp_TemplateRevision;
        private static int? Temp_LineClearanceMainTemplateID;
        private static int? Temp_MeasureProtocolMainTemplateID;

        public static void Save_TempOrderInfo()
        {
            Temp_Benämning = Description;
            Temp_MainTemplateID = Templates_Protocol.MainTemplate.ID;
            Temp_LineClearanceMainTemplateID = Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID;
            Temp_MeasureProtocolMainTemplateID = Templates_MeasureProtocol.MainTemplate.ID;
            Temp_OrderNr = OrderNumber;
            Temp_OrderID = OrderID;
            Temp_Operation = Operation;
            Temp_PartNr = PartNumber;
            Temp_PartID = PartID;
            Temp_PartGroupID = PartGroupID;
            Temp_RevNr = RevNr;
            Temp_Workoperation = WorkOperation;
            Temp_ProdLine = ProdLine;
            Temp_ProdType = ProdType;
            Temp_ProdGroup = ProdGroup;
            Temp_Customer = Customer;
            Temp_TemplateRevision = Templates_Protocol.MainTemplate.Revision;

        }
        public static void Restore_TempOrderInfo()
        {
            Description = Temp_Benämning;
            Templates_Protocol.MainTemplate.ID = Temp_MainTemplateID;
            Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID = Temp_LineClearanceMainTemplateID;
            Templates_MeasureProtocol.MainTemplate.ID = Temp_MeasureProtocolMainTemplateID;
            OrderNumber = Temp_OrderNr;
            OrderID = Temp_OrderID;
            Operation = Temp_Operation;
            PartNumber = Temp_PartNr;
            PartID = Temp_PartID;
            PartGroupID = Temp_PartGroupID;
            RevNr = Temp_RevNr;
            WorkOperation = Temp_Workoperation;
            ProdLine = Temp_ProdLine;
            ProdType = Temp_ProdType;
            ProdGroup = Temp_ProdGroup;
            Customer = Temp_Customer;
            Templates_Protocol.MainTemplate.Revision = Temp_TemplateRevision;
        }

        public static void Load_OrderInformation()
        {
            Load_OrderID(OrderNumber, Operation);
            Load_ProdLine();
           
            WorkOperation = Load_WorkOperation(true, OrderID, PartID);
        }
        public static void Load_OrderInformation_TestOrder()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"SELECT Operation, ProdLine AS Description FROM [Order].MainData WHERE OrderNr = @orderNr";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderNr", Order.OrderNumber);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Order.Operation = reader["Operation"].ToString();
                Order.Description = reader["Description"].ToString();
            }
        }
        public static void Load_Operation(int? orderID)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT Operation FROM [Order].MainData WHERE OrderID = @id";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@id", orderID);
            var value = cmd.ExecuteScalar();
            Operation = (string)value;
        }
        public static void Load_ProdLine()
        {
            if (OrderID is null)
                return;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT ProdLine FROM [Order].MainData WHERE OrderID = @id";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@id", OrderID);
            var value = cmd.ExecuteScalar();
            ProdLine = value != null ? value.ToString() : string.Empty;
        }
        public static void Load_ProdType()
        {
            if (OrderID is null)
                return;
            if (string.IsNullOrEmpty(OrderNumber))
                ProdType = null;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT ProdType FROM [Order].MainData WHERE OrderID = @orderid";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!string.IsNullOrEmpty(reader[0].ToString()))
                        ProdType = reader[0].ToString();
                }
            }

            if (!(string.IsNullOrEmpty(ProdType) & !string.IsNullOrEmpty(PartNumber)))
                return;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT ProdType FROM Processcard.MainData WHERE PartID = @partid";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", PartID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    if (!string.IsNullOrEmpty(reader[0].ToString()))
                        ProdType = reader[0].ToString();
            }

        }

        public static int Amount { get; set; }
        public static int NumberOfLayers { get; set; } = 1;
        public static int? Create_NewOrderID
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT TOP(1) OrderID FROM [Order].MainData ORDER BY OrderID DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var value = cmd.ExecuteScalar();
                if (value is null)
                    return 1;
                return (int)value + 1;
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
                    return null;
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT Version FROM [Order].MainData WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                con.Open();
                return cmd.ExecuteScalar().ToString() ?? string.Empty;
            }
        }
        public static string Rating
        {
            get
            {
                if (string.IsNullOrEmpty(OrderNumber) || OrderID is null)
                    return string.Empty;
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT Points FROM [Order].MainData WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return value.ToString();

                return "";
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

            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT IsOrderDone FROM [Order].MainData WHERE OrderID = @orderid";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", OrderID);
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value == null)
                IsOrderDone = false;
            bool.TryParse(value.ToString(), out var isOrderDone);
            IsOrderDone = isOrderDone;
        }

        public static void DeActivateOrder(int orderid, string comment)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    IF NOT EXISTS (SELECT OrderID FROM [Order].InactiveOrders WHERE OrderID = @orderid)
                    BEGIN
                        INSERT INTO [Order].InactiveOrders (OrderID, Comment, InactivatedBy_Name, InactivatedBy_EmployeeNr, Inactivated_Date)
                        VALUES (@orderid, @comment, @name, @employeenr, @date)
                    END";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@comment", comment);
            cmd.Parameters.AddWithValue("@name", Person.Name);
            cmd.Parameters.AddWithValue("@employeenr", Person.EmployeeNr);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        public static void ActivateOrder(int orderid)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    DELETE FROM [Order].InactiveOrders
                    WHERE OrderID = @orderid";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", orderid);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public static bool IsOrderDone_Before
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT Date_Stop FROM [Order].MainData WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                con.Open();
                var result = cmd.ExecuteScalar();

                if (result == DBNull.Value || result == null)
                    return false;

                return true;
            }
        }
        public static bool IsOrderExist(string? orderNumber, string? operation)
        {
                if (string.IsNullOrEmpty(orderNumber))
                    return false;
                const string query = "SELECT * FROM [Order].MainData WHERE OrderNr = @ordernumber AND Operation = @operation";

                using var con = new SqlConnection(Database.cs_Protocol);
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@ordernumber", orderNumber);
                cmd.Parameters.AddWithValue("@operation", operation);
                con.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    return true;
                return false;
        }
        public static bool IsOnlyTestRun =>
            new[] { "D", "TR", "SP" }.Any(prefix => OrderNumber.StartsWith(prefix));
        public static bool IsPointsSetForOrder
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT * FROM [Order].MainData WHERE OrderID = @orderid AND Points IS NOT NULL";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
                return false;
            }
        }
        public static bool IsUsingBioBurdenSamples { get; set; }



        public static TimeSpan Total_RunTime_Order
        {
            get
            {
                var start = new DateTime();
                var stop = DateTime.Now;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT Date_Start FROM [Order].Data WHERE OrderID = @orderid";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        start = DateTime.Parse(reader[0].ToString());
                }
                var ts = stop - start;
                return ts;
            }

        }


        public static void Set_NumberOfLayers()
        {
            NumberOfLayers = 1;
            if (WorkOperation != WorkOperations.Extrudering_Termo)
                return;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT IsExtraInputBoxes_2Layer 
                    FROM MeasureProtocol.MainTemplate
                    WHERE MeasureProtocolMainTemplateID = @measureprotocoltemplateid";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            SQL_Parameter.Int(cmd.Parameters, "@measureprotocoltemplateid", Templates_MeasureProtocol.MainTemplate.ID);
            con.Open();
            var value = cmd.ExecuteScalar();
            bool IsExtraLayer = false;
            if (value != null)
                bool.TryParse(value.ToString(), out IsExtraLayer);
            NumberOfLayers = IsExtraLayer ? 2 : 1;
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
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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
                    InfoText.Question($"{LanguageManager.GetString("orderNotDone_1")} {reader["OrderNr"]} - Operation {reader["Operation"]} {LanguageManager.GetString("orderNotDone_2")} {dateSpan} {LanguageManager.GetString("orderNotDone_3")}\n" +
                                      $"{LanguageManager.GetString("orderNotDone_4")}\n\n" +
                                      $"{LanguageManager.GetString("orderNotDone_5")}", CustomColors.InfoText_Color.Info, "Info");
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
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    BEGIN TRANSACTION
                        DELETE FROM [Order].Compound WHERE OrderID = @id
                        DELETE FROM [Order].Compound_Main WHERE OrderID = @id
                        DELETE FROM [Order].Data WHERE OrderID = @id 
                        DELETE FROM [Order].ExtraComments WHERE OrderID = @id                        
                        DELETE FROM [Order].MainData WHERE OrderID = @id    
                        DELETE FROM Korprotokoll_Slipning_Maskinparametrar WHERE OrderID = @id                         
                        DELETE FROM Korprotokoll_Slipning_Produktion WHERE OrderID = @id
                        DELETE FROM Korprotokoll_Svetsning_Parametrar WHERE OrderID = @id
                        DELETE FROM Korprotokoll_Svetsning_Maskinparametrar WHERE OrderID = @id 
                        
                        DELETE FROM [Order].PreFab WHERE OrderID = @id
                        DELETE FROM Measureprotocol.Data WHERE OrderID = @id 
                        DELETE FROM Measureprotocol.MainData WHERE OrderID = @id 
                        DELETE FROM MeasureInstruments.Mätdon WHERE OrderID = @id
                        DELETE FROM Processcard.ProposedChanges WHERE OrderID = @id
                        DELETE FROM [Order].Läcksökning WHERE OrderID = @id  
                        DELETE FROM Zumbach.Data WHERE OrderID = @id
                        DELETE FROM Zumbach.Measurements WHERE OrderID = @id
                    COMMIT TRANSACTION";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@id", OrderID);
            con.Open();
            cmd.ExecuteNonQuery();
        }



        


        public static class Start
        {
            public static bool IsOrderOkToStart
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
                            InfoText.Show(string.Format(LanguageManager.GetString("mail_Subject_NotifyOrderStartCount"), PartNumber, totalOrders + 1), CustomColors.InfoText_Color.Warning, "Warning!");
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
                                InfoText.Show(string.Format(LanguageManager.GetString("notifyUserOrderStartCount_6"), PartNumber, totalOrders + 1), CustomColors.InfoText_Color.Warning, "Warning!");
                                return true;
                            }

                            return false;
                        }
                        default: //Startar 7e ordern eller senare
                        {
                            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.StartOrderNr_7_WithoutProcesscard))
                            {
                                Mail.NotifyOrderStartCount_4to5(totalOrders + 1);
                                InfoText.Show(string.Format(LanguageManager.GetString("notifyDirectorOrderStartCount_7"), PartNumber), CustomColors.InfoText_Color.Warning, "Warning!");

                                return true;
                            }

                            return false;
                        }
                    }
                }
            }
            public static bool IsUserNotLoggedIn(Control form)
            {
                if (string.IsNullOrEmpty(Person.Name))
                {
                    InfoText.Show(LanguageManager.GetString("startOrder_NeedLogin"), CustomColors.InfoText_Color.Warning, "Warning", form);

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
                    InfoText.Show(LanguageManager.GetString("startOrder_NoWorkoperation"), CustomColors.InfoText_Color.Bad, "Warning", form);

                    CustomProgressBar.close();
                    return false;
                }

                return true;
            }

            private static void ResetOrder(Main_Form main)
            {
                main.Clear_Mainform();
                main.OrderInformation.tb_OrderNr.Focus();
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

                InfoText.Question($"{LanguageManager.GetString("StartOrder")} {OrderNumber} - {ProdLine}?", CustomColors.InfoText_Color.Info, $"{WorkOperation}", null);
                if (InfoText.answer == InfoText.Answer.No)
                {
                    ResetOrder(main);
                    return;
                }

                IsOkStartOrder = true;
                Activity.Stop("Testar varför det är problem att starta ordrar för t.ex. Slipning TEF - 1");
                OrderID = Create_NewOrderID;
                Activity.Stop("Testar varför det är problem att starta ordrar för t.ex. Slipning TEF - 2");
                if (IsWorkOperationOk(main) == false)
                {
                    ResetOrder(main);
                    return;
                }
                main.OrderInformation.LoadMainForm_NewOrder();
                Activity.Stop("Testar varför det är problem att starta ordrar för t.ex. Slipning TEF - 3");
                main.OrderInformation.lbl_Version.Text = ChangeLog.CurrentVersion.ToString();


                if (IsChosen_ProcesscardOk == false || IsOrderOkToStart == false)
                {
                    ResetOrder(main);
                    return;
                }

                if (IsOkStartOrder || Part.IsPartID_Exist() == false)
                {
                    main.Load_MeasurePoints();
                    Activity.Stop("Testar varför det är problem att starta ordrar för t.ex. Slipning TEF - 4");
                    Templates_Protocol.MainTemplate.Set_MainTemplateID(ref IsOkStartOrder);
                    Activity.Stop("Testar varför det är problem att starta ordrar för t.ex. Slipning TEF - 5");
                    Templates_MeasureProtocol.MainTemplate.Set_MainTemplateID(ref IsOkStartOrder);
                    Activity.Stop("Testar varför det är problem att starta ordrar för t.ex. Slipning TEF - 6");
                    Templates_LineClearance.MainTemplate.Set_MainTemplateID();
                    Activity.Stop("Testar varför det är problem att starta ordrar för t.ex. Slipning TEF - 7");
                    if (IsOkStartOrder == false)
                    {
                        InfoText.Show(LanguageManager.GetString("selectTemplateError"), CustomColors.InfoText_Color.Bad, "Warning", main);
                        ResetOrder(main);
                        return;
                    }
                   
                    Save_MainInfo(); //Hämtar data från Processkorten och lägger till det till ordern
                    Activity.Stop("Testar varför det är problem att starta ordrar för t.ex. Slipning TEF - 8");
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
                Activity.Stop("Testar varför det är problem att starta ordrar för t.ex. Slipning TEF - 9");
                Templates_Protocol.MainTemplate.Revision = Korprotokoll.ProtocolTemplateRevision.OrderNr(OrderID);
                _ = Activity.Stop($"Startar Order: {Person.Name}");
                _ = Main_FilterQuickOpen.Load_ListAsync(main.dgv_QuickOpen);
            }


            public static void OpenRandomOrder(Main_OrderInformation OrderInformation)
            {
                int orderid;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        SELECT TOP(1) OrderID
                        FROM [Order].MainData
                       -- WHERE WorkoperationID NOT IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 18, 20)
                        ORDER BY NEWID()";
                    //(3,5,6,7,9,10,11,12,16,18,19,20,22,23,24,25,26,27,29,30,31,36)
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    orderid = (int)cmd.ExecuteScalar();
                }

                Login_Monitor.Login_API();
                OrderInformation.tb_OrderNr.Text = orderid.ToString();
                OrderInformation.StartOrder();
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

            public static void Save_MainInfo()
            {
                SaveData.INSERT_Korprotokoll_MainData();
                Module.IsOkToSave = true;
                switch (WorkOperation)
                {
                    
                    case WorkOperations.Extrudering_FEP:
                        Korprotokoll.Save_Date_StartUp1();
                        Korprotokoll.Save_Data("", 213, 0, 1, 1);//Zon 1
                        //SaveData.UPDATE_Korprotokoll_Main_From_Processkort_Main();
                        PreFab.SaveData.SavePrefabFromMonitor();
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                        break;

                    case WorkOperations.Extrudering_Termo:
                    case WorkOperations.Extrudering_Tryck:
                        Korprotokoll.Save_Date_StartUp1();
                       // SaveData.UPDATE_Korprotokoll_Main_From_Processkort_Main();
                        PreFab.SaveData.SavePrefabFromMonitor();
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                        break;

                    case WorkOperations.Extrusion_HS:
                        Korprotokoll.Save_Date_StartUp1();
                       // SaveData.UPDATE_Korprotokoll_Main_From_Processkort_Main();
                        PreFab.SaveData.SavePrefabFromMonitor();
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                        break;

                    case WorkOperations.Hackning_TEF:
                    case WorkOperations.Hackning_PTFE:
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                        break;


                    case WorkOperations.Krympslangsblåsning:
                    case WorkOperations.HeatShrink:
                        //SaveData.UPDATE_Korprotokoll_Main_From_Processkort_Main();
                        PreFab.SaveData.SavePrefabFromMonitor();
                        break;

                    case WorkOperations.Extrudering_PTFE:
                    case WorkOperations.Extrudering_Grov_PTFE:
                        PreFab.SaveData.SavePrefabFromMonitor();
                        break;

                    case WorkOperations.Kragning_PTFE:
                    case WorkOperations.Kragning_K22_PTFE:
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                       // SaveData.UPDATE_Korprotokoll_Main_From_Processkort_Main();
                        break;

                    case WorkOperations.Skärmning:
                        //SaveData.UPDATE_Korprotokoll_Main_From_Processkort_Main();
                        PreFab.SaveData.SavePrefabFromMonitor();
                        //PreFab.SaveData.INSERT_Skärmning();
                        break;

                    //case WorkOperations.Kragning_TEF:
                    //case WorkOperations.Slipning:
                    //case WorkOperations.Svetsning:
                    //    SaveData.UPDATE_Korprotokoll_Main_From_Processkort_Main();
                    //    break;

                    case WorkOperations.Synergy_PTFE:
                        MainInfo_B.INSERT_Measurepoints_Korprotokoll();
                       // SaveData.UPDATE_Korprotokoll_Main_From_Processkort_Main();
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
                    //Filtrerar bort Equipment så att operatörerna lär sig att fylla i all utrustning. 
                    //Dom skriver oftast N/A i verktygen om dom saknas istället för att se till att verktygen kommer in i registren.
                    //Om man skriver N/A så sparas det som NULL i databasen och då kan man inte avsluta ordern
                    var list_BlackListFormTemplateID = new List<int>
                    {
                        38, 39, 70, 75, 88, 116
                    };
                    var list = new List<int>();

                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        var query = "SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid";

                        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                        cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (int.TryParse(reader[0].ToString(), out var formtemplateid))
                                if (list_BlackListFormTemplateID.Contains(formtemplateid) == false)
                                    list.Add(formtemplateid);
                        }
                    }

                    return list;
                }
            }
            public static bool Is_OkFinishOrder(Main_Form main)
            {
                    if (IsOrderDone_Before)
                        return true;
                  
                switch (WorkOperation)
                {
                    case WorkOperations.Blandning_PTFE:
                            return Is_Blandning_PTFE_Done(main);
                        
                        case WorkOperations.Extrudering_FEP:
                            return Is_Protocol_Done(formTemplateIDs, main) && Is_Halvfabrikat_Done(main) && IsCommentsDone(main);
                        
                        case WorkOperations.Extrudering_PTFE:
                        case WorkOperations.Extrudering_Grov_PTFE:
                            return Is_MeasureEquipmentFilledIn(main) && Is_Halvfabrikat_Done(main) && Is_Protocol_Done(formTemplateIDs, main) && IsCommentsDone(main);
                        
                        case WorkOperations.Extrudering_Termo:
                        case WorkOperations.Extrudering_Tryck:
                        case WorkOperations.Extrusion_HS:
                            return Is_Protocol_Done(formTemplateIDs, main) && Is_MeasureEquipmentFilledIn(main) && Is_CompoundForm_Done(main) && Is_RoomClimate_Done(main) && Is_Halvfabrikat_Done(main) && IsCommentsDone(main);
                            
                        default:
                            return Is_Protocol_Done(formTemplateIDs, main) && Is_MeasureEquipmentFilledIn(main) && IsCommentsDone(main);

                        case WorkOperations.Kragning_TEF:
                            return Is_Halvfabrikat_Done(main) && Is_Protocol_Done(formTemplateIDs, main);

                        case WorkOperations.Krympslangsblåsning:
                        case WorkOperations.HeatShrink:
                            return IsHeatShrinkMeasurementsDone(main) && Is_MeasureEquipmentFilledIn(main) && Is_Halvfabrikat_Done(main) && Is_Protocol_Done(formTemplateIDs, main) && IsCommentsDone(main);

                        case WorkOperations.Skärmning:
                            return true;
                        case WorkOperations.Slipning:
                            return Is_Slipning_Done(main) && IsCommentsDone(main);
                       
                        case WorkOperations.Svetsning:
                            return Is_Svetsning_Done(main) && IsCommentsDone(main);
                    }
                    return false;
            }
            private static bool Is_Protocol_Done(IEnumerable<int> array_formtemplateid, Main_Form main)
            {
                var TotalStartUps = Module.TotalStartUps;
                foreach (var formtemplateid in array_formtemplateid)
                {
                    const string query_Processkort = @"
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
                    FROM Protocol.Template as template
                    FULL OUTER JOIN Processcard.Data as pc_data
                        ON template.id = pc_data.TemplateID
                        AND PartID = @partid
                        AND NOT (pc_data.Value IS NULL AND pc_data.TextValue IS NULL)
                    LEFT JOIN Protocol.Description as descr
                        ON descr.id = template.ProtocolDescriptionID
                    WHERE template.FormTemplateID = @formtemplateid 
                        AND ColumnIndex = 1
                        AND IsRequired = 1
                        AND pc_data.TemplateID IS NOT NULL
                    ORDER BY RowIndex, MachineIndex";

                    using var con = new SqlConnection(Database.cs_Protocol);
                    var cmd = new SqlCommand(query_Processkort, con);
                    cmd.Parameters.AddWithValue("@partid", PartID);
                    cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int.TryParse(reader["Type"].ToString(), out var type);
                        int.TryParse(reader["ID"].ToString(), out var protocoldescriptionid);
                        var codetext = reader["CodeText"].ToString();
                        var machine = reader["MachineIndex"].ToString();
                        if (codetext == "FILTERHUS")//Denna kontroll kan tas bort först när artiklar får egna templates för protokollet, nu döljs den i vissa fall och programmet tycker att operatör ska fylla i Filterhus fast det är dolt i protokollet
                            if (Equipment.Equipment.Is_Filterhus_Used_In_Processcard == false || Equipment.Equipment.Is_Filterhus_Used_No_Processcard == false)
                                break;

                        switch (type)
                        {
                            case 0:
                                if (Is_Value_Exist_In_Korprotokoll(codetext, protocoldescriptionid, "Value", machine, TotalStartUps) == false)
                                    return ShowMessage(string.IsNullOrEmpty(machine) ? $"{LanguageManager.GetString("orderDone_1")} ({codetext})" : $"{LanguageManager.GetString("orderDone_1")} ({codetext}) {LanguageManager.GetString("orderDone_2")} {machine}", main);
                                break;
                            case 1:
                                if (Is_Value_Exist_In_Korprotokoll(codetext, protocoldescriptionid, "TextValue", machine, TotalStartUps) == false)
                                    return ShowMessage(string.IsNullOrEmpty(machine) ? $"{LanguageManager.GetString("orderDone_1")} ({codetext})" : $"{LanguageManager.GetString("orderDone_1")} ({codetext}) {LanguageManager.GetString("orderDone_2")} {machine}", main);
                                break;
                        }
                    }
                }

                return true;
            }
            private static bool Is_Blandning_PTFE_Done(Main_Form main)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT * FROM [Order].Data WHERE OrderID = @orderid";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                var reader = cmd.ExecuteReader();
                return reader.HasRows || ShowMessage("Fyll i Journalen före du avslutar ordern.", main);
            
            }
            private static bool Is_CompoundForm_Done(Main_Form main)
            {
                    if (Settings.Settings.SpecialPartNumbers.DataTable_SpecialPartNr("Kompoundering").AsEnumerable().Any(row => PartNumber == row.Field<string>("PartNr")) == false)
                        return true;
                    using var con = new SqlConnection(Database.cs_Protocol);
                    const string query = @"
                        SELECT Size AS Pelletsstorlek, BulkWeight AS Bulkvikt, Weight75D AS [Vikt 75D], Weight55D AS [Vikt 55D]
                        FROM [Order].Compound AS kompound
                        JOIN [Order].Compound_Main AS main
                            ON kompound.OrderID = main.OrderID
                        WHERE main.OrderID = @orderid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var IsOk = true;
                    string message = null;
                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                            if (string.IsNullOrEmpty(reader[i].ToString()))
                            {
                                IsOk = false;
                                message = reader.GetName(i);
                            }
                    }

                    if (IsOk == false)
                        return ShowMessage($"Fyll i {message} i Kompounderings-blanketten ", main);
                    if (reader.HasRows == false)
                        return ShowMessage("Du har inte fyllt i Kompounderings-blanketten.", main);
                    return true;
            }

            private static bool Is_MeasureEquipmentFilledIn(Main_Form main)
            {
                Part.SetPartNrSpecial("Kompoundering");
                if (Part.IsPartNrSpecial)
                    return true;
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = $"SELECT * FROM MeasureInstruments.Mätdon {Queries.WHERE_OrderID}";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var IsOk = !string.IsNullOrEmpty(reader["Nr"].ToString());
                    if (IsOk == false)
                        return ShowMessage(LanguageManager.GetString("finishOrder_MeasureEq_1"), main);
                }
                        
                if (reader.HasRows == false)
                    return ShowMessage(LanguageManager.GetString("finishOrder_MeasureEq_2"), main);
                return true;
            }
            private static bool Is_Halvfabrikat_Done(Main_Form main)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT * FROM [Order].PreFab WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (string.IsNullOrEmpty(reader["Halvfabrikat_OrderNr"].ToString()))
                        return ShowMessage(LanguageManager.GetString("finishOrder_Halvfabrikat_1"), main);

                    if ((WorkOperation == WorkOperations.Extrudering_Termo || WorkOperation == WorkOperations.Extrudering_Tryck || WorkOperation == WorkOperations.Extrusion_HS) && string.IsNullOrEmpty(reader["Extruder"].ToString()))
                        return ShowMessage($"{LanguageManager.GetString("finishOrder_Halvfabrikat_2_1")} {reader["Halvfabrikat_ArtikelNr"]} {LanguageManager.GetString("finishOrder_Halvfabrikat_2_2")}", main);
                }

                return true;
            }
            private static bool Is_RoomClimate_Done(Main_Form main)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT Rum_Temp, Rum_Fukt FROM [Order].MainData WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (string.IsNullOrEmpty(reader["Rum_Temp"].ToString()))
                        return ShowMessage(LanguageManager.GetString("finishOrder_RoomTemp"), main); 
                    if (string.IsNullOrEmpty(reader["Rum_Fukt"].ToString()))
                        return ShowMessage(LanguageManager.GetString("finishOrder_RoomMoist"), main);
                }

                return true;
            }
            private static bool IsHeatShrinkMeasurementsDone(Main_Form main)
            {
                if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Length, "LSL") < 500)
                    return true;
                int ctr;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT COUNT(*) FROM Measureprotocol.MainData WHERE OrderID = @orderid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    con.Open();
                    ctr = (int)cmd.ExecuteScalar();
                }
                if (ctr < 13 & !IsOnlyTestRun)
                    return ShowMessage($"{LanguageManager.GetString("finishOrder_2_1")} {ctr} {LanguageManager.GetString("finishOrder_2_2")}", main);
                return true;
            }

            private static bool Is_Svetsning_Done(Main_Form main)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $"SELECT * FROM Korprotokoll_Svetsning_Maskinparametrar {Queries.WHERE_OrderID}";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                        return ShowMessage("Fyll i Maskinparametrarna i Körprotokollet", main);
                }

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $"SELECT * FROM Korprotokoll_Svetsning_Parametrar {Queries.WHERE_OrderID}";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                        return ShowMessage("Fyll i Produktionsparametrarna i Körprotokollet", main);
                }

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $"SELECT * FROM [Order].PreFab {Queries.WHERE_OrderID}";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                        return ShowMessage("Fyll i Halvfabrikatet i Körprotokollet", main);
                }

                return true;
            }
            private static bool Is_Slipning_Done(Main_Form main)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $"SELECT * FROM Korprotokoll_Slipning_Maskinparametrar {Queries.WHERE_OrderID}";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                        return ShowMessage("Fyll i Maskinparametrarna i Körprotokollet", main);
                }

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $"SELECT * FROM Korprotokoll_Slipning_Produktion  {Queries.WHERE_OrderID}";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                        return ShowMessage("Fyll i Produktionsparametrarna i Körprotokollet", main);
                }
                return true;
            }
            private static bool IsCommentsDone(Main_Form main)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT Comments FROM [Order].MainData WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (string.IsNullOrEmpty(reader["Comments"].ToString()))
                        return ShowMessage(LanguageManager.GetString("finishOrder_Comments"), main);
                }

                return true;
            }
            private static bool Is_Value_Exist_In_Korprotokoll(string codetext, int protocolDescriptionID, string valueType, string machine, int totalStartups)
            {
                var IsOk = false;
                for (var startUp = 1; startUp < totalStartups + 1; startUp++)
                {
                    using var con = new SqlConnection(Database.cs_Protocol);
                    var query = $@"
                        SELECT {valueType}, Uppstart, MachineIndex
                        FROM [Order].Data WHERE OrderID = @orderid 
                            AND ProtocolDescriptionID = @protocoldescriptionid
                            AND Uppstart = @startup ";
                    if (!string.IsNullOrEmpty(machine))
                        query += "AND (MachineIndex = @machineindex OR (MachineIndex IS NULL AND @machineindex IS NULL))";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", OrderID);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", protocolDescriptionID);
                    cmd.Parameters.AddWithValue("@codetext", codetext);
                    cmd.Parameters.AddWithValue("@startup", startUp);
                    cmd.Parameters.AddWithValue("@machineindex", machine);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int.TryParse(reader["Uppstart"].ToString(), out var uppstart);
                        var value = reader[0].ToString();
                        if (Is_Korprotokoll_Value_Discarded(uppstart))
                            continue;
                        if (Is_ValueReportedAndOkToLeaveEmpty(protocolDescriptionID))
                            return true;
                        IsOk = !string.IsNullOrEmpty(value);
                    }
                    if (reader.HasRows == false)
                        IsOk = false;
                }
                return IsOk;
            }
            private static bool Is_ValueReportedAndOkToLeaveEmpty(int protocolDescriptionID)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        SELECT 1 
                        FROM [Processcard].ProposedChanges 
                        WHERE OrderID = @orderid 
                            AND ProtocolDescriptionID = @protocoldescriptionid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                cmd.Parameters.AddWithValue("@protocoldescriptionid", protocolDescriptionID);
                con.Open();
                var value = cmd.ExecuteScalar();
                return value != null;
            }
            private static bool Is_Korprotokoll_Value_Discarded(int uppstart)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"SELECT BoolValue FROM [Order].Data WHERE OrderID = @orderid AND uppstart = @row AND ProtocolDescriptionID = @protocoldescriptionid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                cmd.Parameters.AddWithValue("@protocoldescriptionid", 174);//174 = Kasserad
                cmd.Parameters.AddWithValue("@row", uppstart);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return bool.TryParse(value.ToString(), out var IsDiscarded) && IsDiscarded;

                return false;
            }

            private static bool ShowMessage(string? Text, Main_Form main)
            {
                if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.FinishIncompleteOrder, false))
                {
                    InfoText.Question($"{Text} {LanguageManager.GetString("finishOrder_3_1")}\n\n" +
                                  $"{LanguageManager.GetString("finishOrder_3_2")} {Person.Role} {LanguageManager.GetString("finishOrder_3_3")}\n\n" +
                                  $"{LanguageManager.GetString("finishOrder_3_4")}", CustomColors.InfoText_Color.Warning, "Warning!", main);
                    if (InfoText.answer == InfoText.Answer.Yes)
                        return true;
                    return false;
                }

                InfoText.Show($"{Text} {LanguageManager.GetString("finishOrder_3_1")}", CustomColors.InfoText_Color.Bad, "Warning", main);
                _ = Activity.Stop($"Error FinishOrder: {Text}");
                return false;
            }

            public static void Order(Main_Form main)
            {
                if (IsOrderDone)
                {
                    InfoText.Show(LanguageManager.GetString("finishOrder_1"), CustomColors.InfoText_Color.Bad, "Warning!", main);
                    return;
                }

                if (string.IsNullOrEmpty(Person.Name))
                {
                    InfoText.Show(LanguageManager.GetString("finishOrder_4"), CustomColors.InfoText_Color.Bad, "Warning!", main);
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

                //Fortsätter med allt som skall göras om ordern är klar
                if (!IsOrderDone_Before)
                {
                    var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                    var formattedDate = DateTime.Now.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                    main.OrderInformation.lbl_Stopp.Text = formattedDate;

                    SaveData.UPDATE_Order_EndTime(DateTime.Now);
                    _ = Activity.Stop("FinishOrder: Update EndTime [Order].MainData");
                    if (MainProtocol.IsUsingStartUpDates)
                    {
                        SaveData.INSERT_LastStartUp_EndDate();
                        _ = Activity.Stop("FinishOrder: Update EndTime [Order].Data");
                    }
                        
                }

                Is_PrintOutCopy = false;
                _ = Activity.Stop("Skriver ut Order vid avslut.");
                if (ok.utskrift)
                    main.PrintOut();

                SaveData.UPDATE_OrderKlar();
                IsOrderDone = true;
                _ = Activity.Stop("Avslutad Order.");
                main.MainMenu.Menu_Order_OrderDone.Enabled = false;
                main.MainMenu.Menu_User.Enabled = false;
                main.Change_GUI_OrderKlar();

                //Meddelar processtekniker om eventuella uppdateringar av Processkort
                //Om Artikel är under Framarbetning OCH Antal ordrar körda är 3 så skickas ett mail eller om inget Processkort finns OCH antal körda ordrar = 3
                //D-ordrar skall heller inte 
                _ = Activity.Stop("Finish Order: Skickar mail ang. Processkortsuppdateringar");
                Mail.ProcesscardNeedChanges_FinishOrder();
                if (TotalOrders == 3 && !Processcard.IsNotUsingProcesscard(WorkOperation)) 
                    Mail.NotifyOrderFinishedCount_3();

                _ = Main_FilterQuickOpen.Load_ListAsync(main.dgv_QuickOpen);
            }
        }

        
    }
}
