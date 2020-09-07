using CarlyNET.Body.Response;
using CarlyNET.Body;
using CarlyNET.Request;
using Newtonsoft.Json;

namespace CarlyNET
{
    public class CarlyUser
    {
        private static string _email;
        private static string _loginToken;
        private static int _lastUsedCarmake;

        private static RequestClient _req;
        public CarlySubscription SubscriptionInfo;

        internal CarlyUser(LoginResponse loginResponse)
        {
            _email = loginResponse.Email;
            _loginToken = loginResponse.LoginToken;
            _lastUsedCarmake = loginResponse.LastUsedCarMake;

            _req = new RequestClient();

            VerifyPurchase();
        }

        private void VerifyPurchase()
        {
            var verifiedPurchasesBody = new VerifiedPurchasesRequest
            {
                Email = _email,
            };

            var resp = _req.PostAuthenticated("/users/verifiedPurchases", verifiedPurchasesBody);
            var respParsed = JsonConvert.DeserializeObject<VerifiedPurchasesResponse>(resp);

            SubscriptionInfo = new CarlySubscription(respParsed);
        }

        public string GetLastUsedCarmake()
        {
            switch (_lastUsedCarmake)
            {
                case 3:
                    return "Volkswagen";
                default:
                    return "UNKNOWN";
            }
        }
    }
}
