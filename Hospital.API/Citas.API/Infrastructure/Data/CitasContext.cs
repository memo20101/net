using Citas.API.Domain.Entities;
using System.Data.Entity;

namespace Citas.API.Infrastructure.Data
{
    public class CitasContext : DbContext
    {
        public CitasContext() : base("Cita")
        {
        }

        public virtual DbSet<Cita> Citas { get; set; }
       
    }
}