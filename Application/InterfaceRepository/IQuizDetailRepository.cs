using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IQuizDetailRepository:IGenericRepository<QuizDetail>
    {
        Task<List<Guid>> GetAllQuestionIdByQuizId(Guid quizId);
        Task<QuizDetail> FindQuizDetailById(Guid quizId,Guid questionId);
    }
}
