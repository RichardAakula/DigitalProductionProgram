using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Settings;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

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
            cb_Machine.Items.Clear();

            Database.ExecuteSafe(con =>
            {
                const string query = @"
                    SELECT DISTINCT TextValue 
                    FROM [Order].Data 
                    WHERE ProtocolDescriptionID = 
                    (
                        SELECT ID 
                        FROM Protocol.Description 
                        WHERE CodeText = @codetext
                    )";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@codetext", SqlDbType.NVarChar, 50).Value = "Machine";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var value = reader.IsDBNull(reader.GetOrdinal("TextValue")) ? string.Empty : reader["TextValue"].ToString();

                    if (!string.IsNullOrEmpty(value))
                        cb_Machine.Items.Add(value);
                }
            });
        }

        public static void Ask()
        {
            using var addNewLine = new AddNewLine();
            addNewLine.ShowDialog();
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
            linje = cb_Machine.Text;
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
