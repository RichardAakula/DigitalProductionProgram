using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.Protocols.MainInfo;

namespace DigitalProductionProgram.Protocols.Svetsning_TEF
{
    partial class MainProtocol_Svetsning_TEF
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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle44 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle45 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle33 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle34 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle35 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle36 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle37 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle38 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle39 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle40 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle41 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle42 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle43 = new DataGridViewCellStyle();
            tlp_Main = new TableLayoutPanel();
            tlp_Halvfabrikat = new TableLayoutPanel();
            lbl_Halvfabrikat_ID = new TextBox();
            panel_Halvfabrikat_OrderNr = new Panel();
            cb_Halvfabrikat_BatchNr = new ComboBox();
            panel_Halvfabrikat_ArtikelNr = new Panel();
            cb_Halvfabrikat_ArtikelNr = new ComboBox();
            panel_Halvfabrikat_Typ = new Panel();
            cb_Halvfabrikat_Typ = new ComboBox();
            label_Halvfabrikat_Längd = new Label();
            label_Halvfabrikat_W = new Label();
            label_Halvfabrikat_OD = new Label();
            label_Halvfabrikat_BatchNr = new Label();
            label_Halvfabrikat_ArtikelNr = new Label();
            label_Halvfabrikat = new Label();
            label_Halvfabrikat_ID = new Label();
            label1 = new Label();
            dgv_Halvfabrikat = new DataGridView();
            Halvfabrikat_Slang = new DataGridViewTextBoxColumn();
            Halvfabrikat_ArtikelNr = new DataGridViewTextBoxColumn();
            Halvfabrikat_OrderNr = new DataGridViewTextBoxColumn();
            Halvfabrikat_ID = new DataGridViewTextBoxColumn();
            Halvfabrikat_OD = new DataGridViewTextBoxColumn();
            Halvfabrikat_W = new DataGridViewTextBoxColumn();
            Halvfabrikat_Längd = new DataGridViewTextBoxColumn();
            lbl_Transfer_Halvfabrikat = new Label();
            lbl_Halvfabrikat_OD = new TextBox();
            lbl_Halvfabrikat_W = new TextBox();
            lbl_Halvfabrikat_L = new TextBox();
            label_Empty_9 = new Label();
            lbl_Discard_Halvfabrikat = new Label();
            tlp_Produktion_Svetsning = new TableLayoutPanel();
            lbl_Edit_Row_Produktion = new Label();
            label_Inledande = new Label();
            panel_Produktion_OrderNr = new Panel();
            cb_Inledande_BatchNr = new ComboBox();
            label_Inledande_UppmättVidProduktionsStart = new Label();
            label_Inledande_Påse_Nr = new Label();
            label_Inledande_BatchNr = new Label();
            label_Inledande_Uppmätt_Pinn = new Label();
            label_Inledande_Skärmat = new Label();
            label_Produktion_Svetsning = new Label();
            tb_Inledande_Påse = new TextBox();
            label_Inspektion = new Label();
            label_Inledande_ID = new Label();
            label_Inledande_OD = new Label();
            label_Inledande_Längd = new Label();
            label_Inspektion_VisuellTest = new Label();
            label_Inspektion_Utsida = new Label();
            label_Inspektion_Insida = new Label();
            label_Inspektion_Datum = new Label();
            label_Inspektion_Tid = new Label();
            label_Inspektion_AnstNr = new Label();
            label_Inspektion_Sign = new Label();
            lbl_Transfer_Produktion = new Label();
            dgv_Produktion = new DataGridView();
            OrderNr = new DataGridViewTextBoxColumn();
            Påse_Nr = new DataGridViewTextBoxColumn();
            Uppmätt_Pinn = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            OD = new DataGridViewTextBoxColumn();
            Längd = new DataGridViewTextBoxColumn();
            Utsida = new DataGridViewCheckBoxColumn();
            Insida = new DataGridViewCheckBoxColumn();
            Datum = new DataGridViewTextBoxColumn();
            Tid = new DataGridViewTextBoxColumn();
            AnstNr = new DataGridViewTextBoxColumn();
            Sign = new DataGridViewTextBoxColumn();
            dgv_Produktion_TempID = new DataGridViewTextBoxColumn();
            label_Empty_5 = new Label();
            tb_InledandeUppmättPinne = new TextBox();
            tb_InledandeID = new TextBox();
            tb_InledandeOD = new TextBox();
            tb_InledandeLängd = new TextBox();
            label_Empty_6 = new Label();
            chb_InspektionUtsida = new CheckBox();
            chb_InspektionInsida = new CheckBox();
            lbl_Discard_Row_Produktion = new Label();
            tlp_Maskinparametrar = new TableLayoutPanel();
            tb_VärmebackarHål = new TextBox();
            dgv_MaskinParametrar = new DataGridView();
            dgv_Maskinparametrar_Svets = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Tid_Förvärme = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Svetsförflyttning = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Tid_Bindvärme = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Tid_Kylluft = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Temperatur = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Stål = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Pinne_PTFE = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Värmebackar_Bredd = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Värmebackar_Hål = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Datum = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Tid = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_AnstNr = new DataGridViewTextBoxColumn();
            dgv_Maskinparametrar_Sign = new DataGridViewTextBoxColumn();
            tb_VärmebackarBredd = new TextBox();
            lbl_Transfer_Maskinparametrar = new Label();
            tb_PinneODPTFE = new TextBox();
            lbl_Kassera_Maskinparameter = new Label();
            tb_PinneODStål = new TextBox();
            tb_Svets = new TextBox();
            tb_Temperatur = new TextBox();
            tb_TidFörvärme = new TextBox();
            tb_TidKylluft = new TextBox();
            tb_TidBindvärme = new TextBox();
            tb_Svetsförflyttning = new TextBox();
            PC_Svetsning_TEF = new PC_Svetsning_TEF();
            MainInfo = new MainInfo_Description_Prodtype();
            tlp_Main.SuspendLayout();
            tlp_Halvfabrikat.SuspendLayout();
            panel_Halvfabrikat_OrderNr.SuspendLayout();
            panel_Halvfabrikat_ArtikelNr.SuspendLayout();
            panel_Halvfabrikat_Typ.SuspendLayout();
            ((ISupportInitialize)dgv_Halvfabrikat).BeginInit();
            tlp_Produktion_Svetsning.SuspendLayout();
            panel_Produktion_OrderNr.SuspendLayout();
            ((ISupportInitialize)dgv_Produktion).BeginInit();
            tlp_Maskinparametrar.SuspendLayout();
            ((ISupportInitialize)dgv_MaskinParametrar).BeginInit();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Black;
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 973F));
            tlp_Main.Controls.Add(tlp_Halvfabrikat, 0, 3);
            tlp_Main.Controls.Add(tlp_Produktion_Svetsning, 0, 2);
            tlp_Main.Controls.Add(tlp_Maskinparametrar, 0, 1);
            tlp_Main.Controls.Add(MainInfo, 0, 0);
            tlp_Main.Cursor = Cursors.SizeAll;
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 4;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 276F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 284F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 9F));
            tlp_Main.Size = new Size(973, 966);
            tlp_Main.TabIndex = 1;
            // 
            // tlp_Halvfabrikat
            // 
            tlp_Halvfabrikat.BackColor = Color.Black;
            tlp_Halvfabrikat.ColumnCount = 9;
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 33F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 127F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 124F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 191F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 89F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 232F));
            tlp_Halvfabrikat.Controls.Add(lbl_Halvfabrikat_ID, 4, 2);
            tlp_Halvfabrikat.Controls.Add(panel_Halvfabrikat_OrderNr, 3, 2);
            tlp_Halvfabrikat.Controls.Add(panel_Halvfabrikat_ArtikelNr, 2, 2);
            tlp_Halvfabrikat.Controls.Add(panel_Halvfabrikat_Typ, 1, 2);
            tlp_Halvfabrikat.Controls.Add(label_Halvfabrikat_Längd, 7, 1);
            tlp_Halvfabrikat.Controls.Add(label_Halvfabrikat_W, 6, 1);
            tlp_Halvfabrikat.Controls.Add(label_Halvfabrikat_OD, 5, 1);
            tlp_Halvfabrikat.Controls.Add(label_Halvfabrikat_BatchNr, 3, 1);
            tlp_Halvfabrikat.Controls.Add(label_Halvfabrikat_ArtikelNr, 1, 1);
            tlp_Halvfabrikat.Controls.Add(label_Halvfabrikat, 0, 0);
            tlp_Halvfabrikat.Controls.Add(label_Halvfabrikat_ID, 4, 1);
            tlp_Halvfabrikat.Controls.Add(label1, 2, 1);
            tlp_Halvfabrikat.Controls.Add(dgv_Halvfabrikat, 1, 3);
            tlp_Halvfabrikat.Controls.Add(lbl_Transfer_Halvfabrikat, 0, 1);
            tlp_Halvfabrikat.Controls.Add(lbl_Halvfabrikat_OD, 5, 2);
            tlp_Halvfabrikat.Controls.Add(lbl_Halvfabrikat_W, 6, 2);
            tlp_Halvfabrikat.Controls.Add(lbl_Halvfabrikat_L, 7, 2);
            tlp_Halvfabrikat.Controls.Add(label_Empty_9, 8, 1);
            tlp_Halvfabrikat.Controls.Add(lbl_Discard_Halvfabrikat, 0, 3);
            tlp_Halvfabrikat.Dock = DockStyle.Fill;
            tlp_Halvfabrikat.Location = new Point(1, 614);
            tlp_Halvfabrikat.Margin = new Padding(1, 1, 1, 0);
            tlp_Halvfabrikat.Name = "tlp_Halvfabrikat";
            tlp_Halvfabrikat.RowCount = 5;
            tlp_Halvfabrikat.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tlp_Halvfabrikat.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_Halvfabrikat.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_Halvfabrikat.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp_Halvfabrikat.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tlp_Halvfabrikat.Size = new Size(971, 352);
            tlp_Halvfabrikat.TabIndex = 1025;
            // 
            // lbl_Halvfabrikat_ID
            // 
            lbl_Halvfabrikat_ID.BackColor = Color.White;
            lbl_Halvfabrikat_ID.BorderStyle = BorderStyle.None;
            lbl_Halvfabrikat_ID.Dock = DockStyle.Fill;
            lbl_Halvfabrikat_ID.Font = new Font("Courier New", 8.25F, FontStyle.Italic);
            lbl_Halvfabrikat_ID.ForeColor = Color.Gray;
            lbl_Halvfabrikat_ID.Location = new Point(476, 43);
            lbl_Halvfabrikat_ID.Margin = new Padding(1, 0, 0, 0);
            lbl_Halvfabrikat_ID.MaxLength = 6;
            lbl_Halvfabrikat_ID.Multiline = true;
            lbl_Halvfabrikat_ID.Name = "lbl_Halvfabrikat_ID";
            lbl_Halvfabrikat_ID.Size = new Size(57, 22);
            lbl_Halvfabrikat_ID.TabIndex = 916;
            // 
            // panel_Halvfabrikat_OrderNr
            // 
            panel_Halvfabrikat_OrderNr.BackColor = Color.White;
            panel_Halvfabrikat_OrderNr.Controls.Add(cb_Halvfabrikat_BatchNr);
            panel_Halvfabrikat_OrderNr.ForeColor = Color.Black;
            panel_Halvfabrikat_OrderNr.Location = new Point(285, 43);
            panel_Halvfabrikat_OrderNr.Margin = new Padding(1, 0, 0, 0);
            panel_Halvfabrikat_OrderNr.Name = "panel_Halvfabrikat_OrderNr";
            panel_Halvfabrikat_OrderNr.Size = new Size(190, 22);
            panel_Halvfabrikat_OrderNr.TabIndex = 920;
            // 
            // cb_Halvfabrikat_BatchNr
            // 
            cb_Halvfabrikat_BatchNr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_Halvfabrikat_BatchNr.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_Halvfabrikat_BatchNr.Cursor = Cursors.Hand;
            cb_Halvfabrikat_BatchNr.Dock = DockStyle.Fill;
            cb_Halvfabrikat_BatchNr.DropDownHeight = 130;
            cb_Halvfabrikat_BatchNr.DropDownWidth = 130;
            cb_Halvfabrikat_BatchNr.FlatStyle = FlatStyle.Flat;
            cb_Halvfabrikat_BatchNr.Font = new Font("Courier New", 8.25F);
            cb_Halvfabrikat_BatchNr.ForeColor = Color.DarkSlateGray;
            cb_Halvfabrikat_BatchNr.FormattingEnabled = true;
            cb_Halvfabrikat_BatchNr.IntegralHeight = false;
            cb_Halvfabrikat_BatchNr.Location = new Point(0, 0);
            cb_Halvfabrikat_BatchNr.Margin = new Padding(0);
            cb_Halvfabrikat_BatchNr.Name = "cb_Halvfabrikat_BatchNr";
            cb_Halvfabrikat_BatchNr.Size = new Size(190, 22);
            cb_Halvfabrikat_BatchNr.TabIndex = 32;
            // 
            // panel_Halvfabrikat_ArtikelNr
            // 
            panel_Halvfabrikat_ArtikelNr.BackColor = Color.White;
            panel_Halvfabrikat_ArtikelNr.Controls.Add(cb_Halvfabrikat_ArtikelNr);
            panel_Halvfabrikat_ArtikelNr.Dock = DockStyle.Fill;
            panel_Halvfabrikat_ArtikelNr.ForeColor = Color.Black;
            panel_Halvfabrikat_ArtikelNr.Location = new Point(161, 43);
            panel_Halvfabrikat_ArtikelNr.Margin = new Padding(1, 0, 0, 0);
            panel_Halvfabrikat_ArtikelNr.Name = "panel_Halvfabrikat_ArtikelNr";
            panel_Halvfabrikat_ArtikelNr.Size = new Size(123, 22);
            panel_Halvfabrikat_ArtikelNr.TabIndex = 919;
            // 
            // cb_Halvfabrikat_ArtikelNr
            // 
            cb_Halvfabrikat_ArtikelNr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_Halvfabrikat_ArtikelNr.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_Halvfabrikat_ArtikelNr.Cursor = Cursors.Hand;
            cb_Halvfabrikat_ArtikelNr.Dock = DockStyle.Fill;
            cb_Halvfabrikat_ArtikelNr.DropDownHeight = 130;
            cb_Halvfabrikat_ArtikelNr.DropDownWidth = 130;
            cb_Halvfabrikat_ArtikelNr.FlatStyle = FlatStyle.Flat;
            cb_Halvfabrikat_ArtikelNr.Font = new Font("Courier New", 8.25F);
            cb_Halvfabrikat_ArtikelNr.ForeColor = Color.DarkSlateGray;
            cb_Halvfabrikat_ArtikelNr.FormattingEnabled = true;
            cb_Halvfabrikat_ArtikelNr.IntegralHeight = false;
            cb_Halvfabrikat_ArtikelNr.Location = new Point(0, 0);
            cb_Halvfabrikat_ArtikelNr.Margin = new Padding(0);
            cb_Halvfabrikat_ArtikelNr.Name = "cb_Halvfabrikat_ArtikelNr";
            cb_Halvfabrikat_ArtikelNr.Size = new Size(123, 22);
            cb_Halvfabrikat_ArtikelNr.TabIndex = 31;
            cb_Halvfabrikat_ArtikelNr.TextChanged += Halvfabrikat_ArtikelNr_TextChanged;
            // 
            // panel_Halvfabrikat_Typ
            // 
            panel_Halvfabrikat_Typ.BackColor = Color.White;
            panel_Halvfabrikat_Typ.Controls.Add(cb_Halvfabrikat_Typ);
            panel_Halvfabrikat_Typ.Dock = DockStyle.Fill;
            panel_Halvfabrikat_Typ.ForeColor = Color.Black;
            panel_Halvfabrikat_Typ.Location = new Point(34, 43);
            panel_Halvfabrikat_Typ.Margin = new Padding(1, 0, 0, 0);
            panel_Halvfabrikat_Typ.Name = "panel_Halvfabrikat_Typ";
            panel_Halvfabrikat_Typ.Size = new Size(126, 22);
            panel_Halvfabrikat_Typ.TabIndex = 918;
            // 
            // cb_Halvfabrikat_Typ
            // 
            cb_Halvfabrikat_Typ.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_Halvfabrikat_Typ.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_Halvfabrikat_Typ.Cursor = Cursors.Hand;
            cb_Halvfabrikat_Typ.Dock = DockStyle.Fill;
            cb_Halvfabrikat_Typ.DropDownHeight = 130;
            cb_Halvfabrikat_Typ.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Halvfabrikat_Typ.DropDownWidth = 130;
            cb_Halvfabrikat_Typ.FlatStyle = FlatStyle.Flat;
            cb_Halvfabrikat_Typ.Font = new Font("Courier New", 8.25F);
            cb_Halvfabrikat_Typ.ForeColor = Color.DarkSlateGray;
            cb_Halvfabrikat_Typ.FormattingEnabled = true;
            cb_Halvfabrikat_Typ.IntegralHeight = false;
            cb_Halvfabrikat_Typ.Items.AddRange(new object[] { "Skärmad", "Mjuk", "Formar" });
            cb_Halvfabrikat_Typ.Location = new Point(0, 0);
            cb_Halvfabrikat_Typ.Margin = new Padding(0);
            cb_Halvfabrikat_Typ.Name = "cb_Halvfabrikat_Typ";
            cb_Halvfabrikat_Typ.Size = new Size(126, 22);
            cb_Halvfabrikat_Typ.TabIndex = 30;
            // 
            // label_Halvfabrikat_Längd
            // 
            label_Halvfabrikat_Längd.BackColor = Color.White;
            label_Halvfabrikat_Längd.Dock = DockStyle.Fill;
            label_Halvfabrikat_Längd.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Halvfabrikat_Längd.ForeColor = Color.Black;
            label_Halvfabrikat_Längd.Location = new Point(650, 22);
            label_Halvfabrikat_Längd.Margin = new Padding(1, 1, 0, 1);
            label_Halvfabrikat_Längd.Name = "label_Halvfabrikat_Längd";
            label_Halvfabrikat_Längd.Size = new Size(88, 20);
            label_Halvfabrikat_Längd.TabIndex = 917;
            label_Halvfabrikat_Längd.Text = "Längd";
            label_Halvfabrikat_Längd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Halvfabrikat_W
            // 
            label_Halvfabrikat_W.BackColor = Color.White;
            label_Halvfabrikat_W.Dock = DockStyle.Fill;
            label_Halvfabrikat_W.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Halvfabrikat_W.ForeColor = Color.Black;
            label_Halvfabrikat_W.Location = new Point(592, 22);
            label_Halvfabrikat_W.Margin = new Padding(1, 1, 0, 1);
            label_Halvfabrikat_W.Name = "label_Halvfabrikat_W";
            label_Halvfabrikat_W.Size = new Size(57, 20);
            label_Halvfabrikat_W.TabIndex = 916;
            label_Halvfabrikat_W.Text = "W";
            label_Halvfabrikat_W.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Halvfabrikat_OD
            // 
            label_Halvfabrikat_OD.BackColor = Color.White;
            label_Halvfabrikat_OD.Dock = DockStyle.Fill;
            label_Halvfabrikat_OD.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Halvfabrikat_OD.ForeColor = Color.Black;
            label_Halvfabrikat_OD.Location = new Point(534, 22);
            label_Halvfabrikat_OD.Margin = new Padding(1, 1, 0, 1);
            label_Halvfabrikat_OD.Name = "label_Halvfabrikat_OD";
            label_Halvfabrikat_OD.Size = new Size(57, 20);
            label_Halvfabrikat_OD.TabIndex = 914;
            label_Halvfabrikat_OD.Text = "OD";
            label_Halvfabrikat_OD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Halvfabrikat_BatchNr
            // 
            label_Halvfabrikat_BatchNr.BackColor = Color.White;
            label_Halvfabrikat_BatchNr.Dock = DockStyle.Fill;
            label_Halvfabrikat_BatchNr.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Halvfabrikat_BatchNr.ForeColor = Color.Black;
            label_Halvfabrikat_BatchNr.Location = new Point(285, 22);
            label_Halvfabrikat_BatchNr.Margin = new Padding(1, 1, 0, 1);
            label_Halvfabrikat_BatchNr.Name = "label_Halvfabrikat_BatchNr";
            label_Halvfabrikat_BatchNr.Size = new Size(190, 20);
            label_Halvfabrikat_BatchNr.TabIndex = 908;
            label_Halvfabrikat_BatchNr.Text = "BatchNr";
            label_Halvfabrikat_BatchNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Halvfabrikat_ArtikelNr
            // 
            label_Halvfabrikat_ArtikelNr.BackColor = Color.White;
            label_Halvfabrikat_ArtikelNr.Dock = DockStyle.Fill;
            label_Halvfabrikat_ArtikelNr.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Halvfabrikat_ArtikelNr.ForeColor = Color.Black;
            label_Halvfabrikat_ArtikelNr.Location = new Point(34, 22);
            label_Halvfabrikat_ArtikelNr.Margin = new Padding(1, 1, 0, 1);
            label_Halvfabrikat_ArtikelNr.Name = "label_Halvfabrikat_ArtikelNr";
            label_Halvfabrikat_ArtikelNr.Size = new Size(126, 20);
            label_Halvfabrikat_ArtikelNr.TabIndex = 906;
            label_Halvfabrikat_ArtikelNr.Text = "Slang";
            label_Halvfabrikat_ArtikelNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Halvfabrikat
            // 
            label_Halvfabrikat.BackColor = Color.FromArgb(235, 235, 235);
            tlp_Halvfabrikat.SetColumnSpan(label_Halvfabrikat, 9);
            label_Halvfabrikat.Cursor = Cursors.SizeAll;
            label_Halvfabrikat.Dock = DockStyle.Fill;
            label_Halvfabrikat.Font = new Font("Palatino Linotype", 10.25F);
            label_Halvfabrikat.ForeColor = Color.CornflowerBlue;
            label_Halvfabrikat.Location = new Point(0, 0);
            label_Halvfabrikat.Margin = new Padding(0);
            label_Halvfabrikat.Name = "label_Halvfabrikat";
            label_Halvfabrikat.Size = new Size(971, 21);
            label_Halvfabrikat.TabIndex = 904;
            label_Halvfabrikat.Text = "Halvfabrikat:";
            // 
            // label_Halvfabrikat_ID
            // 
            label_Halvfabrikat_ID.BackColor = Color.White;
            label_Halvfabrikat_ID.Dock = DockStyle.Fill;
            label_Halvfabrikat_ID.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Halvfabrikat_ID.ForeColor = Color.Black;
            label_Halvfabrikat_ID.Location = new Point(476, 22);
            label_Halvfabrikat_ID.Margin = new Padding(1, 1, 0, 1);
            label_Halvfabrikat_ID.Name = "label_Halvfabrikat_ID";
            label_Halvfabrikat_ID.Size = new Size(57, 20);
            label_Halvfabrikat_ID.TabIndex = 913;
            label_Halvfabrikat_ID.Text = "ID";
            label_Halvfabrikat_ID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(161, 22);
            label1.Margin = new Padding(1, 1, 0, 1);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 906;
            label1.Text = "ArtikelNr";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgv_Halvfabrikat
            // 
            dgv_Halvfabrikat.AllowUserToAddRows = false;
            dgv_Halvfabrikat.AllowUserToDeleteRows = false;
            dgv_Halvfabrikat.AllowUserToResizeColumns = false;
            dgv_Halvfabrikat.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgv_Halvfabrikat.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Halvfabrikat.BackgroundColor = Color.White;
            dgv_Halvfabrikat.BorderStyle = BorderStyle.None;
            dgv_Halvfabrikat.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Courier New", 8.25F);
            dataGridViewCellStyle2.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_Halvfabrikat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_Halvfabrikat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Halvfabrikat.ColumnHeadersVisible = false;
            dgv_Halvfabrikat.Columns.AddRange(new DataGridViewColumn[] { Halvfabrikat_Slang, Halvfabrikat_ArtikelNr, Halvfabrikat_OrderNr, Halvfabrikat_ID, Halvfabrikat_OD, Halvfabrikat_W, Halvfabrikat_Längd });
            tlp_Halvfabrikat.SetColumnSpan(dgv_Halvfabrikat, 7);
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = SystemColors.Window;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgv_Halvfabrikat.DefaultCellStyle = dataGridViewCellStyle10;
            dgv_Halvfabrikat.Dock = DockStyle.Fill;
            dgv_Halvfabrikat.Location = new Point(34, 67);
            dgv_Halvfabrikat.Margin = new Padding(1, 2, 0, 0);
            dgv_Halvfabrikat.MultiSelect = false;
            dgv_Halvfabrikat.Name = "dgv_Halvfabrikat";
            dgv_Halvfabrikat.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Control;
            dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgv_Halvfabrikat.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgv_Halvfabrikat.RowHeadersVisible = false;
            tlp_Halvfabrikat.SetRowSpan(dgv_Halvfabrikat, 2);
            dgv_Halvfabrikat.ScrollBars = ScrollBars.None;
            dgv_Halvfabrikat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Halvfabrikat.Size = new Size(704, 285);
            dgv_Halvfabrikat.TabIndex = 845;
            // 
            // Halvfabrikat_Slang
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new Font("Courier New", 8.5F);
            dataGridViewCellStyle3.ForeColor = Color.DarkSlateGray;
            Halvfabrikat_Slang.DefaultCellStyle = dataGridViewCellStyle3;
            Halvfabrikat_Slang.HeaderText = "Slang";
            Halvfabrikat_Slang.Name = "Halvfabrikat_Slang";
            Halvfabrikat_Slang.ReadOnly = true;
            Halvfabrikat_Slang.Resizable = DataGridViewTriState.False;
            Halvfabrikat_Slang.SortMode = DataGridViewColumnSortMode.NotSortable;
            Halvfabrikat_Slang.Width = 127;
            // 
            // Halvfabrikat_ArtikelNr
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new Font("Courier New", 8.5F);
            dataGridViewCellStyle4.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            Halvfabrikat_ArtikelNr.DefaultCellStyle = dataGridViewCellStyle4;
            Halvfabrikat_ArtikelNr.HeaderText = "ArtikelNr";
            Halvfabrikat_ArtikelNr.Name = "Halvfabrikat_ArtikelNr";
            Halvfabrikat_ArtikelNr.ReadOnly = true;
            Halvfabrikat_ArtikelNr.Resizable = DataGridViewTriState.False;
            Halvfabrikat_ArtikelNr.SortMode = DataGridViewColumnSortMode.NotSortable;
            Halvfabrikat_ArtikelNr.Width = 123;
            // 
            // Halvfabrikat_OrderNr
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new Font("Courier New", 8.5F);
            dataGridViewCellStyle5.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            Halvfabrikat_OrderNr.DefaultCellStyle = dataGridViewCellStyle5;
            Halvfabrikat_OrderNr.HeaderText = "OrderNr";
            Halvfabrikat_OrderNr.Name = "Halvfabrikat_OrderNr";
            Halvfabrikat_OrderNr.ReadOnly = true;
            Halvfabrikat_OrderNr.Resizable = DataGridViewTriState.False;
            Halvfabrikat_OrderNr.SortMode = DataGridViewColumnSortMode.NotSortable;
            Halvfabrikat_OrderNr.Width = 191;
            // 
            // Halvfabrikat_ID
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new Font("Consolas", 8.5F);
            dataGridViewCellStyle6.ForeColor = Color.Gray;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            Halvfabrikat_ID.DefaultCellStyle = dataGridViewCellStyle6;
            Halvfabrikat_ID.HeaderText = "ID";
            Halvfabrikat_ID.Name = "Halvfabrikat_ID";
            Halvfabrikat_ID.ReadOnly = true;
            Halvfabrikat_ID.Width = 58;
            // 
            // Halvfabrikat_OD
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new Font("Consolas", 8.5F);
            dataGridViewCellStyle7.ForeColor = Color.Gray;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            Halvfabrikat_OD.DefaultCellStyle = dataGridViewCellStyle7;
            Halvfabrikat_OD.HeaderText = "OD";
            Halvfabrikat_OD.Name = "Halvfabrikat_OD";
            Halvfabrikat_OD.ReadOnly = true;
            Halvfabrikat_OD.Width = 58;
            // 
            // Halvfabrikat_W
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Consolas", 8.5F);
            dataGridViewCellStyle8.ForeColor = Color.Gray;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            Halvfabrikat_W.DefaultCellStyle = dataGridViewCellStyle8;
            Halvfabrikat_W.HeaderText = "W";
            Halvfabrikat_W.Name = "Halvfabrikat_W";
            Halvfabrikat_W.ReadOnly = true;
            Halvfabrikat_W.Width = 58;
            // 
            // Halvfabrikat_Längd
            // 
            Halvfabrikat_Längd.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new Font("Consolas", 8.5F);
            dataGridViewCellStyle9.ForeColor = Color.Gray;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            Halvfabrikat_Längd.DefaultCellStyle = dataGridViewCellStyle9;
            Halvfabrikat_Längd.HeaderText = "Längd";
            Halvfabrikat_Längd.Name = "Halvfabrikat_Längd";
            Halvfabrikat_Längd.ReadOnly = true;
            // 
            // lbl_Transfer_Halvfabrikat
            // 
            lbl_Transfer_Halvfabrikat.BackColor = Color.FromArgb(198, 239, 206);
            lbl_Transfer_Halvfabrikat.Cursor = Cursors.Hand;
            lbl_Transfer_Halvfabrikat.Dock = DockStyle.Fill;
            lbl_Transfer_Halvfabrikat.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            lbl_Transfer_Halvfabrikat.ForeColor = Color.FromArgb(0, 97, 0);
            lbl_Transfer_Halvfabrikat.Location = new Point(0, 22);
            lbl_Transfer_Halvfabrikat.Margin = new Padding(0, 1, 0, 0);
            lbl_Transfer_Halvfabrikat.Name = "lbl_Transfer_Halvfabrikat";
            tlp_Halvfabrikat.SetRowSpan(lbl_Transfer_Halvfabrikat, 2);
            lbl_Transfer_Halvfabrikat.Size = new Size(33, 43);
            lbl_Transfer_Halvfabrikat.TabIndex = 33;
            lbl_Transfer_Halvfabrikat.Text = "→";
            lbl_Transfer_Halvfabrikat.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Transfer_Halvfabrikat.Click += Save_Halvfabrikat_Click;
            // 
            // lbl_Halvfabrikat_OD
            // 
            lbl_Halvfabrikat_OD.BackColor = Color.White;
            lbl_Halvfabrikat_OD.BorderStyle = BorderStyle.None;
            lbl_Halvfabrikat_OD.Dock = DockStyle.Fill;
            lbl_Halvfabrikat_OD.Font = new Font("Courier New", 8.25F, FontStyle.Italic);
            lbl_Halvfabrikat_OD.ForeColor = Color.Gray;
            lbl_Halvfabrikat_OD.Location = new Point(534, 43);
            lbl_Halvfabrikat_OD.Margin = new Padding(1, 0, 0, 0);
            lbl_Halvfabrikat_OD.MaxLength = 6;
            lbl_Halvfabrikat_OD.Multiline = true;
            lbl_Halvfabrikat_OD.Name = "lbl_Halvfabrikat_OD";
            lbl_Halvfabrikat_OD.Size = new Size(57, 22);
            lbl_Halvfabrikat_OD.TabIndex = 916;
            // 
            // lbl_Halvfabrikat_W
            // 
            lbl_Halvfabrikat_W.BackColor = Color.White;
            lbl_Halvfabrikat_W.BorderStyle = BorderStyle.None;
            lbl_Halvfabrikat_W.Dock = DockStyle.Fill;
            lbl_Halvfabrikat_W.Font = new Font("Courier New", 8.25F, FontStyle.Italic);
            lbl_Halvfabrikat_W.ForeColor = Color.Gray;
            lbl_Halvfabrikat_W.Location = new Point(592, 43);
            lbl_Halvfabrikat_W.Margin = new Padding(1, 0, 0, 0);
            lbl_Halvfabrikat_W.MaxLength = 5;
            lbl_Halvfabrikat_W.Multiline = true;
            lbl_Halvfabrikat_W.Name = "lbl_Halvfabrikat_W";
            lbl_Halvfabrikat_W.Size = new Size(57, 22);
            lbl_Halvfabrikat_W.TabIndex = 916;
            // 
            // lbl_Halvfabrikat_L
            // 
            lbl_Halvfabrikat_L.BackColor = Color.White;
            lbl_Halvfabrikat_L.BorderStyle = BorderStyle.None;
            lbl_Halvfabrikat_L.Dock = DockStyle.Fill;
            lbl_Halvfabrikat_L.Font = new Font("Courier New", 8.25F, FontStyle.Italic);
            lbl_Halvfabrikat_L.ForeColor = Color.Gray;
            lbl_Halvfabrikat_L.Location = new Point(650, 43);
            lbl_Halvfabrikat_L.Margin = new Padding(1, 0, 0, 0);
            lbl_Halvfabrikat_L.MaxLength = 8;
            lbl_Halvfabrikat_L.Multiline = true;
            lbl_Halvfabrikat_L.Name = "lbl_Halvfabrikat_L";
            lbl_Halvfabrikat_L.Size = new Size(88, 22);
            lbl_Halvfabrikat_L.TabIndex = 916;
            // 
            // label_Empty_9
            // 
            label_Empty_9.BackColor = Color.DarkGray;
            label_Empty_9.Dock = DockStyle.Fill;
            label_Empty_9.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_9.ForeColor = Color.ForestGreen;
            label_Empty_9.Location = new Point(739, 22);
            label_Empty_9.Margin = new Padding(1, 1, 0, 0);
            label_Empty_9.Name = "label_Empty_9";
            tlp_Halvfabrikat.SetRowSpan(label_Empty_9, 4);
            label_Empty_9.Size = new Size(232, 330);
            label_Empty_9.TabIndex = 1007;
            label_Empty_9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Discard_Halvfabrikat
            // 
            lbl_Discard_Halvfabrikat.BackColor = Color.FromArgb(255, 199, 206);
            lbl_Discard_Halvfabrikat.Cursor = Cursors.Hand;
            lbl_Discard_Halvfabrikat.Dock = DockStyle.Fill;
            lbl_Discard_Halvfabrikat.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Discard_Halvfabrikat.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_Discard_Halvfabrikat.Location = new Point(0, 66);
            lbl_Discard_Halvfabrikat.Margin = new Padding(0, 1, 0, 0);
            lbl_Discard_Halvfabrikat.Name = "lbl_Discard_Halvfabrikat";
            lbl_Discard_Halvfabrikat.Size = new Size(33, 29);
            lbl_Discard_Halvfabrikat.TabIndex = 28;
            lbl_Discard_Halvfabrikat.Text = "→";
            lbl_Discard_Halvfabrikat.TextAlign = ContentAlignment.TopCenter;
            lbl_Discard_Halvfabrikat.Click += Delete_Row_Halvfabrikat_Click;
            // 
            // tlp_Produktion_Svetsning
            // 
            tlp_Produktion_Svetsning.BackColor = Color.Black;
            tlp_Produktion_Svetsning.ColumnCount = 13;
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 97F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 71F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 71F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 69F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 69F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 64F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65F));
            tlp_Produktion_Svetsning.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 124F));
            tlp_Produktion_Svetsning.Controls.Add(lbl_Edit_Row_Produktion, 0, 6);
            tlp_Produktion_Svetsning.Controls.Add(label_Inledande, 1, 1);
            tlp_Produktion_Svetsning.Controls.Add(panel_Produktion_OrderNr, 1, 4);
            tlp_Produktion_Svetsning.Controls.Add(label_Inledande_UppmättVidProduktionsStart, 4, 2);
            tlp_Produktion_Svetsning.Controls.Add(label_Inledande_Påse_Nr, 2, 3);
            tlp_Produktion_Svetsning.Controls.Add(label_Inledande_BatchNr, 1, 3);
            tlp_Produktion_Svetsning.Controls.Add(label_Inledande_Uppmätt_Pinn, 3, 2);
            tlp_Produktion_Svetsning.Controls.Add(label_Inledande_Skärmat, 1, 2);
            tlp_Produktion_Svetsning.Controls.Add(label_Produktion_Svetsning, 0, 0);
            tlp_Produktion_Svetsning.Controls.Add(tb_Inledande_Påse, 2, 4);
            tlp_Produktion_Svetsning.Controls.Add(label_Inspektion, 7, 1);
            tlp_Produktion_Svetsning.Controls.Add(label_Inledande_ID, 4, 3);
            tlp_Produktion_Svetsning.Controls.Add(label_Inledande_OD, 5, 3);
            tlp_Produktion_Svetsning.Controls.Add(label_Inledande_Längd, 6, 3);
            tlp_Produktion_Svetsning.Controls.Add(label_Inspektion_VisuellTest, 7, 2);
            tlp_Produktion_Svetsning.Controls.Add(label_Inspektion_Utsida, 7, 3);
            tlp_Produktion_Svetsning.Controls.Add(label_Inspektion_Insida, 8, 3);
            tlp_Produktion_Svetsning.Controls.Add(label_Inspektion_Datum, 9, 2);
            tlp_Produktion_Svetsning.Controls.Add(label_Inspektion_Tid, 10, 2);
            tlp_Produktion_Svetsning.Controls.Add(label_Inspektion_AnstNr, 11, 2);
            tlp_Produktion_Svetsning.Controls.Add(label_Inspektion_Sign, 12, 2);
            tlp_Produktion_Svetsning.Controls.Add(lbl_Transfer_Produktion, 0, 4);
            tlp_Produktion_Svetsning.Controls.Add(dgv_Produktion, 1, 5);
            tlp_Produktion_Svetsning.Controls.Add(label_Empty_5, 0, 1);
            tlp_Produktion_Svetsning.Controls.Add(tb_InledandeUppmättPinne, 3, 4);
            tlp_Produktion_Svetsning.Controls.Add(tb_InledandeID, 4, 4);
            tlp_Produktion_Svetsning.Controls.Add(tb_InledandeOD, 5, 4);
            tlp_Produktion_Svetsning.Controls.Add(tb_InledandeLängd, 6, 4);
            tlp_Produktion_Svetsning.Controls.Add(label_Empty_6, 9, 4);
            tlp_Produktion_Svetsning.Controls.Add(chb_InspektionUtsida, 7, 4);
            tlp_Produktion_Svetsning.Controls.Add(chb_InspektionInsida, 8, 4);
            tlp_Produktion_Svetsning.Controls.Add(lbl_Discard_Row_Produktion, 0, 5);
            tlp_Produktion_Svetsning.Dock = DockStyle.Fill;
            tlp_Produktion_Svetsning.Location = new Point(0, 329);
            tlp_Produktion_Svetsning.Margin = new Padding(0);
            tlp_Produktion_Svetsning.Name = "tlp_Produktion_Svetsning";
            tlp_Produktion_Svetsning.RowCount = 7;
            tlp_Produktion_Svetsning.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Produktion_Svetsning.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Produktion_Svetsning.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_Produktion_Svetsning.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tlp_Produktion_Svetsning.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlp_Produktion_Svetsning.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_Produktion_Svetsning.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Produktion_Svetsning.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Produktion_Svetsning.Size = new Size(973, 284);
            tlp_Produktion_Svetsning.TabIndex = 1021;
            // 
            // lbl_Edit_Row_Produktion
            // 
            lbl_Edit_Row_Produktion.BackColor = Color.FromArgb(255, 235, 156);
            lbl_Edit_Row_Produktion.Cursor = Cursors.Hand;
            lbl_Edit_Row_Produktion.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Edit_Row_Produktion.ForeColor = Color.FromArgb(156, 101, 0);
            lbl_Edit_Row_Produktion.Location = new Point(1, 182);
            lbl_Edit_Row_Produktion.Margin = new Padding(1, 1, 0, 0);
            lbl_Edit_Row_Produktion.Name = "lbl_Edit_Row_Produktion";
            lbl_Edit_Row_Produktion.Size = new Size(33, 27);
            lbl_Edit_Row_Produktion.TabIndex = 1029;
            lbl_Edit_Row_Produktion.Text = "→";
            lbl_Edit_Row_Produktion.TextAlign = ContentAlignment.TopCenter;
            lbl_Edit_Row_Produktion.Click += Edit_Row_Produktion_Click;
            // 
            // label_Inledande
            // 
            label_Inledande.BackColor = Color.White;
            tlp_Produktion_Svetsning.SetColumnSpan(label_Inledande, 6);
            label_Inledande.Dock = DockStyle.Fill;
            label_Inledande.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Inledande.ForeColor = Color.Black;
            label_Inledande.Location = new Point(35, 25);
            label_Inledande.Margin = new Padding(1, 0, 1, 1);
            label_Inledande.Name = "label_Inledande";
            label_Inledande.Size = new Size(445, 22);
            label_Inledande.TabIndex = 1025;
            label_Inledande.Text = "Inledande";
            label_Inledande.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel_Produktion_OrderNr
            // 
            panel_Produktion_OrderNr.BackColor = Color.White;
            panel_Produktion_OrderNr.Controls.Add(cb_Inledande_BatchNr);
            panel_Produktion_OrderNr.Dock = DockStyle.Fill;
            panel_Produktion_OrderNr.ForeColor = Color.Black;
            panel_Produktion_OrderNr.Location = new Point(35, 131);
            panel_Produktion_OrderNr.Margin = new Padding(1, 1, 0, 0);
            panel_Produktion_OrderNr.Name = "panel_Produktion_OrderNr";
            panel_Produktion_OrderNr.Size = new Size(96, 23);
            panel_Produktion_OrderNr.TabIndex = 920;
            // 
            // cb_Inledande_BatchNr
            // 
            cb_Inledande_BatchNr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_Inledande_BatchNr.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_Inledande_BatchNr.Cursor = Cursors.Hand;
            cb_Inledande_BatchNr.Dock = DockStyle.Fill;
            cb_Inledande_BatchNr.DropDownHeight = 130;
            cb_Inledande_BatchNr.DropDownWidth = 130;
            cb_Inledande_BatchNr.FlatStyle = FlatStyle.Flat;
            cb_Inledande_BatchNr.Font = new Font("Courier New", 8.25F);
            cb_Inledande_BatchNr.ForeColor = Color.DarkSlateGray;
            cb_Inledande_BatchNr.FormattingEnabled = true;
            cb_Inledande_BatchNr.IntegralHeight = false;
            cb_Inledande_BatchNr.Location = new Point(0, 0);
            cb_Inledande_BatchNr.Margin = new Padding(0);
            cb_Inledande_BatchNr.Name = "cb_Inledande_BatchNr";
            cb_Inledande_BatchNr.Size = new Size(96, 22);
            cb_Inledande_BatchNr.TabIndex = 20;
            // 
            // label_Inledande_UppmättVidProduktionsStart
            // 
            label_Inledande_UppmättVidProduktionsStart.BackColor = Color.White;
            tlp_Produktion_Svetsning.SetColumnSpan(label_Inledande_UppmättVidProduktionsStart, 3);
            label_Inledande_UppmättVidProduktionsStart.Dock = DockStyle.Fill;
            label_Inledande_UppmättVidProduktionsStart.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            label_Inledande_UppmättVidProduktionsStart.ForeColor = Color.Black;
            label_Inledande_UppmättVidProduktionsStart.Location = new Point(250, 48);
            label_Inledande_UppmättVidProduktionsStart.Margin = new Padding(1, 0, 1, 1);
            label_Inledande_UppmättVidProduktionsStart.Name = "label_Inledande_UppmättVidProduktionsStart";
            label_Inledande_UppmättVidProduktionsStart.Size = new Size(230, 26);
            label_Inledande_UppmättVidProduktionsStart.TabIndex = 1024;
            label_Inledande_UppmättVidProduktionsStart.Text = "Uppmätt vid produktionsstart";
            label_Inledande_UppmättVidProduktionsStart.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_Påse_Nr
            // 
            label_Inledande_Påse_Nr.BackColor = Color.White;
            label_Inledande_Påse_Nr.Dock = DockStyle.Fill;
            label_Inledande_Påse_Nr.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Inledande_Påse_Nr.ForeColor = Color.Black;
            label_Inledande_Påse_Nr.Location = new Point(132, 75);
            label_Inledande_Påse_Nr.Margin = new Padding(1, 0, 0, 1);
            label_Inledande_Påse_Nr.Name = "label_Inledande_Påse_Nr";
            label_Inledande_Påse_Nr.Size = new Size(47, 54);
            label_Inledande_Påse_Nr.TabIndex = 1023;
            label_Inledande_Påse_Nr.Text = "Påse Nr";
            label_Inledande_Påse_Nr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_BatchNr
            // 
            label_Inledande_BatchNr.BackColor = Color.White;
            label_Inledande_BatchNr.Dock = DockStyle.Fill;
            label_Inledande_BatchNr.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Inledande_BatchNr.ForeColor = Color.Black;
            label_Inledande_BatchNr.Location = new Point(35, 75);
            label_Inledande_BatchNr.Margin = new Padding(1, 0, 0, 1);
            label_Inledande_BatchNr.Name = "label_Inledande_BatchNr";
            label_Inledande_BatchNr.Size = new Size(96, 54);
            label_Inledande_BatchNr.TabIndex = 1022;
            label_Inledande_BatchNr.Text = "BatchNr";
            label_Inledande_BatchNr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_Uppmätt_Pinn
            // 
            label_Inledande_Uppmätt_Pinn.BackColor = Color.White;
            label_Inledande_Uppmätt_Pinn.Dock = DockStyle.Fill;
            label_Inledande_Uppmätt_Pinn.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Inledande_Uppmätt_Pinn.ForeColor = Color.Black;
            label_Inledande_Uppmätt_Pinn.Location = new Point(180, 48);
            label_Inledande_Uppmätt_Pinn.Margin = new Padding(1, 0, 0, 1);
            label_Inledande_Uppmätt_Pinn.Name = "label_Inledande_Uppmätt_Pinn";
            tlp_Produktion_Svetsning.SetRowSpan(label_Inledande_Uppmätt_Pinn, 2);
            label_Inledande_Uppmätt_Pinn.Size = new Size(69, 81);
            label_Inledande_Uppmätt_Pinn.TabIndex = 1021;
            label_Inledande_Uppmätt_Pinn.Text = "Uppmätt pinne";
            label_Inledande_Uppmätt_Pinn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_Skärmat
            // 
            label_Inledande_Skärmat.BackColor = Color.White;
            tlp_Produktion_Svetsning.SetColumnSpan(label_Inledande_Skärmat, 2);
            label_Inledande_Skärmat.Dock = DockStyle.Fill;
            label_Inledande_Skärmat.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            label_Inledande_Skärmat.ForeColor = Color.Black;
            label_Inledande_Skärmat.Location = new Point(35, 48);
            label_Inledande_Skärmat.Margin = new Padding(1, 0, 0, 1);
            label_Inledande_Skärmat.Name = "label_Inledande_Skärmat";
            label_Inledande_Skärmat.Size = new Size(144, 26);
            label_Inledande_Skärmat.TabIndex = 1020;
            label_Inledande_Skärmat.Text = "Skärmat";
            label_Inledande_Skärmat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Svetsning
            // 
            label_Produktion_Svetsning.BackColor = Color.FromArgb(235, 235, 235);
            label_Produktion_Svetsning.BorderStyle = BorderStyle.FixedSingle;
            tlp_Produktion_Svetsning.SetColumnSpan(label_Produktion_Svetsning, 13);
            label_Produktion_Svetsning.Cursor = Cursors.SizeAll;
            label_Produktion_Svetsning.Dock = DockStyle.Fill;
            label_Produktion_Svetsning.Font = new Font("Palatino Linotype", 10.25F);
            label_Produktion_Svetsning.ForeColor = Color.SaddleBrown;
            label_Produktion_Svetsning.Location = new Point(0, 0);
            label_Produktion_Svetsning.Margin = new Padding(0);
            label_Produktion_Svetsning.Name = "label_Produktion_Svetsning";
            label_Produktion_Svetsning.Size = new Size(974, 25);
            label_Produktion_Svetsning.TabIndex = 908;
            label_Produktion_Svetsning.Text = "Produktion/Svetsning";
            label_Produktion_Svetsning.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_Inledande_Påse
            // 
            tb_Inledande_Påse.BackColor = Color.White;
            tb_Inledande_Påse.BorderStyle = BorderStyle.None;
            tb_Inledande_Påse.Cursor = Cursors.IBeam;
            tb_Inledande_Påse.Dock = DockStyle.Fill;
            tb_Inledande_Påse.Font = new Font("Courier New", 8.25F);
            tb_Inledande_Påse.ForeColor = Color.DarkSlateGray;
            tb_Inledande_Påse.Location = new Point(132, 131);
            tb_Inledande_Påse.Margin = new Padding(1, 1, 0, 0);
            tb_Inledande_Påse.Multiline = true;
            tb_Inledande_Påse.Name = "tb_Inledande_Påse";
            tb_Inledande_Påse.Size = new Size(47, 23);
            tb_Inledande_Påse.TabIndex = 21;
            tb_Inledande_Påse.TextAlign = HorizontalAlignment.Center;
            tb_Inledande_Påse.WordWrap = false;
            tb_Inledande_Påse.KeyDown += EnterToTab_KeyDown;
            // 
            // label_Inspektion
            // 
            label_Inspektion.BackColor = Color.White;
            tlp_Produktion_Svetsning.SetColumnSpan(label_Inspektion, 6);
            label_Inspektion.Dock = DockStyle.Fill;
            label_Inspektion.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Inspektion.ForeColor = Color.Black;
            label_Inspektion.Location = new Point(482, 25);
            label_Inspektion.Margin = new Padding(1, 0, 1, 1);
            label_Inspektion.Name = "label_Inspektion";
            label_Inspektion.Size = new Size(491, 22);
            label_Inspektion.TabIndex = 1019;
            label_Inspektion.Text = "Inspektion, färdig svets";
            label_Inspektion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Inledande_ID
            // 
            label_Inledande_ID.BackColor = Color.White;
            label_Inledande_ID.Dock = DockStyle.Fill;
            label_Inledande_ID.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Inledande_ID.ForeColor = Color.Black;
            label_Inledande_ID.Location = new Point(250, 75);
            label_Inledande_ID.Margin = new Padding(1, 0, 0, 1);
            label_Inledande_ID.Name = "label_Inledande_ID";
            label_Inledande_ID.Size = new Size(70, 54);
            label_Inledande_ID.TabIndex = 1026;
            label_Inledande_ID.Text = "ID skärmat mm";
            label_Inledande_ID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_OD
            // 
            label_Inledande_OD.BackColor = Color.White;
            label_Inledande_OD.Dock = DockStyle.Fill;
            label_Inledande_OD.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Inledande_OD.ForeColor = Color.Black;
            label_Inledande_OD.Location = new Point(321, 75);
            label_Inledande_OD.Margin = new Padding(1, 0, 0, 1);
            label_Inledande_OD.Name = "label_Inledande_OD";
            label_Inledande_OD.Size = new Size(70, 54);
            label_Inledande_OD.TabIndex = 1026;
            label_Inledande_OD.Text = "OD skärmat mm";
            label_Inledande_OD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_Längd
            // 
            label_Inledande_Längd.BackColor = Color.White;
            label_Inledande_Längd.Dock = DockStyle.Fill;
            label_Inledande_Längd.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Inledande_Längd.ForeColor = Color.Black;
            label_Inledande_Längd.Location = new Point(392, 75);
            label_Inledande_Längd.Margin = new Padding(1, 0, 1, 1);
            label_Inledande_Längd.Name = "label_Inledande_Längd";
            label_Inledande_Längd.Size = new Size(88, 54);
            label_Inledande_Längd.TabIndex = 1026;
            label_Inledande_Längd.Text = "Längd skärmat   mm";
            label_Inledande_Längd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_VisuellTest
            // 
            label_Inspektion_VisuellTest.BackColor = Color.White;
            tlp_Produktion_Svetsning.SetColumnSpan(label_Inspektion_VisuellTest, 2);
            label_Inspektion_VisuellTest.Dock = DockStyle.Fill;
            label_Inspektion_VisuellTest.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            label_Inspektion_VisuellTest.ForeColor = Color.Black;
            label_Inspektion_VisuellTest.Location = new Point(482, 48);
            label_Inspektion_VisuellTest.Margin = new Padding(1, 0, 0, 1);
            label_Inspektion_VisuellTest.Name = "label_Inspektion_VisuellTest";
            label_Inspektion_VisuellTest.Size = new Size(137, 26);
            label_Inspektion_VisuellTest.TabIndex = 1024;
            label_Inspektion_VisuellTest.Text = "Visuell test";
            label_Inspektion_VisuellTest.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Utsida
            // 
            label_Inspektion_Utsida.BackColor = Color.White;
            label_Inspektion_Utsida.Dock = DockStyle.Fill;
            label_Inspektion_Utsida.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Inspektion_Utsida.ForeColor = Color.Black;
            label_Inspektion_Utsida.Location = new Point(482, 75);
            label_Inspektion_Utsida.Margin = new Padding(1, 0, 0, 1);
            label_Inspektion_Utsida.Name = "label_Inspektion_Utsida";
            label_Inspektion_Utsida.Size = new Size(68, 54);
            label_Inspektion_Utsida.TabIndex = 1026;
            label_Inspektion_Utsida.Text = "Utsida (Ja)";
            label_Inspektion_Utsida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Insida
            // 
            label_Inspektion_Insida.BackColor = Color.White;
            label_Inspektion_Insida.Dock = DockStyle.Fill;
            label_Inspektion_Insida.Font = new Font("Arial", 8.5F, FontStyle.Italic);
            label_Inspektion_Insida.ForeColor = Color.Black;
            label_Inspektion_Insida.Location = new Point(551, 75);
            label_Inspektion_Insida.Margin = new Padding(1, 0, 0, 1);
            label_Inspektion_Insida.Name = "label_Inspektion_Insida";
            label_Inspektion_Insida.Size = new Size(68, 54);
            label_Inspektion_Insida.TabIndex = 1026;
            label_Inspektion_Insida.Text = "Insida (Ja)";
            label_Inspektion_Insida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Datum
            // 
            label_Inspektion_Datum.BackColor = Color.White;
            label_Inspektion_Datum.Dock = DockStyle.Fill;
            label_Inspektion_Datum.Font = new Font("Arial", 8.5F);
            label_Inspektion_Datum.ForeColor = Color.Black;
            label_Inspektion_Datum.Location = new Point(620, 48);
            label_Inspektion_Datum.Margin = new Padding(1, 0, 0, 1);
            label_Inspektion_Datum.Name = "label_Inspektion_Datum";
            tlp_Produktion_Svetsning.SetRowSpan(label_Inspektion_Datum, 2);
            label_Inspektion_Datum.Size = new Size(101, 81);
            label_Inspektion_Datum.TabIndex = 1024;
            label_Inspektion_Datum.Text = "Datum";
            label_Inspektion_Datum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Tid
            // 
            label_Inspektion_Tid.BackColor = Color.White;
            label_Inspektion_Tid.Dock = DockStyle.Fill;
            label_Inspektion_Tid.Font = new Font("Arial", 8.5F);
            label_Inspektion_Tid.ForeColor = Color.Black;
            label_Inspektion_Tid.Location = new Point(722, 48);
            label_Inspektion_Tid.Margin = new Padding(1, 0, 0, 1);
            label_Inspektion_Tid.Name = "label_Inspektion_Tid";
            tlp_Produktion_Svetsning.SetRowSpan(label_Inspektion_Tid, 2);
            label_Inspektion_Tid.Size = new Size(63, 81);
            label_Inspektion_Tid.TabIndex = 1024;
            label_Inspektion_Tid.Text = "Tid";
            label_Inspektion_Tid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_AnstNr
            // 
            label_Inspektion_AnstNr.BackColor = Color.White;
            label_Inspektion_AnstNr.Dock = DockStyle.Fill;
            label_Inspektion_AnstNr.Font = new Font("Arial", 8.5F);
            label_Inspektion_AnstNr.ForeColor = Color.Black;
            label_Inspektion_AnstNr.Location = new Point(786, 48);
            label_Inspektion_AnstNr.Margin = new Padding(1, 0, 0, 1);
            label_Inspektion_AnstNr.Name = "label_Inspektion_AnstNr";
            tlp_Produktion_Svetsning.SetRowSpan(label_Inspektion_AnstNr, 2);
            label_Inspektion_AnstNr.Size = new Size(64, 81);
            label_Inspektion_AnstNr.TabIndex = 1024;
            label_Inspektion_AnstNr.Text = "Anst Nr";
            label_Inspektion_AnstNr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Sign
            // 
            label_Inspektion_Sign.BackColor = Color.White;
            label_Inspektion_Sign.Dock = DockStyle.Fill;
            label_Inspektion_Sign.Font = new Font("Arial", 8.5F);
            label_Inspektion_Sign.ForeColor = Color.Black;
            label_Inspektion_Sign.Location = new Point(851, 48);
            label_Inspektion_Sign.Margin = new Padding(1, 0, 1, 1);
            label_Inspektion_Sign.Name = "label_Inspektion_Sign";
            tlp_Produktion_Svetsning.SetRowSpan(label_Inspektion_Sign, 2);
            label_Inspektion_Sign.Size = new Size(122, 81);
            label_Inspektion_Sign.TabIndex = 1024;
            label_Inspektion_Sign.Text = "Sign";
            label_Inspektion_Sign.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Transfer_Produktion
            // 
            lbl_Transfer_Produktion.BackColor = Color.FromArgb(198, 239, 206);
            lbl_Transfer_Produktion.Cursor = Cursors.Hand;
            lbl_Transfer_Produktion.Dock = DockStyle.Fill;
            lbl_Transfer_Produktion.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Transfer_Produktion.ForeColor = Color.FromArgb(0, 97, 0);
            lbl_Transfer_Produktion.Location = new Point(1, 131);
            lbl_Transfer_Produktion.Margin = new Padding(1, 1, 0, 0);
            lbl_Transfer_Produktion.Name = "lbl_Transfer_Produktion";
            lbl_Transfer_Produktion.Size = new Size(33, 23);
            lbl_Transfer_Produktion.TabIndex = 28;
            lbl_Transfer_Produktion.Text = "→";
            lbl_Transfer_Produktion.TextAlign = ContentAlignment.TopCenter;
            lbl_Transfer_Produktion.Click += Save_Production_Parameters_Click;
            // 
            // dgv_Produktion
            // 
            dgv_Produktion.AllowUserToAddRows = false;
            dgv_Produktion.AllowUserToDeleteRows = false;
            dgv_Produktion.AllowUserToResizeColumns = false;
            dgv_Produktion.AllowUserToResizeRows = false;
            dataGridViewCellStyle12.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle12.SelectionForeColor = Color.White;
            dgv_Produktion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            dgv_Produktion.BackgroundColor = Color.White;
            dgv_Produktion.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = SystemColors.Control;
            dataGridViewCellStyle13.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dgv_Produktion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dgv_Produktion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Produktion.ColumnHeadersVisible = false;
            dgv_Produktion.Columns.AddRange(new DataGridViewColumn[] { OrderNr, Påse_Nr, Uppmätt_Pinn, ID, OD, Längd, Utsida, Insida, Datum, Tid, AnstNr, Sign, dgv_Produktion_TempID });
            tlp_Produktion_Svetsning.SetColumnSpan(dgv_Produktion, 12);
            dataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = SystemColors.Window;
            dataGridViewCellStyle26.Font = new Font("Courier New", 8F);
            dataGridViewCellStyle26.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle26.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle26.SelectionForeColor = Color.White;
            dataGridViewCellStyle26.WrapMode = DataGridViewTriState.False;
            dgv_Produktion.DefaultCellStyle = dataGridViewCellStyle26;
            dgv_Produktion.Dock = DockStyle.Fill;
            dgv_Produktion.Location = new Point(35, 155);
            dgv_Produktion.Margin = new Padding(1, 1, 1, 0);
            dgv_Produktion.Name = "dgv_Produktion";
            dgv_Produktion.ReadOnly = true;
            dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = SystemColors.Control;
            dataGridViewCellStyle27.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle27.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = DataGridViewTriState.True;
            dgv_Produktion.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            dgv_Produktion.RowHeadersVisible = false;
            tlp_Produktion_Svetsning.SetRowSpan(dgv_Produktion, 2);
            dgv_Produktion.RowTemplate.Height = 18;
            dgv_Produktion.ScrollBars = ScrollBars.Vertical;
            dgv_Produktion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Produktion.Size = new Size(938, 129);
            dgv_Produktion.TabIndex = 845;
            // 
            // OrderNr
            // 
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle14.ForeColor = Color.DodgerBlue;
            OrderNr.DefaultCellStyle = dataGridViewCellStyle14;
            OrderNr.HeaderText = "OrderNr";
            OrderNr.Name = "OrderNr";
            OrderNr.ReadOnly = true;
            OrderNr.Resizable = DataGridViewTriState.False;
            OrderNr.Width = 96;
            // 
            // Påse_Nr
            // 
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle15.ForeColor = Color.Gray;
            Påse_Nr.DefaultCellStyle = dataGridViewCellStyle15;
            Påse_Nr.HeaderText = "Påse Nr";
            Påse_Nr.Name = "Påse_Nr";
            Påse_Nr.ReadOnly = true;
            Påse_Nr.Resizable = DataGridViewTriState.False;
            Påse_Nr.Width = 48;
            // 
            // Uppmätt_Pinn
            // 
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle16.ForeColor = Color.Gray;
            Uppmätt_Pinn.DefaultCellStyle = dataGridViewCellStyle16;
            Uppmätt_Pinn.HeaderText = "Uppmätt Pinne";
            Uppmätt_Pinn.Name = "Uppmätt_Pinn";
            Uppmätt_Pinn.ReadOnly = true;
            Uppmätt_Pinn.Resizable = DataGridViewTriState.False;
            Uppmätt_Pinn.Width = 70;
            // 
            // ID
            // 
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle17.ForeColor = Color.Gray;
            ID.DefaultCellStyle = dataGridViewCellStyle17;
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Resizable = DataGridViewTriState.False;
            ID.Width = 71;
            // 
            // OD
            // 
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle18.ForeColor = Color.Gray;
            OD.DefaultCellStyle = dataGridViewCellStyle18;
            OD.HeaderText = "OD";
            OD.Name = "OD";
            OD.ReadOnly = true;
            OD.Resizable = DataGridViewTriState.False;
            OD.Width = 71;
            // 
            // Längd
            // 
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle19.ForeColor = Color.Gray;
            Längd.DefaultCellStyle = dataGridViewCellStyle19;
            Längd.HeaderText = "Längd";
            Längd.Name = "Längd";
            Längd.ReadOnly = true;
            Längd.Resizable = DataGridViewTriState.False;
            Längd.Width = 89;
            // 
            // Utsida
            // 
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle20.ForeColor = Color.Gray;
            dataGridViewCellStyle20.NullValue = false;
            Utsida.DefaultCellStyle = dataGridViewCellStyle20;
            Utsida.HeaderText = "Utsida";
            Utsida.Name = "Utsida";
            Utsida.ReadOnly = true;
            Utsida.Resizable = DataGridViewTriState.False;
            Utsida.SortMode = DataGridViewColumnSortMode.Automatic;
            Utsida.Width = 70;
            // 
            // Insida
            // 
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle21.ForeColor = Color.Gray;
            dataGridViewCellStyle21.NullValue = false;
            Insida.DefaultCellStyle = dataGridViewCellStyle21;
            Insida.HeaderText = "Insida";
            Insida.Name = "Insida";
            Insida.ReadOnly = true;
            Insida.Resizable = DataGridViewTriState.False;
            Insida.SortMode = DataGridViewColumnSortMode.Automatic;
            Insida.Width = 69;
            // 
            // Datum
            // 
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle22.ForeColor = Color.Gray;
            Datum.DefaultCellStyle = dataGridViewCellStyle22;
            Datum.HeaderText = "Datum";
            Datum.Name = "Datum";
            Datum.ReadOnly = true;
            Datum.Resizable = DataGridViewTriState.False;
            Datum.Width = 102;
            // 
            // Tid
            // 
            Tid.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle23.ForeColor = Color.Gray;
            Tid.DefaultCellStyle = dataGridViewCellStyle23;
            Tid.HeaderText = "Tid";
            Tid.Name = "Tid";
            Tid.ReadOnly = true;
            Tid.Resizable = DataGridViewTriState.False;
            Tid.Width = 64;
            // 
            // AnstNr
            // 
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle24.ForeColor = Color.Gray;
            AnstNr.DefaultCellStyle = dataGridViewCellStyle24;
            AnstNr.HeaderText = "AnstNr";
            AnstNr.Name = "AnstNr";
            AnstNr.ReadOnly = true;
            AnstNr.Resizable = DataGridViewTriState.False;
            AnstNr.Width = 65;
            // 
            // Sign
            // 
            Sign.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle25.ForeColor = Color.Gray;
            Sign.DefaultCellStyle = dataGridViewCellStyle25;
            Sign.HeaderText = "Sign";
            Sign.Name = "Sign";
            Sign.ReadOnly = true;
            Sign.Resizable = DataGridViewTriState.False;
            // 
            // dgv_Produktion_TempID
            // 
            dgv_Produktion_TempID.HeaderText = "TempID";
            dgv_Produktion_TempID.Name = "dgv_Produktion_TempID";
            dgv_Produktion_TempID.ReadOnly = true;
            dgv_Produktion_TempID.Visible = false;
            // 
            // label_Empty_5
            // 
            label_Empty_5.BackColor = Color.DarkGray;
            label_Empty_5.Dock = DockStyle.Fill;
            label_Empty_5.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_5.ForeColor = Color.ForestGreen;
            label_Empty_5.Location = new Point(1, 25);
            label_Empty_5.Margin = new Padding(1, 0, 0, 1);
            label_Empty_5.Name = "label_Empty_5";
            tlp_Produktion_Svetsning.SetRowSpan(label_Empty_5, 3);
            label_Empty_5.Size = new Size(33, 104);
            label_Empty_5.TabIndex = 1007;
            label_Empty_5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_InledandeUppmättPinne
            // 
            tb_InledandeUppmättPinne.BackColor = Color.White;
            tb_InledandeUppmättPinne.BorderStyle = BorderStyle.None;
            tb_InledandeUppmättPinne.Cursor = Cursors.IBeam;
            tb_InledandeUppmättPinne.Dock = DockStyle.Fill;
            tb_InledandeUppmättPinne.Font = new Font("Courier New", 8.25F);
            tb_InledandeUppmättPinne.ForeColor = Color.DarkSlateGray;
            tb_InledandeUppmättPinne.Location = new Point(180, 131);
            tb_InledandeUppmättPinne.Margin = new Padding(1, 1, 0, 0);
            tb_InledandeUppmättPinne.Multiline = true;
            tb_InledandeUppmättPinne.Name = "tb_InledandeUppmättPinne";
            tb_InledandeUppmättPinne.Size = new Size(69, 23);
            tb_InledandeUppmättPinne.TabIndex = 22;
            tb_InledandeUppmättPinne.TextAlign = HorizontalAlignment.Center;
            tb_InledandeUppmättPinne.WordWrap = false;
            tb_InledandeUppmättPinne.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_InledandeID
            // 
            tb_InledandeID.BackColor = Color.White;
            tb_InledandeID.BorderStyle = BorderStyle.None;
            tb_InledandeID.Cursor = Cursors.IBeam;
            tb_InledandeID.Dock = DockStyle.Fill;
            tb_InledandeID.Font = new Font("Courier New", 8.25F);
            tb_InledandeID.ForeColor = Color.DarkSlateGray;
            tb_InledandeID.Location = new Point(250, 131);
            tb_InledandeID.Margin = new Padding(1, 1, 0, 0);
            tb_InledandeID.Multiline = true;
            tb_InledandeID.Name = "tb_InledandeID";
            tb_InledandeID.Size = new Size(70, 23);
            tb_InledandeID.TabIndex = 23;
            tb_InledandeID.TextAlign = HorizontalAlignment.Center;
            tb_InledandeID.WordWrap = false;
            tb_InledandeID.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_InledandeOD
            // 
            tb_InledandeOD.BackColor = Color.White;
            tb_InledandeOD.BorderStyle = BorderStyle.None;
            tb_InledandeOD.Cursor = Cursors.IBeam;
            tb_InledandeOD.Dock = DockStyle.Fill;
            tb_InledandeOD.Font = new Font("Courier New", 8.25F);
            tb_InledandeOD.ForeColor = Color.DarkSlateGray;
            tb_InledandeOD.Location = new Point(321, 131);
            tb_InledandeOD.Margin = new Padding(1, 1, 0, 0);
            tb_InledandeOD.Multiline = true;
            tb_InledandeOD.Name = "tb_InledandeOD";
            tb_InledandeOD.Size = new Size(70, 23);
            tb_InledandeOD.TabIndex = 24;
            tb_InledandeOD.TextAlign = HorizontalAlignment.Center;
            tb_InledandeOD.WordWrap = false;
            tb_InledandeOD.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_InledandeLängd
            // 
            tb_InledandeLängd.BackColor = Color.White;
            tb_InledandeLängd.BorderStyle = BorderStyle.None;
            tb_InledandeLängd.Cursor = Cursors.IBeam;
            tb_InledandeLängd.Dock = DockStyle.Fill;
            tb_InledandeLängd.Font = new Font("Courier New", 8.25F);
            tb_InledandeLängd.ForeColor = Color.DarkSlateGray;
            tb_InledandeLängd.Location = new Point(392, 131);
            tb_InledandeLängd.Margin = new Padding(1, 1, 1, 0);
            tb_InledandeLängd.Multiline = true;
            tb_InledandeLängd.Name = "tb_InledandeLängd";
            tb_InledandeLängd.Size = new Size(88, 23);
            tb_InledandeLängd.TabIndex = 25;
            tb_InledandeLängd.TextAlign = HorizontalAlignment.Center;
            tb_InledandeLängd.WordWrap = false;
            tb_InledandeLängd.KeyDown += EnterToTab_KeyDown;
            // 
            // label_Empty_6
            // 
            label_Empty_6.BackColor = Color.DarkGray;
            tlp_Produktion_Svetsning.SetColumnSpan(label_Empty_6, 4);
            label_Empty_6.Dock = DockStyle.Fill;
            label_Empty_6.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Empty_6.ForeColor = Color.ForestGreen;
            label_Empty_6.Location = new Point(620, 131);
            label_Empty_6.Margin = new Padding(1, 1, 1, 0);
            label_Empty_6.Name = "label_Empty_6";
            label_Empty_6.Size = new Size(353, 23);
            label_Empty_6.TabIndex = 1007;
            label_Empty_6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chb_InspektionUtsida
            // 
            chb_InspektionUtsida.AutoSize = true;
            chb_InspektionUtsida.BackColor = Color.White;
            chb_InspektionUtsida.CheckAlign = ContentAlignment.MiddleCenter;
            chb_InspektionUtsida.Cursor = Cursors.Hand;
            chb_InspektionUtsida.Dock = DockStyle.Fill;
            chb_InspektionUtsida.Font = new Font("Courier New", 8.25F);
            chb_InspektionUtsida.ForeColor = Color.DarkSlateGray;
            chb_InspektionUtsida.Location = new Point(482, 131);
            chb_InspektionUtsida.Margin = new Padding(1, 1, 0, 0);
            chb_InspektionUtsida.Name = "chb_InspektionUtsida";
            chb_InspektionUtsida.RightToLeft = RightToLeft.No;
            chb_InspektionUtsida.Size = new Size(68, 23);
            chb_InspektionUtsida.TabIndex = 26;
            chb_InspektionUtsida.TextAlign = ContentAlignment.MiddleCenter;
            chb_InspektionUtsida.UseVisualStyleBackColor = false;
            // 
            // chb_InspektionInsida
            // 
            chb_InspektionInsida.AutoSize = true;
            chb_InspektionInsida.BackColor = Color.White;
            chb_InspektionInsida.CheckAlign = ContentAlignment.MiddleCenter;
            chb_InspektionInsida.Cursor = Cursors.Hand;
            chb_InspektionInsida.Dock = DockStyle.Fill;
            chb_InspektionInsida.Font = new Font("Courier New", 8.25F);
            chb_InspektionInsida.ForeColor = Color.DarkSlateGray;
            chb_InspektionInsida.Location = new Point(551, 131);
            chb_InspektionInsida.Margin = new Padding(1, 1, 0, 0);
            chb_InspektionInsida.Name = "chb_InspektionInsida";
            chb_InspektionInsida.RightToLeft = RightToLeft.No;
            chb_InspektionInsida.Size = new Size(68, 23);
            chb_InspektionInsida.TabIndex = 27;
            chb_InspektionInsida.TextAlign = ContentAlignment.MiddleCenter;
            chb_InspektionInsida.UseVisualStyleBackColor = false;
            // 
            // lbl_Discard_Row_Produktion
            // 
            lbl_Discard_Row_Produktion.BackColor = Color.FromArgb(255, 199, 206);
            lbl_Discard_Row_Produktion.Cursor = Cursors.Hand;
            lbl_Discard_Row_Produktion.Dock = DockStyle.Fill;
            lbl_Discard_Row_Produktion.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Discard_Row_Produktion.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_Discard_Row_Produktion.Location = new Point(1, 155);
            lbl_Discard_Row_Produktion.Margin = new Padding(1, 1, 0, 0);
            lbl_Discard_Row_Produktion.Name = "lbl_Discard_Row_Produktion";
            lbl_Discard_Row_Produktion.Size = new Size(33, 26);
            lbl_Discard_Row_Produktion.TabIndex = 28;
            lbl_Discard_Row_Produktion.Text = "→";
            lbl_Discard_Row_Produktion.TextAlign = ContentAlignment.TopCenter;
            lbl_Discard_Row_Produktion.Click += Delete_Row_Production_Parameters_Click;
            // 
            // tlp_Maskinparametrar
            // 
            tlp_Maskinparametrar.ColumnCount = 15;
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 43F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 74F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 74F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 78F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 51F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 49F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 49F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            tlp_Maskinparametrar.Controls.Add(tb_VärmebackarHål, 10, 1);
            tlp_Maskinparametrar.Controls.Add(dgv_MaskinParametrar, 1, 2);
            tlp_Maskinparametrar.Controls.Add(tb_VärmebackarBredd, 9, 1);
            tlp_Maskinparametrar.Controls.Add(lbl_Transfer_Maskinparametrar, 0, 1);
            tlp_Maskinparametrar.Controls.Add(tb_PinneODPTFE, 8, 1);
            tlp_Maskinparametrar.Controls.Add(lbl_Kassera_Maskinparameter, 0, 2);
            tlp_Maskinparametrar.Controls.Add(tb_PinneODStål, 7, 1);
            tlp_Maskinparametrar.Controls.Add(tb_Svets, 1, 1);
            tlp_Maskinparametrar.Controls.Add(tb_Temperatur, 6, 1);
            tlp_Maskinparametrar.Controls.Add(tb_TidFörvärme, 2, 1);
            tlp_Maskinparametrar.Controls.Add(tb_TidKylluft, 5, 1);
            tlp_Maskinparametrar.Controls.Add(tb_TidBindvärme, 4, 1);
            tlp_Maskinparametrar.Controls.Add(tb_Svetsförflyttning, 3, 1);
            tlp_Maskinparametrar.Controls.Add(PC_Svetsning_TEF, 0, 0);
            tlp_Maskinparametrar.Dock = DockStyle.Fill;
            tlp_Maskinparametrar.Location = new Point(0, 53);
            tlp_Maskinparametrar.Margin = new Padding(0, 0, 1, 0);
            tlp_Maskinparametrar.Name = "tlp_Maskinparametrar";
            tlp_Maskinparametrar.RowCount = 4;
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 157F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle());
            tlp_Maskinparametrar.Size = new Size(972, 276);
            tlp_Maskinparametrar.TabIndex = 1024;
            // 
            // tb_VärmebackarHål
            // 
            tb_VärmebackarHål.BackColor = Color.White;
            tb_VärmebackarHål.BorderStyle = BorderStyle.None;
            tb_VärmebackarHål.Cursor = Cursors.IBeam;
            tb_VärmebackarHål.Font = new Font("Courier New", 8.25F);
            tb_VärmebackarHål.ForeColor = Color.DarkSlateGray;
            tb_VärmebackarHål.Location = new Point(629, 158);
            tb_VärmebackarHål.Margin = new Padding(1, 1, 1, 0);
            tb_VärmebackarHål.MaxLength = 5;
            tb_VärmebackarHål.Multiline = true;
            tb_VärmebackarHål.Name = "tb_VärmebackarHål";
            tb_VärmebackarHål.Size = new Size(48, 22);
            tb_VärmebackarHål.TabIndex = 10;
            tb_VärmebackarHål.TextAlign = HorizontalAlignment.Center;
            tb_VärmebackarHål.WordWrap = false;
            tb_VärmebackarHål.KeyDown += EnterToTab_KeyDown;
            // 
            // dgv_MaskinParametrar
            // 
            dgv_MaskinParametrar.AllowUserToAddRows = false;
            dgv_MaskinParametrar.AllowUserToDeleteRows = false;
            dgv_MaskinParametrar.AllowUserToResizeColumns = false;
            dgv_MaskinParametrar.AllowUserToResizeRows = false;
            dataGridViewCellStyle28.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle28.SelectionForeColor = Color.White;
            dgv_MaskinParametrar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle28;
            dgv_MaskinParametrar.BackgroundColor = Color.White;
            dgv_MaskinParametrar.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = SystemColors.Control;
            dataGridViewCellStyle29.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle29.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = DataGridViewTriState.True;
            dgv_MaskinParametrar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            dgv_MaskinParametrar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_MaskinParametrar.ColumnHeadersVisible = false;
            dgv_MaskinParametrar.Columns.AddRange(new DataGridViewColumn[] { dgv_Maskinparametrar_Svets, dgv_Maskinparametrar_Tid_Förvärme, dgv_Maskinparametrar_Svetsförflyttning, dgv_Maskinparametrar_Tid_Bindvärme, dgv_Maskinparametrar_Tid_Kylluft, dgv_Maskinparametrar_Temperatur, dgv_Maskinparametrar_Stål, dgv_Maskinparametrar_Pinne_PTFE, dgv_Maskinparametrar_Värmebackar_Bredd, dgv_Maskinparametrar_Värmebackar_Hål, dgv_Maskinparametrar_Datum, dgv_Maskinparametrar_Tid, dgv_Maskinparametrar_AnstNr, dgv_Maskinparametrar_Sign });
            tlp_Maskinparametrar.SetColumnSpan(dgv_MaskinParametrar, 14);
            dataGridViewCellStyle44.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle44.BackColor = SystemColors.Window;
            dataGridViewCellStyle44.Font = new Font("Courier New", 8F);
            dataGridViewCellStyle44.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle44.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle44.SelectionForeColor = Color.White;
            dataGridViewCellStyle44.WrapMode = DataGridViewTriState.False;
            dgv_MaskinParametrar.DefaultCellStyle = dataGridViewCellStyle44;
            dgv_MaskinParametrar.Dock = DockStyle.Fill;
            dgv_MaskinParametrar.Location = new Point(44, 181);
            dgv_MaskinParametrar.Margin = new Padding(1, 1, 0, 0);
            dgv_MaskinParametrar.MultiSelect = false;
            dgv_MaskinParametrar.Name = "dgv_MaskinParametrar";
            dgv_MaskinParametrar.ReadOnly = true;
            dataGridViewCellStyle45.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle45.BackColor = SystemColors.Control;
            dataGridViewCellStyle45.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle45.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle45.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle45.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle45.WrapMode = DataGridViewTriState.True;
            dgv_MaskinParametrar.RowHeadersDefaultCellStyle = dataGridViewCellStyle45;
            dgv_MaskinParametrar.RowHeadersVisible = false;
            tlp_Maskinparametrar.SetRowSpan(dgv_MaskinParametrar, 2);
            dgv_MaskinParametrar.RowTemplate.Height = 18;
            dgv_MaskinParametrar.ScrollBars = ScrollBars.None;
            dgv_MaskinParametrar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_MaskinParametrar.Size = new Size(928, 95);
            dgv_MaskinParametrar.TabIndex = 1008;
            // 
            // dgv_Maskinparametrar_Svets
            // 
            dataGridViewCellStyle30.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle30.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Svets.DefaultCellStyle = dataGridViewCellStyle30;
            dgv_Maskinparametrar_Svets.HeaderText = "Svets";
            dgv_Maskinparametrar_Svets.Name = "dgv_Maskinparametrar_Svets";
            dgv_Maskinparametrar_Svets.ReadOnly = true;
            dgv_Maskinparametrar_Svets.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Svets.Width = 73;
            // 
            // dgv_Maskinparametrar_Tid_Förvärme
            // 
            dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle31.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Tid_Förvärme.DefaultCellStyle = dataGridViewCellStyle31;
            dgv_Maskinparametrar_Tid_Förvärme.HeaderText = "Tid Förvärme";
            dgv_Maskinparametrar_Tid_Förvärme.Name = "dgv_Maskinparametrar_Tid_Förvärme";
            dgv_Maskinparametrar_Tid_Förvärme.ReadOnly = true;
            dgv_Maskinparametrar_Tid_Förvärme.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Tid_Förvärme.Width = 70;
            // 
            // dgv_Maskinparametrar_Svetsförflyttning
            // 
            dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle32.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Svetsförflyttning.DefaultCellStyle = dataGridViewCellStyle32;
            dgv_Maskinparametrar_Svetsförflyttning.HeaderText = "Svets Förflyttning";
            dgv_Maskinparametrar_Svetsförflyttning.Name = "dgv_Maskinparametrar_Svetsförflyttning";
            dgv_Maskinparametrar_Svetsförflyttning.ReadOnly = true;
            dgv_Maskinparametrar_Svetsförflyttning.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Svetsförflyttning.Width = 74;
            // 
            // dgv_Maskinparametrar_Tid_Bindvärme
            // 
            dataGridViewCellStyle33.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle33.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Tid_Bindvärme.DefaultCellStyle = dataGridViewCellStyle33;
            dgv_Maskinparametrar_Tid_Bindvärme.HeaderText = "Tid Bindvärme";
            dgv_Maskinparametrar_Tid_Bindvärme.Name = "dgv_Maskinparametrar_Tid_Bindvärme";
            dgv_Maskinparametrar_Tid_Bindvärme.ReadOnly = true;
            dgv_Maskinparametrar_Tid_Bindvärme.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Tid_Bindvärme.Width = 78;
            // 
            // dgv_Maskinparametrar_Tid_Kylluft
            // 
            dataGridViewCellStyle34.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle34.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Tid_Kylluft.DefaultCellStyle = dataGridViewCellStyle34;
            dgv_Maskinparametrar_Tid_Kylluft.HeaderText = "Tid Kylluft";
            dgv_Maskinparametrar_Tid_Kylluft.Name = "dgv_Maskinparametrar_Tid_Kylluft";
            dgv_Maskinparametrar_Tid_Kylluft.ReadOnly = true;
            dgv_Maskinparametrar_Tid_Kylluft.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Tid_Kylluft.Width = 52;
            // 
            // dgv_Maskinparametrar_Temperatur
            // 
            dataGridViewCellStyle35.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle35.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle35.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Temperatur.DefaultCellStyle = dataGridViewCellStyle35;
            dgv_Maskinparametrar_Temperatur.HeaderText = "Temperatur";
            dgv_Maskinparametrar_Temperatur.Name = "dgv_Maskinparametrar_Temperatur";
            dgv_Maskinparametrar_Temperatur.ReadOnly = true;
            dgv_Maskinparametrar_Temperatur.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Temperatur.Width = 46;
            // 
            // dgv_Maskinparametrar_Stål
            // 
            dataGridViewCellStyle36.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle36.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Stål.DefaultCellStyle = dataGridViewCellStyle36;
            dgv_Maskinparametrar_Stål.HeaderText = "Pinne Stål";
            dgv_Maskinparametrar_Stål.Name = "dgv_Maskinparametrar_Stål";
            dgv_Maskinparametrar_Stål.ReadOnly = true;
            dgv_Maskinparametrar_Stål.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Stål.Width = 51;
            // 
            // dgv_Maskinparametrar_Pinne_PTFE
            // 
            dataGridViewCellStyle37.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle37.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Pinne_PTFE.DefaultCellStyle = dataGridViewCellStyle37;
            dgv_Maskinparametrar_Pinne_PTFE.HeaderText = "Pinne PTFE";
            dgv_Maskinparametrar_Pinne_PTFE.Name = "dgv_Maskinparametrar_Pinne_PTFE";
            dgv_Maskinparametrar_Pinne_PTFE.ReadOnly = true;
            dgv_Maskinparametrar_Pinne_PTFE.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Pinne_PTFE.Width = 91;
            // 
            // dgv_Maskinparametrar_Värmebackar_Bredd
            // 
            dataGridViewCellStyle38.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle38.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Värmebackar_Bredd.DefaultCellStyle = dataGridViewCellStyle38;
            dgv_Maskinparametrar_Värmebackar_Bredd.HeaderText = "Värmebackar Bredd";
            dgv_Maskinparametrar_Värmebackar_Bredd.Name = "dgv_Maskinparametrar_Värmebackar_Bredd";
            dgv_Maskinparametrar_Värmebackar_Bredd.ReadOnly = true;
            dgv_Maskinparametrar_Värmebackar_Bredd.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Värmebackar_Bredd.Width = 49;
            // 
            // dgv_Maskinparametrar_Värmebackar_Hål
            // 
            dataGridViewCellStyle39.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle39.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Värmebackar_Hål.DefaultCellStyle = dataGridViewCellStyle39;
            dgv_Maskinparametrar_Värmebackar_Hål.HeaderText = "Värmebackar Hål";
            dgv_Maskinparametrar_Värmebackar_Hål.Name = "dgv_Maskinparametrar_Värmebackar_Hål";
            dgv_Maskinparametrar_Värmebackar_Hål.ReadOnly = true;
            dgv_Maskinparametrar_Värmebackar_Hål.Width = 49;
            // 
            // dgv_Maskinparametrar_Datum
            // 
            dataGridViewCellStyle40.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle40.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Datum.DefaultCellStyle = dataGridViewCellStyle40;
            dgv_Maskinparametrar_Datum.HeaderText = "Datum";
            dgv_Maskinparametrar_Datum.Name = "dgv_Maskinparametrar_Datum";
            dgv_Maskinparametrar_Datum.ReadOnly = true;
            dgv_Maskinparametrar_Datum.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Datum.Width = 98;
            // 
            // dgv_Maskinparametrar_Tid
            // 
            dataGridViewCellStyle41.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle41.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle41.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Tid.DefaultCellStyle = dataGridViewCellStyle41;
            dgv_Maskinparametrar_Tid.HeaderText = "Tid";
            dgv_Maskinparametrar_Tid.Name = "dgv_Maskinparametrar_Tid";
            dgv_Maskinparametrar_Tid.ReadOnly = true;
            dgv_Maskinparametrar_Tid.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_Tid.Width = 56;
            // 
            // dgv_Maskinparametrar_AnstNr
            // 
            dataGridViewCellStyle42.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle42.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle42.ForeColor = Color.Gray;
            dgv_Maskinparametrar_AnstNr.DefaultCellStyle = dataGridViewCellStyle42;
            dgv_Maskinparametrar_AnstNr.HeaderText = "AnstNr";
            dgv_Maskinparametrar_AnstNr.Name = "dgv_Maskinparametrar_AnstNr";
            dgv_Maskinparametrar_AnstNr.ReadOnly = true;
            dgv_Maskinparametrar_AnstNr.Resizable = DataGridViewTriState.False;
            dgv_Maskinparametrar_AnstNr.Width = 49;
            // 
            // dgv_Maskinparametrar_Sign
            // 
            dgv_Maskinparametrar_Sign.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle43.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle43.Font = new Font("Courier New", 8.5F, FontStyle.Italic);
            dataGridViewCellStyle43.ForeColor = Color.Gray;
            dgv_Maskinparametrar_Sign.DefaultCellStyle = dataGridViewCellStyle43;
            dgv_Maskinparametrar_Sign.HeaderText = "Sign";
            dgv_Maskinparametrar_Sign.Name = "dgv_Maskinparametrar_Sign";
            dgv_Maskinparametrar_Sign.ReadOnly = true;
            dgv_Maskinparametrar_Sign.Resizable = DataGridViewTriState.False;
            // 
            // tb_VärmebackarBredd
            // 
            tb_VärmebackarBredd.BackColor = Color.White;
            tb_VärmebackarBredd.BorderStyle = BorderStyle.None;
            tb_VärmebackarBredd.Cursor = Cursors.IBeam;
            tb_VärmebackarBredd.Font = new Font("Courier New", 8.25F);
            tb_VärmebackarBredd.ForeColor = Color.DarkSlateGray;
            tb_VärmebackarBredd.Location = new Point(580, 158);
            tb_VärmebackarBredd.Margin = new Padding(1, 1, 0, 0);
            tb_VärmebackarBredd.MaxLength = 5;
            tb_VärmebackarBredd.Multiline = true;
            tb_VärmebackarBredd.Name = "tb_VärmebackarBredd";
            tb_VärmebackarBredd.Size = new Size(48, 22);
            tb_VärmebackarBredd.TabIndex = 9;
            tb_VärmebackarBredd.TextAlign = HorizontalAlignment.Center;
            tb_VärmebackarBredd.WordWrap = false;
            tb_VärmebackarBredd.KeyDown += EnterToTab_KeyDown;
            // 
            // lbl_Transfer_Maskinparametrar
            // 
            lbl_Transfer_Maskinparametrar.BackColor = Color.FromArgb(198, 239, 206);
            lbl_Transfer_Maskinparametrar.Cursor = Cursors.Hand;
            lbl_Transfer_Maskinparametrar.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Transfer_Maskinparametrar.ForeColor = Color.FromArgb(0, 97, 0);
            lbl_Transfer_Maskinparametrar.Location = new Point(0, 158);
            lbl_Transfer_Maskinparametrar.Margin = new Padding(0, 1, 0, 0);
            lbl_Transfer_Maskinparametrar.Name = "lbl_Transfer_Maskinparametrar";
            lbl_Transfer_Maskinparametrar.Size = new Size(43, 22);
            lbl_Transfer_Maskinparametrar.TabIndex = 1010;
            lbl_Transfer_Maskinparametrar.Text = "→";
            lbl_Transfer_Maskinparametrar.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Transfer_Maskinparametrar.Click += Save_Maskinparametrar_Click;
            // 
            // tb_PinneODPTFE
            // 
            tb_PinneODPTFE.BackColor = Color.White;
            tb_PinneODPTFE.BorderStyle = BorderStyle.None;
            tb_PinneODPTFE.Cursor = Cursors.IBeam;
            tb_PinneODPTFE.Font = new Font("Courier New", 8.25F);
            tb_PinneODPTFE.ForeColor = Color.DarkSlateGray;
            tb_PinneODPTFE.Location = new Point(489, 158);
            tb_PinneODPTFE.Margin = new Padding(1, 1, 0, 0);
            tb_PinneODPTFE.MaxLength = 12;
            tb_PinneODPTFE.Multiline = true;
            tb_PinneODPTFE.Name = "tb_PinneODPTFE";
            tb_PinneODPTFE.Size = new Size(90, 22);
            tb_PinneODPTFE.TabIndex = 8;
            tb_PinneODPTFE.TextAlign = HorizontalAlignment.Center;
            tb_PinneODPTFE.WordWrap = false;
            tb_PinneODPTFE.KeyDown += EnterToTab_KeyDown;
            // 
            // lbl_Kassera_Maskinparameter
            // 
            lbl_Kassera_Maskinparameter.BackColor = Color.FromArgb(255, 199, 206);
            lbl_Kassera_Maskinparameter.Cursor = Cursors.Hand;
            lbl_Kassera_Maskinparameter.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Kassera_Maskinparameter.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_Kassera_Maskinparameter.Location = new Point(0, 181);
            lbl_Kassera_Maskinparameter.Margin = new Padding(0, 1, 0, 0);
            lbl_Kassera_Maskinparameter.Name = "lbl_Kassera_Maskinparameter";
            lbl_Kassera_Maskinparameter.Size = new Size(43, 22);
            lbl_Kassera_Maskinparameter.TabIndex = 28;
            lbl_Kassera_Maskinparameter.Text = "→";
            lbl_Kassera_Maskinparameter.TextAlign = ContentAlignment.TopCenter;
            lbl_Kassera_Maskinparameter.Click += Delete_Row_Maskinparameter_Click;
            // 
            // tb_PinneODStål
            // 
            tb_PinneODStål.BackColor = Color.White;
            tb_PinneODStål.BorderStyle = BorderStyle.None;
            tb_PinneODStål.Cursor = Cursors.IBeam;
            tb_PinneODStål.Font = new Font("Courier New", 8.25F);
            tb_PinneODStål.ForeColor = Color.DarkSlateGray;
            tb_PinneODStål.Location = new Point(438, 158);
            tb_PinneODStål.Margin = new Padding(1, 1, 0, 0);
            tb_PinneODStål.MaxLength = 5;
            tb_PinneODStål.Multiline = true;
            tb_PinneODStål.Name = "tb_PinneODStål";
            tb_PinneODStål.Size = new Size(50, 22);
            tb_PinneODStål.TabIndex = 7;
            tb_PinneODStål.TextAlign = HorizontalAlignment.Center;
            tb_PinneODStål.WordWrap = false;
            tb_PinneODStål.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_Svets
            // 
            tb_Svets.BackColor = Color.White;
            tb_Svets.BorderStyle = BorderStyle.None;
            tb_Svets.Cursor = Cursors.IBeam;
            tb_Svets.Font = new Font("Courier New", 8.25F);
            tb_Svets.ForeColor = Color.DarkSlateGray;
            tb_Svets.Location = new Point(44, 158);
            tb_Svets.Margin = new Padding(1, 1, 0, 0);
            tb_Svets.MaxLength = 10;
            tb_Svets.Multiline = true;
            tb_Svets.Name = "tb_Svets";
            tb_Svets.Size = new Size(72, 22);
            tb_Svets.TabIndex = 1;
            tb_Svets.TextAlign = HorizontalAlignment.Center;
            tb_Svets.WordWrap = false;
            tb_Svets.KeyDown += EnterToTab_KeyDown;
            // 
            // tb_Temperatur
            // 
            tb_Temperatur.BackColor = Color.White;
            tb_Temperatur.BorderStyle = BorderStyle.None;
            tb_Temperatur.Cursor = Cursors.IBeam;
            tb_Temperatur.Font = new Font("Courier New", 8.25F);
            tb_Temperatur.ForeColor = Color.DarkSlateGray;
            tb_Temperatur.Location = new Point(392, 158);
            tb_Temperatur.Margin = new Padding(1, 1, 0, 0);
            tb_Temperatur.MaxLength = 4;
            tb_Temperatur.Multiline = true;
            tb_Temperatur.Name = "tb_Temperatur";
            tb_Temperatur.Size = new Size(44, 22);
            tb_Temperatur.TabIndex = 6;
            tb_Temperatur.TextAlign = HorizontalAlignment.Center;
            tb_Temperatur.WordWrap = false;
            tb_Temperatur.KeyDown += EnterToTab_KeyDown;
            tb_Temperatur.Leave += Check_MIN_NOM_MAX_Leave;
            // 
            // tb_TidFörvärme
            // 
            tb_TidFörvärme.BackColor = Color.White;
            tb_TidFörvärme.BorderStyle = BorderStyle.None;
            tb_TidFörvärme.Cursor = Cursors.IBeam;
            tb_TidFörvärme.Font = new Font("Courier New", 8.25F);
            tb_TidFörvärme.ForeColor = Color.DarkSlateGray;
            tb_TidFörvärme.Location = new Point(118, 158);
            tb_TidFörvärme.Margin = new Padding(1, 1, 0, 0);
            tb_TidFörvärme.MaxLength = 4;
            tb_TidFörvärme.Multiline = true;
            tb_TidFörvärme.Name = "tb_TidFörvärme";
            tb_TidFörvärme.Size = new Size(69, 22);
            tb_TidFörvärme.TabIndex = 2;
            tb_TidFörvärme.TextAlign = HorizontalAlignment.Center;
            tb_TidFörvärme.WordWrap = false;
            tb_TidFörvärme.KeyDown += EnterToTab_KeyDown;
            tb_TidFörvärme.Leave += Check_MIN_NOM_MAX_Leave;
            // 
            // tb_TidKylluft
            // 
            tb_TidKylluft.BackColor = Color.White;
            tb_TidKylluft.BorderStyle = BorderStyle.None;
            tb_TidKylluft.Cursor = Cursors.IBeam;
            tb_TidKylluft.Font = new Font("Courier New", 8.25F);
            tb_TidKylluft.ForeColor = Color.DarkSlateGray;
            tb_TidKylluft.Location = new Point(340, 158);
            tb_TidKylluft.Margin = new Padding(1, 1, 0, 0);
            tb_TidKylluft.MaxLength = 3;
            tb_TidKylluft.Multiline = true;
            tb_TidKylluft.Name = "tb_TidKylluft";
            tb_TidKylluft.Size = new Size(51, 22);
            tb_TidKylluft.TabIndex = 5;
            tb_TidKylluft.TextAlign = HorizontalAlignment.Center;
            tb_TidKylluft.WordWrap = false;
            tb_TidKylluft.KeyDown += EnterToTab_KeyDown;
            tb_TidKylluft.Leave += Check_MIN_NOM_MAX_Leave;
            // 
            // tb_TidBindvärme
            // 
            tb_TidBindvärme.BackColor = Color.White;
            tb_TidBindvärme.BorderStyle = BorderStyle.None;
            tb_TidBindvärme.Cursor = Cursors.IBeam;
            tb_TidBindvärme.Font = new Font("Courier New", 8.25F);
            tb_TidBindvärme.ForeColor = Color.DarkSlateGray;
            tb_TidBindvärme.Location = new Point(262, 158);
            tb_TidBindvärme.Margin = new Padding(1, 1, 0, 0);
            tb_TidBindvärme.MaxLength = 3;
            tb_TidBindvärme.Multiline = true;
            tb_TidBindvärme.Name = "tb_TidBindvärme";
            tb_TidBindvärme.Size = new Size(77, 22);
            tb_TidBindvärme.TabIndex = 4;
            tb_TidBindvärme.TextAlign = HorizontalAlignment.Center;
            tb_TidBindvärme.WordWrap = false;
            tb_TidBindvärme.KeyDown += EnterToTab_KeyDown;
            tb_TidBindvärme.Leave += Check_MIN_NOM_MAX_Leave;
            // 
            // tb_Svetsförflyttning
            // 
            tb_Svetsförflyttning.BackColor = Color.White;
            tb_Svetsförflyttning.BorderStyle = BorderStyle.None;
            tb_Svetsförflyttning.Cursor = Cursors.IBeam;
            tb_Svetsförflyttning.Font = new Font("Courier New", 8.25F);
            tb_Svetsförflyttning.ForeColor = Color.DarkSlateGray;
            tb_Svetsförflyttning.Location = new Point(188, 158);
            tb_Svetsförflyttning.Margin = new Padding(1, 1, 0, 0);
            tb_Svetsförflyttning.MaxLength = 4;
            tb_Svetsförflyttning.Multiline = true;
            tb_Svetsförflyttning.Name = "tb_Svetsförflyttning";
            tb_Svetsförflyttning.Size = new Size(72, 22);
            tb_Svetsförflyttning.TabIndex = 3;
            tb_Svetsförflyttning.TextAlign = HorizontalAlignment.Center;
            tb_Svetsförflyttning.WordWrap = false;
            tb_Svetsförflyttning.KeyDown += EnterToTab_KeyDown;
            tb_Svetsförflyttning.Leave += Check_MIN_NOM_MAX_Leave;
            // 
            // PC_Svetsning_TEF
            // 
            tlp_Maskinparametrar.SetColumnSpan(PC_Svetsning_TEF, 15);
            PC_Svetsning_TEF.Dock = DockStyle.Fill;
            PC_Svetsning_TEF.Location = new Point(0, 0);
            PC_Svetsning_TEF.Margin = new Padding(0);
            PC_Svetsning_TEF.Name = "PC_Svetsning_TEF";
            PC_Svetsning_TEF.Size = new Size(972, 157);
            PC_Svetsning_TEF.TabIndex = 1011;
            // 
            // MainInfo
            // 
            MainInfo.Dock = DockStyle.Fill;
            MainInfo.Location = new Point(0, 1);
            MainInfo.Margin = new Padding(0, 1, 0, 0);
            MainInfo.Name = "MainInfo";
            MainInfo.Size = new Size(973, 52);
            MainInfo.TabIndex = 1026;
            // 
            // MainProtocol_Svetsning_TEF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainProtocol_Svetsning_TEF";
            Size = new Size(973, 966);
            tlp_Main.ResumeLayout(false);
            tlp_Halvfabrikat.ResumeLayout(false);
            tlp_Halvfabrikat.PerformLayout();
            panel_Halvfabrikat_OrderNr.ResumeLayout(false);
            panel_Halvfabrikat_ArtikelNr.ResumeLayout(false);
            panel_Halvfabrikat_Typ.ResumeLayout(false);
            ((ISupportInitialize)dgv_Halvfabrikat).EndInit();
            tlp_Produktion_Svetsning.ResumeLayout(false);
            tlp_Produktion_Svetsning.PerformLayout();
            panel_Produktion_OrderNr.ResumeLayout(false);
            ((ISupportInitialize)dgv_Produktion).EndInit();
            tlp_Maskinparametrar.ResumeLayout(false);
            tlp_Maskinparametrar.PerformLayout();
            ((ISupportInitialize)dgv_MaskinParametrar).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private TableLayoutPanel tlp_Produktion_Svetsning;
        private Label label_Inledande;
        private Panel panel_Produktion_OrderNr;
        private Label label_Inledande_UppmättVidProduktionsStart;
        private Label label_Inledande_Påse_Nr;
        private Label label_Inledande_BatchNr;
        private Label label_Inledande_Uppmätt_Pinn;
        private Label label_Inledande_Skärmat;
        private Label label_Produktion_Svetsning;
        private TextBox tb_Inledande_Påse;
        private Label label_Inspektion;
        private Label label_Inledande_ID;
        private Label label_Inledande_OD;
        private Label label_Inledande_Längd;
        private Label label_Inspektion_VisuellTest;
        private Label label_Inspektion_Utsida;
        private Label label_Inspektion_Insida;
        private Label label_Inspektion_Datum;
        private Label label_Inspektion_Tid;
        private Label label_Inspektion_AnstNr;
        private Label label_Inspektion_Sign;
        private DataGridView dgv_Produktion;
        private Label label_Empty_5;
        private TextBox tb_InledandeUppmättPinne;
        private TextBox tb_InledandeID;
        private TextBox tb_InledandeOD;
        private TextBox tb_InledandeLängd;
        private Label label_Empty_6;
        private CheckBox chb_InspektionUtsida;
        private CheckBox chb_InspektionInsida;
        private TableLayoutPanel tlp_Maskinparametrar;
        private TextBox tb_VärmebackarHål;
        private DataGridView dgv_MaskinParametrar;
        private TextBox tb_VärmebackarBredd;
        private TextBox tb_PinneODPTFE;
        private TextBox tb_PinneODStål;
        private TextBox tb_Svets;
        private TextBox tb_Temperatur;
        private TextBox tb_TidFörvärme;
        private TextBox tb_TidKylluft;
        private TextBox tb_TidBindvärme;
        private TextBox tb_Svetsförflyttning;
        private TableLayoutPanel tlp_Halvfabrikat;
        private TextBox lbl_Halvfabrikat_ID;
        private Panel panel_Halvfabrikat_OrderNr;
        private ComboBox cb_Halvfabrikat_BatchNr;
        private Panel panel_Halvfabrikat_ArtikelNr;
        private ComboBox cb_Halvfabrikat_ArtikelNr;
        private Panel panel_Halvfabrikat_Typ;
        private ComboBox cb_Halvfabrikat_Typ;
        private Label label_Halvfabrikat_Längd;
        private Label label_Halvfabrikat_W;
        private Label label_Halvfabrikat_OD;
        private Label label_Halvfabrikat_BatchNr;
        private Label label_Halvfabrikat_ArtikelNr;
        private Label label_Halvfabrikat;
        private Label label_Halvfabrikat_ID;
        private Label label1;
        private TextBox lbl_Halvfabrikat_OD;
        private TextBox lbl_Halvfabrikat_W;
        private TextBox lbl_Halvfabrikat_L;
        private Label label_Empty_9;
        public PC_Svetsning_TEF PC_Svetsning_TEF;
        public DataGridView dgv_Halvfabrikat;
        public Label lbl_Transfer_Halvfabrikat;
        public Label lbl_Transfer_Produktion;
        public ComboBox cb_Inledande_BatchNr;
        public Label lbl_Edit_Row_Produktion;
        public Label lbl_Discard_Row_Produktion;
        public Label lbl_Transfer_Maskinparametrar;
        public Label lbl_Kassera_Maskinparameter;
        public Label lbl_Discard_Halvfabrikat;
        public MainInfo_Description_Prodtype MainInfo;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Svets;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Tid_Förvärme;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Svetsförflyttning;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Tid_Bindvärme;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Tid_Kylluft;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Temperatur;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Stål;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Pinne_PTFE;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Värmebackar_Bredd;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Värmebackar_Hål;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Datum;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Tid;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_AnstNr;
        private DataGridViewTextBoxColumn dgv_Maskinparametrar_Sign;
        private DataGridViewTextBoxColumn Halvfabrikat_Slang;
        private DataGridViewTextBoxColumn Halvfabrikat_ArtikelNr;
        private DataGridViewTextBoxColumn Halvfabrikat_OrderNr;
        private DataGridViewTextBoxColumn Halvfabrikat_ID;
        private DataGridViewTextBoxColumn Halvfabrikat_OD;
        private DataGridViewTextBoxColumn Halvfabrikat_W;
        private DataGridViewTextBoxColumn Halvfabrikat_Längd;
        private DataGridViewTextBoxColumn OrderNr;
        private DataGridViewTextBoxColumn Påse_Nr;
        private DataGridViewTextBoxColumn Uppmätt_Pinn;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn OD;
        private DataGridViewTextBoxColumn Längd;
        private DataGridViewCheckBoxColumn Utsida;
        private DataGridViewCheckBoxColumn Insida;
        private DataGridViewTextBoxColumn Datum;
        private DataGridViewTextBoxColumn Tid;
        private DataGridViewTextBoxColumn AnstNr;
        private DataGridViewTextBoxColumn Sign;
        private DataGridViewTextBoxColumn dgv_Produktion_TempID;
    }
}
