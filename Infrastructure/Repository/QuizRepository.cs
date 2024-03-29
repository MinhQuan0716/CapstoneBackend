using Application.Common;
using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.QuizModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
    {
        private readonly AppDbContext _appDbContext;
        public QuizRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }


        public async Task<Guid> GetLastSaveQuizId()
        {
            Quiz lastSaveQuiz = await _appDbContext.Quizzes.OrderBy(x => x.CreationDate).LastOrDefaultAsync();
            return lastSaveQuiz.Id;
        }

       /* public async Task<List<QuizViewModel>> GetQuizByLessonId(Guid unitId)
        {
            return  await _appDbContext.Quizzes.Include(x => x.Questions)
                                             .ThenInclude(y => y.Question)
                                              .ThenInclude(z => z.Choices)
                                              .Where(x => x.UnitId == unitId)
                                              .Select(x => new QuizViewModel
                                              {
                                                  QuestionTextList=x.Questions.Select(y=>y.Question.QuestionText).ToList(),
                                                  ChoiceList=x.Questions.SelectMany(y=>y.Question.Choices.Select(z=>z.Choice.ChoiceText)).ToList(),
                                              }).AsQueryable().ToListAsync();
        }*/

        public IQueryable<Quiz> GetQuizQueryableForPagination()
        {
            var query = _appDbContext.Quizzes.Include(x => x.Questions)
                                             .ThenInclude(y => y.Question)
                                              .ThenInclude(z => z.Choices)
                                              .ThenInclude(v=>v.Choice)
                                              .AsQueryable();
            return query;
        }
        public Expression<Func<Quiz, bool>> GetExpression(Guid unitId)
        {
            return quiz => quiz.UnitId == unitId;
        }
        public async Task<Pagination<QuizViewModel>> GetPaginationQuiz(Guid unitId,int pageIndex,int pageSize)
        {
            var expression= GetExpression(unitId);
            var queryable = GetQuizQueryableForPagination();
            var quizPagination = await ToPagination(queryable,expression,pageIndex,pageSize);
            var listQuizViewModel= new List<QuizViewModel>();
            foreach(var item in quizPagination.Items)
            {   
                QuizViewModel quizViewModel = new QuizViewModel
                {
                    ChoiceList = item.Questions?.SelectMany(y => y.Question?.Choices?.Select(z => z.Choice?.ChoiceText) ?? new List<string>()).ToList() ?? new List<string>(),
                    QuestionTextList = item.Questions.Select(y => y.Question.QuestionText).ToList()
                };
                listQuizViewModel.Add(quizViewModel);
            }
            return new  Pagination<QuizViewModel>()
            {
                Items = listQuizViewModel,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount=quizPagination.TotalItemsCount
            };
        }
    }
}
