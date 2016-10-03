using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.Core.Models
{
    public class TopicCategory : BaseModel<int>
    {
        public TopicCategory()
        {
            Topics = new HashSet<Topic>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [ForeignKey("MainCategory")]
        public int MainCategoryId { get; set; }

        public virtual MainCategory MainCategory { get; set; }

        [ForeignKey("ApplicationUser")]
        public int ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}