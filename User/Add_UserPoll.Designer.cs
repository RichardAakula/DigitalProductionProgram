using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.User
{
    partial class Add_UserPoll
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
            this.lbl_Fråga = new System.Windows.Forms.Label();
            this.tb_Fråga = new System.Windows.Forms.TextBox();
            this.lbl_Add_Gallup = new System.Windows.Forms.Label();
            this.label_SvarAlt_1 = new System.Windows.Forms.Label();
            this.label_SvarAlt_2 = new System.Windows.Forms.Label();
            this.label_SvarAlt_3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_SvarAlt_4 = new System.Windows.Forms.TextBox();
            this.label_SvarAlt_4 = new System.Windows.Forms.Label();
            this.tb_SvarAlt_1 = new System.Windows.Forms.TextBox();
            this.tb_SvarAlt_2 = new System.Windows.Forms.TextBox();
            this.tb_SvarAlt_3 = new System.Windows.Forms.TextBox();
            this.lbl_Gallup_Done = new System.Windows.Forms.Label();
            this.pb_LaddaUppBild = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LaddaUppBild)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Rubrik
            // 
            this.label_Rubrik.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Rubrik.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rubrik.ForeColor = System.Drawing.Color.IndianRed;
            this.label_Rubrik.Location = new System.Drawing.Point(0, 0);
            this.label_Rubrik.Name = "label_Rubrik";
            this.label_Rubrik.Size = new System.Drawing.Size(897, 34);
            this.label_Rubrik.TabIndex = 1;
            this.label_Rubrik.Text = "Lägg till Gallup";
            this.label_Rubrik.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Fråga
            // 
            this.lbl_Fråga.AutoSize = true;
            this.lbl_Fråga.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Fråga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fråga.ForeColor = System.Drawing.SystemColors.Info;
            this.lbl_Fråga.Location = new System.Drawing.Point(0, 34);
            this.lbl_Fråga.Name = "lbl_Fråga";
            this.lbl_Fråga.Size = new System.Drawing.Size(50, 16);
            this.lbl_Fråga.TabIndex = 4;
            this.lbl_Fråga.Text = "Fråga?";
            // 
            // tb_Fråga
            // 
            this.tb_Fråga.Location = new System.Drawing.Point(3, 54);
            this.tb_Fråga.Multiline = true;
            this.tb_Fråga.Name = "tb_Fråga";
            this.tb_Fråga.Size = new System.Drawing.Size(882, 101);
            this.tb_Fråga.TabIndex = 5;
            // 
            // lbl_Add_Gallup
            // 
            this.lbl_Add_Gallup.AutoSize = true;
            this.lbl_Add_Gallup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Add_Gallup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_Add_Gallup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Add_Gallup.ForeColor = System.Drawing.SystemColors.Info;
            this.lbl_Add_Gallup.Location = new System.Drawing.Point(0, 328);
            this.lbl_Add_Gallup.Name = "lbl_Add_Gallup";
            this.lbl_Add_Gallup.Size = new System.Drawing.Size(95, 16);
            this.lbl_Add_Gallup.TabIndex = 6;
            this.lbl_Add_Gallup.Text = "Lägg till Gallup";
            this.lbl_Add_Gallup.Click += new System.EventHandler(this.lbl_Add_Picture_Click);
            // 
            // label_SvarAlt_1
            // 
            this.label_SvarAlt_1.AutoSize = true;
            this.label_SvarAlt_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SvarAlt_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SvarAlt_1.ForeColor = System.Drawing.SystemColors.Info;
            this.label_SvarAlt_1.Location = new System.Drawing.Point(3, 0);
            this.label_SvarAlt_1.Name = "label_SvarAlt_1";
            this.label_SvarAlt_1.Size = new System.Drawing.Size(214, 23);
            this.label_SvarAlt_1.TabIndex = 7;
            this.label_SvarAlt_1.Text = "Svarsalternativ 1";
            // 
            // label_SvarAlt_2
            // 
            this.label_SvarAlt_2.AutoSize = true;
            this.label_SvarAlt_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SvarAlt_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SvarAlt_2.ForeColor = System.Drawing.SystemColors.Info;
            this.label_SvarAlt_2.Location = new System.Drawing.Point(223, 0);
            this.label_SvarAlt_2.Name = "label_SvarAlt_2";
            this.label_SvarAlt_2.Size = new System.Drawing.Size(214, 23);
            this.label_SvarAlt_2.TabIndex = 7;
            this.label_SvarAlt_2.Text = "Svarsalternativ 2";
            // 
            // label_SvarAlt_3
            // 
            this.label_SvarAlt_3.AutoSize = true;
            this.label_SvarAlt_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SvarAlt_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SvarAlt_3.ForeColor = System.Drawing.SystemColors.Info;
            this.label_SvarAlt_3.Location = new System.Drawing.Point(443, 0);
            this.label_SvarAlt_3.Name = "label_SvarAlt_3";
            this.label_SvarAlt_3.Size = new System.Drawing.Size(214, 23);
            this.label_SvarAlt_3.TabIndex = 7;
            this.label_SvarAlt_3.Text = "Svarsalternativ 3";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.tb_SvarAlt_4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_SvarAlt_4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_SvarAlt_1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_SvarAlt_3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_SvarAlt_2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_SvarAlt_1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_SvarAlt_2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_SvarAlt_3, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 188);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 47);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tb_SvarAlt_4
            // 
            this.tb_SvarAlt_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_SvarAlt_4.Location = new System.Drawing.Point(663, 26);
            this.tb_SvarAlt_4.Name = "tb_SvarAlt_4";
            this.tb_SvarAlt_4.Size = new System.Drawing.Size(216, 20);
            this.tb_SvarAlt_4.TabIndex = 10;
            // 
            // label_SvarAlt_4
            // 
            this.label_SvarAlt_4.AutoSize = true;
            this.label_SvarAlt_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SvarAlt_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SvarAlt_4.ForeColor = System.Drawing.SystemColors.Info;
            this.label_SvarAlt_4.Location = new System.Drawing.Point(663, 0);
            this.label_SvarAlt_4.Name = "label_SvarAlt_4";
            this.label_SvarAlt_4.Size = new System.Drawing.Size(216, 23);
            this.label_SvarAlt_4.TabIndex = 9;
            this.label_SvarAlt_4.Text = "Svarsalternativ 4";
            // 
            // tb_SvarAlt_1
            // 
            this.tb_SvarAlt_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_SvarAlt_1.Location = new System.Drawing.Point(3, 26);
            this.tb_SvarAlt_1.Name = "tb_SvarAlt_1";
            this.tb_SvarAlt_1.Size = new System.Drawing.Size(214, 20);
            this.tb_SvarAlt_1.TabIndex = 8;
            // 
            // tb_SvarAlt_2
            // 
            this.tb_SvarAlt_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_SvarAlt_2.Location = new System.Drawing.Point(223, 26);
            this.tb_SvarAlt_2.Name = "tb_SvarAlt_2";
            this.tb_SvarAlt_2.Size = new System.Drawing.Size(214, 20);
            this.tb_SvarAlt_2.TabIndex = 8;
            // 
            // tb_SvarAlt_3
            // 
            this.tb_SvarAlt_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_SvarAlt_3.Location = new System.Drawing.Point(443, 26);
            this.tb_SvarAlt_3.Name = "tb_SvarAlt_3";
            this.tb_SvarAlt_3.Size = new System.Drawing.Size(214, 20);
            this.tb_SvarAlt_3.TabIndex = 8;
            // 
            // lbl_Gallup_Done
            // 
            this.lbl_Gallup_Done.AutoSize = true;
            this.lbl_Gallup_Done.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Gallup_Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Gallup_Done.ForeColor = System.Drawing.SystemColors.Info;
            this.lbl_Gallup_Done.Location = new System.Drawing.Point(823, 263);
            this.lbl_Gallup_Done.Name = "lbl_Gallup_Done";
            this.lbl_Gallup_Done.Size = new System.Drawing.Size(71, 16);
            this.lbl_Gallup_Done.TabIndex = 9;
            this.lbl_Gallup_Done.Text = "Gallup klar";
            this.lbl_Gallup_Done.Click += new System.EventHandler(this.lbl_Gallup_Done_Click);
            // 
            // pb_LaddaUppBild
            // 
            this.pb_LaddaUppBild.BackColor = System.Drawing.Color.Transparent;
            this.pb_LaddaUppBild.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_LaddaUppBild.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_LaddaUppBild.Image = global::DigitalProductionProgram.Properties.Resources.camera2;
            this.pb_LaddaUppBild.Location = new System.Drawing.Point(5, 279);
            this.pb_LaddaUppBild.Name = "pb_LaddaUppBild";
            this.pb_LaddaUppBild.Size = new System.Drawing.Size(35, 35);
            this.pb_LaddaUppBild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_LaddaUppBild.TabIndex = 837;
            this.pb_LaddaUppBild.TabStop = false;
            this.pb_LaddaUppBild.Visible = false;
            // 
            // Add_Gallup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(897, 344);
            this.Controls.Add(this.pb_LaddaUppBild);
            this.Controls.Add(this.lbl_Gallup_Done);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbl_Add_Gallup);
            this.Controls.Add(this.tb_Fråga);
            this.Controls.Add(this.lbl_Fråga);
            this.Controls.Add(this.label_Rubrik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_Gallup";
            this.Text = "Add_Gallup";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LaddaUppBild)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_Rubrik;
        private Label lbl_Fråga;
        private TextBox tb_Fråga;
        private Label lbl_Add_Gallup;
        private Label label_SvarAlt_1;
        private Label label_SvarAlt_2;
        private Label label_SvarAlt_3;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tb_SvarAlt_1;
        private TextBox tb_SvarAlt_2;
        private TextBox tb_SvarAlt_3;
        private TextBox tb_SvarAlt_4;
        private Label label_SvarAlt_4;
        private Label lbl_Gallup_Done;
        private PictureBox pb_LaddaUppBild;
    }
}