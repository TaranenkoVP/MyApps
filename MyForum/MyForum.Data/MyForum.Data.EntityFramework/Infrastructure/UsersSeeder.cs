using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Data.Core.Models;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.EF.Infrastructure
{
    public class UsersSeeder
    {
        public void Seed(MyForumDbContext context)
        {
            var masterAdminUserName = "Administrator";
            
            var adminRoleName = "admin";
            var moderatorRoleName = "moderator";
            var userRoleName = "user";

            var isMasterAdminSeeded = context.Users.Any(u => u.UserName == masterAdminUserName);

            if (!isMasterAdminSeeded)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                userManager.Create(new ApplicationUser() { UserName = masterAdminUserName, Email = "Administrator@gmail.com", CreatedOn = DateTime.UtcNow, Photo = " /Content/Images/default_photo.png" }, "123456");

                roleManager.Create(new IdentityRole() { Name = adminRoleName });
                roleManager.Create(new IdentityRole() { Name = moderatorRoleName });
                roleManager.Create(new IdentityRole() { Name = userRoleName });

                var admin = context.Users.FirstOrDefault(u => u.UserName == masterAdminUserName);

                userManager.AddToRole(admin.Id, adminRoleName);
            }
        }
    }
}
