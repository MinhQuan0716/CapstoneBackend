using Application.InterfaceService;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MonochordCapstoneProjectAPI.Controllers
{
    public class TheoryLessonController : Controller
    {
        private readonly ITheoryLessonService _theoryLessonService;
        public TheoryLessonController(ITheoryLessonService theoryLessonService)
        {
            _theoryLessonService = theoryLessonService;
        }
        /// <summary>
        /// Get all theory lesson
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get all theory lesson", typeof(Respone))]
        [HttpGet]
        public async Task<Respone> GetALlTheoryLesson()
        {
            var respone = await _theoryLessonService.GetAllTheoryLesson();
            return respone;
        }
        /// <summary>
        /// Get all theory lesson by lessonId
        /// </summary>
        /// /// <param name="Id">The Lesson Id</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get all theory by lesson id", typeof(Respone))]
        [HttpGet("{id}")]
        public async Task<Respone> GetAllTheoryLessonById(Guid lessonId)
        {
            var respone = await _theoryLessonService.GetAllTheoryLessonByLessonId(lessonId);
            return respone;
        }
    }
}
