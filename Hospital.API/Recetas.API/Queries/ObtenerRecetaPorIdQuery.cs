using MediatR;
using Recetas.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.Queries
{
    public class ObtenerRecetaPorIdQuery : IRequest<RecetaDto>
    {
        public int Id { get; set; }
    }
}