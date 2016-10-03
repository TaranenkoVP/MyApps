using System.Data.Entity.Migrations;
using System.Linq;
using MyForum.Data.Core.Constants;

namespace MyForum.Data.EF.Infrastructure
{
    public sealed class Configuration : DbMigrationsConfiguration<MyForumDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            // TODO: Remove in production
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyForumDbContext context)
        {
            var masterAdminUserName = AppConstants.GetConstant("MasterAdminUserName");
            var isMasterAdminSeeded = context.Users.Any(u => u.UserName == masterAdminUserName);

            if (!isMasterAdminSeeded)
            {
                new UsersSeeder().Seed(context);
                new MainTopicCategorySeeder().Seed(context);
            }
        }
    }
}