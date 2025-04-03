using AutoMapper;
using Personas.API.Commands;
using Personas.API.Domain.Entities;
using Personas.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.API.Infrastructure.Mappings
{
    public class PersonaMappingProfile : Profile
    {
        public PersonaMappingProfile()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<CreatePersonaCommand, Persona>();
            CreateMap<UpdatePersonaCommand, Persona>()
                .ForMember(dest => dest.Tipo, opt => opt.Ignore())
                .ForMember(dest => dest.NumeroIdentificacion, opt => opt.Ignore());
        }
    }
}