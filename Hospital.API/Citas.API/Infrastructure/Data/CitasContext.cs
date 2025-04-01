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
        public CitasContext() : base("name=Cita")
        {

        }


        public DbSet<Cita> Citas { get; set; }
    }
}