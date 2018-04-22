using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_001_Office.Startup))]
namespace Lab_001_Office
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
