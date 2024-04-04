using Application.ViewModel.LessonModel;
using Application.ViewModel.TheoryLessonModel;
using Application.ViewModel.VideoUnitModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IVideoUnitRepository : IGenericRepository<UnitVideo>
    {
        Task<IEnumerable<VideoUnitModel>> GetAllVideoUnitByUnitIdAsync(Guid unitId);
    }
}
