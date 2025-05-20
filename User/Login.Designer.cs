using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.User
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Login));
            label_Welcome = new Label();
            label_ChooseUser = new Label();
            tb_Password = new TextBox();
            label_Password = new Label();
            panel_Background = new Panel();
            ProfileCard = new ProfileCard();
            tlp_AddUser = new TableLayoutPanel();
            label_InfoPassword_1 = new Label();
            tb_ConfirmPassword = new TextBox();
            label_ConfirmPassword = new Label();
            label_Mail = new Label();
            btn_AddUpdateUser = new Button();
            tb_Sign = new TextBox();
            label_AddUser = new Label();
            cb_Role = new ComboBox();
            label_NewPassword = new Label();
            label_Sign = new Label();
            tb_AnstNr = new TextBox();
            label_EmpNr = new Label();
            label_FirstName = new Label();
            tb_Förnamn = new TextBox();
            label_LastName = new Label();
            tb_Efternamn = new TextBox();
            tb_Mail = new TextBox();
            label_Role = new Label();
            tb_NewPassword = new TextBox();
            btn_AddProfilePicture = new Button();
            label_InfoPassword_2 = new Label();
            flp_Users = new FlowLayoutPanel();
            panel_Bottom = new Panel();
            tlp_Bottom = new TableLayoutPanel();
            lbl_Exit = new Label();
            lbl_NewUser = new Label();
            lbl_EditUser = new Label();
            lbl_User = new Label();
            panel_Top = new Panel();
            pb_Info = new PictureBox();
            lbl_Date = new Label();
            lbl_Weather = new Label();
            lbl_Temp = new Label();
            toolTip1 = new ToolTip(components);
            timer_UpdateTime = new System.Windows.Forms.Timer(components);
            panel_Background.SuspendLayout();
            tlp_AddUser.SuspendLayout();
            panel_Bottom.SuspendLayout();
            tlp_Bottom.SuspendLayout();
            panel_Top.SuspendLayout();
            ((ISupportInitialize)pb_Info).BeginInit();
            SuspendLayout();
            // 
            // label_Welcome
            // 
            label_Welcome.BackColor = Color.FromArgb(150, 80, 80, 80);
            label_Welcome.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Welcome.ForeColor = Color.White;
            label_Welcome.Location = new Point(63, 9);
            label_Welcome.Margin = new Padding(4, 0, 4, 0);
            label_Welcome.Name = "label_Welcome";
            label_Welcome.Size = new Size(144, 33);
            label_Welcome.TabIndex = 1;
            label_Welcome.Text = "Välkommen";
            // 
            // label_ChooseUser
            // 
            label_ChooseUser.AutoSize = true;
            label_ChooseUser.BackColor = Color.Transparent;
            label_ChooseUser.Dock = DockStyle.Fill;
            label_ChooseUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ChooseUser.ForeColor = Color.White;
            label_ChooseUser.Location = new Point(4, 0);
            label_ChooseUser.Margin = new Padding(4, 0, 4, 0);
            label_ChooseUser.Name = "label_ChooseUser";
            label_ChooseUser.Size = new Size(198, 24);
            label_ChooseUser.TabIndex = 3;
            label_ChooseUser.Text = "Välj användare...";
            // 
            // tb_Password
            // 
            tb_Password.Dock = DockStyle.Fill;
            tb_Password.Location = new Point(7, 82);
            tb_Password.Margin = new Padding(7, 3, 4, 3);
            tb_Password.Name = "tb_Password";
            tb_Password.Size = new Size(195, 23);
            tb_Password.TabIndex = 4;
            tb_Password.UseSystemPasswordChar = true;
            tb_Password.KeyDown += Password_KeyDown;
            // 
            // label_Password
            // 
            label_Password.AutoSize = true;
            label_Password.BackColor = Color.Transparent;
            label_Password.Dock = DockStyle.Fill;
            label_Password.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Password.ForeColor = Color.White;
            label_Password.Location = new Point(4, 54);
            label_Password.Margin = new Padding(4, 0, 4, 0);
            label_Password.Name = "label_Password";
            label_Password.Size = new Size(198, 25);
            label_Password.TabIndex = 5;
            label_Password.Text = "Lösenord:";
            // 
            // panel_Background
            // 
            panel_Background.BackColor = Color.Transparent;
            panel_Background.BackgroundImageLayout = ImageLayout.Stretch;
            panel_Background.Controls.Add(ProfileCard);
            panel_Background.Controls.Add(tlp_AddUser);
            panel_Background.Controls.Add(flp_Users);
            panel_Background.Controls.Add(panel_Bottom);
            panel_Background.Controls.Add(label_Welcome);
            panel_Background.Controls.Add(panel_Top);
            panel_Background.Dock = DockStyle.Fill;
            panel_Background.Location = new Point(0, 0);
            panel_Background.Margin = new Padding(4, 3, 4, 3);
            panel_Background.Name = "panel_Background";
            panel_Background.Size = new Size(805, 826);
            panel_Background.TabIndex = 0;
            // 
            // ProfileCard
            // 
            ProfileCard.BackColor = Color.FromArgb(180, 0, 0, 0);
            ProfileCard.Location = new Point(14, 74);
            ProfileCard.Margin = new Padding(5, 3, 5, 3);
            ProfileCard.Name = "ProfileCard";
            ProfileCard.Size = new Size(404, 263);
            ProfileCard.TabIndex = 53;
            // 
            // tlp_AddUser
            // 
            tlp_AddUser.ColumnCount = 2;
            tlp_AddUser.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 142F));
            tlp_AddUser.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 237F));
            tlp_AddUser.Controls.Add(label_InfoPassword_1, 0, 10);
            tlp_AddUser.Controls.Add(tb_ConfirmPassword, 1, 8);
            tlp_AddUser.Controls.Add(label_ConfirmPassword, 0, 8);
            tlp_AddUser.Controls.Add(label_Mail, 0, 4);
            tlp_AddUser.Controls.Add(btn_AddUpdateUser, 1, 13);
            tlp_AddUser.Controls.Add(tb_Sign, 1, 6);
            tlp_AddUser.Controls.Add(label_AddUser, 0, 0);
            tlp_AddUser.Controls.Add(cb_Role, 1, 3);
            tlp_AddUser.Controls.Add(label_NewPassword, 0, 7);
            tlp_AddUser.Controls.Add(label_Sign, 0, 6);
            tlp_AddUser.Controls.Add(tb_AnstNr, 1, 5);
            tlp_AddUser.Controls.Add(label_EmpNr, 0, 5);
            tlp_AddUser.Controls.Add(label_FirstName, 0, 1);
            tlp_AddUser.Controls.Add(tb_Förnamn, 1, 1);
            tlp_AddUser.Controls.Add(label_LastName, 0, 2);
            tlp_AddUser.Controls.Add(tb_Efternamn, 1, 2);
            tlp_AddUser.Controls.Add(tb_Mail, 1, 4);
            tlp_AddUser.Controls.Add(label_Role, 0, 3);
            tlp_AddUser.Controls.Add(tb_NewPassword, 1, 7);
            tlp_AddUser.Controls.Add(btn_AddProfilePicture, 1, 12);
            tlp_AddUser.Controls.Add(label_InfoPassword_2, 0, 11);
            tlp_AddUser.Location = new Point(410, 74);
            tlp_AddUser.Margin = new Padding(0, 3, 0, 3);
            tlp_AddUser.Name = "tlp_AddUser";
            tlp_AddUser.RowCount = 15;
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 141F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlp_AddUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tlp_AddUser.Size = new Size(379, 523);
            tlp_AddUser.TabIndex = 52;
            tlp_AddUser.Visible = false;
            // 
            // label_InfoPassword_1
            // 
            label_InfoPassword_1.AutoSize = true;
            label_InfoPassword_1.BackColor = Color.FromArgb(255, 199, 206);
            tlp_AddUser.SetColumnSpan(label_InfoPassword_1, 2);
            label_InfoPassword_1.Dock = DockStyle.Fill;
            label_InfoPassword_1.Font = new Font("Lucida Sans", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_InfoPassword_1.ForeColor = Color.FromArgb(156, 0, 6);
            label_InfoPassword_1.Location = new Point(4, 269);
            label_InfoPassword_1.Margin = new Padding(4, 0, 0, 0);
            label_InfoPassword_1.Name = "label_InfoPassword_1";
            label_InfoPassword_1.Size = new Size(375, 25);
            label_InfoPassword_1.TabIndex = 66;
            label_InfoPassword_1.Text = "Lösenordet måste vara 4 tecken eller flera.\r\n";
            label_InfoPassword_1.Visible = false;
            // 
            // tb_ConfirmPassword
            // 
            tb_ConfirmPassword.BorderStyle = BorderStyle.None;
            tb_ConfirmPassword.Dock = DockStyle.Fill;
            tb_ConfirmPassword.Font = new Font("Courier New", 9.25F);
            tb_ConfirmPassword.Location = new Point(142, 210);
            tb_ConfirmPassword.Margin = new Padding(0);
            tb_ConfirmPassword.Multiline = true;
            tb_ConfirmPassword.Name = "tb_ConfirmPassword";
            tb_ConfirmPassword.PasswordChar = '*';
            tb_ConfirmPassword.Size = new Size(237, 31);
            tb_ConfirmPassword.TabIndex = 10;
            tb_ConfirmPassword.TextChanged += Password_TextChanged;
            // 
            // label_ConfirmPassword
            // 
            label_ConfirmPassword.AutoSize = true;
            label_ConfirmPassword.BackColor = Color.Transparent;
            label_ConfirmPassword.Dock = DockStyle.Fill;
            label_ConfirmPassword.ForeColor = SystemColors.Info;
            label_ConfirmPassword.Location = new Point(4, 210);
            label_ConfirmPassword.Margin = new Padding(4, 0, 4, 0);
            label_ConfirmPassword.Name = "label_ConfirmPassword";
            label_ConfirmPassword.Size = new Size(134, 31);
            label_ConfirmPassword.TabIndex = 64;
            label_ConfirmPassword.Text = "Bekräfta Lösenord:";
            label_ConfirmPassword.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Mail
            // 
            label_Mail.AutoSize = true;
            label_Mail.BackColor = Color.Transparent;
            label_Mail.Dock = DockStyle.Fill;
            label_Mail.ForeColor = SystemColors.Info;
            label_Mail.Location = new Point(4, 110);
            label_Mail.Margin = new Padding(4, 0, 4, 0);
            label_Mail.Name = "label_Mail";
            label_Mail.Size = new Size(134, 25);
            label_Mail.TabIndex = 60;
            label_Mail.Text = "eMail:";
            label_Mail.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn_AddUpdateUser
            // 
            btn_AddUpdateUser.BackColor = Color.FromArgb(198, 239, 206);
            btn_AddUpdateUser.Cursor = Cursors.Hand;
            btn_AddUpdateUser.Dock = DockStyle.Fill;
            btn_AddUpdateUser.Enabled = false;
            btn_AddUpdateUser.FlatStyle = FlatStyle.Flat;
            btn_AddUpdateUser.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btn_AddUpdateUser.ForeColor = Color.FromArgb(0, 97, 0);
            btn_AddUpdateUser.Location = new Point(142, 460);
            btn_AddUpdateUser.Margin = new Padding(0);
            btn_AddUpdateUser.Name = "btn_AddUpdateUser";
            btn_AddUpdateUser.Size = new Size(237, 34);
            btn_AddUpdateUser.TabIndex = 50;
            btn_AddUpdateUser.Text = "Lägg till Användare";
            btn_AddUpdateUser.UseVisualStyleBackColor = false;
            // 
            // tb_Sign
            // 
            tb_Sign.BorderStyle = BorderStyle.None;
            tb_Sign.Dock = DockStyle.Fill;
            tb_Sign.Location = new Point(142, 160);
            tb_Sign.Margin = new Padding(0, 0, 0, 1);
            tb_Sign.Multiline = true;
            tb_Sign.Name = "tb_Sign";
            tb_Sign.Size = new Size(237, 24);
            tb_Sign.TabIndex = 8;
            tb_Sign.KeyPress += Sign_KeyPress;
            // 
            // label_AddUser
            // 
            label_AddUser.BackColor = Color.Transparent;
            tlp_AddUser.SetColumnSpan(label_AddUser, 2);
            label_AddUser.Dock = DockStyle.Fill;
            label_AddUser.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_AddUser.ForeColor = Color.Firebrick;
            label_AddUser.Location = new Point(0, 0);
            label_AddUser.Margin = new Padding(0);
            label_AddUser.Name = "label_AddUser";
            label_AddUser.Size = new Size(379, 35);
            label_AddUser.TabIndex = 56;
            label_AddUser.Text = "Lägg till användare:";
            label_AddUser.TextAlign = ContentAlignment.TopCenter;
            // 
            // cb_Role
            // 
            cb_Role.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_Role.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_Role.BackColor = SystemColors.Menu;
            cb_Role.Dock = DockStyle.Fill;
            cb_Role.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Role.FormattingEnabled = true;
            cb_Role.Location = new Point(142, 85);
            cb_Role.Margin = new Padding(0);
            cb_Role.Name = "cb_Role";
            cb_Role.Size = new Size(237, 23);
            cb_Role.TabIndex = 5;
            // 
            // label_NewPassword
            // 
            label_NewPassword.AutoSize = true;
            label_NewPassword.BackColor = Color.Transparent;
            label_NewPassword.Dock = DockStyle.Fill;
            label_NewPassword.ForeColor = SystemColors.Info;
            label_NewPassword.Location = new Point(4, 185);
            label_NewPassword.Margin = new Padding(4, 0, 4, 0);
            label_NewPassword.Name = "label_NewPassword";
            label_NewPassword.Size = new Size(134, 25);
            label_NewPassword.TabIndex = 48;
            label_NewPassword.Text = "Lösenord:";
            label_NewPassword.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Sign
            // 
            label_Sign.AutoSize = true;
            label_Sign.BackColor = Color.Transparent;
            label_Sign.Dock = DockStyle.Fill;
            label_Sign.ForeColor = SystemColors.Info;
            label_Sign.Location = new Point(4, 160);
            label_Sign.Margin = new Padding(4, 0, 4, 0);
            label_Sign.Name = "label_Sign";
            label_Sign.Size = new Size(134, 25);
            label_Sign.TabIndex = 54;
            label_Sign.Text = "Signatur:";
            label_Sign.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_AnstNr
            // 
            tb_AnstNr.BorderStyle = BorderStyle.None;
            tb_AnstNr.Dock = DockStyle.Fill;
            tb_AnstNr.Location = new Point(142, 135);
            tb_AnstNr.Margin = new Padding(0, 0, 0, 1);
            tb_AnstNr.Multiline = true;
            tb_AnstNr.Name = "tb_AnstNr";
            tb_AnstNr.Size = new Size(237, 24);
            tb_AnstNr.TabIndex = 7;
            tb_AnstNr.KeyPress += AnstNr_KeyPress;
            tb_AnstNr.Leave += AnstNr_Leave;
            // 
            // label_EmpNr
            // 
            label_EmpNr.AutoSize = true;
            label_EmpNr.BackColor = Color.Transparent;
            label_EmpNr.Dock = DockStyle.Fill;
            label_EmpNr.ForeColor = SystemColors.Info;
            label_EmpNr.Location = new Point(4, 135);
            label_EmpNr.Margin = new Padding(4, 0, 4, 0);
            label_EmpNr.Name = "label_EmpNr";
            label_EmpNr.Size = new Size(134, 25);
            label_EmpNr.TabIndex = 41;
            label_EmpNr.Text = "AnstNr:";
            label_EmpNr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_FirstName
            // 
            label_FirstName.AutoSize = true;
            label_FirstName.BackColor = Color.Transparent;
            label_FirstName.Dock = DockStyle.Fill;
            label_FirstName.ForeColor = SystemColors.Info;
            label_FirstName.Location = new Point(4, 35);
            label_FirstName.Margin = new Padding(4, 0, 4, 0);
            label_FirstName.Name = "label_FirstName";
            label_FirstName.Size = new Size(134, 25);
            label_FirstName.TabIndex = 40;
            label_FirstName.Text = "Förnamn:";
            label_FirstName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_Förnamn
            // 
            tb_Förnamn.BorderStyle = BorderStyle.None;
            tb_Förnamn.CharacterCasing = CharacterCasing.Upper;
            tb_Förnamn.Dock = DockStyle.Fill;
            tb_Förnamn.Location = new Point(142, 35);
            tb_Förnamn.Margin = new Padding(0, 0, 0, 1);
            tb_Förnamn.Multiline = true;
            tb_Förnamn.Name = "tb_Förnamn";
            tb_Förnamn.Size = new Size(237, 24);
            tb_Förnamn.TabIndex = 1;
            tb_Förnamn.Leave += Name_Leave;
            // 
            // label_LastName
            // 
            label_LastName.AutoSize = true;
            label_LastName.BackColor = Color.Transparent;
            label_LastName.Dock = DockStyle.Fill;
            label_LastName.ForeColor = SystemColors.Info;
            label_LastName.Location = new Point(4, 60);
            label_LastName.Margin = new Padding(4, 0, 4, 0);
            label_LastName.Name = "label_LastName";
            label_LastName.Size = new Size(134, 25);
            label_LastName.TabIndex = 44;
            label_LastName.Text = "Efternamn:";
            label_LastName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_Efternamn
            // 
            tb_Efternamn.BorderStyle = BorderStyle.None;
            tb_Efternamn.CharacterCasing = CharacterCasing.Upper;
            tb_Efternamn.Dock = DockStyle.Fill;
            tb_Efternamn.Location = new Point(142, 60);
            tb_Efternamn.Margin = new Padding(0, 0, 0, 1);
            tb_Efternamn.Multiline = true;
            tb_Efternamn.Name = "tb_Efternamn";
            tb_Efternamn.Size = new Size(237, 24);
            tb_Efternamn.TabIndex = 2;
            tb_Efternamn.Leave += Name_Leave;
            // 
            // tb_Mail
            // 
            tb_Mail.BorderStyle = BorderStyle.None;
            tb_Mail.Dock = DockStyle.Fill;
            tb_Mail.Location = new Point(142, 110);
            tb_Mail.Margin = new Padding(0, 0, 0, 1);
            tb_Mail.Multiline = true;
            tb_Mail.Name = "tb_Mail";
            tb_Mail.Size = new Size(237, 24);
            tb_Mail.TabIndex = 6;
            tb_Mail.Leave += Mail_Leave;
            // 
            // label_Role
            // 
            label_Role.AutoSize = true;
            label_Role.BackColor = Color.Transparent;
            label_Role.Dock = DockStyle.Fill;
            label_Role.ForeColor = SystemColors.Info;
            label_Role.Location = new Point(4, 85);
            label_Role.Margin = new Padding(4, 0, 4, 0);
            label_Role.Name = "label_Role";
            label_Role.Size = new Size(134, 25);
            label_Role.TabIndex = 60;
            label_Role.Text = "Befattning:";
            label_Role.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_NewPassword
            // 
            tb_NewPassword.BorderStyle = BorderStyle.None;
            tb_NewPassword.Dock = DockStyle.Fill;
            tb_NewPassword.Font = new Font("Courier New", 9.25F);
            tb_NewPassword.Location = new Point(142, 185);
            tb_NewPassword.Margin = new Padding(0, 0, 0, 1);
            tb_NewPassword.Multiline = true;
            tb_NewPassword.Name = "tb_NewPassword";
            tb_NewPassword.PasswordChar = '*';
            tb_NewPassword.Size = new Size(237, 24);
            tb_NewPassword.TabIndex = 9;
            tb_NewPassword.TextChanged += Password_TextChanged;
            // 
            // btn_AddProfilePicture
            // 
            btn_AddProfilePicture.BackColor = Color.FromArgb(198, 239, 206);
            btn_AddProfilePicture.Dock = DockStyle.Top;
            btn_AddProfilePicture.FlatStyle = FlatStyle.Flat;
            btn_AddProfilePicture.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btn_AddProfilePicture.ForeColor = Color.FromArgb(0, 97, 0);
            btn_AddProfilePicture.Location = new Point(146, 322);
            btn_AddProfilePicture.Margin = new Padding(4, 3, 4, 3);
            btn_AddProfilePicture.Name = "btn_AddProfilePicture";
            btn_AddProfilePicture.Size = new Size(229, 31);
            btn_AddProfilePicture.TabIndex = 63;
            btn_AddProfilePicture.Text = "Ladda upp profilbild";
            btn_AddProfilePicture.UseVisualStyleBackColor = false;
            btn_AddProfilePicture.Click += AddProfilePicture_Click;
            // 
            // label_InfoPassword_2
            // 
            label_InfoPassword_2.AutoSize = true;
            label_InfoPassword_2.BackColor = Color.FromArgb(255, 199, 206);
            tlp_AddUser.SetColumnSpan(label_InfoPassword_2, 2);
            label_InfoPassword_2.Dock = DockStyle.Fill;
            label_InfoPassword_2.Font = new Font("Lucida Sans", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_InfoPassword_2.ForeColor = Color.FromArgb(156, 0, 6);
            label_InfoPassword_2.Location = new Point(4, 294);
            label_InfoPassword_2.Margin = new Padding(4, 0, 0, 0);
            label_InfoPassword_2.Name = "label_InfoPassword_2";
            label_InfoPassword_2.Size = new Size(375, 25);
            label_InfoPassword_2.TabIndex = 66;
            label_InfoPassword_2.Text = "Lösenorden matchar inte varandra.";
            label_InfoPassword_2.Visible = false;
            // 
            // flp_Users
            // 
            flp_Users.BackColor = Color.Transparent;
            flp_Users.Dock = DockStyle.Bottom;
            flp_Users.Location = new Point(0, 603);
            flp_Users.Margin = new Padding(4, 3, 4, 3);
            flp_Users.Name = "flp_Users";
            flp_Users.Size = new Size(805, 104);
            flp_Users.TabIndex = 51;
            // 
            // panel_Bottom
            // 
            panel_Bottom.BackColor = Color.FromArgb(150, 80, 80, 80);
            panel_Bottom.Controls.Add(tlp_Bottom);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 707);
            panel_Bottom.Margin = new Padding(4, 3, 4, 3);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(805, 119);
            panel_Bottom.TabIndex = 47;
            // 
            // tlp_Bottom
            // 
            tlp_Bottom.ColumnCount = 3;
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 206F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 382F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Bottom.Controls.Add(label_ChooseUser, 0, 0);
            tlp_Bottom.Controls.Add(lbl_Exit, 2, 3);
            tlp_Bottom.Controls.Add(tb_Password, 0, 3);
            tlp_Bottom.Controls.Add(lbl_NewUser, 2, 1);
            tlp_Bottom.Controls.Add(lbl_EditUser, 2, 0);
            tlp_Bottom.Controls.Add(label_Password, 0, 2);
            tlp_Bottom.Controls.Add(lbl_User, 0, 1);
            tlp_Bottom.Dock = DockStyle.Fill;
            tlp_Bottom.Location = new Point(0, 0);
            tlp_Bottom.Margin = new Padding(4, 3, 4, 3);
            tlp_Bottom.Name = "tlp_Bottom";
            tlp_Bottom.RowCount = 4;
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlp_Bottom.Size = new Size(805, 119);
            tlp_Bottom.TabIndex = 49;
            // 
            // lbl_Exit
            // 
            lbl_Exit.AutoSize = true;
            lbl_Exit.BackColor = Color.Transparent;
            lbl_Exit.Cursor = Cursors.Hand;
            lbl_Exit.Dock = DockStyle.Left;
            lbl_Exit.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_Exit.ForeColor = Color.Aquamarine;
            lbl_Exit.Location = new Point(592, 79);
            lbl_Exit.Margin = new Padding(4, 0, 4, 0);
            lbl_Exit.Name = "lbl_Exit";
            lbl_Exit.Size = new Size(69, 40);
            lbl_Exit.TabIndex = 48;
            lbl_Exit.Text = "Avsluta";
            lbl_Exit.Click += Exit_Click;
            lbl_Exit.MouseLeave += Buttons_MouseLeave;
            lbl_Exit.MouseHover += Buttons_MouseEnter;
            // 
            // lbl_NewUser
            // 
            lbl_NewUser.AutoSize = true;
            lbl_NewUser.BackColor = Color.Transparent;
            lbl_NewUser.Cursor = Cursors.Hand;
            lbl_NewUser.Dock = DockStyle.Left;
            lbl_NewUser.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_NewUser.ForeColor = Color.Aquamarine;
            lbl_NewUser.Location = new Point(592, 24);
            lbl_NewUser.Margin = new Padding(4, 0, 4, 0);
            lbl_NewUser.Name = "lbl_NewUser";
            tlp_Bottom.SetRowSpan(lbl_NewUser, 2);
            lbl_NewUser.Size = new Size(125, 55);
            lbl_NewUser.TabIndex = 48;
            lbl_NewUser.Text = "Ny Användare";
            lbl_NewUser.TextAlign = ContentAlignment.MiddleLeft;
            lbl_NewUser.MouseDown += NyAnvändare_MouseDown;
            lbl_NewUser.MouseLeave += Buttons_MouseLeave;
            lbl_NewUser.MouseHover += Buttons_MouseEnter;
            // 
            // lbl_EditUser
            // 
            lbl_EditUser.AutoSize = true;
            lbl_EditUser.BackColor = Color.Transparent;
            lbl_EditUser.Cursor = Cursors.Hand;
            lbl_EditUser.Dock = DockStyle.Left;
            lbl_EditUser.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_EditUser.ForeColor = Color.Aquamarine;
            lbl_EditUser.Location = new Point(592, 0);
            lbl_EditUser.Margin = new Padding(4, 0, 4, 0);
            lbl_EditUser.Name = "lbl_EditUser";
            lbl_EditUser.Size = new Size(173, 24);
            lbl_EditUser.TabIndex = 48;
            lbl_EditUser.Text = "Redigera Användare";
            lbl_EditUser.MouseDown += RedigeraAnvändare_MouseDown;
            lbl_EditUser.MouseLeave += Buttons_MouseLeave;
            lbl_EditUser.MouseHover += Buttons_MouseEnter;
            // 
            // lbl_User
            // 
            lbl_User.AutoSize = true;
            lbl_User.BackColor = Color.White;
            lbl_User.Cursor = Cursors.Hand;
            lbl_User.Dock = DockStyle.Fill;
            lbl_User.Location = new Point(7, 26);
            lbl_User.Margin = new Padding(7, 2, 4, 6);
            lbl_User.Name = "lbl_User";
            lbl_User.Padding = new Padding(0, 0, 0, 5);
            lbl_User.Size = new Size(195, 22);
            lbl_User.TabIndex = 52;
            lbl_User.TextChanged += User_TextChanged;
            lbl_User.Click += Users_Click;
            // 
            // panel_Top
            // 
            panel_Top.BackColor = Color.FromArgb(150, 80, 80, 80);
            panel_Top.Controls.Add(pb_Info);
            panel_Top.Controls.Add(lbl_Date);
            panel_Top.Controls.Add(lbl_Weather);
            panel_Top.Controls.Add(lbl_Temp);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Margin = new Padding(4, 3, 4, 3);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(805, 54);
            panel_Top.TabIndex = 46;
            // 
            // pb_Info
            // 
            pb_Info.BackColor = Color.Transparent;
            pb_Info.BackgroundImage = (Image)resources.GetObject("pb_Info.BackgroundImage");
            pb_Info.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info.Cursor = Cursors.Hand;
            pb_Info.Location = new Point(5, 5);
            pb_Info.Margin = new Padding(4, 3, 4, 3);
            pb_Info.Name = "pb_Info";
            pb_Info.Size = new Size(41, 39);
            pb_Info.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Info.TabIndex = 870;
            pb_Info.TabStop = false;
            pb_Info.Click += Info_Click;
            // 
            // lbl_Date
            // 
            lbl_Date.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_Date.AutoSize = true;
            lbl_Date.BackColor = Color.FromArgb(150, 80, 80, 80);
            lbl_Date.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Date.ForeColor = Color.Maroon;
            lbl_Date.Location = new Point(472, 13);
            lbl_Date.Margin = new Padding(4, 0, 4, 0);
            lbl_Date.Name = "lbl_Date";
            lbl_Date.Size = new Size(57, 21);
            lbl_Date.TabIndex = 6;
            lbl_Date.Text = "Datum";
            // 
            // lbl_Weather
            // 
            lbl_Weather.AutoSize = true;
            lbl_Weather.BackColor = Color.FromArgb(150, 80, 80, 80);
            lbl_Weather.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Weather.ForeColor = Color.Gold;
            lbl_Weather.Location = new Point(279, 13);
            lbl_Weather.Margin = new Padding(4, 0, 4, 0);
            lbl_Weather.Name = "lbl_Weather";
            lbl_Weather.Size = new Size(119, 21);
            lbl_Weather.TabIndex = 10;
            lbl_Weather.Text = "Moustly Cloudy";
            lbl_Weather.Visible = false;
            // 
            // lbl_Temp
            // 
            lbl_Temp.AutoSize = true;
            lbl_Temp.BackColor = Color.FromArgb(150, 80, 80, 80);
            lbl_Temp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Temp.ForeColor = Color.Gold;
            lbl_Temp.Location = new Point(425, 13);
            lbl_Temp.Margin = new Padding(4, 0, 4, 0);
            lbl_Temp.Name = "lbl_Temp";
            lbl_Temp.Size = new Size(35, 21);
            lbl_Temp.TabIndex = 10;
            lbl_Temp.Text = "9°C";
            lbl_Temp.Visible = false;
            // 
            // timer_UpdateTime
            // 
            timer_UpdateTime.Enabled = true;
            timer_UpdateTime.Interval = 1000;
            timer_UpdateTime.Tick += UpdateTime_Tick;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(1, 1, 1);
            ClientSize = new Size(805, 826);
            Controls.Add(panel_Background);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            TransparencyKey = Color.FromArgb(1, 1, 1);
            FormClosing += Login_Ny_FormClosing;
            panel_Background.ResumeLayout(false);
            tlp_AddUser.ResumeLayout(false);
            tlp_AddUser.PerformLayout();
            panel_Bottom.ResumeLayout(false);
            tlp_Bottom.ResumeLayout(false);
            tlp_Bottom.PerformLayout();
            panel_Top.ResumeLayout(false);
            panel_Top.PerformLayout();
            ((ISupportInitialize)pb_Info).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Panel panel_Background;
        private Label label_Welcome;
        private Label label_ChooseUser;
        private TextBox tb_Password;
        private Label label_Password;
        private Label label_AddUser;
        private TextBox tb_Sign;
        private Label label_Sign;
        private Label label_FirstName;
        private Label label_EmpNr;
        private TextBox tb_Förnamn;
        private Label label_LastName;
        private Button btn_AddUpdateUser;
        private TextBox tb_Efternamn;
        private TextBox tb_AnstNr;
        private Label label_NewPassword;
        private ToolTip toolTip1;
        private Label label_Role;
        private Label lbl_Weather;
        private Label lbl_Date;
        private Label lbl_Temp;
        private Panel panel_Top;
        private Panel panel_Bottom;
        private Label lbl_NewUser;
        private Label lbl_Exit;
        private Label label_Mail;
        private TextBox tb_Mail;
        private Label lbl_EditUser;
        private PictureBox pb_Info;
        private TableLayoutPanel tlp_Bottom;
        private FlowLayoutPanel flp_Users;
        private ComboBox cb_Role;
        private TableLayoutPanel tlp_AddUser;
        private System.Windows.Forms.Timer timer_UpdateTime;
        private Label lbl_User;
        private TextBox tb_NewPassword;
        private Button btn_AddProfilePicture;
        private ProfileCard ProfileCard;
        private TextBox tb_ConfirmPassword;
        private Label label_ConfirmPassword;
        private Label label_InfoPassword_1;
        private Label label_InfoPassword_2;
    }
}