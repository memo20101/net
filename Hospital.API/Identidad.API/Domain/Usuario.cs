using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identidad.API.Domain
{
	public class Usuario
	{
        public int Id { get; set; }
        public string UsuarioNombre { get; set; }

        public string Contrasenia { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public bool Activo { get; set; }
    }
}