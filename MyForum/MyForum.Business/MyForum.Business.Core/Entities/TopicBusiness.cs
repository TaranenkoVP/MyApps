using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Common.Models;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Entities
{
    public class TopicBusiness : BaseModelBusiness<int>, IMapFrom<Topic>//, IHaveCustomMappings
    {
        private ICollection<PostBusiness> _posts;

        public int PostCount { get; set; }

        public virtual TopicCategory TopicCategory { get; set; }

        public virtual UserBusiness Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        #region Constructors

        /// <summary>
        /// The class constructor
        /// </summary>
        public TopicBusiness()
        {
            _posts = new HashSet<PostBusiness>();
        }

        #endregion Constructors

        public virtual ICollection<PostBusiness> Posts
        {
            get { return this._posts; }
            set { this._posts = value; }
        }

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //{
        //    configuration.CreateMap<Topic, TopicBusiness>()
        //       .ForMember(r => r.PostCount, opts => opts.MapFrom(x => x.Posts.Count));
        //}
    }
}
