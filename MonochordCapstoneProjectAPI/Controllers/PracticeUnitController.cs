using Application.InterfaceService;
using Application.Services;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MonochordCapstoneProjectAPI.Controllers
{
    public class PracticeUnitController : MainController
    {
        private readonly IPracticeUnitService _practiceUnitService;
        public PracticeUnitController(IPracticeUnitService practiceUnitService)
        {
            _practiceUnitService = practiceUnitService;
        }
        [SwaggerResponse((int)HttpStatusCode.OK, "Get all practice by unit id", typeof(Respone))]
        [HttpGet("{id}")]
        public async Task<Respone> GetAllPracticeByUnitId(Guid id)
        {
            var respone = await _practiceUnitService.GetAllPracticeUnitByUnitId(id);
            return respone;
        }
    }
}
