using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Commands
{
    public class UpdatePersonaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Especialidad { get; set; }
        public string NumeroLicencia { get; set; }
    }
}