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
            this.cb_BlandningsTyp = new System.Windows.Forms.ComboBox();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_Resultat_Material_2 = new System.Windows.Forms.Label();
            this.label_resultat_Material_2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Resultat_Material_1 = new System.Windows.Forms.Label();
            this.label_resultat_Material_1 = new System.Windows.Forms.Label();
            this.label_resultat_pigment_enhet = new System.Windows.Forms.Label();
            this.lbl_Resultat_Pigment = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Ok = new System.Windows.Forms.Label();
            this.label_Material_2_enhet = new System.Windows.Forms.Label();
            this.tb_Material_2 = new System.Windows.Forms.TextBox();
            this.label_Material_2 = new System.Windows.Forms.Label();
            this.label_Material_1_enhet = new System.Windows.Forms.Label();
            this.tb_Material_1 = new System.Windows.Forms.TextBox();
            this.label_Material_1 = new System.Windows.Forms.Label();
            this.label_pigment_enhet = new System.Windows.Forms.Label();
            this.tb_Pigment = new System.Windows.Forms.TextBox();
            this.label_Pigment = new System.Windows.Forms.Label();
            this.label_Färdig_mängd_enhet = new System.Windows.Forms.Label();
            this.label_Färdig_mängd = new System.Windows.Forms.Label();
            this.tb_Total_Mängd = new System.Windows.Forms.TextBox();
            this.lbl_Blandning_Ok = new System.Windows.Forms.Label();
            this.label_empty_0 = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_BlandningsTyp
            // 
            this.tlp_Main.SetColumnSpan(this.cb_BlandningsTyp, 3);
            this.cb_BlandningsTyp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_BlandningsTyp.FormattingEnabled = true;
            this.cb_BlandningsTyp.Items.AddRange(new object[] {
            "Ett material + Pigment",
            "Två material + Pigment",
            "Två material utan Pigment"});
            this.cb_BlandningsTyp.Location = new System.Drawing.Point(0, 0);
            this.cb_BlandningsTyp.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.cb_BlandningsTyp.Name = "cb_BlandningsTyp";
            this.cb_BlandningsTyp.Size = new System.Drawing.Size(236, 21);
            this.cb_BlandningsTyp.TabIndex = 0;
            this.cb_BlandningsTyp.SelectedIndexChanged += new System.EventHandler(this.cb_BlandningsTyp_SelectedIndexChanged);
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 3;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.08475F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.30508F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.61017F));
            this.tlp_Main.Controls.Add(this.label6, 2, 9);
            this.tlp_Main.Controls.Add(this.lbl_Resultat_Material_2, 1, 9);
            this.tlp_Main.Controls.Add(this.label_resultat_Material_2, 0, 9);
            this.tlp_Main.Controls.Add(this.label4, 2, 8);
            this.tlp_Main.Controls.Add(this.lbl_Resultat_Material_1, 1, 8);
            this.tlp_Main.Controls.Add(this.label_resultat_Material_1, 0, 8);
            this.tlp_Main.Controls.Add(this.label_resultat_pigment_enhet, 2, 7);
            this.tlp_Main.Controls.Add(this.lbl_Resultat_Pigment, 1, 7);
            this.tlp_Main.Controls.Add(this.label1, 0, 7);
            this.tlp_Main.Controls.Add(this.label_Ok, 0, 5);
            this.tlp_Main.Controls.Add(this.label_Material_2_enhet, 2, 4);
            this.tlp_Main.Controls.Add(this.tb_Material_2, 1, 4);
            this.tlp_Main.Controls.Add(this.label_Material_2, 0, 4);
            this.tlp_Main.Controls.Add(this.label_Material_1_enhet, 2, 3);
            this.tlp_Main.Controls.Add(this.tb_Material_1, 1, 3);
            this.tlp_Main.Controls.Add(this.label_Material_1, 0, 3);
            this.tlp_Main.Controls.Add(this.label_pigment_enhet, 2, 2);
            this.tlp_Main.Controls.Add(this.tb_Pigment, 1, 2);
            this.tlp_Main.Controls.Add(this.label_Pigment, 0, 2);
            this.tlp_Main.Controls.Add(this.label_Färdig_mängd_enhet, 2, 1);
            this.tlp_Main.Controls.Add(this.cb_BlandningsTyp, 0, 0);
            this.tlp_Main.Controls.Add(this.label_Färdig_mängd, 0, 1);
            this.tlp_Main.Controls.Add(this.tb_Total_Mängd, 1, 1);
            this.tlp_Main.Controls.Add(this.lbl_Blandning_Ok, 1, 5);
            this.tlp_Main.Controls.Add(this.label_empty_0, 0, 6);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 10;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(236, 202);
            this.tlp_Main.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Info;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label6.Location = new System.Drawing.Point(185, 181);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "kg";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Resultat_Material_2
            // 
            this.lbl_Resultat_Material_2.AutoSize = true;
            this.lbl_Resultat_Material_2.BackColor = System.Drawing.Color.Silver;
            this.lbl_Resultat_Material_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Resultat_Material_2.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.lbl_Resultat_Material_2.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_Resultat_Material_2.Location = new System.Drawing.Point(131, 181);
            this.lbl_Resultat_Material_2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Resultat_Material_2.Name = "lbl_Resultat_Material_2";
            this.lbl_Resultat_Material_2.Size = new System.Drawing.Size(53, 20);
            this.lbl_Resultat_Material_2.TabIndex = 22;
            this.lbl_Resultat_Material_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_resultat_Material_2
            // 
            this.label_resultat_Material_2.AutoSize = true;
            this.label_resultat_Material_2.BackColor = System.Drawing.SystemColors.Info;
            this.label_resultat_Material_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_resultat_Material_2.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_resultat_Material_2.Location = new System.Drawing.Point(1, 181);
            this.label_resultat_Material_2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_resultat_Material_2.Name = "label_resultat_Material_2";
            this.label_resultat_Material_2.Size = new System.Drawing.Size(129, 20);
            this.label_resultat_Material_2.TabIndex = 21;
            this.label_resultat_Material_2.Text = "Material 2:";
            this.label_resultat_Material_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label4.Location = new System.Drawing.Point(185, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "kg";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Resultat_Material_1
            // 
            this.lbl_Resultat_Material_1.AutoSize = true;
            this.lbl_Resultat_Material_1.BackColor = System.Drawing.Color.Silver;
            this.lbl_Resultat_Material_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Resultat_Material_1.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.lbl_Resultat_Material_1.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_Resultat_Material_1.Location = new System.Drawing.Point(131, 161);
            this.lbl_Resultat_Material_1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Resultat_Material_1.Name = "lbl_Resultat_Material_1";
            this.lbl_Resultat_Material_1.Size = new System.Drawing.Size(53, 19);
            this.lbl_Resultat_Material_1.TabIndex = 19;
            this.lbl_Resultat_Material_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_resultat_Material_1
            // 
            this.label_resultat_Material_1.AutoSize = true;
            this.label_resultat_Material_1.BackColor = System.Drawing.SystemColors.Info;
            this.label_resultat_Material_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_resultat_Material_1.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_resultat_Material_1.Location = new System.Drawing.Point(1, 161);
            this.label_resultat_Material_1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_resultat_Material_1.Name = "label_resultat_Material_1";
            this.label_resultat_Material_1.Size = new System.Drawing.Size(129, 20);
            this.label_resultat_Material_1.TabIndex = 18;
            this.label_resultat_Material_1.Text = "Material 1:";
            this.label_resultat_Material_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_resultat_pigment_enhet
            // 
            this.label_resultat_pigment_enhet.AutoSize = true;
            this.label_resultat_pigment_enhet.BackColor = System.Drawing.SystemColors.Info;
            this.label_resultat_pigment_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_resultat_pigment_enhet.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_resultat_pigment_enhet.Location = new System.Drawing.Point(185, 141);
            this.label_resultat_pigment_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_resultat_pigment_enhet.Name = "label_resultat_pigment_enhet";
            this.label_resultat_pigment_enhet.Size = new System.Drawing.Size(50, 20);
            this.label_resultat_pigment_enhet.TabIndex = 17;
            this.label_resultat_pigment_enhet.Text = "kg";
            this.label_resultat_pigment_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Resultat_Pigment
            // 
            this.lbl_Resultat_Pigment.AutoSize = true;
            this.lbl_Resultat_Pigment.BackColor = System.Drawing.Color.Silver;
            this.lbl_Resultat_Pigment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Resultat_Pigment.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.lbl_Resultat_Pigment.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_Resultat_Pigment.Location = new System.Drawing.Point(131, 141);
            this.lbl_Resultat_Pigment.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Resultat_Pigment.Name = "lbl_Resultat_Pigment";
            this.lbl_Resultat_Pigment.Size = new System.Drawing.Size(53, 19);
            this.lbl_Resultat_Pigment.TabIndex = 16;
            this.lbl_Resultat_Pigment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label1.Location = new System.Drawing.Point(1, 141);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Pigment:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Ok
            // 
            this.label_Ok.AutoSize = true;
            this.label_Ok.BackColor = System.Drawing.SystemColors.Info;
            this.label_Ok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Ok.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_Ok.Location = new System.Drawing.Point(1, 101);
            this.label_Ok.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Ok.Name = "label_Ok";
            this.label_Ok.Size = new System.Drawing.Size(129, 19);
            this.label_Ok.TabIndex = 13;
            this.label_Ok.Text = "100% ?";
            this.label_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Material_2_enhet
            // 
            this.label_Material_2_enhet.AutoSize = true;
            this.label_Material_2_enhet.BackColor = System.Drawing.SystemColors.Info;
            this.label_Material_2_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Material_2_enhet.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_Material_2_enhet.Location = new System.Drawing.Point(185, 81);
            this.label_Material_2_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Material_2_enhet.Name = "label_Material_2_enhet";
            this.label_Material_2_enhet.Size = new System.Drawing.Size(50, 20);
            this.label_Material_2_enhet.TabIndex = 12;
            this.label_Material_2_enhet.Text = "%";
            this.label_Material_2_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_Material_2
            // 
            this.tb_Material_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Material_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Material_2.Font = new System.Drawing.Font("Courier New", 12F);
            this.tb_Material_2.Location = new System.Drawing.Point(131, 82);
            this.tb_Material_2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Material_2.Name = "tb_Material_2";
            this.tb_Material_2.Size = new System.Drawing.Size(53, 19);
            this.tb_Material_2.TabIndex = 11;
            this.tb_Material_2.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // label_Material_2
            // 
            this.label_Material_2.AutoSize = true;
            this.label_Material_2.BackColor = System.Drawing.SystemColors.Info;
            this.label_Material_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Material_2.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_Material_2.Location = new System.Drawing.Point(1, 81);
            this.label_Material_2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Material_2.Name = "label_Material_2";
            this.label_Material_2.Size = new System.Drawing.Size(129, 20);
            this.label_Material_2.TabIndex = 10;
            this.label_Material_2.Text = "Material 2:";
            this.label_Material_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Material_1_enhet
            // 
            this.label_Material_1_enhet.AutoSize = true;
            this.label_Material_1_enhet.BackColor = System.Drawing.SystemColors.Info;
            this.label_Material_1_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Material_1_enhet.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_Material_1_enhet.Location = new System.Drawing.Point(185, 61);
            this.label_Material_1_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Material_1_enhet.Name = "label_Material_1_enhet";
            this.label_Material_1_enhet.Size = new System.Drawing.Size(50, 20);
            this.label_Material_1_enhet.TabIndex = 9;
            this.label_Material_1_enhet.Text = "%";
            this.label_Material_1_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_Material_1
            // 
            this.tb_Material_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Material_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Material_1.Font = new System.Drawing.Font("Courier New", 12F);
            this.tb_Material_1.Location = new System.Drawing.Point(131, 62);
            this.tb_Material_1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Material_1.Name = "tb_Material_1";
            this.tb_Material_1.Size = new System.Drawing.Size(53, 19);
            this.tb_Material_1.TabIndex = 8;
            this.tb_Material_1.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // label_Material_1
            // 
            this.label_Material_1.AutoSize = true;
            this.label_Material_1.BackColor = System.Drawing.SystemColors.Info;
            this.label_Material_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Material_1.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_Material_1.Location = new System.Drawing.Point(1, 61);
            this.label_Material_1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Material_1.Name = "label_Material_1";
            this.label_Material_1.Size = new System.Drawing.Size(129, 20);
            this.label_Material_1.TabIndex = 7;
            this.label_Material_1.Text = "Material 1:";
            this.label_Material_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_pigment_enhet
            // 
            this.label_pigment_enhet.AutoSize = true;
            this.label_pigment_enhet.BackColor = System.Drawing.SystemColors.Info;
            this.label_pigment_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_pigment_enhet.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_pigment_enhet.Location = new System.Drawing.Point(185, 41);
            this.label_pigment_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_pigment_enhet.Name = "label_pigment_enhet";
            this.label_pigment_enhet.Size = new System.Drawing.Size(50, 20);
            this.label_pigment_enhet.TabIndex = 6;
            this.label_pigment_enhet.Text = "%";
            this.label_pigment_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_Pigment
            // 
            this.tb_Pigment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Pigment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Pigment.Font = new System.Drawing.Font("Courier New", 12F);
            this.tb_Pigment.Location = new System.Drawing.Point(131, 42);
            this.tb_Pigment.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Pigment.Name = "tb_Pigment";
            this.tb_Pigment.Size = new System.Drawing.Size(53, 19);
            this.tb_Pigment.TabIndex = 5;
            this.tb_Pigment.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // label_Pigment
            // 
            this.label_Pigment.AutoSize = true;
            this.label_Pigment.BackColor = System.Drawing.SystemColors.Info;
            this.label_Pigment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Pigment.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_Pigment.Location = new System.Drawing.Point(1, 41);
            this.label_Pigment.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Pigment.Name = "label_Pigment";
            this.label_Pigment.Size = new System.Drawing.Size(129, 20);
            this.label_Pigment.TabIndex = 4;
            this.label_Pigment.Text = "Pigment:";
            this.label_Pigment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Färdig_mängd_enhet
            // 
            this.label_Färdig_mängd_enhet.AutoSize = true;
            this.label_Färdig_mängd_enhet.BackColor = System.Drawing.SystemColors.Info;
            this.label_Färdig_mängd_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Färdig_mängd_enhet.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_Färdig_mängd_enhet.Location = new System.Drawing.Point(185, 22);
            this.label_Färdig_mängd_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Färdig_mängd_enhet.Name = "label_Färdig_mängd_enhet";
            this.label_Färdig_mängd_enhet.Size = new System.Drawing.Size(50, 19);
            this.label_Färdig_mängd_enhet.TabIndex = 3;
            this.label_Färdig_mängd_enhet.Text = "kg";
            this.label_Färdig_mängd_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Färdig_mängd
            // 
            this.label_Färdig_mängd.AutoSize = true;
            this.label_Färdig_mängd.BackColor = System.Drawing.SystemColors.Info;
            this.label_Färdig_mängd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Färdig_mängd.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label_Färdig_mängd.Location = new System.Drawing.Point(1, 22);
            this.label_Färdig_mängd.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Färdig_mängd.Name = "label_Färdig_mängd";
            this.label_Färdig_mängd.Size = new System.Drawing.Size(129, 19);
            this.label_Färdig_mängd.TabIndex = 1;
            this.label_Färdig_mängd.Text = "FÄRDIG mängd:";
            this.label_Färdig_mängd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Total_Mängd
            // 
            this.tb_Total_Mängd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Total_Mängd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Total_Mängd.Font = new System.Drawing.Font("Courier New", 12F);
            this.tb_Total_Mängd.Location = new System.Drawing.Point(131, 22);
            this.tb_Total_Mängd.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.tb_Total_Mängd.Name = "tb_Total_Mängd";
            this.tb_Total_Mängd.Size = new System.Drawing.Size(53, 19);
            this.tb_Total_Mängd.TabIndex = 2;
            this.tb_Total_Mängd.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // lbl_Blandning_Ok
            // 
            this.lbl_Blandning_Ok.AutoSize = true;
            this.lbl_Blandning_Ok.BackColor = System.Drawing.SystemColors.Info;
            this.tlp_Main.SetColumnSpan(this.lbl_Blandning_Ok, 2);
            this.lbl_Blandning_Ok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Blandning_Ok.ForeColor = System.Drawing.Color.White;
            this.lbl_Blandning_Ok.Location = new System.Drawing.Point(131, 102);
            this.lbl_Blandning_Ok.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_Blandning_Ok.Name = "lbl_Blandning_Ok";
            this.lbl_Blandning_Ok.Size = new System.Drawing.Size(104, 18);
            this.lbl_Blandning_Ok.TabIndex = 14;
            this.lbl_Blandning_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_empty_0
            // 
            this.label_empty_0.AutoSize = true;
            this.label_empty_0.BackColor = System.Drawing.SystemColors.Info;
            this.tlp_Main.SetColumnSpan(this.label_empty_0, 3);
            this.label_empty_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_empty_0.Location = new System.Drawing.Point(1, 121);
            this.label_empty_0.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_empty_0.Name = "label_empty_0";
            this.label_empty_0.Size = new System.Drawing.Size(234, 19);
            this.label_empty_0.TabIndex = 24;
            // 
            // Beräkna_Material_Blandning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(236, 202);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(220, 39);
            this.Name = "Beräkna_Material_Blandning";
            this.Text = "Beräkna Blandning";
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

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