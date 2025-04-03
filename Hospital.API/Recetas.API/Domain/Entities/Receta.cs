using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recetas.API.Domain.Entities
{
    public class Receta
    {
        public int Id { get; set; }
        public int CitaId { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime FechaEmision { get; set; } = DateTime.UtcNow;
        public DateTime? FechaVencimiento { get; set; }
        public EstadoReceta Estado { get; set; } = EstadoReceta.Activa;
        public string Medicamentos { get; set; }
        public string Instrucciones { get; set; }

        public string Observaciones { get; set; }
    }
}