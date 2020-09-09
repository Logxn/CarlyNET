using System;
using CarlyNET.Body.Response;
using CarlyNET.Body;
using CarlyNET.Request;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarlyNET
{
    public class CarlyUser
    {
        private static string _email;
        private static string _loginToken;
        private static int _lastUsedCarmake;
        private static int _registeredAt;
        private static RequestClient _req;

        public CarlySubscription SubscriptionInfo;
        public UpgradeOptions UpgradeOptions;
        public UsedFunctions UsedFunctions;
        public List<Vehicle> Vehicles;
        public DateTime RegisteredAt;

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

            Sync();
        }

        private void Sync()
        {
            // WARNING: Do NOT send faulty data, this COULD 'break' your account if Carly's server do not verify the data
            //          you are trying to send or if it does not let you revert the changes you made.
            //          (I have not verified this yet)
            //          Let the app do correct and safe syncing by using it normally!
            //
            //          Sending empty data, the way its done below, will return the current data Carly has about you, the
            //          adapter and your car.
            //
            //          Thank you for reading this paragraph ;)

            var syncBody = new SyncRequest
            {
                Purchases = new string[] { },
                Email = _email,
                CarMake = _lastUsedCarmake,
                Vehicles = new string[] { },
                LastUsedAdapter = 0,
                LastSyncAt = 1599519350
            };

            var resp = _req.PostAuthenticated("/users/sync", syncBody);
            var respParsed = JsonConvert.DeserializeObject<SyncResponse>(resp);

            UpgradeOptions = respParsed.UpgradeOptions;
            UsedFunctions = respParsed.UsedFunctions;
            Vehicles = respParsed.Vehicles;
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
