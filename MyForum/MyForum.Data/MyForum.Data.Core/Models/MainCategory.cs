using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Models;

namespace MyForum.Data.Core.Models
{
    public class MainCategory : ITKeyEntity<int>
    {
        [Key]
        public int Id { get; set; }

        private ICollection<TopicCategory> _topicCategories;

        public MainCategory()
        {
            this._topicCategories = new HashSet<TopicCategory>();
        }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<TopicCategory> TopicCategories
        {
            get { return this._topicCategories; }
            set { this._topicCategories = value; }
        }
    }
}
