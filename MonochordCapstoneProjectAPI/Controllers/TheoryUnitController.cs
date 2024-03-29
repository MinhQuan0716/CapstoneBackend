using Application.InterfaceService;
using Application.ViewModel.ResponeModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MonochordCapstoneProjectAPI.Controllers
{
    public class TheoryUnitController : Controller
    {
        private readonly ITheoryUnitService _theoryUnitService;
        public TheoryUnitController(ITheoryUnitService theoryUnitService)
        {
           _theoryUnitService=theoryUnitService;
        }
        /// <summary>
        /// Get all theory unit
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get all theory lesson", typeof(Respone))]
        [HttpGet]
        public async Task<Respone> GetALlTheoryUnit()
        {
            var respone = await _theoryUnitService.GetAllTheoryUnit();
            return respone;
        }
        /// <summary>
        /// Get all theory unit by UnitId
        /// </summary>
        /// /// <param name="Id">The Unit Id</param>
        /// <returns></returns>
        [SwaggerResponse((int)HttpStatusCode.OK, "Get all theory by unit id", typeof(Respone))]
        [HttpGet("{id}")]
        public async Task<Respone> GetAllTheoryUnitById(Guid unitId)
        {
            var respone = await _theoryUnitService.GetAllTheoryUnitByUnitId(unitId);
            return respone;
        }
    }
}
