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

                userManager.Create(new ApplicationUser() { UserName = authorUserName, Email = authorUserName, CreatedOn = DateTime.UtcNow, Photo = "/Content/Images/default_photo.png" }, "123456");

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

                var topicCategory3 = new TopicCategory()
                {
                    Name = "PHP",
                    Description = "Discussion and technical support for using and deploying PHP based websites.",
                    Author = author,
                    MainCategory = mainCategory2,
                    CreatedOn = DateTime.Now.AddHours(-1)
                };

                var topicCategory4 = new TopicCategory()
                {
                    Name = "Domain Names",
                    Description = "Discussion of various issues involving domain names.",
                    Author = author,
                    MainCategory = mainCategory3,
                    CreatedOn = DateTime.Now
                };

                var topicCategory5 = new TopicCategory()
                {
                    Name = "Forum, Blog, Wiki & CMS",
                    Description = "Discuss the various forum/message board/blogging formats, customizations, settings, features, and troubleshooting here",
                    Author = author,
                    MainCategory = mainCategory3,
                    CreatedOn = DateTime.Now.AddHours(-7)
                };

                var topicCategory6 = new TopicCategory()
                {
                    Name = "Forum Feedback",
                    Description = "If you have feedback about the forums, we'd love to read it!",
                    Author = author,
                    MainCategory = mainCategory4,
                    CreatedOn = DateTime.Now.AddHours(-9)
                };

                var topicCategory7 = new TopicCategory()
                {
                    Name = "ASP.NET",
                    Description = "Discussion and technical support for using and deploying ASP.NET based websites.",
                    Author = author,
                    MainCategory = mainCategory2,
                    CreatedOn = DateTime.Now
                };

                context.TopicCategory.Add(topicCategory1);
                context.TopicCategory.Add(topicCategory2);
                context.TopicCategory.Add(topicCategory3);
                context.TopicCategory.Add(topicCategory4);
                context.TopicCategory.Add(topicCategory5);
                context.TopicCategory.Add(topicCategory6);
                context.TopicCategory.Add(topicCategory7);

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

                var topic3 = new Topic()
                {
                    Title = "Domain Names",
                    Content ="Discussion of various issues involving domain names.",
                    Author = author,
                    TopicCategory = topicCategory3,
                    CreatedOn = DateTime.Now.AddHours(-3)
                };

                var topic4 = new Topic()
                {
                    Title = "Forum, Blog, Wiki & CMS",
                    Content = "Discuss the various forum / message board / blogging formats,customizations,settings,features,and troubleshooting here",
                    Author = author,
                    TopicCategory = topicCategory3,
                    CreatedOn = DateTime.Now.AddHours(-1)
                };

                var topic5 = new Topic()
                {
                    Title = "The Coffee Lounge",
                    Content = "Relax and discuss the latest topics of the day.",
                    Author = author,
                    TopicCategory = topicCategory4,
                    CreatedOn = DateTime.Now
                };

                context.Topic.Add(topic1);
                context.Topic.Add(topic2);
                context.Topic.Add(topic3);
                context.Topic.Add(topic4);
                context.Topic.Add(topic5);

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

                var post3 = new Post()
                {
                    Content = "getElementByID and iFrames",
                    Author = author,
                    Topic = topic1,
                    CreatedOn = DateTime.Now.AddHours(-1)
                };

                var post4 = new Post()
                {
                    Content = "Extend Site to Fill Screen",
                    Author = author,
                    Topic = topic3,
                    CreatedOn = DateTime.Now.AddHours(-3)
                };

                context.Post.Add(post1);
                context.Post.Add(post2);
                context.Post.Add(post3);
                context.Post.Add(post4);

                context.SaveChanges();
            }
        }
    }
}
