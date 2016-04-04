using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{

    /// <summary>
    /// This Class maps a table that represents jobs types like fulltime, part time, apprenticeship etc..
    /// </summary>
    [Table("JobType")]
    public class JobType
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}