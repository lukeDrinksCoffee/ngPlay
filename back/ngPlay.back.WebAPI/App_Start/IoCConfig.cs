using Autofac;
using Autofac.Integration.WebApi;
using DotNetDoodle.Owin.Dependencies.Autofac;
using ngPlay.back.Data;
using ngPlay.back.Data.Contracts;
using ngPlay.back.Domain;
using ngPlay.back.Domain.Contracts;
using ngPlay.back.Domain.Services;
using System.Reflection;

namespace ngPlay.back.WebAPI
{
    public class IoCConfig
    {
        private static IContainer _container;

        public static IContainer GetContainer()
        {
            if (_container == null)
            {
                // Create the container builder.
                var builder = new ContainerBuilder();

                // Register the Web API controllers.
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
                builder.RegisterOwinApplicationContainer();

                // Register other dependencies.
                builder.RegisterType<NgPlayDataContext>().AsSelf();

                builder.RegisterType<AppLogRepository>().As<IAppLogRepository>().InstancePerApiRequest();
                builder.RegisterType<AppLogService>().As<IAppLogService>().InstancePerApiRequest();

                builder.RegisterType<UserRepository>().As<IUserRepository>();
                builder.RegisterType<UserService>().As<IUserService>().InstancePerApiRequest();

                builder.RegisterType<NoteRepository>().As<INoteRepository>().InstancePerApiRequest();
                builder.RegisterType<NoteService>().As<INoteService>().InstancePerApiRequest();

                _container = builder.Build();
            }

            return _container;
        }
    }
}