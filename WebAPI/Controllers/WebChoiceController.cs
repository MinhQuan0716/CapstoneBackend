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
        [HttpPost]
        public async Task<Respone> CreateChoice(CreateChoiceModel model)
        {
            Respone respone=await _choiceService.CreateChoiceAsync(model);
            return respone;
        }
        [HttpPut("{id}")]
        public async Task<Respone> UpdateChoice(Guid id,UpdateChoiceModel updateChoiceModel)
        {
            Respone respone=await _choiceService.UpdateChoice(id,updateChoiceModel);
            return respone;
        }
        [HttpDelete("{id}")]
        public async Task<Respone> DeleteChoice(Guid id)
        {
            Respone respone=await _choiceService.DeleteChoiceAsync(id);
            return respone;
        }
    }
}
