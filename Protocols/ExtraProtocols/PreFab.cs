using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    public partial class PreFab : UserControl
    {
        public event EventHandler? HeaderClicked;
        public MainProtocol? ParentProtocol { get; set; }

        public static bool IsUsingPreFab;
        public static int TotalRows_PreFab
        {
            get
            {
                if (string.IsNullOrEmpty(Order.OrderNumber))
                    return 0;
                var query = $"SELECT COUNT(*) FROM [Order].PreFab {Queries.WHERE_OrderID}";
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                return (int)cmd.ExecuteScalar();
            }
        }

        public static DataTable DataTable_PreFab(int? orderID, bool isOkLoadBalance = false)
        {
            switch(Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.HeatShrink:
                case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                    return DataTable_PreFab_HeatShrink(orderID);
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    return DataTable_PreFab_Svetsning(orderID);
                default:
                    return DataTable_PreFab_Standard(orderID, isOkLoadBalance);
            }
        }
        private static DataTable DataTable_PreFab_Standard(int? orderID, bool IsOkLoadBalance)
        {
            if (orderID is null)
                return null;
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    SELECT 
                        Halvfabrikat_ArtikelNr AS '{LanguageManager.GetString("label_PartNumber")}', 
                        Halvfabrikat_Benämning AS '{LanguageManager.GetString("label_Description")}', 
                        Extruder AS 'Extruder:', 
                        Halvfabrikat_OrderNr AS 'BatchNr:', 
                        CONVERT(VARCHAR, BestBeforeDate, 23) AS '{LanguageManager.GetString("preFab_BestBefore")}',
                        TempID
                    FROM [Order].PreFab 
                    WHERE OrderID = @orderid 
                    ORDER BY Halvfabrikat_ArtikelNr, TempID";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderID);
                con.Open();
                dt.Load(cmd.ExecuteReader());
               
            }
            dt.Columns.Add($"{LanguageManager.GetString("preFab_Balance")}");
            dt.Columns[LanguageManager.GetString("preFab_BestBefore")].ReadOnly = false;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var serialNumber = dt.Rows[i]["BatchNr:"].ToString();
                var artikelnr = dt.Rows[i][LanguageManager.GetString("label_PartNumber")].ToString();
                string bestBeforeDate = dt.Rows[i][LanguageManager.GetString("preFab_BestBefore")].ToString();
                if (DateTime.TryParse(bestBeforeDate, out var parsedDate))
                    bestBeforeDate = parsedDate.ToShortDateString();
                if (string.IsNullOrEmpty(serialNumber) || IsOkLoadBalance == false)
                    dt.Rows[i][$"{LanguageManager.GetString("preFab_Balance")}"] = "N/A";
                else
                    dt.Rows[i][$"{LanguageManager.GetString("preFab_Balance")}"] = $"{Monitor.Monitor.Balance(artikelnr, serialNumber):0.00} {Monitor.Monitor.Units(artikelnr)}";

                if (string.IsNullOrWhiteSpace(bestBeforeDate) && !string.IsNullOrWhiteSpace(serialNumber))
                    dt.Rows[i][$"{LanguageManager.GetString("preFab_BestBefore")}"] = Monitor.Monitor.BestBeforeDate(artikelnr, serialNumber);

            }
            return dt;
        }
        private static DataTable DataTable_PreFab_HeatShrink(int? orderID)
        {
            if (orderID is null)
                return null;
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    SELECT 
                        Halvfabrikat_ArtikelNr AS '{LanguageManager.GetString("label_PartNumber")}', 
                        Halvfabrikat_OrderNr AS 'BatchNr:', 
                        Halvfabrikat_ID AS 'ID', 
                        Halvfabrikat_OD AS 'OD', 
                        Halvfabrikat_W AS 'W', 
                        TempID
                    FROM [Order].PreFab WHERE OrderID = @orderid 
                    ORDER BY Halvfabrikat_ArtikelNr, TempID";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderID);
                con.Open();
                dt.Load(cmd.ExecuteReader());
            }

            dt.Columns.Add($"{LanguageManager.GetString("preFab_Balance")}");
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var batchNr = dt.Rows[i]["BatchNr:"].ToString();
                var artikelnr = dt.Rows[i][LanguageManager.GetString("label_PartNumber")].ToString();
                if (string.IsNullOrEmpty(batchNr))
                    dt.Rows[i][$"{LanguageManager.GetString("preFab_Balance")}"] = "N/A";
                else
                    dt.Rows[i][$"{LanguageManager.GetString("preFab_Balance")}"] = $"{Monitor.Monitor.Balance(artikelnr, batchNr):0.00} {Monitor.Monitor.Units(artikelnr)}";
            }
            return dt;
        }
        private static DataTable DataTable_PreFab_Svetsning(int? orderID)
        {
            if (orderID is null)
                return null;
            var dt = new DataTable();
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $@"
                    SELECT 
                        Typ as 'Slang:', 
                        Halvfabrikat_ArtikelNr AS '{LanguageManager.GetString("label_PartNumber")}', 
                        Halvfabrikat_OrderNr AS 'BatchNr:', 
                        Halvfabrikat_ID AS 'ID', 
                        Halvfabrikat_OD AS 'OD', 
                        Halvfabrikat_W AS 'W', 
                        TempID
                    FROM [Order].PreFab WHERE OrderID = @orderid 
                    ORDER BY Halvfabrikat_ArtikelNr, TempID";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", orderID);
            con.Open();
            dt.Load(cmd.ExecuteReader());


            return dt;

        }

        private static List<string?> List_BatchNr(string? partNr)
        {
            var list = Monitor.Monitor.PreFab_BatchNr(partNr);
            if (list != null)
            {
                return Monitor.Monitor.PreFab_BatchNr(partNr).ToList();
            }

            return null;
        }
        public static List<string?> ListBatchNr
        {
            get
            {
                var list = new List<string?>();
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"SELECT DISTINCT Halvfabrikat_OrderNr FROM [Order].PreFab ORDER BY Halvfabrikat_OrderNr";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader[0].ToString());
                return list;
            }
        }
        public static List<string?> ListMaterial
        {
            get
            {
                var list = new List<string?>();
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"SELECT DISTINCT Halvfabrikat_Benämning FROM [Order].PreFab ORDER BY Halvfabrikat_Benämning";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader[0].ToString());
                return list;
            }
        }
        private static bool Is_CommentNeededToChangeBatchNr
        {
            get
            {
                switch(Order.WorkOperation)
                {
                    case Manage_WorkOperation.WorkOperations.Extrudering_Grov_PTFE:
                    case Manage_WorkOperation.WorkOperations.Extrudering_PTFE:
                    case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                        return false;
                    default:
                        return true;

                }
            }
        }

        //private int ExtruderColumn;
        //private int BatchNrColumn;


        public PreFab()
        {
            InitializeComponent();
            btn_PreFab.Click += (s, e) =>
            {
                try
                {
                    HeaderClicked?.Invoke(this, e);
                }
                catch
                {
                    // swallow exceptions from subscribers
                }
            };
        }
        public void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { btn_AddPreFab, btn_RemovePreFab, btn_PreFab });
        }


        private static void UPDATE_PreFab(string? batchNr, string? typ, double? id, double? od, double? wall, int tempID, string? dateBestBefore)
        {
            if (Module.IsOkToSave)
            {
                using var con = new SqlConnection(Database.cs_Protocol); 
                const string query = @"
                    UPDATE [Order].PreFab
                    SET 
                        Typ = COALESCE(@typ, Typ),
                        Halvfabrikat_OrderNr = COALESCE(@batchnr, Halvfabrikat_OrderNr),
                        BestBeforeDate = COALESCE(@bestbefore, BestBeforeDate),
                        Halvfabrikat_ID = COALESCE(@id, Halvfabrikat_ID),
                        Halvfabrikat_OD = COALESCE(@od, Halvfabrikat_OD),
                        Halvfabrikat_W = COALESCE(@wall, Halvfabrikat_W)
                    WHERE TempID = @tempid";

                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@tempid", tempID);
                cmd.Parameters.AddWithValue("@typ", string.IsNullOrEmpty(typ) ? DBNull.Value : typ);
                cmd.Parameters.AddWithValue("@batchnr", string.IsNullOrEmpty(batchNr) ? DBNull.Value : batchNr);
                cmd.Parameters.AddWithValue("@bestbefore", DateTime.TryParse(dateBestBefore, out var d) ? d : DBNull.Value);
                cmd.Parameters.AddWithValue("@id", id ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@od", od ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@wall", wall ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            
        }
        private static void UPDATE_PreFab_Extruder(string extruder, int tempID)
        {
            if (Module.IsOkToSave)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = $"UPDATE [Order].PreFab SET Extruder = @extruder WHERE TempID = @tempid";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@tempid", tempID);

                if (string.IsNullOrEmpty(extruder))
                    cmd.Parameters.AddWithValue(@"extruder", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@extruder", extruder);
                cmd.ExecuteNonQuery();
            }
        }
        
        


        public void Load_Data(int? orderID = null, bool IsOkLoadBalance = true)
        {
            Translate_Form();
            if (orderID == null)
                orderID = Order.OrderID;

            //ExtruderColumn = 100;
            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                case Manage_WorkOperation.WorkOperations.Extrusion_HS:
                    dgv.DataSource = DataTable_PreFab(orderID, IsOkLoadBalance);
              //      ExtruderColumn = 2;
                //    BatchNrColumn = 3;
                    break;
                case Manage_WorkOperation.WorkOperations.Synergy_PTFE_K18:
                    dgv.DataSource = DataTable_PreFab(orderID, IsOkLoadBalance);
                    dgv.Columns[LanguageManager.GetString("label_Description")].Visible = false;
                    dgv.Columns["Extruder:"].Visible = false;
                  //  BatchNrColumn = 3;
                    break;
                case Manage_WorkOperation.WorkOperations.Extrudering_PTFE:
                case Manage_WorkOperation.WorkOperations.Extrudering_Grov_PTFE:
                case Manage_WorkOperation.WorkOperations.Skärmning:
                case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                    dgv.DataSource = DataTable_PreFab(orderID, IsOkLoadBalance);
                    dgv.Columns["Extruder:"].Visible = false;
                 //   BatchNrColumn = 3;
                    break;
                case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                case Manage_WorkOperation.WorkOperations.HeatShrink:
                    dgv.DataSource = DataTable_PreFab(orderID);
                 //   BatchNrColumn = 1;
                    break;
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    dgv.DataSource = DataTable_PreFab(orderID);
                    break;
                default:
                    return;
            }
            dgv.Columns["TempID"].Visible = false;
            dgv.Columns[ LanguageManager.GetString("label_PartNumber")].ReadOnly = true;
            dgv.ClearSelection();
        }
       

        private void PreFab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Browse_Protocols.Browse_Protocols.Is_BrowsingProtocols)
                return;
            List<string?> items;
            var ColumnName = dgv.Columns[e.ColumnIndex].Name;
            var partNr = dgv.Rows[e.RowIndex].Cells[LanguageManager.GetString("label_PartNumber")].Value.ToString();
            switch (ColumnName)
            {
                case "Extruder:":
                    items = Machines.Extruders("EXTRUDER", Order.OrderID);
                    var choose_Item = new Choose_Item(items, new[] { dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] });
                    choose_Item.ShowDialog();
                    dgv.ClearSelection();
                    break;

                case "BatchNr:":
                    items = List_BatchNr(partNr);

                    if (!string.IsNullOrEmpty(dgv.Rows[e.RowIndex].Cells["BatchNr:"].Value.ToString()) && Is_CommentNeededToChangeBatchNr)
                    {
                        using var byt_BatchNr = new Change_ChargeNr_AddComment();
                        using var black = new BlackBackground("", 80);
                        black.Show();
                        byt_BatchNr.ShowDialog();
                        if (string.IsNullOrEmpty(byt_BatchNr.Kommentar))
                        {
                            InfoText.Show(LanguageManager.GetString("changeBatchNr_Info_1"), CustomColors.InfoText_Color.Info, "Warning", this);

                            black.Close();
                            return;
                        }

                        black.Close();
                        DatabaseManagement.SaveData.INSERT_Kommentar_Byte_BatchNr($"{LanguageManager.GetString("changeBatchNr_Info_2")} {byt_BatchNr.Kommentar}");
                    }

                    if (items != null)
                    {
                        choose_Item = new Choose_Item(items, new[] { dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] }, null, 0, 0, true);
                        choose_Item.ShowDialog();
                    }

                    dgv.ClearSelection();
                    break;
                case "Slang:":
                    choose_Item = new Choose_Item(new List<string?> { "Skärmad", "Mjuk", "Formar" }, new[] { dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] }, null, 0, 0, false);
                    choose_Item.ShowDialog();

                    break;
                     
            }
               

            
        }
        private void Save_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Module.IsOkToSave == false)
                return;
            var ColumnName = dgv.Columns[e.ColumnIndex].Name;
            var tempid = int.Parse(dgv.Rows[e.RowIndex].Cells["TempID"].Value.ToString() ?? string.Empty);
            var row = dgv.CurrentCell.RowIndex;

            switch (ColumnName)
            {
                case "Slang:":
                    var slang = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    UPDATE_PreFab(null, slang, null, null, null, tempid, null);
                    _ = Activity.Stop($"Användare {Person.Name} updating Prefab: (Slang = {slang}) - TempID = {tempid}");
                    break;

                //var col = e.ColumnIndex;
                //if (col == BatchNrColumn)
                case "BatchNr:":
                    string? bestBeforeDate = null;
                    var cell_BatchNr = dgv.Rows[row].Cells["BatchNr:"];
                    var batchNr = cell_BatchNr.Value.ToString();
                    var colName = LanguageManager.GetString("preFab_Balance") ?? string.Empty;
                    if (dgv.Columns.Contains(colName))
                    {
                        var cell_Saldo = dgv.Rows[row].Cells[LanguageManager.GetString("preFab_Balance") ?? string.Empty];
                        var cell_ArtikelNr = dgv.Rows[row].Cells[LanguageManager.GetString("label_PartNumber") ?? string.Empty];
                        var columnName = LanguageManager.GetString("preFab_BestBefore");


                        if (columnName != null && dgv.Columns.Contains(columnName))
                        {
                            var cell_BestBefore = dgv.Rows[row].Cells[columnName];
                            var bestBefore = Monitor.Monitor.BestBeforeDate(cell_ArtikelNr.Value.ToString(), cell_BatchNr.Value.ToString());
                            cell_BestBefore.Value = DateTime.TryParse(bestBefore, out DateTime result) ? (object)result : DBNull.Value;

                            bestBeforeDate = cell_BestBefore.Value.ToString();
                        }
                        cell_Saldo.Value = $"{Monitor.Monitor.Balance(cell_ArtikelNr.Value.ToString(), cell_BatchNr.Value.ToString()):0.00} {Monitor.Monitor.Units(cell_ArtikelNr.Value.ToString())}";
                    }
                    UPDATE_PreFab(batchNr, null, null, null, null, tempid, bestBeforeDate);
                    _ = Activity.Stop($"User {Person.Name} updating Prefab: (BatchNr = {batchNr}) - (BestBeforeDate = {bestBeforeDate}) - TempID = {tempid}");
                    break;
                case "Extruder:":
                    var extruder = dgv.Rows[row].Cells["Extruder:"].Value.ToString();
                    UPDATE_PreFab_Extruder(extruder, tempid); 
                    _ = Activity.Stop($"User {Person.Name} updating Prefab_Extruder: (Extruder = {extruder}) - TempID = {tempid}");
                    break;
                case "ID":
                    double? id = null;
                    if (double.TryParse(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out var parsedID))
                        id = parsedID;
                    UPDATE_PreFab(null, null, id, null, null, tempid, null);
                    _ = Activity.Stop($"User {Person.Name} updating PreFab: (ID = {id}) - TempID = {tempid}");
                    break;
                case "OD":
                    double? od = null;
                    if (double.TryParse(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out var parsedOD))
                        od = parsedOD;
                    UPDATE_PreFab(null, null, null, od, null, tempid, null);
                    _ = Activity.Stop($"User {Person.Name} updating PreFab: (OD = {od}) - TempID = {tempid}");
                    break;
                case "Wall":
                case "W":
                    double? wall = null;
                    if (double.TryParse(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out var parsedWall))
                        wall = parsedWall;
                    UPDATE_PreFab(null, null, null, null, wall, tempid, null);
                    _ = Activity.Stop($"User {Person.Name} updating PreFab: (Wall = {wall}) - TempID = {tempid}");
                    break;
            }
        }
        private void CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == LanguageManager.GetString("preFab_BestBefore"))
            {
                if (DateTime.TryParse(e.Value?.ToString(), out var cellDate))
                {
                    if (cellDate < DateTime.Today)
                    {
                        e.CellStyle.BackColor = CustomColors.Bad_Back;
                        e.CellStyle.ForeColor = CustomColors.Bad_Front;
                    }

                    else
                    {
                        e.CellStyle.BackColor = CustomColors.Ok_Back;
                        e.CellStyle.ForeColor = CustomColors.Ok_Front;
                    }
                }
            }
        }
        private void Add_PreFab_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
                SaveData.SavePrefabFromMonitor();
            else
            {
                if (dgv.CurrentCell.RowIndex < 0)
                {
                    //if (Person.Role == "SuperAdmin")
                    //{
                    //    SaveData.SavePrefabFromMonitor();
                    //    Load_Data(Order.OrderID);
                    //    return;
                    //}
                    InfoText.Show("Välj först vilken rad du vill lägga till en ny rad av.", CustomColors.InfoText_Color.Warning, "Warning", this);
                    return;
                }
                SaveData.INSERT_ExtraRow(dgv.CurrentCell.RowIndex);
            }
            Load_Data(Order.OrderID);
            ParentProtocol?.Set_PreFabHeight();
        }
        private void Delete_PreFab_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
                return;
            var columnPartNumber = dgv.Columns[LanguageManager.GetString("label_PartNumber")].Name;
            var activeBatchNr = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[columnPartNumber].Value.ToString();
            var tempID = (int)dgv.Rows[dgv.CurrentCell.RowIndex].Cells["TempID"].Value;
            var IsOkDeleteRow = false;
            foreach (DataGridViewRow row in dgv.Rows)
                if (row.Cells[columnPartNumber].Value.ToString() == activeBatchNr && row != dgv.CurrentRow)
                    IsOkDeleteRow = true;
            if (IsOkDeleteRow)
            {
                dgv.Rows.RemoveAt(dgv.CurrentCell.RowIndex);
                SaveData.DELETE_Row(tempID);
                _ = Activity.Stop($"Användare {Person.Name} raderar Prefab: (ArtikelNr = {activeBatchNr}) - TempID = {tempID}");
            }
        }
        private void Info_Click(object sender, EventArgs e)
        {
            InfoText.Show(LanguageManager.GetString("Halvfabrikat_Info_1"), CustomColors.InfoText_Color.Info, "Info", this);
        }


        public class SaveData
        {
            public static void SavePrefabFromMonitor(long ManufacturingOrderId = 0)
            {
                if (ManufacturingOrderId == 0)
                {
                    if (Monitor.Monitor.Order is null)
                        return;
                    ManufacturingOrderId = Monitor.Monitor.Order.Id;
                }

                //ListPartID Måste hämtas utan Operation för Extrudering PTFE pga av att halvfabriaktet är kopplat till operation 10 och dom använder operation 20 i DPP
                List<Manufacturing.ManufacturingOrderMaterials> ListPartID;
                if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.LoadPrefabWithoutOperation))
                    ListPartID = Utilities.GetFromMonitor<Manufacturing.ManufacturingOrderMaterials>("select=PartId", $"filter=ManufacturingOrderId Eq'{ManufacturingOrderId}'");
                else
                    ListPartID = Utilities.GetFromMonitor<Manufacturing.ManufacturingOrderMaterials>("select=PartId", $"filter=ManufacturingOrderId Eq'{ManufacturingOrderId}' AND ToOperationNumber Eq'{Order.Operation}'");

                if (ListPartID is null)
                    return;
                foreach (var partID in ListPartID)
                {
                    var ListParts = Utilities.GetFromMonitor<Inventory.Parts>( $"filter=Id Eq'{partID.PartId}'");
                    if (ListParts is null)
                        continue;

                    foreach (var part in ListParts)
                    {
                        using var con = new SqlConnection(Database.cs_Protocol);
                        string query;
                        if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.SaveMeasurepointsWithPrefab))
                            query = @"IF NOT EXISTS (SELECT * FROM [Order].PreFab WHERE OrderID = @orderid AND Halvfabrikat_ArtikelNr = @partnumber)
                                        INSERT INTO [Order].PreFab (OrderID, Halvfabrikat_ArtikelNr, Halvfabrikat_ID, Halvfabrikat_OD, Halvfabrikat_W) 
                                            VALUES (@orderid, @partnumber, @H_ID, @H_OD, @H_W)";
                        else
                            query = @"IF NOT EXISTS (SELECT * FROM [Order].PreFab WHERE OrderID = @orderid AND Halvfabrikat_ArtikelNr = @partnumber)
                                        INSERT INTO [Order].PreFab (OrderID, Halvfabrikat_ArtikelNr, Halvfabrikat_Benämning) 
                                            VALUES (@orderid, @partnumber, @description)";


                        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                        cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                        cmd.Parameters.AddWithValue("@partnumber", part.PartNumber);
                        SQL_Parameter.String(cmd.Parameters, "@description", part.Description);

                        if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.SaveMeasurepointsWithPrefab))
                        {
                           // int.TryParse(Order.Operation, out var operation);
                            var id = Monitor.Monitor.MeasurePoint(part.PartNumber, "ID", 10);
                            var od = Monitor.Monitor.MeasurePoint(part.PartNumber,  "OD", 10);
                            var w = Monitor.Monitor.MeasurePoint(part.PartNumber,  "Wall", 10);
                           
                            SQL_Parameter.Double(cmd.Parameters, "@H_ID", id);
                            SQL_Parameter.Double(cmd.Parameters, "@H_OD", od);
                            SQL_Parameter.Double(cmd.Parameters, "@H_W", w);
                            
                        }
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public static void INSERT_ExtraRow(int row)
            {
                int tempId;

                if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.SaveMeasurepointsWithPrefab))
                    tempId = int.Parse(DataTable_PreFab_HeatShrink(Order.OrderID).Rows[row]["TempID"].ToString());
                else
                    tempId = int.Parse(DataTable_PreFab(Order.OrderID, true).Rows[row]["TempID"].ToString());
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                            INSERT INTO [Order].PreFab (OrderID, Halvfabrikat_ArtikelNr, Halvfabrikat_Benämning, Halvfabrikat_ID, Halvfabrikat_OD, Halvfabrikat_W, BestBeforeDate, Length)
                            SELECT OrderID, Halvfabrikat_ArtikelNr, Halvfabrikat_Benämning, Halvfabrikat_ID, Halvfabrikat_OD, Halvfabrikat_W, BestBeforeDate, Length 
                            FROM [Order].PreFab WHERE OrderID = @orderid AND TempID = @tempid";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@tempid", tempId);
                cmd.ExecuteNonQuery();
                _ = Activity.Stop($"User {Person.Name} Adding Prefab: TempID = {tempId}");
            }
            public static void DELETE_Row(int tempID)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                            DELETE FROM [Order].PreFab WHERE TempID = @tempid";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@tempid", tempID);
                cmd.ExecuteNonQuery();
            }
        }

        

        private void dgv_Leave(object sender, EventArgs e)
        {
            dgv.ClearSelection();
        }
    }
}

