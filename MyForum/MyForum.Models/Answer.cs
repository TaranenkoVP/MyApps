using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Common.Models;

namespace MyForum.Data.Models
{
    public class Answer : BaseModel<int>
    {
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ForumPostId { get; set; }

        public virtual Post Post { get; set; }

    }
}
