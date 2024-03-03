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
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private AppDbContext _appDbContext; 
        public AccountRepository(AppDbContext appDbContext,IClaimService claimService) : base(appDbContext,claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Account> FindAccountByEmailAndPassword(string email, string password)
        {
            return await _appDbContext.Accounts.Include(x=>x.Role).SingleOrDefaultAsync(x=>x.Email== email && x.PasswordHash== password);  
        }

        public async Task<Account> FindAccountByEmail(string email)
        {
            return await _appDbContext.Accounts.Include(x=>x.Role).SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
