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
            this.panel_DPP_ServerStatus = new System.Windows.Forms.Panel();
            this.lbl_DPP_Status = new System.Windows.Forms.Label();
            this.panel_MonitorStatus = new System.Windows.Forms.Panel();
            this.lbl_MonitorStatus = new System.Windows.Forms.Label();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.panel_DPP_ServerStatus.SuspendLayout();
            this.panel_MonitorStatus.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_DPP_ServerStatus
            // 
            this.panel_DPP_ServerStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_DPP_ServerStatus.Controls.Add(this.lbl_DPP_Status);
            this.panel_DPP_ServerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DPP_ServerStatus.Location = new System.Drawing.Point(0, 0);
            this.panel_DPP_ServerStatus.Margin = new System.Windows.Forms.Padding(0);
            this.panel_DPP_ServerStatus.Name = "panel_DPP_ServerStatus";
            this.panel_DPP_ServerStatus.Size = new System.Drawing.Size(58, 35);
            this.panel_DPP_ServerStatus.TabIndex = 896;
            // 
            // lbl_DPP_Status
            // 
            this.lbl_DPP_Status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DPP_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DPP_Status.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_DPP_Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_DPP_Status.Location = new System.Drawing.Point(0, 0);
            this.lbl_DPP_Status.Name = "lbl_DPP_Status";
            this.lbl_DPP_Status.Size = new System.Drawing.Size(58, 35);
            this.lbl_DPP_Status.TabIndex = 895;
            this.lbl_DPP_Status.Text = "DPP";
            this.lbl_DPP_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_DPP_Status.MouseHover += new System.EventHandler(this.DPP_Status_MouseHover);
            // 
            // panel_MonitorStatus
            // 
            this.panel_MonitorStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_MonitorStatus.Controls.Add(this.lbl_MonitorStatus);
            this.panel_MonitorStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_MonitorStatus.Location = new System.Drawing.Point(66, 8);
            this.panel_MonitorStatus.Margin = new System.Windows.Forms.Padding(8);
            this.panel_MonitorStatus.Name = "panel_MonitorStatus";
            this.panel_MonitorStatus.Size = new System.Drawing.Size(42, 19);
            this.panel_MonitorStatus.TabIndex = 895;
            // 
            // lbl_MonitorStatus
            // 
            this.lbl_MonitorStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbl_MonitorStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_MonitorStatus.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_MonitorStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_MonitorStatus.Location = new System.Drawing.Point(0, 0);
            this.lbl_MonitorStatus.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_MonitorStatus.Name = "lbl_MonitorStatus";
            this.lbl_MonitorStatus.Size = new System.Drawing.Size(42, 19);
            this.lbl_MonitorStatus.TabIndex = 895;
            this.lbl_MonitorStatus.Text = "M";
            this.lbl_MonitorStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_MonitorStatus.MouseHover += new System.EventHandler(this.MonitorStatus_MouseHover);
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Controls.Add(this.panel_MonitorStatus, 1, 0);
            this.tlp_Main.Controls.Add(this.panel_DPP_ServerStatus, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 1;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(116, 35);
            this.tlp_Main.TabIndex = 897;
            // 
            // ServerStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "ServerStatus";
            this.Size = new System.Drawing.Size(116, 35);
            this.panel_DPP_ServerStatus.ResumeLayout(false);
            this.panel_MonitorStatus.ResumeLayout(false);
            this.tlp_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlp_Main;
        public Label lbl_DPP_Status;
        public Label lbl_MonitorStatus;
        public Panel panel_DPP_ServerStatus;
        public Panel panel_MonitorStatus;
    }
}
