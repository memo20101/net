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
    public class ListarCitasPorPacienteHandler : IRequestHandler<ListarCitasPorPacienteQuery, IEnumerable<CitaDto>>
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public ListarCitasPorPacienteHandler(ICitaRepository citaRepository, IMapper mapper)
        {
            _citaRepository = citaRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<CitaDto>> Handle(ListarCitasPorPacienteQuery request, CancellationToken cancellationToken)
        {
            var citas = _citaRepository.GetAll(); // Asume que hay un método GetByPacienteId en el repositorio
            return Task.FromResult(_mapper.Map<IEnumerable<CitaDto>>(citas));
        }
    }
}