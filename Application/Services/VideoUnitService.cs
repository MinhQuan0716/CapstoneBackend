using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModel.ResponeModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VideoUnitService : IVideoUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VideoUnitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Respone> GetAllVideoUnitByUnitId(Guid unitId)
        {
            var result = await _unitOfWork.VideoUnitRepository.GetAllVideoUnitByUnitIdAsync(unitId);
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }

        public async Task<Respone> GetAllVideoyUnit()
        {
            var result = await _unitOfWork.VideoUnitRepository.GetAllAsync();
            return new Respone(HttpStatusCode.OK, "Fetch successfully", result);
        }
    }
}
