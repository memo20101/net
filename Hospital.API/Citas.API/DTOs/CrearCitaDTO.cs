using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.API.DTOs
{
    public class CrearCitaDTO
    {
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
    }
}