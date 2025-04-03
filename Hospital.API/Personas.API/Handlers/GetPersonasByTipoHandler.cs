using AutoMapper;
using MediatR;
using Personas.API.Domain.Interfaces;
using Personas.API.DTOs;
using Personas.API.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace Personas.API.Handlers
{
    public class GetPersonasByTipoHandler : IRequestHandler<GetPersonasByTipoQuery, List<PersonaDto>>
    {
        private readonly IPersonaRepository _repository;
        private readonly IMapper _mapper;

        public GetPersonasByTipoHandler(IPersonaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<PersonaDto>> Handle(GetPersonasByTipoQuery request, CancellationToken cancellationToken)
        {
            var personas = _repository.GetByTipo(request.Tipo);
            var result = _mapper.Map<List<PersonaDto>>(personas);
            return Task.FromResult(result);
        }
    }
}