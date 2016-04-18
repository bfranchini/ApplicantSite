using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApplicantSite.Startup))]
namespace ApplicantSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
