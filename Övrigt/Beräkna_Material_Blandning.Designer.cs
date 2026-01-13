using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Övrigt
{
    partial class Beräkna_Material_Blandning
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
            cb_BlandningsTyp = new ComboBox();
            tlp_Main = new TableLayoutPanel();
            label6 = new Label();
            lbl_Resultat_Material_2 = new Label();
            label_resultat_Material_2 = new Label();
            label4 = new Label();
            lbl_Resultat_Material_1 = new Label();
            label_resultat_Material_1 = new Label();
            label_resultat_pigment_enhet = new Label();
            lbl_Resultat_Pigment = new Label();
            label1 = new Label();
            label_Ok = new Label();
            label_Material_2_enhet = new Label();
            tb_Material_2 = new TextBox();
            label_Material_2 = new Label();
            label_Material_1_enhet = new Label();
            tb_Material_1 = new TextBox();
            label_Material_1 = new Label();
            label_pigment_enhet = new Label();
            tb_Pigment = new TextBox();
            label_Pigment = new Label();
            label_Färdig_mängd_enhet = new Label();
            label_Färdig_mängd = new Label();
            tb_Total_Mängd = new TextBox();
            lbl_Blandning_Ok = new Label();
            label_empty_0 = new Label();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // cb_BlandningsTyp
            // 
            tlp_Main.SetColumnSpan(cb_BlandningsTyp, 3);
            cb_BlandningsTyp.Dock = DockStyle.Fill;
            cb_BlandningsTyp.FormattingEnabled = true;
            cb_BlandningsTyp.Items.AddRange(new object[] { "Ett material + Pigment", "Två material + Pigment", "Två material utan Pigment" });
            cb_BlandningsTyp.Location = new Point(0, 0);
            cb_BlandningsTyp.Margin = new Padding(0, 0, 0, 1);
            cb_BlandningsTyp.Name = "cb_BlandningsTyp";
            cb_BlandningsTyp.Size = new Size(275, 23);
            cb_BlandningsTyp.TabIndex = 0;
            cb_BlandningsTyp.SelectedIndexChanged += cb_BlandningsTyp_SelectedIndexChanged;
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Black;
            tlp_Main.ColumnCount = 3;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.08475F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.30508F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.61017F));
            tlp_Main.Controls.Add(label6, 2, 9);
            tlp_Main.Controls.Add(lbl_Resultat_Material_2, 1, 9);
            tlp_Main.Controls.Add(label_resultat_Material_2, 0, 9);
            tlp_Main.Controls.Add(label4, 2, 8);
            tlp_Main.Controls.Add(lbl_Resultat_Material_1, 1, 8);
            tlp_Main.Controls.Add(label_resultat_Material_1, 0, 8);
            tlp_Main.Controls.Add(label_resultat_pigment_enhet, 2, 7);
            tlp_Main.Controls.Add(lbl_Resultat_Pigment, 1, 7);
            tlp_Main.Controls.Add(label1, 0, 7);
            tlp_Main.Controls.Add(label_Ok, 0, 5);
            tlp_Main.Controls.Add(label_Material_2_enhet, 2, 4);
            tlp_Main.Controls.Add(tb_Material_2, 1, 4);
            tlp_Main.Controls.Add(label_Material_2, 0, 4);
            tlp_Main.Controls.Add(label_Material_1_enhet, 2, 3);
            tlp_Main.Controls.Add(tb_Material_1, 1, 3);
            tlp_Main.Controls.Add(label_Material_1, 0, 3);
            tlp_Main.Controls.Add(label_pigment_enhet, 2, 2);
            tlp_Main.Controls.Add(tb_Pigment, 1, 2);
            tlp_Main.Controls.Add(label_Pigment, 0, 2);
            tlp_Main.Controls.Add(label_Färdig_mängd_enhet, 2, 1);
            tlp_Main.Controls.Add(cb_BlandningsTyp, 0, 0);
            tlp_Main.Controls.Add(label_Färdig_mängd, 0, 1);
            tlp_Main.Controls.Add(tb_Total_Mängd, 1, 1);
            tlp_Main.Controls.Add(lbl_Blandning_Ok, 1, 5);
            tlp_Main.Controls.Add(label_empty_0, 0, 6);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 10;
            tlp_Main.RowStyles.Add(new RowStyle());
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.Size = new Size(275, 233);
            tlp_Main.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Info;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Lucida Sans", 8.25F);
            label6.Location = new Point(216, 207);
            label6.Margin = new Padding(1, 0, 1, 1);
            label6.Name = "label6";
            label6.Size = new Size(58, 25);
            label6.TabIndex = 23;
            label6.Text = "kg";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Resultat_Material_2
            // 
            lbl_Resultat_Material_2.AutoSize = true;
            lbl_Resultat_Material_2.BackColor = Color.Silver;
            lbl_Resultat_Material_2.Dock = DockStyle.Fill;
            lbl_Resultat_Material_2.Font = new Font("Lucida Sans", 8.25F);
            lbl_Resultat_Material_2.ForeColor = Color.ForestGreen;
            lbl_Resultat_Material_2.Location = new Point(152, 207);
            lbl_Resultat_Material_2.Margin = new Padding(1, 0, 0, 1);
            lbl_Resultat_Material_2.Name = "lbl_Resultat_Material_2";
            lbl_Resultat_Material_2.Size = new Size(63, 25);
            lbl_Resultat_Material_2.TabIndex = 22;
            lbl_Resultat_Material_2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_resultat_Material_2
            // 
            label_resultat_Material_2.AutoSize = true;
            label_resultat_Material_2.BackColor = SystemColors.Info;
            label_resultat_Material_2.Dock = DockStyle.Fill;
            label_resultat_Material_2.Font = new Font("Lucida Sans", 8.25F);
            label_resultat_Material_2.Location = new Point(1, 207);
            label_resultat_Material_2.Margin = new Padding(1, 0, 0, 1);
            label_resultat_Material_2.Name = "label_resultat_Material_2";
            label_resultat_Material_2.Size = new Size(150, 25);
            label_resultat_Material_2.TabIndex = 21;
            label_resultat_Material_2.Text = "Material 2:";
            label_resultat_Material_2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Info;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Lucida Sans", 8.25F);
            label4.Location = new Point(216, 184);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(58, 23);
            label4.TabIndex = 20;
            label4.Text = "kg";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Resultat_Material_1
            // 
            lbl_Resultat_Material_1.AutoSize = true;
            lbl_Resultat_Material_1.BackColor = Color.Silver;
            lbl_Resultat_Material_1.Dock = DockStyle.Fill;
            lbl_Resultat_Material_1.Font = new Font("Lucida Sans", 8.25F);
            lbl_Resultat_Material_1.ForeColor = Color.ForestGreen;
            lbl_Resultat_Material_1.Location = new Point(152, 184);
            lbl_Resultat_Material_1.Margin = new Padding(1, 0, 0, 1);
            lbl_Resultat_Material_1.Name = "lbl_Resultat_Material_1";
            lbl_Resultat_Material_1.Size = new Size(63, 22);
            lbl_Resultat_Material_1.TabIndex = 19;
            lbl_Resultat_Material_1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_resultat_Material_1
            // 
            label_resultat_Material_1.AutoSize = true;
            label_resultat_Material_1.BackColor = SystemColors.Info;
            label_resultat_Material_1.Dock = DockStyle.Fill;
            label_resultat_Material_1.Font = new Font("Lucida Sans", 8.25F);
            label_resultat_Material_1.Location = new Point(1, 184);
            label_resultat_Material_1.Margin = new Padding(1, 0, 0, 0);
            label_resultat_Material_1.Name = "label_resultat_Material_1";
            label_resultat_Material_1.Size = new Size(150, 23);
            label_resultat_Material_1.TabIndex = 18;
            label_resultat_Material_1.Text = "Material 1:";
            label_resultat_Material_1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_resultat_pigment_enhet
            // 
            label_resultat_pigment_enhet.AutoSize = true;
            label_resultat_pigment_enhet.BackColor = SystemColors.Info;
            label_resultat_pigment_enhet.Dock = DockStyle.Fill;
            label_resultat_pigment_enhet.Font = new Font("Lucida Sans", 8.25F);
            label_resultat_pigment_enhet.Location = new Point(216, 161);
            label_resultat_pigment_enhet.Margin = new Padding(1, 0, 1, 0);
            label_resultat_pigment_enhet.Name = "label_resultat_pigment_enhet";
            label_resultat_pigment_enhet.Size = new Size(58, 23);
            label_resultat_pigment_enhet.TabIndex = 17;
            label_resultat_pigment_enhet.Text = "kg";
            label_resultat_pigment_enhet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Resultat_Pigment
            // 
            lbl_Resultat_Pigment.AutoSize = true;
            lbl_Resultat_Pigment.BackColor = Color.Silver;
            lbl_Resultat_Pigment.Dock = DockStyle.Fill;
            lbl_Resultat_Pigment.Font = new Font("Lucida Sans", 8.25F);
            lbl_Resultat_Pigment.ForeColor = Color.ForestGreen;
            lbl_Resultat_Pigment.Location = new Point(152, 161);
            lbl_Resultat_Pigment.Margin = new Padding(1, 0, 0, 1);
            lbl_Resultat_Pigment.Name = "lbl_Resultat_Pigment";
            lbl_Resultat_Pigment.Size = new Size(63, 22);
            lbl_Resultat_Pigment.TabIndex = 16;
            lbl_Resultat_Pigment.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Info;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Lucida Sans", 8.25F);
            label1.Location = new Point(1, 161);
            label1.Margin = new Padding(1, 0, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(150, 23);
            label1.TabIndex = 15;
            label1.Text = "Pigment:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Ok
            // 
            label_Ok.AutoSize = true;
            label_Ok.BackColor = SystemColors.Info;
            label_Ok.Dock = DockStyle.Fill;
            label_Ok.Font = new Font("Lucida Sans", 8.25F);
            label_Ok.Location = new Point(1, 115);
            label_Ok.Margin = new Padding(1, 0, 0, 1);
            label_Ok.Name = "label_Ok";
            label_Ok.Size = new Size(150, 22);
            label_Ok.TabIndex = 13;
            label_Ok.Text = "100% ?";
            label_Ok.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Material_2_enhet
            // 
            label_Material_2_enhet.AutoSize = true;
            label_Material_2_enhet.BackColor = SystemColors.Info;
            label_Material_2_enhet.Dock = DockStyle.Fill;
            label_Material_2_enhet.Font = new Font("Lucida Sans", 8.25F);
            label_Material_2_enhet.Location = new Point(216, 92);
            label_Material_2_enhet.Margin = new Padding(1, 0, 1, 0);
            label_Material_2_enhet.Name = "label_Material_2_enhet";
            label_Material_2_enhet.Size = new Size(58, 23);
            label_Material_2_enhet.TabIndex = 12;
            label_Material_2_enhet.Text = "%";
            label_Material_2_enhet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_Material_2
            // 
            tb_Material_2.BorderStyle = BorderStyle.None;
            tb_Material_2.Dock = DockStyle.Fill;
            tb_Material_2.Font = new Font("Courier New", 12F);
            tb_Material_2.Location = new Point(152, 93);
            tb_Material_2.Margin = new Padding(1, 1, 0, 0);
            tb_Material_2.Name = "tb_Material_2";
            tb_Material_2.Size = new Size(63, 19);
            tb_Material_2.TabIndex = 11;
            tb_Material_2.TextChanged += tb_TextChanged;
            // 
            // label_Material_2
            // 
            label_Material_2.AutoSize = true;
            label_Material_2.BackColor = SystemColors.Info;
            label_Material_2.Dock = DockStyle.Fill;
            label_Material_2.Font = new Font("Lucida Sans", 8.25F);
            label_Material_2.Location = new Point(1, 92);
            label_Material_2.Margin = new Padding(1, 0, 0, 0);
            label_Material_2.Name = "label_Material_2";
            label_Material_2.Size = new Size(150, 23);
            label_Material_2.TabIndex = 10;
            label_Material_2.Text = "Material 2:";
            label_Material_2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Material_1_enhet
            // 
            label_Material_1_enhet.AutoSize = true;
            label_Material_1_enhet.BackColor = SystemColors.Info;
            label_Material_1_enhet.Dock = DockStyle.Fill;
            label_Material_1_enhet.Font = new Font("Lucida Sans", 8.25F);
            label_Material_1_enhet.Location = new Point(216, 69);
            label_Material_1_enhet.Margin = new Padding(1, 0, 1, 0);
            label_Material_1_enhet.Name = "label_Material_1_enhet";
            label_Material_1_enhet.Size = new Size(58, 23);
            label_Material_1_enhet.TabIndex = 9;
            label_Material_1_enhet.Text = "%";
            label_Material_1_enhet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_Material_1
            // 
            tb_Material_1.BorderStyle = BorderStyle.None;
            tb_Material_1.Dock = DockStyle.Fill;
            tb_Material_1.Font = new Font("Courier New", 12F);
            tb_Material_1.Location = new Point(152, 70);
            tb_Material_1.Margin = new Padding(1, 1, 0, 0);
            tb_Material_1.Name = "tb_Material_1";
            tb_Material_1.Size = new Size(63, 19);
            tb_Material_1.TabIndex = 8;
            tb_Material_1.TextChanged += tb_TextChanged;
            // 
            // label_Material_1
            // 
            label_Material_1.AutoSize = true;
            label_Material_1.BackColor = SystemColors.Info;
            label_Material_1.Dock = DockStyle.Fill;
            label_Material_1.Font = new Font("Lucida Sans", 8.25F);
            label_Material_1.Location = new Point(1, 69);
            label_Material_1.Margin = new Padding(1, 0, 0, 0);
            label_Material_1.Name = "label_Material_1";
            label_Material_1.Size = new Size(150, 23);
            label_Material_1.TabIndex = 7;
            label_Material_1.Text = "Material 1:";
            label_Material_1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_pigment_enhet
            // 
            label_pigment_enhet.AutoSize = true;
            label_pigment_enhet.BackColor = SystemColors.Info;
            label_pigment_enhet.Dock = DockStyle.Fill;
            label_pigment_enhet.Font = new Font("Lucida Sans", 8.25F);
            label_pigment_enhet.Location = new Point(216, 46);
            label_pigment_enhet.Margin = new Padding(1, 0, 1, 0);
            label_pigment_enhet.Name = "label_pigment_enhet";
            label_pigment_enhet.Size = new Size(58, 23);
            label_pigment_enhet.TabIndex = 6;
            label_pigment_enhet.Text = "%";
            label_pigment_enhet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_Pigment
            // 
            tb_Pigment.BorderStyle = BorderStyle.None;
            tb_Pigment.Dock = DockStyle.Fill;
            tb_Pigment.Font = new Font("Courier New", 12F);
            tb_Pigment.Location = new Point(152, 47);
            tb_Pigment.Margin = new Padding(1, 1, 0, 0);
            tb_Pigment.Name = "tb_Pigment";
            tb_Pigment.Size = new Size(63, 19);
            tb_Pigment.TabIndex = 5;
            tb_Pigment.TextChanged += tb_TextChanged;
            // 
            // label_Pigment
            // 
            label_Pigment.AutoSize = true;
            label_Pigment.BackColor = SystemColors.Info;
            label_Pigment.Dock = DockStyle.Fill;
            label_Pigment.Font = new Font("Lucida Sans", 8.25F);
            label_Pigment.Location = new Point(1, 46);
            label_Pigment.Margin = new Padding(1, 0, 0, 0);
            label_Pigment.Name = "label_Pigment";
            label_Pigment.Size = new Size(150, 23);
            label_Pigment.TabIndex = 4;
            label_Pigment.Text = "Pigment:";
            label_Pigment.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Färdig_mängd_enhet
            // 
            label_Färdig_mängd_enhet.AutoSize = true;
            label_Färdig_mängd_enhet.BackColor = SystemColors.Info;
            label_Färdig_mängd_enhet.Dock = DockStyle.Fill;
            label_Färdig_mängd_enhet.Font = new Font("Lucida Sans", 8.25F);
            label_Färdig_mängd_enhet.Location = new Point(216, 24);
            label_Färdig_mängd_enhet.Margin = new Padding(1, 0, 1, 0);
            label_Färdig_mängd_enhet.Name = "label_Färdig_mängd_enhet";
            label_Färdig_mängd_enhet.Size = new Size(58, 22);
            label_Färdig_mängd_enhet.TabIndex = 3;
            label_Färdig_mängd_enhet.Text = "kg";
            label_Färdig_mängd_enhet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Färdig_mängd
            // 
            label_Färdig_mängd.AutoSize = true;
            label_Färdig_mängd.BackColor = SystemColors.Info;
            label_Färdig_mängd.Dock = DockStyle.Fill;
            label_Färdig_mängd.Font = new Font("Lucida Sans", 8.25F);
            label_Färdig_mängd.Location = new Point(1, 24);
            label_Färdig_mängd.Margin = new Padding(1, 0, 0, 0);
            label_Färdig_mängd.Name = "label_Färdig_mängd";
            label_Färdig_mängd.Size = new Size(150, 22);
            label_Färdig_mängd.TabIndex = 1;
            label_Färdig_mängd.Text = "FÄRDIG mängd:";
            label_Färdig_mängd.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tb_Total_Mängd
            // 
            tb_Total_Mängd.BorderStyle = BorderStyle.None;
            tb_Total_Mängd.Dock = DockStyle.Fill;
            tb_Total_Mängd.Font = new Font("Courier New", 12F);
            tb_Total_Mängd.Location = new Point(152, 24);
            tb_Total_Mängd.Margin = new Padding(1, 0, 0, 0);
            tb_Total_Mängd.Name = "tb_Total_Mängd";
            tb_Total_Mängd.Size = new Size(63, 19);
            tb_Total_Mängd.TabIndex = 2;
            tb_Total_Mängd.TextChanged += tb_TextChanged;
            // 
            // lbl_Blandning_Ok
            // 
            lbl_Blandning_Ok.AutoSize = true;
            lbl_Blandning_Ok.BackColor = SystemColors.Info;
            tlp_Main.SetColumnSpan(lbl_Blandning_Ok, 2);
            lbl_Blandning_Ok.Dock = DockStyle.Fill;
            lbl_Blandning_Ok.ForeColor = Color.White;
            lbl_Blandning_Ok.Location = new Point(152, 116);
            lbl_Blandning_Ok.Margin = new Padding(1);
            lbl_Blandning_Ok.Name = "lbl_Blandning_Ok";
            lbl_Blandning_Ok.Size = new Size(122, 21);
            lbl_Blandning_Ok.TabIndex = 14;
            lbl_Blandning_Ok.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_empty_0
            // 
            label_empty_0.AutoSize = true;
            label_empty_0.BackColor = SystemColors.Info;
            tlp_Main.SetColumnSpan(label_empty_0, 3);
            label_empty_0.Dock = DockStyle.Fill;
            label_empty_0.Location = new Point(1, 138);
            label_empty_0.Margin = new Padding(1, 0, 1, 1);
            label_empty_0.Name = "label_empty_0";
            label_empty_0.Size = new Size(273, 22);
            label_empty_0.TabIndex = 24;
            // 
            // Beräkna_Material_Blandning
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(275, 233);
            Controls.Add(tlp_Main);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(254, 39);
            Name = "Beräkna_Material_Blandning";
            Text = "Beräkna Blandning";
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private ComboBox cb_BlandningsTyp;
        private TableLayoutPanel tlp_Main;
        private Label label6;
        private Label lbl_Resultat_Material_2;
        private Label label_resultat_Material_2;
        private Label label4;
        private Label lbl_Resultat_Material_1;
        private Label label_resultat_Material_1;
        private Label label_resultat_pigment_enhet;
        private Label lbl_Resultat_Pigment;
        private Label label1;
        private Label label_Ok;
        private Label label_Material_2_enhet;
        private TextBox tb_Material_2;
        private Label label_Material_2;
        private Label label_Material_1_enhet;
        private TextBox tb_Material_1;
        private Label label_Material_1;
        private Label label_pigment_enhet;
        private TextBox tb_Pigment;
        private Label label_Pigment;
        private Label label_Färdig_mängd_enhet;
        private Label label_Färdig_mängd;
        private TextBox tb_Total_Mängd;
        private Label lbl_Blandning_Ok;
        private Label label_empty_0;
    }
}