using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Business.Core.Services.Common
{
    public interface IDeletableBaseService<TEntity, in TEntityBusiness> : IBaseService
    {
        void Add(TEntityBusiness entity);
        void Update(TEntityBusiness entity);
        void Delete(TEntityBusiness entity);
    }
}
