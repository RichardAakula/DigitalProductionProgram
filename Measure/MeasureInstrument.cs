using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.Measure
{
    public partial class MeasureInstrument : UserControl
    {
        public static IEnumerable<string?> List_Mätdon
        {
            get
            {
                var list = new List<string?>();
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();
                var query = @"SELECT * FROM MeasureInstruments.Templates ORDER BY MätdonsNr";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                var reader = cmd.ExecuteReader();
                var row = 0;
                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                    row++;
                }

                return list;
            }
        }
        public bool IsOkDelete_Mätdon(string Mätdon)
        {
            var list_MätdonTemplate = new List<string>();
            var TotalMätdonInTemplate = 0;
            var TotalMätdon = dgv_Mätdon.Rows.Cast<DataGridViewRow>().Count(row => row.HeaderCell.Value.ToString() == Mätdon);


            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                var query = @"SELECT MätdonsNr
                    FROM MeasureInstruments.WorkOperationTemplate as template
                        INNER JOIN MeasureInstruments.Templates as mätdon
	                        ON template.Template_ID = mätdon.ID
                    WHERE WorkOperation = @workoperation
                    ORDER BY MätdonsNr";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation.ToString());
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list_MätdonTemplate.Add(reader[0].ToString());
                    if (reader[0].ToString() == Mätdon)
                        TotalMätdonInTemplate++;
                }
            }
            if (list_MätdonTemplate.Contains(Mätdon) == false)
                return true;

            return TotalMätdon > TotalMätdonInTemplate;
        }




        public MeasureInstrument()
        {
            InitializeComponent();
            dgv_Mätdon.Leave += DataGridView_Leave;
        }


        public void Translate_Form()
        {
            label_MeasureInstrument_Header.Text = LanguageManager.GetString(label_MeasureInstrument_Header.Name);
        }
        public void Load_Data()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                var query = @"SELECT * FROM MeasureInstruments.Mätdon WHERE OrderID = @orderid ORDER BY Mätdon";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var reader = cmd.ExecuteReader();
                var row = 0;
                while (reader.Read())
                {
                    dgv_Mätdon.Rows.Add();
                    dgv_Mätdon.Rows[row].HeaderCell.Value = reader["Mätdon"].ToString();
                    dgv_Mätdon.Rows[row].HeaderCell.Style.BackColor = Color.FromArgb(35, 103, 112);
                    dgv_Mätdon.Rows[row].HeaderCell.Style.ForeColor = Color.FromArgb(187, 215, 228);
                    
                    dgv_Mätdon.Rows[row].Cells[0].Value = reader["Nr"].ToString();
                    dgv_Mätdon.Rows[row].Cells[1].Value = reader["Row"].ToString();
                    row++;
                }

                if (reader.HasRows == false)
                    Add_MeasureInstrumentsFromTemplate();
            }

            dgv_Mätdon.ClearSelection();
        }
        private void Add_MeasureInstrumentsFromTemplate()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();
            const string query = @"
                    SELECT MätdonsNr
                    FROM MeasureInstruments.WorkOperationTemplate as template
                        INNER JOIN MeasureInstruments.Templates as mätdon
	                        ON template.Template_ID = mätdon.ID
                    WHERE WorkOperation = @workoperation
                    ORDER BY MätdonsNr";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation.ToString());
            var reader = cmd.ExecuteReader();
            var row = 0;
            while (reader.Read())
            {
                if (dgv_Mätdon.Columns.Count > 0)
                {
                    dgv_Mätdon.Rows.Add();
                    dgv_Mätdon.Rows[row].HeaderCell.Value = reader["MätdonsNr"].ToString();
                    dgv_Mätdon.Rows[row].Cells[1].Value = row + 1;
                    Save_Mätdon(reader["MätdonsNr"].ToString(), null, row + 1);
                    row++;
                }

            }
        }
        public void Mätdon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (MeasureInformation.IsOpening)
                return;
            var row = e.RowIndex;
            var cell = dgv_Mätdon.CurrentCell;
            string? Value;

            if (cell.Value is null)
                Value = string.Empty;
            else
                Value = cell.Value.ToString();

            var Mätdon = dgv_Mätdon.Rows[row].HeaderCell.Value.ToString();
            var Row = int.Parse(dgv_Mätdon.Rows[row].Cells[1].Value.ToString());

            Save_Mätdon(Mätdon, Value, Row);

        }
        private void Mätdon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgv_Mätdon.CurrentCell.Value = "N/A";
        }
       
        private void DataGridView_Leave(object sender, EventArgs e)
        {
            var dgv = (DataGridView)sender;
            dgv.ClearSelection();
        }

        private static void Save_Mätdon(string Mätdon, string? Nr, int Row)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    IF NOT EXISTS(SELECT * FROM MeasureInstruments.Mätdon WHERE OrderID = @id AND Mätdon = @mätdon AND Row = @row)
                        INSERT INTO MeasureInstruments.Mätdon (OrderID, Mätdon, Nr, Row)
                            VALUES (@id, @mätdon, @nr, @row)
                    ELSE
                        UPDATE MeasureInstruments.Mätdon SET Nr = @nr WHERE OrderID = @id AND Row = @row AND Mätdon = @mätdon";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@id", Order.OrderID);
            cmd.Parameters.AddWithValue("@mätdon", Mätdon);
            SQL_Parameter.String(cmd.Parameters, "@nr", Nr, true);
            cmd.Parameters.AddWithValue("@row", Row);
            cmd.ExecuteNonQuery();
        }
        private void Delete_MeasureInstrument(string MeasureInstrument, int Row)
        {
            if (IsOkDelete_Mätdon(MeasureInstrument))
            {
                InfoText.Question($"{LanguageManager.GetString("measureinstrument_Delete_1")} ({MeasureInstrument})?\n" +
                              $"{LanguageManager.GetString("measureinstrument_Delete_2")}", CustomColors.InfoText_Color.Warning, "Warning!", this);
                if (InfoText.answer == InfoText.Answer.No)
                    return;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        DELETE FROM MeasureInstruments.Mätdon WHERE OrderID = @id AND Row = @row";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    cmd.Parameters.AddWithValue("@mätdon", MeasureInstrument);
                    cmd.Parameters.AddWithValue("@row", Row);
                    cmd.ExecuteNonQuery();
                }
                dgv_Mätdon.Rows.RemoveAt(dgv_Mätdon.CurrentCell.RowIndex);
            }
            else
                InfoText.Show($"{LanguageManager.GetString("measureinstrument_Delete_3")} ({MeasureInstrument}) {LanguageManager.GetString("measureinstrument_Delete_4")}", CustomColors.InfoText_Color.Bad, "Warning", this);
        }

        private void Add_NewMeasureInstrument_Click(object sender, EventArgs e)
        {
            MeasureInformation.IsOpening = true;

            dgv_Mätdon.Rows.Add();

            DataGridViewCell cell = dgv_Mätdon.Rows[^1].HeaderCell;
            using var choose_Item = new Choose_Item(List_Mätdon, new[] {cell});
            choose_Item.ShowDialog();
            if (cell.Value is null || string.IsNullOrEmpty(cell.Value.ToString()))
            {
                dgv_Mätdon.Rows.RemoveAt(dgv_Mätdon.Rows.Count-1);
                return;
            }

            var Row = dgv_Mätdon.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["col_Row"].Value != null)
                .Select(r => Convert.ToInt32(r.Cells["col_Row"].Value))
                .DefaultIfEmpty(0)  // Om tom → starta på 0
                .Max() + 1;

            dgv_Mätdon.Rows[^1].Cells[1].Value = Row;
            Save_Mätdon(cell.Value.ToString(), null, Row);

            MeasureInformation.IsOpening = false;
        }
        private void Discard_Startup_Click(object sender, EventArgs e)
        {
            var Mätdon = dgv_Mätdon.Rows[dgv_Mätdon.CurrentCell.RowIndex].HeaderCell.Value.ToString();
            var Row = int.Parse(dgv_Mätdon.Rows[dgv_Mätdon.CurrentCell.RowIndex].Cells[1].Value.ToString());

            Delete_MeasureInstrument(Mätdon,  Row);
            
        }

        private void Info_Click(object sender, EventArgs e)
        {
            InfoText.Show($@"{LanguageManager.GetString("measureinstrument_Info").Replace("\\n", Environment.NewLine)}", CustomColors.InfoText_Color.Info, "Info", this);
        }

       
    }
}
