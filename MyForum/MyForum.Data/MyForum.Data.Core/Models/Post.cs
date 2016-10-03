﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.Core.Models
{
    public class Post : BaseModel<int>
    {
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public int TopicId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Topic Topic { get; set; }
    }
}