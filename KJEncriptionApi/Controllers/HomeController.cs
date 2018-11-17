using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using KJEncryptionApi.Service;
using KJEncryptionApi.ViewModels;

namespace KJEncryptionApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ApiUser()
        {
            return View();
        }

        [HttpPost]
        public string Register(EncryptionUserViewModel model)
        {
            model.option = EncryptionApiService.Option.SignUp;

            var encryptionApiService = new EncryptionApiService();
            return encryptionApiService.SendRequestAsync(model).Result;
        }

        [HttpPost]
        public string Encode(EncryptionUserViewModel model)
        {
            model.option = EncryptionApiService.Option.Encode;
            var encryptionApiService = new EncryptionApiService();

            return encryptionApiService.SendRequestAsync(model).Result;
        }

        [HttpPost]
        public string Decode(EncryptionUserViewModel model)
        {
            model.option = EncryptionApiService.Option.Decode;

            var encryptionApiService = new EncryptionApiService();
            return encryptionApiService.SendRequestAsync(model).Result;
        }
    }
}
