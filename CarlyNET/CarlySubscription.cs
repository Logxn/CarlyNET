using System;

using CarlyNET.Body.Response;

namespace CarlyNET
{
    public class CarlySubscription
    {
        public DateTime ExpiresAt;
        public string PurchaseId;
        public string PhoneOs;
        public string ProductId;

        internal CarlySubscription(VerifiedPurchasesResponse subscriptionInfo)
        {
            PurchaseId = subscriptionInfo.CarMake.PurchaseId;
            PhoneOs = subscriptionInfo.CarMake.PhoneOs;
            ProductId = subscriptionInfo.CarMake.ProductId;
            ExpiresAt = UnixToDate(subscriptionInfo.CarMake.ExpiresAt);
        }

        private DateTime UnixToDate(long unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
