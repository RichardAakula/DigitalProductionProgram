using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DigitalProductionProgram.Log
{
    internal partial class MonitorApiPerformanceForm : Form
    {
        private readonly List<LoopResult> _results = new();
        private List<QueryDefinition> _queries;
        private List<FactoryDefinition> _factories;

        private QueryDefinition? _lastQuery;
        private FactoryDefinition? _lastFactory;
        private DateTime _lastRunAt;

        private System.Windows.Forms.Timer _timeModeTimer;
        private DateTime _timeModeEndTime;
        private int _timeModeIntervalSeconds;

        // ✅ LIVECHARTS SERIES
        private LineSeries<double> _chartSeries;
        private List<string> _chartLabels; // ✅ LÄGG TILL DENNA

        private System.Windows.Forms.Timer _countdownTimer; // ✅ NYT - separat timer för nedräkning
        private int _secondsUntilNextExecution; // ✅ NYT

        // ✅ NYT - Track om test är igång
        private bool _isTestRunning = false;

        public MonitorApiPerformanceForm()
        {
            InitializeComponent();
        }

        private void MonitorApiPerformanceForm_Load(object sender, EventArgs e)
        {
            _queries = new List<QueryDefinition>
            {
                new("Top 100 PartNumbers", () =>
                {
                    var rows = Utilities.GetFromMonitor<Inventory.Parts>("top=100");
                    return rows?.Count ?? -1;
                }),
                new("Top 1000 PartNumbers", () =>
                {
                    var rows = Utilities.GetFromMonitor<Inventory.Parts>("top=1000");
                    return rows?.Count ?? -1;
                }),
                new("Top 5000 PartNumbers", () =>
                {
                    var rows = Utilities.GetFromMonitor<Inventory.Parts>("top=5000");
                    return rows?.Count ?? -1;
                })
            };

            _factories = new List<FactoryDefinition>
            {
                new("Godby", Monitor.Monitor.Factory.Godby, "001.1"),
                new("Holding", Monitor.Monitor.Factory.Holding, "003.1"),
                new("Thailand", Monitor.Monitor.Factory.Thailand, "010.1"),
                new("Valley Forge", Monitor.Monitor.Factory.ValleyForge, "012.1")
            };

            label_TimeRemaining.Visible = false;
            LoadDefaults();
            SetupRadioButtons();
            InitializeChart(); // ✅ NYT
        }

        private void LoadDefaults()
        {
            cb_Factory.DataSource = _factories;
            cb_Factory.DisplayMember = nameof(FactoryDefinition.DisplayName);

            cb_Query.DataSource = _queries;
            cb_Query.DisplayMember = nameof(QueryDefinition.DisplayName);

            var currentFactory = _factories.Find(f => f.Factory == Monitor.Monitor.factory) ?? _factories[0];
            cb_Factory.SelectedItem = currentFactory;
            cb_Query.SelectedIndex = 0;
            label_Summary.Text = @"Ingen körning ännu.";
        }

        // ✅ INITIERA CHART
        private void InitializeChart()
        {
            if (chart1 == null) return;

            _chartLabels = new List<string>(); // ✅ INITIERA LABELS

            _chartSeries = new LineSeries<double>
            {
                Name = "Response Time (ms)",
                Values = new ObservableCollection<double>(),
                Stroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 2 },
                GeometrySize = 4,
                GeometryFill = new SolidColorPaint(SKColors.Green)
            };

            chart1.Series = new ISeries[] { _chartSeries };

            // ✅ TILLDELA REFERENS TILL LABELS
            var xAxis = new Axis
            {
                Name = "Iteration",
                Labels = _chartLabels
            };

            var yAxis = new Axis
            {
                Name = "Time (ms)",
                MinLimit = 0
            };

            chart1.XAxes = new Axis[] { xAxis };
            chart1.YAxes = new Axis[] { yAxis };
        }
        private void SetupRadioButtons()
        {
            radioLoopMode.Checked = true;
            radioLoopMode.CheckedChanged += RadioMode_CheckedChanged;
            radioTimeMode.CheckedChanged += RadioMode_CheckedChanged;
        }

        private void RadioMode_CheckedChanged(object sender, EventArgs e)
        {
            // ✅ EXPLICIT KONTROLL - inte bara baserat på isLoopMode
            if (radioLoopMode.Checked)
            {
                // LOOP MODE - visa dessa
                num_Loops.Visible = true;
                label_Loops.Visible = true;

                // Dölj Time Mode kontroller
                num_TimeMinutes.Visible = false;
                num_IntervalSeconds.Visible = false;
                label_TimeMinutes.Visible = false;
                label_IntervalSeconds.Visible = false;
                label_TimeRemaining.Visible = false;
            }
            else if (radioTimeMode.Checked)
            {
                // TIME MODE - visa dessa
                num_TimeMinutes.Visible = true;
                num_IntervalSeconds.Visible = true;
                label_TimeMinutes.Visible = true;
                label_IntervalSeconds.Visible = true;
                label_TimeRemaining.Visible = true;

                // Dölj Loop Mode kontroller
                num_Loops.Visible = false;
                label_Loops.Visible = false;
            }
        }

        private async void btn_Run_Click(object sender, EventArgs e)
        {
            _isTestRunning = true; // ✅ SÄTT FLAG
            
            pbar_ProgressBar.Visible = true;
            if (radioLoopMode.Checked)
                await RunLoopModeAsync();
            else
                await RunTimeModeAsync();
        }
        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExportCsv();
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            _isTestRunning = false; // ✅ STANNA TESTET

            // Stoppa och rensa timers
            if (_countdownTimer != null)
            {
                _countdownTimer.Stop();
                _countdownTimer.Dispose();
                _countdownTimer = null;
            }

            if (_timeModeTimer != null)
            {
                _timeModeTimer.Stop();
                _timeModeTimer.Dispose();
                _timeModeTimer = null;
            }

            label_TimeRemaining.Visible = false;

            // ✅ NOLLSTÄLL PROGRESSBAR OCH LISTVIEW
            pbar_ProgressBar.Value = 0;
            lv_Results.Items.Clear();
            
            // Uppdatera UI
            UpdateSummary();
            btn_Export.Enabled = _results.Count > 0;
            SetControlsEnabled(true);
        }

        private async Task RunLoopModeAsync()
        {
            if (cb_Factory.SelectedItem is not FactoryDefinition factory || cb_Query.SelectedItem is not QueryDefinition query)
                return;

            var loops = (int)num_Loops.Value;
            await RunTestAsync(factory, query, loops, null, 0);
            pbar_ProgressBar.Visible = false;
        }

        // ✅ DENNA METOD SAKNADES!
        private async Task RunTimeModeAsync()
        {
            if (cb_Factory.SelectedItem is not FactoryDefinition factory || cb_Query.SelectedItem is not QueryDefinition query)
                return;

            int durationMinutes = (int)num_TimeMinutes.Value;
            int intervalSeconds = (int)num_IntervalSeconds.Value;

            await RunTestAsync(factory, query, -1, durationMinutes, intervalSeconds);
            pbar_ProgressBar.Visible = false;
        }

        private async Task RunTestAsync(FactoryDefinition factory, QueryDefinition query, int loops, int? durationMinutes, int intervalSeconds)
        {
            bool isTimeMode = durationMinutes.HasValue;

            _results.Clear();
            lv_Results.Items.Clear();

            // ✅ RENSA CHART RÄTT
            if (_chartSeries?.Values is ObservableCollection<double> values)
                values.Clear();
            if (_chartLabels != null)
                _chartLabels.Clear();

            btn_Export.Enabled = false;
            pbar_ProgressBar.Value = 0;

            if (isTimeMode && durationMinutes.HasValue)
                pbar_ProgressBar.Maximum = durationMinutes.Value * 60;
            else
                pbar_ProgressBar.Maximum = loops;

            SetControlsEnabled(false);

            var oldFactory = Monitor.Monitor.factory;
            var oldCompany = Database.MonitorCompany;
            var oldSession = Login_Monitor.sessionId;

            try
            {
                Monitor.Monitor.factory = factory.Factory;
                Database.MonitorCompany = factory.CompanyCode;
                Login_Monitor.sessionId = null;

                var loginResult = await Task.Run(() => Login_Monitor.Login_API(true));
                if (!loginResult.Success)
                {
                    InfoText.Show("Kunde inte logga in mot Monitor för vald factory.", CustomColors.InfoText_Color.Bad, "Monitor API");
                    return;
                }

                if (isTimeMode && durationMinutes.HasValue)
                {
                    await RunTimeModeLoopsAsync(query, durationMinutes.Value, intervalSeconds, pbar_ProgressBar);
                }
                else
                {
                    // ✅ LOOP MODE - KONTROLLERA _isTestRunning
                    for (var i = 1; i <= loops; i++)
                    {
                        // ✅ KONTROLLERA FLAGGAN
                        if (!_isTestRunning)
                        {
                            InfoText.Show("Testet avbröts av användaren.", CustomColors.InfoText_Color.Info, "Stoppad", this);
                            break; // Avbryt loopen
                        }

                        var sw = Stopwatch.StartNew();
                        var rowCount = await Task.Run(query.Execute);
                        sw.Stop();

                        var ok = rowCount > 0;
                        var result = new LoopResult(i, sw.ElapsedMilliseconds, ok, rowCount, DateTime.Now);
                        _results.Add(result);

                        AddResultToListView(result);
                        pbar_ProgressBar.Value = i;
                    }
                }

                _lastFactory = factory;
                _lastQuery = query;
                _lastRunAt = DateTime.Now;

                UpdateSummary();
                btn_Export.Enabled = _results.Count > 0;
            }
            finally
            {
                Monitor.Monitor.factory = oldFactory;
                Database.MonitorCompany = oldCompany;
                Login_Monitor.sessionId = oldSession;
                SetControlsEnabled(true);
            }
        }
        private async Task RunTimeModeLoopsAsync(QueryDefinition query, int durationMinutes, int intervalSeconds, ProgressBar progressBar)
        {
            _timeModeEndTime = DateTime.Now.AddMinutes(durationMinutes);
            _timeModeIntervalSeconds = intervalSeconds;
            int iteration = 0;

            iteration++;
            await ExecuteAndRecordAsync(query, iteration);
            progressBar.Value = 1;

            // ✅ STARTA NEDRÄKNINGSTIMER (uppdaterar varje sekund)
            _secondsUntilNextExecution = intervalSeconds;
            _countdownTimer = new System.Windows.Forms.Timer();
            _countdownTimer.Interval = 1000; // 1 sekund
            _countdownTimer.Tick += (s, e) =>
            {
                // ✅ KONTROLLERA FLAGGAN
                if (!_isTestRunning)
                {
                    _countdownTimer.Stop();
                    _countdownTimer.Dispose();
                    SetControlsEnabled(true);
                    UpdateSummary();
                    btn_Export.Enabled = _results.Count > 0;
                    label_TimeRemaining.Visible = false;
                    return;
                }

                _secondsUntilNextExecution--;

                // ✅ UPPDATERA LABEL MED NEDRÄKNING
                if (label_TimeRemaining != null)
                {
                    label_TimeRemaining.Text = @$"Nästa anrop om: {_secondsUntilNextExecution} sek";
                }

                // ✅ NÄR NEDRÄKNINGEN NÅTT 0 - KÖR NÄSTA ANROP
                if (_secondsUntilNextExecution <= 0)
                {
                    _countdownTimer.Stop();

                    // Kolla om tiden är slut
                    if (DateTime.Now >= _timeModeEndTime)
                    {
                        _countdownTimer.Dispose();
                        SetControlsEnabled(true);
                        UpdateSummary();
                        btn_Export.Enabled = _results.Count > 0;
                        label_TimeRemaining.Visible = false;
                        return;
                    }

                    // ✅ KÖR NÄSTA ANROP
                    iteration++;
                    _ = ExecuteAndRecordAsync(query, iteration);

                    // ✅ ÅTERSTÄLL NEDRÄKNINGEN
                    _secondsUntilNextExecution = intervalSeconds;
                    _countdownTimer.Start();

                    // Uppdatera progressbar
                    int secondsRemaining = (int)(_timeModeEndTime - DateTime.Now).TotalSeconds;
                    int secondsElapsed = durationMinutes * 60 - secondsRemaining;
                    progressBar.Value = Math.Min(secondsElapsed, progressBar.Maximum);
                }
            };

            label_TimeRemaining.Visible = true;
            _countdownTimer.Start();
        }
        private async Task ExecuteAndRecordAsync(QueryDefinition query, int iteration)
        {
            var sw = Stopwatch.StartNew();
            var rowCount = await Task.Run(query.Execute);
            sw.Stop();

            var ok = rowCount > 0;
            var result = new LoopResult(iteration, sw.ElapsedMilliseconds, ok, rowCount, DateTime.Now);
            _results.Add(result);

            this.Invoke(() => AddResultToListView(result));
        }

        private void AddResultToListView(LoopResult result)
        {
            var item = new ListViewItem(result.Iteration.ToString());
            item.SubItems.Add(result.ElapsedMilliseconds.ToString());
            item.SubItems.Add(result.Success ? "OK" : "Fel");
            item.SubItems.Add(result.RowCount.ToString());
            item.SubItems.Add(result.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            item.SubItems.Add("Hämtar data från Monitor API");
            lv_Results.Items.Add(item);

            // ✅ UPPDATERA CHART
            AddPointToChart(result);

            if (lv_Results.Items.Count > 0)
                lv_Results.EnsureVisible(lv_Results.Items.Count - 1);
        }
        private void AddPointToChart(LoopResult result)
        {
            if (_chartSeries == null) return;

            try
            {
                // ✅ LÄGG TILL VÄRDE - Cast to ObservableCollection for Add()
                if (_chartSeries.Values is ObservableCollection<double> values)
                {
                    values.Add(result.ElapsedMilliseconds);

                    // ✅ UPPDATERA LABELS GENOM ATT LÄGGA TILL I LISTAN
                    if (_chartLabels != null)
                        _chartLabels.Add(result.Iteration.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Chart error: {ex.Message}");
            }
        }

       

        private void UpdateSummary()
        {
            if (_results.Count == 0)
            {
                label_Summary.Text = @"Ingen data.";
                return;
            }

            var valid = _results.FindAll(r => r.Success).ConvertAll(r => r.ElapsedMilliseconds);
            if (valid.Count == 0)
            {
                label_Summary.Text = @"Alla loopar misslyckades.";
                return;
            }

            var min = valid.Min();
            var max = valid.Max();
            var avg = valid.Average();
            var failed = _results.Count(r => !r.Success);

            label_Summary.Text = string.Format(
                 @"Factory: {0} ({1}) | Fråga: {2} | Körningar: {3} | Fel: {4} | Min: {5} ms | Max: {6} ms | Average: {7:F2} ms",
                _lastFactory?.DisplayName,
                _lastFactory?.CompanyCode,
                _lastQuery?.DisplayName,
                _results.Count,
                failed,
                min,
                max, avg);
        }

        private void ExportCsv()
        {
            if (_results.Count == 0 || _lastFactory is null || _lastQuery is null)
                return;

            var valid = _results.FindAll(r => r.Success).ConvertAll(r => r.ElapsedMilliseconds);
            var min = valid.Count > 0 ? valid.Min() : 0;
            var max = valid.Count > 0 ? valid.Max() : 0;
            var avg = valid.Count > 0 ? valid.Average() : 0;

            var dt = new DataTable();
            dt.Columns.Add("RunAt");
            dt.Columns.Add("Factory");
            dt.Columns.Add("MonitorCompany");
            dt.Columns.Add("Query");
            dt.Columns.Add("Loop");
            dt.Columns.Add("ElapsedMs");
            dt.Columns.Add("Success");
            dt.Columns.Add("Rows");
            dt.Columns.Add("MinMs");
            dt.Columns.Add("MaxMs");
            dt.Columns.Add("AverageMs");

            foreach (var result in _results)
            {
                dt.Rows.Add(
                    _lastRunAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    _lastFactory.DisplayName,
                    _lastFactory.CompanyCode,
                    _lastQuery.DisplayName,
                    result.Iteration,
                    result.ElapsedMilliseconds,
                    result.Success,
                    result.RowCount,
                    min,
                    max,
                    avg.ToString("F2"));
            }

            var sb = new StringBuilder();
            Get_Protocol_Data.ConvertDataTableTo_csv(dt, sb);
            var fileName = string.Format(
                "MonitorApiPerformance_{0}_{1:yyyyMMdd_HHmmss}.csv",
                _lastFactory.DisplayName, DateTime.Now);
            Get_Protocol_Data.Save_csvFile(sb, fileName);
        }

        private void SetControlsEnabled(bool enabled)
        {
            cb_Factory.Enabled = enabled;
            cb_Query.Enabled = enabled;
            num_Loops.Enabled = enabled;
            num_TimeMinutes.Enabled = enabled;
            num_IntervalSeconds.Enabled = enabled;
            radioLoopMode.Enabled = enabled;
            radioTimeMode.Enabled = enabled;
            btn_Run.Enabled = enabled;
            btn_Stop.Enabled = !enabled; // ✅ VISA STOPPKNAPPEN NÄR TEST KÖR
            btn_Export.Enabled = enabled && _results.Count > 0;
        }

        private sealed class QueryDefinition(string displayName, Func<int> execute)
        {
            public string DisplayName { get; } = displayName;
            public Func<int> Execute { get; } = execute;
        }

        private sealed class FactoryDefinition(string displayName, Monitor.Monitor.Factory factory, string companyCode)
        {
            public string DisplayName { get; } = displayName;
            public Monitor.Monitor.Factory Factory { get; } = factory;
            public string CompanyCode { get; } = companyCode;
        }

        private sealed class LoopResult(int iteration, long elapsedMilliseconds, bool success, int rowCount, DateTime timestamp)
        {
            public int Iteration { get; } = iteration;
            public long ElapsedMilliseconds { get; } = elapsedMilliseconds;
            public bool Success { get; } = success;
            public int RowCount { get; } = rowCount;
            public DateTime Timestamp { get; } = timestamp;
        }

       
    }
}