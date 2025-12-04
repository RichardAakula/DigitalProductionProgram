using DigitalProductionProgram.Monitor.GET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static DigitalProductionProgram.Monitor.GET.Common;
using static DigitalProductionProgram.Monitor.GET.Inventory;

namespace DigitalProductionProgram.Monitor
{
    public class MonitorApiClient
    {
        private readonly HttpClient? _httpClient;
        private readonly HttpClientHandler _handler;

        public MonitorApiClient(string baseUrl, bool ignoreSslErrors = false)
        {
            if (ignoreSslErrors)
            {
                _handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                };
                _httpClient = new HttpClient(_handler) { BaseAddress = new Uri(baseUrl) };
            }
            else
            {
                _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
            }

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public bool Login(string username, string password, bool forceRelogin = true)
        {
            try
            {
                // Body för POST
                var body = new
                {
                    Username = username,
                    Password = password,
                    ForceRelogin = forceRelogin
                };

                // Säkerställ Accept-header
                if (!_httpClient.DefaultRequestHeaders.Accept.Any())
                    _httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")
                    );

                // POST mot exakt /login
                var response = _httpClient.PostAsJsonAsync("login", body).Result;

                if (!response.IsSuccessStatusCode)
                    return false;

                // Läs SessionId från header först
                string sessionId = response.Headers
                    .FirstOrDefault(h => h.Key.Contains("SessionId")).Value?.FirstOrDefault();

                // Fallback: läs från Set-Cookie
                if (string.IsNullOrEmpty(sessionId) && response.Headers.TryGetValues("Set-Cookie", out var cookies))
                {
                    var sessionCookie = cookies
                        .SelectMany(c => c.Split(';'))
                        .FirstOrDefault(p => p.Trim().StartsWith("SessionId="));
                    if (!string.IsNullOrEmpty(sessionCookie))
                        sessionId = sessionCookie.Substring("SessionId=".Length);
                }

                if (string.IsNullOrEmpty(sessionId))
                    return false;

                // Lägg till header
                if (_httpClient.DefaultRequestHeaders.Contains("X-Monitor-SessionId"))
                    _httpClient.DefaultRequestHeaders.Remove("X-Monitor-SessionId");
                _httpClient.DefaultRequestHeaders.Add("X-Monitor-SessionId", sessionId);

                // Lägg till cookie om handler finns
                if (_handler?.CookieContainer != null)
                    _handler.CookieContainer.Add(_httpClient.BaseAddress, new Cookie("SessionId", sessionId));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public class StringToLongConverter : JsonConverter<long>
        {
            public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Number)
                    return reader.GetInt64();
                if (reader.TokenType == JsonTokenType.String && long.TryParse(reader.GetString(), out var value))
                    return value;

                throw new JsonException($"Kan inte konvertera token {reader.TokenType} till long.");
            }

            public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value);
            }
        }
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            Converters = { new StringToLongConverter() }
        };
        public T GetListFromMonitor<T>(string endpoint)
        {
            var response = _httpClient.GetAsync(endpoint).Result;
            response.EnsureSuccessStatusCode();
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<T>(json, _jsonOptions);
        }
        public T GetOneFromMonitor<T>(string endpoint)
        {
            var response = _httpClient.GetAsync(endpoint).Result;
            response.EnsureSuccessStatusCode();
            var json = response.Content.ReadAsStringAsync().Result;

            if (string.IsNullOrWhiteSpace(json))
                return default!;

            json = json.TrimStart();

            // Om JSON är en array
            if (json.StartsWith("["))
            {
                var list = JsonSerializer.Deserialize<List<T>>(json, _jsonOptions);

                if (list == null || list.Count == 0)
                    return default!;

                return list[0];
            }

            // Annars: ett objekt
            return JsonSerializer.Deserialize<T>(json, _jsonOptions);
        }

    }


    public class InventoryService
    {
        private readonly MonitorApiClient _client;

        public InventoryService(MonitorApiClient client)
        {
            _client = client;
        }

        public List<PartCodes> GetPartCodes(string description)
        {
            Utilities.CounterMonitorRequests++;
            string endpoint = $"api/v1/Inventory/PartCodes?$filter=Description eq'{description}'";
            return _client.GetListFromMonitor<List<PartCodes>>(endpoint);
        }

        public List<Parts> GetParts(long partCodeId, string extraDescription = null)
        {
            Utilities.CounterMonitorRequests++;
            string filter = $"PartCodeId eq'{partCodeId}'";
            if (!string.IsNullOrEmpty(extraDescription))
                filter += $" AND ExtraDescription eq'{extraDescription}'";

            string endpoint = $"api/v1/Inventory/Parts?$filter={filter}";
            return _client.GetListFromMonitor<List<Parts>>(endpoint);
        }
        public List<Parts> GetPartsWithExpand(long partCodeId, string extraDescription = null)
        {
            Utilities.CounterMonitorRequests++;
            string filter = $"PartCodeId eq'{partCodeId}'";
            if (!string.IsNullOrEmpty(extraDescription))
                filter += $" AND ExtraDescription eq'{extraDescription}'";
            filter += "&$expand=ExtraFields";

            string endpoint = $"api/v1/Inventory/Parts?$filter={filter}";
            return _client.GetListFromMonitor<List<Parts>>(endpoint);
        }

        public ExtraFields GetExtraField(long parentId, string identifier)
        {
            Utilities.CounterMonitorRequests++;
            string endpoint = $"api/v1/Common/ExtraFields?$filter=ParentId eq'{parentId}' AND Identifier eq'{identifier}'&$select=StringValue";
            return _client.GetOneFromMonitor<ExtraFields>(endpoint);
        }
        public List<ExtraFields> GetExtraFields(string identifier, List<long> parentIds)
        {
            Utilities.CounterMonitorRequests++;

            var allExtraFields = new List<ExtraFields>();
            const int chunkSize = 200; // undvik för långa URL:er

            for (int i = 0; i < parentIds.Count; i += chunkSize)
            {
                var chunk = parentIds.Skip(i).Take(chunkSize).ToList();
                var filterParts = string.Join(" or ", chunk.Select(id => $"ParentId eq '{id}'"));
                var filter = $"({filterParts}) and Identifier eq '{identifier}'";
                var endpoint = $"api/v1/Inventory/ExtraFields?$filter={filter}";

                var extraFieldsChunk = _client.GetListFromMonitor<List<ExtraFields>>(endpoint);
                if (extraFieldsChunk != null)
                    allExtraFields.AddRange(extraFieldsChunk);
            }

            return allExtraFields;
        }


    }

}
