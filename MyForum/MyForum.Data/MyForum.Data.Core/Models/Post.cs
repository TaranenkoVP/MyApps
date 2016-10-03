using System.ComponentModel.DataAnnotations;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models.Identity;

namespace MyForum.Data.Core.Models
{
    public class Post : BaseModel<int>
    {
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}