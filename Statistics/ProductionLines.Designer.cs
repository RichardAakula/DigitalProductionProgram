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
            dgv_Mätningar = new DataGridView();
            lbl_Mätningar = new Label();
            dgv_FrekvensArtikelNr = new DataGridView();
            label_ArtikelNr = new Label();
            dgv_OperatörRengör = new DataGridView();
            label_Operatör = new Label();
            dgv_Huvud = new DataGridView();
            label_Huvud = new Label();
            dgv_Munstycke = new DataGridView();
            label_Munstycke = new Label();
            dgv_Kärn = new DataGridView();
            lblKärn = new Label();
            cb_Linje = new ComboBox();
            dgv_Kund = new DataGridView();
            label_Kund = new Label();
            dgv_KrympslangsRör = new DataGridView();
            label_KrympslangsRör = new Label();
            dgv_KrympslangsLinje = new DataGridView();
            label_krympslangsLinje = new Label();
            dgv_Hackhylsa = new DataGridView();
            label_Hackhylsa = new Label();
            flp_Main = new FlowLayoutPanel();
            panel_Mätningar_Linje = new Panel();
            panel_Operatör_Rengör = new Panel();
            panel_Frekvens_ArtikelNr = new Panel();
            panel_Frekvens_Kund = new Panel();
            panel_Huvud = new Panel();
            panel_Munstycke = new Panel();
            panel_Kärn = new Panel();
            panel_KrympslangsRör = new Panel();
            panel_KrympslangsLinje = new Panel();
            panel_Anslutningsmuff = new Panel();
            label_Anslutningsmuff = new Label();
            dgv_Anslutningsmuff = new DataGridView();
            panel_Hackhylsa = new Panel();
            date_From = new DateTimePicker();
            date_To = new DateTimePicker();
            label_Datum_Från = new Label();
            label_Datum_Till = new Label();
            label_Linje = new Label();
            ((ISupportInitialize)dgv_Mätningar).BeginInit();
            ((ISupportInitialize)dgv_FrekvensArtikelNr).BeginInit();
            ((ISupportInitialize)dgv_OperatörRengör).BeginInit();
            ((ISupportInitialize)dgv_Huvud).BeginInit();
            ((ISupportInitialize)dgv_Munstycke).BeginInit();
            ((ISupportInitialize)dgv_Kärn).BeginInit();
            ((ISupportInitialize)dgv_Kund).BeginInit();
            ((ISupportInitialize)dgv_KrympslangsRör).BeginInit();
            ((ISupportInitialize)dgv_KrympslangsLinje).BeginInit();
            ((ISupportInitialize)dgv_Hackhylsa).BeginInit();
            flp_Main.SuspendLayout();
            panel_Mätningar_Linje.SuspendLayout();
            panel_Operatör_Rengör.SuspendLayout();
            panel_Frekvens_ArtikelNr.SuspendLayout();
            panel_Frekvens_Kund.SuspendLayout();
            panel_Huvud.SuspendLayout();
            panel_Munstycke.SuspendLayout();
            panel_Kärn.SuspendLayout();
            panel_KrympslangsRör.SuspendLayout();
            panel_KrympslangsLinje.SuspendLayout();
            panel_Anslutningsmuff.SuspendLayout();
            ((ISupportInitialize)dgv_Anslutningsmuff).BeginInit();
            panel_Hackhylsa.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_Mätningar
            // 
            dgv_Mätningar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Mätningar.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_Mätningar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Mätningar.Dock = DockStyle.Bottom;
            dgv_Mätningar.Location = new Point(0, 31);
            dgv_Mätningar.Margin = new Padding(4, 3, 4, 3);
            dgv_Mätningar.MaximumSize = new Size(0, 222);
            dgv_Mätningar.Name = "dgv_Mätningar";
            dgv_Mätningar.RowHeadersVisible = false;
            dgv_Mätningar.Size = new Size(251, 219);
            dgv_Mätningar.TabIndex = 2;
            // 
            // lbl_Mätningar
            // 
            lbl_Mätningar.AutoSize = true;
            lbl_Mätningar.BackColor = Color.Transparent;
            lbl_Mätningar.Dock = DockStyle.Top;
            lbl_Mätningar.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Mätningar.ForeColor = Color.LightCoral;
            lbl_Mätningar.Location = new Point(0, 0);
            lbl_Mätningar.Margin = new Padding(4, 0, 4, 0);
            lbl_Mätningar.Name = "lbl_Mätningar";
            lbl_Mätningar.Size = new Size(136, 22);
            lbl_Mätningar.TabIndex = 0;
            lbl_Mätningar.Text = "Mätningar i linjen:";
            // 
            // dgv_FrekvensArtikelNr
            // 
            dgv_FrekvensArtikelNr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_FrekvensArtikelNr.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_FrekvensArtikelNr.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_FrekvensArtikelNr.Dock = DockStyle.Bottom;
            dgv_FrekvensArtikelNr.Location = new Point(0, 31);
            dgv_FrekvensArtikelNr.Margin = new Padding(4, 3, 4, 3);
            dgv_FrekvensArtikelNr.MaximumSize = new Size(0, 219);
            dgv_FrekvensArtikelNr.MinimumSize = new Size(0, 219);
            dgv_FrekvensArtikelNr.Name = "dgv_FrekvensArtikelNr";
            dgv_FrekvensArtikelNr.RowHeadersVisible = false;
            dgv_FrekvensArtikelNr.Size = new Size(470, 219);
            dgv_FrekvensArtikelNr.TabIndex = 3;
            // 
            // label_ArtikelNr
            // 
            label_ArtikelNr.AutoSize = true;
            label_ArtikelNr.BackColor = Color.Transparent;
            label_ArtikelNr.Dock = DockStyle.Top;
            label_ArtikelNr.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ArtikelNr.ForeColor = Color.LightCoral;
            label_ArtikelNr.Location = new Point(0, 0);
            label_ArtikelNr.Margin = new Padding(4, 0, 4, 0);
            label_ArtikelNr.Name = "label_ArtikelNr";
            label_ArtikelNr.Size = new Size(181, 22);
            label_ArtikelNr.TabIndex = 0;
            label_ArtikelNr.Text = "Mest frekventa artikelNr:";
            // 
            // dgv_OperatörRengör
            // 
            dgv_OperatörRengör.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_OperatörRengör.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_OperatörRengör.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_OperatörRengör.Dock = DockStyle.Bottom;
            dgv_OperatörRengör.Location = new Point(0, 31);
            dgv_OperatörRengör.Margin = new Padding(4, 3, 4, 3);
            dgv_OperatörRengör.MaximumSize = new Size(0, 219);
            dgv_OperatörRengör.MinimumSize = new Size(0, 219);
            dgv_OperatörRengör.Name = "dgv_OperatörRengör";
            dgv_OperatörRengör.RowHeadersVisible = false;
            dgv_OperatörRengör.Size = new Size(250, 219);
            dgv_OperatörRengör.TabIndex = 5;
            // 
            // label_Operatör
            // 
            label_Operatör.AutoSize = true;
            label_Operatör.Dock = DockStyle.Top;
            label_Operatör.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Operatör.ForeColor = Color.LightCoral;
            label_Operatör.Location = new Point(0, 0);
            label_Operatör.Margin = new Padding(4, 0, 4, 0);
            label_Operatör.Name = "label_Operatör";
            label_Operatör.Size = new Size(198, 22);
            label_Operatör.TabIndex = 4;
            label_Operatör.Text = "Operatör som rengör oftast:";
            // 
            // dgv_Huvud
            // 
            dgv_Huvud.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Huvud.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_Huvud.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Huvud.Dock = DockStyle.Bottom;
            dgv_Huvud.Location = new Point(0, 31);
            dgv_Huvud.Margin = new Padding(4, 3, 4, 3);
            dgv_Huvud.MaximumSize = new Size(0, 219);
            dgv_Huvud.MinimumSize = new Size(0, 219);
            dgv_Huvud.Name = "dgv_Huvud";
            dgv_Huvud.RowHeadersVisible = false;
            dgv_Huvud.Size = new Size(252, 219);
            dgv_Huvud.TabIndex = 7;
            // 
            // label_Huvud
            // 
            label_Huvud.AutoSize = true;
            label_Huvud.BackColor = Color.Transparent;
            label_Huvud.Dock = DockStyle.Top;
            label_Huvud.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Huvud.ForeColor = Color.LightCoral;
            label_Huvud.Location = new Point(0, 0);
            label_Huvud.Margin = new Padding(4, 0, 4, 0);
            label_Huvud.Name = "label_Huvud";
            label_Huvud.Size = new Size(62, 22);
            label_Huvud.TabIndex = 6;
            label_Huvud.Text = "Huvud:";
            // 
            // dgv_Munstycke
            // 
            dgv_Munstycke.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Munstycke.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_Munstycke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Munstycke.Dock = DockStyle.Bottom;
            dgv_Munstycke.Location = new Point(0, 31);
            dgv_Munstycke.Margin = new Padding(4, 3, 4, 3);
            dgv_Munstycke.MaximumSize = new Size(0, 219);
            dgv_Munstycke.MinimumSize = new Size(0, 219);
            dgv_Munstycke.Name = "dgv_Munstycke";
            dgv_Munstycke.RowHeadersVisible = false;
            dgv_Munstycke.Size = new Size(212, 219);
            dgv_Munstycke.TabIndex = 9;
            // 
            // label_Munstycke
            // 
            label_Munstycke.AutoSize = true;
            label_Munstycke.BackColor = Color.Transparent;
            label_Munstycke.Dock = DockStyle.Top;
            label_Munstycke.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Munstycke.ForeColor = Color.LightCoral;
            label_Munstycke.Location = new Point(0, 0);
            label_Munstycke.Margin = new Padding(4, 0, 4, 0);
            label_Munstycke.Name = "label_Munstycke";
            label_Munstycke.Size = new Size(90, 22);
            label_Munstycke.TabIndex = 8;
            label_Munstycke.Text = "Munstycke:";
            // 
            // dgv_Kärn
            // 
            dgv_Kärn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Kärn.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_Kärn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Kärn.Dock = DockStyle.Bottom;
            dgv_Kärn.Location = new Point(0, 31);
            dgv_Kärn.Margin = new Padding(4, 3, 4, 3);
            dgv_Kärn.MaximumSize = new Size(0, 219);
            dgv_Kärn.MinimumSize = new Size(0, 219);
            dgv_Kärn.Name = "dgv_Kärn";
            dgv_Kärn.RowHeadersVisible = false;
            dgv_Kärn.Size = new Size(233, 219);
            dgv_Kärn.TabIndex = 11;
            // 
            // lblKärn
            // 
            lblKärn.AutoSize = true;
            lblKärn.BackColor = Color.Transparent;
            lblKärn.Dock = DockStyle.Top;
            lblKärn.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKärn.ForeColor = Color.LightCoral;
            lblKärn.Location = new Point(0, 0);
            lblKärn.Margin = new Padding(4, 0, 4, 0);
            lblKärn.Name = "lblKärn";
            lblKärn.Size = new Size(48, 22);
            lblKärn.TabIndex = 10;
            lblKärn.Text = "Kärn:";
            // 
            // cb_Linje
            // 
            cb_Linje.BackColor = Color.FromArgb(45, 45, 45);
            cb_Linje.FlatStyle = FlatStyle.Flat;
            cb_Linje.Font = new Font("Palatino Linotype", 10F);
            cb_Linje.ForeColor = Color.LightCoral;
            cb_Linje.FormattingEnabled = true;
            cb_Linje.Location = new Point(21, 29);
            cb_Linje.Margin = new Padding(4, 3, 4, 3);
            cb_Linje.Name = "cb_Linje";
            cb_Linje.Size = new Size(268, 26);
            cb_Linje.TabIndex = 12;
            cb_Linje.SelectedIndexChanged += Linje_SelectedIndexChanged;
            // 
            // dgv_Kund
            // 
            dgv_Kund.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Kund.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_Kund.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Kund.Dock = DockStyle.Bottom;
            dgv_Kund.Location = new Point(0, 31);
            dgv_Kund.Margin = new Padding(4, 3, 4, 3);
            dgv_Kund.MaximumSize = new Size(0, 219);
            dgv_Kund.MinimumSize = new Size(0, 219);
            dgv_Kund.Name = "dgv_Kund";
            dgv_Kund.RowHeadersVisible = false;
            dgv_Kund.Size = new Size(285, 219);
            dgv_Kund.TabIndex = 14;
            // 
            // label_Kund
            // 
            label_Kund.AutoSize = true;
            label_Kund.BackColor = Color.Transparent;
            label_Kund.Dock = DockStyle.Top;
            label_Kund.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Kund.ForeColor = Color.LightCoral;
            label_Kund.Location = new Point(0, 0);
            label_Kund.Margin = new Padding(4, 0, 4, 0);
            label_Kund.Name = "label_Kund";
            label_Kund.Size = new Size(155, 22);
            label_Kund.TabIndex = 13;
            label_Kund.Text = "Mest frekventa kund:";
            // 
            // dgv_KrympslangsRör
            // 
            dgv_KrympslangsRör.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_KrympslangsRör.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_KrympslangsRör.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_KrympslangsRör.Dock = DockStyle.Bottom;
            dgv_KrympslangsRör.Location = new Point(0, 31);
            dgv_KrympslangsRör.Margin = new Padding(4, 3, 4, 3);
            dgv_KrympslangsRör.MinimumSize = new Size(0, 219);
            dgv_KrympslangsRör.Name = "dgv_KrympslangsRör";
            dgv_KrympslangsRör.RowHeadersVisible = false;
            dgv_KrympslangsRör.Size = new Size(507, 219);
            dgv_KrympslangsRör.TabIndex = 16;
            // 
            // label_KrympslangsRör
            // 
            label_KrympslangsRör.AutoSize = true;
            label_KrympslangsRör.BackColor = Color.Transparent;
            label_KrympslangsRör.Dock = DockStyle.Top;
            label_KrympslangsRör.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_KrympslangsRör.ForeColor = Color.LightCoral;
            label_KrympslangsRör.Location = new Point(0, 0);
            label_KrympslangsRör.Margin = new Padding(4, 0, 4, 0);
            label_KrympslangsRör.Name = "label_KrympslangsRör";
            label_KrympslangsRör.Size = new Size(125, 22);
            label_KrympslangsRör.TabIndex = 15;
            label_KrympslangsRör.Text = "Krympslangsrör:";
            // 
            // dgv_KrympslangsLinje
            // 
            dgv_KrympslangsLinje.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_KrympslangsLinje.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_KrympslangsLinje.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_KrympslangsLinje.Dock = DockStyle.Bottom;
            dgv_KrympslangsLinje.Location = new Point(0, 31);
            dgv_KrympslangsLinje.Margin = new Padding(4, 3, 4, 3);
            dgv_KrympslangsLinje.MaximumSize = new Size(0, 219);
            dgv_KrympslangsLinje.MinimumSize = new Size(0, 219);
            dgv_KrympslangsLinje.Name = "dgv_KrympslangsLinje";
            dgv_KrympslangsLinje.RowHeadersVisible = false;
            dgv_KrympslangsLinje.Size = new Size(280, 219);
            dgv_KrympslangsLinje.TabIndex = 18;
            // 
            // label_krympslangsLinje
            // 
            label_krympslangsLinje.AutoSize = true;
            label_krympslangsLinje.BackColor = Color.Transparent;
            label_krympslangsLinje.Dock = DockStyle.Top;
            label_krympslangsLinje.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_krympslangsLinje.ForeColor = Color.LightCoral;
            label_krympslangsLinje.Location = new Point(0, 0);
            label_krympslangsLinje.Margin = new Padding(4, 0, 4, 0);
            label_krympslangsLinje.Name = "label_krympslangsLinje";
            label_krympslangsLinje.Size = new Size(133, 22);
            label_krympslangsLinje.TabIndex = 17;
            label_krympslangsLinje.Text = "Krympslangslinje:";
            // 
            // dgv_Hackhylsa
            // 
            dgv_Hackhylsa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Hackhylsa.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_Hackhylsa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Hackhylsa.Dock = DockStyle.Bottom;
            dgv_Hackhylsa.Location = new Point(0, 31);
            dgv_Hackhylsa.Margin = new Padding(4, 3, 4, 3);
            dgv_Hackhylsa.MaximumSize = new Size(0, 219);
            dgv_Hackhylsa.MinimumSize = new Size(0, 219);
            dgv_Hackhylsa.Name = "dgv_Hackhylsa";
            dgv_Hackhylsa.RowHeadersVisible = false;
            dgv_Hackhylsa.Size = new Size(304, 219);
            dgv_Hackhylsa.TabIndex = 20;
            // 
            // label_Hackhylsa
            // 
            label_Hackhylsa.AutoSize = true;
            label_Hackhylsa.BackColor = Color.Transparent;
            label_Hackhylsa.Dock = DockStyle.Top;
            label_Hackhylsa.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Hackhylsa.ForeColor = Color.LightCoral;
            label_Hackhylsa.Location = new Point(0, 0);
            label_Hackhylsa.Margin = new Padding(4, 0, 4, 0);
            label_Hackhylsa.Name = "label_Hackhylsa";
            label_Hackhylsa.Size = new Size(83, 22);
            label_Hackhylsa.TabIndex = 19;
            label_Hackhylsa.Text = "Hackhylsa";
            // 
            // flp_Main
            // 
            flp_Main.Controls.Add(panel_Mätningar_Linje);
            flp_Main.Controls.Add(panel_Operatör_Rengör);
            flp_Main.Controls.Add(panel_Frekvens_ArtikelNr);
            flp_Main.Controls.Add(panel_Frekvens_Kund);
            flp_Main.Controls.Add(panel_Huvud);
            flp_Main.Controls.Add(panel_Munstycke);
            flp_Main.Controls.Add(panel_Kärn);
            flp_Main.Controls.Add(panel_KrympslangsRör);
            flp_Main.Controls.Add(panel_KrympslangsLinje);
            flp_Main.Controls.Add(panel_Anslutningsmuff);
            flp_Main.Controls.Add(panel_Hackhylsa);
            flp_Main.Location = new Point(21, 68);
            flp_Main.Margin = new Padding(4, 3, 4, 3);
            flp_Main.Name = "flp_Main";
            flp_Main.Size = new Size(2040, 957);
            flp_Main.TabIndex = 21;
            // 
            // panel_Mätningar_Linje
            // 
            panel_Mätningar_Linje.Controls.Add(lbl_Mätningar);
            panel_Mätningar_Linje.Controls.Add(dgv_Mätningar);
            panel_Mätningar_Linje.Location = new Point(4, 3);
            panel_Mätningar_Linje.Margin = new Padding(4, 3, 4, 3);
            panel_Mätningar_Linje.Name = "panel_Mätningar_Linje";
            panel_Mätningar_Linje.Size = new Size(251, 250);
            panel_Mätningar_Linje.TabIndex = 0;
            // 
            // panel_Operatör_Rengör
            // 
            panel_Operatör_Rengör.Controls.Add(label_Operatör);
            panel_Operatör_Rengör.Controls.Add(dgv_OperatörRengör);
            panel_Operatör_Rengör.Location = new Point(263, 3);
            panel_Operatör_Rengör.Margin = new Padding(4, 3, 4, 3);
            panel_Operatör_Rengör.MinimumSize = new Size(0, 219);
            panel_Operatör_Rengör.Name = "panel_Operatör_Rengör";
            panel_Operatör_Rengör.Size = new Size(250, 250);
            panel_Operatör_Rengör.TabIndex = 1;
            // 
            // panel_Frekvens_ArtikelNr
            // 
            panel_Frekvens_ArtikelNr.Controls.Add(label_ArtikelNr);
            panel_Frekvens_ArtikelNr.Controls.Add(dgv_FrekvensArtikelNr);
            panel_Frekvens_ArtikelNr.Location = new Point(521, 3);
            panel_Frekvens_ArtikelNr.Margin = new Padding(4, 3, 4, 3);
            panel_Frekvens_ArtikelNr.Name = "panel_Frekvens_ArtikelNr";
            panel_Frekvens_ArtikelNr.Size = new Size(470, 250);
            panel_Frekvens_ArtikelNr.TabIndex = 2;
            // 
            // panel_Frekvens_Kund
            // 
            panel_Frekvens_Kund.Controls.Add(label_Kund);
            panel_Frekvens_Kund.Controls.Add(dgv_Kund);
            panel_Frekvens_Kund.Location = new Point(999, 3);
            panel_Frekvens_Kund.Margin = new Padding(4, 3, 4, 3);
            panel_Frekvens_Kund.Name = "panel_Frekvens_Kund";
            panel_Frekvens_Kund.Size = new Size(285, 250);
            panel_Frekvens_Kund.TabIndex = 3;
            // 
            // panel_Huvud
            // 
            panel_Huvud.Controls.Add(label_Huvud);
            panel_Huvud.Controls.Add(dgv_Huvud);
            panel_Huvud.Location = new Point(1292, 3);
            panel_Huvud.Margin = new Padding(4, 3, 4, 3);
            panel_Huvud.Name = "panel_Huvud";
            panel_Huvud.Size = new Size(252, 250);
            panel_Huvud.TabIndex = 4;
            // 
            // panel_Munstycke
            // 
            panel_Munstycke.Controls.Add(label_Munstycke);
            panel_Munstycke.Controls.Add(dgv_Munstycke);
            panel_Munstycke.Location = new Point(1552, 3);
            panel_Munstycke.Margin = new Padding(4, 3, 4, 3);
            panel_Munstycke.Name = "panel_Munstycke";
            panel_Munstycke.Size = new Size(212, 250);
            panel_Munstycke.TabIndex = 5;
            // 
            // panel_Kärn
            // 
            panel_Kärn.Controls.Add(lblKärn);
            panel_Kärn.Controls.Add(dgv_Kärn);
            panel_Kärn.Location = new Point(1772, 3);
            panel_Kärn.Margin = new Padding(4, 3, 4, 3);
            panel_Kärn.Name = "panel_Kärn";
            panel_Kärn.Size = new Size(233, 250);
            panel_Kärn.TabIndex = 6;
            // 
            // panel_KrympslangsRör
            // 
            panel_KrympslangsRör.Controls.Add(label_KrympslangsRör);
            panel_KrympslangsRör.Controls.Add(dgv_KrympslangsRör);
            panel_KrympslangsRör.Location = new Point(4, 259);
            panel_KrympslangsRör.Margin = new Padding(4, 3, 4, 3);
            panel_KrympslangsRör.Name = "panel_KrympslangsRör";
            panel_KrympslangsRör.Size = new Size(507, 250);
            panel_KrympslangsRör.TabIndex = 7;
            // 
            // panel_KrympslangsLinje
            // 
            panel_KrympslangsLinje.Controls.Add(label_krympslangsLinje);
            panel_KrympslangsLinje.Controls.Add(dgv_KrympslangsLinje);
            panel_KrympslangsLinje.Location = new Point(519, 259);
            panel_KrympslangsLinje.Margin = new Padding(4, 3, 4, 3);
            panel_KrympslangsLinje.Name = "panel_KrympslangsLinje";
            panel_KrympslangsLinje.Size = new Size(280, 250);
            panel_KrympslangsLinje.TabIndex = 8;
            // 
            // panel_Anslutningsmuff
            // 
            panel_Anslutningsmuff.Controls.Add(label_Anslutningsmuff);
            panel_Anslutningsmuff.Controls.Add(dgv_Anslutningsmuff);
            panel_Anslutningsmuff.Location = new Point(807, 259);
            panel_Anslutningsmuff.Margin = new Padding(4, 3, 4, 3);
            panel_Anslutningsmuff.Name = "panel_Anslutningsmuff";
            panel_Anslutningsmuff.Size = new Size(304, 250);
            panel_Anslutningsmuff.TabIndex = 21;
            // 
            // label_Anslutningsmuff
            // 
            label_Anslutningsmuff.AutoSize = true;
            label_Anslutningsmuff.BackColor = Color.Transparent;
            label_Anslutningsmuff.Dock = DockStyle.Top;
            label_Anslutningsmuff.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Anslutningsmuff.ForeColor = Color.LightCoral;
            label_Anslutningsmuff.Location = new Point(0, 0);
            label_Anslutningsmuff.Margin = new Padding(4, 0, 4, 0);
            label_Anslutningsmuff.Name = "label_Anslutningsmuff";
            label_Anslutningsmuff.Size = new Size(124, 22);
            label_Anslutningsmuff.TabIndex = 19;
            label_Anslutningsmuff.Text = "Anslutningsmuff";
            // 
            // dgv_Anslutningsmuff
            // 
            dgv_Anslutningsmuff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Anslutningsmuff.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv_Anslutningsmuff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Anslutningsmuff.Dock = DockStyle.Bottom;
            dgv_Anslutningsmuff.Location = new Point(0, 31);
            dgv_Anslutningsmuff.Margin = new Padding(4, 3, 4, 3);
            dgv_Anslutningsmuff.MaximumSize = new Size(0, 219);
            dgv_Anslutningsmuff.MinimumSize = new Size(0, 219);
            dgv_Anslutningsmuff.Name = "dgv_Anslutningsmuff";
            dgv_Anslutningsmuff.RowHeadersVisible = false;
            dgv_Anslutningsmuff.Size = new Size(304, 219);
            dgv_Anslutningsmuff.TabIndex = 20;
            // 
            // panel_Hackhylsa
            // 
            panel_Hackhylsa.Controls.Add(label_Hackhylsa);
            panel_Hackhylsa.Controls.Add(dgv_Hackhylsa);
            panel_Hackhylsa.Location = new Point(1119, 259);
            panel_Hackhylsa.Margin = new Padding(4, 3, 4, 3);
            panel_Hackhylsa.Name = "panel_Hackhylsa";
            panel_Hackhylsa.Size = new Size(304, 250);
            panel_Hackhylsa.TabIndex = 9;
            // 
            // date_From
            // 
            date_From.CalendarMonthBackground = Color.FromArgb(45, 45, 45);
            date_From.Font = new Font("Palatino Linotype", 10F);
            date_From.Location = new Point(322, 29);
            date_From.Margin = new Padding(4, 3, 4, 3);
            date_From.Name = "date_From";
            date_From.Size = new Size(233, 25);
            date_From.TabIndex = 22;
            date_From.Value = new DateTime(2009, 1, 21, 0, 0, 0, 0);
            date_From.ValueChanged += Linje_SelectedIndexChanged;
            // 
            // date_To
            // 
            date_To.CalendarMonthBackground = Color.FromArgb(45, 45, 45);
            date_To.Font = new Font("Palatino Linotype", 10F);
            date_To.Location = new Point(573, 29);
            date_To.Margin = new Padding(4, 3, 4, 3);
            date_To.Name = "date_To";
            date_To.Size = new Size(233, 25);
            date_To.TabIndex = 22;
            date_To.ValueChanged += Linje_SelectedIndexChanged;
            // 
            // label_Datum_Från
            // 
            label_Datum_Från.AutoSize = true;
            label_Datum_Från.Font = new Font("Palatino Linotype", 10F);
            label_Datum_Från.ForeColor = Color.OliveDrab;
            label_Datum_Från.Location = new Point(322, 2);
            label_Datum_Från.Margin = new Padding(4, 0, 4, 0);
            label_Datum_Från.Name = "label_Datum_Från";
            label_Datum_Från.Size = new Size(39, 19);
            label_Datum_Från.TabIndex = 23;
            label_Datum_Från.Text = "Från";
            // 
            // label_Datum_Till
            // 
            label_Datum_Till.AutoSize = true;
            label_Datum_Till.Font = new Font("Palatino Linotype", 10F);
            label_Datum_Till.ForeColor = Color.OliveDrab;
            label_Datum_Till.Location = new Point(580, 1);
            label_Datum_Till.Margin = new Padding(4, 0, 4, 0);
            label_Datum_Till.Name = "label_Datum_Till";
            label_Datum_Till.Size = new Size(30, 19);
            label_Datum_Till.TabIndex = 23;
            label_Datum_Till.Text = "Till";
            // 
            // label_Linje
            // 
            label_Linje.AutoSize = true;
            label_Linje.Font = new Font("Palatino Linotype", 10F);
            label_Linje.ForeColor = Color.OliveDrab;
            label_Linje.Location = new Point(24, 2);
            label_Linje.Margin = new Padding(4, 0, 4, 0);
            label_Linje.Name = "label_Linje";
            label_Linje.Size = new Size(76, 19);
            label_Linje.TabIndex = 23;
            label_Linje.Text = "Välj linje...";
            // 
            // ProductionLines
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(2091, 1038);
            Controls.Add(label_Datum_Till);
            Controls.Add(label_Linje);
            Controls.Add(label_Datum_Från);
            Controls.Add(date_To);
            Controls.Add(date_From);
            Controls.Add(flp_Main);
            Controls.Add(cb_Linje);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProductionLines";
            Text = "ProduktionsLinje";
            Load += ProduktionsLinje_Load;
            ((ISupportInitialize)dgv_Mätningar).EndInit();
            ((ISupportInitialize)dgv_FrekvensArtikelNr).EndInit();
            ((ISupportInitialize)dgv_OperatörRengör).EndInit();
            ((ISupportInitialize)dgv_Huvud).EndInit();
            ((ISupportInitialize)dgv_Munstycke).EndInit();
            ((ISupportInitialize)dgv_Kärn).EndInit();
            ((ISupportInitialize)dgv_Kund).EndInit();
            ((ISupportInitialize)dgv_KrympslangsRör).EndInit();
            ((ISupportInitialize)dgv_KrympslangsLinje).EndInit();
            ((ISupportInitialize)dgv_Hackhylsa).EndInit();
            flp_Main.ResumeLayout(false);
            panel_Mätningar_Linje.ResumeLayout(false);
            panel_Mätningar_Linje.PerformLayout();
            panel_Operatör_Rengör.ResumeLayout(false);
            panel_Operatör_Rengör.PerformLayout();
            panel_Frekvens_ArtikelNr.ResumeLayout(false);
            panel_Frekvens_ArtikelNr.PerformLayout();
            panel_Frekvens_Kund.ResumeLayout(false);
            panel_Frekvens_Kund.PerformLayout();
            panel_Huvud.ResumeLayout(false);
            panel_Huvud.PerformLayout();
            panel_Munstycke.ResumeLayout(false);
            panel_Munstycke.PerformLayout();
            panel_Kärn.ResumeLayout(false);
            panel_Kärn.PerformLayout();
            panel_KrympslangsRör.ResumeLayout(false);
            panel_KrympslangsRör.PerformLayout();
            panel_KrympslangsLinje.ResumeLayout(false);
            panel_KrympslangsLinje.PerformLayout();
            panel_Anslutningsmuff.ResumeLayout(false);
            panel_Anslutningsmuff.PerformLayout();
            ((ISupportInitialize)dgv_Anslutningsmuff).EndInit();
            panel_Hackhylsa.ResumeLayout(false);
            panel_Hackhylsa.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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