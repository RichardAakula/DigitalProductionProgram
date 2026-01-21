using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.EasterEggs;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using static DigitalProductionProgram.DatabaseManagement.Database;

namespace DigitalProductionProgram.MainWindow
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>

        public static readonly int ScreenWidth = Screen.PrimaryScreen!.Bounds.Width;
        public static readonly int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
        public static bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        public static string RelaseDate(string vers)
        {
            var datum = ExecuteSafe(con =>
            {
                const string query = @"SELECT ReleaseDate FROM Log.ChangeLog WHERE Version = @version";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@version", SqlDbType.NVarChar).Value = vers;

                using var reader = cmd.ExecuteReader();
                if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("ReleaseDate")))
                    return reader["ReleaseDate"].ToString();

                return null;
            });
            return DateTime.TryParse(datum, out var date) ? date.ToShortDateString() : "N/A";
        }
        public static bool IsComputerOnlyForMeasurements
        {
            get
            {
                return Database.ExecuteSafe(con =>
                {
                    const string query = @"
                SELECT MeasureOnly 
                FROM [Settings].General 
                WHERE HostName = @computerName";

                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@computerName", SqlDbType.NVarChar).Value = Environment.MachineName;

                    var result = cmd.ExecuteScalar();
                    return result is bool b && b;
                });
            }
        }
        public static bool IsUpdateCritical
        {
            get
            {
                return Database.ExecuteSafe(con =>
                {
                    var query = $"SELECT * FROM Log.ChangeLog WHERE Version = '{ChangeLog.LatestVersion}' AND IsCritical = 'True'";
                    var cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();
                    return reader.HasRows;
                });
            }
        }

        public static Stopwatch stopwatch;
        private static bool IsDatabaseConnectionMissing =>
            string.IsNullOrEmpty(Database.cs_Protocol) ||
            string.IsNullOrEmpty(Database.cs_ToolRegister) ||
            string.IsNullOrEmpty(Database.MonitorCompany) ||
            string.IsNullOrEmpty(Database.MonitorHost);
        public static SplashScreen splashScreen;

        private static void ShowSplash()
        {

            Thread t = new Thread(() =>
            {
                splashScreen = new SplashScreen();
                Application.Run(splashScreen);
            });

            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();

        }
        

        [STAThread] 
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ShowSplash();
            //Kontrollerar att alla databaskopplingar är ok, annars får användaren välja  
            Load_DatabaseSettings();

            var main = new Main_Form();
            Application.Run(main);

        }
        


    }
}