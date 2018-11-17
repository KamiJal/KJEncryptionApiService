using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KJEncryptionApi.Models;

namespace KJEncryptionApi.Service
{
    public class ContextService
    {
        private readonly EncryptionContext _context;

        public ContextService()
        {
            _context = new EncryptionContext();
        }

        public bool AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                _context.Dispose();
                return false;
            }

            return true;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(q=>q.Email.Equals(email));
        }

        public User GetUserByToken(string token)
        {
            return _context.Users.SingleOrDefault(q => q.Token.Equals(token));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}