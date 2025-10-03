using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Templates;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using ProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;

namespace DigitalProductionProgram.Övrigt
{
    internal class Get_Protocol_Data
    {
        // private static string startDate = "2022-05-21";
        private const string startDate = "2021-06-01";

        public static int Max_ProdData(int orderid, int[] descrIDs)
        {
            var maxvalue = int.MaxValue;
            foreach (var descrID in descrIDs)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                    SELECT COUNT(*)
                    FROM Measureprotocol.Data as data
                    INNER JOIN Measureprotocol.MainData as maindata
                        ON data.OrderID = maindata.OrderID
							AND data.RowIndex = maindata.RowIndex
                    WHERE data.OrderID = @orderid
                    AND(maindata.Discarded = 'False' OR maindata.Discarded IS NULL)
					AND DescriptionId = @descriptionid
					AND Value IS NOT NULL";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descriptionid", descrID);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    if (int.TryParse(value.ToString(), out var result))
                        if (result < maxvalue)
                            maxvalue = result;
            }

            return maxvalue;
        }
       
        public static string lastOrdernr(string partnr)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $@"
                    SELECT TOP(1) OrderNr
                    FROM [Order].MainData
                    WHERE PartNr = '{partnr}'
                    ORDER BY Date_Start DESC";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value != null)
            {
                Order.OrderNumber = value.ToString();
                return value.ToString();
            }

            return "";

        }
        public static string? Halvfabrikat_PartNr(string? ordernr)
        {
            long ManufacturingOrderId = 0;
            if (!string.IsNullOrEmpty(ordernr))
                Monitor.Monitor.Load_Order(ordernr);
            ManufacturingOrderId = Monitor.Monitor.Order.Id;
            //long ManufacturingOrderId = Monitor.Monitor.OrderId(partnr);


            var ListPartID = Utilities.GetFromMonitor<Manufacturing.ManufacturingOrderMaterials>("select=PartId", $"filter=ManufacturingOrderId Eq'{ManufacturingOrderId}' AND ToOperationNumber Eq'{10}'");
            if (ListPartID is null)
                return "N/A";
            foreach (var partID in ListPartID)
            {
                var ListParts = Utilities.GetFromMonitor<Inventory.Parts>($"filter=Id Eq'{partID.PartId}'");
                if (ListParts is null)
                    continue;

                foreach (var part in ListParts)
                {
                    return part.PartNumber;
                }
            }

            return "N/A";
        }
        public static string Codetext(int partid, int type, int column, int row)
        {
            var value = "N/A";
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                   SELECT Value, TextValue
                    FROM Protocol.Template AS template
                        JOIN Processcard.Data AS pc_data
	                        ON pc_data.TemplateID = template.Id
                        JOIN Protocol.Description AS descr
	                        ON descr.Id = template.ProtocolDescriptionID
                    WHERE pc_data.PartID = @partID
                    AND template.revision = 'A'
                    AND template.FormTemplateID = 10
                    AND ColumnIndex = @column
                    AND RowIndex = @row";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partID", partid);
            cmd.Parameters.AddWithValue("@column", column);
            cmd.Parameters.AddWithValue("@row", row);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (type == 0)
                    return reader[0].ToString();
                return reader[1].ToString();

            }

            return value;
        }

        public static string Date_Start(int orderid)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT Date_Start
                    FROM [Order].MainData
                    WHERE OrderId = @orderid";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", orderid);
            con.Open();
            var value = cmd.ExecuteScalar();
            if (value != null)
                return value.ToString();

            return "";
        }

        public static string queryBuilderVariable(string variable)
        {
            switch (variable)
            {
                case "Exp ID.":
                    return "(VARIABLENAME = 'Exp ID Keyence' OR VARIABLENAME = 'Exp ID.' OR VARIABLENAME = 'Exp ID. Keyence' OR VARIABLENAME = 'Exp ID.keyence.' OR VARIABLENAME = 'ExpID old' OR VARIABLENAME = 'ExpID-old' OR VARIABLENAME = 'ExpID.')";
                case "Exp Wall.":
                    return "(VARIABLENAME = 'Exp Wall' OR VARIABLENAME = 'Exp Wall Keyence' OR VARIABLENAME = 'Exp Wall.' OR VARIABLENAME = 'Exp Wall.keyence.' OR VARIABLENAME = 'ExpWall' OR VARIABLENAME = 'ExpWall.')";
                case "Rec ID Final.":
                    return "(VARIABLENAME = 'Rec ID Final Keyence' OR VARIABLENAME = 'Rec ID Final.' OR VARIABLENAME = 'Rec ID Final.keyence')";
                case "Rec Wall.":
                    return "(VARIABLENAME = 'Rec Wall Keyence' OR VARIABLENAME = 'Rec Wall.' OR VARIABLENAME = 'Rec Wall.keyence' OR VARIABLENAME = 'RecWall.')";
                case "Length.":
                    return "(VARIABLENAME = 'Length' OR VARIABLENAME = 'Length.' OR VARIABLENAME = 'Length.old')";
                case "Longitudinal change.":
                    return "(VARIABLENAME = 'Longitudinal change' OR VARIABLENAME = 'Longitudinal change Keyence' OR VARIABLENAME = 'Longitudinal change old' OR VARIABLENAME = 'Longitudinal change.')";
            }
            return null;
        }
        public static List<int> Orders(int partid)
        {
            var list = new List<int>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    SELECT OrderID 
                    FROM [Order].MainData
                    WHERE PartID = @partid
                    AND Date_Start > '{startDate}'";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@partID", partid);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(int.Parse(reader[0].ToString()));
            }

            return list;
        }
        public static List<double> Value_Prod(int orderid, int descrID)
        {
            var list = new List<double>();

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT Value  
                    FROM Measureprotocol.Data as data
                    INNER JOIN MeasureProtocol.MainData as maindata
                        ON data.OrderId = maindata.OrderID AND data.RowIndex = maindata.RowIndex
                    WHERE data.OrderID = @orderid
                    AND (maindata.Discarded = 'False' OR maindata.Discarded IS NULL)
                    AND DescriptionID = @descriptionid
                    ORDER BY Date";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@descriptionid", descrID);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                if (double.TryParse(reader[0].ToString(), out var value))
                    list.Add(value);

            return list;
        }
        public static List<string> Date_Prod(int orderid)
        {
            var list = new List<string>();

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT Date  
                    FROM MeasureProtocol.MainData
                    WHERE OrderID = @orderid
                    AND (maindata.Discarded = 'False' OR maindata.Discarded IS NULL)
                    ORDER BY Date";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            cmd.Parameters.AddWithValue("@orderid", orderid);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(reader[0].ToString());

            return list;
        }
        public static List<double> Value_QC(string ordernr, string variablename)
        {
            var list = new List<double>();

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $@"
                    SELECT vsamp.value_, varble.units
                    FROM 
                    [WinSPC_HS_Analysis].[dbo].[VSAMPLE] vsamp
                        INNER JOIN [WinSPC_HS_Analysis].[dbo].[VTAGVAL] vtagval on vsamp.subgroupnumber = vtagval.subgroupnumber and vsamp.VARIABLEID = vtagval.VARIABLEID
                        INNER JOIN [WinSPC_HS_Analysis].[dbo].[TAGVALUE] tagval on vtagval.TAGVALUEID = tagval.TAGVALUEID
                        INNER join [WinSPC_HS_Analysis].[dbo].[VSUBGRP] vsubgrp on vsubgrp.subgroupnumber = vsamp.subgroupnumber and vsubgrp.variableid = vsamp.VARIABLEID
                        INNER JOIN [WinSPC_HS_Analysis].[dbo].[VARBLE] varble on varble.variableid = vtagval.variableid
                        INNER join [WinSPC_HS_Analysis].[dbo].[PART] part on varble.partid = part.partid
                        INNER join [WinSPC_HS_Analysis].[dbo].[OPTTAG] opttag on opttag.partid = part.partid and opttag.tagid = tagval.tagid
                    WHERE opttag.tagname = 'Manufacturing Lot No' 
                        AND {queryBuilderVariable(variablename)} 
                        AND tagval.tagValue = @ordernr ORDER BY datetime_ ";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            cmd.Parameters.AddWithValue("@ordernr", ordernr);
            cmd.Parameters.AddWithValue("@variablename", variablename);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (double.TryParse(reader[0].ToString(), out var value))
                {
                    if (reader[1].ToString() == "in")
                        value *= 25.4;
                    list.Add(value);
                }

            }

            return list;
        }
        public static List<string> Date_QC(string ordernr, string variablename)
        {
            var list = new List<string>();

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $@"
                    SELECT datetime_
                    FROM 
                    [WinSPC_HS_Analysis].[dbo].[VSAMPLE] vsamp
                        INNER JOIN [WinSPC_HS_Analysis].[dbo].[VTAGVAL] vtagval on vsamp.subgroupnumber = vtagval.subgroupnumber and vsamp.VARIABLEID = vtagval.VARIABLEID
                        INNER JOIN [WinSPC_HS_Analysis].[dbo].[TAGVALUE] tagval on vtagval.TAGVALUEID = tagval.TAGVALUEID
                        INNER join [WinSPC_HS_Analysis].[dbo].[VSUBGRP] vsubgrp on vsubgrp.subgroupnumber = vsamp.subgroupnumber and vsubgrp.variableid = vsamp.VARIABLEID
                        INNER JOIN [WinSPC_HS_Analysis].[dbo].[VARBLE] varble on varble.variableid = vtagval.variableid
                        INNER join [WinSPC_HS_Analysis].[dbo].[PART] part on varble.partid = part.partid
                        INNER join [WinSPC_HS_Analysis].[dbo].[OPTTAG] opttag on opttag.partid = part.partid and opttag.tagid = tagval.tagid
                    WHERE opttag.tagname = 'Manufacturing Lot No' 
                        AND {queryBuilderVariable(variablename)} 
                        AND tagval.tagvalue = @ordernr 
                        ORDER BY datetime_";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            cmd.Parameters.AddWithValue("@ordernr", ordernr);
            cmd.Parameters.AddWithValue("@variablename", variablename);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(reader[0].ToString());

            return list;
        }
        public static List<string> Unit_QC(string ordernr, string variablename)
        {
            var list = new List<string>();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    SELECT units
                    FROM 
                    [WinSPC_HS_Analysis].[dbo].[VSAMPLE] vsamp
                        INNER JOIN [WinSPC_HS_Analysis].[dbo].[VTAGVAL] vtagval on vsamp.subgroupnumber = vtagval.subgroupnumber and vsamp.VARIABLEID = vtagval.VARIABLEID
                        INNER JOIN [WinSPC_HS_Analysis].[dbo].[TAGVALUE] tagval on vtagval.TAGVALUEID = tagval.TAGVALUEID
                        INNER join [WinSPC_HS_Analysis].[dbo].[VSUBGRP] vsubgrp on vsubgrp.subgroupnumber = vsamp.subgroupnumber and vsubgrp.variableid = vsamp.VARIABLEID
                        INNER JOIN [WinSPC_HS_Analysis].[dbo].[VARBLE] varble on varble.variableid = vtagval.variableid
                        INNER join [WinSPC_HS_Analysis].[dbo].[PART] part on varble.partid = part.partid
                        INNER join [WinSPC_HS_Analysis].[dbo].[OPTTAG] opttag on opttag.partid = part.partid and opttag.tagid = tagval.tagid
                    WHERE opttag.tagname = 'Manufacturing Lot No'
                        AND {queryBuilderVariable(variablename)}
                        AND tagval.tagValue = @ordernr ORDER BY datetime_ ";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@ordernr", ordernr);
                cmd.Parameters.AddWithValue("@variablename", variablename);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader[0].ToString());
            }

            return list;
        }

        private static int Halvfabrikat_OrderID(int orderid)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT OrderID 
                    FROM [Order].MainData 
                    WHERE OrderNr = (SELECT TOP(1) Halvfabrikat_OrderNr FROM [Order].PreFab WHERE OrderID = @orderid)";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return int.Parse(value.ToString());
                return 0;
            }
        }

        public static void ConvertDataTableTo_csv(DataTable dt, StringBuilder sb)
        {
            var delimiter = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

            sb.AppendLine(string.Join(delimiter, dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName)));
            foreach (DataRow row in dt.Rows)
            {
                var fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(delimiter, fields));
            }


        }

        public static void Save_csvFile(StringBuilder sb, string fileName)
        {
            var saveFile = new SaveFileDialog
            {
                FileName = fileName,
                Filter = "Csv Files (.csv)|*.csv"
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, sb.ToString());
                InfoText.Question(LanguageManager.GetString("transferDataExcel_1"), CustomColors.InfoText_Color.Info, "Open file?");
                if (InfoText.answer == InfoText.Answer.Yes)
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = saveFile.FileName,
                        UseShellExecute = true
                    });
            }

        }
        public static class Get_QuoteData
        {
            public static void TransferData()
            {
                var sb = new StringBuilder();

                var pbar = new ProgressBar();
                pbar.Show();
                var dt = new DataTable();
                string[] ColumnNames =
                {
                    "WorkOperation", "PartID", "PartNr", "Kund", "Extruder", "Benämning", "Produkttyp", "Draghastighet", "Antal Avg", "Antal StdDev", "Enhet", "Munstycke", "Kärna",
                    "ID AVG", "ID STDDEV", "OD AVG", "OD STDDEV", "WALL AVG", "WALL STDDEV", "LENGTH AVG", "LENTH STDDEV", "Krage OD AVG", "Krage OD STDDEV", "MainBody ID AVG", "MainBody ID STDDEV", "Tapered ID AVG", "Tapered ID STDDEV",
                    "Gap Overtube AVG", "Gap Overtube STDDEV", "Tapered Flared OD AVG", "Tapered Flared OD STDDEV", "Length Overtube AVG", "Length Overtube STDDEV", "MainBody Flared OD AVG", "MainBody Flared OD STDDEV", "Tapered OD AVG", "Tapered OD STDDEV",
                    "MainBody OD AVG", "MainBody OD STDDEV", "ExpID AVG", "ExpID STDDEV", "ExpOD AVG", "ExpOD STDDEV", "ExpWall AVG", "ExpWall STDDEV", "RecID AVG", "RecID STDDEV", "RecOD AVG", "RecOD STDDEV", "RecWall AVG", "RecWall STDDEV"
                };
                foreach (var ColumnName in ColumnNames)
                    dt.Columns.Add(ColumnName);




                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    SELECT Name, PartID, PartNr, Customer, ProdLine, main.Description, ProdType, Amount, Unit
                    FROM [Order].MainData as main
                    JOIN WorkOperation.Names as names
                        ON main.WorkoperationID = names.ID
                   
                    ORDER BY Date_Start, PartNr, RevNr DESC";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var partnr = reader["PartNr"].ToString();
                        var IsOk = dt.AsEnumerable().Any(row => partnr == row.Field<string>("PartNr"));
                        if (IsOk == false)
                        {
                            dt.Rows.Add();
                            dt.Rows[dt.Rows.Count - 1][0] = reader["Name"].ToString();

                            if (int.TryParse(reader["PartID"].ToString(), out var partid))
                                dt.Rows[dt.Rows.Count - 1][1] = partid;
                            dt.Rows[dt.Rows.Count - 1][2] = partnr;
                            dt.Rows[dt.Rows.Count - 1][3] = reader["Customer"].ToString();
                            dt.Rows[dt.Rows.Count - 1][4] = reader["ProdLine"].ToString();
                            dt.Rows[dt.Rows.Count - 1][5] = reader["Description"].ToString();
                            dt.Rows[dt.Rows.Count - 1][6] = reader["ProdType"].ToString();

                            dt.Rows[dt.Rows.Count - 1][10] = reader["Unit"].ToString();
                        }
                    }
                }

                pbar.Set_ValueProgressBar(0, "Laddar Draghastighet, Verktyg...");
                //Antal
                foreach (DataRow row in dt.Rows)
                {
                    if (int.TryParse(row[1].ToString(), out var partid))
                    {
                        row[8] = Math.Round(Avg_Value(partid, null), 2);
                        row[9] = Math.Round(STDDEV_Value(partid), 2);
                    }
                    else
                    {
                        row[8] = Math.Round(Avg_Value(0, row[2].ToString()), 2);
                        row[9] = Math.Round(STDDEV_Value(0, row[2].ToString()), 2);
                    }


                }

                //Draghastighet
                foreach (DataRow row in dt.Rows)
                {
                    var protocoldescriptionid = 0;
                    switch (row[0])
                    {
                        case "Extrudering_Termo":
                        case "Extrudering_Tryck":
                        case "Extrudering_FEP":
                        case "Extrudering_Grov_PTFE":
                        case "Extrudering_PTFE":
                            protocoldescriptionid = 99;
                            break;
                        case "Hackning_PTFE":
                            protocoldescriptionid = 5;
                            break;
                        case "Krympslangsblåsning":
                            protocoldescriptionid = 60;
                            break;
                        case "Hackning_TEF":
                            protocoldescriptionid = 126;
                            break;

                    }

                    if (protocoldescriptionid > 0)
                    {
                        if (int.TryParse(row[1].ToString(), out var partid))
                            row[7] = Math.Round(Avg_Value(protocoldescriptionid, partid), 2);
                        else
                            row[7] = Math.Round(Avg_Value(protocoldescriptionid, 0, row[2].ToString()), 2);
                    }
                }

                //Munstycke
                foreach (DataRow row in dt.Rows)
                {
                    var protocoldescriptionid = 83;

                    if (int.TryParse(row[1].ToString(), out var partid))
                        row[11] = LastValue(protocoldescriptionid, partid);
                    else
                        row[11] = LastValue(protocoldescriptionid, 0, row[2].ToString());
                }

                //Kärna
                foreach (DataRow row in dt.Rows)
                {
                    var protocoldescriptionid = 0;
                    switch (row[0])
                    {
                        case "Extrudering_Termo":
                        case "Extrudering_Tryck":
                        case "Extrudering_FEP":

                            protocoldescriptionid = 209;
                            break;
                        case "Extrudering_Grov_PTFE":
                        case "Extrudering_PTFE":
                            protocoldescriptionid = 84;
                            break;
                    }

                    if (protocoldescriptionid > 0)
                    {
                        if (int.TryParse(row[1].ToString(), out var partid))
                            row[12] = LastValue(protocoldescriptionid, partid);
                        else
                            row[12] = LastValue(protocoldescriptionid, 0, row[2].ToString());
                    }
                }

                //Halvfabrikat
                double percent = 0;
                double step_Value = 100f / dt.Rows.Count;
                foreach (DataRow row in dt.Rows)
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        int.TryParse(row[1].ToString(), out var partid);
                        string query;
                        var column = 51;

                        if (partid == 0)
                            query = "SELECT Halvfabrikat_ArtikelNr, Halvfabrikat_Benämning FROM [Order].PreFab WHERE OrderID IN (SELECT TOP(1) OrderID FROM [Order].MainData WHERE PartNr = @partnr ORDER BY Date_Start DESC)";
                        else
                            query = "SELECT Halvfabrikat_ArtikelNr, Halvfabrikat_Benämning FROM [Order].PreFab WHERE OrderID IN (SELECT TOP(1) OrderID FROM [Order].MainData WHERE PartID = @partid ORDER BY Date_Start DESC)";
                        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                        con.Open();
                        cmd.Parameters.AddWithValue("@partid", partid);
                        SQL_Parameter.String(cmd.Parameters, "@partnr", row[2].ToString());
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            if (column >= dt.Columns.Count - 1)
                            {
                                dt.Columns.Add($"Halvfabrikat PartNr {column - 51}", typeof(string));
                                dt.Columns.Add($"Halvfabrikat Benämning {column - 51}", typeof(string));
                            }

                            row[column] = reader[0].ToString();
                            row[column + 1] = reader[1].ToString();
                            column += 2;
                        }

                        percent += step_Value;
                        pbar.Set_ValueProgressBar(percent, "Laddar Halvfabrikat...");
                    }

                    percent = 0;
                }

                //Mått                          ID OD   Wall Length
                int[] protocoldescriptionids = { 1, 11, 18, 34, 8, 2, 3, 5, 6, 7, 8, 9, 10, 14, 16, 22, 15, 17, 23 };

                foreach (DataRow row in dt.Rows)
                {
                    var colIndex = 13;
                    percent += step_Value;
                    pbar.Set_ValueProgressBar(percent, "Laddar Måtten...");

                    foreach (var descriptionID in protocoldescriptionids)
                    {
                        if (int.TryParse(row[1].ToString(), out var partid))
                        {
                            if (descriptionID == 34 && row[9].ToString() == "m")
                                row[colIndex] = row[colIndex + 1] = 1;
                            else
                            {
                                row[colIndex] = Math.Round(AVG_MeasureValue(descriptionID, partid), 3);
                                row[colIndex + 1] = Math.Round(STDDEV_MeasureValue(descriptionID, partid), 3);
                            }
                        }

                        else
                        {
                            if (descriptionID == 34 && row[9].ToString() == "m")
                                row[colIndex] = row[colIndex + 1] = 1;
                            else
                            {
                                row[colIndex] = Math.Round(AVG_MeasureValue(descriptionID, 0, row[2].ToString()), 3);
                                row[colIndex + 1] = Math.Round(STDDEV_MeasureValue(descriptionID, 0, row[2].ToString()), 3);
                            }
                        }

                        colIndex += 2;
                    }
                }



                //Gör om datatable till csv
                pbar.Set_ValueProgressBar(80, "Gör om datatable till csv-fil...");
                ConvertDataTableTo_csv(dt, sb);

                // Write the CSV data to the file
                pbar.Set_ValueProgressBar(90, "Sparar csv-filen...");
                Save_csvFile(sb, "Quote");
                pbar.Close();
            }
            private static string LastValue(int protocoldescriptionid, int partid = 0, string? partnr = null)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    string query;
                    if (partid == 0)
                        query = @"
                        SELECT TextValue
                        FROM [Order].Data
                        WHERE OrderID IN (SELECT TOP(1) OrderID FROM [Order].MainData WHERE PartNr = @partnr ORDER BY Date_Start DESC)
                        AND ProtocolDescriptionID = @protocoldescriptionid";
                    else
                        query = @"
                        SELECT TextValue
                        FROM [Order].Data
                        WHERE OrderID IN (SELECT TOP(1) OrderID FROM [Order].MainData WHERE PartID = @partid ORDER BY Date_Start DESC)
                        AND ProtocolDescriptionID = @protocoldescriptionid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", partid);
                    SQL_Parameter.String(cmd.Parameters, "@partnr", partnr);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", protocoldescriptionid);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        return value.ToString();

                    return "N/A";
                }
            }
            private static double Avg_Value(int protocoldescriptionid, int partid = 0, string? partnr = null)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    string query;
                    if (partid == 0)
                        query = @"
                        SELECT AVG(Value)
                        FROM [Order].Data
                        WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartNr = @partnr)
                        AND ProtocolDescriptionID = @protocoldescriptionid";
                    else
                        query = @"
                        SELECT AVG(Value) 
                        FROM [Order].Data
                        WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartID = @partid)
                        AND ProtocolDescriptionID = @protocoldescriptionid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", partid);
                    SQL_Parameter.String(cmd.Parameters, "@partnr", partnr);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", protocoldescriptionid);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        if (double.TryParse(value.ToString(), out var result))
                            return result;

                    return 0;
                }
            }
            private static double AVG_MeasureValue(int protocoldescriptionid, int partid = 0, string? partnr = null)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    string query;
                    if (partid == 0)
                        query = @"
                        SELECT AVG(Value)
                        FROM MeasureProtocol.Data
                        WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartNr = @partnr)
                        AND DescriptionID = @protocoldescriptionid";
                    else
                        query = @"
                        SELECT AVG(Value) 
                        FROM MeasureProtocol.Data
                        WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartID = @partid)
                        AND DescriptionID = @protocoldescriptionid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", partid);
                    SQL_Parameter.String(cmd.Parameters, "@partnr", partnr);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", protocoldescriptionid);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        if (double.TryParse(value.ToString(), out var result))
                            return result;

                    return 0;
                }
            }
            private static double STDDEV_MeasureValue(int protocoldescriptionid, int partid = 0, string? partnr = null)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    string query;
                    if (partid == 0)
                        query = @"
                        SELECT STDEV(Value)
                        FROM MeasureProtocol.Data
                        WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartNr = @partnr)
                        AND DescriptionID = @protocoldescriptionid";
                    else
                        query = @"
                        SELECT STDEV(Value) 
                        FROM MeasureProtocol.Data
                        WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartID = @partid)
                        AND DescriptionID = @protocoldescriptionid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", partid);
                    SQL_Parameter.String(cmd.Parameters, "@partnr", partnr);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", protocoldescriptionid);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        if (double.TryParse(value.ToString(), out var result))
                            return result;

                    return 0;
                }
            }
            private static double STDDEV_Value(int partid = 0, string? partnr = null)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    string query;
                    if (partid == 0)
                        query = @"
                        SELECT STDEV(Amount)
                        FROM [Order].MainData
                        WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartNr = @partnr)";
                    else
                        query = @"
                        SELECT STDEV(Amount) 
                        FROM [Order].MainData
                        WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartID = @partid)";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", partid);
                    SQL_Parameter.String(cmd.Parameters, "@partnr", partnr);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        if (double.TryParse(value.ToString(), out var result))
                            return result;

                    return 0;
                }
            }
            private static double Avg_Value(int orderid, int descrID)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    SELECT AVG(Value) 
                    FROM MeasureProtocol.Data as data
                    JOIN MeasureProtocol.MainData as maindata
                        ON data.OrderID = maindata.OrderID AND data.RowIndex = maindata.RowIndex
                    WHERE data.OrderID = @orderid
                    AND (maindata.Discarded = 'False' OR maindata.Discarded IS NULL)
                    AND DescriptionID = @descriptionid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", orderid);
                    cmd.Parameters.AddWithValue("@descriptionid", descrID);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        if (double.TryParse(value.ToString(), out var result))
                            return result;
                    return 0;
                }
            }
            private static double Avg_Value(int partid = 0, string? partnr = null)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    string query;
                    if (partid == 0)
                        query = @"
                        SELECT AVG(Amount)
                        FROM [Order].MainData
                        WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartNr = @partnr)";
                    else
                        query = @"
                        SELECT AVG(Amount) 
                        FROM [Order].MainData
                        WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE PartID = @partid)";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partid", partid);
                    SQL_Parameter.String(cmd.Parameters, "@partnr", partnr);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        if (double.TryParse(value.ToString(), out var result))
                            return result;

                    return 0;
                }
            }
        }

        public static class TransferDataToExcel
        {
            private static readonly string[] MainHeaders = { "OrderNr", "Operation", "PartNr", "StartUp", "Machine", "Date", "ProdLine" };
            private static int TotalMachines { get; set; }
            private static void SetTotalMachines(int orderid)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT MAX(MachineIndex) FROM [Order].Data WHERE OrderID = @orderid";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", orderid);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    TotalMachines = int.TryParse(value.ToString(), out var machines) == false ? 1 : machines;
                }
            }

            private static int MaxStartUp { get; set; }
            [DebuggerStepThrough]
            private static void SetMaxStartUp(int orderid)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"SELECT MAX(Uppstart) FROM [Order].Data WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                con.Open();
                var value = cmd.ExecuteScalar();
                int.TryParse(value.ToString(), out var startup);
                MaxStartUp = startup;
            }
            private static DataTable DataTableExcel { get; set; }
            private static DataTable DataTable_Order(int orderid, int formTemplateID, int machine, int startup, bool IsUsingProcesscard, bool IsMultipleExtruders)
            {
                var table = new DataTable();
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                                SELECT data.OrderID, OrderNr, Date_Start, Operation, PartNr, ProdLine, CodeText, template.ProtocolDescriptionID, Value, TextValue, DateValue, MachineIndex, Uppstart, Ugn, template.RowIndex,  template.Type
                                FROM [Order].Data as data
                                    INNER JOIN [Order].MainData AS maindata
	                                    ON data.OrderID = maindata.OrderID
						            INNER JOIN Protocol.Template AS template
	                                    ON template.ProtocolDescriptionID = data.ProtocolDescriptionID
                                    INNER JOIN Protocol.Description as description
	                                    ON data.ProtocolDescriptionID = description.ID

                                WHERE data.OrderID = @orderid
    	                            AND template.FormTemplateID = @formtemplateid
	                                AND template.ProtocolDescriptionID IN (SELECT ProtocolDescriptionID FROM Protocol.Template WHERE FormTemplateID = @formtemplateid)";
                if (formTemplateID != 19)
                    query += @"AND (COALESCE(template.ColumnIndex, 0) = COALESCE(@columnindex, 0))
                                   AND Uppstart = @startup ";
                    
                if (IsMultipleExtruders)
                    query += "AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0))";
                query += "ORDER BY OrderID, MachineIndex, Uppstart, template.RowIndex";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@formtemplateid", formTemplateID);
                cmd.Parameters.AddWithValue("@machineindex", machine);
                cmd.Parameters.AddWithValue("@startup", startup);
                if (IsUsingProcesscard)
                    cmd.Parameters.AddWithValue("@columnindex", 1);
                else
                    cmd.Parameters.AddWithValue("@columnindex", DBNull.Value);

                con.Open();
                var reader = cmd.ExecuteReader();
                table.Load(reader);
                return table;
            }
            private static List<int> ProtocolMainTemplateID { get; set; }
           

            private static void AddMainColumns_DataTableExcel(int row)
            {
                DataTableExcel = new DataTable();
                DataTableExcel.Rows.Add();
                var col = 0;
                foreach (var header in MainHeaders)
                {
                    DataTableExcel.Columns.Add(header);
                    col++;
                }
            }
            private static void AddColumns_DataTableExcel(List<int> listFormTemplateid)
            {
                foreach (var formtemplateid in listFormTemplateid)
                {
                    using var con = new SqlConnection(Database.cs_Protocol);
                    var query = @"
                        SELECT DISTINCT CodeText, RowIndex
                        FROM Protocol.Description as descr
	                        JOIN Protocol.Template as template
		                        ON descr.id = template.ProtocolDescriptionID
                        WHERE FormTemplateID = @formtemplateid
                            AND RowIndex IS NOT NULL
                        ORDER BY RowIndex";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@formtemplateid", formtemplateid);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                       
                    while (reader.Read())
                    {
                        var codetext = reader["CodeText"].ToString();
                        if (DataTableExcel.Columns.Contains(codetext) == false)
                            DataTableExcel.Columns.Add(codetext);
                    }
                }
            }

            private static int Load_MainTemplateID(int orderid)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        SELECT ProtocolMainTemplateID
                        FROM [Order].MainData
                        WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value != null)
                    if (int.TryParse(value.ToString(), out var maintemplateid))
                        return maintemplateid;
                return 0;
            }

            private static List<int> ListFormTemplateID(int maintemplateID)
            {
                var listFormtemplateid = new List<int>();
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@maintemplateid", maintemplateID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader[0].ToString(), out var formtemplateid);
                    listFormtemplateid.Add(formtemplateid);
                }

                return listFormtemplateid;
            }
            public static void ProtocolData(List<int> listOrderID, string PartNr, bool IsUsingProcesscard = true)
            {
                SetTotalMachines(listOrderID[0]);
                double step = 100 / (float)listOrderID.Count;
               
                for (var Machine = 1; Machine < TotalMachines + 1; Machine++)
                {
                    var pbar = new ProgressBar();
                    pbar.Show();
                    double percent = 0;
                    
                    var row = 0;
                    var sb = new StringBuilder();
                    var IsUsingMultipleExtruders = TotalMachines > 1;
                    AddMainColumns_DataTableExcel(row);

                        foreach (var orderID in listOrderID)
                        {
                            var maintemplateID = Load_MainTemplateID(orderID);
                            var listFormtemplateid = ListFormTemplateID(maintemplateID);
                            AddColumns_DataTableExcel(listFormtemplateid);
                            
                            SetMaxStartUp(orderID);
                            //if (Templates.Templates_Protocol.MainTemplate.ID == maintemplateID)
                            {
                                for (var startUp = 1; startUp < MaxStartUp + 1; startUp++)
                                {
                                    DataTableExcel.Rows.Add();
                                    foreach (var formtemplateid in listFormtemplateid)
                                    {
                                        var dt = DataTable_Order(orderID, formtemplateid, Machine,startUp, IsUsingProcesscard, IsUsingMultipleExtruders);

                                        for (var i = 0; i < dt.Rows.Count; i++)
                                        {
                                            var codeText = dt.Rows[i]["CodeText"].ToString();
                                            int.TryParse(dt.Rows[i]["Type"].ToString(), out var type);
                                            int.TryParse(dt.Rows[i]["Uppstart"].ToString(), out var uppstart);
                                            int.TryParse(dt.Rows[i]["RowIndex"].ToString(), out var column);
                                            DateTime.TryParse(dt.Rows[i]["Date_Start"].ToString(), out DateTime date);

                                            DataTableExcel.Rows[row]["OrderNr"] = dt.Rows[i]["OrderNr"].ToString();
                                            DataTableExcel.Rows[row]["Operation"] = dt.Rows[i]["Operation"].ToString();
                                            DataTableExcel.Rows[row]["PartNr"] = dt.Rows[i]["PartNr"].ToString();
                                            DataTableExcel.Rows[row]["StartUp"] = uppstart;
                                            DataTableExcel.Rows[row]["Machine"] = dt.Rows[i]["MachineIndex"].ToString();
                                            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                                            var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                                            DataTableExcel.Rows[row]["Date"] = formattedDate;
                                            DataTableExcel.Rows[row]["ProdLine"] = dt.Rows[i]["ProdLine"].ToString();

                                            switch (type)
                                            {
                                                case 0:
                                                    DataTableExcel.Rows[row][codeText] = $"{dt.Rows[i]["Value"]}";
                                                    break;
                                                case 1:
                                                    DataTableExcel.Rows[row][codeText] = $"{dt.Rows[i]["TextValue"]}";
                                                    break;
                                                case 3:
                                                    DataTableExcel.Rows[row][codeText] =
                                                        dt.Rows[i]["DateValue"].ToString();
                                                    break;
                                            }
                                        }
                                    }
                                    row++;
                                }
                                DataTableExcel.Rows.Add();
                            }
                            pbar.Set_ValueProgressBar(percent, "Exporting data to Excel...");
                            percent += step;
                        }
                    pbar.Close();
                    pbar.Set_ValueProgressBar(percent, "Exporting data to Excel...");
                    ConvertDataTableTo_csv(DataTableExcel, sb);
                    Save_csvFile(sb, $"{PartNr} #{Machine}");
                }
            }

            public static void MeasurementData(DataTable dt, string partNr)
            {
                var sb = new StringBuilder();
                ConvertDataTableTo_csv(dt, sb);
                Save_csvFile(sb, $"MeasurementData-{partNr}");
            }
           
        }
    }
}

