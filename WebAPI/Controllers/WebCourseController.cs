using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    
    public class WebCourseController :MainController
    {
        private readonly ICourseService _courseService;
        public WebCourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseDetailViewModel model)
        {
            var result = await _courseService.CreateCourse(model);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(Guid id, CourseDetailViewModel model)
        {
            var result = await _courseService.UpdateCourse(id, model);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var result = await _courseService.DeleteCourse(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var result= await _courseService.GetAllCourse();
            if (result.Status == HttpStatusCode.OK.ToString())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
