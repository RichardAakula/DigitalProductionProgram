using System.Diagnostics;
using System.Runtime.CompilerServices;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;

namespace DigitalProductionProgram.Log;

internal class Activity
{
    public static readonly string HostName = Environment.MachineName;
    private static DateTime StartTime;
    private static TimeSpan ElapsedTime => DateTime.Now.Subtract(StartTime);
    public static long CurrentMemory;
    public static long PeakMemory;

    private static PerformanceCounter? cpuCounterDpp;
    private static PerformanceCounter? cpuCounterTotal;
    private static bool performanceCountersInitialized = false;

    private static void EnsurePerformanceCounters()
    {
        if (performanceCountersInitialized) return;
        try
        {
            cpuCounterDpp = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName, true);
            cpuCounterTotal = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }
        catch
        {
            cpuCounterDpp = null;
            cpuCounterTotal = null;
        }
        performanceCountersInitialized = true;
    }

    public static void LoadMemory()
    {
        var proc = Process.GetCurrentProcess();
        CurrentMemory = proc.WorkingSet64 / (1024 * 1024);
        PeakMemory = proc.PeakWorkingSet64 / (1024 * 1024);
    }
        
    public static void Start()
    {
        StartTime = DateTime.Now;
    }

    [DebuggerStepThrough]
    public static async Task Stop(string info, double tid = 0, [CallerMemberName] string? methodname = null)
    {
        var sw = Stopwatch.StartNew();
        bool success = false;

        try
        {
            var LoadingTime = tid == 0 ? ElapsedTime.TotalMilliseconds / 1000 : tid;
            if (LoadingTime > 100)
                LoadingTime = 0;

            var proc = Process.GetCurrentProcess();
            var dppMemoryMB = proc.WorkingSet64 / (1024 * 1024);

            EnsurePerformanceCounters();
            float dppCpu = 0, totalCpu = 0;
            if (cpuCounterDpp != null && cpuCounterTotal != null)
            {
                try
                {
                    _ = cpuCounterDpp.NextValue();
                    _ = cpuCounterTotal.NextValue();
                    await Task.Delay(250).ConfigureAwait(false);
                    dppCpu = cpuCounterDpp.NextValue() / Environment.ProcessorCount;
                    totalCpu = cpuCounterTotal.NextValue();
                }
                catch
                {
                    dppCpu = 0;
                    totalCpu = 0;
                }
            }

            var ci = new ComputerInfo();
            var totalMemoryMB = (long)(ci.TotalPhysicalMemory / (1024 * 1024));
            var usedMemoryMB = totalMemoryMB - (long)(ci.AvailablePhysicalMemory / (1024 * 1024));

            // Kör SQL via ExecuteSafeAsync så vi får statusrapportering
            await Database.ExecuteSafeAsync(async con =>
            {
                await using var cmd = new SqlCommand(@"
                INSERT INTO Log.ActivityLog 
                (HostID, UserID, OrderID, Program, Version, Date, LoadingTime, Info, Memory, DPPMemory, CPU, DPPCPU, Resolution, WindowsVersion)
                VALUES 
                ((SELECT HostID FROM [Settings].General WHERE HostName = @hostname), @userid, @orderid, @methodname, @version, @date, @loadingtime, @info, @memory, @dppmemory, @cpu, @dppcpu, @resolution, @windowsversion)", con);

                cmd.Parameters.AddWithValue("@hostname", HostName);

                if (Environment.MachineName == Main_Form.adminHostName && Person.Name != "Richard Aakula")
                    cmd.Parameters.AddWithValue("@userid", 0);
                else
                    SQL_Parameter.Int(cmd.Parameters, "@userid", Person.UserID);

                SQL_Parameter.Int(cmd.Parameters, "@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@methodname", methodname);
                cmd.Parameters.AddWithValue("@version", ChangeLog.CurrentVersion.ToString());
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@loadingtime", (decimal)Math.Min(LoadingTime, 99999.999));
                cmd.Parameters.AddWithValue("@info", info);

                cmd.Parameters.AddWithValue("@memory", usedMemoryMB);
                cmd.Parameters.AddWithValue("@dppmemory", dppMemoryMB);
                cmd.Parameters.AddWithValue("@cpu", totalCpu);
                cmd.Parameters.AddWithValue("@dppcpu", dppCpu);

                cmd.Parameters.AddWithValue("@resolution", $"{Program.ScreenWidth} x {Program.ScreenHeight}");
                cmd.Parameters.AddWithValue("@windowsversion", Environment.OSVersion.ToString());

                await cmd.ExecuteNonQueryAsync();

                return true; // Returneras bara för ExecuteSafeAsync<T>
            });

            success = true;
        }
        catch (Exception e)
        {
            MessageBox.Show($@"Error when logging data: {e.Message}");
        }
       
    }


    public static async Task AddTimeUserReadChangeLog(string version, TimeSpan duration)
    {
        bool success = false;

        try
        {
            await Database.ExecuteSafeAsync(async con =>
            {
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

                await using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userid", Person.UserID);
                cmd.Parameters.AddWithValue("@version", version);
                cmd.Parameters.AddWithValue("@time", duration.TotalSeconds);

                await cmd.ExecuteNonQueryAsync();

                success = true;
                return true; // dummy return
            });

            // Poänglogik oförändrad
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
        catch
        {
            // Om ExecuteSafeAsync kastar (t.ex. default!), success = false
            success = false;
            throw;
        }
        
    }

}