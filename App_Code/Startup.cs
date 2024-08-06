using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Controle_de_Atletas.Startup))]
namespace Controle_de_Atletas
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
