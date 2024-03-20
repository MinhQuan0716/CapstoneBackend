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
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<CourseViewModel>> GetAllCourseByUserIdAsync(Guid userId)
        {
            return await _appDbContext.Courses
                .Include(x => x.Lessons)
                .Select(x => new CourseViewModel
            {
                CourseName = x.CourseName,
                Duration = x.Duration,
                CourseDescription = x.CourseDescription,
                numberLesson = x.Lessons.Count(),
                progress = _appDbContext.UserProgresses.Where(z => z.CourseId == x.Id && z.AccountId == userId).Select(z => z.ProgressPercentage).FirstOrDefault()
            }).AsQueryable().ToListAsync();
        }
    }
}
