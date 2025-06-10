using System.Windows.Forms.DataVisualization.Charting;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.EasterEggs;
using DigitalProductionProgram.MainWindow;
using Microsoft.Data.SqlClient;

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
    SELECT HostID, Version
    FROM (
        SELECT 
        ROW_NUMBER() OVER (PARTITION BY HostID ORDER BY Date DESC) AS rn,
            Version,
            HostID            
        FROM [Log].ActivityLog
    ) AS ranked
    WHERE rn = 1
),
-- Steg 2: Lägg till versionkomponenter för jämförelse
VersionComponents AS (
    SELECT 
        HostID, 
        Version,
      
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

        private readonly List<(string Title, string Query)> chartQueries = new()
        {
            ("Activity DPP - Last Week", Query_LastWeek),
            ("Activity DPP - Last 24 Hour", Query_LastDay),
            ("Activity DPP - Last Hour", Query_LastHour),
            ("Activity DPP - Last Month", Query_LastMonth),
            ("Activity DPP - Last 6 Months", Query_LastMonths),
            ("Activity DPP - Last 5 Years", Query_LastYears),
            ("Deployment by Version", Query_DeploymentByVersion)
        };
        private async Task<List<(string Label, int Value)>> LoadChartDataAsync(string query)
        {
            var data = new List<(string Label, int Value)>();
            await using var con = new SqlConnection(Database.cs_Protocol);
            await using var cmd = new SqlCommand(query, con);
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
            var data = await LoadChartDataAsync(query);

            chart_Statistics.Series[0].Points.Clear();
            chart_Statistics.Series[0].LegendText = legendText;
            chart_Statistics.Legends[0].Docking = Docking.Top;
            chart_Statistics.Legends[0].Alignment = StringAlignment.Far;
            chart_Statistics.Legends[0].IsDockedInsideChartArea = false;
            chart_Statistics.Legends[0].LegendStyle = LegendStyle.Table;
            chart_Statistics.Legends[0].Position.Auto = false;
            chart_Statistics.Legends[0].Position = new ElementPosition(5, 2, 90, 10);

            foreach (var (label, value) in data)
            {
                chart_Statistics.Series[0].Points.AddXY(label, value);
            }

            chart_Statistics.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart_Statistics.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        }

       
        private void panelStatistics_Click(object sender, MouseEventArgs e)
        {
            //EasterEgg_Code.HandleStatisticsClick(this, e.Location);
        }


        private async void chart_Statistics_MouseDown(object sender, MouseEventArgs e)
        {
            await Load_StatisticsAsync();
        }
    }
}



