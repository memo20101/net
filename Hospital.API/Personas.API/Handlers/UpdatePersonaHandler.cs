using AutoMapper;
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
using OpenQA.Selenium;

namespace Personas.API.Handlers
{
    public class UpdatePersonaHandler : IRequestHandler<UpdatePersonaCommand, Unit>
    {
        private readonly IPersonaRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePersonaHandler(IPersonaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<Unit> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
        {
            var persona = _repository.GetById(request.Id);
            if (persona == null)
                throw new NotFoundException();

            _mapper.Map(request, persona);
            _repository.Update(persona);
            return Task.FromResult(Unit.Value);
        }
    }
}