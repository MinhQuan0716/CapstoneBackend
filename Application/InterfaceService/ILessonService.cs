using Application.ViewModel.CourseModel;
using Application.ViewModel.ResponeModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface ILessonService
    {
        Task<Respone> GetAllLessonByUserId();
        Task<Respone> CreateLesson(LessonDetailViewModel model);
        Task<Respone> DeleteLesson(Guid lessonId);
        Task<Respone> UpdateLesson(Guid lessonId, LessonDetailViewModel model);
        Task<Respone> GetLessonById(Guid lessonId);
        Task<Respone> GetAllLesson();
    }
}
