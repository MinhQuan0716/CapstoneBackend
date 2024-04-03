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
    public class QuestionDetailRepository : GenericRepository<QuestionDetail>, IQuestionDetailRepository
    {
        private readonly AppDbContext _appDbContext;
        public QuestionDetailRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> CalculationPoint(List<DoingQuizViewModel> listDoingQuizViewModels)
        {
            int count = 0;
            foreach(var doingQuizModel in listDoingQuizViewModels)
            {
                QuestionDetail questionDetail = await GetQuestionDetail(doingQuizModel.QuestionId, doingQuizModel.ChoiceId);
                if (questionDetail.IsCorrect)
                {
                    count++;
                }
            }
            return count;
        }

        public async Task<List<Guid>> GetAllChoiceInQuestionDetail(Guid questionId)
        {
           List<QuestionDetail> questionDetails= await _appDbContext.QuestionDetails.Where(x=>x.QuestionId==questionId).ToListAsync();
            List<Guid> choiceIdInQuestionDetail = new List<Guid>();
            foreach (var question in questionDetails)
            {
                choiceIdInQuestionDetail.Add(question.ChoiceId);
            }
            return choiceIdInQuestionDetail;
        }

        public async Task<List<Guid>> GetAllQuestionInQuestionDetail(Guid choiceId)
        {
            List<QuestionDetail> questionDetails = await _appDbContext.QuestionDetails.Where(x => x.ChoiceId == choiceId).ToListAsync();
            List<Guid> questionIdInQuestionDetail = new List<Guid>();
            foreach (var question in questionDetails)
            {
                questionIdInQuestionDetail.Add(question.QuestionId);
            }
            return questionIdInQuestionDetail;
        }

        public async Task<QuestionDetail> GetQuestionDetail(Guid questionId,Guid choiceId)
        {
            return await _appDbContext.QuestionDetails.FindAsync(questionId, choiceId);
        }
    }
}
