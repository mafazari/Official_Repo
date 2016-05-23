using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Rekening
    {
        [Key]
        public int RekeningNr { get; set; }
        public double Balans { get; set; }
        public int RekeningType { get; set; }
        public int KlantNr { get; set; }  
        public String Hash { get; set; }      
    }
}