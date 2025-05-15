using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.MainInfo
{
    partial class MainInfo_Description_Prodtype
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
            this.lbl_Prodtype = new System.Windows.Forms.Label();
            this.label_ProdType = new System.Windows.Forms.Label();
            this.lbl_OrderNr = new System.Windows.Forms.Label();
            this.lbl_ArtikelNr = new System.Windows.Forms.Label();
            this.label_OrderNr = new System.Windows.Forms.Label();
            this.label_PartNumber = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.lbl_Customer = new System.Windows.Forms.Label();
            this.label_Customer = new System.Windows.Forms.Label();
            this.label_Description = new System.Windows.Forms.Label();
            this.label_Amount = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.AutoSize = true;
            this.tlp_Main.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlp_Main.ColumnCount = 7;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_Main.Controls.Add(this.lbl_Prodtype, 3, 1);
            this.tlp_Main.Controls.Add(this.label_ProdType, 2, 1);
            this.tlp_Main.Controls.Add(this.lbl_OrderNr, 6, 1);
            this.tlp_Main.Controls.Add(this.lbl_ArtikelNr, 6, 0);
            this.tlp_Main.Controls.Add(this.label_OrderNr, 5, 1);
            this.tlp_Main.Controls.Add(this.label_PartNumber, 5, 0);
            this.tlp_Main.Controls.Add(this.lbl_Total, 4, 0);
            this.tlp_Main.Controls.Add(this.lbl_Description, 1, 1);
            this.tlp_Main.Controls.Add(this.lbl_Customer, 1, 0);
            this.tlp_Main.Controls.Add(this.label_Customer, 0, 0);
            this.tlp_Main.Controls.Add(this.label_Description, 0, 1);
            this.tlp_Main.Controls.Add(this.label_Amount, 3, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Size = new System.Drawing.Size(824, 75);
            this.tlp_Main.TabIndex = 946;
            // 
            // lbl_Prodtype
            // 
            this.lbl_Prodtype.AutoSize = true;
            this.lbl_Prodtype.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.lbl_Prodtype, 2);
            this.lbl_Prodtype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Prodtype.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_Prodtype.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Prodtype.Location = new System.Drawing.Point(509, 37);
            this.lbl_Prodtype.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Prodtype.Name = "lbl_Prodtype";
            this.lbl_Prodtype.Size = new System.Drawing.Size(130, 38);
            this.lbl_Prodtype.TabIndex = 946;
            this.lbl_Prodtype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ProdType
            // 
            this.label_ProdType.BackColor = System.Drawing.Color.White;
            this.label_ProdType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ProdType.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_ProdType.ForeColor = System.Drawing.Color.Black;
            this.label_ProdType.Location = new System.Drawing.Point(402, 37);
            this.label_ProdType.Margin = new System.Windows.Forms.Padding(0);
            this.label_ProdType.Name = "label_ProdType";
            this.label_ProdType.Size = new System.Drawing.Size(107, 38);
            this.label_ProdType.TabIndex = 945;
            this.label_ProdType.Text = "ProduktTyp:";
            this.label_ProdType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderNr
            // 
            this.lbl_OrderNr.AutoSize = true;
            this.lbl_OrderNr.BackColor = System.Drawing.Color.White;
            this.lbl_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderNr.Font = new System.Drawing.Font("Consolas", 9.25F);
            this.lbl_OrderNr.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_OrderNr.Location = new System.Drawing.Point(724, 37);
            this.lbl_OrderNr.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_OrderNr.Name = "lbl_OrderNr";
            this.lbl_OrderNr.Size = new System.Drawing.Size(100, 38);
            this.lbl_OrderNr.TabIndex = 944;
            this.lbl_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_ArtikelNr
            // 
            this.lbl_ArtikelNr.AutoSize = true;
            this.lbl_ArtikelNr.BackColor = System.Drawing.Color.White;
            this.lbl_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ArtikelNr.Font = new System.Drawing.Font("Consolas", 9.25F);
            this.lbl_ArtikelNr.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_ArtikelNr.Location = new System.Drawing.Point(724, 0);
            this.lbl_ArtikelNr.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_ArtikelNr.Name = "lbl_ArtikelNr";
            this.lbl_ArtikelNr.Size = new System.Drawing.Size(100, 37);
            this.lbl_ArtikelNr.TabIndex = 943;
            this.lbl_ArtikelNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr
            // 
            this.label_OrderNr.BackColor = System.Drawing.Color.White;
            this.label_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OrderNr.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_OrderNr.ForeColor = System.Drawing.Color.Black;
            this.label_OrderNr.Location = new System.Drawing.Point(640, 37);
            this.label_OrderNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_OrderNr.Name = "label_OrderNr";
            this.label_OrderNr.Size = new System.Drawing.Size(84, 38);
            this.label_OrderNr.TabIndex = 942;
            this.label_OrderNr.Text = "T.O. nr:";
            this.label_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_PartNumber
            // 
            this.label_PartNumber.BackColor = System.Drawing.Color.White;
            this.label_PartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PartNumber.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_PartNumber.ForeColor = System.Drawing.Color.Black;
            this.label_PartNumber.Location = new System.Drawing.Point(640, 0);
            this.label_PartNumber.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_PartNumber.Name = "label_PartNumber";
            this.label_PartNumber.Size = new System.Drawing.Size(84, 37);
            this.label_PartNumber.TabIndex = 941;
            this.label_PartNumber.Text = "ArtikelNr:";
            this.label_PartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Total
            // 
            this.lbl_Total.AutoSize = true;
            this.lbl_Total.BackColor = System.Drawing.Color.White;
            this.lbl_Total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Total.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_Total.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Total.Location = new System.Drawing.Point(571, 0);
            this.lbl_Total.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(68, 36);
            this.lbl_Total.TabIndex = 940;
            this.lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Description
            // 
            this.lbl_Description.AutoSize = true;
            this.lbl_Description.BackColor = System.Drawing.Color.White;
            this.lbl_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Description.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_Description.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Description.Location = new System.Drawing.Point(86, 37);
            this.lbl_Description.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(316, 38);
            this.lbl_Description.TabIndex = 939;
            this.lbl_Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Customer
            // 
            this.lbl_Customer.AutoSize = true;
            this.lbl_Customer.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.lbl_Customer, 2);
            this.lbl_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Customer.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_Customer.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Customer.Location = new System.Drawing.Point(86, 0);
            this.lbl_Customer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_Customer.Name = "lbl_Customer";
            this.lbl_Customer.Size = new System.Drawing.Size(423, 36);
            this.lbl_Customer.TabIndex = 931;
            this.lbl_Customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Customer
            // 
            this.label_Customer.BackColor = System.Drawing.Color.White;
            this.label_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Customer.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Customer.ForeColor = System.Drawing.Color.Black;
            this.label_Customer.Location = new System.Drawing.Point(0, 0);
            this.label_Customer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Customer.Name = "label_Customer";
            this.label_Customer.Size = new System.Drawing.Size(86, 36);
            this.label_Customer.TabIndex = 927;
            this.label_Customer.Text = "Kund: ";
            this.label_Customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Description
            // 
            this.label_Description.BackColor = System.Drawing.Color.White;
            this.label_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Description.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Description.ForeColor = System.Drawing.Color.Black;
            this.label_Description.Location = new System.Drawing.Point(0, 37);
            this.label_Description.Margin = new System.Windows.Forms.Padding(0);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(86, 38);
            this.label_Description.TabIndex = 937;
            this.label_Description.Text = "Benämning:";
            this.label_Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Amount
            // 
            this.label_Amount.BackColor = System.Drawing.Color.White;
            this.label_Amount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Amount.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Amount.ForeColor = System.Drawing.Color.Black;
            this.label_Amount.Location = new System.Drawing.Point(509, 0);
            this.label_Amount.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Amount.Name = "label_Amount";
            this.label_Amount.Size = new System.Drawing.Size(62, 36);
            this.label_Amount.TabIndex = 937;
            this.label_Amount.Text = "Antal:";
            this.label_Amount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainInfo_Description_Prodtype
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "MainInfo_Description_Prodtype";
            this.Size = new System.Drawing.Size(824, 75);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        public Label lbl_Customer;
        public Label lbl_Total;
        public Label lbl_Description;
        private Label label_Amount;
        public Label label_PartNumber;
        public Label label_OrderNr;
        public Label lbl_ArtikelNr;
        public Label lbl_OrderNr;
        public Label label_Customer;
        public Label label_Description;
        public Label label_ProdType;
        public Label lbl_Prodtype;
    }
}
