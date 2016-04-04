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

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Company> companies { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Contact> contacts { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Device> devices { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.JobType> jobTypes { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Location> locations { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Student> students { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.StudyGroup> studyGroup { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Job> jobs { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Course> courses { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Project> projects { get; set; }

        public System.Data.Entity.DbSet<KompetansetorgetServer.Models.Degree> degrees { get; set; }
    }
}
