using Citas.API.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.API.Queries
{
    public class ObtenerCitaPorIdQuery : IRequest<CitaDto>
    {
        public int Id { get; set; }
    }
}