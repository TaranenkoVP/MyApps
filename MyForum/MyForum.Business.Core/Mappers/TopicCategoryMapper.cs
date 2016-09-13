using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyForum.Business.Core.Entities;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Mappers
{
    public class TopicCategoryMapper
    {
        private IMapper _topicCategoryMapper;

        public TopicCategoryMapper()
        {
            _topicCategoryMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TopicCategory, TopicCategoryBusiness>();

                cfg.CreateMap<TopicCategoryBusiness, TopicCategory>();

            }).CreateMapper();
        }

        public TopicCategoryBusiness GetWrapped(TopicCategory topicCategory)
        {
            return _topicCategoryMapper.Map<TopicCategory, TopicCategoryBusiness>(topicCategory);
        }

        public List<TopicCategoryBusiness> GetWrapped(IEnumerable<TopicCategory> topicCategories)
        {
            return _topicCategoryMapper.Map<IEnumerable<TopicCategory>, List<TopicCategoryBusiness>>(topicCategories);
        }

        public TopicCategory GetWrapped(TopicCategoryBusiness topicCategory)
        {
            return _topicCategoryMapper.Map<TopicCategoryBusiness, TopicCategory>(topicCategory);
        }
    }
}
