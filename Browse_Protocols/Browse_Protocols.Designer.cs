using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.Protocols.ExtraProtocols;

namespace DigitalProductionProgram.Browse_Protocols
{
    partial class Browse_Protocols
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
            components = new Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            flp_Left = new FlowLayoutPanel();
            lbl_Export_Excel = new Label();
            lbl_PrintOrder = new Label();
            tlp_Main = new TableLayoutPanel();
            flp_Machines = new FlowLayoutPanel();
            Processcard_BasedOn = new ProcesscardBasedOn();
            Comments = new Comments();
            Prefab = new PreFab();
            chb_SelectOrders = new CheckBox();
            panel_Top = new Panel();
            panel_MainInfo = new Panel();
            mainInfo_A = new DigitalProductionProgram.Protocols.MainInfo.MainInfo_A();
            lbl_Header = new Label();
            cm_Orderlist = new ContextMenuStrip(components);
            tlp_Right = new TableLayoutPanel();
            lbl_TotalOrders = new Label();
            label_Orderlista = new Label();
            dgv_OrderList = new DataGridView();
            orderlist_PartNr = new DataGridViewTextBoxColumn();
            orderList_MainTemplateID = new DataGridViewTextBoxColumn();
            orderlist_PartID = new DataGridViewTextBoxColumn();
            orderlist_OrderNr = new DataGridViewTextBoxColumn();
            orderlist_OrderID = new DataGridViewTextBoxColumn();
            orderlist_RevNr = new DataGridViewTextBoxColumn();
            orderlist_PC_BasedOn = new DataGridViewTextBoxColumn();
            orderlist_Datum = new DataGridViewTextBoxColumn();
            orderlist_Inactive = new DataGridViewTextBoxColumn();
            orderlist_InactivatedBy = new DataGridViewTextBoxColumn();
            orderlist_InactivatedDate = new DataGridViewTextBoxColumn();
            orderlist_InactivatedComment = new DataGridViewTextBoxColumn();
            pb_Info = new PictureBox();
            panel_DiscardedOrder_Info = new Panel();
            panel_EmptySpace = new Panel();
            lbl_DiscardedComment = new Label();
            lbl_DiscardedDate = new Label();
            lbl_DiscardedBy = new Label();
            flp_Left.SuspendLayout();
            tlp_Main.SuspendLayout();
            panel_Top.SuspendLayout();
            panel_MainInfo.SuspendLayout();
            tlp_Right.SuspendLayout();
            ((ISupportInitialize)dgv_OrderList).BeginInit();
            ((ISupportInitialize)pb_Info).BeginInit();
            panel_DiscardedOrder_Info.SuspendLayout();
            SuspendLayout();
            // 
            // flp_Left
            // 
            flp_Left.BackColor = Color.FromArgb(45, 45, 45);
            flp_Left.Controls.Add(lbl_Export_Excel);
            flp_Left.Controls.Add(lbl_PrintOrder);
            flp_Left.Dock = DockStyle.Left;
            flp_Left.FlowDirection = FlowDirection.TopDown;
            flp_Left.Location = new Point(0, 63);
            flp_Left.Margin = new Padding(4, 3, 4, 3);
            flp_Left.Name = "flp_Left";
            flp_Left.Size = new Size(122, 1161);
            flp_Left.TabIndex = 0;
            // 
            // lbl_Export_Excel
            // 
            lbl_Export_Excel.AutoSize = true;
            lbl_Export_Excel.BackColor = Color.Transparent;
            lbl_Export_Excel.Cursor = Cursors.Hand;
            lbl_Export_Excel.Font = new Font("Palatino Linotype", 10.25F);
            lbl_Export_Excel.ForeColor = Color.Wheat;
            lbl_Export_Excel.Location = new Point(12, 23);
            lbl_Export_Excel.Margin = new Padding(12, 23, 4, 0);
            lbl_Export_Excel.Name = "lbl_Export_Excel";
            lbl_Export_Excel.Size = new Size(104, 38);
            lbl_Export_Excel.TabIndex = 881;
            lbl_Export_Excel.Text = "Export Data to Excel";
            lbl_Export_Excel.TextAlign = ContentAlignment.MiddleLeft;
            lbl_Export_Excel.Click += Export_Excel_Click;
            // 
            // lbl_PrintOrder
            // 
            lbl_PrintOrder.AutoSize = true;
            lbl_PrintOrder.BackColor = Color.Transparent;
            lbl_PrintOrder.Cursor = Cursors.Hand;
            lbl_PrintOrder.Font = new Font("Palatino Linotype", 10.25F);
            lbl_PrintOrder.ForeColor = Color.Wheat;
            lbl_PrintOrder.Location = new Point(12, 84);
            lbl_PrintOrder.Margin = new Padding(12, 23, 4, 0);
            lbl_PrintOrder.Name = "lbl_PrintOrder";
            lbl_PrintOrder.Size = new Size(83, 19);
            lbl_PrintOrder.TabIndex = 881;
            lbl_PrintOrder.Text = "Print Order";
            lbl_PrintOrder.TextAlign = ContentAlignment.MiddleCenter;
            lbl_PrintOrder.Click += PrintOrder_Click;
            // 
            // tlp_Main
            // 
            tlp_Main.AutoScroll = true;
            tlp_Main.BackColor = Color.FromArgb(25, 25, 25);
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.07903F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.92097F));
            tlp_Main.Controls.Add(flp_Machines, 0, 0);
            tlp_Main.Controls.Add(Processcard_BasedOn, 1, 3);
            tlp_Main.Controls.Add(Comments, 1, 1);
            tlp_Main.Controls.Add(Prefab, 1, 2);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(122, 63);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 3;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 46.51163F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 34.88372F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 18.60465F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tlp_Main.Size = new Size(1859, 1161);
            tlp_Main.TabIndex = 0;
            // 
            // flp_Machines
            // 
            flp_Machines.AutoScroll = true;
            flp_Machines.BackColor = Color.FromArgb(25, 25, 25);
            flp_Machines.Dock = DockStyle.Fill;
            flp_Machines.Location = new Point(3, 3);
            flp_Machines.Name = "flp_Machines";
            tlp_Main.SetRowSpan(flp_Machines, 3);
            flp_Machines.Size = new Size(1371, 1061);
            flp_Machines.TabIndex = 907;
            flp_Machines.WrapContents = false;
            // 
            // Processcard_BasedOn
            // 
            Processcard_BasedOn.BackColor = Color.Black;
            Processcard_BasedOn.Dock = DockStyle.Fill;
            Processcard_BasedOn.Location = new Point(1377, 1067);
            Processcard_BasedOn.Margin = new Padding(0);
            Processcard_BasedOn.Name = "Processcard_BasedOn";
            Processcard_BasedOn.Size = new Size(482, 94);
            Processcard_BasedOn.TabIndex = 0;
            // 
            // Comments
            // 
            Comments.Dock = DockStyle.Fill;
            Comments.Location = new Point(1377, 502);
            Comments.Margin = new Padding(0, 5, 0, 0);
            Comments.Name = "Comments";
            Comments.Size = new Size(482, 367);
            Comments.TabIndex = 1;
            // 
            // Prefab
            // 
            Prefab.Dock = DockStyle.Fill;
            Prefab.Location = new Point(1382, 872);
            Prefab.Margin = new Padding(5, 3, 5, 3);
            Prefab.Name = "Prefab";
            Prefab.Size = new Size(472, 192);
            Prefab.TabIndex = 4;
            // 
            // chb_SelectOrders
            // 
            chb_SelectOrders.AutoSize = true;
            chb_SelectOrders.Dock = DockStyle.Fill;
            chb_SelectOrders.Font = new Font("Palatino Linotype", 14.25F);
            chb_SelectOrders.ForeColor = Color.Wheat;
            chb_SelectOrders.Location = new Point(4, 53);
            chb_SelectOrders.Margin = new Padding(4, 3, 4, 3);
            chb_SelectOrders.Name = "chb_SelectOrders";
            chb_SelectOrders.Size = new Size(311, 41);
            chb_SelectOrders.TabIndex = 904;
            chb_SelectOrders.Text = "Ladda inte OrderData";
            chb_SelectOrders.UseVisualStyleBackColor = true;
            // 
            // panel_Top
            // 
            panel_Top.BackColor = Color.FromArgb(25, 25, 25);
            panel_Top.Controls.Add(panel_MainInfo);
            panel_Top.Controls.Add(lbl_Header);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Margin = new Padding(4, 3, 4, 3);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(2395, 63);
            panel_Top.TabIndex = 1;
            // 
            // panel_MainInfo
            // 
            panel_MainInfo.BackColor = Color.Black;
            panel_MainInfo.Controls.Add(mainInfo_A);
            panel_MainInfo.Dock = DockStyle.Fill;
            panel_MainInfo.Location = new Point(0, 0);
            panel_MainInfo.Margin = new Padding(0);
            panel_MainInfo.Name = "panel_MainInfo";
            panel_MainInfo.Size = new Size(2395, 63);
            panel_MainInfo.TabIndex = 905;
            // 
            // mainInfo_A
            // 
            mainInfo_A.BackColor = Color.FromArgb(6, 81, 87);
            mainInfo_A.Dock = DockStyle.Fill;
            mainInfo_A.Location = new Point(0, 0);
            mainInfo_A.Margin = new Padding(5, 3, 5, 3);
            mainInfo_A.Name = "mainInfo_A";
            mainInfo_A.Size = new Size(2395, 63);
            mainInfo_A.TabIndex = 0;
            // 
            // lbl_Header
            // 
            lbl_Header.Dock = DockStyle.Fill;
            lbl_Header.Font = new Font("Palatino Linotype", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Header.ForeColor = Color.Wheat;
            lbl_Header.Location = new Point(0, 0);
            lbl_Header.Margin = new Padding(4, 0, 4, 0);
            lbl_Header.Name = "lbl_Header";
            lbl_Header.Size = new Size(2395, 63);
            lbl_Header.TabIndex = 1;
            lbl_Header.Text = "Browse Protocols - ";
            lbl_Header.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cm_Orderlist
            // 
            cm_Orderlist.Font = new Font("Courier New", 8F);
            cm_Orderlist.ImageScalingSize = new Size(20, 20);
            cm_Orderlist.Name = "cm_Munstycke";
            cm_Orderlist.RenderMode = ToolStripRenderMode.Professional;
            cm_Orderlist.Size = new Size(61, 4);
            cm_Orderlist.ItemClicked += Menu_ItemClicked;
            // 
            // tlp_Right
            // 
            tlp_Right.BackColor = Color.FromArgb(45, 45, 45);
            tlp_Right.ColumnCount = 2;
            tlp_Right.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.1831F));
            tlp_Right.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.8169F));
            tlp_Right.Controls.Add(lbl_TotalOrders, 1, 0);
            tlp_Right.Controls.Add(label_Orderlista, 0, 0);
            tlp_Right.Controls.Add(dgv_OrderList, 0, 3);
            tlp_Right.Controls.Add(pb_Info, 1, 1);
            tlp_Right.Controls.Add(chb_SelectOrders, 0, 1);
            tlp_Right.Controls.Add(panel_DiscardedOrder_Info, 0, 2);
            tlp_Right.Dock = DockStyle.Right;
            tlp_Right.Location = new Point(1981, 63);
            tlp_Right.Margin = new Padding(4, 3, 4, 3);
            tlp_Right.Name = "tlp_Right";
            tlp_Right.RowCount = 4;
            tlp_Right.RowStyles.Add(new RowStyle(SizeType.Percent, 4.942966F));
            tlp_Right.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tlp_Right.RowStyles.Add(new RowStyle(SizeType.Absolute, 99F));
            tlp_Right.RowStyles.Add(new RowStyle(SizeType.Percent, 95.05704F));
            tlp_Right.Size = new Size(414, 1161);
            tlp_Right.TabIndex = 874;
            // 
            // lbl_TotalOrders
            // 
            lbl_TotalOrders.AutoSize = true;
            lbl_TotalOrders.BackColor = Color.Transparent;
            lbl_TotalOrders.Cursor = Cursors.Hand;
            lbl_TotalOrders.Dock = DockStyle.Fill;
            lbl_TotalOrders.Font = new Font("Palatino Linotype", 10.25F);
            lbl_TotalOrders.ForeColor = Color.Wheat;
            lbl_TotalOrders.Location = new Point(319, 0);
            lbl_TotalOrders.Margin = new Padding(0);
            lbl_TotalOrders.Name = "lbl_TotalOrders";
            lbl_TotalOrders.RightToLeft = RightToLeft.No;
            lbl_TotalOrders.Size = new Size(95, 50);
            lbl_TotalOrders.TabIndex = 873;
            lbl_TotalOrders.Text = "10 orders";
            lbl_TotalOrders.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Orderlista
            // 
            label_Orderlista.BackColor = Color.Transparent;
            label_Orderlista.Dock = DockStyle.Fill;
            label_Orderlista.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Orderlista.ForeColor = Color.Wheat;
            label_Orderlista.Location = new Point(0, 0);
            label_Orderlista.Margin = new Padding(0);
            label_Orderlista.Name = "label_Orderlista";
            label_Orderlista.Size = new Size(319, 50);
            label_Orderlista.TabIndex = 872;
            label_Orderlista.Text = "Orderlist:";
            // 
            // dgv_OrderList
            // 
            dgv_OrderList.AllowUserToAddRows = false;
            dgv_OrderList.AllowUserToResizeColumns = false;
            dgv_OrderList.AllowUserToResizeRows = false;
            dgv_OrderList.BackgroundColor = Color.FromArgb(45, 45, 45);
            dgv_OrderList.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv_OrderList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = Color.Crimson;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_OrderList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_OrderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_OrderList.ColumnHeadersVisible = false;
            dgv_OrderList.Columns.AddRange(new DataGridViewColumn[] { orderlist_PartNr, orderList_MainTemplateID, orderlist_PartID, orderlist_OrderNr, orderlist_OrderID, orderlist_RevNr, orderlist_PC_BasedOn, orderlist_Datum, orderlist_Inactive, orderlist_InactivatedBy, orderlist_InactivatedDate, orderlist_InactivatedComment });
            tlp_Right.SetColumnSpan(dgv_OrderList, 2);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(25, 25, 25);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Wheat;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_OrderList.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_OrderList.Dock = DockStyle.Fill;
            dgv_OrderList.Location = new Point(0, 198);
            dgv_OrderList.Margin = new Padding(0, 2, 0, 0);
            dgv_OrderList.MultiSelect = false;
            dgv_OrderList.Name = "dgv_OrderList";
            dgv_OrderList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_OrderList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_OrderList.RowHeadersVisible = false;
            dgv_OrderList.RowHeadersWidth = 51;
            dgv_OrderList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_OrderList.ScrollBars = ScrollBars.Vertical;
            dgv_OrderList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_OrderList.Size = new Size(414, 963);
            dgv_OrderList.TabIndex = 871;
            dgv_OrderList.CellMouseDown += OrderList_CellMouseDown;
            dgv_OrderList.CellValueChanged += OrderList_CellValueChanged;
            dgv_OrderList.RowEnter += OrderList_RowEnter;
            dgv_OrderList.RowsAdded += OrderList_RowsAdded;
            dgv_OrderList.RowsRemoved += OrderList_RowsRemoved;
            // 
            // orderlist_PartNr
            // 
            orderlist_PartNr.HeaderText = "ArtikelNr";
            orderlist_PartNr.MinimumWidth = 6;
            orderlist_PartNr.Name = "orderlist_PartNr";
            orderlist_PartNr.ReadOnly = true;
            orderlist_PartNr.Width = 80;
            // 
            // orderList_MainTemplateID
            // 
            orderList_MainTemplateID.HeaderText = "MainTemplateID";
            orderList_MainTemplateID.Name = "orderList_MainTemplateID";
            orderList_MainTemplateID.ReadOnly = true;
            orderList_MainTemplateID.Visible = false;
            // 
            // orderlist_PartID
            // 
            orderlist_PartID.HeaderText = "PartID";
            orderlist_PartID.MinimumWidth = 6;
            orderlist_PartID.Name = "orderlist_PartID";
            orderlist_PartID.ReadOnly = true;
            orderlist_PartID.Visible = false;
            orderlist_PartID.Width = 125;
            // 
            // orderlist_OrderNr
            // 
            orderlist_OrderNr.HeaderText = "OrderNr";
            orderlist_OrderNr.MinimumWidth = 6;
            orderlist_OrderNr.Name = "orderlist_OrderNr";
            orderlist_OrderNr.ReadOnly = true;
            orderlist_OrderNr.Width = 70;
            // 
            // orderlist_OrderID
            // 
            orderlist_OrderID.HeaderText = "OrderID";
            orderlist_OrderID.MinimumWidth = 6;
            orderlist_OrderID.Name = "orderlist_OrderID";
            orderlist_OrderID.ReadOnly = true;
            orderlist_OrderID.Visible = false;
            orderlist_OrderID.Width = 120;
            // 
            // orderlist_RevNr
            // 
            orderlist_RevNr.HeaderText = "Rev.";
            orderlist_RevNr.MinimumWidth = 6;
            orderlist_RevNr.Name = "orderlist_RevNr";
            orderlist_RevNr.ReadOnly = true;
            orderlist_RevNr.Width = 20;
            // 
            // orderlist_PC_BasedOn
            // 
            orderlist_PC_BasedOn.HeaderText = "Based On";
            orderlist_PC_BasedOn.Name = "orderlist_PC_BasedOn";
            orderlist_PC_BasedOn.ReadOnly = true;
            orderlist_PC_BasedOn.Width = 50;
            // 
            // orderlist_Datum
            // 
            orderlist_Datum.HeaderText = "Datum";
            orderlist_Datum.MinimumWidth = 6;
            orderlist_Datum.Name = "orderlist_Datum";
            orderlist_Datum.ReadOnly = true;
            orderlist_Datum.Width = 120;
            // 
            // orderlist_Inactive
            // 
            orderlist_Inactive.HeaderText = "IsOrderInactive";
            orderlist_Inactive.Name = "orderlist_Inactive";
            orderlist_Inactive.ReadOnly = true;
            orderlist_Inactive.Visible = false;
            // 
            // orderlist_InactivatedBy
            // 
            orderlist_InactivatedBy.HeaderText = "Inactivated By";
            orderlist_InactivatedBy.Name = "orderlist_InactivatedBy";
            orderlist_InactivatedBy.ReadOnly = true;
            orderlist_InactivatedBy.Visible = false;
            // 
            // orderlist_InactivatedDate
            // 
            orderlist_InactivatedDate.HeaderText = "Inactivated Date";
            orderlist_InactivatedDate.Name = "orderlist_InactivatedDate";
            orderlist_InactivatedDate.ReadOnly = true;
            orderlist_InactivatedDate.Visible = false;
            // 
            // orderlist_InactivatedComment
            // 
            orderlist_InactivatedComment.HeaderText = "Discarded Comment";
            orderlist_InactivatedComment.Name = "orderlist_InactivatedComment";
            orderlist_InactivatedComment.ReadOnly = true;
            orderlist_InactivatedComment.Visible = false;
            // 
            // pb_Info
            // 
            pb_Info.BackColor = Color.FromArgb(45, 45, 45);
            pb_Info.BackgroundImage = Properties.Resources.info;
            pb_Info.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info.Cursor = Cursors.Hand;
            pb_Info.Dock = DockStyle.Left;
            pb_Info.Location = new Point(323, 53);
            pb_Info.Margin = new Padding(4, 3, 4, 3);
            pb_Info.Name = "pb_Info";
            pb_Info.Size = new Size(41, 41);
            pb_Info.TabIndex = 875;
            pb_Info.TabStop = false;
            pb_Info.Click += Info_Click;
            // 
            // panel_DiscardedOrder_Info
            // 
            panel_DiscardedOrder_Info.AutoScroll = true;
            panel_DiscardedOrder_Info.AutoSize = true;
            panel_DiscardedOrder_Info.BackColor = Color.FromArgb(40, 40, 40);
            tlp_Right.SetColumnSpan(panel_DiscardedOrder_Info, 2);
            panel_DiscardedOrder_Info.Controls.Add(panel_EmptySpace);
            panel_DiscardedOrder_Info.Controls.Add(lbl_DiscardedComment);
            panel_DiscardedOrder_Info.Controls.Add(lbl_DiscardedDate);
            panel_DiscardedOrder_Info.Controls.Add(lbl_DiscardedBy);
            panel_DiscardedOrder_Info.Dock = DockStyle.Fill;
            panel_DiscardedOrder_Info.Location = new Point(0, 97);
            panel_DiscardedOrder_Info.Margin = new Padding(0, 0, 0, 2);
            panel_DiscardedOrder_Info.Name = "panel_DiscardedOrder_Info";
            panel_DiscardedOrder_Info.Size = new Size(414, 97);
            panel_DiscardedOrder_Info.TabIndex = 876;
            panel_DiscardedOrder_Info.Visible = false;
            // 
            // panel_EmptySpace
            // 
            panel_EmptySpace.Dock = DockStyle.Top;
            panel_EmptySpace.Location = new Point(0, 32);
            panel_EmptySpace.Margin = new Padding(4, 3, 4, 3);
            panel_EmptySpace.Name = "panel_EmptySpace";
            panel_EmptySpace.Size = new Size(414, 2);
            panel_EmptySpace.TabIndex = 3;
            // 
            // lbl_DiscardedComment
            // 
            lbl_DiscardedComment.BackColor = Color.White;
            lbl_DiscardedComment.Dock = DockStyle.Fill;
            lbl_DiscardedComment.Font = new Font("Courier New", 8.25F);
            lbl_DiscardedComment.Location = new Point(0, 32);
            lbl_DiscardedComment.Margin = new Padding(0, 2, 23, 0);
            lbl_DiscardedComment.Name = "lbl_DiscardedComment";
            lbl_DiscardedComment.Padding = new Padding(0, 2, 0, 0);
            lbl_DiscardedComment.Size = new Size(414, 65);
            lbl_DiscardedComment.TabIndex = 2;
            lbl_DiscardedComment.Text = "Comment";
            // 
            // lbl_DiscardedDate
            // 
            lbl_DiscardedDate.BackColor = Color.White;
            lbl_DiscardedDate.Dock = DockStyle.Top;
            lbl_DiscardedDate.Font = new Font("Lucida Sans", 10.25F);
            lbl_DiscardedDate.Location = new Point(0, 16);
            lbl_DiscardedDate.Margin = new Padding(4, 0, 4, 0);
            lbl_DiscardedDate.Name = "lbl_DiscardedDate";
            lbl_DiscardedDate.Size = new Size(414, 16);
            lbl_DiscardedDate.TabIndex = 1;
            lbl_DiscardedDate.Text = "Date";
            // 
            // lbl_DiscardedBy
            // 
            lbl_DiscardedBy.BackColor = Color.White;
            lbl_DiscardedBy.Dock = DockStyle.Top;
            lbl_DiscardedBy.Font = new Font("Lucida Sans", 10.25F);
            lbl_DiscardedBy.Location = new Point(0, 0);
            lbl_DiscardedBy.Margin = new Padding(4, 0, 4, 0);
            lbl_DiscardedBy.Name = "lbl_DiscardedBy";
            lbl_DiscardedBy.Size = new Size(414, 16);
            lbl_DiscardedBy.TabIndex = 0;
            lbl_DiscardedBy.Text = "Name";
            // 
            // Browse_Protocols
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(2395, 1224);
            Controls.Add(tlp_Main);
            Controls.Add(flp_Left);
            Controls.Add(tlp_Right);
            Controls.Add(panel_Top);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Browse_Protocols";
            StartPosition = FormStartPosition.Manual;
            Text = "Browse Old Protocols";
            WindowState = FormWindowState.Maximized;
            FormClosing += Browse_Protocols_FormClosing;
            flp_Left.ResumeLayout(false);
            flp_Left.PerformLayout();
            tlp_Main.ResumeLayout(false);
            panel_Top.ResumeLayout(false);
            panel_MainInfo.ResumeLayout(false);
            tlp_Right.ResumeLayout(false);
            tlp_Right.PerformLayout();
            ((ISupportInitialize)dgv_OrderList).EndInit();
            ((ISupportInitialize)pb_Info).EndInit();
            panel_DiscardedOrder_Info.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlp_Main;
        private Comments Comments;
        private Panel panel_Top;
        private FlowLayoutPanel flp_Left;
        private Label lbl_Export_Excel;
        private Label lbl_Header;
        private Label lbl_PrintOrder;
        private ContextMenuStrip cm_Orderlist;
        private TableLayoutPanel tlp_Right;
        public Label lbl_TotalOrders;
        private Label label_Orderlista;
        private DataGridView dgv_OrderList;
        private PictureBox pb_Info;
        private ProcesscardBasedOn Processcard_BasedOn;
        private PreFab Prefab;
        private Panel panel_MainInfo;
        private Protocols.MainInfo.MainInfo_A mainInfo_A;
        private Panel panel_DiscardedOrder_Info;
        private Label lbl_DiscardedComment;
        private Label lbl_DiscardedDate;
        private Label lbl_DiscardedBy;
        private Panel panel_EmptySpace;
        private CheckBox chb_SelectOrders;
        private DataGridViewTextBoxColumn orderlist_PartNr;
        private DataGridViewTextBoxColumn orderList_MainTemplateID;
        private DataGridViewTextBoxColumn orderlist_PartID;
        private DataGridViewTextBoxColumn orderlist_OrderNr;
        private DataGridViewTextBoxColumn orderlist_OrderID;
        private DataGridViewTextBoxColumn orderlist_RevNr;
        private DataGridViewTextBoxColumn orderlist_PC_BasedOn;
        private DataGridViewTextBoxColumn orderlist_Datum;
        private DataGridViewTextBoxColumn orderlist_Inactive;
        private DataGridViewTextBoxColumn orderlist_InactivatedBy;
        private DataGridViewTextBoxColumn orderlist_InactivatedDate;
        private DataGridViewTextBoxColumn orderlist_InactivatedComment;
        private FlowLayoutPanel flp_Machines;
    }
}