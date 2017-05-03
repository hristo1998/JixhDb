using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JixhDb.Web.Startup))]
namespace JixhDb.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
