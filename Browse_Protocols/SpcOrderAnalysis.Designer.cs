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
            chkList_Orders = new CheckedListBox();
            chkList_Parameters = new CheckedListBox();
            panel_Filter = new Panel();
            tb_FilterProdLine = new TextBox();
            tb_FilterRevNr = new TextBox();
            flp_Charts = new FlowLayoutPanel();
            label_RevNr = new Label();
            label2 = new Label();
            tlp_Main.SuspendLayout();
            tlp_Left.SuspendLayout();
            panel_Filter.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0203743F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.97962F));
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
            tlp_Left.Controls.Add(chkList_Orders, 0, 2);
            tlp_Left.Controls.Add(chkList_Parameters, 0, 0);
            tlp_Left.Controls.Add(panel_Filter, 0, 1);
            tlp_Left.Dock = DockStyle.Fill;
            tlp_Left.Location = new Point(3, 3);
            tlp_Left.Name = "tlp_Left";
            tlp_Left.RowCount = 3;
            tlp_Left.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tlp_Left.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tlp_Left.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tlp_Left.Size = new Size(392, 821);
            tlp_Left.TabIndex = 872;
            // 
            // chkList_Orders
            // 
            chkList_Orders.CheckOnClick = true;
            tlp_Left.SetColumnSpan(chkList_Orders, 3);
            chkList_Orders.Dock = DockStyle.Fill;
            chkList_Orders.FormattingEnabled = true;
            chkList_Orders.IntegralHeight = false;
            chkList_Orders.Location = new Point(3, 333);
            chkList_Orders.Name = "chkList_Orders";
            chkList_Orders.Size = new Size(386, 485);
            chkList_Orders.TabIndex = 34;
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
            chkList_Parameters.Size = new Size(386, 204);
            chkList_Parameters.TabIndex = 33;
            chkList_Parameters.ItemCheck += chkList_Parameters_ItemCheck;
            // 
            // panel_Filter
            // 
            panel_Filter.BackColor = Color.White;
            tlp_Left.SetColumnSpan(panel_Filter, 3);
            panel_Filter.Controls.Add(label2);
            panel_Filter.Controls.Add(label_RevNr);
            panel_Filter.Controls.Add(tb_FilterProdLine);
            panel_Filter.Controls.Add(tb_FilterRevNr);
            panel_Filter.Dock = DockStyle.Fill;
            panel_Filter.Location = new Point(3, 213);
            panel_Filter.Name = "panel_Filter";
            panel_Filter.Size = new Size(386, 114);
            panel_Filter.TabIndex = 35;
            // 
            // tb_FilterProdLine
            // 
            tb_FilterProdLine.Location = new Point(156, 86);
            tb_FilterProdLine.Name = "tb_FilterProdLine";
            tb_FilterProdLine.Size = new Size(100, 23);
            tb_FilterProdLine.TabIndex = 0;
            // 
            // tb_FilterRevNr
            // 
            tb_FilterRevNr.Location = new Point(5, 86);
            tb_FilterRevNr.Name = "tb_FilterRevNr";
            tb_FilterRevNr.Size = new Size(100, 23);
            tb_FilterRevNr.TabIndex = 0;
            // 
            // flp_Charts
            // 
            flp_Charts.AutoScroll = true;
            flp_Charts.Dock = DockStyle.Fill;
            flp_Charts.FlowDirection = FlowDirection.TopDown;
            flp_Charts.Location = new Point(401, 3);
            flp_Charts.Name = "flp_Charts";
            flp_Charts.Size = new Size(1187, 821);
            flp_Charts.TabIndex = 873;
            flp_Charts.WrapContents = false;
            // 
            // label_RevNr
            // 
            label_RevNr.AutoSize = true;
            label_RevNr.Location = new Point(6, 59);
            label_RevNr.Name = "label_RevNr";
            label_RevNr.Size = new Size(39, 15);
            label_RevNr.TabIndex = 1;
            label_RevNr.Text = "RevNr";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(156, 68);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "ProdLine";
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
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tlp_Main;
        private FlowLayoutPanel flp_Charts;
        private TableLayoutPanel tlp_Left;
        private CheckedListBox chkList_Orders;
        private CheckedListBox chkList_Parameters;
        private TableLayoutPanel tlp_SPC_Data;
        private Panel panel_Filter;
        private TextBox tb_FilterRevNr;
        private TextBox tb_FilterProdLine;
        private Label label2;
        private Label label_RevNr;
    }
}