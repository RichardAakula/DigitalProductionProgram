using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Transactions;
using System.Windows.Forms;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;
using TradeWright.UI.Forms;
using static DigitalProductionProgram.Templates.Templates_Protocol;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace DigitalProductionProgram.Templates
{
    public partial class ItemsBuilder : Form
    {
        public enum ListType { MeasureProtocol, Protocol, Processcard }
        private ListType TypeOfList;
        private readonly string listType;
        private readonly int TemplateID;
        private static int ItemsFieldId;
        private static List<string> ListCodetext = new();
        private readonly IItemsProvider? itemsProvider;
        public bool IsListActivated;
        public interface IItemsProvider
        {
            void Initialize(DataGridView dgvItems, DataGridView dgvListItems, ComboBox cbPartCode, ComboBox cbName, ComboBox cbSecondaryName, ComboBox cbProperties, ComboBox cbFilterCodeText, ComboBox cbSecondaryCodeText, TextBox tbText, int templateID);
            void Load();
            void SaveItem(string item);
        }




        public ItemsBuilder(string parameter, ListType listType, int templateID, List<string> listCodetext = null)
        {
            InitializeComponent();

            IsListActivated = false;
            TypeOfList = listType;
            this.listType = listType.ToString();
            TemplateID = templateID;
            ListCodetext = listCodetext;
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
            itemsProvider?.Initialize(dgv_Items, dgv_ListItems, cb_PartCode, cb_Name,  cb_SecondaryName, cb_Properties, cb_FilterCodeText, cb_SecondaryCodeText, tb_AddNewItem,  templateID);
            
            if (dgv_Items.Rows.Count > 0)
                tab_Main.SelectedTab = tab_Main.TabPages[0];
            else
                tab_Main.SelectedTab = tab_Main.TabPages[1];

        }
        private async void ItemsBuilder_Load(object sender, EventArgs e)
        {
            tab_Main.DrawMode = TabDrawMode.OwnerDrawFixed;
            tab_Main.DrawItem += TabControl1_DrawItem;
            tab_Main.ItemSize = new Size(150, 60);
            tab_Main.Paint += TabControl1_Paint;

            var list = await Monitor.Monitor.Get_PropertyList();

            // Använd samma data i två comboboxar (men separata instanser!)
            cb_Name.DataSource = new List<Common.ExtraFieldTemplates>(list);
            cb_Name.DisplayMember = "Name";
            cb_Name.ValueMember = "Name";
            cb_Name.SelectedIndex = - 1;

            cb_SecondaryName.DataSource = new List<Common.ExtraFieldTemplates>(list);
            cb_SecondaryName.DisplayMember = "Name";
            cb_SecondaryName.ValueMember = "Name";
            cb_SecondaryName.SelectedIndex = -1;

            await Monitor.Monitor.Fill_ComboBox_PartCodes(cb_PartCode);
            cb_PartCode.SelectedIndex = -1;
            Fill_ComboBox_FilterColumns(cb_FilterCodeText, ListCodetext);
            Fill_ComboBox_FilterColumns(cb_SecondaryCodeText, ListCodetext);

            itemsProvider?.Load();
        }
        private void TabControl1_DrawItem(object? sender, DrawItemEventArgs e)
        {
            var tabControl = (TabControl)sender!;
            tabControl.BackColor = Color.Red;
            var tabPage = tabControl.TabPages[e.Index];
            var rect = e.Bounds;

            // Bestäm bakgrund beroende på om fliken är vald
            Color backColor = (e.State.HasFlag(DrawItemState.Selected))
                ? CustomColors.Parmesan_Font   // vald flik
                : CustomColors.Teal;     // ovalda flikar

            using (var brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            // Rita texten (större font)
            using (var font = new Font("Segoe UI", 14, FontStyle.Bold)) // Ändra storlek här
            using (var textBrush = new SolidBrush(Color.FromArgb(184, 220, 231)))
            {
                var stringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                e.Graphics.DrawString(tabPage.Text, font, textBrush, rect, stringFormat);
            }

            e.DrawFocusRectangle();
        }
        private void TabControl1_Paint(object? sender, PaintEventArgs e)
        {
            var tabControl = (TabControl)sender!;

            // Måla bakgrunden bakom flikarna
            Rectangle tabBackground = tabControl.DisplayRectangle;
            tabBackground.Inflate((Size)tabControl.Padding);

            using var brush = new SolidBrush(CustomColors.Parmesan_Font); // din bakgrundsfärg
            e.Graphics.FillRectangle(brush, tabControl.ClientRectangle);
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

            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, ComboBox cbPartCode, ComboBox cbName, ComboBox cbSecondaryName, ComboBox cbProperties, ComboBox cbFilterCodeText, ComboBox cbSecondaryCodeText, TextBox tbText, int templateID)
            {
                dgv_Items = dgvItems;
                dgv_ListItems = dgvListItems;
                tb_Text = tbText;
                dgv_ListItems.CellMouseDown += ListItems_CellMouseDown;
            }

            public void LoadData()
            {
                dgv_Items.Rows.Clear();
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
                SELECT Item
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
            private ComboBox? cb_PartCode;
            private ComboBox? cb_Name;
            private ComboBox? cb_SecondaryName;
            private ComboBox? cb_Properties;
            private ComboBox? cb_FilterCodeText;
            private ComboBox? cb_SecondaryCodeText;
            private int TemplateID;


            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, ComboBox cbPartCode, ComboBox cbName, ComboBox cbSecondaryName, ComboBox cbProperties, ComboBox cbFilterCodeText, ComboBox cbSecondaryCodeText, TextBox tbText,  int templateID)
            {
                dgv_Items = dgvItems;
                dgv_ListItems = dgvListItems;
                cb_PartCode = cbPartCode;
                cb_Name = cbName;
                cb_SecondaryName = cbSecondaryName;
                cb_Properties = cbProperties;
                cb_FilterCodeText = cbFilterCodeText;
                cb_SecondaryCodeText = cbSecondaryCodeText;
                TemplateID = templateID;
            }

            public void Load()
            {
                Load_ListItems(dgv_Items, dgv_ListItems, cb_PartCode, cb_Name, cb_SecondaryName, cb_Properties, cb_FilterCodeText, cb_SecondaryCodeText, "Protocol", TemplateID);
            }
            public void SaveItem(string item)
            {
                Save_ListItem(TemplateID, item, dgv_Items.Rows.Count, "Protocol");
            }
        }
        public class ProcesscardItems : IItemsProvider
        {
            private DataGridView? dgv_Items;
            private DataGridView? dgv_ListItems;
            private ComboBox? cb_PartCode;
            private ComboBox? cb_Name;
            private ComboBox? cb_SecondaryName;
            private ComboBox? cb_Properties;
            private ComboBox? cb_FilterCodeText;
            private ComboBox? cb_SecondaryCodeText;
            private int TemplateID;

            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, ComboBox cbPartCode, ComboBox cbName, ComboBox cbSecondaryName, ComboBox cbProperties, ComboBox cbFilterCodeText, ComboBox cbSecondaryCodeText, TextBox tbText,  int templateID)
            {
                dgv_Items = dgvItems;
                dgv_ListItems = dgvListItems;
                cb_PartCode = cbPartCode;
                cb_Name = cbName;
                cb_SecondaryName = cbSecondaryName;
                cb_Properties = cbProperties;
                cb_FilterCodeText = cbFilterCodeText;
                cb_SecondaryCodeText = cbSecondaryCodeText;
                TemplateID = templateID;
            }

            public void Load()
            {
                Load_ListItems(dgv_Items, dgv_ListItems, cb_PartCode, cb_Name, cb_SecondaryName , cb_Properties, cb_FilterCodeText, cb_SecondaryCodeText, "Processcard", TemplateID);
            }
            public void SaveItem(string item)
            {
                Save_ListItem(TemplateID, item, dgv_Items.Rows.Count, "Processcard");
            }
        }





        public static async Task<(List<string?> Items, bool IsItemsMultipleColumns, List<string> Cells_CodeText)> GetListItems(int TemplateID, string ListType, int dataType, Func<string, string?>? filterVariable = null)
        {
            bool isMultipleColumns = false;
            var items = new List<string>();
            var cells_CodeText = new List<string>();
            await using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                SELECT items.Name as ItemName, PartCode, EndPoint, Property, fields.Name, SecondaryName, FilterCodeText, SecondaryCodeText
                FROM List.ItemFields as fields
                    LEFT JOIN List.Items as items 
                        ON fields.ItemId = items.Id
                WHERE TemplateID = @templateID AND ListType = @listType
                ORDER BY ItemOrder";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@templateID", TemplateID);
            cmd.Parameters.AddWithValue("@listType", ListType);
            con.Open();
            await using var reader = await cmd.ExecuteReaderAsync();
            string? endPoint = null;
            string? name = null;
            string? secondaryName = null;
            string? property = null;
            string? partCode = null;
            string? filterCodeText = null;
            string? secondaryCodeText = null;

            while (reader.Read())
            {
                var item = reader["ItemName"]?.ToString();
                if (item != null)
                    items.Add(item);

                partCode = reader["PartCode"] as string ?? reader["PartCode"]?.ToString();
                endPoint = reader["EndPoint"] as string ?? reader["EndPoint"]?.ToString();
                property = reader["Property"] as string ?? reader["Property"]?.ToString();
                name = reader["Name"] as string ?? reader["Name"]?.ToString();
                secondaryName = reader["SecondaryName"] as string ?? reader["SecondaryName"]?.ToString();
                filterCodeText = reader["FilterCodeText"] as string ?? reader["FilterCodeText"]?.ToString();
                secondaryCodeText = reader["SecondaryCodeText"] as string ?? reader["SecondaryCodeText"]?.ToString();
            }
            
            if (!string.IsNullOrEmpty(secondaryCodeText))
                cells_CodeText.Add(secondaryCodeText);

            items.Add("N/A");
            var variable = filterVariable?.Invoke(filterCodeText);
            if (!string.IsNullOrEmpty(secondaryCodeText))
                isMultipleColumns = true;

            var typeName = endPoint != null ? $"DigitalProductionProgram.Monitor.GET.{endPoint}, DigitalProductionProgram" : null;
            var tableType = typeName != null ? Type.GetType(typeName) : null;
            if (tableType != null && partCode != null)
                await Monitor.Services.ToolService.Add_Equipment(items, tableType, partCode, name, property, variable, dataType, isMultipleColumns, secondaryName, secondaryCodeText);

            return (items, isMultipleColumns, cells_CodeText);
        }

        private static void Load_ListItems(DataGridView dgv_Items, DataGridView dgv_ListItems, ComboBox cb_PartCode, ComboBox cb_Name, ComboBox cb_SecondaryName, ComboBox cb_Properties, ComboBox cb_FilterCodeText, ComboBox cb_SecondaryCodeText, string ListType, int TemplateID)
        {
            dgv_ListItems.Rows.Clear();
            dgv_Items.Rows.Clear();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query =
                @"
                SELECT DISTINCT Id, items.Name, TemplateID, ItemOrder, ListType 
                FROM List.Items as items
                JOIN List.ItemFields as fields 
                    ON items.Id = fields.ItemID
                WHERE ListType = @listType
                ORDER BY TemplateID, ItemOrder";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@listType", ListType);
            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader["Id"].ToString();
                var item = reader["Name"].ToString();
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

            Load_MonitorList(cb_PartCode, cb_Name, cb_SecondaryName, cb_Properties, cb_FilterCodeText, cb_SecondaryCodeText, TemplateID, ListType);
        }

        private static void Load_MonitorList(ComboBox cb_PartCode, ComboBox cb_Name, ComboBox cb_SecondaryName, ComboBox cb_Property, ComboBox cb_FilterCodeText, ComboBox cb_SecondaryCodeText, int templateID, string listType)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query =
                @"
                SELECT ItemFieldsId, PartCode, Property, Name, SecondaryName, FilterCodeText, SecondaryCodeText
                FROM List.ItemFields 
                WHERE TemplateID = @templateID AND ListType = @listType
                ORDER BY TemplateID, ItemOrder";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@listType", listType);
            cmd.Parameters.AddWithValue("@templateid", templateID);
            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ItemsFieldId = reader["ItemFieldsId"] != DBNull.Value ? Convert.ToInt32(reader["ItemFieldsId"]) : 0;
                cb_PartCode.SelectedValue = reader["PartCode"].ToString();
                cb_Name.SelectedValue = reader["Name"].ToString();
                cb_SecondaryName.SelectedValue = reader["SecondaryName"].ToString();
                cb_Property.SelectedItem = reader["Property"].ToString();
                cb_FilterCodeText.SelectedItem = reader["FilterCodeText"].ToString();
                cb_SecondaryCodeText.SelectedItem = reader["SecondaryCodeText"].ToString();
            }
        }

        private static void Save_ListItem(int templateID, string itemText, int itemOrder, string listType)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();

            using var tran = con.BeginTransaction();

            // 1. Lägg till i List.Items om det inte redan finns, och hämta ID:t
            var getItemIdQuery = @"
                IF NOT EXISTS (SELECT 1 FROM List.Items WHERE Name = @itemtext)
                BEGIN
                    INSERT INTO List.Items (Name, Description, CreatedBy)
                    VALUES (@itemtext, @description, @createdby);
                    SELECT SCOPE_IDENTITY();
                END
                ELSE
                BEGIN
                    SELECT Id FROM List.Items WHERE Name = @itemtext;
                END";

            int itemId;
            using (var cmd = new SqlCommand(getItemIdQuery, con, tran))
            {
                cmd.Parameters.AddWithValue("@itemtext", itemText);
                cmd.Parameters.AddWithValue("@description", DBNull.Value);
                cmd.Parameters.AddWithValue("@createdby", User.Person.Name);

                itemId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // 2. Lägg till i List.ItemFields om kopplingen inte redan finns
            var insertFieldQuery = @"
                IF NOT EXISTS 
                (
                    SELECT 1 FROM List.ItemFields 
                    WHERE ItemId = @itemid AND TemplateID = @templateid AND ListType = @listtype
                )
                BEGIN
                    INSERT INTO List.ItemFields (ItemId, TemplateID, ListType, ItemOrder, CreatedBy)
                    VALUES (@itemid, @templateid, @listtype, @itemorder, @createdby);
                END";

            using (var cmd = new SqlCommand(insertFieldQuery, con, tran))
            {
                cmd.Parameters.AddWithValue("@itemid", itemId);
                cmd.Parameters.AddWithValue("@templateid", templateID);
                cmd.Parameters.AddWithValue("@listtype", listType);
                cmd.Parameters.AddWithValue("@itemorder", itemOrder);
                cmd.Parameters.AddWithValue("@createdby", User.Person.Name);

                cmd.ExecuteNonQuery();
            }

            tran.Commit();
        }

        private void Save_MonitorList(int templateID)
        {
           

            if (dgv_Items.Rows.Count > 0)
                return;

            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();

            const string query = @"
                IF EXISTS 
                (
                    SELECT 1 FROM List.ItemFields
                    WHERE TemplateID = @templateid AND ListType = @listtype
                )
                BEGIN
                    UPDATE List.ItemFields
                    SET PartCode = @partcode,
                        EndPoint = @endpoint,
                        Property = @property,                        
                        Name = @name,
                        SecondaryName = @secondaryname,
                        FilterCodeText = @filtercodetext,
                        SecondaryCodeText = @secondarycodetext,
                        ModifiedBy = @username,
                        ModifiedDate = GETDATE()
                    WHERE ItemFieldsId = @id
                END
                ELSE
                BEGIN
                    INSERT INTO List.ItemFields (TemplateID, PartCode, EndPoint, Property, Name, SecondaryName, FilterCodeText, SecondaryCodeText, ListType, CreatedBy)
                    VALUES (@templateid, @partcode, @endpoint, @property, @name, @secondaryname, @filtercodetext, @secondarycodetext, @listtype, @username)
                 END";

            using var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", ItemsFieldId);
            cmd.Parameters.AddWithValue("@templateid", templateID);
            cmd.Parameters.AddWithValue("@partcode", cb_PartCode.SelectedValue?.ToString());
            cmd.Parameters.AddWithValue("@endpoint", "Inventory+Parts");
            SQL_Parameter.String(cmd.Parameters, "@property", cb_Properties.SelectedItem?.ToString());
            SQL_Parameter.String(cmd.Parameters, "@name", cb_Name.SelectedValue?.ToString());
            SQL_Parameter.String(cmd.Parameters, "@secondaryname", cb_SecondaryName.SelectedValue?.ToString());
            SQL_Parameter.String(cmd.Parameters, "@filtercodetext", cb_FilterCodeText.SelectedItem?.ToString());
            SQL_Parameter.String(cmd.Parameters, "@secondarycodetext", cb_SecondaryCodeText.SelectedItem?.ToString());
            cmd.Parameters.AddWithValue("@listtype", listType);
            cmd.Parameters.AddWithValue("@username", User.Person.Name);

            cmd.ExecuteNonQuery();
        }
        private void CheckForTemplatesToUpdate()
        {
            ItemsFieldId = 0;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"SELECT ProtocolDescriptionID FROM Protocol.Template WHERE ID = @templateid";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@templateid", TemplateID);
            con.Open();

            var result = cmd.ExecuteScalar()?.ToString();
            int.TryParse(result, out var protocolDescriptionId);

            using var con2 = new SqlConnection(Database.cs_Protocol);
            query = @"
                SELECT Name, Revision, ID
                FROM Protocol.MainTemplate 
                WHERE ID IN 
                (
                    SELECT MainTemplateID 
                    FROM Protocol.FormTemplate 
                    WHERE FormTemplateID IN 
                    (
                        SELECT FormTemplateID 
                        FROM Protocol.Template 
                        WHERE ProtocolDescriptionID = @protocoldescriptionid 
                            AND NOT EXISTS 
                            (
                                SELECT 1 
                                FROM List.ItemFields 
                                WHERE TemplateID = Protocol.Template.ID
                                AND ListType = @listtype
                            )
                    )
                )";
            var cmd2 = new SqlCommand(query, con2);
            cmd2.Parameters.AddWithValue("@protocoldescriptionid", protocolDescriptionId);
            cmd2.Parameters.AddWithValue("@listtype", listType);
            con2.Open();

            var reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                var name = reader2["Name"].ToString();
                var revision = reader2["Revision"].ToString();
                int.TryParse(reader2["ID"].ToString(), out var mainTemplateID);
                InfoText.Question($"{name} - Revision {revision} har också fältet {label_CodeText.Text} i mallen.\n" +
                                 $"Vill du koppla listan till denna mall?", CustomColors.InfoText_Color.Ok, "", this);
                if (InfoText.answer == InfoText.Answer.Yes)
                {
                    var newTemplateID = NewTemplateID(mainTemplateID, protocolDescriptionId);
                    foreach (var newTemplateIDItem in newTemplateID)
                        if (newTemplateIDItem != 0)
                            Save_MonitorList(newTemplateIDItem);
                        else
                            InfoText.Question($"Det gick inte att hitta en mall att koppla mot, kontakta Admin!", CustomColors.InfoText_Color.Bad, "WARNING!", this);
                }

            }
        }
        private List<int> NewTemplateID(int mainTemplateID, int protocolDescriptionID)
        {
            var list = new List<int>();
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                SELECT ID 
                FROM Protocol.Template 
                WHERE ProtocolDescriptionID = @protocolDescriptionID
                    AND FormTemplateID IN (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @newMainTemplateID)";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@protocolDescriptionID", protocolDescriptionID);
            cmd.Parameters.AddWithValue("@newMainTemplateID", mainTemplateID);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int.TryParse(reader["ID"].ToString(), out var templateID);
                list.Add(templateID);
            }
            return list;
        }

        
        public static void Copy_OwnListToNewTemplate(int oldMainTemplateID, int newMainTemplateID)
        {
            //Osäker att detta funkar?
            //Det funkade inte när jag skapade en ny revision av Extrudering Tryck
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

        public void Fill_ComboBox_FilterColumns(ComboBox comboBox, List<string> listCodeText)
        {
            comboBox.Items.Clear();
            var localList = new List<string>(listCodeText);

            // Lägg till alla värden i den lokala listan
            foreach (var codeText in localList)
                comboBox.Items.Add(codeText);
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (dgv_Items.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_Items.SelectedRows[0];
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();

                const string query = @"
                    DELETE FROM List.ItemFields 
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
            if (string.IsNullOrEmpty(cb_PartCode.SelectedValue?.ToString()))
            {
                InfoText.Show("Du måste fylla i Typ av Verktyg för du sparar.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                cb_PartCode.Focus();
                return;
            }
            Save_MonitorList(TemplateID);
            CheckForTemplatesToUpdate();

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
                    cb_Properties.Items.Add("Parts");
                    break;
            }
        }
       

        
    }
}
