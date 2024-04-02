using Application.Common;
using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.ChoiceModel;
using Application.ViewModel.QuestionModel;
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
        public async Task<QuizViewModel> GetQuizByUnitIdAsync(Guid unitId)
        {
            var listQuizViewModel = new List<QuizViewModel>();
            var listChoiceViewModel = new List<ChoiceViewModelForQuiz>();
            var listQuestionViewModel = new List<QuestionViewModelForQuiz>();
            ChoiceViewModelForQuiz choiceList = new ChoiceViewModelForQuiz();
            QuestionViewModelForQuiz questionList = new QuestionViewModelForQuiz();
            QuizViewModel quizViewModel = new QuizViewModel();
            var query = await _appDbContext.Quizzes.Include(x => x.Questions)
                                            .ThenInclude(y => y.Question)
                                             .ThenInclude(z => z.Choices)
                                             .ThenInclude(v => v.Choice)
                                             .Where(x => x.UnitId == unitId)
                                             .ToListAsync();
            foreach (var quiz in query)
            {
                var listChoice = quiz.Questions.SelectMany(quizdetail => quizdetail.Question.Choices).Select(question => question.Choice);
                foreach (var choice in listChoice)
                {
                    choiceList = new ChoiceViewModelForQuiz
                    {
                        ChoiceId = choice.Id,
                        ChoiceText = choice.ChoiceText,
                    };
                    listChoiceViewModel.Add(choiceList);
                }
                var listQuestion = quiz.Questions.Select(quizdetail => quizdetail.Question);
                foreach (var question in listQuestion)
                {
                    questionList = new QuestionViewModelForQuiz
                    {
                        QuestionId = question.Id,
                        QuestionText = question.QuestionText,
                    };
                    listQuestionViewModel.Add(questionList);
                }
                quizViewModel = new QuizViewModel
                {
                    ChoiceList = listChoiceViewModel,
                    QuestionTextList = listQuestionViewModel
                };

            }
            return quizViewModel;

        }
    }
}
