﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IMainCategoriesService : IBaseService<MainCategory, MainCategoryBusiness>
    {
        IEnumerable<MainCategoryBusiness> GetAll();
    }
}