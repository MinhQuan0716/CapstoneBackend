using Application.ViewModel.ResponeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IVideoUnitService
    {
        Task<Respone> GetAllVideoyUnit();
        Task<Respone> GetAllVideoUnitByUnitId(Guid unitId);
    }
}
