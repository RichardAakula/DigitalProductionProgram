using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Slipning_TEF
{
    partial class Produktion_Slipning_TEF
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
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
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
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            tlp_Main = new TableLayoutPanel();
            lbl_Transfer_Produktion = new Label();
            lbl_Edit_Row_Produktion = new Label();
            lbl_Kassera_Produktion = new Label();
            label_Totalalängd_unit = new Label();
            label_SkärmadSlang_Uppmätt = new Label();
            label_Mjukslang_Uppmätt = new Label();
            label_Inledande_Skärmat = new Label();
            label_Godkänd = new Label();
            label_Skärmad_Slang = new Label();
            label_Mjukslang = new Label();
            label_Inledande = new Label();
            label_Empty_5 = new Label();
            label_Produktion_Slipning = new Label();
            label_Godkända_Antal_Godkända = new Label();
            label_Godkända_PåseNr = new Label();
            label_Godkända_Dragprov_Antal = new Label();
            label_Godkända_Hållfasthet = new Label();
            label_Hållfasthet_enhet = new Label();
            label_Hållfasthet_Procent = new Label();
            label_Hållfasthet_1_kort = new Label();
            label_Hållfasthet_1_lång = new Label();
            label_Hållfasthet_2_kort = new Label();
            label_Hållfasthet_2_lång = new Label();
            label_Godkända_ProvAntal_QC = new Label();
            label_Inspektion_Datum = new Label();
            label_Inspektion_AnstNr = new Label();
            label_Inspektion_Sign = new Label();
            label_Inledande_LotNr = new Label();
            label_Inledande_Påse_Nr = new Label();
            label_Mjukslang_ID = new Label();
            label_Mjukslang_OD = new Label();
            label_ODmm_kort = new Label();
            label_ODmm_lång = new Label();
            label_SkärmadSlang_ID = new Label();
            label_SkärmadSlang_OD = new Label();
            tb_Inledande_Påse = new TextBox();
            tb_Mjukslang_ID = new TextBox();
            tb_Mjukslang_OD_kort = new TextBox();
            tb_SkärmadSlang_OD = new TextBox();
            tb_SkärmadSlang_ID = new TextBox();
            tb_SkärmadSlang_Längd = new TextBox();
            tb_Antal_Godkända = new TextBox();
            tb_Dragprov_Antal = new TextBox();
            tb_Hållfasthet_Newton_kort = new TextBox();
            tb_Lev_Påse = new TextBox();
            tb_Hållfasthet_Procent_kort = new TextBox();
            tb_ProvAntal_QC = new TextBox();
            tb_Mjukslang_OD_lång = new TextBox();
            tb_Hållfasthet_Newton_lång = new TextBox();
            tb_Hållfasthet_Procent_lång = new TextBox();
            label_Empty_6 = new Label();
            dgv_Produktion = new DataGridView();
            tb_Inledande_LotNr = new TextBox();
            OrderNr = new DataGridViewTextBoxColumn();
            Påse_Nr = new DataGridViewTextBoxColumn();
            Mjukslang_ID = new DataGridViewTextBoxColumn();
            Mjukslang_OD_kort = new DataGridViewTextBoxColumn();
            Mjukslang_OD_lång = new DataGridViewTextBoxColumn();
            SkärmadSlang_ID = new DataGridViewTextBoxColumn();
            SkärmadSlang_OD = new DataGridViewTextBoxColumn();
            SkärmadSlang_Längd = new DataGridViewTextBoxColumn();
            Antal_Godkända = new DataGridViewTextBoxColumn();
            Lev_Påse = new DataGridViewTextBoxColumn();
            DragProvAntal = new DataGridViewTextBoxColumn();
            Hållfasthet_Newton_kort = new DataGridViewTextBoxColumn();
            Hållfasthet_Newton_lång = new DataGridViewTextBoxColumn();
            Hållfasthet_Procent_kort = new DataGridViewTextBoxColumn();
            Hållfasthet_Procent_lång = new DataGridViewTextBoxColumn();
            Provantal_QC = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            AnstNr = new DataGridViewTextBoxColumn();
            Sign = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            ExactDate = new DataGridViewTextBoxColumn();
            Discarded = new DataGridViewCheckBoxColumn();
            tlp_Main.SuspendLayout();
            ((ISupportInitialize)dgv_Produktion).BeginInit();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Black;
            tlp_Main.ColumnCount = 20;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 49F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 68F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 49F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 49F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 49F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 49F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 161F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 47F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 93F));
            tlp_Main.Controls.Add(lbl_Transfer_Produktion, 0, 6);
            tlp_Main.Controls.Add(lbl_Edit_Row_Produktion, 0, 8);
            tlp_Main.Controls.Add(lbl_Kassera_Produktion, 0, 7);
            tlp_Main.Controls.Add(label_Totalalängd_unit, 8, 2);
            tlp_Main.Controls.Add(label_SkärmadSlang_Uppmätt, 6, 2);
            tlp_Main.Controls.Add(label_Mjukslang_Uppmätt, 3, 2);
            tlp_Main.Controls.Add(label_Inledande_Skärmat, 1, 2);
            tlp_Main.Controls.Add(label_Godkänd, 9, 1);
            tlp_Main.Controls.Add(label_Skärmad_Slang, 6, 1);
            tlp_Main.Controls.Add(label_Mjukslang, 3, 1);
            tlp_Main.Controls.Add(label_Inledande, 1, 1);
            tlp_Main.Controls.Add(label_Empty_5, 0, 1);
            tlp_Main.Controls.Add(label_Produktion_Slipning, 0, 0);
            tlp_Main.Controls.Add(label_Godkända_Antal_Godkända, 9, 2);
            tlp_Main.Controls.Add(label_Godkända_PåseNr, 10, 2);
            tlp_Main.Controls.Add(label_Godkända_Dragprov_Antal, 11, 2);
            tlp_Main.Controls.Add(label_Godkända_Hållfasthet, 12, 2);
            tlp_Main.Controls.Add(label_Hållfasthet_enhet, 12, 4);
            tlp_Main.Controls.Add(label_Hållfasthet_Procent, 14, 4);
            tlp_Main.Controls.Add(label_Hållfasthet_1_kort, 12, 5);
            tlp_Main.Controls.Add(label_Hållfasthet_1_lång, 13, 5);
            tlp_Main.Controls.Add(label_Hållfasthet_2_kort, 14, 5);
            tlp_Main.Controls.Add(label_Hållfasthet_2_lång, 15, 5);
            tlp_Main.Controls.Add(label_Godkända_ProvAntal_QC, 16, 2);
            tlp_Main.Controls.Add(label_Inspektion_Datum, 17, 2);
            tlp_Main.Controls.Add(label_Inspektion_AnstNr, 18, 2);
            tlp_Main.Controls.Add(label_Inspektion_Sign, 19, 2);
            tlp_Main.Controls.Add(label_Inledande_LotNr, 1, 4);
            tlp_Main.Controls.Add(label_Inledande_Påse_Nr, 2, 4);
            tlp_Main.Controls.Add(label_Mjukslang_ID, 3, 4);
            tlp_Main.Controls.Add(label_Mjukslang_OD, 4, 4);
            tlp_Main.Controls.Add(label_ODmm_kort, 4, 5);
            tlp_Main.Controls.Add(label_ODmm_lång, 5, 5);
            tlp_Main.Controls.Add(label_SkärmadSlang_ID, 6, 4);
            tlp_Main.Controls.Add(label_SkärmadSlang_OD, 7, 4);
            tlp_Main.Controls.Add(tb_Inledande_Påse, 2, 6);
            tlp_Main.Controls.Add(tb_Mjukslang_ID, 3, 6);
            tlp_Main.Controls.Add(tb_Mjukslang_OD_kort, 4, 6);
            tlp_Main.Controls.Add(tb_SkärmadSlang_OD, 7, 6);
            tlp_Main.Controls.Add(tb_SkärmadSlang_ID, 6, 6);
            tlp_Main.Controls.Add(tb_SkärmadSlang_Längd, 8, 6);
            tlp_Main.Controls.Add(tb_Antal_Godkända, 9, 6);
            tlp_Main.Controls.Add(tb_Dragprov_Antal, 11, 6);
            tlp_Main.Controls.Add(tb_Hållfasthet_Newton_kort, 12, 6);
            tlp_Main.Controls.Add(tb_Lev_Påse, 10, 6);
            tlp_Main.Controls.Add(tb_Hållfasthet_Procent_kort, 14, 6);
            tlp_Main.Controls.Add(tb_ProvAntal_QC, 16, 6);
            tlp_Main.Controls.Add(tb_Mjukslang_OD_lång, 5, 6);
            tlp_Main.Controls.Add(tb_Hållfasthet_Newton_lång, 13, 6);
            tlp_Main.Controls.Add(tb_Hållfasthet_Procent_lång, 15, 6);
            tlp_Main.Controls.Add(label_Empty_6, 17, 6);
            tlp_Main.Controls.Add(dgv_Produktion, 1, 7);
            tlp_Main.Controls.Add(tb_Inledande_LotNr, 1, 6);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 10;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 17F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 17F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_Main.Size = new Size(1217, 487);
            tlp_Main.TabIndex = 0;
            // 
            // lbl_Transfer_Produktion
            // 
            lbl_Transfer_Produktion.BackColor = Color.FromArgb(198, 239, 206);
            lbl_Transfer_Produktion.Cursor = Cursors.Hand;
            lbl_Transfer_Produktion.Dock = DockStyle.Fill;
            lbl_Transfer_Produktion.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Transfer_Produktion.ForeColor = Color.FromArgb(0, 97, 0);
            lbl_Transfer_Produktion.Location = new Point(1, 125);
            lbl_Transfer_Produktion.Margin = new Padding(1, 0, 0, 0);
            lbl_Transfer_Produktion.Name = "lbl_Transfer_Produktion";
            lbl_Transfer_Produktion.Size = new Size(33, 27);
            lbl_Transfer_Produktion.TabIndex = 16;
            lbl_Transfer_Produktion.Text = "→";
            lbl_Transfer_Produktion.TextAlign = ContentAlignment.TopCenter;
            lbl_Transfer_Produktion.Click += Save_Click;
            // 
            // lbl_Edit_Row_Produktion
            // 
            lbl_Edit_Row_Produktion.BackColor = Color.FromArgb(255, 235, 156);
            lbl_Edit_Row_Produktion.Cursor = Cursors.Hand;
            lbl_Edit_Row_Produktion.Dock = DockStyle.Fill;
            lbl_Edit_Row_Produktion.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Edit_Row_Produktion.ForeColor = Color.FromArgb(156, 101, 0);
            lbl_Edit_Row_Produktion.Location = new Point(1, 180);
            lbl_Edit_Row_Produktion.Margin = new Padding(1, 1, 0, 0);
            lbl_Edit_Row_Produktion.Name = "lbl_Edit_Row_Produktion";
            lbl_Edit_Row_Produktion.Size = new Size(33, 26);
            lbl_Edit_Row_Produktion.TabIndex = 18;
            lbl_Edit_Row_Produktion.Text = "→";
            lbl_Edit_Row_Produktion.TextAlign = ContentAlignment.TopCenter;
            lbl_Edit_Row_Produktion.Click += Edit_Click;
            // 
            // lbl_Kassera_Produktion
            // 
            lbl_Kassera_Produktion.BackColor = Color.FromArgb(255, 199, 206);
            lbl_Kassera_Produktion.Cursor = Cursors.Hand;
            lbl_Kassera_Produktion.Dock = DockStyle.Fill;
            lbl_Kassera_Produktion.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Kassera_Produktion.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_Kassera_Produktion.Location = new Point(1, 153);
            lbl_Kassera_Produktion.Margin = new Padding(1, 1, 0, 0);
            lbl_Kassera_Produktion.Name = "lbl_Kassera_Produktion";
            lbl_Kassera_Produktion.Size = new Size(33, 26);
            lbl_Kassera_Produktion.TabIndex = 17;
            lbl_Kassera_Produktion.Text = "→";
            lbl_Kassera_Produktion.TextAlign = ContentAlignment.TopCenter;
            lbl_Kassera_Produktion.Click += Discard_Click;
            // 
            // label_Totalalängd_unit
            // 
            label_Totalalängd_unit.BackColor = Color.White;
            label_Totalalängd_unit.Dock = DockStyle.Fill;
            label_Totalalängd_unit.Font = new Font("Arial", 8F, FontStyle.Italic);
            label_Totalalängd_unit.ForeColor = Color.Black;
            label_Totalalängd_unit.Location = new Point(421, 48);
            label_Totalalängd_unit.Margin = new Padding(1, 0, 0, 1);
            label_Totalalängd_unit.Name = "label_Totalalängd_unit";
            tlp_Main.SetRowSpan(label_Totalalängd_unit, 4);
            label_Totalalängd_unit.Size = new Size(57, 76);
            label_Totalalängd_unit.TabIndex = 1034;
            label_Totalalängd_unit.Text = "Totala längd mm";
            label_Totalalängd_unit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_SkärmadSlang_Uppmätt
            // 
            label_SkärmadSlang_Uppmätt.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_SkärmadSlang_Uppmätt, 2);
            label_SkärmadSlang_Uppmätt.Dock = DockStyle.Fill;
            label_SkärmadSlang_Uppmätt.Font = new Font("Arial", 8.5F);
            label_SkärmadSlang_Uppmätt.ForeColor = Color.Black;
            label_SkärmadSlang_Uppmätt.Location = new Point(319, 48);
            label_SkärmadSlang_Uppmätt.Margin = new Padding(1, 0, 0, 1);
            label_SkärmadSlang_Uppmätt.Name = "label_SkärmadSlang_Uppmätt";
            tlp_Main.SetRowSpan(label_SkärmadSlang_Uppmätt, 2);
            label_SkärmadSlang_Uppmätt.Size = new Size(101, 42);
            label_SkärmadSlang_Uppmätt.TabIndex = 1032;
            label_SkärmadSlang_Uppmätt.Text = "Uppmätt";
            label_SkärmadSlang_Uppmätt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Mjukslang_Uppmätt
            // 
            label_Mjukslang_Uppmätt.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_Mjukslang_Uppmätt, 3);
            label_Mjukslang_Uppmätt.Dock = DockStyle.Fill;
            label_Mjukslang_Uppmätt.Font = new Font("Arial", 8.5F);
            label_Mjukslang_Uppmätt.ForeColor = Color.Black;
            label_Mjukslang_Uppmätt.Location = new Point(166, 48);
            label_Mjukslang_Uppmätt.Margin = new Padding(1, 0, 0, 1);
            label_Mjukslang_Uppmätt.Name = "label_Mjukslang_Uppmätt";
            tlp_Main.SetRowSpan(label_Mjukslang_Uppmätt, 2);
            label_Mjukslang_Uppmätt.Size = new Size(152, 42);
            label_Mjukslang_Uppmätt.TabIndex = 1031;
            label_Mjukslang_Uppmätt.Text = "Uppmätt ";
            label_Mjukslang_Uppmätt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_Skärmat
            // 
            label_Inledande_Skärmat.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_Inledande_Skärmat, 2);
            label_Inledande_Skärmat.Dock = DockStyle.Fill;
            label_Inledande_Skärmat.Font = new Font("Arial", 8.55F);
            label_Inledande_Skärmat.ForeColor = Color.Black;
            label_Inledande_Skärmat.Location = new Point(35, 48);
            label_Inledande_Skärmat.Margin = new Padding(1, 0, 0, 1);
            label_Inledande_Skärmat.Name = "label_Inledande_Skärmat";
            tlp_Main.SetRowSpan(label_Inledande_Skärmat, 2);
            label_Inledande_Skärmat.Size = new Size(130, 42);
            label_Inledande_Skärmat.TabIndex = 1030;
            label_Inledande_Skärmat.Text = "Skärmat";
            label_Inledande_Skärmat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Godkänd
            // 
            label_Godkänd.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_Godkänd, 11);
            label_Godkänd.Dock = DockStyle.Fill;
            label_Godkänd.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Godkänd.ForeColor = Color.Black;
            label_Godkänd.Location = new Point(479, 25);
            label_Godkänd.Margin = new Padding(1, 0, 1, 1);
            label_Godkänd.Name = "label_Godkänd";
            label_Godkänd.Size = new Size(737, 22);
            label_Godkänd.TabIndex = 1029;
            label_Godkänd.Text = "Godkänd färdig produkt";
            label_Godkänd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Skärmad_Slang
            // 
            label_Skärmad_Slang.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_Skärmad_Slang, 3);
            label_Skärmad_Slang.Dock = DockStyle.Fill;
            label_Skärmad_Slang.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Skärmad_Slang.ForeColor = Color.Black;
            label_Skärmad_Slang.Location = new Point(319, 25);
            label_Skärmad_Slang.Margin = new Padding(1, 0, 0, 1);
            label_Skärmad_Slang.Name = "label_Skärmad_Slang";
            label_Skärmad_Slang.Size = new Size(159, 22);
            label_Skärmad_Slang.TabIndex = 1028;
            label_Skärmad_Slang.Text = "Skärmad Slang";
            label_Skärmad_Slang.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Mjukslang
            // 
            label_Mjukslang.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_Mjukslang, 3);
            label_Mjukslang.Dock = DockStyle.Fill;
            label_Mjukslang.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Mjukslang.ForeColor = Color.Black;
            label_Mjukslang.Location = new Point(166, 25);
            label_Mjukslang.Margin = new Padding(1, 0, 0, 1);
            label_Mjukslang.Name = "label_Mjukslang";
            label_Mjukslang.Size = new Size(152, 22);
            label_Mjukslang.TabIndex = 1027;
            label_Mjukslang.Text = "Mjukslang";
            label_Mjukslang.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Inledande
            // 
            label_Inledande.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_Inledande, 2);
            label_Inledande.Dock = DockStyle.Fill;
            label_Inledande.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Inledande.ForeColor = Color.Black;
            label_Inledande.Location = new Point(35, 25);
            label_Inledande.Margin = new Padding(1, 0, 0, 1);
            label_Inledande.Name = "label_Inledande";
            label_Inledande.Size = new Size(130, 22);
            label_Inledande.TabIndex = 1026;
            label_Inledande.Text = "Inledande";
            label_Inledande.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Empty_5
            // 
            label_Empty_5.BackColor = Color.DarkGray;
            label_Empty_5.Cursor = Cursors.No;
            label_Empty_5.Dock = DockStyle.Fill;
            label_Empty_5.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_5.ForeColor = Color.ForestGreen;
            label_Empty_5.Location = new Point(1, 25);
            label_Empty_5.Margin = new Padding(1, 0, 0, 1);
            label_Empty_5.Name = "label_Empty_5";
            tlp_Main.SetRowSpan(label_Empty_5, 5);
            label_Empty_5.Size = new Size(33, 99);
            label_Empty_5.TabIndex = 1008;
            label_Empty_5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Slipning
            // 
            label_Produktion_Slipning.BackColor = Color.LightGray;
            label_Produktion_Slipning.BorderStyle = BorderStyle.FixedSingle;
            tlp_Main.SetColumnSpan(label_Produktion_Slipning, 20);
            label_Produktion_Slipning.Cursor = Cursors.SizeAll;
            label_Produktion_Slipning.Dock = DockStyle.Fill;
            label_Produktion_Slipning.Font = new Font("Palatino Linotype", 10.25F);
            label_Produktion_Slipning.ForeColor = Color.SaddleBrown;
            label_Produktion_Slipning.Location = new Point(0, 0);
            label_Produktion_Slipning.Margin = new Padding(0);
            label_Produktion_Slipning.Name = "label_Produktion_Slipning";
            label_Produktion_Slipning.Size = new Size(1217, 25);
            label_Produktion_Slipning.TabIndex = 909;
            label_Produktion_Slipning.Text = "Produktion/Slipning";
            label_Produktion_Slipning.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Godkända_Antal_Godkända
            // 
            label_Godkända_Antal_Godkända.BackColor = Color.White;
            label_Godkända_Antal_Godkända.Dock = DockStyle.Fill;
            label_Godkända_Antal_Godkända.Font = new Font("Arial", 8.5F);
            label_Godkända_Antal_Godkända.ForeColor = Color.Black;
            label_Godkända_Antal_Godkända.Location = new Point(479, 48);
            label_Godkända_Antal_Godkända.Margin = new Padding(1, 0, 0, 1);
            label_Godkända_Antal_Godkända.Name = "label_Godkända_Antal_Godkända";
            tlp_Main.SetRowSpan(label_Godkända_Antal_Godkända, 4);
            label_Godkända_Antal_Godkända.Size = new Size(67, 76);
            label_Godkända_Antal_Godkända.TabIndex = 1035;
            label_Godkända_Antal_Godkända.Text = "Antal godk.";
            label_Godkända_Antal_Godkända.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Godkända_PåseNr
            // 
            label_Godkända_PåseNr.BackColor = Color.White;
            label_Godkända_PåseNr.Dock = DockStyle.Fill;
            label_Godkända_PåseNr.Font = new Font("Arial", 8.5F);
            label_Godkända_PåseNr.ForeColor = Color.Black;
            label_Godkända_PåseNr.Location = new Point(547, 48);
            label_Godkända_PåseNr.Margin = new Padding(1, 0, 0, 1);
            label_Godkända_PåseNr.Name = "label_Godkända_PåseNr";
            tlp_Main.SetRowSpan(label_Godkända_PåseNr, 4);
            label_Godkända_PåseNr.Size = new Size(61, 76);
            label_Godkända_PåseNr.TabIndex = 1036;
            label_Godkända_PåseNr.Text = "Lev. påse nr";
            label_Godkända_PåseNr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Godkända_Dragprov_Antal
            // 
            label_Godkända_Dragprov_Antal.BackColor = Color.White;
            label_Godkända_Dragprov_Antal.Dock = DockStyle.Fill;
            label_Godkända_Dragprov_Antal.Font = new Font("Arial", 8.5F);
            label_Godkända_Dragprov_Antal.ForeColor = Color.Black;
            label_Godkända_Dragprov_Antal.Location = new Point(609, 48);
            label_Godkända_Dragprov_Antal.Margin = new Padding(1, 0, 0, 1);
            label_Godkända_Dragprov_Antal.Name = "label_Godkända_Dragprov_Antal";
            tlp_Main.SetRowSpan(label_Godkända_Dragprov_Antal, 4);
            label_Godkända_Dragprov_Antal.Size = new Size(57, 76);
            label_Godkända_Dragprov_Antal.TabIndex = 1037;
            label_Godkända_Dragprov_Antal.Text = "Drag- prov antal";
            label_Godkända_Dragprov_Antal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Godkända_Hållfasthet
            // 
            label_Godkända_Hållfasthet.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_Godkända_Hållfasthet, 4);
            label_Godkända_Hållfasthet.Dock = DockStyle.Fill;
            label_Godkända_Hållfasthet.Font = new Font("Arial", 8.5F);
            label_Godkända_Hållfasthet.ForeColor = Color.Black;
            label_Godkända_Hållfasthet.Location = new Point(667, 48);
            label_Godkända_Hållfasthet.Margin = new Padding(1, 0, 0, 1);
            label_Godkända_Hållfasthet.Name = "label_Godkända_Hållfasthet";
            tlp_Main.SetRowSpan(label_Godkända_Hållfasthet, 2);
            label_Godkända_Hållfasthet.Size = new Size(195, 42);
            label_Godkända_Hållfasthet.TabIndex = 1038;
            label_Godkända_Hållfasthet.Text = "Hållfasthet";
            label_Godkända_Hållfasthet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Hållfasthet_enhet
            // 
            label_Hållfasthet_enhet.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_Hållfasthet_enhet, 2);
            label_Hållfasthet_enhet.Dock = DockStyle.Fill;
            label_Hållfasthet_enhet.Font = new Font("Arial", 8.25F, FontStyle.Italic);
            label_Hållfasthet_enhet.ForeColor = Color.Black;
            label_Hållfasthet_enhet.Location = new Point(667, 91);
            label_Hållfasthet_enhet.Margin = new Padding(1, 0, 0, 0);
            label_Hållfasthet_enhet.Name = "label_Hållfasthet_enhet";
            label_Hållfasthet_enhet.Size = new Size(97, 17);
            label_Hållfasthet_enhet.TabIndex = 1039;
            label_Hållfasthet_enhet.Text = "N";
            label_Hållfasthet_enhet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Hållfasthet_Procent
            // 
            label_Hållfasthet_Procent.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_Hållfasthet_Procent, 2);
            label_Hållfasthet_Procent.Dock = DockStyle.Fill;
            label_Hållfasthet_Procent.Font = new Font("Arial", 8.25F, FontStyle.Italic);
            label_Hållfasthet_Procent.ForeColor = Color.Black;
            label_Hållfasthet_Procent.Location = new Point(765, 91);
            label_Hållfasthet_Procent.Margin = new Padding(1, 0, 0, 0);
            label_Hållfasthet_Procent.Name = "label_Hållfasthet_Procent";
            label_Hållfasthet_Procent.Size = new Size(97, 17);
            label_Hållfasthet_Procent.TabIndex = 1040;
            label_Hållfasthet_Procent.Text = "%";
            label_Hållfasthet_Procent.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Hållfasthet_1_kort
            // 
            label_Hållfasthet_1_kort.BackColor = Color.White;
            label_Hållfasthet_1_kort.Dock = DockStyle.Fill;
            label_Hållfasthet_1_kort.Font = new Font("Arial", 8.25F, FontStyle.Italic);
            label_Hållfasthet_1_kort.ForeColor = Color.Black;
            label_Hållfasthet_1_kort.Location = new Point(667, 108);
            label_Hållfasthet_1_kort.Margin = new Padding(1, 0, 0, 1);
            label_Hållfasthet_1_kort.Name = "label_Hållfasthet_1_kort";
            label_Hållfasthet_1_kort.Size = new Size(48, 16);
            label_Hållfasthet_1_kort.TabIndex = 1041;
            label_Hållfasthet_1_kort.Text = "kort";
            label_Hållfasthet_1_kort.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Hållfasthet_1_lång
            // 
            label_Hållfasthet_1_lång.BackColor = Color.White;
            label_Hållfasthet_1_lång.Dock = DockStyle.Fill;
            label_Hållfasthet_1_lång.Font = new Font("Arial", 8.25F, FontStyle.Italic);
            label_Hållfasthet_1_lång.ForeColor = Color.Black;
            label_Hållfasthet_1_lång.Location = new Point(716, 108);
            label_Hållfasthet_1_lång.Margin = new Padding(1, 0, 0, 1);
            label_Hållfasthet_1_lång.Name = "label_Hållfasthet_1_lång";
            label_Hållfasthet_1_lång.Size = new Size(48, 16);
            label_Hållfasthet_1_lång.TabIndex = 1042;
            label_Hållfasthet_1_lång.Text = "lång";
            label_Hållfasthet_1_lång.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Hållfasthet_2_kort
            // 
            label_Hållfasthet_2_kort.BackColor = Color.White;
            label_Hållfasthet_2_kort.Dock = DockStyle.Fill;
            label_Hållfasthet_2_kort.Font = new Font("Arial", 8.25F, FontStyle.Italic);
            label_Hållfasthet_2_kort.ForeColor = Color.Black;
            label_Hållfasthet_2_kort.Location = new Point(765, 108);
            label_Hållfasthet_2_kort.Margin = new Padding(1, 0, 0, 1);
            label_Hållfasthet_2_kort.Name = "label_Hållfasthet_2_kort";
            label_Hållfasthet_2_kort.Size = new Size(48, 16);
            label_Hållfasthet_2_kort.TabIndex = 1043;
            label_Hållfasthet_2_kort.Text = "kort";
            label_Hållfasthet_2_kort.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Hållfasthet_2_lång
            // 
            label_Hållfasthet_2_lång.BackColor = Color.White;
            label_Hållfasthet_2_lång.Dock = DockStyle.Fill;
            label_Hållfasthet_2_lång.Font = new Font("Arial", 8.25F, FontStyle.Italic);
            label_Hållfasthet_2_lång.ForeColor = Color.Black;
            label_Hållfasthet_2_lång.Location = new Point(814, 108);
            label_Hållfasthet_2_lång.Margin = new Padding(1, 0, 0, 1);
            label_Hållfasthet_2_lång.Name = "label_Hållfasthet_2_lång";
            label_Hållfasthet_2_lång.Size = new Size(48, 16);
            label_Hållfasthet_2_lång.TabIndex = 1044;
            label_Hållfasthet_2_lång.Text = "lång";
            label_Hållfasthet_2_lång.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Godkända_ProvAntal_QC
            // 
            label_Godkända_ProvAntal_QC.BackColor = Color.White;
            label_Godkända_ProvAntal_QC.Dock = DockStyle.Fill;
            label_Godkända_ProvAntal_QC.Font = new Font("Arial", 8.5F);
            label_Godkända_ProvAntal_QC.ForeColor = Color.Black;
            label_Godkända_ProvAntal_QC.Location = new Point(863, 48);
            label_Godkända_ProvAntal_QC.Margin = new Padding(1, 0, 0, 1);
            label_Godkända_ProvAntal_QC.Name = "label_Godkända_ProvAntal_QC";
            tlp_Main.SetRowSpan(label_Godkända_ProvAntal_QC, 4);
            label_Godkända_ProvAntal_QC.Size = new Size(51, 76);
            label_Godkända_ProvAntal_QC.TabIndex = 1045;
            label_Godkända_ProvAntal_QC.Text = "Prov- antal QC";
            label_Godkända_ProvAntal_QC.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Datum
            // 
            label_Inspektion_Datum.BackColor = Color.White;
            label_Inspektion_Datum.Dock = DockStyle.Fill;
            label_Inspektion_Datum.Font = new Font("Arial", 8.5F);
            label_Inspektion_Datum.ForeColor = Color.Black;
            label_Inspektion_Datum.Location = new Point(915, 48);
            label_Inspektion_Datum.Margin = new Padding(1, 0, 0, 1);
            label_Inspektion_Datum.Name = "label_Inspektion_Datum";
            tlp_Main.SetRowSpan(label_Inspektion_Datum, 4);
            label_Inspektion_Datum.Size = new Size(160, 76);
            label_Inspektion_Datum.TabIndex = 1046;
            label_Inspektion_Datum.Text = "Datum - Tid";
            label_Inspektion_Datum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_AnstNr
            // 
            label_Inspektion_AnstNr.BackColor = Color.White;
            label_Inspektion_AnstNr.Dock = DockStyle.Fill;
            label_Inspektion_AnstNr.Font = new Font("Arial", 8.5F);
            label_Inspektion_AnstNr.ForeColor = Color.Black;
            label_Inspektion_AnstNr.Location = new Point(1076, 48);
            label_Inspektion_AnstNr.Margin = new Padding(1, 0, 0, 1);
            label_Inspektion_AnstNr.Name = "label_Inspektion_AnstNr";
            tlp_Main.SetRowSpan(label_Inspektion_AnstNr, 4);
            label_Inspektion_AnstNr.Size = new Size(46, 76);
            label_Inspektion_AnstNr.TabIndex = 1048;
            label_Inspektion_AnstNr.Text = "Anst Nr";
            label_Inspektion_AnstNr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Sign
            // 
            label_Inspektion_Sign.BackColor = Color.White;
            label_Inspektion_Sign.Dock = DockStyle.Fill;
            label_Inspektion_Sign.Font = new Font("Arial", 8.5F);
            label_Inspektion_Sign.ForeColor = Color.Black;
            label_Inspektion_Sign.Location = new Point(1123, 48);
            label_Inspektion_Sign.Margin = new Padding(1, 0, 1, 1);
            label_Inspektion_Sign.Name = "label_Inspektion_Sign";
            tlp_Main.SetRowSpan(label_Inspektion_Sign, 4);
            label_Inspektion_Sign.Size = new Size(93, 76);
            label_Inspektion_Sign.TabIndex = 1049;
            label_Inspektion_Sign.Text = "Sign";
            label_Inspektion_Sign.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_LotNr
            // 
            label_Inledande_LotNr.BackColor = Color.White;
            label_Inledande_LotNr.Dock = DockStyle.Fill;
            label_Inledande_LotNr.Font = new Font("Arial", 8.5F);
            label_Inledande_LotNr.ForeColor = Color.Black;
            label_Inledande_LotNr.Location = new Point(35, 91);
            label_Inledande_LotNr.Margin = new Padding(1, 0, 0, 1);
            label_Inledande_LotNr.Name = "label_Inledande_LotNr";
            tlp_Main.SetRowSpan(label_Inledande_LotNr, 2);
            label_Inledande_LotNr.Size = new Size(81, 33);
            label_Inledande_LotNr.TabIndex = 1050;
            label_Inledande_LotNr.Text = "LotNr";
            label_Inledande_LotNr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_Påse_Nr
            // 
            label_Inledande_Påse_Nr.BackColor = Color.White;
            label_Inledande_Påse_Nr.Dock = DockStyle.Fill;
            label_Inledande_Påse_Nr.Font = new Font("Arial", 8F, FontStyle.Italic);
            label_Inledande_Påse_Nr.ForeColor = Color.Black;
            label_Inledande_Påse_Nr.Location = new Point(117, 91);
            label_Inledande_Påse_Nr.Margin = new Padding(1, 0, 0, 1);
            label_Inledande_Påse_Nr.Name = "label_Inledande_Påse_Nr";
            tlp_Main.SetRowSpan(label_Inledande_Påse_Nr, 2);
            label_Inledande_Påse_Nr.Size = new Size(48, 33);
            label_Inledande_Påse_Nr.TabIndex = 1051;
            label_Inledande_Påse_Nr.Text = "Påse Nr";
            label_Inledande_Påse_Nr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Mjukslang_ID
            // 
            label_Mjukslang_ID.BackColor = Color.White;
            label_Mjukslang_ID.Dock = DockStyle.Fill;
            label_Mjukslang_ID.Font = new Font("Arial", 8F, FontStyle.Italic);
            label_Mjukslang_ID.ForeColor = Color.Black;
            label_Mjukslang_ID.Location = new Point(166, 91);
            label_Mjukslang_ID.Margin = new Padding(1, 0, 0, 1);
            label_Mjukslang_ID.Name = "label_Mjukslang_ID";
            label_Mjukslang_ID.Padding = new Padding(2, 0, 2, 0);
            tlp_Main.SetRowSpan(label_Mjukslang_ID, 2);
            label_Mjukslang_ID.Size = new Size(50, 33);
            label_Mjukslang_ID.TabIndex = 1053;
            label_Mjukslang_ID.Text = "ID mm";
            label_Mjukslang_ID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Mjukslang_OD
            // 
            label_Mjukslang_OD.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_Mjukslang_OD, 2);
            label_Mjukslang_OD.Dock = DockStyle.Fill;
            label_Mjukslang_OD.Font = new Font("Arial", 8F, FontStyle.Italic);
            label_Mjukslang_OD.ForeColor = Color.Black;
            label_Mjukslang_OD.Location = new Point(217, 91);
            label_Mjukslang_OD.Margin = new Padding(1, 0, 0, 0);
            label_Mjukslang_OD.Name = "label_Mjukslang_OD";
            label_Mjukslang_OD.Size = new Size(101, 17);
            label_Mjukslang_OD.TabIndex = 1052;
            label_Mjukslang_OD.Text = "OD mm";
            label_Mjukslang_OD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_ODmm_kort
            // 
            label_ODmm_kort.BackColor = Color.White;
            label_ODmm_kort.Dock = DockStyle.Fill;
            label_ODmm_kort.Font = new Font("Arial", 8.25F, FontStyle.Italic);
            label_ODmm_kort.ForeColor = Color.Black;
            label_ODmm_kort.Location = new Point(217, 108);
            label_ODmm_kort.Margin = new Padding(1, 0, 0, 1);
            label_ODmm_kort.Name = "label_ODmm_kort";
            label_ODmm_kort.Size = new Size(50, 16);
            label_ODmm_kort.TabIndex = 1054;
            label_ODmm_kort.Text = "kort";
            label_ODmm_kort.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_ODmm_lång
            // 
            label_ODmm_lång.BackColor = Color.White;
            label_ODmm_lång.Dock = DockStyle.Fill;
            label_ODmm_lång.Font = new Font("Arial", 8.25F, FontStyle.Italic);
            label_ODmm_lång.ForeColor = Color.Black;
            label_ODmm_lång.Location = new Point(268, 108);
            label_ODmm_lång.Margin = new Padding(1, 0, 0, 1);
            label_ODmm_lång.Name = "label_ODmm_lång";
            label_ODmm_lång.Size = new Size(50, 16);
            label_ODmm_lång.TabIndex = 1055;
            label_ODmm_lång.Text = "lång";
            label_ODmm_lång.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_SkärmadSlang_ID
            // 
            label_SkärmadSlang_ID.BackColor = Color.White;
            label_SkärmadSlang_ID.Dock = DockStyle.Fill;
            label_SkärmadSlang_ID.Font = new Font("Arial", 8F, FontStyle.Italic);
            label_SkärmadSlang_ID.ForeColor = Color.Black;
            label_SkärmadSlang_ID.Location = new Point(319, 91);
            label_SkärmadSlang_ID.Margin = new Padding(1, 0, 0, 1);
            label_SkärmadSlang_ID.Name = "label_SkärmadSlang_ID";
            label_SkärmadSlang_ID.Padding = new Padding(2, 0, 2, 0);
            tlp_Main.SetRowSpan(label_SkärmadSlang_ID, 2);
            label_SkärmadSlang_ID.Size = new Size(50, 33);
            label_SkärmadSlang_ID.TabIndex = 1056;
            label_SkärmadSlang_ID.Text = "ID mm";
            label_SkärmadSlang_ID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_SkärmadSlang_OD
            // 
            label_SkärmadSlang_OD.BackColor = Color.White;
            label_SkärmadSlang_OD.Dock = DockStyle.Fill;
            label_SkärmadSlang_OD.Font = new Font("Arial", 8F, FontStyle.Italic);
            label_SkärmadSlang_OD.ForeColor = Color.Black;
            label_SkärmadSlang_OD.Location = new Point(370, 91);
            label_SkärmadSlang_OD.Margin = new Padding(1, 0, 0, 1);
            label_SkärmadSlang_OD.Name = "label_SkärmadSlang_OD";
            tlp_Main.SetRowSpan(label_SkärmadSlang_OD, 2);
            label_SkärmadSlang_OD.Size = new Size(50, 33);
            label_SkärmadSlang_OD.TabIndex = 1057;
            label_SkärmadSlang_OD.Text = "OD mm";
            label_SkärmadSlang_OD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_Inledande_Påse
            // 
            tb_Inledande_Påse.BackColor = Color.White;
            tb_Inledande_Påse.BorderStyle = BorderStyle.None;
            tb_Inledande_Påse.Cursor = Cursors.IBeam;
            tb_Inledande_Påse.Dock = DockStyle.Fill;
            tb_Inledande_Påse.Font = new Font("Courier New", 8.5F);
            tb_Inledande_Påse.ForeColor = Color.DarkSlateGray;
            tb_Inledande_Påse.Location = new Point(117, 126);
            tb_Inledande_Påse.Margin = new Padding(1, 1, 0, 0);
            tb_Inledande_Påse.MaxLength = 3;
            tb_Inledande_Påse.Multiline = true;
            tb_Inledande_Påse.Name = "tb_Inledande_Påse";
            tb_Inledande_Påse.Size = new Size(48, 26);
            tb_Inledande_Påse.TabIndex = 1;
            tb_Inledande_Påse.TextAlign = HorizontalAlignment.Center;
            tb_Inledande_Påse.WordWrap = false;
            tb_Inledande_Påse.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_Mjukslang_ID
            // 
            tb_Mjukslang_ID.BackColor = Color.White;
            tb_Mjukslang_ID.BorderStyle = BorderStyle.None;
            tb_Mjukslang_ID.Cursor = Cursors.IBeam;
            tb_Mjukslang_ID.Dock = DockStyle.Fill;
            tb_Mjukslang_ID.Font = new Font("Courier New", 8.5F);
            tb_Mjukslang_ID.ForeColor = Color.DarkSlateGray;
            tb_Mjukslang_ID.Location = new Point(166, 126);
            tb_Mjukslang_ID.Margin = new Padding(1, 1, 0, 0);
            tb_Mjukslang_ID.MaxLength = 5;
            tb_Mjukslang_ID.Multiline = true;
            tb_Mjukslang_ID.Name = "tb_Mjukslang_ID";
            tb_Mjukslang_ID.Size = new Size(50, 26);
            tb_Mjukslang_ID.TabIndex = 2;
            tb_Mjukslang_ID.TextAlign = HorizontalAlignment.Center;
            tb_Mjukslang_ID.WordWrap = false;
            tb_Mjukslang_ID.TextChanged += ID_OD_TextChanged;
            tb_Mjukslang_ID.KeyDown += EnterToTab_KeyDown;
            tb_Mjukslang_ID.KeyPress += Mått_KeyPress;
            // 
            // tb_Mjukslang_OD_kort
            // 
            tb_Mjukslang_OD_kort.BackColor = Color.White;
            tb_Mjukslang_OD_kort.BorderStyle = BorderStyle.None;
            tb_Mjukslang_OD_kort.Cursor = Cursors.IBeam;
            tb_Mjukslang_OD_kort.Dock = DockStyle.Fill;
            tb_Mjukslang_OD_kort.Font = new Font("Courier New", 8.5F);
            tb_Mjukslang_OD_kort.ForeColor = Color.DarkSlateGray;
            tb_Mjukslang_OD_kort.Location = new Point(217, 126);
            tb_Mjukslang_OD_kort.Margin = new Padding(1, 1, 0, 0);
            tb_Mjukslang_OD_kort.MaxLength = 5;
            tb_Mjukslang_OD_kort.Multiline = true;
            tb_Mjukslang_OD_kort.Name = "tb_Mjukslang_OD_kort";
            tb_Mjukslang_OD_kort.Size = new Size(50, 26);
            tb_Mjukslang_OD_kort.TabIndex = 3;
            tb_Mjukslang_OD_kort.TextAlign = HorizontalAlignment.Center;
            tb_Mjukslang_OD_kort.WordWrap = false;
            tb_Mjukslang_OD_kort.TextChanged += ID_OD_TextChanged;
            tb_Mjukslang_OD_kort.KeyDown += EnterToTab_KeyDown;
            tb_Mjukslang_OD_kort.KeyPress += Mått_KeyPress;
            // 
            // tb_SkärmadSlang_OD
            // 
            tb_SkärmadSlang_OD.BackColor = Color.White;
            tb_SkärmadSlang_OD.BorderStyle = BorderStyle.None;
            tb_SkärmadSlang_OD.Cursor = Cursors.IBeam;
            tb_SkärmadSlang_OD.Dock = DockStyle.Fill;
            tb_SkärmadSlang_OD.Font = new Font("Courier New", 8.5F);
            tb_SkärmadSlang_OD.ForeColor = Color.DarkSlateGray;
            tb_SkärmadSlang_OD.Location = new Point(370, 126);
            tb_SkärmadSlang_OD.Margin = new Padding(1, 1, 0, 0);
            tb_SkärmadSlang_OD.MaxLength = 5;
            tb_SkärmadSlang_OD.Multiline = true;
            tb_SkärmadSlang_OD.Name = "tb_SkärmadSlang_OD";
            tb_SkärmadSlang_OD.Size = new Size(50, 26);
            tb_SkärmadSlang_OD.TabIndex = 6;
            tb_SkärmadSlang_OD.TextAlign = HorizontalAlignment.Center;
            tb_SkärmadSlang_OD.WordWrap = false;
            tb_SkärmadSlang_OD.TextChanged += ID_OD_TextChanged;
            tb_SkärmadSlang_OD.KeyDown += EnterToTab_KeyDown;
            tb_SkärmadSlang_OD.KeyPress += Mått_KeyPress;
            // 
            // tb_SkärmadSlang_ID
            // 
            tb_SkärmadSlang_ID.BackColor = Color.White;
            tb_SkärmadSlang_ID.BorderStyle = BorderStyle.None;
            tb_SkärmadSlang_ID.Cursor = Cursors.IBeam;
            tb_SkärmadSlang_ID.Dock = DockStyle.Fill;
            tb_SkärmadSlang_ID.Font = new Font("Courier New", 8.5F);
            tb_SkärmadSlang_ID.ForeColor = Color.DarkSlateGray;
            tb_SkärmadSlang_ID.Location = new Point(319, 126);
            tb_SkärmadSlang_ID.Margin = new Padding(1, 1, 0, 0);
            tb_SkärmadSlang_ID.MaxLength = 5;
            tb_SkärmadSlang_ID.Multiline = true;
            tb_SkärmadSlang_ID.Name = "tb_SkärmadSlang_ID";
            tb_SkärmadSlang_ID.Size = new Size(50, 26);
            tb_SkärmadSlang_ID.TabIndex = 5;
            tb_SkärmadSlang_ID.TextAlign = HorizontalAlignment.Center;
            tb_SkärmadSlang_ID.WordWrap = false;
            tb_SkärmadSlang_ID.TextChanged += ID_OD_TextChanged;
            tb_SkärmadSlang_ID.KeyDown += EnterToTab_KeyDown;
            tb_SkärmadSlang_ID.KeyPress += Mått_KeyPress;
            // 
            // tb_SkärmadSlang_Längd
            // 
            tb_SkärmadSlang_Längd.BackColor = Color.White;
            tb_SkärmadSlang_Längd.BorderStyle = BorderStyle.None;
            tb_SkärmadSlang_Längd.Cursor = Cursors.IBeam;
            tb_SkärmadSlang_Längd.Dock = DockStyle.Fill;
            tb_SkärmadSlang_Längd.Font = new Font("Courier New", 8.5F);
            tb_SkärmadSlang_Längd.ForeColor = Color.DarkSlateGray;
            tb_SkärmadSlang_Längd.Location = new Point(421, 126);
            tb_SkärmadSlang_Längd.Margin = new Padding(1, 1, 0, 0);
            tb_SkärmadSlang_Längd.MaxLength = 5;
            tb_SkärmadSlang_Längd.Multiline = true;
            tb_SkärmadSlang_Längd.Name = "tb_SkärmadSlang_Längd";
            tb_SkärmadSlang_Längd.Size = new Size(57, 26);
            tb_SkärmadSlang_Längd.TabIndex = 7;
            tb_SkärmadSlang_Längd.TextAlign = HorizontalAlignment.Center;
            tb_SkärmadSlang_Längd.WordWrap = false;
            tb_SkärmadSlang_Längd.TextChanged += SkärmadSlang_Längd_TextChanged;
            tb_SkärmadSlang_Längd.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_Antal_Godkända
            // 
            tb_Antal_Godkända.BackColor = Color.White;
            tb_Antal_Godkända.BorderStyle = BorderStyle.None;
            tb_Antal_Godkända.Cursor = Cursors.IBeam;
            tb_Antal_Godkända.Dock = DockStyle.Fill;
            tb_Antal_Godkända.Font = new Font("Courier New", 8.5F);
            tb_Antal_Godkända.ForeColor = Color.DarkSlateGray;
            tb_Antal_Godkända.Location = new Point(479, 126);
            tb_Antal_Godkända.Margin = new Padding(1, 1, 0, 0);
            tb_Antal_Godkända.MaxLength = 7;
            tb_Antal_Godkända.Multiline = true;
            tb_Antal_Godkända.Name = "tb_Antal_Godkända";
            tb_Antal_Godkända.Size = new Size(67, 26);
            tb_Antal_Godkända.TabIndex = 8;
            tb_Antal_Godkända.TextAlign = HorizontalAlignment.Center;
            tb_Antal_Godkända.WordWrap = false;
            tb_Antal_Godkända.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_Dragprov_Antal
            // 
            tb_Dragprov_Antal.BackColor = Color.White;
            tb_Dragprov_Antal.BorderStyle = BorderStyle.None;
            tb_Dragprov_Antal.Cursor = Cursors.IBeam;
            tb_Dragprov_Antal.Dock = DockStyle.Fill;
            tb_Dragprov_Antal.Font = new Font("Courier New", 8.5F);
            tb_Dragprov_Antal.ForeColor = Color.DarkSlateGray;
            tb_Dragprov_Antal.Location = new Point(609, 126);
            tb_Dragprov_Antal.Margin = new Padding(1, 1, 0, 0);
            tb_Dragprov_Antal.MaxLength = 3;
            tb_Dragprov_Antal.Multiline = true;
            tb_Dragprov_Antal.Name = "tb_Dragprov_Antal";
            tb_Dragprov_Antal.Size = new Size(57, 26);
            tb_Dragprov_Antal.TabIndex = 10;
            tb_Dragprov_Antal.TextAlign = HorizontalAlignment.Center;
            tb_Dragprov_Antal.WordWrap = false;
            tb_Dragprov_Antal.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_Hållfasthet_Newton_kort
            // 
            tb_Hållfasthet_Newton_kort.BackColor = Color.White;
            tb_Hållfasthet_Newton_kort.BorderStyle = BorderStyle.None;
            tb_Hållfasthet_Newton_kort.Cursor = Cursors.IBeam;
            tb_Hållfasthet_Newton_kort.Dock = DockStyle.Fill;
            tb_Hållfasthet_Newton_kort.Font = new Font("Courier New", 8.5F);
            tb_Hållfasthet_Newton_kort.ForeColor = Color.DarkSlateGray;
            tb_Hållfasthet_Newton_kort.Location = new Point(667, 126);
            tb_Hållfasthet_Newton_kort.Margin = new Padding(1, 1, 0, 0);
            tb_Hållfasthet_Newton_kort.MaxLength = 3;
            tb_Hållfasthet_Newton_kort.Multiline = true;
            tb_Hållfasthet_Newton_kort.Name = "tb_Hållfasthet_Newton_kort";
            tb_Hållfasthet_Newton_kort.Size = new Size(48, 26);
            tb_Hållfasthet_Newton_kort.TabIndex = 11;
            tb_Hållfasthet_Newton_kort.TextAlign = HorizontalAlignment.Center;
            tb_Hållfasthet_Newton_kort.WordWrap = false;
            tb_Hållfasthet_Newton_kort.TextChanged += Hållfasthet_Newton_kort_lång_TextChanged;
            tb_Hållfasthet_Newton_kort.KeyDown += EnterToTab_KeyDown;
            tb_Hållfasthet_Newton_kort.KeyPress += Mått_KeyPress;
            // 
            // tb_Lev_Påse
            // 
            tb_Lev_Påse.BackColor = Color.White;
            tb_Lev_Påse.BorderStyle = BorderStyle.None;
            tb_Lev_Påse.Cursor = Cursors.IBeam;
            tb_Lev_Påse.Dock = DockStyle.Fill;
            tb_Lev_Påse.Font = new Font("Courier New", 8.5F);
            tb_Lev_Påse.ForeColor = Color.DarkSlateGray;
            tb_Lev_Påse.Location = new Point(547, 126);
            tb_Lev_Påse.Margin = new Padding(1, 1, 0, 0);
            tb_Lev_Påse.MaxLength = 6;
            tb_Lev_Påse.Multiline = true;
            tb_Lev_Påse.Name = "tb_Lev_Påse";
            tb_Lev_Påse.Size = new Size(61, 26);
            tb_Lev_Påse.TabIndex = 9;
            tb_Lev_Påse.TextAlign = HorizontalAlignment.Center;
            tb_Lev_Påse.WordWrap = false;
            tb_Lev_Påse.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_Hållfasthet_Procent_kort
            // 
            tb_Hållfasthet_Procent_kort.BackColor = Color.White;
            tb_Hållfasthet_Procent_kort.BorderStyle = BorderStyle.None;
            tb_Hållfasthet_Procent_kort.Cursor = Cursors.IBeam;
            tb_Hållfasthet_Procent_kort.Dock = DockStyle.Fill;
            tb_Hållfasthet_Procent_kort.Font = new Font("Courier New", 8.5F);
            tb_Hållfasthet_Procent_kort.ForeColor = Color.DarkSlateGray;
            tb_Hållfasthet_Procent_kort.Location = new Point(765, 126);
            tb_Hållfasthet_Procent_kort.Margin = new Padding(1, 1, 0, 0);
            tb_Hållfasthet_Procent_kort.MaxLength = 4;
            tb_Hållfasthet_Procent_kort.Multiline = true;
            tb_Hållfasthet_Procent_kort.Name = "tb_Hållfasthet_Procent_kort";
            tb_Hållfasthet_Procent_kort.Size = new Size(48, 26);
            tb_Hållfasthet_Procent_kort.TabIndex = 13;
            tb_Hållfasthet_Procent_kort.TextAlign = HorizontalAlignment.Center;
            tb_Hållfasthet_Procent_kort.WordWrap = false;
            tb_Hållfasthet_Procent_kort.TextChanged += Hållfasthet_Procent_kort_lång_TextChanged;
            tb_Hållfasthet_Procent_kort.KeyDown += EnterToTab_KeyDown;
            tb_Hållfasthet_Procent_kort.KeyPress += Mått_KeyPress;
            // 
            // tb_ProvAntal_QC
            // 
            tb_ProvAntal_QC.BackColor = Color.White;
            tb_ProvAntal_QC.BorderStyle = BorderStyle.None;
            tb_ProvAntal_QC.Cursor = Cursors.IBeam;
            tb_ProvAntal_QC.Dock = DockStyle.Fill;
            tb_ProvAntal_QC.Font = new Font("Courier New", 8.5F);
            tb_ProvAntal_QC.ForeColor = Color.DarkSlateGray;
            tb_ProvAntal_QC.Location = new Point(863, 126);
            tb_ProvAntal_QC.Margin = new Padding(1, 1, 0, 0);
            tb_ProvAntal_QC.MaxLength = 3;
            tb_ProvAntal_QC.Multiline = true;
            tb_ProvAntal_QC.Name = "tb_ProvAntal_QC";
            tb_ProvAntal_QC.Size = new Size(51, 26);
            tb_ProvAntal_QC.TabIndex = 15;
            tb_ProvAntal_QC.TextAlign = HorizontalAlignment.Center;
            tb_ProvAntal_QC.WordWrap = false;
            tb_ProvAntal_QC.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_Mjukslang_OD_lång
            // 
            tb_Mjukslang_OD_lång.BackColor = Color.White;
            tb_Mjukslang_OD_lång.BorderStyle = BorderStyle.None;
            tb_Mjukslang_OD_lång.Cursor = Cursors.IBeam;
            tb_Mjukslang_OD_lång.Dock = DockStyle.Fill;
            tb_Mjukslang_OD_lång.Font = new Font("Courier New", 8.5F);
            tb_Mjukslang_OD_lång.ForeColor = Color.DarkSlateGray;
            tb_Mjukslang_OD_lång.Location = new Point(268, 126);
            tb_Mjukslang_OD_lång.Margin = new Padding(1, 1, 0, 0);
            tb_Mjukslang_OD_lång.MaxLength = 5;
            tb_Mjukslang_OD_lång.Multiline = true;
            tb_Mjukslang_OD_lång.Name = "tb_Mjukslang_OD_lång";
            tb_Mjukslang_OD_lång.Size = new Size(50, 26);
            tb_Mjukslang_OD_lång.TabIndex = 4;
            tb_Mjukslang_OD_lång.TextAlign = HorizontalAlignment.Center;
            tb_Mjukslang_OD_lång.WordWrap = false;
            tb_Mjukslang_OD_lång.TextChanged += ID_OD_TextChanged;
            tb_Mjukslang_OD_lång.KeyDown += EnterToTab_KeyDown;
            tb_Mjukslang_OD_lång.KeyPress += Mått_KeyPress;
            // 
            // tb_Hållfasthet_Newton_lång
            // 
            tb_Hållfasthet_Newton_lång.BackColor = Color.White;
            tb_Hållfasthet_Newton_lång.BorderStyle = BorderStyle.None;
            tb_Hållfasthet_Newton_lång.Cursor = Cursors.IBeam;
            tb_Hållfasthet_Newton_lång.Dock = DockStyle.Fill;
            tb_Hållfasthet_Newton_lång.Font = new Font("Courier New", 8.5F);
            tb_Hållfasthet_Newton_lång.ForeColor = Color.DarkSlateGray;
            tb_Hållfasthet_Newton_lång.Location = new Point(716, 126);
            tb_Hållfasthet_Newton_lång.Margin = new Padding(1, 1, 0, 0);
            tb_Hållfasthet_Newton_lång.MaxLength = 3;
            tb_Hållfasthet_Newton_lång.Multiline = true;
            tb_Hållfasthet_Newton_lång.Name = "tb_Hållfasthet_Newton_lång";
            tb_Hållfasthet_Newton_lång.Size = new Size(48, 26);
            tb_Hållfasthet_Newton_lång.TabIndex = 12;
            tb_Hållfasthet_Newton_lång.TextAlign = HorizontalAlignment.Center;
            tb_Hållfasthet_Newton_lång.WordWrap = false;
            tb_Hållfasthet_Newton_lång.TextChanged += Hållfasthet_Newton_kort_lång_TextChanged;
            tb_Hållfasthet_Newton_lång.KeyDown += EnterToTab_KeyDown;
            tb_Hållfasthet_Newton_lång.KeyPress += Mått_KeyPress;
            // 
            // tb_Hållfasthet_Procent_lång
            // 
            tb_Hållfasthet_Procent_lång.BackColor = Color.White;
            tb_Hållfasthet_Procent_lång.BorderStyle = BorderStyle.None;
            tb_Hållfasthet_Procent_lång.Cursor = Cursors.IBeam;
            tb_Hållfasthet_Procent_lång.Dock = DockStyle.Fill;
            tb_Hållfasthet_Procent_lång.Font = new Font("Courier New", 8.5F);
            tb_Hållfasthet_Procent_lång.ForeColor = Color.DarkSlateGray;
            tb_Hållfasthet_Procent_lång.Location = new Point(814, 126);
            tb_Hållfasthet_Procent_lång.Margin = new Padding(1, 1, 0, 0);
            tb_Hållfasthet_Procent_lång.MaxLength = 4;
            tb_Hållfasthet_Procent_lång.Multiline = true;
            tb_Hållfasthet_Procent_lång.Name = "tb_Hållfasthet_Procent_lång";
            tb_Hållfasthet_Procent_lång.Size = new Size(48, 26);
            tb_Hållfasthet_Procent_lång.TabIndex = 14;
            tb_Hållfasthet_Procent_lång.TextAlign = HorizontalAlignment.Center;
            tb_Hållfasthet_Procent_lång.WordWrap = false;
            tb_Hållfasthet_Procent_lång.TextChanged += Hållfasthet_Procent_kort_lång_TextChanged;
            tb_Hållfasthet_Procent_lång.KeyDown += EnterToTab_KeyDown;
            tb_Hållfasthet_Procent_lång.KeyPress += Mått_KeyPress;
            // 
            // label_Empty_6
            // 
            label_Empty_6.BackColor = Color.DarkGray;
            tlp_Main.SetColumnSpan(label_Empty_6, 3);
            label_Empty_6.Cursor = Cursors.No;
            label_Empty_6.Dock = DockStyle.Fill;
            label_Empty_6.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_6.ForeColor = Color.ForestGreen;
            label_Empty_6.Location = new Point(915, 126);
            label_Empty_6.Margin = new Padding(1, 1, 1, 0);
            label_Empty_6.Name = "label_Empty_6";
            label_Empty_6.Size = new Size(301, 26);
            label_Empty_6.TabIndex = 1076;
            label_Empty_6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgv_Produktion
            // 
            dgv_Produktion.AllowUserToAddRows = false;
            dgv_Produktion.AllowUserToDeleteRows = false;
            dgv_Produktion.AllowUserToResizeColumns = false;
            dgv_Produktion.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgv_Produktion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Produktion.BackgroundColor = Color.White;
            dgv_Produktion.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_Produktion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_Produktion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Produktion.ColumnHeadersVisible = false;
            dgv_Produktion.Columns.AddRange(new DataGridViewColumn[] { OrderNr, Påse_Nr, Mjukslang_ID, Mjukslang_OD_kort, Mjukslang_OD_lång, SkärmadSlang_ID, SkärmadSlang_OD, SkärmadSlang_Längd, Antal_Godkända, Lev_Påse, DragProvAntal, Hållfasthet_Newton_kort, Hållfasthet_Newton_lång, Hållfasthet_Procent_kort, Hållfasthet_Procent_lång, Provantal_QC, Date, AnstNr, Sign, ID, ExactDate, Discarded });
            tlp_Main.SetColumnSpan(dgv_Produktion, 19);
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = SystemColors.Window;
            dataGridViewCellStyle22.Font = new Font("Courier New", 8F);
            dataGridViewCellStyle22.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle22.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle22.SelectionForeColor = Color.White;
            dataGridViewCellStyle22.WrapMode = DataGridViewTriState.False;
            dgv_Produktion.DefaultCellStyle = dataGridViewCellStyle22;
            dgv_Produktion.Dock = DockStyle.Fill;
            dgv_Produktion.Location = new Point(35, 153);
            dgv_Produktion.Margin = new Padding(1);
            dgv_Produktion.MultiSelect = false;
            dgv_Produktion.Name = "dgv_Produktion";
            dgv_Produktion.ReadOnly = true;
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = SystemColors.Control;
            dataGridViewCellStyle23.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle23.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = DataGridViewTriState.True;
            dgv_Produktion.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            dgv_Produktion.RowHeadersVisible = false;
            tlp_Main.SetRowSpan(dgv_Produktion, 3);
            dgv_Produktion.RowTemplate.Height = 18;
            dgv_Produktion.ScrollBars = ScrollBars.None;
            dgv_Produktion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Produktion.Size = new Size(1181, 333);
            dgv_Produktion.TabIndex = 1079;
            // 
            // tb_Inledande_LotNr
            // 
            tb_Inledande_LotNr.BackColor = Color.White;
            tb_Inledande_LotNr.BorderStyle = BorderStyle.None;
            tb_Inledande_LotNr.Cursor = Cursors.IBeam;
            tb_Inledande_LotNr.Dock = DockStyle.Fill;
            tb_Inledande_LotNr.Font = new Font("Courier New", 8.5F);
            tb_Inledande_LotNr.ForeColor = Color.DarkSlateGray;
            tb_Inledande_LotNr.Location = new Point(35, 126);
            tb_Inledande_LotNr.Margin = new Padding(1, 1, 0, 0);
            tb_Inledande_LotNr.MaxLength = 9;
            tb_Inledande_LotNr.Multiline = true;
            tb_Inledande_LotNr.Name = "tb_Inledande_LotNr";
            tb_Inledande_LotNr.Size = new Size(81, 26);
            tb_Inledande_LotNr.TabIndex = 1080;
            tb_Inledande_LotNr.TextAlign = HorizontalAlignment.Center;
            tb_Inledande_LotNr.WordWrap = false;
            tb_Inledande_LotNr.Enter += Inledande_LotNr_Enter;
            tb_Inledande_LotNr.KeyDown += EnterToTab_KeyDown;
            // 
            // OrderNr
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            OrderNr.DefaultCellStyle = dataGridViewCellStyle3;
            OrderNr.HeaderText = "Inledande OrderNr";
            OrderNr.Name = "OrderNr";
            OrderNr.ReadOnly = true;
            OrderNr.Resizable = DataGridViewTriState.False;
            OrderNr.Width = 81;
            // 
            // Påse_Nr
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Påse_Nr.DefaultCellStyle = dataGridViewCellStyle4;
            Påse_Nr.HeaderText = "Påse";
            Påse_Nr.Name = "Påse_Nr";
            Påse_Nr.ReadOnly = true;
            Påse_Nr.Resizable = DataGridViewTriState.False;
            Påse_Nr.Width = 49;
            // 
            // Mjukslang_ID
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Mjukslang_ID.DefaultCellStyle = dataGridViewCellStyle5;
            Mjukslang_ID.HeaderText = "Mjukslang ID";
            Mjukslang_ID.Name = "Mjukslang_ID";
            Mjukslang_ID.ReadOnly = true;
            Mjukslang_ID.Resizable = DataGridViewTriState.False;
            Mjukslang_ID.Width = 51;
            // 
            // Mjukslang_OD_kort
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Mjukslang_OD_kort.DefaultCellStyle = dataGridViewCellStyle6;
            Mjukslang_OD_kort.HeaderText = "Mjukslang OD kort";
            Mjukslang_OD_kort.Name = "Mjukslang_OD_kort";
            Mjukslang_OD_kort.ReadOnly = true;
            Mjukslang_OD_kort.Resizable = DataGridViewTriState.False;
            Mjukslang_OD_kort.Width = 51;
            // 
            // Mjukslang_OD_lång
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Mjukslang_OD_lång.DefaultCellStyle = dataGridViewCellStyle7;
            Mjukslang_OD_lång.HeaderText = "Mjukslang OD lång";
            Mjukslang_OD_lång.Name = "Mjukslang_OD_lång";
            Mjukslang_OD_lång.ReadOnly = true;
            Mjukslang_OD_lång.Resizable = DataGridViewTriState.False;
            Mjukslang_OD_lång.Width = 51;
            // 
            // SkärmadSlang_ID
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle8.ForeColor = Color.Gray;
            SkärmadSlang_ID.DefaultCellStyle = dataGridViewCellStyle8;
            SkärmadSlang_ID.HeaderText = "Skärmat ID";
            SkärmadSlang_ID.Name = "SkärmadSlang_ID";
            SkärmadSlang_ID.ReadOnly = true;
            SkärmadSlang_ID.Resizable = DataGridViewTriState.False;
            SkärmadSlang_ID.Width = 51;
            // 
            // SkärmadSlang_OD
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle9.ForeColor = Color.Gray;
            SkärmadSlang_OD.DefaultCellStyle = dataGridViewCellStyle9;
            SkärmadSlang_OD.HeaderText = "Skärmat OD";
            SkärmadSlang_OD.Name = "SkärmadSlang_OD";
            SkärmadSlang_OD.ReadOnly = true;
            SkärmadSlang_OD.Resizable = DataGridViewTriState.False;
            SkärmadSlang_OD.Width = 51;
            // 
            // SkärmadSlang_Längd
            // 
            dataGridViewCellStyle10.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle10.ForeColor = Color.Gray;
            SkärmadSlang_Längd.DefaultCellStyle = dataGridViewCellStyle10;
            SkärmadSlang_Längd.HeaderText = "Skärmat Längd";
            SkärmadSlang_Längd.Name = "SkärmadSlang_Längd";
            SkärmadSlang_Längd.ReadOnly = true;
            SkärmadSlang_Längd.Resizable = DataGridViewTriState.False;
            SkärmadSlang_Längd.Width = 58;
            // 
            // Antal_Godkända
            // 
            dataGridViewCellStyle11.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle11.ForeColor = Color.Gray;
            Antal_Godkända.DefaultCellStyle = dataGridViewCellStyle11;
            Antal_Godkända.HeaderText = "Antal Godkända";
            Antal_Godkända.Name = "Antal_Godkända";
            Antal_Godkända.ReadOnly = true;
            Antal_Godkända.Resizable = DataGridViewTriState.False;
            Antal_Godkända.Width = 68;
            // 
            // Lev_Påse
            // 
            dataGridViewCellStyle12.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle12.ForeColor = Color.Gray;
            Lev_Påse.DefaultCellStyle = dataGridViewCellStyle12;
            Lev_Påse.HeaderText = "Lev Påse";
            Lev_Påse.Name = "Lev_Påse";
            Lev_Påse.ReadOnly = true;
            Lev_Påse.Width = 62;
            // 
            // DragProvAntal
            // 
            dataGridViewCellStyle13.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle13.ForeColor = Color.Gray;
            DragProvAntal.DefaultCellStyle = dataGridViewCellStyle13;
            DragProvAntal.HeaderText = "Dragprov Antal";
            DragProvAntal.Name = "DragProvAntal";
            DragProvAntal.ReadOnly = true;
            DragProvAntal.Width = 58;
            // 
            // Hållfasthet_Newton_kort
            // 
            dataGridViewCellStyle14.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle14.ForeColor = Color.Gray;
            Hållfasthet_Newton_kort.DefaultCellStyle = dataGridViewCellStyle14;
            Hållfasthet_Newton_kort.HeaderText = "Hållfasthet Newton kort";
            Hållfasthet_Newton_kort.Name = "Hållfasthet_Newton_kort";
            Hållfasthet_Newton_kort.ReadOnly = true;
            Hållfasthet_Newton_kort.Width = 49;
            // 
            // Hållfasthet_Newton_lång
            // 
            dataGridViewCellStyle15.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle15.ForeColor = Color.Gray;
            Hållfasthet_Newton_lång.DefaultCellStyle = dataGridViewCellStyle15;
            Hållfasthet_Newton_lång.HeaderText = "Hållfasthet Newton lång";
            Hållfasthet_Newton_lång.Name = "Hållfasthet_Newton_lång";
            Hållfasthet_Newton_lång.ReadOnly = true;
            Hållfasthet_Newton_lång.Width = 49;
            // 
            // Hållfasthet_Procent_kort
            // 
            dataGridViewCellStyle16.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle16.ForeColor = Color.Gray;
            Hållfasthet_Procent_kort.DefaultCellStyle = dataGridViewCellStyle16;
            Hållfasthet_Procent_kort.HeaderText = "Hållfasthet Procent kort";
            Hållfasthet_Procent_kort.Name = "Hållfasthet_Procent_kort";
            Hållfasthet_Procent_kort.ReadOnly = true;
            Hållfasthet_Procent_kort.Width = 49;
            // 
            // Hållfasthet_Procent_lång
            // 
            dataGridViewCellStyle17.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle17.ForeColor = Color.Gray;
            Hållfasthet_Procent_lång.DefaultCellStyle = dataGridViewCellStyle17;
            Hållfasthet_Procent_lång.HeaderText = "Hållfasthet Procent lång";
            Hållfasthet_Procent_lång.Name = "Hållfasthet_Procent_lång";
            Hållfasthet_Procent_lång.ReadOnly = true;
            Hållfasthet_Procent_lång.Width = 49;
            // 
            // Provantal_QC
            // 
            dataGridViewCellStyle18.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle18.ForeColor = Color.Gray;
            Provantal_QC.DefaultCellStyle = dataGridViewCellStyle18;
            Provantal_QC.HeaderText = "Provantal QC";
            Provantal_QC.Name = "Provantal_QC";
            Provantal_QC.ReadOnly = true;
            Provantal_QC.Width = 52;
            // 
            // Date
            // 
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle19.ForeColor = Color.Gray;
            Date.DefaultCellStyle = dataGridViewCellStyle19;
            Date.HeaderText = "Datum";
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Resizable = DataGridViewTriState.False;
            Date.Width = 161;
            // 
            // AnstNr
            // 
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle20.ForeColor = Color.Gray;
            AnstNr.DefaultCellStyle = dataGridViewCellStyle20;
            AnstNr.HeaderText = "AnstNr";
            AnstNr.Name = "AnstNr";
            AnstNr.ReadOnly = true;
            AnstNr.Resizable = DataGridViewTriState.False;
            AnstNr.Width = 47;
            // 
            // Sign
            // 
            Sign.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle21.ForeColor = Color.Gray;
            Sign.DefaultCellStyle = dataGridViewCellStyle21;
            Sign.HeaderText = "Sign";
            Sign.Name = "Sign";
            Sign.ReadOnly = true;
            Sign.Resizable = DataGridViewTriState.False;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            // 
            // ExactDate
            // 
            ExactDate.HeaderText = "ExactDate";
            ExactDate.Name = "ExactDate";
            ExactDate.ReadOnly = true;
            ExactDate.Visible = false;
            // 
            // Discarded
            // 
            Discarded.HeaderText = "Discarded";
            Discarded.Name = "Discarded";
            Discarded.ReadOnly = true;
            Discarded.Visible = false;
            // 
            // Produktion_Slipning_TEF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Produktion_Slipning_TEF";
            Size = new Size(1217, 487);
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ((ISupportInitialize)dgv_Produktion).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private Label label_Produktion_Slipning;
        private Label label_Empty_5;
        private Label label_Inledande;
        private Label label_Mjukslang;
        private Label label_Skärmad_Slang;
        private Label label_Godkänd;
        private Label label_Inledande_Skärmat;
        private Label label_Mjukslang_Uppmätt;
        private Label label_SkärmadSlang_Uppmätt;
        private Label label_Totalalängd_unit;
        private Label label_Godkända_Antal_Godkända;
        private Label label_Godkända_PåseNr;
        private Label label_Godkända_Dragprov_Antal;
        private Label label_Godkända_Hållfasthet;
        private Label label_Hållfasthet_enhet;
        private Label label_Hållfasthet_Procent;
        private Label label_Hållfasthet_1_kort;
        private Label label_Hållfasthet_1_lång;
        private Label label_Hållfasthet_2_kort;
        private Label label_Hållfasthet_2_lång;
        private Label label_Godkända_ProvAntal_QC;
        private Label label_Inspektion_Datum;
        private Label label_Inspektion_AnstNr;
        private Label label_Inspektion_Sign;
        private Label label_Inledande_LotNr;
        private Label label_Inledande_Påse_Nr;
        private Label label_Mjukslang_ID;
        private Label label_Mjukslang_OD;
        private Label label_ODmm_kort;
        private Label label_ODmm_lång;
        private Label label_SkärmadSlang_ID;
        private Label label_SkärmadSlang_OD;
        private TextBox tb_Inledande_Påse;
        private TextBox tb_Mjukslang_ID;
        private TextBox tb_Mjukslang_OD_kort;
        private TextBox tb_SkärmadSlang_OD;
        private TextBox tb_SkärmadSlang_ID;
        private TextBox tb_SkärmadSlang_Längd;
        private TextBox tb_Antal_Godkända;
        private TextBox tb_Dragprov_Antal;
        private TextBox tb_Hållfasthet_Newton_kort;
        private TextBox tb_Lev_Påse;
        private TextBox tb_Hållfasthet_Procent_kort;
        private TextBox tb_ProvAntal_QC;
        private TextBox tb_Mjukslang_OD_lång;
        private TextBox tb_Hållfasthet_Newton_lång;
        private TextBox tb_Hållfasthet_Procent_lång;
        private Label label_Empty_6;
        private DataGridView dgv_Produktion;
        private TextBox tb_Inledande_LotNr;
        public Label lbl_Transfer_Produktion;
        public TableLayoutPanel tlp_Main;
        public Label lbl_Edit_Row_Produktion;
        public Label lbl_Kassera_Produktion;
        private DataGridViewTextBoxColumn OrderNr;
        private DataGridViewTextBoxColumn Påse_Nr;
        private DataGridViewTextBoxColumn Mjukslang_ID;
        private DataGridViewTextBoxColumn Mjukslang_OD_kort;
        private DataGridViewTextBoxColumn Mjukslang_OD_lång;
        private DataGridViewTextBoxColumn SkärmadSlang_ID;
        private DataGridViewTextBoxColumn SkärmadSlang_OD;
        private DataGridViewTextBoxColumn SkärmadSlang_Längd;
        private DataGridViewTextBoxColumn Antal_Godkända;
        private DataGridViewTextBoxColumn Lev_Påse;
        private DataGridViewTextBoxColumn DragProvAntal;
        private DataGridViewTextBoxColumn Hållfasthet_Newton_kort;
        private DataGridViewTextBoxColumn Hållfasthet_Newton_lång;
        private DataGridViewTextBoxColumn Hållfasthet_Procent_kort;
        private DataGridViewTextBoxColumn Hållfasthet_Procent_lång;
        private DataGridViewTextBoxColumn Provantal_QC;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn AnstNr;
        private DataGridViewTextBoxColumn Sign;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ExactDate;
        private DataGridViewCheckBoxColumn Discarded;
    }
}
