using Newtonsoft.Json;

namespace DigitalProductionProgram.Monitor
{
    public class AuthenticationBody
    {
        [JsonProperty("username")]
        public string Username { get; set; } = "OPTIAPI";

        [JsonProperty("password")]
        public string Password { get; set; } = "OptiAPI9767!";

        [JsonProperty("forceRelogin")]
        public bool ForceRelogin { get; set; } = true;
    }
}