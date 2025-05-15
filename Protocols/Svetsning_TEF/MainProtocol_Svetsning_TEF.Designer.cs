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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Halvfabrikat = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Halvfabrikat_ID = new System.Windows.Forms.TextBox();
            this.panel_Halvfabrikat_OrderNr = new System.Windows.Forms.Panel();
            this.cb_Halvfabrikat_BatchNr = new System.Windows.Forms.ComboBox();
            this.panel_Halvfabrikat_ArtikelNr = new System.Windows.Forms.Panel();
            this.cb_Halvfabrikat_ArtikelNr = new System.Windows.Forms.ComboBox();
            this.panel_Halvfabrikat_Typ = new System.Windows.Forms.Panel();
            this.cb_Halvfabrikat_Typ = new System.Windows.Forms.ComboBox();
            this.label_Halvfabrikat_Längd = new System.Windows.Forms.Label();
            this.label_Halvfabrikat_W = new System.Windows.Forms.Label();
            this.label_Halvfabrikat_OD = new System.Windows.Forms.Label();
            this.label_Halvfabrikat_BatchNr = new System.Windows.Forms.Label();
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
            this.lbl_Discard_Halvfabrikat = new System.Windows.Forms.Label();
            this.tlp_Produktion_Svetsning = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Edit_Row_Produktion = new System.Windows.Forms.Label();
            this.label_Inledande = new System.Windows.Forms.Label();
            this.panel_Produktion_OrderNr = new System.Windows.Forms.Panel();
            this.cb_Inledande_BatchNr = new System.Windows.Forms.ComboBox();
            this.label_Inledande_UppmättVidProduktionsStart = new System.Windows.Forms.Label();
            this.label_Inledande_Påse_Nr = new System.Windows.Forms.Label();
            this.label_Inledande_BatchNr = new System.Windows.Forms.Label();
            this.label_Inledande_Uppmätt_Pinn = new System.Windows.Forms.Label();
            this.label_Inledande_Skärmat = new System.Windows.Forms.Label();
            this.label_Produktion_Svetsning = new System.Windows.Forms.Label();
            this.tb_Inledande_Påse = new System.Windows.Forms.TextBox();
            this.label_Inspektion = new System.Windows.Forms.Label();
            this.label_Inledande_ID = new System.Windows.Forms.Label();
            this.label_Inledande_OD = new System.Windows.Forms.Label();
            this.label_Inledande_Längd = new System.Windows.Forms.Label();
            this.label_Inspektion_VisuellTest = new System.Windows.Forms.Label();
            this.label_Inspektion_Utsida = new System.Windows.Forms.Label();
            this.label_Inspektion_Insida = new System.Windows.Forms.Label();
            this.label_Inspektion_Datum = new System.Windows.Forms.Label();
            this.label_Inspektion_Tid = new System.Windows.Forms.Label();
            this.label_Inspektion_AnstNr = new System.Windows.Forms.Label();
            this.label_Inspektion_Sign = new System.Windows.Forms.Label();
            this.lbl_Transfer_Produktion = new System.Windows.Forms.Label();
            this.dgv_Produktion = new System.Windows.Forms.DataGridView();
            this.OrderNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Påse_Nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uppmätt_Pinn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Längd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Utsida = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Insida = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnstNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Produktion_TempID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_Empty_5 = new System.Windows.Forms.Label();
            this.tb_InledandeUppmättPinne = new System.Windows.Forms.TextBox();
            this.tb_InledandeID = new System.Windows.Forms.TextBox();
            this.tb_InledandeOD = new System.Windows.Forms.TextBox();
            this.tb_InledandeLängd = new System.Windows.Forms.TextBox();
            this.label_Empty_6 = new System.Windows.Forms.Label();
            this.chb_InspektionUtsida = new System.Windows.Forms.CheckBox();
            this.chb_InspektionInsida = new System.Windows.Forms.CheckBox();
            this.lbl_Discard_Row_Produktion = new System.Windows.Forms.Label();
            this.tlp_Maskinparametrar = new System.Windows.Forms.TableLayoutPanel();
            this.tb_VärmebackarHål = new System.Windows.Forms.TextBox();
            this.dgv_MaskinParametrar = new System.Windows.Forms.DataGridView();
            this.dgv_Maskinparametrar_Svets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Tid_Förvärme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Svetsförflyttning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Tid_Bindvärme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Tid_Kylluft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Temperatur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Stål = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Pinne_PTFE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Värmebackar_Bredd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Värmebackar_Hål = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Tid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_AnstNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Maskinparametrar_Sign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_VärmebackarBredd = new System.Windows.Forms.TextBox();
            this.lbl_Transfer_Maskinparametrar = new System.Windows.Forms.Label();
            this.tb_PinneODPTFE = new System.Windows.Forms.TextBox();
            this.lbl_Kassera_Maskinparameter = new System.Windows.Forms.Label();
            this.tb_PinneODStål = new System.Windows.Forms.TextBox();
            this.tb_Svets = new System.Windows.Forms.TextBox();
            this.tb_Temperatur = new System.Windows.Forms.TextBox();
            this.tb_TidFörvärme = new System.Windows.Forms.TextBox();
            this.tb_TidKylluft = new System.Windows.Forms.TextBox();
            this.tb_TidBindvärme = new System.Windows.Forms.TextBox();
            this.tb_Svetsförflyttning = new System.Windows.Forms.TextBox();
            this.PC_Svetsning_TEF = new DigitalProductionProgram.Protocols.Svetsning_TEF.PC_Svetsning_TEF();
            this.MainInfo = new DigitalProductionProgram.Protocols.MainInfo.MainInfo_Description_Prodtype();
            this.tlp_Main.SuspendLayout();
            this.tlp_Halvfabrikat.SuspendLayout();
            this.panel_Halvfabrikat_OrderNr.SuspendLayout();
            this.panel_Halvfabrikat_ArtikelNr.SuspendLayout();
            this.panel_Halvfabrikat_Typ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Halvfabrikat)).BeginInit();
            this.tlp_Produktion_Svetsning.SuspendLayout();
            this.panel_Produktion_OrderNr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Produktion)).BeginInit();
            this.tlp_Maskinparametrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MaskinParametrar)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 834F));
            this.tlp_Main.Controls.Add(this.tlp_Halvfabrikat, 0, 3);
            this.tlp_Main.Controls.Add(this.tlp_Produktion_Svetsning, 0, 2);
            this.tlp_Main.Controls.Add(this.tlp_Maskinparametrar, 0, 1);
            this.tlp_Main.Controls.Add(this.MainInfo, 0, 0);
            this.tlp_Main.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 4;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 239F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlp_Main.Size = new System.Drawing.Size(834, 837);
            this.tlp_Main.TabIndex = 1;
            // 
            // tlp_Halvfabrikat
            // 
            this.tlp_Halvfabrikat.BackColor = System.Drawing.Color.Black;
            this.tlp_Halvfabrikat.ColumnCount = 9;
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlp_Halvfabrikat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tlp_Halvfabrikat.Controls.Add(this.lbl_Halvfabrikat_ID, 4, 2);
            this.tlp_Halvfabrikat.Controls.Add(this.panel_Halvfabrikat_OrderNr, 3, 2);
            this.tlp_Halvfabrikat.Controls.Add(this.panel_Halvfabrikat_ArtikelNr, 2, 2);
            this.tlp_Halvfabrikat.Controls.Add(this.panel_Halvfabrikat_Typ, 1, 2);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Halvfabrikat_Längd, 7, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Halvfabrikat_W, 6, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Halvfabrikat_OD, 5, 1);
            this.tlp_Halvfabrikat.Controls.Add(this.label_Halvfabrikat_BatchNr, 3, 1);
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
            this.tlp_Halvfabrikat.Controls.Add(this.lbl_Discard_Halvfabrikat, 0, 3);
            this.tlp_Halvfabrikat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Halvfabrikat.Location = new System.Drawing.Point(1, 532);
            this.tlp_Halvfabrikat.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.tlp_Halvfabrikat.Name = "tlp_Halvfabrikat";
            this.tlp_Halvfabrikat.RowCount = 5;
            this.tlp_Halvfabrikat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Halvfabrikat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tlp_Halvfabrikat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tlp_Halvfabrikat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlp_Halvfabrikat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlp_Halvfabrikat.Size = new System.Drawing.Size(832, 305);
            this.tlp_Halvfabrikat.TabIndex = 1025;
            // 
            // lbl_Halvfabrikat_ID
            // 
            this.lbl_Halvfabrikat_ID.BackColor = System.Drawing.Color.White;
            this.lbl_Halvfabrikat_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Halvfabrikat_ID.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Halvfabrikat_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Halvfabrikat_ID.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic);
            this.lbl_Halvfabrikat_ID.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Halvfabrikat_ID.Location = new System.Drawing.Point(408, 37);
            this.lbl_Halvfabrikat_ID.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_Halvfabrikat_ID.MaxLength = 6;
            this.lbl_Halvfabrikat_ID.Multiline = true;
            this.lbl_Halvfabrikat_ID.Name = "lbl_Halvfabrikat_ID";
            this.lbl_Halvfabrikat_ID.Size = new System.Drawing.Size(49, 19);
            this.lbl_Halvfabrikat_ID.TabIndex = 916;
            // 
            // panel_Halvfabrikat_OrderNr
            // 
            this.panel_Halvfabrikat_OrderNr.BackColor = System.Drawing.Color.White;
            this.panel_Halvfabrikat_OrderNr.Controls.Add(this.cb_Halvfabrikat_BatchNr);
            this.panel_Halvfabrikat_OrderNr.ForeColor = System.Drawing.Color.Black;
            this.panel_Halvfabrikat_OrderNr.Location = new System.Drawing.Point(244, 37);
            this.panel_Halvfabrikat_OrderNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.panel_Halvfabrikat_OrderNr.Name = "panel_Halvfabrikat_OrderNr";
            this.panel_Halvfabrikat_OrderNr.Size = new System.Drawing.Size(163, 19);
            this.panel_Halvfabrikat_OrderNr.TabIndex = 920;
            // 
            // cb_Halvfabrikat_BatchNr
            // 
            this.cb_Halvfabrikat_BatchNr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Halvfabrikat_BatchNr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Halvfabrikat_BatchNr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Halvfabrikat_BatchNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Halvfabrikat_BatchNr.DropDownHeight = 130;
            this.cb_Halvfabrikat_BatchNr.DropDownWidth = 130;
            this.cb_Halvfabrikat_BatchNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Halvfabrikat_BatchNr.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.cb_Halvfabrikat_BatchNr.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cb_Halvfabrikat_BatchNr.FormattingEnabled = true;
            this.cb_Halvfabrikat_BatchNr.IntegralHeight = false;
            this.cb_Halvfabrikat_BatchNr.Location = new System.Drawing.Point(0, 0);
            this.cb_Halvfabrikat_BatchNr.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Halvfabrikat_BatchNr.Name = "cb_Halvfabrikat_BatchNr";
            this.cb_Halvfabrikat_BatchNr.Size = new System.Drawing.Size(163, 22);
            this.cb_Halvfabrikat_BatchNr.TabIndex = 32;
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
            this.cb_Halvfabrikat_ArtikelNr.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.cb_Halvfabrikat_ArtikelNr.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cb_Halvfabrikat_ArtikelNr.FormattingEnabled = true;
            this.cb_Halvfabrikat_ArtikelNr.IntegralHeight = false;
            this.cb_Halvfabrikat_ArtikelNr.Location = new System.Drawing.Point(0, 0);
            this.cb_Halvfabrikat_ArtikelNr.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Halvfabrikat_ArtikelNr.Name = "cb_Halvfabrikat_ArtikelNr";
            this.cb_Halvfabrikat_ArtikelNr.Size = new System.Drawing.Size(105, 22);
            this.cb_Halvfabrikat_ArtikelNr.TabIndex = 31;
            this.cb_Halvfabrikat_ArtikelNr.TextChanged += new System.EventHandler(this.Halvfabrikat_ArtikelNr_TextChanged);
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
            this.cb_Halvfabrikat_Typ.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.cb_Halvfabrikat_Typ.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cb_Halvfabrikat_Typ.FormattingEnabled = true;
            this.cb_Halvfabrikat_Typ.IntegralHeight = false;
            this.cb_Halvfabrikat_Typ.Items.AddRange(new object[] {
            "Skärmad",
            "Mjuk",
            "Formar"});
            this.cb_Halvfabrikat_Typ.Location = new System.Drawing.Point(0, 0);
            this.cb_Halvfabrikat_Typ.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Halvfabrikat_Typ.Name = "cb_Halvfabrikat_Typ";
            this.cb_Halvfabrikat_Typ.Size = new System.Drawing.Size(108, 22);
            this.cb_Halvfabrikat_Typ.TabIndex = 30;
            // 
            // label_Halvfabrikat_Längd
            // 
            this.label_Halvfabrikat_Längd.BackColor = System.Drawing.Color.White;
            this.label_Halvfabrikat_Längd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Halvfabrikat_Längd.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Halvfabrikat_Längd.ForeColor = System.Drawing.Color.Black;
            this.label_Halvfabrikat_Längd.Location = new System.Drawing.Point(558, 19);
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
            this.label_Halvfabrikat_W.Size = new System.Drawing.Size(49, 17);
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
            // label_Halvfabrikat_BatchNr
            // 
            this.label_Halvfabrikat_BatchNr.BackColor = System.Drawing.Color.White;
            this.label_Halvfabrikat_BatchNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Halvfabrikat_BatchNr.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Halvfabrikat_BatchNr.ForeColor = System.Drawing.Color.Black;
            this.label_Halvfabrikat_BatchNr.Location = new System.Drawing.Point(244, 19);
            this.label_Halvfabrikat_BatchNr.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Halvfabrikat_BatchNr.Name = "label_Halvfabrikat_BatchNr";
            this.label_Halvfabrikat_BatchNr.Size = new System.Drawing.Size(163, 17);
            this.label_Halvfabrikat_BatchNr.TabIndex = 908;
            this.label_Halvfabrikat_BatchNr.Text = "BatchNr";
            this.label_Halvfabrikat_BatchNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label_Halvfabrikat.Size = new System.Drawing.Size(832, 18);
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
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
            this.tlp_Halvfabrikat.SetRowSpan(this.dgv_Halvfabrikat, 2);
            this.dgv_Halvfabrikat.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Halvfabrikat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Halvfabrikat.Size = new System.Drawing.Size(604, 247);
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
            this.Halvfabrikat_W.Width = 50;
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
            this.lbl_Transfer_Halvfabrikat.Click += new System.EventHandler(this.Save_Halvfabrikat_Click);
            // 
            // lbl_Halvfabrikat_OD
            // 
            this.lbl_Halvfabrikat_OD.BackColor = System.Drawing.Color.White;
            this.lbl_Halvfabrikat_OD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Halvfabrikat_OD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Halvfabrikat_OD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Halvfabrikat_OD.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic);
            this.lbl_Halvfabrikat_OD.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Halvfabrikat_OD.Location = new System.Drawing.Point(458, 37);
            this.lbl_Halvfabrikat_OD.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_Halvfabrikat_OD.MaxLength = 6;
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
            this.lbl_Halvfabrikat_W.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic);
            this.lbl_Halvfabrikat_W.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Halvfabrikat_W.Location = new System.Drawing.Point(508, 37);
            this.lbl_Halvfabrikat_W.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lbl_Halvfabrikat_W.MaxLength = 5;
            this.lbl_Halvfabrikat_W.Multiline = true;
            this.lbl_Halvfabrikat_W.Name = "lbl_Halvfabrikat_W";
            this.lbl_Halvfabrikat_W.Size = new System.Drawing.Size(49, 19);
            this.lbl_Halvfabrikat_W.TabIndex = 916;
            // 
            // lbl_Halvfabrikat_L
            // 
            this.lbl_Halvfabrikat_L.BackColor = System.Drawing.Color.White;
            this.lbl_Halvfabrikat_L.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Halvfabrikat_L.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbl_Halvfabrikat_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Halvfabrikat_L.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic);
            this.lbl_Halvfabrikat_L.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Halvfabrikat_L.Location = new System.Drawing.Point(558, 37);
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
            this.label_Empty_9.Location = new System.Drawing.Point(634, 19);
            this.label_Empty_9.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Empty_9.Name = "label_Empty_9";
            this.tlp_Halvfabrikat.SetRowSpan(this.label_Empty_9, 4);
            this.label_Empty_9.Size = new System.Drawing.Size(198, 286);
            this.label_Empty_9.TabIndex = 1007;
            this.label_Empty_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Discard_Halvfabrikat
            // 
            this.lbl_Discard_Halvfabrikat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.lbl_Discard_Halvfabrikat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Discard_Halvfabrikat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Discard_Halvfabrikat.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Discard_Halvfabrikat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_Discard_Halvfabrikat.Location = new System.Drawing.Point(0, 57);
            this.lbl_Discard_Halvfabrikat.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_Discard_Halvfabrikat.Name = "lbl_Discard_Halvfabrikat";
            this.lbl_Discard_Halvfabrikat.Size = new System.Drawing.Size(28, 25);
            this.lbl_Discard_Halvfabrikat.TabIndex = 28;
            this.lbl_Discard_Halvfabrikat.Text = "→";
            this.lbl_Discard_Halvfabrikat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Discard_Halvfabrikat.Click += new System.EventHandler(this.Delete_Row_Halvfabrikat_Click);
            // 
            // tlp_Produktion_Svetsning
            // 
            this.tlp_Produktion_Svetsning.BackColor = System.Drawing.Color.Black;
            this.tlp_Produktion_Svetsning.ColumnCount = 13;
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlp_Produktion_Svetsning.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tlp_Produktion_Svetsning.Controls.Add(this.lbl_Edit_Row_Produktion, 0, 6);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inledande, 1, 1);
            this.tlp_Produktion_Svetsning.Controls.Add(this.panel_Produktion_OrderNr, 1, 4);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inledande_UppmättVidProduktionsStart, 4, 2);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inledande_Påse_Nr, 2, 3);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inledande_BatchNr, 1, 3);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inledande_Uppmätt_Pinn, 3, 2);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inledande_Skärmat, 1, 2);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Produktion_Svetsning, 0, 0);
            this.tlp_Produktion_Svetsning.Controls.Add(this.tb_Inledande_Påse, 2, 4);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inspektion, 7, 1);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inledande_ID, 4, 3);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inledande_OD, 5, 3);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inledande_Längd, 6, 3);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inspektion_VisuellTest, 7, 2);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inspektion_Utsida, 7, 3);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inspektion_Insida, 8, 3);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inspektion_Datum, 9, 2);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inspektion_Tid, 10, 2);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inspektion_AnstNr, 11, 2);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Inspektion_Sign, 12, 2);
            this.tlp_Produktion_Svetsning.Controls.Add(this.lbl_Transfer_Produktion, 0, 4);
            this.tlp_Produktion_Svetsning.Controls.Add(this.dgv_Produktion, 1, 5);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Empty_5, 0, 1);
            this.tlp_Produktion_Svetsning.Controls.Add(this.tb_InledandeUppmättPinne, 3, 4);
            this.tlp_Produktion_Svetsning.Controls.Add(this.tb_InledandeID, 4, 4);
            this.tlp_Produktion_Svetsning.Controls.Add(this.tb_InledandeOD, 5, 4);
            this.tlp_Produktion_Svetsning.Controls.Add(this.tb_InledandeLängd, 6, 4);
            this.tlp_Produktion_Svetsning.Controls.Add(this.label_Empty_6, 9, 4);
            this.tlp_Produktion_Svetsning.Controls.Add(this.chb_InspektionUtsida, 7, 4);
            this.tlp_Produktion_Svetsning.Controls.Add(this.chb_InspektionInsida, 8, 4);
            this.tlp_Produktion_Svetsning.Controls.Add(this.lbl_Discard_Row_Produktion, 0, 5);
            this.tlp_Produktion_Svetsning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Produktion_Svetsning.Location = new System.Drawing.Point(0, 285);
            this.tlp_Produktion_Svetsning.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Produktion_Svetsning.Name = "tlp_Produktion_Svetsning";
            this.tlp_Produktion_Svetsning.RowCount = 7;
            this.tlp_Produktion_Svetsning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Produktion_Svetsning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Produktion_Svetsning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_Produktion_Svetsning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlp_Produktion_Svetsning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tlp_Produktion_Svetsning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_Produktion_Svetsning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Produktion_Svetsning.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Produktion_Svetsning.Size = new System.Drawing.Size(834, 246);
            this.tlp_Produktion_Svetsning.TabIndex = 1021;
            // 
            // lbl_Edit_Row_Produktion
            // 
            this.lbl_Edit_Row_Produktion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_Edit_Row_Produktion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Edit_Row_Produktion.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Edit_Row_Produktion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(101)))), ((int)(((byte)(0)))));
            this.lbl_Edit_Row_Produktion.Location = new System.Drawing.Point(1, 158);
            this.lbl_Edit_Row_Produktion.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.lbl_Edit_Row_Produktion.Name = "lbl_Edit_Row_Produktion";
            this.lbl_Edit_Row_Produktion.Size = new System.Drawing.Size(28, 23);
            this.lbl_Edit_Row_Produktion.TabIndex = 1029;
            this.lbl_Edit_Row_Produktion.Text = "→";
            this.lbl_Edit_Row_Produktion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Edit_Row_Produktion.Click += new System.EventHandler(this.Edit_Row_Produktion_Click);
            // 
            // label_Inledande
            // 
            this.label_Inledande.BackColor = System.Drawing.Color.White;
            this.tlp_Produktion_Svetsning.SetColumnSpan(this.label_Inledande, 6);
            this.label_Inledande.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inledande.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Inledande.ForeColor = System.Drawing.Color.Black;
            this.label_Inledande.Location = new System.Drawing.Point(30, 22);
            this.label_Inledande.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_Inledande.Name = "label_Inledande";
            this.label_Inledande.Size = new System.Drawing.Size(381, 19);
            this.label_Inledande.TabIndex = 1025;
            this.label_Inledande.Text = "Inledande";
            this.label_Inledande.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_Produktion_OrderNr
            // 
            this.panel_Produktion_OrderNr.BackColor = System.Drawing.Color.White;
            this.panel_Produktion_OrderNr.Controls.Add(this.cb_Inledande_BatchNr);
            this.panel_Produktion_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Produktion_OrderNr.ForeColor = System.Drawing.Color.Black;
            this.panel_Produktion_OrderNr.Location = new System.Drawing.Point(30, 114);
            this.panel_Produktion_OrderNr.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.panel_Produktion_OrderNr.Name = "panel_Produktion_OrderNr";
            this.panel_Produktion_OrderNr.Size = new System.Drawing.Size(82, 20);
            this.panel_Produktion_OrderNr.TabIndex = 920;
            // 
            // cb_Inledande_BatchNr
            // 
            this.cb_Inledande_BatchNr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Inledande_BatchNr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Inledande_BatchNr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Inledande_BatchNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Inledande_BatchNr.DropDownHeight = 130;
            this.cb_Inledande_BatchNr.DropDownWidth = 130;
            this.cb_Inledande_BatchNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Inledande_BatchNr.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.cb_Inledande_BatchNr.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cb_Inledande_BatchNr.FormattingEnabled = true;
            this.cb_Inledande_BatchNr.IntegralHeight = false;
            this.cb_Inledande_BatchNr.Location = new System.Drawing.Point(0, 0);
            this.cb_Inledande_BatchNr.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Inledande_BatchNr.Name = "cb_Inledande_BatchNr";
            this.cb_Inledande_BatchNr.Size = new System.Drawing.Size(82, 22);
            this.cb_Inledande_BatchNr.TabIndex = 20;
            // 
            // label_Inledande_UppmättVidProduktionsStart
            // 
            this.label_Inledande_UppmättVidProduktionsStart.BackColor = System.Drawing.Color.White;
            this.tlp_Produktion_Svetsning.SetColumnSpan(this.label_Inledande_UppmättVidProduktionsStart, 3);
            this.label_Inledande_UppmättVidProduktionsStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inledande_UppmättVidProduktionsStart.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label_Inledande_UppmättVidProduktionsStart.ForeColor = System.Drawing.Color.Black;
            this.label_Inledande_UppmättVidProduktionsStart.Location = new System.Drawing.Point(214, 42);
            this.label_Inledande_UppmättVidProduktionsStart.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_Inledande_UppmättVidProduktionsStart.Name = "label_Inledande_UppmättVidProduktionsStart";
            this.label_Inledande_UppmättVidProduktionsStart.Size = new System.Drawing.Size(197, 22);
            this.label_Inledande_UppmättVidProduktionsStart.TabIndex = 1024;
            this.label_Inledande_UppmättVidProduktionsStart.Text = "Uppmätt vid produktionsstart";
            this.label_Inledande_UppmättVidProduktionsStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_Påse_Nr
            // 
            this.label_Inledande_Påse_Nr.BackColor = System.Drawing.Color.White;
            this.label_Inledande_Påse_Nr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inledande_Påse_Nr.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.label_Inledande_Påse_Nr.ForeColor = System.Drawing.Color.Black;
            this.label_Inledande_Påse_Nr.Location = new System.Drawing.Point(113, 65);
            this.label_Inledande_Påse_Nr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inledande_Påse_Nr.Name = "label_Inledande_Påse_Nr";
            this.label_Inledande_Påse_Nr.Size = new System.Drawing.Size(40, 47);
            this.label_Inledande_Påse_Nr.TabIndex = 1023;
            this.label_Inledande_Påse_Nr.Text = "Påse Nr";
            this.label_Inledande_Påse_Nr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_BatchNr
            // 
            this.label_Inledande_BatchNr.BackColor = System.Drawing.Color.White;
            this.label_Inledande_BatchNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inledande_BatchNr.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.label_Inledande_BatchNr.ForeColor = System.Drawing.Color.Black;
            this.label_Inledande_BatchNr.Location = new System.Drawing.Point(30, 65);
            this.label_Inledande_BatchNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inledande_BatchNr.Name = "label_Inledande_BatchNr";
            this.label_Inledande_BatchNr.Size = new System.Drawing.Size(82, 47);
            this.label_Inledande_BatchNr.TabIndex = 1022;
            this.label_Inledande_BatchNr.Text = "BatchNr";
            this.label_Inledande_BatchNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_Uppmätt_Pinn
            // 
            this.label_Inledande_Uppmätt_Pinn.BackColor = System.Drawing.Color.White;
            this.label_Inledande_Uppmätt_Pinn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inledande_Uppmätt_Pinn.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.label_Inledande_Uppmätt_Pinn.ForeColor = System.Drawing.Color.Black;
            this.label_Inledande_Uppmätt_Pinn.Location = new System.Drawing.Point(154, 42);
            this.label_Inledande_Uppmätt_Pinn.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inledande_Uppmätt_Pinn.Name = "label_Inledande_Uppmätt_Pinn";
            this.tlp_Produktion_Svetsning.SetRowSpan(this.label_Inledande_Uppmätt_Pinn, 2);
            this.label_Inledande_Uppmätt_Pinn.Size = new System.Drawing.Size(59, 70);
            this.label_Inledande_Uppmätt_Pinn.TabIndex = 1021;
            this.label_Inledande_Uppmätt_Pinn.Text = "Uppmätt pinne";
            this.label_Inledande_Uppmätt_Pinn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_Skärmat
            // 
            this.label_Inledande_Skärmat.BackColor = System.Drawing.Color.White;
            this.tlp_Produktion_Svetsning.SetColumnSpan(this.label_Inledande_Skärmat, 2);
            this.label_Inledande_Skärmat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inledande_Skärmat.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label_Inledande_Skärmat.ForeColor = System.Drawing.Color.Black;
            this.label_Inledande_Skärmat.Location = new System.Drawing.Point(30, 42);
            this.label_Inledande_Skärmat.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inledande_Skärmat.Name = "label_Inledande_Skärmat";
            this.label_Inledande_Skärmat.Size = new System.Drawing.Size(123, 22);
            this.label_Inledande_Skärmat.TabIndex = 1020;
            this.label_Inledande_Skärmat.Text = "Skärmat";
            this.label_Inledande_Skärmat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Produktion_Svetsning
            // 
            this.label_Produktion_Svetsning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.label_Produktion_Svetsning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlp_Produktion_Svetsning.SetColumnSpan(this.label_Produktion_Svetsning, 13);
            this.label_Produktion_Svetsning.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Produktion_Svetsning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Produktion_Svetsning.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label_Produktion_Svetsning.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_Produktion_Svetsning.Location = new System.Drawing.Point(0, 0);
            this.label_Produktion_Svetsning.Margin = new System.Windows.Forms.Padding(0);
            this.label_Produktion_Svetsning.Name = "label_Produktion_Svetsning";
            this.label_Produktion_Svetsning.Size = new System.Drawing.Size(834, 22);
            this.label_Produktion_Svetsning.TabIndex = 908;
            this.label_Produktion_Svetsning.Text = "Produktion/Svetsning";
            this.label_Produktion_Svetsning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_Inledande_Påse
            // 
            this.tb_Inledande_Påse.BackColor = System.Drawing.Color.White;
            this.tb_Inledande_Påse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Inledande_Påse.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Inledande_Påse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Inledande_Påse.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_Inledande_Påse.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Inledande_Påse.Location = new System.Drawing.Point(113, 114);
            this.tb_Inledande_Påse.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Inledande_Påse.Multiline = true;
            this.tb_Inledande_Påse.Name = "tb_Inledande_Påse";
            this.tb_Inledande_Påse.Size = new System.Drawing.Size(40, 20);
            this.tb_Inledande_Påse.TabIndex = 21;
            this.tb_Inledande_Påse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Inledande_Påse.WordWrap = false;
            this.tb_Inledande_Påse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // label_Inspektion
            // 
            this.label_Inspektion.BackColor = System.Drawing.Color.White;
            this.tlp_Produktion_Svetsning.SetColumnSpan(this.label_Inspektion, 6);
            this.label_Inspektion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inspektion.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Inspektion.ForeColor = System.Drawing.Color.Black;
            this.label_Inspektion.Location = new System.Drawing.Point(413, 22);
            this.label_Inspektion.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_Inspektion.Name = "label_Inspektion";
            this.label_Inspektion.Size = new System.Drawing.Size(420, 19);
            this.label_Inspektion.TabIndex = 1019;
            this.label_Inspektion.Text = "Inspektion, färdig svets";
            this.label_Inspektion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Inledande_ID
            // 
            this.label_Inledande_ID.BackColor = System.Drawing.Color.White;
            this.label_Inledande_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inledande_ID.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.label_Inledande_ID.ForeColor = System.Drawing.Color.Black;
            this.label_Inledande_ID.Location = new System.Drawing.Point(214, 65);
            this.label_Inledande_ID.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inledande_ID.Name = "label_Inledande_ID";
            this.label_Inledande_ID.Size = new System.Drawing.Size(60, 47);
            this.label_Inledande_ID.TabIndex = 1026;
            this.label_Inledande_ID.Text = "ID skärmat mm";
            this.label_Inledande_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_OD
            // 
            this.label_Inledande_OD.BackColor = System.Drawing.Color.White;
            this.label_Inledande_OD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inledande_OD.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.label_Inledande_OD.ForeColor = System.Drawing.Color.Black;
            this.label_Inledande_OD.Location = new System.Drawing.Point(275, 65);
            this.label_Inledande_OD.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inledande_OD.Name = "label_Inledande_OD";
            this.label_Inledande_OD.Size = new System.Drawing.Size(60, 47);
            this.label_Inledande_OD.TabIndex = 1026;
            this.label_Inledande_OD.Text = "OD skärmat mm";
            this.label_Inledande_OD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inledande_Längd
            // 
            this.label_Inledande_Längd.BackColor = System.Drawing.Color.White;
            this.label_Inledande_Längd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inledande_Längd.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.label_Inledande_Längd.ForeColor = System.Drawing.Color.Black;
            this.label_Inledande_Längd.Location = new System.Drawing.Point(336, 65);
            this.label_Inledande_Längd.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_Inledande_Längd.Name = "label_Inledande_Längd";
            this.label_Inledande_Längd.Size = new System.Drawing.Size(75, 47);
            this.label_Inledande_Längd.TabIndex = 1026;
            this.label_Inledande_Längd.Text = "Längd skärmat   mm";
            this.label_Inledande_Längd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_VisuellTest
            // 
            this.label_Inspektion_VisuellTest.BackColor = System.Drawing.Color.White;
            this.tlp_Produktion_Svetsning.SetColumnSpan(this.label_Inspektion_VisuellTest, 2);
            this.label_Inspektion_VisuellTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inspektion_VisuellTest.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label_Inspektion_VisuellTest.ForeColor = System.Drawing.Color.Black;
            this.label_Inspektion_VisuellTest.Location = new System.Drawing.Point(413, 42);
            this.label_Inspektion_VisuellTest.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inspektion_VisuellTest.Name = "label_Inspektion_VisuellTest";
            this.label_Inspektion_VisuellTest.Size = new System.Drawing.Size(117, 22);
            this.label_Inspektion_VisuellTest.TabIndex = 1024;
            this.label_Inspektion_VisuellTest.Text = "Visuell test";
            this.label_Inspektion_VisuellTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Utsida
            // 
            this.label_Inspektion_Utsida.BackColor = System.Drawing.Color.White;
            this.label_Inspektion_Utsida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inspektion_Utsida.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.label_Inspektion_Utsida.ForeColor = System.Drawing.Color.Black;
            this.label_Inspektion_Utsida.Location = new System.Drawing.Point(413, 65);
            this.label_Inspektion_Utsida.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inspektion_Utsida.Name = "label_Inspektion_Utsida";
            this.label_Inspektion_Utsida.Size = new System.Drawing.Size(58, 47);
            this.label_Inspektion_Utsida.TabIndex = 1026;
            this.label_Inspektion_Utsida.Text = "Utsida (Ja)";
            this.label_Inspektion_Utsida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Insida
            // 
            this.label_Inspektion_Insida.BackColor = System.Drawing.Color.White;
            this.label_Inspektion_Insida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inspektion_Insida.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Italic);
            this.label_Inspektion_Insida.ForeColor = System.Drawing.Color.Black;
            this.label_Inspektion_Insida.Location = new System.Drawing.Point(472, 65);
            this.label_Inspektion_Insida.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inspektion_Insida.Name = "label_Inspektion_Insida";
            this.label_Inspektion_Insida.Size = new System.Drawing.Size(58, 47);
            this.label_Inspektion_Insida.TabIndex = 1026;
            this.label_Inspektion_Insida.Text = "Insida (Ja)";
            this.label_Inspektion_Insida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Datum
            // 
            this.label_Inspektion_Datum.BackColor = System.Drawing.Color.White;
            this.label_Inspektion_Datum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inspektion_Datum.Font = new System.Drawing.Font("Arial", 8.5F);
            this.label_Inspektion_Datum.ForeColor = System.Drawing.Color.Black;
            this.label_Inspektion_Datum.Location = new System.Drawing.Point(531, 42);
            this.label_Inspektion_Datum.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inspektion_Datum.Name = "label_Inspektion_Datum";
            this.tlp_Produktion_Svetsning.SetRowSpan(this.label_Inspektion_Datum, 2);
            this.label_Inspektion_Datum.Size = new System.Drawing.Size(86, 70);
            this.label_Inspektion_Datum.TabIndex = 1024;
            this.label_Inspektion_Datum.Text = "Datum";
            this.label_Inspektion_Datum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Tid
            // 
            this.label_Inspektion_Tid.BackColor = System.Drawing.Color.White;
            this.label_Inspektion_Tid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inspektion_Tid.Font = new System.Drawing.Font("Arial", 8.5F);
            this.label_Inspektion_Tid.ForeColor = System.Drawing.Color.Black;
            this.label_Inspektion_Tid.Location = new System.Drawing.Point(618, 42);
            this.label_Inspektion_Tid.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inspektion_Tid.Name = "label_Inspektion_Tid";
            this.tlp_Produktion_Svetsning.SetRowSpan(this.label_Inspektion_Tid, 2);
            this.label_Inspektion_Tid.Size = new System.Drawing.Size(54, 70);
            this.label_Inspektion_Tid.TabIndex = 1024;
            this.label_Inspektion_Tid.Text = "Tid";
            this.label_Inspektion_Tid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_AnstNr
            // 
            this.label_Inspektion_AnstNr.BackColor = System.Drawing.Color.White;
            this.label_Inspektion_AnstNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inspektion_AnstNr.Font = new System.Drawing.Font("Arial", 8.5F);
            this.label_Inspektion_AnstNr.ForeColor = System.Drawing.Color.Black;
            this.label_Inspektion_AnstNr.Location = new System.Drawing.Point(673, 42);
            this.label_Inspektion_AnstNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Inspektion_AnstNr.Name = "label_Inspektion_AnstNr";
            this.tlp_Produktion_Svetsning.SetRowSpan(this.label_Inspektion_AnstNr, 2);
            this.label_Inspektion_AnstNr.Size = new System.Drawing.Size(55, 70);
            this.label_Inspektion_AnstNr.TabIndex = 1024;
            this.label_Inspektion_AnstNr.Text = "Anst Nr";
            this.label_Inspektion_AnstNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Inspektion_Sign
            // 
            this.label_Inspektion_Sign.BackColor = System.Drawing.Color.White;
            this.label_Inspektion_Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Inspektion_Sign.Font = new System.Drawing.Font("Arial", 8.5F);
            this.label_Inspektion_Sign.ForeColor = System.Drawing.Color.Black;
            this.label_Inspektion_Sign.Location = new System.Drawing.Point(729, 42);
            this.label_Inspektion_Sign.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label_Inspektion_Sign.Name = "label_Inspektion_Sign";
            this.tlp_Produktion_Svetsning.SetRowSpan(this.label_Inspektion_Sign, 2);
            this.label_Inspektion_Sign.Size = new System.Drawing.Size(104, 70);
            this.label_Inspektion_Sign.TabIndex = 1024;
            this.label_Inspektion_Sign.Text = "Sign";
            this.label_Inspektion_Sign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Transfer_Produktion
            // 
            this.lbl_Transfer_Produktion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.lbl_Transfer_Produktion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Transfer_Produktion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Transfer_Produktion.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Transfer_Produktion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.lbl_Transfer_Produktion.Location = new System.Drawing.Point(1, 114);
            this.lbl_Transfer_Produktion.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.lbl_Transfer_Produktion.Name = "lbl_Transfer_Produktion";
            this.lbl_Transfer_Produktion.Size = new System.Drawing.Size(28, 20);
            this.lbl_Transfer_Produktion.TabIndex = 28;
            this.lbl_Transfer_Produktion.Text = "→";
            this.lbl_Transfer_Produktion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Transfer_Produktion.Click += new System.EventHandler(this.Save_Production_Parameters_Click);
            // 
            // dgv_Produktion
            // 
            this.dgv_Produktion.AllowUserToAddRows = false;
            this.dgv_Produktion.AllowUserToDeleteRows = false;
            this.dgv_Produktion.AllowUserToResizeColumns = false;
            this.dgv_Produktion.AllowUserToResizeRows = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Produktion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_Produktion.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Produktion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Produktion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_Produktion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Produktion.ColumnHeadersVisible = false;
            this.dgv_Produktion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNr,
            this.Påse_Nr,
            this.Uppmätt_Pinn,
            this.ID,
            this.OD,
            this.Längd,
            this.Utsida,
            this.Insida,
            this.Datum,
            this.Tid,
            this.AnstNr,
            this.Sign,
            this.dgv_Produktion_TempID});
            this.tlp_Produktion_Svetsning.SetColumnSpan(this.dgv_Produktion, 12);
            this.dgv_Produktion.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Courier New", 8F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Produktion.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgv_Produktion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Produktion.Location = new System.Drawing.Point(30, 135);
            this.dgv_Produktion.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.dgv_Produktion.Name = "dgv_Produktion";
            this.dgv_Produktion.ReadOnly = true;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Produktion.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dgv_Produktion.RowHeadersVisible = false;
            this.tlp_Produktion_Svetsning.SetRowSpan(this.dgv_Produktion, 2);
            this.dgv_Produktion.RowTemplate.Height = 18;
            this.dgv_Produktion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Produktion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Produktion.Size = new System.Drawing.Size(803, 111);
            this.dgv_Produktion.TabIndex = 845;
            // 
            // OrderNr
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.OrderNr.DefaultCellStyle = dataGridViewCellStyle14;
            this.OrderNr.HeaderText = "OrderNr";
            this.OrderNr.Name = "OrderNr";
            this.OrderNr.ReadOnly = true;
            this.OrderNr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderNr.Width = 82;
            // 
            // Påse_Nr
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Gray;
            this.Påse_Nr.DefaultCellStyle = dataGridViewCellStyle15;
            this.Påse_Nr.HeaderText = "Påse Nr";
            this.Påse_Nr.Name = "Påse_Nr";
            this.Påse_Nr.ReadOnly = true;
            this.Påse_Nr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Påse_Nr.Width = 41;
            // 
            // Uppmätt_Pinn
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Gray;
            this.Uppmätt_Pinn.DefaultCellStyle = dataGridViewCellStyle16;
            this.Uppmätt_Pinn.HeaderText = "Uppmätt Pinne";
            this.Uppmätt_Pinn.Name = "Uppmätt_Pinn";
            this.Uppmätt_Pinn.ReadOnly = true;
            this.Uppmätt_Pinn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Uppmätt_Pinn.Width = 60;
            // 
            // ID
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Gray;
            this.ID.DefaultCellStyle = dataGridViewCellStyle17;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.Width = 61;
            // 
            // OD
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Gray;
            this.OD.DefaultCellStyle = dataGridViewCellStyle18;
            this.OD.HeaderText = "OD";
            this.OD.Name = "OD";
            this.OD.ReadOnly = true;
            this.OD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OD.Width = 61;
            // 
            // Längd
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Gray;
            this.Längd.DefaultCellStyle = dataGridViewCellStyle19;
            this.Längd.HeaderText = "Längd";
            this.Längd.Name = "Längd";
            this.Längd.ReadOnly = true;
            this.Längd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Längd.Width = 76;
            // 
            // Utsida
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle20.NullValue = false;
            this.Utsida.DefaultCellStyle = dataGridViewCellStyle20;
            this.Utsida.HeaderText = "Utsida";
            this.Utsida.Name = "Utsida";
            this.Utsida.ReadOnly = true;
            this.Utsida.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Utsida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Utsida.Width = 60;
            // 
            // Insida
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle21.NullValue = false;
            this.Insida.DefaultCellStyle = dataGridViewCellStyle21;
            this.Insida.HeaderText = "Insida";
            this.Insida.Name = "Insida";
            this.Insida.ReadOnly = true;
            this.Insida.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Insida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Insida.Width = 59;
            // 
            // Datum
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Gray;
            this.Datum.DefaultCellStyle = dataGridViewCellStyle22;
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            this.Datum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Datum.Width = 87;
            // 
            // Tid
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Gray;
            this.Tid.DefaultCellStyle = dataGridViewCellStyle23;
            this.Tid.HeaderText = "Tid";
            this.Tid.Name = "Tid";
            this.Tid.ReadOnly = true;
            this.Tid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Tid.Width = 55;
            // 
            // AnstNr
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Gray;
            this.AnstNr.DefaultCellStyle = dataGridViewCellStyle24;
            this.AnstNr.HeaderText = "AnstNr";
            this.AnstNr.Name = "AnstNr";
            this.AnstNr.ReadOnly = true;
            this.AnstNr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AnstNr.Width = 56;
            // 
            // Sign
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Gray;
            this.Sign.DefaultCellStyle = dataGridViewCellStyle25;
            this.Sign.HeaderText = "Sign";
            this.Sign.Name = "Sign";
            this.Sign.ReadOnly = true;
            this.Sign.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sign.Width = 65;
            // 
            // dgv_Produktion_TempID
            // 
            this.dgv_Produktion_TempID.HeaderText = "TempID";
            this.dgv_Produktion_TempID.Name = "dgv_Produktion_TempID";
            this.dgv_Produktion_TempID.ReadOnly = true;
            this.dgv_Produktion_TempID.Visible = false;
            // 
            // label_Empty_5
            // 
            this.label_Empty_5.BackColor = System.Drawing.Color.DarkGray;
            this.label_Empty_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_5.Location = new System.Drawing.Point(1, 22);
            this.label_Empty_5.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_Empty_5.Name = "label_Empty_5";
            this.tlp_Produktion_Svetsning.SetRowSpan(this.label_Empty_5, 3);
            this.label_Empty_5.Size = new System.Drawing.Size(28, 90);
            this.label_Empty_5.TabIndex = 1007;
            this.label_Empty_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_InledandeUppmättPinne
            // 
            this.tb_InledandeUppmättPinne.BackColor = System.Drawing.Color.White;
            this.tb_InledandeUppmättPinne.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_InledandeUppmättPinne.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_InledandeUppmättPinne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_InledandeUppmättPinne.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_InledandeUppmättPinne.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_InledandeUppmättPinne.Location = new System.Drawing.Point(154, 114);
            this.tb_InledandeUppmättPinne.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_InledandeUppmättPinne.Multiline = true;
            this.tb_InledandeUppmättPinne.Name = "tb_InledandeUppmättPinne";
            this.tb_InledandeUppmättPinne.Size = new System.Drawing.Size(59, 20);
            this.tb_InledandeUppmättPinne.TabIndex = 22;
            this.tb_InledandeUppmättPinne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_InledandeUppmättPinne.WordWrap = false;
            this.tb_InledandeUppmättPinne.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_InledandeID
            // 
            this.tb_InledandeID.BackColor = System.Drawing.Color.White;
            this.tb_InledandeID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_InledandeID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_InledandeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_InledandeID.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_InledandeID.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_InledandeID.Location = new System.Drawing.Point(214, 114);
            this.tb_InledandeID.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_InledandeID.Multiline = true;
            this.tb_InledandeID.Name = "tb_InledandeID";
            this.tb_InledandeID.Size = new System.Drawing.Size(60, 20);
            this.tb_InledandeID.TabIndex = 23;
            this.tb_InledandeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_InledandeID.WordWrap = false;
            this.tb_InledandeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_InledandeOD
            // 
            this.tb_InledandeOD.BackColor = System.Drawing.Color.White;
            this.tb_InledandeOD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_InledandeOD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_InledandeOD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_InledandeOD.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_InledandeOD.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_InledandeOD.Location = new System.Drawing.Point(275, 114);
            this.tb_InledandeOD.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_InledandeOD.Multiline = true;
            this.tb_InledandeOD.Name = "tb_InledandeOD";
            this.tb_InledandeOD.Size = new System.Drawing.Size(60, 20);
            this.tb_InledandeOD.TabIndex = 24;
            this.tb_InledandeOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_InledandeOD.WordWrap = false;
            this.tb_InledandeOD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_InledandeLängd
            // 
            this.tb_InledandeLängd.BackColor = System.Drawing.Color.White;
            this.tb_InledandeLängd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_InledandeLängd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_InledandeLängd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_InledandeLängd.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_InledandeLängd.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_InledandeLängd.Location = new System.Drawing.Point(336, 114);
            this.tb_InledandeLängd.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.tb_InledandeLängd.Multiline = true;
            this.tb_InledandeLängd.Name = "tb_InledandeLängd";
            this.tb_InledandeLängd.Size = new System.Drawing.Size(75, 20);
            this.tb_InledandeLängd.TabIndex = 25;
            this.tb_InledandeLängd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_InledandeLängd.WordWrap = false;
            this.tb_InledandeLängd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // label_Empty_6
            // 
            this.label_Empty_6.BackColor = System.Drawing.Color.DarkGray;
            this.tlp_Produktion_Svetsning.SetColumnSpan(this.label_Empty_6, 4);
            this.label_Empty_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Empty_6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_Empty_6.Location = new System.Drawing.Point(531, 114);
            this.label_Empty_6.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.label_Empty_6.Name = "label_Empty_6";
            this.label_Empty_6.Size = new System.Drawing.Size(302, 20);
            this.label_Empty_6.TabIndex = 1007;
            this.label_Empty_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chb_InspektionUtsida
            // 
            this.chb_InspektionUtsida.AutoSize = true;
            this.chb_InspektionUtsida.BackColor = System.Drawing.Color.White;
            this.chb_InspektionUtsida.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_InspektionUtsida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chb_InspektionUtsida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_InspektionUtsida.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.chb_InspektionUtsida.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.chb_InspektionUtsida.Location = new System.Drawing.Point(413, 114);
            this.chb_InspektionUtsida.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.chb_InspektionUtsida.Name = "chb_InspektionUtsida";
            this.chb_InspektionUtsida.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chb_InspektionUtsida.Size = new System.Drawing.Size(58, 20);
            this.chb_InspektionUtsida.TabIndex = 26;
            this.chb_InspektionUtsida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_InspektionUtsida.UseVisualStyleBackColor = false;
            // 
            // chb_InspektionInsida
            // 
            this.chb_InspektionInsida.AutoSize = true;
            this.chb_InspektionInsida.BackColor = System.Drawing.Color.White;
            this.chb_InspektionInsida.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_InspektionInsida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chb_InspektionInsida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_InspektionInsida.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.chb_InspektionInsida.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.chb_InspektionInsida.Location = new System.Drawing.Point(472, 114);
            this.chb_InspektionInsida.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.chb_InspektionInsida.Name = "chb_InspektionInsida";
            this.chb_InspektionInsida.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chb_InspektionInsida.Size = new System.Drawing.Size(58, 20);
            this.chb_InspektionInsida.TabIndex = 27;
            this.chb_InspektionInsida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_InspektionInsida.UseVisualStyleBackColor = false;
            // 
            // lbl_Discard_Row_Produktion
            // 
            this.lbl_Discard_Row_Produktion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.lbl_Discard_Row_Produktion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Discard_Row_Produktion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Discard_Row_Produktion.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Discard_Row_Produktion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_Discard_Row_Produktion.Location = new System.Drawing.Point(1, 135);
            this.lbl_Discard_Row_Produktion.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.lbl_Discard_Row_Produktion.Name = "lbl_Discard_Row_Produktion";
            this.lbl_Discard_Row_Produktion.Size = new System.Drawing.Size(28, 22);
            this.lbl_Discard_Row_Produktion.TabIndex = 28;
            this.lbl_Discard_Row_Produktion.Text = "→";
            this.lbl_Discard_Row_Produktion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Discard_Row_Produktion.Click += new System.EventHandler(this.Delete_Row_Production_Parameters_Click);
            // 
            // tlp_Maskinparametrar
            // 
            this.tlp_Maskinparametrar.ColumnCount = 15;
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlp_Maskinparametrar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlp_Maskinparametrar.Controls.Add(this.tb_VärmebackarHål, 10, 1);
            this.tlp_Maskinparametrar.Controls.Add(this.dgv_MaskinParametrar, 1, 2);
            this.tlp_Maskinparametrar.Controls.Add(this.tb_VärmebackarBredd, 9, 1);
            this.tlp_Maskinparametrar.Controls.Add(this.lbl_Transfer_Maskinparametrar, 0, 1);
            this.tlp_Maskinparametrar.Controls.Add(this.tb_PinneODPTFE, 8, 1);
            this.tlp_Maskinparametrar.Controls.Add(this.lbl_Kassera_Maskinparameter, 0, 2);
            this.tlp_Maskinparametrar.Controls.Add(this.tb_PinneODStål, 7, 1);
            this.tlp_Maskinparametrar.Controls.Add(this.tb_Svets, 1, 1);
            this.tlp_Maskinparametrar.Controls.Add(this.tb_Temperatur, 6, 1);
            this.tlp_Maskinparametrar.Controls.Add(this.tb_TidFörvärme, 2, 1);
            this.tlp_Maskinparametrar.Controls.Add(this.tb_TidKylluft, 5, 1);
            this.tlp_Maskinparametrar.Controls.Add(this.tb_TidBindvärme, 4, 1);
            this.tlp_Maskinparametrar.Controls.Add(this.tb_Svetsförflyttning, 3, 1);
            this.tlp_Maskinparametrar.Controls.Add(this.PC_Svetsning_TEF, 0, 0);
            this.tlp_Maskinparametrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Maskinparametrar.Location = new System.Drawing.Point(0, 46);
            this.tlp_Maskinparametrar.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.tlp_Maskinparametrar.Name = "tlp_Maskinparametrar";
            this.tlp_Maskinparametrar.RowCount = 4;
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Maskinparametrar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_Maskinparametrar.Size = new System.Drawing.Size(833, 239);
            this.tlp_Maskinparametrar.TabIndex = 1024;
            // 
            // tb_VärmebackarHål
            // 
            this.tb_VärmebackarHål.BackColor = System.Drawing.Color.White;
            this.tb_VärmebackarHål.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_VärmebackarHål.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_VärmebackarHål.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_VärmebackarHål.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_VärmebackarHål.Location = new System.Drawing.Point(539, 137);
            this.tb_VärmebackarHål.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.tb_VärmebackarHål.MaxLength = 5;
            this.tb_VärmebackarHål.Multiline = true;
            this.tb_VärmebackarHål.Name = "tb_VärmebackarHål";
            this.tb_VärmebackarHål.Size = new System.Drawing.Size(41, 19);
            this.tb_VärmebackarHål.TabIndex = 10;
            this.tb_VärmebackarHål.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_VärmebackarHål.WordWrap = false;
            this.tb_VärmebackarHål.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // dgv_MaskinParametrar
            // 
            this.dgv_MaskinParametrar.AllowUserToAddRows = false;
            this.dgv_MaskinParametrar.AllowUserToDeleteRows = false;
            this.dgv_MaskinParametrar.AllowUserToResizeColumns = false;
            this.dgv_MaskinParametrar.AllowUserToResizeRows = false;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_MaskinParametrar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle28;
            this.dgv_MaskinParametrar.BackgroundColor = System.Drawing.Color.White;
            this.dgv_MaskinParametrar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_MaskinParametrar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dgv_MaskinParametrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MaskinParametrar.ColumnHeadersVisible = false;
            this.dgv_MaskinParametrar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_Maskinparametrar_Svets,
            this.dgv_Maskinparametrar_Tid_Förvärme,
            this.dgv_Maskinparametrar_Svetsförflyttning,
            this.dgv_Maskinparametrar_Tid_Bindvärme,
            this.dgv_Maskinparametrar_Tid_Kylluft,
            this.dgv_Maskinparametrar_Temperatur,
            this.dgv_Maskinparametrar_Stål,
            this.dgv_Maskinparametrar_Pinne_PTFE,
            this.dgv_Maskinparametrar_Värmebackar_Bredd,
            this.dgv_Maskinparametrar_Värmebackar_Hål,
            this.dgv_Maskinparametrar_Datum,
            this.dgv_Maskinparametrar_Tid,
            this.dgv_Maskinparametrar_AnstNr,
            this.dgv_Maskinparametrar_Sign});
            this.tlp_Maskinparametrar.SetColumnSpan(this.dgv_MaskinParametrar, 14);
            this.dgv_MaskinParametrar.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Courier New", 8F);
            dataGridViewCellStyle44.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_MaskinParametrar.DefaultCellStyle = dataGridViewCellStyle44;
            this.dgv_MaskinParametrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_MaskinParametrar.Location = new System.Drawing.Point(38, 157);
            this.dgv_MaskinParametrar.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.dgv_MaskinParametrar.MultiSelect = false;
            this.dgv_MaskinParametrar.Name = "dgv_MaskinParametrar";
            this.dgv_MaskinParametrar.ReadOnly = true;
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_MaskinParametrar.RowHeadersDefaultCellStyle = dataGridViewCellStyle45;
            this.dgv_MaskinParametrar.RowHeadersVisible = false;
            this.tlp_Maskinparametrar.SetRowSpan(this.dgv_MaskinParametrar, 2);
            this.dgv_MaskinParametrar.RowTemplate.Height = 18;
            this.dgv_MaskinParametrar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_MaskinParametrar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_MaskinParametrar.Size = new System.Drawing.Size(795, 82);
            this.dgv_MaskinParametrar.TabIndex = 1008;
            // 
            // dgv_Maskinparametrar_Svets
            // 
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Svets.DefaultCellStyle = dataGridViewCellStyle30;
            this.dgv_Maskinparametrar_Svets.HeaderText = "Svets";
            this.dgv_Maskinparametrar_Svets.Name = "dgv_Maskinparametrar_Svets";
            this.dgv_Maskinparametrar_Svets.ReadOnly = true;
            this.dgv_Maskinparametrar_Svets.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Svets.Width = 62;
            // 
            // dgv_Maskinparametrar_Tid_Förvärme
            // 
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle31.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Tid_Förvärme.DefaultCellStyle = dataGridViewCellStyle31;
            this.dgv_Maskinparametrar_Tid_Förvärme.HeaderText = "Tid Förvärme";
            this.dgv_Maskinparametrar_Tid_Förvärme.Name = "dgv_Maskinparametrar_Tid_Förvärme";
            this.dgv_Maskinparametrar_Tid_Förvärme.ReadOnly = true;
            this.dgv_Maskinparametrar_Tid_Förvärme.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Tid_Förvärme.Width = 60;
            // 
            // dgv_Maskinparametrar_Svetsförflyttning
            // 
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Svetsförflyttning.DefaultCellStyle = dataGridViewCellStyle32;
            this.dgv_Maskinparametrar_Svetsförflyttning.HeaderText = "Svets Förflyttning";
            this.dgv_Maskinparametrar_Svetsförflyttning.Name = "dgv_Maskinparametrar_Svetsförflyttning";
            this.dgv_Maskinparametrar_Svetsförflyttning.ReadOnly = true;
            this.dgv_Maskinparametrar_Svetsförflyttning.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Svetsförflyttning.Width = 63;
            // 
            // dgv_Maskinparametrar_Tid_Bindvärme
            // 
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle33.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Tid_Bindvärme.DefaultCellStyle = dataGridViewCellStyle33;
            this.dgv_Maskinparametrar_Tid_Bindvärme.HeaderText = "Tid Bindvärme";
            this.dgv_Maskinparametrar_Tid_Bindvärme.Name = "dgv_Maskinparametrar_Tid_Bindvärme";
            this.dgv_Maskinparametrar_Tid_Bindvärme.ReadOnly = true;
            this.dgv_Maskinparametrar_Tid_Bindvärme.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Tid_Bindvärme.Width = 67;
            // 
            // dgv_Maskinparametrar_Tid_Kylluft
            // 
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Tid_Kylluft.DefaultCellStyle = dataGridViewCellStyle34;
            this.dgv_Maskinparametrar_Tid_Kylluft.HeaderText = "Tid Kylluft";
            this.dgv_Maskinparametrar_Tid_Kylluft.Name = "dgv_Maskinparametrar_Tid_Kylluft";
            this.dgv_Maskinparametrar_Tid_Kylluft.ReadOnly = true;
            this.dgv_Maskinparametrar_Tid_Kylluft.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Tid_Kylluft.Width = 45;
            // 
            // dgv_Maskinparametrar_Temperatur
            // 
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle35.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Temperatur.DefaultCellStyle = dataGridViewCellStyle35;
            this.dgv_Maskinparametrar_Temperatur.HeaderText = "Temperatur";
            this.dgv_Maskinparametrar_Temperatur.Name = "dgv_Maskinparametrar_Temperatur";
            this.dgv_Maskinparametrar_Temperatur.ReadOnly = true;
            this.dgv_Maskinparametrar_Temperatur.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Temperatur.Width = 39;
            // 
            // dgv_Maskinparametrar_Stål
            // 
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle36.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Stål.DefaultCellStyle = dataGridViewCellStyle36;
            this.dgv_Maskinparametrar_Stål.HeaderText = "Pinne Stål";
            this.dgv_Maskinparametrar_Stål.Name = "dgv_Maskinparametrar_Stål";
            this.dgv_Maskinparametrar_Stål.ReadOnly = true;
            this.dgv_Maskinparametrar_Stål.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Stål.Width = 44;
            // 
            // dgv_Maskinparametrar_Pinne_PTFE
            // 
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle37.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Pinne_PTFE.DefaultCellStyle = dataGridViewCellStyle37;
            this.dgv_Maskinparametrar_Pinne_PTFE.HeaderText = "Pinne PTFE";
            this.dgv_Maskinparametrar_Pinne_PTFE.Name = "dgv_Maskinparametrar_Pinne_PTFE";
            this.dgv_Maskinparametrar_Pinne_PTFE.ReadOnly = true;
            this.dgv_Maskinparametrar_Pinne_PTFE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Pinne_PTFE.Width = 78;
            // 
            // dgv_Maskinparametrar_Värmebackar_Bredd
            // 
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle38.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Värmebackar_Bredd.DefaultCellStyle = dataGridViewCellStyle38;
            this.dgv_Maskinparametrar_Värmebackar_Bredd.HeaderText = "Värmebackar Bredd";
            this.dgv_Maskinparametrar_Värmebackar_Bredd.Name = "dgv_Maskinparametrar_Värmebackar_Bredd";
            this.dgv_Maskinparametrar_Värmebackar_Bredd.ReadOnly = true;
            this.dgv_Maskinparametrar_Värmebackar_Bredd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Värmebackar_Bredd.Width = 42;
            // 
            // dgv_Maskinparametrar_Värmebackar_Hål
            // 
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle39.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Värmebackar_Hål.DefaultCellStyle = dataGridViewCellStyle39;
            this.dgv_Maskinparametrar_Värmebackar_Hål.HeaderText = "Värmebackar Hål";
            this.dgv_Maskinparametrar_Värmebackar_Hål.Name = "dgv_Maskinparametrar_Värmebackar_Hål";
            this.dgv_Maskinparametrar_Värmebackar_Hål.ReadOnly = true;
            this.dgv_Maskinparametrar_Värmebackar_Hål.Width = 42;
            // 
            // dgv_Maskinparametrar_Datum
            // 
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle40.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Datum.DefaultCellStyle = dataGridViewCellStyle40;
            this.dgv_Maskinparametrar_Datum.HeaderText = "Datum";
            this.dgv_Maskinparametrar_Datum.Name = "dgv_Maskinparametrar_Datum";
            this.dgv_Maskinparametrar_Datum.ReadOnly = true;
            this.dgv_Maskinparametrar_Datum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Datum.Width = 84;
            // 
            // dgv_Maskinparametrar_Tid
            // 
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle41.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Tid.DefaultCellStyle = dataGridViewCellStyle41;
            this.dgv_Maskinparametrar_Tid.HeaderText = "Tid";
            this.dgv_Maskinparametrar_Tid.Name = "dgv_Maskinparametrar_Tid";
            this.dgv_Maskinparametrar_Tid.ReadOnly = true;
            this.dgv_Maskinparametrar_Tid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Tid.Width = 48;
            // 
            // dgv_Maskinparametrar_AnstNr
            // 
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle42.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_AnstNr.DefaultCellStyle = dataGridViewCellStyle42;
            this.dgv_Maskinparametrar_AnstNr.HeaderText = "AnstNr";
            this.dgv_Maskinparametrar_AnstNr.Name = "dgv_Maskinparametrar_AnstNr";
            this.dgv_Maskinparametrar_AnstNr.ReadOnly = true;
            this.dgv_Maskinparametrar_AnstNr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_AnstNr.Width = 42;
            // 
            // dgv_Maskinparametrar_Sign
            // 
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Italic);
            dataGridViewCellStyle43.ForeColor = System.Drawing.Color.Gray;
            this.dgv_Maskinparametrar_Sign.DefaultCellStyle = dataGridViewCellStyle43;
            this.dgv_Maskinparametrar_Sign.HeaderText = "Sign";
            this.dgv_Maskinparametrar_Sign.Name = "dgv_Maskinparametrar_Sign";
            this.dgv_Maskinparametrar_Sign.ReadOnly = true;
            this.dgv_Maskinparametrar_Sign.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Maskinparametrar_Sign.Width = 42;
            // 
            // tb_VärmebackarBredd
            // 
            this.tb_VärmebackarBredd.BackColor = System.Drawing.Color.White;
            this.tb_VärmebackarBredd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_VärmebackarBredd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_VärmebackarBredd.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_VärmebackarBredd.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_VärmebackarBredd.Location = new System.Drawing.Point(497, 137);
            this.tb_VärmebackarBredd.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_VärmebackarBredd.MaxLength = 5;
            this.tb_VärmebackarBredd.Multiline = true;
            this.tb_VärmebackarBredd.Name = "tb_VärmebackarBredd";
            this.tb_VärmebackarBredd.Size = new System.Drawing.Size(41, 19);
            this.tb_VärmebackarBredd.TabIndex = 9;
            this.tb_VärmebackarBredd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_VärmebackarBredd.WordWrap = false;
            this.tb_VärmebackarBredd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // lbl_Transfer_Maskinparametrar
            // 
            this.lbl_Transfer_Maskinparametrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.lbl_Transfer_Maskinparametrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Transfer_Maskinparametrar.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Transfer_Maskinparametrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.lbl_Transfer_Maskinparametrar.Location = new System.Drawing.Point(0, 137);
            this.lbl_Transfer_Maskinparametrar.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_Transfer_Maskinparametrar.Name = "lbl_Transfer_Maskinparametrar";
            this.lbl_Transfer_Maskinparametrar.Size = new System.Drawing.Size(37, 19);
            this.lbl_Transfer_Maskinparametrar.TabIndex = 1010;
            this.lbl_Transfer_Maskinparametrar.Text = "→";
            this.lbl_Transfer_Maskinparametrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Transfer_Maskinparametrar.Click += new System.EventHandler(this.Save_Maskinparametrar_Click);
            // 
            // tb_PinneODPTFE
            // 
            this.tb_PinneODPTFE.BackColor = System.Drawing.Color.White;
            this.tb_PinneODPTFE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_PinneODPTFE.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_PinneODPTFE.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_PinneODPTFE.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_PinneODPTFE.Location = new System.Drawing.Point(419, 137);
            this.tb_PinneODPTFE.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_PinneODPTFE.MaxLength = 12;
            this.tb_PinneODPTFE.Multiline = true;
            this.tb_PinneODPTFE.Name = "tb_PinneODPTFE";
            this.tb_PinneODPTFE.Size = new System.Drawing.Size(77, 19);
            this.tb_PinneODPTFE.TabIndex = 8;
            this.tb_PinneODPTFE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_PinneODPTFE.WordWrap = false;
            this.tb_PinneODPTFE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // lbl_Kassera_Maskinparameter
            // 
            this.lbl_Kassera_Maskinparameter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.lbl_Kassera_Maskinparameter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Kassera_Maskinparameter.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Kassera_Maskinparameter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_Kassera_Maskinparameter.Location = new System.Drawing.Point(0, 157);
            this.lbl_Kassera_Maskinparameter.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_Kassera_Maskinparameter.Name = "lbl_Kassera_Maskinparameter";
            this.lbl_Kassera_Maskinparameter.Size = new System.Drawing.Size(37, 19);
            this.lbl_Kassera_Maskinparameter.TabIndex = 28;
            this.lbl_Kassera_Maskinparameter.Text = "→";
            this.lbl_Kassera_Maskinparameter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Kassera_Maskinparameter.Click += new System.EventHandler(this.Delete_Row_Maskinparameter_Click);
            // 
            // tb_PinneODStål
            // 
            this.tb_PinneODStål.BackColor = System.Drawing.Color.White;
            this.tb_PinneODStål.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_PinneODStål.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_PinneODStål.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_PinneODStål.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_PinneODStål.Location = new System.Drawing.Point(375, 137);
            this.tb_PinneODStål.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_PinneODStål.MaxLength = 5;
            this.tb_PinneODStål.Multiline = true;
            this.tb_PinneODStål.Name = "tb_PinneODStål";
            this.tb_PinneODStål.Size = new System.Drawing.Size(43, 19);
            this.tb_PinneODStål.TabIndex = 7;
            this.tb_PinneODStål.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_PinneODStål.WordWrap = false;
            this.tb_PinneODStål.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_Svets
            // 
            this.tb_Svets.BackColor = System.Drawing.Color.White;
            this.tb_Svets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Svets.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Svets.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_Svets.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Svets.Location = new System.Drawing.Point(38, 137);
            this.tb_Svets.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Svets.MaxLength = 10;
            this.tb_Svets.Multiline = true;
            this.tb_Svets.Name = "tb_Svets";
            this.tb_Svets.Size = new System.Drawing.Size(62, 19);
            this.tb_Svets.TabIndex = 1;
            this.tb_Svets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Svets.WordWrap = false;
            this.tb_Svets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            // 
            // tb_Temperatur
            // 
            this.tb_Temperatur.BackColor = System.Drawing.Color.White;
            this.tb_Temperatur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Temperatur.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Temperatur.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_Temperatur.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Temperatur.Location = new System.Drawing.Point(336, 137);
            this.tb_Temperatur.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Temperatur.MaxLength = 4;
            this.tb_Temperatur.Multiline = true;
            this.tb_Temperatur.Name = "tb_Temperatur";
            this.tb_Temperatur.Size = new System.Drawing.Size(38, 19);
            this.tb_Temperatur.TabIndex = 6;
            this.tb_Temperatur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Temperatur.WordWrap = false;
            this.tb_Temperatur.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            this.tb_Temperatur.Leave += new System.EventHandler(this.Check_MIN_NOM_MAX_Leave);
            // 
            // tb_TidFörvärme
            // 
            this.tb_TidFörvärme.BackColor = System.Drawing.Color.White;
            this.tb_TidFörvärme.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_TidFörvärme.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_TidFörvärme.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_TidFörvärme.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_TidFörvärme.Location = new System.Drawing.Point(101, 137);
            this.tb_TidFörvärme.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_TidFörvärme.MaxLength = 4;
            this.tb_TidFörvärme.Multiline = true;
            this.tb_TidFörvärme.Name = "tb_TidFörvärme";
            this.tb_TidFörvärme.Size = new System.Drawing.Size(59, 19);
            this.tb_TidFörvärme.TabIndex = 2;
            this.tb_TidFörvärme.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_TidFörvärme.WordWrap = false;
            this.tb_TidFörvärme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            this.tb_TidFörvärme.Leave += new System.EventHandler(this.Check_MIN_NOM_MAX_Leave);
            // 
            // tb_TidKylluft
            // 
            this.tb_TidKylluft.BackColor = System.Drawing.Color.White;
            this.tb_TidKylluft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_TidKylluft.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_TidKylluft.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_TidKylluft.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_TidKylluft.Location = new System.Drawing.Point(291, 137);
            this.tb_TidKylluft.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_TidKylluft.MaxLength = 3;
            this.tb_TidKylluft.Multiline = true;
            this.tb_TidKylluft.Name = "tb_TidKylluft";
            this.tb_TidKylluft.Size = new System.Drawing.Size(44, 19);
            this.tb_TidKylluft.TabIndex = 5;
            this.tb_TidKylluft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_TidKylluft.WordWrap = false;
            this.tb_TidKylluft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            this.tb_TidKylluft.Leave += new System.EventHandler(this.Check_MIN_NOM_MAX_Leave);
            // 
            // tb_TidBindvärme
            // 
            this.tb_TidBindvärme.BackColor = System.Drawing.Color.White;
            this.tb_TidBindvärme.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_TidBindvärme.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_TidBindvärme.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_TidBindvärme.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_TidBindvärme.Location = new System.Drawing.Point(224, 137);
            this.tb_TidBindvärme.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_TidBindvärme.MaxLength = 3;
            this.tb_TidBindvärme.Multiline = true;
            this.tb_TidBindvärme.Name = "tb_TidBindvärme";
            this.tb_TidBindvärme.Size = new System.Drawing.Size(66, 19);
            this.tb_TidBindvärme.TabIndex = 4;
            this.tb_TidBindvärme.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_TidBindvärme.WordWrap = false;
            this.tb_TidBindvärme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            this.tb_TidBindvärme.Leave += new System.EventHandler(this.Check_MIN_NOM_MAX_Leave);
            // 
            // tb_Svetsförflyttning
            // 
            this.tb_Svetsförflyttning.BackColor = System.Drawing.Color.White;
            this.tb_Svetsförflyttning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Svetsförflyttning.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Svetsförflyttning.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.tb_Svetsförflyttning.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Svetsförflyttning.Location = new System.Drawing.Point(161, 137);
            this.tb_Svetsförflyttning.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.tb_Svetsförflyttning.MaxLength = 4;
            this.tb_Svetsförflyttning.Multiline = true;
            this.tb_Svetsförflyttning.Name = "tb_Svetsförflyttning";
            this.tb_Svetsförflyttning.Size = new System.Drawing.Size(62, 19);
            this.tb_Svetsförflyttning.TabIndex = 3;
            this.tb_Svetsförflyttning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Svetsförflyttning.WordWrap = false;
            this.tb_Svetsförflyttning.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToTab_KeyDown);
            this.tb_Svetsförflyttning.Leave += new System.EventHandler(this.Check_MIN_NOM_MAX_Leave);
            // 
            // PC_Svetsning_TEF
            // 
            this.tlp_Maskinparametrar.SetColumnSpan(this.PC_Svetsning_TEF, 15);
            this.PC_Svetsning_TEF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PC_Svetsning_TEF.Location = new System.Drawing.Point(0, 0);
            this.PC_Svetsning_TEF.Margin = new System.Windows.Forms.Padding(0);
            this.PC_Svetsning_TEF.Name = "PC_Svetsning_TEF";
            this.PC_Svetsning_TEF.Size = new System.Drawing.Size(833, 136);
            this.PC_Svetsning_TEF.TabIndex = 1011;
            // 
            // MainInfo
            // 
            this.MainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainInfo.Location = new System.Drawing.Point(0, 1);
            this.MainInfo.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.MainInfo.Name = "MainInfo";
            this.MainInfo.Size = new System.Drawing.Size(834, 45);
            this.MainInfo.TabIndex = 1026;
            // 
            // MainProtocol_Svetsning_TEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "MainProtocol_Svetsning_TEF";
            this.Size = new System.Drawing.Size(834, 837);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Halvfabrikat.ResumeLayout(false);
            this.tlp_Halvfabrikat.PerformLayout();
            this.panel_Halvfabrikat_OrderNr.ResumeLayout(false);
            this.panel_Halvfabrikat_ArtikelNr.ResumeLayout(false);
            this.panel_Halvfabrikat_Typ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Halvfabrikat)).EndInit();
            this.tlp_Produktion_Svetsning.ResumeLayout(false);
            this.tlp_Produktion_Svetsning.PerformLayout();
            this.panel_Produktion_OrderNr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Produktion)).EndInit();
            this.tlp_Maskinparametrar.ResumeLayout(false);
            this.tlp_Maskinparametrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MaskinParametrar)).EndInit();
            this.ResumeLayout(false);

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
    }
}
