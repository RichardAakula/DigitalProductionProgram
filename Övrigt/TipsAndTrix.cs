using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;

using DigitalProductionProgram.PrintingServices;
using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Övrigt
{
    public partial class TipsAndTrix : UserControl
    {
        public TipsAndTrix()
        {
            InitializeComponent();
        }

        private void Info_Tips_Trix_Click(object sender, EventArgs e)
        {
            InfoText.Show(LanguageManager.GetString("tips_Info_1"), CustomColors.InfoText_Color.Info, "Info", this);
        }

        private void Text_Tips_Trix_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                colorDialog1.Color = rb_Text_Tips_Trix.SelectionColor;
                fontDialog1.Font = rb_Text_Tips_Trix.SelectionFont;

                colorDialog1.ShowDialog();
                fontDialog1.ShowDialog();

                rb_Text_Tips_Trix.SelectionColor = colorDialog1.Color;
                rb_Text_Tips_Trix.SelectionFont = fontDialog1.Font;

                Save_Tips_Trix();
                //Set_Standard_Font_Color_Text();
            }
        }
       private void Text_Tips_Trix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Order.PartNumber is null)
                e.Handled = true;
        }
        private void Text_Tips_Trix_KeyUp(object sender, KeyEventArgs e)
        {
            Save_Tips_Trix();
        }
        private void Save_Tips_Trix()
        {
            if (Order.PartNumber is null)
                return;
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"IF EXISTS (SELECT * FROM ArtikelNr_Tips_Trix WHERE ArtikelNr = @partnr AND WorkOperation = @workoperation)
                                     UPDATE ArtikelNr_Tips_Trix SET Text = @text WHERE ArtikelNr = @partnr AND WorkOperation = @workoperation
                                     ELSE
                                     INSERT INTO ArtikelNr_Tips_Trix (ArtikelNr, Text, WorkOperation) VALUES (@partnr, @text, @workoperation)";
            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
            cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation.ToString());
            cmd.Parameters.AddWithValue("@text", rb_Text_Tips_Trix.Rtf);
            cmd.ExecuteNonQuery();
        }
       
        public void LoadData()
        {
            if (string.IsNullOrEmpty(Order.PartNumber))
                return;
            rb_Text_Tips_Trix.Text = string.Empty;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "SELECT Text FROM ArtikelNr_Tips_Trix WHERE ArtikelNr = @partnr AND WorkOperation = @workoperation";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation.ToString());
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rb_Text_Tips_Trix.Rtf = reader[0].ToString();
                }
            }

            if (rb_Text_Tips_Trix.Text.Length > 5)
                rb_Text_Tips_Trix.Dock = DockStyle.Fill;
            else
                rb_Text_Tips_Trix.Dock = DockStyle.Top;
        }
        public void ClearData()
        {
            rb_Text_Tips_Trix.Text = string.Empty;
        }


    }
}
