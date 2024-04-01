using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
        private bool IsPreviousLessonCompleted(Lesson lesson, Dictionary<Guid, UserProgress> userProgress, List<Lesson> lessons)
        {
            // If it's the first lesson, consider it unlocked
            if (lesson.LessonOrder == 1)
                return true;

            // Get the previous lesson
            var previousLesson = userProgress.TryGetValue(lesson.Id, out var progress) ?
                lessons.FirstOrDefault(l => l.LessonOrder == lesson.LessonOrder - 1) :
                null;

            // If previous lesson is not found or not completed, return false
            if (previousLesson == null || !userProgress.TryGetValue(previousLesson.Id, out var prevProgress) || !prevProgress.IsCompleted)
                return false;

            return true;
        }
        public async Task<IEnumerable<LessonDetailViewModel>> GetAllLessonByUserIdAsync(Guid accountId)
        {
            var lessons = await _appDbContext.Lessons
                .ToListAsync();
            var userProgress = await _appDbContext.UserProgresses
                .Where(up => up.AccountId == accountId)
                .ToDictionaryAsync(up => up.LessonId);
            var lessonCount = lessons.Count();
            var lessonDetailViewModel = lessons.Select(lesson => new LessonDetailViewModel
            {
                LessonName = lesson.LessonName,
                LessonDescription = lesson.LessonDescription,
                IsPremium = lesson.IsPremium,
                ImageUrl = lesson.ImageUrl,
                LessonOrder = lesson.LessonOrder,
                progress = userProgress.TryGetValue(lesson.Id, out var progress) ? progress.ProgressPercentage : 0,
                isUnclocked = IsPreviousLessonCompleted(lesson, userProgress, lessons),
                NumberOfLesson = lessonCount
            }).ToList();

            return lessonDetailViewModel;
            /*return await _appDbContext.Lessons
                .Include(x => x.Units)
                .Select(x => new LessonViewModel
            {
                LessonName = x.LessonName,
                LessonDescription = x.LessonDescription,
                unitNumber = x.Units.Count(),
                progress = _appDbContext.UserProgresses.Where(z => z.LessonId == x.Id && z.AccountId == userId).Select(z => z.ProgressPercentage).FirstOrDefault()
            }).AsQueryable().ToListAsync();*/
        }
        
    }
}
