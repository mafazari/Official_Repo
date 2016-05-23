using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Pas
    {
        [Key]
        public string PasID { get; set; }
        public int RekeningNr { get; set; }
        public int KlantID { get; set; }
        public int Actief { get; set; }
        public int Code { get; set; }
        public int FalsePin { get; set; }
    }
}