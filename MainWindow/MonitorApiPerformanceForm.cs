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
        private readonly List<QueryDefinition> _queries;
        private readonly List<FactoryDefinition> _factories;
        private readonly ComponentResourceManager _resources = new(typeof(MonitorApiPerformanceForm));

        private QueryDefinition? _lastQuery;
        private FactoryDefinition? _lastFactory;
        private DateTime _lastRunAt;

        public MonitorApiPerformanceForm()
        {
            InitializeComponent();

            _queries = new List<QueryDefinition>
            {
                new(R("Query.Units", "Top 1000 PartNumbers"), () =>
                {
                    var rows = Utilities.GetFromMonitor<Inventory.Parts>("top=1000");
                    return rows?.Count ?? -1;
                }),
                new(R("Query.Orders", "ManufacturingOrders (top 1)"), () =>
                {
                    var rows = Utilities.GetFromMonitor<Manufacturing.ManufacturingOrders>("top=1", "select=Id,OrderNumber");
                    return rows?.Count ?? -1;
                }),
                new(R("Query.PartsHeavy", "Inventory.Parts (top 500, heavy)"), () =>
                {
                    var rows = Utilities.GetFromMonitor<Inventory.Parts>("top=500", "select=Id,PartNumber,Description,ExtraDescription");
                    return rows?.Count ?? -1;
                })
            };

            _factories = new List<FactoryDefinition>
            {
                new(R("Factory.Godby", "Godby"), Monitor.Monitor.Factory.Godby, "001.1"),
                new(R("Factory.Holding", "Holding"), Monitor.Monitor.Factory.Holding, "003.1"),
                new(R("Factory.Thailand", "Thailand"), Monitor.Monitor.Factory.Thailand, "010.1"),
                new(R("Factory.ValleyForge", "Valley Forge"), Monitor.Monitor.Factory.ValleyForge, "012.1")
            };

            LoadDefaults();
        }

        private string R(string key, string fallback)
        {
            var value = _resources.GetString(key);
            return string.IsNullOrWhiteSpace(value) ? fallback : value;
        }

        private void LoadDefaults()
        {
            cbFactory.DataSource = _factories;
            cbFactory.DisplayMember = nameof(FactoryDefinition.DisplayName);

            cbQuery.DataSource = _queries;
            cbQuery.DisplayMember = nameof(QueryDefinition.DisplayName);

            var currentFactory = _factories.Find(f => f.Factory == Monitor.Monitor.factory) ?? _factories[0];
            cbFactory.SelectedItem = currentFactory;
            cbQuery.SelectedIndex = 0;
            lblSummary.Text = R("Summary.Empty", "Ingen körning ännu.");
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            await RunPerformanceTestAsync();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportCsv();
        }
        private async Task RunPerformanceTestAsync()
        {
            if (cbFactory.SelectedItem is not FactoryDefinition factory || cbQuery.SelectedItem is not QueryDefinition query)
                return;

            var loops = (int)nudLoops.Value;
            _results.Clear();
            lvResults.Items.Clear();
            btnExport.Enabled = false;
            progressBar.Minimum = 0;
            progressBar.Maximum = loops;
            progressBar.Value = 0;

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
                    InfoText.Show(
                        R("Error.LoginFailed", "Kunde inte logga in mot Monitor för vald factory."),
                        CustomColors.InfoText_Color.Bad,
                        R("Title.Short", "Monitor API"));
                    return;
                }

                for (var i = 1; i <= loops; i++)
                {
                    var sw = Stopwatch.StartNew();
                    var ok = true;

                    var rowCount = _queries.Count;
                    //var parts = await List_PartNumber();
                    //var rowCount = parts.Count;
                    if (rowCount == 0)
                        ok = false;
                    sw.Stop();

                    
                    var result = new LoopResult(i, sw.ElapsedMilliseconds, ok, rowCount, DateTime.Now);
                    _results.Add(result);

                    var item = new ListViewItem(result.Iteration.ToString());
                    item.SubItems.Add(result.ElapsedMilliseconds.ToString());
                    item.SubItems.Add(result.Success ? R("Result.Ok", "OK") : R("Result.Fail", "Fel"));
                    item.SubItems.Add(result.RowCount.ToString());
                    item.SubItems.Add(result.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    item.SubItems.Add("Hämtar 1000 PartNumber från Inventory.Parts");
                    lvResults.Items.Add(item);

                    progressBar.Value = i;
                }

                _lastFactory = factory;
                _lastQuery = query;
                _lastRunAt = DateTime.Now;

                UpdateSummary();
                btnExport.Enabled = _results.Count > 0;
            }
            finally
            {
                Monitor.Monitor.factory = oldFactory;
                Database.MonitorCompany = oldCompany;
                Login_Monitor.sessionId = oldSession;
                SetControlsEnabled(true);
            }
        }

        
        private async Task<List<string>> List_PartNumber()
        {
            var parts = Utilities.GetFromMonitor<Inventory.Parts>("top=1000");
            return parts?.Select(p => p.PartNumber).ToList() ?? new List<string>();
        }

        private void UpdateSummary()
        {
            if (_results.Count == 0)
            {
                lblSummary.Text = R("Summary.NoData", "Ingen data.");
                return;
            }

            var valid = _results.FindAll(r => r.Success).ConvertAll(r => r.ElapsedMilliseconds);
            if (valid.Count == 0)
            {
                lblSummary.Text = R("Summary.AllFailed", "Alla loopar misslyckades.");
                return;
            }

            var min = valid.Min();
            var max = valid.Max();
            var avg = valid.Average();
            var failed = _results.Count(r => !r.Success);

            lblSummary.Text = string.Format(
                R("Summary.Format", "Factory: {0} ({1}) | Fråga: {2} | Körningar: {3} | Fel: {4} | Min: {5} ms | Max: {6} ms | Average: {7} ms"),
                _lastFactory?.DisplayName,
                _lastFactory?.CompanyCode,
                _lastQuery?.DisplayName,
                _results.Count,
                failed,
                min,
                max,
                avg.ToString("F2"));
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
                R("FileName.Format", "MonitorApiPerformance_{0}_{1}.csv"),
                _lastFactory.DisplayName,
                DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            Get_Protocol_Data.Save_csvFile(sb, fileName);
        }
        private void SetControlsEnabled(bool enabled)
        {
            cbFactory.Enabled = enabled;
            cbQuery.Enabled = enabled;
            nudLoops.Enabled = enabled;
            btnRun.Enabled = enabled;
            btnExport.Enabled = enabled && _results.Count > 0;
        }

        private sealed class QueryDefinition
        {
            public QueryDefinition(string displayName, Func<int> execute)
            {
                DisplayName = displayName;
                Execute = execute;
            }

            public string DisplayName { get; }
            public Func<int> Execute { get; }
        }

        private sealed class FactoryDefinition
        {
            public FactoryDefinition(string displayName, Monitor.Monitor.Factory factory, string companyCode)
            {
                DisplayName = displayName;
                Factory = factory;
                CompanyCode = companyCode;
            }

            public string DisplayName { get; }
            public Monitor.Monitor.Factory Factory { get; }
            public string CompanyCode { get; }
        }

        private sealed class LoopResult
        {
            public LoopResult(int iteration, long elapsedMilliseconds, bool success, int rowCount, DateTime timestamp)
            {
                Iteration = iteration;
                ElapsedMilliseconds = elapsedMilliseconds;
                Success = success;
                RowCount = rowCount;
                Timestamp = timestamp;
            }

            public int Iteration { get; }
            public long ElapsedMilliseconds { get; }
            public bool Success { get; }
            public int RowCount { get; }
            public DateTime Timestamp { get; }
        }
    }
}
