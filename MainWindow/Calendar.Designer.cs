namespace DigitalProductionProgram.MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.Main_Calendar = new DigitalProductionProgram.MainWindow.MonitorUsers();
            this.timer_UpdateUsers = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Main_Calendar
            // 
            this.Main_Calendar.BackColor = System.Drawing.Color.Transparent;
            this.Main_Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Calendar.Location = new System.Drawing.Point(0, 0);
            this.Main_Calendar.Margin = new System.Windows.Forms.Padding(0);
            this.Main_Calendar.Name = "Main_Calendar";
            this.Main_Calendar.Size = new System.Drawing.Size(1037, 709);
            this.Main_Calendar.TabIndex = 0;
            // 
            // timer_UpdateUsers
            // 
            this.timer_UpdateUsers.Interval = 60000;
            this.timer_UpdateUsers.Tick += new System.EventHandler(this.Timer_UpdateUsers_Tick);
            // 
            // LoggedInUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 709);
            this.Controls.Add(this.Main_Calendar);
            this.Name = "LoggedInUsers";
            this.Text = "Logged In Users";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoggedInUsers_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private MonitorUsers Main_Calendar;
        private System.Windows.Forms.Timer timer_UpdateUsers;
    }
}