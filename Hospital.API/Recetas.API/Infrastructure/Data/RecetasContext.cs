using Recetas.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Recetas.API.Infrastructure.Data
{
    public class RecetasContext : DbContext
    {
        public RecetasContext() : base("Receta")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Receta> Recetas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receta>().ToTable("Recetas");
            modelBuilder.Entity<Receta>().HasKey(r => r.Id);
            modelBuilder.Entity<Receta>().Property(r => r.Medicamentos).IsRequired();
            modelBuilder.Entity<Receta>().Property(r => r.Instrucciones).HasMaxLength(1000);
            modelBuilder.Entity<Receta>().Property(r => r.Observaciones).HasMaxLength(500);
        }
    }
}