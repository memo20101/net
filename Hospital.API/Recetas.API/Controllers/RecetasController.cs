using AutoMapper;
using Recetas.API.Domain.Entities;
using Recetas.API.DTOs;
using Recetas.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Recetas.API.Controllers
{
    [RoutePrefix("api/recetas")]
    public class RecetasController : ApiController
    {
        private readonly IRecetaUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecetasController(IRecetaUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var recetas = _unitOfWork.Recetas.GetAll();
            var recetasDto = _mapper.Map<IEnumerable<RecetaDto>>(recetas);
            return Ok(recetasDto);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(CrearRecetaDto crearRecetaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var receta = _mapper.Map<Receta>(crearRecetaDto);
            _unitOfWork.Recetas.Add(receta);
            _unitOfWork.Complete();

            var recetaDto = _mapper.Map<RecetaDto>(receta);
            return Ok(recetaDto);
        }

        public object Delete(int v)
        {
            throw new NotImplementedException();
        }

        public object GetById(int v)
        {
            throw new NotImplementedException();
        }
    }
}