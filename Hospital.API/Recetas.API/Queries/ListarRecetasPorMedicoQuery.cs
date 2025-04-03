using MediatR;
using Recetas.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.Queries
{
    public class ListarRecetasPorMedicoQuery : IRequest<IEnumerable<RecetaDto>>
    {
        public int MedicoId { get; set; }
    }
}