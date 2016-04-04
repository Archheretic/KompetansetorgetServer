using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("Project")]
    public class Project
    {
        public Project()
        {
            companies = new HashSet<Company>();
            contacts = new HashSet<Contact>();
            courses = new HashSet<Course>();
            studyGroups = new HashSet<StudyGroup>();
            jobTypes = new HashSet<JobType>();
            degrees = new HashSet<Degree>();
        }

        [Key]
        public string uuid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string webpage { get; set; }
        public string linkedInProfile { get; set; }
        public string status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime expiryDate { get; set; }

        public string stepsToApply { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime created { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime published { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime modified { get; set; }

        public virtual ICollection<Company> companies { get; set; }

        public virtual ICollection<Contact> contacts { get; set; }

        public virtual ICollection<Course> courses { get; set; }

        public virtual ICollection<Degree> degrees { get; set; }

        public virtual ICollection<JobType> jobTypes { get; set; }

        public virtual ICollection<StudyGroup> studyGroups { get; set; }
    }
}
