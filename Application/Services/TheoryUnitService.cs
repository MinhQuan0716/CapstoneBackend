using Application.InterfaceService;
using Application.ViewModel.ResponeModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TheoryUnitService : ITheoryUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TheoryUnitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Respone> GetAllTheoryUnit()
        {
            var result = await _unitOfWork.TheoryUnitRepository.GetAllAsync();
            return new Respone(HttpStatusCode.OK, "Fetch successfully", result);
        }

        public async Task<Respone> GetAllTheoryUnitByUnitId(Guid unitId)
        {
            var result = await _unitOfWork.TheoryUnitRepository.GetAllTheoryUnitByUnitId(unitId);
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }
    }
}
