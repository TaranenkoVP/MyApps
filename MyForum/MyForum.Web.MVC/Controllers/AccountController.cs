using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Web.MVC.Models;

namespace MyForum.Web.MVC.Controllers
{
    //[Authorize]
    public class AccountController : BaseController
    {
        public AccountController(IUserService userService)
        {
            UserService = userService;
        }

        private IUserService UserService { get; }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userBusiness = Mapper.Map<UserBusiness>(model);

                var claim = await UserService.AuthenticateAsync(userBusiness);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Invalid username or password!");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home", new {area = string.Empty});
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var userBusiness = Mapper.Map<UserBusiness>(model);
                userBusiness.Roles = new List<string> {"User"};
                userBusiness.Photo = "/Content/Images/default_photo.png";
                OperationDetails operationDetails = null;
                try
                {
                    operationDetails = await UserService.CreateAsync(userBusiness);
                    if (operationDetails.Succedeed)
                    {
                        //SuccessRegister
                        return View("SuccessRegister");
                    }
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }
    }
}