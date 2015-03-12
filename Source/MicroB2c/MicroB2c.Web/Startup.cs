using Microsoft.Owin;
using Owin;
using MicroB2c.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace MicroB2c.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
