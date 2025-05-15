
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class Main_Buttons
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
            flp_Buttons = new FlowLayoutPanel();
            Measureprotocol = new Button();
            Protocol = new Button();
            BrowseOldMeasureprotocol = new Button();
            BrowseOldOrders = new Button();
            Compound = new Button();
            Zumbach = new Button();
            OverviewProdlines = new Button();
            Statistics = new Button();
            Frequency_Marking = new Button();
            panel_Pictures = new Panel();
            pb_LoadPicture = new PictureBox();
            pb_UploadPicture = new PictureBox();
            flp_Buttons.SuspendLayout();
            panel_Pictures.SuspendLayout();
            ((ISupportInitialize)pb_LoadPicture).BeginInit();
            ((ISupportInitialize)pb_UploadPicture).BeginInit();
            SuspendLayout();
            // 
            // flp_Buttons
            // 
            flp_Buttons.BackColor = Color.Transparent;
            flp_Buttons.Controls.Add(Measureprotocol);
            flp_Buttons.Controls.Add(Protocol);
            flp_Buttons.Controls.Add(BrowseOldMeasureprotocol);
            flp_Buttons.Controls.Add(BrowseOldOrders);
            flp_Buttons.Controls.Add(Compound);
            flp_Buttons.Controls.Add(Zumbach);
            flp_Buttons.Controls.Add(OverviewProdlines);
            flp_Buttons.Controls.Add(Statistics);
            flp_Buttons.Controls.Add(Frequency_Marking);
            flp_Buttons.Controls.Add(panel_Pictures);
            flp_Buttons.Dock = DockStyle.Fill;
            flp_Buttons.Location = new Point(0, 0);
            flp_Buttons.Margin = new Padding(0);
            flp_Buttons.Name = "flp_Buttons";
            flp_Buttons.Size = new Size(1723, 50);
            flp_Buttons.TabIndex = 902;
            // 
            // Measureprotocol
            // 
            Measureprotocol.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 224, 192);
            Measureprotocol.FlatStyle = FlatStyle.Flat;
            Measureprotocol.ForeColor = Color.DarkGoldenrod;
            Measureprotocol.Location = new Point(2, 2);
            Measureprotocol.Margin = new Padding(2, 2, 0, 0);
            Measureprotocol.Name = "Measureprotocol";
            Measureprotocol.Size = new Size(124, 42);
            Measureprotocol.TabIndex = 878;
            Measureprotocol.Text = "F1-Mätprotokoll";
            Measureprotocol.UseVisualStyleBackColor = true;
            Measureprotocol.Click += F1_MeasureProtocol_Click;
            // 
            // Protocol
            // 
            Protocol.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 224, 192);
            Protocol.FlatStyle = FlatStyle.Flat;
            Protocol.ForeColor = Color.DarkGoldenrod;
            Protocol.Location = new Point(128, 2);
            Protocol.Margin = new Padding(2, 2, 0, 0);
            Protocol.Name = "Protocol";
            Protocol.Size = new Size(124, 42);
            Protocol.TabIndex = 879;
            Protocol.Text = "F2-Körprotokoll";
            Protocol.UseVisualStyleBackColor = true;
            Protocol.Click += F2_Protocol_Click;
            // 
            // BrowseOldMeasureprotocol
            // 
            BrowseOldMeasureprotocol.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 224, 192);
            BrowseOldMeasureprotocol.FlatStyle = FlatStyle.Flat;
            BrowseOldMeasureprotocol.ForeColor = Color.DarkGoldenrod;
            BrowseOldMeasureprotocol.Location = new Point(254, 2);
            BrowseOldMeasureprotocol.Margin = new Padding(2, 2, 0, 0);
            BrowseOldMeasureprotocol.Name = "BrowseOldMeasureprotocol";
            BrowseOldMeasureprotocol.Size = new Size(124, 42);
            BrowseOldMeasureprotocol.TabIndex = 880;
            BrowseOldMeasureprotocol.Text = "F3-Bläddra gamla Mätprotokoll";
            BrowseOldMeasureprotocol.UseVisualStyleBackColor = true;
            BrowseOldMeasureprotocol.Click += F3_SearchOldMeasureProtocols_Click;
            // 
            // BrowseOldOrders
            // 
            BrowseOldOrders.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 224, 192);
            BrowseOldOrders.FlatStyle = FlatStyle.Flat;
            BrowseOldOrders.ForeColor = Color.DarkGoldenrod;
            BrowseOldOrders.Location = new Point(380, 2);
            BrowseOldOrders.Margin = new Padding(2, 2, 0, 0);
            BrowseOldOrders.Name = "BrowseOldOrders";
            BrowseOldOrders.Size = new Size(124, 42);
            BrowseOldOrders.TabIndex = 881;
            BrowseOldOrders.Text = "F4-Bläddra gamla Ordrar";
            BrowseOldOrders.UseVisualStyleBackColor = true;
            BrowseOldOrders.Click += F4_SearchOldProtocols;
            // 
            // Compound
            // 
            Compound.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 224, 192);
            Compound.FlatStyle = FlatStyle.Flat;
            Compound.ForeColor = Color.DarkGoldenrod;
            Compound.Location = new Point(506, 2);
            Compound.Margin = new Padding(2, 2, 0, 0);
            Compound.Name = "Compound";
            Compound.Size = new Size(171, 42);
            Compound.TabIndex = 882;
            Compound.Text = "F5-Kompounderingsblankett";
            Compound.UseVisualStyleBackColor = true;
            Compound.Click += F5_Compund_Click;
            // 
            // Zumbach
            // 
            Zumbach.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 224, 192);
            Zumbach.FlatStyle = FlatStyle.Flat;
            Zumbach.ForeColor = Color.DarkGoldenrod;
            Zumbach.Location = new Point(679, 2);
            Zumbach.Margin = new Padding(2, 2, 0, 0);
            Zumbach.Name = "Zumbach";
            Zumbach.Size = new Size(171, 42);
            Zumbach.TabIndex = 883;
            Zumbach.Text = "F6-Zumbach-mätning";
            Zumbach.UseVisualStyleBackColor = true;
            Zumbach.Click += F6_Zumbach_Click;
            // 
            // OverviewProdlines
            // 
            OverviewProdlines.AutoSize = true;
            OverviewProdlines.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 224, 192);
            OverviewProdlines.FlatStyle = FlatStyle.Flat;
            OverviewProdlines.ForeColor = Color.DarkGoldenrod;
            OverviewProdlines.Location = new Point(852, 2);
            OverviewProdlines.Margin = new Padding(2, 2, 0, 0);
            OverviewProdlines.Name = "OverviewProdlines";
            OverviewProdlines.Size = new Size(179, 42);
            OverviewProdlines.TabIndex = 884;
            OverviewProdlines.Text = "F7-Överblick Produktionslinjer";
            OverviewProdlines.UseVisualStyleBackColor = true;
            OverviewProdlines.Click += F7_OverviewProdLines_Click;
            // 
            // Statistics
            // 
            Statistics.AutoSize = true;
            Statistics.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 224, 192);
            Statistics.FlatStyle = FlatStyle.Flat;
            Statistics.ForeColor = Color.DarkGoldenrod;
            Statistics.Location = new Point(1033, 2);
            Statistics.Margin = new Padding(2, 2, 0, 0);
            Statistics.Name = "Statistics";
            Statistics.Size = new Size(86, 42);
            Statistics.TabIndex = 885;
            Statistics.Text = "F8-Statistik";
            Statistics.UseVisualStyleBackColor = true;
            Statistics.Click += F8_Statistics_Click;
            // 
            // Frequency_Marking
            // 
            Frequency_Marking.AutoSize = true;
            Frequency_Marking.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 224, 192);
            Frequency_Marking.FlatStyle = FlatStyle.Flat;
            Frequency_Marking.ForeColor = Color.DarkGoldenrod;
            Frequency_Marking.Location = new Point(1121, 2);
            Frequency_Marking.Margin = new Padding(2, 2, 0, 0);
            Frequency_Marking.Name = "Frequency_Marking";
            Frequency_Marking.Size = new Size(141, 42);
            Frequency_Marking.TabIndex = 886;
            Frequency_Marking.Text = "F9-Frekvens-markering";
            Frequency_Marking.UseVisualStyleBackColor = true;
            // 
            // panel_Pictures
            // 
            panel_Pictures.BackColor = Color.Transparent;
            panel_Pictures.BorderStyle = BorderStyle.FixedSingle;
            panel_Pictures.Controls.Add(pb_LoadPicture);
            panel_Pictures.Controls.Add(pb_UploadPicture);
            panel_Pictures.Location = new Point(1268, 2);
            panel_Pictures.Margin = new Padding(6, 2, 0, 2);
            panel_Pictures.MinimumSize = new Size(136, 45);
            panel_Pictures.Name = "panel_Pictures";
            panel_Pictures.Size = new Size(169, 45);
            panel_Pictures.TabIndex = 876;
            panel_Pictures.Visible = false;
            panel_Pictures.MouseEnter += Buttons_MouseEnter;
            panel_Pictures.MouseLeave += Buttons_MouseLeave;
            // 
            // pb_LoadPicture
            // 
            pb_LoadPicture.BackColor = Color.Transparent;
            pb_LoadPicture.BackgroundImageLayout = ImageLayout.Zoom;
            pb_LoadPicture.Cursor = Cursors.Hand;
            pb_LoadPicture.Image = Properties.Resources.pictures2;
            pb_LoadPicture.Location = new Point(9, 2);
            pb_LoadPicture.Margin = new Padding(4, 3, 4, 3);
            pb_LoadPicture.Name = "pb_LoadPicture";
            pb_LoadPicture.Size = new Size(41, 40);
            pb_LoadPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_LoadPicture.TabIndex = 835;
            pb_LoadPicture.TabStop = false;
            pb_LoadPicture.Click += TittaPåBilder_Click;
            // 
            // pb_UploadPicture
            // 
            pb_UploadPicture.BackColor = Color.Transparent;
            pb_UploadPicture.BackgroundImageLayout = ImageLayout.Zoom;
            pb_UploadPicture.Cursor = Cursors.Hand;
            pb_UploadPicture.Image = Properties.Resources.camera2;
            pb_UploadPicture.Location = new Point(108, 3);
            pb_UploadPicture.Margin = new Padding(4, 3, 4, 3);
            pb_UploadPicture.Name = "pb_UploadPicture";
            pb_UploadPicture.Size = new Size(41, 40);
            pb_UploadPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_UploadPicture.TabIndex = 836;
            pb_UploadPicture.TabStop = false;
            pb_UploadPicture.Click += UploadPicture_Click;
            // 
            // Main_Buttons
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(flp_Buttons);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main_Buttons";
            Size = new Size(1723, 50);
            flp_Buttons.ResumeLayout(false);
            flp_Buttons.PerformLayout();
            panel_Pictures.ResumeLayout(false);
            ((ISupportInitialize)pb_LoadPicture).EndInit();
            ((ISupportInitialize)pb_UploadPicture).EndInit();
            ResumeLayout(false);

        }

        #endregion

        public FlowLayoutPanel flp_Buttons;
        public PictureBox pb_LoadPicture;
        public PictureBox pb_UploadPicture;
        public Panel panel_Pictures;
        public Button Measureprotocol;
        public Button Protocol;
        public Button BrowseOldMeasureprotocol;
        public Button BrowseOldOrders;
        public Button Compound;
        public Button Zumbach;
        public Button OverviewProdlines;
        public Button Statistics;
        public Button Frequency_Marking;
    }
}
