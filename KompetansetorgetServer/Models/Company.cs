using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KompetansetorgetServer.Models
{
    [Table("Company")]
    public class Company
    {
        [Key]
        [Column("IdCompany")]
        public string IdCompany { get; set; }

        public string Name { get; set; }
        public string Adress { get; set; }
        public string Url { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

     }

}