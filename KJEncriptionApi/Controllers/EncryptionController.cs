using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KJEncryptionApi.Models;
using KJEncryptionApi.Service;

namespace KJEncryptionApi.Controllers
{
    public class EncryptionController : ApiController
    {

        [HttpPost]
        public IHttpActionResult SignUp(string email, string name, string password)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(password))
                return BadRequest();

            var user = new User(name, email, password);
            var contextService = new ContextService();

            var userInDb = contextService.GetUserByEmail(email);

            var token = String.Empty;

            if (userInDb == null)
            {
                if (!contextService.AddUser(user))
                    return InternalServerError();
                token = user.Token;
            }
            else
            {
                token = userInDb.Token;
            }

            contextService.Dispose();

            return Ok(token);
        }

        [HttpPost]
        [Route("api/encryption/decode")]
        public IHttpActionResult Decode(string text, string token)
        {
            if (String.IsNullOrWhiteSpace(text) || String.IsNullOrWhiteSpace(token))
                return BadRequest();

            var contextService = new ContextService();
            var userInDb = contextService.GetUserByToken(token);

            if(userInDb == null)
            {
                contextService.Dispose();
                return Unauthorized();
            }

            contextService.Dispose();

            var encodeService = new EncodeDecodeService();
            var decoded = encodeService.Decode(text);

            
            return Ok(decoded);
        }

        [HttpPost]
        [Route("api/encryption/encode")]
        public IHttpActionResult Encode(string text, string token)
        {
            if (String.IsNullOrWhiteSpace(text) || String.IsNullOrWhiteSpace(token))
                return BadRequest();

            var contextService = new ContextService();
            var userInDb = contextService.GetUserByToken(token);

            if (userInDb == null)
            {
                contextService.Dispose();
                return Unauthorized();
            }

            contextService.Dispose();

            var encodeService = new EncodeDecodeService();
            var encoded = encodeService.Encode(text);

            return Ok(encoded);
        }



    }
}
