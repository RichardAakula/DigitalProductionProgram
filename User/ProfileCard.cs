using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;

using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.User
{
    public partial class ProfileCard : UserControl
    {
        public ProfileCard()
        {
            InitializeComponent();
            if (Program.IsComputerOnlyForMeasurements)
            {
                chb_OpenLastOrder.Enabled = true;
                chb_OpenLastOrder.Checked = true;
            }
            BackColor = Color.FromArgb(180, Color.Black);
        }

        public void Translate_Form()
        {
            Control[] controls = { label_Department, label_EmpNr, label_Sign, label_Role, chb_OpenLastOrder };
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }
        public void GetLatestOrderForOperaton(string anstNr)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT TOP(1) OrderID, OrderNr
                    FROM Measureprotocol.MainData AS mp 
                    INNER JOIN [Order].MainData AS kp
                        ON mp.OrderID = kp.OrderID 
                    WHERE AnstNr = @employeenumber 
                    AND IsOrderDone = 'False'
                    ORDER BY Date DESC";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@employeenumber", anstNr);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lbl_LastOrder.Text = reader["OrderNr"].ToString();
                    Order.OrderID = (int)reader["OrderID"];
                }
            }
        }
    }
}
