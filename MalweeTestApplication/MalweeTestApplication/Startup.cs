using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MalweeTestApplication.Startup))]
namespace MalweeTestApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
