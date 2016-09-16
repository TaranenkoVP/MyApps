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
    public class TopicCategorySeeder
    {
        public static Random Rand = new Random();

        public void Seed(MyForumDbContext context)
        {
            var authorUserName = "MainAdmin@gmail.com";

            var isAuthorSeeded = context.Users.Any(u => u.UserName == authorUserName);

            if (!isAuthorSeeded)
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                userManager.Create(new User() { UserName = authorUserName, Email = authorUserName, CreatedOn = DateTime.UtcNow, Photo = "http://cdn2.hubspot.net/hub/245562/file-306538470-png/v3/ninja2.png?t=1453934745802" }, "123456");

                var author = context.Users.FirstOrDefault(u => u.UserName == authorUserName);

                var categories = new List<TopicCategory>
                {
                    new TopicCategory() { Name = "C#" , Description = "Here you can ask questions and find answers about programming with C#."},
                    new TopicCategory() { Name = "JavaScript", Description = "Here you can ask questions and find answers about programming with JavaScript." },
                    new TopicCategory() { Name = "Java", Description = "Here you can ask questions and find answers about programming with Java." },
                    new TopicCategory() { Name = "SQL", Description = "Here you can ask questions and find answers about programming with SQL." },
                    new TopicCategory() { Name = "HTML", Description = "Here you can ask questions and find answers about programming with HTML." },
                    new TopicCategory() { Name = "CSS", Description = "Here you can ask questions and find answers about programming with CSS." }
                };

                foreach (var item in categories)
                {
                    context.TopicCategory.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
