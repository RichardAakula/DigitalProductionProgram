﻿namespace DigitalProductionProgram.MainWindow
{
    partial class LoggedInUsers
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
            Main_Calendar = new MonitorUsers();
            timer_UpdateUsers = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // Main_Calendar
            // 
            Main_Calendar.BackColor = Color.Transparent;
            Main_Calendar.Dock = DockStyle.Fill;
            Main_Calendar.Location = new Point(0, 0);
            Main_Calendar.Margin = new Padding(0);
            Main_Calendar.Name = "Main_Calendar";
            Main_Calendar.Size = new Size(1210, 818);
            Main_Calendar.TabIndex = 0;
            // 
            // timer_UpdateUsers
            // 
            timer_UpdateUsers.Interval = 60000;
            timer_UpdateUsers.Tick += Timer_UpdateUsers_Tick;
            // 
            // LoggedInUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1210, 818);
            Controls.Add(Main_Calendar);
            Margin = new Padding(4, 3, 4, 3);
            Name = "LoggedInUsers";
            Text = "Logged In Users";
            FormClosed += LoggedInUsers_FormClosed;
            ResumeLayout(false);

        }

        #endregion

        private MonitorUsers Main_Calendar;
        private System.Windows.Forms.Timer timer_UpdateUsers;
    }
}