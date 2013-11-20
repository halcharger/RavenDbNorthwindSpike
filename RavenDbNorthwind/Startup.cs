using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RavenDbNorthwind.Startup))]
namespace RavenDbNorthwind
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
