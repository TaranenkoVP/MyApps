using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyForum.Business.Core.Services.Interfaces;
using Microsoft.Owin.Security;
using MyForum.Web.MVC.Controllers;

namespace MyForum.Web.MVC.Areas.Admin.Controllers
{
    //[Authorize(Roles = "admin")]
    //public class AdminAccountController : BaseController
    //{
    //    private readonly IUserService _userService;

    //    public AdminAccountController(IUserService userService)
    //    {
    //        _userService = userService;
    //    }

    //    private IAuthenticationManager AuthenticationManager
    //    {
    //        get { return HttpContext.GetOwinContext().Authentication; }
    //    }

    //    public ActionResult Logout()
    //    {
    //        AuthenticationManager.SignOut();
    //        return RedirectToAction("Index", "Home", new { area = string.Empty });
    //    }
    //}
}