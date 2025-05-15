using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace DigitalProductionProgram.Statistics
{
    partial class Statistik_Övrigt
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine2 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer_Change_Chart = new System.Windows.Forms.Timer(this.components);
            this.btn_Next = new System.Windows.Forms.Button();
            this.lbl_Chart_Index = new System.Windows.Forms.Label();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.flp_Main = new System.Windows.Forms.FlowLayoutPanel();
            this.dgv_List_Statistik = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.tlp_Main.SuspendLayout();
            this.flp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List_Statistik)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.chart.BorderlineColor = System.Drawing.Color.Transparent;
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea1.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.Aqua;
            stripLine1.BorderColor = System.Drawing.Color.Red;
            stripLine1.BorderWidth = 2;
            stripLine1.Text = "slMax";
            stripLine2.BorderColor = System.Drawing.Color.Red;
            stripLine2.BorderWidth = 2;
            stripLine2.Text = "slMin";
            chartArea1.AxisX.StripLines.Add(stripLine1);
            chartArea1.AxisX.StripLines.Add(stripLine2);
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.Goldenrod;
            chartArea1.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.Goldenrod;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            legend1.ForeColor = System.Drawing.Color.Gainsboro;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall;
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(573, 35);
            this.chart.Margin = new System.Windows.Forms.Padding(0);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.RoyalBlue;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(123)))), ((int)(((byte)(71)))));
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(218)))));
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(191)))), ((int)(((byte)(143)))));
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Series4";
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.Maroon;
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "Series5";
            series6.ChartArea = "ChartArea1";
            series6.Color = System.Drawing.Color.Khaki;
            series6.IsVisibleInLegend = false;
            series6.Legend = "Legend1";
            series6.Name = "Series6";
            series7.ChartArea = "ChartArea1";
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(180)))), ((int)(((byte)(226)))));
            series7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            series7.IsVisibleInLegend = false;
            series7.Legend = "Legend1";
            series7.Name = "Series7";
            series7.YValuesPerPoint = 4;
            series8.ChartArea = "ChartArea1";
            series8.IsVisibleInLegend = false;
            series8.Legend = "Legend1";
            series8.Name = "Series8";
            series9.ChartArea = "ChartArea1";
            series9.IsVisibleInLegend = false;
            series9.Legend = "Legend1";
            series9.Name = "Series9";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Series.Add(series5);
            this.chart.Series.Add(series6);
            this.chart.Series.Add(series7);
            this.chart.Series.Add(series8);
            this.chart.Series.Add(series9);
            this.chart.Size = new System.Drawing.Size(1010, 653);
            this.chart.TabIndex = 856;
            title1.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.Gold;
            title1.Name = "Title1";
            title1.Text = "Chart";
            this.chart.Titles.Add(title1);
            this.chart.Click += new System.EventHandler(this.Chart_Click);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart_MouseMove);
            // 
            // timer_Change_Chart
            // 
            this.timer_Change_Chart.Interval = 10000;
            this.timer_Change_Chart.Tick += new System.EventHandler(this.Timer_Change_Chart_Tick);
            // 
            // btn_Next
            // 
            this.btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Next.Location = new System.Drawing.Point(84, 3);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 23);
            this.btn_Next.TabIndex = 857;
            this.btn_Next.Text = "Nästa";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // lbl_Chart_Index
            // 
            this.lbl_Chart_Index.AutoSize = true;
            this.lbl_Chart_Index.Location = new System.Drawing.Point(165, 8);
            this.lbl_Chart_Index.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lbl_Chart_Index.Name = "lbl_Chart_Index";
            this.lbl_Chart_Index.Size = new System.Drawing.Size(31, 13);
            this.lbl_Chart_Index.TabIndex = 858;
            this.lbl_Chart_Index.Text = "1 av ";
            // 
            // btn_Previous
            // 
            this.btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Previous.Location = new System.Drawing.Point(3, 3);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(75, 23);
            this.btn_Previous.TabIndex = 857;
            this.btn_Previous.Text = "Föregående";
            this.btn_Previous.UseVisualStyleBackColor = true;
            this.btn_Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 573F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlp_Main.Controls.Add(this.flp_Main, 0, 0);
            this.tlp_Main.Controls.Add(this.chart, 1, 1);
            this.tlp_Main.Controls.Add(this.dgv_List_Statistik, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.232558F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.76744F));
            this.tlp_Main.Size = new System.Drawing.Size(1583, 688);
            this.tlp_Main.TabIndex = 859;
            // 
            // flp_Main
            // 
            this.flp_Main.BackColor = System.Drawing.SystemColors.Control;
            this.tlp_Main.SetColumnSpan(this.flp_Main, 2);
            this.flp_Main.Controls.Add(this.btn_Previous);
            this.flp_Main.Controls.Add(this.btn_Next);
            this.flp_Main.Controls.Add(this.lbl_Chart_Index);
            this.flp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Main.Location = new System.Drawing.Point(0, 0);
            this.flp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.flp_Main.Name = "flp_Main";
            this.flp_Main.Size = new System.Drawing.Size(1583, 35);
            this.flp_Main.TabIndex = 0;
            this.flp_Main.Click += new System.EventHandler(this.Chart_Click);
            // 
            // dgv_List_Statistik
            // 
            this.dgv_List_Statistik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_List_Statistik.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_List_Statistik.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_List_Statistik.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_List_Statistik.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_List_Statistik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_List_Statistik.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_List_Statistik.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_List_Statistik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_List_Statistik.Location = new System.Drawing.Point(5, 35);
            this.dgv_List_Statistik.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dgv_List_Statistik.MultiSelect = false;
            this.dgv_List_Statistik.Name = "dgv_List_Statistik";
            this.dgv_List_Statistik.RowHeadersVisible = false;
            this.dgv_List_Statistik.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_List_Statistik.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_List_Statistik.Size = new System.Drawing.Size(568, 653);
            this.dgv_List_Statistik.TabIndex = 857;
            this.dgv_List_Statistik.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_List_Statistik_RowEnter);
            // 
            // Statistik_Övrigt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 688);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Statistik_Övrigt";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.tlp_Main.ResumeLayout(false);
            this.flp_Main.ResumeLayout(false);
            this.flp_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List_Statistik)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Chart chart;
        private System.Windows.Forms.Timer timer_Change_Chart;
        private Button btn_Next;
        private Label lbl_Chart_Index;
        private Button btn_Previous;
        private TableLayoutPanel tlp_Main;
        private FlowLayoutPanel flp_Main;
        private DataGridView dgv_List_Statistik;
    }
}