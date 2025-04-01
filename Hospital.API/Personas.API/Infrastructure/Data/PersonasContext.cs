using Personas.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Personas.API.Infrastructure.Data
{
    public class PersonasContext : DbContext
    {
        // Constructor: llama a la cadena de conexión del Web.config
        public PersonasContext() : base("Persona")
        {
            // Esto ayuda a depurar las consultas SQL
        }

        public virtual DbSet<Persona> Personas { get; set; }



    }
}