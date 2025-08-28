using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;

using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.Svetsning_TEF
{
    public partial class MainProtocol_Svetsning_TEF : UserControl
    {
        private Control[] Control_MaskinParametrar
        {
            get
            {
                return new Control[] { tb_Svets, tb_TidFörvärme, tb_Svetsförflyttning, tb_TidBindvärme, tb_TidKylluft, tb_Temperatur, tb_PinneODStål, tb_PinneODPTFE, tb_VärmebackarBredd, tb_VärmebackarHål };
            }
        }
        private IEnumerable<Control> Control_Produktion_Parametrar
        {
            get
            {
                Control[] ctrl = { cb_Inledande_BatchNr, tb_Inledande_Påse, tb_InledandeUppmättPinne, tb_InledandeID, tb_InledandeOD, tb_InledandeLängd };
                return ctrl;
            }
        }
        public IEnumerable<Control> Control_Halvfabrikat
        {
            get
            {
                Control[] ctrl = { cb_Halvfabrikat_ArtikelNr, cb_Halvfabrikat_BatchNr, cb_Halvfabrikat_Typ };
                return ctrl;
            }
        }

        private string Temp_ID;
        private bool IsUpdating_Parameter; //Används ifall operatören håller på editerar en mätning


        private bool IsMaskinParametrar_Filled
        {
            get
            {
                return Control_MaskinParametrar.All(ctrl => !string.IsNullOrEmpty(ctrl.Text));
            }
        }
        private bool IsProduktion_Filled
        {
            get
            {
                foreach (var ctrl in Control_Produktion_Parametrar)
                {
                    if (string.IsNullOrEmpty(ctrl.Text))
                        return false;

                }
                return chb_InspektionUtsida.Checked && chb_InspektionInsida.Checked;
            }
        }


        public MainProtocol_Svetsning_TEF()
        {
            InitializeComponent();

            Fill_Halvfabrikat_ArtikelNr();
            Initialize_Label_Skärmat();

            if (dgv_Halvfabrikat.Rows.Count > 5)
            {
                lbl_Transfer_Halvfabrikat.Enabled = false;
                foreach (var ctrl in Control_Halvfabrikat)
                    ctrl.Enabled = false;
            }
            
            cb_Inledande_BatchNr.SelectionLength = 0;
            dgv_Halvfabrikat.ClearSelection();
            dgv_Produktion.ClearSelection();

            dgv_Produktion.MouseWheel += Parametrar_MouseWheel;
            dgv_Halvfabrikat.MouseWheel += Halvfabrikat_MouseWheel;
        }

       
        public void Load_Data()
        {
            MainInfo.Load_Data(Order.OrderID);

            PC_Svetsning_TEF.Load_Data();
            Load_Data_Korprotokoll_MaskinParametrar();
            Load_Data_Korprotokoll_Produktion();
            Load_Data_Halvfabrikat();

            for (var i = 0; i < dgv_Halvfabrikat.Rows.Count; i++)
            {
                if (dgv_Halvfabrikat.Rows[i].Cells[0].Value.ToString() == "Skärmad")
                {
                    Fill_cb_Inledande_OrderNr(dgv_Halvfabrikat.Rows[i].Cells[1].Value.ToString());
                    break;
                }
            }
        }
        private void Initialize_Label_Skärmat()
        {
            Part.SetPartNrSpecial("Svetsning TEF Stumning");
            if (Part.IsPartNrSpecial)
                label_Inledande_Skärmat.Text = "Mjukspets";
        }
        private void Load_Data_Korprotokoll_MaskinParametrar()
        {
            dgv_MaskinParametrar.Rows.Clear();
            Module.IsOkToSave = false;
            var dt = Svetsning_TEF.dt_Protocol_Svetsning_MaskinParametrar;

            for (var row = 0; row < dt.Rows.Count; row++)
            {
                dgv_MaskinParametrar.Rows.Add();
                dgv_MaskinParametrar.Rows[row].DefaultCellStyle.BackColor = CustomColors.Ok_Back;
                dgv_MaskinParametrar.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Ok_Front;

                var is_Skrotad = bool.Parse(dt.Rows[row]["Kasserad"].ToString());

                for (var cell = 1; cell < dgv_MaskinParametrar.Columns.Count + 1; cell++)
                {
                    dgv_MaskinParametrar.Rows[row].Cells[cell - 1].Value = dt.Rows[row][cell].ToString();
                    if (!Enumerable.Range(2, 6).Contains(cell) || is_Skrotad)
                        continue;
                    if (!double.TryParse(dgv_MaskinParametrar.Rows[row].Cells[cell - 1].Value.ToString(), out var value))
                        continue;
                    if (double.TryParse(PC_Svetsning_TEF.MIN_Value(dgv_MaskinParametrar.Columns[cell - 1].Name), out var min) && double.TryParse(PC_Svetsning_TEF.MAX_Value(dgv_MaskinParametrar.Columns[cell - 1].Name), out var max))
                        Validate_Data.Value_CellOrControl(true, dgv_MaskinParametrar.Columns[cell - 1].Name, 0,$"{min}", $"{max}", $"{value}", null, dgv_MaskinParametrar.Rows[row].Cells[cell - 1]);

                }

                if (!is_Skrotad)
                    continue;
                dgv_MaskinParametrar.Rows[row].DefaultCellStyle.BackColor = CustomColors.Bad_Back;
                dgv_MaskinParametrar.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Bad_Front;
                dgv_MaskinParametrar.Rows[row].DefaultCellStyle.Font = new Font("Courier New", 8, FontStyle.Italic | FontStyle.Strikeout);
            }

            if (dgv_MaskinParametrar.Rows.Count > 3)
                ControlManager.Lock_Controls(new Control[] {tb_Svets, tb_TidFörvärme, tb_Svetsförflyttning, tb_TidBindvärme,
                    tb_TidKylluft, tb_Temperatur, tb_PinneODStål, tb_PinneODPTFE, tb_VärmebackarBredd, tb_VärmebackarHål, lbl_Transfer_Maskinparametrar }, true);

            Module.IsOkToSave = true;
        }
        private void Load_Data_Korprotokoll_Produktion()
        {
            dgv_Produktion.Rows.Clear();
            var dt = Svetsning_TEF.dt_Protocol_Svetsning_Produktion;
            for (var row = 0; row < dt.Rows.Count; row++)
            {
                dgv_Produktion.Rows.Add();
                for (var col = 1; col < dt.Columns.Count; col++)
                {
                    dgv_Produktion.Rows[row].Cells[col - 1].Value = dt.Rows[row][col].ToString();
                    if (bool.Parse(dt.Rows[row][0].ToString()))
                    {
                        dgv_Produktion.Rows[row].DefaultCellStyle.BackColor = CustomColors.Bad_Back;
                        dgv_Produktion.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Bad_Front;
                        dgv_Produktion.Rows[row].DefaultCellStyle.Font = new Font("Courier New", 8, FontStyle.Italic | FontStyle.Strikeout);
                    }
                    else
                    {
                        dgv_Produktion.Rows[row].DefaultCellStyle.BackColor = CustomColors.Ok_Back;
                        dgv_Produktion.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Ok_Front;
                    }
                }
            }
        }
        private void Load_Data_Halvfabrikat()
        {
            dgv_Halvfabrikat.Rows.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"SELECT Typ, Halvfabrikat_ArtikelNr, Halvfabrikat_OrderNr, Halvfabrikat_ID, Halvfabrikat_OD, Halvfabrikat_W, Length
                                        FROM [Order].PreFab {Queries.WHERE_OrderID} ORDER BY TempID";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                cmd.Parameters.AddWithValue("@typ", cb_Halvfabrikat_Typ.Text);
                cmd.Parameters.AddWithValue("@halv_ArtikelNr", cb_Halvfabrikat_ArtikelNr.Text);
                cmd.Parameters.AddWithValue("@halv_OrderNr", cb_Halvfabrikat_BatchNr.Text);
                SQL_Parameter.Double(cmd.Parameters, "@halv_ID", lbl_Halvfabrikat_ID.Text);
                SQL_Parameter.Double(cmd.Parameters, "@halv_OD", lbl_Halvfabrikat_OD.Text);
                SQL_Parameter.Double(cmd.Parameters, "@halv_W", lbl_Halvfabrikat_W.Text);
                SQL_Parameter.Double(cmd.Parameters, "@length", lbl_Halvfabrikat_L.Text);
                cmd.ExecuteNonQuery();
            }

            Clear_Halvfabrikat_Row();

            if (dgv_Halvfabrikat.Rows.Count > 4)
            {
                MessageBox.Show(@"Du har nu fyllt i max antal rader med halvfabrikat, om du behöver skriva i mera så skriv i kommentarerna.\n
                                    Om detta blir ett problem så ta kontakt med arbetsledare eller admin.", "Varning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbl_Transfer_Halvfabrikat.Enabled = false;
            }


        }
        private void Save_MaskinParametrar()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    INSERT INTO Korprotokoll_Svetsning_Maskinparametrar
                         VALUES (@id, 'False', @0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @datum, @tid, @employeenumber, @sign)";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                cmd.Parameters.AddWithValue("@datum", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@tid", DateTime.Now.ToString("HH:mm"));
                cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                cmd.Parameters.AddWithValue("@sign", Person.Sign);
                for (var i = 0; i < Control_MaskinParametrar.Length; i++)
                    cmd.Parameters.AddWithValue("@" + i, Control_MaskinParametrar[i].Text);

                con.Open();
                cmd.ExecuteScalar();
            }
        }
        private void Save_Produktion_Parametrar()
        {
            Points.Add_Points(7, "Överför Produktion, Svetsning");
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    INSERT INTO Korprotokoll_Svetsning_Parametrar 
                    VALUES (@id, 'False', @inledande_ordernr, @inledande_Påse, @inledande_Pinne, @inledande_ID, @inledande_OD, @inledande_Längd, @inspekt_utsida, @inspekt_insida, @datum, @tid, @employeenumber, @sign)";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                cmd.Parameters.AddWithValue("@inledande_ordernr", cb_Inledande_BatchNr.Text);
                cmd.Parameters.AddWithValue("@inledande_Påse", tb_Inledande_Påse.Text);
                cmd.Parameters.AddWithValue("@inledande_Pinne", tb_InledandeUppmättPinne.Text);
                cmd.Parameters.AddWithValue("@inledande_ID", tb_InledandeID.Text);
                cmd.Parameters.AddWithValue("@inledande_OD", tb_InledandeOD.Text);
                cmd.Parameters.AddWithValue("@inledande_Längd", tb_InledandeLängd.Text);
                cmd.Parameters.AddWithValue("@inspekt_utsida", chb_InspektionUtsida.Checked);
                cmd.Parameters.AddWithValue("@inspekt_insida", chb_InspektionInsida.Checked);
                cmd.Parameters.AddWithValue("@datum", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@tid", DateTime.Now.ToString("HH:mm"));
                cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                cmd.Parameters.AddWithValue("@sign", Person.Sign);

                con.Open();
                cmd.ExecuteScalar();
            }
        }

        public void Lock_Controls()
        {
            ControlManager.Lock_Controls(new Control[]
            {
                lbl_Transfer_Maskinparametrar, lbl_Kassera_Maskinparameter, lbl_Transfer_Produktion, lbl_Discard_Row_Produktion, lbl_Edit_Row_Produktion, lbl_Transfer_Halvfabrikat, lbl_Discard_Halvfabrikat,
                tb_Svets, tb_TidFörvärme, tb_Svetsförflyttning, tb_TidBindvärme, tb_TidKylluft, tb_Temperatur, tb_PinneODStål, tb_PinneODPTFE, tb_VärmebackarBredd, tb_VärmebackarHål,
                cb_Inledande_BatchNr, tb_Inledande_Påse, tb_InledandeUppmättPinne, tb_InledandeID, tb_InledandeOD, tb_InledandeLängd, chb_InspektionInsida, chb_InspektionUtsida,
                cb_Halvfabrikat_Typ, cb_Halvfabrikat_ArtikelNr, cb_Halvfabrikat_BatchNr
            }, true);
        }
        private void Fill_Halvfabrikat_ArtikelNr()
        {
            Monitor.Monitor.Fill_cb_Halvfabrikat_ArtikelNr(cb_Halvfabrikat_ArtikelNr);
        }
        private void Fill_cb_Inledande_OrderNr(string? artikelNr)
        {
            cb_Inledande_BatchNr.DataSource = Monitor.Monitor.PreFab_BatchNr(artikelNr);

            cb_Inledande_BatchNr.SelectedIndex = -1;
        }
        private void Clear_Halvfabrikat_Row()
        {
            cb_Halvfabrikat_ArtikelNr.TextChanged -= Halvfabrikat_ArtikelNr_TextChanged;

            cb_Halvfabrikat_Typ.SelectedIndex = -1;
            cb_Halvfabrikat_ArtikelNr.SelectedIndex = -1;
            cb_Halvfabrikat_BatchNr.SelectedIndex = -1;
            cb_Halvfabrikat_BatchNr.Text = string.Empty;
            lbl_Halvfabrikat_ID.Text = lbl_Halvfabrikat_OD.Text = lbl_Halvfabrikat_W.Text = lbl_Halvfabrikat_L.Text = string.Empty;

            cb_Halvfabrikat_ArtikelNr.TextChanged += Halvfabrikat_ArtikelNr_TextChanged;
        }


        private void Halvfabrikat_ArtikelNr_TextChanged(object sender, EventArgs e)
        {
            cb_Halvfabrikat_BatchNr.DataSource = Monitor.Monitor.PreFab_BatchNr(cb_Halvfabrikat_ArtikelNr.Text);

            int Operation;
            switch (cb_Halvfabrikat_Typ.Text)
            {
                case "Formar":
                case "Mjuk":
                    Operation = 10;
                    break;
                case "Skärmad":
                    Operation = 30;
                    cb_Inledande_BatchNr.DataSource = Monitor.Monitor.PreFab_BatchNr(cb_Halvfabrikat_ArtikelNr.Text);
                    break;
                default:
                    Operation = 0;
                    break;
            }

            if (Operation == 0 & !string.IsNullOrEmpty(cb_Halvfabrikat_ArtikelNr.Text))
            {
                InfoText.Show("Du har inte valt någon Slangtyp och mått till Halvfabrikat kan ej laddas.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }
            lbl_Halvfabrikat_ID.Text = $"{Monitor.Monitor.MeasurePoint(cb_Halvfabrikat_ArtikelNr.Text, "ID", Operation):0.00}";
            lbl_Halvfabrikat_OD.Text = $"{Monitor.Monitor.MeasurePoint(cb_Halvfabrikat_ArtikelNr.Text, "OD", Operation):0.00}";
            lbl_Halvfabrikat_W.Text = $"{Monitor.Monitor.MeasurePoint(cb_Halvfabrikat_ArtikelNr.Text, "Wall", Operation):0.00}";
            lbl_Halvfabrikat_L.Text = $"{Monitor.Monitor.MeasurePoint(cb_Halvfabrikat_ArtikelNr.Text, "Length", Operation):0.00}";


            if (cb_Halvfabrikat_Typ.Text == "Skärmad")
                Fill_cb_Inledande_OrderNr(cb_Halvfabrikat_ArtikelNr.Text);
        }
        private void Parametrar_MouseWheel(object sender, MouseEventArgs e)
        {
            var currentIndex = dgv_Produktion.FirstDisplayedScrollingRowIndex;
            var scrollLines = SystemInformation.MouseWheelScrollLines;

            try
            {
                if (e.Delta > 0)
                {
                    dgv_Produktion.FirstDisplayedScrollingRowIndex = Math.Max(0, currentIndex - scrollLines);
                }
                else if (e.Delta < 0)
                {
                    dgv_Produktion.FirstDisplayedScrollingRowIndex = currentIndex + scrollLines;
                }
            }
            catch { }
        }
        private void Halvfabrikat_MouseWheel(object sender, MouseEventArgs e)
        {
            var currentIndex = dgv_Halvfabrikat.FirstDisplayedScrollingRowIndex;
            var scrollLines = SystemInformation.MouseWheelScrollLines;

            try
            {
                if (e.Delta > 0)
                {
                    dgv_Halvfabrikat.FirstDisplayedScrollingRowIndex = Math.Max(0, currentIndex - scrollLines);
                }
                else if (e.Delta < 0)
                {
                    dgv_Halvfabrikat.FirstDisplayedScrollingRowIndex = currentIndex + scrollLines;
                }
            }
            catch { }
        }
        private void Check_MIN_NOM_MAX_Leave(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            double.TryParse(tb.Text, out var value);
            Validate_Data.Value_CellOrControl(true, tb.Name, 0, PC_Svetsning_TEF.MIN_Value(tb.Name), PC_Svetsning_TEF.MAX_Value(tb.Name), tb.Text, null, null, tb);
        }
        private void Save_Maskinparametrar_Click(object sender, EventArgs e)
        {
           
            if (!IsMaskinParametrar_Filled)
            {
                InfoText.Show("Fyll i alla parametrar före du överför.", CustomColors.InfoText_Color.Bad, "Varning!");
                return;
            }
            if (!Person.IsUserSignedIn(true))
            {
                return;
            }

            using var black = new BlackBackground(string.Empty, 80);
            using var password = new PasswordManager(LanguageManager.GetString("confirmTransferPassword"));
            black.Show();
            password.ShowDialog();
            black.Close();
            if (password.IsOk == false)
                return;

            Save_MaskinParametrar();
            Load_Data_Korprotokoll_MaskinParametrar();
            ControlManager.Clear_TextBoxes(Control_MaskinParametrar);
        }
        private void Delete_Row_Maskinparameter_Click(object sender, EventArgs e)
        {
            var row = dgv_MaskinParametrar.CurrentCell.RowIndex;
            InfoText.Question($"Vill du skrota rad nr {row + 1}?", CustomColors.InfoText_Color.Info, "Warning!", this);
            if (InfoText.answer == InfoText.Answer.Yes)
            {
                SaveData.UPDATE_Korprotokoll_Parametrar_Kassera("Korprotokoll_Svetsning_Maskinparametrar", dgv_MaskinParametrar.Rows[row].Cells["dgv_Maskinparametrar_Datum"].Value.ToString(),
                    dgv_MaskinParametrar.Rows[row].Cells["dgv_Maskinparametrar_Tid"].Value.ToString(), dgv_MaskinParametrar.Rows[row].Cells["dgv_Maskinparametrar_AnstNr"].Value.ToString());
                Load_Data_Korprotokoll_MaskinParametrar();
            }
        }

        private void Save_Production_Parameters_Click(object sender, EventArgs e)
        {
            if (!IsProduktion_Filled)
            {
                InfoText.Show("Fyll i alla parametrar före du överför.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }
            if (!Person.IsUserSignedIn(true))
                return;

            if (IsUpdating_Parameter == false)
            {
                using var black = new BlackBackground(string.Empty, 80);
                using var password = new PasswordManager(LanguageManager.GetString("confirmTransferPassword"));
                black.Show();
                password.ShowDialog();
                black.Close();
                if (password.IsOk == false)
                    return;

                Save_Produktion_Parametrar();
            }
            else
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"UPDATE Korprotokoll_Svetsning_Parametrar SET Inledande_OrderNr = @inledande_OrderNr, Inledande_Påse = @inledande_Påse, Inledande_UppmättPinne = @inledande_Pinne, 
                        Inledande_ID = @inledande_ID, Inledande_OD = @inledande_OD, Inledande_Längd = @inledande_Längd, Inspektion_Utsida = @inspektion_Utsida, Inspektion_Insida = @inspektion_Insida
                            {Queries.WHERE_OrderID} AND TempID = @tempId";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    cmd.Parameters.AddWithValue("@inledande_OrderNr", cb_Inledande_BatchNr.Text);
                    cmd.Parameters.AddWithValue("@inledande_Påse", tb_Inledande_Påse.Text);
                    cmd.Parameters.AddWithValue("@inledande_Pinne", tb_InledandeUppmättPinne.Text);

                    cmd.Parameters.AddWithValue("@inledande_ID", tb_InledandeID.Text);
                    cmd.Parameters.AddWithValue("@inledande_OD", tb_InledandeOD.Text);
                    cmd.Parameters.AddWithValue("@inledande_Längd", tb_InledandeLängd.Text);
                    cmd.Parameters.AddWithValue("@inspektion_utsida", chb_InspektionUtsida.Checked);
                    cmd.Parameters.AddWithValue("@inspektion_insida", chb_InspektionInsida.Checked);

                    cmd.Parameters.AddWithValue("@tempId", Temp_ID);

                    con.Open();
                    cmd.ExecuteScalar();
                }
                IsUpdating_Parameter = false;
            }

            Load_Data_Korprotokoll_Produktion();
            ControlManager.Clear_TextBoxes(new Control[] { cb_Inledande_BatchNr, tb_Inledande_Påse, tb_InledandeUppmättPinne, tb_InledandeID, tb_InledandeOD, tb_InledandeLängd, chb_InspektionInsida, chb_InspektionUtsida, cb_Inledande_BatchNr });

        }
        private void Delete_Row_Production_Parameters_Click(object sender, EventArgs e)
        {
            var row = dgv_Produktion.CurrentCell.RowIndex;
            InfoText.Question($"Vill du skrota rad nr {row + 1}?", CustomColors.InfoText_Color.Info, "Warning!", this);
            if (InfoText.answer == InfoText.Answer.Yes)
            {
                SaveData.UPDATE_Korprotokoll_Parametrar_Kassera("Korprotokoll_Svetsning_Parametrar", dgv_Produktion.Rows[row].Cells["Datum"].Value.ToString(),
                    dgv_Produktion.Rows[row].Cells["Tid"].Value.ToString(), dgv_Produktion.Rows[row].Cells["AnstNr"].Value.ToString());
                Load_Data_Korprotokoll_Produktion();
            }
        }
        private void Edit_Row_Produktion_Click(object sender, EventArgs e)
        {
            IsUpdating_Parameter = true;
            var row = dgv_Produktion.CurrentCell.RowIndex;
            cb_Inledande_BatchNr.Text = dgv_Produktion.Rows[row].Cells[0].Value.ToString();
            tb_Inledande_Påse.Text = dgv_Produktion.Rows[row].Cells[1].Value.ToString();
            tb_InledandeUppmättPinne.Text = dgv_Produktion.Rows[row].Cells[2].Value.ToString();
            tb_InledandeID.Text = dgv_Produktion.Rows[row].Cells[3].Value.ToString();
            tb_InledandeOD.Text = dgv_Produktion.Rows[row].Cells[4].Value.ToString();
            tb_InledandeLängd.Text = dgv_Produktion.Rows[row].Cells[5].Value.ToString();
            chb_InspektionInsida.Checked = bool.Parse(dgv_Produktion.Rows[row].Cells[6].Value.ToString());
            chb_InspektionUtsida.Checked = bool.Parse(dgv_Produktion.Rows[row].Cells[7].Value.ToString());

            Temp_ID = dgv_Produktion.Rows[row].Cells[12].Value.ToString();

            dgv_Produktion.Rows.RemoveAt(row);
        }
        private void EnterToTab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void Save_Halvfabrikat_Click(object sender, EventArgs e)
        {
            Save_Halvfabrikat();
            Load_Data_Halvfabrikat();
        }
        private void Delete_Row_Halvfabrikat_Click(object sender, EventArgs e)
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
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    cmd.Parameters.AddWithValue("@typ", dgv_Halvfabrikat.Rows[row].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@h_a", dgv_Halvfabrikat.Rows[row].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@h_o", dgv_Halvfabrikat.Rows[row].Cells[2].Value.ToString());
                    cmd.ExecuteNonQuery();
                }
                Load_Data_Halvfabrikat();
            }
        }
    }
}
