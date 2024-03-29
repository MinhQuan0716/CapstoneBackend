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
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UnitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Respone> DeleteUnit(Guid unitId)
        {
            var obj = await _unitOfWork.UnitRepository.GetByIdAsync(unitId);
            if (obj is not null)
            {
                _unitOfWork.UnitRepository.SoftRemove(obj);
                var result = await _unitOfWork.SaveChangeAsync();
                if (result > 0)
                {
                    return new Respone(HttpStatusCode.OK, "Delete Success");
                }
            }
            return new Respone(HttpStatusCode.InternalServerError, "Delete Failed");
        }

        public async Task<Respone> GetAllUnitByLessonId(Guid lessonId)
        {
            var result = await _unitOfWork.UnitRepository.GetAllUnitByLessonIdAsync(lessonId);
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }

        public async Task<Respone> GetUnitById(Guid unitId)
        {
            var result = await _unitOfWork.UnitRepository.GetByIdAsync(unitId);
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }
        public async Task<Respone> GetAllUnit()
        {
            var result = await _unitOfWork.UnitRepository.GetAllAsync();
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }
    }
}
