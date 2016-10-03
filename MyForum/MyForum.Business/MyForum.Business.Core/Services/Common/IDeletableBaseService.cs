using System;

namespace MyForum.Business.Core.Services.Common
{
    public interface IDeletable<in TEntityBusiness> : IDisposable
    {
        void Add(TEntityBusiness entity);
        void Update(TEntityBusiness entity);
        void Delete(TEntityBusiness entity);
    }
}