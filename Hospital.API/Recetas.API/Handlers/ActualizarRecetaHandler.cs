using AutoMapper;
using MediatR;
using Recetas.API.Commands;
using Recetas.API.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace Recetas.API.Handlers
{
    public class ActualizarRecetaHandler : IRequestHandler<ActualizarRecetaCommand, Unit>
    {
        private readonly IRecetaRepository _repository;
        private readonly IMapper _mapper;

        public ActualizarRecetaHandler(IRecetaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<Unit> Handle(ActualizarRecetaCommand request, CancellationToken cancellationToken)
        {
            var receta = _repository.GetById(request.Id);
            if (receta != null)
            {
                _mapper.Map(request, receta);
                _repository.Update(receta);
            }
            return Task.FromResult(Unit.Value);
        }
    }
}