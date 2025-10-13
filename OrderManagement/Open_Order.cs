using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.MainWindow;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using CustomProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;

namespace DigitalProductionProgram.OrderManagement
{
    public partial class Open_Order : Form
    {
        public bool svarÖppna;
        private static DataTable? dt_Korprotokoll_MainData;
        private bool IsOkFilterData;
        readonly CustomProgressBar pbar = new CustomProgressBar();

        public Open_Order()
        {
            InitializeComponent();
            Translate_Form();

            IsOkFilterData = true;
        }

        private void Translate_Form()
        {
            var controls = new Control[] { label_PartNumber, label_ProdLine, label_Customer, label_DateTo, label_DateFrom, btn_OpenOrder };
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }

        public static async Task Load_dt_Korprotokoll_MainDataAsync()
        {
            try
            {
                await using var con = new SqlConnection(Database.cs_Protocol);
                await con.OpenAsync();

                const string query = @"
                    SELECT OrderID, template.Name, OrderNr, Operation, PartNr, RevNr, ProdLine, Customer, Date_Start
                    FROM [Order].MainData as maindata
                        LEFT JOIN Protocol.MainTemplate AS template 
                            ON maindata.ProtocolMainTemplateID = template.ID
                    ORDER BY Date_Start DESC";

                await using var cmd = new SqlCommand(query, con);
                ServerStatus.Add_Sql_Counter();

                await using var reader = await cmd.ExecuteReaderAsync();

                var dt = new DataTable();
                dt.Load(reader);

                dt_Korprotokoll_MainData = dt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Fel vid laddning av Körprotokoll-data: {ex.Message}");
                dt_Korprotokoll_MainData = new DataTable(); // tom fallback
            }
        }

        private void Fill_dgv_OrderList()
        {
            dgv_OrderList.DataSource = dt_Korprotokoll_MainData;
            dgv_OrderList.Columns[0].Visible = false;
            dgv_OrderList.Columns[0].Width = 0;
            //date_To.Value = DateTime.Parse(dgv_OrderList.Rows[0].Cells["Date_Start"].Value.ToString());
            //if (dgv_OrderList.Rows.Count > 0)
            date_From.Value = DateTime.Parse(dt_Korprotokoll_MainData.Rows[^1]["Date_Start"].ToString());
            OrderList_ChangeWidth();
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
            OrderList_ChangeWidth();
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

        private async void Open_Order_Shown(object sender, EventArgs e)
        {
            pbar.Show();
            pbar.pBar_Main.Style = ProgressBarStyle.Marquee;
            pbar.pBar_Main.MarqueeAnimationSpeed = 30;
            pbar.Set_ValueProgressBar(0, "Laddar ordrar...");
            await Task.Delay(250);
            Fill_dgv_OrderList();

            pbar.Close();
        }

        private void label_DateFrom_Click(object sender, EventArgs e)
        {
            date_From.Value = DateTime.Now.AddDays(-7);
        }
    }
}