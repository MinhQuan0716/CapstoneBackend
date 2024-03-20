using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MonochordCapstoneProjectAPI.Controllers
{
    
    public class CourseController :MainController
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        /// <summary>
        /// Get Course By User id
        /// </summary>
        /// <param name="Id">The user Id</param>
        /// <returns>Response Model</returns>
        [SwaggerResponse((int)HttpStatusCode.OK,"Get course by userId",typeof(Respone))]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCourse(Guid Id)
        {
            var result = await _courseService.GetAllCourseByUserId(Id);
            if(result.Status==HttpStatusCode.OK.ToString())
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }
        /// <summary>
        /// Get course by courseId
        /// </summary>
        /// <param name="id"> The Course Id</param>
        /// <returns>ResponeModel</returns>
        [SwaggerResponse((int)HttpStatusCode.OK,"Get course by courseId",typeof(Respone))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            var result = await _courseService.GetCourseById(id);

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var result = await _courseService.GetAllCourse();
            if (result.Status == HttpStatusCode.OK.ToString())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
