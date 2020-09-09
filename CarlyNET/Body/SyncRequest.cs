using Newtonsoft.Json;

namespace CarlyNET.Body
{
    internal class SyncRequest : BaseAuthenticatedRequest
    {
        [JsonProperty("purchases")]
        public string[] Purchases { get; set; }
        [JsonProperty("car_make")]
        public int CarMake { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("vehicles")]
        public string[] Vehicles { get; set; }
        [JsonProperty("last_used_adapter")]
        public int LastUsedAdapter { get; set; }
        [JsonProperty("last_sync_at")]
        public long LastSyncAt { get; set; }
    }
}
