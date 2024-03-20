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
    public class TheoryLessonRepository : GenericRepository<TheoryLesson>, ITheoryLessonRepository
    {
        private readonly AppDbContext _appDbContext;
        public TheoryLessonRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<TheoryLessonModel>> GetAllTheoryLessonByLessonId(Guid lessonId)
        {
            return await _appDbContext.TheoryLessons
                .Where(theoryLesson => theoryLesson.LessonId == lessonId)
                .Select(x => new TheoryLessonModel
                {
                    Title = x.Title,
                    Content = x.Content
                }).AsQueryable().ToListAsync();
        }
    }
}
