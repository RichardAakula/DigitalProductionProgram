using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Processcards;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using DigitalProductionProgram.Templates;


namespace DigitalProductionProgram.OrderManagement
{
    internal class Part
    {

        public static string? ExtraInfo_Part
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT TOP(1) Extra_Info FROM Processcard.MainData WHERE PartID = @partid";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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
                     
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return (int)value;
                return 0;
            }
        }


        public static void Load_PartID(string PartNr, bool IsOperatorStartingOrder, bool IsOnlyProcessCard, bool isAutoSelectTemplate, string? WorkOperation = null)
        {
            //IsOnlyProcessCard - Letar endast efter mallar i Processkorten
            //IsOperatprStartingOrder - Då görs en kontroll när användare klickar på Processkortet om det är ok att starta ordern
            bool isMultipleProcesscard = Processcard.IsMultipleProcesscard(Order.WorkOperation, PartNr);

            if (WorkOperation is null || WorkOperation == Manage_WorkOperation.WorkOperations.Nothing.ToString() || isMultipleProcesscard)
            {
                if (WorkOperation is null)
                    Order.WorkOperation = Manage_WorkOperation.WorkOperations.Nothing;
                var black = new BlackBackground("", 70);
                var chooseProcesscard = new ProcesscardTemplateSelector(IsOperatorStartingOrder, IsOnlyProcessCard, false, isAutoSelectTemplate);
                {
                    black.Show();
                    chooseProcesscard.ShowDialog();
                    black.Close();

                }
                WorkOperation = Order.WorkOperation.ToString();
                isMultipleProcesscard = Processcard.IsMultipleProcesscard(Order.WorkOperation, PartNr); // uppdatera!
            }

            if (Order.PartID != null)
                return;
            if (Order.PartNumber is null)
                return;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = new StringBuilder(@"
                    WITH OrderedRevisions AS (
                        SELECT 
                        PartID, 
                        RevNr,
                        QA_sign,
                        ROW_NUMBER() OVER (ORDER BY revNr DESC) AS RowNum,
                        COUNT(*) OVER () AS TotalRevisions -- Count total revisions
                    FROM Processcard.MainData 
                        WHERE PartNr = @partnr 
                        AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) 
                        AND Aktiv = 'True'
                        ");

            if (isMultipleProcesscard)
            {
                if (!string.IsNullOrEmpty(Order.ProdLine))
                    query.Append(" AND ProdLine = @prodline ");

                if (!string.IsNullOrEmpty(Order.ProdType))
                    query.Append(" AND ProdType = @prodtyp ");
            }

            query.Append(@")
                    SELECT PartID FROM OrderedRevisions
                    WHERE (QA_sign IS NOT NULL AND RowNum = 1)  -- Latest approved revision
                        OR (QA_sign IS NULL AND RowNum = 2)   -- Previous revision if latest is not approved
                        OR (RowNum = 1 AND TotalRevisions = 1) -- Special case: If only one revision exists, select it regardless of QA_sign
                    ORDER BY RowNum
                    OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY; -- Ensure only one record is returned");

            con.Open();
            using var cmd = new SqlCommand(query.ToString(), con);
            cmd.Parameters.AddWithValue("@partnr", PartNr);
            cmd.Parameters.AddWithValue("@workoperation", WorkOperation);
            SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
            SQL_Parameter.String(cmd.Parameters, "@prodtyp", Order.ProdType);

            var value = cmd.ExecuteScalar();
            Order.PartID = value as int?;
        }
        public static Dictionary<string, int?> Get_PartIDs_Batch(IEnumerable<(string PartNr, Manage_WorkOperation.WorkOperations WorkOp)> keys)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();

            var results = new Dictionary<string, int?>();
            var values = new List<string>();
            var cmd = new SqlCommand();
            int i = 0;

            foreach (var key in keys.Distinct())
            {
                var pPart = $"@part{i}";
                var pOp = $"@op{i}";
                values.Add($"({pPart}, {pOp})");
                cmd.Parameters.AddWithValue(pPart, key.PartNr);
                cmd.Parameters.AddWithValue(pOp, key.WorkOp.ToString());
                i++;
            }

            if (values.Count == 0)
                return results;

            cmd.Connection = con;

            // Vi skapar en inline tabell (VALUES) och joinar med MainData för att hämta senaste revision
            cmd.CommandText = $@"
            SELECT 
                input.partnr,
                w.Name AS WorkOperation,
                CASE 
                    WHEN COUNT(DISTINCT md.PartGroupID) > 1 THEN 0
                    ELSE MAX(md.PartID)
                END AS PartID
            FROM 
                (VALUES {string.Join(",", values)}) AS input(partnr, workopname)
                JOIN Workoperation.Names w ON w.Name = input.workopname
                LEFT JOIN Processcard.MainData md ON md.PartNr = input.partnr AND md.WorkOperationID = w.ID
            GROUP BY input.partnr, w.Name";


            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var partNr = reader["partnr"].ToString();
                var workOp = reader["WorkOperation"].ToString();
                var partID = reader["PartID"] as int?;
                string key = $"{partNr}__{workOp}";
                results[key] = partID;
            }

            return results;
        }


        public static Dictionary<string, int?> LoadPartIDCache(IEnumerable<(string PartNr, string WorkOpStr)> combos)
        {
            var result = new Dictionary<string, int?>();
            using var con = new SqlConnection(Database.cs_Protocol);

            // Bygg tabell i minnet
            var dt = new DataTable();
            dt.Columns.Add("PartNr", typeof(string));
            dt.Columns.Add("WorkOperation", typeof(string));
            foreach (var (partNr, workOpStr) in combos.Distinct())
                dt.Rows.Add(partNr, workOpStr);

            con.Open();
            using var cmd = new SqlCommand(@"
        SELECT PartNr, W.Name AS WorkOperation, MAX(PartID) AS PartID
        FROM Processcard.MainData P
        JOIN Workoperation.Names W ON W.ID = P.WorkOperationID
        WHERE (P.ProdLine = @prodLine OR @prodLine IS NULL)
          AND (P.ProdType = @prodType OR @prodType IS NULL)
          AND Aktiv = 'True'
        GROUP BY PartNr, W.Name", con); // Vi hämtar max(PartID) per unik PartNr + WorkOp

            SQL_Parameter.String(cmd.Parameters, "@prodLine", Order.ProdLine);
            SQL_Parameter.String(cmd.Parameters, "@prodType", Order.ProdType);
            ServerStatus.Add_Sql_Counter();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var partNr = reader["PartNr"].ToString();
                var workOp = reader["WorkOperation"].ToString();
                var partKey = $"{partNr}__{workOp}";
                result[partKey] = reader["PartID"] as int?;
            }

            return result;
        }
        public class ProcesscardStatus
        {
            public bool IsPartIDExist { get; set; }
            public bool IsUnderConstruction { get; set; }
            public int TotalOrders { get; set; }
            public bool IsApprovedQA { get; set; }
            public bool IsMultipleProcesscard { get; set; } = false;
        }

        public static ProcesscardStatus GetProcesscardStatus(int? partID)
        {
            if (partID is null or 0)
                return new ProcesscardStatus();

            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();

            var cmd = new SqlCommand(@"
        SELECT 
            COUNT(*) AS PartExists,
            SUM(CASE WHEN Framtagning_Processfönster = 'True' THEN 1 ELSE 0 END) AS UnderConstruction,
            (SELECT COUNT(*) FROM [Order].MainData WHERE PartID = @partid AND IsOrderDone = 'True') AS TotalOrders,
            (SELECT TOP(1) 
                CASE 
                    WHEN Framtagning_Processfönster = 'True' THEN 1
                    WHEN QA_sign IS NOT NULL AND (Validerat = 'True' OR Historiska_Data = 'True') THEN 1
                    ELSE 0
                END
             FROM Processcard.MainData 
             WHERE PartID = @partid 
             ORDER BY RevNr DESC) AS IsApprovedQA
        FROM Processcard.MainData
        WHERE PartID = @partid", con);

            ServerStatus.Add_Sql_Counter();
            SQL_Parameter.NullableINT(cmd.Parameters, "@partid", partID);

            using var reader = cmd.ExecuteReader();
            var result = new ProcesscardStatus();
            if (reader.Read())
            {
                result.IsPartIDExist = (int)reader["PartExists"] > 0;
                result.IsUnderConstruction = (int)reader["UnderConstruction"] > 0;
                result.TotalOrders = (int)reader["TotalOrders"];
                result.IsApprovedQA = (int)reader["IsApprovedQA"] > 0;
            }

            return result;
        }
        //public static Dictionary<int, ProcesscardStatus> GetProcesscardStatuses(IEnumerable<int> partIDs)
        //{
        //    var result = new Dictionary<int, ProcesscardStatus>();

        //    // Hantera partID = 0 som specialfall PartID 0 = Artiklar med flera Processkort som ej går att hantera från Monitor
        //    var zeroIDs = partIDs.Where(id => id == 0).Distinct();
        //    foreach (var zeroID in zeroIDs)
        //    {
        //        result[zeroID] = new ProcesscardStatus
        //        {
        //            IsPartIDExist = true,
        //            IsUnderConstruction = false,
        //            TotalOrders = 0,
        //            IsApprovedQA = false,
        //            IsMultipleProcesscard = true // <-- markerar specialfallet
        //        };
        //    }

        //    // Hantera övriga
        //    var idList = partIDs.Distinct().Where(id => id != 0).ToList();
        //    if (idList.Count == 0)
        //        return result;

        //    using var con = new SqlConnection(Database.cs_Protocol);
        //    con.Open();

        //    var cmd = new SqlCommand();
        //    var paramNames = new List<string>();
        //    for (int i = 0; i < idList.Count; i++)
        //    {
        //        var paramName = $"@id{i}";
        //        cmd.Parameters.AddWithValue(paramName, idList[i]);
        //        paramNames.Add(paramName);
        //    }

        //    cmd.Connection = con;
        //    cmd.CommandText = $@"
        //        SELECT 
        //            md.PartID,
        //            COUNT(*) AS PartExists,
        //            SUM(CASE WHEN md.Framtagning_Processfönster = 'True' THEN 1 ELSE 0 END) AS UnderConstruction,
        //            (
        //                SELECT COUNT(*) 
        //                FROM [Order].MainData o 
        //                WHERE o.PartID = md.PartID AND o.IsOrderDone = 'True'
        //            ) AS TotalOrders,
        //            (
        //                SELECT TOP(1) 
        //                CASE 
        //                    WHEN md2.Framtagning_Processfönster = 'True' THEN 1
        //                    WHEN md2.QA_sign IS NOT NULL AND (md2.Validerat = 'True' OR md2.Historiska_Data = 'True') THEN 1
        //                ELSE 0
        //                END
        //                FROM Processcard.MainData md2
        //                WHERE md2.PartID = md.PartID
        //                ORDER BY md2.RevNr DESC
        //            ) AS IsApprovedQA
        //        FROM Processcard.MainData md
        //        WHERE md.PartID IN ({string.Join(",", paramNames)})
        //        GROUP BY md.PartID";

        //    using var reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        int partID = (int)reader["PartID"];
        //        var status = new ProcesscardStatus
        //        {
        //            IsPartIDExist = (int)reader["PartExists"] > 0,
        //            IsUnderConstruction = (int)reader["UnderConstruction"] > 0,
        //            TotalOrders = (int)reader["TotalOrders"],
        //            IsApprovedQA = (int)reader["IsApprovedQA"] > 0,
        //            IsMultipleProcesscard = false // <-- normalfallet
        //        };
        //        result[partID] = status;
        //    }

        //    return result;
        //}
        public static Dictionary<int, ProcesscardStatus> GetProcesscardStatuses(Dictionary<int, bool> partIDsWithMultipleFlag)
        {
            var result = new Dictionary<int, ProcesscardStatus>();

            var partIDs = partIDsWithMultipleFlag.Keys.ToList();
            if (partIDs.Count == 0)
                return result;

            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();

            var cmd = new SqlCommand();
            var paramNames = new List<string>();
            for (int i = 0; i < partIDs.Count; i++)
            {
                var paramName = $"@id{i}";
                cmd.Parameters.AddWithValue(paramName, partIDs[i]);
                paramNames.Add(paramName);
            }

            cmd.Connection = con;
            cmd.CommandText = $@"
SELECT 
    md.PartID,
    COUNT(*) AS PartExists,
    SUM(CASE WHEN md.Framtagning_Processfönster = 'True' THEN 1 ELSE 0 END) AS UnderConstruction,
    (
        SELECT COUNT(*) 
        FROM [Order].MainData o 
        WHERE o.PartID = md.PartID AND o.IsOrderDone = 'True'
    ) AS TotalOrders,
    (
        SELECT TOP(1) 
            CASE 
                WHEN md2.Framtagning_Processfönster = 'True' THEN 1
                WHEN md2.QA_sign IS NOT NULL AND (md2.Validerat = 'True' OR md2.Historiska_Data = 'True') THEN 1
                ELSE 0
            END
        FROM Processcard.MainData md2
        WHERE md2.PartID = md.PartID
        ORDER BY md2.RevNr DESC
    ) AS IsApprovedQA
FROM Processcard.MainData md
WHERE md.PartID IN ({string.Join(",", paramNames)})
GROUP BY md.PartID";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int partID = (int)reader["PartID"];
                var status = new ProcesscardStatus
                {
                    IsPartIDExist = (int)reader["PartExists"] > 0,
                    IsUnderConstruction = (int)reader["UnderConstruction"] > 0,
                    TotalOrders = (int)reader["TotalOrders"],
                    IsApprovedQA = (int)reader["IsApprovedQA"] > 0,
                    IsMultipleProcesscard = partIDsWithMultipleFlag.TryGetValue(partID, out bool isMulti) && isMulti
                };
                result[partID] = status;
            }

            return result;
        }




        public static void Load_PartGroup_ID(string? PartNr, Manage_WorkOperation.WorkOperations workoperation)
        {
            if (string.IsNullOrEmpty(PartNr))
                return;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT PartGroupID FROM Processcard.MainData WHERE PartNr = @partnr AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) ";
            if (Processcard.IsMultipleProcesscard(workoperation, PartNr))
                query += "AND (@prodline IS NULL OR ProdLine = @prodline) AND ProdType = @prodtyp";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partnr", PartNr);
            cmd.Parameters.AddWithValue("@workoperation", workoperation.ToString());
            SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
            SQL_Parameter.String(cmd.Parameters, "@prodtyp", Order.ProdType);
            var value = cmd.ExecuteScalar();
            Order.PartGroupID = (int?)value;
        }
        public static int? Get_NewPartID
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT TOP(1) PartID FROM Processcard.MainData ORDER BY PartID DESC";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var value = cmd.ExecuteScalar() ?? 0;
                return (int)value + 1;
            }
        }
        public static void Create_NewPartGroup_ID()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT TOP(1) PartGroupID FROM Processcard.MainData ORDER BY PartGroupID DESC";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            var value = cmd.ExecuteScalar() ?? 0;
            Order.PartGroupID = (int) value + 1;
        }

        public static void Load_ProdLine()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            string query;
            if (Order.OrderID != null)
                query = @"SELECT ProdLine FROM [Order].MainData WHERE PartID = @partid AND OrderID = @orderid";
            else
                query = @"SELECT ProdLine FROM [Order].MainData WHERE PartID = @partid";

            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
            if (Order.OrderID != null)
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            if (string.IsNullOrEmpty(Order.PartNumber))
                return;
            Order.ProdLine = (string)cmd.ExecuteScalar();
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

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT * FROM Processcard.MainData WHERE PartID = @partid";
            var cmd = new SqlCommand(query, con);
            SQL_Parameter.NullableINT(cmd.Parameters, "@partid", partID);

            con.Open();
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return true;
            return false;
        }
        public static bool IsPartNr_ApprovedQA
        {
            get
            {
                if (Order.PartID is null || Order.PartID == 0)
                    return true;
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                        SELECT TOP(1) Historiska_Data, Validerat, Framtagning_Processfönster, QA_sign 
                        FROM Processcard.MainData 
                        WHERE PartID = @artID ORDER BY RevNr DESC";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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

                return true;
            }
        }
        public static bool IsPartNr_UnderConstruction(int? partID = null)
        {//--- ca 0,5 sekunder
            if (partID == null)
                partID = Order.PartID;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT Count(*) FROM Processcard.MainData WHERE PartID = @partid AND Framtagning_Processfönster = 'True'";
                   
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            SQL_Parameter.NullableINT(cmd.Parameters, "@partid", partID);
                    
            con.Open();

            if ((int)cmd.ExecuteScalar() > 0)
                return true;
            return false;
        }
        public static bool IsPartNrSpecial(string description) 
        {
            if (string.IsNullOrEmpty(Order.PartNumber))
                return false;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $"SELECT PartNr FROM Parts.PartNrSpecial WHERE PartNr = @partnr AND PartNrDescriptionID = (SELECT id FROM Parts.PartNrDescription WHERE Description = '{description}')";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
            con.Open();
            var reader = cmd.ExecuteReader();
            return reader.HasRows;
        }


        public static List<string?> List_PartNr
        {
            get
            {
                var list = new List<string?>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT DISTINCT PartNr FROM [Order].MainData WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) ORDER BY PartNr";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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
