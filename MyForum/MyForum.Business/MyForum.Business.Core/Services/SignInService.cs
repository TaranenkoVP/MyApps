using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using MyForum.Business.Core.Services.Common;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common;

namespace MyForum.Business.Core.Services
{
   // public class SignInService : BaseService, ISignInService
   // {
        //public SignInService(IUnitOfWork uow, IAuthenticationManager authenticationManager)
        //    : base(uow)
        //{
            //SignInManager = new ApplicationSignInManager(uow.UserManager, authenticationManager);

            // public SignInManager SignInManager
            //{
            //public async Task<IList<UserLoginInfo>> PasswordSignInAsync(string userId)
            //{
            //    var logins = await Database.UserManager.GetLoginsAsync(userId);
            //    return logins;
            //}
       // }
        //public ApplicationSignInManager SignInManager { get; }
    //}
}
