using Autofac.Integration.WebApi;
using DotNetDoodle.Owin;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(ngPlay.back.WebAPI.Startup))]

namespace ngPlay.back.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Share DI between OWIN and WebApi
            var container = IoCConfig.GetContainer();

            app.UseAutofacContainer(container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            ConfigureAuth(app);

            ConfigureJsonSerialization();
        }

        private void ConfigureJsonSerialization()
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
