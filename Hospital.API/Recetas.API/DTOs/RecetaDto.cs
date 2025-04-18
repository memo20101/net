﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.DTOs
{
    public class RecetaDto
    {
        public int Id { get; set; }
        public int CitaId { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string FechaEmision { get; set; }
        public string FechaVencimiento { get; set; }
        public string Estado { get; set; }
        public string Medicamentos { get; set; }
        public string Instrucciones { get; set; }
        public string Observaciones { get; set; }
    }
}