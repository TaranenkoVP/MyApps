using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class MainCategoriesService : BaseService<MainCategory, MainCategoryBusiness>, IMainCategoriesService
    {
        public MainCategoriesService(IUnitOfWork uow)
            : base(uow, uow.MainCategoryRepository)
        {
        }

        public IEnumerable<MainCategoryBusiness> GetAll()
        {
            return Mapper.Map<List<MainCategoryBusiness>>(
                Database.MainCategoryRepository.Get(
                    includeProperties: "TopicCategories")
                    .ToList());
        }
    }
}
