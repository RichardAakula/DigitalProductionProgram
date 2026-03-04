namespace DigitalProductionProgram.Browse_Protocols
{
    partial class SpcOrderAnalysis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            tlp_Main = new TableLayoutPanel();
            tlp_Left = new TableLayoutPanel();
            chkList_Parameters = new CheckedListBox();
            panel_Filter = new Panel();
            label_ProdType = new Label();
            label_ProdLine = new Label();
            label_RevNr = new Label();
            tb_ProdType = new TextBox();
            tb_FilterProdLine = new TextBox();
            tb_FilterRevNr = new TextBox();
            dgv_OrderList = new DataGridView();
            flp_Charts = new FlowLayoutPanel();
            orderId = new DataGridViewTextBoxColumn();
            isChecked = new DataGridViewCheckBoxColumn();
            ordernr = new DataGridViewTextBoxColumn();
            revnr = new DataGridViewTextBoxColumn();
            prodline = new DataGridViewTextBoxColumn();
            prodtype = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            tlp_Main.SuspendLayout();
            tlp_Left.SuspendLayout();
            panel_Filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_OrderList).BeginInit();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.2438736F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.75613F));
            tlp_Main.Controls.Add(tlp_Left, 0, 0);
            tlp_Main.Controls.Add(flp_Charts, 1, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 1;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_Main.Size = new Size(1591, 827);
            tlp_Main.TabIndex = 1;
            // 
            // tlp_Left
            // 
            tlp_Left.BackColor = Color.FromArgb(6, 81, 87);
            tlp_Left.ColumnCount = 3;
            tlp_Left.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            tlp_Left.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 49F));
            tlp_Left.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Left.Controls.Add(chkList_Parameters, 0, 0);
            tlp_Left.Controls.Add(panel_Filter, 0, 1);
            tlp_Left.Controls.Add(dgv_OrderList, 0, 2);
            tlp_Left.Dock = DockStyle.Fill;
            tlp_Left.Location = new Point(3, 3);
            tlp_Left.Name = "tlp_Left";
            tlp_Left.RowCount = 3;
            tlp_Left.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tlp_Left.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tlp_Left.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tlp_Left.Size = new Size(507, 821);
            tlp_Left.TabIndex = 872;
            // 
            // chkList_Parameters
            // 
            chkList_Parameters.CheckOnClick = true;
            tlp_Left.SetColumnSpan(chkList_Parameters, 3);
            chkList_Parameters.Dock = DockStyle.Fill;
            chkList_Parameters.FormattingEnabled = true;
            chkList_Parameters.IntegralHeight = false;
            chkList_Parameters.Location = new Point(3, 3);
            chkList_Parameters.Name = "chkList_Parameters";
            chkList_Parameters.Size = new Size(501, 204);
            chkList_Parameters.TabIndex = 33;
            chkList_Parameters.ItemCheck += chkList_Parameters_ItemCheck;
            // 
            // panel_Filter
            // 
            panel_Filter.BackColor = Color.White;
            tlp_Left.SetColumnSpan(panel_Filter, 3);
            panel_Filter.Controls.Add(label_ProdType);
            panel_Filter.Controls.Add(label_ProdLine);
            panel_Filter.Controls.Add(label_RevNr);
            panel_Filter.Controls.Add(tb_ProdType);
            panel_Filter.Controls.Add(tb_FilterProdLine);
            panel_Filter.Controls.Add(tb_FilterRevNr);
            panel_Filter.Dock = DockStyle.Fill;
            panel_Filter.Location = new Point(3, 213);
            panel_Filter.Name = "panel_Filter";
            panel_Filter.Size = new Size(501, 114);
            panel_Filter.TabIndex = 35;
            // 
            // label_ProdType
            // 
            label_ProdType.AutoSize = true;
            label_ProdType.Location = new Point(6, 82);
            label_ProdType.Name = "label_ProdType";
            label_ProdType.Size = new Size(56, 15);
            label_ProdType.TabIndex = 3;
            label_ProdType.Text = "ProdType";
            // 
            // label_ProdLine
            // 
            label_ProdLine.AutoSize = true;
            label_ProdLine.Location = new Point(8, 48);
            label_ProdLine.Name = "label_ProdLine";
            label_ProdLine.Size = new Size(54, 15);
            label_ProdLine.TabIndex = 2;
            label_ProdLine.Text = "ProdLine";
            // 
            // label_RevNr
            // 
            label_RevNr.AutoSize = true;
            label_RevNr.Location = new Point(23, 14);
            label_RevNr.Name = "label_RevNr";
            label_RevNr.Size = new Size(39, 15);
            label_RevNr.TabIndex = 1;
            label_RevNr.Text = "RevNr";
            // 
            // tb_ProdType
            // 
            tb_ProdType.Location = new Point(66, 79);
            tb_ProdType.Name = "tb_ProdType";
            tb_ProdType.Size = new Size(100, 23);
            tb_ProdType.TabIndex = 0;
            // 
            // tb_FilterProdLine
            // 
            tb_FilterProdLine.Location = new Point(66, 45);
            tb_FilterProdLine.Name = "tb_FilterProdLine";
            tb_FilterProdLine.Size = new Size(100, 23);
            tb_FilterProdLine.TabIndex = 0;
            // 
            // tb_FilterRevNr
            // 
            tb_FilterRevNr.Location = new Point(66, 11);
            tb_FilterRevNr.Name = "tb_FilterRevNr";
            tb_FilterRevNr.Size = new Size(100, 23);
            tb_FilterRevNr.TabIndex = 0;
            // 
            // dgv_OrderList
            // 
            dgv_OrderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_OrderList.Columns.AddRange(new DataGridViewColumn[] { orderId, isChecked, ordernr, revnr, prodline, prodtype, date });
            tlp_Left.SetColumnSpan(dgv_OrderList, 3);
            dgv_OrderList.Dock = DockStyle.Fill;
            dgv_OrderList.Location = new Point(3, 333);
            dgv_OrderList.Name = "dgv_OrderList";
            dgv_OrderList.RowHeadersVisible = false;
            dgv_OrderList.Size = new Size(501, 485);
            dgv_OrderList.TabIndex = 36;
            dgv_OrderList.CellValueChanged += dgv_OrderList_CellValueChanged;
            dgv_OrderList.CurrentCellDirtyStateChanged += dgv_OrderList_CurrentCellDirtyStateChanged;
            // 
            // flp_Charts
            // 
            flp_Charts.AutoScroll = true;
            flp_Charts.Dock = DockStyle.Fill;
            flp_Charts.FlowDirection = FlowDirection.TopDown;
            flp_Charts.Location = new Point(516, 3);
            flp_Charts.Name = "flp_Charts";
            flp_Charts.Size = new Size(1072, 821);
            flp_Charts.TabIndex = 873;
            flp_Charts.WrapContents = false;
            // 
            // orderId
            // 
            orderId.HeaderText = "OrderId";
            orderId.Name = "orderId";
            orderId.Visible = false;
            // 
            // isChecked
            // 
            isChecked.HeaderText = "";
            isChecked.Name = "isChecked";
            isChecked.Resizable = DataGridViewTriState.True;
            isChecked.SortMode = DataGridViewColumnSortMode.Automatic;
            isChecked.Width = 25;
            // 
            // ordernr
            // 
            ordernr.HeaderText = "OrderNr";
            ordernr.Name = "ordernr";
            ordernr.Width = 60;
            // 
            // revnr
            // 
            revnr.HeaderText = "Rev Nr";
            revnr.Name = "revnr";
            revnr.Width = 35;
            // 
            // prodline
            // 
            prodline.HeaderText = "ProdLine";
            prodline.Name = "prodline";
            prodline.Width = 120;
            // 
            // prodtype
            // 
            prodtype.HeaderText = "ProdType";
            prodtype.Name = "prodtype";
            prodtype.Width = 120;
            // 
            // date
            // 
            date.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            date.HeaderText = "Date";
            date.Name = "date";
            date.Width = 56;
            // 
            // SpcOrderAnalysis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1591, 827);
            Controls.Add(tlp_Main);
            Name = "SpcOrderAnalysis";
            Text = "SpcOrderAnalysis";
            tlp_Main.ResumeLayout(false);
            tlp_Left.ResumeLayout(false);
            panel_Filter.ResumeLayout(false);
            panel_Filter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_OrderList).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tlp_Main;
        private FlowLayoutPanel flp_Charts;
        private TableLayoutPanel tlp_Left;
        private CheckedListBox chkList_Parameters;
        private TableLayoutPanel tlp_SPC_Data;
        private Panel panel_Filter;
        private TextBox tb_FilterRevNr;
        private TextBox tb_FilterProdLine;
        private Label label_ProdLine;
        private Label label_RevNr;
        private DataGridView dgv_OrderList;
        private Label label_ProdType;
        private TextBox tb_ProdType;
        private DataGridViewTextBoxColumn orderId;
        private DataGridViewCheckBoxColumn isChecked;
        private DataGridViewTextBoxColumn ordernr;
        private DataGridViewTextBoxColumn revnr;
        private DataGridViewTextBoxColumn prodline;
        private DataGridViewTextBoxColumn prodtype;
        private DataGridViewTextBoxColumn date;
    }
}