using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;

namespace DigitalProductionProgram.User
{
    public partial class Add_UserPoll : Form
    {
        private byte[] Picture
        {
            get
            {
                var picLocation = string.Empty;
               using  var dlg = new OpenFileDialog
                {
                    Filter = "JPG Files(*.jpg).*jpg|PNG Files(*.png)|GIF Files(*.gif)|*.gif|All Files(*.*)|*.*",
                    Title = "Välj en bild om du vill ha en bild med i Gallupen."
                };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    picLocation = dlg.FileName;
                }

                if (!string.IsNullOrEmpty(picLocation))
                {
                    var fs = new FileStream(picLocation, FileMode.Open, FileAccess.Read);
                    var br = new BinaryReader(fs);
        
                    return br.ReadBytes((int)fs.Length);
                }
                return null;
            }
        }



        public Add_UserPoll()
        {
            InitializeComponent();
            Load_Last_Gallup();
        }

        private void Add_Question()
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var _img = Picture;
            string query;
            if (_img == null)
                query = "INSERT INTO [User].Gallup (Fråga, SvarsAlternativ_1, SvarsAlternativ_2, SvarsAlternativ_3,SvarsAlternativ_4, Svar_1, Svar_2, Svar_3, Svar_4, Done, Show_Result) VALUES (@question, @svarAlt_1, @svarAlt_2, @svarAlt_3, @svarAlt_4, 0, 0, 0, 0, 'False', 'False')";
            else
                query = "INSERT INTO [User].Gallup (Fråga, Bild, SvarsAlternativ_1, SvarsAlternativ_2, SvarsAlternativ_3,SvarsAlternativ_4, Svar_1, Svar_2, Svar_3, Svar_4, Done, Show_Result) VALUES (@question, @img, @svarAlt_1, @svarAlt_2, @svarAlt_3, @svarAlt_4, 0, 0, 0, 0, 'False', 'False')";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            cmd.Parameters.AddWithValue("@question", tb_Fråga.Text);
            cmd.Parameters.AddWithValue("@svarAlt_1", tb_SvarAlt_1.Text);
            cmd.Parameters.AddWithValue("@svarAlt_2", tb_SvarAlt_2.Text);
            cmd.Parameters.AddWithValue("@svarAlt_3", tb_SvarAlt_3.Text);
            cmd.Parameters.AddWithValue("@svarAlt_4", tb_SvarAlt_4.Text);
            if (_img != null)
                cmd.Parameters.AddWithValue("@img", _img);
                    
            cmd.ExecuteNonQuery();

            con.Close();
        }
        private void Clear_User_Votes()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "UPDATE [User].Person SET Vote_Last_Gallup = 'False'";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                cmd.ExecuteScalar();     
            }
        }
        private void Load_Last_Gallup()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT * FROM [User].Gallup WHERE Done = 'False' AND Show_Result = 'False'";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tb_Fråga.Text = reader["Fråga"].ToString();
                    tb_SvarAlt_1.Text = reader["SvarsAlternativ_1"].ToString();
                    tb_SvarAlt_2.Text = reader["SvarsAlternativ_2"].ToString();
                    tb_SvarAlt_3.Text = reader["SvarsAlternativ_3"].ToString();
                    tb_SvarAlt_4.Text = reader["SvarsAlternativ_4"].ToString();
                }
            }
        }
        private void lbl_Add_Picture_Click(object sender, EventArgs e)
        {
            Add_Question();
           // Clear_User_Votes();
            Close();
        }

        private void lbl_Gallup_Done_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "UPDATE [User].Gallup SET Show_Result = 'True', Done = 'True' WHERE Fråga = @fråga";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@fråga",tb_Fråga.Text);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

       
    }
}
