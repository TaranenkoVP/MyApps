using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Data.Core.Common.Models;

namespace MyForum.Data.Core.Models.Identity
{
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public string Photo { get; set; }

        public virtual ICollection<MainCategory> MainCategories { get; set; }

        public virtual ICollection<TopicCategory> TopicCategories { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }
    }
}