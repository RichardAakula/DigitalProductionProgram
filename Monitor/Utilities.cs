using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.User;
using Newtonsoft.Json;
using Activity = DigitalProductionProgram.Log.Activity;

namespace DigitalProductionProgram.Monitor
{
    public static class Utilities
    {
        #region GET
        // public static string MonitorStatus;
        // [DebuggerStepThrough]
        //private static HttpResponseMessage Http_response(string query)
        //{
        //    var ctr_ErrorLogin = 0;
        //Start:
        //    var response = Login_Monitor.httpClient.GetAsync(query).Result;

        //    if (response.StatusCode != HttpStatusCode.OK)
        //    {
        //        if (ctr_ErrorLogin > 10)
        //        {
        //            _ = Activity.Stop($"Error:Monitor - Failat inloggning 10 ggr: Query = {query}. Response = {response.ReasonPhrase}. StatusCode = {response.StatusCode}");
        //            Monitor.Set_Monitorstatus(Monitor.Status.Bad, $"StatusCode: {response.StatusCode}. Response: {response.ReasonPhrase}");
        //        }

        //        if (Monitor.status == Monitor.Status.Bad && ctr_ErrorLogin > 10)
        //            return null;
        //        Login_Monitor.Login_API();
        //        ctr_ErrorLogin++;
        //        goto Start;
        //    }
        //    return response;
        //}
        public static int CounterMonitorRequests;
        private static async Task<HttpResponseMessage?> Http_responseAsync(string query, int maxRetries = 5, TimeSpan? initialDelay = null, CancellationToken cancellationToken = default)
        {
             CounterMonitorRequests++;
            initialDelay ??= TimeSpan.FromMilliseconds(200);
            var delay = initialDelay.Value;
            var rnd = new Random();

            for (int attempt = 0; attempt <= maxRetries; attempt++)
            {
                try
                {
                    // Respektera cancellation
                    cancellationToken.ThrowIfCancellationRequested();

                    var response = await Login_Monitor.httpClient.GetAsync(query, cancellationToken).ConfigureAwait(false);

                    // Om OK -> returnera
                    if (response.StatusCode == HttpStatusCode.OK)
                        return response;

                    // Hantera 401/403 explicit: försök login en gång direkt
                    if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        // Försök att logga in (synkront eller async beroende på din implementation)
                        // Om Login_API är sync, kör den i en Task.Run så vi inte blockerar.
                        try
                        {
                            await Task.Run(() => Login_Monitor.Login_API()).ConfigureAwait(false);
                        }
                        catch
                        {
                            // login misslyckades — låt retry-logiken ta hand om nästa försök
                        }

                        // Vänta lite och fortsätt retry-loop
                    }

                    // Om vi nått maxRetry, logga och returnera null
                    if (attempt == maxRetries)
                    {
                        // Logga felstatus (ersätt med din logging)
                        _ = Activity.Stop($"Error:Monitor - Max retries reached for query: {query}. Last StatusCode = {response.StatusCode}");
                        Monitor.Set_Monitorstatus(Monitor.Status.Bad, $"StatusCode: {response.StatusCode}. Response: {response.ReasonPhrase}");
                        return null;
                    }

                    // Annars vänta innan nästa försök (exponential backoff + jitter)
                    var jitter = TimeSpan.FromMilliseconds(rnd.Next(0, 100));
                    await Task.Delay(delay + jitter, cancellationToken).ConfigureAwait(false);
                    // öka delay (exponential)
                    delay = TimeSpan.FromMilliseconds(Math.Min(5000, delay.TotalMilliseconds * 2));
                }
                catch (OperationCanceledException)
                {
                    // Avbrutet av caller — bubbla upp eller returnera null
                    return null;
                }
                catch (HttpRequestException ex)
                {
                    // Nätverksfel — logga och retrya om möjligt
                    if (attempt == maxRetries)
                    {
                        _ = Activity.Stop($"Error:Monitor - HttpRequestException for query: {query}. Exception: {ex}");
                        Monitor.Set_Monitorstatus(Monitor.Status.Bad, $"HttpRequestException: {ex.Message}");
                        return null;
                    }

                    // vänta och försök igen
                    var jitter = TimeSpan.FromMilliseconds(rnd.Next(0, 200));
                    await Task.Delay(delay + jitter, cancellationToken).ConfigureAwait(false);
                    delay = TimeSpan.FromMilliseconds(Math.Min(5000, delay.TotalMilliseconds * 2));
                }
                catch (Exception ex)
                {
                    // Oförutsedd fel — logga och avbryt för att undvika tyst fel
                    _ = Activity.Stop($"Error:Monitor - Unexpected exception for query: {query}. Exception: {ex}");
                    Monitor.Set_Monitorstatus(Monitor.Status.Bad, $"Exception: {ex.Message}");
                    return null;
                }
            }

            return null;
        }
        //[DebuggerStepThrough]
        public static async Task<List<T>> GetFromMonitor<T>(params string[] queryOptions) where T : DTO, new()
        {
            var query = BuildQuery<T>(queryOptions);
            var response = await Http_responseAsync(query);
            if (response is null) return null;

            var asString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(asString);
        }

        //public static List<T> GetFromMonitor<T>(params string[] queryOptions) where T : DTO, new()
        //{
        //    var query = BuildQuery<T>(queryOptions);
        //    var response = Http_response(query);
        //    if (response is null)
        //        return null;
        //    var asString = response.Content.ReadAsStringAsync().Result;
        //   // try
        //    {
        //        var list = JsonConvert.DeserializeObject<List<T>>(asString);
                
        //        if (list is null)
        //        {
        //            if (Person.Role =="SuperAdmin")
        //                MessageBox.Show($"StatusCode = {response.StatusCode}\n" +
        //                                $"Content = {response.Content}\n" +
        //                                $"IsSuccessStatusCode = {response.IsSuccessStatusCode}");
        //        }

        //        return list;
        //    }
        //    //catch (Exception e)
        //    {
        //        //if (Person.Role == "SuperAdmin")
        //        //    MessageBox.Show(e.ToString());
        //    }
        //    return null;

        //}
        [DebuggerStepThrough]
        public static async Task<T?> GetOneFromMonitor<T>(params string[] queryOptions) where T : DTO, new()
        {
            var query = BuildQuery<T>(queryOptions);

            // Begränsa till 1 rad om det inte redan finns
            if (!query.Contains("$top="))
                query += query.Contains("?$") ? "&$top=1" : "?$top=1";

            var response = await Http_responseAsync(query);
            if (response is null)
                return default;

            var asString = await response.Content.ReadAsStringAsync();

            var isIdSelect = queryOptions.Length > 0 && queryOptions[0].StartsWith("/");

            try
            {
                if (isIdSelect)
                {
                    // Om det är en /ID-select (typ /1234), returnera direkt som objekt
                    return JsonConvert.DeserializeObject<T>(asString);
                }
                else
                {
                    // Annars är det en lista – ta första elementet
                    var list = JsonConvert.DeserializeObject<List<T>>(asString);
                    return list?.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                if (Person.Role == "SuperAdmin")
                    MessageBox.Show($"Error in GetOneFromMonitorAsync<{typeof(T).Name}>():\n{ex.Message}\n\nQuery:\n{query}");
                return default;
            }
        }

        //public static T GetOneFromMonitor<T>(params string[] queryOptions) where T : DTO, new()
        //{
        //    var query = BuildQuery<T>(queryOptions);
        //    if (!query.Contains("$top="))
        //        query += query.Contains("?$") ? "&$top=1" : "?$top=1";

        //    var response = Http_response(query);
        //    if (response is null)
        //        return null;
        //    var asString = response.Content.ReadAsStringAsync().Result;

        //    var isIdSelect = queryOptions.Length > 0 && queryOptions[0].StartsWith("/");
        //    try
        //    {
        //        return isIdSelect ? JsonConvert.DeserializeObject<T>(asString) : (JsonConvert.DeserializeObject<List<T>>(asString) ?? throw new InvalidOperationException()).FirstOrDefault();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        // [DebuggerStepThrough]
        [DebuggerStepThrough]
        private static string BuildQuery<T>(string[] queryOptions) where T : DTO, new()
        {
            // Combine the query options. If the first one starts with /xxx, it means that it's an ID select. This means that option 2, if one exists, has to start with ?$ instead of &$
            var query = "";
            if (queryOptions.Length > 0)
            {
                var isIdSelect = queryOptions[0].StartsWith("/");
                var i = isIdSelect ? 1 : 0;

                if (isIdSelect)
                    query = queryOptions[0];

                query += $"?${queryOptions[i]}";
                i++;
                for (; i < queryOptions.Length; i++)
                    query += $"&${queryOptions[i]}";
            }

            query = Login_Monitor.httpClient.BaseAddress + "/api/v1/" + new T().URL + query;
            return query;
        }


        #endregion
    }
}
