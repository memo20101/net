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
using AutoMapper;
using Citas.API.DTOs;
using Citas.API.Queries;

namespace Citas.API.Handlers
{
    public class ProgramarCitaHandler : IRequestHandler<ProgramarCitaCommand, int>
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public ProgramarCitaHandler(ICitaRepository citaRepository, IMapper mapper)
        {
            _citaRepository = citaRepository;
            _mapper = mapper;
        }

        public Task<int> Handle(ProgramarCitaCommand request, CancellationToken cancellationToken)
        {
            var cita = _mapper.Map<Cita>(request);
            cita.Estado = EstadoCita.Pendiente;
            _citaRepository.Add(cita);
            return Task.FromResult(cita.Id);
        }
    }
}