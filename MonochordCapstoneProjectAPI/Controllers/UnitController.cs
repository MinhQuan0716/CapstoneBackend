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
    public class UnitController :MainController
    {
        private readonly IUnitService _unitService;
        public UnitController(IUnitService unitService)
        {
            _unitService = unitService; 
        }
        /// <summary>
        /// Get Unit by LessonId
        /// </summary>
        /// <param name="id">The Lesson Id </param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get Unit by Lesson id", typeof(Respone))]
        [HttpGet("{id}")]
        public async Task<Respone> GettUnitByLessonId(Guid id)
        {
            var respone = await _unitService.GetAllUnitByLessonId(id);

            return respone;
        }
        /// <summary>
        /// Get Unit By Unit id
        /// </summary>
        /// <param name="Id">The Unit Id</param>
        /// <returns>Response Model</returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get Unit by Unit id", typeof(Respone))]
        [HttpGet("{id}")]
        public async Task<Respone> GetUnitById(Guid id)
        {
            var respone = await _unitService.GetUnitById(id);

            return respone;
        }
        /// <summary>
        /// Delete Unit 
        /// </summary>
        /// <param name="Id">The Unit Id</param>
        /// <returns>Response Model</returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Delete Unit", typeof(Respone))]
        [HttpDelete("{id}")]
        public async Task<Respone> DeleteUnit(Guid id)
        {
            var respone = await _unitService.DeleteUnit(id);
            return respone;
        }
        /// <summary>
        /// Get all Unit
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get All Unit", typeof(Respone))]
        [Authorize]
        [HttpGet]
        public async Task<Respone> GetAllUnit()
        {
            var respone = await _unitService.GetAllUnit();
            return respone;
        }
    }
}
