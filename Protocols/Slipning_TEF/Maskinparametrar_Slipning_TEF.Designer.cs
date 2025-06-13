using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Slipning_TEF
{
    partial class Maskinparametrar_Slipning_TEF
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            tlp_Main = new TableLayoutPanel();
            label_Maskinparametrar = new Label();
            lbl_Transfer_Maskinparametrar = new Label();
            label_Empty_11 = new Label();
            label_Empty_1 = new Label();
            lbl_Centerhöjd = new Label();
            lbl_Arbetsblad_max = new Label();
            lbl_Bladhöjd_max = new Label();
            lbl_Arbetsblad_min = new Label();
            lbl_Bladhöjd_min = new Label();
            label_Chimshöjd = new Label();
            tb_Slipmaskin = new TextBox();
            lbl_Chimshöjd_nom = new Label();
            label_Empty_3 = new Label();
            lbl_Arbetsblad_nom = new Label();
            lbl_Bladhöjd_nom = new Label();
            lbl_Helix_Vinkel_nom = new Label();
            lbl_Matarhjul_Vinkel_nom = new Label();
            lbl_Matarhjul_Hastighet_nom = new Label();
            label_Empty_2 = new Label();
            label_MAX = new Label();
            label_NOM = new Label();
            label_MIN = new Label();
            label_Empty_9 = new Label();
            dgv_MaskinParametrar = new DataGridView();
            label_Bladhöjd_enhet = new Label();
            label_Helix_Vikel_enhet = new Label();
            label_Matarhjul_Vinkel_enhet = new Label();
            label_Matarhjul_Hastighet_enhet = new Label();
            label_Chimshöjd_enhet = new Label();
            label_Empty_8 = new Label();
            label_Värmebackar = new Label();
            label_Nr = new Label();
            label_Arbetsblad = new Label();
            label_Bladhöjd = new Label();
            label_Helix_Vinkel = new Label();
            label_Matarhjul_Vinkel = new Label();
            label_MatarHjul_Hastighet = new Label();
            label_Slipmaskin = new Label();
            label_Empty_7 = new Label();
            label_Centerhöjd_enhet = new Label();
            label_Empty_12 = new Label();
            label_Empty_10 = new Label();
            lbl_Matarhjul_Vinkel_min = new Label();
            label_Empty_14 = new Label();
            label_Empty_15 = new Label();
            lbl_Matarhjul_Vinkel_max = new Label();
            label_Maskinparametrar_Datum = new Label();
            label_Maskinparametrar_Tid = new Label();
            label_Maskinparametrar_AnstNr = new Label();
            label_Maskinparametrar_Sign = new Label();
            label3 = new Label();
            tb_MatarhjulHastighet = new TextBox();
            tb_MatarhjulVinkel = new TextBox();
            tb_HelixVinkel = new TextBox();
            tb_Bladhöjd = new TextBox();
            tb_Arbetsblad = new TextBox();
            tb_Nr = new TextBox();
            tb_Chimshöjd = new TextBox();
            label4 = new Label();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_MatarhjulVinkel = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Bladhöjd = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Arbetsblad = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
            tlp_Main.SuspendLayout();
            ((ISupportInitialize)dgv_MaskinParametrar).BeginInit();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.FromArgb(45, 45, 45);
            tlp_Main.ColumnCount = 14;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 43F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 76F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 66F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 68F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 93F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 47F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlp_Main.Controls.Add(label_Maskinparametrar, 0, 0);
            tlp_Main.Controls.Add(lbl_Transfer_Maskinparametrar, 0, 8);
            tlp_Main.Controls.Add(label_Empty_11, 2, 7);
            tlp_Main.Controls.Add(label_Empty_1, 0, 1);
            tlp_Main.Controls.Add(lbl_Centerhöjd, 9, 6);
            tlp_Main.Controls.Add(lbl_Arbetsblad_max, 6, 7);
            tlp_Main.Controls.Add(lbl_Bladhöjd_max, 5, 7);
            tlp_Main.Controls.Add(lbl_Arbetsblad_min, 6, 5);
            tlp_Main.Controls.Add(lbl_Bladhöjd_min, 5, 5);
            tlp_Main.Controls.Add(label_Chimshöjd, 8, 1);
            tlp_Main.Controls.Add(tb_Slipmaskin, 1, 8);
            tlp_Main.Controls.Add(lbl_Chimshöjd_nom, 8, 6);
            tlp_Main.Controls.Add(label_Empty_3, 7, 5);
            tlp_Main.Controls.Add(lbl_Arbetsblad_nom, 6, 6);
            tlp_Main.Controls.Add(lbl_Bladhöjd_nom, 5, 6);
            tlp_Main.Controls.Add(lbl_Helix_Vinkel_nom, 4, 6);
            tlp_Main.Controls.Add(lbl_Matarhjul_Vinkel_nom, 3, 6);
            tlp_Main.Controls.Add(lbl_Matarhjul_Hastighet_nom, 2, 6);
            tlp_Main.Controls.Add(label_Empty_2, 1, 5);
            tlp_Main.Controls.Add(label_MAX, 0, 7);
            tlp_Main.Controls.Add(label_NOM, 0, 6);
            tlp_Main.Controls.Add(label_MIN, 0, 5);
            tlp_Main.Controls.Add(label_Empty_9, 6, 4);
            tlp_Main.Controls.Add(dgv_MaskinParametrar, 1, 9);
            tlp_Main.Controls.Add(label_Bladhöjd_enhet, 5, 4);
            tlp_Main.Controls.Add(label_Helix_Vikel_enhet, 4, 4);
            tlp_Main.Controls.Add(label_Matarhjul_Vinkel_enhet, 3, 4);
            tlp_Main.Controls.Add(label_Matarhjul_Hastighet_enhet, 2, 4);
            tlp_Main.Controls.Add(label_Chimshöjd_enhet, 8, 4);
            tlp_Main.Controls.Add(label_Empty_8, 7, 4);
            tlp_Main.Controls.Add(label_Värmebackar, 9, 1);
            tlp_Main.Controls.Add(label_Nr, 7, 1);
            tlp_Main.Controls.Add(label_Arbetsblad, 6, 1);
            tlp_Main.Controls.Add(label_Bladhöjd, 5, 1);
            tlp_Main.Controls.Add(label_Helix_Vinkel, 4, 1);
            tlp_Main.Controls.Add(label_Matarhjul_Vinkel, 3, 1);
            tlp_Main.Controls.Add(label_MatarHjul_Hastighet, 2, 1);
            tlp_Main.Controls.Add(label_Slipmaskin, 1, 1);
            tlp_Main.Controls.Add(label_Empty_7, 7, 7);
            tlp_Main.Controls.Add(label_Centerhöjd_enhet, 9, 4);
            tlp_Main.Controls.Add(label_Empty_12, 7, 6);
            tlp_Main.Controls.Add(label_Empty_10, 2, 5);
            tlp_Main.Controls.Add(lbl_Matarhjul_Vinkel_min, 3, 5);
            tlp_Main.Controls.Add(label_Empty_14, 4, 5);
            tlp_Main.Controls.Add(label_Empty_15, 4, 7);
            tlp_Main.Controls.Add(lbl_Matarhjul_Vinkel_max, 3, 7);
            tlp_Main.Controls.Add(label_Maskinparametrar_Datum, 10, 1);
            tlp_Main.Controls.Add(label_Maskinparametrar_Tid, 11, 1);
            tlp_Main.Controls.Add(label_Maskinparametrar_AnstNr, 12, 1);
            tlp_Main.Controls.Add(label_Maskinparametrar_Sign, 13, 1);
            tlp_Main.Controls.Add(label3, 10, 5);
            tlp_Main.Controls.Add(tb_MatarhjulHastighet, 2, 8);
            tlp_Main.Controls.Add(tb_MatarhjulVinkel, 3, 8);
            tlp_Main.Controls.Add(tb_HelixVinkel, 4, 8);
            tlp_Main.Controls.Add(tb_Bladhöjd, 5, 8);
            tlp_Main.Controls.Add(tb_Arbetsblad, 6, 8);
            tlp_Main.Controls.Add(tb_Nr, 7, 8);
            tlp_Main.Controls.Add(tb_Chimshöjd, 8, 8);
            tlp_Main.Controls.Add(label4, 9, 8);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 11;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 9F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Main.Size = new Size(1042, 380);
            tlp_Main.TabIndex = 1;
            // 
            // label_Maskinparametrar
            // 
            label_Maskinparametrar.BackColor = Color.LightGray;
            tlp_Main.SetColumnSpan(label_Maskinparametrar, 14);
            label_Maskinparametrar.Dock = DockStyle.Fill;
            label_Maskinparametrar.Font = new Font("Palatino Linotype", 10.25F);
            label_Maskinparametrar.ForeColor = Color.SaddleBrown;
            label_Maskinparametrar.Location = new Point(0, 0);
            label_Maskinparametrar.Margin = new Padding(0, 0, 0, 1);
            label_Maskinparametrar.Name = "label_Maskinparametrar";
            label_Maskinparametrar.Size = new Size(1043, 27);
            label_Maskinparametrar.TabIndex = 1010;
            label_Maskinparametrar.Text = "Maskinparametrar";
            label_Maskinparametrar.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Transfer_Maskinparametrar
            // 
            lbl_Transfer_Maskinparametrar.BackColor = Color.FromArgb(198, 239, 206);
            lbl_Transfer_Maskinparametrar.Cursor = Cursors.Hand;
            lbl_Transfer_Maskinparametrar.Dock = DockStyle.Fill;
            lbl_Transfer_Maskinparametrar.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Transfer_Maskinparametrar.ForeColor = Color.FromArgb(0, 97, 0);
            lbl_Transfer_Maskinparametrar.Location = new Point(0, 175);
            lbl_Transfer_Maskinparametrar.Margin = new Padding(0, 1, 0, 0);
            lbl_Transfer_Maskinparametrar.Name = "lbl_Transfer_Maskinparametrar";
            lbl_Transfer_Maskinparametrar.Size = new Size(43, 24);
            lbl_Transfer_Maskinparametrar.TabIndex = 1009;
            lbl_Transfer_Maskinparametrar.Text = "→";
            lbl_Transfer_Maskinparametrar.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Transfer_Maskinparametrar.Click += Save_Click;
            // 
            // label_Empty_11
            // 
            label_Empty_11.BackColor = Color.DarkGray;
            label_Empty_11.Cursor = Cursors.SizeAll;
            label_Empty_11.Dock = DockStyle.Fill;
            label_Empty_11.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_11.ForeColor = Color.ForestGreen;
            label_Empty_11.Location = new Point(128, 151);
            label_Empty_11.Margin = new Padding(0, 0, 0, 1);
            label_Empty_11.Name = "label_Empty_11";
            label_Empty_11.Size = new Size(76, 22);
            label_Empty_11.TabIndex = 1008;
            label_Empty_11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_1
            // 
            label_Empty_1.BackColor = Color.DarkGray;
            label_Empty_1.Cursor = Cursors.SizeAll;
            label_Empty_1.Dock = DockStyle.Fill;
            label_Empty_1.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_1.ForeColor = Color.ForestGreen;
            label_Empty_1.Location = new Point(0, 28);
            label_Empty_1.Margin = new Padding(0, 0, 0, 1);
            label_Empty_1.Name = "label_Empty_1";
            tlp_Main.SetRowSpan(label_Empty_1, 4);
            label_Empty_1.Size = new Size(43, 76);
            label_Empty_1.TabIndex = 1007;
            label_Empty_1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Centerhöjd
            // 
            lbl_Centerhöjd.AutoSize = true;
            lbl_Centerhöjd.BackColor = Color.LightGray;
            lbl_Centerhöjd.Dock = DockStyle.Fill;
            lbl_Centerhöjd.Font = new Font("Consolas", 8.75F);
            lbl_Centerhöjd.ForeColor = Color.ForestGreen;
            lbl_Centerhöjd.Location = new Point(650, 129);
            lbl_Centerhöjd.Margin = new Padding(1);
            lbl_Centerhöjd.Name = "lbl_Centerhöjd";
            lbl_Centerhöjd.Size = new Size(86, 21);
            lbl_Centerhöjd.TabIndex = 1005;
            lbl_Centerhöjd.Text = "63,7";
            lbl_Centerhöjd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Arbetsblad_max
            // 
            lbl_Arbetsblad_max.AutoSize = true;
            lbl_Arbetsblad_max.BackColor = Color.FromArgb(230, 230, 230);
            lbl_Arbetsblad_max.Dock = DockStyle.Fill;
            lbl_Arbetsblad_max.Font = new Font("Consolas", 8.75F);
            lbl_Arbetsblad_max.ForeColor = Color.DodgerBlue;
            lbl_Arbetsblad_max.Location = new Point(414, 151);
            lbl_Arbetsblad_max.Margin = new Padding(1, 0, 0, 1);
            lbl_Arbetsblad_max.Name = "lbl_Arbetsblad_max";
            lbl_Arbetsblad_max.Size = new Size(81, 22);
            lbl_Arbetsblad_max.TabIndex = 1004;
            lbl_Arbetsblad_max.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Bladhöjd_max
            // 
            lbl_Bladhöjd_max.AutoSize = true;
            lbl_Bladhöjd_max.BackColor = Color.FromArgb(230, 230, 230);
            lbl_Bladhöjd_max.Dock = DockStyle.Fill;
            lbl_Bladhöjd_max.Font = new Font("Consolas", 8.75F);
            lbl_Bladhöjd_max.ForeColor = Color.DodgerBlue;
            lbl_Bladhöjd_max.Location = new Point(339, 151);
            lbl_Bladhöjd_max.Margin = new Padding(1, 0, 0, 1);
            lbl_Bladhöjd_max.Name = "lbl_Bladhöjd_max";
            lbl_Bladhöjd_max.Size = new Size(74, 22);
            lbl_Bladhöjd_max.TabIndex = 1003;
            lbl_Bladhöjd_max.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Arbetsblad_min
            // 
            lbl_Arbetsblad_min.AutoSize = true;
            lbl_Arbetsblad_min.BackColor = Color.FromArgb(230, 230, 230);
            lbl_Arbetsblad_min.Dock = DockStyle.Fill;
            lbl_Arbetsblad_min.Font = new Font("Consolas", 8.75F);
            lbl_Arbetsblad_min.ForeColor = Color.DodgerBlue;
            lbl_Arbetsblad_min.Location = new Point(414, 105);
            lbl_Arbetsblad_min.Margin = new Padding(1, 0, 0, 1);
            lbl_Arbetsblad_min.Name = "lbl_Arbetsblad_min";
            lbl_Arbetsblad_min.Size = new Size(81, 22);
            lbl_Arbetsblad_min.TabIndex = 1002;
            lbl_Arbetsblad_min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Bladhöjd_min
            // 
            lbl_Bladhöjd_min.AutoSize = true;
            lbl_Bladhöjd_min.BackColor = Color.FromArgb(230, 230, 230);
            lbl_Bladhöjd_min.Dock = DockStyle.Fill;
            lbl_Bladhöjd_min.Font = new Font("Consolas", 8.75F);
            lbl_Bladhöjd_min.ForeColor = Color.DodgerBlue;
            lbl_Bladhöjd_min.Location = new Point(339, 105);
            lbl_Bladhöjd_min.Margin = new Padding(1, 0, 0, 1);
            lbl_Bladhöjd_min.Name = "lbl_Bladhöjd_min";
            lbl_Bladhöjd_min.Size = new Size(74, 22);
            lbl_Bladhöjd_min.TabIndex = 1001;
            lbl_Bladhöjd_min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Chimshöjd
            // 
            label_Chimshöjd.BackColor = Color.White;
            label_Chimshöjd.Dock = DockStyle.Fill;
            label_Chimshöjd.Font = new Font("Arial", 8.55F);
            label_Chimshöjd.ForeColor = Color.Black;
            label_Chimshöjd.Location = new Point(566, 28);
            label_Chimshöjd.Margin = new Padding(1, 0, 0, 0);
            label_Chimshöjd.Name = "label_Chimshöjd";
            tlp_Main.SetRowSpan(label_Chimshöjd, 3);
            label_Chimshöjd.Size = new Size(83, 61);
            label_Chimshöjd.TabIndex = 996;
            label_Chimshöjd.Text = "Chimshöjd";
            label_Chimshöjd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_Slipmaskin
            // 
            tb_Slipmaskin.BackColor = Color.White;
            tb_Slipmaskin.BorderStyle = BorderStyle.None;
            tb_Slipmaskin.Cursor = Cursors.IBeam;
            tb_Slipmaskin.Dock = DockStyle.Fill;
            tb_Slipmaskin.Font = new Font("Courier New", 8.5F);
            tb_Slipmaskin.ForeColor = Color.DarkSlateGray;
            tb_Slipmaskin.Location = new Point(44, 175);
            tb_Slipmaskin.Margin = new Padding(1, 1, 0, 0);
            tb_Slipmaskin.MaxLength = 10;
            tb_Slipmaskin.Multiline = true;
            tb_Slipmaskin.Name = "tb_Slipmaskin";
            tb_Slipmaskin.Size = new Size(84, 24);
            tb_Slipmaskin.TabIndex = 11;
            tb_Slipmaskin.TextAlign = HorizontalAlignment.Center;
            tb_Slipmaskin.WordWrap = false;
            tb_Slipmaskin.KeyDown += EnterToTab_KeyDown;
            // 
            // lbl_Chimshöjd_nom
            // 
            lbl_Chimshöjd_nom.AutoSize = true;
            lbl_Chimshöjd_nom.BackColor = Color.LightGray;
            lbl_Chimshöjd_nom.Dock = DockStyle.Fill;
            lbl_Chimshöjd_nom.Font = new Font("Consolas", 8.75F);
            lbl_Chimshöjd_nom.ForeColor = Color.ForestGreen;
            lbl_Chimshöjd_nom.Location = new Point(566, 129);
            lbl_Chimshöjd_nom.Margin = new Padding(1, 1, 0, 1);
            lbl_Chimshöjd_nom.Name = "lbl_Chimshöjd_nom";
            lbl_Chimshöjd_nom.Size = new Size(83, 21);
            lbl_Chimshöjd_nom.TabIndex = 990;
            lbl_Chimshöjd_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_3
            // 
            label_Empty_3.BackColor = Color.DarkGray;
            tlp_Main.SetColumnSpan(label_Empty_3, 3);
            label_Empty_3.Cursor = Cursors.SizeAll;
            label_Empty_3.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_3.ForeColor = Color.ForestGreen;
            label_Empty_3.Location = new Point(496, 105);
            label_Empty_3.Margin = new Padding(1, 0, 0, 0);
            label_Empty_3.Name = "label_Empty_3";
            label_Empty_3.Size = new Size(240, 23);
            label_Empty_3.TabIndex = 1007;
            label_Empty_3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Arbetsblad_nom
            // 
            lbl_Arbetsblad_nom.AutoSize = true;
            lbl_Arbetsblad_nom.BackColor = Color.LightGray;
            lbl_Arbetsblad_nom.Dock = DockStyle.Fill;
            lbl_Arbetsblad_nom.Font = new Font("Consolas", 8.75F);
            lbl_Arbetsblad_nom.ForeColor = Color.ForestGreen;
            lbl_Arbetsblad_nom.Location = new Point(414, 128);
            lbl_Arbetsblad_nom.Margin = new Padding(1, 0, 0, 1);
            lbl_Arbetsblad_nom.Name = "lbl_Arbetsblad_nom";
            lbl_Arbetsblad_nom.Size = new Size(81, 22);
            lbl_Arbetsblad_nom.TabIndex = 988;
            lbl_Arbetsblad_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Bladhöjd_nom
            // 
            lbl_Bladhöjd_nom.AutoSize = true;
            lbl_Bladhöjd_nom.BackColor = Color.LightGray;
            lbl_Bladhöjd_nom.Dock = DockStyle.Fill;
            lbl_Bladhöjd_nom.Font = new Font("Consolas", 8.75F);
            lbl_Bladhöjd_nom.ForeColor = Color.ForestGreen;
            lbl_Bladhöjd_nom.Location = new Point(339, 128);
            lbl_Bladhöjd_nom.Margin = new Padding(1, 0, 0, 1);
            lbl_Bladhöjd_nom.Name = "lbl_Bladhöjd_nom";
            lbl_Bladhöjd_nom.Size = new Size(74, 22);
            lbl_Bladhöjd_nom.TabIndex = 987;
            lbl_Bladhöjd_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Helix_Vinkel_nom
            // 
            lbl_Helix_Vinkel_nom.AutoSize = true;
            lbl_Helix_Vinkel_nom.BackColor = Color.LightGray;
            lbl_Helix_Vinkel_nom.Dock = DockStyle.Fill;
            lbl_Helix_Vinkel_nom.Font = new Font("Consolas", 8.75F);
            lbl_Helix_Vinkel_nom.ForeColor = Color.ForestGreen;
            lbl_Helix_Vinkel_nom.Location = new Point(271, 128);
            lbl_Helix_Vinkel_nom.Margin = new Padding(1, 0, 0, 1);
            lbl_Helix_Vinkel_nom.Name = "lbl_Helix_Vinkel_nom";
            lbl_Helix_Vinkel_nom.Size = new Size(67, 22);
            lbl_Helix_Vinkel_nom.TabIndex = 986;
            lbl_Helix_Vinkel_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Matarhjul_Vinkel_nom
            // 
            lbl_Matarhjul_Vinkel_nom.AutoSize = true;
            lbl_Matarhjul_Vinkel_nom.BackColor = Color.LightGray;
            lbl_Matarhjul_Vinkel_nom.Dock = DockStyle.Fill;
            lbl_Matarhjul_Vinkel_nom.Font = new Font("Consolas", 8.75F);
            lbl_Matarhjul_Vinkel_nom.ForeColor = Color.ForestGreen;
            lbl_Matarhjul_Vinkel_nom.Location = new Point(205, 128);
            lbl_Matarhjul_Vinkel_nom.Margin = new Padding(1, 0, 0, 1);
            lbl_Matarhjul_Vinkel_nom.Name = "lbl_Matarhjul_Vinkel_nom";
            lbl_Matarhjul_Vinkel_nom.Size = new Size(65, 22);
            lbl_Matarhjul_Vinkel_nom.TabIndex = 985;
            lbl_Matarhjul_Vinkel_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Matarhjul_Hastighet_nom
            // 
            lbl_Matarhjul_Hastighet_nom.AutoSize = true;
            lbl_Matarhjul_Hastighet_nom.BackColor = Color.LightGray;
            lbl_Matarhjul_Hastighet_nom.Dock = DockStyle.Fill;
            lbl_Matarhjul_Hastighet_nom.Font = new Font("Consolas", 8.75F);
            lbl_Matarhjul_Hastighet_nom.ForeColor = Color.ForestGreen;
            lbl_Matarhjul_Hastighet_nom.Location = new Point(129, 128);
            lbl_Matarhjul_Hastighet_nom.Margin = new Padding(1, 0, 0, 1);
            lbl_Matarhjul_Hastighet_nom.Name = "lbl_Matarhjul_Hastighet_nom";
            lbl_Matarhjul_Hastighet_nom.Size = new Size(75, 22);
            lbl_Matarhjul_Hastighet_nom.TabIndex = 984;
            lbl_Matarhjul_Hastighet_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_2
            // 
            label_Empty_2.AutoSize = true;
            label_Empty_2.BackColor = Color.DarkGray;
            label_Empty_2.Cursor = Cursors.SizeAll;
            label_Empty_2.Dock = DockStyle.Fill;
            label_Empty_2.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_2.ForeColor = Color.ForestGreen;
            label_Empty_2.Location = new Point(44, 105);
            label_Empty_2.Margin = new Padding(1, 0, 0, 1);
            label_Empty_2.Name = "label_Empty_2";
            tlp_Main.SetRowSpan(label_Empty_2, 3);
            label_Empty_2.Size = new Size(84, 68);
            label_Empty_2.TabIndex = 983;
            label_Empty_2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_MAX
            // 
            label_MAX.BackColor = Color.Silver;
            label_MAX.Dock = DockStyle.Fill;
            label_MAX.Font = new Font("Palatino Linotype", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MAX.ForeColor = Color.DodgerBlue;
            label_MAX.Location = new Point(0, 151);
            label_MAX.Margin = new Padding(0, 0, 0, 1);
            label_MAX.Name = "label_MAX";
            label_MAX.Size = new Size(43, 22);
            label_MAX.TabIndex = 838;
            label_MAX.Text = "MAX";
            label_MAX.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_NOM
            // 
            label_NOM.BackColor = Color.Silver;
            label_NOM.Dock = DockStyle.Fill;
            label_NOM.Font = new Font("Palatino Linotype", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_NOM.ForeColor = Color.ForestGreen;
            label_NOM.Location = new Point(0, 128);
            label_NOM.Margin = new Padding(0, 0, 0, 1);
            label_NOM.Name = "label_NOM";
            label_NOM.Size = new Size(43, 22);
            label_NOM.TabIndex = 824;
            label_NOM.Text = "NOM";
            label_NOM.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_MIN
            // 
            label_MIN.BackColor = Color.Silver;
            label_MIN.Dock = DockStyle.Fill;
            label_MIN.Font = new Font("Palatino Linotype", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MIN.ForeColor = Color.DodgerBlue;
            label_MIN.Location = new Point(0, 105);
            label_MIN.Margin = new Padding(0, 0, 0, 1);
            label_MIN.Name = "label_MIN";
            label_MIN.Size = new Size(43, 22);
            label_MIN.TabIndex = 819;
            label_MIN.Text = "MIN";
            label_MIN.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_9
            // 
            label_Empty_9.BackColor = Color.White;
            label_Empty_9.Dock = DockStyle.Fill;
            label_Empty_9.Font = new Font("Arial", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label_Empty_9.ForeColor = Color.Black;
            label_Empty_9.Location = new Point(414, 89);
            label_Empty_9.Margin = new Padding(1, 0, 0, 1);
            label_Empty_9.Name = "label_Empty_9";
            label_Empty_9.Size = new Size(81, 15);
            label_Empty_9.TabIndex = 818;
            label_Empty_9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgv_MaskinParametrar
            // 
            dgv_MaskinParametrar.AllowUserToAddRows = false;
            dgv_MaskinParametrar.AllowUserToDeleteRows = false;
            dgv_MaskinParametrar.AllowUserToResizeColumns = false;
            dgv_MaskinParametrar.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgv_MaskinParametrar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_MaskinParametrar.BackgroundColor = Color.White;
            dgv_MaskinParametrar.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_MaskinParametrar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_MaskinParametrar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_MaskinParametrar.ColumnHeadersVisible = false;
            dgv_MaskinParametrar.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dgv_Maskinparametrar_MatarhjulVinkel, dataGridViewTextBoxColumn4, dgv_Maskinparametrar_Bladhöjd, dgv_Maskinparametrar_Arbetsblad, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn14, dataGridViewTextBoxColumn15, dataGridViewTextBoxColumn16, dataGridViewTextBoxColumn17 });
            tlp_Main.SetColumnSpan(dgv_MaskinParametrar, 13);
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = SystemColors.Window;
            dataGridViewCellStyle16.Font = new Font("Consolas", 7.5F);
            dataGridViewCellStyle16.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle16.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle16.SelectionForeColor = Color.White;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.False;
            dgv_MaskinParametrar.DefaultCellStyle = dataGridViewCellStyle16;
            dgv_MaskinParametrar.Dock = DockStyle.Fill;
            dgv_MaskinParametrar.Location = new Point(44, 200);
            dgv_MaskinParametrar.Margin = new Padding(1, 1, 0, 0);
            dgv_MaskinParametrar.MultiSelect = false;
            dgv_MaskinParametrar.Name = "dgv_MaskinParametrar";
            dgv_MaskinParametrar.ReadOnly = true;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = SystemColors.Control;
            dataGridViewCellStyle17.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle17.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dgv_MaskinParametrar.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dgv_MaskinParametrar.RowHeadersVisible = false;
            tlp_Main.SetRowSpan(dgv_MaskinParametrar, 2);
            dgv_MaskinParametrar.RowTemplate.Height = 18;
            dgv_MaskinParametrar.ScrollBars = ScrollBars.None;
            dgv_MaskinParametrar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_MaskinParametrar.Size = new Size(999, 180);
            dgv_MaskinParametrar.TabIndex = 845;
            // 
            // label_Bladhöjd_enhet
            // 
            label_Bladhöjd_enhet.BackColor = Color.White;
            label_Bladhöjd_enhet.Dock = DockStyle.Fill;
            label_Bladhöjd_enhet.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Bladhöjd_enhet.ForeColor = Color.Black;
            label_Bladhöjd_enhet.Location = new Point(339, 89);
            label_Bladhöjd_enhet.Margin = new Padding(1, 0, 0, 1);
            label_Bladhöjd_enhet.Name = "label_Bladhöjd_enhet";
            label_Bladhöjd_enhet.Padding = new Padding(9, 0, 9, 0);
            label_Bladhöjd_enhet.Size = new Size(74, 15);
            label_Bladhöjd_enhet.TabIndex = 817;
            label_Bladhöjd_enhet.Text = "mm";
            label_Bladhöjd_enhet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Helix_Vikel_enhet
            // 
            label_Helix_Vikel_enhet.BackColor = Color.White;
            label_Helix_Vikel_enhet.Dock = DockStyle.Fill;
            label_Helix_Vikel_enhet.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Helix_Vikel_enhet.ForeColor = Color.Black;
            label_Helix_Vikel_enhet.Location = new Point(271, 89);
            label_Helix_Vikel_enhet.Margin = new Padding(1, 0, 0, 1);
            label_Helix_Vikel_enhet.Name = "label_Helix_Vikel_enhet";
            label_Helix_Vikel_enhet.Padding = new Padding(9, 0, 9, 0);
            label_Helix_Vikel_enhet.Size = new Size(67, 15);
            label_Helix_Vikel_enhet.TabIndex = 816;
            label_Helix_Vikel_enhet.Text = "º";
            label_Helix_Vikel_enhet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Matarhjul_Vinkel_enhet
            // 
            label_Matarhjul_Vinkel_enhet.BackColor = Color.White;
            label_Matarhjul_Vinkel_enhet.Dock = DockStyle.Fill;
            label_Matarhjul_Vinkel_enhet.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Matarhjul_Vinkel_enhet.ForeColor = Color.Black;
            label_Matarhjul_Vinkel_enhet.Location = new Point(205, 89);
            label_Matarhjul_Vinkel_enhet.Margin = new Padding(1, 0, 0, 1);
            label_Matarhjul_Vinkel_enhet.Name = "label_Matarhjul_Vinkel_enhet";
            label_Matarhjul_Vinkel_enhet.Padding = new Padding(9, 0, 9, 0);
            label_Matarhjul_Vinkel_enhet.Size = new Size(65, 15);
            label_Matarhjul_Vinkel_enhet.TabIndex = 815;
            label_Matarhjul_Vinkel_enhet.Text = "º";
            label_Matarhjul_Vinkel_enhet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Matarhjul_Hastighet_enhet
            // 
            label_Matarhjul_Hastighet_enhet.BackColor = Color.White;
            label_Matarhjul_Hastighet_enhet.Dock = DockStyle.Fill;
            label_Matarhjul_Hastighet_enhet.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Matarhjul_Hastighet_enhet.ForeColor = Color.Black;
            label_Matarhjul_Hastighet_enhet.Location = new Point(129, 89);
            label_Matarhjul_Hastighet_enhet.Margin = new Padding(1, 0, 0, 1);
            label_Matarhjul_Hastighet_enhet.Name = "label_Matarhjul_Hastighet_enhet";
            label_Matarhjul_Hastighet_enhet.Padding = new Padding(9, 0, 9, 0);
            label_Matarhjul_Hastighet_enhet.Size = new Size(75, 15);
            label_Matarhjul_Hastighet_enhet.TabIndex = 814;
            label_Matarhjul_Hastighet_enhet.Text = "rpm";
            label_Matarhjul_Hastighet_enhet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Chimshöjd_enhet
            // 
            label_Chimshöjd_enhet.BackColor = Color.White;
            label_Chimshöjd_enhet.Dock = DockStyle.Fill;
            label_Chimshöjd_enhet.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Chimshöjd_enhet.ForeColor = Color.Black;
            label_Chimshöjd_enhet.Location = new Point(566, 89);
            label_Chimshöjd_enhet.Margin = new Padding(1, 0, 0, 1);
            label_Chimshöjd_enhet.Name = "label_Chimshöjd_enhet";
            label_Chimshöjd_enhet.Size = new Size(83, 15);
            label_Chimshöjd_enhet.TabIndex = 812;
            label_Chimshöjd_enhet.Text = "mm";
            label_Chimshöjd_enhet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_8
            // 
            label_Empty_8.BackColor = Color.White;
            label_Empty_8.Dock = DockStyle.Fill;
            label_Empty_8.Font = new Font("Arial", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label_Empty_8.ForeColor = Color.Black;
            label_Empty_8.Location = new Point(496, 89);
            label_Empty_8.Margin = new Padding(1, 0, 0, 1);
            label_Empty_8.Name = "label_Empty_8";
            label_Empty_8.Size = new Size(69, 15);
            label_Empty_8.TabIndex = 811;
            label_Empty_8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Värmebackar
            // 
            label_Värmebackar.BackColor = Color.White;
            label_Värmebackar.Dock = DockStyle.Fill;
            label_Värmebackar.Font = new Font("Arial", 8.55F);
            label_Värmebackar.ForeColor = Color.Black;
            label_Värmebackar.Location = new Point(650, 28);
            label_Värmebackar.Margin = new Padding(1, 0, 1, 0);
            label_Värmebackar.Name = "label_Värmebackar";
            tlp_Main.SetRowSpan(label_Värmebackar, 3);
            label_Värmebackar.Size = new Size(86, 61);
            label_Värmebackar.TabIndex = 809;
            label_Värmebackar.Text = "Centerhöjd";
            label_Värmebackar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Nr
            // 
            label_Nr.BackColor = Color.White;
            label_Nr.Dock = DockStyle.Fill;
            label_Nr.Font = new Font("Arial", 8.55F);
            label_Nr.ForeColor = Color.Black;
            label_Nr.Location = new Point(496, 28);
            label_Nr.Margin = new Padding(1, 0, 0, 0);
            label_Nr.Name = "label_Nr";
            tlp_Main.SetRowSpan(label_Nr, 3);
            label_Nr.Size = new Size(69, 61);
            label_Nr.TabIndex = 138;
            label_Nr.Text = "Nr";
            label_Nr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Arbetsblad
            // 
            label_Arbetsblad.BackColor = Color.White;
            label_Arbetsblad.Dock = DockStyle.Fill;
            label_Arbetsblad.Font = new Font("Arial", 8.55F);
            label_Arbetsblad.ForeColor = Color.Black;
            label_Arbetsblad.Location = new Point(414, 28);
            label_Arbetsblad.Margin = new Padding(1, 0, 0, 0);
            label_Arbetsblad.Name = "label_Arbetsblad";
            tlp_Main.SetRowSpan(label_Arbetsblad, 3);
            label_Arbetsblad.Size = new Size(81, 61);
            label_Arbetsblad.TabIndex = 137;
            label_Arbetsblad.Text = "Arbetsblad";
            label_Arbetsblad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Bladhöjd
            // 
            label_Bladhöjd.BackColor = Color.White;
            label_Bladhöjd.Dock = DockStyle.Fill;
            label_Bladhöjd.Font = new Font("Arial", 8.55F);
            label_Bladhöjd.ForeColor = Color.Black;
            label_Bladhöjd.Location = new Point(339, 28);
            label_Bladhöjd.Margin = new Padding(1, 0, 0, 0);
            label_Bladhöjd.Name = "label_Bladhöjd";
            tlp_Main.SetRowSpan(label_Bladhöjd, 3);
            label_Bladhöjd.Size = new Size(74, 61);
            label_Bladhöjd.TabIndex = 136;
            label_Bladhöjd.Text = "Bladhöjd";
            label_Bladhöjd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Helix_Vinkel
            // 
            label_Helix_Vinkel.BackColor = Color.White;
            label_Helix_Vinkel.Dock = DockStyle.Fill;
            label_Helix_Vinkel.Font = new Font("Arial", 8.55F);
            label_Helix_Vinkel.ForeColor = Color.Black;
            label_Helix_Vinkel.Location = new Point(271, 28);
            label_Helix_Vinkel.Margin = new Padding(1, 0, 0, 0);
            label_Helix_Vinkel.Name = "label_Helix_Vinkel";
            tlp_Main.SetRowSpan(label_Helix_Vinkel, 3);
            label_Helix_Vinkel.Size = new Size(67, 61);
            label_Helix_Vinkel.TabIndex = 134;
            label_Helix_Vinkel.Text = "Helix vinkel";
            label_Helix_Vinkel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Matarhjul_Vinkel
            // 
            label_Matarhjul_Vinkel.BackColor = Color.White;
            label_Matarhjul_Vinkel.Dock = DockStyle.Fill;
            label_Matarhjul_Vinkel.Font = new Font("Arial", 8.55F);
            label_Matarhjul_Vinkel.ForeColor = Color.Black;
            label_Matarhjul_Vinkel.Location = new Point(205, 28);
            label_Matarhjul_Vinkel.Margin = new Padding(1, 0, 0, 0);
            label_Matarhjul_Vinkel.Name = "label_Matarhjul_Vinkel";
            tlp_Main.SetRowSpan(label_Matarhjul_Vinkel, 3);
            label_Matarhjul_Vinkel.Size = new Size(65, 61);
            label_Matarhjul_Vinkel.TabIndex = 133;
            label_Matarhjul_Vinkel.Text = "Matar hjul vinkel";
            label_Matarhjul_Vinkel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_MatarHjul_Hastighet
            // 
            label_MatarHjul_Hastighet.BackColor = Color.White;
            label_MatarHjul_Hastighet.Dock = DockStyle.Fill;
            label_MatarHjul_Hastighet.Font = new Font("Arial", 8.55F);
            label_MatarHjul_Hastighet.ForeColor = Color.Black;
            label_MatarHjul_Hastighet.Location = new Point(129, 28);
            label_MatarHjul_Hastighet.Margin = new Padding(1, 0, 0, 0);
            label_MatarHjul_Hastighet.Name = "label_MatarHjul_Hastighet";
            label_MatarHjul_Hastighet.Padding = new Padding(1, 0, 1, 0);
            tlp_Main.SetRowSpan(label_MatarHjul_Hastighet, 3);
            label_MatarHjul_Hastighet.Size = new Size(75, 61);
            label_MatarHjul_Hastighet.TabIndex = 131;
            label_MatarHjul_Hastighet.Text = "Matarhjul hastighet";
            label_MatarHjul_Hastighet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Slipmaskin
            // 
            label_Slipmaskin.BackColor = Color.White;
            label_Slipmaskin.Dock = DockStyle.Fill;
            label_Slipmaskin.Font = new Font("Arial", 8.55F);
            label_Slipmaskin.ForeColor = Color.Black;
            label_Slipmaskin.Location = new Point(44, 28);
            label_Slipmaskin.Margin = new Padding(1, 0, 0, 1);
            label_Slipmaskin.Name = "label_Slipmaskin";
            tlp_Main.SetRowSpan(label_Slipmaskin, 4);
            label_Slipmaskin.Size = new Size(84, 76);
            label_Slipmaskin.TabIndex = 130;
            label_Slipmaskin.Text = "Slip- maskin RMG";
            label_Slipmaskin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_7
            // 
            label_Empty_7.BackColor = Color.DarkGray;
            tlp_Main.SetColumnSpan(label_Empty_7, 3);
            label_Empty_7.Cursor = Cursors.SizeAll;
            label_Empty_7.Dock = DockStyle.Fill;
            label_Empty_7.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_7.ForeColor = Color.ForestGreen;
            label_Empty_7.Location = new Point(496, 151);
            label_Empty_7.Margin = new Padding(1, 0, 0, 1);
            label_Empty_7.Name = "label_Empty_7";
            label_Empty_7.Size = new Size(241, 22);
            label_Empty_7.TabIndex = 1007;
            label_Empty_7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Centerhöjd_enhet
            // 
            label_Centerhöjd_enhet.BackColor = Color.White;
            label_Centerhöjd_enhet.Dock = DockStyle.Fill;
            label_Centerhöjd_enhet.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Centerhöjd_enhet.ForeColor = Color.Black;
            label_Centerhöjd_enhet.Location = new Point(650, 89);
            label_Centerhöjd_enhet.Margin = new Padding(1, 0, 1, 1);
            label_Centerhöjd_enhet.Name = "label_Centerhöjd_enhet";
            label_Centerhöjd_enhet.Size = new Size(86, 15);
            label_Centerhöjd_enhet.TabIndex = 812;
            label_Centerhöjd_enhet.Text = "mm";
            label_Centerhöjd_enhet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_12
            // 
            label_Empty_12.BackColor = Color.DarkGray;
            label_Empty_12.Cursor = Cursors.SizeAll;
            label_Empty_12.Dock = DockStyle.Fill;
            label_Empty_12.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_12.ForeColor = Color.ForestGreen;
            label_Empty_12.Location = new Point(496, 128);
            label_Empty_12.Margin = new Padding(1, 0, 0, 0);
            label_Empty_12.Name = "label_Empty_12";
            label_Empty_12.Size = new Size(69, 23);
            label_Empty_12.TabIndex = 1007;
            label_Empty_12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_10
            // 
            label_Empty_10.BackColor = Color.DarkGray;
            label_Empty_10.Cursor = Cursors.SizeAll;
            label_Empty_10.Dock = DockStyle.Fill;
            label_Empty_10.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_10.ForeColor = Color.ForestGreen;
            label_Empty_10.Location = new Point(128, 105);
            label_Empty_10.Margin = new Padding(0, 0, 0, 1);
            label_Empty_10.Name = "label_Empty_10";
            label_Empty_10.Size = new Size(76, 22);
            label_Empty_10.TabIndex = 1007;
            label_Empty_10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Matarhjul_Vinkel_min
            // 
            lbl_Matarhjul_Vinkel_min.AutoSize = true;
            lbl_Matarhjul_Vinkel_min.BackColor = Color.FromArgb(230, 230, 230);
            lbl_Matarhjul_Vinkel_min.Dock = DockStyle.Fill;
            lbl_Matarhjul_Vinkel_min.Font = new Font("Consolas", 8.75F);
            lbl_Matarhjul_Vinkel_min.ForeColor = Color.DodgerBlue;
            lbl_Matarhjul_Vinkel_min.Location = new Point(205, 105);
            lbl_Matarhjul_Vinkel_min.Margin = new Padding(1, 0, 0, 1);
            lbl_Matarhjul_Vinkel_min.Name = "lbl_Matarhjul_Vinkel_min";
            lbl_Matarhjul_Vinkel_min.Size = new Size(65, 22);
            lbl_Matarhjul_Vinkel_min.TabIndex = 1001;
            lbl_Matarhjul_Vinkel_min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_14
            // 
            label_Empty_14.BackColor = Color.DarkGray;
            label_Empty_14.Cursor = Cursors.SizeAll;
            label_Empty_14.Dock = DockStyle.Fill;
            label_Empty_14.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_14.ForeColor = Color.ForestGreen;
            label_Empty_14.Location = new Point(271, 105);
            label_Empty_14.Margin = new Padding(1, 0, 0, 1);
            label_Empty_14.Name = "label_Empty_14";
            label_Empty_14.Size = new Size(67, 22);
            label_Empty_14.TabIndex = 1007;
            label_Empty_14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_15
            // 
            label_Empty_15.BackColor = Color.DarkGray;
            label_Empty_15.Cursor = Cursors.SizeAll;
            label_Empty_15.Dock = DockStyle.Fill;
            label_Empty_15.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_15.ForeColor = Color.ForestGreen;
            label_Empty_15.Location = new Point(271, 151);
            label_Empty_15.Margin = new Padding(1, 0, 0, 1);
            label_Empty_15.Name = "label_Empty_15";
            label_Empty_15.Size = new Size(67, 22);
            label_Empty_15.TabIndex = 1008;
            label_Empty_15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Matarhjul_Vinkel_max
            // 
            lbl_Matarhjul_Vinkel_max.AutoSize = true;
            lbl_Matarhjul_Vinkel_max.BackColor = Color.FromArgb(230, 230, 230);
            lbl_Matarhjul_Vinkel_max.Dock = DockStyle.Fill;
            lbl_Matarhjul_Vinkel_max.Font = new Font("Consolas", 8.75F);
            lbl_Matarhjul_Vinkel_max.ForeColor = Color.DodgerBlue;
            lbl_Matarhjul_Vinkel_max.Location = new Point(205, 151);
            lbl_Matarhjul_Vinkel_max.Margin = new Padding(1, 0, 0, 1);
            lbl_Matarhjul_Vinkel_max.Name = "lbl_Matarhjul_Vinkel_max";
            lbl_Matarhjul_Vinkel_max.Size = new Size(65, 22);
            lbl_Matarhjul_Vinkel_max.TabIndex = 1001;
            lbl_Matarhjul_Vinkel_max.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Maskinparametrar_Datum
            // 
            label_Maskinparametrar_Datum.BackColor = Color.White;
            label_Maskinparametrar_Datum.Dock = DockStyle.Fill;
            label_Maskinparametrar_Datum.Font = new Font("Arial", 8.55F);
            label_Maskinparametrar_Datum.ForeColor = Color.Black;
            label_Maskinparametrar_Datum.Location = new Point(737, 28);
            label_Maskinparametrar_Datum.Margin = new Padding(0, 0, 0, 1);
            label_Maskinparametrar_Datum.Name = "label_Maskinparametrar_Datum";
            tlp_Main.SetRowSpan(label_Maskinparametrar_Datum, 4);
            label_Maskinparametrar_Datum.Size = new Size(93, 76);
            label_Maskinparametrar_Datum.TabIndex = 809;
            label_Maskinparametrar_Datum.Text = "Datum";
            label_Maskinparametrar_Datum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Maskinparametrar_Tid
            // 
            label_Maskinparametrar_Tid.BackColor = Color.White;
            label_Maskinparametrar_Tid.Dock = DockStyle.Fill;
            label_Maskinparametrar_Tid.Font = new Font("Arial", 8.55F);
            label_Maskinparametrar_Tid.ForeColor = Color.Black;
            label_Maskinparametrar_Tid.Location = new Point(831, 28);
            label_Maskinparametrar_Tid.Margin = new Padding(1, 0, 0, 1);
            label_Maskinparametrar_Tid.Name = "label_Maskinparametrar_Tid";
            tlp_Main.SetRowSpan(label_Maskinparametrar_Tid, 4);
            label_Maskinparametrar_Tid.Size = new Size(55, 76);
            label_Maskinparametrar_Tid.TabIndex = 809;
            label_Maskinparametrar_Tid.Text = "Tid";
            label_Maskinparametrar_Tid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Maskinparametrar_AnstNr
            // 
            label_Maskinparametrar_AnstNr.BackColor = Color.White;
            label_Maskinparametrar_AnstNr.Dock = DockStyle.Fill;
            label_Maskinparametrar_AnstNr.Font = new Font("Arial", 8.55F);
            label_Maskinparametrar_AnstNr.ForeColor = Color.Black;
            label_Maskinparametrar_AnstNr.Location = new Point(887, 28);
            label_Maskinparametrar_AnstNr.Margin = new Padding(1, 0, 0, 1);
            label_Maskinparametrar_AnstNr.Name = "label_Maskinparametrar_AnstNr";
            tlp_Main.SetRowSpan(label_Maskinparametrar_AnstNr, 4);
            label_Maskinparametrar_AnstNr.Size = new Size(46, 76);
            label_Maskinparametrar_AnstNr.TabIndex = 809;
            label_Maskinparametrar_AnstNr.Text = "Anst Nr";
            label_Maskinparametrar_AnstNr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Maskinparametrar_Sign
            // 
            label_Maskinparametrar_Sign.BackColor = Color.White;
            label_Maskinparametrar_Sign.Dock = DockStyle.Fill;
            label_Maskinparametrar_Sign.Font = new Font("Arial", 8.55F);
            label_Maskinparametrar_Sign.ForeColor = Color.Black;
            label_Maskinparametrar_Sign.Location = new Point(934, 28);
            label_Maskinparametrar_Sign.Margin = new Padding(1, 0, 0, 1);
            label_Maskinparametrar_Sign.Name = "label_Maskinparametrar_Sign";
            tlp_Main.SetRowSpan(label_Maskinparametrar_Sign, 4);
            label_Maskinparametrar_Sign.Size = new Size(109, 76);
            label_Maskinparametrar_Sign.TabIndex = 809;
            label_Maskinparametrar_Sign.Text = "Sign";
            label_Maskinparametrar_Sign.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.DarkGray;
            tlp_Main.SetColumnSpan(label3, 4);
            label3.Cursor = Cursors.SizeAll;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.ForestGreen;
            label3.Location = new Point(737, 105);
            label3.Margin = new Padding(0, 0, 0, 1);
            label3.Name = "label3";
            tlp_Main.SetRowSpan(label3, 3);
            label3.Size = new Size(306, 68);
            label3.TabIndex = 1007;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_MatarhjulHastighet
            // 
            tb_MatarhjulHastighet.BackColor = Color.White;
            tb_MatarhjulHastighet.BorderStyle = BorderStyle.None;
            tb_MatarhjulHastighet.Cursor = Cursors.IBeam;
            tb_MatarhjulHastighet.Dock = DockStyle.Fill;
            tb_MatarhjulHastighet.Font = new Font("Courier New", 8.5F);
            tb_MatarhjulHastighet.ForeColor = Color.DarkSlateGray;
            tb_MatarhjulHastighet.Location = new Point(129, 175);
            tb_MatarhjulHastighet.Margin = new Padding(1, 1, 0, 0);
            tb_MatarhjulHastighet.MaxLength = 4;
            tb_MatarhjulHastighet.Multiline = true;
            tb_MatarhjulHastighet.Name = "tb_MatarhjulHastighet";
            tb_MatarhjulHastighet.Size = new Size(75, 24);
            tb_MatarhjulHastighet.TabIndex = 11;
            tb_MatarhjulHastighet.TextAlign = HorizontalAlignment.Center;
            tb_MatarhjulHastighet.WordWrap = false;
            tb_MatarhjulHastighet.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_MatarhjulVinkel
            // 
            tb_MatarhjulVinkel.BackColor = Color.White;
            tb_MatarhjulVinkel.BorderStyle = BorderStyle.None;
            tb_MatarhjulVinkel.Cursor = Cursors.IBeam;
            tb_MatarhjulVinkel.Dock = DockStyle.Fill;
            tb_MatarhjulVinkel.Font = new Font("Courier New", 8.5F);
            tb_MatarhjulVinkel.ForeColor = Color.DarkSlateGray;
            tb_MatarhjulVinkel.Location = new Point(205, 175);
            tb_MatarhjulVinkel.Margin = new Padding(1, 1, 0, 0);
            tb_MatarhjulVinkel.MaxLength = 4;
            tb_MatarhjulVinkel.Multiline = true;
            tb_MatarhjulVinkel.Name = "tb_MatarhjulVinkel";
            tb_MatarhjulVinkel.Size = new Size(65, 24);
            tb_MatarhjulVinkel.TabIndex = 11;
            tb_MatarhjulVinkel.TextAlign = HorizontalAlignment.Center;
            tb_MatarhjulVinkel.WordWrap = false;
            tb_MatarhjulVinkel.KeyDown += EnterToTab_KeyDown;
            tb_MatarhjulVinkel.Leave += Check_MIN_NOM_MAX_Leave;
            // 
            // tb_HelixVinkel
            // 
            tb_HelixVinkel.BackColor = Color.White;
            tb_HelixVinkel.BorderStyle = BorderStyle.None;
            tb_HelixVinkel.Cursor = Cursors.IBeam;
            tb_HelixVinkel.Dock = DockStyle.Fill;
            tb_HelixVinkel.Font = new Font("Courier New", 8.5F);
            tb_HelixVinkel.ForeColor = Color.DarkSlateGray;
            tb_HelixVinkel.Location = new Point(271, 175);
            tb_HelixVinkel.Margin = new Padding(1, 1, 0, 0);
            tb_HelixVinkel.MaxLength = 4;
            tb_HelixVinkel.Multiline = true;
            tb_HelixVinkel.Name = "tb_HelixVinkel";
            tb_HelixVinkel.Size = new Size(67, 24);
            tb_HelixVinkel.TabIndex = 11;
            tb_HelixVinkel.TextAlign = HorizontalAlignment.Center;
            tb_HelixVinkel.WordWrap = false;
            tb_HelixVinkel.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_Bladhöjd
            // 
            tb_Bladhöjd.BackColor = Color.White;
            tb_Bladhöjd.BorderStyle = BorderStyle.None;
            tb_Bladhöjd.Cursor = Cursors.IBeam;
            tb_Bladhöjd.Dock = DockStyle.Fill;
            tb_Bladhöjd.Font = new Font("Courier New", 8.5F);
            tb_Bladhöjd.ForeColor = Color.DarkSlateGray;
            tb_Bladhöjd.Location = new Point(339, 175);
            tb_Bladhöjd.Margin = new Padding(1, 1, 0, 0);
            tb_Bladhöjd.MaxLength = 6;
            tb_Bladhöjd.Multiline = true;
            tb_Bladhöjd.Name = "tb_Bladhöjd";
            tb_Bladhöjd.Size = new Size(74, 24);
            tb_Bladhöjd.TabIndex = 11;
            tb_Bladhöjd.TextAlign = HorizontalAlignment.Center;
            tb_Bladhöjd.WordWrap = false;
            tb_Bladhöjd.KeyDown += EnterToTab_KeyDown;
            tb_Bladhöjd.Leave += Check_MIN_NOM_MAX_Leave;
            // 
            // tb_Arbetsblad
            // 
            tb_Arbetsblad.BackColor = Color.White;
            tb_Arbetsblad.BorderStyle = BorderStyle.None;
            tb_Arbetsblad.Cursor = Cursors.IBeam;
            tb_Arbetsblad.Dock = DockStyle.Fill;
            tb_Arbetsblad.Font = new Font("Courier New", 8.5F);
            tb_Arbetsblad.ForeColor = Color.DarkSlateGray;
            tb_Arbetsblad.Location = new Point(414, 175);
            tb_Arbetsblad.Margin = new Padding(1, 1, 0, 0);
            tb_Arbetsblad.MaxLength = 5;
            tb_Arbetsblad.Multiline = true;
            tb_Arbetsblad.Name = "tb_Arbetsblad";
            tb_Arbetsblad.Size = new Size(81, 24);
            tb_Arbetsblad.TabIndex = 11;
            tb_Arbetsblad.TextAlign = HorizontalAlignment.Center;
            tb_Arbetsblad.WordWrap = false;
            tb_Arbetsblad.KeyDown += EnterToTab_KeyDown;
            tb_Arbetsblad.Leave += Check_MIN_NOM_MAX_Leave;
            // 
            // tb_Nr
            // 
            tb_Nr.BackColor = Color.White;
            tb_Nr.BorderStyle = BorderStyle.None;
            tb_Nr.Cursor = Cursors.IBeam;
            tb_Nr.Dock = DockStyle.Fill;
            tb_Nr.Font = new Font("Courier New", 8.5F);
            tb_Nr.ForeColor = Color.DarkSlateGray;
            tb_Nr.Location = new Point(496, 175);
            tb_Nr.Margin = new Padding(1, 1, 0, 0);
            tb_Nr.MaxLength = 4;
            tb_Nr.Multiline = true;
            tb_Nr.Name = "tb_Nr";
            tb_Nr.Size = new Size(69, 24);
            tb_Nr.TabIndex = 11;
            tb_Nr.TextAlign = HorizontalAlignment.Center;
            tb_Nr.WordWrap = false;
            tb_Nr.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_Chimshöjd
            // 
            tb_Chimshöjd.BackColor = Color.White;
            tb_Chimshöjd.BorderStyle = BorderStyle.None;
            tb_Chimshöjd.Cursor = Cursors.IBeam;
            tb_Chimshöjd.Dock = DockStyle.Fill;
            tb_Chimshöjd.Font = new Font("Courier New", 8.5F);
            tb_Chimshöjd.ForeColor = Color.DarkSlateGray;
            tb_Chimshöjd.Location = new Point(566, 175);
            tb_Chimshöjd.Margin = new Padding(1, 1, 0, 0);
            tb_Chimshöjd.MaxLength = 4;
            tb_Chimshöjd.Multiline = true;
            tb_Chimshöjd.Name = "tb_Chimshöjd";
            tb_Chimshöjd.Size = new Size(83, 24);
            tb_Chimshöjd.TabIndex = 11;
            tb_Chimshöjd.TextAlign = HorizontalAlignment.Center;
            tb_Chimshöjd.WordWrap = false;
            tb_Chimshöjd.KeyDown += EnterToTab_KeyDown;
            // 
            // label4
            // 
            label4.BackColor = Color.DarkGray;
            tlp_Main.SetColumnSpan(label4, 5);
            label4.Cursor = Cursors.SizeAll;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.ForestGreen;
            label4.Location = new Point(650, 175);
            label4.Margin = new Padding(1, 1, 0, 0);
            label4.Name = "label4";
            label4.Size = new Size(393, 24);
            label4.TabIndex = 1007;
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle3.ForeColor = Color.Gray;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn1.HeaderText = "Slipmaskin";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn1.Width = 84;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle4.ForeColor = Color.Gray;
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewTextBoxColumn2.HeaderText = "Matarhjul Hastighet";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn2.Width = 76;
            // 
            // dgv_Maskinparametrar_MatarhjulVinkel
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle5.ForeColor = Color.Gray;
            dgv_Maskinparametrar_MatarhjulVinkel.DefaultCellStyle = dataGridViewCellStyle5;
            dgv_Maskinparametrar_MatarhjulVinkel.HeaderText = "Matarhjul Vinkel";
            dgv_Maskinparametrar_MatarhjulVinkel.Name = "dgv_Maskinparametrar_MatarhjulVinkel";
            dgv_Maskinparametrar_MatarhjulVinkel.ReadOnly = true;
            dgv_Maskinparametrar_MatarhjulVinkel.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_MatarhjulVinkel.Width = 66;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle6.ForeColor = Color.Gray;
            dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewTextBoxColumn4.HeaderText = "Helix Vinkel";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn4.Width = 68;
            // 
            // dgv_Maskinparametrar_Bladhöjd
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle7.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Bladhöjd.DefaultCellStyle = dataGridViewCellStyle7;
            dgv_Maskinparametrar_Bladhöjd.HeaderText = "Bladhöjd";
            dgv_Maskinparametrar_Bladhöjd.Name = "dgv_Maskinparametrar_Bladhöjd";
            dgv_Maskinparametrar_Bladhöjd.ReadOnly = true;
            dgv_Maskinparametrar_Bladhöjd.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Bladhöjd.Width = 75;
            // 
            // dgv_Maskinparametrar_Arbetsblad
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle8.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Arbetsblad.DefaultCellStyle = dataGridViewCellStyle8;
            dgv_Maskinparametrar_Arbetsblad.HeaderText = "Arbetsblad";
            dgv_Maskinparametrar_Arbetsblad.Name = "dgv_Maskinparametrar_Arbetsblad";
            dgv_Maskinparametrar_Arbetsblad.ReadOnly = true;
            dgv_Maskinparametrar_Arbetsblad.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Arbetsblad.Width = 82;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle9.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle9.ForeColor = Color.Gray;
            dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewTextBoxColumn7.HeaderText = "Nr";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn7.Width = 70;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle10.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle10.ForeColor = Color.Gray;
            dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewTextBoxColumn8.HeaderText = "Chimshöjd";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            dataGridViewTextBoxColumn8.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn8.Width = 83;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewCellStyle11.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle11.ForeColor = Color.Gray;
            dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewTextBoxColumn9.HeaderText = "Centerhöjd";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            dataGridViewTextBoxColumn9.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn9.Width = 87;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle12.ForeColor = Color.Gray;
            dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle12;
            dataGridViewTextBoxColumn14.HeaderText = "Datum";
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.ReadOnly = true;
            dataGridViewTextBoxColumn14.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn14.Width = 94;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle13.ForeColor = Color.Gray;
            dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewTextBoxColumn15.HeaderText = "Tid";
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            dataGridViewTextBoxColumn15.ReadOnly = true;
            dataGridViewTextBoxColumn15.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn15.Width = 56;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle14.ForeColor = Color.Gray;
            dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewTextBoxColumn16.HeaderText = "AnstNr";
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.ReadOnly = true;
            dataGridViewTextBoxColumn16.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn16.Width = 57;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewTextBoxColumn17.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle15.ForeColor = Color.Gray;
            dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewTextBoxColumn17.HeaderText = "Sign";
            dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            dataGridViewTextBoxColumn17.ReadOnly = true;
            dataGridViewTextBoxColumn17.Resizable = DataGridViewTriState.False;
            // 
            // Maskinparametrar_Slipning_TEF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Maskinparametrar_Slipning_TEF";
            Size = new Size(1042, 380);
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ((ISupportInitialize)dgv_MaskinParametrar).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private Label lbl_Transfer_Maskinparametrar;
        private Label label_Empty_11;
        private Label label_Empty_1;
        private Label lbl_Centerhöjd;
        private Label lbl_Arbetsblad_max;
        private Label lbl_Bladhöjd_max;
        private Label lbl_Arbetsblad_min;
        private Label lbl_Bladhöjd_min;
        private Label label_Chimshöjd;
        private TextBox tb_Slipmaskin;
        private Label lbl_Chimshöjd_nom;
        private Label label_Empty_3;
        private Label lbl_Arbetsblad_nom;
        private Label lbl_Bladhöjd_nom;
        private Label lbl_Helix_Vinkel_nom;
        private Label lbl_Matarhjul_Vinkel_nom;
        private Label lbl_Matarhjul_Hastighet_nom;
        private Label label_Empty_2;
        private Label label_MAX;
        private Label label_NOM;
        private Label label_MIN;
        private Label label_Empty_9;
        private DataGridView dgv_MaskinParametrar;
        private Label label_Bladhöjd_enhet;
        private Label label_Helix_Vikel_enhet;
        private Label label_Matarhjul_Vinkel_enhet;
        private Label label_Matarhjul_Hastighet_enhet;
        private Label label_Chimshöjd_enhet;
        private Label label_Empty_8;
        private Label label_Värmebackar;
        private Label label_Nr;
        private Label label_Arbetsblad;
        private Label label_Bladhöjd;
        private Label label_Helix_Vinkel;
        private Label label_Matarhjul_Vinkel;
        private Label label_MatarHjul_Hastighet;
        private Label label_Slipmaskin;
        private Label label_Empty_7;
        private Label label_Centerhöjd_enhet;
        private Label label_Empty_12;
        private Label label_Empty_10;
        private Label lbl_Matarhjul_Vinkel_min;
        private Label label_Empty_14;
        private Label label_Empty_15;
        private Label lbl_Matarhjul_Vinkel_max;
        private Label label_Maskinparametrar_Datum;
        private Label label_Maskinparametrar_Tid;
        private Label label_Maskinparametrar_AnstNr;
        private Label label_Maskinparametrar_Sign;
        private Label label3;
        private TextBox tb_MatarhjulHastighet;
        private TextBox tb_MatarhjulVinkel;
        private TextBox tb_HelixVinkel;
        private TextBox tb_Bladhöjd;
        private TextBox tb_Arbetsblad;
        private TextBox tb_Nr;
        private TextBox tb_Chimshöjd;
        private Label label4;
        private Label label_Maskinparametrar;
        public TableLayoutPanel tlp_Main;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_MatarhjulVinkel;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Bladhöjd;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Arbetsblad;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
    }
}
