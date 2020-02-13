using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aspire1.Startup))]
namespace aspire1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
