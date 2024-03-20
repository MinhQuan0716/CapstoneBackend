using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.ChoiceModel;
using Application.ViewModel.QuestionModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        private readonly AppDbContext _appDbContext;
        public QuestionRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<QuestionViewModel>> GetAllQuestions()
        {
            
            return await _appDbContext.Questions.Include(x => x.Choices).ThenInclude(y => y.Choice).Where(x=>x.IsDelete==false)
                .Select(x => new QuestionViewModel
                {
                    QuestionId=x.Id,
                    QuestionText=x.QuestionText,
                    Explainantion=x.Explaination,
                    ChoiceList=x.Choices.Select(x=>new ChoiceViewModel
                    {
                        ChoiceId=x.Choice.Id,
                        ChoiceText=x.Choice.ChoiceText,
                        IsCorrect=x.IsCorrect
                    }).ToList(),
                }
                ).AsQueryable().ToListAsync();
        }

        public async Task<Guid> GetLastSavedQuestion()
        {
            Question question= await _appDbContext.Questions.OrderBy(x=>x.CreationDate).LastOrDefaultAsync();
            return question.Id;
        }

        public async Task<IEnumerable<QuestionViewModel>> GetQuestionByQuizId(Guid quizId)
        {
            return await _appDbContext.Questions
                .Include(x => x.Choices)
                .ThenInclude(z => z.Choice)
                .Where(x=>x.QuizDetail.Select(x=>x.Quiz).Select(quiz=>quiz.Id).Contains(quizId)&&x.IsDelete==false)
               .Select(x => new QuestionViewModel
               {
                   QuestionId = x.Id,
                   QuestionText = x.QuestionText,
                   Explainantion = x.Explaination,
                   ChoiceList = x.Choices.Select(x => new ChoiceViewModel
                   {
                       ChoiceId = x.Choice.Id,
                       ChoiceText = x.Choice.ChoiceText,
                       IsCorrect = x.IsCorrect
                   }).ToList(),
               }
               ).AsQueryable().ToListAsync();
        }
    }
}
