using Citas.API.Commands;
using Citas.API.Domain.Entities;
using Citas.API.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace Citas.API.Handlers
{
    public class CancelarCitaHandler : IRequestHandler<CancelarCitaCommand, Unit>
    {
        private readonly ICitaRepository _citaRepository;

        public CancelarCitaHandler(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        public Task<Unit> Handle(CancelarCitaCommand request, CancellationToken cancellationToken)
        {
            var cita = _citaRepository.GetById(request.Id);
            if (cita != null)
            {
                cita.Estado = EstadoCita.Cancelada;
                _citaRepository.Update(cita);
            }
            return Task.FromResult(Unit.Value);
        }
    }
}