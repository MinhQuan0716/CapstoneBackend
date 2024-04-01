using Application.ViewModel.CourseModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface ILessonRepository:IGenericRepository<Lesson>
    {
        Task<IEnumerable<LessonDetailViewModel>> GetAllLessonByUserIdAsync(Guid accountId);
    }
}
