
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Slipning_TEF
{
    partial class PC_Slipning_TEF
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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Slipning_Empty_1 = new System.Windows.Forms.Label();
            this.tb_Chimshöjd_nom = new System.Windows.Forms.TextBox();
            this.tb_Arbetsblad_nom = new System.Windows.Forms.TextBox();
            this.tb_Bladhöjd_nom = new System.Windows.Forms.TextBox();
            this.tb_Matarhjul_Vinkel_nom = new System.Windows.Forms.TextBox();
            this.tb_Helix_Vinkel_nom = new System.Windows.Forms.TextBox();
            this.tb_Matarhjul_Hastighet_nom = new System.Windows.Forms.TextBox();
            this.tb_Bladhöjd_min = new System.Windows.Forms.TextBox();
            this.tb_Bladhöjd_max = new System.Windows.Forms.TextBox();
            this.label_Slipning_Maskinparametrar = new System.Windows.Forms.Label();
            this.label_Matarhjul_Vinkel = new System.Windows.Forms.Label();
            this.label_Matarhjul_Hastighet = new System.Windows.Forms.Label();
            this.label_Matarhjul_Hastighet_enhet = new System.Windows.Forms.Label();
            this.label_Matarhjul_Vinkel_enhet = new System.Windows.Forms.Label();
            this.label_Helix_Vinkel = new System.Windows.Forms.Label();
            this.label_Helix_Vinkel_enhet = new System.Windows.Forms.Label();
            this.label_Slipning_MIN = new System.Windows.Forms.Label();
            this.label_Slipning_NOM = new System.Windows.Forms.Label();
            this.label_Slipning_MAX = new System.Windows.Forms.Label();
            this.label_Bladhöjd = new System.Windows.Forms.Label();
            this.label_Slipning_Empty_6 = new System.Windows.Forms.Label();
            this.label_Bladhöjd_enhet = new System.Windows.Forms.Label();
            this.label_Arbetsblad = new System.Windows.Forms.Label();
            this.label_Chimshöjd = new System.Windows.Forms.Label();
            this.label_Chimshöjd_enhet = new System.Windows.Forms.Label();
            this.tb_Arbetsblad_min = new System.Windows.Forms.TextBox();
            this.tb_Arbetsblad_max = new System.Windows.Forms.TextBox();
            this.tb_Matarhjul_Vinkel_min = new System.Windows.Forms.TextBox();
            this.tb_Matarhjul_Vinkel_max = new System.Windows.Forms.TextBox();
            this.cb_Dragprov_Enhet = new System.Windows.Forms.ComboBox();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 7;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlp_Main.Controls.Add(this.label1, 0, 7);
            this.tlp_Main.Controls.Add(this.label_Slipning_Empty_1, 0, 1);
            this.tlp_Main.Controls.Add(this.tb_Chimshöjd_nom, 6, 5);
            this.tlp_Main.Controls.Add(this.tb_Arbetsblad_nom, 5, 5);
            this.tlp_Main.Controls.Add(this.tb_Bladhöjd_nom, 4, 5);
            this.tlp_Main.Controls.Add(this.tb_Matarhjul_Vinkel_nom, 2, 5);
            this.tlp_Main.Controls.Add(this.tb_Helix_Vinkel_nom, 3, 5);
            this.tlp_Main.Controls.Add(this.tb_Matarhjul_Hastighet_nom, 1, 5);
            this.tlp_Main.Controls.Add(this.tb_Bladhöjd_min, 4, 4);
            this.tlp_Main.Controls.Add(this.tb_Bladhöjd_max, 4, 6);
            this.tlp_Main.Controls.Add(this.label_Slipning_Maskinparametrar, 0, 0);
            this.tlp_Main.Controls.Add(this.label_Matarhjul_Vinkel, 2, 1);
            this.tlp_Main.Controls.Add(this.label_Matarhjul_Hastighet, 1, 1);
            this.tlp_Main.Controls.Add(this.label_Matarhjul_Hastighet_enhet, 1, 3);
            this.tlp_Main.Controls.Add(this.label_Matarhjul_Vinkel_enhet, 2, 3);
            this.tlp_Main.Controls.Add(this.label_Helix_Vinkel, 3, 1);
            this.tlp_Main.Controls.Add(this.label_Helix_Vinkel_enhet, 3, 3);
            this.tlp_Main.Controls.Add(this.label_Slipning_MIN, 0, 4);
            this.tlp_Main.Controls.Add(this.label_Slipning_NOM, 0, 5);
            this.tlp_Main.Controls.Add(this.label_Slipning_MAX, 0, 6);
            this.tlp_Main.Controls.Add(this.label_Bladhöjd, 4, 1);
            this.tlp_Main.Controls.Add(this.label_Slipning_Empty_6, 5, 3);
            this.tlp_Main.Controls.Add(this.label_Bladhöjd_enhet, 4, 3);
            this.tlp_Main.Controls.Add(this.label_Arbetsblad, 5, 1);
            this.tlp_Main.Controls.Add(this.label_Chimshöjd, 6, 1);
            this.tlp_Main.Controls.Add(this.label_Chimshöjd_enhet, 6, 3);
            this.tlp_Main.Controls.Add(this.tb_Arbetsblad_min, 5, 4);
            this.tlp_Main.Controls.Add(this.tb_Arbetsblad_max, 5, 6);
            this.tlp_Main.Controls.Add(this.tb_Matarhjul_Vinkel_min, 2, 4);
            this.tlp_Main.Controls.Add(this.tb_Matarhjul_Vinkel_max, 2, 6);
            this.tlp_Main.Controls.Add(this.cb_Dragprov_Enhet, 2, 7);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 9;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Main.Size = new System.Drawing.Size(423, 154);
            this.tlp_Main.TabIndex = 946;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 1031;
            this.label1.Text = "Dragprov Enhet";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Slipning_Empty_1
            // 
            this.label_Slipning_Empty_1.BackColor = System.Drawing.Color.DarkGray;
            this.label_Slipning_Empty_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Slipning_Empty_1.Enabled = false;
            this.label_Slipning_Empty_1.Font = new System.Drawing.Font("Arial", 8F);
            this.label_Slipning_Empty_1.Location = new System.Drawing.Point(1, 23);
            this.label_Slipning_Empty_1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Slipning_Empty_1.Name = "label_Slipning_Empty_1";
            this.tlp_Main.SetRowSpan(this.label_Slipning_Empty_1, 3);
            this.label_Slipning_Empty_1.Size = new System.Drawing.Size(33, 52);
            this.label_Slipning_Empty_1.TabIndex = 1029;
            this.label_Slipning_Empty_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_Chimshöjd_nom
            // 
            this.tb_Chimshöjd_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Chimshöjd_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Chimshöjd_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Chimshöjd_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Chimshöjd_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Chimshöjd_nom.Location = new System.Drawing.Point(342, 94);
            this.tb_Chimshöjd_nom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.tb_Chimshöjd_nom.MaxLength = 5;
            this.tb_Chimshöjd_nom.Multiline = true;
            this.tb_Chimshöjd_nom.Name = "tb_Chimshöjd_nom";
            this.tb_Chimshöjd_nom.Size = new System.Drawing.Size(80, 17);
            this.tb_Chimshöjd_nom.TabIndex = 12;
            this.tb_Chimshöjd_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Arbetsblad_nom
            // 
            this.tb_Arbetsblad_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Arbetsblad_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Arbetsblad_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Arbetsblad_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Arbetsblad_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Arbetsblad_nom.Location = new System.Drawing.Point(271, 94);
            this.tb_Arbetsblad_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Arbetsblad_nom.MaxLength = 5;
            this.tb_Arbetsblad_nom.Multiline = true;
            this.tb_Arbetsblad_nom.Name = "tb_Arbetsblad_nom";
            this.tb_Arbetsblad_nom.Size = new System.Drawing.Size(70, 17);
            this.tb_Arbetsblad_nom.TabIndex = 10;
            this.tb_Arbetsblad_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Bladhöjd_nom
            // 
            this.tb_Bladhöjd_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Bladhöjd_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Bladhöjd_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Bladhöjd_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Bladhöjd_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Bladhöjd_nom.Location = new System.Drawing.Point(212, 94);
            this.tb_Bladhöjd_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Bladhöjd_nom.MaxLength = 5;
            this.tb_Bladhöjd_nom.Multiline = true;
            this.tb_Bladhöjd_nom.Name = "tb_Bladhöjd_nom";
            this.tb_Bladhöjd_nom.Size = new System.Drawing.Size(58, 17);
            this.tb_Bladhöjd_nom.TabIndex = 7;
            this.tb_Bladhöjd_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Matarhjul_Vinkel_nom
            // 
            this.tb_Matarhjul_Vinkel_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Matarhjul_Vinkel_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Matarhjul_Vinkel_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Matarhjul_Vinkel_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Matarhjul_Vinkel_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Matarhjul_Vinkel_nom.Location = new System.Drawing.Point(97, 94);
            this.tb_Matarhjul_Vinkel_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Matarhjul_Vinkel_nom.MaxLength = 3;
            this.tb_Matarhjul_Vinkel_nom.Multiline = true;
            this.tb_Matarhjul_Vinkel_nom.Name = "tb_Matarhjul_Vinkel_nom";
            this.tb_Matarhjul_Vinkel_nom.Size = new System.Drawing.Size(63, 17);
            this.tb_Matarhjul_Vinkel_nom.TabIndex = 3;
            this.tb_Matarhjul_Vinkel_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Helix_Vinkel_nom
            // 
            this.tb_Helix_Vinkel_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Helix_Vinkel_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Helix_Vinkel_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Helix_Vinkel_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Helix_Vinkel_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Helix_Vinkel_nom.Location = new System.Drawing.Point(161, 94);
            this.tb_Helix_Vinkel_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Helix_Vinkel_nom.MaxLength = 3;
            this.tb_Helix_Vinkel_nom.Multiline = true;
            this.tb_Helix_Vinkel_nom.Name = "tb_Helix_Vinkel_nom";
            this.tb_Helix_Vinkel_nom.Size = new System.Drawing.Size(50, 17);
            this.tb_Helix_Vinkel_nom.TabIndex = 5;
            this.tb_Helix_Vinkel_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Matarhjul_Hastighet_nom
            // 
            this.tb_Matarhjul_Hastighet_nom.BackColor = System.Drawing.Color.LightGray;
            this.tb_Matarhjul_Hastighet_nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Matarhjul_Hastighet_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Matarhjul_Hastighet_nom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Matarhjul_Hastighet_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.tb_Matarhjul_Hastighet_nom.Location = new System.Drawing.Point(35, 94);
            this.tb_Matarhjul_Hastighet_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Matarhjul_Hastighet_nom.MaxLength = 4;
            this.tb_Matarhjul_Hastighet_nom.Multiline = true;
            this.tb_Matarhjul_Hastighet_nom.Name = "tb_Matarhjul_Hastighet_nom";
            this.tb_Matarhjul_Hastighet_nom.Size = new System.Drawing.Size(61, 17);
            this.tb_Matarhjul_Hastighet_nom.TabIndex = 1;
            this.tb_Matarhjul_Hastighet_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Bladhöjd_min
            // 
            this.tb_Bladhöjd_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Bladhöjd_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Bladhöjd_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Bladhöjd_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Bladhöjd_min.ForeColor = System.Drawing.Color.Black;
            this.tb_Bladhöjd_min.Location = new System.Drawing.Point(212, 76);
            this.tb_Bladhöjd_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Bladhöjd_min.MaxLength = 5;
            this.tb_Bladhöjd_min.Multiline = true;
            this.tb_Bladhöjd_min.Name = "tb_Bladhöjd_min";
            this.tb_Bladhöjd_min.Size = new System.Drawing.Size(58, 17);
            this.tb_Bladhöjd_min.TabIndex = 6;
            this.tb_Bladhöjd_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Bladhöjd_max
            // 
            this.tb_Bladhöjd_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Bladhöjd_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Bladhöjd_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Bladhöjd_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Bladhöjd_max.ForeColor = System.Drawing.Color.Black;
            this.tb_Bladhöjd_max.Location = new System.Drawing.Point(212, 112);
            this.tb_Bladhöjd_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Bladhöjd_max.MaxLength = 5;
            this.tb_Bladhöjd_max.Multiline = true;
            this.tb_Bladhöjd_max.Name = "tb_Bladhöjd_max";
            this.tb_Bladhöjd_max.Size = new System.Drawing.Size(58, 17);
            this.tb_Bladhöjd_max.TabIndex = 8;
            this.tb_Bladhöjd_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Slipning_Maskinparametrar
            // 
            this.label_Slipning_Maskinparametrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tlp_Main.SetColumnSpan(this.label_Slipning_Maskinparametrar, 7);
            this.label_Slipning_Maskinparametrar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Slipning_Maskinparametrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Slipning_Maskinparametrar.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label_Slipning_Maskinparametrar.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_Slipning_Maskinparametrar.Location = new System.Drawing.Point(1, 2);
            this.label_Slipning_Maskinparametrar.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.label_Slipning_Maskinparametrar.Name = "label_Slipning_Maskinparametrar";
            this.label_Slipning_Maskinparametrar.Size = new System.Drawing.Size(421, 20);
            this.label_Slipning_Maskinparametrar.TabIndex = 933;
            this.label_Slipning_Maskinparametrar.Text = "Maskinparametrar";
            this.label_Slipning_Maskinparametrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Matarhjul_Vinkel
            // 
            this.label_Matarhjul_Vinkel.BackColor = System.Drawing.Color.White;
            this.label_Matarhjul_Vinkel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Matarhjul_Vinkel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Matarhjul_Vinkel.ForeColor = System.Drawing.Color.Black;
            this.label_Matarhjul_Vinkel.Location = new System.Drawing.Point(97, 23);
            this.label_Matarhjul_Vinkel.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Matarhjul_Vinkel.Name = "label_Matarhjul_Vinkel";
            this.tlp_Main.SetRowSpan(this.label_Matarhjul_Vinkel, 2);
            this.label_Matarhjul_Vinkel.Size = new System.Drawing.Size(63, 38);
            this.label_Matarhjul_Vinkel.TabIndex = 937;
            this.label_Matarhjul_Vinkel.Text = "Matarhjul vinkel";
            this.label_Matarhjul_Vinkel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Matarhjul_Hastighet
            // 
            this.label_Matarhjul_Hastighet.BackColor = System.Drawing.Color.White;
            this.label_Matarhjul_Hastighet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Matarhjul_Hastighet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Matarhjul_Hastighet.ForeColor = System.Drawing.Color.Black;
            this.label_Matarhjul_Hastighet.Location = new System.Drawing.Point(35, 23);
            this.label_Matarhjul_Hastighet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Matarhjul_Hastighet.Name = "label_Matarhjul_Hastighet";
            this.tlp_Main.SetRowSpan(this.label_Matarhjul_Hastighet, 2);
            this.label_Matarhjul_Hastighet.Size = new System.Drawing.Size(61, 38);
            this.label_Matarhjul_Hastighet.TabIndex = 936;
            this.label_Matarhjul_Hastighet.Text = "Matarhjul hastighet";
            this.label_Matarhjul_Hastighet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Matarhjul_Hastighet_enhet
            // 
            this.label_Matarhjul_Hastighet_enhet.BackColor = System.Drawing.Color.White;
            this.label_Matarhjul_Hastighet_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Matarhjul_Hastighet_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Matarhjul_Hastighet_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Matarhjul_Hastighet_enhet.Location = new System.Drawing.Point(35, 61);
            this.label_Matarhjul_Hastighet_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Matarhjul_Hastighet_enhet.Name = "label_Matarhjul_Hastighet_enhet";
            this.label_Matarhjul_Hastighet_enhet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Matarhjul_Hastighet_enhet.Size = new System.Drawing.Size(61, 14);
            this.label_Matarhjul_Hastighet_enhet.TabIndex = 939;
            this.label_Matarhjul_Hastighet_enhet.Text = "rpm";
            this.label_Matarhjul_Hastighet_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Matarhjul_Vinkel_enhet
            // 
            this.label_Matarhjul_Vinkel_enhet.BackColor = System.Drawing.Color.White;
            this.label_Matarhjul_Vinkel_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Matarhjul_Vinkel_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Matarhjul_Vinkel_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Matarhjul_Vinkel_enhet.Location = new System.Drawing.Point(97, 61);
            this.label_Matarhjul_Vinkel_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Matarhjul_Vinkel_enhet.Name = "label_Matarhjul_Vinkel_enhet";
            this.label_Matarhjul_Vinkel_enhet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Matarhjul_Vinkel_enhet.Size = new System.Drawing.Size(63, 14);
            this.label_Matarhjul_Vinkel_enhet.TabIndex = 940;
            this.label_Matarhjul_Vinkel_enhet.Text = "º";
            this.label_Matarhjul_Vinkel_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Helix_Vinkel
            // 
            this.label_Helix_Vinkel.BackColor = System.Drawing.Color.White;
            this.label_Helix_Vinkel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Helix_Vinkel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Helix_Vinkel.ForeColor = System.Drawing.Color.Black;
            this.label_Helix_Vinkel.Location = new System.Drawing.Point(161, 23);
            this.label_Helix_Vinkel.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Helix_Vinkel.Name = "label_Helix_Vinkel";
            this.tlp_Main.SetRowSpan(this.label_Helix_Vinkel, 2);
            this.label_Helix_Vinkel.Size = new System.Drawing.Size(50, 38);
            this.label_Helix_Vinkel.TabIndex = 938;
            this.label_Helix_Vinkel.Text = "Helix vinkel";
            this.label_Helix_Vinkel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Helix_Vinkel_enhet
            // 
            this.label_Helix_Vinkel_enhet.BackColor = System.Drawing.Color.White;
            this.label_Helix_Vinkel_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Helix_Vinkel_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Helix_Vinkel_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Helix_Vinkel_enhet.Location = new System.Drawing.Point(161, 61);
            this.label_Helix_Vinkel_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Helix_Vinkel_enhet.Name = "label_Helix_Vinkel_enhet";
            this.label_Helix_Vinkel_enhet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Helix_Vinkel_enhet.Size = new System.Drawing.Size(50, 14);
            this.label_Helix_Vinkel_enhet.TabIndex = 941;
            this.label_Helix_Vinkel_enhet.Text = "º";
            this.label_Helix_Vinkel_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Slipning_MIN
            // 
            this.label_Slipning_MIN.BackColor = System.Drawing.Color.White;
            this.label_Slipning_MIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Slipning_MIN.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.label_Slipning_MIN.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_Slipning_MIN.Location = new System.Drawing.Point(1, 76);
            this.label_Slipning_MIN.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Slipning_MIN.Name = "label_Slipning_MIN";
            this.label_Slipning_MIN.Size = new System.Drawing.Size(33, 17);
            this.label_Slipning_MIN.TabIndex = 942;
            this.label_Slipning_MIN.Text = "MIN";
            this.label_Slipning_MIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Slipning_NOM
            // 
            this.label_Slipning_NOM.BackColor = System.Drawing.Color.White;
            this.label_Slipning_NOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Slipning_NOM.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.label_Slipning_NOM.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Slipning_NOM.Location = new System.Drawing.Point(1, 94);
            this.label_Slipning_NOM.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Slipning_NOM.Name = "label_Slipning_NOM";
            this.label_Slipning_NOM.Size = new System.Drawing.Size(33, 17);
            this.label_Slipning_NOM.TabIndex = 943;
            this.label_Slipning_NOM.Text = "NOM";
            this.label_Slipning_NOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Slipning_MAX
            // 
            this.label_Slipning_MAX.AutoSize = true;
            this.label_Slipning_MAX.BackColor = System.Drawing.Color.White;
            this.label_Slipning_MAX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Slipning_MAX.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.label_Slipning_MAX.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_Slipning_MAX.Location = new System.Drawing.Point(1, 112);
            this.label_Slipning_MAX.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Slipning_MAX.Name = "label_Slipning_MAX";
            this.label_Slipning_MAX.Size = new System.Drawing.Size(33, 17);
            this.label_Slipning_MAX.TabIndex = 944;
            this.label_Slipning_MAX.Text = "MAX";
            this.label_Slipning_MAX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Bladhöjd
            // 
            this.label_Bladhöjd.BackColor = System.Drawing.Color.White;
            this.label_Bladhöjd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Bladhöjd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Bladhöjd.ForeColor = System.Drawing.Color.Black;
            this.label_Bladhöjd.Location = new System.Drawing.Point(212, 23);
            this.label_Bladhöjd.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Bladhöjd.Name = "label_Bladhöjd";
            this.tlp_Main.SetRowSpan(this.label_Bladhöjd, 2);
            this.label_Bladhöjd.Size = new System.Drawing.Size(58, 38);
            this.label_Bladhöjd.TabIndex = 997;
            this.label_Bladhöjd.Text = "Bladhöjd";
            this.label_Bladhöjd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Slipning_Empty_6
            // 
            this.label_Slipning_Empty_6.BackColor = System.Drawing.Color.White;
            this.label_Slipning_Empty_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Slipning_Empty_6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Slipning_Empty_6.ForeColor = System.Drawing.Color.Black;
            this.label_Slipning_Empty_6.Location = new System.Drawing.Point(271, 61);
            this.label_Slipning_Empty_6.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Slipning_Empty_6.Name = "label_Slipning_Empty_6";
            this.label_Slipning_Empty_6.Size = new System.Drawing.Size(70, 14);
            this.label_Slipning_Empty_6.TabIndex = 1000;
            this.label_Slipning_Empty_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Bladhöjd_enhet
            // 
            this.label_Bladhöjd_enhet.BackColor = System.Drawing.Color.White;
            this.label_Bladhöjd_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Bladhöjd_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Bladhöjd_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Bladhöjd_enhet.Location = new System.Drawing.Point(212, 61);
            this.label_Bladhöjd_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Bladhöjd_enhet.Name = "label_Bladhöjd_enhet";
            this.label_Bladhöjd_enhet.Size = new System.Drawing.Size(58, 14);
            this.label_Bladhöjd_enhet.TabIndex = 1001;
            this.label_Bladhöjd_enhet.Text = "mm";
            this.label_Bladhöjd_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Arbetsblad
            // 
            this.label_Arbetsblad.BackColor = System.Drawing.Color.White;
            this.label_Arbetsblad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Arbetsblad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Arbetsblad.ForeColor = System.Drawing.Color.Black;
            this.label_Arbetsblad.Location = new System.Drawing.Point(271, 23);
            this.label_Arbetsblad.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Arbetsblad.Name = "label_Arbetsblad";
            this.tlp_Main.SetRowSpan(this.label_Arbetsblad, 2);
            this.label_Arbetsblad.Size = new System.Drawing.Size(70, 38);
            this.label_Arbetsblad.TabIndex = 998;
            this.label_Arbetsblad.Text = "Arbetsblad";
            this.label_Arbetsblad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Chimshöjd
            // 
            this.label_Chimshöjd.BackColor = System.Drawing.Color.White;
            this.label_Chimshöjd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Chimshöjd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Chimshöjd.ForeColor = System.Drawing.Color.Black;
            this.label_Chimshöjd.Location = new System.Drawing.Point(342, 23);
            this.label_Chimshöjd.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Chimshöjd.Name = "label_Chimshöjd";
            this.tlp_Main.SetRowSpan(this.label_Chimshöjd, 2);
            this.label_Chimshöjd.Size = new System.Drawing.Size(80, 38);
            this.label_Chimshöjd.TabIndex = 1005;
            this.label_Chimshöjd.Text = "Chimshöjd";
            this.label_Chimshöjd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Chimshöjd_enhet
            // 
            this.label_Chimshöjd_enhet.BackColor = System.Drawing.Color.White;
            this.label_Chimshöjd_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Chimshöjd_enhet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Chimshöjd_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_Chimshöjd_enhet.Location = new System.Drawing.Point(342, 61);
            this.label_Chimshöjd_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_Chimshöjd_enhet.Name = "label_Chimshöjd_enhet";
            this.label_Chimshöjd_enhet.Size = new System.Drawing.Size(80, 14);
            this.label_Chimshöjd_enhet.TabIndex = 1008;
            this.label_Chimshöjd_enhet.Text = "mm";
            this.label_Chimshöjd_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Arbetsblad_min
            // 
            this.tb_Arbetsblad_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Arbetsblad_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Arbetsblad_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Arbetsblad_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Arbetsblad_min.ForeColor = System.Drawing.Color.Black;
            this.tb_Arbetsblad_min.Location = new System.Drawing.Point(271, 76);
            this.tb_Arbetsblad_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Arbetsblad_min.MaxLength = 4;
            this.tb_Arbetsblad_min.Multiline = true;
            this.tb_Arbetsblad_min.Name = "tb_Arbetsblad_min";
            this.tb_Arbetsblad_min.Size = new System.Drawing.Size(70, 17);
            this.tb_Arbetsblad_min.TabIndex = 9;
            this.tb_Arbetsblad_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Arbetsblad_max
            // 
            this.tb_Arbetsblad_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Arbetsblad_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Arbetsblad_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Arbetsblad_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Arbetsblad_max.ForeColor = System.Drawing.Color.Black;
            this.tb_Arbetsblad_max.Location = new System.Drawing.Point(271, 112);
            this.tb_Arbetsblad_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Arbetsblad_max.MaxLength = 4;
            this.tb_Arbetsblad_max.Multiline = true;
            this.tb_Arbetsblad_max.Name = "tb_Arbetsblad_max";
            this.tb_Arbetsblad_max.Size = new System.Drawing.Size(70, 17);
            this.tb_Arbetsblad_max.TabIndex = 11;
            this.tb_Arbetsblad_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Matarhjul_Vinkel_min
            // 
            this.tb_Matarhjul_Vinkel_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Matarhjul_Vinkel_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Matarhjul_Vinkel_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Matarhjul_Vinkel_min.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Matarhjul_Vinkel_min.ForeColor = System.Drawing.Color.Black;
            this.tb_Matarhjul_Vinkel_min.Location = new System.Drawing.Point(97, 76);
            this.tb_Matarhjul_Vinkel_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Matarhjul_Vinkel_min.MaxLength = 5;
            this.tb_Matarhjul_Vinkel_min.Multiline = true;
            this.tb_Matarhjul_Vinkel_min.Name = "tb_Matarhjul_Vinkel_min";
            this.tb_Matarhjul_Vinkel_min.Size = new System.Drawing.Size(63, 17);
            this.tb_Matarhjul_Vinkel_min.TabIndex = 2;
            this.tb_Matarhjul_Vinkel_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Matarhjul_Vinkel_max
            // 
            this.tb_Matarhjul_Vinkel_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tb_Matarhjul_Vinkel_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Matarhjul_Vinkel_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Matarhjul_Vinkel_max.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.tb_Matarhjul_Vinkel_max.ForeColor = System.Drawing.Color.Black;
            this.tb_Matarhjul_Vinkel_max.Location = new System.Drawing.Point(97, 112);
            this.tb_Matarhjul_Vinkel_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.tb_Matarhjul_Vinkel_max.MaxLength = 5;
            this.tb_Matarhjul_Vinkel_max.Multiline = true;
            this.tb_Matarhjul_Vinkel_max.Name = "tb_Matarhjul_Vinkel_max";
            this.tb_Matarhjul_Vinkel_max.Size = new System.Drawing.Size(63, 17);
            this.tb_Matarhjul_Vinkel_max.TabIndex = 4;
            this.tb_Matarhjul_Vinkel_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_Dragprov_Enhet
            // 
            this.cb_Dragprov_Enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Dragprov_Enhet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Dragprov_Enhet.FormattingEnabled = true;
            this.cb_Dragprov_Enhet.Items.AddRange(new object[] {
            "lbf",
            "N"});
            this.cb_Dragprov_Enhet.Location = new System.Drawing.Point(96, 130);
            this.cb_Dragprov_Enhet.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Dragprov_Enhet.Name = "cb_Dragprov_Enhet";
            this.cb_Dragprov_Enhet.Size = new System.Drawing.Size(64, 21);
            this.cb_Dragprov_Enhet.TabIndex = 1030;
            // 
            // PC_Slipning_TEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "PC_Slipning_TEF";
            this.Size = new System.Drawing.Size(423, 154);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Label label1;
        private Label label_Slipning_Empty_1;
        private TextBox tb_Chimshöjd_nom;
        private TextBox tb_Arbetsblad_nom;
        private TextBox tb_Bladhöjd_nom;
        private TextBox tb_Matarhjul_Vinkel_nom;
        private TextBox tb_Helix_Vinkel_nom;
        private TextBox tb_Matarhjul_Hastighet_nom;
        private TextBox tb_Bladhöjd_min;
        private TextBox tb_Bladhöjd_max;
        private Label label_Slipning_Maskinparametrar;
        private Label label_Matarhjul_Vinkel;
        private Label label_Matarhjul_Hastighet;
        private Label label_Matarhjul_Hastighet_enhet;
        private Label label_Matarhjul_Vinkel_enhet;
        private Label label_Helix_Vinkel;
        private Label label_Helix_Vinkel_enhet;
        private Label label_Slipning_MIN;
        private Label label_Slipning_NOM;
        private Label label_Slipning_MAX;
        private Label label_Bladhöjd;
        private Label label_Slipning_Empty_6;
        private Label label_Bladhöjd_enhet;
        private Label label_Arbetsblad;
        private Label label_Chimshöjd;
        private Label label_Chimshöjd_enhet;
        private TextBox tb_Arbetsblad_min;
        private TextBox tb_Arbetsblad_max;
        private TextBox tb_Matarhjul_Vinkel_min;
        private TextBox tb_Matarhjul_Vinkel_max;
        private ComboBox cb_Dragprov_Enhet;
    }
}
