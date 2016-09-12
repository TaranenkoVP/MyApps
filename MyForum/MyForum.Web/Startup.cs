using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyForum.Web.Startup))]
namespace MyForum.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
