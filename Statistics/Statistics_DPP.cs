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
WITH LatestLogPerHost AS (
    SELECT HostID, Version, Date
    FROM (
        SELECT 
            HostID, 
            Version,
            Date,
            ROW_NUMBER() OVER (PARTITION BY HostID ORDER BY Date DESC) AS rn
        FROM [Log].ActivityLog
        WHERE Date >= DATEADD(DAY, -7, GETDATE()) -- Begränsa till de senaste 7 dagarna
    ) AS ranked
    WHERE rn = 1
),
-- Steg 2: Lägg till versionkomponenter för jämförelse
VersionComponents AS (
    SELECT 
        HostID, 
        Version,
        Date,
        CAST(PARSENAME(Version, 4) AS INT) AS Major,
        CAST(PARSENAME(Version, 3) AS INT) AS Minor,
        CAST(PARSENAME(Version, 2) AS INT) AS Patch,
        CAST(PARSENAME(Version, 1) AS INT) AS Build
    FROM LatestLogPerHost
),
-- Steg 3: Begränsa till de 8 senaste versionerna
Top8Versions AS (
    SELECT TOP 8 Version
    FROM VersionComponents
    GROUP BY Version, Major, Minor, Patch, Build
    ORDER BY Major DESC, Minor DESC, Patch DESC, Build DESC
)
-- Steg 4: Räkna hur många hostar som har varje av de versionerna + visa senaste datum
SELECT 
    COUNT(*) AS HostCount,
    v.Version
   
FROM VersionComponents v
JOIN Top8Versions t ON v.Version = t.Version
GROUP BY v.Version, v.Major, v.Minor, v.Patch, v.Build
ORDER BY v.Major DESC, v.Minor DESC, v.Patch DESC, v.Build DESC;";
        private const string Query_MeasurementsLastMonth = @"
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
FROM MeasureProtocol.MainData md
JOIN TimeIntervals ti
    ON md.Date BETWEEN ti.IntervalStart AND ti.IntervalEnd
GROUP BY IntervalStart, IntervalEnd
ORDER BY IntervalStart;";
        private const string Query_MeasurementsLastMonths = @"
                   WITH TimeIntervals AS 
(
    SELECT 
        DATEADD(MONTH, -6, CAST(GETDATE() AS date)) AS IntervalStart,
        DATEADD(DAY, 5, DATEADD(MONTH, -6, CAST(GETDATE() AS date))) AS IntervalEnd
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
FROM MeasureProtocol.MainData md
JOIN TimeIntervals ti
    ON md.MeasurementDate BETWEEN ti.IntervalStart AND ti.IntervalEnd
GROUP BY IntervalStart, IntervalEnd
ORDER BY IntervalStart;";
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

        private readonly List<(string Title, string Query)> chartQueries = new()
        {
            ("Activity DPP - Last Week", Query_LastWeek),
            ("Activity DPP - Last 24 Hour", Query_LastDay),
            ("Activity DPP - Last Hour", Query_LastHour),
            ("Activity DPP - Last Month", Query_LastMonth),
            ("Activity DPP - Last 6 Months", Query_LastMonths),
            ("Activity DPP - Last 5 Years", Query_LastYears),
            ("Deployment by Version", Query_DeploymentByVersion),
            ("Measurements - Last Month", Query_MeasurementsLastMonth),
            ("Measurements - Last 6 Months", Query_MeasurementsLastMonths),
            ("Measurements - Last 24 Hour", Query_MeasurementsLastDay),
            ("Measurements - Last Week", Query_MeasurementsLastWeek),

        };
        private async Task<List<(string Label, int Value)>> LoadChartDataAsync(string query)
        {
            var data = new List<(string Label, int Value)>();
            await using var con = new SqlConnection(Database.cs_Protocol);
            await using var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            await con.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var label = reader[1].ToString();
                int.TryParse(reader[0].ToString(), out var value);
                data.Add((label, value));
            }

            return data;
        }

        public Statistics_DPP()
        {
            InitializeComponent();

        }
        private async void Statistics_DPP_Load(object sender, EventArgs e)
        {
            if (DesignMode || Program.IsInDesignMode())
                return;

            if (DesignMode || Program.IsInDesignMode())
                return;

            await Load_StatisticsAsync();
        }
        public async Task Load_StatisticsAsync()
        {
            var random = new Random();
            var selected = chartQueries[random.Next(chartQueries.Count)];

            await CreateChartAsync(selected.Title, selected.Query);
        }

        public async Task CreateChartAsync(string legendText, string query)
        {
            this.Controls.Clear(); // Clear existing controls in the panel
            var data = await LoadChartDataAsync(query);
            var values = data.Select(d => (double)d.Value).ToArray();
            var labels = data.Select(d => d.Label).ToArray();
            var columnSeries = new ColumnSeries<double>
            {
                Values = values,
                Name = legendText,
                Stroke = new SolidColorPaint(SKColors.SteelBlue, 1),
            };
            var chart_Stats = new CartesianChart
            {
                Dock = DockStyle.Fill,
                Name = "chart_Stats",
                Text = legendText,
                BackColor = Teman.backColor_ChartStats,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Top,
                LegendTextPaint = new SolidColorPaint(SKColors.White, 1),
                LegendTextSize = 12,
                XAxes = new[]
                {
                    new Axis
                    {
                        Labels = labels,
                        TextSize = 10,
                        LabelsRotation = -45,
                        LabelsPaint = new SolidColorPaint(SKColors.White),
                    }
                },
                Series = new ISeries[] { columnSeries },
            };
            
            chart_Stats.MouseDown += chart_Statistics_MouseDown;

            // this.BackColor = Color.Transparent;
            if (this.InvokeRequired)
            {
                this.Invoke(() => this.Controls.Add(chart_Stats));
            }
            else
            {
                this.Controls.Add(chart_Stats);
            }
        }

        private async void chart_Statistics_MouseDown(object sender, MouseEventArgs e)
        {
            await Load_StatisticsAsync();
        }
    }
}



