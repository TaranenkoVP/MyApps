using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;
using MyForum.Data.Models;

namespace MyForum.Data
{
    public class MyForumDbContext : IdentityDbContext<User>
    {
        public IDbSet<Post> Posts { get; set; }
        public IDbSet<Topic> Topics { get; set; }
        public IDbSet<Answer> Answers { get; set; }

        public MyForumDbContext(string connectionString)
            : base(connectionString)
        {
            Database.Log = (e) => { Debug.WriteLine(e); };
            //Database.SetInitializer(new StoreDbInitializer());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
        //    modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
        //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        //}
    }
}
