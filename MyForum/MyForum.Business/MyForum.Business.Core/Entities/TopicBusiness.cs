using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Entities
{
    public class TopicBusiness : BaseModelBusiness<int>, IMapFrom<Topic>
    {
        private ICollection<PostBusiness> _posts;

        #region Constructors

        /// <summary>
        /// The class constructor
        /// </summary>
        public TopicBusiness(UserBusiness author)
        {
            _posts = new HashSet<PostBusiness>();
            Author = author;
        }

        #endregion Constructors

        public virtual UserBusiness Author { get; }

        public virtual ICollection<PostBusiness> Posts
        {
            get { return this._posts; }
            set { this._posts = value; }
        }
    }
}
