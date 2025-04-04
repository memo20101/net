using Identidad.API.Commads;
using Identidad.API.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using Identidad.API.Infrastructure.Interface;

namespace Identidad.API.Handlers
{
    public class LoginHandler : IRequestHandler<LoginUsuarioCommand, UsuarioDto>
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITokenServicio _tokenServicio;

        public LoginHandler(IUsuarioRepositorio usuarioRepositorio, ITokenServicio tokenServicio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _tokenServicio = tokenServicio;
        }

        public async Task<UsuarioDto> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepositorio.ObtenerPorUsuarioAsync(request.UsuarioNombre);

            if (usuario == null || !VerificarContrasenia(request.Contrasenia, usuario.Contrasenia))
            {
                return null;
            }

            var token = _tokenServicio.GenerarToken(usuario);
            return new UsuarioDto { UsuarioNombre = usuario.UsuarioNombre, Token = token };
        }

        private bool VerificarContrasenia(string contrasenia, string contraseniaHash)
        {
            return contrasenia == contraseniaHash;
        }
    }
}