using Newtonsoft.Json;

namespace CarlyNET.Body
{
    internal class LoginRequest : BaseRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
