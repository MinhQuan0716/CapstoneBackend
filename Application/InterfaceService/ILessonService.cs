using Application.ViewModel.CourseModel;
using Application.ViewModel.ResponeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface ILessonService
    {
        Task<Respone> GetAllLessonByCourseId(Guid courseId);
        Task<Respone> DeleteLesson(Guid lessonId);
        Task<Respone> GetLessonById(Guid lessonId);
        Task<Respone> GetAllLesson();
    }
}