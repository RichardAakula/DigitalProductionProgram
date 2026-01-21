using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace DigitalProductionProgram.Protocols.LineClearance
{
    public partial class LineClearance : UserControl
    {
        public static bool IsLineClearanceDone
        {
            get
            {
                if (Order.OrderID == null)
                    return false;
                return Database.ExecuteSafe(con =>
                {
                    var query = $@"SELECT LC_Name FROM [Order].MainData {Queries.WHERE_OrderID}";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    var value = cmd.ExecuteScalar();
                    return value != DBNull.Value;
                });
            }
        }
        public static bool IsLineClearanceApproved
        {
            get
            {
                if (Order.OrderID == null)
                    return false;
                return Database.ExecuteSafe(con =>
                {
                    var query = @"SELECT LC_Approved_Name FROM [Order].MainData WHERE OrderID = @orderid";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    var value = cmd.ExecuteScalar();
                    if (value == null || value == DBNull.Value)
                        return false;

                    return !string.IsNullOrEmpty(value.ToString());
                });
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
                using var lc = new LineClearance_Extra();
                using var black = new BlackBackground("", 75);
                black.Show();
                lc.ShowDialog();
                black.Close();
                return;
            }

            if (Korprotokoll.IsProtocol_Open_By_AnotherUser(null) || (!string.IsNullOrEmpty(lbl_LC_Name.Text) && lbl_LC_Name.Text != LanguageManager.GetString("lbl_LC_Name")))
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
            Database.ExecuteSafe(con =>
            {
                const string query = @"
                    SELECT 
                        LC_Date, 
                        LC_Name
                    FROM [Order].MainData
                    WHERE OrderID = @orderid";

                var cmd = new SqlCommand(query, con);
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
            });
        }

        public static void SaveLineClearance(string name, string date)
        {
            Database.ExecuteSafe(con =>
            {
                var query = @"
                    BEGIN
                        INSERT INTO Log.ActivityLog
                            (
                                HostID, 
                                UserID, 
                                OrderID, 
                                Program, 
                                Version, 
                                Date,   
                                Info
                            )
                        VALUES
                            (
                                (SELECT HostID FROM [Settings].General WHERE HostName = @hostname), 
                                @userid, 
                                @orderid, 
                                @program, 
                                @version, 
                                @date,                            
                                'LineClearance Done'
                        )
                    END;    
                    BEGIN
                        UPDATE [Order].MainData 
                        SET 
                            LC_Name = @lc_name, 
                            LC_Date = @lc_date 
                        WHERE OrderID = @orderid
                    END;";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@lc_name", name);
                cmd.Parameters.AddWithValue("@lc_date", date);
                SQL_Parameter.Int(cmd.Parameters, "@userid", Person.UserID);
                cmd.Parameters.AddWithValue("@hostname", Activity.HostName);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@program", "SaveData");
                cmd.Parameters.AddWithValue("@version", ChangeLog.CurrentVersion.ToString());
                cmd.ExecuteNonQuery();
            });
        }
        public static void SaveApprovedLineClearance(string name, string date)
        {
            Database.ExecuteSafe(con =>
            {
                var query =
                    "UPDATE [Order].MainData SET LC_Approved_Date = @date, LC_Approved_Name = @name WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            });
        }

    }
}
