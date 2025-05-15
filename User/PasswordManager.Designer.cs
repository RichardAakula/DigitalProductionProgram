using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.User
{
    partial class PasswordManager : Form
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
            this.lblNamn = new System.Windows.Forms.Label();
            this.label_Header = new System.Windows.Forms.Label();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.label_PasswordPassword = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.label_PasswordUser = new System.Windows.Forms.Label();
            this.lbl_Abort = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_PasswordInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNamn
            // 
            this.lblNamn.Location = new System.Drawing.Point(25, 46);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(0, 0);
            this.lblNamn.TabIndex = 0;
            this.lblNamn.Text = "Namn:";
            // 
            // label_Header
            // 
            this.label_Header.BackColor = System.Drawing.Color.Transparent;
            this.label_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_Header.ForeColor = System.Drawing.Color.White;
            this.label_Header.Location = new System.Drawing.Point(0, 0);
            this.label_Header.Name = "label_Header";
            this.label_Header.Size = new System.Drawing.Size(468, 17);
            this.label_Header.TabIndex = 2;
            this.label_Header.Text = "Bekräfta överföringen med lösenord:";
            this.label_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(196, 68);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(133, 20);
            this.tb_Password.TabIndex = 3;
            this.tb_Password.UseSystemPasswordChar = true;
            this.tb_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Password_KeyPress);
            // 
            // label_PasswordPassword
            // 
            this.label_PasswordPassword.BackColor = System.Drawing.Color.Transparent;
            this.label_PasswordPassword.ForeColor = System.Drawing.Color.White;
            this.label_PasswordPassword.Location = new System.Drawing.Point(135, 71);
            this.label_PasswordPassword.Name = "label_PasswordPassword";
            this.label_PasswordPassword.Size = new System.Drawing.Size(58, 17);
            this.label_PasswordPassword.TabIndex = 4;
            this.label_PasswordPassword.Text = "Lösenord:";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(196, 32);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.ReadOnly = true;
            this.tb_Name.Size = new System.Drawing.Size(133, 20);
            this.tb_Name.TabIndex = 6;
            // 
            // label_PasswordUser
            // 
            this.label_PasswordUser.BackColor = System.Drawing.Color.Transparent;
            this.label_PasswordUser.ForeColor = System.Drawing.Color.White;
            this.label_PasswordUser.Location = new System.Drawing.Point(130, 35);
            this.label_PasswordUser.Name = "label_PasswordUser";
            this.label_PasswordUser.Size = new System.Drawing.Size(64, 17);
            this.label_PasswordUser.TabIndex = 7;
            this.label_PasswordUser.Text = "Användare:";
            // 
            // lbl_Abort
            // 
            this.lbl_Abort.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Abort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Abort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Abort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_Abort.ForeColor = System.Drawing.Color.Red;
            this.lbl_Abort.Location = new System.Drawing.Point(365, 0);
            this.lbl_Abort.Name = "lbl_Abort";
            this.lbl_Abort.Size = new System.Drawing.Size(100, 27);
            this.lbl_Abort.TabIndex = 8;
            this.lbl_Abort.Text = "Avbryt:";
            this.lbl_Abort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Abort.Click += new System.EventHandler(this.Abort_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.35043F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.64957F));
            this.tableLayoutPanel1.Controls.Add(this.label_PasswordInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Abort, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 94);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(468, 27);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // label_PasswordInfo
            // 
            this.label_PasswordInfo.BackColor = System.Drawing.Color.Transparent;
            this.label_PasswordInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_PasswordInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PasswordInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_PasswordInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.label_PasswordInfo.Location = new System.Drawing.Point(3, 0);
            this.label_PasswordInfo.Name = "label_PasswordInfo";
            this.label_PasswordInfo.Size = new System.Drawing.Size(356, 27);
            this.label_PasswordInfo.TabIndex = 9;
            this.label_PasswordInfo.Text = "Bekräfta ditt lösenord med Enter/Retur";
            this.label_PasswordInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PasswordManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(468, 121);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label_Header);
            this.Controls.Add(this.label_PasswordUser);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.lblNamn);
            this.Controls.Add(this.label_PasswordPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PasswordManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lösenord";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Password_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_Header;
        public Label lblNamn;
        private TextBox tb_Password;
        private Label label_PasswordPassword;
        private TextBox tb_Name;
        private Label label_PasswordUser;
        private Label lbl_Abort;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label_PasswordInfo;
    }
}