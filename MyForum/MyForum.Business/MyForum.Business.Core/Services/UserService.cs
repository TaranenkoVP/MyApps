using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Business.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _database;

        public UserService(IUnitOfWork uow)
        {
            _database = uow;
        }

        public async Task<OperationDetails> Create(UserBusiness userBusiness)
        {
            var user = await _database.UserManager.FindByEmailAsync(userBusiness.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userBusiness.Email, UserName = userBusiness.Email };
                await _database.UserManager.CreateAsync(user, userBusiness.Password);
                // adding role
                await _database.UserManager.AddToRoleAsync(user.Id, userBusiness.Role);

                _database.Commit();
                return new OperationDetails(true, "Your registration has been successfully completed", "");
            }
            else
            {
                return new OperationDetails(false, "A user with this login already exists", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserBusiness userBusiness)
        {
            ClaimsIdentity claim = null;
            // user search
            var user = await _database.UserManager.FindAsync(userBusiness.Email, userBusiness.Password);
            // authorizing him, and return the object ClaimsIdentity
            if (user != null)
            {
                claim = await _database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }

        // initialization DB
        public async Task SetInitialData(UserBusiness adminDto, List<string> roles)
        {
            foreach (var roleName in roles)
            {
                var role = await _database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await _database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
