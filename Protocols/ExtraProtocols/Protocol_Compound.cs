using System.Data;
using System.Globalization;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;

namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    public partial class Protocol_Compund : Form
    {
        public static bool IsCompound
        {
            get
            {
                if (Settings.Settings.SpecialPartNumbers.DataTable_SpecialPartNr("Kompoundering").AsEnumerable().Any(row => Order.PartNumber == row.Field<string>("PartNr")))
                    return true;
                return false;

            }
        }

        private readonly BindingSource bs_ProtocolCompound = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();


        public Protocol_Compund()
        {
            InitializeComponent();
            var load = new Load(this);
            load.MainInfo();
            load.KorprotokollInfo();
            load.Halvfabrikat();
            if (string.IsNullOrEmpty(lbl_Date.Text))
            {
                lbl_Date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                Save.Data("Date", lbl_Date.Text);
                load.MainInfo();
            }


        }
        private void Protocol_Compund_Load(object sender, EventArgs e)
        {
            dgv_Data.DataSource = bs_ProtocolCompound;
            Load_ProtocolCompound();
            dgv_Data.Columns["OrderID"].Visible = false;
            dgv_Data.Columns["TempID"].Visible = false;
            
        }


        private void Load_ProtocolCompound()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $"SELECT * FROM [Order].Compound WHERE OrderID = '{Order.OrderID}' ORDER BY TempID";

            dataAdapter = new SqlDataAdapter(query, con);
            var dt = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };

            dataAdapter.Fill(dt);
            bs_ProtocolCompound.DataSource = dt;
        }



        private void Name_Click(object sender, EventArgs e)
        {
            if (Person.IsPasswordOk("Bekräfta med ditt lösenord"))
                lbl_Name.Text = Person.Name;

            Save.Data("Name", lbl_Name.Text);
        }
        private void Weight_75D_TextChanged(object sender, EventArgs e)
        {
            Save.Data("Weight75D", null, tb_kg75D.Text);
        }
        private void Weight_55D_TextChanged(object sender, EventArgs e)
        {
            Save.Data("Weight55D", null, tb_kg55D.Text);
        }
        private void Weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                e.Handled = true;
        }

        private void Data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dgv_Data.Rows[e.RowIndex].Cells[2].Value != null)
                if (string.IsNullOrEmpty(dgv_Data.Rows[e.RowIndex].Cells[2].Value.ToString()))
                    dgv_Data.Rows[e.RowIndex].Cells[2].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            dgv_Data.Rows[e.RowIndex].Cells[0].Value = Order.OrderID;

        }

        private void Protocol_Compund_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save.DataGridView(dgv_Data);
        }

    }



    public class Load
    {
        private readonly Protocol_Compund Compound;
        public Load(Protocol_Compund compound)
        {
            Compound = compound;
        }

        public void MainInfo()
        {
            Compound.lbl_ArtikelNr.Text = Order.PartNumber;
            Compound.lbl_OrderNr.Text = Order.OrderNumber;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT * FROM [Order].Compound_Main WHERE OrderID = @id";
            var cmd = new SqlCommand(query, con);
            SQL_Parameter.NullableINT(cmd.Parameters, "@id", Order.OrderID);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Compound.lbl_Date.Text = reader["Date"].ToString();
                Compound.lbl_Name.Text = reader["Name"].ToString();
                Compound.tb_kg55D.Text = reader["Weight55D"].ToString();
                Compound.tb_kg75D.Text = reader["Weight75D"].ToString();
            }
        }
        public void KorprotokollInfo()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT Rum_Temp, Rum_Fukt FROM [Order].MainData WHERE OrderID = @id";
            var cmd = new SqlCommand(query, con);
            SQL_Parameter.NullableINT(cmd.Parameters, "@id", Order.OrderID);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Compound.lbl_RumTemp.Text = reader["Rum_Temp"].ToString();
                Compound.lbl_RumFukt.Text = reader["Rum_Fukt"].ToString();
            }
        }
        public void Halvfabrikat()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = "SELECT Halvfabrikat_Benämning, Halvfabrikat_OrderNr FROM [Order].PreFab WHERE OrderID = @id ORDER BY Halvfabrikat_Benämning DESC";
            var cmd = new SqlCommand(query, con);
            SQL_Parameter.NullableINT(cmd.Parameters, "@id", Order.OrderID);
            con.Open();
            var reader = cmd.ExecuteReader();
            Label[] lbl_Benämning = { Compound.label_PUR75D, Compound.label_PUR55D };
            Label[] lbl_LotNr = { Compound.lbl_LotNr75D, Compound.lbl_LotNr55D };
            var ctr = 0;
            while (reader.Read())
            {
                lbl_Benämning[ctr].Text = $"{reader["Halvfabrikat_Benämning"]} - LotNr:";
                lbl_LotNr[ctr].Text = $"{reader["Halvfabrikat_OrderNr"]}";
                ctr++;
            }
        }
    }

    public class Save
    {
        public static void Data(string Column, string Text = null, string? Value = null)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    IF EXISTS (SELECT * FROM [Order].Compound_Main WHERE OrderID = @id) 
                        BEGIN
                            UPDATE [Order].Compound_Main
                                SET {Column} = @text
                                WHERE OrderID = @id
                        END
                    ELSE
                        BEGIN
                            INSERT INTO [Order].Compound_Main (OrderID, {Column})
                            VALUES (@id, @text)
                        END";
                var cmd = new SqlCommand(query, con);
                SQL_Parameter.NullableINT(cmd.Parameters, "@id", Order.OrderID);
                if (string.IsNullOrEmpty(Text))
                    SQL_Parameter.Double(cmd.Parameters, "@text", Value);
                else
                {
                    if (DateTime.TryParse(Text, out var date))
                        cmd.Parameters.AddWithValue("@text", date);
                    else
                        cmd.Parameters.AddWithValue("@text", DBNull.Value);
                }

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void DataGridView(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[0].Value is null || string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                    return;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        IF NOT EXISTS (SELECT * FROM [Order].Compound WHERE TempID = @tempid) 
                            INSERT INTO [Order].Compound (OrderID, Sample, DateTime, Size, BulkWeight, Comments)
                            VALUES (@orderid, @sample, @date, @size, @bulkweight, @comments)
                        ELSE
                            UPDATE [Order].Compound
                                SET Sample = @sample, Size = @size, BulkWeight = @bulkweight, Comments = @comments
                                WHERE OrderID = @orderid AND TempID = @tempid";
                    var cmd = new SqlCommand(query, con);
                    SQL_Parameter.Int(cmd.Parameters, "@tempid", row.Cells[6].Value);
                    SQL_Parameter.NullableINT(cmd.Parameters, "@orderid", Order.OrderID);
                    SQL_Parameter.Int(cmd.Parameters, "@sample", row.Cells[1].Value);
                    DateTime.TryParse(row.Cells[2].Value.ToString(), out var dateTime);
                    cmd.Parameters.AddWithValue("@date", dateTime);
                    
                    SQL_Parameter.String(cmd.Parameters, "@size", row.Cells[3].Value.ToString());
                    SQL_Parameter.Int(cmd.Parameters, "@bulkweight", row.Cells[4].Value);
                    SQL_Parameter.String(cmd.Parameters, "@comments", row.Cells[5].Value.ToString());

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
