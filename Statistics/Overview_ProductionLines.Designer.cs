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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Overview_ProductionLines));
            this.timer_UpdateInfo = new System.Windows.Forms.Timer(this.components);
            this.panel_Main = new System.Windows.Forms.Panel();
            this.pBox_Close = new System.Windows.Forms.PictureBox();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.label_ProductionLines_Info = new System.Windows.Forms.Label();
            this.label_ProductionLines_Red = new System.Windows.Forms.Label();
            this.label_ProductionLines_Green = new System.Windows.Forms.Label();
            this.pBox_Info = new System.Windows.Forms.PictureBox();
            this.label_ProductionLines_Header = new System.Windows.Forms.Label();
            this.panel_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Close)).BeginInit();
            this.panel_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_UpdateInfo
            // 
            this.timer_UpdateInfo.Interval = 1000;
            // 
            // panel_Main
            // 
            this.panel_Main.AutoScroll = true;
            this.panel_Main.Controls.Add(this.pBox_Close);
            this.panel_Main.Controls.Add(this.panel_Info);
            this.panel_Main.Controls.Add(this.pBox_Info);
            this.panel_Main.Controls.Add(this.label_ProductionLines_Header);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Main.Location = new System.Drawing.Point(0, 0);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(1460, 651);
            this.panel_Main.TabIndex = 0;
            this.panel_Main.Click += new System.EventHandler(this.Close_Click);
            // 
            // pBox_Close
            // 
            this.pBox_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBox_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBox_Close.Image = ((System.Drawing.Image)(resources.GetObject("pBox_Close.Image")));
            this.pBox_Close.Location = new System.Drawing.Point(31, 0);
            this.pBox_Close.MaximumSize = new System.Drawing.Size(30, 40);
            this.pBox_Close.MinimumSize = new System.Drawing.Size(30, 40);
            this.pBox_Close.Name = "pBox_Close";
            this.pBox_Close.Size = new System.Drawing.Size(30, 40);
            this.pBox_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox_Close.TabIndex = 3;
            this.pBox_Close.TabStop = false;
            this.pBox_Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // panel_Info
            // 
            this.panel_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Info.Controls.Add(this.label_ProductionLines_Info);
            this.panel_Info.Controls.Add(this.label_ProductionLines_Red);
            this.panel_Info.Controls.Add(this.label_ProductionLines_Green);
            this.panel_Info.Location = new System.Drawing.Point(62, 0);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(260, 84);
            this.panel_Info.TabIndex = 2;
            this.panel_Info.Visible = false;
            // 
            // label_ProductionLines_Info
            // 
            this.label_ProductionLines_Info.AutoSize = true;
            this.label_ProductionLines_Info.ForeColor = System.Drawing.SystemColors.Info;
            this.label_ProductionLines_Info.Location = new System.Drawing.Point(16, 54);
            this.label_ProductionLines_Info.Name = "label_ProductionLines_Info";
            this.label_ProductionLines_Info.Size = new System.Drawing.Size(137, 13);
            this.label_ProductionLines_Info.TabIndex = 0;
            this.label_ProductionLines_Info.Text = "Klicka på Linjen för mer info";
            // 
            // label_ProductionLines_Red
            // 
            this.label_ProductionLines_Red.AutoSize = true;
            this.label_ProductionLines_Red.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.label_ProductionLines_Red.Location = new System.Drawing.Point(16, 33);
            this.label_ProductionLines_Red.Name = "label_ProductionLines_Red";
            this.label_ProductionLines_Red.Size = new System.Drawing.Size(147, 13);
            this.label_ProductionLines_Red.TabIndex = 0;
            this.label_ProductionLines_Red.Text = "Röd = Linjen är inaktiv just nu";
            // 
            // label_ProductionLines_Green
            // 
            this.label_ProductionLines_Green.AutoSize = true;
            this.label_ProductionLines_Green.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.label_ProductionLines_Green.Location = new System.Drawing.Point(18, 12);
            this.label_ProductionLines_Green.Name = "label_ProductionLines_Green";
            this.label_ProductionLines_Green.Size = new System.Drawing.Size(142, 13);
            this.label_ProductionLines_Green.TabIndex = 0;
            this.label_ProductionLines_Green.Text = "Grön = Linjen är aktiv just nu";
            // 
            // pBox_Info
            // 
            this.pBox_Info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBox_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBox_Info.Location = new System.Drawing.Point(0, 0);
            this.pBox_Info.MaximumSize = new System.Drawing.Size(30, 40);
            this.pBox_Info.MinimumSize = new System.Drawing.Size(30, 40);
            this.pBox_Info.Name = "pBox_Info";
            this.pBox_Info.Size = new System.Drawing.Size(30, 40);
            this.pBox_Info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox_Info.TabIndex = 1;
            this.pBox_Info.TabStop = false;
            this.pBox_Info.MouseEnter += new System.EventHandler(this.Info_MouseEnter);
            this.pBox_Info.MouseLeave += new System.EventHandler(this.Info_MouseLeave);
            // 
            // label_ProductionLines_Header
            // 
            this.label_ProductionLines_Header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ProductionLines_Header.AutoSize = true;
            this.label_ProductionLines_Header.BackColor = System.Drawing.Color.Transparent;
            this.label_ProductionLines_Header.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProductionLines_Header.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_ProductionLines_Header.Location = new System.Drawing.Point(322, 0);
            this.label_ProductionLines_Header.Name = "label_ProductionLines_Header";
            this.label_ProductionLines_Header.Size = new System.Drawing.Size(238, 40);
            this.label_ProductionLines_Header.TabIndex = 0;
            this.label_ProductionLines_Header.Text = "ProduktionsLinjer";
            this.label_ProductionLines_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Overview_ProductionLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1460, 651);
            this.Controls.Add(this.panel_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Overview_ProductionLines";
            this.Opacity = 0.9D;
            this.Text = "Överblick_ProduktionsLinjer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Click += new System.EventHandler(this.Close_Click);
            this.panel_Main.ResumeLayout(false);
            this.panel_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Close)).EndInit();
            this.panel_Info.ResumeLayout(false);
            this.panel_Info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Info)).EndInit();
            this.ResumeLayout(false);

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