using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Processcards;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data.Odbc;
using System.Diagnostics;
using static DigitalProductionProgram.DatabaseManagement.Database;

namespace DigitalProductionProgram.MainWindow
{
    internal class Program
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
            var datum = string.Empty;
            try
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"SELECT ReleaseDate FROM Log.ChangeLog WHERE Version = @vers";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@vers", vers);
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                    datum = reader["ReleaseDatum"].ToString();
                if (DateTime.TryParse(datum, out DateTime date))
                    return date.ToShortDateString();
            }
            catch
            {
                return "N/A";
            }
            return "N/A";
        }
        public static bool IsComputerOnlyForMeasurements
        {
            get
            {
                try
                {
                    using var con = new SqlConnection(Database.cs_Protocol);
                    const string query = "SELECT MeasureOnly FROM [Settings].General WHERE HostName = @computerName";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@computerName", Environment.MachineName);

                    if (cmd.ExecuteScalar() != null)
                        return (bool)cmd.ExecuteScalar();
                    return false;
                }
                catch (Exception exception)
                {
                    ErrorHandler.Allmänt_Fel(exception, "is_DatorMätdator");
                    return false;
                }

            }
        }
        public static bool IsUpdateCritical
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = $"SELECT * FROM Log.ChangeLog WHERE Version = '{ChangeLog.LatestVersion}' AND IsCritical = 'True'";
                var cmd = new SqlCommand(query, con);

                con.Open();
                var reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }

        private static bool IsDatabaseConnectionMissing =>
            string.IsNullOrEmpty(Database.cs_Protocol) ||
            string.IsNullOrEmpty(Database.cs_ToolRegister) ||
            string.IsNullOrEmpty(Database.MonitorCompany) ||
            string.IsNullOrEmpty(Database.MonitorHost);

        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Kontrollerar att alla databaskopplingar är ok, annars får användaren välja  
            Load_DatabaseSettings();

            if (IsDatabaseConnectionMissing)
            {
                var cs = new Database();
                cs.ShowDialog();
            }

            //Order.WorkOperation = Manage_WorkOperation.WorkOperations.Extrudering_Termo;

            //User.Person.Name = "Richard Aakula";
            //User.Person.Role = "SuperAdmin";
            //Application.Run(new Manage_Processcards());
            //return;
            //Nedanstående är originalkoden som skall laddas
            var back = new BlackBackground("Initialising Digital Production Program.\nConnecting to Monitor and loading data from server, please wait.", 98, true)
            {
                TopMost = false,
                WindowState = FormWindowState.Normal,
                Width = 600,
                Height = 300,
                KeyPreview = true,

            };
            back.Show();
            Application.Run(new Main_Form(back));

        }


        
    }
}