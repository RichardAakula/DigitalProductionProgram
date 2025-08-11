using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace DigitalProductionProgram.MainWindow
{
    public partial class Test : Form
    {
        private string CodeName;
        private string CodeText;
        public Test(string codeName, string codeText)
        {
            InitializeComponent();
            CodeName = codeName;
            CodeText = codeText;
            InitializeChart();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            //measurementChart?.Add_Data_Chart_MainForm(CodeName, CodeText);
        }
        private CartesianChart cartesianChart;
        private void InitializeChart()
        {
            cartesianChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Black,

                Series = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = new ObservableCollection<double> { 3, 5, 7, 9, 4, 6, 8 },
                        Stroke = new SolidColorPaint(SKColors.Yellow, 2),
                        Fill = null,

                        GeometrySize = 10,
                        GeometryStroke = new SolidColorPaint(SKColors.Black, 2),
                        GeometryFill = new SolidColorPaint(SKColors.Yellow),

                        // Tooltip-text vid hover
                        TooltipLabelFormatter = point => $"Y: {point.PrimaryValue:N1}",
                        DataLabelsPaint = new SolidColorPaint(SKColors.White),
                        DataLabelsSize = 14,
                    }
                },

                XAxes = new Axis[]
                {
                    new Axis
                    {
                        LabelsPaint = new SolidColorPaint(SKColors.White),
                        SeparatorsPaint = new SolidColorPaint(SKColors.White.WithAlpha(60))
                    }
                },

                YAxes = new Axis[]
                {
                    new Axis
                    {
                        LabelsPaint = new SolidColorPaint(SKColors.White),
                        SeparatorsPaint = new SolidColorPaint(SKColors.White.WithAlpha(60)),
                        Labeler = value => value.ToString("N")
                    }
                },

                // Tooltip måste sättas för WinForms
                TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top
            };

            Controls.Add(cartesianChart);
        }


    }
}
