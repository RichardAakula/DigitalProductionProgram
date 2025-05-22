using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Processcards;
using static DigitalProductionProgram.OrderManagement.Manage_WorkOperation;


namespace DigitalProductionProgram.OrderManagement
{
    internal class Part
    {
       
       
        public static string ExtraInfo_Part
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT TOP(1) Extra_Info FROM Processcard.MainData WHERE PartNr = @partnr AND RevNr = @revNr";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                cmd.Parameters.AddWithValue("@revNr", Order.RevNr);
                con.Open();
                try
                {
                    return (string)cmd.ExecuteScalar();
                }
                catch
                {
                    Debug.WriteLine("Förösker hämta extra info om parametrar till mainform");
                    return string.Empty;
                }
            }
        }

        public static int TotalOrders_WithProcesscard(int? partID = null)
        {
            if (partID is null)
                return 0;
            const string query = "SELECT COUNT(*) FROM [Order].MainData WHERE PartID = @artID";

            using var con = new SqlConnection(Database.cs_Protocol);
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@artID", partID);
            con.Open();
            return (int)cmd.ExecuteScalar();
        }
        public static int? TotalOrdersRun
        {
            get
            {
                if (string.IsNullOrEmpty(Order.PartNumber))
                    return null;
                string query;
                if (Order.PartID is null || Order.PartID == 0)
                {
                    query = "SELECT COUNT(*) FROM [Order].MainData WHERE PartNr = @partnr ";
                    if (string.IsNullOrEmpty(Order.ProdLine) == false)
                        query += "AND ProdLine = @prodline ";
                    if (string.IsNullOrEmpty(Order.ProdType) == false)
                        query += "AND ProdType = @prodtype";
                    query += "AND PartID IS NULL";
                }
                else
                    query = "SELECT COUNT(*) FROM [Order].MainData WHERE PartID = @partid";

                using var con = new SqlConnection(Database.cs_Protocol);
                var cmd = new SqlCommand(query, con);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
                cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
                SQL_Parameter.String(cmd.Parameters, "@prodtype", Order.ProdType);
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        public static int TotalOrders_PartID(int? partID = null)
        {
            if (partID == null)
                partID = Order.PartID;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT COUNT(*) FROM (SELECT * FROM [Order].MainData WHERE PartID = @partid AND IsOrderDone = 'True') x";

            var cmd = new SqlCommand(query, con);
            SQL_Parameter.NullableINT(cmd.Parameters, "@partid", partID);
            con.Open();
            if (string.IsNullOrEmpty(Processkort_General.Last_RevNr(partID)))
                return 0;
            return (int)cmd.ExecuteScalar();
        }
        public static int TotalOrders_WithoutProcesscard
        {
            get
            {
                if (string.IsNullOrEmpty(Order.PartNumber))
                    return 0;
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        SELECT COUNT(*) 
                        FROM [Order].MainData
                        WHERE PartNr = @partnr
                            AND PartID IS NULL
                            AND (ProdLine = @prodline OR COALESCE(@prodline, '') = '')
                            AND (Operation = @operation OR COALESCE(@operation, '') = '')
                            AND LEFT(OrderNr, 1) != 'D' 
                            AND LEFT(OrderNr, 2) != 'SP'
                            AND LEFT(OrderNr, 2) != 'TR'
                            AND NOT EXISTS (SELECT 1 FROM [Order].InactiveOrders WHERE [Order].InactiveOrders.OrderID = [Order].MainData.OrderID)";
                     
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                SQL_Parameter.String(cmd.Parameters, "@operation", Order.Operation);
                SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return (int)value;
                return 0;
            }
        }
        public static int TotalOrders_WithProcesscardBasedOn_DevelopmentOfProcesscard
        {
            get
            {
                if (Order.PartID is null || Order.PartID == 0)
                    return 0;
                //Ändrade till PartID här i sql-queryn istället för PartNumber+Prodline 2025-01-14
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                        SELECT COUNT(*) 
                        FROM [Order].MainData AS orders
                        JOIN Processcard.MainData AS processcard
	                        ON processcard.PartID = orders.PartID
                        WHERE orders.PartID = @partid
	                        AND processcard.Framtagning_Processfönster = 'True'
                            AND LEFT(OrderNr, 1) != 'D'
                            AND LEFT(OrderNr, 2) != 'SP'
                            AND LEFT(OrderNr, 2) != 'TR'
                            AND NOT EXISTS (SELECT 1 FROM [Order].InactiveOrders WHERE [Order].InactiveOrders.OrderID = orders.OrderID)";

                var cmd = new SqlCommand(query, con);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return (int)value;
                return 0;
            }
        }

        public static void Load_PartID(string? PartNr, bool IsOperatorStartingOrder, bool IsOnlyProcessCard, string WorkOperation = null)
        {
            //IsOnlyProcessCard - Letar endast efter mallar i Processkorten
            //IsOperatorStartingOrder - Då görs en kontroll när användare klickar på Processkortet om det är ok att starta ordern
            //IsOkSelectLatestRevNr - Används vid hantering av Processkort där senaste Revisionen av processkortet är ok att ladda trots att Revisionen ej är godkänd
            if (string.IsNullOrWhiteSpace(PartNr))
                return;

            if (WorkOperation is null || WorkOperation == WorkOperations.Nothing.ToString())
            {
                Order.WorkOperation = WorkOperations.Nothing;
                var black = new BlackBackground("", 70);
                var chooseProcesscard = new ProcesscardTemplateSelector(IsOperatorStartingOrder, IsOnlyProcessCard, false);
                {
                    if (Order.WorkOperation == WorkOperations.Nothing)
                    {
                        black.Show();
                        chooseProcesscard.ShowDialog();
                        black.Close();
                        if (chooseProcesscard.IsAborted)
                            return;
                    }
                    
                }
                WorkOperation = Order.WorkOperation.ToString();
            }

            if (Order.PartNumber is null)
                return;
            var IsMultipleProcesscard = Processcard.IsMultiple_Processcard(Order.WorkOperation, PartNr);
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = new StringBuilder(@"
                    WITH OrderedRevisions AS (
                        SELECT 
                        PartID, 
                        PartGroupID,
                        RevNr,
                        QA_sign,
                        Framtagning_Processfönster,");
            if (IsMultipleProcesscard)
            {
                if (!string.IsNullOrEmpty(Order.ProdLine))
                    query.Append("ProdLine, ");
                if (!string.IsNullOrEmpty(Order.ProdType))
                    query.Append("ProdType, ");
            }

            query.Append(@"
                        ROW_NUMBER() OVER (PARTITION BY PartGroupID ORDER BY RevNr DESC) AS RowNum,
                        COUNT(*) OVER (PARTITION BY PartGroupID) AS TotalRevisions, -- Count total revisions
                        MIN(RevNr) OVER (PARTITION BY PartGroupID) AS FirstRev, -- First revision
                        MAX(RevNr) OVER (PARTITION BY PartGroupID) AS LatestRev, -- Latest revision
                        MAX(CASE WHEN Framtagning_Processfönster = 'True' THEN RevNr END) OVER (PARTITION BY PartGroupID) AS LatestFramtagningRev, -- Latest revision where Framtagning_Processfönster = TRUE
                        MAX(CASE WHEN QA_sign IS NOT NULL THEN RevNr END) OVER (PARTITION BY PartGroupID) AS LatestApprovedRev -- Find latest approved revision
                    FROM Processcard.MainData 
                        WHERE PartNr = @partnr 
                        AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) 
                        AND Aktiv = 'True'");
            if (IsMultipleProcesscard)
            {
                if (!string.IsNullOrEmpty(Order.ProdLine))
                    query.Append(" AND ProdLine = @prodline ");

                if (!string.IsNullOrEmpty(Order.ProdType))
                    query.Append(" AND ProdType = @prodtyp ");
            }

            query.Append(@"
                    )
                        , CheckAllNulls AS 
                        (
                            -- Find PartGroupIDs where ALL revisions have QA_sign = NULL
                            SELECT PartGroupID 
                            FROM OrderedRevisions 
                            GROUP BY PartGroupID
                            HAVING COUNT(*) = COUNT(CASE WHEN QA_sign IS NULL THEN 1 END)
                        )
                    SELECT 
                        PartID,
                        RevNr,
                        LatestRev,
                        CASE WHEN RevNr = LatestRev THEN 1 ELSE 0 END AS LatestRevSelected


                    FROM OrderedRevisions
                    WHERE (RevNr = LatestApprovedRev) -- Latest approved revision
                        OR (RevNr = FirstRev AND PartGroupID IN (SELECT PartGroupID FROM CheckAllNulls) AND Framtagning_Processfönster = 'False') -- Select first if all QA_sign NULL and Framtagning_Processfönster = FALSE
                        OR (RevNr = LatestFramtagningRev AND PartGroupID IN (SELECT PartGroupID FROM CheckAllNulls) AND EXISTS (SELECT 1 FROM OrderedRevisions WHERE PartGroupID = OrderedRevisions.PartGroupID AND Framtagning_Processfönster = 'True')) -- Select latest where Framtagning_Processfönster = TRUE
                    ORDER BY PartGroupID, RevNr DESC");


            con.Open();
            using var cmd = new SqlCommand(query.ToString(), con);
            cmd.Parameters.AddWithValue("@partnr", PartNr);
            cmd.Parameters.AddWithValue("@workoperation", WorkOperation);
            SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
            SQL_Parameter.String(cmd.Parameters, "@prodtyp", Order.ProdType);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int.TryParse(reader["PartID"].ToString(), out int partID);
                Order.PartID = partID;
                var latestRevNr = reader["LatestRev"].ToString();
                Order.RevNr = reader["RevNr"].ToString();
                            
                var isLastRevNrSelected = Convert.ToBoolean(reader["LatestRevSelected"]);

                if (isLastRevNrSelected == false && IsOperatorStartingOrder)
                    Mail.NotifyQAPartNumberNeedApproval(latestRevNr);
            }

            //var value = cmd.ExecuteScalar();
            //Order.PartID = value as int?;
        }
        public static int? Get_PartID(string? PartNr, WorkOperations WorkOperation)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT PartID FROM Processcard.MainData WHERE PartNr = @partnr AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) ";
                if (Processcard.IsMultiple_Processcard(WorkOperation, PartNr))
                {
                    if (!string.IsNullOrEmpty(Order.ProdLine))
                        query += "AND ProdLine = @prodline ";
                    if (!string.IsNullOrEmpty(Order.ProdType))
                        query += "AND ProdType = @prodtyp ";
                }

                query += "ORDER BY revNr DESC";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnr", PartNr);
                cmd.Parameters.AddWithValue("@workoperation", WorkOperation.ToString());
                SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
                SQL_Parameter.String(cmd.Parameters, "@prodtyp", Order.ProdType);
                var value = cmd.ExecuteScalar();
                return (int?)value;
            }
        }

        public static void Load_PartGroup_ID(string? PartNr, WorkOperations workoperation)
        {
            if (string.IsNullOrEmpty(PartNr))
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT PartGroupID FROM Processcard.MainData WHERE PartNr = @partnr AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) ";
                if (Processcard.IsMultiple_Processcard(workoperation, PartNr))
                    query += "AND (@prodline IS NULL OR ProdLine = @prodline) AND ProdType = @prodtyp";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnr", PartNr);
                cmd.Parameters.AddWithValue("@workoperation", workoperation.ToString());
                SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
                SQL_Parameter.String(cmd.Parameters, "@prodtyp", Order.ProdType);
                var value = cmd.ExecuteScalar();
                Order.PartGroupID = (int?)value;
            }
        }
        public static int? Get_NewPartID
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT TOP(1) PartID FROM Processcard.MainData ORDER BY PartID DESC";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    var value = cmd.ExecuteScalar() ?? 0;
                    return (int)value + 1;
                }
            }
        }
        public static void Create_NewPartGroup_ID()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT TOP(1) PartGroupID FROM Processcard.MainData ORDER BY PartGroupID DESC";
                con.Open();
                var cmd = new SqlCommand(query, con);
                var value = cmd.ExecuteScalar() ?? 0;
                Order.PartGroupID = (int) value + 1;
            }
        }

        public static void Load_ProdLine()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                string query;
                if (Order.OrderID != null)
                    query = @"SELECT ProdLine FROM [Order].MainData WHERE PartID = @partid AND OrderID = @orderid";
                else
                    query = @"SELECT ProdLine FROM [Order].MainData WHERE PartID = @partid";

                con.Open();
                var cmd = new SqlCommand(query, con);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
                if (Order.OrderID != null)
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                if (string.IsNullOrEmpty(Order.PartNumber))
                    return;
                Order.ProdLine = (string)cmd.ExecuteScalar();
            }
        }
        public static bool IsPartNr_Exist(string PartNr, string WorkOperation, string ProdLine, string ProdType)
        {
            if (Order.PartID is null || Order.PartID == 0)
                return false;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                            SELECT * FROM Processcard.MainData 
                            WHERE PartNr = @partNr 
                                AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) 
                                AND (ProdLine = @prodline OR COALESCE(@prodline, '') = '') 
                                AND (ProdType = @prodtype OR COALESCE(@prodtype, '') = '')";

                var cmd = new SqlCommand(query, con);
                var test = Order.PartNumber;
                    
                cmd.Parameters.AddWithValue("@partNr", PartNr);
                cmd.Parameters.AddWithValue("@workoperation", WorkOperation);
                cmd.Parameters.AddWithValue("@prodline", ProdLine);
                cmd.Parameters.AddWithValue("@prodtype", ProdType);

                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
            }
            return false;
        }
        public static bool IsPartID_Exist(int? partID = null)
        {
            if (partID == null)
                partID = Order.PartID;
            if (partID is null || partID == 0)
                return false;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT * FROM Processcard.MainData WHERE PartID = @partid";
                var cmd = new SqlCommand(query, con);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", partID);

                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
            }
            return false;
        }
        public static bool IsPartNr_ApprovedQA
        {
            get
            {
                if (Order.PartID is null || Order.PartID == 0)
                    return true;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        SELECT TOP(1) Historiska_Data, Validerat, Framtagning_Processfönster, QA_sign 
                        FROM Processcard.MainData 
                        WHERE PartID = @artID ORDER BY RevNr DESC";

                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    SQL_Parameter.NullableINT(cmd.Parameters, "@artID", Order.PartID);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (bool.TryParse(reader["Framtagning_Processfönster"].ToString(), out var IsFramtagning))
                            if (IsFramtagning)
                                return true;

                        if (string.IsNullOrEmpty(reader["QA_sign"].ToString()))
                            return false;
                        bool.TryParse(reader["Historiska_Data"].ToString(), out var IsHistoriskaData);
                        bool.TryParse(reader["Validerat"].ToString(), out var IsValiderat);

                        if (IsHistoriskaData && !string.IsNullOrEmpty(reader["QA_sign"].ToString()))
                            return true;
                        if (IsValiderat && !string.IsNullOrEmpty(reader["QA_sign"].ToString()))
                            return true;
                    }
                }
                return true;
            }
        }
        public static bool IsPartNr_UnderConstruction(int? partID = null)
        {//--- ca 0,5 sekunder
            if (partID == null)
                partID = Order.PartID;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT Count(*) FROM Processcard.MainData WHERE PartID = @partid AND Framtagning_Processfönster = 'True'";
                   
                var cmd = new SqlCommand(query, con);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", partID);
                    
                con.Open();

                if ((int)cmd.ExecuteScalar() > 0)
                    return true;
                return false;
            }
        }
        public static bool IsPartNrSpecial(string description) 
        {
            if (string.IsNullOrEmpty(Order.PartNumber))
                return false;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $"SELECT PartNr FROM Parts.PartNrSpecial WHERE PartNr = @partnr AND PartNrDescriptionID = (SELECT id FROM Parts.PartNrDescription WHERE Description = '{description}')";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                con.Open();
                var reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }


        public static List<string> List_PartNr
        {
            get
            {
                var list = new List<string>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT DISTINCT PartNr FROM [Order].MainData WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) ORDER BY PartNr";

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
