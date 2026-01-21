using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.EasterEggs;

namespace DigitalProductionProgram.MainWindow
{
    public partial class ServerStatus : UserControl
    {
        public static LoginResult? LastLoginResult { get; private set; }
        public static event Action<LoginResult>? LoginStatusChanged;
        public static void Report(LoginResult result)
        {
            LastLoginResult = result;
            LoginStatusChanged?.Invoke(result);
        }

        private string MonitorTime;
        private string DPP_Status;
        private Main_Form? mainForm;
        private static readonly object _lock = new();
        public static readonly Dictionary<string, int> dictMethodsSqlCounter = new();
        private Color GetStatusColor(long ms)
        {
            // Begränsa till 10–1000 ms
            ms = Math.Clamp(ms, 10, 1000);

            // Definiera steg: 10 steg från grönt till mörkrött
            Color[] colors =
            [
                Color.FromArgb(0, 200, 0),     // 10-50ms → Ljusgrön
                Color.FromArgb(50, 220, 0),    // 51-140ms
                Color.FromArgb(100, 220, 0),   // 141-230ms
                Color.FromArgb(150, 200, 0),   // 231-320ms
                Color.FromArgb(200, 180, 0),   // 321-410ms
                Color.FromArgb(220, 150, 0),   // 411-500ms → orange
                Color.FromArgb(240, 100, 0),   // 501-600ms
                Color.FromArgb(250, 60, 0),    // 601-700ms
                Color.FromArgb(255, 0, 0),     // 701-850ms → röd
                Color.FromArgb(140, 0, 0)      // 851-1000ms → mörkröd
            ];

            int index = (int)((ms - 10) / ((1000 - 10) / (colors.Length - 1.0)));
            index = Math.Clamp(index, 0, colors.Length - 1);

            return colors[index];
        }

        public ServerStatus()
        {
            InitializeComponent();
            LoginStatusChanged += OnMonitorStatusChanged;
            DatabaseConnectionStatus.StatusChanged += OnDatabaseStatusChanged;
        }
       
        public void SetMainForm(Main_Form form)
        {
            mainForm = form;
        }
        private void OnMonitorStatusChanged(LoginResult result)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => OnMonitorStatusChanged(result)));
                return;
            }

            if (!result.Success)
            {
                lbl_MonitorStatus.ForeColor = Color.DarkRed;
                MonitorTime = Monitor.Monitor.status.ToString();    //Kolla om denna funkar samt vad den visar
            }

            MonitorTime = $"{result.ElapsedMilliseconds} ms";
            lbl_MonitorStatus.ForeColor = GetStatusColor(result.ElapsedMilliseconds);
            //switch (result.ElapsedMilliseconds)
            //{
            //    case > 700:
            //        lbl_MonitorStatus.ForeColor = Color.OrangeRed;
            //        break;
            //    case > 500:
            //        lbl_MonitorStatus.ForeColor = Color.DarkOrange;
            //        break;
            //    case > 400:
            //        lbl_MonitorStatus.ForeColor = Color.Orange;
            //        break;
            //    default:
            //        lbl_MonitorStatus.ForeColor = Color.Green;
            //        break;
            //}
           
        }
        private void OnDatabaseStatusChanged(DatabaseExecutionResult result)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => OnDatabaseStatusChanged(result)));
                return;
            }

            DPP_Status = $"{result.ElapsedMilliseconds} ms";
            lbl_DPP_Status.ForeColor = GetStatusColor(result.ElapsedMilliseconds);
        }
        [DebuggerStepThrough]
        public static void Add_Sql_Counter([CallerMemberName]string methodname = null)
        {
            Database.SQL_Counter++;
            lock (_lock)
            {
                if (dictMethodsSqlCounter.ContainsKey(methodname))
                    dictMethodsSqlCounter[methodname]++;
                else
                    dictMethodsSqlCounter[methodname] = 1;
            }

        }

        public void Set_Sql_Counter()
        {
            lbl_SQL_Queries.Text = Database.SQL_Counter.ToString();
        }
        public void Set_DPP_Memory_Usage(string memoryUsage)
        {
            lbl_Memory.Text = memoryUsage;
        }
        private void MonitorStatus_MouseHover(object sender, EventArgs e)
        {
            var tooltip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };
            tooltip.SetToolTip(lbl_MonitorStatus, MonitorTime); //Monitor.Monitor.MonitorStatus);
        }
        private void DPP_Status_MouseHover(object sender, EventArgs e)
        {
            var tooltip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };
            tooltip.SetToolTip(lbl_DPP_Status, DPP_Status);
        }
        private void FlyingEasterEggClick_Click(object sender, EventArgs e)
        {
            if (mainForm != null && EasterEgg_HighScore.IsOkStartGame("Flying Easter Egg", mainForm))
            {
                FlyingEasterEgg flying = new FlyingEasterEgg(mainForm);
                flying.StartGame();
            }
        }
        
    }


    public static class DatabaseConnectionStatus
    {
        public static DatabaseExecutionResult? LastResult { get; private set; }

        public static event Action<DatabaseExecutionResult>? StatusChanged;

        public static void Report(DatabaseExecutionResult result)
        {
            LastResult = result;
            StatusChanged?.Invoke(result);
        }
    }
    public class LoginResult
    {
        public bool Success { get; init; }
        public long ElapsedMilliseconds { get; init; }

    }
    public class DatabaseExecutionResult
    {
        public bool Success { get; init; }
        public long ElapsedMilliseconds { get; init; }
    }
}
