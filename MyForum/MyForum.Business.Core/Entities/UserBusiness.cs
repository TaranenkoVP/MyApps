using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Models;

namespace MyForum.Business.Core.Entities
{
    public class UserBusiness
    {
        private ICollection<PostBusiness> _posts;
        private ICollection<TopicCategoryBusiness> _answers;
        private ICollection<TopicBusiness> _topics;

        #region Constructors

        public UserBusiness()
        {
            _posts = new HashSet<PostBusiness>();
            _answers = new HashSet<TopicCategoryBusiness>();
            _topics = new HashSet<TopicBusiness>();
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

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<PostBusiness> Posts
        {
            get { return _posts; }
            set { _posts = value; }
        }

        public virtual ICollection<TopicCategoryBusiness> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        public virtual ICollection<TopicBusiness> Topics
        {
            get { return _topics; }
            set { _topics = value; }
        }
    }
}
