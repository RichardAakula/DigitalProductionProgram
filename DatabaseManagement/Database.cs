using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.Log;


namespace DigitalProductionProgram.DatabaseManagement
{
    public partial class Database : Form
    {
        /// <summary>

        public static int SQL_Counter = 0;

        
        private const string ServerOTH = @"THAI-SRV1-SQL01\SQLEXPRESS";
        private const string ServerOGO = "GOD-S1-SQL01";
        private const string ServerOVF = "OVF-S1-SQL";

        private const string UserID = "korprotokoll";
        private static string Password = "GOD-Stout4-Gladiator-Gazing-Retail-Pegboard";
        

        private static readonly string csDPP_OGO = $"Data Source={ServerOGO};Initial Catalog=Korprotokoll;Persist Security Info=True;User ID={UserID};Password={Password};Connect Timeout=10;Encrypt=True;TrustServerCertificate=True;";
        private static readonly string csDPP_OTH = $"Data Source={ServerOTH};Initial Catalog=Korprotokoll_Thai;Persist Security Info=True;User ID={UserID};Password={Password};Connect Timeout=5;Encrypt=True;TrustServerCertificate=True;";
        private static readonly string csDPP_OVF = $"Data Source={ServerOVF};Initial Catalog=DPP_OVF;Persist Security Info=True;User ID={UserID};Password={Password};Connect Timeout=5;Encrypt=True;TrustServerCertificate=True;";
        private static readonly string csDPP_Beta = $"Data Source={ServerOGO};Initial Catalog=GOD_DPP_DEV;Persist Security Info=True;User ID={UserID};Password={Password};Connect Timeout=5;Encrypt=True;TrustServerCertificate=True;";
        

        private static readonly string? csToolRegisterGodby = $"Data Source={ServerOGO};Initial Catalog=Verktygsprogram;Persist Security Info=True;User ID={UserID};Password={Password};Connect Timeout=5;Encrypt=True;TrustServerCertificate=True;";
        private const string csToolRegisterThai = "Data Source=THAI-SRV1-SQL01\\SQLEXPRESS;Initial Catalog=Toolregister_Thai;Persist Security Info=True;User ID=korprotokoll;Password=korprotokoll;Connect Timeout=5;Encrypt=True;TrustServerCertificate=True;";
        private const string csToolRegisterOVF = "Data Source=OVF-S1-SQL;Initial Catalog=Toolregister_OVF;Persist Security Info=True;User ID=korprotokoll;Password=korprotokoll;Connect Timeout=5;Encrypt=True;TrustServerCertificate=True;";
        /// </summary>


        public static string? cs_Protocol = csDPP_OGO;
        public static string? cs_ToolRegister = csToolRegisterGodby;
        public static string? MonitorHost = "optig5";
        public static string? MonitorCompany = "001.1";
        

        private bool mouseDown;
        private Point lastLocation;
        
        
        public static Type? DataType(string kolumn, string register)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var cmd = new SqlCommand($"SELECT TOP(1) {kolumn} FROM {register}", con);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                return reader.GetFieldType(0);
            return null;
        }

        private void IsOkSave()
        {
            if (string.IsNullOrEmpty(cb_DPP.Text) || string.IsNullOrEmpty(cb_Toolregister.Text) || string.IsNullOrEmpty(cb_MonitorCompany.Text) || string.IsNullOrEmpty(cb_MonitorHost.Text))
            {
                    btn_SaveAndExit.ForeColor = Color.FromArgb(156, 0, 6);
                    btn_SaveAndExit.BackColor = Color.FromArgb(255, 199, 206);
                    btn_SaveAndExit.Enabled = false;
            }
            else
            {
                btn_SaveAndExit.ForeColor = Color.FromArgb(0, 97, 0);
                btn_SaveAndExit.BackColor = Color.FromArgb(198, 239, 206);
                btn_SaveAndExit.Enabled = true;
            }
         
        }

        private string? building_csProtocol;
        private string? building_csToolRegister;

        public static string InstallationPath
        {
            get
            {
                switch (Monitor.Monitor.factory)
                {
                    case Monitor.Monitor.Factory.Godby:
                    case Monitor.Monitor.Factory.Holding:
                        return @"\\optifil\dpp\";
                    
                    case Monitor.Monitor.Factory.Thailand:
                        return @"\\optifil\dpp\";
                    case Monitor.Monitor.Factory.ValleyForge:
                        return @"\\optifil\dpp\";
                    default:
                        throw new InvalidOperationException("Ogiltig fabrik angiven.");
                }
            }
        }


        public Database()
        {
            InitializeComponent();
            Load_Databases();
        }

        public static T ExecuteSafe<T>(Func<SqlConnection, T> action)
        {
            try
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                con.Open();
                return action(con);
            }
            catch (Exception)
            {
                // Här kan du logga, visa fel, eller slå på en SQL-counter
                InfoText.Show(LanguageManager.GetString("errorConnectingDatabase"),
                    CustomColors.InfoText_Color.Bad, "Error!");
                return default!;
            }
        }
        public static async Task<T> ExecuteSafeAsync<T>(Func<SqlConnection, Task<T>> action)
        {
            try
            {
                await using var con = new SqlConnection(Database.cs_Protocol);
                await con.OpenAsync();
                return await action(con);
            }
            catch (Exception)
            {
                // Logga eller räkna
                InfoText.Show(LanguageManager.GetString("errorConnectingDatabase"),
                    CustomColors.InfoText_Color.Bad, "Error!");
                return default!;
            }
        }
        public static void Load_DatabaseSettings()
        {
            cs_Protocol = null;
            cs_ToolRegister = null;
            MonitorHost = null;
            MonitorCompany = null;

            // Försök läsa från användarmappen
            string settingsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "DigitalProductionProgram",
                "DatabaseSettings.json");

            // Fallback till installationsmappen om filen inte finns
            if (!File.Exists(settingsPath))
            {
                settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatabaseSettings.json");
            }

            var json = File.ReadAllText(settingsPath);
            var jObject = JObject.Parse(json);

            //"Data Source=GOD-S1-SQL01;Initial Catalog=Korprotokoll;Persist Security Info=True;User ID=korprotokoll;Password=GOD-Stout4-Gladiator-Gazing-Retail-Pegboard;Connect Timeout=5;Encrypt=True;TrustServerCertificate=True;";
            cs_Protocol = jObject["ConnectionStrings"]?["csProtocol"]?.ToString();
            cs_ToolRegister = jObject["ConnectionStrings"]?["csToolregister"]?.ToString();
            MonitorHost = jObject["ConnectionStrings"]?["MonitorHost"]?.ToString();
            MonitorCompany = jObject["ConnectionStrings"]?["MonitorCompany"]?.ToString();

            switch (MonitorCompany)
            {
                case "001.1":
                    Monitor.Monitor.factory = Monitor.Monitor.Factory.Godby;
                    break;
                case "003.1":
                    Monitor.Monitor.factory = Monitor.Monitor.Factory.Holding;
                    break;
                case "010.1":
                    Monitor.Monitor.factory = Monitor.Monitor.Factory.Thailand;
                    break;
                case "012.1":
                    Monitor.Monitor.factory = Monitor.Monitor.Factory.ValleyForge;
                    break;
            }
        }

        private void Load_Databases()
        {
            if (string.IsNullOrEmpty(cs_Protocol))
                return;

          
            cb_DPP.Text = cs_Protocol switch
            {
                string s when s.Contains("GOD_DPP_DEV", StringComparison.OrdinalIgnoreCase) => "Godby Test",
                string s when s.Contains(ServerOGO, StringComparison.OrdinalIgnoreCase) => "Godby",
                string s when s.Contains(ServerOTH, StringComparison.OrdinalIgnoreCase) => "Thailand",
                string s when s.Contains(ServerOVF, StringComparison.OrdinalIgnoreCase) => "Valley Forge",
                _ => "Okänd plats"
            };



            if (cs_Protocol.Equals(csToolRegisterGodby, StringComparison.OrdinalIgnoreCase))
                cb_Toolregister.Text = "Godby";
            else if (cs_Protocol.Equals(csToolRegisterGodby, StringComparison.OrdinalIgnoreCase))
                cb_Toolregister.Text = "Godby Test";
            else if (cs_Protocol.Equals(csToolRegisterThai, StringComparison.OrdinalIgnoreCase))
                cb_Toolregister.Text = "Thailand";
            else if (cs_Protocol.Equals(csToolRegisterOVF, StringComparison.OrdinalIgnoreCase))
                cb_Toolregister.Text = "Valley Forge";


            //switch (cs_ToolRegister)
            //{
            //    case csToolRegisterGodby:
            //        cb_Toolregister.Text = "Godby";
            //        break;
            //    case csToolRegisterThai:
            //        cb_Toolregister.Text = "Thailand";
            //        break;
            //    case csToolRegisterOVF:
            //        cb_Toolregister.Text = "Valley Forge";
            //        break;
            //}
            cb_MonitorHost.Text = MonitorHost;
            cb_MonitorCompany.Text = MonitorCompany;
           
        }

       
        private void DPP_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsOkSave();

            string? ServerDPP = null;
            string? DatabaseDPP = null;
           
            var timeout = 0;
            switch (cb_DPP.Text)
            {
                case "Godby":
                    ServerDPP = ServerOGO;
                    DatabaseDPP = "Korprotokoll";
                    timeout = 5;
                    Password = "GOD-Stout4-Gladiator-Gazing-Retail-Pegboard";
                    cb_Toolregister.Text = @"Godby";
                    cb_MonitorCompany.Text = @"001.1";
                    break;
                case "Godby Test":
                    ServerDPP = ServerOGO;
                    DatabaseDPP = "GOD_DPP_DEV";
                    timeout = 5;
                    Password = "GOD-Stout4-Gladiator-Gazing-Retail-Pegboard";
                    cb_Toolregister.Text = @"Godby";
                    cb_MonitorCompany.Text = @"001.1";
                    break;
                case "Thailand":
                    ServerDPP = ServerOTH;
                    DatabaseDPP = "Korprotokoll_Thai";
                    timeout = 10;
                    Password = "korprotokoll";
                    cb_Toolregister.Text = @"Thailand";
                    cb_MonitorCompany.Text = @"010.1";
                    break;
                case "Valley Forge":
                    ServerDPP = ServerOVF;
                    DatabaseDPP = "DPP_OVF";
                    timeout = 10;
                    Password = "korprotokoll";
                    cb_Toolregister.Text = @"Valley Forge";
                    cb_MonitorCompany.Text = @"012.1";
                    break;
            }
            building_csProtocol = $"Data Source={ServerDPP};Initial Catalog={DatabaseDPP};Persist Security Info=True;User ID={UserID};Password={Password};Connect Timeout={timeout};Encrypt=True;TrustServerCertificate=True;";
            
        }
        private void DPP_Enter(object sender, EventArgs e)
        {
            label_Info.Text = string.Empty;
        }
        private void Toolregister_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsOkSave();

            string? ServerToolregister = null;
            string? DatabaseToolregister = null;
            var timeout = 0;

            switch (cb_Toolregister.Text)
            {
                case "Godby":
                    ServerToolregister = ServerOGO;
                    timeout = 5;
                    DatabaseToolregister = "Verktygsprogram";
                    break;
                case "Thailand":
                    ServerToolregister = ServerOTH;
                    timeout = 10;
                    DatabaseToolregister = "Toolregister_Thai";
                    break;
                case "Valley Forge":
                    ServerToolregister = ServerOVF;
                    timeout = 10;
                    DatabaseToolregister = "Toolregister_OVF";
                    break;
            }
            building_csToolRegister = $"Data Source={ServerToolregister};Initial Catalog={DatabaseToolregister};Persist Security Info=True;User ID={UserID};Password={Password};Connect Timeout={timeout};Encrypt=True;TrustServerCertificate=True;";
        }
        private void Toolregister_Enter(object sender, EventArgs e)
        {
            label_Info.Text = string.Empty;
        }
        private void MonitorCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsOkSave();
        }
        private void MonitorCompany_Enter(object sender, EventArgs e)
        {
            label_Info.Text = @"001.1 - Optinova Godby Ab
                                003.1 - Optinova Holding Ab
                                010.1 - Optinova Thailand Co
                                012.1 - Optinova Valley Forge";

        }
        private void MonitorHost_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsOkSave();
        }
        private void MonitorHost_Enter(object sender, EventArgs e)
        {
            label_Info.Text = $"optig5 - Monitor\n" +
                              $"stage-optig5.optinova.fi - Monitor Testbolag";
        }

        private void SaveAndExit_Click(object sender, EventArgs e)
        {
            Save_XmlFile();
            Close();
        }

        private void Database_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void Database_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void Database_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                var deltaX = e.X - lastLocation.X;
                var deltaY = e.Y - lastLocation.Y;

                Location = new Point(Location.X + deltaX, Location.Y + deltaY);
            }
        }

        private void Save_XmlFile()
        {
            string settingsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "DigitalProductionProgram",
                "DatabaseSettings.json");
            Directory.CreateDirectory(Path.GetDirectoryName(settingsPath) ?? string.Empty); // Säkerställ att mappen finns

            if (!File.Exists(settingsPath))
            {
                MessageBox.Show("DatabaseSettings.json hittades inte.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var json = File.ReadAllText(settingsPath);
            var jObject = JObject.Parse(json);

            // Uppdatera anslutningssträngarna
            jObject["ConnectionStrings"]["csProtocol"] = building_csProtocol;
            jObject["ConnectionStrings"]["csToolregister"] = building_csToolRegister;
            jObject["ConnectionStrings"]["MonitorHost"] = MonitorHost = cb_MonitorHost.Text;
            jObject["ConnectionStrings"]["MonitorCompany"] = MonitorCompany = cb_MonitorCompany.Text;

            // Spara till samma sökväg
            File.WriteAllText(settingsPath, jObject.ToString());
        }



        public class DataBaseType
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }
        public static readonly List<DataBaseType> datatype =
        [
            new DataBaseType { Name = "Numeric", ID = 0 },
            new DataBaseType { Name = "Text", ID = 1 },
            new DataBaseType { Name = "Bool", ID = 2 },
            new DataBaseType { Name = "DateTime", ID = 3 }
        ];
        public static Monitor_API_Credentials LoadCredentials()
        {
            string settingsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "DigitalProductionProgram",
                "DatabaseSettings.json");

            // Fallback till original om filen inte finns i AppData
            if (!File.Exists(settingsPath))
            {
                settingsPath = Path.Combine(AppContext.BaseDirectory, "DatabaseSettings.json");
            }

            var config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(settingsPath)!)
                .AddJsonFile(Path.GetFileName(settingsPath), optional: false, reloadOnChange: true)
                .Build();

            var credentials = config.GetSection("ApiCredentials").Get<Monitor_API_Credentials>();

            if (credentials == null)
                throw new Exception("Kunde inte läsa API credentials från konfigurationen.");

            // Dekryptera lösenordet
            credentials.Password = AesEncryption.Decrypt(credentials.Password);

            return credentials;
        }

        public class Monitor_API_Credentials
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public static class AesEncryption
        {
            private static readonly string EncryptionKey = "SuperSecretKey123!"; // exakt 16 tecken för AES-128

            public static string Encrypt(string plainText)
            {
                // Ensure the key is exactly 16 bytes (128 bits)
                byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);

                // If the key is shorter than 16 bytes, pad it, otherwise trim to 16 bytes
                if (keyBytes.Length < 16)
                {
                    keyBytes = keyBytes.Concat(new byte[16 - keyBytes.Length]).ToArray(); // Padding to 16 bytes
                }
                else if (keyBytes.Length > 16)
                {
                    keyBytes = keyBytes.Take(16).ToArray(); // Trimming to 16 bytes
                }

                using var aes = Aes.Create();
                aes.Key = keyBytes;
                aes.GenerateIV(); // Generate a new IV for each encryption
                using var encryptor = aes.CreateEncryptor();

                using var ms = new MemoryStream();
                ms.Write(aes.IV, 0, aes.IV.Length); // IV goes first in the encrypted data
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }

                return Convert.ToBase64String(ms.ToArray());
            }
            public static string Decrypt(string cipherText)
            {
                try
                {
                    Console.WriteLine("Cipher Text: " + cipherText); // Log the ciphertext

                    // Ensure the string is a valid base64 string
                    if (string.IsNullOrEmpty(cipherText) || !IsBase64String(cipherText))
                    {
                        throw new ArgumentException("Invalid Base64 string");
                    }

                    byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);

                    // Ensure the key is exactly 16 bytes (128 bits)
                    if (keyBytes.Length < 16)
                    {
                        keyBytes = keyBytes.Concat(new byte[16 - keyBytes.Length]).ToArray();
                    }
                    else if (keyBytes.Length > 16)
                    {
                        keyBytes = keyBytes.Take(16).ToArray();
                    }

                    using var aes = Aes.Create();
                    aes.Key = keyBytes;

                    // Extract the IV from the start of the cipher text
                    using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
                    byte[] iv = new byte[16];
                    ms.Read(iv, 0, iv.Length);
                    aes.IV = iv;

                    using var decryptor = aes.CreateDecryptor();
                    using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                    using var sr = new StreamReader(cs);

                    return sr.ReadToEnd();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Decryption error: " + ex.Message); // Log the error
                    throw;
                }
            }

            // Helper function to check if a string is Base64 encoded
            public static bool IsBase64String(string base64String)
            {
                base64String = base64String.Trim();
                return (base64String.Length % 4 == 0) &&
                       base64String.All(c => "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".Contains(c));
            }


        }
    }
}
