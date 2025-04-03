using AutoMapper;
using MediatR;
using Recetas.API.Commands;
using Recetas.API.Domain.Entities;
using Recetas.API.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace Recetas.API.Handlers
{
    public class CrearRecetaHandler : IRequestHandler<CrearRecetaCommand, int>
    {
        private readonly IRecetaRepository _repository;
        private readonly IMapper _mapper;

        public CrearRecetaHandler(IRecetaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<int> Handle(CrearRecetaCommand request, CancellationToken cancellationToken)
        {
            var receta = _mapper.Map<Receta>(request);

            if (request.DiasValidez.HasValue)
            {
                receta.FechaVencimiento = DateTime.UtcNow.AddDays(request.DiasValidez.Value);
            }

            _repository.Add(receta);
            return Task.FromResult(receta.Id);
        }
    }
}