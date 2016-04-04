using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("StudyGroup")]
    public class StudyGroup
    {
        [Key]
        public string id { get; set; } // e.g administrasjon
        public string name { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

    }
}