using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public string id { get; set; }

        public string name { get; set; }
        public string adress { get; set; }
        public string url { get; set; }
        public string facebook { get; set; }
        public string linkedIn { get; set; }
        public string description { get; set; }
        public string logo { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

    }

}