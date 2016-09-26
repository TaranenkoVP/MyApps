using System;
using MyForum.Web.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using MyForum.Business.Core.Services.Interfaces;
using Owin;

[assembly: OwinStartup(typeof(MyForum.Web.MVC.Startup))]

namespace MyForum.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.CreatePerOwinContext<IUserService>(userService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        //private IUserService CreateUserService()
        //{
        //    return serviceCreator.CreateUserService("DefaultConnection");
        //}
    }
}