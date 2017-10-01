using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LogInEx1.Startup))]
namespace LogInEx1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
