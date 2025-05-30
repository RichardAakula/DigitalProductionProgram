using System;
using System.Data;
using DigitalProductionProgram.ControlsManagement;
using Microsoft.Data.SqlClient;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Monitor.GET;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;

namespace DigitalProductionProgram.MainWindow
{
    public partial class Main_Priorityplanning : UserControl
    {
        private readonly Label label_OrderKlar = new Label();

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
            var controls = new Control[] { btn_RefreshPriorityPlan, label_ProductionSchedule, label_ProdGroup, label_Green, label_Yellow, label_White, label_Blue, label_Orange, label_Brown, label_Red };
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }

        public void Load_PriorityPlanning()
        {
            var dt = dt_PriorityPlan;
            dgv_PriorityPlanning.Invoke(new Action(() => dgv_PriorityPlanning.DataSource = null));

            if (Settings.Settings.MeasuringComputerOnly || Main_Form.IsLoadingPriorityPlan == false)
                return;

            var WorkCenter = Utilities.GetOneFromMonitor<Manufacturing.WorkCenters>($"filter=Number Eq'{tb_ProdGrupp.Text}'");
            if (WorkCenter is null)
                return;
            var orderOperations = Utilities.GetFromMonitor<Manufacturing.ManufacturingOrderOperations>($"filter=WorkCenterId Eq'{WorkCenter.Id}' AND RestQuantity gt'0'", "orderby=Priority");
            var ctr = -1;

            Manage_WorkOperation.WorkOperations workOperation = new Manage_WorkOperation.WorkOperations();
            foreach (var row in orderOperations)
            {
                ctr++;
                var ordernr = Utilities.GetOneFromMonitor<Manufacturing.ManufacturingOrders>($"filter=Id Eq'{row.ManufacturingOrderId}'");
                var part = Utilities.GetOneFromMonitor<Inventory.Parts>($"filter=Id Eq'{row.PartId}'");
                var ts = row.PlannedFinishDate - row.PlannedStartDate;
                if (ordernr == null)
                    continue;

                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["OrderNr"] = ordernr.OrderNumber;
                dt.Rows[dt.Rows.Count - 1]["Operation"] = row.OperationNumber;
                dt.Rows[dt.Rows.Count - 1]["ArtikelNr"] = part.PartNumber;
                dt.Rows[dt.Rows.Count - 1]["Benämning"] = part.Description;
                dt.Rows[dt.Rows.Count - 1]["ProdLine"] = row.Description;
                dt.Rows[dt.Rows.Count - 1]["Antal Rest"] = $"{row.RestQuantity:0}";
                dt.Rows[dt.Rows.Count - 1]["Antal"] = $"{row.PlannedQuantity:0}";
                dt.Rows[dt.Rows.Count - 1]["Total Tid"] = $"{ts.TotalHours:0.0}";
                dt.Rows[dt.Rows.Count - 1]["Planerad Start"] = $"{row.PlannedStartDate:yyyy-MM-dd}";
                dt.Rows[dt.Rows.Count - 1]["Planerad Stopp"] = $"{row.PlannedFinishDate:yyyy-MM-dd}";
                dt.Rows[dt.Rows.Count - 1]["Order Startad"] = Order.IsOrder_Exist(ordernr.OrderNumber, row.OperationNumber.ToString());
                dt.Rows[dt.Rows.Count - 1]["Processkort Godkänt"] = Part.IsPartNr_ApprovedQA;


                dgv_PriorityPlanning.Invoke(new Action(() => dgv_PriorityPlanning.DataSource = dt));
                dgv_PriorityPlanning.Invoke(new Action(() => dgv_PriorityPlanning.Columns["Order Startad"].Visible = false));
                dgv_PriorityPlanning.Invoke(new Action(() => dgv_PriorityPlanning.Columns["Processkort Godkänt"].Visible = false));

                var partNr = dgv_PriorityPlanning.Rows[ctr].Cells["ArtikelNr"].Value.ToString();
                var operation = row.OperationNumber;
                var orderID = Order.GetOrderID(ordernr.OrderNumber, operation.ToString());
               
                if (workOperation == Manage_WorkOperation.WorkOperations.Nothing)
                    workOperation = Manage_WorkOperation.Load_WorkOperation(false, orderID, null, row.Description);

                var partID = Part.Get_PartID(partNr, workOperation);

                //GUL       Order startad
                if (IsOrderStarted(ctr))
                    continue;

                //GRÖN      Skall ej ha PROCESSKORT, OK Att starta
                if (IsNoProcesscard(ctr, workOperation))
                    continue;
                //RÖD       Order ej godkänd av QA
                if (IsNotApprovedByQA(ctr, partID))
                    continue;
                //Vit       Parametrar saknas
                if (IsProcesscardMissing(ctr, partID))
                    continue;
                //Orange    PartNr utan processkort körd fler än 3 ggr - Processkort behövs - Kontakta arbetsledare
                if (IsProcesscardMissingAndRunnedMoreThan3Times(ctr, partID))
                    continue;

                //Brun    Processkort under framarbetning och körd fler än 3 gånger - Kontakta arbetsledare
                if (IsProcesscardUnderConstructionAndRunnedMoreThan3Times(ctr, operation, partID))
                    continue;
                //Grön      Order Ok att starta
                if (IsOrderOkStart(ctr))
                    continue;
            }
        }
        private bool IsOrderStarted(int row)
        {
            if (bool.Parse(dgv_PriorityPlanning.Rows[row].Cells["Order Startad"].Value.ToString()))
            {
                dgv_PriorityPlanning.Rows[row].DefaultCellStyle.BackColor = CustomColors.Warning_Back;
                dgv_PriorityPlanning.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Warning_Front;
                return true;
            }
            return false;
        }
        private bool IsNoProcesscard(int row, Manage_WorkOperation.WorkOperations workoperation)
        {
            if (!Processcard.IsNotUsing_Processcard(workoperation)) 
                return false;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.BackColor = CustomColors.Ok_Back;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Ok_Front;
            return true;
        }
        private bool IsNotApprovedByQA(int row, int? partID)
        {
            if (bool.Parse(dgv_PriorityPlanning.Rows[row].Cells["Processkort Godkänt"].Value.ToString()) || !Part.IsPartID_Exist(partID)) 
                return false;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.BackColor = CustomColors.Bad_Back;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Bad_Front;
            return true;
        }
        private bool IsProcesscardMissing(int row, int? partID)
        {
            if (Part.IsPartID_Exist(partID)) 
                return false;
            if (Part.TotalOrders_WithoutProcesscard >= 3) 
                return false;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.BackColor = CustomColors.Parametrar_Saknas_Back;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Parametrar_Saknas_Front;
            return true;
        }
        private bool IsProcesscardMissingAndRunnedMoreThan3Times(int row, int? partID)
        {
            if (Part.IsPartID_Exist(partID)) 
                return false;
            if (Part.TotalOrders_WithoutProcesscard <= 2) 
                return false;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.BackColor = Color.DarkOrange;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.ForeColor = Color.Brown;
            return true;
        }
        private bool IsProcesscardUnderConstructionAndRunnedMoreThan3Times(int row, int operation, int? partID)
        {
            if (!Part.IsPartNr_UnderConstruction(partID) || Part.TotalOrders_PartID(partID) <= 2) 
                return false;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.BackColor = Color.Brown;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.ForeColor = Color.DarkOrange;
            return true;
        }
        private bool IsOrderOkStart(int row)
        {
            if (bool.Parse(dgv_PriorityPlanning.Rows[row].Cells["Order Startad"].Value.ToString())) 
                return false;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.BackColor = CustomColors.Ok_Back;
            dgv_PriorityPlanning.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Ok_Front;
            return true;
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
                var cmd = new SqlCommand(query, con);
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
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT QA_sign, Framtagning_Processfönster
                    FROM Processcard.MainData
                    WHERE PartNr = @partnr
                        AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL)
                        AND (COALESCE(ProdLine, '') = COALESCE(@prodline, ''))
                        AND (COALESCE(ProdType, '') = COALESCE(@prodtype, ''))
                   
                    ORDER BY RevNr DESC";
                con.Open();
                var cmd = new SqlCommand(query, con);
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

            var choose_Item = new Choose_Item(dt, new Control[] { tb_ProdGrupp, tb_ProdBenämning }, false);
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

      
    }
}
