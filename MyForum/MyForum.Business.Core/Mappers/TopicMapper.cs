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
    public class TopicMapper
    {
        private IMapper _topicMapper;

        public TopicMapper()
        {
            _topicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Topic, TopicBusiness>();

                cfg.CreateMap<TopicBusiness, Topic>();

            }).CreateMapper();
        }

        public TopicBusiness GetWrapped(Topic product)
        {
            return _topicMapper.Map<Topic, TopicBusiness>(product);
        }

        public List<TopicBusiness> GetWrapped(IEnumerable<Topic> products)
        {
            return _topicMapper.Map<IEnumerable<Topic>, List<TopicBusiness>>(products);
        }

        public Topic GetWrapped(TopicBusiness product)
        {
            return _topicMapper.Map<TopicBusiness, Topic>(product);
        }
    }
}
