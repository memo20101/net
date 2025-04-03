using AutoMapper;
using Citas.API.Commands;
using Citas.API.Domain.Entities;
using Citas.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.API.Infrastructure.Mappings
{
    public class CitaMappingProfile : Profile
    {
        public CitaMappingProfile()
        {
            // Mapeo desde la entidad Cita al DTO
            CreateMap<Cita, CitaDto>()
                .ForMember(dest => dest, opt => opt.MapFrom(src => src.Estado.ToString()));

            // Mapeo desde los commands a la entidad Cita
            CreateMap<ProgramarCitaCommand, Cita>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(_ => EstadoCita.Pendiente));

            CreateMap<ActualizarCitaCommand, Cita>()
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.PacienteId, opt => opt.Ignore())
                .ForMember(dest => dest.MedicoId, opt => opt.Ignore());
        }
    }
}