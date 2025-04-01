using AutoMapper;
using Recetas.API.Infrastructure.Data;
using Recetas.API.Infrastructure.Mappings;
using Recetas.API.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Recetas.API.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IRecetaRepository, RecetaRepository>();
            container.RegisterType<IRecetaUnitOfWork, RecetaUnitOfWork>();
            container.RegisterType<RecetasContext>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            container.RegisterInstance(mapper);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}