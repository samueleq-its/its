using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrestitiVideoTecaWebForm.Startup))]
namespace PrestitiVideoTecaWebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
