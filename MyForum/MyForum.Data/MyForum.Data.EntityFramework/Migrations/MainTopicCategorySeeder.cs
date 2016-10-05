using System;
using System.Linq;
using MyForum.Data.Core.Constants;
using MyForum.Data.Core.Models;
using MyForum.Data.EF.Infrastructure;

namespace MyForum.Data.EF.Migrations
{
    public class MainTopicCategorySeeder
    {
        public void Seed(MyForumDbContext context)
        {
            var masterAdminUserName = AppConstants.GetConstant("MasterAdminUserName");
            var author = context.Users.FirstOrDefault(u => u.UserName == masterAdminUserName);

            var mainCategory1 = new MainCategory
            {
                Name = "Client-Side Development",
                Description = "Discuss HTML, CSS, XML, JavaScript, and other client-side technologies",
                IsDeleted = false,
                ApplicationUser = author
            };

            var mainCategory2 = new MainCategory
            {
                Name = "Server-Side Development",
                Description = "Here is where we discuss the various back end scripting languages and their uses",
                IsDeleted = false,
                ApplicationUser = author
            };
            var mainCategory3 = new MainCategory
            {
                Name = "Site Management",
                Description = "Here ",
                IsDeleted = false,
                ApplicationUser = author
            };

            var mainCategory4 = new MainCategory
            {
                Name = "Etc.",
                Description = "This is where you can leave feedback or just chat about non-developer related topics.",
                IsDeleted = false,
                ApplicationUser = author
            };

            context.MainCategory.Add(mainCategory1);
            context.MainCategory.Add(mainCategory2);
            context.MainCategory.Add(mainCategory3);
            context.MainCategory.Add(mainCategory4);

            context.SaveChanges();

            // TODO: Remove in production

            var moderUserName = "Moder1";
            var authormoder = context.Users.FirstOrDefault(u => u.UserName == moderUserName);

            var user1Name = "User1";
            var authoruser1 = context.Users.FirstOrDefault(u => u.UserName == user1Name);

            var topicCategory1 = new TopicCategory
            {
                Name = "HTML",
                Description =
                    "Discussion and technical support for building, using and deploying HTML sites. For articles, check out our HTML5 Development Center.",
                ApplicationUser = author,
                MainCategory = mainCategory1,
                CreatedOn = DateTime.Now.AddHours(-1),
                IsDeleted = false
            };

            var topicCategory2 = new TopicCategory
            {
                Name = "XML",
                Description =
                    "Discussion and technical support for using and deploying XML applications and websites.",
                ApplicationUser = authormoder,
                MainCategory = mainCategory1,
                CreatedOn = DateTime.Now.AddHours(-2),
                IsDeleted = false
            };

            var topicCategory3 = new TopicCategory
            {
                Name = "PHP",
                Description = "Discussion and technical support for using and deploying PHP based websites.",
                ApplicationUser = author,
                MainCategory = mainCategory2,
                CreatedOn = DateTime.Now.AddHours(-1),
                IsDeleted = false
            };

            var topicCategory4 = new TopicCategory
            {
                Name = "Domain Names",
                Description = "Discussion of various issues involving domain names.",
                ApplicationUser = authormoder,
                MainCategory = mainCategory3,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            var topicCategory5 = new TopicCategory
            {
                Name = "Forum, Blog, Wiki & CMS",
                Description =
                    "Discuss the various forum/message board/blogging formats, customizations, settings, features, and troubleshooting here",
                ApplicationUser = author,
                MainCategory = mainCategory3,
                CreatedOn = DateTime.Now.AddHours(-7),
                IsDeleted = false
            };

            var topicCategory6 = new TopicCategory
            {
                Name = "Forum Feedback",
                Description = "If you have feedback about the forums, we'd love to read it!",
                ApplicationUser = authormoder,
                MainCategory = mainCategory4,
                CreatedOn = DateTime.Now.AddHours(-9),
                IsDeleted = false
            };

            var topicCategory7 = new TopicCategory
            {
                Name = "ASP.NET",
                Description = "Discussion and technical support for using and deploying ASP.NET based websites.",
                ApplicationUser = author,
                MainCategory = mainCategory2,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            context.TopicCategory.Add(topicCategory1);
            context.TopicCategory.Add(topicCategory2);
            context.TopicCategory.Add(topicCategory3);
            context.TopicCategory.Add(topicCategory4);
            context.TopicCategory.Add(topicCategory5);
            context.TopicCategory.Add(topicCategory6);
            context.TopicCategory.Add(topicCategory7);

            context.SaveChanges();

            var topic1 = new Topic
            {
                Title = "HTML",
                Content =
                    "Discussion and technical support for building, using and deploying HTML sites. For articles, check out our HTML5 Development Center.",
                ApplicationUser = author,
                TopicCategory = topicCategory1,
                CreatedOn = DateTime.Now.AddHours(-1),
                IsDeleted = false
            };

            var topic2 = new Topic
            {
                Title = "HTML",
                Content =
                    "Discussion and technical support for building, using and deploying HTML sites. For articles, check out our HTML5 Development Center.",
                ApplicationUser = authormoder,
                TopicCategory = topicCategory2,
                CreatedOn = DateTime.Now.AddHours(-3),
                IsDeleted = false
            };

            var topic3 = new Topic
            {
                Title = "Domain Names",
                Content = "Discussion of various issues involving domain names.",
                ApplicationUser = author,
                TopicCategory = topicCategory3,
                CreatedOn = DateTime.Now.AddHours(-3),
                IsDeleted = false
            };

            var topic4 = new Topic
            {
                Title = "Forum, Blog, Wiki & CMS",
                Content =
                    "Discuss the various forum / message board / blogging formats,customizations,settings,features,and troubleshooting here",
                ApplicationUser = authormoder,
                TopicCategory = topicCategory3,
                CreatedOn = DateTime.Now.AddHours(-1),
                IsDeleted = false
            };

            var topic5 = new Topic
            {
                Title = "The Coffee Lounge",
                Content = "Relax and discuss the latest topics of the day.",
                ApplicationUser = author,
                TopicCategory = topicCategory4,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            context.Topic.Add(topic1);
            context.Topic.Add(topic2);
            context.Topic.Add(topic3);
            context.Topic.Add(topic4);
            context.Topic.Add(topic5);

            context.SaveChanges();

            var post1 = new Post
            {
                Content = "getElementByID and iFrames",
                ApplicationUser = author,
                Topic = topic1,
                CreatedOn = DateTime.Now.AddHours(-1),
                IsDeleted = false
            };

            var post2 = new Post
            {
                Content = "Extend Site to Fill Screen",
                ApplicationUser = authormoder,
                Topic = topic2,
                CreatedOn = DateTime.Now.AddHours(-3),
                IsDeleted = false
            };

            var post3 = new Post
            {
                Content = "getElementByID and iFrames user",
                ApplicationUser = authoruser1,
                Topic = topic1,
                CreatedOn = DateTime.Now.AddHours(-1),
                IsDeleted = false
            };

            var post4 = new Post
            {
                Content = "Extend Site to Fill Screen",
                ApplicationUser = author,
                Topic = topic3,
                CreatedOn = DateTime.Now.AddHours(-3),
                IsDeleted = false
            };

            context.Post.Add(post1);
            context.Post.Add(post2);
            context.Post.Add(post3);
            context.Post.Add(post4);

            context.SaveChanges();
        }
    }
}