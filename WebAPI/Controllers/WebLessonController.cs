using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    
    public class WebLessonController :MainController
    {
        private readonly ILessonService _lessonService;
        public WebLessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateLesson(LessonDetailViewModel model)
        {
            var result = await _lessonService.CreateLesson(model);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(Guid id, LessonDetailViewModel model)
        {
            var result = await _lessonService.UpdateLesson(id, model);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(Guid id)
        {
            var result = await _lessonService.DeleteLesson(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLesson()
        {
            var result= await _lessonService.GetAllLesson();
            if (result.Status == HttpStatusCode.OK.ToString())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
