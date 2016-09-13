using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;

namespace MyForum.Business.Core.Services.Interfaces
{
    public interface IAnswerService
    {
        IQueryable<AnswerBusiness> AnswersByPostId(int id);

        AnswerBusiness GetAnswer(int? id);

        void Add(AnswerBusiness entity);
        void Update(AnswerBusiness entity);
        void Delete(AnswerBusiness entity);

    }
}
