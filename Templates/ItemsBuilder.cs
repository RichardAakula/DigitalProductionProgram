using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Transactions;
using static DigitalProductionProgram.Templates.Templates_Protocol;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace DigitalProductionProgram.Templates
{
    public partial class ItemsBuilder : Form
    {
        public enum ListType { MeasureProtocol, Protocol, Processcard }
        private ListType TypeOfList;
        private string listType;
        private readonly int TemplateID;
        private readonly IItemsProvider? itemsProvider;
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
            IsListActivated = false;
            TypeOfList = listType;
            this.listType = listType.ToString();
            TemplateID = templateID;
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


            label_CodeText.Text = parameter;
            itemsProvider?.Initialize(dgv_Items, dgv_ListItems, tb_AddNewItem, descriptionID, templateID);
            itemsProvider?.Load();
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
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
            private int DescriptionID;
            private int TemplateID;


            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, TextBox tbText, int descriptionID, int templateID)
            {
                dgv_Items = dgvItems;
                dgv_ListItems = dgvListItems;
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
            private int DescriptionID;
            private int TemplateID;

            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, TextBox tbText, int descriptionID, int templateID)
            {
                dgv_Items = dgvItems;
                dgv_ListItems = dgvListItems;
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
                SELECT ItemText, EndPoint, PropertyName, FilterExpression 
                FROM List.ListItems 
                WHERE TemplateID = @templateID AND ListType = @listType
                ORDER BY ItemOrder";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@templateID", TemplateID);
            cmd.Parameters.AddWithValue("@listType", ListType);
            con.Open();
            using var reader = cmd.ExecuteReader();
            string endPoint = null;
            string columnName = null;
            string filter = null;
            while (reader.Read())
            {
                var item = reader["ItemText"].ToString();
                if (item != null)
                    items.Add(item);

                endPoint = reader["EndPoint"].ToString();
                columnName = reader["PropertyName"].ToString();
                filter = reader["FilterExpression"].ToString();
            }
            items.Add("N/A");
            string typeName = $"DigitalProductionProgram.Monitor.GET.{endPoint}, DigitalProductionProgram";
            Type tableType = Type.GetType(typeName);
            if (tableType != null)
                Monitor.Services.ToolService.Add_Equipment(items, tableType, "EXTRUDER", columnName, filter);

            return items;
        }
        private static void Load_ListItems(DataGridView dgv_Items, DataGridView dgv_ListItems, string ListType, int TemplateID)
        {
            dgv_ListItems.Rows.Clear();
            dgv_Items.Rows.Clear();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                SELECT DISTINCT ListID, ItemText, TemplateID, ItemOrder, ListType 
                FROM List.ListItems 
                ORDER BY TemplateID, ItemOrder";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@listType", ListType);
            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader["ListID"].ToString();
                var item = reader["ItemText"].ToString();
                int.TryParse(reader["TemplateID"].ToString(), out var templateID);
                var listType = reader["ListType"].ToString();
                var exists = dgv_ListItems.Rows
                    .Cast<DataGridViewRow>()
                    .Any(r => r.Cells[0].Value?.ToString() == item);
                if (!exists && item != null)
                    dgv_ListItems.Rows.Add(item);
                if (TemplateID == templateID && listType == ListType)
                    dgv_Items.Rows.Add(id, item);
            }
        }
        private static void Save_ListItem(int TemplateID, string ItemText, int ItemOrder, string ListType)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();

            const string query = @"
                    INSERT INTO List.ListItems (TemplateID, ItemText, ItemOrder, ListType, CreatedBy)
                    SELECT @templateid, @itemtext, @itemorder, @listtype, @createdby
                    WHERE NOT EXISTS 
                    (
                        SELECT 1 
                        FROM List.ListItems 
                        WHERE TemplateID = @templateid 
                        AND ItemText = @itemtext
                        AND ListType = @listtype
                    );";
            using var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@templateid", TemplateID);
            cmd.Parameters.AddWithValue("@itemtext", ItemText);
            cmd.Parameters.AddWithValue("@itemorder", ItemOrder);
            cmd.Parameters.AddWithValue("@listtype", ListType);
            cmd.Parameters.AddWithValue("@createdby", User.Person.Name);

            cmd.ExecuteScalar();
        }

        private void Save_MonitorFilter()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();

            const string query = @"
                    INSERT INTO List.ListItems (TemplateID, EndPoint, PropertyName, FilterExpression, ListType, CreatedBy)
                    SELECT @templateid, @endpoint, @propertyname, @filterexpression, @listtype, @createdby
                    WHERE NOT EXISTS 
                    (
                        SELECT 1 
                        FROM List.ListItems 
                        WHERE TemplateID = @templateid 
                        AND EndPoint = @endpoint
                        AND PropertyName = @propertyname
                        AND FilterExpression = @filterexpression
                    );";
            using var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@templateid", TemplateID);
            cmd.Parameters.AddWithValue("@endpoint", $"{cb_Module.Text}+{cb_Resource.Text}");
            cmd.Parameters.AddWithValue("@propertyname", cb_Column.Text);
            cmd.Parameters.AddWithValue("@filterexpression", queryBuilder);
            cmd.Parameters.AddWithValue("@listtype", listType);
            cmd.Parameters.AddWithValue("@createdby", User.Person.Name);

            cmd.ExecuteScalar();
        }

        private string queryBuilder
        {
            get
            {
                string query = "filter=";
                switch (cb_FilterFunctions.Text)
                {
                    case "startswith":
                        query += $"startswith({cb_FilterColumn.Text}, '{tb_FilterText.Text}')";
                        break;
                }
                return query;
            }
        }
        public static void Copy_ListItemsToNewTemplate(int oldMainTemplateID, int newMainTemplateID)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"SELECT ID, ProtocolDescriptionID FROM Protocol.Template WHERE FormTemplateID IN (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @oldmaintemplateid)";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@oldmaintemplateid", oldMainTemplateID);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int.TryParse(reader["ID"].ToString(), out var templateID);
                int.TryParse(reader["ProtocolDescriptionID"].ToString(), out var protocolDescriptionID);

                using var con2 = new SqlConnection(Database.cs_Protocol);
                const string query2 = @"SELECT ItemText, ItemOrder, ListType FROM List.ListItems WHERE TemplateID = @templateID";
                var cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@templateID", templateID);
                con2.Open();
                var reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    var itemText = reader2["ItemText"].ToString();
                    int.TryParse(reader2["ItemOrder"].ToString(), out var itemOrder);
                    var listType = reader2["ListType"].ToString();
                    using var con3 = new SqlConnection(Database.cs_Protocol);
                    const string query3 = @"SELECT TOP(1) ID 
                                FROM Protocol.Template 
                                WHERE ProtocolDescriptionID = @protocolDescriptionID
                                AND FormTemplateID IN (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @newMainTemplateID)
                                ORDER BY ID";
                    var cmd3 = new SqlCommand(query3, con3);
                    cmd3.Parameters.AddWithValue("@protocolDescriptionID", protocolDescriptionID);
                    cmd3.Parameters.AddWithValue("@newMainTemplateID", newMainTemplateID);
                    con3.Open();
                    var result = cmd3.ExecuteScalar(); // hämtar första kolumnen i första raden
                    int.TryParse(result?.ToString(), out var newTemplateID);

                    Save_ListItem(newTemplateID, itemText, itemOrder, listType);
                }
            }

        }


        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (dgv_Items.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_Items.SelectedRows[0];
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();

                const string query = @"
                    DELETE FROM List.ListItems 
                    WHERE ListID = @id";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", selectedRow.Cells["col_ID"].Value.ToString());

                cmd.ExecuteScalar();
            }
            dgv_Items.Rows.RemoveAt(dgv_Items.SelectedRows[0].Index);
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

            if (item != null)
                itemsProvider.SaveItem(item);
            itemsProvider.Load();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Save_MonitorFilter(); 

            this.Close();
        }
        private void ItemsBuilder_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsListActivated = dgv_Items.Rows.Count > 0;
        }

        private void cb_Module_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_Module.Text)
            {
                case "Inventory":
                    cb_Resource.Items.Add("Parts");
                    break;
            }
        }
        private void cb_Resource_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_Resource.Text)
            {
                case "Inventory":
                    cb_Column.Items.Add("PartNumber");
                    cb_Column.Items.Add("Description");
                    break;
            }
        }
    }
}
