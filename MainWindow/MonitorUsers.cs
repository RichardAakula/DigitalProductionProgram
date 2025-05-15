using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.Monitor;
using DigitalProductionProgram.Monitor.GET;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using Action = System.Action;

namespace DigitalProductionProgram.MainWindow
{
    public partial class MonitorUsers : UserControl
    {
        private readonly List<DateTime> date_Meeting_Start = new List<DateTime>();
        private readonly List<FlowLayoutPanel> list_flp_Meetings = new List<FlowLayoutPanel>();
        private readonly List<int> Alpha_Color = new List<int>();
        private readonly List<System.Windows.Forms.Timer> timer_Change_Color_Meetings = new List<System.Windows.Forms.Timer>();
        private int ctr_Meeting_Starting;
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
        private DoubleBufferedFlowLayoutPanel flp_List = new DoubleBufferedFlowLayoutPanel();

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
        public void Fill_Meetings()
        {
           // if (Environment.MachineName != "RICHARDA-HPZ240" && Environment.MachineName != "GOD-JOHANU-SP6")
           // {
           //     flp_List.Visible = false;
           //     timer_Update.Stop();
           //     return;
           // }

           //// Clear_List(flp_List);
           // date_Meeting_Start.Clear();
           // list_flp_Meetings.Clear();
           // Alpha_Color.Clear();
           // timer_Change_Color_Meetings.Clear();
           // ctr_Meeting_Starting = 0;
           // Application oApp = new Application();
           // NameSpace oNS = oApp.GetNamespace("MAPI");
           // List<MAPIFolder> calendars = new List<MAPIFolder>();

           // Accounts accounts = oNS.Accounts;
           // foreach (Account account in accounts)
           // {
           //     Recipient recipient = oNS.CreateRecipient(account.DisplayName);

           //     MAPIFolder calendar = oNS.GetSharedDefaultFolder(recipient,
           //         OlDefaultFolders.olFolderCalendar);
           //     if (calendar != null)
           //         calendars.Add(calendar);
           // }

           // foreach (var folder in calendars)
           // {
           //     DateTime dateFrom = DateTime.Now;
           //     DateTime dateTo = DateTime.Now.AddDays(30);

           //     string start = dateFrom.ToString("yyyy-MM-dd");
           //     string end = dateTo.ToString("yyyy-MM-dd");


           //     string searchCriteria = "[Start]<=\"" + end + "\"" + " AND [End]>=\"" +
           //                             start + "\"";
           //     int counter = default;
           //     //  try
           //     {
           //         var folderItems = folder.Items;
           //         folderItems.IncludeRecurrences = true;
           //         folderItems.Sort("[Start]");
           //         if (folderItems.Count > 0)
           //         {
           //             object resultItem = folderItems.Find(searchCriteria);
           //             if (resultItem != null)
           //             {
           //                 do
           //                 {
           //                     if (resultItem is _AppointmentItem appItem)
           //                     {
           //                         counter++;
           //                         Add_Meeting_flp(appItem);
           //                     }

           //                     Marshal.ReleaseComObject(resultItem);
           //                     resultItem = folderItems.FindNext();
           //                 } while (resultItem != null && counter < 5);

           //                 flp_List.Visible = true;
           //             }
           //         }

           //     }
           // }
        }
        
        //private void Add_Meeting_flp(_AppointmentItem item)
        //{
        //    int width = flp_List.Width + 10;

        //    FlowLayoutPanel flp = new FlowLayoutPanel
        //    {
        //        BorderStyle = BorderStyle.FixedSingle,
        //        BackColor = Color.Transparent,
        //        FlowDirection = FlowDirection.TopDown,
        //        AutoSize = true,
        //        MaximumSize = new Size(width - 20, 1000),
        //        Left = 5,
               
        //    };

        //    Label lbl_Organizer = new Label
        //    {
        //        Text = item.Organizer,
        //        TextAlign = ContentAlignment.MiddleCenter,
        //        ForeColor = Color.LightGray,
        //        BackColor = Color.Transparent,
        //        Font = new Font("Palatino LineType", 10, FontStyle.Bold),
        //        Width = width
        //    };
        //    Label lbl_Subject = new Label
        //    {
        //        Text = item.Subject,
        //        ForeColor = Color.Lime,
        //        BackColor = Color.Transparent,
        //        Font = new Font("Palatino LineType", 10),
        //        AutoSize = true
        //    };
        //    Label lbl_Location = new Label
        //    {
        //        Text = item.Location,
        //        ForeColor = Color.Gold,
        //        BackColor = Color.Transparent,
        //        Font = new Font("Palatino LineType", 10),
        //        AutoSize = true,
        //        MaximumSize = new Size(width - 20, 1000)
        //    };
        //    Label lbl_Date = new Label
        //    {
        //        Text = item.Start.ToString("yyyy-MM-dd"),
        //        ForeColor = Color.LightCyan,
        //        BackColor = Color.Transparent,
        //        Font = new Font("Palatino LineType", 10),
        //        Width = width
        //    };
        //    Label lbl_Start = new Label
        //    {
        //        Text = $"{item.Start.ToString("HH:mm")} - {item.End.ToString("HH:mm")}",
        //        ForeColor = Color.LightCyan,
        //        BackColor = Color.Transparent,
        //        Font = new Font("Palatino LineType", 10),
        //        Width = width
        //    };

        //    flp.Controls.Add(lbl_Organizer);
        //    flp.Controls.Add(lbl_Subject);
        //    flp.Controls.Add(lbl_Location);
        //    flp.Controls.Add(lbl_Date);
        //    flp.Controls.Add(lbl_Start);

        //    if (item.Start < DateTime.Now && DateTime.Now < item.End)
        //        flp.BackColor = Color.FromArgb(120, 156, 101, 0); //Gul Bakgrund = Möte Pågår

        //    if (DateTime.Now > item.End)
        //        flp.BackColor = Color.FromArgb(80, 156, 0, 6); //Röd Bakgrund = Möte Klart

        //    if (DateTime.Now < item.Start && DateTime.Now < item.End) //Grön Bakgrund = Möte på kommande
        //    {
        //        flp.BackColor = Color.FromArgb(0, 198, 239, 206);
        //        list_flp_Meetings.Add(flp);
        //        date_Meeting_Start.Add(item.Start);

        //        Create_Timer_Fill_flp_Meeting(ctr_Meeting_Starting);
        //        ctr_Meeting_Starting++;
        //    }


        //    flp_List.Controls.Add(flp);

        //}
        private void Create_Timer_Fill_flp_Meeting(int ctr_Timer)
        {
            Alpha_Color.Add(0);
            TimeSpan span = date_Meeting_Start[ctr_Timer].Subtract(DateTime.Now);
            var min_Left = (int)span.TotalMinutes;
            var interval = (double)min_Left / 120 * 60 * 1000;
            if (!(interval > 0)) return;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer_Change_Color_Meetings.Add(timer);
            if (ctr_Timer >= timer_Change_Color_Meetings.Count)
            {
                if (Person.Name == "Richard Aakula")
                    MessageBox.Show("fel på timer");
                return;
            }

            timer_Change_Color_Meetings[ctr_Timer].Interval = (int)interval;
            timer_Change_Color_Meetings[ctr_Timer].Tick += (sender, e) =>
                Timer_Change_Color_Meeting_Tick(ctr_Timer);
            Alpha_Color[ctr_Timer] = 0;
            timer_Change_Color_Meetings[ctr_Timer].Start();
        }
        private void Timer_Change_Color_Meeting_Tick(int ctr_Timer)
        {
            if (ctr_Timer >= Alpha_Color.Count)
                return;

            Alpha_Color[ctr_Timer]++;

            if (Alpha_Color[ctr_Timer] < 120)
                list_flp_Meetings[ctr_Timer].BackColor = Color.FromArgb(Alpha_Color[ctr_Timer], 168, 209, 176);
            else
            {
                timer_Change_Color_Meetings[ctr_Timer].Stop();
                timer_Change_Color_Meetings[ctr_Timer].Dispose();
                Alpha_Color.RemoveAt(ctr_Timer);
                list_flp_Meetings[ctr_Timer].BackColor = Color.FromArgb(120, 156, 101, 0);
            }
        }

        private bool Is_flp_Exist(string name)
        {
            return flp_List.Controls.Cast<Control>().Any(control => control.Name == name);
        }
        public void Fill_OnlineMonitorUsers()
        {
            if (Monitor.Monitor.List_Users is null)
                return;
            foreach (var user in Monitor.Monitor.List_Users)
            {
                var name = $"{user.FirstName} {user.LastName}";
                if (Is_flp_Exist(name))
                {
                    var flp = (FlowLayoutPanel)flp_List.Controls[name];
                    Update_User_flp(flp, user);
                }
                else
                    Add_User_flp(user);
            }
            Login_Monitor.Login_API();
        }
        private void Add_User_flp(TimeRecording.AttendanceChart user)
        {
            if (flp_List.InvokeRequired)
            {
                flp_List.Invoke(new Action(() => Add_User_flp(user)));
            }
            else
            {
                FlowLayoutPanel flp = new FlowLayoutPanel
                {
                    Name = $"{user.FirstName} {user.LastName} - {user.EmployeeNumber}",
                    FlowDirection = FlowDirection.TopDown,
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = flp_List.Width - 23,
                    Height = 90,
                };
                if (user.IsClosedInterval || user.AbsenceDescription != null)
                    flp.BackColor = Color.FromArgb(120, CustomColors.Bad_Front);
                else
                    flp.BackColor = Color.FromArgb(50, CustomColors.Ok_Front);

                var lbl_Name = new Label
                {
                    Text = $"{user.FirstName} {user.LastName}",
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.TopCenter,
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    Font = new Font("Palatino LineType", 10),
                    Width = flp_List.Width
                };
                var lbl_Start = new Label
                {
                    Name = "Start",
                    Text = $"Start: {user.IntervalStart}",
                    ForeColor = Color.FromArgb(50, 50, 50),
                    BackColor = Color.Transparent,
                    Font = new Font("Palatino LineType", 9),
                    Width = flp_List.Width
                };

                string loggedIn = null;
                if (!user.IsClosedInterval)
                    loggedIn = Time(user);
                var lbl_LoggedIn = new Label
                {
                    Name = "LoggedIn",
                    Text = loggedIn,
                    ForeColor = Color.FromArgb(50, 50, 50),
                    BackColor = Color.Transparent,
                    Font = new Font("Palatino LineType", 9),
                    Width = flp_List.Width
                };

                string endtime = "";
                if (user.IsClosedInterval)
                    endtime += $"End: {user.IntervalEnd}";
                var lbl_End = new Label
                {
                    Name = "End",
                    Text = endtime,
                    ForeColor = Color.FromArgb(50, 50, 50),
                    BackColor = Color.Transparent,
                    Font = new Font("Palatino LineType", 9),
                    Width = flp_List.Width
                };
                var lbl_Absence = new Label
                {
                    Name = "Test",
                    Text = user.AbsenceDescription,
                    ForeColor = Color.FromArgb(50, 50, 50),
                    BackColor = Color.Transparent,
                    Font = new Font("Palatino LineType", 9),
                    Width = flp_List.Width
                };

                flp.Controls.Add(lbl_Name);
                flp.Controls.Add(lbl_Start);
                flp.Controls.Add(lbl_Absence);
                if (!user.IsClosedInterval)
                    flp.Controls.Add(lbl_LoggedIn);
                flp.Controls.Add(lbl_End);

                flp_List.Controls.Add(flp);
            }
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
