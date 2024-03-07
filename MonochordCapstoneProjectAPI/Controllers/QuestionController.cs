using Application.InterfaceService;
using Application.ViewModel.QuestionModel;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MonochordCapstoneProjectAPI.Controllers
{
    
    public class QuestionController : MainController
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpPost("/createQuestion")]
        public async Task<IActionResult> CreateQuestion(CreateQuestionModel createQuestionModel)
        {
            Respone createRespone=await _questionService.AddQuestionAsync(createQuestionModel);
            return Ok(createRespone);
        }
    }
}
