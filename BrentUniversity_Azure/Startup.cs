using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrentUniversity_Azure.Startup))]
namespace BrentUniversity_Azure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
