using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.EF.Infrastructure
{
    public class MyForumDbContext : IdentityDbContext<User>
    {
        public IDbSet<Post> Posts { get; set; }
        public IDbSet<Topic> Topics { get; set; }
        public IDbSet<TopicCategory> TopicCategory { get; set; }

        public MyForumDbContext() { }

        public MyForumDbContext(string connectionString)
            : base(connectionString)
        {
            //   Database.Log = (e) => { Debug.WriteLine(e); };
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyForumDbContext, Configuration>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
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
