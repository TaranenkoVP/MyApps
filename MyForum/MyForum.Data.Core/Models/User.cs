using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Data.Core.Common.Models;

namespace MyForum.Data.Core.Models
{
    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Post> _posts;
        private ICollection<TopicCategory> _topicCategories;
        private ICollection<Topic> _topics;

        #region Constructors

        public User()
        {
            _posts = new HashSet<Post>();
            _topicCategories = new HashSet<TopicCategory>();
            _topics = new HashSet<Topic>();
        }

        #endregion Constructors
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        //{
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    return userIdentity;
        //}

        public string Photo { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return _posts; }
            set { _posts = value; }
        }

        public virtual ICollection<TopicCategory> TopicCategories
        {
            get { return _topicCategories; }
            set { _topicCategories = value; }
        }

        public virtual ICollection<Topic> Topics
        {
            get { return _topics; }
            set { _topics = value; }
        }
    }
}
