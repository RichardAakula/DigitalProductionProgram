using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Help
{
    partial class InfoText
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(InfoText));
            flp_Img = new FlowLayoutPanel();
            lbl_img_1 = new Label();
            lbl_img_2 = new Label();
            lbl_img_3 = new Label();
            lbl_img_4 = new Label();
            lbl_img_5 = new Label();
            lbl_Video = new Label();
            lbl_Rubrik = new Label();
            tlp_Buttons = new TableLayoutPanel();
            btn_No = new Button();
            btn_Ok = new Button();
            btn_Yes = new Button();
            panel_Text = new Panel();
            lbl_Message = new Label();
            tlp_Main = new TableLayoutPanel();
            pb_Line_Bottom = new PictureBox();
            pb_Line_Top = new PictureBox();
            pb_Tube = new PictureBox();
            flp_Img.SuspendLayout();
            tlp_Buttons.SuspendLayout();
            panel_Text.SuspendLayout();
            tlp_Main.SuspendLayout();
            ((ISupportInitialize)pb_Line_Bottom).BeginInit();
            ((ISupportInitialize)pb_Line_Top).BeginInit();
            ((ISupportInitialize)pb_Tube).BeginInit();
            SuspendLayout();
            // 
            // flp_Img
            // 
            flp_Img.BackColor = Color.Transparent;
            flp_Img.Controls.Add(lbl_img_1);
            flp_Img.Controls.Add(lbl_img_2);
            flp_Img.Controls.Add(lbl_img_3);
            flp_Img.Controls.Add(lbl_img_4);
            flp_Img.Controls.Add(lbl_img_5);
            flp_Img.Controls.Add(lbl_Video);
            flp_Img.Dock = DockStyle.Fill;
            flp_Img.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            flp_Img.ForeColor = SystemColors.HotTrack;
            flp_Img.Location = new Point(1643, 197);
            flp_Img.Margin = new Padding(4, 3, 4, 3);
            flp_Img.Name = "flp_Img";
            flp_Img.Size = new Size(225, 296);
            flp_Img.TabIndex = 2;
            // 
            // lbl_img_1
            // 
            lbl_img_1.AutoSize = true;
            lbl_img_1.Cursor = Cursors.Hand;
            lbl_img_1.Location = new Point(4, 0);
            lbl_img_1.Margin = new Padding(4, 0, 4, 0);
            lbl_img_1.Name = "lbl_img_1";
            lbl_img_1.Size = new Size(42, 18);
            lbl_img_1.TabIndex = 0;
            lbl_img_1.Text = "Bild 1";
            lbl_img_1.Visible = false;
            lbl_img_1.Click += Img_Click;
            // 
            // lbl_img_2
            // 
            lbl_img_2.AutoSize = true;
            lbl_img_2.Cursor = Cursors.Hand;
            lbl_img_2.Location = new Point(54, 0);
            lbl_img_2.Margin = new Padding(4, 0, 4, 0);
            lbl_img_2.Name = "lbl_img_2";
            lbl_img_2.Size = new Size(42, 18);
            lbl_img_2.TabIndex = 0;
            lbl_img_2.Text = "Bild 2";
            lbl_img_2.Visible = false;
            lbl_img_2.Click += Img_Click;
            // 
            // lbl_img_3
            // 
            lbl_img_3.AutoSize = true;
            lbl_img_3.Cursor = Cursors.Hand;
            lbl_img_3.Location = new Point(104, 0);
            lbl_img_3.Margin = new Padding(4, 0, 4, 0);
            lbl_img_3.Name = "lbl_img_3";
            lbl_img_3.Size = new Size(42, 18);
            lbl_img_3.TabIndex = 0;
            lbl_img_3.Text = "Bild 3";
            lbl_img_3.Visible = false;
            lbl_img_3.Click += Img_Click;
            // 
            // lbl_img_4
            // 
            lbl_img_4.AutoSize = true;
            lbl_img_4.Cursor = Cursors.Hand;
            lbl_img_4.Location = new Point(154, 0);
            lbl_img_4.Margin = new Padding(4, 0, 4, 0);
            lbl_img_4.Name = "lbl_img_4";
            lbl_img_4.Size = new Size(42, 18);
            lbl_img_4.TabIndex = 0;
            lbl_img_4.Text = "Bild 4";
            lbl_img_4.Visible = false;
            lbl_img_4.Click += Img_Click;
            // 
            // lbl_img_5
            // 
            lbl_img_5.AutoSize = true;
            lbl_img_5.Cursor = Cursors.Hand;
            lbl_img_5.Location = new Point(4, 18);
            lbl_img_5.Margin = new Padding(4, 0, 4, 0);
            lbl_img_5.Name = "lbl_img_5";
            lbl_img_5.Size = new Size(42, 18);
            lbl_img_5.TabIndex = 0;
            lbl_img_5.Text = "Bild 5";
            lbl_img_5.Visible = false;
            lbl_img_5.Click += Img_Click;
            // 
            // lbl_Video
            // 
            lbl_Video.AutoSize = true;
            lbl_Video.Cursor = Cursors.Hand;
            lbl_Video.Location = new Point(54, 18);
            lbl_Video.Margin = new Padding(4, 0, 4, 0);
            lbl_Video.Name = "lbl_Video";
            lbl_Video.Size = new Size(43, 18);
            lbl_Video.TabIndex = 1;
            lbl_Video.Text = "Video";
            lbl_Video.Visible = false;
            lbl_Video.Click += Video_Click;
            // 
            // lbl_Rubrik
            // 
            lbl_Rubrik.AutoSize = true;
            lbl_Rubrik.BackColor = Color.Transparent;
            lbl_Rubrik.Dock = DockStyle.Fill;
            lbl_Rubrik.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Rubrik.ForeColor = Color.FromArgb(171, 150, 85);
            lbl_Rubrik.Location = new Point(233, 7);
            lbl_Rubrik.Margin = new Padding(0, 1, 0, 0);
            lbl_Rubrik.Name = "lbl_Rubrik";
            lbl_Rubrik.Size = new Size(1406, 34);
            lbl_Rubrik.TabIndex = 6;
            lbl_Rubrik.Text = "Rubrik";
            lbl_Rubrik.TextAlign = ContentAlignment.TopCenter;
            lbl_Rubrik.Visible = false;
            // 
            // tlp_Buttons
            // 
            tlp_Buttons.BackColor = Color.Transparent;
            tlp_Buttons.ColumnCount = 5;
            tlp_Buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tlp_Buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tlp_Buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tlp_Buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Buttons.Controls.Add(btn_No, 3, 0);
            tlp_Buttons.Controls.Add(btn_Ok, 2, 0);
            tlp_Buttons.Controls.Add(btn_Yes, 1, 0);
            tlp_Buttons.Dock = DockStyle.Fill;
            tlp_Buttons.Location = new Point(237, 499);
            tlp_Buttons.Margin = new Padding(4, 3, 4, 3);
            tlp_Buttons.Name = "tlp_Buttons";
            tlp_Buttons.RowCount = 1;
            tlp_Buttons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Buttons.Size = new Size(1398, 44);
            tlp_Buttons.TabIndex = 7;
            // 
            // btn_No
            // 
            btn_No.BackColor = Color.FromArgb(255, 199, 206);
            btn_No.Cursor = Cursors.Hand;
            btn_No.Dock = DockStyle.Fill;
            btn_No.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 179, 186);
            btn_No.FlatStyle = FlatStyle.Flat;
            btn_No.Font = new Font("Palatino Linotype", 14F, FontStyle.Bold);
            btn_No.ForeColor = Color.FromArgb(156, 0, 6);
            btn_No.Location = new Point(786, 0);
            btn_No.Margin = new Padding(0);
            btn_No.Name = "btn_No";
            btn_No.Size = new Size(175, 44);
            btn_No.TabIndex = 6;
            btn_No.Text = "Nej";
            btn_No.TextAlign = ContentAlignment.TopCenter;
            btn_No.UseVisualStyleBackColor = false;
            btn_No.Click += No_Click;
            // 
            // btn_Ok
            // 
            btn_Ok.BackColor = Color.FromArgb(180, 198, 231);
            btn_Ok.Cursor = Cursors.Hand;
            btn_Ok.Dock = DockStyle.Fill;
            btn_Ok.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 178, 211);
            btn_Ok.FlatStyle = FlatStyle.Flat;
            btn_Ok.Font = new Font("Palatino Linotype", 14F, FontStyle.Bold);
            btn_Ok.ForeColor = Color.DarkSlateGray;
            btn_Ok.Location = new Point(634, 0);
            btn_Ok.Margin = new Padding(23, 0, 23, 0);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(129, 44);
            btn_Ok.TabIndex = 5;
            btn_Ok.Text = "Ok";
            btn_Ok.TextAlign = ContentAlignment.TopCenter;
            btn_Ok.UseVisualStyleBackColor = false;
            btn_Ok.Click += Ok_Click;
            // 
            // btn_Yes
            // 
            btn_Yes.BackColor = Color.FromArgb(198, 239, 206);
            btn_Yes.Cursor = Cursors.Hand;
            btn_Yes.Dock = DockStyle.Fill;
            btn_Yes.FlatAppearance.MouseOverBackColor = Color.FromArgb(178, 219, 186);
            btn_Yes.FlatStyle = FlatStyle.Flat;
            btn_Yes.Font = new Font("Palatino Linotype", 14F, FontStyle.Bold);
            btn_Yes.ForeColor = Color.FromArgb(0, 97, 0);
            btn_Yes.Location = new Point(436, 0);
            btn_Yes.Margin = new Padding(0);
            btn_Yes.Name = "btn_Yes";
            btn_Yes.Size = new Size(175, 44);
            btn_Yes.TabIndex = 4;
            btn_Yes.Text = "Ja";
            btn_Yes.TextAlign = ContentAlignment.TopCenter;
            btn_Yes.UseVisualStyleBackColor = false;
            btn_Yes.Click += Yes_Click;
            // 
            // panel_Text
            // 
            panel_Text.AutoScroll = true;
            panel_Text.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Text.BackColor = Color.Transparent;
            tlp_Main.SetColumnSpan(panel_Text, 2);
            panel_Text.Controls.Add(lbl_Message);
            panel_Text.Dock = DockStyle.Fill;
            panel_Text.Location = new Point(233, 42);
            panel_Text.Margin = new Padding(0, 1, 0, 0);
            panel_Text.Name = "panel_Text";
            panel_Text.Size = new Size(1639, 152);
            panel_Text.TabIndex = 10;
            panel_Text.Click += InfoText_Close_Click;
            // 
            // lbl_Message
            // 
            lbl_Message.AutoSize = true;
            lbl_Message.BackColor = Color.Transparent;
            lbl_Message.Cursor = Cursors.Hand;
            lbl_Message.Dock = DockStyle.Fill;
            lbl_Message.Font = new Font("Lucida Sans", 10.25F);
            lbl_Message.ForeColor = Color.FromArgb(181, 210, 207);
            lbl_Message.Location = new Point(0, 0);
            lbl_Message.Margin = new Padding(4, 0, 4, 0);
            lbl_Message.Name = "lbl_Message";
            lbl_Message.Size = new Size(88, 16);
            lbl_Message.TabIndex = 1;
            lbl_Message.Text = "Meddelande";
            lbl_Message.TextAlign = ContentAlignment.MiddleLeft;
            lbl_Message.Click += InfoText_Close_Click;
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Transparent;
            tlp_Main.ColumnCount = 3;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 233F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 233F));
            tlp_Main.Controls.Add(pb_Line_Bottom, 0, 5);
            tlp_Main.Controls.Add(lbl_Rubrik, 1, 1);
            tlp_Main.Controls.Add(panel_Text, 1, 2);
            tlp_Main.Controls.Add(tlp_Buttons, 1, 4);
            tlp_Main.Controls.Add(flp_Img, 2, 3);
            tlp_Main.Controls.Add(pb_Line_Top, 0, 0);
            tlp_Main.Controls.Add(pb_Tube, 0, 3);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 6;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 6F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 302F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 6F));
            tlp_Main.Size = new Size(1872, 552);
            tlp_Main.TabIndex = 11;
            tlp_Main.Click += InfoText_Close_Click;
            // 
            // pb_Line_Bottom
            // 
            pb_Line_Bottom.BackgroundImageLayout = ImageLayout.Center;
            tlp_Main.SetColumnSpan(pb_Line_Bottom, 3);
            pb_Line_Bottom.Dock = DockStyle.Fill;
            pb_Line_Bottom.Image = (Image)resources.GetObject("pb_Line_Bottom.Image");
            pb_Line_Bottom.Location = new Point(0, 546);
            pb_Line_Bottom.Margin = new Padding(0);
            pb_Line_Bottom.MaximumSize = new Size(0, 6);
            pb_Line_Bottom.MinimumSize = new Size(0, 6);
            pb_Line_Bottom.Name = "pb_Line_Bottom";
            pb_Line_Bottom.Size = new Size(1872, 6);
            pb_Line_Bottom.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_Line_Bottom.TabIndex = 12;
            pb_Line_Bottom.TabStop = false;
            // 
            // pb_Line_Top
            // 
            pb_Line_Top.BackgroundImageLayout = ImageLayout.Center;
            tlp_Main.SetColumnSpan(pb_Line_Top, 3);
            pb_Line_Top.Dock = DockStyle.Fill;
            pb_Line_Top.Image = (Image)resources.GetObject("pb_Line_Top.Image");
            pb_Line_Top.Location = new Point(0, 0);
            pb_Line_Top.Margin = new Padding(0);
            pb_Line_Top.MaximumSize = new Size(0, 6);
            pb_Line_Top.MinimumSize = new Size(0, 6);
            pb_Line_Top.Name = "pb_Line_Top";
            pb_Line_Top.Size = new Size(1872, 6);
            pb_Line_Top.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_Line_Top.TabIndex = 11;
            pb_Line_Top.TabStop = false;
            // 
            // pb_Tube
            // 
            pb_Tube.BackColor = Color.Transparent;
            pb_Tube.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Tube.Dock = DockStyle.Right;
            pb_Tube.Location = new Point(4, 197);
            pb_Tube.Margin = new Padding(4, 3, 4, 3);
            pb_Tube.Name = "pb_Tube";
            tlp_Main.SetRowSpan(pb_Tube, 2);
            pb_Tube.Size = new Size(225, 346);
            pb_Tube.TabIndex = 13;
            pb_Tube.TabStop = false;
            // 
            // InfoText
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(6, 71, 77);
            ClientSize = new Size(1872, 552);
            Controls.Add(tlp_Main);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "InfoText";
            Opacity = 0.95D;
            StartPosition = FormStartPosition.CenterParent;
            Text = "InfoText";
            TopMost = true;
            FormClosed += InfoText_FormClosed;
            Click += InfoText_Close_Click;
            flp_Img.ResumeLayout(false);
            flp_Img.PerformLayout();
            tlp_Buttons.ResumeLayout(false);
            panel_Text.ResumeLayout(false);
            panel_Text.PerformLayout();
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ((ISupportInitialize)pb_Line_Bottom).EndInit();
            ((ISupportInitialize)pb_Line_Top).EndInit();
            ((ISupportInitialize)pb_Tube).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private FlowLayoutPanel flp_Img;
        private Label lbl_img_1;
        private Label lbl_img_2;
        private Label lbl_img_3;
        private Label lbl_img_5;
        private Label lbl_img_4;
        // private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private Label lbl_Video;
        private Label lbl_Rubrik;
        private TableLayoutPanel tlp_Buttons;
        private Panel panel_Text;
        private Label lbl_Message;
        private TableLayoutPanel tlp_Main;
        private Button btn_Ok;
        private Button btn_Yes;
        private Button btn_No;
        private PictureBox pb_Line_Bottom;
        private PictureBox pb_Line_Top;
        private PictureBox pb_Tube;
    }
}