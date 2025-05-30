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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flp_Left = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_Export_Excel = new System.Windows.Forms.Label();
            this.lbl_PrintOrder = new System.Windows.Forms.Label();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Machines = new System.Windows.Forms.TableLayoutPanel();
            this.Processcard_BasedOn = new DigitalProductionProgram.Processcards.ProcesscardBasedOn();
            this.Comments = new Comments();
            this.Prefab = new PreFab();
            this.chb_SelectOrders = new System.Windows.Forms.CheckBox();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.panel_MainInfo = new System.Windows.Forms.Panel();
            this.mainInfo_A = new DigitalProductionProgram.Protocols.MainInfo.MainInfo_A();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.cm_Orderlist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlp_Right = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_TotalOrders = new System.Windows.Forms.Label();
            this.label_Orderlista = new System.Windows.Forms.Label();
            this.dgv_OrderList = new System.Windows.Forms.DataGridView();
            this.pb_Info = new System.Windows.Forms.PictureBox();
            this.panel_DiscardedOrder_Info = new System.Windows.Forms.Panel();
            this.panel_EmptySpace = new System.Windows.Forms.Panel();
            this.lbl_DiscardedComment = new System.Windows.Forms.Label();
            this.lbl_DiscardedDate = new System.Windows.Forms.Label();
            this.lbl_DiscardedBy = new System.Windows.Forms.Label();
            this.orderlist_PartNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderList_MainTemplateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderlist_PartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderlist_OrderNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderlist_OrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderlist_RevNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderlist_PC_BasedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderlist_Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderlist_Inactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderlist_InactivatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderlist_InactivatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderlist_InactivatedComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flp_Left.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.panel_MainInfo.SuspendLayout();
            this.tlp_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).BeginInit();
            this.panel_DiscardedOrder_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_Left
            // 
            this.flp_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.flp_Left.Controls.Add(this.lbl_Export_Excel);
            this.flp_Left.Controls.Add(this.lbl_PrintOrder);
            this.flp_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.flp_Left.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Left.Location = new System.Drawing.Point(0, 55);
            this.flp_Left.Name = "flp_Left";
            this.flp_Left.Size = new System.Drawing.Size(105, 1006);
            this.flp_Left.TabIndex = 0;
            // 
            // lbl_Export_Excel
            // 
            this.lbl_Export_Excel.AutoSize = true;
            this.lbl_Export_Excel.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Export_Excel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Export_Excel.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.lbl_Export_Excel.ForeColor = System.Drawing.Color.Wheat;
            this.lbl_Export_Excel.Location = new System.Drawing.Point(10, 20);
            this.lbl_Export_Excel.Margin = new System.Windows.Forms.Padding(10, 20, 3, 0);
            this.lbl_Export_Excel.Name = "lbl_Export_Excel";
            this.lbl_Export_Excel.Size = new System.Drawing.Size(91, 38);
            this.lbl_Export_Excel.TabIndex = 881;
            this.lbl_Export_Excel.Text = "Export Data to Excel";
            this.lbl_Export_Excel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Export_Excel.Click += new System.EventHandler(this.Export_Excel_Click);
            // 
            // lbl_PrintOrder
            // 
            this.lbl_PrintOrder.AutoSize = true;
            this.lbl_PrintOrder.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PrintOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_PrintOrder.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.lbl_PrintOrder.ForeColor = System.Drawing.Color.Wheat;
            this.lbl_PrintOrder.Location = new System.Drawing.Point(10, 78);
            this.lbl_PrintOrder.Margin = new System.Windows.Forms.Padding(10, 20, 3, 0);
            this.lbl_PrintOrder.Name = "lbl_PrintOrder";
            this.lbl_PrintOrder.Size = new System.Drawing.Size(83, 19);
            this.lbl_PrintOrder.TabIndex = 881;
            this.lbl_PrintOrder.Text = "Print Order";
            this.lbl_PrintOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PrintOrder.Click += new System.EventHandler(this.PrintOrder_Click);
            // 
            // tlp_Main
            // 
            this.tlp_Main.AutoScroll = true;
            this.tlp_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.07903F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.92097F));
            this.tlp_Main.Controls.Add(this.tlp_Machines, 0, 0);
            this.tlp_Main.Controls.Add(this.Processcard_BasedOn, 1, 3);
            this.tlp_Main.Controls.Add(this.Comments, 1, 1);
            this.tlp_Main.Controls.Add(this.Prefab, 1, 2);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(105, 55);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.51163F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.88372F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.60465F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlp_Main.Size = new System.Drawing.Size(1593, 1006);
            this.tlp_Main.TabIndex = 0;
            // 
            // tlp_Machines
            // 
            this.tlp_Machines.AutoScroll = true;
            this.tlp_Machines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tlp_Machines.ColumnCount = 1;
            this.tlp_Machines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Machines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Machines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Machines.Location = new System.Drawing.Point(3, 3);
            this.tlp_Machines.Name = "tlp_Machines";
            this.tlp_Machines.RowCount = 1;
            this.tlp_Main.SetRowSpan(this.tlp_Machines, 4);
            this.tlp_Machines.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Machines.Size = new System.Drawing.Size(1174, 1000);
            this.tlp_Machines.TabIndex = 903;
            // 
            // Processcard_BasedOn
            // 
            this.Processcard_BasedOn.BackColor = System.Drawing.Color.Black;
            this.Processcard_BasedOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Processcard_BasedOn.Location = new System.Drawing.Point(1180, 925);
            this.Processcard_BasedOn.Margin = new System.Windows.Forms.Padding(0);
            this.Processcard_BasedOn.Name = "Processcard_BasedOn";
            this.Processcard_BasedOn.Size = new System.Drawing.Size(413, 81);
            this.Processcard_BasedOn.TabIndex = 0;
            // 
            // Comments
            // 
            this.Comments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Comments.Location = new System.Drawing.Point(1180, 434);
            this.Comments.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.Comments.Name = "Comments";
            this.Comments.Size = new System.Drawing.Size(413, 319);
            this.Comments.TabIndex = 1;
            // 
            // Prefab
            // 
            this.Prefab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Prefab.Location = new System.Drawing.Point(1183, 756);
            this.Prefab.Name = "Prefab";
            this.Prefab.Size = new System.Drawing.Size(407, 166);
            this.Prefab.TabIndex = 4;
            // 
            // chb_SelectOrders
            // 
            this.chb_SelectOrders.AutoSize = true;
            this.chb_SelectOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_SelectOrders.Font = new System.Drawing.Font("Palatino Linotype", 14.25F);
            this.chb_SelectOrders.ForeColor = System.Drawing.Color.Wheat;
            this.chb_SelectOrders.Location = new System.Drawing.Point(3, 46);
            this.chb_SelectOrders.Name = "chb_SelectOrders";
            this.chb_SelectOrders.Size = new System.Drawing.Size(268, 35);
            this.chb_SelectOrders.TabIndex = 904;
            this.chb_SelectOrders.Text = "Ladda inte OrderData";
            this.chb_SelectOrders.UseVisualStyleBackColor = true;
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel_Top.Controls.Add(this.panel_MainInfo);
            this.panel_Top.Controls.Add(this.lbl_Header);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(2053, 55);
            this.panel_Top.TabIndex = 1;
            // 
            // panel_MainInfo
            // 
            this.panel_MainInfo.BackColor = System.Drawing.Color.Black;
            this.panel_MainInfo.Controls.Add(this.mainInfo_A);
            this.panel_MainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_MainInfo.Location = new System.Drawing.Point(0, 0);
            this.panel_MainInfo.Margin = new System.Windows.Forms.Padding(0);
            this.panel_MainInfo.Name = "panel_MainInfo";
            this.panel_MainInfo.Size = new System.Drawing.Size(2053, 55);
            this.panel_MainInfo.TabIndex = 905;
            // 
            // mainInfo_A
            // 
            this.mainInfo_A.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(81)))), ((int)(((byte)(87)))));
            this.mainInfo_A.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainInfo_A.Location = new System.Drawing.Point(0, 0);
            this.mainInfo_A.Name = "mainInfo_A";
            this.mainInfo_A.Size = new System.Drawing.Size(2053, 55);
            this.mainInfo_A.TabIndex = 0;
            // 
            // lbl_Header
            // 
            this.lbl_Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Header.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.ForeColor = System.Drawing.Color.Wheat;
            this.lbl_Header.Location = new System.Drawing.Point(0, 0);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(2053, 55);
            this.lbl_Header.TabIndex = 1;
            this.lbl_Header.Text = "Browse Protocols - ";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cm_Orderlist
            // 
            this.cm_Orderlist.Font = new System.Drawing.Font("Courier New", 8F);
            this.cm_Orderlist.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cm_Orderlist.Name = "cm_Munstycke";
            this.cm_Orderlist.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cm_Orderlist.Size = new System.Drawing.Size(61, 4);
            this.cm_Orderlist.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_ItemClicked);
            // 
            // tlp_Right
            // 
            this.tlp_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tlp_Right.ColumnCount = 2;
            this.tlp_Right.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.1831F));
            this.tlp_Right.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.8169F));
            this.tlp_Right.Controls.Add(this.lbl_TotalOrders, 1, 0);
            this.tlp_Right.Controls.Add(this.label_Orderlista, 0, 0);
            this.tlp_Right.Controls.Add(this.dgv_OrderList, 0, 3);
            this.tlp_Right.Controls.Add(this.pb_Info, 1, 1);
            this.tlp_Right.Controls.Add(this.chb_SelectOrders, 0, 1);
            this.tlp_Right.Controls.Add(this.panel_DiscardedOrder_Info, 0, 2);
            this.tlp_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlp_Right.Location = new System.Drawing.Point(1698, 55);
            this.tlp_Right.Name = "tlp_Right";
            this.tlp_Right.RowCount = 4;
            this.tlp_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.942966F));
            this.tlp_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlp_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlp_Right.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.05704F));
            this.tlp_Right.Size = new System.Drawing.Size(355, 1006);
            this.tlp_Right.TabIndex = 874;
            // 
            // lbl_TotalOrders
            // 
            this.lbl_TotalOrders.AutoSize = true;
            this.lbl_TotalOrders.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TotalOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_TotalOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalOrders.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.lbl_TotalOrders.ForeColor = System.Drawing.Color.Wheat;
            this.lbl_TotalOrders.Location = new System.Drawing.Point(274, 0);
            this.lbl_TotalOrders.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_TotalOrders.Name = "lbl_TotalOrders";
            this.lbl_TotalOrders.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_TotalOrders.Size = new System.Drawing.Size(81, 43);
            this.lbl_TotalOrders.TabIndex = 873;
            this.lbl_TotalOrders.Text = "10 orders";
            this.lbl_TotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Orderlista
            // 
            this.label_Orderlista.BackColor = System.Drawing.Color.Transparent;
            this.label_Orderlista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Orderlista.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Orderlista.ForeColor = System.Drawing.Color.Wheat;
            this.label_Orderlista.Location = new System.Drawing.Point(0, 0);
            this.label_Orderlista.Margin = new System.Windows.Forms.Padding(0);
            this.label_Orderlista.Name = "label_Orderlista";
            this.label_Orderlista.Size = new System.Drawing.Size(274, 43);
            this.label_Orderlista.TabIndex = 872;
            this.label_Orderlista.Text = "Orderlist:";
            // 
            // dgv_OrderList
            // 
            this.dgv_OrderList.AllowUserToAddRows = false;
            this.dgv_OrderList.AllowUserToResizeColumns = false;
            this.dgv_OrderList.AllowUserToResizeRows = false;
            this.dgv_OrderList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.dgv_OrderList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_OrderList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_OrderList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_OrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_OrderList.ColumnHeadersVisible = false;
            this.dgv_OrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderlist_PartNr,
            this.orderList_MainTemplateID,
            this.orderlist_PartID,
            this.orderlist_OrderNr,
            this.orderlist_OrderID,
            this.orderlist_RevNr,
            this.orderlist_PC_BasedOn,
            this.orderlist_Datum,
            this.orderlist_Inactive,
            this.orderlist_InactivatedBy,
            this.orderlist_InactivatedDate,
            this.orderlist_InactivatedComment});
            this.tlp_Right.SetColumnSpan(this.dgv_OrderList, 2);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_OrderList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_OrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_OrderList.Location = new System.Drawing.Point(0, 172);
            this.dgv_OrderList.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.dgv_OrderList.MultiSelect = false;
            this.dgv_OrderList.Name = "dgv_OrderList";
            this.dgv_OrderList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_OrderList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_OrderList.RowHeadersVisible = false;
            this.dgv_OrderList.RowHeadersWidth = 51;
            this.dgv_OrderList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_OrderList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_OrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_OrderList.Size = new System.Drawing.Size(355, 834);
            this.dgv_OrderList.TabIndex = 871;
            this.dgv_OrderList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OrderList_CellMouseDown);
            this.dgv_OrderList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderList_CellValueChanged);
            this.dgv_OrderList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderList_RowEnter);
            this.dgv_OrderList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.OrderList_RowsAdded);
            this.dgv_OrderList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.OrderList_RowsRemoved);
            // 
            // pb_Info
            // 
            this.pb_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pb_Info.BackgroundImage = global::DigitalProductionProgram.Properties.Resources.info;
            this.pb_Info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_Info.Location = new System.Drawing.Point(277, 46);
            this.pb_Info.Name = "pb_Info";
            this.pb_Info.Size = new System.Drawing.Size(35, 35);
            this.pb_Info.TabIndex = 875;
            this.pb_Info.TabStop = false;
            this.pb_Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // panel_DiscardedOrder_Info
            // 
            this.panel_DiscardedOrder_Info.AutoScroll = true;
            this.panel_DiscardedOrder_Info.AutoSize = true;
            this.panel_DiscardedOrder_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tlp_Right.SetColumnSpan(this.panel_DiscardedOrder_Info, 2);
            this.panel_DiscardedOrder_Info.Controls.Add(this.panel_EmptySpace);
            this.panel_DiscardedOrder_Info.Controls.Add(this.lbl_DiscardedComment);
            this.panel_DiscardedOrder_Info.Controls.Add(this.lbl_DiscardedDate);
            this.panel_DiscardedOrder_Info.Controls.Add(this.lbl_DiscardedBy);
            this.panel_DiscardedOrder_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DiscardedOrder_Info.Location = new System.Drawing.Point(0, 84);
            this.panel_DiscardedOrder_Info.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.panel_DiscardedOrder_Info.Name = "panel_DiscardedOrder_Info";
            this.panel_DiscardedOrder_Info.Size = new System.Drawing.Size(355, 84);
            this.panel_DiscardedOrder_Info.TabIndex = 876;
            this.panel_DiscardedOrder_Info.Visible = false;
            // 
            // panel_EmptySpace
            // 
            this.panel_EmptySpace.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_EmptySpace.Location = new System.Drawing.Point(0, 28);
            this.panel_EmptySpace.Name = "panel_EmptySpace";
            this.panel_EmptySpace.Size = new System.Drawing.Size(355, 2);
            this.panel_EmptySpace.TabIndex = 3;
            // 
            // lbl_DiscardedComment
            // 
            this.lbl_DiscardedComment.BackColor = System.Drawing.Color.White;
            this.lbl_DiscardedComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DiscardedComment.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lbl_DiscardedComment.Location = new System.Drawing.Point(0, 28);
            this.lbl_DiscardedComment.Margin = new System.Windows.Forms.Padding(0, 2, 20, 0);
            this.lbl_DiscardedComment.Name = "lbl_DiscardedComment";
            this.lbl_DiscardedComment.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbl_DiscardedComment.Size = new System.Drawing.Size(355, 56);
            this.lbl_DiscardedComment.TabIndex = 2;
            this.lbl_DiscardedComment.Text = "Comment";
            // 
            // lbl_DiscardedDate
            // 
            this.lbl_DiscardedDate.BackColor = System.Drawing.Color.White;
            this.lbl_DiscardedDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_DiscardedDate.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.lbl_DiscardedDate.Location = new System.Drawing.Point(0, 14);
            this.lbl_DiscardedDate.Name = "lbl_DiscardedDate";
            this.lbl_DiscardedDate.Size = new System.Drawing.Size(355, 14);
            this.lbl_DiscardedDate.TabIndex = 1;
            this.lbl_DiscardedDate.Text = "Date";
            // 
            // lbl_DiscardedBy
            // 
            this.lbl_DiscardedBy.BackColor = System.Drawing.Color.White;
            this.lbl_DiscardedBy.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_DiscardedBy.Font = new System.Drawing.Font("Lucida Sans", 10.25F);
            this.lbl_DiscardedBy.Location = new System.Drawing.Point(0, 0);
            this.lbl_DiscardedBy.Name = "lbl_DiscardedBy";
            this.lbl_DiscardedBy.Size = new System.Drawing.Size(355, 14);
            this.lbl_DiscardedBy.TabIndex = 0;
            this.lbl_DiscardedBy.Text = "Name";
            // 
            // orderlist_PartNr
            // 
            this.orderlist_PartNr.HeaderText = "ArtikelNr";
            this.orderlist_PartNr.MinimumWidth = 6;
            this.orderlist_PartNr.Name = "orderlist_PartNr";
            this.orderlist_PartNr.ReadOnly = true;
            this.orderlist_PartNr.Width = 80;
            // 
            // orderList_MainTemplateID
            // 
            this.orderList_MainTemplateID.HeaderText = "MainTemplateID";
            this.orderList_MainTemplateID.Name = "orderList_MainTemplateID";
            this.orderList_MainTemplateID.ReadOnly = true;
            this.orderList_MainTemplateID.Visible = false;
            // 
            // orderlist_PartID
            // 
            this.orderlist_PartID.HeaderText = "PartID";
            this.orderlist_PartID.MinimumWidth = 6;
            this.orderlist_PartID.Name = "orderlist_PartID";
            this.orderlist_PartID.ReadOnly = true;
            this.orderlist_PartID.Visible = false;
            this.orderlist_PartID.Width = 125;
            // 
            // orderlist_OrderNr
            // 
            this.orderlist_OrderNr.HeaderText = "OrderNr";
            this.orderlist_OrderNr.MinimumWidth = 6;
            this.orderlist_OrderNr.Name = "orderlist_OrderNr";
            this.orderlist_OrderNr.ReadOnly = true;
            this.orderlist_OrderNr.Width = 70;
            // 
            // orderlist_OrderID
            // 
            this.orderlist_OrderID.HeaderText = "OrderID";
            this.orderlist_OrderID.MinimumWidth = 6;
            this.orderlist_OrderID.Name = "orderlist_OrderID";
            this.orderlist_OrderID.ReadOnly = true;
            this.orderlist_OrderID.Visible = false;
            this.orderlist_OrderID.Width = 120;
            // 
            // orderlist_RevNr
            // 
            this.orderlist_RevNr.HeaderText = "Rev.";
            this.orderlist_RevNr.MinimumWidth = 6;
            this.orderlist_RevNr.Name = "orderlist_RevNr";
            this.orderlist_RevNr.ReadOnly = true;
            this.orderlist_RevNr.Width = 20;
            // 
            // orderlist_PC_BasedOn
            // 
            this.orderlist_PC_BasedOn.HeaderText = "Based On";
            this.orderlist_PC_BasedOn.Name = "orderlist_PC_BasedOn";
            this.orderlist_PC_BasedOn.ReadOnly = true;
            this.orderlist_PC_BasedOn.Width = 50;
            // 
            // orderlist_Datum
            // 
            this.orderlist_Datum.HeaderText = "Datum";
            this.orderlist_Datum.MinimumWidth = 6;
            this.orderlist_Datum.Name = "orderlist_Datum";
            this.orderlist_Datum.ReadOnly = true;
            this.orderlist_Datum.Width = 120;
            // 
            // orderlist_Inactive
            // 
            this.orderlist_Inactive.HeaderText = "IsOrderInactive";
            this.orderlist_Inactive.Name = "orderlist_Inactive";
            this.orderlist_Inactive.ReadOnly = true;
            this.orderlist_Inactive.Visible = false;
            // 
            // orderlist_InactivatedBy
            // 
            this.orderlist_InactivatedBy.HeaderText = "Inactivated By";
            this.orderlist_InactivatedBy.Name = "orderlist_InactivatedBy";
            this.orderlist_InactivatedBy.ReadOnly = true;
            this.orderlist_InactivatedBy.Visible = false;
            // 
            // orderlist_InactivatedDate
            // 
            this.orderlist_InactivatedDate.HeaderText = "Inactivated Date";
            this.orderlist_InactivatedDate.Name = "orderlist_InactivatedDate";
            this.orderlist_InactivatedDate.ReadOnly = true;
            this.orderlist_InactivatedDate.Visible = false;
            // 
            // orderlist_InactivatedComment
            // 
            this.orderlist_InactivatedComment.HeaderText = "Discarded Comment";
            this.orderlist_InactivatedComment.Name = "orderlist_InactivatedComment";
            this.orderlist_InactivatedComment.ReadOnly = true;
            this.orderlist_InactivatedComment.Visible = false;
            // 
            // Browse_Protocols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(2053, 1061);
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.flp_Left);
            this.Controls.Add(this.tlp_Right);
            this.Controls.Add(this.panel_Top);
            this.DoubleBuffered = true;
            this.Name = "Browse_Protocols";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Browse Old Protocols";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Browse_Protocols_FormClosing);
            this.flp_Left.ResumeLayout(false);
            this.flp_Left.PerformLayout();
            this.tlp_Main.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.panel_MainInfo.ResumeLayout(false);
            this.tlp_Right.ResumeLayout(false);
            this.tlp_Right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).EndInit();
            this.panel_DiscardedOrder_Info.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private TableLayoutPanel tlp_Machines;
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
    }
}