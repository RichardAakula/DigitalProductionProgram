using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Kragning_TEF
{
    partial class MainProtocol_Kragning_TEF
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
            tlp_Main = new TableLayoutPanel();
            panel_Halvfabrikat = new Panel();
            tlp_Halvfabrikat = new TableLayoutPanel();
            lbl_Halvfabrikat_ID = new TextBox();
            panel_Halvfabrikat_OrderNr = new Panel();
            cb_Halvfabrikat_OrderNr = new ComboBox();
            panel_Halvfabrikat_ArtikelNr = new Panel();
            cb_Halvfabrikat_ArtikelNr = new ComboBox();
            panel_Halvfabrikat_Typ = new Panel();
            cb_Halvfabrikat_Typ = new ComboBox();
            label_Halvfabrikat_Längd = new Label();
            label_Halvfabrikat_W = new Label();
            label_Halvfabrikat_OD = new Label();
            label_Halvfabrikat_OrderNr = new Label();
            label_Halvfabrikat_ArtikelNr = new Label();
            label_Halvfabrikat = new Label();
            label_Halvfabrikat_ID = new Label();
            label1 = new Label();
            dgv_Halvfabrikat = new DataGridView();
            lbl_Transfer_Halvfabrikat = new Label();
            lbl_Halvfabrikat_OD = new TextBox();
            lbl_Halvfabrikat_W = new TextBox();
            lbl_Halvfabrikat_L = new TextBox();
            label_Empty_9 = new Label();
            lbl_Delete_Halvfabrikat = new Label();
            panel_MaskinParametrar = new Panel();
            tlp_Maskinparametrar = new TableLayoutPanel();
            Processkort_Kragning = new PC_Kragning();
            KP_Kragning = new KP_Kragning();
            panel_ProduktInformation = new Panel();
            tlp_ProduktInformation = new TableLayoutPanel();
            lbl_Benämning = new Label();
            label_Benämning = new Label();
            label_Påse_Spole = new Label();
            ProdType = new TextBox();
            lbl_OrderNr = new Label();
            lbl_ArtikelNr = new Label();
            label_Kund = new Label();
            label_ProdType = new Label();
            label_ArtikelNr = new Label();
            label_Datum = new Label();
            label_OrderNr = new Label();
            lbl_Customer = new Label();
            lbl_LC_Date = new Label();
            label_Namn = new Label();
            Påse_Spole = new TextBox();
            Name_Start = new Label();
            Halvfabrikat_Slang = new DataGridViewTextBoxColumn();
            Halvfabrikat_ArtikelNr = new DataGridViewTextBoxColumn();
            Halvfabrikat_OrderNr = new DataGridViewTextBoxColumn();
            Halvfabrikat_ID = new DataGridViewTextBoxColumn();
            Halvfabrikat_OD = new DataGridViewTextBoxColumn();
            Halvfabrikat_W = new DataGridViewTextBoxColumn();
            Halvfabrikat_Längd = new DataGridViewTextBoxColumn();
            tlp_Main.SuspendLayout();
            panel_Halvfabrikat.SuspendLayout();
            tlp_Halvfabrikat.SuspendLayout();
            panel_Halvfabrikat_OrderNr.SuspendLayout();
            panel_Halvfabrikat_ArtikelNr.SuspendLayout();
            panel_Halvfabrikat_Typ.SuspendLayout();
            ((ISupportInitialize)dgv_Halvfabrikat).BeginInit();
            panel_MaskinParametrar.SuspendLayout();
            tlp_Maskinparametrar.SuspendLayout();
            panel_ProduktInformation.SuspendLayout();
            tlp_ProduktInformation.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.White;
            tlp_Main.ColumnCount = 3;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 598F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tlp_Main.Controls.Add(panel_Halvfabrikat, 0, 2);
            tlp_Main.Controls.Add(panel_MaskinParametrar, 0, 1);
            tlp_Main.Controls.Add(panel_ProduktInformation, 0, 0);
            tlp_Main.Cursor = Cursors.SizeAll;
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 3;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 97F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 366F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 179F));
            tlp_Main.Size = new Size(848, 864);
            tlp_Main.TabIndex = 1;
            // 
            // panel_Halvfabrikat
            // 
            panel_Halvfabrikat.BorderStyle = BorderStyle.FixedSingle;
            tlp_Main.SetColumnSpan(panel_Halvfabrikat, 3);
            panel_Halvfabrikat.Controls.Add(tlp_Halvfabrikat);
            panel_Halvfabrikat.Dock = DockStyle.Fill;
            panel_Halvfabrikat.Location = new Point(0, 463);
            panel_Halvfabrikat.Margin = new Padding(0);
            panel_Halvfabrikat.Name = "panel_Halvfabrikat";
            panel_Halvfabrikat.Size = new Size(848, 401);
            panel_Halvfabrikat.TabIndex = 907;
            // 
            // tlp_Halvfabrikat
            // 
            tlp_Halvfabrikat.BackColor = Color.FromArgb(45, 45, 45);
            tlp_Halvfabrikat.ColumnCount = 9;
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 33F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 127F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 124F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 191F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 64F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 89F));
            tlp_Halvfabrikat.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102F));
            tlp_Halvfabrikat.Controls.Add(lbl_Halvfabrikat_ID, 4, 2);
            tlp_Halvfabrikat.Controls.Add(panel_Halvfabrikat_OrderNr, 3, 2);
            tlp_Halvfabrikat.Controls.Add(panel_Halvfabrikat_ArtikelNr, 2, 2);
            tlp_Halvfabrikat.Controls.Add(panel_Halvfabrikat_Typ, 1, 2);
            tlp_Halvfabrikat.Controls.Add(label_Halvfabrikat_Längd, 7, 1);
            tlp_Halvfabrikat.Controls.Add(label_Halvfabrikat_W, 6, 1);
            tlp_Halvfabrikat.Controls.Add(label_Halvfabrikat_OD, 5, 1);
            tlp_Halvfabrikat.Controls.Add(label_Halvfabrikat_OrderNr, 3, 1);
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
            tlp_Halvfabrikat.Controls.Add(lbl_Delete_Halvfabrikat, 0, 3);
            tlp_Halvfabrikat.Dock = DockStyle.Fill;
            tlp_Halvfabrikat.Location = new Point(0, 0);
            tlp_Halvfabrikat.Margin = new Padding(0);
            tlp_Halvfabrikat.Name = "tlp_Halvfabrikat";
            tlp_Halvfabrikat.RowCount = 4;
            tlp_Halvfabrikat.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tlp_Halvfabrikat.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_Halvfabrikat.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_Halvfabrikat.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_Halvfabrikat.Size = new Size(846, 399);
            tlp_Halvfabrikat.TabIndex = 1;
            // 
            // lbl_Halvfabrikat_ID
            // 
            lbl_Halvfabrikat_ID.BackColor = Color.White;
            lbl_Halvfabrikat_ID.BorderStyle = BorderStyle.None;
            lbl_Halvfabrikat_ID.Dock = DockStyle.Fill;
            lbl_Halvfabrikat_ID.Font = new Font("Consolas", 8.25F, FontStyle.Italic);
            lbl_Halvfabrikat_ID.ForeColor = Color.Gray;
            lbl_Halvfabrikat_ID.Location = new Point(476, 43);
            lbl_Halvfabrikat_ID.Margin = new Padding(1, 0, 0, 0);
            lbl_Halvfabrikat_ID.MaxLength = 5;
            lbl_Halvfabrikat_ID.Multiline = true;
            lbl_Halvfabrikat_ID.Name = "lbl_Halvfabrikat_ID";
            lbl_Halvfabrikat_ID.Size = new Size(57, 22);
            lbl_Halvfabrikat_ID.TabIndex = 916;
            // 
            // panel_Halvfabrikat_OrderNr
            // 
            panel_Halvfabrikat_OrderNr.BackColor = Color.White;
            panel_Halvfabrikat_OrderNr.Controls.Add(cb_Halvfabrikat_OrderNr);
            panel_Halvfabrikat_OrderNr.ForeColor = Color.Black;
            panel_Halvfabrikat_OrderNr.Location = new Point(285, 43);
            panel_Halvfabrikat_OrderNr.Margin = new Padding(1, 0, 0, 0);
            panel_Halvfabrikat_OrderNr.Name = "panel_Halvfabrikat_OrderNr";
            panel_Halvfabrikat_OrderNr.Size = new Size(190, 22);
            panel_Halvfabrikat_OrderNr.TabIndex = 920;
            // 
            // cb_Halvfabrikat_OrderNr
            // 
            cb_Halvfabrikat_OrderNr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_Halvfabrikat_OrderNr.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_Halvfabrikat_OrderNr.Cursor = Cursors.Hand;
            cb_Halvfabrikat_OrderNr.Dock = DockStyle.Fill;
            cb_Halvfabrikat_OrderNr.DropDownHeight = 130;
            cb_Halvfabrikat_OrderNr.DropDownWidth = 130;
            cb_Halvfabrikat_OrderNr.FlatStyle = FlatStyle.Flat;
            cb_Halvfabrikat_OrderNr.Font = new Font("Courier New", 8.25F, FontStyle.Italic);
            cb_Halvfabrikat_OrderNr.ForeColor = Color.DarkSlateGray;
            cb_Halvfabrikat_OrderNr.FormattingEnabled = true;
            cb_Halvfabrikat_OrderNr.IntegralHeight = false;
            cb_Halvfabrikat_OrderNr.Location = new Point(0, 0);
            cb_Halvfabrikat_OrderNr.Margin = new Padding(0);
            cb_Halvfabrikat_OrderNr.Name = "cb_Halvfabrikat_OrderNr";
            cb_Halvfabrikat_OrderNr.Size = new Size(190, 23);
            cb_Halvfabrikat_OrderNr.TabIndex = 32;
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
            cb_Halvfabrikat_ArtikelNr.Font = new Font("Courier New", 8.25F, FontStyle.Italic);
            cb_Halvfabrikat_ArtikelNr.ForeColor = Color.DarkSlateGray;
            cb_Halvfabrikat_ArtikelNr.FormattingEnabled = true;
            cb_Halvfabrikat_ArtikelNr.IntegralHeight = false;
            cb_Halvfabrikat_ArtikelNr.Location = new Point(0, 0);
            cb_Halvfabrikat_ArtikelNr.Margin = new Padding(0);
            cb_Halvfabrikat_ArtikelNr.Name = "cb_Halvfabrikat_ArtikelNr";
            cb_Halvfabrikat_ArtikelNr.Size = new Size(123, 23);
            cb_Halvfabrikat_ArtikelNr.TabIndex = 31;
            cb_Halvfabrikat_ArtikelNr.SelectedIndexChanged += Halvfabrikat_ArtikelNr_TextChanged;
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
            cb_Halvfabrikat_Typ.Font = new Font("Courier New", 8.25F, FontStyle.Italic);
            cb_Halvfabrikat_Typ.ForeColor = Color.DarkSlateGray;
            cb_Halvfabrikat_Typ.FormattingEnabled = true;
            cb_Halvfabrikat_Typ.IntegralHeight = false;
            cb_Halvfabrikat_Typ.Items.AddRange(new object[] { "Mjukslang", "Svetsform" });
            cb_Halvfabrikat_Typ.Location = new Point(0, 0);
            cb_Halvfabrikat_Typ.Margin = new Padding(0);
            cb_Halvfabrikat_Typ.Name = "cb_Halvfabrikat_Typ";
            cb_Halvfabrikat_Typ.Size = new Size(126, 23);
            cb_Halvfabrikat_Typ.TabIndex = 30;
            // 
            // label_Halvfabrikat_Längd
            // 
            label_Halvfabrikat_Längd.BackColor = Color.White;
            label_Halvfabrikat_Längd.Dock = DockStyle.Fill;
            label_Halvfabrikat_Längd.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Halvfabrikat_Längd.ForeColor = Color.Black;
            label_Halvfabrikat_Längd.Location = new Point(656, 22);
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
            label_Halvfabrikat_W.Size = new Size(63, 20);
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
            // label_Halvfabrikat_OrderNr
            // 
            label_Halvfabrikat_OrderNr.BackColor = Color.White;
            label_Halvfabrikat_OrderNr.Dock = DockStyle.Fill;
            label_Halvfabrikat_OrderNr.Font = new Font("Arial", 9.25F, FontStyle.Bold);
            label_Halvfabrikat_OrderNr.ForeColor = Color.Black;
            label_Halvfabrikat_OrderNr.Location = new Point(285, 22);
            label_Halvfabrikat_OrderNr.Margin = new Padding(1, 1, 0, 1);
            label_Halvfabrikat_OrderNr.Name = "label_Halvfabrikat_OrderNr";
            label_Halvfabrikat_OrderNr.Size = new Size(190, 20);
            label_Halvfabrikat_OrderNr.TabIndex = 908;
            label_Halvfabrikat_OrderNr.Text = "LotNr";
            label_Halvfabrikat_OrderNr.TextAlign = ContentAlignment.MiddleLeft;
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
            label_Halvfabrikat.Size = new Size(846, 21);
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
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
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
            dgv_Halvfabrikat.ScrollBars = ScrollBars.None;
            dgv_Halvfabrikat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Halvfabrikat.Size = new Size(710, 332);
            dgv_Halvfabrikat.TabIndex = 845;
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
            lbl_Transfer_Halvfabrikat.Click += Transfer_Halvfabrikat_Click;
            // 
            // lbl_Halvfabrikat_OD
            // 
            lbl_Halvfabrikat_OD.BackColor = Color.White;
            lbl_Halvfabrikat_OD.BorderStyle = BorderStyle.None;
            lbl_Halvfabrikat_OD.Dock = DockStyle.Fill;
            lbl_Halvfabrikat_OD.Font = new Font("Consolas", 8.25F, FontStyle.Italic);
            lbl_Halvfabrikat_OD.ForeColor = Color.Gray;
            lbl_Halvfabrikat_OD.Location = new Point(534, 43);
            lbl_Halvfabrikat_OD.Margin = new Padding(1, 0, 0, 0);
            lbl_Halvfabrikat_OD.MaxLength = 5;
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
            lbl_Halvfabrikat_W.Font = new Font("Consolas", 8.25F, FontStyle.Italic);
            lbl_Halvfabrikat_W.ForeColor = Color.Gray;
            lbl_Halvfabrikat_W.Location = new Point(592, 43);
            lbl_Halvfabrikat_W.Margin = new Padding(1, 0, 0, 0);
            lbl_Halvfabrikat_W.MaxLength = 5;
            lbl_Halvfabrikat_W.Multiline = true;
            lbl_Halvfabrikat_W.Name = "lbl_Halvfabrikat_W";
            lbl_Halvfabrikat_W.Size = new Size(63, 22);
            lbl_Halvfabrikat_W.TabIndex = 916;
            // 
            // lbl_Halvfabrikat_L
            // 
            lbl_Halvfabrikat_L.BackColor = Color.White;
            lbl_Halvfabrikat_L.BorderStyle = BorderStyle.None;
            lbl_Halvfabrikat_L.Dock = DockStyle.Fill;
            lbl_Halvfabrikat_L.Font = new Font("Consolas", 8.25F, FontStyle.Italic);
            lbl_Halvfabrikat_L.ForeColor = Color.Gray;
            lbl_Halvfabrikat_L.Location = new Point(656, 43);
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
            label_Empty_9.Location = new Point(745, 22);
            label_Empty_9.Margin = new Padding(1, 1, 0, 0);
            label_Empty_9.Name = "label_Empty_9";
            tlp_Halvfabrikat.SetRowSpan(label_Empty_9, 3);
            label_Empty_9.Size = new Size(101, 377);
            label_Empty_9.TabIndex = 1007;
            label_Empty_9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Delete_Halvfabrikat
            // 
            lbl_Delete_Halvfabrikat.BackColor = Color.FromArgb(255, 199, 206);
            lbl_Delete_Halvfabrikat.Cursor = Cursors.Hand;
            lbl_Delete_Halvfabrikat.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            lbl_Delete_Halvfabrikat.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_Delete_Halvfabrikat.Location = new Point(0, 66);
            lbl_Delete_Halvfabrikat.Margin = new Padding(0, 1, 0, 0);
            lbl_Delete_Halvfabrikat.Name = "lbl_Delete_Halvfabrikat";
            lbl_Delete_Halvfabrikat.Size = new Size(33, 25);
            lbl_Delete_Halvfabrikat.TabIndex = 28;
            lbl_Delete_Halvfabrikat.Text = "→";
            lbl_Delete_Halvfabrikat.TextAlign = ContentAlignment.TopCenter;
            lbl_Delete_Halvfabrikat.Click += Delete_Halvfabrikat_Click;
            // 
            // panel_MaskinParametrar
            // 
            panel_MaskinParametrar.BorderStyle = BorderStyle.FixedSingle;
            tlp_Main.SetColumnSpan(panel_MaskinParametrar, 3);
            panel_MaskinParametrar.Controls.Add(tlp_Maskinparametrar);
            panel_MaskinParametrar.Dock = DockStyle.Fill;
            panel_MaskinParametrar.Location = new Point(0, 97);
            panel_MaskinParametrar.Margin = new Padding(0);
            panel_MaskinParametrar.Name = "panel_MaskinParametrar";
            panel_MaskinParametrar.Size = new Size(848, 366);
            panel_MaskinParametrar.TabIndex = 906;
            // 
            // tlp_Maskinparametrar
            // 
            tlp_Maskinparametrar.BackColor = Color.FromArgb(45, 45, 45);
            tlp_Maskinparametrar.ColumnCount = 13;
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 63F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 66F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 59F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 83F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 47F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44F));
            tlp_Maskinparametrar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 142F));
            tlp_Maskinparametrar.Controls.Add(Processkort_Kragning, 0, 0);
            tlp_Maskinparametrar.Controls.Add(KP_Kragning, 0, 1);
            tlp_Maskinparametrar.Cursor = Cursors.SizeAll;
            tlp_Maskinparametrar.Dock = DockStyle.Fill;
            tlp_Maskinparametrar.Location = new Point(0, 0);
            tlp_Maskinparametrar.Margin = new Padding(0);
            tlp_Maskinparametrar.Name = "tlp_Maskinparametrar";
            tlp_Maskinparametrar.RowCount = 3;
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 209F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_Maskinparametrar.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_Maskinparametrar.Size = new Size(846, 364);
            tlp_Maskinparametrar.TabIndex = 0;
            // 
            // Processkort_Kragning
            // 
            tlp_Maskinparametrar.SetColumnSpan(Processkort_Kragning, 13);
            Processkort_Kragning.Dock = DockStyle.Fill;
            Processkort_Kragning.Location = new Point(0, 0);
            Processkort_Kragning.Margin = new Padding(0);
            Processkort_Kragning.Name = "Processkort_Kragning";
            Processkort_Kragning.Size = new Size(846, 209);
            Processkort_Kragning.TabIndex = 1009;
            // 
            // KP_Kragning
            // 
            KP_Kragning.BackColor = Color.FromArgb(80, 80, 80);
            tlp_Maskinparametrar.SetColumnSpan(KP_Kragning, 13);
            KP_Kragning.Dock = DockStyle.Fill;
            KP_Kragning.Location = new Point(0, 209);
            KP_Kragning.Margin = new Padding(0);
            KP_Kragning.Name = "KP_Kragning";
            tlp_Maskinparametrar.SetRowSpan(KP_Kragning, 2);
            KP_Kragning.Size = new Size(846, 155);
            KP_Kragning.TabIndex = 1010;
            // 
            // panel_ProduktInformation
            // 
            panel_ProduktInformation.BorderStyle = BorderStyle.FixedSingle;
            tlp_Main.SetColumnSpan(panel_ProduktInformation, 3);
            panel_ProduktInformation.Controls.Add(tlp_ProduktInformation);
            panel_ProduktInformation.Dock = DockStyle.Fill;
            panel_ProduktInformation.Location = new Point(0, 0);
            panel_ProduktInformation.Margin = new Padding(0);
            panel_ProduktInformation.Name = "panel_ProduktInformation";
            panel_ProduktInformation.Size = new Size(848, 97);
            panel_ProduktInformation.TabIndex = 131;
            // 
            // tlp_ProduktInformation
            // 
            tlp_ProduktInformation.BackColor = Color.FromArgb(45, 45, 45);
            tlp_ProduktInformation.ColumnCount = 5;
            tlp_ProduktInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 259F));
            tlp_ProduktInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            tlp_ProduktInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tlp_ProduktInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tlp_ProduktInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 205F));
            tlp_ProduktInformation.Controls.Add(lbl_Benämning, 1, 1);
            tlp_ProduktInformation.Controls.Add(label_Benämning, 1, 0);
            tlp_ProduktInformation.Controls.Add(label_Påse_Spole, 3, 2);
            tlp_ProduktInformation.Controls.Add(ProdType, 0, 3);
            tlp_ProduktInformation.Controls.Add(lbl_OrderNr, 4, 0);
            tlp_ProduktInformation.Controls.Add(lbl_ArtikelNr, 4, 1);
            tlp_ProduktInformation.Controls.Add(label_Kund, 0, 0);
            tlp_ProduktInformation.Controls.Add(label_ProdType, 0, 2);
            tlp_ProduktInformation.Controls.Add(label_ArtikelNr, 3, 1);
            tlp_ProduktInformation.Controls.Add(label_Datum, 1, 2);
            tlp_ProduktInformation.Controls.Add(label_OrderNr, 3, 0);
            tlp_ProduktInformation.Controls.Add(lbl_Customer, 0, 1);
            tlp_ProduktInformation.Controls.Add(lbl_LC_Date, 1, 3);
            tlp_ProduktInformation.Controls.Add(label_Namn, 2, 2);
            tlp_ProduktInformation.Controls.Add(Påse_Spole, 3, 3);
            tlp_ProduktInformation.Controls.Add(Name_Start, 2, 3);
            tlp_ProduktInformation.Dock = DockStyle.Fill;
            tlp_ProduktInformation.Location = new Point(0, 0);
            tlp_ProduktInformation.Margin = new Padding(0);
            tlp_ProduktInformation.Name = "tlp_ProduktInformation";
            tlp_ProduktInformation.RowCount = 4;
            tlp_ProduktInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_ProduktInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_ProduktInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tlp_ProduktInformation.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlp_ProduktInformation.Size = new Size(846, 95);
            tlp_ProduktInformation.TabIndex = 0;
            // 
            // lbl_Benämning
            // 
            lbl_Benämning.BackColor = Color.White;
            tlp_ProduktInformation.SetColumnSpan(lbl_Benämning, 2);
            lbl_Benämning.Dock = DockStyle.Fill;
            lbl_Benämning.Font = new Font("Consolas", 8.25F);
            lbl_Benämning.ForeColor = Color.Gray;
            lbl_Benämning.Location = new Point(260, 23);
            lbl_Benämning.Margin = new Padding(1, 0, 0, 1);
            lbl_Benämning.Name = "lbl_Benämning";
            lbl_Benämning.Size = new Size(324, 22);
            lbl_Benämning.TabIndex = 916;
            lbl_Benämning.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Benämning
            // 
            label_Benämning.BackColor = Color.White;
            tlp_ProduktInformation.SetColumnSpan(label_Benämning, 2);
            label_Benämning.Cursor = Cursors.SizeAll;
            label_Benämning.Dock = DockStyle.Fill;
            label_Benämning.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Benämning.ForeColor = Color.Black;
            label_Benämning.Location = new Point(260, 0);
            label_Benämning.Margin = new Padding(1, 0, 0, 0);
            label_Benämning.Name = "label_Benämning";
            label_Benämning.Size = new Size(324, 23);
            label_Benämning.TabIndex = 915;
            label_Benämning.Text = "Benämning";
            label_Benämning.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Påse_Spole
            // 
            label_Påse_Spole.BackColor = Color.White;
            tlp_ProduktInformation.SetColumnSpan(label_Påse_Spole, 2);
            label_Påse_Spole.Dock = DockStyle.Fill;
            label_Påse_Spole.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Påse_Spole.ForeColor = Color.Black;
            label_Påse_Spole.Location = new Point(585, 46);
            label_Påse_Spole.Margin = new Padding(1, 0, 0, 0);
            label_Påse_Spole.Name = "label_Påse_Spole";
            label_Påse_Spole.Size = new Size(261, 16);
            label_Påse_Spole.TabIndex = 908;
            label_Påse_Spole.Text = "Från påse/spole nr";
            label_Påse_Spole.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ProdType
            // 
            ProdType.BackColor = Color.White;
            ProdType.BorderStyle = BorderStyle.None;
            ProdType.Cursor = Cursors.IBeam;
            ProdType.Dock = DockStyle.Fill;
            ProdType.Enabled = false;
            ProdType.Font = new Font("Consolas", 8.25F);
            ProdType.ForeColor = Color.Gray;
            ProdType.Location = new Point(0, 62);
            ProdType.Margin = new Padding(0);
            ProdType.Multiline = true;
            ProdType.Name = "ProdType";
            ProdType.Size = new Size(259, 33);
            ProdType.TabIndex = 808;
            ProdType.WordWrap = false;
            // 
            // lbl_OrderNr
            // 
            lbl_OrderNr.AutoSize = true;
            lbl_OrderNr.BackColor = Color.White;
            lbl_OrderNr.Dock = DockStyle.Fill;
            lbl_OrderNr.Font = new Font("Consolas", 8.25F);
            lbl_OrderNr.ForeColor = Color.Gray;
            lbl_OrderNr.Location = new Point(640, 0);
            lbl_OrderNr.Margin = new Padding(0);
            lbl_OrderNr.Name = "lbl_OrderNr";
            lbl_OrderNr.Size = new Size(206, 23);
            lbl_OrderNr.TabIndex = 135;
            lbl_OrderNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_ArtikelNr
            // 
            lbl_ArtikelNr.AutoSize = true;
            lbl_ArtikelNr.BackColor = Color.White;
            lbl_ArtikelNr.Dock = DockStyle.Fill;
            lbl_ArtikelNr.Font = new Font("Consolas", 8.25F);
            lbl_ArtikelNr.ForeColor = Color.Gray;
            lbl_ArtikelNr.Location = new Point(640, 23);
            lbl_ArtikelNr.Margin = new Padding(0, 0, 0, 1);
            lbl_ArtikelNr.Name = "lbl_ArtikelNr";
            lbl_ArtikelNr.Size = new Size(206, 22);
            lbl_ArtikelNr.TabIndex = 134;
            lbl_ArtikelNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Kund
            // 
            label_Kund.BackColor = Color.White;
            label_Kund.Cursor = Cursors.SizeAll;
            label_Kund.Dock = DockStyle.Fill;
            label_Kund.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Kund.ForeColor = Color.Black;
            label_Kund.Location = new Point(0, 0);
            label_Kund.Margin = new Padding(0);
            label_Kund.Name = "label_Kund";
            label_Kund.Size = new Size(259, 23);
            label_Kund.TabIndex = 128;
            label_Kund.Text = "Kund:";
            label_Kund.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_ProdType
            // 
            label_ProdType.BackColor = Color.White;
            label_ProdType.Cursor = Cursors.SizeAll;
            label_ProdType.Dock = DockStyle.Fill;
            label_ProdType.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_ProdType.ForeColor = Color.Black;
            label_ProdType.Location = new Point(0, 46);
            label_ProdType.Margin = new Padding(0);
            label_ProdType.Name = "label_ProdType";
            label_ProdType.Size = new Size(259, 16);
            label_ProdType.TabIndex = 129;
            label_ProdType.Text = "ProduktTyp";
            label_ProdType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_ArtikelNr
            // 
            label_ArtikelNr.BackColor = Color.White;
            label_ArtikelNr.Dock = DockStyle.Fill;
            label_ArtikelNr.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_ArtikelNr.ForeColor = Color.Black;
            label_ArtikelNr.Location = new Point(585, 23);
            label_ArtikelNr.Margin = new Padding(1, 0, 0, 1);
            label_ArtikelNr.Name = "label_ArtikelNr";
            label_ArtikelNr.Size = new Size(55, 22);
            label_ArtikelNr.TabIndex = 130;
            label_ArtikelNr.Text = "Art. nr.";
            label_ArtikelNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Datum
            // 
            label_Datum.BackColor = Color.White;
            label_Datum.Cursor = Cursors.SizeAll;
            label_Datum.Dock = DockStyle.Fill;
            label_Datum.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Datum.ForeColor = Color.Black;
            label_Datum.Location = new Point(260, 46);
            label_Datum.Margin = new Padding(1, 0, 0, 0);
            label_Datum.Name = "label_Datum";
            label_Datum.Size = new Size(104, 16);
            label_Datum.TabIndex = 130;
            label_Datum.Text = "Datum";
            label_Datum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr
            // 
            label_OrderNr.BackColor = Color.White;
            label_OrderNr.Dock = DockStyle.Fill;
            label_OrderNr.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_OrderNr.ForeColor = Color.Black;
            label_OrderNr.Location = new Point(585, 0);
            label_OrderNr.Margin = new Padding(1, 0, 0, 0);
            label_OrderNr.Name = "label_OrderNr";
            label_OrderNr.Size = new Size(55, 23);
            label_OrderNr.TabIndex = 130;
            label_OrderNr.Text = "T.O. nr";
            label_OrderNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Customer
            // 
            lbl_Customer.AutoSize = true;
            lbl_Customer.BackColor = Color.White;
            lbl_Customer.Dock = DockStyle.Fill;
            lbl_Customer.Font = new Font("Consolas", 8.25F);
            lbl_Customer.ForeColor = Color.Gray;
            lbl_Customer.Location = new Point(0, 23);
            lbl_Customer.Margin = new Padding(0, 0, 0, 1);
            lbl_Customer.Name = "lbl_Customer";
            lbl_Customer.Size = new Size(259, 22);
            lbl_Customer.TabIndex = 132;
            // 
            // lbl_LC_Date
            // 
            lbl_LC_Date.BackColor = Color.White;
            lbl_LC_Date.Dock = DockStyle.Fill;
            lbl_LC_Date.Font = new Font("Courier New", 8.25F);
            lbl_LC_Date.ForeColor = Color.DarkSlateGray;
            lbl_LC_Date.Location = new Point(260, 62);
            lbl_LC_Date.Margin = new Padding(1, 0, 0, 0);
            lbl_LC_Date.Name = "lbl_LC_Date";
            lbl_LC_Date.Size = new Size(104, 33);
            lbl_LC_Date.TabIndex = 914;
            lbl_LC_Date.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Namn
            // 
            label_Namn.BackColor = Color.White;
            label_Namn.Cursor = Cursors.SizeAll;
            label_Namn.Dock = DockStyle.Fill;
            label_Namn.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Namn.ForeColor = Color.Black;
            label_Namn.Location = new Point(365, 46);
            label_Namn.Margin = new Padding(1, 0, 0, 0);
            label_Namn.Name = "label_Namn";
            label_Namn.Size = new Size(219, 16);
            label_Namn.TabIndex = 917;
            label_Namn.Text = "Namn";
            label_Namn.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Påse_Spole
            // 
            Påse_Spole.BackColor = Color.White;
            Påse_Spole.BorderStyle = BorderStyle.None;
            tlp_ProduktInformation.SetColumnSpan(Påse_Spole, 2);
            Påse_Spole.Cursor = Cursors.IBeam;
            Påse_Spole.Dock = DockStyle.Fill;
            Påse_Spole.Enabled = false;
            Påse_Spole.Font = new Font("Courier New", 8.25F);
            Påse_Spole.ForeColor = Color.DarkSlateGray;
            Påse_Spole.Location = new Point(585, 62);
            Påse_Spole.Margin = new Padding(1, 0, 0, 0);
            Påse_Spole.Multiline = true;
            Påse_Spole.Name = "Påse_Spole";
            Påse_Spole.Size = new Size(261, 33);
            Påse_Spole.TabIndex = 909;
            Påse_Spole.WordWrap = false;
            Påse_Spole.TextChanged += Påse_Spole_TextChanged;
            Påse_Spole.KeyPress += Only_Decimals_KeyPress;
            // 
            // Name_Start
            // 
            Name_Start.BackColor = Color.White;
            Name_Start.Dock = DockStyle.Fill;
            Name_Start.Font = new Font("Courier New", 8.25F);
            Name_Start.ForeColor = Color.DarkSlateGray;
            Name_Start.Location = new Point(365, 62);
            Name_Start.Margin = new Padding(1, 0, 0, 0);
            Name_Start.Name = "Name_Start";
            Name_Start.Size = new Size(219, 33);
            Name_Start.TabIndex = 914;
            Name_Start.TextAlign = ContentAlignment.MiddleLeft;
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
            Halvfabrikat_Slang.Width = 126;
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
            Halvfabrikat_ArtikelNr.Width = 124;
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
            Halvfabrikat_W.Width = 64;
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
            // MainProtocol_Kragning_TEF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainProtocol_Kragning_TEF";
            Size = new Size(848, 864);
            tlp_Main.ResumeLayout(false);
            panel_Halvfabrikat.ResumeLayout(false);
            tlp_Halvfabrikat.ResumeLayout(false);
            tlp_Halvfabrikat.PerformLayout();
            panel_Halvfabrikat_OrderNr.ResumeLayout(false);
            panel_Halvfabrikat_ArtikelNr.ResumeLayout(false);
            panel_Halvfabrikat_Typ.ResumeLayout(false);
            ((ISupportInitialize)dgv_Halvfabrikat).EndInit();
            panel_MaskinParametrar.ResumeLayout(false);
            tlp_Maskinparametrar.ResumeLayout(false);
            panel_ProduktInformation.ResumeLayout(false);
            tlp_ProduktInformation.ResumeLayout(false);
            tlp_ProduktInformation.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Panel panel_MaskinParametrar;
        private TableLayoutPanel tlp_Maskinparametrar;
        private PC_Kragning Processkort_Kragning;
        private Panel panel_ProduktInformation;
        private TableLayoutPanel tlp_ProduktInformation;
        private Label label_Benämning;
        private Label label_Påse_Spole;
        private Label label_Kund;
        private Label label_ProdType;
        private Label label_ArtikelNr;
        private Label label_Datum;
        private Label label_OrderNr;
        private Label lbl_LC_Date;
        private Label label_Namn;
        private Label Name_Start;
        public Label lbl_Benämning;
        public TextBox ProdType;
        public Label lbl_ArtikelNr;
        public Label lbl_Customer;
        private Panel panel_Halvfabrikat;
        private TableLayoutPanel tlp_Halvfabrikat;
        private TextBox lbl_Halvfabrikat_ID;
        private Panel panel_Halvfabrikat_OrderNr;
        private ComboBox cb_Halvfabrikat_OrderNr;
        private Panel panel_Halvfabrikat_ArtikelNr;
        private ComboBox cb_Halvfabrikat_ArtikelNr;
        private Panel panel_Halvfabrikat_Typ;
        private ComboBox cb_Halvfabrikat_Typ;
        private Label label_Halvfabrikat_Längd;
        private Label label_Halvfabrikat_W;
        private Label label_Halvfabrikat_OD;
        private Label label_Halvfabrikat_OrderNr;
        private Label label_Halvfabrikat_ArtikelNr;
        private Label label_Halvfabrikat;
        private Label label_Halvfabrikat_ID;
        private Label label1;
        private DataGridView dgv_Halvfabrikat;
        private TextBox lbl_Halvfabrikat_OD;
        private TextBox lbl_Halvfabrikat_W;
        private TextBox lbl_Halvfabrikat_L;
        private Label label_Empty_9;
        public TextBox Påse_Spole;
        public Label lbl_Transfer_Halvfabrikat;
        public Label lbl_Delete_Halvfabrikat;
        public KP_Kragning KP_Kragning;
        public Label lbl_OrderNr;
        private DataGridViewTextBoxColumn Halvfabrikat_Slang;
        private DataGridViewTextBoxColumn Halvfabrikat_ArtikelNr;
        private DataGridViewTextBoxColumn Halvfabrikat_OrderNr;
        private DataGridViewTextBoxColumn Halvfabrikat_ID;
        private DataGridViewTextBoxColumn Halvfabrikat_OD;
        private DataGridViewTextBoxColumn Halvfabrikat_W;
        private DataGridViewTextBoxColumn Halvfabrikat_Längd;
    }
}
