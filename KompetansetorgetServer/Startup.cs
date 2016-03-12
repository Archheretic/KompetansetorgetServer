using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KompetansetorgetServer.Startup))]
namespace KompetansetorgetServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
