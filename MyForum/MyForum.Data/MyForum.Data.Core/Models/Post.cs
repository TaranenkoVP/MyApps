﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.Core.Models
{
    public class Post : BaseModel<int>
    {
        private ICollection<TopicCategory> answers;

        #region Constructors

        public Post( )
        {
            this.answers = new HashSet<TopicCategory>();
        }

        #endregion Constructors

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual ICollection<TopicCategory> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }

    }
}