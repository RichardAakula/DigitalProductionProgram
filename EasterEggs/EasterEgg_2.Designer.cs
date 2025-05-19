using System.ComponentModel;

namespace DigitalProductionProgram.EasterEggs
{
    partial class EasterEgg_2
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
            dgv_HighScore = new DataGridView();
            ((ISupportInitialize)dgv_HighScore).BeginInit();
            SuspendLayout();
            // 
            // dgv_HighScore
            // 
            dgv_HighScore.AllowUserToAddRows = false;
            dgv_HighScore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_HighScore.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_HighScore.Dock = DockStyle.Right;
            dgv_HighScore.Location = new Point(1033, 0);
            dgv_HighScore.Name = "dgv_HighScore";
            dgv_HighScore.ReadOnly = true;
            dgv_HighScore.RowHeadersVisible = false;
            dgv_HighScore.Size = new Size(438, 841);
            dgv_HighScore.TabIndex = 0;
            dgv_HighScore.Visible = false;
            // 
            // EasterEgg_2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1471, 841);
            Controls.Add(dgv_HighScore);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EasterEgg_2";
            Text = "EasterEgg_2";
            WindowState = FormWindowState.Maximized;
            Shown += EasterEgg_2_Shown;
            Click += EasterEgg_2_Click;
            ((ISupportInitialize)dgv_HighScore).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DataGridView dgv_HighScore;
    }
}