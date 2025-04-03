using MediatR;
using Personas.API.Domain.Entities;
using Personas.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Queries
{
    public class GetPersonasByTipoQuery : IRequest<List<PersonaDto>>
    {
        public TipoPersona Tipo { get; set; }
    }
}