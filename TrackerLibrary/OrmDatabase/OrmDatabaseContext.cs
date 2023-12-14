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
            if (!optionsBuilder.IsConfigured)
            {
                // Set your connection string here
                optionsBuilder.UseSqlServer("Server=localhost;Database=MarkTournoment;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
