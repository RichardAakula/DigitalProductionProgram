using System;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Log
{
    internal class Activity
    {
        private static readonly string HostName = Environment.MachineName;
        private static TimeSpan laddTid => DateTime.Now.Subtract(StartTime);
        private static DateTime StartTime;
        public static long CurrentMemory;
        public static long PeakMemory;

        public static void LoadMemory()
        {
            var proc = Process.GetCurrentProcess();
            CurrentMemory = proc.WorkingSet64;
            PeakMemory = proc.PeakWorkingSet64;
        }
        public static void Start()
        {
            StartTime = DateTime.Now;
        }

        public static async Task Stop(string info, double tid = 0)
        {
            double LoadingTime = tid == 0 ? laddTid.TotalMilliseconds / 1000 : tid;
            if (LoadingTime > 100)
                LoadingTime = 0;
            try
            {
                await using var con = new SqlConnection(Database.cs_Protocol);
                await using var cmd = new SqlCommand(@"
            INSERT INTO Log.ActivityLog 
            (HostID, UserID, OrderID, Version, Date, LoadingTime, Info, Resolution, WindowsVersion)
            VALUES 
            ((SELECT HostID FROM [Settings].General WHERE HostName = @hostname), @userid, @orderid, @version, @date, @loadingtime, @info, @resolution, @windowsversion)", con);
                await con.OpenAsync();
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@hostname", HostName);
                SQL_Parameter.Int(cmd.Parameters, "@userid", Person.UserID);
                SQL_Parameter.Int(cmd.Parameters, "orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@version", ChangeLog.CurrentVersion.ToString());
                cmd.Parameters.AddWithValue("@loadingtime", (decimal)Math.Min(LoadingTime, 99999.999));
                cmd.Parameters.AddWithValue("@info", info);
                cmd.Parameters.AddWithValue("@resolution", $"{Program.ScreenWidth} x {Program.ScreenHeight}");
                cmd.Parameters.AddWithValue("@windowsversion", Environment.Version.ToString());

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Error when logging data: {e.Message}");
            }
        }
        public static async Task AddTimeUserRead(string version, TimeSpan duration)
        {
            await using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                IF NOT EXISTS 
                (
                    SELECT 1
                    FROM [User].TimeReadChangeLog
                    WHERE UserID = @userid
                        AND Version = @version
                )
                BEGIN
                    INSERT INTO [User].TimeReadChangeLog (UserID, Version, Time)
                    VALUES (@userid, @version, @time);
                END";
            await con.OpenAsync();
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@userid", Person.UserID);
            cmd.Parameters.AddWithValue("@version", version);
            cmd.Parameters.AddWithValue("@time", duration.TotalSeconds);
            await cmd.ExecuteNonQueryAsync();

            if (duration.TotalSeconds > 10)
            {
                Points.Add_Points(10, $"Läser Information om versionshistorik - Tid = ({duration.TotalSeconds:0})");
                return;
            }

            if (duration.TotalSeconds > 5)
            {
                Points.Add_Points(4, $"Läser Information om versionshistorik - Tid = ({duration.TotalSeconds:0})");
                return;
            }

            if (duration.TotalSeconds > 2)
            {
                Points.Add_Points(1, $"Läser Information om versionshistorik - Tid = ({duration.TotalSeconds:0})");
                return;
            }

            Points.Add_Points(-3, $"Läser INTE Information om versionshistorik - Tid = ({duration.TotalSeconds:0})");
        }
    }
}   
    
