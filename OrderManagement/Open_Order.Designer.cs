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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btn_OpenOrder = new Button();
            label_ProdLine = new Label();
            label_PartNumber = new Label();
            dgv_OrderList = new DataGridView();
            tb_PartNumber = new TextBox();
            tb_ProdLine = new TextBox();
            label_DateFrom = new Label();
            date_From = new DateTimePicker();
            label_DateTo = new Label();
            date_To = new DateTimePicker();
            label_Customer = new Label();
            tb_Customer = new TextBox();
            label_OrderNr = new Label();
            tb_OrderNr = new TextBox();
            label_Frisökning = new Label();
            tb_CodeText = new TextBox();
            tb_FreeText = new TextBox();
            label_TemplateName = new Label();
            tb_TemplateName = new TextBox();
            ((ISupportInitialize)dgv_OrderList).BeginInit();
            SuspendLayout();
            // 
            // btn_OpenOrder
            // 
            btn_OpenOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_OpenOrder.FlatStyle = FlatStyle.Flat;
            btn_OpenOrder.Font = new Font("Lucida Sans", 10.25F);
            btn_OpenOrder.ForeColor = Color.DarkGoldenrod;
            btn_OpenOrder.Location = new Point(1488, 650);
            btn_OpenOrder.Margin = new Padding(4, 3, 4, 3);
            btn_OpenOrder.Name = "btn_OpenOrder";
            btn_OpenOrder.Size = new Size(141, 33);
            btn_OpenOrder.TabIndex = 1;
            btn_OpenOrder.Text = "Öppna order";
            btn_OpenOrder.UseVisualStyleBackColor = true;
            btn_OpenOrder.Click += Öppna_Click;
            // 
            // label_ProdLine
            // 
            label_ProdLine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_ProdLine.Font = new Font("Lucida Sans", 10.25F);
            label_ProdLine.ForeColor = Color.DarkGoldenrod;
            label_ProdLine.Location = new Point(1471, 150);
            label_ProdLine.Margin = new Padding(4, 0, 4, 0);
            label_ProdLine.Name = "label_ProdLine";
            label_ProdLine.Size = new Size(159, 18);
            label_ProdLine.TabIndex = 8;
            label_ProdLine.Text = "ProduktionsLinje:";
            label_ProdLine.TextAlign = ContentAlignment.TopRight;
            // 
            // label_PartNumber
            // 
            label_PartNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_PartNumber.Font = new Font("Lucida Sans", 10.25F);
            label_PartNumber.ForeColor = Color.DarkGoldenrod;
            label_PartNumber.Location = new Point(1471, 81);
            label_PartNumber.Margin = new Padding(4, 0, 4, 0);
            label_PartNumber.Name = "label_PartNumber";
            label_PartNumber.Size = new Size(159, 18);
            label_PartNumber.TabIndex = 2;
            label_PartNumber.Text = "ArtikelNr:";
            label_PartNumber.TextAlign = ContentAlignment.TopRight;
            // 
            // dgv_OrderList
            // 
            dgv_OrderList.AllowUserToAddRows = false;
            dgv_OrderList.AllowUserToDeleteRows = false;
            dgv_OrderList.AllowUserToResizeColumns = false;
            dgv_OrderList.AllowUserToResizeRows = false;
            dgv_OrderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_OrderList.BackgroundColor = Color.FromArgb(63, 115, 140);
            dgv_OrderList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle1.Font = new Font("Arial", 11.25F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(183, 220, 233);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(147, 146, 153);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_OrderList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_OrderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_OrderList.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_OrderList.Dock = DockStyle.Left;
            dgv_OrderList.EnableHeadersVisualStyles = false;
            dgv_OrderList.Location = new Point(0, 0);
            dgv_OrderList.Margin = new Padding(12, 12, 4, 3);
            dgv_OrderList.MultiSelect = false;
            dgv_OrderList.Name = "dgv_OrderList";
            dgv_OrderList.RowHeadersVisible = false;
            dgv_OrderList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_OrderList.Size = new Size(1263, 704);
            dgv_OrderList.TabIndex = 14;
            // 
            // tb_PartNumber
            // 
            tb_PartNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_PartNumber.Location = new Point(1471, 104);
            tb_PartNumber.Margin = new Padding(4, 3, 4, 3);
            tb_PartNumber.Name = "tb_PartNumber";
            tb_PartNumber.Size = new Size(158, 23);
            tb_PartNumber.TabIndex = 15;
            tb_PartNumber.TextChanged += Filter_TextChanged;
            // 
            // tb_ProdLine
            // 
            tb_ProdLine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_ProdLine.Location = new Point(1471, 173);
            tb_ProdLine.Margin = new Padding(4, 3, 4, 3);
            tb_ProdLine.Name = "tb_ProdLine";
            tb_ProdLine.Size = new Size(158, 23);
            tb_ProdLine.TabIndex = 15;
            tb_ProdLine.TextChanged += Filter_TextChanged;
            // 
            // label_DateFrom
            // 
            label_DateFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_DateFrom.Font = new Font("Lucida Sans", 10.25F);
            label_DateFrom.ForeColor = Color.DarkGoldenrod;
            label_DateFrom.Location = new Point(1396, 428);
            label_DateFrom.Margin = new Padding(4, 0, 4, 0);
            label_DateFrom.Name = "label_DateFrom";
            label_DateFrom.Size = new Size(233, 18);
            label_DateFrom.TabIndex = 16;
            label_DateFrom.Text = "Från Datum";
            label_DateFrom.TextAlign = ContentAlignment.TopRight;
            label_DateFrom.Click += label_DateFrom_Click;
            // 
            // date_From
            // 
            date_From.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            date_From.Location = new Point(1396, 451);
            date_From.Margin = new Padding(4, 3, 4, 3);
            date_From.Name = "date_From";
            date_From.Size = new Size(233, 23);
            date_From.TabIndex = 17;
            date_From.ValueChanged += date_From_ValueChanged;
            // 
            // label_DateTo
            // 
            label_DateTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_DateTo.Font = new Font("Lucida Sans", 10.25F);
            label_DateTo.ForeColor = Color.DarkGoldenrod;
            label_DateTo.Location = new Point(1396, 358);
            label_DateTo.Margin = new Padding(4, 0, 4, 0);
            label_DateTo.Name = "label_DateTo";
            label_DateTo.Size = new Size(233, 18);
            label_DateTo.TabIndex = 16;
            label_DateTo.Text = "Till Datum";
            label_DateTo.TextAlign = ContentAlignment.TopRight;
            // 
            // date_To
            // 
            date_To.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            date_To.Location = new Point(1396, 382);
            date_To.Margin = new Padding(4, 3, 4, 3);
            date_To.Name = "date_To";
            date_To.Size = new Size(233, 23);
            date_To.TabIndex = 17;
            date_To.ValueChanged += Filter_TextChanged;
            // 
            // label_Customer
            // 
            label_Customer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_Customer.Font = new Font("Lucida Sans", 10.25F);
            label_Customer.ForeColor = Color.DarkGoldenrod;
            label_Customer.Location = new Point(1471, 220);
            label_Customer.Margin = new Padding(4, 0, 4, 0);
            label_Customer.Name = "label_Customer";
            label_Customer.Size = new Size(159, 18);
            label_Customer.TabIndex = 8;
            label_Customer.Text = "Kund:";
            label_Customer.TextAlign = ContentAlignment.TopRight;
            // 
            // tb_Customer
            // 
            tb_Customer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_Customer.Location = new Point(1471, 242);
            tb_Customer.Margin = new Padding(4, 3, 4, 3);
            tb_Customer.Name = "tb_Customer";
            tb_Customer.Size = new Size(158, 23);
            tb_Customer.TabIndex = 15;
            tb_Customer.TextChanged += Filter_TextChanged;
            // 
            // label_OrderNr
            // 
            label_OrderNr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_OrderNr.Font = new Font("Lucida Sans", 10.25F);
            label_OrderNr.ForeColor = Color.DarkGoldenrod;
            label_OrderNr.Location = new Point(1471, 12);
            label_OrderNr.Margin = new Padding(4, 0, 4, 0);
            label_OrderNr.Name = "label_OrderNr";
            label_OrderNr.Size = new Size(159, 18);
            label_OrderNr.TabIndex = 2;
            label_OrderNr.Text = "OrderNr";
            label_OrderNr.TextAlign = ContentAlignment.TopRight;
            // 
            // tb_OrderNr
            // 
            tb_OrderNr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_OrderNr.Location = new Point(1471, 35);
            tb_OrderNr.Margin = new Padding(4, 3, 4, 3);
            tb_OrderNr.Name = "tb_OrderNr";
            tb_OrderNr.Size = new Size(158, 23);
            tb_OrderNr.TabIndex = 15;
            tb_OrderNr.TextChanged += Filter_TextChanged;
            // 
            // label_Frisökning
            // 
            label_Frisökning.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_Frisökning.Font = new Font("Lucida Sans", 10.25F);
            label_Frisökning.ForeColor = Color.DarkGoldenrod;
            label_Frisökning.Location = new Point(1471, 499);
            label_Frisökning.Margin = new Padding(4, 0, 4, 0);
            label_Frisökning.Name = "label_Frisökning";
            label_Frisökning.Size = new Size(159, 18);
            label_Frisökning.TabIndex = 8;
            label_Frisökning.Text = "Fritext:";
            label_Frisökning.TextAlign = ContentAlignment.TopRight;
            label_Frisökning.Visible = false;
            // 
            // tb_CodeText
            // 
            tb_CodeText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_CodeText.Location = new Point(1471, 521);
            tb_CodeText.Margin = new Padding(4, 3, 4, 3);
            tb_CodeText.Name = "tb_CodeText";
            tb_CodeText.ReadOnly = true;
            tb_CodeText.Size = new Size(158, 23);
            tb_CodeText.TabIndex = 15;
            tb_CodeText.Visible = false;
            tb_CodeText.Click += tb_CodeText_Click;
            // 
            // tb_FreeText
            // 
            tb_FreeText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_FreeText.Location = new Point(1471, 563);
            tb_FreeText.Margin = new Padding(4, 3, 4, 3);
            tb_FreeText.Name = "tb_FreeText";
            tb_FreeText.Size = new Size(158, 23);
            tb_FreeText.TabIndex = 15;
            tb_FreeText.Visible = false;
            tb_FreeText.TextChanged += Filter_TextChanged;
            // 
            // label_TemplateName
            // 
            label_TemplateName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_TemplateName.Font = new Font("Lucida Sans", 10.25F);
            label_TemplateName.ForeColor = Color.DarkGoldenrod;
            label_TemplateName.Location = new Point(1470, 283);
            label_TemplateName.Margin = new Padding(4, 0, 4, 0);
            label_TemplateName.Name = "label_TemplateName";
            label_TemplateName.Size = new Size(159, 18);
            label_TemplateName.TabIndex = 8;
            label_TemplateName.Text = "Protokoll namn";
            label_TemplateName.TextAlign = ContentAlignment.TopRight;
            // 
            // tb_TemplateName
            // 
            tb_TemplateName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_TemplateName.Location = new Point(1470, 305);
            tb_TemplateName.Margin = new Padding(4, 3, 4, 3);
            tb_TemplateName.Name = "tb_TemplateName";
            tb_TemplateName.Size = new Size(158, 23);
            tb_TemplateName.TabIndex = 15;
            tb_TemplateName.TextChanged += Filter_TextChanged;
            tb_TemplateName.Enter += tb_TemplateName_Enter;
            // 
            // Open_Order
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1643, 704);
            Controls.Add(date_To);
            Controls.Add(date_From);
            Controls.Add(label_DateTo);
            Controls.Add(label_DateFrom);
            Controls.Add(tb_FreeText);
            Controls.Add(tb_CodeText);
            Controls.Add(tb_TemplateName);
            Controls.Add(tb_Customer);
            Controls.Add(tb_ProdLine);
            Controls.Add(tb_OrderNr);
            Controls.Add(tb_PartNumber);
            Controls.Add(dgv_OrderList);
            Controls.Add(label_Frisökning);
            Controls.Add(label_TemplateName);
            Controls.Add(label_Customer);
            Controls.Add(label_ProdLine);
            Controls.Add(label_OrderNr);
            Controls.Add(label_PartNumber);
            Controls.Add(btn_OpenOrder);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Open_Order";
            Text = "Öppna";
            Shown += Open_Order_Shown;
            ((ISupportInitialize)dgv_OrderList).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private Label label_TemplateName;
        private TextBox tb_TemplateName;
    }
}