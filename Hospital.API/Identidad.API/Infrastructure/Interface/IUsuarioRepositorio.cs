using Identidad.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identidad.API.Infrastructure.Interface
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> ObtenerPorUsuarioAsync(string usuarioNombre);
    }
}
