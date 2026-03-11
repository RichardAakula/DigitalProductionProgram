using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.Övrigt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.MainWindow
{
    internal partial class MonitorApiPerformanceForm : Form
    {
        private readonly List<LoopResult> _results = new();
        private List<QueryDefinition> _queries;
        private List<FactoryDefinition> _factories;

        private QueryDefinition? _lastQuery;
        private FactoryDefinition? _lastFactory;
        private DateTime _lastRunAt;


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
                new( "Thailand", Monitor.Monitor.Factory.Thailand, "010.1"),
                new( "Valley Forge", Monitor.Monitor.Factory.ValleyForge, "012.1")
            };

            LoadDefaults();
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

        private async void btn_Run_Click(object sender, EventArgs e)
        {
            await RunPerformanceTestAsync();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExportCsv();
        }
        private async Task RunPerformanceTestAsync()
        {
            if (cb_Factory.SelectedItem is not FactoryDefinition factory || cb_Query.SelectedItem is not QueryDefinition query)
                return;

            var loops = (int)num_Loops.Value;
            _results.Clear();
            lv_Results.Items.Clear();
            btn_Export.Enabled = false;
            pbar_ProgressBar.Minimum = 0;
            pbar_ProgressBar.Maximum = loops;
            pbar_ProgressBar.Value = 0;

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

                for (var i = 1; i <= loops; i++)
                {
                    var sw = Stopwatch.StartNew();
                    var ok = true;

                    var rowCount = await Task.Run(query.Execute);
                    //var parts = await List_PartNumber();
                    //var rowCount = parts.Count;
                    if (rowCount == 0)
                        ok = false;
                    sw.Stop();


                    var result = new LoopResult(i, sw.ElapsedMilliseconds, ok, rowCount, DateTime.Now);
                    _results.Add(result);

                    var item = new ListViewItem(result.Iteration.ToString());
                    item.SubItems.Add(result.ElapsedMilliseconds.ToString());
                    item.SubItems.Add(result.Success ? "OK" : "Fel");
                    item.SubItems.Add(result.RowCount.ToString());
                    item.SubItems.Add(result.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    item.SubItems.Add("Hämtar 1000 PartNumber från Inventory.Parts");
                    lv_Results.Items.Add(item);

                    pbar_ProgressBar.Value = i;
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
            btn_Run.Enabled = enabled;
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
