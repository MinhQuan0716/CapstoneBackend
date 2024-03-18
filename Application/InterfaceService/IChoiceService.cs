using Application.ViewModel.ChoiceModel;
using Application.ViewModel.ResponeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IChoiceService
    {
        Task<Respone> UpdateChoice(Guid choiceId, UpdateChoiceModel updateChoiceModel);
    }
}
