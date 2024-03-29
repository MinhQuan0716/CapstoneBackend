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
        /*Task<List<QuizViewModel>> GetQuizByUnitId(Guid unitId);*/
        IQueryable<Quiz> GetQuizQueryableForPagination();
        Expression<Func<Quiz, bool>> GetExpression(Guid unitId);
        Task<Pagination<QuizViewModel>> GetPaginationQuiz(Guid unitId, int pageIndex, int pageSize);
        /*Task<Pagination<QuizViewModel>> GetQuizPaginatedByLessonId(Guid lessonId);*/
    }
}
