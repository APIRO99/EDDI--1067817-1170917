using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project_1067817_1170917.Models
{
    public class Project_1067817_1170917Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Project_1067817_1170917Context() : base("name=Project_1067817_1170917Context")
        {
        }

        public System.Data.Entity.DbSet<Project_1067817_1170917.Models.Player> Players { get; set; }
    }
}
