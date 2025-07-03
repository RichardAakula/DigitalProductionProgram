using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.Blandning_PTFE
{
    public partial class Journal_Blandning_PTFE : UserControl
    {
        public Warning? warning;
        public static int TotalRows
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    SELECT TOP(1) Uppstart
                    FROM [Order].Data
                    WHERE OrderID = @orderid
                    ORDER BY uppstart DESC";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", Order.OrderID);
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        return int.Parse(value.ToString());
                }

                return 0;
            }
        }

        private int uppstart;
        public static string? row_User;
        private readonly Dictionary<int, (int Type, int? Decimals, int? MaxChars)> dict_TemplateRules = new();

        private void ParameterUppstart(SqlParameterCollection collection, string param)
        {
            if (uppstart == 0)
                collection.AddWithValue(param, dgv_Journal.Rows.Count + 1);
            else
                collection.AddWithValue(param, uppstart);
        }

        public Journal_Blandning_PTFE()
        {
            InitializeComponent();
        }
        private void Journal_Blandning_PTFE_Load(object sender, EventArgs e)
        {
            LoadTemplateRules();
        }
        public void Load_Info()
        {
            dgv_Journal.Columns.Clear();
            dgv_Journal_Input.Columns.Clear();
            //Temp  LuftFukt  LC  PTFE-Typ  Pig.ArtNr  LotNr   Pig.LotNr  FatNr
            int[] width = { 50, 90, 65, 80, 80, 90, 75, 35, 60, 65, 120, 50, 50, 70, 45, 45 };
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                SELECT DISTINCT 
                    descr.CodeText, 
                    unit.UnitName AS Unit,
                    template.RowIndex, 
                    template.ColumnIndex, 
                    template.Type, 
                    template.Decimals
                FROM Protocol.Template AS template
                JOIN Protocol.Description AS descr 
                    ON descr.Id = template.ProtocolDescriptionID
                LEFT JOIN Protocol.Unit AS unit 
                    ON unit.Id = descr.UnitID
                WHERE template.FormTemplateID = @formtemplateid
                ORDER BY template.ColumnIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@formtemplateid", 16);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var reader = cmd.ExecuteReader();
                var ctr = 0;
                while (reader.Read())
                {
                    var col = new DataGridViewColumn
                    {
                        HeaderText = reader[0].ToString(),
                        Name = reader[0].ToString(),
                        CellTemplate = new DataGridViewTextBoxCell(),
                        Width = width[ctr],

                    };
                    var col1 = new DataGridViewColumn
                    {
                        HeaderText = reader[0].ToString(),
                        Name = reader[0].ToString(),
                        CellTemplate = new DataGridViewTextBoxCell(),
                        Width = width[ctr],

                    };
                    ctr++;
                    dgv_Journal_Input.Columns.Add(col);
                    dgv_Journal.Columns.Add(col1);
                }
            }
            dgv_Journal_Input.Rows.Add();

            Hide_Pigment_Columns();
        }

        private void Hide_Pigment_Columns()
        {
            if (Part.IsPartNrSpecial == false)
            {
                int[] columns = { 4, 6, 9 };
                foreach (var column in columns)
                    dgv_Journal_Input.Columns[column].Visible = dgv_Journal.Columns[column].Visible = false;

            }
        }
        public void Load_Data()
        {
            dgv_Journal.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT DISTINCT Uppstart, Value, TextValue, RowIndex, ColumnIndex, template.Type, template.Decimals
                        FROM [Order].Data AS protocol
	                        JOIN Protocol.Template as template
		                        ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
	                        JOIN Protocol.Description as descr
		                        ON descr.id = template.ProtocolDescriptionID
                        WHERE OrderID = @orderid
                            AND FormTemplateID = @formtemplateid
                        ORDER BY uppstart, RowIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@formtemplateid", 16);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int.TryParse(reader["Type"].ToString(), out var type);
                    int.TryParse(reader["RowIndex"].ToString(), out var row);
                    int.TryParse(reader["Uppstart"].ToString(), out var uppstart);
                    if (uppstart > dgv_Journal.Rows.Count)
                        dgv_Journal.Rows.Add();
                    int.TryParse(reader["ColumnIndex"].ToString(), out var col);

                    var value = string.Empty;
                    switch (type)
                    {
                        case 0: //NumberValue
                            int.TryParse(reader["Decimals"].ToString(), out var decimals);
                            if (double.TryParse(reader["Value"].ToString(), out var NumberValue) == false)
                                value = string.Empty;
                            else
                                value = Processcard.Format_Value(NumberValue, decimals);
                            break;
                        case 1:
                            value = reader["TextValue"].ToString();
                            break;
                    }

                    if (string.IsNullOrEmpty(value))
                        value = "N/A";

                    dgv_Journal.Rows[uppstart - 1].Cells[col].Value = value;
                }
            }
        }
        private void LoadTemplateRules()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();
            var cmd = new SqlCommand(@"
                SELECT ColumnIndex, Type, Decimals, MaxChars
                FROM Protocol.Template
                WHERE FormTemplateID = @id", con);
            cmd.Parameters.AddWithValue("@id", 16);

            using var reader = cmd.ExecuteReader();
            ServerStatus.Add_Sql_Counter();
            while (reader.Read())
            {
                var colIndex = Convert.ToInt32(reader["ColumnIndex"]);
                var type = Convert.ToInt32(reader["Type"]);
                int? decimals = reader["Decimals"] == DBNull.Value ? null : Convert.ToInt32(reader["Decimals"]);
                int? maxchars = reader["MaxChars"] == DBNull.Value ? null : Convert.ToInt32(reader["MaxChars"]);

                dict_TemplateRules[colIndex] = (type, decimals, maxchars);
            }
        }

        private void SaveRow_Click(object sender, EventArgs e)
        {
            if (!Person.IsPasswordOk("Bekräfta överföringen med ditt lösenord."))
                return;

            dgv_Journal_Input.Rows[0].Cells[Protocol_Description.Codetext(157)].Value = Person.Sign;
            dgv_Journal_Input.Rows[0].Cells[Protocol_Description.Codetext(158)].Value = Person.EmployeeNr;

            var now = DateTime.Now;
            if (dgv_Journal_Input.Rows[0].Cells[Protocol_Description.Codetext(152)].Value == null)// || string.IsNullOrEmpty(dgv_Journal_Input.Rows[0].Cells[Protocol_Description.Codetext(152)].Value.ToString()))
                dgv_Journal_Input.Rows[0].Cells[Protocol_Description.Codetext(152)].Value = now.ToString("yyyy-MM-dd HH:mm");
            foreach (DataGridViewColumn column in dgv_Journal_Input.Columns)
            {
                var cell = dgv_Journal_Input.Rows[0].Cells[column.Index];
                var pcID = Protocol_Description.Protocol_Description_ID_Col(column.Index, 16);
                var type = Module.DatabaseManagement.ValueType(pcID, 16);

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, Uppstart, Ugn, Value, TextValue, BoolValue)
                        VALUES (@orderid, @protocoldescriptionid, @uppstart, @ugn, @value, @textvalue, NULL)";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", pcID);
                    ParameterUppstart(cmd.Parameters, "@uppstart");
                    cmd.Parameters.AddWithValue("@ugn", DBNull.Value);

                    switch (type)
                    {
                        case 0: //NumberValue
                            SQL_Parameter.Double(cmd.Parameters, "@value", cell.Value);
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            break;
                        case 1: //TextValue
                            if (cell.Value != null)
                                SQL_Parameter.String(cmd.Parameters, "@textvalue", cell.Value.ToString());
                            else
                                cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@value", DBNull.Value);
                            break;
                    }

                    cmd.ExecuteNonQuery();
                }
            }

            uppstart = 0;
            dgv_Journal_Input.Rows.Clear();
            Load_Data();
            dgv_Journal_Input.Rows.Add();
            warning?.Close();
        }
        private void EditRow_Click(object sender, EventArgs e)
        {
            var row = dgv_Journal.CurrentCell.RowIndex;
            uppstart = row + 1;
            row_User = dgv_Journal.Rows[row].Cells["Sign"].Value.ToString();
            if (row_User != Person.Sign)
            {
                InfoText.Show("Du kan inte redigera någon annans rad.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }

            warning = new Warning("Kom ihåg att spara raden annars försvinner den!", 75);
            warning.Show();

            for (var col = 0; col < dgv_Journal.Columns.Count; col++)
                dgv_Journal_Input.Rows[0].Cells[col].Value = dgv_Journal.Rows[row].Cells[col].Value;

            dgv_Journal.Rows.RemoveAt(row);

            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"DELETE FROM [Order].Data WHERE OrderID = @orderid AND uppstart = @row";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            cmd.Parameters.AddWithValue("@row", row + 1);

            cmd.ExecuteNonQuery();
        }

        private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += AllowedChars_KeyPress_Blandning_PTFE;
            tb.ShortcutsEnabled = false;
        }
        private void AllowedChars_KeyPress_Blandning_PTFE(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            var col = dgv_Journal_Input.CurrentCell.ColumnIndex;

            // Vissa kolumner får ej fyllas i
            if (col is 8)
            {
                InfoText.Show("Detta fält kan du inte skriva i, du måste välja från listan som dyker upp när du aktiverar fältet.", CustomColors.InfoText_Color.Info, null, this);
                e.Handled = true;
                return;
            }
            if (col is 2 or 10 or 14 or 15)
            {
                InfoText.Show("Denna ruta fylls i automatiskt när du Sparar raden.", CustomColors.InfoText_Color.Info, null, this);
                e.Handled = true;
                // Flytta fokus till nästa
                int nextCol;
                if (col is 14 or 15)
                {
                    var headerName = Protocol_Description.Codetext(156);
                    var colIndex = dgv_Journal_Input.Columns
                        .Cast<DataGridViewColumn>()
                        .FirstOrDefault(c => c.HeaderText == headerName)?.Index ?? -1;

                    nextCol = colIndex;
                }
                else
                    nextCol = col + 1;
                
                
                if (nextCol < dgv_Journal_Input.Columns.Count)
                    dgv_Journal_Input.CurrentCell = dgv_Journal_Input.Rows[0].Cells[nextCol];
                return;
            }

            if (dict_TemplateRules.TryGetValue(col, out var rule))
            {
                var (type, decimals, maxchars) = rule;

                switch (type)
                {
                    case 0: // Siffra
                        if (decimals > 0)
                        {
                            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '-')
                                e.Handled = true;
                        }
                        else
                        {
                            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                                e.Handled = true;
                        }
                        break;

                    case 1: // Text
                    case 2: // Alfanumerisk
                        e.Handled = false;
                        break;

                    default:
                        e.Handled = true;
                        break;
                }
            }
            else
            {
                // Om kolumn ej hittas i template: förhindra inmatning
                e.Handled = true;
            }
        }

        
        private void Journal_Input_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var items = new List<string?>();
            var col = e.ColumnIndex;
            switch (col)
            {
                case 2:
                    dgv_Journal_Input.Rows[0].Cells[e.ColumnIndex].Value = Person.Sign;
                    return;

                case 8:
                    items.Add("1");
                    items.Add("2");
                    items.Add("3");
                    break;
                default:
                    return;
            }

            var choose_Item = new Choose_Item(items, new[] { dgv_Journal_Input.Rows[0].Cells[col] });
            choose_Item.ShowDialog();
        }

       
    }
}
