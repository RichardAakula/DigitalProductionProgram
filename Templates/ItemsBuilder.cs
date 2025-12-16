using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Transactions;
using System.Windows.Forms;
using DigitalProductionProgram.Equipment;
using OpenTK.Platform.MacOS;
using TradeWright.UI.Forms;
using static DigitalProductionProgram.Templates.Templates_Protocol;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace DigitalProductionProgram.Templates
{
    public partial class ItemsBuilder : Form
    {
        public enum ListType { None, MeasureProtocol, Protocol, Processcard }
        public ListType TypeOfList;
        public string listType;
        private readonly int ProtocolDescriptionId;
        // private readonly List<int> List_TemplateID;
        private static int ItemsFieldId;
        private static List<string> ListCodetext = new();
        private readonly IItemsProvider? itemsProvider;
        public static bool IsListActivated;

        public interface IItemsProvider
        {
            void Initialize(DataGridView dgvItems, DataGridView dgvListItems, ComboBox cbPartCode, ComboBox cbName, ComboBox cbSecondaryName, ComboBox cbProperties, ComboBox cbFilterCodeText, ComboBox cbSecondaryCodeText, ComboBox cbSortMode, TextBox tbText, int protocolDescriptionId);
            // void Load();
            // void SaveItem(string item);
        }




        public ItemsBuilder(string parameter, ListType listType, int protocolDescriptionId, List<string> listCodetext = null)
        {
            InitializeComponent();

            IsListActivated = false;

            ProtocolDescriptionId = protocolDescriptionId;
            // List_TemplateID = list_templateID;
            ListCodetext = listCodetext;

            if (listType == ListType.None)
            {
                InfoText.Question("Vill du editera listor för Processkort eller Körprotokoll?", CustomColors.InfoText_Color.Info, "Edit Lists", this, false, ["Processcard", "Protocol"]);
                if (InfoText.answer == InfoText.Answer.Yes)
                    listType = ListType.Processcard;
                else
                    listType = ListType.Protocol;
            }
            this.listType = listType.ToString();
            tb_ListType.Text = listType.ToString();
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


            label_CodeText.Text = parameter;
            itemsProvider?.Initialize(dgv_Items, dgv_ListItems, cb_PartCode, cb_Name, cb_SecondaryName, cb_Properties, cb_FilterCodeText, cb_SecondaryCodeText, cb_SortMode, tb_AddNewItem, protocolDescriptionId);



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
            cb_Name.SelectedIndex = -1;

            cb_SecondaryName.DataSource = new List<Common.ExtraFieldTemplates>(list);
            cb_SecondaryName.DisplayMember = "Name";
            cb_SecondaryName.ValueMember = "Name";
            cb_SecondaryName.SelectedIndex = -1;

            await Monitor.Monitor.Fill_ComboBox_PartCodes(cb_PartCode);
            cb_PartCode.SelectedIndex = -1;

            Fill_ComboBox_FilterColumns(cb_FilterCodeText, ListCodetext);
            Fill_ComboBox_FilterColumns(cb_SecondaryCodeText, ListCodetext);

            Load_ListItems();
            Load_TotalLists();

            if (dgv_Items.Rows.Count > 0)
                tab_Main.SelectedTab = tab_Main.TabPages[0];
            else
                tab_Main.SelectedTab = tab_Main.TabPages[1];
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

            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, ComboBox cbPartCode, ComboBox cbName, ComboBox cbSecondaryName, ComboBox cbProperties, ComboBox cbFilterCodeText, ComboBox cbSecondaryCodeText, ComboBox cbSortMode, TextBox tbText, int protocolDescriptionId)
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

            private void ListItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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
            //private DataGridView? dgv_Items;
            //private DataGridView? dgv_ListItems;
            //private ComboBox? cb_PartCode;
            //private ComboBox? cb_Name;
            //private ComboBox? cb_SecondaryName;
            //private ComboBox? cb_Properties;
            //private ComboBox? cb_FilterCodeText;
            //private ComboBox? cb_SecondaryCodeText;
            //private ComboBox? cb_SortMode;
            //private int ProtocolDescriptionId;


            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, ComboBox cbPartCode, ComboBox cbName, ComboBox cbSecondaryName, ComboBox cbProperties, ComboBox cbFilterCodeText, ComboBox cbSecondaryCodeText, ComboBox cbSortMode, TextBox tbText, int protocolDescriptionId)
            {
                //dgv_Items = dgvItems;
                //dgv_ListItems = dgvListItems;
                //cb_PartCode = cbPartCode;
                //cb_Name = cbName;
                //cb_SecondaryName = cbSecondaryName;
                //cb_Properties = cbProperties;
                //cb_FilterCodeText = cbFilterCodeText;
                //cb_SecondaryCodeText = cbSecondaryCodeText;
                //cb_SortMode = cbSortMode;
                //ProtocolDescriptionId = protocolDescriptionId;
                //List_TemplateID = list_templateID;
            }

            //public void Load()
            //{
            //    Load_ListItems(dgv_Items, dgv_ListItems, cb_PartCode, cb_Name, cb_SecondaryName, cb_Properties, cb_FilterCodeText, cb_SecondaryCodeText, cb_SortMode, "Protocol", ProtocolDescriptionId);

            //}
            //public void SaveItem(string item)
            //{
            //    Save_ListItem(ProtocolDescriptionId, item, dgv_Items.Rows.Count, "Protocol");
            //}
        }
        public class ProcesscardItems : IItemsProvider
        {
            //private DataGridView? dgv_Items;
            //private DataGridView? dgv_ListItems;
            //private ComboBox? cb_PartCode;
            //private ComboBox? cb_Name;
            //private ComboBox? cb_SecondaryName;
            //private ComboBox? cb_Properties;
            //private ComboBox? cb_FilterCodeText;
            //private ComboBox? cb_SecondaryCodeText;
            //private ComboBox? cb_SortMode;
            //private int ProtocolDescriptionId;

            public void Initialize(DataGridView dgvItems, DataGridView dgvListItems, ComboBox cbPartCode, ComboBox cbName, ComboBox cbSecondaryName, ComboBox cbProperties, ComboBox cbFilterCodeText, ComboBox cbSecondaryCodeText, ComboBox cbSortMode, TextBox tbText, int protocolDescriptionId)
            {
                //dgv_Items = dgvItems;
                //dgv_ListItems = dgvListItems;
                //cb_PartCode = cbPartCode;
                //cb_Name = cbName;
                //cb_SecondaryName = cbSecondaryName;
                //cb_Properties = cbProperties;
                //cb_FilterCodeText = cbFilterCodeText;
                //cb_SecondaryCodeText = cbSecondaryCodeText;
                //cb_SortMode = cbSortMode;
                //ProtocolDescriptionId = protocolDescriptionId;
                //List_TemplateID = list_templateID;
            }

        }





        public static async Task<(List<string?> Items, bool IsItemsMultipleColumns, List<string> Cells_CodeText)> GetListItems(int ProtocolDescriptionId, string ListType, int dataType, Func<string, string?>? filterVariable = null)
        {
            bool isMultipleColumns = false;
            var items = new List<string>();
            var cells_CodeText = new List<string>();
            await using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                SELECT items.Name as ItemName, PartCode, EndPoint, Property, fields.Name, SecondaryName, FilterCodeText, SecondaryCodeText, SortMode
                FROM List.ItemFields as fields
                    LEFT JOIN List.Items as items 
                        ON fields.ItemId = items.Id
                WHERE ProtocolDescriptionId = @protocoldescriptionid AND MainTemplateId = @maintemplateid AND ListType = @listType
                ORDER BY ItemOrder";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@protocoldescriptionid", ProtocolDescriptionId);
            cmd.Parameters.AddWithValue("@maintemplateid", MainTemplate.ID);
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
            string? sortmode = null;

            while (reader.Read())
            {
                var item = reader["ItemName"]?.ToString();
                if (item != null)
                    items.Add(item);

                partCode = reader["PartCode"] as string ?? reader["PartCode"]?.ToString();
                endPoint = reader["EndPoint"] as string ?? reader["EndPoint"]?.ToString();
                property = reader["Property"] as string ?? reader["Property"]?.ToString();
                sortmode = reader["SortMode"] as string ?? reader["SortMode"]?.ToString();
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
                await Monitor.Services.ToolService.Add_Equipment(items, tableType, partCode, name, property, variable, sortmode, dataType, isMultipleColumns, secondaryName, secondaryCodeText);

            return (items, isMultipleColumns, cells_CodeText);
        }

        private void Load_ListItems()
        {
            dgv_ListItems.Rows.Clear();
            dgv_Items.Rows.Clear();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query =
                @"
                SELECT DISTINCT
                    items.Id,
                    items.Name,
                    fields.ProtocolDescriptionId,
                    fields.ItemOrder,
                    fields.ListType
                FROM List.Items AS items
                LEFT JOIN List.ItemFields AS fields
                    ON items.Id = fields.ItemID
                    AND fields.ListType = @listtype
                    AND fields.MainTemplateID = @maintemplateid
                ORDER BY fields.ProtocolDescriptionId, fields.ItemOrder;";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@listtype", listType);
            cmd.Parameters.AddWithValue("@maintemplateid", MainTemplate.ID);
            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                IsListActivated = true;
                var id = reader["Id"].ToString();
                var item = reader["Name"].ToString();
                int.TryParse(reader["ProtocolDescriptionId"].ToString(), out var protocolDescriptionId);
                var listtype = reader["ListType"].ToString();
                var exists = dgv_ListItems.Rows
                    .Cast<DataGridViewRow>()
                    .Any(r => r.Cells[0].Value?.ToString() == item);
                if (!exists && item != null)
                    dgv_ListItems.Rows.Add(item);
                if (protocolDescriptionId == ProtocolDescriptionId && listtype == listType)
                    dgv_Items.Rows.Add(id, item);

            }

            Load_MonitorList(cb_PartCode, cb_Name, cb_SecondaryName, cb_Properties, cb_FilterCodeText, cb_SecondaryCodeText, cb_SortMode, ProtocolDescriptionId, listType);
        }
        private static void Load_MonitorList(ComboBox cb_PartCode, ComboBox cb_Name, ComboBox cb_SecondaryName, ComboBox cb_Property, ComboBox cb_FilterCodeText, ComboBox cb_SecondaryCodeText, ComboBox cb_SortMode, int protocolDescriptionId, string listType)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query =
                @"
                SELECT ItemFieldsId, PartCode, Property, Name, SecondaryName, FilterCodeText, SecondaryCodeText, SortMode
                FROM List.ItemFields 
                WHERE ProtocolDescriptionId = @protocoldescriptionid AND MainTemplateId = @maintemplateid AND ListType = @listType
                ORDER BY ProtocolDescriptionId, ItemOrder";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@listType", listType);
            cmd.Parameters.AddWithValue("@protocoldescriptionid", protocolDescriptionId);
            cmd.Parameters.AddWithValue("@maintemplateid", MainTemplate.ID);
            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                IsListActivated = true;
                ItemsFieldId = reader["ItemFieldsId"] != DBNull.Value ? Convert.ToInt32(reader["ItemFieldsId"]) : 0;
                cb_PartCode.SelectedItem = reader["PartCode"].ToString();
                cb_Name.SelectedValue = reader["Name"].ToString();
                cb_SecondaryName.SelectedValue = reader["SecondaryName"].ToString();
                cb_Property.SelectedItem = reader["Property"].ToString();
                cb_FilterCodeText.SelectedItem = reader["FilterCodeText"].ToString();
                cb_SecondaryCodeText.SelectedItem = reader["SecondaryCodeText"].ToString();
                cb_SortMode.SelectedItem = reader["SortMode"].ToString();
            }

        }
        private void Load_TotalLists()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                SELECT COUNT(DISTINCT MainTemplateID) AS TotalLists
                FROM List.ItemFields
                WHERE ProtocolDescriptionId = @protocoldescriptionid AND ListType = @listtype";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@protocoldescriptionid", ProtocolDescriptionId);
            cmd.Parameters.AddWithValue("@listtype", listType);
            con.Open();
            var totalLists = cmd.ExecuteScalar();
            label_TotalLists.Text = $@"Denna lista finns i {totalLists} Mallar";
        }

        private void Save_ListItem(int protocolDescriptionId, int mainTemplateID, string itemText, int itemOrder, string listType)
        {

            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();
            IsListActivated = true;
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
                    WHERE ItemId = @itemid AND ProtocolDescriptionId = @protocoldescriptionid AND MainTemplateId = @maintemplateid AND ListType = @listtype
                )
                BEGIN
                    INSERT INTO List.ItemFields (ItemId, ProtocolDescriptionId, MainTemplateID, ListType, ItemOrder, CreatedBy)
                    VALUES (@itemid, @protocoldescriptionid, @maintemplateid, @listtype, @itemorder, @createdby);
                END";

            using (var cmd = new SqlCommand(insertFieldQuery, con, tran))
            {
                cmd.Parameters.AddWithValue("@itemid", itemId);
                cmd.Parameters.AddWithValue("@protocoldescriptionid", protocolDescriptionId);
                cmd.Parameters.AddWithValue("@maintemplateid", mainTemplateID);
                cmd.Parameters.AddWithValue("@listtype", listType);
                cmd.Parameters.AddWithValue("@itemorder", itemOrder);
                cmd.Parameters.AddWithValue("@createdby", User.Person.Name);

                cmd.ExecuteNonQuery();
            }

            tran.Commit();

        }
        private void Save_MonitorList(int protocolDescriptionId, int mainTemplateId)
        {
            if (dgv_Items.Rows.Count > 0)
                return;
            IsListActivated = true;
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();

            const string query = @"
                IF EXISTS 
                (
                    SELECT 1 FROM List.ItemFields
                    WHERE ProtocolDescriptionID = @protocoldescriptionid AND MainTemplateId = @maintemplateid AND ListType = @listtype
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
                        SortMode =  @sortmode,
                        ModifiedBy = @username,
                        ModifiedDate = GETDATE()
                    WHERE ItemFieldsId = @id
                END
                ELSE
                BEGIN
                    INSERT INTO List.ItemFields (ProtocolDescriptionId, MainTemplateId, PartCode, EndPoint, Property, Name, SecondaryName, FilterCodeText, SecondaryCodeText, SortMode, ListType, CreatedBy)
                    VALUES (@protocoldescriptionid, @maintemplateid, @partcode, @endpoint, @property, @name, @secondaryname, @filtercodetext, @secondarycodetext, @sortmode, @listtype, @username)
                 END";

            using var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", ItemsFieldId);
            cmd.Parameters.AddWithValue("@protocoldescriptionid", protocolDescriptionId);
            cmd.Parameters.AddWithValue("@maintemplateid", mainTemplateId);
            cmd.Parameters.AddWithValue("@partcode", cb_PartCode.SelectedValue?.ToString());
            cmd.Parameters.AddWithValue("@endpoint", "Inventory+Parts");
            SQL_Parameter.String(cmd.Parameters, "@property", cb_Properties.SelectedItem?.ToString());
            SQL_Parameter.String(cmd.Parameters, "@name", cb_Name.SelectedValue?.ToString());
            SQL_Parameter.String(cmd.Parameters, "@secondaryname", cb_SecondaryName.SelectedValue?.ToString());
            SQL_Parameter.String(cmd.Parameters, "@filtercodetext", cb_FilterCodeText.SelectedItem?.ToString());
            SQL_Parameter.String(cmd.Parameters, "@secondarycodetext", cb_SecondaryCodeText.SelectedItem?.ToString());
            SQL_Parameter.String(cmd.Parameters, "@sortmode", cb_SortMode.SelectedItem?.ToString());
            cmd.Parameters.AddWithValue("@listtype", listType);
            cmd.Parameters.AddWithValue("@username", User.Person.Name);

            cmd.ExecuteNonQuery();
        }
        private void CheckForTemplatesToUpdate()
        {
            ItemsFieldId = 0;
            using var con = new SqlConnection(Database.cs_Protocol);
            string query = @"
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
                                WHERE ProtocolDescriptionId = Protocol.Template.ProtocolDescriptionID
                                    AND ListType = @listtype
                                    AND MainTemplateID = Protocol.MainTemplate.ID 
                            )
                    )
                )
                ORDER BY Name";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@protocoldescriptionid", ProtocolDescriptionId);
            cmd.Parameters.AddWithValue("@listtype", listType);
            con.Open();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var name = reader["Name"].ToString();
                var revision = reader["Revision"].ToString();
                int.TryParse(reader["ID"].ToString(), out var mainTemplateID);
                InfoText.Question($"{name} - Revision {revision} har också fältet {label_CodeText.Text} i mallen.\n" +
                                 $"Vill du koppla listorna för Processkort samt Protokoll för denna mall?", CustomColors.InfoText_Color.Ok, "", this);
                if (InfoText.answer == InfoText.Answer.Yes)
                    Copy_ListsToNewTemplate(MainTemplate.ID, mainTemplateID, ProtocolDescriptionId);

            }
        }

        public class TemplateMap
        {
            public int TemplateID { get; set; }
            public int ProtocolDescriptionID { get; set; }
            public int? ColumnIndex { get; set; }

            public int ItemFieldsId { get; set; }
        }

        private static List<TemplateMap> ListOldTemplateID(int oldMainTemplateID)
        {
            var result = new List<TemplateMap>();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                SELECT ItemFieldsId, TemplateID, ProtocolDescriptionID, ColumnIndex
                FROM List.ItemFields as fields
                JOIN Protocol.Template as template
	                ON fields.TemplateID = template.ID
                WHERE 
                (
                    TemplateID IN 
                    (
                        SELECT ID 
                        FROM Protocol.Template
                        WHERE FormTemplateID IN
                        (
                            SELECT FormTemplateID
                            FROM Protocol.FormTemplate
                            WHERE MainTemplateID = @oldmaintemplateid)))";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@oldmaintemplateid", oldMainTemplateID);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new TemplateMap
                {
                    ItemFieldsId = Convert.ToInt32(reader.GetValue(0)),
                    TemplateID = Convert.ToInt32(reader.GetValue(1)),
                    ProtocolDescriptionID = Convert.ToInt32(reader.GetValue(2)),
                    ColumnIndex = reader.IsDBNull(3) ? (int?)null : Convert.ToInt32(reader.GetValue(3))
                });
            }

            return result;
        }
        private static List<TemplateMap> ListNewTemplateID(int newMainTemplateID)
        {
            var result = new List<TemplateMap>();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                SELECT ID, ProtocolDescriptionID, ColumnIndex
                FROM Protocol.Template as template
                WHERE 
                (
                    ID IN 
                    (
                        SELECT ID 
                        FROM Protocol.Template
                        WHERE FormTemplateID IN
                        (
                            SELECT FormTemplateID
                            FROM Protocol.FormTemplate
                            WHERE MainTemplateID = @newmaintemplateid)))";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@newmaintemplateid", newMainTemplateID);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new TemplateMap
                {
                    TemplateID = Convert.ToInt32(reader.GetValue(0)),
                    ProtocolDescriptionID = Convert.ToInt32(reader.GetValue(1)),
                    ColumnIndex = reader.IsDBNull(2) ? (int?)null : Convert.ToInt32(reader.GetValue(2))
                });
            }
            return result;
        }
        public static void Copy_ListsToNewTemplate(int? oldMainTemplateID, int newMainTemplateID, int? protocolDescriptionId = null)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                SELECT 
                    ItemFieldsId
                FROM List.ItemFields
                WHERE MainTemplateId = @maintemplateid";
            if (protocolDescriptionId != null)
                query += @"
                    AND ProtocolDescriptionId = @protocoldescriptionid";
            query += @"
                AND EXISTS
                (
                    SELECT 1 FROM Protocol.Template
                    WHERE ProtocolDescriptionID = List.ItemFields.ProtocolDescriptionId
                        AND Template.FormTemplateID IN 
                        (
                            SELECT FormTemplateID
                            FROM Protocol.FormTemplate
                            WHERE MainTemplateID = @maintemplateid  
                        )
                )";
            using var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@maintemplateid", oldMainTemplateID);
            cmd.Parameters.AddWithValue("@protocoldescriptionid", protocolDescriptionId);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var itemFieldsId = reader.GetInt32(0);
                Copy_ListItem(itemFieldsId, newMainTemplateID);
            }
        }
        private static void Copy_ListItem(int itemFieldsId, int newMainTemplateId)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                INSERT INTO List.ItemFields
                (
                    ProtocolDescriptionId,
                    MainTemplateId, 
                    ItemId,
                    ItemText,
                    ItemOrder,
                    PartCode,
                    EndPoint,
                    Property,
                    Name,
                    SecondaryName,
                    FilterCodeText,
                    SecondaryCodeText,
                    SortMode,
                    ListType,
                    CreatedBy            
                )
                SELECT
                    ProtocolDescriptionID,
                    @newmaintemplateid AS MainTemplateId,
                    ItemId,
                    ItemText,
                    ItemOrder,
                    PartCode,
                    EndPoint,
                    Property,
                    Name,
                    SecondaryName,
                    FilterCodeText,
                    SecondaryCodeText,
                    SortMode,
                    ListType,
                    @createdby            
                FROM List.ItemFields
                WHERE ItemFieldsId = @itemfieldsid;";
            using var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@itemfieldsid", itemFieldsId);
            cmd.Parameters.AddWithValue("@newmaintemplateid", newMainTemplateId);
            cmd.Parameters.AddWithValue("@createdby", User.Person.Name);

            con.Open();
            cmd.ExecuteNonQuery();
        }
        public void Fill_ComboBox_FilterColumns(ComboBox comboBox, List<string> listCodeText)
        {
            comboBox.Items.Clear();
            var localList = new List<string>(listCodeText);

            // Lägg till alla värden i den lokala listan
            foreach (var codeText in localList)
                comboBox.Items.Add(codeText);
        }

        private void ListType_Enter(object sender, EventArgs e)
        {
            var choose_ListType = new Choose_Item(["Processcard", "Protocol"], [tb_ListType], false, false, true);
            choose_ListType.ShowDialog();
            switch (tb_ListType.Text)
            {
                case "Processcard":
                    TypeOfList = ListType.Processcard;
                    listType = "Processcard";
                    break;
                case "Protocol":
                    TypeOfList = ListType.Protocol;
                    listType = "Protocol";
                    break;
            }
            Load_ListItems();
            Load_TotalLists();
        }
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            Delete_Item();
            dgv_Items.Rows.RemoveAt(dgv_Items.SelectedRows[0].Index);
        }
        private void ResetList_Click(object sender, EventArgs e)
        {
            dgv_Items.Rows.Clear();
            cb_PartCode.SelectedIndex = -1;
            cb_Properties.SelectedIndex = -1;
            cb_FilterCodeText.SelectedIndex = -1;
            cb_SortMode.SelectedIndex = -1;
            cb_Module.SelectedIndex = -1;
            cb_Name.SelectedIndex = -1;
            cb_SecondaryCodeText.SelectedIndex = -1;
            cb_SecondaryName.SelectedIndex = -1;
        }

        private void Delete_Item()
        {
            if (dgv_Items.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_Items.SelectedRows[0];
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();

                const string query = @"
                    DELETE FROM List.ItemFields 
                    WHERE ItemId = @id
                        AND MainTemplateID = @maintemplateid
                        AND ProtocolDescriptionId = @protocoldescriptionid
                        AND ListType = @listtype";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", selectedRow.Cells["col_ID"].Value.ToString());
                cmd.Parameters.AddWithValue("@maintemplateid", MainTemplate.ID);
                cmd.Parameters.AddWithValue("@protocoldescriptionid", ProtocolDescriptionId);
                cmd.Parameters.AddWithValue("@listtype", listType);

                cmd.ExecuteScalar();
            }
        }
        private void dgv_Items_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Delete_Item();
        }
        private void NewItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_AddNewItem.Text))
            {
                dgv_Items.Rows.Add(tb_AddNewItem.Text);
                Save_ListItem(ProtocolDescriptionId, MainTemplate.ID, tb_AddNewItem.Text, dgv_Items.Rows.Count, listType);
                Load_ListItems();
                tb_AddNewItem.Text = string.Empty;
            }
        }
        private void ItemList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var item = dgv_ListItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (item != null)
                Save_ListItem(ProtocolDescriptionId, MainTemplate.ID, item, dgv_Items.Rows.Count, listType);
            //itemsProvider.SaveItem(item);
            Load_ListItems();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            if (tab_Main.SelectedTab == page_MonitorLists && string.IsNullOrEmpty(cb_PartCode.SelectedValue?.ToString()))
            {
                InfoText.Show("Du måste fylla i Typ av Verktyg för du sparar.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                cb_PartCode.Focus();
                return;
            }
            //foreach(var templateId in List_TemplateID)
            Save_MonitorList(ProtocolDescriptionId, MainTemplate.ID);
            CheckForTemplatesToUpdate();

            this.Close();
        }
        private void CopyListToOtherTemplates_Click(object sender, EventArgs e)
        {
            CheckForTemplatesToUpdate();
            Load_TotalLists();
        }
        private void ItemsBuilder_FormClosed(object sender, FormClosedEventArgs e)
        {
            //IsListActivated = dgv_Items.Rows.Count > 0;
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
