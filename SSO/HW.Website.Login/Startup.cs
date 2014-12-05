using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HW.Website.Login.Startup))]
namespace HW.Website.Login
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
