using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using static DigitalProductionProgram.Templates.Templates_Protocol;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace DigitalProductionProgram.Templates
{
    public partial class ItemsBuilder : Form
    {
        public enum ListType { MeasureProtocol, Protocol, Processcard }
        private ListType TypeOfList;
        private readonly IItemsProvider itemsProvider;
        public bool IsListActivated;
        public interface IItemsProvider
        {
            void Initialize(DataGridView dgvItems, DataGridView dgvListItems, TextBox tbText, int descriptionID, int templateID);
            void Load();
            void SaveItem(string item);
        }
        public ItemsBuilder(string parameter, int descriptionID, ListType listType, int templateID)
        {
            InitializeComponent();
            TypeOfList = listType;
            switch (listType)
            {
                case ListType.MeasureProtocol:
                    this.Text = @"List for Measureprotocol";
                    itemsProvider = new MeasureProtocolItems();
                    break;
                case ListType.Processcard:
                    this.Text = @"List for Processcards";
                    itemsProvider = new ProcesscardItems();
                    break;
                case ListType.Protocol:
                    this.Text = @"List for Protocols";
                    itemsProvider = new ProtocolItems();
                    break;
            }

            // Välj rätt provider
            //if (listType == ListType.MeasureProtocol)
            //    itemsProvider = new MeasureProtocolItems();
            //if (listType == ListType.Processcard)
            //    itemsProvider = new ProcesscardItems();
            //if (listType == ListType.Protocol)
            //    itemsProvider = new ProtocolItems();

            dgv_Items.Columns[0].HeaderText = parameter;
            itemsProvider.Initialize(dgv_Items, dgv_ListItems, tb_AddNewItem, descriptionID, templateID);
            itemsProvider.Load();
        }



        public class MeasureProtocolItems : IItemsProvider
        {
            private DataTable? dt_Items;
            private DataGridView? dgv_Items;
            private DataGridView? dgv_ListItems;
            private TextBox? tb_Text;
            private int DescriptionID;

            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, TextBox tbText, int descriptionID, int templateID)
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
            private DataGridView? dgv_Items;
            private DataGridView? dgv_ListItems;
            private TextBox? tb_Text;
            private int DescriptionID;
            private int TemplateID;


            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, TextBox tbText, int descriptionID, int templateID)
            {
                dgv_Items = dgvItems;
                dgv_ListItems = dgvListItems;
                tb_Text = tbText;
                DescriptionID = descriptionID;
                TemplateID = templateID;
            }

            public void Load()
            {
                Load_ListItems(dgv_Items, dgv_ListItems, "Protocol", TemplateID);
            }
            public void SaveItem(string item)
            {
                Save_ListItem(TemplateID, item, dgv_Items.Rows.Count, "Protocol");
            }
        }
        public class ProcesscardItems : IItemsProvider
        {
            private DataTable? dt_Items;
            private DataGridView? dgv_Items;
            private DataGridView? dgv_ListItems;
            private TextBox? tb_Text;
            private int DescriptionID;
            private int TemplateID;

            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, TextBox tbText, int descriptionID, int templateID)
            {
                dgv_Items = dgvItems;
                dgv_ListItems = dgvListItems;
                tb_Text = tbText;
                DescriptionID = descriptionID;
                TemplateID = templateID;
            }

            public void Load()
            {
                Load_ListItems(dgv_Items, dgv_ListItems, "Processcard", TemplateID);
            }

            public void SaveItem(string item)
            {
                Save_ListItem(TemplateID, item, dgv_Items.Rows.Count, "Processcard");
            }
        }




        public static List<string?>? GetListItems(int TemplateID, string ListType)
        {
            var items = new List<string>();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                SELECT ItemText 
                FROM List.ListItems 
                WHERE TemplateID = @templateID AND ListType = @listType
                ORDER BY ItemOrder";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@templateID", TemplateID);
            cmd.Parameters.AddWithValue("@listType", ListType);
            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var item = reader["ItemText"].ToString();
                if (item != null)
                    items.Add(item);
            }
            items.Add("N/A");
            return items;
        }
        private static void Load_ListItems(DataGridView dgv_Items, DataGridView dgv_ListItems, string ListType, int TemplateID)
        {
            dgv_ListItems.Rows.Clear();
            dgv_Items.Rows.Clear();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                SELECT DISTINCT ItemText, TemplateID, ItemOrder, ListType 
                FROM List.ListItems 
                ORDER BY TemplateID, ItemOrder";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@listType", ListType);
            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var item = reader["ItemText"].ToString();
                int.TryParse(reader["TemplateID"].ToString(), out var templateID);
                var listType = reader["ListType"].ToString();
                var exists = dgv_ListItems.Rows
                    .Cast<DataGridViewRow>()
                    .Any(r => r.Cells[0].Value?.ToString() == item);
                if (!exists && item != null)
                    dgv_ListItems.Rows.Add(item);
                if (TemplateID == templateID && listType == ListType)
                    dgv_Items.Rows.Add(item);
            }
        }
        private static void Save_ListItem(int TemplateID, string ItemText, int ItemOrder, string ListType)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();

            const string insertHeader = @"
                    INSERT INTO List.ListItems (TemplateID, ItemText, ItemOrder, Description, ListType, CreatedBy)
                    VALUES (@templateid, @itemtext, @itemorder, @description, @listtype, @createdby)";
            using var cmd = new SqlCommand(insertHeader, con);
            cmd.Parameters.AddWithValue("@templateid", TemplateID);
            cmd.Parameters.AddWithValue("@itemtext", ItemText);
            cmd.Parameters.AddWithValue("@itemorder", ItemOrder);
            cmd.Parameters.AddWithValue("@description", "");
            cmd.Parameters.AddWithValue("@listtype", ListType);
            cmd.Parameters.AddWithValue("@createdby", User.Person.Name);

            cmd.ExecuteScalar();
        }
        private void SaveItems_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void NewItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_AddNewItem.Text))
            {
                dgv_Items.Rows.Add(tb_AddNewItem.Text);
                itemsProvider.SaveItem(tb_AddNewItem.Text);
                itemsProvider.Load();
                tb_AddNewItem.Text = string.Empty;
            }
        }
        private void ItemList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var item = dgv_ListItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            //dgv_Items.Rows.Add(item);
            if (item != null) 
                itemsProvider.SaveItem(item);
            itemsProvider.Load();
        }
        private void ItemsBuilder_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsListActivated = dgv_Items.Rows.Count > 0;
        }

       
    }
}
