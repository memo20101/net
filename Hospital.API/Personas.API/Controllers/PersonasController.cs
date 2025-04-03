using AutoMapper;
using MediatR;
using Personas.API.Commands;
using Personas.API.Domain.Entities;
using Personas.API.Domain.Interfaces;
using Personas.API.DTOs;
using Personas.API.Infrastructure.Data;
using Personas.API.Infrastructure.Repositories;
using Personas.API.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Personas.API.Controllers
{
    [RoutePrefix("api/personas")]
    public class PersonasController : ApiController
    {
        private readonly IMediator _mediator;

        public PersonasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var query = new GetAllPersonasQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var query = new GetPersonaByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("tipo/{tipo}")]
        public async Task<IHttpActionResult> GetByTipo(TipoPersona tipo)
        {
            var query = new GetPersonasByTipoQuery { Tipo = tipo };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody] CreatePersonaCommand command)
        {
            var result = await _mediator.Send(command);
            return Created($"api/personas/{result}", result);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, [FromBody] UpdatePersonaCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var command = new DeletePersonaCommand { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}