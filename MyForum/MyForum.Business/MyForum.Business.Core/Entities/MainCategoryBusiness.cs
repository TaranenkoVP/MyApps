using System.Collections.Generic;
using MyForum.Business.Core.Infrastructure.Mappers;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Entities
{
    public class MainCategoryBusiness : IMapFrom<MainCategory>
    {
        private ICollection<TopicCategoryBusiness> _topicCategories;

        /// <summary>
        ///     The class constructor
        /// </summary>
        public MainCategoryBusiness()
        {
            _topicCategories = new HashSet<TopicCategoryBusiness>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<TopicCategoryBusiness> TopicCategories
        {
            get { return _topicCategories; }
            set { _topicCategories = value; }
        }

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //            opts => opts.MapFrom(x => x.Topics.Select(y => y.Posts.OrderByDescending(t => t.CreatedOn).FirstOrDefault())));
        //       .ForMember(r => r.LatestPost,
        //       .ForMember(r => r.PostsCount, opts => opts.MapFrom(x => x.Topics.SelectMany(y => y.Posts).Count()))
        //       .ForMember(r => r.TopicsCount, opts => opts.MapFrom(x => x.Topics.Count))
        //}
    }
}