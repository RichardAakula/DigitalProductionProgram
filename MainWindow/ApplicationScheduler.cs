using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Statistics;
using DigitalProductionProgram.User;
using System.Diagnostics;
using Activity = DigitalProductionProgram.Log.Activity;

namespace DigitalProductionProgram.MainWindow
{
    public class ApplicationScheduler
    {
        private readonly System.Windows.Forms.Timer _masterTimer;

        // Counters
        private int minutes_UpdateGrade;
        private int minutes_CheckMaintenanceWork;
        private int minutes_CheckForUpdate;
        private int minutes_CheckMeasurementValues;
        private int minutes_UpdateChart;

        private int timer_counterPlaneratStopp = 60;  // 1 timme
        //private int timer_CheckForUpdate = 10; //10 minut
        private const int develop_MainTimer = 30000; // 30 sekunder

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
                Interval = 60000 // 1 sekund
            };

            _masterTimer.Tick += MasterTimer_Tick;
        }


       

        
        public void Start()
        {
            if (Environment.MachineName == Main_Form.adminHostName && Main_Form.IsAutoLoginSuperAdmin)
                _masterTimer.Interval = develop_MainTimer;
            else
                _masterTimer.Interval = 60000; // 1 minut
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
            minutes_UpdateGrade++;
            minutes_CheckMaintenanceWork++;
            minutes_CheckForUpdate++;
            minutes_CheckMeasurementValues++;
            minutes_UpdateChart++;
        }
        private void UpdateServerStatus()
        {
            _serverStatus.Set_Sql_Counter();

            Activity.LoadMemory();
            _serverStatus.Set_DPP_Memory_Usage(Activity.CurrentMemory.ToString());
        }

        private async Task RunScheduledTasksAsync()
        {
            Debug.WriteLine("");
            Debug.WriteLine("------------------------------------------------------");
            Debug.WriteLine("-------------------MasterTimer Start-------------------");
            Debug.WriteLine($"--{DateTime.Now}");
            Debug.WriteLine($"Check Mätpunkter:  {minutes_CheckMeasurementValues}");
            Debug.WriteLine($"Uppdatera Chart:   {minutes_UpdateChart}");
            Debug.WriteLine($"Kolla Uppdatering: {minutes_CheckForUpdate}");
            Debug.WriteLine($"Uppdatera Grade:   {minutes_UpdateGrade}");
            Debug.WriteLine($"Check Maintenance: {minutes_CheckMaintenanceWork}");
            Debug.WriteLine("");

            //----5 minuter----
            //----Kontrollerar att mätningarna inte ligger för nära gränser. OBS! Endast under utveckling ännu----
            if (minutes_CheckMeasurementValues >= 5 && Person.Role == "SuperAdmin" && Main_Form.IsZumbachÖppet == false)
            {
                Debug.WriteLine("----Check Mätpunkter----");
                minutes_CheckMeasurementValues = 0;
                MainMeasureStatistics.ValidateMeasurements.AverageValues();
            }

            //----5 minuter----
            //----Uppdaterar mätvärden i MainForm samt Chart----
            //----Denna ligger i Main_Form.Task UpdateMeasureInformationAsync()
            if (minutes_UpdateChart >= 5 && Main_Form.IsZumbachÖppet == false)
            {
                Debug.WriteLine("----Uppdatera Chart----");
                minutes_UpdateChart = 0;

                if (!string.IsNullOrEmpty(Order.OrderNumber))
                    await RunUpdateChartAsync();

                await _statistics.Load_StatisticsAsync();
            }

            //----10 minuter----
            //----Kollar om det finns en ny version av programmet och uppdaterar vid behov----
            if (minutes_CheckForUpdate >= 10)
            {
                Debug.WriteLine("----Kolla Uppdatering----");
                minutes_CheckForUpdate = 0;
                CheckForUpdate();
            }

            //----10 minuter----
            //----Uppdatera GUI Grade----
            //----Denna ligger i Main_Form.Change_GUI_Grade()
            if (minutes_UpdateGrade >= 10 && Main_Form.IsZumbachÖppet == false)
            {
                Debug.WriteLine("----Uppdatera Grade----");
                minutes_UpdateGrade = 0;
                _updateGuiGrade();
            }

            //----60 minuter----
            if (minutes_CheckMaintenanceWork >= timer_counterPlaneratStopp)
            {
                Debug.WriteLine("----Check Maintenance----");
                minutes_CheckMaintenanceWork = 0;
                CheckForMaintenanceWork();
            }
            Debug.WriteLine("-------------------MasterTimer Stop--------------------");
            Debug.WriteLine("------------------------------------------------------\n");
        }

        public void CheckForUpdate()
        {
            Version currentVersion = ChangeLog.CurrentVersion;
            Version latestAllowedtVersion = ChangeLog.LatestAllowedVersion;

            if (latestAllowedtVersion is null)
                return;

            if (latestAllowedtVersion.CompareTo(currentVersion) <= 0)
                return;

            if (Program.IsUpdateCritical)
            {
                InfoText.Show(LanguageManager.GetString("update_Info_1"), CustomColors.InfoText_Color.Bad, "Warning!");

                Maintenance.StartInstallation(true);
                minutes_CheckForUpdate = 1; // 1 minut mellan försöken
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
                _ = Activity.Stop($"User {Person.Name} did NOT update the application. CurrentVersion = {currentVersion} - LatestVersion = {latestAllowedtVersion}");
                minutes_CheckForUpdate = 120; // 2 timmar
            }
            else
            {
                _ = Activity.Stop($"User {Person.Name} updated the Application. CurrentVersion = {currentVersion} - LatestVersion = {latestAllowedtVersion}");
                Maintenance.StartInstallation(false);
            }
        }

        private void CheckForMaintenanceWork()
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
