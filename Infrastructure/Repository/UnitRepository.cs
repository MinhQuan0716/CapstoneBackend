using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Application.ViewModel.LessonModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        private readonly AppDbContext _appDbContext;
        public UnitRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<UnitViewModel>> GetAllUnitByLessonIdAsync(Guid lessonId)
        {
            var units = await _appDbContext.Units
                .Include(unit => unit.PraticeUnits)
                .Include(unit => unit.TheoryUnits)
                .Include(unit => unit.Videos)
                .Where(unit => unit.LessonId == lessonId)
                .OrderBy(unit => unit.UnitOrder)
        .       ToListAsync();

            var unitViewModels = units.Select(unit => new UnitViewModel
            {
                UnitName = unit.UnitName,
                UnitDuration = unit.UnitDuration,
                UnitType = GetUnitType(unit)
            })
                .ToList(); // Materialize the projection into a list.

            return unitViewModels;
        }

        public async Task<Unit> GetUnitByName(string lessonName)
        {
            return await _appDbContext.Units.FirstOrDefaultAsync(x => x.UnitName == lessonName);
        }

        private string GetUnitType(Unit unit)
        {
            if (unit.Videos != null && unit.Videos.Any())
            {
                return "Video Unit";
            }
            else if (unit.Quizzes != null && unit.Quizzes.Any())
            {
                return "Quiz Unit";
            }
            else if (unit.TheoryUnits != null && unit.TheoryUnits.Any())
            {
                return "Theory Unit";
            }
            else
            {
                return "Unknown Unit Type";
            }
        }
    }

}
