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
            EnsureHttpClient();

            // ✔ Om vi redan HAR en session → bara lägg till headern om det saknas
            if (sessionId != null)
            {
                if (!Login_Monitor.httpClient.DefaultRequestHeaders.Contains("X-Monitor-SessionId"))
                    Login_Monitor.httpClient.DefaultRequestHeaders.Add("X-Monitor-SessionId", sessionId);

                return; // ✔ Ingen login igen
            }

            // ---------------------------------------------------
            // Ingen sessionId → logga in 1 gång
            // ---------------------------------------------------
            var credentials = Database.LoadCredentials();
            var authData = new
            {
                Username = credentials.Username,
                Password = credentials.Password,
                ForceRelogin = true
            };

            var authResponse = httpClient.PostAsJsonAsync("login", authData).Result;
            if (!authResponse.IsSuccessStatusCode)
                throw new Exception("Monitor login failed.");

            sessionId = authResponse.Headers
                .FirstOrDefault(x => x.Key.Contains("SessionId")).Value?
                .FirstOrDefault();

            if (sessionId == null)
                throw new Exception("No SessionId returned from Monitor!");

            // ✔ Viktigt: Lägg till headern DIREKT efter login
            httpClient.DefaultRequestHeaders.Add("X-Monitor-SessionId", sessionId);
        }

        //public static void Login_API()
        //{
        //    EnsureHttpClient();

        //    // Om vi redan är inloggade – skicka headern och dra
        //    if (sessionId != null)
        //    {
        //        if (!httpClient.DefaultRequestHeaders.Contains("X-Monitor-SessionId"))
        //            httpClient.DefaultRequestHeaders.Add("X-Monitor-SessionId", sessionId);

        //        return;
        //    }

        //    // Annars logga in
        //    var credentials = Database.LoadCredentials();
        //    var authData = new
        //    {
        //        Username = credentials.Username,
        //        Password = credentials.Password,
        //        ForceRelogin = true
        //    };

        //    var authResponse = httpClient.PostAsJsonAsync("login", authData).Result;
        //    if (!authResponse.IsSuccessStatusCode)
        //        throw new Exception("Failed to authenticate with API.");

        //    sessionId = authResponse.Headers
        //        .FirstOrDefault(x => x.Key.Contains("SessionId")).Value?.FirstOrDefault();

        //    // IMPORTANT: ADD HEADER HERE
        //    if (!httpClient.DefaultRequestHeaders.Contains("X-Monitor-SessionId"))
        //        httpClient.DefaultRequestHeaders.Add("X-Monitor-SessionId", sessionId);
        //}


        //public static void Login_API(string? company = null)
        //{
        //    try
        //    {
        //        Log.Activity.Start();
        //        var sw = Stopwatch.StartNew();
        //        company ??= Database.MonitorCompany;

        //        BaseAddress = $"https://{Database.MonitorHost}:8001/{LanguageCode}/{company}/";

        //        var handler = new HttpClientHandler
        //        {
        //            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        //        };

        //        httpClient = new HttpClient(handler)
        //        {
        //            BaseAddress = new Uri(BaseAddress)
        //        };

        //        httpClient.DefaultRequestHeaders.Accept.Clear();
        //        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        // Load from config
        //        var credentials = Database.LoadCredentials();
        //        //var decryptedPassword = Database.AesEncryption.Decrypt(credentials.Password);

        //        var authenticationData = new
        //        {
        //            Username = credentials.Username,
        //            Password = credentials.Password,
        //            ForceRelogin = true
        //        };
        //        var authentication = httpClient.PostAsJsonAsync("login", authenticationData).Result;

        //        if (authentication.IsSuccessStatusCode)
        //        {
        //            var sessionId = authentication.Headers.ToList()
        //                .FirstOrDefault(x => x.Key.Contains("SessionId")).Value.FirstOrDefault();
        //            httpClient.DefaultRequestHeaders.Add("X-Monitor-SessionId", sessionId);

        //            var cookieContainer = new CookieContainer();
        //            cookieContainer.Add(httpClient.BaseAddress, new Cookie("SessionId", sessionId));

        //            sw.Stop();
        //            if (sw.ElapsedMilliseconds < 1000)
        //                Monitor.Set_Monitorstatus(Monitor.Status.Ok, sw.ElapsedMilliseconds.ToString());
        //            else
        //                Monitor.Set_Monitorstatus(Monitor.Status.Warning, sw.ElapsedMilliseconds.ToString());
        //        }
        //        else
        //        {
        //            Monitor.Set_Monitorstatus(Monitor.Status.Bad, "Failed to authenticate with API.");
        //        }

        //        Log.Activity.Stop("Login_Monitor");
        //    }
        //    catch (Exception exc)
        //    {
        //        Monitor.Set_Monitorstatus(Monitor.Status.Bad, exc.Message);
        //        InfoText.Show(exc.Message, CustomColors.InfoText_Color.Bad, "Problem with Monitor.");
        //    }
        //}

        public static int TotalLoginAttemps;
       


    }
}
