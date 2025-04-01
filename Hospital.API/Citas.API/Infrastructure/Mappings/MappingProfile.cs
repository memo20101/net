using AutoMapper;
using Citas.API.Domain.Entities;
using Citas.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.API.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo de Cita a CitaDto (para GET)
            CreateMap<Cita, CitaDTO>();

            // Mapeo de CitaDto a Cita (opcional, si quieres actualizar/crear desde el DTO)
            CreateMap<CitaDTO, Cita>();

            // Mapeo de CrearCitaDto a Cita (para POST)
            CreateMap<CrearCitaDTO, Cita>();
        }
    }
}