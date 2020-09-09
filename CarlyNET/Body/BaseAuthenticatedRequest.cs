using Newtonsoft.Json;

namespace CarlyNET.Body
{
    internal class BaseAuthenticatedRequest : BaseRequest
    {
        [JsonProperty("login_token")]
        public string LoginToken { get; set; }
    }
}
