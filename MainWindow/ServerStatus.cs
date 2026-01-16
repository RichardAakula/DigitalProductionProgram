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


        public static string? DPP_ServerStatus;
        private Main_Form? mainForm;
        private static readonly object _lock = new();
        public static readonly Dictionary<string, int> dictMethodsSqlCounter = new();


        public ServerStatus()
        {
            InitializeComponent();
            LoginStatusChanged += OnLoginStatusChanged;
            DatabaseConnectionStatus.StatusChanged += OnDatabaseStatusChanged;
        }
       
        public void SetMainForm(Main_Form form)
        {
            mainForm = form;
        }
        private void OnLoginStatusChanged(LoginResult result)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => OnLoginStatusChanged(result)));
                return;
            }

            if (!result.Success)
            {
                lbl_MonitorStatus.ForeColor = Color.DarkRed;
                
            }

            switch (result.ElapsedMilliseconds)
            {
                case > 400:
                    lbl_MonitorStatus.ForeColor = Color.Red;
                    break;
                case > 300:
                    lbl_MonitorStatus.ForeColor = Color.DarkOrange;
                    break;
                case > 250:
                    lbl_MonitorStatus.ForeColor = Color.Orange;
                    break;
                default:
                    lbl_MonitorStatus.ForeColor = Color.Green;
                    break;
            }
           
        }
        private void OnDatabaseStatusChanged(DatabaseExecutionResult result)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => OnDatabaseStatusChanged(result)));
                return;
            }

            switch (result.ElapsedMilliseconds)
            {
                case > 50:
                    lbl_DPP_Status.ForeColor = Color.Red;
                    break;
                case > 30:
                    lbl_DPP_Status.ForeColor = Color.DarkOrange;
                    break;
                case > 20:
                    lbl_DPP_Status.ForeColor = Color.Orange;
                    break;
                default:
                    lbl_DPP_Status.ForeColor = Color.Green;
                    break;
            }
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
            tooltip.SetToolTip(lbl_MonitorStatus, Monitor.Monitor.MonitorStatus);
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
            tooltip.SetToolTip(lbl_DPP_Status, DPP_ServerStatus);
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
