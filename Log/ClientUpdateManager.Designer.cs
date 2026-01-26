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
            tlp_Main = new TableLayoutPanel();
            label_ProdLines = new Label();
            lb_AllUsers = new ListBox();
            label_AllUsers = new Label();
            label_Versions = new Label();
            label_BlockedClients = new Label();
            label_UsersOnClient = new Label();
            label_Clients = new Label();
            lb_Versions = new ListBox();
            lb_BlockedClients = new ListBox();
            chk_CheckAllClients = new CheckBox();
            btn_BlockClient = new Button();
            btn_UnBlockClient = new Button();
            chk_CheckAllBlockedClients = new CheckBox();
            tb_Filter = new TextBox();
            lv_UsersOnClient = new ListView();
            lb_ProdLines = new ListBox();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // lb_Clients
            // 
            lb_Clients.BackColor = SystemColors.Window;
            tlp_Main.SetColumnSpan(lb_Clients, 3);
            lb_Clients.Dock = DockStyle.Fill;
            lb_Clients.FormattingEnabled = true;
            lb_Clients.ItemHeight = 15;
            lb_Clients.Location = new Point(333, 73);
            lb_Clients.Name = "lb_Clients";
            lb_Clients.SelectionMode = SelectionMode.MultiExtended;
            lb_Clients.Size = new Size(298, 699);
            lb_Clients.TabIndex = 0;
            lb_Clients.SelectedIndexChanged += lb_Clients_SelectedIndexChanged;
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 9;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 83F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 124F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 97F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 218F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 136F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 87F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            tlp_Main.Controls.Add(label_ProdLines, 1, 0);
            tlp_Main.Controls.Add(lb_AllUsers, 0, 2);
            tlp_Main.Controls.Add(label_AllUsers, 0, 0);
            tlp_Main.Controls.Add(label_Versions, 6, 0);
            tlp_Main.Controls.Add(label_BlockedClients, 7, 0);
            tlp_Main.Controls.Add(label_UsersOnClient, 5, 0);
            tlp_Main.Controls.Add(lb_Clients, 2, 2);
            tlp_Main.Controls.Add(label_Clients, 2, 0);
            tlp_Main.Controls.Add(lb_Versions, 6, 2);
            tlp_Main.Controls.Add(lb_BlockedClients, 7, 2);
            tlp_Main.Controls.Add(chk_CheckAllClients, 2, 1);
            tlp_Main.Controls.Add(btn_BlockClient, 4, 1);
            tlp_Main.Controls.Add(btn_UnBlockClient, 8, 1);
            tlp_Main.Controls.Add(chk_CheckAllBlockedClients, 7, 1);
            tlp_Main.Controls.Add(tb_Filter, 3, 1);
            tlp_Main.Controls.Add(lv_UsersOnClient, 5, 2);
            tlp_Main.Controls.Add(lb_ProdLines, 1, 2);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 3;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(1665, 775);
            tlp_Main.TabIndex = 2;
            // 
            // label_ProdLines
            // 
            label_ProdLines.AutoSize = true;
            label_ProdLines.Dock = DockStyle.Fill;
            label_ProdLines.Font = new Font("Segoe UI", 14F);
            label_ProdLines.ForeColor = Color.FromArgb(239, 228, 177);
            label_ProdLines.Location = new Point(153, 0);
            label_ProdLines.Name = "label_ProdLines";
            label_ProdLines.Size = new Size(174, 40);
            label_ProdLines.TabIndex = 16;
            label_ProdLines.Text = "Production Lines";
            label_ProdLines.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb_AllUsers
            // 
            lb_AllUsers.Dock = DockStyle.Fill;
            lb_AllUsers.FormattingEnabled = true;
            lb_AllUsers.ItemHeight = 15;
            lb_AllUsers.Location = new Point(3, 73);
            lb_AllUsers.Name = "lb_AllUsers";
            lb_AllUsers.SelectionMode = SelectionMode.MultiSimple;
            lb_AllUsers.Size = new Size(144, 699);
            lb_AllUsers.TabIndex = 14;
            lb_AllUsers.SelectedIndexChanged += lb_AllUsers_SelectedIndexChanged;
            // 
            // label_AllUsers
            // 
            label_AllUsers.AutoSize = true;
            label_AllUsers.Dock = DockStyle.Fill;
            label_AllUsers.Font = new Font("Segoe UI", 14F);
            label_AllUsers.ForeColor = Color.FromArgb(239, 228, 177);
            label_AllUsers.Location = new Point(3, 0);
            label_AllUsers.Name = "label_AllUsers";
            label_AllUsers.Size = new Size(144, 40);
            label_AllUsers.TabIndex = 13;
            label_AllUsers.Text = "All Users";
            label_AllUsers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Versions
            // 
            label_Versions.AutoSize = true;
            label_Versions.Dock = DockStyle.Fill;
            label_Versions.Font = new Font("Segoe UI", 14F);
            label_Versions.ForeColor = Color.FromArgb(239, 228, 177);
            label_Versions.Location = new Point(855, 0);
            label_Versions.Name = "label_Versions";
            label_Versions.Size = new Size(130, 40);
            label_Versions.TabIndex = 11;
            label_Versions.Text = "Versions";
            label_Versions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_BlockedClients
            // 
            label_BlockedClients.AutoSize = true;
            tlp_Main.SetColumnSpan(label_BlockedClients, 2);
            label_BlockedClients.Dock = DockStyle.Fill;
            label_BlockedClients.Font = new Font("Segoe UI", 14F);
            label_BlockedClients.ForeColor = Color.FromArgb(239, 228, 177);
            label_BlockedClients.Location = new Point(991, 0);
            label_BlockedClients.Name = "label_BlockedClients";
            label_BlockedClients.Size = new Size(671, 40);
            label_BlockedClients.TabIndex = 10;
            label_BlockedClients.Text = "Blocked Clients";
            label_BlockedClients.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_UsersOnClient
            // 
            label_UsersOnClient.AutoSize = true;
            label_UsersOnClient.Dock = DockStyle.Fill;
            label_UsersOnClient.Font = new Font("Segoe UI", 14F);
            label_UsersOnClient.ForeColor = Color.FromArgb(239, 228, 177);
            label_UsersOnClient.Location = new Point(637, 0);
            label_UsersOnClient.Name = "label_UsersOnClient";
            label_UsersOnClient.Size = new Size(212, 40);
            label_UsersOnClient.TabIndex = 3;
            label_UsersOnClient.Text = "Users On Client";
            label_UsersOnClient.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Clients
            // 
            label_Clients.AutoSize = true;
            tlp_Main.SetColumnSpan(label_Clients, 3);
            label_Clients.Dock = DockStyle.Fill;
            label_Clients.Font = new Font("Segoe UI", 14F);
            label_Clients.ForeColor = Color.FromArgb(239, 228, 177);
            label_Clients.Location = new Point(333, 0);
            label_Clients.Name = "label_Clients";
            label_Clients.Size = new Size(298, 40);
            label_Clients.TabIndex = 2;
            label_Clients.Text = "All Clients";
            label_Clients.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb_Versions
            // 
            lb_Versions.Dock = DockStyle.Fill;
            lb_Versions.FormattingEnabled = true;
            lb_Versions.ItemHeight = 15;
            lb_Versions.Location = new Point(855, 73);
            lb_Versions.Name = "lb_Versions";
            lb_Versions.Size = new Size(130, 699);
            lb_Versions.TabIndex = 4;
            lb_Versions.SelectedIndexChanged += lb_Versions_SelectedIndexChanged;
            // 
            // lb_BlockedClients
            // 
            tlp_Main.SetColumnSpan(lb_BlockedClients, 2);
            lb_BlockedClients.Dock = DockStyle.Fill;
            lb_BlockedClients.FormattingEnabled = true;
            lb_BlockedClients.ItemHeight = 15;
            lb_BlockedClients.Location = new Point(991, 73);
            lb_BlockedClients.Name = "lb_BlockedClients";
            lb_BlockedClients.SelectionMode = SelectionMode.MultiSimple;
            lb_BlockedClients.Size = new Size(671, 699);
            lb_BlockedClients.TabIndex = 5;
            // 
            // chk_CheckAllClients
            // 
            chk_CheckAllClients.AutoSize = true;
            chk_CheckAllClients.ForeColor = Color.FromArgb(184, 220, 231);
            chk_CheckAllClients.Location = new Point(333, 43);
            chk_CheckAllClients.Name = "chk_CheckAllClients";
            chk_CheckAllClients.Size = new Size(76, 19);
            chk_CheckAllClients.TabIndex = 6;
            chk_CheckAllClients.Text = "Check All";
            chk_CheckAllClients.UseVisualStyleBackColor = true;
            chk_CheckAllClients.CheckedChanged += chk_CheckAll_CheckedChanged;
            // 
            // btn_BlockClient
            // 
            btn_BlockClient.BackColor = Color.FromArgb(255, 199, 206);
            btn_BlockClient.Dock = DockStyle.Fill;
            btn_BlockClient.FlatStyle = FlatStyle.Flat;
            btn_BlockClient.ForeColor = Color.FromArgb(156, 0, 6);
            btn_BlockClient.Location = new Point(540, 43);
            btn_BlockClient.Name = "btn_BlockClient";
            btn_BlockClient.Size = new Size(91, 24);
            btn_BlockClient.TabIndex = 7;
            btn_BlockClient.Text = "Block Client";
            btn_BlockClient.UseVisualStyleBackColor = false;
            btn_BlockClient.Click += btn_BlockClient_Click;
            // 
            // btn_UnBlockClient
            // 
            btn_UnBlockClient.BackColor = Color.FromArgb(198, 239, 206);
            btn_UnBlockClient.Dock = DockStyle.Left;
            btn_UnBlockClient.FlatStyle = FlatStyle.Flat;
            btn_UnBlockClient.ForeColor = Color.FromArgb(0, 97, 0);
            btn_UnBlockClient.Location = new Point(1078, 43);
            btn_UnBlockClient.Name = "btn_UnBlockClient";
            btn_UnBlockClient.Size = new Size(155, 24);
            btn_UnBlockClient.TabIndex = 8;
            btn_UnBlockClient.Text = "Unblock Client";
            btn_UnBlockClient.UseVisualStyleBackColor = false;
            btn_UnBlockClient.Click += btn_UnBlockClient_Click;
            // 
            // chk_CheckAllBlockedClients
            // 
            chk_CheckAllBlockedClients.AutoSize = true;
            chk_CheckAllBlockedClients.ForeColor = Color.FromArgb(184, 220, 231);
            chk_CheckAllBlockedClients.Location = new Point(991, 43);
            chk_CheckAllBlockedClients.Name = "chk_CheckAllBlockedClients";
            chk_CheckAllBlockedClients.Size = new Size(76, 19);
            chk_CheckAllBlockedClients.TabIndex = 9;
            chk_CheckAllBlockedClients.Text = "Check All";
            chk_CheckAllBlockedClients.UseVisualStyleBackColor = true;
            chk_CheckAllBlockedClients.CheckedChanged += chk_CheckAllBlockedClients_CheckedChanged;
            // 
            // tb_Filter
            // 
            tb_Filter.Dock = DockStyle.Fill;
            tb_Filter.Location = new Point(416, 43);
            tb_Filter.Name = "tb_Filter";
            tb_Filter.Size = new Size(118, 23);
            tb_Filter.TabIndex = 12;
            // 
            // lv_UsersOnClient
            // 
            lv_UsersOnClient.BackColor = Color.FromArgb(81, 85, 92);
            lv_UsersOnClient.Dock = DockStyle.Fill;
            lv_UsersOnClient.ForeColor = Color.FromArgb(147, 146, 153);
            lv_UsersOnClient.Location = new Point(637, 73);
            lv_UsersOnClient.MultiSelect = false;
            lv_UsersOnClient.Name = "lv_UsersOnClient";
            lv_UsersOnClient.Size = new Size(212, 699);
            lv_UsersOnClient.TabIndex = 15;
            lv_UsersOnClient.UseCompatibleStateImageBehavior = false;
            // 
            // lb_ProdLines
            // 
            lb_ProdLines.Dock = DockStyle.Fill;
            lb_ProdLines.FormattingEnabled = true;
            lb_ProdLines.ItemHeight = 15;
            lb_ProdLines.Location = new Point(153, 73);
            lb_ProdLines.Name = "lb_ProdLines";
            lb_ProdLines.SelectionMode = SelectionMode.MultiSimple;
            lb_ProdLines.Size = new Size(174, 699);
            lb_ProdLines.TabIndex = 17;
            lb_ProdLines.SelectedIndexChanged += lb_ProdLines_SelectedIndexChanged;
            // 
            // ClientUpdateManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1665, 775);
            Controls.Add(tlp_Main);
            Name = "ClientUpdateManager";
            Text = "ClientUpdateManager";
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lb_Clients;
        private TableLayoutPanel tlp_Main;
        private Label label_UsersOnClient;
        private Label label_Clients;
        private ListBox lb_Versions;
        private ListBox lb_BlockedClients;
        private CheckBox chk_CheckAllClients;
        private Button btn_BlockClient;
        private Button btn_UnBlockClient;
        private Label label_BlockedClients;
        private CheckBox chk_CheckAllBlockedClients;
        private Label label_Versions;
        private TextBox tb_Filter;
        private ListBox lb_AllUsers;
        private Label label_AllUsers;
        private ListView lv_UsersOnClient;
        private Label label_ProdLines;
        private ListBox lb_ProdLines;
    }
}