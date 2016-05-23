using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Transactie
    {
        [Key]
        public int TransactieID { get; set; }
        public int RekeningID { get; set; }
        public double Bedrag { get; set; }
        public string PasID { get; set; }
    }
}