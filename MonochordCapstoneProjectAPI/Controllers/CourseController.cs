using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("/courses")]
        public async Task<IActionResult> GetCourse()
        {
            IEnumerable<CourseViewModel> listCourse= await _courseService.GetAllCourse();
            if(listCourse.Any())
            {
                return Ok(listCourse);
            }
            return BadRequest();
        }
    }
}
