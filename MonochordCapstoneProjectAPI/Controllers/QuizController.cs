using Application.InterfaceService;
using Application.ViewModel.QuizModel;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MonochordCapstoneProjectAPI.Controllers
{
    public class QuizController : MainController
    {
        private readonly IQuizService _quizService;
        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }
        /// <summary>
        /// Get quiz by unit Id with pagination
        /// </summary>
        /// <param name="id">The unit id </param>
        /// <param name="pageIndex">The zero-based page index for the pagination. </param>
        /// <param name="pageSize">The number of items per page for the pagination.</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK,"Get quiz by lesson id with pagination",typeof(Respone))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizByLessonId(Guid id,[FromQuery] int pageIndex,[FromQuery] int pageSize)
        {
            Respone getRespone = await _quizService.GetQuizAsync(id,pageIndex,pageSize);
            return Ok(getRespone);
        }
    }
}


