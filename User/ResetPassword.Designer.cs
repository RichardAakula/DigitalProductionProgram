namespace DigitalProductionProgram.User
{
    partial class ResetPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            label_ResetPasswordInfo = new Label();
            tb_Code_1 = new TextBox();
            lbl_ResetPasswordTimer = new Label();
            btn_ConfirmCode = new Button();
            btn_NewCode = new Button();
            lbl_ResetPasswordError = new Label();
            timer_Counter = new System.Windows.Forms.Timer(components);
            tb_Code_2 = new TextBox();
            tb_Code_3 = new TextBox();
            tb_Code_4 = new TextBox();
            tb_Code_5 = new TextBox();
            tb_Code_6 = new TextBox();
            tb_NewPassword = new TextBox();
            btn_ConfirmNewCode = new Button();
            tb_ConfirmNewPassword = new TextBox();
            panel_NewPassword = new Panel();
            panel_NewPassword.SuspendLayout();
            SuspendLayout();
            // 
            // label_ResetPasswordInfo
            // 
            label_ResetPasswordInfo.AutoSize = true;
            label_ResetPasswordInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_ResetPasswordInfo.ForeColor = Color.FromArgb(119, 142, 162);
            label_ResetPasswordInfo.Location = new Point(12, 30);
            label_ResetPasswordInfo.Name = "label_ResetPasswordInfo";
            label_ResetPasswordInfo.Size = new Size(502, 25);
            label_ResetPasswordInfo.TabIndex = 0;
            label_ResetPasswordInfo.Text = "Vi har skickat en kod till din e-post. Skriv in den nedan.";
            // 
            // tb_Code_1
            // 
            tb_Code_1.Font = new Font("Segoe UI", 18F);
            tb_Code_1.Location = new Point(22, 76);
            tb_Code_1.Name = "tb_Code_1";
            tb_Code_1.Size = new Size(50, 39);
            tb_Code_1.TabIndex = 1;
            tb_Code_1.TextAlign = HorizontalAlignment.Center;
            tb_Code_1.TextChanged += tb_Code_TextChanged;
            tb_Code_1.Enter += tb_Code_Enter;
            // 
            // lbl_ResetPasswordTimer
            // 
            lbl_ResetPasswordTimer.AutoSize = true;
            lbl_ResetPasswordTimer.Dock = DockStyle.Bottom;
            lbl_ResetPasswordTimer.Font = new Font("Segoe UI", 16F);
            lbl_ResetPasswordTimer.ForeColor = Color.FromArgb(57, 108, 121);
            lbl_ResetPasswordTimer.Location = new Point(0, 234);
            lbl_ResetPasswordTimer.Name = "lbl_ResetPasswordTimer";
            lbl_ResetPasswordTimer.Size = new Size(176, 30);
            lbl_ResetPasswordTimer.TabIndex = 2;
            lbl_ResetPasswordTimer.Text = "Koden är giltig i: ";
            // 
            // btn_ConfirmCode
            // 
            btn_ConfirmCode.BackColor = Color.FromArgb(80, 80, 80);
            btn_ConfirmCode.Cursor = Cursors.Hand;
            btn_ConfirmCode.Enabled = false;
            btn_ConfirmCode.FlatAppearance.BorderColor = Color.FromArgb(57, 108, 121);
            btn_ConfirmCode.FlatAppearance.BorderSize = 0;
            btn_ConfirmCode.FlatAppearance.MouseOverBackColor = SystemColors.WindowFrame;
            btn_ConfirmCode.FlatStyle = FlatStyle.Flat;
            btn_ConfirmCode.ForeColor = Color.FromArgb(171, 150, 85);
            btn_ConfirmCode.Location = new Point(25, 138);
            btn_ConfirmCode.Name = "btn_ConfirmCode";
            btn_ConfirmCode.Size = new Size(96, 23);
            btn_ConfirmCode.TabIndex = 7;
            btn_ConfirmCode.Text = "Bekräfta Kod";
            btn_ConfirmCode.UseVisualStyleBackColor = false;
            btn_ConfirmCode.Click += btn_ConfirmCode_Click;
            // 
            // btn_NewCode
            // 
            btn_NewCode.BackColor = Color.FromArgb(80, 80, 80);
            btn_NewCode.Cursor = Cursors.Hand;
            btn_NewCode.FlatAppearance.BorderColor = Color.FromArgb(57, 108, 121);
            btn_NewCode.FlatAppearance.BorderSize = 0;
            btn_NewCode.FlatAppearance.MouseOverBackColor = SystemColors.WindowFrame;
            btn_NewCode.FlatStyle = FlatStyle.Flat;
            btn_NewCode.ForeColor = Color.FromArgb(171, 150, 85);
            btn_NewCode.Location = new Point(167, 138);
            btn_NewCode.Name = "btn_NewCode";
            btn_NewCode.Size = new Size(96, 23);
            btn_NewCode.TabIndex = 8;
            btn_NewCode.Text = "Skicka ny kod";
            btn_NewCode.UseVisualStyleBackColor = false;
            btn_NewCode.Click += btn_NewCode_Click;
            // 
            // lbl_ResetPasswordError
            // 
            lbl_ResetPasswordError.AutoSize = true;
            lbl_ResetPasswordError.Dock = DockStyle.Bottom;
            lbl_ResetPasswordError.Font = new Font("Segoe UI", 14F);
            lbl_ResetPasswordError.ForeColor = Color.FromArgb(255, 199, 206);
            lbl_ResetPasswordError.Location = new Point(0, 209);
            lbl_ResetPasswordError.Name = "lbl_ResetPasswordError";
            lbl_ResetPasswordError.Size = new Size(72, 25);
            lbl_ResetPasswordError.TabIndex = 4;
            lbl_ResetPasswordError.Text = "Fel kod";
            lbl_ResetPasswordError.Visible = false;
            // 
            // timer_Counter
            // 
            timer_Counter.Interval = 1000;
            timer_Counter.Tick += timer_Counter_Tick;
            // 
            // tb_Code_2
            // 
            tb_Code_2.Font = new Font("Segoe UI", 18F);
            tb_Code_2.Location = new Point(78, 76);
            tb_Code_2.Name = "tb_Code_2";
            tb_Code_2.Size = new Size(50, 39);
            tb_Code_2.TabIndex = 2;
            tb_Code_2.TextAlign = HorizontalAlignment.Center;
            tb_Code_2.TextChanged += tb_Code_TextChanged;
            tb_Code_2.Enter += tb_Code_Enter;
            // 
            // tb_Code_3
            // 
            tb_Code_3.Font = new Font("Segoe UI", 18F);
            tb_Code_3.Location = new Point(134, 76);
            tb_Code_3.Name = "tb_Code_3";
            tb_Code_3.Size = new Size(50, 39);
            tb_Code_3.TabIndex = 3;
            tb_Code_3.TextAlign = HorizontalAlignment.Center;
            tb_Code_3.TextChanged += tb_Code_TextChanged;
            tb_Code_3.Enter += tb_Code_Enter;
            // 
            // tb_Code_4
            // 
            tb_Code_4.Font = new Font("Segoe UI", 18F);
            tb_Code_4.Location = new Point(190, 76);
            tb_Code_4.Name = "tb_Code_4";
            tb_Code_4.Size = new Size(50, 39);
            tb_Code_4.TabIndex = 4;
            tb_Code_4.TextAlign = HorizontalAlignment.Center;
            tb_Code_4.TextChanged += tb_Code_TextChanged;
            tb_Code_4.Enter += tb_Code_Enter;
            // 
            // tb_Code_5
            // 
            tb_Code_5.Font = new Font("Segoe UI", 18F);
            tb_Code_5.Location = new Point(246, 76);
            tb_Code_5.Name = "tb_Code_5";
            tb_Code_5.Size = new Size(50, 39);
            tb_Code_5.TabIndex = 5;
            tb_Code_5.TextAlign = HorizontalAlignment.Center;
            tb_Code_5.TextChanged += tb_Code_TextChanged;
            tb_Code_5.Enter += tb_Code_Enter;
            // 
            // tb_Code_6
            // 
            tb_Code_6.Font = new Font("Segoe UI", 18F);
            tb_Code_6.Location = new Point(302, 76);
            tb_Code_6.Name = "tb_Code_6";
            tb_Code_6.Size = new Size(50, 39);
            tb_Code_6.TabIndex = 6;
            tb_Code_6.TextAlign = HorizontalAlignment.Center;
            tb_Code_6.TextChanged += tb_Code_TextChanged;
            tb_Code_6.Enter += tb_Code_Enter;
            // 
            // tb_NewPassword
            // 
            tb_NewPassword.BorderStyle = BorderStyle.None;
            tb_NewPassword.Font = new Font("Courier New", 9.25F);
            tb_NewPassword.Location = new Point(7, 11);
            tb_NewPassword.Margin = new Padding(0, 0, 0, 1);
            tb_NewPassword.Multiline = true;
            tb_NewPassword.Name = "tb_NewPassword";
            tb_NewPassword.PasswordChar = '*';
            tb_NewPassword.Size = new Size(237, 24);
            tb_NewPassword.TabIndex = 10;
            tb_NewPassword.TextChanged += tb_NewPassword_TextChanged;
            // 
            // btn_ConfirmNewCode
            // 
            btn_ConfirmNewCode.BackColor = Color.FromArgb(80, 80, 80);
            btn_ConfirmNewCode.Cursor = Cursors.Hand;
            btn_ConfirmNewCode.FlatAppearance.BorderColor = Color.FromArgb(57, 108, 121);
            btn_ConfirmNewCode.FlatAppearance.BorderSize = 0;
            btn_ConfirmNewCode.FlatAppearance.MouseOverBackColor = SystemColors.WindowFrame;
            btn_ConfirmNewCode.FlatStyle = FlatStyle.Flat;
            btn_ConfirmNewCode.ForeColor = Color.FromArgb(171, 150, 85);
            btn_ConfirmNewCode.Location = new Point(7, 94);
            btn_ConfirmNewCode.Name = "btn_ConfirmNewCode";
            btn_ConfirmNewCode.Size = new Size(96, 23);
            btn_ConfirmNewCode.TabIndex = 7;
            btn_ConfirmNewCode.Text = "Bekräfta Kod";
            btn_ConfirmNewCode.UseVisualStyleBackColor = false;
            btn_ConfirmNewCode.Click += btn_ConfirmNewCode_Click;
            // 
            // tb_ConfirmNewPassword
            // 
            tb_ConfirmNewPassword.BorderStyle = BorderStyle.None;
            tb_ConfirmNewPassword.Font = new Font("Courier New", 9.25F);
            tb_ConfirmNewPassword.Location = new Point(7, 55);
            tb_ConfirmNewPassword.Margin = new Padding(0, 0, 0, 1);
            tb_ConfirmNewPassword.Multiline = true;
            tb_ConfirmNewPassword.Name = "tb_ConfirmNewPassword";
            tb_ConfirmNewPassword.PasswordChar = '*';
            tb_ConfirmNewPassword.Size = new Size(237, 24);
            tb_ConfirmNewPassword.TabIndex = 10;
            tb_ConfirmNewPassword.TextChanged += tb_NewPassword_TextChanged;
            // 
            // panel_NewPassword
            // 
            panel_NewPassword.Controls.Add(tb_NewPassword);
            panel_NewPassword.Controls.Add(tb_ConfirmNewPassword);
            panel_NewPassword.Controls.Add(btn_ConfirmNewCode);
            panel_NewPassword.Location = new Point(539, 76);
            panel_NewPassword.Name = "panel_NewPassword";
            panel_NewPassword.Size = new Size(249, 143);
            panel_NewPassword.TabIndex = 11;
            panel_NewPassword.Visible = false;
            // 
            // ResetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            ClientSize = new Size(800, 264);
            Controls.Add(panel_NewPassword);
            Controls.Add(lbl_ResetPasswordError);
            Controls.Add(btn_NewCode);
            Controls.Add(btn_ConfirmCode);
            Controls.Add(lbl_ResetPasswordTimer);
            Controls.Add(tb_Code_6);
            Controls.Add(tb_Code_5);
            Controls.Add(tb_Code_4);
            Controls.Add(tb_Code_3);
            Controls.Add(tb_Code_2);
            Controls.Add(tb_Code_1);
            Controls.Add(label_ResetPasswordInfo);
            Name = "ResetPassword";
            Text = "ResetPassword";
            panel_NewPassword.ResumeLayout(false);
            panel_NewPassword.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_ResetPasswordInfo;
        private TextBox tb_Code_1;
        private Label lbl_ResetPasswordTimer;
        private Button btn_ConfirmCode;
        private Button btn_NewCode;
        private Label lbl_ResetPasswordError;
        private System.Windows.Forms.Timer timer_Counter;
        private TextBox tb_Code_2;
        private TextBox tb_Code_3;
        private TextBox tb_Code_4;
        private TextBox tb_Code_5;
        private TextBox tb_Code_6;
        private TextBox tb_NewPassword;
        private Button btn_ConfirmNewCode;
        private TextBox tb_ConfirmNewPassword;
        private Panel panel_NewPassword;
    }
}