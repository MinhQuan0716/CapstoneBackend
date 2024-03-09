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
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        private readonly AppDbContext _appDbContext;
        public LessonRepository(AppDbContext appDbContext, IClaimService claimService) : base(appDbContext, claimService)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<LessonViewModel>> GetAllLessonByCourseIdAsync(Guid courseId)
        {
            return await _appDbContext.Lessons
        .Where(lesson => lesson.CourseId == courseId)
        .Select(lesson => new LessonViewModel
        {
            LessonName = lesson.LessonName,
            LessonContent = lesson.LessonContent,
            LessonType = GetLessonType(lesson),
        })
        .ToListAsync();
        }

        public async Task<Lesson> GetLessonByName(string lessonName)
        {
            return await _appDbContext.Lessons.FirstOrDefaultAsync(x => x.LessonName == lessonName);
        }

        private string GetLessonType(Lesson lesson)
        {
            if (lesson.Videos.Any())
            {
                return "Video Lesson";
            }
            else if (lesson.Quizzes.Any())
            {
                return "Quiz Lesson";
            }
            else if (lesson.TheoryLessons.Any())
            {
                return "Theory Lesson";
            }
            else
            {
                return "Unknown Lesson Type";
            }
        }
    }

}
