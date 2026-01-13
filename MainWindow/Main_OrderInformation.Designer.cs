
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class Main_OrderInformation
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
            label_Header = new Label();
            lbl_Start = new Label();
            lbl_Stopp = new Label();
            panel_Operation = new Panel();
            cb_Operation = new ComboBox();
            label_ProdGroup = new Label();
            label_OrderNr = new Label();
            label_PartNumber = new Label();
            label_Customer = new Label();
            label_Operation = new Label();
            lbl_TotalOrders = new Label();
            label_Description = new Label();
            label_Amount = new Label();
            label_Start = new Label();
            label_Stop = new Label();
            label_ProdLine = new Label();
            lbl_Enhet = new Label();
            lbl_Antal = new Label();
            lbl_ArtikelNr = new Label();
            lbl_ProdGroup = new Label();
            lbl_ProdLine = new Label();
            lbl_Customer = new Label();
            lbl_Benämning = new Label();
            panel_tb_OrderNr = new Panel();
            tb_OrderNr = new TextBox();
            label_revNr = new Label();
            lbl_RevNr = new Label();
            label_OrderStartedBy = new Label();
            label_TotalOrders = new Label();
            lbl_OrderStartedBy = new Label();
            lbl_Version = new Label();
            tlp_Main.SuspendLayout();
            panel_Operation.SuspendLayout();
            panel_tb_OrderNr.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Transparent;
            tlp_Main.ColumnCount = 6;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 134F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 68F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 37F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 169F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tlp_Main.Controls.Add(label_Header, 0, 0);
            tlp_Main.Controls.Add(lbl_Start, 1, 5);
            tlp_Main.Controls.Add(lbl_Stopp, 1, 6);
            tlp_Main.Controls.Add(panel_Operation, 5, 1);
            tlp_Main.Controls.Add(label_ProdGroup, 4, 4);
            tlp_Main.Controls.Add(label_OrderNr, 0, 1);
            tlp_Main.Controls.Add(label_PartNumber, 0, 2);
            tlp_Main.Controls.Add(label_Customer, 4, 3);
            tlp_Main.Controls.Add(label_Operation, 4, 1);
            tlp_Main.Controls.Add(lbl_TotalOrders, 5, 6);
            tlp_Main.Controls.Add(label_Description, 4, 2);
            tlp_Main.Controls.Add(label_Amount, 0, 3);
            tlp_Main.Controls.Add(label_Start, 0, 5);
            tlp_Main.Controls.Add(label_Stop, 0, 6);
            tlp_Main.Controls.Add(label_ProdLine, 4, 5);
            tlp_Main.Controls.Add(lbl_Enhet, 2, 3);
            tlp_Main.Controls.Add(lbl_Antal, 1, 3);
            tlp_Main.Controls.Add(lbl_ArtikelNr, 1, 2);
            tlp_Main.Controls.Add(lbl_ProdGroup, 5, 4);
            tlp_Main.Controls.Add(lbl_ProdLine, 5, 5);
            tlp_Main.Controls.Add(lbl_Customer, 5, 3);
            tlp_Main.Controls.Add(lbl_Benämning, 5, 2);
            tlp_Main.Controls.Add(panel_tb_OrderNr, 1, 1);
            tlp_Main.Controls.Add(label_revNr, 2, 2);
            tlp_Main.Controls.Add(lbl_RevNr, 3, 2);
            tlp_Main.Controls.Add(label_OrderStartedBy, 0, 4);
            tlp_Main.Controls.Add(label_TotalOrders, 4, 6);
            tlp_Main.Controls.Add(lbl_OrderStartedBy, 1, 4);
            tlp_Main.Controls.Add(lbl_Version, 5, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(0, 6, 0, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 7;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tlp_Main.Size = new Size(824, 231);
            tlp_Main.TabIndex = 896;
            // 
            // label_Header
            // 
            label_Header.BackColor = Color.Transparent;
            tlp_Main.SetColumnSpan(label_Header, 5);
            label_Header.Dock = DockStyle.Fill;
            label_Header.Font = new Font("Palatino Linotype", 13.25F);
            label_Header.ForeColor = Color.Moccasin;
            label_Header.Location = new Point(1, 1);
            label_Header.Margin = new Padding(1, 1, 0, 1);
            label_Header.Name = "label_Header";
            label_Header.Size = new Size(522, 27);
            label_Header.TabIndex = 1;
            label_Header.Text = "Digital Production Program:";
            // 
            // lbl_Start
            // 
            lbl_Start.BackColor = Color.Transparent;
            tlp_Main.SetColumnSpan(lbl_Start, 3);
            lbl_Start.Dock = DockStyle.Fill;
            lbl_Start.Font = new Font("Arial", 10F);
            lbl_Start.ForeColor = Color.DarkGray;
            lbl_Start.Location = new Point(116, 161);
            lbl_Start.Margin = new Padding(1, 0, 0, 1);
            lbl_Start.Name = "lbl_Start";
            lbl_Start.Size = new Size(238, 32);
            lbl_Start.TabIndex = 9;
            lbl_Start.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Stopp
            // 
            lbl_Stopp.BackColor = Color.Transparent;
            tlp_Main.SetColumnSpan(lbl_Stopp, 3);
            lbl_Stopp.Dock = DockStyle.Fill;
            lbl_Stopp.Font = new Font("Arial", 10F);
            lbl_Stopp.ForeColor = Color.DarkGray;
            lbl_Stopp.Location = new Point(116, 194);
            lbl_Stopp.Margin = new Padding(1, 0, 0, 1);
            lbl_Stopp.Name = "lbl_Stopp";
            lbl_Stopp.Size = new Size(238, 36);
            lbl_Stopp.TabIndex = 9;
            lbl_Stopp.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel_Operation
            // 
            panel_Operation.Controls.Add(cb_Operation);
            panel_Operation.Dock = DockStyle.Fill;
            panel_Operation.Location = new Point(524, 29);
            panel_Operation.Margin = new Padding(1, 0, 1, 1);
            panel_Operation.Name = "panel_Operation";
            panel_Operation.Size = new Size(299, 32);
            panel_Operation.TabIndex = 830;
            // 
            // cb_Operation
            // 
            cb_Operation.BackColor = Color.White;
            cb_Operation.Dock = DockStyle.Fill;
            cb_Operation.DropDownHeight = 150;
            cb_Operation.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Operation.DropDownWidth = 150;
            cb_Operation.FlatStyle = FlatStyle.Flat;
            cb_Operation.Font = new Font("Arial", 10F);
            cb_Operation.ForeColor = Color.DimGray;
            cb_Operation.FormattingEnabled = true;
            cb_Operation.IntegralHeight = false;
            cb_Operation.ItemHeight = 16;
            cb_Operation.Location = new Point(0, 0);
            cb_Operation.Margin = new Padding(4, 3, 4, 3);
            cb_Operation.Name = "cb_Operation";
            cb_Operation.Size = new Size(299, 24);
            cb_Operation.TabIndex = 1;
            cb_Operation.TabStop = false;
            cb_Operation.KeyDown += cb_Operation_KeyDown;
            // 
            // label_ProdGroup
            // 
            label_ProdGroup.BackColor = Color.Transparent;
            label_ProdGroup.Dock = DockStyle.Fill;
            label_ProdGroup.Font = new Font("Arial", 10F);
            label_ProdGroup.ForeColor = Color.Snow;
            label_ProdGroup.Location = new Point(355, 128);
            label_ProdGroup.Margin = new Padding(1, 0, 0, 1);
            label_ProdGroup.Name = "label_ProdGroup";
            label_ProdGroup.Size = new Size(168, 32);
            label_ProdGroup.TabIndex = 589;
            label_ProdGroup.Text = "Prod.grupp:";
            label_ProdGroup.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr
            // 
            label_OrderNr.BackColor = Color.Transparent;
            label_OrderNr.Dock = DockStyle.Fill;
            label_OrderNr.Font = new Font("Arial", 10F);
            label_OrderNr.ForeColor = Color.Snow;
            label_OrderNr.ImageAlign = ContentAlignment.BottomCenter;
            label_OrderNr.Location = new Point(1, 29);
            label_OrderNr.Margin = new Padding(1, 0, 0, 1);
            label_OrderNr.Name = "label_OrderNr";
            label_OrderNr.Size = new Size(114, 32);
            label_OrderNr.TabIndex = 12;
            label_OrderNr.Text = "OrderNr:";
            label_OrderNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_PartNumber
            // 
            label_PartNumber.BackColor = Color.Transparent;
            label_PartNumber.Dock = DockStyle.Fill;
            label_PartNumber.Font = new Font("Arial", 10F);
            label_PartNumber.ForeColor = Color.Snow;
            label_PartNumber.Location = new Point(1, 62);
            label_PartNumber.Margin = new Padding(1, 0, 0, 1);
            label_PartNumber.Name = "label_PartNumber";
            label_PartNumber.Size = new Size(114, 32);
            label_PartNumber.TabIndex = 38;
            label_PartNumber.Text = "ArtikelNr:";
            label_PartNumber.TextAlign = ContentAlignment.MiddleLeft;
            label_PartNumber.Click += label_PartNumber_Click;
            // 
            // label_Customer
            // 
            label_Customer.BackColor = Color.Transparent;
            label_Customer.Dock = DockStyle.Fill;
            label_Customer.Font = new Font("Arial", 10F);
            label_Customer.ForeColor = Color.Snow;
            label_Customer.Location = new Point(355, 95);
            label_Customer.Margin = new Padding(1, 0, 0, 1);
            label_Customer.Name = "label_Customer";
            label_Customer.Size = new Size(168, 32);
            label_Customer.TabIndex = 8;
            label_Customer.Text = "Kund: ";
            label_Customer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Operation
            // 
            label_Operation.BackColor = Color.Transparent;
            label_Operation.Dock = DockStyle.Fill;
            label_Operation.Font = new Font("Arial", 10F);
            label_Operation.ForeColor = Color.Snow;
            label_Operation.Location = new Point(355, 29);
            label_Operation.Margin = new Padding(1, 0, 0, 1);
            label_Operation.Name = "label_Operation";
            label_Operation.Size = new Size(168, 32);
            label_Operation.TabIndex = 8;
            label_Operation.Text = "Operation:";
            label_Operation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_TotalOrders
            // 
            lbl_TotalOrders.AutoSize = true;
            lbl_TotalOrders.BackColor = Color.Transparent;
            lbl_TotalOrders.Dock = DockStyle.Fill;
            lbl_TotalOrders.Font = new Font("Palatino Linotype", 10F);
            lbl_TotalOrders.ForeColor = Color.Yellow;
            lbl_TotalOrders.Location = new Point(527, 194);
            lbl_TotalOrders.Margin = new Padding(4, 0, 4, 0);
            lbl_TotalOrders.Name = "lbl_TotalOrders";
            lbl_TotalOrders.Size = new Size(293, 37);
            lbl_TotalOrders.TabIndex = 897;
            lbl_TotalOrders.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Description
            // 
            label_Description.BackColor = Color.Transparent;
            label_Description.Dock = DockStyle.Fill;
            label_Description.Font = new Font("Arial", 10F);
            label_Description.ForeColor = Color.Snow;
            label_Description.Location = new Point(355, 62);
            label_Description.Margin = new Padding(1, 0, 0, 1);
            label_Description.Name = "label_Description";
            label_Description.Size = new Size(168, 32);
            label_Description.TabIndex = 10;
            label_Description.Text = "Benämning:";
            label_Description.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Amount
            // 
            label_Amount.BackColor = Color.Transparent;
            label_Amount.Dock = DockStyle.Fill;
            label_Amount.Font = new Font("Arial", 10F);
            label_Amount.ForeColor = Color.Snow;
            label_Amount.Location = new Point(1, 95);
            label_Amount.Margin = new Padding(1, 0, 0, 1);
            label_Amount.Name = "label_Amount";
            label_Amount.Size = new Size(114, 32);
            label_Amount.TabIndex = 74;
            label_Amount.Text = "Antal:";
            label_Amount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Start
            // 
            label_Start.BackColor = Color.Transparent;
            label_Start.Dock = DockStyle.Fill;
            label_Start.Font = new Font("Arial", 10F);
            label_Start.ForeColor = Color.Snow;
            label_Start.Location = new Point(1, 161);
            label_Start.Margin = new Padding(1, 0, 0, 1);
            label_Start.Name = "label_Start";
            label_Start.Size = new Size(114, 32);
            label_Start.TabIndex = 8;
            label_Start.Text = "Start:";
            label_Start.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Stop
            // 
            label_Stop.BackColor = Color.Transparent;
            label_Stop.Dock = DockStyle.Fill;
            label_Stop.Font = new Font("Arial", 10F);
            label_Stop.ForeColor = Color.Snow;
            label_Stop.Location = new Point(1, 194);
            label_Stop.Margin = new Padding(1, 0, 0, 1);
            label_Stop.Name = "label_Stop";
            label_Stop.Size = new Size(114, 36);
            label_Stop.TabIndex = 590;
            label_Stop.Text = "Stopp:";
            label_Stop.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_ProdLine
            // 
            label_ProdLine.BackColor = Color.Transparent;
            label_ProdLine.Dock = DockStyle.Fill;
            label_ProdLine.Font = new Font("Arial", 10F);
            label_ProdLine.ForeColor = Color.Snow;
            label_ProdLine.Location = new Point(355, 161);
            label_ProdLine.Margin = new Padding(1, 0, 0, 1);
            label_ProdLine.Name = "label_ProdLine";
            label_ProdLine.Size = new Size(168, 32);
            label_ProdLine.TabIndex = 587;
            label_ProdLine.Text = "ProdLinje:";
            label_ProdLine.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Enhet
            // 
            lbl_Enhet.AutoSize = true;
            lbl_Enhet.BackColor = Color.Transparent;
            tlp_Main.SetColumnSpan(lbl_Enhet, 2);
            lbl_Enhet.Dock = DockStyle.Fill;
            lbl_Enhet.Font = new Font("Arial", 10F);
            lbl_Enhet.ForeColor = Color.DarkGray;
            lbl_Enhet.Location = new Point(249, 95);
            lbl_Enhet.Margin = new Padding(0, 0, 0, 1);
            lbl_Enhet.Name = "lbl_Enhet";
            lbl_Enhet.Size = new Size(105, 32);
            lbl_Enhet.TabIndex = 834;
            lbl_Enhet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Antal
            // 
            lbl_Antal.AutoSize = true;
            lbl_Antal.BackColor = Color.Transparent;
            lbl_Antal.Dock = DockStyle.Fill;
            lbl_Antal.Font = new Font("Arial", 10F);
            lbl_Antal.ForeColor = Color.DarkGray;
            lbl_Antal.Location = new Point(116, 95);
            lbl_Antal.Margin = new Padding(1, 0, 0, 1);
            lbl_Antal.Name = "lbl_Antal";
            lbl_Antal.Size = new Size(133, 32);
            lbl_Antal.TabIndex = 834;
            lbl_Antal.TextAlign = ContentAlignment.MiddleLeft;
            lbl_Antal.MouseClick += Label_MouseClick;
            // 
            // lbl_ArtikelNr
            // 
            lbl_ArtikelNr.AutoSize = true;
            lbl_ArtikelNr.BackColor = Color.Transparent;
            lbl_ArtikelNr.Dock = DockStyle.Fill;
            lbl_ArtikelNr.Font = new Font("Arial", 10F);
            lbl_ArtikelNr.ForeColor = Color.DarkGray;
            lbl_ArtikelNr.Location = new Point(116, 62);
            lbl_ArtikelNr.Margin = new Padding(1, 0, 0, 1);
            lbl_ArtikelNr.Name = "lbl_ArtikelNr";
            lbl_ArtikelNr.Size = new Size(133, 32);
            lbl_ArtikelNr.TabIndex = 835;
            lbl_ArtikelNr.TextAlign = ContentAlignment.MiddleLeft;
            lbl_ArtikelNr.MouseClick += Label_MouseClick;
            // 
            // lbl_ProdGroup
            // 
            lbl_ProdGroup.AutoSize = true;
            lbl_ProdGroup.BackColor = Color.Transparent;
            lbl_ProdGroup.Dock = DockStyle.Fill;
            lbl_ProdGroup.Font = new Font("Arial", 10F);
            lbl_ProdGroup.ForeColor = Color.DarkGray;
            lbl_ProdGroup.Location = new Point(524, 128);
            lbl_ProdGroup.Margin = new Padding(1, 0, 0, 1);
            lbl_ProdGroup.Name = "lbl_ProdGroup";
            lbl_ProdGroup.Size = new Size(300, 32);
            lbl_ProdGroup.TabIndex = 836;
            lbl_ProdGroup.TextAlign = ContentAlignment.MiddleLeft;
            lbl_ProdGroup.MouseClick += Label_MouseClick;
            // 
            // lbl_ProdLine
            // 
            lbl_ProdLine.AutoSize = true;
            lbl_ProdLine.BackColor = Color.Transparent;
            lbl_ProdLine.Cursor = Cursors.Hand;
            lbl_ProdLine.Dock = DockStyle.Fill;
            lbl_ProdLine.Font = new Font("Arial", 10F, FontStyle.Underline);
            lbl_ProdLine.ForeColor = SystemColors.Highlight;
            lbl_ProdLine.Location = new Point(524, 161);
            lbl_ProdLine.Margin = new Padding(1, 0, 1, 1);
            lbl_ProdLine.Name = "lbl_ProdLine";
            lbl_ProdLine.Size = new Size(299, 32);
            lbl_ProdLine.TabIndex = 836;
            lbl_ProdLine.TextAlign = ContentAlignment.MiddleLeft;
            lbl_ProdLine.Click += ProdLine_Click;
            // 
            // lbl_Customer
            // 
            lbl_Customer.AutoSize = true;
            lbl_Customer.BackColor = Color.Transparent;
            lbl_Customer.Cursor = Cursors.Hand;
            lbl_Customer.Dock = DockStyle.Fill;
            lbl_Customer.Font = new Font("Arial", 10F, FontStyle.Underline);
            lbl_Customer.ForeColor = SystemColors.Highlight;
            lbl_Customer.Location = new Point(524, 95);
            lbl_Customer.Margin = new Padding(1, 0, 1, 1);
            lbl_Customer.Name = "lbl_Customer";
            lbl_Customer.Size = new Size(299, 32);
            lbl_Customer.TabIndex = 836;
            lbl_Customer.TextAlign = ContentAlignment.MiddleLeft;
            lbl_Customer.Click += Customer_Click;
            // 
            // lbl_Benämning
            // 
            lbl_Benämning.AutoSize = true;
            lbl_Benämning.BackColor = Color.Transparent;
            lbl_Benämning.Dock = DockStyle.Fill;
            lbl_Benämning.Font = new Font("Arial", 10F);
            lbl_Benämning.ForeColor = Color.DarkGray;
            lbl_Benämning.Location = new Point(524, 62);
            lbl_Benämning.Margin = new Padding(1, 0, 1, 1);
            lbl_Benämning.Name = "lbl_Benämning";
            lbl_Benämning.Size = new Size(299, 32);
            lbl_Benämning.TabIndex = 836;
            lbl_Benämning.TextAlign = ContentAlignment.MiddleLeft;
            lbl_Benämning.MouseClick += Label_MouseClick;
            // 
            // panel_tb_OrderNr
            // 
            panel_tb_OrderNr.BackColor = Color.Transparent;
            panel_tb_OrderNr.Controls.Add(tb_OrderNr);
            panel_tb_OrderNr.Dock = DockStyle.Fill;
            panel_tb_OrderNr.Location = new Point(115, 29);
            panel_tb_OrderNr.Margin = new Padding(0);
            panel_tb_OrderNr.Name = "panel_tb_OrderNr";
            panel_tb_OrderNr.Size = new Size(134, 33);
            panel_tb_OrderNr.TabIndex = 898;
            // 
            // tb_OrderNr
            // 
            tb_OrderNr.AcceptsTab = true;
            tb_OrderNr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_OrderNr.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_OrderNr.BackColor = Color.Khaki;
            tb_OrderNr.BorderStyle = BorderStyle.None;
            tb_OrderNr.CharacterCasing = CharacterCasing.Upper;
            tb_OrderNr.Font = new Font("Arial", 9F);
            tb_OrderNr.ForeColor = Color.DarkGray;
            tb_OrderNr.Location = new Point(1, 5);
            tb_OrderNr.Margin = new Padding(0, 3, 0, 0);
            tb_OrderNr.Name = "tb_OrderNr";
            tb_OrderNr.Size = new Size(104, 14);
            tb_OrderNr.TabIndex = 0;
            tb_OrderNr.MouseDoubleClick += Label_MouseClick;
            tb_OrderNr.Validated += OrderNr_Validated;
            // 
            // label_revNr
            // 
            label_revNr.BackColor = Color.Transparent;
            label_revNr.Dock = DockStyle.Fill;
            label_revNr.Font = new Font("Arial", 10F);
            label_revNr.ForeColor = Color.Snow;
            label_revNr.Location = new Point(250, 62);
            label_revNr.Margin = new Padding(1, 0, 0, 1);
            label_revNr.Name = "label_revNr";
            label_revNr.Size = new Size(67, 32);
            label_revNr.TabIndex = 38;
            label_revNr.Text = "RevNr:";
            label_revNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_RevNr
            // 
            lbl_RevNr.AutoSize = true;
            lbl_RevNr.BackColor = Color.Transparent;
            lbl_RevNr.Dock = DockStyle.Fill;
            lbl_RevNr.Font = new Font("Arial", 10F);
            lbl_RevNr.ForeColor = Color.DarkGray;
            lbl_RevNr.Location = new Point(317, 62);
            lbl_RevNr.Margin = new Padding(0, 0, 0, 1);
            lbl_RevNr.Name = "lbl_RevNr";
            lbl_RevNr.Size = new Size(37, 32);
            lbl_RevNr.TabIndex = 834;
            lbl_RevNr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_OrderStartedBy
            // 
            label_OrderStartedBy.BackColor = Color.Transparent;
            label_OrderStartedBy.Dock = DockStyle.Fill;
            label_OrderStartedBy.Font = new Font("Arial", 10F);
            label_OrderStartedBy.ForeColor = Color.Snow;
            label_OrderStartedBy.Location = new Point(1, 128);
            label_OrderStartedBy.Margin = new Padding(1, 0, 0, 1);
            label_OrderStartedBy.Name = "label_OrderStartedBy";
            label_OrderStartedBy.Size = new Size(114, 32);
            label_OrderStartedBy.TabIndex = 8;
            label_OrderStartedBy.Text = "Startad av:";
            label_OrderStartedBy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_TotalOrders
            // 
            label_TotalOrders.BackColor = Color.Transparent;
            label_TotalOrders.Dock = DockStyle.Fill;
            label_TotalOrders.Font = new Font("Arial", 10F);
            label_TotalOrders.ForeColor = Color.Snow;
            label_TotalOrders.Location = new Point(355, 194);
            label_TotalOrders.Margin = new Padding(1, 0, 0, 1);
            label_TotalOrders.Name = "label_TotalOrders";
            label_TotalOrders.Size = new Size(168, 36);
            label_TotalOrders.TabIndex = 587;
            label_TotalOrders.Text = "Antal Ordrar:";
            label_TotalOrders.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderStartedBy
            // 
            lbl_OrderStartedBy.BackColor = Color.Transparent;
            tlp_Main.SetColumnSpan(lbl_OrderStartedBy, 3);
            lbl_OrderStartedBy.Dock = DockStyle.Fill;
            lbl_OrderStartedBy.Font = new Font("Arial", 10F);
            lbl_OrderStartedBy.ForeColor = Color.DarkGray;
            lbl_OrderStartedBy.Location = new Point(116, 128);
            lbl_OrderStartedBy.Margin = new Padding(1, 0, 0, 1);
            lbl_OrderStartedBy.Name = "lbl_OrderStartedBy";
            lbl_OrderStartedBy.Size = new Size(238, 32);
            lbl_OrderStartedBy.TabIndex = 9;
            lbl_OrderStartedBy.TextAlign = ContentAlignment.MiddleLeft;
            lbl_OrderStartedBy.MouseClick += Label_MouseClick;
            // 
            // lbl_Version
            // 
            lbl_Version.BackColor = Color.Transparent;
            lbl_Version.Dock = DockStyle.Fill;
            lbl_Version.Font = new Font("Palatino Linotype", 8.25F);
            lbl_Version.ForeColor = Color.Snow;
            lbl_Version.Location = new Point(523, 1);
            lbl_Version.Margin = new Padding(0, 1, 1, 1);
            lbl_Version.Name = "lbl_Version";
            lbl_Version.Size = new Size(300, 27);
            lbl_Version.TabIndex = 833;
            lbl_Version.Text = "0.0.0.0";
            lbl_Version.TextAlign = ContentAlignment.TopRight;
            // 
            // Main_OrderInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main_OrderInformation";
            Size = new Size(824, 231);
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            panel_Operation.ResumeLayout(false);
            panel_tb_OrderNr.ResumeLayout(false);
            panel_tb_OrderNr.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        public TableLayoutPanel tlp_Main;
        private Label label_Header;
        public Label lbl_Start;
        public Label lbl_Stopp;
        public Panel panel_Operation;
        public ComboBox cb_Operation;
        private Label label_ProdGroup;
        private Label label_OrderNr;
        private Label label_PartNumber;
        private Label label_Customer;
        private Label label_Operation;
        private Label label_Description;
        private Label label_Amount;
        private Label label_Start;
        private Label label_Stop;
        private Label label_ProdLine;
        public Label lbl_Enhet;
        public Label lbl_Antal;
        public Label lbl_ArtikelNr;
        public Label lbl_ProdGroup;
        public Label lbl_ProdLine;
        public Label lbl_Customer;
        public Label lbl_Benämning;
        public Panel panel_tb_OrderNr;
        public TextBox tb_OrderNr;
        private Label label_revNr;
        public Label lbl_RevNr;
        public Label lbl_TotalOrders;
        public Label lbl_Version;
        private Label label_OrderStartedBy;
        private Label label_TotalOrders;
        public Label lbl_OrderStartedBy;
    }
}
