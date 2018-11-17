using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using KJEncryptionApi.ViewModels;

namespace KJEncryptionApi.Service
{
    public class EncryptionApiService
    {
        private readonly HttpClient _client;

        public enum Option
        {
            Encode,
            Decode,
            SignUp
        }

        public EncryptionApiService()
        {
            _client = new HttpClient { BaseAddress = new Uri("http://localhost:49631/api/Encryption/") };
        }

        public async Task<string> SendRequestAsync(EncryptionUserViewModel model)
        {
            var request = String.Empty;

            switch (model.option)
            {
                case Option.Encode: { request = $"encode?text={model.text}&token={model.token}"; } break;
                case Option.Decode: { request = $"decode?text={model.text}&token={model.token}"; } break;
                case Option.SignUp: { request = $"signup?email={model.email}&name={model.name}&password={model.password}"; } break;
            }

            var result = _client.PostAsync(request, null).Result;

            if (result.StatusCode == HttpStatusCode.Unauthorized)
                return "Your token is incorrect!";

            return (await result.Content.ReadAsStringAsync()).Replace("\"", "");
        }
    }
}

