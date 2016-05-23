﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class BankContext : DbContext
    {
        public BankContext() : base("MyDbContextConnectionStringRemote") //verwijs hier naar de connection string in de app.config. Op deze manier kan je redelijk makkelijk switchen tussen verschillende databases
        //public BankContext()
        {
            base.Configuration.LazyLoadingEnabled = false; //helaas ondersteunt de huidige versie van de mysql connector geen lazy loading, dus die moeten we uitzetten
        }

        public System.Data.Entity.DbSet<WebApplication5.Models.Klant> Klants { get; set; }

        public System.Data.Entity.DbSet<WebApplication5.Models.Rekening> Rekenings { get; set; }

        public System.Data.Entity.DbSet<WebApplication5.Models.Pas> Pas { get; set; }

        public System.Data.Entity.DbSet<WebApplication5.Models.Transactie> Transacties { get; set; }
    }
}