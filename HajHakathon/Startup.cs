using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HajHakathon.Startup))]
namespace HajHakathon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
