using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.EasterEggs;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using Microsoft.Data.SqlClient;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using DigitalProductionProgram.User;
using DigitalProductionProgram.ControlsManagement;

namespace DigitalProductionProgram.Statistics
{
    public partial class Statistics_DPP : UserControl
    {

        private const string Query_LastMonth = @"
                    WITH TimeIntervals AS 
                    (
                        SELECT 
                            DATEADD(DAY, -30, GETDATE()) AS IntervalStart,
                            DATEADD(DAY, 5, DATEADD(DAY, -30, GETDATE())) AS IntervalEnd
                        UNION ALL
                        SELECT 
                            DATEADD(DAY, 5, IntervalStart), 
                            DATEADD(DAY, 5, IntervalEnd)
                        FROM TimeIntervals
                        WHERE IntervalStart < GETDATE() - 5
                    )
                    SELECT 
                        COUNT(*) AS total_count, 
                        FORMAT(IntervalStart, 'dd MMMM') + ' - ' + FORMAT(IntervalEnd, 'dd MMMM') AS time_range
                    FROM Log.ActivityLog
                    JOIN TimeIntervals 
                        ON ActivityLog.Date BETWEEN TimeIntervals.IntervalStart AND TimeIntervals.IntervalEnd
                    GROUP BY IntervalStart, IntervalEnd
        ORDER BY IntervalStart;";
        private const string Query_LastMonths = @"
            WITH TimeIntervals AS 
            (
            SELECT 
                DATEADD(MONTH, -5, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) AS IntervalStart,
                DATEADD(MONTH, -4, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) AS IntervalEnd
            UNION ALL
            SELECT 
                IntervalEnd,
                DATEADD(MONTH, 1, IntervalEnd)
            FROM TimeIntervals
            WHERE IntervalEnd < DATEADD(MONTH, 1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))
            )

            SELECT 
                COUNT(*) AS total_count, 
                FORMAT(ti.IntervalStart, 'MMM') AS [MONTH]
            FROM Log.ActivityLog a
            JOIN TimeIntervals ti
                ON a.Date >= ti.IntervalStart AND a.Date < ti.IntervalEnd
            GROUP BY ti.IntervalStart
            ORDER BY ti.IntervalStart";
        private const string Query_LastYears = @"
                    WITH TimeIntervals AS 
                    (
                        SELECT 
                            DATEADD(YEAR, -5, CAST(GETDATE() AS DATE)) AS IntervalStart,
                            DATEADD(YEAR, -4, CAST(GETDATE() AS DATE)) AS IntervalEnd
                        UNION ALL
                        SELECT 
                            DATEADD(YEAR, 1, IntervalStart), DATEADD(YEAR, 1, IntervalEnd)
                        FROM TimeIntervals
                        WHERE IntervalStart < DATEADD(YEAR, 1, CAST(GETDATE() AS DATE))
                    )
                        SELECT 
                            COUNT(*) AS total_count,
                            YEAR(ActivityLog.Date) AS Year
                        FROM Log.ActivityLog
                            JOIN TimeIntervals
                                ON ActivityLog.Date >= TimeIntervals.IntervalStart 
                            AND ActivityLog.Date < TimeIntervals.IntervalEnd
                        GROUP BY YEAR(ActivityLog.Date)
                        ORDER BY Year;";
        private const string Query_LastHour = @"
            WITH TimeIntervals AS 
            (
            SELECT 
                DATEADD(HOUR, -1, GETDATE()) AS IntervalStart,
                DATEADD(MINUTE, 10, DATEADD(HOUR, -1, GETDATE())) AS IntervalEnd
            UNION ALL
            SELECT 
                DATEADD(MINUTE, 1, IntervalEnd),  -- Starta nästa intervall 1 min efter föregående slut
                DATEADD(MINUTE, 10, DATEADD(MINUTE, 1, IntervalEnd))
            FROM TimeIntervals
            WHERE IntervalEnd < GETDATE()
            )

            SELECT 
                COUNT(*) AS total_count, 
                FORMAT(ti.IntervalStart, 'HH:mm') + '-' + FORMAT(ti.IntervalEnd, 'HH:mm') AS time_range
            FROM Log.ActivityLog a
            JOIN TimeIntervals ti
                ON a.Date BETWEEN ti.IntervalStart AND ti.IntervalEnd
            GROUP BY ti.IntervalStart, ti.IntervalEnd
            ORDER BY ti.IntervalStart;";
        private const string Query_LastDay = @"
            WITH TimeIntervals AS 
            (
            SELECT 
                DATEADD(DAY, -1, GETDATE()) AS IntervalStart,
                DATEADD(HOUR, 4, DATEADD(DAY, -1, GETDATE())) AS IntervalEnd
            UNION ALL
            SELECT 
                DATEADD(MINUTE, 1, IntervalEnd),
                DATEADD(MINUTE, 240, IntervalEnd)  -- 239 + 1 == 240
            FROM TimeIntervals
            WHERE IntervalEnd < GETDATE()
            )

            SELECT 
                COUNT(*) AS total_count, 
                FORMAT(ti.IntervalStart, 'HH:mm') + ' - ' + FORMAT(ti.IntervalEnd, 'HH:mm') AS time_range
            FROM Log.ActivityLog a
            JOIN TimeIntervals ti
                ON a.Date BETWEEN ti.IntervalStart AND ti.IntervalEnd
            GROUP BY ti.IntervalStart, ti.IntervalEnd
            ORDER BY ti.IntervalStart;";
        private const string Query_LastWeek = @"
            WITH TimeIntervals AS 
            (
            SELECT 
                DATEADD(DAY, -6, CAST(GETDATE() AS DATE)) AS IntervalStart,
                DATEADD(DAY, 1, DATEADD(DAY, -6, CAST(GETDATE() AS DATE))) AS IntervalEnd
            UNION ALL
            SELECT 
                IntervalEnd,
                DATEADD(DAY, 1, IntervalEnd)
            FROM TimeIntervals
            WHERE IntervalEnd < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
            )

            SELECT 
                COUNT(*) AS total_count, 
                FORMAT(ti.IntervalStart, 'ddd') AS day
            FROM Log.ActivityLog a
            JOIN TimeIntervals ti
                ON a.Date BETWEEN ti.IntervalStart AND ti.IntervalEnd
            GROUP BY ti.IntervalStart, ti.IntervalEnd
            ORDER BY ti.IntervalStart";
        private const string Query_DeploymentByVersion = @"
          -- Steg 1: Hämta senaste loggpost per HostID
WITH LatestLogPerHost AS
(
    SELECT HostID, Version
    FROM
    (
        SELECT
            HostID,
            Version,
            ROW_NUMBER() OVER (PARTITION BY HostID ORDER BY Date DESC) AS rn
        FROM [Log].ActivityLog
        WHERE Date >= DATEADD(DAY, -7, GETDATE())
    ) x
    WHERE rn = 1
),
Top8Versions AS
(
    SELECT TOP (8) Version
    FROM LatestLogPerHost
    GROUP BY Version
    ORDER BY
        CAST(PARSENAME(Version, 4) AS INT) DESC,
        CAST(PARSENAME(Version, 3) AS INT) DESC,
        CAST(PARSENAME(Version, 2) AS INT) DESC,
        CAST(PARSENAME(Version, 1) AS INT) DESC
)
SELECT
    COUNT(*) AS HostCount,
    l.Version
FROM LatestLogPerHost l
JOIN Top8Versions t
    ON l.Version = t.Version
GROUP BY l.Version
ORDER BY
    CAST(PARSENAME(l.Version, 4) AS INT) DESC,
    CAST(PARSENAME(l.Version, 3) AS INT) DESC,
    CAST(PARSENAME(l.Version, 2) AS INT) DESC,
    CAST(PARSENAME(l.Version, 1) AS INT) DESC;";

        private const string Query_OrdersLastWeek = @"
WITH TimeIntervals AS 
(
    SELECT 
        DATEADD(DAY, -6, CAST(GETDATE() AS DATE)) AS IntervalStart,
        DATEADD(DAY, -5, CAST(GETDATE() AS DATE)) AS IntervalEnd
    UNION ALL
    SELECT 
        IntervalEnd,
        DATEADD(DAY, 1, IntervalEnd)
    FROM TimeIntervals
    WHERE IntervalEnd < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
)
SELECT 
    COUNT(o.OrderID) AS total_count,
    FORMAT(ti.IntervalStart, 'dddd') AS day
FROM TimeIntervals ti
LEFT JOIN [Order].MainData o
    ON o.Date_Stop >= ti.IntervalStart
   AND o.Date_Stop <  ti.IntervalEnd
GROUP BY ti.IntervalStart
ORDER BY ti.IntervalStart;";
        private const string Query_OrdersLastMonth = @"
            
WITH TimeIntervals AS 
(
    SELECT 
        DATEADD(MONTH, -5, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) AS IntervalStart,
        DATEADD(MONTH, -4, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) AS IntervalEnd
    UNION ALL
    SELECT 
        IntervalEnd,
        DATEADD(MONTH, 1, IntervalEnd)
    FROM TimeIntervals
    WHERE IntervalEnd < DATEADD(MONTH, 1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))
)
SELECT 
    COUNT(DISTINCT md.OrderID) AS total_count,
    FORMAT(ti.IntervalStart, 'MMM') AS [MONTH]
FROM TimeIntervals ti
LEFT JOIN [Order].MainData md
    ON md.Date_Stop >= ti.IntervalStart
   AND md.Date_Stop <  ti.IntervalEnd
GROUP BY ti.IntervalStart
ORDER BY ti.IntervalStart;";
        private const string Query_OrdersPerYear = """
                                                               SELECT
                                                                   COUNT(DISTINCT md.OrderID) AS total_orders,
                                                                   YEAR(md.Date_Stop) AS[Year]
                                                               FROM [Order].MainData md
                                                               WHERE md.Date_Stop >= DATEADD(YEAR, -5, CAST(GETDATE() AS DATE))
                                                               GROUP BY YEAR(md.Date_Stop)
                                                               ORDER BY[Year]
                                                   """;
        private const string Query_LastMonth_Orders = """
                                                      WITH TimeIntervals AS
                                                      (
                                                          -- Första dagen i förra månaden
                                                          SELECT
                                                              DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0) AS IntervalStart,
                                                              DATEADD(DAY, 1, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)) AS IntervalEnd

                                                          UNION ALL

                                                          SELECT
                                                              IntervalEnd,
                                                              DATEADD(DAY, 1, IntervalEnd)
                                                          FROM TimeIntervals
                                                          WHERE IntervalEnd < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)
                                                      )
                                                      SELECT
                                                          COUNT(o.OrderID) AS total_count,
                                                          FORMAT(ti.IntervalStart, 'dd') AS [day]
                                                      FROM TimeIntervals ti
                                                      LEFT JOIN [Order].MainData o
                                                          ON o.Date_Stop >= ti.IntervalStart
                                                         AND o.Date_Stop <  ti.IntervalEnd
                                                      GROUP BY ti.IntervalStart
                                                      ORDER BY ti.IntervalStart;

                                                      """;

        private const string Query_MeasurementsLastMonth = """
                                                           WITH PrevMonth AS
                                                           (
                                                               SELECT
                                                                   CAST(DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) AS date) AS FirstDayThisMonth,
                                                                   CAST(EOMONTH(DATEADD(MONTH, -1, GETDATE())) AS date) AS LastDayPrevMonth
                                                           ),
                                                           DateSeries AS
                                                           (
                                                               SELECT CAST(DATEADD(MONTH, -1, FirstDayThisMonth) AS date) AS [dt],
                                                                      LastDayPrevMonth
                                                               FROM PrevMonth
                                                               UNION ALL
                                                               SELECT DATEADD(DAY, 1, [dt]), LastDayPrevMonth
                                                               FROM DateSeries
                                                               WHERE [dt] < LastDayPrevMonth
                                                           )
                                                           SELECT
                                                               COUNT(md.[Date]) AS [antal_mätningar],
                                                               CONVERT(varchar(10), ds.[dt], 23) + ':' + DATENAME(weekday, ds.[dt])
                                                           FROM DateSeries ds
                                                           LEFT JOIN MeasureProtocol.MainData md
                                                               ON CAST(md.[Date] AS date) = ds.[dt] 
                                                           GROUP BY ds.[dt]
                                                           ORDER BY ds.[dt]
                                                           OPTION (MAXRECURSION 150);
                                                           """;
        private const string Query_MeasurementsLastMonths = """
                                                            WITH TimeIntervals AS 
                                                            (
                                                                SELECT 
                                                                    DATEADD(MONTH, -5, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) AS IntervalStart,
                                                                    DATEADD(MONTH, -4, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) AS IntervalEnd
                                                                UNION ALL
                                                                SELECT 
                                                                    IntervalEnd,
                                                                    DATEADD(MONTH, 1, IntervalEnd)
                                                                FROM TimeIntervals
                                                                WHERE IntervalEnd < DATEADD(MONTH, 1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))
                                                            )
                                                            SELECT 
                                                                COUNT(*) AS total_count, 
                                                                FORMAT(ti.IntervalStart, 'MMM yyyy') AS [MONTH]
                                                            FROM MeasureProtocol.MainData md
                                                            JOIN TimeIntervals ti
                                                                ON md.Date >= ti.IntervalStart AND md.Date < ti.IntervalEnd
                                                            GROUP BY ti.IntervalStart
                                                            ORDER BY ti.IntervalStart;

                                                            """;
        private const string Query_MeasurementsLastDay = @"
                  WITH TimeIntervals AS 
(
    SELECT 
        DATEADD(DAY, -1, GETDATE()) AS IntervalStart,
        DATEADD(HOUR, 4, DATEADD(DAY, -1, GETDATE())) AS IntervalEnd
    UNION ALL
    SELECT 
        DATEADD(MINUTE, 1, IntervalEnd),
        DATEADD(MINUTE, 240, IntervalEnd)  -- 239 + 1 == 240
    FROM TimeIntervals
    WHERE IntervalEnd < GETDATE()
)
SELECT 
    COUNT(*) AS total_count, 
    FORMAT(ti.IntervalStart, 'HH:mm') + ' - ' + FORMAT(ti.IntervalEnd, 'HH:mm') AS time_range
FROM MeasureProtocol.MainData m
JOIN TimeIntervals ti
    ON m.Date BETWEEN ti.IntervalStart AND ti.IntervalEnd
GROUP BY ti.IntervalStart, ti.IntervalEnd
ORDER BY ti.IntervalStart;";
        private const string Query_MeasurementsLastWeek = @"
                 WITH TimeIntervals AS 
(
    SELECT 
        DATEADD(DAY, -6, CAST(GETDATE() AS DATE)) AS IntervalStart,
        DATEADD(DAY, 1, DATEADD(DAY, -6, CAST(GETDATE() AS DATE))) AS IntervalEnd
    UNION ALL
    SELECT 
        IntervalEnd,
        DATEADD(DAY, 1, IntervalEnd)
    FROM TimeIntervals
    WHERE IntervalEnd < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
)
SELECT 
    COUNT(*) AS total_count, 
    FORMAT(ti.IntervalStart, 'ddd dd MMM') AS [day]
FROM MeasureProtocol.MainData md
JOIN TimeIntervals ti
    ON md.Date >= ti.IntervalStart AND md.Date < ti.IntervalEnd
GROUP BY ti.IntervalStart, ti.IntervalEnd
ORDER BY ti.IntervalStart;
";
        private const string Query_MeasurementsLastYears = @"
                WITH TimeIntervals AS 
(
    SELECT 
        DATEADD(YEAR, -5, CAST(GETDATE() AS DATE)) AS IntervalStart,
        DATEADD(YEAR, -4, CAST(GETDATE() AS DATE)) AS IntervalEnd
    UNION ALL
    SELECT 
        DATEADD(YEAR, 1, IntervalStart), 
        DATEADD(YEAR, 1, IntervalEnd)
    FROM TimeIntervals
    WHERE IntervalStart < DATEADD(YEAR, 1, CAST(GETDATE() AS DATE))
)
SELECT 
    COUNT(*) AS total_count,
    YEAR(md.Date) AS [Year]
FROM MeasureProtocol.MainData md
JOIN TimeIntervals ti
    ON md.Date >= ti.IntervalStart 
   AND md.Date < ti.IntervalEnd
GROUP BY YEAR(md.Date)
ORDER BY [Year];";




        private readonly List<(string Title, string Query)> chartQueries =
        [
            ("Activity DPP - Last Hour", Query_LastHour),
            ("Activity DPP - Last 24 Hour", Query_LastDay),
            ("Activity DPP - Last Week", Query_LastWeek),
            ("Activity DPP - Last Month", Query_LastMonth),
            ("Activity DPP - Last 6 Months", Query_LastMonths),
            ("Activity DPP - Last 6 Years", Query_LastYears),

            ("Deployment by Version", Query_DeploymentByVersion),

            ("Total Orders - Last Week", Query_OrdersLastWeek),
            ("Total Orders - Last Month", Query_LastMonth_Orders),
            ("Total Orders - Last 6 Months", Query_OrdersLastMonth),
            ("Total Orders - Last 6 Years", Query_OrdersPerYear),

            ("Activity DPP - Last 5 Years", Query_LastYears),

            ("Measurements - Last 24 Hour", Query_MeasurementsLastDay),
            ("Measurements - Last Week", Query_MeasurementsLastWeek),
            ("Measurements - Last Month", Query_MeasurementsLastMonth),
            ("Measurements - Last 6 Months", Query_MeasurementsLastMonths),
            ("Measurements - Last 5 Years", Query_MeasurementsLastYears)

        ];
        private bool suppressSelectorChanged;
        private bool isSelectorInitialized;
        private bool isSuperAdminChartLoaded;
        private int chartLoadVersion;
        private async Task<List<(string Label, int Value)>> LoadChartDataAsync(string query)
        {
            return await Database.ExecuteSafeAsync(async con =>
            {
                var data = new List<(string Label, int Value)>();
                await using var cmd = new SqlCommand(query, con);
                await using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var label = reader[1].ToString();
                    int.TryParse(reader[0].ToString(), out var value);
                    data.Add((label, value));
                }

                return data;
            });
        }

        public Statistics_DPP()
        {
            InitializeComponent();
            ConfigureStatisticsSelector();
        }
        private async void Statistics_DPP_Load(object sender, EventArgs e)
        {
            if (DesignMode || Program.IsInDesignMode())
                return;
            await Load_StatisticsAsync();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (DesignMode || Program.IsInDesignMode())
                return;
            RefreshStatisticsSelectorVisibility();
        }
        private int index;
        public async Task Load_StatisticsAsync()
        {
            if (IsStatisticsSelectorReady())
                RefreshStatisticsSelectorVisibility();
            if (IsStatisticsSelectorReady() && IsSuperAdminSelectorVisible())
            {
                if (isSuperAdminChartLoaded == false)
                {
                    isSuperAdminChartLoaded = true;
                    await LoadSelectedStatisticsAsync();
                }
                return;
            }
            isSuperAdminChartLoaded = false;
            var selected = chartQueries[index];
            index++;
            if (index >= chartQueries.Count)
                index = 0;
            await CreateChartAsync(selected.Title, selected.Query);
        }
        private void ConfigureStatisticsSelector()
        {
            if (IsStatisticsSelectorReady() == false)
                return;
            DrawingControl.EnableDoubleBuffer(this);
            DrawingControl.EnableDoubleBuffer(selectorPanel);
            DrawingControl.EnableDoubleBuffer(chartHost);
            DrawingControl.EnableDoubleBuffer(cbStatistics);
            chart_Stats.AnimationsSpeed = TimeSpan.Zero;
            LoadStatisticsSelectorOnce();
        }
        private bool IsStatisticsSelectorReady()
        {
            return selectorPanel != null && cbStatistics != null && chartHost != null && chart_Stats != null;
        }
        private void LoadStatisticsSelectorOnce()
        {
            if (isSelectorInitialized || cbStatistics == null)
                return;
            suppressSelectorChanged = true;
            try
            {
                cbStatistics.SetItems(chartQueries.Select(x => x.Title));
                if (cbStatistics.ItemCount > 0)
                    cbStatistics.SelectedIndex = Math.Clamp(index, 0, chartQueries.Count - 1);
                isSelectorInitialized = true;
            }
            finally
            {
                suppressSelectorChanged = false;
            }
        }
        private bool UpdateSelectorVisibility()
        {
            var shouldShow = IsSuperAdminSelectorVisible();
            if (selectorPanel.Visible == shouldShow)
                return false;
            selectorPanel.Visible = shouldShow;
            if (shouldShow == false)
                isSuperAdminChartLoaded = false;
            return true;
        }
        public void RefreshStatisticsSelectorVisibility()
        {
            if (IsStatisticsSelectorReady() == false)
                return;
            var visibilityChanged = UpdateSelectorVisibility();
            if (selectorPanel.Visible && cbStatistics.SelectedIndex < 0)
                SetSelectedStatisticsIndex(Math.Clamp(index, 0, chartQueries.Count - 1));
            if (selectorPanel.Visible && visibilityChanged)
                selectorPanel.BringToFront();
        }
        private static bool IsSuperAdminSelectorVisible()
        {
            return Person.Role == "SuperAdmin";
        }
        private void SetSelectedStatisticsIndex(int selectedIndex)
        {
            if (cbStatistics == null)
                return;
            if (selectedIndex < 0 || selectedIndex >= chartQueries.Count)
                return;
            if (cbStatistics.SelectedIndex == selectedIndex)
                return;
            suppressSelectorChanged = true;
            cbStatistics.SelectedIndex = selectedIndex;
            suppressSelectorChanged = false;
        }
        private async Task LoadSelectedStatisticsAsync()
        {
            if (cbStatistics == null)
            {
                await CreateChartAsync(chartQueries[0].Title, chartQueries[0].Query);
                return;
            }
            var selectedIndex = cbStatistics.SelectedIndex < 0 ? 0 : cbStatistics.SelectedIndex;
            if (selectedIndex >= chartQueries.Count)
                selectedIndex = 0;
            index = selectedIndex;
            isSuperAdminChartLoaded = true;
            var selected = chartQueries[selectedIndex];
            await CreateChartAsync(selected.Title, selected.Query);
        }
        private async Task LoadNextStatisticsAsync()
        {
            if (IsStatisticsSelectorReady() && IsSuperAdminSelectorVisible())
            {
                var nextIndex = cbStatistics.SelectedIndex + 1;
                if (nextIndex >= chartQueries.Count)
                    nextIndex = 0;
                SetSelectedStatisticsIndex(nextIndex);
                await LoadSelectedStatisticsAsync();
                return;
            }
            await Load_StatisticsAsync();
        }
        private async Task CreateChartAsync(string legendText, string query)
        {
            var loadVersion = ++chartLoadVersion;
            var data = await LoadChartDataAsync(query);
            if (loadVersion != chartLoadVersion)
                return;
            if (data == null || !data.Any())
                return;
            var values = data.Select(d => (double)d.Value).ToArray();
            var labels = data.Select(d => d.Label).ToArray();
            var columnSeries = new ColumnSeries<double>
            {
                Values = values,
                Name = legendText,
                Stroke = new SolidColorPaint(SKColors.SteelBlue, 1),
            };
            var color = Teman.backColor_ChartStats;
            if (color != Color.FromArgb(35,35,35))
                color = Color.FromArgb(35, 35,35);
            if (chartHost.InvokeRequired)
                chartHost.Invoke(() => ApplyChartData(legendText, color, labels, columnSeries));
            else
                ApplyChartData(legendText, color, labels, columnSeries);
        }
        private void ApplyChartData(string legendText, Color color, string?[] labels, ColumnSeries<double> columnSeries)
        {
            chartHost.SuspendLayout();
            try
            {
                chart_Stats.Text = legendText;
                chart_Stats.BackColor = color;
                chart_Stats.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top;
                chart_Stats.LegendTextPaint = new SolidColorPaint(SKColors.White, 1);
                chart_Stats.LegendTextSize = 12;
                chart_Stats.XAxes =
                [
                    new Axis
                    {
                        Labels = labels,
                        TextSize = 10,
                        LabelsRotation = -45,
                        LabelsPaint = new SolidColorPaint(SKColors.White),
                    }
                ];
                chart_Stats.Series = [columnSeries];
            }
            finally
            {
                chartHost.ResumeLayout(false);
            }
        }
        private void panelStatistics_Click(object sender, MouseEventArgs e)
        {
            //EasterEgg_Code.HandleStatisticsClick(this, e.Location);
        }
        private async void chart_Statistics_MouseDown(object sender, MouseEventArgs e)
        {
            await LoadNextStatisticsAsync();
        }
        private async void cbStatistics_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (suppressSelectorChanged || !IsSuperAdminSelectorVisible())
                return;
            await LoadSelectedStatisticsAsync();
        }
    }
}




