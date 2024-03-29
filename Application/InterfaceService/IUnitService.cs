using Application.ViewModel.CourseModel;
using Application.ViewModel.ResponeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IUnitService
    {
        Task<Respone> GetAllUnitByLessonId(Guid lessonId);
        Task<Respone> DeleteUnit(Guid unitId);
        Task<Respone> GetUnitById(Guid unitId);
        Task<Respone> GetAllUnit();
    }
}