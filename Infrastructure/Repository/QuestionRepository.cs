using Application.InterfaceRepository;
using Application.InterfaceService;
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
            return await _appDbContext.Questions.Include(x => x.Choices).ThenInclude(y => y.Choice)
                .Select(x => new QuestionViewModel
                {
                    QuestionId=x.Id,
                    QuestionText=x.QuestionText,
                    Explainantion=x.Explaination,
                    ChoiceList=x.Choices.Select(x=>x.Choice.ChoiceText).ToList(),
                }
                ).AsQueryable().ToListAsync();
        }

        public async Task<Guid> GetLastSavedQuestion()
        {
            Question question= await _appDbContext.Questions.OrderBy(x=>x.CreationDate).LastOrDefaultAsync();
            return question.Id;
        }
    }
}
