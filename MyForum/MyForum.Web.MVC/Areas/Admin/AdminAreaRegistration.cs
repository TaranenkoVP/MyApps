using System.Web.Mvc;

namespace MyForum.Web.MVC.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //context.MapRoute(
            //    "Admin_LogOut", 
            //    "Admin/Account/Logout",
            //    new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            //    );

            context.MapRoute(
                    "Admin_defaultnew",
                    "Admin/{controller}/{action}/{id}",
                    new { action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}