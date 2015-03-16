using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(A11_RBS.Startup))]
namespace A11_RBS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
