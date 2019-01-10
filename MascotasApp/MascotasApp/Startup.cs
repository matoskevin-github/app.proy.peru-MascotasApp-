using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MascotasApp.Startup))]
namespace MascotasApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
