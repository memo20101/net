using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.Commands
{
    public class ActualizarRecetaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Medicamentos { get; set; }
        public string Instrucciones { get; set; }
        public string Observaciones { get; set; }
    }
}