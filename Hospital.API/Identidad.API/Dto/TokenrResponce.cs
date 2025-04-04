using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identidad.API.Dto
{
    public class TokenResponse
    {
        public string Token { get; set; }

        public string Mensaje { get; set; }
    }
}