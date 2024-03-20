using Application.InterfaceService;
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
        /// <summary>
        /// Get question in quiz
        /// </summary>
        /// <param name="id">The quiz Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Respone> GetAllQuestionByQuizId (Guid id )
        {
            Respone respone = await _questionService.GetQuestionByQuizIdAsync(id);
            return respone;
        }
    }
}
