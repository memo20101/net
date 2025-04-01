using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.DTOs
{
    public class CrearPersonaDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string TipoPersona { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}