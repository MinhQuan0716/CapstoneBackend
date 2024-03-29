using Application.InterfaceService;
using Application.ViewModel.AccountModel;
using Application.ViewModel.CourseModel;
using Application.ViewModel.ResponeModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Application.Services
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        public LessonService (IUnitOfWork unitOfWork, IMapper mapper, IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimService = claimService;
        }

        public async Task<Respone> CreateLesson(LessonDetailViewModel model)
        {
            var obj = _mapper.Map<Lesson>(model);
            obj.IsDelete = false;
            await _unitOfWork.LessonRepository.AddAsync(obj);
            var result = await _unitOfWork.SaveChangeAsync();
            if (result > 0)
            {
                return new Respone(HttpStatusCode.OK, "Add Suceess", model);
            }
            return new Respone(HttpStatusCode.InternalServerError, "Add False", model);
        }

        public async Task<Respone> DeleteLesson(Guid lessonId)
        {
            var obj = await _unitOfWork.LessonRepository.GetByIdAsync(lessonId);
            if (obj is not null)
            {
                _unitOfWork.LessonRepository.SoftRemove(obj);
                var result = await _unitOfWork.SaveChangeAsync();
                if (result > 0)
                {
                    return new Respone(HttpStatusCode.OK, "Delete Suceess");
                }
            }
            return new Respone(HttpStatusCode.InternalServerError, "Delete False");
        }

        public async Task<Respone> GetAllLesson()
        {
            List<Lesson> course = await _unitOfWork.LessonRepository.GetAllAsync();
            if (course.Any())
            {
                return new Respone(HttpStatusCode.OK, "Fetch successfully", course);
            }
            return new Respone(HttpStatusCode.BadRequest, "Fetch error");
        }

        public async Task<Respone> GetAllLessonByUserId()
        {
            var result = await _unitOfWork.LessonRepository.GetAllLessonByUserIdAsync(_claimService.GetCurrentUserId);
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }

        public async Task<Respone> GetLessonById(Guid lessonId)
        {
            var result = await _unitOfWork.LessonRepository.GetByIdAsync(lessonId);
            return new Respone(HttpStatusCode.OK, "fetch success", result);
        }
        public async Task<Respone> UpdateLesson(Guid lessonId, LessonDetailViewModel model)
        {
            var obj = await _unitOfWork.LessonRepository.GetByIdAsync(lessonId);
            if (obj is not null)
            {
                _mapper.Map(model, obj, typeof(LessonDetailViewModel), typeof(Lesson));
                _unitOfWork.LessonRepository.Update(obj);
                var result = await _unitOfWork.SaveChangeAsync();
                if (result > 0)
                {
                    return new Respone(HttpStatusCode.OK, "Update Suceess", model);
                }
            }
            return new Respone(HttpStatusCode.InternalServerError, "Update False");
        }
    }
}
