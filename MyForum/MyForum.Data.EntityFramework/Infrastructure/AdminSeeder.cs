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
    public class AdminSeeder
    {
        public void Seed(MyForumDbContext context)
        {
            var masterAdminUserName = "MasterAdmin@gmail.com";

            var roleName = "admin";

            var isMasterAdminSeeded = context.Users.Any(u => u.UserName == masterAdminUserName);

            if (!isMasterAdminSeeded)
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                userManager.Create(new User() { UserName = masterAdminUserName, Email = masterAdminUserName, CreatedOn = DateTime.UtcNow, Photo = "http://cdn2.hubspot.net/hub/245562/file-306538470-png/v3/ninja2.png?t=1453934745802" }, "123456");

                roleManager.Create(new IdentityRole() { Name = roleName });

                var admin = context.Users.FirstOrDefault(u => u.UserName == masterAdminUserName);

                userManager.AddToRole(admin.Id, roleName);
            }
        }
    }
}
