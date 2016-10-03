using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyForum.Data.Core.Common.Models;

namespace MyForum.Data.Core.Models
{
    public class MainCategory : BaseModel<int>
    {
        public MainCategory()
        {
            TopicCategories = new HashSet<TopicCategory>();
        }

        [ForeignKey("ApplicationUser")]
        public int ApplicationUserId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<TopicCategory> TopicCategories { get; set; }
    }
}