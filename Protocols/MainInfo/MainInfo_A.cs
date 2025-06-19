using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;

namespace DigitalProductionProgram.Protocols.MainInfo
{
    public partial class MainInfo_A : UserControl
    {
        public MainInfo_A()
        {
            InitializeComponent();
        }
        public void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { label_Customer, label_Amount, label_PartNumber, label_ProdType });
        }
        public void Load_Data(int? OrderID)
        {
            Translate_Form();
            Room_TempMoisture.Load_Data();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"SELECT OrderNr, PartNr, ProdType, Customer, Amount FROM [Order].MainData WHERE OrderID = @orderid";

            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", OrderID);
            var reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    lbl_OrderNr.Text = reader["OrderNr"].ToString();
                    lbl_PartNumber.Text = reader["PartNr"].ToString();
                    lbl_ProdType.Text = reader["ProdType"].ToString();
                    lbl_Customer.Text = reader["Customer"].ToString();
                    lbl_Antal.Text = reader["Amount"].ToString();
                }
            }
        }

      
    }
}
