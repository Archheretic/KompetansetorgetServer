using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    public class KompetansetorgetServerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public KompetansetorgetServerContext() : base("name=KompetansetorgetServerContext")
        {
        }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Device> Devices { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.JobType> JobTypes { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Study_group> Study_group { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Job> Jobs { get; set; }
    }
}
