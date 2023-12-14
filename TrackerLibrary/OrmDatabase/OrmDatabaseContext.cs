using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Data;
using TrackerLibrary.Models;

namespace TrackerLibrary.OrmDatabase
{
    public class OrmDatabaseContext : DbContext
    {
        public DbSet<PrizeModel> PrizeTable { get; set; }
        public OrmDatabaseContext()
        {
        }
        public OrmDatabaseContext(DbContextOptions<MyappContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Ez a metódus automatikusan hívódik amikor létrehozol egy OrmDatabaseContext példányt,
            //nem kell vele foglalkoznod
            if (!optionsBuilder.IsConfigured)
            {
                //Itt pedig azt mondod meg hogy milyen adatbázissal szeretnél kapcsolódni, és milyen connection string-el
                //A connection string mind1 honnan jön, jöhetne config fájlból is
                //Az adatbázis típusa pedig lehetne SQL Serveren kívül pl SQLite vagy bármi
                optionsBuilder.UseSqlServer("Server=localhost;Database=MarkTournoment;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
