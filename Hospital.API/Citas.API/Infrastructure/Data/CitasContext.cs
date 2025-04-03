using Citas.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Citas.API.Infrastructure.Data
{
    public class CitasContext : DbContext
    {
        public CitasContext() 
        {
            this.Configuration.LazyLoadingEnabled = true;
        }


        public DbSet<Cita> Citas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cita>()
                .Property(q => q.Estado)
                .IsRequired();
        }



    }
}