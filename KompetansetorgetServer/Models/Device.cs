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
        public string IdDevice { get; set; }
        public string Token { get; set; } // size: (4096)
        public string DeviceType { get; set; }

        public virtual Student Student { get; set; }
    }
}