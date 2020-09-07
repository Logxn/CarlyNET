using Newtonsoft.Json;

namespace CarlyNET.Body.Response
{
    internal class VerifiedPurchasesResponse
    {
        [JsonProperty("vag")]
        public CarMake CarMake { get; set; }
    }

    internal class CarMake
    {
        [JsonProperty("expires_at")]
        public long ExpiresAt { get; set; }
        [JsonProperty("os")]
        public string PhoneOs { get; set; }
        [JsonProperty("product_id")]
        public string ProductId { get; set; }
        [JsonProperty("purchase_id")]
        public string PurchaseId { get; set; }
    }
}
