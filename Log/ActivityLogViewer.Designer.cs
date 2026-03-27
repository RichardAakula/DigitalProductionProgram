using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalProductionProgram.Log
{
    partial class ActivityLogViewer
    {
        private IContainer components = null;

        private TableLayoutPanel tlp_Main;
        private Panel panel_Header;
        private Panel panel_Filter;
        private Panel panel_ScrollContainer;
        private Panel panel_Status;
        private Label label_Header;
        private Label label_Status;
        private TextBox tb_FilterHostName;
        private TextBox tb_FilterUsername;
        private SmoothFlowLayoutPanel panel_activityListPanel;
        
        

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        public void InitializeComponent()
        {
            tlp_Main = new TableLayoutPanel();
            panel_Header = new Panel();
            label_Header = new Label();
            panel_Filter = new Panel();
            tb_FilterHostName = new TextBox();
            tb_FilterUsername = new TextBox();
            panel_ScrollContainer = new Panel();
            panel_activityListPanel = new SmoothFlowLayoutPanel();
            panel_Status = new Panel();
            label_Status = new Label();
            tlp_Main.SuspendLayout();
            panel_Header.SuspendLayout();
            panel_Filter.SuspendLayout();
            panel_ScrollContainer.SuspendLayout();
            panel_Status.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.Controls.Add(panel_Header, 0, 0);
            tlp_Main.Controls.Add(panel_Filter, 0, 1);
            tlp_Main.Controls.Add(panel_ScrollContainer, 0, 2);
            tlp_Main.Controls.Add(panel_Status, 0, 3);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 4;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            tlp_Main.Size = new Size(736, 972);
            tlp_Main.TabIndex = 0;
            // 
            // panel_Header
            // 
            panel_Header.BackColor = Color.FromArgb(33, 33, 33);
            panel_Header.Controls.Add(label_Header);
            panel_Header.Dock = DockStyle.Fill;
            panel_Header.Location = new Point(3, 3);
            panel_Header.Name = "panel_Header";
            panel_Header.Padding = new Padding(20, 10, 20, 10);
            panel_Header.Size = new Size(730, 64);
            panel_Header.TabIndex = 0;
            // 
            // label_Header
            // 
            label_Header.AutoSize = true;
            label_Header.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label_Header.ForeColor = Color.White;
            label_Header.Location = new Point(0, 0);
            label_Header.Name = "label_Header";
            label_Header.Size = new Size(187, 41);
            label_Header.TabIndex = 0;
            label_Header.Text = "Activity Log";
            // 
            // panel_Filter
            // 
            panel_Filter.BackColor = SystemColors.ButtonFace;
            panel_Filter.Controls.Add(tb_FilterHostName);
            panel_Filter.Controls.Add(tb_FilterUsername);
            panel_Filter.Dock = DockStyle.Fill;
            panel_Filter.Location = new Point(3, 73);
            panel_Filter.Name = "panel_Filter";
            panel_Filter.Padding = new Padding(15, 10, 15, 5);
            panel_Filter.Size = new Size(730, 49);
            panel_Filter.TabIndex = 1;
            // 
            // tb_FilterHostName
            // 
            tb_FilterHostName.Location = new Point(335, 12);
            tb_FilterHostName.Name = "tb_FilterHostName";
            tb_FilterHostName.PlaceholderText = "Filter by HostName...";
            tb_FilterHostName.Size = new Size(200, 23);
            tb_FilterHostName.TabIndex = 0;
            tb_FilterHostName.TextChanged += FilterChanged;
            // 
            // tb_FilterUsername
            // 
            tb_FilterUsername.Location = new Point(26, 12);
            tb_FilterUsername.Name = "tb_FilterUsername";
            tb_FilterUsername.PlaceholderText = "Filter by UserName...";
            tb_FilterUsername.Size = new Size(200, 23);
            tb_FilterUsername.TabIndex = 1;
            tb_FilterUsername.TextChanged += FilterChanged;
            // 
            // panel_ScrollContainer
            // 
            panel_ScrollContainer.AutoScroll = true;
            panel_ScrollContainer.BackColor = SystemColors.ButtonFace;
            panel_ScrollContainer.Controls.Add(panel_activityListPanel);
            panel_ScrollContainer.Dock = DockStyle.Fill;
            panel_ScrollContainer.Location = new Point(3, 128);
            panel_ScrollContainer.Name = "panel_ScrollContainer";
            panel_ScrollContainer.Padding = new Padding(15);
            panel_ScrollContainer.Size = new Size(730, 783);
            panel_ScrollContainer.TabIndex = 2;
            // 
            // panel_activityListPanel
            // 
            panel_activityListPanel.AutoScroll = true;
            panel_activityListPanel.Dock = DockStyle.Fill;
            panel_activityListPanel.Location = new Point(15, 15);
            panel_activityListPanel.Name = "panel_activityListPanel";
            panel_activityListPanel.Size = new Size(700, 753);
            panel_activityListPanel.TabIndex = 0;
            // 
            // panel_Status
            // 
            panel_Status.BackColor = Color.FromArgb(250, 250, 250);
            panel_Status.BorderStyle = BorderStyle.FixedSingle;
            panel_Status.Controls.Add(label_Status);
            panel_Status.Dock = DockStyle.Fill;
            panel_Status.Location = new Point(3, 917);
            panel_Status.Name = "panel_Status";
            panel_Status.Padding = new Padding(15);
            panel_Status.Size = new Size(730, 52);
            panel_Status.TabIndex = 3;
            // 
            // label_Status
            // 
            label_Status.AutoSize = true;
            label_Status.Dock = DockStyle.Left;
            label_Status.Font = new Font("Segoe UI", 10F);
            label_Status.ForeColor = Color.FromArgb(76, 175, 80);
            label_Status.Location = new Point(15, 15);
            label_Status.Name = "label_Status";
            label_Status.Size = new Size(87, 19);
            label_Status.TabIndex = 0;
            label_Status.Text = "● Updating...";
            // 
            // ActivityLogViewer
            // 
            ClientSize = new Size(736, 972);
            Controls.Add(tlp_Main);
            Name = "ActivityLogViewer";
            tlp_Main.ResumeLayout(false);
            panel_Header.ResumeLayout(false);
            panel_Header.PerformLayout();
            panel_Filter.ResumeLayout(false);
            panel_Filter.PerformLayout();
            panel_ScrollContainer.ResumeLayout(false);
            panel_Status.ResumeLayout(false);
            panel_Status.PerformLayout();
            ResumeLayout(false);
        }


    }
}