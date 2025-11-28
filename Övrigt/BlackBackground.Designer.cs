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
            components = new Container();
            lblInfo = new Label();
            bgw_InfoText = new BackgroundWorker();
            timer1 = new System.Windows.Forms.Timer(components);
            pb_Icon = new PictureBox();
            tlp_Main = new TableLayoutPanel();
            ((ISupportInitialize)pb_Icon).BeginInit();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Dock = DockStyle.Fill;
            lblInfo.Font = new Font("Modern No. 20", 20F, FontStyle.Bold);
            lblInfo.ForeColor = Color.FloralWhite;
            lblInfo.Location = new Point(4, 0);
            lblInfo.Margin = new Padding(4, 0, 4, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Padding = new Padding(0, 0, 0, 115);
            lblInfo.Size = new Size(1695, 570);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "Information";
            lblInfo.TextAlign = ContentAlignment.BottomCenter;
            // 
            // bgw_InfoText
            // 
            bgw_InfoText.WorkerSupportsCancellation = true;
            // 
            // timer1
            // 
            timer1.Interval = 50;
            // 
            // pb_Icon
            // 
            pb_Icon.BackgroundImageLayout = ImageLayout.Zoom;
            pb_Icon.Dock = DockStyle.Fill;
            pb_Icon.Location = new Point(4, 611);
            pb_Icon.Margin = new Padding(4, 3, 4, 3);
            pb_Icon.Name = "pb_Icon";
            pb_Icon.Size = new Size(1695, 235);
            pb_Icon.TabIndex = 1;
            pb_Icon.TabStop = false;
            pb_Icon.Visible = false;
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Transparent;
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.Controls.Add(lblInfo, 0, 0);
            tlp_Main.Controls.Add(pb_Icon, 0, 2);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 3;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 70.38043F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 29.61957F));
            tlp_Main.Size = new Size(1703, 849);
            tlp_Main.TabIndex = 2;
            // 
            // BlackBackground
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1703, 849);
            Controls.Add(tlp_Main);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "BlackBackground";
            Opacity = 0.85D;
            StartPosition = FormStartPosition.CenterParent;
            Text = "BlackBackground";
            WindowState = FormWindowState.Maximized;
            Load += BlackBackground_Load;
            Click += BlackBackground_Click;
            ((ISupportInitialize)pb_Icon).EndInit();
            tlp_Main.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private Label lblInfo;
        private BackgroundWorker bgw_InfoText;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pb_Icon;
        private TableLayoutPanel tlp_Main;
    }
}