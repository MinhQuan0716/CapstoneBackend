using Application.InterfaceRepository;
using Application.InterfaceService;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserQuizAttemptRepository : GenericRepository<UserQuizAttempt>, IUserQuizAttemptRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserQuizAttemptRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }
        
    }
}
