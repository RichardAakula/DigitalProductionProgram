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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Kassera_Maskinparameter = new System.Windows.Forms.Label();
            this.tlp_Maskinparametrar = new System.Windows.Forms.TableLayoutPanel();
            this.label_Empty_11 = new System.Windows.Forms.Label();
            this.lbl_Antal_Trådar_nom = new System.Windows.Forms.Label();
            this.label_Produktion_Skärmning = new System.Windows.Forms.Label();
            this.label_Empty_9 = new System.Windows.Forms.Label();
            this.label_Empty_6 = new System.Windows.Forms.Label();
            this.label_Empty_5 = new System.Windows.Forms.Label();
            this.label_Empty_3 = new System.Windows.Forms.Label();
            this.label_Empty_2 = new System.Windows.Forms.Label();
            this.lbl_Pot_Maskin_Hastighet_nom = new System.Windows.Forms.Label();
            this.label_Empty_1 = new System.Windows.Forms.Label();
            this.Maskin_Hastighet_pot = new System.Windows.Forms.TextBox();
            this.lbl_PPI_nom = new System.Windows.Forms.Label();
            this.lbl_CarrierFjäder_nom = new System.Windows.Forms.Label();
            this.label_MAX = new System.Windows.Forms.Label();
            this.label_NOM = new System.Windows.Forms.Label();
            this.Tråd_Antal = new System.Windows.Forms.TextBox();
            this.label_MIN = new System.Windows.Forms.Label();
            this.label_ODs_enhet = new System.Windows.Forms.Label();
            this.label_Arbetsblad = new System.Windows.Forms.Label();
            this.label_Helix_Vinkel = new System.Windows.Forms.Label();
            this.label_Matarhjul_Vinkel = new System.Windows.Forms.Label();
            this.label_MatarHjul_Hastighet = new System.Windows.Forms.Label();
            this.label_Slipmaskin = new System.Windows.Forms.Label();
            this.label_Empty_4 = new System.Windows.Forms.Label();
            this.label_Empty_7 = new System.Windows.Forms.Label();
            this.label_Empty_8 = new System.Windows.Forms.Label();
            this.Travers_Hastighet_pot = new System.Windows.Forms.TextBox();
            this.Carrier_fjäder = new System.Windows.Forms.TextBox();
            this.PPI = new System.Windows.Forms.TextBox();
            this.OD_oinsmält = new System.Windows.Forms.TextBox();
            this.label_Empty_10 = new System.Windows.Forms.Label();
            this.label_Antal_trådar = new System.Windows.Forms.Label();
            this.label_Maskinparametrar = new System.Windows.Forms.Label();
            this.tlp_ProduktInformation = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_LotNr = new System.Windows.Forms.Label();
            this.label_Empty_15 = new System.Windows.Forms.Label();
            this.label_LotNr = new System.Windows.Forms.Label();
            this.lbl_Tråd_Material = new System.Windows.Forms.Label();
            this.label_Tråd_Benämning = new System.Windows.Forms.Label();
            this.lbl_Benämning = new System.Windows.Forms.Label();
            this.label_Benämning = new System.Windows.Forms.Label();
            this.lbl_OrderNr = new System.Windows.Forms.Label();
            this.lbl_ArtikelNr = new System.Windows.Forms.Label();
            this.label_Kund = new System.Windows.Forms.Label();
            this.label_ArtikelNr = new System.Windows.Forms.Label();
            this.label_Datum = new System.Windows.Forms.Label();
            this.label_OrderNr = new System.Windows.Forms.Label();
            this.lbl_Customer = new System.Windows.Forms.Label();
            this.Date_Start = new System.Windows.Forms.Label();
            this.label_Namn = new System.Windows.Forms.Label();
            this.Name_Start = new System.Windows.Forms.Label();
            this.label_Produktinformation = new System.Windows.Forms.Label();
            this.tab_ctrl_Arbetskort = new System.Windows.Forms.TabControl();
            this.tlp_Produktion = new System.Windows.Forms.TableLayoutPanel();
            this.label_Produktion_Sign = new System.Windows.Forms.Label();
            this.label_Produktion_Tid = new System.Windows.Forms.Label();
            this.lbl_Transfer_Produktion = new System.Windows.Forms.Label();
            this.lbl_Produktion_Temp_nom = new System.Windows.Forms.Label();
            this.lbl_Produktion_Temp_max = new System.Windows.Forms.Label();
            this.lbl_Produktion_Temp_min = new System.Windows.Forms.Label();
            this.label_Empty_12 = new System.Windows.Forms.Label();
            this.label_Produktion_ID = new System.Windows.Forms.Label();
            this.label_Produktion_MAX = new System.Windows.Forms.Label();
            this.label_Produktion_NOM = new System.Windows.Forms.Label();
            this.lbl_VerktygsID_max = new System.Windows.Forms.Label();
            this.label_Produktion_MIN = new System.Windows.Forms.Label();
            this.lbl_VerktygsID_min = new System.Windows.Forms.Label();
            this.lbl_VerktygsID_nom = new System.Windows.Forms.Label();
            this.lbl_Add_Arbetskort = new System.Windows.Forms.Label();
            this.label_Produktion_Datum = new System.Windows.Forms.Label();
            this.label_Produktion_Mätare = new System.Windows.Forms.Label();
            this.label_Produktion_Temp_L1 = new System.Windows.Forms.Label();
            this.label_Produktion_Temp = new System.Windows.Forms.Label();
            this.label_Produktion_Temp_L2 = new System.Windows.Forms.Label();
            this.label_Produktion_ID_L1 = new System.Windows.Forms.Label();
            this.label_Produktion_ID_L2 = new System.Windows.Forms.Label();
            this.label_Produktion_OD1 = new System.Windows.Forms.Label();
            this.label_Produktion_OD1_L1 = new System.Windows.Forms.Label();
            this.label_VerktygsID_enhet = new System.Windows.Forms.Label();
            this.label_Produktion_OD1_L2 = new System.Windows.Forms.Label();
            this.label_Produktion_ODs = new System.Windows.Forms.Label();
            this.label_Bladhöjd = new System.Windows.Forms.Label();
            this.label_Produktion_ODs_L1 = new System.Windows.Forms.Label();
            this.tb_Verktygs_ID = new System.Windows.Forms.TextBox();
            this.label_Produktion_ODs_L2 = new System.Windows.Forms.Label();
            this.label_Produktion_Tråd_slut = new System.Windows.Forms.Label();
            this.label_Produktion_Tråd_av = new System.Windows.Forms.Label();
            this.label_Produktion_Trasig_carrier = new System.Windows.Forms.Label();
            this.label_Produktion_Skarv = new System.Windows.Forms.Label();
            this.label_Produktion_Spole_slut = new System.Windows.Forms.Label();
            this.label_Produktion_Avslut_linje = new System.Windows.Forms.Label();
            this.label_Produktion_Kommentar = new System.Windows.Forms.Label();
            this.lbl_Produktion_ID_min = new System.Windows.Forms.Label();
            this.lbl_Produktion_OD1_min = new System.Windows.Forms.Label();
            this.lbl_Produktion_ODs_min = new System.Windows.Forms.Label();
            this.lbl_Produktion_ID_nom = new System.Windows.Forms.Label();
            this.lbl_Produktion_OD1_nom = new System.Windows.Forms.Label();
            this.lbl_Produktion_ODs_nom = new System.Windows.Forms.Label();
            this.lbl_Produktion_ID_max = new System.Windows.Forms.Label();
            this.lbl_Produktion_OD1_max = new System.Windows.Forms.Label();
            this.lbl_Produktion_ODs_max = new System.Windows.Forms.Label();
            this.label_Empty_13 = new System.Windows.Forms.Label();
            this.tb_Produktion_Mätare = new System.Windows.Forms.TextBox();
            this.tb_Produktion_Temp_L1 = new System.Windows.Forms.TextBox();
            this.tb_Produktion_Temp_L2 = new System.Windows.Forms.TextBox();
            this.tb_Produktion_ID_L1 = new System.Windows.Forms.TextBox();
            this.tb_Produktion_ID_L2 = new System.Windows.Forms.TextBox();
            this.tb_Produktion_OD1_L1 = new System.Windows.Forms.TextBox();
            this.tb_Produktion_OD1_L2 = new System.Windows.Forms.TextBox();
            this.tb_Produktion_ODs_L1 = new System.Windows.Forms.TextBox();
            this.tb_Produktion_ODs_L2 = new System.Windows.Forms.TextBox();
            this.chb_Tråd_slut = new System.Windows.Forms.CheckBox();
            this.chb_Tråd_av = new System.Windows.Forms.CheckBox();
            this.chb_Trasig_carrier = new System.Windows.Forms.CheckBox();
            this.chb_Skarv = new System.Windows.Forms.CheckBox();
            this.chb_Spole_slut = new System.Windows.Forms.CheckBox();
            this.chb_Avslut_linje = new System.Windows.Forms.CheckBox();
            this.tb_Produktion_Kommentar = new System.Windows.Forms.TextBox();
            this.label_Produktion_AnstNr = new System.Windows.Forms.Label();
            this.label_Empty_14 = new System.Windows.Forms.Label();
            this.chb_Avrapporterat = new System.Windows.Forms.CheckBox();
            this.label_Produktion_Avrapporterat = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            this.tlp_Maskinparametrar.SuspendLayout();
            this.tlp_ProduktInformation.SuspendLayout();
            this.tlp_Produktion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tlp_Main.ColumnCount = 3;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1047F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tlp_Main.Controls.Add(this.lbl_Kassera_Maskinparameter, 0, 6);
            this.tlp_Main.Controls.Add(this.tlp_Maskinparametrar, 0, 3);
            this.tlp_Main.Controls.Add(this.label_Maskinparametrar, 0, 2);
            this.tlp_Main.Controls.Add(this.tlp_ProduktInformation, 0, 1);
            this.tlp_Main.Controls.Add(this.label_Produktinformation, 0, 0);
            this.tlp_Main.Controls.Add(this.tab_ctrl_Arbetskort, 1, 6);
            this.tlp_Main.Controls.Add(this.tlp_Produktion, 0, 4);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(1);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 7;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 243F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(1250, 651);
            this.tlp_Main.TabIndex = 1;
            // 
            // lbl_Kassera_Maskinparameter
            // 
            this.lbl_Kassera_Maskinparameter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.lbl_Kassera_Maskinparameter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Kassera_Maskinparameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Kassera_Maskinparameter.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Kassera_Maskinparameter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_Kassera_Maskinparameter.Location = new System.Drawing.Point(3, 414);
            this.lbl_Kassera_Maskinparameter.Margin = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.lbl_Kassera_Maskinparameter.Name = "lbl_Kassera_Maskinparameter";
            this.lbl_Kassera_Maskinparameter.Size = new System.Drawing.Size(31, 21);
            this.lbl_Kassera_Maskinparameter.TabIndex = 1032;
            this.lbl_Kassera_Maskinparameter.Text = "→";
            this.lbl_Kassera_Maskinparameter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Kassera_Maskinparameter.Click += new System.EventHandler(this.Kassera_Rad_Produktion_Click);
            // 
            // tlp_Maskinparametrar
            // 
            this.tlp_Maskinparametrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tlp_Maskinparametrar.ColumnCount = 12;
            this.tlp_Main.SetColumnSpan(this.tlp_Maskinparametrar, 3);
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 453F));
            this.tlp_Maskinparametrar.Controls.Add(this.label_Empty_11, 0, 7);
            this.tlp_Maskinparametrar.Controls.Add(this.lbl_Antal_Trådar_nom, 1, 5);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Produktion_Skärmning, 0, 8);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Empty_9, 6, 4);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Empty_6, 4, 6);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Empty_5, 4, 4);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Empty_3, 1, 6);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Empty_2, 1, 4);
            this.tlp_Maskinparametrar.Controls.Add(this.lbl_Pot_Maskin_Hastighet_nom, 2, 5);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Empty_1, 0, 0);
            this.tlp_Maskinparametrar.Controls.Add(this.Maskin_Hastighet_pot, 2, 7);
            this.tlp_Maskinparametrar.Controls.Add(this.lbl_PPI_nom, 5, 5);
            this.tlp_Maskinparametrar.Controls.Add(this.lbl_CarrierFjäder_nom, 4, 5);
            this.tlp_Maskinparametrar.Controls.Add(this.label_MAX, 0, 6);
            this.tlp_Maskinparametrar.Controls.Add(this.label_NOM, 0, 5);
            this.tlp_Maskinparametrar.Controls.Add(this.Tråd_Antal, 1, 7);
            this.tlp_Maskinparametrar.Controls.Add(this.label_MIN, 0, 4);
            this.tlp_Maskinparametrar.Controls.Add(this.label_ODs_enhet, 6, 3);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Arbetsblad, 6, 0);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Helix_Vinkel, 5, 0);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Matarhjul_Vinkel, 4, 0);
            this.tlp_Maskinparametrar.Controls.Add(this.label_MatarHjul_Hastighet, 3, 0);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Slipmaskin, 2, 0);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Empty_4, 3, 4);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Empty_7, 5, 4);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Empty_8, 5, 6);
            this.tlp_Maskinparametrar.Controls.Add(this.Travers_Hastighet_pot, 3, 7);
            this.tlp_Maskinparametrar.Controls.Add(this.Carrier_fjäder, 4, 7);
            this.tlp_Maskinparametrar.Controls.Add(this.PPI, 5, 7);
            this.tlp_Maskinparametrar.Controls.Add(this.OD_oinsmält, 6, 7);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Empty_10, 7, 0);
            this.tlp_Maskinparametrar.Controls.Add(this.label_Antal_trådar, 1, 0);
            this.tlp_Maskinparametrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Maskinparametrar.Location = new System.Drawing.Point(3, 110);
            this.tlp_Maskinparametrar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tlp_Maskinparametrar.Name = "tlp_Maskinparametrar";
            this.tlp_Maskinparametrar.RowCount = 10;
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Maskinparametrar.Size = new System.Drawing.Size(1244, 175);
            this.tlp_Maskinparametrar.TabIndex = 1028;
            // 
            // label_Empty_11
            // 
            this.label_Empty_11.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_11.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_11.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_11.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_11.Location = new System.Drawing.Point(1, 128);
            this.label_Empty_11.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Empty_11.Name = "label_Empty_11";
            this.label_Empty_11.Size = new System.Drawing.Size(41, 21);
            this.label_Empty_11.TabIndex = 1023;
            this.label_Empty_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Antal_Trådar_nom
            // 
            this.lbl_Antal_Trådar_nom.AutoSize = true;
            this.lbl_Antal_Trådar_nom.BackColor = System.Drawing.Color.Silver;
            this.lbl_Antal_Trådar_nom.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Antal_Trådar_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Antal_Trådar_nom.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Antal_Trådar_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_Antal_Trådar_nom.Location = new System.Drawing.Point(43, 87);
            this.lbl_Antal_Trådar_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Antal_Trådar_nom.Name = "lbl_Antal_Trådar_nom";
            this.lbl_Antal_Trådar_nom.Size = new System.Drawing.Size(59, 19);
            this.lbl_Antal_Trådar_nom.TabIndex = 1022;
            this.lbl_Antal_Trådar_nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Skärmning
            // 
            this.label_Produktion_Skärmning.BackColor = System.Drawing.Color.LightGray;
            this.label_Produktion_Skärmning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlp_Maskinparametrar.SetColumnSpan(this.label_Produktion_Skärmning, 12);
            this.label_Produktion_Skärmning.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Produktion_Skärmning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Skärmning.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label_Produktion_Skärmning.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_Produktion_Skärmning.Location = new System.Drawing.Point(0, 149);
            this.label_Produktion_Skärmning.Margin = new System.Windows.Forms.Padding(0);
            this.label_Produktion_Skärmning.Name = "label_Produktion_Skärmning";
            this.label_Produktion_Skärmning.Size = new System.Drawing.Size(1244, 25);
            this.label_Produktion_Skärmning.TabIndex = 1021;
            this.label_Produktion_Skärmning.Text = "Produktion/Skärmning";
            this.label_Produktion_Skärmning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Empty_9
            // 
            this.label_Empty_9.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_9.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_9.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_9.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_9.Location = new System.Drawing.Point(387, 67);
            this.label_Empty_9.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Empty_9.Name = "label_Empty_9";
            this.tlp_Maskinparametrar.SetRowSpan(this.label_Empty_9, 3);
            this.label_Empty_9.Size = new System.Drawing.Size(80, 59);
            this.label_Empty_9.TabIndex = 1020;
            this.label_Empty_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_6
            // 
            this.label_Empty_6.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_6.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_6.Location = new System.Drawing.Point(241, 107);
            this.label_Empty_6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Empty_6.Name = "label_Empty_6";
            this.label_Empty_6.Size = new System.Drawing.Size(76, 19);
            this.label_Empty_6.TabIndex = 1019;
            this.label_Empty_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_5
            // 
            this.label_Empty_5.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_5.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_5.Location = new System.Drawing.Point(241, 67);
            this.label_Empty_5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Empty_5.Name = "label_Empty_5";
            this.label_Empty_5.Size = new System.Drawing.Size(76, 19);
            this.label_Empty_5.TabIndex = 1018;
            this.label_Empty_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_3
            // 
            this.label_Empty_3.BackColor = System.Drawing.Color.DarkGray;
            this.tlp_Maskinparametrar.SetColumnSpan(this.label_Empty_3, 2);
            this.label_Empty_3.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_3.Location = new System.Drawing.Point(43, 107);
            this.label_Empty_3.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Empty_3.Name = "label_Empty_3";
            this.label_Empty_3.Size = new System.Drawing.Size(127, 19);
            this.label_Empty_3.TabIndex = 1017;
            this.label_Empty_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_2
            // 
            this.label_Empty_2.BackColor = System.Drawing.Color.DarkGray;
            this.tlp_Maskinparametrar.SetColumnSpan(this.label_Empty_2, 2);
            this.label_Empty_2.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_2.Location = new System.Drawing.Point(43, 67);
            this.label_Empty_2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Empty_2.Name = "label_Empty_2";
            this.label_Empty_2.Size = new System.Drawing.Size(127, 19);
            this.label_Empty_2.TabIndex = 1015;
            this.label_Empty_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Pot_Maskin_Hastighet_nom
            // 
            this.lbl_Pot_Maskin_Hastighet_nom.AutoSize = true;
            this.lbl_Pot_Maskin_Hastighet_nom.BackColor = System.Drawing.Color.Silver;
            this.lbl_Pot_Maskin_Hastighet_nom.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Pot_Maskin_Hastighet_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Pot_Maskin_Hastighet_nom.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Pot_Maskin_Hastighet_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_Pot_Maskin_Hastighet_nom.Location = new System.Drawing.Point(103, 87);
            this.lbl_Pot_Maskin_Hastighet_nom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_Pot_Maskin_Hastighet_nom.Name = "lbl_Pot_Maskin_Hastighet_nom";
            this.lbl_Pot_Maskin_Hastighet_nom.Size = new System.Drawing.Size(66, 19);
            this.lbl_Pot_Maskin_Hastighet_nom.TabIndex = 1014;
            this.lbl_Pot_Maskin_Hastighet_nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_1
            // 
            this.label_Empty_1.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_1.Location = new System.Drawing.Point(1, 0);
            this.label_Empty_1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Empty_1.Name = "label_Empty_1";
            this.tlp_Maskinparametrar.SetRowSpan(this.label_Empty_1, 4);
            this.label_Empty_1.Size = new System.Drawing.Size(41, 66);
            this.label_Empty_1.TabIndex = 1007;
            this.label_Empty_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Maskin_Hastighet_pot
            // 
            this.Maskin_Hastighet_pot.BackColor = System.Drawing.Color.White;
            this.Maskin_Hastighet_pot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Maskin_Hastighet_pot.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Maskin_Hastighet_pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Maskin_Hastighet_pot.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.Maskin_Hastighet_pot.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Maskin_Hastighet_pot.Location = new System.Drawing.Point(103, 128);
            this.Maskin_Hastighet_pot.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.Maskin_Hastighet_pot.MaxLength = 4;
            this.Maskin_Hastighet_pot.Multiline = true;
            this.Maskin_Hastighet_pot.Name = "Maskin_Hastighet_pot";
            this.Maskin_Hastighet_pot.Size = new System.Drawing.Size(67, 21);
            this.Maskin_Hastighet_pot.TabIndex = 1;
            this.Maskin_Hastighet_pot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Maskin_Hastighet_pot.WordWrap = false;
            this.Maskin_Hastighet_pot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this. Int_Values_Only_KeyPress);
            this.Maskin_Hastighet_pot.Leave += new System.EventHandler(this.Save_Korprotokoll_Leave);
            // 
            // lbl_PPI_nom
            // 
            this.lbl_PPI_nom.AutoSize = true;
            this.lbl_PPI_nom.BackColor = System.Drawing.Color.Silver;
            this.lbl_PPI_nom.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_PPI_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_PPI_nom.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_PPI_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_PPI_nom.Location = new System.Drawing.Point(318, 87);
            this.lbl_PPI_nom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_PPI_nom.Name = "lbl_PPI_nom";
            this.lbl_PPI_nom.Size = new System.Drawing.Size(68, 19);
            this.lbl_PPI_nom.TabIndex = 986;
            this.lbl_PPI_nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CarrierFjäder_nom
            // 
            this.lbl_CarrierFjäder_nom.AutoSize = true;
            this.lbl_CarrierFjäder_nom.BackColor = System.Drawing.Color.Silver;
            this.lbl_CarrierFjäder_nom.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_CarrierFjäder_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_CarrierFjäder_nom.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_CarrierFjäder_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_CarrierFjäder_nom.Location = new System.Drawing.Point(242, 87);
            this.lbl_CarrierFjäder_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_CarrierFjäder_nom.Name = "lbl_CarrierFjäder_nom";
            this.lbl_CarrierFjäder_nom.Size = new System.Drawing.Size(75, 19);
            this.lbl_CarrierFjäder_nom.TabIndex = 985;
            this.lbl_CarrierFjäder_nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_MAX
            // 
            this.label_MAX.BackColor = System.Drawing.Color.Silver;
            this.label_MAX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MAX.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MAX.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_MAX.Location = new System.Drawing.Point(1, 107);
            this.label_MAX.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_MAX.Name = "label_MAX";
            this.label_MAX.Size = new System.Drawing.Size(41, 19);
            this.label_MAX.TabIndex = 838;
            this.label_MAX.Text = "MAX";
            this.label_MAX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_NOM
            // 
            this.label_NOM.BackColor = System.Drawing.Color.Silver;
            this.label_NOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_NOM.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NOM.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_NOM.Location = new System.Drawing.Point(1, 87);
            this.label_NOM.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_NOM.Name = "label_NOM";
            this.label_NOM.Size = new System.Drawing.Size(41, 19);
            this.label_NOM.TabIndex = 824;
            this.label_NOM.Text = "NOM";
            this.label_NOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tråd_Antal
            // 
            this.Tråd_Antal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tråd_Antal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tråd_Antal.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.Tråd_Antal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Tråd_Antal.Location = new System.Drawing.Point(43, 128);
            this.Tråd_Antal.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.Tråd_Antal.MaxLength = 6;
            this.Tråd_Antal.Multiline = true;
            this.Tråd_Antal.Name = "Tråd_Antal";
            this.Tråd_Antal.Size = new System.Drawing.Size(59, 21);
            this.Tråd_Antal.TabIndex = 0;
            this.Tråd_Antal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Tråd_Antal.Leave += new System.EventHandler(this.Save_Korprotokoll_Leave);
            // 
            // label_MIN
            // 
            this.label_MIN.BackColor = System.Drawing.Color.Silver;
            this.label_MIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MIN.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MIN.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_MIN.Location = new System.Drawing.Point(1, 67);
            this.label_MIN.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_MIN.Name = "label_MIN";
            this.label_MIN.Size = new System.Drawing.Size(41, 19);
            this.label_MIN.TabIndex = 819;
            this.label_MIN.Text = "MIN";
            this.label_MIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ODs_enhet
            // 
            this.label_ODs_enhet.BackColor = System.Drawing.Color.White;
            this.label_ODs_enhet.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_ODs_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ODs_enhet.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.label_ODs_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_ODs_enhet.Location = new System.Drawing.Point(388, 53);
            this.label_ODs_enhet.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_ODs_enhet.Name = "label_ODs_enhet";
            this.label_ODs_enhet.Size = new System.Drawing.Size(78, 13);
            this.label_ODs_enhet.TabIndex = 818;
            this.label_ODs_enhet.Text = "mm";
            this.label_ODs_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Arbetsblad
            // 
            this.label_Arbetsblad.BackColor = System.Drawing.Color.White;
            this.label_Arbetsblad.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Arbetsblad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Arbetsblad.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Arbetsblad.ForeColor = System.Drawing.Color.Black;
            this.label_Arbetsblad.Location = new System.Drawing.Point(388, 0);
            this.label_Arbetsblad.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Arbetsblad.Name = "label_Arbetsblad";
            this.tlp_Maskinparametrar.SetRowSpan(this.label_Arbetsblad, 3);
            this.label_Arbetsblad.Size = new System.Drawing.Size(78, 53);
            this.label_Arbetsblad.TabIndex = 137;
            this.label_Arbetsblad.Text = "ODs oinsmält";
            this.label_Arbetsblad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Helix_Vinkel
            // 
            this.label_Helix_Vinkel.BackColor = System.Drawing.Color.White;
            this.label_Helix_Vinkel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Helix_Vinkel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Helix_Vinkel.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Helix_Vinkel.ForeColor = System.Drawing.Color.Black;
            this.label_Helix_Vinkel.Location = new System.Drawing.Point(318, 0);
            this.label_Helix_Vinkel.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Helix_Vinkel.Name = "label_Helix_Vinkel";
            this.tlp_Maskinparametrar.SetRowSpan(this.label_Helix_Vinkel, 4);
            this.label_Helix_Vinkel.Size = new System.Drawing.Size(69, 66);
            this.label_Helix_Vinkel.TabIndex = 134;
            this.label_Helix_Vinkel.Text = "PPI";
            this.label_Helix_Vinkel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Matarhjul_Vinkel
            // 
            this.label_Matarhjul_Vinkel.BackColor = System.Drawing.Color.White;
            this.label_Matarhjul_Vinkel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Matarhjul_Vinkel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Matarhjul_Vinkel.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Matarhjul_Vinkel.ForeColor = System.Drawing.Color.Black;
            this.label_Matarhjul_Vinkel.Location = new System.Drawing.Point(242, 0);
            this.label_Matarhjul_Vinkel.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Matarhjul_Vinkel.Name = "label_Matarhjul_Vinkel";
            this.tlp_Maskinparametrar.SetRowSpan(this.label_Matarhjul_Vinkel, 4);
            this.label_Matarhjul_Vinkel.Size = new System.Drawing.Size(75, 66);
            this.label_Matarhjul_Vinkel.TabIndex = 133;
            this.label_Matarhjul_Vinkel.Text = "Carrier fjäder";
            this.label_Matarhjul_Vinkel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_MatarHjul_Hastighet
            // 
            this.label_MatarHjul_Hastighet.BackColor = System.Drawing.Color.White;
            this.label_MatarHjul_Hastighet.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_MatarHjul_Hastighet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MatarHjul_Hastighet.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_MatarHjul_Hastighet.ForeColor = System.Drawing.Color.Black;
            this.label_MatarHjul_Hastighet.Location = new System.Drawing.Point(171, 0);
            this.label_MatarHjul_Hastighet.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_MatarHjul_Hastighet.Name = "label_MatarHjul_Hastighet";
            this.label_MatarHjul_Hastighet.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tlp_Maskinparametrar.SetRowSpan(this.label_MatarHjul_Hastighet, 4);
            this.label_MatarHjul_Hastighet.Size = new System.Drawing.Size(70, 66);
            this.label_MatarHjul_Hastighet.TabIndex = 131;
            this.label_MatarHjul_Hastighet.Text = "Pot. Travers Hastighet";
            this.label_MatarHjul_Hastighet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Slipmaskin
            // 
            this.label_Slipmaskin.BackColor = System.Drawing.Color.White;
            this.label_Slipmaskin.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Slipmaskin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Slipmaskin.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Slipmaskin.ForeColor = System.Drawing.Color.Black;
            this.label_Slipmaskin.Location = new System.Drawing.Point(103, 0);
            this.label_Slipmaskin.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Slipmaskin.Name = "label_Slipmaskin";
            this.tlp_Maskinparametrar.SetRowSpan(this.label_Slipmaskin, 4);
            this.label_Slipmaskin.Size = new System.Drawing.Size(67, 66);
            this.label_Slipmaskin.TabIndex = 130;
            this.label_Slipmaskin.Text = "Pot. Maskin Hastighet";
            this.label_Slipmaskin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_4
            // 
            this.label_Empty_4.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_4.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_4.Location = new System.Drawing.Point(170, 67);
            this.label_Empty_4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Empty_4.Name = "label_Empty_4";
            this.tlp_Maskinparametrar.SetRowSpan(this.label_Empty_4, 3);
            this.label_Empty_4.Size = new System.Drawing.Size(71, 59);
            this.label_Empty_4.TabIndex = 1007;
            this.label_Empty_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_7
            // 
            this.label_Empty_7.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_7.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_7.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_7.Location = new System.Drawing.Point(317, 67);
            this.label_Empty_7.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Empty_7.Name = "label_Empty_7";
            this.label_Empty_7.Size = new System.Drawing.Size(70, 19);
            this.label_Empty_7.TabIndex = 1007;
            this.label_Empty_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_8
            // 
            this.label_Empty_8.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_8.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_8.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_8.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_8.Location = new System.Drawing.Point(317, 107);
            this.label_Empty_8.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Empty_8.Name = "label_Empty_8";
            this.label_Empty_8.Size = new System.Drawing.Size(70, 19);
            this.label_Empty_8.TabIndex = 1008;
            this.label_Empty_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Travers_Hastighet_pot
            // 
            this.Travers_Hastighet_pot.BackColor = System.Drawing.Color.White;
            this.Travers_Hastighet_pot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Travers_Hastighet_pot.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Travers_Hastighet_pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Travers_Hastighet_pot.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.Travers_Hastighet_pot.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Travers_Hastighet_pot.Location = new System.Drawing.Point(171, 128);
            this.Travers_Hastighet_pot.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.Travers_Hastighet_pot.MaxLength = 5;
            this.Travers_Hastighet_pot.Multiline = true;
            this.Travers_Hastighet_pot.Name = "Travers_Hastighet_pot";
            this.Travers_Hastighet_pot.Size = new System.Drawing.Size(70, 21);
            this.Travers_Hastighet_pot.TabIndex = 2;
            this.Travers_Hastighet_pot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Travers_Hastighet_pot.WordWrap = false;
            this.Travers_Hastighet_pot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Int_Values_Only_KeyPress);
            this.Travers_Hastighet_pot.Leave += new System.EventHandler(this.Save_Korprotokoll_Leave);
            // 
            // Carrier_fjäder
            // 
            this.Carrier_fjäder.BackColor = System.Drawing.Color.White;
            this.Carrier_fjäder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Carrier_fjäder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Carrier_fjäder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Carrier_fjäder.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.Carrier_fjäder.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Carrier_fjäder.Location = new System.Drawing.Point(242, 128);
            this.Carrier_fjäder.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.Carrier_fjäder.MaxLength = 6;
            this.Carrier_fjäder.Multiline = true;
            this.Carrier_fjäder.Name = "Carrier_fjäder";
            this.Carrier_fjäder.Size = new System.Drawing.Size(75, 21);
            this.Carrier_fjäder.TabIndex = 3;
            this.Carrier_fjäder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Carrier_fjäder.WordWrap = false;
            this.Carrier_fjäder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Double_Values_Onyl_KeyPress);
            this.Carrier_fjäder.Leave += new System.EventHandler(this.Save_Korprotokoll_Leave);
            // 
            // PPI
            // 
            this.PPI.BackColor = System.Drawing.Color.White;
            this.PPI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PPI.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PPI.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.PPI.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.PPI.Location = new System.Drawing.Point(318, 128);
            this.PPI.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.PPI.MaxLength = 6;
            this.PPI.Multiline = true;
            this.PPI.Name = "PPI";
            this.PPI.Size = new System.Drawing.Size(69, 21);
            this.PPI.TabIndex = 4;
            this.PPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PPI.WordWrap = false;
            this.PPI.Leave += new System.EventHandler(this.Save_Korprotokoll_Leave);
            // 
            // OD_oinsmält
            // 
            this.OD_oinsmält.BackColor = System.Drawing.Color.White;
            this.OD_oinsmält.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OD_oinsmält.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OD_oinsmält.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OD_oinsmält.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.OD_oinsmält.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.OD_oinsmält.Location = new System.Drawing.Point(388, 128);
            this.OD_oinsmält.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.OD_oinsmält.MaxLength = 6;
            this.OD_oinsmält.Multiline = true;
            this.OD_oinsmält.Name = "OD_oinsmält";
            this.OD_oinsmält.Size = new System.Drawing.Size(78, 21);
            this.OD_oinsmält.TabIndex = 5;
            this.OD_oinsmält.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OD_oinsmält.WordWrap = false;
            this.OD_oinsmält.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Double_Values_Onyl_KeyPress);
            this.OD_oinsmält.Leave += new System.EventHandler(this.Save_Korprotokoll_Leave);
            // 
            // label_Empty_10
            // 
            this.label_Empty_10.BackColor = System.Drawing.Color.DarkGray;
            this.tlp_Maskinparametrar.SetColumnSpan(this.label_Empty_10, 5);
            this.label_Empty_10.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_10.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_10.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_10.Location = new System.Drawing.Point(467, 0);
            this.label_Empty_10.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.label_Empty_10.Name = "label_Empty_10";
            this.tlp_Maskinparametrar.SetRowSpan(this.label_Empty_10, 8);
            this.label_Empty_10.Size = new System.Drawing.Size(776, 149);
            this.label_Empty_10.TabIndex = 1020;
            this.label_Empty_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Antal_trådar
            // 
            this.label_Antal_trådar.BackColor = System.Drawing.Color.White;
            this.label_Antal_trådar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Antal_trådar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Antal_trådar.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Antal_trådar.ForeColor = System.Drawing.Color.Black;
            this.label_Antal_trådar.Location = new System.Drawing.Point(43, 0);
            this.label_Antal_trådar.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Antal_trådar.Name = "label_Antal_trådar";
            this.tlp_Maskinparametrar.SetRowSpan(this.label_Antal_trådar, 4);
            this.label_Antal_trådar.Size = new System.Drawing.Size(59, 66);
            this.label_Antal_trådar.TabIndex = 130;
            this.label_Antal_trådar.Text = "Antal Trådar";
            this.label_Antal_trådar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Maskinparametrar
            // 
            this.label_Maskinparametrar.BackColor = System.Drawing.Color.LightGray;
            this.label_Maskinparametrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlp_Main.SetColumnSpan(this.label_Maskinparametrar, 4);
            this.label_Maskinparametrar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Maskinparametrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Maskinparametrar.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label_Maskinparametrar.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_Maskinparametrar.Location = new System.Drawing.Point(3, 90);
            this.label_Maskinparametrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.label_Maskinparametrar.Name = "label_Maskinparametrar";
            this.label_Maskinparametrar.Size = new System.Drawing.Size(1244, 20);
            this.label_Maskinparametrar.TabIndex = 1027;
            this.label_Maskinparametrar.Text = "Maskinparametrar";
            this.label_Maskinparametrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlp_ProduktInformation
            // 
            this.tlp_ProduktInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tlp_ProduktInformation.ColumnCount = 6;
            this.tlp_Main.SetColumnSpan(this.tlp_ProduktInformation, 3);
            this.tlp_ProduktInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_ProduktInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 444F));
            this.tlp_ProduktInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tlp_ProduktInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 279F));
            this.tlp_ProduktInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tlp_ProduktInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.tlp_ProduktInformation.Controls.Add(this.lbl_LotNr, 3, 2);
            this.tlp_ProduktInformation.Controls.Add(this.label_Empty_15, 4, 2);
            this.tlp_ProduktInformation.Controls.Add(this.label_LotNr, 2, 2);
            this.tlp_ProduktInformation.Controls.Add(this.lbl_Tråd_Material, 1, 2);
            this.tlp_ProduktInformation.Controls.Add(this.label_Tråd_Benämning, 0, 2);
            this.tlp_ProduktInformation.Controls.Add(this.lbl_Benämning, 1, 1);
            this.tlp_ProduktInformation.Controls.Add(this.label_Benämning, 0, 1);
            this.tlp_ProduktInformation.Controls.Add(this.lbl_OrderNr, 5, 0);
            this.tlp_ProduktInformation.Controls.Add(this.lbl_ArtikelNr, 5, 1);
            this.tlp_ProduktInformation.Controls.Add(this.label_Kund, 0, 0);
            this.tlp_ProduktInformation.Controls.Add(this.label_ArtikelNr, 4, 1);
            this.tlp_ProduktInformation.Controls.Add(this.label_Datum, 2, 0);
            this.tlp_ProduktInformation.Controls.Add(this.label_OrderNr, 4, 0);
            this.tlp_ProduktInformation.Controls.Add(this.lbl_Customer, 1, 0);
            this.tlp_ProduktInformation.Controls.Add(this.Date_Start, 3, 0);
            this.tlp_ProduktInformation.Controls.Add(this.label_Namn, 2, 1);
            this.tlp_ProduktInformation.Controls.Add(this.Name_Start, 3, 1);
            this.tlp_ProduktInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_ProduktInformation.Location = new System.Drawing.Point(3, 25);
            this.tlp_ProduktInformation.Name = "tlp_ProduktInformation";
            this.tlp_ProduktInformation.RowCount = 4;
            this.tlp_ProduktInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_ProduktInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_ProduktInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_ProduktInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_ProduktInformation.Size = new System.Drawing.Size(1244, 60);
            this.tlp_ProduktInformation.TabIndex = 1026;
            // 
            // lbl_LotNr
            // 
            this.lbl_LotNr.AutoSize = true;
            this.lbl_LotNr.BackColor = System.Drawing.Color.White;
            this.lbl_LotNr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_LotNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_LotNr.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lbl_LotNr.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_LotNr.Location = new System.Drawing.Point(622, 40);
            this.lbl_LotNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_LotNr.Name = "lbl_LotNr";
            this.lbl_LotNr.Size = new System.Drawing.Size(278, 20);
            this.lbl_LotNr.TabIndex = 1025;
            this.lbl_LotNr.Click += new System.EventHandler(this.LotNr_Click);
            // 
            // label_Empty_15
            // 
            this.label_Empty_15.BackColor = System.Drawing.Color.DarkGray;
            this.tlp_ProduktInformation.SetColumnSpan(this.label_Empty_15, 2);
            this.label_Empty_15.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_15.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_15.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_15.Location = new System.Drawing.Point(901, 40);
            this.label_Empty_15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Empty_15.Name = "label_Empty_15";
            this.label_Empty_15.Size = new System.Drawing.Size(342, 20);
            this.label_Empty_15.TabIndex = 1023;
            this.label_Empty_15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_LotNr
            // 
            this.label_LotNr.BackColor = System.Drawing.Color.White;
            this.label_LotNr.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_LotNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LotNr.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label_LotNr.ForeColor = System.Drawing.Color.Black;
            this.label_LotNr.Location = new System.Drawing.Point(545, 40);
            this.label_LotNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_LotNr.Name = "label_LotNr";
            this.label_LotNr.Size = new System.Drawing.Size(76, 20);
            this.label_LotNr.TabIndex = 921;
            this.label_LotNr.Text = "Lot nr.";
            this.label_LotNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Tråd_Material
            // 
            this.lbl_Tråd_Material.BackColor = System.Drawing.Color.White;
            this.lbl_Tråd_Material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Tråd_Material.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lbl_Tråd_Material.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Tråd_Material.Location = new System.Drawing.Point(101, 40);
            this.lbl_Tråd_Material.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_Tråd_Material.Name = "lbl_Tråd_Material";
            this.lbl_Tråd_Material.Size = new System.Drawing.Size(443, 20);
            this.lbl_Tråd_Material.TabIndex = 920;
            this.lbl_Tråd_Material.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Tråd_Benämning
            // 
            this.label_Tråd_Benämning.BackColor = System.Drawing.Color.White;
            this.label_Tråd_Benämning.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Tråd_Benämning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Tråd_Benämning.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label_Tråd_Benämning.ForeColor = System.Drawing.Color.Black;
            this.label_Tråd_Benämning.Location = new System.Drawing.Point(1, 40);
            this.label_Tråd_Benämning.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Tråd_Benämning.Name = "label_Tråd_Benämning";
            this.label_Tråd_Benämning.Size = new System.Drawing.Size(99, 20);
            this.label_Tråd_Benämning.TabIndex = 919;
            this.label_Tråd_Benämning.Text = "Tråd Benämning";
            this.label_Tråd_Benämning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Benämning
            // 
            this.lbl_Benämning.BackColor = System.Drawing.Color.White;
            this.lbl_Benämning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Benämning.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lbl_Benämning.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Benämning.Location = new System.Drawing.Point(101, 20);
            this.lbl_Benämning.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Benämning.Name = "lbl_Benämning";
            this.lbl_Benämning.Size = new System.Drawing.Size(443, 19);
            this.lbl_Benämning.TabIndex = 916;
            this.lbl_Benämning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Benämning
            // 
            this.label_Benämning.BackColor = System.Drawing.Color.White;
            this.label_Benämning.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Benämning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Benämning.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label_Benämning.ForeColor = System.Drawing.Color.Black;
            this.label_Benämning.Location = new System.Drawing.Point(1, 20);
            this.label_Benämning.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Benämning.Name = "label_Benämning";
            this.label_Benämning.Size = new System.Drawing.Size(99, 19);
            this.label_Benämning.TabIndex = 915;
            this.label_Benämning.Text = "Benämning";
            this.label_Benämning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderNr
            // 
            this.lbl_OrderNr.AutoSize = true;
            this.lbl_OrderNr.BackColor = System.Drawing.Color.White;
            this.lbl_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderNr.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lbl_OrderNr.ForeColor = System.Drawing.Color.Gray;
            this.lbl_OrderNr.Location = new System.Drawing.Point(998, 0);
            this.lbl_OrderNr.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_OrderNr.Name = "lbl_OrderNr";
            this.lbl_OrderNr.Size = new System.Drawing.Size(245, 19);
            this.lbl_OrderNr.TabIndex = 135;
            this.lbl_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_ArtikelNr
            // 
            this.lbl_ArtikelNr.AutoSize = true;
            this.lbl_ArtikelNr.BackColor = System.Drawing.Color.White;
            this.lbl_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ArtikelNr.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lbl_ArtikelNr.ForeColor = System.Drawing.Color.Gray;
            this.lbl_ArtikelNr.Location = new System.Drawing.Point(998, 20);
            this.lbl_ArtikelNr.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_ArtikelNr.Name = "lbl_ArtikelNr";
            this.lbl_ArtikelNr.Size = new System.Drawing.Size(245, 19);
            this.lbl_ArtikelNr.TabIndex = 134;
            this.lbl_ArtikelNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Kund
            // 
            this.label_Kund.BackColor = System.Drawing.Color.White;
            this.label_Kund.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Kund.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Kund.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label_Kund.ForeColor = System.Drawing.Color.Black;
            this.label_Kund.Location = new System.Drawing.Point(1, 0);
            this.label_Kund.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Kund.Name = "label_Kund";
            this.label_Kund.Size = new System.Drawing.Size(99, 19);
            this.label_Kund.TabIndex = 128;
            this.label_Kund.Text = "Kund";
            this.label_Kund.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ArtikelNr
            // 
            this.label_ArtikelNr.BackColor = System.Drawing.Color.White;
            this.label_ArtikelNr.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ArtikelNr.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label_ArtikelNr.ForeColor = System.Drawing.Color.Black;
            this.label_ArtikelNr.Location = new System.Drawing.Point(901, 20);
            this.label_ArtikelNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_ArtikelNr.Name = "label_ArtikelNr";
            this.label_ArtikelNr.Size = new System.Drawing.Size(96, 19);
            this.label_ArtikelNr.TabIndex = 130;
            this.label_ArtikelNr.Text = "ArtikelNr";
            this.label_ArtikelNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Datum
            // 
            this.label_Datum.BackColor = System.Drawing.Color.White;
            this.label_Datum.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Datum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Datum.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label_Datum.ForeColor = System.Drawing.Color.Black;
            this.label_Datum.Location = new System.Drawing.Point(545, 0);
            this.label_Datum.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Datum.Name = "label_Datum";
            this.label_Datum.Size = new System.Drawing.Size(76, 19);
            this.label_Datum.TabIndex = 130;
            this.label_Datum.Text = "Datum";
            this.label_Datum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr
            // 
            this.label_OrderNr.BackColor = System.Drawing.Color.White;
            this.label_OrderNr.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OrderNr.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label_OrderNr.ForeColor = System.Drawing.Color.Black;
            this.label_OrderNr.Location = new System.Drawing.Point(901, 0);
            this.label_OrderNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_OrderNr.Name = "label_OrderNr";
            this.label_OrderNr.Size = new System.Drawing.Size(96, 19);
            this.label_OrderNr.TabIndex = 130;
            this.label_OrderNr.Text = "OrderNr";
            this.label_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Customer
            // 
            this.lbl_Customer.AutoSize = true;
            this.lbl_Customer.BackColor = System.Drawing.Color.White;
            this.lbl_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Customer.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lbl_Customer.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Customer.Location = new System.Drawing.Point(101, 0);
            this.lbl_Customer.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Customer.Name = "lbl_Customer";
            this.lbl_Customer.Size = new System.Drawing.Size(443, 19);
            this.lbl_Customer.TabIndex = 132;
            // 
            // Date_Start
            // 
            this.Date_Start.BackColor = System.Drawing.Color.White;
            this.Date_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Date_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Date_Start.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.Date_Start.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Date_Start.Location = new System.Drawing.Point(622, 0);
            this.Date_Start.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.Date_Start.Name = "Date_Start";
            this.Date_Start.Size = new System.Drawing.Size(278, 19);
            this.Date_Start.TabIndex = 914;
            this.Date_Start.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Date_Start.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Date_MouseDown);
            // 
            // label_Namn
            // 
            this.label_Namn.BackColor = System.Drawing.Color.White;
            this.label_Namn.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Namn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Namn.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label_Namn.ForeColor = System.Drawing.Color.Black;
            this.label_Namn.Location = new System.Drawing.Point(545, 20);
            this.label_Namn.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Namn.Name = "label_Namn";
            this.label_Namn.Size = new System.Drawing.Size(76, 19);
            this.label_Namn.TabIndex = 917;
            this.label_Namn.Text = "Namn";
            this.label_Namn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Name_Start
            // 
            this.Name_Start.AutoSize = true;
            this.Name_Start.BackColor = System.Drawing.Color.White;
            this.Name_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name_Start.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.Name_Start.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Name_Start.Location = new System.Drawing.Point(622, 20);
            this.Name_Start.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.Name_Start.Name = "Name_Start";
            this.Name_Start.Size = new System.Drawing.Size(278, 19);
            this.Name_Start.TabIndex = 1024;
            this.Name_Start.Click += new System.EventHandler(this.Name_Click);
            // 
            // label_Produktinformation
            // 
            this.label_Produktinformation.BackColor = System.Drawing.Color.LightGray;
            this.label_Produktinformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlp_Main.SetColumnSpan(this.label_Produktinformation, 4);
            this.label_Produktinformation.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Produktinformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktinformation.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label_Produktinformation.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_Produktinformation.Location = new System.Drawing.Point(0, 0);
            this.label_Produktinformation.Margin = new System.Windows.Forms.Padding(0);
            this.label_Produktinformation.Name = "label_Produktinformation";
            this.label_Produktinformation.Size = new System.Drawing.Size(1250, 22);
            this.label_Produktinformation.TabIndex = 1025;
            this.label_Produktinformation.Text = "Produktinformation";
            this.label_Produktinformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tab_ctrl_Arbetskort
            // 
            this.tlp_Main.SetColumnSpan(this.tab_ctrl_Arbetskort, 2);
            this.tab_ctrl_Arbetskort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_ctrl_Arbetskort.Location = new System.Drawing.Point(36, 412);
            this.tab_ctrl_Arbetskort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.tab_ctrl_Arbetskort.Name = "tab_ctrl_Arbetskort";
            this.tab_ctrl_Arbetskort.SelectedIndex = 0;
            this.tab_ctrl_Arbetskort.Size = new System.Drawing.Size(1212, 241);
            this.tab_ctrl_Arbetskort.TabIndex = 1022;
            // 
            // tlp_Produktion
            // 
            this.tlp_Produktion.ColumnCount = 24;
            this.tlp_Main.SetColumnSpan(this.tlp_Produktion, 3);
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlp_Produktion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Sign, 23, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Tid, 21, 0);
            this.tlp_Produktion.Controls.Add(this.lbl_Transfer_Produktion, 0, 5);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_Temp_nom, 3, 3);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_Temp_max, 3, 4);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_Temp_min, 3, 2);
            this.tlp_Produktion.Controls.Add(this.label_Empty_12, 2, 2);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_ID, 5, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_MAX, 0, 4);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_NOM, 0, 3);
            this.tlp_Produktion.Controls.Add(this.lbl_VerktygsID_max, 11, 4);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_MIN, 0, 2);
            this.tlp_Produktion.Controls.Add(this.lbl_VerktygsID_min, 11, 2);
            this.tlp_Produktion.Controls.Add(this.lbl_VerktygsID_nom, 11, 3);
            this.tlp_Produktion.Controls.Add(this.lbl_Add_Arbetskort, 0, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Datum, 20, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Mätare, 2, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Temp_L1, 3, 1);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Temp, 3, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Temp_L2, 4, 1);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_ID_L1, 5, 1);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_ID_L2, 6, 1);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_OD1, 7, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_OD1_L1, 7, 1);
            this.tlp_Produktion.Controls.Add(this.label_VerktygsID_enhet, 11, 1);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_OD1_L2, 8, 1);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_ODs, 9, 0);
            this.tlp_Produktion.Controls.Add(this.label_Bladhöjd, 11, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_ODs_L1, 9, 1);
            this.tlp_Produktion.Controls.Add(this.tb_Verktygs_ID, 11, 5);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_ODs_L2, 10, 1);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Tråd_slut, 12, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Tråd_av, 13, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Trasig_carrier, 14, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Skarv, 15, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Spole_slut, 16, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Avslut_linje, 17, 0);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Kommentar, 19, 0);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_ID_min, 5, 2);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_OD1_min, 7, 2);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_ODs_min, 9, 2);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_ID_nom, 5, 3);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_OD1_nom, 7, 3);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_ODs_nom, 9, 3);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_ID_max, 5, 4);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_OD1_max, 7, 4);
            this.tlp_Produktion.Controls.Add(this.lbl_Produktion_ODs_max, 9, 4);
            this.tlp_Produktion.Controls.Add(this.label_Empty_13, 12, 2);
            this.tlp_Produktion.Controls.Add(this.tb_Produktion_Mätare, 2, 5);
            this.tlp_Produktion.Controls.Add(this.tb_Produktion_Temp_L1, 3, 5);
            this.tlp_Produktion.Controls.Add(this.tb_Produktion_Temp_L2, 4, 5);
            this.tlp_Produktion.Controls.Add(this.tb_Produktion_ID_L1, 5, 5);
            this.tlp_Produktion.Controls.Add(this.tb_Produktion_ID_L2, 6, 5);
            this.tlp_Produktion.Controls.Add(this.tb_Produktion_OD1_L1, 7, 5);
            this.tlp_Produktion.Controls.Add(this.tb_Produktion_OD1_L2, 8, 5);
            this.tlp_Produktion.Controls.Add(this.tb_Produktion_ODs_L1, 9, 5);
            this.tlp_Produktion.Controls.Add(this.tb_Produktion_ODs_L2, 10, 5);
            this.tlp_Produktion.Controls.Add(this.chb_Tråd_slut, 12, 5);
            this.tlp_Produktion.Controls.Add(this.chb_Tråd_av, 13, 5);
            this.tlp_Produktion.Controls.Add(this.chb_Trasig_carrier, 14, 5);
            this.tlp_Produktion.Controls.Add(this.chb_Skarv, 15, 5);
            this.tlp_Produktion.Controls.Add(this.chb_Spole_slut, 16, 5);
            this.tlp_Produktion.Controls.Add(this.chb_Avslut_linje, 17, 5);
            this.tlp_Produktion.Controls.Add(this.tb_Produktion_Kommentar, 19, 5);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_AnstNr, 22, 0);
            this.tlp_Produktion.Controls.Add(this.label_Empty_14, 20, 5);
            this.tlp_Produktion.Controls.Add(this.chb_Avrapporterat, 18, 5);
            this.tlp_Produktion.Controls.Add(this.label_Produktion_Avrapporterat, 18, 0);
            this.tlp_Produktion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Produktion.Location = new System.Drawing.Point(2, 288);
            this.tlp_Produktion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tlp_Produktion.Name = "tlp_Produktion";
            this.tlp_Produktion.RowCount = 6;
            this.tlp_Main.SetRowSpan(this.tlp_Produktion, 2);
            this.tlp_Produktion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Produktion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Produktion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Produktion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Produktion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Produktion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Produktion.Size = new System.Drawing.Size(1246, 122);
            this.tlp_Produktion.TabIndex = 1030;
            // 
            // label_Produktion_Sign
            // 
            this.label_Produktion_Sign.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Sign.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Sign.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_Sign.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Sign.Location = new System.Drawing.Point(1031, 1);
            this.label_Produktion_Sign.Margin = new System.Windows.Forms.Padding(1);
            this.label_Produktion_Sign.Name = "label_Produktion_Sign";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Sign, 2);
            this.label_Produktion_Sign.Size = new System.Drawing.Size(214, 38);
            this.label_Produktion_Sign.TabIndex = 1045;
            this.label_Produktion_Sign.Text = "Sign";
            this.label_Produktion_Sign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Tid
            // 
            this.label_Produktion_Tid.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Tid.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Tid.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_Tid.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Tid.Location = new System.Drawing.Point(930, 1);
            this.label_Produktion_Tid.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Produktion_Tid.Name = "label_Produktion_Tid";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Tid, 2);
            this.label_Produktion_Tid.Size = new System.Drawing.Size(48, 38);
            this.label_Produktion_Tid.TabIndex = 1044;
            this.label_Produktion_Tid.Text = "Tid";
            this.label_Produktion_Tid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Transfer_Produktion
            // 
            this.lbl_Transfer_Produktion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.tlp_Produktion.SetColumnSpan(this.lbl_Transfer_Produktion, 2);
            this.lbl_Transfer_Produktion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Transfer_Produktion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Transfer_Produktion.Enabled = false;
            this.lbl_Transfer_Produktion.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Transfer_Produktion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.lbl_Transfer_Produktion.Location = new System.Drawing.Point(1, 101);
            this.lbl_Transfer_Produktion.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.lbl_Transfer_Produktion.Name = "lbl_Transfer_Produktion";
            this.lbl_Transfer_Produktion.Size = new System.Drawing.Size(37, 21);
            this.lbl_Transfer_Produktion.TabIndex = 1041;
            this.lbl_Transfer_Produktion.Text = "→";
            this.lbl_Transfer_Produktion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Transfer_Produktion.Click += new System.EventHandler(this.Transfer_Produktion_Click);
            // 
            // lbl_Produktion_Temp_nom
            // 
            this.lbl_Produktion_Temp_nom.BackColor = System.Drawing.Color.Silver;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_Temp_nom, 2);
            this.lbl_Produktion_Temp_nom.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_Temp_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_Temp_nom.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_Temp_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_Produktion_Temp_nom.Location = new System.Drawing.Point(85, 60);
            this.lbl_Produktion_Temp_nom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_Produktion_Temp_nom.Name = "lbl_Produktion_Temp_nom";
            this.lbl_Produktion_Temp_nom.Size = new System.Drawing.Size(64, 19);
            this.lbl_Produktion_Temp_nom.TabIndex = 1040;
            this.lbl_Produktion_Temp_nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_Temp_max
            // 
            this.lbl_Produktion_Temp_max.BackColor = System.Drawing.Color.Gainsboro;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_Temp_max, 2);
            this.lbl_Produktion_Temp_max.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_Temp_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_Temp_max.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_Temp_max.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Produktion_Temp_max.Location = new System.Drawing.Point(85, 80);
            this.lbl_Produktion_Temp_max.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_Produktion_Temp_max.Name = "lbl_Produktion_Temp_max";
            this.lbl_Produktion_Temp_max.Size = new System.Drawing.Size(64, 19);
            this.lbl_Produktion_Temp_max.TabIndex = 1039;
            this.lbl_Produktion_Temp_max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_Temp_min
            // 
            this.lbl_Produktion_Temp_min.BackColor = System.Drawing.Color.Gainsboro;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_Temp_min, 2);
            this.lbl_Produktion_Temp_min.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_Temp_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_Temp_min.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_Temp_min.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Produktion_Temp_min.Location = new System.Drawing.Point(85, 40);
            this.lbl_Produktion_Temp_min.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_Produktion_Temp_min.Name = "lbl_Produktion_Temp_min";
            this.lbl_Produktion_Temp_min.Size = new System.Drawing.Size(64, 19);
            this.lbl_Produktion_Temp_min.TabIndex = 1038;
            this.lbl_Produktion_Temp_min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_12
            // 
            this.label_Empty_12.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_12.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_12.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_12.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_12.Location = new System.Drawing.Point(39, 40);
            this.label_Empty_12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_Empty_12.Name = "label_Empty_12";
            this.tlp_Produktion.SetRowSpan(this.label_Empty_12, 3);
            this.label_Empty_12.Size = new System.Drawing.Size(44, 59);
            this.label_Empty_12.TabIndex = 1037;
            this.label_Empty_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_ID
            // 
            this.label_Produktion_ID.BackColor = System.Drawing.Color.White;
            this.tlp_Produktion.SetColumnSpan(this.label_Produktion_ID, 2);
            this.label_Produktion_ID.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_ID.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_ID.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_ID.Location = new System.Drawing.Point(151, 1);
            this.label_Produktion_ID.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Produktion_ID.Name = "label_Produktion_ID";
            this.label_Produktion_ID.Size = new System.Drawing.Size(71, 19);
            this.label_Produktion_ID.TabIndex = 1036;
            this.label_Produktion_ID.Text = "ID";
            this.label_Produktion_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_MAX
            // 
            this.label_Produktion_MAX.BackColor = System.Drawing.Color.Silver;
            this.tlp_Produktion.SetColumnSpan(this.label_Produktion_MAX, 2);
            this.label_Produktion_MAX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_MAX.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Produktion_MAX.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_Produktion_MAX.Location = new System.Drawing.Point(1, 80);
            this.label_Produktion_MAX.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Produktion_MAX.Name = "label_Produktion_MAX";
            this.label_Produktion_MAX.Size = new System.Drawing.Size(37, 19);
            this.label_Produktion_MAX.TabIndex = 1033;
            this.label_Produktion_MAX.Text = "MAX";
            this.label_Produktion_MAX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_NOM
            // 
            this.label_Produktion_NOM.BackColor = System.Drawing.Color.Silver;
            this.tlp_Produktion.SetColumnSpan(this.label_Produktion_NOM, 2);
            this.label_Produktion_NOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_NOM.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Produktion_NOM.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Produktion_NOM.Location = new System.Drawing.Point(1, 60);
            this.label_Produktion_NOM.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Produktion_NOM.Name = "label_Produktion_NOM";
            this.label_Produktion_NOM.Size = new System.Drawing.Size(37, 19);
            this.label_Produktion_NOM.TabIndex = 1032;
            this.label_Produktion_NOM.Text = "NOM";
            this.label_Produktion_NOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_VerktygsID_max
            // 
            this.lbl_VerktygsID_max.AutoSize = true;
            this.lbl_VerktygsID_max.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_VerktygsID_max.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_VerktygsID_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_VerktygsID_max.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_VerktygsID_max.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_VerktygsID_max.Location = new System.Drawing.Point(366, 80);
            this.lbl_VerktygsID_max.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.lbl_VerktygsID_max.Name = "lbl_VerktygsID_max";
            this.lbl_VerktygsID_max.Size = new System.Drawing.Size(68, 19);
            this.lbl_VerktygsID_max.TabIndex = 1003;
            this.lbl_VerktygsID_max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_MIN
            // 
            this.label_Produktion_MIN.BackColor = System.Drawing.Color.Silver;
            this.tlp_Produktion.SetColumnSpan(this.label_Produktion_MIN, 2);
            this.label_Produktion_MIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_MIN.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Produktion_MIN.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_Produktion_MIN.Location = new System.Drawing.Point(1, 40);
            this.label_Produktion_MIN.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Produktion_MIN.Name = "label_Produktion_MIN";
            this.label_Produktion_MIN.Size = new System.Drawing.Size(37, 19);
            this.label_Produktion_MIN.TabIndex = 1031;
            this.label_Produktion_MIN.Text = "MIN";
            this.label_Produktion_MIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_VerktygsID_min
            // 
            this.lbl_VerktygsID_min.AutoSize = true;
            this.lbl_VerktygsID_min.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_VerktygsID_min.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_VerktygsID_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_VerktygsID_min.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_VerktygsID_min.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_VerktygsID_min.Location = new System.Drawing.Point(366, 40);
            this.lbl_VerktygsID_min.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.lbl_VerktygsID_min.Name = "lbl_VerktygsID_min";
            this.lbl_VerktygsID_min.Size = new System.Drawing.Size(68, 19);
            this.lbl_VerktygsID_min.TabIndex = 1001;
            this.lbl_VerktygsID_min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_VerktygsID_nom
            // 
            this.lbl_VerktygsID_nom.AutoSize = true;
            this.lbl_VerktygsID_nom.BackColor = System.Drawing.Color.Silver;
            this.lbl_VerktygsID_nom.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_VerktygsID_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_VerktygsID_nom.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_VerktygsID_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_VerktygsID_nom.Location = new System.Drawing.Point(366, 60);
            this.lbl_VerktygsID_nom.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.lbl_VerktygsID_nom.Name = "lbl_VerktygsID_nom";
            this.lbl_VerktygsID_nom.Size = new System.Drawing.Size(68, 19);
            this.lbl_VerktygsID_nom.TabIndex = 987;
            this.lbl_VerktygsID_nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Add_Arbetskort
            // 
            this.lbl_Add_Arbetskort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.tlp_Produktion.SetColumnSpan(this.lbl_Add_Arbetskort, 2);
            this.lbl_Add_Arbetskort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Add_Arbetskort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Add_Arbetskort.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Add_Arbetskort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.lbl_Add_Arbetskort.Location = new System.Drawing.Point(1, 1);
            this.lbl_Add_Arbetskort.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.lbl_Add_Arbetskort.Name = "lbl_Add_Arbetskort";
            this.tlp_Produktion.SetRowSpan(this.lbl_Add_Arbetskort, 2);
            this.lbl_Add_Arbetskort.Size = new System.Drawing.Size(37, 38);
            this.lbl_Add_Arbetskort.TabIndex = 1029;
            this.lbl_Add_Arbetskort.Text = "+";
            this.lbl_Add_Arbetskort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Add_Arbetskort.Click += new System.EventHandler(this.Add_Arbetskort_Click);
            // 
            // label_Produktion_Datum
            // 
            this.label_Produktion_Datum.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Datum.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Datum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Datum.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_Datum.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Datum.Location = new System.Drawing.Point(851, 1);
            this.label_Produktion_Datum.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Produktion_Datum.Name = "label_Produktion_Datum";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Datum, 2);
            this.label_Produktion_Datum.Size = new System.Drawing.Size(78, 38);
            this.label_Produktion_Datum.TabIndex = 1030;
            this.label_Produktion_Datum.Text = "Datum";
            this.label_Produktion_Datum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Mätare
            // 
            this.label_Produktion_Mätare.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Mätare.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Mätare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Mätare.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_Mätare.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Mätare.Location = new System.Drawing.Point(39, 1);
            this.label_Produktion_Mätare.Margin = new System.Windows.Forms.Padding(1);
            this.label_Produktion_Mätare.Name = "label_Produktion_Mätare";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Mätare, 2);
            this.label_Produktion_Mätare.Size = new System.Drawing.Size(44, 38);
            this.label_Produktion_Mätare.TabIndex = 1034;
            this.label_Produktion_Mätare.Text = "Mätare";
            this.label_Produktion_Mätare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Temp_L1
            // 
            this.label_Produktion_Temp_L1.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Temp_L1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Temp_L1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Temp_L1.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_Temp_L1.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Temp_L1.Location = new System.Drawing.Point(85, 20);
            this.label_Produktion_Temp_L1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Produktion_Temp_L1.Name = "label_Produktion_Temp_L1";
            this.label_Produktion_Temp_L1.Size = new System.Drawing.Size(32, 19);
            this.label_Produktion_Temp_L1.TabIndex = 1035;
            this.label_Produktion_Temp_L1.Text = "L1";
            this.label_Produktion_Temp_L1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Temp
            // 
            this.label_Produktion_Temp.BackColor = System.Drawing.Color.White;
            this.tlp_Produktion.SetColumnSpan(this.label_Produktion_Temp, 2);
            this.label_Produktion_Temp.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Temp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Temp.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_Temp.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Temp.Location = new System.Drawing.Point(85, 1);
            this.label_Produktion_Temp.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.label_Produktion_Temp.Name = "label_Produktion_Temp";
            this.label_Produktion_Temp.Size = new System.Drawing.Size(64, 19);
            this.label_Produktion_Temp.TabIndex = 1034;
            this.label_Produktion_Temp.Text = "Temp ºC";
            this.label_Produktion_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Temp_L2
            // 
            this.label_Produktion_Temp_L2.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Temp_L2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Temp_L2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Temp_L2.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_Temp_L2.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Temp_L2.Location = new System.Drawing.Point(118, 20);
            this.label_Produktion_Temp_L2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_Produktion_Temp_L2.Name = "label_Produktion_Temp_L2";
            this.label_Produktion_Temp_L2.Size = new System.Drawing.Size(31, 19);
            this.label_Produktion_Temp_L2.TabIndex = 1035;
            this.label_Produktion_Temp_L2.Text = "L2";
            this.label_Produktion_Temp_L2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_ID_L1
            // 
            this.label_Produktion_ID_L1.BackColor = System.Drawing.Color.White;
            this.label_Produktion_ID_L1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_ID_L1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_ID_L1.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_ID_L1.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_ID_L1.Location = new System.Drawing.Point(151, 20);
            this.label_Produktion_ID_L1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Produktion_ID_L1.Name = "label_Produktion_ID_L1";
            this.label_Produktion_ID_L1.Size = new System.Drawing.Size(35, 19);
            this.label_Produktion_ID_L1.TabIndex = 1035;
            this.label_Produktion_ID_L1.Text = "L1";
            this.label_Produktion_ID_L1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_ID_L2
            // 
            this.label_Produktion_ID_L2.BackColor = System.Drawing.Color.White;
            this.label_Produktion_ID_L2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_ID_L2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_ID_L2.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_ID_L2.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_ID_L2.Location = new System.Drawing.Point(187, 20);
            this.label_Produktion_ID_L2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Produktion_ID_L2.Name = "label_Produktion_ID_L2";
            this.label_Produktion_ID_L2.Size = new System.Drawing.Size(35, 19);
            this.label_Produktion_ID_L2.TabIndex = 1035;
            this.label_Produktion_ID_L2.Text = "L2";
            this.label_Produktion_ID_L2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_OD1
            // 
            this.label_Produktion_OD1.BackColor = System.Drawing.Color.White;
            this.tlp_Produktion.SetColumnSpan(this.label_Produktion_OD1, 2);
            this.label_Produktion_OD1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_OD1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_OD1.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_OD1.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_OD1.Location = new System.Drawing.Point(223, 1);
            this.label_Produktion_OD1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Produktion_OD1.Name = "label_Produktion_OD1";
            this.label_Produktion_OD1.Size = new System.Drawing.Size(71, 19);
            this.label_Produktion_OD1.TabIndex = 1036;
            this.label_Produktion_OD1.Text = "OD1";
            this.label_Produktion_OD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_OD1_L1
            // 
            this.label_Produktion_OD1_L1.BackColor = System.Drawing.Color.White;
            this.label_Produktion_OD1_L1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_OD1_L1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_OD1_L1.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_OD1_L1.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_OD1_L1.Location = new System.Drawing.Point(223, 20);
            this.label_Produktion_OD1_L1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Produktion_OD1_L1.Name = "label_Produktion_OD1_L1";
            this.label_Produktion_OD1_L1.Size = new System.Drawing.Size(35, 19);
            this.label_Produktion_OD1_L1.TabIndex = 1035;
            this.label_Produktion_OD1_L1.Text = "L1";
            this.label_Produktion_OD1_L1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_VerktygsID_enhet
            // 
            this.label_VerktygsID_enhet.BackColor = System.Drawing.Color.White;
            this.label_VerktygsID_enhet.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_VerktygsID_enhet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_VerktygsID_enhet.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.label_VerktygsID_enhet.ForeColor = System.Drawing.Color.Black;
            this.label_VerktygsID_enhet.Location = new System.Drawing.Point(366, 20);
            this.label_VerktygsID_enhet.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.label_VerktygsID_enhet.Name = "label_VerktygsID_enhet";
            this.label_VerktygsID_enhet.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label_VerktygsID_enhet.Size = new System.Drawing.Size(68, 19);
            this.label_VerktygsID_enhet.TabIndex = 817;
            this.label_VerktygsID_enhet.Text = "mm";
            this.label_VerktygsID_enhet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_OD1_L2
            // 
            this.label_Produktion_OD1_L2.BackColor = System.Drawing.Color.White;
            this.label_Produktion_OD1_L2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_OD1_L2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_OD1_L2.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_OD1_L2.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_OD1_L2.Location = new System.Drawing.Point(259, 20);
            this.label_Produktion_OD1_L2.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Produktion_OD1_L2.Name = "label_Produktion_OD1_L2";
            this.label_Produktion_OD1_L2.Size = new System.Drawing.Size(35, 19);
            this.label_Produktion_OD1_L2.TabIndex = 1035;
            this.label_Produktion_OD1_L2.Text = "L2";
            this.label_Produktion_OD1_L2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_ODs
            // 
            this.label_Produktion_ODs.BackColor = System.Drawing.Color.White;
            this.tlp_Produktion.SetColumnSpan(this.label_Produktion_ODs, 2);
            this.label_Produktion_ODs.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_ODs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_ODs.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_ODs.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_ODs.Location = new System.Drawing.Point(295, 1);
            this.label_Produktion_ODs.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.label_Produktion_ODs.Name = "label_Produktion_ODs";
            this.label_Produktion_ODs.Size = new System.Drawing.Size(70, 19);
            this.label_Produktion_ODs.TabIndex = 1036;
            this.label_Produktion_ODs.Text = "ODs";
            this.label_Produktion_ODs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Bladhöjd
            // 
            this.label_Bladhöjd.BackColor = System.Drawing.Color.White;
            this.label_Bladhöjd.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Bladhöjd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Bladhöjd.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Bladhöjd.ForeColor = System.Drawing.Color.Black;
            this.label_Bladhöjd.Location = new System.Drawing.Point(366, 1);
            this.label_Bladhöjd.Margin = new System.Windows.Forms.Padding(0, 1, 1, 0);
            this.label_Bladhöjd.Name = "label_Bladhöjd";
            this.label_Bladhöjd.Size = new System.Drawing.Size(68, 19);
            this.label_Bladhöjd.TabIndex = 136;
            this.label_Bladhöjd.Text = "Verktygs ID";
            this.label_Bladhöjd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_ODs_L1
            // 
            this.label_Produktion_ODs_L1.BackColor = System.Drawing.Color.White;
            this.label_Produktion_ODs_L1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_ODs_L1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_ODs_L1.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_ODs_L1.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_ODs_L1.Location = new System.Drawing.Point(295, 20);
            this.label_Produktion_ODs_L1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Produktion_ODs_L1.Name = "label_Produktion_ODs_L1";
            this.label_Produktion_ODs_L1.Size = new System.Drawing.Size(35, 19);
            this.label_Produktion_ODs_L1.TabIndex = 1035;
            this.label_Produktion_ODs_L1.Text = "L1";
            this.label_Produktion_ODs_L1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Verktygs_ID
            // 
            this.tb_Verktygs_ID.BackColor = System.Drawing.Color.White;
            this.tb_Verktygs_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Verktygs_ID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Verktygs_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Verktygs_ID.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.tb_Verktygs_ID.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Verktygs_ID.Location = new System.Drawing.Point(366, 101);
            this.tb_Verktygs_ID.Margin = new System.Windows.Forms.Padding(0, 1, 1, 0);
            this.tb_Verktygs_ID.MaxLength = 6;
            this.tb_Verktygs_ID.Multiline = true;
            this.tb_Verktygs_ID.Name = "tb_Verktygs_ID";
            this.tb_Verktygs_ID.Size = new System.Drawing.Size(68, 21);
            this.tb_Verktygs_ID.TabIndex = 19;
            this.tb_Verktygs_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Verktygs_ID.WordWrap = false;
            this.tb_Verktygs_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Double_Values_Onyl_KeyPress);
            this.tb_Verktygs_ID.Leave += new System.EventHandler(this.ValidateData_TextLeave);
            // 
            // label_Produktion_ODs_L2
            // 
            this.label_Produktion_ODs_L2.BackColor = System.Drawing.Color.White;
            this.label_Produktion_ODs_L2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_ODs_L2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_ODs_L2.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_ODs_L2.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_ODs_L2.Location = new System.Drawing.Point(331, 20);
            this.label_Produktion_ODs_L2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_Produktion_ODs_L2.Name = "label_Produktion_ODs_L2";
            this.label_Produktion_ODs_L2.Size = new System.Drawing.Size(34, 19);
            this.label_Produktion_ODs_L2.TabIndex = 1035;
            this.label_Produktion_ODs_L2.Text = "L2";
            this.label_Produktion_ODs_L2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Tråd_slut
            // 
            this.label_Produktion_Tråd_slut.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Tråd_slut.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Tråd_slut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Tråd_slut.Font = new System.Drawing.Font("Arial", 6.55F);
            this.label_Produktion_Tråd_slut.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Tråd_slut.Location = new System.Drawing.Point(436, 1);
            this.label_Produktion_Tråd_slut.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Produktion_Tråd_slut.Name = "label_Produktion_Tråd_slut";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Tråd_slut, 2);
            this.label_Produktion_Tråd_slut.Size = new System.Drawing.Size(35, 38);
            this.label_Produktion_Tråd_slut.TabIndex = 1036;
            this.label_Produktion_Tråd_slut.Text = "Tråd slut";
            this.label_Produktion_Tråd_slut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Tråd_av
            // 
            this.label_Produktion_Tråd_av.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Tråd_av.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Tråd_av.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Tråd_av.Font = new System.Drawing.Font("Arial", 6.55F);
            this.label_Produktion_Tråd_av.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Tråd_av.Location = new System.Drawing.Point(472, 1);
            this.label_Produktion_Tråd_av.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Produktion_Tråd_av.Name = "label_Produktion_Tråd_av";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Tråd_av, 2);
            this.label_Produktion_Tråd_av.Size = new System.Drawing.Size(35, 38);
            this.label_Produktion_Tråd_av.TabIndex = 1036;
            this.label_Produktion_Tråd_av.Text = "Tråd av";
            this.label_Produktion_Tråd_av.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Trasig_carrier
            // 
            this.label_Produktion_Trasig_carrier.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Trasig_carrier.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Trasig_carrier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Trasig_carrier.Font = new System.Drawing.Font("Arial", 6.55F);
            this.label_Produktion_Trasig_carrier.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Trasig_carrier.Location = new System.Drawing.Point(508, 1);
            this.label_Produktion_Trasig_carrier.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Produktion_Trasig_carrier.Name = "label_Produktion_Trasig_carrier";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Trasig_carrier, 2);
            this.label_Produktion_Trasig_carrier.Size = new System.Drawing.Size(35, 38);
            this.label_Produktion_Trasig_carrier.TabIndex = 1036;
            this.label_Produktion_Trasig_carrier.Text = "Trasig carrier";
            this.label_Produktion_Trasig_carrier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Skarv
            // 
            this.label_Produktion_Skarv.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Skarv.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Skarv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Skarv.Font = new System.Drawing.Font("Arial", 6.55F);
            this.label_Produktion_Skarv.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Skarv.Location = new System.Drawing.Point(544, 1);
            this.label_Produktion_Skarv.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Produktion_Skarv.Name = "label_Produktion_Skarv";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Skarv, 2);
            this.label_Produktion_Skarv.Size = new System.Drawing.Size(35, 38);
            this.label_Produktion_Skarv.TabIndex = 1036;
            this.label_Produktion_Skarv.Text = "Skarv";
            this.label_Produktion_Skarv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Spole_slut
            // 
            this.label_Produktion_Spole_slut.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Spole_slut.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Spole_slut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Spole_slut.Font = new System.Drawing.Font("Arial", 6.55F);
            this.label_Produktion_Spole_slut.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Spole_slut.Location = new System.Drawing.Point(580, 1);
            this.label_Produktion_Spole_slut.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Produktion_Spole_slut.Name = "label_Produktion_Spole_slut";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Spole_slut, 2);
            this.label_Produktion_Spole_slut.Size = new System.Drawing.Size(35, 38);
            this.label_Produktion_Spole_slut.TabIndex = 1036;
            this.label_Produktion_Spole_slut.Text = "Spole slut";
            this.label_Produktion_Spole_slut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Avslut_linje
            // 
            this.label_Produktion_Avslut_linje.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Avslut_linje.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Avslut_linje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Avslut_linje.Font = new System.Drawing.Font("Arial", 6.55F);
            this.label_Produktion_Avslut_linje.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Avslut_linje.Location = new System.Drawing.Point(616, 1);
            this.label_Produktion_Avslut_linje.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Produktion_Avslut_linje.Name = "label_Produktion_Avslut_linje";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Avslut_linje, 2);
            this.label_Produktion_Avslut_linje.Size = new System.Drawing.Size(35, 38);
            this.label_Produktion_Avslut_linje.TabIndex = 1036;
            this.label_Produktion_Avslut_linje.Text = "Avslut linje";
            this.label_Produktion_Avslut_linje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Kommentar
            // 
            this.label_Produktion_Kommentar.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Kommentar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Kommentar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Kommentar.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_Kommentar.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Kommentar.Location = new System.Drawing.Point(688, 1);
            this.label_Produktion_Kommentar.Margin = new System.Windows.Forms.Padding(1);
            this.label_Produktion_Kommentar.Name = "label_Produktion_Kommentar";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Kommentar, 2);
            this.label_Produktion_Kommentar.Size = new System.Drawing.Size(161, 38);
            this.label_Produktion_Kommentar.TabIndex = 1036;
            this.label_Produktion_Kommentar.Text = "Kommentar";
            this.label_Produktion_Kommentar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ID_min
            // 
            this.lbl_Produktion_ID_min.BackColor = System.Drawing.Color.Gainsboro;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_ID_min, 2);
            this.lbl_Produktion_ID_min.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_ID_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_ID_min.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_ID_min.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Produktion_ID_min.Location = new System.Drawing.Point(151, 40);
            this.lbl_Produktion_ID_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Produktion_ID_min.Name = "lbl_Produktion_ID_min";
            this.lbl_Produktion_ID_min.Size = new System.Drawing.Size(71, 19);
            this.lbl_Produktion_ID_min.TabIndex = 1038;
            this.lbl_Produktion_ID_min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_OD1_min
            // 
            this.lbl_Produktion_OD1_min.BackColor = System.Drawing.Color.Gainsboro;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_OD1_min, 2);
            this.lbl_Produktion_OD1_min.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_OD1_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_OD1_min.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_OD1_min.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Produktion_OD1_min.Location = new System.Drawing.Point(223, 40);
            this.lbl_Produktion_OD1_min.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Produktion_OD1_min.Name = "lbl_Produktion_OD1_min";
            this.lbl_Produktion_OD1_min.Size = new System.Drawing.Size(71, 19);
            this.lbl_Produktion_OD1_min.TabIndex = 1038;
            this.lbl_Produktion_OD1_min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ODs_min
            // 
            this.lbl_Produktion_ODs_min.BackColor = System.Drawing.Color.Gainsboro;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_ODs_min, 2);
            this.lbl_Produktion_ODs_min.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_ODs_min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_ODs_min.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_ODs_min.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Produktion_ODs_min.Location = new System.Drawing.Point(295, 40);
            this.lbl_Produktion_ODs_min.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_Produktion_ODs_min.Name = "lbl_Produktion_ODs_min";
            this.lbl_Produktion_ODs_min.Size = new System.Drawing.Size(70, 19);
            this.lbl_Produktion_ODs_min.TabIndex = 1038;
            this.lbl_Produktion_ODs_min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ID_nom
            // 
            this.lbl_Produktion_ID_nom.BackColor = System.Drawing.Color.Silver;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_ID_nom, 2);
            this.lbl_Produktion_ID_nom.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_ID_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_ID_nom.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_ID_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_Produktion_ID_nom.Location = new System.Drawing.Point(151, 60);
            this.lbl_Produktion_ID_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Produktion_ID_nom.Name = "lbl_Produktion_ID_nom";
            this.lbl_Produktion_ID_nom.Size = new System.Drawing.Size(71, 19);
            this.lbl_Produktion_ID_nom.TabIndex = 1040;
            this.lbl_Produktion_ID_nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_OD1_nom
            // 
            this.lbl_Produktion_OD1_nom.BackColor = System.Drawing.Color.Silver;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_OD1_nom, 2);
            this.lbl_Produktion_OD1_nom.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_OD1_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_OD1_nom.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_OD1_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_Produktion_OD1_nom.Location = new System.Drawing.Point(223, 60);
            this.lbl_Produktion_OD1_nom.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Produktion_OD1_nom.Name = "lbl_Produktion_OD1_nom";
            this.lbl_Produktion_OD1_nom.Size = new System.Drawing.Size(71, 19);
            this.lbl_Produktion_OD1_nom.TabIndex = 1040;
            this.lbl_Produktion_OD1_nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ODs_nom
            // 
            this.lbl_Produktion_ODs_nom.BackColor = System.Drawing.Color.Silver;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_ODs_nom, 2);
            this.lbl_Produktion_ODs_nom.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_ODs_nom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_ODs_nom.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_ODs_nom.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_Produktion_ODs_nom.Location = new System.Drawing.Point(295, 60);
            this.lbl_Produktion_ODs_nom.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_Produktion_ODs_nom.Name = "lbl_Produktion_ODs_nom";
            this.lbl_Produktion_ODs_nom.Size = new System.Drawing.Size(70, 19);
            this.lbl_Produktion_ODs_nom.TabIndex = 1040;
            this.lbl_Produktion_ODs_nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ID_max
            // 
            this.lbl_Produktion_ID_max.BackColor = System.Drawing.Color.Gainsboro;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_ID_max, 2);
            this.lbl_Produktion_ID_max.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_ID_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_ID_max.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_ID_max.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Produktion_ID_max.Location = new System.Drawing.Point(151, 80);
            this.lbl_Produktion_ID_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Produktion_ID_max.Name = "lbl_Produktion_ID_max";
            this.lbl_Produktion_ID_max.Size = new System.Drawing.Size(71, 19);
            this.lbl_Produktion_ID_max.TabIndex = 1039;
            this.lbl_Produktion_ID_max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_OD1_max
            // 
            this.lbl_Produktion_OD1_max.BackColor = System.Drawing.Color.Gainsboro;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_OD1_max, 2);
            this.lbl_Produktion_OD1_max.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_OD1_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_OD1_max.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_OD1_max.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Produktion_OD1_max.Location = new System.Drawing.Point(223, 80);
            this.lbl_Produktion_OD1_max.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Produktion_OD1_max.Name = "lbl_Produktion_OD1_max";
            this.lbl_Produktion_OD1_max.Size = new System.Drawing.Size(71, 19);
            this.lbl_Produktion_OD1_max.TabIndex = 1039;
            this.lbl_Produktion_OD1_max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Produktion_ODs_max
            // 
            this.lbl_Produktion_ODs_max.BackColor = System.Drawing.Color.Gainsboro;
            this.tlp_Produktion.SetColumnSpan(this.lbl_Produktion_ODs_max, 2);
            this.lbl_Produktion_ODs_max.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Produktion_ODs_max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Produktion_ODs_max.Font = new System.Drawing.Font("Consolas", 8.75F);
            this.lbl_Produktion_ODs_max.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Produktion_ODs_max.Location = new System.Drawing.Point(295, 80);
            this.lbl_Produktion_ODs_max.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_Produktion_ODs_max.Name = "lbl_Produktion_ODs_max";
            this.lbl_Produktion_ODs_max.Size = new System.Drawing.Size(70, 19);
            this.lbl_Produktion_ODs_max.TabIndex = 1039;
            this.lbl_Produktion_ODs_max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_13
            // 
            this.label_Empty_13.BackColor = System.Drawing.Color.DarkGray;
            this.tlp_Produktion.SetColumnSpan(this.label_Empty_13, 12);
            this.label_Empty_13.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_13.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_13.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_13.Location = new System.Drawing.Point(436, 40);
            this.label_Empty_13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Empty_13.Name = "label_Empty_13";
            this.tlp_Produktion.SetRowSpan(this.label_Empty_13, 3);
            this.label_Empty_13.Size = new System.Drawing.Size(809, 60);
            this.label_Empty_13.TabIndex = 1037;
            this.label_Empty_13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Produktion_Mätare
            // 
            this.tb_Produktion_Mätare.BackColor = System.Drawing.Color.White;
            this.tb_Produktion_Mätare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Produktion_Mätare.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Produktion_Mätare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Produktion_Mätare.Enabled = false;
            this.tb_Produktion_Mätare.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.tb_Produktion_Mätare.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Produktion_Mätare.Location = new System.Drawing.Point(39, 101);
            this.tb_Produktion_Mätare.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.tb_Produktion_Mätare.MaxLength = 5;
            this.tb_Produktion_Mätare.Multiline = true;
            this.tb_Produktion_Mätare.Name = "tb_Produktion_Mätare";
            this.tb_Produktion_Mätare.Size = new System.Drawing.Size(44, 21);
            this.tb_Produktion_Mätare.TabIndex = 10;
            this.tb_Produktion_Mätare.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Produktion_Mätare.WordWrap = false;
            // 
            // tb_Produktion_Temp_L1
            // 
            this.tb_Produktion_Temp_L1.BackColor = System.Drawing.Color.White;
            this.tb_Produktion_Temp_L1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Produktion_Temp_L1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Produktion_Temp_L1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Produktion_Temp_L1.Enabled = false;
            this.tb_Produktion_Temp_L1.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.tb_Produktion_Temp_L1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Produktion_Temp_L1.Location = new System.Drawing.Point(85, 101);
            this.tb_Produktion_Temp_L1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Produktion_Temp_L1.MaxLength = 4;
            this.tb_Produktion_Temp_L1.Multiline = true;
            this.tb_Produktion_Temp_L1.Name = "tb_Produktion_Temp_L1";
            this.tb_Produktion_Temp_L1.Size = new System.Drawing.Size(32, 21);
            this.tb_Produktion_Temp_L1.TabIndex = 11;
            this.tb_Produktion_Temp_L1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Produktion_Temp_L1.WordWrap = false;
            this.tb_Produktion_Temp_L1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Int_Values_Only_KeyPress);
            this.tb_Produktion_Temp_L1.Leave += new System.EventHandler(this.ValidateData_TextLeave);
            // 
            // tb_Produktion_Temp_L2
            // 
            this.tb_Produktion_Temp_L2.BackColor = System.Drawing.Color.White;
            this.tb_Produktion_Temp_L2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Produktion_Temp_L2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Produktion_Temp_L2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Produktion_Temp_L2.Enabled = false;
            this.tb_Produktion_Temp_L2.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.tb_Produktion_Temp_L2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Produktion_Temp_L2.Location = new System.Drawing.Point(118, 101);
            this.tb_Produktion_Temp_L2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.tb_Produktion_Temp_L2.MaxLength = 4;
            this.tb_Produktion_Temp_L2.Multiline = true;
            this.tb_Produktion_Temp_L2.Name = "tb_Produktion_Temp_L2";
            this.tb_Produktion_Temp_L2.Size = new System.Drawing.Size(31, 21);
            this.tb_Produktion_Temp_L2.TabIndex = 12;
            this.tb_Produktion_Temp_L2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Produktion_Temp_L2.WordWrap = false;
            this.tb_Produktion_Temp_L2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Int_Values_Only_KeyPress);
            this.tb_Produktion_Temp_L2.Leave += new System.EventHandler(this.ValidateData_TextLeave);
            // 
            // tb_Produktion_ID_L1
            // 
            this.tb_Produktion_ID_L1.BackColor = System.Drawing.Color.White;
            this.tb_Produktion_ID_L1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Produktion_ID_L1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Produktion_ID_L1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Produktion_ID_L1.Enabled = false;
            this.tb_Produktion_ID_L1.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.tb_Produktion_ID_L1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Produktion_ID_L1.Location = new System.Drawing.Point(151, 101);
            this.tb_Produktion_ID_L1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Produktion_ID_L1.MaxLength = 6;
            this.tb_Produktion_ID_L1.Multiline = true;
            this.tb_Produktion_ID_L1.Name = "tb_Produktion_ID_L1";
            this.tb_Produktion_ID_L1.Size = new System.Drawing.Size(35, 21);
            this.tb_Produktion_ID_L1.TabIndex = 13;
            this.tb_Produktion_ID_L1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Produktion_ID_L1.WordWrap = false;
            this.tb_Produktion_ID_L1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Double_Values_Onyl_KeyPress);
            this.tb_Produktion_ID_L1.Leave += new System.EventHandler(this.ValidateData_TextLeave);
            // 
            // tb_Produktion_ID_L2
            // 
            this.tb_Produktion_ID_L2.BackColor = System.Drawing.Color.White;
            this.tb_Produktion_ID_L2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Produktion_ID_L2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Produktion_ID_L2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Produktion_ID_L2.Enabled = false;
            this.tb_Produktion_ID_L2.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.tb_Produktion_ID_L2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Produktion_ID_L2.Location = new System.Drawing.Point(187, 101);
            this.tb_Produktion_ID_L2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Produktion_ID_L2.MaxLength = 6;
            this.tb_Produktion_ID_L2.Multiline = true;
            this.tb_Produktion_ID_L2.Name = "tb_Produktion_ID_L2";
            this.tb_Produktion_ID_L2.Size = new System.Drawing.Size(35, 21);
            this.tb_Produktion_ID_L2.TabIndex = 14;
            this.tb_Produktion_ID_L2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Produktion_ID_L2.WordWrap = false;
            this.tb_Produktion_ID_L2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Double_Values_Onyl_KeyPress);
            this.tb_Produktion_ID_L2.Leave += new System.EventHandler(this.ValidateData_TextLeave);
            // 
            // tb_Produktion_OD1_L1
            // 
            this.tb_Produktion_OD1_L1.BackColor = System.Drawing.Color.White;
            this.tb_Produktion_OD1_L1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Produktion_OD1_L1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Produktion_OD1_L1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Produktion_OD1_L1.Enabled = false;
            this.tb_Produktion_OD1_L1.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.tb_Produktion_OD1_L1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Produktion_OD1_L1.Location = new System.Drawing.Point(223, 101);
            this.tb_Produktion_OD1_L1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Produktion_OD1_L1.MaxLength = 6;
            this.tb_Produktion_OD1_L1.Multiline = true;
            this.tb_Produktion_OD1_L1.Name = "tb_Produktion_OD1_L1";
            this.tb_Produktion_OD1_L1.Size = new System.Drawing.Size(35, 21);
            this.tb_Produktion_OD1_L1.TabIndex = 15;
            this.tb_Produktion_OD1_L1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Produktion_OD1_L1.WordWrap = false;
            this.tb_Produktion_OD1_L1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Double_Values_Onyl_KeyPress);
            this.tb_Produktion_OD1_L1.Leave += new System.EventHandler(this.ValidateData_TextLeave);
            // 
            // tb_Produktion_OD1_L2
            // 
            this.tb_Produktion_OD1_L2.BackColor = System.Drawing.Color.White;
            this.tb_Produktion_OD1_L2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Produktion_OD1_L2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Produktion_OD1_L2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Produktion_OD1_L2.Enabled = false;
            this.tb_Produktion_OD1_L2.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.tb_Produktion_OD1_L2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Produktion_OD1_L2.Location = new System.Drawing.Point(259, 101);
            this.tb_Produktion_OD1_L2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Produktion_OD1_L2.MaxLength = 6;
            this.tb_Produktion_OD1_L2.Multiline = true;
            this.tb_Produktion_OD1_L2.Name = "tb_Produktion_OD1_L2";
            this.tb_Produktion_OD1_L2.Size = new System.Drawing.Size(35, 21);
            this.tb_Produktion_OD1_L2.TabIndex = 16;
            this.tb_Produktion_OD1_L2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Produktion_OD1_L2.WordWrap = false;
            this.tb_Produktion_OD1_L2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Double_Values_Onyl_KeyPress);
            this.tb_Produktion_OD1_L2.Leave += new System.EventHandler(this.ValidateData_TextLeave);
            // 
            // tb_Produktion_ODs_L1
            // 
            this.tb_Produktion_ODs_L1.BackColor = System.Drawing.Color.White;
            this.tb_Produktion_ODs_L1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Produktion_ODs_L1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Produktion_ODs_L1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Produktion_ODs_L1.Enabled = false;
            this.tb_Produktion_ODs_L1.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.tb_Produktion_ODs_L1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Produktion_ODs_L1.Location = new System.Drawing.Point(295, 101);
            this.tb_Produktion_ODs_L1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Produktion_ODs_L1.MaxLength = 6;
            this.tb_Produktion_ODs_L1.Multiline = true;
            this.tb_Produktion_ODs_L1.Name = "tb_Produktion_ODs_L1";
            this.tb_Produktion_ODs_L1.Size = new System.Drawing.Size(35, 21);
            this.tb_Produktion_ODs_L1.TabIndex = 17;
            this.tb_Produktion_ODs_L1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Produktion_ODs_L1.WordWrap = false;
            this.tb_Produktion_ODs_L1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Double_Values_Onyl_KeyPress);
            this.tb_Produktion_ODs_L1.Leave += new System.EventHandler(this.ValidateData_TextLeave);
            // 
            // tb_Produktion_ODs_L2
            // 
            this.tb_Produktion_ODs_L2.BackColor = System.Drawing.Color.White;
            this.tb_Produktion_ODs_L2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Produktion_ODs_L2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Produktion_ODs_L2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Produktion_ODs_L2.Enabled = false;
            this.tb_Produktion_ODs_L2.Font = new System.Drawing.Font("Courier New", 8.5F);
            this.tb_Produktion_ODs_L2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Produktion_ODs_L2.Location = new System.Drawing.Point(331, 101);
            this.tb_Produktion_ODs_L2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.tb_Produktion_ODs_L2.MaxLength = 6;
            this.tb_Produktion_ODs_L2.Multiline = true;
            this.tb_Produktion_ODs_L2.Name = "tb_Produktion_ODs_L2";
            this.tb_Produktion_ODs_L2.Size = new System.Drawing.Size(34, 21);
            this.tb_Produktion_ODs_L2.TabIndex = 18;
            this.tb_Produktion_ODs_L2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Produktion_ODs_L2.WordWrap = false;
            this.tb_Produktion_ODs_L2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Double_Values_Onyl_KeyPress);
            this.tb_Produktion_ODs_L2.Leave += new System.EventHandler(this.ValidateData_TextLeave);
            // 
            // chb_Tråd_slut
            // 
            this.chb_Tråd_slut.AutoSize = true;
            this.chb_Tråd_slut.BackColor = System.Drawing.Color.White;
            this.chb_Tråd_slut.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_Tråd_slut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Tråd_slut.Enabled = false;
            this.chb_Tråd_slut.Location = new System.Drawing.Point(436, 101);
            this.chb_Tråd_slut.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.chb_Tråd_slut.Name = "chb_Tråd_slut";
            this.chb_Tråd_slut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chb_Tråd_slut.Size = new System.Drawing.Size(35, 21);
            this.chb_Tråd_slut.TabIndex = 19;
            this.chb_Tråd_slut.UseVisualStyleBackColor = false;
            // 
            // chb_Tråd_av
            // 
            this.chb_Tråd_av.AutoSize = true;
            this.chb_Tråd_av.BackColor = System.Drawing.Color.White;
            this.chb_Tråd_av.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_Tråd_av.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Tråd_av.Enabled = false;
            this.chb_Tråd_av.Location = new System.Drawing.Point(472, 101);
            this.chb_Tråd_av.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.chb_Tråd_av.Name = "chb_Tråd_av";
            this.chb_Tråd_av.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chb_Tråd_av.Size = new System.Drawing.Size(35, 21);
            this.chb_Tråd_av.TabIndex = 20;
            this.chb_Tråd_av.UseVisualStyleBackColor = false;
            // 
            // chb_Trasig_carrier
            // 
            this.chb_Trasig_carrier.AutoSize = true;
            this.chb_Trasig_carrier.BackColor = System.Drawing.Color.White;
            this.chb_Trasig_carrier.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_Trasig_carrier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Trasig_carrier.Enabled = false;
            this.chb_Trasig_carrier.Location = new System.Drawing.Point(508, 101);
            this.chb_Trasig_carrier.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.chb_Trasig_carrier.Name = "chb_Trasig_carrier";
            this.chb_Trasig_carrier.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chb_Trasig_carrier.Size = new System.Drawing.Size(35, 21);
            this.chb_Trasig_carrier.TabIndex = 21;
            this.chb_Trasig_carrier.UseVisualStyleBackColor = false;
            // 
            // chb_Skarv
            // 
            this.chb_Skarv.AutoSize = true;
            this.chb_Skarv.BackColor = System.Drawing.Color.White;
            this.chb_Skarv.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_Skarv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Skarv.Enabled = false;
            this.chb_Skarv.Location = new System.Drawing.Point(544, 101);
            this.chb_Skarv.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.chb_Skarv.Name = "chb_Skarv";
            this.chb_Skarv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chb_Skarv.Size = new System.Drawing.Size(35, 21);
            this.chb_Skarv.TabIndex = 22;
            this.chb_Skarv.UseVisualStyleBackColor = false;
            // 
            // chb_Spole_slut
            // 
            this.chb_Spole_slut.AutoSize = true;
            this.chb_Spole_slut.BackColor = System.Drawing.Color.White;
            this.chb_Spole_slut.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_Spole_slut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Spole_slut.Enabled = false;
            this.chb_Spole_slut.Location = new System.Drawing.Point(580, 101);
            this.chb_Spole_slut.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.chb_Spole_slut.Name = "chb_Spole_slut";
            this.chb_Spole_slut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chb_Spole_slut.Size = new System.Drawing.Size(35, 21);
            this.chb_Spole_slut.TabIndex = 23;
            this.chb_Spole_slut.UseVisualStyleBackColor = false;
            // 
            // chb_Avslut_linje
            // 
            this.chb_Avslut_linje.AutoSize = true;
            this.chb_Avslut_linje.BackColor = System.Drawing.Color.White;
            this.chb_Avslut_linje.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_Avslut_linje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Avslut_linje.Enabled = false;
            this.chb_Avslut_linje.Location = new System.Drawing.Point(616, 101);
            this.chb_Avslut_linje.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.chb_Avslut_linje.Name = "chb_Avslut_linje";
            this.chb_Avslut_linje.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chb_Avslut_linje.Size = new System.Drawing.Size(35, 21);
            this.chb_Avslut_linje.TabIndex = 24;
            this.chb_Avslut_linje.UseVisualStyleBackColor = false;
            // 
            // tb_Produktion_Kommentar
            // 
            this.tb_Produktion_Kommentar.BackColor = System.Drawing.Color.White;
            this.tb_Produktion_Kommentar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Produktion_Kommentar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Produktion_Kommentar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Produktion_Kommentar.Enabled = false;
            this.tb_Produktion_Kommentar.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.tb_Produktion_Kommentar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Produktion_Kommentar.Location = new System.Drawing.Point(688, 101);
            this.tb_Produktion_Kommentar.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Produktion_Kommentar.MaxLength = 26;
            this.tb_Produktion_Kommentar.Multiline = true;
            this.tb_Produktion_Kommentar.Name = "tb_Produktion_Kommentar";
            this.tb_Produktion_Kommentar.Size = new System.Drawing.Size(162, 21);
            this.tb_Produktion_Kommentar.TabIndex = 25;
            this.tb_Produktion_Kommentar.WordWrap = false;
            // 
            // label_Produktion_AnstNr
            // 
            this.label_Produktion_AnstNr.BackColor = System.Drawing.Color.White;
            this.label_Produktion_AnstNr.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_AnstNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_AnstNr.Font = new System.Drawing.Font("Arial", 8.55F);
            this.label_Produktion_AnstNr.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_AnstNr.Location = new System.Drawing.Point(979, 1);
            this.label_Produktion_AnstNr.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Produktion_AnstNr.Name = "label_Produktion_AnstNr";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_AnstNr, 2);
            this.label_Produktion_AnstNr.Size = new System.Drawing.Size(51, 38);
            this.label_Produktion_AnstNr.TabIndex = 1044;
            this.label_Produktion_AnstNr.Text = "Anst Nr";
            this.label_Produktion_AnstNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Empty_14
            // 
            this.label_Empty_14.BackColor = System.Drawing.Color.DarkGray;
            this.tlp_Produktion.SetColumnSpan(this.label_Empty_14, 4);
            this.label_Empty_14.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Empty_14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_14.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_14.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_14.Location = new System.Drawing.Point(851, 100);
            this.label_Empty_14.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Empty_14.Name = "label_Empty_14";
            this.label_Empty_14.Size = new System.Drawing.Size(394, 22);
            this.label_Empty_14.TabIndex = 1037;
            this.label_Empty_14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chb_Avrapporterat
            // 
            this.chb_Avrapporterat.AutoSize = true;
            this.chb_Avrapporterat.BackColor = System.Drawing.Color.White;
            this.chb_Avrapporterat.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_Avrapporterat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Avrapporterat.Enabled = false;
            this.chb_Avrapporterat.Location = new System.Drawing.Point(652, 101);
            this.chb_Avrapporterat.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.chb_Avrapporterat.Name = "chb_Avrapporterat";
            this.chb_Avrapporterat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chb_Avrapporterat.Size = new System.Drawing.Size(35, 21);
            this.chb_Avrapporterat.TabIndex = 24;
            this.chb_Avrapporterat.UseVisualStyleBackColor = false;
            // 
            // label_Produktion_Avrapporterat
            // 
            this.label_Produktion_Avrapporterat.BackColor = System.Drawing.Color.White;
            this.label_Produktion_Avrapporterat.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_Produktion_Avrapporterat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Avrapporterat.Font = new System.Drawing.Font("Arial", 6.55F);
            this.label_Produktion_Avrapporterat.ForeColor = System.Drawing.Color.Black;
            this.label_Produktion_Avrapporterat.Location = new System.Drawing.Point(652, 1);
            this.label_Produktion_Avrapporterat.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Produktion_Avrapporterat.Name = "label_Produktion_Avrapporterat";
            this.tlp_Produktion.SetRowSpan(this.label_Produktion_Avrapporterat, 2);
            this.label_Produktion_Avrapporterat.Size = new System.Drawing.Size(35, 38);
            this.label_Produktion_Avrapporterat.TabIndex = 1036;
            this.label_Produktion_Avrapporterat.Text = "Avrapporterat";
            this.label_Produktion_Avrapporterat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainProtocol_Skärmning_TEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "MainProtocol_Skärmning_TEF";
            this.Size = new System.Drawing.Size(1250, 651);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Maskinparametrar.ResumeLayout(false);
            this.tlp_Maskinparametrar.PerformLayout();
            this.tlp_ProduktInformation.ResumeLayout(false);
            this.tlp_ProduktInformation.PerformLayout();
            this.tlp_Produktion.ResumeLayout(false);
            this.tlp_Produktion.PerformLayout();
            this.ResumeLayout(false);

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
        private Label lbl_LotNr;
        private Label label_Empty_15;
        private Label label_LotNr;
        private Label lbl_Tråd_Material;
        private Label label_Tråd_Benämning;
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
    }
}
