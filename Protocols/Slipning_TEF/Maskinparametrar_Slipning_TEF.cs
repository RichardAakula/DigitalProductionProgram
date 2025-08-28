using System;
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
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.Slipning_TEF
{
    public partial class Maskinparametrar_Slipning_TEF : UserControl
    {
        private bool IsParametrar_Filled
        {
            get
            {
                return Control_MaskinParametrar.All(ctrl => !string.IsNullOrEmpty(ctrl.Text));
            }
        }
        private string? MIN_Value(string name)
        {
            switch (name)
            {
                case "tb_MatarhjulVinkel":
                case "dgv_MatarhjulVinkel":
                    return lbl_Matarhjul_Vinkel_min.Text;
                case "tb_Bladhöjd":
                case "dgv_Bladhöjd":
                    return lbl_Bladhöjd_min.Text;
                case "tb_Arbetsblad":
                case "dgv_Arbetsblad":
                    return lbl_Arbetsblad_min.Text;
            }
            return null;
        }
        private string? MAX_Value(string name)
        {
            switch (name)
            {
                case "tb_MatarhjulVinkel":
                case "dgv_MatarhjulVinkel":
                    return lbl_Matarhjul_Vinkel_max.Text;
                case "tb_Bladhöjd":
                case "dgv_Bladhöjd":
                    return lbl_Bladhöjd_max.Text;
                case "tb_Arbetsblad":
                case "dgv_Arbetsblad":
                    return lbl_Arbetsblad_max.Text;
            }
            return null;
        }

        public Control[] Control_MaskinParametrar
        {
            get
            {
                return new Control[]{ tb_Slipmaskin, tb_MatarhjulHastighet, tb_MatarhjulVinkel,
                    tb_HelixVinkel, tb_Bladhöjd, tb_Arbetsblad, tb_Nr, tb_Chimshöjd };
            }
        }
        public Control[] Control_ProcessParametrar
        {
            get
            {
                Control[] ctrl =  {lbl_Matarhjul_Hastighet_nom, lbl_Matarhjul_Vinkel_min, lbl_Matarhjul_Vinkel_nom, lbl_Matarhjul_Vinkel_max, lbl_Helix_Vinkel_nom, lbl_Bladhöjd_min, lbl_Bladhöjd_nom, lbl_Bladhöjd_max,
                    lbl_Arbetsblad_min, lbl_Arbetsblad_nom, lbl_Arbetsblad_max, lbl_Chimshöjd_nom };
                return ctrl;
            }
        }


        public Maskinparametrar_Slipning_TEF()
        {
            InitializeComponent();
            //Gör det möjligt att scrolla med musen i parametrarna
            dgv_MaskinParametrar.MouseWheel += Scroll_MouseWheel;
        }

        public void Load_Data()
        {
            Load_Processkort();
            Load_Körprotokoll();
        }
        private void Load_Processkort()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT Matarhjul_Hastighet_nom, Matarhjul_Vinkel_min, Matarhjul_Vinkel_nom, Matarhjul_Vinkel_max, Helix_Vinkel_nom, Bladhöjd_min, Bladhöjd_nom, Bladhöjd_max, 
                        Arbetsblad_min, Arbetsblad_nom, Arbetsblad_max, Chimshöjd_nom, Dragprov_enhet
                    FROM Processkort_Slipning
                    WHERE PartID = @partID";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partID", Order.PartID);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                for (var i = 0; i < Control_ProcessParametrar.Length; i++)
                {
                    Control_ProcessParametrar[i].Text = reader[i] == DBNull.Value ? "": reader[i].ToString();
                    if (string.IsNullOrEmpty(Control_ProcessParametrar[i].Text))
                        Control_ProcessParametrar[i].Text = "N/A";
                }
            }
        }
        private void Load_Körprotokoll()
        {
            dgv_MaskinParametrar.Rows.Clear();
            var dt = Slipning_TEF.dt_Protocol_Slipning_MaskinParametrar;
            var column = dt.Columns.Add("Centerhöjd");
            column.SetOrdinal(9);

            for (var row = 0; row < dt.Rows.Count; row++)
            {
                dgv_MaskinParametrar.Rows.Add();

                for (var cell = 1; cell < dgv_MaskinParametrar.Columns.Count + 1; cell++)
                {
                    dgv_MaskinParametrar.Rows[row].Cells[cell - 1].Value = dt.Rows[row][cell].ToString();
                    dgv_MaskinParametrar.Rows[row].Cells[cell - 1].Style.BackColor = CustomColors.Ok_Back;
                    dgv_MaskinParametrar.Rows[row].Cells[cell - 1].Style.ForeColor = CustomColors.Ok_Front;

                    if (cell == 9)  //Lägger till Centerhöjd som ej fylls i som en tom grå kolumn
                        dgv_MaskinParametrar.Rows[row].Cells[cell - 1].Style.BackColor = Color.DarkGray;

                    if (bool.Parse(dt.Rows[row]["Kasserad"].ToString()))
                    {
                        dgv_MaskinParametrar.Rows[row].DefaultCellStyle.BackColor = CustomColors.Bad_Back;
                        dgv_MaskinParametrar.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Bad_Front;
                        dgv_MaskinParametrar.Rows[row].DefaultCellStyle.Font = new Font("Courier New", (float)8.5, FontStyle.Italic | FontStyle.Strikeout);
                    }
                    else
                    {
                        if (cell != 3 && cell != 5 && cell != 6) continue;
                        if (!double.TryParse(dgv_MaskinParametrar.Rows[row].Cells[cell - 1].Value.ToString(), out var value))
                            continue;
                        var Min = MIN_Value(dgv_MaskinParametrar.Columns[cell - 1].Name);
                        var Max = MAX_Value(dgv_MaskinParametrar.Columns[cell - 1].Name);
                        Validate_Data.Value_CellOrControl(true, dgv_MaskinParametrar.Columns[cell - 1].Name,0, Min, Max, dgv_MaskinParametrar.Rows[row].Cells[cell - 1].Value.ToString(), null, dgv_MaskinParametrar.Rows[row].Cells[cell - 1]);
                    }
                }
            }
            if (dgv_MaskinParametrar.Rows.Count > 3)
                ControlManager.Lock_Controls(new Control[] {tb_Slipmaskin, tb_MatarhjulHastighet, tb_MatarhjulVinkel, tb_HelixVinkel,
                    tb_Bladhöjd, tb_Arbetsblad, tb_Nr, tb_Chimshöjd, lbl_Transfer_Maskinparametrar }, true);

        }

        private void Save_Data()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    INSERT INTO Korprotokoll_Slipning_Maskinparametrar
                    VALUES (@id, 'False', @0, @1, @2, @3, @4, @5, @6, @chimsHöjd, @datum, @tid, @employeenumber, @sign)";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

            cmd.Parameters.AddWithValue("@id", Order.OrderID);
            cmd.Parameters.AddWithValue("@datum", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@tid", DateTime.Now.ToString("HH:mm"));
            cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
            cmd.Parameters.AddWithValue("@sign", Person.Sign);
            cmd.Parameters.AddWithValue("@chimsHöjd", lbl_Chimshöjd_nom.Text);
            for (var i = 0; i < Control_MaskinParametrar.Length; i++)
                cmd.Parameters.AddWithValue("@" + i, Control_MaskinParametrar[i].Text);

            con.Open();
            cmd.ExecuteScalar();
        }
        
        private void Save_Click(object sender, EventArgs e)
        {
           
            if (!IsParametrar_Filled)
            {
                InfoText.Show("Fyll i alla parametrar före du överför.", CustomColors.InfoText_Color.Bad, "Varning!");
                return;
            }
            if (!Person.IsUserSignedIn(true))
                return;

            using var black = new BlackBackground(string.Empty, 80);
            using var password = new PasswordManager(LanguageManager.GetString("confirmTransferPassword"));
            black.Show();
            password.ShowDialog();
            black.Close();
            if (password.IsOk == false)
                return;

            Save_Data();
            Load_Data();
            ControlManager.Clear_TextBoxes(Control_MaskinParametrar);
        }

        private void Check_MIN_NOM_MAX_Leave(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            double.TryParse(tb.Text, out var value);
            Validate_Data.Value_CellOrControl(true, tb.Name, 0,MIN_Value(tb.Name), MAX_Value(tb.Name), tb.Text, null, null, tb);
        }
        private void Scroll_MouseWheel(object sender, MouseEventArgs e)
        {
            var currentIndex = dgv_MaskinParametrar.FirstDisplayedScrollingRowIndex;
            var scrollLines = SystemInformation.MouseWheelScrollLines;
            var dgv = (DataGridView)sender;
            try
            {
                if (e.Delta > 0)
                {
                    dgv.FirstDisplayedScrollingRowIndex = Math.Max(0, currentIndex - scrollLines);
                }
                else if (e.Delta < 0)
                {
                    dgv.FirstDisplayedScrollingRowIndex = currentIndex + scrollLines;
                }
            }
            catch { }
        }

        
        private void EnterToTab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }
        
    }
}
