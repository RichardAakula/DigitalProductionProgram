
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Kragning_TEF
{
    partial class PC_Kragning
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label_Kylning = new System.Windows.Forms.Label();
            this.label_Värme = new System.Windows.Forms.Label();
            this.label_Finmatning = new System.Windows.Forms.Label();
            this.label_Verktyg = new System.Windows.Forms.Label();
            this.label_Induktion = new System.Windows.Forms.Label();
            this.label_Tryckluft = new System.Windows.Forms.Label();
            this.label_Maskinparametrar = new System.Windows.Forms.Label();
            this.label_Fasthållning = new System.Windows.Forms.Label();
            this.label_TryckluftFasthållning_Mpa = new System.Windows.Forms.Label();
            this.label_TryckluftFinmatning_Mpa = new System.Windows.Forms.Label();
            this.label_InduktionVärme_sec = new System.Windows.Forms.Label();
            this.label_InduktionKylning_sec = new System.Windows.Forms.Label();
            this.label_min = new System.Windows.Forms.Label();
            this.label_nom = new System.Windows.Forms.Label();
            this.labelmax = new System.Windows.Forms.Label();
            this.label_PTFE_ID_mm = new System.Windows.Forms.Label();
            this.label_PTFE_OD_mm = new System.Windows.Forms.Label();
            this.label_PTFE_ID = new System.Windows.Forms.Label();
            this.label_KragDon_max = new System.Windows.Forms.Label();
            this.label_PTFE_OD = new System.Windows.Forms.Label();
            this.label_Kragningsdon = new System.Windows.Forms.Label();
            this.label_KragdonOD = new System.Windows.Forms.Label();
            this.label_KragdonNr = new System.Windows.Forms.Label();
            this.label_KragDon_min = new System.Windows.Forms.Label();
            this.Kragningsdon_Nr = new System.Windows.Forms.TextBox();
            this.label_Sign = new System.Windows.Forms.Label();
            this.label_AnstNr = new System.Windows.Forms.Label();
            this.label_Datum = new System.Windows.Forms.Label();
            this.dgv_Processkort = new System.Windows.Forms.DataGridView();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Processkort)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 12;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlp_Main.Controls.Add(this.label_Kylning, 4, 2);
            this.tlp_Main.Controls.Add(this.label_Värme, 3, 2);
            this.tlp_Main.Controls.Add(this.label_Finmatning, 2, 2);
            this.tlp_Main.Controls.Add(this.label_Verktyg, 5, 1);
            this.tlp_Main.Controls.Add(this.label_Induktion, 3, 1);
            this.tlp_Main.Controls.Add(this.label_Tryckluft, 1, 1);
            this.tlp_Main.Controls.Add(this.label_Maskinparametrar, 0, 0);
            this.tlp_Main.Controls.Add(this.label_Fasthållning, 1, 2);
            this.tlp_Main.Controls.Add(this.label_TryckluftFasthållning_Mpa, 1, 5);
            this.tlp_Main.Controls.Add(this.label_TryckluftFinmatning_Mpa, 2, 5);
            this.tlp_Main.Controls.Add(this.label_InduktionVärme_sec, 3, 5);
            this.tlp_Main.Controls.Add(this.label_InduktionKylning_sec, 4, 5);
            this.tlp_Main.Controls.Add(this.label_min, 0, 6);
            this.tlp_Main.Controls.Add(this.label_nom, 0, 7);
            this.tlp_Main.Controls.Add(this.labelmax, 0, 8);
            this.tlp_Main.Controls.Add(this.label_PTFE_ID_mm, 5, 5);
            this.tlp_Main.Controls.Add(this.label_PTFE_OD_mm, 6, 5);
            this.tlp_Main.Controls.Add(this.label_PTFE_ID, 5, 2);
            this.tlp_Main.Controls.Add(this.label_KragDon_max, 8, 5);
            this.tlp_Main.Controls.Add(this.label_PTFE_OD, 6, 2);
            this.tlp_Main.Controls.Add(this.label_Kragningsdon, 7, 2);
            this.tlp_Main.Controls.Add(this.label_KragdonOD, 7, 4);
            this.tlp_Main.Controls.Add(this.label_KragdonNr, 7, 3);
            this.tlp_Main.Controls.Add(this.label_KragDon_min, 7, 5);
            this.tlp_Main.Controls.Add(this.Kragningsdon_Nr, 8, 3);
            this.tlp_Main.Controls.Add(this.label_Sign, 11, 1);
            this.tlp_Main.Controls.Add(this.label_AnstNr, 10, 1);
            this.tlp_Main.Controls.Add(this.label_Datum, 9, 1);
            this.tlp_Main.Controls.Add(this.dgv_Processkort, 1, 6);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 9;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(698, 180);
            this.tlp_Main.TabIndex = 0;
            // 
            // label_Kylning
            // 
            this.label_Kylning.BackColor = System.Drawing.Color.White;
            this.label_Kylning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Kylning.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Kylning.ForeColor = System.Drawing.Color.Black;
            this.label_Kylning.Location = new System.Drawing.Point(190, 40);
            this.label_Kylning.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Kylning.Name = "label_Kylning";
            this.tlp_Main.SetRowSpan(this.label_Kylning, 3);
            this.label_Kylning.Size = new System.Drawing.Size(52, 60);
            this.label_Kylning.TabIndex = 913;
            this.label_Kylning.Text = "Kylning";
            this.label_Kylning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Värme
            // 
            this.label_Värme.BackColor = System.Drawing.Color.White;
            this.label_Värme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Värme.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Värme.ForeColor = System.Drawing.Color.Black;
            this.label_Värme.Location = new System.Drawing.Point(137, 40);
            this.label_Värme.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Värme.Name = "label_Värme";
            this.tlp_Main.SetRowSpan(this.label_Värme, 3);
            this.label_Värme.Size = new System.Drawing.Size(52, 60);
            this.label_Värme.TabIndex = 912;
            this.label_Värme.Text = "Värme";
            this.label_Värme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Finmatning
            // 
            this.label_Finmatning.BackColor = System.Drawing.Color.White;
            this.label_Finmatning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Finmatning.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Finmatning.ForeColor = System.Drawing.Color.Black;
            this.label_Finmatning.Location = new System.Drawing.Point(84, 40);
            this.label_Finmatning.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Finmatning.Name = "label_Finmatning";
            this.label_Finmatning.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tlp_Main.SetRowSpan(this.label_Finmatning, 3);
            this.label_Finmatning.Size = new System.Drawing.Size(52, 60);
            this.label_Finmatning.TabIndex = 911;
            this.label_Finmatning.Text = "Finmat-ning";
            this.label_Finmatning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Verktyg
            // 
            this.label_Verktyg.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Verktyg, 4);
            this.label_Verktyg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Verktyg.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Verktyg.ForeColor = System.Drawing.Color.Black;
            this.label_Verktyg.Location = new System.Drawing.Point(243, 20);
            this.label_Verktyg.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Verktyg.Name = "label_Verktyg";
            this.label_Verktyg.Size = new System.Drawing.Size(211, 19);
            this.label_Verktyg.TabIndex = 909;
            this.label_Verktyg.Text = "Verktyg";
            this.label_Verktyg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Induktion
            // 
            this.label_Induktion.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Induktion, 2);
            this.label_Induktion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Induktion.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Induktion.ForeColor = System.Drawing.Color.Black;
            this.label_Induktion.Location = new System.Drawing.Point(137, 20);
            this.label_Induktion.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Induktion.Name = "label_Induktion";
            this.label_Induktion.Size = new System.Drawing.Size(105, 19);
            this.label_Induktion.TabIndex = 908;
            this.label_Induktion.Text = "Induktion";
            this.label_Induktion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Tryckluft
            // 
            this.label_Tryckluft.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Tryckluft, 2);
            this.label_Tryckluft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Tryckluft.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Tryckluft.ForeColor = System.Drawing.Color.Black;
            this.label_Tryckluft.Location = new System.Drawing.Point(31, 20);
            this.label_Tryckluft.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Tryckluft.Name = "label_Tryckluft";
            this.label_Tryckluft.Size = new System.Drawing.Size(105, 19);
            this.label_Tryckluft.TabIndex = 907;
            this.label_Tryckluft.Text = "Tryckluft";
            this.label_Tryckluft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Maskinparametrar
            // 
            this.label_Maskinparametrar.BackColor = System.Drawing.Color.LightGray;
            this.tlp_Main.SetColumnSpan(this.label_Maskinparametrar, 12);
            this.label_Maskinparametrar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Maskinparametrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Maskinparametrar.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label_Maskinparametrar.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_Maskinparametrar.Location = new System.Drawing.Point(0, 0);
            this.label_Maskinparametrar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Maskinparametrar.Name = "label_Maskinparametrar";
            this.label_Maskinparametrar.Size = new System.Drawing.Size(698, 19);
            this.label_Maskinparametrar.TabIndex = 906;
            this.label_Maskinparametrar.Text = "Maskinparametrar";
            this.label_Maskinparametrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Fasthållning
            // 
            this.label_Fasthållning.BackColor = System.Drawing.Color.White;
            this.label_Fasthållning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Fasthållning.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Fasthållning.ForeColor = System.Drawing.Color.Black;
            this.label_Fasthållning.Location = new System.Drawing.Point(31, 40);
            this.label_Fasthållning.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Fasthållning.Name = "label_Fasthållning";
            this.tlp_Main.SetRowSpan(this.label_Fasthållning, 3);
            this.label_Fasthållning.Size = new System.Drawing.Size(52, 60);
            this.label_Fasthållning.TabIndex = 910;
            this.label_Fasthållning.Text = "Fasthåll-ning";
            this.label_Fasthållning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_TryckluftFasthållning_Mpa
            // 
            this.label_TryckluftFasthållning_Mpa.BackColor = System.Drawing.Color.White;
            this.label_TryckluftFasthållning_Mpa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_TryckluftFasthållning_Mpa.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TryckluftFasthållning_Mpa.ForeColor = System.Drawing.Color.Black;
            this.label_TryckluftFasthållning_Mpa.Location = new System.Drawing.Point(31, 100);
            this.label_TryckluftFasthållning_Mpa.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_TryckluftFasthållning_Mpa.Name = "label_TryckluftFasthållning_Mpa";
            this.label_TryckluftFasthållning_Mpa.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_TryckluftFasthållning_Mpa.Size = new System.Drawing.Size(52, 20);
            this.label_TryckluftFasthållning_Mpa.TabIndex = 813;
            this.label_TryckluftFasthållning_Mpa.Text = "MPa";
            this.label_TryckluftFasthållning_Mpa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_TryckluftFinmatning_Mpa
            // 
            this.label_TryckluftFinmatning_Mpa.BackColor = System.Drawing.Color.White;
            this.label_TryckluftFinmatning_Mpa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_TryckluftFinmatning_Mpa.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TryckluftFinmatning_Mpa.ForeColor = System.Drawing.Color.Black;
            this.label_TryckluftFinmatning_Mpa.Location = new System.Drawing.Point(84, 100);
            this.label_TryckluftFinmatning_Mpa.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_TryckluftFinmatning_Mpa.Name = "label_TryckluftFinmatning_Mpa";
            this.label_TryckluftFinmatning_Mpa.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_TryckluftFinmatning_Mpa.Size = new System.Drawing.Size(52, 20);
            this.label_TryckluftFinmatning_Mpa.TabIndex = 814;
            this.label_TryckluftFinmatning_Mpa.Text = "MPa";
            this.label_TryckluftFinmatning_Mpa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_InduktionVärme_sec
            // 
            this.label_InduktionVärme_sec.BackColor = System.Drawing.Color.White;
            this.label_InduktionVärme_sec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_InduktionVärme_sec.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_InduktionVärme_sec.ForeColor = System.Drawing.Color.Black;
            this.label_InduktionVärme_sec.Location = new System.Drawing.Point(137, 100);
            this.label_InduktionVärme_sec.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_InduktionVärme_sec.Name = "label_InduktionVärme_sec";
            this.label_InduktionVärme_sec.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_InduktionVärme_sec.Size = new System.Drawing.Size(52, 20);
            this.label_InduktionVärme_sec.TabIndex = 815;
            this.label_InduktionVärme_sec.Text = "sec";
            this.label_InduktionVärme_sec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_InduktionKylning_sec
            // 
            this.label_InduktionKylning_sec.BackColor = System.Drawing.Color.White;
            this.label_InduktionKylning_sec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_InduktionKylning_sec.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_InduktionKylning_sec.ForeColor = System.Drawing.Color.Black;
            this.label_InduktionKylning_sec.Location = new System.Drawing.Point(190, 100);
            this.label_InduktionKylning_sec.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_InduktionKylning_sec.Name = "label_InduktionKylning_sec";
            this.label_InduktionKylning_sec.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_InduktionKylning_sec.Size = new System.Drawing.Size(52, 20);
            this.label_InduktionKylning_sec.TabIndex = 816;
            this.label_InduktionKylning_sec.Text = "sec";
            this.label_InduktionKylning_sec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_min
            // 
            this.label_min.BackColor = System.Drawing.Color.White;
            this.label_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_min.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.label_min.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_min.Location = new System.Drawing.Point(0, 120);
            this.label_min.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_min.Name = "label_min";
            this.label_min.Size = new System.Drawing.Size(30, 20);
            this.label_min.TabIndex = 819;
            this.label_min.Text = "MIN";
            this.label_min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_nom
            // 
            this.label_nom.BackColor = System.Drawing.Color.White;
            this.label_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_nom.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.label_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_nom.Location = new System.Drawing.Point(0, 141);
            this.label_nom.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_nom.Name = "label_nom";
            this.label_nom.Size = new System.Drawing.Size(30, 19);
            this.label_nom.TabIndex = 824;
            this.label_nom.Text = "NOM";
            this.label_nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelmax
            // 
            this.labelmax.BackColor = System.Drawing.Color.White;
            this.labelmax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelmax.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.labelmax.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelmax.Location = new System.Drawing.Point(0, 161);
            this.labelmax.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.labelmax.Name = "labelmax";
            this.labelmax.Size = new System.Drawing.Size(30, 19);
            this.labelmax.TabIndex = 838;
            this.labelmax.Text = "MAX";
            this.labelmax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_PTFE_ID_mm
            // 
            this.label_PTFE_ID_mm.BackColor = System.Drawing.Color.White;
            this.label_PTFE_ID_mm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PTFE_ID_mm.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PTFE_ID_mm.ForeColor = System.Drawing.Color.Black;
            this.label_PTFE_ID_mm.Location = new System.Drawing.Point(243, 100);
            this.label_PTFE_ID_mm.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_PTFE_ID_mm.Name = "label_PTFE_ID_mm";
            this.label_PTFE_ID_mm.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_PTFE_ID_mm.Size = new System.Drawing.Size(53, 20);
            this.label_PTFE_ID_mm.TabIndex = 817;
            this.label_PTFE_ID_mm.Text = "mm";
            this.label_PTFE_ID_mm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_PTFE_OD_mm
            // 
            this.label_PTFE_OD_mm.BackColor = System.Drawing.Color.White;
            this.label_PTFE_OD_mm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PTFE_OD_mm.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PTFE_OD_mm.ForeColor = System.Drawing.Color.Black;
            this.label_PTFE_OD_mm.Location = new System.Drawing.Point(296, 100);
            this.label_PTFE_OD_mm.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label_PTFE_OD_mm.Name = "label_PTFE_OD_mm";
            this.label_PTFE_OD_mm.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_PTFE_OD_mm.Size = new System.Drawing.Size(56, 20);
            this.label_PTFE_OD_mm.TabIndex = 818;
            this.label_PTFE_OD_mm.Text = "mm";
            this.label_PTFE_OD_mm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_PTFE_ID
            // 
            this.label_PTFE_ID.BackColor = System.Drawing.Color.White;
            this.label_PTFE_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PTFE_ID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PTFE_ID.ForeColor = System.Drawing.Color.Black;
            this.label_PTFE_ID.Location = new System.Drawing.Point(243, 40);
            this.label_PTFE_ID.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_PTFE_ID.Name = "label_PTFE_ID";
            this.tlp_Main.SetRowSpan(this.label_PTFE_ID, 3);
            this.label_PTFE_ID.Size = new System.Drawing.Size(53, 60);
            this.label_PTFE_ID.TabIndex = 136;
            this.label_PTFE_ID.Text = "PTFE, ID";
            this.label_PTFE_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_KragDon_max
            // 
            this.label_KragDon_max.BackColor = System.Drawing.Color.White;
            this.label_KragDon_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_KragDon_max.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_KragDon_max.ForeColor = System.Drawing.Color.Black;
            this.label_KragDon_max.Location = new System.Drawing.Point(403, 100);
            this.label_KragDon_max.Margin = new System.Windows.Forms.Padding(0);
            this.label_KragDon_max.Name = "label_KragDon_max";
            this.label_KragDon_max.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_KragDon_max.Size = new System.Drawing.Size(51, 20);
            this.label_KragDon_max.TabIndex = 812;
            this.label_KragDon_max.Text = "MAX";
            this.label_KragDon_max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_PTFE_OD
            // 
            this.label_PTFE_OD.BackColor = System.Drawing.Color.White;
            this.label_PTFE_OD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PTFE_OD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PTFE_OD.ForeColor = System.Drawing.Color.Black;
            this.label_PTFE_OD.Location = new System.Drawing.Point(296, 40);
            this.label_PTFE_OD.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label_PTFE_OD.Name = "label_PTFE_OD";
            this.tlp_Main.SetRowSpan(this.label_PTFE_OD, 3);
            this.label_PTFE_OD.Size = new System.Drawing.Size(56, 60);
            this.label_PTFE_OD.TabIndex = 137;
            this.label_PTFE_OD.Text = "PTFE, OD";
            this.label_PTFE_OD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Kragningsdon
            // 
            this.label_Kragningsdon.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Kragningsdon, 2);
            this.label_Kragningsdon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Kragningsdon.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Kragningsdon.ForeColor = System.Drawing.Color.Black;
            this.label_Kragningsdon.Location = new System.Drawing.Point(353, 40);
            this.label_Kragningsdon.Margin = new System.Windows.Forms.Padding(0);
            this.label_Kragningsdon.Name = "label_Kragningsdon";
            this.label_Kragningsdon.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_Kragningsdon.Size = new System.Drawing.Size(101, 20);
            this.label_Kragningsdon.TabIndex = 138;
            this.label_Kragningsdon.Text = "Kragningsdon";
            this.label_Kragningsdon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_KragdonOD
            // 
            this.label_KragdonOD.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_KragdonOD, 2);
            this.label_KragdonOD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_KragdonOD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_KragdonOD.ForeColor = System.Drawing.Color.Black;
            this.label_KragdonOD.Location = new System.Drawing.Point(353, 80);
            this.label_KragdonOD.Margin = new System.Windows.Forms.Padding(0);
            this.label_KragdonOD.Name = "label_KragdonOD";
            this.label_KragdonOD.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_KragdonOD.Size = new System.Drawing.Size(101, 20);
            this.label_KragdonOD.TabIndex = 810;
            this.label_KragdonOD.Text = "OD (mm)";
            this.label_KragdonOD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_KragdonNr
            // 
            this.label_KragdonNr.BackColor = System.Drawing.Color.White;
            this.label_KragdonNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_KragdonNr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_KragdonNr.ForeColor = System.Drawing.Color.Black;
            this.label_KragdonNr.Location = new System.Drawing.Point(353, 60);
            this.label_KragdonNr.Margin = new System.Windows.Forms.Padding(0);
            this.label_KragdonNr.Name = "label_KragdonNr";
            this.label_KragdonNr.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_KragdonNr.Size = new System.Drawing.Size(50, 20);
            this.label_KragdonNr.TabIndex = 139;
            this.label_KragdonNr.Text = "NR:";
            this.label_KragdonNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_KragDon_min
            // 
            this.label_KragDon_min.BackColor = System.Drawing.Color.White;
            this.label_KragDon_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_KragDon_min.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_KragDon_min.ForeColor = System.Drawing.Color.Black;
            this.label_KragDon_min.Location = new System.Drawing.Point(353, 100);
            this.label_KragDon_min.Margin = new System.Windows.Forms.Padding(0);
            this.label_KragDon_min.Name = "label_KragDon_min";
            this.label_KragDon_min.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_KragDon_min.Size = new System.Drawing.Size(50, 20);
            this.label_KragDon_min.TabIndex = 811;
            this.label_KragDon_min.Text = "MIN";
            this.label_KragDon_min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Kragningsdon_Nr
            // 
            this.Kragningsdon_Nr.BackColor = System.Drawing.Color.White;
            this.Kragningsdon_Nr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Kragningsdon_Nr.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Kragningsdon_Nr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Kragningsdon_Nr.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kragningsdon_Nr.ForeColor = System.Drawing.Color.Gray;
            this.Kragningsdon_Nr.Location = new System.Drawing.Point(403, 60);
            this.Kragningsdon_Nr.Margin = new System.Windows.Forms.Padding(0);
            this.Kragningsdon_Nr.Multiline = true;
            this.Kragningsdon_Nr.Name = "Kragningsdon_Nr";
            this.Kragningsdon_Nr.Size = new System.Drawing.Size(51, 20);
            this.Kragningsdon_Nr.TabIndex = 808;
            this.Kragningsdon_Nr.TextChanged += new System.EventHandler(this.Kragningsdon_Nr_TextChanged);
            // 
            // label_Sign
            // 
            this.label_Sign.BackColor = System.Drawing.Color.White;
            this.label_Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Sign.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Sign.ForeColor = System.Drawing.Color.Black;
            this.label_Sign.Location = new System.Drawing.Point(645, 20);
            this.label_Sign.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Sign.Name = "label_Sign";
            this.tlp_Main.SetRowSpan(this.label_Sign, 5);
            this.label_Sign.Size = new System.Drawing.Size(53, 100);
            this.label_Sign.TabIndex = 851;
            this.label_Sign.Text = "Sign";
            this.label_Sign.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label_AnstNr
            // 
            this.label_AnstNr.BackColor = System.Drawing.Color.White;
            this.label_AnstNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_AnstNr.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_AnstNr.ForeColor = System.Drawing.Color.Black;
            this.label_AnstNr.Location = new System.Drawing.Point(595, 20);
            this.label_AnstNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_AnstNr.Name = "label_AnstNr";
            this.tlp_Main.SetRowSpan(this.label_AnstNr, 5);
            this.label_AnstNr.Size = new System.Drawing.Size(49, 100);
            this.label_AnstNr.TabIndex = 850;
            this.label_AnstNr.Text = "AnstNr";
            this.label_AnstNr.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label_Datum
            // 
            this.label_Datum.BackColor = System.Drawing.Color.White;
            this.label_Datum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Datum.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Datum.ForeColor = System.Drawing.Color.Black;
            this.label_Datum.Location = new System.Drawing.Point(455, 20);
            this.label_Datum.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Datum.Name = "label_Datum";
            this.tlp_Main.SetRowSpan(this.label_Datum, 5);
            this.label_Datum.Size = new System.Drawing.Size(139, 100);
            this.label_Datum.TabIndex = 809;
            this.label_Datum.Text = "Datum";
            this.label_Datum.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgv_Processkort
            // 
            this.dgv_Processkort.AllowUserToAddRows = false;
            this.dgv_Processkort.AllowUserToDeleteRows = false;
            this.dgv_Processkort.AllowUserToResizeColumns = false;
            this.dgv_Processkort.AllowUserToResizeRows = false;
            this.dgv_Processkort.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dgv_Processkort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Processkort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Processkort.ColumnHeadersVisible = false;
            this.tlp_Main.SetColumnSpan(this.dgv_Processkort, 11);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Processkort.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Processkort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Processkort.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dgv_Processkort.Location = new System.Drawing.Point(30, 120);
            this.dgv_Processkort.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Processkort.Name = "dgv_Processkort";
            this.dgv_Processkort.ReadOnly = true;
            this.dgv_Processkort.RowHeadersVisible = false;
            this.tlp_Main.SetRowSpan(this.dgv_Processkort, 3);
            this.dgv_Processkort.RowTemplate.Height = 20;
            this.dgv_Processkort.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Processkort.Size = new System.Drawing.Size(668, 61);
            this.dgv_Processkort.TabIndex = 914;
            // 
            // Processkort_Kragning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "Processkort_Kragning";
            this.Size = new System.Drawing.Size(698, 180);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Processkort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Label label_Maskinparametrar;
        private Label label_Tryckluft;
        private Label label_Induktion;
        private Label label_Verktyg;
        private Label label_Fasthållning;
        private Label label_Finmatning;
        private Label label_Kylning;
        private Label label_Värme;
        private Label label_TryckluftFasthållning_Mpa;
        private Label label_TryckluftFinmatning_Mpa;
        private Label label_InduktionVärme_sec;
        private Label label_InduktionKylning_sec;
        private Label label_min;
        private Label label_nom;
        private Label labelmax;
        private Label label_KragDon_max;
        private Label label_KragDon_min;
        private Label label_KragdonOD;
        private Label label_KragdonNr;
        private Label label_Kragningsdon;
        private Label label_PTFE_OD;
        private Label label_PTFE_ID;
        private Label label_PTFE_ID_mm;
        private Label label_PTFE_OD_mm;
        private Label label_Sign;
        private Label label_AnstNr;
        private Label label_Datum;
        public TextBox Kragningsdon_Nr;
        public DataGridView dgv_Processkort;
    }
}
