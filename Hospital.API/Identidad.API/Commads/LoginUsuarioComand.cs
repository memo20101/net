using Identidad.API.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identidad.API.Commads
{
    public class LoginUsuarioCommand : IRequest<UsuarioDto>
    {
        public string UsuarioNombre { get; set; }
        public string Contrasenia { get; set; }

        public LoginUsuarioCommand(string usuarioNombre, string contrasenia)
        {
            UsuarioNombre = usuarioNombre;
            Contrasenia = contrasenia;
        }
    }

}