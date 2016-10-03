using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.Core.Models
{
    public class TopicCategory : BaseModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public int MainCategoryId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual MainCategory MainCategory { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}