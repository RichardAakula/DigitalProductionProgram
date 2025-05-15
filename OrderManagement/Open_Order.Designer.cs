using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.OrderManagement
{
    partial class Open_Order
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_OpenOrder = new System.Windows.Forms.Button();
            this.label_ProdLine = new System.Windows.Forms.Label();
            this.label_PartNumber = new System.Windows.Forms.Label();
            this.dgv_OrderList = new System.Windows.Forms.DataGridView();
            this.tb_PartNumber = new System.Windows.Forms.TextBox();
            this.tb_ProdLine = new System.Windows.Forms.TextBox();
            this.label_DateFrom = new System.Windows.Forms.Label();
            this.date_From = new System.Windows.Forms.DateTimePicker();
            this.label_DateTo = new System.Windows.Forms.Label();
            this.date_To = new System.Windows.Forms.DateTimePicker();
            this.label_Customer = new System.Windows.Forms.Label();
            this.tb_Customer = new System.Windows.Forms.TextBox();
            this.label_OrderNr = new System.Windows.Forms.Label();
            this.tb_OrderNr = new System.Windows.Forms.TextBox();
            this.label_Frisökning = new System.Windows.Forms.Label();
            this.tb_CodeText = new System.Windows.Forms.TextBox();
            this.tb_FreeText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OpenOrder
            // 
            this.btn_OpenOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OpenOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OpenOrder.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.btn_OpenOrder.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_OpenOrder.Location = new System.Drawing.Point(1039, 503);
            this.btn_OpenOrder.Name = "btn_OpenOrder";
            this.btn_OpenOrder.Size = new System.Drawing.Size(121, 29);
            this.btn_OpenOrder.TabIndex = 1;
            this.btn_OpenOrder.Text = "Öppna order";
            this.btn_OpenOrder.UseVisualStyleBackColor = true;
            this.btn_OpenOrder.Click += new System.EventHandler(this.Öppna_Click);
            // 
            // label_ProdLine
            // 
            this.label_ProdLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ProdLine.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_ProdLine.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label_ProdLine.Location = new System.Drawing.Point(1024, 130);
            this.label_ProdLine.Name = "label_ProdLine";
            this.label_ProdLine.Size = new System.Drawing.Size(136, 16);
            this.label_ProdLine.TabIndex = 8;
            this.label_ProdLine.Text = "ProduktionsLinje:";
            this.label_ProdLine.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_PartNumber
            // 
            this.label_PartNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PartNumber.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_PartNumber.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label_PartNumber.Location = new System.Drawing.Point(1024, 70);
            this.label_PartNumber.Name = "label_PartNumber";
            this.label_PartNumber.Size = new System.Drawing.Size(136, 16);
            this.label_PartNumber.TabIndex = 2;
            this.label_PartNumber.Text = "ArtikelNr:";
            this.label_PartNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgv_OrderList
            // 
            this.dgv_OrderList.AllowUserToAddRows = false;
            this.dgv_OrderList.AllowUserToDeleteRows = false;
            this.dgv_OrderList.AllowUserToResizeColumns = false;
            this.dgv_OrderList.AllowUserToResizeRows = false;
            this.dgv_OrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_OrderList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            this.dgv_OrderList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(85)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(146)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_OrderList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_OrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(228)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_OrderList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_OrderList.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_OrderList.EnableHeadersVisualStyles = false;
            this.dgv_OrderList.Location = new System.Drawing.Point(0, 0);
            this.dgv_OrderList.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.dgv_OrderList.MultiSelect = false;
            this.dgv_OrderList.Name = "dgv_OrderList";
            this.dgv_OrderList.RowHeadersVisible = false;
            this.dgv_OrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_OrderList.Size = new System.Drawing.Size(600, 544);
            this.dgv_OrderList.TabIndex = 14;
            // 
            // tb_PartNumber
            // 
            this.tb_PartNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_PartNumber.Location = new System.Drawing.Point(1024, 90);
            this.tb_PartNumber.Name = "tb_PartNumber";
            this.tb_PartNumber.Size = new System.Drawing.Size(136, 20);
            this.tb_PartNumber.TabIndex = 15;
            this.tb_PartNumber.TextChanged += new System.EventHandler(this.PartNumber_TextChanged);
            // 
            // tb_ProdLine
            // 
            this.tb_ProdLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ProdLine.Location = new System.Drawing.Point(1024, 150);
            this.tb_ProdLine.Name = "tb_ProdLine";
            this.tb_ProdLine.Size = new System.Drawing.Size(136, 20);
            this.tb_ProdLine.TabIndex = 15;
            this.tb_ProdLine.TextChanged += new System.EventHandler(this.PartNumber_TextChanged);
            // 
            // label_DateFrom
            // 
            this.label_DateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_DateFrom.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_DateFrom.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label_DateFrom.Location = new System.Drawing.Point(960, 310);
            this.label_DateFrom.Name = "label_DateFrom";
            this.label_DateFrom.Size = new System.Drawing.Size(200, 16);
            this.label_DateFrom.TabIndex = 16;
            this.label_DateFrom.Text = "Från Datum";
            this.label_DateFrom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // date_From
            // 
            this.date_From.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date_From.Location = new System.Drawing.Point(960, 330);
            this.date_From.Name = "date_From";
            this.date_From.Size = new System.Drawing.Size(200, 20);
            this.date_From.TabIndex = 17;
            this.date_From.ValueChanged += new System.EventHandler(this.PartNumber_TextChanged);
            // 
            // label_DateTo
            // 
            this.label_DateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_DateTo.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_DateTo.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label_DateTo.Location = new System.Drawing.Point(960, 250);
            this.label_DateTo.Name = "label_DateTo";
            this.label_DateTo.Size = new System.Drawing.Size(200, 16);
            this.label_DateTo.TabIndex = 16;
            this.label_DateTo.Text = "Till Datum";
            this.label_DateTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // date_To
            // 
            this.date_To.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date_To.Location = new System.Drawing.Point(960, 270);
            this.date_To.Name = "date_To";
            this.date_To.Size = new System.Drawing.Size(200, 20);
            this.date_To.TabIndex = 17;
            this.date_To.ValueChanged += new System.EventHandler(this.PartNumber_TextChanged);
            // 
            // label_Customer
            // 
            this.label_Customer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Customer.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_Customer.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label_Customer.Location = new System.Drawing.Point(1024, 191);
            this.label_Customer.Name = "label_Customer";
            this.label_Customer.Size = new System.Drawing.Size(136, 16);
            this.label_Customer.TabIndex = 8;
            this.label_Customer.Text = "Kund:";
            this.label_Customer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tb_Customer
            // 
            this.tb_Customer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Customer.Location = new System.Drawing.Point(1024, 210);
            this.tb_Customer.Name = "tb_Customer";
            this.tb_Customer.Size = new System.Drawing.Size(136, 20);
            this.tb_Customer.TabIndex = 15;
            this.tb_Customer.TextChanged += new System.EventHandler(this.PartNumber_TextChanged);
            // 
            // label_OrderNr
            // 
            this.label_OrderNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_OrderNr.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_OrderNr.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label_OrderNr.Location = new System.Drawing.Point(1024, 10);
            this.label_OrderNr.Name = "label_OrderNr";
            this.label_OrderNr.Size = new System.Drawing.Size(136, 16);
            this.label_OrderNr.TabIndex = 2;
            this.label_OrderNr.Text = "OrderNr";
            this.label_OrderNr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tb_OrderNr
            // 
            this.tb_OrderNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_OrderNr.Location = new System.Drawing.Point(1024, 30);
            this.tb_OrderNr.Name = "tb_OrderNr";
            this.tb_OrderNr.Size = new System.Drawing.Size(136, 20);
            this.tb_OrderNr.TabIndex = 15;
            this.tb_OrderNr.TextChanged += new System.EventHandler(this.PartNumber_TextChanged);
            // 
            // label_Frisökning
            // 
            this.label_Frisökning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Frisökning.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.label_Frisökning.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label_Frisökning.Location = new System.Drawing.Point(1024, 372);
            this.label_Frisökning.Name = "label_Frisökning";
            this.label_Frisökning.Size = new System.Drawing.Size(136, 16);
            this.label_Frisökning.TabIndex = 8;
            this.label_Frisökning.Text = "Fritext:";
            this.label_Frisökning.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_Frisökning.Visible = false;
            // 
            // tb_CodeText
            // 
            this.tb_CodeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_CodeText.Location = new System.Drawing.Point(1024, 391);
            this.tb_CodeText.Name = "tb_CodeText";
            this.tb_CodeText.ReadOnly = true;
            this.tb_CodeText.Size = new System.Drawing.Size(136, 20);
            this.tb_CodeText.TabIndex = 15;
            this.tb_CodeText.Visible = false;
            this.tb_CodeText.Click += new System.EventHandler(this.tb_CodeText_Click);
            // 
            // tb_FreeText
            // 
            this.tb_FreeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_FreeText.Location = new System.Drawing.Point(1024, 427);
            this.tb_FreeText.Name = "tb_FreeText";
            this.tb_FreeText.Size = new System.Drawing.Size(136, 20);
            this.tb_FreeText.TabIndex = 15;
            this.tb_FreeText.Visible = false;
            this.tb_FreeText.TextChanged += new System.EventHandler(this.PartNumber_TextChanged);
            // 
            // Öppna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1172, 544);
            this.Controls.Add(this.date_To);
            this.Controls.Add(this.date_From);
            this.Controls.Add(this.label_DateTo);
            this.Controls.Add(this.label_DateFrom);
            this.Controls.Add(this.tb_FreeText);
            this.Controls.Add(this.tb_CodeText);
            this.Controls.Add(this.tb_Customer);
            this.Controls.Add(this.tb_ProdLine);
            this.Controls.Add(this.tb_OrderNr);
            this.Controls.Add(this.tb_PartNumber);
            this.Controls.Add(this.dgv_OrderList);
            this.Controls.Add(this.label_Frisökning);
            this.Controls.Add(this.label_Customer);
            this.Controls.Add(this.label_ProdLine);
            this.Controls.Add(this.label_OrderNr);
            this.Controls.Add(this.label_PartNumber);
            this.Controls.Add(this.btn_OpenOrder);
            this.Name = "Öppna";
            this.Text = "Öppna";
            this.Load += new System.EventHandler(this.Öppna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OrderList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btn_OpenOrder;
        private Label label_ProdLine;
        private Label label_PartNumber;
        private DataGridView dgv_OrderList;
        private TextBox tb_PartNumber;
        private TextBox tb_ProdLine;
        private Label label_DateFrom;
        private DateTimePicker date_From;
        private Label label_DateTo;
        private DateTimePicker date_To;
        private Label label_Customer;
        private TextBox tb_Customer;
        private Label label_OrderNr;
        private TextBox tb_OrderNr;
        private Label label_Frisökning;
        private TextBox tb_CodeText;
        private TextBox tb_FreeText;
    }
}