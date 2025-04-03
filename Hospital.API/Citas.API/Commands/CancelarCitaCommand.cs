using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.API.Commands
{
    public class CancelarCitaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}