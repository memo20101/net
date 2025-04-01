using AutoMapper;
using Personas.API.Domain.Entities;
using Personas.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<CrearPersonaDto, Persona>();
        }
    }
}