using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyForum.Business.Core.Entities;
using MyForum.Business.Core.Infrastructure;
using MyForum.Business.Core.Mappers;
using MyForum.Business.Core.Services.Interfaces;
using MyForum.Data.Core.Common.Repositories;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _database;

        public AnswerService(IUnitOfWork uow)
        {
            _database = uow;
        }

        public AnswerBusiness GetAnswer(int? id)
        {
            if (!id.HasValue)
            {
                throw new ValidationException("Answer id is null");
            }

            var answer = new AnswerMapper().GetWrapped(_database.AnswerRepository.GetById(id.Value));

            if (answer == null)
            {
                throw new ValidationException("Answer not found");
            }

            return answer;
        }

        public IQueryable<AnswerBusiness> AnswersByPostId(int id)
        {
            var answers = _database.AnswerRepository.Get(
                filter: d => d.ForumPostId == id);

            return new AnswerMapper().GetWrapped(answers.AsEnumerable()).AsQueryable();
        }

        public void Update(AnswerBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Answer is Null");
            }

            _database.AnswerRepository.Update(new AnswerMapper().GetWrapped(entity));
            _database.Commit();
        }

        public void Add(AnswerBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Answer is unspecified");
            }

            _database.AnswerRepository.Add(new AnswerMapper().GetWrapped(entity));
            _database.Commit();
        }

        public void Delete(AnswerBusiness entity)
        {
            if (entity == null)
            {
                throw new ValidationException("Answer is Null");
            }

            _database.AnswerRepository.Delete(new AnswerMapper().GetWrapped(entity));
            _database.Commit();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
