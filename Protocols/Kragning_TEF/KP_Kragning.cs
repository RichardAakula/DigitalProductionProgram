using System;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;

using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.Kragning_TEF
{
    public partial class KP_Kragning : UserControl
    {
        private const int FormTemplateID = 8;
        private bool IsParametrarFilled
        {
            get
            {
                foreach (DataGridViewColumn column in dgv_Korprotokoll_Inputdata.Columns)
                {
                    var cell = dgv_Korprotokoll_Inputdata.Rows[0].Cells[column.Index];
                    if (cell.Value == null)
                        return false;
                    if (string.IsNullOrEmpty(cell.Value.ToString()))
                        return false;
                }
                return true;
            }
        }
        public DataGridView dgv_Processkort;
        private string? Min(int col)
        {
            return dgv_Processkort.Rows[0].Cells[col].Value is null ? null : dgv_Processkort.Rows[0].Cells[col].Value.ToString();
        }
        private string? Nom(int col)
        {
            return dgv_Processkort.Rows[1].Cells[col].Value is null ? null : dgv_Processkort.Rows[1].Cells[col].Value.ToString();
        }
        private string? Max(int col)
        {
            return dgv_Processkort.Rows[2].Cells[col].Value is null ? null : dgv_Processkort.Rows[2].Cells[col].Value.ToString();
        }


        public KP_Kragning()
        {
            InitializeComponent();
           
            dgv_Korprotokoll_Inputdata.CellDoubleClick += ControlManager.Write_NA_CellDoubleClick;
            dgv_Korprotokoll_Inputdata.Rows.Add();
            dgv_Korprotokoll.MouseWheel += DataGridView_Parametrar_MouseWheel;
        }

        public void Load_Data()
        {
            Module.IsOkToSave = false;

            dgv_Korprotokoll.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        SELECT DISTINCT Value, TextValue, BoolValue, Uppstart, Ugn, RowIndex, template.Type, template.Decimals, descr.id
                        FROM [Order].Data AS protocol
	                        JOIN Protocol.Template as template
		                        ON protocol.ProtocolDescriptionID = template.ProtocolDescriptionID
	                        JOIN Protocol.Description as descr
		                        ON descr.id = template.ProtocolDescriptionID
                        WHERE OrderID = @orderid
	                        AND FormTemplateID = (SELECT FormTemplateID FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateid)
	                        AND uppstart IS NOT NULL
                        ORDER BY uppstart, RowIndex";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                var reader = cmd.ExecuteReader();

                var IsRowDiscarded = false;
                while (reader.Read())
                {
                    int.TryParse(reader["Uppstart"].ToString(), out var uppstart);
                    int.TryParse(reader["RowIndex"].ToString(), out var col);
                    int.TryParse(reader["id"].ToString(), out var description_id);


                    if (uppstart > dgv_Korprotokoll.Rows.Count)
                    {
                        dgv_Korprotokoll.Rows.Add();
                        IsRowDiscarded = false;
                    }

                    int.TryParse(reader["Type"].ToString(), out var type);
                   
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
                        case 2:
                            if (description_id == 174)
                            {
                                if (bool.TryParse(reader["BoolValue"].ToString(), out IsRowDiscarded))
                                    continue;
                            }

                            break;
                        case 3:
                            DateTime.TryParse(reader["TextValue"].ToString(), out var date);
                            value = date.ToString("yyyy-MM-dd HH:mm");
                            break;
                    }

                    if (string.IsNullOrEmpty(value))
                        value = "N/A";
                    dgv_Korprotokoll.Rows[uppstart - 1].Cells[col].Value = value;
                    var cell = dgv_Korprotokoll.Rows[uppstart -1].Cells[col];
                   
                    if (col < 8)
                        Validate_Data.ValidateData(cell, uppstart - 1, true, FormTemplateID, 0,Min(col), Nom(col), Max(col));

                    if (IsRowDiscarded)
                    {
                        cell.Style.BackColor = CustomColors.Bad_Back;
                        cell.Style.ForeColor = CustomColors.Bad_Front;
                        cell.Style.Font = new Font(dgv_Korprotokoll.DefaultCellStyle.Font, FontStyle.Strikeout);
                    }
                }
            }

            dgv_Korprotokoll.ClearSelection();

            Module.IsOkToSave = true;
        }
        private void Save_Data()
        {
            Points.Add_Points(7, "Överför Parametrar, Kragning");
            var uppstart = dgv_Korprotokoll.Rows.Count + 1;

            foreach (DataGridViewColumn column in dgv_Korprotokoll_Inputdata.Columns)
            {
                var cell = dgv_Korprotokoll_Inputdata.Rows[0].Cells[column.Index];
                var protocol_Description_ID = Protocol_Description.Protocol_Description_ID_Row(cell.ColumnIndex, 8);
                var type = Module.DatabaseManagement.ValueType(protocol_Description_ID, 8);
                
                INSERT_Data(dgv_Korprotokoll, protocol_Description_ID, uppstart, cell.Value.ToString(), type);
            }

            var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            INSERT_Data(dgv_Korprotokoll, 171, uppstart, date, 3);
            INSERT_Data(dgv_Korprotokoll, 158, uppstart, Person.EmployeeNr, 0);
            INSERT_Data(dgv_Korprotokoll, 157, uppstart, Person.Sign, 1);
        }

        public static void INSERT_Data(DataGridView dgv_Korprotokoll, int? Protocol_Description_ID, int uppstart, string? value, int type)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                string query;
                    if (uppstart == 0)
                        query = @"
                    IF NOT EXISTS (SELECT * FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid)
                        INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, value, textvalue)
                        VALUES (@orderid, @protocoldescriptionid, @value, @textvalue)
                    ELSE
                         UPDATE [Order].Data 
                            SET value = @value, textvalue = @textvalue
                        WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid";
                    else
                        query = @"
                    IF NOT EXISTS (SELECT * FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid AND Uppstart = @uppstart)
                        INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, uppstart, value, textvalue)
                        VALUES (@orderid, @protocoldescriptionid, @uppstart, @value, @textvalue)
                    ELSE
                        UPDATE [Order].Data 
                            SET value = @value, textvalue = @textvalue
                        WHERE OrderID = @orderid AND ProtocolDescriptionID = @protocoldescriptionid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@protocoldescriptionid", Protocol_Description_ID);
                if (uppstart == 0)
                    cmd.Parameters.AddWithValue("@uppstart", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@uppstart", uppstart);
                switch (type)
                {
                    case 0://NumberValue
                        SQL_Parameter.Double(cmd.Parameters, "@value", value);
                        cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                        break;
                    case 1://TextValue
                        if (value != null)
                            SQL_Parameter.String(cmd.Parameters, "@textvalue", value);
                        else
                            cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                        cmd.Parameters.AddWithValue("@value", DBNull.Value);
                        break;
                    case 3: //DateTime
                        if (value != null)
                            SQL_Parameter.String(cmd.Parameters, "@textvalue", value);
                        cmd.Parameters.AddWithValue("@value", DBNull.Value);
                        break;
                }

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void Transfer_Click(object sender, EventArgs e)
        {
            if (!IsParametrarFilled)
            {
                InfoText.Show("Fyll i alla parametrar före du överför.", CustomColors.InfoText_Color.Bad, "Varning!");
                return;
            }
            if (!Person.IsUserSignedIn(true))
                return;

            var black = new BlackBackground(string.Empty, 80);
            var password = new PasswordManager(LanguageManager.GetString("confirmTransferPassword"));
            black.Show();
            password.ShowDialog();
            black.Close();
            if (password.IsOk == false)
                return;

            Save_Data();
            foreach (DataGridViewRow row in dgv_Korprotokoll_Inputdata.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = "";
                    cell.Style.BackColor = Color.White;
                    cell.Style.ForeColor = Color.DarkSlateGray;
                }
            }
            Load_Data();
        }
        private void Kassera_Rad_Click(object sender, EventArgs e)
        {
            
            InfoText.Question("Vill du kassera denna rad?", CustomColors.InfoText_Color.Info,"Warning!", this);
            if (InfoText.answer == InfoText.Answer.Yes)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, uppstart, BoolValue)
                        VALUES (@orderid, @protocoldescriptionid, @uppstart, 'True')";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@protocoldescriptionid", 174);
                    cmd.Parameters.AddWithValue("@uppstart", dgv_Korprotokoll.CurrentCell.RowIndex + 1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                Load_Data();
            }
        }


        private void EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += AllowedChars_KeyPress;
        }
        private void AllowedChars_KeyPress(object sender, KeyPressEventArgs e)
        {
            var col = dgv_Korprotokoll_Inputdata.CurrentCell.ColumnIndex;
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            switch (col)
            {
                case 0: case 1: case 4: case 6: case 7://Decimaltal
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '-')
                    {
                        e.Handled = true;
                        return;
                    }
                    e.Handled = false;
                    return;
                case 2: case 3: //Integer
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                    {
                        e.Handled = true;
                        return;
                    }
                    e.Handled = false;
                    return;
                default:
                    e.Handled = false;
                    return;
            }
        }
        private void DataGridView_Parametrar_MouseWheel(object sender, MouseEventArgs e)
        {
            var currentIndex = dgv_Korprotokoll.FirstDisplayedScrollingRowIndex;
            var scrollLines = SystemInformation.MouseWheelScrollLines;

            try
            {
                if (e.Delta > 0)
                {
                    dgv_Korprotokoll.FirstDisplayedScrollingRowIndex
                        = Math.Max(0, currentIndex - scrollLines);
                }
                else if (e.Delta < 0)
                {
                    dgv_Korprotokoll.FirstDisplayedScrollingRowIndex
                        = currentIndex + scrollLines;
                }
            }
            catch { }
        }
        private void dgv_Korprotokoll_Leave(object sender, EventArgs e)
        {
            dgv_Korprotokoll.ClearSelection();
        }
        private void CellLeave_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgv_Korprotokoll_Inputdata.CurrentCell.RowIndex;
            var col = dgv_Korprotokoll_Inputdata.CurrentCell.ColumnIndex;
            var cell = dgv_Korprotokoll_Inputdata.Rows[row].Cells[col];
            Validate_Data.ValidateData(cell, col,  true, FormTemplateID, 0, Min(col), Nom(col), Max(col));
        }
    }
}
