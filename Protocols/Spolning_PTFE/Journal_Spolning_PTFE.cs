using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;
using SortOrder = System.Windows.Forms.SortOrder;

namespace DigitalProductionProgram.Protocols.Spolning_PTFE
{
    public partial class Journal_Spolning_PTFE : UserControl
    {
        public Warning? warning;
        private int? EditRow;
        public static string row_User = null!;
        private readonly Dictionary<int, (int? Type, int? Decimals, int? MaxChars)> dict_TemplateRules = new();

        public static int[] InputBoxes_Width
        {
            get
            {
                if (Templates_Protocol.MainTemplate.ID == 37)
                    return new[] { 60, 50, 45, 100, 80, 45, 55, 100, 80, 45, 55, 100, 40, 40, 55, 48, 50, 45, 55, 50, 125, 40, 40, 108, 100, 50 };
                return new[] { 60, 50, 45, 75, 100, 80, 45, 55, 100, 80, 45, 55, 100, 40, 40, 55, 48, 50, 45, 55, 50, 125, 40, 40, 50, 100, 50, 120 };
            }
        }
        private static List<string?> Blandning_LotNr
        {
            get
            {
                var list = new List<string?>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT Halvfabrikat_OrderNr 
                        FROM [Order].PreFab
                        WHERE OrderID IN (SELECT OrderID FROM [Order].MainData WHERE orderNr = @ordernr)";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@ordernr", Order.OrderNumber);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0].ToString());
                }
                return list;
            }
        }
        private string? Lotnr => dgv_Journal_Input.Rows[0].Cells["147"]?.Value?.ToString();

        private int Fatnr
        {
            get
            {
                if (dgv_Journal_Input.Rows[0].Cells["149"].Value == null)
                    return 0;
                int.TryParse(dgv_Journal_Input.Rows[0].Cells["149"].Value.ToString(), out var fat);
                return fat;

            }
        }
        private int Påse
        {
            //Hämtar Påse/SpoleNr från raden som skrivs i
            get
            {
                if (dgv_Journal_Input.Rows[0].Cells["177"].Value == null)
                    return 0;
                int.TryParse(dgv_Journal_Input.Rows[0].Cells["177"].Value.ToString(), out var påse);
                return påse;

            }
        }

        private static int OrderID(string? lotnr)
        {
            var orderid = new int();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT TOP(1) OrderID FROM [Order].MainData WHERE orderNr = @ordernr ORDER BY Operation";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@ordernr", lotnr);
                var value = cmd.ExecuteScalar();
                if (value != null)
                    orderid = int.Parse(value.ToString());
            }
            return orderid;
        }
        private static string Date_Blandning(string? lotnr, int fatnr, DateTime dateTime)
        {
            //Hämtar Datum från Blandning_PTFE baserat på vilket FatNr operatören skriver in
            //Om det inte finns ett matchande FatNr i ordern skickas dateTime tillbaka
            //dateTime är det värde operatören har skrivit i, om operatören ej fyllt i datum skickas N/A tillbaks

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT textvalue FROM [Order].Data 
                        WHERE OrderID = @orderid 
                            AND ProtocolDescriptionID = 152 
                            AND uppstart = (SELECT uppstart FROM [Order].Data WHERE OrderID = @orderid AND value = @fatnr AND ProtocolDescriptionID = 149)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID(lotnr));
                cmd.Parameters.AddWithValue("@fatnr", fatnr);
                var value = cmd.ExecuteScalar();
                if (value != null)
                    if (DateTime.TryParse(value.ToString(), out var date))
                        return date.ToString("yyyy-MM-dd");

            }

            if (dateTime > DateTime.MinValue)
                return dateTime.ToString("yyyy-MM-dd");
            return "N/A";
        }
        private static string Measureprotocol_Date_Sintring(string? lotnr, int påse)
        {
            // Hämtar Datum från Mätprotokollet baserat på vilket PåsNr operatören skriver in
            //Om det inte finns ett matchande PåsNr i Mätprotokollet skickas N/A tillbaka.

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT Date FROM Measureprotocol.MainData AS main
                        INNER JOIN Measureprotocol.Data AS data
                            ON main.OrderID = data.OrderID
                                AND main.RowIndex = data.RowIndex
                        WHERE main.OrderID = @orderid 
                        AND Value = @påse AND DescriptionID = 37 AND Discarded = 'False'";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID(lotnr));
                cmd.Parameters.AddWithValue("@påse", påse);
                var value = cmd.ExecuteScalar();
                if (value != null)
                    if (DateTime.TryParse(value.ToString(), out var date))
                        return date.ToString("yyyy-MM-dd");
            }

            return "N/A";
        }
        private static string Nafta_Percent(string? lotnr, int fatnr)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT value FROM [Order].Data 
                        WHERE OrderID = @orderid 
                            AND ProtocolDescriptionID = 154 
                            AND uppstart = (SELECT uppstart FROM [Order].Data WHERE OrderID = @orderid AND value = @fatnr AND ProtocolDescriptionID = 149)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID(lotnr));
                cmd.Parameters.AddWithValue("@fatnr", fatnr);
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return value.ToString();
            }

            return null;
        }
        private static string Measureprotocol_Sign(string? lotnr, int påse)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT Sign FROM Measureprotocol.MainData AS main
                        INNER JOIN Measureprotocol.Data AS data
                            ON main.OrderID = data.OrderID
                                AND main.RowIndex = data.RowIndex
                        WHERE main.OrderID = @orderid 
                        AND Value = @påse AND DescriptionID = 37 AND Discarded = 'False'";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID(lotnr));
                cmd.Parameters.AddWithValue("@påse", påse);
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return value.ToString();
            }

            return null;
        }
        private static string Korprotokoll_Extruder(string? lotnr)
        {
            //Hämtar Extruder från Extrudering_PTFE baserat på vilket ordernr operatören skriver in
            //Om det inte finns extruder i ordern skickas N/A tillbaka.
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT TOP(1) textvalue FROM [Order].Data
                        WHERE OrderID = @orderid 
                        AND ProtocolDescriptionID = 80
                        ORDER BY uppstart";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID(lotnr));
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return value.ToString();
            }

            return "N/A";
        }
        private static string Measureprotocol_Ugn(string? lotnr, int påse)
        {
            //Hämtar Ugn_Nr från Mätprotokoll baserat på vilket ordernr samt PåsNr operatören skriver in
            //Om det inte finns matchande nr i ordern skickas N/A tillbaka.
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT Value FROM Measureprotocol.MainData AS main
                        INNER JOIN Measureprotocol.Data AS data
                            ON main.OrderID = data.OrderID
                                AND main.RowIndex = data.RowIndex
                        WHERE main.OrderID = @orderid 
                        AND Value = @påse AND DescriptionID = 56 AND Discarded = 'False'";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", OrderID(lotnr));
                cmd.Parameters.AddWithValue("@påse", påse);
                var value = cmd.ExecuteScalar();
                if (value != null)
                    return value.ToString();
            }

            return "N/A";
        }
        //private int Extra_Label_Width(IEnumerable<int> columns)
        //{
        //    var width = columns.Where(column => dgv_Journal_Input.Columns[column].Visible).Sum(column => dgv_Journal_Input.Columns[column].Width);
        //    return width + 1;
        //}
        private int Extra_Label_Width(IEnumerable<string> columns)
        {
            var width = columns.Where(column => dgv_Journal_Input.Columns[column].Visible).Sum(column => dgv_Journal_Input.Columns[column].Width);
            return width + 1;
        }


        public Journal_Spolning_PTFE()
        {
            InitializeComponent();
        }
        private void Journal_Spolning_PTFE_Load(object sender, EventArgs e)
        {
            Load_TemplateRules_Spolning();
        }

        private void Add_Extra_InfoLabels()
        {
            var lbl_Blandning = new Label
            {
                Text = "BLANDNING",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = InputBoxes_Width[0] + InputBoxes_Width[1] + InputBoxes_Width[2] + InputBoxes_Width[3],
                Width = Extra_Label_Width(new[] { "178", "147", "149", "154" }),
                BorderStyle = BorderStyle.FixedSingle
            };
            var lbl_Blandning_2 = new Label
            {
                Text = "BLANDNING STRIPES",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = InputBoxes_Width[0] + InputBoxes_Width[1] + InputBoxes_Width[2] + +InputBoxes_Width[3] + lbl_Blandning.Width - 1,
                Width = Extra_Label_Width(new[] { "200", "197", "198", "199" }),
                BorderStyle = BorderStyle.FixedSingle
            };
            var lbl_Extr_Sintr = new Label
            {
                Text = "EXTRUDER OCH SINTRING",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = InputBoxes_Width[0] + InputBoxes_Width[1] + InputBoxes_Width[2] + InputBoxes_Width[3] + lbl_Blandning.Width - 1 + lbl_Blandning_2.Width - 1,
                Width = Extra_Label_Width(new[] { "182", "183", "184", "202" }),
                BorderStyle = BorderStyle.FixedSingle
            };
            var lbl_Kontrollspolning = new Label
            {
                Text = "KONTROLLSPOLNING",
                TextAlign = ContentAlignment.MiddleCenter,
                Left = InputBoxes_Width[0] + InputBoxes_Width[1] + InputBoxes_Width[2] + InputBoxes_Width[3] + lbl_Blandning.Width - 1 + lbl_Blandning_2.Width - 1 + lbl_Extr_Sintr.Width - 1,
                Width = Extra_Label_Width(new[] { "187", "188", "189", "190", "191", "171", "157", "158" }),
                BorderStyle = BorderStyle.FixedSingle
            };

            panel_ExtraInfoLabels.Controls.Add(lbl_Blandning);
            panel_ExtraInfoLabels.Controls.Add(lbl_Blandning_2);
            panel_ExtraInfoLabels.Controls.Add(lbl_Extr_Sintr);
            panel_ExtraInfoLabels.Controls.Add(lbl_Kontrollspolning);

        }
        private void Hide_Stripes_Columns()
        {
            dgv_Journal.Columns["200"].Visible = dgv_Journal_Input.Columns["200"].Visible = false;
            dgv_Journal.Columns["197"].Visible = dgv_Journal_Input.Columns["197"].Visible = false;
            dgv_Journal.Columns["198"].Visible = dgv_Journal_Input.Columns["198"].Visible = false;
            dgv_Journal.Columns["199"].Visible = dgv_Journal_Input.Columns["199"].Visible = false;
        }
        public void Load_Info()
        {
            dgv_Journal.Columns.Clear();
            dgv_Journal_Input.Columns.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT DISTINCT 
                        descr.CodeText, 
                        unit.UnitName AS Unit,
                        template.RowIndex, 
                        template.ColumnIndex, 
                        template.Type, 
                        template.Decimals, 
                        template.ProtocolDescriptionID
                    FROM Protocol.Template AS template
                        JOIN Protocol.Description AS descr ON descr.Id = template.ProtocolDescriptionID
                        LEFT JOIN Protocol.Unit AS unit ON unit.Id = descr.UnitID
                    WHERE template.FormTemplateID = 
                    (
                        SELECT FormTemplateID 
                        FROM Protocol.FormTemplate 
                        WHERE MainTemplateID = @protocolmaintemplateid
                    )
                    ORDER BY template.ColumnIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@protocolmaintemplateid", Templates_Protocol.MainTemplate.ID);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var reader = cmd.ExecuteReader();
                var ctr = 0;

                while (reader.Read())
                {
                    var name = reader["ProtocolDescriptionID"].ToString();
                    var col_Input = new DataGridViewTextBoxColumn
                    {
                        HeaderText = reader[0].ToString(),
                        Name = reader["ProtocolDescriptionID"].ToString(),
                        CellTemplate = new DataGridViewTextBoxCell(),
                        Width = InputBoxes_Width[ctr],
                    };

                    var col1 = new DataGridViewColumn
                    {
                        HeaderText = reader[0].ToString(),
                        Name = reader["ProtocolDescriptionID"].ToString(),
                        CellTemplate = new DataGridViewTextBoxCell(),
                        Width = InputBoxes_Width[ctr],

                    };
                    ctr++;
                    dgv_Journal_Input.Columns.Add(col_Input);
                    dgv_Journal.Columns.Add(col1);
                }
            }

            var IsOkShowRowIndex = Person.Role == "SuperAdmin";

            // ReSharper disable once PossibleNullReferenceException
            ((DataGridViewTextBoxColumn)dgv_Journal_Input.Columns["187"]).MaxInputLength = 1;
            // ReSharper disable once PossibleNullReferenceException
            ((DataGridViewTextBoxColumn)dgv_Journal_Input.Columns["189"]).MaxInputLength = 1;
            var col = new DataGridViewColumn
            {
                Name = "RowIndex",
                CellTemplate = new DataGridViewTextBoxCell(),
                Visible = IsOkShowRowIndex

            };
            dgv_Journal.Columns.Add(col);
            dgv_Journal_Input.Rows.Add();

            Width = dgv_Journal_Input.Width;

            if (Part.IsPartNrSpecial == false)
                Hide_Stripes_Columns();

            Add_Extra_InfoLabels();
        }
        public void Load_Data()
        {
            dgv_Journal.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                        SELECT DISTINCT Uppstart, Value, TextValue, ColumnIndex, template.Type, template.Decimals
                        FROM [Order].Data AS protocol
	                        JOIN Protocol.Template as template
		                        ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
	                        JOIN Protocol.Description as descr
		                        ON descr.id = template.ProtocolDescriptionID
                        WHERE OrderID = @orderid
                            AND FormTemplateID = (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @protocolmaintemplateid)
                        ORDER BY uppstart, ColumnIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@formtemplateid", 13);
                cmd.Parameters.AddWithValue("@protocolmaintemplateid", Templates_Protocol.MainTemplate.ID);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int.TryParse(reader["Type"].ToString(), out var type);
                    int.TryParse(reader["Uppstart"].ToString(), out var row);

                    int.TryParse(reader["ColumnIndex"].ToString(), out var col);
                    if (col == 0)
                        dgv_Journal.Rows.Add();

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
                        case 2:
                            value = "\u221A";
                            break;
                        case 1:
                        case 3:
                            value = reader["TextValue"].ToString();
                            break;
                    }

                    if (string.IsNullOrEmpty(value))
                        value = "N/A";

                    dgv_Journal.Rows[dgv_Journal.Rows.Count - 1].Cells[col].Value = value;
                    dgv_Journal.Rows[dgv_Journal.Rows.Count - 1].Cells["RowIndex"].Value = row;
                }
            }
        }
        private void Load_TemplateRules_Spolning()
        {
            dict_TemplateRules.Clear();

            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();

            var query = @"
                SELECT t.ColumnIndex, t.Type, t.Decimals, t.MaxChars
                FROM Protocol.Template t
                WHERE t.FormTemplateID = (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @mainID)";

            using var cmd = new SqlCommand(query, con);
            ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@mainID", Templates_Protocol.MainTemplate.ID);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var colIndex = Convert.ToInt32(reader["ColumnIndex"]);
                var type = Convert.ToInt32(reader["Type"]);
                int? decimals = reader["Decimals"] == DBNull.Value ? null : Convert.ToInt32(reader["Decimals"]);
                int? maxchars = reader["MaxChars"] == DBNull.Value ? null : Convert.ToInt32(reader["MaxChars"]);

                //if (colIndex.HasValue)
                dict_TemplateRules[colIndex] = (type, decimals, maxchars);
            }
        }
        private static int Last_StartUp
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT MAX(Uppstart) FROM [Order].Data WHERE OrderID = @orderid";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    var value = cmd.ExecuteScalar();
                    if (value is null)
                        return 0;
                    if (int.TryParse(value.ToString(), out var startUp))
                        return startUp;
                    return 0;
                }
            }
        }
        private void SaveRow_Click(object sender, EventArgs e)
        {
            if (!Person.IsPasswordOk("Bekräfta överföringen med ditt lösenord."))
                return;
            Activity.Start();
            //Om raden editeras raderas här den förra raden 
            if (EditRow != null)
                DeleteRow();

            dgv_Journal_Input.Rows[0].Cells["157"].Value = Person.Sign;
            dgv_Journal_Input.Rows[0].Cells["158"].Value = Person.EmployeeNr;

            var now = DateTime.Now;
            dgv_Journal_Input.Rows[0].Cells["171"].Value = now.ToString("yyyy-MM-dd HH:mm");
            var uppstart = Last_StartUp + 1;
            foreach (DataGridViewColumn column in dgv_Journal_Input.Columns)
            {
                var cell = dgv_Journal_Input.Rows[0].Cells[column.Index];
                var pcID = Protocol_Description.Protocol_Description_ID_Col(column.Index, 13);
                var type = Module.DatabaseManagement.ValueType(pcID, 13);

                if (EditRow != null)
                    uppstart = (int)EditRow;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, Uppstart, Ugn, Value, TextValue, BoolValue)
                        VALUES (@orderid, @protocoldescriptionid, @uppstart, NULL, @value, @textvalue, @boolvalue)";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", pcID);
                    cmd.Parameters.AddWithValue("@uppstart", uppstart);

                    switch (type)
                    {
                        case 0: //NumberValue
                            SQL_Parameter.Double(cmd.Parameters, "@value", cell.Value);
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                            break;
                        case 1: //TextValue
                        case 3: //Date
                            if (cell.Value != null)
                                SQL_Parameter.String(cmd.Parameters, "@textvalue", cell.Value.ToString());
                            else
                                cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@value", DBNull.Value);
                            cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                            break;
                        case 2: //Bool
                            SQL_Parameter.Boolean(cmd.Parameters, "@boolvalue", "True");
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                            cmd.Parameters.AddWithValue("@value", DBNull.Value);
                            break;
                    }
                    cmd.ExecuteNonQuery();
                }

            }
            _ = Activity.Stop($"Användare överför mätning Uppstart = {uppstart}. TotalRows = {dgv_Journal.Rows.Count}");
            dgv_Journal_Input.Rows.Clear();
            Load_Data();
            dgv_Journal_Input.Rows.Add();
            warning?.Close();
            EditRow = null;
            btn_EditRow.Enabled = true;
        }
        private void EditRow_Click(object sender, EventArgs e)
        {
            dgv_Journal_Input.CellValueChanged -= Journal_Input_CellValueChanged;
            btn_EditRow.Enabled = false;
            var row = (int)dgv_Journal.Rows[dgv_Journal.CurrentCell.RowIndex].Cells["RowIndex"].Value;
            EditRow = row;
            row_User = dgv_Journal.Rows[dgv_Journal.CurrentCell.RowIndex].Cells["157"].Value.ToString();//157=Sign
            if (row_User != Person.Sign)
            {
                InfoText.Show("Du kan inte redigera någon annans rad.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }

            warning = new Warning("Kom ihåg att spara raden annars försvinner den!", 75);
            warning.Show();

            for (var col = 0; col < dgv_Journal.Columns.Count - 1; col++)
                dgv_Journal_Input.Rows[0].Cells[col].Value = dgv_Journal.Rows[dgv_Journal.CurrentCell.RowIndex].Cells[col].Value;

            dgv_Journal.Rows.RemoveAt(dgv_Journal.CurrentCell.RowIndex);


            _ = Activity.Stop($"Användare {Person.Name} redigerade rad {row}");

            dgv_Journal_Input.CellValueChanged += Journal_Input_CellValueChanged;
        }

        private void DeleteRow()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"DELETE FROM [Order].Data WHERE OrderID = @orderid AND Uppstart = @row";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@row", EditRow);

                cmd.ExecuteNonQuery();
            }
        }
        private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += AllowedChars_KeyPress_Spolning_PTFE;
            tb.ShortcutsEnabled = false;
        }
        private void AllowedChars_KeyPress_Spolning_PTFE(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            var colIndex = dgv_Journal_Input.CurrentCell.ColumnIndex;
            var colName = dgv_Journal_Input.Columns[colIndex].Name;
            int.TryParse(colName, out int protocolDescriptionID);

            // Spärrade kolumner
            if (protocolDescriptionID is 178 or 182 or 187 or 157 or 158)
            {
                string msg = protocolDescriptionID switch
                {
                    178 or 182 => "Klicka i rutan för att välja datum.",
                    187 => "Klicka i denna ruta för att bekräfta att slangen är ok.",
                    157 or 158 => "Denna ruta fylls i automatiskt när du Sparar raden.",
                    _ => "Denna ruta är spärrad."
                };

                InfoText.Show(msg, CustomColors.InfoText_Color.Warning, "Warning!", this);
                e.Handled = true;

                // Hoppa vidare till nästa kolumn
                int nextCol = protocolDescriptionID switch
                {
                    187 => colIndex + 1,
                    157 or 158 => dgv_Journal_Input.Columns.Contains("192") ? dgv_Journal_Input.Columns["192"].Index : colIndex + 1,
                    _ => colIndex + 1
                };

                if (nextCol < dgv_Journal_Input.Columns.Count)
                    dgv_Journal_Input.CurrentCell = dgv_Journal_Input.Rows[0].Cells[nextCol];

                return;
            }

            // Begränsa specifikt för 189 och 191 (bara 1,2,3)
            if (protocolDescriptionID is 189 or 191)
            {
                if (e.KeyChar is not ('1' or '2' or '3'))
                    e.Handled = true;
                return;
            }

            // Validera mot regler
            if (dict_TemplateRules.TryGetValue(colIndex, out var rule))
            {
                var (type, decimals, _) = rule;

                switch (type)
                {
                    case 0: // Numerisk
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
                    case 2: // Alfanum
                        e.Handled = false;
                        break;

                    default:
                        e.Handled = true;
                        break;
                }
            }
            else
            {
                // Kolumn finns ej i mall: blockera
                e.Handled = true;
            }
        }

        private void Journal_Input_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            List<string?> items = null;
            var protocoldescriptionid = int.Parse(dgv_Journal_Input.Columns[e.ColumnIndex].Name);
            switch (protocoldescriptionid)
            {
                case 147: //BatchNr
                case 197: //BatchNr - Stripes
                    items = Blandning_LotNr;
                    break;
                default:
                    return;
            }

            if (items is null)
                return;
            var choose_Item = new Choose_Item(items, new[] { dgv_Journal_Input.Rows[0].Cells[e.ColumnIndex] }, null, 0, 0, true);
            choose_Item.ShowDialog();
        }
        private void Journal_Input_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var protocoldescriptionid = int.Parse(dgv_Journal_Input.Columns[e.ColumnIndex].Name);
            switch (protocoldescriptionid)
            {
                case 177: //SpoleNr
                    dgv_Journal_Input.Rows[0].Cells["182"].Value = Measureprotocol_Date_Sintring(Order.OrderNumber, Påse);
                    dgv_Journal_Input.Rows[0].Cells["183"].Value = Korprotokoll_Extruder(Order.OrderNumber);
                    dgv_Journal_Input.Rows[0].Cells["184"].Value = Measureprotocol_Ugn(Order.OrderNumber, Påse);
                    // dgv_Journal_Input.Rows[0].Cells[Protocol_Description.Codetext(202)].Value = Measureprotocol_Sign(Order.OrderNumber, Påse);
                    break;
                case 147: //BatchNr
                case 149: //FatNr
                    if (!string.IsNullOrEmpty(Lotnr) && Fatnr > 0)
                    {
                        var date = new DateTime();
                        if (dgv_Journal_Input.Rows[0].Cells["178"].Value != null)
                            DateTime.TryParse(dgv_Journal_Input.Rows[0].Cells["178"].Value.ToString(), out date);
                        dgv_Journal_Input.Rows[0].Cells["178"].Value = Date_Blandning(Lotnr, Fatnr, date);//Hämtar Blandningsdatum
                        dgv_Journal_Input.Rows[0].Cells["154"].Value = Nafta_Percent(Lotnr, Fatnr);
                    }
                    break;
                case 183:     //Extr.Nr
                case 184:    //UgnNr
                    if (!string.IsNullOrEmpty(Lotnr) && Fatnr > 0)
                    {
                        var date = new DateTime();
                        if (dgv_Journal_Input.Rows[0].Cells["200"].Value != null)
                            DateTime.TryParse(dgv_Journal_Input.Rows[0].Cells["200"].Value.ToString(), out date);
                        dgv_Journal_Input.Rows[0].Cells["200"].Value = Date_Blandning(Lotnr, Fatnr, date);
                        dgv_Journal_Input.Rows[0].Cells["199"].Value = Nafta_Percent(Lotnr, Fatnr);
                    }
                    break;
            }
        }
        private void Journal_Input_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var col = e.ColumnIndex;
            var protocoldescriptionid = int.Parse(dgv_Journal_Input.Columns[col].Name);
            switch (protocoldescriptionid)
            {
                case 178:     //Blandning Datum
                case 182:    //Sintring Datum
                    var date = new DatePicker(string.Empty, true);
                    date.ShowDialog();
                    dgv_Journal_Input.Rows[0].Cells[col].Value = date.OutGoingDate;
                    break;
                case 187:    //a) Bra slang
                    if (dgv_Journal_Input.Rows[0].Cells[col].Value is null || string.IsNullOrEmpty(dgv_Journal_Input.Rows[0].Cells[col].Value.ToString()))
                        dgv_Journal_Input.Rows[0].Cells[col].Value = "\u221A";
                    else
                        dgv_Journal_Input.Rows[0].Cells[col].Value = string.Empty;
                    break;
            }
        }

        private void CopyRow_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = e.RowIndex;
            for (var i = 0; i < dgv_Journal.Columns.Count - 5; i++)
                if (dgv_Journal.Rows[row].Cells[i].Value != null)
                    dgv_Journal_Input.Rows[0].Cells[i].Value = dgv_Journal.Rows[row].Cells[i].Value.ToString();
            _ = Activity.Stop($"Användare kopierar rad #{row}");
        }

        private void dgv_Journal_Input_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var headerCell = dgv_Journal_Input.Columns[e.ColumnIndex].HeaderCell;
            var sortDirection = ListSortDirection.Ascending;

            if (headerCell.SortGlyphDirection == SortOrder.Ascending)
                sortDirection = ListSortDirection.Descending;

            dgv_Journal.Sort(dgv_Journal.Columns["RowIndex"], sortDirection);
        }

        
    }
}
