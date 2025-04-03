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
        public RecetasContext() : base("Recetas") { }

        public DbSet<Receta> Recetas { get; set; }
    }
}