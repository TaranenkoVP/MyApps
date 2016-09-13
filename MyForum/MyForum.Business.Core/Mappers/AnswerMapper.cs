using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyForum.Business.Core.Entities;
using MyForum.Data.Core.Models;

namespace MyForum.Business.Core.Mappers
{
    public class AnswerMapper
    {
        private IMapper _answerMapper;

        public AnswerMapper()
        {
            _answerMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Answer, AnswerBusiness>();

                cfg.CreateMap<AnswerBusiness, Answer>();

            }).CreateMapper();
        }

        public AnswerBusiness GetWrapped(Answer answer)
        {
            return _answerMapper.Map<Answer, AnswerBusiness>(answer);
        }

        public List<AnswerBusiness> GetWrapped(IEnumerable<Answer> answers)
        {
            return _answerMapper.Map<IEnumerable<Answer>, List<AnswerBusiness>>(answers);
        }

        public Answer GetWrapped(AnswerBusiness answer)
        {
            return _answerMapper.Map<AnswerBusiness, Answer>(answer);
        }
    }
}
