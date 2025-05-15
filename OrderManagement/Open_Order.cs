using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using ProgressBar = DigitalProductionProgram.ControlsManagement.ProgressBar;

namespace DigitalProductionProgram.OrderManagement
{
    public partial class Open_Order : Form
    {
        public bool svarÖppna;
        private readonly ProgressBar pbar;
        private DataTable dt_Korprotokoll_MainData;
        private bool IsOkFilterData;

        public Open_Order()
        {
            InitializeComponent();
            pbar = new ProgressBar();
            Translate_Form();
        }
        private void Öppna_Load(object sender, EventArgs e)
        {
            pbar.Show();
            Load_dt_Korprotokoll_MainData();
            OrderList_ChangeWidth();
            pbar.Close();
            IsOkFilterData = true;
        }
        private void Translate_Form()
        {
            var controls = new Control[] { label_PartNumber, label_ProdLine, label_Customer, label_DateTo, label_DateFrom, btn_OpenOrder};
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }

        private void Load_dt_Korprotokoll_MainData()
        {
            dt_Korprotokoll_MainData = new DataTable();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
               con.Open();
                var query = $@"
                    SELECT OrderID, OrderNr, Operation, PartNr, ProdLine, Customer, Date_Start
                    FROM [Order].MainData
                    ORDER BY Date_Start DESC";


                var cmd = new SqlCommand(query, con);
                var da = new SqlDataAdapter(cmd);

                da.Fill(dt_Korprotokoll_MainData);
                da.Dispose();
            }
            pbar.Set_ValueProgressBar(0, "Loading Orders...");
            dgv_OrderList.DataSource = dt_Korprotokoll_MainData;
            dgv_OrderList.Columns[0].Visible = false;
            dgv_OrderList.Columns[0].Width = 0;
            date_To.Value = DateTime.Parse(dgv_OrderList.Rows[0].Cells["Date_Start"].Value.ToString());
            pbar.Set_ValueProgressBar(20, "Loading Orders...");
            if (dgv_OrderList.Rows.Count > 0)
                date_From.Value = DateTime.Parse(dgv_OrderList.Rows[dgv_OrderList.Rows.Count-1].Cells["Date_Start"].Value.ToString());
        }

        private void Öppna_Click(object sender, EventArgs e)
        {
            Order.OrderNumber = dgv_OrderList.Rows[dgv_OrderList.CurrentCell.RowIndex].Cells["OrderNr"].Value.ToString();
            Order.Operation = dgv_OrderList.Rows[dgv_OrderList.CurrentCell.RowIndex].Cells["Operation"].Value.ToString();
            Order.OrderID = int.Parse(dgv_OrderList.Rows[dgv_OrderList.CurrentCell.RowIndex].Cells["OrderID"].Value.ToString());
            svarÖppna = true;
            Close();
        }


        private void PartNumber_TextChanged(object sender, EventArgs e)
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
            
                filterCondition += $"AND [Date_Start] >= '{date_From.Value}' AND [Date_Start] <= '{date_To.Value}'";

            dt_Korprotokoll_MainData.DefaultView.RowFilter = filterCondition;
            OrderList_ChangeWidth();
        }
        private void OrderList_ChangeWidth()
        {
            var totalWidth = 0;
            for (var i = 0; i < dgv_OrderList.Columns.Count; i++)
                if (dgv_OrderList.Columns[i].Visible)
                    totalWidth += dgv_OrderList.Columns[i].Width;
            dgv_OrderList.Width = totalWidth + 20;
        }

        private void tb_CodeText_Click(object sender, EventArgs e)
        {
            var list = new List<string>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT CodeText FROM Protocol.Description ORDER BY CodeText";
                var cmd = new SqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                    list.Add(reader[0].ToString());
            }

            var item = new Choose_Item(list, new Control[] { tb_CodeText }, false, false, true);
            item.ShowDialog();
        }
    }
}