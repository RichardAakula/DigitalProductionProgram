using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Statistics
{
    partial class Overview_ProductionLines
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Overview_ProductionLines));
            timer_UpdateInfo = new System.Windows.Forms.Timer(components);
            panel_Main = new Panel();
            pBox_Close = new PictureBox();
            panel_Info = new Panel();
            label_ProductionLines_Info = new Label();
            label_ProductionLines_Red = new Label();
            label_ProductionLines_Green = new Label();
            pBox_Info = new PictureBox();
            label_ProductionLines_Header = new Label();
            panel_Main.SuspendLayout();
            ((ISupportInitialize)pBox_Close).BeginInit();
            panel_Info.SuspendLayout();
            ((ISupportInitialize)pBox_Info).BeginInit();
            SuspendLayout();
            // 
            // timer_UpdateInfo
            // 
            timer_UpdateInfo.Interval = 1000;
            // 
            // panel_Main
            // 
            panel_Main.AutoScroll = true;
            panel_Main.Controls.Add(pBox_Close);
            panel_Main.Controls.Add(panel_Info);
            panel_Main.Controls.Add(pBox_Info);
            panel_Main.Controls.Add(label_ProductionLines_Header);
            panel_Main.Dock = DockStyle.Fill;
            panel_Main.Location = new Point(0, 0);
            panel_Main.Margin = new Padding(4, 3, 4, 3);
            panel_Main.Name = "panel_Main";
            panel_Main.Size = new Size(1703, 751);
            panel_Main.TabIndex = 0;
            panel_Main.Click += Close_Click;
            // 
            // pBox_Close
            // 
            pBox_Close.BackgroundImageLayout = ImageLayout.Center;
            pBox_Close.Cursor = Cursors.Hand;
            pBox_Close.Image = (Image)resources.GetObject("pBox_Close.Image");
            pBox_Close.Location = new Point(36, 0);
            pBox_Close.Margin = new Padding(4, 3, 4, 3);
            pBox_Close.MaximumSize = new Size(35, 46);
            pBox_Close.MinimumSize = new Size(35, 46);
            pBox_Close.Name = "pBox_Close";
            pBox_Close.Size = new Size(35, 46);
            pBox_Close.SizeMode = PictureBoxSizeMode.Zoom;
            pBox_Close.TabIndex = 3;
            pBox_Close.TabStop = false;
            pBox_Close.Click += Close_Click;
            // 
            // panel_Info
            // 
            panel_Info.BorderStyle = BorderStyle.FixedSingle;
            panel_Info.Controls.Add(label_ProductionLines_Info);
            panel_Info.Controls.Add(label_ProductionLines_Red);
            panel_Info.Controls.Add(label_ProductionLines_Green);
            panel_Info.Location = new Point(72, 0);
            panel_Info.Margin = new Padding(4, 3, 4, 3);
            panel_Info.Name = "panel_Info";
            panel_Info.Size = new Size(303, 97);
            panel_Info.TabIndex = 2;
            panel_Info.Visible = false;
            // 
            // label_ProductionLines_Info
            // 
            label_ProductionLines_Info.AutoSize = true;
            label_ProductionLines_Info.ForeColor = SystemColors.Info;
            label_ProductionLines_Info.Location = new Point(19, 62);
            label_ProductionLines_Info.Margin = new Padding(4, 0, 4, 0);
            label_ProductionLines_Info.Name = "label_ProductionLines_Info";
            label_ProductionLines_Info.Size = new Size(155, 15);
            label_ProductionLines_Info.TabIndex = 0;
            label_ProductionLines_Info.Text = "Klicka på Linjen för mer info";
            // 
            // label_ProductionLines_Red
            // 
            label_ProductionLines_Red.AutoSize = true;
            label_ProductionLines_Red.ForeColor = Color.FromArgb(156, 0, 6);
            label_ProductionLines_Red.Location = new Point(19, 38);
            label_ProductionLines_Red.Margin = new Padding(4, 0, 4, 0);
            label_ProductionLines_Red.Name = "label_ProductionLines_Red";
            label_ProductionLines_Red.Size = new Size(164, 15);
            label_ProductionLines_Red.TabIndex = 0;
            label_ProductionLines_Red.Text = "Röd = Linjen är inaktiv just nu";
            // 
            // label_ProductionLines_Green
            // 
            label_ProductionLines_Green.AutoSize = true;
            label_ProductionLines_Green.ForeColor = Color.FromArgb(0, 97, 0);
            label_ProductionLines_Green.Location = new Point(21, 14);
            label_ProductionLines_Green.Margin = new Padding(4, 0, 4, 0);
            label_ProductionLines_Green.Name = "label_ProductionLines_Green";
            label_ProductionLines_Green.Size = new Size(159, 15);
            label_ProductionLines_Green.TabIndex = 0;
            label_ProductionLines_Green.Text = "Grön = Linjen är aktiv just nu";
            // 
            // pBox_Info
            // 
            pBox_Info.BackgroundImageLayout = ImageLayout.Center;
            pBox_Info.Dock = DockStyle.Top;
            pBox_Info.Location = new Point(0, 0);
            pBox_Info.Margin = new Padding(4, 3, 4, 3);
            pBox_Info.MaximumSize = new Size(35, 46);
            pBox_Info.MinimumSize = new Size(35, 46);
            pBox_Info.Name = "pBox_Info";
            pBox_Info.Size = new Size(35, 46);
            pBox_Info.SizeMode = PictureBoxSizeMode.Zoom;
            pBox_Info.TabIndex = 1;
            pBox_Info.TabStop = false;
            pBox_Info.MouseEnter += Info_MouseEnter;
            pBox_Info.MouseLeave += Info_MouseLeave;
            // 
            // label_ProductionLines_Header
            // 
            label_ProductionLines_Header.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_ProductionLines_Header.AutoSize = true;
            label_ProductionLines_Header.BackColor = Color.Transparent;
            label_ProductionLines_Header.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ProductionLines_Header.ForeColor = SystemColors.ActiveCaption;
            label_ProductionLines_Header.Location = new Point(376, 0);
            label_ProductionLines_Header.Margin = new Padding(4, 0, 4, 0);
            label_ProductionLines_Header.Name = "label_ProductionLines_Header";
            label_ProductionLines_Header.Size = new Size(238, 40);
            label_ProductionLines_Header.TabIndex = 0;
            label_ProductionLines_Header.Text = "ProduktionsLinjer";
            label_ProductionLines_Header.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Overview_ProductionLines
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Black;
            ClientSize = new Size(1703, 751);
            Controls.Add(panel_Main);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Overview_ProductionLines";
            Opacity = 0.9D;
            Text = "Överblick_ProduktionsLinjer";
            WindowState = FormWindowState.Maximized;
            Click += Close_Click;
            panel_Main.ResumeLayout(false);
            panel_Main.PerformLayout();
            ((ISupportInitialize)pBox_Close).EndInit();
            panel_Info.ResumeLayout(false);
            panel_Info.PerformLayout();
            ((ISupportInitialize)pBox_Info).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_UpdateInfo;
        private Panel panel_Main;
        private Label label_ProductionLines_Header;
        private PictureBox pBox_Info;
        private Panel panel_Info;
        private Label label_ProductionLines_Green;
        private Label label_ProductionLines_Red;
        private PictureBox pBox_Close;
        private Label label_ProductionLines_Info;
    }
}