﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Common;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface ITopicCategoriesService : IDeletableBaseService<TopicCategory, TopicCategoryBusiness>
    {
        IEnumerable<TopicCategoryBusiness> GetAll();
        TopicCategoryBusiness GetById(int id);
        //void Add(TopicCategoryBusiness entity);
        //void Update(TopicCategoryBusiness entity);
        //void Delete(TopicCategoryBusiness entity);
    }
}
