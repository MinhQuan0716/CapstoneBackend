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
    public class ChoiceRepository : GenericRepository<Choice>, IChoiceRepository
    {
        private readonly AppDbContext _appDbContext;
        public ChoiceRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> GetLastSavedChoice()
        {
            Choice choice = await _appDbContext.Choices.OrderBy(x=>x.CreationDate).LastOrDefaultAsync();
            return choice.Id;
        }
    }
}
