﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            new AdminSeeder().Seed(context);
            new TopicCategorySeeder().Seed(context);
        }
    }
}