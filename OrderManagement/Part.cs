using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Processcards;
using static DigitalProductionProgram.OrderManagement.Manage_WorkOperation;
using System.Data;


namespace DigitalProductionProgram.OrderManagement
{
    internal class Part
    {

        private static string BuildProcesscardQuery(string workOperation, string partNr)
        {
            bool isMultiple = Processcard.IsMultiple_Processcard(Order.WorkOperation, partNr);
            var q = new StringBuilder(@"
        WITH OrderedRevisions AS (
            SELECT 
                PartID, 
                PartGroupID,
                RevNr,
                QA_sign,
                Framtagning_Processfönster,");

            if (isMultiple)
            {
                if (!string.IsNullOrEmpty(Order.ProdLine))
                    q.Append("ProdLine, ");
                if (!string.IsNullOrEmpty(Order.ProdType))
                    q.Append("ProdType, ");
            }

            q.Append(@"
                ROW_NUMBER() OVER (PARTITION BY PartGroupID ORDER BY RevNr DESC) AS RowNum,
                COUNT(*) OVER (PARTITION BY PartGroupID) AS TotalRevisions,
                MIN(RevNr) OVER (PARTITION BY PartGroupID) AS FirstRev,
                MAX(RevNr) OVER (PARTITION BY PartGroupID) AS LatestRev,
                MAX(CASE WHEN Framtagning_Processfönster = 'True' THEN RevNr END) OVER (PARTITION BY PartGroupID) AS LatestFramtagningRev,
                MAX(CASE WHEN QA_sign IS NOT NULL THEN RevNr END) OVER (PARTITION BY PartGroupID) AS LatestApprovedRev
            FROM Processcard.MainData
            WHERE PartNr = @partnr
            AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL)
            AND Aktiv = 'True'");

            if (isMultiple)
            {
                if (!string.IsNullOrEmpty(Order.ProdLine))
                    q.Append(" AND ProdLine = @prodline ");

                if (!string.IsNullOrEmpty(Order.ProdType))
                    q.Append(" AND ProdType = @prodtyp ");
            }

            q.Append(@"
        ),
        CheckAllNulls AS (
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
        WHERE 
            RevNr = LatestApprovedRev
            OR (RevNr = FirstRev AND PartGroupID IN (SELECT PartGroupID FROM CheckAllNulls) AND Framtagning_Processfönster = 'False')
            OR (RevNr = LatestFramtagningRev AND PartGroupID IN (SELECT PartGroupID FROM CheckAllNulls) 
                AND EXISTS (SELECT 1 FROM OrderedRevisions AS innerR 
                            WHERE innerR.PartGroupID = OrderedRevisions.PartGroupID 
                            AND Framtagning_Processfönster = 'True'))
        ORDER BY PartGroupID, RevNr DESC");

            return q.ToString();
        }

        public static string? ExtraInfo_Part
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT TOP(1) Extra_Info FROM Processcard.MainData WHERE PartID = @partid";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partid", Order.PartID);
                con.Open();
                var result = cmd.ExecuteScalar();
                return result == DBNull.Value || result == null ? string.Empty : result.ToString();
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

        private record ProcesscardRevision(int PartID, string RevNr, string LatestRev, bool IsLatestRevSelected);
        private static ProcesscardRevision? GetProcesscardRevision(string query, string partNr, string workOperation)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            using var cmd = new SqlCommand(query, con);

            cmd.Parameters.Add("@partnr", SqlDbType.VarChar).Value = partNr;
            cmd.Parameters.Add("@workoperation", SqlDbType.VarChar).Value = workOperation;
            SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
            SQL_Parameter.String(cmd.Parameters, "@prodtyp", Order.ProdType);

            con.Open();
            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            var partId = reader.GetInt32(reader.GetOrdinal("PartID"));
            var revNr = reader.GetString(reader.GetOrdinal("RevNr"));
            var latestRev = reader.GetString(reader.GetOrdinal("LatestRev"));
            var isLatest = Convert.ToBoolean(reader["LatestRevSelected"]);

            return new ProcesscardRevision(partId, revNr, latestRev, isLatest);
        }

        public static void Load_PartID(string? partNr, bool isOperatorStartingOrder, bool isOnlyProcessCard, string? workOperation = null)
        {
            if (string.IsNullOrWhiteSpace(partNr))
                return;

            var resolvedWorkOperation = ResolveWorkOperation(workOperation, isOnlyProcessCard, isOperatorStartingOrder);
            if (string.IsNullOrWhiteSpace(resolvedWorkOperation))
                return;

            var query = BuildProcesscardQuery(resolvedWorkOperation, partNr);
            var revision = GetProcesscardRevision(query, partNr, resolvedWorkOperation);

            if (revision is null)
                return;

            Order.PartID = revision.PartID;
            Order.RevNr = revision.RevNr;

            if (!revision.IsLatestRevSelected && isOperatorStartingOrder)
                Mail.NotifyQAPartNumberNeedApproval(revision.LatestRev);
        }
        private static string? ResolveWorkOperation(string? workOperation, bool isOnlyProcessCard, bool isOperatorStartingOrder)
        {
            if (!string.IsNullOrWhiteSpace(workOperation) && workOperation != WorkOperations.Nothing.ToString())
                return workOperation;

            Order.WorkOperation = WorkOperations.Nothing;

            using var black = new BlackBackground("", 70);
            using var chooser = new ProcesscardTemplateSelector(isOperatorStartingOrder, isOnlyProcessCard, false);

            black.Show();
            chooser.ShowDialog();
            black.Close();

            return chooser.IsAborted ? null : Order.WorkOperation.ToString();
        }

        public static int? Get_PartID(string? PartNr, WorkOperations WorkOperation)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
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
