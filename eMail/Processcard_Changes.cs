using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.eMail
{
    public partial class Processcard_Changes : Form
    {
        private readonly BlackBackground black = new BlackBackground("", 80);
        public static bool IsMessageSaved;
        private readonly string Header;
        private readonly int ProtocoldescriptionID;





        public Processcard_Changes(string header, int protocoldescriptionid)
        {
            black.Show();

            Header = header;
            ProtocoldescriptionID = protocoldescriptionid;
            InitializeComponent();
            Translate_Form();
            label_Meddelande_Rubrik.Text = Header.Replace("<br />", "\n");
            IsMessageSaved = false;
        }


        private void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { label_Info_ProcesscardChange, lbl_SaveMessage, lbl_Abort });
        }


        private void SaveMessage_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"INSERT INTO Processcard.ProposedChanges (OrderID, ProtocolDescriptionID, Rubrik, Meddelande, Namn, Datum) 
                              VALUES (@orderid, @protocoldescriptionid, @rubrik, @meddelande, @namn, @datum)";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                SQL_Parameter.Int(cmd.Parameters, "@protocoldescriptionid", ProtocoldescriptionID);
                cmd.Parameters.AddWithValue("@rubrik", Header);
                cmd.Parameters.AddWithValue("@meddelande", tb_Meddelande.Text);
                cmd.Parameters.AddWithValue("@namn", Person.Name);
                cmd.Parameters.AddWithValue("@datum", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            IsMessageSaved = true;
            Close();
        }
        private void AbortClick(object sender, EventArgs e)
        {
            Close();
        }
        private void Processcard_Changes_FormClosing(object sender, FormClosingEventArgs e)
        {
            black.Close();
        }
    }
}
