using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Razor.Text;

namespace KompetansetorgetServer.Models
{
    [Table("Job")]
    public class Job
    {


        public Job()
        {
            Study_groups = new HashSet<Study_group>();
        }


        [Key]
        public int IdJob { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Webpage { get; set; }
        public string LinkedIn_profile { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Expiry_date { get; set; }

        public string Steps_to_apply { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Published { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }

        public virtual ICollection<Study_group> Study_groups { get; set; }

        [Column("IdContact")]
        [ForeignKey("Contact")]
        public int IdContact { get; set; }
        public Contact Contact { get; set; }

        [Column("IdLocation")]
        [ForeignKey("Location")]
        public string IdLocation { get; set; }
        public Location Location { get; set; }

        [Column("IdJobType")]
        [ForeignKey("JobType")]
        public string IdJobType { get; set; }
        public JobType JobType { get; set; }

        [Column("IdCompany")]
        [ForeignKey("Company")]
        public string IdCompany { get; set; }
        public Company Company { get; set; }
    }
}