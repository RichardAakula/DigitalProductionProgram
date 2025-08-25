using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.LineClearance
{
    public partial class LineClearance : UserControl
    {
        public static bool IsLineClearanceDone
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"SELECT LC_Name FROM [Order].MainData {Queries.WHERE_OrderID}";

                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    var value = cmd.ExecuteScalar();
                    return value != DBNull.Value;
                }
            }
        }
        public static bool IsLineClearanceApproved
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $@"SELECT LC_Approved_Name FROM [Order].MainData WHERE OrderID = @orderid";

                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    var value = cmd.ExecuteScalar();
                    if (value == DBNull.Value)
                        return false;
                    return !string.IsNullOrEmpty(value.ToString());
                }
            }
        }

        public LineClearance()
        {
            InitializeComponent();
            pb_Info_LineClearance.Click += Public_Events.pb_Info_LineClearance_Click;
        }



        public void Translate_Form()
        {
            label_LC_Name_Date.Text = LanguageManager.GetString("print_LineClearance_1");
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{lbl_LC_Name });
        }
       

        private void LC_Performed_Click(object sender, EventArgs e)
        {
            if ((Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID ?? 0) != 0)
            {
                var lc = new LineClearance_Extra();
                var black = new BlackBackground("", 75);
                black.Show();
                lc.ShowDialog();
                black.Close();
                return;
            }

            if (Korprotokoll.IsProtocol_Open_By_AnotherUser(null) || (string.IsNullOrEmpty(lbl_LC_Name.Text) == false && lbl_LC_Name.Text != LanguageManager.GetString("lbl_LC_Name")))
                return;
            if (Person.IsPasswordOk(LanguageManager.GetString("lineClearance_Info_1")) && IsLineClearanceDone == false)
            {
                lbl_LC_Name.Text = Person.Name;
                LC_Date.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                LC_Date.ForeColor = Color.FromArgb(10, 10, 10);
                SaveLineClearance(lbl_LC_Name.Text, LC_Date.Text);
            }
        }
        public void Load_Data(int? OrderID)
        {
            Translate_Form();
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    SELECT 
                        LC_Date, 
                        LC_Name
                    FROM [Order].MainData
                    WHERE OrderID = @orderid";

            con.Open();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", OrderID);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (DateTime.TryParse(reader["LC_Date"].ToString(), out var date))
                {
                    var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                    var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                    LC_Date.Text = formattedDate;
                }
                        
                if (!string.IsNullOrEmpty(reader["LC_Name"].ToString()))
                    lbl_LC_Name.Text = reader["LC_Name"].ToString();
            }
        }

        

        public static void SaveLineClearance(string name, string date)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "UPDATE [Order].MainData SET LC_Name = @lc_name, LC_Date = @lc_date WHERE OrderID = @orderid";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@lc_name", name);
                cmd.Parameters.AddWithValue("@lc_date", date);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
