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
    public class ListarCitasPorMedicoHandler : IRequestHandler<ListarCitasPorMedicoQuery, IEnumerable<CitaDto>>
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public ListarCitasPorMedicoHandler(ICitaRepository citaRepository, IMapper mapper)
        {
            _citaRepository = citaRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<CitaDto>> Handle(ListarCitasPorMedicoQuery request, CancellationToken cancellationToken)
        {
            var citas = _citaRepository.GetAll(); // Asume que hay un método GetByMedicoId en el repositorio
            return Task.FromResult(_mapper.Map<IEnumerable<CitaDto>>(citas));
        }
    }
}