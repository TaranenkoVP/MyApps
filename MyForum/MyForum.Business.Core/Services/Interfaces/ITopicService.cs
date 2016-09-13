using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface ITopicService : IDisposable
    {
        IQueryable<TopicBusiness> GetAllTopics();
        TopicBusiness GetTopic(int? id);
        void Add(TopicBusiness entity);
        void Update(TopicBusiness entity);
        void Delete(TopicBusiness entity);
    }
}
