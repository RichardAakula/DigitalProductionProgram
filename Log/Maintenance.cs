using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;

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
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);
                    stop = DateTime.Parse(cmd.ExecuteScalar().ToString());
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
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);
                    start = DateTime.Parse(cmd.ExecuteScalar().ToString());
                }

                return now.Subtract(start);
            }
        }
        public static DateTime Date_PlannedStop
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT Datum FROM Log.Maintenance_Work WHERE Datum > @now";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);
                    return DateTime.Parse(cmd.ExecuteScalar().ToString());
                }

            }
        }

        public static bool IsMaintenance_Coming
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT * FROM Log.Maintenance_Work WHERE Datum > @now";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);
                    var reader = cmd.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }
        public static bool IsMaintenance_Ongoing
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT * FROM Log.Maintenance_Work WHERE Datum < @now AND Done = 'False'";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);
                    var reader = cmd.ExecuteReader();
                    return reader.HasRows;
                }
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
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = "SELECT Info FROM Log.Maintenance_Work WHERE Datum > @now";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }

        public static void StartInstallation()
        {
            try
            {
                // Starta MSIX-installationen
                Process.Start(new ProcessStartInfo
                {
                    FileName = @"\\optifil\DPP\Install DPP.appinstaller", 
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kunde inte starta installationsfilen.\n{ex.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
