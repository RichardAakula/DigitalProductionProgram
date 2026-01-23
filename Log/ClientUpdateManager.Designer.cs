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
            tlp_Main = new TableLayoutPanel();
            label1 = new Label();
            label_Users = new Label();
            label_Clients = new Label();
            lb_Versions = new ListBox();
            lb_BlockedClients = new ListBox();
            chk_CheckAllClients = new CheckBox();
            btn_BlockClient = new Button();
            btn_UnBlockClient = new Button();
            chk_CheckAllBlockedClients = new CheckBox();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // lb_Clients
            // 
            tlp_Main.SetColumnSpan(lb_Clients, 2);
            lb_Clients.Dock = DockStyle.Fill;
            lb_Clients.FormattingEnabled = true;
            lb_Clients.ItemHeight = 15;
            lb_Clients.Location = new Point(3, 73);
            lb_Clients.Name = "lb_Clients";
            lb_Clients.SelectionMode = SelectionMode.MultiSimple;
            lb_Clients.Size = new Size(278, 699);
            lb_Clients.TabIndex = 0;
            lb_Clients.SelectedIndexChanged += lb_Clients_SelectedIndexChanged;
            // 
            // lb_Users
            // 
            lb_Users.Dock = DockStyle.Fill;
            lb_Users.FormattingEnabled = true;
            lb_Users.ItemHeight = 15;
            lb_Users.Location = new Point(287, 73);
            lb_Users.Name = "lb_Users";
            lb_Users.SelectionMode = SelectionMode.None;
            lb_Users.Size = new Size(223, 699);
            lb_Users.TabIndex = 1;
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 6;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 123F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 161F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 229F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 154F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 106F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 122F));
            tlp_Main.Controls.Add(label1, 4, 0);
            tlp_Main.Controls.Add(label_Users, 2, 0);
            tlp_Main.Controls.Add(lb_Clients, 0, 2);
            tlp_Main.Controls.Add(lb_Users, 2, 2);
            tlp_Main.Controls.Add(label_Clients, 0, 0);
            tlp_Main.Controls.Add(lb_Versions, 3, 2);
            tlp_Main.Controls.Add(lb_BlockedClients, 4, 2);
            tlp_Main.Controls.Add(chk_CheckAllClients, 0, 1);
            tlp_Main.Controls.Add(btn_BlockClient, 1, 1);
            tlp_Main.Controls.Add(btn_UnBlockClient, 5, 1);
            tlp_Main.Controls.Add(chk_CheckAllBlockedClients, 4, 1);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 3;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(1364, 775);
            tlp_Main.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tlp_Main.SetColumnSpan(label1, 2);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 14F);
            label1.ForeColor = Color.FromArgb(239, 228, 177);
            label1.Location = new Point(670, 0);
            label1.Name = "label1";
            label1.Size = new Size(691, 40);
            label1.TabIndex = 10;
            label1.Text = "Alla Klienter";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Users
            // 
            label_Users.AutoSize = true;
            label_Users.Dock = DockStyle.Fill;
            label_Users.Font = new Font("Segoe UI", 14F);
            label_Users.ForeColor = Color.FromArgb(239, 228, 177);
            label_Users.Location = new Point(287, 0);
            label_Users.Name = "label_Users";
            label_Users.Size = new Size(223, 40);
            label_Users.TabIndex = 3;
            label_Users.Text = "Användare";
            label_Users.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Clients
            // 
            label_Clients.AutoSize = true;
            tlp_Main.SetColumnSpan(label_Clients, 2);
            label_Clients.Dock = DockStyle.Fill;
            label_Clients.Font = new Font("Segoe UI", 14F);
            label_Clients.ForeColor = Color.FromArgb(239, 228, 177);
            label_Clients.Location = new Point(3, 0);
            label_Clients.Name = "label_Clients";
            label_Clients.Size = new Size(278, 40);
            label_Clients.TabIndex = 2;
            label_Clients.Text = "Alla Klienter";
            label_Clients.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb_Versions
            // 
            lb_Versions.Dock = DockStyle.Fill;
            lb_Versions.FormattingEnabled = true;
            lb_Versions.ItemHeight = 15;
            lb_Versions.Location = new Point(516, 73);
            lb_Versions.Name = "lb_Versions";
            lb_Versions.Size = new Size(148, 699);
            lb_Versions.TabIndex = 4;
            lb_Versions.SelectedIndexChanged += lb_Versions_SelectedIndexChanged;
            // 
            // lb_BlockedClients
            // 
            tlp_Main.SetColumnSpan(lb_BlockedClients, 2);
            lb_BlockedClients.Dock = DockStyle.Fill;
            lb_BlockedClients.FormattingEnabled = true;
            lb_BlockedClients.ItemHeight = 15;
            lb_BlockedClients.Location = new Point(670, 73);
            lb_BlockedClients.Name = "lb_BlockedClients";
            lb_BlockedClients.SelectionMode = SelectionMode.MultiSimple;
            lb_BlockedClients.Size = new Size(691, 699);
            lb_BlockedClients.TabIndex = 5;
            // 
            // chk_CheckAllClients
            // 
            chk_CheckAllClients.AutoSize = true;
            chk_CheckAllClients.ForeColor = Color.FromArgb(184, 220, 231);
            chk_CheckAllClients.Location = new Point(3, 43);
            chk_CheckAllClients.Name = "chk_CheckAllClients";
            chk_CheckAllClients.Size = new Size(92, 19);
            chk_CheckAllClients.TabIndex = 6;
            chk_CheckAllClients.Text = "Markera Alla";
            chk_CheckAllClients.UseVisualStyleBackColor = true;
            chk_CheckAllClients.CheckedChanged += chk_CheckAll_CheckedChanged;
            // 
            // btn_BlockClient
            // 
            btn_BlockClient.BackColor = Color.FromArgb(255, 199, 206);
            btn_BlockClient.Dock = DockStyle.Fill;
            btn_BlockClient.FlatStyle = FlatStyle.Flat;
            btn_BlockClient.ForeColor = Color.FromArgb(156, 0, 6);
            btn_BlockClient.Location = new Point(126, 43);
            btn_BlockClient.Name = "btn_BlockClient";
            btn_BlockClient.Size = new Size(155, 24);
            btn_BlockClient.TabIndex = 7;
            btn_BlockClient.Text = "Blockera Klient";
            btn_BlockClient.UseVisualStyleBackColor = false;
            btn_BlockClient.Click += btn_BlockClient_Click;
            // 
            // btn_UnBlockClient
            // 
            btn_UnBlockClient.BackColor = Color.FromArgb(198, 239, 206);
            btn_UnBlockClient.Dock = DockStyle.Left;
            btn_UnBlockClient.FlatStyle = FlatStyle.Flat;
            btn_UnBlockClient.ForeColor = Color.FromArgb(0, 97, 0);
            btn_UnBlockClient.Location = new Point(776, 43);
            btn_UnBlockClient.Name = "btn_UnBlockClient";
            btn_UnBlockClient.Size = new Size(155, 24);
            btn_UnBlockClient.TabIndex = 8;
            btn_UnBlockClient.Text = "Avblockera Klient";
            btn_UnBlockClient.UseVisualStyleBackColor = false;
            btn_UnBlockClient.Click += btn_UnBlockClient_Click;
            // 
            // chk_CheckAllBlockedClients
            // 
            chk_CheckAllBlockedClients.AutoSize = true;
            chk_CheckAllBlockedClients.ForeColor = Color.FromArgb(184, 220, 231);
            chk_CheckAllBlockedClients.Location = new Point(670, 43);
            chk_CheckAllBlockedClients.Name = "chk_CheckAllBlockedClients";
            chk_CheckAllBlockedClients.Size = new Size(92, 19);
            chk_CheckAllBlockedClients.TabIndex = 9;
            chk_CheckAllBlockedClients.Text = "Markera Alla";
            chk_CheckAllBlockedClients.UseVisualStyleBackColor = true;
            chk_CheckAllBlockedClients.CheckedChanged += chk_CheckAllBlockedClients_CheckedChanged;
            // 
            // ClientUpdateManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1364, 775);
            Controls.Add(tlp_Main);
            Name = "ClientUpdateManager";
            Text = "ClientUpdateManager";
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lb_Clients;
        private ListBox lb_Users;
        private TableLayoutPanel tlp_Main;
        private Label label_Users;
        private Label label_Clients;
        private ListBox lb_Versions;
        private ListBox lb_BlockedClients;
        private CheckBox chk_CheckAllClients;
        private Button btn_BlockClient;
        private Button btn_UnBlockClient;
        private Label label1;
        private CheckBox chk_CheckAllBlockedClients;
    }
}