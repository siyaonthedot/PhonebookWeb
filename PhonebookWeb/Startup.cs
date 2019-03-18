using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhonebookWeb.Startup))]
namespace PhonebookWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
