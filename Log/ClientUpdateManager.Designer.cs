namespace DigitalProductionProgram.Log
{
    partial class ClientUpdateManager
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
            lb_Clients = new ListBox();
            lb_Users = new ListBox();
            SuspendLayout();
            // 
            // lb_Clients
            // 
            lb_Clients.Dock = DockStyle.Left;
            lb_Clients.FormattingEnabled = true;
            lb_Clients.ItemHeight = 15;
            lb_Clients.Location = new Point(0, 0);
            lb_Clients.Name = "lb_Clients";
            lb_Clients.SelectionMode = SelectionMode.MultiExtended;
            lb_Clients.Size = new Size(273, 775);
            lb_Clients.TabIndex = 0;
            lb_Clients.SelectedIndexChanged += lb_Clients_SelectedIndexChanged;
            // 
            // lb_Users
            // 
            lb_Users.FormattingEnabled = true;
            lb_Users.ItemHeight = 15;
            lb_Users.Location = new Point(293, 0);
            lb_Users.Name = "lb_Users";
            lb_Users.SelectionMode = SelectionMode.MultiExtended;
            lb_Users.Size = new Size(232, 364);
            lb_Users.TabIndex = 1;
            // 
            // ClientUpdateManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1364, 775);
            Controls.Add(lb_Users);
            Controls.Add(lb_Clients);
            Name = "ClientUpdateManager";
            Text = "ClientUpdateManager";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lb_Clients;
        private ListBox lb_Users;
    }
}