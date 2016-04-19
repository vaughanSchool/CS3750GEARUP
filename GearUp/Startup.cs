using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GearUp.Startup))]
namespace GearUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
