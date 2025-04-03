using MediatR;
using Personas.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Commands
{
	public class CreatePersonaCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroIdentificacion { get; set; }
        public TipoPersona Tipo { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Especialidad { get; set; }
        public string NumeroLicencia { get; set; }
    }
}