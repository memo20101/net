
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Citas.API.Domain.Interfaces;
using Citas.API.Handlers;
using Citas.API.Infrastructure.Data;
using Citas.API.Infrastructure.Mappings;
using Citas.API.Infrastructure.Repositories;
using MediatR;
using Microsoft.Owin;
using System.Reflection;
using System.Web.Http;
[assembly: OwinStartup(typeof(Citas.API.App_Start.Startup))]
namespace Citas.API
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
            builder.RegisterType<CitasContext>().InstancePerLifetimeScope();
            builder.RegisterType<CitaRepository>().As<ICitaRepository>().InstancePerLifetimeScope();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CitaMappingProfile>(); // Asegúrate de tener un perfil de mapeo
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            // REGISTRAR HANDLERS
            builder.RegisterAssemblyTypes(typeof(ProgramarCitaHandler).Assembly)
                  .AsClosedTypesOf(typeof(IRequestHandler<,>))
                  .InstancePerLifetimeScope();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }

    }
}
