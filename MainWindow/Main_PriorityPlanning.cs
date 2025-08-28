using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using static DigitalProductionProgram.OrderManagement.Manage_WorkOperation;

namespace DigitalProductionProgram.MainWindow
{
    public partial class Main_Priorityplanning : UserControl
    {
        private readonly Label label_OrderKlar = new Label();
        private WorkOperations workOperation;
        private DataTable dt_PriorityPlan
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add("OrderNr");
                dt.Columns.Add("Operation");
                dt.Columns.Add("ArtikelNr");
                dt.Columns.Add("Benämning");
                dt.Columns.Add("ProdLine");
                dt.Columns.Add("Antal Rest");
                dt.Columns.Add("Antal");
                dt.Columns.Add("Total Tid");
                dt.Columns.Add("Planerad Start");
                dt.Columns.Add("Planerad Stopp");
                dt.Columns.Add("Order Startad");
                dt.Columns.Add("Processkort Godkänt");
                dt.Columns.Add("PartID");
                return dt;
            }
        }

        public Main_Priorityplanning()
        {
            InitializeComponent();


        }


        public void Load_ProdGrupp()
        {
            tb_ProdGrupp.Text = Settings.Settings.ProdLine_LoadingPLan;

            if (Monitor.Monitor.WorkCenters is null || Monitor.Monitor.WorkCenters.Count == 0)
                return;

            if (tb_ProdGrupp.Text == "0")
                return;
            if (Monitor.Monitor.WorkCenters.TryGetValue(tb_ProdGrupp.Text, out var prodGroup))
                tb_ProdBenämning.Text = prodGroup;
            else
                tb_ProdGrupp.Text = Monitor.Monitor.WorkCenters.Keys.First();
        }
        public void Change_Theme()
        {
            BackColor = dgv_PriorityPlanning.BackgroundColor = Teman.backColor_PriorityPlan;
            label_ProductionSchedule.ForeColor = label_ProdGroup.ForeColor = Teman.foreColor_PriorityPlan;
        }

        public void Change_GUI_OrderNotFinished()
        {
            Visible = true;
        }
        public void Change_GUI_OrderFinished()
        {
            BackColor = Color.FromArgb(100, 20, 44, 20);
            label_OrderKlar.Font = new Font("Cambria", 100f);
            label_OrderKlar.Text = "Order Klar";
            label_OrderKlar.BackColor = Color.Transparent;
            label_OrderKlar.ForeColor = Color.FromArgb(200, 230, 180);

            label_OrderKlar.Dock = DockStyle.Fill;
            label_OrderKlar.TextAlign = ContentAlignment.MiddleCenter;

            Controls.Remove(label_OrderKlar);
            Controls.Add(label_OrderKlar);
            Visible = true;
        }
        public void Translate_Form()
        {
            var controls = new Control[] { btn_RefreshPriorityPlan, label_ProductionSchedule, label_ProdGroup, label_Green, label_Yellow, label_White, label_Blue, label_Brown, label_Red };
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }


        private readonly Dictionary<string, bool> dictIsOrderExist = new();
        private readonly Dictionary<string, int?> dictOrderID = new();
        private readonly Dictionary<string, int?> dictPartID = new();
        private Dictionary<int, Part.ProcesscardStatus> dictPartStatus = new();

        public static Dictionary<string, (bool IsStarted, int? OrderID)> LoadOrderExistCache(List<(string OrderNumber, string OperationNumber)> neededChecks)
        {
            var result = new Dictionary<string, (bool, int?)>();

            if (neededChecks == null || neededChecks.Count == 0)
                return result;

            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();

            // Bygg parametrar för IN-klausul
            var parameters = new List<string>();
            var cmd = new SqlCommand();
            cmd.Connection = con;

            int index = 0;
            foreach (var check in neededChecks)
            {
                var pOrder = $"@orderNr{index}";
                var pOp = $"@operation{index}";
                parameters.Add($"(OrderNr = {pOrder} AND Operation = {pOp})");

                cmd.Parameters.AddWithValue(pOrder, check.OrderNumber);
                cmd.Parameters.AddWithValue(pOp, check.OperationNumber);

                index++;
            }

            var whereClause = string.Join(" OR ", parameters);
            cmd.CommandText = $@"
        SELECT OrderNr, Operation, OrderID 
        FROM [Order].MainData 
        WHERE {whereClause}";

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var orderNr = reader.GetString(reader.GetOrdinal("OrderNr"));
                var operation = reader.GetString(reader.GetOrdinal("Operation"));
                var orderID = reader.IsDBNull(reader.GetOrdinal("OrderID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("OrderID"));

                var key = $"{orderNr}-{operation}";
                result[key] = (true, orderID);
            }

            // Lägg till alla som inte hittades i resultatet med false och null
            foreach (var check in neededChecks)
            {
                var key = $"{check.OrderNumber}-{check.OperationNumber}";
                if (!result.ContainsKey(key))
                    result[key] = (false, null);
            }

            return result;
        }
        public void Load_PriorityPlanning()
        {
            workOperation = Manage_WorkOperation.Load_WorkOperationProdLine(false, tb_ProdBenämning.Text);

            var dt = dt_PriorityPlan;
            dgv_PriorityPlanning.Invoke(new Action(() => dgv_PriorityPlanning.DataSource = null));

            if (Settings.Settings.MeasuringComputerOnly || Main_Form.IsLoadingPriorityPlan == false)
                return;

            var WorkCenter = Utilities.GetOneFromMonitor<Manufacturing.WorkCenters>($"filter=Number Eq'{tb_ProdGrupp.Text}'");
            if (WorkCenter is null)
                return;

            var orderOperations = Utilities.GetFromMonitor<Manufacturing.ManufacturingOrderOperations>($"filter=WorkCenterId Eq'{WorkCenter.Id}' AND RestQuantity gt'0'", "orderby=Priority");
            var ctr = -1;



            // Fyll cache för order start-status
            var neededChecks = new List<(string OrderNumber, string OperationNumber)>();

            foreach (var row in orderOperations)
            {
                var ordernr = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrders>($"filter=Id Eq'{row.ManufacturingOrderId}'");
                if (ordernr == null)
                    continue;

                var key = $"{ordernr.OrderNumber}-{row.OperationNumber}";
                if (!dictIsOrderExist.ContainsKey(key))
                {
                    neededChecks.Add((ordernr.OrderNumber, row.OperationNumber.ToString()));
                }
            }
            // 2. Hämta data i bulk från DB och fyll cachen
            var loadedCache = LoadOrderExistCache(neededChecks);
            foreach (var kvp in loadedCache)
            {
                dictIsOrderExist[kvp.Key] = kvp.Value.IsStarted;
                dictOrderID[kvp.Key] = kvp.Value.OrderID;  // _orderIDCache är en ny Dictionary<string, int?>
            }

            // Bygg datatable med data och använd cachen för isStarted
            foreach (var row in orderOperations)
            {
                ctr++;
                var ordernr = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrders>($"filter=Id Eq'{row.ManufacturingOrderId}'");
                var part = Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=Id Eq'{row.PartId}'");
                var ts = row.PlannedFinishDate - row.PlannedStartDate;
                if (ordernr == null)
                    continue;

                var key = $"{ordernr.OrderNumber}-{row.OperationNumber}";
                dictIsOrderExist.TryGetValue(key, out bool isStarted);

                dt.Rows.Add();
                dt.Rows[^1]["OrderNr"] = ordernr.OrderNumber;
                dt.Rows[^1]["Operation"] = row.OperationNumber;
                dt.Rows[^1]["ArtikelNr"] = part.PartNumber;
                dt.Rows[^1]["Benämning"] = part.Description;
                dt.Rows[^1]["ProdLine"] = row.Description;
                dt.Rows[^1]["Antal Rest"] = $"{row.RestQuantity:0}";
                dt.Rows[^1]["Antal"] = $"{row.PlannedQuantity:0}";
                dt.Rows[^1]["Total Tid"] = $"{ts.TotalHours:0.0}";
                dt.Rows[^1]["Planerad Start"] = $"{row.PlannedStartDate:yyyy-MM-dd}";
                dt.Rows[^1]["Planerad Stopp"] = $"{row.PlannedFinishDate:yyyy-MM-dd}";
                dt.Rows[^1]["Order Startad"] = isStarted;
                dt.Rows[^1]["Processkort Godkänt"] = Part.IsPartNr_ApprovedQA;


            }


            dgv_PriorityPlanning.Invoke(new Action(() => dgv_PriorityPlanning.DataSource = dt));
            dgv_PriorityPlanning.Invoke(new Action(() => dgv_PriorityPlanning.Columns["Order Startad"].Visible = false));
            dgv_PriorityPlanning.Invoke(new Action(() => dgv_PriorityPlanning.Columns["Processkort Godkänt"].Visible = false));
            dgv_PriorityPlanning.Invoke(new Action(() => dgv_PriorityPlanning.Columns["PartID"].Visible = false));
            SetProcesscardStatus(dt);
            SetColorsPriorityPlan();
        }

        private void SetProcesscardStatus(DataTable dt)
        {
            var keys = new List<(string PartNr, WorkOperations WorkOp)>();
            foreach (DataRow dr in dt.Rows)
            {
                var partNr = dr["ArtikelNr"].ToString();
                keys.Add((partNr, workOperation));
            }

            // 2. Hämta alla PartIDs i ett svep
            var partIDMap = Part.Get_PartIDs_Batch(keys);

            // 3. Tilldela tillbaka till tabellen
            foreach (DataRow dr in dt.Rows)
            {
                var partNr = dr["ArtikelNr"].ToString();
                var workOp = workOperation;
                var key = $"{partNr}__{workOp}";
                if (partIDMap.TryGetValue(key, out var partID))
                    dr["PartID"] = partID;
                else
                    dr["PartID"] = DBNull.Value; // Om PartID inte hittades, sätt till DBNull
            }
            var allPartIDs = dt.Rows.Cast<DataRow>()
                .Where(r => r["PartID"] != DBNull.Value)
                .Select(r => Convert.ToInt32(r["PartID"]))
                .Distinct()
                .ToDictionary(id => id, id => id == 0); // ==0 => IsMultipleProcesscard
                                                        //.Select(r => r["PartID"])
                                                        //.Where(val => val != DBNull.Value)
                                                        //.Select(val => Convert.ToInt32(val))
                                                        //.ToList();

            dictPartStatus = Part.GetProcesscardStatuses(allPartIDs);
        }
        private void SetColorsPriorityPlan()
        {
            for (int row = 0; row < dgv_PriorityPlanning.Rows.Count; row++)
            {
                var rowObj = dgv_PriorityPlanning.Rows[row];
                var cellValue = rowObj.Cells["PartID"]?.Value;
                if (cellValue == null || !int.TryParse(cellValue.ToString(), out int partID))
                {
                    //VIT - Parametrar saknas
                    rowObj.DefaultCellStyle.BackColor = CustomColors.Parametrar_Saknas_Back;
                    rowObj.DefaultCellStyle.ForeColor = CustomColors.Parametrar_Saknas_Front;
                    continue;
                }

                // Kollar status på Processkort
                dictPartStatus.TryGetValue(partID, out var status);


                // GUL
                if (bool.Parse(rowObj.Cells["Order Startad"].Value.ToString()))
                {
                    rowObj.DefaultCellStyle.BackColor = CustomColors.Warning_Back;
                    rowObj.DefaultCellStyle.ForeColor = CustomColors.Warning_Front;
                    continue;
                }

                // BLÅ --Multipla processkort
                if (status.IsMultipleProcesscard)
                {
                    rowObj.DefaultCellStyle.BackColor = Color.FromArgb(180, 198, 231);
                    rowObj.DefaultCellStyle.ForeColor = Color.DarkSlateGray;
                    continue;
                }

                // RÖD  - Ej godkänt av QA
                if (!status.IsApprovedQA && status.IsPartIDExist)
                {
                    rowObj.DefaultCellStyle.BackColor = CustomColors.Bad_Back;
                    rowObj.DefaultCellStyle.ForeColor = CustomColors.Bad_Front;
                    continue;
                }


                // BRUN - Under Framtagning och mer än 2 ordrar
                if (status is { IsUnderConstruction: true, TotalOrders: > 2 })
                {
                    rowObj.DefaultCellStyle.BackColor = Color.Brown;
                    rowObj.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    continue;
                }

                // GRÖN OK ATT STARTA
                rowObj.DefaultCellStyle.BackColor = CustomColors.Ok_Back;
                rowObj.DefaultCellStyle.ForeColor = CustomColors.Ok_Front;
            }
        }
       

        public void Load_PriorityPlanning_QA_NotApprovedProcesscards(DataGridView dgv)
        {
            dgv_PriorityPlanning.Columns.Clear();

            var dt = new DataTable();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT PartNr, RevNr, ProdLine, ProdType, workoperation.Name, RevÄndratDatum 
                    FROM Processcard.MainData as maindata
                        JOIN Workoperation.Names as workoperation
                            ON maindata.WorkoperationID = workoperation.ID
                    WHERE QA_sign IS NULL AND Framtagning_Processfönster = 'False' AND Aktiv = 'True'
                    ORDER BY RevÄndratDatum";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                var reader = cmd.ExecuteReader();
                dt.Load(reader);
            }

            foreach (DataRow row in dt.Rows)
            {
                var partnr = row[0].ToString();
                var prodline = row[2].ToString();
                var prodtype = row[3].ToString();
                var workoperation = row[4].ToString();
                if (Is_Processcard_Approved(partnr, workoperation, prodline, prodtype))
                    row.Delete();
            }

            dgv.DataSource = dt;
            dgv.Visible = true;
            for (var i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].DefaultCellStyle.BackColor = CustomColors.Bad_Back;       //Röd  Order ej godkänd av QA
                dgv.Rows[i].DefaultCellStyle.ForeColor = CustomColors.Bad_Front;
            }

            dgv.ClearSelection();

        }

        private static bool Is_Processcard_Approved(string partnr, string workoperation, string prodline, string prodtype)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT QA_sign, Framtagning_Processfönster
                    FROM Processcard.MainData
                    WHERE PartNr = @partnr
                        AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL)
                        AND (COALESCE(ProdLine, '') = COALESCE(@prodline, ''))
                        AND (COALESCE(ProdType, '') = COALESCE(@prodtype, ''))
                   
                    ORDER BY RevNr DESC";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partnr", partnr);
            cmd.Parameters.AddWithValue("@workoperation", workoperation);
            cmd.Parameters.AddWithValue("@prodline", prodline);
            cmd.Parameters.AddWithValue("@prodtype", prodtype);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var sign = reader[0].ToString();
                var framtagning = bool.Parse(reader[1].ToString());
                if (framtagning)
                    return true;
                if (string.IsNullOrEmpty(sign))
                    return false;
                return true;
            }

            return true;
        }

        private void RefreshPriorityPlan_Click(object sender, EventArgs e)
        {
            Load_PriorityPlanning();
        }
        private void ProdGrupp_MouseDown(object sender, MouseEventArgs e)
        {
            var dt = new DataTable();
            dt.Columns.Add("Item1", typeof(string));
            dt.Columns.Add("Item2", typeof(string));

            foreach (var kvp in Monitor.Monitor.WorkCenters)
                dt.Rows.Add(kvp.Key, kvp.Value);
            dt.Rows.Add(0, "Processkort Ej godkända av QA");

            using var choose_Item = new Choose_Item(dt, new Control[] { tb_ProdGrupp, tb_ProdBenämning }, false);
            choose_Item.ShowDialog();

        }
        private void ProdGrupp_TextChanged(object sender, EventArgs e)
        {
            //Order.Clear_Order();
            if (Monitor.Monitor.WorkCenters == null || Monitor.Monitor.WorkCenters.Count == 0)
                return;
            if (tb_ProdGrupp.Text == "0")
            {
                tb_ProdBenämning.Text = "Processkort Ej godkända av QA";
                Load_PriorityPlanning_QA_NotApprovedProcesscards(dgv_PriorityPlanning);
                Settings.Settings.SaveData.UPDATE_Setting("ProdLine_LoadingPlan", tb_ProdGrupp, tb_ProdGrupp.Text);
                return;
            }

            if (Monitor.Monitor.WorkCenters.TryGetValue(tb_ProdGrupp.Text, out var workCenter))
            {
                Monitor.Monitor.Load_WorkCenter(tb_ProdGrupp.Text);
                tb_ProdBenämning.Text = workCenter;
            }
            else
                tb_ProdGrupp.Text = Monitor.Monitor.WorkCenters.Keys.First();

            var org_ProdLinje = Order.ProdLine;
            if (Order.WorkOperation == Manage_WorkOperation.WorkOperations.Nothing) //Denna är inte helt säker på att kan vara här, kolla tillräckligt många gånger att det inte medför problem. Testat 2 gånger nu
                Enum.TryParse(Manage_WorkOperation.Workoperation(Order.OrderID), out Order.WorkOperation);

            if (Order.IsOrderDone == false)
                Load_PriorityPlanning();

            Settings.Settings.SaveData.UPDATE_Setting("ProdLine_LoadingPlan", tb_ProdGrupp, tb_ProdGrupp.Text);
            Order.ProdLine = org_ProdLinje;
        }

       

        private void Copy_Text_MouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dgv_PriorityPlanning.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    Clipboard.SetText(cell.Value.ToString());
                }
            }

        }
    }
}
