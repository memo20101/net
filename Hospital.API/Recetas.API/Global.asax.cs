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

namespace Recetas.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });


            builder.RegisterType<CitasContext>().InstancePerLifetimeScope();
            builder.RegisterType<CitaRepository>().As<ICitaRepository>().InstancePerLifetimeScope();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CitaMappingProfile>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(typeof(ProgramarCitaHandler).Assembly)
                  .AsClosedTypesOf(typeof(IRequestHandler<,>))
                  .InstancePerLifetimeScope();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
