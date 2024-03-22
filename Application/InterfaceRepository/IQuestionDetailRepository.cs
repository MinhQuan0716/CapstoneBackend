using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IQuestionDetailRepository:IGenericRepository<QuestionDetail>
    {
        Task<List<Guid>> GetAllChoiceInQuestionDetail(Guid questionId);
        Task<List<Guid>> GetAllQuestionInQuestionDetail(Guid choiceId);
        Task<QuestionDetail> GetQuestionDetail(Guid questionId,Guid choiceId);
    }
}
