using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MonochordCapstoneProjectAPI.Controllers
{
    public class LessonController :MainController
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonByCourseId(Guid id)
        {
            var result = await _lessonService.GetAllLessonByCourseId(id);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(Guid id)
        {
            var result = await _lessonService.GetLessonById(id);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(Guid id)
        {
            var result = await _lessonService.DeleteLesson(id);
            return Ok(result);
        }
    }
}
