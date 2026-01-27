using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.Log
{
    internal class Maintenance
    {
        public static TimeSpan Time_Left_Stop
        {
            get
            {
                DateTime stop;
                var now = DateTime.Now;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT Datum FROM Log.Maintenance_Work WHERE Datum > @now";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);
                    stop = DateTime.Parse(cmd.ExecuteScalar().ToString() ?? string.Empty);
                }
                return stop.Subtract(now);
            }
        }
        public static TimeSpan Time_Ongoing_Maintenance
        {
            get
            {
                DateTime start;
                var now = DateTime.Now;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT Datum FROM Log.Maintenance_Work WHERE Datum < @now AND Done = 'False'";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);
                    start = DateTime.Parse(cmd.ExecuteScalar().ToString() ?? string.Empty);
                }

                return now.Subtract(start);
            }
        }
        public static string Date_PlannedStop
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT Datum FROM Log.Maintenance_Work WHERE Datum > @now";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@now", DateTime.Now);
                var result = cmd.ExecuteScalar()?.ToString();

                if (string.IsNullOrEmpty(result))
                    return string.Empty;

                var date = DateTime.Parse(result);
                return date.ToString("dddd yyyy/MM/dd HH:mm"); 
            }
        }


        public static bool IsMaintenance_Coming
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT * FROM Log.Maintenance_Work WHERE Datum > @now";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@now", DateTime.Now);
                var reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }
        public static bool IsMaintenance_Ongoing
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT * FROM Log.Maintenance_Work WHERE Datum < @now AND Done = 'False'";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@now", DateTime.Now);
                var reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }
        public static string Time_Left
        {
            get
            {
                var days = Time_Left_Stop.Days;
                var hours = Time_Left_Stop.Hours;
                var minutes = Time_Left_Stop.Minutes;

                return $"{days} {LanguageManager.GetString("maintenanceWork_days")}: {hours} {LanguageManager.GetString("maintenanceWork_hours")}: {minutes} {LanguageManager.GetString("maintenanceWork_minutes")}";
            }
        }
        public static string Time_Ongoing
        {
            get
            {
                var hours = Time_Ongoing_Maintenance.Hours;
                var minutes = Time_Ongoing_Maintenance.Minutes;

                return $" {hours} {LanguageManager.GetString("maintenanceWork_hours")}: {minutes} {LanguageManager.GetString("maintenanceWork_minutes")}";
            }
        }
        public static string PlannedTime
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT Info FROM Log.Maintenance_Work WHERE Datum > @now";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@now", DateTime.Now);
                return cmd.ExecuteScalar().ToString() ?? string.Empty;
            }
        }


        public static void StartInstallation(bool isForceUpdate)
        {
            var currentVersion = ChangeLog.CurrentVersion;
            var latestAllowedVersion = ChangeLog.LatestAllowedVersion;
            var latestVersion = ChangeLog.LatestVersion;

            // 1️⃣ Force update – alltid uppdatera
            if (isForceUpdate)
            {
                Process.Start(Database.UpdatePath);
                Application.Exit();
                return;
            }

            // 2️⃣ Det finns en nyare version, men klienten får inte uppdatera
            if (latestAllowedVersion < latestVersion && currentVersion >= latestAllowedVersion)
            {
                InfoText.Show(LanguageManager.GetString("update_Info"), CustomColors.InfoText_Color.Info, "Information");
                return;
            }

            // 3️⃣ Klienten är redan uppdaterad till senaste tillåtna version
            if (currentVersion >= latestAllowedVersion)
            {
                InfoText.Show(LanguageManager.GetString("update_Info_2"), CustomColors.InfoText_Color.Info, "Information");
                return;
            }

            // 4️⃣ ✅ currentVersion < latestAllowedVersion → uppdatera
            Process.Start(Database.UpdatePath);
            Application.Exit();
        }


    }
}
