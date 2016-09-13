﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Models;

namespace MyForum.Data.Core.Models
{
    public class Topic : BaseModel<int>
    {
        private ICollection<Post> _posts;

        #region Constructors

        /// <summary>
        /// The class constructor
        /// </summary>
        public Topic()
        {
            _posts = new HashSet<Post>();
        }

        #endregion Constructors

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int TopicCategoryId { get; set; }

        public virtual TopicCategory Category { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this._posts; }
            set { this._posts = value; }
        }
    }
}
