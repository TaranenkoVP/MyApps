using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Common;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Business.Core.Services
{
    public class UserService : EntityService, IUserService
    {
        public UserService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(string userId)
        {
            var logins = await Database.UserManager.GetLoginsAsync(userId);
            return logins;
        }

        public async Task<OperationDetails> CreateAsync(UserBusiness userBusiness)
        {
            var user = await Database.UserManager.FindByNameAsync(userBusiness.UserName);
            if (user == null)
            {
                //var roles =new List<IdentityRole> { new IdentityRole("user") };
                user = new ApplicationUser { CreatedOn = DateTime.Now, IsDeleted = false };
                Mapper.Map(userBusiness, user);
                user.LockoutEnabled = true;
                var result = await Database.UserManager.CreateAsync(user, userBusiness.Password);
                if (result.Succeeded)
                    await Database.UserManager.AddToRoleAsync(user.Id, "User");
                // adding roles
                await Database.CommitAsync();
                return new OperationDetails(true, "Your registration has been successfully completed", "");
            }
            return new OperationDetails(false, "A user with this login is already exists","");
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(UserBusiness userBusiness)
        {
            ClaimsIdentity claim = null;
            // user search
            var user = await Database.UserManager.FindAsync(userBusiness.UserName, userBusiness.Password);
            // authorizing him, and return the object ClaimsIdentity
            if (user != null)
            {
                claim =
                    await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }

        public async Task<UserBusiness> FindByIdAsync(string userId)
        {
            var user = await Database.UserManager.FindByIdAsync(userId);
            var userBusiness = Mapper.Map<UserBusiness>(user);
            return userBusiness;
        }

    }
}