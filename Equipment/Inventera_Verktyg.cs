using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Equipment
{
    public partial class Inventera_Verktyg : Form
    {
        private DataTable dataTable = new DataTable();
        private  DataTable dt_Verktyg_Inventeringar()
        {
            var dt = new DataTable();
            using (var con = new SqlConnection(Database.cs_ToolRegister))
            {
                var query = "SELECT Dimension AS Dim, Datum, Namn FROM Register_Verktyg_Inventering WHERE ID_Nummer = @idNummer AND Typ = @typ ORDER BY Datum DESC";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idNummer", lbl_ID_Nummer.Text);
                cmd.Parameters.AddWithValue("@typ", label_Typ.Text);
                con.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }
        private string sort;
        public static string Verktyg_Dim_OrderNr(string sort)
        {
            using (var con = new SqlConnection(Database.cs_ToolRegister))
            {
                var query = "SELECT Dimension FROM Register_Verktyg_Inventering WHERE Sort = @sort AND OrderNr = @ordernr AND Operation = @operation";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                cmd.Parameters.AddWithValue("@sort", sort);
                try
                {
                    return cmd.ExecuteScalar().ToString();
                }
                catch { return string.Empty; }
            }
        }
        private static bool IsMåttOk(string mått, double min, double max, double value)
        {
            if ((value > max || value < min) && value > 0)
            {
                InfoText.Show($"VARNING!\n\n{mått} är utanför spec, du bör byta verktyg och kontakta din arbetsledare", CustomColors.InfoText_Color.Bad, null);
                return false;
            }
            return true;
        }
        public static bool IsInventering_Done(string typ, string id_nummer)
        {
            using (var con = new SqlConnection(Database.cs_ToolRegister))
            {
                var query = "SELECT * FROM Register_Verktyg_Inventering WHERE Typ = @typ AND ID_Nummer = @idnummer AND OrderNr = @ordernr AND Operation = @operation";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ordernr", Order.OrderNumber);
                cmd.Parameters.AddWithValue("@operation", Order.Operation);
                cmd.Parameters.AddWithValue("@typ", typ);
                cmd.Parameters.AddWithValue("@idnummer", id_nummer);
                con.Open();
                var reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }
        public static bool IsToolMeasured(string sort)
        {
            using (var con = new SqlConnection(Database.cs_ToolRegister))
            {
                const string query = @"SELECT * FROM Register_Verktyg_Inventering WHERE Sort = @sort AND OrderNr = @ordernr AND Operation = @operation";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@sort", sort);
                cmd.Parameters.AddWithValue("@ordernr", Order.OrderNumber);
                cmd.Parameters.AddWithValue("@operation", Order.Operation);

                con.Open();
                var reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }
        public  bool IsUserCanceled = true;


        public Inventera_Verktyg(string id_Nummer, string typ)
        {
            InitializeComponent();
            
            lbl_ID_Nummer.Text = id_Nummer;
            label_Typ.Text = typ;
            if (!string.IsNullOrEmpty(id_Nummer))
            {
                Load_Data_dgv_Inventering();
                Load_Data();
            }
            else
                Close();

            if (dataTable.Rows.Count > 0)
                Initialize_dgv_Inventering();
            Log.Activity.Start();
        }

        private void Load_Data_dgv_Inventering()
        {
            dataTable = dt_Verktyg_Inventeringar();
        }
        private void Load_Data()
        {
            using (var con = new SqlConnection(Database.cs_ToolRegister))
            {
                var query = "SELECT Sort, Dimension_min, Dimension_max FROM Register_Verktyg WHERE ID_Nummer = @idNummer AND Typ = @typ";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idNummer", lbl_ID_Nummer.Text);
                cmd.Parameters.AddWithValue("@typ", label_Typ.Text);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sort = reader["Sort"].ToString();
                    lbl_Dim_min.Text = reader["Dimension_min"].ToString();
                    lbl_Dim_max.Text = reader["Dimension_max"].ToString();
                }
            }
        }

        private void Initialize_dgv_Inventering()
        {
            dgv_Inventering.DataSource = dataTable;

            dgv_Inventering.Columns[0].Width = 50;
            dgv_Inventering.Columns[1].Width = 70;
            // dgv_Inventering.Columns[2].Width = 60;
            //  dgv_Inventering.Columns[3].Width = 100;
        }


        private void Dimension_Leave(object sender, EventArgs e)
        {
            double.TryParse(tb_Dimension.Text, out var dim);
            double.TryParse(lbl_Dim_min.Text, out var dim_min);
            double.TryParse(lbl_Dim_max.Text, out var dim_max);

            if (!IsMåttOk("Dimensionen", dim_min, dim_max, dim))
            {
                tb_Dimension.ForeColor = CustomColors.Bad_Front;
                tb_Dimension.BackColor = CustomColors.Bad_Back;
            }
            else
            {
                tb_Dimension.ForeColor = CustomColors.Ok_Front;
                tb_Dimension.BackColor = CustomColors.Ok_Back;
            }
            if (dim == 0)
            {
                tb_Dimension.ForeColor = Color.White;
                tb_Dimension.BackColor = Color.FromArgb(25, 25, 25);
            }
        }
        private void Mått_SelectText_Click(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            tb.SelectAll();
        }
        private void Klar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tb_Dimension.Text, out var dimension))
            {
                using (var con = new SqlConnection(Database.cs_ToolRegister))
                {
                    var query = @"INSERT INTO Register_Verktyg_Inventering (ID_Nummer, Typ, Sort, Dimension, Datum, Namn, OrderNr, Operation) 
                                        VALUES (@idNummer, @typ, @sort, @dim, @datum, @namn, @ordernr, @op)";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idNummer", lbl_ID_Nummer.Text);
                    cmd.Parameters.AddWithValue("@typ", label_Typ.Text);
                    cmd.Parameters.AddWithValue("@sort", sort);
                    cmd.Parameters.AddWithValue("@dim", dimension);
                    cmd.Parameters.AddWithValue("@datum", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@namn", Person.Name);
                    cmd.Parameters.AddWithValue("@ordernr", Order.OrderNumber);
                    cmd.Parameters.AddWithValue("@op", Order.Operation);

                    con.Open();
                    cmd.ExecuteScalar();
                }
                Close();
                Points.Add_Points(5, "Inventerat Verktyg");
            }
            else
                MessageBox.Show("Något gick fel, kontrollera att du skrivit rätt mått för Dimension.");

            _= Log.Activity.Stop($"{Person.Name} har inventerat {label_Typ.Text} - {lbl_ID_Nummer.Text}.");
            IsUserCanceled = false;
        }
        private void Numbers_Only_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                e.Handled = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inventera_Verktyg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsUserCanceled)
                _= Log.Activity.Stop($"{Person.Name} har INTE inventerat {label_Typ.Text} - {lbl_ID_Nummer.Text}.");
        }
    }
}
