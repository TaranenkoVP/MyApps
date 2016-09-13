using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Models;

namespace MyForum.Data.Core.Models
{
    public class TopicCategory : BaseModel<int>
    {
        private ICollection<Topic> _topics;

        public TopicCategory()
        {
            this._topics = new HashSet<Topic>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public ICollection<Topic> Topics
        {
            get { return this._topics; }
            set { this._topics = value; }
        }

    }
}
