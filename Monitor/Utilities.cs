using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

        //[DebuggerStepThrough]
        public static string SyncHttpGet(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "application/json";

            // Bypass cert fel (som curl)
            request.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        private static HttpWebResponse Http_Response(string query)
        {
            Cursor previous = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                const int maxRetries = 2;

                for (int attempt = 1; attempt <= maxRetries; attempt++)
                {
                    HttpWebResponse response = null;
                    WebException caughtEx = null;
                    Stopwatch swTotal = Stopwatch.StartNew();

                    try
                    {
                        var req = (HttpWebRequest)WebRequest.Create(query);
                        req.Method = "GET";
                        req.Accept = "application/json";
                        req.Timeout = 30000;

                        req.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate, br";
                        req.AutomaticDecompression = DecompressionMethods.GZip
                                                     | DecompressionMethods.Deflate
                                                     | DecompressionMethods.Brotli;

                        // Håll anslutningen vid liv (mindre handshakes)
                        req.KeepAlive = true;

                        // (Valfritt) snabbare handskak och moderna protokoll
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;


                        // SSL bypass
                        req.ServerCertificateValidationCallback += (sender, cert, chain, sslErrors) => true;

                        // Lägg till session header om vi har sessionId
                        if (!string.IsNullOrEmpty(Login_Monitor.sessionId))
                            req.Headers.Add("X-Monitor-SessionId", Login_Monitor.sessionId);

                        Debug.WriteLine("====================================================");
                        Debug.WriteLine($"HTTP CALL START  |  {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                        Debug.WriteLine($"URL              |  {query}");
                        Debug.WriteLine($"ATTEMPT          |  {attempt}/{maxRetries}");

                        // SYNKRON GET
                        response = (HttpWebResponse)req.GetResponse();

                        swTotal.Stop();

                        // Logga resultat
                        Debug.WriteLine($"DURATION TOTAL   |  {swTotal.ElapsedMilliseconds} ms");
                        Debug.WriteLine($"HTTP STATUS      |  {(int)response.StatusCode} {response.StatusCode}");
                        long? size = response.ContentLength >= 0 ? response.ContentLength : null;
                        Debug.WriteLine($"PAYLOAD SIZE     |  {(size.HasValue ? size.Value + " bytes" : "unknown")}");
                        Debug.WriteLine("RESULT           |  SUCCESS");
                        Debug.WriteLine("====================================================");

                        return response; // SUCCESS
                    }
                    catch (WebException ex)
                    {
                        swTotal.Stop();
                        caughtEx = ex;
                        response = ex.Response as HttpWebResponse;

                        Debug.WriteLine($"DURATION TOTAL   |  {swTotal.ElapsedMilliseconds} ms");
                        Debug.WriteLine($"EXCEPTION        |  {caughtEx}");

                        if (response != null)
                            Debug.WriteLine($"HTTP STATUS      |  {(int)response.StatusCode} {response.StatusCode}");
                        else
                            Debug.WriteLine($"HTTP STATUS      |  NO RESPONSE");

                        // 401 Unauthorized → tvinga login och retry
                        if (response != null && response.StatusCode == HttpStatusCode.Unauthorized && attempt < maxRetries)
                        {
                            Debug.WriteLine("RESULT           |  401 Unauthorized → RETRYING LOGIN");
                            Login_Monitor.sessionId = null;
                            Login_Monitor.Login_API(); // Synkron login
                            response?.Close();
                            continue;
                        }

                        // Alla andra fel → kasta
                        response?.Close();
                        Debug.WriteLine("RESULT           |  ERROR (NON-RETRYABLE)");
                        Debug.WriteLine("====================================================");
                        return null;
                    }
                }

                throw new Exception("Monitor API: maximum retry attempts reached.");
            }
            finally
            {
                Cursor.Current = previous;
            }
        }









        public static int CounterMonitorRequests;
        //[DebuggerStepThrough]
        public static List<T> GetFromMonitor<T>(params string[] queryOptions) where T : DTO, new()
        {
            Cursor previous = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            CounterMonitorRequests++;

            // Bygger Monitor-URL
            var query = BuildQuery<T>(queryOptions);

            // Synkront GET-anrop
            var response = Http_Response(query);

            if (response == null)
                return null;
            var responseStreamm = response.GetResponseStream();

            //Denna är snabb
            try
            {
                // var sw = new Stopwatch();
                // sw.Start();

                var result = JsonSerializer.Deserialize<List<T>>(responseStreamm, JsonOptions);
                //  MessageBox.Show(sw.ElapsedMilliseconds.ToString());
                return result;


            }
            catch (Exception ex)
            {
                if (Person.Role == "SuperAdmin")
                    MessageBox.Show($"JSON Error in GetFromMonitor:\n{ex}");
                return null;
            }
            finally
            {
                Cursor.Current = previous;

            }
        }
       // [DebuggerStepThrough]
        public static T GetOneFromMonitor<T>(params string[] queryOptions) where T : DTO, new()
        {
            Cursor previous = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            CounterMonitorRequests++;

            // Bygg query
            var query = BuildQuery<T>(queryOptions);

            // Se till att den alltid bara tar 1 rad
            if (!query.Contains("$top="))
                query += query.Contains("?$") ? "&$top=1" : "?$top=1";

            // Synkron HTTP
            var response = Http_Response(query);
            if (response == null)
                return default;

            string json;

            // Läs JSON synkront från HttpWebResponse
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            // Är det en direkt-ID select (t.ex. "/12345")?
            bool isIdSelect =
                queryOptions.Length > 0 &&
                queryOptions[0].StartsWith("/");

            try
            {
                if (isIdSelect)
                {
                    // Returnera direkt T
                    return JsonSerializer.Deserialize<T>(json, JsonOptions);
                }
                else
                {
                    // Annars returnera första elementet från en lista
                    var list = JsonSerializer.Deserialize<List<T>>(json, JsonOptions);
                    return list?.FirstOrDefault();
                }
            }
            catch
            {
                return default;
            }
            finally
            {
                Cursor.Current = previous;
            }
        }
        [DebuggerStepThrough]
        private static string BuildQuery<T>(string[] queryOptions) where T : DTO, new()
        {
            // Bas-URL utan dubbel-slash-problem
            string baseUrl =
                $"https://{Database.MonitorHost}:8001/{Login_Monitor.LanguageCode}/{Database.MonitorCompany}/api/v1/{new T().URL}";

            string query = "";

            if (queryOptions.Length > 0)
            {
                bool isIdSelect = queryOptions[0].StartsWith("/");
                int i = isIdSelect ? 1 : 0;

                if (isIdSelect)
                    query = queryOptions[0];

                query += $"?${queryOptions[i]}";
                i++;

                for (; i < queryOptions.Length; i++)
                    query += $"&${queryOptions[i]}";
            }

            return baseUrl + query;
        }


        private class FlexibleLongConverter : JsonConverter<long>
        {
            public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                    return 0;

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