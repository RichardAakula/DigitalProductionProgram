using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.Monitor
{
    internal abstract class Login_Monitor
    {
        public static string LanguageCode = "sv";
        private static string BaseAddress { get; set; } = string.Empty;

        public static string? sessionId;
        public static HttpClient? httpClient;
        public static void EnsureHttpClient()
        {
            if (httpClient != null) return;

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri($"https://{Database.MonitorHost}:8001/{LanguageCode}/{Database.MonitorCompany}/")
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void GiveUserWarningMonitorOnStageServer()
        {
            if (Database.MonitorHost == "stage-optig5.optinova.fi")
                InfoText.Show(LanguageManager.GetString("warning_MonitorTestserver"), CustomColors.InfoText_Color.Bad, null);
        }

        [DebuggerStepThrough]
        public static void Login_API()
        {
            Stopwatch sw = Stopwatch.StartNew();

            // ✔ Om vi redan har session → gör inget
            if (sessionId != null)
                return;

            var credentials = Database.LoadCredentials();
            var authJson =
                $"{{\"Username\":\"{credentials.Username}\",\"Password\":\"{credentials.Password}\",\"ForceRelogin\":true}}";

            string url = $"https://{Database.MonitorHost}:8001/{Login_Monitor.LanguageCode}/{Database.MonitorCompany}/login";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            // ✔ Tillåt self-signed cert (samma som i HttpClientHandler)
            request.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            // Skicka body synkront
            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(authJson);
            }

            // Synkront svar
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("Monitor login failed (sync).");

                // ✔ Hämta SessionId från headers
                sessionId = response.Headers["X-Monitor-SessionId"];

                if (sessionId == null)
                    sessionId = response.Headers.AllKeys
                        .Where(k => k.Contains("SessionId"))
                        .Select(k => response.Headers[k])
                        .FirstOrDefault();

                if (sessionId == null)
                    throw new Exception("Monitor login failed: No SessionId returned.");
            }

            sw.Stop();
            Debug.WriteLine("======== SYNC LOGIN ========");
            Debug.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
        }

        public static int TotalLoginAttemps;
       


    }
}
