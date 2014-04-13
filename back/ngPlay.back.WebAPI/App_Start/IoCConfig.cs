using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using ngPlay.back.Data;
using ngPlay.back.Data.Contracts;
using ngPlay.back.Domain.Contracts;
using ngPlay.back.Domain.Services;

namespace ngPlay.back.WebAPI
{
    public class IoCConfig
    {
        public static IContainer Container;

        public static void RegisterDependencies()
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register the Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register other dependencies.
            builder.RegisterType<AppLogService>().As<IAppLogService>().InstancePerApiRequest();
            builder.RegisterType<AppLogRepository>().As<IAppLogRepository>().InstancePerApiRequest();

            var dataContext = new NgPlayDataContext();

            builder.RegisterInstance(dataContext).AsSelf();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

            // Build the container.
            var container = builder.Build();
            Container = container;

            // Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}