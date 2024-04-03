using Application.ViewModel.PracticeUnitModel;
using Application.ViewModel.TheoryLessonModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IPracticeUnitRepository : IGenericRepository<PraticeUnit>
    {
        Task<IEnumerable<PracticeUnitModel>> GetAllPracticeUnitByUnitId(Guid unitId);
    }
}