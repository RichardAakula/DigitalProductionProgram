using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;

namespace DigitalProductionProgram.User
{
    public partial class UserPoll : Form
    {
        public static bool IsUserPoll_Ready_For_Show(string fråga)
        {
            if (string.IsNullOrEmpty(Person.Name))
                return false;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT * FROM [User].Gallup WHERE Done = 'True' AND Show_Result = 'True' AND Fråga = @fråga";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@namn", Person.Name);
                cmd.Parameters.AddWithValue("@fråga", fråga);
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
                return false;
            }
        }
        public static bool IsUserVotedPoll
        {
            get
            {
                if (string.IsNullOrEmpty(Person.Name))
                    return true;

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT Vote_Last_Gallup FROM [User].Person WHERE EmployeeNumber = @employeenumber";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@employeenumber", Person.EmployeeNr);
                    con.Open();
                    return (bool)cmd.ExecuteScalar();
                }
            }
        }
        private static string Ctr_Votes
        {
            get
            {
                var ctr_Total = 0;
                var ctr_Votes = 0;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = "SELECT Vote_Last_Gallup FROM [User].Person";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (bool.TryParse(reader["Vote_Last_Gallup"].ToString(), out var is_Vote))
                            if (is_Vote)
                                ctr_Votes++;
                        
                        ctr_Total++;
                    }
                }
                return $"{ctr_Votes} / {ctr_Total} röster - ca {ctr_Votes / (double)ctr_Total * 100: 0} % har röstat";
            }//$"{value:0.000}";
        }
        private new int Height => lbl_Fråga.Height + 150;


        public UserPoll()
        {
            InitializeComponent();
            Load_Gallup("SELECT * FROM [User].Gallup WHERE Done = 'False'");
            lbl_ctr_Votes.Text = Ctr_Votes;
            if (IsUserVotedPoll)
                Lock_Buttons();
            if (IsUserPoll_Ready_For_Show(lbl_Fråga.Text))
            {
                Initalize_GUI_Show_Result();
            }
        }

        private void Initalize_GUI_Show_Result()
        {
            Load_Gallup("SELECT * FROM [User].Gallup WHERE Done = 'True' AND Show_Result = 'True'");
            Lock_Buttons();

            var question = $"Undersökning är nu klar och du ser resultatet nedan. Frågan som var: \n\n {lbl_Fråga.Text}";
            lbl_Fråga.Text = question;
        }
        private void Load_Gallup(string query)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                 
                var cmd = new SqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lbl_Fråga.Text = reader["Fråga"].ToString();
                    if (!string.IsNullOrEmpty(reader["Bild"].ToString()))
                    {
                        var img = (byte[])(reader["Bild"]);
                        var ms = new MemoryStream(img);
                        pb_Bild.Image = Image.FromStream(ms);
                    }
                    lbl_Svar_1.Text = reader["SvarsAlternativ_1"].ToString();
                    lbl_Svar_2.Text = reader["SvarsAlternativ_2"].ToString();
                    lbl_Svar_3.Text = reader["SvarsAlternativ_3"].ToString();
                    lbl_Svar_4.Text = reader["SvarsAlternativ_4"].ToString();
                }
                                
            }
            if (pb_Bild.Image == null)
            {
                pb_Bild.Dispose();
                base.Height = Height + 5;
            }
            Load_Percent_Answer();
        }
        private void Load_Percent_Answer()
        {
            double percent_1 = 0;
            double percent_2 = 0;
            double percent_3 = 0;
            double percent_4 = 0;

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT Svar_1, Svar_2, Svar_3, Svar_4 FROM [User].Gallup WHERE Fråga = @fråga";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fråga", lbl_Fråga.Text);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var total = int.Parse(reader["Svar_1"].ToString()) + int.Parse(reader["Svar_2"].ToString()) + int.Parse(reader["Svar_3"].ToString()) + int.Parse(reader["Svar_4"].ToString());

                    double.TryParse(reader["Svar_1"].ToString(), out var svar_1);
                    double.TryParse(reader["Svar_2"].ToString(), out var svar_2);
                    double.TryParse(reader["Svar_3"].ToString(), out var svar_3);
                    double.TryParse(reader["Svar_4"].ToString(), out var svar_4);
                    if (total > 0)
                    {
                        percent_1 = svar_1 / total * 100;
                        percent_2 = svar_2 / total * 100;
                        percent_3 = svar_3 / total * 100;
                        percent_4 = svar_4 / total * 100;
                    }
                }
            }
            lbl_Percent_Svar_1.Text = $"{percent_1:0.0}" + " %";
            lbl_Percent_Svar_2.Text = $"{percent_2:0.0}" + " %";
            lbl_Percent_Svar_3.Text = $"{percent_3:0.0}" + " %";
            lbl_Percent_Svar_4.Text = $"{percent_4:0.0}" + " %";

        }
        private void Lock_Buttons()
        {
            lbl_Svar_1.Click -= Svar_Click;
            lbl_Svar_2.Click -= Svar_Click;
            lbl_Svar_3.Click -= Svar_Click;
            lbl_Svar_4.Click -= Svar_Click;
        }
        private void Update_User_Vote_Done()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "UPDATE [User].Person SET Vote_Last_Gallup = 'True' WHERE Name = @name";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", Person.Name);
                con.Open();
                cmd.ExecuteScalar();     
            }
        }

        private void Svar_Click(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            var query = "UPDATE [User].Gallup SET ";
            if (lbl == lbl_Svar_1)
                query += "Svar_1 = Svar_1 + 1 "; 
            if (lbl == lbl_Svar_2)
               query += "Svar_2 = Svar_2 + 1 ";
            if (lbl == lbl_Svar_3)
                query += "Svar_3 = Svar_3 + 1 ";
            if (lbl == lbl_Svar_4)
                query += "Svar_4 = Svar_4 + 1 ";

            query += "WHERE Fråga = @fråga";

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fråga", lbl_Fråga.Text);
                con.Open();
                cmd.ExecuteScalar();     
            }
            Update_User_Vote_Done();
            Close();

            Points.Add_Points(20, "Svarat Gallup");
        }

        private void label_Exit_Click(object sender, EventArgs e)
        {
            Log.Activity.Start();
            Close();
            _ = Log.Activity.Stop($"{Person.Name} stängde ner gallupen utan att rösta.");
            if (IsUserPoll_Ready_For_Show(lbl_Fråga.Text))
                SaveData.UPDATE_Användare_Seen_Gallup_Result();
        }
    }
}
