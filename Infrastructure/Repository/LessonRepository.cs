using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        private readonly AppDbContext _appDbContext;
        public LessonRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<LessonViewModel>> GetAllLessonByUserIdAsync(Guid userId)
        {
            return await _appDbContext.Lessons
                .Include(x => x.Units)
                .Select(x => new LessonViewModel
            {
                LessonName = x.LessonName,
                LessonDescription = x.LessonDescription,
                unitNumber = x.Units.Count(),
                progress = _appDbContext.UserProgresses.Where(z => z.LessonId == x.Id && z.AccountId == userId).Select(z => z.ProgressPercentage).FirstOrDefault()
            }).AsQueryable().ToListAsync();
        }
    }
}
