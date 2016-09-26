using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyForum.Web.MVC.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Interfaces;

namespace MyForum.Web.MVC.Controllers
{
    //[Authorize]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        private IUserService UserService
        {
            get { return _userService; }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userBusiness = Mapper.Map<UserBusiness>(model);

                ClaimsIdentity claim = await UserService.Authenticate(userBusiness);
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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userBusiness = Mapper.Map<UserBusiness>(model);

                userBusiness.Role = "user";

                OperationDetails operationDetails = await UserService.Create(userBusiness);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
    }
}