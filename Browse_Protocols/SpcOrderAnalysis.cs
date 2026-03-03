using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using OpenTK.Audio.OpenAL;
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
        private readonly CartesianChart? cartesianChart;
        private readonly Dictionary<string, SeriesData> _seriesByParameter = new();
        private SeriesData? GetSingleVisibleSeriesData()
        {
            var visible = _seriesByParameter.Values
                .Where(v => v.HostPanel != null && v.HostPanel.Visible)
                .ToList();

            return visible.Count == 1 ? visible[0] : null;
        }
        
        private bool IsMatch(string? text, string? pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern)) return true;
            if (string.IsNullOrEmpty(text)) return false;

            // Dela upp pattern på , ; eller mellanslag
            var parts = pattern
                .Split([',', ';'], StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .Where(p => p.Length > 0)
                .ToArray();

            if (parts.Length == 0)
                return true;

            foreach (var p in parts)
            {
                // Om inget wildcard används → gör Contains(…) jämförelse
                if (!p.Contains('*') && !p.Contains('?'))
                {
                    if (text.IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)
                        return true;
                    continue;
                }

                // Wildcard-stöd
                var rx = "^" + System.Text.RegularExpressions.Regex.Escape(p)
                    .Replace("\\*", ".*")
                    .Replace("\\?", ".") + "$";

                if (System.Text.RegularExpressions.Regex.IsMatch(
                        text, rx, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }




        public SpcOrderAnalysis(OrderSpcRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            InitializeComponent();
            chkList_Parameters.CheckOnClick = true; // gör det smidigt att klicka
            chkList_Orders.ItemCheck += chkList_Orders_ItemCheck;

            tb_FilterProdLine.TextChanged += (s, e) =>
                ApplyOrderFilters(tb_FilterRevNr.Text, tb_FilterProdLine.Text, checkMatches: true, uncheckOthers: false);
            tb_FilterRevNr.TextChanged += (s, e) =>
                ApplyOrderFilters(tb_FilterRevNr.Text, tb_FilterProdLine.Text, checkMatches: true, uncheckOthers: false);

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

           
            if (sd.SpcPanel == null) 
                return;

            // Töm och förbered
            sd.SpcPanel.SuspendLayout();
            sd.SpcPanel.Controls.Clear();

            // Skapa en tabell med 2 kolumner och auto-rader
            var tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                ColumnCount = 2,
                RowCount = 0,
                AutoSize = false,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            // Kolumnbredder: caption auto, värde fyll
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));     // caption
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); // value (tar resten)

            // En liten lokal helper för att lägga till rader
            void AddRow(string caption, string value)
            {
                int row = tlp.RowCount++;
                tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                var lblCaption = new Label
                {
                    Text = caption,
                    AutoSize = true,
                    ForeColor = CustomColors.Teal_Font,
                    Margin = new Padding(0, 0, 6, 4), // lite luft till höger + nederkant
                    TextAlign = ContentAlignment.MiddleLeft
                };

                var lblValue = new Label
                {
                    Text = value,
                    AutoSize = true,
                    ForeColor = CustomColors.Teal_Font,
                    Margin = new Padding(0, 0, 0, 4),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                tlp.Controls.Add(lblCaption, 0, row);
                tlp.Controls.Add(lblValue,   1, row);
            }

            // Formatera tal (justera efter din standard)
            string F3(double? d) => d.HasValue ? d.Value.ToString("F3") : "–";
            string F2(double? d) => d.HasValue ? d.Value.ToString("F2") : "–";
            string F0(double? d) => d.HasValue ? d.Value.ToString("F0") : "–";
    
            // Bygg rader – USL/NOM/LSL först (dina sd‑gränser)
            AddRow("USL:",    F2(sd.Max));
            AddRow("NOM:",    F2(sd.Nom));
            AddRow("LSL:",    F2(sd.Min));
            AddRow("Total Orders:", F0(spc.Count)); //F0(sd.Measurements.Count));
        
            // Sedan beräknade värden
            AddRow("Mean:",   F3(spc.Mean));
            AddRow("Median:", F3(spc.Median));       // <-- fixad, var spc.Mean hos dig
            AddRow("Min:",    spc.Min.HasValue ? spc.Min.Value.ToString("F2") : "–");
            AddRow("Max:",    spc.Max.HasValue ? spc.Max.Value.ToString("F2") : "–");
            AddRow("Range:",  spc.Range.HasValue ? spc.Range.Value.ToString("F2") : "–");
            AddRow("StandardDeviation:",  spc.StandardDeviation.HasValue ? spc.StandardDeviation.Value.ToString("F3") : "–");
            AddRow("Skewness:",    F3(spc.Skewness));
            AddRow("Kurtosis:",    F3(spc.Kurtosis));
            AddRow("Pp:",    F3(spc.Pp));
            AddRow("Ppk:",    F3(spc.Ppk));
            AddRow("PerformanceRatio:",    F3(spc.PerformanceRatio));

            // Lägg in tabellen i panelen
            sd.SpcPanel.Controls.Add(tlp);
            sd.SpcPanel.ResumeLayout();

        }
       
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

        private bool _updatingOrderChecks = false;
        private void ApplyOrderFilters(string? revPattern, string? linePattern, bool checkMatches, bool uncheckOthers)
        {
            try
            {
                _updatingOrderChecks = true;
                chkList_Orders.BeginUpdate();

                for (int i = 0; i < chkList_Orders.Items.Count; i++)
                {
                    if (chkList_Orders.Items[i] is not OrderInfo o) continue;

                    bool match =
                        IsMatch(o.RevNr,       revPattern) &&
                        IsMatch(o.ProdLine,    linePattern);

                    if (match)
                    {
                        if (!chkList_Orders.GetItemChecked(i))
                            chkList_Orders.SetItemChecked(i, true);
                    }
                    else 
                    {
                        if (chkList_Orders.GetItemChecked(i))
                            chkList_Orders.SetItemChecked(i, false);
                    }
                }
            }
            finally
            {
                chkList_Orders.EndUpdate();
                _updatingOrderChecks = false;
            }

            // Trigga din grafuppdatering efter programmatisk ändring
            UpdateChartForCheckedOrders(new ItemCheckEventArgs(-1, CheckState.Unchecked, CheckState.Unchecked));
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
                Height = 320,                     // valfritt – höjd styr du själv
                Width = flp_Charts.ClientSize.Width - 20
            };
            
            var spcPanel = new Panel()
            {
                Dock = DockStyle.Left,
                AutoScroll = false,
                BackColor = CustomColors.Teal,
                Width = 190,
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
                Series = [series]
            };

            host.Controls.Add(chart);
            host.Controls.Add(spcPanel);
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
            foreach (var order in orders) 
                chkList_Orders.Items.Add(order, true);
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

            bool willBeChecked = (e.NewValue == CheckState.Checked);
                if (sd.HostPanel != null) sd.HostPanel.Visible = willBeChecked;

            // Uppdatera SPC om exakt ett kort är synligt
            var single = GetSingleVisibleSeriesData();
            if (single != null)
                UpdateSPCFor(single);
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
