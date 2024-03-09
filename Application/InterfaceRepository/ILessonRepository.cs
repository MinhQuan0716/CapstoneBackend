using Application.ViewModel.CourseModel;
using Application.ViewModel.LessonModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        Task<IEnumerable<LessonViewModel>> GetAllLessonByCourseIdAsync(Guid courseId);
        Task<Lesson> GetLessonByName (string lessonName); 
    }
}
