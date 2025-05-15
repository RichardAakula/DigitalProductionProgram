using System.ComponentModel;

namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    partial class Protocol_Compund
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tlp_Main = new TableLayoutPanel();
            tlp_MainInfo = new TableLayoutPanel();
            lbl_RumFukt = new Label();
            lbl_RumTemp = new Label();
            label_RumFukt = new Label();
            label_RumsTemp = new Label();
            lbl_Name = new Label();
            lbl_Date = new Label();
            label_Operatör = new Label();
            label_Datum = new Label();
            tb_kg55D = new TextBox();
            label_kg55D = new Label();
            label_kg75D = new Label();
            lbl_LotNr55D = new Label();
            lbl_LotNr75D = new Label();
            label_PUR55D = new Label();
            label_PUR75D = new Label();
            lbl_ArtikelNr = new Label();
            lbl_OrderNr = new Label();
            label_OrderNr = new Label();
            label_ArtikelNr = new Label();
            tb_kg75D = new TextBox();
            dgv_Data = new DataGridView();
            tlp_Main.SuspendLayout();
            tlp_MainInfo.SuspendLayout();
            ((ISupportInitialize)dgv_Data).BeginInit();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Black;
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Main.Controls.Add(tlp_MainInfo, 0, 0);
            tlp_Main.Controls.Add(dgv_Data, 0, 1);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 10.07905F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 89.92095F));
            tlp_Main.Size = new Size(1143, 584);
            tlp_Main.TabIndex = 0;
            // 
            // tlp_MainInfo
            // 
            tlp_MainInfo.ColumnCount = 10;
            tlp_MainInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
            tlp_MainInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            tlp_MainInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 245F));
            tlp_MainInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 99F));
            tlp_MainInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 31F));
            tlp_MainInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
            tlp_MainInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tlp_MainInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 234F));
            tlp_MainInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98F));
            tlp_MainInfo.ColumnStyles.Add(new ColumnStyle());
            tlp_MainInfo.Controls.Add(lbl_RumFukt, 9, 1);
            tlp_MainInfo.Controls.Add(lbl_RumTemp, 9, 0);
            tlp_MainInfo.Controls.Add(label_RumFukt, 8, 1);
            tlp_MainInfo.Controls.Add(label_RumsTemp, 8, 0);
            tlp_MainInfo.Controls.Add(lbl_Name, 7, 1);
            tlp_MainInfo.Controls.Add(lbl_Date, 7, 0);
            tlp_MainInfo.Controls.Add(label_Operatör, 6, 1);
            tlp_MainInfo.Controls.Add(label_Datum, 6, 0);
            tlp_MainInfo.Controls.Add(tb_kg55D, 5, 1);
            tlp_MainInfo.Controls.Add(label_kg55D, 4, 1);
            tlp_MainInfo.Controls.Add(label_kg75D, 4, 0);
            tlp_MainInfo.Controls.Add(lbl_LotNr55D, 3, 1);
            tlp_MainInfo.Controls.Add(lbl_LotNr75D, 3, 0);
            tlp_MainInfo.Controls.Add(label_PUR55D, 2, 1);
            tlp_MainInfo.Controls.Add(label_PUR75D, 2, 0);
            tlp_MainInfo.Controls.Add(lbl_ArtikelNr, 1, 0);
            tlp_MainInfo.Controls.Add(lbl_OrderNr, 1, 1);
            tlp_MainInfo.Controls.Add(label_OrderNr, 0, 1);
            tlp_MainInfo.Controls.Add(label_ArtikelNr, 0, 0);
            tlp_MainInfo.Controls.Add(tb_kg75D, 5, 0);
            tlp_MainInfo.Dock = DockStyle.Fill;
            tlp_MainInfo.Location = new Point(0, 0);
            tlp_MainInfo.Margin = new Padding(0);
            tlp_MainInfo.Name = "tlp_MainInfo";
            tlp_MainInfo.RowCount = 2;
            tlp_MainInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_MainInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_MainInfo.Size = new Size(1143, 58);
            tlp_MainInfo.TabIndex = 0;
            // 
            // lbl_RumFukt
            // 
            lbl_RumFukt.AutoSize = true;
            lbl_RumFukt.BackColor = Color.White;
            lbl_RumFukt.Dock = DockStyle.Fill;
            lbl_RumFukt.Font = new Font("Consolas", 8.25F);
            lbl_RumFukt.ForeColor = Color.DarkSlateGray;
            lbl_RumFukt.Location = new Point(1100, 29);
            lbl_RumFukt.Margin = new Padding(0, 0, 1, 1);
            lbl_RumFukt.Name = "lbl_RumFukt";
            lbl_RumFukt.Padding = new Padding(6, 0, 0, 0);
            lbl_RumFukt.Size = new Size(42, 28);
            lbl_RumFukt.TabIndex = 958;
            // 
            // lbl_RumTemp
            // 
            lbl_RumTemp.AutoSize = true;
            lbl_RumTemp.BackColor = Color.White;
            lbl_RumTemp.Dock = DockStyle.Fill;
            lbl_RumTemp.Font = new Font("Consolas", 8.25F);
            lbl_RumTemp.ForeColor = Color.DarkSlateGray;
            lbl_RumTemp.Location = new Point(1100, 1);
            lbl_RumTemp.Margin = new Padding(0, 1, 1, 0);
            lbl_RumTemp.Name = "lbl_RumTemp";
            lbl_RumTemp.Padding = new Padding(6, 0, 0, 0);
            lbl_RumTemp.Size = new Size(42, 28);
            lbl_RumTemp.TabIndex = 957;
            // 
            // label_RumFukt
            // 
            label_RumFukt.AutoSize = true;
            label_RumFukt.BackColor = Color.White;
            label_RumFukt.Dock = DockStyle.Fill;
            label_RumFukt.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_RumFukt.Location = new Point(1002, 29);
            label_RumFukt.Margin = new Padding(0, 0, 0, 1);
            label_RumFukt.Name = "label_RumFukt";
            label_RumFukt.Size = new Size(98, 28);
            label_RumFukt.TabIndex = 956;
            label_RumFukt.Text = "Rel. Fukt. %";
            label_RumFukt.TextAlign = ContentAlignment.TopRight;
            // 
            // label_RumsTemp
            // 
            label_RumsTemp.AutoSize = true;
            label_RumsTemp.BackColor = Color.White;
            label_RumsTemp.Dock = DockStyle.Fill;
            label_RumsTemp.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_RumsTemp.Location = new Point(1002, 1);
            label_RumsTemp.Margin = new Padding(0, 1, 0, 0);
            label_RumsTemp.Name = "label_RumsTemp";
            label_RumsTemp.Size = new Size(98, 28);
            label_RumsTemp.TabIndex = 955;
            label_RumsTemp.Text = "Rumstemp °C";
            label_RumsTemp.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.BackColor = Color.White;
            lbl_Name.Dock = DockStyle.Fill;
            lbl_Name.Font = new Font("Consolas", 8.25F);
            lbl_Name.ForeColor = Color.DarkSlateGray;
            lbl_Name.Location = new Point(768, 29);
            lbl_Name.Margin = new Padding(0, 0, 0, 1);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Padding = new Padding(6, 0, 0, 0);
            lbl_Name.Size = new Size(234, 28);
            lbl_Name.TabIndex = 954;
            lbl_Name.Click += Name_Click;
            // 
            // lbl_Date
            // 
            lbl_Date.AutoSize = true;
            lbl_Date.BackColor = Color.White;
            lbl_Date.Dock = DockStyle.Fill;
            lbl_Date.Font = new Font("Consolas", 8.25F);
            lbl_Date.ForeColor = Color.DarkSlateGray;
            lbl_Date.Location = new Point(768, 1);
            lbl_Date.Margin = new Padding(0, 1, 0, 0);
            lbl_Date.Name = "lbl_Date";
            lbl_Date.Padding = new Padding(6, 0, 0, 0);
            lbl_Date.Size = new Size(234, 28);
            lbl_Date.TabIndex = 953;
            // 
            // label_Operatör
            // 
            label_Operatör.AutoSize = true;
            label_Operatör.BackColor = Color.White;
            label_Operatör.Dock = DockStyle.Fill;
            label_Operatör.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Operatör.Location = new Point(608, 29);
            label_Operatör.Margin = new Padding(0, 0, 0, 1);
            label_Operatör.Name = "label_Operatör";
            label_Operatör.Size = new Size(160, 28);
            label_Operatör.TabIndex = 952;
            label_Operatör.Text = "Operatör Sign/AnstNr:";
            label_Operatör.TextAlign = ContentAlignment.TopRight;
            // 
            // label_Datum
            // 
            label_Datum.AutoSize = true;
            label_Datum.BackColor = Color.White;
            label_Datum.Dock = DockStyle.Fill;
            label_Datum.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Datum.Location = new Point(608, 1);
            label_Datum.Margin = new Padding(0, 1, 0, 0);
            label_Datum.Name = "label_Datum";
            label_Datum.Size = new Size(160, 28);
            label_Datum.TabIndex = 951;
            label_Datum.Text = "Datum:";
            label_Datum.TextAlign = ContentAlignment.TopRight;
            // 
            // tb_kg55D
            // 
            tb_kg55D.BorderStyle = BorderStyle.None;
            tb_kg55D.Dock = DockStyle.Fill;
            tb_kg55D.Font = new Font("Consolas", 8.25F);
            tb_kg55D.ForeColor = Color.DarkSlateGray;
            tb_kg55D.Location = new Point(562, 29);
            tb_kg55D.Margin = new Padding(0, 0, 0, 1);
            tb_kg55D.Multiline = true;
            tb_kg55D.Name = "tb_kg55D";
            tb_kg55D.Size = new Size(46, 28);
            tb_kg55D.TabIndex = 950;
            tb_kg55D.TextChanged += Weight_55D_TextChanged;
            tb_kg55D.KeyPress += Weight_KeyPress;
            // 
            // label_kg55D
            // 
            label_kg55D.AutoSize = true;
            label_kg55D.BackColor = Color.White;
            label_kg55D.Dock = DockStyle.Fill;
            label_kg55D.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_kg55D.Location = new Point(531, 29);
            label_kg55D.Margin = new Padding(0, 0, 0, 1);
            label_kg55D.Name = "label_kg55D";
            label_kg55D.Size = new Size(31, 28);
            label_kg55D.TabIndex = 948;
            label_kg55D.Text = "kg:";
            label_kg55D.TextAlign = ContentAlignment.TopRight;
            // 
            // label_kg75D
            // 
            label_kg75D.AutoSize = true;
            label_kg75D.BackColor = Color.White;
            label_kg75D.Dock = DockStyle.Fill;
            label_kg75D.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_kg75D.Location = new Point(531, 1);
            label_kg75D.Margin = new Padding(0, 1, 0, 0);
            label_kg75D.Name = "label_kg75D";
            label_kg75D.Size = new Size(31, 28);
            label_kg75D.TabIndex = 947;
            label_kg75D.Text = "kg:";
            label_kg75D.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_LotNr55D
            // 
            lbl_LotNr55D.AutoSize = true;
            lbl_LotNr55D.BackColor = Color.White;
            lbl_LotNr55D.Dock = DockStyle.Fill;
            lbl_LotNr55D.Font = new Font("Consolas", 8.25F);
            lbl_LotNr55D.ForeColor = Color.DarkSlateGray;
            lbl_LotNr55D.Location = new Point(432, 29);
            lbl_LotNr55D.Margin = new Padding(0, 0, 0, 1);
            lbl_LotNr55D.Name = "lbl_LotNr55D";
            lbl_LotNr55D.Padding = new Padding(6, 0, 0, 0);
            lbl_LotNr55D.Size = new Size(99, 28);
            lbl_LotNr55D.TabIndex = 946;
            // 
            // lbl_LotNr75D
            // 
            lbl_LotNr75D.AutoSize = true;
            lbl_LotNr75D.BackColor = Color.White;
            lbl_LotNr75D.Dock = DockStyle.Fill;
            lbl_LotNr75D.Font = new Font("Consolas", 8.25F);
            lbl_LotNr75D.ForeColor = Color.DarkSlateGray;
            lbl_LotNr75D.Location = new Point(432, 1);
            lbl_LotNr75D.Margin = new Padding(0, 1, 0, 0);
            lbl_LotNr75D.Name = "lbl_LotNr75D";
            lbl_LotNr75D.Padding = new Padding(6, 0, 0, 0);
            lbl_LotNr75D.Size = new Size(99, 28);
            lbl_LotNr75D.TabIndex = 945;
            // 
            // label_PUR55D
            // 
            label_PUR55D.AutoSize = true;
            label_PUR55D.BackColor = Color.White;
            label_PUR55D.Dock = DockStyle.Fill;
            label_PUR55D.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_PUR55D.Location = new Point(187, 29);
            label_PUR55D.Margin = new Padding(0, 0, 0, 1);
            label_PUR55D.Name = "label_PUR55D";
            label_PUR55D.Size = new Size(245, 28);
            label_PUR55D.TabIndex = 944;
            label_PUR55D.Text = "PUR Pellethane 55D LotNr:";
            label_PUR55D.TextAlign = ContentAlignment.TopRight;
            // 
            // label_PUR75D
            // 
            label_PUR75D.AutoSize = true;
            label_PUR75D.BackColor = Color.White;
            label_PUR75D.Dock = DockStyle.Fill;
            label_PUR75D.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_PUR75D.Location = new Point(187, 1);
            label_PUR75D.Margin = new Padding(0, 1, 0, 0);
            label_PUR75D.Name = "label_PUR75D";
            label_PUR75D.Size = new Size(245, 28);
            label_PUR75D.TabIndex = 943;
            label_PUR75D.Text = "PUR Pellethane 75D LotNr:";
            label_PUR75D.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_ArtikelNr
            // 
            lbl_ArtikelNr.AutoSize = true;
            lbl_ArtikelNr.BackColor = Color.White;
            lbl_ArtikelNr.Dock = DockStyle.Fill;
            lbl_ArtikelNr.Font = new Font("Consolas", 8.25F);
            lbl_ArtikelNr.ForeColor = Color.DarkSlateGray;
            lbl_ArtikelNr.Location = new Point(82, 1);
            lbl_ArtikelNr.Margin = new Padding(0, 1, 0, 0);
            lbl_ArtikelNr.Name = "lbl_ArtikelNr";
            lbl_ArtikelNr.Padding = new Padding(6, 0, 0, 0);
            lbl_ArtikelNr.Size = new Size(105, 28);
            lbl_ArtikelNr.TabIndex = 942;
            // 
            // lbl_OrderNr
            // 
            lbl_OrderNr.AutoSize = true;
            lbl_OrderNr.BackColor = Color.White;
            lbl_OrderNr.Dock = DockStyle.Fill;
            lbl_OrderNr.Font = new Font("Consolas", 8.25F);
            lbl_OrderNr.ForeColor = Color.DarkSlateGray;
            lbl_OrderNr.Location = new Point(82, 29);
            lbl_OrderNr.Margin = new Padding(0, 0, 0, 1);
            lbl_OrderNr.Name = "lbl_OrderNr";
            lbl_OrderNr.Padding = new Padding(6, 0, 0, 0);
            lbl_OrderNr.Size = new Size(105, 28);
            lbl_OrderNr.TabIndex = 940;
            // 
            // label_OrderNr
            // 
            label_OrderNr.AutoSize = true;
            label_OrderNr.BackColor = Color.White;
            label_OrderNr.Dock = DockStyle.Fill;
            label_OrderNr.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_OrderNr.Location = new Point(1, 29);
            label_OrderNr.Margin = new Padding(1, 0, 0, 1);
            label_OrderNr.Name = "label_OrderNr";
            label_OrderNr.Size = new Size(81, 28);
            label_OrderNr.TabIndex = 1;
            label_OrderNr.Text = "Order Nr:";
            label_OrderNr.TextAlign = ContentAlignment.TopRight;
            // 
            // label_ArtikelNr
            // 
            label_ArtikelNr.AutoSize = true;
            label_ArtikelNr.BackColor = Color.White;
            label_ArtikelNr.Dock = DockStyle.Fill;
            label_ArtikelNr.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_ArtikelNr.Location = new Point(1, 1);
            label_ArtikelNr.Margin = new Padding(1, 1, 0, 0);
            label_ArtikelNr.Name = "label_ArtikelNr";
            label_ArtikelNr.Size = new Size(81, 28);
            label_ArtikelNr.TabIndex = 0;
            label_ArtikelNr.Text = "Artikel Nr:";
            label_ArtikelNr.TextAlign = ContentAlignment.TopRight;
            // 
            // tb_kg75D
            // 
            tb_kg75D.BorderStyle = BorderStyle.None;
            tb_kg75D.Dock = DockStyle.Fill;
            tb_kg75D.Font = new Font("Consolas", 8.25F);
            tb_kg75D.ForeColor = Color.DarkSlateGray;
            tb_kg75D.Location = new Point(562, 1);
            tb_kg75D.Margin = new Padding(0, 1, 0, 0);
            tb_kg75D.Multiline = true;
            tb_kg75D.Name = "tb_kg75D";
            tb_kg75D.Size = new Size(46, 28);
            tb_kg75D.TabIndex = 949;
            tb_kg75D.TextChanged += Weight_75D_TextChanged;
            tb_kg75D.KeyPress += Weight_KeyPress;
            // 
            // dgv_Data
            // 
            dgv_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Data.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Data.Dock = DockStyle.Fill;
            dgv_Data.Location = new Point(1, 58);
            dgv_Data.Margin = new Padding(1, 0, 1, 1);
            dgv_Data.MultiSelect = false;
            dgv_Data.Name = "dgv_Data";
            dgv_Data.RowHeadersVisible = false;
            dgv_Data.Size = new Size(1141, 525);
            dgv_Data.TabIndex = 1;
            dgv_Data.CellValueChanged += Data_CellValueChanged;
            // 
            // Protocol_Compund
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 584);
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Protocol_Compund";
            Text = "Kompounderingsregistrering PUR-Kompound";
            FormClosing += Protocol_Compund_FormClosing;
            Load += Protocol_Compund_Load;
            tlp_Main.ResumeLayout(false);
            tlp_MainInfo.ResumeLayout(false);
            tlp_MainInfo.PerformLayout();
            ((ISupportInitialize)dgv_Data).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private TableLayoutPanel tlp_MainInfo;
        private Label label_OrderNr;
        private Label label_ArtikelNr;
        private Label label_kg55D;
        private Label label_kg75D;
        private Label label_RumFukt;
        private Label label_RumsTemp;
        private Label label_Operatör;
        private Label label_Datum;
        public Label lbl_OrderNr;
        public Label lbl_ArtikelNr;
        public Label lbl_Name;
        public Label lbl_Date;
        public TextBox tb_kg55D;
        public TextBox tb_kg75D;
        public Label lbl_RumFukt;
        public Label lbl_RumTemp;
        public Label lbl_LotNr55D;
        public Label lbl_LotNr75D;
        public Label label_PUR55D;
        public Label label_PUR75D;
        public DataGridView dgv_Data;
    }
}