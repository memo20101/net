 using AutoMapper;
using Citas.API.Commands;
using Citas.API.Domain.Entities;
using Citas.API.Domain.Interfaces;
using Citas.API.DTOs;
using Citas.API.Infrastructure.Data;

using Citas.API.Infrastructure.Repositories;
using Citas.API.Queries;
using Citas.API.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Citas.API.Controllers
{
    [RoutePrefix("api/citas")]
    public class CitasController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly PersonasService _personasService;

        public CitasController(IMediator mediator, IMapper mapper, PersonasService personasService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _personasService = personasService;
        }
        [Authorize]
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> ProgramarCita([FromBody] ProgramarCitaCommand command)
        {
            var persona = await _personasService.ObtenerPersonaPorIdAsync(command.PacienteId);
            if (persona == null)
                return BadRequest("Paciente no encontrado");

            var citaId = await _mediator.Send(command);
            return Ok(new { Id = citaId });
        }
        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult ActualizarCita(int id, [FromBody] ActualizarCitaCommand command)
        {
            command.Id = id;
            _mediator.Send(command).Wait();
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult CancelarCita(int id)
        {
            var command = new CancelarCitaCommand { Id = id };
            _mediator.Send(command).Wait();
            return Ok();
        }
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult ObtenerCitaPorId(int id)
        {
            var query = new ObtenerCitaPorIdQuery { Id = id };
            var cita = _mediator.Send(query).Result;
            return Ok(cita);
        }
        [Authorize]
        [HttpGet]
        [Route("")]
        public IHttpActionResult ListarTodasLasCitas()
        {
            var query = new ListarCitasQuery();
            var citas = _mediator.Send(query).Result;
            return Ok(citas);
        }

        [HttpGet]
        [Route("medico/{medicoId}")]
        public IHttpActionResult ListarCitasPorMedico(int medicoId)
        {
            var query = new ListarCitasPorMedicoQuery { MedicoId = medicoId };
            var citas = _mediator.Send(query).Result;
            return Ok(citas);
        }

        [HttpGet]
        [Route("paciente/{pacienteId}")]
        public IHttpActionResult ListarCitasPorPaciente(int pacienteId)
        {
            var query = new ListarCitasPorPacienteQuery { PacienteId = pacienteId };
            var citas = _mediator.Send(query).Result;
            return Ok(citas);
        }
    }
}