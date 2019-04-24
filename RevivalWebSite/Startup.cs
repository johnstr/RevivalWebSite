using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RevivalWebSite.Startup))]
namespace RevivalWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
