using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("Device")]
    public class Device
    {
        [Key]
        public string id { get; set; }
        public string token { get; set; } // size: (4096)
        public string deviceType { get; set; }

        public virtual Student Student { get; set; }
    }
}