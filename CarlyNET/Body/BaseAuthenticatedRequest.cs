using Newtonsoft.Json;

namespace CarlyNET.Body
{
    internal class BaseAuthenticatedRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("ad_id")]
        public string AdId { get; set; }
        [JsonProperty("login_token")]
        public string LoginToken { get; set; }
    }
}
