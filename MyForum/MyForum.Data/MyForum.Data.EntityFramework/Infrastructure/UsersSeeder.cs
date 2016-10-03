using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Data.Core.Constants;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.EF.Infrastructure
{
    public class UsersSeeder
    {
        public void Seed(MyForumDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));

            userManager.Create(new ApplicationUser
            {
                UserName = AppConstants.GetConstant("MasterAdminUserName"),
                Email = AppConstants.GetConstant("MasterAdminEmail"),
                CreatedOn = DateTime.UtcNow,
                Photo = AppConstants.GetConstant("MasterAdminPhoto")
            },
                AppConstants.GetConstant("MasterAdminStartPassword"));

            roleManager.Create(new ApplicationRole { Name = AppConstants.GetConstant("MasterAdminRoleName")});
            roleManager.Create(new ApplicationRole { Name = AppConstants.GetConstant("ModeratorRoleName")});
            roleManager.Create(new ApplicationRole { Name = AppConstants.GetConstant("UserRoleName")});

            var masterAdminUserName = AppConstants.GetConstant("MasterAdminUserName");
            var admin = context.Users.FirstOrDefault(u => u.UserName == masterAdminUserName);

            userManager.AddToRole(admin.Id, AppConstants.GetConstant("MasterAdminRoleName"));
            userManager.AddToRole(admin.Id, AppConstants.GetConstant("ModeratorRoleName"));
            userManager.AddToRole(admin.Id, AppConstants.GetConstant("UserRoleName"));
        }
    }
}