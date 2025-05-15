using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;

using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Zumbach
{
    public partial class Kassera_Zumbach_Mätning : Form
    {
        readonly int bag;
        public Kassera_Zumbach_Mätning(int bag)
        {
            this.bag = bag;
            InitializeComponent();
            
            Translate_Form();
            Load_Data();
        }

        private void Translate_Form()
        {
            Control[] controls = { label_DiscardZumbachMeasurement_Header, btn_Discard, btn_Cancel };
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }
        public void Load_Data()
        {
            CheckBox[] chb = { chb_Pos1, chb_Pos2, chb_Pos3 };
            for (var i = 1; i < 4; i++)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT TOP(1) Discarded FROM Zumbach.Measurements
                                      WHERE OrderID = @orderid AND Bag = @bag AND Position = @pos";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@pos", i);
                    cmd.Parameters.AddWithValue("@bag", bag);
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    var flag = false;
                    if (value != null)
                        bool.TryParse(value.ToString(), out flag);

                    chb[i - 1].Checked = flag;
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Discard_Click(object sender, EventArgs e)
        {
            CheckBox[] chb = { chb_Pos1, chb_Pos2, chb_Pos3 };
            for (var position = 1; position < 4; position++)
            {
                
            }
            Close();
        }
    }
}
