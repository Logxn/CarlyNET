using Newtonsoft.Json;

namespace CarlyNET.Body
{
    internal class BaseRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("ad_id")]
        public string AdId { get; set; }
    }
}
