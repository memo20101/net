using AutoMapper;
using Citas.API.Commands;
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
    public class ActualizarCitaHandler : IRequestHandler<ActualizarCitaCommand, Unit>
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public ActualizarCitaHandler(ICitaRepository citaRepository, IMapper mapper)
        {
            _citaRepository = citaRepository;
            _mapper = mapper;
        }

        public Task<Unit> Handle(ActualizarCitaCommand request, CancellationToken cancellationToken)
        {
            var citaExistente = _citaRepository.GetById(request.Id);
            if (citaExistente != null)
            {
                _mapper.Map(request, citaExistente);
                _citaRepository.Update(citaExistente);
            }
            return Task.FromResult(Unit.Value);
        }
    }
}