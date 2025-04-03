using AutoMapper;
using Recetas.API.Commands;
using Recetas.API.Domain.Entities;
using Recetas.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.Infrastructure.Mappings
{
    public class RecetaMappingProfile : Profile
    {
        public RecetaMappingProfile()
        {
            // Mapeo de Entidad a DTO
            CreateMap<Receta, RecetaDto>()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()))
                .ForMember(dest => dest.FechaEmision, opt => opt.MapFrom(src => src.FechaEmision.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.FechaVencimiento, opt => opt.MapFrom(src => src.FechaVencimiento.HasValue ?
                    src.FechaVencimiento.Value.ToString("yyyy-MM-dd") : null));

            // Mapeo de Command a Entidad
            CreateMap<CrearRecetaCommand, Receta>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(_ => EstadoReceta.Activa))
                .ForMember(dest => dest.FechaEmision, opt => opt.MapFrom(_ => DateTime.UtcNow));
        }
    }
}