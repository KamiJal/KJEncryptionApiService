using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KJEncryptionApi.Service;

namespace KJEncryptionApi.ViewModels
{
    public class EncryptionUserViewModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string text { get; set; }
        public string token { get; set; }
        public EncryptionApiService.Option option { get; set; }
    }
}