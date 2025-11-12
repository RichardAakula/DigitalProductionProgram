using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class ServerStatus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel_DPP_ServerStatus = new Panel();
            lbl_DPP_Status = new Label();
            panel_MonitorStatus = new Panel();
            lbl_MonitorStatus = new Label();
            tlp_Main = new TableLayoutPanel();
            lbl_Memory = new Label();
            label_Memory = new Label();
            label_Queries = new Label();
            lbl_SQL_Queries = new Label();
            panel_DPP_ServerStatus.SuspendLayout();
            panel_MonitorStatus.SuspendLayout();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // panel_DPP_ServerStatus
            // 
            panel_DPP_ServerStatus.BackgroundImageLayout = ImageLayout.Stretch;
            panel_DPP_ServerStatus.Controls.Add(lbl_DPP_Status);
            panel_DPP_ServerStatus.Dock = DockStyle.Fill;
            panel_DPP_ServerStatus.Location = new Point(66, 0);
            panel_DPP_ServerStatus.Margin = new Padding(0);
            panel_DPP_ServerStatus.Name = "panel_DPP_ServerStatus";
            tlp_Main.SetRowSpan(panel_DPP_ServerStatus, 2);
            panel_DPP_ServerStatus.Size = new Size(33, 40);
            panel_DPP_ServerStatus.TabIndex = 896;
            // 
            // lbl_DPP_Status
            // 
            lbl_DPP_Status.BackColor = Color.Transparent;
            lbl_DPP_Status.Dock = DockStyle.Fill;
            lbl_DPP_Status.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            lbl_DPP_Status.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_DPP_Status.Location = new Point(0, 0);
            lbl_DPP_Status.Margin = new Padding(4, 0, 4, 0);
            lbl_DPP_Status.Name = "lbl_DPP_Status";
            lbl_DPP_Status.Size = new Size(33, 40);
            lbl_DPP_Status.TabIndex = 895;
            lbl_DPP_Status.Text = "DPP";
            lbl_DPP_Status.TextAlign = ContentAlignment.MiddleCenter;
            lbl_DPP_Status.MouseHover += DPP_Status_MouseHover;
            // 
            // panel_MonitorStatus
            // 
            panel_MonitorStatus.BackgroundImageLayout = ImageLayout.Stretch;
            panel_MonitorStatus.Controls.Add(lbl_MonitorStatus);
            panel_MonitorStatus.Dock = DockStyle.Fill;
            panel_MonitorStatus.Location = new Point(99, 0);
            panel_MonitorStatus.Margin = new Padding(0);
            panel_MonitorStatus.Name = "panel_MonitorStatus";
            tlp_Main.SetRowSpan(panel_MonitorStatus, 2);
            panel_MonitorStatus.Size = new Size(36, 40);
            panel_MonitorStatus.TabIndex = 895;
            // 
            // lbl_MonitorStatus
            // 
            lbl_MonitorStatus.BackColor = Color.Transparent;
            lbl_MonitorStatus.Dock = DockStyle.Fill;
            lbl_MonitorStatus.Font = new Font("Mongolian Baiti", 9F, FontStyle.Bold);
            lbl_MonitorStatus.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_MonitorStatus.Location = new Point(0, 0);
            lbl_MonitorStatus.Margin = new Padding(6);
            lbl_MonitorStatus.Name = "lbl_MonitorStatus";
            lbl_MonitorStatus.Size = new Size(36, 40);
            lbl_MonitorStatus.TabIndex = 895;
            lbl_MonitorStatus.Text = "M";
            lbl_MonitorStatus.TextAlign = ContentAlignment.MiddleCenter;
            lbl_MonitorStatus.Click += FlyingEasterEggClick_Click;
            lbl_MonitorStatus.MouseHover += MonitorStatus_MouseHover;
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 4;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp_Main.Controls.Add(lbl_Memory, 0, 1);
            tlp_Main.Controls.Add(label_Memory, 0, 0);
            tlp_Main.Controls.Add(label_Queries, 1, 0);
            tlp_Main.Controls.Add(lbl_SQL_Queries, 1, 1);
            tlp_Main.Controls.Add(panel_MonitorStatus, 3, 0);
            tlp_Main.Controls.Add(panel_DPP_ServerStatus, 2, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_Main.Size = new Size(135, 40);
            tlp_Main.TabIndex = 897;
            // 
            // lbl_Memory
            // 
            lbl_Memory.BackColor = Color.Transparent;
            lbl_Memory.Dock = DockStyle.Fill;
            lbl_Memory.Font = new Font("Arial", 8F, FontStyle.Bold);
            lbl_Memory.ForeColor = Color.White;
            lbl_Memory.Location = new Point(0, 20);
            lbl_Memory.Margin = new Padding(0);
            lbl_Memory.Name = "lbl_Memory";
            lbl_Memory.Size = new Size(33, 20);
            lbl_Memory.TabIndex = 899;
            lbl_Memory.Text = "0";
            lbl_Memory.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Memory.Visible = false;
            // 
            // label_Memory
            // 
            label_Memory.BackColor = Color.Transparent;
            label_Memory.Dock = DockStyle.Fill;
            label_Memory.Font = new Font("Arial", 6F, FontStyle.Bold);
            label_Memory.ForeColor = Color.White;
            label_Memory.Location = new Point(0, 0);
            label_Memory.Margin = new Padding(0);
            label_Memory.Name = "label_Memory";
            label_Memory.Size = new Size(33, 20);
            label_Memory.TabIndex = 898;
            label_Memory.Text = "Memory";
            label_Memory.TextAlign = ContentAlignment.MiddleCenter;
            label_Memory.Visible = false;
            // 
            // label_Queries
            // 
            label_Queries.BackColor = Color.Transparent;
            label_Queries.Dock = DockStyle.Fill;
            label_Queries.Font = new Font("Arial", 6F, FontStyle.Bold);
            label_Queries.ForeColor = Color.White;
            label_Queries.Location = new Point(33, 0);
            label_Queries.Margin = new Padding(0);
            label_Queries.Name = "label_Queries";
            label_Queries.Size = new Size(33, 20);
            label_Queries.TabIndex = 897;
            label_Queries.Text = "Queries";
            label_Queries.TextAlign = ContentAlignment.MiddleCenter;
            label_Queries.Visible = false;
            // 
            // lbl_SQL_Queries
            // 
            lbl_SQL_Queries.BackColor = Color.Transparent;
            lbl_SQL_Queries.Dock = DockStyle.Fill;
            lbl_SQL_Queries.Font = new Font("Arial", 8F, FontStyle.Bold);
            lbl_SQL_Queries.ForeColor = Color.White;
            lbl_SQL_Queries.Location = new Point(33, 20);
            lbl_SQL_Queries.Margin = new Padding(0);
            lbl_SQL_Queries.Name = "lbl_SQL_Queries";
            lbl_SQL_Queries.Size = new Size(33, 20);
            lbl_SQL_Queries.TabIndex = 896;
            lbl_SQL_Queries.Text = "0";
            lbl_SQL_Queries.TextAlign = ContentAlignment.MiddleCenter;
            lbl_SQL_Queries.Visible = false;
            // 
            // ServerStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ServerStatus";
            Size = new Size(135, 40);
            panel_DPP_ServerStatus.ResumeLayout(false);
            panel_MonitorStatus.ResumeLayout(false);
            tlp_Main.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlp_Main;
        public Label lbl_DPP_Status;
        public Label lbl_MonitorStatus;
        public Panel panel_DPP_ServerStatus;
        public Panel panel_MonitorStatus;
        public Label lbl_SQL_Queries;
        public Label lbl_Memory;
        public Label label_Memory;
        public Label label_Queries;
    }
}
