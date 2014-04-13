using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ngPlay.back.WebAPI.Startup))]

namespace ngPlay.back.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
