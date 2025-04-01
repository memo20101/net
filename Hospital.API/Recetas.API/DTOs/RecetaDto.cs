using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.DTOs
{
    public class RecetaDto
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Detalle { get; set; }
    }
}