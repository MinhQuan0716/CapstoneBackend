using Application.ViewModel.ResponeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IPracticeUnitService
    {
        Task<Respone> GetAllPracticeUnit();
        Task<Respone> GetAllPracticeUnitByUnitId(Guid unitId);
    }
}
