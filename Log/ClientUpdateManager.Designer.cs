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
            lv_AllowedClients = new DigitalProductionProgram.ControlsManagement.BufferedListView();
            tlp_Main = new TableLayoutPanel();
            label_ProdLines = new Label();
            lb_AllUsers = new DigitalProductionProgram.ControlsManagement.BufferedListBox();
            label_AllUsers = new Label();
            label_Versions = new Label();
            label_BlockedClients = new Label();
            label_UsersOnClient = new Label();
            label_AllowedClients = new Label();
            lb_Versions = new DigitalProductionProgram.ControlsManagement.BufferedListBox();
            lv_BlockedClients = new DigitalProductionProgram.ControlsManagement.BufferedListView();
            chk_CheckAllClients = new CheckBox();
            btn_BlockClient = new Button();
            btn_UnBlockClient = new Button();
            chk_CheckAllBlockedClients = new CheckBox();
            tb_FilterAllClients = new TextBox();
            lv_UsersOnClient = new DigitalProductionProgram.ControlsManagement.BufferedListView();
            label_ProdLinesOnClient = new Label();
            lv_ProdLinesOnClient = new DigitalProductionProgram.ControlsManagement.BufferedListView();
            lb_ProdLines = new DigitalProductionProgram.ControlsManagement.BufferedListBox();
            label_FilterClients = new Label();
            tb_FilterBlockedClients = new TextBox();
            tb_FilterUsersProdLines = new TextBox();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // lv_AllowedClients
            // 
            lv_AllowedClients.BackColor = SystemColors.Window;
            tlp_Main.SetColumnSpan(lv_AllowedClients, 3);
            lv_AllowedClients.Dock = DockStyle.Fill;
            lv_AllowedClients.FullRowSelect = true;
            lv_AllowedClients.Location = new Point(843, 103);
            lv_AllowedClients.Name = "lv_AllowedClients";
            lv_AllowedClients.Size = new Size(404, 699);
            lv_AllowedClients.TabIndex = 0;
            lv_AllowedClients.UseCompatibleStateImageBehavior = false;
            lv_AllowedClients.View = View.Details;
            lv_AllowedClients.SelectedIndexChanged += lb_Clients_SelectedIndexChanged;
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 13;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 230F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 113F));
            tlp_Main.Controls.Add(label_ProdLines, 1, 1);
            tlp_Main.Controls.Add(lb_AllUsers, 0, 3);
            tlp_Main.Controls.Add(label_AllUsers, 0, 1);
            tlp_Main.Controls.Add(label_Versions, 9, 1);
            tlp_Main.Controls.Add(label_BlockedClients, 8, 1);
            tlp_Main.Controls.Add(label_UsersOnClient, 2, 1);
            tlp_Main.Controls.Add(lv_AllowedClients, 4, 3);
            tlp_Main.Controls.Add(label_AllowedClients, 4, 1);
            tlp_Main.Controls.Add(lb_Versions, 9, 3);
            tlp_Main.Controls.Add(lv_BlockedClients, 8, 3);
            tlp_Main.Controls.Add(chk_CheckAllClients, 4, 2);
            tlp_Main.Controls.Add(btn_BlockClient, 6, 2);
            tlp_Main.Controls.Add(btn_UnBlockClient, 10, 2);
            tlp_Main.Controls.Add(chk_CheckAllBlockedClients, 8, 2);
            tlp_Main.Controls.Add(tb_FilterAllClients, 5, 2);
            tlp_Main.Controls.Add(lv_UsersOnClient, 2, 3);
            tlp_Main.Controls.Add(label_ProdLinesOnClient, 3, 1);
            tlp_Main.Controls.Add(lv_ProdLinesOnClient, 3, 3);
            tlp_Main.Controls.Add(lb_ProdLines, 1, 3);
            tlp_Main.Controls.Add(label_FilterClients, 0, 0);
            tlp_Main.Controls.Add(tb_FilterBlockedClients, 9, 2);
            tlp_Main.Controls.Add(tb_FilterUsersProdLines, 0, 2);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 4;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(1974, 805);
            tlp_Main.TabIndex = 2;
            // 
            // label_ProdLines
            // 
            label_ProdLines.AutoSize = true;
            label_ProdLines.Dock = DockStyle.Fill;
            label_ProdLines.Font = new Font("Segoe UI", 14F);
            label_ProdLines.ForeColor = Color.FromArgb(239, 228, 177);
            label_ProdLines.Location = new Point(153, 30);
            label_ProdLines.Name = "label_ProdLines";
            label_ProdLines.Size = new Size(174, 40);
            label_ProdLines.TabIndex = 16;
            label_ProdLines.Text = "Production Lines";
            label_ProdLines.TextAlign = ContentAlignment.MiddleCenter;
            label_ProdLines.Click += label_ProdLines_Click;
            // 
            // lb_AllUsers
            // 
            lb_AllUsers.Dock = DockStyle.Fill;
            lb_AllUsers.DrawMode = DrawMode.OwnerDrawFixed;
            lb_AllUsers.FormattingEnabled = true;
            lb_AllUsers.ItemHeight = 15;
            lb_AllUsers.Location = new Point(3, 103);
            lb_AllUsers.Name = "lb_AllUsers";
            lb_AllUsers.SelectionMode = SelectionMode.MultiExtended;
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
            label_AllUsers.Location = new Point(3, 30);
            label_AllUsers.Name = "label_AllUsers";
            label_AllUsers.Size = new Size(144, 40);
            label_AllUsers.TabIndex = 13;
            label_AllUsers.Text = "All Users";
            label_AllUsers.TextAlign = ContentAlignment.MiddleCenter;
            label_AllUsers.Click += label_AllUsers_Click;
            // 
            // label_Versions
            // 
            label_Versions.AutoSize = true;
            label_Versions.Dock = DockStyle.Fill;
            label_Versions.Font = new Font("Segoe UI", 14F);
            label_Versions.ForeColor = Color.FromArgb(239, 228, 177);
            label_Versions.Location = new Point(1703, 30);
            label_Versions.Name = "label_Versions";
            label_Versions.Size = new Size(214, 40);
            label_Versions.TabIndex = 11;
            label_Versions.Text = "Versions";
            label_Versions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_BlockedClients
            // 
            label_BlockedClients.AutoSize = true;
            tlp_Main.SetColumnSpan(label_BlockedClients, 3);
            label_BlockedClients.Dock = DockStyle.Fill;
            label_BlockedClients.Font = new Font("Segoe UI", 14F);
            label_BlockedClients.ForeColor = Color.FromArgb(239, 228, 177);
            label_BlockedClients.Location = new Point(1293, 30);
            label_BlockedClients.Name = "label_BlockedClients";
            label_BlockedClients.Size = new Size(404, 40);
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
            label_UsersOnClient.Location = new Point(333, 30);
            label_UsersOnClient.Name = "label_UsersOnClient";
            label_UsersOnClient.Size = new Size(224, 40);
            label_UsersOnClient.TabIndex = 3;
            label_UsersOnClient.Text = "Users On Client";
            label_UsersOnClient.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_AllowedClients
            // 
            label_AllowedClients.AutoSize = true;
            tlp_Main.SetColumnSpan(label_AllowedClients, 3);
            label_AllowedClients.Dock = DockStyle.Fill;
            label_AllowedClients.Font = new Font("Segoe UI", 14F);
            label_AllowedClients.ForeColor = Color.FromArgb(239, 228, 177);
            label_AllowedClients.Location = new Point(843, 30);
            label_AllowedClients.Name = "label_AllowedClients";
            label_AllowedClients.Size = new Size(404, 40);
            label_AllowedClients.TabIndex = 2;
            label_AllowedClients.Text = "Allowed Clients";
            label_AllowedClients.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb_Versions
            // 
            lb_Versions.Dock = DockStyle.Fill;
            lb_Versions.DrawMode = DrawMode.OwnerDrawFixed;
            lb_Versions.FormattingEnabled = true;
            lb_Versions.ItemHeight = 15;
            lb_Versions.Location = new Point(1703, 103);
            lb_Versions.Name = "lb_Versions";
            lb_Versions.Size = new Size(214, 699);
            lb_Versions.TabIndex = 4;
            lb_Versions.SelectedIndexChanged += lb_Versions_SelectedIndexChanged;
            // 
            // lv_BlockedClients
            // 
            tlp_Main.SetColumnSpan(lv_BlockedClients, 3);
            lv_BlockedClients.Dock = DockStyle.Fill;
            lv_BlockedClients.FullRowSelect = true;
            lv_BlockedClients.Location = new Point(1293, 103);
            lv_BlockedClients.Name = "lv_BlockedClients";
            lv_BlockedClients.Size = new Size(404, 699);
            lv_BlockedClients.TabIndex = 5;
            lv_BlockedClients.UseCompatibleStateImageBehavior = false;
            lv_BlockedClients.View = View.Details;
            lv_BlockedClients.SelectedIndexChanged += lb_BlockedClients_SelectedIndexChanged;
            // 
            // chk_CheckAllClients
            // 
            chk_CheckAllClients.AutoSize = true;
            chk_CheckAllClients.ForeColor = Color.FromArgb(184, 220, 231);
            chk_CheckAllClients.Location = new Point(843, 73);
            chk_CheckAllClients.Name = "chk_CheckAllClients";
            chk_CheckAllClients.Size = new Size(76, 19);
            chk_CheckAllClients.TabIndex = 6;
            chk_CheckAllClients.Text = "Check All";
            chk_CheckAllClients.UseVisualStyleBackColor = true;
            chk_CheckAllClients.CheckedChanged += chk_CheckAllClients_CheckedChanged;
            // 
            // btn_BlockClient
            // 
            btn_BlockClient.BackColor = Color.FromArgb(255, 199, 206);
            btn_BlockClient.Dock = DockStyle.Fill;
            btn_BlockClient.FlatStyle = FlatStyle.Flat;
            btn_BlockClient.ForeColor = Color.FromArgb(156, 0, 6);
            btn_BlockClient.Location = new Point(1103, 73);
            btn_BlockClient.Name = "btn_BlockClient";
            btn_BlockClient.Size = new Size(144, 24);
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
            btn_UnBlockClient.Location = new Point(1553, 73);
            btn_UnBlockClient.Name = "btn_UnBlockClient";
            btn_UnBlockClient.Size = new Size(144, 24);
            btn_UnBlockClient.TabIndex = 8;
            btn_UnBlockClient.Text = "Unblock Client";
            btn_UnBlockClient.UseVisualStyleBackColor = false;
            btn_UnBlockClient.Click += btn_UnBlockClient_Click;
            // 
            // chk_CheckAllBlockedClients
            // 
            chk_CheckAllBlockedClients.AutoSize = true;
            chk_CheckAllBlockedClients.ForeColor = Color.FromArgb(184, 220, 231);
            chk_CheckAllBlockedClients.Location = new Point(1293, 73);
            chk_CheckAllBlockedClients.Name = "chk_CheckAllBlockedClients";
            chk_CheckAllBlockedClients.Size = new Size(76, 19);
            chk_CheckAllBlockedClients.TabIndex = 9;
            chk_CheckAllBlockedClients.Text = "Check All";
            chk_CheckAllBlockedClients.UseVisualStyleBackColor = true;
            chk_CheckAllBlockedClients.CheckedChanged += chk_CheckAllBlockedClients_CheckedChanged;
            // 
            // tb_FilterAllClients
            // 
            tb_FilterAllClients.Dock = DockStyle.Fill;
            tb_FilterAllClients.Location = new Point(953, 73);
            tb_FilterAllClients.Name = "tb_FilterAllClients";
            tb_FilterAllClients.Size = new Size(144, 23);
            tb_FilterAllClients.TabIndex = 12;
            // 
            // lv_UsersOnClient
            // 
            lv_UsersOnClient.BackColor = Color.FromArgb(81, 85, 92);
            lv_UsersOnClient.Dock = DockStyle.Fill;
            lv_UsersOnClient.ForeColor = Color.FromArgb(147, 146, 153);
            lv_UsersOnClient.Location = new Point(333, 103);
            lv_UsersOnClient.MultiSelect = false;
            lv_UsersOnClient.Name = "lv_UsersOnClient";
            lv_UsersOnClient.Size = new Size(224, 699);
            lv_UsersOnClient.TabIndex = 15;
            lv_UsersOnClient.UseCompatibleStateImageBehavior = false;
            // 
            // label_ProdLinesOnClient
            // 
            label_ProdLinesOnClient.AutoSize = true;
            label_ProdLinesOnClient.Dock = DockStyle.Fill;
            label_ProdLinesOnClient.Font = new Font("Segoe UI", 14F);
            label_ProdLinesOnClient.ForeColor = Color.FromArgb(239, 228, 177);
            label_ProdLinesOnClient.Location = new Point(563, 30);
            label_ProdLinesOnClient.Name = "label_ProdLinesOnClient";
            label_ProdLinesOnClient.Size = new Size(274, 40);
            label_ProdLinesOnClient.TabIndex = 21;
            label_ProdLinesOnClient.Text = "Lines On Client";
            label_ProdLinesOnClient.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lv_ProdLinesOnClient
            // 
            lv_ProdLinesOnClient.BackColor = Color.FromArgb(81, 85, 92);
            lv_ProdLinesOnClient.Dock = DockStyle.Fill;
            lv_ProdLinesOnClient.ForeColor = Color.FromArgb(147, 146, 153);
            lv_ProdLinesOnClient.Location = new Point(563, 103);
            lv_ProdLinesOnClient.MultiSelect = false;
            lv_ProdLinesOnClient.Name = "lv_ProdLinesOnClient";
            lv_ProdLinesOnClient.Size = new Size(274, 699);
            lv_ProdLinesOnClient.TabIndex = 22;
            lv_ProdLinesOnClient.UseCompatibleStateImageBehavior = false;
            // 
            // lb_ProdLines
            // 
            lb_ProdLines.Dock = DockStyle.Fill;
            lb_ProdLines.DrawMode = DrawMode.OwnerDrawFixed;
            lb_ProdLines.FormattingEnabled = true;
            lb_ProdLines.ItemHeight = 15;
            lb_ProdLines.Location = new Point(153, 103);
            lb_ProdLines.Name = "lb_ProdLines";
            lb_ProdLines.SelectionMode = SelectionMode.MultiExtended;
            lb_ProdLines.Size = new Size(174, 699);
            lb_ProdLines.TabIndex = 17;
            lb_ProdLines.SelectedIndexChanged += lb_ProdLines_SelectedIndexChanged;
            // 
            // label_FilterClients
            // 
            label_FilterClients.AutoSize = true;
            tlp_Main.SetColumnSpan(label_FilterClients, 2);
            label_FilterClients.Dock = DockStyle.Fill;
            label_FilterClients.Font = new Font("Segoe UI", 20F);
            label_FilterClients.ForeColor = Color.FromArgb(147, 146, 153);
            label_FilterClients.Location = new Point(3, 0);
            label_FilterClients.Name = "label_FilterClients";
            label_FilterClients.Size = new Size(324, 30);
            label_FilterClients.TabIndex = 18;
            label_FilterClients.Text = "Filter Users / Lines";
            label_FilterClients.TextAlign = ContentAlignment.BottomCenter;
            // 
            // tb_FilterBlockedClients
            // 
            tb_FilterBlockedClients.Location = new Point(1403, 73);
            tb_FilterBlockedClients.Name = "tb_FilterBlockedClients";
            tb_FilterBlockedClients.Size = new Size(99, 23);
            tb_FilterBlockedClients.TabIndex = 19;
            // 
            // tb_FilterUsersProdLines
            // 
            tlp_Main.SetColumnSpan(tb_FilterUsersProdLines, 2);
            tb_FilterUsersProdLines.Dock = DockStyle.Fill;
            tb_FilterUsersProdLines.Location = new Point(3, 73);
            tb_FilterUsersProdLines.Name = "tb_FilterUsersProdLines";
            tb_FilterUsersProdLines.PlaceholderText = "Filter user or production line";
            tb_FilterUsersProdLines.Size = new Size(324, 23);
            tb_FilterUsersProdLines.TabIndex = 20;
            // 
            // ClientUpdateManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1974, 805);
            Controls.Add(tlp_Main);
            Name = "ClientUpdateManager";
            Text = "ClientUpdateManager";
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DigitalProductionProgram.ControlsManagement.BufferedListView lv_AllowedClients;
        private TableLayoutPanel tlp_Main;
        private Label label_UsersOnClient;
        private Label label_AllowedClients;
        private DigitalProductionProgram.ControlsManagement.BufferedListBox lb_Versions;
        private DigitalProductionProgram.ControlsManagement.BufferedListView lv_BlockedClients;
        private CheckBox chk_CheckAllClients;
        private Button btn_BlockClient;
        private Button btn_UnBlockClient;
        private Label label_BlockedClients;
        private CheckBox chk_CheckAllBlockedClients;
        private Label label_Versions;
        private TextBox tb_FilterAllClients;
        private DigitalProductionProgram.ControlsManagement.BufferedListBox lb_AllUsers;
        private Label label_AllUsers;
        private DigitalProductionProgram.ControlsManagement.BufferedListView lv_UsersOnClient;
        private Label label_ProdLinesOnClient;
        private DigitalProductionProgram.ControlsManagement.BufferedListView lv_ProdLinesOnClient;
        private Label label_ProdLines;
        private DigitalProductionProgram.ControlsManagement.BufferedListBox lb_ProdLines;
        private Label label_FilterClients;
        private TextBox tb_FilterBlockedClients;
        private TextBox tb_FilterUsersProdLines;
    }
}
