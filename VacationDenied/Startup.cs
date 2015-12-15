using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VacationDenied.Startup))]
namespace VacationDenied
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
