using Application.ViewModel.ResponeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface ITheoryLessonService
    {
        Task<Respone> GetAllTheoryLesson();
        Task<Respone> GetAllTheoryLessonByLessonId(Guid lessonId);
    }
}
