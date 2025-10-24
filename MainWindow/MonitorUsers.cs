using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Action = System.Action;

namespace DigitalProductionProgram.MainWindow
{
    public partial class MonitorUsers : UserControl
    {
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
            Login_Monitor.Login_API();
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
                    RowCount = 3,
                    ColumnCount = 3,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = flp_List.Width - 23,
                    Height = 75,
                };
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200)); // Kolumn 1
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));       // Kolumn 2
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200)); // Kolumn 3

                // Raddefinitioner (du kan justera höjder om du vill)
                tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Rad 1
                tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Rad 2
                tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Rad 3
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

                tlp.Controls.Add(lbl_Name, 0, 0);
                tlp.SetColumnSpan(lbl_Name, 3);
                
                tlp.Controls.Add(lbl_Start, 0, 1);
                tlp.Controls.Add(lbl_End, 2, 1);

                tlp.Controls.Add(lbl_Absence, 1,1);
                tlp.Controls.Add(lbl_LoggedIn, 0, 2);

                flp_List.Controls.Add(tlp);
            }
        }

        private void CreateChart()
        {
            chart.Series = Array.Empty<ISeries>();
            chart.XAxes = Array.Empty<Axis>();
            chart.YAxes = Array.Empty<Axis>();
            events = events.OrderBy(e => e.Time).ToList();
            var count = 0;
            var chartPoints = new List<(DateTime time, int activeUsers, string name)>();
            foreach (var e in events)
            {
                if (e.Type == EventType.Login)
                    count++;
                else
                    count--;

                chartPoints.Add((e.Time, count, e.Name));
            }

            var series = new LineSeries<int>
            {
                Values = chartPoints.Select(p => p.activeUsers).ToList(),
                Fill = null, // ingen fyllning under kurvan
                GeometrySize = 5,
            };

            // Skapa X-axel som visar tiden
            var xAxis = new Axis
            {
                //Labels = chartPoints.Select(p => p.time.ToString("HH:mm")).ToArray(),
                Labels = chartPoints.Select(p => $"{p.time:HH:mm} - {p.name}").ToArray(),
                LabelsRotation = 45, // snedställda etiketter om det blir trångt
                Name = "Tid",
                LabelsPaint = new SolidColorPaint(SKColors.Yellow) { SKTypeface = SKTypeface.Default },
                NamePaint = new SolidColorPaint(SKColors.Yellow) { SKTypeface = SKTypeface.Default }
            };
            var yAxis = new Axis
            {
                Name = "Aktiva användare",
                MinLimit = 0,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow) { SKTypeface = SKTypeface.Default },
                NamePaint = new SolidColorPaint(SKColors.Yellow) { SKTypeface = SKTypeface.Default }
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

            Label end = (Label) flp.Controls["End"];
            string endtime = "";
            if (user.IsClosedInterval)
                endtime += $"End: {user.IntervalEnd}";
            end.Text = endtime;

            Label lbl_loggedIn = (Label) flp.Controls["LoggedIn"];
            
            var loggedIn = user.AbsenceDescription ?? Time(user);
            lbl_loggedIn.Invoke(new Action(() => lbl_loggedIn.Text = loggedIn));

        }

    }
}
