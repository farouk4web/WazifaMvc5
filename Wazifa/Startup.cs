using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wazifa.Startup))]
namespace Wazifa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
