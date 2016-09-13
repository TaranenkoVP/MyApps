using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyForum.Web.MVC.Startup))]
namespace MyForum.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
