using Newtonsoft.Json;

namespace CarlyNET.Body
{
    // I dont know why but that is the name of the endpoint, send help please.
    // If someone from carly sees this: Why not rename it to "VerifyPurchase" ?
    internal class VerifiedPurchasesRequest : BaseAuthenticatedRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
