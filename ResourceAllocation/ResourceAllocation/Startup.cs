using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResourceAllocation.Startup))]
namespace ResourceAllocation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
