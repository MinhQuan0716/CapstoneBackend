using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.QuizModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<QuizViewModel> GetQuiz(Guid lessonId)
        {
            return await _appDbContext.Quizzes.Include(x => x.Questions)
                                             .ThenInclude(y => y.Question)
                                              .ThenInclude(z => z.Choices)
                                              .Where(x => x.LessonId == lessonId)
                                              .Select(x => new QuizViewModel
                                              {
                                                  QuestionTextList=x.Questions.Select(y=>y.Question.QuestionText).ToList(),
                                                  ChoiceList=x.Questions.SelectMany(y=>y.Question.Choices.Select(z=>z.Choice.ChoiceText)).ToList(),
                                              }).FirstOrDefaultAsync();
        }
    }
}
