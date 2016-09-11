﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyForum.Data.Common.Models;

namespace MyForum.Data.Models
{
    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Post> _posts;
        private ICollection<Answer> _answers;
        private ICollection<Topic> _topics;

        #region Constructors

        public User()
        {
            _posts = new HashSet<Post>();
            _answers = new HashSet<Answer>();
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

        public virtual ICollection<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        public virtual ICollection<Topic> Topics
        {
            get { return _topics; }
            set { _topics = value; }
        }
    }
}