using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Data.Core.Constants;
using MyForum.Data.Core.Models.Identity;
using MyForum.Data.EF.Infrastructure;

namespace MyForum.Data.EF.Migrations
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

            // TODO: Remove in production
            
            //moder

            userManager.Create(new ApplicationUser
            {
                UserName = "Moder1",
                Email = "moder1@gmail.com",
                CreatedOn = DateTime.UtcNow,
                Photo = AppConstants.GetConstant("ModeratorRoleName")
            },
            AppConstants.GetConstant("MasterAdminStartPassword"));

            var moder1 = context.Users.FirstOrDefault(u => u.UserName == "Moder1");
            userManager.AddToRole(moder1.Id, AppConstants.GetConstant("ModeratorRoleName"));
            userManager.AddToRole(moder1.Id, AppConstants.GetConstant("UserRoleName"));
            
            //user

            userManager.Create(new ApplicationUser
            {
                UserName = "User1",
                Email = "user1@gmail.com",
                CreatedOn = DateTime.UtcNow,
                Photo = AppConstants.GetConstant("MasterAdminPhoto")
            },
            AppConstants.GetConstant("MasterAdminStartPassword"));

            var user1 = context.Users.FirstOrDefault(u => u.UserName == "User1");
            userManager.AddToRole(user1.Id, AppConstants.GetConstant("UserRoleName"));
            context.SaveChanges();
        }
    }
}