using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Statistics
{
    partial class ProductionLines
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_Mätningar = new System.Windows.Forms.DataGridView();
            this.lbl_Mätningar = new System.Windows.Forms.Label();
            this.dgv_FrekvensArtikelNr = new System.Windows.Forms.DataGridView();
            this.label_ArtikelNr = new System.Windows.Forms.Label();
            this.dgv_OperatörRengör = new System.Windows.Forms.DataGridView();
            this.label_Operatör = new System.Windows.Forms.Label();
            this.dgv_Huvud = new System.Windows.Forms.DataGridView();
            this.label_Huvud = new System.Windows.Forms.Label();
            this.dgv_Munstycke = new System.Windows.Forms.DataGridView();
            this.label_Munstycke = new System.Windows.Forms.Label();
            this.dgv_Kärn = new System.Windows.Forms.DataGridView();
            this.lblKärn = new System.Windows.Forms.Label();
            this.cb_Linje = new System.Windows.Forms.ComboBox();
            this.dgv_Kund = new System.Windows.Forms.DataGridView();
            this.label_Kund = new System.Windows.Forms.Label();
            this.dgv_KrympslangsRör = new System.Windows.Forms.DataGridView();
            this.label_KrympslangsRör = new System.Windows.Forms.Label();
            this.dgv_KrympslangsLinje = new System.Windows.Forms.DataGridView();
            this.label_krympslangsLinje = new System.Windows.Forms.Label();
            this.dgv_Hackhylsa = new System.Windows.Forms.DataGridView();
            this.label_Hackhylsa = new System.Windows.Forms.Label();
            this.flp_Main = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_Mätningar_Linje = new System.Windows.Forms.Panel();
            this.panel_Operatör_Rengör = new System.Windows.Forms.Panel();
            this.panel_Frekvens_ArtikelNr = new System.Windows.Forms.Panel();
            this.panel_Frekvens_Kund = new System.Windows.Forms.Panel();
            this.panel_Huvud = new System.Windows.Forms.Panel();
            this.panel_Munstycke = new System.Windows.Forms.Panel();
            this.panel_Kärn = new System.Windows.Forms.Panel();
            this.panel_KrympslangsRör = new System.Windows.Forms.Panel();
            this.panel_KrympslangsLinje = new System.Windows.Forms.Panel();
            this.panel_Anslutningsmuff = new System.Windows.Forms.Panel();
            this.label_Anslutningsmuff = new System.Windows.Forms.Label();
            this.dgv_Anslutningsmuff = new System.Windows.Forms.DataGridView();
            this.panel_Hackhylsa = new System.Windows.Forms.Panel();
            this.date_From = new System.Windows.Forms.DateTimePicker();
            this.date_To = new System.Windows.Forms.DateTimePicker();
            this.label_Datum_Från = new System.Windows.Forms.Label();
            this.label_Datum_Till = new System.Windows.Forms.Label();
            this.label_Linje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mätningar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FrekvensArtikelNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OperatörRengör)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Huvud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Munstycke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kärn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KrympslangsRör)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KrympslangsLinje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Hackhylsa)).BeginInit();
            this.flp_Main.SuspendLayout();
            this.panel_Mätningar_Linje.SuspendLayout();
            this.panel_Operatör_Rengör.SuspendLayout();
            this.panel_Frekvens_ArtikelNr.SuspendLayout();
            this.panel_Frekvens_Kund.SuspendLayout();
            this.panel_Huvud.SuspendLayout();
            this.panel_Munstycke.SuspendLayout();
            this.panel_Kärn.SuspendLayout();
            this.panel_KrympslangsRör.SuspendLayout();
            this.panel_KrympslangsLinje.SuspendLayout();
            this.panel_Anslutningsmuff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Anslutningsmuff)).BeginInit();
            this.panel_Hackhylsa.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Mätningar
            // 
            this.dgv_Mätningar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Mätningar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_Mätningar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Mätningar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_Mätningar.Location = new System.Drawing.Point(0, 27);
            this.dgv_Mätningar.MaximumSize = new System.Drawing.Size(0, 192);
            this.dgv_Mätningar.Name = "dgv_Mätningar";
            this.dgv_Mätningar.RowHeadersVisible = false;
            this.dgv_Mätningar.Size = new System.Drawing.Size(215, 190);
            this.dgv_Mätningar.TabIndex = 2;
            // 
            // lbl_Mätningar
            // 
            this.lbl_Mätningar.AutoSize = true;
            this.lbl_Mätningar.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Mätningar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Mätningar.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Mätningar.ForeColor = System.Drawing.Color.LightCoral;
            this.lbl_Mätningar.Location = new System.Drawing.Point(0, 0);
            this.lbl_Mätningar.Name = "lbl_Mätningar";
            this.lbl_Mätningar.Size = new System.Drawing.Size(136, 22);
            this.lbl_Mätningar.TabIndex = 0;
            this.lbl_Mätningar.Text = "Mätningar i linjen:";
            // 
            // dgv_FrekvensArtikelNr
            // 
            this.dgv_FrekvensArtikelNr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_FrekvensArtikelNr.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_FrekvensArtikelNr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_FrekvensArtikelNr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_FrekvensArtikelNr.Location = new System.Drawing.Point(0, 27);
            this.dgv_FrekvensArtikelNr.MaximumSize = new System.Drawing.Size(0, 190);
            this.dgv_FrekvensArtikelNr.MinimumSize = new System.Drawing.Size(0, 190);
            this.dgv_FrekvensArtikelNr.Name = "dgv_FrekvensArtikelNr";
            this.dgv_FrekvensArtikelNr.RowHeadersVisible = false;
            this.dgv_FrekvensArtikelNr.Size = new System.Drawing.Size(403, 190);
            this.dgv_FrekvensArtikelNr.TabIndex = 3;
            // 
            // label_ArtikelNr
            // 
            this.label_ArtikelNr.AutoSize = true;
            this.label_ArtikelNr.BackColor = System.Drawing.Color.Transparent;
            this.label_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_ArtikelNr.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ArtikelNr.ForeColor = System.Drawing.Color.LightCoral;
            this.label_ArtikelNr.Location = new System.Drawing.Point(0, 0);
            this.label_ArtikelNr.Name = "label_ArtikelNr";
            this.label_ArtikelNr.Size = new System.Drawing.Size(181, 22);
            this.label_ArtikelNr.TabIndex = 0;
            this.label_ArtikelNr.Text = "Mest frekventa artikelNr:";
            // 
            // dgv_OperatörRengör
            // 
            this.dgv_OperatörRengör.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_OperatörRengör.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_OperatörRengör.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_OperatörRengör.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_OperatörRengör.Location = new System.Drawing.Point(0, 27);
            this.dgv_OperatörRengör.MaximumSize = new System.Drawing.Size(0, 190);
            this.dgv_OperatörRengör.MinimumSize = new System.Drawing.Size(0, 190);
            this.dgv_OperatörRengör.Name = "dgv_OperatörRengör";
            this.dgv_OperatörRengör.RowHeadersVisible = false;
            this.dgv_OperatörRengör.Size = new System.Drawing.Size(214, 190);
            this.dgv_OperatörRengör.TabIndex = 5;
            // 
            // label_Operatör
            // 
            this.label_Operatör.AutoSize = true;
            this.label_Operatör.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Operatör.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Operatör.ForeColor = System.Drawing.Color.LightCoral;
            this.label_Operatör.Location = new System.Drawing.Point(0, 0);
            this.label_Operatör.Name = "label_Operatör";
            this.label_Operatör.Size = new System.Drawing.Size(198, 22);
            this.label_Operatör.TabIndex = 4;
            this.label_Operatör.Text = "Operatör som rengör oftast:";
            // 
            // dgv_Huvud
            // 
            this.dgv_Huvud.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Huvud.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_Huvud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Huvud.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_Huvud.Location = new System.Drawing.Point(0, 27);
            this.dgv_Huvud.MaximumSize = new System.Drawing.Size(0, 190);
            this.dgv_Huvud.MinimumSize = new System.Drawing.Size(0, 190);
            this.dgv_Huvud.Name = "dgv_Huvud";
            this.dgv_Huvud.RowHeadersVisible = false;
            this.dgv_Huvud.Size = new System.Drawing.Size(216, 190);
            this.dgv_Huvud.TabIndex = 7;
            // 
            // label_Huvud
            // 
            this.label_Huvud.AutoSize = true;
            this.label_Huvud.BackColor = System.Drawing.Color.Transparent;
            this.label_Huvud.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Huvud.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Huvud.ForeColor = System.Drawing.Color.LightCoral;
            this.label_Huvud.Location = new System.Drawing.Point(0, 0);
            this.label_Huvud.Name = "label_Huvud";
            this.label_Huvud.Size = new System.Drawing.Size(62, 22);
            this.label_Huvud.TabIndex = 6;
            this.label_Huvud.Text = "Huvud:";
            // 
            // dgv_Munstycke
            // 
            this.dgv_Munstycke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Munstycke.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_Munstycke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Munstycke.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_Munstycke.Location = new System.Drawing.Point(0, 27);
            this.dgv_Munstycke.MaximumSize = new System.Drawing.Size(0, 190);
            this.dgv_Munstycke.MinimumSize = new System.Drawing.Size(0, 190);
            this.dgv_Munstycke.Name = "dgv_Munstycke";
            this.dgv_Munstycke.RowHeadersVisible = false;
            this.dgv_Munstycke.Size = new System.Drawing.Size(182, 190);
            this.dgv_Munstycke.TabIndex = 9;
            // 
            // label_Munstycke
            // 
            this.label_Munstycke.AutoSize = true;
            this.label_Munstycke.BackColor = System.Drawing.Color.Transparent;
            this.label_Munstycke.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Munstycke.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Munstycke.ForeColor = System.Drawing.Color.LightCoral;
            this.label_Munstycke.Location = new System.Drawing.Point(0, 0);
            this.label_Munstycke.Name = "label_Munstycke";
            this.label_Munstycke.Size = new System.Drawing.Size(90, 22);
            this.label_Munstycke.TabIndex = 8;
            this.label_Munstycke.Text = "Munstycke:";
            // 
            // dgv_Kärn
            // 
            this.dgv_Kärn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Kärn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_Kärn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Kärn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_Kärn.Location = new System.Drawing.Point(0, 27);
            this.dgv_Kärn.MaximumSize = new System.Drawing.Size(0, 190);
            this.dgv_Kärn.MinimumSize = new System.Drawing.Size(0, 190);
            this.dgv_Kärn.Name = "dgv_Kärn";
            this.dgv_Kärn.RowHeadersVisible = false;
            this.dgv_Kärn.Size = new System.Drawing.Size(200, 190);
            this.dgv_Kärn.TabIndex = 11;
            // 
            // lblKärn
            // 
            this.lblKärn.AutoSize = true;
            this.lblKärn.BackColor = System.Drawing.Color.Transparent;
            this.lblKärn.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKärn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKärn.ForeColor = System.Drawing.Color.LightCoral;
            this.lblKärn.Location = new System.Drawing.Point(0, 0);
            this.lblKärn.Name = "lblKärn";
            this.lblKärn.Size = new System.Drawing.Size(48, 22);
            this.lblKärn.TabIndex = 10;
            this.lblKärn.Text = "Kärn:";
            // 
            // cb_Linje
            // 
            this.cb_Linje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cb_Linje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Linje.Font = new System.Drawing.Font("Palatino Linotype", 10F);
            this.cb_Linje.ForeColor = System.Drawing.Color.LightCoral;
            this.cb_Linje.FormattingEnabled = true;
            this.cb_Linje.Location = new System.Drawing.Point(18, 25);
            this.cb_Linje.Name = "cb_Linje";
            this.cb_Linje.Size = new System.Drawing.Size(230, 26);
            this.cb_Linje.TabIndex = 12;
            this.cb_Linje.SelectedIndexChanged += new System.EventHandler(this.Linje_SelectedIndexChanged);
            // 
            // dgv_Kund
            // 
            this.dgv_Kund.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Kund.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_Kund.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Kund.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_Kund.Location = new System.Drawing.Point(0, 27);
            this.dgv_Kund.MaximumSize = new System.Drawing.Size(0, 190);
            this.dgv_Kund.MinimumSize = new System.Drawing.Size(0, 190);
            this.dgv_Kund.Name = "dgv_Kund";
            this.dgv_Kund.RowHeadersVisible = false;
            this.dgv_Kund.Size = new System.Drawing.Size(244, 190);
            this.dgv_Kund.TabIndex = 14;
            // 
            // label_Kund
            // 
            this.label_Kund.AutoSize = true;
            this.label_Kund.BackColor = System.Drawing.Color.Transparent;
            this.label_Kund.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Kund.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Kund.ForeColor = System.Drawing.Color.LightCoral;
            this.label_Kund.Location = new System.Drawing.Point(0, 0);
            this.label_Kund.Name = "label_Kund";
            this.label_Kund.Size = new System.Drawing.Size(155, 22);
            this.label_Kund.TabIndex = 13;
            this.label_Kund.Text = "Mest frekventa kund:";
            // 
            // dgv_KrympslangsRör
            // 
            this.dgv_KrympslangsRör.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_KrympslangsRör.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_KrympslangsRör.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_KrympslangsRör.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_KrympslangsRör.Location = new System.Drawing.Point(0, 27);
            this.dgv_KrympslangsRör.MinimumSize = new System.Drawing.Size(0, 190);
            this.dgv_KrympslangsRör.Name = "dgv_KrympslangsRör";
            this.dgv_KrympslangsRör.RowHeadersVisible = false;
            this.dgv_KrympslangsRör.Size = new System.Drawing.Size(435, 190);
            this.dgv_KrympslangsRör.TabIndex = 16;
            // 
            // label_KrympslangsRör
            // 
            this.label_KrympslangsRör.AutoSize = true;
            this.label_KrympslangsRör.BackColor = System.Drawing.Color.Transparent;
            this.label_KrympslangsRör.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_KrympslangsRör.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_KrympslangsRör.ForeColor = System.Drawing.Color.LightCoral;
            this.label_KrympslangsRör.Location = new System.Drawing.Point(0, 0);
            this.label_KrympslangsRör.Name = "label_KrympslangsRör";
            this.label_KrympslangsRör.Size = new System.Drawing.Size(125, 22);
            this.label_KrympslangsRör.TabIndex = 15;
            this.label_KrympslangsRör.Text = "Krympslangsrör:";
            // 
            // dgv_KrympslangsLinje
            // 
            this.dgv_KrympslangsLinje.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_KrympslangsLinje.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_KrympslangsLinje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_KrympslangsLinje.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_KrympslangsLinje.Location = new System.Drawing.Point(0, 27);
            this.dgv_KrympslangsLinje.MaximumSize = new System.Drawing.Size(0, 190);
            this.dgv_KrympslangsLinje.MinimumSize = new System.Drawing.Size(0, 190);
            this.dgv_KrympslangsLinje.Name = "dgv_KrympslangsLinje";
            this.dgv_KrympslangsLinje.RowHeadersVisible = false;
            this.dgv_KrympslangsLinje.Size = new System.Drawing.Size(240, 190);
            this.dgv_KrympslangsLinje.TabIndex = 18;
            // 
            // label_krympslangsLinje
            // 
            this.label_krympslangsLinje.AutoSize = true;
            this.label_krympslangsLinje.BackColor = System.Drawing.Color.Transparent;
            this.label_krympslangsLinje.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_krympslangsLinje.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_krympslangsLinje.ForeColor = System.Drawing.Color.LightCoral;
            this.label_krympslangsLinje.Location = new System.Drawing.Point(0, 0);
            this.label_krympslangsLinje.Name = "label_krympslangsLinje";
            this.label_krympslangsLinje.Size = new System.Drawing.Size(133, 22);
            this.label_krympslangsLinje.TabIndex = 17;
            this.label_krympslangsLinje.Text = "Krympslangslinje:";
            // 
            // dgv_Hackhylsa
            // 
            this.dgv_Hackhylsa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Hackhylsa.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_Hackhylsa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Hackhylsa.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_Hackhylsa.Location = new System.Drawing.Point(0, 27);
            this.dgv_Hackhylsa.MaximumSize = new System.Drawing.Size(0, 190);
            this.dgv_Hackhylsa.MinimumSize = new System.Drawing.Size(0, 190);
            this.dgv_Hackhylsa.Name = "dgv_Hackhylsa";
            this.dgv_Hackhylsa.RowHeadersVisible = false;
            this.dgv_Hackhylsa.Size = new System.Drawing.Size(261, 190);
            this.dgv_Hackhylsa.TabIndex = 20;
            // 
            // label_Hackhylsa
            // 
            this.label_Hackhylsa.AutoSize = true;
            this.label_Hackhylsa.BackColor = System.Drawing.Color.Transparent;
            this.label_Hackhylsa.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Hackhylsa.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Hackhylsa.ForeColor = System.Drawing.Color.LightCoral;
            this.label_Hackhylsa.Location = new System.Drawing.Point(0, 0);
            this.label_Hackhylsa.Name = "label_Hackhylsa";
            this.label_Hackhylsa.Size = new System.Drawing.Size(83, 22);
            this.label_Hackhylsa.TabIndex = 19;
            this.label_Hackhylsa.Text = "Hackhylsa";
            // 
            // flp_Main
            // 
            this.flp_Main.Controls.Add(this.panel_Mätningar_Linje);
            this.flp_Main.Controls.Add(this.panel_Operatör_Rengör);
            this.flp_Main.Controls.Add(this.panel_Frekvens_ArtikelNr);
            this.flp_Main.Controls.Add(this.panel_Frekvens_Kund);
            this.flp_Main.Controls.Add(this.panel_Huvud);
            this.flp_Main.Controls.Add(this.panel_Munstycke);
            this.flp_Main.Controls.Add(this.panel_Kärn);
            this.flp_Main.Controls.Add(this.panel_KrympslangsRör);
            this.flp_Main.Controls.Add(this.panel_KrympslangsLinje);
            this.flp_Main.Controls.Add(this.panel_Anslutningsmuff);
            this.flp_Main.Controls.Add(this.panel_Hackhylsa);
            this.flp_Main.Location = new System.Drawing.Point(18, 59);
            this.flp_Main.Name = "flp_Main";
            this.flp_Main.Size = new System.Drawing.Size(1749, 829);
            this.flp_Main.TabIndex = 21;
            // 
            // panel_Mätningar_Linje
            // 
            this.panel_Mätningar_Linje.Controls.Add(this.lbl_Mätningar);
            this.panel_Mätningar_Linje.Controls.Add(this.dgv_Mätningar);
            this.panel_Mätningar_Linje.Location = new System.Drawing.Point(3, 3);
            this.panel_Mätningar_Linje.Name = "panel_Mätningar_Linje";
            this.panel_Mätningar_Linje.Size = new System.Drawing.Size(215, 217);
            this.panel_Mätningar_Linje.TabIndex = 0;
            // 
            // panel_Operatör_Rengör
            // 
            this.panel_Operatör_Rengör.Controls.Add(this.label_Operatör);
            this.panel_Operatör_Rengör.Controls.Add(this.dgv_OperatörRengör);
            this.panel_Operatör_Rengör.Location = new System.Drawing.Point(224, 3);
            this.panel_Operatör_Rengör.MinimumSize = new System.Drawing.Size(0, 190);
            this.panel_Operatör_Rengör.Name = "panel_Operatör_Rengör";
            this.panel_Operatör_Rengör.Size = new System.Drawing.Size(214, 217);
            this.panel_Operatör_Rengör.TabIndex = 1;
            // 
            // panel_Frekvens_ArtikelNr
            // 
            this.panel_Frekvens_ArtikelNr.Controls.Add(this.label_ArtikelNr);
            this.panel_Frekvens_ArtikelNr.Controls.Add(this.dgv_FrekvensArtikelNr);
            this.panel_Frekvens_ArtikelNr.Location = new System.Drawing.Point(444, 3);
            this.panel_Frekvens_ArtikelNr.Name = "panel_Frekvens_ArtikelNr";
            this.panel_Frekvens_ArtikelNr.Size = new System.Drawing.Size(403, 217);
            this.panel_Frekvens_ArtikelNr.TabIndex = 2;
            // 
            // panel_Frekvens_Kund
            // 
            this.panel_Frekvens_Kund.Controls.Add(this.label_Kund);
            this.panel_Frekvens_Kund.Controls.Add(this.dgv_Kund);
            this.panel_Frekvens_Kund.Location = new System.Drawing.Point(853, 3);
            this.panel_Frekvens_Kund.Name = "panel_Frekvens_Kund";
            this.panel_Frekvens_Kund.Size = new System.Drawing.Size(244, 217);
            this.panel_Frekvens_Kund.TabIndex = 3;
            // 
            // panel_Huvud
            // 
            this.panel_Huvud.Controls.Add(this.label_Huvud);
            this.panel_Huvud.Controls.Add(this.dgv_Huvud);
            this.panel_Huvud.Location = new System.Drawing.Point(1103, 3);
            this.panel_Huvud.Name = "panel_Huvud";
            this.panel_Huvud.Size = new System.Drawing.Size(216, 217);
            this.panel_Huvud.TabIndex = 4;
            // 
            // panel_Munstycke
            // 
            this.panel_Munstycke.Controls.Add(this.label_Munstycke);
            this.panel_Munstycke.Controls.Add(this.dgv_Munstycke);
            this.panel_Munstycke.Location = new System.Drawing.Point(1325, 3);
            this.panel_Munstycke.Name = "panel_Munstycke";
            this.panel_Munstycke.Size = new System.Drawing.Size(182, 217);
            this.panel_Munstycke.TabIndex = 5;
            // 
            // panel_Kärn
            // 
            this.panel_Kärn.Controls.Add(this.lblKärn);
            this.panel_Kärn.Controls.Add(this.dgv_Kärn);
            this.panel_Kärn.Location = new System.Drawing.Point(1513, 3);
            this.panel_Kärn.Name = "panel_Kärn";
            this.panel_Kärn.Size = new System.Drawing.Size(200, 217);
            this.panel_Kärn.TabIndex = 6;
            // 
            // panel_KrympslangsRör
            // 
            this.panel_KrympslangsRör.Controls.Add(this.label_KrympslangsRör);
            this.panel_KrympslangsRör.Controls.Add(this.dgv_KrympslangsRör);
            this.panel_KrympslangsRör.Location = new System.Drawing.Point(3, 226);
            this.panel_KrympslangsRör.Name = "panel_KrympslangsRör";
            this.panel_KrympslangsRör.Size = new System.Drawing.Size(435, 217);
            this.panel_KrympslangsRör.TabIndex = 7;
            // 
            // panel_KrympslangsLinje
            // 
            this.panel_KrympslangsLinje.Controls.Add(this.label_krympslangsLinje);
            this.panel_KrympslangsLinje.Controls.Add(this.dgv_KrympslangsLinje);
            this.panel_KrympslangsLinje.Location = new System.Drawing.Point(444, 226);
            this.panel_KrympslangsLinje.Name = "panel_KrympslangsLinje";
            this.panel_KrympslangsLinje.Size = new System.Drawing.Size(240, 217);
            this.panel_KrympslangsLinje.TabIndex = 8;
            // 
            // panel_Anslutningsmuff
            // 
            this.panel_Anslutningsmuff.Controls.Add(this.label_Anslutningsmuff);
            this.panel_Anslutningsmuff.Controls.Add(this.dgv_Anslutningsmuff);
            this.panel_Anslutningsmuff.Location = new System.Drawing.Point(690, 226);
            this.panel_Anslutningsmuff.Name = "panel_Anslutningsmuff";
            this.panel_Anslutningsmuff.Size = new System.Drawing.Size(261, 217);
            this.panel_Anslutningsmuff.TabIndex = 21;
            // 
            // label_Anslutningsmuff
            // 
            this.label_Anslutningsmuff.AutoSize = true;
            this.label_Anslutningsmuff.BackColor = System.Drawing.Color.Transparent;
            this.label_Anslutningsmuff.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Anslutningsmuff.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Anslutningsmuff.ForeColor = System.Drawing.Color.LightCoral;
            this.label_Anslutningsmuff.Location = new System.Drawing.Point(0, 0);
            this.label_Anslutningsmuff.Name = "label_Anslutningsmuff";
            this.label_Anslutningsmuff.Size = new System.Drawing.Size(124, 22);
            this.label_Anslutningsmuff.TabIndex = 19;
            this.label_Anslutningsmuff.Text = "Anslutningsmuff";
            // 
            // dgv_Anslutningsmuff
            // 
            this.dgv_Anslutningsmuff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Anslutningsmuff.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_Anslutningsmuff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Anslutningsmuff.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_Anslutningsmuff.Location = new System.Drawing.Point(0, 27);
            this.dgv_Anslutningsmuff.MaximumSize = new System.Drawing.Size(0, 190);
            this.dgv_Anslutningsmuff.MinimumSize = new System.Drawing.Size(0, 190);
            this.dgv_Anslutningsmuff.Name = "dgv_Anslutningsmuff";
            this.dgv_Anslutningsmuff.RowHeadersVisible = false;
            this.dgv_Anslutningsmuff.Size = new System.Drawing.Size(261, 190);
            this.dgv_Anslutningsmuff.TabIndex = 20;
            // 
            // panel_Hackhylsa
            // 
            this.panel_Hackhylsa.Controls.Add(this.label_Hackhylsa);
            this.panel_Hackhylsa.Controls.Add(this.dgv_Hackhylsa);
            this.panel_Hackhylsa.Location = new System.Drawing.Point(957, 226);
            this.panel_Hackhylsa.Name = "panel_Hackhylsa";
            this.panel_Hackhylsa.Size = new System.Drawing.Size(261, 217);
            this.panel_Hackhylsa.TabIndex = 9;
            // 
            // date_From
            // 
            this.date_From.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.date_From.Font = new System.Drawing.Font("Palatino Linotype", 10F);
            this.date_From.Location = new System.Drawing.Point(276, 25);
            this.date_From.Name = "date_From";
            this.date_From.Size = new System.Drawing.Size(200, 25);
            this.date_From.TabIndex = 22;
            this.date_From.Value = new System.DateTime(2009, 1, 21, 0, 0, 0, 0);
            this.date_From.ValueChanged += new System.EventHandler(this.Linje_SelectedIndexChanged);
            // 
            // date_To
            // 
            this.date_To.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.date_To.Font = new System.Drawing.Font("Palatino Linotype", 10F);
            this.date_To.Location = new System.Drawing.Point(491, 25);
            this.date_To.Name = "date_To";
            this.date_To.Size = new System.Drawing.Size(200, 25);
            this.date_To.TabIndex = 22;
            this.date_To.ValueChanged += new System.EventHandler(this.Linje_SelectedIndexChanged);
            // 
            // label_Datum_Från
            // 
            this.label_Datum_Från.AutoSize = true;
            this.label_Datum_Från.Font = new System.Drawing.Font("Palatino Linotype", 10F);
            this.label_Datum_Från.ForeColor = System.Drawing.Color.OliveDrab;
            this.label_Datum_Från.Location = new System.Drawing.Point(276, 2);
            this.label_Datum_Från.Name = "label_Datum_Från";
            this.label_Datum_Från.Size = new System.Drawing.Size(39, 19);
            this.label_Datum_Från.TabIndex = 23;
            this.label_Datum_Från.Text = "Från";
            // 
            // label_Datum_Till
            // 
            this.label_Datum_Till.AutoSize = true;
            this.label_Datum_Till.Font = new System.Drawing.Font("Palatino Linotype", 10F);
            this.label_Datum_Till.ForeColor = System.Drawing.Color.OliveDrab;
            this.label_Datum_Till.Location = new System.Drawing.Point(497, 1);
            this.label_Datum_Till.Name = "label_Datum_Till";
            this.label_Datum_Till.Size = new System.Drawing.Size(30, 19);
            this.label_Datum_Till.TabIndex = 23;
            this.label_Datum_Till.Text = "Till";
            // 
            // label_Linje
            // 
            this.label_Linje.AutoSize = true;
            this.label_Linje.Font = new System.Drawing.Font("Palatino Linotype", 10F);
            this.label_Linje.ForeColor = System.Drawing.Color.OliveDrab;
            this.label_Linje.Location = new System.Drawing.Point(21, 2);
            this.label_Linje.Name = "label_Linje";
            this.label_Linje.Size = new System.Drawing.Size(76, 19);
            this.label_Linje.TabIndex = 23;
            this.label_Linje.Text = "Välj linje...";
            // 
            // ProductionLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1792, 900);
            this.Controls.Add(this.label_Datum_Till);
            this.Controls.Add(this.label_Linje);
            this.Controls.Add(this.label_Datum_Från);
            this.Controls.Add(this.date_To);
            this.Controls.Add(this.date_From);
            this.Controls.Add(this.flp_Main);
            this.Controls.Add(this.cb_Linje);
            this.Name = "ProductionLines";
            this.Text = "ProduktionsLinje";
            this.Load += new System.EventHandler(this.ProduktionsLinje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mätningar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FrekvensArtikelNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OperatörRengör)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Huvud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Munstycke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kärn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KrympslangsRör)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KrympslangsLinje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Hackhylsa)).EndInit();
            this.flp_Main.ResumeLayout(false);
            this.panel_Mätningar_Linje.ResumeLayout(false);
            this.panel_Mätningar_Linje.PerformLayout();
            this.panel_Operatör_Rengör.ResumeLayout(false);
            this.panel_Operatör_Rengör.PerformLayout();
            this.panel_Frekvens_ArtikelNr.ResumeLayout(false);
            this.panel_Frekvens_ArtikelNr.PerformLayout();
            this.panel_Frekvens_Kund.ResumeLayout(false);
            this.panel_Frekvens_Kund.PerformLayout();
            this.panel_Huvud.ResumeLayout(false);
            this.panel_Huvud.PerformLayout();
            this.panel_Munstycke.ResumeLayout(false);
            this.panel_Munstycke.PerformLayout();
            this.panel_Kärn.ResumeLayout(false);
            this.panel_Kärn.PerformLayout();
            this.panel_KrympslangsRör.ResumeLayout(false);
            this.panel_KrympslangsRör.PerformLayout();
            this.panel_KrympslangsLinje.ResumeLayout(false);
            this.panel_KrympslangsLinje.PerformLayout();
            this.panel_Anslutningsmuff.ResumeLayout(false);
            this.panel_Anslutningsmuff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Anslutningsmuff)).EndInit();
            this.panel_Hackhylsa.ResumeLayout(false);
            this.panel_Hackhylsa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgv_Mätningar;
        private Label lbl_Mätningar;
        private DataGridView dgv_FrekvensArtikelNr;
        private Label label_ArtikelNr;
        private DataGridView dgv_OperatörRengör;
        private Label label_Operatör;
        private DataGridView dgv_Huvud;
        private Label label_Huvud;
        private DataGridView dgv_Munstycke;
        private Label label_Munstycke;
        private DataGridView dgv_Kärn;
        private Label lblKärn;
        private ComboBox cb_Linje;
        private DataGridView dgv_Kund;
        private Label label_Kund;
        private DataGridView dgv_KrympslangsRör;
        private Label label_KrympslangsRör;
        private DataGridView dgv_KrympslangsLinje;
        private Label label_krympslangsLinje;
        private DataGridView dgv_Hackhylsa;
        private Label label_Hackhylsa;
        private FlowLayoutPanel flp_Main;
        private Panel panel_Mätningar_Linje;
        private Panel panel_Operatör_Rengör;
        private Panel panel_Frekvens_ArtikelNr;
        private Panel panel_Frekvens_Kund;
        private Panel panel_Huvud;
        private Panel panel_Munstycke;
        private Panel panel_Kärn;
        private Panel panel_KrympslangsRör;
        private Panel panel_KrympslangsLinje;
        private Panel panel_Hackhylsa;
        private DateTimePicker date_From;
        private DateTimePicker date_To;
        private Label label_Datum_Från;
        private Label label_Datum_Till;
        private Label label_Linje;
        private Panel panel_Anslutningsmuff;
        private Label label_Anslutningsmuff;
        private DataGridView dgv_Anslutningsmuff;
    }
}