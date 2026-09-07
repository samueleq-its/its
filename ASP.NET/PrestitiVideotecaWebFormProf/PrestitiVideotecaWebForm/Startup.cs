using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrestitiVideotecaWebForm.Startup))]
namespace PrestitiVideotecaWebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
