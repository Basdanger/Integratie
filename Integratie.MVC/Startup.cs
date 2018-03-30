using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Integratie.MVC.Startup))]
namespace Integratie.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
