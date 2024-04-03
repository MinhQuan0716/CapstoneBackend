using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Application.ViewModel.TheoryLessonModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TheoryUnitRepository : GenericRepository<TheoryUnit>, ITheoryUnitRepository
    {
        private readonly AppDbContext _appDbContext;
        public TheoryUnitRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<TheoryUnitModel>> GetAllTheoryUnitByUnitId(Guid unitId)
        {
            return await _appDbContext.TheoryUnits
                .Where(theoryUnit => theoryUnit.UnitId == unitId)
                .Select(x => new TheoryUnitModel
                {
                    Title = x.Title,
                    Content = x.Content
                }).AsQueryable().ToListAsync();
        }
    }
}
