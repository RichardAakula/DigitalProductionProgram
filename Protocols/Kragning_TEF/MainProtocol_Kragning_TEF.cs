using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;

namespace DigitalProductionProgram.Protocols.Kragning_TEF
{
    public partial class MainProtocol_Kragning_TEF : UserControl
    {
        private bool IsHalvfabrikatOk
        {
            get
            {
                if (string.IsNullOrEmpty(cb_Halvfabrikat_Typ.Text))
                {
                    InfoText.Show("Välj först vilken typ av halvfabrikat du vill använda", CustomColors.InfoText_Color.Warning, "Warning", this);
                    cb_Halvfabrikat_Typ.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(cb_Halvfabrikat_ArtikelNr.Text))
                {
                    InfoText.Show("Välj först artikelnr för halvfabrikatet", CustomColors.InfoText_Color.Warning, "Warning", this);
                    cb_Halvfabrikat_ArtikelNr.Focus();
                    return false;
                }
                return true;
            }
        }

        private bool IsTransferringHalvfabrikat;

        public MainProtocol_Kragning_TEF()
        {
            InitializeComponent();

            Processkort_Kragning.Lock_TextBoxes();

            Processkort_Kragning.dgv_Korprotokoll = KP_Kragning.dgv_Korprotokoll;
            KP_Kragning.dgv_Processkort = Processkort_Kragning.dgv_Processkort;

            ProdType.TextChanged += ControlManager.Save.Protocol_Main;

            Påse_Spole.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
            ProdType.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
            KP_Kragning.dgv_Korprotokoll.ClearSelection();

            Fill_Halvfabrikat_ArtikelNr();
        }

        public void Lock_Card()
        {
            ControlManager.Lock_Controls(new Control[] {label_Datum, lbl_LC_Date, ProdType, Påse_Spole, Processkort_Kragning.Kragningsdon_Nr,
                lbl_Transfer_Halvfabrikat, lbl_Delete_Halvfabrikat});
            KP_Kragning.Enabled = false;
        }
        private void Fill_Halvfabrikat_ArtikelNr()
        {
            Monitor.Monitor.Fill_cb_Halvfabrikat_ArtikelNr(cb_Halvfabrikat_ArtikelNr);
        }
        public void Load_Data()
        {
            Load_Data_Korprotokoll();

            Load_Data_Halvfabrikat();
            Processkort_Kragning.Load_Info();
            Processkort_Kragning.Load_Data();
            KP_Kragning.Load_Data();

        }
        private void Load_Data_Korprotokoll()
        {
            Control[] ctrl = { lbl_OrderNr, lbl_ArtikelNr, lbl_Customer, lbl_Benämning, ProdType, lbl_LC_Date, Name_Start, Påse_Spole, Processkort_Kragning.Kragningsdon_Nr };
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                var query = @"
                        SELECT OrderNr, PartNr, Customer, Description, ProdType, Date_Start, Name_Start, 
                            (SELECT TextValue FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = 172) AS Påse_Spole, 
                            (SELECT TextValue FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = 173) AS Kragningsdon_Nr
                        FROM [Order].MainData
                        WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    for (var i = 0; i < reader.FieldCount; i++)
                        ctrl[i].Text = reader[i].ToString();
            }
        }
        private void Load_Data_Halvfabrikat()
        {
            dgv_Halvfabrikat.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"SELECT Typ, Halvfabrikat_ArtikelNr, Halvfabrikat_OrderNr, Halvfabrikat_ID, Halvfabrikat_OD, Halvfabrikat_W, Length
                                        FROM [Order].PreFab {Queries.WHERE_OrderID} ORDER BY TempID";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                var row = 0;
                while (reader.Read())
                {
                    dgv_Halvfabrikat.Rows.Add();
                    for (var col = 0; col < reader.FieldCount; col++)
                        dgv_Halvfabrikat.Rows[row].Cells[col].Value = reader.GetValue(col);
                    row++;
                }
            }
        }
        private void Save_Halvfabrikat()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                var query = @"
                    INSERT INTO [Order].PreFab 
                        (OrderID, Typ, Halvfabrikat_ArtikelNr, Halvfabrikat_OrderNr, Halvfabrikat_ID, Halvfabrikat_OD, Halvfabrikat_W, Length) 
                    VALUES (@id, @typ, @halv_ArtikelNr, @halv_OrderNr, @halv_ID, @halv_OD, @halv_W, @length)";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                cmd.Parameters.AddWithValue("@typ", cb_Halvfabrikat_Typ.Text);
                cmd.Parameters.AddWithValue("@halv_ArtikelNr", cb_Halvfabrikat_ArtikelNr.Text);
                cmd.Parameters.AddWithValue("@halv_OrderNr", cb_Halvfabrikat_OrderNr.Text);
                SQL_Parameter.Double(cmd.Parameters, "@halv_ID", lbl_Halvfabrikat_ID.Text);
                SQL_Parameter.Double(cmd.Parameters, "@halv_OD", lbl_Halvfabrikat_OD.Text);
                SQL_Parameter.Double(cmd.Parameters, "@halv_W", lbl_Halvfabrikat_W.Text);
                SQL_Parameter.Double(cmd.Parameters, "@length", lbl_Halvfabrikat_L.Text);
                cmd.ExecuteNonQuery();
            }

            Clear_Halvfabrikat_Row();

            if (dgv_Halvfabrikat.Rows.Count > 4)
            {
                InfoText.Show("Du har nu fyllt i max antal rader med halvfabrikat, om du behöver skriva i mera så skriv i kommentarerna. Om detta blir ett problem så ta kontakt med arbetsledare eller admin.",
                    CustomColors.InfoText_Color.Warning, "Warning", this);

                lbl_Transfer_Halvfabrikat.Enabled = false;
            }
        }
        private void Clear_Halvfabrikat_Row()
        {
            cb_Halvfabrikat_Typ.SelectedIndex = -1;
            cb_Halvfabrikat_ArtikelNr.SelectedIndex = -1;
            cb_Halvfabrikat_OrderNr.SelectedIndex = -1;
            cb_Halvfabrikat_OrderNr.Text = string.Empty;
            lbl_Halvfabrikat_ID.Text = lbl_Halvfabrikat_OD.Text = lbl_Halvfabrikat_W.Text = lbl_Halvfabrikat_L.Text = string.Empty;
        }
        private void Transfer_Halvfabrikat_Click(object sender, EventArgs e)
        {
            IsTransferringHalvfabrikat = true;
            
            if (IsHalvfabrikatOk)
                Save_Halvfabrikat();

            Load_Data_Halvfabrikat();

            IsTransferringHalvfabrikat = false;
        }
        private void Delete_Halvfabrikat_Click(object sender, EventArgs e)
        {
           var row = dgv_Halvfabrikat.CurrentCell.RowIndex;
            InfoText.Question($"Vill du radera rad nr {row + 1}? \n" +
                          "Om du fortsätter så försvinner raden och det går inte att ångra.", CustomColors.InfoText_Color.Info, "Warning!", this);
            if (InfoText.answer == InfoText.Answer.Yes)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $"DELETE TOP (1) FROM [Order].PreFab {Queries.WHERE_OrderID} AND Typ = @typ AND Halvfabrikat_ArtikelNr = @h_a AND Halvfabrikat_OrderNr = @h_o";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    cmd.Parameters.AddWithValue("@typ", dgv_Halvfabrikat.Rows[row].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@h_a", dgv_Halvfabrikat.Rows[row].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@h_o", dgv_Halvfabrikat.Rows[row].Cells[2].Value.ToString());
                    cmd.ExecuteNonQuery();
                }
                Load_Data_Halvfabrikat();
            }
        }
        private void Halvfabrikat_ArtikelNr_TextChanged(object sender, EventArgs e)
        {
            if (IsTransferringHalvfabrikat)
                return;
            cb_Halvfabrikat_OrderNr.DataSource = Monitor.Monitor.PreFab_BatchNr(cb_Halvfabrikat_ArtikelNr.Text);

            int Operation;
            switch (cb_Halvfabrikat_Typ.Text)
            {
                case "Mjukslang":
                case "Svetsform":
                    Operation = 10;
                    break;
                default:
                    Operation = 0;
                    break;
            }
            if (Operation == 0)
            {
                InfoText.Show("Du har inte valt någon Slangtyp och mått till Halvfabrikat kan ej laddas.", CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }
            lbl_Halvfabrikat_ID.Text = $"{Monitor.Monitor.MeasurePoint(cb_Halvfabrikat_ArtikelNr.Text, "ID", Operation):0.00}";
            lbl_Halvfabrikat_OD.Text = $"{Monitor.Monitor.MeasurePoint(cb_Halvfabrikat_ArtikelNr.Text, "OD", Operation):0.00}";
            lbl_Halvfabrikat_W.Text = $"{Monitor.Monitor.MeasurePoint(cb_Halvfabrikat_ArtikelNr.Text, "Wall", Operation):0.00}";
            lbl_Halvfabrikat_L.Text = $"{Monitor.Monitor.MeasurePoint(cb_Halvfabrikat_ArtikelNr.Text, "Length", Operation):0.00}";
        }
        private void Only_Decimals_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }

            if (!char.IsControl(e.KeyChar) && (e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Påse_Spole_TextChanged(object sender, EventArgs e)
        {
            if (Module.IsOkToSave)
                KP_Kragning.INSERT_Data(KP_Kragning.dgv_Korprotokoll, 172, 0, Påse_Spole.Text, 1);
        }
    }
}
