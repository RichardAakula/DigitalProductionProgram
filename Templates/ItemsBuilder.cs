using DigitalProductionProgram.DatabaseManagement;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Templates;

namespace DigitalProductionProgram.Protocols.Template_Management
{
    public partial class ItemsBuilder : Form
    {
        public ItemsBuilder(string parameter, int descriptionID)
        {
            InitializeComponent();
            
            dgv_Items.Columns[0].HeaderText = parameter;
            Items.Initialize(dgv_Items, dgv_ListItems, tb_AddNewItem, descriptionID);
            Items.Load();
            btn_AddItem.Click += Items.AddItem_Click;
            LoadData();
        }

        public void LoadData()
        {
            dgv_Items.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT 
                        Item
                    FROM MeasureProtocol.ItemsList
                    WHERE MeasureProtocolMainTemplateID = @maintemplateid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = reader["Item"].ToString();
                        dgv_Items.Rows.Add(item);
                    }
                }
            }
        }

        private void ListItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var item = dgv_ListItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            dgv_Items.Rows.Add();
            dgv_Items.Rows[dgv_Items.Rows.Count - 1].Cells["col_Items"].Value = item;
            Items.SaveItem(item);
            tb_AddNewItem.Text = string.Empty;
        }
        public class Items
        {
            public static DataTable dt_Items;
            private static DataGridView dgv_Items;
            private static DataGridView dgv_ListItems;
            private static TextBox tb_Text;
            private static int DescriptionID { get; set; }

            public static void Initialize(DataGridView dgvItems, DataGridView dgvListItems, TextBox tbText, int descriptionID)
            {
                dgv_Items = dgvItems;
                dgv_ListItems = dgvListItems;
                tb_Text = tbText;
                DescriptionID = descriptionID;
            }
            
            public static void Load()
            {
                dt_Items = new DataTable();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT DISTINCT Item FROM MeasureProtocol.ItemsList ORDER BY Item";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    var dataAdapter = new SqlDataAdapter(query, con);
                    dataAdapter.Fill(dt_Items);
                    dgv_ListItems.DataSource = dt_Items;
                }

                dgv_ListItems.Columns[0].FillWeight = 100;
            }
            public static void AddItem_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(tb_Text.Text))
                    return;
                Items.Add(tb_Text.Text);
                Items.Load();
                SaveItem(tb_Text.Text);
                tb_Text.Text = string.Empty;
            }

            public static void SaveItem(string item)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                    IF NOT EXISTS (SELECT * FROM MeasureProtocol.ItemsList WHERE MeasureProtocolMainTemplateID = @maintemplateid AND Item = @items)
                    BEGIN
                        INSERT INTO MeasureProtocol.ItemsList (MeasureProtocolMainTemplateID, DescriptionID, Item)
                        VALUES (@maintemplateid, @descriptionid, @items)
                    END";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@items", SqlDbType.NVarChar).Value = item;
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                    cmd.Parameters.AddWithValue("@descriptionid", DescriptionID);
                    con.Open();
                    cmd.ExecuteScalar();
                }
            }
         
            private void SaveItems_Click(object sender, EventArgs e)
            {

            }
            public static void Add(string item)
            {
               // if (IsTaskExistInCategory(dgv_LineClearance_Active_Main, task))
                 //   return;
                dgv_Items.Rows.Add();
                dgv_Items.Rows[dgv_Items.Rows.Count - 1].Cells["col_Items"].Value = $"• {item}";

                Items.Load();
            }
        }

        private void SaveItems_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
