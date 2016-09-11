using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Models;

namespace MyForum.Data.Core.Models
{
    public class Post : BaseModel<int>
    {
        private ICollection<Answer> answers;

        #region Constructors

        public Post(User author, Topic topic )
        {
            this.answers = new HashSet<Answer>();
            this.Author = author;
            this.Topic = topic;
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

        public virtual Topic Topic { get; set; }

        public virtual ICollection<Answer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }

    }
}
