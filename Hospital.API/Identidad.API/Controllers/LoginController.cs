using Identidad.API.Commads;
using Identidad.API.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Identidad.API.Controllers
{   
    [RoutePrefix("api/login")]
    public class LoginController: ApiController
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Login([FromBody] LoginUsuarioCommand command)
        {
            var usuarioDto = await _mediator.Send(command);

            if (usuarioDto == null)
            {
                return Content(HttpStatusCode.Unauthorized, new TokenResponse { Mensaje = "Credenciales incorrectas" });
            }

            return Ok(new TokenResponse { Token = usuarioDto.Token });
        }
    }
}