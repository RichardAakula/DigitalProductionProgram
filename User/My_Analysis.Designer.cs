using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DigitalProductionProgram.User
{
    partial class My_Analysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(My_Analysis));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Parts = new System.Windows.Forms.Panel();
            this.label_Artiklar = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_Parts = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_Info_Parts = new System.Windows.Forms.Label();
            this.panel_Processkort = new System.Windows.Forms.Panel();
            this.label_Processkort = new System.Windows.Forms.Label();
            this.pb_Processkort = new System.Windows.Forms.PictureBox();
            this.chart_Skapade_Processkort = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_Processkort_Info = new System.Windows.Forms.Label();
            this.label_Info_Processcard = new System.Windows.Forms.Label();
            this.panel_Produktionslinjer = new System.Windows.Forms.Panel();
            this.label_ProdLines = new System.Windows.Forms.Label();
            this.pb_ProdLines = new System.Windows.Forms.PictureBox();
            this.label_Linje_Aktivitet_Extra_Info = new System.Windows.Forms.Label();
            this.chart_Linjer_Aktivitet = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_Info_ProdLines = new System.Windows.Forms.Label();
            this.panel_Samarbete = new System.Windows.Forms.Panel();
            this.label_Samarbete_Rubrik = new System.Windows.Forms.Label();
            this.pb_Medarbetare = new System.Windows.Forms.PictureBox();
            this.chart_Samarbete = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_Samarbete_Info = new System.Windows.Forms.Label();
            this.panel_Starta_Ordrar = new System.Windows.Forms.Panel();
            this.pb_Körda_Ordrar = new System.Windows.Forms.PictureBox();
            this.chart_Antal_Mätningar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pb_Startade_Ordrar = new System.Windows.Forms.PictureBox();
            this.pb_Antal_Mätningar = new System.Windows.Forms.PictureBox();
            this.chart_Körda_Ordrar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_Ordrar_Rubrik = new System.Windows.Forms.Label();
            this.label_AntalMätningar_Info = new System.Windows.Forms.Label();
            this.label_KördaOrdrar_Info = new System.Windows.Forms.Label();
            this.label_AntalMätningar_Rubrik = new System.Windows.Forms.Label();
            this.chart_Startade_Ordrar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_KördaOrdrar_Rubrik = new System.Windows.Forms.Label();
            this.label_AntalStartadeOrdrar_Info = new System.Windows.Forms.Label();
            this.label_AntalStartadeOrdrar_Rubrik = new System.Windows.Forms.Label();
            this.panel_Rubrik = new System.Windows.Forms.Panel();
            this.tb_User = new System.Windows.Forms.TextBox();
            this.lbl_Close = new System.Windows.Forms.Label();
            this.lbl_Initialer = new System.Windows.Forms.Label();
            this.label_Header_Aktivitet_Rubrik = new System.Windows.Forms.Label();
            this.chart_Rubrik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_Header_Info = new System.Windows.Forms.Label();
            this.label_Header_Rubrikt = new System.Windows.Forms.Label();
            this.timer_AutoScroll = new System.Windows.Forms.Timer(this.components);
            this.timer_Start_timer_AutoScroll = new System.Windows.Forms.Timer(this.components);
            this.tlp_Main.SuspendLayout();
            this.panel_Parts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Parts)).BeginInit();
            this.panel_Processkort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Processkort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Skapade_Processkort)).BeginInit();
            this.panel_Produktionslinjer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ProdLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Linjer_Aktivitet)).BeginInit();
            this.panel_Samarbete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Medarbetare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Samarbete)).BeginInit();
            this.panel_Starta_Ordrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Körda_Ordrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Antal_Mätningar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Startade_Ordrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Antal_Mätningar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Körda_Ordrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Startade_Ordrar)).BeginInit();
            this.panel_Rubrik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Rubrik)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.AutoScroll = true;
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.panel_Parts, 0, 5);
            this.tlp_Main.Controls.Add(this.panel_Processkort, 0, 4);
            this.tlp_Main.Controls.Add(this.panel_Produktionslinjer, 0, 3);
            this.tlp_Main.Controls.Add(this.panel_Samarbete, 0, 2);
            this.tlp_Main.Controls.Add(this.panel_Starta_Ordrar, 0, 1);
            this.tlp_Main.Controls.Add(this.panel_Rubrik, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 6;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 560F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 223F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tlp_Main.Size = new System.Drawing.Size(764, 859);
            this.tlp_Main.TabIndex = 0;
            this.tlp_Main.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tlp_Main_Scroll);
            // 
            // panel_Parts
            // 
            this.panel_Parts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Parts.Controls.Add(this.label_Artiklar);
            this.panel_Parts.Controls.Add(this.pictureBox4);
            this.panel_Parts.Controls.Add(this.label3);
            this.panel_Parts.Controls.Add(this.chart_Parts);
            this.panel_Parts.Controls.Add(this.label_Info_Parts);
            this.panel_Parts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Parts.Location = new System.Drawing.Point(3, 1486);
            this.panel_Parts.Name = "panel_Parts";
            this.panel_Parts.Size = new System.Drawing.Size(758, 504);
            this.panel_Parts.TabIndex = 8;
            // 
            // label_Artiklar
            // 
            this.label_Artiklar.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Artiklar.Font = new System.Drawing.Font("Javanese Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Artiklar.ForeColor = System.Drawing.Color.LimeGreen;
            this.label_Artiklar.Location = new System.Drawing.Point(0, 0);
            this.label_Artiklar.Name = "label_Artiklar";
            this.label_Artiklar.Size = new System.Drawing.Size(756, 35);
            this.label_Artiklar.TabIndex = 5;
            this.label_Artiklar.Text = "Artiklar";
            this.label_Artiklar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(15, 44);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 40);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 7.75F);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(0, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 66);
            this.label3.TabIndex = 2;
            this.label3.Text = "Artiklar som du kört baserar sig på ordrar som du startat samt gjort LineClearanc" +
    "e på.\r\n.";
            // 
            // chart_Parts
            // 
            this.chart_Parts.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Teal;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart_Parts.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.ForeColor = System.Drawing.Color.Gainsboro;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.chart_Parts.Legends.Add(legend1);
            this.chart_Parts.Location = new System.Drawing.Point(301, 44);
            this.chart_Parts.Name = "chart_Parts";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_Parts.Series.Add(series1);
            this.chart_Parts.Size = new System.Drawing.Size(419, 192);
            this.chart_Parts.TabIndex = 1;
            this.chart_Parts.Text = "chart1";
            // 
            // label_Info_Parts
            // 
            this.label_Info_Parts.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Info_Parts.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Info_Parts.Location = new System.Drawing.Point(60, 42);
            this.label_Info_Parts.Name = "label_Info_Parts";
            this.label_Info_Parts.Size = new System.Drawing.Size(154, 75);
            this.label_Info_Parts.TabIndex = 0;
            this.label_Info_Parts.Text = "Top 10 Artiklar du kört på Optinova";
            // 
            // panel_Processkort
            // 
            this.panel_Processkort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Processkort.Controls.Add(this.label_Processkort);
            this.panel_Processkort.Controls.Add(this.pb_Processkort);
            this.panel_Processkort.Controls.Add(this.chart_Skapade_Processkort);
            this.panel_Processkort.Controls.Add(this.label_Processkort_Info);
            this.panel_Processkort.Controls.Add(this.label_Info_Processcard);
            this.panel_Processkort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Processkort.Location = new System.Drawing.Point(3, 1263);
            this.panel_Processkort.Name = "panel_Processkort";
            this.panel_Processkort.Size = new System.Drawing.Size(758, 217);
            this.panel_Processkort.TabIndex = 6;
            // 
            // label_Processkort
            // 
            this.label_Processkort.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Processkort.Font = new System.Drawing.Font("Javanese Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Processkort.ForeColor = System.Drawing.Color.LimeGreen;
            this.label_Processkort.Location = new System.Drawing.Point(0, 0);
            this.label_Processkort.Name = "label_Processkort";
            this.label_Processkort.Size = new System.Drawing.Size(756, 35);
            this.label_Processkort.TabIndex = 6;
            this.label_Processkort.Text = "Processkort";
            this.label_Processkort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_Processkort
            // 
            this.pb_Processkort.BackgroundImage = global::DigitalProductionProgram.Properties.Resources.ProcessCard;
            this.pb_Processkort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Processkort.Location = new System.Drawing.Point(15, 48);
            this.pb_Processkort.Name = "pb_Processkort";
            this.pb_Processkort.Size = new System.Drawing.Size(40, 40);
            this.pb_Processkort.TabIndex = 5;
            this.pb_Processkort.TabStop = false;
            // 
            // chart_Skapade_Processkort
            // 
            this.chart_Skapade_Processkort.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Teal;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chart_Skapade_Processkort.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.ForeColor = System.Drawing.Color.Gainsboro;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.Name = "Legend1";
            legend2.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.chart_Skapade_Processkort.Legends.Add(legend2);
            this.chart_Skapade_Processkort.Location = new System.Drawing.Point(330, 60);
            this.chart_Skapade_Processkort.Name = "chart_Skapade_Processkort";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.SeaGreen;
            series2.Legend = "Legend1";
            series2.Name = "Två månader sedan";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Transparent;
            series3.Legend = "Legend1";
            series3.Name = "-";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.DodgerBlue;
            series4.Legend = "Legend1";
            series4.Name = "Förra månaden";
            this.chart_Skapade_Processkort.Series.Add(series2);
            this.chart_Skapade_Processkort.Series.Add(series3);
            this.chart_Skapade_Processkort.Series.Add(series4);
            this.chart_Skapade_Processkort.Size = new System.Drawing.Size(389, 152);
            this.chart_Skapade_Processkort.TabIndex = 1;
            this.chart_Skapade_Processkort.Text = "chart1";
            // 
            // label_Processkort_Info
            // 
            this.label_Processkort_Info.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Processkort_Info.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label_Processkort_Info.Location = new System.Drawing.Point(28, 122);
            this.label_Processkort_Info.Name = "label_Processkort_Info";
            this.label_Processkort_Info.Size = new System.Drawing.Size(250, 50);
            this.label_Processkort_Info.TabIndex = 0;
            this.label_Processkort_Info.Text = "En ökning på %";
            // 
            // label_Info_Processcard
            // 
            this.label_Info_Processcard.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Info_Processcard.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Info_Processcard.Location = new System.Drawing.Point(60, 53);
            this.label_Info_Processcard.Name = "label_Info_Processcard";
            this.label_Info_Processcard.Size = new System.Drawing.Size(225, 56);
            this.label_Info_Processcard.TabIndex = 0;
            this.label_Info_Processcard.Text = "Antal skapade Processkort du har gjort denna månad.";
            // 
            // panel_Produktionslinjer
            // 
            this.panel_Produktionslinjer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Produktionslinjer.Controls.Add(this.label_ProdLines);
            this.panel_Produktionslinjer.Controls.Add(this.pb_ProdLines);
            this.panel_Produktionslinjer.Controls.Add(this.label_Linje_Aktivitet_Extra_Info);
            this.panel_Produktionslinjer.Controls.Add(this.chart_Linjer_Aktivitet);
            this.panel_Produktionslinjer.Controls.Add(this.label_Info_ProdLines);
            this.panel_Produktionslinjer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Produktionslinjer.Location = new System.Drawing.Point(3, 1013);
            this.panel_Produktionslinjer.Name = "panel_Produktionslinjer";
            this.panel_Produktionslinjer.Size = new System.Drawing.Size(758, 244);
            this.panel_Produktionslinjer.TabIndex = 5;
            // 
            // label_ProdLines
            // 
            this.label_ProdLines.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_ProdLines.Font = new System.Drawing.Font("Javanese Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProdLines.ForeColor = System.Drawing.Color.LimeGreen;
            this.label_ProdLines.Location = new System.Drawing.Point(0, 0);
            this.label_ProdLines.Name = "label_ProdLines";
            this.label_ProdLines.Size = new System.Drawing.Size(756, 35);
            this.label_ProdLines.TabIndex = 5;
            this.label_ProdLines.Text = "Produktionslinjer";
            this.label_ProdLines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_ProdLines
            // 
            this.pb_ProdLines.BackgroundImage = global::DigitalProductionProgram.Properties.Resources.Extrusion;
            this.pb_ProdLines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_ProdLines.Location = new System.Drawing.Point(15, 44);
            this.pb_ProdLines.Name = "pb_ProdLines";
            this.pb_ProdLines.Size = new System.Drawing.Size(40, 40);
            this.pb_ProdLines.TabIndex = 4;
            this.pb_ProdLines.TabStop = false;
            // 
            // label_Linje_Aktivitet_Extra_Info
            // 
            this.label_Linje_Aktivitet_Extra_Info.Font = new System.Drawing.Font("Arial", 7.75F);
            this.label_Linje_Aktivitet_Extra_Info.ForeColor = System.Drawing.Color.DimGray;
            this.label_Linje_Aktivitet_Extra_Info.Location = new System.Drawing.Point(0, 127);
            this.label_Linje_Aktivitet_Extra_Info.Name = "label_Linje_Aktivitet_Extra_Info";
            this.label_Linje_Aktivitet_Extra_Info.Size = new System.Drawing.Size(295, 66);
            this.label_Linje_Aktivitet_Extra_Info.TabIndex = 2;
            this.label_Linje_Aktivitet_Extra_Info.Text = "Denna data är baserad på hur många mätningar du gjort på \r\ndom ordrar du varit in" +
    "volverad i.\r\nTiden kan diffa endel pga att programmet ej tar hänsyn till helger " +
    "och rengöringstider mitt i ordrar.";
            // 
            // chart_Linjer_Aktivitet
            // 
            this.chart_Linjer_Aktivitet.BackColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.LineColor = System.Drawing.Color.Teal;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chart_Linjer_Aktivitet.ChartAreas.Add(chartArea3);
            legend3.Alignment = System.Drawing.StringAlignment.Center;
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.ForeColor = System.Drawing.Color.Gainsboro;
            legend3.Name = "Legend1";
            legend3.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.chart_Linjer_Aktivitet.Legends.Add(legend3);
            this.chart_Linjer_Aktivitet.Location = new System.Drawing.Point(301, 44);
            this.chart_Linjer_Aktivitet.Name = "chart_Linjer_Aktivitet";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart_Linjer_Aktivitet.Series.Add(series5);
            this.chart_Linjer_Aktivitet.Size = new System.Drawing.Size(419, 192);
            this.chart_Linjer_Aktivitet.TabIndex = 1;
            this.chart_Linjer_Aktivitet.Text = "chart1";
            // 
            // label_Info_ProdLines
            // 
            this.label_Info_ProdLines.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Info_ProdLines.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Info_ProdLines.Location = new System.Drawing.Point(60, 42);
            this.label_Info_ProdLines.Name = "label_Info_ProdLines";
            this.label_Info_ProdLines.Size = new System.Drawing.Size(154, 75);
            this.label_Info_ProdLines.TabIndex = 0;
            this.label_Info_ProdLines.Text = "Produktionslinjer som du har spenderat tid vid senaste månaden";
            // 
            // panel_Samarbete
            // 
            this.panel_Samarbete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Samarbete.Controls.Add(this.label_Samarbete_Rubrik);
            this.panel_Samarbete.Controls.Add(this.pb_Medarbetare);
            this.panel_Samarbete.Controls.Add(this.chart_Samarbete);
            this.panel_Samarbete.Controls.Add(this.label_Samarbete_Info);
            this.panel_Samarbete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Samarbete.Location = new System.Drawing.Point(3, 763);
            this.panel_Samarbete.Name = "panel_Samarbete";
            this.panel_Samarbete.Size = new System.Drawing.Size(758, 244);
            this.panel_Samarbete.TabIndex = 4;
            // 
            // label_Samarbete_Rubrik
            // 
            this.label_Samarbete_Rubrik.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Samarbete_Rubrik.Font = new System.Drawing.Font("Javanese Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Samarbete_Rubrik.ForeColor = System.Drawing.Color.LimeGreen;
            this.label_Samarbete_Rubrik.Location = new System.Drawing.Point(0, 0);
            this.label_Samarbete_Rubrik.Name = "label_Samarbete_Rubrik";
            this.label_Samarbete_Rubrik.Size = new System.Drawing.Size(756, 35);
            this.label_Samarbete_Rubrik.TabIndex = 4;
            this.label_Samarbete_Rubrik.Text = "Samarbete";
            this.label_Samarbete_Rubrik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_Medarbetare
            // 
            this.pb_Medarbetare.BackgroundImage = global::DigitalProductionProgram.Properties.Resources.Medarebetare;
            this.pb_Medarbetare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Medarbetare.Location = new System.Drawing.Point(15, 79);
            this.pb_Medarbetare.Name = "pb_Medarbetare";
            this.pb_Medarbetare.Size = new System.Drawing.Size(40, 40);
            this.pb_Medarbetare.TabIndex = 3;
            this.pb_Medarbetare.TabStop = false;
            // 
            // chart_Samarbete
            // 
            this.chart_Samarbete.BackColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea4.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX.LineColor = System.Drawing.Color.Teal;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro;
            chartArea4.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea4.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea1";
            this.chart_Samarbete.ChartAreas.Add(chartArea4);
            legend4.Alignment = System.Drawing.StringAlignment.Center;
            legend4.BackColor = System.Drawing.Color.Transparent;
            legend4.ForeColor = System.Drawing.Color.Gainsboro;
            legend4.Name = "Legend1";
            legend4.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.chart_Samarbete.Legends.Add(legend4);
            this.chart_Samarbete.Location = new System.Drawing.Point(215, 42);
            this.chart_Samarbete.Name = "chart_Samarbete";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart_Samarbete.Series.Add(series6);
            this.chart_Samarbete.Size = new System.Drawing.Size(505, 192);
            this.chart_Samarbete.TabIndex = 1;
            this.chart_Samarbete.Text = "chart1";
            // 
            // label_Samarbete_Info
            // 
            this.label_Samarbete_Info.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Samarbete_Info.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Samarbete_Info.Location = new System.Drawing.Point(60, 75);
            this.label_Samarbete_Info.Name = "label_Samarbete_Info";
            this.label_Samarbete_Info.Size = new System.Drawing.Size(154, 62);
            this.label_Samarbete_Info.TabIndex = 0;
            this.label_Samarbete_Info.Text = "Medarbetare du har samkört ordrar med senaste månaden";
            // 
            // panel_Starta_Ordrar
            // 
            this.panel_Starta_Ordrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Starta_Ordrar.Controls.Add(this.pb_Körda_Ordrar);
            this.panel_Starta_Ordrar.Controls.Add(this.chart_Antal_Mätningar);
            this.panel_Starta_Ordrar.Controls.Add(this.pb_Startade_Ordrar);
            this.panel_Starta_Ordrar.Controls.Add(this.pb_Antal_Mätningar);
            this.panel_Starta_Ordrar.Controls.Add(this.chart_Körda_Ordrar);
            this.panel_Starta_Ordrar.Controls.Add(this.label_Ordrar_Rubrik);
            this.panel_Starta_Ordrar.Controls.Add(this.label_AntalMätningar_Info);
            this.panel_Starta_Ordrar.Controls.Add(this.label_KördaOrdrar_Info);
            this.panel_Starta_Ordrar.Controls.Add(this.label_AntalMätningar_Rubrik);
            this.panel_Starta_Ordrar.Controls.Add(this.chart_Startade_Ordrar);
            this.panel_Starta_Ordrar.Controls.Add(this.label_KördaOrdrar_Rubrik);
            this.panel_Starta_Ordrar.Controls.Add(this.label_AntalStartadeOrdrar_Info);
            this.panel_Starta_Ordrar.Controls.Add(this.label_AntalStartadeOrdrar_Rubrik);
            this.panel_Starta_Ordrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Starta_Ordrar.Location = new System.Drawing.Point(3, 203);
            this.panel_Starta_Ordrar.Name = "panel_Starta_Ordrar";
            this.panel_Starta_Ordrar.Size = new System.Drawing.Size(758, 554);
            this.panel_Starta_Ordrar.TabIndex = 0;
            // 
            // pb_Körda_Ordrar
            // 
            this.pb_Körda_Ordrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Körda_Ordrar.BackgroundImage")));
            this.pb_Körda_Ordrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Körda_Ordrar.Location = new System.Drawing.Point(15, 230);
            this.pb_Körda_Ordrar.Name = "pb_Körda_Ordrar";
            this.pb_Körda_Ordrar.Size = new System.Drawing.Size(40, 40);
            this.pb_Körda_Ordrar.TabIndex = 3;
            this.pb_Körda_Ordrar.TabStop = false;
            // 
            // chart_Antal_Mätningar
            // 
            this.chart_Antal_Mätningar.BackColor = System.Drawing.Color.Transparent;
            chartArea5.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea5.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea5.AxisX.LineColor = System.Drawing.Color.Teal;
            chartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea5.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro;
            chartArea5.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea5.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea5.BackColor = System.Drawing.Color.Transparent;
            chartArea5.Name = "ChartArea1";
            this.chart_Antal_Mätningar.ChartAreas.Add(chartArea5);
            legend5.Alignment = System.Drawing.StringAlignment.Center;
            legend5.BackColor = System.Drawing.Color.Transparent;
            legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend5.ForeColor = System.Drawing.Color.Gainsboro;
            legend5.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend5.Name = "Legend1";
            legend5.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.chart_Antal_Mätningar.Legends.Add(legend5);
            this.chart_Antal_Mätningar.Location = new System.Drawing.Point(300, 390);
            this.chart_Antal_Mätningar.Name = "chart_Antal_Mätningar";
            series7.ChartArea = "ChartArea1";
            series7.Color = System.Drawing.Color.SeaGreen;
            series7.Legend = "Legend1";
            series7.Name = "Två månader sedan";
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.Transparent;
            series8.Legend = "Legend1";
            series8.Name = "-";
            series9.ChartArea = "ChartArea1";
            series9.Color = System.Drawing.Color.DodgerBlue;
            series9.Legend = "Legend1";
            series9.Name = "Förra månaden";
            this.chart_Antal_Mätningar.Series.Add(series7);
            this.chart_Antal_Mätningar.Series.Add(series8);
            this.chart_Antal_Mätningar.Series.Add(series9);
            this.chart_Antal_Mätningar.Size = new System.Drawing.Size(420, 155);
            this.chart_Antal_Mätningar.TabIndex = 1;
            this.chart_Antal_Mätningar.Text = "chart1";
            // 
            // pb_Startade_Ordrar
            // 
            this.pb_Startade_Ordrar.BackgroundImage = global::DigitalProductionProgram.Properties.Resources.Start;
            this.pb_Startade_Ordrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Startade_Ordrar.Location = new System.Drawing.Point(15, 60);
            this.pb_Startade_Ordrar.Name = "pb_Startade_Ordrar";
            this.pb_Startade_Ordrar.Size = new System.Drawing.Size(40, 40);
            this.pb_Startade_Ordrar.TabIndex = 2;
            this.pb_Startade_Ordrar.TabStop = false;
            // 
            // pb_Antal_Mätningar
            // 
            this.pb_Antal_Mätningar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Antal_Mätningar.BackgroundImage")));
            this.pb_Antal_Mätningar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Antal_Mätningar.Location = new System.Drawing.Point(15, 400);
            this.pb_Antal_Mätningar.Name = "pb_Antal_Mätningar";
            this.pb_Antal_Mätningar.Size = new System.Drawing.Size(40, 40);
            this.pb_Antal_Mätningar.TabIndex = 2;
            this.pb_Antal_Mätningar.TabStop = false;
            // 
            // chart_Körda_Ordrar
            // 
            this.chart_Körda_Ordrar.BackColor = System.Drawing.Color.Transparent;
            chartArea6.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea6.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea6.AxisX.LineColor = System.Drawing.Color.Teal;
            chartArea6.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea6.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro;
            chartArea6.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea6.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea6.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea6.BackColor = System.Drawing.Color.Transparent;
            chartArea6.Name = "ChartArea1";
            this.chart_Körda_Ordrar.ChartAreas.Add(chartArea6);
            legend6.Alignment = System.Drawing.StringAlignment.Center;
            legend6.BackColor = System.Drawing.Color.Transparent;
            legend6.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend6.ForeColor = System.Drawing.Color.Gainsboro;
            legend6.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend6.Name = "Legend1";
            legend6.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.chart_Körda_Ordrar.Legends.Add(legend6);
            this.chart_Körda_Ordrar.Location = new System.Drawing.Point(300, 220);
            this.chart_Körda_Ordrar.Name = "chart_Körda_Ordrar";
            series10.ChartArea = "ChartArea1";
            series10.Color = System.Drawing.Color.SeaGreen;
            series10.Legend = "Legend1";
            series10.Name = "Två månader sedan";
            series11.ChartArea = "ChartArea1";
            series11.Color = System.Drawing.Color.Transparent;
            series11.Legend = "Legend1";
            series11.Name = "-";
            series12.ChartArea = "ChartArea1";
            series12.Color = System.Drawing.Color.DodgerBlue;
            series12.Legend = "Legend1";
            series12.Name = "Förra månaden";
            this.chart_Körda_Ordrar.Series.Add(series10);
            this.chart_Körda_Ordrar.Series.Add(series11);
            this.chart_Körda_Ordrar.Series.Add(series12);
            this.chart_Körda_Ordrar.Size = new System.Drawing.Size(420, 155);
            this.chart_Körda_Ordrar.TabIndex = 1;
            this.chart_Körda_Ordrar.Text = "chart1";
            // 
            // label_Ordrar_Rubrik
            // 
            this.label_Ordrar_Rubrik.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Ordrar_Rubrik.Font = new System.Drawing.Font("Javanese Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ordrar_Rubrik.ForeColor = System.Drawing.Color.LimeGreen;
            this.label_Ordrar_Rubrik.Location = new System.Drawing.Point(0, 0);
            this.label_Ordrar_Rubrik.Name = "label_Ordrar_Rubrik";
            this.label_Ordrar_Rubrik.Size = new System.Drawing.Size(756, 35);
            this.label_Ordrar_Rubrik.TabIndex = 2;
            this.label_Ordrar_Rubrik.Text = "Ordrar";
            this.label_Ordrar_Rubrik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_AntalMätningar_Info
            // 
            this.label_AntalMätningar_Info.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AntalMätningar_Info.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label_AntalMätningar_Info.Location = new System.Drawing.Point(30, 440);
            this.label_AntalMätningar_Info.Name = "label_AntalMätningar_Info";
            this.label_AntalMätningar_Info.Size = new System.Drawing.Size(250, 70);
            this.label_AntalMätningar_Info.TabIndex = 0;
            this.label_AntalMätningar_Info.Text = "En ökning på %";
            // 
            // label_KördaOrdrar_Info
            // 
            this.label_KördaOrdrar_Info.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_KördaOrdrar_Info.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label_KördaOrdrar_Info.Location = new System.Drawing.Point(30, 270);
            this.label_KördaOrdrar_Info.Name = "label_KördaOrdrar_Info";
            this.label_KördaOrdrar_Info.Size = new System.Drawing.Size(250, 62);
            this.label_KördaOrdrar_Info.TabIndex = 0;
            this.label_KördaOrdrar_Info.Text = "En ökning på %";
            // 
            // label_AntalMätningar_Rubrik
            // 
            this.label_AntalMätningar_Rubrik.AutoSize = true;
            this.label_AntalMätningar_Rubrik.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AntalMätningar_Rubrik.ForeColor = System.Drawing.SystemColors.Info;
            this.label_AntalMätningar_Rubrik.Location = new System.Drawing.Point(60, 415);
            this.label_AntalMätningar_Rubrik.Name = "label_AntalMätningar_Rubrik";
            this.label_AntalMätningar_Rubrik.Size = new System.Drawing.Size(112, 15);
            this.label_AntalMätningar_Rubrik.TabIndex = 0;
            this.label_AntalMätningar_Rubrik.Text = "Antal Mätningar";
            // 
            // chart_Startade_Ordrar
            // 
            this.chart_Startade_Ordrar.BackColor = System.Drawing.Color.Transparent;
            chartArea7.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea7.AxisX.LineColor = System.Drawing.Color.Teal;
            chartArea7.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea7.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro;
            chartArea7.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea7.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea7.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea7.BackColor = System.Drawing.Color.Transparent;
            chartArea7.Name = "ChartArea1";
            this.chart_Startade_Ordrar.ChartAreas.Add(chartArea7);
            legend7.Alignment = System.Drawing.StringAlignment.Center;
            legend7.BackColor = System.Drawing.Color.Transparent;
            legend7.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend7.ForeColor = System.Drawing.Color.Gainsboro;
            legend7.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend7.Name = "Legend1";
            legend7.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.chart_Startade_Ordrar.Legends.Add(legend7);
            this.chart_Startade_Ordrar.Location = new System.Drawing.Point(300, 50);
            this.chart_Startade_Ordrar.Name = "chart_Startade_Ordrar";
            series13.ChartArea = "ChartArea1";
            series13.Color = System.Drawing.Color.SeaGreen;
            series13.Legend = "Legend1";
            series13.Name = "Två månader sedan";
            series14.ChartArea = "ChartArea1";
            series14.Color = System.Drawing.Color.Transparent;
            series14.Legend = "Legend1";
            series14.Name = "-";
            series15.ChartArea = "ChartArea1";
            series15.Color = System.Drawing.Color.DodgerBlue;
            series15.Legend = "Legend1";
            series15.Name = "Förra månaden";
            this.chart_Startade_Ordrar.Series.Add(series13);
            this.chart_Startade_Ordrar.Series.Add(series14);
            this.chart_Startade_Ordrar.Series.Add(series15);
            this.chart_Startade_Ordrar.Size = new System.Drawing.Size(420, 155);
            this.chart_Startade_Ordrar.TabIndex = 1;
            this.chart_Startade_Ordrar.Text = "chart1";
            // 
            // label_KördaOrdrar_Rubrik
            // 
            this.label_KördaOrdrar_Rubrik.AutoSize = true;
            this.label_KördaOrdrar_Rubrik.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_KördaOrdrar_Rubrik.ForeColor = System.Drawing.SystemColors.Info;
            this.label_KördaOrdrar_Rubrik.Location = new System.Drawing.Point(60, 245);
            this.label_KördaOrdrar_Rubrik.Name = "label_KördaOrdrar_Rubrik";
            this.label_KördaOrdrar_Rubrik.Size = new System.Drawing.Size(98, 15);
            this.label_KördaOrdrar_Rubrik.TabIndex = 0;
            this.label_KördaOrdrar_Rubrik.Text = "Körda Ordrar ";
            // 
            // label_AntalStartadeOrdrar_Info
            // 
            this.label_AntalStartadeOrdrar_Info.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AntalStartadeOrdrar_Info.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label_AntalStartadeOrdrar_Info.Location = new System.Drawing.Point(30, 100);
            this.label_AntalStartadeOrdrar_Info.Name = "label_AntalStartadeOrdrar_Info";
            this.label_AntalStartadeOrdrar_Info.Size = new System.Drawing.Size(250, 70);
            this.label_AntalStartadeOrdrar_Info.TabIndex = 0;
            this.label_AntalStartadeOrdrar_Info.Text = "En ökning på %";
            // 
            // label_AntalStartadeOrdrar_Rubrik
            // 
            this.label_AntalStartadeOrdrar_Rubrik.AutoSize = true;
            this.label_AntalStartadeOrdrar_Rubrik.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AntalStartadeOrdrar_Rubrik.ForeColor = System.Drawing.SystemColors.Info;
            this.label_AntalStartadeOrdrar_Rubrik.Location = new System.Drawing.Point(60, 75);
            this.label_AntalStartadeOrdrar_Rubrik.Name = "label_AntalStartadeOrdrar_Rubrik";
            this.label_AntalStartadeOrdrar_Rubrik.Size = new System.Drawing.Size(154, 15);
            this.label_AntalStartadeOrdrar_Rubrik.TabIndex = 0;
            this.label_AntalStartadeOrdrar_Rubrik.Text = "Antal Startade Ordrar";
            // 
            // panel_Rubrik
            // 
            this.panel_Rubrik.BackColor = System.Drawing.Color.Transparent;
            this.panel_Rubrik.Controls.Add(this.tb_User);
            this.panel_Rubrik.Controls.Add(this.lbl_Close);
            this.panel_Rubrik.Controls.Add(this.lbl_Initialer);
            this.panel_Rubrik.Controls.Add(this.label_Header_Aktivitet_Rubrik);
            this.panel_Rubrik.Controls.Add(this.chart_Rubrik);
            this.panel_Rubrik.Controls.Add(this.label_Header_Info);
            this.panel_Rubrik.Controls.Add(this.label_Header_Rubrikt);
            this.panel_Rubrik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Rubrik.Location = new System.Drawing.Point(3, 3);
            this.panel_Rubrik.Name = "panel_Rubrik";
            this.panel_Rubrik.Size = new System.Drawing.Size(758, 194);
            this.panel_Rubrik.TabIndex = 3;
            // 
            // tb_User
            // 
            this.tb_User.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_User.Location = new System.Drawing.Point(9, 162);
            this.tb_User.Name = "tb_User";
            this.tb_User.Size = new System.Drawing.Size(141, 20);
            this.tb_User.TabIndex = 6;
            this.tb_User.Visible = false;
            this.tb_User.Click += new System.EventHandler(this.User_Click);
            this.tb_User.TextChanged += new System.EventHandler(this.User_TextChanged);
            // 
            // lbl_Close
            // 
            this.lbl_Close.AutoSize = true;
            this.lbl_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Close.Font = new System.Drawing.Font("Consolas", 18.75F);
            this.lbl_Close.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_Close.Location = new System.Drawing.Point(4, 4);
            this.lbl_Close.Name = "lbl_Close";
            this.lbl_Close.Size = new System.Drawing.Size(27, 29);
            this.lbl_Close.TabIndex = 5;
            this.lbl_Close.Text = "X";
            this.lbl_Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // lbl_Initialer
            // 
            this.lbl_Initialer.AutoSize = true;
            this.lbl_Initialer.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Initialer.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_Initialer.Location = new System.Drawing.Point(327, 37);
            this.lbl_Initialer.Name = "lbl_Initialer";
            this.lbl_Initialer.Size = new System.Drawing.Size(45, 25);
            this.lbl_Initialer.TabIndex = 4;
            this.lbl_Initialer.Text = "RA";
            // 
            // label_Header_Aktivitet_Rubrik
            // 
            this.label_Header_Aktivitet_Rubrik.AutoSize = true;
            this.label_Header_Aktivitet_Rubrik.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Header_Aktivitet_Rubrik.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Header_Aktivitet_Rubrik.Location = new System.Drawing.Point(496, 6);
            this.label_Header_Aktivitet_Rubrik.Name = "label_Header_Aktivitet_Rubrik";
            this.label_Header_Aktivitet_Rubrik.Size = new System.Drawing.Size(70, 15);
            this.label_Header_Aktivitet_Rubrik.TabIndex = 3;
            this.label_Header_Aktivitet_Rubrik.Text = "Aktivitet";
            // 
            // chart_Rubrik
            // 
            this.chart_Rubrik.BackColor = System.Drawing.Color.Transparent;
            chartArea8.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea8.AxisX.LineColor = System.Drawing.Color.Teal;
            chartArea8.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea8.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro;
            chartArea8.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea8.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea8.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea8.BackColor = System.Drawing.Color.Transparent;
            chartArea8.Name = "ChartArea1";
            this.chart_Rubrik.ChartAreas.Add(chartArea8);
            this.chart_Rubrik.Dock = System.Windows.Forms.DockStyle.Right;
            legend8.Alignment = System.Drawing.StringAlignment.Center;
            legend8.BackColor = System.Drawing.Color.Transparent;
            legend8.ForeColor = System.Drawing.Color.Gainsboro;
            legend8.Name = "Legend1";
            this.chart_Rubrik.Legends.Add(legend8);
            this.chart_Rubrik.Location = new System.Drawing.Point(505, 0);
            this.chart_Rubrik.Name = "chart_Rubrik";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series16.Color = System.Drawing.Color.SeaGreen;
            series16.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series16.Legend = "Legend1";
            series16.Name = "Serie1";
            this.chart_Rubrik.Series.Add(series16);
            this.chart_Rubrik.Size = new System.Drawing.Size(253, 194);
            this.chart_Rubrik.TabIndex = 2;
            this.chart_Rubrik.Text = "chart1";
            // 
            // label_Header_Info
            // 
            this.label_Header_Info.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Header_Info.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Header_Info.Location = new System.Drawing.Point(29, 24);
            this.label_Header_Info.Name = "label_Header_Info";
            this.label_Header_Info.Size = new System.Drawing.Size(225, 94);
            this.label_Header_Info.TabIndex = 0;
            this.label_Header_Info.Text = "Hej";
            // 
            // label_Header_Rubrikt
            // 
            this.label_Header_Rubrikt.Font = new System.Drawing.Font("Californian FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Header_Rubrikt.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Header_Rubrikt.Location = new System.Drawing.Point(34, 0);
            this.label_Header_Rubrikt.Name = "label_Header_Rubrikt";
            this.label_Header_Rubrikt.Size = new System.Drawing.Size(705, 24);
            this.label_Header_Rubrikt.TabIndex = 0;
            this.label_Header_Rubrikt.Text = "My Analysis";
            this.label_Header_Rubrikt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer_AutoScroll
            // 
            this.timer_AutoScroll.Interval = 17;
            this.timer_AutoScroll.Tick += new System.EventHandler(this.timer_AutoScroll_Tick);
            // 
            // timer_Start_timer_AutoScroll
            // 
            this.timer_Start_timer_AutoScroll.Interval = 10000;
            this.timer_Start_timer_AutoScroll.Tick += new System.EventHandler(this.timer_Start_timer_AutoScroll_Tick);
            // 
            // My_Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(764, 859);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "My_Analysis";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My_Analysis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.My_Analysis_FormClosed);
            this.tlp_Main.ResumeLayout(false);
            this.panel_Parts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Parts)).EndInit();
            this.panel_Processkort.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Processkort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Skapade_Processkort)).EndInit();
            this.panel_Produktionslinjer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ProdLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Linjer_Aktivitet)).EndInit();
            this.panel_Samarbete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Medarbetare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Samarbete)).EndInit();
            this.panel_Starta_Ordrar.ResumeLayout(false);
            this.panel_Starta_Ordrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Körda_Ordrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Antal_Mätningar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Startade_Ordrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Antal_Mätningar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Körda_Ordrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Startade_Ordrar)).EndInit();
            this.panel_Rubrik.ResumeLayout(false);
            this.panel_Rubrik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Rubrik)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Panel panel_Starta_Ordrar;
        private Chart chart_Startade_Ordrar;
        private Label label_AntalStartadeOrdrar_Rubrik;
        private Label label_AntalStartadeOrdrar_Info;
        private Chart chart_Körda_Ordrar;
        private Label label_KördaOrdrar_Info;
        private Label label_KördaOrdrar_Rubrik;
        private Chart chart_Antal_Mätningar;
        private Label label_AntalMätningar_Info;
        private Label label_AntalMätningar_Rubrik;
        private Panel panel_Rubrik;
        private Label label_Header_Rubrikt;
        private Chart chart_Rubrik;
        private Label label_Header_Aktivitet_Rubrik;
        private Panel panel_Samarbete;
        private Chart chart_Samarbete;
        private Label label_Samarbete_Info;
        private Panel panel_Produktionslinjer;
        private Chart chart_Linjer_Aktivitet;
        private Label label_Info_ProdLines;
        private Label label_Header_Info;
        private Label label_Linje_Aktivitet_Extra_Info;
        private Panel panel_Processkort;
        private Chart chart_Skapade_Processkort;
        private Label label_Processkort_Info;
        private Label label_Info_Processcard;
        private PictureBox pb_Antal_Mätningar;
        private PictureBox pb_Medarbetare;
        private PictureBox pb_ProdLines;
        private PictureBox pb_Processkort;
        private PictureBox pb_Körda_Ordrar;
        private PictureBox pb_Startade_Ordrar;
        private Label label_Ordrar_Rubrik;
        private Label label_Samarbete_Rubrik;
        private Label label_Processkort;
        private Label label_ProdLines;
        private Label lbl_Initialer;
        private System.Windows.Forms.Timer timer_AutoScroll;
        private System.Windows.Forms.Timer timer_Start_timer_AutoScroll;
        private Label lbl_Close;
        private TextBox tb_User;
        private Panel panel_Parts;
        private Label label_Artiklar;
        private PictureBox pictureBox4;
        private Label label3;
        private Chart chart_Parts;
        private Label label_Info_Parts;
    }
}