using Application.ViewModel.CourseModel;
using Application.ViewModel.TheoryLessonModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface ITheoryLessonRepository : IGenericRepository<TheoryLesson>
    {
        Task<IEnumerable<TheoryLessonModel>> GetAllTheoryLessonByLessonId(Guid lessonId);
    }
}
