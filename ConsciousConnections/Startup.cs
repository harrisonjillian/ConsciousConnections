using ConsciousConnections.Data;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConsciousConnections.Startup))]
namespace ConsciousConnections
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
