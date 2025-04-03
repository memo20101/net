using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.API.Commands
{
    public class ActualizarCitaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }
    }
}