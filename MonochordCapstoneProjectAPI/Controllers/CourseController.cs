using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MonochordCapstoneProjectAPI.Controllers
{
   
    public class CourseController :MainController
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCourse(Guid Id)
        {
            var result = await _courseService.GetAllCourse(Id);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            var result = await _courseService.GetCourseById(id);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseDetailViewModel model)
        {
            var result = await _courseService.CreateCourse(model);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourt(Guid id, CourseDetailViewModel model)
        {
             var result = await _courseService.UpdateCourse(id, model);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourt(Guid id)
        {
            var result = await _courseService.DeleteCourse(id);
            return Ok(result);
        }
    }
}
