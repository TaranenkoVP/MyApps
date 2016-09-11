using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Data.Core.Common.Models;

namespace MyForum.Data.Core.Models
{
    public class Topic : BaseModel<int>
    {
        private ICollection<Post> _posts;

        #region Constructors

        /// <summary>
        /// The class constructor
        /// </summary>
        public Topic(User author)
        {
            _posts = new HashSet<Post>();
            Author = author;
        }

        #endregion Constructors

        public virtual User Author { get; }

        public virtual ICollection<Post> Posts
        {
            get { return this._posts; }
            set { this._posts = value; }
        }
    }
}
