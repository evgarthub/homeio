using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeIO.Startup))]
namespace HomeIO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
