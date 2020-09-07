using System;

using CarlyNET.Body;
using RestSharp;
using Newtonsoft.Json;

namespace CarlyNET.Request
{
    internal class RequestClient
    {
        private static RestClient _restClient;
        private const string BASE_URL = "https://solutions.mycarly.com";
        private const string KEY = "Bia7NZgZEfmmjiF4McJJPmLY7";

        public RequestClient()
        {
            _restClient = new RestClient(BASE_URL);
        }

        public string Post(string endpoint, BaseRequest content)
        {
            var request = new RestRequest(endpoint);
            request.AddHeader("App-Os", "IOS");
            request.AddHeader("App-Version", "40.1.18");

            content.Key = KEY;
            content.AdId = GenerateAdId();

            var body = JsonConvert.SerializeObject(content);

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var resp = _restClient.Post(request);

            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Internal error");

            return resp.Content;
        }

        private string GenerateAdId()
        {
            // Ad_id example: XXXXXXX-XXX-XXX-XXXXXXXXXXX

            var rnd = new Random();
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var adId = "";
            
            for(var i = 0; i < 8; i++)
            {
                var rndInt = rnd.Next(0, alphabet.Length);

                adId += alphabet[rndInt];
            }

            adId += "-";

            for(var i = 0; i < 3; i++)
            {
                for(var y = 0; y < 4; y++)
                {
                    var rndInt = rnd.Next(0, alphabet.Length);

                    adId += alphabet[rndInt];
                }

                adId += "-";
            }

            for(var i = 0; i < 12; i++)
            {
                var rndInt = rnd.Next(0, alphabet.Length);

                adId += alphabet[rndInt];
            }

            return adId;
        }
    }
}
