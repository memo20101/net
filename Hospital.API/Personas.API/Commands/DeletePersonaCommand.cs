using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Commands
{
    public class DeletePersonaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}