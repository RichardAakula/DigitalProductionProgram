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
            lbl_ParameterName = new Label();
            label_LSL = new Label();
            label_Nom = new Label();
            label_USL = new Label();
            tlp_Main = new TableLayoutPanel();
            tlp_SPC_Data = new TableLayoutPanel();
            lbl_LSL = new Label();
            lbl_NOM = new Label();
            lbl_USL = new Label();
            lbl_Bar_StandardDeviation = new Label();
            lbl_Bar_Ppk = new Label();
            lbl_Bar_Pp = new Label();
            lbl_Bar_Kurtosis = new Label();
            lbl_Kurtosis = new Label();
            lbl_Skewness = new Label();
            lbl_StandardDeviation = new Label();
            lbl_Range = new Label();
            label_Kurtosis = new Label();
            label_Skewness = new Label();
            label_StandardDev = new Label();
            label_Range = new Label();
            lbl_Min = new Label();
            label_Min = new Label();
            lbl_Max = new Label();
            label_Max = new Label();
            lbl_Median = new Label();
            label_Median = new Label();
            lbl_Mean = new Label();
            label_Mean = new Label();
            lbl_Ppk = new Label();
            label_Ppk = new Label();
            lbl_Pp = new Label();
            label_Pp = new Label();
            label_TotalOrders = new Label();
            lbl_TotalOrders = new Label();
            lbl_Bar_Skewness = new Label();
            label_PerformanceRatio = new Label();
            lbl_PerformanceRatio = new Label();
            lbl_Bar_PerformanceRatio = new Label();
            tlp_Main.SuspendLayout();
            tlp_SPC_Data.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_ParameterName
            // 
            lbl_ParameterName.AutoSize = true;
            tlp_SPC_Data.SetColumnSpan(lbl_ParameterName, 3);
            lbl_ParameterName.Dock = DockStyle.Fill;
            lbl_ParameterName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_ParameterName.ForeColor = Color.FromArgb(239, 228, 177);
            lbl_ParameterName.Location = new Point(3, 0);
            lbl_ParameterName.Name = "lbl_ParameterName";
            lbl_ParameterName.Size = new Size(295, 20);
            lbl_ParameterName.TabIndex = 0;
            lbl_ParameterName.Text = "Parameter Name:";
            lbl_ParameterName.TextAlign = ContentAlignment.TopCenter;
            // 
            // label_LSL
            // 
            label_LSL.AutoSize = true;
            label_LSL.Dock = DockStyle.Fill;
            label_LSL.ForeColor = Color.FromArgb(181, 210, 207);
            label_LSL.Location = new Point(3, 60);
            label_LSL.Name = "label_LSL";
            label_LSL.Size = new Size(119, 20);
            label_LSL.TabIndex = 0;
            label_LSL.Text = "LSL";
            label_LSL.TextAlign = ContentAlignment.TopRight;
            // 
            // label_Nom
            // 
            label_Nom.AutoSize = true;
            label_Nom.Dock = DockStyle.Fill;
            label_Nom.ForeColor = Color.FromArgb(181, 210, 207);
            label_Nom.Location = new Point(3, 40);
            label_Nom.Name = "label_Nom";
            label_Nom.Size = new Size(119, 20);
            label_Nom.TabIndex = 0;
            label_Nom.Text = "NOM";
            label_Nom.TextAlign = ContentAlignment.TopRight;
            // 
            // label_USL
            // 
            label_USL.AutoSize = true;
            label_USL.Dock = DockStyle.Fill;
            label_USL.ForeColor = Color.FromArgb(181, 210, 207);
            label_USL.Location = new Point(3, 20);
            label_USL.Name = "label_USL";
            label_USL.Size = new Size(119, 20);
            label_USL.TabIndex = 0;
            label_USL.Text = "USL";
            label_USL.TextAlign = ContentAlignment.TopRight;
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0203743F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.97962F));
            tlp_Main.Controls.Add(tlp_SPC_Data, 0, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 1;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_Main.Size = new Size(1227, 608);
            tlp_Main.TabIndex = 1;
            // 
            // tlp_SPC_Data
            // 
            tlp_SPC_Data.BackColor = Color.FromArgb(6, 81, 87);
            tlp_SPC_Data.ColumnCount = 3;
            tlp_SPC_Data.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            tlp_SPC_Data.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 49F));
            tlp_SPC_Data.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_SPC_Data.Controls.Add(lbl_LSL, 1, 3);
            tlp_SPC_Data.Controls.Add(lbl_NOM, 1, 2);
            tlp_SPC_Data.Controls.Add(lbl_USL, 1, 1);
            tlp_SPC_Data.Controls.Add(label_LSL, 0, 3);
            tlp_SPC_Data.Controls.Add(label_Nom, 0, 2);
            tlp_SPC_Data.Controls.Add(label_USL, 0, 1);
            tlp_SPC_Data.Controls.Add(lbl_ParameterName, 0, 0);
            tlp_SPC_Data.Controls.Add(lbl_Bar_StandardDeviation, 2, 10);
            tlp_SPC_Data.Controls.Add(lbl_Bar_Ppk, 2, 14);
            tlp_SPC_Data.Controls.Add(lbl_Bar_Pp, 2, 13);
            tlp_SPC_Data.Controls.Add(lbl_Bar_Kurtosis, 2, 12);
            tlp_SPC_Data.Controls.Add(lbl_Kurtosis, 1, 12);
            tlp_SPC_Data.Controls.Add(lbl_Skewness, 1, 11);
            tlp_SPC_Data.Controls.Add(lbl_StandardDeviation, 1, 10);
            tlp_SPC_Data.Controls.Add(lbl_Range, 1, 9);
            tlp_SPC_Data.Controls.Add(label_Kurtosis, 0, 12);
            tlp_SPC_Data.Controls.Add(label_Skewness, 0, 11);
            tlp_SPC_Data.Controls.Add(label_StandardDev, 0, 10);
            tlp_SPC_Data.Controls.Add(label_Range, 0, 9);
            tlp_SPC_Data.Controls.Add(lbl_Min, 1, 7);
            tlp_SPC_Data.Controls.Add(label_Min, 0, 7);
            tlp_SPC_Data.Controls.Add(lbl_Max, 1, 8);
            tlp_SPC_Data.Controls.Add(label_Max, 0, 8);
            tlp_SPC_Data.Controls.Add(lbl_Median, 1, 6);
            tlp_SPC_Data.Controls.Add(label_Median, 0, 6);
            tlp_SPC_Data.Controls.Add(lbl_Mean, 1, 5);
            tlp_SPC_Data.Controls.Add(label_Mean, 0, 5);
            tlp_SPC_Data.Controls.Add(lbl_Ppk, 1, 14);
            tlp_SPC_Data.Controls.Add(label_Ppk, 0, 14);
            tlp_SPC_Data.Controls.Add(lbl_Pp, 1, 13);
            tlp_SPC_Data.Controls.Add(label_Pp, 0, 13);
            tlp_SPC_Data.Controls.Add(label_TotalOrders, 0, 4);
            tlp_SPC_Data.Controls.Add(lbl_TotalOrders, 1, 4);
            tlp_SPC_Data.Controls.Add(lbl_Bar_Skewness, 2, 11);
            tlp_SPC_Data.Controls.Add(label_PerformanceRatio, 0, 15);
            tlp_SPC_Data.Controls.Add(lbl_PerformanceRatio, 1, 15);
            tlp_SPC_Data.Controls.Add(lbl_Bar_PerformanceRatio, 2, 15);
            tlp_SPC_Data.Dock = DockStyle.Fill;
            tlp_SPC_Data.Location = new Point(3, 3);
            tlp_SPC_Data.Name = "tlp_SPC_Data";
            tlp_SPC_Data.RowCount = 17;
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_SPC_Data.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_SPC_Data.Size = new Size(301, 602);
            tlp_SPC_Data.TabIndex = 872;
            // 
            // lbl_LSL
            // 
            lbl_LSL.AutoSize = true;
            lbl_LSL.Dock = DockStyle.Fill;
            lbl_LSL.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_LSL.Location = new Point(128, 60);
            lbl_LSL.Name = "lbl_LSL";
            lbl_LSL.Size = new Size(43, 20);
            lbl_LSL.TabIndex = 32;
            lbl_LSL.Text = "0";
            // 
            // lbl_NOM
            // 
            lbl_NOM.AutoSize = true;
            lbl_NOM.Dock = DockStyle.Fill;
            lbl_NOM.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_NOM.Location = new Point(128, 40);
            lbl_NOM.Name = "lbl_NOM";
            lbl_NOM.Size = new Size(43, 20);
            lbl_NOM.TabIndex = 31;
            lbl_NOM.Text = "0";
            // 
            // lbl_USL
            // 
            lbl_USL.AutoSize = true;
            lbl_USL.Dock = DockStyle.Fill;
            lbl_USL.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_USL.Location = new Point(128, 20);
            lbl_USL.Name = "lbl_USL";
            lbl_USL.Size = new Size(43, 20);
            lbl_USL.TabIndex = 30;
            lbl_USL.Text = "0";
            // 
            // lbl_Bar_StandardDeviation
            // 
            lbl_Bar_StandardDeviation.AutoSize = true;
            lbl_Bar_StandardDeviation.Dock = DockStyle.Fill;
            lbl_Bar_StandardDeviation.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl_Bar_StandardDeviation.ForeColor = Color.FromArgb(147, 146, 153);
            lbl_Bar_StandardDeviation.Location = new Point(177, 200);
            lbl_Bar_StandardDeviation.Name = "lbl_Bar_StandardDeviation";
            lbl_Bar_StandardDeviation.Size = new Size(121, 20);
            lbl_Bar_StandardDeviation.TabIndex = 25;
            lbl_Bar_StandardDeviation.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl_Bar_Ppk
            // 
            lbl_Bar_Ppk.AutoSize = true;
            lbl_Bar_Ppk.Dock = DockStyle.Fill;
            lbl_Bar_Ppk.Location = new Point(177, 280);
            lbl_Bar_Ppk.Name = "lbl_Bar_Ppk";
            lbl_Bar_Ppk.Size = new Size(121, 20);
            lbl_Bar_Ppk.TabIndex = 24;
            lbl_Bar_Ppk.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Bar_Pp
            // 
            lbl_Bar_Pp.AutoSize = true;
            lbl_Bar_Pp.Dock = DockStyle.Fill;
            lbl_Bar_Pp.Location = new Point(177, 260);
            lbl_Bar_Pp.Name = "lbl_Bar_Pp";
            lbl_Bar_Pp.Size = new Size(121, 20);
            lbl_Bar_Pp.TabIndex = 23;
            lbl_Bar_Pp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Bar_Kurtosis
            // 
            lbl_Bar_Kurtosis.AutoSize = true;
            lbl_Bar_Kurtosis.Dock = DockStyle.Fill;
            lbl_Bar_Kurtosis.Location = new Point(177, 240);
            lbl_Bar_Kurtosis.Name = "lbl_Bar_Kurtosis";
            lbl_Bar_Kurtosis.Size = new Size(121, 20);
            lbl_Bar_Kurtosis.TabIndex = 22;
            lbl_Bar_Kurtosis.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Kurtosis
            // 
            lbl_Kurtosis.AutoSize = true;
            lbl_Kurtosis.Dock = DockStyle.Fill;
            lbl_Kurtosis.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Kurtosis.Location = new Point(128, 240);
            lbl_Kurtosis.Name = "lbl_Kurtosis";
            lbl_Kurtosis.Size = new Size(43, 20);
            lbl_Kurtosis.TabIndex = 20;
            lbl_Kurtosis.Text = "-";
            // 
            // lbl_Skewness
            // 
            lbl_Skewness.AutoSize = true;
            lbl_Skewness.Dock = DockStyle.Fill;
            lbl_Skewness.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Skewness.Location = new Point(128, 220);
            lbl_Skewness.Name = "lbl_Skewness";
            lbl_Skewness.Size = new Size(43, 20);
            lbl_Skewness.TabIndex = 19;
            lbl_Skewness.Text = "-";
            // 
            // lbl_StandardDeviation
            // 
            lbl_StandardDeviation.AutoSize = true;
            lbl_StandardDeviation.Dock = DockStyle.Fill;
            lbl_StandardDeviation.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_StandardDeviation.Location = new Point(128, 200);
            lbl_StandardDeviation.Name = "lbl_StandardDeviation";
            lbl_StandardDeviation.Size = new Size(43, 20);
            lbl_StandardDeviation.TabIndex = 18;
            lbl_StandardDeviation.Text = "-";
            // 
            // lbl_Range
            // 
            lbl_Range.AutoSize = true;
            lbl_Range.Dock = DockStyle.Fill;
            lbl_Range.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Range.Location = new Point(128, 180);
            lbl_Range.Name = "lbl_Range";
            lbl_Range.Size = new Size(43, 20);
            lbl_Range.TabIndex = 17;
            lbl_Range.Text = "-";
            // 
            // label_Kurtosis
            // 
            label_Kurtosis.AutoSize = true;
            label_Kurtosis.Dock = DockStyle.Fill;
            label_Kurtosis.ForeColor = Color.FromArgb(181, 210, 207);
            label_Kurtosis.Location = new Point(3, 240);
            label_Kurtosis.Name = "label_Kurtosis";
            label_Kurtosis.Size = new Size(119, 20);
            label_Kurtosis.TabIndex = 16;
            label_Kurtosis.Text = "Kurtosis:";
            label_Kurtosis.TextAlign = ContentAlignment.TopRight;
            // 
            // label_Skewness
            // 
            label_Skewness.AutoSize = true;
            label_Skewness.Dock = DockStyle.Fill;
            label_Skewness.ForeColor = Color.FromArgb(181, 210, 207);
            label_Skewness.Location = new Point(3, 220);
            label_Skewness.Name = "label_Skewness";
            label_Skewness.Size = new Size(119, 20);
            label_Skewness.TabIndex = 15;
            label_Skewness.Text = "Skewness:";
            label_Skewness.TextAlign = ContentAlignment.TopRight;
            // 
            // label_StandardDev
            // 
            label_StandardDev.AutoSize = true;
            label_StandardDev.Dock = DockStyle.Fill;
            label_StandardDev.ForeColor = Color.FromArgb(181, 210, 207);
            label_StandardDev.Location = new Point(3, 200);
            label_StandardDev.Name = "label_StandardDev";
            label_StandardDev.Size = new Size(119, 20);
            label_StandardDev.TabIndex = 14;
            label_StandardDev.Text = "Standard Deviation:";
            label_StandardDev.TextAlign = ContentAlignment.TopRight;
            // 
            // label_Range
            // 
            label_Range.AutoSize = true;
            label_Range.Dock = DockStyle.Fill;
            label_Range.ForeColor = Color.FromArgb(181, 210, 207);
            label_Range.Location = new Point(3, 180);
            label_Range.Name = "label_Range";
            label_Range.Size = new Size(119, 20);
            label_Range.TabIndex = 13;
            label_Range.Text = "Range:";
            label_Range.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_Min
            // 
            lbl_Min.AutoSize = true;
            lbl_Min.Dock = DockStyle.Fill;
            lbl_Min.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Min.Location = new Point(128, 140);
            lbl_Min.Name = "lbl_Min";
            lbl_Min.Size = new Size(43, 20);
            lbl_Min.TabIndex = 12;
            lbl_Min.Text = "-";
            // 
            // label_Min
            // 
            label_Min.AutoSize = true;
            label_Min.Dock = DockStyle.Fill;
            label_Min.ForeColor = Color.FromArgb(181, 210, 207);
            label_Min.Location = new Point(3, 140);
            label_Min.Name = "label_Min";
            label_Min.Size = new Size(119, 20);
            label_Min.TabIndex = 11;
            label_Min.Text = "Min:";
            label_Min.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_Max
            // 
            lbl_Max.AutoSize = true;
            lbl_Max.Dock = DockStyle.Fill;
            lbl_Max.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Max.Location = new Point(128, 160);
            lbl_Max.Name = "lbl_Max";
            lbl_Max.Size = new Size(43, 20);
            lbl_Max.TabIndex = 10;
            lbl_Max.Text = "-";
            // 
            // label_Max
            // 
            label_Max.AutoSize = true;
            label_Max.Dock = DockStyle.Fill;
            label_Max.ForeColor = Color.FromArgb(181, 210, 207);
            label_Max.Location = new Point(3, 160);
            label_Max.Name = "label_Max";
            label_Max.Size = new Size(119, 20);
            label_Max.TabIndex = 9;
            label_Max.Text = "Max:";
            label_Max.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_Median
            // 
            lbl_Median.AutoSize = true;
            lbl_Median.Dock = DockStyle.Fill;
            lbl_Median.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Median.Location = new Point(128, 120);
            lbl_Median.Name = "lbl_Median";
            lbl_Median.Size = new Size(43, 20);
            lbl_Median.TabIndex = 8;
            lbl_Median.Text = "-";
            // 
            // label_Median
            // 
            label_Median.AutoSize = true;
            label_Median.Dock = DockStyle.Fill;
            label_Median.ForeColor = Color.FromArgb(181, 210, 207);
            label_Median.Location = new Point(3, 120);
            label_Median.Name = "label_Median";
            label_Median.Size = new Size(119, 20);
            label_Median.TabIndex = 7;
            label_Median.Text = "Median:";
            label_Median.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_Mean
            // 
            lbl_Mean.AutoSize = true;
            lbl_Mean.Dock = DockStyle.Fill;
            lbl_Mean.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Mean.Location = new Point(128, 100);
            lbl_Mean.Name = "lbl_Mean";
            lbl_Mean.Size = new Size(43, 20);
            lbl_Mean.TabIndex = 6;
            lbl_Mean.Text = "-";
            // 
            // label_Mean
            // 
            label_Mean.AutoSize = true;
            label_Mean.Dock = DockStyle.Fill;
            label_Mean.ForeColor = Color.FromArgb(181, 210, 207);
            label_Mean.Location = new Point(3, 100);
            label_Mean.Name = "label_Mean";
            label_Mean.Size = new Size(119, 20);
            label_Mean.TabIndex = 5;
            label_Mean.Text = "Mean:";
            label_Mean.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_Ppk
            // 
            lbl_Ppk.AutoSize = true;
            lbl_Ppk.Dock = DockStyle.Fill;
            lbl_Ppk.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Ppk.Location = new Point(128, 280);
            lbl_Ppk.Name = "lbl_Ppk";
            lbl_Ppk.Size = new Size(43, 20);
            lbl_Ppk.TabIndex = 4;
            lbl_Ppk.Text = "-";
            // 
            // label_Ppk
            // 
            label_Ppk.AutoSize = true;
            label_Ppk.Dock = DockStyle.Fill;
            label_Ppk.ForeColor = Color.FromArgb(181, 210, 207);
            label_Ppk.Location = new Point(3, 280);
            label_Ppk.Name = "label_Ppk";
            label_Ppk.Size = new Size(119, 20);
            label_Ppk.TabIndex = 3;
            label_Ppk.Text = "Ppk:";
            label_Ppk.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_Pp
            // 
            lbl_Pp.AutoSize = true;
            lbl_Pp.Dock = DockStyle.Fill;
            lbl_Pp.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_Pp.Location = new Point(128, 260);
            lbl_Pp.Name = "lbl_Pp";
            lbl_Pp.Size = new Size(43, 20);
            lbl_Pp.TabIndex = 2;
            lbl_Pp.Text = "-";
            // 
            // label_Pp
            // 
            label_Pp.AutoSize = true;
            label_Pp.Dock = DockStyle.Fill;
            label_Pp.ForeColor = Color.FromArgb(181, 210, 207);
            label_Pp.Location = new Point(3, 260);
            label_Pp.Name = "label_Pp";
            label_Pp.Size = new Size(119, 20);
            label_Pp.TabIndex = 1;
            label_Pp.Text = "Pp:";
            label_Pp.TextAlign = ContentAlignment.TopRight;
            // 
            // label_TotalOrders
            // 
            label_TotalOrders.AutoSize = true;
            label_TotalOrders.Dock = DockStyle.Fill;
            label_TotalOrders.ForeColor = Color.FromArgb(181, 210, 207);
            label_TotalOrders.Location = new Point(3, 80);
            label_TotalOrders.Name = "label_TotalOrders";
            label_TotalOrders.Size = new Size(119, 20);
            label_TotalOrders.TabIndex = 0;
            label_TotalOrders.Text = "Total Orders:";
            label_TotalOrders.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_TotalOrders
            // 
            lbl_TotalOrders.AutoSize = true;
            lbl_TotalOrders.Dock = DockStyle.Fill;
            lbl_TotalOrders.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_TotalOrders.Location = new Point(128, 80);
            lbl_TotalOrders.Name = "lbl_TotalOrders";
            lbl_TotalOrders.Size = new Size(43, 20);
            lbl_TotalOrders.TabIndex = 0;
            lbl_TotalOrders.Text = "0";
            // 
            // lbl_Bar_Skewness
            // 
            lbl_Bar_Skewness.AutoSize = true;
            lbl_Bar_Skewness.Dock = DockStyle.Fill;
            lbl_Bar_Skewness.Location = new Point(177, 220);
            lbl_Bar_Skewness.Name = "lbl_Bar_Skewness";
            lbl_Bar_Skewness.Size = new Size(121, 20);
            lbl_Bar_Skewness.TabIndex = 21;
            lbl_Bar_Skewness.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_PerformanceRatio
            // 
            label_PerformanceRatio.AutoSize = true;
            label_PerformanceRatio.Dock = DockStyle.Fill;
            label_PerformanceRatio.ForeColor = Color.FromArgb(181, 210, 207);
            label_PerformanceRatio.Location = new Point(3, 300);
            label_PerformanceRatio.Name = "label_PerformanceRatio";
            label_PerformanceRatio.Size = new Size(119, 20);
            label_PerformanceRatio.TabIndex = 26;
            label_PerformanceRatio.Text = "Performance Ratio:";
            label_PerformanceRatio.TextAlign = ContentAlignment.TopRight;
            // 
            // lbl_PerformanceRatio
            // 
            lbl_PerformanceRatio.AutoSize = true;
            lbl_PerformanceRatio.Dock = DockStyle.Fill;
            lbl_PerformanceRatio.ForeColor = Color.FromArgb(184, 220, 231);
            lbl_PerformanceRatio.Location = new Point(128, 300);
            lbl_PerformanceRatio.Name = "lbl_PerformanceRatio";
            lbl_PerformanceRatio.Size = new Size(43, 20);
            lbl_PerformanceRatio.TabIndex = 27;
            lbl_PerformanceRatio.Text = "-";
            // 
            // lbl_Bar_PerformanceRatio
            // 
            lbl_Bar_PerformanceRatio.AutoSize = true;
            lbl_Bar_PerformanceRatio.Dock = DockStyle.Fill;
            lbl_Bar_PerformanceRatio.Location = new Point(177, 300);
            lbl_Bar_PerformanceRatio.Name = "lbl_Bar_PerformanceRatio";
            lbl_Bar_PerformanceRatio.Size = new Size(121, 20);
            lbl_Bar_PerformanceRatio.TabIndex = 28;
            lbl_Bar_PerformanceRatio.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SpcOrderAnalysis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1227, 608);
            Controls.Add(tlp_Main);
            Name = "SpcOrderAnalysis";
            Text = "SpcOrderAnalysis";
            tlp_Main.ResumeLayout(false);
            tlp_SPC_Data.ResumeLayout(false);
            tlp_SPC_Data.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_ParameterName;
        private Label label_LSL;
        private Label label_Nom;
        private Label label_USL;
        private TableLayoutPanel tlp_Main;
        private TableLayoutPanel tlp_SPC_Data;
        private Label lbl_Bar_StandardDeviation;
        private Label lbl_Bar_Ppk;
        private Label lbl_Bar_Pp;
        private Label lbl_Bar_Kurtosis;
        private Label lbl_Kurtosis;
        private Label lbl_Skewness;
        private Label lbl_StandardDeviation;
        private Label lbl_Range;
        private Label label_Kurtosis;
        private Label label_Skewness;
        private Label label_StandardDev;
        private Label label_Range;
        private Label lbl_Min;
        private Label label_Min;
        private Label lbl_Max;
        private Label label_Max;
        private Label lbl_Median;
        private Label label_Median;
        private Label lbl_Mean;
        private Label label_Mean;
        private Label lbl_Ppk;
        private Label label_Ppk;
        private Label lbl_Pp;
        private Label label_Pp;
        private Label label_TotalOrders;
        private Label lbl_TotalOrders;
        private Label lbl_Bar_Skewness;
        private Label label_PerformanceRatio;
        private Label lbl_PerformanceRatio;
        private Label lbl_Bar_PerformanceRatio;
        private Label lbl_LSL;
        private Label lbl_NOM;
        private Label lbl_USL;
    }
}