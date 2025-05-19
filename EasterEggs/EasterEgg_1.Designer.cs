using System.ComponentModel;

namespace DigitalProductionProgram.EasterEggs
{
    partial class EasterEgg_1
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
            panel_GameArea = new Panel();
            lbl_Start_Game = new Label();
            timer = new System.Windows.Forms.Timer(components);
            lbl_Timer = new Label();
            lbl_Points = new Label();
            lbl_Level = new Label();
            label_Level = new Label();
            label_Poäng = new Label();
            label_Tid = new Label();
            label_Total_Poäng = new Label();
            lbl_Total_Poäng = new Label();
            dgv_HighScore = new DataGridView();
            label_Info = new Label();
            lbl_Avsluta = new Label();
            dgv_Text = new DataGridView();
            Text = new DataGridViewTextBoxColumn();
            ((ISupportInitialize)dgv_HighScore).BeginInit();
            ((ISupportInitialize)dgv_Text).BeginInit();
            SuspendLayout();
            // 
            // panel_GameArea
            // 
            panel_GameArea.BackColor = Color.FromArgb(25, 25, 25);
            panel_GameArea.Location = new Point(35, 69);
            panel_GameArea.Margin = new Padding(4, 3, 4, 3);
            panel_GameArea.Name = "panel_GameArea";
            panel_GameArea.Size = new Size(1219, 747);
            panel_GameArea.TabIndex = 0;
            // 
            // lbl_Start_Game
            // 
            lbl_Start_Game.AutoSize = true;
            lbl_Start_Game.Cursor = Cursors.Hand;
            lbl_Start_Game.Font = new Font("Malgun Gothic", 16F);
            lbl_Start_Game.ForeColor = Color.FromArgb(0, 97, 0);
            lbl_Start_Game.Location = new Point(1301, 10);
            lbl_Start_Game.Margin = new Padding(4, 0, 4, 0);
            lbl_Start_Game.Name = "lbl_Start_Game";
            lbl_Start_Game.Size = new Size(121, 30);
            lbl_Start_Game.TabIndex = 1;
            lbl_Start_Game.Text = "Starta Spel";
            lbl_Start_Game.Click += lbl_Start_Game_Click;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // lbl_Timer
            // 
            lbl_Timer.AutoSize = true;
            lbl_Timer.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Timer.Location = new Point(34, 31);
            lbl_Timer.Margin = new Padding(4, 0, 4, 0);
            lbl_Timer.Name = "lbl_Timer";
            lbl_Timer.Size = new Size(38, 25);
            lbl_Timer.TabIndex = 2;
            lbl_Timer.Text = "10";
            // 
            // lbl_Points
            // 
            lbl_Points.AutoSize = true;
            lbl_Points.Font = new Font("Microsoft Sans Serif", 10.75F, FontStyle.Bold);
            lbl_Points.Location = new Point(1278, 114);
            lbl_Points.Margin = new Padding(4, 0, 4, 0);
            lbl_Points.Name = "lbl_Points";
            lbl_Points.Size = new Size(26, 18);
            lbl_Points.TabIndex = 2;
            lbl_Points.Text = "0p";
            // 
            // lbl_Level
            // 
            lbl_Level.AutoSize = true;
            lbl_Level.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Level.Location = new Point(573, 31);
            lbl_Level.Margin = new Padding(4, 0, 4, 0);
            lbl_Level.Name = "lbl_Level";
            lbl_Level.Size = new Size(25, 25);
            lbl_Level.TabIndex = 2;
            lbl_Level.Text = "1";
            // 
            // label_Level
            // 
            label_Level.AutoSize = true;
            label_Level.Font = new Font("Malgun Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Level.ForeColor = Color.Gray;
            label_Level.Location = new Point(561, 5);
            label_Level.Margin = new Padding(4, 0, 4, 0);
            label_Level.Name = "label_Level";
            label_Level.Size = new Size(48, 21);
            label_Level.TabIndex = 1;
            label_Level.Text = "Level";
            label_Level.Click += lbl_Start_Game_Click;
            // 
            // label_Poäng
            // 
            label_Poäng.AutoSize = true;
            label_Poäng.Font = new Font("Malgun Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Poäng.ForeColor = Color.Gray;
            label_Poäng.Location = new Point(1260, 80);
            label_Poäng.Margin = new Padding(4, 0, 4, 0);
            label_Poäng.Name = "label_Poäng";
            label_Poäng.Size = new Size(56, 21);
            label_Poäng.TabIndex = 1;
            label_Poäng.Text = "Poäng";
            label_Poäng.Click += lbl_Start_Game_Click;
            // 
            // label_Tid
            // 
            label_Tid.AutoSize = true;
            label_Tid.Font = new Font("Malgun Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Tid.ForeColor = Color.Gray;
            label_Tid.Location = new Point(35, 5);
            label_Tid.Margin = new Padding(4, 0, 4, 0);
            label_Tid.Name = "label_Tid";
            label_Tid.Size = new Size(33, 21);
            label_Tid.TabIndex = 1;
            label_Tid.Text = "Tid";
            label_Tid.Click += lbl_Start_Game_Click;
            // 
            // label_Total_Poäng
            // 
            label_Total_Poäng.AutoSize = true;
            label_Total_Poäng.Font = new Font("Malgun Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Total_Poäng.ForeColor = Color.Gray;
            label_Total_Poäng.Location = new Point(1387, 80);
            label_Total_Poäng.Margin = new Padding(4, 0, 4, 0);
            label_Total_Poäng.Name = "label_Total_Poäng";
            label_Total_Poäng.Size = new Size(99, 21);
            label_Total_Poäng.TabIndex = 1;
            label_Total_Poäng.Text = "Total Poäng";
            label_Total_Poäng.Click += lbl_Start_Game_Click;
            // 
            // lbl_Total_Poäng
            // 
            lbl_Total_Poäng.AutoSize = true;
            lbl_Total_Poäng.Font = new Font("Microsoft Sans Serif", 10.75F, FontStyle.Bold);
            lbl_Total_Poäng.Location = new Point(1429, 114);
            lbl_Total_Poäng.Margin = new Padding(4, 0, 4, 0);
            lbl_Total_Poäng.Name = "lbl_Total_Poäng";
            lbl_Total_Poäng.Size = new Size(26, 18);
            lbl_Total_Poäng.TabIndex = 2;
            lbl_Total_Poäng.Text = "0p";
            // 
            // dgv_HighScore
            // 
            dgv_HighScore.AllowUserToAddRows = false;
            dgv_HighScore.AllowUserToDeleteRows = false;
            dgv_HighScore.AllowUserToResizeRows = false;
            dgv_HighScore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dgv_HighScore.BackgroundColor = Color.White;
            dgv_HighScore.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_HighScore.Location = new Point(1626, 33);
            dgv_HighScore.Margin = new Padding(4, 3, 4, 3);
            dgv_HighScore.Name = "dgv_HighScore";
            dgv_HighScore.RowHeadersVisible = false;
            dgv_HighScore.Size = new Size(392, 299);
            dgv_HighScore.TabIndex = 3;
            // 
            // label_Info
            // 
            label_Info.ForeColor = Color.Gray;
            label_Info.Location = new Point(1265, 332);
            label_Info.Margin = new Padding(4, 0, 4, 0);
            label_Info.Name = "label_Info";
            label_Info.Size = new Size(321, 96);
            label_Info.TabIndex = 4;
            label_Info.Text = "Klicka på Starta Spel och följ sedan den gula linjen till slutet för att klara banan.\r\nDu måste klara banan före tiden (uppe till vänster) tar slut.\r\nBanorna blir svårare för varje gång.";
            // 
            // lbl_Avsluta
            // 
            lbl_Avsluta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_Avsluta.AutoSize = true;
            lbl_Avsluta.Cursor = Cursors.Hand;
            lbl_Avsluta.Font = new Font("Malgun Gothic", 16F);
            lbl_Avsluta.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_Avsluta.Location = new Point(1937, 853);
            lbl_Avsluta.Margin = new Padding(4, 0, 4, 0);
            lbl_Avsluta.Name = "lbl_Avsluta";
            lbl_Avsluta.Size = new Size(85, 30);
            lbl_Avsluta.TabIndex = 1;
            lbl_Avsluta.Text = "Avsluta";
            lbl_Avsluta.Click += lbl_Avsluta_Click;
            // 
            // dgv_Text
            // 
            dgv_Text.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Text.Columns.AddRange(new DataGridViewColumn[] { Text });
            dgv_Text.Location = new Point(1386, 505);
            dgv_Text.Name = "dgv_Text";
            dgv_Text.Size = new Size(370, 150);
            dgv_Text.TabIndex = 5;
            dgv_Text.Visible = false;
            // 
            // Text
            // 
            Text.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Text.HeaderText = "Text";
            Text.Name = "Text";
            // 
            // EasterEgg_1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2050, 898);
            Controls.Add(dgv_Text);
            Controls.Add(label_Info);
            Controls.Add(dgv_HighScore);
            Controls.Add(lbl_Total_Poäng);
            Controls.Add(lbl_Points);
            Controls.Add(lbl_Level);
            Controls.Add(label_Tid);
            Controls.Add(label_Total_Poäng);
            Controls.Add(label_Poäng);
            Controls.Add(label_Level);
            Controls.Add(lbl_Timer);
            Controls.Add(lbl_Avsluta);
            Controls.Add(lbl_Start_Game);
            Controls.Add(panel_GameArea);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "EasterEgg_1";
            StartPosition = FormStartPosition.CenterScreen;
            ((ISupportInitialize)dgv_HighScore).EndInit();
            ((ISupportInitialize)dgv_Text).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Panel panel_GameArea;
        private Label lbl_Start_Game;
        private System.Windows.Forms.Timer timer;
        private Label lbl_Timer;
        private Label lbl_Points;
        private Label lbl_Level;
        private Label label_Level;
        private Label label_Poäng;
        private Label label_Tid;
        private Label label_Total_Poäng;
        private Label lbl_Total_Poäng;
        private DataGridView dgv_HighScore;
        private Label label_Info;
        private Label lbl_Avsluta;
        private DataGridView dgv_Text;
        private DataGridViewTextBoxColumn Text;
    }
}