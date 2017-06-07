using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PoolManager.Startup))]
namespace PoolManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
