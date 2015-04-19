using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_GuateFinanzas.Startup))]
namespace Project_GuateFinanzas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
