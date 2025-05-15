namespace DigitalProductionProgram.DatabaseManagement
{
    partial class Database
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
            label_ConnectionString_DPP = new Label();
            label_ConnectionString_ToolRegister = new Label();
            cb_DPP = new ComboBox();
            cb_Toolregister = new ComboBox();
            btn_SaveAndExit = new Button();
            label_MonitorCompany = new Label();
            cb_MonitorCompany = new ComboBox();
            label_HostMonitor = new Label();
            cb_MonitorHost = new ComboBox();
            label_Info = new Label();
            panel_Main = new Panel();
            panel_Main.SuspendLayout();
            SuspendLayout();
            // 
            // label_ConnectionString_DPP
            // 
            label_ConnectionString_DPP.AutoSize = true;
            label_ConnectionString_DPP.Font = new Font("Lucida Sans", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ConnectionString_DPP.ForeColor = Color.FromArgb(181, 210, 207);
            label_ConnectionString_DPP.Location = new Point(23, 23);
            label_ConnectionString_DPP.Margin = new Padding(4, 0, 4, 0);
            label_ConnectionString_DPP.Name = "label_ConnectionString_DPP";
            label_ConnectionString_DPP.Size = new Size(182, 17);
            label_ConnectionString_DPP.TabIndex = 0;
            label_ConnectionString_DPP.Text = "Select Database for DPP";
            // 
            // label_ConnectionString_ToolRegister
            // 
            label_ConnectionString_ToolRegister.AutoSize = true;
            label_ConnectionString_ToolRegister.Font = new Font("Lucida Sans", 10.75F);
            label_ConnectionString_ToolRegister.ForeColor = Color.FromArgb(181, 210, 207);
            label_ConnectionString_ToolRegister.Location = new Point(23, 98);
            label_ConnectionString_ToolRegister.Margin = new Padding(4, 0, 4, 0);
            label_ConnectionString_ToolRegister.Name = "label_ConnectionString_ToolRegister";
            label_ConnectionString_ToolRegister.Size = new Size(241, 17);
            label_ConnectionString_ToolRegister.TabIndex = 0;
            label_ConnectionString_ToolRegister.Text = "Select Database for Toolregister";
            // 
            // cb_DPP
            // 
            cb_DPP.Cursor = Cursors.Arrow;
            cb_DPP.FormattingEnabled = true;
            cb_DPP.Items.AddRange(new object[] { "Godby", "Godby Test", "Thailand", "Valley Forge" });
            cb_DPP.Location = new Point(21, 46);
            cb_DPP.Margin = new Padding(4, 3, 4, 3);
            cb_DPP.Name = "cb_DPP";
            cb_DPP.Size = new Size(202, 23);
            cb_DPP.TabIndex = 1;
            cb_DPP.SelectedIndexChanged += DPP_SelectedIndexChanged;
            cb_DPP.Enter += DPP_Enter;
            // 
            // cb_Toolregister
            // 
            cb_Toolregister.Cursor = Cursors.Arrow;
            cb_Toolregister.FormattingEnabled = true;
            cb_Toolregister.Items.AddRange(new object[] { "Godby", "Thailand", "Valley Forge" });
            cb_Toolregister.Location = new Point(21, 121);
            cb_Toolregister.Margin = new Padding(4, 3, 4, 3);
            cb_Toolregister.Name = "cb_Toolregister";
            cb_Toolregister.Size = new Size(202, 23);
            cb_Toolregister.TabIndex = 1;
            cb_Toolregister.SelectedIndexChanged += Toolregister_SelectedIndexChanged;
            cb_Toolregister.Enter += Toolregister_Enter;
            // 
            // btn_SaveAndExit
            // 
            btn_SaveAndExit.BackColor = Color.FromArgb(255, 199, 206);
            btn_SaveAndExit.Cursor = Cursors.Hand;
            btn_SaveAndExit.FlatAppearance.BorderColor = Color.FromArgb(156, 0, 6);
            btn_SaveAndExit.Font = new Font("Lucida Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_SaveAndExit.ForeColor = Color.FromArgb(156, 0, 6);
            btn_SaveAndExit.Location = new Point(21, 213);
            btn_SaveAndExit.Margin = new Padding(4, 3, 4, 3);
            btn_SaveAndExit.Name = "btn_SaveAndExit";
            btn_SaveAndExit.Size = new Size(144, 44);
            btn_SaveAndExit.TabIndex = 2;
            btn_SaveAndExit.Text = "Save and Exit";
            btn_SaveAndExit.UseVisualStyleBackColor = false;
            btn_SaveAndExit.Click += SaveAndExit_Click;
            // 
            // label_MonitorCompany
            // 
            label_MonitorCompany.AutoSize = true;
            label_MonitorCompany.Font = new Font("Lucida Sans", 10.75F);
            label_MonitorCompany.ForeColor = Color.FromArgb(181, 210, 207);
            label_MonitorCompany.Location = new Point(321, 24);
            label_MonitorCompany.Margin = new Padding(4, 0, 4, 0);
            label_MonitorCompany.Name = "label_MonitorCompany";
            label_MonitorCompany.Size = new Size(213, 17);
            label_MonitorCompany.TabIndex = 0;
            label_MonitorCompany.Text = "Select Company for Monitor";
            // 
            // cb_MonitorCompany
            // 
            cb_MonitorCompany.Cursor = Cursors.Arrow;
            cb_MonitorCompany.FormattingEnabled = true;
            cb_MonitorCompany.Items.AddRange(new object[] { "001.1", "003.1", "010.1", "012.1" });
            cb_MonitorCompany.Location = new Point(318, 47);
            cb_MonitorCompany.Margin = new Padding(4, 3, 4, 3);
            cb_MonitorCompany.Name = "cb_MonitorCompany";
            cb_MonitorCompany.Size = new Size(202, 23);
            cb_MonitorCompany.TabIndex = 1;
            cb_MonitorCompany.SelectedIndexChanged += MonitorCompany_SelectedIndexChanged;
            cb_MonitorCompany.Enter += MonitorCompany_Enter;
            // 
            // label_HostMonitor
            // 
            label_HostMonitor.AutoSize = true;
            label_HostMonitor.Font = new Font("Lucida Sans", 10.75F);
            label_HostMonitor.ForeColor = Color.FromArgb(181, 210, 207);
            label_HostMonitor.Location = new Point(321, 99);
            label_HostMonitor.Margin = new Padding(4, 0, 4, 0);
            label_HostMonitor.Name = "label_HostMonitor";
            label_HostMonitor.Size = new Size(179, 17);
            label_HostMonitor.TabIndex = 0;
            label_HostMonitor.Text = "Select Host for Monitor";
            // 
            // cb_MonitorHost
            // 
            cb_MonitorHost.Cursor = Cursors.Arrow;
            cb_MonitorHost.FormattingEnabled = true;
            cb_MonitorHost.Items.AddRange(new object[] { "optig5", "stage-optig5.optinova.fi" });
            cb_MonitorHost.Location = new Point(318, 122);
            cb_MonitorHost.Margin = new Padding(4, 3, 4, 3);
            cb_MonitorHost.Name = "cb_MonitorHost";
            cb_MonitorHost.Size = new Size(202, 23);
            cb_MonitorHost.TabIndex = 1;
            cb_MonitorHost.SelectedIndexChanged += MonitorHost_SelectedIndexChanged;
            cb_MonitorHost.Enter += MonitorHost_Enter;
            // 
            // label_Info
            // 
            label_Info.BorderStyle = BorderStyle.FixedSingle;
            label_Info.Font = new Font("Lucida Sans", 10.25F);
            label_Info.ForeColor = Color.FromArgb(171, 150, 85);
            label_Info.Location = new Point(614, 18);
            label_Info.Margin = new Padding(4, 0, 4, 0);
            label_Info.Name = "label_Info";
            label_Info.Size = new Size(390, 138);
            label_Info.TabIndex = 3;
            label_Info.Text = "001.1 - Optinova Godby Ab\r\n003.1 - Optinova Holding Ab\r\n010.1 - Optinova Thailand Co\r\n012.1 - Optinova Valley Forge\r\n\r\n\r\n";
            // 
            // panel_Main
            // 
            panel_Main.BackColor = Color.FromArgb(6, 81, 87);
            panel_Main.Controls.Add(label_ConnectionString_DPP);
            panel_Main.Controls.Add(label_Info);
            panel_Main.Controls.Add(label_ConnectionString_ToolRegister);
            panel_Main.Controls.Add(cb_MonitorHost);
            panel_Main.Controls.Add(btn_SaveAndExit);
            panel_Main.Controls.Add(cb_MonitorCompany);
            panel_Main.Controls.Add(cb_DPP);
            panel_Main.Controls.Add(label_HostMonitor);
            panel_Main.Controls.Add(cb_Toolregister);
            panel_Main.Controls.Add(label_MonitorCompany);
            panel_Main.Location = new Point(6, 6);
            panel_Main.Margin = new Padding(29);
            panel_Main.Name = "panel_Main";
            panel_Main.Padding = new Padding(6);
            panel_Main.Size = new Size(1027, 277);
            panel_Main.TabIndex = 4;
            // 
            // Database
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1038, 288);
            Controls.Add(panel_Main);
            Cursor = Cursors.SizeAll;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Database";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SelectDatabase";
            MouseDown += Database_MouseDown;
            MouseMove += Database_MouseMove;
            MouseUp += Database_MouseUp;
            panel_Main.ResumeLayout(false);
            panel_Main.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_ConnectionString_DPP;
        private System.Windows.Forms.Label label_ConnectionString_ToolRegister;
        private System.Windows.Forms.ComboBox cb_DPP;
        private System.Windows.Forms.ComboBox cb_Toolregister;
        private System.Windows.Forms.Button btn_SaveAndExit;
        private System.Windows.Forms.Label label_MonitorCompany;
        private System.Windows.Forms.ComboBox cb_MonitorCompany;
        private System.Windows.Forms.Label label_HostMonitor;
        private System.Windows.Forms.ComboBox cb_MonitorHost;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.Panel panel_Main;
    }
}