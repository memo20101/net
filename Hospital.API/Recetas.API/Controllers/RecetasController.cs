using AutoMapper;
using MediatR;
using Recetas.API.Commands;
using Recetas.API.Domain.Entities;
using Recetas.API.DTOs;
using Recetas.API.Infrastructure.Data;
using Recetas.API.Queries;
using System.Web.Http;

namespace Recetas.API.Controllers
{
    [RoutePrefix("api/recetas")]
    public class RecetasController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RecetasController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Crear([FromBody] CrearRecetaCommand command)
        {
            var id = _mediator.Send(command).Result;
            return Ok(new { Id = id });
        }
        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Actualizar(int id, [FromBody] ActualizarRecetaCommand command)
        {
            command.Id = id;
            _mediator.Send(command).Wait();
            return Ok();
        }

        [HttpPut]
        [Route("{id}/estado")]
        public IHttpActionResult CambiarEstado(int id, [FromBody] CambiarEstadoRecetaCommand command)
        {
            command.Id = id;
            _mediator.Send(command).Wait();
            return Ok();
        }
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult ObtenerPorId(int id)
        {
            var query = new ObtenerRecetaPorIdQuery { Id = id };
            var result = _mediator.Send(query).Result;
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        [Route("paciente/{pacienteId}")]
        public IHttpActionResult ListarPorPaciente(int pacienteId)
        {
            var query = new ListarRecetasPorPacienteQuery { PacienteId = pacienteId };
            var result = _mediator.Send(query).Result;
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        [Route("medico/{medicoId}")]
        public IHttpActionResult ListarPorMedico(int medicoId)
        {
            var query = new ListarRecetasPorMedicoQuery { MedicoId = medicoId };
            var result = _mediator.Send(query).Result;
            return Ok(result);
        }
    }
}