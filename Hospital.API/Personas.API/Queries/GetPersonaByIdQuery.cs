using MediatR;
using Personas.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Queries
{
    public class GetPersonaByIdQuery : IRequest<PersonaDto>
    {
        public int Id { get; set; }
    }
}