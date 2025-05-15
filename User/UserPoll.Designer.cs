using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.User
{
    partial class UserPoll
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
            this.label_Rubrik = new System.Windows.Forms.Label();
            this.lbl_Svar_1 = new System.Windows.Forms.Label();
            this.lbl_Svar_2 = new System.Windows.Forms.Label();
            this.lbl_Svar_3 = new System.Windows.Forms.Label();
            this.lbl_Fråga = new System.Windows.Forms.Label();
            this.lbl_Percent_Svar_1 = new System.Windows.Forms.Label();
            this.lbl_Percent_Svar_2 = new System.Windows.Forms.Label();
            this.lbl_Percent_Svar_3 = new System.Windows.Forms.Label();
            this.lbl_ctr_Votes = new System.Windows.Forms.Label();
            this.tlp_Top = new System.Windows.Forms.TableLayoutPanel();
            this.label_Exit = new System.Windows.Forms.Label();
            this.lbl_Percent_Svar_4 = new System.Windows.Forms.Label();
            this.lbl_Svar_4 = new System.Windows.Forms.Label();
            this.flp_Main = new System.Windows.Forms.FlowLayoutPanel();
            this.pb_Bild = new System.Windows.Forms.PictureBox();
            this.tlp_Bottom = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Top.SuspendLayout();
            this.flp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Bild)).BeginInit();
            this.tlp_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Rubrik
            // 
            this.label_Rubrik.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rubrik.ForeColor = System.Drawing.Color.IndianRed;
            this.label_Rubrik.Location = new System.Drawing.Point(87, 0);
            this.label_Rubrik.Name = "label_Rubrik";
            this.label_Rubrik.Size = new System.Drawing.Size(503, 34);
            this.label_Rubrik.TabIndex = 0;
            this.label_Rubrik.Text = "Undersökning";
            this.label_Rubrik.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Svar_1
            // 
            this.lbl_Svar_1.AutoSize = true;
            this.lbl_Svar_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lbl_Svar_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Svar_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Svar_1.Font = new System.Drawing.Font("Modern No. 20", 12.75F);
            this.lbl_Svar_1.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_Svar_1.Location = new System.Drawing.Point(45, 2);
            this.lbl_Svar_1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.lbl_Svar_1.Name = "lbl_Svar_1";
            this.lbl_Svar_1.Size = new System.Drawing.Size(115, 115);
            this.lbl_Svar_1.TabIndex = 1;
            this.lbl_Svar_1.Text = "1";
            this.lbl_Svar_1.Click += new System.EventHandler(this.Svar_Click);
            // 
            // lbl_Svar_2
            // 
            this.lbl_Svar_2.AutoSize = true;
            this.lbl_Svar_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lbl_Svar_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Svar_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Svar_2.Font = new System.Drawing.Font("Modern No. 20", 12.75F);
            this.lbl_Svar_2.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_Svar_2.Location = new System.Drawing.Point(205, 2);
            this.lbl_Svar_2.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.lbl_Svar_2.Name = "lbl_Svar_2";
            this.lbl_Svar_2.Size = new System.Drawing.Size(115, 115);
            this.lbl_Svar_2.TabIndex = 1;
            this.lbl_Svar_2.Text = "2";
            this.lbl_Svar_2.Click += new System.EventHandler(this.Svar_Click);
            // 
            // lbl_Svar_3
            // 
            this.lbl_Svar_3.AutoSize = true;
            this.lbl_Svar_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lbl_Svar_3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Svar_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Svar_3.Font = new System.Drawing.Font("Modern No. 20", 12.75F);
            this.lbl_Svar_3.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_Svar_3.Location = new System.Drawing.Point(365, 2);
            this.lbl_Svar_3.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.lbl_Svar_3.Name = "lbl_Svar_3";
            this.lbl_Svar_3.Size = new System.Drawing.Size(115, 115);
            this.lbl_Svar_3.TabIndex = 1;
            this.lbl_Svar_3.Text = "3";
            this.lbl_Svar_3.Click += new System.EventHandler(this.Svar_Click);
            // 
            // lbl_Fråga
            // 
            this.lbl_Fråga.AutoSize = true;
            this.lbl_Fråga.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Fråga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fråga.ForeColor = System.Drawing.SystemColors.Info;
            this.lbl_Fråga.Location = new System.Drawing.Point(3, 0);
            this.lbl_Fråga.Name = "lbl_Fråga";
            this.lbl_Fråga.Size = new System.Drawing.Size(51, 16);
            this.lbl_Fråga.TabIndex = 3;
            this.lbl_Fråga.Text = "Vill du?";
            // 
            // lbl_Percent_Svar_1
            // 
            this.lbl_Percent_Svar_1.AutoSize = true;
            this.lbl_Percent_Svar_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lbl_Percent_Svar_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Percent_Svar_1.Font = new System.Drawing.Font("Modern No. 20", 10.75F);
            this.lbl_Percent_Svar_1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbl_Percent_Svar_1.Location = new System.Drawing.Point(2, 2);
            this.lbl_Percent_Svar_1.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.lbl_Percent_Svar_1.Name = "lbl_Percent_Svar_1";
            this.lbl_Percent_Svar_1.Size = new System.Drawing.Size(43, 115);
            this.lbl_Percent_Svar_1.TabIndex = 2;
            this.lbl_Percent_Svar_1.Text = "0 %";
            this.lbl_Percent_Svar_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Percent_Svar_2
            // 
            this.lbl_Percent_Svar_2.AutoSize = true;
            this.lbl_Percent_Svar_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lbl_Percent_Svar_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Percent_Svar_2.Font = new System.Drawing.Font("Modern No. 20", 10.75F);
            this.lbl_Percent_Svar_2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbl_Percent_Svar_2.Location = new System.Drawing.Point(162, 2);
            this.lbl_Percent_Svar_2.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.lbl_Percent_Svar_2.Name = "lbl_Percent_Svar_2";
            this.lbl_Percent_Svar_2.Size = new System.Drawing.Size(43, 115);
            this.lbl_Percent_Svar_2.TabIndex = 2;
            this.lbl_Percent_Svar_2.Text = "0 %";
            this.lbl_Percent_Svar_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Percent_Svar_3
            // 
            this.lbl_Percent_Svar_3.AutoSize = true;
            this.lbl_Percent_Svar_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lbl_Percent_Svar_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Percent_Svar_3.Font = new System.Drawing.Font("Modern No. 20", 10.75F);
            this.lbl_Percent_Svar_3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbl_Percent_Svar_3.Location = new System.Drawing.Point(322, 2);
            this.lbl_Percent_Svar_3.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.lbl_Percent_Svar_3.Name = "lbl_Percent_Svar_3";
            this.lbl_Percent_Svar_3.Size = new System.Drawing.Size(43, 115);
            this.lbl_Percent_Svar_3.TabIndex = 2;
            this.lbl_Percent_Svar_3.Text = "0 %";
            this.lbl_Percent_Svar_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ctr_Votes
            // 
            this.lbl_ctr_Votes.AutoSize = true;
            this.lbl_ctr_Votes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_Bottom.SetColumnSpan(this.lbl_ctr_Votes, 8);
            this.lbl_ctr_Votes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ctr_Votes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ctr_Votes.ForeColor = System.Drawing.SystemColors.Info;
            this.lbl_ctr_Votes.Location = new System.Drawing.Point(0, 119);
            this.lbl_ctr_Votes.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_ctr_Votes.Name = "lbl_ctr_Votes";
            this.lbl_ctr_Votes.Size = new System.Drawing.Size(640, 19);
            this.lbl_ctr_Votes.TabIndex = 5;
            this.lbl_ctr_Votes.Text = "Antal röster";
            this.lbl_ctr_Votes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlp_Top
            // 
            this.tlp_Top.ColumnCount = 3;
            this.tlp_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlp_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Top.Controls.Add(this.label_Rubrik, 1, 0);
            this.tlp_Top.Controls.Add(this.label_Exit, 2, 0);
            this.tlp_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_Top.Location = new System.Drawing.Point(0, 0);
            this.tlp_Top.Name = "tlp_Top";
            this.tlp_Top.RowCount = 1;
            this.tlp_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_Top.Size = new System.Drawing.Size(643, 31);
            this.tlp_Top.TabIndex = 6;
            // 
            // label_Exit
            // 
            this.label_Exit.AutoSize = true;
            this.label_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Exit.Font = new System.Drawing.Font("Perpetua", 20.75F, System.Drawing.FontStyle.Bold);
            this.label_Exit.ForeColor = System.Drawing.Color.Gray;
            this.label_Exit.Location = new System.Drawing.Point(593, 0);
            this.label_Exit.Margin = new System.Windows.Forms.Padding(0);
            this.label_Exit.Name = "label_Exit";
            this.label_Exit.Size = new System.Drawing.Size(50, 40);
            this.label_Exit.TabIndex = 6;
            this.label_Exit.Text = "X";
            this.label_Exit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_Exit.Click += new System.EventHandler(this.label_Exit_Click);
            // 
            // lbl_Percent_Svar_4
            // 
            this.lbl_Percent_Svar_4.AutoSize = true;
            this.lbl_Percent_Svar_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lbl_Percent_Svar_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Percent_Svar_4.Font = new System.Drawing.Font("Modern No. 20", 10.75F);
            this.lbl_Percent_Svar_4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbl_Percent_Svar_4.Location = new System.Drawing.Point(482, 2);
            this.lbl_Percent_Svar_4.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.lbl_Percent_Svar_4.Name = "lbl_Percent_Svar_4";
            this.lbl_Percent_Svar_4.Size = new System.Drawing.Size(43, 115);
            this.lbl_Percent_Svar_4.TabIndex = 2;
            this.lbl_Percent_Svar_4.Text = "0 %";
            this.lbl_Percent_Svar_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Svar_4
            // 
            this.lbl_Svar_4.AutoSize = true;
            this.lbl_Svar_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lbl_Svar_4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Svar_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Svar_4.Font = new System.Drawing.Font("Modern No. 20", 12.75F);
            this.lbl_Svar_4.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_Svar_4.Location = new System.Drawing.Point(525, 2);
            this.lbl_Svar_4.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.lbl_Svar_4.Name = "lbl_Svar_4";
            this.lbl_Svar_4.Size = new System.Drawing.Size(113, 115);
            this.lbl_Svar_4.TabIndex = 1;
            this.lbl_Svar_4.Text = "4";
            this.lbl_Svar_4.Click += new System.EventHandler(this.Svar_Click);
            // 
            // flp_Main
            // 
            this.flp_Main.Controls.Add(this.lbl_Fråga);
            this.flp_Main.Controls.Add(this.pb_Bild);
            this.flp_Main.Controls.Add(this.tlp_Bottom);
            this.flp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Main.Location = new System.Drawing.Point(0, 31);
            this.flp_Main.Name = "flp_Main";
            this.flp_Main.Size = new System.Drawing.Size(643, 957);
            this.flp_Main.TabIndex = 7;
            // 
            // pb_Bild
            // 
            this.pb_Bild.BackColor = System.Drawing.Color.Black;
            this.pb_Bild.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_Bild.Location = new System.Drawing.Point(3, 19);
            this.pb_Bild.Name = "pb_Bild";
            this.pb_Bild.Size = new System.Drawing.Size(640, 752);
            this.pb_Bild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_Bild.TabIndex = 4;
            this.pb_Bild.TabStop = false;
            // 
            // tlp_Bottom
            // 
            this.tlp_Bottom.BackColor = System.Drawing.Color.White;
            this.tlp_Bottom.ColumnCount = 8;
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlp_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_Bottom.Controls.Add(this.lbl_ctr_Votes, 0, 1);
            this.tlp_Bottom.Controls.Add(this.lbl_Percent_Svar_1, 0, 0);
            this.tlp_Bottom.Controls.Add(this.lbl_Svar_4, 7, 0);
            this.tlp_Bottom.Controls.Add(this.lbl_Percent_Svar_4, 6, 0);
            this.tlp_Bottom.Controls.Add(this.lbl_Svar_3, 5, 0);
            this.tlp_Bottom.Controls.Add(this.lbl_Svar_1, 1, 0);
            this.tlp_Bottom.Controls.Add(this.lbl_Percent_Svar_3, 4, 0);
            this.tlp_Bottom.Controls.Add(this.lbl_Svar_2, 3, 0);
            this.tlp_Bottom.Controls.Add(this.lbl_Percent_Svar_2, 2, 0);
            this.tlp_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlp_Bottom.Location = new System.Drawing.Point(3, 777);
            this.tlp_Bottom.Name = "tlp_Bottom";
            this.tlp_Bottom.RowCount = 2;
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tlp_Bottom.Size = new System.Drawing.Size(640, 138);
            this.tlp_Bottom.TabIndex = 5;
            // 
            // Gallup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(643, 988);
            this.ControlBox = false;
            this.Controls.Add(this.flp_Main);
            this.Controls.Add(this.tlp_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Gallup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gallup";
            this.tlp_Top.ResumeLayout(false);
            this.tlp_Top.PerformLayout();
            this.flp_Main.ResumeLayout(false);
            this.flp_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Bild)).EndInit();
            this.tlp_Bottom.ResumeLayout(false);
            this.tlp_Bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label_Rubrik;
        private Label lbl_Svar_1;
        private Label lbl_Svar_2;
        private Label lbl_Svar_3;
        private Label lbl_Fråga;
        private Label lbl_Percent_Svar_1;
        private Label lbl_Percent_Svar_2;
        private Label lbl_Percent_Svar_3;
        private Label lbl_ctr_Votes;
        private TableLayoutPanel tlp_Top;
        private Label label_Exit;
        private Label lbl_Percent_Svar_4;
        private Label lbl_Svar_4;
        private FlowLayoutPanel flp_Main;
        private PictureBox pb_Bild;
        private TableLayoutPanel tlp_Bottom;
    }
}