using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using LiveChartsCore.SkiaSharpView.WinForms;
using Microsoft.Data.SqlClient;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using Axis = LiveChartsCore.SkiaSharpView.Axis;

namespace DigitalProductionProgram.Measure
{
    public partial class MeasurementChart : UserControl
    {
        private static Dictionary<string, double> dict_AverageValuesForLastOrder = new();
        private static Dictionary<string, double> dict_AverageValuesForPart = new();
        public static void LoadAvgValuesForLastOrder()
        {
            dict_AverageValuesForLastOrder.Clear();

            if (Order.PartNumber is null)
                return;

            Database.ExecuteSafe(con =>
            {
                const string query = @"
                SELECT d.CodeName, AVG(data.Value) AS AvgValue
                FROM Measureprotocol.Data AS data
                INNER JOIN MeasureProtocol.MainData AS maindata
                    ON data.OrderID = maindata.OrderID
                    AND data.RowIndex = maindata.RowIndex
                INNER JOIN MeasureProtocol.Description AS d
                    ON data.DescriptionId = d.Id
                WHERE data.OrderID = 
                (
                    SELECT OrderID FROM 
                    (
                        SELECT TOP(2) OrderID, ROW_NUMBER() OVER (ORDER BY Date_Start DESC) AS RowNum
                        FROM [Order].MainData 
                        WHERE PartNr = @partnumber
                    ) AS tables
                    WHERE RowNum = 2
                )
                    AND (maindata.Discarded = 'False' OR maindata.Discarded IS NULL)
                GROUP BY d.CodeName";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnumber", Order.PartNumber);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var code = reader["CodeName"]?.ToString();
                    if (string.IsNullOrEmpty(code))
                        continue;

                    var val = reader["AvgValue"] != DBNull.Value ? Convert.ToDouble(reader["AvgValue"]) : 0d;
                    dict_AverageValuesForLastOrder[code] = val;
                }
            });
        }

        public static void LoadAvgValuesForPart()
        {
            dict_AverageValuesForPart.Clear();

            if (Order.PartID is null || Order.PartID == 0)
                return;

            Database.ExecuteSafe(con =>
            {
                const string query = @"
                    SELECT d.CodeName, AVG(data.Value) AS AvgValue
                    FROM Measureprotocol.Data AS data 
                    INNER JOIN MeasureProtocol.MainData AS maindata
                        ON data.OrderID = maindata.OrderID
                        AND data.RowIndex = maindata.RowIndex
                    INNER JOIN MeasureProtocol.Description AS d
                        ON data.DescriptionId = d.Id
                    WHERE EXISTS 
                    (
                        SELECT * 
                        FROM [Order].MainData AS om 
                        WHERE om.OrderID = data.OrderID 
                        AND om.PartID = @partid
                    )
                        AND (maindata.Discarded = 'False' OR maindata.Discarded IS NULL)
                    GROUP BY d.CodeName";

                using var cmd = new SqlCommand(query, con);
                ServerStatus.Add_Sql_Counter();
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var code = reader["CodeName"]?.ToString();
                    if (string.IsNullOrEmpty(code))
                        continue;

                    var val = reader["AvgValue"] != DBNull.Value ? Convert.ToDouble(reader["AvgValue"]) : 0d;
                    dict_AverageValuesForPart[code] = val;
                }

                return 0; // ExecuteSafe kräver returvärde
            });
        }

        private static double AverageValuePartNr(string codename)
        {
            if (dict_AverageValuesForPart.TryGetValue(codename, out var avgValuePartNr) == false)
                return double.NaN;
            return avgValuePartNr;
        }
        private static double? AverageValueLastOrder(string codename)
        {
            if (dict_AverageValuesForLastOrder.TryGetValue(codename, out var avgValueLastOrder) == false)
                return null;
            return avgValueLastOrder;
        }

        private static double? chart_Maximum_Yvalue(string codename, double sl_max)
        {
            var maxMeasurementValue = MainMeasureStatistics.GetMeasurementValue("MAX", codename);
            if (dict_AverageValuesForLastOrder.TryGetValue(codename, out var avgValueLastOrder) == false)
                return Math.Max(maxMeasurementValue, sl_max);
            var max = Math.Max(avgValueLastOrder, maxMeasurementValue);
            return Math.Max(max, sl_max);
        }
        private static double chart_Minimum_Yvalue(string codename)
        {
            var minMeasurementValue = MainMeasureStatistics.GetMeasurementValue("MIN", codename);
            if (!dict_AverageValuesForLastOrder.TryGetValue(codename, out var avgValueLastOrder) || avgValueLastOrder <= 0)
                return minMeasurementValue;

            var min = Math.Min(minMeasurementValue, avgValueLastOrder);
            return min;
        }
        private static double? Y_Axis_MaxValue(string? codename, double sl_max)
        {
            var usl = MeasurePoints.Tolerances.ActiveTolerance(codename, "USL");
            var max_chart = chart_Maximum_Yvalue(codename, sl_max);

            var result = double.MaxValue;

            if (usl != null && max_chart != null)
                result = Math.Max(usl.Value, max_chart.Value);
            else
                if (max_chart != null)
                    result = Math.Ceiling(max_chart.Value * 100) / 100;

           
            var margin = Math.Pow(result, 0.75) * 0.005; // Dynamisk marginal baserat på värdet
            return result + margin;
        }
        private static double? Y_Axis_MinValue(string? codename)
        {
            var lsl = MeasurePoints.Tolerances.ActiveTolerance(codename, "LSL");
            double? min_chart = chart_Minimum_Yvalue(codename);

            var result = double.MinValue;

            if (lsl != null && min_chart != null)
                result = Math.Min(lsl.Value, min_chart.Value);
            else 
                if (min_chart != null)
                    result = Math.Floor(min_chart.Value * 100) / 100;


            var margin = Math.Pow(result, 0.85) * 0.005; // Dynamisk marginal baserat på värdet
            return result - margin;
        }

        public static int TotalValuesInChart
        {
            get
            {
                var currentCount = 0;
                if (cartesianChart != null &&
                    cartesianChart.Series != null &&
                    cartesianChart.Series.Count() >= 3 &&
                    cartesianChart.Series.ElementAt(2) is LineSeries<ObservablePoint> s &&
                    s.Values is IEnumerable<ObservablePoint> values)
                {
                    currentCount = values.Count(); // 🔹 LINQ Count() extension
                }
                return currentCount;
            }
        }

        public static int TotalValuesInMeasureProtocol
        {
            get
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = @"
                    SELECT COUNT(*)
                    FROM Measureprotocol.MainData
                    WHERE OrderID = @orderid
                        AND (Discarded = 'False' OR Discarded IS NULL)";
                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    ServerStatus.Add_Sql_Counter();

                    var count = cmd.ExecuteScalar();
                    return count != null && int.TryParse(count.ToString(), out var result) ? result : 0;
                });
            }
        }


        public static CartesianChart? cartesianChart;
        private LineSeries<ObservablePoint> serieValues;
        private LineSeries<ObservablePoint> serieUSL;
        private LineSeries<ObservablePoint> serieUCL;
        private LineSeries<ObservablePoint> serieLCL;
        private LineSeries<ObservablePoint> serieLSL;
        private LineSeries<ObservablePoint> serieAvgLatest;
        private LineSeries<ObservablePoint> serieAvgPart;

        private static LineSeries<ObservablePoint> serie_Values(string? codetext)
        {
            var serie = new LineSeries<ObservablePoint>
            {
                Name = codetext,
                IsVisibleAtLegend = true,
                Values = new ObservableCollection<ObservablePoint>(),
                Stroke = new SolidColorPaint(SKColors.Yellow, 2),
                Fill = null,
                GeometrySize = 4, 
                GeometryFill = new SolidColorPaint(SKColors.Yellow),
                GeometryStroke = new SolidColorPaint(SKColors.Yellow),
                YToolTipLabelFormatter = value => $"# {value.Coordinate.SecondaryValue} / {value.Coordinate.PrimaryValue:F3}",

                AnimationsSpeed = TimeSpan.FromMilliseconds(100)
            };

            return serie;
        }
        private static LineSeries<ObservablePoint> serie_AvgLatestOrder(string codename) =>
            new()
            {
                Name = $"{Properties.Resources.legendAverageLastOrder} - {AverageValueLastOrder(codename):F3}",
                IsVisibleAtLegend = true,
                Fill = null,
                GeometryFill = new SolidColorPaint(SKColors.Green), 
                GeometryStroke = new SolidColorPaint(SKColors.Green),
            };
        private static LineSeries<ObservablePoint> serie_AvgPart(string codename) =>
            new()
            {
                Name = $"{Properties.Resources.legendAverageValuePartNr} - {AverageValuePartNr(codename):F3}",
                IsVisibleAtLegend = true,
                Fill = null,
                GeometryFill = new SolidColorPaint(SKColors.DeepSkyBlue),
                GeometryStroke = new SolidColorPaint(SKColors.DeepSkyBlue),
            };
        private static LineSeries<ObservablePoint> serie_USL(string codename) =>
            new()
            {
                Name = $"USL - {MeasurePoints.Tolerances.ActiveTolerance(codename, "USL"):F3}",
                IsVisibleAtLegend = true,
                GeometryFill = new SolidColorPaint(new SKColor(156, 0, 6, 230)),
                GeometryStroke = new SolidColorPaint(new SKColor(156, 0, 6, 230)),
                Fill = null,
            };
        private static LineSeries<ObservablePoint> serie_UCL(string codename) => 
            new()
            {
                Name = $"UCL - {MeasurePoints.Tolerances.ActiveTolerance(codename, "UCL"):F3}",
                IsVisibleAtLegend = true,
                GeometryFill = new SolidColorPaint(new SKColor(156, 101, 0, 230)),
                GeometryStroke = new SolidColorPaint(new SKColor(156, 101, 0, 230)),
                Fill = null,
            };
        private static LineSeries<ObservablePoint> serie_LCL(string codename) =>
            new()
            {
                Name = $"LCL - {MeasurePoints.Tolerances.ActiveTolerance(codename, "LCL"):F3}",
                IsVisibleAtLegend = true,
                GeometryFill = new SolidColorPaint(new SKColor(156, 101, 0, 230)),
                GeometryStroke = new SolidColorPaint(new SKColor(156, 101, 0, 230)),
                Fill = null,
            };
        private static LineSeries<ObservablePoint> serie_LSL(string codename) =>
            new()
            {
                Name = $"LSL - {MeasurePoints.Tolerances.ActiveTolerance(codename, "LSL"):F3}",
                IsVisibleAtLegend = true,
                GeometryFill = new SolidColorPaint(new SKColor(156, 0, 6, 230)),
                GeometryStroke = new SolidColorPaint(new SKColor(156, 0, 6, 230)),
                Fill = null,
            };
        private static SolidColorPaint dashedStroke(SKColor color)
        {
            var stroke = new SolidColorPaint
            {
                Color = color,
                StrokeThickness = 2,
                PathEffect = new DashEffect([16, 1])
            };
            return stroke;
        }
        



        public MeasurementChart()
        {
            InitializeComponent();
        }



        private void Initialize_Chart_MainForm(string? codename, string? codetext)
        {
            // Skapa serier och spara referenser
            serieUSL = serie_USL(codename);
            serieUCL = serie_UCL(codename);
            serieLCL = serie_LCL(codename);
            serieLSL = serie_LSL(codename);
            serieValues = serie_Values(codetext);
            serieAvgLatest = serie_AvgLatestOrder(codename);
            serieAvgPart = serie_AvgPart(codename);

            cartesianChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                Sections = new RectangularSection[]
                {
            new() { Yi = MeasurePoints.Tolerances.ActiveTolerance(codename, "USL") ?? double.NaN,
                    Yj = Y_Axis_MaxValue(codename, 0),
                    Fill = new SolidColorPaint { Color = new SKColor(156,0,6,230) } },

            new() { Yi = MeasurePoints.Tolerances.ActiveTolerance(codename, "UCL") ?? double.NaN,
                    Yj = MeasurePoints.Tolerances.ActiveTolerance(codename, "USL") ?? double.NaN,
                    Fill = new SolidColorPaint { Color = new SKColor(156,101,0,230) } },

            new() { Yi = MeasurePoints.Tolerances.ActiveTolerance(codename, "LCL") ?? double.NaN,
                    Yj = MeasurePoints.Tolerances.ActiveTolerance(codename, "LSL") ?? double.NaN,
                    Fill = new SolidColorPaint { Color = new SKColor(156,101,0,230) } },

            new() { Yi = Y_Axis_MinValue(codename),
                    Yj = MeasurePoints.Tolerances.ActiveTolerance(codename, "LSL") ?? double.NaN,
                    Fill = new SolidColorPaint { Color = new SKColor(156,0,6,230) } },

            new() { Yi = AverageValueLastOrder(codename) ?? double.NaN,
                    Yj = AverageValueLastOrder(codename) ?? double.NaN,
                    Stroke = dashedStroke(SKColors.Green) },

            new() { Yi = AverageValuePartNr(codename),
                    Yj = AverageValuePartNr(codename),
                    Stroke = dashedStroke(SKColors.DeepSkyBlue) }
                },
                XAxes = new[]
                {
            new Axis
            {
                Name = "Measurement",
                TextSize = 12,
                LabelsPaint = new SolidColorPaint(SKColors.White),
                SeparatorsPaint = new SolidColorPaint(SKColors.Black),
                ShowSeparatorLines = true,
                MinLimit = 1,
                MinStep = 1
            }
        },
                YAxes = new[]
                {
            new Axis
            {
                Name = codetext,
                TextSize = 12,
                Labeler = value => $"{value:F3} mm",
                LabelsPaint = new SolidColorPaint(SKColors.White),
                SeparatorsPaint = new SolidColorPaint(SKColors.Black),
                MinLimit = Y_Axis_MinValue(codename) ?? 0,
                MaxLimit = Y_Axis_MaxValue(codename, 0) ?? 10,
                MinStep = 0.001
            }
        },
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right,
                LegendTextPaint = new SolidColorPaint { Color = SKColors.White },
                LegendTextSize = 12,
                ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X
            };

            // Lägg till alla serier
            cartesianChart.Series = new ISeries[]
            {
        serieUSL, serieUCL, serieValues, serieAvgLatest, serieAvgPart, serieLCL, serieLSL
            };

            if (!this.Controls.Contains(cartesianChart))
                this.Controls.Add(cartesianChart);
        }
        //private void Initialize_Chart_MainForm(string? codename, string? codetext)
        //{
        //    cartesianChart = new CartesianChart
        //    {
        //        Dock = DockStyle.Fill,
        //        Sections = new RectangularSection[]
        //        {
        //            new()
        //            {
        //               Yi = MeasurePoints.Tolerances.ActiveTolerance(codename, "USL") ?? double.NaN,
        //               Yj = Y_Axis_MaxValue(codename, 0),
        //               Fill = new SolidColorPaint
        //               {
        //                   Color = new SKColor(156,0,6,230)
        //               }

        //            },
        //            new()
        //            {
        //               Yi = MeasurePoints.Tolerances.ActiveTolerance(codename, "UCL") ?? double.NaN,
        //               Yj = MeasurePoints.Tolerances.ActiveTolerance(codename, "USL") ?? double.NaN,
        //               Fill = new SolidColorPaint
        //               {
        //                   Color = new SKColor(156,101,0,230)
        //               }

        //            },
        //            new() {
        //                Yi = MeasurePoints.Tolerances.ActiveTolerance(codename, "LCL") ?? double.NaN,
        //                Yj = MeasurePoints.Tolerances.ActiveTolerance(codename, "LSL") ?? double.NaN,
        //                Fill = new SolidColorPaint
        //                {
        //                    Color = new SKColor(156,101,0,230)
        //                }

        //            },
        //            new()
        //            {
        //                Yi = Y_Axis_MinValue(codename),
        //                Yj = MeasurePoints.Tolerances.ActiveTolerance(codename, "LSL") ?? double.NaN,
        //                Fill = new SolidColorPaint
        //                { 
        //                        Color = new SKColor(156,0,6,230)
        //               }
        //            },
        //            new()
        //            {                    
        //                Yi = AverageValueLastOrder(codename) ?? double.NaN,
        //                Yj = AverageValueLastOrder(codename) ?? double.NaN,
        //                Stroke = dashedStroke(SKColors.Green),
        //            },
        //            new()
        //            {
        //                Yi = AverageValuePartNr(codename),
        //                Yj = AverageValuePartNr(codename),
        //                Stroke = dashedStroke(SKColors.DeepSkyBlue),
        //            }
        //        },
        //        XAxes =
        //        [
        //            new Axis
        //            {
        //                Name = "Measurement",
        //                TextSize = 12,
        //                LabelsPaint = new SolidColorPaint(SKColors.White),
        //                SeparatorsPaint = new SolidColorPaint(SKColors.Black),
        //                ShowSeparatorLines = true,
        //                MinLimit = 1,
        //                MinStep = 1
        //            }
        //        ],
        //        YAxes =
        //        [
        //            new Axis
        //            {
        //                Name = codetext,
        //                TextSize = 12,
        //                Labeler = value => $"{value:F3} mm",
        //                LabelsPaint = new SolidColorPaint(SKColors.White),
        //                SeparatorsPaint = new SolidColorPaint(SKColors.Black),
        //                MinLimit = Y_Axis_MinValue(codename) ?? 0,
        //                MaxLimit = Y_Axis_MaxValue(codename, 0) ?? 10, // Sätt ett rimligt maxvärde om inget annat finns
        //                MinStep = 0.001, // Stegstorlek för y-axeln
        //            }
        //        ],
        //        LegendPosition = LiveChartsCore.Measure.LegendPosition.Right,
        //        LegendTextPaint = new SolidColorPaint
        //        {
        //            Color = SKColors.White,
        //            SKTypeface = SKTypeface.Default,
        //        },
        //        LegendTextSize = 12,
        //        ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X, // Aktivera zoomning och panorering på både X- och Y-axlar
        //    };

        //    cartesianChart.Series = [serie_USL(codename), serie_UCL(codename), serie_Values(codetext), serie_AvgLatestOrder(codename), serie_AvgPart(codename), serie_LCL(codename),  serie_LSL(codename)];

        //}

        public static string? ActiveCodeName;
        public static string? ActiveCodeText;


        //public async Task Add_Data_Chart_MainForm()
        //{
        //    await RemoveChart();
        //    // Init + add chart on UI thread
        //    this.Invoke(() =>
        //    {
        //        Refresh();
        //        Visible = true;
        //        Initialize_Chart_MainForm(ActiveCodeName, ActiveCodeText);

        //        if (!this.Controls.Contains(cartesianChart))
        //            this.Controls.Add(cartesianChart);

        //        Refresh();
        //    });

        //    await using var con = new SqlConnection(Database.cs_Protocol);

        //    const string query = @"
        //        SELECT Value
        //        FROM Measureprotocol.Data AS data
        //        INNER JOIN Measureprotocol.MainData as maindata
        //            ON data.OrderID = maindata.OrderID
        //            AND data.RowIndex = maindata.RowIndex
        //        WHERE data.OrderID = @orderid
        //            AND (Discarded = 'False' OR Discarded IS NULL)
        //            AND DescriptionId = (SELECT Id FROM MeasureProtocol.Description WHERE CodeName = @codename)
        //        ORDER BY maindata.RowIndex";

        //    await using var cmd = new SqlCommand(query, con);

        //    ServerStatus.Add_Sql_Counter();
        //    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
        //    cmd.Parameters.AddWithValue("@codename", ActiveCodeName);

        //    await con.OpenAsync();

        //    await using var reader = await cmd.ExecuteReaderAsync();

        //    var measurementValues = new ObservableCollection<ObservablePoint>();
        //    var index = 1;

        //    while (await reader.ReadAsync())
        //    {
        //        if (!double.TryParse(reader["Value"].ToString(), out var result))
        //            continue;

        //        measurementValues.Add(new ObservablePoint(index, result));
        //        index++;
        //    }

        //    // SÄTT SERIES PÅ UI-TRÅD
        //    this.Invoke(() =>
        //    {
        //        if (cartesianChart?.Series == null)
        //            return;

        //        var seriesList = cartesianChart.Series.ToList();

        //        if (seriesList.Count >= 5 &&
        //            seriesList[2] is LineSeries<ObservablePoint> series0)
        //        {
        //            series0.Values = measurementValues;
        //        }

        //        foreach(var point in measurementValues)
        //            Debug.WriteLine($"x:{point.X}, y:{point.Y}");
        //    });
        //}
        public async Task Add_Data_Chart_MainForm()
        {
            try
            {
                // Ta bort gammal chart
                await RemoveChart();

                // Initiera chart på UI-tråden
                this.Invoke(() =>
                {
                    Visible = true;
                    Refresh();
                    Initialize_Chart_MainForm(ActiveCodeName, ActiveCodeText);

                    // Lägg till chart i formuläret om den inte redan finns
                    if (!this.Controls.Contains(cartesianChart))
                        this.Controls.Add(cartesianChart);
                });

                // Hämta data asynkront från databasen
                var measurementValues = new ObservableCollection<ObservablePoint>();
                await using var con = new SqlConnection(Database.cs_Protocol);

                const string query = @"
            SELECT Value
            FROM Measureprotocol.Data AS data
            INNER JOIN Measureprotocol.MainData AS maindata
                ON data.OrderID = maindata.OrderID
                AND data.RowIndex = maindata.RowIndex
            WHERE data.OrderID = @orderid
                AND (Discarded = 'False' OR Discarded IS NULL)
                AND DescriptionId = (SELECT Id FROM MeasureProtocol.Description WHERE CodeName = @codename)
            ORDER BY maindata.RowIndex";

                await using var cmd = new SqlCommand(query, con);
                ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@codename", ActiveCodeName);

                await con.OpenAsync();
                await using var reader = await cmd.ExecuteReaderAsync();

                int index = 1;
                while (await reader.ReadAsync())
                {
                    if (!double.TryParse(reader["Value"]?.ToString(), out var result))
                        continue;

                    measurementValues.Add(new ObservablePoint(index, result));
                    index++;
                }

                // Uppdatera serien på UI-tråden
                this.Invoke(() =>
                {
                    if (serieValues != null)
                        serieValues.Values = measurementValues;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Fel i Add_Data_Chart_MainForm: {ex}");
                Log.Activity.Stop($"Felsökning: Fel i Add_Data_Chart_MainForm ({ex})");
                InfoText.Show("Fel vid inläsning av chart-data.", CustomColors.InfoText_Color.Bad, "Error", this);
            }
        }



        public Task RemoveChart()
        {
            if (cartesianChart != null)
            {
                this.Invoke(() => {
                    Controls.Remove(cartesianChart);
                    cartesianChart.Dispose();
                });
                cartesianChart = null;
            }
            this.Invoke(() => this.Controls.Clear());
            return Task.CompletedTask;
        }

    }
}
