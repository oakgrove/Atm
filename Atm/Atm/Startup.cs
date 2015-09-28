using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Atm.Startup))]
namespace Atm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
