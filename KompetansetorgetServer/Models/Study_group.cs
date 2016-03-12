using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("Study_group")]
    public class Study_group
    {
        [Key]
        [Column("IdStudy_group")]
        public string IdStudy_group { get; set; } // administrasjon
        public string Name { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}