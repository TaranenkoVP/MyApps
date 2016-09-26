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
    public interface IPostsService : IDeletableBaseService<Post, PostBusiness>
    {
        PostBusiness GetLastCreated();
        int GetPostsCountByTopicId(int id);
    }
}
