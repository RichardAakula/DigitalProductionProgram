
using Azure.Core;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;

using Activity = DigitalProductionProgram.Log.Activity;

namespace DigitalProductionProgram.Monitor
{
    public static class Utilities
    {
        
        // STATISK KONSTRUKTOR – körs en gång
        static Utilities()
        {
            JsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true
            };

            // Här lägger vi till konvertern
            JsonOptions.Converters.Add(new FlexibleLongConverter());
        }

        private static readonly JsonSerializerOptions JsonOptions;

        [DebuggerStepThrough]
        private static HttpResponseMessage Http_response(string query)
        {
            Cursor previous = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                const int maxRetries = 2;

                for (int attempt = 1; attempt <= maxRetries; attempt++)
                {
                    // ✔ Säkerställ att vi har sessionId och header
                    if (Login_Monitor.sessionId == null)
                        Login_Monitor.Login_API();

                    // ✔ Skicka GET
                    var response = Login_Monitor.httpClient.GetAsync(query).Result;

                    // ✔ Klart
                    if (response.IsSuccessStatusCode)
                        return response;

                    // 🔁 Endast vid 401 → försök logga in igen
                    if (response.StatusCode == HttpStatusCode.Unauthorized && attempt < maxRetries)
                    {
                        Login_Monitor.sessionId = null; // force new login
                        continue;
                    }

                    // ❌ Alla andra fel → kasta
                    throw new Exception($"Monitor API error: {response.StatusCode} - {response.ReasonPhrase}");
                }

                throw new Exception("Monitor API: max retries reached.");
            }
            finally
            {
                Cursor.Current = previous;
            }
        }



        public static int CounterMonitorRequests;
       // [DebuggerStepThrough]
        public static List<T> GetFromMonitor<T>(params string[] queryOptions) where T : DTO, new()
        {
            CounterMonitorRequests++;
            var query = BuildQuery<T>(queryOptions);
            var response = Http_response(query);

            if (response is null)
                return null;

            var json = response.Content.ReadAsStringAsync().Result;

            try
            {
                return JsonSerializer.Deserialize<List<T>>(json, JsonOptions);
            }
            catch (Exception ex)
            {
                if (Person.Role == "SuperAdmin")
                    MessageBox.Show($"JSON Error in GetFromMonitor:\n{ex}");
                return null;
            }
        }
        [DebuggerStepThrough]
        public static T GetOneFromMonitor<T>(params string[] queryOptions) where T : DTO, new()
        {
            CounterMonitorRequests++;
            var query = BuildQuery<T>(queryOptions);
            if (!query.Contains("$top="))
                query += query.Contains("?$") ? "&$top=1" : "?$top=1";

            var response = Http_response(query);
            if (response is null)
                return default;

            var json = response.Content.ReadAsStringAsync().Result;

            var isIdSelect = queryOptions.Length > 0 && queryOptions[0].StartsWith("/");

            try
            {
                if (isIdSelect)
                    return JsonSerializer.Deserialize<T>(json, JsonOptions);

                var list = JsonSerializer.Deserialize<List<T>>(json, JsonOptions);
                return list?.FirstOrDefault();
            }
            catch
            {
                return default;
            }
        }

        [DebuggerStepThrough]
        private static string BuildQuery<T>(string[] queryOptions) where T : DTO, new()
        {
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


        private class FlexibleLongConverter : JsonConverter<long>
        {
            public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Number)
                    return reader.GetInt64();

                if (reader.TokenType == JsonTokenType.String)
                {
                    var str = reader.GetString();
                    if (long.TryParse(str, out var value))
                        return value;
                }

                throw new JsonException($"Cannot convert to long: '{reader.GetString()}'");
            }

            public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value);
            }
        }
    }
}





































































































//using DigitalProductionProgram.DatabaseManagement;
//using DigitalProductionProgram.User;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using System.Windows;
////using Newtonsoft.Json;

//using Activity = DigitalProductionProgram.Log.Activity;
////using JsonSerializer = System.Text.Json.JsonSerializer;

//namespace DigitalProductionProgram.Monitor
//{
//    public static class Utilities
//    {
//        static Utilities()
//        {
//            JsonOptions = new JsonSerializerOptions
//            {
//                PropertyNameCaseInsensitive = true,
//                ReadCommentHandling = JsonCommentHandling.Skip,
//                AllowTrailingCommas = true
//            };

//            // Här lägger vi till konvertern
//            JsonOptions.Converters.Add(new FlexibleLongConverter());
//        }

//        private static readonly JsonSerializerOptions JsonOptions;
//        #region GET
//        // public static string MonitorStatus;
//        [DebuggerStepThrough]
//        private static HttpResponseMessage Http_response(string query)
//        {
//            var ctr_ErrorLogin = 0;
//        Start:
//            var response = Login_Monitor.httpClient.GetAsync(query).Result;

//            if (response.StatusCode != HttpStatusCode.OK)
//            {
//                if (ctr_ErrorLogin > 10)
//                {
//                    _ = Activity.Stop($"Error:Monitor - Failat inloggning 10 ggr: Query = {query}. Response = {response.ReasonPhrase}. StatusCode = {response.StatusCode}");
//                    Monitor.Set_Monitorstatus(Monitor.Status.Bad, $"StatusCode: {response.StatusCode}. Response: {response.ReasonPhrase}");
//                }

//                if (Monitor.status == Monitor.Status.Bad && ctr_ErrorLogin > 10)
//                    return null;
//                Login_Monitor.Login_API();
//                ctr_ErrorLogin++;
//                goto Start;
//            }
//            return response;
//        }
//        public static int CounterMonitorRequests;

//        [DebuggerStepThrough]
//        //public static List<T> GetFromMonitor<T>(params string[] queryOptions) where T : DTO, new()
//        //{
//        //    Utilities.CounterMonitorRequests++;
//        //    var query = BuildQuery<T>(queryOptions);
//        //    var response = Http_response(query);
//        //    if (response is null)
//        //        return null;
//        //    var asString = response.Content.ReadAsStringAsync().Result;
//        //    // try
//        //    {
//        //        var list = JsonConvert.DeserializeObject<List<T>>(asString);

//        //        if (list is null)
//        //        {
//        //            if (Person.Role == "SuperAdmin")
//        //                MessageBox.Show($"StatusCode = {response.StatusCode}\n" +
//        //                                $"Content = {response.Content}\n" +
//        //                                $"IsSuccessStatusCode = {response.IsSuccessStatusCode}");
//        //        }

//        //        return list;
//        //    }
//        //    //catch (Exception e)
//        //    {
//        //        //if (Person.Role == "SuperAdmin")
//        //        //    MessageBox.Show(e.ToString());
//        //    }
//        //    return null;

//        //}
//       

//        [DebuggerStepThrough]

//        //public static T GetOneFromMonitor<T>(params string[] queryOptions) where T : DTO, new()
//        //{
//        //    Utilities.CounterMonitorRequests++;
//        //    var query = BuildQuery<T>(queryOptions);
//        //    if (!query.Contains("$top="))
//        //        query += query.Contains("?$") ? "&$top=1" : "?$top=1";

//        //    var response = Http_response(query);
//        //    if (response is null)
//        //        return null;
//        //    var asString = response.Content.ReadAsStringAsync().Result;

//        //    var isIdSelect = queryOptions.Length > 0 && queryOptions[0].StartsWith("/");
//        //    try
//        //    {
//        //        return isIdSelect ? JsonConvert.DeserializeObject<T>(asString) : (JsonConvert.DeserializeObject<List<T>>(asString) ?? throw new InvalidOperationException()).FirstOrDefault();
//        //    }
//        //    catch
//        //    {
//        //        return null;
//        //    }
//        //}
//        public static T GetOneFromMonitor<T>(params string[] queryOptions) where T : DTO, new()
//        {
//            Utilities.CounterMonitorRequests++;
//            var query = BuildQuery<T>(queryOptions);
//            if (!query.Contains("$top="))
//                query += query.Contains("?$") ? "&$top=1" : "?$top=1";

//            var response = Http_response(query);
//            if (response is null)
//                return default;

//            var json = response.Content.ReadAsStringAsync().Result;

//            var isIdSelect = queryOptions.Length > 0 && queryOptions[0].StartsWith("/");

//            try
//            {
//                if (isIdSelect)
//                    return System.Text.Json.JsonSerializer.Deserialize<T>(json, JsonOptions);

//                var list = System.Text.Json.JsonSerializer.Deserialize<List<T>>(json, JsonOptions);
//                return list?.FirstOrDefault();
//            }
//            catch
//            {
//                return default;
//            }
//        }

//        [DebuggerStepThrough]
//        private static string BuildQuery<T>(string[] queryOptions) where T : DTO, new()
//        {
//            // Combine the query options. If the first one starts with /xxx, it means that it's an ID select. This means that option 2, if one exists, has to start with ?$ instead of &$
//            var query = "";
//            if (queryOptions.Length > 0)
//            {
//                var isIdSelect = queryOptions[0].StartsWith("/");
//                var i = isIdSelect ? 1 : 0;

//                if (isIdSelect)
//                    query = queryOptions[0];

//                query += $"?${queryOptions[i]}";
//                i++;
//                for (; i < queryOptions.Length; i++)
//                    query += $"&${queryOptions[i]}";
//            }

//            query = Login_Monitor.httpClient.BaseAddress + "/api/v1/" + new T().URL + query;
//            return query;
//        }


//        #endregion
//        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
//        {
//            PropertyNameCaseInsensitive = true,
//            ReadCommentHandling = JsonCommentHandling.Skip,
//            AllowTrailingCommas = true
//        };

//        public class FlexibleLongConverter : JsonConverter<long>
//        {
//            public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//            {
//                if (reader.TokenType == JsonTokenType.Number)
//                {
//                    return reader.GetInt64();
//                }
//                if (reader.TokenType == JsonTokenType.String)
//                {
//                    var str = reader.GetString();
//                    if (long.TryParse(str, out var value))
//                        return value;
//                }

//                throw new JsonException($"Cannot convert to long: '{reader.GetString()}'");
//            }

//            public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
//            {
//                writer.WriteNumberValue(value);
//            }
//        }

//    }




//    }
