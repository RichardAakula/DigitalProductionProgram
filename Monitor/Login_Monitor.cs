using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DigitalProductionProgram.Monitor
{
    internal class Login_Monitor
    {
        public static string LanguageCode = "sv";
        //public static string Company { get; set; }
        public static string BaseAddress { get; set; } = string.Empty;

        public static HttpClient? httpClient;

        public static void GiveUserWarningMonitorOnStageServer()
        {
            if (Database.MonitorHost == "stage-optig5.optinova.fi")
                InfoText.Show(LanguageManager.GetString("warning_MonitorTestserver"), CustomColors.InfoText_Color.Bad, null);
        }
       

        //public static void Login_API(string? company = null)
        //{
        //   try
        //   {
        //       Log.Activity.Start();
        //       var sw = Stopwatch.StartNew();
        //       company ??= Database.MonitorCompany;

        //       BaseAddress = $"https://{Database.MonitorHost}:8001/{LanguageCode}/{company}/";

        //       var handler = new HttpClientHandler
        //       {
        //           ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        //       };

        //       httpClient = new HttpClient(handler)
        //       {
        //           BaseAddress = new Uri(BaseAddress)
        //       };

        //       httpClient.DefaultRequestHeaders.Accept.Clear();
        //       httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //       // Load from config
        //       var credentials = Database.LoadCredentials();
        //       //var decryptedPassword = Database.AesEncryption.Decrypt(credentials.Password);

        //       var authenticationData = new
        //       {
        //           Username = credentials.Username,
        //           Password = credentials.Password,
        //           ForceRelogin = true
        //       };
        //       var authentication = httpClient.PostAsJsonAsync("login", authenticationData).Result;

        //       if (authentication.IsSuccessStatusCode)
        //       {
        //           var sessionId = authentication.Headers.ToList()
        //               .FirstOrDefault(x => x.Key.Contains("SessionId")).Value.FirstOrDefault();
        //           httpClient.DefaultRequestHeaders.Add("X-Monitor-SessionId", sessionId);

        //           var cookieContainer = new CookieContainer();
        //           cookieContainer.Add(httpClient.BaseAddress, new Cookie("SessionId", sessionId));

        //           sw.Stop();
        //           if (sw.ElapsedMilliseconds < 1000)
        //               Monitor.Set_Monitorstatus(Monitor.Status.Ok, sw.ElapsedMilliseconds.ToString());
        //           else
        //               Monitor.Set_Monitorstatus(Monitor.Status.Warning, sw.ElapsedMilliseconds.ToString());
        //       }
        //       else
        //       {
        //           Monitor.Set_Monitorstatus(Monitor.Status.Bad, "Failed to authenticate with API.");
        //       }

        //       Log.Activity.Stop("Login_Monitor");
        //   }
        //   catch (Exception exc)
        //   {
        //             Monitor.Set_Monitorstatus(Monitor.Status.Bad, exc.Message);
        //        InfoText.Show(exc.Message, CustomColors.InfoText_Color.Bad, "Problem with Monitor.");
        //   }
        //}

        public static int TotalLoginAttemps;
        [DebuggerStepThrough]
        public static async Task Login_API(string? company = null)
        {
            try
            {
                Log.Activity.Start();
                var sw = Stopwatch.StartNew();
                company ??= Database.MonitorCompany;
                TotalLoginAttemps++;
                BaseAddress = $"https://{Database.MonitorHost}:8001/{LanguageCode}/{company}/";

                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                };

                httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(BaseAddress)
                };

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                // Load credentials
                var credentials = Database.LoadCredentials();

                var authenticationData = new
                {
                    Username = credentials.Username,
                    Password = credentials.Password,
                    ForceRelogin = true
                };

                // 🔹 Asynkront anrop istället för .Result
                var authentication = await httpClient.PostAsJsonAsync("login", authenticationData)
                                                     .ConfigureAwait(false);

                if (authentication.IsSuccessStatusCode)
                {
                    var sessionId = authentication.Headers.ToList()
                        .FirstOrDefault(x => x.Key.Contains("SessionId"))
                        .Value.FirstOrDefault();

                    if (!string.IsNullOrEmpty(sessionId))
                    {
                        httpClient.DefaultRequestHeaders.Add("X-Monitor-SessionId", sessionId);

                        var cookieContainer = new CookieContainer();
                        cookieContainer.Add(httpClient.BaseAddress, new Cookie("SessionId", sessionId));
                    }

                    sw.Stop();
                    if (sw.ElapsedMilliseconds < 1000)
                        Monitor.Set_Monitorstatus(Monitor.Status.Ok, sw.ElapsedMilliseconds.ToString());
                    else
                        Monitor.Set_Monitorstatus(Monitor.Status.Warning, sw.ElapsedMilliseconds.ToString());
                }
                else
                {
                    Monitor.Set_Monitorstatus(Monitor.Status.Bad, "Failed to authenticate with API.");
                }

                Log.Activity.Stop("Login_Monitor");
            }
            catch (Exception exc)
            {
                Monitor.Set_Monitorstatus(Monitor.Status.Bad, exc.Message);
                InfoText.Show(exc.Message, CustomColors.InfoText_Color.Bad, "Problem with Monitor.");
            }
        }


    }
}
