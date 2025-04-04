using Personas.API.Domain.Entities;
using System.Data.Entity;

namespace Personas.API.Infrastructure.Data
{
    public class PersonasContext : DbContext
    {
        public PersonasContext() : base("Persona")
        {
        }

        public virtual DbSet<Persona> Personas { get; set; }

    }
}