using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int IdContact { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}