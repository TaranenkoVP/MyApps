using System.Collections.Generic;
using AutoMapper;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Entities
{
    public class TopicBusiness : BaseModelBusiness<int>, IMapFrom<Topic>, IHaveCustomMappings
    {
        private ICollection<PostBusiness> _posts;

        #region Constructors

        /// <summary>
        ///     The class constructor
        /// </summary>
        public TopicBusiness()
        {
            _posts = new HashSet<PostBusiness>();
        }

        #endregion Constructors

        public string Title { get; set; }

        public int TopicCategoryId { get; set; }

        public string TopicCategoryName { get; set; }

        public string AuthorId { get; set; }

        public virtual UserBusiness Author { get; set; }

        public PostBusiness LatestPost { get; set; }

        public int PostsCount { get; set; }

        public virtual ICollection<PostBusiness> Posts
        {
            get { return _posts; }
            set { _posts = value; }
        }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Topic, TopicBusiness>();
            //.ForMember(r => r.TopicCategoryId, opts => opts.MapFrom(x => x.TopicCategory.Id))
            //.ForMember(r => r.TopicCategoryName, opts => opts.MapFrom(x => x.TopicCategory.Name))
            //.ForMember(r => r.PostCount, opts => opts.MapFrom(x => x.Posts.Count))
            //.ForMember(r => r.LatestPost,
            //    opts => opts.MapFrom(x => x.Posts.OrderByDescending(t => t.CreatedOn).FirstOrDefault()));
        }
    }
}