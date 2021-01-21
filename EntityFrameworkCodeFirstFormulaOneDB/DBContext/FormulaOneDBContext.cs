using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFrameworkCodeFirstFormulaOneDB.DBContext
{
    public class FormulaOneDBContext : DbContext
    {
        public FormulaOneDBContext() : base("name=FormulaOneDBConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<EntityFrameworkCodeFirstFormulaOneDB.Models.Driver> Drivers { get; set; }

        public System.Data.Entity.DbSet<EntityFrameworkCodeFirstFormulaOneDB.Models.Championship> Championships { get; set; }

        public System.Data.Entity.DbSet<EntityFrameworkCodeFirstFormulaOneDB.Models.DriverChampionshipResult> DriverChampionshipResults { get; set; }
    }
}