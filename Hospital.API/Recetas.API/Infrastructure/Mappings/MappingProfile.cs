using AutoMapper;
using Recetas.API.Domain.Entities;
using Recetas.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Receta, RecetaDto>();
            CreateMap<CrearRecetaDto, Receta>();
        }
    }
}