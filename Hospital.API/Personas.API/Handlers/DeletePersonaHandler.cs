using MediatR;
using OpenQA.Selenium;
using Personas.API.Commands;
using Personas.API.Domain.Entities;
using Personas.API.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace Personas.API.Handlers
{
    public class DeletePersonaHandler : IRequestHandler<DeletePersonaCommand, Unit>
    {
        private readonly IPersonaRepository _repository;

        public DeletePersonaHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {
            var persona = _repository.GetById(request.Id);
            if (persona == null)
                throw new NotFoundException();

            _repository.Delete(persona);
            return Task.FromResult(Unit.Value);
        }
    }
}