using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}