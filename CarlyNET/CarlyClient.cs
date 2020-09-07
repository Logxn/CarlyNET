using System;
using Newtonsoft.Json;
using CarlyNET.Request;
using CarlyNET.Body;
using CarlyNET.Body.Response;

namespace CarlyNET
{
    public class CarlyClient
    {
        private static RequestClient _req;

        public CarlyClient()
        {
            _req = new RequestClient();
        }

        public void Login(string username, string password)
        {
            var loginBody = new LoginRequest
            {
                Email = username,
                Password = password
            };

            var resp = _req.Post("/users/login", loginBody);
            var respParsed = JsonConvert.DeserializeObject<LoginResponse>(resp);
        }
    }
}
