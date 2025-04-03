using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.Commands
{
    public class CrearRecetaCommand : IRequest<int>
    {
        public int CitaId { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string Medicamentos { get; set; }
        public string Instrucciones { get; set; }
        public string Observaciones { get; set; }
        public int? DiasValidez { get; set; }
    }
}