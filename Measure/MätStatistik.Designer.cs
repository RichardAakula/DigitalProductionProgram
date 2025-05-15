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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlp_SPC = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_LSL = new System.Windows.Forms.Label();
            this.label_LSL = new System.Windows.Forms.Label();
            this.lbl_USL = new System.Windows.Forms.Label();
            this.label_USL = new System.Windows.Forms.Label();
            this.lbl_Cpk = new System.Windows.Forms.Label();
            this.label_Cpk = new System.Windows.Forms.Label();
            this.lbl_Cp = new System.Windows.Forms.Label();
            this.label_Cp = new System.Windows.Forms.Label();
            this.label_Max = new System.Windows.Forms.Label();
            this.lbl_HiLo = new System.Windows.Forms.Label();
            this.label_Avg = new System.Windows.Forms.Label();
            this.lbl_Min = new System.Windows.Forms.Label();
            this.label_HiLo = new System.Windows.Forms.Label();
            this.lbl_Avg = new System.Windows.Forms.Label();
            this.label_Min = new System.Windows.Forms.Label();
            this.lbl_Max = new System.Windows.Forms.Label();
            this.dgv_OrderList = new System.Windows.Forms.DataGridView();
            this.order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cB_visaAllaOrdrar = new System.Windows.Forms.CheckBox();
            this.cb_Mått = new System.Windows.Forms.ComboBox();
            this.chartData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblOrderNr = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tlp_SPC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tlp_SPC);
            this.panel1.Controls.Add(this.dgv_OrderList);
            this.panel1.Controls.Add(this.cB_visaAllaOrdrar);
            this.panel1.Controls.Add(this.cb_Mått);
            this.panel1.Controls.Add(this.chartData);
            this.panel1.Controls.Add(this.lblOrderNr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 499);
            this.panel1.TabIndex = 0;
            // 
            // tlp_SPC
            // 
            this.tlp_SPC.ColumnCount = 2;
            this.tlp_SPC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.95238F));
            this.tlp_SPC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.04762F));
            this.tlp_SPC.Controls.Add(this.lbl_LSL, 1, 4);
            this.tlp_SPC.Controls.Add(this.label_LSL, 0, 4);
            this.tlp_SPC.Controls.Add(this.lbl_USL, 1, 0);
            this.tlp_SPC.Controls.Add(this.label_USL, 0, 0);
            this.tlp_SPC.Controls.Add(this.lbl_Cpk, 1, 8);
            this.tlp_SPC.Controls.Add(this.label_Cpk, 0, 8);
            this.tlp_SPC.Controls.Add(this.lbl_Cp, 1, 7);
            this.tlp_SPC.Controls.Add(this.label_Cp, 0, 7);
            this.tlp_SPC.Controls.Add(this.label_Max, 0, 1);
            this.tlp_SPC.Controls.Add(this.lbl_HiLo, 1, 5);
            this.tlp_SPC.Controls.Add(this.label_Avg, 0, 2);
            this.tlp_SPC.Controls.Add(this.lbl_Min, 1, 3);
            this.tlp_SPC.Controls.Add(this.label_HiLo, 0, 5);
            this.tlp_SPC.Controls.Add(this.lbl_Avg, 1, 2);
            this.tlp_SPC.Controls.Add(this.label_Min, 0, 3);
            this.tlp_SPC.Controls.Add(this.lbl_Max, 1, 1);
            this.tlp_SPC.Location = new System.Drawing.Point(918, 72);
            this.tlp_SPC.Name = "tlp_SPC";
            this.tlp_SPC.RowCount = 9;
            this.tlp_SPC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_SPC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_SPC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_SPC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_SPC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_SPC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_SPC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_SPC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_SPC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_SPC.Size = new System.Drawing.Size(105, 176);
            this.tlp_SPC.TabIndex = 5;
            // 
            // lbl_LSL
            // 
            this.lbl_LSL.AutoSize = true;
            this.lbl_LSL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_LSL.ForeColor = System.Drawing.Color.White;
            this.lbl_LSL.Location = new System.Drawing.Point(46, 80);
            this.lbl_LSL.Name = "lbl_LSL";
            this.lbl_LSL.Size = new System.Drawing.Size(56, 20);
            this.lbl_LSL.TabIndex = 12;
            this.lbl_LSL.Text = "0,000";
            this.lbl_LSL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_LSL
            // 
            this.label_LSL.AutoSize = true;
            this.label_LSL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LSL.ForeColor = System.Drawing.Color.Red;
            this.label_LSL.Location = new System.Drawing.Point(3, 80);
            this.label_LSL.Name = "label_LSL";
            this.label_LSL.Size = new System.Drawing.Size(37, 20);
            this.label_LSL.TabIndex = 11;
            this.label_LSL.Text = "LSL:";
            this.label_LSL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_USL
            // 
            this.lbl_USL.AutoSize = true;
            this.lbl_USL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_USL.ForeColor = System.Drawing.Color.White;
            this.lbl_USL.Location = new System.Drawing.Point(46, 0);
            this.lbl_USL.Name = "lbl_USL";
            this.lbl_USL.Size = new System.Drawing.Size(56, 20);
            this.lbl_USL.TabIndex = 10;
            this.lbl_USL.Text = "0,000";
            this.lbl_USL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_USL
            // 
            this.label_USL.AutoSize = true;
            this.label_USL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_USL.ForeColor = System.Drawing.Color.Red;
            this.label_USL.Location = new System.Drawing.Point(3, 0);
            this.label_USL.Name = "label_USL";
            this.label_USL.Size = new System.Drawing.Size(37, 20);
            this.label_USL.TabIndex = 9;
            this.label_USL.Text = "USL:";
            this.label_USL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Cpk
            // 
            this.lbl_Cpk.AutoSize = true;
            this.lbl_Cpk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Cpk.ForeColor = System.Drawing.Color.White;
            this.lbl_Cpk.Location = new System.Drawing.Point(46, 150);
            this.lbl_Cpk.Name = "lbl_Cpk";
            this.lbl_Cpk.Size = new System.Drawing.Size(56, 26);
            this.lbl_Cpk.TabIndex = 8;
            this.lbl_Cpk.Text = "0,000";
            this.lbl_Cpk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Cpk
            // 
            this.label_Cpk.AutoSize = true;
            this.label_Cpk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Cpk.ForeColor = System.Drawing.Color.Gold;
            this.label_Cpk.Location = new System.Drawing.Point(3, 150);
            this.label_Cpk.Name = "label_Cpk";
            this.label_Cpk.Size = new System.Drawing.Size(37, 26);
            this.label_Cpk.TabIndex = 7;
            this.label_Cpk.Text = "Cpk:";
            this.label_Cpk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Cp
            // 
            this.lbl_Cp.AutoSize = true;
            this.lbl_Cp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Cp.ForeColor = System.Drawing.Color.White;
            this.lbl_Cp.Location = new System.Drawing.Point(46, 135);
            this.lbl_Cp.Name = "lbl_Cp";
            this.lbl_Cp.Size = new System.Drawing.Size(56, 15);
            this.lbl_Cp.TabIndex = 6;
            this.lbl_Cp.Text = "0,000";
            this.lbl_Cp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Cp
            // 
            this.label_Cp.AutoSize = true;
            this.label_Cp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Cp.ForeColor = System.Drawing.Color.Gold;
            this.label_Cp.Location = new System.Drawing.Point(3, 135);
            this.label_Cp.Name = "label_Cp";
            this.label_Cp.Size = new System.Drawing.Size(37, 15);
            this.label_Cp.TabIndex = 5;
            this.label_Cp.Text = "Cp:";
            this.label_Cp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Max
            // 
            this.label_Max.AutoSize = true;
            this.label_Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Max.ForeColor = System.Drawing.Color.Gold;
            this.label_Max.Location = new System.Drawing.Point(3, 20);
            this.label_Max.Name = "label_Max";
            this.label_Max.Size = new System.Drawing.Size(37, 20);
            this.label_Max.TabIndex = 4;
            this.label_Max.Text = "Max:";
            this.label_Max.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_HiLo
            // 
            this.lbl_HiLo.AutoSize = true;
            this.lbl_HiLo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_HiLo.ForeColor = System.Drawing.Color.White;
            this.lbl_HiLo.Location = new System.Drawing.Point(46, 100);
            this.lbl_HiLo.Name = "lbl_HiLo";
            this.lbl_HiLo.Size = new System.Drawing.Size(56, 20);
            this.lbl_HiLo.TabIndex = 4;
            this.lbl_HiLo.Text = "0,000";
            this.lbl_HiLo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Avg
            // 
            this.label_Avg.AutoSize = true;
            this.label_Avg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Avg.ForeColor = System.Drawing.Color.Gold;
            this.label_Avg.Location = new System.Drawing.Point(3, 40);
            this.label_Avg.Name = "label_Avg";
            this.label_Avg.Size = new System.Drawing.Size(37, 20);
            this.label_Avg.TabIndex = 4;
            this.label_Avg.Text = "Avg:";
            this.label_Avg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Min
            // 
            this.lbl_Min.AutoSize = true;
            this.lbl_Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Min.ForeColor = System.Drawing.Color.White;
            this.lbl_Min.Location = new System.Drawing.Point(46, 60);
            this.lbl_Min.Name = "lbl_Min";
            this.lbl_Min.Size = new System.Drawing.Size(56, 20);
            this.lbl_Min.TabIndex = 4;
            this.lbl_Min.Text = "0,000";
            this.lbl_Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_HiLo
            // 
            this.label_HiLo.AutoSize = true;
            this.label_HiLo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_HiLo.ForeColor = System.Drawing.Color.Gold;
            this.label_HiLo.Location = new System.Drawing.Point(3, 100);
            this.label_HiLo.Name = "label_HiLo";
            this.label_HiLo.Size = new System.Drawing.Size(37, 20);
            this.label_HiLo.TabIndex = 4;
            this.label_HiLo.Text = "HiLo:";
            this.label_HiLo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Avg
            // 
            this.lbl_Avg.AutoSize = true;
            this.lbl_Avg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Avg.ForeColor = System.Drawing.Color.White;
            this.lbl_Avg.Location = new System.Drawing.Point(46, 40);
            this.lbl_Avg.Name = "lbl_Avg";
            this.lbl_Avg.Size = new System.Drawing.Size(56, 20);
            this.lbl_Avg.TabIndex = 4;
            this.lbl_Avg.Text = "0,000";
            this.lbl_Avg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Min
            // 
            this.label_Min.AutoSize = true;
            this.label_Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Min.ForeColor = System.Drawing.Color.Gold;
            this.label_Min.Location = new System.Drawing.Point(3, 60);
            this.label_Min.Name = "label_Min";
            this.label_Min.Size = new System.Drawing.Size(37, 20);
            this.label_Min.TabIndex = 4;
            this.label_Min.Text = "Min:";
            this.label_Min.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Max
            // 
            this.lbl_Max.AutoSize = true;
            this.lbl_Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Max.ForeColor = System.Drawing.Color.White;
            this.lbl_Max.Location = new System.Drawing.Point(46, 20);
            this.lbl_Max.Name = "lbl_Max";
            this.lbl_Max.Size = new System.Drawing.Size(56, 20);
            this.lbl_Max.TabIndex = 4;
            this.lbl_Max.Text = "0,000";
            this.lbl_Max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_OrderList
            // 
            this.dgv_OrderList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.dgv_OrderList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_OrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_OrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order});
            this.dgv_OrderList.Location = new System.Drawing.Point(833, 72);
            this.dgv_OrderList.Name = "dgv_OrderList";
            this.dgv_OrderList.RowHeadersVisible = false;
            this.dgv_OrderList.Size = new System.Drawing.Size(79, 257);
            this.dgv_OrderList.TabIndex = 3;
            this.dgv_OrderList.Visible = false;
            this.dgv_OrderList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Data_CellContentClick);
            // 
            // order
            // 
            this.order.HeaderText = "OrderNr";
            this.order.Name = "order";
            this.order.Width = 70;
            // 
            // cB_visaAllaOrdrar
            // 
            this.cB_visaAllaOrdrar.AutoSize = true;
            this.cB_visaAllaOrdrar.ForeColor = System.Drawing.Color.White;
            this.cB_visaAllaOrdrar.Location = new System.Drawing.Point(838, 49);
            this.cB_visaAllaOrdrar.Name = "cB_visaAllaOrdrar";
            this.cB_visaAllaOrdrar.Size = new System.Drawing.Size(185, 17);
            this.cB_visaAllaOrdrar.TabIndex = 1;
            this.cB_visaAllaOrdrar.Text = "Visa alla ordrar med detta artikelnr";
            this.cB_visaAllaOrdrar.UseVisualStyleBackColor = true;
            this.cB_visaAllaOrdrar.Visible = false;
            this.cB_visaAllaOrdrar.CheckedChanged += new System.EventHandler(this.Mått_SelectedIndexChanged);
            // 
            // cb_Mått
            // 
            this.cb_Mått.FormattingEnabled = true;
            this.cb_Mått.Location = new System.Drawing.Point(838, 10);
            this.cb_Mått.Name = "cb_Mått";
            this.cb_Mått.Size = new System.Drawing.Size(139, 21);
            this.cb_Mått.TabIndex = 2;
            this.cb_Mått.Visible = false;
            this.cb_Mått.SelectedIndexChanged += new System.EventHandler(this.Mått_SelectedIndexChanged);
            // 
            // chartData
            // 
            this.chartData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartData.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            legend1.TitleForeColor = System.Drawing.Color.White;
            this.chartData.Legends.Add(legend1);
            this.chartData.Location = new System.Drawing.Point(6, 35);
            this.chartData.Name = "chartData";
            this.chartData.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series1.BorderColor = System.Drawing.Color.Red;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Green;
            series1.LabelBackColor = System.Drawing.Color.Black;
            series1.LabelBorderColor = System.Drawing.Color.Transparent;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.White;
            series1.Name = "Value";
            series1.YValuesPerPoint = 6;
            this.chartData.Series.Add(series1);
            this.chartData.Size = new System.Drawing.Size(823, 450);
            this.chartData.TabIndex = 1;
            this.chartData.Text = "chart1";
            title1.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.Orange;
            title1.Name = "Title1";
            title1.Text = "Blåst ID";
            this.chartData.Titles.Add(title1);
            this.chartData.Visible = false;
            this.chartData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart_Data_MouseMove);
            // 
            // lblOrderNr
            // 
            this.lblOrderNr.AutoSize = true;
            this.lblOrderNr.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOrderNr.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNr.ForeColor = System.Drawing.Color.Gold;
            this.lblOrderNr.Location = new System.Drawing.Point(0, 0);
            this.lblOrderNr.Name = "lblOrderNr";
            this.lblOrderNr.Size = new System.Drawing.Size(0, 26);
            this.lblOrderNr.TabIndex = 0;
            // 
            // MätStatistik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1037, 499);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MätStatistik";
            this.Opacity = 0.25D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestStatistik";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Deactivate += new System.EventHandler(this.MätStatistik_Deactivate);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tlp_SPC.ResumeLayout(false);
            this.tlp_SPC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).EndInit();
            this.ResumeLayout(false);

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