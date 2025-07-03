using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.User
{
    public partial class ResetPassword : Form
    {
        private string? currentCode;
        private DateTime codeExpiresAt;
        private int remainingSeconds = 120;
        private const int maxAttempts = 3;
        private int attemptCount;
        private bool CheckCode()
        {
            string code = tb_Code_1.Text + tb_Code_2.Text + tb_Code_3.Text + tb_Code_4.Text + tb_Code_5.Text + tb_Code_6.Text;
            return code == currentCode;
        }
        private bool ValidatePasswords(out string errorMessage)
        {
            var pw = tb_NewPassword.Text;
            var confirm = tb_ConfirmNewPassword.Text;

            if (string.IsNullOrWhiteSpace(pw) || pw.Length < 4)
            {
                errorMessage = "Lösenordet måste vara minst 4 tecken långt.";
                return false;
            }

            if (pw != confirm)
            {
                errorMessage = "Lösenorden matchar inte.";
                return false;
            }

            errorMessage = "";
            return true;
        }


        public ResetPassword()
        {
            InitializeComponent();
            SendNewCode();
            StartCountdown();
            TranslateForm();

        }

        private void Initialize_SetNewPassword()
        {
            tb_Code_1.Visible = tb_Code_2.Visible = tb_Code_3.Visible = tb_Code_4.Visible = tb_Code_5.Visible = tb_Code_6.Visible = false;
            btn_ConfirmCode.Visible = false;
            btn_NewCode.Visible = false;
            lbl_ResetPasswordTimer.Visible = false;
            panel_NewPassword.Visible = true;
            panel_NewPassword.Left = 20;
            label_ResetPasswordInfo.Text = @"Ange ett nytt lösenord:";
        }
        private void TranslateForm()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { label_ResetPasswordInfo, btn_ConfirmCode, btn_NewCode, btn_ConfirmNewCode });
           
        }
        private void timer_Counter_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;
            UpdateCountdownLabel();

            if (remainingSeconds <= 0)
            {
                timer_Counter.Stop();
                lbl_ResetPasswordError.Text = LanguageManager.GetString("resetPassword_CodeExpired");
                lbl_ResetPasswordError.Visible = true;
                btn_ConfirmCode.Enabled = false;
            }
        }
        private void StartCountdown()
        {
            timer_Counter = new System.Windows.Forms.Timer();
            timer_Counter.Interval = 1000;
            timer_Counter.Tick += timer_Counter_Tick;
            timer_Counter.Start();
            UpdateCountdownLabel();
        }
        private void UpdateCountdownLabel()
        {
            int mins = remainingSeconds / 60;
            int secs = remainingSeconds % 60;
            lbl_ResetPasswordTimer.Text = $"{LanguageManager.GetString("resetPassword_TimeLeft")} {mins:D2}:{secs:D2}";
        }
        private void SendNewCode()
        {
            // Här genereras en 6-siffrig kod
            var rnd = new Random();
            currentCode = rnd.Next(100000, 999999).ToString();
            codeExpiresAt = DateTime.Now.AddMinutes(2);
            remainingSeconds = 120;
            attemptCount = 0;

            Mail.NotifyUserCodeResetPassword(currentCode);
        }
        private void ClearAllCodeTextBoxes()
        {
            tb_Code_1.Clear();
            tb_Code_2.Clear();
            tb_Code_3.Clear();
            tb_Code_4.Clear();
            tb_Code_5.Clear();
            tb_Code_6.Clear();

            tb_Code_1.Focus();
        }
        private void CheckIfCodeIsComplete()
        {
            bool allFilled = !string.IsNullOrWhiteSpace(tb_Code_1.Text) &&
                             !string.IsNullOrWhiteSpace(tb_Code_2.Text) &&
                             !string.IsNullOrWhiteSpace(tb_Code_3.Text) &&
                             !string.IsNullOrWhiteSpace(tb_Code_4.Text) &&
                             !string.IsNullOrWhiteSpace(tb_Code_5.Text) &&
                             !string.IsNullOrWhiteSpace(tb_Code_6.Text);

            btn_ConfirmCode.Enabled = allFilled;
        }

        private void btn_ConfirmCode_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > codeExpiresAt)
            {
                lbl_ResetPasswordError.Text = LanguageManager.GetString("resetPassword_CodeExpired");
                lbl_ResetPasswordError.Visible = true;
                return;
            }

            if (CheckCode())
            {
                timer_Counter.Stop();
                Initialize_SetNewPassword();
            }
            else
            {
                attemptCount++;
                if (attemptCount >= maxAttempts)
                {
                    btn_ConfirmCode.Enabled = false;
                    lbl_ResetPasswordError.Text = LanguageManager.GetString("resetPassword_MaxAttemptsReached");
                }
                else
                {
                    lbl_ResetPasswordError.Text = $"{LanguageManager.GetString("resetPassword_WrongCode")} {maxAttempts - attemptCount}";
                    ClearAllCodeTextBoxes();
                }
                lbl_ResetPasswordError.Visible = true;
            }
        }
        private void btn_ConfirmNewCode_Click(object sender, EventArgs e)
        {
            if (!ValidatePasswords(out string error))
            {
                lbl_ResetPasswordError.Text = error;
                lbl_ResetPasswordError.Visible = true;
                return;
            }
            Person.UpdatePassword(tb_NewPassword.Text);
            InfoText.Show($"{LanguageManager.GetString("user_PasswordUpdated")}", CustomColors.InfoText_Color.Ok, null);
            this.Close();
        }
        private void btn_NewCode_Click(object sender, EventArgs e)
        {
            timer_Counter.Stop();
            SendNewCode();
            StartCountdown();
            btn_ConfirmCode.Enabled = true;
            lbl_ResetPasswordError.Visible = false;
            ClearAllCodeTextBoxes();
        }
        private void tb_Code_TextChanged(object sender, EventArgs e)
        {
            var currentTextBox = sender as TextBox;

            CheckIfCodeIsComplete();

            if (currentTextBox == null) return;

            if (currentTextBox.Text.Length > 1)
            {
                currentTextBox.Text = currentTextBox.Text.Substring(0, 1);
                currentTextBox.SelectionStart = 1;
            }

            if (currentTextBox.Text.Length == 1)
            {
                // Flytta fokus till nästa kontroll i tabordningen
                this.SelectNextControl(currentTextBox, true, true, true, true);

                // Om det är sista textboxen, kolla koden
                if (currentTextBox == tb_Code_6)
                {
                    CheckCode();
                }
            }
        }
        private void tb_Code_Enter(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            tb?.SelectAll();
        }
        private void tb_NewPassword_TextChanged(object sender, EventArgs e)
        {
            if (!ValidatePasswords(out var error))
            {
                lbl_ResetPasswordError.Text = error;
                lbl_ResetPasswordError.Visible = true;
            }
            else
                lbl_ResetPasswordError.Visible = false;
        }

    }
}
