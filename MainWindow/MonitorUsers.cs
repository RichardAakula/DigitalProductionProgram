using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.SKCharts;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using LiveChartsCore.Drawing;
using LiveChartsCore.Measure;
using Action = System.Action;
using Padding = System.Windows.Forms.Padding;

namespace DigitalProductionProgram.MainWindow
{
    public partial class MonitorUsers : UserControl
    {
        private string org_MonitorCompany;
        private static string Time(TimeRecording.AttendanceChart user)
        {
            int hours = DateTime.Now.Subtract(user.IntervalStart).Hours;
            int minutes = DateTime.Now.Subtract(user.IntervalStart).Minutes;
            return $"{hours}h:{minutes}min";
        }
        public class DoubleBufferedFlowLayoutPanel : FlowLayoutPanel
        {
            public DoubleBufferedFlowLayoutPanel()
            {
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.UpdateStyles();
            }
        }
        private DoubleBufferedFlowLayoutPanel flp_List = new();
        public enum EventType { Login, Logout }
        private readonly SemaphoreSlim _fillLock = new(1, 1);


        public MonitorUsers()
        {
            org_MonitorCompany = Database.MonitorCompany;
            InitializeComponent();
        }


        public async Task Clear_ListAsync()
        {
            await Task.Run(() =>
            {
                flp_List.Invoke(new Action(() =>
                {
                    flp_List.Controls.Clear();
                    Refresh();
                }));

            });
        }


        private bool Is_flp_Exist(string name)
        {
            return flp_List.Controls.Cast<Control>().Any(control => control.Name == name);
        }

        public void Fill_OnlineMonitorUsers()
        {
            if (Monitor.Monitor.List_Users is null)
                return;
            events.Clear();
            foreach (var user in Monitor.Monitor.List_Users)
            {
                var name = $"{user.FirstName} {user.LastName}";
                if (Is_flp_Exist(name))
                {
                    var flp = (FlowLayoutPanel)flp_List.Controls[name];
                    Update_User_flp(flp, user);
                }
                else Add_User_flp(user);
            }
            CreateChart();
            //Login_Monitor.Login_API();
        }

        public class UserEvent
        {
            public DateTime Time { get; set; }
            public EventType Type { get; set; }
            public string Name { get; set; }
        }

        List<UserEvent> events = new();
        private void Add_User_flp(TimeRecording.AttendanceChart user)
        {
            if (flp_List.InvokeRequired)
            {
                flp_List.Invoke(new Action(() => Add_User_flp(user)));
            }
            else
            {

                TableLayoutPanel tlp = new TableLayoutPanel()
                {
                    Name = $"{user.FirstName} {user.LastName} - {user.EmployeeNumber}",
                    RowCount = 2,
                    ColumnCount = 3,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = flp_List.ClientSize.Width - SystemInformation.VerticalScrollBarWidth,
                    Height = 50,
                };

                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200)); // Kolumn 1
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));       // Kolumn 2
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200)); // Kolumn 3

                // Raddefinitioner (du kan justera höjder om du vill)
                tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Rad 1
                tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Rad 2
                //tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Rad 3
                if (user.IsClosedInterval || user.AbsenceDescription != null)
                {
                    tlp.BackColor = CustomColors.Bad_Back;
                    events.Add(new UserEvent
                    {
                        Time = user.IntervalStart,
                        Type = EventType.Login,
                        Name = $"{user.FirstName} {user.LastName}"
                    });
                    events.Add(new UserEvent
                    {
                        Time = user.IntervalEnd,
                        Type = EventType.Logout,
                        Name = $"{user.FirstName} {user.LastName}"
                    });
                }

                else
                {
                    tlp.BackColor = CustomColors.Ok_Back;
                    events.Add(new UserEvent
                    {
                        Time = user.IntervalStart,
                        Type = EventType.Login,
                        Name = $"{user.FirstName} {user.LastName}"
                    });
                }


                var lbl_Name = new Label
                {
                    Text = $@"{user.FirstName} {user.LastName}",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.TopCenter,
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    Font = new Font("Palatino LineType", 10),
                    Margin = new Padding(3, 0, 3, 0)
                };
                var lbl_Start = new Label
                {
                    Name = "Start",
                    Text = $@"Start: {user.IntervalStart}",
                    Dock = DockStyle.Fill,
                    ForeColor = Color.FromArgb(50, 50, 50),
                    BackColor = Color.Transparent,
                    Font = new Font("Palatino LineType", 9),
                    Width = flp_List.Width,
                    Margin = new Padding(3, 0, 3, 0)

                };

                string loggedIn = null;
                if (!user.IsClosedInterval)
                    loggedIn = Time(user);
                var lbl_LoggedIn = new Label
                {
                    Name = "LoggedIn",
                    Text = $@"Totalt: {loggedIn}",
                    Dock = DockStyle.Fill,
                    ForeColor = Color.FromArgb(50, 50, 50),
                    BackColor = Color.Transparent,
                    Font = new Font("Palatino LineType", 9),
                    Margin = new Padding(3, 0, 3, 0)
                };

                string endtime = "End:";
                if (user.IsClosedInterval)
                    endtime += $"{user.IntervalEnd}";
                var lbl_End = new Label
                {
                    Name = "End",
                    Text = endtime,
                    Dock = DockStyle.Fill,
                    ForeColor = Color.FromArgb(50, 50, 50),
                    BackColor = Color.Transparent,
                    Font = new Font("Palatino LineType", 9),
                    Margin = new Padding(3, 0, 3, 0)
                };
                var lbl_Absence = new Label
                {
                    Name = "Test",
                    Text = $@"Absence: {user.AbsenceDescription}",
                    Dock = DockStyle.Fill,
                    ForeColor = Color.FromArgb(50, 50, 50),
                    BackColor = Color.Transparent,
                    Font = new Font("Palatino LineType", 9)
                };

                tlp.Controls.Add(lbl_Name, 1, 0);
                //tlp.SetColumnSpan(lbl_Name, 3);

                tlp.Controls.Add(lbl_Start, 0, 0);
                tlp.Controls.Add(lbl_End, 2, 0);

                tlp.Controls.Add(lbl_Absence, 2, 0);
                tlp.Controls.Add(lbl_LoggedIn, 0, 1);

                flp_List.Controls.Add(tlp);
            }
        }





        private sealed class NamedPoint : ObservablePoint
        {
            public string Name { get; set; } = "";
        }


        // Pseudocode / Plan:
        // - Clear existing chart series and axes.
        // - Build a list of NamedPoint from events, storing time ticks in X and active count in Y.
        // - Create a LineSeries using these points.
        // - Provide robust tooltip formatters:
        //   - When cp.Model is NamedPoint, read values directly.
        //   - Otherwise, try to read coordinate properties via reflection and convert safely.
        //   - When matching a coordinate X to a NamedPoint in the points list, convert the NamedPoint.X
        //     to decimal before performing the subtraction to avoid mixing double and decimal types.
        // - Configure axes and assign to chart
        private void CreateChart()
        {
            // Rensa gammalt innehåll
            chart.Series = Array.Empty<ISeries>();
            chart.XAxes = Array.Empty<Axis>();
            chart.YAxes = Array.Empty<Axis>();

            // Aktivera tooltip med styling
            chart.Tooltip = new SKDefaultTooltip
            {
               // BackgroundPaint = new SolidColorPaint(SKColors.Red),

            };
            chart.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top;

            // Bygg data
            var count = 0;
            var points = new List<NamedPoint>();
            foreach (var ev in events.OrderBy(e => e.Time))
            {
                count += ev.Type == EventType.Login ? 1 : -1;

                points.Add(new NamedPoint
                {
                    // OBS: ObservablePoint kräver double/decimal; vi sparar ticks här
                    X = ev.Time.Ticks,
                    Y = count,
                    Name = ev.Name
                });
            }

            // Skapa serien
            var series = new LineSeries<NamedPoint>
            {
                Values = points,
                Fill = null,
                GeometrySize = 6,
                IsHoverable = true,
            };

            // Helper: try to get numeric value from an object by common property names
            static object? GetCoordinateProperty(object? coord, params string[] names)
            {
                if (coord is null) return null;
                var type = coord.GetType();
                foreach (var n in names)
                {
                    var prop = type.GetProperty(n);
                    if (prop is not null)
                    {
                        try
                        {
                            return prop.GetValue(coord);
                        }
                        catch
                        {
                            // ignore and try next
                        }
                    }
                }
                return null;
            }

            // New tooltip formatters: use model if present, otherwise try to read coordinate via reflection
            series.XToolTipLabelFormatter = cp =>
            {
                // Try model first (preferred)
                long ticks = 0;
                string? name = null;

                if (cp.Model is NamedPoint np)
                {
                    // NamedPoint.X might be decimal/double; convert to long ticks
                    try
                    {
                        ticks = Convert.ToInt64(np.X);
                    }
                    catch
                    {
                        ticks = 0;
                    }
                    name = np.Name;
                }
                else
                {
                    // Fallback: inspect cp.Coordinate for common property names
                    var coord = cp.Coordinate;
                    // try "X" then "Primary" then "Secondary" as possible names
                    var xObj = GetCoordinateProperty(coord, "X", "Primary", "Secondary");
                    if (xObj is not null)
                    {
                        try
                        {
                            // normalize to decimal for comparisons and to long for DateTime ticks
                            var coordXDecimal = Convert.ToDecimal(xObj);
                            ticks = Convert.ToInt64(coordXDecimal);

                            // Try to find a matching NamedPoint by comparing decimals (tolerance 0.5)
                            var found = points.FirstOrDefault(p =>
                            {
                                try
                                {
                                    // Convert p.X to decimal to avoid mixing double and decimal types
                                    var pxDecimal = Convert.ToDecimal(p.X);
                                    return Math.Abs(pxDecimal - coordXDecimal) < 0.5m;
                                }
                                catch
                                {
                                    return false;
                                }
                            });

                            if (found is not null) name = found.Name;
                        }
                        catch
                        {
                            // ignore fallback errors
                        }
                    }
                }

                // Build time string
                var time = ticks > 0 ? new DateTime(ticks) : DateTime.Now;
                if (!string.IsNullOrEmpty(name))
                    return $"{time:HH:mm} - {name}";

                return $"{time:HH:mm}";
            };

            series.YToolTipLabelFormatter = cp =>
            {
                double yValue = 0;
                if (cp.Model is NamedPoint np)
                {
                    try
                    {
                        yValue = Convert.ToDouble(np.Y);
                    }
                    catch
                    {
                        yValue = 0;
                    }
                }
                else
                {
                    var coord = cp.Coordinate;
                    var yObj = GetCoordinateProperty(coord, "Y", "Secondary", "Primary");
                    if (yObj is not null)
                    {
                        try
                        {
                            yValue = Convert.ToDouble(yObj);
                        }
                        catch
                        {
                            yValue = 0;
                        }
                    }
                }

                var active = (int)Math.Round(yValue);
                return $"Aktiva: {active}";
            };

            // X-axel med 15-minuters intervall
            var xAxis = new Axis
            {
                Labeler = v => new DateTime((long)v).ToString("HH:mm"),
                UnitWidth = TimeSpan.FromMinutes(15).Ticks,
                MinStep = TimeSpan.FromMinutes(15).Ticks,
                Name = "Tid",
                LabelsPaint = new SolidColorPaint(SKColors.Yellow),
                NamePaint = new SolidColorPaint(SKColors.Yellow)
            };

            // Y-axel
            var yAxis = new Axis
            {
                Name = "Aktiva användare",
                MinLimit = 0,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow),
                NamePaint = new SolidColorPaint(SKColors.Yellow)
            };

            // Tilldela till chart
            chart.Series = new ISeries[] { series };
            chart.XAxes = new Axis[] { xAxis };
            chart.YAxes = new Axis[] { yAxis };
        }



        private void Update_User_flp(FlowLayoutPanel flp, TimeRecording.AttendanceChart user)
        {
            if (user.IsClosedInterval || user.AbsenceDescription != null)
                flp.BackColor = Color.FromArgb(120, CustomColors.Bad_Front);
            else
                flp.BackColor = Color.FromArgb(50, CustomColors.Ok_Front);

            Label end = (Label)flp.Controls["End"];
            string endtime = "";
            if (user.IsClosedInterval)
                endtime += $"End: {user.IntervalEnd}";
            end.Text = endtime;

            Label lbl_loggedIn = (Label)flp.Controls["LoggedIn"];

            var loggedIn = user.AbsenceDescription ?? Time(user);
            lbl_loggedIn.Invoke(new Action(() => lbl_loggedIn.Text = loggedIn));

        }

        private async void cb_Monitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Clear_ListAsync();
            Database.MonitorCompany = cb_Monitor.SelectedItem.ToString();
            Login_Monitor.Login_API(true);
            Refresh();
            //flp_List.Controls.Clear();
            Fill_OnlineMonitorUsers();
        }

        private void flp_List_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in flp_List.Controls)
            {
                ctrl.Width = flp_List.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            }
        }
    }
}
