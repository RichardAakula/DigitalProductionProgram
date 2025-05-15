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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Halvfabrikat = new System.Windows.Forms.Panel();
            this.tlp_Halvfabrikat = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Halvfabrikat_ID = new System.Windows.Forms.TextBox();
            this.panel_Halvfabrikat_OrderNr = new System.Windows.Forms.Panel();
            this.cb_Halvfabrikat_OrderNr = new System.Windows.Forms.ComboBox();
            this.panel_Halvfabrikat_ArtikelNr = new System.Windows.Forms.Panel();
            this.cb_Halvfabrikat_ArtikelNr = new System.Windows.Forms.ComboBox();
            this.panel_Halvfabrikat_Typ = new System.Windows.Forms.Panel();
            this.cb_Halvfabrikat_Typ = new System.Windows.Forms.ComboBox();
            this.label_Halvfabrikat_Längd = new System.Windows.Forms.Label();
            this.label_Halvfabrikat_W = new System.Windows.Forms.Label();
            this.label_Halvfabrikat_OD = new System.Windows.Forms.Label();
            this.label_Halvfabrikat_OrderNr = new System.Windows.Forms.Label();
            this.label_Halvfabrikat_ArtikelNr = new System.Windows.Forms.Label();
            this.label_Halvfabrikat = new System.Windows.Forms.Label();
            this.label_Halvfabrikat_ID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Halvfabrikat = new System.Windows.Forms.DataGridView();
            this.Halvfabrikat_Slang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Halvfabrikat_ArtikelNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Halvfabrikat_OrderNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Halvfabrikat_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Halvfabrikat_OD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Halvfabrikat_W = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Halvfabrikat_Längd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_Transfer_Halvfabrikat = new System.Windows.Forms.Label();
            this.lbl_Halvfabrikat_OD = new System.Windows.Forms.TextBox();
            this.lbl_Halvfabrikat_W = new System.Windows.Forms.TextBox();
            this.lbl_Halvfabrikat_L = new System.Windows.Forms.TextBox();
            this.label_Empty_9 = new System.Windows.Forms.Label();
            this.lbl_Delete_Halvfabrikat = new System.Windows.Forms.Label();
            this.panel_MaskinParametrar = new System.Windows.Forms.Panel();
            this.tlp_Maskinparametrar = new System.Windows.Forms.TableLayoutPanel();
            this.Processkort_Kragning = new DigitalProductionProgram.Protocols.Kragning_TEF.PC_Kragning();
            this.KP_Kragning = new DigitalProductionProgram.Protocols.Kragning_TEF.KP_Kragning();
            this.panel_ProduktInformation = new System.Windows.Forms.Panel();
            this.tlp_ProduktInformation = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Benämning = new System.Windows.Forms.Label();
            this.label_Benämning = new System.Windows.Forms.Label();
            this.label_Påse_Spole = new System.Windows.Forms.Label();
            this.ProdType = new System.Windows.Forms.TextBox();
            this.lbl_OrderNr = new System.Windows.Forms.Label();
            this.lbl_ArtikelNr = new System.Windows.Forms.Label();
            this.label_Kund = new System.Windows.Forms.Label();
            this.label_ProdType = new System.Windows.Forms.Label();
            this.label_ArtikelNr = new System.Windows.Forms.Label();
            this.label_Datum = new System.Windows.Forms.Label();
            this.label_OrderNr = new System.Windows.Forms.Label();
            this.lbl_Customer = new System.Windows.Forms.Label();
            this.lbl_LC_Date = new System.Windows.Forms.Label();
            this.label_Namn = new System.Windows.Forms.Label();
            this.Påse_Spole = new System.Windows.Forms.TextBox();
            this.Name_Start = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            this.panel_Halvfabrikat.SuspendLayout();
            this.tlp_Halvfabrikat.SuspendLayout();
            this.panel_Halvfabrikat_OrderNr.SuspendLayout();
            this.panel_Halvfabrikat_ArtikelNr.SuspendLayout();
            this.panel_Halvfabrikat_Typ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Halvfabrikat)).BeginInit();
            this.panel_MaskinParametrar.SuspendLayout();
            this.tlp_Maskinparametrar.SuspendLayout();
            this.panel_ProduktInformation.SuspendLayout();
            this.tlp_ProduktInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.White;
            this.tlp_Main.ColumnCount = 3;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 513F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tlp_Main.Controls.Add(this.panel_Halvfabrikat, 0, 2);
            this.tlp_Main.Controls.Add(this.panel_MaskinParametrar, 0, 1);
            this.tlp_Main.Controls.Add(this.panel_ProduktInformation, 0, 0);
            this.tlp_Main.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 317F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tlp_Main.Size = new System.Drawing.Size(727, 749);
            this.tlp_Main.TabIndex = 1;
            // 
            // panel_Halvfabrikat
            // 
            this.panel_Halvfabrikat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlp_Main.SetColumnSpan(this.panel_Halvfabrikat, 3);
            this.panel_Halvfabrikat.Controls.Add(this.tlp_Halvfabrikat);
            this.panel_Halvfabrikat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Halvfabrikat.Location = new System.Drawing.Point(0, 401);
            this.panel_Halvfabrikat.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Halvfabrikat.Name = "panel_Halvfabrikat";
            this.panel_Halvfabrikat.Size = new System.Drawing.Size(727, 348);
            this.panel_Halvfabrikat.TabIndex = 907;
            // 
            // tlp_Halvfabrikat
            // 
            this.tlp_Halvfabrikat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tlp_Halvfabrikat.ColumnCount = 9;
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tlp_Halvfabrikat.Controls.Add(this.lbl_Halvfabrikat_ID, 4, 2);
            this.tlp_Halvfabrikat.Controls.Add(this.panel_Halvfabrikat_OrderNr, 3, 2);
            this.tlp_Halvfabrikat.Controls.Add(this.panel_Halvfabrikat_ArtikelNr, 2, 2);
            this.tlp_Halvfabrikat.Controls.Add(this.panel_Halvfabrikat_Typ, 1, 2);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Halvfabrikat_Längd, 7, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Halvfabrikat_W, 6, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Halvfabrikat_OD, 5, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Halvfabrikat_OrderNr, 3, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Halvfabrikat_ArtikelNr, 1, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Halvfabrikat, 0, 0);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Halvfabrikat_ID, 4, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.label1, 2, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.dgv_Halvfabrikat, 1, 3);
            this.tlp_Halvfabrikat.Controls.Add(this.lbl_Transfer_Halvfabrikat, 0, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.lbl_Halvfabrikat_OD, 5, 2);
            this.tlp_Halvfabrikat.Controls.Add(this.lbl_Halvfabrikat_W, 6, 2);
            this.tlp_Halvfabrikat.Controls.Add(this.lbl_Halvfabrikat_L, 7, 2);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Empty_9, 8, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.lbl_Delete_Halvfabrikat, 0, 3);
            this.tlp_Halvfabrikat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Halvfabrikat.Location = new System.Drawing.Point(0, 0);
            this.tlp_Halvfabrikat.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Halvfabrikat.Name = "tlp_Halvfabrikat";
            this.tlp_Halvfabrikat.RowCount = 4;
            this.tlp_Halvfabrikat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Halvfabrikat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tlp_Halvfabrikat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tlp_Halvfabrikat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tlp_Halvfabrikat.Size = new System.Drawing.Size(725, 346);
            this.tlp_Halvfabrikat.TabIndex = 1;
            // 
            // lbl_Halvfabrikat_ID
            // 
            this.lbl_Halvfabrikat_ID.BackColor = System.Drawing.Color.White;
            this.lbl_Halvfabrikat_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Halvfabrikat_ID.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Halvfabrikat_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Halvfabrikat_ID.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.lbl_Halvfabrikat_ID.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Halvfabrikat_ID.Location = new System.Drawing.Point(408, 37);
            this.lbl_Halvfabrikat_ID.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_Halvfabrikat_ID.MaxLength = 5;
            this.lbl_Halvfabrikat_ID.Multiline = true;
            this.lbl_Halvfabrikat_ID.Name = "lbl_Halvfabrikat_ID";
            this.lbl_Halvfabrikat_ID.Size = new System.Drawing.Size(49, 19);
            this.lbl_Halvfabrikat_ID.TabIndex = 916;
            // 
            // panel_Halvfabrikat_OrderNr
            // 
            this.panel_Halvfabrikat_OrderNr.BackColor = System.Drawing.Color.White;
            this.panel_Halvfabrikat_OrderNr.Controls.Add(this.cb_Halvfabrikat_OrderNr);
            this.panel_Halvfabrikat_OrderNr.ForeColor = System.Drawing.Color.Black;
            this.panel_Halvfabrikat_OrderNr.Location = new System.Drawing.Point(244, 37);
            this.panel_Halvfabrikat_OrderNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.panel_Halvfabrikat_OrderNr.Name = "panel_Halvfabrikat_OrderNr";
            this.panel_Halvfabrikat_OrderNr.Size = new System.Drawing.Size(163, 19);
            this.panel_Halvfabrikat_OrderNr.TabIndex = 920;
            // 
            // cb_Halvfabrikat_OrderNr
            // 
            this.cb_Halvfabrikat_OrderNr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Halvfabrikat_OrderNr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Halvfabrikat_OrderNr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Halvfabrikat_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Halvfabrikat_OrderNr.DropDownHeight = 130;
            this.cb_Halvfabrikat_OrderNr.DropDownWidth = 130;
            this.cb_Halvfabrikat_OrderNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Halvfabrikat_OrderNr.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic);
            this.cb_Halvfabrikat_OrderNr.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cb_Halvfabrikat_OrderNr.FormattingEnabled = true;
            this.cb_Halvfabrikat_OrderNr.IntegralHeight = false;
            this.cb_Halvfabrikat_OrderNr.Location = new System.Drawing.Point(0, 0);
            this.cb_Halvfabrikat_OrderNr.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Halvfabrikat_OrderNr.Name = "cb_Halvfabrikat_OrderNr";
            this.cb_Halvfabrikat_OrderNr.Size = new System.Drawing.Size(163, 23);
            this.cb_Halvfabrikat_OrderNr.TabIndex = 32;
            // 
            // panel_Halvfabrikat_ArtikelNr
            // 
            this.panel_Halvfabrikat_ArtikelNr.BackColor = System.Drawing.Color.White;
            this.panel_Halvfabrikat_ArtikelNr.Controls.Add(this.cb_Halvfabrikat_ArtikelNr);
            this.panel_Halvfabrikat_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Halvfabrikat_ArtikelNr.ForeColor = System.Drawing.Color.Black;
            this.panel_Halvfabrikat_ArtikelNr.Location = new System.Drawing.Point(138, 37);
            this.panel_Halvfabrikat_ArtikelNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.panel_Halvfabrikat_ArtikelNr.Name = "panel_Halvfabrikat_ArtikelNr";
            this.panel_Halvfabrikat_ArtikelNr.Size = new System.Drawing.Size(105, 19);
            this.panel_Halvfabrikat_ArtikelNr.TabIndex = 919;
            // 
            // cb_Halvfabrikat_ArtikelNr
            // 
            this.cb_Halvfabrikat_ArtikelNr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Halvfabrikat_ArtikelNr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Halvfabrikat_ArtikelNr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Halvfabrikat_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Halvfabrikat_ArtikelNr.DropDownHeight = 130;
            this.cb_Halvfabrikat_ArtikelNr.DropDownWidth = 130;
            this.cb_Halvfabrikat_ArtikelNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Halvfabrikat_ArtikelNr.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic);
            this.cb_Halvfabrikat_ArtikelNr.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cb_Halvfabrikat_ArtikelNr.FormattingEnabled = true;
            this.cb_Halvfabrikat_ArtikelNr.IntegralHeight = false;
            this.cb_Halvfabrikat_ArtikelNr.Location = new System.Drawing.Point(0, 0);
            this.cb_Halvfabrikat_ArtikelNr.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Halvfabrikat_ArtikelNr.Name = "cb_Halvfabrikat_ArtikelNr";
            this.cb_Halvfabrikat_ArtikelNr.Size = new System.Drawing.Size(105, 23);
            this.cb_Halvfabrikat_ArtikelNr.TabIndex = 31;
            this.cb_Halvfabrikat_ArtikelNr.SelectedIndexChanged += new System.EventHandler(this.Halvfabrikat_ArtikelNr_TextChanged);
            // 
            // panel_Halvfabrikat_Typ
            // 
            this.panel_Halvfabrikat_Typ.BackColor = System.Drawing.Color.White;
            this.panel_Halvfabrikat_Typ.Controls.Add(this.cb_Halvfabrikat_Typ);
            this.panel_Halvfabrikat_Typ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Halvfabrikat_Typ.ForeColor = System.Drawing.Color.Black;
            this.panel_Halvfabrikat_Typ.Location = new System.Drawing.Point(29, 37);
            this.panel_Halvfabrikat_Typ.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.panel_Halvfabrikat_Typ.Name = "panel_Halvfabrikat_Typ";
            this.panel_Halvfabrikat_Typ.Size = new System.Drawing.Size(108, 19);
            this.panel_Halvfabrikat_Typ.TabIndex = 918;
            // 
            // cb_Halvfabrikat_Typ
            // 
            this.cb_Halvfabrikat_Typ.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Halvfabrikat_Typ.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Halvfabrikat_Typ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Halvfabrikat_Typ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Halvfabrikat_Typ.DropDownHeight = 130;
            this.cb_Halvfabrikat_Typ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Halvfabrikat_Typ.DropDownWidth = 130;
            this.cb_Halvfabrikat_Typ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Halvfabrikat_Typ.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic);
            this.cb_Halvfabrikat_Typ.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cb_Halvfabrikat_Typ.FormattingEnabled = true;
            this.cb_Halvfabrikat_Typ.IntegralHeight = false;
            this.cb_Halvfabrikat_Typ.Items.AddRange(new object[] {
            "Mjukslang",
            "Svetsform"});
            this.cb_Halvfabrikat_Typ.Location = new System.Drawing.Point(0, 0);
            this.cb_Halvfabrikat_Typ.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Halvfabrikat_Typ.Name = "cb_Halvfabrikat_Typ";
            this.cb_Halvfabrikat_Typ.Size = new System.Drawing.Size(108, 23);
            this.cb_Halvfabrikat_Typ.TabIndex = 30;
            // 
            // label_Halvfabrikat_Längd
            // 
            this.label_Halvfabrikat_Längd.BackColor = System.Drawing.Color.White;
            this.label_Halvfabrikat_Längd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Halvfabrikat_Längd.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Halvfabrikat_Längd.ForeColor = System.Drawing.Color.Black;
            this.label_Halvfabrikat_Längd.Location = new System.Drawing.Point(563, 19);
            this.label_Halvfabrikat_Längd.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Halvfabrikat_Längd.Name = "label_Halvfabrikat_Längd";
            this.label_Halvfabrikat_Längd.Size = new System.Drawing.Size(75, 17);
            this.label_Halvfabrikat_Längd.TabIndex = 917;
            this.label_Halvfabrikat_Längd.Text = "Längd";
            this.label_Halvfabrikat_Längd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Halvfabrikat_W
            // 
            this.label_Halvfabrikat_W.BackColor = System.Drawing.Color.White;
            this.label_Halvfabrikat_W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Halvfabrikat_W.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Halvfabrikat_W.ForeColor = System.Drawing.Color.Black;
            this.label_Halvfabrikat_W.Location = new System.Drawing.Point(508, 19);
            this.label_Halvfabrikat_W.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Halvfabrikat_W.Name = "label_Halvfabrikat_W";
            this.label_Halvfabrikat_W.Size = new System.Drawing.Size(54, 17);
            this.label_Halvfabrikat_W.TabIndex = 916;
            this.label_Halvfabrikat_W.Text = "W";
            this.label_Halvfabrikat_W.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Halvfabrikat_OD
            // 
            this.label_Halvfabrikat_OD.BackColor = System.Drawing.Color.White;
            this.label_Halvfabrikat_OD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Halvfabrikat_OD.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Halvfabrikat_OD.ForeColor = System.Drawing.Color.Black;
            this.label_Halvfabrikat_OD.Location = new System.Drawing.Point(458, 19);
            this.label_Halvfabrikat_OD.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Halvfabrikat_OD.Name = "label_Halvfabrikat_OD";
            this.label_Halvfabrikat_OD.Size = new System.Drawing.Size(49, 17);
            this.label_Halvfabrikat_OD.TabIndex = 914;
            this.label_Halvfabrikat_OD.Text = "OD";
            this.label_Halvfabrikat_OD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Halvfabrikat_OrderNr
            // 
            this.label_Halvfabrikat_OrderNr.BackColor = System.Drawing.Color.White;
            this.label_Halvfabrikat_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Halvfabrikat_OrderNr.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Halvfabrikat_OrderNr.ForeColor = System.Drawing.Color.Black;
            this.label_Halvfabrikat_OrderNr.Location = new System.Drawing.Point(244, 19);
            this.label_Halvfabrikat_OrderNr.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Halvfabrikat_OrderNr.Name = "label_Halvfabrikat_OrderNr";
            this.label_Halvfabrikat_OrderNr.Size = new System.Drawing.Size(163, 17);
            this.label_Halvfabrikat_OrderNr.TabIndex = 908;
            this.label_Halvfabrikat_OrderNr.Text = "LotNr";
            this.label_Halvfabrikat_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Halvfabrikat_ArtikelNr
            // 
            this.label_Halvfabrikat_ArtikelNr.BackColor = System.Drawing.Color.White;
            this.label_Halvfabrikat_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Halvfabrikat_ArtikelNr.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Halvfabrikat_ArtikelNr.ForeColor = System.Drawing.Color.Black;
            this.label_Halvfabrikat_ArtikelNr.Location = new System.Drawing.Point(29, 19);
            this.label_Halvfabrikat_ArtikelNr.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Halvfabrikat_ArtikelNr.Name = "label_Halvfabrikat_ArtikelNr";
            this.label_Halvfabrikat_ArtikelNr.Size = new System.Drawing.Size(108, 17);
            this.label_Halvfabrikat_ArtikelNr.TabIndex = 906;
            this.label_Halvfabrikat_ArtikelNr.Text = "Slang";
            this.label_Halvfabrikat_ArtikelNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Halvfabrikat
            // 
            this.label_Halvfabrikat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tlp_Halvfabrikat.SetColumnSpan(this.label_Halvfabrikat, 9);
            this.label_Halvfabrikat.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Halvfabrikat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Halvfabrikat.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label_Halvfabrikat.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label_Halvfabrikat.Location = new System.Drawing.Point(0, 0);
            this.label_Halvfabrikat.Margin = new System.Windows.Forms.Padding(0);
            this.label_Halvfabrikat.Name = "label_Halvfabrikat";
            this.label_Halvfabrikat.Size = new System.Drawing.Size(725, 18);
            this.label_Halvfabrikat.TabIndex = 904;
            this.label_Halvfabrikat.Text = "Halvfabrikat:";
            // 
            // label_Halvfabrikat_ID
            // 
            this.label_Halvfabrikat_ID.BackColor = System.Drawing.Color.White;
            this.label_Halvfabrikat_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Halvfabrikat_ID.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Halvfabrikat_ID.ForeColor = System.Drawing.Color.Black;
            this.label_Halvfabrikat_ID.Location = new System.Drawing.Point(408, 19);
            this.label_Halvfabrikat_ID.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Halvfabrikat_ID.Name = "label_Halvfabrikat_ID";
            this.label_Halvfabrikat_ID.Size = new System.Drawing.Size(49, 17);
            this.label_Halvfabrikat_ID.TabIndex = 913;
            this.label_Halvfabrikat_ID.Text = "ID";
            this.label_Halvfabrikat_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(138, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 906;
            this.label1.Text = "ArtikelNr";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_Halvfabrikat
            // 
            this.dgv_Halvfabrikat.AllowUserToAddRows = false;
            this.dgv_Halvfabrikat.AllowUserToDeleteRows = false;
            this.dgv_Halvfabrikat.AllowUserToResizeColumns = false;
            this.dgv_Halvfabrikat.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Halvfabrikat.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Halvfabrikat.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Halvfabrikat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Halvfabrikat.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Halvfabrikat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Halvfabrikat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Halvfabrikat.ColumnHeadersVisible = false;
            this.dgv_Halvfabrikat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Halvfabrikat_Slang,
            this.Halvfabrikat_ArtikelNr,
            this.Halvfabrikat_OrderNr,
            this.Halvfabrikat_ID,
            this.Halvfabrikat_OD,
            this.Halvfabrikat_W,
            this.Halvfabrikat_Längd});
            this.tlp_Halvfabrikat.SetColumnSpan(this.dgv_Halvfabrikat, 7);
            this.dgv_Halvfabrikat.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Halvfabrikat.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_Halvfabrikat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Halvfabrikat.Location = new System.Drawing.Point(29, 58);
            this.dgv_Halvfabrikat.Margin = new System.Windows.Forms.Padding(1, 2, 0, 0);
            this.dgv_Halvfabrikat.MultiSelect = false;
            this.dgv_Halvfabrikat.Name = "dgv_Halvfabrikat";
            this.dgv_Halvfabrikat.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Halvfabrikat.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_Halvfabrikat.RowHeadersVisible = false;
            this.dgv_Halvfabrikat.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Halvfabrikat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Halvfabrikat.Size = new System.Drawing.Size(609, 288);
            this.dgv_Halvfabrikat.TabIndex = 845;
            // 
            // Halvfabrikat_Slang
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 8.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Halvfabrikat_Slang.DefaultCellStyle = dataGridViewCellStyle3;
            this.Halvfabrikat_Slang.HeaderText = "Slang";
            this.Halvfabrikat_Slang.Name = "Halvfabrikat_Slang";
            this.Halvfabrikat_Slang.ReadOnly = true;
            this.Halvfabrikat_Slang.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Halvfabrikat_Slang.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Halvfabrikat_Slang.Width = 108;
            // 
            // Halvfabrikat_ArtikelNr
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 8.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.Halvfabrikat_ArtikelNr.DefaultCellStyle = dataGridViewCellStyle4;
            this.Halvfabrikat_ArtikelNr.HeaderText = "ArtikelNr";
            this.Halvfabrikat_ArtikelNr.Name = "Halvfabrikat_ArtikelNr";
            this.Halvfabrikat_ArtikelNr.ReadOnly = true;
            this.Halvfabrikat_ArtikelNr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Halvfabrikat_ArtikelNr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Halvfabrikat_ArtikelNr.Width = 106;
            // 
            // Halvfabrikat_OrderNr
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Courier New", 8.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.Halvfabrikat_OrderNr.DefaultCellStyle = dataGridViewCellStyle5;
            this.Halvfabrikat_OrderNr.HeaderText = "OrderNr";
            this.Halvfabrikat_OrderNr.Name = "Halvfabrikat_OrderNr";
            this.Halvfabrikat_OrderNr.ReadOnly = true;
            this.Halvfabrikat_OrderNr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Halvfabrikat_OrderNr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Halvfabrikat_OrderNr.Width = 164;
            // 
            // Halvfabrikat_ID
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 8.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.Halvfabrikat_ID.DefaultCellStyle = dataGridViewCellStyle6;
            this.Halvfabrikat_ID.HeaderText = "ID";
            this.Halvfabrikat_ID.Name = "Halvfabrikat_ID";
            this.Halvfabrikat_ID.ReadOnly = true;
            this.Halvfabrikat_ID.Width = 50;
            // 
            // Halvfabrikat_OD
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Consolas", 8.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.Halvfabrikat_OD.DefaultCellStyle = dataGridViewCellStyle7;
            this.Halvfabrikat_OD.HeaderText = "OD";
            this.Halvfabrikat_OD.Name = "Halvfabrikat_OD";
            this.Halvfabrikat_OD.ReadOnly = true;
            this.Halvfabrikat_OD.Width = 50;
            // 
            // Halvfabrikat_W
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Consolas", 8.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.Halvfabrikat_W.DefaultCellStyle = dataGridViewCellStyle8;
            this.Halvfabrikat_W.HeaderText = "W";
            this.Halvfabrikat_W.Name = "Halvfabrikat_W";
            this.Halvfabrikat_W.ReadOnly = true;
            this.Halvfabrikat_W.Width = 55;
            // 
            // Halvfabrikat_Längd
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Consolas", 8.5F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.Halvfabrikat_Längd.DefaultCellStyle = dataGridViewCellStyle9;
            this.Halvfabrikat_Längd.HeaderText = "Längd";
            this.Halvfabrikat_Längd.Name = "Halvfabrikat_Längd";
            this.Halvfabrikat_Längd.ReadOnly = true;
            this.Halvfabrikat_Längd.Width = 77;
            // 
            // lbl_Transfer_Halvfabrikat
            // 
            this.lbl_Transfer_Halvfabrikat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.lbl_Transfer_Halvfabrikat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Transfer_Halvfabrikat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Transfer_Halvfabrikat.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_Transfer_Halvfabrikat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.lbl_Transfer_Halvfabrikat.Location = new System.Drawing.Point(0, 19);
            this.lbl_Transfer_Halvfabrikat.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_Transfer_Halvfabrikat.Name = "lbl_Transfer_Halvfabrikat";
            this.tlp_Halvfabrikat.SetRowSpan(this.lbl_Transfer_Halvfabrikat, 2);
            this.lbl_Transfer_Halvfabrikat.Size = new System.Drawing.Size(28, 37);
            this.lbl_Transfer_Halvfabrikat.TabIndex = 33;
            this.lbl_Transfer_Halvfabrikat.Text = "→";
            this.lbl_Transfer_Halvfabrikat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Transfer_Halvfabrikat.Click += new System.EventHandler(this.Transfer_Halvfabrikat_Click);
            // 
            // lbl_Halvfabrikat_OD
            // 
            this.lbl_Halvfabrikat_OD.BackColor = System.Drawing.Color.White;
            this.lbl_Halvfabrikat_OD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Halvfabrikat_OD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Halvfabrikat_OD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Halvfabrikat_OD.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.lbl_Halvfabrikat_OD.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Halvfabrikat_OD.Location = new System.Drawing.Point(458, 37);
            this.lbl_Halvfabrikat_OD.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_Halvfabrikat_OD.MaxLength = 5;
            this.lbl_Halvfabrikat_OD.Multiline = true;
            this.lbl_Halvfabrikat_OD.Name = "lbl_Halvfabrikat_OD";
            this.lbl_Halvfabrikat_OD.Size = new System.Drawing.Size(49, 19);
            this.lbl_Halvfabrikat_OD.TabIndex = 916;
            // 
            // lbl_Halvfabrikat_W
            // 
            this.lbl_Halvfabrikat_W.BackColor = System.Drawing.Color.White;
            this.lbl_Halvfabrikat_W.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Halvfabrikat_W.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Halvfabrikat_W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Halvfabrikat_W.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.lbl_Halvfabrikat_W.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Halvfabrikat_W.Location = new System.Drawing.Point(508, 37);
            this.lbl_Halvfabrikat_W.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_Halvfabrikat_W.MaxLength = 5;
            this.lbl_Halvfabrikat_W.Multiline = true;
            this.lbl_Halvfabrikat_W.Name = "lbl_Halvfabrikat_W";
            this.lbl_Halvfabrikat_W.Size = new System.Drawing.Size(54, 19);
            this.lbl_Halvfabrikat_W.TabIndex = 916;
            // 
            // lbl_Halvfabrikat_L
            // 
            this.lbl_Halvfabrikat_L.BackColor = System.Drawing.Color.White;
            this.lbl_Halvfabrikat_L.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Halvfabrikat_L.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Halvfabrikat_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Halvfabrikat_L.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic);
            this.lbl_Halvfabrikat_L.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Halvfabrikat_L.Location = new System.Drawing.Point(563, 37);
            this.lbl_Halvfabrikat_L.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_Halvfabrikat_L.MaxLength = 8;
            this.lbl_Halvfabrikat_L.Multiline = true;
            this.lbl_Halvfabrikat_L.Name = "lbl_Halvfabrikat_L";
            this.lbl_Halvfabrikat_L.Size = new System.Drawing.Size(75, 19);
            this.lbl_Halvfabrikat_L.TabIndex = 916;
            // 
            // label_Empty_9
            // 
            this.label_Empty_9.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_9.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_9.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_9.Location = new System.Drawing.Point(639, 19);
            this.label_Empty_9.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Empty_9.Name = "label_Empty_9";
            this.tlp_Halvfabrikat.SetRowSpan(this.label_Empty_9, 3);
            this.label_Empty_9.Size = new System.Drawing.Size(86, 327);
            this.label_Empty_9.TabIndex = 1007;
            this.label_Empty_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Delete_Halvfabrikat
            // 
            this.lbl_Delete_Halvfabrikat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.lbl_Delete_Halvfabrikat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Delete_Halvfabrikat.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Delete_Halvfabrikat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_Delete_Halvfabrikat.Location = new System.Drawing.Point(0, 57);
            this.lbl_Delete_Halvfabrikat.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_Delete_Halvfabrikat.Name = "lbl_Delete_Halvfabrikat";
            this.lbl_Delete_Halvfabrikat.Size = new System.Drawing.Size(28, 22);
            this.lbl_Delete_Halvfabrikat.TabIndex = 28;
            this.lbl_Delete_Halvfabrikat.Text = "→";
            this.lbl_Delete_Halvfabrikat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Delete_Halvfabrikat.Click += new System.EventHandler(this.Delete_Halvfabrikat_Click);
            // 
            // panel_MaskinParametrar
            // 
            this.panel_MaskinParametrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlp_Main.SetColumnSpan(this.panel_MaskinParametrar, 3);
            this.panel_MaskinParametrar.Controls.Add(this.tlp_Maskinparametrar);
            this.panel_MaskinParametrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_MaskinParametrar.Location = new System.Drawing.Point(0, 84);
            this.panel_MaskinParametrar.Margin = new System.Windows.Forms.Padding(0);
            this.panel_MaskinParametrar.Name = "panel_MaskinParametrar";
            this.panel_MaskinParametrar.Size = new System.Drawing.Size(727, 317);
            this.panel_MaskinParametrar.TabIndex = 906;
            // 
            // tlp_Maskinparametrar
            // 
            this.tlp_Maskinparametrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tlp_Maskinparametrar.ColumnCount = 13;
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tlp_Maskinparametrar.Controls.Add(this.Processkort_Kragning, 0, 0);
            this.tlp_Maskinparametrar.Controls.Add(this.KP_Kragning, 0, 1);
            this.tlp_Maskinparametrar.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.tlp_Maskinparametrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Maskinparametrar.Location = new System.Drawing.Point(0, 0);
            this.tlp_Maskinparametrar.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Maskinparametrar.Name = "tlp_Maskinparametrar";
            this.tlp_Maskinparametrar.RowCount = 3;
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Maskinparametrar.Size = new System.Drawing.Size(725, 315);
            this.tlp_Maskinparametrar.TabIndex = 0;
            // 
            // Processkort_Kragning
            // 
            this.tlp_Maskinparametrar.SetColumnSpan(this.Processkort_Kragning, 13);
            this.Processkort_Kragning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Processkort_Kragning.Location = new System.Drawing.Point(0, 0);
            this.Processkort_Kragning.Margin = new System.Windows.Forms.Padding(0);
            this.Processkort_Kragning.Name = "Processkort_Kragning";
            this.Processkort_Kragning.Size = new System.Drawing.Size(725, 181);
            this.Processkort_Kragning.TabIndex = 1009;
            // 
            // KP_Kragning
            // 
            this.KP_Kragning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tlp_Maskinparametrar.SetColumnSpan(this.KP_Kragning, 13);
            this.KP_Kragning.Cursor = System.Windows.Forms.Cursors.Default;
            this.KP_Kragning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KP_Kragning.Location = new System.Drawing.Point(0, 181);
            this.KP_Kragning.Margin = new System.Windows.Forms.Padding(0);
            this.KP_Kragning.Name = "KP_Kragning";
            this.tlp_Maskinparametrar.SetRowSpan(this.KP_Kragning, 2);
            this.KP_Kragning.Size = new System.Drawing.Size(725, 134);
            this.KP_Kragning.TabIndex = 1010;
            // 
            // panel_ProduktInformation
            // 
            this.panel_ProduktInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlp_Main.SetColumnSpan(this.panel_ProduktInformation, 3);
            this.panel_ProduktInformation.Controls.Add(this.tlp_ProduktInformation);
            this.panel_ProduktInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ProduktInformation.Location = new System.Drawing.Point(0, 0);
            this.panel_ProduktInformation.Margin = new System.Windows.Forms.Padding(0);
            this.panel_ProduktInformation.Name = "panel_ProduktInformation";
            this.panel_ProduktInformation.Size = new System.Drawing.Size(727, 84);
            this.panel_ProduktInformation.TabIndex = 131;
            // 
            // tlp_ProduktInformation
            // 
            this.tlp_ProduktInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tlp_ProduktInformation.ColumnCount = 5;
            this.tlp_ProduktInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tlp_ProduktInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlp_ProduktInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tlp_ProduktInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlp_ProduktInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tlp_ProduktInformation.Controls.Add(this.lbl_Benämning, 1, 1);
            this.tlp_ProduktInformation.Controls.Add(this.label_Benämning, 1, 0);
            this.tlp_ProduktInformation.Controls.Add(this.label_Påse_Spole, 3, 2);
            this.tlp_ProduktInformation.Controls.Add(this.ProdType, 0, 3);
            this.tlp_ProduktInformation.Controls.Add(this.lbl_OrderNr, 4, 0);
            this.tlp_ProduktInformation.Controls.Add(this.lbl_ArtikelNr, 4, 1);
            this.tlp_ProduktInformation.Controls.Add(this.label_Kund, 0, 0);
            this.tlp_ProduktInformation.Controls.Add(this.label_ProdType, 0, 2);
            this.tlp_ProduktInformation.Controls.Add(this.label_ArtikelNr, 3, 1);
            this.tlp_ProduktInformation.Controls.Add(this.label_Datum, 1, 2);
            this.tlp_ProduktInformation.Controls.Add(this.label_OrderNr, 3, 0);
            this.tlp_ProduktInformation.Controls.Add(this.lbl_Customer, 0, 1);
            this.tlp_ProduktInformation.Controls.Add(this.lbl_LC_Date, 1, 3);
            this.tlp_ProduktInformation.Controls.Add(this.label_Namn, 2, 2);
            this.tlp_ProduktInformation.Controls.Add(this.Påse_Spole, 3, 3);
            this.tlp_ProduktInformation.Controls.Add(this.Name_Start, 2, 3);
            this.tlp_ProduktInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_ProduktInformation.Location = new System.Drawing.Point(0, 0);
            this.tlp_ProduktInformation.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_ProduktInformation.Name = "tlp_ProduktInformation";
            this.tlp_ProduktInformation.RowCount = 4;
            this.tlp_ProduktInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_ProduktInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_ProduktInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlp_ProduktInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlp_ProduktInformation.Size = new System.Drawing.Size(725, 82);
            this.tlp_ProduktInformation.TabIndex = 0;
            // 
            // lbl_Benämning
            // 
            this.lbl_Benämning.BackColor = System.Drawing.Color.White;
            this.tlp_ProduktInformation.SetColumnSpan(this.lbl_Benämning, 2);
            this.lbl_Benämning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Benämning.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.lbl_Benämning.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Benämning.Location = new System.Drawing.Point(223, 20);
            this.lbl_Benämning.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.lbl_Benämning.Name = "lbl_Benämning";
            this.lbl_Benämning.Size = new System.Drawing.Size(278, 19);
            this.lbl_Benämning.TabIndex = 916;
            this.lbl_Benämning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Benämning
            // 
            this.label_Benämning.BackColor = System.Drawing.Color.White;
            this.tlp_ProduktInformation.SetColumnSpan(this.label_Benämning, 2);
            this.label_Benämning.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Benämning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Benämning.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Benämning.ForeColor = System.Drawing.Color.Black;
            this.label_Benämning.Location = new System.Drawing.Point(223, 0);
            this.label_Benämning.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Benämning.Name = "label_Benämning";
            this.label_Benämning.Size = new System.Drawing.Size(278, 20);
            this.label_Benämning.TabIndex = 915;
            this.label_Benämning.Text = "Benämning";
            this.label_Benämning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Påse_Spole
            // 
            this.label_Påse_Spole.BackColor = System.Drawing.Color.White;
            this.tlp_ProduktInformation.SetColumnSpan(this.label_Påse_Spole, 2);
            this.label_Påse_Spole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Påse_Spole.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Påse_Spole.ForeColor = System.Drawing.Color.Black;
            this.label_Påse_Spole.Location = new System.Drawing.Point(502, 40);
            this.label_Påse_Spole.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Påse_Spole.Name = "label_Påse_Spole";
            this.label_Påse_Spole.Size = new System.Drawing.Size(223, 14);
            this.label_Påse_Spole.TabIndex = 908;
            this.label_Påse_Spole.Text = "Från påse/spole nr";
            this.label_Påse_Spole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProdType
            // 
            this.ProdType.BackColor = System.Drawing.Color.White;
            this.ProdType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProdType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ProdType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProdType.Enabled = false;
            this.ProdType.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ProdType.ForeColor = System.Drawing.Color.Gray;
            this.ProdType.Location = new System.Drawing.Point(0, 54);
            this.ProdType.Margin = new System.Windows.Forms.Padding(0);
            this.ProdType.Multiline = true;
            this.ProdType.Name = "ProdType";
            this.ProdType.Size = new System.Drawing.Size(222, 28);
            this.ProdType.TabIndex = 808;
            this.ProdType.WordWrap = false;
            // 
            // lbl_OrderNr
            // 
            this.lbl_OrderNr.AutoSize = true;
            this.lbl_OrderNr.BackColor = System.Drawing.Color.White;
            this.lbl_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderNr.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.lbl_OrderNr.ForeColor = System.Drawing.Color.Gray;
            this.lbl_OrderNr.Location = new System.Drawing.Point(549, 0);
            this.lbl_OrderNr.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_OrderNr.Name = "lbl_OrderNr";
            this.lbl_OrderNr.Size = new System.Drawing.Size(176, 20);
            this.lbl_OrderNr.TabIndex = 135;
            this.lbl_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_ArtikelNr
            // 
            this.lbl_ArtikelNr.AutoSize = true;
            this.lbl_ArtikelNr.BackColor = System.Drawing.Color.White;
            this.lbl_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ArtikelNr.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.lbl_ArtikelNr.ForeColor = System.Drawing.Color.Gray;
            this.lbl_ArtikelNr.Location = new System.Drawing.Point(549, 20);
            this.lbl_ArtikelNr.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_ArtikelNr.Name = "lbl_ArtikelNr";
            this.lbl_ArtikelNr.Size = new System.Drawing.Size(176, 19);
            this.lbl_ArtikelNr.TabIndex = 134;
            this.lbl_ArtikelNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Kund
            // 
            this.label_Kund.BackColor = System.Drawing.Color.White;
            this.label_Kund.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Kund.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Kund.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Kund.ForeColor = System.Drawing.Color.Black;
            this.label_Kund.Location = new System.Drawing.Point(0, 0);
            this.label_Kund.Margin = new System.Windows.Forms.Padding(0);
            this.label_Kund.Name = "label_Kund";
            this.label_Kund.Size = new System.Drawing.Size(222, 20);
            this.label_Kund.TabIndex = 128;
            this.label_Kund.Text = "Kund:";
            this.label_Kund.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ProdType
            // 
            this.label_ProdType.BackColor = System.Drawing.Color.White;
            this.label_ProdType.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_ProdType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ProdType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProdType.ForeColor = System.Drawing.Color.Black;
            this.label_ProdType.Location = new System.Drawing.Point(0, 40);
            this.label_ProdType.Margin = new System.Windows.Forms.Padding(0);
            this.label_ProdType.Name = "label_ProdType";
            this.label_ProdType.Size = new System.Drawing.Size(222, 14);
            this.label_ProdType.TabIndex = 129;
            this.label_ProdType.Text = "ProduktTyp";
            this.label_ProdType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ArtikelNr
            // 
            this.label_ArtikelNr.BackColor = System.Drawing.Color.White;
            this.label_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ArtikelNr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ArtikelNr.ForeColor = System.Drawing.Color.Black;
            this.label_ArtikelNr.Location = new System.Drawing.Point(502, 20);
            this.label_ArtikelNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_ArtikelNr.Name = "label_ArtikelNr";
            this.label_ArtikelNr.Size = new System.Drawing.Size(47, 19);
            this.label_ArtikelNr.TabIndex = 130;
            this.label_ArtikelNr.Text = "Art. nr.";
            this.label_ArtikelNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Datum
            // 
            this.label_Datum.BackColor = System.Drawing.Color.White;
            this.label_Datum.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Datum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Datum.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Datum.ForeColor = System.Drawing.Color.Black;
            this.label_Datum.Location = new System.Drawing.Point(223, 40);
            this.label_Datum.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Datum.Name = "label_Datum";
            this.label_Datum.Size = new System.Drawing.Size(89, 14);
            this.label_Datum.TabIndex = 130;
            this.label_Datum.Text = "Datum";
            this.label_Datum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr
            // 
            this.label_OrderNr.BackColor = System.Drawing.Color.White;
            this.label_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OrderNr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OrderNr.ForeColor = System.Drawing.Color.Black;
            this.label_OrderNr.Location = new System.Drawing.Point(502, 0);
            this.label_OrderNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_OrderNr.Name = "label_OrderNr";
            this.label_OrderNr.Size = new System.Drawing.Size(47, 20);
            this.label_OrderNr.TabIndex = 130;
            this.label_OrderNr.Text = "T.O. nr";
            this.label_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Customer
            // 
            this.lbl_Customer.AutoSize = true;
            this.lbl_Customer.BackColor = System.Drawing.Color.White;
            this.lbl_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Customer.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.lbl_Customer.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Customer.Location = new System.Drawing.Point(0, 20);
            this.lbl_Customer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_Customer.Name = "lbl_Customer";
            this.lbl_Customer.Size = new System.Drawing.Size(222, 19);
            this.lbl_Customer.TabIndex = 132;
            // 
            // lbl_LC_Date
            // 
            this.lbl_LC_Date.BackColor = System.Drawing.Color.White;
            this.lbl_LC_Date.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_LC_Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_LC_Date.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lbl_LC_Date.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_LC_Date.Location = new System.Drawing.Point(223, 54);
            this.lbl_LC_Date.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_LC_Date.Name = "lbl_LC_Date";
            this.lbl_LC_Date.Size = new System.Drawing.Size(89, 28);
            this.lbl_LC_Date.TabIndex = 914;
            this.lbl_LC_Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Namn
            // 
            this.label_Namn.BackColor = System.Drawing.Color.White;
            this.label_Namn.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Namn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Namn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Namn.ForeColor = System.Drawing.Color.Black;
            this.label_Namn.Location = new System.Drawing.Point(313, 40);
            this.label_Namn.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_Namn.Name = "label_Namn";
            this.label_Namn.Size = new System.Drawing.Size(188, 14);
            this.label_Namn.TabIndex = 917;
            this.label_Namn.Text = "Namn";
            this.label_Namn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Påse_Spole
            // 
            this.Påse_Spole.BackColor = System.Drawing.Color.White;
            this.Påse_Spole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlp_ProduktInformation.SetColumnSpan(this.Påse_Spole, 2);
            this.Påse_Spole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Påse_Spole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Påse_Spole.Enabled = false;
            this.Påse_Spole.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.Påse_Spole.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Påse_Spole.Location = new System.Drawing.Point(502, 54);
            this.Påse_Spole.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.Påse_Spole.Multiline = true;
            this.Påse_Spole.Name = "Påse_Spole";
            this.Påse_Spole.Size = new System.Drawing.Size(223, 28);
            this.Påse_Spole.TabIndex = 909;
            this.Påse_Spole.WordWrap = false;
            this.Påse_Spole.TextChanged += new System.EventHandler(this.Påse_Spole_TextChanged);
            this.Påse_Spole.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Only_Decimals_KeyPress);
            // 
            // Name_Start
            // 
            this.Name_Start.BackColor = System.Drawing.Color.White;
            this.Name_Start.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name_Start.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.Name_Start.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Name_Start.Location = new System.Drawing.Point(313, 54);
            this.Name_Start.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.Name_Start.Name = "Name_Start";
            this.Name_Start.Size = new System.Drawing.Size(188, 28);
            this.Name_Start.TabIndex = 914;
            this.Name_Start.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainProtocol_Kragning_TEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "MainProtocol_Kragning_TEF";
            this.Size = new System.Drawing.Size(727, 749);
            this.tlp_Main.ResumeLayout(false);
            this.panel_Halvfabrikat.ResumeLayout(false);
            this.tlp_Halvfabrikat.ResumeLayout(false);
            this.tlp_Halvfabrikat.PerformLayout();
            this.panel_Halvfabrikat_OrderNr.ResumeLayout(false);
            this.panel_Halvfabrikat_ArtikelNr.ResumeLayout(false);
            this.panel_Halvfabrikat_Typ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Halvfabrikat)).EndInit();
            this.panel_MaskinParametrar.ResumeLayout(false);
            this.tlp_Maskinparametrar.ResumeLayout(false);
            this.panel_ProduktInformation.ResumeLayout(false);
            this.tlp_ProduktInformation.ResumeLayout(false);
            this.tlp_ProduktInformation.PerformLayout();
            this.ResumeLayout(false);

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
        private DataGridViewTextBoxColumn Halvfabrikat_Slang;
        private DataGridViewTextBoxColumn Halvfabrikat_ArtikelNr;
        private DataGridViewTextBoxColumn Halvfabrikat_OrderNr;
        private DataGridViewTextBoxColumn Halvfabrikat_ID;
        private DataGridViewTextBoxColumn Halvfabrikat_OD;
        private DataGridViewTextBoxColumn Halvfabrikat_W;
        private DataGridViewTextBoxColumn Halvfabrikat_Längd;
        private TextBox lbl_Halvfabrikat_OD;
        private TextBox lbl_Halvfabrikat_W;
        private TextBox lbl_Halvfabrikat_L;
        private Label label_Empty_9;
        public TextBox Påse_Spole;
        public Label lbl_Transfer_Halvfabrikat;
        public Label lbl_Delete_Halvfabrikat;
        public KP_Kragning KP_Kragning;
        public Label lbl_OrderNr;
    }
}
