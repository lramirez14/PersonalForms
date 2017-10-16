using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalForms.Startup))]
namespace PersonalForms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
