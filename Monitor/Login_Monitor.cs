using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.PrintingServices;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static DigitalProductionProgram.MainWindow.ServerStatus;

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

        //[DebuggerStepThrough]
        public static LoginResult Login_API(bool forceRelogin = false)
        {
            var sw = Stopwatch.StartNew();
            LoginResult result;

            try
            {
                if (forceRelogin)
                    sessionId = null;

                if (sessionId != null)
                {
                    result = new LoginResult
                    {
                        Success = true,
                        ElapsedMilliseconds = 0
                    };

                    return result;
                }

                var credentials = Database.LoadCredentials();
                var authJson =
                    $"{{\"Username\":\"{credentials.Username}\",\"Password\":\"{credentials.Password}\",\"ForceRelogin\":true}}";

                string url =
                    $"https://{Database.MonitorHost}:8001/{Login_Monitor.LanguageCode}/{Database.MonitorCompany}/login";

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                request.ServerCertificateValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => true;

                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(authJson);
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception("Monitor login failed (sync).");

                    sessionId =
                        response.Headers["X-Monitor-SessionId"]
                        ?? response.Headers.AllKeys
                            .Where(k => k.Contains("SessionId"))
                            .Select(k => response.Headers[k])
                            .FirstOrDefault();

                    if (sessionId == null)
                        throw new Exception("Monitor login failed: No SessionId returned.");
                }

                result = new LoginResult
                {
                    Success = true,
                    ElapsedMilliseconds = sw.ElapsedMilliseconds
                };

                Debug.WriteLine("======== SYNC LOGIN ========");
                Debug.WriteLine($"Time: {result.ElapsedMilliseconds} ms");

                return result;
            }
            catch (WebException)
            {
                InfoText.Show(LanguageManager.GetString("error_Monitor"), CustomColors.InfoText_Color.Bad, "Error Monitor");

                result = new LoginResult
                {
                    Success = false,
                    ElapsedMilliseconds = sw.ElapsedMilliseconds
                };

                return result;
            }
            finally
            {
                sw.Stop();

                // ENDA stället där status rapporteras
                ServerStatus.Report(
                    new LoginResult
                    {
                        Success = sessionId != null,
                        ElapsedMilliseconds = sw.ElapsedMilliseconds
                    });
            }
        }



        public static int TotalLoginAttemps;



    }
}
