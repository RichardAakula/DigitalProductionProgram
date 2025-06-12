using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols
{
    public partial class FrequencyMarking : Form
    {
        private int rowIndex;
        private bool IsRowOk(int row)
        {
            for (var col = 0; col < 4; col++)
            {
                if (dgv_Frekvensmarkering.Rows[row].Cells[col].Value is null)
                    return false;
            }
            return true;
        }
        public static bool IsLäcksökning
        {
            get
            {
                if (Order.PartID is null || Order.OrderID is null)
                    return false;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    //ProtocolDescriptionID = 227 = Läcksökning
                    var query = @"
                        SELECT TextValue
                        FROM [Order].Data
                        WHERE OrderID = @orderid AND ProtocolDescriptionID = 227
                        UNION 
                        SELECT TextValue 
                        FROM Processcard.Data
                        WHERE PartID = @partid
                        AND TemplateID IN (SELECT ID FROM Protocol.Template WHERE ProtocolDescriptionID = 227)";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@partid", Order.PartID);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == "Ja")
                            return true;
                    }
                    return false;
                }

            }
        }

        public FrequencyMarking()
        {
            InitializeComponent();

            MainInfo.Load_Data(Order.OrderID);
            Load_FROM_Frekvensmarkering();
        }


        private void Load_FROM_Frekvensmarkering()
        {
            dgv_Frekvensmarkering.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    SELECT SpolNr, Material_Lot, Antal_hål, Antal_meter, Datum_Tid, Anst_Nr, Sign, TempID, Kasserad
                    FROM [Order].Läcksökning
                    {Queries.WHERE_OrderID}
                    ORDER BY Datum_Tid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgv_Frekvensmarkering.ReadOnly = false;
                    dgv_Frekvensmarkering.Rows.Add();
                    var row = dgv_Frekvensmarkering.Rows.Count - 1;

                    dgv_Frekvensmarkering.Rows[row].Cells[0].Value = reader[0].ToString();
                    dgv_Frekvensmarkering.Rows[row].Cells[1].Value = reader[1].ToString();
                    dgv_Frekvensmarkering.Rows[row].Cells[2].Value = reader[2].ToString();
                    dgv_Frekvensmarkering.Rows[row].Cells[3].Value = reader[3].ToString();
                    dgv_Frekvensmarkering.Rows[row].Cells[4].Value = DateTime.Parse(reader[4].ToString()).ToString("yyyy-MM-dd HH:mm");
                    dgv_Frekvensmarkering.Rows[row].Cells[5].Value = reader[5].ToString();
                    dgv_Frekvensmarkering.Rows[row].Cells[6].Value = reader[6].ToString();
                    dgv_Frekvensmarkering.Rows[row].Cells[7].Value = reader[7].ToString();
                    dgv_Frekvensmarkering.Rows[row].ReadOnly = true;

                    if (bool.Parse(reader[8].ToString()))
                    {
                        for (var i = 0; i < dgv_Frekvensmarkering.Columns.Count; i++)
                        {
                            dgv_Frekvensmarkering.Rows[row].Cells[i].Style.BackColor = CustomColors.Discarded_Back;
                            dgv_Frekvensmarkering.Rows[row].Cells[i].Style.ForeColor = CustomColors.Discarded_Front;
                            dgv_Frekvensmarkering.Rows[row].Cells[i].Style.Font = new Font(dgv_Frekvensmarkering.DefaultCellStyle.Font, FontStyle.Strikeout);
                        }
                    }
                }
            }

            dgv_Frekvensmarkering.Rows.Add();

        }
        private static IEnumerable<string?> List_BatchNr
        {
            get
            {
                var list = new List<string?>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT Halvfabrikat_OrderNr
                            FROM [Order].PreFab WHERE OrderID = @orderid";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(reader[0].ToString());
                }

                return list;
            }
        }

        private void LotNr_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            dgv_Frekvensmarkering.Rows[rowIndex].Cells[1].Value = e.ClickedItem.Text;
        }
        private void Buttons_MouseEnter(object sender, EventArgs e)
        {
            var lbl = (Control)sender;
            lbl.BackColor = Color.White;
            lbl.ForeColor = Color.Black;
        }
        private void Buttons_MouseLeave(object sender, EventArgs e)
        {
            var lbl = (Control)sender;
            lbl.BackColor = Color.Transparent;
            lbl.ForeColor = Color.White;
        }

        private void Save_Frekvensmarkering(int row)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"INSERT INTO [Order].Läcksökning
                    VALUES (@id, @is_Kasserad, @spole, @lotnr, @hål, @meter, @tid, @employeenumber, @sign)";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                cmd.Parameters.AddWithValue("@is_Kasserad", false);
                cmd.Parameters.AddWithValue("@spole", dgv_Frekvensmarkering.Rows[row].Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@lotnr", dgv_Frekvensmarkering.Rows[row].Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@hål", dgv_Frekvensmarkering.Rows[row].Cells[2].Value.ToString());
                cmd.Parameters.AddWithValue("@meter", dgv_Frekvensmarkering.Rows[row].Cells[3].Value.ToString());
                cmd.Parameters.AddWithValue("@tid", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                cmd.Parameters.AddWithValue("@sign", Person.Sign);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void Spara_Click(object sender, EventArgs e)
        {
            if (!Person.IsPasswordOk("Bekräfta överföring med ditt lösenord."))
                return;
            var rowIndex = dgv_Frekvensmarkering.CurrentCell.RowIndex;
            if (dgv_Frekvensmarkering.Rows[rowIndex].ReadOnly)
                return;

            if (IsRowOk(rowIndex))
            {
                Save_Frekvensmarkering(rowIndex);
                dgv_Frekvensmarkering.Rows.Add();
                Load_FROM_Frekvensmarkering();
            }
            else
                InfoText.Show("Fyll i hela raden annars sparas ej datan.", CustomColors.InfoText_Color.Bad, "Warning!", this);
        }
        private void Kassera_Click(object sender, EventArgs e)
        {
            if (dgv_Frekvensmarkering.CurrentRow != null)
            {
                var row = dgv_Frekvensmarkering.CurrentRow.Index;
                if (row == dgv_Frekvensmarkering.Rows.Count)
                {
                    InfoText.Show("Välj en rad före du försöker kassera en mätning.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    return;
                }
                if (dgv_Frekvensmarkering.Rows[row].Cells[1].Value == null)
                {
                    InfoText.Show("Välj en rad som inte är tom", CustomColors.InfoText_Color.Bad, "Warning!", this);
                    dgv_Frekvensmarkering.ClearSelection();
                    return;
                }
                var tempID = int.Parse(dgv_Frekvensmarkering.Rows[row].Cells["dgv_TempID"].Value.ToString());
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "UPDATE [Order].Läcksökning SET Kasserad = 'True' WHERE TempID = @tempID";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@tempID", tempID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            Load_FROM_Frekvensmarkering();
        }

        private void Frekvensmarkering_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Frekvensmarkering.Rows[e.RowIndex].ReadOnly)
                return;
            if (e.ColumnIndex == 1)
            {
                rowIndex = e.RowIndex;
                var items = List_BatchNr.ToList();
                var cells = new[] { dgv_Frekvensmarkering.Rows[e.RowIndex].Cells[e.ColumnIndex] };

                var choose_Item = new Choose_Item(items, cells, null, 0, 0, true, true);
                choose_Item.ShowDialog();

            }
        }
        private void Frekvensmarkering_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= Column_KeyPress;
            var col = dgv_Frekvensmarkering.CurrentCell.ColumnIndex;
            if (col == 0 || col == 2 || col == 3)
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += Column_KeyPress;
                }
            }
        }
        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
