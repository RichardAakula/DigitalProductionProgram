using Microsoft.Data.SqlClient;
using System.Globalization;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.Blandning_PTFE;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Protocols.Skärmning_TEF;
using DigitalProductionProgram.Protocols.Slipning_TEF;
using DigitalProductionProgram.Protocols.Spolning_PTFE;
using DigitalProductionProgram.Protocols.Svetsning_TEF;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Browse_Protocols
{
    public partial class Browse_Protocols : Form
    {
        private MainProtocol_Blandning_PTFE? blandning_PTFE;
        private MainProtocol_Skärmning_TEF? skärmning_TEF;
        private MainProtocol_Slipning_TEF? slipning_TEF;
        private MainProtocol_Spolning_PTFE? spolning_PTFE;
        private MainProtocol_Svetsning_TEF? svetsning_TEF;


        public static bool Is_BrowsingProtocols;

        public Browse_Protocols(string? partnr = null)
        {
            Module.IsOkToSave = false;
            Manage_Processcards.IsProcesscardUnderManagement = false;
            InitializeComponent();
            var extra_query = string.Empty;
            if (!string.IsNullOrEmpty(partnr))
                extra_query = $" AND PartNr = '{partnr}'";
            this.Shown += async (s, e) => await Load_OrderList(extra_query);

            Initialize_GUI();
           
            Translate_Form();
            Prefab.Translate_Form();
            Processcard_BasedOn.Translate_Form();
            Prefab.btn_AddPreFab.Enabled = Prefab.btn_RemovePreFab.Enabled = false;
            Fill_Menu_Items();

            mainInfo_A.lbl_PartNumber.Cursor = mainInfo_A.lbl_Customer.Cursor = Cursors.Hand;
            mainInfo_A.lbl_PartNumber.MouseClick += PartNr_Click;
            mainInfo_A.lbl_Customer.MouseClick += Customer_Click;
        }
       
        private void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { chb_SelectOrders });
        }
        private void Initialize_GUI()
        {
            Comments.tb_Comments.ReadOnly = true;
            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Blandning_PTFE:
                    Initialize_GUI_Blandning_PTFE();
                    break;
                case Manage_WorkOperation.WorkOperations.Skärmning:
                    Initialize_GUI_Skärmning_TEF();
                    break;
                case Manage_WorkOperation.WorkOperations.Slipning:
                    Initialize_GUI_Slipning_TEF();
                    break;
                case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                    Initialize_GUI_Spolning_PTFE();
                    break;
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    Initialize_GUI_Svetsning_TEF();
                    break;
                default:
                    // Initialize_GUI_Protocol();
                    break;
            }

            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ManageOrderCounter, false) == false)
                chb_SelectOrders.Visible = pb_Info.Visible = false;
            lbl_Header.Text += $" {Order.WorkOperation}";
        }
        private void Fill_Menu_Items()
        {
            cm_Orderlist.Items.Add(LanguageManager.GetString("browseProtocols_1")); //Remove Order
            cm_Orderlist.Items.Add(LanguageManager.GetString("browseProtocols_3")); //Discard Order
            cm_Orderlist.Items.Add(LanguageManager.GetString("browseProtocols_4")); //Activate Order
        }

        private static void Change_ControlsToClickable(IEnumerable<Control> controls)
        {
            foreach (var control in controls)
            {
                control.Enabled = true;
                control.ForeColor = SystemColors.Highlight;
                control.Cursor = Cursors.Hand;
            }
        }
        private void Initialize_GUI_Blandning_PTFE()
        {
            blandning_PTFE = new MainProtocol_Blandning_PTFE();
            flp_Machines.Controls.Add(blandning_PTFE);

            Prefab.Dispose();
            Comments.Dispose();
            Processcard_BasedOn.Dispose();

            blandning_PTFE.Journal.btn_SaveRow.Enabled = false;
            blandning_PTFE.Journal.btn_EditRow.Enabled = false;

            Change_ControlsToClickable(new Control[] { blandning_PTFE.MainInfo.lbl_PartNumber, blandning_PTFE.MainInfo.lbl_Customer, blandning_PTFE.MainInfo.lbl_OrderNr });

            blandning_PTFE.MainInfo.lbl_PartNumber.Click += PartNr_Click;
            blandning_PTFE.MainInfo.lbl_Customer.Click += Customer_Click;
            blandning_PTFE.MainInfo.lbl_OrderNr.Click += Order_Click;

        }

        private void Initialize_GUI_Skärmning_TEF()
        {
            skärmning_TEF = new MainProtocol_Skärmning_TEF();
            flp_Machines.Controls.Add(skärmning_TEF);

            Prefab.Dispose();
            skärmning_TEF.lbl_Add_Arbetskort.Dispose();
            skärmning_TEF.lbl_Kassera_Maskinparameter.Dispose();
            skärmning_TEF.lbl_Transfer_Produktion.Dispose();

            Change_ControlsToClickable(new Control[] { skärmning_TEF.lbl_ArtikelNr, skärmning_TEF.lbl_Customer, skärmning_TEF.lbl_OrderNr });

            skärmning_TEF.lbl_ArtikelNr.Click += PartNr_Click;
            skärmning_TEF.lbl_Customer.Click += Customer_Click;
            skärmning_TEF.lbl_OrderNr.Click += Order_Click;
        }
        private void Initialize_GUI_Slipning_TEF()
        {
            slipning_TEF = new MainProtocol_Slipning_TEF();
            flp_Machines.Controls.Add(slipning_TEF);

            Prefab.Dispose();

            slipning_TEF.Maskinparametrar.Enabled = false;
            slipning_TEF.Produktion.Enabled = false;

            Change_ControlsToClickable(new Control[] { slipning_TEF.MainInfo.lbl_ArtikelNr, slipning_TEF.MainInfo.lbl_Customer, slipning_TEF.MainInfo.lbl_OrderNr });

            slipning_TEF.MainInfo.lbl_ArtikelNr.Click += PartNr_Click;
            slipning_TEF.MainInfo.lbl_Customer.Click += Customer_Click;
            slipning_TEF.MainInfo.lbl_OrderNr.Click += Order_Click;
        }
        private void Initialize_GUI_Spolning_PTFE()
        {
            spolning_PTFE = new MainProtocol_Spolning_PTFE();
            flp_Machines.Controls.Add(spolning_PTFE);

            Prefab.Dispose();
            Processcard_BasedOn.Dispose();

            spolning_PTFE.Journal.btn_SaveRow.Dispose();
            spolning_PTFE.Journal.btn_EditRow.Dispose();

            Change_ControlsToClickable(new Control[] { spolning_PTFE.MainInfo.lbl_ArtikelNr, spolning_PTFE.MainInfo.lbl_Customer, spolning_PTFE.MainInfo.lbl_OrderNr });

            spolning_PTFE.MainInfo.lbl_ArtikelNr.Click += PartNr_Click;
            spolning_PTFE.MainInfo.lbl_Customer.Click += Customer_Click;
            spolning_PTFE.MainInfo.lbl_OrderNr.Click += Order_Click;
        }
        private void Initialize_GUI_Svetsning_TEF()
        {
            svetsning_TEF = new MainProtocol_Svetsning_TEF();
            flp_Machines.Controls.Add(svetsning_TEF);

            Prefab.Dispose();
            svetsning_TEF.Lock_Controls();

            Change_ControlsToClickable(new Control[] { svetsning_TEF.MainInfo.lbl_ArtikelNr, svetsning_TEF.MainInfo.lbl_Customer, svetsning_TEF.MainInfo.lbl_OrderNr });

            svetsning_TEF.MainInfo.lbl_ArtikelNr.Click += PartNr_Click;
            svetsning_TEF.MainInfo.lbl_Customer.Click += Customer_Click;
            svetsning_TEF.MainInfo.lbl_OrderNr.Click += Order_Click;
        }
        private void Initialize_GUI_Protocol()
        {
            AddMachine(1);
        }
        private void AddMachine(int machineIndex)
        {
            var isUsingEquipment = false;
            var height = 0;

            var machine = new Machine(machineIndex, ref isUsingEquipment, ref height, false)
            {
                Name = machineIndex.ToString(),
            };
            var width = machine.TotalWidth;
            if (machine.HorizontalScroll.Visible)
                height += SystemInformation.HorizontalScrollBarHeight;
            machine.Size = new Size(width, height);
            flp_Machines.Controls.Add(machine);

        }

        private async Task Load_OrderList(string extraQuery = null)
        {
            dgv_OrderList.Rows.Clear();
            CustomProgressBar pbar = new CustomProgressBar();
            pbar.Show();


            var orderRows = new List<DataGridViewRow>();

            await Task.Run(() =>
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = $@"
            SELECT 
                PartID, 
                ProtocolMainTemplateID, 
                PartNr, 
                orders.OrderID, 
                orders.OrderNr, 
                RevNr, 
                Date_Start,
                CASE 
                    WHEN discard.OrderID IS NULL THEN 'False' 
                    ELSE 'True' 
                END AS IsOrderInactivated,
                InactivatedBy_Name,
                Inactivated_Date,
                Comment
            FROM [Order].MainData AS orders
            LEFT JOIN [Order].InactiveOrders as discard
                ON orders.OrderID = discard.OrderID
            WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL)
              AND IsOrderDone = 'True'
              {extraQuery}
            ORDER BY Date_Start DESC";

                con.Open(); ServerStatus.Add_Sql_Counter();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation.ToString());
                var reader = cmd.ExecuteReader();

                var isRoleAuthorized = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ManageOrderCounter, false);

                while (reader.Read())
                {
                    var row = new DataGridViewRow();
                    row.CreateCells(dgv_OrderList);
                    row.Cells[0].Value = reader["PartNr"].ToString();
                    row.Cells[1].Value = reader["ProtocolMainTemplateID"].ToString();
                    row.Cells[2].Value = reader["PartID"].ToString();
                    row.Cells[3].Value = reader["OrderNr"].ToString();
                    row.Cells[4].Value = reader["OrderID"].ToString();
                    row.Cells[5].Value = reader["RevNr"].ToString();

                    var date = DateTime.Parse(reader["Date_Start"].ToString());
                    var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                    var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                    row.Cells[7].Value = formattedDate;

                    bool isDiscarded = bool.TryParse(reader["IsOrderInactivated"].ToString(), out var temp) && temp;

                    if (isRoleAuthorized)
                    {
                        row.Cells[8].Value = isDiscarded;
                        row.Cells[9].Value = reader["InactivatedBy_Name"].ToString();
                        row.Cells[10].Value = reader["Inactivated_Date"].ToString();
                        row.Cells[11].Value = reader["Comment"].ToString();
                    }

                    row.DefaultCellStyle.BackColor = isDiscarded ? CustomColors.Bad_Back : CustomColors.Ok_Back;
                    row.DefaultCellStyle.ForeColor = isDiscarded ? CustomColors.Bad_Front : CustomColors.Ok_Front;

                    orderRows.Add(row);
                }
            });

            // Uppdatera UI när all data är klar
            dgv_OrderList.Rows.AddRange(orderRows.ToArray());
            pbar.Close();
        }

        private void OrderList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex;
            if (dgv_OrderList.Rows[row].Cells["orderlist_Inactive"].Value != null)
            {
                if (bool.TryParse(dgv_OrderList.Rows[row].Cells["orderlist_Inactive"].Value.ToString(), out var isDiscarded))
                {
                    if (isDiscarded)
                    {
                        panel_DiscardedOrder_Info.Visible = true;
                        if (dgv_OrderList.Rows[row].Cells["orderlist_InactivatedBy"].Value != null)
                            lbl_DiscardedBy.Text = dgv_OrderList.Rows[row].Cells["orderlist_InactivatedBy"].Value.ToString();
                        if (dgv_OrderList.Rows[row].Cells["orderlist_InactivatedDate"].Value != null)
                            lbl_DiscardedDate.Text = dgv_OrderList.Rows[row].Cells["orderlist_InactivatedDate"].Value.ToString();
                        if (dgv_OrderList.Rows[row].Cells["orderlist_InactivatedComment"].Value != null)
                            lbl_DiscardedComment.Text = dgv_OrderList.Rows[row].Cells["orderlist_InactivatedComment"].Value.ToString();
                    }
                    else
                        panel_DiscardedOrder_Info.Visible = false;
                }
            }

            if (chb_SelectOrders.Checked == false)
                Load_Data(row);

        }
        private void OrderList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ManageOrderCounter, false) == false)
                return;
            if (e.Button != MouseButtons.Right)
                return;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgv_OrderList.ClearSelection();
                dgv_OrderList.Rows[e.RowIndex].Selected = true;
            }

            cm_Orderlist.Show(dgv_OrderList.PointToScreen(dgv_OrderList.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location));
        }
        private void OrderList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Count_Orders();
        }
        private void OrderList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Count_Orders();
        }
        private void OrderList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Count_Orders();
        }



        private void Count_Orders()
        {
            var count = dgv_OrderList.Rows.Cast<DataGridViewRow>()
                .Count(row =>
                    row.Cells["orderlist_Inactive"].Value is bool b && b == false);
            lbl_TotalOrders.Text = $"{count} orders";
        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var value = e.ClickedItem;
            if (value == null)
                return;
            var row = dgv_OrderList.SelectedCells[0].RowIndex;
            int.TryParse(dgv_OrderList.Rows[row].Cells["orderlist_OrderID"].Value.ToString(), out var orderid);
            switch (value.Text)
            {
                case var text when text == LanguageManager.GetString("browseProtocols_1")://Remove Order
                    Menu_RemoveOrder();
                    break;
                case var text when text == LanguageManager.GetString("browseProtocols_3")://Discard Order
                    Menu_DeactivateOrder(orderid, row);
                    break;
                case var text when text == LanguageManager.GetString("browseProtocols_4"): //Activate Order
                    Menu_ActivateOrder(orderid, row);
                    break;
            }
        }
        private void Menu_RemoveOrder()
        {
            var rows = (from DataGridViewRow dgvRow in dgv_OrderList.SelectedRows select dgvRow.Index).ToList();
            rows.Sort();
            for (var i = rows.Count - 1; i >= 0; i--)
            {
                var rowIndex = rows[i];
                dgv_OrderList.Rows.RemoveAt(rowIndex);
            }
        }
        private void Menu_DeactivateOrder(int orderid, int row)
        {
            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ManageOrderCounter) == false)
                return;

            var password = new PasswordManager("Bekräfta att du avaktiverar denna order med ditt lösenord.");
            password.ShowDialog();
            if (password.IsOk == false)
                return;

            InfoText.PromptForText("Fyll i en kommentar om varför denna order skall skrotas/ej räknas med i orderräknaren.", CustomColors.InfoText_Color.Info, string.Empty, this, null);

            var comment = InfoText.return_Text;
            if (string.IsNullOrEmpty(comment))
            {
                InfoText.Show("Du måste fylla i en kommentar om varför du skrotar ordern.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }

            Order.DeActivateOrder(orderid, comment);
            dgv_OrderList.Rows[row].Cells["orderlist_Inactive"].Value = true;
            dgv_OrderList.Rows[row].Cells["orderlist_InactivatedBy"].Value = lbl_DiscardedBy.Text = Person.Name;
            dgv_OrderList.Rows[row].Cells["orderlist_InactivatedDate"].Value = lbl_DiscardedDate.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            dgv_OrderList.Rows[row].Cells["orderlist_InactivatedComment"].Value = lbl_DiscardedComment.Text = comment;

            panel_DiscardedOrder_Info.Visible = true;
            dgv_OrderList.Rows[row].DefaultCellStyle.BackColor = CustomColors.Bad_Back;
            dgv_OrderList.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Bad_Front;
        }
        private void Menu_ActivateOrder(int orderid, int row)
        {
            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ManageOrderCounter) == false)
                return;
            panel_DiscardedOrder_Info.Visible = false;
            dgv_OrderList.Rows[row].Cells["orderlist_Inactive"].Value = false;
            dgv_OrderList.Rows[row].Cells["orderlist_InactivatedBy"].Value = lbl_DiscardedBy.Text = string.Empty;
            dgv_OrderList.Rows[row].Cells["orderlist_InactivatedDate"].Value = lbl_DiscardedDate.Text = string.Empty;
            dgv_OrderList.Rows[row].Cells["orderlist_InactivatedComment"].Value = lbl_DiscardedComment.Text = string.Empty;
            dgv_OrderList.Rows[row].DefaultCellStyle.BackColor = CustomColors.Ok_Back;
            dgv_OrderList.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Ok_Front;
            Order.ActivateOrder(orderid);
        }

        private void Load_Data(int row)
        {
            DrawingControl.SuspendDrawing(this);

            Order.OrderID = null;
            Order.PartID = null;
            if (dgv_OrderList.Rows[row].Cells["orderlist_OrderID"].Value is null)
            {
                DrawingControl.ResumeDrawing(this);
                return;
            }
            if (int.TryParse(dgv_OrderList.Rows[row].Cells["orderlist_OrderID"].Value.ToString(), out var orderID))
                Order.OrderID = orderID;
            if (int.TryParse(dgv_OrderList.Rows[row].Cells["orderlist_PartID"].Value.ToString(), out var partID))
                Order.PartID = partID;

            Order.PartNumber = dgv_OrderList.Rows[row].Cells["orderlist_PartNr"].Value.ToString();

            int.TryParse(dgv_OrderList.Rows[row].Cells["orderList_MainTemplateID"].Value.ToString(), out var mainTemplateID);
            Templates_Protocol.MainTemplate.ID = mainTemplateID;
            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Blandning_PTFE:
                    Load_Blandning_PTFE();
                    break;
                case Manage_WorkOperation.WorkOperations.Kragning_TEF:
                    ///  kragning_TEF.Load_Data();
                    break;
                case Manage_WorkOperation.WorkOperations.Skärmning:
                    skärmning_TEF?.Load_Data();
                    break;
                case Manage_WorkOperation.WorkOperations.Slipning:
                    Load_Slipning_TEF();
                    break;
                case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                    Load_Spolning_PTFE();
                    break;
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    svetsning_TEF?.Load_Data();
                    break;
                default:
                    flp_Machines.Controls.Clear();

                    for (int i = 0; i < Machine.TotalMachines; i++)
                        AddMachine(i + 1);

                    break;
            }

            Processcard_BasedOn.Load_Data();
            Comments.Load_Data();

            if (Prefab.IsDisposed == false)
            {
                if (Prefab.dgv.Columns.Count > 0)
                {
                    Prefab.Load_Data(null, false);
                    Prefab.dgv.Columns[3].DefaultCellStyle.ForeColor = SystemColors.Highlight;
                    Prefab.dgv.Columns[1].DefaultCellStyle.ForeColor = SystemColors.Highlight;
                }
            }

            mainInfo_A.Load_Data(Order.OrderID);


            Select();
            DrawingControl.ResumeDrawing(this);
        }

        private void Load_Blandning_PTFE()
        {
            blandning_PTFE?.Load_Data();
            Part.SetPartNrSpecial("Blandning Pigment");
            if (Part.IsPartNrSpecial == false)
            {
                if (blandning_PTFE != null) blandning_PTFE.Width = 871;
            }
            else if (blandning_PTFE != null) blandning_PTFE.Width = 1092;

            blandning_PTFE?.Journal.dgv_Journal_Input.Rows.RemoveAt(0);
        }

        private void Load_Slipning_TEF()
        {
            slipning_TEF?.Load_Data();
            Part.SetPartNrSpecial("Extra Parametrar Slipning_TEF");
            if (Part.IsPartNrSpecial == false)
            {
                if (slipning_TEF != null) slipning_TEF.Width = 950;
            }
            else if (slipning_TEF != null) slipning_TEF.Width = 1038;

            Processcard_BasedOn.Load_Data();
            Comments.Load_Data();
        }
        private void Load_Spolning_PTFE()
        {
            spolning_PTFE?.Load_Data();
            if (spolning_PTFE != null)
            {
                spolning_PTFE.Width = (from DataGridViewColumn column in spolning_PTFE.Journal.dgv_Journal_Input.Columns where column.Visible select column.Width + 1).Sum();
                spolning_PTFE.Journal.dgv_Journal_Input.Rows.RemoveAt(0);
            }
        }


        private async void PartNr_Click(object? sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var choose_Item = new Choose_Item(Part.List_PartNr, new[] { ctrl }, false);
            choose_Item.ShowDialog();
            await Load_OrderList($" AND PartNr = '{ctrl.Text}'");
        }
        private async void Customer_Click(object? sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var choose_Item = new Choose_Item(Customer.Customer.List_Customers, new[] { ctrl }, false);
            choose_Item.ShowDialog();
            await Load_OrderList($" AND Customer = '{ctrl.Text}'");
        }
        private async void Order_Click(object? sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var choose_Item = new Choose_Item(Order.List_Orders, new[] { ctrl }, false);
            choose_Item.ShowDialog();
            await Load_OrderList($" AND OrderNr = '{ctrl.Text}'");
        }
        private async void ProdType_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var choose_Item = new Choose_Item(Order.List_ProdType, new[] { ctrl }, false);
            choose_Item.ShowDialog();
            await Load_OrderList($" AND ProdType = '{ctrl.Text}'");
        }
        private async void Halvfabrikat_Click(object sender, EventArgs e)
        {
            var column = Prefab.dgv.CurrentCell.ColumnIndex;
            DataGridViewCell[] cells = { Prefab.dgv.Rows[0].Cells[column] };
            string codetext;
            List<string?> items;
            switch (column)
            {
                case 1:
                    items = PreFab.ListMaterial;
                    codetext = "Halvfabrikat_Benämning";
                    break;
                case 3:
                    items = PreFab.ListBatchNr;
                    codetext = "Halvfabrikat_OrderNr";
                    break;
                default:
                    return;
            }

            var choose_Items = new Choose_Item(items, cells);
            choose_Items.ShowDialog();
            await Load_OrderList($" AND OrderID IN (SELECT OrderID FROM [Order].PreFab WHERE {codetext} = '{cells[0].Value}')");
        }
        private async void Protocol_Click(object sender, EventArgs e)
        {
            var dgv = (DataGridView)sender;
            DataGridViewCell[] cells = { dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0] };

            int.TryParse(dgv.Rows[dgv.CurrentCell.RowIndex].Cells["ProtocolDescriptionID"].Value.ToString(), out var protocoldescriptionid);
            var items = new List<string?>();
            await using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT DISTINCT TextValue, Value 
                    FROM [Order].Data 
                    WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE Workoperation = @workoperation) 
                        AND ProtocolDescriptionID = @protocoldescriptionid
                    ORDER BY TextValue";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation.ToString());
                cmd.Parameters.AddWithValue("@protocoldescriptionid", protocoldescriptionid);
                con.Open();
                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                    items.Add(reader[0].ToString());
            }

            if (items.Count == 0)
            {
                InfoText.Show("Denna funktion fungerar endast om det finns data i Processkortet", CustomColors.InfoText_Color.Warning, "Warning", this);
                return;
            }
            var choose_Items = new Choose_Item(items, cells);
            choose_Items.ShowDialog();
            await Load_OrderList($" AND OrderID IN (SELECT DISTINCT OrderID FROM [Order].Data WHERE TextValue = '{cells[0].Value}')");
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Export_Excel_Click(object sender, EventArgs e)
        {
            var listOrderID = new List<int>();
            var listMaintemplateid = new List<int>();
            for (var i = 0; i < dgv_OrderList.Rows.Count; i++)
            {
                var orderid = int.Parse(dgv_OrderList.Rows[i].Cells["orderlist_OrderID"].Value.ToString() ?? string.Empty);
                var maintemplateid = int.Parse(dgv_OrderList.Rows[i].Cells["orderList_MainTemplateID"].Value.ToString() ?? string.Empty);
                listOrderID.Add(orderid);
                if (listMaintemplateid.Contains(maintemplateid) == false)
                    listMaintemplateid.Add(maintemplateid);
            }

            //var listFormtemplateid = new List<int>();
            //using (var con = new SqlConnection(Database.cs_Protocol))
            //{
            //    const string query = @"SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid";
            //    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            //    cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
            //    con.Open();
            //    var reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        int.TryParse(reader[0].ToString(), out var formtemplateid);
            //        listFormtemplateid.Add(formtemplateid);
            //    }
            //}

            //Get_Protocol_Data.TransferDataToExcel.TransferData(listOrderID, listFormtemplateid, listMaintemplateid, dgv_OrderList.Rows[0].Cells["orderlist_PartNr"].Value.ToString() ?? string.Empty);
            Get_Protocol_Data.TransferDataToExcel.TransferData(listOrderID, dgv_OrderList.Rows[0].Cells["orderlist_PartNr"].Value.ToString() ?? string.Empty);

        }
        private void PrintOrder_Click(object sender, EventArgs e)
        {
            Main_Form.Preview_PrintOut();
        }
        private void Info_Click(object sender, EventArgs e)
        {
            InfoText.Show(LanguageManager.GetString("browseProtocols_2"), CustomColors.InfoText_Color.Info, "Info", this);
        }

        private void Browse_Protocols_FormClosing(object sender, FormClosingEventArgs e)
        {
            Is_BrowsingProtocols = false;
            Order.Restore_TempOrderInfo();
        }

       
    }
}
