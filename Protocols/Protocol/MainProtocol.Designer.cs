using DigitalProductionProgram.Protocols.ExtraProtocols;

namespace DigitalProductionProgram.Protocols.Protocol
{
    partial class MainProtocol
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
            tlp_Main = new TableLayoutPanel();
            panel_LineClearance = new Panel();
            Line_Clearance = new DigitalProductionProgram.Protocols.LineClearance.LineClearance();
            tlp_Right = new TableLayoutPanel();
            Comments = new Comments();
            flp_Buttons = new FlowLayoutPanel();
            btn_AddStartUp = new Button();
            btn_RemoveStartUp = new Button();
            btn_Add_Oven = new Button();
            btn_RemoveOven = new Button();
            btn_Confirm_Equipment = new Button();
            btn_Edit_Equipment = new Button();
            btn_ExtraComments = new Button();
            ProcesscardBasedOn = new DigitalProductionProgram.Processcards.ProcesscardBasedOn();
            PreFab = new PreFab();
            panel_MainInfo = new Panel();
            flp_Machines = new FlowLayoutPanel();
            tlp_Main.SuspendLayout();
            panel_LineClearance.SuspendLayout();
            tlp_Right.SuspendLayout();
            flp_Buttons.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            tlp_Main.Controls.Add(panel_LineClearance, 0, 1);
            tlp_Main.Controls.Add(tlp_Right, 1, 2);
            tlp_Main.Controls.Add(panel_MainInfo, 0, 0);
            tlp_Main.Controls.Add(flp_Machines, 0, 2);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 3;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(2637, 1224);
            tlp_Main.TabIndex = 2;
            // 
            // panel_LineClearance
            // 
            panel_LineClearance.BackColor = Color.Black;
            tlp_Main.SetColumnSpan(panel_LineClearance, 2);
            panel_LineClearance.Controls.Add(Line_Clearance);
            panel_LineClearance.Dock = DockStyle.Fill;
            panel_LineClearance.Location = new Point(0, 68);
            panel_LineClearance.Margin = new Padding(0);
            panel_LineClearance.Name = "panel_LineClearance";
            panel_LineClearance.Size = new Size(2637, 75);
            panel_LineClearance.TabIndex = 905;
            // 
            // Line_Clearance
            // 
            Line_Clearance.Dock = DockStyle.Fill;
            Line_Clearance.Location = new Point(0, 0);
            Line_Clearance.Margin = new Padding(0);
            Line_Clearance.Name = "Line_Clearance";
            Line_Clearance.Size = new Size(2637, 75);
            Line_Clearance.TabIndex = 0;
            // 
            // tlp_Right
            // 
            tlp_Right.BackColor = Color.FromArgb(57, 108, 121);
            tlp_Right.ColumnCount = 1;
            tlp_Right.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Right.Controls.Add(Comments, 0, 4);
            tlp_Right.Controls.Add(flp_Buttons, 0, 0);
            tlp_Right.Controls.Add(btn_ExtraComments, 0, 3);
            tlp_Right.Controls.Add(ProcesscardBasedOn, 0, 2);
            tlp_Right.Controls.Add(PreFab, 0, 1);
            tlp_Right.Dock = DockStyle.Fill;
            tlp_Right.Location = new Point(2193, 143);
            tlp_Right.Margin = new Padding(6, 0, 0, 0);
            tlp_Right.Name = "tlp_Right";
            tlp_Right.RowCount = 5;
            tlp_Right.RowStyles.Add(new RowStyle(SizeType.Absolute, 323F));
            tlp_Right.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tlp_Right.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlp_Right.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlp_Right.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Right.Size = new Size(444, 1081);
            tlp_Right.TabIndex = 2;
            // 
            // Comments
            // 
            Comments.Dock = DockStyle.Fill;
            Comments.Location = new Point(1, 537);
            Comments.Margin = new Padding(1, 0, 0, 1);
            Comments.Name = "Comments";
            Comments.Size = new Size(443, 543);
            Comments.TabIndex = 1;
            // 
            // flp_Buttons
            // 
            flp_Buttons.BackColor = Color.FromArgb(57, 108, 121);
            flp_Buttons.Controls.Add(btn_AddStartUp);
            flp_Buttons.Controls.Add(btn_RemoveStartUp);
            flp_Buttons.Controls.Add(btn_Add_Oven);
            flp_Buttons.Controls.Add(btn_RemoveOven);
            flp_Buttons.Controls.Add(btn_Confirm_Equipment);
            flp_Buttons.Controls.Add(btn_Edit_Equipment);
            flp_Buttons.Dock = DockStyle.Fill;
            flp_Buttons.FlowDirection = FlowDirection.TopDown;
            flp_Buttons.Location = new Point(0, 0);
            flp_Buttons.Margin = new Padding(0, 0, 0, 1);
            flp_Buttons.Name = "flp_Buttons";
            flp_Buttons.Size = new Size(444, 322);
            flp_Buttons.TabIndex = 2;
            // 
            // btn_AddStartUp
            // 
            btn_AddStartUp.BackColor = Color.FromArgb(25, 25, 25);
            btn_AddStartUp.Cursor = Cursors.Hand;
            btn_AddStartUp.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 75, 75);
            btn_AddStartUp.FlatStyle = FlatStyle.Flat;
            btn_AddStartUp.Font = new Font("Consolas", 10F);
            btn_AddStartUp.ForeColor = Color.FromArgb(198, 239, 206);
            btn_AddStartUp.Location = new Point(2, 1);
            btn_AddStartUp.Margin = new Padding(2, 1, 0, 0);
            btn_AddStartUp.Name = "btn_AddStartUp";
            btn_AddStartUp.Size = new Size(259, 39);
            btn_AddStartUp.TabIndex = 0;
            btn_AddStartUp.Text = "+ Lägg till Uppstart";
            btn_AddStartUp.TextAlign = ContentAlignment.MiddleLeft;
            btn_AddStartUp.UseVisualStyleBackColor = false;
            btn_AddStartUp.Click += AddStartup_Click;
            // 
            // btn_RemoveStartUp
            // 
            btn_RemoveStartUp.BackColor = Color.FromArgb(25, 25, 25);
            btn_RemoveStartUp.Cursor = Cursors.Hand;
            btn_RemoveStartUp.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 75, 75);
            btn_RemoveStartUp.FlatStyle = FlatStyle.Flat;
            btn_RemoveStartUp.Font = new Font("Consolas", 10F);
            btn_RemoveStartUp.ForeColor = Color.FromArgb(255, 199, 206);
            btn_RemoveStartUp.Location = new Point(2, 41);
            btn_RemoveStartUp.Margin = new Padding(2, 1, 0, 0);
            btn_RemoveStartUp.Name = "btn_RemoveStartUp";
            btn_RemoveStartUp.Size = new Size(259, 39);
            btn_RemoveStartUp.TabIndex = 0;
            btn_RemoveStartUp.Text = "- Radera Senaste Uppstart";
            btn_RemoveStartUp.TextAlign = ContentAlignment.MiddleLeft;
            btn_RemoveStartUp.UseVisualStyleBackColor = false;
            btn_RemoveStartUp.Click += RemoveStartup_Click;
            // 
            // btn_Add_Oven
            // 
            btn_Add_Oven.BackColor = Color.FromArgb(25, 25, 25);
            btn_Add_Oven.Cursor = Cursors.Hand;
            btn_Add_Oven.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 75, 75);
            btn_Add_Oven.FlatStyle = FlatStyle.Flat;
            btn_Add_Oven.Font = new Font("Consolas", 10F);
            btn_Add_Oven.ForeColor = Color.FromArgb(198, 239, 206);
            btn_Add_Oven.Location = new Point(2, 115);
            btn_Add_Oven.Margin = new Padding(2, 35, 0, 0);
            btn_Add_Oven.Name = "btn_Add_Oven";
            btn_Add_Oven.Size = new Size(259, 39);
            btn_Add_Oven.TabIndex = 2;
            btn_Add_Oven.Text = "+ Lägg till Ugn";
            btn_Add_Oven.TextAlign = ContentAlignment.MiddleLeft;
            btn_Add_Oven.UseVisualStyleBackColor = false;
            btn_Add_Oven.Visible = false;
            btn_Add_Oven.Click += AddOven_Click;
            // 
            // btn_RemoveOven
            // 
            btn_RemoveOven.BackColor = Color.FromArgb(25, 25, 25);
            btn_RemoveOven.Cursor = Cursors.Hand;
            btn_RemoveOven.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 75, 75);
            btn_RemoveOven.FlatStyle = FlatStyle.Flat;
            btn_RemoveOven.Font = new Font("Consolas", 10F);
            btn_RemoveOven.ForeColor = Color.FromArgb(255, 199, 206);
            btn_RemoveOven.Location = new Point(2, 155);
            btn_RemoveOven.Margin = new Padding(2, 1, 0, 0);
            btn_RemoveOven.Name = "btn_RemoveOven";
            btn_RemoveOven.Size = new Size(259, 39);
            btn_RemoveOven.TabIndex = 3;
            btn_RemoveOven.Text = "- Radera Senaste Ugn";
            btn_RemoveOven.TextAlign = ContentAlignment.MiddleLeft;
            btn_RemoveOven.UseVisualStyleBackColor = false;
            btn_RemoveOven.Visible = false;
            btn_RemoveOven.Click += RemoveOven_Click;
            // 
            // btn_Confirm_Equipment
            // 
            btn_Confirm_Equipment.BackColor = Color.FromArgb(25, 25, 25);
            btn_Confirm_Equipment.Cursor = Cursors.Hand;
            btn_Confirm_Equipment.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 75, 75);
            btn_Confirm_Equipment.FlatStyle = FlatStyle.Flat;
            btn_Confirm_Equipment.Font = new Font("Consolas", 10F);
            btn_Confirm_Equipment.ForeColor = Color.FromArgb(198, 239, 206);
            btn_Confirm_Equipment.Location = new Point(2, 229);
            btn_Confirm_Equipment.Margin = new Padding(2, 35, 0, 0);
            btn_Confirm_Equipment.Name = "btn_Confirm_Equipment";
            btn_Confirm_Equipment.Size = new Size(259, 39);
            btn_Confirm_Equipment.TabIndex = 1;
            btn_Confirm_Equipment.Text = "Bekräfta Utrustning";
            btn_Confirm_Equipment.TextAlign = ContentAlignment.MiddleLeft;
            btn_Confirm_Equipment.UseVisualStyleBackColor = false;
            btn_Confirm_Equipment.Click += Confirm_Equipment_Click;
            // 
            // btn_Edit_Equipment
            // 
            btn_Edit_Equipment.BackColor = Color.FromArgb(25, 25, 25);
            btn_Edit_Equipment.Cursor = Cursors.Hand;
            btn_Edit_Equipment.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 75, 75);
            btn_Edit_Equipment.FlatStyle = FlatStyle.Flat;
            btn_Edit_Equipment.Font = new Font("Consolas", 10F);
            btn_Edit_Equipment.ForeColor = Color.FromArgb(255, 235, 156);
            btn_Edit_Equipment.Location = new Point(2, 269);
            btn_Edit_Equipment.Margin = new Padding(2, 1, 0, 0);
            btn_Edit_Equipment.Name = "btn_Edit_Equipment";
            btn_Edit_Equipment.Size = new Size(259, 39);
            btn_Edit_Equipment.TabIndex = 1;
            btn_Edit_Equipment.Text = "Editera Utrustning";
            btn_Edit_Equipment.TextAlign = ContentAlignment.MiddleLeft;
            btn_Edit_Equipment.UseVisualStyleBackColor = false;
            btn_Edit_Equipment.Visible = false;
            btn_Edit_Equipment.Click += Edit_Equipment_Click;
            // 
            // btn_ExtraComments
            // 
            btn_ExtraComments.BackColor = Color.LightGray;
            btn_ExtraComments.Cursor = Cursors.Hand;
            btn_ExtraComments.Dock = DockStyle.Fill;
            btn_ExtraComments.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 45);
            btn_ExtraComments.FlatStyle = FlatStyle.Flat;
            btn_ExtraComments.Font = new Font("Palatino Linotype", 10F);
            btn_ExtraComments.ForeColor = Color.SaddleBrown;
            btn_ExtraComments.Location = new Point(0, 505);
            btn_ExtraComments.Margin = new Padding(0, 0, 0, 2);
            btn_ExtraComments.Name = "btn_ExtraComments";
            btn_ExtraComments.Size = new Size(444, 30);
            btn_ExtraComments.TabIndex = 1;
            btn_ExtraComments.Text = "Extra Kommentarer";
            btn_ExtraComments.TextAlign = ContentAlignment.TopLeft;
            btn_ExtraComments.UseVisualStyleBackColor = false;
            btn_ExtraComments.Click += ExtraComments_Click;
            // 
            // ProcesscardBasedOn
            // 
            ProcesscardBasedOn.BackColor = Color.Black;
            ProcesscardBasedOn.Cursor = Cursors.Hand;
            ProcesscardBasedOn.Dock = DockStyle.Fill;
            ProcesscardBasedOn.Location = new Point(0, 473);
            ProcesscardBasedOn.Margin = new Padding(0, 0, 0, 1);
            ProcesscardBasedOn.Name = "ProcesscardBasedOn";
            ProcesscardBasedOn.Size = new Size(444, 31);
            ProcesscardBasedOn.TabIndex = 0;
            // 
            // PreFab
            // 
            PreFab.BackColor = Color.Black;
            PreFab.Dock = DockStyle.Fill;
            PreFab.Location = new Point(0, 323);
            PreFab.Margin = new Padding(0, 0, 1, 1);
            PreFab.Name = "PreFab";
            PreFab.Size = new Size(443, 149);
            PreFab.TabIndex = 1;
            // 
            // panel_MainInfo
            // 
            panel_MainInfo.BackColor = Color.Black;
            tlp_Main.SetColumnSpan(panel_MainInfo, 2);
            panel_MainInfo.Dock = DockStyle.Fill;
            panel_MainInfo.Location = new Point(0, 0);
            panel_MainInfo.Margin = new Padding(0);
            panel_MainInfo.Name = "panel_MainInfo";
            panel_MainInfo.Size = new Size(2637, 68);
            panel_MainInfo.TabIndex = 904;
            // 
            // flp_Machines
            // 
            flp_Machines.AutoScroll = true;
            flp_Machines.BackColor = Color.FromArgb(65, 65, 65);
            flp_Machines.Dock = DockStyle.Fill;
            flp_Machines.Location = new Point(3, 146);
            flp_Machines.Name = "flp_Machines";
            flp_Machines.Size = new Size(2181, 1075);
            flp_Machines.TabIndex = 906;
            flp_Machines.WrapContents = false;
            flp_Machines.SizeChanged += flp_Machines_SizeChanged;
            // 
            // MainProtocol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2637, 1224);
            Controls.Add(tlp_Main);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(931, 802);
            Name = "MainProtocol";
            Text = "Protocol";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainProtocol_FormClosing;
            Load += MainProtocol_Load;
            tlp_Main.ResumeLayout(false);
            panel_LineClearance.ResumeLayout(false);
            tlp_Right.ResumeLayout(false);
            flp_Buttons.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private Comments Comments;
        private System.Windows.Forms.FlowLayoutPanel flp_Buttons;
        private System.Windows.Forms.Button btn_AddStartUp;
        private System.Windows.Forms.Button btn_RemoveStartUp;
        private System.Windows.Forms.Button btn_Confirm_Equipment;
        private System.Windows.Forms.Button btn_Edit_Equipment;
        private System.Windows.Forms.Button btn_ExtraComments;
        private PreFab PreFab;
        public Processcards.ProcesscardBasedOn ProcesscardBasedOn;
        public System.Windows.Forms.TableLayoutPanel tlp_Main;
        public System.Windows.Forms.TableLayoutPanel tlp_Right;
        private System.Windows.Forms.Button btn_Add_Oven;
        private System.Windows.Forms.Button btn_RemoveOven;
        private System.Windows.Forms.Panel panel_MainInfo;
        private System.Windows.Forms.Panel panel_LineClearance;
        private LineClearance.LineClearance Line_Clearance;
        private FlowLayoutPanel flp_Machines;
    }
}