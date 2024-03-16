using Application.InterfaceService;
using Application.ViewModel.QuizModel;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MonochordCapstoneProjectAPI.Controllers
{
    public class QuizController : MainController
    {
        private readonly IQuizService _quizService;
        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }
        /* [HttpPost]
         public async Task<IActionResult> CreateQuiz(CreateQuizModel createQuizModel)
         {
             Respone createRespone = await _quizService.CreateQuizAsync(createQuizModel);
             return Ok(createRespone);
         }
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteQuiz(Guid id)
         {
             Respone deleteRespone = await _quizService.DeleteQuizAsync(id);
             return NoContent();
         }*/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizByLessonId(Guid id,[FromQuery] int pageIndex,int pageSize)
        {
            Respone getRespone = await _quizService.GetQuizAsync(id,pageIndex,pageSize);
            return Ok(getRespone);
        }
    }
}


