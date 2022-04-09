using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using INSSWEBMVC.Entity;

namespace INSSWEBMVC.ConnectContext
{
    public class DataContext: DbContext
    {

        public DataContext() : base("ConnectionBank") { }
        public DbSet<InssModel> Inssdb { get; set; }
        public DbSet<CalculoModel> calculodb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InssModel>()
                .HasMany(e => e.listasalarios)
                .WithRequired(e => e.inssrefmodel)
                .HasForeignKey(e => e.inssid)
                .WillCascadeOnDelete(true);
        }



    }
    }