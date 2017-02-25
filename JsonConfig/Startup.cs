using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JsonConfig.Startup))]
namespace JsonConfig
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
