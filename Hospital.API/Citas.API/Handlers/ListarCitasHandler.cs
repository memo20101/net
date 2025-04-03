using AutoMapper;
using Citas.API.Domain.Interfaces;
using Citas.API.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using Citas.API.Queries;

namespace Citas.API.Handlers
{
    public class ListarCitasHandler : IRequestHandler<ListarCitasQuery, IEnumerable<CitaDto>>
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public ListarCitasHandler(ICitaRepository citaRepository, IMapper mapper)
        {
            _citaRepository = citaRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<CitaDto>> Handle(ListarCitasQuery request, CancellationToken cancellationToken)
        {
            var citas = _citaRepository.GetAll();
            return Task.FromResult(_mapper.Map<IEnumerable<CitaDto>>(citas));
        }
    }
}