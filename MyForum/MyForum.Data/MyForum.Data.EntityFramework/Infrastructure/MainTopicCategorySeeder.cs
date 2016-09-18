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
    public class MainTopicCategorySeeder
    {
        public static Random Rand = new Random();

        public void Seed(MyForumDbContext context)
        {
            var authorUserName = "MainAdmin@gmail.com";

            var isAuthorSeeded = context.Users.Any(u => u.UserName == authorUserName);

            if (!isAuthorSeeded)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                userManager.Create(new ApplicationUser() { UserName = authorUserName, Email = authorUserName, CreatedOn = DateTime.UtcNow, Photo = "http://cdn2.hubspot.net/hub/245562/file-306538470-png/v3/ninja2.png?t=1453934745802" }, "123456");

                var author = context.Users.FirstOrDefault(u => u.UserName == authorUserName);

                var mainCategory1 = new MainCategory()
                {
                    Name = "Client-Side Development",
                    Description = "Discuss HTML, CSS, XML, JavaScript, and other client-side technologies"
                };
                var mainCategory2 = new MainCategory()
                {
                    Name = "Server-Side Development",
                    Description = "Here is where we discuss the various back end scripting languages and their uses"
                };
                var mainCategory3 = new MainCategory()
                {
                    Name = "Site Management",
                    Description = "Here "
                };

                var mainCategory4 = new MainCategory()
                {
                    Name = "Etc.",
                    Description = "This is where you can leave feedback or just chat about non-developer related topics."
                };

                context.MainCategory.Add(mainCategory1);
                context.MainCategory.Add(mainCategory2);
                context.MainCategory.Add(mainCategory3);
                context.MainCategory.Add(mainCategory4);

                context.SaveChanges();

                // TODO: Remove in production

                var topicCategory1 = new TopicCategory()
                {
                    Name = "HTML",
                    Description =
                        "Discussion and technical support for building, using and deploying HTML sites. For articles, check out our HTML5 Development Center.",
                    Author = author,
                    MainCategory = mainCategory1,
                    CreatedOn = DateTime.Now.AddHours(-1)
                };

                var topicCategory2 = new TopicCategory()
                {
                    Name = "XML",
                    Description =
                        "Discussion and technical support for using and deploying XML applications and websites.",
                    Author = author,
                    MainCategory = mainCategory1,
                    CreatedOn = DateTime.Now.AddHours(-2)
                };
                context.TopicCategory.Add(topicCategory1);
                context.TopicCategory.Add(topicCategory2);

                context.SaveChanges();

                var topic1 = new Topic()
                {
                    Title = "HTML",
                    Content =
                        "Discussion and technical support for building, using and deploying HTML sites. For articles, check out our HTML5 Development Center.",
                    Author = author,
                    TopicCategory = topicCategory1,
                    CreatedOn = DateTime.Now.AddHours(-1)
                };

                var topic2 = new Topic()
                {
                    Title = "HTML",
                    Content =
                        "Discussion and technical support for building, using and deploying HTML sites. For articles, check out our HTML5 Development Center.",
                    Author = author,
                    TopicCategory = topicCategory2,
                    CreatedOn = DateTime.Now.AddHours(-3)
                };

                context.Topic.Add(topic1);
                context.Topic.Add(topic2);

                context.SaveChanges();

                var post1 = new Post()
                {
                    Content = "getElementByID and iFrames",
                    Author = author,
                    Topic = topic1,
                    CreatedOn = DateTime.Now.AddHours(-1)
                };

                var post2 = new Post()
                {
                    Content = "Extend Site to Fill Screen",
                    Author = author,
                    Topic = topic2,
                    CreatedOn = DateTime.Now.AddHours(-3)
                };

                context.Post.Add(post1);
                context.Post.Add(post2);

                context.SaveChanges();
            }
        }
    }
}
