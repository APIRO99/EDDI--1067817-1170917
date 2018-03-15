using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project01.Startup))]
namespace Project01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
