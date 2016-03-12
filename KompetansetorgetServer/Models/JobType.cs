using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("JobType")]
    public class JobType
    {
        [Key]
        public string IdJobType { get; set; }

        public string Name { get; set; }
    }
}