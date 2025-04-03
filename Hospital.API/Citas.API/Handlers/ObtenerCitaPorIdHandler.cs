using AutoMapper;
using Citas.API.Domain.Interfaces;
using Citas.API.DTOs;
using Citas.API.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace Citas.API.Handlers
{
    public class ObtenerCitaPorIdHandler : IRequestHandler<ObtenerCitaPorIdQuery, CitaDto>
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public ObtenerCitaPorIdHandler(ICitaRepository citaRepository, IMapper mapper)
        {
            _citaRepository = citaRepository;
            _mapper = mapper;
        }

        public Task<CitaDto> Handle(ObtenerCitaPorIdQuery request, CancellationToken cancellationToken)
        {
            var cita = _citaRepository.GetById(request.Id);
            var citaDto = _mapper.Map<CitaDto>(cita);
            return Task.FromResult(citaDto);
        }
    }
}