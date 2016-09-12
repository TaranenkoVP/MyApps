using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Models;

namespace MyForum.Business.Core.Entities
{
    public class PostBusiness : BaseModel<int>
    {
        private ICollection<AnswerBusiness> answers;

        #region Constructors

        public PostBusiness(UserBusiness author, TopicBusiness topic )
        {
            this.answers = new HashSet<AnswerBusiness>();
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

        public virtual UserBusiness Author { get; set; }

        public virtual TopicBusiness Topic { get; set; }

        public virtual ICollection<AnswerBusiness> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }

    }
}
