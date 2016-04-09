using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("ApprovedCourse")]
    public class ApprovedCourse
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}