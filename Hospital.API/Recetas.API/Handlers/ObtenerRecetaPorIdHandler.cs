using AutoMapper;
using MediatR;
using Recetas.API.Domain.Interfaces;
using Recetas.API.DTOs;
using Recetas.API.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace Recetas.API.Handlers
{
    public class ObtenerRecetaPorIdHandler : IRequestHandler<ObtenerRecetaPorIdQuery, RecetaDto>
    {
        private readonly IRecetaRepository _repository;
        private readonly IMapper _mapper;

        public ObtenerRecetaPorIdHandler(IRecetaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<RecetaDto> Handle(ObtenerRecetaPorIdQuery request, CancellationToken cancellationToken)
        {
            var receta = _repository.GetById(request.Id);
            return Task.FromResult(_mapper.Map<RecetaDto>(receta));
        }
    }
}