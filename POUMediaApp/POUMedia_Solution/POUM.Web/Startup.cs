using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POUM.Web.Startup))]
namespace POUM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
