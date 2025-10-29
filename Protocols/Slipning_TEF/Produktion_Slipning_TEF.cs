using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.Slipning_TEF
{
    public partial class Produktion_Slipning_TEF : UserControl
    {
        public static DataTable DataTable_Parts_Slipning_TEF_Extra
        {
            //Dessa artikelnr skall ha lite extra parametrar i körprotokollet
            get
            {
                var dt = new DataTable();
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"SELECT PartNr FROM Parts.PartNrSpecial WHERE PartNrDescriptionID = (SELECT id FROM Parts.PartNrDescription WHERE description = 'Extra Parametrar Slipning_TEF')";

                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }
        private Control[] Control_Produktion_Parametrar
        {
            get
            {
                Control[] ctrl = {tb_Inledande_LotNr, tb_Inledande_Påse, tb_Mjukslang_ID, tb_Mjukslang_OD_kort,  tb_SkärmadSlang_ID, tb_SkärmadSlang_OD, tb_SkärmadSlang_Längd, tb_Antal_Godkända, tb_Lev_Påse,
                    tb_Dragprov_Antal, tb_Hållfasthet_Newton_kort, tb_Hållfasthet_Procent_kort, tb_ProvAntal_QC};
                return ctrl;
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
                return true;
            }
        }
        public bool IsProduktion_Slipning_Data_Saved
        {
            get
            {
                foreach (var ctrl in Control_Produktion_Parametrar)
                {
                    if (!string.IsNullOrEmpty(ctrl.Text))
                        return false;
                }
                return true;
            }
        }
        private bool IsUpdating_Parameter;
        private int Editing_Row;



        public Produktion_Slipning_TEF()
        {
            InitializeComponent();
            
            dgv_Produktion.MouseWheel += Scroll_MouseWheel;
        }
        public void Fill_Inledande_LotNr()
        {
            Monitor.Monitor.Load_PartMaterial();
        }
        public void Change_GUI()
        {
            if (Part.IsPartNrSpecial == false)
            {
                //Döljer dom extra kolumnerna vid körning med dubbla halvfabrikat
                tlp_Main.ColumnStyles[5].Width = 0;
                tlp_Main.ColumnStyles[13].Width = 0;
                tlp_Main.ColumnStyles[15].Width = 0;
               // tlp_Main.ColumnStyles[19].Width = 10;

                label_ODmm_kort.Dispose();
                label_ODmm_lång.Dispose();
                label_Hållfasthet_1_kort.Dispose();
                label_Hållfasthet_1_lång.Dispose();
                label_Hållfasthet_2_kort.Dispose();
                label_Hållfasthet_2_lång.Dispose();
                tb_Mjukslang_OD_lång.Dispose();
                tb_Hållfasthet_Newton_lång.Dispose();
                tb_Hållfasthet_Procent_lång.Dispose();

                tlp_Main.SetColumnSpan(label_Mjukslang_OD, 1);
                tlp_Main.SetColumnSpan(label_Hållfasthet_enhet, 1);
                tlp_Main.SetColumnSpan(label_Hållfasthet_Procent, 1);

                tlp_Main.SetRowSpan(label_Mjukslang_OD, 2);
                tlp_Main.SetRowSpan(label_Hållfasthet_enhet, 2);
                tlp_Main.SetRowSpan(label_Hållfasthet_Procent, 2);

                label_Mjukslang_OD.Margin = new Padding(1, 0, 0, 1);
                label_Hållfasthet_enhet.Margin = new Padding(1, 0, 0, 1);
                label_Hållfasthet_Procent.Margin = new Padding(1, 0, 0, 1);

                dgv_Produktion.Columns[4].Visible = false;
                dgv_Produktion.Columns[12].Visible = false;
                dgv_Produktion.Columns[14].Visible = false;
                
            }

        }


        private void Save_Click(object sender, EventArgs e)
        {
            if (!IsProduktion_Filled)
            {
                InfoText.Show("Fyll i alla parametrar före du överför.", CustomColors.InfoText_Color.Bad, "Warning!");
                return;
            }
            if (!Person.IsUserSignedIn(true))
                return;

            if (IsUpdating_Parameter == false)
            {//Om en ny rad skall läggas till
                using var black = new BlackBackground(string.Empty, 80);
                using var password = new PasswordManager(LanguageManager.GetString("confirmTransferPassword"));
                black.Show();
                password.ShowDialog();
                black.Close();
                if (password.IsOk == false)
                    return;
                Save_Data(string.Empty);
            }
            else
            {//Om operatören uppdaterar en rad
                var date = dgv_Produktion.Rows[Editing_Row].Cells["ExactDate"].Value.ToString();
                Save_Data(date);
                IsUpdating_Parameter = false;
            }

            Load_Data();
            ControlManager.Clear_TextBoxes(Control_Produktion_Parametrar);
            if (Part.IsPartNrSpecial)
                ControlManager.Clear_TextBoxes(new[] {tb_Mjukslang_OD_lång, tb_Hållfasthet_Newton_lång, tb_Hållfasthet_Procent_lång});
            ControlManager.Unlock_Controls(Control_Produktion_Parametrar);
            ControlManager.Unlock_Controls(new Control[] { lbl_Edit_Row_Produktion, lbl_Kassera_Produktion });
            lbl_Edit_Row_Produktion.BackColor = Color.FromArgb(255, 235, 156);
            lbl_Kassera_Produktion.BackColor = Color.FromArgb(255, 199, 206);
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            Editing_Row = dgv_Produktion.CurrentCell.RowIndex;
            bool.TryParse(dgv_Produktion.Rows[Editing_Row].Cells["Discarded"].Value.ToString(), out bool IsDiscarded);
            if (IsDiscarded)
            {
                InfoText.Show("Du kan inte redigera en skrotad rad.", CustomColors.InfoText_Color.Bad, "Warning!",this);
                return;
            }
            IsUpdating_Parameter = true;
            
            for (var col = 0; col < 16; col++)
            {
                if (Part.IsPartNrSpecial == false && (col == 4 || col == 12 || col == 14))
                    continue;
                tlp_Main.GetControlFromPosition(col + 1, 6).Text = dgv_Produktion.Rows[Editing_Row].Cells[col].Value.ToString();
            }

            ControlManager.Lock_Controls(new Control[] {tb_Inledande_Påse, tb_Mjukslang_ID, tb_Mjukslang_OD_kort, tb_Mjukslang_OD_lång, tb_SkärmadSlang_ID, tb_SkärmadSlang_OD, tb_SkärmadSlang_Längd,
                tb_Dragprov_Antal, tb_Hållfasthet_Newton_kort, tb_Hållfasthet_Newton_lång, tb_Hållfasthet_Procent_kort, tb_Hållfasthet_Procent_lång, lbl_Kassera_Produktion, lbl_Edit_Row_Produktion }, true);

            tb_Antal_Godkända.Focus();
        }
        private void Discard_Click(object sender, EventArgs e)
        {
            InfoText.Question("Vill du skrota denna rad?", CustomColors.InfoText_Color.Info,null,this);
            if (InfoText.answer == InfoText.Answer.Yes)
            {
                if (sender == lbl_Kassera_Produktion)
                {
                    var row = dgv_Produktion.CurrentCell.RowIndex;
                    var date = DateTime.ParseExact(dgv_Produktion.Rows[row].Cells["ExactDate"].Value.ToString(), "yyyy-MM-dd HH:mm:ss", null);

                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        var query = @"
                            UPDATE Korprotokoll_Slipning_Produktion 
                            SET Bool = 'True' WHERE OrderID = @orderid AND CodeText = 'Kasserad' 
                                AND Date_Time = @date";

                        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                        cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                        cmd.Parameters.AddWithValue("@date", date);
                        con.Open();
                        cmd.ExecuteScalar();
                    }
                    Load_Data();
                }
            }
        }

        public void Load_Data()
        {
            dgv_Produktion.Rows.Clear();
            var row = -1;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT CodeText, Value, Text, Bool, Date_Time, EmployeeNumber, Signature, Column_Index, TempID FROM Korprotokoll_Slipning_Produktion AS prod
                    JOIN [User].Person AS op
                        ON op.EmployeeNumber = prod.AnstNr
                    WHERE OrderID = @id ORDER BY Date_Time, Column_Index";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //var row = int.Parse(reader["RowID"].ToString());
                    
                    string text = null;
                    if (int.TryParse(reader["Column_Index"].ToString(), out var colIndex))
                    {
                        
                        switch (colIndex)
                        {
                            //Text
                            case 0:
                            case 8:
                            case 9:
                            case 15:
                                text = reader["Text"].ToString();
                                break;
                            //Heltal
                            case 1:
                            case 7:
                            case 10:
                            case 13:
                            case 14:
                                double.TryParse(reader["Value"].ToString(), out var intValue);
                                text = $"{intValue:0}";
                                break;
                            //2 Decimaler
                            case 2: case 3: case 4: case 5: case 6:
                                double.TryParse(reader["Value"].ToString(), out var value);
                                text = $"{value:0.00}";
                                break;
                            //1 Decimal
                            case 11: case 12:
                                double.TryParse(reader["Value"].ToString(), out value);
                                text = $"{value:0.0}";
                                break;
                        }

                        dgv_Produktion.Rows[row].Cells[colIndex].Value = text;
                    }
                    else
                    {
                        row++;
                        dgv_Produktion.Rows.Add();
                        int.TryParse(reader["TempID"].ToString(), out int id);
                        var date = DateTime.Parse(reader["Date_Time"].ToString());
                        dgv_Produktion.Rows[row].Cells["Date"].Value = date.ToString("yyyy-MM-dd HH:mm");
                        dgv_Produktion.Rows[row].Cells["ExactDate"].Value = date.ToString("yyyy-MM-dd HH:mm:ss");
                        dgv_Produktion.Rows[row].Cells["AnstNr"].Value = reader["EmployeeNumber"].ToString();
                        dgv_Produktion.Rows[row].Cells["Sign"].Value = reader["Signature"].ToString();
                        dgv_Produktion.Rows[row].Cells["ID"].Value = id;
                        bool.TryParse(reader["Bool"].ToString(), out var IsDiscarded);
                        dgv_Produktion.Rows[row].Cells["Discarded"].Value = IsDiscarded;
                        if (IsDiscarded)
                        {
                            dgv_Produktion.Rows[row].DefaultCellStyle.BackColor = CustomColors.Bad_Back;
                            dgv_Produktion.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Bad_Front;
                            dgv_Produktion.Rows[row].DefaultCellStyle.Font = new Font("Courier New", (float)8.5, FontStyle.Italic | FontStyle.Strikeout);
                            
                        }
                        else
                        {
                            dgv_Produktion.Rows[row].DefaultCellStyle.BackColor = CustomColors.Ok_Back;
                            dgv_Produktion.Rows[row].DefaultCellStyle.ForeColor = CustomColors.Ok_Front;
                        }
                    }
                }
            }
        }
        public void Load_Hållfasthet_Enhet()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT Dragprov_enhet FROM Processkort_Slipning WHERE PartID = @partID";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.Parameters.AddWithValue("@partID", Order.PartID);
                if (string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()) == false)
                    label_Hållfasthet_enhet.Text = cmd.ExecuteScalar().ToString();
            }
        }
        private void Save_Data(string date)
        {
            Points.Add_Points(7, $"Överför Produktion - Slipning, IsUpdating = {IsUpdating_Parameter}, RowID = RowID");
            var dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            for (var col = -1; col < 16; col++)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        IF EXISTS 
                        (SELECT * FROM Korprotokoll_Slipning_Produktion 
                            WHERE CodeText = @codetext AND OrderID = @orderid AND Date_Time = @dateTime)
                            BEGIN
                                UPDATE Korprotokoll_Slipning_Produktion 
                                SET Value = @value, Text = @text
                                WHERE CodeText = @codetext AND OrderID = @orderid AND Date_Time = @dateTime
                            END
                        ELSE
                            BEGIN
                                INSERT INTO Korprotokoll_Slipning_Produktion 
                                VALUES (@orderid, @codeText, @Value, @text, @bool, @date, @employeenumber, @colIndex)
                            END";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                if (col < 0)
                {
                    cmd.Parameters.AddWithValue("@codeText", "Kasserad");
                    SQL_Parameter.Boolean(cmd.Parameters, "@bool", "False");
                    SQL_Parameter.Int(cmd.Parameters, "@colIndex", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@codeText", dgv_Produktion.Columns[col].HeaderText);
                    SQL_Parameter.Boolean(cmd.Parameters, "@bool", DBNull.Value);
                    SQL_Parameter.Int(cmd.Parameters, "@colIndex", col);
                }

                switch (col)
                {

                    case 0: case 8: case 9: case 15:
                        var control = tlp_Main.GetControlFromPosition(col + 1, 6);
                        var text = control?.Text ?? string.Empty;
                        SQL_Parameter.String(cmd.Parameters, "@text", text);
                        SQL_Parameter.Double(cmd.Parameters, "@value", DBNull.Value);
                        break;
                       
                    default:
                        if (Part.IsPartNrSpecial == false && col is 4 or 12 or 14)
                            continue;

                        var ctrl = tlp_Main.GetControlFromPosition(col + 1, 6);
                        text = ctrl?.Text ?? string.Empty;
                        double.TryParse(text, out var value);

                        SQL_Parameter.Double(cmd.Parameters, "@value", value);
                        SQL_Parameter.String(cmd.Parameters, "@text", string.Empty);
                        break;
                }
                    
                cmd.Parameters.AddWithValue("@date", dateTime);
                cmd.Parameters.AddWithValue("@dateTime", date);
                cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                cmd.Parameters.AddWithValue("@sign", Person.Sign);

                con.Open();
                cmd.ExecuteScalar();
            }
            

        }
       
      
        private void Scroll_MouseWheel(object sender, MouseEventArgs e)
        {
            var currentIndex = dgv_Produktion.FirstDisplayedScrollingRowIndex;
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
        //private void Inledande_LotNr_Enter(object sender, EventArgs e)
        //{
        //    var ctrl = (Control) sender;
        //    var list = new List<string?>();

        //    if (Monitor.Monitor.Part_Material is null == false)
        //        list = Monitor.Monitor.PreFab_BatchNr(Monitor.Monitor.Part_Material.PartNumber);

        //    for (var i = 0; i < dgv_Produktion.Rows.Count; i++)
        //    {
        //        if (list.Contains(dgv_Produktion.Rows[i].Cells[0].Value.ToString()) == false)
        //            list.Add(dgv_Produktion.Rows[i].Cells[0].Value.ToString());
        //    }
        //    using var choose_Item = new Choose_Item(list, new[] {ctrl}, false);
        //    choose_Item.ShowDialog();

        //    _ = Activity.Stop(Monitor.Monitor.Part_Material is null == false ? 
        //        $"Felsökning tomma lotnr Slipning: ArtikelNr halvfabrikat: {Monitor.Monitor.Part_Material.PartNumber}. Antal i list: {list.Count}" : 
        //        $"Felsökning tomma lotnr Slipning: Monitor.Load_Data.Part_Material.PartNumber is null. Antal i list: {list.Count}");
        //}
        private async void Inledande_LotNr_Enter(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var list = new List<string?>();

            if (Monitor.Monitor.Part_Material != null)
            {
                // Kör PreFab_BatchNr asynkront
                list = await Task.Run(() => Monitor.Monitor.PreFab_BatchNr(Monitor.Monitor.Part_Material.PartNumber));
            }

            // Lägg till lotnr från datagrid
            for (var i = 0; i < dgv_Produktion.Rows.Count; i++)
            {
                var value = dgv_Produktion.Rows[i].Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(value) && !list.Contains(value))
                    list.Add(value);
            }

            using var choose_Item = new Choose_Item(list, new[] { ctrl }, false);
            choose_Item.ShowDialog();

            _ = Activity.Stop(Monitor.Monitor.Part_Material != null
                ? $"Felsökning tomma lotnr Slipning: ArtikelNr halvfabrikat: {Monitor.Monitor.Part_Material.PartNumber}. Antal i list: {list.Count}"
                : $"Felsökning tomma lotnr Slipning: Monitor.Load_Data.Part_Material.PartNumber is null. Antal i list: {list.Count}");
        }


        private void Mått_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }
        private void ID_OD_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            Validate_Data(tb, 10);
        }
        private void SkärmadSlang_Längd_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            Validate_Data(tb, 3000);
        }
        private void Hållfasthet_Newton_kort_lång_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            Validate_Data(tb, 100);
        }
        private void Hållfasthet_Procent_kort_lång_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            Validate_Data(tb, 1000);
        }
        private void EnterToTab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void Validate_Data(TextBox tb, double MaxValue)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.BackColor = Color.White;
                tb.ForeColor = Color.DarkSlateGray;
                return;
            }
            var IsWarning = double.TryParse(tb.Text, out var result) == false || result > MaxValue;

            if (IsWarning)
            {
                tb.BackColor = CustomColors.Warning_Back;
                tb.ForeColor = CustomColors.Warning_Front;
            }
            else
            {
                tb.BackColor = CustomColors.Ok_Back;
                tb.ForeColor = CustomColors.Ok_Front;
            }
        }
    }
}
