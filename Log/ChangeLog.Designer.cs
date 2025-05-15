namespace DigitalProductionProgram.Log
{
    partial class ChangeLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            panel_Left = new Panel();
            flp_Versions = new FlowLayoutPanel();
            label_ReleaseDate = new Label();
            flp_Descriptions = new FlowLayoutPanel();
            splitter1 = new Splitter();
            panel_TitleBar = new Panel();
            btn_Minimize = new Button();
            btn_Close = new Button();
            panel_Left.SuspendLayout();
            panel_TitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Left
            // 
            panel_Left.BackColor = Color.FromArgb(6, 81, 87);
            panel_Left.Controls.Add(flp_Versions);
            panel_Left.Controls.Add(label_ReleaseDate);
            panel_Left.Dock = DockStyle.Left;
            panel_Left.Location = new Point(0, 39);
            panel_Left.Margin = new Padding(4, 3, 4, 3);
            panel_Left.MinimumSize = new Size(210, 0);
            panel_Left.Name = "panel_Left";
            panel_Left.Size = new Size(310, 781);
            panel_Left.TabIndex = 0;
            // 
            // flp_Versions
            // 
            flp_Versions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flp_Versions.AutoSize = true;
            flp_Versions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flp_Versions.FlowDirection = FlowDirection.TopDown;
            flp_Versions.Location = new Point(4, 156);
            flp_Versions.Margin = new Padding(4, 3, 4, 3);
            flp_Versions.Name = "flp_Versions";
            flp_Versions.Size = new Size(0, 0);
            flp_Versions.TabIndex = 1;
            // 
            // label_ReleaseDate
            // 
            label_ReleaseDate.AutoSize = true;
            label_ReleaseDate.Dock = DockStyle.Top;
            label_ReleaseDate.Font = new Font("Lucida Sans", 9F);
            label_ReleaseDate.ForeColor = Color.FromArgb(147, 146, 153);
            label_ReleaseDate.Location = new Point(0, 0);
            label_ReleaseDate.Margin = new Padding(4, 0, 4, 0);
            label_ReleaseDate.Name = "label_ReleaseDate";
            label_ReleaseDate.Padding = new Padding(47, 0, 0, 0);
            label_ReleaseDate.Size = new Size(126, 15);
            label_ReleaseDate.TabIndex = 0;
            label_ReleaseDate.Text = "2025-04-09";
            // 
            // flp_Descriptions
            // 
            flp_Descriptions.AutoScroll = true;
            flp_Descriptions.BackColor = Color.FromArgb(63, 115, 140);
            flp_Descriptions.Dock = DockStyle.Fill;
            flp_Descriptions.FlowDirection = FlowDirection.TopDown;
            flp_Descriptions.Location = new Point(310, 39);
            flp_Descriptions.Margin = new Padding(35, 3, 4, 3);
            flp_Descriptions.Name = "flp_Descriptions";
            flp_Descriptions.Padding = new Padding(6, 0, 0, 0);
            flp_Descriptions.Size = new Size(823, 781);
            flp_Descriptions.TabIndex = 1;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(310, 39);
            splitter1.Margin = new Padding(4, 3, 4, 3);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(7, 781);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // panel_TitleBar
            // 
            panel_TitleBar.BackColor = Color.FromArgb(6, 81, 87);
            panel_TitleBar.Controls.Add(btn_Minimize);
            panel_TitleBar.Controls.Add(btn_Close);
            panel_TitleBar.Dock = DockStyle.Top;
            panel_TitleBar.Location = new Point(0, 0);
            panel_TitleBar.Margin = new Padding(4, 3, 4, 3);
            panel_TitleBar.Name = "panel_TitleBar";
            panel_TitleBar.Size = new Size(1133, 39);
            panel_TitleBar.TabIndex = 3;
            panel_TitleBar.MouseDown += TitleBar_MouseDown;
            panel_TitleBar.MouseMove += TitleBar_MouseMove;
            panel_TitleBar.MouseUp += TitleBar_MouseUp;
            // 
            // btn_Minimize
            // 
            btn_Minimize.Dock = DockStyle.Right;
            btn_Minimize.FlatAppearance.BorderSize = 0;
            btn_Minimize.FlatStyle = FlatStyle.Flat;
            btn_Minimize.Font = new Font("Segoe UI", 10F);
            btn_Minimize.ForeColor = Color.FromArgb(239, 228, 177);
            btn_Minimize.Location = new Point(1046, 0);
            btn_Minimize.Margin = new Padding(0);
            btn_Minimize.Name = "btn_Minimize";
            btn_Minimize.Size = new Size(50, 39);
            btn_Minimize.TabIndex = 1;
            btn_Minimize.Text = "__";
            btn_Minimize.TextAlign = ContentAlignment.BottomCenter;
            btn_Minimize.UseVisualStyleBackColor = true;
            btn_Minimize.Click += Minimize_Click;
            // 
            // btn_Close
            // 
            btn_Close.Dock = DockStyle.Right;
            btn_Close.FlatAppearance.BorderSize = 0;
            btn_Close.FlatStyle = FlatStyle.Flat;
            btn_Close.Font = new Font("Segoe UI", 10F);
            btn_Close.ForeColor = Color.FromArgb(239, 228, 177);
            btn_Close.Location = new Point(1096, 0);
            btn_Close.Margin = new Padding(0);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(37, 39);
            btn_Close.TabIndex = 0;
            btn_Close.Text = "X";
            btn_Close.TextAlign = ContentAlignment.BottomCenter;
            btn_Close.UseVisualStyleBackColor = true;
            btn_Close.Click += Close_Click;
            // 
            // ChangeLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(1133, 820);
            Controls.Add(splitter1);
            Controls.Add(flp_Descriptions);
            Controls.Add(panel_Left);
            Controls.Add(panel_TitleBar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ChangeLog";
            Text = "ChangeLog";
            FormClosing += ChangeLog_FormClosing;
            panel_Left.ResumeLayout(false);
            panel_Left.PerformLayout();
            panel_TitleBar.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Label label_ReleaseDate;
        private System.Windows.Forms.FlowLayoutPanel flp_Descriptions;
        private System.Windows.Forms.FlowLayoutPanel flp_Versions;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel_TitleBar;
        private System.Windows.Forms.Button btn_Minimize;
        private System.Windows.Forms.Button btn_Close;
    }
}