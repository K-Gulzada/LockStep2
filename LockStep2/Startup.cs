using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LockStep2.Startup))]
namespace LockStep2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
