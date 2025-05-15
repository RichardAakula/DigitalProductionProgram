using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.MainInfo
{
    partial class MainInfo_A
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
            this.lbl_OrderNr = new System.Windows.Forms.Label();
            this.lbl_PartNumber = new System.Windows.Forms.Label();
            this.label_OrderNr = new System.Windows.Forms.Label();
            this.label_PartNumber = new System.Windows.Forms.Label();
            this.lbl_Antal = new System.Windows.Forms.Label();
            this.lbl_ProdType = new System.Windows.Forms.Label();
            this.lbl_Customer = new System.Windows.Forms.Label();
            this.label_Customer = new System.Windows.Forms.Label();
            this.label_ProdType = new System.Windows.Forms.Label();
            this.label_Amount = new System.Windows.Forms.Label();
            this.Room_TempMoisture = new DigitalProductionProgram.Protocols.MainInfo.Room_TempMoisture();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 6;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tlp_Main.Controls.Add(this.lbl_OrderNr, 5, 1);
            this.tlp_Main.Controls.Add(this.lbl_PartNumber, 5, 0);
            this.tlp_Main.Controls.Add(this.label_OrderNr, 4, 1);
            this.tlp_Main.Controls.Add(this.label_PartNumber, 4, 0);
            this.tlp_Main.Controls.Add(this.lbl_Antal, 3, 1);
            this.tlp_Main.Controls.Add(this.lbl_ProdType, 1, 1);
            this.tlp_Main.Controls.Add(this.lbl_Customer, 1, 0);
            this.tlp_Main.Controls.Add(this.label_Customer, 0, 0);
            this.tlp_Main.Controls.Add(this.label_ProdType, 0, 1);
            this.tlp_Main.Controls.Add(this.label_Amount, 3, 0);
            this.tlp_Main.Controls.Add(this.Room_TempMoisture, 2, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Size = new System.Drawing.Size(1178, 57);
            this.tlp_Main.TabIndex = 947;
            // 
            // lbl_OrderNr
            // 
            this.lbl_OrderNr.AutoSize = true;
            this.lbl_OrderNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.lbl_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderNr.Font = new System.Drawing.Font("Consolas", 9.25F);
            this.lbl_OrderNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_OrderNr.Location = new System.Drawing.Point(1070, 28);
            this.lbl_OrderNr.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_OrderNr.Name = "lbl_OrderNr";
            this.lbl_OrderNr.Size = new System.Drawing.Size(108, 29);
            this.lbl_OrderNr.TabIndex = 944;
            this.lbl_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PartNumber
            // 
            this.lbl_PartNumber.AutoSize = true;
            this.lbl_PartNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.lbl_PartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_PartNumber.Font = new System.Drawing.Font("Consolas", 9.25F);
            this.lbl_PartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_PartNumber.Location = new System.Drawing.Point(1070, 0);
            this.lbl_PartNumber.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_PartNumber.Name = "lbl_PartNumber";
            this.lbl_PartNumber.Size = new System.Drawing.Size(108, 27);
            this.lbl_PartNumber.TabIndex = 943;
            this.lbl_PartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr
            // 
            this.label_OrderNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OrderNr.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_OrderNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_OrderNr.Location = new System.Drawing.Point(1001, 28);
            this.label_OrderNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_OrderNr.Name = "label_OrderNr";
            this.label_OrderNr.Size = new System.Drawing.Size(69, 29);
            this.label_OrderNr.TabIndex = 942;
            this.label_OrderNr.Text = "OrderNr:";
            this.label_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_PartNumber
            // 
            this.label_PartNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_PartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PartNumber.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_PartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_PartNumber.Location = new System.Drawing.Point(1001, 0);
            this.label_PartNumber.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_PartNumber.Name = "label_PartNumber";
            this.label_PartNumber.Size = new System.Drawing.Size(69, 27);
            this.label_PartNumber.TabIndex = 941;
            this.label_PartNumber.Text = "ArtikelNr:";
            this.label_PartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Antal
            // 
            this.lbl_Antal.AutoSize = true;
            this.lbl_Antal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.lbl_Antal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Antal.Font = new System.Drawing.Font("Consolas", 9F);
            this.lbl_Antal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_Antal.Location = new System.Drawing.Point(914, 28);
            this.lbl_Antal.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Antal.Name = "lbl_Antal";
            this.lbl_Antal.Size = new System.Drawing.Size(86, 29);
            this.lbl_Antal.TabIndex = 940;
            this.lbl_Antal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_ProdType
            // 
            this.lbl_ProdType.AutoSize = true;
            this.lbl_ProdType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.lbl_ProdType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ProdType.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_ProdType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_ProdType.Location = new System.Drawing.Point(114, 28);
            this.lbl_ProdType.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_ProdType.Name = "lbl_ProdType";
            this.lbl_ProdType.Size = new System.Drawing.Size(474, 29);
            this.lbl_ProdType.TabIndex = 939;
            this.lbl_ProdType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Customer
            // 
            this.lbl_Customer.AutoSize = true;
            this.lbl_Customer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.tlp_Main.SetColumnSpan(this.lbl_Customer, 2);
            this.lbl_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Customer.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_Customer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_Customer.Location = new System.Drawing.Point(114, 0);
            this.lbl_Customer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_Customer.Name = "lbl_Customer";
            this.lbl_Customer.Size = new System.Drawing.Size(800, 27);
            this.lbl_Customer.TabIndex = 931;
            this.lbl_Customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Customer
            // 
            this.label_Customer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Customer.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Customer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_Customer.Location = new System.Drawing.Point(0, 0);
            this.label_Customer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Customer.Name = "label_Customer";
            this.label_Customer.Size = new System.Drawing.Size(114, 27);
            this.label_Customer.TabIndex = 927;
            this.label_Customer.Text = "Kund: ";
            this.label_Customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ProdType
            // 
            this.label_ProdType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_ProdType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ProdType.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_ProdType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_ProdType.Location = new System.Drawing.Point(0, 28);
            this.label_ProdType.Margin = new System.Windows.Forms.Padding(0);
            this.label_ProdType.Name = "label_ProdType";
            this.label_ProdType.Size = new System.Drawing.Size(114, 29);
            this.label_ProdType.TabIndex = 937;
            this.label_ProdType.Text = "ProduktTyp:";
            this.label_ProdType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Amount
            // 
            this.label_Amount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_Amount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Amount.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Amount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_Amount.Location = new System.Drawing.Point(914, 0);
            this.label_Amount.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Amount.Name = "label_Amount";
            this.label_Amount.Size = new System.Drawing.Size(86, 27);
            this.label_Amount.TabIndex = 937;
            this.label_Amount.Text = "Antal:";
            this.label_Amount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Room_TempMoisture
            // 
            this.Room_TempMoisture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Room_TempMoisture.Location = new System.Drawing.Point(589, 28);
            this.Room_TempMoisture.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Room_TempMoisture.Name = "Room_TempMoisture";
            this.Room_TempMoisture.Size = new System.Drawing.Size(324, 29);
            this.Room_TempMoisture.TabIndex = 945;
            // 
            // MainInfo_A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.Controls.Add(this.tlp_Main);
            this.Name = "MainInfo_A";
            this.Size = new System.Drawing.Size(1178, 57);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        public Label lbl_OrderNr;
        public Label lbl_PartNumber;
        public Label label_OrderNr;
        public Label label_PartNumber;
        public Label lbl_ProdType;
        public Label lbl_Customer;
        public Label label_Customer;
        public Label label_ProdType;
        private Label label_Amount;
        public Label lbl_Antal;
        private Room_TempMoisture Room_TempMoisture;
    }
}
