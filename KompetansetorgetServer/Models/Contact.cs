using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}