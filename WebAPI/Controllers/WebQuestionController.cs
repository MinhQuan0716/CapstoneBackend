using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.QuestionModel;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
 
    public class WebQuestionController :MainController
    {
        private readonly IQuestionService _questionService;
        public WebQuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        public async Task<Respone> GetAllQuestion()
        {
            Respone respone=await _questionService.GetAllQuestionAsync();
            return respone;
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionModel createQuestionModel)
        {
            Respone response=await _questionService.AddQuestionAsync(createQuestionModel);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<Respone> DeleteQuestion(Guid id)
        {
            Respone respone=await _questionService.DeleteQuestionAsync(id);
            return respone;
        }
        [HttpGet("{id}")]
        public async Task<Respone> GetAllQuestionByQuizId(Guid id)
        {
            Respone respone = await _questionService.GetQuestionByQuizIdAsync(id);
            return respone;
        }
        
    }
}
