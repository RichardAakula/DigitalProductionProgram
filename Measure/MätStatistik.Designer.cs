using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DigitalProductionProgram.Measure
{
    sealed partial class MätStatistik
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
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();
            Title title1 = new Title();
            panel1 = new Panel();
            tlp_SPC = new TableLayoutPanel();
            lbl_LSL = new Label();
            label_LSL = new Label();
            lbl_USL = new Label();
            label_USL = new Label();
            lbl_Cpk = new Label();
            label_Cpk = new Label();
            lbl_Cp = new Label();
            label_Cp = new Label();
            label_Max = new Label();
            lbl_HiLo = new Label();
            label_Avg = new Label();
            lbl_Min = new Label();
            label_HiLo = new Label();
            lbl_Avg = new Label();
            label_Min = new Label();
            lbl_Max = new Label();
            dgv_OrderList = new DataGridView();
            order = new DataGridViewTextBoxColumn();
            cB_visaAllaOrdrar = new CheckBox();
            cb_Mått = new ComboBox();
            chartData = new Chart();
            lblOrderNr = new Label();
            panel1.SuspendLayout();
            tlp_SPC.SuspendLayout();
            ((ISupportInitialize)dgv_OrderList).BeginInit();
            ((ISupportInitialize)chartData).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 24, 24);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(tlp_SPC);
            panel1.Controls.Add(dgv_OrderList);
            panel1.Controls.Add(cB_visaAllaOrdrar);
            panel1.Controls.Add(cb_Mått);
            panel1.Controls.Add(chartData);
            panel1.Controls.Add(lblOrderNr);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1210, 576);
            panel1.TabIndex = 0;
            // 
            // tlp_SPC
            // 
            tlp_SPC.ColumnCount = 2;
            tlp_SPC.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.95238F));
            tlp_SPC.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.04762F));
            tlp_SPC.Controls.Add(lbl_LSL, 1, 4);
            tlp_SPC.Controls.Add(label_LSL, 0, 4);
            tlp_SPC.Controls.Add(lbl_USL, 1, 0);
            tlp_SPC.Controls.Add(label_USL, 0, 0);
            tlp_SPC.Controls.Add(lbl_Cpk, 1, 8);
            tlp_SPC.Controls.Add(label_Cpk, 0, 8);
            tlp_SPC.Controls.Add(lbl_Cp, 1, 7);
            tlp_SPC.Controls.Add(label_Cp, 0, 7);
            tlp_SPC.Controls.Add(label_Max, 0, 1);
            tlp_SPC.Controls.Add(lbl_HiLo, 1, 5);
            tlp_SPC.Controls.Add(label_Avg, 0, 2);
            tlp_SPC.Controls.Add(lbl_Min, 1, 3);
            tlp_SPC.Controls.Add(label_HiLo, 0, 5);
            tlp_SPC.Controls.Add(lbl_Avg, 1, 2);
            tlp_SPC.Controls.Add(label_Min, 0, 3);
            tlp_SPC.Controls.Add(lbl_Max, 1, 1);
            tlp_SPC.Location = new Point(1071, 83);
            tlp_SPC.Margin = new Padding(4, 3, 4, 3);
            tlp_SPC.Name = "tlp_SPC";
            tlp_SPC.RowCount = 9;
            tlp_SPC.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_SPC.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_SPC.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_SPC.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_SPC.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_SPC.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_SPC.RowStyles.Add(new RowStyle(SizeType.Absolute, 17F));
            tlp_SPC.RowStyles.Add(new RowStyle(SizeType.Absolute, 17F));
            tlp_SPC.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_SPC.Size = new Size(122, 203);
            tlp_SPC.TabIndex = 5;
            // 
            // lbl_LSL
            // 
            lbl_LSL.AutoSize = true;
            lbl_LSL.Dock = DockStyle.Fill;
            lbl_LSL.ForeColor = Color.White;
            lbl_LSL.Location = new Point(53, 92);
            lbl_LSL.Margin = new Padding(4, 0, 4, 0);
            lbl_LSL.Name = "lbl_LSL";
            lbl_LSL.Size = new Size(65, 23);
            lbl_LSL.TabIndex = 12;
            lbl_LSL.Text = "0,000";
            lbl_LSL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_LSL
            // 
            label_LSL.AutoSize = true;
            label_LSL.Dock = DockStyle.Fill;
            label_LSL.ForeColor = Color.Red;
            label_LSL.Location = new Point(4, 92);
            label_LSL.Margin = new Padding(4, 0, 4, 0);
            label_LSL.Name = "label_LSL";
            label_LSL.Size = new Size(41, 23);
            label_LSL.TabIndex = 11;
            label_LSL.Text = "LSL:";
            label_LSL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_USL
            // 
            lbl_USL.AutoSize = true;
            lbl_USL.Dock = DockStyle.Fill;
            lbl_USL.ForeColor = Color.White;
            lbl_USL.Location = new Point(53, 0);
            lbl_USL.Margin = new Padding(4, 0, 4, 0);
            lbl_USL.Name = "lbl_USL";
            lbl_USL.Size = new Size(65, 23);
            lbl_USL.TabIndex = 10;
            lbl_USL.Text = "0,000";
            lbl_USL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_USL
            // 
            label_USL.AutoSize = true;
            label_USL.Dock = DockStyle.Fill;
            label_USL.ForeColor = Color.Red;
            label_USL.Location = new Point(4, 0);
            label_USL.Margin = new Padding(4, 0, 4, 0);
            label_USL.Name = "label_USL";
            label_USL.Size = new Size(41, 23);
            label_USL.TabIndex = 9;
            label_USL.Text = "USL:";
            label_USL.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Cpk
            // 
            lbl_Cpk.AutoSize = true;
            lbl_Cpk.Dock = DockStyle.Fill;
            lbl_Cpk.ForeColor = Color.White;
            lbl_Cpk.Location = new Point(53, 172);
            lbl_Cpk.Margin = new Padding(4, 0, 4, 0);
            lbl_Cpk.Name = "lbl_Cpk";
            lbl_Cpk.Size = new Size(65, 31);
            lbl_Cpk.TabIndex = 8;
            lbl_Cpk.Text = "0,000";
            lbl_Cpk.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Cpk
            // 
            label_Cpk.AutoSize = true;
            label_Cpk.Dock = DockStyle.Fill;
            label_Cpk.ForeColor = Color.Gold;
            label_Cpk.Location = new Point(4, 172);
            label_Cpk.Margin = new Padding(4, 0, 4, 0);
            label_Cpk.Name = "label_Cpk";
            label_Cpk.Size = new Size(41, 31);
            label_Cpk.TabIndex = 7;
            label_Cpk.Text = "Cpk:";
            label_Cpk.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Cp
            // 
            lbl_Cp.AutoSize = true;
            lbl_Cp.Dock = DockStyle.Fill;
            lbl_Cp.ForeColor = Color.White;
            lbl_Cp.Location = new Point(53, 155);
            lbl_Cp.Margin = new Padding(4, 0, 4, 0);
            lbl_Cp.Name = "lbl_Cp";
            lbl_Cp.Size = new Size(65, 17);
            lbl_Cp.TabIndex = 6;
            lbl_Cp.Text = "0,000";
            lbl_Cp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Cp
            // 
            label_Cp.AutoSize = true;
            label_Cp.Dock = DockStyle.Fill;
            label_Cp.ForeColor = Color.Gold;
            label_Cp.Location = new Point(4, 155);
            label_Cp.Margin = new Padding(4, 0, 4, 0);
            label_Cp.Name = "label_Cp";
            label_Cp.Size = new Size(41, 17);
            label_Cp.TabIndex = 5;
            label_Cp.Text = "Cp:";
            label_Cp.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Max
            // 
            label_Max.AutoSize = true;
            label_Max.Dock = DockStyle.Fill;
            label_Max.ForeColor = Color.Gold;
            label_Max.Location = new Point(4, 23);
            label_Max.Margin = new Padding(4, 0, 4, 0);
            label_Max.Name = "label_Max";
            label_Max.Size = new Size(41, 23);
            label_Max.TabIndex = 4;
            label_Max.Text = "Max:";
            label_Max.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_HiLo
            // 
            lbl_HiLo.AutoSize = true;
            lbl_HiLo.Dock = DockStyle.Fill;
            lbl_HiLo.ForeColor = Color.White;
            lbl_HiLo.Location = new Point(53, 115);
            lbl_HiLo.Margin = new Padding(4, 0, 4, 0);
            lbl_HiLo.Name = "lbl_HiLo";
            lbl_HiLo.Size = new Size(65, 23);
            lbl_HiLo.TabIndex = 4;
            lbl_HiLo.Text = "0,000";
            lbl_HiLo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Avg
            // 
            label_Avg.AutoSize = true;
            label_Avg.Dock = DockStyle.Fill;
            label_Avg.ForeColor = Color.Gold;
            label_Avg.Location = new Point(4, 46);
            label_Avg.Margin = new Padding(4, 0, 4, 0);
            label_Avg.Name = "label_Avg";
            label_Avg.Size = new Size(41, 23);
            label_Avg.TabIndex = 4;
            label_Avg.Text = "Avg:";
            label_Avg.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Min
            // 
            lbl_Min.AutoSize = true;
            lbl_Min.Dock = DockStyle.Fill;
            lbl_Min.ForeColor = Color.White;
            lbl_Min.Location = new Point(53, 69);
            lbl_Min.Margin = new Padding(4, 0, 4, 0);
            lbl_Min.Name = "lbl_Min";
            lbl_Min.Size = new Size(65, 23);
            lbl_Min.TabIndex = 4;
            lbl_Min.Text = "0,000";
            lbl_Min.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_HiLo
            // 
            label_HiLo.AutoSize = true;
            label_HiLo.Dock = DockStyle.Fill;
            label_HiLo.ForeColor = Color.Gold;
            label_HiLo.Location = new Point(4, 115);
            label_HiLo.Margin = new Padding(4, 0, 4, 0);
            label_HiLo.Name = "label_HiLo";
            label_HiLo.Size = new Size(41, 23);
            label_HiLo.TabIndex = 4;
            label_HiLo.Text = "HiLo:";
            label_HiLo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Avg
            // 
            lbl_Avg.AutoSize = true;
            lbl_Avg.Dock = DockStyle.Fill;
            lbl_Avg.ForeColor = Color.White;
            lbl_Avg.Location = new Point(53, 46);
            lbl_Avg.Margin = new Padding(4, 0, 4, 0);
            lbl_Avg.Name = "lbl_Avg";
            lbl_Avg.Size = new Size(65, 23);
            lbl_Avg.TabIndex = 4;
            lbl_Avg.Text = "0,000";
            lbl_Avg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Min
            // 
            label_Min.AutoSize = true;
            label_Min.Dock = DockStyle.Fill;
            label_Min.ForeColor = Color.Gold;
            label_Min.Location = new Point(4, 69);
            label_Min.Margin = new Padding(4, 0, 4, 0);
            label_Min.Name = "label_Min";
            label_Min.Size = new Size(41, 23);
            label_Min.TabIndex = 4;
            label_Min.Text = "Min:";
            label_Min.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Max
            // 
            lbl_Max.AutoSize = true;
            lbl_Max.Dock = DockStyle.Fill;
            lbl_Max.ForeColor = Color.White;
            lbl_Max.Location = new Point(53, 23);
            lbl_Max.Margin = new Padding(4, 0, 4, 0);
            lbl_Max.Name = "lbl_Max";
            lbl_Max.Size = new Size(65, 23);
            lbl_Max.TabIndex = 4;
            lbl_Max.Text = "0,000";
            lbl_Max.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgv_OrderList
            // 
            dgv_OrderList.BackgroundColor = Color.FromArgb(24, 24, 24);
            dgv_OrderList.BorderStyle = BorderStyle.None;
            dgv_OrderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_OrderList.Columns.AddRange(new DataGridViewColumn[] { order });
            dgv_OrderList.Location = new Point(972, 83);
            dgv_OrderList.Margin = new Padding(4, 3, 4, 3);
            dgv_OrderList.Name = "dgv_OrderList";
            dgv_OrderList.RowHeadersVisible = false;
            dgv_OrderList.Size = new Size(92, 297);
            dgv_OrderList.TabIndex = 3;
            dgv_OrderList.Visible = false;
            dgv_OrderList.CellContentClick += DataGridView_Data_CellContentClick;
            // 
            // order
            // 
            order.HeaderText = "OrderNr";
            order.Name = "order";
            order.Width = 70;
            // 
            // cB_visaAllaOrdrar
            // 
            cB_visaAllaOrdrar.AutoSize = true;
            cB_visaAllaOrdrar.ForeColor = Color.White;
            cB_visaAllaOrdrar.Location = new Point(978, 57);
            cB_visaAllaOrdrar.Margin = new Padding(4, 3, 4, 3);
            cB_visaAllaOrdrar.Name = "cB_visaAllaOrdrar";
            cB_visaAllaOrdrar.Size = new Size(206, 19);
            cB_visaAllaOrdrar.TabIndex = 1;
            cB_visaAllaOrdrar.Text = "Visa alla ordrar med detta artikelnr";
            cB_visaAllaOrdrar.UseVisualStyleBackColor = true;
            cB_visaAllaOrdrar.Visible = false;
            cB_visaAllaOrdrar.CheckedChanged += Mått_SelectedIndexChanged;
            // 
            // cb_Mått
            // 
            cb_Mått.FormattingEnabled = true;
            cb_Mått.Location = new Point(978, 12);
            cb_Mått.Margin = new Padding(4, 3, 4, 3);
            cb_Mått.Name = "cb_Mått";
            cb_Mått.Size = new Size(162, 23);
            cb_Mått.TabIndex = 2;
            cb_Mått.Visible = false;
            cb_Mått.SelectedIndexChanged += Mått_SelectedIndexChanged;
            // 
            // chartData
            // 
            chartData.BackColor = Color.FromArgb(24, 24, 24);
            chartArea1.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea1.AxisX.LineColor = Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = Color.DimGray;
            chartArea1.AxisX2.LineColor = Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea1.AxisY.LineColor = Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = Color.DimGray;
            chartArea1.AxisY2.LineColor = Color.White;
            chartArea1.BackColor = Color.Transparent;
            chartArea1.BorderColor = Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chartData.ChartAreas.Add(chartArea1);
            legend1.BackColor = Color.Transparent;
            legend1.Enabled = false;
            legend1.ForeColor = Color.White;
            legend1.Name = "Legend1";
            legend1.TableStyle = LegendTableStyle.Wide;
            legend1.TitleForeColor = Color.White;
            chartData.Legends.Add(legend1);
            chartData.Location = new Point(7, 40);
            chartData.Margin = new Padding(4, 3, 4, 3);
            chartData.Name = "chartData";
            chartData.Palette = ChartColorPalette.Light;
            series1.BorderColor = Color.Red;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Spline;
            series1.Color = Color.Green;
            series1.LabelBackColor = Color.Black;
            series1.LabelBorderColor = Color.Transparent;
            series1.LabelForeColor = Color.White;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = Color.White;
            series1.Name = "Value";
            series1.YValuesPerPoint = 6;
            chartData.Series.Add(series1);
            chartData.Size = new Size(960, 519);
            chartData.TabIndex = 1;
            chartData.Text = "chart1";
            title1.Font = new Font("Lucida Bright", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            title1.ForeColor = Color.Orange;
            title1.Name = "Title1";
            title1.Text = "Blåst ID";
            chartData.Titles.Add(title1);
            chartData.Visible = false;
            chartData.MouseMove += Chart_Data_MouseMove;
            // 
            // lblOrderNr
            // 
            lblOrderNr.AutoSize = true;
            lblOrderNr.Dock = DockStyle.Top;
            lblOrderNr.Font = new Font("Palatino Linotype", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderNr.ForeColor = Color.Gold;
            lblOrderNr.Location = new Point(0, 0);
            lblOrderNr.Margin = new Padding(4, 0, 4, 0);
            lblOrderNr.Name = "lblOrderNr";
            lblOrderNr.Size = new Size(0, 26);
            lblOrderNr.TabIndex = 0;
            // 
            // MätStatistik
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 45);
            ClientSize = new Size(1210, 576);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MätStatistik";
            Opacity = 0.25D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TestStatistik";
            TransparencyKey = Color.FromArgb(45, 45, 45);
            Deactivate += MätStatistik_Deactivate;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tlp_SPC.ResumeLayout(false);
            tlp_SPC.PerformLayout();
            ((ISupportInitialize)dgv_OrderList).EndInit();
            ((ISupportInitialize)chartData).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label lblOrderNr;
        private ComboBox cb_Mått;
        private Chart chartData;
        private CheckBox cB_visaAllaOrdrar;
        private DataGridView dgv_OrderList;
        private DataGridViewTextBoxColumn order;
        private Label lbl_HiLo;
        private Label label_HiLo;
        private Label lbl_Min;
        private Label label_Min;
        private Label lbl_Avg;
        private Label label_Avg;
        private Label lbl_Max;
        private Label label_Max;
        private TableLayoutPanel tlp_SPC;
        private Label label_Cp;
        private Label lbl_Cpk;
        private Label label_Cpk;
        private Label lbl_Cp;
        private Label lbl_USL;
        private Label label_USL;
        private Label lbl_LSL;
        private Label label_LSL;
    }
}