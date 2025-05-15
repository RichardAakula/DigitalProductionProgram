using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Settings;

namespace DigitalProductionProgram.Protocols.Skärmning_TEF
{
    public partial class AddNewLine : Form
    {
        static AddNewLine question;
        public static string linje;
        public static string sida;


        public AddNewLine()
        {
            InitializeComponent();
            
            Fill_ComboBox();
        }

        private void Fill_ComboBox()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "SELECT DISTINCT(TextValue) FROM [Order].Data WHERE ProtocolDescriptionID = (SELECT ID FROM Protocol.Description WHERE CodeText = 'Machine')"; //Maskin
                con.Open();
                var cmd = new SqlCommand(query, con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    cb_Linje.Items.Add(reader[0].ToString());
            }
        }
        public static void Ask()
        {
            question = new AddNewLine();
            question.ShowDialog();
        }
        private void Side_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                lbl_Side.Text = ControlValidator.Next_Letter(lbl_Side.Text, true);
            else
                if (lbl_Side.Text != "A")
                    lbl_Side.Text = ControlValidator.Next_Letter(lbl_Side.Text, false);
        }
        private void Back_Click(object sender, EventArgs e)
        {
            linje = cb_Linje.Text;
            sida = lbl_Side.Text;
            Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            linje = string.Empty;
            sida = string.Empty;
            Close();
        }
    }
}
