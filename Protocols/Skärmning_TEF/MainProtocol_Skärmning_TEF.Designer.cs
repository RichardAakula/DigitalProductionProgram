using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.Övrigt;

namespace DigitalProductionProgram.Protocols.Skärmning_TEF
{
    partial class MainProtocol_Skärmning_TEF
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
            tlp_Main = new TableLayoutPanel();
            PreFab = new DigitalProductionProgram.Protocols.ExtraProtocols.PreFab();
            lbl_Kassera_Maskinparameter = new Label();
            tlp_Maskinparametrar = new TableLayoutPanel();
            label_Empty_11 = new Label();
            lbl_Antal_Trådar_nom = new Label();
            label_Produktion_Skärmning = new Label();
            label_Empty_9 = new Label();
            label_Empty_6 = new Label();
            label_Empty_5 = new Label();
            label_Empty_3 = new Label();
            label_Empty_2 = new Label();
            lbl_Pot_Maskin_Hastighet_nom = new Label();
            label_Empty_1 = new Label();
            Maskin_Hastighet_pot = new TextBox();
            lbl_PPI_nom = new Label();
            lbl_CarrierFjäder_nom = new Label();
            label_MAX = new Label();
            label_NOM = new Label();
            Tråd_Antal = new TextBox();
            label_MIN = new Label();
            label_ODs_enhet = new Label();
            label_Arbetsblad = new Label();
            label_Helix_Vinkel = new Label();
            label_Matarhjul_Vinkel = new Label();
            label_MatarHjul_Hastighet = new Label();
            label_Slipmaskin = new Label();
            label_Empty_4 = new Label();
            label_Empty_7 = new Label();
            label_Empty_8 = new Label();
            Travers_Hastighet_pot = new TextBox();
            Carrier_fjäder = new TextBox();
            PPI = new TextBox();
            OD_oinsmält = new TextBox();
            label_Empty_10 = new Label();
            label_Antal_trådar = new Label();
            label_Maskinparametrar = new Label();
            tlp_ProduktInformation = new TableLayoutPanel();
            lbl_Benämning = new Label();
            label_Benämning = new Label();
            lbl_OrderNr = new Label();
            lbl_ArtikelNr = new Label();
            label_Kund = new Label();
            label_ArtikelNr = new Label();
            label_Datum = new Label();
            label_OrderNr = new Label();
            lbl_Customer = new Label();
            Date_Start = new Label();
            label_Namn = new Label();
            Name_Start = new Label();
            label_Produktinformation = new Label();
            tab_ctrl_Arbetskort = new TabControl();
            tlp_Produktion = new TableLayoutPanel();
            label_Produktion_Sign = new Label();
            label_Produktion_Tid = new Label();
            lbl_Transfer_Produktion = new Label();
            lbl_Produktion_Temp_nom = new Label();
            lbl_Produktion_Temp_max = new Label();
            lbl_Produktion_Temp_min = new Label();
            label_Empty_12 = new Label();
            label_Produktion_ID = new Label();
            label_Produktion_MAX = new Label();
            label_Produktion_NOM = new Label();
            lbl_VerktygsID_max = new Label();
            label_Produktion_MIN = new Label();
            lbl_VerktygsID_min = new Label();
            lbl_VerktygsID_nom = new Label();
            lbl_Add_Arbetskort = new Label();
            label_Produktion_Datum = new Label();
            label_Produktion_Mätare = new Label();
            label_Produktion_Temp_L1 = new Label();
            label_Produktion_Temp = new Label();
            label_Produktion_Temp_L2 = new Label();
            label_Produktion_ID_L1 = new Label();
            label_Produktion_ID_L2 = new Label();
            label_Produktion_OD1 = new Label();
            label_Produktion_OD1_L1 = new Label();
            label_VerktygsID_enhet = new Label();
            label_Produktion_OD1_L2 = new Label();
            label_Produktion_ODs = new Label();
            label_Bladhöjd = new Label();
            label_Produktion_ODs_L1 = new Label();
            tb_Verktygs_ID = new TextBox();
            label_Produktion_ODs_L2 = new Label();
            label_Produktion_Tråd_slut = new Label();
            label_Produktion_Tråd_av = new Label();
            label_Produktion_Trasig_carrier = new Label();
            label_Produktion_Skarv = new Label();
            label_Produktion_Spole_slut = new Label();
            label_Produktion_Avslut_linje = new Label();
            label_Produktion_Kommentar = new Label();
            lbl_Produktion_ID_min = new Label();
            lbl_Produktion_OD1_min = new Label();
            lbl_Produktion_ODs_min = new Label();
            lbl_Produktion_ID_nom = new Label();
            lbl_Produktion_OD1_nom = new Label();
            lbl_Produktion_ODs_nom = new Label();
            lbl_Produktion_ID_max = new Label();
            lbl_Produktion_OD1_max = new Label();
            lbl_Produktion_ODs_max = new Label();
            label_Empty_13 = new Label();
            tb_Produktion_Mätare = new TextBox();
            tb_Produktion_Temp_L1 = new TextBox();
            tb_Produktion_Temp_L2 = new TextBox();
            tb_Produktion_ID_L1 = new TextBox();
            tb_Produktion_ID_L2 = new TextBox();
            tb_Produktion_OD1_L1 = new TextBox();
            tb_Produktion_OD1_L2 = new TextBox();
            tb_Produktion_ODs_L1 = new TextBox();
            tb_Produktion_ODs_L2 = new TextBox();
            chb_Tråd_slut = new CheckBox();
            chb_Tråd_av = new CheckBox();
            chb_Trasig_carrier = new CheckBox();
            chb_Skarv = new CheckBox();
            chb_Spole_slut = new CheckBox();
            chb_Avslut_linje = new CheckBox();
            tb_Produktion_Kommentar = new TextBox();
            label_Produktion_AnstNr = new Label();
            label_Empty_14 = new Label();
            chb_Avrapporterat = new CheckBox();
            label_Produktion_Avrapporterat = new Label();
            tlp_Main.SuspendLayout();
            tlp_Maskinparametrar.SuspendLayout();
            tlp_ProduktInformation.SuspendLayout();
            tlp_Produktion.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.FromArgb(45, 45, 45);
            tlp_Main.ColumnCount = 3;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1222F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tlp_Main.Controls.Add(PreFab, 0, 2);
            tlp_Main.Controls.Add(lbl_Kassera_Maskinparameter, 0, 7);
            tlp_Main.Controls.Add(tlp_Maskinparametrar, 0, 3);
            tlp_Main.Controls.Add(label_Maskinparametrar, 0, 3);
            tlp_Main.Controls.Add(tlp_ProduktInformation, 0, 1);
            tlp_Main.Controls.Add(label_Produktinformation, 0, 0);
            tlp_Main.Controls.Add(tab_ctrl_Arbetskort, 1, 7);
            tlp_Main.Controls.Add(tlp_Produktion, 0, 4);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(1);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 8;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 208F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 148F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 265F));
            tlp_Main.Size = new Size(1458, 1032);
            tlp_Main.TabIndex = 1;
            // 
            // PreFab
            // 
            tlp_Main.SetColumnSpan(PreFab, 3);
            PreFab.Dock = DockStyle.Fill;
            PreFab.Location = new Point(3, 82);
            PreFab.Margin = new Padding(3, 0, 0, 0);
            PreFab.Name = "PreFab";
            PreFab.Size = new Size(1455, 130);
            PreFab.TabIndex = 1036;
            // 
            // lbl_Kassera_Maskinparameter
            // 
            lbl_Kassera_Maskinparameter.BackColor = Color.FromArgb(255, 199, 206);
            lbl_Kassera_Maskinparameter.Cursor = Cursors.Hand;
            lbl_Kassera_Maskinparameter.Dock = DockStyle.Top;
            lbl_Kassera_Maskinparameter.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Kassera_Maskinparameter.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_Kassera_Maskinparameter.Location = new Point(4, 607);
            lbl_Kassera_Maskinparameter.Margin = new Padding(4, 5, 0, 0);
            lbl_Kassera_Maskinparameter.Name = "lbl_Kassera_Maskinparameter";
            lbl_Kassera_Maskinparameter.Size = new Size(36, 24);
            lbl_Kassera_Maskinparameter.TabIndex = 1032;
            lbl_Kassera_Maskinparameter.Text = "→";
            lbl_Kassera_Maskinparameter.TextAlign = ContentAlignment.TopCenter;
            lbl_Kassera_Maskinparameter.Click += Kassera_Rad_Produktion_Click;
            // 
            // tlp_Maskinparametrar
            // 
            tlp_Maskinparametrar.BackColor = Color.FromArgb(45, 45, 45);
            tlp_Maskinparametrar.ColumnCount = 12;
            tlp_Main.SetColumnSpan(tlp_Maskinparametrar, 3);
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 54F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 83F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 81F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 166F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 71F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 528F));
            tlp_Maskinparametrar.Controls.Add(label_Empty_11, 0, 7);
            tlp_Maskinparametrar.Controls.Add(lbl_Antal_Trådar_nom, 1, 5);
            tlp_Maskinparametrar.Controls.Add(label_Produktion_Skärmning, 0, 8);
            tlp_Maskinparametrar.Controls.Add(label_Empty_9, 6, 4);
            tlp_Maskinparametrar.Controls.Add(label_Empty_6, 4, 6);
            tlp_Maskinparametrar.Controls.Add(label_Empty_5, 4, 4);
            tlp_Maskinparametrar.Controls.Add(label_Empty_3, 1, 6);
            tlp_Maskinparametrar.Controls.Add(label_Empty_2, 1, 4);
            tlp_Maskinparametrar.Controls.Add(lbl_Pot_Maskin_Hastighet_nom, 2, 5);
            tlp_Maskinparametrar.Controls.Add(label_Empty_1, 0, 0);
            tlp_Maskinparametrar.Controls.Add(Maskin_Hastighet_pot, 2, 7);
            tlp_Maskinparametrar.Controls.Add(lbl_PPI_nom, 5, 5);
            tlp_Maskinparametrar.Controls.Add(lbl_CarrierFjäder_nom, 4, 5);
            tlp_Maskinparametrar.Controls.Add(label_MAX, 0, 6);
            tlp_Maskinparametrar.Controls.Add(label_NOM, 0, 5);
            tlp_Maskinparametrar.Controls.Add(Tråd_Antal, 1, 7);
            tlp_Maskinparametrar.Controls.Add(label_MIN, 0, 4);
            tlp_Maskinparametrar.Controls.Add(label_ODs_enhet, 6, 3);
            tlp_Maskinparametrar.Controls.Add(label_Arbetsblad, 6, 0);
            tlp_Maskinparametrar.Controls.Add(label_Helix_Vinkel, 5, 0);
            tlp_Maskinparametrar.Controls.Add(label_Matarhjul_Vinkel, 4, 0);
            tlp_Maskinparametrar.Controls.Add(label_MatarHjul_Hastighet, 3, 0);
            tlp_Maskinparametrar.Controls.Add(label_Slipmaskin, 2, 0);
            tlp_Maskinparametrar.Controls.Add(label_Empty_4, 3, 4);
            tlp_Maskinparametrar.Controls.Add(label_Empty_7, 5, 4);
            tlp_Maskinparametrar.Controls.Add(label_Empty_8, 5, 6);
            tlp_Maskinparametrar.Controls.Add(Travers_Hastighet_pot, 3, 7);
            tlp_Maskinparametrar.Controls.Add(Carrier_fjäder, 4, 7);
            tlp_Maskinparametrar.Controls.Add(PPI, 5, 7);
            tlp_Maskinparametrar.Controls.Add(OD_oinsmält, 6, 7);
            tlp_Maskinparametrar.Controls.Add(label_Empty_10, 7, 0);
            tlp_Maskinparametrar.Controls.Add(label_Antal_trådar, 1, 0);
            tlp_Maskinparametrar.Dock = DockStyle.Fill;
            tlp_Maskinparametrar.Location = new Point(4, 240);
            tlp_Maskinparametrar.Margin = new Padding(4, 2, 4, 3);
            tlp_Maskinparametrar.Name = "tlp_Maskinparametrar";
            tlp_Maskinparametrar.RowCount = 9;
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 9F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Maskinparametrar.Size = new Size(1450, 203);
            tlp_Maskinparametrar.TabIndex = 1028;
            // 
            // label_Empty_11
            // 
            label_Empty_11.BackColor = Color.DarkGray;
            label_Empty_11.Cursor = Cursors.SizeAll;
            label_Empty_11.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_11.ForeColor = Color.ForestGreen;
            label_Empty_11.Location = new Point(1, 147);
            label_Empty_11.Margin = new Padding(1, 1, 0, 0);
            label_Empty_11.Name = "label_Empty_11";
            label_Empty_11.Size = new Size(41, 24);
            label_Empty_11.TabIndex = 1023;
            label_Empty_11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Antal_Trådar_nom
            // 
            lbl_Antal_Trådar_nom.AutoSize = true;
            lbl_Antal_Trådar_nom.BackColor = Color.Silver;
            lbl_Antal_Trådar_nom.Dock = DockStyle.Fill;
            lbl_Antal_Trådar_nom.Font = new Font("Consolas", 8.75F);
            lbl_Antal_Trådar_nom.ForeColor = Color.ForestGreen;
            lbl_Antal_Trådar_nom.Location = new Point(43, 100);
            lbl_Antal_Trådar_nom.Margin = new Padding(1, 0, 0, 1);
            lbl_Antal_Trådar_nom.Name = "lbl_Antal_Trådar_nom";
            lbl_Antal_Trådar_nom.Size = new Size(53, 22);
            lbl_Antal_Trådar_nom.TabIndex = 1022;
            lbl_Antal_Trådar_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Skärmning
            // 
            label_Produktion_Skärmning.BackColor = Color.LightGray;
            label_Produktion_Skärmning.BorderStyle = BorderStyle.FixedSingle;
            tlp_Maskinparametrar.SetColumnSpan(label_Produktion_Skärmning, 12);
            label_Produktion_Skärmning.Cursor = Cursors.SizeAll;
            label_Produktion_Skärmning.Dock = DockStyle.Fill;
            label_Produktion_Skärmning.Font = new Font("Palatino Linotype", 10.25F);
            label_Produktion_Skärmning.ForeColor = Color.SaddleBrown;
            label_Produktion_Skärmning.Location = new Point(0, 173);
            label_Produktion_Skärmning.Margin = new Padding(0, 2, 0, 0);
            label_Produktion_Skärmning.Name = "label_Produktion_Skärmning";
            label_Produktion_Skärmning.Size = new Size(1451, 30);
            label_Produktion_Skärmning.TabIndex = 1021;
            label_Produktion_Skärmning.Text = "Produktion/Skärmning";
            label_Produktion_Skärmning.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Empty_9
            // 
            label_Empty_9.BackColor = Color.DarkGray;
            label_Empty_9.Cursor = Cursors.SizeAll;
            label_Empty_9.Dock = DockStyle.Fill;
            label_Empty_9.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_9.ForeColor = Color.ForestGreen;
            label_Empty_9.Location = new Point(423, 77);
            label_Empty_9.Margin = new Padding(0, 0, 0, 1);
            label_Empty_9.Name = "label_Empty_9";
            tlp_Maskinparametrar.SetRowSpan(label_Empty_9, 3);
            label_Empty_9.Size = new Size(81, 68);
            label_Empty_9.TabIndex = 1020;
            label_Empty_9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_6
            // 
            label_Empty_6.BackColor = Color.DarkGray;
            label_Empty_6.Cursor = Cursors.SizeAll;
            label_Empty_6.Dock = DockStyle.Fill;
            label_Empty_6.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_6.ForeColor = Color.ForestGreen;
            label_Empty_6.Location = new Point(256, 123);
            label_Empty_6.Margin = new Padding(0, 0, 0, 1);
            label_Empty_6.Name = "label_Empty_6";
            label_Empty_6.Size = new Size(84, 22);
            label_Empty_6.TabIndex = 1019;
            label_Empty_6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_5
            // 
            label_Empty_5.BackColor = Color.DarkGray;
            label_Empty_5.Cursor = Cursors.SizeAll;
            label_Empty_5.Dock = DockStyle.Fill;
            label_Empty_5.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_5.ForeColor = Color.ForestGreen;
            label_Empty_5.Location = new Point(256, 77);
            label_Empty_5.Margin = new Padding(0, 0, 0, 1);
            label_Empty_5.Name = "label_Empty_5";
            label_Empty_5.Size = new Size(84, 22);
            label_Empty_5.TabIndex = 1018;
            label_Empty_5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_3
            // 
            label_Empty_3.BackColor = Color.DarkGray;
            tlp_Maskinparametrar.SetColumnSpan(label_Empty_3, 2);
            label_Empty_3.Cursor = Cursors.SizeAll;
            label_Empty_3.Dock = DockStyle.Fill;
            label_Empty_3.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_3.ForeColor = Color.ForestGreen;
            label_Empty_3.Location = new Point(43, 123);
            label_Empty_3.Margin = new Padding(1, 0, 0, 1);
            label_Empty_3.Name = "label_Empty_3";
            label_Empty_3.Size = new Size(128, 22);
            label_Empty_3.TabIndex = 1017;
            label_Empty_3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_2
            // 
            label_Empty_2.BackColor = Color.DarkGray;
            tlp_Maskinparametrar.SetColumnSpan(label_Empty_2, 2);
            label_Empty_2.Cursor = Cursors.SizeAll;
            label_Empty_2.Dock = DockStyle.Fill;
            label_Empty_2.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_2.ForeColor = Color.ForestGreen;
            label_Empty_2.Location = new Point(43, 77);
            label_Empty_2.Margin = new Padding(1, 0, 0, 1);
            label_Empty_2.Name = "label_Empty_2";
            label_Empty_2.Size = new Size(128, 22);
            label_Empty_2.TabIndex = 1015;
            label_Empty_2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Pot_Maskin_Hastighet_nom
            // 
            lbl_Pot_Maskin_Hastighet_nom.AutoSize = true;
            lbl_Pot_Maskin_Hastighet_nom.BackColor = Color.Silver;
            lbl_Pot_Maskin_Hastighet_nom.Dock = DockStyle.Fill;
            lbl_Pot_Maskin_Hastighet_nom.Font = new Font("Consolas", 8.75F);
            lbl_Pot_Maskin_Hastighet_nom.ForeColor = Color.ForestGreen;
            lbl_Pot_Maskin_Hastighet_nom.Location = new Point(97, 100);
            lbl_Pot_Maskin_Hastighet_nom.Margin = new Padding(1, 0, 1, 1);
            lbl_Pot_Maskin_Hastighet_nom.Name = "lbl_Pot_Maskin_Hastighet_nom";
            lbl_Pot_Maskin_Hastighet_nom.Size = new Size(73, 22);
            lbl_Pot_Maskin_Hastighet_nom.TabIndex = 1014;
            lbl_Pot_Maskin_Hastighet_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_1
            // 
            label_Empty_1.BackColor = Color.DarkGray;
            label_Empty_1.Cursor = Cursors.SizeAll;
            label_Empty_1.Dock = DockStyle.Fill;
            label_Empty_1.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_1.ForeColor = Color.ForestGreen;
            label_Empty_1.Location = new Point(1, 0);
            label_Empty_1.Margin = new Padding(1, 0, 0, 1);
            label_Empty_1.Name = "label_Empty_1";
            tlp_Maskinparametrar.SetRowSpan(label_Empty_1, 4);
            label_Empty_1.Size = new Size(41, 76);
            label_Empty_1.TabIndex = 1007;
            label_Empty_1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Maskin_Hastighet_pot
            // 
            Maskin_Hastighet_pot.BackColor = Color.White;
            Maskin_Hastighet_pot.BorderStyle = BorderStyle.None;
            Maskin_Hastighet_pot.Cursor = Cursors.IBeam;
            Maskin_Hastighet_pot.Dock = DockStyle.Fill;
            Maskin_Hastighet_pot.Font = new Font("Courier New", 8.5F);
            Maskin_Hastighet_pot.ForeColor = Color.DarkSlateGray;
            Maskin_Hastighet_pot.Location = new Point(97, 147);
            Maskin_Hastighet_pot.Margin = new Padding(1, 1, 0, 0);
            Maskin_Hastighet_pot.MaxLength = 4;
            Maskin_Hastighet_pot.Multiline = true;
            Maskin_Hastighet_pot.Name = "Maskin_Hastighet_pot";
            Maskin_Hastighet_pot.Size = new Size(74, 24);
            Maskin_Hastighet_pot.TabIndex = 1;
            Maskin_Hastighet_pot.TextAlign = HorizontalAlignment.Center;
            Maskin_Hastighet_pot.WordWrap = false;
            Maskin_Hastighet_pot.KeyPress += Int_Values_Only_KeyPress;
            Maskin_Hastighet_pot.Leave += Save_Korprotokoll_Leave;
            // 
            // lbl_PPI_nom
            // 
            lbl_PPI_nom.AutoSize = true;
            lbl_PPI_nom.BackColor = Color.Silver;
            lbl_PPI_nom.Dock = DockStyle.Fill;
            lbl_PPI_nom.Font = new Font("Consolas", 8.75F);
            lbl_PPI_nom.ForeColor = Color.ForestGreen;
            lbl_PPI_nom.Location = new Point(341, 100);
            lbl_PPI_nom.Margin = new Padding(1, 0, 1, 1);
            lbl_PPI_nom.Name = "lbl_PPI_nom";
            lbl_PPI_nom.Size = new Size(81, 22);
            lbl_PPI_nom.TabIndex = 986;
            lbl_PPI_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_CarrierFjäder_nom
            // 
            lbl_CarrierFjäder_nom.AutoSize = true;
            lbl_CarrierFjäder_nom.BackColor = Color.Silver;
            lbl_CarrierFjäder_nom.Dock = DockStyle.Fill;
            lbl_CarrierFjäder_nom.Font = new Font("Consolas", 8.75F);
            lbl_CarrierFjäder_nom.ForeColor = Color.ForestGreen;
            lbl_CarrierFjäder_nom.Location = new Point(257, 100);
            lbl_CarrierFjäder_nom.Margin = new Padding(1, 0, 0, 1);
            lbl_CarrierFjäder_nom.Name = "lbl_CarrierFjäder_nom";
            lbl_CarrierFjäder_nom.Size = new Size(83, 22);
            lbl_CarrierFjäder_nom.TabIndex = 985;
            lbl_CarrierFjäder_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_MAX
            // 
            label_MAX.BackColor = Color.Silver;
            label_MAX.Dock = DockStyle.Fill;
            label_MAX.Font = new Font("Palatino Linotype", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MAX.ForeColor = Color.DodgerBlue;
            label_MAX.Location = new Point(1, 123);
            label_MAX.Margin = new Padding(1, 0, 0, 1);
            label_MAX.Name = "label_MAX";
            label_MAX.Size = new Size(41, 22);
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
            label_NOM.Location = new Point(1, 100);
            label_NOM.Margin = new Padding(1, 0, 0, 1);
            label_NOM.Name = "label_NOM";
            label_NOM.Size = new Size(41, 22);
            label_NOM.TabIndex = 824;
            label_NOM.Text = "NOM";
            label_NOM.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Tråd_Antal
            // 
            Tråd_Antal.BorderStyle = BorderStyle.None;
            Tråd_Antal.Dock = DockStyle.Fill;
            Tråd_Antal.Font = new Font("Courier New", 8.5F);
            Tråd_Antal.ForeColor = Color.DarkSlateGray;
            Tråd_Antal.Location = new Point(43, 147);
            Tråd_Antal.Margin = new Padding(1, 1, 0, 0);
            Tråd_Antal.MaxLength = 6;
            Tråd_Antal.Multiline = true;
            Tråd_Antal.Name = "Tråd_Antal";
            Tråd_Antal.Size = new Size(53, 24);
            Tråd_Antal.TabIndex = 0;
            Tråd_Antal.TextAlign = HorizontalAlignment.Center;
            Tråd_Antal.Leave += Save_Korprotokoll_Leave;
            // 
            // label_MIN
            // 
            label_MIN.BackColor = Color.Silver;
            label_MIN.Dock = DockStyle.Fill;
            label_MIN.Font = new Font("Palatino Linotype", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MIN.ForeColor = Color.DodgerBlue;
            label_MIN.Location = new Point(1, 77);
            label_MIN.Margin = new Padding(1, 0, 0, 1);
            label_MIN.Name = "label_MIN";
            label_MIN.Size = new Size(41, 22);
            label_MIN.TabIndex = 819;
            label_MIN.Text = "MIN";
            label_MIN.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_ODs_enhet
            // 
            label_ODs_enhet.BackColor = Color.White;
            label_ODs_enhet.Dock = DockStyle.Fill;
            label_ODs_enhet.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_ODs_enhet.ForeColor = Color.Black;
            label_ODs_enhet.Location = new Point(424, 61);
            label_ODs_enhet.Margin = new Padding(1, 0, 1, 1);
            label_ODs_enhet.Name = "label_ODs_enhet";
            label_ODs_enhet.Size = new Size(79, 15);
            label_ODs_enhet.TabIndex = 818;
            label_ODs_enhet.Text = "mm";
            label_ODs_enhet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Arbetsblad
            // 
            label_Arbetsblad.BackColor = Color.White;
            label_Arbetsblad.Dock = DockStyle.Fill;
            label_Arbetsblad.Font = new Font("Arial", 8.55F);
            label_Arbetsblad.ForeColor = Color.Black;
            label_Arbetsblad.Location = new Point(424, 0);
            label_Arbetsblad.Margin = new Padding(1, 0, 1, 0);
            label_Arbetsblad.Name = "label_Arbetsblad";
            tlp_Maskinparametrar.SetRowSpan(label_Arbetsblad, 3);
            label_Arbetsblad.Size = new Size(79, 61);
            label_Arbetsblad.TabIndex = 137;
            label_Arbetsblad.Text = "ODs oinsmält";
            label_Arbetsblad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Helix_Vinkel
            // 
            label_Helix_Vinkel.BackColor = Color.White;
            label_Helix_Vinkel.Dock = DockStyle.Fill;
            label_Helix_Vinkel.Font = new Font("Arial", 8.55F);
            label_Helix_Vinkel.ForeColor = Color.Black;
            label_Helix_Vinkel.Location = new Point(341, 0);
            label_Helix_Vinkel.Margin = new Padding(1, 0, 0, 1);
            label_Helix_Vinkel.Name = "label_Helix_Vinkel";
            tlp_Maskinparametrar.SetRowSpan(label_Helix_Vinkel, 4);
            label_Helix_Vinkel.Size = new Size(82, 76);
            label_Helix_Vinkel.TabIndex = 134;
            label_Helix_Vinkel.Text = "PPI";
            label_Helix_Vinkel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Matarhjul_Vinkel
            // 
            label_Matarhjul_Vinkel.BackColor = Color.White;
            label_Matarhjul_Vinkel.Dock = DockStyle.Fill;
            label_Matarhjul_Vinkel.Font = new Font("Arial", 8.55F);
            label_Matarhjul_Vinkel.ForeColor = Color.Black;
            label_Matarhjul_Vinkel.Location = new Point(257, 0);
            label_Matarhjul_Vinkel.Margin = new Padding(1, 0, 0, 1);
            label_Matarhjul_Vinkel.Name = "label_Matarhjul_Vinkel";
            tlp_Maskinparametrar.SetRowSpan(label_Matarhjul_Vinkel, 4);
            label_Matarhjul_Vinkel.Size = new Size(83, 76);
            label_Matarhjul_Vinkel.TabIndex = 133;
            label_Matarhjul_Vinkel.Text = "Carrier fjäder";
            label_Matarhjul_Vinkel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_MatarHjul_Hastighet
            // 
            label_MatarHjul_Hastighet.BackColor = Color.White;
            label_MatarHjul_Hastighet.Dock = DockStyle.Fill;
            label_MatarHjul_Hastighet.Font = new Font("Arial", 8.55F);
            label_MatarHjul_Hastighet.ForeColor = Color.Black;
            label_MatarHjul_Hastighet.Location = new Point(172, 0);
            label_MatarHjul_Hastighet.Margin = new Padding(1, 0, 0, 1);
            label_MatarHjul_Hastighet.Name = "label_MatarHjul_Hastighet";
            label_MatarHjul_Hastighet.Padding = new Padding(1, 0, 1, 0);
            tlp_Maskinparametrar.SetRowSpan(label_MatarHjul_Hastighet, 4);
            label_MatarHjul_Hastighet.Size = new Size(84, 76);
            label_MatarHjul_Hastighet.TabIndex = 131;
            label_MatarHjul_Hastighet.Text = "Pot. Travers Hastighet";
            label_MatarHjul_Hastighet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Slipmaskin
            // 
            label_Slipmaskin.BackColor = Color.White;
            label_Slipmaskin.Dock = DockStyle.Fill;
            label_Slipmaskin.Font = new Font("Arial", 8.55F);
            label_Slipmaskin.ForeColor = Color.Black;
            label_Slipmaskin.Location = new Point(97, 0);
            label_Slipmaskin.Margin = new Padding(1, 0, 0, 1);
            label_Slipmaskin.Name = "label_Slipmaskin";
            tlp_Maskinparametrar.SetRowSpan(label_Slipmaskin, 4);
            label_Slipmaskin.Size = new Size(74, 76);
            label_Slipmaskin.TabIndex = 130;
            label_Slipmaskin.Text = "Pot. Maskin Hastighet";
            label_Slipmaskin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_4
            // 
            label_Empty_4.BackColor = Color.DarkGray;
            label_Empty_4.Cursor = Cursors.SizeAll;
            label_Empty_4.Dock = DockStyle.Fill;
            label_Empty_4.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_4.ForeColor = Color.ForestGreen;
            label_Empty_4.Location = new Point(171, 77);
            label_Empty_4.Margin = new Padding(0, 0, 0, 1);
            label_Empty_4.Name = "label_Empty_4";
            tlp_Maskinparametrar.SetRowSpan(label_Empty_4, 3);
            label_Empty_4.Size = new Size(85, 68);
            label_Empty_4.TabIndex = 1007;
            label_Empty_4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_7
            // 
            label_Empty_7.BackColor = Color.DarkGray;
            label_Empty_7.Cursor = Cursors.SizeAll;
            label_Empty_7.Dock = DockStyle.Fill;
            label_Empty_7.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_7.ForeColor = Color.ForestGreen;
            label_Empty_7.Location = new Point(340, 77);
            label_Empty_7.Margin = new Padding(0, 0, 0, 1);
            label_Empty_7.Name = "label_Empty_7";
            label_Empty_7.Size = new Size(83, 22);
            label_Empty_7.TabIndex = 1007;
            label_Empty_7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_8
            // 
            label_Empty_8.BackColor = Color.DarkGray;
            label_Empty_8.Cursor = Cursors.SizeAll;
            label_Empty_8.Dock = DockStyle.Fill;
            label_Empty_8.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_8.ForeColor = Color.ForestGreen;
            label_Empty_8.Location = new Point(340, 123);
            label_Empty_8.Margin = new Padding(0, 0, 0, 1);
            label_Empty_8.Name = "label_Empty_8";
            label_Empty_8.Size = new Size(83, 22);
            label_Empty_8.TabIndex = 1008;
            label_Empty_8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Travers_Hastighet_pot
            // 
            Travers_Hastighet_pot.BackColor = Color.White;
            Travers_Hastighet_pot.BorderStyle = BorderStyle.None;
            Travers_Hastighet_pot.Cursor = Cursors.IBeam;
            Travers_Hastighet_pot.Dock = DockStyle.Fill;
            Travers_Hastighet_pot.Font = new Font("Courier New", 8.5F);
            Travers_Hastighet_pot.ForeColor = Color.DarkSlateGray;
            Travers_Hastighet_pot.Location = new Point(172, 147);
            Travers_Hastighet_pot.Margin = new Padding(1, 1, 0, 0);
            Travers_Hastighet_pot.MaxLength = 5;
            Travers_Hastighet_pot.Multiline = true;
            Travers_Hastighet_pot.Name = "Travers_Hastighet_pot";
            Travers_Hastighet_pot.Size = new Size(84, 24);
            Travers_Hastighet_pot.TabIndex = 2;
            Travers_Hastighet_pot.TextAlign = HorizontalAlignment.Center;
            Travers_Hastighet_pot.WordWrap = false;
            Travers_Hastighet_pot.KeyPress += Int_Values_Only_KeyPress;
            Travers_Hastighet_pot.Leave += Save_Korprotokoll_Leave;
            // 
            // Carrier_fjäder
            // 
            Carrier_fjäder.BackColor = Color.White;
            Carrier_fjäder.BorderStyle = BorderStyle.None;
            Carrier_fjäder.Cursor = Cursors.IBeam;
            Carrier_fjäder.Dock = DockStyle.Fill;
            Carrier_fjäder.Font = new Font("Courier New", 8.5F);
            Carrier_fjäder.ForeColor = Color.DarkSlateGray;
            Carrier_fjäder.Location = new Point(257, 147);
            Carrier_fjäder.Margin = new Padding(1, 1, 0, 0);
            Carrier_fjäder.MaxLength = 6;
            Carrier_fjäder.Multiline = true;
            Carrier_fjäder.Name = "Carrier_fjäder";
            Carrier_fjäder.Size = new Size(83, 24);
            Carrier_fjäder.TabIndex = 3;
            Carrier_fjäder.TextAlign = HorizontalAlignment.Center;
            Carrier_fjäder.WordWrap = false;
            Carrier_fjäder.KeyPress += Double_Values_Onyl_KeyPress;
            Carrier_fjäder.Leave += Save_Korprotokoll_Leave;
            // 
            // PPI
            // 
            PPI.BackColor = Color.White;
            PPI.BorderStyle = BorderStyle.None;
            PPI.Cursor = Cursors.IBeam;
            PPI.Dock = DockStyle.Fill;
            PPI.Font = new Font("Courier New", 8.5F);
            PPI.ForeColor = Color.DarkSlateGray;
            PPI.Location = new Point(341, 147);
            PPI.Margin = new Padding(1, 1, 0, 0);
            PPI.MaxLength = 6;
            PPI.Multiline = true;
            PPI.Name = "PPI";
            PPI.Size = new Size(82, 24);
            PPI.TabIndex = 4;
            PPI.TextAlign = HorizontalAlignment.Center;
            PPI.WordWrap = false;
            PPI.Leave += Save_Korprotokoll_Leave;
            // 
            // OD_oinsmält
            // 
            OD_oinsmält.BackColor = Color.White;
            OD_oinsmält.BorderStyle = BorderStyle.None;
            OD_oinsmält.Cursor = Cursors.IBeam;
            OD_oinsmält.Dock = DockStyle.Fill;
            OD_oinsmält.Font = new Font("Courier New", 8.5F);
            OD_oinsmält.ForeColor = Color.DarkSlateGray;
            OD_oinsmält.Location = new Point(424, 147);
            OD_oinsmält.Margin = new Padding(1, 1, 1, 0);
            OD_oinsmält.MaxLength = 6;
            OD_oinsmält.Multiline = true;
            OD_oinsmält.Name = "OD_oinsmält";
            OD_oinsmält.Size = new Size(79, 24);
            OD_oinsmält.TabIndex = 5;
            OD_oinsmält.TextAlign = HorizontalAlignment.Center;
            OD_oinsmält.WordWrap = false;
            OD_oinsmält.KeyPress += Double_Values_Onyl_KeyPress;
            OD_oinsmält.Leave += Save_Korprotokoll_Leave;
            // 
            // label_Empty_10
            // 
            label_Empty_10.BackColor = Color.DarkGray;
            tlp_Maskinparametrar.SetColumnSpan(label_Empty_10, 5);
            label_Empty_10.Cursor = Cursors.SizeAll;
            label_Empty_10.Dock = DockStyle.Fill;
            label_Empty_10.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_10.ForeColor = Color.ForestGreen;
            label_Empty_10.Location = new Point(504, 0);
            label_Empty_10.Margin = new Padding(0, 0, 1, 0);
            label_Empty_10.Name = "label_Empty_10";
            tlp_Maskinparametrar.SetRowSpan(label_Empty_10, 8);
            label_Empty_10.Size = new Size(946, 171);
            label_Empty_10.TabIndex = 1020;
            label_Empty_10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Antal_trådar
            // 
            label_Antal_trådar.BackColor = Color.White;
            label_Antal_trådar.Dock = DockStyle.Fill;
            label_Antal_trådar.Font = new Font("Arial", 8.55F);
            label_Antal_trådar.ForeColor = Color.Black;
            label_Antal_trådar.Location = new Point(43, 0);
            label_Antal_trådar.Margin = new Padding(1, 0, 0, 1);
            label_Antal_trådar.Name = "label_Antal_trådar";
            tlp_Maskinparametrar.SetRowSpan(label_Antal_trådar, 4);
            label_Antal_trådar.Size = new Size(53, 76);
            label_Antal_trådar.TabIndex = 130;
            label_Antal_trådar.Text = "Antal Trådar";
            label_Antal_trådar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Maskinparametrar
            // 
            label_Maskinparametrar.BackColor = Color.LightGray;
            label_Maskinparametrar.BorderStyle = BorderStyle.FixedSingle;
            tlp_Main.SetColumnSpan(label_Maskinparametrar, 4);
            label_Maskinparametrar.Cursor = Cursors.SizeAll;
            label_Maskinparametrar.Dock = DockStyle.Fill;
            label_Maskinparametrar.Font = new Font("Palatino Linotype", 10.25F);
            label_Maskinparametrar.ForeColor = Color.SaddleBrown;
            label_Maskinparametrar.Location = new Point(2, 214);
            label_Maskinparametrar.Margin = new Padding(2, 2, 4, 0);
            label_Maskinparametrar.Name = "label_Maskinparametrar";
            label_Maskinparametrar.Size = new Size(1452, 24);
            label_Maskinparametrar.TabIndex = 1027;
            label_Maskinparametrar.Text = "Maskinparametrar";
            label_Maskinparametrar.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlp_ProduktInformation
            // 
            tlp_ProduktInformation.BackColor = Color.FromArgb(45, 45, 45);
            tlp_ProduktInformation.ColumnCount = 6;
            tlp_Main.SetColumnSpan(tlp_ProduktInformation, 3);
            tlp_ProduktInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            tlp_ProduktInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 518F));
            tlp_ProduktInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tlp_ProduktInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 326F));
            tlp_ProduktInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 113F));
            tlp_ProduktInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 288F));
            tlp_ProduktInformation.Controls.Add(lbl_Benämning, 1, 1);
            tlp_ProduktInformation.Controls.Add(label_Benämning, 0, 1);
            tlp_ProduktInformation.Controls.Add(lbl_OrderNr, 5, 0);
            tlp_ProduktInformation.Controls.Add(lbl_ArtikelNr, 5, 1);
            tlp_ProduktInformation.Controls.Add(label_Kund, 0, 0);
            tlp_ProduktInformation.Controls.Add(label_ArtikelNr, 4, 1);
            tlp_ProduktInformation.Controls.Add(label_Datum, 2, 0);
            tlp_ProduktInformation.Controls.Add(label_OrderNr, 4, 0);
            tlp_ProduktInformation.Controls.Add(lbl_Customer, 1, 0);
            tlp_ProduktInformation.Controls.Add(Date_Start, 3, 0);
            tlp_ProduktInformation.Controls.Add(label_Namn, 2, 1);
            tlp_ProduktInformation.Controls.Add(Name_Start, 3, 1);
            tlp_ProduktInformation.Dock = DockStyle.Fill;
            tlp_ProduktInformation.Location = new Point(4, 28);
            tlp_ProduktInformation.Margin = new Padding(4, 3, 4, 3);
            tlp_ProduktInformation.Name = "tlp_ProduktInformation";
            tlp_ProduktInformation.RowCount = 2;
            tlp_ProduktInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_ProduktInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_ProduktInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_ProduktInformation.Size = new Size(1450, 51);
            tlp_ProduktInformation.TabIndex = 1026;
            // 
            // lbl_Benämning
            // 
            lbl_Benämning.BackColor = Color.White;
            lbl_Benämning.Dock = DockStyle.Fill;
            lbl_Benämning.Font = new Font("Consolas", 8.5F);
            lbl_Benämning.ForeColor = Color.Gray;
            lbl_Benämning.Location = new Point(118, 23);
            lbl_Benämning.Margin = new Padding(1, 0, 0, 0);
            lbl_Benämning.Name = "lbl_Benämning";
            lbl_Benämning.Size = new Size(517, 28);
            lbl_Benämning.TabIndex = 916;
            lbl_Benämning.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Benämning
            // 
            label_Benämning.BackColor = Color.White;
            label_Benämning.Cursor = Cursors.SizeAll;
            label_Benämning.Dock = DockStyle.Fill;
            label_Benämning.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            label_Benämning.ForeColor = Color.Black;
            label_Benämning.Location = new Point(1, 23);
            label_Benämning.Margin = new Padding(1, 0, 0, 0);
            label_Benämning.Name = "label_Benämning";
            label_Benämning.Size = new Size(116, 28);
            label_Benämning.TabIndex = 915;
            label_Benämning.Text = "Benämning";
            label_Benämning.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderNr
            // 
            lbl_OrderNr.AutoSize = true;
            lbl_OrderNr.BackColor = Color.White;
            lbl_OrderNr.Dock = DockStyle.Fill;
            lbl_OrderNr.Font = new Font("Consolas", 8.5F);
            lbl_OrderNr.ForeColor = Color.Gray;
            lbl_OrderNr.Location = new Point(1165, 0);
            lbl_OrderNr.Margin = new Padding(1, 0, 1, 1);
            lbl_OrderNr.Name = "lbl_OrderNr";
            lbl_OrderNr.Size = new Size(286, 22);
            lbl_OrderNr.TabIndex = 135;
            lbl_OrderNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_ArtikelNr
            // 
            lbl_ArtikelNr.AutoSize = true;
            lbl_ArtikelNr.BackColor = Color.White;
            lbl_ArtikelNr.Dock = DockStyle.Fill;
            lbl_ArtikelNr.Font = new Font("Consolas", 8.5F);
            lbl_ArtikelNr.ForeColor = Color.Gray;
            lbl_ArtikelNr.Location = new Point(1165, 23);
            lbl_ArtikelNr.Margin = new Padding(1, 0, 1, 0);
            lbl_ArtikelNr.Name = "lbl_ArtikelNr";
            lbl_ArtikelNr.Size = new Size(286, 28);
            lbl_ArtikelNr.TabIndex = 134;
            lbl_ArtikelNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Kund
            // 
            label_Kund.BackColor = Color.White;
            label_Kund.Cursor = Cursors.SizeAll;
            label_Kund.Dock = DockStyle.Fill;
            label_Kund.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            label_Kund.ForeColor = Color.Black;
            label_Kund.Location = new Point(1, 0);
            label_Kund.Margin = new Padding(1, 0, 0, 1);
            label_Kund.Name = "label_Kund";
            label_Kund.Size = new Size(116, 22);
            label_Kund.TabIndex = 128;
            label_Kund.Text = "Kund";
            label_Kund.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_ArtikelNr
            // 
            label_ArtikelNr.BackColor = Color.White;
            label_ArtikelNr.Cursor = Cursors.SizeAll;
            label_ArtikelNr.Dock = DockStyle.Fill;
            label_ArtikelNr.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            label_ArtikelNr.ForeColor = Color.Black;
            label_ArtikelNr.Location = new Point(1052, 23);
            label_ArtikelNr.Margin = new Padding(1, 0, 0, 0);
            label_ArtikelNr.Name = "label_ArtikelNr";
            label_ArtikelNr.Size = new Size(112, 28);
            label_ArtikelNr.TabIndex = 130;
            label_ArtikelNr.Text = "ArtikelNr";
            label_ArtikelNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Datum
            // 
            label_Datum.BackColor = Color.White;
            label_Datum.Cursor = Cursors.SizeAll;
            label_Datum.Dock = DockStyle.Fill;
            label_Datum.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            label_Datum.ForeColor = Color.Black;
            label_Datum.Location = new Point(636, 0);
            label_Datum.Margin = new Padding(1, 0, 0, 1);
            label_Datum.Name = "label_Datum";
            label_Datum.Size = new Size(89, 22);
            label_Datum.TabIndex = 130;
            label_Datum.Text = "Datum";
            label_Datum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr
            // 
            label_OrderNr.BackColor = Color.White;
            label_OrderNr.Cursor = Cursors.SizeAll;
            label_OrderNr.Dock = DockStyle.Fill;
            label_OrderNr.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            label_OrderNr.ForeColor = Color.Black;
            label_OrderNr.Location = new Point(1052, 0);
            label_OrderNr.Margin = new Padding(1, 0, 0, 1);
            label_OrderNr.Name = "label_OrderNr";
            label_OrderNr.Size = new Size(112, 22);
            label_OrderNr.TabIndex = 130;
            label_OrderNr.Text = "OrderNr";
            label_OrderNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Customer
            // 
            lbl_Customer.AutoSize = true;
            lbl_Customer.BackColor = Color.White;
            lbl_Customer.Dock = DockStyle.Fill;
            lbl_Customer.Font = new Font("Consolas", 8.5F);
            lbl_Customer.ForeColor = Color.Gray;
            lbl_Customer.Location = new Point(118, 0);
            lbl_Customer.Margin = new Padding(1, 0, 0, 1);
            lbl_Customer.Name = "lbl_Customer";
            lbl_Customer.Size = new Size(517, 22);
            lbl_Customer.TabIndex = 132;
            // 
            // Date_Start
            // 
            Date_Start.BackColor = Color.White;
            Date_Start.Cursor = Cursors.Hand;
            Date_Start.Dock = DockStyle.Fill;
            Date_Start.Font = new Font("Courier New", 8.5F);
            Date_Start.ForeColor = Color.DarkSlateGray;
            Date_Start.Location = new Point(726, 0);
            Date_Start.Margin = new Padding(1, 0, 0, 1);
            Date_Start.Name = "Date_Start";
            Date_Start.Size = new Size(325, 22);
            Date_Start.TabIndex = 914;
            Date_Start.TextAlign = ContentAlignment.MiddleLeft;
            Date_Start.MouseDown += Date_MouseDown;
            // 
            // label_Namn
            // 
            label_Namn.BackColor = Color.White;
            label_Namn.Cursor = Cursors.SizeAll;
            label_Namn.Dock = DockStyle.Fill;
            label_Namn.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            label_Namn.ForeColor = Color.Black;
            label_Namn.Location = new Point(636, 23);
            label_Namn.Margin = new Padding(1, 0, 0, 0);
            label_Namn.Name = "label_Namn";
            label_Namn.Size = new Size(89, 28);
            label_Namn.TabIndex = 917;
            label_Namn.Text = "Namn";
            label_Namn.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Name_Start
            // 
            Name_Start.AutoSize = true;
            Name_Start.BackColor = Color.White;
            Name_Start.Cursor = Cursors.Hand;
            Name_Start.Dock = DockStyle.Fill;
            Name_Start.Font = new Font("Courier New", 8.25F);
            Name_Start.ForeColor = Color.DarkSlateGray;
            Name_Start.Location = new Point(726, 23);
            Name_Start.Margin = new Padding(1, 0, 0, 0);
            Name_Start.Name = "Name_Start";
            Name_Start.Size = new Size(325, 28);
            Name_Start.TabIndex = 1024;
            Name_Start.Click += Name_Click;
            // 
            // label_Produktinformation
            // 
            label_Produktinformation.BackColor = Color.LightGray;
            label_Produktinformation.BorderStyle = BorderStyle.FixedSingle;
            tlp_Main.SetColumnSpan(label_Produktinformation, 4);
            label_Produktinformation.Cursor = Cursors.SizeAll;
            label_Produktinformation.Dock = DockStyle.Fill;
            label_Produktinformation.Font = new Font("Palatino Linotype", 10.25F);
            label_Produktinformation.ForeColor = Color.SaddleBrown;
            label_Produktinformation.Location = new Point(0, 0);
            label_Produktinformation.Margin = new Padding(0);
            label_Produktinformation.Name = "label_Produktinformation";
            label_Produktinformation.Size = new Size(1458, 25);
            label_Produktinformation.TabIndex = 1025;
            label_Produktinformation.Text = "Produktinformation";
            label_Produktinformation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tab_ctrl_Arbetskort
            // 
            tlp_Main.SetColumnSpan(tab_ctrl_Arbetskort, 2);
            tab_ctrl_Arbetskort.Dock = DockStyle.Fill;
            tab_ctrl_Arbetskort.Location = new Point(42, 604);
            tab_ctrl_Arbetskort.Margin = new Padding(2, 2, 2, 0);
            tab_ctrl_Arbetskort.Name = "tab_ctrl_Arbetskort";
            tab_ctrl_Arbetskort.SelectedIndex = 0;
            tab_ctrl_Arbetskort.Size = new Size(1414, 428);
            tab_ctrl_Arbetskort.TabIndex = 1022;
            // 
            // tlp_Produktion
            // 
            tlp_Produktion.ColumnCount = 24;
            tlp_Main.SetColumnSpan(tlp_Produktion, 3);
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 21F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 54F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 57F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 61F));
            tlp_Produktion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 252F));
            tlp_Produktion.Controls.Add(label_Produktion_Sign, 23, 0);
            tlp_Produktion.Controls.Add(label_Produktion_Tid, 21, 0);
            tlp_Produktion.Controls.Add(lbl_Transfer_Produktion, 0, 5);
            tlp_Produktion.Controls.Add(lbl_Produktion_Temp_nom, 3, 3);
            tlp_Produktion.Controls.Add(lbl_Produktion_Temp_max, 3, 4);
            tlp_Produktion.Controls.Add(lbl_Produktion_Temp_min, 3, 2);
            tlp_Produktion.Controls.Add(label_Empty_12, 2, 2);
            tlp_Produktion.Controls.Add(label_Produktion_ID, 5, 0);
            tlp_Produktion.Controls.Add(label_Produktion_MAX, 0, 4);
            tlp_Produktion.Controls.Add(label_Produktion_NOM, 0, 3);
            tlp_Produktion.Controls.Add(lbl_VerktygsID_max, 11, 4);
            tlp_Produktion.Controls.Add(label_Produktion_MIN, 0, 2);
            tlp_Produktion.Controls.Add(lbl_VerktygsID_min, 11, 2);
            tlp_Produktion.Controls.Add(lbl_VerktygsID_nom, 11, 3);
            tlp_Produktion.Controls.Add(lbl_Add_Arbetskort, 0, 0);
            tlp_Produktion.Controls.Add(label_Produktion_Datum, 20, 0);
            tlp_Produktion.Controls.Add(label_Produktion_Mätare, 2, 0);
            tlp_Produktion.Controls.Add(label_Produktion_Temp_L1, 3, 1);
            tlp_Produktion.Controls.Add(label_Produktion_Temp, 3, 0);
            tlp_Produktion.Controls.Add(label_Produktion_Temp_L2, 4, 1);
            tlp_Produktion.Controls.Add(label_Produktion_ID_L1, 5, 1);
            tlp_Produktion.Controls.Add(label_Produktion_ID_L2, 6, 1);
            tlp_Produktion.Controls.Add(label_Produktion_OD1, 7, 0);
            tlp_Produktion.Controls.Add(label_Produktion_OD1_L1, 7, 1);
            tlp_Produktion.Controls.Add(label_VerktygsID_enhet, 11, 1);
            tlp_Produktion.Controls.Add(label_Produktion_OD1_L2, 8, 1);
            tlp_Produktion.Controls.Add(label_Produktion_ODs, 9, 0);
            tlp_Produktion.Controls.Add(label_Bladhöjd, 11, 0);
            tlp_Produktion.Controls.Add(label_Produktion_ODs_L1, 9, 1);
            tlp_Produktion.Controls.Add(tb_Verktygs_ID, 11, 5);
            tlp_Produktion.Controls.Add(label_Produktion_ODs_L2, 10, 1);
            tlp_Produktion.Controls.Add(label_Produktion_Tråd_slut, 12, 0);
            tlp_Produktion.Controls.Add(label_Produktion_Tråd_av, 13, 0);
            tlp_Produktion.Controls.Add(label_Produktion_Trasig_carrier, 14, 0);
            tlp_Produktion.Controls.Add(label_Produktion_Skarv, 15, 0);
            tlp_Produktion.Controls.Add(label_Produktion_Spole_slut, 16, 0);
            tlp_Produktion.Controls.Add(label_Produktion_Avslut_linje, 17, 0);
            tlp_Produktion.Controls.Add(label_Produktion_Kommentar, 19, 0);
            tlp_Produktion.Controls.Add(lbl_Produktion_ID_min, 5, 2);
            tlp_Produktion.Controls.Add(lbl_Produktion_OD1_min, 7, 2);
            tlp_Produktion.Controls.Add(lbl_Produktion_ODs_min, 9, 2);
            tlp_Produktion.Controls.Add(lbl_Produktion_ID_nom, 5, 3);
            tlp_Produktion.Controls.Add(lbl_Produktion_OD1_nom, 7, 3);
            tlp_Produktion.Controls.Add(lbl_Produktion_ODs_nom, 9, 3);
            tlp_Produktion.Controls.Add(lbl_Produktion_ID_max, 5, 4);
            tlp_Produktion.Controls.Add(lbl_Produktion_OD1_max, 7, 4);
            tlp_Produktion.Controls.Add(lbl_Produktion_ODs_max, 9, 4);
            tlp_Produktion.Controls.Add(label_Empty_13, 12, 2);
            tlp_Produktion.Controls.Add(tb_Produktion_Mätare, 2, 5);
            tlp_Produktion.Controls.Add(tb_Produktion_Temp_L1, 3, 5);
            tlp_Produktion.Controls.Add(tb_Produktion_Temp_L2, 4, 5);
            tlp_Produktion.Controls.Add(tb_Produktion_ID_L1, 5, 5);
            tlp_Produktion.Controls.Add(tb_Produktion_ID_L2, 6, 5);
            tlp_Produktion.Controls.Add(tb_Produktion_OD1_L1, 7, 5);
            tlp_Produktion.Controls.Add(tb_Produktion_OD1_L2, 8, 5);
            tlp_Produktion.Controls.Add(tb_Produktion_ODs_L1, 9, 5);
            tlp_Produktion.Controls.Add(tb_Produktion_ODs_L2, 10, 5);
            tlp_Produktion.Controls.Add(chb_Tråd_slut, 12, 5);
            tlp_Produktion.Controls.Add(chb_Tråd_av, 13, 5);
            tlp_Produktion.Controls.Add(chb_Trasig_carrier, 14, 5);
            tlp_Produktion.Controls.Add(chb_Skarv, 15, 5);
            tlp_Produktion.Controls.Add(chb_Spole_slut, 16, 5);
            tlp_Produktion.Controls.Add(chb_Avslut_linje, 17, 5);
            tlp_Produktion.Controls.Add(tb_Produktion_Kommentar, 19, 5);
            tlp_Produktion.Controls.Add(label_Produktion_AnstNr, 22, 0);
            tlp_Produktion.Controls.Add(label_Empty_14, 20, 5);
            tlp_Produktion.Controls.Add(chb_Avrapporterat, 18, 5);
            tlp_Produktion.Controls.Add(label_Produktion_Avrapporterat, 18, 0);
            tlp_Produktion.Dock = DockStyle.Fill;
            tlp_Produktion.Location = new Point(2, 446);
            tlp_Produktion.Margin = new Padding(2, 0, 2, 0);
            tlp_Produktion.Name = "tlp_Produktion";
            tlp_Produktion.RowCount = 6;
            tlp_Main.SetRowSpan(tlp_Produktion, 2);
            tlp_Produktion.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Produktion.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Produktion.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Produktion.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Produktion.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tlp_Produktion.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tlp_Produktion.Size = new Size(1454, 156);
            tlp_Produktion.TabIndex = 1030;
            // 
            // label_Produktion_Sign
            // 
            label_Produktion_Sign.BackColor = Color.White;
            label_Produktion_Sign.Dock = DockStyle.Fill;
            label_Produktion_Sign.Font = new Font("Arial", 8.55F);
            label_Produktion_Sign.ForeColor = Color.Black;
            label_Produktion_Sign.Location = new Point(1201, 1);
            label_Produktion_Sign.Margin = new Padding(1);
            label_Produktion_Sign.Name = "label_Produktion_Sign";
            tlp_Produktion.SetRowSpan(label_Produktion_Sign, 2);
            label_Produktion_Sign.Size = new Size(252, 44);
            label_Produktion_Sign.TabIndex = 1045;
            label_Produktion_Sign.Text = "Sign";
            label_Produktion_Sign.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Tid
            // 
            label_Produktion_Tid.BackColor = Color.White;
            label_Produktion_Tid.Font = new Font("Arial", 8.55F);
            label_Produktion_Tid.ForeColor = Color.Black;
            label_Produktion_Tid.Location = new Point(1083, 1);
            label_Produktion_Tid.Margin = new Padding(1, 1, 0, 1);
            label_Produktion_Tid.Name = "label_Produktion_Tid";
            tlp_Produktion.SetRowSpan(label_Produktion_Tid, 2);
            label_Produktion_Tid.Size = new Size(56, 44);
            label_Produktion_Tid.TabIndex = 1044;
            label_Produktion_Tid.Text = "Tid";
            label_Produktion_Tid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Transfer_Produktion
            // 
            lbl_Transfer_Produktion.BackColor = Color.FromArgb(198, 239, 206);
            tlp_Produktion.SetColumnSpan(lbl_Transfer_Produktion, 2);
            lbl_Transfer_Produktion.Cursor = Cursors.Hand;
            lbl_Transfer_Produktion.Dock = DockStyle.Fill;
            lbl_Transfer_Produktion.Enabled = false;
            lbl_Transfer_Produktion.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Transfer_Produktion.ForeColor = Color.FromArgb(0, 97, 0);
            lbl_Transfer_Produktion.Location = new Point(1, 119);
            lbl_Transfer_Produktion.Margin = new Padding(1, 1, 0, 0);
            lbl_Transfer_Produktion.Name = "lbl_Transfer_Produktion";
            lbl_Transfer_Produktion.Size = new Size(43, 41);
            lbl_Transfer_Produktion.TabIndex = 1041;
            lbl_Transfer_Produktion.Text = "→";
            lbl_Transfer_Produktion.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Transfer_Produktion.Click += Transfer_Produktion_Click;
            // 
            // lbl_Produktion_Temp_nom
            // 
            lbl_Produktion_Temp_nom.BackColor = Color.Silver;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_Temp_nom, 2);
            lbl_Produktion_Temp_nom.Dock = DockStyle.Fill;
            lbl_Produktion_Temp_nom.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_Temp_nom.ForeColor = Color.ForestGreen;
            lbl_Produktion_Temp_nom.Location = new Point(99, 69);
            lbl_Produktion_Temp_nom.Margin = new Padding(1, 0, 1, 1);
            lbl_Produktion_Temp_nom.Name = "lbl_Produktion_Temp_nom";
            lbl_Produktion_Temp_nom.Size = new Size(74, 22);
            lbl_Produktion_Temp_nom.TabIndex = 1040;
            lbl_Produktion_Temp_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_Temp_max
            // 
            lbl_Produktion_Temp_max.BackColor = Color.Gainsboro;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_Temp_max, 2);
            lbl_Produktion_Temp_max.Dock = DockStyle.Fill;
            lbl_Produktion_Temp_max.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_Temp_max.ForeColor = Color.DodgerBlue;
            lbl_Produktion_Temp_max.Location = new Point(99, 92);
            lbl_Produktion_Temp_max.Margin = new Padding(1, 0, 1, 1);
            lbl_Produktion_Temp_max.Name = "lbl_Produktion_Temp_max";
            lbl_Produktion_Temp_max.Size = new Size(74, 25);
            lbl_Produktion_Temp_max.TabIndex = 1039;
            lbl_Produktion_Temp_max.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_Temp_min
            // 
            lbl_Produktion_Temp_min.BackColor = Color.Gainsboro;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_Temp_min, 2);
            lbl_Produktion_Temp_min.Dock = DockStyle.Fill;
            lbl_Produktion_Temp_min.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_Temp_min.ForeColor = Color.DodgerBlue;
            lbl_Produktion_Temp_min.Location = new Point(99, 46);
            lbl_Produktion_Temp_min.Margin = new Padding(1, 0, 1, 1);
            lbl_Produktion_Temp_min.Name = "lbl_Produktion_Temp_min";
            lbl_Produktion_Temp_min.Size = new Size(74, 22);
            lbl_Produktion_Temp_min.TabIndex = 1038;
            lbl_Produktion_Temp_min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_12
            // 
            label_Empty_12.BackColor = Color.DarkGray;
            label_Empty_12.Cursor = Cursors.SizeAll;
            label_Empty_12.Dock = DockStyle.Fill;
            label_Empty_12.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_12.ForeColor = Color.ForestGreen;
            label_Empty_12.Location = new Point(45, 46);
            label_Empty_12.Margin = new Padding(1, 0, 1, 1);
            label_Empty_12.Name = "label_Empty_12";
            tlp_Produktion.SetRowSpan(label_Empty_12, 3);
            label_Empty_12.Size = new Size(52, 71);
            label_Empty_12.TabIndex = 1037;
            label_Empty_12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_ID
            // 
            label_Produktion_ID.BackColor = Color.White;
            tlp_Produktion.SetColumnSpan(label_Produktion_ID, 2);
            label_Produktion_ID.Dock = DockStyle.Fill;
            label_Produktion_ID.Font = new Font("Arial", 8.55F);
            label_Produktion_ID.ForeColor = Color.Black;
            label_Produktion_ID.Location = new Point(175, 1);
            label_Produktion_ID.Margin = new Padding(1, 1, 0, 0);
            label_Produktion_ID.Name = "label_Produktion_ID";
            label_Produktion_ID.Size = new Size(83, 22);
            label_Produktion_ID.TabIndex = 1036;
            label_Produktion_ID.Text = "ID";
            label_Produktion_ID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_MAX
            // 
            label_Produktion_MAX.BackColor = Color.Silver;
            tlp_Produktion.SetColumnSpan(label_Produktion_MAX, 2);
            label_Produktion_MAX.Dock = DockStyle.Fill;
            label_Produktion_MAX.Font = new Font("Palatino Linotype", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Produktion_MAX.ForeColor = Color.DodgerBlue;
            label_Produktion_MAX.Location = new Point(1, 92);
            label_Produktion_MAX.Margin = new Padding(1, 0, 0, 1);
            label_Produktion_MAX.Name = "label_Produktion_MAX";
            label_Produktion_MAX.Size = new Size(43, 25);
            label_Produktion_MAX.TabIndex = 1033;
            label_Produktion_MAX.Text = "MAX";
            label_Produktion_MAX.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_NOM
            // 
            label_Produktion_NOM.BackColor = Color.Silver;
            tlp_Produktion.SetColumnSpan(label_Produktion_NOM, 2);
            label_Produktion_NOM.Dock = DockStyle.Fill;
            label_Produktion_NOM.Font = new Font("Palatino Linotype", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Produktion_NOM.ForeColor = Color.ForestGreen;
            label_Produktion_NOM.Location = new Point(1, 69);
            label_Produktion_NOM.Margin = new Padding(1, 0, 0, 1);
            label_Produktion_NOM.Name = "label_Produktion_NOM";
            label_Produktion_NOM.Size = new Size(43, 22);
            label_Produktion_NOM.TabIndex = 1032;
            label_Produktion_NOM.Text = "NOM";
            label_Produktion_NOM.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_VerktygsID_max
            // 
            lbl_VerktygsID_max.AutoSize = true;
            lbl_VerktygsID_max.BackColor = Color.Gainsboro;
            lbl_VerktygsID_max.Dock = DockStyle.Fill;
            lbl_VerktygsID_max.Font = new Font("Consolas", 8.75F);
            lbl_VerktygsID_max.ForeColor = Color.DodgerBlue;
            lbl_VerktygsID_max.Location = new Point(426, 92);
            lbl_VerktygsID_max.Margin = new Padding(0, 0, 1, 1);
            lbl_VerktygsID_max.Name = "lbl_VerktygsID_max";
            lbl_VerktygsID_max.Size = new Size(79, 25);
            lbl_VerktygsID_max.TabIndex = 1003;
            lbl_VerktygsID_max.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_MIN
            // 
            label_Produktion_MIN.BackColor = Color.Silver;
            tlp_Produktion.SetColumnSpan(label_Produktion_MIN, 2);
            label_Produktion_MIN.Dock = DockStyle.Fill;
            label_Produktion_MIN.Font = new Font("Palatino Linotype", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Produktion_MIN.ForeColor = Color.DodgerBlue;
            label_Produktion_MIN.Location = new Point(1, 46);
            label_Produktion_MIN.Margin = new Padding(1, 0, 0, 1);
            label_Produktion_MIN.Name = "label_Produktion_MIN";
            label_Produktion_MIN.Size = new Size(43, 22);
            label_Produktion_MIN.TabIndex = 1031;
            label_Produktion_MIN.Text = "MIN";
            label_Produktion_MIN.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_VerktygsID_min
            // 
            lbl_VerktygsID_min.AutoSize = true;
            lbl_VerktygsID_min.BackColor = Color.Gainsboro;
            lbl_VerktygsID_min.Dock = DockStyle.Fill;
            lbl_VerktygsID_min.Font = new Font("Consolas", 8.75F);
            lbl_VerktygsID_min.ForeColor = Color.DodgerBlue;
            lbl_VerktygsID_min.Location = new Point(426, 46);
            lbl_VerktygsID_min.Margin = new Padding(0, 0, 1, 1);
            lbl_VerktygsID_min.Name = "lbl_VerktygsID_min";
            lbl_VerktygsID_min.Size = new Size(79, 22);
            lbl_VerktygsID_min.TabIndex = 1001;
            lbl_VerktygsID_min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_VerktygsID_nom
            // 
            lbl_VerktygsID_nom.AutoSize = true;
            lbl_VerktygsID_nom.BackColor = Color.Silver;
            lbl_VerktygsID_nom.Dock = DockStyle.Fill;
            lbl_VerktygsID_nom.Font = new Font("Consolas", 8.75F);
            lbl_VerktygsID_nom.ForeColor = Color.ForestGreen;
            lbl_VerktygsID_nom.Location = new Point(426, 69);
            lbl_VerktygsID_nom.Margin = new Padding(0, 0, 1, 1);
            lbl_VerktygsID_nom.Name = "lbl_VerktygsID_nom";
            lbl_VerktygsID_nom.Size = new Size(79, 22);
            lbl_VerktygsID_nom.TabIndex = 987;
            lbl_VerktygsID_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Add_Arbetskort
            // 
            lbl_Add_Arbetskort.BackColor = Color.FromArgb(198, 239, 206);
            tlp_Produktion.SetColumnSpan(lbl_Add_Arbetskort, 2);
            lbl_Add_Arbetskort.Cursor = Cursors.Hand;
            lbl_Add_Arbetskort.Dock = DockStyle.Fill;
            lbl_Add_Arbetskort.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Add_Arbetskort.ForeColor = Color.FromArgb(0, 97, 0);
            lbl_Add_Arbetskort.Location = new Point(1, 1);
            lbl_Add_Arbetskort.Margin = new Padding(1, 1, 0, 1);
            lbl_Add_Arbetskort.Name = "lbl_Add_Arbetskort";
            tlp_Produktion.SetRowSpan(lbl_Add_Arbetskort, 2);
            lbl_Add_Arbetskort.Size = new Size(43, 44);
            lbl_Add_Arbetskort.TabIndex = 1029;
            lbl_Add_Arbetskort.Text = "+";
            lbl_Add_Arbetskort.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Add_Arbetskort.Click += Add_Arbetskort_Click;
            // 
            // label_Produktion_Datum
            // 
            label_Produktion_Datum.BackColor = Color.White;
            label_Produktion_Datum.Dock = DockStyle.Fill;
            label_Produktion_Datum.Font = new Font("Arial", 8.55F);
            label_Produktion_Datum.ForeColor = Color.Black;
            label_Produktion_Datum.Location = new Point(991, 1);
            label_Produktion_Datum.Margin = new Padding(1, 1, 0, 1);
            label_Produktion_Datum.Name = "label_Produktion_Datum";
            tlp_Produktion.SetRowSpan(label_Produktion_Datum, 2);
            label_Produktion_Datum.Size = new Size(91, 44);
            label_Produktion_Datum.TabIndex = 1030;
            label_Produktion_Datum.Text = "Datum";
            label_Produktion_Datum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Mätare
            // 
            label_Produktion_Mätare.BackColor = Color.White;
            label_Produktion_Mätare.Dock = DockStyle.Fill;
            label_Produktion_Mätare.Font = new Font("Arial", 8.55F);
            label_Produktion_Mätare.ForeColor = Color.Black;
            label_Produktion_Mätare.Location = new Point(45, 1);
            label_Produktion_Mätare.Margin = new Padding(1);
            label_Produktion_Mätare.Name = "label_Produktion_Mätare";
            tlp_Produktion.SetRowSpan(label_Produktion_Mätare, 2);
            label_Produktion_Mätare.Size = new Size(52, 44);
            label_Produktion_Mätare.TabIndex = 1034;
            label_Produktion_Mätare.Text = "Mätare";
            label_Produktion_Mätare.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Temp_L1
            // 
            label_Produktion_Temp_L1.BackColor = Color.White;
            label_Produktion_Temp_L1.Dock = DockStyle.Fill;
            label_Produktion_Temp_L1.Font = new Font("Arial", 8.55F);
            label_Produktion_Temp_L1.ForeColor = Color.Black;
            label_Produktion_Temp_L1.Location = new Point(99, 23);
            label_Produktion_Temp_L1.Margin = new Padding(1, 0, 0, 1);
            label_Produktion_Temp_L1.Name = "label_Produktion_Temp_L1";
            label_Produktion_Temp_L1.Size = new Size(37, 22);
            label_Produktion_Temp_L1.TabIndex = 1035;
            label_Produktion_Temp_L1.Text = "L1";
            label_Produktion_Temp_L1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Temp
            // 
            label_Produktion_Temp.BackColor = Color.White;
            tlp_Produktion.SetColumnSpan(label_Produktion_Temp, 2);
            label_Produktion_Temp.Dock = DockStyle.Fill;
            label_Produktion_Temp.Font = new Font("Arial", 8.55F);
            label_Produktion_Temp.ForeColor = Color.Black;
            label_Produktion_Temp.Location = new Point(99, 1);
            label_Produktion_Temp.Margin = new Padding(1, 1, 1, 0);
            label_Produktion_Temp.Name = "label_Produktion_Temp";
            label_Produktion_Temp.Size = new Size(74, 22);
            label_Produktion_Temp.TabIndex = 1034;
            label_Produktion_Temp.Text = "Temp ºC";
            label_Produktion_Temp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Temp_L2
            // 
            label_Produktion_Temp_L2.BackColor = Color.White;
            label_Produktion_Temp_L2.Dock = DockStyle.Fill;
            label_Produktion_Temp_L2.Font = new Font("Arial", 8.55F);
            label_Produktion_Temp_L2.ForeColor = Color.Black;
            label_Produktion_Temp_L2.Location = new Point(137, 23);
            label_Produktion_Temp_L2.Margin = new Padding(1, 0, 1, 1);
            label_Produktion_Temp_L2.Name = "label_Produktion_Temp_L2";
            label_Produktion_Temp_L2.Size = new Size(36, 22);
            label_Produktion_Temp_L2.TabIndex = 1035;
            label_Produktion_Temp_L2.Text = "L2";
            label_Produktion_Temp_L2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_ID_L1
            // 
            label_Produktion_ID_L1.BackColor = Color.White;
            label_Produktion_ID_L1.Dock = DockStyle.Fill;
            label_Produktion_ID_L1.Font = new Font("Arial", 8.55F);
            label_Produktion_ID_L1.ForeColor = Color.Black;
            label_Produktion_ID_L1.Location = new Point(175, 23);
            label_Produktion_ID_L1.Margin = new Padding(1, 0, 0, 1);
            label_Produktion_ID_L1.Name = "label_Produktion_ID_L1";
            label_Produktion_ID_L1.Size = new Size(41, 22);
            label_Produktion_ID_L1.TabIndex = 1035;
            label_Produktion_ID_L1.Text = "L1";
            label_Produktion_ID_L1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_ID_L2
            // 
            label_Produktion_ID_L2.BackColor = Color.White;
            label_Produktion_ID_L2.Dock = DockStyle.Fill;
            label_Produktion_ID_L2.Font = new Font("Arial", 8.55F);
            label_Produktion_ID_L2.ForeColor = Color.Black;
            label_Produktion_ID_L2.Location = new Point(217, 23);
            label_Produktion_ID_L2.Margin = new Padding(1, 0, 0, 1);
            label_Produktion_ID_L2.Name = "label_Produktion_ID_L2";
            label_Produktion_ID_L2.Size = new Size(41, 22);
            label_Produktion_ID_L2.TabIndex = 1035;
            label_Produktion_ID_L2.Text = "L2";
            label_Produktion_ID_L2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_OD1
            // 
            label_Produktion_OD1.BackColor = Color.White;
            tlp_Produktion.SetColumnSpan(label_Produktion_OD1, 2);
            label_Produktion_OD1.Dock = DockStyle.Fill;
            label_Produktion_OD1.Font = new Font("Arial", 8.55F);
            label_Produktion_OD1.ForeColor = Color.Black;
            label_Produktion_OD1.Location = new Point(259, 1);
            label_Produktion_OD1.Margin = new Padding(1, 1, 0, 0);
            label_Produktion_OD1.Name = "label_Produktion_OD1";
            label_Produktion_OD1.Size = new Size(83, 22);
            label_Produktion_OD1.TabIndex = 1036;
            label_Produktion_OD1.Text = "OD1";
            label_Produktion_OD1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_OD1_L1
            // 
            label_Produktion_OD1_L1.BackColor = Color.White;
            label_Produktion_OD1_L1.Dock = DockStyle.Fill;
            label_Produktion_OD1_L1.Font = new Font("Arial", 8.55F);
            label_Produktion_OD1_L1.ForeColor = Color.Black;
            label_Produktion_OD1_L1.Location = new Point(259, 23);
            label_Produktion_OD1_L1.Margin = new Padding(1, 0, 0, 1);
            label_Produktion_OD1_L1.Name = "label_Produktion_OD1_L1";
            label_Produktion_OD1_L1.Size = new Size(41, 22);
            label_Produktion_OD1_L1.TabIndex = 1035;
            label_Produktion_OD1_L1.Text = "L1";
            label_Produktion_OD1_L1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_VerktygsID_enhet
            // 
            label_VerktygsID_enhet.BackColor = Color.White;
            label_VerktygsID_enhet.Dock = DockStyle.Fill;
            label_VerktygsID_enhet.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_VerktygsID_enhet.ForeColor = Color.Black;
            label_VerktygsID_enhet.Location = new Point(426, 23);
            label_VerktygsID_enhet.Margin = new Padding(0, 0, 1, 1);
            label_VerktygsID_enhet.Name = "label_VerktygsID_enhet";
            label_VerktygsID_enhet.Padding = new Padding(9, 0, 9, 0);
            label_VerktygsID_enhet.Size = new Size(79, 22);
            label_VerktygsID_enhet.TabIndex = 817;
            label_VerktygsID_enhet.Text = "mm";
            label_VerktygsID_enhet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_OD1_L2
            // 
            label_Produktion_OD1_L2.BackColor = Color.White;
            label_Produktion_OD1_L2.Dock = DockStyle.Fill;
            label_Produktion_OD1_L2.Font = new Font("Arial", 8.55F);
            label_Produktion_OD1_L2.ForeColor = Color.Black;
            label_Produktion_OD1_L2.Location = new Point(301, 23);
            label_Produktion_OD1_L2.Margin = new Padding(1, 0, 0, 1);
            label_Produktion_OD1_L2.Name = "label_Produktion_OD1_L2";
            label_Produktion_OD1_L2.Size = new Size(41, 22);
            label_Produktion_OD1_L2.TabIndex = 1035;
            label_Produktion_OD1_L2.Text = "L2";
            label_Produktion_OD1_L2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_ODs
            // 
            label_Produktion_ODs.BackColor = Color.White;
            tlp_Produktion.SetColumnSpan(label_Produktion_ODs, 2);
            label_Produktion_ODs.Dock = DockStyle.Fill;
            label_Produktion_ODs.Font = new Font("Arial", 8.55F);
            label_Produktion_ODs.ForeColor = Color.Black;
            label_Produktion_ODs.Location = new Point(343, 1);
            label_Produktion_ODs.Margin = new Padding(1, 1, 1, 0);
            label_Produktion_ODs.Name = "label_Produktion_ODs";
            label_Produktion_ODs.Size = new Size(82, 22);
            label_Produktion_ODs.TabIndex = 1036;
            label_Produktion_ODs.Text = "ODs";
            label_Produktion_ODs.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Bladhöjd
            // 
            label_Bladhöjd.BackColor = Color.White;
            label_Bladhöjd.Dock = DockStyle.Fill;
            label_Bladhöjd.Font = new Font("Arial", 8.55F);
            label_Bladhöjd.ForeColor = Color.Black;
            label_Bladhöjd.Location = new Point(426, 1);
            label_Bladhöjd.Margin = new Padding(0, 1, 1, 0);
            label_Bladhöjd.Name = "label_Bladhöjd";
            label_Bladhöjd.Size = new Size(79, 22);
            label_Bladhöjd.TabIndex = 136;
            label_Bladhöjd.Text = "Verktygs ID";
            label_Bladhöjd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_ODs_L1
            // 
            label_Produktion_ODs_L1.BackColor = Color.White;
            label_Produktion_ODs_L1.Dock = DockStyle.Fill;
            label_Produktion_ODs_L1.Font = new Font("Arial", 8.55F);
            label_Produktion_ODs_L1.ForeColor = Color.Black;
            label_Produktion_ODs_L1.Location = new Point(343, 23);
            label_Produktion_ODs_L1.Margin = new Padding(1, 0, 0, 1);
            label_Produktion_ODs_L1.Name = "label_Produktion_ODs_L1";
            label_Produktion_ODs_L1.Size = new Size(41, 22);
            label_Produktion_ODs_L1.TabIndex = 1035;
            label_Produktion_ODs_L1.Text = "L1";
            label_Produktion_ODs_L1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_Verktygs_ID
            // 
            tb_Verktygs_ID.BackColor = Color.White;
            tb_Verktygs_ID.BorderStyle = BorderStyle.None;
            tb_Verktygs_ID.Cursor = Cursors.IBeam;
            tb_Verktygs_ID.Dock = DockStyle.Fill;
            tb_Verktygs_ID.Font = new Font("Courier New", 8.5F);
            tb_Verktygs_ID.ForeColor = Color.DarkSlateGray;
            tb_Verktygs_ID.Location = new Point(426, 119);
            tb_Verktygs_ID.Margin = new Padding(0, 1, 1, 0);
            tb_Verktygs_ID.MaxLength = 6;
            tb_Verktygs_ID.Multiline = true;
            tb_Verktygs_ID.Name = "tb_Verktygs_ID";
            tb_Verktygs_ID.Size = new Size(79, 41);
            tb_Verktygs_ID.TabIndex = 19;
            tb_Verktygs_ID.TextAlign = HorizontalAlignment.Center;
            tb_Verktygs_ID.WordWrap = false;
            tb_Verktygs_ID.KeyPress += Double_Values_Onyl_KeyPress;
            tb_Verktygs_ID.Leave += ValidateData_TextLeave;
            // 
            // label_Produktion_ODs_L2
            // 
            label_Produktion_ODs_L2.BackColor = Color.White;
            label_Produktion_ODs_L2.Dock = DockStyle.Fill;
            label_Produktion_ODs_L2.Font = new Font("Arial", 8.55F);
            label_Produktion_ODs_L2.ForeColor = Color.Black;
            label_Produktion_ODs_L2.Location = new Point(385, 23);
            label_Produktion_ODs_L2.Margin = new Padding(1, 0, 1, 1);
            label_Produktion_ODs_L2.Name = "label_Produktion_ODs_L2";
            label_Produktion_ODs_L2.Size = new Size(40, 22);
            label_Produktion_ODs_L2.TabIndex = 1035;
            label_Produktion_ODs_L2.Text = "L2";
            label_Produktion_ODs_L2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Tråd_slut
            // 
            label_Produktion_Tråd_slut.BackColor = Color.White;
            label_Produktion_Tråd_slut.Dock = DockStyle.Fill;
            label_Produktion_Tråd_slut.Font = new Font("Arial", 6.55F);
            label_Produktion_Tråd_slut.ForeColor = Color.Black;
            label_Produktion_Tråd_slut.Location = new Point(507, 1);
            label_Produktion_Tråd_slut.Margin = new Padding(1, 1, 0, 1);
            label_Produktion_Tråd_slut.Name = "label_Produktion_Tråd_slut";
            tlp_Produktion.SetRowSpan(label_Produktion_Tråd_slut, 2);
            label_Produktion_Tråd_slut.Size = new Size(41, 44);
            label_Produktion_Tråd_slut.TabIndex = 1036;
            label_Produktion_Tråd_slut.Text = "Tråd slut";
            label_Produktion_Tråd_slut.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Tråd_av
            // 
            label_Produktion_Tråd_av.BackColor = Color.White;
            label_Produktion_Tråd_av.Dock = DockStyle.Fill;
            label_Produktion_Tråd_av.Font = new Font("Arial", 6.55F);
            label_Produktion_Tråd_av.ForeColor = Color.Black;
            label_Produktion_Tråd_av.Location = new Point(549, 1);
            label_Produktion_Tråd_av.Margin = new Padding(1, 1, 0, 1);
            label_Produktion_Tråd_av.Name = "label_Produktion_Tråd_av";
            tlp_Produktion.SetRowSpan(label_Produktion_Tråd_av, 2);
            label_Produktion_Tråd_av.Size = new Size(41, 44);
            label_Produktion_Tråd_av.TabIndex = 1036;
            label_Produktion_Tråd_av.Text = "Tråd av";
            label_Produktion_Tråd_av.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Trasig_carrier
            // 
            label_Produktion_Trasig_carrier.BackColor = Color.White;
            label_Produktion_Trasig_carrier.Dock = DockStyle.Fill;
            label_Produktion_Trasig_carrier.Font = new Font("Arial", 6.55F);
            label_Produktion_Trasig_carrier.ForeColor = Color.Black;
            label_Produktion_Trasig_carrier.Location = new Point(591, 1);
            label_Produktion_Trasig_carrier.Margin = new Padding(1, 1, 0, 1);
            label_Produktion_Trasig_carrier.Name = "label_Produktion_Trasig_carrier";
            tlp_Produktion.SetRowSpan(label_Produktion_Trasig_carrier, 2);
            label_Produktion_Trasig_carrier.Size = new Size(41, 44);
            label_Produktion_Trasig_carrier.TabIndex = 1036;
            label_Produktion_Trasig_carrier.Text = "Trasig carrier";
            label_Produktion_Trasig_carrier.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Skarv
            // 
            label_Produktion_Skarv.BackColor = Color.White;
            label_Produktion_Skarv.Dock = DockStyle.Fill;
            label_Produktion_Skarv.Font = new Font("Arial", 6.55F);
            label_Produktion_Skarv.ForeColor = Color.Black;
            label_Produktion_Skarv.Location = new Point(633, 1);
            label_Produktion_Skarv.Margin = new Padding(1, 1, 0, 1);
            label_Produktion_Skarv.Name = "label_Produktion_Skarv";
            tlp_Produktion.SetRowSpan(label_Produktion_Skarv, 2);
            label_Produktion_Skarv.Size = new Size(41, 44);
            label_Produktion_Skarv.TabIndex = 1036;
            label_Produktion_Skarv.Text = "Skarv";
            label_Produktion_Skarv.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Spole_slut
            // 
            label_Produktion_Spole_slut.BackColor = Color.White;
            label_Produktion_Spole_slut.Dock = DockStyle.Fill;
            label_Produktion_Spole_slut.Font = new Font("Arial", 6.55F);
            label_Produktion_Spole_slut.ForeColor = Color.Black;
            label_Produktion_Spole_slut.Location = new Point(675, 1);
            label_Produktion_Spole_slut.Margin = new Padding(1, 1, 0, 1);
            label_Produktion_Spole_slut.Name = "label_Produktion_Spole_slut";
            tlp_Produktion.SetRowSpan(label_Produktion_Spole_slut, 2);
            label_Produktion_Spole_slut.Size = new Size(41, 44);
            label_Produktion_Spole_slut.TabIndex = 1036;
            label_Produktion_Spole_slut.Text = "Spole slut";
            label_Produktion_Spole_slut.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Avslut_linje
            // 
            label_Produktion_Avslut_linje.BackColor = Color.White;
            label_Produktion_Avslut_linje.Dock = DockStyle.Fill;
            label_Produktion_Avslut_linje.Font = new Font("Arial", 6.55F);
            label_Produktion_Avslut_linje.ForeColor = Color.Black;
            label_Produktion_Avslut_linje.Location = new Point(717, 1);
            label_Produktion_Avslut_linje.Margin = new Padding(1, 1, 0, 1);
            label_Produktion_Avslut_linje.Name = "label_Produktion_Avslut_linje";
            tlp_Produktion.SetRowSpan(label_Produktion_Avslut_linje, 2);
            label_Produktion_Avslut_linje.Size = new Size(41, 44);
            label_Produktion_Avslut_linje.TabIndex = 1036;
            label_Produktion_Avslut_linje.Text = "Avslut linje";
            label_Produktion_Avslut_linje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Kommentar
            // 
            label_Produktion_Kommentar.BackColor = Color.White;
            label_Produktion_Kommentar.Dock = DockStyle.Fill;
            label_Produktion_Kommentar.Font = new Font("Arial", 8.55F);
            label_Produktion_Kommentar.ForeColor = Color.Black;
            label_Produktion_Kommentar.Location = new Point(801, 1);
            label_Produktion_Kommentar.Margin = new Padding(1);
            label_Produktion_Kommentar.Name = "label_Produktion_Kommentar";
            tlp_Produktion.SetRowSpan(label_Produktion_Kommentar, 2);
            label_Produktion_Kommentar.Size = new Size(188, 44);
            label_Produktion_Kommentar.TabIndex = 1036;
            label_Produktion_Kommentar.Text = "Kommentar";
            label_Produktion_Kommentar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ID_min
            // 
            lbl_Produktion_ID_min.BackColor = Color.Gainsboro;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_ID_min, 2);
            lbl_Produktion_ID_min.Dock = DockStyle.Fill;
            lbl_Produktion_ID_min.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_ID_min.ForeColor = Color.DodgerBlue;
            lbl_Produktion_ID_min.Location = new Point(175, 46);
            lbl_Produktion_ID_min.Margin = new Padding(1, 0, 0, 1);
            lbl_Produktion_ID_min.Name = "lbl_Produktion_ID_min";
            lbl_Produktion_ID_min.Size = new Size(83, 22);
            lbl_Produktion_ID_min.TabIndex = 1038;
            lbl_Produktion_ID_min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_OD1_min
            // 
            lbl_Produktion_OD1_min.BackColor = Color.Gainsboro;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_OD1_min, 2);
            lbl_Produktion_OD1_min.Dock = DockStyle.Fill;
            lbl_Produktion_OD1_min.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_OD1_min.ForeColor = Color.DodgerBlue;
            lbl_Produktion_OD1_min.Location = new Point(259, 46);
            lbl_Produktion_OD1_min.Margin = new Padding(1, 0, 0, 1);
            lbl_Produktion_OD1_min.Name = "lbl_Produktion_OD1_min";
            lbl_Produktion_OD1_min.Size = new Size(83, 22);
            lbl_Produktion_OD1_min.TabIndex = 1038;
            lbl_Produktion_OD1_min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ODs_min
            // 
            lbl_Produktion_ODs_min.BackColor = Color.Gainsboro;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_ODs_min, 2);
            lbl_Produktion_ODs_min.Dock = DockStyle.Fill;
            lbl_Produktion_ODs_min.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_ODs_min.ForeColor = Color.DodgerBlue;
            lbl_Produktion_ODs_min.Location = new Point(343, 46);
            lbl_Produktion_ODs_min.Margin = new Padding(1, 0, 1, 1);
            lbl_Produktion_ODs_min.Name = "lbl_Produktion_ODs_min";
            lbl_Produktion_ODs_min.Size = new Size(82, 22);
            lbl_Produktion_ODs_min.TabIndex = 1038;
            lbl_Produktion_ODs_min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ID_nom
            // 
            lbl_Produktion_ID_nom.BackColor = Color.Silver;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_ID_nom, 2);
            lbl_Produktion_ID_nom.Dock = DockStyle.Fill;
            lbl_Produktion_ID_nom.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_ID_nom.ForeColor = Color.ForestGreen;
            lbl_Produktion_ID_nom.Location = new Point(175, 69);
            lbl_Produktion_ID_nom.Margin = new Padding(1, 0, 0, 1);
            lbl_Produktion_ID_nom.Name = "lbl_Produktion_ID_nom";
            lbl_Produktion_ID_nom.Size = new Size(83, 22);
            lbl_Produktion_ID_nom.TabIndex = 1040;
            lbl_Produktion_ID_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_OD1_nom
            // 
            lbl_Produktion_OD1_nom.BackColor = Color.Silver;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_OD1_nom, 2);
            lbl_Produktion_OD1_nom.Dock = DockStyle.Fill;
            lbl_Produktion_OD1_nom.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_OD1_nom.ForeColor = Color.ForestGreen;
            lbl_Produktion_OD1_nom.Location = new Point(259, 69);
            lbl_Produktion_OD1_nom.Margin = new Padding(1, 0, 0, 1);
            lbl_Produktion_OD1_nom.Name = "lbl_Produktion_OD1_nom";
            lbl_Produktion_OD1_nom.Size = new Size(83, 22);
            lbl_Produktion_OD1_nom.TabIndex = 1040;
            lbl_Produktion_OD1_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ODs_nom
            // 
            lbl_Produktion_ODs_nom.BackColor = Color.Silver;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_ODs_nom, 2);
            lbl_Produktion_ODs_nom.Dock = DockStyle.Fill;
            lbl_Produktion_ODs_nom.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_ODs_nom.ForeColor = Color.ForestGreen;
            lbl_Produktion_ODs_nom.Location = new Point(343, 69);
            lbl_Produktion_ODs_nom.Margin = new Padding(1, 0, 1, 1);
            lbl_Produktion_ODs_nom.Name = "lbl_Produktion_ODs_nom";
            lbl_Produktion_ODs_nom.Size = new Size(82, 22);
            lbl_Produktion_ODs_nom.TabIndex = 1040;
            lbl_Produktion_ODs_nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ID_max
            // 
            lbl_Produktion_ID_max.BackColor = Color.Gainsboro;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_ID_max, 2);
            lbl_Produktion_ID_max.Dock = DockStyle.Fill;
            lbl_Produktion_ID_max.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_ID_max.ForeColor = Color.DodgerBlue;
            lbl_Produktion_ID_max.Location = new Point(175, 92);
            lbl_Produktion_ID_max.Margin = new Padding(1, 0, 0, 1);
            lbl_Produktion_ID_max.Name = "lbl_Produktion_ID_max";
            lbl_Produktion_ID_max.Size = new Size(83, 25);
            lbl_Produktion_ID_max.TabIndex = 1039;
            lbl_Produktion_ID_max.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_OD1_max
            // 
            lbl_Produktion_OD1_max.BackColor = Color.Gainsboro;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_OD1_max, 2);
            lbl_Produktion_OD1_max.Dock = DockStyle.Fill;
            lbl_Produktion_OD1_max.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_OD1_max.ForeColor = Color.DodgerBlue;
            lbl_Produktion_OD1_max.Location = new Point(259, 92);
            lbl_Produktion_OD1_max.Margin = new Padding(1, 0, 0, 1);
            lbl_Produktion_OD1_max.Name = "lbl_Produktion_OD1_max";
            lbl_Produktion_OD1_max.Size = new Size(83, 25);
            lbl_Produktion_OD1_max.TabIndex = 1039;
            lbl_Produktion_OD1_max.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ODs_max
            // 
            lbl_Produktion_ODs_max.BackColor = Color.Gainsboro;
            tlp_Produktion.SetColumnSpan(lbl_Produktion_ODs_max, 2);
            lbl_Produktion_ODs_max.Dock = DockStyle.Fill;
            lbl_Produktion_ODs_max.Font = new Font("Consolas", 8.75F);
            lbl_Produktion_ODs_max.ForeColor = Color.DodgerBlue;
            lbl_Produktion_ODs_max.Location = new Point(343, 92);
            lbl_Produktion_ODs_max.Margin = new Padding(1, 0, 1, 1);
            lbl_Produktion_ODs_max.Name = "lbl_Produktion_ODs_max";
            lbl_Produktion_ODs_max.Size = new Size(82, 25);
            lbl_Produktion_ODs_max.TabIndex = 1039;
            lbl_Produktion_ODs_max.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_13
            // 
            label_Empty_13.BackColor = Color.DarkGray;
            tlp_Produktion.SetColumnSpan(label_Empty_13, 12);
            label_Empty_13.Cursor = Cursors.SizeAll;
            label_Empty_13.Dock = DockStyle.Fill;
            label_Empty_13.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_13.ForeColor = Color.ForestGreen;
            label_Empty_13.Location = new Point(507, 46);
            label_Empty_13.Margin = new Padding(1, 0, 1, 0);
            label_Empty_13.Name = "label_Empty_13";
            tlp_Produktion.SetRowSpan(label_Empty_13, 3);
            label_Empty_13.Size = new Size(946, 72);
            label_Empty_13.TabIndex = 1037;
            label_Empty_13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_Produktion_Mätare
            // 
            tb_Produktion_Mätare.BackColor = Color.White;
            tb_Produktion_Mätare.BorderStyle = BorderStyle.None;
            tb_Produktion_Mätare.Cursor = Cursors.IBeam;
            tb_Produktion_Mätare.Dock = DockStyle.Fill;
            tb_Produktion_Mätare.Enabled = false;
            tb_Produktion_Mätare.Font = new Font("Courier New", 8.5F);
            tb_Produktion_Mätare.ForeColor = Color.DarkSlateGray;
            tb_Produktion_Mätare.Location = new Point(45, 119);
            tb_Produktion_Mätare.Margin = new Padding(1, 1, 1, 0);
            tb_Produktion_Mätare.MaxLength = 5;
            tb_Produktion_Mätare.Multiline = true;
            tb_Produktion_Mätare.Name = "tb_Produktion_Mätare";
            tb_Produktion_Mätare.Size = new Size(52, 41);
            tb_Produktion_Mätare.TabIndex = 10;
            tb_Produktion_Mätare.TextAlign = HorizontalAlignment.Center;
            tb_Produktion_Mätare.WordWrap = false;
            // 
            // tb_Produktion_Temp_L1
            // 
            tb_Produktion_Temp_L1.BackColor = Color.White;
            tb_Produktion_Temp_L1.BorderStyle = BorderStyle.None;
            tb_Produktion_Temp_L1.Cursor = Cursors.IBeam;
            tb_Produktion_Temp_L1.Dock = DockStyle.Fill;
            tb_Produktion_Temp_L1.Enabled = false;
            tb_Produktion_Temp_L1.Font = new Font("Courier New", 8.5F);
            tb_Produktion_Temp_L1.ForeColor = Color.DarkSlateGray;
            tb_Produktion_Temp_L1.Location = new Point(99, 119);
            tb_Produktion_Temp_L1.Margin = new Padding(1, 1, 0, 0);
            tb_Produktion_Temp_L1.MaxLength = 4;
            tb_Produktion_Temp_L1.Multiline = true;
            tb_Produktion_Temp_L1.Name = "tb_Produktion_Temp_L1";
            tb_Produktion_Temp_L1.Size = new Size(37, 41);
            tb_Produktion_Temp_L1.TabIndex = 11;
            tb_Produktion_Temp_L1.TextAlign = HorizontalAlignment.Center;
            tb_Produktion_Temp_L1.WordWrap = false;
            tb_Produktion_Temp_L1.KeyPress += Int_Values_Only_KeyPress;
            tb_Produktion_Temp_L1.Leave += ValidateData_TextLeave;
            // 
            // tb_Produktion_Temp_L2
            // 
            tb_Produktion_Temp_L2.BackColor = Color.White;
            tb_Produktion_Temp_L2.BorderStyle = BorderStyle.None;
            tb_Produktion_Temp_L2.Cursor = Cursors.IBeam;
            tb_Produktion_Temp_L2.Dock = DockStyle.Fill;
            tb_Produktion_Temp_L2.Enabled = false;
            tb_Produktion_Temp_L2.Font = new Font("Courier New", 8.5F);
            tb_Produktion_Temp_L2.ForeColor = Color.DarkSlateGray;
            tb_Produktion_Temp_L2.Location = new Point(137, 119);
            tb_Produktion_Temp_L2.Margin = new Padding(1, 1, 1, 0);
            tb_Produktion_Temp_L2.MaxLength = 4;
            tb_Produktion_Temp_L2.Multiline = true;
            tb_Produktion_Temp_L2.Name = "tb_Produktion_Temp_L2";
            tb_Produktion_Temp_L2.Size = new Size(36, 41);
            tb_Produktion_Temp_L2.TabIndex = 12;
            tb_Produktion_Temp_L2.TextAlign = HorizontalAlignment.Center;
            tb_Produktion_Temp_L2.WordWrap = false;
            tb_Produktion_Temp_L2.KeyPress += Int_Values_Only_KeyPress;
            tb_Produktion_Temp_L2.Leave += ValidateData_TextLeave;
            // 
            // tb_Produktion_ID_L1
            // 
            tb_Produktion_ID_L1.BackColor = Color.White;
            tb_Produktion_ID_L1.BorderStyle = BorderStyle.None;
            tb_Produktion_ID_L1.Cursor = Cursors.IBeam;
            tb_Produktion_ID_L1.Dock = DockStyle.Fill;
            tb_Produktion_ID_L1.Enabled = false;
            tb_Produktion_ID_L1.Font = new Font("Courier New", 8.5F);
            tb_Produktion_ID_L1.ForeColor = Color.DarkSlateGray;
            tb_Produktion_ID_L1.Location = new Point(175, 119);
            tb_Produktion_ID_L1.Margin = new Padding(1, 1, 0, 0);
            tb_Produktion_ID_L1.MaxLength = 6;
            tb_Produktion_ID_L1.Multiline = true;
            tb_Produktion_ID_L1.Name = "tb_Produktion_ID_L1";
            tb_Produktion_ID_L1.Size = new Size(41, 41);
            tb_Produktion_ID_L1.TabIndex = 13;
            tb_Produktion_ID_L1.TextAlign = HorizontalAlignment.Center;
            tb_Produktion_ID_L1.WordWrap = false;
            tb_Produktion_ID_L1.KeyPress += Double_Values_Onyl_KeyPress;
            tb_Produktion_ID_L1.Leave += ValidateData_TextLeave;
            // 
            // tb_Produktion_ID_L2
            // 
            tb_Produktion_ID_L2.BackColor = Color.White;
            tb_Produktion_ID_L2.BorderStyle = BorderStyle.None;
            tb_Produktion_ID_L2.Cursor = Cursors.IBeam;
            tb_Produktion_ID_L2.Dock = DockStyle.Fill;
            tb_Produktion_ID_L2.Enabled = false;
            tb_Produktion_ID_L2.Font = new Font("Courier New", 8.5F);
            tb_Produktion_ID_L2.ForeColor = Color.DarkSlateGray;
            tb_Produktion_ID_L2.Location = new Point(217, 119);
            tb_Produktion_ID_L2.Margin = new Padding(1, 1, 0, 0);
            tb_Produktion_ID_L2.MaxLength = 6;
            tb_Produktion_ID_L2.Multiline = true;
            tb_Produktion_ID_L2.Name = "tb_Produktion_ID_L2";
            tb_Produktion_ID_L2.Size = new Size(41, 41);
            tb_Produktion_ID_L2.TabIndex = 14;
            tb_Produktion_ID_L2.TextAlign = HorizontalAlignment.Center;
            tb_Produktion_ID_L2.WordWrap = false;
            tb_Produktion_ID_L2.KeyPress += Double_Values_Onyl_KeyPress;
            tb_Produktion_ID_L2.Leave += ValidateData_TextLeave;
            // 
            // tb_Produktion_OD1_L1
            // 
            tb_Produktion_OD1_L1.BackColor = Color.White;
            tb_Produktion_OD1_L1.BorderStyle = BorderStyle.None;
            tb_Produktion_OD1_L1.Cursor = Cursors.IBeam;
            tb_Produktion_OD1_L1.Dock = DockStyle.Fill;
            tb_Produktion_OD1_L1.Enabled = false;
            tb_Produktion_OD1_L1.Font = new Font("Courier New", 8.5F);
            tb_Produktion_OD1_L1.ForeColor = Color.DarkSlateGray;
            tb_Produktion_OD1_L1.Location = new Point(259, 119);
            tb_Produktion_OD1_L1.Margin = new Padding(1, 1, 0, 0);
            tb_Produktion_OD1_L1.MaxLength = 6;
            tb_Produktion_OD1_L1.Multiline = true;
            tb_Produktion_OD1_L1.Name = "tb_Produktion_OD1_L1";
            tb_Produktion_OD1_L1.Size = new Size(41, 41);
            tb_Produktion_OD1_L1.TabIndex = 15;
            tb_Produktion_OD1_L1.TextAlign = HorizontalAlignment.Center;
            tb_Produktion_OD1_L1.WordWrap = false;
            tb_Produktion_OD1_L1.KeyPress += Double_Values_Onyl_KeyPress;
            tb_Produktion_OD1_L1.Leave += ValidateData_TextLeave;
            // 
            // tb_Produktion_OD1_L2
            // 
            tb_Produktion_OD1_L2.BackColor = Color.White;
            tb_Produktion_OD1_L2.BorderStyle = BorderStyle.None;
            tb_Produktion_OD1_L2.Cursor = Cursors.IBeam;
            tb_Produktion_OD1_L2.Dock = DockStyle.Fill;
            tb_Produktion_OD1_L2.Enabled = false;
            tb_Produktion_OD1_L2.Font = new Font("Courier New", 8.5F);
            tb_Produktion_OD1_L2.ForeColor = Color.DarkSlateGray;
            tb_Produktion_OD1_L2.Location = new Point(301, 119);
            tb_Produktion_OD1_L2.Margin = new Padding(1, 1, 0, 0);
            tb_Produktion_OD1_L2.MaxLength = 6;
            tb_Produktion_OD1_L2.Multiline = true;
            tb_Produktion_OD1_L2.Name = "tb_Produktion_OD1_L2";
            tb_Produktion_OD1_L2.Size = new Size(41, 41);
            tb_Produktion_OD1_L2.TabIndex = 16;
            tb_Produktion_OD1_L2.TextAlign = HorizontalAlignment.Center;
            tb_Produktion_OD1_L2.WordWrap = false;
            tb_Produktion_OD1_L2.KeyPress += Double_Values_Onyl_KeyPress;
            tb_Produktion_OD1_L2.Leave += ValidateData_TextLeave;
            // 
            // tb_Produktion_ODs_L1
            // 
            tb_Produktion_ODs_L1.BackColor = Color.White;
            tb_Produktion_ODs_L1.BorderStyle = BorderStyle.None;
            tb_Produktion_ODs_L1.Cursor = Cursors.IBeam;
            tb_Produktion_ODs_L1.Dock = DockStyle.Fill;
            tb_Produktion_ODs_L1.Enabled = false;
            tb_Produktion_ODs_L1.Font = new Font("Courier New", 8.5F);
            tb_Produktion_ODs_L1.ForeColor = Color.DarkSlateGray;
            tb_Produktion_ODs_L1.Location = new Point(343, 119);
            tb_Produktion_ODs_L1.Margin = new Padding(1, 1, 0, 0);
            tb_Produktion_ODs_L1.MaxLength = 6;
            tb_Produktion_ODs_L1.Multiline = true;
            tb_Produktion_ODs_L1.Name = "tb_Produktion_ODs_L1";
            tb_Produktion_ODs_L1.Size = new Size(41, 41);
            tb_Produktion_ODs_L1.TabIndex = 17;
            tb_Produktion_ODs_L1.TextAlign = HorizontalAlignment.Center;
            tb_Produktion_ODs_L1.WordWrap = false;
            tb_Produktion_ODs_L1.KeyPress += Double_Values_Onyl_KeyPress;
            tb_Produktion_ODs_L1.Leave += ValidateData_TextLeave;
            // 
            // tb_Produktion_ODs_L2
            // 
            tb_Produktion_ODs_L2.BackColor = Color.White;
            tb_Produktion_ODs_L2.BorderStyle = BorderStyle.None;
            tb_Produktion_ODs_L2.Cursor = Cursors.IBeam;
            tb_Produktion_ODs_L2.Dock = DockStyle.Fill;
            tb_Produktion_ODs_L2.Enabled = false;
            tb_Produktion_ODs_L2.Font = new Font("Courier New", 8.5F);
            tb_Produktion_ODs_L2.ForeColor = Color.DarkSlateGray;
            tb_Produktion_ODs_L2.Location = new Point(385, 119);
            tb_Produktion_ODs_L2.Margin = new Padding(1, 1, 1, 0);
            tb_Produktion_ODs_L2.MaxLength = 6;
            tb_Produktion_ODs_L2.Multiline = true;
            tb_Produktion_ODs_L2.Name = "tb_Produktion_ODs_L2";
            tb_Produktion_ODs_L2.Size = new Size(40, 41);
            tb_Produktion_ODs_L2.TabIndex = 18;
            tb_Produktion_ODs_L2.TextAlign = HorizontalAlignment.Center;
            tb_Produktion_ODs_L2.WordWrap = false;
            tb_Produktion_ODs_L2.KeyPress += Double_Values_Onyl_KeyPress;
            tb_Produktion_ODs_L2.Leave += ValidateData_TextLeave;
            // 
            // chb_Tråd_slut
            // 
            chb_Tråd_slut.AutoSize = true;
            chb_Tråd_slut.BackColor = Color.White;
            chb_Tråd_slut.CheckAlign = ContentAlignment.MiddleCenter;
            chb_Tråd_slut.Dock = DockStyle.Fill;
            chb_Tråd_slut.Enabled = false;
            chb_Tråd_slut.Location = new Point(507, 119);
            chb_Tråd_slut.Margin = new Padding(1, 1, 0, 0);
            chb_Tråd_slut.Name = "chb_Tråd_slut";
            chb_Tråd_slut.RightToLeft = RightToLeft.No;
            chb_Tråd_slut.Size = new Size(41, 41);
            chb_Tråd_slut.TabIndex = 19;
            chb_Tråd_slut.UseVisualStyleBackColor = false;
            // 
            // chb_Tråd_av
            // 
            chb_Tråd_av.AutoSize = true;
            chb_Tråd_av.BackColor = Color.White;
            chb_Tråd_av.CheckAlign = ContentAlignment.MiddleCenter;
            chb_Tråd_av.Dock = DockStyle.Fill;
            chb_Tråd_av.Enabled = false;
            chb_Tråd_av.Location = new Point(549, 119);
            chb_Tråd_av.Margin = new Padding(1, 1, 0, 0);
            chb_Tråd_av.Name = "chb_Tråd_av";
            chb_Tråd_av.RightToLeft = RightToLeft.No;
            chb_Tråd_av.Size = new Size(41, 41);
            chb_Tråd_av.TabIndex = 20;
            chb_Tråd_av.UseVisualStyleBackColor = false;
            // 
            // chb_Trasig_carrier
            // 
            chb_Trasig_carrier.AutoSize = true;
            chb_Trasig_carrier.BackColor = Color.White;
            chb_Trasig_carrier.CheckAlign = ContentAlignment.MiddleCenter;
            chb_Trasig_carrier.Dock = DockStyle.Fill;
            chb_Trasig_carrier.Enabled = false;
            chb_Trasig_carrier.Location = new Point(591, 119);
            chb_Trasig_carrier.Margin = new Padding(1, 1, 0, 0);
            chb_Trasig_carrier.Name = "chb_Trasig_carrier";
            chb_Trasig_carrier.RightToLeft = RightToLeft.No;
            chb_Trasig_carrier.Size = new Size(41, 41);
            chb_Trasig_carrier.TabIndex = 21;
            chb_Trasig_carrier.UseVisualStyleBackColor = false;
            // 
            // chb_Skarv
            // 
            chb_Skarv.AutoSize = true;
            chb_Skarv.BackColor = Color.White;
            chb_Skarv.CheckAlign = ContentAlignment.MiddleCenter;
            chb_Skarv.Dock = DockStyle.Fill;
            chb_Skarv.Enabled = false;
            chb_Skarv.Location = new Point(633, 119);
            chb_Skarv.Margin = new Padding(1, 1, 0, 0);
            chb_Skarv.Name = "chb_Skarv";
            chb_Skarv.RightToLeft = RightToLeft.No;
            chb_Skarv.Size = new Size(41, 41);
            chb_Skarv.TabIndex = 22;
            chb_Skarv.UseVisualStyleBackColor = false;
            // 
            // chb_Spole_slut
            // 
            chb_Spole_slut.AutoSize = true;
            chb_Spole_slut.BackColor = Color.White;
            chb_Spole_slut.CheckAlign = ContentAlignment.MiddleCenter;
            chb_Spole_slut.Dock = DockStyle.Fill;
            chb_Spole_slut.Enabled = false;
            chb_Spole_slut.Location = new Point(675, 119);
            chb_Spole_slut.Margin = new Padding(1, 1, 0, 0);
            chb_Spole_slut.Name = "chb_Spole_slut";
            chb_Spole_slut.RightToLeft = RightToLeft.No;
            chb_Spole_slut.Size = new Size(41, 41);
            chb_Spole_slut.TabIndex = 23;
            chb_Spole_slut.UseVisualStyleBackColor = false;
            // 
            // chb_Avslut_linje
            // 
            chb_Avslut_linje.AutoSize = true;
            chb_Avslut_linje.BackColor = Color.White;
            chb_Avslut_linje.CheckAlign = ContentAlignment.MiddleCenter;
            chb_Avslut_linje.Dock = DockStyle.Fill;
            chb_Avslut_linje.Enabled = false;
            chb_Avslut_linje.Location = new Point(717, 119);
            chb_Avslut_linje.Margin = new Padding(1, 1, 0, 0);
            chb_Avslut_linje.Name = "chb_Avslut_linje";
            chb_Avslut_linje.RightToLeft = RightToLeft.No;
            chb_Avslut_linje.Size = new Size(41, 41);
            chb_Avslut_linje.TabIndex = 24;
            chb_Avslut_linje.UseVisualStyleBackColor = false;
            // 
            // tb_Produktion_Kommentar
            // 
            tb_Produktion_Kommentar.BackColor = Color.White;
            tb_Produktion_Kommentar.BorderStyle = BorderStyle.None;
            tb_Produktion_Kommentar.Cursor = Cursors.IBeam;
            tb_Produktion_Kommentar.Dock = DockStyle.Fill;
            tb_Produktion_Kommentar.Enabled = false;
            tb_Produktion_Kommentar.Font = new Font("Consolas", 8.5F);
            tb_Produktion_Kommentar.ForeColor = Color.DarkSlateGray;
            tb_Produktion_Kommentar.Location = new Point(801, 119);
            tb_Produktion_Kommentar.Margin = new Padding(1, 1, 0, 0);
            tb_Produktion_Kommentar.MaxLength = 26;
            tb_Produktion_Kommentar.Multiline = true;
            tb_Produktion_Kommentar.Name = "tb_Produktion_Kommentar";
            tb_Produktion_Kommentar.Size = new Size(189, 41);
            tb_Produktion_Kommentar.TabIndex = 25;
            tb_Produktion_Kommentar.WordWrap = false;
            // 
            // label_Produktion_AnstNr
            // 
            label_Produktion_AnstNr.BackColor = Color.White;
            label_Produktion_AnstNr.Dock = DockStyle.Fill;
            label_Produktion_AnstNr.Font = new Font("Arial", 8.55F);
            label_Produktion_AnstNr.ForeColor = Color.Black;
            label_Produktion_AnstNr.Location = new Point(1140, 1);
            label_Produktion_AnstNr.Margin = new Padding(1, 1, 0, 1);
            label_Produktion_AnstNr.Name = "label_Produktion_AnstNr";
            tlp_Produktion.SetRowSpan(label_Produktion_AnstNr, 2);
            label_Produktion_AnstNr.Size = new Size(60, 44);
            label_Produktion_AnstNr.TabIndex = 1044;
            label_Produktion_AnstNr.Text = "Anst Nr";
            label_Produktion_AnstNr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Empty_14
            // 
            label_Empty_14.BackColor = Color.DarkGray;
            tlp_Produktion.SetColumnSpan(label_Empty_14, 4);
            label_Empty_14.Cursor = Cursors.SizeAll;
            label_Empty_14.Dock = DockStyle.Fill;
            label_Empty_14.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_14.ForeColor = Color.ForestGreen;
            label_Empty_14.Location = new Point(991, 118);
            label_Empty_14.Margin = new Padding(1, 0, 1, 0);
            label_Empty_14.Name = "label_Empty_14";
            label_Empty_14.Size = new Size(462, 42);
            label_Empty_14.TabIndex = 1037;
            label_Empty_14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chb_Avrapporterat
            // 
            chb_Avrapporterat.AutoSize = true;
            chb_Avrapporterat.BackColor = Color.White;
            chb_Avrapporterat.CheckAlign = ContentAlignment.MiddleCenter;
            chb_Avrapporterat.Dock = DockStyle.Fill;
            chb_Avrapporterat.Enabled = false;
            chb_Avrapporterat.Location = new Point(759, 119);
            chb_Avrapporterat.Margin = new Padding(1, 1, 0, 0);
            chb_Avrapporterat.Name = "chb_Avrapporterat";
            chb_Avrapporterat.RightToLeft = RightToLeft.No;
            chb_Avrapporterat.Size = new Size(41, 41);
            chb_Avrapporterat.TabIndex = 24;
            chb_Avrapporterat.UseVisualStyleBackColor = false;
            // 
            // label_Produktion_Avrapporterat
            // 
            label_Produktion_Avrapporterat.BackColor = Color.White;
            label_Produktion_Avrapporterat.Dock = DockStyle.Fill;
            label_Produktion_Avrapporterat.Font = new Font("Arial", 6.55F);
            label_Produktion_Avrapporterat.ForeColor = Color.Black;
            label_Produktion_Avrapporterat.Location = new Point(759, 1);
            label_Produktion_Avrapporterat.Margin = new Padding(1, 1, 0, 1);
            label_Produktion_Avrapporterat.Name = "label_Produktion_Avrapporterat";
            tlp_Produktion.SetRowSpan(label_Produktion_Avrapporterat, 2);
            label_Produktion_Avrapporterat.Size = new Size(41, 44);
            label_Produktion_Avrapporterat.TabIndex = 1036;
            label_Produktion_Avrapporterat.Text = "Avrapporterat";
            label_Produktion_Avrapporterat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainProtocol_Skärmning_TEF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainProtocol_Skärmning_TEF";
            Size = new Size(1458, 1032);
            tlp_Main.ResumeLayout(false);
            tlp_Maskinparametrar.ResumeLayout(false);
            tlp_Maskinparametrar.PerformLayout();
            tlp_ProduktInformation.ResumeLayout(false);
            tlp_ProduktInformation.PerformLayout();
            tlp_Produktion.ResumeLayout(false);
            tlp_Produktion.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private TableLayoutPanel tlp_Maskinparametrar;
        private Label label_Empty_11;
        private Label lbl_Antal_Trådar_nom;
        private Label label_Produktion_Skärmning;
        private Label label_Empty_9;
        private Label label_Empty_6;
        private Label label_Empty_5;
        private Label label_Empty_3;
        private Label label_Empty_2;
        private Label lbl_Pot_Maskin_Hastighet_nom;
        private Label label_Empty_1;
        private Label lbl_PPI_nom;
        private Label lbl_CarrierFjäder_nom;
        private Label label_MAX;
        private Label label_NOM;
        private Label label_MIN;
        private Label label_ODs_enhet;
        private Label label_Arbetsblad;
        private Label label_Helix_Vinkel;
        private Label label_Matarhjul_Vinkel;
        private Label label_MatarHjul_Hastighet;
        private Label label_Slipmaskin;
        private Label label_Empty_4;
        private Label label_Empty_7;
        private Label label_Empty_8;
        private Label label_Empty_10;
        private Label label_Antal_trådar;
        private Label label_Maskinparametrar;
        private TableLayoutPanel tlp_ProduktInformation;
        private Label lbl_Benämning;
        private Label label_Benämning;
        private Label label_Kund;
        private Label label_ArtikelNr;
        private Label label_Datum;
        private Label label_OrderNr;
        private Label Date_Start;
        private Label label_Namn;
        private Label Name_Start;
        private Label label_Produktinformation;
        private TabControl tab_ctrl_Arbetskort;
        private TableLayoutPanel tlp_Produktion;
        private Label label_Produktion_Sign;
        private Label label_Produktion_Tid;
        private Label lbl_Produktion_Temp_nom;
        private Label lbl_Produktion_Temp_max;
        private Label lbl_Produktion_Temp_min;
        private Label label_Empty_12;
        private Label label_Produktion_ID;
        private Label label_Produktion_MAX;
        private Label label_Produktion_NOM;
        private Label lbl_VerktygsID_max;
        private Label label_Produktion_MIN;
        private Label lbl_VerktygsID_min;
        private Label lbl_VerktygsID_nom;
        private Label label_Produktion_Datum;
        private Label label_Produktion_Mätare;
        private Label label_Produktion_Temp_L1;
        private Label label_Produktion_Temp;
        private Label label_Produktion_Temp_L2;
        private Label label_Produktion_ID_L1;
        private Label label_Produktion_ID_L2;
        private Label label_Produktion_OD1;
        private Label label_Produktion_OD1_L1;
        private Label label_VerktygsID_enhet;
        private Label label_Produktion_OD1_L2;
        private Label label_Produktion_ODs;
        private Label label_Bladhöjd;
        private Label label_Produktion_ODs_L1;
        private Label label_Produktion_ODs_L2;
        private Label label_Produktion_Tråd_slut;
        private Label label_Produktion_Tråd_av;
        private Label label_Produktion_Trasig_carrier;
        private Label label_Produktion_Skarv;
        private Label label_Produktion_Spole_slut;
        private Label label_Produktion_Avslut_linje;
        private Label label_Produktion_Kommentar;
        private Label lbl_Produktion_ID_min;
        private Label lbl_Produktion_OD1_min;
        private Label lbl_Produktion_ODs_min;
        private Label lbl_Produktion_ID_nom;
        private Label lbl_Produktion_OD1_nom;
        private Label lbl_Produktion_ODs_nom;
        private Label lbl_Produktion_ID_max;
        private Label lbl_Produktion_OD1_max;
        private Label lbl_Produktion_ODs_max;
        private Label label_Empty_13;
        private TextBox tb_Produktion_Temp_L1;
        private TextBox tb_Produktion_Temp_L2;
        private TextBox tb_Produktion_ID_L1;
        private TextBox tb_Produktion_ID_L2;
        private TextBox tb_Produktion_OD1_L1;
        private TextBox tb_Produktion_OD1_L2;
        private TextBox tb_Produktion_ODs_L1;
        private TextBox tb_Produktion_ODs_L2;
        private CheckBox chb_Tråd_slut;
        private CheckBox chb_Tråd_av;
        private CheckBox chb_Trasig_carrier;
        private CheckBox chb_Skarv;
        private CheckBox chb_Spole_slut;
        private CheckBox chb_Avslut_linje;
        private TextBox tb_Produktion_Kommentar;
        private Label label_Produktion_AnstNr;
        private Label label_Empty_14;
        private CheckBox chb_Avrapporterat;
        private Label label_Produktion_Avrapporterat;
        public TextBox Maskin_Hastighet_pot;
        public TextBox Tråd_Antal;
        public TextBox Travers_Hastighet_pot;
        public TextBox Carrier_fjäder;
        public TextBox PPI;
        public TextBox OD_oinsmält;
        public TextBox tb_Verktygs_ID;
        public Label lbl_OrderNr;
        public Label lbl_ArtikelNr;
        public Label lbl_Customer;
        public Label lbl_Kassera_Maskinparameter;
        public Label lbl_Transfer_Produktion;
        public Label lbl_Add_Arbetskort;
        public TextBox tb_Produktion_Mätare;
        private ExtraProtocols.PreFab PreFab;
    }
}
