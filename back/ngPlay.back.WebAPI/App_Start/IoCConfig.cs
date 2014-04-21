﻿using Autofac;
using Autofac.Integration.WebApi;
using DotNetDoodle.Owin.Dependencies.Autofac;
using ngPlay.back.Data;
using ngPlay.back.Data.Contracts;
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
                builder.RegisterType<AppLogService>().As<IAppLogService>().InstancePerApiRequest();
                builder.RegisterType<AppLogRepository>().As<IAppLogRepository>().InstancePerApiRequest();

                builder.RegisterType<NgPlayDataContext>().AsSelf();
                builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

                _container = builder.Build();
            }

            return _container;
        }
    }
}