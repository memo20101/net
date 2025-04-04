using Autofac;
using AutoMapper;
using System.Reflection;
using System.Web.Http;
using Autofac.Integration.WebApi;
using AutoMapper;
using MediatR;
using System.Reflection;
using System.Web.Http;
using Citas.API.Infrastructure.Data;
using Citas.API.Infrastructure.Repositories;
using Citas.API.Domain.Interfaces;
using Citas.API.Infrastructure.Mappings;
using Citas.API.Handlers;
using Recetas.API.Domain.Interfaces;
using Recetas.API.Handlers;
using Recetas.API.Infrastructure.Data;
using Recetas.API.Infrastructure.Mappings;
using Recetas.API.Infrastructure.Repositories;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(Recetas.API.App_Start.Startup))]
namespace Recetas.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            // 1. Registrar controladores API
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // 2. Configurar MediatR (igual que en los otros microservicios)
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            // 3. Registrar repositorios y contexto
            builder.RegisterType<RecetasContext>().InstancePerLifetimeScope();
            builder.RegisterType<RecetaRepository>().As<IRecetaRepository>().InstancePerLifetimeScope();

            // 4. Configurar AutoMapper
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RecetaMappingProfile>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            // 5. Registrar todos los handlers
            builder.RegisterAssemblyTypes(typeof(CrearRecetaHandler).Assembly)
                  .AsClosedTypesOf(typeof(IRequestHandler<,>))
                  .InstancePerLifetimeScope();

            // Construir el contenedor y configurar Web API
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
