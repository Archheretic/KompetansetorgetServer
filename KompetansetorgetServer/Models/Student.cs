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
            studyGroups = new HashSet<StudyGroup>();
            Devices = new List<Device>();
        }
        [Key]
        [Column("username")]
        public string username { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public virtual ICollection<StudyGroup> studyGroups { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}