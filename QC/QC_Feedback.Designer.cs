namespace DigitalProductionProgram.QC
{
    partial class QC_Feedback
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
            panel_Bottom = new Panel();
            num_RemainingViews = new NumericUpDown();
            label_RemainingView = new Label();
            panel1 = new Panel();
            btn_UploadImage = new Button();
            btn_Screenshot = new Button();
            panel_Right = new Panel();
            tb_ppkHistory = new TextBox();
            tb_ppkOrder = new TextBox();
            label1 = new Label();
            label2 = new Label();
            panel_OrderInfo = new Panel();
            tb_WorkOperation = new TextBox();
            tb_Date = new TextBox();
            tb_ProdType = new TextBox();
            tb_Operation = new TextBox();
            tb_ProdLine = new TextBox();
            tb_PartNr = new TextBox();
            tb_OrderNr = new TextBox();
            label_Workoperation = new Label();
            label_Date = new Label();
            label_ProdType = new Label();
            label__Operation = new Label();
            label_ProdLine = new Label();
            label_PartNumber = new Label();
            label_OrderNr = new Label();
            label_Header = new Label();
            panel_Left = new Panel();
            tb_Comments = new TextBox();
            label_Comments = new Label();
            panel_Buttons = new Panel();
            btn_Exit = new Button();
            btn_Save_Exit = new Button();
            pb_Image = new PictureBox();
            tlp_Main.SuspendLayout();
            panel_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_RemainingViews).BeginInit();
            panel1.SuspendLayout();
            panel_Right.SuspendLayout();
            panel_OrderInfo.SuspendLayout();
            panel_Left.SuspendLayout();
            panel_Buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Image).BeginInit();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Transparent;
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Main.Controls.Add(panel_Bottom, 0, 3);
            tlp_Main.Controls.Add(panel1, 0, 5);
            tlp_Main.Controls.Add(panel_Right, 0, 2);
            tlp_Main.Controls.Add(panel_OrderInfo, 0, 1);
            tlp_Main.Controls.Add(label_Header, 0, 0);
            tlp_Main.Controls.Add(panel_Left, 0, 2);
            tlp_Main.Controls.Add(panel_Buttons, 1, 5);
            tlp_Main.Controls.Add(pb_Image, 0, 4);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 6;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 152F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 137F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tlp_Main.Size = new Size(1101, 1008);
            tlp_Main.TabIndex = 0;
            // 
            // panel_Bottom
            // 
            panel_Bottom.BorderStyle = BorderStyle.Fixed3D;
            tlp_Main.SetColumnSpan(panel_Bottom, 2);
            panel_Bottom.Controls.Add(num_RemainingViews);
            panel_Bottom.Controls.Add(label_RemainingView);
            panel_Bottom.Dock = DockStyle.Fill;
            panel_Bottom.Location = new Point(4, 360);
            panel_Bottom.Margin = new Padding(4, 3, 4, 3);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(1093, 66);
            panel_Bottom.TabIndex = 7;
            // 
            // num_RemainingViews
            // 
            num_RemainingViews.Font = new Font("Courier New", 15.75F);
            num_RemainingViews.ForeColor = SystemColors.WindowFrame;
            num_RemainingViews.Location = new Point(657, 13);
            num_RemainingViews.Margin = new Padding(4, 3, 4, 3);
            num_RemainingViews.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            num_RemainingViews.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_RemainingViews.Name = "num_RemainingViews";
            num_RemainingViews.Size = new Size(65, 31);
            num_RemainingViews.TabIndex = 1;
            num_RemainingViews.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label_RemainingView
            // 
            label_RemainingView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_RemainingView.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            label_RemainingView.ForeColor = Color.FromArgb(147, 150, 149);
            label_RemainingView.Location = new Point(32, 17);
            label_RemainingView.Margin = new Padding(4, 0, 4, 0);
            label_RemainingView.Name = "label_RemainingView";
            label_RemainingView.Size = new Size(612, 27);
            label_RemainingView.TabIndex = 0;
            label_RemainingView.Text = "Välj här hur många gånger denna notis skall visas för operatörerna.";
            label_RemainingView.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_UploadImage);
            panel1.Controls.Add(btn_Screenshot);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 946);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 62);
            panel1.TabIndex = 6;
            // 
            // btn_UploadImage
            // 
            btn_UploadImage.BackColor = Color.FromArgb(238, 230, 182);
            btn_UploadImage.Cursor = Cursors.Hand;
            btn_UploadImage.Dock = DockStyle.Right;
            btn_UploadImage.FlatAppearance.BorderColor = Color.FromArgb(25, 25, 25);
            btn_UploadImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(111, 90, 25);
            btn_UploadImage.FlatStyle = FlatStyle.Flat;
            btn_UploadImage.Font = new Font("Palatino Linotype", 10.25F);
            btn_UploadImage.ForeColor = Color.FromArgb(141, 120, 55);
            btn_UploadImage.Location = new Point(359, 0);
            btn_UploadImage.Margin = new Padding(4, 3, 12, 3);
            btn_UploadImage.Name = "btn_UploadImage";
            btn_UploadImage.Size = new Size(191, 62);
            btn_UploadImage.TabIndex = 1011;
            btn_UploadImage.Text = "Ladda upp bild";
            btn_UploadImage.UseVisualStyleBackColor = false;
            btn_UploadImage.Click += UploadImage_Click;
            // 
            // btn_Screenshot
            // 
            btn_Screenshot.BackColor = Color.FromArgb(238, 230, 182);
            btn_Screenshot.Cursor = Cursors.Hand;
            btn_Screenshot.Dock = DockStyle.Left;
            btn_Screenshot.FlatAppearance.BorderColor = Color.FromArgb(25, 25, 25);
            btn_Screenshot.FlatAppearance.MouseOverBackColor = Color.FromArgb(111, 90, 25);
            btn_Screenshot.FlatStyle = FlatStyle.Flat;
            btn_Screenshot.Font = new Font("Palatino Linotype", 10.25F);
            btn_Screenshot.ForeColor = Color.FromArgb(141, 120, 55);
            btn_Screenshot.Location = new Point(0, 0);
            btn_Screenshot.Margin = new Padding(4, 3, 4, 3);
            btn_Screenshot.Name = "btn_Screenshot";
            btn_Screenshot.Size = new Size(138, 62);
            btn_Screenshot.TabIndex = 1010;
            btn_Screenshot.Text = "Ta en screenshot";
            btn_Screenshot.UseVisualStyleBackColor = false;
            btn_Screenshot.Click += Screenshot_Click;
            // 
            // panel_Right
            // 
            panel_Right.BorderStyle = BorderStyle.Fixed3D;
            panel_Right.Controls.Add(tb_ppkHistory);
            panel_Right.Controls.Add(tb_ppkOrder);
            panel_Right.Controls.Add(label1);
            panel_Right.Controls.Add(label2);
            panel_Right.Dock = DockStyle.Fill;
            panel_Right.Location = new Point(554, 223);
            panel_Right.Margin = new Padding(4, 3, 4, 3);
            panel_Right.Name = "panel_Right";
            panel_Right.Size = new Size(543, 131);
            panel_Right.TabIndex = 3;
            // 
            // tb_ppkHistory
            // 
            tb_ppkHistory.BorderStyle = BorderStyle.FixedSingle;
            tb_ppkHistory.Font = new Font("Courier New", 9.75F);
            tb_ppkHistory.ForeColor = SystemColors.WindowFrame;
            tb_ppkHistory.Location = new Point(174, 72);
            tb_ppkHistory.Margin = new Padding(4, 3, 4, 3);
            tb_ppkHistory.Name = "tb_ppkHistory";
            tb_ppkHistory.Size = new Size(80, 22);
            tb_ppkHistory.TabIndex = 1;
            tb_ppkHistory.WordWrap = false;
            // 
            // tb_ppkOrder
            // 
            tb_ppkOrder.BorderStyle = BorderStyle.FixedSingle;
            tb_ppkOrder.Font = new Font("Courier New", 9.75F);
            tb_ppkOrder.ForeColor = SystemColors.WindowFrame;
            tb_ppkOrder.Location = new Point(174, 21);
            tb_ppkOrder.Margin = new Padding(4, 3, 4, 3);
            tb_ppkOrder.Name = "tb_ppkOrder";
            tb_ppkOrder.Size = new Size(80, 22);
            tb_ppkOrder.TabIndex = 1;
            tb_ppkOrder.WordWrap = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(147, 150, 149);
            label1.Location = new Point(47, 70);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(125, 23);
            label1.TabIndex = 0;
            label1.Text = "PPK - Historik:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(147, 150, 149);
            label2.Location = new Point(65, 19);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 23);
            label2.TabIndex = 0;
            label2.Text = "PPK - Order:";
            // 
            // panel_OrderInfo
            // 
            panel_OrderInfo.BackColor = Color.Transparent;
            panel_OrderInfo.BorderStyle = BorderStyle.Fixed3D;
            tlp_Main.SetColumnSpan(panel_OrderInfo, 2);
            panel_OrderInfo.Controls.Add(tb_WorkOperation);
            panel_OrderInfo.Controls.Add(tb_Date);
            panel_OrderInfo.Controls.Add(tb_ProdType);
            panel_OrderInfo.Controls.Add(tb_Operation);
            panel_OrderInfo.Controls.Add(tb_ProdLine);
            panel_OrderInfo.Controls.Add(tb_PartNr);
            panel_OrderInfo.Controls.Add(tb_OrderNr);
            panel_OrderInfo.Controls.Add(label_Workoperation);
            panel_OrderInfo.Controls.Add(label_Date);
            panel_OrderInfo.Controls.Add(label_ProdType);
            panel_OrderInfo.Controls.Add(label__Operation);
            panel_OrderInfo.Controls.Add(label_ProdLine);
            panel_OrderInfo.Controls.Add(label_PartNumber);
            panel_OrderInfo.Controls.Add(label_OrderNr);
            panel_OrderInfo.Dock = DockStyle.Fill;
            panel_OrderInfo.Location = new Point(4, 71);
            panel_OrderInfo.Margin = new Padding(4, 3, 4, 3);
            panel_OrderInfo.Name = "panel_OrderInfo";
            panel_OrderInfo.Size = new Size(1093, 146);
            panel_OrderInfo.TabIndex = 2;
            // 
            // tb_WorkOperation
            // 
            tb_WorkOperation.BorderStyle = BorderStyle.FixedSingle;
            tb_WorkOperation.Font = new Font("Courier New", 9.75F);
            tb_WorkOperation.ForeColor = SystemColors.WindowFrame;
            tb_WorkOperation.Location = new Point(415, 54);
            tb_WorkOperation.Margin = new Padding(4, 3, 4, 3);
            tb_WorkOperation.Name = "tb_WorkOperation";
            tb_WorkOperation.ReadOnly = true;
            tb_WorkOperation.Size = new Size(193, 22);
            tb_WorkOperation.TabIndex = 1;
            tb_WorkOperation.WordWrap = false;
            // 
            // tb_Date
            // 
            tb_Date.BorderStyle = BorderStyle.FixedSingle;
            tb_Date.Font = new Font("Courier New", 9.75F);
            tb_Date.ForeColor = SystemColors.WindowFrame;
            tb_Date.Location = new Point(826, 96);
            tb_Date.Margin = new Padding(4, 3, 4, 3);
            tb_Date.Name = "tb_Date";
            tb_Date.ReadOnly = true;
            tb_Date.Size = new Size(224, 22);
            tb_Date.TabIndex = 1;
            tb_Date.WordWrap = false;
            // 
            // tb_ProdType
            // 
            tb_ProdType.BorderStyle = BorderStyle.FixedSingle;
            tb_ProdType.Font = new Font("Courier New", 9.75F);
            tb_ProdType.ForeColor = SystemColors.WindowFrame;
            tb_ProdType.Location = new Point(826, 54);
            tb_ProdType.Margin = new Padding(4, 3, 4, 3);
            tb_ProdType.Name = "tb_ProdType";
            tb_ProdType.ReadOnly = true;
            tb_ProdType.Size = new Size(224, 22);
            tb_ProdType.TabIndex = 1;
            tb_ProdType.WordWrap = false;
            // 
            // tb_Operation
            // 
            tb_Operation.BorderStyle = BorderStyle.FixedSingle;
            tb_Operation.Font = new Font("Courier New", 9.75F);
            tb_Operation.ForeColor = SystemColors.WindowFrame;
            tb_Operation.Location = new Point(139, 54);
            tb_Operation.Margin = new Padding(4, 3, 4, 3);
            tb_Operation.Name = "tb_Operation";
            tb_Operation.ReadOnly = true;
            tb_Operation.Size = new Size(81, 22);
            tb_Operation.TabIndex = 1;
            tb_Operation.WordWrap = false;
            // 
            // tb_ProdLine
            // 
            tb_ProdLine.BorderStyle = BorderStyle.FixedSingle;
            tb_ProdLine.Font = new Font("Courier New", 9.75F);
            tb_ProdLine.ForeColor = SystemColors.WindowFrame;
            tb_ProdLine.Location = new Point(826, 13);
            tb_ProdLine.Margin = new Padding(4, 3, 4, 3);
            tb_ProdLine.Name = "tb_ProdLine";
            tb_ProdLine.ReadOnly = true;
            tb_ProdLine.Size = new Size(224, 22);
            tb_ProdLine.TabIndex = 1;
            tb_ProdLine.WordWrap = false;
            // 
            // tb_PartNr
            // 
            tb_PartNr.BorderStyle = BorderStyle.FixedSingle;
            tb_PartNr.Font = new Font("Courier New", 9.75F);
            tb_PartNr.ForeColor = SystemColors.WindowFrame;
            tb_PartNr.Location = new Point(415, 13);
            tb_PartNr.Margin = new Padding(4, 3, 4, 3);
            tb_PartNr.Name = "tb_PartNr";
            tb_PartNr.ReadOnly = true;
            tb_PartNr.Size = new Size(193, 22);
            tb_PartNr.TabIndex = 1;
            tb_PartNr.WordWrap = false;
            tb_PartNr.Click += PartNr_LoadHistory_Click;
            // 
            // tb_OrderNr
            // 
            tb_OrderNr.BorderStyle = BorderStyle.FixedSingle;
            tb_OrderNr.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_OrderNr.ForeColor = SystemColors.WindowFrame;
            tb_OrderNr.Location = new Point(139, 13);
            tb_OrderNr.Margin = new Padding(4, 3, 4, 3);
            tb_OrderNr.Name = "tb_OrderNr";
            tb_OrderNr.ReadOnly = true;
            tb_OrderNr.Size = new Size(81, 22);
            tb_OrderNr.TabIndex = 1;
            tb_OrderNr.WordWrap = false;
            // 
            // label_Workoperation
            // 
            label_Workoperation.AutoSize = true;
            label_Workoperation.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            label_Workoperation.ForeColor = Color.FromArgb(147, 150, 149);
            label_Workoperation.Location = new Point(274, 52);
            label_Workoperation.Margin = new Padding(4, 0, 4, 0);
            label_Workoperation.Name = "label_Workoperation";
            label_Workoperation.Size = new Size(139, 23);
            label_Workoperation.TabIndex = 0;
            label_Workoperation.Text = "Arbetsoperation:";
            // 
            // label_Date
            // 
            label_Date.AutoSize = true;
            label_Date.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            label_Date.ForeColor = Color.FromArgb(147, 150, 149);
            label_Date.Location = new Point(580, 94);
            label_Date.Margin = new Padding(4, 0, 4, 0);
            label_Date.Name = "label_Date";
            label_Date.Size = new Size(244, 23);
            label_Date.TabIndex = 0;
            label_Date.Text = "Datum för inlämnad feedback:";
            // 
            // label_ProdType
            // 
            label_ProdType.AutoSize = true;
            label_ProdType.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            label_ProdType.ForeColor = Color.FromArgb(147, 150, 149);
            label_ProdType.Location = new Point(718, 52);
            label_ProdType.Margin = new Padding(4, 0, 4, 0);
            label_ProdType.Name = "label_ProdType";
            label_ProdType.Size = new Size(106, 23);
            label_ProdType.TabIndex = 0;
            label_ProdType.Text = "ProduktTyp:";
            // 
            // label__Operation
            // 
            label__Operation.AutoSize = true;
            label__Operation.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            label__Operation.ForeColor = Color.FromArgb(147, 150, 149);
            label__Operation.Location = new Point(45, 52);
            label__Operation.Margin = new Padding(4, 0, 4, 0);
            label__Operation.Name = "label__Operation";
            label__Operation.Size = new Size(92, 23);
            label__Operation.TabIndex = 0;
            label__Operation.Text = "Operation:";
            // 
            // label_ProdLine
            // 
            label_ProdLine.AutoSize = true;
            label_ProdLine.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            label_ProdLine.ForeColor = Color.FromArgb(147, 150, 149);
            label_ProdLine.Location = new Point(683, 11);
            label_ProdLine.Margin = new Padding(4, 0, 4, 0);
            label_ProdLine.Name = "label_ProdLine";
            label_ProdLine.Size = new Size(141, 23);
            label_ProdLine.TabIndex = 0;
            label_ProdLine.Text = "Produktionslinje:";
            // 
            // label_PartNumber
            // 
            label_PartNumber.AutoSize = true;
            label_PartNumber.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            label_PartNumber.ForeColor = Color.FromArgb(147, 150, 149);
            label_PartNumber.Location = new Point(324, 11);
            label_PartNumber.Margin = new Padding(4, 0, 4, 0);
            label_PartNumber.Name = "label_PartNumber";
            label_PartNumber.Size = new Size(89, 23);
            label_PartNumber.TabIndex = 0;
            label_PartNumber.Text = "ArtikelNr:";
            // 
            // label_OrderNr
            // 
            label_OrderNr.AutoSize = true;
            label_OrderNr.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            label_OrderNr.ForeColor = Color.FromArgb(147, 150, 149);
            label_OrderNr.Location = new Point(56, 11);
            label_OrderNr.Margin = new Padding(4, 0, 4, 0);
            label_OrderNr.Name = "label_OrderNr";
            label_OrderNr.Size = new Size(81, 23);
            label_OrderNr.TabIndex = 0;
            label_OrderNr.Text = "OrderNr:";
            // 
            // label_Header
            // 
            label_Header.AutoSize = true;
            label_Header.BackColor = Color.FromArgb(66, 113, 139);
            tlp_Main.SetColumnSpan(label_Header, 2);
            label_Header.Cursor = Cursors.SizeAll;
            label_Header.Dock = DockStyle.Fill;
            label_Header.Font = new Font("Lucida Sans", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Header.ForeColor = Color.FromArgb(187, 215, 228);
            label_Header.Location = new Point(0, 0);
            label_Header.Margin = new Padding(0);
            label_Header.Name = "label_Header";
            label_Header.Padding = new Padding(58, 0, 0, 0);
            label_Header.Size = new Size(1101, 68);
            label_Header.TabIndex = 0;
            label_Header.Text = "QC Feedback";
            label_Header.TextAlign = ContentAlignment.MiddleLeft;
            label_Header.MouseDown += MouseDown;
            label_Header.MouseMove += MouseMove;
            label_Header.MouseUp += MouseUp;
            // 
            // panel_Left
            // 
            panel_Left.BorderStyle = BorderStyle.Fixed3D;
            panel_Left.Controls.Add(tb_Comments);
            panel_Left.Controls.Add(label_Comments);
            panel_Left.Dock = DockStyle.Fill;
            panel_Left.Location = new Point(4, 223);
            panel_Left.Margin = new Padding(4, 3, 4, 3);
            panel_Left.Name = "panel_Left";
            panel_Left.Size = new Size(542, 131);
            panel_Left.TabIndex = 1;
            // 
            // tb_Comments
            // 
            tb_Comments.BorderStyle = BorderStyle.FixedSingle;
            tb_Comments.Font = new Font("Courier New", 9.75F);
            tb_Comments.ForeColor = SystemColors.WindowFrame;
            tb_Comments.Location = new Point(35, 37);
            tb_Comments.Margin = new Padding(4, 3, 4, 3);
            tb_Comments.Multiline = true;
            tb_Comments.Name = "tb_Comments";
            tb_Comments.Size = new Size(469, 75);
            tb_Comments.TabIndex = 1;
            tb_Comments.WordWrap = false;
            // 
            // label_Comments
            // 
            label_Comments.AutoSize = true;
            label_Comments.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            label_Comments.ForeColor = Color.FromArgb(147, 150, 149);
            label_Comments.Location = new Point(30, 5);
            label_Comments.Margin = new Padding(4, 0, 4, 0);
            label_Comments.Name = "label_Comments";
            label_Comments.Size = new Size(102, 23);
            label_Comments.TabIndex = 0;
            label_Comments.Text = "Kommentar";
            // 
            // panel_Buttons
            // 
            panel_Buttons.Controls.Add(btn_Exit);
            panel_Buttons.Controls.Add(btn_Save_Exit);
            panel_Buttons.Dock = DockStyle.Fill;
            panel_Buttons.Location = new Point(550, 946);
            panel_Buttons.Margin = new Padding(0);
            panel_Buttons.Name = "panel_Buttons";
            panel_Buttons.Size = new Size(551, 62);
            panel_Buttons.TabIndex = 4;
            // 
            // btn_Exit
            // 
            btn_Exit.BackColor = Color.FromArgb(255, 199, 206);
            btn_Exit.Cursor = Cursors.Hand;
            btn_Exit.Dock = DockStyle.Right;
            btn_Exit.FlatAppearance.BorderColor = Color.FromArgb(25, 25, 25);
            btn_Exit.FlatAppearance.MouseOverBackColor = Color.FromArgb(126, 0, 6);
            btn_Exit.FlatStyle = FlatStyle.Flat;
            btn_Exit.Font = new Font("Palatino Linotype", 10.25F);
            btn_Exit.ForeColor = Color.FromArgb(156, 0, 6);
            btn_Exit.Location = new Point(360, 0);
            btn_Exit.Margin = new Padding(4, 3, 4, 3);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(191, 62);
            btn_Exit.TabIndex = 1011;
            btn_Exit.Text = "Avsluta";
            btn_Exit.UseVisualStyleBackColor = false;
            btn_Exit.Click += Exit_Click;
            // 
            // btn_Save_Exit
            // 
            btn_Save_Exit.BackColor = Color.FromArgb(198, 239, 206);
            btn_Save_Exit.Cursor = Cursors.Hand;
            btn_Save_Exit.Dock = DockStyle.Left;
            btn_Save_Exit.FlatAppearance.BorderColor = Color.FromArgb(25, 25, 25);
            btn_Save_Exit.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 67, 0);
            btn_Save_Exit.FlatStyle = FlatStyle.Flat;
            btn_Save_Exit.Font = new Font("Palatino Linotype", 10.25F);
            btn_Save_Exit.ForeColor = Color.FromArgb(0, 97, 0);
            btn_Save_Exit.Location = new Point(0, 0);
            btn_Save_Exit.Margin = new Padding(12, 3, 4, 3);
            btn_Save_Exit.Name = "btn_Save_Exit";
            btn_Save_Exit.Size = new Size(191, 62);
            btn_Save_Exit.TabIndex = 1010;
            btn_Save_Exit.Text = "Spara och Avsluta";
            btn_Save_Exit.UseVisualStyleBackColor = false;
            btn_Save_Exit.Click += Save_Exit_Click;
            // 
            // pb_Image
            // 
            pb_Image.BackgroundImageLayout = ImageLayout.Stretch;
            tlp_Main.SetColumnSpan(pb_Image, 2);
            pb_Image.Dock = DockStyle.Fill;
            pb_Image.Location = new Point(4, 432);
            pb_Image.Margin = new Padding(4, 3, 4, 3);
            pb_Image.Name = "pb_Image";
            pb_Image.Size = new Size(1093, 511);
            pb_Image.TabIndex = 5;
            pb_Image.TabStop = false;
            // 
            // QC_Feedback
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(185, 188, 189);
            ClientSize = new Size(1101, 1008);
            Controls.Add(tlp_Main);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "QC_Feedback";
            Text = "QC_Feedback";
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            panel_Bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)num_RemainingViews).EndInit();
            panel1.ResumeLayout(false);
            panel_Right.ResumeLayout(false);
            panel_Right.PerformLayout();
            panel_OrderInfo.ResumeLayout(false);
            panel_OrderInfo.PerformLayout();
            panel_Left.ResumeLayout(false);
            panel_Left.PerformLayout();
            panel_Buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_Image).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.Label label_Header;
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.TextBox tb_Comments;
        private System.Windows.Forms.Label label_Comments;
        private System.Windows.Forms.Panel panel_OrderInfo;
        private System.Windows.Forms.TextBox tb_Operation;
        private System.Windows.Forms.TextBox tb_OrderNr;
        private System.Windows.Forms.Label label__Operation;
        private System.Windows.Forms.Label label_OrderNr;
        private System.Windows.Forms.Panel panel_Right;
        private System.Windows.Forms.TextBox tb_ppkHistory;
        private System.Windows.Forms.TextBox tb_ppkOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_WorkOperation;
        private System.Windows.Forms.TextBox tb_ProdLine;
        private System.Windows.Forms.Label label_Workoperation;
        private System.Windows.Forms.Label label_ProdLine;
        private System.Windows.Forms.TextBox tb_ProdType;
        private System.Windows.Forms.TextBox tb_PartNr;
        private System.Windows.Forms.Label label_ProdType;
        private System.Windows.Forms.Label label_PartNumber;
        private System.Windows.Forms.Panel panel_Buttons;
        public System.Windows.Forms.Button btn_Save_Exit;
        public System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btn_UploadImage;
        public System.Windows.Forms.Button btn_Screenshot;
        private System.Windows.Forms.PictureBox pb_Image;
        private System.Windows.Forms.TextBox tb_Date;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.Label label_RemainingView;
        private System.Windows.Forms.NumericUpDown num_RemainingViews;
    }
}