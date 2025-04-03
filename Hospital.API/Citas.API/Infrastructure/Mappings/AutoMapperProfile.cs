using AutoMapper;
using Citas.API.Domain.Entities;
using Citas.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.API.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cita, CitaDto>();
            CreateMap<CitaDto, Cita>();
            // Agrega más mapeos según necesites
        }
    }
}