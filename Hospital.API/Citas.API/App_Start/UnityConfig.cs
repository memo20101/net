using AutoMapper;
using Citas.API.Domain.Interfaces;
using Citas.API.Infrastructure.Data;
using Citas.API.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity.Lifetime;
using Unity;
using Citas.API.Infrastructure.Mappings;
using Citas.API.Infrastructure;

namespace Citas.API.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Registros
            container.RegisterType<ICitaRepository, CitaRepository>();
            container.RegisterType<ICitaUnitOfWork, CitaUnitOfWork>();
            container.RegisterType<CitasContext>();

            // AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            container.RegisterInstance(mapper);

            // ✅ Aquí inyectamos el UnityResolver en lugar de usar el paquete NuGet
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}