using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Telcel.R9.Estructura.Presentacion.Startup))]
namespace Telcel.R9.Estructura.Presentacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
