using MediatR;
using Personas.API.Commands;
using Personas.API.Domain.Entities;
using Personas.API.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using AutoMapper;

namespace Personas.API.Handlers
{
    public class CreatePersonaHandler : IRequestHandler<CreatePersonaCommand, int>
    {
        private readonly IPersonaRepository _repository;
        private readonly IMapper _mapper;

        public CreatePersonaHandler(IPersonaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<int> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
        {
            var persona = _mapper.Map<Persona>(request);
            _repository.Add(persona);
            return Task.FromResult(persona.Id);
        }
    }
}
