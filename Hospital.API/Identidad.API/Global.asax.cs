using Identidad.API.Commads;
using Identidad.API.Dto;
using Identidad.API.Infrastructure.Data;
using Identidad.API.Infrastructure.Interface;
using Identidad.API.Infrastructure.Repositories;
using Identidad.API.Infrastructure.Security;
using MediatR;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Identidad.API.Handlers;

namespace Identidad.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Registrar los controladores de Web API
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // Registrar dependencias
            RegisterDependencies(container);

            // Configurar el Dependency Resolver de Web API
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            // Registrar rutas y áreas
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void RegisterDependencies(Container container)
        {
            // Registrar repositorios e infraestructura
            container.Register<UsuariosContext>(Lifestyle.Scoped);
            container.Register<IUsuarioRepositorio, UsuarioRepositorio>(Lifestyle.Scoped);
            container.Register<ITokenServicio, TokenServicio>(Lifestyle.Scoped);

            // Registrar MediatR
            container.RegisterSingleton<IMediator, Mediator>();

            // Registrar la fábrica de servicios de MediatR
            container.Register<ServiceFactory>(() => t => container.GetInstance(t), Lifestyle.Singleton);

            // Registrar los handlers de MediatR
            container.Register<IRequestHandler<LoginUsuarioCommand, UsuarioDto>, LoginHandler>(Lifestyle.Scoped);

            // Registrar IPipelineBehavior para evitar error de colección vacía
            container.Collection.Register<IPipelineBehavior<LoginUsuarioCommand, UsuarioDto>>(Array.Empty<IPipelineBehavior<LoginUsuarioCommand, UsuarioDto>>());

            // Verificar configuraciones
            container.Verify();
        }
    }
    }
