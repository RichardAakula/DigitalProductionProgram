using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.User
{
    public partial class PasswordManager : Form 
    {
        public bool IsOk;
        public static string ConvertFromHashedPassword(string password)
        {
            // Create SHA-512 hash
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        public static string ConvertToHashedPassword(string password)
        {
            using (var sha512 = SHA512.Create())
            {
                var hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    builder.Append(b.ToString("x2")); // Convert to hexadecimal
                }
                return builder.ToString();
            }

        }



        public PasswordManager(string? text)
        {
            InitializeComponent();
            label_Header.Text = text;
            tb_Name.Text = Person.Name;
            Opacity = 0.85;
            IsOk = false;
            label_PasswordInfo.Text = LanguageManager.GetString("label_PasswordInfo");
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{label_PasswordUser, label_PasswordPassword, lbl_Abort});
        }


        public void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                var con = new SqlConnection(Database.cs_Protocol);
                var cmd = new SqlCommand("SELECT Password FROM [User].Person WHERE EmployeeNumber = @employeenumber", con);
                cmd.Parameters.AddWithValue(@"employeenumber", Person.EmployeeNr);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    Person.Password = reader[0].ToString();
                reader.Close();
                con.Close();

                if (IsPasswordOK(tb_Password.Text) == false)
                {
                    InfoText.Show(LanguageManager.GetString("password_Info_1"), CustomColors.InfoText_Color.Bad, "Warning!", this);
                    IsOk = false;
                    tb_Password.SelectAll();
                    return;
                }
                IsOk = true;
                Close();
            }
        }
        
        public static bool IsPasswordOK(string password)
        {
            return Person.Password == ConvertFromHashedPassword(password);
        }

        private void Password_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Person.Password != ConvertFromHashedPassword(tb_Password.Text))
            {
                IsOk = false;
            }
           
        }
        private void Abort_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}