#define DEBUG
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models;
using MyForum.Data.Core.Models.Identity;
using MyForum.Data.EF.Migrations;

namespace MyForum.Data.EF.Infrastructure
{
    public class MyForumDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyForumDbContext()
        {
        }

        public MyForumDbContext(string connectionString)
            : base(connectionString)
        {
            //Database.Log = e => { Debug.WriteLine(e); };
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyForumDbContext, Configuration>());
        }

        public IDbSet<MainCategory> MainCategory { get; set; }
        public IDbSet<TopicCategory> TopicCategory { get; set; }
        public IDbSet<Topic> Topic { get; set; }
        public IDbSet<Post> Post { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MainCategory>()
                .HasRequired(c => c.ApplicationUser)
                .WithMany(t => t.MainCategories)
                .HasForeignKey(m => m.ApplicationUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TopicCategory>()
                .HasRequired(c => c.ApplicationUser)
                .WithMany(t => t.TopicCategories)
                .HasForeignKey(m => m.ApplicationUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TopicCategory>()
                .HasRequired(m => m.MainCategory)
                .WithMany(t => t.TopicCategories)
                .HasForeignKey(m => m.MainCategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .HasRequired(c => c.ApplicationUser)
                .WithMany(t => t.Topics)
                .HasForeignKey(m => m.ApplicationUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .HasRequired(m => m.TopicCategory)
                .WithMany(t => t.Topics)
                .HasForeignKey(m => m.TopicCategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasRequired(c => c.ApplicationUser)
                .WithMany(t => t.Posts)
                .HasForeignKey(m => m.ApplicationUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasRequired(m => m.Topic)
                .WithMany(t => t.Posts)
                .HasForeignKey(m => m.TopicId)
                .WillCascadeOnDelete(false);
        }

        public override int SaveChanges()
        {
            ApplyAuditInfoRules();

            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                ChangeTracker.Entries()
                    .Where(
                        e =>
                            e.Entity is IAuditInfo &&
                            ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo) entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}