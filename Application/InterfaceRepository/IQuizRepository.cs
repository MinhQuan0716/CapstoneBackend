using Application.Common;
using Application.ViewModel.QuizModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IQuizRepository:IGenericRepository<Quiz>
    {
        Task<Guid> GetLastSaveQuizId();
        Task<List<QuizViewModel>> GetQuizByLessonId(Guid lessonId);
        IQueryable<Quiz> GetQuizQueryableForPagination();
        Expression<Func<Quiz, bool>> GetExpression(Guid lessonId);
        Task<Pagination<QuizViewModel>> GetPaginationQuiz(Guid lessonId, int pageIndex, int pageSize);
        /*Task<Pagination<QuizViewModel>> GetQuizPaginatedByLessonId(Guid lessonId);*/
    }
}
