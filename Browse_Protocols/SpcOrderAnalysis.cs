using DigitalProductionProgram.DatabaseManagement;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.Measure;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;

namespace DigitalProductionProgram.Browse_Protocols
{
    public partial class SpcOrderAnalysis : Form
    {
        private readonly OrderSpcRequest _request;
        private readonly CartesianChart cartesianChart;
        private readonly List<MeasurementPoint> _measurements;

        public SpcOrderAnalysis(OrderSpcRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            InitializeComponent();
            cartesianChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
            };
            tlp_Main.Controls.Add(cartesianChart,1,0);
            _request = request;
            _measurements = LoadMeasurements(request.ProtocolDescriptionId ?? 0, request.OrderNumbers.Select(int.Parse).ToList());
            InitializeView();
            AddDataToChart(_measurements);
            AddXAxisLabels(_measurements);
            AddLimitSections(_request.Min, _request.Nom, _request.Max);
        }



        private void InitializeView()
        {
            this.Text = $"SPC – {_request.ParameterName}";

            lbl_ParameterName.Text = _request.ParameterName;
            label_USL.Text = $@"{_request.Max?.ToString()}";
            lbl_NOM.Text = $@"{_request.Nom?.ToString()}";
            lbl_LSL.Text = $@"{_request.Min?.ToString()}";
            var valueList = _measurements.Select(m => m.Value).ToList();
            var spc = BrowseMeasureProtocols.SpcResult.Calculate(valueList, _request.ParameterName, null, _request.Min, _request.Max);
            lbl_Mean.Text = spc.Mean?.ToString("F3");
            lbl_Median.Text = spc.Median?.ToString();
            lbl_Min.Text = valueList.Min()?.ToString();
            lbl_Max.Text = valueList.Max()?.ToString();
            lbl_Range.Text = spc.Range?.ToString();
            lbl_StandardDeviation.Text = spc.StandardDeviation?.ToString("F3");
            lbl_Skewness.Text = spc.Skewness?.ToString("F3");
            lbl_Kurtosis.Text = spc.Kurtosis?.ToString("F3");
            lbl_Pp.Text = spc.Pp?.ToString("F3");
            lbl_Ppk.Text = spc.Ppk?.ToString("F3");
            lbl_PerformanceRatio.Text = spc.PerformanceRatio?.ToString("P2");
            lbl_TotalOrders.Text = $@"Total Orders: {_request.OrderNumbers.Count}";
        }
        private List<MeasurementPoint> LoadMeasurements(int protocolDescriptionId, List<int> orderid)
        {
            var list = new List<MeasurementPoint>();

            Database.ExecuteSafe(con =>
            {
                var query = """
                                SELECT 
                                    main.OrderNr,
                                    data.Uppstart,
                                    data.Value
                                FROM [Order].MainData as main
                                JOIN [Order].Data as data 
                                    ON main.OrderID = data.OrderID
                                    AND data.ProtocolDescriptionID = @protocoldescriptionid
                                    AND main.OrderId IN 
                                    (
                            """ 
                            + string.Join(",", orderid) + 
                            @"
                                    )
                                ORDER BY main.OrderNr, Uppstart";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@protocoldescriptionid", protocolDescriptionId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var valueObj = reader["Value"];
                    double? value = valueObj == DBNull.Value ? null : Convert.ToDouble(valueObj);

                    list.Add(new MeasurementPoint
                    {
                        OrderNumber = reader["OrderNr"].ToString(),
                        StartUp = Convert.ToInt16(reader["Uppstart"]),
                        Value = value
                    });
                }
            });

            return list;
        }
        private void AddDataToChart(List<MeasurementPoint> measurements)
        {
            if (measurements == null || measurements.Count == 0)
                return;

            // Bygg Y-värden
            var points = measurements.Select(m => m.Value).ToList();

            // Skapa serien
            var series = new LineSeries<double?>
            {
                Values = points,
                Fill = null,
                Stroke = new SolidColorPaint(SKColors.Blue, 2),
                GeometryFill = new SolidColorPaint(SKColors.Green),
                GeometryStroke = new SolidColorPaint(SKColors.Green),
                GeometrySize = 1,    // punktstorlek
            };

            // Sätt in i charten
            cartesianChart.Series = [series];
        }
        private void AddXAxisLabels(List<MeasurementPoint> measurements)
        {
            var labels = measurements.Select(m => $"{m.OrderNumber}-U{m.StartUp}").ToList();

            cartesianChart.XAxes =
            [
                new Axis
                {
                    Labels = labels,
                    LabelsRotation = 45,   // rotera för bättre läsbarhet
                    UnitWidth = 1,
                    MinStep = 1
                }
            ];
        }
        private void AddLimitSections(double? lsl, double? nom, double? usl)
        {
            // Lägg till 5 % "luft" ovanför och under
            var marginPercent = 10; // ändra om du vill ha mer/less
            double margin = ((usl ?? 0) - (lsl ?? 0)) * marginPercent / 100;

            var minY = (lsl ?? 0) - margin;  // lite under LSL
            var maxY = (usl ?? 0) + margin;


            var sections = new List<RectangularSection>();

            if (usl.HasValue)
                sections.Add(new RectangularSection
                {
                    Yi = usl.Value,
                    Yj = maxY,
                    Fill = new SolidColorPaint(new SKColor(255, 199, 206, 230)) // röd
                });

            if (lsl.HasValue)
                sections.Add(new RectangularSection
                {
                    Yi = minY,
                    Yj = lsl.Value,
                    Fill = new SolidColorPaint(new SKColor(255, 199, 206, 230)) // röd
                });

            if (lsl.HasValue && usl.HasValue)
                sections.Add(new RectangularSection
                {
                    Yi = usl.Value,
                    Yj = lsl.Value,
                    Fill = new SolidColorPaint(new SKColor(198, 239, 206, 255)) // grön
                });
            cartesianChart.Sections = sections;

            cartesianChart.YAxes =
            [
                new Axis
                {
                    MinLimit = minY,
                    MaxLimit = maxY,
                    SeparatorsPaint = new SolidColorPaint
                    {
                        Color = new SKColor(150, 150, 150, 120),
                        StrokeThickness = 1.5f
                    }
                }
            ];

        }
    }

    public class MeasurementPoint
    {
        public string OrderNumber { get; set; }
        public int StartUp { get; set; }
        public double? Value { get; set; }
    }
}
