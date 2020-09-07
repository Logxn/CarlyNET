using Newtonsoft.Json;

namespace CarlyNET.Body.Response
{
    internal class LoginResponse
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("login_token")]
        public string LoginToken { get; set; }
        [JsonProperty("last_used_carmake")]
        public int LastUsedCarMake { get; set; }
    }
}
