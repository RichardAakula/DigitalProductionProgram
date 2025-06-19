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
            panel_DPP_ServerStatus.Location = new Point(45, 0);
            panel_DPP_ServerStatus.Margin = new Padding(0);
            panel_DPP_ServerStatus.Name = "panel_DPP_ServerStatus";
            panel_DPP_ServerStatus.Size = new Size(45, 40);
            panel_DPP_ServerStatus.TabIndex = 896;
            // 
            // lbl_DPP_Status
            // 
            lbl_DPP_Status.BackColor = Color.Transparent;
            lbl_DPP_Status.Dock = DockStyle.Fill;
            lbl_DPP_Status.Font = new Font("Mongolian Baiti", 10F, FontStyle.Bold);
            lbl_DPP_Status.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_DPP_Status.Location = new Point(0, 0);
            lbl_DPP_Status.Margin = new Padding(4, 0, 4, 0);
            lbl_DPP_Status.Name = "lbl_DPP_Status";
            lbl_DPP_Status.Size = new Size(45, 40);
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
            panel_MonitorStatus.Location = new Point(99, 9);
            panel_MonitorStatus.Margin = new Padding(9);
            panel_MonitorStatus.Name = "panel_MonitorStatus";
            panel_MonitorStatus.Size = new Size(27, 22);
            panel_MonitorStatus.TabIndex = 895;
            // 
            // lbl_MonitorStatus
            // 
            lbl_MonitorStatus.BackColor = Color.Transparent;
            lbl_MonitorStatus.Dock = DockStyle.Fill;
            lbl_MonitorStatus.Font = new Font("Mongolian Baiti", 10F, FontStyle.Bold);
            lbl_MonitorStatus.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_MonitorStatus.Location = new Point(0, 0);
            lbl_MonitorStatus.Margin = new Padding(6);
            lbl_MonitorStatus.Name = "lbl_MonitorStatus";
            lbl_MonitorStatus.Size = new Size(27, 22);
            lbl_MonitorStatus.TabIndex = 895;
            lbl_MonitorStatus.Text = "M";
            lbl_MonitorStatus.TextAlign = ContentAlignment.TopCenter;
            lbl_MonitorStatus.Click += lbl_MonitorStatus_Click;
            lbl_MonitorStatus.MouseHover += MonitorStatus_MouseHover;
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 3;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlp_Main.Controls.Add(lbl_SQL_Queries, 0, 0);
            tlp_Main.Controls.Add(panel_MonitorStatus, 2, 0);
            tlp_Main.Controls.Add(panel_DPP_ServerStatus, 1, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 1;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(135, 40);
            tlp_Main.TabIndex = 897;
            // 
            // lbl_SQL_Queries
            // 
            lbl_SQL_Queries.BackColor = Color.Transparent;
            lbl_SQL_Queries.Font = new Font("Arial", 8F, FontStyle.Bold);
            lbl_SQL_Queries.ForeColor = Color.White;
            lbl_SQL_Queries.Location = new Point(4, 0);
            lbl_SQL_Queries.Margin = new Padding(4, 0, 4, 0);
            lbl_SQL_Queries.Name = "lbl_SQL_Queries";
            lbl_SQL_Queries.Size = new Size(37, 40);
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
    }
}
