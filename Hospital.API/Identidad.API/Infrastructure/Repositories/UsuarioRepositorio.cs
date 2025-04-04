using Identidad.API.Domain;
using Identidad.API.Infrastructure.Data;
using Identidad.API.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Identidad.API.Infrastructure.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UsuariosContext _context;

        public UsuarioRepositorio(UsuariosContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObtenerPorUsuarioAsync(string usuarioNombre)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioNombre == usuarioNombre);
        }

        public async Task AgregarUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}