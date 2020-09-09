using System;
using System.Net;

using RestSharp;
using Newtonsoft.Json;
using CarlyNET.Body;
using CarlyNET.Body.Response;

namespace CarlyNET.Request
{
    internal class RequestClient
    {
        private static RestClient _restClient;

        private const string BASE_URL = "https://solutions.mycarly.com";
        private const string KEY = "Bia7NZgZEfmmjiF4McJJPmLY7";
        private const string ADID = "J9UAQ2FJ-60OZ-0LXU-BI5V-EDKMADW33Q2X";

        private static string _loginToken = "";

        public RequestClient()
        {
            _restClient = new RestClient(BASE_URL);
            _restClient.AddDefaultHeader("App-Os", "IOS");
            _restClient.AddDefaultHeader("App-Version", "40.1.18");
        }

        public string Post(string endpoint, BaseRequest content)
        {
            var request = new RestRequest(endpoint);

            content.Key = KEY;
            content.AdId = ADID;

            var body = JsonConvert.SerializeObject(content);

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var resp = _restClient.Post(request);

            if (resp.StatusCode != HttpStatusCode.OK)
                throw new Exception("Internal Error");

            _loginToken = JsonConvert.DeserializeObject<LoginResponse>(resp.Content).LoginToken;

            return resp.Content;
        }

        public string PostAuthenticated(string endpoint, BaseAuthenticatedRequest content)
        {
            var request = new RestRequest(endpoint);

            content.Key = KEY;
            content.AdId = ADID;
            content.LoginToken = _loginToken;

            var body = JsonConvert.SerializeObject(content);

#if DEBUG
            Console.WriteLine($"[Request => {endpoint}]");
            Console.WriteLine(body + Environment.NewLine);
#endif

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var resp = _restClient.Post(request);

            if (resp.StatusCode != HttpStatusCode.OK)
                throw new Exception("Internal Error");

#if DEBUG
            Console.WriteLine($"[Response <= {endpoint}]");
            Console.WriteLine(resp.Content + Environment.NewLine);
#endif
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
