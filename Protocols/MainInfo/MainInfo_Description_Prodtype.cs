using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;

namespace DigitalProductionProgram.Protocols.MainInfo
{
    public partial class MainInfo_Description_Prodtype : UserControl
    {
        public MainInfo_Description_Prodtype()
        {
            InitializeComponent();
            
        }

        public void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { label_Customer, label_Description, label_Amount, label_PartNumber, label_OrderNr, label_ProdType });
        }
        public void Load_Data(int? OrderID)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"SELECT OrderNr, PartNr, Description, Customer, ProdType, Amount FROM [Order].MainData WHERE OrderID = @id";

            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", OrderID);
            var reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    lbl_OrderNr.Text = reader["OrderNr"].ToString();
                    lbl_ArtikelNr.Text = reader["PartNr"].ToString();
                    lbl_Description.Text = reader["Description"].ToString();
                    lbl_Customer.Text = reader["Customer"].ToString();
                    lbl_Prodtype.Text = reader["ProdType"].ToString();
                    lbl_Total.Text = reader["Amount"].ToString();
                }
            }
        }
    }
}
