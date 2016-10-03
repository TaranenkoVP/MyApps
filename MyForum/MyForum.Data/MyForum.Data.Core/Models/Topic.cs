using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.Core.Models
{
    public class Topic : BaseModel<int>
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string Content { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public int TopicCategoryId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual TopicCategory TopicCategory { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}