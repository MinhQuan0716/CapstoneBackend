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
    public interface IUnitRepository : IGenericRepository<Unit>
    {
        Task<IEnumerable<UnitViewModel>> GetAllUnitByLessonIdAsync(Guid lessonId);
        Task<Unit> GetUnitByName (string unitName); 
    }
}
