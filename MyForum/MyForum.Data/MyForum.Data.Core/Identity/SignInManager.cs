using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.Core.Identity
{
    //public class SignInManager : SignInManager<ApplicationUser, string>
    //{
    //    public SignInManager(UserManager userManager, IAuthenticationManager authenticationManager)
    //        : base(userManager, authenticationManager)
    //    {
    //    }

    //    public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
    //    {
    //        return user.GenerateUserIdentityAsync((UserManager)UserManager);
    //    }

    //    public static SignInManager Create(IdentityFactoryOptions<SignInManager> options, IOwinContext context)
    //    {
    //        return new SignInManager(context.GetUserManager<UserManager>(), context.Authentication);
    //    }
    //}
}
