using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Klant
    {
        [Key]       
        public int KlantID { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Adres { get; set; }
        public string Woonplaats { get; set; }
        public string Contact { get; set; }
    }
}