using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.Commands
{
    public class CambiarEstadoRecetaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Estado { get; set; }
    }
}