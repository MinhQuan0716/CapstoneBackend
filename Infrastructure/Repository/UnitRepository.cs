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

        public async Task<IEnumerable<UnitViewModel>> GetAllUnitByLessonIdAsync(Guid courseId)
        {
            return await _appDbContext.Units
        .Where(unit => unit.LessonId == courseId)
        .Select(unit => new UnitViewModel
        {
            UnitName = unit.UnitName,
            UnitDuration =unit.UnitDuration,
            UnitType=GetLessonType(unit)
        })
        .ToListAsync();
        }

        public async Task<Unit> GetUnitByName(string lessonName)
        {
            return await _appDbContext.Units.FirstOrDefaultAsync(x => x.UnitName == lessonName);
        }

        private string GetLessonType(Unit unit)
        {
            if (unit.Videos.Any())
            {
                return "Video Unit";
            }
            else if (unit.Quizzes.Any())
            {
                return "Quiz Unit";
            }
            else if (unit.TheoryUnits.Any())
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
