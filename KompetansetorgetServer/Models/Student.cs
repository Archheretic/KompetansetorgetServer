using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("Student")]
    public class Student
    {
        public Student()
        {
            Study_groups = new HashSet<Study_group>();
            Devices = new List<Device>();
        }
        [Key]
        [Column("Username")]
        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Study_group> Study_groups { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}