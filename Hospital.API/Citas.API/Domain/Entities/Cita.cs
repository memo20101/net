using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.API.Domain.Entities
{
    public enum EstadoCita
    {
        Pendiente,
        Confirmada,
        Cancelada
    }

    public class Cita
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }    // Relación con Persona
        public int MedicoId { get; set; }      // Relación con Persona
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }
        public EstadoCita Estado { get; set; }
    }
}