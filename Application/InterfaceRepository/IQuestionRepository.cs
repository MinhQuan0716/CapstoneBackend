using Application.ViewModel.QuestionModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IQuestionRepository:IGenericRepository<Question>
    {
        Task<Guid> GetLastSavedQuestion();
        Task<IEnumerable<QuestionViewModel>> GetAllQuestions();
        Task<IEnumerable<QuestionViewModel>> GetQuestionByQuizId(Guid quizId);
    }
}
