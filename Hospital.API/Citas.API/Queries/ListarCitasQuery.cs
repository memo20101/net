using Citas.API.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.API.Queries
{
    public class ListarCitasQuery : IRequest<IEnumerable<CitaDto>>
    {
    }
}