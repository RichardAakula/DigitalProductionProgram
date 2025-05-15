
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.LineClearance
{
    partial class LineClearance_Extra
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
            this.label_Kund = new System.Windows.Forms.Label();
            this.lbl_Customer = new System.Windows.Forms.Label();
            this.tlp_MainInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_ArtikelNr = new System.Windows.Forms.Label();
            this.label_ArtikelNr = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.label_Line_Clearance = new System.Windows.Forms.Label();
            this.label_ID = new System.Windows.Forms.Label();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.lbl_InstructionLink = new System.Windows.Forms.LinkLabel();
            this.lbl_OrderNr = new System.Windows.Forms.Label();
            this.label_LineClearanceTemplate = new System.Windows.Forms.Label();
            this.label_Info_2 = new System.Windows.Forms.Label();
            this.label_Info_1 = new System.Windows.Forms.Label();
            this.tlp_LineClearance = new System.Windows.Forms.TableLayoutPanel();
            this.label_Comments = new System.Windows.Forms.Label();
            this.LC_Approved_Date = new System.Windows.Forms.Label();
            this.label_LC_Approved_Date = new System.Windows.Forms.Label();
            this.LC_Approved_Name = new System.Windows.Forms.Label();
            this.label_LC_Approved_Sign = new System.Windows.Forms.Label();
            this.lbl_LC_Approved_AnstNr = new System.Windows.Forms.Label();
            this.label_LC_Approved_AnstNr = new System.Windows.Forms.Label();
            this.lbl_LC_Performed_AnstNr = new System.Windows.Forms.Label();
            this.label_LC_Performed_AnstNr = new System.Windows.Forms.Label();
            this.label_LC_Performed_Sign = new System.Windows.Forms.Label();
            this.LC_Name = new System.Windows.Forms.Label();
            this.label_LC_Performed_Date = new System.Windows.Forms.Label();
            this.LC_Date = new System.Windows.Forms.Label();
            this.tb_Comments = new System.Windows.Forms.TextBox();
            this.flp_Checkboxes = new System.Windows.Forms.FlowLayoutPanel();
            this.tlp_MainInfo.SuspendLayout();
            this.panel_Info.SuspendLayout();
            this.tlp_LineClearance.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Kund
            // 
            this.label_Kund.BackColor = System.Drawing.Color.White;
            this.label_Kund.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Kund.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label_Kund.ForeColor = System.Drawing.Color.Black;
            this.label_Kund.Location = new System.Drawing.Point(1, 26);
            this.label_Kund.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Kund.Name = "label_Kund";
            this.label_Kund.Size = new System.Drawing.Size(49, 19);
            this.label_Kund.TabIndex = 927;
            this.label_Kund.Text = "Kund: ";
            this.label_Kund.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Customer
            // 
            this.lbl_Customer.AutoSize = true;
            this.lbl_Customer.BackColor = System.Drawing.Color.White;
            this.lbl_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Customer.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_Customer.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Customer.Location = new System.Drawing.Point(50, 26);
            this.lbl_Customer.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_Customer.Name = "lbl_Customer";
            this.lbl_Customer.Size = new System.Drawing.Size(350, 19);
            this.lbl_Customer.TabIndex = 931;
            this.lbl_Customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlp_MainInfo
            // 
            this.tlp_MainInfo.ColumnCount = 6;
            this.tlp_MainInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_MainInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tlp_MainInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlp_MainInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tlp_MainInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tlp_MainInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 352F));
            this.tlp_MainInfo.Controls.Add(this.lbl_ArtikelNr, 5, 1);
            this.tlp_MainInfo.Controls.Add(this.label_ArtikelNr, 4, 1);
            this.tlp_MainInfo.Controls.Add(this.lbl_ID, 3, 1);
            this.tlp_MainInfo.Controls.Add(this.label_Kund, 0, 1);
            this.tlp_MainInfo.Controls.Add(this.label_Line_Clearance, 0, 0);
            this.tlp_MainInfo.Controls.Add(this.lbl_Customer, 1, 1);
            this.tlp_MainInfo.Controls.Add(this.label_ID, 2, 1);
            this.tlp_MainInfo.Controls.Add(this.panel_Info, 0, 2);
            this.tlp_MainInfo.Controls.Add(this.tlp_LineClearance, 0, 3);
            this.tlp_MainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_MainInfo.Location = new System.Drawing.Point(0, 0);
            this.tlp_MainInfo.Name = "tlp_MainInfo";
            this.tlp_MainInfo.RowCount = 4;
            this.tlp_MainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_MainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_MainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlp_MainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_MainInfo.Size = new System.Drawing.Size(950, 823);
            this.tlp_MainInfo.TabIndex = 932;
            // 
            // lbl_ArtikelNr
            // 
            this.lbl_ArtikelNr.AutoSize = true;
            this.lbl_ArtikelNr.BackColor = System.Drawing.Color.White;
            this.lbl_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ArtikelNr.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_ArtikelNr.ForeColor = System.Drawing.Color.Gray;
            this.lbl_ArtikelNr.Location = new System.Drawing.Point(598, 26);
            this.lbl_ArtikelNr.Margin = new System.Windows.Forms.Padding(0, 1, 1, 0);
            this.lbl_ArtikelNr.Name = "lbl_ArtikelNr";
            this.lbl_ArtikelNr.Size = new System.Drawing.Size(351, 19);
            this.lbl_ArtikelNr.TabIndex = 936;
            this.lbl_ArtikelNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ArtikelNr
            // 
            this.label_ArtikelNr.BackColor = System.Drawing.Color.White;
            this.label_ArtikelNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ArtikelNr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label_ArtikelNr.ForeColor = System.Drawing.Color.Black;
            this.label_ArtikelNr.Location = new System.Drawing.Point(531, 26);
            this.label_ArtikelNr.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label_ArtikelNr.Name = "label_ArtikelNr";
            this.label_ArtikelNr.Size = new System.Drawing.Size(67, 19);
            this.label_ArtikelNr.TabIndex = 935;
            this.label_ArtikelNr.Text = "ArtikelNr:";
            this.label_ArtikelNr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.BackColor = System.Drawing.Color.White;
            this.lbl_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ID.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_ID.ForeColor = System.Drawing.Color.Gray;
            this.lbl_ID.Location = new System.Drawing.Point(427, 26);
            this.lbl_ID.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(104, 19);
            this.lbl_ID.TabIndex = 934;
            this.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Line_Clearance
            // 
            this.label_Line_Clearance.BackColor = System.Drawing.Color.LightGray;
            this.tlp_MainInfo.SetColumnSpan(this.label_Line_Clearance, 6);
            this.label_Line_Clearance.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Line_Clearance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Line_Clearance.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label_Line_Clearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_Line_Clearance.Location = new System.Drawing.Point(1, 1);
            this.label_Line_Clearance.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.label_Line_Clearance.Name = "label_Line_Clearance";
            this.label_Line_Clearance.Size = new System.Drawing.Size(948, 24);
            this.label_Line_Clearance.TabIndex = 933;
            this.label_Line_Clearance.Text = "Line Clearance";
            // 
            // label_ID
            // 
            this.label_ID.BackColor = System.Drawing.Color.White;
            this.label_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label_ID.ForeColor = System.Drawing.Color.Black;
            this.label_ID.Location = new System.Drawing.Point(400, 26);
            this.label_ID.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(27, 19);
            this.label_ID.TabIndex = 927;
            this.label_ID.Text = "ID:";
            this.label_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_Info
            // 
            this.panel_Info.BackColor = System.Drawing.Color.White;
            this.tlp_MainInfo.SetColumnSpan(this.panel_Info, 6);
            this.panel_Info.Controls.Add(this.lbl_InstructionLink);
            this.panel_Info.Controls.Add(this.lbl_OrderNr);
            this.panel_Info.Controls.Add(this.label_LineClearanceTemplate);
            this.panel_Info.Controls.Add(this.label_Info_2);
            this.panel_Info.Controls.Add(this.label_Info_1);
            this.panel_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Info.Location = new System.Drawing.Point(1, 45);
            this.panel_Info.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(948, 68);
            this.panel_Info.TabIndex = 937;
            // 
            // lbl_InstructionLink
            // 
            this.lbl_InstructionLink.AutoSize = true;
            this.lbl_InstructionLink.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.lbl_InstructionLink.Location = new System.Drawing.Point(558, 14);
            this.lbl_InstructionLink.Name = "lbl_InstructionLink";
            this.lbl_InstructionLink.Size = new System.Drawing.Size(40, 17);
            this.lbl_InstructionLink.TabIndex = 1;
            this.lbl_InstructionLink.TabStop = true;
            this.lbl_InstructionLink.Text = "I526";
            this.lbl_InstructionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.InstructionLink_LinkClicked);
            // 
            // lbl_OrderNr
            // 
            this.lbl_OrderNr.AutoSize = true;
            this.lbl_OrderNr.Font = new System.Drawing.Font("Lucida Sans", 10.25F, System.Drawing.FontStyle.Bold);
            this.lbl_OrderNr.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_OrderNr.Location = new System.Drawing.Point(200, 15);
            this.lbl_OrderNr.Name = "lbl_OrderNr";
            this.lbl_OrderNr.Size = new System.Drawing.Size(64, 16);
            this.lbl_OrderNr.TabIndex = 0;
            this.lbl_OrderNr.Text = "Q00000";
            // 
            // label_LineClearanceTemplate
            // 
            this.label_LineClearanceTemplate.AutoSize = true;
            this.label_LineClearanceTemplate.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LineClearanceTemplate.Location = new System.Drawing.Point(620, 15);
            this.label_LineClearanceTemplate.Name = "label_LineClearanceTemplate";
            this.label_LineClearanceTemplate.Size = new System.Drawing.Size(130, 17);
            this.label_LineClearanceTemplate.TabIndex = 0;
            this.label_LineClearanceTemplate.Text = "Template Name";
            // 
            // label_Info_2
            // 
            this.label_Info_2.AutoSize = true;
            this.label_Info_2.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_Info_2.Location = new System.Drawing.Point(265, 15);
            this.label_Info_2.Name = "label_Info_2";
            this.label_Info_2.Size = new System.Drawing.Size(278, 16);
            this.label_Info_2.TabIndex = 0;
            this.label_Info_2.Text = "är Line Clearance utförd enligt instruktion";
            // 
            // label_Info_1
            // 
            this.label_Info_1.AutoSize = true;
            this.label_Info_1.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_Info_1.Location = new System.Drawing.Point(20, 15);
            this.label_Info_1.Name = "label_Info_1";
            this.label_Info_1.Size = new System.Drawing.Size(178, 16);
            this.label_Info_1.TabIndex = 0;
            this.label_Info_1.Text = "Före tillverkning av order:";
            // 
            // tlp_LineClearance
            // 
            this.tlp_LineClearance.ColumnCount = 6;
            this.tlp_MainInfo.SetColumnSpan(this.tlp_LineClearance, 6);
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 286F));
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 241F));
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tlp_LineClearance.Controls.Add(this.label_Comments, 0, 3);
            this.tlp_LineClearance.Controls.Add(this.LC_Approved_Date, 5, 2);
            this.tlp_LineClearance.Controls.Add(this.label_LC_Approved_Date, 4, 2);
            this.tlp_LineClearance.Controls.Add(this.LC_Approved_Name, 3, 2);
            this.tlp_LineClearance.Controls.Add(this.label_LC_Approved_Sign, 2, 2);
            this.tlp_LineClearance.Controls.Add(this.lbl_LC_Approved_AnstNr, 1, 2);
            this.tlp_LineClearance.Controls.Add(this.label_LC_Approved_AnstNr, 0, 2);
            this.tlp_LineClearance.Controls.Add(this.lbl_LC_Performed_AnstNr, 1, 1);
            this.tlp_LineClearance.Controls.Add(this.label_LC_Performed_AnstNr, 0, 1);
            this.tlp_LineClearance.Controls.Add(this.label_LC_Performed_Sign, 2, 1);
            this.tlp_LineClearance.Controls.Add(this.LC_Name, 3, 1);
            this.tlp_LineClearance.Controls.Add(this.label_LC_Performed_Date, 4, 1);
            this.tlp_LineClearance.Controls.Add(this.LC_Date, 5, 1);
            this.tlp_LineClearance.Controls.Add(this.tb_Comments, 0, 4);
            this.tlp_LineClearance.Controls.Add(this.flp_Checkboxes, 0, 0);
            this.tlp_LineClearance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_LineClearance.Location = new System.Drawing.Point(0, 113);
            this.tlp_LineClearance.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_LineClearance.Name = "tlp_LineClearance";
            this.tlp_LineClearance.RowCount = 5;
            this.tlp_LineClearance.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_LineClearance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlp_LineClearance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlp_LineClearance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlp_LineClearance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_LineClearance.Size = new System.Drawing.Size(950, 710);
            this.tlp_LineClearance.TabIndex = 938;
            // 
            // label_Comments
            // 
            this.label_Comments.AutoSize = true;
            this.label_Comments.BackColor = System.Drawing.Color.White;
            this.tlp_LineClearance.SetColumnSpan(this.label_Comments, 6);
            this.label_Comments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Comments.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_Comments.Location = new System.Drawing.Point(1, 102);
            this.label_Comments.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Comments.Name = "label_Comments";
            this.label_Comments.Size = new System.Drawing.Size(948, 37);
            this.label_Comments.TabIndex = 17;
            this.label_Comments.Text = "Kommentarer:";
            this.label_Comments.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // LC_Approved_Date
            // 
            this.LC_Approved_Date.AutoSize = true;
            this.LC_Approved_Date.BackColor = System.Drawing.Color.White;
            this.LC_Approved_Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LC_Approved_Date.Font = new System.Drawing.Font("Courier New", 10.25F, System.Drawing.FontStyle.Bold);
            this.LC_Approved_Date.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LC_Approved_Date.Location = new System.Drawing.Point(745, 76);
            this.LC_Approved_Date.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.LC_Approved_Date.Name = "LC_Approved_Date";
            this.LC_Approved_Date.Size = new System.Drawing.Size(204, 25);
            this.LC_Approved_Date.TabIndex = 16;
            this.LC_Approved_Date.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_LC_Approved_Date
            // 
            this.label_LC_Approved_Date.AutoSize = true;
            this.label_LC_Approved_Date.BackColor = System.Drawing.Color.White;
            this.label_LC_Approved_Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LC_Approved_Date.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_LC_Approved_Date.Location = new System.Drawing.Point(646, 76);
            this.label_LC_Approved_Date.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_LC_Approved_Date.Name = "label_LC_Approved_Date";
            this.label_LC_Approved_Date.Size = new System.Drawing.Size(99, 25);
            this.label_LC_Approved_Date.TabIndex = 15;
            this.label_LC_Approved_Date.Text = "Datum/Tid:";
            this.label_LC_Approved_Date.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // LC_Approved_Name
            // 
            this.LC_Approved_Name.AutoSize = true;
            this.LC_Approved_Name.BackColor = System.Drawing.Color.White;
            this.LC_Approved_Name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LC_Approved_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LC_Approved_Name.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.LC_Approved_Name.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LC_Approved_Name.Location = new System.Drawing.Point(405, 76);
            this.LC_Approved_Name.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.LC_Approved_Name.Name = "LC_Approved_Name";
            this.LC_Approved_Name.Size = new System.Drawing.Size(241, 25);
            this.LC_Approved_Name.TabIndex = 14;
            this.LC_Approved_Name.Text = "Klicka här för godkännande...";
            this.LC_Approved_Name.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.LC_Approved_Name.Click += new System.EventHandler(this.LC_Approved_Click);
            // 
            // label_LC_Approved_Sign
            // 
            this.label_LC_Approved_Sign.AutoSize = true;
            this.label_LC_Approved_Sign.BackColor = System.Drawing.Color.White;
            this.label_LC_Approved_Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LC_Approved_Sign.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_LC_Approved_Sign.Location = new System.Drawing.Point(346, 76);
            this.label_LC_Approved_Sign.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_LC_Approved_Sign.Name = "label_LC_Approved_Sign";
            this.label_LC_Approved_Sign.Size = new System.Drawing.Size(59, 25);
            this.label_LC_Approved_Sign.TabIndex = 13;
            this.label_LC_Approved_Sign.Text = "Namn:";
            this.label_LC_Approved_Sign.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lbl_LC_Approved_AnstNr
            // 
            this.lbl_LC_Approved_AnstNr.AutoSize = true;
            this.lbl_LC_Approved_AnstNr.BackColor = System.Drawing.Color.White;
            this.lbl_LC_Approved_AnstNr.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_LC_Approved_AnstNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_LC_Approved_AnstNr.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_LC_Approved_AnstNr.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_LC_Approved_AnstNr.Location = new System.Drawing.Point(286, 76);
            this.lbl_LC_Approved_AnstNr.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_LC_Approved_AnstNr.Name = "lbl_LC_Approved_AnstNr";
            this.lbl_LC_Approved_AnstNr.Size = new System.Drawing.Size(60, 25);
            this.lbl_LC_Approved_AnstNr.TabIndex = 12;
            this.lbl_LC_Approved_AnstNr.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_LC_Approved_AnstNr
            // 
            this.label_LC_Approved_AnstNr.AutoSize = true;
            this.label_LC_Approved_AnstNr.BackColor = System.Drawing.Color.White;
            this.label_LC_Approved_AnstNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LC_Approved_AnstNr.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_LC_Approved_AnstNr.Location = new System.Drawing.Point(1, 76);
            this.label_LC_Approved_AnstNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_LC_Approved_AnstNr.Name = "label_LC_Approved_AnstNr";
            this.label_LC_Approved_AnstNr.Size = new System.Drawing.Size(285, 25);
            this.label_LC_Approved_AnstNr.TabIndex = 11;
            this.label_LC_Approved_AnstNr.Text = "Godkänd för produktion av: Anst.Nr:";
            this.label_LC_Approved_AnstNr.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lbl_LC_Performed_AnstNr
            // 
            this.lbl_LC_Performed_AnstNr.AutoSize = true;
            this.lbl_LC_Performed_AnstNr.BackColor = System.Drawing.Color.White;
            this.lbl_LC_Performed_AnstNr.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_LC_Performed_AnstNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_LC_Performed_AnstNr.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_LC_Performed_AnstNr.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_LC_Performed_AnstNr.Location = new System.Drawing.Point(286, 50);
            this.lbl_LC_Performed_AnstNr.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_LC_Performed_AnstNr.Name = "lbl_LC_Performed_AnstNr";
            this.lbl_LC_Performed_AnstNr.Size = new System.Drawing.Size(60, 26);
            this.lbl_LC_Performed_AnstNr.TabIndex = 0;
            this.lbl_LC_Performed_AnstNr.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_LC_Performed_AnstNr
            // 
            this.label_LC_Performed_AnstNr.AutoSize = true;
            this.label_LC_Performed_AnstNr.BackColor = System.Drawing.Color.White;
            this.label_LC_Performed_AnstNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LC_Performed_AnstNr.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_LC_Performed_AnstNr.Location = new System.Drawing.Point(1, 50);
            this.label_LC_Performed_AnstNr.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label_LC_Performed_AnstNr.Name = "label_LC_Performed_AnstNr";
            this.label_LC_Performed_AnstNr.Size = new System.Drawing.Size(285, 26);
            this.label_LC_Performed_AnstNr.TabIndex = 5;
            this.label_LC_Performed_AnstNr.Text = "Line Clearance utförd av: Anst.Nr:";
            this.label_LC_Performed_AnstNr.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label_LC_Performed_Sign
            // 
            this.label_LC_Performed_Sign.AutoSize = true;
            this.label_LC_Performed_Sign.BackColor = System.Drawing.Color.White;
            this.label_LC_Performed_Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LC_Performed_Sign.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_LC_Performed_Sign.Location = new System.Drawing.Point(346, 50);
            this.label_LC_Performed_Sign.Margin = new System.Windows.Forms.Padding(0);
            this.label_LC_Performed_Sign.Name = "label_LC_Performed_Sign";
            this.label_LC_Performed_Sign.Size = new System.Drawing.Size(59, 26);
            this.label_LC_Performed_Sign.TabIndex = 6;
            this.label_LC_Performed_Sign.Text = "Namn:";
            this.label_LC_Performed_Sign.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // LC_Name
            // 
            this.LC_Name.AutoSize = true;
            this.LC_Name.BackColor = System.Drawing.Color.White;
            this.LC_Name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LC_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LC_Name.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.LC_Name.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LC_Name.Location = new System.Drawing.Point(405, 50);
            this.LC_Name.Margin = new System.Windows.Forms.Padding(0);
            this.LC_Name.Name = "LC_Name";
            this.LC_Name.Size = new System.Drawing.Size(241, 26);
            this.LC_Name.TabIndex = 7;
            this.LC_Name.Text = "Klicka här för LC...";
            this.LC_Name.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.LC_Name.Click += new System.EventHandler(this.LC_Performed_Click);
            // 
            // label_LC_Performed_Date
            // 
            this.label_LC_Performed_Date.AutoSize = true;
            this.label_LC_Performed_Date.BackColor = System.Drawing.Color.White;
            this.label_LC_Performed_Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LC_Performed_Date.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.label_LC_Performed_Date.Location = new System.Drawing.Point(646, 50);
            this.label_LC_Performed_Date.Margin = new System.Windows.Forms.Padding(0);
            this.label_LC_Performed_Date.Name = "label_LC_Performed_Date";
            this.label_LC_Performed_Date.Size = new System.Drawing.Size(99, 26);
            this.label_LC_Performed_Date.TabIndex = 8;
            this.label_LC_Performed_Date.Text = "Datum/Tid:";
            this.label_LC_Performed_Date.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // LC_Date
            // 
            this.LC_Date.AutoSize = true;
            this.LC_Date.BackColor = System.Drawing.Color.White;
            this.LC_Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LC_Date.Font = new System.Drawing.Font("Courier New", 10.25F, System.Drawing.FontStyle.Bold);
            this.LC_Date.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LC_Date.Location = new System.Drawing.Point(745, 50);
            this.LC_Date.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.LC_Date.Name = "LC_Date";
            this.LC_Date.Size = new System.Drawing.Size(204, 26);
            this.LC_Date.TabIndex = 9;
            this.LC_Date.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tb_Comments
            // 
            this.tb_Comments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlp_LineClearance.SetColumnSpan(this.tb_Comments, 6);
            this.tb_Comments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Comments.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Comments.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Comments.Location = new System.Drawing.Point(1, 140);
            this.tb_Comments.Margin = new System.Windows.Forms.Padding(1);
            this.tb_Comments.Multiline = true;
            this.tb_Comments.Name = "tb_Comments";
            this.tb_Comments.Size = new System.Drawing.Size(948, 569);
            this.tb_Comments.TabIndex = 18;
            // 
            // flp_Checkboxes
            // 
            this.flp_Checkboxes.AutoSize = true;
            this.flp_Checkboxes.BackColor = System.Drawing.Color.White;
            this.tlp_LineClearance.SetColumnSpan(this.flp_Checkboxes, 6);
            this.flp_Checkboxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Checkboxes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Checkboxes.Location = new System.Drawing.Point(1, 0);
            this.flp_Checkboxes.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.flp_Checkboxes.MinimumSize = new System.Drawing.Size(0, 50);
            this.flp_Checkboxes.Name = "flp_Checkboxes";
            this.flp_Checkboxes.Size = new System.Drawing.Size(948, 50);
            this.flp_Checkboxes.TabIndex = 19;
            // 
            // LineClearance_Extra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(950, 823);
            this.Controls.Add(this.tlp_MainInfo);
            this.Name = "LineClearance_Extra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Line Clearance Extra";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LineClearance_Save_Comments_FormClosed);
            this.tlp_MainInfo.ResumeLayout(false);
            this.tlp_MainInfo.PerformLayout();
            this.panel_Info.ResumeLayout(false);
            this.panel_Info.PerformLayout();
            this.tlp_LineClearance.ResumeLayout(false);
            this.tlp_LineClearance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label_Kund;
        private Label lbl_Customer;
        private TableLayoutPanel tlp_MainInfo;
        private Label lbl_ArtikelNr;
        private Label label_ArtikelNr;
        private Label lbl_ID;
        private Label label_Line_Clearance;
        private Label label_ID;
        private Panel panel_Info;
        private Label lbl_OrderNr;
        private Label label_Info_2;
        private Label label_Info_1;
        private TableLayoutPanel tlp_LineClearance;
        private Label label_LC_Performed_AnstNr;
        private Label label_Comments;
        private Label LC_Approved_Date;
        private Label label_LC_Approved_Date;
        private Label LC_Approved_Name;
        private Label label_LC_Approved_Sign;
        private Label lbl_LC_Approved_AnstNr;
        private Label label_LC_Approved_AnstNr;
        private Label lbl_LC_Performed_AnstNr;
        private Label label_LC_Performed_Sign;
        private Label LC_Name;
        private Label label_LC_Performed_Date;
        private Label LC_Date;
        private TextBox tb_Comments;
        private LinkLabel lbl_InstructionLink;
        private Label label_LineClearanceTemplate;
        private FlowLayoutPanel flp_Checkboxes;
    }
}