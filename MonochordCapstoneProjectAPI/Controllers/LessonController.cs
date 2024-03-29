using Application.InterfaceService;
using Application.ViewModel.CourseModel;
using Application.ViewModel.ResponeModel;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MonochordCapstoneProjectAPI.Controllers
{
    
    public class LessonController :MainController
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        /// <summary>
        /// Get Lesson By user id
        /// </summary>
        /// <param name="Id">The user Id</param>
        /// <returns>Response Model</returns>
        [SwaggerResponse((int)HttpStatusCode.OK,"Get course by userId",typeof(Respone))]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetLessonByUserId()
        {
            var result = await _lessonService.GetAllLessonByUserId();
            return Ok(result);
        }
        /// <summary>
        /// Get lesson by lessonId
        /// </summary>
        /// <param name="id"> The Lesson Id</param>
        /// <returns>ResponeModel</returns>
        [SwaggerResponse((int)HttpStatusCode.OK,"Get course by courseId",typeof(Respone))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(Guid id)
        {
            var result = await _lessonService.GetLessonById(id);

            return Ok(result);
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
    }
}
