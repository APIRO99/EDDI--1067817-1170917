using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab1_1170917.Startup))]
namespace Lab1_1170917
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
