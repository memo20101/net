

using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using MediatR;
using Microsoft.Owin;
using Personas.API.Domain.Interfaces;
using Personas.API.Handlers;
using Personas.API.Infrastructure.Data;
using Personas.API.Infrastructure.Mappings;
using Personas.API.Infrastructure.Repositories;
using System.Reflection;
using System.Web.Http;
[assembly: OwinStartup(typeof(Personas.API.App_Start.Startup))]
namespace Personas.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            // REGISTRAR CONTROLADORES
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // REGISTRAR MEDIATOR
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            // REGISTRAR REPOSITORIOS Y SERVICIOS
            builder.RegisterType<PersonasContext>().InstancePerLifetimeScope();
            builder.RegisterType<PersonaRepository>().As<IPersonaRepository>().InstancePerLifetimeScope();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PersonaMappingProfile>(); // Asegúrate de tener un perfil de mapeo
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            // REGISTRAR HANDLERS
            builder.RegisterAssemblyTypes(typeof(CreatePersonaHandler).Assembly)
                  .AsClosedTypesOf(typeof(IRequestHandler<,>))
                  .InstancePerLifetimeScope();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
