using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_WebApp.Models;

namespace Proiect_WebApp.Data
{
    public class Proiect_WebAppContext : DbContext
    {
        public Proiect_WebAppContext (DbContextOptions<Proiect_WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_WebApp.Models.Produs> Produs { get; set; }

        public DbSet<Proiect_WebApp.Models.Vanzator> Vanzator { get; set; }

        public DbSet<Proiect_WebApp.Models.Categorie> Categorie { get; set; }
    }
}
