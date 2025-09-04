using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace DigitalProductionProgram.Templates
{
    public partial class ItemsBuilder : Form
    {
        public enum ListType { MeasureProtocol, Protocol, Processcard }
        private ListType TypeOfList;
        private readonly IItemsProvider itemsProvider;

        public interface IItemsProvider
        {
            void Initialize(DataGridView dgvItems, DataGridView dgvListItems, TextBox tbText, int descriptionID, int? templateID = null);
            void Load();
            void SaveItem(string item);
            void LoadData();
        }



        public class MeasureProtocolItems : IItemsProvider
        {
            private DataTable? dt_Items;
            private DataGridView? dgv_Items;
            private DataGridView? dgv_ListItems;
            private TextBox? tb_Text;
            private int DescriptionID;

            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, TextBox tbText, int descriptionID, int? templateID = null)
            {
                dgv_Items = dgvItems;
                dgv_ListItems = dgvListItems;
                tb_Text = tbText;
                DescriptionID = descriptionID;
                dgv_ListItems.CellMouseDown += ListItems_CellMouseDown;
            }

            public void LoadData()
            {
                dgv_Items.Rows.Clear();
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
            SELECT 
                Item
            FROM MeasureProtocol.ItemsList
            WHERE MeasureProtocolMainTemplateID = @maintemplateid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                con.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var item = reader["Item"].ToString();
                    dgv_Items.Rows.Add(item);
                }
            }
            public void Load()
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
            public void SaveItem(string item)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
            IF NOT EXISTS (SELECT * FROM MeasureProtocol.ItemsList WHERE MeasureProtocolMainTemplateID = @maintemplateid AND Item = @items)
            BEGIN
                INSERT INTO MeasureProtocol.ItemsList (MeasureProtocolMainTemplateID, DescriptionID, Item)
                VALUES (@maintemplateid, @descriptionid, @items)
            END";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@items", SqlDbType.NVarChar).Value = item;
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                cmd.Parameters.AddWithValue("@descriptionid", DescriptionID);
                con.Open();
                cmd.ExecuteScalar();
            }

            public void Add(string item)
            {
                dgv_Items.Rows.Add();
                dgv_Items.Rows[^1].Cells["col_Items"].Value = $"• {item}";
                Load();
            }
            public void ListItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.RowIndex < 0)
                    return;
                var item = dgv_ListItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                dgv_Items.Rows.Add();
                dgv_Items.Rows[^1].Cells["col_Items"].Value = item;
                SaveItem(item);
                tb_Text.Text = string.Empty;
            }
        }
        public class ProtocolItems : IItemsProvider
        {
           
            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, TextBox tbText, int descriptionID, int? templateID) { /* ... */ }
            public void Load() { /* ... */ }
            public void SaveItem(string item) { /* ... */ }
            public void LoadData() { /* ... */ }
        }
        public class ProcesscardItems : IItemsProvider
        {
            private DataTable? dt_Items;
            private DataGridView? dgv_Items;
            private DataGridView? dgv_ListItems;
            private TextBox? tb_Text;
            private int DescriptionID;
            private int? TemplateID;

            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, TextBox tbText, int descriptionID, int? templateID)
            {
                dgv_Items = dgvItems;
                dgv_ListItems = dgvListItems;
                tb_Text = tbText;
                DescriptionID = descriptionID;
                TemplateID = templateID;
            }

            public void Load()
            {
                dgv_Items.Rows.Clear();
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
            SELECT 
                ItemText
            FROM List.ListItem
            WHERE ListID = @listid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@listid", 1);
                con.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var item = reader["Item"].ToString();
                    dgv_Items.Rows.Add(item);
                }
            }

            public void SaveItem(string item)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();

                int listId;

                // 1. Spara header och få tillbaka ListID
                const string insertHeader = @"
                    INSERT INTO List.ListHeader (TemplateID, ListName, Description, ListType, CreatedBy)
                    OUTPUT INSERTED.ListID
                    VALUES (@templateid, @listname, @description, @listtype, @createdby)";
                using (var cmd = new SqlCommand(insertHeader, con))
                {
                    cmd.Parameters.AddWithValue("@templateid", TemplateID);
                    cmd.Parameters.AddWithValue("@listname", tb_Text.Text);
                    cmd.Parameters.AddWithValue("@description", "");
                    cmd.Parameters.AddWithValue("@listtype", "Processcard");
                    cmd.Parameters.AddWithValue("@createdby", User.Person.Name);

                    listId = (int)cmd.ExecuteScalar();
                }

                // 2. Spara item som hör till listan
                const string insertItem = @"
                    INSERT INTO List.ListItem (ListID, ItemOrder, ItemText)
                    VALUES (@listid, @itemorder, @itemtext)";
                using (var cmd = new SqlCommand(insertItem, con))
                {
                    cmd.Parameters.AddWithValue("@listid", listId);
                    cmd.Parameters.AddWithValue("@itemorder", dgv_Items.CurrentCell.RowIndex);   // eller generera dynamiskt om du vill
                    cmd.Parameters.AddWithValue("@itemtext", item);

                    cmd.ExecuteNonQuery();
                }
            }
            public void LoadData() { /* ... */ }
        }


        public ItemsBuilder(string parameter, int descriptionID, ListType listType, int? templateID = null)
        {
            InitializeComponent();
            TypeOfList = listType;
            switch (listType)
            {
                case ListType.MeasureProtocol:
                    this.Text = @"List for Measureprotocol";
                    break;
                case ListType.Processcard:
                    this.Text = @"List for Processcards";
                    break;
                case ListType.Protocol:
                    this.Text = @"List for Protocols";
                    break;
            }

            // Välj rätt provider
            if (listType == ListType.MeasureProtocol)
                itemsProvider = new MeasureProtocolItems();
                
            else
                itemsProvider = new ProtocolItems();

            dgv_Items.Columns[0].HeaderText = parameter;
            itemsProvider.Initialize(dgv_Items, dgv_ListItems, tb_AddNewItem, descriptionID);
            itemsProvider.Load();
            btn_AddItem.Click += (s, e) => {
                // Lägg till logik för att hämta text och spara
                if (!string.IsNullOrEmpty(tb_AddNewItem.Text))
                {
                    itemsProvider.SaveItem(tb_AddNewItem.Text);
                    itemsProvider.Load();
                    tb_AddNewItem.Text = string.Empty;
                }
            };
        }

      

       

        private void SaveItems_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
