using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Övrigt
{
    partial class BlackBackground
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblInfo = new System.Windows.Forms.Label();
            this.bgw_InfoText = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pb_Icon = new System.Windows.Forms.PictureBox();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Icon)).BeginInit();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Font = new System.Drawing.Font("Modern No. 20", 20F, System.Drawing.FontStyle.Bold);
            this.lblInfo.ForeColor = System.Drawing.Color.FloralWhite;
            this.lblInfo.Location = new System.Drawing.Point(3, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 100);
            this.lblInfo.Size = new System.Drawing.Size(1454, 518);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Information";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // bgw_InfoText
            // 
            this.bgw_InfoText.WorkerSupportsCancellation = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            // 
            // pb_Icon
            // 
            this.pb_Icon.BackgroundImage = global::DigitalProductionProgram.Properties.Resources.NewIcon;
            this.pb_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_Icon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Icon.Location = new System.Drawing.Point(3, 521);
            this.pb_Icon.Name = "pb_Icon";
            this.pb_Icon.Size = new System.Drawing.Size(1454, 212);
            this.pb_Icon.TabIndex = 1;
            this.pb_Icon.TabStop = false;
            this.pb_Icon.Visible = false;
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Controls.Add(this.lblInfo, 0, 0);
            this.tlp_Main.Controls.Add(this.pb_Icon, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.38043F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.61957F));
            this.tlp_Main.Size = new System.Drawing.Size(1460, 736);
            this.tlp_Main.TabIndex = 2;
            // 
            // BlackBackground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1460, 736);
            this.Controls.Add(this.tlp_Main);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "BlackBackground";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BlackBackground";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BlackBackground_Load);
            this.Click += new System.EventHandler(this.BlackBackground_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Icon)).EndInit();
            this.tlp_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblInfo;
        private BackgroundWorker bgw_InfoText;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pb_Icon;
        private TableLayoutPanel tlp_Main;
    }
}