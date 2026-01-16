using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Statistics;
using DigitalProductionProgram.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    public class ApplicationScheduler
    {
        private readonly System.Windows.Forms.Timer _masterTimer;

        // Counters
        private int _changeGrade;
        private int _planeratStopp;
        private int _checkForUpdate;
        private int _checkMätpunkter;
        private int _updateChart;
        private int timer_counterPlaneratStopp = 60;  // 1 timme
        private int timer_CheckForUpdate = 10; //10 minut
        private const int develop_MainTimer = 30000; // 10 sekunder

        private readonly Func<Task> _updateMeasureInfo;
        private readonly Action _updateGuiGrade;
        private readonly Statistics_DPP _statistics;
        private readonly ServerStatus _serverStatus;

        public ApplicationScheduler(Func<Task> updateMeasureInfo, Action updateGuiGrade, Statistics_DPP statistics, ServerStatus serverStatus)
        {
            _updateMeasureInfo = updateMeasureInfo;
            _updateGuiGrade = updateGuiGrade;
            _statistics = statistics;
            _serverStatus = serverStatus;
            _masterTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // 1 sekund
            };

            _masterTimer.Tick += MasterTimer_Tick;
        }


       

        
        public void Start()
        {
           
            if (Environment.MachineName == Main_Form.adminHostName && Main_Form.IsAutoLoginSuperAdmin)
                _masterTimer.Interval = develop_MainTimer;
            else
                _masterTimer.Interval = 60000; // 1 minut
            _masterTimer.Tick += MasterTimer_Tick;
            _masterTimer.Start();
        }

        public void Stop() => _masterTimer.Stop();
        private async Task RunUpdateChartAsync()
        {
            await _updateMeasureInfo();
        }

        private async void MasterTimer_Tick(object? sender, EventArgs e)
        {
            _masterTimer.Stop();

            TickCounters();
            UpdateServerStatus();

            await RunScheduledTasksAsync();

            _masterTimer.Start();
        }
        private void TickCounters()
        {
            _changeGrade++;
            _planeratStopp++;
            _checkForUpdate++;
            _checkMätpunkter++;
            _updateChart++;
        }
        private void UpdateServerStatus()
        {
            _serverStatus.Set_Sql_Counter();

            Activity.LoadMemory();
            _serverStatus.Set_DPP_Memory_Usage(Activity.CurrentMemory.ToString());
        }

        private async Task RunScheduledTasksAsync()
        {
            if (_planeratStopp >= timer_counterPlaneratStopp)
            {
                _planeratStopp = 0;
                CheckForMaintenanceWork();
            }

            if (_checkForUpdate >= timer_CheckForUpdate)
            {
                _checkForUpdate = 0;
                CheckForUpdate();
            }

            if (_checkMätpunkter >= 5 &&
                Person.Role == "SuperAdmin" &&
                Main_Form.IsZumbachÖppet == false)
            {
                _checkMätpunkter = 0;
                MainMeasureStatistics.ValidateMeasurements.AverageValues();
            }

            if (_updateChart >= 1 && Main_Form.IsZumbachÖppet == false)
            {
                _updateChart = 0;

                if (!string.IsNullOrEmpty(Order.OrderNumber))
                {
                    await RunUpdateChartAsync();
                }

                await _statistics.Load_StatisticsAsync();
            }

            if (_changeGrade >= 10 && Main_Form.IsZumbachÖppet == false)
            {
                _changeGrade = 0;
                _updateGuiGrade();
            }
        }

        public void CheckForUpdate()
        {
            if (ChangeLog.LatestVersion is null)
                return;

            if (ChangeLog.LatestVersion.CompareTo(ChangeLog.CurrentVersion) <= 0)
                return;

            if (Program.IsUpdateCritical)
            {
                InfoText.Show(LanguageManager.GetString("update_Info_1"), CustomColors.InfoText_Color.Bad, "Warning!");

                Maintenance.StartInstallation();
                _checkForUpdate = 1; // 1 minut mellan försöken
                return;
            }

            Activity.Start();

            InfoText.Question(
                $"{LanguageManager.GetString("update_Info_1_1")}\n\n" +
                $"{ChangeLog.News}\n" +
                $"{LanguageManager.GetString("update_Info_1_2")}",
                CustomColors.InfoText_Color.Warning, "Warning!");

            if (InfoText.answer == InfoText.Answer.No)
            {
                _ = Activity.Stop($"User {Person.Name} did NOT update the application");
                timer_CheckForUpdate = 120; // 2 timmar
            }
            else
            {
                _ = Activity.Stop($"User {Person.Name} updated the Application");
                Maintenance.StartInstallation();
            }
        }
        public void CheckForMaintenanceWork()
        {
            if (Person.Role == "SuperAdmin")
                return;

            if (Maintenance.IsMaintenance_Ongoing)
            {
                InfoText.Show($"{LanguageManager.GetString("maintenanceWork_1")} {Maintenance.Time_Ongoing}.",
                    CustomColors.InfoText_Color.Bad, "Info");
                Application.Exit();
                Environment.Exit(0);
                return;
            }

            if (!Maintenance.IsMaintenance_Coming)
                return;

            var clr = CustomColors.InfoText_Color.Ok;
            //Mellan 8 timmar och 2 dygn kvar till planerat stopp
            if (Maintenance.Time_Left_Stop.TotalHours > 8)
            {
                timer_counterPlaneratStopp = 60; // 1 timme
                clr = CustomColors.InfoText_Color.Warning;
            }

            //Mer än 2 dygn kvar till planerat stopp
            if (Maintenance.Time_Left_Stop.TotalDays > 2)
            {
                timer_counterPlaneratStopp = 420; // 7 timmar
                clr = CustomColors.InfoText_Color.Ok;
            }

            //Mindre än 8 timmar kvar till planerat stopp
            if (Maintenance.Time_Left_Stop.TotalHours < 8)
            {
                timer_counterPlaneratStopp = 30; // 30 minuter
                clr = CustomColors.InfoText_Color.Bad;
            }


            Activity.Start();
            InfoText.Show($"{LanguageManager.GetString("maintenanceWork_4")} {Maintenance.Time_Left} \n\n" +
                          $"{Maintenance.Date_PlannedStop} {LanguageManager.GetString("maintenanceWork_2")}\n\n" +
                          $"{LanguageManager.GetString("maintenanceWork_3")} {Maintenance.PlannedTime}", clr, "Info");
            _ = Activity.Stop($"{Person.Name} has read about the scheduled downtime");

        }
    }
}
