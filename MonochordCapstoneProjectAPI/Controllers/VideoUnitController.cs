using Application.InterfaceService;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MonochordCapstoneProjectAPI.Controllers
{
    public class VideoUnitController : MainController
    {
        private readonly IVideoUnitService _videoUnitService;
        public VideoUnitController(IVideoUnitService videoUnitService)
        {
            _videoUnitService = videoUnitService;
        }
        [SwaggerResponse((int)HttpStatusCode.OK, "Get all Video", typeof(Respone))]
        [HttpGet]
        public async Task<Respone> GetALlVideoUnit()
        {
            var respone = await _videoUnitService.GetAllVideoyUnit();
            return respone;
        }
        /// <summary>
        /// Get all theory unit by UnitId
        /// </summary>
        /// /// <param name="Id">The Unit Id</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get all video by unit id", typeof(Respone))]
        [HttpGet("{id}")]
        public async Task<Respone> GetAllVideoUnitById(Guid id)
        {
            var respone = await _videoUnitService.GetAllVideoUnitByUnitId(id);
            return respone;
        }
    }
}