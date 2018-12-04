using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManageMyChild.Startup))]
namespace ManageMyChild
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
