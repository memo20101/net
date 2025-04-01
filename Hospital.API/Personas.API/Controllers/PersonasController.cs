using AutoMapper;
using Personas.API.Domain.Entities;
using Personas.API.Domain.Interfaces;
using Personas.API.DTOs;
using Personas.API.Infrastructure.Data;
using Personas.API.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace Personas.API.Controllers
{
    [RoutePrefix("api/personas")]
    public class PersonasController : ApiController
    {
        private readonly IPersonaUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonasController(IPersonaUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var personas = _unitOfWork.Personas.GetAll();
            var personasDto = _mapper.Map<IEnumerable<PersonaDto>>(personas);
            return Ok(personasDto);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(CrearPersonaDto crearPersonaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var persona = _mapper.Map<Persona>(crearPersonaDto);
            _unitOfWork.Personas.Add(persona);
            _unitOfWork.Complete();

            var personaDto = _mapper.Map<PersonaDto>(persona);
            return Ok(personaDto);
        }
    }
}