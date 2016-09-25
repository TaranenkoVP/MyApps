﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface ITopicsService : IBaseService<Topic, TopicBusiness>
    {
        //IEnumerable<TopicBusiness> GetAllTopics();
        //TopicBusiness GetTopic(int id);
        TopicBusiness GetById(int id);
        //TopicBusiness GetLastCreatedByCategoryId(int id);
        //int GetTopicsCountByCategoryId(int id);
        //int GetPostsCountByCategoryId(int id);
        //PostBusiness GetLatestPostByCategoryId(int id);
        //void Add(TopicBusiness entity);
        //void Update(TopicBusiness entity);
        //void Delete(TopicBusiness entity);
    }
}
