using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataSubmission.Startup))]
namespace DataSubmission
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
