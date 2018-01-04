
using Microsoft.Owin;

[assembly: OwinStartup(typeof(JixhDb.Web.Startup))]
namespace JixhDb.Web
{
    using Owin;
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            ConfigureAuth(app);
        }

        
    }
}
