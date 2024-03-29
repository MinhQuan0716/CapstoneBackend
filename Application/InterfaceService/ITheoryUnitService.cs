using Application.ViewModel.ResponeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface ITheoryUnitService
    {
        Task<Respone> GetAllTheoryUnit();
        Task<Respone> GetAllTheoryUnitByUnitId(Guid lessonId);
    }
}
