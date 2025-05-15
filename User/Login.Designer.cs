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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label_Welcome = new System.Windows.Forms.Label();
            this.label_ChooseUser = new System.Windows.Forms.Label();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.panel_Background = new System.Windows.Forms.Panel();
            this.tlp_AddUser = new System.Windows.Forms.TableLayoutPanel();
            this.label_InfoPassword_1 = new System.Windows.Forms.Label();
            this.tb_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.label_ConfirmPassword = new System.Windows.Forms.Label();
            this.label_Mail = new System.Windows.Forms.Label();
            this.btn_AddUpdateUser = new System.Windows.Forms.Button();
            this.tb_Sign = new System.Windows.Forms.TextBox();
            this.label_AddUser = new System.Windows.Forms.Label();
            this.cb_Role = new System.Windows.Forms.ComboBox();
            this.label_NewPassword = new System.Windows.Forms.Label();
            this.label_Sign = new System.Windows.Forms.Label();
            this.tb_AnstNr = new System.Windows.Forms.TextBox();
            this.label_EmpNr = new System.Windows.Forms.Label();
            this.label_FirstName = new System.Windows.Forms.Label();
            this.tb_Förnamn = new System.Windows.Forms.TextBox();
            this.label_LastName = new System.Windows.Forms.Label();
            this.tb_Efternamn = new System.Windows.Forms.TextBox();
            this.tb_Mail = new System.Windows.Forms.TextBox();
            this.label_Role = new System.Windows.Forms.Label();
            this.tb_NewPassword = new System.Windows.Forms.TextBox();
            this.btn_AddProfilePicture = new System.Windows.Forms.Button();
            this.label_InfoPassword_2 = new System.Windows.Forms.Label();
            this.flp_Users = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.tlp_Bottom = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Exit = new System.Windows.Forms.Label();
            this.lbl_NewUser = new System.Windows.Forms.Label();
            this.lbl_EditUser = new System.Windows.Forms.Label();
            this.lbl_User = new System.Windows.Forms.Label();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.pb_Info = new System.Windows.Forms.PictureBox();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.lbl_Weather = new System.Windows.Forms.Label();
            this.lbl_Temp = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer_UpdateTime = new System.Windows.Forms.Timer(this.components);
            this.ProfileCard = new DigitalProductionProgram.User.ProfileCard();
            this.panel_Background.SuspendLayout();
            this.tlp_AddUser.SuspendLayout();
            this.panel_Bottom.SuspendLayout();
            this.tlp_Bottom.SuspendLayout();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Welcome
            // 
            this.label_Welcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label_Welcome.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Welcome.ForeColor = System.Drawing.Color.White;
            this.label_Welcome.Location = new System.Drawing.Point(54, 8);
            this.label_Welcome.Name = "label_Welcome";
            this.label_Welcome.Size = new System.Drawing.Size(123, 29);
            this.label_Welcome.TabIndex = 1;
            this.label_Welcome.Text = "Välkommen";
            // 
            // label_ChooseUser
            // 
            this.label_ChooseUser.AutoSize = true;
            this.label_ChooseUser.BackColor = System.Drawing.Color.Transparent;
            this.label_ChooseUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ChooseUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ChooseUser.ForeColor = System.Drawing.Color.White;
            this.label_ChooseUser.Location = new System.Drawing.Point(3, 0);
            this.label_ChooseUser.Name = "label_ChooseUser";
            this.label_ChooseUser.Size = new System.Drawing.Size(171, 21);
            this.label_ChooseUser.TabIndex = 3;
            this.label_ChooseUser.Text = "Välj användare...";
            // 
            // tb_Password
            // 
            this.tb_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Password.Location = new System.Drawing.Point(6, 72);
            this.tb_Password.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(168, 20);
            this.tb_Password.TabIndex = 4;
            this.tb_Password.UseSystemPasswordChar = true;
            this.tb_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.BackColor = System.Drawing.Color.Transparent;
            this.label_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Password.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Password.ForeColor = System.Drawing.Color.White;
            this.label_Password.Location = new System.Drawing.Point(3, 47);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(171, 22);
            this.label_Password.TabIndex = 5;
            this.label_Password.Text = "Lösenord:";
            // 
            // panel_Background
            // 
            this.panel_Background.BackColor = System.Drawing.Color.Transparent;
            this.panel_Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Background.Controls.Add(this.ProfileCard);
            this.panel_Background.Controls.Add(this.tlp_AddUser);
            this.panel_Background.Controls.Add(this.flp_Users);
            this.panel_Background.Controls.Add(this.panel_Bottom);
            this.panel_Background.Controls.Add(this.label_Welcome);
            this.panel_Background.Controls.Add(this.panel_Top);
            this.panel_Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Background.Location = new System.Drawing.Point(0, 0);
            this.panel_Background.Name = "panel_Background";
            this.panel_Background.Size = new System.Drawing.Size(690, 673);
            this.panel_Background.TabIndex = 0;
            // 
            // tlp_AddUser
            // 
            this.tlp_AddUser.ColumnCount = 2;
            this.tlp_AddUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tlp_AddUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.tlp_AddUser.Controls.Add(this.label_InfoPassword_1, 0, 9);
            this.tlp_AddUser.Controls.Add(this.tb_ConfirmPassword, 1, 8);
            this.tlp_AddUser.Controls.Add(this.label_ConfirmPassword, 0, 8);
            this.tlp_AddUser.Controls.Add(this.label_Mail, 0, 4);
            this.tlp_AddUser.Controls.Add(this.btn_AddUpdateUser, 1, 12);
            this.tlp_AddUser.Controls.Add(this.tb_Sign, 1, 6);
            this.tlp_AddUser.Controls.Add(this.label_AddUser, 0, 0);
            this.tlp_AddUser.Controls.Add(this.cb_Role, 1, 3);
            this.tlp_AddUser.Controls.Add(this.label_NewPassword, 0, 7);
            this.tlp_AddUser.Controls.Add(this.label_Sign, 0, 6);
            this.tlp_AddUser.Controls.Add(this.tb_AnstNr, 1, 5);
            this.tlp_AddUser.Controls.Add(this.label_EmpNr, 0, 5);
            this.tlp_AddUser.Controls.Add(this.label_FirstName, 0, 1);
            this.tlp_AddUser.Controls.Add(this.tb_Förnamn, 1, 1);
            this.tlp_AddUser.Controls.Add(this.label_LastName, 0, 2);
            this.tlp_AddUser.Controls.Add(this.tb_Efternamn, 1, 2);
            this.tlp_AddUser.Controls.Add(this.tb_Mail, 1, 4);
            this.tlp_AddUser.Controls.Add(this.label_Role, 0, 3);
            this.tlp_AddUser.Controls.Add(this.tb_NewPassword, 1, 7);
            this.tlp_AddUser.Controls.Add(this.btn_AddProfilePicture, 1, 11);
            this.tlp_AddUser.Controls.Add(this.label_InfoPassword_2, 0, 10);
            this.tlp_AddUser.Location = new System.Drawing.Point(351, 64);
            this.tlp_AddUser.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tlp_AddUser.Name = "tlp_AddUser";
            this.tlp_AddUser.RowCount = 14;
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlp_AddUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlp_AddUser.Size = new System.Drawing.Size(325, 410);
            this.tlp_AddUser.TabIndex = 52;
            this.tlp_AddUser.Visible = false;
            // 
            // label_InfoPassword_1
            // 
            this.label_InfoPassword_1.AutoSize = true;
            this.label_InfoPassword_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.tlp_AddUser.SetColumnSpan(this.label_InfoPassword_1, 2);
            this.label_InfoPassword_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_InfoPassword_1.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_InfoPassword_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.label_InfoPassword_1.Location = new System.Drawing.Point(3, 216);
            this.label_InfoPassword_1.Margin = new System.Windows.Forms.Padding(3, 10, 0, 0);
            this.label_InfoPassword_1.Name = "label_InfoPassword_1";
            this.label_InfoPassword_1.Size = new System.Drawing.Size(322, 21);
            this.label_InfoPassword_1.TabIndex = 66;
            this.label_InfoPassword_1.Text = "Lösenordet måste vara 4 tecken eller flera.\r\n";
            this.label_InfoPassword_1.Visible = false;
            // 
            // tb_ConfirmPassword
            // 
            this.tb_ConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ConfirmPassword.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.tb_ConfirmPassword.Location = new System.Drawing.Point(122, 184);
            this.tb_ConfirmPassword.Margin = new System.Windows.Forms.Padding(0);
            this.tb_ConfirmPassword.Multiline = true;
            this.tb_ConfirmPassword.Name = "tb_ConfirmPassword";
            this.tb_ConfirmPassword.PasswordChar = '*';
            this.tb_ConfirmPassword.Size = new System.Drawing.Size(203, 22);
            this.tb_ConfirmPassword.TabIndex = 65;
            this.tb_ConfirmPassword.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // label_ConfirmPassword
            // 
            this.label_ConfirmPassword.AutoSize = true;
            this.label_ConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.label_ConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ConfirmPassword.ForeColor = System.Drawing.SystemColors.Info;
            this.label_ConfirmPassword.Location = new System.Drawing.Point(3, 184);
            this.label_ConfirmPassword.Name = "label_ConfirmPassword";
            this.label_ConfirmPassword.Size = new System.Drawing.Size(116, 22);
            this.label_ConfirmPassword.TabIndex = 64;
            this.label_ConfirmPassword.Text = "Bekräfta Lösenord:";
            this.label_ConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Mail
            // 
            this.label_Mail.AutoSize = true;
            this.label_Mail.BackColor = System.Drawing.Color.Transparent;
            this.label_Mail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Mail.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Mail.Location = new System.Drawing.Point(3, 96);
            this.label_Mail.Name = "label_Mail";
            this.label_Mail.Size = new System.Drawing.Size(116, 22);
            this.label_Mail.TabIndex = 60;
            this.label_Mail.Text = "eMail:";
            this.label_Mail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_AddUpdateUser
            // 
            this.btn_AddUpdateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_AddUpdateUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddUpdateUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_AddUpdateUser.Enabled = false;
            this.btn_AddUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddUpdateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_AddUpdateUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_AddUpdateUser.Location = new System.Drawing.Point(122, 348);
            this.btn_AddUpdateUser.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddUpdateUser.Name = "btn_AddUpdateUser";
            this.btn_AddUpdateUser.Size = new System.Drawing.Size(203, 29);
            this.btn_AddUpdateUser.TabIndex = 50;
            this.btn_AddUpdateUser.Text = "Lägg till Användare";
            this.btn_AddUpdateUser.UseVisualStyleBackColor = false;
            // 
            // tb_Sign
            // 
            this.tb_Sign.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Sign.Location = new System.Drawing.Point(122, 140);
            this.tb_Sign.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tb_Sign.Multiline = true;
            this.tb_Sign.Name = "tb_Sign";
            this.tb_Sign.Size = new System.Drawing.Size(203, 21);
            this.tb_Sign.TabIndex = 8;
            this.tb_Sign.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Sign_KeyPress);
            // 
            // label_AddUser
            // 
            this.label_AddUser.BackColor = System.Drawing.Color.Transparent;
            this.tlp_AddUser.SetColumnSpan(this.label_AddUser, 2);
            this.label_AddUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_AddUser.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AddUser.ForeColor = System.Drawing.Color.Firebrick;
            this.label_AddUser.Location = new System.Drawing.Point(0, 0);
            this.label_AddUser.Margin = new System.Windows.Forms.Padding(0);
            this.label_AddUser.Name = "label_AddUser";
            this.label_AddUser.Size = new System.Drawing.Size(325, 30);
            this.label_AddUser.TabIndex = 56;
            this.label_AddUser.Text = "Lägg till användare:";
            this.label_AddUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cb_Role
            // 
            this.cb_Role.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Role.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Role.BackColor = System.Drawing.SystemColors.Menu;
            this.cb_Role.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Role.FormattingEnabled = true;
            this.cb_Role.Location = new System.Drawing.Point(122, 74);
            this.cb_Role.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Role.Name = "cb_Role";
            this.cb_Role.Size = new System.Drawing.Size(203, 21);
            this.cb_Role.TabIndex = 5;
            // 
            // label_NewPassword
            // 
            this.label_NewPassword.AutoSize = true;
            this.label_NewPassword.BackColor = System.Drawing.Color.Transparent;
            this.label_NewPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_NewPassword.ForeColor = System.Drawing.SystemColors.Info;
            this.label_NewPassword.Location = new System.Drawing.Point(3, 162);
            this.label_NewPassword.Name = "label_NewPassword";
            this.label_NewPassword.Size = new System.Drawing.Size(116, 22);
            this.label_NewPassword.TabIndex = 48;
            this.label_NewPassword.Text = "Lösenord:";
            this.label_NewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Sign
            // 
            this.label_Sign.AutoSize = true;
            this.label_Sign.BackColor = System.Drawing.Color.Transparent;
            this.label_Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Sign.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Sign.Location = new System.Drawing.Point(3, 140);
            this.label_Sign.Name = "label_Sign";
            this.label_Sign.Size = new System.Drawing.Size(116, 22);
            this.label_Sign.TabIndex = 54;
            this.label_Sign.Text = "Signatur:";
            this.label_Sign.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_AnstNr
            // 
            this.tb_AnstNr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_AnstNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_AnstNr.Location = new System.Drawing.Point(122, 118);
            this.tb_AnstNr.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tb_AnstNr.Multiline = true;
            this.tb_AnstNr.Name = "tb_AnstNr";
            this.tb_AnstNr.Size = new System.Drawing.Size(203, 21);
            this.tb_AnstNr.TabIndex = 7;
            this.tb_AnstNr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AnstNr_KeyPress);
            this.tb_AnstNr.Leave += new System.EventHandler(this.AnstNr_Leave);
            // 
            // label_EmpNr
            // 
            this.label_EmpNr.AutoSize = true;
            this.label_EmpNr.BackColor = System.Drawing.Color.Transparent;
            this.label_EmpNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_EmpNr.ForeColor = System.Drawing.SystemColors.Info;
            this.label_EmpNr.Location = new System.Drawing.Point(3, 118);
            this.label_EmpNr.Name = "label_EmpNr";
            this.label_EmpNr.Size = new System.Drawing.Size(116, 22);
            this.label_EmpNr.TabIndex = 41;
            this.label_EmpNr.Text = "AnstNr:";
            this.label_EmpNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_FirstName
            // 
            this.label_FirstName.AutoSize = true;
            this.label_FirstName.BackColor = System.Drawing.Color.Transparent;
            this.label_FirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_FirstName.ForeColor = System.Drawing.SystemColors.Info;
            this.label_FirstName.Location = new System.Drawing.Point(3, 30);
            this.label_FirstName.Name = "label_FirstName";
            this.label_FirstName.Size = new System.Drawing.Size(116, 22);
            this.label_FirstName.TabIndex = 40;
            this.label_FirstName.Text = "Förnamn:";
            this.label_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Förnamn
            // 
            this.tb_Förnamn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Förnamn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_Förnamn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Förnamn.Location = new System.Drawing.Point(122, 30);
            this.tb_Förnamn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tb_Förnamn.Multiline = true;
            this.tb_Förnamn.Name = "tb_Förnamn";
            this.tb_Förnamn.Size = new System.Drawing.Size(203, 21);
            this.tb_Förnamn.TabIndex = 1;
            this.tb_Förnamn.Leave += new System.EventHandler(this.Name_Leave);
            // 
            // label_LastName
            // 
            this.label_LastName.AutoSize = true;
            this.label_LastName.BackColor = System.Drawing.Color.Transparent;
            this.label_LastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LastName.ForeColor = System.Drawing.SystemColors.Info;
            this.label_LastName.Location = new System.Drawing.Point(3, 52);
            this.label_LastName.Name = "label_LastName";
            this.label_LastName.Size = new System.Drawing.Size(116, 22);
            this.label_LastName.TabIndex = 44;
            this.label_LastName.Text = "Efternamn:";
            this.label_LastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Efternamn
            // 
            this.tb_Efternamn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Efternamn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_Efternamn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Efternamn.Location = new System.Drawing.Point(122, 52);
            this.tb_Efternamn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tb_Efternamn.Multiline = true;
            this.tb_Efternamn.Name = "tb_Efternamn";
            this.tb_Efternamn.Size = new System.Drawing.Size(203, 21);
            this.tb_Efternamn.TabIndex = 2;
            this.tb_Efternamn.Leave += new System.EventHandler(this.Name_Leave);
            // 
            // tb_Mail
            // 
            this.tb_Mail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Mail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Mail.Location = new System.Drawing.Point(122, 96);
            this.tb_Mail.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tb_Mail.Multiline = true;
            this.tb_Mail.Name = "tb_Mail";
            this.tb_Mail.Size = new System.Drawing.Size(203, 21);
            this.tb_Mail.TabIndex = 6;
            this.tb_Mail.Leave += new System.EventHandler(this.Mail_Leave);
            // 
            // label_Role
            // 
            this.label_Role.AutoSize = true;
            this.label_Role.BackColor = System.Drawing.Color.Transparent;
            this.label_Role.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Role.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Role.Location = new System.Drawing.Point(3, 74);
            this.label_Role.Name = "label_Role";
            this.label_Role.Size = new System.Drawing.Size(116, 22);
            this.label_Role.TabIndex = 60;
            this.label_Role.Text = "Befattning:";
            this.label_Role.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_NewPassword
            // 
            this.tb_NewPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_NewPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_NewPassword.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.tb_NewPassword.Location = new System.Drawing.Point(122, 162);
            this.tb_NewPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tb_NewPassword.Multiline = true;
            this.tb_NewPassword.Name = "tb_NewPassword";
            this.tb_NewPassword.PasswordChar = '*';
            this.tb_NewPassword.Size = new System.Drawing.Size(203, 21);
            this.tb_NewPassword.TabIndex = 9;
            this.tb_NewPassword.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // btn_AddProfilePicture
            // 
            this.btn_AddProfilePicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_AddProfilePicture.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_AddProfilePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddProfilePicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_AddProfilePicture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_AddProfilePicture.Location = new System.Drawing.Point(125, 261);
            this.btn_AddProfilePicture.Name = "btn_AddProfilePicture";
            this.btn_AddProfilePicture.Size = new System.Drawing.Size(197, 27);
            this.btn_AddProfilePicture.TabIndex = 63;
            this.btn_AddProfilePicture.Text = "Ladda upp profilbild";
            this.btn_AddProfilePicture.UseVisualStyleBackColor = false;
            this.btn_AddProfilePicture.Click += new System.EventHandler(this.AddProfilePicture_Click);
            // 
            // label_InfoPassword_2
            // 
            this.label_InfoPassword_2.AutoSize = true;
            this.label_InfoPassword_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.tlp_AddUser.SetColumnSpan(this.label_InfoPassword_2, 2);
            this.label_InfoPassword_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_InfoPassword_2.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_InfoPassword_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.label_InfoPassword_2.Location = new System.Drawing.Point(3, 237);
            this.label_InfoPassword_2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label_InfoPassword_2.Name = "label_InfoPassword_2";
            this.label_InfoPassword_2.Size = new System.Drawing.Size(322, 21);
            this.label_InfoPassword_2.TabIndex = 66;
            this.label_InfoPassword_2.Text = "Lösenorden matchar inte varandra.";
            this.label_InfoPassword_2.Visible = false;
            // 
            // flp_Users
            // 
            this.flp_Users.BackColor = System.Drawing.Color.Transparent;
            this.flp_Users.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flp_Users.Location = new System.Drawing.Point(0, 480);
            this.flp_Users.Name = "flp_Users";
            this.flp_Users.Size = new System.Drawing.Size(690, 90);
            this.flp_Users.TabIndex = 51;
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.panel_Bottom.Controls.Add(this.tlp_Bottom);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 570);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(690, 103);
            this.panel_Bottom.TabIndex = 47;
            // 
            // tlp_Bottom
            // 
            this.tlp_Bottom.ColumnCount = 3;
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 327F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Bottom.Controls.Add(this.label_ChooseUser, 0, 0);
            this.tlp_Bottom.Controls.Add(this.lbl_Exit, 2, 3);
            this.tlp_Bottom.Controls.Add(this.tb_Password, 0, 3);
            this.tlp_Bottom.Controls.Add(this.lbl_NewUser, 2, 1);
            this.tlp_Bottom.Controls.Add(this.lbl_EditUser, 2, 0);
            this.tlp_Bottom.Controls.Add(this.label_Password, 0, 2);
            this.tlp_Bottom.Controls.Add(this.lbl_User, 0, 1);
            this.tlp_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Bottom.Location = new System.Drawing.Point(0, 0);
            this.tlp_Bottom.Name = "tlp_Bottom";
            this.tlp_Bottom.RowCount = 4;
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlp_Bottom.Size = new System.Drawing.Size(690, 103);
            this.tlp_Bottom.TabIndex = 49;
            // 
            // lbl_Exit
            // 
            this.lbl_Exit.AutoSize = true;
            this.lbl_Exit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Exit.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Exit.Font = new System.Drawing.Font("Segoe UI", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Exit.ForeColor = System.Drawing.Color.Aquamarine;
            this.lbl_Exit.Location = new System.Drawing.Point(507, 69);
            this.lbl_Exit.Name = "lbl_Exit";
            this.lbl_Exit.Size = new System.Drawing.Size(69, 34);
            this.lbl_Exit.TabIndex = 48;
            this.lbl_Exit.Text = "Avsluta";
            this.lbl_Exit.Click += new System.EventHandler(this.Exit_Click);
            this.lbl_Exit.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            this.lbl_Exit.MouseHover += new System.EventHandler(this.Buttons_MouseEnter);
            // 
            // lbl_NewUser
            // 
            this.lbl_NewUser.AutoSize = true;
            this.lbl_NewUser.BackColor = System.Drawing.Color.Transparent;
            this.lbl_NewUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_NewUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_NewUser.Font = new System.Drawing.Font("Segoe UI", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NewUser.ForeColor = System.Drawing.Color.Aquamarine;
            this.lbl_NewUser.Location = new System.Drawing.Point(507, 21);
            this.lbl_NewUser.Name = "lbl_NewUser";
            this.tlp_Bottom.SetRowSpan(this.lbl_NewUser, 2);
            this.lbl_NewUser.Size = new System.Drawing.Size(125, 48);
            this.lbl_NewUser.TabIndex = 48;
            this.lbl_NewUser.Text = "Ny Användare";
            this.lbl_NewUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_NewUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NyAnvändare_MouseDown);
            this.lbl_NewUser.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            this.lbl_NewUser.MouseHover += new System.EventHandler(this.Buttons_MouseEnter);
            // 
            // lbl_EditUser
            // 
            this.lbl_EditUser.AutoSize = true;
            this.lbl_EditUser.BackColor = System.Drawing.Color.Transparent;
            this.lbl_EditUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_EditUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_EditUser.Font = new System.Drawing.Font("Segoe UI", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EditUser.ForeColor = System.Drawing.Color.Aquamarine;
            this.lbl_EditUser.Location = new System.Drawing.Point(507, 0);
            this.lbl_EditUser.Name = "lbl_EditUser";
            this.lbl_EditUser.Size = new System.Drawing.Size(173, 21);
            this.lbl_EditUser.TabIndex = 48;
            this.lbl_EditUser.Text = "Redigera Användare";
            this.lbl_EditUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RedigeraAnvändare_MouseDown);
            this.lbl_EditUser.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            this.lbl_EditUser.MouseHover += new System.EventHandler(this.Buttons_MouseEnter);
            // 
            // lbl_User
            // 
            this.lbl_User.AutoSize = true;
            this.lbl_User.BackColor = System.Drawing.Color.White;
            this.lbl_User.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_User.Location = new System.Drawing.Point(6, 23);
            this.lbl_User.Margin = new System.Windows.Forms.Padding(6, 2, 3, 5);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lbl_User.Size = new System.Drawing.Size(168, 19);
            this.lbl_User.TabIndex = 52;
            this.lbl_User.TextChanged += new System.EventHandler(this.User_TextChanged);
            this.lbl_User.Click += new System.EventHandler(this.Users_Click);
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.panel_Top.Controls.Add(this.pb_Info);
            this.panel_Top.Controls.Add(this.lbl_Date);
            this.panel_Top.Controls.Add(this.lbl_Weather);
            this.panel_Top.Controls.Add(this.lbl_Temp);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(690, 47);
            this.panel_Top.TabIndex = 46;
            // 
            // pb_Info
            // 
            this.pb_Info.BackColor = System.Drawing.Color.Transparent;
            this.pb_Info.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Info.BackgroundImage")));
            this.pb_Info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info.Location = new System.Drawing.Point(4, 4);
            this.pb_Info.Name = "pb_Info";
            this.pb_Info.Size = new System.Drawing.Size(35, 34);
            this.pb_Info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Info.TabIndex = 870;
            this.pb_Info.TabStop = false;
            this.pb_Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // lbl_Date
            // 
            this.lbl_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbl_Date.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Date.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_Date.Location = new System.Drawing.Point(405, 11);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(57, 21);
            this.lbl_Date.TabIndex = 6;
            this.lbl_Date.Text = "Datum";
            // 
            // lbl_Weather
            // 
            this.lbl_Weather.AutoSize = true;
            this.lbl_Weather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbl_Weather.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Weather.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Weather.Location = new System.Drawing.Point(239, 11);
            this.lbl_Weather.Name = "lbl_Weather";
            this.lbl_Weather.Size = new System.Drawing.Size(119, 21);
            this.lbl_Weather.TabIndex = 10;
            this.lbl_Weather.Text = "Moustly Cloudy";
            this.lbl_Weather.Visible = false;
            // 
            // lbl_Temp
            // 
            this.lbl_Temp.AutoSize = true;
            this.lbl_Temp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbl_Temp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Temp.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Temp.Location = new System.Drawing.Point(364, 11);
            this.lbl_Temp.Name = "lbl_Temp";
            this.lbl_Temp.Size = new System.Drawing.Size(35, 21);
            this.lbl_Temp.TabIndex = 10;
            this.lbl_Temp.Text = "9°C";
            this.lbl_Temp.Visible = false;
            // 
            // timer_UpdateTime
            // 
            this.timer_UpdateTime.Enabled = true;
            this.timer_UpdateTime.Interval = 1000;
            this.timer_UpdateTime.Tick += new System.EventHandler(this.UpdateTime_Tick);
            // 
            // ProfileCard
            // 
            this.ProfileCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ProfileCard.Location = new System.Drawing.Point(12, 64);
            this.ProfileCard.Name = "ProfileCard";
            this.ProfileCard.Size = new System.Drawing.Size(346, 228);
            this.ProfileCard.TabIndex = 53;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(690, 673);
            this.Controls.Add(this.panel_Background);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_Ny_FormClosing);
            this.panel_Background.ResumeLayout(false);
            this.tlp_AddUser.ResumeLayout(false);
            this.tlp_AddUser.PerformLayout();
            this.panel_Bottom.ResumeLayout(false);
            this.tlp_Bottom.ResumeLayout(false);
            this.tlp_Bottom.PerformLayout();
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).EndInit();
            this.ResumeLayout(false);

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