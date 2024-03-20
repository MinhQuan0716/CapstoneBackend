using Application.InterfaceService;
using Application.Services;
using Application.ViewModel.CourseModel;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Authorization;
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
        /// Get Lesson by CourseId
        /// </summary>
        /// <param name="id">The Course Id </param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get lesson by course id", typeof(Respone))]
        [HttpGet("{id}")]
        public async Task<Respone> GetLessonByCourseId(Guid id)
        {
            var respone = await _lessonService.GetAllLessonByCourseId(id);

            return respone;
        }
        /// <summary>
        /// Get Lesson By Lesson id
        /// </summary>
        /// <param name="Id">The Lesson Id</param>
        /// <returns>Response Model</returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get lesson by lesson id", typeof(Respone))]
        [HttpGet("{id}")]
        public async Task<Respone> GetLessonById(Guid id)
        {
            var respone = await _lessonService.GetLessonById(id);

            return respone;
        }
        /// <summary>
        /// Delete Lesson By Lesson id
        /// </summary>
        /// <param name="Id">The Lesson Id</param>
        /// <returns>Response Model</returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Delete lesson by lesson id", typeof(Respone))]
        [HttpDelete("{id}")]
        public async Task<Respone> DeleteLesson(Guid id)
        {
            var respone = await _lessonService.DeleteLesson(id);
            return respone;
        }
        /// <summary>
        /// Get all lesson
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get All Lesson", typeof(Respone))]
        [Authorize]
        [HttpGet]
        public async Task<Respone> GetAllAccount()
        {
            var respone = await _lessonService.GetAllLesson();
            return respone;
        }
    }
}
