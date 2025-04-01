using AutoMapper;
using Citas.API.Domain.Entities;
using Citas.API.Domain.Interfaces;
using Citas.API.DTOs;
using Citas.API.Infrastructure.Data;
using Citas.API.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Citas.API.Controllers
{
    [RoutePrefix("api/citas")]
    public class CitasController : ApiController
    {
        private readonly ICitaUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CitasController(ICitaUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todas las citas.
        /// </summary>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var citas = _unitOfWork.Citas.GetAll();
            var citasDto = _mapper.Map<IEnumerable<CitaDTO>>(citas);

            return Ok(citasDto);
        }

        /// <summary>
        /// Obtiene una cita específica por Id.
        /// </summary>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var cita = _unitOfWork.Citas.GetById(id);

            if (cita == null)
                return NotFound();

            var citaDto = _mapper.Map<CitaDTO>(cita);
            return Ok(citaDto);
        }

        /// <summary>
        /// Crea una nueva cita.
        /// </summary>
        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] CrearCitaDTO crearCitaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cita = _mapper.Map<Cita>(crearCitaDto);
            _unitOfWork.Citas.Add(cita);
            _unitOfWork.Complete();

            var citaDto = _mapper.Map<CitaDTO>(cita);
            return CreatedAtRoute("DefaultApi", new { id = citaDto.Id }, citaDto);
        }

        /// <summary>
        /// Actualiza una cita existente.
        /// </summary>
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, [FromBody] CrearCitaDTO actualizarCitaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var citaExistente = _unitOfWork.Citas.GetById(id);
            if (citaExistente == null)
                return NotFound();

            // Mapear los cambios al objeto existente
            _mapper.Map(actualizarCitaDto, citaExistente);

            _unitOfWork.Citas.Update(citaExistente);
            _unitOfWork.Complete();

            var citaDto = _mapper.Map<CitaDTO>(citaExistente);
            return Ok(citaDto);
        }

        /// <summary>
        /// Elimina una cita existente.
        /// </summary>
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var citaExistente = _unitOfWork.Citas.GetById(id);

            if (citaExistente == null)
                return NotFound();

            _unitOfWork.Citas.Delete(citaExistente);
            _unitOfWork.Complete();

            return Ok($"Cita con id {id} eliminada correctamente.");
        }
    }
}