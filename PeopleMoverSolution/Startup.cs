using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeopleMoverSolution.Startup))]
namespace PeopleMoverSolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
