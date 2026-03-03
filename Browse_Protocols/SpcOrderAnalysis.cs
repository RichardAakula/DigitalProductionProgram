using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.Protocols.Protocol;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;

namespace DigitalProductionProgram.Browse_Protocols
{
    public partial class SpcOrderAnalysis : Form
    {
        private bool _initializingOrders = false;
        private readonly CartesianChart cartesianChart;
        private readonly List<MeasurementPoint> _measurements;
        private Dictionary<string, SeriesData> _seriesByParameter = new();
        //private SeriesData? GetSingleVisibleSeriesData()
        //{
        //    // Hämta ibockade parameternamn
        //    var checkedParams = new HashSet<string>(
        //        chkList_Parameters.CheckedItems.Cast<string>()
        //    );

        //    // Filtrera på dictionary-nyckeln (parameternamn)
        //    var visible = _seriesByParameter
        //        .Where(kvp => checkedParams.Contains(kvp.Key))
        //        .Select(kvp => kvp.Value)
        //        .ToList();

        //    return visible.Count == 1 ? visible[0] : null;
        //}
        private SeriesData? GetSingleVisibleSeriesData()
        {
            var visible = _seriesByParameter.Values
                .Where(v => v.HostPanel != null && v.HostPanel.Visible)
                .ToList();

            return visible.Count == 1 ? visible[0] : null;
        }
        public SpcOrderAnalysis(OrderSpcRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            InitializeComponent();
            chkList_Parameters.CheckOnClick = true; // gör det smidigt att klicka
            chkList_Orders.ItemCheck += chkList_Orders_ItemCheck;

            flp_Charts.Resize += (s, e) =>
            {
                foreach (var sd in _seriesByParameter.Values)
                {
                    if (sd.HostPanel != null)
                    {
                        sd.HostPanel.Width =
                            flp_Charts.ClientSize.Width - 20;
                    }
                }
            };



        }

        

        //private void UpdateSPC(SeriesData? seriesData)
        //{
        //    if (seriesData == null || seriesData.Series?.Values == null)
        //    {
        //        ResetSpcLabels();
        //        this.Text = "SPC";
        //        return;
        //    }
        //    this.Text = $"SPC – {seriesData.ParameterName}";
        //    lbl_ParameterName.Text = seriesData.ParameterName;
        //    lbl_USL.Text = seriesData.Max?.ToString();
        //    lbl_NOM.Text = seriesData.Nom?.ToString();
        //    lbl_LSL.Text = seriesData.Min?.ToString();

            
        //    var valueList = ((LineSeries<ObservableMeasurementPoint>)seriesData.Series)
        //        .Values
        //        .Cast<ObservableMeasurementPoint>()
        //        .Select(mp => (double?)mp.Val)
        //        .ToList();

            
        //    var spc = BrowseMeasureProtocols.SpcResult.Calculate(
        //        valueList,
        //        seriesData.ParameterName,
        //        null,
        //        seriesData.Min,
        //        seriesData.Max
        //    );

        //    lbl_Mean.Text = spc.Mean?.ToString("F3");
        //    lbl_Median.Text = spc.Median?.ToString();
        //    lbl_Min.Text = valueList.Min().ToString();
        //    lbl_Max.Text = valueList.Max().ToString();
        //    lbl_Range.Text = spc.Range?.ToString();
        //    lbl_StandardDeviation.Text = spc.StandardDeviation?.ToString("F3");
        //    lbl_Skewness.Text = spc.Skewness?.ToString("F3");
        //    lbl_Kurtosis.Text = spc.Kurtosis?.ToString("F3");
        //    lbl_Pp.Text = spc.Pp?.ToString("F3");
        //    lbl_Ppk.Text = spc.Ppk?.ToString("F3");
        //    lbl_PerformanceRatio.Text = spc.PerformanceRatio?.ToString("F2");
        //    lbl_TotalOrders.Text = $@"{spc.Count}";
        //    //lbl_TotalOrders.Text = @$"{seriesData.Measurements.Select(m => m.OrderNumber).Distinct().Count()}";
        //}
        private void UpdateSPCFor(SeriesData sd)
        {
            var test = sd.HostPanel;
            if (sd.SpcPanel == null)
                return;
            var valueList = ((LineSeries<ObservableMeasurementPoint>)sd.Series)
                    .Values
                    .Cast<ObservableMeasurementPoint>()
                    .Select(mp => (double?)mp.Val)
                    .ToList();

            var spc = BrowseMeasureProtocols.SpcResult.Calculate(
                valueList, sd.ParameterName, null, sd.Min, sd.Max);

            sd.SpcPanel.Controls.Clear();

            sd.SpcPanel.Controls.Add(new Label { Text = @$"Mean: {spc.Mean:F3}" });
            sd.SpcPanel.Controls.Add(new Label { Text = @$"Median: {spc.Mean:F3}" });
            sd.SpcPanel.Controls.Add(new Label { Text = @$"Min: {spc.Min}" });
            sd.SpcPanel.Controls.Add(new Label { Text = @$"Max: {spc.Max}" });
            sd.SpcPanel.Controls.Add(new Label { Text = @$"Ppk: {spc.Ppk:F3}" });
            sd.SpcPanel.Controls.Add(new Label { Text = @$"Orders: {spc.Count}" });
        }
        //private void UpdateSections()
        //{
        //    var visibleSeries = _seriesByParameter.Values
        //        .Where(x => x?.Series != null && x.Series.IsVisible)
        //        .ToList();

        //    int count = visibleSeries.Count;

        //    // Rensa alltid sections först
        //    cartesianChart.Sections = Array.Empty<RectangularSection>();
        //    ResetSpcLabels();

        //    // =========================
        //    // 0 serier
        //    // =========================
        //    if (count == 0)
        //    {
        //        cartesianChart.YAxes = new[]
        //        {
        //            new Axis
        //            {
        //                MinLimit = 0,
        //                MaxLimit = 1
        //            }
        //        };
        //        return;
        //    }

        //    // =========================
        //    // Flera serier (INGA LSL/USL)
        //    // =========================
        //    if (count > 1)
        //    {
        //        double globalMin = double.MaxValue;
        //        double globalMax = double.MinValue;

        //        foreach (var s in visibleSeries)
        //        {
        //            var values = ((LineSeries<ObservableMeasurementPoint>)s.Series)
        //                .Values.Cast<ObservableMeasurementPoint>()
        //                .Select(mp => mp.Val ?? double.NaN);

        //            if (!values.Any()) continue;

        //            var min = values.Min();
        //            var max = values.Max();

        //            if (min < globalMin) globalMin = min;
        //            if (max > globalMax) globalMax = max;
        //        }

        //        if (globalMin == double.MaxValue)
        //        {
        //            globalMin = 0;
        //            globalMax = 1;
        //        }

        //        double span = globalMax - globalMin;
        //        if (span <= 0) span = 1;

        //        double margin = span * 0.1;

        //        cartesianChart.YAxes = new[]
        //        {
        //            new Axis
        //            {
        //                MinLimit = globalMin - margin,
        //                MaxLimit = globalMax + margin
        //            }
        //        };

        //        return;
        //    }

        //    // =========================
        //    // Exakt 1 serie (visa LSL/USL)
        //    // =========================
        //    var single = visibleSeries.First();
            
        //    var valuesList = ((LineSeries<ObservableMeasurementPoint>)single.Series)
        //        .Values
        //        .Cast<ObservableMeasurementPoint>()
        //        .Select(m => m.Val ?? double.NaN)
        //        .ToList();



        //    if (!valuesList.Any())
        //        return;

        //    double dataMin = valuesList.Min();
        //    double dataMax = valuesList.Max();

        //    // Inkludera toleranser i axelberäkningen
        //    double effectiveMin = dataMin;
        //    double effectiveMax = dataMax;

        //    if (single.Min.HasValue)
        //        effectiveMin = Math.Min(effectiveMin, single.Min.Value);

        //    if (single.Max.HasValue)
        //        effectiveMax = Math.Max(effectiveMax, single.Max.Value);

        //    double spanSingle = effectiveMax - effectiveMin;
        //    if (spanSingle <= 0) spanSingle = 1;

        //    double marginSingle = spanSingle * 0.1;

        //    double yMin = effectiveMin - marginSingle;
        //    double yMax = effectiveMax + marginSingle;

        //    cartesianChart.YAxes = new[]
        //    {
        //        new Axis
        //        {
        //            MinLimit = yMin,
        //            MaxLimit = yMax
        //        }
        //    };

        //    var sections = new List<RectangularSection>();

        //    if (single.Min.HasValue)
        //    {
        //        sections.Add(new RectangularSection
        //        {
        //            Yi = yMin,
        //            Yj = single.Min.Value,
        //            Fill = new SolidColorPaint(new SKColor(255, 199, 206, 230))
        //        });
        //    }

        //    if (single.Max.HasValue)
        //    {
        //        sections.Add(new RectangularSection
        //        {
        //            Yi = single.Max.Value,
        //            Yj = yMax,
        //            Fill = new SolidColorPaint(new SKColor(255, 199, 206, 230))
        //        });
        //    }

        //    if (single.Min.HasValue && single.Max.HasValue)
        //    {
        //        sections.Add(new RectangularSection
        //        {
        //            Yi = single.Min.Value,
        //            Yj = single.Max.Value,
        //            Fill = new SolidColorPaint(new SKColor(198, 239, 206, 255))
        //        });
        //    }
        //    //var serie = visibleSeries[0];
        //    UpdateSPCFor(single);
        //   // UpdateSPC(single);
        //    cartesianChart.Sections = sections.ToArray();
        //}
        private void ApplySectionsAndYAxis(SeriesData sd)
{
    if (sd.Chart is null || sd.Series is not LineSeries<ObservableMeasurementPoint> ls) return;

    var values = ls.Values
        .Cast<ObservableMeasurementPoint>()
        .Select(v => v.Val ?? double.NaN)
        .Where(v => !double.IsNaN(v))
        .ToList();

    if (values.Count == 0)
    {
        sd.Chart.YAxes = new[]
        {
            new Axis { MinLimit = 0, MaxLimit = 1 }
        };
        sd.Chart.Sections = Array.Empty<RectangularSection>();
        return;
    }

    double dataMin = values.Min();
    double dataMax = values.Max();

    double effectiveMin = dataMin;
    double effectiveMax = dataMax;

    if (sd.Min.HasValue) effectiveMin = Math.Min(effectiveMin, sd.Min.Value);
    if (sd.Max.HasValue) effectiveMax = Math.Max(effectiveMax, sd.Max.Value);

    double span = effectiveMax - effectiveMin;
    if (span <= 0) span = 1;
    double margin = span * 0.10;

    double yMin = effectiveMin - margin;
    double yMax = effectiveMax + margin;

    sd.Chart.YAxes = new[] { new Axis { MinLimit = yMin, MaxLimit = yMax } };

    var sections = new List<RectangularSection>();

    // under LSL (röd)
    if (sd.Min.HasValue)
    {
        sections.Add(new RectangularSection
        {
            Yi = yMin,
            Yj = sd.Min.Value,
            Fill = new SolidColorPaint(new SKColor(255, 199, 206, 230))
        });
    }

    // över USL (röd)
    if (sd.Max.HasValue)
    {
        sections.Add(new RectangularSection
        {
            Yi = sd.Max.Value,
            Yj = yMax,
            Fill = new SolidColorPaint(new SKColor(255, 199, 206, 230))
        });
    }

    // inom tolerans (grön)
    if (sd.Min.HasValue && sd.Max.HasValue)
    {
        sections.Add(new RectangularSection
        {
            Yi = sd.Min.Value,
            Yj = sd.Max.Value,
            Fill = new SolidColorPaint(new SKColor(198, 239, 206, 255))
        });
    }

    sd.Chart.Sections = sections.ToArray();
    sd.Chart.Update();
}
        private void UpdateChartForCheckedOrders(ItemCheckEventArgs e)
        {
            if (_initializingOrders) return;

            // Hämta ibockade OrderID
            var checkedOrders = new HashSet<int>();
            for (int i = 0; i < chkList_Orders.Items.Count; i++)
            {
                bool isChecked = (i == e.Index)
                    ? e.NewValue == CheckState.Checked
                    : chkList_Orders.GetItemChecked(i);

                if (isChecked && chkList_Orders.Items[i] is OrderInfo order)
                    checkedOrders.Add(order.OrderID);
            }

            foreach (var sd in _seriesByParameter.Values)
            {
                // Filtrera mätpunkter
                var filtered = sd.Measurements
                    .Where(m => m.Value.HasValue && checkedOrders.Contains(m.OrderID))
                    .ToList();

                // Bygg om ObservableMeasurementPoint med ny X-indexering
                var obsValues = new ObservableCollection<SpcOrderAnalysis.ObservableMeasurementPoint>();
                int x = 0;
                foreach (var m in filtered)
                {
                    obsValues.Add(new SpcOrderAnalysis.ObservableMeasurementPoint(x, m.Value!.Value, m));
                    x++;
                }

                if (sd.Series is LineSeries<ObservableMeasurementPoint> ls)
                    ls.Values = obsValues;

                // Sätt om Y-axel + sektioner för det här chartet
                UpdateSPCFor(sd);
                ApplySectionsAndYAxis(sd);
            }

            // Uppdatera SPC för "enda synliga" (om exakt ett kort är ibockat)
            var singleVisible = GetSingleVisibleSeriesData();
            //UpdateSPC(singleVisible);
        }

        private void ResetSpcLabels()
        {
            lbl_ParameterName.Text = "Multiple Series";
            lbl_USL.Text = @"N/A";
            lbl_NOM.Text = @"N/A";
            lbl_LSL.Text = @"N/A";
            lbl_Mean.Text = @"N/A";
            lbl_Median.Text = @"N/A";
            lbl_Min.Text = @"N/A";
            lbl_Max.Text = @"N/A";
            lbl_Range.Text = @"N/A";
            lbl_StandardDeviation.Text = @"N/A";
            lbl_Skewness.Text = @"N/A";
            lbl_Kurtosis.Text = @"N/A";
            lbl_Pp.Text = @"N/A";
            lbl_Ppk.Text = @"N/A";
            lbl_PerformanceRatio.Text = @"N/A";
            lbl_TotalOrders.Text = @"N/A";
        }
        
        public class ObservableMeasurementPoint(double x, double y, MeasurementPoint mp) : ObservablePoint(x, y)
        {
            public int OrderID { get; } = mp.OrderID;
            public string OrderNumber { get; } = mp.OrderNumber;
            public int StartUp { get; } = mp.StartUp;
            public double? Val { get; } = mp.Value;
        }


        public void AddParameter(Module.ParameterInfo parameter, List<OrderInfo> orders)
        {
            if (_seriesByParameter.ContainsKey(parameter.Name))
                return; // redan tillagd

            var orderIds = orders.Select(o => o.OrderID).ToList();
            var measurements = LoadMeasurements(parameter.ProtocolDescriptionId, orderIds);

            var hasValues = measurements.Any(m => m.Value.HasValue);
            if (!hasValues) return;

            // Bygg värden (X = löpindex för snygg linje även när vi filtrerar)
            var obsValues = new ObservableCollection<ObservableMeasurementPoint>();
            int x = 0;
            foreach (var mp in measurements.Where(m => m.Value.HasValue))
            {
                obsValues.Add(new ObservableMeasurementPoint(x, mp.Value!.Value, mp));
                x++;
            }

            var series = new LineSeries<ObservableMeasurementPoint>
            {
                Name = string.Empty,               // ingen titel i tooltip
                Fill = null,
                GeometrySize = 2,
                Values = obsValues,
                YToolTipLabelFormatter = cp =>
                {
                    var mp = (ObservableMeasurementPoint)cp.Model;
                    var nl = Environment.NewLine; // CRLF på Windows

                    return nl +                   // tom första rad
                           $"OrderNr: {mp.OrderNumber}{nl}" +
                           $"StartUp: {mp.StartUp}{nl}" +
                           $"Value: {mp.Val}";
                }
            };

            // --- Skapa en "kort-panel" per parameter: Label (rubrik) + Chart ---
            var host = new Panel
            {
                Margin = new Padding(3),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,   // valfritt, men bra för att “synas”
                Height = 300,                     // valfritt – höjd styr du själv
                Width = flp_Charts.ClientSize.Width - 20
            };
            host.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            
            var spcPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 180,
                Padding = new Padding(6)
            };
            
            

            var header = new Label
            {
                Text = parameter.Name,
                Dock = DockStyle.Top,
                AutoSize = false,
                Height = 28,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font(Font, FontStyle.Bold)
            };

            var chart = new CartesianChart
            {
                Dock = DockStyle.Fill,

                //LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden,
                Series = [series]
            };

            host.Controls.Add(chart);
            //host.Controls.Add(spcPanel);
            host.Controls.Add(header);
            flp_Charts.Controls.Add(host);

            var sd = new SeriesData 
            {
                ParameterName = parameter.Name,
                ProtocolDescriptionId = parameter.ProtocolDescriptionId,
                Series = series,
                Chart = chart,
                HostPanel = host,
                SpcPanel = spcPanel,
                Min = parameter.Min,
                Nom = parameter.Nom,
                Max = parameter.Max,
                Measurements = measurements
            };

            _seriesByParameter.Add(parameter.Name, sd);

            // Sätt Y-axel & sektioner för den här (enda) serien/chartet
            ApplySectionsAndYAxis(sd);

            // Lägg till parameter i chkList_Parameters (styr synlighet av KORTET)
            if (!chkList_Parameters.Items.Contains(parameter.Name))
                chkList_Parameters.Items.Add(parameter.Name, true);

            // Fyll orderlistan
            _initializingOrders = true;
            chkList_Orders.Items.Clear();
            foreach (var order in orders) chkList_Orders.Items.Add(order, true);
            _initializingOrders = false;

            // Uppdatera SPC för denna (om du vill att senast tillagda blir aktiv)
            UpdateSPCFor(sd);
            //UpdateSPC(sd);
}
        private List<MeasurementPoint> LoadMeasurements(int? protocolDescriptionId, List<int> orderid)
        {
            var list = new List<MeasurementPoint>();

            Database.ExecuteSafe(con =>
            {
                var query = """
                                SELECT 
                                    main.OrderId,
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
                                ORDER BY main.OrderId DESC, Uppstart";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@protocoldescriptionid", protocolDescriptionId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var valueObj = reader["Value"];
                    double? value = valueObj == DBNull.Value ? null : Convert.ToDouble(valueObj);
                    if (value != null)
                    {
                        list.Add(new MeasurementPoint
                        {
                            OrderID = Convert.ToInt16(reader["OrderId"]),
                            OrderNumber = reader["OrderNr"].ToString(),
                            StartUp = Convert.ToInt16(reader["Uppstart"]),
                            Value = value
                        });
                    }
                }
            });

            return list;
        }
        private void chkList_Parameters_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var paramName = chkList_Parameters.Items[e.Index]?.ToString();
            if (paramName == null) return;

            if (!_seriesByParameter.TryGetValue(paramName, out var sd)) return;

            // Växla synlighet på hela kortet när användaren klickar
            // (NewValue är framtida tillstånd, så vi sätter Visible = Checked)
            bool willBeChecked = (e.NewValue == CheckState.Checked);
            // Fördröjd toggle tills efter eventet: använd BeginInvoke
            //BeginInvoke(new Action(() =>
           // {
                if (sd.HostPanel != null) sd.HostPanel.Visible = willBeChecked;

                // Uppdatera SPC om exakt ett kort är synligt
                var single = GetSingleVisibleSeriesData();
                if (single != null)
                    UpdateSPCFor(single);
            //}));
        }
        

        private void chkList_Orders_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_initializingOrders)
                return; // ignorera eventet under initialisering
            UpdateChartForCheckedOrders(e);
        }
    }

    public class MeasurementPoint
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public int StartUp { get; set; }
        public double? Value { get; set; }
    }
    public class SeriesData
    {
        public ISeries? Series { get; set; }
        public CartesianChart? Chart { get; set; }
        public Panel? SpcPanel { get; set; }
        public Panel? HostPanel { get; set; } 
        public string ParameterName { get; set; } = "";
        public int? ProtocolDescriptionId { get; set; }
        public double? Min { get; set; }
        public double? Nom { get; set; }
        public double? Max { get; set; }
        public List<MeasurementPoint> Measurements { get; set; }
    }
}
