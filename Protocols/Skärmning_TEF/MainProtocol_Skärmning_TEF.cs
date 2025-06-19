using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.Skärmning_TEF
{
    public partial class MainProtocol_Skärmning_TEF : UserControl
    {
        private bool IsOkTransferProduktion
        {
            get
            {
                if (string.IsNullOrEmpty(tb_Produktion_Mätare.Text))
                    return false;
                return true;
            }
        }
        
        private string? MIN_Value(string name)
        {
            switch (name)
            {
                case string a when a.Contains("Temp"):
                    return lbl_Produktion_Temp_min.Text;
                case string a when a.Contains("Produktion_ID"):
                    return lbl_Produktion_ID_min.Text;
                case string a when a.Contains("OD1"):
                    return lbl_Produktion_OD1_min.Text;
                case string a when a.Contains("ODs"):
                    return lbl_Produktion_ODs_min.Text;
                case string a when a.Contains("Verktyg"):
                    return lbl_VerktygsID_min.Text;
            }
            return null;
        }
        private string? MAX_Value(string name)
        {
            switch (name)
            {
                case string a when a.Contains("Temp"):
                    return lbl_Produktion_Temp_max.Text;
                case string a when a.Contains("Produktion_ID"):
                    return lbl_Produktion_ID_max.Text;
                case string a when a.Contains("OD1"):
                    return lbl_Produktion_OD1_max.Text;
                case string a when a.Contains("ODs"):
                    return lbl_Produktion_ODs_max.Text;
                case string a when a.Contains("Verktyg"):
                    return lbl_VerktygsID_max.Text;
            }
            return null;
        }

        private readonly List<DataGridView> list_dgv = new List<DataGridView>();
      
        private List<int> List_ProtocolDescriptionID { get; set; }
        private List<int> List_Type { get; set; }
        private void Load_Lists()
        {
            if (Order.OrderID is null)
                return;
            List_ProtocolDescriptionID = new List<int>();
            List_Type = new List<int>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT DISTINCT ProtocolDescriptionID, Type, ColumnIndex
                    FROM Protocol.Template WHERE (FormTemplateID = 12)
                    ORDER BY ColumnIndex";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    List_ProtocolDescriptionID.Add(int.Parse(reader["ProtocolDescriptionID"].ToString()));
                    List_Type.Add(int.Parse(reader["Type"].ToString()));
                }
            }
        }
        private int RowIndex_Active_dgv
        {
            get
            {
                var dgv = (DataGridView)tab_ctrl_Arbetskort.SelectedTab.Controls[0];
                return dgv.Rows.Count;
            }
        }


        public static string MachineName(int MachineIndex)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    	SELECT STUFF(
                            (SELECT '_' + TextValue
                            FROM [Order].Data
                            WHERE OrderID = @orderid
                                AND MachineIndex = @machineIndex
                                AND Uppstart = 0
                                AND (ProtocolDescriptionID = (SELECT ID FROM Protocol.Description WHERE CodeText = 'Maskin') OR ProtocolDescriptionID = (SELECT ID FROM Protocol.Description WHERE CodeText = 'Sida'))
                            ORDER BY ProtocolDescriptionID
                        FOR XML PATH('')), 1, 1, '')";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@machineIndex", MachineIndex);
                con.Open();
                var value = cmd.ExecuteScalar();
                return value.ToString();
            }
        }


        public MainProtocol_Skärmning_TEF()
        {
            InitializeComponent();
            Load_Lists();
        }

        internal void Load_Data()
        {
            Module.IsOkToSave = false;

            lbl_OrderNr.Text = Order.OrderNumber;
            lbl_ArtikelNr.Text = Order.PartNumber;
            lbl_Customer.Text = Order.Customer;
            lbl_Benämning.Text = Order.Description;

            Load_MainInfo();
            Load_Data_FROM_Processcard();
            Load_Processcard_Maskinparametrar_Values();
            Load_Data_FROM_Halvfabrikat();
            Load_Korprotokoll_Values();
            Load_Protocol_Production();

            Module.IsOkToSave = true;

        }
        private void Load_MainInfo()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                           SELECT Date_Start, Name_Start
                           FROM [Order].MainData AS main
                                    
                            WHERE OrderID = @id";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Date_Start.Text = reader[0].ToString();
                    Name_Start.Text = reader[1].ToString();
                }
            }
        }
        private void Load_Korprotokoll_Values()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT DISTINCT Value, TextValue, ColumnIndex, template.Type, template.Decimals
                        FROM [Order].Data AS protocol
	                        JOIN Protocol.Template as template
		                        ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
	                        JOIN Protocol.Description as descr
		                        ON descr.id = template.ProtocolDescriptionID
                        WHERE OrderID = @orderid
                            AND FormTemplateID = @formtemplateid
                            AND template.revision = @revision
                        ORDER BY ColumnIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@formtemplateid",11);
                cmd.Parameters.AddWithValue("@revision", Korprotokoll.ProtocolTemplateRevision.OrderNr(Order.OrderID));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int.TryParse(reader["ColumnIndex"].ToString(), out var col);
                    int.TryParse(reader["type"].ToString(), out var type);
                    var value = string.Empty;
                    switch (type)
                    {
                        case 0: //Numbers
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);
                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                                value = Processcard.Format_Value(NumberValue, decimals);
                            break;
                        case 1://TextValue
                            value = reader["TextValue"].ToString();
                            break;
                    }

                    if (string.IsNullOrEmpty(value))
                        value = "N/A";
                    var ctrl = tlp_Maskinparametrar.GetControlFromPosition(col + 1, 7);
                    ctrl.Text = value;
                }
            }
            
        }

        private void Load_Processcard_Maskinparametrar_Values()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT ColumnIndex, RowIndex, Value, TextValue, template.Type, template.Decimals
                    FROM Protocol.Template AS template
                        JOIN Processcard.Data AS pc_data
	                        ON pc_data.TemplateID = template.Id
                        JOIN Protocol.Description AS descr
	                        ON descr.Id = template.ProtocolDescriptionID
                    WHERE pc_data.PartID = @partID
                    AND template.FormTemplateID = @formtemplateid
                    ORDER BY ColumnIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
                SQL_Parameter.NullableINT(cmd.Parameters, "@formtemplateid", 11);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader["type"].ToString(), out var type);
                    int.TryParse(reader["ColumnIndex"].ToString(), out var col);
                    var value = string.Empty;
                    switch (type)
                    {
                        case 0://NumberValue
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);

                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                                value = Processcard.Format_Value(NumberValue, decimals);
                            break;
                        case 1://TextValue
                            value = reader["TextValue"].ToString();
                            break;
                    }
                    var ctrl = tlp_Maskinparametrar.GetControlFromPosition(col + 1, 5);
                    ctrl.Text = value;
                }
            }
        }

        private void Load_Data_FROM_Processcard()
        {
            Control[] ctrl_ProcessParametrar =
            {
                lbl_Produktion_Temp_min, lbl_Produktion_Temp_nom, lbl_Produktion_Temp_max,
                lbl_Produktion_ID_min, lbl_Produktion_ID_nom, lbl_Produktion_ID_max,
                lbl_Produktion_OD1_min, lbl_Produktion_OD1_nom, lbl_Produktion_OD1_max,
                lbl_Produktion_ODs_min, lbl_Produktion_ODs_nom, lbl_Produktion_ODs_max,
                lbl_VerktygsID_min, lbl_VerktygsID_nom, lbl_VerktygsID_max,
                
            };

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                            SELECT ColumnIndex, RowIndex, Value, TextValue, template.Type, template.Decimals
                            FROM Protocol.Template AS template
	                        JOIN Processcard.Data AS pc_data
		                        ON pc_data.TemplateID = template.Id
	                        JOIN Protocol.Description AS descr
		                        ON descr.Id = template.ProtocolDescriptionID
                            WHERE pc_data.PartID = @partID
                                AND template.FormTemplateID = @formtemplateid
                                AND ColumnIndex % 2 = 0
                            ORDER BY ColumnIndex";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@partID", Order.PartID);
                cmd.Parameters.AddWithValue("@formtemplateid", 12);
                var reader = cmd.ExecuteReader();
                var ctr = 0;
                while (reader.Read())
                {
                    int.TryParse(reader["type"].ToString(), out var type);
                    var value = string.Empty;
                    switch (type)
                    {
                        case 0://NumberValue
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);

                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                                value = Processcard.Format_Value(NumberValue, decimals);
                            break;
                        case 1://TextValue
                            value = reader["TextValue"].ToString();
                            break;
                    }
                    ctrl_ProcessParametrar[ctr].Text = value;
                    ctr++;
                }
            }
        }
        public void Load_Protocol_Production()
        {
            Module.IsOkToSave = false;
            DrawingControl.SuspendDrawing(tab_ctrl_Arbetskort);

            Remove_All_Cards();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query =
                    @"SELECT DISTINCT CodeText, Value, TextValue, DateValue, BoolValue, MachineIndex, Uppstart, ColumnIndex, template.Decimals, template.Type
                        FROM [Order].Data AS protocol
	                        JOIN Protocol.Template as template
		                        ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
	                        JOIN Protocol.Description as descr
		                        ON descr.id = template.ProtocolDescriptionID
                        WHERE OrderID = @orderid
                            AND FormTemplateID = @formtemplateid
                            AND protocol.ProtocolDescriptionID != 351
                       ORDER BY MachineIndex, Uppstart, ColumnIndex";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@formtemplateid", 12);
                con.Open();
                var reader = cmd.ExecuteReader();
                var lastMachine = 0;
                while (reader.Read())
                {
                    int.TryParse(reader["MachineIndex"].ToString(), out var machineIndex);
                    int.TryParse(reader["Type"].ToString(), out var type);
                    var codetext = reader["CodeText"].ToString();
                    var IsOkAddRow = int.TryParse(reader["ColumnIndex"].ToString(), out var col) == false;

                    if (lastMachine != machineIndex)
                    {
                        var workCard = MachineName(machineIndex);
                        Add_New_Card(workCard);
                        lastMachine = machineIndex;
                    }
                       

                    var value = string.Empty;
                    var boolValue = false;
                    switch (type)
                    {
                        case 0: //NumberValue
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);
                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                                value = Processcard.Format_Value(NumberValue, decimals);
                            break;
                        case 1: //TextValue
                            value = reader["TextValue"].ToString();
                            break;
                        case 2: //BoolValue
                            bool.TryParse(reader["BoolValue"].ToString(), out boolValue);
                            break;
                        case 3: //DateValue
                            if (DateTime.TryParse(reader["DateValue"].ToString(), out var date))
                                value = date.ToString("yyyy-MM-dd HH:mm");
                            break;
                    }

                    if (string.IsNullOrEmpty(value))
                        value = "N/A";
                    if (IsOkAddRow == false)
                    {
                        if (list_dgv[machineIndex - 1].Rows.Count <= 1)
                        {
                            if (type == 2) //bool value
                            {
                                var checkbox = new DataGridViewCheckBoxColumn
                                {
                                    Name = codetext
                                };
                                list_dgv[machineIndex - 1].Columns.Add(checkbox);
                            }
                            else
                                list_dgv[machineIndex - 1].Columns.Add(codetext, string.Empty);
                        }
                    }

                    if (IsOkAddRow)
                        list_dgv[machineIndex - 1].Rows.Add();
                    var row = list_dgv[machineIndex - 1].Rows.Count - 1;
                    if (type == 2)
                        list_dgv[machineIndex - 1].Rows[row].Cells[col].Value = boolValue;
                    else
                        list_dgv[machineIndex - 1].Rows[row].Cells[col].Value = value;
                }

                for (var i = 0; i < list_dgv.Count; i++)
                {
                    tab_ctrl_Arbetskort.SelectedIndex = i;
                    Set_ColumnWidth_dgv(list_dgv[i]);
                }

                Set_Colors_dgv();
                tab_ctrl_Arbetskort.SelectedIndex = 0;
                DrawingControl.ResumeDrawing(tab_ctrl_Arbetskort);

                Module.IsOkToSave = true;
            }
        }
        private void Load_Data_FROM_Halvfabrikat()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $"SELECT Halvfabrikat_Benämning, Halvfabrikat_OrderNr FROM [Order].PreFab {Queries.WHERE_OrderID}";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lbl_Tråd_Material.Text = reader[0].ToString();
                    lbl_LotNr.Text = reader[1].ToString();
                }
            }
        }

        public static void Save_Korprotokoll_Main(string Column, string value)
        {
            if (Module.IsOkToSave)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $"UPDATE [Order].MainData SET {Column} = @value {Queries.WHERE_OrderID}";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@value", value);
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void Save_Korprotokoll_Leave(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;

            if (Module.IsOkToSave)
            {
                var colIndex = tlp_Maskinparametrar.GetColumn(tb) - 1;
                var protocol_Description_ID = Protocol_Description.Protocol_Description_ID_Col(colIndex, 11);
                
                var type = Module.DatabaseManagement.ValueType(protocol_Description_ID, 11);

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    IF NOT EXISTS (SELECT * FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid)
                        INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, Value, TextValue, Uppstart)
                            VALUES(@orderid, @protocoldescriptionid, @value, @textvalue, 1)
                    ELSE
                        UPDATE [Order].Data
                            SET Value = @value, TextValue = @textvalue
                    WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", protocol_Description_ID);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    switch (type)
                    {
                        case 0://NumberValue
                            SQL_Parameter.Double(cmd.Parameters, "@value", tb.Text);
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            break;
                        case 1://TextValue
                            cmd.Parameters.AddWithValue("@value", DBNull.Value);
                            SQL_Parameter.String(cmd.Parameters, "@textvalue", tb.Text);
                            break;
                    }

                    cmd.ExecuteNonQuery();
                }
            }

            Validate_Data.Value_CellOrControl(true, tb.Name, 0,MIN_Value(tb.Name), MAX_Value(tb.Name), tb.Text, null, null, tb);
        }
        private void ValidateData_TextLeave(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            Validate_Data.Value_CellOrControl( true, tb.Name, 0,MIN_Value(tb.Name), MAX_Value(tb.Name), tb.Text, null, null, tb);
        }
        private void Date_MouseDown(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(Date_Start.Text) == false)
                return;
            if (e.Button == MouseButtons.Left)
            {
                var nuDatum = Date_Start.Text;
                var datePicker = new DatePicker(nuDatum);
                datePicker.ShowDialog();

                Date_Start.Text = datePicker.OutGoingDate;
            }
            else if (e.Button == MouseButtons.Right)
                Date_Start.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            Save_Korprotokoll_Main("Date_Start", Date_Start.Text);
        }
        private void Name_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name_Start.Text) == false)
                return;
            if (Person.IsPasswordOk("Bekräfta överföring med ditt lösenord."))
            {
                Name_Start.Text = Person.Name;
                Save_Korprotokoll_Main("Name_Start", Name_Start.Text);
            }
        }
        private void LotNr_Click(object sender, EventArgs e)
        {
            if (Module.IsOkToSave)
            {
                var list = Monitor.Monitor.PreFab_BatchNr(Monitor.Monitor.Part_Material.PartNumber);
                var choose_Item = new Choose_Item(list, new[] { lbl_LotNr }, false);
                choose_Item.ShowDialog();

                PreFab.UPDATE_BatchNr_Skärmning(lbl_LotNr.Text);
            }
        }

        private void Add_New_Card(string card_Name)
        {
            DrawingControl.SuspendDrawing(tab_ctrl_Arbetskort);
            tab_ctrl_Arbetskort.TabPages.Insert(tab_ctrl_Arbetskort.TabPages.Count, card_Name);
            var page = tab_ctrl_Arbetskort.TabPages[tab_ctrl_Arbetskort.TabPages.Count - 1];
            var dgv = new DataGridView
            {
                RowHeadersVisible = false,
                ColumnHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToResizeColumns = false,
                Dock = DockStyle.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Name = card_Name,
                Text = card_Name,
                ReadOnly = true
            };
            dgv.Columns.Add(card_Name, string.Empty);
            dgv.DefaultCellStyle.Font = new Font("Courier New", 7.5F);
            dgv.DefaultCellStyle.ForeColor = Color.DarkSlateGray;

            list_dgv.Add(dgv);
         
            page.Controls.Add(dgv);
            Enable_Controls();
            DrawingControl.SuspendDrawing(tab_ctrl_Arbetskort);
        }
        private void Remove_All_Cards()
        {
            tab_ctrl_Arbetskort.TabPages.Clear();
            list_dgv.Clear();
        }
        private void Enable_Controls()
        {
            ControlManager.Unlock_Controls(new Control[] {lbl_Transfer_Produktion, tb_Produktion_Mätare, tb_Produktion_Temp_L1, tb_Produktion_Temp_L2, tb_Produktion_ID_L1, tb_Produktion_ID_L2, tb_Produktion_OD1_L1, tb_Produktion_OD1_L2, tb_Produktion_ODs_L1, tb_Produktion_ODs_L2,
            chb_Tråd_slut, chb_Tråd_av, chb_Trasig_carrier, chb_Skarv, chb_Spole_slut, chb_Avslut_linje, chb_Avrapporterat, tb_Produktion_Kommentar});
        }
        internal void Lock_All_control()
        {
            Module.IsOkToSave = false;
            ControlManager.Lock_Controls(new Control[] {lbl_Transfer_Produktion, lbl_Kassera_Maskinparameter, lbl_LotNr, Tråd_Antal,
                Maskin_Hastighet_pot, Travers_Hastighet_pot, Carrier_fjäder, PPI, tb_Verktygs_ID, OD_oinsmält,
                tb_Produktion_Mätare, tb_Produktion_Temp_L1, tb_Produktion_Temp_L2, tb_Produktion_ID_L1, tb_Produktion_ID_L2, tb_Produktion_OD1_L1, tb_Produktion_OD1_L2, tb_Produktion_ODs_L1, tb_Produktion_ODs_L2,
                tb_Verktygs_ID, chb_Avslut_linje, chb_Skarv, chb_Spole_slut, chb_Trasig_carrier, chb_Tråd_av, chb_Tråd_slut, chb_Avrapporterat, tb_Produktion_Kommentar }, true);

        }
        private void Set_ColumnWidth_dgv(DataGridView dgv)
        {
            int test = dgv.ColumnCount;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;

            dgv.Columns[2].Width = 45;
            dgv.Columns[3].Width = 33;
            dgv.Columns[4].Width = 32;
            dgv.Columns[5].Width = 37;
            dgv.Columns[6].Width = 36;
            dgv.Columns[7].Width = 36;
            dgv.Columns[8].Width = 36;
            dgv.Columns[9].Width = 36;
            dgv.Columns[10].Width = 36;
            dgv.Columns[11].Width = 70;
            dgv.Columns[12].Width = 36;
            dgv.Columns[13].Width = 36;
            dgv.Columns[14].Width = 36;
            dgv.Columns[15].Width = 36;
            dgv.Columns[16].Width = 36;
            dgv.Columns[17].Width = 36;
            dgv.Columns[18].Width = 36;
            dgv.Columns[19].Width = 163;
            dgv.Columns[20].Width = 125;
            dgv.Columns[21].Width = 50;
            dgv.Columns[22].Width = 72;
        }
        private void Set_Colors_dgv()
        {
            foreach (var dgv in list_dgv)
            {
                for (var i = 0; i < dgv.Rows.Count; i++)
                {
                    if (bool.Parse(dgv.Rows[i].Cells[1].Value.ToString()))
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = CustomColors.Bad_Back;
                        dgv.Rows[i].DefaultCellStyle.ForeColor = CustomColors.Bad_Front;
                        dgv.Rows[i].DefaultCellStyle.Font = new Font("Courier New", (float)7.5,
                            FontStyle.Italic | FontStyle.Strikeout);
                    }
                    else
                    {
                        Validate_Data.Value_CellOrControl(true, "Temp L1", 0,lbl_Produktion_Temp_min.Text, lbl_Produktion_Temp_max.Text, dgv.Rows[i].Cells[3].Value.ToString(), null, dgv.Rows[i].Cells[3]);
                        Validate_Data.Value_CellOrControl(true, "Temp L2",0, lbl_Produktion_Temp_min.Text, lbl_Produktion_Temp_max.Text, dgv.Rows[i].Cells[4].Value.ToString(), null, dgv.Rows[i].Cells[4]);
                        Validate_Data.Value_CellOrControl(true, "ID L1", 0, lbl_Produktion_ID_min.Text, lbl_Produktion_ID_max.Text, dgv.Rows[i].Cells[5].Value.ToString(), null, dgv.Rows[i].Cells[5]);
                        Validate_Data.Value_CellOrControl( true, "ID L2", 0, lbl_Produktion_ID_min.Text, lbl_Produktion_ID_max.Text, dgv.Rows[i].Cells[6].Value.ToString(), null, dgv.Rows[i].Cells[6]);
                        Validate_Data.Value_CellOrControl(true, "OD L1", 0, lbl_Produktion_OD1_min.Text, lbl_Produktion_OD1_max.Text, dgv.Rows[i].Cells[7].Value.ToString(), null, dgv.Rows[i].Cells[7]);
                        Validate_Data.Value_CellOrControl(true, "OD L2", 0, lbl_Produktion_OD1_min.Text, lbl_Produktion_OD1_max.Text, dgv.Rows[i].Cells[8].Value.ToString(), null, dgv.Rows[i].Cells[8]);
                        Validate_Data.Value_CellOrControl(true, "ODs L1", 0, lbl_Produktion_ODs_min.Text, lbl_Produktion_ODs_max.Text, dgv.Rows[i].Cells[9].Value.ToString(), null, dgv.Rows[i].Cells[9]);
                        Validate_Data.Value_CellOrControl(true, "ODs L2", 0, lbl_Produktion_ODs_min.Text, lbl_Produktion_ODs_max.Text, dgv.Rows[i].Cells[10].Value.ToString(), null, dgv.Rows[i].Cells[10]);
                        Validate_Data.Value_CellOrControl(true, "Verktyg ID", 0, lbl_VerktygsID_min.Text, lbl_VerktygsID_max.Text, null, dgv.Rows[i].Cells[11].Value.ToString(), dgv.Rows[i].Cells[11]);
                    }
                }
            }
        }
        internal void Activate_Events()
        {
            TextBox[] tb = {Tråd_Antal, Maskin_Hastighet_pot, Travers_Hastighet_pot, Carrier_fjäder, PPI, OD_oinsmält, tb_Produktion_Mätare,
                tb_Produktion_Temp_L1, tb_Produktion_Temp_L2, tb_Produktion_ID_L1, tb_Produktion_ID_L2, tb_Produktion_OD1_L1, tb_Produktion_OD1_L2, tb_Produktion_ODs_L1, tb_Produktion_ODs_L2, tb_Verktygs_ID};

            foreach (var textbox in tb)
                textbox.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
        }
        private void Add_Arbetskort_Click(object sender, EventArgs e)
        {
            AddNewLine.Ask();
            var linje = AddNewLine.linje;
            var sida = AddNewLine.sida;

            if (!string.IsNullOrEmpty(sida))
                Add_New_Card($"{linje}_{sida}");
        }
        private void Transfer_Produktion_Click(object sender, EventArgs e)
        {
            if (IsOkTransferProduktion == false)
            {
                InfoText.Show("Någonting blev fel, kontrollera att allt är ifyllt och att du skapat ett arbetskort", CustomColors.InfoText_Color.Warning, "Warning", this);
                return;
            }
            Points.Add_Points(7, "Överför Produktion, Skärmning");
            var tab_Index = tab_ctrl_Arbetskort.SelectedIndex;
            var ctrl_tb = new Control[] { tb_Produktion_Mätare, tb_Produktion_Temp_L1, tb_Produktion_Temp_L2, tb_Produktion_ID_L1, tb_Produktion_ID_L2, tb_Produktion_OD1_L1, tb_Produktion_OD1_L2, tb_Produktion_ODs_L1, tb_Produktion_ODs_L2, tb_Verktygs_ID, tb_Produktion_Kommentar };
            ControlManager.Set_Control_NA(ctrl_tb);

            var black = new BlackBackground(string.Empty, 80);
            var password = new PasswordManager(LanguageManager.GetString("confirmTransferPassword"));
            black.Show();
            password.ShowDialog();
            black.Close();
            if (password.IsOk == false)
                return;

            var machineName = tab_ctrl_Arbetskort.SelectedTab.Text.Split('_');

            var values = new[]
            {
                machineName[0], machineName[1], "False", tb_Produktion_Mätare.Text, tb_Produktion_Temp_L1.Text, tb_Produktion_Temp_L2.Text, tb_Produktion_ID_L1.Text, tb_Produktion_ID_L2.Text, tb_Produktion_OD1_L1.Text, tb_Produktion_OD1_L2.Text,
                tb_Produktion_ODs_L1.Text, tb_Produktion_ODs_L2.Text, tb_Verktygs_ID.Text, chb_Tråd_slut.Checked.ToString(), chb_Tråd_av.Checked.ToString(), chb_Trasig_carrier.Checked.ToString(), chb_Skarv.Checked.ToString(), 
                chb_Spole_slut.Checked.ToString(), chb_Avslut_linje.Checked.ToString(), chb_Avrapporterat.Checked.ToString(),
                tb_Produktion_Kommentar.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm"), Person.EmployeeNr, Person.Sign
            };

            for (var i = 0; i < values.Length; i++)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        INSERT INTO [Order].Data
                                (OrderID, ProtocolDescriptionID, MachineIndex, Uppstart, Value, TextValue, BoolValue, DateValue)
                        VALUES  (@orderid, @protocoldescriptionid, @machineindex, @uppstart, @value, @textvalue, @boolvalue, @datevalue)";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    var value = values[i];
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", List_ProtocolDescriptionID[i]);
                    cmd.Parameters.AddWithValue("@machineindex", tab_ctrl_Arbetskort.SelectedTab.TabIndex + 1);
                    cmd.Parameters.AddWithValue("@uppstart", RowIndex_Active_dgv);
                    switch (List_Type[i])
                    {
                        case 0:
                            SQL_Parameter.Double(cmd.Parameters, "@value", value);
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                            break;
                        case 1:
                            SQL_Parameter.String(cmd.Parameters, "@textvalue", value);
                            cmd.Parameters.AddWithValue("@value", DBNull.Value);
                            cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                            break;
                        case 2:
                            SQL_Parameter.Boolean(cmd.Parameters, "@boolvalue", value);
                            cmd.Parameters.AddWithValue("@value", DBNull.Value);
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                            break;
                        case 3:
                            SQL_Parameter.Date_Time(cmd.Parameters, "@datevalue", value);
                            cmd.Parameters.AddWithValue("@value", DBNull.Value);
                            cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            break;
                    }
                  
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            
            }
            ControlManager.Clear_TextBoxes(ctrl_tb);
            Load_Protocol_Production();
            tab_ctrl_Arbetskort.SelectedIndex = tab_Index;

        }
        private void Kassera_Rad_Produktion_Click(object sender, EventArgs e)
        {
            var dgv = list_dgv[tab_ctrl_Arbetskort.SelectedIndex];
            var row = dgv.CurrentCell.RowIndex;
            InfoText.Question($"Vill du kassera rad nr {row + 1}?", CustomColors.InfoText_Color.Info, "Warning!",this);
            if (InfoText.answer == InfoText.Answer.Yes)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        UPDATE [Order].Data 
                        SET BoolValue = 'True' 
                        WHERE OrderID = @orderid 
                            AND MachineIndex = @machineIndex 
                            AND ProtocolDescriptionID = @protocoldescriptionid 
                            AND Uppstart = @uppstart";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@machineIndex", tab_ctrl_Arbetskort.SelectedTab.TabIndex + 1);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", 174);
                    cmd.Parameters.AddWithValue("@uppstart", row);
                    cmd.ExecuteScalar();
                }
                Load_Protocol_Production();
            }
        }


        private void Int_Values_Only_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void Double_Values_Onyl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                e.Handled = true;
        }


    }
}
