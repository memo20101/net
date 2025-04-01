using AutoMapper;
using Personas.API.Domain.Interfaces;
using Personas.API.Infrastructure.Data;
using Personas.API.Infrastructure.Mappings;
using Personas.API.Infrastructure.Repositories;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;


namespace Personas.API.App_Start
{
    public static class UnityConfig
    {
        // Exponemos el contenedor para MVC y otros usos
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Registro de servicios/repositorios/contextos
            container.RegisterType<IPersonaRepository, PersonaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<PersonasContext>(new HierarchicalLifetimeManager());

            // AutoMapper Profile
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            container.RegisterInstance(mapper);

            // Asignamos el container a la propiedad pública
            Container = container;

            // Para Web API
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}