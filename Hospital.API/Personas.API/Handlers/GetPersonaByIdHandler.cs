using AutoMapper;
using MediatR;
using OpenQA.Selenium;
using Personas.API.Domain.Entities;
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
    public class GetPersonaByIdHandler : IRequestHandler<GetPersonaByIdQuery, PersonaDto>
    {
        private readonly IPersonaRepository _repository;
        private readonly IMapper _mapper;

        public GetPersonaByIdHandler(IPersonaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PersonaDto> Handle(GetPersonaByIdQuery request, CancellationToken cancellationToken)
        {
            var persona = _repository.GetById(request.Id);
            if (persona == null)
                throw new NotFoundException();

            var result = _mapper.Map<PersonaDto>(persona);
            return Task.FromResult(result);
        }
    }
}