using Application.InterfaceService;
using Application.ViewModel.ChoiceModel;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
   
    public class WebChoiceController : MainController
    {
        private readonly IChoiceService _choiceService;
        public WebChoiceController(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }
        [HttpPut("{id}")]
        public async Task<Respone> UpdateChoice(Guid id,UpdateChoiceModel updateChoiceModel)
        {
            Respone respone=await _choiceService.UpdateChoice(id,updateChoiceModel);
            return respone;
        }
    }
}
