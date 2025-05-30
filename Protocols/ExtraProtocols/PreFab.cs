using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    public partial class PreFab : UserControl
    {
        public static bool IsUsingPreFab;
        public static int TotalRows_PreFab
        {
            get
            {
                if (string.IsNullOrEmpty(Order.OrderNumber))
                    return 0;
                var query = $"SELECT COUNT(*) FROM [Order].PreFab {Queries.WHERE_OrderID}";
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable DataTable_PreFab(int? orderID, bool IsOkLoadBalance)
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
                var cmd = new SqlCommand(query, con);
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
        public static DataTable DataTable_Halvfabrikat_Krympslang(int? orderID)
        {
            if (orderID is null)
                return null;
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    SELECT Halvfabrikat_ArtikelNr AS '{LanguageManager.GetString("label_PartNumber")}', Halvfabrikat_OrderNr AS 'BatchNr:', Halvfabrikat_ID AS 'ID', Halvfabrikat_OD AS 'OD', Halvfabrikat_W AS 'W', TempID
                    FROM [Order].PreFab WHERE OrderID = @orderid 
                    ORDER BY Halvfabrikat_ArtikelNr, TempID";
                var cmd = new SqlCommand(query, con);
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
        public static List<string> List_BatchNr(string? partNr)
        {
            var list = Monitor.Monitor.PreFab_BatchNr(partNr);
            if (list != null)
            {
                var list_Parts = Monitor.Monitor.PreFab_BatchNr(partNr).ToList();
                return list_Parts;
            }

            return null;
        }
        public static List<string> ListBatchNr
        {
            get
            {
                var list = new List<string>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT DISTINCT Halvfabrikat_OrderNr FROM [Order].PreFab ORDER BY Halvfabrikat_OrderNr";

                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0].ToString());
                }
                return list;
            }
        }
        public static List<string> ListMaterial
        {
            get
            {
                var list = new List<string>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT DISTINCT Halvfabrikat_Benämning FROM [Order].PreFab ORDER BY Halvfabrikat_Benämning";

                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0].ToString());
                }
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

        private int ExtruderColumn;
        private int BatchNrColumn;


        public PreFab()
        {
            InitializeComponent();
        }
        public void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { btn_AddPreFab, btn_RemovePreFab, btn_PreFab });
        }

        public static void UPDATE_PreFab(string artikelNr, string batchNr, int tempID, string dateBestBefore)
        {
            if (Module.IsOkToSave)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        UPDATE [Order].PreFab 
                        SET 
                            Halvfabrikat_OrderNr = @batchnr,
                            BestBeforeDate = @bestbeforedate
                        WHERE TempID = @tempid";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@tempid", tempID);
                    cmd.Parameters.AddWithValue("@halv_ArtikelNr", artikelNr);
                   
                    if (!DateTime.TryParse(dateBestBefore, out var dateTime))
                        cmd.Parameters.AddWithValue("@bestbeforedate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@bestbeforedate", dateTime);
                  
                    if (string.IsNullOrEmpty(batchNr))
                        cmd.Parameters.AddWithValue(@"batchnr", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@batchnr", batchNr);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UPDATE_PreFab_Extruder(string artikelnr, string extruder)
        {
            if (Module.IsOkToSave)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $"UPDATE [Order].PreFab SET Extruder = @extruder WHERE OrderID = @orderid AND Halvfabrikat_ArtikelNr = @halv_ArtikelNr";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@halv_ArtikelNr", artikelnr);

                    if (string.IsNullOrEmpty(extruder))
                        cmd.Parameters.AddWithValue(@"extruder", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@extruder", extruder);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UPDATE_BatchNr_Skärmning(string batchNr)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $"UPDATE [Order].PreFab SET Halvfabrikat_OrderNr = @H_O WHERE OrderID = @orderid";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@H_O", batchNr);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        


        public void Load_Data(int? orderID = null, bool IsOkLoadBalance = true)
        {
            Translate_Form();
            if (orderID == null)
                orderID = Order.OrderID;

            ExtruderColumn = 100;
            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                    dgv.DataSource = DataTable_PreFab(orderID, IsOkLoadBalance);
                    BatchNrColumn = 3;
                    dgv.Columns["Extruder:"].Visible = false;
                    break;
                case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                case Manage_WorkOperation.WorkOperations.Extrusion_HS:
                    dgv.DataSource = DataTable_PreFab(orderID, IsOkLoadBalance);
                    ExtruderColumn = 2;
                    BatchNrColumn = 3;
                    break;
                case Manage_WorkOperation.WorkOperations.Synergy_PTFE:
                    dgv.DataSource = DataTable_PreFab(orderID, IsOkLoadBalance);
                    dgv.Columns[LanguageManager.GetString("label_Description")].Visible = false;
                    dgv.Columns["Extruder:"].Visible = false;
                    BatchNrColumn = 3;
                    break;
                case Manage_WorkOperation.WorkOperations.Extrudering_PTFE:
                case Manage_WorkOperation.WorkOperations.Extrudering_Grov_PTFE:
                    dgv.DataSource = DataTable_PreFab(orderID, IsOkLoadBalance);
                    dgv.Columns["Extruder:"].Visible = false;
                    BatchNrColumn = 3;
                    break;
                case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                case Manage_WorkOperation.WorkOperations.HeatShrink:
                    dgv.DataSource = DataTable_Halvfabrikat_Krympslang(orderID);
                    BatchNrColumn = 1;
                    break;
                default:
                    return;
            }
            dgv.Columns["TempID"].Visible = false;
            dgv.ClearSelection();
        }
       

        private void PreFab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Browse_Protocols.Browse_Protocols.Is_BrowsingProtocols)
                return;
            List<string> items;

            if (e.ColumnIndex == ExtruderColumn)//Extruder
            {
                items = Machines.Extruders("EXTRUDER", Order.OrderID);
                var choose_Item = new Choose_Item(items, new[] { dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] });
                choose_Item.ShowDialog();
                dgv.ClearSelection();
            }

            if (e.ColumnIndex == BatchNrColumn)//BatchNr
            {
                items = List_BatchNr(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (!string.IsNullOrEmpty(dgv.Rows[e.RowIndex].Cells["BatchNr:"].Value.ToString()) && Is_CommentNeededToChangeBatchNr)
                {
                    var byt_BatchNr = new Change_ChargeNr_AddComment();
                    var black = new BlackBackground("", 80);
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
                    var choose_Item = new Choose_Item(items, new[] { dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] }, null, 0, 0, true);
                    choose_Item.ShowDialog();
                }

                dgv.ClearSelection();
            }
        }
        private void Save_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Module.IsOkToSave == false)
                return;

            var col = e.ColumnIndex;
            if (col == BatchNrColumn)
            {
                var row = dgv.CurrentCell.RowIndex;
                var cell_Saldo = dgv.Rows[row].Cells[LanguageManager.GetString("preFab_Balance")];
                var cell_BatchNr = dgv.Rows[row].Cells["BatchNr:"];
                var cell_ArtikelNr = dgv.Rows[row].Cells[LanguageManager.GetString("label_PartNumber")];
                string bestBeforeDate = null;
                var columnName = LanguageManager.GetString("preFab_BestBefore");
                string batchNr = cell_BatchNr.Value.ToString();
                if (dgv.Columns.Contains(columnName))
                {
                    var cell_BestBefore = dgv.Rows[row].Cells[LanguageManager.GetString("preFab_BestBefore")];
                    var bestBefore = Monitor.Monitor.BestBeforeDate(cell_ArtikelNr.Value.ToString(), cell_BatchNr.Value.ToString());
                    cell_BestBefore.Value = DateTime.TryParse(bestBefore, out DateTime result) ? (object)result : DBNull.Value;

                    bestBeforeDate = cell_BestBefore.Value.ToString();
                }

                cell_Saldo.Value = $"{Monitor.Monitor.Balance(cell_ArtikelNr.Value.ToString(), cell_BatchNr.Value.ToString()):0.00} {Monitor.Monitor.Units(cell_ArtikelNr.Value.ToString())}";

                
                UPDATE_PreFab(cell_ArtikelNr.Value.ToString(), batchNr, int.Parse(dgv.Rows[row].Cells["TempID"].Value.ToString()), bestBeforeDate);
            }

            if (col == ExtruderColumn)
            {
                var row = dgv.CurrentCell.RowIndex;
                UPDATE_PreFab_Extruder(dgv.Rows[row].Cells[LanguageManager.GetString("label_PartNumber")].Value.ToString(), dgv.Rows[row].Cells["Extruder:"].Value.ToString());
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
                SaveData.INSERT_Halvfabrikat();
            else
            {
                if (dgv.CurrentCell.RowIndex < 0)
                {
                    InfoText.Show("Välj först vilken rad du vill lägga till en ny rad av.", CustomColors.InfoText_Color.Warning, "Warning", this);
                    return;
                }

                SaveData.INSERT_ExtraRow(dgv.CurrentCell.RowIndex);
            }

            Load_Data(Order.OrderID);
        }
        private void Delete_PreFab_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
                return;
            var activeBatchNr = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
            var tempID = (int)dgv.Rows[dgv.CurrentCell.RowIndex].Cells["TempID"].Value;
            var IsOkDeleteRow = false;
            foreach (DataGridViewRow row in dgv.Rows)
                if (row.Cells[0].Value.ToString() == activeBatchNr && row != dgv.CurrentRow)
                    IsOkDeleteRow = true;
            if (IsOkDeleteRow)
            {
                dgv.Rows.RemoveAt(dgv.CurrentCell.RowIndex);
                SaveData.DELETE_Row(tempID);
            }
        }
        private void Info_Click(object sender, EventArgs e)
        {
            InfoText.Show(LanguageManager.GetString("Halvfabrikat_Info_1"), CustomColors.InfoText_Color.Info, "Info", this);
        }


        public class SaveData
        {
            public static void INSERT_Halvfabrikat(long ManufacturingOrderId = 0)
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
                        using (var con = new SqlConnection(Database.cs_Protocol))
                        {
                            string query;
                            if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.SaveMeasurepointsWithPrefab))
                                query = @"IF NOT EXISTS (SELECT * FROM [Order].PreFab WHERE OrderID = @orderid AND Halvfabrikat_ArtikelNr = @partnumber)
                                        INSERT INTO [Order].PreFab (OrderID, Halvfabrikat_ArtikelNr, Halvfabrikat_ID, Halvfabrikat_OD, Halvfabrikat_W) 
                                            VALUES (@orderid, @partnumber, @H_ID, @H_OD, @H_W)";
                            else
                                query = @"IF NOT EXISTS (SELECT * FROM [Order].PreFab WHERE OrderID = @orderid AND Halvfabrikat_ArtikelNr = @partnumber)
                                        INSERT INTO [Order].PreFab (OrderID, Halvfabrikat_ArtikelNr, Halvfabrikat_Benämning) 
                                            VALUES (@orderid, @partnumber, @description)";


                            var cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                            cmd.Parameters.AddWithValue("@partnumber", part.PartNumber);
                            SQL_Parameter.String(cmd.Parameters, "@description", part.Description);

                            if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.SaveMeasurepointsWithPrefab))
                            {
                                var id = Monitor.Monitor.MeasurePoint(part.PartNumber, "ID");
                                var od = Monitor.Monitor.MeasurePoint(part.PartNumber,  "OD");
                                var w = Monitor.Monitor.MeasurePoint(part.PartNumber,  "Wall");
                                if (id > od)    //Blir ibland fel att ID och OD mixas
                                {
                                    Activity.Start();
                                    SQL_Parameter.Double(cmd.Parameters, "@H_ID", id);
                                    SQL_Parameter.Double(cmd.Parameters, "@H_OD", od);
                                    SQL_Parameter.Double(cmd.Parameters, "@H_W", w);
                                    _ = Activity.Stop($"Halvfabrikat fel ID/OD: ID = {id} - OD = {od}");
                                }
                                else
                                {
                                    SQL_Parameter.Double(cmd.Parameters, "@H_ID", id);
                                    SQL_Parameter.Double(cmd.Parameters, "@H_OD", od);
                                    SQL_Parameter.Double(cmd.Parameters, "@H_W", w);
                                }
                            }
                            con.Open();
                            cmd.ExecuteNonQuery();

                        }
                    }
                }
            }
            public static void INSERT_Skärmning()
            {
                var tråd_Benämning = Monitor.Monitor.Part_Material.Description;
                var tråd_artikelNr = Monitor.Monitor.Part_Material.PartNumber;

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"
                    IF NOT EXISTS (SELECT * FROM [Order].PreFab {Queries.WHERE_OrderID} AND Halvfabrikat_ArtikelNr = @h_a) 
                        INSERT INTO [Order].PreFab (OrderID, Halvfabrikat_ArtikelNr, Halvfabrikat_Benämning)
                            VALUES (@id, @h_a, @h_b)";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    cmd.Parameters.AddWithValue("@h_a", tråd_artikelNr);
                    cmd.Parameters.AddWithValue("@h_b", tråd_Benämning);
                    cmd.ExecuteNonQuery();
                }
            }

            public static void INSERT_ExtraRow(int row)
            {
                int tempId;

                if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.SaveMeasurepointsWithPrefab))
                    tempId = int.Parse(DataTable_Halvfabrikat_Krympslang(Order.OrderID).Rows[row]["TempID"].ToString());
                else
                    tempId = int.Parse(DataTable_PreFab(Order.OrderID, true).Rows[row]["TempID"].ToString());
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                            INSERT INTO [Order].PreFab (OrderID, Halvfabrikat_ArtikelNr, Halvfabrikat_Benämning, Halvfabrikat_ID, Halvfabrikat_OD, Halvfabrikat_W, BestBeforeDate, Length)
                            SELECT OrderID, Halvfabrikat_ArtikelNr, Halvfabrikat_Benämning, Halvfabrikat_ID, Halvfabrikat_OD, Halvfabrikat_W, BestBeforeDate, Length 
                            FROM [Order].PreFab WHERE OrderID = @orderid AND TempID = @tempid";

                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@tempid", tempId);
                    cmd.ExecuteNonQuery();
                }
            }
            public static void DELETE_Row(int tempID)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                            DELETE FROM [Order].PreFab WHERE TempID = @tempid";

                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@tempid", tempID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        

        private void dgv_Leave(object sender, EventArgs e)
        {
            dgv.ClearSelection();
        }

        private void PreFab_Click(object sender, EventArgs e)
        {
            var parentControl = this.Parent;
            while (!(parentControl is MainProtocol) && parentControl != null)
                parentControl = parentControl.Parent;

            if (!(parentControl is MainProtocol form)) 
                return;
            if (form.tlp_Main.ColumnStyles[1].Width > 450)
                form.Hide_ExtraControls();
            else
                form.Show_PreFab();
        }

    }
}

