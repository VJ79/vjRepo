using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HW.Website.LogTest.Startup))]
namespace HW.Website.LogTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
