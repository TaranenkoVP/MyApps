using System.Data.Entity.Migrations;
using MyForum.Data.EF.Infrastructure;

namespace MyForum.Data.EF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MyForumDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyForumDbContext context)
        {
        }
    }
}