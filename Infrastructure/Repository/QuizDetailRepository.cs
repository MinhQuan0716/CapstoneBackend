using Application.InterfaceRepository;
using Application.InterfaceService;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class QuizDetailRepository : GenericRepository<QuizDetail>, IQuizDetailRepository
    {
        private readonly AppDbContext _appDbContext;
        public QuizDetailRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<QuizDetail> FindQuizDetailById(Guid quizId, Guid questionId)
        {
            return await _appDbContext.QuizDetails.FindAsync(quizId, questionId);
        }

        public async Task<List<Guid>> GetAllQuestionIdByQuizId(Guid quizId)
        {
            List<QuizDetail> detailList = await _appDbContext.QuizDetails.Where(x => x.QuizId == quizId).ToListAsync();
            List<Guid> questionId =new List<Guid>();
            foreach (var detail in detailList)
            {
                questionId.Add(detail.QuestionId);
            }
            return questionId;
        }
    }
}
