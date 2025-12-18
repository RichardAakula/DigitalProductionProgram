using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.MainWindow;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using CustomProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;

namespace DigitalProductionProgram.OrderManagement
{
    public partial class Open_Order : Form
    {
        public bool svarÖppna;
        private static DataTable? dt_Korprotokoll_MainData;
        private bool IsOkFilterData;

        // Progressbar host on separate UI thread
        private CustomProgressBar? pbar;
        private Thread? pbarThread;
        private readonly AutoResetEvent pbarReady = new(false);

        public Open_Order()
        {
            InitializeComponent();
            date_From.Value = DateTime.Now.AddYears(-1);
            Translate_Form();
            _ = Task.Run(Load_dt_Korprotokoll_MainDataAsync);
            lastDateFromValue = date_From.Value;
            IsOkFilterData = true;
        }
        private async void Open_Order_Shown(object sender, EventArgs e)
        {
            // Start progress on its own UI thread so it keeps animating while main thread is busy.
            // ShowProgressOnNewThread("Laddar ordrar...");

            // Small delay to ensure progress window paints before binding starts
            // await Task.Delay(150);

            // Perform the slow UI-thread binding (DataGridView must be updated on UI thread)
            Fill_dgv_OrderList();

            // Close the progress window
            // CloseProgressbar();
        }

        private void Translate_Form()
        {
            var controls = new Control[] { label_PartNumber, label_ProdLine, label_Customer, label_DateTo, label_DateFrom, btn_OpenOrder };
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }

        public async Task Load_dt_Korprotokoll_MainDataAsync()
        {
            dt_Korprotokoll_MainData = new DataTable();
            try
            {
                await using var con = new SqlConnection(Database.cs_Protocol);
                await con.OpenAsync();

                const string query = @"
                    SELECT OrderID, template.Name, OrderNr, Operation, PartNr, RevNr, ProdLine, Customer, Date_Start
                    FROM [Order].MainData as maindata
                        LEFT JOIN Protocol.MainTemplate AS template 
                            ON maindata.ProtocolMainTemplateID = template.ID
                    WHERE Date_Start > @datefrom
                    ORDER BY Date_Start DESC";

                await using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@datefrom", DateTime.Parse(date_From.Value.ToString()));
                ServerStatus.Add_Sql_Counter();

                await using var reader = await cmd.ExecuteReaderAsync();

                var dt = new DataTable();
               
                dt.Load(reader);
                int test = dt.Rows.Count;
                dt_Korprotokoll_MainData = dt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Fel vid laddning av Körprotokoll-data: {ex.Message}");
                dt_Korprotokoll_MainData = new DataTable(); // tom fallback
            }
        }

        private async void Fill_dgv_OrderList()
        {
            ShowProgressOnNewThread("Laddar ordrar...");
            await Task.Delay(150);

            dgv_OrderList.DataSource = dt_Korprotokoll_MainData;
            dgv_OrderList.Columns[0].Visible = false;
            dgv_OrderList.Columns[0].Width = 0;
            date_From.Value = DateTime.Parse(dt_Korprotokoll_MainData.Rows[^1]["Date_Start"].ToString());
            OrderList_ChangeWidth();
            CloseProgressbar();
        }
        private void Öppna_Click(object sender, EventArgs e)
        {
            Order.OrderNumber = dgv_OrderList.Rows[dgv_OrderList.CurrentCell.RowIndex].Cells["OrderNr"].Value.ToString();
            Order.Operation = dgv_OrderList.Rows[dgv_OrderList.CurrentCell.RowIndex].Cells["Operation"].Value.ToString();
            Order.OrderID = int.Parse(dgv_OrderList.Rows[dgv_OrderList.CurrentCell.RowIndex].Cells["OrderID"].Value.ToString());
            svarÖppna = true;
            Close();
        }


        private void Filter_TextChanged(object sender, EventArgs e)
        {
            if (IsOkFilterData == false)
                return;
            var filterCondition =
                $"[PartNr] LIKE '%{tb_PartNumber.Text}%' ";
            if (!string.IsNullOrEmpty(tb_OrderNr.Text))
                filterCondition += $"AND [OrderNr] LIKE '%{tb_OrderNr.Text}%' ";
            if (!string.IsNullOrEmpty(tb_ProdLine.Text))
                filterCondition += $"AND [ProdLine] LIKE '%{tb_ProdLine.Text}%' ";
            if (!string.IsNullOrEmpty(tb_Customer.Text))
                filterCondition += $"AND [Customer] LIKE '%{tb_Customer.Text}%' ";
            if (!string.IsNullOrEmpty(tb_TemplateName.Text))
                filterCondition += $"AND [Name] = '{tb_TemplateName.Text}' ";

            filterCondition += $"AND [Date_Start] >= '{date_From.Value}' AND [Date_Start] <= '{date_To.Value}'";
            dt_Korprotokoll_MainData.DefaultView.RowFilter = filterCondition;
            Fill_dgv_OrderList();
            OrderList_ChangeWidth();
        }

        private DateTime lastDateFromValue;
        private async void date_From_ValueChanged(object sender, EventArgs e)
        {
            if (date_From.Value < lastDateFromValue)
            {
                await Load_dt_Korprotokoll_MainDataAsync();
                lastDateFromValue = date_From.Value;
                Filter_TextChanged(sender, e);
            }
        }
        private void OrderList_ChangeWidth()
        {
            if (dgv_OrderList.InvokeRequired)
            {
                dgv_OrderList.Invoke(new Action(OrderList_ChangeWidth));
                return;
            }

            var totalWidth = 0;
            for (var i = 0; i < dgv_OrderList.Columns.Count; i++)
            {
                if (dgv_OrderList.Columns[i].Visible)
                    totalWidth += dgv_OrderList.Columns[i].Width;
            }

            dgv_OrderList.Width = totalWidth + 20;
        }

        private void tb_CodeText_Click(object sender, EventArgs e)
        {
            var list = new List<string?>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT CodeText FROM Protocol.Description ORDER BY CodeText";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader[0].ToString());
            }

            using var item = new Choose_Item(list, new Control[] { tb_CodeText }, false, false, true);
            item.ShowDialog();
        }
        private void tb_TemplateName_Enter(object sender, EventArgs e)
        {
            var list = new List<string?>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT Name FROM Protocol.MainTemplate ORDER BY Name";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(reader[0].ToString());
            }

            using var item = new Choose_Item(list, new Control[] { tb_TemplateName }, false, false, true);
            item.ShowDialog();
        }

        // Show the progress dialog on a dedicated STA thread so it can continue animating.
        private void ShowProgressOnNewThread(string text)
        {
            // Ensure any previous instance is closed
            if (pbar != null)
                CloseProgressbar();

            pbarReady.Reset();
            pbarThread = new Thread(() =>
            {
                var local = new CustomProgressBar();
                local.pBar_Main.Style = ProgressBarStyle.Marquee;
                local.pBar_Main.MarqueeAnimationSpeed = 30;
                local.lbl_Percent_Main.Visible = false;
                local.Set_ValueProgressBar(0, text);
                pbar = local;
                // signal that the form is created and shown
                pbarReady.Set();
                Application.Run(local);
            });

            pbarThread.SetApartmentState(ApartmentState.STA);
            pbarThread.IsBackground = true;
            pbarThread.Start();

            // Wait until form is created before continuing
            pbarReady.WaitOne();
        }

        private void CloseProgressbar()
        {
            try
            {
                if (pbar != null && !pbar.IsDisposed)
                {
                    // Close safely on the progress form's thread
                    pbar.BeginInvoke((MethodInvoker)(() =>
                    {
                        try
                        {
                            if (!pbar.IsDisposed)
                                pbar.Close();
                        }
                        catch { }
                    }));

                    // Allow some time for Application.Run to exit and thread to finish
                    pbarThread?.Join(500);
                }
            }
            catch { }
            finally
            {
                pbar = null;
                pbarThread = null;
            }
        }

       

        private void label_DateFrom_Click(object sender, EventArgs e)
        {
            date_From.Value = DateTime.Now.AddDays(-7);
        }

        
    }
}