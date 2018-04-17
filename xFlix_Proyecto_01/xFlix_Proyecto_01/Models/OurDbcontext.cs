using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace xFlix_Proyecto_01.Models
{
    public class OurDbcontext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
    }
}