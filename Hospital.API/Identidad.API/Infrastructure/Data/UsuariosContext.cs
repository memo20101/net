using Identidad.API.Domain;
using System.Data.Entity;

namespace Identidad.API.Infrastructure.Data
{

        public class UsuariosContext : DbContext
        {
            public UsuariosContext() : base("name=Usuario")
            {
            }
            public DbSet<Usuario> Usuarios { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            }
        }
}