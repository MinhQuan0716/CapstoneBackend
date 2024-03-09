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
    }
}
