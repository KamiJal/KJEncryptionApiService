using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KJEncryptionApi.Models
{
    public class EncryptionContext : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}