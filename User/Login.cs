using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Övrigt.PlaySounds;
using DigitalProductionProgram.PrintingServices;
using NAudio.Wave;

namespace DigitalProductionProgram.User
{
    public partial class Login : Form
    {

        private byte[] ProfilePicture;
        public Image Bild;
        public static Image RandomBackPic
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT TOP(1) Image FROM [Settings].Themes ORDER BY NEWID()";
                con.Open();
                var cmd = new SqlCommand(query, con);
                var value = cmd.ExecuteScalar();
                if (value is null)
                    return Properties.Resources.anonym;
                var img = (byte[])value;
                var ms = new MemoryStream(img);
                return Image.FromStream(ms);
            }
        }
        public bool SvarÖppnaOrder;
        public bool IsOkEdit_Mode
        {
            get
            {
                if (string.IsNullOrEmpty(lbl_User.Text))
                {
                    InfoText.Show("Välj användare före du försöker låsa upp adminrättigheter.", CustomColors.InfoText_Color.Warning, "Warning!", this);
                    return false;
                }
        
                if (PasswordManager.IsPasswordOK(tb_Password.Text) == false)
                {
                    InfoText.Show(LanguageManager.GetString("password_Info_1"), CustomColors.InfoText_Color.Bad, "Warning!", this);
                    tb_Password.SelectAll();
                    return false;
                }
                return true;
            }
        }
        public bool IsUserDataFilled =>
            !string.IsNullOrEmpty(tb_Förnamn.Text) && !string.IsNullOrEmpty(tb_Efternamn.Text) && !string.IsNullOrEmpty(cb_Role.Text) && 
            !string.IsNullOrEmpty(tb_AnstNr.Text) && !string.IsNullOrEmpty(tb_Sign.Text) && !string.IsNullOrEmpty(tb_NewPassword.Text) && !string.IsNullOrEmpty(tb_Mail.Text);
        private bool IsInEditMode;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
                
        public Login()
        {
            SuspendLayout();
            InitializeComponent();
            Translate_Form();
            
            LoadBackground();
            timer_UpdateTime.Start();
            Fill_ComboBoxes();
            
            HideObjects();
            ResumeLayout();
           
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));

            Load_flp_Users();
            tlp_AddUser.BackColor = Color.FromArgb(180, Color.Black);
           
            panel_Background.BackColor = Color.FromArgb(150, Color.Black);

            tb_NewPassword.PasswordChar = '*';
        }

        private void Fill_ComboBoxes()
        {
            cb_Role.DataSource = Person.List_Roles;
        }
         
        private void Translate_Form()
        {
            Control[] controls = {label_Welcome, label_AddUser, label_FirstName, label_ChooseUser,  label_Password, label_ConfirmPassword, lbl_NewUser, lbl_EditUser, lbl_Exit, 
                label_FirstName, label_LastName, label_Role,  label_EmpNr, label_Sign, label_NewPassword, btn_AddProfilePicture, btn_AddUpdateUser, label_InfoPassword_1, label_InfoPassword_2 };
            LanguageManager.TranslationHelper.TranslateControls(controls);

            ProfileCard.Translate_Form();
        }
        private void LoadBackground()
        {
            if (Environment.MachineName == "OH-ID61")
                return;
            panel_Background.BackgroundImage = RandomBackPic;
        }
        private void Load_User_Info()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                SELECT Name, roles.RoleName, Mail, EmployeeNumber, Signature, UserID 
                FROM [User].Person as person
                JOIN [User].Roles as roles
                    ON person.RoleID = roles.RoleID
                WHERE Name = @name";
                
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", lbl_User.Text);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var namn = reader["Name"].ToString().Split(' ');
                    
                    tb_Förnamn.Text = namn[0];
                    tb_Efternamn.Text = namn[1];
                    cb_Role.Text = reader["RoleName"].ToString();
                    tb_Mail.Text = reader["Mail"].ToString();
                    tb_AnstNr.Text = reader["EmployeeNumber"].ToString();
                    tb_Sign.Text = reader["Signature"].ToString();
                    Person.UserID = int.Parse(reader["UserID"].ToString());
                }
            }
        }
        private void Load_flp_Users()
        {
            var list_users = new List<string?>();
            flp_Users.BackColor = Color.FromArgb(100, Color.Black);
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT person.Name, Date
                    FROM Log.ActivityLog as log
                        JOIN [User].Person as person
                            ON log.UserID = person.UserID
                    WHERE HostID = (SELECT HostID FROM [Settings].General WHERE HostName = @hostname) AND Date > @date AND person.Name != '' ORDER BY Date DESC";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@hostname", Environment.MachineName);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.AddDays(-14));
                var reader = cmd.ExecuteReader();
                var ctr = 0;
                while (reader.Read())
                {
                    if (!list_users.Contains(reader[0].ToString()))
                    {
                        list_users.Add(reader[0].ToString());
                        ctr++;
                    }
                    if (ctr == 8)
                        break;
                }
            }
            foreach (var t in list_users)
            {
                var panel = new Panel
                {
                    Margin = new Padding(10, 0, 10, 0),
                    Width = 65,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BorderStyle = BorderStyle.FixedSingle
                };
                try
                {
                    panel.BackgroundImage = Person.ProfilePicture(t);
                }
                catch { }
                Person.Load_EmployeeNumber(t);
                var lbl = new Label
                {
                    Text = $"{Person.Get_SignWithName(t)} \n\n" +
                           $"{Person.EmployeeNr}",
                    ForeColor = Color.LightGray,
                    BackColor = Color.Transparent,
                    Font = new Font("Cambria", 14f),
                    Dock = DockStyle.Fill,
                    Cursor = Cursors.Hand,
                    TextAlign = ContentAlignment.MiddleCenter
                    
                };
                panel.Controls.Add(lbl);
                lbl.Click += click_User_Label;
                flp_Users.Controls.Add(panel);
            }
        }
        private void click_User_Label(object sender, EventArgs e)
        {
            Log.Activity.Start();
            
            var lbl = (Label)sender;
            var anstNr = Regex.Replace(lbl.Text, @"\t|\n|\r|\D", string.Empty);

            lbl_User.Text = Person.Get_NameWithAnstNr(anstNr);
            tb_Password.Focus();

            _ = Log.Activity.Stop($"Snabblogin - {lbl_User.Text}");
        }
        private void HideObjects()
        {
            ProfileCard.Visible = false;
            tlp_AddUser.Visible = false;
        }
        private void ShowVisitkort()
        {
            ProfileCard.Visible = true;
        }
        private void Initialize_GUI_Add_User()
        {
            btn_AddUpdateUser.Click += Add_User_Click;
            btn_AddUpdateUser.Text = LanguageManager.GetString("login_AddUser");
            tlp_AddUser.Visible = true;
            IsInEditMode = false;
        }
        private void Initialize_GUI_Edit_User()
        {
            btn_AddUpdateUser.Click += Update_User_Click;
            btn_AddUpdateUser.Text = LanguageManager.GetString("login_UpdateUser");
            Load_User_Info();
            tlp_AddUser.Visible = true;
            tb_Förnamn.Enabled = false;
            tb_Efternamn.Enabled = false;
            cb_Role.Enabled = false;
            tb_AnstNr.Enabled = false;
            tb_Sign.Enabled = false;
            tb_Mail.Enabled = false;
            IsInEditMode = true;
        }
        
        private void Clear_All()
        {
            tb_Förnamn.Clear();
            tb_Efternamn.Clear();
            cb_Role.SelectedIndex = -1;
            tb_AnstNr.Clear();
            tb_Sign.Clear();
            tb_NewPassword.Clear();
            tb_Förnamn.SelectAll();
            tb_Mail.Clear();
        }
        private async Task CheckVersion()
        {
            var lastVersion = Person.LastReadChangeLogVersion(lbl_User.Text);

            if (lastVersion == new Version("0.0.0.0"))
            {
                var changeLog = new ChangeLog(Version.Parse("1.0.0.0"));
                changeLog.ShowDialog();
                //await Person.UpdateLastReadChangelogVersion(lbl_User.Text);
                return; 
            }

            if (lastVersion != ChangeLog.CurrentVersion)
            {
                InfoText.Question(
                    $"{LanguageManager.GetString("login_Info_1_1")} {lastVersion} {LanguageManager.GetString("login_Info_1_2")} {ChangeLog.CurrentVersion}\n" +
                    $"{LanguageManager.GetString("login_Info_1_3")}", CustomColors.InfoText_Color.Info, LanguageManager.GetString("login_Info_1_4"), this);

                if (InfoText.answer == InfoText.Answer.Yes)
                {
                    var watch = new Stopwatch();
                    watch.Start();

                    var changeLog = new ChangeLog(lastVersion);
                    changeLog.ShowDialog();

                    watch.Stop();
                    var time = watch.Elapsed.TotalSeconds;

                    //await Activity.AddTimeUserRead(lastVersion.ToString(), time);
                }
            }
        }






        private void Info_Click(object sender, EventArgs e)
        {
            InfoText.Show(LanguageManager.GetString("login_Info_2"), CustomColors.InfoText_Color.Info, "Log in:");
        }
        private void Add_User_Click(object sender, EventArgs e)
        {
            var namn = tb_Förnamn.Text + " " + tb_Efternamn.Text;

            if (!IsUserDataFilled)
            {
                InfoText.Show(LanguageManager.GetString("login_Info_3"), CustomColors.InfoText_Color.Warning, "Warning!", this);
                return;
            }
            Person.Add(namn, tb_Sign.Text, tb_AnstNr.Text, tb_NewPassword.Text, cb_Role.Text, tb_Mail.Text, ProfilePicture);
            Clear_All();

            Fill_ComboBoxes();
        }
        private void Update_User_Click(object sender, EventArgs e)
        {
            if (!IsUserDataFilled)
            {
                InfoText.Show(LanguageManager.GetString("login_Info_4"), CustomColors.InfoText_Color.Warning, "Warning!", this);
                return;
            }
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "UPDATE [User].Person SET Mail = @mail, Password = @password WHERE UserID = @userID";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@mail", tb_Mail.Text);
                cmd.Parameters.AddWithValue("@password", PasswordManager.ConvertToHashedPassword(tb_NewPassword.Text));
                cmd.Parameters.AddWithValue("@userID", Person.UserID);
                con.Open();
                cmd.ExecuteScalar();     
            }
            InfoText.Show(LanguageManager.GetString("login_Info_5"), CustomColors.InfoText_Color.Ok, "Updated Profile");
            Clear_All();
            Close();
        }
        private void AddProfilePicture_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "All Files(*.*)|*.*",
                Title = LanguageManager.GetString("login_Info_6")
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var picLocation = dlg.FileName;

                var fs = new FileStream(picLocation, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                ProfilePicture = br.ReadBytes((int)fs.Length);
            }

            if (IsInEditMode)
                Person.Save_ProfilePicture(ProfilePicture, lbl_User.Text);
        }

        private void NyAnvändare_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsOkEdit_Mode)
            {
                if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.AddUser))
                {
                    lbl_User.Enabled = false;
                    Initialize_GUI_Add_User();

                    tb_Password.Clear();
                }
            }
        }
        private void RedigeraAnvändare_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsOkEdit_Mode)
            {
                lbl_User.Enabled = false;
                Initialize_GUI_Edit_User();
                tb_Password.Clear();
            }
            Person.Role = ProfileCard.lbl_Role.Text;
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Users_Click(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            var choose_Item = new Choose_Item(Person.List_Users(false),new[] { ctrl }, false);
            choose_Item.ShowDialog();
        }
        private void AnstNr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Sign_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
        private async void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                Log.Activity.Start();

                if (PasswordManager.IsPasswordOK(tb_Password.Text) == false ||string.IsNullOrEmpty(lbl_User.Text))
                {
                    Shake(this);
                    InfoText.Show(LanguageManager.GetString("password_Info_1"), CustomColors.InfoText_Color.Bad, "Warning!", this);
                    tb_Password.SelectAll();
                    _ = Log.Activity.Stop($"Fel lösenord! Loggar in: Användare.Name = {Person.Name} - cb_Användare.Text = {lbl_User.Text} Användare.Lösenord = {Person.Password} - tb_Lösenord.Text = {tb_Password.Text}");
                    return;
                }

                Person.EmployeeNr = ProfileCard.lbl_EmpNr.Text;
                Person.Sign = ProfileCard.lbl_Sign.Text;
                Person.Name = lbl_User.Text;
                Person.Role = ProfileCard.lbl_Role.Text;

                if (string.IsNullOrEmpty(ProfileCard.lbl_LastOrder.Text))
                    ProfileCard.chb_OpenLastOrder.Checked = false;

                if (ProfileCard.chb_OpenLastOrder.Checked && ProfileCard.lbl_LastOrder.Text != string.Empty)
                {
                    SvarÖppnaOrder = true;
                    Order.OrderNumber = ProfileCard.lbl_LastOrder.Text;
                }
                if (Person.Name == "Kenny Lindqvist")
                    Sounds.PlayGollum();
                await CheckVersion();
                _ = Log.Activity.Stop("Loggar in: " + lbl_User.Text);
                Close();
            }
        }
        private void Mail_Leave(object sender, EventArgs e)
        {
            if (Mail.IsValidEmail(tb_Mail.Text) == false)
            {
                InfoText.Show(LanguageManager.GetString("validEmail"), CustomColors.InfoText_Color.Bad, "Warning!", this);
                tb_Mail.Focus();
            }
        }

        private void Login_Ny_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Person.Password != PasswordManager.ConvertToHashedPassword(tb_Password.Text))
            {
                Person.Role = string.Empty;
                Person.EmployeeNr = string.Empty;
                
                Person.Name = string.Empty;
                ProfileCard.pb_Image.Image = Person.ProfilePicture(null);
                Person.Sign = null;
                SvarÖppnaOrder = false;
                Points.TotalPoints = 0;
            }
           
        }
       
      
        private void User_TextChanged(object sender, EventArgs e)
        {
            if (lbl_User.Text != string.Empty)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT UserID, Signature, EmployeeNumber, Password, Mail, roles.RoleName, Points 
                    FROM [User].Person as person
                    JOIN [User].Roles as roles
                        ON person.RoleID = roles.RoleID
                    WHERE Name = @name";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", lbl_User.Text);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Person.UserID = reader.GetInt32(0);
                        ProfileCard.lbl_Sign.Text = reader["Signature"].ToString();
                        Person.EmployeeNr = ProfileCard.lbl_EmpNr.Text = reader["EmployeeNumber"].ToString();
                        Person.Password = reader["Password"].ToString();
                        Person.Mail = reader["Mail"].ToString();
                        Points.TotalPoints = int.Parse(reader["Points"].ToString());
                        ProfileCard.lbl_Role.Text = Person.Role  = reader["RoleName"].ToString();
                    }
                }
                ProfileCard.pb_Image.Image = Person.ProfilePicture(lbl_User.Text);
                   
              
                ProfileCard.label_Name.Text = lbl_User.Text;
                lbl_NewUser.Cursor = Cursors.Hand;
                lbl_NewUser.Enabled = true;
                if (Program.IsComputerOnlyForMeasurements)
                    ProfileCard.GetLatestOrderForOperaton(Person.EmployeeNr);
                ShowVisitkort();
                tb_Password.Focus();
            }
        }
       
        private void Buttons_MouseEnter(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.ForeColor = Color.Azure;
            
        }
        private void Buttons_MouseLeave(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.ForeColor = Color.Aquamarine;
            
        }
        

       
        

        private void UpdateTime_Tick(object sender, EventArgs e)
        {
             lbl_Date.Text = DateTime.Now.ToString("dddd dd-MMMM-yyy HH:mm:ss");
        }


        private void Shake(Form form)
        {
            var original = form.Location;
            var rnd = new Random(1337);
            const int shake_amplitude = 10;
            for (var i = 0; i < 15; i++)
            {
                form.Location = new Point(original.X + rnd.Next(-shake_amplitude, shake_amplitude),
                    original.Y + rnd.Next(-shake_amplitude, shake_amplitude));
                Thread.Sleep(30);
            }
            form.Location = original;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            bool IsOk;
            if (tb_NewPassword.Text.Length > 3)
            {
                label_InfoPassword_1.Visible = false;
                IsOk = true;
            }
            else
            {
                label_InfoPassword_1.Visible = true;
                IsOk = false;
            }
                

            if (tb_NewPassword.Text == tb_ConfirmPassword.Text && tb_NewPassword.Text.Length > 3)
            {
                label_InfoPassword_2.Visible = false;
                IsOk = true;
            }
            else
            {
                label_InfoPassword_2.Visible = true;
                IsOk = false;
            }
                

            if (IsOk)
            {
                btn_AddUpdateUser.BackColor = CustomColors.Ok_Back;
                btn_AddUpdateUser.ForeColor = CustomColors.Ok_Front;
                btn_AddUpdateUser.Enabled = true;
                
                return;
            }
            btn_AddUpdateUser.BackColor = CustomColors.Bad_Back;
            btn_AddUpdateUser.ForeColor = CustomColors.Bad_Front;
            btn_AddUpdateUser.Enabled = false;
           
        }


        
        
        private void AnstNr_Leave(object sender, EventArgs e)
        {
            int.TryParse(tb_AnstNr.Text, out var employeeNumber);
            var person = Monitor.Monitor.User(employeeNumber);
            if (person != null)
            {
                tb_Förnamn.Text = person.FirstName;
                tb_Efternamn.Text = person.LastName;
                tb_Mail.Text = person.EmailAddress;
                tb_Sign.Text = person.Initials;
            }
        }
        private void Name_Leave(object sender, EventArgs e)
        {
            var person = Monitor.Monitor.User(tb_Förnamn.Text, tb_Efternamn.Text);
            if (person != null)
            {
                tb_AnstNr.Text = person.EmployeeNumber.ToString();
                tb_Mail.Text = person.EmailAddress;
                tb_Sign.Text = person.Initials;
            }
        }

    }
}