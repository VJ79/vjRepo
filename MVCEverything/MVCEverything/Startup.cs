using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCEverything.Startup))]
namespace MVCEverything
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
