using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("Degree")]
    public class Degree
    {
        [Key]
        public string id { get; set; } // e.g bachelor
        public string name { get; set; } // e.g Bachelor
        public virtual ICollection<Project> Projects { get; set; }
    }
}