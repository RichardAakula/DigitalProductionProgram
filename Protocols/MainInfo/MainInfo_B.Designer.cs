
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.MainInfo
{
    partial class MainInfo_B
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
            this.tlp_Main_Top = new System.Windows.Forms.TableLayoutPanel();
            this.label_Customer = new System.Windows.Forms.Label();
            this.lbl_Customer = new System.Windows.Forms.Label();
            this.ProdType = new System.Windows.Forms.TextBox();
            this.label_ProdType = new System.Windows.Forms.Label();
            this.lbl_OrderNr = new System.Windows.Forms.Label();
            this.label_OrderNr = new System.Windows.Forms.Label();
            this.tlp_Main_Bottom = new System.Windows.Forms.TableLayoutPanel();
            this.label_ID = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.WALL = new System.Windows.Forms.TextBox();
            this.label_W = new System.Windows.Forms.Label();
            this.OD = new System.Windows.Forms.TextBox();
            this.label_OD = new System.Windows.Forms.Label();
            this.LENGTH = new System.Windows.Forms.TextBox();
            this.label_Length = new System.Windows.Forms.Label();
            this.Room_TempMoisture = new DigitalProductionProgram.Protocols.MainInfo.Room_TempMoisture();
            this.lbl_ArtikelNr = new System.Windows.Forms.Label();
            this.label_PartNumber = new System.Windows.Forms.Label();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Main_Top.SuspendLayout();
            this.tlp_Main_Bottom.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main_Top
            // 
            this.tlp_Main_Top.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main_Top.ColumnCount = 4;
            this.tlp_Main_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlp_Main_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tlp_Main_Top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main_Top.Controls.Add(this.label_Customer, 0, 0);
            this.tlp_Main_Top.Controls.Add(this.lbl_Customer, 1, 0);
            this.tlp_Main_Top.Controls.Add(this.ProdType, 3, 0);
            this.tlp_Main_Top.Controls.Add(this.label_ProdType, 2, 0);
            this.tlp_Main_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main_Top.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main_Top.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main_Top.Name = "tlp_Main_Top";
            this.tlp_Main_Top.RowCount = 1;
            this.tlp_Main_Top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main_Top.Size = new System.Drawing.Size(864, 34);
            this.tlp_Main_Top.TabIndex = 942;
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
            this.label_Customer.Size = new System.Drawing.Size(84, 33);
            this.label_Customer.TabIndex = 926;
            this.label_Customer.Text = "Kund: ";
            this.label_Customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Customer
            // 
            this.lbl_Customer.AutoSize = true;
            this.lbl_Customer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.lbl_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Customer.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbl_Customer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_Customer.Location = new System.Drawing.Point(84, 0);
            this.lbl_Customer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_Customer.Name = "lbl_Customer";
            this.lbl_Customer.Size = new System.Drawing.Size(335, 33);
            this.lbl_Customer.TabIndex = 930;
            this.lbl_Customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProdType
            // 
            this.ProdType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.ProdType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProdType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProdType.Font = new System.Drawing.Font("Consolas", 10F);
            this.ProdType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.ProdType.Location = new System.Drawing.Point(529, 0);
            this.ProdType.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.ProdType.Multiline = true;
            this.ProdType.Name = "ProdType";
            this.ProdType.Size = new System.Drawing.Size(335, 33);
            this.ProdType.TabIndex = 937;
            this.ProdType.Click += new System.EventHandler(this.ProdType_Click);
            // 
            // label_ProdType
            // 
            this.label_ProdType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_ProdType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ProdType.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_ProdType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_ProdType.Location = new System.Drawing.Point(419, 0);
            this.label_ProdType.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_ProdType.Name = "label_ProdType";
            this.label_ProdType.Size = new System.Drawing.Size(109, 33);
            this.label_ProdType.TabIndex = 936;
            this.label_ProdType.Text = "Produkt typ:";
            this.label_ProdType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderNr
            // 
            this.lbl_OrderNr.AutoSize = true;
            this.lbl_OrderNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.lbl_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderNr.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbl_OrderNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_OrderNr.Location = new System.Drawing.Point(933, 35);
            this.lbl_OrderNr.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_OrderNr.Name = "lbl_OrderNr";
            this.lbl_OrderNr.Size = new System.Drawing.Size(180, 34);
            this.lbl_OrderNr.TabIndex = 939;
            this.lbl_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr
            // 
            this.label_OrderNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OrderNr.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_OrderNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_OrderNr.Location = new System.Drawing.Point(865, 35);
            this.label_OrderNr.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_OrderNr.Name = "label_OrderNr";
            this.label_OrderNr.Size = new System.Drawing.Size(68, 34);
            this.label_OrderNr.TabIndex = 938;
            this.label_OrderNr.Text = "T.O. nr:";
            this.label_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlp_Main_Bottom
            // 
            this.tlp_Main_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.tlp_Main_Bottom.ColumnCount = 9;
            this.tlp_Main_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_Main_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlp_Main_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_Main_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlp_Main_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_Main_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlp_Main_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlp_Main_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tlp_Main_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 387F));
            this.tlp_Main_Bottom.Controls.Add(this.label_ID, 0, 0);
            this.tlp_Main_Bottom.Controls.Add(this.ID, 1, 0);
            this.tlp_Main_Bottom.Controls.Add(this.WALL, 5, 0);
            this.tlp_Main_Bottom.Controls.Add(this.label_W, 4, 0);
            this.tlp_Main_Bottom.Controls.Add(this.OD, 3, 0);
            this.tlp_Main_Bottom.Controls.Add(this.label_OD, 2, 0);
            this.tlp_Main_Bottom.Controls.Add(this.LENGTH, 7, 0);
            this.tlp_Main_Bottom.Controls.Add(this.label_Length, 6, 0);
            this.tlp_Main_Bottom.Controls.Add(this.Room_TempMoisture, 8, 0);
            this.tlp_Main_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main_Bottom.Location = new System.Drawing.Point(0, 34);
            this.tlp_Main_Bottom.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main_Bottom.Name = "tlp_Main_Bottom";
            this.tlp_Main_Bottom.RowCount = 1;
            this.tlp_Main_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main_Bottom.Size = new System.Drawing.Size(864, 35);
            this.tlp_Main_Bottom.TabIndex = 943;
            // 
            // label_ID
            // 
            this.label_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ID.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_ID.Location = new System.Drawing.Point(0, 1);
            this.label_ID.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(35, 34);
            this.label_ID.TabIndex = 927;
            this.label_ID.Text = "ID:";
            // 
            // ID
            // 
            this.ID.AccessibleName = "tb_ID";
            this.ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ID.Font = new System.Drawing.Font("Consolas", 9F);
            this.ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.ID.Location = new System.Drawing.Point(35, 1);
            this.ID.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.ID.MaxLength = 6;
            this.ID.Multiline = true;
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(70, 34);
            this.ID.TabIndex = 928;
            this.ID.TextChanged += new System.EventHandler(this.Value_TextChanged);
            this.ID.Leave += new System.EventHandler(this.ID_OD_Leave);
            // 
            // WALL
            // 
            this.WALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.WALL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WALL.Font = new System.Drawing.Font("Consolas", 9F);
            this.WALL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.WALL.Location = new System.Drawing.Point(245, 1);
            this.WALL.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.WALL.MaxLength = 5;
            this.WALL.Multiline = true;
            this.WALL.Name = "WALL";
            this.WALL.Size = new System.Drawing.Size(70, 34);
            this.WALL.TabIndex = 933;
            this.WALL.TextChanged += new System.EventHandler(this.Value_TextChanged);
            // 
            // label_W
            // 
            this.label_W.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_W.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_W.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_W.Location = new System.Drawing.Point(211, 1);
            this.label_W.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_W.Name = "label_W";
            this.label_W.Size = new System.Drawing.Size(34, 34);
            this.label_W.TabIndex = 932;
            this.label_W.Text = "W:";
            // 
            // OD
            // 
            this.OD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.OD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OD.Font = new System.Drawing.Font("Consolas", 9F);
            this.OD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.OD.Location = new System.Drawing.Point(140, 1);
            this.OD.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.OD.MaxLength = 6;
            this.OD.Multiline = true;
            this.OD.Name = "OD";
            this.OD.Size = new System.Drawing.Size(70, 34);
            this.OD.TabIndex = 931;
            this.OD.TextChanged += new System.EventHandler(this.Value_TextChanged);
            this.OD.Leave += new System.EventHandler(this.ID_OD_Leave);
            // 
            // label_OD
            // 
            this.label_OD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_OD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OD.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_OD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_OD.Location = new System.Drawing.Point(106, 1);
            this.label_OD.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_OD.Name = "label_OD";
            this.label_OD.Size = new System.Drawing.Size(34, 34);
            this.label_OD.TabIndex = 929;
            this.label_OD.Text = "OD:";
            // 
            // LENGTH
            // 
            this.LENGTH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.LENGTH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LENGTH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LENGTH.Font = new System.Drawing.Font("Consolas", 9F);
            this.LENGTH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.LENGTH.Location = new System.Drawing.Point(370, 1);
            this.LENGTH.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.LENGTH.MaxLength = 9;
            this.LENGTH.Multiline = true;
            this.LENGTH.Name = "LENGTH";
            this.LENGTH.Size = new System.Drawing.Size(107, 34);
            this.LENGTH.TabIndex = 935;
            this.LENGTH.TextChanged += new System.EventHandler(this.Value_TextChanged);
            // 
            // label_Length
            // 
            this.label_Length.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_Length.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Length.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Length.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_Length.Location = new System.Drawing.Point(316, 1);
            this.label_Length.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Length.Name = "label_Length";
            this.label_Length.Size = new System.Drawing.Size(54, 34);
            this.label_Length.TabIndex = 934;
            this.label_Length.Text = "Längd:";
            // 
            // Room_TempMoisture
            // 
            this.Room_TempMoisture.Dock = System.Windows.Forms.DockStyle.Right;
            this.Room_TempMoisture.Location = new System.Drawing.Point(478, 1);
            this.Room_TempMoisture.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.Room_TempMoisture.Name = "Room_TempMoisture";
            this.Room_TempMoisture.Size = new System.Drawing.Size(385, 34);
            this.Room_TempMoisture.TabIndex = 936;
            // 
            // lbl_ArtikelNr
            // 
            this.lbl_ArtikelNr.AutoSize = true;
            this.lbl_ArtikelNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.lbl_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ArtikelNr.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbl_ArtikelNr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.lbl_ArtikelNr.Location = new System.Drawing.Point(933, 0);
            this.lbl_ArtikelNr.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_ArtikelNr.Name = "lbl_ArtikelNr";
            this.lbl_ArtikelNr.Size = new System.Drawing.Size(180, 33);
            this.lbl_ArtikelNr.TabIndex = 941;
            this.lbl_ArtikelNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_PartNumber
            // 
            this.label_PartNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.label_PartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PartNumber.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_PartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.label_PartNumber.Location = new System.Drawing.Point(865, 0);
            this.label_PartNumber.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_PartNumber.Name = "label_PartNumber";
            this.label_PartNumber.Size = new System.Drawing.Size(68, 33);
            this.label_PartNumber.TabIndex = 940;
            this.label_PartNumber.Text = "ArtikelNr:";
            this.label_PartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 3;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlp_Main.Controls.Add(this.tlp_Main_Bottom, 0, 1);
            this.tlp_Main.Controls.Add(this.label_PartNumber, 1, 0);
            this.tlp_Main.Controls.Add(this.tlp_Main_Top, 0, 0);
            this.tlp_Main.Controls.Add(this.lbl_ArtikelNr, 2, 0);
            this.tlp_Main.Controls.Add(this.label_OrderNr, 1, 1);
            this.tlp_Main.Controls.Add(this.lbl_OrderNr, 2, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Size = new System.Drawing.Size(1113, 69);
            this.tlp_Main.TabIndex = 944;
            // 
            // MainInfo_B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tlp_Main);
            this.Name = "MainInfo_B";
            this.Size = new System.Drawing.Size(1113, 69);
            this.tlp_Main_Top.ResumeLayout(false);
            this.tlp_Main_Top.PerformLayout();
            this.tlp_Main_Bottom.ResumeLayout(false);
            this.tlp_Main_Bottom.PerformLayout();
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label_Customer;
        public TextBox ID;
        public TextBox OD;
        public TextBox WALL;
        public TextBox LENGTH;
        private Label label_ProdType;
        private TableLayoutPanel tlp_Main_Top;
        private TableLayoutPanel tlp_Main_Bottom;
        private TableLayoutPanel tlp_Main;
        public Label lbl_Customer;
        public TextBox ProdType;
        public Label lbl_OrderNr;
        public Label lbl_ArtikelNr;
        public Label label_OrderNr;
        public Label label_PartNumber;
        public Label label_OD;
        public Label label_W;
        public Label label_Length;
        public Label label_ID;
        private Room_TempMoisture Room_TempMoisture;
    }
}
