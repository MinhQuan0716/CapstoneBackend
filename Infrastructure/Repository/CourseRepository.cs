using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<CourseViewModel>> GetAllCourseAsync()
        {
            return await _appDbContext.Courses.Select(x=>new CourseViewModel
            {
                courseName = x.CourseName,
                Duration = x.Duration,
                lessonAmount=x.Lessons.Count(),
                Percentage=75
            }).AsQueryable().ToListAsync();
        }
    }
}
